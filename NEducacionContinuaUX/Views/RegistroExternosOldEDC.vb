Imports System.Text.RegularExpressions

Public Class RegistroExternosOldEDC
    Dim re As GestionExternosController = New GestionExternosController()
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Public Shared matriculaExterna As Boolean
    Dim combo_filtro As String

    Private Sub RegistroExternosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        re.loadComboboxExternos(cbEstado, cbEstadoF, cbEstadoEd, cbEstadoFEd, cbExterno, cbEstadoEC, cbEstadoFEC)
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

    Sub LimpiarPanel(panel As Panel)
        For Each control As Control In panel.Controls
            If (control.Name.Substring(0, 3) = "txt") Then
                Dim txt As TextBox = control
                txt.Clear()
                txt.Enabled = True
            End If
        Next
    End Sub

    Private Sub btnGuardarN_Click(sender As Object, e As EventArgs) Handles btnGuardarN.Click
        Dim validaTXT As Object() = re.validaTextboxDatos(txtNombre, txtAp_Pat, txtAp_Mat, txtDireccion, txtColonia, txtCorreo, txtCP, txtTelefono, cbMunicipio)
        Dim validaCorreo As Object() = re.validaCorreo(txtCorreo.Text, "Nuevo", 0)
        Dim RFC As String = txtRFC.Text

        If (validaTXT(0) = False And matriculaExterna = False) Then
            MessageBox.Show(validaTXT(1))
            Return
        End If

        If (validaCorreo(0) = False) Then
            MessageBox.Show(validaCorreo(1))
            Return
        End If

        Dim datosFiscales As Boolean

        If (chbDatosFiscales.Checked = True) Then
            Dim validaFiscal As Object() = re.validaTextboxFiscal(txtRFC, txtNR, txtDireccionF, txtColoniaF, txtCiudad, txtCorreoF, txtCPF, txtTelefonoF, cbMunicipioF, cbRegimenFiscal, cbUsoCFDI)
            Dim idRFC As Integer = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_catRFC WHERE rfc = '{txtRFC.Text}'")
            If (idRFC > 0) Then
                RFC = db.exectSQLQueryScalar($"SELECT rfc FROM portal_catRFC WHERE id_rfc = {idRFC}")
            End If
            If (validaFiscal(0) = False) Then
                MessageBox.Show(validaFiscal(1))
                Return
            End If
            datosFiscales = True
        Else
            datosFiscales = False
        End If

        Dim tipocliente As Integer
        If (chbDatosFiscales.Checked = True) Then
            tipocliente = 1
        Else
            tipocliente = 2
        End If

        Dim idResRegCFDI As Integer = db.exectSQLQueryScalar($"SELECT id_res_usoCFDI_regimenFiscal FROM ing_res_usoCFDI_regimenFiscal WHERE clave_usoCFDI = '{cbUsoCFDI.SelectedValue}' AND clave_regimeFiscal = '{cbRegimenFiscal.SelectedValue}'")

        re.RegistroExterno(matriculaExterna, Matricula, txtCorreo.Text, txtNombre.Text, txtDireccion.Text, txtColonia.Text, txtCP.Text, cbMunicipio.SelectedValue, tipocliente, txtTelefono.Text, 104, txtAp_Pat.Text, txtAp_Mat.Text, lblMatriculaEXString.Text, chbDatosFiscales.Checked, RFC, txtDireccionF.Text, 0, txtColoniaF.Text, txtCPF.Text, txtCiudad.Text, txtTelefonoF.Text, txtCorreoF.Text, cbMunicipioF.SelectedValue, txtNR.Text, idResRegCFDI)
    End Sub

    Private Sub btnGuardarEdit_Click(sender As Object, e As EventArgs) Handles btnGuardarEdit.Click
        Dim validaTXT As Object() = re.validaTextboxDatos(txtNombreEd, txtAp_PatEd, txtAp_MatEd, txtDireccionEd, txtColoniaEd, txtCorreoEd, txtCPEd, txtTelefonoEd, cbMunicipioEd)
        Dim validaCorreo As Object() = re.validaCorreo(txtCorreoEd.Text, "Edicion", Matricula)

        If (validaTXT(0) = False) Then
            MessageBox.Show(validaTXT(1))
            Return
        End If

        If (chbDatosFiscales.Checked = True) Then
            Dim validaFiscal As Object() = re.validaTextboxFiscal(txtRFCEd, txtNREd, txtDireccionFEd, txtColoniaFEd, txtCiudadFEd, txtCorreoFEd, txtCPFEd, txtTelefonoFEd, cbMunicipioFEd, cbRegimenFiscalEd, cbUsoCFDIEd)
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

        re.EdicionExterno(txtMatriculaEd.Text, txtCorreoEd.Text, txtNombreEd.Text, txtDireccionEd.Text, txtColoniaEd.Text, txtCPEd.Text, cbMunicipioEd.SelectedValue, tipocliente, txtTelefonoEd.Text, 104, txtAp_PatEd.Text, txtAp_MatEd.Text, matriculaExterna, chbDatosFiscalesEdit.Checked, txtRFCEd.Text, txtDireccionFEd.Text, 0, txtColoniaFEd.Text, txtCPFEd.Text, txtCiudadFEd.Text, txtTelefonoFEd.Text, txtCorreoFEd.Text, cbMunicipioFEd.SelectedValue, txtNREd.Text, cbRegimenFiscalEd.SelectedValue, cbUsoCFDIEd.SelectedValue)
    End Sub

    Private Sub btnBuscarEd_Click(sender As Object, e As EventArgs) Handles btnBuscarEd.Click
        Me.LimpiarPanel(panelDatosPersonalesEdit)
        Me.LimpiarPanel(panelDatosFiscalesEdit)
        cbRFCEd.Items.Clear()
        cbEstadoEd.SelectedIndex = 0
        cbEstadoFEd.SelectedIndex = 0
        Try
            cbMunicipioEd.SelectedIndex = 0
            cbMunicipioFEd.DataSource = Nothing
        Catch ex As Exception

        End Try


        Matricula = txtMatriculaEd.Text
        re.buscarDatosMatriculaExterna(Matricula, txtNombreEd, txtAp_PatEd, txtAp_MatEd, txtDireccionEd, txtColoniaEd, cbEstadoEd, cbMunicipioEd, txtCorreoEd, txtCPEd, txtTelefonoEd,
                                       txtRFCEd, txtNREd, txtDireccionFEd, txtColoniaFEd, cbEstadoFEd, cbMunicipioFEd, txtCiudadFEd, txtCorreoFEd, txtCPFEd, txtTelefonoFEd, chbDatosFiscalesEdit, panelDatosPersonalesEdit, panelDatosFiscalesEdit, btnGuardarEdit, btnSalirEd, btnLimpiarEd, cbRFCEd)
        lblMatriculaEXEdString.Text = Matricula
    End Sub

    Private Sub btnBuscarEC_Click(sender As Object, e As EventArgs) Handles btnBuscarEC.Click
        Matricula = txtClaveEC.Text
        re.buscarDatosMatriculaEc(txtClaveEC.Text, txtNombreEC, txtApPaternoEC, txtApMaternoEC, txtDireccionEC, txtColoniaEC, cbEstadoEC, cbMunicipioEC, txtCorreoEC, txtCPEC, txtTelefonoEC,
                                  txtRFCFEC, txtRazonSocialFEC, txtDireccionFEC, txtColoniaFEC, cbEstadoFEC, cbMunicipioFEC, txtCiudadFEC, txtCorreoFEC, txtCPFEC, txtTelefonoFEC, chbDatosFiscalesEC, panelDatosPersonalesEC, panelDatosFiscalesEC, btnGuardarEC, btnSalirEC, btnLimpiarEC, cbRFCEC)
    End Sub

    Private Sub btnGuardarEC_Click(sender As Object, e As EventArgs) Handles btnGuardarEC.Click
        Dim validaTXT As Object() = re.validaTextboxDatos(txtNombreEC, txtApPaternoEC, txtApMaternoEC, txtDireccionEC, txtColoniaEC, txtCorreoEC, txtCPEC, txtTelefonoEC, cbMunicipioEC)
        Dim validaCorreo As Object() = re.validaCorreo(txtCorreoEd.Text, "Edicion", Matricula)

        If (validaTXT(0) = False) Then
            MessageBox.Show(validaTXT(1))
            Return
        End If

        If (chbDatosFiscalesEC.Checked = True) Then
            Dim validaFiscal As Object() = re.validaTextboxFiscal(txtRFCFEC, txtRazonSocialFEC, txtDireccionFEC, txtColoniaFEC, txtCiudadFEC, txtCorreoFEC, txtCPFEC, txtTelefonoFEC, cbMunicipioFEC, cbRegimenFiscalEC, cbUsoCFDIFEC)
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
        If (chbDatosFiscalesEC.Checked = True) Then
            tipocliente = 1
        Else
            tipocliente = 2
        End If

        re.EdicionEC(txtClaveEC.Text, txtCorreoEC.Text, txtNombreEC.Text, txtDireccionEC.Text, txtColoniaEC.Text, txtCPEC.Text, cbMunicipioEC.SelectedValue, tipocliente, txtTelefonoEC.Text, 104, txtApPaternoEC.Text, txtApMaternoEC.Text, chbDatosFiscalesEC.Checked,
                     txtRFCFEC.Text, txtDireccionFEC.Text, 0, txtColoniaFEC.Text, txtCPFEC.Text, txtCiudadFEC.Text, txtTelefonoFEC.Text, txtCorreoFEC.Text, cbMunicipioFEC.SelectedValue, txtRazonSocialFEC.Text, cbRegimenFiscalEC.SelectedValue, cbUsoCFDIFEC.SelectedValue)
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

    Private Sub cbEstadoEC_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbEstadoEC.SelectionChangeCommitted
        Dim tableMunicipiosEC As DataTable = db.getDataTableFromSQL($"SELECT id_municipio, nombre FROM portal_municipio WHERE id_estado = {cbEstadoEC.SelectedValue} ORDER BY nombre")
        ComboboxService.llenarCombobox(cbMunicipioEC, tableMunicipiosEC, "id_municipio", "nombre")
    End Sub

    Private Sub cbEstadoFEC_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbEstadoFEC.SelectionChangeCommitted
        Dim tableMunicipiosFEC As DataTable = db.getDataTableFromSQL($"SELECT id_municipio, nombre FROM portal_municipio WHERE id_estado = {cbEstadoFEC.SelectedValue} ORDER BY nombre")
        ComboboxService.llenarCombobox(cbMunicipioFEC, tableMunicipiosFEC, "id_municipio", "nombre")
    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectedIndexChanged
        Try
            Matricula = cbExterno.SelectedValue
            re.buscarDatosMatriculaExterna(cbExterno.SelectedValue, txtNombreEd, txtAp_PatEd, txtAp_MatEd, txtDireccionEd, txtColoniaEd, cbEstadoEd, cbMunicipioEd, txtCorreoEd, txtCPEd, txtTelefonoEd,
                                       txtRFCEd, txtNREd, txtDireccionFEd, txtColoniaFEd, cbEstadoFEd, cbMunicipioFEd, txtCiudadFEd, txtCorreoFEd, txtCPFEd, txtTelefonoFEd, chbDatosFiscalesEdit, panelDatosPersonalesEdit, panelDatosFiscalesEdit, btnGuardarEdit, btnSalirEd, btnLimpiarEd, cbRFCEd)
            lblMatriculaEXEdString.Text = Matricula
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbUX_KeyUp(sender As Object, e As KeyEventArgs) Handles cbUX.KeyUp
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            combo_filtro = cbUX.Text
        End If
    End Sub

    Private Sub cbUX_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbUX.KeyPress
        Me.keypress_textos_cmb(cbUX, e)
        Dim kc As KeysConverter = New KeysConverter()
        Dim encontrar As String = cbUX.Text

        Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\´]", RegexOptions.IgnoreCase)
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If re.IsMatch(e.KeyChar) = False Then

            combo_filtro += kc.ConvertToString(e.KeyChar)
            Dim filtro As String = cbUX.Text
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"SELECT H.matricula, UPPER(A.nombre + ' ' + A.ap_pat + ' ' + A.ap_mat) AS NombreAlumno FROM ux.dbo.dae_historia AS H 
                                                           INNER JOIN ux.dbo.dae_catAlumnos AS A ON A.matricula = H.matricula AND A.sit_esc != 'B'
                                                           INNER JOIN ux.dbo.dae_catPeriodos AS P ON P.activo = 1 AND P.actual = 1
                                                           INNER JOIN ux.dbo.dae_catCarreras AS C ON C.clave = H.carrera AND P.nivel = C.nivel AND P.turno = C.turno
                                                           WHERE H.fechaDeInscripcion IS NOT NULL AND H.periodo = P.periodo AND (A.nombre + ' ' + A.ap_pat + ' ' + A.ap_mat) LIKE '%{filtro}%'
                                                           ORDER BY A.nombre")
            ComboboxService.llenarCombobox(cbUX, tableFiltro, "matricula", "NombreAlumno")
            cbUX.SelectedValue = -1
            cbUX.Text = combo_filtro
            cbUX.DroppedDown = True
            cbUX.SelectionStart = encontrar.Length
            cbUX.SelectionLength = cbUX.Text.Length - cbUX.SelectionStart
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

    Private Sub cbUX_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbUX.SelectionChangeCommitted
        Try
            If (cbUX.SelectedIndex <> -1) Then
                Matricula = txtMatricula.Text
                re.buscaDatosMatriculaUX(cbUX.SelectedValue, txtNombre, txtAp_Pat, txtAp_Mat, txtDireccion, txtColonia, cbEstado, cbMunicipio, txtCorreo, txtCP, txtTelefono)
            End If

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

    Private Sub chbDatosFiscales_CheckedChanged(sender As Object, e As EventArgs) Handles chbDatosFiscalesEC.Click
        If (chbDatosFiscalesEC.Checked = True) Then
            Dim result As DialogResult = MessageBox.Show("Quiere usar los datos personales como datos fiscales?", "", MessageBoxButtons.YesNo)
            If (result = 6) Then
                txtDireccionFEC.Text = txtDireccionEC.Text
                txtColoniaFEC.Text = txtColoniaEC.Text
                txtCorreoFEC.Text = txtCorreoEC.Text
                txtCPFEC.Text = txtCPEC.Text
                txtTelefonoFEC.Text = txtTelefonoEC.Text
                cbEstadoFEC.SelectedValue = cbEstadoEC.SelectedValue
                Me.cbEstadoFEC_SelectionChangeCommitted(Nothing, Nothing)
                cbMunicipioFEC.SelectedValue = cbMunicipioEC.SelectedValue
            End If
            panelDatosFiscalesEC.Visible = True
        Else
            panelDatosFiscalesEC.Visible = False
        End If
    End Sub

    Private Sub chbDatosFiscalesEdit_CheckedChanged(sender As Object, e As EventArgs) Handles chbDatosFiscales.Click
        If (chbDatosFiscales.Checked = True) Then
            Dim result As DialogResult = MessageBox.Show("Quiere usar los datos personales como datos fiscales?", "", MessageBoxButtons.YesNo)
            If (result = 6) Then
                Try
                    txtDireccionF.Text = txtDireccion.Text
                    txtColoniaF.Text = txtColonia.Text
                    txtCorreoF.Text = txtCorreo.Text
                    txtCPF.Text = txtCP.Text
                    txtTelefonoF.Text = txtTelefono.Text
                    cbEstadoF.SelectedValue = cbEstado.SelectedValue
                    Me.cbEstadoF_SelectionChangeCommitted(Nothing, Nothing)
                    cbMunicipioF.SelectedValue = cbMunicipio.SelectedValue
                Catch ex As Exception

                End Try

            End If
            panelDatosFiscales.Visible = True
        Else
            panelDatosFiscales.Visible = False
        End If
    End Sub

    Private Sub chbDatosFiscalesEC_CheckedChanged(sender As Object, e As EventArgs) Handles chbDatosFiscalesEdit.Click
        If (chbDatosFiscalesEdit.Checked = True) Then
            Dim result As DialogResult = MessageBox.Show("Quiere usar los datos personales como datos fiscales?", "", MessageBoxButtons.YesNo)
            If (result = 6) Then
                Try
                    txtDireccionFEC.Text = txtDireccionEC.Text
                    txtColoniaFEd.Text = txtColoniaEC.Text
                    txtCorreoFEC.Text = txtCorreoEC.Text
                    txtCPFEC.Text = txtCPEC.Text
                    txtTelefonoFEC.Text = txtTelefonoEC.Text
                    cbEstadoFEC.SelectedValue = cbEstadoEC.SelectedValue
                    Me.cbEstadoFEC_SelectionChangeCommitted(Nothing, Nothing)
                    cbMunicipioFEC.SelectedValue = cbMunicipioEC.SelectedValue
                Catch ex As Exception

                End Try
            End If
            panelDatosFiscalesEdit.Visible = True
        Else
            panelDatosFiscalesEdit.Visible = False
        End If
    End Sub

    Sub commitCheckChangedFEC()
        chbDatosFiscales_CheckedChanged(Nothing, Nothing)
    End Sub

    Sub commitCheckChanged()
        chbDatosFiscalesEdit_CheckedChanged(Nothing, Nothing)
    End Sub

    Sub commitCheckChangedEC()
        chbDatosFiscalesEC_CheckedChanged(Nothing, Nothing)
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

    Sub commitChangeEstadoEC()
        cbEstadoEC_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Sub commitChangeEstadoFEC()
        cbEstadoFEC_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Sub commitChangeRFCEC()
        cbRFCEC_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Sub commitChangeRFCEd()
        cbRFCEd_SelectionChangeCommitted(Nothing, Nothing)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSalirEC.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnLimpiarEd.Click
        Me.Reiniciar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLimpiarEC.Click
        Me.Reiniciar()
    End Sub

    Private Sub cbRFCEd_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbRFCEd.SelectionChangeCommitted
        If (cbRFCEd.Text <> "Nuevo RFC") Then

            Dim IDRegistroCongreso As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")
            Dim IDResCFDIReg As Integer
            Dim tableDatosFiscales As DataTable = db.getDataTableFromSQL($"SELECT RFC.rfc, RC.direccion, RC.colonia, E.id_estado, M.id_municipio, RC.localidad, RC.razonsocial, RC.correo, RC.telefono, RC.cp, RC.id_res_cfdi_regimen FROM portal_reRFC AS RC 
                                                                           INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RC.id_rfc
                                                                           INNER JOIN portal_municipio AS M ON M.id_municipio = RC.id_municipio
                                                                           INNER JOIN portal_estado AS E ON E.id_estado = M.id_estado
                                                                           WHERE RC.id_registro = {IDRegistroCongreso} AND RFC.rfc = '{cbRFCEd.Text}'")

            For Each item As DataRow In tableDatosFiscales.Rows
                txtRFCEd.Text = item("rfc")
                txtRFCEd.Enabled = False
                txtNREd.Text = item("razonsocial")
                txtDireccionFEd.Text = item("direccion")
                txtColoniaFEd.Text = item("colonia")
                cbEstadoFEd.SelectedValue = item("id_estado")
                Me.commitChangeEstadoEditF()
                cbMunicipioFEd.SelectedValue = item("id_municipio")
                txtCiudadFEd.Text = item("localidad")
                txtCorreoFEd.Text = item("correo")
                txtCPFEd.Text = item("cp")
                txtTelefonoFEd.Text = item("telefono")
                IDResCFDIReg = item("id_res_cfdi_regimen")
            Next
            Dim RegFiscal = db.exectSQLQueryScalar($"SELECT clave_regimeFiscal FROM ing_res_usoCFDI_regimenFiscal WHERE id_res_usoCFDI_regimenFiscal = {IDResCFDIReg}")
            Dim UsoCFDI = db.exectSQLQueryScalar($"SELECT clave_usoCFDI FROM ing_res_usoCFDI_regimenFiscal WHERE id_res_usoCFDI_regimenFiscal = {IDResCFDIReg}")
            Try
                cbRegimenFiscalEd.SelectedValue = RegFiscal
                Me.cbRegimenFiscalEd_SelectionChangeCommitted(Nothing, Nothing)
                cbUsoCFDIEd.SelectedValue = UsoCFDI
            Catch ex As Exception
                cbUsoCFDIEd.SelectedIndex = -1
                cbRegimenFiscalEd.SelectedIndex = -1
            End Try
        Else
            txtRFCEd.Clear()
            txtRFCEd.Enabled = True
            txtNREd.Clear()
            txtDireccionFEd.Clear()
            txtColoniaFEd.Clear()
            txtCiudadFEd.Clear()
            txtCPFEd.Clear()
            txtCorreoFEd.Clear()
            txtTelefonoFEd.Clear()
            cbMunicipioFEd.SelectedIndex = -1
            cbEstadoFEd.SelectedIndex = -1
            cbUsoCFDIEd.SelectedIndex = -1
            cbRegimenFiscalEd.SelectedIndex = -1
        End If

    End Sub

    Private Sub cbRFCEC_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbRFCEC.SelectionChangeCommitted
        If (cbRFCEC.Text <> "Nuevo RFC") Then

            Dim IDRegistroCongreso As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
            Dim IDResCFDIReg As Integer
            Dim tableDatosFiscales As DataTable = db.getDataTableFromSQL($"SELECT RFC.rfc, RC.direccion, RC.colonia, E.id_estado, M.id_municipio, RC.localidad, RC.razonsocial, RC.correo, RC.telefono, RC.cp, RC.id_res_cfdi_regimen FROM portal_rcRFC AS RC 
                                                                           INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RC.id_rfc
                                                                           INNER JOIN portal_municipio AS M ON M.id_municipio = RC.id_municipio
                                                                           INNER JOIN portal_estado AS E ON E.id_estado = M.id_estado
                                                                           WHERE RC.id_registro = {IDRegistroCongreso} AND RFC.rfc = '{cbRFCEC.Text}'")

            For Each item As DataRow In tableDatosFiscales.Rows
                txtRFCFEC.Text = item("rfc")
                txtRFCFEC.Enabled = False
                txtRazonSocialFEC.Text = item("razonsocial")
                txtDireccionFEC.Text = item("direccion")
                txtColoniaFEC.Text = item("colonia")
                cbEstadoFEC.SelectedValue = item("id_estado")
                Me.commitChangeEstadoFEC()
                cbMunicipioFEC.SelectedValue = item("id_municipio")
                txtCiudadFEC.Text = item("localidad")
                txtCorreoFEC.Text = item("correo")
                txtCPFEC.Text = item("cp")
                txtTelefonoFEC.Text = item("telefono")
                IDResCFDIReg = item("id_res_cfdi_regimen")
            Next
            Dim RegFiscal = db.exectSQLQueryScalar($"SELECT clave_regimeFiscal FROM ing_res_usoCFDI_regimenFiscal WHERE id_res_usoCFDI_regimenFiscal = {IDResCFDIReg}")
            Dim UsoCFDI = db.exectSQLQueryScalar($"SELECT clave_usoCFDI FROM ing_res_usoCFDI_regimenFiscal WHERE id_res_usoCFDI_regimenFiscal = {IDResCFDIReg}")
            cbRegimenFiscalEC.SelectedValue = RegFiscal
            Me.cbRegimenFiscalEC_SelectionChangeCommitted(Nothing, Nothing)
            cbUsoCFDIFEC.SelectedValue = UsoCFDI
        Else
            txtRFCFEC.Clear()
            txtRFCFEC.Enabled = True
            txtRazonSocialFEC.Clear()
            txtDireccionFEC.Clear()
            txtColoniaFEC.Clear()
            txtCiudadFEC.Clear()
            txtCPFEC.Clear()
            txtCorreoFEC.Clear()
            txtTelefonoFEC.Clear()
            cbMunicipioFEC.SelectedIndex = -1
            cbEstadoFEC.SelectedIndex = -1
            cbUsoCFDIFEC.SelectedIndex = -1
            cbRegimenFiscalEC.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtRFC_TextChanged(sender As Object, e As EventArgs) Handles txtRFC.TextChanged
        Dim query As String
        If (txtRFC.Text.Length() = 13) Then ''FISICA
            query = $"SELECT ID_Contador, RegimenFiscal FROM ing_Cat_RegFis WHERE Fisica = 1"
        ElseIf (txtRFC.Text.Length() = 12) Then ''MORAL
            query = $"SELECT ID_Contador, RegimenFiscal FROM ing_Cat_RegFis WHERE Moral = 1"
        Else
            cbRegimenFiscal.DataSource = Nothing
            cbUsoCFDI.DataSource = Nothing
            Exit Sub
        End If

        Dim tableRegFis As DataTable = db.getDataTableFromSQL(query)
        ComboboxService.llenarCombobox(cbRegimenFiscal, tableRegFis, "ID_Contador", "RegimenFiscal")
    End Sub

    Private Sub txtRFCEd_TextChanged(sender As Object, e As EventArgs) Handles txtRFCEd.TextChanged
        Dim query As String
        If (txtRFCEd.Text.Length() = 12 Or txtRFCEd.Text.Length() = 13) Then ''FISICA
            If (txtRFCEd.Text.Length() = 13) Then
                query = $"SELECT ID_Contador, RegimenFiscal FROM ing_Cat_RegFis WHERE Fisica = 1"
            Else
                query = $"SELECT ID_Contador, RegimenFiscal FROM ing_Cat_RegFis WHERE Moral = 1"
            End If

            Dim IDRFC As Integer = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_catRFC WHERE rfc = '{txtRFCEd.Text}'")
            If (IDRFC > 2) Then

                Dim tableDatosRFC As DataTable = db.getDataTableFromSQL($"SELECT CAT.direccion, CAT.numero, CAT.colonia, CAT.cp, CAT.poblacion, CAT.localidad, CAT.telefono, CAT.correo, M.id_estado, CAT.id_municipio, CAT.razonsocial FROM portal_catRFC AS CAT
                                                                          INNER JOIN portal_municipio AS M ON M.id_municipio = CAT.id_municipio
                                                                          WHERE CAT.id_rfc = {IDRFC}")
                For Each item As DataRow In tableDatosRFC.Rows
                    txtDireccionFEd.Text = item("direccion")
                    txtColoniaFEd.Text = item("colonia")
                    txtCPFEd.Text = item("cp")
                    txtCiudadFEd.Text = item("poblacion")
                    txtTelefonoFEd.Text = item("telefono")
                    txtCorreoFEd.Text = item("correo")
                    txtNREd.Text = item("razonsocial")
                    cbEstadoFEd.SelectedValue = item("id_estado")
                    Me.cbEstadoFEd_SelectionChangeCommitted(Nothing, Nothing)
                    cbMunicipioFEd.SelectedValue = item("id_municipio")
                Next

            End If
        Else
            cbRegimenFiscalEd.DataSource = Nothing
            cbUsoCFDIEd.DataSource = Nothing
            Exit Sub
        End If

        Dim tableRegFis As DataTable = db.getDataTableFromSQL(query)
        ComboboxService.llenarCombobox(cbRegimenFiscalEd, tableRegFis, "ID_Contador", "RegimenFiscal")
    End Sub

    Private Sub txtRFCFEC_TextChanged(sender As Object, e As EventArgs) Handles txtRFCFEC.TextChanged
        Dim query As String
        If (txtRFCFEC.Text.Length() = 13) Then ''FISICA
            query = $"SELECT ID_Contador, RegimenFiscal FROM ing_Cat_RegFis WHERE Fisica = 1"
        ElseIf (txtRFCFEC.Text.Length() = 12) Then ''MORAL
            query = $"SELECT ID_Contador, RegimenFiscal FROM ing_Cat_RegFis WHERE Moral = 1"
        Else
            cbRegimenFiscalEC.DataSource = Nothing
            cbUsoCFDIFEC.DataSource = Nothing
            Exit Sub
        End If

        Dim tableRegFis As DataTable = db.getDataTableFromSQL(query)
        ComboboxService.llenarCombobox(cbRegimenFiscalEC, tableRegFis, "ID_Contador", "RegimenFiscal")
    End Sub

    Private Sub cbRegimenFiscal_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbRegimenFiscal.SelectionChangeCommitted
        Dim tableCFDI As DataTable = db.getDataTableFromSQL($"SELECT CF.clave_usoCFDI, CF.descripcion FROM ing_res_usoCFDI_regimenFiscal AS REG 
                                                              INNER JOIN ing_cat_usoCFDI AS CF ON CF.clave_usoCFDI = REG.clave_usoCFDI
                                                              WHERE REG.clave_regimeFiscal = '{cbRegimenFiscal.SelectedValue}'")
        ComboboxService.llenarCombobox(cbUsoCFDI, tableCFDI, "clave_usoCFDI", "descripcion")
    End Sub

    Private Sub cbRegimenFiscalEC_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbRegimenFiscalEC.SelectionChangeCommitted
        Dim tableCFDI As DataTable = db.getDataTableFromSQL($"SELECT CF.clave_usoCFDI, CF.descripcion FROM ing_res_usoCFDI_regimenFiscal AS REG 
                                                              INNER JOIN ing_cat_usoCFDI AS CF ON CF.clave_usoCFDI = REG.clave_usoCFDI
                                                              WHERE REG.clave_regimeFiscal = '{cbRegimenFiscalEC.SelectedValue}'")
        ComboboxService.llenarCombobox(cbUsoCFDIFEC, tableCFDI, "clave_usoCFDI", "descripcion")
    End Sub

    Private Sub cbRegimenFiscalEd_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbRegimenFiscalEd.SelectionChangeCommitted
        Dim tableCFDI As DataTable = db.getDataTableFromSQL($"SELECT CF.clave_usoCFDI, CF.descripcion FROM ing_res_usoCFDI_regimenFiscal AS REG 
                                                              INNER JOIN ing_cat_usoCFDI AS CF ON CF.clave_usoCFDI = REG.clave_usoCFDI
                                                              WHERE REG.clave_regimeFiscal = '{cbRegimenFiscalEd.SelectedValue}'")
        ComboboxService.llenarCombobox(cbUsoCFDIEd, tableCFDI, "clave_usoCFDI", "descripcion")
    End Sub

    Private Sub btnActualizarDatosFiscales_Click(sender As Object, e As EventArgs) Handles btnActualizarDatosFiscales.Click
        Dim MatriculaUX As String = db.exectSQLQueryScalar($"SELECT MatriculaUX FROM ing_catMatriculasUX WHERE MatriculaEX = '{txtMatriculaEd.Text}'")
        If (MatriculaUX Is Nothing) Then
            MessageBox.Show("La matricula ingresada no fue migrada desde la UX, ingrese una matricula válida")
            Exit Sub
        Else
            Dim tableDatosFiscales As DataTable = db.getDataTableFromSQL($"SELECT RFC.rfc, RES.direccion, RES.colonia, RES.estado, RES.municipio, RES.poblacion, RES.nombre, RES.correo, RES.cp, RES.tel, RES.clave_RegimenFiscal, RES.clave_USOCFDI FROM ux.dbo.ing_res_rfc_matricula AS RES
                                                                           INNER JOIN ux.dbo.ing_CatRFC AS RFC ON RFC.id_rfc = RES.id_rfc
                                                                           WHERE RES.matricula = '{MatriculaUX}' AND RES.activo = 1 AND RES.timbrar = 1")
            If (tableDatosFiscales.Rows.Count < 1) Then
                MessageBox.Show("No se encontraron datos fiscales de esta matricula")
                Exit Sub
            End If

            For Each item As DataRow In tableDatosFiscales.Rows
                txtRFCEd.Text = item("rfc")
                Me.commitChangeRFCEd()
                txtDireccionFEd.Text = item("direccion")
                txtColoniaFEd.Text = item("colonia")
                cbEstadoFEd.SelectedValue = item("estado")
                cbMunicipioFEd.SelectedValue = item("municipio")
                txtCiudadFEd.Text = item("poblacion")
                txtNREd.Text = item("nombre")
                txtCorreoFEd.Text = item("correo")
                txtCPFEd.Text = item("cp")
                txtTelefonoFEd.Text = item("tel")
                cbRegimenFiscalEd.SelectedValue = item("clave_RegimenFiscal")
                cbUsoCFDIEd.SelectedValue = item("clave_USOCFDI")
            Next
        End If
    End Sub

    ''

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal")) Then
    '        System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal")
    '    End If

    '    Try

    '        If (System.IO.File.Exists(config(3) & "\Documentos\ConstanciaFiscal\" & txtRFC.Text & ".pdf")) Then

    '            My.Computer.FileSystem.CopyFile(config(3) & "\Documentos\ConstanciaFiscal\" & txtRFC.Text & ".pdf",
    '            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal\" & txtRFC.Text & ".pdf",
    '            FileIO.UIOption.AllDialogs,
    '            FileIO.UICancelOption.ThrowException)

    '            ' Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal\" & txtrfc.Text & ".pdf")


    '            Dim doc As PdfDocument = New PdfDocument
    '            doc.LoadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal\" & txtRFC.Text & ".pdf")

    '            'Dim bmp As Image = doc.SaveAsImage(0)
    '            'Dim emf As Image = doc.SaveAsImage(0, Spire.Pdf.Graphics.PdfImageType.Metafile)


    '            Dim reader = New BarcodeReader()
    '            Dim barcodeBitmap As New Bitmap(doc.SaveAsImage(0))


    '            Dim Result = reader.Decode(barcodeBitmap)

    '            If Result IsNot Nothing Then

    '                Process.Start(Result.Text.ToString())
    '                Dim urlQR = Result.Text.ToString()

    '                ''    '----------------- scrapy quiza en un futuro

    '                'Try
    '                '    Dim listaTD As New List(Of String)
    '                '    Dim listaRFC As New List(Of String)
    '                '    Dim html As New HtmlDocument

    '                '    Dim Mirequest As HttpWebRequest = TryCast(WebRequest.Create(urlQR), HttpWebRequest)

    '                '    Dim Miresponse As HttpWebResponse = TryCast(Mirequest.GetResponse(), HttpWebResponse)
    '                '    Dim dtStream As Stream = Miresponse.GetResponseStream()
    '                '    Dim stReader As New StreamReader(dtStream, Encoding.UTF8) 'utf-8
    '                '    Dim responseFinal As String = stReader.ReadToEnd()

    '                '    Miresponse.Close()
    '                '    stReader.Close()

    '                '    html.LoadHtml(responseFinal)

    '                '    For Each node As HtmlNode In html.DocumentNode.SelectNodes("//tbody//tr//td")
    '                '        If (node.Attributes.Count = 2) Then
    '                '            If node.Attributes(1).Value.Equals("text-align:left;") Then
    '                '                listaTD.Add(node.InnerHtml)
    '                '            End If
    '                '        End If
    '                '    Next
    '                '    For Each node As HtmlNode In html.DocumentNode.SelectNodes("//ul//li")
    '                '        If (node.InnerText.Contains("RFC")) Then
    '                '            listaRFC.Add(node.InnerHtml)
    '                '        End If
    '                '    Next

    '                '    MsgBox("")
    '                'Catch ex As Exception

    '                'End Try

    '                ''-----------------

    '            End If

    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

End Class
