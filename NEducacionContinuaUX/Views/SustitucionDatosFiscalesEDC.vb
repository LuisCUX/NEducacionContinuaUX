Public Class SustitucionDatosFiscalesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim sd As SustitucionDatosFiscalesController = New SustitucionDatosFiscalesController
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim Folio As String
    Dim IDFolio As Integer
    Dim Matricula As String
    Dim listaconceptosFinal As New List(Of Concepto)
    Dim tipoMatricula As String
    Private Sub SustitucionDatosFiscalesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableFormaPago As DataTable = db.getDataTableFromSQL("SELECT Forma_Pago, Descripcion FROM ing_CatFormaPago")
        ComboboxService.llenarComboboxVacio(cbFormaPago, tableFormaPago, "Forma_Pago", "Descripcion")
        Dim tablebancos As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre_Banco FROM ing_Cat_Bancos WHERE Activo = 1")
        ComboboxService.llenarComboboxVacio(cbBanco, tablebancos, "ID", "Nombre_Banco")
        Dim tableObservacion As DataTable = db.getDataTableFromSQL($"SELECT ID, Observacion FROM ing_CatObservacionesCancelacion WHERE Activo = 1 AND ID_TipoOtraObservacion = 3")
        ComboboxService.llenarCombobox(cbObservaciones, tableObservacion, "iD", "Observacion")
        cbObservaciones.SelectedIndex = -1
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.limpiar()
        Folio = txtFolio.Text
        IDFolio = db.exectSQLQueryScalar($"SELECT ID FROM ing_xmlTimbrados WHERE Folio = '{Folio}' AND CanceladaHoy = 0 AND CanceladaOtroDia = 0")
        Matricula = db.exectSQLQueryScalar($"SELECT Matricula_Clave FROM ing_xmlTimbrados WHERE ID = {IDFolio}")
        If (IDFolio < 1) Then
            MessageBox.Show("El folio ingresado no existe o esta cancelado, ingrese un folio válido")
            Me.Reiniciar()
            Exit Sub
        End If

        Dim IDSustitucion As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_Sustituciones WHERE FolioSustituido = '{Folio}' AND Clave_Matricula = '{Matricula}' AND Activo = 1")
        If (IDSustitucion > 0) Then
            MessageBox.Show("El folio ingresado ya fue sustituido, ingrese un folio válido")
            Me.Reiniciar()
            Exit Sub
        End If

        tipoMatricula = va.validarMatricula(Matricula)

        sd.obtenerInfoFactura(Folio, lblClaveCliente, lblRFCTimbrado, lblFechaFacturacion, lblFormaPago, lblFolioFiscal)
        Me.organizarFormasPago(lblFormaPago.Text)

        sd.LlenarGridConceptos(IDFolio, GridConceptos)
        panelInfo.Visible = True

        For x = 0 To GridConceptos.Rows.Count - 1
            ch.agregarconcepto(GridConceptos.Rows(x).Cells(0).Value, GridConceptos.Rows(x).Cells(1).Value, Matricula)
        Next
        listaconceptosFinal = ch.getListaConceptos()

        Dim total As Decimal
        For x = 0 To GridConceptos.Rows.Count - 1
            total = total + Convert.ToDecimal(GridConceptos.Rows(x).Cells(7).Value)
        Next
        lblTotal.Text = total
    End Sub

    Sub organizarFormasPago(FormaPago As String)
        cbFormaPago.Text = FormaPago
        If (FormaPago = "EFECTIVO") Then ''EFECTIVO
            Me.controlesFalse()
        ElseIf (FormaPago = "TARJETA DE CREDITO" Or FormaPago = "TARJETA DE DEBITO") Then ''TARJETA DE CREDITO O DEBITO
            Me.controlesFalse()
            lblBanco.Visible = True
            lblTIpoBanco.Visible = True
            lblUltimosDigitos.Visible = True
            txtUltimos4Digitos.Visible = True
            cbBanco.Visible = True
            cbTipoBanco.Visible = True
            sd.getDatosPagoTarjeta(IDFolio, cbBanco, cbTipoBanco, txtUltimos4Digitos)
        ElseIf (FormaPago = "CHEQUE") Then ''CHEQUE
            Me.controlesFalse()
            lblNoCuenta.Visible = True
            lblNoCheque.Visible = True
            lblBancotext.Visible = True
            txtBancotext.Visible = True
            txtNoCheque.Visible = True
            txtNoCuenta.Visible = True
            sd.getDatosPagoCheque(IDFolio, txtBancotext, txtNoCuenta, txtNoCheque)
        ElseIf (FormaPago = "TRANSFERENCIA") Then ''TRANSFERENCIA
            Me.controlesFalse()
            lblBanco.Visible = True
            lblFecha.Visible = True
            cbBanco.Visible = True
            DTPickerFecha.Visible = True
            sd.getDatosTransferencia(IDFolio, cbBanco, DTPickerFecha)
        ElseIf (FormaPago = "DEPOSITO BANCARIO C/COMPROBANTE" Or FormaPago = "DEPOSITO BANCARIO EDO CTA") Then ''DEPOSITO BANCARIO C/COMPROBANTE
            Me.controlesFalse()
            lblBanco.Visible = True
            lblTIpoBanco.Visible = True
            lblFecha.Visible = True
            cbBanco.Visible = True
            cbTipoBanco.Visible = True
            DTPickerFecha.Visible = True
            sd.getDatosDeposito(IDFolio, cbBanco, cbTipoBanco, DTPickerFecha)
        ElseIf (FormaPago = "CREDITO") Then ''CREDITO
            Me.controlesFalse()
        ElseIf (FormaPago = "NOTA DE CREDITO") Then ''NOTA DE CREDITO
            Me.controlesFalse()
            lblNotaAplicada.Visible = True
            txtNotaAplicada.Visible = True
        End If
    End Sub

    Sub controlesFalse()
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
        lblNotaAplicada.Visible = False
        txtNotaAplicada.Visible = False
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

    Sub commitcbBanco()
        cbBanco_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        SustitucionDatosFiscalesEDC_Load(Me, Nothing)
    End Sub

    Private Sub btnGuardarSustitucion_Click(sender As Object, e As EventArgs) Handles btnGuardarSustitucion.Click
        ''---------------------------------------------------------VALIDA DATOS FISCALES---------------------------------------------------------
        Dim RFCTimbrar As String
        Dim RegFiscalTimbrar As String
        Dim UsoCFDITimbrar As String
        Dim cpTimbrar As String
        Dim NombreTimbrar As String
        Dim tipocliente As Integer
        Dim tablas As String()

        If (cbObservaciones.Text = "") Then
            MessageBox.Show("Seleccione una observación")
            Exit Sub
        End If
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

        If (RFCDefault <> "XAXX010101000" And IDResRegCF <> 254 And IDResRegCF <> 0) Then
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
                NombreTimbrar = db.exectSQLQueryScalar($"SELECT UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno)As Nombre FROM portal_reRFC AS RE
                                                     INNER JOIN portal_registroExterno AS E ON E.id_registro = RE.id_registro
                                                     INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                     WHERE E.clave_cliente = '{Matricula}'")
                cpTimbrar = EnviromentService.CP
            End If
        Else
            RFCTimbrar = "XAXX010101000"
            RegFiscalTimbrar = "616"
            UsoCFDITimbrar = "S01"
            NombreTimbrar = db.exectSQLQueryScalar($"SELECT UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno)As Nombre FROM portal_reRFC AS RE
                                                     INNER JOIN portal_registroExterno AS E ON E.id_registro = RE.id_registro
                                                     INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                     WHERE E.clave_cliente = '{Matricula}'")
            cpTimbrar = EnviromentService.CP
        End If

        If (RFCTimbrar = lblRFCTimbrado.Text) Then
            Dim result As DialogResult = MessageBox.Show("El RFC seleccionado es igual al RFC Timbrado ¿Quiere continuar con la sustitución?", "", MessageBoxButtons.YesNo)
            If (result <> 6) Then
                Me.Reiniciar()
                Exit Sub
            End If
        End If

        Dim formaPagoClave As String
        Dim formaPagoID As String
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
        If (tipoMatricula = "EX") Then
            tipocliente = 2
        ElseIf (tipoMatricula = "EC") Then
            tipocliente = 1
        End If

        For x = 0 To GridConceptos.Rows.Count - 1
            listaconceptosFinal(x).costoUnitario = GridConceptos.Rows(x).Cells(4).Value
            listaconceptosFinal(x).costoTotal = GridConceptos.Rows(x).Cells(4).Value
            listaconceptosFinal(x).costoBase = GridConceptos.Rows(x).Cells(4).Value
            listaconceptosFinal(x).costoIVATotal = GridConceptos.Rows(x).Cells(6).Value
        Next

        Dim nuevoFolio As String = sd.Cobrar(listaconceptosFinal, formaPagoClave, formaPagoID, Matricula, RFCTimbrar, NombreTimbrar, Convert.ToDecimal(lblTotal.Text), False, tipocliente, cpTimbrar, RegFiscalTimbrar, UsoCFDITimbrar, lblFolioFiscal.Text)

        db.execSQLQueryWithoutParams($"INSERT INTO ing_Sustituciones(Clave_Matricula, FolioSustituido, FolioNuevo, FechaSustitucion, IDObservacion, TipoSustitucion, Usuario, Activo) VALUES('{Matricula}', '{Folio}', '{nuevoFolio}', GETDATE(), {cbObservaciones.SelectedValue}, 'Datos', '{User.getUsername}', 1)")
        MessageBox.Show("Factura sustituida exitosamente")
        Me.Reiniciar()
    End Sub

    Sub limpiar()
        lblTotal.Text = ""
        ch.limpiarListaConceptos()
        cbBanco.SelectedIndex = -1
        cbTipoBanco.SelectedIndex = -1
        txtUltimos4Digitos.Clear()
        txtNoCheque.Clear()
        txtNoCuenta.Clear()
        cbFormaPago.SelectedIndex = 0
        GridConceptos.Rows.Clear()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
    End Sub
End Class