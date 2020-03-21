<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModalCobrosDiferidosEDC
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModalCobrosDiferidosEDC))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Eventos")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pagos Opcionales")
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTurno = New System.Windows.Forms.TextBox()
        Me.txtCarrera = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.panelBusqueda = New System.Windows.Forms.Panel()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.panelPagos = New System.Windows.Forms.Panel()
        Me.btnCobrar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.ImageListTree = New System.Windows.Forms.ImageList(Me.components)
        Me.Tree = New System.Windows.Forms.TreeView()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.panelDatos.SuspendLayout()
        Me.panelBusqueda.SuspendLayout()
        Me.panelPagos.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(799, 69)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Cobros"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.lblTurno)
        Me.panelDatos.Controls.Add(Me.lblCarrera)
        Me.panelDatos.Controls.Add(Me.txtEmail)
        Me.panelDatos.Controls.Add(Me.txtTurno)
        Me.panelDatos.Controls.Add(Me.txtCarrera)
        Me.panelDatos.Controls.Add(Me.txtNombre)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Location = New System.Drawing.Point(261, 72)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(527, 107)
        Me.panelDatos.TabIndex = 18
        Me.panelDatos.Visible = False
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurno.Location = New System.Drawing.Point(7, 79)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(42, 15)
        Me.lblTurno.TabIndex = 23
        Me.lblTurno.Text = "Turno:"
        '
        'lblCarrera
        '
        Me.lblCarrera.AutoSize = True
        Me.lblCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarrera.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCarrera.Location = New System.Drawing.Point(7, 57)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Size = New System.Drawing.Size(51, 15)
        Me.lblCarrera.TabIndex = 21
        Me.lblCarrera.Text = "Carrera:"
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(77, 32)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(392, 21)
        Me.txtEmail.TabIndex = 20
        '
        'txtTurno
        '
        Me.txtTurno.Enabled = False
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.Location = New System.Drawing.Point(77, 76)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.Size = New System.Drawing.Size(392, 21)
        Me.txtTurno.TabIndex = 24
        '
        'txtCarrera
        '
        Me.txtCarrera.Enabled = False
        Me.txtCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarrera.Location = New System.Drawing.Point(77, 54)
        Me.txtCarrera.Name = "txtCarrera"
        Me.txtCarrera.Size = New System.Drawing.Size(392, 21)
        Me.txtCarrera.TabIndex = 22
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(77, 10)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(392, 21)
        Me.txtNombre.TabIndex = 18
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail.Location = New System.Drawing.Point(7, 35)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail.TabIndex = 19
        Me.lblEmail.Text = "Email:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre.Location = New System.Drawing.Point(7, 11)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblNombre.TabIndex = 18
        Me.lblNombre.Text = "Nombre: "
        '
        'panelBusqueda
        '
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Location = New System.Drawing.Point(5, 72)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(250, 107)
        Me.panelBusqueda.TabIndex = 17
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_32px
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.Location = New System.Drawing.Point(186, 44)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(41, 34)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtMatricula
        '
        Me.txtMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula.Location = New System.Drawing.Point(10, 50)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(170, 22)
        Me.txtMatricula.TabIndex = 1
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula.Location = New System.Drawing.Point(7, 16)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(65, 16)
        Me.lblMatricula.TabIndex = 0
        Me.lblMatricula.Text = "Matricula:"
        '
        'panelPagos
        '
        Me.panelPagos.Controls.Add(Me.lblPeso)
        Me.panelPagos.Controls.Add(Me.lblTotal)
        Me.panelPagos.Controls.Add(Me.Tree)
        Me.panelPagos.Controls.Add(Me.btnSalir)
        Me.panelPagos.Controls.Add(Me.btnCobrar)
        Me.panelPagos.Location = New System.Drawing.Point(4, 185)
        Me.panelPagos.Name = "panelPagos"
        Me.panelPagos.Size = New System.Drawing.Size(784, 403)
        Me.panelPagos.TabIndex = 19
        Me.panelPagos.Visible = False
        '
        'btnCobrar
        '
        Me.btnCobrar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.descargar
        Me.btnCobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCobrar.Location = New System.Drawing.Point(187, 356)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(70, 40)
        Me.btnCobrar.TabIndex = 21
        Me.btnCobrar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_32px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(537, 356)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(70, 40)
        Me.btnSalir.TabIndex = 20
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'ImageListTree
        '
        Me.ImageListTree.ImageStream = CType(resources.GetObject("ImageListTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTree.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListTree.Images.SetKeyName(0, "unchecked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(1, "checked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(2, "folder_40px.png")
        '
        'Tree
        '
        Me.Tree.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Tree.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tree.ForeColor = System.Drawing.SystemColors.Control
        Me.Tree.Location = New System.Drawing.Point(11, 17)
        Me.Tree.Name = "Tree"
        TreeNode1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        TreeNode1.ForeColor = System.Drawing.SystemColors.Control
        TreeNode1.Name = "nodeEventos"
        TreeNode1.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode1.SelectedImageIndex = -2
        TreeNode1.StateImageIndex = 2
        TreeNode1.Text = "Eventos"
        TreeNode2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        TreeNode2.ForeColor = System.Drawing.SystemColors.Control
        TreeNode2.Name = "nodePagosOpcionales"
        TreeNode2.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode2.SelectedImageIndex = -2
        TreeNode2.StateImageIndex = 2
        TreeNode2.Text = "Pagos Opcionales"
        Me.Tree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Me.Tree.Size = New System.Drawing.Size(766, 268)
        Me.Tree.StateImageList = Me.ImageListTree
        Me.Tree.TabIndex = 24
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPeso.Location = New System.Drawing.Point(532, 301)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(26, 29)
        Me.lblPeso.TabIndex = 26
        Me.lblPeso.Text = "$"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Location = New System.Drawing.Point(552, 301)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 29)
        Me.lblTotal.TabIndex = 25
        '
        'ModalCobrosDiferidosEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(793, 593)
        Me.Controls.Add(Me.panelPagos)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.panelBusqueda)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "ModalCobrosDiferidosEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ModalCobrosDiferidosEDC"
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelPagos.ResumeLayout(False)
        Me.panelPagos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelDatos As Panel
    Friend WithEvents lblTurno As Label
    Friend WithEvents lblCarrera As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTurno As TextBox
    Friend WithEvents txtCarrera As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents lblMatricula As Label
    Friend WithEvents panelPagos As Panel
    Friend WithEvents btnCobrar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents ImageListTree As ImageList
    Friend WithEvents Tree As TreeView
    Friend WithEvents lblPeso As Label
    Friend WithEvents lblTotal As Label
End Class
