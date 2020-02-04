Public Class ConceptHandlerController
    Dim db As DataBaseService = New DataBaseService()
    Dim listaConceptos As New List(Of Concepto)

    Sub agregarconcepto(conceptoID As Integer, cantidad As Integer, gridConceptos As DataGridView, lblTotal As Label)
        Dim concepto As New Concepto
        concepto = Me.crearConcepto(conceptoID, cantidad)
        listaConceptos.Add(concepto)
        gridConceptos.Rows.Add(conceptoID, concepto.NombreConcepto, Format(CDec(concepto.costoUnitario), "#####0.00"), Format(CDec(concepto.costoIVAUnitario), "#####0.00"), Format(CDec(concepto.descuento), "#####0.00"), concepto.Cantidad)
        Me.actualizarTotal(listaConceptos, lblTotal, True)
    End Sub

    Function crearConcepto(conceptoID As Integer, cantidad As Integer) As Concepto
        Dim concepto As New Concepto()
        Dim tableConcepto As DataTable = db.getDataTableFromSQL("SELECT * FROM ing_ConceptosTemp WHERE ID = " & conceptoID & "")
        For Each item As DataRow In tableConcepto.Rows
            concepto.NombreConcepto = item("Nombre")
            concepto.cveClase = item("claveProductoServicio")
            concepto.cveUnidad = item("claveUnidad")
            concepto.costoUnitario = item("valorUnitario")
            concepto.descuento = item("Descuento")
            concepto.absorbeIVA = item("absorbeIVA")
            concepto.consideraIVA = item("consideraIVA")
            concepto.IVAExento = item("exentoIVA")
        Next
        concepto.Cantidad = cantidad


        If (concepto.absorbeIVA = True And concepto.IVAExento = False And concepto.consideraIVA = False) Then ''---ABSORBE IVA

            Dim costooriginal As Decimal = CDec(concepto.costoUnitario)
            Dim unitariosiniva As Decimal = (CDec(costooriginal) / 1.16)
            Dim unitariodescuento As Decimal = unitariosiniva - CDec(concepto.descuento)

            unitariosiniva = Me.getFormat(unitariosiniva)
            unitariodescuento = Me.getFormat(unitariodescuento)

            concepto.costoUnitario = unitariosiniva
            concepto.costoBase = unitariodescuento * CDec(concepto.Cantidad)
            concepto.costoIVAUnitario = (unitariodescuento * 0.16)
            concepto.costoIVATotal = (CDec(concepto.costoIVAUnitario) * CDec(concepto.Cantidad))
            concepto.costoTotal = unitariosiniva * CDec(concepto.Cantidad)
            concepto.costoFinal = (CDec(concepto.costoBase)) + (CDec(concepto.costoIVATotal))
            concepto.descuento = (CDec(concepto.descuento) * CDec(concepto.Cantidad))

        ElseIf (concepto.absorbeIVA = False And concepto.IVAExento = False And concepto.consideraIVA = True) Then ''---CONSIDERA IVA

            Dim unitariodescuento As Decimal = CDec(concepto.costoUnitario) - CDec(concepto.descuento)
            concepto.costoBase = unitariodescuento * CDec(concepto.Cantidad)
            unitariodescuento = unitariodescuento
            concepto.costoIVAUnitario = (unitariodescuento * 0.16)
            concepto.costoIVATotal = (CDec(concepto.costoIVAUnitario) * CDec(concepto.Cantidad))
            concepto.costoTotal = (CDec(concepto.costoUnitario) * CDec(concepto.Cantidad))
            concepto.costoFinal = ((unitariodescuento * CDec(concepto.Cantidad)) + CDec(concepto.costoIVATotal))
            concepto.descuento = (CDec(concepto.descuento) * CDec(concepto.Cantidad))

        ElseIf (concepto.absorbeIVA = False And concepto.IVAExento = True And concepto.consideraIVA = False) Then ''---IVA EXENTO

            concepto.costoIVAUnitario = "0.00000000"
            concepto.costoIVATotal = "0.00000000"
            concepto.costoTotal = (CDec(concepto.costoUnitario) * CDec(concepto.Cantidad))
            concepto.costoBase = concepto.costoTotal
            concepto.costoFinal = concepto.costoTotal

        ElseIf (concepto.absorbeIVA = False And concepto.IVAExento = False And concepto.consideraIVA = False) Then ''--- SIN IVA

            concepto.costoIVAUnitario = "0.00000000"
            concepto.costoIVATotal = "0.00000000"
            concepto.costoTotal = (CDec(concepto.costoUnitario) * CDec(concepto.Cantidad))
            concepto.costoFinal = concepto.costoTotal

        End If
        concepto = formatoPrecios(concepto)
        Return concepto
    End Function

    Function formatoPrecios(concepto As Concepto) As Concepto
        concepto.costoUnitario = Format(CDec(concepto.costoUnitario), "#####0.000000")
        concepto.costoTotal = Format(CDec(concepto.costoTotal), "#####0.00")
        concepto.costoIVAUnitario = Format(CDec(concepto.costoIVAUnitario), "#####0.000000")
        concepto.costoIVATotal = Format(CDec(concepto.costoIVATotal), "#####0.00")
        concepto.descuento = Format(CDec(concepto.descuento), "#####0.00")
        concepto.costoBase = Format(CDec(concepto.costoBase), "#####0.00")
        concepto.costoFinal = Format(CDec(concepto.costoFinal), "#####0.00")
        Return concepto
    End Function

    Sub actualizarTotal(listaConceptos As List(Of Concepto), lblTotal As Label, Tipo As Boolean)
        Dim Total As Decimal
        For Each concepto As Concepto In listaConceptos
            Total = Total + CDec(concepto.costoFinal)
        Next
        lblTotal.Text = Total.ToString()
    End Sub

    Function getFormat(cadena As String) As String
        Return Format(CDec(cadena), "#####0.00")
    End Function

    Function getListaConceptos() As List(Of Concepto)
        Return listaConceptos
    End Function
End Class