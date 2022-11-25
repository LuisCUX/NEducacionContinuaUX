Imports System.Text
Imports System.Text.RegularExpressions

Public Class CobrosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim co As CobrosController = New CobrosController()
    Dim ca As CargosController = New CargosController()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim es As UXServiceEmail = New UXServiceEmail()
    Dim combo_filtro As String
    Private Sub CobrosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim folioPago As String = co.obtenerFolio("Pago")
        lblFolio.Text = folioPago
        'Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
        '                                                    INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
        '                                                    ORDER BY NombreCliente")
        'Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
        '                                                         INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
        '                                                         INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
        '                                                         ORDER BY C.nombre")

        'tableExternos.Merge(tableEDC)
        'ComboboxService.llenarCombobox(cbExterno, tableExternos, "clave_cliente", "NombreCliente")
        Dim tableFormaPago As DataTable = db.getDataTableFromSQL("SELECT Forma_Pago, Descripcion FROM ing_CatFormaPago")
        ComboboxService.llenarComboboxVacio(cbFormaPago, tableFormaPago, "Forma_Pago", "Descripcion")
        Dim tablebancos As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre_Banco FROM ing_Cat_Bancos WHERE Activo = 1")
        ComboboxService.llenarComboboxVacio(cbBanco, tablebancos, "ID", "Nombre_Banco")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Limpiar()

        Matricula = txtMatricula.Text.ToUpper()
        tipoMatricula = va.validarMatricula(Matricula)
        If (tipoMatricula = "False") Then
            MessageBox.Show("La clave ingresada no existe o esta incorrecta, ingrese una clave valida")
            Me.Reiniciar()
            txtMatricula.Focus()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelCobros, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelCobros, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCPtxt, lblRegFiscaltxt, lblCFDItxt, lblDireccion)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelCobros, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCPtxt, lblRegFiscaltxt, lblCFDItxt, lblDireccion)
        End If
        ca.buscarPagosOpcionales(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarCongresos(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarColegiaturas(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarInscripcionesDiplomados(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarPagoUnicoDiplomados(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarRecargosDiplomados(Tree, Matricula, tipoMatricula, "Cobros")
        Tree.Nodes(0).Expand()
        Tree.Nodes(1).Expand()
        Tree.Nodes(2).Expand()
        Tree.Nodes(3).Expand()
        Tree.Nodes(4).Expand()
        Tree.Nodes(5).Expand()

        Dim notaCredito As Boolean = ca.buscarNotasCredito(Matricula)
        If (notaCredito = True) Then
            ObjectBagService.setItem("Matricula", Matricula)
            ModalNotasCreditoEDC.ShowDialog()
            If (ObjectBagService.getItem("NotaAgregada")) Then
                Me.Enabled = True
            Else
                Me.Reiniciar()
            End If
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
            lblBancotext.Visible = False
            txtBancotext.Visible = False
            DTPickerFecha.Visible = False
            txtNoCuenta.Visible = False
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            lblMonto.Visible = True
            txtMonto.Visible = True
            lblNotaAplicada.Visible = False
            txtNotaAplicada.Visible = False
            btnBuscarNota.Visible = False
        ElseIf (cbFormaPago.Text = "TARJETA DE CREDITO" Or cbFormaPago.Text = "TARJETA DE DEBITO") Then ''TARJETA DE CREDITO O DEBITO
            lblBanco.Visible = True
            lblTIpoBanco.Visible = True
            lblFecha.Visible = False
            lblUltimosDigitos.Visible = True
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            cbBanco.Visible = True
            cbTipoBanco.Visible = True
            lblBancotext.Visible = False
            txtBancotext.Visible = False
            DTPickerFecha.Visible = False
            txtUltimos4Digitos.Visible = True
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = True
            txtMonto.Visible = True
            lblNotaAplicada.Visible = False
            txtNotaAplicada.Visible = False
            btnBuscarNota.Visible = False
        ElseIf (cbFormaPago.Text = "CHEQUE") Then ''CHEQUE
            lblBanco.Visible = False
            lblTIpoBanco.Visible = False
            lblFecha.Visible = False
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = True
            lblNoCheque.Visible = True
            cbBanco.Visible = False
            cbTipoBanco.Visible = False
            lblBancotext.Visible = True
            txtBancotext.Visible = True
            DTPickerFecha.Visible = False
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = True
            txtNoCuenta.Visible = True
            lblMonto.Visible = True
            txtMonto.Visible = True
            lblNotaAplicada.Visible = False
            txtNotaAplicada.Visible = False
            btnBuscarNota.Visible = False
        ElseIf (cbFormaPago.Text = "TRANSFERENCIA") Then ''TRANSFERENCIA
            lblBanco.Visible = True
            lblTIpoBanco.Visible = False
            lblFecha.Visible = True
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            cbBanco.Visible = True
            lblBancotext.Visible = False
            txtBancotext.Visible = False
            cbTipoBanco.Visible = False
            DTPickerFecha.Visible = True
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = True
            txtMonto.Visible = True
            lblNotaAplicada.Visible = False
            txtNotaAplicada.Visible = False
            btnBuscarNota.Visible = False
        ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE" Or cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then ''DEPOSITO BANCARIO C/COMPROBANTE
            lblBanco.Visible = True
            lblTIpoBanco.Visible = True
            lblFecha.Visible = True
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            cbBanco.Visible = True
            lblBancotext.Visible = False
            txtBancotext.Visible = False
            cbTipoBanco.Visible = True
            DTPickerFecha.Visible = True
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = True
            txtMonto.Visible = True
            lblNotaAplicada.Visible = False
            txtNotaAplicada.Visible = False
            btnBuscarNota.Visible = False
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
            lblBancotext.Visible = False
            txtBancotext.Visible = False
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = False
            txtMonto.Visible = False
            lblNotaAplicada.Visible = False
            txtNotaAplicada.Visible = False
            btnBuscarNota.Visible = False
        ElseIf (cbFormaPago.Text = "NOTA DE CREDITO") Then ''NOTA DE CREDITO
            lblBanco.Visible = False
            lblTIpoBanco.Visible = False
            lblFecha.Visible = False
            lblUltimosDigitos.Visible = False
            lblNoCuenta.Visible = False
            lblNoCheque.Visible = False
            lblBancotext.Visible = False
            txtBancotext.Visible = False
            cbBanco.Visible = False
            cbTipoBanco.Visible = False
            DTPickerFecha.Visible = False
            txtUltimos4Digitos.Visible = False
            txtNoCheque.Visible = False
            txtNoCuenta.Visible = False
            lblMonto.Visible = False
            txtMonto.Visible = False
            lblNotaAplicada.Visible = True
            txtNotaAplicada.Visible = True
            btnBuscarNota.Visible = True
        End If
    End Sub

    Private Sub cbBanco_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbBanco.SelectionChangeCommitted
        If (cbFormaPago.Text = "TARJETA DE CREDITO" Or cbFormaPago.Text = "TARJETA DE DEBITO") Then
            Dim tableTipoPAgo As DataTable = db.getDataTableFromSQL($"SELECT T.ID, T.Nombre FROM ing_CatTipoTarjeta AS T
                                                                  INNER JOIN ing_res_BancoTarjeta AS B ON B.ID_TipoTarjeta = T.ID
                                                                  WHERE B.ID_Banco = {cbBanco.SelectedValue} AND B.Activo = 1")
            ComboboxService.llenarCombobox(cbTipoBanco, tableTipoPAgo, "ID", "Nombre")

        ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE" Or cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then
            Dim IDPago As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Descripcion = '{cbFormaPago.Text}'")
            Dim tableTipoPAgo As DataTable = db.getDataTableFromSQL($"SELECT ID, Tipo_Pago FROM ing_cat_tipoFormaPago WHERE ID_TipoPago = {IDPago}")
            ComboboxService.llenarCombobox(cbTipoBanco, tableTipoPAgo, "ID", "Tipo_Pago")
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        CobrosEDC_Load(Me, Nothing)
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Tree_DoubleClick(sender As Object, e As EventArgs) Handles Tree.DoubleClick
        Me.Nodos()
    End Sub

    Sub Nodos()
        If (Tree.SelectedNode Is Nothing) Then
            Exit Sub
        ElseIf (Tree.SelectedNode.Text) = "Eventos" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Pagos Opcionales" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Congresos" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Inscripción" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Colegiaturas" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Pago Unico" Then
            Exit Sub
        End If

        Dim tipoPago As String

        Try
            tipoPago = Tree.SelectedNode.Parent.Name()
        Catch ex As Exception
            Exit Sub
        End Try


        If (tipoPago = "nodeCongresos") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "CON", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(0).Nodes(index).SelectedImageIndex = 1
            Else
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.eliminarconcepto(conceptoID, "CON", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(0).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodePagosOpcionales") Then
            Dim tipoConcepto As String
            If (tipoMatricula = "UX") Then
                tipoConcepto = "POA"
            ElseIf (tipoMatricula = "EX") Then
                tipoConcepto = "POE"
            ElseIf (tipoMatricula = "EC") Then
                tipoConcepto = "POC"
            End If
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, tipoConcepto, Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(1).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.eliminarconcepto(conceptoID, tipoConcepto, Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(1).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodeInscripcionDip") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "DIN", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(2).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                For Each item As TreeNode In Tree.Nodes(3).Nodes
                    If (item.SelectedImageIndex = 1) Then
                        MessageBox.Show($"No puede pagar colegiaturas sin antes haber pagado el cargo de inscripción")
                        Exit Sub
                    End If
                Next
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.eliminarconcepto(conceptoID, "DIN", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(2).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodeColegiaturaDip") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                If (Tree.Nodes(2).Nodes.Count() > 0) Then
                    If (Tree.Nodes(2).Nodes.Count > 0 And Tree.Nodes(2).Nodes(0).SelectedImageIndex <> 1) Then
                        MessageBox.Show("No puede pagar colegiaturas sin antes haber pagado el cargo de inscripción")
                        Exit Sub
                    End If
                End If
                If (Me.validarSeleccionNodosColegiaturas(index, 1) = False) Then
                    ''Dim mesActual As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "-", "-")
                    MessageBox.Show($"No puede pagar la colegiatura sin antes haber pagado las colegiaturas anteriores")
                    Exit Sub
                End If
                'If (Me.buscarRecargoColegiaturas(conceptoID) = False) Then
                '    Dim mesActual As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "-", "-")
                '    MessageBox.Show($"No puede pagar la colegiatura del mes de {mesActual} sin antes haber pagado el recargo correspondiente")
                '    Exit Sub
                'End If
                Me.marcarRecargo(conceptoID, True)
                Tree.SelectedNode.Checked = True
                ch.agregarconcepto(conceptoID, "DCO", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(3).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                If (Me.validarSeleccionNodosColegiaturas(index, 2) = False) Then
                    ''Dim mesActual As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "-", "-")
                    MessageBox.Show($"No puede desmarcar el pago sin antes haber pagado las colegiaturas posteriores")
                    Exit Sub
                End If
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                Me.marcarRecargo(conceptoID, False)
                ch.eliminarconcepto(conceptoID, "DCO", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(3).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodePagoUnicoDip") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "DPU", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(4).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.eliminarconcepto(conceptoID, "DPU", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(4).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodeColegiaturasRec") Then
            'Dim index As Integer = Tree.SelectedNode.Index
            'If (Tree.SelectedNode.Checked = False) Then
            '    Tree.SelectedNode.Checked = True
            '    Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
            '    ch.agregarconcepto(conceptoID, "REC", Matricula)
            '    Me.actualizarTotal(ch.getListaConceptos())
            '    Tree.Nodes(5).Nodes(index).SelectedImageIndex = 1
            'ElseIf (Tree.SelectedNode.Checked = True) Then
            '    Dim recargoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
            '    If (Me.buscarConceptoConRecargo(recargoID) = False) Then
            '        MessageBox.Show("No puede cobrar conceptos sin antes haber pagado los recargos correspondientes")
            '        Exit Sub
            '    End If
            '    Tree.SelectedNode.Checked = False
            '    Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
            '    ch.eliminarconcepto(conceptoID, "REC", Matricula)
            '    Me.actualizarTotal(ch.getListaConceptos())
            '    Tree.Nodes(5).Nodes(index).SelectedImageIndex = 0
            'End If
        End If
        If (ch.getConceptosCount() < 1) Then
            panelTipoPago.Enabled = False
        Else
            panelTipoPago.Enabled = True
        End If
    End Sub

    Sub actualizarTotal(listaConceptos As List(Of Concepto))
        Dim Total As Decimal
        Total = 0.00
        For Each concepto As Concepto In listaConceptos
            Total = Total + CDec(concepto.costoFinal)
        Next
        lblTotal.Text = Total.ToString()
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

    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        Dim listaConceptos As New List(Of Concepto)
        Dim listaConceptosPrueba As New List(Of Concepto)
        Dim tipocliente As Integer
        Dim cobrarAbono As Boolean = False
        Dim creditoband As Boolean = False
        Dim formaPagoClave As String
        Dim formaPagoID As Integer
        Dim NombreTimbrar As String
        listaConceptos = ch.getListaConceptos()
        listaConceptosPrueba = ch.getListaConceptos()
        Dim listaconceptosFinal As New List(Of Concepto)
        If (listaConceptos.Count() = 0) Then
            MessageBox.Show("Ingrese al menos un concepto para poder cobrar")
            Return
        ElseIf ((txtMonto.Text = "" Or txtMonto.Text = " ") And (cbFormaPago.Text <> "CREDITO" And cbFormaPago.Text <> "NOTA DE CREDITO")) Then
            MessageBox.Show("Ingrese el monto a pagar")
            Return
        End If

        ''---------------------------------------------------------VALIDA FORMA DE PAGO---------------------------------------------------------
        If (cbFormaPago.Text = "") Then
            MessageBox.Show("Seleccione una forma de pago")
            Exit Sub
        ElseIf (cbFormaPago.Text = "TARJETA DE CREDITO" Or cbFormaPago.Text = "TARJETA DE DEBITO") Then
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
            If (txtBancotext.Text = "") Then
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
        ElseIf (cbFormaPago.Text = "CREDITO") Then
            creditoband = True
        End If

        If (creditoband = False) Then

            Dim montoTotal As Decimal = CDec(lblTotal.Text)
            Dim montoIngresado As Decimal = CDec(txtMonto.Text)
            If (montoTotal <> montoIngresado) Then
                If (montoIngresado > montoTotal) Then
                    If (cbFormaPago.Text = "EFECTIVO") Then
                        MessageBox.Show($"El cambio a entregar es de {Format(CDec(montoIngresado - montoTotal), "##0.00")} pesos.")
                    Else
                        MessageBox.Show("No puede ingresar un monto mayor al total a pagar, ingrese un monto valido")
                        Exit Sub
                    End If
                Else
                    listaconceptosFinal = co.calcularAbonos(listaConceptosPrueba, montoIngresado, montoTotal, Matricula)
                    cobrarAbono = True
                    If (IsNothing(listaconceptosFinal)) Then
                        Exit Sub
                    End If
                End If
            End If
            listaconceptosFinal = ch.getListaConceptos()
            For Each concepto As Concepto In listaconceptosFinal
                Dim IDClavePago As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE Clave = '{concepto.claveConcepto}'")
                Dim tieneAbono As Integer = db.exectSQLQueryScalar($"SELECT TOP 1 ID FROM ing_Abonos WHERE ID_ClavePago = {IDClavePago} AND IDPago = {concepto.IDConcepto} ORDER BY ID DESC")
                If (tieneAbono > 0) Then
                    Dim montoRestante As Decimal = db.exectSQLQueryScalar($"SELECT Cantidad_Restante FROM ing_Abonos WHERE ID = {tieneAbono}")
                    If (concepto.costoFinal = montoRestante) Then
                        If (concepto.absorbeIVA = False And concepto.IVAExento = False And concepto.consideraIVA = True) Then
                            co.recalcularCostoAbono(concepto, concepto.costoFinal, 2)
                        End If
                        Dim first As String = concepto.NombreConcepto.Substring(0, 1)
                        If (first = "1") Then
                            Dim x As String = concepto.NombreConcepto.Substring(1, concepto.NombreConcepto.Length() - 1)
                            concepto.NombreConcepto = $"2{x}"
                        Else
                            concepto.NombreConcepto = $"2{concepto.NombreConcepto}"
                        End If

                    Else
                        Dim first As String = concepto.NombreConcepto.Substring(0, 1)
                        If (first <> "1") Then
                            concepto.NombreConcepto = $"1{concepto.NombreConcepto}"
                        End If
                    End If
                    ''co.recalcularCostoAbono(concepto, concepto.costoFinal, 2)
                    ''concepto.NombreConcepto = $"2{concepto.NombreConcepto}"
                End If
            Next
            If (tipoMatricula = "EX") Then
                tipocliente = 2
            ElseIf (tipoMatricula = "EC") Then
                tipocliente = 1
            End If
        End If
        ''---------------------------------------------------------VALIDA DATOS FISCALES---------------------------------------------------------
        Dim RFCTimbrar As String
        Dim RegFiscalTimbrar As String
        Dim UsoCFDITimbrar As String
        Dim cpTimbrar As String
        Dim tablas As String()
        If (tipoMatricula = "EX") Then
            tablas = {"portal_registroExterno", "portal_reRFC"}
        ElseIf (tipoMatricula = "EC") Then
            tablas = {"portal_registroCongreso", "portal_rcRFC"}
        End If
        Dim IDRegistro As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM {tablas(0)} WHERE clave_cliente = '{Matricula}'")
        Dim RFCDefault As String = db.exectSQLQueryScalar($"SELECT RFC.rfc FROM portal_catRFC AS RFC
                                                           INNER JOIN {tablas(1)} AS RE ON RE.id_rfc = RFC.id_rfc AND RE.activo = 1 AND RE.id_registro = {IDRegistro}")
        Dim IDResRegCF As Integer = db.exectSQLQueryScalar($"SELECT id_res_cfdi_regimen FROM {tablas(1)} AS R
                                                            INNER JOIN portal_catRFC AS RFC ON R.id_rfc = RFC.id_rfc
                                                            WHERE RFC.rfc = '{RFCDefault}' AND R.activo = 1")
        If (IDResRegCF = 254 Or IDResRegCF = 0) Then
            Dim resulta As DialogResult = MessageBox.Show("La clave ingresada no tiene registrados regimen fiscal ni uso de CFDI, no se podrá cobrar con datos fiscales hasta que sean actualizados, ¿Desea continuar con el cobro sin datos fiscales?", "", MessageBoxButtons.YesNo)
            If (resulta <> 6) Then
                Exit Sub
            End If
        End If
        If (lblRFCtxt.Text <> "XAXX010101000" And IDResRegCF <> 254 And IDResRegCF <> 0) Then
            Dim result As DialogResult = MessageBox.Show("¿Quiere usar datos fiscales?", "", MessageBoxButtons.YesNo)
            If (result = 6) Then
                ObjectBagService.setItem("Matricula", Matricula)
                ModalDatosFiscalesCobrosEDC.ShowDialog()
                RFCTimbrar = ObjectBagService.getItem("RFCTimbrar")
                If (RFCTimbrar = "FALSE") Then
                    Exit Sub
                End If
                RegFiscalTimbrar = ObjectBagService.getItem("RegFiscalTimbrar")
                UsoCFDITimbrar = ObjectBagService.getItem("UsoCFDITimbrar")
                    NombreTimbrar = ObjectBagService.getItem("NombreTimbrar")
                    cpTimbrar = ObjectBagService.getItem("cpTimbrar")
                    ObjectBagService.clearBag()
                Else
                    RFCTimbrar = "XAXX010101000"
                RegFiscalTimbrar = "616"
                UsoCFDITimbrar = "S01"
                NombreTimbrar = lblNombretxt.Text
                cpTimbrar = EnviromentService.CP
            End If
        Else
            RFCTimbrar = "XAXX010101000"
            RegFiscalTimbrar = "616"
            UsoCFDITimbrar = "S01"
            NombreTimbrar = lblNombretxt.Text
            cpTimbrar = EnviromentService.CP
        End If
        If (creditoband = True) Then
            If (tipoMatricula = "EX") Then
                tipocliente = 2
            ElseIf (tipoMatricula = "EC") Then
                tipocliente = 1
            End If
            Dim IDXMLC As Integer = co.Cobrar(listaConceptosPrueba, cbFormaPago.SelectedValue, 9, Matricula, RFCTimbrar, NombreTimbrar, lblTotal.Text, True, tipocliente, lblCPtxt.Text, RegFiscalTimbrar, UsoCFDITimbrar)
            If (IDXMLC > 0) Then
                Me.Reiniciar()
                Exit Sub
            End If
        End If

        ''---------------------------------------------------------CLAVE DE FORMA DE PAGO---------------------------------------------------------
        If (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE" Or cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then
            If (cbTipoBanco.Text = "EFECTIVO") Then
                formaPagoClave = "01"
                If (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE") Then
                    formaPagoID = 7
                ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then
                    formaPagoID = 8
                End If
            ElseIf (cbTipoBanco.Text = "OTRO") Then
                formaPagoClave = "99"
                If (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE") Then
                    formaPagoID = 7
                ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then
                    formaPagoID = 8
                End If
            End If
        ElseIf (cbFormaPago.Text = "NOTA DE CREDITO") Then
            formaPagoClave = "99"
            formaPagoID = 10
        Else
            formaPagoClave = cbFormaPago.SelectedValue
            formaPagoID = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPagoClave}'")
        End If
        Dim IDXML As Integer = co.Cobrar(listaconceptosFinal, formaPagoClave, formaPagoID, Matricula, RFCTimbrar, NombreTimbrar, lblTotal.Text, False, tipocliente, cpTimbrar, RegFiscalTimbrar, UsoCFDITimbrar)

        ''---------------------------------------------------------REGISTRO DE FORMA DE PAGO---------------------------------------------------------
        If (IDXML > 0) Then
            If (cbFormaPago.Text = "TARJETA DE CREDITO") Then
                Dim IDRes As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_res_BancoTarjeta WHERE ID_Banco = {cbBanco.SelectedValue} AND ID_TipoTarjeta = {cbTipoBanco.SelectedValue}")
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosTarjeta(ID_Factura, ID_resBancoTarjeta, NumTarjeta, Monto, FechaPago, TipoTarjeta) VALUES({IDXML}, {IDRes}, '{txtUltimos4Digitos.Text}', {txtMonto.Text}, GETDATE(), 'C')")
            ElseIf (cbFormaPago.Text = "TARJETA DE DEBITO") Then
                Dim IDRes As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_res_BancoTarjeta WHERE ID_Banco = {cbBanco.SelectedValue} AND ID_TipoTarjeta = {cbTipoBanco.SelectedValue}")
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosTarjeta(ID_Factura, ID_resBancoTarjeta, NumTarjeta, Monto, FechaPago, TipoTarjeta) VALUES({IDXML}, {IDRes}, '{txtUltimos4Digitos.Text}', {txtMonto.Text}, GETDATE(), 'D')")
            ElseIf (cbFormaPago.Text = "CHEQUE") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosCheques(ID_Factura, NombreBanco, NoCuenta, NoCheque, Monto, FechaPago, Activo) VALUES({IDXML}, '{txtBancotext.Text}', '{txtNoCuenta.Text}', '{txtNoCheque.Text}', {txtMonto.Text}, GETDATE(), 1)")
            ElseIf (cbFormaPago.Text = "TRANSFERENCIA") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosTransferencias(ID_Factura, ID_Banco, Monto, Fecha_Pago) VALUES ({IDXML}, {cbBanco.SelectedValue}, {txtMonto.Text}, '{va.obtenerFechaString(DTPickerFecha)}')")
            ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDepositos(ID_Factura, ID_Banco, ID_TipoPago, Monto, TipoDeposito, FechaPago) VALUES({IDXML}, {cbBanco.SelectedValue}, {cbTipoBanco.SelectedValue}, {txtMonto.Text}, 'Comprobante', '{va.obtenerFechaString(DTPickerFecha)}')")
            ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDepositos(ID_Factura, ID_Banco, ID_TipoPago, Monto, TipoDeposito, FechaPago) VALUES({IDXML}, {cbBanco.SelectedValue}, {cbTipoBanco.SelectedValue}, {txtMonto.Text}, 'Edo', '{va.obtenerFechaString(DTPickerFecha)}')")
            ElseIf (cbFormaPago.Text = "NOTA DE CREDITO") Then
                db.execSQLQueryWithoutParams($"UPDATE ing_NotasCredito SET Aplicada = 1 WHERE FolioNota = '{txtNotaAplicada.Text}'")
                Dim IDNota As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_NotasCredito WHERE FolioNota = '{txtNotaAplicada.Text}'")
                db.execSQLQueryWithoutParams($"INSERT INTO ing_res_NotaCreditoXML(ID_NotaCredito, ID_XmlTimbrado) VALUES ({IDXML}, {IDNota})")
            End If
        End If

        If (cobrarAbono = True And IDXML > 0) Then
            Dim montoAnterior As Decimal = ObjectBagService.getItem("MontoAnterior")
            Dim montoRestante As Decimal = ObjectBagService.getItem("MontoRestante")
            Dim listaConceptosAbonos As New List(Of Concepto)
            listaConceptosAbonos = ObjectBagService.getItem("ListaAbonos")
            If (listaConceptosAbonos.Count > 0) Then
                For Each concepto As Concepto In listaConceptosAbonos
                    Dim montoDespues As Decimal
                    Dim IDClavePago As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE Clave = '{concepto.claveConcepto}'")
                    Dim tieneAbono As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_Abonos WHERE ID_ClavePago = {IDClavePago} AND IDPago = {concepto.IDConcepto} ORDER BY ID DESC")
                    If (tieneAbono > 0) Then
                        montoAnterior = db.exectSQLQueryScalar($"SELECT Cantidad_Restante FROM ing_Abonos WHERE ID = {tieneAbono}")
                        montoDespues = montoAnterior - montoRestante
                        concepto.Abonado = True
                    Else
                        montoDespues = montoAnterior - montoRestante
                        concepto.Abonado = True
                    End If
                    ''listaConceptos(0).NombreConcepto = $"1{concepto.NombreConcepto}"
                    Dim Folio As String = ObjectBagService.getItem("Folio")
                    Dim Serie As String = ObjectBagService.getItem("Serie")
                    db.execSQLQueryWithoutParams($"INSERT INTO ing_Abonos(Folio, Clave_Cliente, Cantidad_Anterior, Cantidad_Abonada, Cantidad_Restante, IDPago, ID_ClavePago, FechaAbono, Activo) VALUES ('{Serie}{Folio}', '{Matricula}', {montoAnterior}, {montoRestante}, {montoDespues}, {concepto.IDConcepto}, {IDClavePago}, GETDATE(), 1)")
                    listaconceptosFinal.Add(concepto)
                Next
                MessageBox.Show("Abono registrado correctamente")
            End If
        End If

        If (IDXML > 0) Then
            ''--------------------------------------------------------------ENVIO DE EMAIL--------------------------------------------------------------
            Dim Total As String = ObjectBagService.getItem("CantidadLetra")
            Dim usoCFDI As String = ObjectBagService.getItem("usoCFDI")
            Dim Serie As String = ObjectBagService.getItem("Serie")
            Dim Folio As String = ObjectBagService.getItem("Folio")
            Dim folioFiscal As String = ObjectBagService.getItem("FolioF")
            Dim tipoClienteint As Integer = ObjectBagService.getItem("tipoCliente")
            Dim NombreEvento As String = ObjectBagService.getItem("NombreEvento")
            ObjectBagService.clearBag()
            If (IsNothing(NombreEvento)) Then
                NombreEvento = "------"
            End If
            Dim rep2 As ImpresionReportesService = New ImpresionReportesService()

            Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={RFCTimbrar}id={folioFiscal}tt={Total}"
            co.gernerarQr(QR, $"{Serie}{Folio}")
            rep2.AgregarFuente("FacturaEDC.rpt")
            rep2.AgregarParametros("IDXML", IDXML)
            rep2.AgregarParametros("ClaveCliente", Matricula)
            rep2.AgregarParametros("CantidadLetra", Total)
            rep2.AgregarParametros("usoCFDI", usoCFDI)
            rep2.AgregarParametros("TipoCliente", tipocliente)
            rep2.AgregarParametros("NombreEvento", NombreEvento)
            rep2.AgregarParametros("RFC", RFCTimbrar)

            Dim mail As New EmailModel
            Dim archivo_pdf As Byte() = Nothing
            Dim archivo_xml As Byte() = Nothing

            Dim xmlTimbrado As String = db.exectSQLQueryScalar($"SELECT XMLTimbrado FROM ing_xmlTimbrados WHERE ID = {IDXML}")


            archivo_pdf = rep2.obtenerReporteByte()
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

            destino.Add(emailCliente)
            mail.Destino = destino
            mail.Asunto = "GRACIAS POR SU PAGO"
            mail.Mensaje = "ANEXAMOS TUS COMPROBANTES DE PAGO ADJUNTOS A ESTE CORREO, GRACIAS."
            mail.BytesFile = archivo_pdf
            mail.FileName = $"{Serie}{Folio}.pdf"
            mail.BytesFile2 = archivo_xml
            mail.FileName2 = $"{Serie}{Folio}.xml "
            Try
                es.sendEmailWithFileBytes(mail)
                Me.Reiniciar()
            Catch ex As Exception
                MessageBox.Show("Error al enviar email")
            End Try
        End If
        Me.Reiniciar()
    End Sub

    Function buscarRecargoColegiaturas(ID As Integer) As Boolean
        Dim IDRecargo As Integer
        Dim seleccionado As Boolean
        For Each item As TreeNode In Tree.Nodes(5).Nodes
            IDRecargo = co.Extrae_Cadena(item.ToString(), "[", "]")
            Dim idConceptoRecargo As Integer = db.exectSQLQueryScalar($"SELECT ID_Concepto FROM ing_PlanesRecargos WHERE ID = {IDRecargo}")
            Dim autorizado As Integer = db.exectSQLQueryScalar($"SELECT Autorizado FROM ing_AsignacionCargosPlanes WHERE ID = {idConceptoRecargo}")
            If (idConceptoRecargo = ID And item.SelectedImageIndex <> 1 And autorizado = False) Then
                item.Checked = True
                item.SelectedImageIndex = 1
            End If
        Next
        Return True
    End Function

    Sub marcarRecargo(ID As Integer, tipo As Boolean)
        Dim IDRecargo As Integer
        Dim seleccionado As Boolean
        For Each item As TreeNode In Tree.Nodes(5).Nodes
            IDRecargo = co.Extrae_Cadena(item.ToString(), "[", "]")
            Dim idConceptoRecargo As Integer = db.exectSQLQueryScalar($"SELECT ID_Concepto FROM ing_PlanesRecargos WHERE ID = {IDRecargo}")
            Dim autorizado As Integer = db.exectSQLQueryScalar($"SELECT Autorizado FROM ing_AsignacionCargosPlanes WHERE ID = {idConceptoRecargo}")
            If (idConceptoRecargo = ID And item.SelectedImageIndex <> 1 And autorizado = False And tipo = True) Then
                item.Checked = True
                item.SelectedImageIndex = 1
                ch.agregarconcepto(IDRecargo, "REC", Matricula)
            ElseIf (idConceptoRecargo = ID And item.SelectedImageIndex <> 0 And autorizado = False And tipo = False) Then
                item.Checked = False
                item.SelectedImageIndex = 0
                ch.eliminarconcepto(IDRecargo, "REC", Matricula)
            End If
        Next
    End Sub

    Function buscarConceptoConRecargo(IDRecargo As Integer) As Boolean
        Dim IDRecargado As Integer = db.exectSQLQueryScalar($"SELECT ID_Concepto FROM ing_PlanesRecargos WHERE ID = {IDRecargo}")
        For x = 0 To 5
            For Each item As TreeNode In Tree.Nodes(x).Nodes
                Dim IDCOncepto As Integer = co.Extrae_Cadena(item.ToString(), "[", "]")
                If (IDCOncepto = IDRecargado And item.SelectedImageIndex = 1) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Function validarSeleccionNodosColegiaturas(index As Integer, tipo As Integer) As Boolean
        If (tipo = 1) Then
            For x = 0 To index - 1
                If (Tree.Nodes(3).Nodes(x).SelectedImageIndex <> 1) Then
                    Return False
                End If
            Next
        ElseIf (tipo = 2) Then
            For x = index To Tree.Nodes(3).Nodes.Count() - 1
                If (Tree.Nodes(3).Nodes(x).SelectedImageIndex = 1 And Tree.Nodes(3).Nodes(x).Index <> index) Then
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Sub Limpiar()
        lblNombretxt.Text = ""
        lblEmailtxt.Text = ""
        lblCarreratxt.Text = ""
        lblTurnotxt.Text = ""
        Tree.Nodes(0).Nodes.Clear()
        Tree.Nodes(1).Nodes.Clear()
        Tree.Nodes(2).Nodes.Clear()
        Tree.Nodes(3).Nodes.Clear()
        Tree.Nodes(4).Nodes.Clear()
        Tree.Nodes(5).Nodes.Clear()
        lblTotal.Text = ""
        ch.limpiarListaConceptos()
        txtMonto.Clear()
        cbBanco.SelectedIndex = -1
        cbTipoBanco.SelectedIndex = -1
        txtUltimos4Digitos.Clear()
        txtNoCheque.Clear()
        txtNoCuenta.Clear()
        cbFormaPago.SelectedIndex = 0
        Me.cbFormaPago_SelectionChangeCommitted(Nothing, Nothing)
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
        txtMatricula.Focus()
    End Sub

    Private Sub btnBuscarNota_Click(sender As Object, e As EventArgs) Handles btnBuscarNota.Click
        Dim notaCredito As Boolean = ca.buscarNotasCredito(Matricula)
        If (notaCredito = True) Then
            ObjectBagService.setItem("Matricula", Matricula)
            ModalNotasCreditoEDC.ShowDialog()
            If (ObjectBagService.getItem("NotaAgregada")) Then
                Me.Enabled = True
            Else
                Me.Reiniciar()
            End If
        End If
    End Sub

    Function obtenerFechaString(datePicker As DateTimePicker) As String
        Try
            Dim dia As String = datePicker.Value.Day
            Dim mes As String = datePicker.Value.Month
            Dim año As String = datePicker.Value.Year
            If (System.Diagnostics.Debugger.IsAttached) Then
                Return $"{dia}/{mes}/{año}"
            Else
                Return $"{mes}/{dia}/{año}"
            End If

        Catch ex As Exception
            Return "1900-01-01"
        End Try

    End Function

End Class