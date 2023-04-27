<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReimpresionFacturasEDC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReimpresionFacturasEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscarFolio = New System.Windows.Forms.Button()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblFolioBuscar = New System.Windows.Forms.Label()
        Me.btnBuscarMatricula = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblEmailCL = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblRFCCL = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNombreCL = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbFactura = New System.Windows.Forms.ComboBox()
        Me.lblFacturaCB = New System.Windows.Forms.Label()
        Me.panelFactura = New System.Windows.Forms.Panel()
        Me.GridConceptos = New System.Windows.Forms.DataGridView()
        Me.NombreConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnReenviar = New System.Windows.Forms.Button()
        Me.btnReimprimir = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.panelFactura.SuspendLayout()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, -1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1001, 69)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Herramientas de facturación"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbExterno
        '
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(9, 95)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(417, 21)
        Me.cbExterno.TabIndex = 75
        '
        'lblBusquedaNombre
        '
        Me.lblBusquedaNombre.AutoSize = True
        Me.lblBusquedaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBusquedaNombre.Location = New System.Drawing.Point(6, 76)
        Me.lblBusquedaNombre.Name = "lblBusquedaNombre"
        Me.lblBusquedaNombre.Size = New System.Drawing.Size(63, 16)
        Me.lblBusquedaNombre.TabIndex = 74
        Me.lblBusquedaNombre.Text = "Nombre: "
        '
        'txtMatricula
        '
        Me.txtMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula.Location = New System.Drawing.Point(61, 43)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(110, 22)
        Me.txtMatricula.TabIndex = 16
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula.Location = New System.Drawing.Point(6, 44)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(49, 18)
        Me.lblMatricula.TabIndex = 15
        Me.lblMatricula.Text = "Clave:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 86)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscarFolio)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFolio)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFolioBuscar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbExterno)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMatricula)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblBusquedaNombre)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMatricula)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscarMatricula)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblEmailCL)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblRFCCL)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblNombreCL)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Size = New System.Drawing.Size(973, 142)
        Me.SplitContainer1.SplitterDistance = 498
        Me.SplitContainer1.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(495, 25)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Busqueda de factura"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBuscarFolio
        '
        Me.btnBuscarFolio.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscarFolio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscarFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarFolio.Location = New System.Drawing.Point(397, 37)
        Me.btnBuscarFolio.Name = "btnBuscarFolio"
        Me.btnBuscarFolio.Size = New System.Drawing.Size(41, 34)
        Me.btnBuscarFolio.TabIndex = 20
        Me.btnBuscarFolio.UseVisualStyleBackColor = True
        '
        'txtFolio
        '
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.Location = New System.Drawing.Point(281, 43)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(110, 22)
        Me.txtFolio.TabIndex = 19
        '
        'lblFolioBuscar
        '
        Me.lblFolioBuscar.AutoSize = True
        Me.lblFolioBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioBuscar.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFolioBuscar.Location = New System.Drawing.Point(239, 44)
        Me.lblFolioBuscar.Name = "lblFolioBuscar"
        Me.lblFolioBuscar.Size = New System.Drawing.Size(45, 18)
        Me.lblFolioBuscar.TabIndex = 18
        Me.lblFolioBuscar.Text = "Folio:"
        '
        'btnBuscarMatricula
        '
        Me.btnBuscarMatricula.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscarMatricula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscarMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarMatricula.Location = New System.Drawing.Point(177, 37)
        Me.btnBuscarMatricula.Name = "btnBuscarMatricula"
        Me.btnBuscarMatricula.Size = New System.Drawing.Size(41, 34)
        Me.btnBuscarMatricula.TabIndex = 17
        Me.btnBuscarMatricula.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Maroon
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gold
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(471, 25)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Información del cliente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEmailCL
        '
        Me.lblEmailCL.AutoSize = True
        Me.lblEmailCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailCL.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmailCL.Location = New System.Drawing.Point(71, 93)
        Me.lblEmailCL.Name = "lblEmailCL"
        Me.lblEmailCL.Size = New System.Drawing.Size(0, 16)
        Me.lblEmailCL.TabIndex = 80
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(11, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "Email:"
        '
        'lblRFCCL
        '
        Me.lblRFCCL.AutoSize = True
        Me.lblRFCCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCCL.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFCCL.Location = New System.Drawing.Point(71, 62)
        Me.lblRFCCL.Name = "lblRFCCL"
        Me.lblRFCCL.Size = New System.Drawing.Size(0, 16)
        Me.lblRFCCL.TabIndex = 78
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(11, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 16)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "RFC:"
        '
        'lblNombreCL
        '
        Me.lblNombreCL.AutoSize = True
        Me.lblNombreCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCL.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombreCL.Location = New System.Drawing.Point(71, 34)
        Me.lblNombreCL.Name = "lblNombreCL"
        Me.lblNombreCL.Size = New System.Drawing.Size(0, 16)
        Me.lblNombreCL.TabIndex = 76
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(11, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Nombre: "
        '
        'cbFactura
        '
        Me.cbFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFactura.FormattingEnabled = True
        Me.cbFactura.Location = New System.Drawing.Point(9, 23)
        Me.cbFactura.Name = "cbFactura"
        Me.cbFactura.Size = New System.Drawing.Size(416, 21)
        Me.cbFactura.TabIndex = 77
        '
        'lblFacturaCB
        '
        Me.lblFacturaCB.AutoSize = True
        Me.lblFacturaCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturaCB.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFacturaCB.Location = New System.Drawing.Point(6, 4)
        Me.lblFacturaCB.Name = "lblFacturaCB"
        Me.lblFacturaCB.Size = New System.Drawing.Size(126, 16)
        Me.lblFacturaCB.TabIndex = 76
        Me.lblFacturaCB.Text = "Seleccionar factura:"
        '
        'panelFactura
        '
        Me.panelFactura.Controls.Add(Me.GridConceptos)
        Me.panelFactura.Controls.Add(Me.lblFacturaCB)
        Me.panelFactura.Controls.Add(Me.cbFactura)
        Me.panelFactura.Location = New System.Drawing.Point(12, 234)
        Me.panelFactura.Name = "panelFactura"
        Me.panelFactura.Size = New System.Drawing.Size(973, 369)
        Me.panelFactura.TabIndex = 17
        Me.panelFactura.Visible = False
        '
        'GridConceptos
        '
        Me.GridConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridConceptos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreConcepto, Me.Cantidad, Me.PrecioUnitario, Me.IVA, Me.Descuento, Me.Total})
        Me.GridConceptos.Location = New System.Drawing.Point(9, 50)
        Me.GridConceptos.Name = "GridConceptos"
        Me.GridConceptos.Size = New System.Drawing.Size(961, 316)
        Me.GridConceptos.TabIndex = 0
        '
        'NombreConcepto
        '
        Me.NombreConcepto.HeaderText = "Nombre del concepto"
        Me.NombreConcepto.Name = "NombreConcepto"
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.HeaderText = "Precio unitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        '
        'IVA
        '
        Me.IVA.HeaderText = "IVA"
        Me.IVA.Name = "IVA"
        '
        'Descuento
        '
        Me.Descuento.HeaderText = "Descuento"
        Me.Descuento.Name = "Descuento"
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(829, 609)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 71)
        Me.btnLimpiar.TabIndex = 21
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnReenviar
        '
        Me.btnReenviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnReenviar.Image = Global.NEducacionContinuaUX.My.Resources.Resources.send_40px
        Me.btnReenviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReenviar.Location = New System.Drawing.Point(748, 609)
        Me.btnReenviar.Name = "btnReenviar"
        Me.btnReenviar.Size = New System.Drawing.Size(75, 71)
        Me.btnReenviar.TabIndex = 20
        Me.btnReenviar.Text = "Reenviar correo"
        Me.btnReenviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReenviar.UseVisualStyleBackColor = True
        '
        'btnReimprimir
        '
        Me.btnReimprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnReimprimir.Image = Global.NEducacionContinuaUX.My.Resources.Resources.print_40px
        Me.btnReimprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReimprimir.Location = New System.Drawing.Point(667, 609)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(75, 71)
        Me.btnReimprimir.TabIndex = 19
        Me.btnReimprimir.Text = "Reimprimir"
        Me.btnReimprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimprimir.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(910, 609)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 71)
        Me.btnSalir.TabIndex = 18
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'ReimpresionFacturasEDC
        '
        Me.AcceptButton = Me.btnBuscarMatricula
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(997, 692)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnReenviar)
        Me.Controls.Add(Me.btnReimprimir)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.panelFactura)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReimpresionFacturasEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReimpresionFacturasEDC"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.panelFactura.ResumeLayout(False)
        Me.panelFactura.PerformLayout()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents btnBuscarMatricula As Button
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents lblMatricula As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lblFolioBuscar As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents btnBuscarFolio As Button
    Friend WithEvents lblFacturaCB As Label
    Friend WithEvents cbFactura As ComboBox
    Friend WithEvents panelFactura As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnReimprimir As Button
    Friend WithEvents btnReenviar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents GridConceptos As DataGridView
    Friend WithEvents NombreConcepto As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents IVA As DataGridViewTextBoxColumn
    Friend WithEvents Descuento As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents lblNombreCL As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblRFCCL As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblEmailCL As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
End Class
