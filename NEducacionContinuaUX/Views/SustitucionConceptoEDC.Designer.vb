<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SustitucionConceptoEDC
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
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.panelInfo = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardarSustitucion = New System.Windows.Forms.Button()
        Me.cbObservaciones = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GridConceptos = New System.Windows.Forms.DataGridView()
        Me.IDPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDClave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreConceptoNuevo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblFolioFiscal = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblFormaPago = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFechaFacturacion = New System.Windows.Forms.Label()
        Me.lblRFCTimbrado = New System.Windows.Forms.Label()
        Me.lblClaveCliente = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelTipoPago = New System.Windows.Forms.Panel()
        Me.lblFormadepago = New System.Windows.Forms.Label()
        Me.txtNotaAplicada = New System.Windows.Forms.TextBox()
        Me.cbFormaPago = New System.Windows.Forms.ComboBox()
        Me.lblNotaAplicada = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.txtBancotext = New System.Windows.Forms.TextBox()
        Me.cbBanco = New System.Windows.Forms.ComboBox()
        Me.lblBancotext = New System.Windows.Forms.Label()
        Me.lblTIpoBanco = New System.Windows.Forms.Label()
        Me.cbTipoBanco = New System.Windows.Forms.ComboBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtNoCuenta = New System.Windows.Forms.TextBox()
        Me.DTPickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblNoCuenta = New System.Windows.Forms.Label()
        Me.lblUltimosDigitos = New System.Windows.Forms.Label()
        Me.txtNoCheque = New System.Windows.Forms.TextBox()
        Me.txtUltimos4Digitos = New System.Windows.Forms.TextBox()
        Me.lblNoCheque = New System.Windows.Forms.Label()
        Me.panelInfo.SuspendLayout()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelTipoPago.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-3, -1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1141, 69)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Sustitución de conceptos para facturas timbradas"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFolio.Location = New System.Drawing.Point(18, 81)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(41, 16)
        Me.lblFolio.TabIndex = 55
        Me.lblFolio.Text = "Folio:"
        '
        'txtFolio
        '
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.Location = New System.Drawing.Point(65, 78)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(100, 22)
        Me.txtFolio.TabIndex = 56
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscar.Location = New System.Drawing.Point(172, 72)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(50, 35)
        Me.btnBuscar.TabIndex = 57
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'panelInfo
        '
        Me.panelInfo.Controls.Add(Me.btnSalir)
        Me.panelInfo.Controls.Add(Me.btnLimpiar)
        Me.panelInfo.Controls.Add(Me.btnGuardarSustitucion)
        Me.panelInfo.Controls.Add(Me.cbObservaciones)
        Me.panelInfo.Controls.Add(Me.Label11)
        Me.panelInfo.Controls.Add(Me.GridConceptos)
        Me.panelInfo.Controls.Add(Me.lblFolioFiscal)
        Me.panelInfo.Controls.Add(Me.Label10)
        Me.panelInfo.Controls.Add(Me.lblFormaPago)
        Me.panelInfo.Controls.Add(Me.Label8)
        Me.panelInfo.Controls.Add(Me.lblFechaFacturacion)
        Me.panelInfo.Controls.Add(Me.lblRFCTimbrado)
        Me.panelInfo.Controls.Add(Me.lblClaveCliente)
        Me.panelInfo.Controls.Add(Me.Label3)
        Me.panelInfo.Controls.Add(Me.Label2)
        Me.panelInfo.Controls.Add(Me.Label1)
        Me.panelInfo.Controls.Add(Me.panelTipoPago)
        Me.panelInfo.Location = New System.Drawing.Point(3, 110)
        Me.panelInfo.Name = "panelInfo"
        Me.panelInfo.Size = New System.Drawing.Size(1127, 468)
        Me.panelInfo.TabIndex = 58
        Me.panelInfo.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(1024, 381)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(85, 77)
        Me.btnSalir.TabIndex = 87
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(813, 383)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(85, 77)
        Me.btnLimpiar.TabIndex = 86
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardarSustitucion
        '
        Me.btnGuardarSustitucion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarSustitucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarSustitucion.Image = Global.NEducacionContinuaUX.My.Resources.Resources.icons8_one_page_down_40
        Me.btnGuardarSustitucion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardarSustitucion.Location = New System.Drawing.Point(922, 383)
        Me.btnGuardarSustitucion.Name = "btnGuardarSustitucion"
        Me.btnGuardarSustitucion.Size = New System.Drawing.Size(85, 75)
        Me.btnGuardarSustitucion.TabIndex = 85
        Me.btnGuardarSustitucion.Text = "Sustituir factura"
        Me.btnGuardarSustitucion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardarSustitucion.UseVisualStyleBackColor = True
        '
        'cbObservaciones
        '
        Me.cbObservaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbObservaciones.FormattingEnabled = True
        Me.cbObservaciones.Location = New System.Drawing.Point(18, 402)
        Me.cbObservaciones.Name = "cbObservaciones"
        Me.cbObservaciones.Size = New System.Drawing.Size(551, 24)
        Me.cbObservaciones.TabIndex = 84
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(15, 383)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(135, 16)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "Motivo de sustitución:"
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
        Me.GridConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDPago, Me.IDClave, Me.NombreConcepto, Me.Cantidad, Me.PreioUnitario, Me.Descuento, Me.IVA, Me.NombreConceptoNuevo, Me.Total})
        Me.GridConceptos.Location = New System.Drawing.Point(18, 89)
        Me.GridConceptos.Name = "GridConceptos"
        Me.GridConceptos.ReadOnly = True
        Me.GridConceptos.Size = New System.Drawing.Size(740, 281)
        Me.GridConceptos.TabIndex = 82
        '
        'IDPago
        '
        Me.IDPago.HeaderText = "IDPago"
        Me.IDPago.Name = "IDPago"
        Me.IDPago.ReadOnly = True
        Me.IDPago.Visible = False
        '
        'IDClave
        '
        Me.IDClave.HeaderText = "IDClave"
        Me.IDClave.Name = "IDClave"
        Me.IDClave.ReadOnly = True
        Me.IDClave.Visible = False
        '
        'NombreConcepto
        '
        Me.NombreConcepto.FillWeight = 150.0!
        Me.NombreConcepto.HeaderText = "NombreConcepto"
        Me.NombreConcepto.Name = "NombreConcepto"
        Me.NombreConcepto.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.FillWeight = 68.86192!
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Visible = False
        '
        'PreioUnitario
        '
        Me.PreioUnitario.FillWeight = 99.74654!
        Me.PreioUnitario.HeaderText = "PrecioUnitario"
        Me.PreioUnitario.Name = "PreioUnitario"
        Me.PreioUnitario.ReadOnly = True
        Me.PreioUnitario.Visible = False
        '
        'Descuento
        '
        Me.Descuento.FillWeight = 96.43436!
        Me.Descuento.HeaderText = "Descuento"
        Me.Descuento.Name = "Descuento"
        Me.Descuento.ReadOnly = True
        Me.Descuento.Visible = False
        '
        'IVA
        '
        Me.IVA.FillWeight = 93.55492!
        Me.IVA.HeaderText = "IVA"
        Me.IVA.Name = "IVA"
        Me.IVA.ReadOnly = True
        Me.IVA.Visible = False
        '
        'NombreConceptoNuevo
        '
        Me.NombreConceptoNuevo.FillWeight = 150.0!
        Me.NombreConceptoNuevo.HeaderText = "Nuevo nombre del concepto"
        Me.NombreConceptoNuevo.Name = "NombreConceptoNuevo"
        Me.NombreConceptoNuevo.ReadOnly = True
        '
        'Total
        '
        Me.Total.FillWeight = 91.37056!
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'lblFolioFiscal
        '
        Me.lblFolioFiscal.AutoSize = True
        Me.lblFolioFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioFiscal.ForeColor = System.Drawing.Color.Gold
        Me.lblFolioFiscal.Location = New System.Drawing.Point(397, 63)
        Me.lblFolioFiscal.Name = "lblFolioFiscal"
        Me.lblFolioFiscal.Size = New System.Drawing.Size(51, 18)
        Me.lblFolioFiscal.TabIndex = 81
        Me.lblFolioFiscal.Text = "Label9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Control
        Me.Label10.Location = New System.Drawing.Point(284, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 16)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Folio fiscal digital:"
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormaPago.ForeColor = System.Drawing.Color.Gold
        Me.lblFormaPago.Location = New System.Drawing.Point(120, 62)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(51, 18)
        Me.lblFormaPago.TabIndex = 79
        Me.lblFormaPago.Text = "Label7"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Location = New System.Drawing.Point(15, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 78
        Me.Label8.Text = "Forma de pago:"
        '
        'lblFechaFacturacion
        '
        Me.lblFechaFacturacion.AutoSize = True
        Me.lblFechaFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFacturacion.ForeColor = System.Drawing.Color.Gold
        Me.lblFechaFacturacion.Location = New System.Drawing.Point(532, 22)
        Me.lblFechaFacturacion.Name = "lblFechaFacturacion"
        Me.lblFechaFacturacion.Size = New System.Drawing.Size(51, 18)
        Me.lblFechaFacturacion.TabIndex = 77
        Me.lblFechaFacturacion.Text = "Label6"
        '
        'lblRFCTimbrado
        '
        Me.lblRFCTimbrado.AutoSize = True
        Me.lblRFCTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCTimbrado.ForeColor = System.Drawing.Color.Gold
        Me.lblRFCTimbrado.Location = New System.Drawing.Point(278, 21)
        Me.lblRFCTimbrado.Name = "lblRFCTimbrado"
        Me.lblRFCTimbrado.Size = New System.Drawing.Size(51, 18)
        Me.lblRFCTimbrado.TabIndex = 76
        Me.lblRFCTimbrado.Text = "Label5"
        '
        'lblClaveCliente
        '
        Me.lblClaveCliente.AutoSize = True
        Me.lblClaveCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaveCliente.ForeColor = System.Drawing.Color.Gold
        Me.lblClaveCliente.Location = New System.Drawing.Point(59, 21)
        Me.lblClaveCliente.Name = "lblClaveCliente"
        Me.lblClaveCliente.Size = New System.Drawing.Size(51, 18)
        Me.lblClaveCliente.TabIndex = 75
        Me.lblClaveCliente.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(397, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 16)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Fecha de facturación:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(178, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "RFC Timbrado:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Clave:"
        '
        'panelTipoPago
        '
        Me.panelTipoPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelTipoPago.Controls.Add(Me.lblFormadepago)
        Me.panelTipoPago.Controls.Add(Me.txtNotaAplicada)
        Me.panelTipoPago.Controls.Add(Me.cbFormaPago)
        Me.panelTipoPago.Controls.Add(Me.lblNotaAplicada)
        Me.panelTipoPago.Controls.Add(Me.lblTotal)
        Me.panelTipoPago.Controls.Add(Me.lblPeso)
        Me.panelTipoPago.Controls.Add(Me.lblBanco)
        Me.panelTipoPago.Controls.Add(Me.txtBancotext)
        Me.panelTipoPago.Controls.Add(Me.cbBanco)
        Me.panelTipoPago.Controls.Add(Me.lblBancotext)
        Me.panelTipoPago.Controls.Add(Me.lblTIpoBanco)
        Me.panelTipoPago.Controls.Add(Me.cbTipoBanco)
        Me.panelTipoPago.Controls.Add(Me.lblFecha)
        Me.panelTipoPago.Controls.Add(Me.txtNoCuenta)
        Me.panelTipoPago.Controls.Add(Me.DTPickerFecha)
        Me.panelTipoPago.Controls.Add(Me.lblNoCuenta)
        Me.panelTipoPago.Controls.Add(Me.lblUltimosDigitos)
        Me.panelTipoPago.Controls.Add(Me.txtNoCheque)
        Me.panelTipoPago.Controls.Add(Me.txtUltimos4Digitos)
        Me.panelTipoPago.Controls.Add(Me.lblNoCheque)
        Me.panelTipoPago.Enabled = False
        Me.panelTipoPago.Location = New System.Drawing.Point(764, 9)
        Me.panelTipoPago.Name = "panelTipoPago"
        Me.panelTipoPago.Size = New System.Drawing.Size(355, 361)
        Me.panelTipoPago.TabIndex = 71
        '
        'lblFormadepago
        '
        Me.lblFormadepago.AutoSize = True
        Me.lblFormadepago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormadepago.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFormadepago.Location = New System.Drawing.Point(3, 13)
        Me.lblFormadepago.Name = "lblFormadepago"
        Me.lblFormadepago.Size = New System.Drawing.Size(104, 16)
        Me.lblFormadepago.TabIndex = 6
        Me.lblFormadepago.Text = "Forma de pago:"
        '
        'txtNotaAplicada
        '
        Me.txtNotaAplicada.Enabled = False
        Me.txtNotaAplicada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotaAplicada.Location = New System.Drawing.Point(112, 48)
        Me.txtNotaAplicada.Name = "txtNotaAplicada"
        Me.txtNotaAplicada.Size = New System.Drawing.Size(226, 21)
        Me.txtNotaAplicada.TabIndex = 41
        Me.txtNotaAplicada.Visible = False
        '
        'cbFormaPago
        '
        Me.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormaPago.FormattingEnabled = True
        Me.cbFormaPago.Location = New System.Drawing.Point(113, 12)
        Me.cbFormaPago.Name = "cbFormaPago"
        Me.cbFormaPago.Size = New System.Drawing.Size(226, 21)
        Me.cbFormaPago.TabIndex = 7
        '
        'lblNotaAplicada
        '
        Me.lblNotaAplicada.AutoSize = True
        Me.lblNotaAplicada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotaAplicada.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNotaAplicada.Location = New System.Drawing.Point(3, 51)
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
        Me.lblTotal.Location = New System.Drawing.Point(143, 309)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 29)
        Me.lblTotal.TabIndex = 9
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPeso.Location = New System.Drawing.Point(117, 309)
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
        Me.lblBanco.Location = New System.Drawing.Point(3, 80)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(50, 16)
        Me.lblBanco.TabIndex = 11
        Me.lblBanco.Text = "Banco:"
        Me.lblBanco.Visible = False
        '
        'txtBancotext
        '
        Me.txtBancotext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBancotext.Location = New System.Drawing.Point(112, 108)
        Me.txtBancotext.Name = "txtBancotext"
        Me.txtBancotext.Size = New System.Drawing.Size(226, 21)
        Me.txtBancotext.TabIndex = 37
        Me.txtBancotext.Visible = False
        '
        'cbBanco
        '
        Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(113, 79)
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
        Me.lblBancotext.Location = New System.Drawing.Point(3, 111)
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
        Me.lblTIpoBanco.Location = New System.Drawing.Point(2, 110)
        Me.lblTIpoBanco.Name = "lblTIpoBanco"
        Me.lblTIpoBanco.Size = New System.Drawing.Size(39, 16)
        Me.lblTIpoBanco.TabIndex = 13
        Me.lblTIpoBanco.Text = "TIpo:"
        Me.lblTIpoBanco.Visible = False
        '
        'cbTipoBanco
        '
        Me.cbTipoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoBanco.FormattingEnabled = True
        Me.cbTipoBanco.Location = New System.Drawing.Point(112, 139)
        Me.cbTipoBanco.Name = "cbTipoBanco"
        Me.cbTipoBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbTipoBanco.TabIndex = 14
        Me.cbTipoBanco.Visible = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFecha.Location = New System.Drawing.Point(3, 170)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(49, 16)
        Me.lblFecha.TabIndex = 15
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.Visible = False
        '
        'txtNoCuenta
        '
        Me.txtNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCuenta.Location = New System.Drawing.Point(112, 222)
        Me.txtNoCuenta.Name = "txtNoCuenta"
        Me.txtNoCuenta.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCuenta.TabIndex = 33
        Me.txtNoCuenta.Visible = False
        '
        'DTPickerFecha
        '
        Me.DTPickerFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPickerFecha.Location = New System.Drawing.Point(112, 166)
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
        Me.lblNoCuenta.Location = New System.Drawing.Point(3, 225)
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
        Me.lblUltimosDigitos.Location = New System.Drawing.Point(2, 198)
        Me.lblUltimosDigitos.Name = "lblUltimosDigitos"
        Me.lblUltimosDigitos.Size = New System.Drawing.Size(109, 16)
        Me.lblUltimosDigitos.TabIndex = 17
        Me.lblUltimosDigitos.Text = "Últimos 4 digitos:"
        Me.lblUltimosDigitos.Visible = False
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCheque.Location = New System.Drawing.Point(112, 250)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCheque.TabIndex = 31
        Me.txtNoCheque.Visible = False
        '
        'txtUltimos4Digitos
        '
        Me.txtUltimos4Digitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimos4Digitos.Location = New System.Drawing.Point(112, 195)
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
        Me.lblNoCheque.Location = New System.Drawing.Point(2, 253)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(96, 16)
        Me.lblNoCheque.TabIndex = 30
        Me.lblNoCheque.Text = "No. de cheque"
        Me.lblNoCheque.Visible = False
        '
        'SustitucionConceptoEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1137, 587)
        Me.Controls.Add(Me.panelInfo)
        Me.Controls.Add(Me.lblFolio)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "SustitucionConceptoEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SustitufionConceptoEDC"
        Me.panelInfo.ResumeLayout(False)
        Me.panelInfo.PerformLayout()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelTipoPago.ResumeLayout(False)
        Me.panelTipoPago.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents lblFolio As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents panelInfo As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnGuardarSustitucion As Button
    Friend WithEvents cbObservaciones As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GridConceptos As DataGridView
    Friend WithEvents lblFolioFiscal As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblFormaPago As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblFechaFacturacion As Label
    Friend WithEvents lblRFCTimbrado As Label
    Friend WithEvents lblClaveCliente As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents panelTipoPago As Panel
    Friend WithEvents lblFormadepago As Label
    Friend WithEvents txtNotaAplicada As TextBox
    Friend WithEvents cbFormaPago As ComboBox
    Friend WithEvents lblNotaAplicada As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblPeso As Label
    Friend WithEvents lblBanco As Label
    Friend WithEvents txtBancotext As TextBox
    Friend WithEvents cbBanco As ComboBox
    Friend WithEvents lblBancotext As Label
    Friend WithEvents lblTIpoBanco As Label
    Friend WithEvents cbTipoBanco As ComboBox
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtNoCuenta As TextBox
    Friend WithEvents DTPickerFecha As DateTimePicker
    Friend WithEvents lblNoCuenta As Label
    Friend WithEvents lblUltimosDigitos As Label
    Friend WithEvents txtNoCheque As TextBox
    Friend WithEvents txtUltimos4Digitos As TextBox
    Friend WithEvents lblNoCheque As Label
    Friend WithEvents IDPago As DataGridViewTextBoxColumn
    Friend WithEvents IDClave As DataGridViewTextBoxColumn
    Friend WithEvents NombreConcepto As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents PreioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents Descuento As DataGridViewTextBoxColumn
    Friend WithEvents IVA As DataGridViewTextBoxColumn
    Friend WithEvents NombreConceptoNuevo As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
End Class
