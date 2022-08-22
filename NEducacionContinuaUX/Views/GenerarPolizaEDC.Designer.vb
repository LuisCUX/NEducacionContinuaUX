<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarPolizaEDC
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
        Me.dtPickerFin = New System.Windows.Forms.DateTimePicker()
        Me.dtPickerInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnPol = New System.Windows.Forms.Button()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(559, 69)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Generar poliza .POL"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtPickerFin
        '
        Me.dtPickerFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPickerFin.Location = New System.Drawing.Point(378, 99)
        Me.dtPickerFin.Name = "dtPickerFin"
        Me.dtPickerFin.Size = New System.Drawing.Size(82, 20)
        Me.dtPickerFin.TabIndex = 139
        '
        'dtPickerInicio
        '
        Me.dtPickerInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPickerInicio.Location = New System.Drawing.Point(144, 99)
        Me.dtPickerInicio.Name = "dtPickerInicio"
        Me.dtPickerInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtPickerInicio.TabIndex = 138
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFechaInicio.Location = New System.Drawing.Point(25, 103)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(83, 16)
        Me.lblFechaInicio.TabIndex = 137
        Me.lblFechaInicio.Text = "Fecha inicio:"
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFin.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFechaFin.Location = New System.Drawing.Point(307, 103)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(65, 16)
        Me.lblFechaFin.TabIndex = 136
        Me.lblFechaFin.Text = "Fecha fin:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(25, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Numero de póliza:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(144, 140)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(82, 20)
        Me.TextBox1.TabIndex = 141
        '
        'btnPol
        '
        Me.btnPol.Image = Global.NEducacionContinuaUX.My.Resources.Resources.icons8_powerpoint_40
        Me.btnPol.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPol.Location = New System.Drawing.Point(440, 215)
        Me.btnPol.Name = "btnPol"
        Me.btnPol.Size = New System.Drawing.Size(89, 66)
        Me.btnPol.TabIndex = 143
        Me.btnPol.Text = "Generar .POL"
        Me.btnPol.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPol.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.NEducacionContinuaUX.My.Resources.Resources.icons8_analyze_40
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReporte.Location = New System.Drawing.Point(345, 215)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(89, 66)
        Me.btnReporte.TabIndex = 142
        Me.btnReporte.Text = "Generar reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'GenerarPolizaEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(551, 290)
        Me.Controls.Add(Me.btnPol)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtPickerFin)
        Me.Controls.Add(Me.dtPickerInicio)
        Me.Controls.Add(Me.lblFechaInicio)
        Me.Controls.Add(Me.lblFechaFin)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "GenerarPolizaEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GenerarPolizaEDC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents dtPickerFin As DateTimePicker
    Friend WithEvents dtPickerInicio As DateTimePicker
    Friend WithEvents lblFechaInicio As Label
    Friend WithEvents lblFechaFin As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnReporte As Button
    Friend WithEvents btnPol As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
