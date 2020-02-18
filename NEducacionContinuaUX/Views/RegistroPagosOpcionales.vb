Public Class RegistroPagosOpcionales
    Dim po As PagosOpcionalesController = New PagosOpcionalesController()
    Dim db As DataBaseService = New DataBaseService()
    Private Sub RegistroPagosOpcionales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        po.llenarCombobox(cbConceptoPara, cbTipoPago, cbTipoConcepto, cbNivel)
    End Sub

    Private Sub txtValorUnitario_TextChanged(sender As Object, e As EventArgs) Handles txtValorUnitario.TextChanged
        Dim tipo As Integer
        If (chbExentaIVA.Checked = True) Then
            tipo = 3
        ElseIf (chbIncluyeIVA.Checked = True) Then
            tipo = 2
        ElseIf (chbConsideraIVA.Checked = True) Then
            tipo = 1
        End If
        Me.valorUnitario(tipo)
    End Sub

    Private Sub txtValorUnitario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorUnitario.KeyPress
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
        ElseIf InStr(txtValorUnitario.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub valorUnitario(Tipo As Integer)
        If (txtValorUnitario.Text <> "") Then
            If (Tipo = 1) Then
                Dim valorunitarioiva As Decimal = CDec(txtValorUnitario.Text) / 1.16
                txtValorUnitarioSinIVA.Text = Format(CDec(valorunitarioiva), "#####0.00")
            ElseIf (Tipo = 2) Then
                Dim IVA As Decimal = CDec(txtValorUnitario.Text) * 0.16
                IVA = CDec(txtValorUnitario.Text) + IVA
                txtValorUnitarioSinIVA.Text = Format(CDec(IVA), "#####0.00")
            ElseIf (Tipo = 3) Then
                txtValorUnitarioSinIVA.Text = Format(CDec(txtValorUnitario.Text), "#####0.00")
            ElseIf (Tipo = 0) Then
                txtValorUnitarioSinIVA.Text = txtValorUnitario.Text
            End If
        Else
            txtValorUnitarioSinIVA.Text = "0.00"
        End If

    End Sub

    Private Sub enableControls()
        cbTipoConcepto.Enabled = True
        cbDivision.Enabled = True
        cbGrupo.Enabled = True
        cbClase.Enabled = True
        cbProdServ.Enabled = True
        cbUnidad.Enabled = True
    End Sub

    Private Sub chbConsideraIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConsideraIVA.CheckedChanged
        If (chbConsideraIVA.Checked = True) Then
            chbExentaIVA.Checked = False
            chbIncluyeIVA.Checked = False
            Me.valorUnitario(1)
        ElseIf (chbConsideraIVA.Checked = False And chbIncluyeIVA.Checked = False And chbExentaIVA.Checked = False) Then
            MessageBox.Show("Seleccione al menos una de las 3 opciones de IVA")
            chbConsideraIVA.Checked = True
        End If
    End Sub

    Private Sub chbIncluyeIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbIncluyeIVA.CheckedChanged
        If (chbIncluyeIVA.Checked = True) Then
            chbExentaIVA.Checked = False
            chbConsideraIVA.Checked = False
            Me.valorUnitario(2)
        ElseIf (chbConsideraIVA.Checked = False And chbIncluyeIVA.Checked = False And chbExentaIVA.Checked = False) Then
            MessageBox.Show("Seleccione al menos una de las 3 opciones de IVA")
            chbIncluyeIVA.Checked = True
        End If
    End Sub

    Private Sub chbExentaIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbExentaIVA.CheckedChanged
        If (chbExentaIVA.Checked = True) Then
            chbIncluyeIVA.Checked = False
            chbConsideraIVA.Checked = False
            Me.valorUnitario(3)
        ElseIf (chbConsideraIVA.Checked = False And chbIncluyeIVA.Checked = False And chbExentaIVA.Checked = False) Then
            MessageBox.Show("Seleccione al menos una de las 3 opciones de IVA")
            chbExentaIVA.Checked = True
        End If
    End Sub

    Private Sub cbTipoPago_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoPago.SelectionChangeCommitted
        cbTipoConcepto.SelectedIndex = 1
        cbTipoConcepto_SelectionChangeCommitted(Nothing, Nothing)

        cbTipoConcepto.Enabled = True
        cbDivision.Enabled = True
        cbGrupo.Enabled = True
        cbClase.Enabled = True
        cbProdServ.Enabled = True
        cbUnidad.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub cbTipoConcepto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoConcepto.SelectionChangeCommitted
        Dim tableDivision As DataTable = db.getDataTableFromSQL($"SELECT DISTINCT Cve_division, Division FROM sat_ClasificacionClavesSAT WHERE Tipo = '{cbTipoConcepto.Text}'")
        ComboboxService.llenarCombobox(cbDivision, tableDivision, "Cve_division", "Division")
        If (cbTipoConcepto.Text = "SERVICIO") Then
            cbDivision.SelectedValue = "86000000"
            cbDivision_SelectionChangeCommitted(Nothing, Nothing)
        End If
        cbDivision_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub cbDivision_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbDivision.SelectionChangeCommitted
        Dim tableGrupo As DataTable = db.getDataTableFromSQL($"SELECT DISTINCT cve_grupo, grupo FROM sat_ClasificacionClavesSAT WHERE Cve_division = '{cbDivision.SelectedValue}'")
        ComboboxService.llenarCombobox(cbGrupo, tableGrupo, "cve_grupo", "grupo")
        If (cbTipoConcepto.Text = "SERVICIO") Then
            cbGrupo.SelectedValue = "86120000"
        End If
        cbGrupo_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub cbGrupo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbGrupo.SelectionChangeCommitted
        Dim tableClase As DataTable = db.getDataTableFromSQL($"SELECT DISTINCT cve_clase, clase FROM sat_ClasificacionClavesSAT WHERE cve_grupo = '{cbGrupo.SelectedValue}'")
        ComboboxService.llenarCombobox(cbClase, tableClase, "cve_clase", "clase")
        If (cbTipoConcepto.Text = "SERVICIO") Then
            cbClase.SelectedValue = "86121700"
        End If
        cbClase_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub cbClase_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClase.SelectionChangeCommitted
        Dim clave As String = cbClase.SelectedValue.ToString().Substring(0, cbClase.SelectedValue.ToString().Length() - 2) + "%"
        Dim tableProdServ As DataTable = db.getDataTableFromSQL($"SELECT ClaveProdServ, Descripcion FROM sat_CatClaveProdServSAT WHERE ClaveProdServ LIKE '{clave}'")
        ComboboxService.llenarCombobox(cbProdServ, tableProdServ, "ClaveProdServ", "Descripcion")
        If (cbTipoConcepto.Text = "SERVICIO") Then
            cbProdServ.SelectedValue = "86121700"
        End If
        cbProdServ_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub cbProdServ_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbProdServ.SelectionChangeCommitted
        Dim tableUnidad As DataTable = db.getDataTableFromSQL("SELECT id_claveProd, nombre FROM sat_cat_unidad")
        ComboboxService.llenarCombobox(cbUnidad, tableUnidad, "id_claveProd", "nombre")
    End Sub

    Private Sub cbConceptoPara_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbConceptoPara.SelectionChangeCommitted
        If (cbConceptoPara.Text = "EXTERNO") Then
            cbTipoPago.Enabled = True
            txtConcepto.Enabled = True
            txtDescripcion.Enabled = True
            txtValorUnitario.Enabled = True
            txtValorUnitarioSinIVA.Enabled = True
            chbConsideraIVA.Enabled = True
            chbExentaIVA.Enabled = True
            chbIncluyeIVA.Enabled = True

            lblNivel.Visible = False
            cbNivel.Visible = False
            lblTurno.Visible = False
            cbTurno.Visible = False
        Else
            lblNivel.Visible = True
            cbNivel.Visible = True

            cbTipoPago.Enabled = False
            txtConcepto.Enabled = False
            txtDescripcion.Enabled = False
            txtValorUnitario.Enabled = False
            txtValorUnitarioSinIVA.Enabled = False
            chbConsideraIVA.Enabled = False
            chbExentaIVA.Enabled = False
            chbIncluyeIVA.Enabled = False
        End If
    End Sub

    Private Sub cbNivel_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNivel.SelectionChangeCommitted
        lblTurno.Visible = True
        cbTurno.Visible = True

        Dim tableTurnos As DataTable = db.getDataTableFromSQL($"SELECT R.ID, N.Clave As ClaveN, T.clave as ClaveT, T.Turno FROM mov_Res_Nivel_Turno AS R
                                                               INNER JOIN mov_CatNivel AS N ON N.Clave = R.Clave_Nivel
                                                               INNER JOIN mov_CatTurno AS T ON T.clave = R.Clave_Turno
                                                               WHERE N.Clave = '{cbNivel.SelectedValue}'
                                                               ORDER BY R.ID")
        ComboboxService.llenarCombobox(cbTurno, tableTurnos, "ClaveT", "Turno")
    End Sub

    Private Sub cbTurno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTurno.SelectionChangeCommitted
        cbTipoPago.Enabled = True
        txtConcepto.Enabled = True
        txtDescripcion.Enabled = True
        txtValorUnitario.Enabled = True
        txtValorUnitarioSinIVA.Enabled = True
        chbConsideraIVA.Enabled = True
        chbExentaIVA.Enabled = True
        chbIncluyeIVA.Enabled = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtConcepto.Text = "") Then
            MessageBox.Show("Ingrese el nombre del concepto")
            Return
        ElseIf (txtDescripcion.Text = "") Then
            MessageBox.Show("Ingrese la descripción del concepto")
            Return
        ElseIf (txtValorUnitario.Text = "") Then
            MessageBox.Show("Ingrese el monto del concepto")
            Return
        End If

        Dim consideraIVA As Integer
        Dim agregaIVA As Integer
        Dim exentaIVA As Integer

        If (chbConsideraIVA.Checked = True) Then
            consideraIVA = 1
        Else
            consideraIVA = 0
        End If

        If (chbIncluyeIVA.Checked = True) Then
            agregaIVA = 1
        Else
            agregaIVA = 0
        End If

        If (chbExentaIVA.Checked = True) Then
            exentaIVA = 1
        Else
            exentaIVA = 0
        End If

        po.registrarPagoOpcional(txtConcepto.Text, txtDescripcion.Text, cbProdServ.SelectedValue, cbUnidad.SelectedValue, CDec(txtValorUnitario.Text), cbConceptoPara.Text, consideraIVA, agregaIVA, exentaIVA, cbTipoPago.SelectedValue, cbTurno.SelectedValue, cbNivel.SelectedValue)
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        RegistroPagosOpcionales_Load(Me, Nothing)
    End Sub
End Class