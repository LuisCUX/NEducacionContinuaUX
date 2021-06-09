Imports System.Text.RegularExpressions

Public Class MainCobrosDiferidosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim co As CobrosDiferidosController = New CobrosDiferidosController()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim listaConceptos As List(Of Concepto)
    Dim combo_filtro As String
    Dim combo_filtroEDC As String

    Private Sub MainCobrosDiferidosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableFormaPago As DataTable = db.getDataTableFromSQL("SELECT Forma_Pago, Descripcion FROM ing_CatFormaPago WHERE Descripcion != 'CREDITO'")
        ComboboxService.llenarCombobox(cbFormaPago, tableFormaPago, "Forma_Pago", "Descripcion")
        Dim tablebancos As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre_Banco FROM ing_Cat_Bancos")
        ComboboxService.llenarCombobox(cbBanco, tablebancos, "ID", "Nombre_Banco")
        'Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
        '                                                    INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
        '                                                    ORDER BY NombreCliente")
        'Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
        '                                                         INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
        '                                                         INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
        '                                                         ORDER BY C.nombre")
        'ComboboxService.llenarCombobox(cbEDC, tableEDC, "clave_cliente", "NombreCliente")
        'ComboboxService.llenarCombobox(cbExterno, tableExternos, "clave_cliente", "NombreCliente")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Limpiar()
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno, txtRFC)
        Else
            MessageBox.Show("Ingrese una matricula externa")
            txtMatricula.Clear()
            Exit Sub
        End If
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
        End If
    End Sub

    Private Sub cbBanco_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbBanco.SelectionChangeCommitted
        Dim tableTipoPAgo As DataTable = db.getDataTableFromSQL($"SELECT ID, Tipo_Pago FROM ing_cat_tipoFormaPago WHERE ID_TipoPago = (SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = {cbFormaPago.SelectedValue} AND Descripcion = '{cbFormaPago.Text}')")
        ComboboxService.llenarCombobox(cbTipoBanco, tableTipoPAgo, "ID", "Tipo_Pago")
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        MainCobrosDiferidosEDC_Load(Me, Nothing)
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress, txtBusquedaMatricula.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Sub Limpiar()
        txtNombre.Clear()
        txtEmail.Clear()
        lblTotal.Text = ""
        ch.limpiarListaConceptos()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        For x = 0 To GridConceptos.Rows.Count - 1
            If (GridConceptos.Rows(x).Cells(2).Value = txtBusquedaMatricula.Text) Then
                MessageBox.Show("La matricula ingresada ya se encuentra lista, ingrese una matricula diferente")
                Exit Sub
            End If
        Next
        Dim tipoMatriculaB As String = va.validarMatricula(txtBusquedaMatricula.Text)
        If (txtBusquedaMatricula.Text = "") Then
            MessageBox.Show("Por favor ingrese una matricula")
            Exit Sub
        ElseIf (tipoMatricula = "False") Then
            txtBusquedaMatricula.Clear()
            Exit Sub
        Else
            'ObjectBagService.setItem("Matricula", txtBusquedaMatricula.Text)
            'ObjectBagService.setItem("tipoMatricula", tipoMatriculaB)
            'ModalCobrosDiferidosEDC.MdiParent = PrincipalView
            'ModalCobrosDiferidosEDC.Show()
            Dim IDConcepto As Integer = co.buscarCongreso(txtBusquedaMatricula.Text)
            Me.actualizarTotal()
        End If
    End Sub

    Sub refreshGrid()
        GridConceptos.Rows.Clear()
        Dim listaConceptos As List(Of Concepto) = ch.getListaConceptos()
        For Each concepto As Concepto In listaConceptos
            GridConceptos.Rows.Add(concepto.IDConcepto, concepto.NombreConcepto, concepto.costoTotal)
        Next
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            Dim index As Integer
            index = GridConceptos.CurrentCell.RowIndex
            Dim matriculaBuscada As String = GridConceptos.Rows(index).Cells(2).Value
            Dim IDConcepto As Integer = GridConceptos.Rows(index).Cells(0).Value
            GridConceptos.Rows.RemoveAt(index)
            ch.eliminarconcepto(IDConcepto, "CON", matriculaBuscada)
            Me.actualizarTotal()
        Catch ex As Exception

        End Try
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

    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        Dim listaConceptos As List(Of Concepto) = Me.obtenerListaConceptos()
        If (listaConceptos.Count() = 0) Then
            MessageBox.Show("Ingrese al menos un concepto para poder cobrar")
            Return
        ElseIf (txtMonto.Text = "" Or txtMonto.Text = " ") Then
            MessageBox.Show("Ingrese el monto a pagar")
            Return
        End If

        If (CDec(lblTotal.Text) <> CDec(txtMonto.Text)) Then
            If (CDec(txtMonto.Text) > CDec(lblTotal.Text)) Then
                MessageBox.Show("No puede ingresar un monto mayor al total a pagar, ingrese un monto valido")
                Exit Sub
            Else
                MessageBox.Show("No puede ingresar un monto menor al total a pagar, ingrese un monto valido")
                Exit Sub
            End If
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

        Dim tipocliente As Integer
        If (tipoMatricula = "EX") Then
            tipocliente = 2
        ElseIf (tipoMatricula = "EC") Then
            tipocliente = 1
        End If
        Dim IDXML As Integer = co.Cobrar(listaConceptos, cbFormaPago.SelectedValue, txtRFC.Text, txtNombre.Text, txtMonto.Text, Matricula, False, tipocliente)


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
    End Sub

    Function obtenerListaConceptos() As List(Of Concepto)
        For x = 0 To GridConceptos.Rows.Count - 1
            ch.agregarconcepto(GridConceptos.Rows(x).Cells(0).Value, GridConceptos.Rows(x).Cells(1).Value, GridConceptos.Rows(x).Cells(2).Value)
        Next
        Return ch.getListaConceptos()
    End Function

    Sub actualizarTotal()
        Dim total As Decimal
        For x = 0 To GridConceptos.Rows.Count - 1
            total = total + GridConceptos.Rows(x).Cells(4).Value
        Next
        lblTotal.Text = Format(CDec(total), "#####0.00")
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

    Private Sub cbEDC_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbEDC.SelectionChangeCommitted
        Try
            If (cbEDC.SelectedIndex <> -1) Then
                txtBusquedaMatricula.Text = cbEDC.SelectedValue
                btnAgregar.PerformClick()
                txtBusquedaMatricula.Clear()
                cbEDC.Text = ""
                combo_filtroEDC = ""
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
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
		                                                         INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                 INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
                                                                 WHERE (C.nombre + ' ' + E.paterno + ' ' + E.materno) LIKE '%{filtro}%'")
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

    Private Sub cbEDC_KeyUp(sender As Object, e As KeyEventArgs) Handles cbEDC.KeyUp
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            combo_filtroEDC = cbEDC.Text
        End If
    End Sub

    Private Sub cbEDC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbEDC.KeyPress
        Me.keypress_textos_cmb(cbEDC, e)
        Dim kc As KeysConverter = New KeysConverter()
        Dim encontrar As String = cbEDC.Text

        Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\´]", RegexOptions.IgnoreCase)
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If re.IsMatch(e.KeyChar) = False Then

            combo_filtroEDC += kc.ConvertToString(e.KeyChar)
            Dim filtro As String = cbEDC.Text
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                             INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
                                                             WHERE (C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno) like '%{filtro}%'")
            ComboboxService.llenarCombobox(cbEDC, tableFiltro, "clave_cliente", "NombreCliente")
            cbEDC.SelectedValue = -1
            cbEDC.Text = combo_filtroEDC
            cbEDC.DroppedDown = True
            cbEDC.SelectionStart = encontrar.Length
            cbEDC.SelectionLength = cbEDC.Text.Length - cbEDC.SelectionStart
        Else
            If Asc(e.KeyChar) = Keys.Space Then
                combo_filtroEDC += " "
            End If
        End If
    End Sub
End Class