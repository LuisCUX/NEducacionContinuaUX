<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CancelacionFacturasEDC
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
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardarCancelacion = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridConceptos = New System.Windows.Forms.DataGridView()
        Me.cbObservacionCancelaciones = New System.Windows.Forms.ComboBox()
        Me.lblTipoCancelacion = New System.Windows.Forms.Label()
        Me.cbTipoCancelacion = New System.Windows.Forms.ComboBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.lblFechaFacturacion = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblMatriculatxt = New System.Windows.Forms.Label()
        Me.lblFechaFacturaciontxt = New System.Windows.Forms.Label()
        Me.lblRFCtxt = New System.Windows.Forms.Label()
        Me.cbMotivoSAT = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, 1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1048, 69)
        Me.lblNombreVentana.TabIndex = 13
        Me.lblNombreVentana.Text = "Cancelación de facturas"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(961, 629)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(72, 53)
        Me.btnSalir.TabIndex = 43
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(767, 629)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(72, 53)
        Me.btnLimpiar.TabIndex = 42
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardarCancelacion
        '
        Me.btnGuardarCancelacion.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardarCancelacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarCancelacion.Location = New System.Drawing.Point(866, 629)
        Me.btnGuardarCancelacion.Name = "btnGuardarCancelacion"
        Me.btnGuardarCancelacion.Size = New System.Drawing.Size(72, 53)
        Me.btnGuardarCancelacion.TabIndex = 41
        Me.btnGuardarCancelacion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(26, 629)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 16)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Motivo de cancelación interno:"
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
        Me.GridConceptos.Location = New System.Drawing.Point(29, 160)
        Me.GridConceptos.Name = "GridConceptos"
        Me.GridConceptos.ReadOnly = True
        Me.GridConceptos.Size = New System.Drawing.Size(1004, 403)
        Me.GridConceptos.TabIndex = 45
        '
        'cbObservacionCancelaciones
        '
        Me.cbObservacionCancelaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObservacionCancelaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbObservacionCancelaciones.FormattingEnabled = True
        Me.cbObservacionCancelaciones.Location = New System.Drawing.Point(29, 648)
        Me.cbObservacionCancelaciones.Name = "cbObservacionCancelaciones"
        Me.cbObservacionCancelaciones.Size = New System.Drawing.Size(551, 24)
        Me.cbObservacionCancelaciones.TabIndex = 46
        '
        'lblTipoCancelacion
        '
        Me.lblTipoCancelacion.AutoSize = True
        Me.lblTipoCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCancelacion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoCancelacion.Location = New System.Drawing.Point(26, 86)
        Me.lblTipoCancelacion.Name = "lblTipoCancelacion"
        Me.lblTipoCancelacion.Size = New System.Drawing.Size(134, 16)
        Me.lblTipoCancelacion.TabIndex = 47
        Me.lblTipoCancelacion.Text = "Tipo de cancelación:"
        '
        'cbTipoCancelacion
        '
        Me.cbTipoCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoCancelacion.FormattingEnabled = True
        Me.cbTipoCancelacion.Location = New System.Drawing.Point(178, 83)
        Me.cbTipoCancelacion.Name = "cbTipoCancelacion"
        Me.cbTipoCancelacion.Size = New System.Drawing.Size(486, 24)
        Me.cbTipoCancelacion.TabIndex = 48
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFolio.Location = New System.Drawing.Point(26, 128)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(41, 16)
        Me.lblFolio.TabIndex = 49
        Me.lblFolio.Text = "Folio:"
        '
        'txtFolio
        '
        Me.txtFolio.Enabled = False
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.Location = New System.Drawing.Point(72, 125)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(100, 22)
        Me.txtFolio.TabIndex = 50
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscar.Location = New System.Drawing.Point(178, 119)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(50, 35)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula.Location = New System.Drawing.Point(234, 128)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(46, 16)
        Me.lblMatricula.TabIndex = 52
        Me.lblMatricula.Text = "Clave:"
        '
        'lblFechaFacturacion
        '
        Me.lblFechaFacturacion.AutoSize = True
        Me.lblFechaFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFacturacion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFechaFacturacion.Location = New System.Drawing.Point(433, 128)
        Me.lblFechaFacturacion.Name = "lblFechaFacturacion"
        Me.lblFechaFacturacion.Size = New System.Drawing.Size(136, 16)
        Me.lblFechaFacturacion.TabIndex = 53
        Me.lblFechaFacturacion.Text = "Fecha de facturación:"
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFC.Location = New System.Drawing.Point(784, 128)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(38, 16)
        Me.lblRFC.TabIndex = 54
        Me.lblRFC.Text = "RFC:"
        '
        'lblMatriculatxt
        '
        Me.lblMatriculatxt.AutoSize = True
        Me.lblMatriculatxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatriculatxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatriculatxt.Location = New System.Drawing.Point(305, 124)
        Me.lblMatriculatxt.Name = "lblMatriculatxt"
        Me.lblMatriculatxt.Size = New System.Drawing.Size(0, 20)
        Me.lblMatriculatxt.TabIndex = 55
        '
        'lblFechaFacturaciontxt
        '
        Me.lblFechaFacturaciontxt.AutoSize = True
        Me.lblFechaFacturaciontxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFacturaciontxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFechaFacturaciontxt.Location = New System.Drawing.Point(567, 126)
        Me.lblFechaFacturaciontxt.Name = "lblFechaFacturaciontxt"
        Me.lblFechaFacturaciontxt.Size = New System.Drawing.Size(0, 20)
        Me.lblFechaFacturaciontxt.TabIndex = 56
        '
        'lblRFCtxt
        '
        Me.lblRFCtxt.AutoSize = True
        Me.lblRFCtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFCtxt.Location = New System.Drawing.Point(824, 124)
        Me.lblRFCtxt.Name = "lblRFCtxt"
        Me.lblRFCtxt.Size = New System.Drawing.Size(0, 20)
        Me.lblRFCtxt.TabIndex = 57
        '
        'cbMotivoSAT
        '
        Me.cbMotivoSAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMotivoSAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMotivoSAT.FormattingEnabled = True
        Me.cbMotivoSAT.Location = New System.Drawing.Point(29, 595)
        Me.cbMotivoSAT.Name = "cbMotivoSAT"
        Me.cbMotivoSAT.Size = New System.Drawing.Size(551, 24)
        Me.cbMotivoSAT.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(26, 576)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 16)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Motivo de cancelación SAT:"
        '
        'CancelacionFacturasEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1045, 694)
        Me.Controls.Add(Me.cbMotivoSAT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRFCtxt)
        Me.Controls.Add(Me.lblFechaFacturaciontxt)
        Me.Controls.Add(Me.lblMatriculatxt)
        Me.Controls.Add(Me.lblRFC)
        Me.Controls.Add(Me.lblFechaFacturacion)
        Me.Controls.Add(Me.lblMatricula)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.lblFolio)
        Me.Controls.Add(Me.cbTipoCancelacion)
        Me.Controls.Add(Me.lblTipoCancelacion)
        Me.Controls.Add(Me.cbObservacionCancelaciones)
        Me.Controls.Add(Me.GridConceptos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnGuardarCancelacion)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "CancelacionFacturasEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CancelacionFacturasEDC"
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnGuardarCancelacion As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GridConceptos As DataGridView
    Friend WithEvents cbObservacionCancelaciones As ComboBox
    Friend WithEvents lblTipoCancelacion As Label
    Friend WithEvents cbTipoCancelacion As ComboBox
    Friend WithEvents lblFolio As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblMatricula As Label
    Friend WithEvents lblFechaFacturacion As Label
    Friend WithEvents lblRFC As Label
    Friend WithEvents lblMatriculatxt As Label
    Friend WithEvents lblFechaFacturaciontxt As Label
    Friend WithEvents lblRFCtxt As Label
    Friend WithEvents cbMotivoSAT As ComboBox
    Friend WithEvents Label2 As Label
End Class
