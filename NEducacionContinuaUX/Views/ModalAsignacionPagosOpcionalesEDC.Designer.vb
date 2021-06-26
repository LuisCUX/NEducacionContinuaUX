<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModalAsignacionPagosOpcionalesEDC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModalAsignacionPagosOpcionalesEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.lblTipoPago = New System.Windows.Forms.Label()
        Me.cbTipoPago = New System.Windows.Forms.ComboBox()
        Me.lblValorUnitario = New System.Windows.Forms.Label()
        Me.txtValorUnitario = New System.Windows.Forms.TextBox()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.chbExentaIVA = New System.Windows.Forms.CheckBox()
        Me.chbIncluyeIVA = New System.Windows.Forms.CheckBox()
        Me.chbConsideraIVA = New System.Windows.Forms.CheckBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.cbPagosOpcionales = New System.Windows.Forms.ComboBox()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.NUCantidad = New System.Windows.Forms.NumericUpDown()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.chbActivo = New System.Windows.Forms.CheckBox()
        CType(Me.NUCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(676, 69)
        Me.lblNombreVentana.TabIndex = 12
        Me.lblNombreVentana.Text = "Asignación de pagos opcionales"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTipoPago
        '
        Me.lblTipoPago.AutoSize = True
        Me.lblTipoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPago.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoPago.Location = New System.Drawing.Point(12, 88)
        Me.lblTipoPago.Name = "lblTipoPago"
        Me.lblTipoPago.Size = New System.Drawing.Size(148, 16)
        Me.lblTipoPago.TabIndex = 15
        Me.lblTipoPago.Text = "Tipo de pago opcional:"
        '
        'cbTipoPago
        '
        Me.cbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoPago.FormattingEnabled = True
        Me.cbTipoPago.Location = New System.Drawing.Point(166, 85)
        Me.cbTipoPago.Name = "cbTipoPago"
        Me.cbTipoPago.Size = New System.Drawing.Size(490, 23)
        Me.cbTipoPago.TabIndex = 16
        '
        'lblValorUnitario
        '
        Me.lblValorUnitario.AutoSize = True
        Me.lblValorUnitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorUnitario.ForeColor = System.Drawing.SystemColors.Control
        Me.lblValorUnitario.Location = New System.Drawing.Point(12, 228)
        Me.lblValorUnitario.Name = "lblValorUnitario"
        Me.lblValorUnitario.Size = New System.Drawing.Size(89, 16)
        Me.lblValorUnitario.TabIndex = 19
        Me.lblValorUnitario.Text = "Valor unitario:"
        '
        'txtValorUnitario
        '
        Me.txtValorUnitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorUnitario.Location = New System.Drawing.Point(166, 225)
        Me.txtValorUnitario.Name = "txtValorUnitario"
        Me.txtValorUnitario.Size = New System.Drawing.Size(134, 22)
        Me.txtValorUnitario.TabIndex = 20
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCantidad.Location = New System.Drawing.Point(12, 162)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(65, 16)
        Me.lblCantidad.TabIndex = 17
        Me.lblCantidad.Text = "Cantidad:"
        '
        'chbExentaIVA
        '
        Me.chbExentaIVA.AutoSize = True
        Me.chbExentaIVA.Enabled = False
        Me.chbExentaIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbExentaIVA.ForeColor = System.Drawing.SystemColors.Control
        Me.chbExentaIVA.Location = New System.Drawing.Point(329, 252)
        Me.chbExentaIVA.Name = "chbExentaIVA"
        Me.chbExentaIVA.Size = New System.Drawing.Size(98, 19)
        Me.chbExentaIVA.TabIndex = 47
        Me.chbExentaIVA.Text = "¿Exenta IVA?"
        Me.chbExentaIVA.UseVisualStyleBackColor = True
        '
        'chbIncluyeIVA
        '
        Me.chbIncluyeIVA.AutoSize = True
        Me.chbIncluyeIVA.Enabled = False
        Me.chbIncluyeIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbIncluyeIVA.ForeColor = System.Drawing.SystemColors.Control
        Me.chbIncluyeIVA.Location = New System.Drawing.Point(329, 227)
        Me.chbIncluyeIVA.Name = "chbIncluyeIVA"
        Me.chbIncluyeIVA.Size = New System.Drawing.Size(109, 19)
        Me.chbIncluyeIVA.TabIndex = 46
        Me.chbIncluyeIVA.Text = "¿Aumenta IVA?"
        Me.chbIncluyeIVA.UseVisualStyleBackColor = True
        '
        'chbConsideraIVA
        '
        Me.chbConsideraIVA.AutoSize = True
        Me.chbConsideraIVA.Enabled = False
        Me.chbConsideraIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbConsideraIVA.ForeColor = System.Drawing.SystemColors.Control
        Me.chbConsideraIVA.Location = New System.Drawing.Point(329, 202)
        Me.chbConsideraIVA.Name = "chbConsideraIVA"
        Me.chbConsideraIVA.Size = New System.Drawing.Size(105, 19)
        Me.chbConsideraIVA.TabIndex = 45
        Me.chbConsideraIVA.Text = "¿Absorbe IVA?"
        Me.chbConsideraIVA.UseVisualStyleBackColor = True
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(166, 303)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(134, 22)
        Me.txtTotal.TabIndex = 49
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Location = New System.Drawing.Point(12, 306)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(42, 16)
        Me.lblTotal.TabIndex = 48
        Me.lblTotal.Text = "Total:"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.Location = New System.Drawing.Point(209, 395)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(76, 46)
        Me.btnGuardar.TabIndex = 50
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(404, 395)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(76, 46)
        Me.btnSalir.TabIndex = 51
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'cbPagosOpcionales
        '
        Me.cbPagosOpcionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPagosOpcionales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPagosOpcionales.FormattingEnabled = True
        Me.cbPagosOpcionales.Location = New System.Drawing.Point(166, 118)
        Me.cbPagosOpcionales.Name = "cbPagosOpcionales"
        Me.cbPagosOpcionales.Size = New System.Drawing.Size(490, 23)
        Me.cbPagosOpcionales.TabIndex = 53
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConcepto.ForeColor = System.Drawing.SystemColors.Control
        Me.lblConcepto.Location = New System.Drawing.Point(12, 121)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(69, 16)
        Me.lblConcepto.TabIndex = 52
        Me.lblConcepto.Text = "Concepto:"
        '
        'NUCantidad
        '
        Me.NUCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUCantidad.Location = New System.Drawing.Point(166, 158)
        Me.NUCantidad.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.NUCantidad.Name = "NUCantidad"
        Me.NUCantidad.Size = New System.Drawing.Size(91, 21)
        Me.NUCantidad.TabIndex = 54
        Me.NUCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivo.ForeColor = System.Drawing.SystemColors.Control
        Me.lblActivo.Location = New System.Drawing.Point(12, 348)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(48, 16)
        Me.lblActivo.TabIndex = 55
        Me.lblActivo.Text = "Activo:"
        Me.lblActivo.Visible = False
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbActivo.ForeColor = System.Drawing.SystemColors.Control
        Me.chbActivo.Location = New System.Drawing.Point(166, 348)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(57, 19)
        Me.chbActivo.TabIndex = 56
        Me.chbActivo.Text = "Activo"
        Me.chbActivo.UseVisualStyleBackColor = True
        Me.chbActivo.Visible = False
        '
        'ModalAsignacionPagosOpcionalesEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(670, 453)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.lblActivo)
        Me.Controls.Add(Me.NUCantidad)
        Me.Controls.Add(Me.cbPagosOpcionales)
        Me.Controls.Add(Me.lblConcepto)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.chbExentaIVA)
        Me.Controls.Add(Me.chbIncluyeIVA)
        Me.Controls.Add(Me.chbConsideraIVA)
        Me.Controls.Add(Me.txtValorUnitario)
        Me.Controls.Add(Me.lblValorUnitario)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.cbTipoPago)
        Me.Controls.Add(Me.lblTipoPago)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModalAsignacionPagosOpcionalesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ModalAsignacionPagosOpcionalesEDC"
        CType(Me.NUCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents lblTipoPago As Label
    Friend WithEvents cbTipoPago As ComboBox
    Friend WithEvents lblValorUnitario As Label
    Friend WithEvents txtValorUnitario As TextBox
    Friend WithEvents lblCantidad As Label
    Friend WithEvents chbExentaIVA As CheckBox
    Friend WithEvents chbIncluyeIVA As CheckBox
    Friend WithEvents chbConsideraIVA As CheckBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents cbPagosOpcionales As ComboBox
    Friend WithEvents lblConcepto As Label
    Friend WithEvents NUCantidad As NumericUpDown
    Friend WithEvents lblActivo As Label
    Friend WithEvents chbActivo As CheckBox
End Class
