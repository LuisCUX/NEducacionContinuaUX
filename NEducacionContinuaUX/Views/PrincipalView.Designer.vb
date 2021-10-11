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
        Me.CobroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagosACreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotasDeCreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeNotaDeCreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutorizacionesYCondonacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutorizacionesYCondonacionesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagosOpcionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDePagosOpcionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignacionDePagosOpcionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanesDeDiplomadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDePlanesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignacionDePlanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosAlumnosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignaciónDePlanesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambioDePlanesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificaciónDeCostosDePlanesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CatalogosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionDeExternosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EwewaewaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IVAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReimpresionDeFacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CobrosToolStripMenuItem, Me.NotasDeCreditoToolStripMenuItem, Me.AutorizacionesYCondonacionesToolStripMenuItem, Me.PagosOpcionalesToolStripMenuItem, Me.PlanesDeDiplomadosToolStripMenuItem, Me.MovimientosAlumnosToolStripMenuItem, Me.CatalogosToolStripMenuItem, Me.ReportesToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1423, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip"
        '
        'CobrosToolStripMenuItem
        '
        Me.CobrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CobrosToolStripMenuItem1, Me.CobroToolStripMenuItem, Me.PagosACreditoToolStripMenuItem})
        Me.CobrosToolStripMenuItem.Name = "CobrosToolStripMenuItem"
        Me.CobrosToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.CobrosToolStripMenuItem.Text = "Cobros"
        '
        'CobrosToolStripMenuItem1
        '
        Me.CobrosToolStripMenuItem1.Name = "CobrosToolStripMenuItem1"
        Me.CobrosToolStripMenuItem1.Size = New System.Drawing.Size(164, 22)
        Me.CobrosToolStripMenuItem1.Text = "Cobros"
        '
        'CobroToolStripMenuItem
        '
        Me.CobroToolStripMenuItem.Name = "CobroToolStripMenuItem"
        Me.CobroToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CobroToolStripMenuItem.Text = "Cobros multiples"
        '
        'PagosACreditoToolStripMenuItem
        '
        Me.PagosACreditoToolStripMenuItem.Name = "PagosACreditoToolStripMenuItem"
        Me.PagosACreditoToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PagosACreditoToolStripMenuItem.Text = "Pagos a credito"
        '
        'NotasDeCreditoToolStripMenuItem
        '
        Me.NotasDeCreditoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistroDeNotaDeCreditoToolStripMenuItem})
        Me.NotasDeCreditoToolStripMenuItem.Name = "NotasDeCreditoToolStripMenuItem"
        Me.NotasDeCreditoToolStripMenuItem.Size = New System.Drawing.Size(106, 20)
        Me.NotasDeCreditoToolStripMenuItem.Text = "Notas de credito"
        '
        'RegistroDeNotaDeCreditoToolStripMenuItem
        '
        Me.RegistroDeNotaDeCreditoToolStripMenuItem.Name = "RegistroDeNotaDeCreditoToolStripMenuItem"
        Me.RegistroDeNotaDeCreditoToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.RegistroDeNotaDeCreditoToolStripMenuItem.Text = "Registro de nota de credito"
        '
        'AutorizacionesYCondonacionesToolStripMenuItem
        '
        Me.AutorizacionesYCondonacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutorizacionesYCondonacionesToolStripMenuItem1})
        Me.AutorizacionesYCondonacionesToolStripMenuItem.Name = "AutorizacionesYCondonacionesToolStripMenuItem"
        Me.AutorizacionesYCondonacionesToolStripMenuItem.Size = New System.Drawing.Size(192, 20)
        Me.AutorizacionesYCondonacionesToolStripMenuItem.Text = "Autorizaciones y Condonaciones"
        '
        'AutorizacionesYCondonacionesToolStripMenuItem1
        '
        Me.AutorizacionesYCondonacionesToolStripMenuItem1.Name = "AutorizacionesYCondonacionesToolStripMenuItem1"
        Me.AutorizacionesYCondonacionesToolStripMenuItem1.Size = New System.Drawing.Size(247, 22)
        Me.AutorizacionesYCondonacionesToolStripMenuItem1.Text = "Autorizaciones y Condonaciones"
        '
        'PagosOpcionalesToolStripMenuItem
        '
        Me.PagosOpcionalesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistroDePagosOpcionalesToolStripMenuItem, Me.AsignacionDePagosOpcionalesToolStripMenuItem})
        Me.PagosOpcionalesToolStripMenuItem.Name = "PagosOpcionalesToolStripMenuItem"
        Me.PagosOpcionalesToolStripMenuItem.Size = New System.Drawing.Size(113, 20)
        Me.PagosOpcionalesToolStripMenuItem.Text = "Pagos Opcionales"
        '
        'RegistroDePagosOpcionalesToolStripMenuItem
        '
        Me.RegistroDePagosOpcionalesToolStripMenuItem.Name = "RegistroDePagosOpcionalesToolStripMenuItem"
        Me.RegistroDePagosOpcionalesToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.RegistroDePagosOpcionalesToolStripMenuItem.Text = "Registro de pagos opcionales"
        '
        'AsignacionDePagosOpcionalesToolStripMenuItem
        '
        Me.AsignacionDePagosOpcionalesToolStripMenuItem.Name = "AsignacionDePagosOpcionalesToolStripMenuItem"
        Me.AsignacionDePagosOpcionalesToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.AsignacionDePagosOpcionalesToolStripMenuItem.Text = "Asignacion de pagos opcionales"
        '
        'PlanesDeDiplomadosToolStripMenuItem
        '
        Me.PlanesDeDiplomadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistroDePlanesToolStripMenuItem, Me.AsignacionDePlanToolStripMenuItem})
        Me.PlanesDeDiplomadosToolStripMenuItem.Name = "PlanesDeDiplomadosToolStripMenuItem"
        Me.PlanesDeDiplomadosToolStripMenuItem.Size = New System.Drawing.Size(135, 20)
        Me.PlanesDeDiplomadosToolStripMenuItem.Text = "Planes de diplomados"
        '
        'RegistroDePlanesToolStripMenuItem
        '
        Me.RegistroDePlanesToolStripMenuItem.Name = "RegistroDePlanesToolStripMenuItem"
        Me.RegistroDePlanesToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.RegistroDePlanesToolStripMenuItem.Text = "Registro de planes"
        '
        'AsignacionDePlanToolStripMenuItem
        '
        Me.AsignacionDePlanToolStripMenuItem.Name = "AsignacionDePlanToolStripMenuItem"
        Me.AsignacionDePlanToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.AsignacionDePlanToolStripMenuItem.Text = "Asignacion de plan"
        '
        'MovimientosAlumnosToolStripMenuItem
        '
        Me.MovimientosAlumnosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsignaciónDePlanesToolStripMenuItem, Me.CambioDePlanesToolStripMenuItem, Me.ModificaciónDeCostosDePlanesToolStripMenuItem})
        Me.MovimientosAlumnosToolStripMenuItem.Name = "MovimientosAlumnosToolStripMenuItem"
        Me.MovimientosAlumnosToolStripMenuItem.Size = New System.Drawing.Size(138, 20)
        Me.MovimientosAlumnosToolStripMenuItem.Text = "Movimientos alumnos"
        '
        'AsignaciónDePlanesToolStripMenuItem
        '
        Me.AsignaciónDePlanesToolStripMenuItem.Name = "AsignaciónDePlanesToolStripMenuItem"
        Me.AsignaciónDePlanesToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.AsignaciónDePlanesToolStripMenuItem.Text = "Asignación de planes"
        '
        'CambioDePlanesToolStripMenuItem
        '
        Me.CambioDePlanesToolStripMenuItem.Name = "CambioDePlanesToolStripMenuItem"
        Me.CambioDePlanesToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.CambioDePlanesToolStripMenuItem.Text = "Cambio de planes"
        '
        'ModificaciónDeCostosDePlanesToolStripMenuItem
        '
        Me.ModificaciónDeCostosDePlanesToolStripMenuItem.Name = "ModificaciónDeCostosDePlanesToolStripMenuItem"
        Me.ModificaciónDeCostosDePlanesToolStripMenuItem.Size = New System.Drawing.Size(250, 22)
        Me.ModificaciónDeCostosDePlanesToolStripMenuItem.Text = "Modificación de costos de planes"
        '
        'CatalogosToolStripMenuItem
        '
        Me.CatalogosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GestionDeExternosToolStripMenuItem, Me.EwewaewaToolStripMenuItem, Me.IVAToolStripMenuItem, Me.ReimpresionDeFacturasToolStripMenuItem})
        Me.CatalogosToolStripMenuItem.Name = "CatalogosToolStripMenuItem"
        Me.CatalogosToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.CatalogosToolStripMenuItem.Text = "Catalogos"
        '
        'GestionDeExternosToolStripMenuItem
        '
        Me.GestionDeExternosToolStripMenuItem.Name = "GestionDeExternosToolStripMenuItem"
        Me.GestionDeExternosToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.GestionDeExternosToolStripMenuItem.Text = "Alta/Baja de externos"
        '
        'EwewaewaToolStripMenuItem
        '
        Me.EwewaewaToolStripMenuItem.Name = "EwewaewaToolStripMenuItem"
        Me.EwewaewaToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.EwewaewaToolStripMenuItem.Text = "Timbres utilizados"
        '
        'IVAToolStripMenuItem
        '
        Me.IVAToolStripMenuItem.Name = "IVAToolStripMenuItem"
        Me.IVAToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.IVAToolStripMenuItem.Text = "IVA"
        '
        'ReimpresionDeFacturasToolStripMenuItem
        '
        Me.ReimpresionDeFacturasToolStripMenuItem.Name = "ReimpresionDeFacturasToolStripMenuItem"
        Me.ReimpresionDeFacturasToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ReimpresionDeFacturasToolStripMenuItem.Text = "Reimpresion de facturas"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
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
    Friend WithEvents PagosOpcionalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDePagosOpcionalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsignacionDePagosOpcionalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CobrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents statusLabel As ToolStripStatusLabel
    Friend WithEvents CobrosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CatalogosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GestionDeExternosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutorizacionesYCondonacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutorizacionesYCondonacionesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PlanesDeDiplomadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDePlanesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsignacionDePlanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CobroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotasDeCreditoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDeNotaDeCreditoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EwewaewaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PagosACreditoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IVAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReimpresionDeFacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MovimientosAlumnosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsignaciónDePlanesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CambioDePlanesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModificaciónDeCostosDePlanesToolStripMenuItem As ToolStripMenuItem
End Class
