Public Class ModalCobrosDiferidosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim co As CobrosController = New CobrosController()
    Dim va As ValidacionesController = New ValidacionesController()

    Private Sub ModalCobrosDiferidosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Limpiar()
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelPagos, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelPagos, txtNombre, txtEmail, txtCarrera, txtTurno)
        End If

        Tree.Nodes(1).Expand()
    End Sub


    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        ModalCobrosDiferidosEDC_Load(Me, Nothing)
    End Sub

    Sub Limpiar()
        txtNombre.Clear()
        txtEmail.Clear()
        txtCarrera.Clear()
        txtTurno.Clear()
        Tree.Nodes(0).Nodes.Clear()
        Tree.Nodes(1).Nodes.Clear()
        lblTotal.Text = ""
    End Sub

End Class