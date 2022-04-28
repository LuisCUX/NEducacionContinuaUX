<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NotasDeCreditoEDC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotasDeCreditoEDC))
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
        Me.lblTurnotxt = New System.Windows.Forms.Label()
        Me.lblRegFiscal = New System.Windows.Forms.Label()
        Me.lblCarreratxt = New System.Windows.Forms.Label()
        Me.lblCPtxt = New System.Windows.Forms.Label()
        Me.lblRFCtxt = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblEmailtxt = New System.Windows.Forms.Label()
        Me.lblNombretxt = New System.Windows.Forms.Label()
        Me.lblMatriculatxt = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblMatriculaDato = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.panelGridNota = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalNota = New System.Windows.Forms.Label()
        Me.GBNota = New System.Windows.Forms.GroupBox()
        Me.chb100 = New System.Windows.Forms.CheckBox()
        Me.NUPorcentaje = New System.Windows.Forms.NumericUpDown()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTipoNota = New System.Windows.Forms.Label()
        Me.cbConcepto = New System.Windows.Forms.ComboBox()
        Me.cbTipoNota = New System.Windows.Forms.ComboBox()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GridNota = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FolioFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostoOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.lblDirecciontxt = New System.Windows.Forms.Label()
        Me.panelBusqueda.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.panelGridNota.SuspendLayout()
        Me.GBNota.SuspendLayout()
        CType(Me.NUPorcentaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridNota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(0, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1117, 69)
        Me.lblNombreVentana.TabIndex = 13
        Me.lblNombreVentana.Text = "Notas de Crédito"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBusqueda
        '
        Me.panelBusqueda.Controls.Add(Me.cbExterno)
        Me.panelBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Location = New System.Drawing.Point(7, 73)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(1102, 50)
        Me.panelBusqueda.TabIndex = 15
        '
        'cbExterno
        '
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(300, 14)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(600, 21)
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
        Me.panelDatos.Controls.Add(Me.lblTurnotxt)
        Me.panelDatos.Controls.Add(Me.lblRegFiscal)
        Me.panelDatos.Controls.Add(Me.lblCarreratxt)
        Me.panelDatos.Controls.Add(Me.lblCPtxt)
        Me.panelDatos.Controls.Add(Me.lblRFCtxt)
        Me.panelDatos.Controls.Add(Me.lblCP)
        Me.panelDatos.Controls.Add(Me.lblEmailtxt)
        Me.panelDatos.Controls.Add(Me.lblNombretxt)
        Me.panelDatos.Controls.Add(Me.lblMatriculatxt)
        Me.panelDatos.Controls.Add(Me.lblRFC)
        Me.panelDatos.Controls.Add(Me.lblMatriculaDato)
        Me.panelDatos.Controls.Add(Me.lblTurno)
        Me.panelDatos.Controls.Add(Me.lblCarrera)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Location = New System.Drawing.Point(6, 129)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(1103, 53)
        Me.panelDatos.TabIndex = 16
        Me.panelDatos.Visible = False
        '
        'lblCFDItxt
        '
        Me.lblCFDItxt.AutoSize = True
        Me.lblCFDItxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDItxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDItxt.Location = New System.Drawing.Point(799, 31)
        Me.lblCFDItxt.Name = "lblCFDItxt"
        Me.lblCFDItxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCFDItxt.TabIndex = 97
        '
        'lblCFDI
        '
        Me.lblCFDI.AutoSize = True
        Me.lblCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDI.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDI.Location = New System.Drawing.Point(737, 31)
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
        Me.lblRegFiscaltxt.Location = New System.Drawing.Point(671, 31)
        Me.lblRegFiscaltxt.Name = "lblRegFiscaltxt"
        Me.lblRegFiscaltxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRegFiscaltxt.TabIndex = 89
        '
        'lblTurnotxt
        '
        Me.lblTurnotxt.AutoSize = True
        Me.lblTurnotxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnotxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurnotxt.Location = New System.Drawing.Point(1022, 31)
        Me.lblTurnotxt.Name = "lblTurnotxt"
        Me.lblTurnotxt.Size = New System.Drawing.Size(0, 15)
        Me.lblTurnotxt.TabIndex = 48
        Me.lblTurnotxt.Visible = False
        '
        'lblRegFiscal
        '
        Me.lblRegFiscal.AutoSize = True
        Me.lblRegFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegFiscal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRegFiscal.Location = New System.Drawing.Point(554, 31)
        Me.lblRegFiscal.Name = "lblRegFiscal"
        Me.lblRegFiscal.Size = New System.Drawing.Size(92, 15)
        Me.lblRegFiscal.TabIndex = 88
        Me.lblRegFiscal.Text = "Regimen fiscal:"
        '
        'lblCarreratxt
        '
        Me.lblCarreratxt.AutoSize = True
        Me.lblCarreratxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarreratxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCarreratxt.Location = New System.Drawing.Point(897, 30)
        Me.lblCarreratxt.Name = "lblCarreratxt"
        Me.lblCarreratxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCarreratxt.TabIndex = 47
        Me.lblCarreratxt.Visible = False
        '
        'lblCPtxt
        '
        Me.lblCPtxt.AutoSize = True
        Me.lblCPtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCPtxt.Location = New System.Drawing.Point(489, 31)
        Me.lblCPtxt.Name = "lblCPtxt"
        Me.lblCPtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCPtxt.TabIndex = 87
        '
        'lblRFCtxt
        '
        Me.lblRFCtxt.AutoSize = True
        Me.lblRFCtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFCtxt.Location = New System.Drawing.Point(51, 31)
        Me.lblRFCtxt.Name = "lblRFCtxt"
        Me.lblRFCtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRFCtxt.TabIndex = 46
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCP.Location = New System.Drawing.Point(455, 31)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(26, 15)
        Me.lblCP.TabIndex = 86
        Me.lblCP.Text = "CP:"
        '
        'lblEmailtxt
        '
        Me.lblEmailtxt.AutoSize = True
        Me.lblEmailtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmailtxt.Location = New System.Drawing.Point(503, 7)
        Me.lblEmailtxt.Name = "lblEmailtxt"
        Me.lblEmailtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblEmailtxt.TabIndex = 45
        '
        'lblNombretxt
        '
        Me.lblNombretxt.AutoSize = True
        Me.lblNombretxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombretxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombretxt.Location = New System.Drawing.Point(214, 8)
        Me.lblNombretxt.Name = "lblNombretxt"
        Me.lblNombretxt.Size = New System.Drawing.Size(0, 15)
        Me.lblNombretxt.TabIndex = 44
        '
        'lblMatriculatxt
        '
        Me.lblMatriculatxt.AutoSize = True
        Me.lblMatriculatxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatriculatxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatriculatxt.Location = New System.Drawing.Point(79, 8)
        Me.lblMatriculatxt.Name = "lblMatriculatxt"
        Me.lblMatriculatxt.Size = New System.Drawing.Size(0, 15)
        Me.lblMatriculatxt.TabIndex = 43
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFC.Location = New System.Drawing.Point(14, 31)
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
        Me.lblMatriculaDato.Location = New System.Drawing.Point(12, 7)
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
        Me.lblTurno.Location = New System.Drawing.Point(981, 30)
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
        Me.lblCarrera.Location = New System.Drawing.Point(846, 30)
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
        Me.lblEmail.Location = New System.Drawing.Point(455, 7)
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
        Me.lblNombre.Location = New System.Drawing.Point(155, 8)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblNombre.TabIndex = 37
        Me.lblNombre.Text = "Nombre: "
        '
        'panelGridNota
        '
        Me.panelGridNota.Controls.Add(Me.btnEliminar)
        Me.panelGridNota.Controls.Add(Me.Label1)
        Me.panelGridNota.Controls.Add(Me.lblTotalNota)
        Me.panelGridNota.Controls.Add(Me.GBNota)
        Me.panelGridNota.Controls.Add(Me.btnLimpiar)
        Me.panelGridNota.Controls.Add(Me.btnSalir)
        Me.panelGridNota.Controls.Add(Me.btnGuardar)
        Me.panelGridNota.Controls.Add(Me.GridNota)
        Me.panelGridNota.Location = New System.Drawing.Point(6, 188)
        Me.panelGridNota.Name = "panelGridNota"
        Me.panelGridNota.Size = New System.Drawing.Size(1103, 427)
        Me.panelGridNota.TabIndex = 18
        Me.panelGridNota.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.trash_can_30px
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnEliminar.Location = New System.Drawing.Point(458, 108)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(44, 36)
        Me.btnEliminar.TabIndex = 85
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(735, 298)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 29)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Total: $"
        '
        'lblTotalNota
        '
        Me.lblTotalNota.AutoSize = True
        Me.lblTotalNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNota.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTotalNota.Location = New System.Drawing.Point(831, 298)
        Me.lblTotalNota.Name = "lblTotalNota"
        Me.lblTotalNota.Size = New System.Drawing.Size(0, 29)
        Me.lblTotalNota.TabIndex = 83
        '
        'GBNota
        '
        Me.GBNota.Controls.Add(Me.chb100)
        Me.GBNota.Controls.Add(Me.NUPorcentaje)
        Me.GBNota.Controls.Add(Me.lblPeso)
        Me.GBNota.Controls.Add(Me.lblTotal)
        Me.GBNota.Controls.Add(Me.btnAgregar)
        Me.GBNota.Controls.Add(Me.Label5)
        Me.GBNota.Controls.Add(Me.Label4)
        Me.GBNota.Controls.Add(Me.txtMonto)
        Me.GBNota.Controls.Add(Me.Label3)
        Me.GBNota.Controls.Add(Me.lblTipoNota)
        Me.GBNota.Controls.Add(Me.cbConcepto)
        Me.GBNota.Controls.Add(Me.cbTipoNota)
        Me.GBNota.Controls.Add(Me.lblConcepto)
        Me.GBNota.ForeColor = System.Drawing.SystemColors.Control
        Me.GBNota.Location = New System.Drawing.Point(6, 6)
        Me.GBNota.Name = "GBNota"
        Me.GBNota.Size = New System.Drawing.Size(446, 421)
        Me.GBNota.TabIndex = 82
        Me.GBNota.TabStop = False
        Me.GBNota.Text = "Datos nota de credito"
        '
        'chb100
        '
        Me.chb100.AutoSize = True
        Me.chb100.Location = New System.Drawing.Point(181, 270)
        Me.chb100.Name = "chb100"
        Me.chb100.Size = New System.Drawing.Size(52, 17)
        Me.chb100.TabIndex = 91
        Me.chb100.Text = "100%"
        Me.chb100.UseVisualStyleBackColor = True
        '
        'NUPorcentaje
        '
        Me.NUPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUPorcentaje.Location = New System.Drawing.Point(80, 267)
        Me.NUPorcentaje.Name = "NUPorcentaje"
        Me.NUPorcentaje.Size = New System.Drawing.Size(65, 22)
        Me.NUPorcentaje.TabIndex = 90
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPeso.Location = New System.Drawing.Point(6, 162)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(26, 29)
        Me.lblPeso.TabIndex = 89
        Me.lblPeso.Text = "$"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Location = New System.Drawing.Point(26, 162)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 29)
        Me.lblTotal.TabIndex = 88
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.Add_40px
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAgregar.Location = New System.Drawing.Point(176, 356)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 48)
        Me.btnAgregar.TabIndex = 87
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(149, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 16)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(6, 269)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Porcentaje:"
        '
        'txtMonto
        '
        Me.txtMonto.Enabled = False
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(80, 235)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(89, 22)
        Me.txtMonto.TabIndex = 83
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(5, 238)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Monto:"
        '
        'lblTipoNota
        '
        Me.lblTipoNota.AutoSize = True
        Me.lblTipoNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoNota.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoNota.Location = New System.Drawing.Point(3, 30)
        Me.lblTipoNota.Name = "lblTipoNota"
        Me.lblTipoNota.Size = New System.Drawing.Size(150, 16)
        Me.lblTipoNota.TabIndex = 78
        Me.lblTipoNota.Text = "Tipo de nota de credito:"
        '
        'cbConcepto
        '
        Me.cbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbConcepto.FormattingEnabled = True
        Me.cbConcepto.Location = New System.Drawing.Point(6, 102)
        Me.cbConcepto.Name = "cbConcepto"
        Me.cbConcepto.Size = New System.Drawing.Size(432, 21)
        Me.cbConcepto.TabIndex = 81
        '
        'cbTipoNota
        '
        Me.cbTipoNota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoNota.FormattingEnabled = True
        Me.cbTipoNota.Location = New System.Drawing.Point(7, 49)
        Me.cbTipoNota.Name = "cbTipoNota"
        Me.cbTipoNota.Size = New System.Drawing.Size(431, 21)
        Me.cbTipoNota.TabIndex = 79
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConcepto.ForeColor = System.Drawing.SystemColors.Control
        Me.lblConcepto.Location = New System.Drawing.Point(3, 83)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(69, 16)
        Me.lblConcepto.TabIndex = 80
        Me.lblConcepto.Text = "Concepto:"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(557, 359)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 48)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(931, 359)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 48)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.Location = New System.Drawing.Point(753, 359)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 48)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'GridNota
        '
        Me.GridNota.AllowUserToAddRows = False
        Me.GridNota.AllowUserToDeleteRows = False
        Me.GridNota.AllowUserToResizeColumns = False
        Me.GridNota.AllowUserToResizeRows = False
        Me.GridNota.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridNota.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridNota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridNota.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Descripcion, Me.Importe, Me.IVA, Me.TipoNota, Me.FolioFactura, Me.Porcentaje, Me.CostoOriginal})
        Me.GridNota.Location = New System.Drawing.Point(508, 11)
        Me.GridNota.Name = "GridNota"
        Me.GridNota.Size = New System.Drawing.Size(586, 263)
        Me.GridNota.TabIndex = 0
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.FillWeight = 99.49239!
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        '
        'Importe
        '
        Me.Importe.FillWeight = 40.0!
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        '
        'IVA
        '
        Me.IVA.FillWeight = 40.0!
        Me.IVA.HeaderText = "IVA"
        Me.IVA.Name = "IVA"
        '
        'TipoNota
        '
        Me.TipoNota.FillWeight = 30.0!
        Me.TipoNota.HeaderText = "Tipo de nota"
        Me.TipoNota.Name = "TipoNota"
        '
        'FolioFactura
        '
        Me.FolioFactura.HeaderText = "FolioFactura"
        Me.FolioFactura.Name = "FolioFactura"
        Me.FolioFactura.Visible = False
        '
        'Porcentaje
        '
        Me.Porcentaje.HeaderText = "Porcentaje"
        Me.Porcentaje.Name = "Porcentaje"
        Me.Porcentaje.Visible = False
        '
        'CostoOriginal
        '
        Me.CostoOriginal.HeaderText = "CostoOriginal"
        Me.CostoOriginal.Name = "CostoOriginal"
        Me.CostoOriginal.Visible = False
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDireccion.Location = New System.Drawing.Point(238, 31)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(0, 15)
        Me.lblDireccion.TabIndex = 101
        '
        'lblDirecciontxt
        '
        Me.lblDirecciontxt.AutoSize = True
        Me.lblDirecciontxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirecciontxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDirecciontxt.Location = New System.Drawing.Point(155, 31)
        Me.lblDirecciontxt.Name = "lblDirecciontxt"
        Me.lblDirecciontxt.Size = New System.Drawing.Size(62, 15)
        Me.lblDirecciontxt.TabIndex = 100
        Me.lblDirecciontxt.Text = "Direccion:"
        '
        'NotasDeCreditoEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1117, 627)
        Me.Controls.Add(Me.panelGridNota)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.panelBusqueda)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NotasDeCreditoEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NotasDeCreditoEDC"
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.panelGridNota.ResumeLayout(False)
        Me.panelGridNota.PerformLayout()
        Me.GBNota.ResumeLayout(False)
        Me.GBNota.PerformLayout()
        CType(Me.NUPorcentaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridNota, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents panelGridNota As Panel
    Friend WithEvents GridNota As DataGridView
    Friend WithEvents lblTipoNota As Label
    Friend WithEvents cbTipoNota As ComboBox
    Friend WithEvents lblConcepto As Label
    Friend WithEvents cbConcepto As ComboBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents GBNota As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents lblPeso As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents NUPorcentaje As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTotalNota As Label
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
    Friend WithEvents btnEliminar As Button
    Friend WithEvents chb100 As CheckBox
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents IVA As DataGridViewTextBoxColumn
    Friend WithEvents TipoNota As DataGridViewTextBoxColumn
    Friend WithEvents FolioFactura As DataGridViewTextBoxColumn
    Friend WithEvents Porcentaje As DataGridViewTextBoxColumn
    Friend WithEvents CostoOriginal As DataGridViewTextBoxColumn
    Friend WithEvents lblRegFiscaltxt As Label
    Friend WithEvents lblRegFiscal As Label
    Friend WithEvents lblCPtxt As Label
    Friend WithEvents lblCP As Label
    Friend WithEvents lblCFDItxt As Label
    Friend WithEvents lblCFDI As Label
    Friend WithEvents lblDireccion As Label
    Friend WithEvents lblDirecciontxt As Label
End Class
