<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignacionPlanesEDC
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
        Me.panelBusqueda = New System.Windows.Forms.Panel()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.panelRegistro = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GridPagos = New System.Windows.Forms.DataGridView()
        Me.cbPlanes = New System.Windows.Forms.ComboBox()
        Me.lblPlanes = New System.Windows.Forms.Label()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.panelBusqueda.SuspendLayout()
        Me.panelRegistro.SuspendLayout()
        CType(Me.GridPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(0, -1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(801, 69)
        Me.lblNombreVentana.TabIndex = 12
        Me.lblNombreVentana.Text = "Asignación de planes"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBusqueda
        '
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBusqueda.Controls.Add(Me.cbExterno)
        Me.panelBusqueda.Location = New System.Drawing.Point(6, 71)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(788, 39)
        Me.panelBusqueda.TabIndex = 86
        '
        'txtMatricula
        '
        Me.txtMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula.Location = New System.Drawing.Point(70, 6)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(111, 22)
        Me.txtMatricula.TabIndex = 75
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula.Location = New System.Drawing.Point(8, 9)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(65, 16)
        Me.lblMatricula.TabIndex = 74
        Me.lblMatricula.Text = "Matrícula:"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.Location = New System.Drawing.Point(187, 0)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(41, 39)
        Me.btnBuscar.TabIndex = 76
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblBusquedaNombre
        '
        Me.lblBusquedaNombre.AutoSize = True
        Me.lblBusquedaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBusquedaNombre.Location = New System.Drawing.Point(234, 9)
        Me.lblBusquedaNombre.Name = "lblBusquedaNombre"
        Me.lblBusquedaNombre.Size = New System.Drawing.Size(63, 16)
        Me.lblBusquedaNombre.TabIndex = 77
        Me.lblBusquedaNombre.Text = "Nombre: "
        '
        'cbExterno
        '
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(303, 8)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(478, 21)
        Me.cbExterno.TabIndex = 78
        '
        'panelRegistro
        '
        Me.panelRegistro.Controls.Add(Me.btnSalir)
        Me.panelRegistro.Controls.Add(Me.btnGuardar)
        Me.panelRegistro.Controls.Add(Me.GridPagos)
        Me.panelRegistro.Controls.Add(Me.cbPlanes)
        Me.panelRegistro.Controls.Add(Me.lblPlanes)
        Me.panelRegistro.Location = New System.Drawing.Point(6, 188)
        Me.panelRegistro.Name = "panelRegistro"
        Me.panelRegistro.Size = New System.Drawing.Size(788, 553)
        Me.panelRegistro.TabIndex = 87
        Me.panelRegistro.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(238, 504)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(59, 46)
        Me.btnSalir.TabIndex = 83
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.Location = New System.Drawing.Point(467, 504)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 46)
        Me.btnGuardar.TabIndex = 82
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'GridPagos
        '
        Me.GridPagos.AllowUserToAddRows = False
        Me.GridPagos.AllowUserToDeleteRows = False
        Me.GridPagos.AllowUserToResizeColumns = False
        Me.GridPagos.AllowUserToResizeRows = False
        Me.GridPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridPagos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPagos.Location = New System.Drawing.Point(6, 35)
        Me.GridPagos.Name = "GridPagos"
        Me.GridPagos.ReadOnly = True
        Me.GridPagos.Size = New System.Drawing.Size(775, 397)
        Me.GridPagos.TabIndex = 81
        '
        'cbPlanes
        '
        Me.cbPlanes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPlanes.FormattingEnabled = True
        Me.cbPlanes.Location = New System.Drawing.Point(70, 8)
        Me.cbPlanes.Name = "cbPlanes"
        Me.cbPlanes.Size = New System.Drawing.Size(474, 21)
        Me.cbPlanes.TabIndex = 80
        '
        'lblPlanes
        '
        Me.lblPlanes.AutoSize = True
        Me.lblPlanes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanes.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPlanes.Location = New System.Drawing.Point(3, 9)
        Me.lblPlanes.Name = "lblPlanes"
        Me.lblPlanes.Size = New System.Drawing.Size(53, 16)
        Me.lblPlanes.TabIndex = 79
        Me.lblPlanes.Text = "Planes:"
        '
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.txtEmail)
        Me.panelDatos.Controls.Add(Me.txtNombre)
        Me.panelDatos.Location = New System.Drawing.Point(6, 116)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(788, 65)
        Me.panelDatos.TabIndex = 85
        Me.panelDatos.Visible = False
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre.Location = New System.Drawing.Point(3, 9)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblNombre.TabIndex = 80
        Me.lblNombre.Text = "Nombre: "
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail.Location = New System.Drawing.Point(3, 38)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail.TabIndex = 81
        Me.lblEmail.Text = "Email:"
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(70, 35)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(474, 21)
        Me.txtEmail.TabIndex = 82
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(70, 6)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(474, 21)
        Me.txtNombre.TabIndex = 79
        '
        'AsignacionPlanesEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(802, 753)
        Me.Controls.Add(Me.panelBusqueda)
        Me.Controls.Add(Me.panelRegistro)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "AsignacionPlanesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AsignacionPlanesEDC"
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelRegistro.ResumeLayout(False)
        Me.panelRegistro.PerformLayout()
        CType(Me.GridPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents lblMatricula As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents panelRegistro As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents GridPagos As DataGridView
    Friend WithEvents cbPlanes As ComboBox
    Friend WithEvents lblPlanes As Label
    Friend WithEvents panelDatos As Panel
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtNombre As TextBox
End Class
