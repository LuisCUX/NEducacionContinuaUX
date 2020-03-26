Public Class AutorizacionCondonacionEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim ac As AutorizacionCondonacionController = New AutorizacionCondonacionController()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim ca As CargosController = New CargosController()
    Dim va As ValidacionesController = New ValidacionesController()

    Private Sub AutorizacionCondonacionEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ac.llenarComboboxes(cbTipoCondonacion)
    End Sub

    Private Sub cbTipoCondonacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoCondonacion.SelectionChangeCommitted
        ac.ActualizarArbolCondonacion(TreeCondonaciones, cbTipoCondonacion.Text, Matricula, tipoMatricula)
        If (cbTipoCondonacion.Text = "CONDONACIÓN TOTAL") Then
            lblPorcentaje.Visible = False
            txtPorcentaje.Visible = False
        ElseIf (cbTipoCondonacion.Text = "CONDONACIÓN PARCIAL") Then
            lblPorcentaje.Visible = True
            txtPorcentaje.Visible = True
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.limpiar()
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        txtMatriculaDato.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelAutCon, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelAutCon, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelAutCon, txtNombre, txtEmail, txtCarrera, txtTurno)
        End If
    End Sub

    Private Sub TreeCondonaciones_DoubleClick(sender As Object, e As EventArgs) Handles TreeCondonaciones.DoubleClick
        Me.NodosCondonaciones()
    End Sub


    Sub NodosCondonaciones()
        If (TreeCondonaciones.SelectedNode Is Nothing) Then
            Exit Sub
        End If

        Dim index As Integer = TreeCondonaciones.SelectedNode.Index
        If (TreeCondonaciones.SelectedNode.Checked = False) Then
            TreeCondonaciones.SelectedNode.Checked = True
            TreeCondonaciones.SelectedNode.SelectedImageIndex = 1
        Else
            TreeCondonaciones.SelectedNode.Checked = False
            TreeCondonaciones.SelectedNode.SelectedImageIndex = 0
        End If
    End Sub

    Sub limpiar()
        txtMatriculaDato.Clear()
        txtNombre.Clear()
        txtEmail.Clear()
        txtCarrera.Clear()
        txtTurno.Clear()
        TreeCondonaciones.Nodes.Clear()
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        AutorizacionCondonacionEDC_Load(Me, Nothing)
    End Sub
End Class