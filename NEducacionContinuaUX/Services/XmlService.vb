Imports System.Configuration
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Data.SqlClient
Public Class XmlService
    Dim connectionstring As String = "Server=DESKTOP-RORPGCT\SQLEXPRESS;Database=EducacionContinuaTemp;User Id=chupon;Password=chupon"
    Dim con As New SqlConnection(connectionstring)
    Dim db As DataBaseService = New DataBaseService()


    Function cadenaPrueba(Serie As String, Folio As String, Fecha As String, FormaPago As String, NoCertificado As String, SubTotal As String, Descuento As String, Total As String, listaConceptos As List(Of Concepto), totalIVA As String, RFC As String, NombreCompleto As String, Credito As Boolean) As String
        Dim metodoPago As String
        If (Credito = True) Then
            metodoPago = "PPD"
        Else
            metodoPago = "PUE"
        End If
        Dim bandIVA As Boolean = False
        Dim cadena As String = "||3.3|" & Serie & "|" & Folio & "|" & Fecha & "|" & FormaPago & "|" & NoCertificado & "|" & SubTotal.ToString() & "|" & Descuento.ToString() & "|MXN|" & Total & "|I|" & metodoPago & "|91190|TES030201001|EDUCACION CONTINUA|601|" & RFC & "|" & NombreCompleto & "|P01"
        For Each concepto As Concepto In listaConceptos
            cadena = "" & cadena & "|" & concepto.cveClase & "|" & concepto.Cantidad & "|" & concepto.cveUnidad & "|Pieza|" & concepto.NombreConcepto & "|" & concepto.costoUnitario & "|" & concepto.costoTotal & "|" & concepto.descuento & ""
            If (concepto.absorbeIVA = True Or concepto.consideraIVA = True) Then
                bandIVA = True
                cadena = "" & cadena & "|" & CDec(concepto.costoBase) & "|002|Tasa|0.160000|" & concepto.costoIVATotal & ""
            ElseIf (concepto.IVAExento = True) Then
                cadena = "" & cadena & "|" & (CDec(concepto.costoTotal) + CDec(concepto.costoIVATotal)) & "|002|Exento"
            End If
        Next
        If (bandIVA = True) Then
            cadena = "" & cadena & "|002|Tasa|0.160000|" & totalIVA.ToString() & "|" & totalIVA.ToString() & "||"
        Else
            cadena = "" & cadena & "||"
        End If


        Return cadena
    End Function

    Function cadenaCredito(Serie As String, Folio As String, Fecha As String, NoCertificado As String, Certificado As String, RFC As String, NombreCompleto As String, UsoCFDI As String, FolioFiscal As String, SerieOriginal As String, FolioOriginal As String, NumParcialidad As Integer,
                        SaldoAnterior As Decimal, montoAbonado As Decimal, saldoRestante As Decimal, FechaAbono As String, FormaPago As String) As String
        Dim cadena As String = $"||3.3|{Serie}|{Folio}|{Fecha}|{NoCertificado}|0|XXX|0|P|{ConfigurationSettings.AppSettings.Get("CP").ToString()}|{ConfigurationSettings.AppSettings.Get("RFC").ToString()}|{ConfigurationSettings.AppSettings.Get("NombreEmpresa").ToString()}|{ConfigurationSettings.AppSettings.Get("RegimenFiscal").ToString()}|{RFC}|{NombreCompleto}|{UsoCFDI}|84111506|1|ACT|Pago|0|0|1.0|{FechaAbono}|{FormaPago}|MXN|{montoAbonado}|{FolioFiscal}|{SerieOriginal}|{FolioOriginal}|MXN|PPD|{NumParcialidad}|{Format(CDec(SaldoAnterior), "#####0.00")}|{Format(CDec(montoAbonado), "#####0.00")}|{Format(CDec(saldoRestante), "#####0.00")}||"


        Return cadena
    End Function

    Function cadenaNotaCredito(listaConceptos As List(Of Concepto), listaUUID As List(Of String), montoTotal As String, subtotal As String, descuento As String, fecha As String, folio As String, serie As String, noCertificado As String, RFC As String, NombreCompleto As String, usoCFDI As String)
        Dim cadena As String = $"||3.3|{serie}|{folio}|{fecha}|99|{noCertificado}|{CDec(montoTotal)}|{CDec(descuento)}|MXN|{CDec(subtotal)}|E|PUE|91190|01"
        For Each item As String In listaUUID
            cadena = $"{cadena}|{item}"
        Next
        cadena = $"{cadena}|{ConfigurationSettings.AppSettings.Get("RFC").ToString()}|{ConfigurationSettings.AppSettings.Get("NombreEmpresa").ToString()}|{ConfigurationSettings.AppSettings.Get("RegimenFiscal").ToString()}|{RFC}|{NombreCompleto}|{usoCFDI}"

        For Each concepto As Concepto In listaConceptos
            cadena = $"{cadena}|{concepto.cveClase}|{concepto.Cantidad}|ACT|actividad|{concepto.NombreConcepto}|{concepto.costoUnitario}|{concepto.costoTotal}|{concepto.descuento}"
        Next

        cadena = $"{cadena}||"
        Return cadena
    End Function


    Function xmlPrueba(Total As String, SubTotal As String, Descuento As String, TotalIVA As String, Fecha As String, Sello As String, Certificado As String, NoCertificado As String, FormaPago As String, Folio As String, Serie As String, UsoCFDI As String, listaConceptos As List(Of Concepto), RFC As String, NombreCompleto As String, Credito As Boolean) As String
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
                wr.WriteStartElement("cfdi", "Comprobante", "http://www.sat.gob.mx/cfd/3") ''NODO COMPROBANTE START
                wr.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                wr.WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd")
                wr.WriteAttributeString("Version", Nothing, ConfigurationSettings.AppSettings.Get("VersionSAT").ToString())
                wr.WriteAttributeString("Serie", Nothing, Serie)
                wr.WriteAttributeString("Folio", Nothing, Folio)
                wr.WriteAttributeString("Fecha", Nothing, Fecha)
                wr.WriteAttributeString("FormaPago", Nothing, FormaPago)
                wr.WriteAttributeString("NoCertificado", Nothing, NoCertificado)
                wr.WriteAttributeString("SubTotal", Nothing, SubTotal)
                wr.WriteAttributeString("Descuento", Nothing, Descuento)
                wr.WriteAttributeString("Moneda", Nothing, "MXN")
                wr.WriteAttributeString("Total", Nothing, Total)
                wr.WriteAttributeString("TipoDeComprobante", Nothing, "I")
                If (Credito = True) Then
                    wr.WriteAttributeString("MetodoPago", Nothing, "PPD")
                Else
                    wr.WriteAttributeString("MetodoPago", Nothing, "PUE")
                End If
                wr.WriteAttributeString("LugarExpedicion", Nothing, ConfigurationSettings.AppSettings.Get("CP").ToString())
                wr.WriteAttributeString("Sello", Nothing, Sello)
                wr.WriteAttributeString("Certificado", Nothing, Certificado)

                wr.WriteStartElement("cfdi", "Emisor", Nothing) ''NODO EMISOR START
                wr.WriteAttributeString("Rfc", Nothing, ConfigurationSettings.AppSettings.Get("RFC").ToString())
                wr.WriteAttributeString("Nombre", Nothing, ConfigurationSettings.AppSettings.Get("NombreEmpresa").ToString())
                wr.WriteAttributeString("RegimenFiscal", Nothing, ConfigurationSettings.AppSettings.Get("RegimenFiscal").ToString())
                wr.WriteEndElement() ''NODO EMISOR END

                wr.WriteStartElement("cfdi", "Receptor", Nothing) ''NODO RECEPTOR START
                wr.WriteAttributeString("Rfc", Nothing, RFC)
                wr.WriteAttributeString("Nombre", Nothing, NombreCompleto)
                wr.WriteAttributeString("UsoCFDI", Nothing, UsoCFDI)
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
                    wr.WriteAttributeString("Descuento", Nothing, concepto.descuento)

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


    Function xmlCredito(Serie As String, Folio As String, Fecha As String, NoCertificado As String, Sello As String, Certificado As String, RFC As String, NombreCompleto As String, UsoCFDI As String, FolioFiscal As String, SerieOriginal As String, FolioOriginal As String, NumParcialidad As Integer,
                        SaldoAnterior As Decimal, montoAbonado As Decimal, saldoRestante As Decimal, FechaAbono As String, FormaPago As String) As String
        Dim xml As String
        Dim config As New XmlWriterSettings
        config.Indent = True
        config.Encoding = Encoding.UTF8
        config.Async = True
        Dim archivo_xml As String = "C:\Users\Luis\Desktop\wea.xml"
        Using sw As New StringWriter()
            Using wr As XmlWriter = XmlWriter.Create(sw, config)
                wr.WriteStartDocument()
                wr.WriteStartElement("cfdi", "Comprobante", "http://www.sat.gob.mx/cfd/3") ''NODO COMPROBANTE START
                wr.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                wr.WriteAttributeString("xmlns", "pago10", Nothing, "http://www.sat.gob.mx/Pagos")
                wr.WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/Pagos http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos10.xsd")
                wr.WriteAttributeString("Moneda", Nothing, "MXN")
                wr.WriteAttributeString("Version", Nothing, ConfigurationSettings.AppSettings.Get("VersionSAT").ToString())
                wr.WriteAttributeString("TipoDeComprobante", Nothing, "P")
                wr.WriteAttributeString("Total", Nothing, "0")
                wr.WriteAttributeString("SubTotal", Nothing, "0")
                wr.WriteAttributeString("Fecha", Nothing, Fecha)
                wr.WriteAttributeString("Sello", Nothing, Sello)
                wr.WriteAttributeString("Certificado", Nothing, Certificado)
                wr.WriteAttributeString("LugarExpedicion", Nothing, ConfigurationSettings.AppSettings.Get("CP").ToString())
                wr.WriteAttributeString("Folio", Nothing, Folio)
                wr.WriteAttributeString("Serie", Nothing, Serie)
                wr.WriteAttributeString("NoCertificado", Nothing, NoCertificado)

                wr.WriteStartElement("cfdi", "Emisor", Nothing) ''NODO EMISOR START
                wr.WriteAttributeString("RegimenFiscal", Nothing, ConfigurationSettings.AppSettings.Get("RegimenFiscal").ToString())
                wr.WriteAttributeString("Rfc", Nothing, ConfigurationSettings.AppSettings.Get("RFC").ToString())
                wr.WriteAttributeString("Nombre", Nothing, ConfigurationSettings.AppSettings.Get("NombreEmpresa").ToString())

                wr.WriteEndElement() ''NODO EMISOR END

                wr.WriteStartElement("cfdi", "Receptor", Nothing) ''NODO RECEPTOR START
                wr.WriteAttributeString("Rfc", Nothing, RFC)
                wr.WriteAttributeString("Nombre", Nothing, NombreCompleto)
                wr.WriteAttributeString("UsoCFDI", Nothing, UsoCFDI)
                wr.WriteEndElement() ''NODO RECEPTOR END

                wr.WriteStartElement("cfdi", "Conceptos", Nothing) ''NODO CONCEPTOS START
                wr.WriteStartElement("cfdi", "Concepto", Nothing) ''NODO CONCEPTO START
                wr.WriteAttributeString("ClaveProdServ", Nothing, "84111506")
                wr.WriteAttributeString("Cantidad", Nothing, 1)
                wr.WriteAttributeString("ClaveUnidad", Nothing, "ACT")
                wr.WriteAttributeString("Descripcion", Nothing, "Pago")
                wr.WriteAttributeString("ValorUnitario", Nothing, "0")
                wr.WriteAttributeString("Importe", Nothing, "0")

                wr.WriteEndElement() ''NODO CONCEPTO END
                wr.WriteEndElement() ''NODO CONCEPTOS END

                wr.WriteStartElement("cfdi", "Complemento", Nothing) ''NODO COMPLEMENTO START
                wr.WriteStartElement("pago10", "Pagos", Nothing) ''NODO PAGO10 START
                wr.WriteAttributeString("Version", Nothing, "1.0")
                wr.WriteStartElement("pago10", "Pago", Nothing) ''NODO PAGO10 START
                wr.WriteAttributeString("FechaPago", Nothing, FechaAbono)
                wr.WriteAttributeString("FormaDePagoP", Nothing, FormaPago)
                wr.WriteAttributeString("MonedaP", Nothing, "MXN")
                wr.WriteAttributeString("Monto", Nothing, montoAbonado)
                wr.WriteStartElement("pago10", "DoctoRelacionado", Nothing) ''NODO DOCTORELACIONADO START
                wr.WriteAttributeString("IdDocumento", Nothing, FolioFiscal)
                wr.WriteAttributeString("Serie", Nothing, SerieOriginal)
                wr.WriteAttributeString("Folio", Nothing, FolioOriginal)
                wr.WriteAttributeString("MonedaDR", Nothing, "MXN")
                wr.WriteAttributeString("MetodoDePagoDR", Nothing, "PPD")
                wr.WriteAttributeString("NumParcialidad", Nothing, NumParcialidad)
                wr.WriteAttributeString("ImpSaldoAnt", Nothing, Format(CDec(SaldoAnterior), "#####0.00"))
                wr.WriteAttributeString("ImpPagado", Nothing, Format(CDec(montoAbonado), "#####0.00"))
                wr.WriteAttributeString("ImpSaldoInsoluto", Nothing, Format(CDec(saldoRestante), "#####0.00"))
                wr.WriteEndElement() ''NODO COMPLEMENTO END
                wr.WriteEndElement() ''NODO PAGO10 END
                wr.WriteEndElement() ''NODO DOCTORELACIONADO END

            End Using
            xml = sw.ToString()
        End Using
        Return xml
    End Function

    Function xmlNotaCredito(Total As String, SubTotal As String, Descuento As String, Fecha As String, Sello As String, Certificado As String, Folio As String, Serie As String, NoCertificado As String,
                            RFC As String, NombreCompleto As String, UsoCFDI As String, listaConceptos As List(Of Concepto), listaUUID As List(Of String)) As String
        Dim xml As String
        Dim config As New XmlWriterSettings
        config.Indent = True
        config.Encoding = Encoding.UTF8
        config.Async = True
        Dim archivo_xml As String = "C:\Users\Luis\Desktop\wea.xml"
        Using sw As New StringWriter()
            Using wr As XmlWriter = XmlWriter.Create(sw, config)
                wr.WriteStartDocument()
                wr.WriteStartElement("cfdi", "Comprobante", "http://www.sat.gob.mx/cfd/3") ''NODO COMPROBANTE START
                wr.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
                wr.WriteAttributeString("xmlns", "pago10", Nothing, "http://www.sat.gob.mx/Pagos")
                wr.WriteAttributeString("xsi", "schemaLocation", Nothing, "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/Pagos http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos10.xsd")
                wr.WriteAttributeString("Moneda", Nothing, "MXN")
                wr.WriteAttributeString("Version", Nothing, ConfigurationSettings.AppSettings.Get("VersionSAT").ToString())
                wr.WriteAttributeString("TipoDeComprobante", Nothing, "E")
                wr.WriteAttributeString("Total", Nothing, Format(CDec(Total), "#####0.00"))
                wr.WriteAttributeString("SubTotal", Nothing, Format(CDec(SubTotal), "#####0.00"))
                wr.WriteAttributeString("Descuento", Nothing, Format(CDec(Descuento), "#####0.00"))
                wr.WriteAttributeString("Fecha", Nothing, Fecha)
                wr.WriteAttributeString("Sello", Nothing, Sello)
                wr.WriteAttributeString("Certificado", Nothing, Certificado)
                wr.WriteAttributeString("LugarExpedicion", Nothing, ConfigurationSettings.AppSettings.Get("CP").ToString())
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
                wr.WriteAttributeString("RegimenFiscal", Nothing, ConfigurationSettings.AppSettings.Get("RegimenFiscal").ToString())
                wr.WriteAttributeString("Rfc", Nothing, ConfigurationSettings.AppSettings.Get("RFC").ToString())
                wr.WriteAttributeString("Nombre", Nothing, ConfigurationSettings.AppSettings.Get("NombreEmpresa").ToString())

                wr.WriteEndElement() ''NODO EMISOR END

                wr.WriteStartElement("cfdi", "Receptor", Nothing) ''NODO RECEPTOR START
                wr.WriteAttributeString("Rfc", Nothing, RFC)
                wr.WriteAttributeString("Nombre", Nothing, NombreCompleto)
                wr.WriteAttributeString("UsoCFDI", Nothing, UsoCFDI)
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
                    wr.WriteAttributeString("Descuento", Nothing, concepto.descuento)
                    wr.WriteEndElement()
                Next
                wr.WriteEndElement()
            End Using
            xml = sw.ToString()
        End Using
        Return xml
    End Function
End Class