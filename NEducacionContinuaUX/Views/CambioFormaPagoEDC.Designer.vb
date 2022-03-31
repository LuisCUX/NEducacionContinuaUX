<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambioFormaPagoEDC
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cbFactura = New System.Windows.Forms.ComboBox()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.lblFacturaCB = New System.Windows.Forms.Label()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.btnBuscarMatricula = New System.Windows.Forms.Button()
        Me.lblFolioBuscar = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.btnBuscarFolio = New System.Windows.Forms.Button()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.txtBancotext = New System.Windows.Forms.TextBox()
        Me.btnGuardarCondonaciones = New System.Windows.Forms.Button()
        Me.lblBancotext = New System.Windows.Forms.Label()
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
        Me.cbFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblFormadepago = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(1, 1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(782, 69)
        Me.lblNombreVentana.TabIndex = 13
        Me.lblNombreVentana.Text = "Cambio de forma de pago"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(14, 75)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbFactura)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbExterno)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMatricula)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFacturaCB)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblBusquedaNombre)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMatricula)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscarMatricula)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblFolioBuscar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtFolio)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnBuscarFolio)
        Me.SplitContainer1.Size = New System.Drawing.Size(758, 154)
        Me.SplitContainer1.SplitterDistance = 513
        Me.SplitContainer1.TabIndex = 17
        '
        'cbFactura
        '
        Me.cbFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFactura.FormattingEnabled = True
        Me.cbFactura.Location = New System.Drawing.Point(9, 110)
        Me.cbFactura.Name = "cbFactura"
        Me.cbFactura.Size = New System.Drawing.Size(489, 21)
        Me.cbFactura.TabIndex = 77
        '
        'cbExterno
        '
        Me.cbExterno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbExterno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(8, 67)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(490, 21)
        Me.cbExterno.TabIndex = 75
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula.Location = New System.Drawing.Point(5, 16)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(49, 18)
        Me.lblMatricula.TabIndex = 15
        Me.lblMatricula.Text = "Clave:"
        '
        'lblFacturaCB
        '
        Me.lblFacturaCB.AutoSize = True
        Me.lblFacturaCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturaCB.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFacturaCB.Location = New System.Drawing.Point(6, 91)
        Me.lblFacturaCB.Name = "lblFacturaCB"
        Me.lblFacturaCB.Size = New System.Drawing.Size(56, 16)
        Me.lblFacturaCB.TabIndex = 76
        Me.lblFacturaCB.Text = "Factura:"
        '
        'lblBusquedaNombre
        '
        Me.lblBusquedaNombre.AutoSize = True
        Me.lblBusquedaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBusquedaNombre.Location = New System.Drawing.Point(5, 48)
        Me.lblBusquedaNombre.Name = "lblBusquedaNombre"
        Me.lblBusquedaNombre.Size = New System.Drawing.Size(63, 16)
        Me.lblBusquedaNombre.TabIndex = 74
        Me.lblBusquedaNombre.Text = "Nombre: "
        '
        'txtMatricula
        '
        Me.txtMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula.Location = New System.Drawing.Point(77, 15)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(110, 22)
        Me.txtMatricula.TabIndex = 16
        '
        'btnBuscarMatricula
        '
        Me.btnBuscarMatricula.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscarMatricula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscarMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarMatricula.Location = New System.Drawing.Point(194, 9)
        Me.btnBuscarMatricula.Name = "btnBuscarMatricula"
        Me.btnBuscarMatricula.Size = New System.Drawing.Size(41, 34)
        Me.btnBuscarMatricula.TabIndex = 17
        Me.btnBuscarMatricula.UseVisualStyleBackColor = True
        '
        'lblFolioBuscar
        '
        Me.lblFolioBuscar.AutoSize = True
        Me.lblFolioBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioBuscar.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFolioBuscar.Location = New System.Drawing.Point(13, 16)
        Me.lblFolioBuscar.Name = "lblFolioBuscar"
        Me.lblFolioBuscar.Size = New System.Drawing.Size(45, 18)
        Me.lblFolioBuscar.TabIndex = 18
        Me.lblFolioBuscar.Text = "Folio:"
        '
        'txtFolio
        '
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.Location = New System.Drawing.Point(64, 15)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(110, 22)
        Me.txtFolio.TabIndex = 19
        '
        'btnBuscarFolio
        '
        Me.btnBuscarFolio.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscarFolio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscarFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarFolio.Location = New System.Drawing.Point(180, 9)
        Me.btnBuscarFolio.Name = "btnBuscarFolio"
        Me.btnBuscarFolio.Size = New System.Drawing.Size(41, 34)
        Me.btnBuscarFolio.TabIndex = 20
        Me.btnBuscarFolio.UseVisualStyleBackColor = True
        '
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.Button2)
        Me.panelDatos.Controls.Add(Me.Label11)
        Me.panelDatos.Controls.Add(Me.btnLimpiar)
        Me.panelDatos.Controls.Add(Me.txtBancotext)
        Me.panelDatos.Controls.Add(Me.btnGuardarCondonaciones)
        Me.panelDatos.Controls.Add(Me.lblBancotext)
        Me.panelDatos.Controls.Add(Me.txtMonto)
        Me.panelDatos.Controls.Add(Me.lblMonto)
        Me.panelDatos.Controls.Add(Me.txtNoCuenta)
        Me.panelDatos.Controls.Add(Me.lblNoCuenta)
        Me.panelDatos.Controls.Add(Me.txtNoCheque)
        Me.panelDatos.Controls.Add(Me.lblNoCheque)
        Me.panelDatos.Controls.Add(Me.txtUltimos4Digitos)
        Me.panelDatos.Controls.Add(Me.lblUltimosDigitos)
        Me.panelDatos.Controls.Add(Me.DTPickerFecha)
        Me.panelDatos.Controls.Add(Me.lblFecha)
        Me.panelDatos.Controls.Add(Me.cbTipoBanco)
        Me.panelDatos.Controls.Add(Me.lblTIpoBanco)
        Me.panelDatos.Controls.Add(Me.cbBanco)
        Me.panelDatos.Controls.Add(Me.lblBanco)
        Me.panelDatos.Controls.Add(Me.cbFormaPago)
        Me.panelDatos.Controls.Add(Me.lblFormadepago)
        Me.panelDatos.Location = New System.Drawing.Point(14, 235)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(758, 454)
        Me.panelDatos.TabIndex = 18
        Me.panelDatos.Visible = False
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(486, 389)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 53)
        Me.Button2.TabIndex = 43
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(308, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 20)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Nuevos datos"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(205, 389)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(72, 53)
        Me.btnLimpiar.TabIndex = 42
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'txtBancotext
        '
        Me.txtBancotext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBancotext.Location = New System.Drawing.Point(311, 157)
        Me.txtBancotext.Name = "txtBancotext"
        Me.txtBancotext.Size = New System.Drawing.Size(226, 21)
        Me.txtBancotext.TabIndex = 74
        Me.txtBancotext.Visible = False
        '
        'btnGuardarCondonaciones
        '
        Me.btnGuardarCondonaciones.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardarCondonaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarCondonaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarCondonaciones.Location = New System.Drawing.Point(354, 389)
        Me.btnGuardarCondonaciones.Name = "btnGuardarCondonaciones"
        Me.btnGuardarCondonaciones.Size = New System.Drawing.Size(72, 53)
        Me.btnGuardarCondonaciones.TabIndex = 41
        Me.btnGuardarCondonaciones.UseVisualStyleBackColor = True
        '
        'lblBancotext
        '
        Me.lblBancotext.AutoSize = True
        Me.lblBancotext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBancotext.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBancotext.Location = New System.Drawing.Point(202, 160)
        Me.lblBancotext.Name = "lblBancotext"
        Me.lblBancotext.Size = New System.Drawing.Size(50, 16)
        Me.lblBancotext.TabIndex = 73
        Me.lblBancotext.Text = "Banco:"
        Me.lblBancotext.Visible = False
        '
        'txtMonto
        '
        Me.txtMonto.Enabled = False
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(311, 97)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(226, 21)
        Me.txtMonto.TabIndex = 72
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMonto.Location = New System.Drawing.Point(201, 100)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(98, 16)
        Me.lblMonto.TabIndex = 71
        Me.lblMonto.Text = "Monto a pagar:"
        '
        'txtNoCuenta
        '
        Me.txtNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCuenta.Location = New System.Drawing.Point(311, 271)
        Me.txtNoCuenta.Name = "txtNoCuenta"
        Me.txtNoCuenta.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCuenta.TabIndex = 70
        Me.txtNoCuenta.Visible = False
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCuenta.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCuenta.Location = New System.Drawing.Point(202, 274)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(74, 16)
        Me.lblNoCuenta.TabIndex = 69
        Me.lblNoCuenta.Text = "No. Cuenta"
        Me.lblNoCuenta.Visible = False
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCheque.Location = New System.Drawing.Point(311, 299)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCheque.TabIndex = 68
        Me.txtNoCheque.Visible = False
        '
        'lblNoCheque
        '
        Me.lblNoCheque.AutoSize = True
        Me.lblNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCheque.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCheque.Location = New System.Drawing.Point(201, 302)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(96, 16)
        Me.lblNoCheque.TabIndex = 67
        Me.lblNoCheque.Text = "No. de cheque"
        Me.lblNoCheque.Visible = False
        '
        'txtUltimos4Digitos
        '
        Me.txtUltimos4Digitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimos4Digitos.Location = New System.Drawing.Point(311, 244)
        Me.txtUltimos4Digitos.MaxLength = 4
        Me.txtUltimos4Digitos.Name = "txtUltimos4Digitos"
        Me.txtUltimos4Digitos.Size = New System.Drawing.Size(226, 21)
        Me.txtUltimos4Digitos.TabIndex = 66
        Me.txtUltimos4Digitos.Visible = False
        '
        'lblUltimosDigitos
        '
        Me.lblUltimosDigitos.AutoSize = True
        Me.lblUltimosDigitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimosDigitos.ForeColor = System.Drawing.SystemColors.Control
        Me.lblUltimosDigitos.Location = New System.Drawing.Point(201, 247)
        Me.lblUltimosDigitos.Name = "lblUltimosDigitos"
        Me.lblUltimosDigitos.Size = New System.Drawing.Size(109, 16)
        Me.lblUltimosDigitos.TabIndex = 65
        Me.lblUltimosDigitos.Text = "Últimos 4 digitos:"
        Me.lblUltimosDigitos.Visible = False
        '
        'DTPickerFecha
        '
        Me.DTPickerFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPickerFecha.Location = New System.Drawing.Point(311, 215)
        Me.DTPickerFecha.Name = "DTPickerFecha"
        Me.DTPickerFecha.Size = New System.Drawing.Size(89, 20)
        Me.DTPickerFecha.TabIndex = 64
        Me.DTPickerFecha.Visible = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFecha.Location = New System.Drawing.Point(202, 219)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(49, 16)
        Me.lblFecha.TabIndex = 63
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.Visible = False
        '
        'cbTipoBanco
        '
        Me.cbTipoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoBanco.FormattingEnabled = True
        Me.cbTipoBanco.Location = New System.Drawing.Point(311, 188)
        Me.cbTipoBanco.Name = "cbTipoBanco"
        Me.cbTipoBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbTipoBanco.TabIndex = 62
        Me.cbTipoBanco.Visible = False
        '
        'lblTIpoBanco
        '
        Me.lblTIpoBanco.AutoSize = True
        Me.lblTIpoBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIpoBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTIpoBanco.Location = New System.Drawing.Point(201, 189)
        Me.lblTIpoBanco.Name = "lblTIpoBanco"
        Me.lblTIpoBanco.Size = New System.Drawing.Size(39, 16)
        Me.lblTIpoBanco.TabIndex = 61
        Me.lblTIpoBanco.Text = "Tipo:"
        Me.lblTIpoBanco.Visible = False
        '
        'cbBanco
        '
        Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(312, 128)
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbBanco.TabIndex = 60
        Me.cbBanco.Visible = False
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBanco.Location = New System.Drawing.Point(202, 129)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(50, 16)
        Me.lblBanco.TabIndex = 59
        Me.lblBanco.Text = "Banco:"
        Me.lblBanco.Visible = False
        '
        'cbFormaPago
        '
        Me.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormaPago.Enabled = False
        Me.cbFormaPago.FormattingEnabled = True
        Me.cbFormaPago.Location = New System.Drawing.Point(311, 63)
        Me.cbFormaPago.Name = "cbFormaPago"
        Me.cbFormaPago.Size = New System.Drawing.Size(226, 21)
        Me.cbFormaPago.TabIndex = 58
        '
        'lblFormadepago
        '
        Me.lblFormadepago.AutoSize = True
        Me.lblFormadepago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormadepago.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFormadepago.Location = New System.Drawing.Point(201, 64)
        Me.lblFormadepago.Name = "lblFormadepago"
        Me.lblFormadepago.Size = New System.Drawing.Size(104, 16)
        Me.lblFormadepago.TabIndex = 57
        Me.lblFormadepago.Text = "Forma de pago:"
        '
        'CambioFormaPagoEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(782, 701)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "CambioFormaPagoEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CambioFormaPagoEDC"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents cbFactura As ComboBox
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents lblMatricula As Label
    Friend WithEvents lblFacturaCB As Label
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents btnBuscarMatricula As Button
    Friend WithEvents lblFolioBuscar As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents btnBuscarFolio As Button
    Friend WithEvents panelDatos As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents txtBancotext As TextBox
    Friend WithEvents lblBancotext As Label
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
    Friend WithEvents cbFormaPago As ComboBox
    Friend WithEvents lblFormadepago As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnGuardarCondonaciones As Button
End Class
