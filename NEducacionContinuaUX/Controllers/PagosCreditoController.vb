Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Public Class PagosCreditoController
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim xml As XmlService40 = New XmlService40()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Dim abono As Boolean = False
    Dim co As CobrosController = New CobrosController()
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder

    Function cobroCredito(IDCredito As Integer, CantidadAbonada As Decimal, MontoAnterior As Decimal, MontoNuevo As Decimal, Matricula As String, NumPago As Integer, RFC As String, NombreCompleto As String, FolioFiscal As String, NoParcialidad As Integer, FormaPago As String, RegFiscal As String, CP As String) As Integer
        Try
            db.startTransaction()
            Dim FolioPago As String = co.obtenerFolio("Pago")
            Dim Folio As String = FolioPago.Substring(1, 6)
            Dim Serie As String = FolioPago.Substring(0, 1)
            Dim UsoCFDI As String = "S01"
            Dim Fecha As String = db.exectSQLQueryScalar("select STUFF(CONVERT(VARCHAR(50),GETDATE(), 127) ,20,4,'') as fecha")
            Dim Certificado As String
            Dim NoCertificado As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                Certificado = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
                NoCertificado = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()
            Else
                Certificado = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
                NoCertificado = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()
            End If
            Dim serieOriginal As String = db.exectSQLQueryScalar($"select SUBSTRING(Folio, 1, 1) from ing_Creditos where ID = {IDCredito}")
            Dim folioOriginal As String = db.exectSQLQueryScalar($"select SUBSTRING(Folio, 2, DATALENGTH(Folio)) from ing_Creditos where ID = {IDCredito}")
            Dim FechaOriginal As String = db.exectSQLQueryScalar($"select STUFF(CONVERT(VARCHAR(50),Fecha, 127) ,20,4,'') as fecha from ing_Creditos where ID = {IDCredito}")

            Dim Cadena As String = xml.cadenaCredito(Serie, Folio, Fecha, NoCertificado, Certificado, RFC, NombreCompleto, UsoCFDI, FolioFiscal, serieOriginal, folioOriginal, NoParcialidad, MontoAnterior, CantidadAbonada, MontoNuevo, FechaOriginal, FormaPago, CP, RegFiscal)
            Dim sello As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                sello = st.Sellado("\\192.168.1.252\Sistemas\Reportes\EducacionContinua\Timbrado\pfx\uxa_pfx33.pfx", "12345678a", Cadena) ''PRUEBAS
            Else
                sello = st.Sellado("\\192.168.1.252\Sistemas\Reportes\EducacionContinua\Timbrado\pfx\EDC.pfx", "EDC12345a", Cadena) ''REAL
            End If
            Dim xmlString As String = xml.xmlCredito(Serie, Folio, Fecha, NoCertificado, sello, Certificado, RFC, NombreCompleto, UsoCFDI, FolioFiscal, serieOriginal, folioOriginal, NoParcialidad, MontoAnterior, CantidadAbonada, MontoNuevo, FechaOriginal, FormaPago, RegFiscal, CP)
            xmlString = xmlString.Replace("utf-16", "UTF-8")
            Dim xmlTimbrado As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                xmlTimbrado = st.TimbradoPruebas(xmlString, Folio)
            Else
                xmlTimbrado = st.Timbrado(xmlString, Folio)
            End If
            Dim folioFiscalNuevo As String = Me.Extrae_Cadena(xmlTimbrado, "UUID=", " FechaTimbrado")
            FolioFiscal = Me.Extrae_Cadena(FolioFiscal, "=", "")
            FolioFiscal = FolioFiscal.Substring(1, FolioFiscal.Length() - 1)
            File.WriteAllText("C:\Users\Luis\Desktop\wea.xml", xmlTimbrado)

            db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosCredito(ID_Credito, Folio, NumPago, Monto_Anterior, Monto_Actual, Monto_Abonado, Fecha, Activo) VALUES ({IDCredito}, '{FolioPago}', {NumPago}, {MontoAnterior}, {MontoNuevo}, {CantidadAbonada}, GETDATE(), 1)")
            db.execSQLQueryWithoutParams($"UPDATE ing_Creditos SET NumAbonos = NumAbonos + 1, Cantidad_Abonada = Cantidad_Abonada + {CantidadAbonada} WHERE ID = {IDCredito}")
            db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Usuario = '{User.getUsername()}'")

            Dim formapagoid As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{FormaPago}'")
            Dim XMLID = db.insertAndGetIDInserted($"INSERT INTO ing_xmlTimbrados(Matricula_Clave, Folio, FolioFiscal, Certificado, XMLTimbrado, fac_Cadena, fac_Sello, Tipo_Pago, Forma_Pago, Forma_PagoID, Fecha_Pago, Cajero, RegimenFiscal, RFCTimbrado, Subtotal, Descuento, IVA, Total, usoCFDI, CanceladaHoy, CanceladaOtroDia) VALUES ('{Matricula}', '{Serie}{Folio}', '{FolioFiscal}', '{NoCertificado}', '{xmlTimbrado}', '{Cadena}', '{sello}', 'PAGO DE CREDITO', '{FormaPago}', {formapagoid}, '{Fecha}', '{User.getUsername}', 'GENERAL DE LEY(603)', {RFC}, 0, 0, 0, 0, '{UsoCFDI}', 0, 0)")
            db.execSQLQueryWithoutParams($"INSERT INTO ing_xmlTimbradosConceptos(Clave_Cliente, XMLID, Nombre_Concepto, IDConcepto, Clave_Concepto, ClaveUnidad, PrecioUnitario, IVA, Descuento, Cantidad, Total) VALUES ('{Matricula}', {XMLID}, 'PAGO', {IDCredito}, 1, 'E48', 0, 0, 0, 1, 0)")
            If (MontoNuevo = 0) Then
                db.execSQLQueryWithoutParams($"UPDATE ing_Creditos SET Activo = 0 WHERE ID = {IDCredito}")
            End If
            Dim descripcionCFDI As String = db.exectSQLQueryScalar($"select UPPER('(' + clave_usoCFDI + ')' + ' ' + descripcion) As Clave from ing_cat_usoCFDI WHERE clave_usoCFDI = '{UsoCFDI}'")

            Dim TotalText As String
            Dim valores As String()
            If (InStr(CantidadAbonada.ToString(), ".")) Then
                valores = Split(CantidadAbonada.ToString(), ".")
                TotalText = $"{co.Num2Text(valores(0))} PESOS {valores(1)}/100 M.N"
            Else
                TotalText = $"{co.Num2Text(CantidadAbonada.ToString())} PESOS"
            End If

            Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={RFC}id={FolioFiscal}tt=0"
            Me.gernerarQr(QR, $"{Serie}{Folio}")
            MessageBox.Show("Abono registrado correctamente")
            rep.AgregarFuente("FacturaEDCCredito.rpt")
            rep.AgregarParametros("IDXML", XMLID)
            rep.AgregarParametros("CantidadLetra", TotalText)
            rep.AgregarParametros("ClaveCliente", Matricula)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.MostrarReporte()
            db.commitTransaction()
            Return XMLID
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
            Return 0
        End Try
    End Function


    Public Function Extrae_Cadena(ByVal texto As String, ByVal limite_inicio As String, ByVal limite_fin As String)
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        Dim referencias_nodo As String = ""
        posicion1 = InStr(texto, limite_inicio)
        posicion2 = InStrRev(texto, limite_fin)
        referencias_nodo = texto.Substring(posicion1, posicion2 - 1 - posicion1)
        Return referencias_nodo
    End Function

    Public Sub gernerarQr(QR As String, Nombre As String)
        Try
            Dim img As New Bitmap(QR_Generator.Encode(QR.ToString), New Size(220, 220))
            img.Save($"\\{EnviromentService.serverIP}\ti\NEducacionContinua\QR\{Nombre}.png", Imaging.ImageFormat.Png)
            Thread.Sleep(1500)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
