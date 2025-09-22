<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnviarCorreosConstanciasCongresosEDC
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.btnEnviarCorreos = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GridAlumnos = New System.Windows.Forms.DataGridView()
        Me.cbCongreso = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.GridAlumnos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(0, -2)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(801, 62)
        Me.lblNombreVentana.TabIndex = 16
        Me.lblNombreVentana.Text = "Envio de constancias a asistentes de congresos"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEnviarCorreos
        '
        Me.btnEnviarCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviarCorreos.Location = New System.Drawing.Point(652, 561)
        Me.btnEnviarCorreos.Name = "btnEnviarCorreos"
        Me.btnEnviarCorreos.Size = New System.Drawing.Size(136, 46)
        Me.btnEnviarCorreos.TabIndex = 57
        Me.btnEnviarCorreos.Text = "Enviar correos"
        Me.btnEnviarCorreos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(12, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(234, 16)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Asistentes que asistieron al congreso:"
        '
        'GridAlumnos
        '
        Me.GridAlumnos.AllowUserToAddRows = False
        Me.GridAlumnos.AllowUserToDeleteRows = False
        Me.GridAlumnos.AllowUserToResizeColumns = False
        Me.GridAlumnos.AllowUserToResizeRows = False
        Me.GridAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridAlumnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAlumnos.Location = New System.Drawing.Point(15, 168)
        Me.GridAlumnos.Name = "GridAlumnos"
        Me.GridAlumnos.Size = New System.Drawing.Size(773, 368)
        Me.GridAlumnos.TabIndex = 55
        '
        'cbCongreso
        '
        Me.cbCongreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCongreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCongreso.FormattingEnabled = True
        Me.cbCongreso.Location = New System.Drawing.Point(15, 100)
        Me.cbCongreso.Name = "cbCongreso"
        Me.cbCongreso.Size = New System.Drawing.Size(773, 24)
        Me.cbCongreso.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Congreso:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(328, 561)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "taller"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(447, 561)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 59
        Me.Button2.Text = "general"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'EnviarCorreosConstanciasCongresosEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(800, 631)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnEnviarCorreos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GridAlumnos)
        Me.Controls.Add(Me.cbCongreso)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "EnviarCorreosConstanciasCongresosEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EnviarCorreosConstanciasCongresosEDC"
        CType(Me.GridAlumnos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents btnEnviarCorreos As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GridAlumnos As DataGridView
    Friend WithEvents cbCongreso As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
