<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportesEDC
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pageReporteIngresos = New System.Windows.Forms.TabPage()
        Me.dtPickerFin = New System.Windows.Forms.DateTimePicker()
        Me.dtPickerInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.cbCajero = New System.Windows.Forms.ComboBox()
        Me.lblCajero = New System.Windows.Forms.Label()
        Me.cbTIpoReporte = New System.Windows.Forms.ComboBox()
        Me.lblTipoReporte = New System.Windows.Forms.Label()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.pageReporteIngresos.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(0, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(861, 69)
        Me.lblNombreVentana.TabIndex = 12
        Me.lblNombreVentana.Text = "Reportes"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.pageReporteIngresos)
        Me.TabControl1.Location = New System.Drawing.Point(12, 82)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(834, 525)
        Me.TabControl1.TabIndex = 13
        '
        'pageReporteIngresos
        '
        Me.pageReporteIngresos.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.pageReporteIngresos.Controls.Add(Me.btnReporte)
        Me.pageReporteIngresos.Controls.Add(Me.dtPickerFin)
        Me.pageReporteIngresos.Controls.Add(Me.dtPickerInicio)
        Me.pageReporteIngresos.Controls.Add(Me.lblFechaInicio)
        Me.pageReporteIngresos.Controls.Add(Me.lblFechaFin)
        Me.pageReporteIngresos.Controls.Add(Me.cbCajero)
        Me.pageReporteIngresos.Controls.Add(Me.lblCajero)
        Me.pageReporteIngresos.Controls.Add(Me.cbTIpoReporte)
        Me.pageReporteIngresos.Controls.Add(Me.lblTipoReporte)
        Me.pageReporteIngresos.Location = New System.Drawing.Point(4, 22)
        Me.pageReporteIngresos.Name = "pageReporteIngresos"
        Me.pageReporteIngresos.Padding = New System.Windows.Forms.Padding(3)
        Me.pageReporteIngresos.Size = New System.Drawing.Size(826, 499)
        Me.pageReporteIngresos.TabIndex = 0
        Me.pageReporteIngresos.Text = "Reporte de ingresos"
        '
        'dtPickerFin
        '
        Me.dtPickerFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPickerFin.Location = New System.Drawing.Point(159, 153)
        Me.dtPickerFin.Name = "dtPickerFin"
        Me.dtPickerFin.Size = New System.Drawing.Size(82, 20)
        Me.dtPickerFin.TabIndex = 135
        '
        'dtPickerInicio
        '
        Me.dtPickerInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPickerInicio.Location = New System.Drawing.Point(159, 120)
        Me.dtPickerInicio.Name = "dtPickerInicio"
        Me.dtPickerInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtPickerInicio.TabIndex = 134
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFechaInicio.Location = New System.Drawing.Point(36, 124)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(83, 16)
        Me.lblFechaInicio.TabIndex = 98
        Me.lblFechaInicio.Text = "Fecha inicio:"
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFin.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFechaFin.Location = New System.Drawing.Point(36, 157)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(65, 16)
        Me.lblFechaFin.TabIndex = 97
        Me.lblFechaFin.Text = "Fecha fin:"
        '
        'cbCajero
        '
        Me.cbCajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCajero.Enabled = False
        Me.cbCajero.FormattingEnabled = True
        Me.cbCajero.Location = New System.Drawing.Point(159, 69)
        Me.cbCajero.Name = "cbCajero"
        Me.cbCajero.Size = New System.Drawing.Size(226, 21)
        Me.cbCajero.TabIndex = 96
        '
        'lblCajero
        '
        Me.lblCajero.AutoSize = True
        Me.lblCajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajero.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCajero.Location = New System.Drawing.Point(36, 69)
        Me.lblCajero.Name = "lblCajero"
        Me.lblCajero.Size = New System.Drawing.Size(51, 16)
        Me.lblCajero.TabIndex = 95
        Me.lblCajero.Text = "Cajero:"
        '
        'cbTIpoReporte
        '
        Me.cbTIpoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTIpoReporte.FormattingEnabled = True
        Me.cbTIpoReporte.Location = New System.Drawing.Point(159, 40)
        Me.cbTIpoReporte.Name = "cbTIpoReporte"
        Me.cbTIpoReporte.Size = New System.Drawing.Size(226, 21)
        Me.cbTIpoReporte.TabIndex = 94
        '
        'lblTipoReporte
        '
        Me.lblTipoReporte.AutoSize = True
        Me.lblTipoReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoReporte.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoReporte.Location = New System.Drawing.Point(36, 41)
        Me.lblTipoReporte.Name = "lblTipoReporte"
        Me.lblTipoReporte.Size = New System.Drawing.Size(104, 16)
        Me.lblTipoReporte.TabIndex = 93
        Me.lblTipoReporte.Text = "Tipo de reporte:"
        '
        'btnReporte
        '
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Location = New System.Drawing.Point(687, 441)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(118, 39)
        Me.btnReporte.TabIndex = 136
        Me.btnReporte.Text = "Generar reporte"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'ReportesEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(858, 619)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "ReportesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReportesEDC"
        Me.TabControl1.ResumeLayout(False)
        Me.pageReporteIngresos.ResumeLayout(False)
        Me.pageReporteIngresos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents pageReporteIngresos As TabPage
    Friend WithEvents cbCajero As ComboBox
    Friend WithEvents lblCajero As Label
    Friend WithEvents cbTIpoReporte As ComboBox
    Friend WithEvents lblTipoReporte As Label
    Friend WithEvents lblFechaInicio As Label
    Friend WithEvents lblFechaFin As Label
    Friend WithEvents dtPickerFin As DateTimePicker
    Friend WithEvents dtPickerInicio As DateTimePicker
    Friend WithEvents btnReporte As Button
End Class
