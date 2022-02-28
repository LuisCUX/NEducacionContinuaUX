<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ObservacionesEDC
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
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.tabObservaciones = New System.Windows.Forms.TabControl()
        Me.tabObsAutCon = New System.Windows.Forms.TabPage()
        Me.tabModificacionObservacion = New System.Windows.Forms.TabPage()
        Me.tabObservacionesCancelaciones = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cbTipoObsCancelacion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chbActivoCancelacion = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservacionCancelacion = New System.Windows.Forms.TextBox()
        Me.btnEditarObCancelacion = New System.Windows.Forms.Button()
        Me.btnSalirObCancelacion = New System.Windows.Forms.Button()
        Me.btnLimpiarObCancelacion = New System.Windows.Forms.Button()
        Me.btnGuardarObCancelacion = New System.Windows.Forms.Button()
        Me.GridObservacionCancelacion = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Editar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tabObservaciones.SuspendLayout()
        Me.tabObservacionesCancelaciones.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridObservacionCancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-1, 1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1032, 69)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Observaciones"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabObservaciones
        '
        Me.tabObservaciones.Controls.Add(Me.tabObsAutCon)
        Me.tabObservaciones.Controls.Add(Me.tabModificacionObservacion)
        Me.tabObservaciones.Controls.Add(Me.tabObservacionesCancelaciones)
        Me.tabObservaciones.Location = New System.Drawing.Point(5, 73)
        Me.tabObservaciones.Name = "tabObservaciones"
        Me.tabObservaciones.SelectedIndex = 0
        Me.tabObservaciones.Size = New System.Drawing.Size(1018, 519)
        Me.tabObservaciones.TabIndex = 15
        '
        'tabObsAutCon
        '
        Me.tabObsAutCon.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabObsAutCon.Location = New System.Drawing.Point(4, 22)
        Me.tabObsAutCon.Name = "tabObsAutCon"
        Me.tabObsAutCon.Padding = New System.Windows.Forms.Padding(3)
        Me.tabObsAutCon.Size = New System.Drawing.Size(1010, 493)
        Me.tabObsAutCon.TabIndex = 0
        Me.tabObsAutCon.Text = "Observaciones de autorización y condonación"
        '
        'tabModificacionObservacion
        '
        Me.tabModificacionObservacion.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabModificacionObservacion.Location = New System.Drawing.Point(4, 22)
        Me.tabModificacionObservacion.Name = "tabModificacionObservacion"
        Me.tabModificacionObservacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tabModificacionObservacion.Size = New System.Drawing.Size(1010, 493)
        Me.tabModificacionObservacion.TabIndex = 1
        Me.tabModificacionObservacion.Text = "Modificación de observaciones"
        '
        'tabObservacionesCancelaciones
        '
        Me.tabObservacionesCancelaciones.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabObservacionesCancelaciones.Controls.Add(Me.SplitContainer1)
        Me.tabObservacionesCancelaciones.Location = New System.Drawing.Point(4, 22)
        Me.tabObservacionesCancelaciones.Name = "tabObservacionesCancelaciones"
        Me.tabObservacionesCancelaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tabObservacionesCancelaciones.Size = New System.Drawing.Size(1010, 493)
        Me.tabObservacionesCancelaciones.TabIndex = 2
        Me.tabObservacionesCancelaciones.Text = "Observaciones de cancelaciones"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbTipoObsCancelacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chbActivoCancelacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtObservacionCancelacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnEditarObCancelacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnSalirObCancelacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnLimpiarObCancelacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnGuardarObCancelacion)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridObservacionCancelacion)
        Me.SplitContainer1.Size = New System.Drawing.Size(1004, 487)
        Me.SplitContainer1.SplitterDistance = 381
        Me.SplitContainer1.TabIndex = 0
        '
        'cbTipoObsCancelacion
        '
        Me.cbTipoObsCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoObsCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoObsCancelacion.FormattingEnabled = True
        Me.cbTipoObsCancelacion.Location = New System.Drawing.Point(32, 68)
        Me.cbTipoObsCancelacion.Name = "cbTipoObsCancelacion"
        Me.cbTipoObsCancelacion.Size = New System.Drawing.Size(306, 23)
        Me.cbTipoObsCancelacion.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(29, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 16)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Tipo de observación"
        '
        'chbActivoCancelacion
        '
        Me.chbActivoCancelacion.AutoSize = True
        Me.chbActivoCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbActivoCancelacion.ForeColor = System.Drawing.SystemColors.Control
        Me.chbActivoCancelacion.Location = New System.Drawing.Point(281, 132)
        Me.chbActivoCancelacion.Name = "chbActivoCancelacion"
        Me.chbActivoCancelacion.Size = New System.Drawing.Size(57, 19)
        Me.chbActivoCancelacion.TabIndex = 50
        Me.chbActivoCancelacion.Text = "Activo"
        Me.chbActivoCancelacion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(29, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Observaciones:"
        '
        'txtObservacionCancelacion
        '
        Me.txtObservacionCancelacion.Location = New System.Drawing.Point(32, 158)
        Me.txtObservacionCancelacion.Multiline = True
        Me.txtObservacionCancelacion.Name = "txtObservacionCancelacion"
        Me.txtObservacionCancelacion.Size = New System.Drawing.Size(306, 118)
        Me.txtObservacionCancelacion.TabIndex = 48
        '
        'btnEditarObCancelacion
        '
        Me.btnEditarObCancelacion.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.card_exchange_40px
        Me.btnEditarObCancelacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnEditarObCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditarObCancelacion.Location = New System.Drawing.Point(110, 405)
        Me.btnEditarObCancelacion.Name = "btnEditarObCancelacion"
        Me.btnEditarObCancelacion.Size = New System.Drawing.Size(72, 53)
        Me.btnEditarObCancelacion.TabIndex = 47
        Me.btnEditarObCancelacion.UseVisualStyleBackColor = True
        '
        'btnSalirObCancelacion
        '
        Me.btnSalirObCancelacion.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalirObCancelacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalirObCancelacion.Location = New System.Drawing.Point(266, 405)
        Me.btnSalirObCancelacion.Name = "btnSalirObCancelacion"
        Me.btnSalirObCancelacion.Size = New System.Drawing.Size(72, 53)
        Me.btnSalirObCancelacion.TabIndex = 46
        Me.btnSalirObCancelacion.UseVisualStyleBackColor = True
        '
        'btnLimpiarObCancelacion
        '
        Me.btnLimpiarObCancelacion.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiarObCancelacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiarObCancelacion.Location = New System.Drawing.Point(188, 405)
        Me.btnLimpiarObCancelacion.Name = "btnLimpiarObCancelacion"
        Me.btnLimpiarObCancelacion.Size = New System.Drawing.Size(72, 53)
        Me.btnLimpiarObCancelacion.TabIndex = 45
        Me.btnLimpiarObCancelacion.UseVisualStyleBackColor = True
        '
        'btnGuardarObCancelacion
        '
        Me.btnGuardarObCancelacion.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardarObCancelacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarObCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarObCancelacion.Location = New System.Drawing.Point(32, 405)
        Me.btnGuardarObCancelacion.Name = "btnGuardarObCancelacion"
        Me.btnGuardarObCancelacion.Size = New System.Drawing.Size(72, 53)
        Me.btnGuardarObCancelacion.TabIndex = 44
        Me.btnGuardarObCancelacion.UseVisualStyleBackColor = True
        '
        'GridObservacionCancelacion
        '
        Me.GridObservacionCancelacion.AllowUserToAddRows = False
        Me.GridObservacionCancelacion.AllowUserToDeleteRows = False
        Me.GridObservacionCancelacion.AllowUserToResizeColumns = False
        Me.GridObservacionCancelacion.AllowUserToResizeRows = False
        Me.GridObservacionCancelacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridObservacionCancelacion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridObservacionCancelacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridObservacionCancelacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Observacion, Me.Editar})
        Me.GridObservacionCancelacion.Location = New System.Drawing.Point(3, 3)
        Me.GridObservacionCancelacion.Name = "GridObservacionCancelacion"
        Me.GridObservacionCancelacion.Size = New System.Drawing.Size(611, 481)
        Me.GridObservacionCancelacion.TabIndex = 0
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'Observacion
        '
        Me.Observacion.FillWeight = 184.7716!
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        '
        'Editar
        '
        Me.Editar.FillWeight = 15.22843!
        Me.Editar.HeaderText = "Editar"
        Me.Editar.Name = "Editar"
        '
        'ObservacionesEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1028, 598)
        Me.Controls.Add(Me.tabObservaciones)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "ObservacionesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ObservacionesEDC"
        Me.tabObservaciones.ResumeLayout(False)
        Me.tabObservacionesCancelaciones.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridObservacionCancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents tabObservaciones As TabControl
    Friend WithEvents tabObsAutCon As TabPage
    Friend WithEvents tabModificacionObservacion As TabPage
    Friend WithEvents tabObservacionesCancelaciones As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GridObservacionCancelacion As DataGridView
    Friend WithEvents btnEditarObCancelacion As Button
    Friend WithEvents btnSalirObCancelacion As Button
    Friend WithEvents btnLimpiarObCancelacion As Button
    Friend WithEvents btnGuardarObCancelacion As Button
    Friend WithEvents chbActivoCancelacion As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtObservacionCancelacion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbTipoObsCancelacion As ComboBox
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents Editar As DataGridViewCheckBoxColumn
End Class
