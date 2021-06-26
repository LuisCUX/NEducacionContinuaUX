<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CobrosEDC
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Congresos")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pagos Opcionales")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inscripción a Diplomados")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Colegiaturas de Diplomados")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pago Unico de Diplomado")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recargos de Diplomados")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CobrosEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.panelBusqueda = New System.Windows.Forms.Panel()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.txtRFC = New System.Windows.Forms.TextBox()
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
        Me.panelCobros = New System.Windows.Forms.Panel()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.txtNoCuenta = New System.Windows.Forms.TextBox()
        Me.lblNoCuenta = New System.Windows.Forms.Label()
        Me.txtNoCheque = New System.Windows.Forms.TextBox()
        Me.lblNoCheque = New System.Windows.Forms.Label()
        Me.txtUltimos4Digitos = New System.Windows.Forms.TextBox()
        Me.lblUltimosDigitos = New System.Windows.Forms.Label()
        Me.DTPickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.cbTipoBanco = New System.Windows.Forms.ComboBox()
        Me.lblTIpoBanco = New System.Windows.Forms.Label()
        Me.cbBanco = New System.Windows.Forms.ComboBox()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Tree = New System.Windows.Forms.TreeView()
        Me.ImageListTree = New System.Windows.Forms.ImageList(Me.components)
        Me.cbFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblFormadepago = New System.Windows.Forms.Label()
        Me.btnCobrar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblPendientes = New System.Windows.Forms.Label()
        Me.panelBusqueda.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.panelCobros.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-1, 1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1319, 69)
        Me.lblNombreVentana.TabIndex = 12
        Me.lblNombreVentana.Text = "Cobros"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBusqueda
        '
        Me.panelBusqueda.Controls.Add(Me.cbExterno)
        Me.panelBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Location = New System.Drawing.Point(5, 73)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(1300, 50)
        Me.panelBusqueda.TabIndex = 14
        '
        'cbExterno
        '
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(300, 14)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(586, 21)
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
        Me.btnBuscar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
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
        Me.lblMatricula.Text = "Matrícula:"
        '
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.lblRFC)
        Me.panelDatos.Controls.Add(Me.txtRFC)
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
        Me.panelDatos.Location = New System.Drawing.Point(5, 127)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(1300, 101)
        Me.panelDatos.TabIndex = 15
        Me.panelDatos.Visible = False
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFC.Location = New System.Drawing.Point(204, 6)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 15)
        Me.lblRFC.TabIndex = 27
        Me.lblRFC.Text = "RFC:"
        '
        'txtRFC
        '
        Me.txtRFC.Enabled = False
        Me.txtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRFC.Location = New System.Drawing.Point(244, 3)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(240, 21)
        Me.txtRFC.TabIndex = 28
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
        Me.lblMatriculaDato.Text = "Matrícula:"
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurno.Location = New System.Drawing.Point(499, 6)
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
        Me.lblCarrera.Location = New System.Drawing.Point(7, 77)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Size = New System.Drawing.Size(51, 15)
        Me.lblCarrera.TabIndex = 21
        Me.lblCarrera.Text = "Carrera:"
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(69, 51)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(817, 21)
        Me.txtEmail.TabIndex = 20
        '
        'txtTurno
        '
        Me.txtTurno.Enabled = False
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.Location = New System.Drawing.Point(569, 3)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.Size = New System.Drawing.Size(149, 21)
        Me.txtTurno.TabIndex = 24
        '
        'txtCarrera
        '
        Me.txtCarrera.Enabled = False
        Me.txtCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarrera.Location = New System.Drawing.Point(69, 74)
        Me.txtCarrera.Name = "txtCarrera"
        Me.txtCarrera.Size = New System.Drawing.Size(817, 21)
        Me.txtCarrera.TabIndex = 22
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(69, 28)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(817, 21)
        Me.txtNombre.TabIndex = 18
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail.Location = New System.Drawing.Point(7, 54)
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
        Me.lblNombre.Location = New System.Drawing.Point(7, 31)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblNombre.TabIndex = 18
        Me.lblNombre.Text = "Nombre: "
        '
        'panelCobros
        '
        Me.panelCobros.Controls.Add(Me.txtMonto)
        Me.panelCobros.Controls.Add(Me.lblMonto)
        Me.panelCobros.Controls.Add(Me.txtNoCuenta)
        Me.panelCobros.Controls.Add(Me.lblNoCuenta)
        Me.panelCobros.Controls.Add(Me.txtNoCheque)
        Me.panelCobros.Controls.Add(Me.lblNoCheque)
        Me.panelCobros.Controls.Add(Me.txtUltimos4Digitos)
        Me.panelCobros.Controls.Add(Me.lblUltimosDigitos)
        Me.panelCobros.Controls.Add(Me.DTPickerFecha)
        Me.panelCobros.Controls.Add(Me.lblFecha)
        Me.panelCobros.Controls.Add(Me.cbTipoBanco)
        Me.panelCobros.Controls.Add(Me.lblTIpoBanco)
        Me.panelCobros.Controls.Add(Me.cbBanco)
        Me.panelCobros.Controls.Add(Me.lblBanco)
        Me.panelCobros.Controls.Add(Me.lblPeso)
        Me.panelCobros.Controls.Add(Me.lblTotal)
        Me.panelCobros.Controls.Add(Me.Tree)
        Me.panelCobros.Controls.Add(Me.cbFormaPago)
        Me.panelCobros.Controls.Add(Me.lblFormadepago)
        Me.panelCobros.Controls.Add(Me.btnCobrar)
        Me.panelCobros.Controls.Add(Me.btnSalir)
        Me.panelCobros.Controls.Add(Me.lblPendientes)
        Me.panelCobros.Location = New System.Drawing.Point(5, 234)
        Me.panelCobros.Name = "panelCobros"
        Me.panelCobros.Size = New System.Drawing.Size(1300, 471)
        Me.panelCobros.TabIndex = 16
        Me.panelCobros.Visible = False
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(1046, 62)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(226, 21)
        Me.txtMonto.TabIndex = 35
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMonto.Location = New System.Drawing.Point(936, 65)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(98, 16)
        Me.lblMonto.TabIndex = 34
        Me.lblMonto.Text = "Monto a pagar:"
        '
        'txtNoCuenta
        '
        Me.txtNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCuenta.Location = New System.Drawing.Point(1046, 236)
        Me.txtNoCuenta.Name = "txtNoCuenta"
        Me.txtNoCuenta.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCuenta.TabIndex = 33
        Me.txtNoCuenta.Visible = False
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCuenta.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCuenta.Location = New System.Drawing.Point(937, 239)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(74, 16)
        Me.lblNoCuenta.TabIndex = 32
        Me.lblNoCuenta.Text = "No. Cuenta"
        Me.lblNoCuenta.Visible = False
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCheque.Location = New System.Drawing.Point(1046, 264)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCheque.TabIndex = 31
        Me.txtNoCheque.Visible = False
        '
        'lblNoCheque
        '
        Me.lblNoCheque.AutoSize = True
        Me.lblNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCheque.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCheque.Location = New System.Drawing.Point(936, 267)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(96, 16)
        Me.lblNoCheque.TabIndex = 30
        Me.lblNoCheque.Text = "No. de cheque"
        Me.lblNoCheque.Visible = False
        '
        'txtUltimos4Digitos
        '
        Me.txtUltimos4Digitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimos4Digitos.Location = New System.Drawing.Point(1046, 209)
        Me.txtUltimos4Digitos.MaxLength = 4
        Me.txtUltimos4Digitos.Name = "txtUltimos4Digitos"
        Me.txtUltimos4Digitos.Size = New System.Drawing.Size(226, 21)
        Me.txtUltimos4Digitos.TabIndex = 29
        Me.txtUltimos4Digitos.Visible = False
        '
        'lblUltimosDigitos
        '
        Me.lblUltimosDigitos.AutoSize = True
        Me.lblUltimosDigitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimosDigitos.ForeColor = System.Drawing.SystemColors.Control
        Me.lblUltimosDigitos.Location = New System.Drawing.Point(936, 212)
        Me.lblUltimosDigitos.Name = "lblUltimosDigitos"
        Me.lblUltimosDigitos.Size = New System.Drawing.Size(109, 16)
        Me.lblUltimosDigitos.TabIndex = 17
        Me.lblUltimosDigitos.Text = "Últimos 4 digitos:"
        Me.lblUltimosDigitos.Visible = False
        '
        'DTPickerFecha
        '
        Me.DTPickerFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPickerFecha.Location = New System.Drawing.Point(1046, 180)
        Me.DTPickerFecha.Name = "DTPickerFecha"
        Me.DTPickerFecha.Size = New System.Drawing.Size(89, 20)
        Me.DTPickerFecha.TabIndex = 16
        Me.DTPickerFecha.Visible = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFecha.Location = New System.Drawing.Point(937, 184)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(49, 16)
        Me.lblFecha.TabIndex = 15
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.Visible = False
        '
        'cbTipoBanco
        '
        Me.cbTipoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoBanco.FormattingEnabled = True
        Me.cbTipoBanco.Location = New System.Drawing.Point(1046, 153)
        Me.cbTipoBanco.Name = "cbTipoBanco"
        Me.cbTipoBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbTipoBanco.TabIndex = 14
        Me.cbTipoBanco.Visible = False
        '
        'lblTIpoBanco
        '
        Me.lblTIpoBanco.AutoSize = True
        Me.lblTIpoBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIpoBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTIpoBanco.Location = New System.Drawing.Point(936, 154)
        Me.lblTIpoBanco.Name = "lblTIpoBanco"
        Me.lblTIpoBanco.Size = New System.Drawing.Size(39, 16)
        Me.lblTIpoBanco.TabIndex = 13
        Me.lblTIpoBanco.Text = "TIpo:"
        Me.lblTIpoBanco.Visible = False
        '
        'cbBanco
        '
        Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(1046, 124)
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbBanco.TabIndex = 12
        Me.cbBanco.Visible = False
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBanco.Location = New System.Drawing.Point(936, 125)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(50, 16)
        Me.lblBanco.TabIndex = 11
        Me.lblBanco.Text = "Banco:"
        Me.lblBanco.Visible = False
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPeso.Location = New System.Drawing.Point(955, 333)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(26, 29)
        Me.lblPeso.TabIndex = 10
        Me.lblPeso.Text = "$"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Location = New System.Drawing.Point(975, 333)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 29)
        Me.lblTotal.TabIndex = 9
        '
        'Tree
        '
        Me.Tree.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Tree.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tree.ForeColor = System.Drawing.SystemColors.Control
        Me.Tree.Location = New System.Drawing.Point(7, 29)
        Me.Tree.Name = "Tree"
        TreeNode1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        TreeNode1.ForeColor = System.Drawing.SystemColors.Control
        TreeNode1.Name = "nodeCongresos"
        TreeNode1.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode1.SelectedImageIndex = -2
        TreeNode1.StateImageIndex = 2
        TreeNode1.Text = "Congresos"
        TreeNode2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        TreeNode2.ForeColor = System.Drawing.SystemColors.Control
        TreeNode2.Name = "nodePagosOpcionales"
        TreeNode2.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode2.SelectedImageIndex = -2
        TreeNode2.StateImageIndex = 2
        TreeNode2.Text = "Pagos Opcionales"
        TreeNode3.Name = "nodeInscripcionDip"
        TreeNode3.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode3.StateImageIndex = 2
        TreeNode3.Text = "Inscripción a Diplomados"
        TreeNode4.Name = "nodeColegiaturaDip"
        TreeNode4.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode4.StateImageIndex = 2
        TreeNode4.Text = "Colegiaturas de Diplomados"
        TreeNode5.Name = "nodePagoUnicoDip"
        TreeNode5.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode5.StateImageIndex = 2
        TreeNode5.Text = "Pago Unico de Diplomado"
        TreeNode6.Name = "nodeColegiaturasRec"
        TreeNode6.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode6.StateImageIndex = 2
        TreeNode6.Text = "Recargos de Diplomados"
        Me.Tree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4, TreeNode5, TreeNode6})
        Me.Tree.Size = New System.Drawing.Size(923, 415)
        Me.Tree.StateImageList = Me.ImageListTree
        Me.Tree.TabIndex = 8
        '
        'ImageListTree
        '
        Me.ImageListTree.ImageStream = CType(resources.GetObject("ImageListTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTree.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListTree.Images.SetKeyName(0, "unchecked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(1, "checked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(2, "folder_40px.png")
        '
        'cbFormaPago
        '
        Me.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormaPago.FormattingEnabled = True
        Me.cbFormaPago.Location = New System.Drawing.Point(1046, 28)
        Me.cbFormaPago.Name = "cbFormaPago"
        Me.cbFormaPago.Size = New System.Drawing.Size(226, 21)
        Me.cbFormaPago.TabIndex = 7
        '
        'lblFormadepago
        '
        Me.lblFormadepago.AutoSize = True
        Me.lblFormadepago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormadepago.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFormadepago.Location = New System.Drawing.Point(936, 29)
        Me.lblFormadepago.Name = "lblFormadepago"
        Me.lblFormadepago.Size = New System.Drawing.Size(104, 16)
        Me.lblFormadepago.TabIndex = 6
        Me.lblFormadepago.Text = "Forma de pago:"
        '
        'btnCobrar
        '
        Me.btnCobrar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.cash_register_40px
        Me.btnCobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCobrar.Location = New System.Drawing.Point(1121, 393)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(82, 51)
        Me.btnCobrar.TabIndex = 5
        Me.btnCobrar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(1209, 393)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(83, 51)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblPendientes
        '
        Me.lblPendientes.AutoSize = True
        Me.lblPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendientes.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPendientes.Location = New System.Drawing.Point(7, 10)
        Me.lblPendientes.Name = "lblPendientes"
        Me.lblPendientes.Size = New System.Drawing.Size(121, 16)
        Me.lblPendientes.TabIndex = 3
        Me.lblPendientes.Text = "Pagos pendientes:"
        '
        'CobrosEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1317, 710)
        Me.Controls.Add(Me.panelCobros)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.panelBusqueda)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CobrosEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CobrosEDC"
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.panelCobros.ResumeLayout(False)
        Me.panelCobros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents lblMatricula As Label
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents panelDatos As Panel
    Friend WithEvents lblTurno As Label
    Friend WithEvents lblCarrera As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtTurno As TextBox
    Friend WithEvents txtCarrera As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents panelCobros As Panel
    Friend WithEvents GridPagosPendientes As DataGridView
    Friend WithEvents lblPendientes As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnCobrar As Button
    Friend WithEvents lblFormadepago As Label
    Friend WithEvents cbFormaPago As ComboBox
    Friend WithEvents Tree As TreeView
    Friend WithEvents ImageListTree As ImageList
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblPeso As Label
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents lblMatriculaDato As Label
    Friend WithEvents txtMatriculaDato As TextBox
    Friend WithEvents lblRFC As Label
    Friend WithEvents txtRFC As TextBox
    Friend WithEvents cbBanco As ComboBox
    Friend WithEvents lblBanco As Label
    Friend WithEvents cbTipoBanco As ComboBox
    Friend WithEvents lblTIpoBanco As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents DTPickerFecha As DateTimePicker
    Friend WithEvents lblUltimosDigitos As Label
    Friend WithEvents txtUltimos4Digitos As TextBox
    Friend WithEvents txtNoCheque As TextBox
    Friend WithEvents lblNoCheque As Label
    Friend WithEvents txtNoCuenta As TextBox
    Friend WithEvents lblNoCuenta As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents lblMonto As Label
End Class
