Imports System.Text
Imports System.Xml

Public Class PolizaController
    Dim db As DataBaseService = New DataBaseService()
    Function llenarListaPoliza(FechaInicio As String, FechaFin As String) As List(Of ConceptoPoliza)
        Dim listaPoliza As List(Of ConceptoPoliza) = New List(Of ConceptoPoliza)
        Dim tableConceptosPoliza As DataTable = db.getDataTableFromSQL($"SELECT Cuenta, Concepto, Debe, Haber, FolioFiscal, Folio, RFCTimbrado, FechaPago FROM obtenerPolizaEDC('{FechaInicio}', '{FechaFin}')")
        For Each row As DataRow In tableConceptosPoliza.Rows
            Dim conceptoP As ConceptoPoliza = New ConceptoPoliza()
            conceptoP.Cuenta = row("Cuenta")
            conceptoP.Concepto = row("Concepto")
            If (IsDBNull(row("Debe"))) Then
                conceptoP.Monto = row("Haber")
                conceptoP.DebeHaber = "H"
            Else
                conceptoP.Monto = row("Debe")
                conceptoP.DebeHaber = "D"
            End If
            conceptoP.UUID = row("FolioFiscal")
            conceptoP.Serie = row("Folio").ToString().Substring(0, 1)
            conceptoP.Folio = row("Folio").ToString().Substring(1, row("Folio").ToString().Length() - 1)
            conceptoP.RFCEmisor = EnviromentService.RFCEDC
            conceptoP.RFCReceptor = row("RFCTimbrado")
            conceptoP.Fecha = row("FechaPago").ToString().Substring(0, 10)
            listaPoliza.Add(conceptoP)
        Next

        Return listaPoliza
    End Function



    Public Function generarXMLPol(ByVal num_pol As String, ByVal listaPoliza As List(Of ConceptoPoliza), ByVal rango_folios As String, dtPickerInicio As DateTimePicker) As String

        Dim miDocumentoXml As New XmlDocument()


        Dim resultado As String = ""



        Dim conceptoGeneral As String = UCase("INGRESO DEL DiA " & Format(CDate(dtPickerInicio.Value), "dd 'de' MMMM 'del' yyyy") & " FACT. " & rango_folios)


        Dim settings As New XmlWriterSettings()
        settings.Indent = False
        settings.Encoding = Nothing
        settings.NewLineOnAttributes = False
        settings.NewLineChars = False

        settings.Async = True
        Dim builder As New StringBuilder()

        Try

            Using wr As XmlWriter = XmlWriter.Create(builder, settings)
                wr.WriteStartDocument(True)

                wr.WriteStartElement("DATAPACKET", "") 'inicio Nodo DATAPACKET
                wr.WriteAttributeString("Version", "2.0")
                wr.WriteStartElement("METADATA") 'inicio Nodo METADATA
                wr.WriteStartElement("FIELDS") 'inicio Nodo FIELDS 1

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD VersionCOI
                wr.WriteAttributeString("attrname", "VersionCOI")
                wr.WriteAttributeString("fieldtype", "i2")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD TipoPoliz
                wr.WriteAttributeString("attrname", "TipoPoliz")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "5")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD DiaPoliz
                wr.WriteAttributeString("attrname", "DiaPoliz")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "2")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD ConcepPoliz
                wr.WriteAttributeString("attrname", "ConcepPoliz")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "120")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD UUID
                wr.WriteAttributeString("attrname", "UUID")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "100")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD Partidas
                wr.WriteAttributeString("attrname", "Partidas")
                wr.WriteAttributeString("fieldtype", "nested")


                wr.WriteStartElement("FIELDS") 'inicio Nodo FIELDS 2


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD Cuenta
                wr.WriteAttributeString("attrname", "Cuenta")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "21")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD Depto
                wr.WriteAttributeString("attrname", "Depto")
                wr.WriteAttributeString("fieldtype", "i4")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD ConceptoPol
                wr.WriteAttributeString("attrname", "ConceptoPol")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "120")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD Monto
                wr.WriteAttributeString("attrname", "Monto")
                wr.WriteAttributeString("fieldtype", "r8")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD UUID
                wr.WriteAttributeString("attrname", "TipoCambio")
                wr.WriteAttributeString("fieldtype", "r8")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD DebeHaber
                wr.WriteAttributeString("attrname", "DebeHaber")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "1")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD ccostos
                wr.WriteAttributeString("attrname", "ccostos")
                wr.WriteAttributeString("fieldtype", "i4")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD proyectos
                wr.WriteAttributeString("attrname", "proyectos")
                wr.WriteAttributeString("fieldtype", "i4")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD Porcentaje
                wr.WriteAttributeString("attrname", "Porcentaje")
                wr.WriteAttributeString("fieldtype", "r8")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD FRMPAGO
                wr.WriteAttributeString("attrname", "FRMPAGO")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "5")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD NUMCHEQUE
                wr.WriteAttributeString("attrname", "NUMCHEQUE")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "20")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD MONTOBN
                wr.WriteAttributeString("attrname", "MONTOBN")
                wr.WriteAttributeString("fieldtype", "r8")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD BANCO
                wr.WriteAttributeString("attrname", "BANCO")
                wr.WriteAttributeString("fieldtype", "i4")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD CTAORIG
                wr.WriteAttributeString("attrname", "CTAORIG")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "50")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD BENEF
                wr.WriteAttributeString("attrname", "BENEF")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "300")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD RFC
                wr.WriteAttributeString("attrname", "RFC")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "13")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD BANCODEST
                wr.WriteAttributeString("attrname", "BANCODEST")
                wr.WriteAttributeString("fieldtype", "i4")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD CTADEST
                wr.WriteAttributeString("attrname", "CTADEST")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "50")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD FECHACHEQUE
                wr.WriteAttributeString("attrname", "FECHACHEQUE")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "10")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD BANCOORIGEXT
                wr.WriteAttributeString("attrname", "BANCOORIGEXT")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "225")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD BANCODESTEXT
                wr.WriteAttributeString("attrname", "BANCODESTEXT")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "225")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD IDUUID
                wr.WriteAttributeString("attrname", "IDUUID")
                wr.WriteAttributeString("fieldtype", "i4")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD IDFISCAL
                wr.WriteAttributeString("attrname", "IDFISCAL")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "40")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD CDSPartidasUUID
                wr.WriteAttributeString("attrname", "CDSPartidasUUID")
                wr.WriteAttributeString("fieldtype", "nested")


                wr.WriteStartElement("FIELDS") 'inicio Nodo FIELDS 3

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD NUMREG
                wr.WriteAttributeString("attrname", "NUMREG")
                wr.WriteAttributeString("fieldtype", "i4")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD UUIDTIMBRE
                wr.WriteAttributeString("attrname", "UUIDTIMBRE")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "36")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD MONTO
                wr.WriteAttributeString("attrname", "MONTO")
                wr.WriteAttributeString("fieldtype", "r8")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD IDFISCAL
                wr.WriteAttributeString("attrname", "SERIE")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "100")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD FOLIO
                wr.WriteAttributeString("attrname", "FOLIO")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "100")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD RFCEMISOR
                wr.WriteAttributeString("attrname", "RFCEMISOR")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "16")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD RFCRECEPTOR
                wr.WriteAttributeString("attrname", "RFCRECEPTOR")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "16")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD FECHAUUID
                wr.WriteAttributeString("attrname", "FECHAUUID")
                wr.WriteAttributeString("fieldtype", "string")
                wr.WriteAttributeString("WIDTH", "10")
                wr.WriteEndElement() 'Fin Nodo FIELD

                wr.WriteStartElement("FIELD") 'inicio Nodo FIELD TIPOCOMPROBANTE
                wr.WriteAttributeString("attrname", "TIPOCOMPROBANTE")
                wr.WriteAttributeString("fieldtype", "i2")
                wr.WriteEndElement() 'Fin Nodo FIELD


                wr.WriteEndElement() 'Fin Nodo FIELDS 3
                wr.WriteStartElement("PARAMS") 'inicio Nodo PARAMS
                wr.WriteEndElement() 'Fin Nodo PARAMS
                wr.WriteEndElement() 'Fin Nodo FIELD  CDSPartidasUUID

                wr.WriteEndElement() 'Fin Nodo FIELDS 2
                wr.WriteStartElement("PARAMS") 'inicio Nodo PARAMS
                wr.WriteEndElement() 'Fin Nodo PARAMS
                wr.WriteEndElement() 'Fin Nodo FIELD Partidas

                wr.WriteEndElement() 'Fin Nodo FIELDS 1
                wr.WriteStartElement("PARAMS") 'inicio Nodo PARAMS
                wr.WriteEndElement() 'Fin Nodo PARAMS

                wr.WriteEndElement() 'fin Nodo METADATA


                wr.WriteStartElement("ROWDATA")  'inicio Nodo ROWDATA

                wr.WriteStartElement("ROW")  'inicio Nodo ROW

                wr.WriteAttributeString("VersionCOI", "810")
                wr.WriteAttributeString("TipoPoliz", "Ig")

                wr.WriteAttributeString("DiaPoliz", num_pol) 'cambiar
                wr.WriteAttributeString("ConcepPoliz", conceptoGeneral) 'cambiar

                wr.WriteStartElement("Partidas")

                For i As Integer = 0 To listaPoliza.Count - 1

                    wr.WriteStartElement("ROWPartidas")  'inicio Nodo ROWPartidas

                    wr.WriteAttributeString("Cuenta", listaPoliza(i).Cuenta)
                    wr.WriteAttributeString("Depto", "0")
                    wr.WriteAttributeString("ConceptoPol", listaPoliza(i).Concepto)
                    wr.WriteAttributeString("Monto", listaPoliza(i).Monto)
                    wr.WriteAttributeString("TipoCambio", "1")
                    wr.WriteAttributeString("DebeHaber", listaPoliza(i).DebeHaber)

                    wr.WriteAttributeString("ccostos", "0")
                    wr.WriteAttributeString("proyectos", "0")
                    wr.WriteAttributeString("Porcentaje", "0")
                    wr.WriteAttributeString("FRMPAGO", "")
                    wr.WriteAttributeString("NUMCHEQUE", "")
                    wr.WriteAttributeString("MONTOBN", "0")
                    wr.WriteAttributeString("BANCO", "0")

                    wr.WriteAttributeString("CTAORIG", "")
                    wr.WriteAttributeString("BENEF", "")
                    wr.WriteAttributeString("RFC", "")
                    wr.WriteAttributeString("BANCODEST", "0")
                    wr.WriteAttributeString("CTADEST", "")
                    wr.WriteAttributeString("FECHACHEQUE", "")
                    wr.WriteAttributeString("BANCOORIGEXT", "")
                    wr.WriteAttributeString("BANCODESTEXT", "")
                    wr.WriteAttributeString("IDUUID", CStr(i))
                    wr.WriteAttributeString("IDFISCAL", "")

                    If listaPoliza(i).UUID Is Nothing Then

                        wr.WriteStartElement("CDSPartidasUUID")  'inicio Nodo CDSPartidasUUID
                        wr.WriteString("")
                        wr.WriteEndElement() 'fin Nodo CDSPartidasUUID

                    Else
                        wr.WriteStartElement("CDSPartidasUUID")  'inicio Nodo CDSPartidasUUID
                        wr.WriteStartElement("ROWCDSPartidasUUID")  'inicio Nodo ROWCDSPartidasUUID

                        wr.WriteAttributeString("NUMREG", CStr(i))
                        wr.WriteAttributeString("UUIDTIMBRE", listaPoliza(i).UUID)
                        wr.WriteAttributeString("MONTO", listaPoliza(i).Monto)
                        wr.WriteAttributeString("BANCODEST", "0")
                        wr.WriteAttributeString("SERIE", listaPoliza(i).Serie)
                        wr.WriteAttributeString("FOLIO", listaPoliza(i).Folio)
                        wr.WriteAttributeString("RFCEMISOR", listaPoliza(i).RFCEmisor)
                        wr.WriteAttributeString("RFCRECEPTOR", listaPoliza(i).RFCReceptor)
                        wr.WriteAttributeString("FECHAUUID", Format(CDate(listaPoliza(i).Fecha), "dd/MM/yyyy"))
                        wr.WriteAttributeString("TIPOCOMPROBANTE", "1")

                        wr.WriteEndElement() 'fin Nodo ROWCDSPartidasUUID
                        wr.WriteEndElement() 'fin Nodo CDSPartidasUUID

                    End If


                    wr.WriteEndElement() 'fin Nodo ROWPartidas

                Next

                wr.WriteEndElement() 'fin Nodo Partidas
                wr.WriteEndElement() 'fin Nodo ROW
                wr.WriteEndElement() 'fin Nodo ROWDATA

                wr.WriteEndElement() 'Fin del nodo DATAPACKET

                wr.WriteEndDocument()
                wr.Flush()

            End Using

            resultado = builder.ToString
            Console.WriteLine(builder)
            Console.ReadLine()

            resultado = resultado.Replace("<?xml version=" + Chr(34) + "1.0" + Chr(34) + " encoding=" + Chr(34) + "utf-16" + Chr(34) + " standalone=" + Chr(34) + "yes" + Chr(34) + "?>", "<?xml version=" + Chr(34) + "1.0" + Chr(34) + " standalone=" + Chr(34) + "yes" + Chr(34) + "?>  ")
            resultado = resultado.Replace(" />", "/>")

            Console.WriteLine(resultado)
            Console.ReadLine()

        Catch ex As Exception
            MsgBox("Error: " & ex.ToString)
        End Try


        Return resultado

    End Function

End Class
