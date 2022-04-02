Imports System.Text.RegularExpressions

Public Class PagosCreditoEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim pc As PagosCreditoController = New PagosCreditoController()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim combo_filtro As String
    Private Sub PagosCreditoEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
        '                                                    INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
        '                                                    ORDER BY NombreCliente")
        'Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
        '                                                         INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
        '                                                         INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
        '                                                         ORDER BY C.nombre")

        'tableExternos.Merge(tableEDC)
        'ComboboxService.llenarCombobox(cbExterno, tableExternos, "clave_cliente", "NombreCliente")
        Dim tableFormaPago As DataTable = db.getDataTableFromSQL("SELECT Forma_Pago, Descripcion FROM ing_CatFormaPago WHERE Descripcion != 'CREDITO'")
        ComboboxService.llenarComboboxVacio(cbFormaPago, tableFormaPago, "Forma_Pago", "Descripcion")
        Dim tablebancos As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre_Banco FROM ing_Cat_Bancos")
        ComboboxService.llenarComboboxVacio(cbBanco, tablebancos, "ID", "Nombre_Banco")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        lblMatriculatxt.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelCobroCredito, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelCobroCredito, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCPtxt, lblRegFiscaltxt, lblCFDItxt)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelCobroCredito, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCPtxt, lblRegFiscaltxt, lblCFDItxt)
        End If
        Dim tableFacturasCredito As DataTable = db.getDataTableFromSQL($"SELECT ID, UPPER('FOLIO: ' + Folio + ' - FECHA: ' + CAST(Fecha AS VARCHAR(MAX))) As Descripcion FROM ing_Creditos WHERE Matricula = '{Matricula}' AND Activo = 1")
        ComboboxService.llenarCombobox(cbFactura, tableFacturasCredito, "ID", "Descripcion")
    End Sub

    Private Sub cbFactura_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbFactura.SelectionChangeCommitted
        gridConceptosFactura.Rows.Clear()
        Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT C.IDConcepto, C.Clave_Concepto, CP.Clave, C.Nombre_Concepto, C.Total FROM ing_xmlTimbradosConceptos AS C
                                                                   INNER JOIN ing_xmlTimbrados AS T ON T.ID = C.XMLID
                                                                   INNER JOIN ing_Creditos AS CR ON CR.Folio = T.Folio AND CR.FolioFiscal = T.FolioFiscal
                                                                   INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = C.Clave_Concepto
                                                                   WHERE CR.ID = {cbFactura.SelectedValue}")
        For Each row As DataRow In tableConceptos.Rows
            gridConceptosFactura.Rows.Add(row("IDConcepto"), row("Clave_Concepto"), row("Clave"), row("Nombre_Concepto"), row("Total"))
        Next
    End Sub

    Private Sub cbBanco_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbBanco.SelectionChangeCommitted
        Dim tableTipoPAgo As DataTable = db.getDataTableFromSQL($"SELECT ID, Tipo_Pago FROM ing_cat_tipoFormaPago WHERE ID_TipoPago = (SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = {cbFormaPago.SelectedValue} AND Descripcion = '{cbFormaPago.Text}')")
        ComboboxService.llenarCombobox(cbTipoBanco, tableTipoPAgo, "ID", "Tipo_Pago")
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If (gridConceptosFactura.Rows.Count = 0) Then
            MessageBox.Show("Seleccione una factura a agregar")
            Exit Sub
        End If

        If (GridFacturaSeleccionada.Rows.Count > 0) Then
            GridFacturaSeleccionada.Rows.Clear()
            GridFacturaPagos.Rows.Clear()
            lblTotal.Text = ""
        End If
        Dim IDFactura As Integer = cbFactura.SelectedValue
        Dim tableInfoPagos As DataTable = db.getDataTableFromSQL($"SELECT ID, Folio, Fecha, Cantidad, Cantidad_Abonada, NumAbonos FROM ing_Creditos WHERE ID = {IDFactura}")
        Dim tableHistorialPagos As DataTable = db.getDataTableFromSQL($"SELECT Folio, NumPago, Monto_Anterior, Monto_Abonado, Monto_Actual FROM ing_PagosCredito WHERE ID_Credito = {IDFactura}")
        For Each row As DataRow In tableInfoPagos.Rows
            GridFacturaSeleccionada.Rows.Add(row("ID"), row("Folio"), row("Fecha"), Format(CDec(row("Cantidad")), "#####0.00"), Format(CDec(row("Cantidad_Abonada")), "#####0.00"), row("NumAbonos"))
        Next

        For Each row As DataRow In tableHistorialPagos.Rows
            GridFacturaPagos.Rows.Add(row("Folio"), row("NumPago"), Format(CDec(row("Monto_Anterior")), "#####0.00"), Format(CDec(row("Monto_Abonado")), "#####0.00"), Format(CDec(row("Monto_Actual")), "#####0.00"))
        Next

        Dim noPago As Integer = Convert.ToInt32(GridFacturaSeleccionada.Rows(0).Cells(5).Value) + 1
        Dim rowCount As Integer = GridFacturaPagos.Rows.Count - 1
        Dim IDCredito As Integer = GridFacturaSeleccionada.Rows(0).Cells(0).Value
        If (noPago = 1) Then
            lblTotal.Text = db.exectSQLQueryScalar($"SELECT Cantidad FROM ing_Creditos WHERE ID = {IDCredito}")
        Else
            lblTotal.Text = CDec(GridFacturaPagos.Rows(rowCount).Cells(4).Value)
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        PagosCreditoEDC_Load(Me, Nothing)
        txtMatricula.Focus()
    End Sub

    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        If (CDec(txtMonto.Text) > CDec(lblTotal.Text)) Then
            MessageBox.Show("No puede ingresar un monto superior al total del pago")
            Exit Sub
        End If
        ''---------------------------------------------------------VALIDA FORMA DE PAGO---------------------------------------------------------
        If (cbFormaPago.Text = "TARJETA DE CREDITO" Or cbFormaPago.Text = "TARJETA DE DEBITO") Then
            If (cbBanco.Text = "") Then
                MessageBox.Show("Ingrese un banco")
                Exit Sub
            ElseIf (cbTipoBanco.Text = "") Then
                MessageBox.Show("Ingrese el tipo de pago (Ventanilla/Domiciliacion)")
                Exit Sub
            ElseIf (txtUltimos4Digitos.TextLength < 4) Then
                MessageBox.Show("Ingrese los ultimos 4 digitos de la tarjeta")
                Exit Sub
            End If
        ElseIf (cbFormaPago.Text = "CHEQUE") Then
            If (cbBanco.Text = "") Then
                MessageBox.Show("Ingrese un banco")
                Exit Sub
            ElseIf (txtNoCuenta.Text = "") Then
                MessageBox.Show("Ingrese el numero de cuenta")
                Exit Sub
            ElseIf (txtNoCheque.Text = "") Then
                MessageBox.Show("Ingrese el numero del cheque")
                Exit Sub
            End If
        ElseIf (cbFormaPago.Text = "TRANSFERENCIA") Then
            If (cbBanco.Text = "") Then
                MessageBox.Show("Ingrese un banco")
                Exit Sub
            End If
        ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE" Or cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then
            If (cbBanco.Text = "") Then
                MessageBox.Show("Ingrese un banco")
                Exit Sub
            ElseIf (cbTipoBanco.Text = "") Then
                MessageBox.Show("Ingrese el tipo de pago (Efectivo/Otro)")
                Exit Sub
            End If
        End If

        Dim IDCredito As Integer = GridFacturaSeleccionada.Rows(0).Cells(0).Value
        Dim CantidadAbonada As Decimal = CDec(txtMonto.Text)
        Dim montoAnterior As Decimal
        Dim rowCount As Integer = GridFacturaPagos.Rows.Count - 1

        Dim noPago As Integer = Convert.ToInt32(GridFacturaSeleccionada.Rows(0).Cells(5).Value) + 1
        If (noPago = 1) Then
            montoAnterior = db.exectSQLQueryScalar($"SELECT Cantidad FROM ing_Creditos WHERE ID = {IDCredito}")
        Else
            montoAnterior = CDec(GridFacturaPagos.Rows(rowCount).Cells(4).Value)
        End If
        Dim montoNuevo As Decimal = montoAnterior - CantidadAbonada
        Dim folioFiscal As String = db.exectSQLQueryScalar($"SELECT FolioFiscal FROM ing_Creditos WHERE ID = {IDCredito}")
        Dim IDXML As Integer = pc.cobroCredito(IDCredito, CantidadAbonada, montoAnterior, montoNuevo, Matricula, noPago, lblRFCtxt.Text, lblNombretxt.Text, folioFiscal, noPago, cbFormaPago.SelectedValue, lblRegFiscaltxt.Text, lblCPtxt.Text)

        ''---------------------------------------------------------REGISTRO DE FORMA DE PAGO---------------------------------------------------------
        If (IDXML > 0) Then
            If (cbFormaPago.Text = "TARJETA DE CREDITO") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosTarjeta(ID_Factura, ID_Banco, ID_TipoPago, NumTarjeta, Monto, FechaPago, TipoTarjeta) VALUES({IDXML}, {cbBanco.SelectedValue}, {cbTipoBanco.SelectedValue}, '{txtUltimos4Digitos.Text}', {txtMonto.Text}, GETDATE(), 'C')")
            ElseIf (cbFormaPago.Text = "TARJETA DE DEBITO") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosTarjeta(ID_Factura, ID_Banco, ID_TipoPago, NumTarjeta, Monto, FechaPago, TipoTarjeta) VALUES({IDXML}, {cbBanco.SelectedValue}, {cbTipoBanco.SelectedValue}, '{txtUltimos4Digitos.Text}', {txtMonto.Text}, GETDATE(), 'D')")
            ElseIf (cbFormaPago.Text = "CHEQUE") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosCheques(ID_Factura, NoCuenta, NoCheque, Monto, FechaPago) VALUES({IDXML}, '{txtNoCuenta.Text}', '{txtNoCheque.Text}', {txtMonto.Text}, GETDATE())")
            ElseIf (cbFormaPago.Text = "TRANSFERENCIA") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosTransferencias(ID_Factura, ID_Banco, Monto, Fecha_Pago) VALUES ({IDXML}, {cbBanco.SelectedValue}, {txtMonto.Text}, '{DTPickerFecha.Text}')")
            ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDepositos(ID_Factura, ID_Banco, ID_TipoPago, Monto, TipoDeposito, FechaPago) VALUES({IDXML}, {cbBanco.SelectedValue}, {cbTipoBanco.SelectedValue}, {txtMonto.Text}, 'Comprobante', '{DTPickerFecha.Text}')")
            ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDepositos(ID_Factura, ID_Banco, ID_TipoPago, Monto, TipoDeposito, FechaPago) VALUES({IDXML}, {cbBanco.SelectedValue}, {cbTipoBanco.SelectedValue}, {txtMonto.Text}, 'Edo', '{DTPickerFecha.Text}')")
            End If
        End If

        Me.Reiniciar()
        Exit Sub
    End Sub

    Private Sub cbFormaPago_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbFormaPago.SelectionChangeCommitted
        cbTipoBanco.DataSource = Nothing
        If (cbFormaPago.Text = "EFECTIVO") Then ''EFECTIVO
            lblBanco.Visible = False
            lblTIpoBanco.Visible = False
            lblFecha.Visible = False
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            cbBanco.Visible = False
            cbTipoBanco.Visible = False
            DTPickerFecha.Visible = False
            txtNoCuenta.Visible = False
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            lblMonto.Visible = True
            txtMonto.Visible = True
        ElseIf (cbFormaPago.Text = "TARJETA DE CREDITO" Or cbFormaPago.Text = "TARJETA DE DEBITO") Then ''TARJETA DE CREDITO O DEBITO
            lblBanco.Visible = True
            lblTIpoBanco.Visible = True
            lblFecha.Visible = False
            lblUltimosDigitos.Visible = True
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            cbBanco.Visible = True
            cbTipoBanco.Visible = True
            DTPickerFecha.Visible = False
            txtUltimos4Digitos.Visible = True
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = True
            txtMonto.Visible = True
        ElseIf (cbFormaPago.Text = "CHEQUE") Then ''CHEQUE
            lblBanco.Visible = True
            lblTIpoBanco.Visible = False
            lblFecha.Visible = False
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = True
            lblNoCheque.Visible = True
            cbBanco.Visible = True
            cbTipoBanco.Visible = False
            DTPickerFecha.Visible = False
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = True
            txtNoCuenta.Visible = True
            lblMonto.Visible = True
            txtMonto.Visible = True
        ElseIf (cbFormaPago.Text = "TRANSFERENCIA") Then ''TRANSFERENCIA
            lblBanco.Visible = True
            lblTIpoBanco.Visible = False
            lblFecha.Visible = True
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            cbBanco.Visible = True
            cbTipoBanco.Visible = False
            DTPickerFecha.Visible = True
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = True
            txtMonto.Visible = True
        ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE" Or cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then ''DEPOSITO BANCARIO C/COMPROBANTE
            lblBanco.Visible = True
            lblTIpoBanco.Visible = True
            lblFecha.Visible = True
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            cbBanco.Visible = True
            cbTipoBanco.Visible = True
            DTPickerFecha.Visible = True
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = True
            txtMonto.Visible = True
        ElseIf (cbFormaPago.Text = "CREDITO") Then ''CREDITO
            lblBanco.Visible = False
            lblTIpoBanco.Visible = False
            lblFecha.Visible = False
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            cbBanco.Visible = False
            cbTipoBanco.Visible = False
            DTPickerFecha.Visible = False
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = False
            txtMonto.Visible = False
        ElseIf (cbFormaPago.Text = "NOTA DE CREDITO") Then ''NOTA DE CREDITO
            lblBanco.Visible = False
            lblTIpoBanco.Visible = False
            lblFecha.Visible = False
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            cbBanco.Visible = False
            cbTipoBanco.Visible = False
            DTPickerFecha.Visible = False
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = False
            txtMonto.Visible = False
        End If
    End Sub

    Private Sub controlCantidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress, txtUltimos4Digitos.KeyPress, txtNoCheque.KeyPress, txtNoCuenta.KeyPress
        Dim num_cantidad As Decimal = 0
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("0123456789.", Chr(KeyAscii)) = 0 Then
            If KeyAscii <> 8 Then
                KeyAscii = 0
            End If
            e.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        ElseIf InStr(txtMonto.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
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
            If (cbExterno.SelectedIndex <> -1) Then
                txtMatricula.Text = cbExterno.SelectedValue
                btnBuscar.PerformClick()
                txtMatricula.Clear()
                cbExterno.Text = ""
                combo_filtro = ""
            End If

        Catch ex As Exception

        End Try
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
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"(SELECT RC.clave_cliente, UPPER('Congreso: ' + C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                                INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
    											    WHERE (C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno LIKE '%{filtro}%'))

    											UNION
                                                                (SELECT CL.clave_cliente, UPPER('Externo: '+  C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
                                                                INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
    										     	WHERE (C.nombre + ' ' +E.paterno + ' ' +E.materno LIKE '%{filtro}%'))")
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
    End Sub
End Class