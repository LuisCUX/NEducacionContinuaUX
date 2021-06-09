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
    Dim es As EmailService = New EmailService()
    Dim combo_filtro As String
    Private Sub CobrosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        ComboboxService.llenarCombobox(cbFormaPago, tableFormaPago, "Forma_Pago", "Descripcion")
        Dim tablebancos As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre_Banco FROM ing_Cat_Bancos")
        ComboboxService.llenarCombobox(cbBanco, tablebancos, "ID", "Nombre_Banco")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Limpiar()
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        txtMatriculaDato.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno, txtRFC)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno, txtRFC)
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

    Private Sub cbBanco_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbBanco.SelectionChangeCommitted
        Dim tableTipoPAgo As DataTable = db.getDataTableFromSQL($"SELECT ID, Tipo_Pago FROM ing_cat_tipoFormaPago WHERE ID_TipoPago = (SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = {cbFormaPago.SelectedValue} AND Descripcion = '{cbFormaPago.Text}')")
        ComboboxService.llenarCombobox(cbTipoBanco, tableTipoPAgo, "ID", "Tipo_Pago")
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
        ElseIf Tree.SelectedNode.Text = "Inscripción a Diplomados" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Colegiaturas de Diplomados" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Pago Unico de Diplomados" Then
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
            Else
                tipoConcepto = "POE"
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
                    Dim mesActual As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "-", "-")
                    MessageBox.Show($"No puede pagar la colegiatura del mes {mesActual} sin antes haber pagado las colegiaturas anteriores")
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
                    Dim mesActual As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "-", "-")
                    MessageBox.Show($"No puede desmarcar el pago del mes de {mesActual} sin antes haber pagado las colegiaturas posteriores")
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
        ElseIf (cbFormaPago.Text = "CREDITO") Then

            If (tipoMatricula = "EX") Then
                tipocliente = 2
            ElseIf (tipoMatricula = "EC") Then
                tipocliente = 1
            End If
            Dim IDXMLC As Integer = co.Cobrar(listaConceptosPrueba, cbFormaPago.SelectedValue, Matricula, txtRFC.Text, txtNombre.Text, lblTotal.Text, True, tipocliente)
            If (IDXMLC > 0) Then
                Me.Reiniciar()
                Exit Sub
            End If
        End If

        Dim montoTotal As Decimal = CDec(lblTotal.Text)
        Dim montoIngresado As Decimal = CDec(txtMonto.Text)
        If (montoTotal <> montoIngresado) Then
            If (montoIngresado > montoTotal) Then
                MessageBox.Show("No puede ingresar un monto mayor al total a pagar, ingrese un monto valido")
                Exit Sub
            End If
            listaconceptosFinal = co.calcularAbonos(listaConceptosPrueba, montoIngresado, montoTotal, Matricula)
            If (IsNothing(listaconceptosFinal)) Then
                Exit Sub
            End If
        Else
            listaconceptosFinal = ch.getListaConceptos()
            For Each concepto As Concepto In listaconceptosFinal
                Dim IDClavePago As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE Clave = '{concepto.claveConcepto}'")
                Dim tieneAbono As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_Abonos WHERE ID_ClavePago = {IDClavePago} AND IDPago = {concepto.IDConcepto}")
                If (tieneAbono > 0) Then
                    co.recalcularCostoAbono(concepto, concepto.costoFinal, 2)
                    concepto.NombreConcepto = $"2{concepto.NombreConcepto}"
                End If
            Next
        End If
        If (tipoMatricula = "EX") Then
            tipocliente = 2
        ElseIf (tipoMatricula = "EC") Then
            tipocliente = 1
        End If
        Dim IDXML As Integer = co.Cobrar(listaconceptosFinal, cbFormaPago.SelectedValue, Matricula, txtRFC.Text, txtNombre.Text, lblTotal.Text, False, tipocliente)


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

        ''--------------------------------------------------------------ENVIO DE EMAIL--------------------------------------------------------------
        Dim Total As String = ObjectBagService.getItem("CantidadLetra")
        Dim usoCFDI As String = ObjectBagService.getItem("usoCFDI")
        Dim Serie As String = ObjectBagService.getItem("Serie")
        Dim Folio As String = ObjectBagService.getItem("Folio")
        Dim RFCCLiente As String = ObjectBagService.getItem("RFC")
        Dim folioFiscal As String = ObjectBagService.getItem("FolioF")
        Dim tipoClienteint As Integer = ObjectBagService.getItem("tipoCliente")
        ObjectBagService.clearBag()
        Dim rep2 As ImpresionReportesService = New ImpresionReportesService()

        Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={RFCCLiente}id={folioFiscal}tt={Total}"
        co.gernerarQr(QR, $"{Serie}{Folio}")
        rep2.AgregarFuente("FacturaEDC.rpt")
        rep2.AgregarParametros("IDXML", IDXML)
        rep2.AgregarParametros("CantidadLetra", Total)
        rep2.AgregarParametros("ClaveCliente", Matricula)
        rep2.AgregarParametros("usoCFDI", usoCFDI)
        rep2.AgregarParametros("TipoCliente", tipoClienteint)

        Dim mail As New Mail
        Dim archivo_pdf As Byte() = Nothing
        Dim archivo_xml As Byte() = Nothing

        Dim xmlTimbrado As String = db.exectSQLQueryScalar($"SELECT XMLTimbrado FROM ing_xmlTimbrados WHERE ID = {IDXML}")

        archivo_pdf = rep2.obtenerReporteByte()
        'archivo_pdf = Encoding.Default.GetBytes(xmlTimbrado)
        archivo_xml = Encoding.Default.GetBytes(xmlTimbrado)

        mail.Destino = "luis.c@ux.edu.mx"
        mail.Asunto = "GRACIAS POR SU PAGO"
        mail.Mensaje = "ANEXAMOS TUS COMPROBANTES DE PAGO ADJUNTOS A ESTE CORREO, GRACIAS."
        mail.BytesFile = archivo_pdf
        mail.BytesFile2 = archivo_xml
        mail.FileName = "Factura"
        mail.FileName2 = "xml"
        Try
            es.sendEmailWithFileBytesCobro(mail)
            MessageBox.Show("Email enviado correctamente")
            Me.Reiniciar()
        Catch ex As Exception
            MessageBox.Show("Error al enviar email")
        End Try
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
        txtNombre.Clear()
        txtEmail.Clear()
        txtCarrera.Clear()
        txtTurno.Clear()
        Tree.Nodes(0).Nodes.Clear()
        Tree.Nodes(1).Nodes.Clear()
        Tree.Nodes(2).Nodes.Clear()
        Tree.Nodes(3).Nodes.Clear()
        Tree.Nodes(4).Nodes.Clear()
        Tree.Nodes(5).Nodes.Clear()
        lblTotal.Text = ""
        ch.limpiarListaConceptos()
        txtMonto.Clear()
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
End Class