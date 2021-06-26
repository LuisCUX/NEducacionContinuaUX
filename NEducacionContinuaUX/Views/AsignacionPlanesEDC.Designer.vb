<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignacionPlanesEDC
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsignacionPlanesEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.panelBusqueda = New System.Windows.Forms.Panel()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.panelRegistro = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GridPagos = New System.Windows.Forms.DataGridView()
        Me.cbPlanes = New System.Windows.Forms.ComboBox()
        Me.lblPlanes = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pageAsignacion = New System.Windows.Forms.TabPage()
        Me.pageCambio = New System.Windows.Forms.TabPage()
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
        Me.pageModificacion = New System.Windows.Forms.TabPage()
        Me.panelModificacion3 = New System.Windows.Forms.Panel()
        Me.lblPlanActual3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GridActual3 = New System.Windows.Forms.DataGridView()
        Me.IDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitarioColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecargoColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoActualColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NuevoDescuentoColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelInfo3 = New System.Windows.Forms.Panel()
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
        Me.panelBusqueda.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.panelRegistro.SuspendLayout()
        CType(Me.GridPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.pageAsignacion.SuspendLayout()
        Me.pageCambio.SuspendLayout()
        Me.panelBusqueda2.SuspendLayout()
        Me.panelPlan2.SuspendLayout()
        CType(Me.GridNuevoPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPlanActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelInfo2.SuspendLayout()
        Me.pageModificacion.SuspendLayout()
        Me.panelModificacion3.SuspendLayout()
        CType(Me.GridActual3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelInfo3.SuspendLayout()
        Me.panelBusqueda3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(829, 69)
        Me.lblNombreVentana.TabIndex = 11
        Me.lblNombreVentana.Text = "Asignación de planes"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbExterno
        '
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(303, 8)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(478, 21)
        Me.cbExterno.TabIndex = 78
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
        'panelBusqueda
        '
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBusqueda.Controls.Add(Me.cbExterno)
        Me.panelBusqueda.Location = New System.Drawing.Point(6, 6)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(788, 39)
        Me.panelBusqueda.TabIndex = 83
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
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.txtEmail)
        Me.panelDatos.Controls.Add(Me.txtNombre)
        Me.panelDatos.Location = New System.Drawing.Point(6, 51)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(788, 65)
        Me.panelDatos.TabIndex = 0
        Me.panelDatos.Visible = False
        '
        'panelRegistro
        '
        Me.panelRegistro.Controls.Add(Me.btnSalir)
        Me.panelRegistro.Controls.Add(Me.btnGuardar)
        Me.panelRegistro.Controls.Add(Me.GridPagos)
        Me.panelRegistro.Controls.Add(Me.cbPlanes)
        Me.panelRegistro.Controls.Add(Me.lblPlanes)
        Me.panelRegistro.Location = New System.Drawing.Point(6, 123)
        Me.panelRegistro.Name = "panelRegistro"
        Me.panelRegistro.Size = New System.Drawing.Size(788, 553)
        Me.panelRegistro.TabIndex = 84
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.pageAsignacion)
        Me.TabControl1.Controls.Add(Me.pageCambio)
        Me.TabControl1.Controls.Add(Me.pageModificacion)
        Me.TabControl1.Location = New System.Drawing.Point(7, 72)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(811, 708)
        Me.TabControl1.TabIndex = 85
        '
        'pageAsignacion
        '
        Me.pageAsignacion.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.pageAsignacion.Controls.Add(Me.panelBusqueda)
        Me.pageAsignacion.Controls.Add(Me.panelRegistro)
        Me.pageAsignacion.Controls.Add(Me.panelDatos)
        Me.pageAsignacion.Location = New System.Drawing.Point(4, 22)
        Me.pageAsignacion.Name = "pageAsignacion"
        Me.pageAsignacion.Padding = New System.Windows.Forms.Padding(3)
        Me.pageAsignacion.Size = New System.Drawing.Size(803, 682)
        Me.pageAsignacion.TabIndex = 0
        Me.pageAsignacion.Text = "Asignación de plan"
        '
        'pageCambio
        '
        Me.pageCambio.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.pageCambio.Controls.Add(Me.panelBusqueda2)
        Me.pageCambio.Controls.Add(Me.panelPlan2)
        Me.pageCambio.Controls.Add(Me.panelInfo2)
        Me.pageCambio.Location = New System.Drawing.Point(4, 22)
        Me.pageCambio.Name = "pageCambio"
        Me.pageCambio.Padding = New System.Windows.Forms.Padding(3)
        Me.pageCambio.Size = New System.Drawing.Size(803, 682)
        Me.pageCambio.TabIndex = 1
        Me.pageCambio.Text = "Cambio de plan"
        '
        'panelBusqueda2
        '
        Me.panelBusqueda2.Controls.Add(Me.txtMatricula2)
        Me.panelBusqueda2.Controls.Add(Me.lblMatricula2)
        Me.panelBusqueda2.Controls.Add(Me.btnBuscar2)
        Me.panelBusqueda2.Controls.Add(Me.lblNombre2)
        Me.panelBusqueda2.Controls.Add(Me.cbNombre2)
        Me.panelBusqueda2.Location = New System.Drawing.Point(7, 6)
        Me.panelBusqueda2.Name = "panelBusqueda2"
        Me.panelBusqueda2.Size = New System.Drawing.Size(788, 39)
        Me.panelBusqueda2.TabIndex = 86
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
        Me.panelPlan2.Location = New System.Drawing.Point(7, 123)
        Me.panelPlan2.Name = "panelPlan2"
        Me.panelPlan2.Size = New System.Drawing.Size(788, 553)
        Me.panelPlan2.TabIndex = 87
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
        Me.panelInfo2.Location = New System.Drawing.Point(7, 51)
        Me.panelInfo2.Name = "panelInfo2"
        Me.panelInfo2.Size = New System.Drawing.Size(788, 65)
        Me.panelInfo2.TabIndex = 85
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
        'pageModificacion
        '
        Me.pageModificacion.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.pageModificacion.Controls.Add(Me.panelModificacion3)
        Me.pageModificacion.Controls.Add(Me.panelInfo3)
        Me.pageModificacion.Controls.Add(Me.panelBusqueda3)
        Me.pageModificacion.Location = New System.Drawing.Point(4, 22)
        Me.pageModificacion.Name = "pageModificacion"
        Me.pageModificacion.Size = New System.Drawing.Size(803, 682)
        Me.pageModificacion.TabIndex = 2
        Me.pageModificacion.Text = "Modificación de plan"
        '
        'panelModificacion3
        '
        Me.panelModificacion3.Controls.Add(Me.lblPlanActual3)
        Me.panelModificacion3.Controls.Add(Me.Button2)
        Me.panelModificacion3.Controls.Add(Me.Button3)
        Me.panelModificacion3.Controls.Add(Me.GridActual3)
        Me.panelModificacion3.Location = New System.Drawing.Point(7, 122)
        Me.panelModificacion3.Name = "panelModificacion3"
        Me.panelModificacion3.Size = New System.Drawing.Size(788, 553)
        Me.panelModificacion3.TabIndex = 88
        Me.panelModificacion3.Visible = False
        '
        'lblPlanActual3
        '
        Me.lblPlanActual3.AutoSize = True
        Me.lblPlanActual3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanActual3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPlanActual3.Location = New System.Drawing.Point(8, 7)
        Me.lblPlanActual3.Name = "lblPlanActual3"
        Me.lblPlanActual3.Size = New System.Drawing.Size(77, 16)
        Me.lblPlanActual3.TabIndex = 86
        Me.lblPlanActual3.Text = "Plan actual:"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(238, 504)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 46)
        Me.Button2.TabIndex = 83
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Location = New System.Drawing.Point(467, 504)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(60, 46)
        Me.Button3.TabIndex = 82
        Me.Button3.UseVisualStyleBackColor = True
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
        Me.GridActual3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDColumn, Me.DescripcionColumn, Me.PrecioUnitarioColumn, Me.RecargoColumn, Me.DescuentoActualColumn, Me.NuevoDescuentoColumn})
        Me.GridActual3.Location = New System.Drawing.Point(6, 27)
        Me.GridActual3.Name = "GridActual3"
        Me.GridActual3.Size = New System.Drawing.Size(775, 321)
        Me.GridActual3.TabIndex = 81
        '
        'IDColumn
        '
        Me.IDColumn.HeaderText = "ID"
        Me.IDColumn.Name = "IDColumn"
        Me.IDColumn.ReadOnly = True
        Me.IDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IDColumn.Visible = False
        '
        'DescripcionColumn
        '
        Me.DescripcionColumn.HeaderText = "Descripcion"
        Me.DescripcionColumn.Name = "DescripcionColumn"
        Me.DescripcionColumn.ReadOnly = True
        Me.DescripcionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'PrecioUnitarioColumn
        '
        Me.PrecioUnitarioColumn.FillWeight = 50.0!
        Me.PrecioUnitarioColumn.HeaderText = "Precio unitario"
        Me.PrecioUnitarioColumn.Name = "PrecioUnitarioColumn"
        Me.PrecioUnitarioColumn.ReadOnly = True
        Me.PrecioUnitarioColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'RecargoColumn
        '
        Me.RecargoColumn.FillWeight = 50.0!
        Me.RecargoColumn.HeaderText = "Recargo"
        Me.RecargoColumn.Name = "RecargoColumn"
        Me.RecargoColumn.ReadOnly = True
        Me.RecargoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DescuentoActualColumn
        '
        Me.DescuentoActualColumn.FillWeight = 50.0!
        Me.DescuentoActualColumn.HeaderText = "Descuento actual"
        Me.DescuentoActualColumn.Name = "DescuentoActualColumn"
        Me.DescuentoActualColumn.ReadOnly = True
        Me.DescuentoActualColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'NuevoDescuentoColumn
        '
        Me.NuevoDescuentoColumn.FillWeight = 50.0!
        Me.NuevoDescuentoColumn.HeaderText = "Nuevo descuento"
        Me.NuevoDescuentoColumn.Name = "NuevoDescuentoColumn"
        Me.NuevoDescuentoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'panelInfo3
        '
        Me.panelInfo3.Controls.Add(Me.lblNombreInfo3)
        Me.panelInfo3.Controls.Add(Me.lblEmail3)
        Me.panelInfo3.Controls.Add(Me.txtEmail3)
        Me.panelInfo3.Controls.Add(Me.txtNombre3)
        Me.panelInfo3.Location = New System.Drawing.Point(7, 51)
        Me.panelInfo3.Name = "panelInfo3"
        Me.panelInfo3.Size = New System.Drawing.Size(788, 65)
        Me.panelInfo3.TabIndex = 86
        Me.panelInfo3.Visible = False
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
        Me.panelBusqueda3.Location = New System.Drawing.Point(7, 6)
        Me.panelBusqueda3.Name = "panelBusqueda3"
        Me.panelBusqueda3.Size = New System.Drawing.Size(788, 39)
        Me.panelBusqueda3.TabIndex = 84
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
        'AsignacionPlanesEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(827, 792)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AsignacionPlanesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AsignacionPlanesEDC"
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.panelRegistro.ResumeLayout(False)
        Me.panelRegistro.PerformLayout()
        CType(Me.GridPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.pageAsignacion.ResumeLayout(False)
        Me.pageCambio.ResumeLayout(False)
        Me.panelBusqueda2.ResumeLayout(False)
        Me.panelBusqueda2.PerformLayout()
        Me.panelPlan2.ResumeLayout(False)
        Me.panelPlan2.PerformLayout()
        CType(Me.GridNuevoPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPlanActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelInfo2.ResumeLayout(False)
        Me.panelInfo2.PerformLayout()
        Me.pageModificacion.ResumeLayout(False)
        Me.panelModificacion3.ResumeLayout(False)
        Me.panelModificacion3.PerformLayout()
        CType(Me.GridActual3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelInfo3.ResumeLayout(False)
        Me.panelInfo3.PerformLayout()
        Me.panelBusqueda3.ResumeLayout(False)
        Me.panelBusqueda3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents lblMatricula As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents panelDatos As Panel
    Friend WithEvents panelRegistro As Panel
    Friend WithEvents lblPlanes As Label
    Friend WithEvents cbPlanes As ComboBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents GridPagos As DataGridView
    Friend WithEvents btnSalir As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents pageAsignacion As TabPage
    Friend WithEvents pageCambio As TabPage
    Friend WithEvents panelBusqueda2 As Panel
    Friend WithEvents txtMatricula2 As TextBox
    Friend WithEvents lblMatricula2 As Label
    Friend WithEvents btnBuscar2 As Button
    Friend WithEvents lblNombre2 As Label
    Friend WithEvents cbNombre2 As ComboBox
    Friend WithEvents panelPlan2 As Panel
    Friend WithEvents GridNuevoPlan As DataGridView
    Friend WithEvents btnSalir2 As Button
    Friend WithEvents btnGuardar2 As Button
    Friend WithEvents GridPlanActual As DataGridView
    Friend WithEvents panelInfo2 As Panel
    Friend WithEvents lblNombreA2 As Label
    Friend WithEvents lblEmail2 As Label
    Friend WithEvents txtEmail2 As TextBox
    Friend WithEvents txtNombre2 As TextBox
    Friend WithEvents lblNuevoPlan As Label
    Friend WithEvents lblPlanActual As Label
    Friend WithEvents cbNuevoPlan As ComboBox
    Friend WithEvents pageModificacion As TabPage
    Friend WithEvents panelBusqueda3 As Panel
    Friend WithEvents txtMatricula3 As TextBox
    Friend WithEvents lblMatricula3 As Label
    Friend WithEvents btnBuscar3 As Button
    Friend WithEvents lblNombre3 As Label
    Friend WithEvents cbBuscar3 As ComboBox
    Friend WithEvents panelInfo3 As Panel
    Friend WithEvents lblNombreInfo3 As Label
    Friend WithEvents lblEmail3 As Label
    Friend WithEvents txtEmail3 As TextBox
    Friend WithEvents txtNombre3 As TextBox
    Friend WithEvents panelModificacion3 As Panel
    Friend WithEvents lblPlanActual3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents GridActual3 As DataGridView
    Friend WithEvents IDColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitarioColumn As DataGridViewTextBoxColumn
    Friend WithEvents RecargoColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescuentoActualColumn As DataGridViewTextBoxColumn
    Friend WithEvents NuevoDescuentoColumn As DataGridViewTextBoxColumn
End Class
