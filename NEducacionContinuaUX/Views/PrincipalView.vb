Public Class PrincipalView
    Private Sub PrincipalView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        statusLabel.Text = User.getPerfil
    End Sub

    Private Sub CobrosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CobrosToolStripMenuItem1.Click
        CobrosEDC.MdiParent = Me
        CobrosEDC.Show()
    End Sub

    Private Sub CobrosMultiplesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobrosMultiplesToolStripMenuItem.Click
        MainCobrosDiferidosEDC.MdiParent = Me
        MainCobrosDiferidosEDC.Show()
    End Sub

    Private Sub CobroDeCreditosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobroDeCreditosToolStripMenuItem.Click
        PagosCreditoEDC.MdiParent = Me
        PagosCreditoEDC.Show()
    End Sub

    Private Sub PlanesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanesToolStripMenuItem.Click
        PlanesEDC.MdiParent = Me
        PlanesEDC.Show()
    End Sub

    Private Sub AltaDePagosOpcionalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaDePagosOpcionalesToolStripMenuItem.Click
        MainRegistroPagosOpcionalesEDC.MdiParent = Me
        MainRegistroPagosOpcionalesEDC.Show()
    End Sub

    Private Sub AltaYModificaciónDeExternosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaYModificaciónDeExternosToolStripMenuItem.Click
        RegistroExternosEDC.MdiParent = Me
        RegistroExternosEDC.Show()
    End Sub

    Private Sub AsignaciónDePagosOpcionalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignaciónDePagosOpcionalesToolStripMenuItem.Click
        MainAsignacionPagosOpcionalesEDC.MdiParent = Me
        MainAsignacionPagosOpcionalesEDC.Show()
    End Sub

    Private Sub AutorizacionesYCondonacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizacionesYCondonacionesToolStripMenuItem.Click
        AutorizacionCondonacionEDC.MdiParent = Me
        AutorizacionCondonacionEDC.Show()
    End Sub

    Private Sub AsignaciónDePlanesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignaciónDePlanesToolStripMenuItem.Click
        AsignacionPlanesEDC.MdiParent = Me
        AsignacionPlanesEDC.Show()
    End Sub

    Private Sub CambioDePlanesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambioDePlanesToolStripMenuItem.Click
        CambioPlanesEDC.MdiParent = Me
        CambioPlanesEDC.Show()
    End Sub

    Private Sub ModificacionDeCostosDePlanesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificacionDeCostosDePlanesToolStripMenuItem.Click
        ModificacionCostosPlanesEDC.MdiParent = Me
        ModificacionCostosPlanesEDC.Show()
    End Sub

    Private Sub ReimpresiónDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReimpresiónDeFacturasToolStripMenuItem.Click
        ReimpresionFacturasEDC.MdiParent = Me
        ReimpresionFacturasEDC.Show()
    End Sub

    Private Sub TimbresUtilizadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimbresUtilizadosToolStripMenuItem.Click
        ConsultaTimbresService.EstatusTimbre()
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportesToolStripMenuItem.Click
        ReportesEDC.MdiParent = Me
        ReportesEDC.Show()
    End Sub

    Private Sub BancosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BancosToolStripMenuItem.Click
        BancosEDC.MdiParent = Me
        BancosEDC.Show()
    End Sub

    Private Sub CambioDeFormaDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambioDeFormaDePagoToolStripMenuItem.Click
        CambioFormaPagoEDC.MdiParent = Me
        CambioFormaPagoEDC.Show()
    End Sub

    Private Sub CancelaciónDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelaciónDeFacturasToolStripMenuItem.Click
        CancelacionFacturasEDC.MdiParent = Me
        CancelacionFacturasEDC.Show()
    End Sub

    Private Sub ObservacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObservacionesToolStripMenuItem.Click
        ObservacionesEDC.MdiParent = Me
        ObservacionesEDC.Show()
    End Sub

    Private Sub NotasDeCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotasDeCreditoToolStripMenuItem.Click
        NotasDeCreditoEDC.MdiParent = Me
        NotasDeCreditoEDC.Show()
    End Sub
End Class