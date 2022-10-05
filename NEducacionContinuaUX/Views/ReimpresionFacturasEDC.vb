Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class ReimpresionFacturasEDC
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
    Dim Matricula As String
    Dim Folio As String
    Dim IDXML As Integer
    Dim re As ReimpresionFacturasController = New ReimpresionFacturasController()
    Dim db As DataBaseService = New DataBaseService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Dim repEmail As ImpresionReportesService = New ImpresionReportesService()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim es As UXServiceEmail = New UXServiceEmail()
    Dim c As CobrosController = New CobrosController
    Dim tipoMatricula As String
    Dim combo_filtro As String
    Private Sub ReimpresionFacturasEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbFactura_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbFactura.SelectionChangeCommitted
        GridConceptos.Rows.Clear()
        Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT Nombre_Concepto, Cantidad, PrecioUnitario, IVA, Descuento, Total FROM ing_xmlTimbradosConceptos WHERE XMLID = {cbFactura.SelectedValue}")
        For Each item As DataRow In tableConceptos.Rows
            GridConceptos.Rows.Add(item("Nombre_Concepto"), item("Cantidad"), Format(item("PrecioUnitario"), "#####0.00"), Format(item("IVA"), "#####0.00"), Format(item("Descuento"), "#####0.00"), Format(item("Total"), "#####0.00"))
        Next
        panelFactura.Visible = True
        IDXML = cbFactura.SelectedValue
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscarMatricula_Click(sender As Object, e As EventArgs) Handles btnBuscarMatricula.Click
        Matricula = txtMatricula.Text
        GridConceptos.Rows.Clear()
        tipoMatricula = re.validarMatricula(Matricula)
        Dim valida As Boolean = re.llenarComboboxFacturas(Matricula, cbFactura)
        If (valida = False) Then
            Me.Reiniciar()
        End If
    End Sub


    Private Sub btnBuscarFolio_Click(sender As Object, e As EventArgs) Handles btnBuscarFolio.Click
        Folio = txtFolio.Text
        IDXML = db.exectSQLQueryScalar($"SELECT ID FROM ing_xmlTimbrados WHERE Folio = '{Folio}'")
        Matricula = db.exectSQLQueryScalar($"SELECT Matricula_Clave FROM ing_xmlTimbrados WHERE Folio = '{Folio}'")
        If (IDXML <= 0) Then
            MessageBox.Show("El folio ingresado no existe, ingrese un folio valido")
        Else
            Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT Nombre_Concepto, Cantidad, PrecioUnitario, IVA, Descuento, Total FROM ing_xmlTimbradosConceptos WHERE XMLID = {IDXML}")
            For Each item As DataRow In tableConceptos.Rows
                GridConceptos.Rows.Add(item("Nombre_Concepto"), item("Cantidad"), Format(item("PrecioUnitario"), "#####0.00"), Format(item("IVA"), "#####0.00"), Format(item("Descuento"), "#####0.00"), Format(item("Total"), "#####0.00"))
            Next
            panelFactura.Visible = True
        End If
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        ReimpresionFacturasEDC_Load(Me, Nothing)
        txtMatricula.Focus()
    End Sub

    Private Sub btnReimprimir_Click(sender As Object, e As EventArgs) Handles btnReimprimir.Click
        If MsgBox("¿Desea generar el archivo .XML de esta factura?", MsgBoxStyle.YesNo, "Generar XML ") = vbYes Then
            Try
                Dim xml As String = db.exectSQLQueryScalar($"SELECT XMLTimbrado FROM ing_xmlTimbrados WHERE ID = {IDXML}")
                Dim saveFileDialog1 As New SaveFileDialog
                saveFileDialog1.InitialDirectory = "C:\"
                saveFileDialog1.Title = "Guardar archivo XML"
                saveFileDialog1.DefaultExt = "xml"
                saveFileDialog1.Filter = "XML files (*.xml)|"
                saveFileDialog1.FilterIndex = 2
                saveFileDialog1.RestoreDirectory = True
                saveFileDialog1.ShowDialog()
                Dim doc As XDocument = XDocument.Parse(xml)
                doc.Save(saveFileDialog1.FileName)
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error al guardar el archivo")
            End Try

        Else

        End If
        Dim folioFiscal As String = db.exectSQLQueryScalar($"SELECT FolioFiscal FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim folioEDC As String = db.exectSQLQueryScalar($"SELECT Folio FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim Total As Decimal = db.exectSQLQueryScalar($"SELECT Total FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim usoCFDI As String = db.exectSQLQueryScalar($"SELECT usoCFDI FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim Foliotxt As String = db.exectSQLQueryScalar($"SELECT Folio FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim Serie As String = Foliotxt.Substring(0, 1)
        Dim Folio As String = Foliotxt.Substring(1, Foliotxt.Length - 1)
        Dim tipoClienteint As Integer = ObjectBagService.getItem("tipoCliente")
        Dim NombreEvento As String = ObjectBagService.getItem("NombreEvento")
        Dim rfcTimbrar As String = db.exectSQLQueryScalar($"SELECT RFCTimbrado FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim tipoMatricula As String = re.validarMatricula(Matricula)
        Dim tipoPago As String = db.exectSQLQueryScalar($"SELECT Tipo_Pago FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim nombreReporte As String

        Dim tipoCliente As Integer
        Dim esEvento As Boolean
        If (tipoMatricula = "EX") Then
            tipoCliente = 2
        ElseIf (tipoMatricula = "EC") Then
            tipoCliente = 1
        End If

        Dim tableIDConceptos As DataTable = db.getDataTableFromSQL($"SELECT DISTINCT Clave_Concepto FROM ing_xmlTimbradosConceptos WHERE XMLID = {IDXML}")
        For Each item As DataRow In tableIDConceptos.Rows
            If (item("Clave_Concepto") = 3) Then
                esEvento = True
            End If
        Next

        Dim cantidadString As String
        Dim valores As String()
        If (InStr(Total, ".")) Then
            valores = Split(Total, ".")
            cantidadString = $"{Me.Num2Text(valores(0))} PESOS {valores(1)}/100 M.N"
        Else
            cantidadString = $"{Me.Num2Text(Total)} PESOS"
        End If

        If (esEvento = False) Then
            NombreEvento = "   "
        Else
            NombreEvento = db.exectSQLQueryScalar($"SELECT C.nombre FROM portal_registroCongreso AS RC
                                                        INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                        INNER JOIN portal_congreso AS C ON C.id_congreso = TA.id_congreso
                                                        WHERE RC.clave_cliente = '{Matricula}'")
        End If
        Dim descripcionCFDI As String = db.exectSQLQueryScalar($"select UPPER('(' + clave_usoCFDI + ')' + ' ' + descripcion) As Clave from ing_cat_usoCFDI WHERE clave_usoCFDI = '{usoCFDI}'")
        Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={rfcTimbrar}id={folioFiscal}tt={Total}"
        c.gernerarQr(QR, $"{Serie}{Folio}")
        If (tipoPago = "PAGO DE CREDITO") Then
            rep.AgregarFuente("FacturaEDCCredito.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("ClaveCliente", Matricula)
            rep.AgregarParametros("CantidadLetra", cantidadString)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.AgregarParametros("RFC", rfcTimbrar)
            rep.AgregarParametros("TipoCliente", tipoCliente)
        ElseIf (tipoPago = "COBRO DE CONCEPTO" Or tipoPago = "COBRO DE CONCEPTO A CREDITO") Then
            rep.AgregarFuente("FacturaEDC.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("ClaveCliente", Matricula)
            rep.AgregarParametros("CantidadLetra", cantidadString)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.AgregarParametros("TipoCliente", tipoCliente)
            rep.AgregarParametros("NombreEvento", NombreEvento)
            rep.AgregarParametros("RFC", rfcTimbrar)
        End If


        rep.MostrarReporte()
    End Sub

    Private Sub btnReenviar_Click(sender As Object, e As EventArgs) Handles btnReenviar.Click
        Dim folioFiscal As String = db.exectSQLQueryScalar($"SELECT FolioFiscal FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim folioEDC As String = db.exectSQLQueryScalar($"SELECT Folio FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim Total As Decimal = db.exectSQLQueryScalar($"SELECT Total FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim usoCFDI As String = db.exectSQLQueryScalar($"SELECT usoCFDI FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim Foliotxt As String = db.exectSQLQueryScalar($"SELECT Folio FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim Serie As String = Foliotxt.Substring(0, 1)
        Dim Folio As String = Foliotxt.Substring(1, Foliotxt.Length - 1)
        Dim tipoClienteint As Integer = ObjectBagService.getItem("tipoCliente")
        Dim NombreEvento As String = ObjectBagService.getItem("NombreEvento")
        Dim rfcTimbrar As String = db.exectSQLQueryScalar($"SELECT RFCTimbrado FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim tipoMatricula As String = re.validarMatricula(Matricula)
        Dim tipoPago As String = db.exectSQLQueryScalar($"SELECT Tipo_Pago FROM ing_xmlTimbrados WHERE ID = {IDXML}")
        Dim tipoCliente As Integer
        Dim esEvento As Boolean
        If (tipoMatricula = "EX") Then
            tipoCliente = 2
        ElseIf (tipoMatricula = "EC") Then
            tipoCliente = 1
        End If

        Dim tableIDConceptos As DataTable = db.getDataTableFromSQL($"SELECT DISTINCT Clave_Concepto FROM ing_xmlTimbradosConceptos WHERE XMLID = {IDXML}")
        For Each item As DataRow In tableIDConceptos.Rows
            If (item("Clave_Concepto") = 3) Then
                esEvento = True
            End If
        Next

        Dim cantidadString As String
        Dim valores As String()
        If (InStr(Total, ".")) Then
            valores = Split(Total, ".")
            cantidadString = $"{Me.Num2Text(valores(0))} PESOS {valores(1)}/100 M.N"
        Else
            cantidadString = $"{Me.Num2Text(Total)} PESOS"
        End If

        If (esEvento = False) Then
            NombreEvento = "   "
        Else
            NombreEvento = db.exectSQLQueryScalar($"SELECT C.nombre FROM portal_registroCongreso AS RC
                                                        INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                        INNER JOIN portal_congreso AS C ON C.id_congreso = TA.id_congreso
                                                        WHERE RC.clave_cliente = '{Matricula}'")
        End If
        Dim descripcionCFDI As String = db.exectSQLQueryScalar($"select UPPER('(' + clave_usoCFDI + ')' + ' ' + descripcion) As Clave from ing_cat_usoCFDI WHERE clave_usoCFDI = '{usoCFDI}'")
        Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={rfcTimbrar}id={folioFiscal}tt={Total}"
        c.gernerarQr(QR, $"{Serie}{Folio}")
        If (tipoPago = "PAGO DE CREDITO") Then
            rep.AgregarFuente("FacturaEDCCredito.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("ClaveCliente", Matricula)
            rep.AgregarParametros("CantidadLetra", cantidadString)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.AgregarParametros("RFC", rfcTimbrar)
            rep.AgregarParametros("TipoCliente", tipoCliente)
        ElseIf (tipoPago = "COBRO DE CONCEPTO" Or tipoPago = "COBRO DE CONCEPTO A CREDITO") Then
            rep.AgregarFuente("FacturaEDC.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("ClaveCliente", Matricula)
            rep.AgregarParametros("CantidadLetra", cantidadString)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.AgregarParametros("TipoCliente", tipoCliente)
            rep.AgregarParametros("NombreEvento", NombreEvento)
            rep.AgregarParametros("RFC", rfcTimbrar)
        End If

        Dim mail As New EmailModel
        Dim archivo_pdf As Byte() = Nothing
        Dim archivo_xml As Byte() = Nothing

        Dim xmlTimbrado As String = db.exectSQLQueryScalar($"SELECT XMLTimbrado FROM ing_xmlTimbrados WHERE ID = {IDXML}")


        archivo_pdf = rep.obtenerReporteByte()
        archivo_xml = Encoding.Default.GetBytes(xmlTimbrado)

        Dim emailCliente As String
        Dim destino As New List(Of String)
        If (tipoMatricula = "EX") Then
            emailCliente = db.exectSQLQueryScalar($"SELECT C.correo FROM portal_cliente AS C
                                                    INNER JOIN portal_registroExterno AS RC ON RC.id_cliente = C.id_cliente
                                                    WHERE RC.clave_cliente = '{Matricula}'")
        ElseIf (tipoMatricula = "EC") Then
            emailCliente = db.exectSQLQueryScalar($"SELECT C.correo FROM portal_cliente AS C
                                                    INNER JOIN portal_registroCongreso AS RC ON RC.id_cliente = C.id_cliente
                                                    WHERE RC.clave_cliente = '{Matricula}'")
        End If

        If MsgBox($"¿Desea usar este correo electrónico: {emailCliente} ?", MsgBoxStyle.YesNo, "Reenviar correo electrónico") = vbYes Then
            emailCliente = emailCliente
        Else
            emailCliente = InputBox("¿Cuál es el correo electrónico en donde se reenviarán la factura y el XML de este folio?", "Ingrese el correo electrónico")
        End If

        destino.Add(emailCliente)
        mail.Destino = destino
        mail.Asunto = "GRACIAS POR SU PAGO"
        mail.Mensaje = "ANEXAMOS TUS COMPROBANTES DE PAGO ADJUNTOS A ESTE CORREO, GRACIAS."
        mail.BytesFile = archivo_pdf
        mail.FileName = $"{folioEDC}.pdf"
        mail.BytesFile2 = archivo_xml
        mail.FileName2 = $"{folioEDC}.xml"
        Try
            es.sendEmailWithFileBytes(mail)
            MessageBox.Show("Correo enviado")
            Me.Reiniciar()
        Catch ex As Exception
            MessageBox.Show("Error al enviar email")
        End Try
    End Sub


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
            'img.Save($"\\{EnviromentService.serverIP}\Sistemas\Reportes\EducacionContinua\QR{Nombre}.png", Imaging.ImageFormat.Png)
            img.Save($"{EnviromentService.reportesPath}\QR\{Nombre}.png", Imaging.ImageFormat.Png)
            Thread.Sleep(1500)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
        txtMatricula.Text = Matricula
        btnBuscarMatricula.PerformClick()
    End Sub

    Private Sub LimpiaCaracteres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress, txtFolio.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbExterno_KeyUp(sender As Object, e As KeyEventArgs) Handles cbExterno.KeyUp
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            combo_filtro = cbExterno.Text
        End If
    End Sub

    Private Sub cbExterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbExterno.KeyPress
        Me.keypress_textos_cmb(cbExterno, e)
        Dim kc As KeysConverter = New KeysConverter()
        Dim encontrar As String = cbExterno.Text

        Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\´]", RegexOptions.IgnoreCase)
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If re.IsMatch(e.KeyChar) = False Then

            combo_filtro += kc.ConvertToString(e.KeyChar)
            Dim filtro As String = cbExterno.Text
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"SELECT clave_cliente, NombreCliente FROM
                                                                    ((SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
                                                                    INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                    INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente)
																    UNION

                                                                    (SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                                    INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente)) AS ALUMNOS WHERE NombreCliente LIKE '%{filtro}%'")
            ComboboxService.llenarCombobox(cbExterno, tableFiltro, "clave_cliente", "NombreCliente")
            cbExterno.SelectedValue = -1
            cbExterno.Text = combo_filtro
            cbExterno.DroppedDown = True
            cbExterno.SelectionStart = encontrar.Length
            cbExterno.SelectionLength = cbExterno.Text.Length - cbExterno.SelectionStart
        Else
            If Asc(e.KeyChar) = Keys.Space Then
                combo_filtro += " "
            End If
        End If
    End Sub

    Public Sub keypress_textos_cmb(ByVal TXT As ComboBox, ByVal e As KeyPressEventArgs)
        Try

            Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\:\´]", RegexOptions.IgnoreCase)
            Dim KeyAscii As Short = Asc(e.KeyChar)

            If KeyAscii <> 8 Then
                e.Handled = re.IsMatch(e.KeyChar)
            End If

        Catch ex As Exception
            MsgBox("Error: en la validación de este campo, por favor verifique o comuniquese con sistemas", MsgBoxStyle.Exclamation, "Error en datos")
        End Try

    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectionChangeCommitted
        Try
            txtMatricula.Text = cbExterno.SelectedValue
            btnBuscarMatricula.PerformClick()
            txtMatricula.Clear()
        Catch ex As Exception

        End Try
    End Sub
End Class