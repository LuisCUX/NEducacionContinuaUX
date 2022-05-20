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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridConceptos = New System.Windows.Forms.DataGridView()
        Me.cbObservacionCancelaciones = New System.Windows.Forms.ComboBox()
        Me.lblTipoCancelacion = New System.Windows.Forms.Label()
        Me.cbTipoCancelacion = New System.Windows.Forms.ComboBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.lblFechaFacturacion = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblMatriculatxt = New System.Windows.Forms.Label()
        Me.lblFechaFacturaciontxt = New System.Windows.Forms.Label()
        Me.lblRFCtxt = New System.Windows.Forms.Label()
        Me.cbMotivoSAT = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnGuardarInterno = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardarCancelacion = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnReimprimir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFolioReimpresion = New System.Windows.Forms.TextBox()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(26, 674)
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
        Me.GridConceptos.Location = New System.Drawing.Point(12, 206)
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
        Me.cbObservacionCancelaciones.Location = New System.Drawing.Point(29, 693)
        Me.cbObservacionCancelaciones.Name = "cbObservacionCancelaciones"
        Me.cbObservacionCancelaciones.Size = New System.Drawing.Size(551, 24)
        Me.cbObservacionCancelaciones.TabIndex = 46
        '
        'lblTipoCancelacion
        '
        Me.lblTipoCancelacion.AutoSize = True
        Me.lblTipoCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCancelacion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoCancelacion.Location = New System.Drawing.Point(14, 13)
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
        Me.cbTipoCancelacion.Location = New System.Drawing.Point(169, 10)
        Me.cbTipoCancelacion.Name = "cbTipoCancelacion"
        Me.cbTipoCancelacion.Size = New System.Drawing.Size(471, 24)
        Me.cbTipoCancelacion.TabIndex = 48
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFolio.Location = New System.Drawing.Point(14, 52)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(41, 16)
        Me.lblFolio.TabIndex = 49
        Me.lblFolio.Text = "Folio:"
        '
        'txtFolio
        '
        Me.txtFolio.Enabled = False
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.Location = New System.Drawing.Point(61, 49)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(100, 22)
        Me.txtFolio.TabIndex = 50
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula.Location = New System.Drawing.Point(14, 90)
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
        Me.lblFechaFacturacion.Location = New System.Drawing.Point(277, 89)
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
        Me.lblRFC.Location = New System.Drawing.Point(642, 90)
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
        Me.lblMatriculatxt.Location = New System.Drawing.Point(65, 85)
        Me.lblMatriculatxt.Name = "lblMatriculatxt"
        Me.lblMatriculatxt.Size = New System.Drawing.Size(0, 20)
        Me.lblMatriculatxt.TabIndex = 55
        '
        'lblFechaFacturaciontxt
        '
        Me.lblFechaFacturaciontxt.AutoSize = True
        Me.lblFechaFacturaciontxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFacturaciontxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblFechaFacturaciontxt.Location = New System.Drawing.Point(411, 87)
        Me.lblFechaFacturaciontxt.Name = "lblFechaFacturaciontxt"
        Me.lblFechaFacturaciontxt.Size = New System.Drawing.Size(0, 20)
        Me.lblFechaFacturaciontxt.TabIndex = 56
        '
        'lblRFCtxt
        '
        Me.lblRFCtxt.AutoSize = True
        Me.lblRFCtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFCtxt.Location = New System.Drawing.Point(682, 86)
        Me.lblRFCtxt.Name = "lblRFCtxt"
        Me.lblRFCtxt.Size = New System.Drawing.Size(0, 20)
        Me.lblRFCtxt.TabIndex = 57
        '
        'cbMotivoSAT
        '
        Me.cbMotivoSAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMotivoSAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMotivoSAT.FormattingEnabled = True
        Me.cbMotivoSAT.Location = New System.Drawing.Point(29, 640)
        Me.cbMotivoSAT.Name = "cbMotivoSAT"
        Me.cbMotivoSAT.Size = New System.Drawing.Size(551, 24)
        Me.cbMotivoSAT.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(26, 621)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 16)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Motivo de cancelación SAT:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscar.Location = New System.Drawing.Point(168, 43)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(50, 35)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnGuardarInterno
        '
        Me.btnGuardarInterno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarInterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarInterno.Image = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardarInterno.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardarInterno.Location = New System.Drawing.Point(607, 640)
        Me.btnGuardarInterno.Name = "btnGuardarInterno"
        Me.btnGuardarInterno.Size = New System.Drawing.Size(85, 75)
        Me.btnGuardarInterno.TabIndex = 60
        Me.btnGuardarInterno.Text = "Cancelacion interna"
        Me.btnGuardarInterno.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardarInterno.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.Location = New System.Drawing.Point(931, 638)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(85, 77)
        Me.btnSalir.TabIndex = 43
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(720, 640)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(85, 77)
        Me.btnLimpiar.TabIndex = 42
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardarCancelacion
        '
        Me.btnGuardarCancelacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarCancelacion.Image = Global.NEducacionContinuaUX.My.Resources.Resources.cancel_subscription_40px
        Me.btnGuardarCancelacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardarCancelacion.Location = New System.Drawing.Point(829, 640)
        Me.btnGuardarCancelacion.Name = "btnGuardarCancelacion"
        Me.btnGuardarCancelacion.Size = New System.Drawing.Size(85, 75)
        Me.btnGuardarCancelacion.TabIndex = 41
        Me.btnGuardarCancelacion.Text = "Cancelacion en SAT"
        Me.btnGuardarCancelacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardarCancelacion.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 73)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTipoCancelacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbTipoCancelacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFolio)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFolio)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMatriculatxt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFechaFacturaciontxt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMatricula)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblRFCtxt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnBuscar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFechaFacturacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblRFC)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnReimprimir)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtFolioReimpresion)
        Me.SplitContainer1.Size = New System.Drawing.Size(1004, 127)
        Me.SplitContainer1.SplitterDistance = 809
        Me.SplitContainer1.TabIndex = 61
        '
        'btnReimprimir
        '
        Me.btnReimprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnReimprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReimprimir.Image = Global.NEducacionContinuaUX.My.Resources.Resources.print_40px
        Me.btnReimprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReimprimir.Location = New System.Drawing.Point(59, 46)
        Me.btnReimprimir.Name = "btnReimprimir"
        Me.btnReimprimir.Size = New System.Drawing.Size(126, 71)
        Me.btnReimprimir.TabIndex = 61
        Me.btnReimprimir.Text = "Reimprimir factura"
        Me.btnReimprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReimprimir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Folio:"
        '
        'txtFolioReimpresion
        '
        Me.txtFolioReimpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolioReimpresion.Location = New System.Drawing.Point(59, 10)
        Me.txtFolioReimpresion.Name = "txtFolioReimpresion"
        Me.txtFolioReimpresion.Size = New System.Drawing.Size(126, 22)
        Me.txtFolioReimpresion.TabIndex = 53
        '
        'CancelacionFacturasEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1029, 731)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnGuardarInterno)
        Me.Controls.Add(Me.cbMotivoSAT)
        Me.Controls.Add(Me.Label2)
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
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
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
    Friend WithEvents btnGuardarInterno As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFolioReimpresion As TextBox
    Friend WithEvents btnReimprimir As Button
End Class
