Public Class PrincipalView
    Private Sub PrincipalView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        statusLabel.Text = User.getPerfil
    End Sub

    Private Sub RegistroDePagosOpcionalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDePagosOpcionalesToolStripMenuItem.Click
        MainPagosOpcionales.MdiParent = Me
        MainPagosOpcionales.Show()
    End Sub
End Class