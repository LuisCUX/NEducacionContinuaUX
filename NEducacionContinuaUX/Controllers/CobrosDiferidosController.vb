Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Public Class CobrosDiferidosController
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim xml As XmlService = New XmlService()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim co As CobrosController = New CobrosController()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder

    Function Cobrar(listaConceptos As List(Of Concepto), formaPago As String, RFCCLiente As String, NombreCLiente As String, Monto As String, MatriculaGeneral As String, Credito As Boolean) As Integer

        Dim montoDec As Decimal = CDec(Monto)
        Dim folioPago As String = co.obtenerFolio("Pago")
        Try
            db.startTransaction()
            ''---------------------------------------------------------CALCULO DE TOTALES---------------------------------------------------------
            Dim Certificado As String = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
            Dim NoCertificado As String = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()

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

            If (Total <> montoDec) Then
                If (montoDec > Total) Then
                    db.rollBackTransaction()
                    MessageBox.Show("No puede ingresar un monto mayor al total a pagar, ingrese un monto valido")
                    Exit Function
                Else
                    If (listaConceptos.Count() > 1) Then
                        db.rollBackTransaction()
                        MessageBox.Show("No puede abonar a mas de un concepto, favor de seleccionar un concepto valido")
                        Exit Function
                    Else
                        Dim result As Integer = MessageBox.Show($"Se abonara ${montoDec} al concepto seleccionado, el concepto se considerara como pagado hasta que el monto sea pagado en su totalidad. ¿Desea registrar el abono?", "Confirmacion", MessageBoxButtons.YesNoCancel)
                        If result = DialogResult.Cancel Then
                            db.rollBackTransaction()
                            Exit Function
                        ElseIf result = DialogResult.No Then
                            db.rollBackTransaction()
                            Exit Function
                        ElseIf result = DialogResult.Yes Then
                            Dim folioAbono As String = co.obtenerFolio("Abono")
                            Dim IDClavePago As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE Clave = '{listaConceptos(0).claveConcepto}'")
                            db.execSQLQueryWithoutParams($"INSERT INTO ing_Abonos(Folio, Clave_Cliente, Cantidad, IDPago, ID_ClavePago, FechaAbono, Activo) VALUES ('{folioAbono}', '{MatriculaGeneral}', {montoDec}, {listaConceptos(0).IDConcepto}, {IDClavePago}, GETDATE(), 1)")
                            db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Usuario = 'Abonos'")
                            db.commitTransaction()
                            MessageBox.Show("Abono registrado correctamente")
                            Return 0
                        End If
                    End If
                End If
            End If

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
            Dim sello As String = st.Sellado("C:\Users\Luis\Desktop\pfx\uxa_pfx33.pfx", "12345678a", cadena)
            Dim xmlString As String = xml.xmlPrueba(Total, SubTotal, DescuentoS, totalIVA, Fecha, sello, Certificado, NoCertificado, formaPago, Folio, Serie, UsoCFDI, listaConceptos, RFCCLiente, NombreCLiente, Credito)
            xmlString = xmlString.Replace("utf-16", "UTF-8")
            Dim xmlTimbrado As String = st.Timbrado(xmlString, Folio)
            Dim folioFiscal As String = co.Extrae_Cadena(xmlTimbrado, "UUID=", " FechaTimbrado")
            folioFiscal = co.Extrae_Cadena(folioFiscal, "=", "")
            folioFiscal = folioFiscal.Substring(1, folioFiscal.Length() - 1)
            File.WriteAllText("C:\Users\Luis\Desktop\wea.xml", xmlTimbrado)
            ''File.WriteAllText("C:\Users\darkz\Desktop\wea.xml", xmlTimbrado)

            ''---------------------------------------------------------GENERACION DE FACTURA---------------------------------------------------------
            Dim IDXML As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_xmlTimbrados(Matricula_Clave, Folio, FolioFiscal, Certificado, XMLTimbrado, fac_Cadena, fac_Sello, Tipo_Pago, Forma_Pago, Fecha_Pago, Cajero, RegimenFiscal, Subtotal, Descuento, IVA, Total, usoCFDI) VALUES ('{MatriculaGeneral}', '{Serie}{Folio}', '{folioFiscal}', '{NoCertificado}', '{xmlTimbrado}', '{cadena}', '{sello}', '', '{formaPago}', '{Fecha}', '{User.getUsername}', 'GENERAL DE LEY(603)', {SubTotal}, {DescuentoS}, {totalIVA}, {Total}, '{UsoCFDI}')")
            For Each item As Concepto In listaConceptos
                db.execSQLQueryWithoutParams($"INSERT INTO ing_xmlTimbradosConceptos(Clave_Cliente, XMLID, Nombre_Concepto, Clave_Concepto, ClaveUnidad, PrecioUnitario, IVA, Descuento, Cantidad, Total) VALUES ('{item.Matricula}', {IDXML}, '{item.NombreConcepto}', {1}, '{item.cveUnidad}', {item.costoUnitario}, {item.costoIVAUnitario}, {item.descuento}, {item.Cantidad}, {item.costoTotal})")
            Next
            db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Usuario = '{User.getUsername()}'")


            MessageBox.Show("XML completado")
            Dim descripcionCFDI As String = db.exectSQLQueryScalar($"select UPPER('(' + clave_usoCFDI + ')' + ' ' + descripcion) As Clave from ing_cat_usoCFDI WHERE clave_usoCFDI = '{UsoCFDI}'")
            Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={RFCCLiente}id={folioFiscal}tt={Total}"
            co.gernerarQr(QR, $"{Serie}{Folio}")
            rep.AgregarFuente("FacturaEDC.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("CantidadLetra", TotalText)
            rep.AgregarParametros("ClaveCliente", MatriculaGeneral)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.MostrarReporte()
            db.commitTransaction()
            Return IDXML
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
            CobrosEDC.Reiniciar()
        End Try
    End Function
End Class
