<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainCobrosDiferidosEDC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainCobrosDiferidosEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.panelBusqueda = New System.Windows.Forms.Panel()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.lblCFDItxt = New System.Windows.Forms.Label()
        Me.lblCFDI = New System.Windows.Forms.Label()
        Me.lblRegFiscaltxt = New System.Windows.Forms.Label()
        Me.lblRegFiscal = New System.Windows.Forms.Label()
        Me.lblCPtxt = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblT = New System.Windows.Forms.Label()
        Me.lblC = New System.Windows.Forms.Label()
        Me.lblRFCtxt = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblEmailtxt = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNombretxt = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.cbFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblFormadepago = New System.Windows.Forms.Label()
        Me.panelCobros = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.cbEDC = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.txtBusquedaMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula2 = New System.Windows.Forms.Label()
        Me.GridConceptos = New System.Windows.Forms.DataGridView()
        Me.columnID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnClavePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatriculaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCobrar = New System.Windows.Forms.Button()
        Me.ImageListTree = New System.Windows.Forms.ImageList(Me.components)
        Me.panelBusqueda.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.panelCobros.SuspendLayout()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-1, -2)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1241, 69)
        Me.lblNombreVentana.TabIndex = 13
        Me.lblNombreVentana.Text = "Cobros múltiples"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBusqueda
        '
        Me.panelBusqueda.Controls.Add(Me.cbExterno)
        Me.panelBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Location = New System.Drawing.Point(5, 70)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(1225, 41)
        Me.panelBusqueda.TabIndex = 15
        '
        'cbExterno
        '
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(432, 14)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(586, 21)
        Me.cbExterno.TabIndex = 75
        '
        'lblBusquedaNombre
        '
        Me.lblBusquedaNombre.AutoSize = True
        Me.lblBusquedaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBusquedaNombre.Location = New System.Drawing.Point(373, 16)
        Me.lblBusquedaNombre.Name = "lblBusquedaNombre"
        Me.lblBusquedaNombre.Size = New System.Drawing.Size(63, 16)
        Me.lblBusquedaNombre.TabIndex = 74
        Me.lblBusquedaNombre.Text = "Nombre: "
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.Location = New System.Drawing.Point(312, 7)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(41, 34)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtMatricula
        '
        Me.txtMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula.Location = New System.Drawing.Point(136, 13)
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
        Me.lblMatricula.Size = New System.Drawing.Size(104, 16)
        Me.lblMatricula.TabIndex = 0
        Me.lblMatricula.Text = "Clave a facturar:"
        '
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.lblCFDItxt)
        Me.panelDatos.Controls.Add(Me.lblCFDI)
        Me.panelDatos.Controls.Add(Me.lblRegFiscaltxt)
        Me.panelDatos.Controls.Add(Me.lblRegFiscal)
        Me.panelDatos.Controls.Add(Me.lblCPtxt)
        Me.panelDatos.Controls.Add(Me.lblCP)
        Me.panelDatos.Controls.Add(Me.lblT)
        Me.panelDatos.Controls.Add(Me.lblC)
        Me.panelDatos.Controls.Add(Me.lblRFCtxt)
        Me.panelDatos.Controls.Add(Me.lblRFC)
        Me.panelDatos.Controls.Add(Me.lblEmailtxt)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.lblNombretxt)
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Location = New System.Drawing.Point(5, 117)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(1225, 60)
        Me.panelDatos.TabIndex = 16
        Me.panelDatos.Visible = False
        '
        'lblCFDItxt
        '
        Me.lblCFDItxt.AutoSize = True
        Me.lblCFDItxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDItxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDItxt.Location = New System.Drawing.Point(455, 36)
        Me.lblCFDItxt.Name = "lblCFDItxt"
        Me.lblCFDItxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCFDItxt.TabIndex = 97
        '
        'lblCFDI
        '
        Me.lblCFDI.AutoSize = True
        Me.lblCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDI.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDI.Location = New System.Drawing.Point(393, 36)
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
        Me.lblRegFiscaltxt.Location = New System.Drawing.Point(907, 10)
        Me.lblRegFiscaltxt.Name = "lblRegFiscaltxt"
        Me.lblRegFiscaltxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRegFiscaltxt.TabIndex = 93
        '
        'lblRegFiscal
        '
        Me.lblRegFiscal.AutoSize = True
        Me.lblRegFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegFiscal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRegFiscal.Location = New System.Drawing.Point(790, 10)
        Me.lblRegFiscal.Name = "lblRegFiscal"
        Me.lblRegFiscal.Size = New System.Drawing.Size(92, 15)
        Me.lblRegFiscal.TabIndex = 92
        Me.lblRegFiscal.Text = "Regimen fiscal:"
        '
        'lblCPtxt
        '
        Me.lblCPtxt.AutoSize = True
        Me.lblCPtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCPtxt.Location = New System.Drawing.Point(691, 10)
        Me.lblCPtxt.Name = "lblCPtxt"
        Me.lblCPtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCPtxt.TabIndex = 91
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCP.Location = New System.Drawing.Point(657, 10)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(26, 15)
        Me.lblCP.TabIndex = 90
        Me.lblCP.Text = "CP:"
        '
        'lblT
        '
        Me.lblT.AutoSize = True
        Me.lblT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT.ForeColor = System.Drawing.SystemColors.Control
        Me.lblT.Location = New System.Drawing.Point(620, 31)
        Me.lblT.Name = "lblT"
        Me.lblT.Size = New System.Drawing.Size(0, 15)
        Me.lblT.TabIndex = 40
        Me.lblT.Visible = False
        '
        'lblC
        '
        Me.lblC.AutoSize = True
        Me.lblC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblC.ForeColor = System.Drawing.SystemColors.Control
        Me.lblC.Location = New System.Drawing.Point(612, 23)
        Me.lblC.Name = "lblC"
        Me.lblC.Size = New System.Drawing.Size(0, 15)
        Me.lblC.TabIndex = 39
        Me.lblC.Visible = False
        '
        'lblRFCtxt
        '
        Me.lblRFCtxt.AutoSize = True
        Me.lblRFCtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFCtxt.Location = New System.Drawing.Point(430, 10)
        Me.lblRFCtxt.Name = "lblRFCtxt"
        Me.lblRFCtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRFCtxt.TabIndex = 38
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFC.Location = New System.Drawing.Point(393, 10)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 15)
        Me.lblRFC.TabIndex = 37
        Me.lblRFC.Text = "RFC:"
        '
        'lblEmailtxt
        '
        Me.lblEmailtxt.AutoSize = True
        Me.lblEmailtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmailtxt.Location = New System.Drawing.Point(68, 36)
        Me.lblEmailtxt.Name = "lblEmailtxt"
        Me.lblEmailtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblEmailtxt.TabIndex = 36
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail.Location = New System.Drawing.Point(9, 36)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail.TabIndex = 35
        Me.lblEmail.Text = "Email:"
        '
        'lblNombretxt
        '
        Me.lblNombretxt.AutoSize = True
        Me.lblNombretxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombretxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombretxt.Location = New System.Drawing.Point(68, 10)
        Me.lblNombretxt.Name = "lblNombretxt"
        Me.lblNombretxt.Size = New System.Drawing.Size(0, 15)
        Me.lblNombretxt.TabIndex = 34
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre.Location = New System.Drawing.Point(9, 10)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblNombre.TabIndex = 33
        Me.lblNombre.Text = "Nombre: "
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Location = New System.Drawing.Point(1003, 383)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 29)
        Me.lblTotal.TabIndex = 21
        '
        'cbFormaPago
        '
        Me.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormaPago.FormattingEnabled = True
        Me.cbFormaPago.Location = New System.Drawing.Point(982, 88)
        Me.cbFormaPago.Name = "cbFormaPago"
        Me.cbFormaPago.Size = New System.Drawing.Size(235, 21)
        Me.cbFormaPago.TabIndex = 20
        '
        'lblFormadepago
        '
        Me.lblFormadepago.AutoSize = True
        Me.lblFormadepago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormadepago.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFormadepago.Location = New System.Drawing.Point(876, 89)
        Me.lblFormadepago.Name = "lblFormadepago"
        Me.lblFormadepago.Size = New System.Drawing.Size(104, 16)
        Me.lblFormadepago.TabIndex = 19
        Me.lblFormadepago.Text = "Forma de pago:"
        '
        'panelCobros
        '
        Me.panelCobros.Controls.Add(Me.btnLimpiar)
        Me.panelCobros.Controls.Add(Me.cbEDC)
        Me.panelCobros.Controls.Add(Me.Label3)
        Me.panelCobros.Controls.Add(Me.txtMonto)
        Me.panelCobros.Controls.Add(Me.lblTotal)
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
        Me.panelCobros.Controls.Add(Me.btnBorrar)
        Me.panelCobros.Controls.Add(Me.txtBusquedaMatricula)
        Me.panelCobros.Controls.Add(Me.lblMatricula2)
        Me.panelCobros.Controls.Add(Me.GridConceptos)
        Me.panelCobros.Controls.Add(Me.lblPeso)
        Me.panelCobros.Controls.Add(Me.Label2)
        Me.panelCobros.Controls.Add(Me.btnAgregar)
        Me.panelCobros.Controls.Add(Me.Label1)
        Me.panelCobros.Controls.Add(Me.lblFormadepago)
        Me.panelCobros.Controls.Add(Me.btnSalir)
        Me.panelCobros.Controls.Add(Me.btnCobrar)
        Me.panelCobros.Controls.Add(Me.cbFormaPago)
        Me.panelCobros.Location = New System.Drawing.Point(5, 183)
        Me.panelCobros.Name = "panelCobros"
        Me.panelCobros.Size = New System.Drawing.Size(1225, 489)
        Me.panelCobros.TabIndex = 23
        Me.panelCobros.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(921, 429)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(76, 51)
        Me.btnLimpiar.TabIndex = 76
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'cbEDC
        '
        Me.cbEDC.FormattingEnabled = True
        Me.cbEDC.Location = New System.Drawing.Point(349, 39)
        Me.cbEDC.Name = "cbEDC"
        Me.cbEDC.Size = New System.Drawing.Size(450, 21)
        Me.cbEDC.TabIndex = 75
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(290, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Nombre: "
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(982, 121)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(226, 21)
        Me.txtMonto.TabIndex = 49
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMonto.Location = New System.Drawing.Point(876, 124)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(98, 16)
        Me.lblMonto.TabIndex = 48
        Me.lblMonto.Text = "Monto a pagar:"
        '
        'txtNoCuenta
        '
        Me.txtNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCuenta.Location = New System.Drawing.Point(982, 295)
        Me.txtNoCuenta.Name = "txtNoCuenta"
        Me.txtNoCuenta.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCuenta.TabIndex = 47
        Me.txtNoCuenta.Visible = False
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCuenta.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCuenta.Location = New System.Drawing.Point(877, 298)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(74, 16)
        Me.lblNoCuenta.TabIndex = 46
        Me.lblNoCuenta.Text = "No. Cuenta"
        Me.lblNoCuenta.Visible = False
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCheque.Location = New System.Drawing.Point(982, 323)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCheque.TabIndex = 45
        Me.txtNoCheque.Visible = False
        '
        'lblNoCheque
        '
        Me.lblNoCheque.AutoSize = True
        Me.lblNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCheque.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCheque.Location = New System.Drawing.Point(876, 326)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(96, 16)
        Me.lblNoCheque.TabIndex = 44
        Me.lblNoCheque.Text = "No. de cheque"
        Me.lblNoCheque.Visible = False
        '
        'txtUltimos4Digitos
        '
        Me.txtUltimos4Digitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimos4Digitos.Location = New System.Drawing.Point(982, 268)
        Me.txtUltimos4Digitos.MaxLength = 4
        Me.txtUltimos4Digitos.Name = "txtUltimos4Digitos"
        Me.txtUltimos4Digitos.Size = New System.Drawing.Size(226, 21)
        Me.txtUltimos4Digitos.TabIndex = 43
        Me.txtUltimos4Digitos.Visible = False
        '
        'lblUltimosDigitos
        '
        Me.lblUltimosDigitos.AutoSize = True
        Me.lblUltimosDigitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimosDigitos.ForeColor = System.Drawing.SystemColors.Control
        Me.lblUltimosDigitos.Location = New System.Drawing.Point(876, 271)
        Me.lblUltimosDigitos.Name = "lblUltimosDigitos"
        Me.lblUltimosDigitos.Size = New System.Drawing.Size(109, 16)
        Me.lblUltimosDigitos.TabIndex = 42
        Me.lblUltimosDigitos.Text = "Últimos 4 digitos:"
        Me.lblUltimosDigitos.Visible = False
        '
        'DTPickerFecha
        '
        Me.DTPickerFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPickerFecha.Location = New System.Drawing.Point(982, 239)
        Me.DTPickerFecha.Name = "DTPickerFecha"
        Me.DTPickerFecha.Size = New System.Drawing.Size(89, 20)
        Me.DTPickerFecha.TabIndex = 41
        Me.DTPickerFecha.Visible = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFecha.Location = New System.Drawing.Point(877, 243)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(49, 16)
        Me.lblFecha.TabIndex = 40
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.Visible = False
        '
        'cbTipoBanco
        '
        Me.cbTipoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoBanco.FormattingEnabled = True
        Me.cbTipoBanco.Location = New System.Drawing.Point(982, 212)
        Me.cbTipoBanco.Name = "cbTipoBanco"
        Me.cbTipoBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbTipoBanco.TabIndex = 39
        Me.cbTipoBanco.Visible = False
        '
        'lblTIpoBanco
        '
        Me.lblTIpoBanco.AutoSize = True
        Me.lblTIpoBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIpoBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTIpoBanco.Location = New System.Drawing.Point(876, 213)
        Me.lblTIpoBanco.Name = "lblTIpoBanco"
        Me.lblTIpoBanco.Size = New System.Drawing.Size(39, 16)
        Me.lblTIpoBanco.TabIndex = 38
        Me.lblTIpoBanco.Text = "TIpo:"
        Me.lblTIpoBanco.Visible = False
        '
        'cbBanco
        '
        Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(982, 183)
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbBanco.TabIndex = 37
        Me.cbBanco.Visible = False
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBanco.Location = New System.Drawing.Point(876, 184)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(50, 16)
        Me.lblBanco.TabIndex = 36
        Me.lblBanco.Text = "Banco:"
        Me.lblBanco.Visible = False
        '
        'btnBorrar
        '
        Me.btnBorrar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.trash_can_30px
        Me.btnBorrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Location = New System.Drawing.Point(802, 230)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(52, 41)
        Me.btnBorrar.TabIndex = 29
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'txtBusquedaMatricula
        '
        Me.txtBusquedaMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusquedaMatricula.Location = New System.Drawing.Point(73, 38)
        Me.txtBusquedaMatricula.Name = "txtBusquedaMatricula"
        Me.txtBusquedaMatricula.Size = New System.Drawing.Size(133, 22)
        Me.txtBusquedaMatricula.TabIndex = 3
        '
        'lblMatricula2
        '
        Me.lblMatricula2.AutoSize = True
        Me.lblMatricula2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula2.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula2.Location = New System.Drawing.Point(9, 41)
        Me.lblMatricula2.Name = "lblMatricula2"
        Me.lblMatricula2.Size = New System.Drawing.Size(46, 16)
        Me.lblMatricula2.TabIndex = 3
        Me.lblMatricula2.Text = "Clave:"
        '
        'GridConceptos
        '
        Me.GridConceptos.AllowUserToAddRows = False
        Me.GridConceptos.AllowUserToDeleteRows = False
        Me.GridConceptos.AllowUserToResizeColumns = False
        Me.GridConceptos.AllowUserToResizeRows = False
        Me.GridConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridConceptos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnID, Me.columnClavePago, Me.MatriculaColumn, Me.DescripcionColumn, Me.MontoColumn})
        Me.GridConceptos.Location = New System.Drawing.Point(10, 78)
        Me.GridConceptos.Name = "GridConceptos"
        Me.GridConceptos.ReadOnly = True
        Me.GridConceptos.Size = New System.Drawing.Size(789, 401)
        Me.GridConceptos.TabIndex = 28
        '
        'columnID
        '
        Me.columnID.HeaderText = "ID"
        Me.columnID.Name = "columnID"
        Me.columnID.ReadOnly = True
        Me.columnID.Visible = False
        '
        'columnClavePago
        '
        Me.columnClavePago.HeaderText = "ClavePago"
        Me.columnClavePago.Name = "columnClavePago"
        Me.columnClavePago.ReadOnly = True
        Me.columnClavePago.Visible = False
        '
        'MatriculaColumn
        '
        Me.MatriculaColumn.FillWeight = 60.9137!
        Me.MatriculaColumn.HeaderText = "Clave cliente"
        Me.MatriculaColumn.Name = "MatriculaColumn"
        Me.MatriculaColumn.ReadOnly = True
        '
        'DescripcionColumn
        '
        Me.DescripcionColumn.FillWeight = 172.6754!
        Me.DescripcionColumn.HeaderText = "Descripcion"
        Me.DescripcionColumn.Name = "DescripcionColumn"
        Me.DescripcionColumn.ReadOnly = True
        '
        'MontoColumn
        '
        Me.MontoColumn.FillWeight = 66.41091!
        Me.MontoColumn.HeaderText = "Monto"
        Me.MontoColumn.Name = "MontoColumn"
        Me.MontoColumn.ReadOnly = True
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPeso.Location = New System.Drawing.Point(971, 383)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(26, 29)
        Me.lblPeso.TabIndex = 27
        Me.lblPeso.Text = "$"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(991, 383)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 29)
        Me.Label2.TabIndex = 26
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.Add_30px
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(212, 26)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(77, 41)
        Me.btnAgregar.TabIndex = 25
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(7, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Agregar pago:"
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(1129, 429)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(76, 51)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCobrar
        '
        Me.btnCobrar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.cash_register_40px1
        Me.btnCobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCobrar.Location = New System.Drawing.Point(1026, 430)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(76, 50)
        Me.btnCobrar.TabIndex = 18
        Me.btnCobrar.UseVisualStyleBackColor = True
        '
        'ImageListTree
        '
        Me.ImageListTree.ImageStream = CType(resources.GetObject("ImageListTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTree.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListTree.Images.SetKeyName(0, "unchecked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(1, "checked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(2, "folder_40px.png")
        '
        'MainCobrosDiferidosEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1237, 674)
        Me.Controls.Add(Me.panelCobros)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.panelBusqueda)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainCobrosDiferidosEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainCobrosDiferidosEDC"
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.panelCobros.ResumeLayout(False)
        Me.panelCobros.PerformLayout()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents lblMatricula As Label
    Friend WithEvents panelDatos As Panel
    Friend WithEvents lblTotal As Label
    Friend WithEvents cbFormaPago As ComboBox
    Friend WithEvents lblFormadepago As Label
    Friend WithEvents btnCobrar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents panelCobros As Panel
    Friend WithEvents ImageListTree As ImageList
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents lblPeso As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GridConceptos As DataGridView
    Friend WithEvents txtBusquedaMatricula As TextBox
    Friend WithEvents lblMatricula2 As Label
    Friend WithEvents columnID As DataGridViewTextBoxColumn
    Friend WithEvents columnClavePago As DataGridViewTextBoxColumn
    Friend WithEvents MatriculaColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionColumn As DataGridViewTextBoxColumn
    Friend WithEvents MontoColumn As DataGridViewTextBoxColumn
    Friend WithEvents btnBorrar As Button
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents lblMonto As Label
    Friend WithEvents txtNoCuenta As TextBox
    Friend WithEvents lblNoCuenta As Label
    Friend WithEvents txtNoCheque As TextBox
    Friend WithEvents lblNoCheque As Label
    Friend WithEvents txtUltimos4Digitos As TextBox
    Friend WithEvents lblUltimosDigitos As Label
    Friend WithEvents DTPickerFecha As DateTimePicker
    Friend WithEvents lblFecha As Label
    Friend WithEvents cbTipoBanco As ComboBox
    Friend WithEvents lblTIpoBanco As Label
    Friend WithEvents cbBanco As ComboBox
    Friend WithEvents lblBanco As Label
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents cbEDC As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblNombretxt As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblEmailtxt As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblRFCtxt As Label
    Friend WithEvents lblRFC As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents lblT As Label
    Friend WithEvents lblC As Label
    Friend WithEvents lblRegFiscaltxt As Label
    Friend WithEvents lblRegFiscal As Label
    Friend WithEvents lblCPtxt As Label
    Friend WithEvents lblCP As Label
    Friend WithEvents lblCFDItxt As Label
    Friend WithEvents lblCFDI As Label
End Class
