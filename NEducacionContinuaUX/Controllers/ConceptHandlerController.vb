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
        Dim claveConceptoint As Integer
        If (claveConcepto = "POA" Or claveConcepto = "POE") Then
            Dim nombreTabla As String
            If (claveConcepto = "POA") Then
                nombreTabla = "ing_AsignacionPagoOpcionalAlumno"
                claveConceptoint = 1
            ElseIf (claveconcepto = "POE") Then
                nombreTabla = "ing_AsignacionPagoOpcionalExterno"
                claveConceptoint = 2
            End If
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT P.Nombre, P.claveProductoServicio, P.claveUnidad, A.costoUnitario, 0.00 As Descuento, P.considerarIVA, P.AgregaIVA, P.ExentaIVA, A.Cantidad FROM {nombreTabla} AS A
                                                                     INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                                     INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                                     WHERE A.ID = {conceptoID}")

            Dim condonacion As Object() = Me.obtenerDatosCondonacion(conceptoID, claveConceptoint)

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
                If (condonacion(0) > 0) Then
                    concep.Condonacion = True
                Else
                    concep.Condonacion = False
                End If
                concep.porcentajeCondonacion = condonacion(1)
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

            Dim condonacion As Object() = Me.obtenerDatosCondonacion(conceptoID, 3)

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
                If (condonacion(0) > 0) Then
                    concep.Condonacion = True
                Else
                    concep.Condonacion = False
                End If
                concep.porcentajeCondonacion = condonacion(1)
            Next
        ElseIf (claveConcepto = "COLIN") Then
            Dim Costo As Decimal
            Dim Descuento As Decimal
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, CON.clave_servicio, C.Importe, C.Descuento FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_Planes AS PL ON PL.ID = C.ID_Plan
                                                                      INNER JOIN portal_congreso AS CON ON CON.id_congreso = PL.ID_Congreso
                                                                      WHERE AC.ID = {conceptoID}")
            For Each item As DataRow In tableConcepto.Rows

                concep.IDConcepto = item("ID")
                concep.NombreConcepto = Me.removerEspaciosInicioFin(item("Descripcion"))
                concep.claveConcepto = claveConcepto
                concep.cveClase = item("clave_servicio")
                concep.cveUnidad = "E48"
                concep.costoUnitario = item("Importe")
                concep.descuento = item("Descuento")
                concep.absorbeIVA = True
                concep.consideraIVA = False
                concep.IVAExento = False
                concep.Cantidad = 1
            Next
        ElseIf (claveConcepto = "COL") Then
            Dim Costo As Decimal
            Dim Descuento As Decimal
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, CON.clave_servicio, C.Importe, C.Descuento FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_Planes AS PL ON PL.ID = C.ID_Plan
                                                                      INNER JOIN portal_congreso AS CON ON CON.id_congreso = PL.ID_Congreso
                                                                      WHERE AC.ID = {conceptoID}")
            For Each item As DataRow In tableConcepto.Rows

                concep.IDConcepto = item("ID")
                concep.NombreConcepto = Me.removerEspaciosInicioFin(item("Descripcion"))
                concep.claveConcepto = claveConcepto
                concep.cveClase = item("clave_servicio")
                concep.cveUnidad = "E48"
                concep.costoUnitario = item("Importe")
                concep.descuento = item("Descuento")
                concep.absorbeIVA = True
                concep.consideraIVA = False
                concep.IVAExento = False
                concep.Cantidad = 1
            Next
        ElseIf (claveConcepto = "COLPU") Then
            Dim Costo As Decimal
            Dim Descuento As Decimal
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, CON.clave_servicio, C.Importe, C.Descuento FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_Planes AS PL ON PL.ID = C.ID_Plan
                                                                      INNER JOIN portal_congreso AS CON ON CON.id_congreso = PL.ID_Congreso
                                                                      WHERE AC.ID = {conceptoID}")
            For Each item As DataRow In tableConcepto.Rows

                concep.IDConcepto = item("ID")
                concep.NombreConcepto = Me.removerEspaciosInicioFin(item("Descripcion"))
                concep.claveConcepto = claveConcepto
                concep.cveClase = item("clave_servicio")
                concep.cveUnidad = "E48"
                concep.costoUnitario = item("Importe")
                concep.descuento = item("Descuento")
                concep.absorbeIVA = True
                concep.consideraIVA = False
                concep.IVAExento = False
                concep.Cantidad = 1
            Next
        End If
        Return concep
    End Function

    Function crearConcepto(conceptoID As Integer, claveConcepto As String) As Concepto
        Dim concepto As New Concepto()
        concepto = Me.crearObjeto(conceptoID, claveConcepto)

        If (concepto.Condonacion = True) Then
            Dim porcentaje = concepto.costoUnitario * CDec(concepto.porcentajeCondonacion / 100)
            concepto.costoUnitario = concepto.costoUnitario - porcentaje
            concepto.descuento = 0.00
        End If

        If (concepto.absorbeIVA = True And concepto.IVAExento = False And concepto.consideraIVA = False) Then ''---ABSORBE IVA

            Dim costooriginal As Decimal = CDec(concepto.costoUnitario)
            Dim unitariosiniva As Decimal = (CDec(costooriginal) / 1.16)
            Dim unitariodescuento As Decimal = unitariosiniva - CDec(concepto.descuento)

            unitariosiniva = unitariosiniva
            unitariodescuento = unitariodescuento

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

    Function obtenerDatosCondonacion(conceptoID As Integer, claveID As Integer) As Object()
        Dim IDCondonacion As Integer = db.exectSQLQueryScalar($"SELECT ID FROM aut_Condonaciones WHERE ID_Concepto = {conceptoID} AND ID_ClaveConcepto = {claveID} AND Activo = 1")

        Dim porcentajeCondonacion As Decimal
        If (IDCondonacion > 0) Then
            porcentajeCondonacion = db.exectSQLQueryScalar($"SELECT Porcentaje FROM aut_Condonaciones WHERE ID = {IDCondonacion}")
        Else
            porcentajeCondonacion = 0
        End If
        Return {IDCondonacion, porcentajeCondonacion}
    End Function

    Sub limpiarListaConceptos()
        listaConceptos.Clear()
    End Sub
End Class