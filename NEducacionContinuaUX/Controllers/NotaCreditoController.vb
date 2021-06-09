Imports System.Configuration

Public Class NotaCreditoController
    Dim xml As XmlService = New XmlService()
    Dim db As DataBaseService = New DataBaseService()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Sub GenerarNotaCredito(listaConceptos As List(Of Concepto), listaUUID As List(Of String), listaUUIDOriginal As List(Of String), RFC As String, NombreCompleto As String, usoCFDI As String,
                           montoTotal As String, subtotal As String, descuento As String, Matricula As String, ClaveNota As String)
        Try
            Dim FolioNota As String = Me.obtenerFolio()
            Dim Serie As String = FolioNota.Substring(0, 4)
            Dim Folio As String = FolioNota.Substring(4, 6)
            Dim NoCertificado As String = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()
            Dim Certificado As String = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
            Dim Fecha As String = db.exectSQLQueryScalar("select STUFF(CONVERT(VARCHAR(50),GETDATE(), 127) ,20,4,'') as fecha")
            Dim cadena As String = xml.cadenaNotaCredito(listaConceptos, listaUUID, montoTotal, subtotal, descuento, Fecha, Folio, Serie, NoCertificado, RFC, NombreCompleto, usoCFDI)
            Dim sello As String = st.Sellado("\\192.168.1.241\ti\NEducacionContinua\Timbrado\pfx\uxa_pfx33.pfx", "12345678a", cadena)
            Dim xmlString As String = xml.xmlNotaCredito(montoTotal, subtotal, descuento, Fecha, sello, Certificado, Folio, Serie, NoCertificado, RFC, NombreCompleto, usoCFDI, listaConceptos, listaUUID)
            xmlString = xmlString.Replace("utf-16", "UTF-8")
            Dim xmlTimbrado As String = st.Timbrado(xmlString, Folio)
            Dim IDReferencia As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatTipoNotaCredito WHERE ClaveNota = '{ClaveNota}'")
            Dim x As Integer = 0
            For Each concepto As Concepto In listaConceptos
                Dim uuid As String = listaUUIDOriginal(x)
                Dim IDXML As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_xmlTimbrados WHERE FolioFiscal = '{uuid}'")
                db.execSQLQueryWithoutParams($"INSERT INTO ing_NotasCredito(Matricula, IDTipoNota, FolioNota, Importe, Fecha, IDConcepto, IDClavePago, Descripcion, Usuario, UUIDFactura, Matricula, Aplicada, Activo) VALUES ('{concepto.Matricula}', {IDReferencia}, '{Serie}{Folio}', {concepto.costoFinal}, '{Fecha}', {concepto.IDConcepto}, {concepto.claveConcepto}, {concepto.NombreConcepto}, '{User.getUsername}', '{IDXML}', NULL, 0, 1)")
                x = x + 1
            Next
        Catch ex As Exception

        End Try


    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------OBTIENE FOLIO DE PAGO-----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Public Function obtenerFolio() As String
        Dim Serie As String
        Dim Consecutivo As Integer
        Serie = db.exectSQLQueryScalar($"SELECT Folio FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}' AND Descripcion = 'NOTACREDITO'")
        Consecutivo = db.exectSQLQueryScalar($"SELECT Consecutivo + 1 FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}' AND Descripcion = 'NOTACREDITO'")

        Dim ConsecutivoStr As String
        If (Consecutivo > 0 And Consecutivo < 10) Then
            ConsecutivoStr = $"00000{Consecutivo}"
        ElseIf (Consecutivo >= 10 And Consecutivo < 100) Then
            ConsecutivoStr = $"0000{Consecutivo}"
        ElseIf (Consecutivo >= 100 And Consecutivo < 1000) Then
            ConsecutivoStr = $"000{Consecutivo}"
        ElseIf (Consecutivo >= 1000 And Consecutivo < 10000) Then
            ConsecutivoStr = $"000{Consecutivo}"
        ElseIf (Consecutivo >= 10000 And Consecutivo < 100000) Then
            ConsecutivoStr = $"00{Consecutivo}"
        ElseIf (Consecutivo >= 100000 And Consecutivo < 1000000) Then
            ConsecutivoStr = $"0{Consecutivo}"
        ElseIf (Consecutivo >= 1000000 And Consecutivo < 10000000) Then
            ConsecutivoStr = $"{Consecutivo}"
        End If

        Return $"{Serie}{ConsecutivoStr}"
    End Function
End Class

