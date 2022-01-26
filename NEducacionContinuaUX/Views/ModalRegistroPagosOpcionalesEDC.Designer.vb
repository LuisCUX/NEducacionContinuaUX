<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModalRegistroPagosOpcionalesEDC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModalRegistroPagosOpcionalesEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.lblconceptopara = New System.Windows.Forms.Label()
        Me.cbConceptoPara = New System.Windows.Forms.ComboBox()
        Me.lblTipoPago = New System.Windows.Forms.Label()
        Me.cbTipoPago = New System.Windows.Forms.ComboBox()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblValorUnitario = New System.Windows.Forms.Label()
        Me.txtValorUnitario = New System.Windows.Forms.TextBox()
        Me.lblValorUnitarioSinIVA = New System.Windows.Forms.Label()
        Me.txtValorUnitarioSinIVA = New System.Windows.Forms.TextBox()
        Me.chbConsideraIVA = New System.Windows.Forms.CheckBox()
        Me.cbTipoConcepto = New System.Windows.Forms.ComboBox()
        Me.lblTipoConcepto = New System.Windows.Forms.Label()
        Me.cbDivision = New System.Windows.Forms.ComboBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.cbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.cbClase = New System.Windows.Forms.ComboBox()
        Me.lblClase = New System.Windows.Forms.Label()
        Me.cbProdServ = New System.Windows.Forms.ComboBox()
        Me.lblProdServ = New System.Windows.Forms.Label()
        Me.cbUnidad = New System.Windows.Forms.ComboBox()
        Me.lblUnidad = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblNivel = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.cbNivel = New System.Windows.Forms.ComboBox()
        Me.cbTurno = New System.Windows.Forms.ComboBox()
        Me.chbIncluyeIVA = New System.Windows.Forms.CheckBox()
        Me.chbExentaIVA = New System.Windows.Forms.CheckBox()
        Me.lblBuscarPS = New System.Windows.Forms.Label()
        Me.txtClavePS = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(681, 69)
        Me.lblNombreVentana.TabIndex = 11
        Me.lblNombreVentana.Text = "Registro de pagos opcionales"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblconceptopara
        '
        Me.lblconceptopara.AutoSize = True
        Me.lblconceptopara.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconceptopara.ForeColor = System.Drawing.SystemColors.Control
        Me.lblconceptopara.Location = New System.Drawing.Point(13, 88)
        Me.lblconceptopara.Name = "lblconceptopara"
        Me.lblconceptopara.Size = New System.Drawing.Size(100, 16)
        Me.lblconceptopara.TabIndex = 12
        Me.lblconceptopara.Text = "Concepto para:"
        '
        'cbConceptoPara
        '
        Me.cbConceptoPara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbConceptoPara.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbConceptoPara.FormattingEnabled = True
        Me.cbConceptoPara.Location = New System.Drawing.Point(180, 85)
        Me.cbConceptoPara.Name = "cbConceptoPara"
        Me.cbConceptoPara.Size = New System.Drawing.Size(128, 23)
        Me.cbConceptoPara.TabIndex = 13
        '
        'lblTipoPago
        '
        Me.lblTipoPago.AutoSize = True
        Me.lblTipoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPago.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoPago.Location = New System.Drawing.Point(13, 116)
        Me.lblTipoPago.Name = "lblTipoPago"
        Me.lblTipoPago.Size = New System.Drawing.Size(148, 16)
        Me.lblTipoPago.TabIndex = 14
        Me.lblTipoPago.Text = "Tipo de pago opcional:"
        '
        'cbTipoPago
        '
        Me.cbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoPago.Enabled = False
        Me.cbTipoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoPago.FormattingEnabled = True
        Me.cbTipoPago.Location = New System.Drawing.Point(180, 113)
        Me.cbTipoPago.Name = "cbTipoPago"
        Me.cbTipoPago.Size = New System.Drawing.Size(490, 23)
        Me.cbTipoPago.TabIndex = 15
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConcepto.ForeColor = System.Drawing.SystemColors.Control
        Me.lblConcepto.Location = New System.Drawing.Point(13, 145)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(141, 16)
        Me.lblConcepto.TabIndex = 16
        Me.lblConcepto.Text = "Nombre del concepto:"
        '
        'txtConcepto
        '
        Me.txtConcepto.Enabled = False
        Me.txtConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConcepto.Location = New System.Drawing.Point(180, 142)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(425, 56)
        Me.txtConcepto.TabIndex = 17
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(180, 204)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(425, 56)
        Me.txtDescripcion.TabIndex = 19
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDescripcion.Location = New System.Drawing.Point(13, 207)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(83, 16)
        Me.lblDescripcion.TabIndex = 18
        Me.lblDescripcion.Text = "Descripción:"
        '
        'lblValorUnitario
        '
        Me.lblValorUnitario.AutoSize = True
        Me.lblValorUnitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorUnitario.ForeColor = System.Drawing.SystemColors.Control
        Me.lblValorUnitario.Location = New System.Drawing.Point(13, 300)
        Me.lblValorUnitario.Name = "lblValorUnitario"
        Me.lblValorUnitario.Size = New System.Drawing.Size(167, 16)
        Me.lblValorUnitario.TabIndex = 20
        Me.lblValorUnitario.Text = "Valor unitario neto con IVA:"
        '
        'txtValorUnitario
        '
        Me.txtValorUnitario.Enabled = False
        Me.txtValorUnitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorUnitario.Location = New System.Drawing.Point(317, 297)
        Me.txtValorUnitario.Name = "txtValorUnitario"
        Me.txtValorUnitario.Size = New System.Drawing.Size(113, 22)
        Me.txtValorUnitario.TabIndex = 21
        '
        'lblValorUnitarioSinIVA
        '
        Me.lblValorUnitarioSinIVA.AutoSize = True
        Me.lblValorUnitarioSinIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorUnitarioSinIVA.ForeColor = System.Drawing.SystemColors.Control
        Me.lblValorUnitarioSinIVA.Location = New System.Drawing.Point(13, 336)
        Me.lblValorUnitarioSinIVA.Name = "lblValorUnitarioSinIVA"
        Me.lblValorUnitarioSinIVA.Size = New System.Drawing.Size(133, 16)
        Me.lblValorUnitarioSinIVA.TabIndex = 22
        Me.lblValorUnitarioSinIVA.Text = "Valor unitario sin IVA:"
        '
        'txtValorUnitarioSinIVA
        '
        Me.txtValorUnitarioSinIVA.Enabled = False
        Me.txtValorUnitarioSinIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorUnitarioSinIVA.Location = New System.Drawing.Point(317, 333)
        Me.txtValorUnitarioSinIVA.Name = "txtValorUnitarioSinIVA"
        Me.txtValorUnitarioSinIVA.Size = New System.Drawing.Size(113, 22)
        Me.txtValorUnitarioSinIVA.TabIndex = 23
        '
        'chbConsideraIVA
        '
        Me.chbConsideraIVA.AutoSize = True
        Me.chbConsideraIVA.Enabled = False
        Me.chbConsideraIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbConsideraIVA.ForeColor = System.Drawing.SystemColors.Control
        Me.chbConsideraIVA.Location = New System.Drawing.Point(446, 299)
        Me.chbConsideraIVA.Name = "chbConsideraIVA"
        Me.chbConsideraIVA.Size = New System.Drawing.Size(105, 19)
        Me.chbConsideraIVA.TabIndex = 24
        Me.chbConsideraIVA.Text = "¿Absorbe IVA?"
        Me.chbConsideraIVA.UseVisualStyleBackColor = True
        '
        'cbTipoConcepto
        '
        Me.cbTipoConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoConcepto.Enabled = False
        Me.cbTipoConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoConcepto.FormattingEnabled = True
        Me.cbTipoConcepto.Location = New System.Drawing.Point(180, 446)
        Me.cbTipoConcepto.Name = "cbTipoConcepto"
        Me.cbTipoConcepto.Size = New System.Drawing.Size(490, 23)
        Me.cbTipoConcepto.TabIndex = 26
        '
        'lblTipoConcepto
        '
        Me.lblTipoConcepto.AutoSize = True
        Me.lblTipoConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoConcepto.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoConcepto.Location = New System.Drawing.Point(13, 449)
        Me.lblTipoConcepto.Name = "lblTipoConcepto"
        Me.lblTipoConcepto.Size = New System.Drawing.Size(117, 16)
        Me.lblTipoConcepto.TabIndex = 25
        Me.lblTipoConcepto.Text = "Tipo de concepto:"
        '
        'cbDivision
        '
        Me.cbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDivision.Enabled = False
        Me.cbDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDivision.FormattingEnabled = True
        Me.cbDivision.Location = New System.Drawing.Point(180, 474)
        Me.cbDivision.Name = "cbDivision"
        Me.cbDivision.Size = New System.Drawing.Size(490, 23)
        Me.cbDivision.TabIndex = 28
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDivision.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDivision.Location = New System.Drawing.Point(13, 477)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(56, 16)
        Me.lblDivision.TabIndex = 27
        Me.lblDivision.Text = "División"
        '
        'cbGrupo
        '
        Me.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGrupo.Enabled = False
        Me.cbGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGrupo.FormattingEnabled = True
        Me.cbGrupo.Location = New System.Drawing.Point(180, 502)
        Me.cbGrupo.Name = "cbGrupo"
        Me.cbGrupo.Size = New System.Drawing.Size(490, 23)
        Me.cbGrupo.TabIndex = 30
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrupo.ForeColor = System.Drawing.SystemColors.Control
        Me.lblGrupo.Location = New System.Drawing.Point(13, 505)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(48, 16)
        Me.lblGrupo.TabIndex = 29
        Me.lblGrupo.Text = "Grupo:"
        '
        'cbClase
        '
        Me.cbClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbClase.Enabled = False
        Me.cbClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbClase.FormattingEnabled = True
        Me.cbClase.Location = New System.Drawing.Point(180, 530)
        Me.cbClase.Name = "cbClase"
        Me.cbClase.Size = New System.Drawing.Size(490, 23)
        Me.cbClase.TabIndex = 32
        '
        'lblClase
        '
        Me.lblClase.AutoSize = True
        Me.lblClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClase.ForeColor = System.Drawing.SystemColors.Control
        Me.lblClase.Location = New System.Drawing.Point(13, 533)
        Me.lblClase.Name = "lblClase"
        Me.lblClase.Size = New System.Drawing.Size(46, 16)
        Me.lblClase.TabIndex = 31
        Me.lblClase.Text = "Clase:"
        '
        'cbProdServ
        '
        Me.cbProdServ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProdServ.Enabled = False
        Me.cbProdServ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProdServ.FormattingEnabled = True
        Me.cbProdServ.Location = New System.Drawing.Point(180, 558)
        Me.cbProdServ.Name = "cbProdServ"
        Me.cbProdServ.Size = New System.Drawing.Size(490, 23)
        Me.cbProdServ.TabIndex = 34
        '
        'lblProdServ
        '
        Me.lblProdServ.AutoSize = True
        Me.lblProdServ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProdServ.ForeColor = System.Drawing.SystemColors.Control
        Me.lblProdServ.Location = New System.Drawing.Point(13, 561)
        Me.lblProdServ.Name = "lblProdServ"
        Me.lblProdServ.Size = New System.Drawing.Size(125, 16)
        Me.lblProdServ.TabIndex = 33
        Me.lblProdServ.Text = "Producto y servicio:"
        '
        'cbUnidad
        '
        Me.cbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUnidad.Enabled = False
        Me.cbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnidad.FormattingEnabled = True
        Me.cbUnidad.Location = New System.Drawing.Point(180, 586)
        Me.cbUnidad.Name = "cbUnidad"
        Me.cbUnidad.Size = New System.Drawing.Size(490, 23)
        Me.cbUnidad.TabIndex = 36
        '
        'lblUnidad
        '
        Me.lblUnidad.AutoSize = True
        Me.lblUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidad.ForeColor = System.Drawing.SystemColors.Control
        Me.lblUnidad.Location = New System.Drawing.Point(13, 589)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(109, 16)
        Me.lblUnidad.TabIndex = 35
        Me.lblUnidad.Text = "Clave de unidad:"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Location = New System.Drawing.Point(194, 620)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 54)
        Me.btnGuardar.TabIndex = 37
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(461, 620)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 54)
        Me.btnSalir.TabIndex = 38
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblNivel
        '
        Me.lblNivel.AutoSize = True
        Me.lblNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNivel.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNivel.Location = New System.Drawing.Point(314, 88)
        Me.lblNivel.Name = "lblNivel"
        Me.lblNivel.Size = New System.Drawing.Size(42, 16)
        Me.lblNivel.TabIndex = 39
        Me.lblNivel.Text = "Nivel:"
        Me.lblNivel.Visible = False
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurno.Location = New System.Drawing.Point(490, 87)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(46, 16)
        Me.lblTurno.TabIndex = 40
        Me.lblTurno.Text = "Turno:"
        Me.lblTurno.Visible = False
        '
        'cbNivel
        '
        Me.cbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNivel.FormattingEnabled = True
        Me.cbNivel.Location = New System.Drawing.Point(359, 84)
        Me.cbNivel.Name = "cbNivel"
        Me.cbNivel.Size = New System.Drawing.Size(128, 23)
        Me.cbNivel.TabIndex = 41
        Me.cbNivel.Visible = False
        '
        'cbTurno
        '
        Me.cbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTurno.FormattingEnabled = True
        Me.cbTurno.Location = New System.Drawing.Point(542, 84)
        Me.cbTurno.Name = "cbTurno"
        Me.cbTurno.Size = New System.Drawing.Size(128, 23)
        Me.cbTurno.TabIndex = 42
        Me.cbTurno.Visible = False
        '
        'chbIncluyeIVA
        '
        Me.chbIncluyeIVA.AutoSize = True
        Me.chbIncluyeIVA.Enabled = False
        Me.chbIncluyeIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbIncluyeIVA.ForeColor = System.Drawing.SystemColors.Control
        Me.chbIncluyeIVA.Location = New System.Drawing.Point(446, 324)
        Me.chbIncluyeIVA.Name = "chbIncluyeIVA"
        Me.chbIncluyeIVA.Size = New System.Drawing.Size(109, 19)
        Me.chbIncluyeIVA.TabIndex = 43
        Me.chbIncluyeIVA.Text = "¿Aumenta IVA?"
        Me.chbIncluyeIVA.UseVisualStyleBackColor = True
        '
        'chbExentaIVA
        '
        Me.chbExentaIVA.AutoSize = True
        Me.chbExentaIVA.Checked = True
        Me.chbExentaIVA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbExentaIVA.Enabled = False
        Me.chbExentaIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbExentaIVA.ForeColor = System.Drawing.SystemColors.Control
        Me.chbExentaIVA.Location = New System.Drawing.Point(446, 349)
        Me.chbExentaIVA.Name = "chbExentaIVA"
        Me.chbExentaIVA.Size = New System.Drawing.Size(98, 19)
        Me.chbExentaIVA.TabIndex = 44
        Me.chbExentaIVA.Text = "¿Exenta IVA?"
        Me.chbExentaIVA.UseVisualStyleBackColor = True
        '
        'lblBuscarPS
        '
        Me.lblBuscarPS.AutoSize = True
        Me.lblBuscarPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscarPS.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBuscarPS.Location = New System.Drawing.Point(13, 406)
        Me.lblBuscarPS.Name = "lblBuscarPS"
        Me.lblBuscarPS.Size = New System.Drawing.Size(114, 16)
        Me.lblBuscarPS.TabIndex = 45
        Me.lblBuscarPS.Text = "Buscar clave P/S:"
        '
        'txtClavePS
        '
        Me.txtClavePS.Enabled = False
        Me.txtClavePS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClavePS.Location = New System.Drawing.Point(180, 403)
        Me.txtClavePS.Name = "txtClavePS"
        Me.txtClavePS.Size = New System.Drawing.Size(136, 21)
        Me.txtClavePS.TabIndex = 46
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(331, 620)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 54)
        Me.btnLimpiar.TabIndex = 47
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'ModalRegistroPagosOpcionalesEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(677, 701)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.txtClavePS)
        Me.Controls.Add(Me.lblBuscarPS)
        Me.Controls.Add(Me.chbExentaIVA)
        Me.Controls.Add(Me.chbIncluyeIVA)
        Me.Controls.Add(Me.cbTurno)
        Me.Controls.Add(Me.cbNivel)
        Me.Controls.Add(Me.lblTurno)
        Me.Controls.Add(Me.lblNivel)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cbUnidad)
        Me.Controls.Add(Me.lblUnidad)
        Me.Controls.Add(Me.cbProdServ)
        Me.Controls.Add(Me.lblProdServ)
        Me.Controls.Add(Me.cbClase)
        Me.Controls.Add(Me.lblClase)
        Me.Controls.Add(Me.cbGrupo)
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.cbDivision)
        Me.Controls.Add(Me.lblDivision)
        Me.Controls.Add(Me.cbTipoConcepto)
        Me.Controls.Add(Me.lblTipoConcepto)
        Me.Controls.Add(Me.chbConsideraIVA)
        Me.Controls.Add(Me.txtValorUnitarioSinIVA)
        Me.Controls.Add(Me.lblValorUnitarioSinIVA)
        Me.Controls.Add(Me.txtValorUnitario)
        Me.Controls.Add(Me.lblValorUnitario)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.lblConcepto)
        Me.Controls.Add(Me.cbTipoPago)
        Me.Controls.Add(Me.lblTipoPago)
        Me.Controls.Add(Me.cbConceptoPara)
        Me.Controls.Add(Me.lblconceptopara)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModalRegistroPagosOpcionalesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "s"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents lblconceptopara As Label
    Friend WithEvents cbConceptoPara As ComboBox
    Friend WithEvents lblTipoPago As Label
    Friend WithEvents cbTipoPago As ComboBox
    Friend WithEvents lblConcepto As Label
    Friend WithEvents txtConcepto As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents lblValorUnitario As Label
    Friend WithEvents txtValorUnitario As TextBox
    Friend WithEvents lblValorUnitarioSinIVA As Label
    Friend WithEvents txtValorUnitarioSinIVA As TextBox
    Friend WithEvents chbConsideraIVA As CheckBox
    Friend WithEvents cbTipoConcepto As ComboBox
    Friend WithEvents lblTipoConcepto As Label
    Friend WithEvents cbDivision As ComboBox
    Friend WithEvents lblDivision As Label
    Friend WithEvents cbGrupo As ComboBox
    Friend WithEvents lblGrupo As Label
    Friend WithEvents cbClase As ComboBox
    Friend WithEvents lblClase As Label
    Friend WithEvents cbProdServ As ComboBox
    Friend WithEvents lblProdServ As Label
    Friend WithEvents cbUnidad As ComboBox
    Friend WithEvents lblUnidad As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblNivel As Label
    Friend WithEvents lblTurno As Label
    Friend WithEvents cbNivel As ComboBox
    Friend WithEvents cbTurno As ComboBox
    Friend WithEvents chbIncluyeIVA As CheckBox
    Friend WithEvents chbExentaIVA As CheckBox
    Friend WithEvents lblBuscarPS As Label
    Friend WithEvents txtClavePS As TextBox
    Friend WithEvents btnLimpiar As Button
End Class
