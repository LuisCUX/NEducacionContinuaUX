Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Class CobrosDiferidosController
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim xml As XmlService = New XmlService()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim co As CobrosController = New CobrosController()
    Dim es As EmailService = New EmailService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder

    Function Cobrar(listaConceptos As List(Of Concepto), formaPago As String, RFCCLiente As String, NombreCLiente As String, Monto As String, MatriculaGeneral As String, Credito As Boolean, tipocliente As Integer) As Integer

        Dim montoDec As Decimal = CDec(Monto)
        Dim folioPago As String = co.obtenerFolio("Pago")
        Try
            db.startTransaction()
            ''---------------------------------------------------------CALCULO DE TOTALES---------------------------------------------------------
            Dim Certificado As String
            Dim NoCertificado As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                Certificado = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
                NoCertificado = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()
            Else
                Certificado = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
                NoCertificado = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()
            End If

            Dim subtotalSuma As Decimal
            For Each concepto As Concepto In listaConceptos
                subtotalSuma = subtotalSuma + CDec(concepto.costoTotal)
            Next
            Dim SubTotal As String = subtotalSuma.ToString()

            Dim totalSuma As Decimal
            For Each concepto As Concepto In listaConceptos
                totalSuma = totalSuma + CDec(concepto.costoFinal)
            Next
            Dim Total As String = totalSuma.ToString()
            Dim totalIVASuma As Decimal
            For Each concepto As Concepto In listaConceptos
                totalIVASuma = totalIVASuma + CDec(concepto.costoIVATotal)
            Next
            Dim totalIVA As String = totalIVASuma.ToString()

            Dim Descuento As Decimal
            For Each concepto As Concepto In listaConceptos
                Descuento = Descuento + CDec(concepto.descuento)
            Next
            Dim DescuentoS As String = Descuento.ToString()
            Dim Folio As String = folioPago.Substring(1, 6)
            Dim Serie As String = folioPago.Substring(0, 1)
            Dim UsoCFDI As String = "P01"

            SubTotal = ch.getFormat(SubTotal)
            totalIVA = ch.getFormat(totalIVA)
            DescuentoS = ch.getFormat(DescuentoS)
            Total = ((CDec(SubTotal) - CDec(Descuento)) + CDec(totalIVA))



            Dim TotalText As String
            Dim valores As String()
            If (InStr(Total, ".")) Then
                valores = Split(Total, ".")
                TotalText = $"{co.Num2Text(valores(0))} PESOS {valores(1)}/100 M.N"
            Else
                TotalText = $"{co.Num2Text(Total)} PESOS"
            End If
            Dim Fecha As String = db.exectSQLQueryScalar("select STUFF(CONVERT(VARCHAR(50),GETDATE(), 127) ,20,4,'') as fecha")
            MessageBox.Show(Fecha)

            ''---------------------------------------------------------REGISTRO DE COBRO/S EN BASE DE DATOS---------------------------------------------------------
            For Each concepto As Concepto In listaConceptos
                If (concepto.claveConcepto = "POA") Then
                    co.cobrarPagoOpcionalAlumno(concepto, concepto.Matricula, folioPago)
                ElseIf (concepto.claveConcepto = "POE") Then
                    co.cobrarPagoOpcionalExterno(concepto, concepto.Matricula, folioPago)
                ElseIf (concepto.claveConcepto = "POC") Then
                    co.cobrarPagoOpcionalCongreso(concepto, concepto.Matricula, folioPago)
                ElseIf (concepto.claveConcepto = "CON") Then
                    co.cobrarCongreso(concepto, concepto.Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "DCO") Then
                    co.cobrarColegiaturaDiplomado(concepto, concepto.Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "DIN") Then
                    co.cobrarInscripcionDiplomado(concepto, concepto.Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "DPU") Then
                    co.cobrarPagoUnicoDiplomado(concepto, concepto.Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "REC") Then
                    co.cobrarRecargoDiplomado(concepto, concepto.Matricula, $"{Serie}{Folio}", formaPago)
                End If
            Next

            ''---------------------------------------------------------TIMBRADO---------------------------------------------------------
            Dim cadena = xml.cadenaPrueba(Serie, Folio, Fecha, formaPago, NoCertificado, SubTotal, DescuentoS, Total, listaConceptos, totalIVA, RFCCLiente, NombreCLiente, Credito)
            ''Dim sello As String = st.Sellado("C:\Users\darkz\Desktop\pfx\uxa_pfx33.pfx", "12345678a", cadena)
            Dim sello As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                sello = st.Sellado("\\192.168.1.252\Sistemas\Reportes\EducacionContinua\Timbrado\pfx\uxa_pfx33.pfx", "12345678a", cadena)
            Else
                sello = st.Sellado("\\192.168.1.252\Sistemas\Reportes\EducacionContinua\Timbrado\pfx\EDC.pfx", "EDC12345a", cadena) ''REAL
            End If
            Dim xmlString As String = xml.xmlPrueba(Total, SubTotal, DescuentoS, totalIVA, Fecha, sello, Certificado, NoCertificado, formaPago, Folio, Serie, UsoCFDI, listaConceptos, RFCCLiente, NombreCLiente, Credito)
            xmlString = xmlString.Replace("utf-16", "UTF-8")
            Dim xmlTimbrado As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                xmlTimbrado = st.TimbradoPruebas(xmlString, Folio)
            Else
                xmlTimbrado = st.Timbrado(xmlString, Folio)
            End If

            Dim folioFiscal As String = co.Extrae_Cadena(xmlTimbrado, "UUID=", " FechaTimbrado")
            folioFiscal = co.Extrae_Cadena(folioFiscal, "=", "")
            folioFiscal = folioFiscal.Substring(1, folioFiscal.Length() - 1)

            ''---------------------------------------------------------GENERACION DE FACTURA---------------------------------------------------------
            Dim formapagoid As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")

            Dim IDXML As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_xmlTimbrados(Matricula_Clave, Folio, FolioFiscal, Certificado, XMLTimbrado, fac_Cadena, fac_Sello, Tipo_Pago, Forma_Pago, Forma_PagoID, Fecha_Pago, Cajero, RegimenFiscal, Subtotal, Descuento, IVA, Total, usoCFDI, CanceladaHoy, CanceladaOtroDia) VALUES ('{MatriculaGeneral}', '{Serie}{Folio}', '{folioFiscal}', '{NoCertificado}', '{xmlTimbrado}', '{cadena}', '{sello}', 'COBRO DIFERIDO DE CONCEPTO A MATRICULA {MatriculaGeneral}', '{formaPago}', {formapagoid}, '{Fecha}', '{User.getUsername}', 'GENERAL DE LEY(603)', {SubTotal}, {DescuentoS}, {totalIVA}, {Total}, '{UsoCFDI}', 0, 0)")
            For Each item As Concepto In listaConceptos
                db.execSQLQueryWithoutParams($"INSERT INTO ing_xmlTimbradosConceptos(Clave_Cliente, XMLID, Nombre_Concepto, Clave_Concepto, ClaveProdServ, ClaveUnidad, PrecioUnitario, IVA, Descuento, Cantidad, Total) VALUES ('{item.Matricula}', {IDXML}, '{item.NombreConcepto}', {1}, '{item.cveUnidad}', '{item.cveClase}', {item.costoUnitario}, {item.costoIVAUnitario}, {item.descuento}, {item.Cantidad}, {item.costoTotal})")
            Next
            db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Usuario = '{User.getUsername()}'")

            ''---------------------------------------------------------ENVIO DE EMAIL---------------------------------------------------------''
            Dim mail As New Mail
            Dim archivo_pdf As Byte() = Nothing
            Dim archivo_xml As Byte() = Nothing

            archivo_pdf = rep.obtenerReporteByte()
            archivo_xml = Encoding.Default.GetBytes(xmlTimbrado)

            mail.Destino = "luis.c@ux.edu.mx"
            mail.Asunto = "GRACIAS POR SU PAGO"
            mail.Mensaje = "ANEXAMOS TUS COMPROBANTES DE PAGO ADJUNTOS A ESTE CORREO, GRACIAS."
            mail.BytesFile = archivo_pdf
            mail.BytesFile2 = archivo_xml
            mail.FileName = "Factura"
            mail.FileName2 = "xml"

            es.sendEmailWithFileBytesCobro(mail)
            MessageBox.Show("XML completado")
            Dim descripcionCFDI As String = db.exectSQLQueryScalar($"select UPPER('(' + clave_usoCFDI + ')' + ' ' + descripcion) As Clave from ing_cat_usoCFDI WHERE clave_usoCFDI = '{UsoCFDI}'")
            Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={RFCCLiente}id={folioFiscal}tt={Total}"
            co.gernerarQr(QR, $"{Serie}{Folio}")
            rep.AgregarFuente("FacturaEDC.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("CantidadLetra", TotalText)
            rep.AgregarParametros("ClaveCliente", MatriculaGeneral)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.AgregarParametros("TipoCliente", tipocliente)
            rep.MostrarReporte()
            db.commitTransaction()
            Return IDXML
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
            CobrosEDC.Reiniciar()
        End Try
    End Function

    Function buscarCongreso(Matricula As String) As Integer
        Dim IDConcepto As Integer
        Dim tablePagosOpcionales As DataTable = db.getDataTableFromSQL($"SELECT RC.id_registro, CP.Clave, SUB.costo_total, SUB.descuento, CON.nombre, 1 As Cantidad, 1 As considerarIVA, 0 As AgregaIVA, 0 As exentaIVA FROM portal_registroCongreso AS RC
                                                                         INNER JOIN portal_cliente AS C ON C.id_cliente = RC.id_cliente
                                                                         INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                                         INNER JOIN portal_congreso AS CON ON CON.id_congreso = TA.id_congreso
                                                                         INNER JOIN portal_subtotales AS SUB ON SUB.clave_cliente = RC.clave_cliente
                                                                         INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = 3
                                                                         WHERE RC.clave_cliente = '{Matricula}' AND RC.clave_cliente NOT IN (SELECT Matricula FROM ing_PagosCongresos)")
        For Each item As DataRow In tablePagosOpcionales.Rows
            MainCobrosDiferidosEDC.GridConceptos.Rows.Add(item("id_registro"), "CON", Matricula, item("nombre"), item("costo_total"))
            IDConcepto = item("id_registro")
        Next
        Return IDConcepto
    End Function
End Class
