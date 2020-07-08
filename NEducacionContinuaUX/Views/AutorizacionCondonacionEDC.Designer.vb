<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AutorizacionCondonacionEDC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutorizacionCondonacionEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.panelBusqueda = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbEDC = New System.Windows.Forms.RadioButton()
        Me.rbExterno = New System.Windows.Forms.RadioButton()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.txtMatriculaDato = New System.Windows.Forms.TextBox()
        Me.lblMatriculaDato = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTurno = New System.Windows.Forms.TextBox()
        Me.txtCarrera = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.panelAutCon = New System.Windows.Forms.Panel()
        Me.tabAutCon = New System.Windows.Forms.TabControl()
        Me.tabCondonaciones = New System.Windows.Forms.TabPage()
        Me.btnGuardarCondonaciones = New System.Windows.Forms.Button()
        Me.GridCondonaciones = New System.Windows.Forms.DataGridView()
        Me.Node = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbTipoCondonacion = New System.Windows.Forms.ComboBox()
        Me.lblTipoCondonacion = New System.Windows.Forms.Label()
        Me.TreeCondonaciones = New System.Windows.Forms.TreeView()
        Me.ImageListTree = New System.Windows.Forms.ImageList(Me.components)
        Me.tabAutorizacionCaja = New System.Windows.Forms.TabPage()
        Me.tabAutorizacionProceso = New System.Windows.Forms.TabPage()
        Me.treeAutorizacionCaja = New System.Windows.Forms.TreeView()
        Me.btnGuardarAutorizacionCaja = New System.Windows.Forms.Button()
        Me.GridAutorizacionCaja = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelBusqueda.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.panelAutCon.SuspendLayout()
        Me.tabAutCon.SuspendLayout()
        Me.tabCondonaciones.SuspendLayout()
        CType(Me.GridCondonaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAutorizacionCaja.SuspendLayout()
        CType(Me.GridAutorizacionCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1205, 69)
        Me.lblNombreVentana.TabIndex = 13
        Me.lblNombreVentana.Text = "Autorización y Condonación"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBusqueda
        '
        Me.panelBusqueda.Controls.Add(Me.Label2)
        Me.panelBusqueda.Controls.Add(Me.Label1)
        Me.panelBusqueda.Controls.Add(Me.rbEDC)
        Me.panelBusqueda.Controls.Add(Me.rbExterno)
        Me.panelBusqueda.Controls.Add(Me.cbExterno)
        Me.panelBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Location = New System.Drawing.Point(12, 72)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(1175, 50)
        Me.panelBusqueda.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(872, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "matricula:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(874, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Tipo de "
        '
        'rbEDC
        '
        Me.rbEDC.AutoSize = True
        Me.rbEDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEDC.ForeColor = System.Drawing.SystemColors.Control
        Me.rbEDC.Location = New System.Drawing.Point(1080, 16)
        Me.rbEDC.Name = "rbEDC"
        Me.rbEDC.Size = New System.Drawing.Size(92, 20)
        Me.rbEDC.TabIndex = 77
        Me.rbEDC.TabStop = True
        Me.rbEDC.Text = "Congresos"
        Me.rbEDC.UseVisualStyleBackColor = True
        '
        'rbExterno
        '
        Me.rbExterno.AutoSize = True
        Me.rbExterno.Checked = True
        Me.rbExterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbExterno.ForeColor = System.Drawing.SystemColors.Control
        Me.rbExterno.Location = New System.Drawing.Point(938, 14)
        Me.rbExterno.Name = "rbExterno"
        Me.rbExterno.Size = New System.Drawing.Size(136, 20)
        Me.rbExterno.TabIndex = 76
        Me.rbExterno.TabStop = True
        Me.rbExterno.Text = "Pagos opcionales"
        Me.rbExterno.UseVisualStyleBackColor = True
        '
        'cbExterno
        '
        Me.cbExterno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbExterno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(298, 15)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(556, 21)
        Me.cbExterno.TabIndex = 73
        '
        'lblBusquedaNombre
        '
        Me.lblBusquedaNombre.AutoSize = True
        Me.lblBusquedaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBusquedaNombre.Location = New System.Drawing.Point(241, 16)
        Me.lblBusquedaNombre.Name = "lblBusquedaNombre"
        Me.lblBusquedaNombre.Size = New System.Drawing.Size(63, 16)
        Me.lblBusquedaNombre.TabIndex = 3
        Me.lblBusquedaNombre.Text = "Nombre: "
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_32px
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.Location = New System.Drawing.Point(186, 7)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(41, 34)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtMatricula
        '
        Me.txtMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula.Location = New System.Drawing.Point(69, 13)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(111, 22)
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
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.txtMatriculaDato)
        Me.panelDatos.Controls.Add(Me.lblMatriculaDato)
        Me.panelDatos.Controls.Add(Me.lblTurno)
        Me.panelDatos.Controls.Add(Me.lblCarrera)
        Me.panelDatos.Controls.Add(Me.txtEmail)
        Me.panelDatos.Controls.Add(Me.txtTurno)
        Me.panelDatos.Controls.Add(Me.txtCarrera)
        Me.panelDatos.Controls.Add(Me.txtNombre)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Location = New System.Drawing.Point(12, 128)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(1175, 53)
        Me.panelDatos.TabIndex = 16
        Me.panelDatos.Visible = False
        '
        'txtMatriculaDato
        '
        Me.txtMatriculaDato.Enabled = False
        Me.txtMatriculaDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatriculaDato.Location = New System.Drawing.Point(69, 6)
        Me.txtMatriculaDato.Name = "txtMatriculaDato"
        Me.txtMatriculaDato.Size = New System.Drawing.Size(111, 21)
        Me.txtMatriculaDato.TabIndex = 26
        '
        'lblMatriculaDato
        '
        Me.lblMatriculaDato.AutoSize = True
        Me.lblMatriculaDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatriculaDato.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatriculaDato.Location = New System.Drawing.Point(7, 9)
        Me.lblMatriculaDato.Name = "lblMatriculaDato"
        Me.lblMatriculaDato.Size = New System.Drawing.Size(61, 15)
        Me.lblMatriculaDato.TabIndex = 25
        Me.lblMatriculaDato.Text = "Matricula:"
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurno.Location = New System.Drawing.Point(694, 31)
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
        Me.lblCarrera.Location = New System.Drawing.Point(7, 31)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Size = New System.Drawing.Size(51, 15)
        Me.lblCarrera.TabIndex = 21
        Me.lblCarrera.Text = "Carrera:"
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(764, 6)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(392, 21)
        Me.txtEmail.TabIndex = 20
        '
        'txtTurno
        '
        Me.txtTurno.Enabled = False
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.Location = New System.Drawing.Point(764, 28)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.Size = New System.Drawing.Size(392, 21)
        Me.txtTurno.TabIndex = 24
        '
        'txtCarrera
        '
        Me.txtCarrera.Enabled = False
        Me.txtCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarrera.Location = New System.Drawing.Point(69, 28)
        Me.txtCarrera.Name = "txtCarrera"
        Me.txtCarrera.Size = New System.Drawing.Size(590, 21)
        Me.txtCarrera.TabIndex = 22
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(244, 6)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(415, 21)
        Me.txtNombre.TabIndex = 18
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail.Location = New System.Drawing.Point(694, 9)
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
        Me.lblNombre.Location = New System.Drawing.Point(183, 9)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblNombre.TabIndex = 18
        Me.lblNombre.Text = "Nombre: "
        '
        'panelAutCon
        '
        Me.panelAutCon.Controls.Add(Me.tabAutCon)
        Me.panelAutCon.Location = New System.Drawing.Point(12, 187)
        Me.panelAutCon.Name = "panelAutCon"
        Me.panelAutCon.Size = New System.Drawing.Size(1175, 473)
        Me.panelAutCon.TabIndex = 17
        Me.panelAutCon.Visible = False
        '
        'tabAutCon
        '
        Me.tabAutCon.Controls.Add(Me.tabCondonaciones)
        Me.tabAutCon.Controls.Add(Me.tabAutorizacionCaja)
        Me.tabAutCon.Controls.Add(Me.tabAutorizacionProceso)
        Me.tabAutCon.Location = New System.Drawing.Point(3, 3)
        Me.tabAutCon.Name = "tabAutCon"
        Me.tabAutCon.SelectedIndex = 0
        Me.tabAutCon.Size = New System.Drawing.Size(1169, 467)
        Me.tabAutCon.TabIndex = 0
        '
        'tabCondonaciones
        '
        Me.tabCondonaciones.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabCondonaciones.Controls.Add(Me.btnGuardarCondonaciones)
        Me.tabCondonaciones.Controls.Add(Me.GridCondonaciones)
        Me.tabCondonaciones.Controls.Add(Me.cbTipoCondonacion)
        Me.tabCondonaciones.Controls.Add(Me.lblTipoCondonacion)
        Me.tabCondonaciones.Controls.Add(Me.TreeCondonaciones)
        Me.tabCondonaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCondonaciones.Location = New System.Drawing.Point(4, 22)
        Me.tabCondonaciones.Name = "tabCondonaciones"
        Me.tabCondonaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCondonaciones.Size = New System.Drawing.Size(1161, 441)
        Me.tabCondonaciones.TabIndex = 0
        Me.tabCondonaciones.Text = "Condonacion parcial o total"
        '
        'btnGuardarCondonaciones
        '
        Me.btnGuardarCondonaciones.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.descargar
        Me.btnGuardarCondonaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarCondonaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarCondonaciones.Location = New System.Drawing.Point(1083, 385)
        Me.btnGuardarCondonaciones.Name = "btnGuardarCondonaciones"
        Me.btnGuardarCondonaciones.Size = New System.Drawing.Size(72, 53)
        Me.btnGuardarCondonaciones.TabIndex = 15
        Me.btnGuardarCondonaciones.UseVisualStyleBackColor = True
        '
        'GridCondonaciones
        '
        Me.GridCondonaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridCondonaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridCondonaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCondonaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Node, Me.Concepto, Me.Porcentaje})
        Me.GridCondonaciones.Location = New System.Drawing.Point(592, 69)
        Me.GridCondonaciones.Name = "GridCondonaciones"
        Me.GridCondonaciones.Size = New System.Drawing.Size(563, 307)
        Me.GridCondonaciones.TabIndex = 12
        '
        'Node
        '
        Me.Node.HeaderText = "Node"
        Me.Node.Name = "Node"
        Me.Node.Visible = False
        '
        'Concepto
        '
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        '
        'Porcentaje
        '
        Me.Porcentaje.FillWeight = 15.0!
        Me.Porcentaje.HeaderText = "Porcentaje"
        Me.Porcentaje.Name = "Porcentaje"
        '
        'cbTipoCondonacion
        '
        Me.cbTipoCondonacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoCondonacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoCondonacion.FormattingEnabled = True
        Me.cbTipoCondonacion.Location = New System.Drawing.Point(166, 25)
        Me.cbTipoCondonacion.Name = "cbTipoCondonacion"
        Me.cbTipoCondonacion.Size = New System.Drawing.Size(402, 24)
        Me.cbTipoCondonacion.TabIndex = 11
        '
        'lblTipoCondonacion
        '
        Me.lblTipoCondonacion.AutoSize = True
        Me.lblTipoCondonacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCondonacion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoCondonacion.Location = New System.Drawing.Point(11, 26)
        Me.lblTipoCondonacion.Name = "lblTipoCondonacion"
        Me.lblTipoCondonacion.Size = New System.Drawing.Size(155, 18)
        Me.lblTipoCondonacion.TabIndex = 10
        Me.lblTipoCondonacion.Text = "Tipo de condonación: "
        '
        'TreeCondonaciones
        '
        Me.TreeCondonaciones.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TreeCondonaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeCondonaciones.ForeColor = System.Drawing.SystemColors.Control
        Me.TreeCondonaciones.Location = New System.Drawing.Point(14, 69)
        Me.TreeCondonaciones.Name = "TreeCondonaciones"
        Me.TreeCondonaciones.Size = New System.Drawing.Size(554, 366)
        Me.TreeCondonaciones.StateImageList = Me.ImageListTree
        Me.TreeCondonaciones.TabIndex = 9
        '
        'ImageListTree
        '
        Me.ImageListTree.ImageStream = CType(resources.GetObject("ImageListTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTree.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListTree.Images.SetKeyName(0, "unchecked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(1, "checked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(2, "folder_40px.png")
        '
        'tabAutorizacionCaja
        '
        Me.tabAutorizacionCaja.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabAutorizacionCaja.Controls.Add(Me.btnGuardarAutorizacionCaja)
        Me.tabAutorizacionCaja.Controls.Add(Me.GridAutorizacionCaja)
        Me.tabAutorizacionCaja.Controls.Add(Me.treeAutorizacionCaja)
        Me.tabAutorizacionCaja.Location = New System.Drawing.Point(4, 22)
        Me.tabAutorizacionCaja.Name = "tabAutorizacionCaja"
        Me.tabAutorizacionCaja.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAutorizacionCaja.Size = New System.Drawing.Size(1161, 441)
        Me.tabAutorizacionCaja.TabIndex = 1
        Me.tabAutorizacionCaja.Text = "Autorizacion de Caja"
        '
        'tabAutorizacionProceso
        '
        Me.tabAutorizacionProceso.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabAutorizacionProceso.Location = New System.Drawing.Point(4, 22)
        Me.tabAutorizacionProceso.Name = "tabAutorizacionProceso"
        Me.tabAutorizacionProceso.Size = New System.Drawing.Size(1161, 441)
        Me.tabAutorizacionProceso.TabIndex = 2
        Me.tabAutorizacionProceso.Text = "Autorizacion de Proceso"
        '
        'treeAutorizacionCaja
        '
        Me.treeAutorizacionCaja.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.treeAutorizacionCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeAutorizacionCaja.ForeColor = System.Drawing.SystemColors.Control
        Me.treeAutorizacionCaja.Location = New System.Drawing.Point(16, 15)
        Me.treeAutorizacionCaja.Name = "treeAutorizacionCaja"
        Me.treeAutorizacionCaja.Size = New System.Drawing.Size(568, 411)
        Me.treeAutorizacionCaja.StateImageList = Me.ImageListTree
        Me.treeAutorizacionCaja.TabIndex = 10
        '
        'btnGuardarAutorizacionCaja
        '
        Me.btnGuardarAutorizacionCaja.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.descargar
        Me.btnGuardarAutorizacionCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarAutorizacionCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarAutorizacionCaja.Location = New System.Drawing.Point(1083, 373)
        Me.btnGuardarAutorizacionCaja.Name = "btnGuardarAutorizacionCaja"
        Me.btnGuardarAutorizacionCaja.Size = New System.Drawing.Size(72, 53)
        Me.btnGuardarAutorizacionCaja.TabIndex = 17
        Me.btnGuardarAutorizacionCaja.UseVisualStyleBackColor = True
        '
        'GridAutorizacionCaja
        '
        Me.GridAutorizacionCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridAutorizacionCaja.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridAutorizacionCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAutorizacionCaja.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.GridAutorizacionCaja.Location = New System.Drawing.Point(592, 15)
        Me.GridAutorizacionCaja.Name = "GridAutorizacionCaja"
        Me.GridAutorizacionCaja.Size = New System.Drawing.Size(563, 330)
        Me.GridAutorizacionCaja.TabIndex = 16
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Node"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Concepto"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'AutorizacionCondonacionEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1199, 672)
        Me.Controls.Add(Me.panelAutCon)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.panelBusqueda)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "AutorizacionCondonacionEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AutorizacionCondonacionEDC"
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.panelAutCon.ResumeLayout(False)
        Me.tabAutCon.ResumeLayout(False)
        Me.tabCondonaciones.ResumeLayout(False)
        Me.tabCondonaciones.PerformLayout()
        CType(Me.GridCondonaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAutorizacionCaja.ResumeLayout(False)
        CType(Me.GridAutorizacionCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents lblMatricula As Label
    Friend WithEvents panelDatos As Panel
    Friend WithEvents txtMatriculaDato As TextBox
    Friend WithEvents lblMatriculaDato As Label
    Friend WithEvents lblTurno As Label
    Friend WithEvents lblCarrera As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTurno As TextBox
    Friend WithEvents txtCarrera As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents panelAutCon As Panel
    Friend WithEvents tabAutCon As TabControl
    Friend WithEvents tabCondonaciones As TabPage
    Friend WithEvents tabAutorizacionCaja As TabPage
    Friend WithEvents tabAutorizacionProceso As TabPage
    Friend WithEvents ImageListTree As ImageList
    Friend WithEvents lblTipoCondonacion As Label
    Friend WithEvents TreeCondonaciones As TreeView
    Friend WithEvents cbTipoCondonacion As ComboBox
    Friend WithEvents GridCondonaciones As DataGridView
    Friend WithEvents btnGuardarCondonaciones As Button
    Friend WithEvents Node As DataGridViewTextBoxColumn
    Friend WithEvents Concepto As DataGridViewTextBoxColumn
    Friend WithEvents Porcentaje As DataGridViewTextBoxColumn
    Friend WithEvents rbEDC As RadioButton
    Friend WithEvents rbExterno As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnGuardarAutorizacionCaja As Button
    Friend WithEvents GridAutorizacionCaja As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents treeAutorizacionCaja As TreeView
End Class
