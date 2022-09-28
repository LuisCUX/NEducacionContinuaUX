Imports System.Configuration
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Data.SqlClient
Public Class XmlService40
    Dim connectionstring As String = "Server=DESKTOP-RORPGCT\SQLEXPRESS;Database=EducacionContinuaTemp;User Id=chupon;Password=chupon"
    Dim con As New SqlConnection(connectionstring)
    Dim db As DataBaseService = New DataBaseService()
    ''------------------------------------------------------------------------------------------------------------------------------''
    ''------------------------------------------CADENA PAGO NORMAL------------------------------------------''
    ''------------------------------------------------------------------------------------------------------------------------------''
    Function cadenaPrueba(Serie As String, Folio As String, Fecha As String, FormaPago As String, NoCertificado As String, SubTotal As String, Descuento As String, Total As String, listaConceptos As List(Of Concepto), totalIVA As String, RFC As String, NombreCompleto As String, Credito As Boolean, CP As String, RegFiscal As String, CostoBaseTotal As String, usoCFDI As String) As String
        Dim metodoPago As String
        If (Credito = True) Then
            metodoPago = "PPD"
        Else
            metodoPago = "PUE"
        End If

        Dim Descuentotxt As String
        If (Descuento <> 0) Then
            Descuentotxt = $"|{Descuento.ToString()}|"
        Else
            Descuentotxt = "|"
        End If

        Dim cpemisor As String
        If (System.Diagnostics.Debugger.IsAttached) Then
            cpemisor = "72000"
        Else
            cpemisor = EnviromentService.CP
        End If

        Dim cpreceptor As String
        If (System.Diagnostics.Debugger.IsAttached) Then
            cpreceptor = "72000"
        Else
            cpreceptor = CP
        End If

        Dim nombreEmisor As String
        If (System.Diagnostics.Debugger.IsAttached) Then
            nombreEmisor = "Compuhipermegared"
        Else
            nombreEmisor = EnviromentService.NombreEmpresa
        End If

        Dim bandIVA As Boolean = False
        Dim cadena As String = "||4.0|" & Serie & "|" & Folio & "|" & Fecha & "|" & FormaPago & "|" & NoCertificado & "|" & SubTotal.ToString() & "" & Descuentotxt & "MXN|" & Total & "|I|01|" & metodoPago & "|" & cpemisor & "|" & EnviromentService.RFCEDC & "|" & nombreEmisor & "|" & EnviromentService.RegimenFiscal & "|" & RFC & "|" & NombreCompleto & "|" & cpreceptor & "|" & RegFiscal & "|" & usoCFDI & ""
        For Each concepto As Concepto In listaConceptos
            If (concepto.descuento <> 0) Then
                Descuentotxt = $"|{Descuento.ToString()}"
            Else
                Descuentotxt = ""
            End If

            Dim objetoimp As String
            If ((concepto.absorbeIVA = False And concepto.IVAExento = False And concepto.consideraIVA = False)) Then
                objetoimp = "01"
            ElseIf (concepto.absorbeIVA = True Or concepto.consideraIVA = True Or concepto.IVAExento = True) Then
                objetoimp = "02"
            End If

            cadena = "" & cadena & "|" & concepto.cveClase & "|" & concepto.Cantidad & "|" & concepto.cveUnidad & "|Pieza|" & concepto.NombreConcepto & "|" & concepto.costoUnitario & "|" & concepto.costoTotal & "" & Descuentotxt & "|" & objetoimp & ""
            If (concepto.absorbeIVA = True Or concepto.consideraIVA = True) Then
                bandIVA = True
                cadena = "" & cadena & "|" & CDec(concepto.costoBase) & "|002|Tasa|0.160000|" & concepto.costoIVATotal & ""
            ElseIf (concepto.IVAExento = True) Then
                cadena = "" & cadena & "|" & (CDec(concepto.costoTotal) + CDec(concepto.costoIVATotal)) & "|002|Exento"
            End If
        Next
        If (bandIVA = True) Then
            cadena = "" & cadena & "|" & CostoBaseTotal & "|002|Tasa|0.160000|" & totalIVA.ToString() & "|" & totalIVA.ToString() & "||"
        Else
            cadena = "" & cadena & "||"
        End If


        Return cadena
    End Function

    ''------------------------------------------------------------------------------------------------------------------------------''
    ''------------------------------------------CADENA PAGO DE CREDITO------------------------------------------''
    ''------------------------------------------------------------------------------------------------------------------------------''

    Function cadenaCredito(Serie As String, Folio As String, Fecha As String, NoCertificado As String, Certificado As String, RFC As String, NombreCompleto As String, UsoCFDI As String, FolioFiscal As String, SerieOriginal As String, FolioOriginal As String, NumParcialidad As Integer,
                        SaldoAnterior As Decimal, montoAbonado As Decimal, saldoRestante As Decimal, FechaAbono As String, FormaPago As String, CP As String, RegFiscal As String, ivaBool As Boolean, BaseIVA As String, IVACobrado As String) As String
        Dim cpemisor As String
        If (System.Diagnostics.Debugger.IsAttached) Then
            cpemisor = "72000"
        Else
            cpemisor = EnviromentService.CP
        End If

        Dim cpreceptor As String
        If (System.Diagnostics.Debugger.IsAttached) Then
            cpreceptor = "72000"
        Else
            cpreceptor = CP
        End If

        Dim nombreEmisor As String
        If (System.Diagnostics.Debugger.IsAttached) Then
            nombreEmisor = "Compuhipermegared"
        Else
            nombreEmisor = EnviromentService.NombreEmpresa
        End If

        Dim seccionDoctoRelacionado As String
        Dim seccionIVAFinal As String
        Dim objetoImpuesto As String
        If (ivaBool = True) Then
            seccionDoctoRelacionado = $"|{BaseIVA}|{IVACobrado}|"
            seccionIVAFinal = $"|{BaseIVA}|002|Tasa|0.160000|{IVACobrado}|{BaseIVA}|002|Tasa|0.160000|{IVACobrado}||"
            objetoImpuesto = "02"
        Else
            seccionDoctoRelacionado = "|"
            seccionIVAFinal = "||"
            objetoImpuesto = "01"
        End If

        Dim cadena As String = $"||4.0|{Serie}|{Folio}|{Fecha}|{NoCertificado}|0|XXX|0|P|01|{cpemisor}|{EnviromentService.RFCEDC}|{nombreEmisor}|{EnviromentService.RegimenFiscal}|{RFC}|{NombreCompleto}|{cpreceptor}|{RegFiscal}|CP01|84111506|1|ACT|Pago|0|0|01|2.0{seccionDoctoRelacionado}{Format(CDec(montoAbonado), "#####0.00")}|{FechaAbono}|{FormaPago}|MXN|1|{Format(CDec(montoAbonado), "#####0.00")}|{FolioFiscal}|{SerieOriginal}|{FolioOriginal}|MXN|1|{NumParcialidad}|{Format(CDec(SaldoAnterior), "#####0.00")}|{Format(CDec(montoAbonado), "#####0.00")}|{Format(CDec(saldoRestante), "#####0.00")}|{objetoImpuesto}{seccionIVAFinal}"

        Return cadena
    End Function

    ''------------------------------------------------------------------------------------------------------------------------------''
    ''------------------------------------------CADENA NOTA DE CREDITO------------------------------------------''
    ''------------------------------------------------------------------------------------------------------------------------------''

    Function cadenaNotaCredito(listaConceptos As List(Of Concepto), listaUUID As List(Of String), montoTotal As String, subtotal As String, descuento As String, fecha As String, folio As String, serie As String, noCertificado As String, RFC As String, NombreCompleto As String, usoCFDI As String, CP As String, RegFiscal As String, TotalIVA As String)
        Dim Descuentotxt As String
        Dim bandIVA = False
        If (descuento <> 0) Then
            Descuentotxt = $"|{descuento.ToString()}|"
        Else
            Descuentotxt = "|"
        End If

        Dim cpemisor As String
        If (System.Diagnostics.Debugger.IsAttached) Then
            cpemisor = "72000"
        Else
            cpemisor = EnviromentService.CP
        End If

        Dim cpreceptor As String
        If (System.Diagnostics.Debugger.IsAttached) Then
            cpreceptor = "72000"
        Else
            cpreceptor = CP
        End If

        Dim nombreEmisor As String
        If (System.Diagnostics.Debugger.IsAttached) Then
            nombreEmisor = "Compuhipermegared"
        Else
            nombreEmisor = EnviromentService.NombreEmpresa
        End If


        Dim cadena As String = $"||4.0|{serie}|{folio}|{fecha}|99|{noCertificado}|{Format(CDec(subtotal), "#####0.00")}|MXN|{Format(CDec(montoTotal), "#####0.00")}|E|01|PUE|{cpemisor}|01"
        For Each item As String In listaUUID
            cadena = $"{cadena}|{item}"
        Next
        cadena = $"{cadena}|{EnviromentService.RFCEDC}|{nombreEmisor}|{EnviromentService.RegimenFiscal}|{RFC}|{NombreCompleto}|{cpreceptor}|{RegFiscal}|{usoCFDI}"

        For Each concepto As Concepto In listaConceptos
            Dim objetoimp As String
            If ((concepto.absorbeIVA = False And concepto.IVAExento = False And concepto.consideraIVA = False)) Then
                objetoimp = "01"
            ElseIf (concepto.absorbeIVA = True Or concepto.consideraIVA = True Or concepto.IVAExento = True) Then
                objetoimp = "02"
            End If
            cadena = $"{cadena}|{concepto.cveClase}|{concepto.Cantidad}|ACT|actividad|{concepto.NombreConcepto}|{concepto.costoUnitario}|{concepto.costoTotal}|{objetoimp}"
            If (concepto.absorbeIVA = True Or concepto.consideraIVA = True) Then
                bandIVA = True
                cadena = "" & cadena & "|" & CDec(concepto.costoBase) & "|002|Tasa|0.160000|" & concepto.costoIVATotal & ""
            ElseIf (concepto.IVAExento = True) Then
                cadena = "" & cadena & "|" & (CDec(concepto.costoTotal) + CDec(concepto.costoIVATotal)) & "|002|Exento"
            End If
        Next
        If (bandIVA = True) Then
            cadena = "" & cadena & "|" & subtotal & "|002|Tasa|0.160000|" & TotalIVA.ToString() & "|" & TotalIVA.ToString() & "||"
        Else
            cadena = "" & cadena & "||"
        End If
        Return cadena
    End Function

    ''------------------------------------------------------------------------------------------------------------------------------''
    ''------------------------------------------XML PAGO NORMAL------------------------------------------''
    ''------------------------------------------------------------------------------------------------------------------------------''
    Function xmlPrueba(Total As String, SubTotal As String, Descuento As String, TotalIVA As String, Fecha As String, Sello As String, Certificado As String, NoCertificado As String, FormaPago As String, Folio As String, Serie As String, UsoCFDI As String, listaConceptos As List(Of Concepto), RFC As String, NombreCompleto As String, Credito As Boolean, Cp As String, RegFiscal As String, CostoIVABaseTotal As String) As String
        Dim IVABand As Boolean = False
        Dim config As New XmlWriterSettings
        config.Indent = True
        config.Encoding = Encoding.UTF8
        config.Async = True
        Dim xml As String
        Dim archivo_xml As String = "C:\Users\Luis\Desktop\wea.xml"

        Using sw As New StringWriter()
            Using wr As XmlWriter = XmlWriter.Create(sw, config)
                wr.WriteStartDocument()
                wr.WriteStartElement("cfdi", "Comprobante", "http://www.sat.gob.mx/cfd/4") ''NODO COMPROBANTE START
                wr.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                wr.WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd")
                wr.WriteAttributeString("Version", Nothing, ConfigurationSettings.AppSettings.Get("VersionSAT").ToString())
                wr.WriteAttributeString("Serie", Nothing, Serie)
                wr.WriteAttributeString("Folio", Nothing, Folio)
                wr.WriteAttributeString("Fecha", Nothing, Fecha)
                wr.WriteAttributeString("FormaPago", Nothing, FormaPago)
                wr.WriteAttributeString("NoCertificado", Nothing, NoCertificado)
                wr.WriteAttributeString("SubTotal", Nothing, SubTotal)

                If (Descuento <> 0) Then
                    wr.WriteAttributeString("Descuento", Nothing, Descuento)
                End If
                wr.WriteAttributeString("Moneda", Nothing, "MXN")
                wr.WriteAttributeString("Total", Nothing, Total)
                wr.WriteAttributeString("TipoDeComprobante", Nothing, "I")
                wr.WriteAttributeString("Exportacion", Nothing, "01")
                If (Credito = True) Then
                    wr.WriteAttributeString("MetodoPago", Nothing, "PPD")
                Else
                    wr.WriteAttributeString("MetodoPago", Nothing, "PUE")
                End If

                If (System.Diagnostics.Debugger.IsAttached) Then
                    wr.WriteAttributeString("LugarExpedicion", Nothing, "72000")
                Else
                    wr.WriteAttributeString("LugarExpedicion", Nothing, EnviromentService.CP)
                End If

                wr.WriteAttributeString("Sello", Nothing, Sello)
                wr.WriteAttributeString("Certificado", Nothing, Certificado)

                wr.WriteStartElement("cfdi", "Emisor", Nothing) ''NODO EMISOR START
                wr.WriteAttributeString("Rfc", Nothing, EnviromentService.RFCEDC)
                If (System.Diagnostics.Debugger.IsAttached) Then
                    wr.WriteAttributeString("Nombre", Nothing, "Compuhipermegared")
                Else
                    wr.WriteAttributeString("Nombre", Nothing, EnviromentService.NombreEmpresa)
                End If

                wr.WriteAttributeString("RegimenFiscal", Nothing, EnviromentService.RegimenFiscal)
                wr.WriteEndElement() ''NODO EMISOR END

                wr.WriteStartElement("cfdi", "Receptor", Nothing) ''NODO RECEPTOR START

                If (System.Diagnostics.Debugger.IsAttached) Then
                    wr.WriteAttributeString("DomicilioFiscalReceptor", Nothing, "72000")
                Else
                    wr.WriteAttributeString("DomicilioFiscalReceptor", Nothing, Cp)
                End If

                wr.WriteAttributeString("Rfc", Nothing, RFC)
                wr.WriteAttributeString("Nombre", Nothing, NombreCompleto)
                wr.WriteAttributeString("UsoCFDI", Nothing, UsoCFDI)
                wr.WriteAttributeString("RegimenFiscalReceptor", Nothing, RegFiscal)
                wr.WriteEndElement() ''NODO RECEPTOR END

                wr.WriteStartElement("cfdi", "Conceptos", Nothing) ''NODO CONCEPTOS START

                For Each concepto As Concepto In listaConceptos
                    wr.WriteStartElement("cfdi", "Concepto", Nothing) ''NODO CONCEPTO START
                    wr.WriteAttributeString("ClaveProdServ", Nothing, concepto.cveClase)
                    wr.WriteAttributeString("Cantidad", Nothing, concepto.Cantidad)
                    wr.WriteAttributeString("ClaveUnidad", Nothing, concepto.cveUnidad)
                    ''Dim unidad As String = db.exectSQLQueryScalar($"SELECT nombre FROM ing_cat_unidad WHERE id_claveProd = '{concepto.cveUnidad}'")
                    wr.WriteAttributeString("Unidad", Nothing, "Pieza")
                    wr.WriteAttributeString("Descripcion", Nothing, concepto.NombreConcepto)
                    wr.WriteAttributeString("ValorUnitario", Nothing, concepto.costoUnitario)
                    wr.WriteAttributeString("Importe", Nothing, concepto.costoTotal)

                    If (concepto.descuento <> 0) Then
                        wr.WriteAttributeString("Descuento", Nothing, concepto.descuento)
                    End If

                    If ((concepto.absorbeIVA = False And concepto.IVAExento = False And concepto.consideraIVA = False)) Then
                        wr.WriteAttributeString("ObjetoImp", Nothing, "01")
                    ElseIf (concepto.absorbeIVA = True Or concepto.consideraIVA = True Or concepto.IVAExento = True) Then
                        wr.WriteAttributeString("ObjetoImp", Nothing, "02")
                    End If

                    If (concepto.absorbeIVA = True Or concepto.IVAExento = True Or concepto.consideraIVA = True) Then
                        wr.WriteStartElement("cfdi", "Impuestos", Nothing) ''NODO IMPUESTOS START
                        wr.WriteStartElement("cfdi", "Traslados", Nothing) ''NODO TRASLADOS START
                        wr.WriteStartElement("cfdi", "Traslado", Nothing) ''NODO TRASLADO START
                        wr.WriteAttributeString("Base", Nothing, (CDec(concepto.costoBase)).ToString())
                        wr.WriteAttributeString("Impuesto", Nothing, "002")
                        If (concepto.IVAExento = True And concepto.absorbeIVA = False And concepto.consideraIVA = False) Then
                            wr.WriteAttributeString("TipoFactor", Nothing, "Exento")
                        ElseIf (concepto.IVAExento = False And (concepto.absorbeIVA = True Or concepto.consideraIVA = True)) Then
                            IVABand = True
                            wr.WriteAttributeString("TipoFactor", Nothing, "Tasa")
                            wr.WriteAttributeString("TasaOCuota", Nothing, "0.160000")
                            wr.WriteAttributeString("Importe", Nothing, concepto.costoIVATotal)
                        End If

                        wr.WriteEndElement() ''NODO TRASLADO END
                        wr.WriteEndElement() ''NODO TRASLADOS END
                        wr.WriteEndElement() ''NODO IMPUESTOS END
                    End If
                    wr.WriteEndElement() ''NODO CONCEPTO END

                Next

                wr.WriteEndElement() ''NODO CONCEPTOS END

                If (IVABand = True) Then
                    wr.WriteStartElement("cfdi", "Impuestos", Nothing) ''NODO IMPUESTOS START
                    wr.WriteAttributeString("TotalImpuestosTrasladados", Nothing, TotalIVA)
                    wr.WriteStartElement("cfdi", "Traslados", Nothing) ''NODO TRASLADOS START
                    wr.WriteStartElement("cfdi", "Traslado", Nothing) ''NODO TRASLADO START
                    wr.WriteAttributeString("Impuesto", Nothing, "002")
                    wr.WriteAttributeString("TipoFactor", Nothing, "Tasa")
                    wr.WriteAttributeString("TasaOCuota", Nothing, "0.160000")
                    wr.WriteAttributeString("Base", Nothing, CostoIVABaseTotal)
                    wr.WriteAttributeString("Importe", Nothing, TotalIVA)
                    wr.WriteEndElement() ''NODO TRASLADO END
                    wr.WriteEndElement() ''NODO TRASLADOS END
                    wr.WriteEndElement() ''NODO IMPUESTOS END
                End If
                wr.WriteEndElement() ''NODO COMPROBANTE END
                wr.WriteEndDocument()

                wr.Close()
            End Using
            xml = sw.ToString()
        End Using
        Return xml
    End Function


    ''------------------------------------------------------------------------------------------------------------------------------''
    ''------------------------------------------XML PAGO A CREDITO------------------------------------------''
    ''------------------------------------------------------------------------------------------------------------------------------''

    Function xmlCredito(Serie As String, Folio As String, Fecha As String, NoCertificado As String, Sello As String, Certificado As String, RFC As String, NombreCompleto As String, UsoCFDI As String, FolioFiscal As String, SerieOriginal As String, FolioOriginal As String, NumParcialidad As Integer,
                        SaldoAnterior As Decimal, montoAbonado As Decimal, saldoRestante As Decimal, FechaAbono As String, FormaPago As String, RegFiscal As String, Cp As String, ivaBool As Boolean, BaseIVA As String, IVACobrado As String) As String
        Dim xml As String
        Dim config As New XmlWriterSettings
        config.Indent = True
        config.Encoding = Encoding.UTF8
        config.Async = True
        Dim archivo_xml As String = "C:\Users\Luis\Desktop\wea.xml"
        Using sw As New StringWriter()
            Using wr As XmlWriter = XmlWriter.Create(sw, config)
                wr.WriteStartDocument()
                wr.WriteStartElement("cfdi", "Comprobante", "http://www.sat.gob.mx/cfd/4") ''NODO COMPROBANTE START
                wr.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                wr.WriteAttributeString("xmlns", "pago20", Nothing, "http://www.sat.gob.mx/Pagos20")
                wr.WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/Pagos20 http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos20.xsd")

                wr.WriteAttributeString("Moneda", Nothing, "XXX")
                wr.WriteAttributeString("Version", Nothing, ConfigurationSettings.AppSettings.Get("VersionSAT").ToString())
                wr.WriteAttributeString("TipoDeComprobante", Nothing, "P")
                wr.WriteAttributeString("Exportacion", Nothing, "01")
                wr.WriteAttributeString("Total", Nothing, "0")
                wr.WriteAttributeString("SubTotal", Nothing, "0")
                wr.WriteAttributeString("Fecha", Nothing, Fecha)
                wr.WriteAttributeString("Sello", Nothing, Sello)
                wr.WriteAttributeString("Certificado", Nothing, Certificado)
                If (System.Diagnostics.Debugger.IsAttached) Then
                    wr.WriteAttributeString("LugarExpedicion", Nothing, "72000")
                Else
                    wr.WriteAttributeString("LugarExpedicion", Nothing, EnviromentService.CP)
                End If
                wr.WriteAttributeString("Folio", Nothing, Folio)
                wr.WriteAttributeString("Serie", Nothing, Serie)
                wr.WriteAttributeString("NoCertificado", Nothing, NoCertificado)

                wr.WriteStartElement("cfdi", "Emisor", Nothing) ''NODO EMISOR START
                wr.WriteAttributeString("RegimenFiscal", Nothing, EnviromentService.RegimenFiscal)
                wr.WriteAttributeString("Rfc", Nothing, EnviromentService.RFCEDC)
                If (System.Diagnostics.Debugger.IsAttached) Then
                    wr.WriteAttributeString("Nombre", Nothing, "Compuhipermegared")
                Else
                    wr.WriteAttributeString("Nombre", Nothing, EnviromentService.NombreEmpresa)
                End If

                wr.WriteEndElement() ''NODO EMISOR END

                wr.WriteStartElement("cfdi", "Receptor", Nothing) ''NODO RECEPTOR START
                If (System.Diagnostics.Debugger.IsAttached) Then
                    wr.WriteAttributeString("DomicilioFiscalReceptor", Nothing, "72000")
                Else
                    wr.WriteAttributeString("DomicilioFiscalReceptor", Nothing, Cp)
                End If
                wr.WriteAttributeString("Rfc", Nothing, RFC)
                wr.WriteAttributeString("Nombre", Nothing, NombreCompleto)
                wr.WriteAttributeString("UsoCFDI", Nothing, "CP01")
                wr.WriteAttributeString("RegimenFiscalReceptor", Nothing, RegFiscal)
                wr.WriteEndElement() ''NODO RECEPTOR END

                wr.WriteStartElement("cfdi", "Conceptos", Nothing) ''NODO CONCEPTOS START
                wr.WriteStartElement("cfdi", "Concepto", Nothing) ''NODO CONCEPTO START
                wr.WriteAttributeString("ClaveProdServ", Nothing, "84111506")
                wr.WriteAttributeString("Cantidad", Nothing, 1)
                wr.WriteAttributeString("ClaveUnidad", Nothing, "ACT")
                wr.WriteAttributeString("Descripcion", Nothing, "Pago")
                wr.WriteAttributeString("ValorUnitario", Nothing, "0")
                wr.WriteAttributeString("Importe", Nothing, "0")
                wr.WriteAttributeString("ObjetoImp", Nothing, "01")

                wr.WriteEndElement() ''NODO CONCEPTO END
                wr.WriteEndElement() ''NODO CONCEPTOS END

                wr.WriteStartElement("cfdi", "Complemento", Nothing) ''NODO COMPLEMENTO START
                wr.WriteStartElement("pago20", "Pagos", Nothing) ''NODO PAGO20 START
                wr.WriteAttributeString("Version", Nothing, "2.0")
                wr.WriteStartElement("pago20", "Totales", Nothing) ''NODO PAGOSTOTALES START
                If (ivaBool = True) Then
                    wr.WriteAttributeString("TotalTrasladosBaseIVA16", Nothing, Format(CDec(BaseIVA), "#####0.00"))
                    wr.WriteAttributeString("TotalTrasladosImpuestoIVA16", Nothing, Format(CDec(IVACobrado), "#####0.00"))
                End If
                wr.WriteAttributeString("MontoTotalPagos", Nothing, Format(CDec(montoAbonado), "#####0.00"))
                wr.WriteEndElement() ''NODO PAGOSTOTALES END
                wr.WriteStartElement("pago20", "Pago", Nothing) ''NODO PAGO10 START
                wr.WriteAttributeString("FechaPago", Nothing, FechaAbono)
                wr.WriteAttributeString("FormaDePagoP", Nothing, FormaPago)
                wr.WriteAttributeString("MonedaP", Nothing, "MXN")
                wr.WriteAttributeString("Monto", Nothing, Format(CDec(montoAbonado), "#####0.00"))
                wr.WriteAttributeString("TipoCambioP", Nothing, "1")
                wr.WriteStartElement("pago20", "DoctoRelacionado", Nothing) ''NODO DOCTORELACIONADO START
                wr.WriteAttributeString("IdDocumento", Nothing, FolioFiscal)
                wr.WriteAttributeString("Serie", Nothing, SerieOriginal)
                wr.WriteAttributeString("Folio", Nothing, FolioOriginal)
                wr.WriteAttributeString("MonedaDR", Nothing, "MXN")
                wr.WriteAttributeString("NumParcialidad", Nothing, NumParcialidad)
                wr.WriteAttributeString("ImpSaldoAnt", Nothing, Format(CDec(SaldoAnterior), "#####0.00"))
                wr.WriteAttributeString("ImpPagado", Nothing, Format(CDec(montoAbonado), "#####0.00"))
                wr.WriteAttributeString("ImpSaldoInsoluto", Nothing, Format(CDec(saldoRestante), "#####0.00"))
                wr.WriteAttributeString("EquivalenciaDR", Nothing, "1")
                If (ivaBool = True) Then
                    wr.WriteAttributeString("ObjetoImpDR", Nothing, "02")
                Else
                    wr.WriteAttributeString("ObjetoImpDR", Nothing, "01")
                End If

                If (ivaBool = True) Then
                    wr.WriteStartElement("pago20", "ImpuestosDR", Nothing) ''NODO ImpuestosDR START
                    wr.WriteStartElement("pago20", "TrasladosDR", Nothing) ''NODO TrasladosDR START
                    wr.WriteStartElement("pago20", "TrasladoDR", Nothing) ''NODO TrasladoDR START
                    wr.WriteAttributeString("BaseDR", Nothing, Format(CDec(BaseIVA), "#####0.00"))
                    wr.WriteAttributeString("ImpuestoDR", Nothing, "002")
                    wr.WriteAttributeString("TipoFactorDR", Nothing, "Tasa")
                    wr.WriteAttributeString("TasaOCuotaDR", Nothing, "0.160000")
                    wr.WriteAttributeString("ImporteDR", Nothing, Format(CDec(IVACobrado), "#####0.00"))
                    wr.WriteEndElement() ''NODO TrasladoDR END
                    wr.WriteEndElement() ''NODO TrasladosDR END
                    wr.WriteEndElement() ''NODO ImpuestosDR END
                End If
                wr.WriteEndElement() ''NODO COMPLEMENTO END
                If (ivaBool = True) Then
                    wr.WriteStartElement("pago20", "ImpuestosP", Nothing) ''NODO ImpuestosP START
                    wr.WriteStartElement("pago20", "TrasladosP", Nothing) ''NODO TrasladosP START
                    wr.WriteStartElement("pago20", "TrasladoP", Nothing) ''NODO TrasladoP START
                    wr.WriteAttributeString("BaseP", Nothing, Format(CDec(BaseIVA), "#####0.00"))
                    wr.WriteAttributeString("ImpuestoP", Nothing, "002")
                    wr.WriteAttributeString("TipoFactorP", Nothing, "Tasa")
                    wr.WriteAttributeString("TasaOCuotaP", Nothing, "0.160000")
                    wr.WriteAttributeString("ImporteP", Nothing, Format(CDec(IVACobrado), "#####0.00"))
                    wr.WriteEndElement() ''NODO TrasladoP END
                    wr.WriteEndElement() ''NODO TrasladosP END
                    wr.WriteEndElement() ''NODO ImpuestosP END
                End If
                wr.WriteEndElement() ''NODO PAGO20 END
                wr.WriteEndElement() ''NODO DOCTORELACIONADO END

            End Using
            xml = sw.ToString()
        End Using
        Return xml
    End Function


    ''------------------------------------------------------------------------------------------------------------------------------''
    ''------------------------------------------XML NOTA DE CREDITO------------------------------------------''
    ''------------------------------------------------------------------------------------------------------------------------------''

    Function xmlNotaCredito(Total As String, SubTotal As String, Descuento As String, Fecha As String, Sello As String, Certificado As String, Folio As String, Serie As String, NoCertificado As String,
                            RFC As String, NombreCompleto As String, UsoCFDI As String, listaConceptos As List(Of Concepto), listaUUID As List(Of String), RegFiscal As String, Cp As String, TotalIVA As String) As String
        Dim xml As String
        Dim config As New XmlWriterSettings
        config.Indent = True
        config.Encoding = Encoding.UTF8
        config.Async = True
        Dim IVABand As Boolean = False
        Dim archivo_xml As String = "C:\Users\Luis\Desktop\wea.xml"
        Using sw As New StringWriter()
            Using wr As XmlWriter = XmlWriter.Create(sw, config)
                wr.WriteStartDocument()
                wr.WriteStartElement("cfdi", "Comprobante", "http://www.sat.gob.mx/cfd/4") ''NODO COMPROBANTE START
                wr.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                wr.WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd")
                wr.WriteAttributeString("Moneda", Nothing, "MXN")
                wr.WriteAttributeString("Version", Nothing, ConfigurationSettings.AppSettings.Get("VersionSAT").ToString())
                wr.WriteAttributeString("TipoDeComprobante", Nothing, "E")
                wr.WriteAttributeString("Exportacion", Nothing, "01")
                wr.WriteAttributeString("Total", Nothing, Format(CDec(Total), "#####0.00"))
                wr.WriteAttributeString("SubTotal", Nothing, Format(CDec(SubTotal), "#####0.00"))
                wr.WriteAttributeString("Fecha", Nothing, Fecha)
                wr.WriteAttributeString("Sello", Nothing, Sello)
                wr.WriteAttributeString("Certificado", Nothing, Certificado)
                If (System.Diagnostics.Debugger.IsAttached) Then
                    wr.WriteAttributeString("LugarExpedicion", Nothing, "72000")
                Else
                    wr.WriteAttributeString("LugarExpedicion", Nothing, EnviromentService.CP)
                End If
                wr.WriteAttributeString("MetodoPago", Nothing, "PUE")
                wr.WriteAttributeString("FormaPago", Nothing, "99")
                wr.WriteAttributeString("Folio", Nothing, Folio)
                wr.WriteAttributeString("Serie", Nothing, Serie)
                wr.WriteAttributeString("NoCertificado", Nothing, NoCertificado)

                wr.WriteStartElement("cfdi", "CfdiRelacionados", Nothing) ''NODO CFDI RELACIONADOS
                wr.WriteAttributeString("TipoRelacion", Nothing, "01")

                For Each item As String In listaUUID
                    wr.WriteStartElement("cfdi", "CfdiRelacionado", Nothing) ''NODO CFDI RELACIONADO
                    wr.WriteAttributeString("UUID", Nothing, item)
                    wr.WriteEndElement() ''END CFDI RELACIONADO
                Next

                wr.WriteEndElement() ''END CFDI RELACIONADOS

                wr.WriteStartElement("cfdi", "Emisor", Nothing) ''NODO EMISOR START
                wr.WriteAttributeString("RegimenFiscal", Nothing, EnviromentService.RegimenFiscal)
                wr.WriteAttributeString("Rfc", Nothing, EnviromentService.RFCEDC)
                If (System.Diagnostics.Debugger.IsAttached) Then
                    wr.WriteAttributeString("Nombre", Nothing, "Compuhipermegared")
                Else
                    wr.WriteAttributeString("Nombre", Nothing, EnviromentService.NombreEmpresa)
                End If

                wr.WriteEndElement() ''NODO EMISOR END

                wr.WriteStartElement("cfdi", "Receptor", Nothing) ''NODO RECEPTOR START
                If (System.Diagnostics.Debugger.IsAttached) Then
                    wr.WriteAttributeString("DomicilioFiscalReceptor", Nothing, "72000")
                Else
                    wr.WriteAttributeString("DomicilioFiscalReceptor", Nothing, Cp)
                End If
                wr.WriteAttributeString("Rfc", Nothing, RFC)
                wr.WriteAttributeString("Nombre", Nothing, NombreCompleto)
                wr.WriteAttributeString("UsoCFDI", Nothing, UsoCFDI)
                wr.WriteAttributeString("RegimenFiscalReceptor", Nothing, RegFiscal)
                wr.WriteEndElement() ''NODO RECEPTOR END

                wr.WriteStartElement("cfdi", "Conceptos", Nothing) ''NODO CONCEPTOS START
                For Each concepto As Concepto In listaConceptos
                    wr.WriteStartElement("cfdi", "Concepto", Nothing) ''NODO CONCEPTO START
                    wr.WriteAttributeString("ClaveProdServ", Nothing, concepto.cveClase)
                    wr.WriteAttributeString("Cantidad", Nothing, concepto.Cantidad)
                    wr.WriteAttributeString("ClaveUnidad", Nothing, "ACT")
                    wr.WriteAttributeString("Unidad", Nothing, "actividad")
                    wr.WriteAttributeString("Descripcion", Nothing, concepto.NombreConcepto)
                    wr.WriteAttributeString("ValorUnitario", Nothing, concepto.costoUnitario)
                    wr.WriteAttributeString("Importe", Nothing, concepto.costoTotal)
                    'wr.WriteAttributeString("Descuento", Nothing, concepto.descuento)
                    If ((concepto.absorbeIVA = False And concepto.IVAExento = False And concepto.consideraIVA = False)) Then
                        wr.WriteAttributeString("ObjetoImp", Nothing, "01")
                    Else
                        wr.WriteAttributeString("ObjetoImp", Nothing, "02")
                    End If
                    If (concepto.absorbeIVA = True Or concepto.IVAExento = True Or concepto.consideraIVA = True) Then
                        wr.WriteStartElement("cfdi", "Impuestos", Nothing) ''NODO IMPUESTOS START
                        wr.WriteStartElement("cfdi", "Traslados", Nothing) ''NODO TRASLADOS START
                        wr.WriteStartElement("cfdi", "Traslado", Nothing) ''NODO TRASLADO START
                        wr.WriteAttributeString("Base", Nothing, (CDec(concepto.costoBase)).ToString())
                        wr.WriteAttributeString("Impuesto", Nothing, "002")
                        If (concepto.IVAExento = True And concepto.absorbeIVA = False And concepto.consideraIVA = False) Then
                            wr.WriteAttributeString("TipoFactor", Nothing, "Exento")
                        ElseIf (concepto.IVAExento = False And (concepto.absorbeIVA = True Or concepto.consideraIVA = True)) Then
                            IVABand = True
                            wr.WriteAttributeString("TipoFactor", Nothing, "Tasa")
                            wr.WriteAttributeString("TasaOCuota", Nothing, "0.160000")
                            wr.WriteAttributeString("Importe", Nothing, concepto.costoIVATotal)
                        End If

                        wr.WriteEndElement() ''NODO TRASLADO END
                        wr.WriteEndElement() ''NODO TRASLADOS END
                        wr.WriteEndElement() ''NODO IMPUESTOS END
                    End If
                    wr.WriteEndElement()
                Next
                wr.WriteEndElement()
                If (IVABand = True) Then
                    wr.WriteStartElement("cfdi", "Impuestos", Nothing) ''NODO IMPUESTOS START
                    wr.WriteAttributeString("TotalImpuestosTrasladados", Nothing, TotalIVA)
                    wr.WriteStartElement("cfdi", "Traslados", Nothing) ''NODO TRASLADOS START
                    wr.WriteStartElement("cfdi", "Traslado", Nothing) ''NODO TRASLADO START
                    wr.WriteAttributeString("Impuesto", Nothing, "002")
                    wr.WriteAttributeString("TipoFactor", Nothing, "Tasa")
                    wr.WriteAttributeString("TasaOCuota", Nothing, "0.160000")
                    wr.WriteAttributeString("Base", Nothing, SubTotal)
                    wr.WriteAttributeString("Importe", Nothing, TotalIVA)
                    wr.WriteEndElement() ''NODO TRASLADO END
                    wr.WriteEndElement() ''NODO TRASLADOS END
                    wr.WriteEndElement() ''NODO IMPUESTOS END
                End If
            End Using
            xml = sw.ToString()
        End Using
        Return xml
    End Function
End Class