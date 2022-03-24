<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModalNotasCreditoEDC
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
        Me.GridConceptos = New System.Windows.Forms.DataGridView()
        Me.cbNotasCredito = New System.Windows.Forms.ComboBox()
        Me.lblNotaCredito = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GridConceptos.Location = New System.Drawing.Point(0, 31)
        Me.GridConceptos.Name = "GridConceptos"
        Me.GridConceptos.Size = New System.Drawing.Size(552, 253)
        Me.GridConceptos.TabIndex = 0
        '
        'cbNotasCredito
        '
        Me.cbNotasCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNotasCredito.FormattingEnabled = True
        Me.cbNotasCredito.Location = New System.Drawing.Point(98, 4)
        Me.cbNotasCredito.Name = "cbNotasCredito"
        Me.cbNotasCredito.Size = New System.Drawing.Size(143, 21)
        Me.cbNotasCredito.TabIndex = 1
        '
        'lblNotaCredito
        '
        Me.lblNotaCredito.AutoSize = True
        Me.lblNotaCredito.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNotaCredito.Location = New System.Drawing.Point(9, 8)
        Me.lblNotaCredito.Name = "lblNotaCredito"
        Me.lblNotaCredito.Size = New System.Drawing.Size(83, 13)
        Me.lblNotaCredito.TabIndex = 2
        Me.lblNotaCredito.Text = "Nota de crédito:"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTotal.Location = New System.Drawing.Point(12, 292)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(61, 20)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "Total: $"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCantidad.Location = New System.Drawing.Point(68, 292)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(0, 20)
        Me.lblCantidad.TabIndex = 4
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(465, 290)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 5
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'ModalNotasCreditoEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(552, 319)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblNotaCredito)
        Me.Controls.Add(Me.cbNotasCredito)
        Me.Controls.Add(Me.GridConceptos)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ModalNotasCreditoEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ModalNotasCreditoEDC"
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridConceptos As DataGridView
    Friend WithEvents cbNotasCredito As ComboBox
    Friend WithEvents lblNotaCredito As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblCantidad As Label
    Friend WithEvents btnAgregar As Button
End Class
