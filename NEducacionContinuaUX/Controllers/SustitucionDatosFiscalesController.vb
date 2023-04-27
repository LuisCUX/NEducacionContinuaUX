Imports System.Configuration

Public Class SustitucionDatosFiscalesController
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim xml As XmlService40 = New XmlService40()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Dim es As EmailService = New EmailService()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim co As CobrosController = New CobrosController()

    Sub obtenerInfoFactura(Folio As String, lblClaveCliente As Label, lblRFCTimbrado As Label, lblFechaFacturacion As Label, lblFormaPago As Label, lblFolioFiscal As Label)
        Dim tableDatosFactura As DataTable = db.getDataTableFromSQL($"SELECT X.Matricula_Clave, X.RFCTimbrado, X.Fecha_Pago, F.Descripcion, X.FolioFiscal FROM ing_xmlTimbrados AS X
                                                                       INNER JOIN ing_CatFormaPago AS F ON F.ID = X.Forma_PagoID
                                                                       WHERE Folio = '{Folio}'")

        For Each row As DataRow In tableDatosFactura.Rows
            lblClaveCliente.Text = row("Matricula_Clave")
            lblRFCTimbrado.Text = row("RFCTimbrado")
            lblFechaFacturacion.Text = row("Fecha_Pago").ToString().Replace("T", " ")
            lblFormaPago.Text = row("Descripcion")
            lblFolioFiscal.Text = row("FolioFiscal")
        Next
    End Sub

    Sub getDatosPagoTarjeta(XMLID As Integer, cbBanco As ComboBox, cbTipoTarjeta As ComboBox, txtNumTarjeta As TextBox)
        Dim tablePagoTarjeta As DataTable = db.getDataTableFromSQL($"SELECT B.ID AS IDBanco, TT.ID AS IDTipo, NumTarjeta FROM ing_PagosTarjeta AS T 
                                                                     INNER JOIN ing_res_BancoTarjeta AS RES ON RES.ID = T.ID_resBancoTarjeta
                                                                     INNER JOIN ing_Cat_Bancos AS B ON B.ID = RES.ID_Banco
                                                                     INNER JOIN ing_CatTipoTarjeta AS TT ON TT.ID = RES.ID_TipoTarjeta
                                                                     WHERE ID_Factura = {XMLID}")

        For Each row As DataRow In tablePagoTarjeta.Rows
            txtNumTarjeta.Text = row("NumTarjeta")
            cbBanco.SelectedValue = row("IDBanco")
            SustitucionDatosFiscalesEDC.commitcbBanco()
            cbTipoTarjeta.SelectedValue = row("IDTipo")
        Next

    End Sub

    Sub getDatosPagoCheque(XMLID As Integer, txtBanco As TextBox, txtNoCuenta As TextBox, txtNoCheque As TextBox)
        Dim tablePagoCheque As DataTable = db.getDataTableFromSQL($"SELECT NombreBanco, NoCuenta, NoCheque FROM ing_PagosCheques WHERE ID_Factura = {XMLID}")
        For Each row As DataRow In tablePagoCheque.Rows
            txtBanco.Text = row("NombreBanco")
            txtNoCuenta.Text = row("NoCuenta")
            txtNoCheque.Text = row("NoCheque")
        Next
    End Sub

    Sub getDatosTransferencia(XMLID As Integer, cbBanco As ComboBox, FechaPago As DateTimePicker)
        Dim tablePagoTransferencias As DataTable = db.getDataTableFromSQL($"SELECT ID_Banco, Fecha_Pago FROM ing_PagosTransferencias WHERE ID_Factura = {XMLID}")
        For Each row As DataRow In tablePagoTransferencias.Rows
            cbBanco.SelectedValue = row("ID_Banco")
            FechaPago.Value = row("Fecha_Pago")
        Next
    End Sub

    Sub getDatosDeposito(XMLID As Integer, cbBanco As ComboBox, cbTipoTarjeta As ComboBox, FechaPago As DateTimePicker)
        Dim tablePagoDeposito As DataTable = db.getDataTableFromSQL($"SELECT ID_Banco, ID_TipoPago, FechaPago FROM ing_PagosDepositos WHERE ID_Factura = {XMLID}")
        For Each row As DataRow In tablePagoDeposito.Rows
            cbBanco.SelectedValue = row("ID_Banco")
            SustitucionDatosFiscalesEDC.commitcbBanco()
            cbTipoTarjeta.SelectedValue = row("ID_TipoPago")
            FechaPago.Value = row("FechaPago")
        Next
    End Sub

    Sub getDatosNotaCredito(XMLID As Integer)

    End Sub

    Sub LlenarGridConceptos(XMLID As Integer, GridConceptos As DataGridView)
        Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT X.IDConcepto, C.Clave AS Clave_Concepto, X.Nombre_Concepto, X.Cantidad, X.PrecioUnitario, X.Descuento, X.IVA, X.Total FROM ing_xmlTimbradosConceptos AS X
                                                                   INNER JOIN ing_CatClavesPagos AS C ON C.ID = X.Clave_Concepto
                                                                   WHERE XMLID = {XMLID}")

        For Each concepto As DataRow In tableConceptos.Rows
            concepto("PrecioUnitario") = Format(CDec(concepto("PrecioUnitario")), "#####0.00")
            concepto("Descuento") = Format(CDec(concepto("Descuento")), "#####0.00")
            concepto("IVA") = Format(CDec(concepto("IVA")), "#####0.00")
            concepto("Total") = Format(CDec(concepto("Total")), "#####0.00")
        Next

        For Each row As DataRow In tableConceptos.Rows
            GridConceptos.Rows.Add(row("IDConcepto"), row("Clave_Concepto"), row("Nombre_Concepto"), row("Cantidad"), row("PrecioUnitario"), row("Descuento"), row("IVA"), row("Total"))
        Next
    End Sub

    Sub LlenarGridConceptosSC(XMLID As Integer, GridConceptos As DataGridView)
        Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT X.IDConcepto, C.Clave AS Clave_Concepto, X.Nombre_Concepto, X.Cantidad, X.PrecioUnitario, X.Descuento, X.IVA, X.Total FROM ing_xmlTimbradosConceptos AS X
                                                                   INNER JOIN ing_CatClavesPagos AS C ON C.ID = X.Clave_Concepto
                                                                   WHERE XMLID = {XMLID}")

        For Each concepto As DataRow In tableConceptos.Rows
            concepto("PrecioUnitario") = Format(CDec(concepto("PrecioUnitario")), "#####0.00")
            concepto("Descuento") = Format(CDec(concepto("Descuento")), "#####0.00")
            concepto("IVA") = Format(CDec(concepto("IVA")), "#####0.00")
            concepto("Total") = Format(CDec(concepto("Total")), "#####0.00")
        Next

        For Each row As DataRow In tableConceptos.Rows
            GridConceptos.Rows.Add(row("IDConcepto"), row("Clave_Concepto"), row("Nombre_Concepto"), row("Cantidad"), row("PrecioUnitario"), row("Descuento"), row("IVA"), Me.getNuevoNombreConcepto(row("IDConcepto"), row("Clave_Concepto")).ToString().ToUpper(), row("Total"))
        Next
    End Sub

    Function Cobrar(listaConceptos As List(Of Concepto), formaPago As String, formaPagoID As Integer, Matricula As String, RFCCLiente As String, NombreCLiente As String, montoTotal As Decimal, Credito As Boolean, tipoMatricula As Integer, Cp As String, RegFiscal As String, usoCFDI As String, UUIDSustituido As String) As String
        If (RFCCLiente = "XAXX010101000") Then
            NombreCLiente = va.quitaTildesEspecial(NombreCLiente)
        End If
        NombreCLiente = va.borrarEspacios(NombreCLiente)
        Dim folioPago As String = co.obtenerFolio("Pago")
        Dim esEvento As Boolean = False
        Try
            db.startTransaction()
            '---------------------------------------------------------IDENTIFICA ABONO---------------------------------------------------------

            ''---------------------------------------------------------CALCULO DE TOTALES------------------------------------------------------
            Dim Certificado As String
            Dim NoCertificado As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                Certificado = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
                NoCertificado = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()
            Else
                Certificado = ConfigurationSettings.AppSettings.Get("prodCertificadoContent").ToString()
                NoCertificado = ConfigurationSettings.AppSettings.Get("prodCertificado").ToString()
            End If

            ''-----CALCULA SUBTOTAL-----''
            Dim subtotalSuma As Decimal
            For Each concepto As Concepto In listaConceptos
                subtotalSuma = subtotalSuma + CDec(concepto.costoTotal)
            Next
            Dim SubTotal As String = subtotalSuma.ToString()

            ''-----CALCULA TOTAL-----''
            Dim totalSuma As Decimal
            For Each concepto As Concepto In listaConceptos
                totalSuma = totalSuma + CDec(concepto.costoFinal)
            Next
            Dim Total As String = totalSuma.ToString()

            ''-----CALCULA TOTAL IVA-----''
            Dim totalIVASuma As Decimal
            For Each concepto As Concepto In listaConceptos
                totalIVASuma = totalIVASuma + CDec(concepto.costoIVATotal)
            Next
            Dim totalIVA As String = totalIVASuma.ToString()

            ''-----CALCULA TOTAL BASE-----''
            Dim totalIVABase As Decimal
            For Each concepto As Concepto In listaConceptos
                totalIVABase = totalIVABase + CDec(concepto.CostoIvaBase)
            Next
            Dim totalBase As String = totalIVABase.ToString()

            ''-----CALCUOA DECUENTO-----''
            Dim Descuento As Decimal
            For Each concepto As Concepto In listaConceptos
                Descuento = Descuento + CDec(concepto.descuento)
            Next
            Dim DescuentoS As String = Descuento.ToString()
            Dim Folio As String = folioPago.Substring(1, 6)
            Dim Serie As String = folioPago.Substring(0, 1)

            SubTotal = ch.getFormat(SubTotal)
            totalIVA = ch.getFormat(totalIVA)
            DescuentoS = ch.getFormat(DescuentoS)
            Total = ((CDec(SubTotal) - CDec(Descuento)) + CDec(totalIVA))

            For Each concepto As Concepto In listaConceptos
                If (concepto.claveConcepto <> "POA" And concepto.claveConcepto <> "POE" And concepto.claveConcepto <> "POC" And concepto.claveConcepto <> "REC") Then
                    esEvento = True
                End If
            Next

            Dim TotalText As String
            Dim valores As String()
            If (InStr(Total, ".")) Then
                valores = Split(Total, ".")
                TotalText = $"{co.Num2Text(valores(0))} PESOS {valores(1)}/100 M.N"
            Else
                TotalText = $"{co.Num2Text(Total)} PESOS"
            End If
            Dim Fecha As String = db.exectSQLQueryScalar("select STUFF(CONVERT(VARCHAR(50),GETDATE(), 127) ,20,4,'') as fecha")

            For Each concepto As Concepto In listaConceptos
                concepto.NombreConcepto = co.quitaTildesEspecial(concepto.NombreConcepto)
            Next



            ''---------------------------------------------------------TIMBRADO---------------------------------------------------------
            Dim cadena = xml.cadenaSustitucion(Serie, Folio, Fecha, formaPago, NoCertificado, SubTotal, DescuentoS, Total, listaConceptos, totalIVA, RFCCLiente, NombreCLiente, Credito, Cp, RegFiscal, totalBase, usoCFDI, UUIDSustituido)
            Dim sello As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                sello = st.Sellado("\\192.168.1.252\Sistemas\Reportes\EducacionContinua\Timbrado\pfx\uxa_pfx33.pfx", "12345678a", cadena) ''PRUEBAS
            Else
                sello = st.Sellado("\\192.168.1.252\Sistemas\Reportes\EducacionContinua\Timbrado\pfx\EDC.pfx", "EDC12345a", cadena) ''REAL
            End If

            Dim xmlString As String = xml.xmlPruebaSustitucion(Total, SubTotal, DescuentoS, totalIVA, Fecha, sello, Certificado, NoCertificado, formaPago, Folio, Serie, usoCFDI, listaConceptos, RFCCLiente, NombreCLiente, Credito, Cp, RegFiscal, totalBase, UUIDSustituido)
            xmlString = xmlString.Replace("utf-16", "UTF-8")
            Dim xmlTimbrado As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                xmlTimbrado = st.TimbradoPruebas(xmlString, Folio)
            Else
                xmlTimbrado = st.Timbrado(xmlString, Folio)
            End If

            Dim folioFiscal As String = co.Extrae_Cadena(xmlTimbrado, "TimbreFiscalDigital", "SelloCFD")
            folioFiscal = co.Extrae_Cadena(folioFiscal, "UUID=", " FechaTimbrado")
            folioFiscal = co.Extrae_Cadena(folioFiscal, "=", "")
            folioFiscal = folioFiscal.Substring(1, folioFiscal.Length() - 1)

            ''---------------------------------------------------------GENERACION DE FACTURA---------------------------------------------------------''

            Dim tipoPago As String = $"COBRO DE CONCEPTO SUSTITUYENDO FACTURA UUID = {UUIDSustituido}"

            Dim regimenFiscaltxt As String = db.exectSQLQueryScalar($"SELECT (RegimenFiscal + '(' + CAST(ID_Contador AS varchar(MAX)) + ')') AS regimen FROM ing_Cat_RegFis WHERE ID_Contador = {RegFiscal}")

            Dim IDXML As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_xmlTimbrados(Matricula_Clave, Folio, FolioFiscal, Certificado, XMLTimbrado, fac_Cadena, fac_Sello, Tipo_Pago, Forma_Pago, Forma_PagoID, Fecha_Pago, Cajero, RegimenFiscal, RFCTimbrado, Subtotal, Descuento, IVA, Total, usoCFDI, CanceladaHoy, CanceladaOtroDia) VALUES ('{Matricula}', '{Serie}{Folio}', '{folioFiscal}', '{NoCertificado}', '{xmlTimbrado}', '{cadena}', '{sello}', '{tipoPago}', '{formaPago}', {formaPagoID}, '{Fecha}', '{User.getUsername}', '{regimenFiscaltxt}', '{RFCCLiente}', {SubTotal}, {DescuentoS}, {totalIVA}, {Total}, '{usoCFDI}', 0, 0)")
            For Each item As Concepto In listaConceptos
                Dim IDClave As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE Clave = '{item.claveConcepto}'")
                db.execSQLQueryWithoutParams($"INSERT INTO ing_xmlTimbradosConceptos(Clave_Cliente, XMLID, Nombre_Concepto, IDConcepto, Clave_Concepto, ClaveUnidad, ClaveProdServ, PrecioUnitario, IVA, Descuento, Cantidad, Total, Nota) VALUES ('{item.Matricula}', {IDXML}, '{item.NombreConcepto}', {item.IDConcepto}, {IDClave}, '{item.cveUnidad}', '{item.cveClase}', {Format(CDec(item.costoUnitario), "#####0.00")}, {Format(CDec(item.costoIVAUnitario), "#####0.00")}, {Format(CDec(item.descuento), "#####0.00")}, {item.Cantidad}, {Format(CDec(((item.costoTotal - item.descuento) + item.costoIVATotal)), "#####0.00")}, 0)")
            Next
            db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Usuario = '{User.getUsername()}'")

            Dim NombreEvento As String
            If (esEvento = False) Then
                NombreEvento = "   "
            Else
                NombreEvento = db.exectSQLQueryScalar($"SELECT C.nombre FROM portal_congreso AS C
                                                        INNER JOIN ing_Planes AS P ON P.ID_Congreso = C.id_congreso
                                                        INNER JOIN portal_registroCongreso AS RC ON RC.id_plan = P.ID
                                                        WHERE RC.clave_cliente = '{Matricula}'")
            End If
            If (IsNothing(NombreEvento)) Then
                NombreEvento = "------"
            End If
            Dim descripcionCFDI As String = db.exectSQLQueryScalar($"select UPPER('(' + clave_usoCFDI + ')' + ' ' + descripcion) As Clave from ing_cat_usoCFDI WHERE clave_usoCFDI = '{usoCFDI}'")
            Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={RFCCLiente}id={folioFiscal}tt={Total}"
            co.gernerarQr(QR, $"{Serie}{Folio}")
            rep.AgregarFuente("FacturaEDC.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("ClaveCliente", Matricula)
            rep.AgregarParametros("CantidadLetra", TotalText)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.AgregarParametros("TipoCliente", tipoMatricula)
            rep.AgregarParametros("NombreEvento", NombreEvento)
            rep.AgregarParametros("RFC", RFCCLiente)
            rep.MostrarReporte()
            db.commitTransaction()
            Return $"{Serie}{Folio}"
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
            SustitucionDatosFiscalesEDC.Reiniciar()
            Return Nothing
        End Try

    End Function


    Function getNuevoNombreConcepto(conceptoID As Integer, claveConcepto As String)
        Dim nombreConcepto As String
        Dim claveConceptoint As Integer
        ''--------------------PAGOS OPCIONALES--------------------''
        If (claveConcepto = "POA" Or claveConcepto = "POE" Or claveConcepto = "POC") Then
            Dim nombreTabla As String
            If (claveConcepto = "POA") Then
                nombreTabla = "ing_AsignacionPagoOpcionalAlumno"
                claveConceptoint = 1
            ElseIf (claveConcepto = "POE") Then
                nombreTabla = "ing_AsignacionPagoOpcionalExterno"
                claveConceptoint = 2
            ElseIf (claveConcepto = "POC") Then
                nombreTabla = "ing_AsignacionPagoOpcionalCongreso"
                claveConceptoint = 8
            End If
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT P.Nombre, P.claveProductoServicio, P.claveUnidad, A.costoUnitario, 0.00 As Descuento, P.considerarIVA, P.AgregaIVA, P.ExentaIVA, A.Cantidad FROM {nombreTabla} AS A
                                                                     INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                                     INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                                     WHERE A.ID = {conceptoID}")

            For Each item As DataRow In tableConcepto.Rows
                nombreConcepto = Me.removerEspaciosInicioFin(item("Nombre"))
            Next
            ''--------------------CONGRESOS--------------------''
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

            For Each item As DataRow In tableConcepto.Rows
                nombreConcepto = Me.removerEspaciosInicioFin(item("nombre"))
            Next
            ''--------------------DIPLOMADOS INSCRIPCION--------------------''
        ElseIf (claveConcepto = "DIN") Then
            Dim Costo As Decimal
            Dim Descuento As Decimal
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, CON.clave_servicio, C.Importe, AC.Descuento, C.Fecha_Limite_Desc, C.AgregaIVA, C.AbsorbeIVA, C.ExentaIVA FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_Planes AS PL ON PL.ID = C.ID_Plan
                                                                      INNER JOIN portal_congreso AS CON ON CON.id_congreso = PL.ID_Congreso
                                                                      WHERE AC.ID = {conceptoID}")
            For Each item As DataRow In tableConcepto.Rows
                nombreConcepto = Me.removerEspaciosInicioFin(item("Descripcion"))
            Next
            ''--------------------DIPLOMADOS COLEGIATURAS--------------------''
        ElseIf (claveConcepto = "DCO") Then
            Dim Costo As Decimal
            Dim Descuento As Decimal
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, CON.clave_servicio, C.Importe, AC.Descuento, C.Fecha_Limite_Desc, C.AgregaIVA, C.AbsorbeIVA, C.ExentaIVA FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_Planes AS PL ON PL.ID = C.ID_Plan
                                                                      INNER JOIN portal_congreso AS CON ON CON.id_congreso = PL.ID_Congreso
                                                                      WHERE AC.ID = {conceptoID}")
            For Each item As DataRow In tableConcepto.Rows
                nombreConcepto = Me.removerEspaciosInicioFin(item("Descripcion"))
            Next
            ''--------------------DIPLOMADOS PAGO UNICO--------------------''
        ElseIf (claveConcepto = "DPU") Then
            Dim Costo As Decimal
            Dim Descuento As Decimal
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, CON.clave_servicio, C.Importe, AC.Descuento, C.Fecha_Limite_Desc, C.AgregaIVA, C.AbsorbeIVA, C.ExentaIVA FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_Planes AS PL ON PL.ID = C.ID_Plan
                                                                      INNER JOIN portal_congreso AS CON ON CON.id_congreso = PL.ID_Congreso
                                                                      WHERE AC.ID = {conceptoID}")
            For Each item As DataRow In tableConcepto.Rows
                nombreConcepto = Me.removerEspaciosInicioFin(item("Descripcion"))
            Next
            ''--------------------RECARGOS--------------------''
        ElseIf (claveConcepto = "REC") Then
            Dim tableConcepto As DataTable = db.getDataTableFromSQL($"SELECT ID, Descripcion, Monto FROM ing_PlanesRecargos WHERE ID = {conceptoID}")
            For Each item As DataRow In tableConcepto.Rows
                nombreConcepto = Me.removerEspaciosInicioFin(item("Descripcion"))
            Next
        End If

        Return nombreConcepto
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
End Class