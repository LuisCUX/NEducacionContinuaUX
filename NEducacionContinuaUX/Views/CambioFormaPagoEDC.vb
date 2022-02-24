Public Class CambioFormaPagoEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim cf As CambioFormaPagoController = New CambioFormaPagoController()
    Dim Matricula As String
    Dim tipoMatricula As String
    Private Sub CambioFormaPagoEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
                                                            ORDER BY NombreCliente")
        Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
                                                                 INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                 INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
                                                                 ORDER BY C.nombre")

        tableExternos.Merge(tableEDC)
        ComboboxService.llenarCombobox(cbExterno, tableExternos, "clave_cliente", "NombreCliente")

        Dim tableFormaPago As DataTable = db.getDataTableFromSQL("SELECT ID, Descripcion FROM ing_CatFormaPago")
        ComboboxService.llenarComboboxVacio(cbFormaPago, tableFormaPago, "ID", "Descripcion")
        Dim tablebancos As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre_Banco FROM ing_Cat_Bancos WHERE Activo = 1")
        ComboboxService.llenarComboboxVacio(cbBanco, tablebancos, "ID", "Nombre_Banco")
    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectedIndexChanged
        Try
            txtMatricula.Text = cbExterno.SelectedValue
            btnBuscarMatricula.PerformClick()
            txtMatricula.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscarMatricula_Click(sender As Object, e As EventArgs) Handles btnBuscarMatricula.Click
        Matricula = txtMatricula.Text
        tipoMatricula = cf.validarMatricula(Matricula)
        Dim valida As Boolean = cf.llenarComboboxFacturas(Matricula, cbFactura)
        If (valida = False) Then
            Me.Reiniciar()
            Exit Sub
        End If
        panelDatos.Visible = True
    End Sub

    Private Sub cbFactura_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbFactura.SelectionChangeCommitted
        cf.getDatosPagoActuales(cbFactura.SelectedValue, lblFormadepago, cbFormaPago, lblMonto, txtMonto, lblBanco, cbBanco, lblBancotext, txtBancotext, lblTIpoBanco, cbTipoBanco, lblFecha, DTPickerFecha,
                                lblUltimosDigitos, txtUltimos4Digitos, lblNoCuenta, txtNoCuenta, lblNoCheque, txtNoCheque)
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        CambioFormaPagoEDC_Load(Me, Nothing)
        txtMatricula.Focus()
    End Sub

    Private Sub cbBanco_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbBanco.SelectedValueChanged
        Try
            If (cbFormaPago.Text = "TARJETA DE DEBITO" Or cbFormaPago.Text = "TARJETA DE CREDITO") Then

                Dim tableTipoPAgo As DataTable = db.getDataTableFromSQL($"SELECT T.ID, T.Nombre FROM ing_CatTipoTarjeta AS T
                                                                  INNER JOIN ing_res_BancoTarjeta AS B ON B.ID_TipoTarjeta = T.ID
                                                                  WHERE B.ID_Banco = {cbBanco.SelectedValue} AND B.Activo = 1")
                ComboboxService.llenarCombobox(cbTipoBanco, tableTipoPAgo, "ID", "Nombre")

            ElseIf (cbFormaPago.Text = "DEPOSITO BANCARIO C/COMPROBANTE" Or cbFormaPago.Text = "DEPOSITO BANCARIO EDO CTA") Then

                Dim tableTipoPAgo As DataTable = db.getDataTableFromSQL($"SELECT ID, Tipo_Pago FROM ing_cat_tipoFormaPago WHERE ID_TipoPago = {cbFormaPago.SelectedValue}")
                ComboboxService.llenarCombobox(cbTipoBanco, tableTipoPAgo, "ID", "Tipo_Pago")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnGuardarCondonaciones_Click(sender As Object, e As EventArgs) Handles btnGuardarCondonaciones.Click
        cf.GuardarCambiosPagos(cbFactura.SelectedValue, cbFormaPago, txtMonto, cbBanco, txtBancotext, cbTipoBanco, DTPickerFecha, txtUltimos4Digitos, txtNoCuenta, txtNoCheque)
        Me.Reiniciar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
    End Sub


End Class