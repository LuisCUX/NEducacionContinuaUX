<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrincipalView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrincipalView))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.CobrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagosOpcionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDePagosOpcionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignacionDePagosOpcionalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Location = New System.Drawing.Point(0, 728)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1423, 22)
        Me.StatusStrip.TabIndex = 1
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CobrosToolStripMenuItem, Me.PagosOpcionalesToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1423, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip"
        '
        'CobrosToolStripMenuItem
        '
        Me.CobrosToolStripMenuItem.Name = "CobrosToolStripMenuItem"
        Me.CobrosToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.CobrosToolStripMenuItem.Text = "Cobros"
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
        'PrincipalView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.ec_logo
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
        Me.Text = "Educacion Continua"
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
End Class
