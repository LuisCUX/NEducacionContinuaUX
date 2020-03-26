Public Class PrincipalView
    Private Sub PrincipalView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        statusLabel.Text = User.getPerfil
    End Sub

    Private Sub RegistroDePagosOpcionalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDePagosOpcionalesToolStripMenuItem.Click
        MainRegistroPagosOpcionalesEDC.MdiParent = Me
        MainRegistroPagosOpcionalesEDC.Show()
    End Sub

    Private Sub AsignacionDePagosOpcionalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignacionDePagosOpcionalesToolStripMenuItem.Click
        MainAsignacionPagosOpcionalesEDC.MdiParent = Me
        MainAsignacionPagosOpcionalesEDC.Show()
    End Sub

    Private Sub CobrosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CobrosToolStripMenuItem1.Click
        CobrosEDC.MdiParent = Me
        CobrosEDC.Show()
    End Sub

    Private Sub GestionDeExternosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionDeExternosToolStripMenuItem.Click
        RegistroExternosEDC.MdiParent = Me
        RegistroExternosEDC.Show()
    End Sub

    Private Sub AutorizacionesYCondonacionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AutorizacionesYCondonacionesToolStripMenuItem1.Click
        AutorizacionCondonacionEDC.MdiParent = Me
        AutorizacionCondonacionEDC.Show()
    End Sub
End Class