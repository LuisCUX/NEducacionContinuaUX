<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModalRecordatoriosEDC
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
        Me.txtRecordatorio = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.chbActivo = New System.Windows.Forms.CheckBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.chbNuevo = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-3, -1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(708, 46)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Recordatorios"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRecordatorio
        '
        Me.txtRecordatorio.Location = New System.Drawing.Point(12, 80)
        Me.txtRecordatorio.Multiline = True
        Me.txtRecordatorio.Name = "txtRecordatorio"
        Me.txtRecordatorio.Size = New System.Drawing.Size(678, 249)
        Me.txtRecordatorio.TabIndex = 15
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(615, 335)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 51)
        Me.btnSalir.TabIndex = 102
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardar.Location = New System.Drawing.Point(518, 335)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 51)
        Me.btnGuardar.TabIndex = 101
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.Checked = True
        Me.chbActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbActivo.ForeColor = System.Drawing.SystemColors.Control
        Me.chbActivo.Location = New System.Drawing.Point(12, 348)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(71, 24)
        Me.chbActivo.TabIndex = 103
        Me.chbActivo.Text = "Activo"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.SystemColors.Control
        Me.lblInfo.Location = New System.Drawing.Point(12, 53)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(51, 18)
        Me.lblInfo.TabIndex = 104
        Me.lblInfo.Text = "Label1"
        Me.lblInfo.Visible = False
        '
        'chbNuevo
        '
        Me.chbNuevo.AutoSize = True
        Me.chbNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbNuevo.ForeColor = System.Drawing.SystemColors.Control
        Me.chbNuevo.Location = New System.Drawing.Point(528, 51)
        Me.chbNuevo.Name = "chbNuevo"
        Me.chbNuevo.Size = New System.Drawing.Size(162, 24)
        Me.chbNuevo.TabIndex = 105
        Me.chbNuevo.Text = "Nuevo recordatorio"
        Me.chbNuevo.UseVisualStyleBackColor = True
        '
        'ModalRecordatoriosEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(702, 396)
        Me.Controls.Add(Me.chbNuevo)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtRecordatorio)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "ModalRecordatoriosEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ModalRecordatoriosEDC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents txtRecordatorio As TextBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents chbActivo As CheckBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents chbNuevo As CheckBox
End Class
