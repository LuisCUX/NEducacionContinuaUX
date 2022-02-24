<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BancosEDC
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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tarjetas", -2, -2)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BancosEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.tabBancosTarjetas = New System.Windows.Forms.TabControl()
        Me.pageBancos = New System.Windows.Forms.TabPage()
        Me.btnSalirB = New System.Windows.Forms.Button()
        Me.btnGuardarB = New System.Windows.Forms.Button()
        Me.TreeTarjetas = New System.Windows.Forms.TreeView()
        Me.ImageTree = New System.Windows.Forms.ImageList(Me.components)
        Me.chbActivoBanco = New System.Windows.Forms.CheckBox()
        Me.txtNombreBanco = New System.Windows.Forms.TextBox()
        Me.lblNombreBanco = New System.Windows.Forms.Label()
        Me.GridBancos = New System.Windows.Forms.DataGridView()
        Me.IDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NuevoPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Editar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pageTarjetas = New System.Windows.Forms.TabPage()
        Me.btnSalirT = New System.Windows.Forms.Button()
        Me.btnGuardarT = New System.Windows.Forms.Button()
        Me.GridTarjetas = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.chbActivoTarjeta = New System.Windows.Forms.CheckBox()
        Me.txtNombreTarjeta = New System.Windows.Forms.TextBox()
        Me.lblNombreTarjeta = New System.Windows.Forms.Label()
        Me.tabBancosTarjetas.SuspendLayout()
        Me.pageBancos.SuspendLayout()
        CType(Me.GridBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pageTarjetas.SuspendLayout()
        CType(Me.GridTarjetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-1, -2)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(840, 69)
        Me.lblNombreVentana.TabIndex = 13
        Me.lblNombreVentana.Text = "Catálogo de bancos y tipos de tarjeta"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabBancosTarjetas
        '
        Me.tabBancosTarjetas.Controls.Add(Me.pageBancos)
        Me.tabBancosTarjetas.Controls.Add(Me.pageTarjetas)
        Me.tabBancosTarjetas.Location = New System.Drawing.Point(5, 70)
        Me.tabBancosTarjetas.Name = "tabBancosTarjetas"
        Me.tabBancosTarjetas.SelectedIndex = 0
        Me.tabBancosTarjetas.Size = New System.Drawing.Size(819, 430)
        Me.tabBancosTarjetas.TabIndex = 14
        '
        'pageBancos
        '
        Me.pageBancos.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.pageBancos.Controls.Add(Me.btnSalirB)
        Me.pageBancos.Controls.Add(Me.btnGuardarB)
        Me.pageBancos.Controls.Add(Me.TreeTarjetas)
        Me.pageBancos.Controls.Add(Me.chbActivoBanco)
        Me.pageBancos.Controls.Add(Me.txtNombreBanco)
        Me.pageBancos.Controls.Add(Me.lblNombreBanco)
        Me.pageBancos.Controls.Add(Me.GridBancos)
        Me.pageBancos.Location = New System.Drawing.Point(4, 22)
        Me.pageBancos.Name = "pageBancos"
        Me.pageBancos.Padding = New System.Windows.Forms.Padding(3)
        Me.pageBancos.Size = New System.Drawing.Size(811, 404)
        Me.pageBancos.TabIndex = 0
        Me.pageBancos.Text = "Bancos"
        '
        'btnSalirB
        '
        Me.btnSalirB.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalirB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirB.Location = New System.Drawing.Point(459, 336)
        Me.btnSalirB.Name = "btnSalirB"
        Me.btnSalirB.Size = New System.Drawing.Size(75, 51)
        Me.btnSalirB.TabIndex = 100
        Me.btnSalirB.UseVisualStyleBackColor = True
        '
        'btnGuardarB
        '
        Me.btnGuardarB.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardarB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarB.Location = New System.Drawing.Point(273, 336)
        Me.btnGuardarB.Name = "btnGuardarB"
        Me.btnGuardarB.Size = New System.Drawing.Size(75, 51)
        Me.btnGuardarB.TabIndex = 99
        Me.btnGuardarB.UseVisualStyleBackColor = True
        '
        'TreeTarjetas
        '
        Me.TreeTarjetas.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TreeTarjetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeTarjetas.ForeColor = System.Drawing.SystemColors.Control
        Me.TreeTarjetas.Location = New System.Drawing.Point(9, 105)
        Me.TreeTarjetas.Name = "TreeTarjetas"
        TreeNode2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        TreeNode2.ForeColor = System.Drawing.SystemColors.Control
        TreeNode2.ImageIndex = -2
        TreeNode2.Name = "nodeTarjetas"
        TreeNode2.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode2.SelectedImageIndex = -2
        TreeNode2.StateImageIndex = 2
        TreeNode2.Text = "Tarjetas"
        Me.TreeTarjetas.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.TreeTarjetas.Size = New System.Drawing.Size(376, 217)
        Me.TreeTarjetas.StateImageList = Me.ImageTree
        Me.TreeTarjetas.TabIndex = 93
        '
        'ImageTree
        '
        Me.ImageTree.ImageStream = CType(resources.GetObject("ImageTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageTree.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageTree.Images.SetKeyName(0, "unchecked_checkbox_40px.png")
        Me.ImageTree.Images.SetKeyName(1, "checked_checkbox_40px.png")
        Me.ImageTree.Images.SetKeyName(2, "folder_40px.png")
        '
        'chbActivoBanco
        '
        Me.chbActivoBanco.AutoSize = True
        Me.chbActivoBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbActivoBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.chbActivoBanco.Location = New System.Drawing.Point(9, 79)
        Me.chbActivoBanco.Name = "chbActivoBanco"
        Me.chbActivoBanco.Size = New System.Drawing.Size(64, 20)
        Me.chbActivoBanco.TabIndex = 92
        Me.chbActivoBanco.Text = "Activo"
        Me.chbActivoBanco.UseVisualStyleBackColor = True
        '
        'txtNombreBanco
        '
        Me.txtNombreBanco.Location = New System.Drawing.Point(9, 44)
        Me.txtNombreBanco.Name = "txtNombreBanco"
        Me.txtNombreBanco.Size = New System.Drawing.Size(376, 20)
        Me.txtNombreBanco.TabIndex = 90
        '
        'lblNombreBanco
        '
        Me.lblNombreBanco.AutoSize = True
        Me.lblNombreBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombreBanco.Location = New System.Drawing.Point(6, 13)
        Me.lblNombreBanco.Name = "lblNombreBanco"
        Me.lblNombreBanco.Size = New System.Drawing.Size(123, 16)
        Me.lblNombreBanco.TabIndex = 89
        Me.lblNombreBanco.Text = "Nombre del banco:"
        '
        'GridBancos
        '
        Me.GridBancos.AllowUserToAddRows = False
        Me.GridBancos.AllowUserToDeleteRows = False
        Me.GridBancos.AllowUserToResizeColumns = False
        Me.GridBancos.AllowUserToResizeRows = False
        Me.GridBancos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridBancos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridBancos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDColumn, Me.NuevoPrecio, Me.Activo, Me.Editar})
        Me.GridBancos.Location = New System.Drawing.Point(438, 1)
        Me.GridBancos.Name = "GridBancos"
        Me.GridBancos.Size = New System.Drawing.Size(370, 321)
        Me.GridBancos.TabIndex = 88
        '
        'IDColumn
        '
        Me.IDColumn.HeaderText = "ID"
        Me.IDColumn.Name = "IDColumn"
        Me.IDColumn.ReadOnly = True
        Me.IDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IDColumn.Visible = False
        '
        'NuevoPrecio
        '
        Me.NuevoPrecio.FillWeight = 139.201!
        Me.NuevoPrecio.HeaderText = "Nombre del banco"
        Me.NuevoPrecio.Name = "NuevoPrecio"
        Me.NuevoPrecio.ReadOnly = True
        Me.NuevoPrecio.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Activo
        '
        Me.Activo.FillWeight = 47.34727!
        Me.Activo.HeaderText = "Activo"
        Me.Activo.Name = "Activo"
        '
        'Editar
        '
        Me.Editar.FillWeight = 63.45178!
        Me.Editar.HeaderText = "Editar"
        Me.Editar.Name = "Editar"
        Me.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'pageTarjetas
        '
        Me.pageTarjetas.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.pageTarjetas.Controls.Add(Me.btnSalirT)
        Me.pageTarjetas.Controls.Add(Me.btnGuardarT)
        Me.pageTarjetas.Controls.Add(Me.GridTarjetas)
        Me.pageTarjetas.Controls.Add(Me.chbActivoTarjeta)
        Me.pageTarjetas.Controls.Add(Me.txtNombreTarjeta)
        Me.pageTarjetas.Controls.Add(Me.lblNombreTarjeta)
        Me.pageTarjetas.Location = New System.Drawing.Point(4, 22)
        Me.pageTarjetas.Name = "pageTarjetas"
        Me.pageTarjetas.Padding = New System.Windows.Forms.Padding(3)
        Me.pageTarjetas.Size = New System.Drawing.Size(811, 404)
        Me.pageTarjetas.TabIndex = 1
        Me.pageTarjetas.Text = "Tarjetas"
        '
        'btnSalirT
        '
        Me.btnSalirT.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalirT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirT.Location = New System.Drawing.Point(459, 336)
        Me.btnSalirT.Name = "btnSalirT"
        Me.btnSalirT.Size = New System.Drawing.Size(75, 51)
        Me.btnSalirT.TabIndex = 98
        Me.btnSalirT.UseVisualStyleBackColor = True
        '
        'btnGuardarT
        '
        Me.btnGuardarT.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardarT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarT.Location = New System.Drawing.Point(273, 336)
        Me.btnGuardarT.Name = "btnGuardarT"
        Me.btnGuardarT.Size = New System.Drawing.Size(75, 51)
        Me.btnGuardarT.TabIndex = 97
        Me.btnGuardarT.UseVisualStyleBackColor = True
        '
        'GridTarjetas
        '
        Me.GridTarjetas.AllowUserToAddRows = False
        Me.GridTarjetas.AllowUserToDeleteRows = False
        Me.GridTarjetas.AllowUserToResizeColumns = False
        Me.GridTarjetas.AllowUserToResizeRows = False
        Me.GridTarjetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridTarjetas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTarjetas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.GridTarjetas.Location = New System.Drawing.Point(438, 1)
        Me.GridTarjetas.Name = "GridTarjetas"
        Me.GridTarjetas.Size = New System.Drawing.Size(370, 321)
        Me.GridTarjetas.TabIndex = 96
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 139.201!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre de la tarjeta"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 47.34727!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Activo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 63.45178!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Editar"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'chbActivoTarjeta
        '
        Me.chbActivoTarjeta.AutoSize = True
        Me.chbActivoTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbActivoTarjeta.ForeColor = System.Drawing.SystemColors.Control
        Me.chbActivoTarjeta.Location = New System.Drawing.Point(9, 78)
        Me.chbActivoTarjeta.Name = "chbActivoTarjeta"
        Me.chbActivoTarjeta.Size = New System.Drawing.Size(64, 20)
        Me.chbActivoTarjeta.TabIndex = 95
        Me.chbActivoTarjeta.Text = "Activo"
        Me.chbActivoTarjeta.UseVisualStyleBackColor = True
        '
        'txtNombreTarjeta
        '
        Me.txtNombreTarjeta.Location = New System.Drawing.Point(9, 43)
        Me.txtNombreTarjeta.Name = "txtNombreTarjeta"
        Me.txtNombreTarjeta.Size = New System.Drawing.Size(376, 20)
        Me.txtNombreTarjeta.TabIndex = 94
        '
        'lblNombreTarjeta
        '
        Me.lblNombreTarjeta.AutoSize = True
        Me.lblNombreTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreTarjeta.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombreTarjeta.Location = New System.Drawing.Point(6, 12)
        Me.lblNombreTarjeta.Name = "lblNombreTarjeta"
        Me.lblNombreTarjeta.Size = New System.Drawing.Size(133, 16)
        Me.lblNombreTarjeta.TabIndex = 93
        Me.lblNombreTarjeta.Text = "Nombre de la tarjeta:"
        '
        'BancosEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(836, 512)
        Me.Controls.Add(Me.tabBancosTarjetas)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "BancosEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BancosEDC"
        Me.tabBancosTarjetas.ResumeLayout(False)
        Me.pageBancos.ResumeLayout(False)
        Me.pageBancos.PerformLayout()
        CType(Me.GridBancos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pageTarjetas.ResumeLayout(False)
        Me.pageTarjetas.PerformLayout()
        CType(Me.GridTarjetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents tabBancosTarjetas As TabControl
    Friend WithEvents pageBancos As TabPage
    Friend WithEvents pageTarjetas As TabPage
    Friend WithEvents GridBancos As DataGridView
    Friend WithEvents lblNombreBanco As Label
    Friend WithEvents txtNombreBanco As TextBox
    Friend WithEvents chbActivoBanco As CheckBox
    Friend WithEvents TreeTarjetas As TreeView
    Friend WithEvents chbActivoTarjeta As CheckBox
    Friend WithEvents txtNombreTarjeta As TextBox
    Friend WithEvents lblNombreTarjeta As Label
    Friend WithEvents GridTarjetas As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewCheckBoxColumn
    Friend WithEvents IDColumn As DataGridViewTextBoxColumn
    Friend WithEvents NuevoPrecio As DataGridViewTextBoxColumn
    Friend WithEvents Activo As DataGridViewTextBoxColumn
    Friend WithEvents Editar As DataGridViewCheckBoxColumn
    Friend WithEvents btnSalirT As Button
    Friend WithEvents btnGuardarT As Button
    Friend WithEvents btnSalirB As Button
    Friend WithEvents btnGuardarB As Button
    Friend WithEvents ImageTree As ImageList
End Class
