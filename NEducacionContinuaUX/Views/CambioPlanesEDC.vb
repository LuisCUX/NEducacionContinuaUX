Imports System.Text.RegularExpressions

Public Class CambioPlanesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim vc As ValidacionesController = New ValidacionesController()
    Dim ap As AsignacionPlanesController = New AsignacionPlanesController()
    Dim planID As Integer
    Dim Matricula As String
    Dim combo_filtro As String
    Dim combo_filtro2 As String
    Dim combo_filtro3 As String
    Private Sub CambioPlanesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar2_Click(sender As Object, e As EventArgs) Handles btnBuscar2.Click
        Matricula = txtMatricula2.Text
        ap.buscarMatriculaEC(Matricula, panelInfo2, panelPlan2, txtNombre2, txtEmail2, cbNuevoPlan)
        planID = db.exectSQLQueryScalar($"SELECT DISTINCT P.ID FROM ing_AsignacionCargosPlanes AS A 
                                                         INNER JOIN ing_PlanesConceptos AS C ON C.ID = A.ID_Concepto
                                                         INNER JOIN ing_Planes AS P ON P.ID = C.ID_Plan
                                                         WHERE A.Matricula = '{Matricula}' AND A.Activo = 1")
        If (planID < 1) Then
            MessageBox.Show("La matricula ingresada no tiene planes registrados")
            Me.Reiniciar()
            Exit Sub
        Else
            Try
                ap.llenarGridPagos(planID, GridPlanActual)
                cbNuevoPlan.DataSource = Nothing
                Dim tablePlanes As DataTable = db.getDataTableFromSQL($"SELECT P.ID, P.Nombre_Plan FROM portal_registroCongreso AS RC
                                                                INNER JOIN portal_tipoAsistente AS TA ON RC.id_tipo_asistente = TA.id_tipo_asistente
                                                                INNER JOIN portal_congreso AS C ON C.id_congreso = TA.id_congreso AND C.activo = 1
                                                                INNER JOIN ing_Planes AS P ON P.ID_Congreso = C.id_congreso AND P.Activo = 1
                                                                WHERE RC.clave_cliente = '{Matricula}' AND P.ID != {planID}")

                ComboboxService.llenarCombobox(cbNuevoPlan, tablePlanes, "ID", "Nombre_Plan")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cbNuevoPlan_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNuevoPlan.SelectionChangeCommitted
        Try
            ap.llenarGridPagos(cbNuevoPlan.SelectedValue, GridNuevoPlan)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar2_Click(sender As Object, e As EventArgs) Handles btnGuardar2.Click
        If (GridNuevoPlan.Rows.Count = 0) Then
            MessageBox.Show("Seleccione un plan")
            Exit Sub
        Else
            ap.cambiarPlanPagos(Matricula, GridNuevoPlan, planID)
        End If
    End Sub

    Private Sub cbNombre2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNombre2.SelectionChangeCommitted
        Try
            If (cbNombre2.SelectedIndex <> -1) Then
                txtMatricula2.Text = cbNombre2.SelectedValue
                btnBuscar2.PerformClick()
                txtMatricula2.Clear()
                cbNombre2.Text = ""
                combo_filtro2 = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbNombre2_KeyUp(sender As Object, e As KeyEventArgs) Handles cbNombre2.KeyUp
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            combo_filtro2 = cbNombre2.Text
        End If
    End Sub

    Private Sub cbNombre2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbNombre2.KeyPress
        Me.keypress_textos_cmb(cbNombre2, e)
        Dim kc As KeysConverter = New KeysConverter()
        Dim encontrar As String = cbNombre2.Text

        Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\´]", RegexOptions.IgnoreCase)
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If re.IsMatch(e.KeyChar) = False Then

            combo_filtro2 += kc.ConvertToString(e.KeyChar)
            Dim filtro As String = cbNombre2.Text
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"SELECT RC.clave_cliente, UPPER('Congreso: ' + C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                                INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
    											    WHERE (C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno LIKE '%{filtro}%')")
            ComboboxService.llenarCombobox(cbNombre2, tableFiltro, "clave_cliente", "NombreCliente")
            cbNombre2.SelectedValue = -1
            cbNombre2.Text = combo_filtro2
            cbNombre2.DroppedDown = True
            cbNombre2.SelectionStart = encontrar.Length
            cbNombre2.SelectionLength = cbNombre2.Text.Length - cbNombre2.SelectionStart
        Else
            If Asc(e.KeyChar) = Keys.Space Then
                combo_filtro2 += " "
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

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        CambioPlanesEDC_Load(Me, Nothing)
    End Sub
End Class