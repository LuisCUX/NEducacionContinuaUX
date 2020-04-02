Public Class ConceptHandlerController
    Dim db As DataBaseService = New DataBaseService()
    Dim listaConceptos As New List(Of Concepto)

    Sub agregarconcepto(conceptoID As Integer, claveConcepto As String)
        Dim concepto As New Concepto
        concepto = Me.crearConcepto(conceptoID, claveConcepto)
        listaConceptos.Add(concepto)
    End Sub

    Sub eliminarconcepto(conceptoID As Integer, claveConcepto As String)
        Dim concepto As New Concepto
        concepto = Me.crearConcepto(conceptoID, claveConcepto)
        listaConceptos.RemoveAll(Function(wea) wea.absorbeIVA = concepto.absorbeIVA And wea.Cantidad = concepto.Cantidad And wea.consideraIVA = concepto.consideraIVA And wea.costoBase = concepto.costoBase And wea.costoFinal = concepto.costoFinal And wea.costoIVATotal = concepto.costoIVATotal And wea.claveConcepto = concepto.claveConcepto And wea.IDConcepto = concepto.IDConcepto And
                                 wea.costoIVAUnitario = concepto.costoIVAUnitario And wea.costoTotal = concepto.costoTotal And wea.costoUnitario = concepto.costoUnitario And wea.cveClase = concepto.cveClase And wea.cveUnidad = concepto.cveUnidad And wea.descuento = concepto.descuento And wea.IVAExento = concepto.IVAExento And wea.NombreConcepto = concepto.NombreConcepto)
    End Sub

    Function crearObjeto(conceptoID As Integer, claveConcepto As String) As Concepto
        Dim concep As Concepto = New Concepto()

        If (claveConcepto = "POA" Or claveConcepto = "POE") Then
            Dim nombreTabla As String
            If (claveConcepto = "POA") Then
                nombreTabla = "ing_AsignacionPagoOpcionalAlumno"
            ElseIf (claveconcepto = "POE") Then
                nombreTabla = "ing_AsignacionPagoOpcionalExterno"
            End If
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT P.Nombre, P.claveProductoServicio, P.claveUnidad, A.costoUnitario, 0.00 As Descuento, P.considerarIVA, P.AgregaIVA, P.ExentaIVA, A.Cantidad FROM {nombreTabla} AS A
                                                                     INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                                     INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                                     WHERE A.ID = {conceptoID}")
            For Each item As DataRow In tableConcepto.Rows
                concep.IDConcepto = conceptoID
                concep.NombreConcepto = Me.removerEspaciosInicioFin(item("Nombre"))
                concep.claveConcepto = claveConcepto
                concep.cveClase = item("claveProductoServicio")
                concep.cveUnidad = item("claveUnidad")
                concep.costoUnitario = item("costoUnitario")
                concep.descuento = item("Descuento")
                concep.absorbeIVA = item("considerarIVA")
                concep.consideraIVA = item("AgregaIVA")
                concep.IVAExento = item("ExentaIVA")
                concep.Cantidad = item("Cantidad")
            Next
        ElseIf (claveConcepto = "CON") Then
            Dim Costo As Decimal
            Dim Descuento As Decimal
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT RC.id_registro, CON.nombre, CON.clave_servicio, 1 As considerarIVA, 0 As AgregaIVA, 0 As ExentaIVA, 1 As Cantidad, GETDATE() AS FechaHoy, SUB.costo_total, SUB.descuento FROM portal_registroCongreso AS RC
                                                                      INNER JOIN portal_cliente AS C ON C.id_cliente = RC.id_cliente
                                                                      INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                                      INNER JOIN portal_congreso AS CON ON CON.id_congreso = TA.id_congreso
                                                                      INNER JOIN portal_subtotales AS SUB ON SUB.clave_cliente = RC.clave_cliente
                                                                      INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = 3
                                                                      WHERE RC.id_registro = {conceptoID}")
            For Each item As DataRow In tableConcepto.Rows

                concep.IDConcepto = item("id_registro")
                concep.NombreConcepto = Me.removerEspaciosInicioFin(item("nombre"))
                concep.claveConcepto = claveConcepto
                concep.cveClase = item("clave_servicio")
                concep.cveUnidad = "E48"
                concep.costoUnitario = item("costo_total")
                concep.descuento = item("descuento")
                concep.absorbeIVA = item("considerarIVA")
                concep.consideraIVA = item("AgregaIVA")
                concep.IVAExento = item("ExentaIVA")
                concep.Cantidad = item("Cantidad")
            Next
        End If
        Return concep
    End Function

    Function crearConcepto(conceptoID As Integer, claveConcepto As String) As Concepto
        Dim concepto As New Concepto()
        concepto = Me.crearObjeto(conceptoID, claveConcepto)

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

    Function removerEspaciosInicioFin(cadena As String) As String
        Dim first As String = cadena.Substring(0, 1)
        Dim last As String = cadena.Substring(cadena.Length() - 1, 1)

        If (first = " " And last <> " ") Then
            Return cadena.Substring(1, cadena.Length() - 1)
        ElseIf (first <> " " And last = " ") Then
            Return cadena.Substring(0, cadena.Length() - 2)
        ElseIf (first = " " And last = " ") Then
            cadena = cadena.Substring(1, cadena.Length() - 1)
            Return cadena.Substring(0, cadena.Length() - 2)
        ElseIf (first <> " " And last <> " ") Then
            Return cadena
        End If
        Return Nothing
    End Function

    Sub limpiarListaConceptos()
        listaConceptos.Clear()
    End Sub
End Class