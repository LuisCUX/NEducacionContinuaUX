<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificacionCostosPlanesEDC
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
        Me.panelInfo3 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.lblNombreInfo3 = New System.Windows.Forms.Label()
        Me.lblEmail3 = New System.Windows.Forms.Label()
        Me.txtEmail3 = New System.Windows.Forms.TextBox()
        Me.txtNombre3 = New System.Windows.Forms.TextBox()
        Me.panelBusqueda3 = New System.Windows.Forms.Panel()
        Me.txtMatricula3 = New System.Windows.Forms.TextBox()
        Me.lblMatricula3 = New System.Windows.Forms.Label()
        Me.btnBuscar3 = New System.Windows.Forms.Button()
        Me.lblNombre3 = New System.Windows.Forms.Label()
        Me.cbBuscar3 = New System.Windows.Forms.ComboBox()
        Me.panelModificacion3 = New System.Windows.Forms.Panel()
        Me.txtPagounico = New System.Windows.Forms.TextBox()
        Me.txtMensualidades = New System.Windows.Forms.TextBox()
        Me.txtInscripcion = New System.Windows.Forms.TextBox()
        Me.lblPagounico = New System.Windows.Forms.Label()
        Me.lblMensualidades = New System.Windows.Forms.Label()
        Me.lblInscripcion = New System.Windows.Forms.Label()
        Me.lblPlanActual3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GridActual3 = New System.Windows.Forms.DataGridView()
        Me.IDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NuevoPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnModificacionDesc = New System.Windows.Forms.Button()
        Me.panelInfo3.SuspendLayout()
        Me.panelBusqueda3.SuspendLayout()
        Me.panelModificacion3.SuspendLayout()
        CType(Me.GridActual3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1046, 69)
        Me.lblNombreVentana.TabIndex = 13
        Me.lblNombreVentana.Text = "Modificación de costos"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelInfo3
        '
        Me.panelInfo3.Controls.Add(Me.ComboBox1)
        Me.panelInfo3.Controls.Add(Me.lblNombreInfo3)
        Me.panelInfo3.Controls.Add(Me.lblEmail3)
        Me.panelInfo3.Controls.Add(Me.txtEmail3)
        Me.panelInfo3.Controls.Add(Me.txtNombre3)
        Me.panelInfo3.Location = New System.Drawing.Point(131, 117)
        Me.panelInfo3.Name = "panelInfo3"
        Me.panelInfo3.Size = New System.Drawing.Size(788, 65)
        Me.panelInfo3.TabIndex = 88
        Me.panelInfo3.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(774, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(10, 21)
        Me.ComboBox1.TabIndex = 83
        Me.ComboBox1.Visible = False
        '
        'lblNombreInfo3
        '
        Me.lblNombreInfo3.AutoSize = True
        Me.lblNombreInfo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreInfo3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombreInfo3.Location = New System.Drawing.Point(3, 9)
        Me.lblNombreInfo3.Name = "lblNombreInfo3"
        Me.lblNombreInfo3.Size = New System.Drawing.Size(58, 15)
        Me.lblNombreInfo3.TabIndex = 80
        Me.lblNombreInfo3.Text = "Nombre: "
        '
        'lblEmail3
        '
        Me.lblEmail3.AutoSize = True
        Me.lblEmail3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail3.Location = New System.Drawing.Point(3, 38)
        Me.lblEmail3.Name = "lblEmail3"
        Me.lblEmail3.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail3.TabIndex = 81
        Me.lblEmail3.Text = "Email:"
        '
        'txtEmail3
        '
        Me.txtEmail3.Enabled = False
        Me.txtEmail3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail3.Location = New System.Drawing.Point(70, 35)
        Me.txtEmail3.Name = "txtEmail3"
        Me.txtEmail3.Size = New System.Drawing.Size(474, 21)
        Me.txtEmail3.TabIndex = 82
        '
        'txtNombre3
        '
        Me.txtNombre3.Enabled = False
        Me.txtNombre3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre3.Location = New System.Drawing.Point(70, 6)
        Me.txtNombre3.Name = "txtNombre3"
        Me.txtNombre3.Size = New System.Drawing.Size(474, 21)
        Me.txtNombre3.TabIndex = 79
        '
        'panelBusqueda3
        '
        Me.panelBusqueda3.Controls.Add(Me.txtMatricula3)
        Me.panelBusqueda3.Controls.Add(Me.lblMatricula3)
        Me.panelBusqueda3.Controls.Add(Me.btnBuscar3)
        Me.panelBusqueda3.Controls.Add(Me.lblNombre3)
        Me.panelBusqueda3.Controls.Add(Me.cbBuscar3)
        Me.panelBusqueda3.Location = New System.Drawing.Point(131, 72)
        Me.panelBusqueda3.Name = "panelBusqueda3"
        Me.panelBusqueda3.Size = New System.Drawing.Size(788, 39)
        Me.panelBusqueda3.TabIndex = 87
        '
        'txtMatricula3
        '
        Me.txtMatricula3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula3.Location = New System.Drawing.Point(70, 6)
        Me.txtMatricula3.Name = "txtMatricula3"
        Me.txtMatricula3.Size = New System.Drawing.Size(111, 22)
        Me.txtMatricula3.TabIndex = 75
        '
        'lblMatricula3
        '
        Me.lblMatricula3.AutoSize = True
        Me.lblMatricula3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula3.Location = New System.Drawing.Point(8, 9)
        Me.lblMatricula3.Name = "lblMatricula3"
        Me.lblMatricula3.Size = New System.Drawing.Size(65, 16)
        Me.lblMatricula3.TabIndex = 74
        Me.lblMatricula3.Text = "Matrícula:"
        '
        'btnBuscar3
        '
        Me.btnBuscar3.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar3.Location = New System.Drawing.Point(187, 0)
        Me.btnBuscar3.Name = "btnBuscar3"
        Me.btnBuscar3.Size = New System.Drawing.Size(41, 39)
        Me.btnBuscar3.TabIndex = 76
        Me.btnBuscar3.UseVisualStyleBackColor = True
        '
        'lblNombre3
        '
        Me.lblNombre3.AutoSize = True
        Me.lblNombre3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre3.Location = New System.Drawing.Point(234, 9)
        Me.lblNombre3.Name = "lblNombre3"
        Me.lblNombre3.Size = New System.Drawing.Size(63, 16)
        Me.lblNombre3.TabIndex = 77
        Me.lblNombre3.Text = "Nombre: "
        '
        'cbBuscar3
        '
        Me.cbBuscar3.FormattingEnabled = True
        Me.cbBuscar3.Location = New System.Drawing.Point(303, 8)
        Me.cbBuscar3.Name = "cbBuscar3"
        Me.cbBuscar3.Size = New System.Drawing.Size(478, 21)
        Me.cbBuscar3.TabIndex = 78
        '
        'panelModificacion3
        '
        Me.panelModificacion3.Controls.Add(Me.txtPagounico)
        Me.panelModificacion3.Controls.Add(Me.txtMensualidades)
        Me.panelModificacion3.Controls.Add(Me.txtInscripcion)
        Me.panelModificacion3.Controls.Add(Me.lblPagounico)
        Me.panelModificacion3.Controls.Add(Me.lblMensualidades)
        Me.panelModificacion3.Controls.Add(Me.lblInscripcion)
        Me.panelModificacion3.Controls.Add(Me.lblPlanActual3)
        Me.panelModificacion3.Controls.Add(Me.Button2)
        Me.panelModificacion3.Controls.Add(Me.GridActual3)
        Me.panelModificacion3.Controls.Add(Me.btnModificacionDesc)
        Me.panelModificacion3.Location = New System.Drawing.Point(4, 188)
        Me.panelModificacion3.Name = "panelModificacion3"
        Me.panelModificacion3.Size = New System.Drawing.Size(1030, 412)
        Me.panelModificacion3.TabIndex = 89
        Me.panelModificacion3.Visible = False
        '
        'txtPagounico
        '
        Me.txtPagounico.Enabled = False
        Me.txtPagounico.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagounico.Location = New System.Drawing.Point(793, 197)
        Me.txtPagounico.Name = "txtPagounico"
        Me.txtPagounico.Size = New System.Drawing.Size(157, 31)
        Me.txtPagounico.TabIndex = 94
        '
        'txtMensualidades
        '
        Me.txtMensualidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensualidades.Location = New System.Drawing.Point(793, 128)
        Me.txtMensualidades.Name = "txtMensualidades"
        Me.txtMensualidades.Size = New System.Drawing.Size(157, 31)
        Me.txtMensualidades.TabIndex = 93
        '
        'txtInscripcion
        '
        Me.txtInscripcion.Enabled = False
        Me.txtInscripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInscripcion.Location = New System.Drawing.Point(793, 55)
        Me.txtInscripcion.Name = "txtInscripcion"
        Me.txtInscripcion.Size = New System.Drawing.Size(157, 31)
        Me.txtInscripcion.TabIndex = 92
        '
        'lblPagounico
        '
        Me.lblPagounico.AutoSize = True
        Me.lblPagounico.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagounico.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPagounico.Location = New System.Drawing.Point(789, 174)
        Me.lblPagounico.Name = "lblPagounico"
        Me.lblPagounico.Size = New System.Drawing.Size(205, 20)
        Me.lblPagounico.TabIndex = 91
        Me.lblPagounico.Text = "Nuevo costo de pago único:"
        '
        'lblMensualidades
        '
        Me.lblMensualidades.AutoSize = True
        Me.lblMensualidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensualidades.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMensualidades.Location = New System.Drawing.Point(789, 105)
        Me.lblMensualidades.Name = "lblMensualidades"
        Me.lblMensualidades.Size = New System.Drawing.Size(234, 20)
        Me.lblMensualidades.TabIndex = 90
        Me.lblMensualidades.Text = "Nuevo costo de mensualidades:"
        '
        'lblInscripcion
        '
        Me.lblInscripcion.AutoSize = True
        Me.lblInscripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInscripcion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblInscripcion.Location = New System.Drawing.Point(789, 32)
        Me.lblInscripcion.Name = "lblInscripcion"
        Me.lblInscripcion.Size = New System.Drawing.Size(195, 20)
        Me.lblInscripcion.TabIndex = 89
        Me.lblInscripcion.Text = "Nuevo costo de Incripción:"
        '
        'lblPlanActual3
        '
        Me.lblPlanActual3.AutoSize = True
        Me.lblPlanActual3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanActual3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPlanActual3.Location = New System.Drawing.Point(8, 9)
        Me.lblPlanActual3.Name = "lblPlanActual3"
        Me.lblPlanActual3.Size = New System.Drawing.Size(91, 20)
        Me.lblPlanActual3.TabIndex = 88
        Me.lblPlanActual3.Text = "Plan actual:"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(581, 359)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 46)
        Me.Button2.TabIndex = 85
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GridActual3
        '
        Me.GridActual3.AllowUserToAddRows = False
        Me.GridActual3.AllowUserToDeleteRows = False
        Me.GridActual3.AllowUserToResizeColumns = False
        Me.GridActual3.AllowUserToResizeRows = False
        Me.GridActual3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridActual3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridActual3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridActual3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDColumn, Me.Clave, Me.DescripcionColumn, Me.PrecioActual, Me.NuevoPrecio})
        Me.GridActual3.Location = New System.Drawing.Point(8, 32)
        Me.GridActual3.Name = "GridActual3"
        Me.GridActual3.Size = New System.Drawing.Size(775, 321)
        Me.GridActual3.TabIndex = 87
        '
        'IDColumn
        '
        Me.IDColumn.HeaderText = "ID"
        Me.IDColumn.Name = "IDColumn"
        Me.IDColumn.ReadOnly = True
        Me.IDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IDColumn.Visible = False
        '
        'Clave
        '
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.ReadOnly = True
        Me.Clave.Visible = False
        '
        'DescripcionColumn
        '
        Me.DescripcionColumn.HeaderText = "Descripcion"
        Me.DescripcionColumn.Name = "DescripcionColumn"
        Me.DescripcionColumn.ReadOnly = True
        Me.DescripcionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'PrecioActual
        '
        Me.PrecioActual.FillWeight = 50.0!
        Me.PrecioActual.HeaderText = "PrecioActual"
        Me.PrecioActual.Name = "PrecioActual"
        Me.PrecioActual.ReadOnly = True
        Me.PrecioActual.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'NuevoPrecio
        '
        Me.NuevoPrecio.FillWeight = 50.0!
        Me.NuevoPrecio.HeaderText = "Nuevo Precio"
        Me.NuevoPrecio.Name = "NuevoPrecio"
        Me.NuevoPrecio.ReadOnly = True
        Me.NuevoPrecio.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'btnModificacionDesc
        '
        Me.btnModificacionDesc.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnModificacionDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnModificacionDesc.Location = New System.Drawing.Point(314, 359)
        Me.btnModificacionDesc.Name = "btnModificacionDesc"
        Me.btnModificacionDesc.Size = New System.Drawing.Size(60, 46)
        Me.btnModificacionDesc.TabIndex = 84
        Me.btnModificacionDesc.UseVisualStyleBackColor = True
        '
        'ModificacionCostosPlanesEDC
        '
        Me.AcceptButton = Me.btnBuscar3
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1041, 607)
        Me.Controls.Add(Me.panelModificacion3)
        Me.Controls.Add(Me.panelInfo3)
        Me.Controls.Add(Me.panelBusqueda3)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "ModificacionCostosPlanesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ModificacionCostosPlanesEDC"
        Me.panelInfo3.ResumeLayout(False)
        Me.panelInfo3.PerformLayout()
        Me.panelBusqueda3.ResumeLayout(False)
        Me.panelBusqueda3.PerformLayout()
        Me.panelModificacion3.ResumeLayout(False)
        Me.panelModificacion3.PerformLayout()
        CType(Me.GridActual3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelInfo3 As Panel
    Friend WithEvents lblNombreInfo3 As Label
    Friend WithEvents lblEmail3 As Label
    Friend WithEvents txtEmail3 As TextBox
    Friend WithEvents txtNombre3 As TextBox
    Friend WithEvents panelBusqueda3 As Panel
    Friend WithEvents txtMatricula3 As TextBox
    Friend WithEvents lblMatricula3 As Label
    Friend WithEvents btnBuscar3 As Button
    Friend WithEvents lblNombre3 As Label
    Friend WithEvents cbBuscar3 As ComboBox
    Friend WithEvents panelModificacion3 As Panel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents lblPlanActual3 As Label
    Friend WithEvents GridActual3 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents btnModificacionDesc As Button
    Friend WithEvents lblPagounico As Label
    Friend WithEvents lblMensualidades As Label
    Friend WithEvents lblInscripcion As Label
    Friend WithEvents txtPagounico As TextBox
    Friend WithEvents txtMensualidades As TextBox
    Friend WithEvents txtInscripcion As TextBox
    Friend WithEvents IDColumn As DataGridViewTextBoxColumn
    Friend WithEvents Clave As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrecioActual As DataGridViewTextBoxColumn
    Friend WithEvents NuevoPrecio As DataGridViewTextBoxColumn
End Class
