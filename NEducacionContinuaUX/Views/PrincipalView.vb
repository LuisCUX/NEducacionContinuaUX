Public Class PrincipalView
    Private Sub PrincipalView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        statusLabel.Text = User.getPerfil
        If (User.getPerfil = "DEV") Then
            ContabilidadToolStripMenuItem.Visible = True
            CobrosToolStripMenuItem.Visible = True
            CatálogosToolStripMenuItem.Visible = True
            ExternosToolStripMenuItem.Visible = True
            ExternosConPlanToolStripMenuItem.Visible = True
            HerramientasToolStripMenuItem.Visible = True
            ReportesToolStripMenuItem.Visible = True
            CongresosDiplomadosToolStripMenuItem.Visible = True
            DEVToolStripMenuItem.Visible = True
            ReportesCongresosDiplomadosToolStripMenuItem.Visible = True
        End If

        If (User.getPerfil = "Cajero") Then
            ContabilidadToolStripMenuItem.Visible = False
            CobrosToolStripMenuItem.Visible = True
            CatálogosToolStripMenuItem.Visible = True
            ExternosToolStripMenuItem.Visible = True
            ExternosConPlanToolStripMenuItem.Visible = True
            HerramientasToolStripMenuItem.Visible = True
            ReportesToolStripMenuItem.Visible = True
            CongresosDiplomadosToolStripMenuItem.Visible = False
            DEVToolStripMenuItem.Visible = False
            ReportesCongresosDiplomadosToolStripMenuItem.Visible = False
        End If

        If (User.getPerfil = "Contabilidad") Then
            ContabilidadToolStripMenuItem.Visible = True
            CobrosToolStripMenuItem.Visible = False
            CatálogosToolStripMenuItem.Visible = False
            ExternosToolStripMenuItem.Visible = False
            ExternosConPlanToolStripMenuItem.Visible = False
            HerramientasToolStripMenuItem.Visible = False
            ReportesToolStripMenuItem.Visible = False
            CongresosDiplomadosToolStripMenuItem.Visible = False
            DEVToolStripMenuItem.Visible = False
            ReportesCongresosDiplomadosToolStripMenuItem.Visible = False
        End If

        If (User.getPerfil = "Desarrollo Institucional") Then
            ContabilidadToolStripMenuItem.Visible = False
            CobrosToolStripMenuItem.Visible = False
            CatálogosToolStripMenuItem.Visible = False
            ExternosToolStripMenuItem.Visible = False
            ExternosConPlanToolStripMenuItem.Visible = False
            HerramientasToolStripMenuItem.Visible = False
            ReportesToolStripMenuItem.Visible = False
            CongresosDiplomadosToolStripMenuItem.Visible = True
            DEVToolStripMenuItem.Visible = False
            ReportesCongresosDiplomadosToolStripMenuItem.Visible = True
        End If
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

    Private Sub AltaYModificaciónDeExternosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaYModificaciónDeExternosToolStripMenuItem.Click
        RegistroExternosOldEDC.MdiParent = Me
        RegistroExternosOldEDC.Show()
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

    Private Sub ModificacionDeCostosDePlanesToolStripMenuItem_Click(sender As Object, e As EventArgs)
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

    Private Sub NotasDeCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        NotasDeCreditoEDC.MdiParent = Me
        NotasDeCreditoEDC.Show()
    End Sub

    Private Sub NotaDeCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeCreditoToolStripMenuItem.Click
        NotasDeCreditoEDC.MdiParent = Me
        NotasDeCreditoEDC.Show()
    End Sub

    Private Sub AltaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaToolStripMenuItem.Click
        ModalRegistroPagosOpcionalesEDC.MdiParent = Me
        ModalRegistroPagosOpcionalesEDC.Show()
    End Sub

    Private Sub ModificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaciónToolStripMenuItem.Click
        MainRegistroPagosOpcionalesEDC.MdiParent = Me
        MainRegistroPagosOpcionalesEDC.Show()
    End Sub

    Private Sub CatalogoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatalogoToolStripMenuItem.Click
        RegistroTipoPagosOpcionales.MdiParent = Me
        RegistroTipoPagosOpcionales.Show()
    End Sub

    Private Sub DesarrolloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesarrolloToolStripMenuItem.Click
        EnviromentService.getEnviroment("dev")
        MessageBox.Show("Ambiente cambiado a desarrollo")
    End Sub

    Private Sub ProduccionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProduccionToolStripMenuItem.Click
        EnviromentService.getEnviroment("prod")
        MessageBox.Show("Ambiente cambiado a producción")
    End Sub

    Private Sub Form1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Form1ToolStripMenuItem.Click
        Form1.MdiParent = Me
        Form1.Show()
    End Sub

    Private Sub GeneraciónDePólizaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneraciónDePólizaToolStripMenuItem.Click
        GenerarPolizaEDC.MdiParent = Me
        GenerarPolizaEDC.Show()
    End Sub

    Private Sub DescuentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescuentosToolStripMenuItem.Click
        ModificacionCostosPlanesEDC.MdiParent = Me
        ModificacionCostosPlanesEDC.Show()
    End Sub

    Private Sub ReportesCongresosDiplomadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportesCongresosDiplomadosToolStripMenuItem.Click
        ReportesCongresosDiplomados.MdiParent = Me
        ReportesCongresosDiplomados.Show()
    End Sub

    Private Sub SustitucioncambioDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SustitucioncambioDeDatosToolStripMenuItem.Click
        SustitucionDatosFiscalesEDC.MdiParent = Me
        SustitucionDatosFiscalesEDC.Show()
    End Sub

    Private Sub SustitucioncambioDeConceptoclaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SustitucioncambioDeConceptoclaveToolStripMenuItem.Click
        SustitucionConceptoEDC.MdiParent = Me
        SustitucionConceptoEDC.Show()
    End Sub
End Class