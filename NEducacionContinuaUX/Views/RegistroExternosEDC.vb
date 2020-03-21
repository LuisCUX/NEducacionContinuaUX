Public Class RegistroExternosEDC
    Dim re As GestionExternosController = New GestionExternosController()
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Public Shared matriculaExterna As Boolean

    Private Sub RegistroExternosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        re.loadComboboxExternos(cbEstado, cbEstadoF, cbEstadoEd, cbEstadoFEd, cbExterno, cbUX)
        lblMatriculaEXString.Text = re.obtenerNuevaMatricula()
        matriculaExterna = False
    End Sub

    Private Sub btnBuscarUX_Click(sender As Object, e As EventArgs) Handles btnBuscarUX.Click
        Matricula = txtMatricula.Text
        re.buscaDatosMatriculaUX(Matricula, txtNombre, txtAp_Pat, txtAp_Mat, txtDireccion, txtColonia, cbEstado, cbMunicipio, txtCorreo, txtCP, txtTelefono)
    End Sub

    Private Sub btnLimpiarUX_Click(sender As Object, e As EventArgs) Handles btnLimpiarUX.Click
        For Each control As Control In panelDatosPersonales.Controls
            If (control.Name.Substring(0, 3) = "txt") Then
                Dim txt As TextBox = control
                txt.Clear()
                txt.Enabled = True
            ElseIf (control.Name.Substring(0, 2) = "cb") Then
                Dim cb As ComboBox = control
                cb.SelectedIndex = -1
                cb.Enabled = True
            End If
        Next
        matriculaExterna = False
    End Sub

    Private Sub btnGuardarN_Click(sender As Object, e As EventArgs) Handles btnGuardarN.Click
        Dim validaTXT As Object() = re.validaTextboxDatos(txtNombre, txtAp_Pat, txtAp_Mat, txtDireccion, txtColonia, txtCorreo, txtCP, txtTelefono, cbMunicipio)
        Dim validaCorreo As Object() = re.validaCorreo(txtCorreo.Text, "Nuevo", 0)

        If (validaTXT(0) = False And matriculaExterna = False) Then
            MessageBox.Show(validaTXT(1))
            Return
        End If

        If (validaCorreo(0) = False) Then
            MessageBox.Show(validaCorreo(1))
            Return
        End If

        If (chbDatosFiscales.Checked = True) Then
            Dim validaFiscal As Object() = re.validaTextboxFiscal(txtRFC, txtNR, txtDireccionF, txtColoniaF, txtCiudad, txtCorreoF, txtCPF, txtTelefonoF, cbMunicipioF)
            If (validaFiscal(0) = False) Then
                MessageBox.Show(validaFiscal(1))
                Return
            End If
        End If

        Dim tipocliente As Integer
        If (chbDatosFiscales.Checked = True) Then
            tipocliente = 1
        Else
            tipocliente = 2
        End If

        re.RegistroExterno(matriculaExterna, Matricula, txtCorreo.Text, txtNombre.Text, txtDireccion.Text, txtColonia.Text, txtCP.Text, cbMunicipio.SelectedValue, tipocliente, txtTelefono.Text, 104, txtAp_Pat.Text, txtAp_Mat.Text, lblMatriculaEXString.Text, chbDatosFiscales.Checked, txtRFC.Text, txtDireccionF.Text, 0, txtColoniaF.Text, txtCPF.Text, txtCiudad.Text, txtTelefonoF.Text, txtCorreoF.Text, cbMunicipioF.SelectedValue, txtNR.Text)
    End Sub

    Private Sub btnGuardarEdit_Click(sender As Object, e As EventArgs) Handles btnGuardarEdit.Click
        Dim validaTXT As Object() = re.validaTextboxDatos(txtNombreEd, txtAp_PatEd, txtAp_MatEd, txtDireccionEd, txtColoniaEd, txtCorreoEd, txtCPEd, txtTelefonoEd, cbMunicipioEd)
        Dim validaCorreo As Object() = re.validaCorreo(txtCorreoEd.Text, "Edicion", Matricula)

        If (validaTXT(0) = False) Then
            MessageBox.Show(validaTXT(1))
            Return
        End If

        If (chbDatosFiscales.Checked = True) Then
            Dim validaFiscal As Object() = re.validaTextboxFiscal(txtRFCEd, txtNREd, txtDireccionFEd, txtColoniaFEd, txtCiudadFEd, txtCorreoFEd, txtCPFEd, txtTelefonoFEd, cbMunicipioFEd)
            If (validaFiscal(0) = False) Then
                MessageBox.Show(validaFiscal(1))
                Return
            End If
        End If

        If (validaCorreo(0) = False) Then
            MessageBox.Show(validaCorreo(1))
            Return
        End If

        Dim tipocliente As Integer
        If (chbDatosFiscales.Checked = True) Then
            tipocliente = 1
        Else
            tipocliente = 2
        End If

        re.EdicionExterno(txtMatriculaEd.Text, txtCorreoEd.Text, txtNombreEd.Text, txtDireccionEd.Text, txtColoniaEd.Text, txtCPEd.Text, cbMunicipioEd.SelectedValue, tipocliente, txtTelefonoEd.Text, 104, txtAp_PatEd.Text, txtAp_MatEd.Text, matriculaExterna, chbDatosFiscalesEdit.Checked, txtRFCEd.Text, txtDireccionFEd.Text, 0, txtColoniaFEd.Text, txtCPFEd.Text, txtCiudadFEd.Text, txtTelefonoFEd.Text, txtCorreoFEd.Text, cbMunicipioFEd.SelectedValue, txtNREd.Text)
    End Sub

    Private Sub btnBuscarEd_Click(sender As Object, e As EventArgs) Handles btnBuscarEd.Click
        Matricula = txtMatricula.Text
        re.buscarDatosMatriculaExterna(txtMatriculaEd.Text, txtNombreEd, txtAp_PatEd, txtAp_MatEd, txtDireccionEd, txtColoniaEd, cbEstadoEd, cbMunicipioEd, txtCorreoEd, txtCPEd, txtTelefonoEd,
                                       txtRFCEd, txtNREd, txtDireccionFEd, txtColoniaFEd, cbEstadoFEd, cbMunicipioFEd, txtCiudadFEd, txtCorreoFEd, txtCPFEd, txtTelefonoFEd, chbDatosFiscalesEdit, panelDatosPersonalesEdit, panelDatosFiscalesEdit, btnGuardarEdit, btnSalirEd)
        lblMatriculaEXEdString.Text = Matricula
    End Sub

    Private Sub cbEstado_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbEstado.SelectionChangeCommitted
        Dim tableMunicipios As DataTable = db.getDataTableFromSQL($"SELECT id_municipio, nombre FROM portal_municipio WHERE id_estado = {cbEstado.SelectedValue} ORDER BY nombre")
        ComboboxService.llenarCombobox(cbMunicipio, tableMunicipios, "id_municipio", "nombre")
    End Sub

    Private Sub cbEstadoF_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbEstadoF.SelectionChangeCommitted
        Dim tableMunicipiosF As DataTable = db.getDataTableFromSQL($"SELECT id_municipio, nombre FROM portal_municipio WHERE id_estado = {cbEstadoF.SelectedValue} ORDER BY nombre")
        ComboboxService.llenarCombobox(cbMunicipioF, tableMunicipiosF, "id_municipio", "nombre")
    End Sub

    Private Sub cbEstadoEd_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbEstadoEd.SelectionChangeCommitted
        Dim tableMunicipiosEd As DataTable = db.getDataTableFromSQL($"SELECT id_municipio, nombre FROM portal_municipio WHERE id_estado = {cbEstadoEd.SelectedValue} ORDER BY nombre")
        ComboboxService.llenarCombobox(cbMunicipioEd, tableMunicipiosEd, "id_municipio", "nombre")
    End Sub

    Private Sub cbEstadoFEd_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbEstadoFEd.SelectionChangeCommitted
        Dim tableMunicipiosFEd As DataTable = db.getDataTableFromSQL($"SELECT id_municipio, nombre FROM portal_municipio WHERE id_estado = {cbEstadoFEd.SelectedValue} ORDER BY nombre")
        ComboboxService.llenarCombobox(cbMunicipioFEd, tableMunicipiosFEd, "id_municipio", "nombre")
    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectedIndexChanged
        Try
            Matricula = cbExterno.SelectedValue
            re.buscarDatosMatriculaExterna(cbExterno.SelectedValue, txtNombreEd, txtAp_PatEd, txtAp_MatEd, txtDireccionEd, txtColoniaEd, cbEstadoEd, cbMunicipioEd, txtCorreoEd, txtCPEd, txtTelefonoEd,
                                       txtRFCEd, txtNREd, txtDireccionFEd, txtColoniaFEd, cbEstadoFEd, cbMunicipioFEd, txtCiudadFEd, txtCorreoFEd, txtCPFEd, txtTelefonoFEd, chbDatosFiscalesEdit, panelDatosPersonalesEdit, panelDatosFiscalesEdit, btnGuardarEdit, btnSalirEd)
            lblMatriculaEXEdString.Text = Matricula
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbUX_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbUX.SelectedIndexChanged
        Try
            Matricula = txtMatricula.Text
            re.buscaDatosMatriculaUX(cbUX.SelectedValue, txtNombre, txtAp_Pat, txtAp_Mat, txtDireccion, txtColonia, cbEstado, cbMunicipio, txtCorreo, txtCP, txtTelefono)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_KeyPressNumber(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress, txtTelefono.KeyPress, txtCPF.KeyPress, txtTelefonoF.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress, txtNombre.KeyPress, txtAp_Pat.KeyPress, txtAp_Mat.KeyPress, txtDireccion.KeyPress, txtColonia.KeyPress, txtCP.KeyPress, txtCorreo.KeyPress, txtTelefono.KeyPress,
        txtRFC.KeyPress, txtNR.KeyPress, txtDireccionF.KeyPress, txtColoniaF.KeyPress, txtCiudad.KeyPress, txtCorreoF.KeyPress, txtCPF.KeyPress, txtTelefonoF.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_KeyEditPress(sender As Object, e As KeyPressEventArgs) Handles txtMatriculaEd.KeyPress, txtNombreEd.KeyPress, txtAp_PatEd.KeyPress, txtAp_MatEd.KeyPress, txtDireccionEd.KeyPress, txtColoniaEd.KeyPress, txtCPEd.KeyPress, txtCorreoEd.KeyPress, txtTelefonoEd.KeyPress,
        txtRFCEd.KeyPress, txtNR.KeyPress, txtDireccionFEd.KeyPress, txtColoniaFEd.KeyPress, txtCiudadFEd.KeyPress, txtCorreoFEd.KeyPress, txtCPFEd.KeyPress, txtTelefonoFEd.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub panelDatosFiscales_Paint(sender As Object, e As PaintEventArgs) Handles panelDatosFiscales.Paint
        Dim r As New Rectangle(New Point(0, 0), New Size(sender.Width - 3, sender.Height - 3))
        Dim p As New Pen(Brushes.DarkGray, 4)
        e.Graphics.DrawRectangle(p, r)
    End Sub

    Private Sub panelDatosPersonales_Paint(sender As Object, e As PaintEventArgs) Handles panelDatosPersonales.Paint
        Dim r As New Rectangle(New Point(0, 0), New Size(sender.Width - 3, sender.Height - 3))
        Dim p As New Pen(Brushes.DarkGray, 4)
        e.Graphics.DrawRectangle(p, r)
    End Sub

    Private Sub panelDatosFiscalesEdit_Paint(sender As Object, e As PaintEventArgs) Handles panelDatosFiscalesEdit.Paint
        Dim r As New Rectangle(New Point(0, 0), New Size(sender.Width - 3, sender.Height - 3))
        Dim p As New Pen(Brushes.DarkGray, 4)
        e.Graphics.DrawRectangle(p, r)
    End Sub

    Private Sub panelDatosPersonalesEdit_Paint(sender As Object, e As PaintEventArgs) Handles panelDatosPersonalesEdit.Paint
        Dim r As New Rectangle(New Point(0, 0), New Size(sender.Width - 3, sender.Height - 3))
        Dim p As New Pen(Brushes.DarkGray, 4)
        e.Graphics.DrawRectangle(p, r)
    End Sub

    Private Sub chbDatosFiscales_CheckedChanged(sender As Object, e As EventArgs) Handles chbDatosFiscales.CheckedChanged
        If (chbDatosFiscales.Checked = True) Then
            panelDatosFiscales.Visible = True
        Else
            panelDatosFiscales.Visible = False
        End If
    End Sub

    Private Sub chbDatosFiscalesEdit_CheckedChanged(sender As Object, e As EventArgs) Handles chbDatosFiscalesEdit.CheckedChanged
        If (chbDatosFiscalesEdit.Checked = True) Then
            panelDatosFiscalesEdit.Visible = True
        Else
            panelDatosFiscalesEdit.Visible = False
        End If
    End Sub

    Sub commitCheckChanged()
        chbDatosFiscalesEdit_CheckedChanged(Nothing, Nothing)
    End Sub

    Sub commitChangeEstado()
        cbEstado_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Sub commitChangeEstadoEdit()
        cbEstadoEd_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Sub commitChangeEstadoEditF()
        cbEstadoFEd_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        RegistroExternosEDC_Load(Me, Nothing)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnSalirEd_Click(sender As Object, e As EventArgs) Handles btnSalirEd.Click
        Me.Close()
    End Sub
End Class
