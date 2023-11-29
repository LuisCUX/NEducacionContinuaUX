<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PrincipalView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrincipalView))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CobrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CobrosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CobrosMultiplesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CobroDeCreditosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SustitucioncambioDeDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SustitucioncambioDeConceptoclaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotaDeCreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatálogosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltaDePagosOpcionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObservacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BancosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExternosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltaYModificaciónDeExternosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignaciónDePagosOpcionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutorizacionesYCondonacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExternosConPlanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignaciónDePlanesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambioDePlanesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReimpresiónDeFacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimbresUtilizadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelaciónDeFacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambioDeFormaDePagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContabilidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneraciónDePólizaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DEVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarConexiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesarrolloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProduccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Form1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CongresosDiplomadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescuentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificaciónDeDatosFiscalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesCongresosDiplomadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 728)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1423, 22)
        Me.StatusStrip.TabIndex = 1
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'statusLabel
        '
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(67, 17)
        Me.statusLabel.Text = "StatusLabel"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CobrosToolStripMenuItem, Me.CatálogosToolStripMenuItem, Me.ExternosToolStripMenuItem, Me.ExternosConPlanToolStripMenuItem, Me.HerramientasToolStripMenuItem, Me.ReportesToolStripMenuItem, Me.ContabilidadToolStripMenuItem, Me.DEVToolStripMenuItem, Me.CongresosDiplomadosToolStripMenuItem, Me.ReportesCongresosDiplomadosToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1423, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip"
        '
        'CobrosToolStripMenuItem
        '
        Me.CobrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CobrosToolStripMenuItem1, Me.CobrosMultiplesToolStripMenuItem, Me.CobroDeCreditosToolStripMenuItem, Me.SustitucioncambioDeDatosToolStripMenuItem, Me.SustitucioncambioDeConceptoclaveToolStripMenuItem, Me.NotaDeCreditoToolStripMenuItem})
        Me.CobrosToolStripMenuItem.Name = "CobrosToolStripMenuItem"
        Me.CobrosToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.CobrosToolStripMenuItem.Text = "Cobros"
        '
        'CobrosToolStripMenuItem1
        '
        Me.CobrosToolStripMenuItem1.Name = "CobrosToolStripMenuItem1"
        Me.CobrosToolStripMenuItem1.Size = New System.Drawing.Size(279, 22)
        Me.CobrosToolStripMenuItem1.Text = "Cobros"
        '
        'CobrosMultiplesToolStripMenuItem
        '
        Me.CobrosMultiplesToolStripMenuItem.Name = "CobrosMultiplesToolStripMenuItem"
        Me.CobrosMultiplesToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.CobrosMultiplesToolStripMenuItem.Text = "Cobros multiples"
        '
        'CobroDeCreditosToolStripMenuItem
        '
        Me.CobroDeCreditosToolStripMenuItem.Name = "CobroDeCreditosToolStripMenuItem"
        Me.CobroDeCreditosToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.CobroDeCreditosToolStripMenuItem.Text = "Pago de creditos"
        '
        'SustitucioncambioDeDatosToolStripMenuItem
        '
        Me.SustitucioncambioDeDatosToolStripMenuItem.Name = "SustitucioncambioDeDatosToolStripMenuItem"
        Me.SustitucioncambioDeDatosToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.SustitucioncambioDeDatosToolStripMenuItem.Text = "Sustitucion/cambio de datos"
        '
        'SustitucioncambioDeConceptoclaveToolStripMenuItem
        '
        Me.SustitucioncambioDeConceptoclaveToolStripMenuItem.Name = "SustitucioncambioDeConceptoclaveToolStripMenuItem"
        Me.SustitucioncambioDeConceptoclaveToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.SustitucioncambioDeConceptoclaveToolStripMenuItem.Text = "Sustitucion/cambio de concepto-clave"
        '
        'NotaDeCreditoToolStripMenuItem
        '
        Me.NotaDeCreditoToolStripMenuItem.Name = "NotaDeCreditoToolStripMenuItem"
        Me.NotaDeCreditoToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.NotaDeCreditoToolStripMenuItem.Text = "Nota de credito"
        '
        'CatálogosToolStripMenuItem
        '
        Me.CatálogosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlanesToolStripMenuItem, Me.AltaDePagosOpcionalesToolStripMenuItem, Me.ObservacionesToolStripMenuItem, Me.BancosToolStripMenuItem})
        Me.CatálogosToolStripMenuItem.Name = "CatálogosToolStripMenuItem"
        Me.CatálogosToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.CatálogosToolStripMenuItem.Text = "Catálogos"
        '
        'PlanesToolStripMenuItem
        '
        Me.PlanesToolStripMenuItem.Name = "PlanesToolStripMenuItem"
        Me.PlanesToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.PlanesToolStripMenuItem.Text = "Planes"
        '
        'AltaDePagosOpcionalesToolStripMenuItem
        '
        Me.AltaDePagosOpcionalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AltaToolStripMenuItem, Me.ModificaciónToolStripMenuItem, Me.CatalogoToolStripMenuItem})
        Me.AltaDePagosOpcionalesToolStripMenuItem.Name = "AltaDePagosOpcionalesToolStripMenuItem"
        Me.AltaDePagosOpcionalesToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AltaDePagosOpcionalesToolStripMenuItem.Text = "Pagos opcionales"
        '
        'AltaToolStripMenuItem
        '
        Me.AltaToolStripMenuItem.Name = "AltaToolStripMenuItem"
        Me.AltaToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.AltaToolStripMenuItem.Text = "Alta"
        '
        'ModificaciónToolStripMenuItem
        '
        Me.ModificaciónToolStripMenuItem.Name = "ModificaciónToolStripMenuItem"
        Me.ModificaciónToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.ModificaciónToolStripMenuItem.Text = "Modificación"
        '
        'CatalogoToolStripMenuItem
        '
        Me.CatalogoToolStripMenuItem.Name = "CatalogoToolStripMenuItem"
        Me.CatalogoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CatalogoToolStripMenuItem.Text = "Catálogo"
        '
        'ObservacionesToolStripMenuItem
        '
        Me.ObservacionesToolStripMenuItem.Name = "ObservacionesToolStripMenuItem"
        Me.ObservacionesToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ObservacionesToolStripMenuItem.Text = "Observaciones"
        '
        'BancosToolStripMenuItem
        '
        Me.BancosToolStripMenuItem.Name = "BancosToolStripMenuItem"
        Me.BancosToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.BancosToolStripMenuItem.Text = "Bancos"
        '
        'ExternosToolStripMenuItem
        '
        Me.ExternosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AltaYModificaciónDeExternosToolStripMenuItem, Me.AsignaciónDePagosOpcionalesToolStripMenuItem, Me.AutorizacionesYCondonacionesToolStripMenuItem})
        Me.ExternosToolStripMenuItem.Name = "ExternosToolStripMenuItem"
        Me.ExternosToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.ExternosToolStripMenuItem.Text = "Externos"
        '
        'AltaYModificaciónDeExternosToolStripMenuItem
        '
        Me.AltaYModificaciónDeExternosToolStripMenuItem.Name = "AltaYModificaciónDeExternosToolStripMenuItem"
        Me.AltaYModificaciónDeExternosToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AltaYModificaciónDeExternosToolStripMenuItem.Text = "Alta y modificación de externos"
        '
        'AsignaciónDePagosOpcionalesToolStripMenuItem
        '
        Me.AsignaciónDePagosOpcionalesToolStripMenuItem.Name = "AsignaciónDePagosOpcionalesToolStripMenuItem"
        Me.AsignaciónDePagosOpcionalesToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AsignaciónDePagosOpcionalesToolStripMenuItem.Text = "Asignación de pagos opcionales"
        '
        'AutorizacionesYCondonacionesToolStripMenuItem
        '
        Me.AutorizacionesYCondonacionesToolStripMenuItem.Name = "AutorizacionesYCondonacionesToolStripMenuItem"
        Me.AutorizacionesYCondonacionesToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AutorizacionesYCondonacionesToolStripMenuItem.Text = "Autorizaciones y condonaciones"
        '
        'ExternosConPlanToolStripMenuItem
        '
        Me.ExternosConPlanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsignaciónDePlanesToolStripMenuItem, Me.CambioDePlanesToolStripMenuItem})
        Me.ExternosConPlanToolStripMenuItem.Name = "ExternosConPlanToolStripMenuItem"
        Me.ExternosConPlanToolStripMenuItem.Size = New System.Drawing.Size(113, 20)
        Me.ExternosConPlanToolStripMenuItem.Text = "Externos con plan"
        '
        'AsignaciónDePlanesToolStripMenuItem
        '
        Me.AsignaciónDePlanesToolStripMenuItem.Name = "AsignaciónDePlanesToolStripMenuItem"
        Me.AsignaciónDePlanesToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AsignaciónDePlanesToolStripMenuItem.Text = "Asignación de planes"
        '
        'CambioDePlanesToolStripMenuItem
        '
        Me.CambioDePlanesToolStripMenuItem.Name = "CambioDePlanesToolStripMenuItem"
        Me.CambioDePlanesToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.CambioDePlanesToolStripMenuItem.Text = "Cambio de planes"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReimpresiónDeFacturasToolStripMenuItem, Me.TimbresUtilizadosToolStripMenuItem, Me.CancelaciónDeFacturasToolStripMenuItem, Me.CambioDeFormaDePagoToolStripMenuItem})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.HerramientasToolStripMenuItem.Text = "Herramientas"
        '
        'ReimpresiónDeFacturasToolStripMenuItem
        '
        Me.ReimpresiónDeFacturasToolStripMenuItem.Name = "ReimpresiónDeFacturasToolStripMenuItem"
        Me.ReimpresiónDeFacturasToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ReimpresiónDeFacturasToolStripMenuItem.Text = "Reimpresión de facturas"
        '
        'TimbresUtilizadosToolStripMenuItem
        '
        Me.TimbresUtilizadosToolStripMenuItem.Name = "TimbresUtilizadosToolStripMenuItem"
        Me.TimbresUtilizadosToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.TimbresUtilizadosToolStripMenuItem.Text = "Timbres utilizados"
        '
        'CancelaciónDeFacturasToolStripMenuItem
        '
        Me.CancelaciónDeFacturasToolStripMenuItem.Name = "CancelaciónDeFacturasToolStripMenuItem"
        Me.CancelaciónDeFacturasToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.CancelaciónDeFacturasToolStripMenuItem.Text = "Cancelación de facturas"
        '
        'CambioDeFormaDePagoToolStripMenuItem
        '
        Me.CambioDeFormaDePagoToolStripMenuItem.Name = "CambioDeFormaDePagoToolStripMenuItem"
        Me.CambioDeFormaDePagoToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.CambioDeFormaDePagoToolStripMenuItem.Text = "Cambio de forma de pago"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'ContabilidadToolStripMenuItem
        '
        Me.ContabilidadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneraciónDePólizaToolStripMenuItem})
        Me.ContabilidadToolStripMenuItem.Name = "ContabilidadToolStripMenuItem"
        Me.ContabilidadToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.ContabilidadToolStripMenuItem.Text = "Contabilidad"
        '
        'GeneraciónDePólizaToolStripMenuItem
        '
        Me.GeneraciónDePólizaToolStripMenuItem.Name = "GeneraciónDePólizaToolStripMenuItem"
        Me.GeneraciónDePólizaToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.GeneraciónDePólizaToolStripMenuItem.Text = "Generar póliza"
        '
        'DEVToolStripMenuItem
        '
        Me.DEVToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CambiarConexiónToolStripMenuItem, Me.Form1ToolStripMenuItem})
        Me.DEVToolStripMenuItem.Name = "DEVToolStripMenuItem"
        Me.DEVToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.DEVToolStripMenuItem.Text = "DEV"
        '
        'CambiarConexiónToolStripMenuItem
        '
        Me.CambiarConexiónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesarrolloToolStripMenuItem, Me.ProduccionToolStripMenuItem})
        Me.CambiarConexiónToolStripMenuItem.Name = "CambiarConexiónToolStripMenuItem"
        Me.CambiarConexiónToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CambiarConexiónToolStripMenuItem.Text = "Cambiar conexión"
        '
        'DesarrolloToolStripMenuItem
        '
        Me.DesarrolloToolStripMenuItem.Name = "DesarrolloToolStripMenuItem"
        Me.DesarrolloToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.DesarrolloToolStripMenuItem.Text = "Desarrollo"
        '
        'ProduccionToolStripMenuItem
        '
        Me.ProduccionToolStripMenuItem.Name = "ProduccionToolStripMenuItem"
        Me.ProduccionToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ProduccionToolStripMenuItem.Text = "Produccion"
        '
        'Form1ToolStripMenuItem
        '
        Me.Form1ToolStripMenuItem.Name = "Form1ToolStripMenuItem"
        Me.Form1ToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.Form1ToolStripMenuItem.Text = "form1"
        '
        'CongresosDiplomadosToolStripMenuItem
        '
        Me.CongresosDiplomadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DescuentosToolStripMenuItem, Me.ModificaciónDeDatosFiscalesToolStripMenuItem})
        Me.CongresosDiplomadosToolStripMenuItem.Name = "CongresosDiplomadosToolStripMenuItem"
        Me.CongresosDiplomadosToolStripMenuItem.Size = New System.Drawing.Size(144, 20)
        Me.CongresosDiplomadosToolStripMenuItem.Text = "Congresos/Diplomados"
        '
        'DescuentosToolStripMenuItem
        '
        Me.DescuentosToolStripMenuItem.Name = "DescuentosToolStripMenuItem"
        Me.DescuentosToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.DescuentosToolStripMenuItem.Text = "Descuentos"
        '
        'ModificaciónDeDatosFiscalesToolStripMenuItem
        '
        Me.ModificaciónDeDatosFiscalesToolStripMenuItem.Name = "ModificaciónDeDatosFiscalesToolStripMenuItem"
        Me.ModificaciónDeDatosFiscalesToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.ModificaciónDeDatosFiscalesToolStripMenuItem.Text = "Link para datos fiscales clave EC"
        Me.ModificaciónDeDatosFiscalesToolStripMenuItem.Visible = False
        '
        'ReportesCongresosDiplomadosToolStripMenuItem
        '
        Me.ReportesCongresosDiplomadosToolStripMenuItem.Name = "ReportesCongresosDiplomadosToolStripMenuItem"
        Me.ReportesCongresosDiplomadosToolStripMenuItem.Size = New System.Drawing.Size(193, 20)
        Me.ReportesCongresosDiplomadosToolStripMenuItem.Text = "Reportes Congresos/Diplomados"
        '
        'PrincipalView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.EDCLogo
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1423, 750)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "PrincipalView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Educacion Continua"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents statusLabel As ToolStripStatusLabel
    Friend WithEvents CobrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CobrosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CobrosMultiplesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CobroDeCreditosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SustitucioncambioDeDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SustitucioncambioDeConceptoclaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CatálogosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlanesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AltaDePagosOpcionalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObservacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BancosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExternosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AltaYModificaciónDeExternosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsignaciónDePagosOpcionalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutorizacionesYCondonacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExternosConPlanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsignaciónDePlanesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CambioDePlanesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HerramientasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReimpresiónDeFacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimbresUtilizadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelaciónDeFacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CambioDeFormaDePagoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotaDeCreditoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AltaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CatalogoToolStripMenuItem As ToolStripMenuItem
    Private WithEvents DEVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CambiarConexiónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DesarrolloToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProduccionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Form1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContabilidadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneraciónDePólizaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CongresosDiplomadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DescuentosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesCongresosDiplomadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificaciónDeDatosFiscalesToolStripMenuItem As ToolStripMenuItem
End Class
