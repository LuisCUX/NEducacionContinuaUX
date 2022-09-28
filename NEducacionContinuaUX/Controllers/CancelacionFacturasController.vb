Imports System.Xml

Public Class CancelacionFacturasController
    Dim db As DataBaseService = New DataBaseService

    Sub CancelarPagos(Matricula As String, IDXml As Integer, Folio As String, TableConceptos As DataTable)

        For Each concepto As DataRow In TableConceptos.Rows

            If (concepto("Clave_Concepto") = 1) Then ''POA PAGOS OPCIONALES ALUMNOS
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalAlumno SET Activo = 1, folioPago = NULL WHERE Matricula = '{Matricula}' AND ID = {concepto("IDConcepto")}")
            ElseIf (concepto("Clave_Concepto") = 2) Then ''POE PAGOS OPCIONALES EXTERNOS
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalExterno SET Activo = 1, folioPago = NULL WHERE MatriculaExterna = '{Matricula}' AND ID = {concepto("IDConcepto")}")
            ElseIf (concepto("Clave_Concepto") = 3) Then ''CON CONGRESOS
                db.execSQLQueryWithoutParams($"UPDATE ing_PagosCongresos SET Activo = 0 WHERE Matricula = '{Matricula}' AND Folio = '{Folio}'")
            ElseIf (concepto("Clave_Concepto") = 4) Then ''DCO COLEGIATURA DIPLOMADO
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1, Folio = NULL WHERE ID = {concepto("IDConcepto")}")
            ElseIf (concepto("Clave_Concepto") = 5) Then ''DPU PAGO UNICO DIPLOMADO
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1, Folio = NULL WHERE ID = {concepto("IDConcepto")}")
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 4")
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 6")
            ElseIf (concepto("Clave_Concepto") = 6) Then ''DIN INSCRIPCION DIPLOMADO
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1, Folio = NULL WHERE ID = {concepto("IDConcepto")}")
            ElseIf (concepto("Clave_Concepto") = 7) Then ''REC RECARGO
                db.execSQLQueryWithoutParams($"UPDATE ing_PlanesRecargos SET Folio = NULL, Activo = 1 WHERE ID = {concepto("IDConcepto")}")
            End If
        Next

        Dim IDAbono As Integer = Me.buscarAbono(Folio)
        If (IDAbono > 0) Then
            db.execSQLQueryWithoutParams($"UPDATE ing_Abonos SET Activo = 0 WHERE ID = {IDAbono}")
        End If
    End Sub

    Function buscarAbono(Folio As String) As Integer
        Return db.exectSQLQueryScalar($"SELECT ID FROM ing_Abonos WHERE Folio = '{Folio}'")
    End Function

    Function obtenerxmlAcuse(FolioFactura As String) As String
        Dim FolioFiscal As String
        Dim RFCReceptor As String
        Dim RFCEmisor As String
        Dim EstadoCFDI As String
        Dim EstadoCancelacion As String
        Dim Fecha As String
        Dim selloSAT As String
        Dim co As CobrosController = New CobrosController

        Dim xmlTimbrado As String = db.exectSQLQueryScalar($"SELECT XMLTimbrado FROM ing_xmlTimbrados WHERE Folio = '{FolioFactura}'")
        FolioFiscal = db.exectSQLQueryScalar($"SELECT FolioFiscal FROM ing_xmlTimbrados WHERE Folio = '{FolioFactura}'")
        RFCReceptor = db.exectSQLQueryScalar($"SELECT RFCTimbrado FROM ing_xmlTimbrados WHERE Folio = '{FolioFactura}'")
        RFCEmisor = EnviromentService.RFCEDC
        EstadoCancelacion = db.exectSQLQueryScalar($"SELECT estatusCancelacion FROM Ing_Cancelaciones WHERE Folio = '{FolioFactura}'")

        Dim xmlDoc As New XmlDocument
        xmlDoc.LoadXml(xmlTimbrado)
        selloSAT = xmlDoc.FirstChild.NextSibling.LastChild.FirstChild.Attributes.GetNamedItem("SelloSAT").Value

        If (System.Diagnostics.Debugger.IsAttached) Then
            Dim ServicioTimbrado As New TimbradoUXPruebas.WSCFDI33Client
            Dim RespuestaReal As New TimbradoUXPruebas.RespuestaTFD33
            Dim referencia As String = FolioFactura.Substring(1, FolioFactura.Length - 1)
            RespuestaReal = ServicioTimbrado.ConsultarTimbrePorReferencia("ECU150924HR4", "JCXM5@uUgr+", referencia)
            EstadoCFDI = RespuestaReal.Timbre.Estado
        Else
            Dim ServicioTimbrado As New TimbradoUXReal.WSCFDI33Client
            Dim RespuestaReal As New TimbradoUXReal.RespuestaTFD33
            Dim referencia As String = FolioFactura.Substring(1, FolioFactura.Length - 1)
            RespuestaReal = ServicioTimbrado.ConsultarTimbrePorReferencia("ECU150924HR4", "JCXM5@uUgr+", referencia)
            EstadoCFDI = RespuestaReal.Timbre.Estado
        End If

        Dim acusexml As String = db.exectSQLQueryScalar($"SELECT xmlAcuse FROM Ing_Cancelaciones WHERE Folio = '{FolioFactura}' AND Activo = 1")
        Dim xmlDoc2 As New XmlDocument
        xmlDoc2.LoadXml(acusexml)

        Fecha = xmlDoc2.FirstChild.NextSibling.Attributes.GetNamedItem("Fecha").Value

        Dim rep As ImpresionReportesService = New ImpresionReportesService()
        rep.AgregarFuente("AcuseCancelacion.rpt")
        rep.AgregarParametros("FolioInterno", FolioFactura)
        rep.AgregarParametros("FolioFiscal", FolioFiscal)
        rep.AgregarParametros("RFCReceptor", RFCReceptor)
        rep.AgregarParametros("RFCEmisor", RFCEmisor)
        rep.AgregarParametros("EstadoCFDI", EstadoCFDI)
        rep.AgregarParametros("EstadoCanc", EstadoCancelacion)
        rep.AgregarParametros("Fecha", Fecha)
        rep.AgregarParametros("selloSAT", selloSAT)
        rep.MostrarReporte()
    End Function
End Class