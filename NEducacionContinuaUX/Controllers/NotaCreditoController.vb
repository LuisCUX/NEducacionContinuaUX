Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Class NotaCreditoController
    Dim xml As XmlService40 = New XmlService40()
    Dim db As DataBaseService = New DataBaseService()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
    Sub GenerarNotaCredito(listaConceptos As List(Of Concepto), listaUUID As List(Of String), listaUUIDOriginal As List(Of String), ListaPorcentajes As List(Of String), ListaCostoOriginal As List(Of String), RFC As String, NombreCompleto As String, usoCFDI As String,
                           Matricula As String, ClaveNota As String, RegFiscal As String, Cp As String)
        Try
            db.startTransaction()
            Dim montototal As Decimal
            Dim subtotal As Decimal
            Dim descuento As Decimal
            Dim totalIVa As Decimal

            For Each concepto As Concepto In listaConceptos
                montototal = montototal + concepto.costoTotal
                subtotal = subtotal + concepto.CostoIvaBase
                totalIVa = totalIVa + concepto.costoIVATotal
            Next


            Dim FolioNota As String = Me.obtenerFolio()
            Dim Serie As String = FolioNota.Substring(0, 4)
            Dim Folio As String = FolioNota.Substring(4, 6)
            Dim Certificado As String
            Dim NoCertificado As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                Certificado = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
                NoCertificado = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()
            Else
                Certificado = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
                NoCertificado = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()
            End If
            Dim Fecha As String = db.exectSQLQueryScalar("select STUFF(CONVERT(VARCHAR(50),GETDATE(), 127) ,20,4,'') as fecha")
            Dim cadena As String = xml.cadenaNotaCredito(listaConceptos, listaUUID, montoTotal, subtotal, descuento, Fecha, Folio, Serie, NoCertificado, RFC, NombreCompleto, usoCFDI, Cp, RegFiscal)
            Dim sello As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                sello = st.Sellado("\\192.168.1.241\ti\NEducacionContinua\Timbrado\pfx\uxa_pfx33.pfx", "12345678a", cadena) ''PRUEBAS
            Else
                sello = st.Sellado("\\192.168.1.241\ti\NEducacionContinua\Timbrado\pfx\EDC.pfx", "EDC12345a", cadena) ''REAL
            End If
            Dim xmlString As String = xml.xmlNotaCredito(montoTotal, subtotal, descuento, Fecha, sello, Certificado, Folio, Serie, NoCertificado, RFC, NombreCompleto, usoCFDI, listaConceptos, listaUUID, RegFiscal, Cp)
            xmlString = xmlString.Replace("utf-16", "UTF-8")
            Dim xmlTimbrado As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                xmlTimbrado = st.TimbradoPruebas(xmlString, Folio)
            Else
                xmlTimbrado = st.Timbrado(xmlString, Folio)
            End If

            Dim FolioFiscalpre As String = Me.Extrae_Cadena(xmlTimbrado, "<tfd:TimbreFiscalDigital", "</cfdi:Complemento>")
            Dim folioFiscal As String = Me.Extrae_Cadena(FolioFiscalpre, "UUID=", " FechaTimbrado")
            folioFiscal = Me.Extrae_Cadena(folioFiscal, "=", "")
            folioFiscal = folioFiscal.Substring(1, folioFiscal.Length() - 1)

            Dim IDReferencia As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatTipoNotaCredito WHERE TipoNota = '{ClaveNota}'")

            Dim IDXML As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_xmlTimbrados(Matricula_Clave, Folio, FolioFiscal, Certificado, XMLTimbrado, fac_Cadena, fac_Sello, Tipo_Pago, Forma_Pago, Forma_PagoID, Fecha_Pago, Cajero, RegimenFiscal, Subtotal, Descuento, IVA, Total, usoCFDI, CanceladaHoy, CanceladaOtroDia) VALUES ('{Matricula}', '{Serie}{Folio}', '{folioFiscal}', '{NoCertificado}', '{xmlTimbrado}', '{cadena}', '{sello}', 'NOTA DE CREDITO', 99, 10, '{Fecha}', '{User.getUsername}', 'GENERAL DE LEY(603)', {subtotal}, 0.00, 0.00, {montoTotal}, '{usoCFDI}', 0, 0)")

            Dim x As Integer = 0
            For Each concepto As Concepto In listaConceptos
                Dim uuid As String = listaUUIDOriginal(x)
                Dim IDClaveConcepto As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE Clave = '{concepto.claveConcepto}'")
                Dim IDXMLRef As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_xmlTimbrados WHERE Folio = '{uuid}'")
                Dim IDXMLConcepto As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_xmlTimbradosConceptos WHERE XMLID = {IDXMLRef} AND IDConcepto = {concepto.IDConcepto} AND Clave_Concepto = {IDClaveConcepto}")
                db.execSQLQueryWithoutParams($"UPDATE ing_xmlTimbradosConceptos SET Nota = 1 WHERE ID = {IDXMLConcepto}")
                db.execSQLQueryWithoutParams($"INSERT INTO ing_NotasCredito(Matricula, IDTipoNota, FolioNota, FolioFiscal, Importe, Porcentaje, Fecha, IDConcepto, IDClavePago, Descripcion, Usuario, IDXML, MatriculaTransferir, Aplicada, Activo) VALUES ('{concepto.Matricula}', {IDReferencia}, '{Serie}{Folio}', '{listaUUID(x)}', {concepto.costoFinal}, {ListaPorcentajes(x)}, '{Fecha}', {concepto.IDConcepto}, {IDClaveConcepto}, '{concepto.NombreConcepto}', '{User.getUsername}', '{IDXMLConcepto}', NULL, 0, 1)")
                Dim IDNotaPasada As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_NotasCreditoPorcentajes WHERE IDXMLConcepto = {IDXMLConcepto}")

                If (IDNotaPasada > 0) Then
                    Dim montoAnterior As Decimal = Format(CDec(db.exectSQLQueryScalar($"SELECT Importe_Restante FROM ing_NotasCreditoPorcentajes WHERE ID = {IDNotaPasada}")), "#####0.00")
                    If (montoAnterior - concepto.costoFinal = 0) Then
                        db.execSQLQueryWithoutParams($"UPDATE ing_NotasCreditoPorcentajes SET Activo = 0, Importe_Restante = 0 WHERE ID = {IDNotaPasada}")
                    Else
                        db.execSQLQueryWithoutParams($"UPDATE ing_NotasCreditoPorcentajes SET Importe_Restante = Importe_Restante - {concepto.costoFinal} WHERE ID = {IDNotaPasada}")
                    End If
                Else
                    If (ListaPorcentajes(x) <> 100) Then
                        db.execSQLQueryWithoutParams($"INSERT INTO ing_NotasCreditoPorcentajes(Matricula, IDXMLConcepto, Importe_Restante, Porcentaje_Restante, IDConcepto, IDClavePago, Activo) VALUES ('{Matricula}', '{IDXMLConcepto}', {ListaCostoOriginal(x) - concepto.costoFinal}, {100 - ListaPorcentajes(x)}, {concepto.IDConcepto}, {IDClaveConcepto}, 1)")
                    End If
                End If
                Dim IDClave As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE Clave = '{concepto.claveConcepto}'")
                db.execSQLQueryWithoutParams($"INSERT INTO ing_xmlTimbradosConceptos(Clave_Cliente, XMLID, Nombre_Concepto, IDConcepto, Clave_Concepto, ClaveUnidad, PrecioUnitario, IVA, Descuento, Cantidad, Total, Nota) VALUES ('{concepto.Matricula}', {IDXML}, '{concepto.NombreConcepto}', {concepto.IDConcepto}, {IDClave}, '{concepto.cveUnidad}', {Format(CDec(concepto.costoUnitario), "#####0.00")}, {Format(CDec(concepto.costoIVAUnitario), "#####0.00")}, {Format(CDec(concepto.descuento), "#####0.00")}, {concepto.Cantidad}, {Format(CDec(((concepto.costoTotal - concepto.descuento) + concepto.costoIVATotal)), "#####0.00")}, 0)")
                x = x + 1
            Next

            Dim TotalText As String
            Dim valores As String()
            If (InStr(montoTotal, ".")) Then
                valores = Split(montoTotal, ".")
                TotalText = $"{Me.Num2Text(valores(0))} PESOS {valores(1)}/100 M.N"
            Else
                TotalText = $"{Me.Num2Text(montoTotal)} PESOS"
            End If

            Dim descripcionCFDI As String = db.exectSQLQueryScalar($"select UPPER('(' + clave_usoCFDI + ')' + ' ' + descripcion) As Clave from ing_cat_usoCFDI WHERE clave_usoCFDI = '{usoCFDI}'")
            Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={RFC}id={folioFiscal}tt={montoTotal}"
            Me.gernerarQr(QR, $"{Serie}{Folio}")
            rep.AgregarFuente("FacturaEDCNota.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("ClaveCliente", Matricula)
            rep.AgregarParametros("CantidadLetra", TotalText)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.MostrarReporte()
            db.commitTransaction()
            MessageBox.Show("Nota de credito generada correctamente")
            NotasDeCreditoEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
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
        db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = {Consecutivo} WHERE Usuario = '{User.getUsername()}' AND Descripcion = 'NOTACREDITO'")
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

    Public Function Extrae_Cadena(ByVal texto As String, ByVal limite_inicio As String, ByVal limite_fin As String)
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        Dim referencias_nodo As String = ""
        posicion1 = InStr(texto, limite_inicio)
        posicion2 = InStrRev(texto, limite_fin)
        referencias_nodo = texto.Substring(posicion1, posicion2 - 1 - posicion1)
        Return referencias_nodo
    End Function

    Public Function Num2Text(ByVal value As Double) As String
        Dim valores(2) As String  ' IMPORTE CON LETRA
        Dim bandera_numero_letra As Boolean = True ' IMPORTE CON LETRA
        Dim centavos As String 'IMPORTE CON LETRA
        'FUNCION PARA SACAR EL IMPORTE EN LETRA
        Dim valor

        If InStr(value, ".") Then
            valores = Split(value, ".")
            valor = valores(0)
        Else
            valor = value
            bandera_numero_letra = False
        End If

        If bandera_numero_letra = True Then
            bandera_numero_letra = False
            valores = Split(value, ".")
            centavos = valores(1)
        End If

        Select Case valor
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

    Public Sub gernerarQr(QR As String, Nombre As String)

        Try
            Dim img As New Bitmap(QR_Generator.Encode(QR.ToString), New Size(220, 220))
            ''img.Save($"\\{EnviromentService.serverIP}\ti\NEducacionContinua\QR\{Nombre}.png", Imaging.ImageFormat.Png)
            img.Save($"\\192.168.1.250\Reportes\NEDC\QR\{Nombre}.png", Imaging.ImageFormat.Png)
            Thread.Sleep(1500)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class

