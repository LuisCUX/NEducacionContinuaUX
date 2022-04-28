<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PagosCreditoEDC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PagosCreditoEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.panelBusqueda = New System.Windows.Forms.Panel()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.lblDirecciontxt = New System.Windows.Forms.Label()
        Me.lblCFDItxt = New System.Windows.Forms.Label()
        Me.lblCFDI = New System.Windows.Forms.Label()
        Me.lblRegFiscaltxt = New System.Windows.Forms.Label()
        Me.lblRegFiscal = New System.Windows.Forms.Label()
        Me.lblCPtxt = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblTurnotxt = New System.Windows.Forms.Label()
        Me.lblCarreratxt = New System.Windows.Forms.Label()
        Me.lblRFCtxt = New System.Windows.Forms.Label()
        Me.lblEmailtxt = New System.Windows.Forms.Label()
        Me.lblNombretxt = New System.Windows.Forms.Label()
        Me.lblMatriculatxt = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblMatriculaDato = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.GBFactura = New System.Windows.Forms.GroupBox()
        Me.gridConceptosFactura = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClaveIDPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lblTipoNota = New System.Windows.Forms.Label()
        Me.cbFactura = New System.Windows.Forms.ComboBox()
        Me.panelCobroCredito = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCobrar = New System.Windows.Forms.Button()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFormadepago = New System.Windows.Forms.Label()
        Me.cbFormaPago = New System.Windows.Forms.ComboBox()
        Me.GBDesglose = New System.Windows.Forms.GroupBox()
        Me.GridFacturaPagos = New System.Windows.Forms.DataGridView()
        Me.FolioA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoPagoA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoPagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoRestante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBFacturaSeleccionada = New System.Windows.Forms.GroupBox()
        Me.GridFacturaSeleccionada = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abonado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoPagos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelBusqueda.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.GBFactura.SuspendLayout()
        CType(Me.gridConceptosFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelCobroCredito.SuspendLayout()
        Me.GBDesglose.SuspendLayout()
        CType(Me.GridFacturaPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBFacturaSeleccionada.SuspendLayout()
        CType(Me.GridFacturaSeleccionada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(1, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1320, 69)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Pago de Créditos"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBusqueda
        '
        Me.panelBusqueda.Controls.Add(Me.cbExterno)
        Me.panelBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Location = New System.Drawing.Point(7, 72)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(1301, 50)
        Me.panelBusqueda.TabIndex = 16
        '
        'cbExterno
        '
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(355, 14)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(677, 21)
        Me.cbExterno.TabIndex = 73
        '
        'lblBusquedaNombre
        '
        Me.lblBusquedaNombre.AutoSize = True
        Me.lblBusquedaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBusquedaNombre.Location = New System.Drawing.Point(296, 16)
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
        Me.txtMatricula.Location = New System.Drawing.Point(66, 13)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(111, 22)
        Me.txtMatricula.TabIndex = 1
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula.Location = New System.Drawing.Point(5, 16)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(46, 16)
        Me.lblMatricula.TabIndex = 0
        Me.lblMatricula.Text = "Clave:"
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
        Me.panelDatos.Controls.Add(Me.lblTurnotxt)
        Me.panelDatos.Controls.Add(Me.lblCarreratxt)
        Me.panelDatos.Controls.Add(Me.lblRFCtxt)
        Me.panelDatos.Controls.Add(Me.lblEmailtxt)
        Me.panelDatos.Controls.Add(Me.lblNombretxt)
        Me.panelDatos.Controls.Add(Me.lblMatriculatxt)
        Me.panelDatos.Controls.Add(Me.lblRFC)
        Me.panelDatos.Controls.Add(Me.lblMatriculaDato)
        Me.panelDatos.Controls.Add(Me.lblTurno)
        Me.panelDatos.Controls.Add(Me.lblCarrera)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Location = New System.Drawing.Point(7, 128)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(1301, 104)
        Me.panelDatos.TabIndex = 17
        Me.panelDatos.Visible = False
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDireccion.Location = New System.Drawing.Point(78, 79)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(0, 15)
        Me.lblDireccion.TabIndex = 101
        '
        'lblDirecciontxt
        '
        Me.lblDirecciontxt.AutoSize = True
        Me.lblDirecciontxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirecciontxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDirecciontxt.Location = New System.Drawing.Point(11, 79)
        Me.lblDirecciontxt.Name = "lblDirecciontxt"
        Me.lblDirecciontxt.Size = New System.Drawing.Size(62, 15)
        Me.lblDirecciontxt.TabIndex = 100
        Me.lblDirecciontxt.Text = "Direccion:"
        '
        'lblCFDItxt
        '
        Me.lblCFDItxt.AutoSize = True
        Me.lblCFDItxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDItxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDItxt.Location = New System.Drawing.Point(507, 56)
        Me.lblCFDItxt.Name = "lblCFDItxt"
        Me.lblCFDItxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCFDItxt.TabIndex = 95
        '
        'lblCFDI
        '
        Me.lblCFDI.AutoSize = True
        Me.lblCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDI.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDI.Location = New System.Drawing.Point(409, 56)
        Me.lblCFDI.Name = "lblCFDI"
        Me.lblCFDI.Size = New System.Drawing.Size(62, 15)
        Me.lblCFDI.TabIndex = 94
        Me.lblCFDI.Text = "Uso CFDI:"
        '
        'lblRegFiscaltxt
        '
        Me.lblRegFiscaltxt.AutoSize = True
        Me.lblRegFiscaltxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegFiscaltxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRegFiscaltxt.Location = New System.Drawing.Point(507, 29)
        Me.lblRegFiscaltxt.Name = "lblRegFiscaltxt"
        Me.lblRegFiscaltxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRegFiscaltxt.TabIndex = 93
        '
        'lblRegFiscal
        '
        Me.lblRegFiscal.AutoSize = True
        Me.lblRegFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegFiscal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRegFiscal.Location = New System.Drawing.Point(409, 33)
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
        Me.lblCPtxt.Location = New System.Drawing.Point(507, 79)
        Me.lblCPtxt.Name = "lblCPtxt"
        Me.lblCPtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCPtxt.TabIndex = 91
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCP.Location = New System.Drawing.Point(409, 79)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(26, 15)
        Me.lblCP.TabIndex = 90
        Me.lblCP.Text = "CP:"
        '
        'lblTurnotxt
        '
        Me.lblTurnotxt.AutoSize = True
        Me.lblTurnotxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnotxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurnotxt.Location = New System.Drawing.Point(1122, 80)
        Me.lblTurnotxt.Name = "lblTurnotxt"
        Me.lblTurnotxt.Size = New System.Drawing.Size(0, 15)
        Me.lblTurnotxt.TabIndex = 48
        Me.lblTurnotxt.Visible = False
        '
        'lblCarreratxt
        '
        Me.lblCarreratxt.AutoSize = True
        Me.lblCarreratxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarreratxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCarreratxt.Location = New System.Drawing.Point(1140, 56)
        Me.lblCarreratxt.Name = "lblCarreratxt"
        Me.lblCarreratxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCarreratxt.TabIndex = 47
        Me.lblCarreratxt.Visible = False
        '
        'lblRFCtxt
        '
        Me.lblRFCtxt.AutoSize = True
        Me.lblRFCtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFCtxt.Location = New System.Drawing.Point(507, 12)
        Me.lblRFCtxt.Name = "lblRFCtxt"
        Me.lblRFCtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRFCtxt.TabIndex = 46
        '
        'lblEmailtxt
        '
        Me.lblEmailtxt.AutoSize = True
        Me.lblEmailtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmailtxt.Location = New System.Drawing.Point(78, 56)
        Me.lblEmailtxt.Name = "lblEmailtxt"
        Me.lblEmailtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblEmailtxt.TabIndex = 45
        '
        'lblNombretxt
        '
        Me.lblNombretxt.AutoSize = True
        Me.lblNombretxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombretxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombretxt.Location = New System.Drawing.Point(78, 33)
        Me.lblNombretxt.Name = "lblNombretxt"
        Me.lblNombretxt.Size = New System.Drawing.Size(0, 15)
        Me.lblNombretxt.TabIndex = 44
        '
        'lblMatriculatxt
        '
        Me.lblMatriculatxt.AutoSize = True
        Me.lblMatriculatxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatriculatxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatriculatxt.Location = New System.Drawing.Point(78, 12)
        Me.lblMatriculatxt.Name = "lblMatriculatxt"
        Me.lblMatriculatxt.Size = New System.Drawing.Size(0, 15)
        Me.lblMatriculatxt.TabIndex = 43
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFC.Location = New System.Drawing.Point(409, 11)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 15)
        Me.lblRFC.TabIndex = 42
        Me.lblRFC.Text = "RFC:"
        '
        'lblMatriculaDato
        '
        Me.lblMatriculaDato.AutoSize = True
        Me.lblMatriculaDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatriculaDato.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatriculaDato.Location = New System.Drawing.Point(11, 11)
        Me.lblMatriculaDato.Name = "lblMatriculaDato"
        Me.lblMatriculaDato.Size = New System.Drawing.Size(61, 15)
        Me.lblMatriculaDato.TabIndex = 41
        Me.lblMatriculaDato.Text = "Matrícula:"
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurno.Location = New System.Drawing.Point(1081, 79)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(42, 15)
        Me.lblTurno.TabIndex = 40
        Me.lblTurno.Text = "Turno:"
        Me.lblTurno.Visible = False
        '
        'lblCarrera
        '
        Me.lblCarrera.AutoSize = True
        Me.lblCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarrera.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCarrera.Location = New System.Drawing.Point(1081, 56)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Size = New System.Drawing.Size(51, 15)
        Me.lblCarrera.TabIndex = 39
        Me.lblCarrera.Text = "Carrera:"
        Me.lblCarrera.Visible = False
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail.Location = New System.Drawing.Point(11, 56)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail.TabIndex = 38
        Me.lblEmail.Text = "Email:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre.Location = New System.Drawing.Point(11, 33)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblNombre.TabIndex = 37
        Me.lblNombre.Text = "Nombre: "
        '
        'GBFactura
        '
        Me.GBFactura.Controls.Add(Me.gridConceptosFactura)
        Me.GBFactura.Controls.Add(Me.btnAgregar)
        Me.GBFactura.Controls.Add(Me.lblTipoNota)
        Me.GBFactura.Controls.Add(Me.cbFactura)
        Me.GBFactura.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GBFactura.Location = New System.Drawing.Point(5, 6)
        Me.GBFactura.Name = "GBFactura"
        Me.GBFactura.Size = New System.Drawing.Size(446, 445)
        Me.GBFactura.TabIndex = 83
        Me.GBFactura.TabStop = False
        Me.GBFactura.Text = "Facturas cobradas a credito"
        '
        'gridConceptosFactura
        '
        Me.gridConceptosFactura.AllowUserToAddRows = False
        Me.gridConceptosFactura.AllowUserToDeleteRows = False
        Me.gridConceptosFactura.AllowUserToResizeColumns = False
        Me.gridConceptosFactura.AllowUserToResizeRows = False
        Me.gridConceptosFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridConceptosFactura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.gridConceptosFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridConceptosFactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.ClaveIDPago, Me.Clave, Me.Descripcion, Me.TotalPago})
        Me.gridConceptosFactura.Location = New System.Drawing.Point(5, 64)
        Me.gridConceptosFactura.Name = "gridConceptosFactura"
        Me.gridConceptosFactura.ReadOnly = True
        Me.gridConceptosFactura.Size = New System.Drawing.Size(434, 320)
        Me.gridConceptosFactura.TabIndex = 108
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 49.16087!
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'ClaveIDPago
        '
        Me.ClaveIDPago.HeaderText = "Clave"
        Me.ClaveIDPago.Name = "ClaveIDPago"
        Me.ClaveIDPago.ReadOnly = True
        Me.ClaveIDPago.Visible = False
        '
        'Clave
        '
        Me.Clave.FillWeight = 50.48787!
        Me.Clave.HeaderText = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.FillWeight = 198.8284!
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'TotalPago
        '
        Me.TotalPago.FillWeight = 101.5228!
        Me.TotalPago.HeaderText = "Total"
        Me.TotalPago.Name = "TotalPago"
        Me.TotalPago.ReadOnly = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.Add_30px
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAgregar.Location = New System.Drawing.Point(179, 390)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(70, 40)
        Me.btnAgregar.TabIndex = 107
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lblTipoNota
        '
        Me.lblTipoNota.AutoSize = True
        Me.lblTipoNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoNota.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoNota.Location = New System.Drawing.Point(4, 16)
        Me.lblTipoNota.Name = "lblTipoNota"
        Me.lblTipoNota.Size = New System.Drawing.Size(147, 16)
        Me.lblTipoNota.TabIndex = 78
        Me.lblTipoNota.Text = "Seleccione una factura:"
        '
        'cbFactura
        '
        Me.cbFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFactura.FormattingEnabled = True
        Me.cbFactura.Location = New System.Drawing.Point(7, 35)
        Me.cbFactura.Name = "cbFactura"
        Me.cbFactura.Size = New System.Drawing.Size(431, 21)
        Me.cbFactura.TabIndex = 79
        '
        'panelCobroCredito
        '
        Me.panelCobroCredito.Controls.Add(Me.btnLimpiar)
        Me.panelCobroCredito.Controls.Add(Me.btnSalir)
        Me.panelCobroCredito.Controls.Add(Me.btnCobrar)
        Me.panelCobroCredito.Controls.Add(Me.txtMonto)
        Me.panelCobroCredito.Controls.Add(Me.lblTotal)
        Me.panelCobroCredito.Controls.Add(Me.lblMonto)
        Me.panelCobroCredito.Controls.Add(Me.txtNoCuenta)
        Me.panelCobroCredito.Controls.Add(Me.lblNoCuenta)
        Me.panelCobroCredito.Controls.Add(Me.txtNoCheque)
        Me.panelCobroCredito.Controls.Add(Me.lblNoCheque)
        Me.panelCobroCredito.Controls.Add(Me.txtUltimos4Digitos)
        Me.panelCobroCredito.Controls.Add(Me.lblUltimosDigitos)
        Me.panelCobroCredito.Controls.Add(Me.DTPickerFecha)
        Me.panelCobroCredito.Controls.Add(Me.lblFecha)
        Me.panelCobroCredito.Controls.Add(Me.cbTipoBanco)
        Me.panelCobroCredito.Controls.Add(Me.lblTIpoBanco)
        Me.panelCobroCredito.Controls.Add(Me.cbBanco)
        Me.panelCobroCredito.Controls.Add(Me.lblBanco)
        Me.panelCobroCredito.Controls.Add(Me.lblPeso)
        Me.panelCobroCredito.Controls.Add(Me.Label3)
        Me.panelCobroCredito.Controls.Add(Me.lblFormadepago)
        Me.panelCobroCredito.Controls.Add(Me.cbFormaPago)
        Me.panelCobroCredito.Controls.Add(Me.GBDesglose)
        Me.panelCobroCredito.Controls.Add(Me.GBFacturaSeleccionada)
        Me.panelCobroCredito.Controls.Add(Me.GBFactura)
        Me.panelCobroCredito.Location = New System.Drawing.Point(7, 238)
        Me.panelCobroCredito.Name = "panelCobroCredito"
        Me.panelCobroCredito.Size = New System.Drawing.Size(1301, 458)
        Me.panelCobroCredito.TabIndex = 84
        Me.panelCobroCredito.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(985, 389)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(70, 52)
        Me.btnLimpiar.TabIndex = 107
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(1200, 389)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(70, 52)
        Me.btnSalir.TabIndex = 105
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCobrar
        '
        Me.btnCobrar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.cash_register_40px
        Me.btnCobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCobrar.Location = New System.Drawing.Point(1097, 389)
        Me.btnCobrar.Name = "btnCobrar"
        Me.btnCobrar.Size = New System.Drawing.Size(70, 52)
        Me.btnCobrar.TabIndex = 106
        Me.btnCobrar.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(1034, 74)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(226, 21)
        Me.txtMonto.TabIndex = 104
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Location = New System.Drawing.Point(1055, 336)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 29)
        Me.lblTotal.TabIndex = 88
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMonto.Location = New System.Drawing.Point(928, 77)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(98, 16)
        Me.lblMonto.TabIndex = 103
        Me.lblMonto.Text = "Monto a pagar:"
        '
        'txtNoCuenta
        '
        Me.txtNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCuenta.Location = New System.Drawing.Point(1034, 248)
        Me.txtNoCuenta.Name = "txtNoCuenta"
        Me.txtNoCuenta.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCuenta.TabIndex = 102
        Me.txtNoCuenta.Visible = False
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCuenta.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCuenta.Location = New System.Drawing.Point(929, 251)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(74, 16)
        Me.lblNoCuenta.TabIndex = 101
        Me.lblNoCuenta.Text = "No. Cuenta"
        Me.lblNoCuenta.Visible = False
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCheque.Location = New System.Drawing.Point(1034, 276)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(226, 21)
        Me.txtNoCheque.TabIndex = 100
        Me.txtNoCheque.Visible = False
        '
        'lblNoCheque
        '
        Me.lblNoCheque.AutoSize = True
        Me.lblNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCheque.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNoCheque.Location = New System.Drawing.Point(928, 279)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(96, 16)
        Me.lblNoCheque.TabIndex = 99
        Me.lblNoCheque.Text = "No. de cheque"
        Me.lblNoCheque.Visible = False
        '
        'txtUltimos4Digitos
        '
        Me.txtUltimos4Digitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimos4Digitos.Location = New System.Drawing.Point(1034, 221)
        Me.txtUltimos4Digitos.MaxLength = 4
        Me.txtUltimos4Digitos.Name = "txtUltimos4Digitos"
        Me.txtUltimos4Digitos.Size = New System.Drawing.Size(226, 21)
        Me.txtUltimos4Digitos.TabIndex = 98
        Me.txtUltimos4Digitos.Visible = False
        '
        'lblUltimosDigitos
        '
        Me.lblUltimosDigitos.AutoSize = True
        Me.lblUltimosDigitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimosDigitos.ForeColor = System.Drawing.SystemColors.Control
        Me.lblUltimosDigitos.Location = New System.Drawing.Point(928, 224)
        Me.lblUltimosDigitos.Name = "lblUltimosDigitos"
        Me.lblUltimosDigitos.Size = New System.Drawing.Size(109, 16)
        Me.lblUltimosDigitos.TabIndex = 97
        Me.lblUltimosDigitos.Text = "Últimos 4 digitos:"
        Me.lblUltimosDigitos.Visible = False
        '
        'DTPickerFecha
        '
        Me.DTPickerFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPickerFecha.Location = New System.Drawing.Point(1034, 192)
        Me.DTPickerFecha.Name = "DTPickerFecha"
        Me.DTPickerFecha.Size = New System.Drawing.Size(89, 20)
        Me.DTPickerFecha.TabIndex = 96
        Me.DTPickerFecha.Visible = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFecha.Location = New System.Drawing.Point(929, 196)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(49, 16)
        Me.lblFecha.TabIndex = 95
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.Visible = False
        '
        'cbTipoBanco
        '
        Me.cbTipoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoBanco.FormattingEnabled = True
        Me.cbTipoBanco.Location = New System.Drawing.Point(1034, 165)
        Me.cbTipoBanco.Name = "cbTipoBanco"
        Me.cbTipoBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbTipoBanco.TabIndex = 94
        Me.cbTipoBanco.Visible = False
        '
        'lblTIpoBanco
        '
        Me.lblTIpoBanco.AutoSize = True
        Me.lblTIpoBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIpoBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTIpoBanco.Location = New System.Drawing.Point(928, 166)
        Me.lblTIpoBanco.Name = "lblTIpoBanco"
        Me.lblTIpoBanco.Size = New System.Drawing.Size(39, 16)
        Me.lblTIpoBanco.TabIndex = 93
        Me.lblTIpoBanco.Text = "Tipo:"
        Me.lblTIpoBanco.Visible = False
        '
        'cbBanco
        '
        Me.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBanco.FormattingEnabled = True
        Me.cbBanco.Location = New System.Drawing.Point(1034, 136)
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.Size = New System.Drawing.Size(226, 21)
        Me.cbBanco.TabIndex = 92
        Me.cbBanco.Visible = False
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBanco.Location = New System.Drawing.Point(928, 137)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(50, 16)
        Me.lblBanco.TabIndex = 91
        Me.lblBanco.Text = "Banco:"
        Me.lblBanco.Visible = False
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPeso.Location = New System.Drawing.Point(1023, 336)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(26, 29)
        Me.lblPeso.TabIndex = 90
        Me.lblPeso.Text = "$"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(1043, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 29)
        Me.Label3.TabIndex = 89
        '
        'lblFormadepago
        '
        Me.lblFormadepago.AutoSize = True
        Me.lblFormadepago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormadepago.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFormadepago.Location = New System.Drawing.Point(928, 42)
        Me.lblFormadepago.Name = "lblFormadepago"
        Me.lblFormadepago.Size = New System.Drawing.Size(104, 16)
        Me.lblFormadepago.TabIndex = 86
        Me.lblFormadepago.Text = "Forma de pago:"
        '
        'cbFormaPago
        '
        Me.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormaPago.FormattingEnabled = True
        Me.cbFormaPago.Location = New System.Drawing.Point(1034, 41)
        Me.cbFormaPago.Name = "cbFormaPago"
        Me.cbFormaPago.Size = New System.Drawing.Size(226, 21)
        Me.cbFormaPago.TabIndex = 87
        '
        'GBDesglose
        '
        Me.GBDesglose.Controls.Add(Me.GridFacturaPagos)
        Me.GBDesglose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GBDesglose.Location = New System.Drawing.Point(457, 236)
        Me.GBDesglose.Name = "GBDesglose"
        Me.GBDesglose.Size = New System.Drawing.Size(446, 215)
        Me.GBDesglose.TabIndex = 85
        Me.GBDesglose.TabStop = False
        Me.GBDesglose.Text = "Historial de pagos de factura seleccionada"
        '
        'GridFacturaPagos
        '
        Me.GridFacturaPagos.AllowUserToAddRows = False
        Me.GridFacturaPagos.AllowUserToDeleteRows = False
        Me.GridFacturaPagos.AllowUserToResizeColumns = False
        Me.GridFacturaPagos.AllowUserToResizeRows = False
        Me.GridFacturaPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridFacturaPagos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridFacturaPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridFacturaPagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FolioA, Me.NoPagoA, Me.SaldoAnt, Me.SaldoPagado, Me.SaldoRestante})
        Me.GridFacturaPagos.Location = New System.Drawing.Point(6, 19)
        Me.GridFacturaPagos.Name = "GridFacturaPagos"
        Me.GridFacturaPagos.ReadOnly = True
        Me.GridFacturaPagos.Size = New System.Drawing.Size(434, 191)
        Me.GridFacturaPagos.TabIndex = 83
        '
        'FolioA
        '
        Me.FolioA.HeaderText = "Folio"
        Me.FolioA.Name = "FolioA"
        Me.FolioA.ReadOnly = True
        '
        'NoPagoA
        '
        Me.NoPagoA.HeaderText = "No. Pago"
        Me.NoPagoA.Name = "NoPagoA"
        Me.NoPagoA.ReadOnly = True
        '
        'SaldoAnt
        '
        Me.SaldoAnt.HeaderText = "Saldo Anterior"
        Me.SaldoAnt.Name = "SaldoAnt"
        Me.SaldoAnt.ReadOnly = True
        '
        'SaldoPagado
        '
        Me.SaldoPagado.HeaderText = "Saldo Abonado"
        Me.SaldoPagado.Name = "SaldoPagado"
        Me.SaldoPagado.ReadOnly = True
        '
        'SaldoRestante
        '
        Me.SaldoRestante.HeaderText = "Saldo Restante"
        Me.SaldoRestante.Name = "SaldoRestante"
        Me.SaldoRestante.ReadOnly = True
        '
        'GBFacturaSeleccionada
        '
        Me.GBFacturaSeleccionada.Controls.Add(Me.GridFacturaSeleccionada)
        Me.GBFacturaSeleccionada.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GBFacturaSeleccionada.Location = New System.Drawing.Point(457, 6)
        Me.GBFacturaSeleccionada.Name = "GBFacturaSeleccionada"
        Me.GBFacturaSeleccionada.Size = New System.Drawing.Size(446, 224)
        Me.GBFacturaSeleccionada.TabIndex = 84
        Me.GBFacturaSeleccionada.TabStop = False
        Me.GBFacturaSeleccionada.Text = "Factura seleccionada"
        '
        'GridFacturaSeleccionada
        '
        Me.GridFacturaSeleccionada.AllowUserToAddRows = False
        Me.GridFacturaSeleccionada.AllowUserToDeleteRows = False
        Me.GridFacturaSeleccionada.AllowUserToResizeColumns = False
        Me.GridFacturaSeleccionada.AllowUserToResizeRows = False
        Me.GridFacturaSeleccionada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridFacturaSeleccionada.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridFacturaSeleccionada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridFacturaSeleccionada.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Folio, Me.Fecha, Me.Cantidad, Me.Abonado, Me.NoPagos})
        Me.GridFacturaSeleccionada.Location = New System.Drawing.Point(6, 19)
        Me.GridFacturaSeleccionada.Name = "GridFacturaSeleccionada"
        Me.GridFacturaSeleccionada.ReadOnly = True
        Me.GridFacturaSeleccionada.Size = New System.Drawing.Size(434, 199)
        Me.GridFacturaSeleccionada.TabIndex = 82
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'Folio
        '
        Me.Folio.HeaderText = "Folio"
        Me.Folio.Name = "Folio"
        Me.Folio.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        '
        'Abonado
        '
        Me.Abonado.HeaderText = "Abonado"
        Me.Abonado.Name = "Abonado"
        Me.Abonado.ReadOnly = True
        '
        'NoPagos
        '
        Me.NoPagos.HeaderText = "No. Pagos"
        Me.NoPagos.Name = "NoPagos"
        Me.NoPagos.ReadOnly = True
        '
        'PagosCreditoEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1320, 708)
        Me.Controls.Add(Me.panelCobroCredito)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.panelBusqueda)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PagosCreditoEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PagosCreditoEDC"
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.GBFactura.ResumeLayout(False)
        Me.GBFactura.PerformLayout()
        CType(Me.gridConceptosFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelCobroCredito.ResumeLayout(False)
        Me.panelCobroCredito.PerformLayout()
        Me.GBDesglose.ResumeLayout(False)
        CType(Me.GridFacturaPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBFacturaSeleccionada.ResumeLayout(False)
        CType(Me.GridFacturaSeleccionada, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GBFactura As GroupBox
    Friend WithEvents lblTipoNota As Label
    Friend WithEvents cbFactura As ComboBox
    Friend WithEvents panelCobroCredito As Panel
    Friend WithEvents GBFacturaSeleccionada As GroupBox
    Friend WithEvents GBDesglose As GroupBox
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents lblTotal As Label
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
    Friend WithEvents lblPeso As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblFormadepago As Label
    Friend WithEvents cbFormaPago As ComboBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnCobrar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents GridFacturaPagos As DataGridView
    Friend WithEvents FolioA As DataGridViewTextBoxColumn
    Friend WithEvents NoPagoA As DataGridViewTextBoxColumn
    Friend WithEvents SaldoAnt As DataGridViewTextBoxColumn
    Friend WithEvents SaldoPagado As DataGridViewTextBoxColumn
    Friend WithEvents SaldoRestante As DataGridViewTextBoxColumn
    Friend WithEvents GridFacturaSeleccionada As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Folio As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Abonado As DataGridViewTextBoxColumn
    Friend WithEvents NoPagos As DataGridViewTextBoxColumn
    Friend WithEvents gridConceptosFactura As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents ClaveIDPago As DataGridViewTextBoxColumn
    Friend WithEvents Clave As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents TotalPago As DataGridViewTextBoxColumn
    Friend WithEvents lblTurnotxt As Label
    Friend WithEvents lblCarreratxt As Label
    Friend WithEvents lblRFCtxt As Label
    Friend WithEvents lblEmailtxt As Label
    Friend WithEvents lblNombretxt As Label
    Friend WithEvents lblMatriculatxt As Label
    Friend WithEvents lblRFC As Label
    Friend WithEvents lblMatriculaDato As Label
    Friend WithEvents lblTurno As Label
    Friend WithEvents lblCarrera As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents lblRegFiscaltxt As Label
    Friend WithEvents lblRegFiscal As Label
    Friend WithEvents lblCPtxt As Label
    Friend WithEvents lblCP As Label
    Friend WithEvents lblCFDItxt As Label
    Friend WithEvents lblCFDI As Label
    Friend WithEvents lblDireccion As Label
    Friend WithEvents lblDirecciontxt As Label
End Class
