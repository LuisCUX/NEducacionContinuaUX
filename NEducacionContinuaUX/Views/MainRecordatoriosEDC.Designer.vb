<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainRecordatoriosEDC
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
        Me.GridRecordatorios = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recordatorio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.GridRecordatorios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-1, -2)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(806, 55)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Recordatorios"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridRecordatorios
        '
        Me.GridRecordatorios.AllowUserToAddRows = False
        Me.GridRecordatorios.AllowUserToDeleteRows = False
        Me.GridRecordatorios.AllowUserToResizeColumns = False
        Me.GridRecordatorios.AllowUserToResizeRows = False
        Me.GridRecordatorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridRecordatorios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.GridRecordatorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridRecordatorios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Recordatorio, Me.Fecha, Me.Usuario})
        Me.GridRecordatorios.Location = New System.Drawing.Point(12, 104)
        Me.GridRecordatorios.Name = "GridRecordatorios"
        Me.GridRecordatorios.ReadOnly = True
        Me.GridRecordatorios.Size = New System.Drawing.Size(776, 342)
        Me.GridRecordatorios.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(649, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 37)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Nuevo recordatorio"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Recordatorio
        '
        Me.Recordatorio.FillWeight = 175.8917!
        Me.Recordatorio.HeaderText = "Recordatorio"
        Me.Recordatorio.Name = "Recordatorio"
        Me.Recordatorio.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.FillWeight = 63.19462!
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Usuario
        '
        Me.Usuario.FillWeight = 60.9137!
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        '
        'MainRecordatoriosEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(800, 458)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GridRecordatorios)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "MainRecordatoriosEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainRecordatoriosEDC"
        CType(Me.GridRecordatorios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents GridRecordatorios As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Recordatorio As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Usuario As DataGridViewTextBoxColumn
End Class
