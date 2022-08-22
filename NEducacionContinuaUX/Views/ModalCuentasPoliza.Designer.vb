<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModalCuentasPoliza
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridConceptos = New System.Windows.Forms.DataGridView()
        Me.IDPagoOpcional = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Conceptos sin cuenta asignada:"
        '
        'GridConceptos
        '
        Me.GridConceptos.AllowUserToAddRows = False
        Me.GridConceptos.AllowUserToDeleteRows = False
        Me.GridConceptos.AllowUserToResizeColumns = False
        Me.GridConceptos.AllowUserToResizeRows = False
        Me.GridConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridConceptos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDPagoOpcional, Me.NombreConcepto, Me.Cuenta})
        Me.GridConceptos.Location = New System.Drawing.Point(12, 28)
        Me.GridConceptos.Name = "GridConceptos"
        Me.GridConceptos.Size = New System.Drawing.Size(776, 401)
        Me.GridConceptos.TabIndex = 1
        '
        'IDPagoOpcional
        '
        Me.IDPagoOpcional.HeaderText = "ID"
        Me.IDPagoOpcional.Name = "IDPagoOpcional"
        Me.IDPagoOpcional.Visible = False
        '
        'NombreConcepto
        '
        Me.NombreConcepto.HeaderText = "Nombre concepto"
        Me.NombreConcepto.Name = "NombreConcepto"
        Me.NombreConcepto.ReadOnly = True
        '
        'Cuenta
        '
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.Location = New System.Drawing.Point(666, 436)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(122, 36)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "Guardar cambios"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSalir.Location = New System.Drawing.Point(538, 436)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(122, 36)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'ModalCuentasPoliza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(800, 484)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GridConceptos)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "ModalCuentasPoliza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ModalCuentasPoliza"
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GridConceptos As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents IDPagoOpcional As DataGridViewTextBoxColumn
    Friend WithEvents NombreConcepto As DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents btnSalir As Button
End Class
