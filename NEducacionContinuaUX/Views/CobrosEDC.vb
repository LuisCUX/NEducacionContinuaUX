Public Class CobrosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim co As CobrosController = New CobrosController()
    Private Sub CobrosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tree.ImageList = ImageListTree
        Tree.Nodes(0).ImageIndex = 2
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        tipoMatricula = co.validarMatricula(Matricula)
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            co.buscarMatriculaUX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
            Dim tablePagos As DataTable = db.getDataTableFromSQL($"SELECT A.ID, P.Nombre, A.costoUnitario, A.Cantidad, (costoUnitario * Cantidad) AS Total FROM ing_AsignacionPagoOpcionalAlumno AS A
                                                                  INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                                  INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                              WHERE A.Activo = 1 AND A.Matricula = '{Matricula}'")
            Tree.Nodes(0).Nodes.Add("LEL|LEL|LEL").ImageIndex = 0
            Tree.Nodes(0).Expand()
        ElseIf (tipoMatricula = "EC") Then

        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        CobrosEDC_Load(Me, Nothing)
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub
End Class