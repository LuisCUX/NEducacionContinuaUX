<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambioPlanesEDC
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
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.panelBusqueda2 = New System.Windows.Forms.Panel()
        Me.txtMatricula2 = New System.Windows.Forms.TextBox()
        Me.lblMatricula2 = New System.Windows.Forms.Label()
        Me.btnBuscar2 = New System.Windows.Forms.Button()
        Me.lblNombre2 = New System.Windows.Forms.Label()
        Me.cbNombre2 = New System.Windows.Forms.ComboBox()
        Me.panelPlan2 = New System.Windows.Forms.Panel()
        Me.cbNuevoPlan = New System.Windows.Forms.ComboBox()
        Me.lblPlanActual = New System.Windows.Forms.Label()
        Me.lblNuevoPlan = New System.Windows.Forms.Label()
        Me.GridNuevoPlan = New System.Windows.Forms.DataGridView()
        Me.btnSalir2 = New System.Windows.Forms.Button()
        Me.btnGuardar2 = New System.Windows.Forms.Button()
        Me.GridPlanActual = New System.Windows.Forms.DataGridView()
        Me.panelInfo2 = New System.Windows.Forms.Panel()
        Me.lblNombreA2 = New System.Windows.Forms.Label()
        Me.lblEmail2 = New System.Windows.Forms.Label()
        Me.txtEmail2 = New System.Windows.Forms.TextBox()
        Me.txtNombre2 = New System.Windows.Forms.TextBox()
        Me.panelBusqueda2.SuspendLayout()
        Me.panelPlan2.SuspendLayout()
        CType(Me.GridNuevoPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPlanActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelInfo2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-3, -1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(809, 69)
        Me.lblNombreVentana.TabIndex = 12
        Me.lblNombreVentana.Text = "Cambio de planes"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBusqueda2
        '
        Me.panelBusqueda2.Controls.Add(Me.txtMatricula2)
        Me.panelBusqueda2.Controls.Add(Me.lblMatricula2)
        Me.panelBusqueda2.Controls.Add(Me.btnBuscar2)
        Me.panelBusqueda2.Controls.Add(Me.lblNombre2)
        Me.panelBusqueda2.Controls.Add(Me.cbNombre2)
        Me.panelBusqueda2.Location = New System.Drawing.Point(7, 75)
        Me.panelBusqueda2.Name = "panelBusqueda2"
        Me.panelBusqueda2.Size = New System.Drawing.Size(788, 39)
        Me.panelBusqueda2.TabIndex = 89
        '
        'txtMatricula2
        '
        Me.txtMatricula2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula2.Location = New System.Drawing.Point(70, 6)
        Me.txtMatricula2.Name = "txtMatricula2"
        Me.txtMatricula2.Size = New System.Drawing.Size(111, 22)
        Me.txtMatricula2.TabIndex = 75
        '
        'lblMatricula2
        '
        Me.lblMatricula2.AutoSize = True
        Me.lblMatricula2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula2.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula2.Location = New System.Drawing.Point(8, 9)
        Me.lblMatricula2.Name = "lblMatricula2"
        Me.lblMatricula2.Size = New System.Drawing.Size(65, 16)
        Me.lblMatricula2.TabIndex = 74
        Me.lblMatricula2.Text = "Matrícula:"
        '
        'btnBuscar2
        '
        Me.btnBuscar2.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar2.Location = New System.Drawing.Point(187, 0)
        Me.btnBuscar2.Name = "btnBuscar2"
        Me.btnBuscar2.Size = New System.Drawing.Size(41, 39)
        Me.btnBuscar2.TabIndex = 76
        Me.btnBuscar2.UseVisualStyleBackColor = True
        '
        'lblNombre2
        '
        Me.lblNombre2.AutoSize = True
        Me.lblNombre2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre2.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre2.Location = New System.Drawing.Point(234, 9)
        Me.lblNombre2.Name = "lblNombre2"
        Me.lblNombre2.Size = New System.Drawing.Size(63, 16)
        Me.lblNombre2.TabIndex = 77
        Me.lblNombre2.Text = "Nombre: "
        '
        'cbNombre2
        '
        Me.cbNombre2.FormattingEnabled = True
        Me.cbNombre2.Location = New System.Drawing.Point(303, 8)
        Me.cbNombre2.Name = "cbNombre2"
        Me.cbNombre2.Size = New System.Drawing.Size(478, 21)
        Me.cbNombre2.TabIndex = 78
        '
        'panelPlan2
        '
        Me.panelPlan2.Controls.Add(Me.cbNuevoPlan)
        Me.panelPlan2.Controls.Add(Me.lblPlanActual)
        Me.panelPlan2.Controls.Add(Me.lblNuevoPlan)
        Me.panelPlan2.Controls.Add(Me.GridNuevoPlan)
        Me.panelPlan2.Controls.Add(Me.btnSalir2)
        Me.panelPlan2.Controls.Add(Me.btnGuardar2)
        Me.panelPlan2.Controls.Add(Me.GridPlanActual)
        Me.panelPlan2.Location = New System.Drawing.Point(7, 192)
        Me.panelPlan2.Name = "panelPlan2"
        Me.panelPlan2.Size = New System.Drawing.Size(788, 553)
        Me.panelPlan2.TabIndex = 90
        Me.panelPlan2.Visible = False
        '
        'cbNuevoPlan
        '
        Me.cbNuevoPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNuevoPlan.FormattingEnabled = True
        Me.cbNuevoPlan.Location = New System.Drawing.Point(94, 247)
        Me.cbNuevoPlan.Name = "cbNuevoPlan"
        Me.cbNuevoPlan.Size = New System.Drawing.Size(474, 21)
        Me.cbNuevoPlan.TabIndex = 88
        '
        'lblPlanActual
        '
        Me.lblPlanActual.AutoSize = True
        Me.lblPlanActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanActual.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPlanActual.Location = New System.Drawing.Point(8, 7)
        Me.lblPlanActual.Name = "lblPlanActual"
        Me.lblPlanActual.Size = New System.Drawing.Size(77, 16)
        Me.lblPlanActual.TabIndex = 86
        Me.lblPlanActual.Text = "Plan actual:"
        '
        'lblNuevoPlan
        '
        Me.lblNuevoPlan.AutoSize = True
        Me.lblNuevoPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevoPlan.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNuevoPlan.Location = New System.Drawing.Point(8, 248)
        Me.lblNuevoPlan.Name = "lblNuevoPlan"
        Me.lblNuevoPlan.Size = New System.Drawing.Size(80, 16)
        Me.lblNuevoPlan.TabIndex = 85
        Me.lblNuevoPlan.Text = "Nuevo plan:"
        '
        'GridNuevoPlan
        '
        Me.GridNuevoPlan.AllowUserToAddRows = False
        Me.GridNuevoPlan.AllowUserToDeleteRows = False
        Me.GridNuevoPlan.AllowUserToResizeColumns = False
        Me.GridNuevoPlan.AllowUserToResizeRows = False
        Me.GridNuevoPlan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridNuevoPlan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridNuevoPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridNuevoPlan.Location = New System.Drawing.Point(6, 275)
        Me.GridNuevoPlan.Name = "GridNuevoPlan"
        Me.GridNuevoPlan.ReadOnly = True
        Me.GridNuevoPlan.Size = New System.Drawing.Size(775, 223)
        Me.GridNuevoPlan.TabIndex = 84
        '
        'btnSalir2
        '
        Me.btnSalir2.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir2.Location = New System.Drawing.Point(238, 504)
        Me.btnSalir2.Name = "btnSalir2"
        Me.btnSalir2.Size = New System.Drawing.Size(59, 46)
        Me.btnSalir2.TabIndex = 83
        Me.btnSalir2.UseVisualStyleBackColor = True
        '
        'btnGuardar2
        '
        Me.btnGuardar2.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar2.Location = New System.Drawing.Point(467, 504)
        Me.btnGuardar2.Name = "btnGuardar2"
        Me.btnGuardar2.Size = New System.Drawing.Size(60, 46)
        Me.btnGuardar2.TabIndex = 82
        Me.btnGuardar2.UseVisualStyleBackColor = True
        '
        'GridPlanActual
        '
        Me.GridPlanActual.AllowUserToAddRows = False
        Me.GridPlanActual.AllowUserToDeleteRows = False
        Me.GridPlanActual.AllowUserToResizeColumns = False
        Me.GridPlanActual.AllowUserToResizeRows = False
        Me.GridPlanActual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridPlanActual.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridPlanActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPlanActual.Location = New System.Drawing.Point(6, 27)
        Me.GridPlanActual.Name = "GridPlanActual"
        Me.GridPlanActual.ReadOnly = True
        Me.GridPlanActual.Size = New System.Drawing.Size(775, 209)
        Me.GridPlanActual.TabIndex = 81
        '
        'panelInfo2
        '
        Me.panelInfo2.Controls.Add(Me.lblNombreA2)
        Me.panelInfo2.Controls.Add(Me.lblEmail2)
        Me.panelInfo2.Controls.Add(Me.txtEmail2)
        Me.panelInfo2.Controls.Add(Me.txtNombre2)
        Me.panelInfo2.Location = New System.Drawing.Point(7, 120)
        Me.panelInfo2.Name = "panelInfo2"
        Me.panelInfo2.Size = New System.Drawing.Size(788, 65)
        Me.panelInfo2.TabIndex = 88
        Me.panelInfo2.Visible = False
        '
        'lblNombreA2
        '
        Me.lblNombreA2.AutoSize = True
        Me.lblNombreA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreA2.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombreA2.Location = New System.Drawing.Point(3, 9)
        Me.lblNombreA2.Name = "lblNombreA2"
        Me.lblNombreA2.Size = New System.Drawing.Size(58, 15)
        Me.lblNombreA2.TabIndex = 80
        Me.lblNombreA2.Text = "Nombre: "
        '
        'lblEmail2
        '
        Me.lblEmail2.AutoSize = True
        Me.lblEmail2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail2.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail2.Location = New System.Drawing.Point(3, 38)
        Me.lblEmail2.Name = "lblEmail2"
        Me.lblEmail2.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail2.TabIndex = 81
        Me.lblEmail2.Text = "Email:"
        '
        'txtEmail2
        '
        Me.txtEmail2.Enabled = False
        Me.txtEmail2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail2.Location = New System.Drawing.Point(70, 35)
        Me.txtEmail2.Name = "txtEmail2"
        Me.txtEmail2.Size = New System.Drawing.Size(474, 21)
        Me.txtEmail2.TabIndex = 82
        '
        'txtNombre2
        '
        Me.txtNombre2.Enabled = False
        Me.txtNombre2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre2.Location = New System.Drawing.Point(70, 6)
        Me.txtNombre2.Name = "txtNombre2"
        Me.txtNombre2.Size = New System.Drawing.Size(474, 21)
        Me.txtNombre2.TabIndex = 79
        '
        'CambioPlanesEDC
        '
        Me.AcceptButton = Me.btnBuscar2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(800, 753)
        Me.Controls.Add(Me.panelBusqueda2)
        Me.Controls.Add(Me.panelPlan2)
        Me.Controls.Add(Me.panelInfo2)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "CambioPlanesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CambioPlanesEDC"
        Me.panelBusqueda2.ResumeLayout(False)
        Me.panelBusqueda2.PerformLayout()
        Me.panelPlan2.ResumeLayout(False)
        Me.panelPlan2.PerformLayout()
        CType(Me.GridNuevoPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPlanActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelInfo2.ResumeLayout(False)
        Me.panelInfo2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelBusqueda2 As Panel
    Friend WithEvents txtMatricula2 As TextBox
    Friend WithEvents lblMatricula2 As Label
    Friend WithEvents btnBuscar2 As Button
    Friend WithEvents lblNombre2 As Label
    Friend WithEvents cbNombre2 As ComboBox
    Friend WithEvents panelPlan2 As Panel
    Friend WithEvents cbNuevoPlan As ComboBox
    Friend WithEvents lblPlanActual As Label
    Friend WithEvents lblNuevoPlan As Label
    Friend WithEvents GridNuevoPlan As DataGridView
    Friend WithEvents btnSalir2 As Button
    Friend WithEvents btnGuardar2 As Button
    Friend WithEvents GridPlanActual As DataGridView
    Friend WithEvents panelInfo2 As Panel
    Friend WithEvents lblNombreA2 As Label
    Friend WithEvents lblEmail2 As Label
    Friend WithEvents txtEmail2 As TextBox
    Friend WithEvents txtNombre2 As TextBox
End Class
