<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistroTipoPagosOpcionales
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
        Me.btnSalirB = New System.Windows.Forms.Button()
        Me.btnGuardarB = New System.Windows.Forms.Button()
        Me.chbActivo = New System.Windows.Forms.CheckBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.GridTipoPago = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_AreaAsignada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Editar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAreas = New System.Windows.Forms.ComboBox()
        CType(Me.GridTipoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(0, -1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(841, 69)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Tipos de pagos opcionales"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSalirB
        '
        Me.btnSalirB.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalirB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirB.Location = New System.Drawing.Point(532, 438)
        Me.btnSalirB.Name = "btnSalirB"
        Me.btnSalirB.Size = New System.Drawing.Size(75, 51)
        Me.btnSalirB.TabIndex = 100
        Me.btnSalirB.UseVisualStyleBackColor = True
        '
        'btnGuardarB
        '
        Me.btnGuardarB.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardarB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarB.Location = New System.Drawing.Point(397, 438)
        Me.btnGuardarB.Name = "btnGuardarB"
        Me.btnGuardarB.Size = New System.Drawing.Size(75, 51)
        Me.btnGuardarB.TabIndex = 99
        Me.btnGuardarB.UseVisualStyleBackColor = True
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbActivo.ForeColor = System.Drawing.SystemColors.Control
        Me.chbActivo.Location = New System.Drawing.Point(15, 323)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(64, 20)
        Me.chbActivo.TabIndex = 92
        Me.chbActivo.Text = "Activo"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(15, 145)
        Me.txtNombre.Multiline = True
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(376, 63)
        Me.txtNombre.TabIndex = 90
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre.Location = New System.Drawing.Point(12, 126)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(60, 16)
        Me.lblNombre.TabIndex = 89
        Me.lblNombre.Text = "Nombre:"
        '
        'GridTipoPago
        '
        Me.GridTipoPago.AllowUserToAddRows = False
        Me.GridTipoPago.AllowUserToDeleteRows = False
        Me.GridTipoPago.AllowUserToResizeColumns = False
        Me.GridTipoPago.AllowUserToResizeRows = False
        Me.GridTipoPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridTipoPago.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridTipoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTipoPago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Clave, Me.Descripcion, Me.Nombre, Me.ID_AreaAsignada, Me.Activo, Me.Editar})
        Me.GridTipoPago.Location = New System.Drawing.Point(397, 78)
        Me.GridTipoPago.Name = "GridTipoPago"
        Me.GridTipoPago.ShowCellToolTips = False
        Me.GridTipoPago.ShowEditingIcon = False
        Me.GridTipoPago.Size = New System.Drawing.Size(436, 321)
        Me.GridTipoPago.TabIndex = 88
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'Clave
        '
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Visible = False
        '
        'Nombre
        '
        Me.Nombre.FillWeight = 215.5866!
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        '
        'ID_AreaAsignada
        '
        Me.ID_AreaAsignada.HeaderText = "Area"
        Me.ID_AreaAsignada.Name = "ID_AreaAsignada"
        '
        'Activo
        '
        Me.Activo.FillWeight = 45.68528!
        Me.Activo.HeaderText = "Activo"
        Me.Activo.Name = "Activo"
        '
        'Editar
        '
        Me.Editar.FillWeight = 38.72813!
        Me.Editar.HeaderText = "Editar"
        Me.Editar.Name = "Editar"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(15, 97)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(93, 20)
        Me.txtClave.TabIndex = 102
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClave.ForeColor = System.Drawing.SystemColors.Control
        Me.lblClave.Location = New System.Drawing.Point(12, 78)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(46, 16)
        Me.lblClave.TabIndex = 101
        Me.lblClave.Text = "Clave:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(15, 230)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(376, 20)
        Me.txtDescripcion.TabIndex = 104
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 211)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(83, 16)
        Me.lblDescripcion.TabIndex = 103
        Me.lblDescripcion.Text = "Descripcion:"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(262, 438)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 51)
        Me.btnLimpiar.TabIndex = 105
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 16)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Depto. Asignado"
        '
        'cbAreas
        '
        Me.cbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAreas.FormattingEnabled = True
        Me.cbAreas.Location = New System.Drawing.Point(15, 282)
        Me.cbAreas.Name = "cbAreas"
        Me.cbAreas.Size = New System.Drawing.Size(376, 23)
        Me.cbAreas.TabIndex = 107
        '
        'RegistroTipoPagosOpcionales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(843, 502)
        Me.Controls.Add(Me.cbAreas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.lblClave)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.btnGuardarB)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.btnSalirB)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.GridTipoPago)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "RegistroTipoPagosOpcionales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RegistroTipoPagosOpcionales"
        CType(Me.GridTipoPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents btnSalirB As Button
    Friend WithEvents btnGuardarB As Button
    Friend WithEvents chbActivo As CheckBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents GridTipoPago As DataGridView
    Friend WithEvents txtClave As TextBox
    Friend WithEvents lblClave As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cbAreas As ComboBox
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Clave As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents ID_AreaAsignada As DataGridViewTextBoxColumn
    Friend WithEvents Activo As DataGridViewTextBoxColumn
    Friend WithEvents Editar As DataGridViewCheckBoxColumn
End Class
