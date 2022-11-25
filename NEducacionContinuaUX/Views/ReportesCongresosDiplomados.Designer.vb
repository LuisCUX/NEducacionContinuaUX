<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportesCongresosDiplomados
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
        Me.tabAsistentes = New System.Windows.Forms.TabPage()
        Me.cbCongresos = New System.Windows.Forms.ComboBox()
        Me.btnImprimirReporteAsistentes = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabReportes = New System.Windows.Forms.TabControl()
        Me.tabAsistentes.SuspendLayout()
        Me.tabReportes.SuspendLayout()
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
        Me.lblNombreVentana.TabIndex = 13
        Me.lblNombreVentana.Text = "Reportes"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabAsistentes
        '
        Me.tabAsistentes.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabAsistentes.Controls.Add(Me.cbCongresos)
        Me.tabAsistentes.Controls.Add(Me.btnImprimirReporteAsistentes)
        Me.tabAsistentes.Controls.Add(Me.Label1)
        Me.tabAsistentes.Location = New System.Drawing.Point(4, 22)
        Me.tabAsistentes.Name = "tabAsistentes"
        Me.tabAsistentes.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAsistentes.Size = New System.Drawing.Size(832, 500)
        Me.tabAsistentes.TabIndex = 0
        Me.tabAsistentes.Text = "Reporte asistentes congresos/diplomados"
        '
        'cbCongresos
        '
        Me.cbCongresos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCongresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCongresos.FormattingEnabled = True
        Me.cbCongresos.Location = New System.Drawing.Point(106, 36)
        Me.cbCongresos.Name = "cbCongresos"
        Me.cbCongresos.Size = New System.Drawing.Size(668, 24)
        Me.cbCongresos.TabIndex = 2
        '
        'btnImprimirReporteAsistentes
        '
        Me.btnImprimirReporteAsistentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirReporteAsistentes.Location = New System.Drawing.Point(691, 453)
        Me.btnImprimirReporteAsistentes.Name = "btnImprimirReporteAsistentes"
        Me.btnImprimirReporteAsistentes.Size = New System.Drawing.Size(135, 41)
        Me.btnImprimirReporteAsistentes.TabIndex = 1
        Me.btnImprimirReporteAsistentes.Text = "Generar reporte"
        Me.btnImprimirReporteAsistentes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(23, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Congresos:"
        '
        'tabReportes
        '
        Me.tabReportes.Controls.Add(Me.tabAsistentes)
        Me.tabReportes.Location = New System.Drawing.Point(6, 81)
        Me.tabReportes.Name = "tabReportes"
        Me.tabReportes.SelectedIndex = 0
        Me.tabReportes.Size = New System.Drawing.Size(840, 526)
        Me.tabReportes.TabIndex = 14
        '
        'ReportesCongresosDiplomados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(858, 619)
        Me.Controls.Add(Me.tabReportes)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "ReportesCongresosDiplomados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReportesCongresosDiplomados"
        Me.tabAsistentes.ResumeLayout(False)
        Me.tabAsistentes.PerformLayout()
        Me.tabReportes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents tabAsistentes As TabPage
    Friend WithEvents tabReportes As TabControl
    Friend WithEvents Label1 As Label
    Friend WithEvents btnImprimirReporteAsistentes As Button
    Friend WithEvents cbCongresos As ComboBox
End Class
