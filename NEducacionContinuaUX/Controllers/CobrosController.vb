Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Public Class CobrosController
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim xml As XmlService40 = New XmlService40()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Dim es As EmailService = New EmailService()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim abono As Boolean = False
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA PAGO OPCIONAL DE ALUMNO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarPagoOpcionalAlumno(concepto As Concepto, Matricula As String, Folio As String)
        Dim ID_ResAsignacion As Integer = db.exectSQLQueryScalar($"SELECT ID_resPagoOpcionalAsignacion FROM ing_AsignacionPagoOpcionalAlumno WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalAlumno SET folioPago = '{Folio}', Activo = 0 WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_resPagoOpcionalAsignacion SET Activo = 0 WHERE ID = {ID_ResAsignacion}")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA PAGO OPCIONAL DE EXTERNO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarPagoOpcionalExterno(concepto As Concepto, Matricula As String, Folio As String)
        Dim ID_ResAsignacion As Integer = db.exectSQLQueryScalar($"SELECT ID_resPagoOpcionalAsignacion FROM ing_AsignacionPagoOpcionalExterno WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalExterno SET folioPago = '{Folio}', Activo = 0 WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_resPagoOpcionalAsignacion SET Activo = 0 WHERE ID = {ID_ResAsignacion}")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA PAGO OPCIONAL DE CONGRESO----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarPagoOpcionalCongreso(concepto As Concepto, Matricula As String, Folio As String)
        Dim ID_ResAsignacion As Integer = db.exectSQLQueryScalar($"SELECT ID_resPagoOpcionalAsignacion FROM ing_AsignacionPagoOpcionalCongreso WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalCongreso SET folioPago = '{Folio}', Activo = 0 WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_resPagoOpcionalAsignacion SET Activo = 0 WHERE ID = {ID_ResAsignacion}")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------------------COBRA CONGRESO-------------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarCongreso(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        Dim formaPagoint As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosCongresos(Folio, Matricula, valorUnitario, Cantidad, valorIVA, Descuento, ID_FormaPago, Fecha_Pago, Autorizado, Condonado, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {concepto.Cantidad}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, GETDATE(), 0, 0, '{User.getUsername()}', 0)")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA INSCRIPCION DE DIPLOMADO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarInscripcionDiplomado(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        Dim formaPagoint As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDiplomados(Folio, Matricula, valorUnitario, valorIVA, Descuento, ID_FormaPago, ID_ClavePago, Fecha_Pago, Autorizado, Condonado, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, 6, GETDATE(), 0, 0, '{User.getUsername()}', 1)")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0, Folio = '{Folio}' WHERE ID = {concepto.IDConcepto}")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA COLEGIATURA DE DIPLOMADO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarColegiaturaDiplomado(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        Dim formaPagoint As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDiplomados(Folio, Matricula, valorUnitario, valorIVA, Descuento, ID_FormaPago, ID_ClavePago, Fecha_Pago, Autorizado, Condonado, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, 4, GETDATE(), 0, 0, '{User.getUsername()}', 1)")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0, Folio = '{Folio}' WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 5")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA PAGO UNICO DE DIPLOMADO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarPagoUnicoDiplomado(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        Dim formaPagoint As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDiplomados(Folio, Matricula, valorUnitario, valorIVA, Descuento, ID_FormaPago, ID_ClavePago, Fecha_Pago, Autorizado, Condonado, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, 5, GETDATE(), 0, 0, '{User.getUsername()}', 1)")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0, Folio = '{Folio}' WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 4")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 6")
    End Sub

    Sub cobrarRecargoDiplomado(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        db.execSQLQueryWithoutParams($"UPDATE ing_PlanesRecargos SET Activo = 0, Folio = '{Folio}' WHERE ID = {concepto.IDConcepto}")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''---------------------------------------------------------COBRA PAGO YA VALIDADO---------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Function Cobrar(listaConceptos As List(Of Concepto), formaPago As String, formaPagoID As Integer, Matricula As String, RFCCLiente As String, NombreCLiente As String, montoTotal As Decimal, Credito As Boolean, tipoMatricula As Integer, Cp As String, RegFiscal As String, usoCFDI As String) As Integer
        If (RFCCLiente = "XAXX010101000") Then
            NombreCLiente = va.quitaTildesEspecial(NombreCLiente)
        End If
        NombreCLiente = va.borrarEspacios(NombreCLiente)
        Dim folioPago As String = Me.obtenerFolio("Pago")
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
                TotalText = $"{Me.Num2Text(valores(0))} PESOS {valores(1)}/100 M.N"
            Else
                TotalText = $"{Me.Num2Text(Total)} PESOS"
            End If
            Dim Fecha As String = db.exectSQLQueryScalar("select STUFF(CONVERT(VARCHAR(50),GETDATE(), 127) ,20,4,'') as fecha")

            For Each concepto As Concepto In listaConceptos
                concepto.NombreConcepto = Me.quitaTildesEspecial(concepto.NombreConcepto)
            Next



            ''---------------------------------------------------------TIMBRADO---------------------------------------------------------
            Dim cadena = xml.cadenaPrueba(Serie, Folio, Fecha, formaPago, NoCertificado, SubTotal, DescuentoS, Total, listaConceptos, totalIVA, RFCCLiente, NombreCLiente, Credito, Cp, RegFiscal, totalBase, usoCFDI)
            Dim sello As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                sello = st.Sellado("\\192.168.1.252\Sistemas\Reportes\EducacionContinua\Timbrado\pfx\uxa_pfx33.pfx", "12345678a", cadena) ''PRUEBAS
            Else
                sello = st.Sellado("\\192.168.1.252\Sistemas\Reportes\EducacionContinua\Timbrado\pfx\EDC.pfx", "EDC12345a", cadena) ''REAL
            End If

            Dim xmlString As String = xml.xmlPrueba(Total, SubTotal, DescuentoS, totalIVA, Fecha, sello, Certificado, NoCertificado, formaPago, Folio, Serie, usoCFDI, listaConceptos, RFCCLiente, NombreCLiente, Credito, Cp, RegFiscal, totalBase)
            xmlString = xmlString.Replace("utf-16", "UTF-8")
            Dim xmlTimbrado As String
            If (System.Diagnostics.Debugger.IsAttached) Then
                xmlTimbrado = st.TimbradoPruebas(xmlString, Folio)
            Else
                xmlTimbrado = st.Timbrado(xmlString, Folio)
            End If
            Dim folioFiscal As String = Me.Extrae_Cadena(xmlTimbrado, "UUID=", " FechaTimbrado")
            folioFiscal = Me.Extrae_Cadena(folioFiscal, "=", "")
            folioFiscal = folioFiscal.Substring(1, folioFiscal.Length() - 1)
            If (System.Diagnostics.Debugger.IsAttached) Then
                File.WriteAllText("C:\Users\Luis\Desktop\wea.xml", xmlTimbrado)
            End If

            ''---------------------------------------------------------REGISTRO DE COBRO/S EN BASE DE DATOS---------------------------------------------------------
            For Each concepto As Concepto In listaConceptos
                If (concepto.Abonado = False) Then
                    If (concepto.claveConcepto = "POA") Then
                        Me.cobrarPagoOpcionalAlumno(concepto, Matricula, folioPago)
                    ElseIf (concepto.claveConcepto = "POE") Then
                        Me.cobrarPagoOpcionalExterno(concepto, Matricula, folioPago)
                    ElseIf (concepto.claveConcepto = "POC") Then
                        Me.cobrarPagoOpcionalCongreso(concepto, Matricula, folioPago)
                    ElseIf (concepto.claveConcepto = "CON") Then
                        Me.cobrarCongreso(concepto, Matricula, folioPago, formaPago)
                    ElseIf (concepto.claveConcepto = "DCO") Then
                        Me.cobrarColegiaturaDiplomado(concepto, Matricula, folioPago, formaPago)
                    ElseIf (concepto.claveConcepto = "DIN") Then
                        Me.cobrarInscripcionDiplomado(concepto, Matricula, folioPago, formaPago)
                    ElseIf (concepto.claveConcepto = "DPU") Then
                        Me.cobrarPagoUnicoDiplomado(concepto, Matricula, folioPago, formaPago)
                    ElseIf (concepto.claveConcepto = "REC") Then
                        Me.cobrarRecargoDiplomado(concepto, Matricula, $"{Serie}{Folio}", formaPago)
                    End If
                End If
            Next

            ''File.WriteAllText("C:\Users\darkz\Desktop\wea.xml", xmlTimbrado)

            ''---------------------------------------------------------GENERACION DE FACTURA---------------------------------------------------------''

            Dim tipoPago As String
            If (Credito = True) Then
                tipoPago = "COBRO DE CONCEPTO A CREDITO"
                db.execSQLQueryWithoutParams($"INSERT INTO ing_Creditos(Matricula, Folio, FolioFiscal, Cantidad, Cantidad_Abonada, NumAbonos, Fecha, Activo) VALUES ('{Matricula}', '{folioPago}', '{folioFiscal}', {montoTotal}, 0, 0, GETDATE(), 1)")
            Else
                tipoPago = "COBRO DE CONCEPTO"
            End If

            Dim regimenFiscaltxt As String = db.exectSQLQueryScalar($"SELECT (RegimenFiscal + '(' + CAST(ID_Contador AS varchar(MAX)) + ')') AS regimen FROM ing_Cat_RegFis WHERE ID_Contador = {RegFiscal}")

            Dim IDXML As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_xmlTimbrados(Matricula_Clave, Folio, FolioFiscal, Certificado, XMLTimbrado, fac_Cadena, fac_Sello, Tipo_Pago, Forma_Pago, Forma_PagoID, Fecha_Pago, Cajero, RegimenFiscal, RFCTimbrado, Subtotal, Descuento, IVA, Total, usoCFDI, CanceladaHoy, CanceladaOtroDia) VALUES ('{Matricula}', '{Serie}{Folio}', '{folioFiscal}', '{NoCertificado}', '{xmlTimbrado}', '{cadena}', '{sello}', '{tipoPago}', '{formaPago}', {formaPagoID}, '{Fecha}', '{User.getUsername}', '{regimenFiscaltxt}', '{RFCCLiente}', {SubTotal}, {DescuentoS}, {totalIVA}, {Total}, '{usoCFDI}', 0, 0)")
            For Each item As Concepto In listaConceptos
                Dim IDClave As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE Clave = '{item.claveConcepto}'")
                db.execSQLQueryWithoutParams($"INSERT INTO ing_xmlTimbradosConceptos(Clave_Cliente, XMLID, Nombre_Concepto, IDConcepto, Clave_Concepto, ClaveUnidad, ClaveProdServ, PrecioUnitario, IVA, Descuento, Cantidad, Total, Nota) VALUES ('{item.Matricula}', {IDXML}, '{item.NombreConcepto}', {item.IDConcepto}, {IDClave}, '{item.cveUnidad}', '{item.cveClase}', {Format(CDec(item.costoUnitario), "#####0.00")}, {Format(CDec(item.costoIVAUnitario), "#####0.00")}, {Format(CDec(item.descuento), "#####0.00")}, {item.Cantidad}, {Format(CDec(((item.costoTotal - item.descuento) + item.costoIVATotal)), "#####0.00")}, 0)")
            Next
            db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Usuario = '{User.getUsername()}'")


            MessageBox.Show("Pago registrado correctamente")
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
            Me.gernerarQr(QR, $"{Serie}{Folio}")
            rep.AgregarFuente("FacturaEDC.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("ClaveCliente", Matricula)
            rep.AgregarParametros("CantidadLetra", TotalText)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.AgregarParametros("TipoCliente", tipoMatricula)
            rep.AgregarParametros("NombreEvento", NombreEvento)
            rep.AgregarParametros("RFC", RFCCLiente)


            ObjectBagService.setItem("CantidadLetra", TotalText)
            ObjectBagService.setItem("Serie", Serie)
            ObjectBagService.setItem("usoCFDI", descripcionCFDI)
            ObjectBagService.setItem("Folio", Folio)
            ObjectBagService.setItem("RFC", RFCCLiente)
            ObjectBagService.setItem("FolioF", folioFiscal)
            ObjectBagService.setItem("tipoCliente", tipoMatricula)
            ObjectBagService.setItem("NombreEvento", NombreEvento)
            rep.MostrarReporte()
            db.commitTransaction()
            Return IDXML
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
            CobrosEDC.Reiniciar()
        End Try

    End Function

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------CALCULA TOTAL A PAGAR-----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Function calcularTotal(costoUnitario As Decimal, cantidad As Integer, consideraIVA As Boolean, agregaIVA As Boolean, exentaIVA As Boolean) As String
        Dim total As Decimal
        Dim IVA As Decimal
        Dim costosiniva As Decimal

        If (consideraIVA = True And agregaIVA = False And exentaIVA = False) Then
            total = costoUnitario * cantidad
        ElseIf (consideraIVA = False And agregaIVA = True And exentaIVA = False) Then
            IVA = costoUnitario * 0.16
            total = (costoUnitario + IVA) * cantidad
        ElseIf (consideraIVA = False And agregaIVA = False And exentaIVA = True) Then
            total = costoUnitario * cantidad
        End If

        Return Format(CDec(total), "#####0.00")
    End Function

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''---------------------------------------------------EXTRAE CADENA ENTRE 2 CARACTERES-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Public Function Extrae_Cadena(ByVal texto As String, ByVal limite_inicio As String, ByVal limite_fin As String)
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        Dim referencias_nodo As String = ""
        posicion1 = InStr(texto, limite_inicio)
        posicion2 = InStrRev(texto, limite_fin)
        referencias_nodo = texto.Substring(posicion1, posicion2 - 1 - posicion1)
        Return referencias_nodo
    End Function

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------OBTIENE FOLIO DE PAGO-----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Public Function obtenerFolio(Tipo As String) As String
        Dim Serie As String
        Dim Consecutivo As Integer
        If (Tipo = "Pago") Then
            Serie = db.exectSQLQueryScalar($"SELECT Folio FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}' AND Descripcion = 'ING'")
            Consecutivo = db.exectSQLQueryScalar($"SELECT Consecutivo + 1 FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}' AND Descripcion = 'ING'")
        ElseIf (Tipo = "Abono") Then
            Serie = db.exectSQLQueryScalar($"SELECT Folio FROM ing_CatFolios WHERE Usuario = 'Abonos' AND Descripcion = 'ABONOS'")
            Consecutivo = db.exectSQLQueryScalar($"SELECT Consecutivo + 1 FROM ing_CatFolios WHERE Usuario = 'Abonos' AND Descripcion = 'ABONOS'")
        End If

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
            ''img.Save($"\\{EnviromentService.serverIP}\Reportes\NEDC\QR\{Nombre}.png", Imaging.ImageFormat.Png)
            img.Save($"{EnviromentService.reportesPath}\QR\{Nombre}.png", Imaging.ImageFormat.Png)
            Thread.Sleep(1500)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''----------------------------------------------------CALCULA NUEVO COSTO CON ABONO-------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub recalcularCostoAbono(concepto As Concepto, montoAbono As Decimal, tipoPago As Integer)
        If (concepto.absorbeIVA = True And concepto.IVAExento = False And concepto.consideraIVA = False) Then ''---ABSORBE IVA
            Dim costoSinIVA As Decimal = montoAbono / 1.16
            Dim costoIVA As Decimal = montoAbono - costoSinIVA
            Dim descuento As Decimal = concepto.descuento

            concepto.costoBase = costoSinIVA
            concepto.costoUnitario = costoSinIVA
            concepto.costoTotal = costoSinIVA * concepto.Cantidad
            concepto.costoIVATotal = costoIVA * concepto.Cantidad
            concepto.costoIVAUnitario = costoIVA
            concepto.descuento = 0.00000000
            concepto.costoFinal = costoSinIVA * concepto.Cantidad
            concepto.CostoIvaBase = concepto.costoTotal
            If (tipoPago = 2) Then
                concepto.costoBase = costoSinIVA
                concepto.costoUnitario = costoSinIVA + descuento
                concepto.costoTotal = costoSinIVA + descuento
                concepto.descuento = descuento
            End If
            ch.formatoPrecios(concepto)
        ElseIf (concepto.absorbeIVA = False And concepto.IVAExento = False And concepto.consideraIVA = True) Then ''---AGREGA IVA
            Dim costoSinIVA As Decimal = montoAbono / 1.16
            Dim costoIVA As Decimal = montoAbono - costoSinIVA
            Dim descuento As Decimal = concepto.descuento

            concepto.costoBase = costoSinIVA
            concepto.costoUnitario = costoSinIVA
            concepto.costoTotal = costoSinIVA * concepto.Cantidad
            concepto.costoIVATotal = costoIVA * concepto.Cantidad
            concepto.costoIVAUnitario = costoIVA
            concepto.descuento = 0.00000000
            concepto.costoFinal = costoSinIVA * concepto.Cantidad
            If (tipoPago = 2) Then
                concepto.costoBase = costoSinIVA
                concepto.costoUnitario = costoSinIVA + descuento
                concepto.costoTotal = (costoSinIVA + descuento) * concepto.Cantidad
                concepto.costoFinal = (costoSinIVA + concepto.costoIVAUnitario) * concepto.Cantidad
                concepto.descuento = descuento
            End If
            ch.formatoPrecios(concepto)
        ElseIf ((concepto.absorbeIVA = False And concepto.IVAExento = True And concepto.consideraIVA = False) Or (concepto.absorbeIVA = False And concepto.IVAExento = False And concepto.consideraIVA = False)) Then ''---IVA EXENTO
            Dim descuento As Decimal = concepto.descuento
            concepto.costoBase = montoAbono
            concepto.costoUnitario = montoAbono
            concepto.costoTotal = montoAbono
            concepto.descuento = 0.00000000
            concepto.costoFinal = montoAbono
            concepto.CostoIvaBase = concepto.costoTotal
            If (tipoPago = 2) Then
                concepto.costoBase = montoAbono
                concepto.costoUnitario = montoAbono + descuento
                concepto.costoTotal = montoAbono + descuento
                concepto.costoFinal = montoAbono + descuento
                concepto.descuento = descuento
            End If
            ch.formatoPrecios(concepto)
        End If
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''---------------------------------------------------REORGANIZA LISTA DE PAGOS CON ABONO--------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Function calcularAbonos(listaConceptos As List(Of Concepto), montoIngresado As Decimal, montoTotal As Decimal, Matricula As String) As List(Of Concepto)
        Dim montoRestante = montoIngresado
        Dim listaCongresos As New List(Of Concepto)
        Dim listaPagosOpcionales As New List(Of Concepto)
        Dim listaColegiaturas As New List(Of Concepto)
        Dim listaRecargos As New List(Of Concepto)

        listaConceptos = Me.ordenarListaConceptos(listaConceptos, Matricula)

        Dim listaConceptosFinal As New List(Of Concepto)
        Dim listaConceptosCobrar As New List(Of Concepto)
        Dim listaConceptosAbonos As New List(Of Concepto)
        Dim listaConceptosRechazados As New List(Of Concepto)
        Dim band As Boolean = False
        Dim band2 As Boolean = False
        Dim montoAnterior As Decimal

        For Each concepto As Concepto In listaConceptos
            If (band = True) Then
                listaConceptosRechazados.Add(concepto)
            End If
            If ((montoRestante - concepto.costoFinal >= 0) And band = False) Then
                montoRestante = montoRestante - concepto.costoFinal
                listaConceptosCobrar.Add(concepto)

            ElseIf ((montoRestante - concepto.costoFinal < 0) And band = False) Then
                band = True
                listaConceptosRechazados.Add(concepto)
            End If
        Next
        listaConceptos.Clear()
        If (listaConceptosRechazados.Count > 0) Then
            For Each concepto As Concepto In listaConceptosRechazados
                If ((concepto.costoFinal <= montoRestante) And (montoRestante - concepto.costoFinal >= 0) And (concepto.claveConcepto <> "REC")) Then
                    listaConceptosCobrar.Add(concepto)
                    montoRestante = montoRestante - concepto.costoFinal
                Else
                    listaConceptos.Add(concepto)
                End If
            Next
            listaConceptosRechazados.Clear()
            If (listaConceptos.Count > 0) Then
                listaConceptosAbonos.Add(listaConceptos(0))
                montoAnterior = listaConceptos(0).costoFinal
                Me.recalcularCostoAbono(listaConceptos(0), montoRestante, 1)
            End If
        End If

        For Each concepto As Concepto In listaConceptosCobrar
            listaConceptosRechazados.RemoveAll(Function(x) x.IDConcepto = concepto.IDConcepto And x.NombreConcepto = concepto.NombreConcepto And x.claveConcepto = concepto.claveConcepto)
        Next

        For Each concepto As Concepto In listaConceptosAbonos
            listaConceptosRechazados.RemoveAll(Function(x) x.IDConcepto = concepto.IDConcepto And x.NombreConcepto = concepto.NombreConcepto And x.claveConcepto = concepto.claveConcepto)
        Next

        Dim mensaje As String = "Se abonarán los siguientes conceptos: " + vbNewLine
        mensaje += vbNewLine
        For Each concepto As Concepto In listaConceptosAbonos
            mensaje += $"{concepto.NombreConcepto} - ABONO: ${CDec(CDec(concepto.costoFinal) + CDec(concepto.costoIVATotal))}" + vbNewLine
        Next
        MessageBox.Show(mensaje)
        For Each concepto As Concepto In listaConceptosCobrar
            Dim IDClavePago As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE Clave = '{concepto.claveConcepto}'")
            Dim tieneAbono As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_Abonos WHERE ID_ClavePago = {IDClavePago} AND IDPago = {concepto.IDConcepto}")
            If (tieneAbono > 0) Then
                Me.recalcularCostoAbono(concepto, concepto.costoFinal, 2)
            End If
            concepto.Abonado = True
            listaConceptosFinal.Add(concepto)
        Next
        If (listaConceptosAbonos.Count > 0) Then
            For Each concepto As Concepto In listaConceptosAbonos
                If (concepto.Abonado = False) Then
                    concepto.Abonado = True
                    listaConceptos(0).NombreConcepto = $"1{concepto.NombreConcepto}"
                End If
            Next
        End If
        ObjectBagService.setItem("ListaAbonos", listaConceptosAbonos)
        ObjectBagService.setItem("MontoAnterior", montoAnterior)
        ObjectBagService.setItem("MontoRestante", montoRestante)

        Return listaConceptosFinal
        Return listaConceptosFinal
    End Function

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------ORDENA LISTA DE CONCEPTOS CON ABONO----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Function ordenarListaConceptos(listaConceptos As List(Of Concepto), Matricula As String) As List(Of Concepto)
        Dim listaCongresos As New List(Of Concepto)
        Dim listaPagosOpcionales As New List(Of Concepto)
        Dim listaColegiaturas As New List(Of Concepto)
        Dim listaRecargos As New List(Of Concepto)

        ''--------------DIVIDE LISTA PRINCIPAL EN DIFERENTES LISTAS SEGUN EL CONCEPTO
        For Each concepto As Concepto In listaConceptos
            If (concepto.claveConcepto = "POA" Or concepto.claveConcepto = "POE" Or concepto.claveConcepto = "POC") Then
                listaPagosOpcionales.Add(concepto)
            ElseIf (concepto.claveConcepto = "CON") Then
                listaCongresos.Add(concepto)
            ElseIf (concepto.claveConcepto = "DCO" Or concepto.claveConcepto = "DIN" Or concepto.claveConcepto = "DPU") Then
                listaColegiaturas.Add(concepto)
            ElseIf (concepto.claveConcepto = "REC") Then
                listaRecargos.Add(concepto)
            End If
        Next

        ''--------------ORDENA CADA LISTA SEGUN ID
        listaCongresos = listaCongresos.OrderBy(Function(x) x.IDConcepto).ToList()
        listaPagosOpcionales = listaPagosOpcionales.OrderBy(Function(x) x.IDConcepto).ToList()
        listaColegiaturas = listaColegiaturas.OrderBy(Function(x) x.IDConcepto).ToList()
        listaRecargos = listaRecargos.OrderBy(Function(x) x.IDConcepto).ToList()

        listaConceptos.Clear()

        ''--------------LLENA LISTA CON CONCEPTOS YA ORDENADOS Y POR LISTA DE IMPORTANCIA
        For Each concepto As Concepto In listaCongresos
            listaConceptos.Add(concepto)
        Next

        For Each concepto As Concepto In listaPagosOpcionales
            listaConceptos.Add(concepto)
        Next

        For Each concepto As Concepto In listaColegiaturas
            Dim conceptoRecargo As New Concepto
            Dim tieneRecargo As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_PlanesRecargos WHERE ID_Concepto = {concepto.IDConcepto} AND Activo = 1")

            If (tieneRecargo > 0) Then
                conceptoRecargo = ch.crearConcepto(tieneRecargo, "REC", Matricula)
                listaRecargos.RemoveAll(Function(x) x.IDConcepto = conceptoRecargo.IDConcepto And x.NombreConcepto = conceptoRecargo.NombreConcepto)
                listaConceptos.Add(concepto)
                listaConceptos.Add(conceptoRecargo)
            Else
                listaConceptos.Add(concepto)
            End If
        Next

        For Each concepto As Concepto In listaRecargos
            listaConceptos.Add(concepto)
        Next
        ''--------------DEVUELVE LISTA ORDENADA SEGUN LA IMPORTANCIA DEL CONCEPTO Y POR ID
        Return listaConceptos
    End Function

    Function quitaTildesEspecial(limpia As String) As String
        Dim wea As String = """"
        wea = wea.Substring(0, 1)
        If Not IsNothing(limpia) Then
            limpia = Replace(limpia, "¡", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, "¿", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, "'", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, "á", "a", 1, Len(limpia), 1)
            limpia = Replace(limpia, "é", "e", 1, Len(limpia), 1)
            limpia = Replace(limpia, "í", "i", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ó", "o", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ú", "u", 1, Len(limpia), 1)
            ''limpia = Replace(limpia, "ñ", "n", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ç", "c", 1, Len(limpia), 1)

            limpia = Replace(limpia, "Á", "A", 1, Len(limpia), 1)
            limpia = Replace(limpia, "É", "E", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Í", "I", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ó", "O", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ú", "U", 1, Len(limpia), 1)
            ''limpia = Replace(limpia, "Ñ", "N", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ç", "C", 1, Len(limpia), 1)

            limpia = Replace(limpia, "à", "a", 1, Len(limpia), 1)
            limpia = Replace(limpia, "è", "e", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ì", "i", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ò", "o", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ù", "u", 1, Len(limpia), 1)

            limpia = Replace(limpia, "À", "A", 1, Len(limpia), 1)
            limpia = Replace(limpia, "È", "E", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ì", "I", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ò", "O", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ù", "U", 1, Len(limpia), 1)

            limpia = Replace(limpia, "ä", "a", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ë", "e", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ï", "i", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ö", "o", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ü", "u", 1, Len(limpia), 1)

            limpia = Replace(limpia, "Ä", "A", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ë", "E", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ï", "I", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ö", "O", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ü", "U", 1, Len(limpia), 1)

            limpia = Replace(limpia, "â", "a", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ê", "e", 1, Len(limpia), 1)
            limpia = Replace(limpia, "î", "i", 1, Len(limpia), 1)
            limpia = Replace(limpia, "ô", "o", 1, Len(limpia), 1)
            limpia = Replace(limpia, "û", "u", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Â", "A", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ê", "E", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Î", "I", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Ô", "O", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Û", "U", 1, Len(limpia), 1)
            limpia = Replace(limpia, "Nº", "Numero", 1, Len(limpia), 1)
            limpia = Replace(limpia, "/", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, "(", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, ")", "", 1, Len(limpia), 1)
            'limpia = Replace(limpia, "-", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, "$", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, ":", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, "°", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, "´", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, "#", "", 1, Len(limpia), 1)
            limpia = Replace(limpia, wea, "", 1, Len(limpia), 1)
        Else
            limpia = ""
        End If

        quitaTildesEspecial = Trim((UCase(limpia)))
    End Function
End Class