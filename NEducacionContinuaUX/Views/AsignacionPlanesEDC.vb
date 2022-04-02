Imports System.Text.RegularExpressions
Public Class AsignacionPlanesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim vc As ValidacionesController = New ValidacionesController()
    Dim ap As AsignacionPlanesController = New AsignacionPlanesController()
    Dim planID As Integer
    Dim Matricula As String
    Dim combo_filtro As String
    Private Sub AsignacionPlanesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        ap.buscarMatriculaEC(Matricula, panelDatos, panelRegistro, txtNombre, txtEmail, cbPlanes)
        planID = db.exectSQLQueryScalar($"SELECT DISTINCT P.ID FROM ing_AsignacionCargosPlanes AS A 
                                                         INNER JOIN ing_PlanesConceptos AS C ON C.ID = A.ID_Concepto
                                                         INNER JOIN ing_Planes AS P ON P.ID = C.ID_Plan
                                                         WHERE A.Matricula = '{Matricula}' AND A.Activo = 1")
        If (planID > 0) Then
            MessageBox.Show("La clave ingresada ya tiene un plan asignado")
            txtMatricula.Clear()
            Me.Reiniciar()
            Exit Sub
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ap.asignarPagosMatricula(Matricula, GridPagos)
    End Sub

    Private Sub cbPlanes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbPlanes.SelectionChangeCommitted
        Try
            ap.llenarGridPagos(cbPlanes.SelectedValue, GridPagos)
        Catch ex As Exception

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
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"SELECT RC.clave_cliente, UPPER('Congreso: ' + C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                                INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
    											    WHERE (C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno LIKE '%{filtro}%')")
            ComboboxService.llenarComboboxVacio(cbExterno, tableFiltro, "clave_cliente", "NombreCliente")
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

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        AsignacionPlanesEDC_Load(Me, Nothing)
        txtMatricula.Focus()
    End Sub
End Class