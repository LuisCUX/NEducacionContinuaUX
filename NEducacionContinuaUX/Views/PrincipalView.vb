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

    Private Sub RegistroDePlanesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDePlanesToolStripMenuItem.Click
        PlanesEDC.MdiParent = Me
        PlanesEDC.Show()
    End Sub

    Private Sub AsignacionDePlanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignacionDePlanToolStripMenuItem.Click
        AsignacionPlanesoldEDC.MdiParent = Me
        AsignacionPlanesoldEDC.Show()
    End Sub

    Private Sub CobroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobroToolStripMenuItem.Click
        MainCobrosDiferidosEDC.MdiParent = Me
        MainCobrosDiferidosEDC.Show()
    End Sub

    Private Sub RegistroDeNotaDeCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeNotaDeCreditoToolStripMenuItem.Click
        NotasDeCreditoEDC.MdiParent = Me
        NotasDeCreditoEDC.Show()
    End Sub

    Private Sub EwewaewaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EwewaewaToolStripMenuItem.Click
        ConsultaTimbresService.EstatusTimbre()
    End Sub

    Private Sub PagosACreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagosACreditoToolStripMenuItem.Click
        PagosCreditoEDC.MdiParent = Me
        PagosCreditoEDC.Show()
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportesToolStripMenuItem.Click
        ReportesEDC.MdiParent = Me
        ReportesEDC.Show()
    End Sub

    Private Sub IVAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IVAToolStripMenuItem.Click
        IVAEDC.MdiParent = Me
        IVAEDC.Show()
    End Sub

    Private Sub ReimpresionDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReimpresionDeFacturasToolStripMenuItem.Click
        ReimpresionFacturasEDC.MdiParent = Me
        ReimpresionFacturasEDC.Show()
    End Sub

    Private Sub AsignaciónDePlanesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignaciónDePlanesToolStripMenuItem.Click
        AsignacionPlanesEDC.MdiParent = Me
        AsignacionPlanesEDC.Show()
    End Sub

    Private Sub CambioDePlanesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambioDePlanesToolStripMenuItem.Click
        CambioPlanesEDC.MdiParent = Me
        CambioPlanesEDC.Show()
    End Sub

    Private Sub ModificaciónDeCostosDePlanesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaciónDeCostosDePlanesToolStripMenuItem.Click
        ModificacionCostosPlanesEDC.MdiParent = Me
        ModificacionCostosPlanesEDC.Show()
    End Sub
End Class