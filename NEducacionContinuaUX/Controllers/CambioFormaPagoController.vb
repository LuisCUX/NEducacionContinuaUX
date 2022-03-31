Public Class CambioFormaPagoController
    Dim db As DataBaseService = New DataBaseService()

    Function llenarComboboxFacturas(Matricula As String, cbFacturas As ComboBox) As Boolean
        Dim tableFacturas As DataTable = db.getDataTableFromSQL($"SELECT ID, UPPER('Folio: ' + ' ' + Folio + ' Fecha: ' + Fecha_Pago)As TextoFactura FROM ing_xmlTimbrados WHERE Matricula_Clave = '{Matricula}'")

        If (tableFacturas.Rows.Count() = 0) Then
            MessageBox.Show("La clave ingresada no existe o no tiene facturas cobradas, ingrese una clave diferente")
            Return False
        End If

        ComboboxService.llenarCombobox(cbFacturas, tableFacturas, "ID", "TextoFactura")

        Return True
    End Function

    Function validarMatricula(Matricula As String) As String
        If (Matricula.Length() < 9 Or Matricula.Length() > 9) Then
            MessageBox.Show("La clave ingresada no existe, favor de ingresar una clave valida")
            Return "False"
        Else
            Dim MatriculaUX As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")
            If (MatriculaUX > 0) Then
                Return "UX"
            ElseIf (Matricula.Substring(0, 2) = "EX") Then
                Return "EX"
            ElseIf (Matricula.Substring(0, 2) = "EC") Then
                Return "EC"
            End If
        End If

        Return "False"
    End Function

    Sub getDatosPagoActuales(IDXml As Integer, lblFormaPago As Label, cbFormaPago As ComboBox, lblMonto As Label, txtMonto As TextBox, lblBanco As Label, cbBanco As ComboBox, lblBanco2 As Label, txtBanco2 As TextBox,
                             lblTipo As Label, cbTipo As ComboBox, lblFecha As Label, dtPickerFecha As DateTimePicker, lbl4dig As Label, txt4dig As TextBox, lblNoCuenta As Label, txtNoCuenta As TextBox, lblNoCheque As Label, txtNoCheque As TextBox)
        Dim IDFormaPago As Integer = db.exectSQLQueryScalar($"SELECT Forma_PagoID FROM ing_xmlTimbrados WHERE ID = {IDXml}")
        cbFormaPago.SelectedValue = IDFormaPago
        txtMonto.Text = db.exectSQLQueryScalar($"SELECT Total FROM ing_xmlTimbrados WHERE ID = {IDXml}")

        If (IDFormaPago = 2) Then ''TARJETA DE CREDITO
            Dim tablePagoTCredito As DataTable = db.getDataTableFromSQL($"SELECT B.ID As IDBanco, T.ID As IDTarjeta, NumTarjeta FROM ing_PagosTarjeta AS PT
                                                                          INNER JOIN ing_res_BancoTarjeta AS RBT ON RBT.ID = PT.ID_resBancoTarjeta
                                                                          INNER JOIN ing_Cat_Bancos AS B ON B.ID = RBT.ID_Banco
                                                                          INNER JOIN ing_CatTipoTarjeta AS T ON T.ID = RBT.ID_TipoTarjeta
                                                                          WHERE PT.ID_Factura = {IDXml}")
            For Each row As DataRow In tablePagoTCredito.Rows
                cbBanco.SelectedValue = row("IDBanco")
                cbTipo.SelectedValue = row("IDTarjeta")
                txt4dig.Text = row("NumTarjeta")
            Next

            lblBanco.Visible = True
            cbBanco.Visible = True
            lblTipo.Visible = True
            cbTipo.Visible = True
            lbl4dig.Visible = True
            txt4dig.Visible = True
        ElseIf (IDFormaPago = 3) Then ''TARJETA DE DEBITO
            Dim tablePagoTCredito As DataTable = db.getDataTableFromSQL($"SELECT B.ID As IDBanco, T.ID As IDTarjeta, NumTarjeta FROM ing_PagosTarjeta AS PT
                                                                          INNER JOIN ing_res_BancoTarjeta AS RBT ON RBT.ID = PT.ID_resBancoTarjeta
                                                                          INNER JOIN ing_Cat_Bancos AS B ON B.ID = RBT.ID_Banco
                                                                          INNER JOIN ing_CatTipoTarjeta AS T ON T.ID = RBT.ID_TipoTarjeta
                                                                          WHERE PT.ID_Factura = {IDXml}")
            For Each row As DataRow In tablePagoTCredito.Rows
                cbBanco.SelectedValue = row("IDBanco")
                cbTipo.SelectedValue = row("IDTarjeta")
                txt4dig.Text = row("NumTarjeta")
            Next

            lblBanco.Visible = True
            cbBanco.Visible = True
            lblTipo.Visible = True
            cbTipo.Visible = True
            lbl4dig.Visible = True
            txt4dig.Visible = True
        ElseIf (IDFormaPago = 4) Then ''CHEQUE
            Dim tableCheque As DataTable = db.getDataTableFromSQL($"SELECT NombreBanco, NoCuenta, NoCheque FROM ing_PagosCheques WHERE ID_Factura = {IDXml}")

            For Each row As DataRow In tableCheque.Rows
                txtBanco2.Text = row("NombreBanco")
                txtNoCuenta.Text = row("NoCuenta")
                txtNoCheque.Text = row("NoCheque")
            Next

            lblBanco2.Visible = True
            txtBanco2.Visible = True
            lblNoCuenta.Visible = True
            txtNoCuenta.Visible = True
            lblNoCheque.Visible = True
            txtNoCheque.Visible = True
        ElseIf (IDFormaPago = 5) Then ''TRANSFERENCIA
            Dim tableTransferencia As DataTable = db.getDataTableFromSQL($"SELECT ID_Banco, Fecha_Pago FROM ing_PagosTransferencias WHERE ID_Factura = {IDXml}")

            For Each row As DataRow In tableTransferencia.Rows
                cbBanco.SelectedValue = row("ID_Banco")
                dtPickerFecha.Value = row("Fecha_Pago")
            Next

            lblBanco.Visible = True
            cbBanco.Visible = True
            lblFecha.Visible = True
            dtPickerFecha.Visible = True
        ElseIf (IDFormaPago = 7) Then ''DEPOSITO BANCARIO C/COMPROBANTE
            Dim tableDeposito As DataTable = db.getDataTableFromSQL($"SELECT ID_Banco, ID_TipoPago, FechaPago FROM ing_PagosDepositos WHERE ID_Factura = {IDXml}")

            For Each row As DataRow In tableDeposito.Rows
                cbBanco.SelectedValue = row("ID_Banco")
                cbTipo.SelectedValue = row("ID_TipoPago")
                dtPickerFecha.Value = row("FechaPago")
            Next

            lblBanco.Visible = True
            cbBanco.Visible = True
            lblTipo.Visible = True
            cbTipo.Visible = True
            lblFecha.Visible = True
            dtPickerFecha.Visible = True
        ElseIf (IDFormaPago = 8) Then ''DEPOSITO BANCARIO EDO CTA
            Dim tableDeposito As DataTable = db.getDataTableFromSQL($"SELECT ID_Banco, ID_TipoPago, FechaPago FROM ing_PagosDepositos WHERE ID_Factura = {IDXml}")

            For Each row As DataRow In tableDeposito.Rows
                cbBanco.SelectedValue = row("ID_Banco")
                cbTipo.SelectedValue = row("ID_TipoPago")
                dtPickerFecha.Value = row("FechaPago")
            Next

            lblBanco.Visible = True
            cbBanco.Visible = True
            lblTipo.Visible = True
            cbTipo.Visible = True
            lblFecha.Visible = True
            dtPickerFecha.Visible = True
        End If
    End Sub

    Sub GuardarCambiosPagos(IDXml As Integer, cbFormaPago As ComboBox, txtMonto As TextBox, cbBanco As ComboBox, txtBanco2 As TextBox, cbTipo As ComboBox, dtPickerFecha As DateTimePicker, txt4dig As TextBox, txtNoCuenta As TextBox, txtNoCheque As TextBox)
        Dim IDFormaPago As Integer = db.exectSQLQueryScalar($"SELECT Forma_PagoID FROM ing_xmlTimbrados WHERE ID = {IDXml}")
        cbFormaPago.SelectedValue = IDFormaPago
        txtMonto.Text = db.exectSQLQueryScalar($"SELECT Total FROM ing_xmlTimbrados WHERE ID = {IDXml}")

        If (IDFormaPago = 2) Then ''TARJETA DE CREDITO

            Dim IDRes As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_res_BancoTarjeta WHERE ID_Banco = {cbBanco.SelectedValue} AND ID_TipoTarjeta = {cbTipo.SelectedValue}")
            db.execSQLQueryWithoutParams($"UPDATE ing_PagosTarjeta SET ID_resBancoTarjeta = {IDRes}, NumTarjeta = '{txt4dig.Text}' WHERE ID_Factura = {IDXml}")

        ElseIf (IDFormaPago = 3) Then ''TARJETA DE DEBITO

            Dim IDRes As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_res_BancoTarjeta WHERE ID_Banco = {cbBanco.SelectedValue} AND ID_TipoTarjeta = {cbTipo.SelectedValue}")
            db.execSQLQueryWithoutParams($"UPDATE ing_PagosTarjeta SET ID_resBancoTarjeta = {IDRes}, NumTarjeta = '{txt4dig.Text}' WHERE ID_Factura = {IDXml}")

        ElseIf (IDFormaPago = 4) Then ''CHEQUE

            db.execSQLQueryWithoutParams($"UPDATE ing_PagosCheques SET NombreBanco = '{txtBanco2.Text}', NoCuenta = '{txtNoCuenta.Text}', NoCheque = '{txtNoCheque.Text}' WHERE ID_Factura = {IDXml}")

        ElseIf (IDFormaPago = 5) Then ''TRANSFERENCIA

            db.execSQLQueryWithoutParams($"UPDATE ing_PagosTransferencias SET ID_Banco = {cbBanco.SelectedValue}, Fecha_Pago = '{dtPickerFecha.Text}' WHERE ID_Factura = {IDXml}")

        ElseIf (IDFormaPago = 7) Then ''DEPOSITO BANCARIO C/COMPROBANTE

            db.execSQLQueryWithoutParams($"UPDATE ing_PagosDepositos SET ID_Banco = {cbBanco.SelectedValue}, ID_TipoPago = {cbTipo.SelectedValue}, FechaPago = '{dtPickerFecha.Text}' WHERE ID_Factura = {IDXml}")

        ElseIf (IDFormaPago = 8) Then ''DEPOSITO BANCARIO EDO CTA

            db.execSQLQueryWithoutParams($"UPDATE ing_PagosDepositos SET ID_Banco = {cbBanco.SelectedValue}, ID_TipoPago = {cbTipo.SelectedValue}, FechaPago = '{dtPickerFecha.Text}' WHERE ID_Factura = {IDXml}")

        End If

        MessageBox.Show("Cambios guardados correctamente")
    End Sub

End Class
