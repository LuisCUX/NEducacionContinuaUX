<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainRegistroPagosOpcionalesEDC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainRegistroPagosOpcionalesEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.GridPagosOpcionales = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GridPagosOpcionales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, -1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(803, 69)
        Me.lblNombreVentana.TabIndex = 10
        Me.lblNombreVentana.Text = "Pagos opcionales"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridPagosOpcionales
        '
        Me.GridPagosOpcionales.AllowUserToAddRows = False
        Me.GridPagosOpcionales.AllowUserToDeleteRows = False
        Me.GridPagosOpcionales.AllowUserToResizeColumns = False
        Me.GridPagosOpcionales.AllowUserToResizeRows = False
        Me.GridPagosOpcionales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridPagosOpcionales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridPagosOpcionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPagosOpcionales.Location = New System.Drawing.Point(12, 103)
        Me.GridPagosOpcionales.Name = "GridPagosOpcionales"
        Me.GridPagosOpcionales.ReadOnly = True
        Me.GridPagosOpcionales.Size = New System.Drawing.Size(776, 426)
        Me.GridPagosOpcionales.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(9, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(329, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Para modificar dar click en la clave del concepto:"
        '
        'MainRegistroPagosOpcionalesEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(800, 536)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridPagosOpcionales)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainRegistroPagosOpcionalesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagos Opcionales"
        CType(Me.GridPagosOpcionales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents GridPagosOpcionales As DataGridView
    Friend WithEvents Label1 As Label
End Class
