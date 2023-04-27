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
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Congresos")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pagos Opcionales")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inscripción")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Colegiaturas")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pago Unico")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recargos")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CobrosEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.panelBusqueda = New System.Windows.Forms.Panel()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.lblCarreratxt = New System.Windows.Forms.Label()
        Me.lblTurnotxt = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.lblDirecciontxt = New System.Windows.Forms.Label()
        Me.lblCFDItxt = New System.Windows.Forms.Label()
        Me.lblCFDI = New System.Windows.Forms.Label()
        Me.lblRegFiscaltxt = New System.Windows.Forms.Label()
        Me.lblRegFiscal = New System.Windows.Forms.Label()
        Me.lblCPtxt = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblRFCtxt = New System.Windows.Forms.Label()
        Me.lblEmailtxt = New System.Windows.Forms.Label()
        Me.lblNombretxt = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblFoliotxt = New System.Windows.Forms.Label()
        Me.panelCobros = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelTipoPago = New System.Windows.Forms.Panel()
        Me.lblFormadepago = New System.Windows.Forms.Label()
        Me.txtNotaAplicada = New System.Windows.Forms.TextBox()
        Me.cbFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblNotaAplicada = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnBuscarNota = New System.Windows.Forms.Button()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.txtBancotext = New System.Windows.Forms.TextBox()
        Me.cbBanco = New System.Windows.Forms.ComboBox()
        Me.lblBancotext = New System.Windows.Forms.Label()
        Me.lblTIpoBanco = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.cbTipoBanco = New System.Windows.Forms.ComboBox()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtNoCuenta = New System.Windows.Forms.TextBox()
        Me.DTPickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblNoCuenta = New System.Windows.Forms.Label()
        Me.lblUltimosDigitos = New System.Windows.Forms.Label()
        Me.txtNoCheque = New System.Windows.Forms.TextBox()
        Me.txtUltimos4Digitos = New System.Windows.Forms.TextBox()
        Me.lblNoCheque = New System.Windows.Forms.Label()
        Me.Tree = New System.Windows.Forms.TreeView()
        Me.ImageListTree = New System.Windows.Forms.ImageList(Me.components)
        Me.lblPendientes = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCobrar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnVerRecordatorio = New System.Windows.Forms.Button()
        Me.btnRecordatorios = New System.Windows.Forms.Button()
        Me.panelBusqueda.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.panelCobros.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panelTipoPago.SuspendLayout()
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
        Me.panelBusqueda.Controls.Add(Me.btnVerRecordatorio)
        Me.panelBusqueda.Controls.Add(Me.btnRecordatorios)
        Me.panelBusqueda.Controls.Add(Me.cbExterno)
        Me.panelBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblCarreratxt)
        Me.panelBusqueda.Controls.Add(Me.lblTurnotxt)
        Me.panelBusqueda.Location = New System.Drawing.Point(5, 73)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(1300, 60)
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
        Me.lblMatricula.Size = New System.Drawing.Size(46, 16)
        Me.lblMatricula.TabIndex = 0
        Me.lblMatricula.Text = "Clave:"
        '
        'lblCarreratxt
        '
        Me.lblCarreratxt.AutoSize = True
        Me.lblCarreratxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarreratxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCarreratxt.Location = New System.Drawing.Point(1071, 15)
        Me.lblCarreratxt.Name = "lblCarreratxt"
        Me.lblCarreratxt.Size = New System.Drawing.Size(0, 20)
        Me.lblCarreratxt.TabIndex = 35
        Me.lblCarreratxt.Visible = False
        '
        'lblTurnotxt
        '
        Me.lblTurnotxt.AutoSize = True
        Me.lblTurnotxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnotxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurnotxt.Location = New System.Drawing.Point(971, 19)
        Me.lblTurnotxt.Name = "lblTurnotxt"
        Me.lblTurnotxt.Size = New System.Drawing.Size(0, 20)
        Me.lblTurnotxt.TabIndex = 36
        Me.lblTurnotxt.Visible = False
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurno.Location = New System.Drawing.Point(450, 8)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(54, 20)
        Me.lblTurno.TabIndex = 23
        Me.lblTurno.Text = "Turno:"
        Me.lblTurno.Visible = False
        '
        'lblCarrera
        '
        Me.lblCarrera.AutoSize = True
        Me.lblCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarrera.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCarrera.Location = New System.Drawing.Point(526, 8)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Size = New System.Drawing.Size(66, 20)
        Me.lblCarrera.TabIndex = 21
        Me.lblCarrera.Text = "Carrera:"
        Me.lblCarrera.Visible = False
        '
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.lblDireccion)
        Me.panelDatos.Controls.Add(Me.lblDirecciontxt)
        Me.panelDatos.Controls.Add(Me.lblCFDItxt)
        Me.panelDatos.Controls.Add(Me.lblCFDI)
        Me.panelDatos.Controls.Add(Me.lblRegFiscaltxt)
        Me.panelDatos.Controls.Add(Me.lblRegFiscal)
        Me.panelDatos.Controls.Add(Me.lblCPtxt)
        Me.panelDatos.Controls.Add(Me.lblCP)
        Me.panelDatos.Controls.Add(Me.lblRFCtxt)
        Me.panelDatos.Controls.Add(Me.lblEmailtxt)
        Me.panelDatos.Controls.Add(Me.lblNombretxt)
        Me.panelDatos.Controls.Add(Me.lblRFC)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Location = New System.Drawing.Point(5, 127)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(1300, 101)
        Me.panelDatos.TabIndex = 15
        Me.panelDatos.Visible = False
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDireccion.Location = New System.Drawing.Point(76, 31)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(0, 15)
        Me.lblDireccion.TabIndex = 99
        '
        'lblDirecciontxt
        '
        Me.lblDirecciontxt.AutoSize = True
        Me.lblDirecciontxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirecciontxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDirecciontxt.Location = New System.Drawing.Point(7, 31)
        Me.lblDirecciontxt.Name = "lblDirecciontxt"
        Me.lblDirecciontxt.Size = New System.Drawing.Size(62, 15)
        Me.lblDirecciontxt.TabIndex = 98
        Me.lblDirecciontxt.Text = "Direccion:"
        '
        'lblCFDItxt
        '
        Me.lblCFDItxt.AutoSize = True
        Me.lblCFDItxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDItxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDItxt.Location = New System.Drawing.Point(793, 54)
        Me.lblCFDItxt.Name = "lblCFDItxt"
        Me.lblCFDItxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCFDItxt.TabIndex = 97
        '
        'lblCFDI
        '
        Me.lblCFDI.AutoSize = True
        Me.lblCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDI.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDI.Location = New System.Drawing.Point(676, 54)
        Me.lblCFDI.Name = "lblCFDI"
        Me.lblCFDI.Size = New System.Drawing.Size(62, 15)
        Me.lblCFDI.TabIndex = 96
        Me.lblCFDI.Text = "Uso CFDI:"
        '
        'lblRegFiscaltxt
        '
        Me.lblRegFiscaltxt.AutoSize = True
        Me.lblRegFiscaltxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegFiscaltxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRegFiscaltxt.Location = New System.Drawing.Point(793, 31)
        Me.lblRegFiscaltxt.Name = "lblRegFiscaltxt"
        Me.lblRegFiscaltxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRegFiscaltxt.TabIndex = 40
        '
        'lblRegFiscal
        '
        Me.lblRegFiscal.AutoSize = True
        Me.lblRegFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegFiscal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRegFiscal.Location = New System.Drawing.Point(676, 31)
        Me.lblRegFiscal.Name = "lblRegFiscal"
        Me.lblRegFiscal.Size = New System.Drawing.Size(92, 15)
        Me.lblRegFiscal.TabIndex = 39
        Me.lblRegFiscal.Text = "Regimen fiscal:"
        '
        'lblCPtxt
        '
        Me.lblCPtxt.AutoSize = True
        Me.lblCPtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCPtxt.Location = New System.Drawing.Point(76, 77)
        Me.lblCPtxt.Name = "lblCPtxt"
        Me.lblCPtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCPtxt.TabIndex = 38
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCP.Location = New System.Drawing.Point(7, 77)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(26, 15)
        Me.lblCP.TabIndex = 37
        Me.lblCP.Text = "CP:"
        '
        'lblRFCtxt
        '
        Me.lblRFCtxt.AutoSize = True
        Me.lblRFCtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFCtxt.Location = New System.Drawing.Point(793, 9)
        Me.lblRFCtxt.Name = "lblRFCtxt"
        Me.lblRFCtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRFCtxt.TabIndex = 34
        '
        'lblEmailtxt
        '
        Me.lblEmailtxt.AutoSize = True
        Me.lblEmailtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmailtxt.Location = New System.Drawing.Point(76, 54)
        Me.lblEmailtxt.Name = "lblEmailtxt"
        Me.lblEmailtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblEmailtxt.TabIndex = 33
        '
        'lblNombretxt
        '
        Me.lblNombretxt.AutoSize = True
        Me.lblNombretxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombretxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombretxt.Location = New System.Drawing.Point(76, 9)
        Me.lblNombretxt.Name = "lblNombretxt"
        Me.lblNombretxt.Size = New System.Drawing.Size(0, 15)
        Me.lblNombretxt.TabIndex = 32
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFC.Location = New System.Drawing.Point(676, 9)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 15)
        Me.lblRFC.TabIndex = 27
        Me.lblRFC.Text = "RFC:"
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
        Me.lblNombre.Location = New System.Drawing.Point(6, 9)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblNombre.TabIndex = 18
        Me.lblNombre.Text = "Nombre: "
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFolio.Location = New System.Drawing.Point(971, 5)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(0, 25)
        Me.lblFolio.TabIndex = 30
        '
        'lblFoliotxt
        '
        Me.lblFoliotxt.AutoSize = True
        Me.lblFoliotxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFoliotxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFoliotxt.Location = New System.Drawing.Point(900, 5)
        Me.lblFoliotxt.Name = "lblFoliotxt"
        Me.lblFoliotxt.Size = New System.Drawing.Size(65, 25)
        Me.lblFoliotxt.TabIndex = 29
        Me.lblFoliotxt.Text = "Folio:"
        '
        'panelCobros
        '
        Me.panelCobros.Controls.Add(Me.Panel1)
        Me.panelCobros.Controls.Add(Me.panelTipoPago)
        Me.panelCobros.Controls.Add(Me.Tree)
        Me.panelCobros.Controls.Add(Me.lblPendientes)
        Me.panelCobros.Controls.Add(Me.lblTurno)
        Me.panelCobros.Controls.Add(Me.lblCarrera)
        Me.panelCobros.Controls.Add(Me.lblFoliotxt)
        Me.panelCobros.Controls.Add(Me.lblFolio)
        Me.panelCobros.Location = New System.Drawing.Point(5, 234)
        Me.panelCobros.Name = "panelCobros"
        Me.panelCobros.Size = New System.Drawing.Size(1300, 488)
        Me.panelCobros.TabIndex = 16
        Me.panelCobros.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnCobrar)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(901, 416)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 60)
        Me.Panel1.TabIndex = 43
        '
        'panelTipoPago
        '
        Me.panelTipoPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelTipoPago.Controls.Add(Me.lblFormadepago)
        Me.panelTipoPago.Controls.Add(Me.txtNotaAplicada)
        Me.panelTipoPago.Controls.Add(Me.cbFormaPago)
        Me.panelTipoPago.Controls.Add(Me.lblNotaAplicada)
        Me.panelTipoPago.Controls.Add(Me.lblTotal)
        Me.panelTipoPago.Controls.Add(Me.btnBuscarNota)
        Me.panelTipoPago.Controls.Add(Me.lblPeso)
        Me.panelTipoPago.Controls.Add(Me.lblBanco)
        Me.panelTipoPago.Controls.Add(Me.txtBancotext)
        Me.panelTipoPago.Controls.Add(Me.cbBanco)
        Me.panelTipoPago.Controls.Add(Me.lblBancotext)
        Me.panelTipoPago.Controls.Add(Me.lblTIpoBanco)
        Me.panelTipoPago.Controls.Add(Me.txtMonto)
        Me.panelTipoPago.Controls.Add(Me.cbTipoBanco)
        Me.panelTipoPago.Controls.Add(Me.lblMonto)
        Me.panelTipoPago.Controls.Add(Me.lblFecha)
        Me.panelTipoPago.Controls.Add(Me.txtNoCuenta)
        Me.panelTipoPago.Controls.Add(Me.DTPickerFecha)
        Me.panelTipoPago.Controls.Add(Me.lblNoCuenta)
        Me.panelTipoPago.Controls.Add(Me.lblUltimosDigitos)
        Me.panelTipoPago.Controls.Add(Me.txtNoCheque)
        Me.panelTipoPago.Controls.Add(Me.txtUltimos4Digitos)
        Me.panelTipoPago.Controls.Add(Me.lblNoCheque)
        Me.panelTipoPago.Enabled = False
        Me.panelTipoPago.Location = New System.Drawing.Point(901, 31)
        Me.panelTipoPago.Name = "panelTipoPago"
        Me.panelTipoPago.Size = New System.Drawing.Size(391, 382)
        Me.panelTipoPago.TabIndex = 42
        '
        'lblFormadepago
        '
        Me.lblFormadepago.AutoSize = True
        Me.lblFormadepago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormadepago.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFormadepago.Location = New System.Drawing.Point(12, 16)
        Me.lblFormadepago.Name = "lblFormadepago"
        Me.lblFormadepago.Size = New System.Drawing.Size(104, 16)
        Me.lblFormadepago.TabIndex = 6
        Me.lblFormadepago.Text = "Forma de pago:"
        '
        'txtNotaAplicada
        '
        Me.txtNotaAplicada.Enabled = False
        Me.txtNotaAplicada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotaAplicada.Location = New System.Drawing.Point(121, 80)
        Me.txtNotaAplicada.Name = "txtNotaAplicada"
        Me.txtNotaAplicada.Size = New System.Drawing.Size(226, 21)
        Me.txtNotaAplicada.TabIndex = 41
        Me.txtNotaAplicada.Visible = False
        '
        'cbFormaPago
        '
        Me.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormaPago.FormattingEnabled = True
        Me.cbFormaPago.Location = New System.Drawing.Point(122, 15)
        Me.cbFormaPago.Name = "cbFormaPago"
        Me.cbFormaPago.Size = New System.Drawing.Size(226, 21)
        Me.cbFormaPago.TabIndex = 7
        '
        'lblNotaAplicada
        '
        Me.lblNotaAplicada.AutoSize = True
        Me.lblNotaAplicada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotaAplicada.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNotaAplicada.Location = New System.Drawing.Point(12, 83)
        Me.lblNotaAplicada.Name = "lblNotaAplicada"
        Me.lblNotaAplicada.Size = New System.Drawing.Size(96, 16)
        Me.lblNotaAplicada.TabIndex = 40
        Me.lblNotaAplicada.Text = "Nota aplicada:"
        Me.lblNotaAplicada.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Location = New System.Drawing.Point(244, 347)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 29)
        Me.lblTotal.TabIndex = 9
        '
        'btnBuscarNota
        '
        Me.btnBuscarNota.Location = New System.Drawing.Point(121, 107)
        Me.btnBuscarNota.Name = "btnBuscarNota"
        Me.btnBuscarNota.Size = New System.Drawing.Size(123, 23)
        Me.btnBuscarNota.TabIndex = 39
        Me.btnBuscarNota.Text = "Buscar nota de crédito"
        Me.btnBuscarNota.UseVisualStyleBackColor = True
        Me.btnBuscarNota.Visible = False
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPeso.Location = New System.Drawing.Point(218, 347)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(26, 29)
        Me.lblPeso.TabIndex = 10
        Me.lblPeso.Text = "$"
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBanco.Location = New System.Drawing.Point(12, 144)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(50, 16)
        Me.lblBanco.TabIndex = 11
        Me.lblBanco.Text = "Banco:"
        Me.lblBanco.Visible = False
        '
        'txtBancotext
        '
        Me.txtBancotext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBancotext.Location = New System.Drawing.Point(121, 172)
        Me.txtBancotext.Name = "txtBancotext"
        Me.txtBancotext.Size = New System.Drawing.Size(226, 21)
        Me.txtBancotext.TabIndex = 37
        Me.txtBancotext.Visible = False
        '
        'cbBanco
        '
        Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(122, 143)
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbBanco.TabIndex = 12
        Me.cbBanco.Visible = False
        '
        'lblBancotext
        '
        Me.lblBancotext.AutoSize = True
        Me.lblBancotext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBancotext.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBancotext.Location = New System.Drawing.Point(12, 175)
        Me.lblBancotext.Name = "lblBancotext"
        Me.lblBancotext.Size = New System.Drawing.Size(50, 16)
        Me.lblBancotext.TabIndex = 36
        Me.lblBancotext.Text = "Banco:"
        Me.lblBancotext.Visible = False
        '
        'lblTIpoBanco
        '
        Me.lblTIpoBanco.AutoSize = True
        Me.lblTIpoBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIpoBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTIpoBanco.Location = New System.Drawing.Point(11, 174)
        Me.lblTIpoBanco.Name = "lblTIpoBanco"
        Me.lblTIpoBanco.Size = New System.Drawing.Size(39, 16)
        Me.lblTIpoBanco.TabIndex = 13
        Me.lblTIpoBanco.Text = "TIpo:"
        Me.lblTIpoBanco.Visible = False
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(122, 49)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(226, 21)
        Me.txtMonto.TabIndex = 35
        '
        'cbTipoBanco
        '
        Me.cbTipoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoBanco.FormattingEnabled = True
        Me.cbTipoBanco.Location = New System.Drawing.Point(121, 203)
        Me.cbTipoBanco.Name = "cbTipoBanco"
        Me.cbTipoBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbTipoBanco.TabIndex = 14
        Me.cbTipoBanco.Visible = False
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMonto.Location = New System.Drawing.Point(12, 52)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(98, 16)
        Me.lblMonto.TabIndex = 34
        Me.lblMonto.Text = "Monto a pagar:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFecha.Location = New System.Drawing.Point(12, 234)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(49, 16)
        Me.lblFecha.TabIndex = 15
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.Visible = False
        '
        'txtNoCuenta
        '
        Me.txtNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCuenta.Location = New System.Drawing.Point(121, 286)
        Me.txtNoCuenta.Name = "txtNoCuenta"
        Me.txtNoCuenta.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCuenta.TabIndex = 33
        Me.txtNoCuenta.Visible = False
        '
        'DTPickerFecha
        '
        Me.DTPickerFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPickerFecha.Location = New System.Drawing.Point(121, 230)
        Me.DTPickerFecha.Name = "DTPickerFecha"
        Me.DTPickerFecha.Size = New System.Drawing.Size(89, 20)
        Me.DTPickerFecha.TabIndex = 16
        Me.DTPickerFecha.Visible = False
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCuenta.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCuenta.Location = New System.Drawing.Point(12, 289)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(74, 16)
        Me.lblNoCuenta.TabIndex = 32
        Me.lblNoCuenta.Text = "No. Cuenta"
        Me.lblNoCuenta.Visible = False
        '
        'lblUltimosDigitos
        '
        Me.lblUltimosDigitos.AutoSize = True
        Me.lblUltimosDigitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimosDigitos.ForeColor = System.Drawing.SystemColors.Control
        Me.lblUltimosDigitos.Location = New System.Drawing.Point(11, 262)
        Me.lblUltimosDigitos.Name = "lblUltimosDigitos"
        Me.lblUltimosDigitos.Size = New System.Drawing.Size(109, 16)
        Me.lblUltimosDigitos.TabIndex = 17
        Me.lblUltimosDigitos.Text = "Últimos 4 digitos:"
        Me.lblUltimosDigitos.Visible = False
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCheque.Location = New System.Drawing.Point(121, 314)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCheque.TabIndex = 31
        Me.txtNoCheque.Visible = False
        '
        'txtUltimos4Digitos
        '
        Me.txtUltimos4Digitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimos4Digitos.Location = New System.Drawing.Point(121, 259)
        Me.txtUltimos4Digitos.MaxLength = 4
        Me.txtUltimos4Digitos.Name = "txtUltimos4Digitos"
        Me.txtUltimos4Digitos.Size = New System.Drawing.Size(226, 21)
        Me.txtUltimos4Digitos.TabIndex = 29
        Me.txtUltimos4Digitos.Visible = False
        '
        'lblNoCheque
        '
        Me.lblNoCheque.AutoSize = True
        Me.lblNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCheque.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCheque.Location = New System.Drawing.Point(11, 317)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(96, 16)
        Me.lblNoCheque.TabIndex = 30
        Me.lblNoCheque.Text = "No. de cheque"
        Me.lblNoCheque.Visible = False
        '
        'Tree
        '
        Me.Tree.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Tree.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tree.ForeColor = System.Drawing.SystemColors.Control
        Me.Tree.Location = New System.Drawing.Point(7, 31)
        Me.Tree.Name = "Tree"
        TreeNode7.BackColor = System.Drawing.SystemColors.ControlDarkDark
        TreeNode7.ForeColor = System.Drawing.SystemColors.Control
        TreeNode7.Name = "nodeCongresos"
        TreeNode7.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode7.SelectedImageIndex = -2
        TreeNode7.StateImageIndex = 2
        TreeNode7.Text = "Congresos"
        TreeNode8.BackColor = System.Drawing.SystemColors.ControlDarkDark
        TreeNode8.ForeColor = System.Drawing.SystemColors.Control
        TreeNode8.Name = "nodePagosOpcionales"
        TreeNode8.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode8.SelectedImageIndex = -2
        TreeNode8.StateImageIndex = 2
        TreeNode8.Text = "Pagos Opcionales"
        TreeNode9.Name = "nodeInscripcionDip"
        TreeNode9.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode9.StateImageIndex = 2
        TreeNode9.Text = "Inscripción"
        TreeNode10.Name = "nodeColegiaturaDip"
        TreeNode10.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode10.StateImageIndex = 2
        TreeNode10.Text = "Colegiaturas"
        TreeNode11.Name = "nodePagoUnicoDip"
        TreeNode11.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode11.StateImageIndex = 2
        TreeNode11.Text = "Pago Unico"
        TreeNode12.Name = "nodeColegiaturasRec"
        TreeNode12.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode12.StateImageIndex = 2
        TreeNode12.Text = "Recargos"
        Me.Tree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12})
        Me.Tree.Size = New System.Drawing.Size(879, 445)
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
        'lblPendientes
        '
        Me.lblPendientes.AutoSize = True
        Me.lblPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendientes.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPendientes.Location = New System.Drawing.Point(7, 12)
        Me.lblPendientes.Name = "lblPendientes"
        Me.lblPendientes.Size = New System.Drawing.Size(121, 16)
        Me.lblPendientes.TabIndex = 3
        Me.lblPendientes.Text = "Pagos pendientes:"
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
        'btnCobrar
        '
        Me.btnCobrar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.cash_register_40px
        Me.btnCobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCobrar.Location = New System.Drawing.Point(162, 3)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(82, 51)
        Me.btnCobrar.TabIndex = 5
        Me.btnCobrar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(261, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(83, 51)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(57, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(82, 51)
        Me.btnLimpiar.TabIndex = 38
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnVerRecordatorio
        '
        Me.btnVerRecordatorio.Image = Global.NEducacionContinuaUX.My.Resources.Resources.icons8_show_property_40
        Me.btnVerRecordatorio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnVerRecordatorio.Location = New System.Drawing.Point(999, 0)
        Me.btnVerRecordatorio.Name = "btnVerRecordatorio"
        Me.btnVerRecordatorio.Size = New System.Drawing.Size(88, 57)
        Me.btnVerRecordatorio.TabIndex = 75
        Me.btnVerRecordatorio.Text = "Ver recordatorio"
        Me.btnVerRecordatorio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVerRecordatorio.UseVisualStyleBackColor = True
        '
        'btnRecordatorios
        '
        Me.btnRecordatorios.Image = Global.NEducacionContinuaUX.My.Resources.Resources.icons8_note_40
        Me.btnRecordatorios.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRecordatorios.Location = New System.Drawing.Point(905, 0)
        Me.btnRecordatorios.Name = "btnRecordatorios"
        Me.btnRecordatorios.Size = New System.Drawing.Size(88, 57)
        Me.btnRecordatorios.TabIndex = 74
        Me.btnRecordatorios.Text = "Recordatorios"
        Me.btnRecordatorios.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRecordatorios.UseVisualStyleBackColor = True
        '
        'CobrosEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1317, 728)
        Me.Controls.Add(Me.panelCobros)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.panelBusqueda)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CobrosEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "   "
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.panelCobros.ResumeLayout(False)
        Me.panelCobros.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.panelTipoPago.ResumeLayout(False)
        Me.panelTipoPago.PerformLayout()
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
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents panelCobros As Panel
    Friend WithEvents GridPagosPendientes As DataGridView
    Friend WithEvents lblPendientes As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnCobrar As Button
    Friend WithEvents lblFormadepago As Label
    Friend WithEvents cbFormaPago As ComboBox
    Friend WithEvents ImageListTree As ImageList
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblPeso As Label
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents lblRFC As Label
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
    Friend WithEvents lblFoliotxt As Label
    Friend WithEvents lblFolio As Label
    Friend WithEvents txtBancotext As TextBox
    Friend WithEvents lblBancotext As Label
    Friend WithEvents lblRFCtxt As Label
    Friend WithEvents lblEmailtxt As Label
    Friend WithEvents lblNombretxt As Label
    Friend WithEvents lblCarreratxt As Label
    Friend WithEvents lblTurnotxt As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents txtNotaAplicada As TextBox
    Friend WithEvents lblNotaAplicada As Label
    Friend WithEvents btnBuscarNota As Button
    Friend WithEvents lblCPtxt As Label
    Friend WithEvents lblCP As Label
    Friend WithEvents lblRegFiscaltxt As Label
    Friend WithEvents lblRegFiscal As Label
    Friend WithEvents lblCFDItxt As Label
    Friend WithEvents lblCFDI As Label
    Friend WithEvents panelTipoPago As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblDirecciontxt As Label
    Friend WithEvents lblDireccion As Label
    Public WithEvents Tree As TreeView
    Friend WithEvents btnRecordatorios As Button
    Friend WithEvents btnVerRecordatorio As Button
End Class
