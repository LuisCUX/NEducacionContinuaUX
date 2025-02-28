<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificacionCostosCongresos
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
        Me.panelInfo3 = New System.Windows.Forms.Panel()
        Me.lblNombreInfo3 = New System.Windows.Forms.Label()
        Me.lblEmail3 = New System.Windows.Forms.Label()
        Me.txtEmail3 = New System.Windows.Forms.TextBox()
        Me.txtNombre3 = New System.Windows.Forms.TextBox()
        Me.panelBusqueda3 = New System.Windows.Forms.Panel()
        Me.txtMatricula3 = New System.Windows.Forms.TextBox()
        Me.lblMatricula3 = New System.Windows.Forms.Label()
        Me.btnBuscar3 = New System.Windows.Forms.Button()
        Me.lblNombre3 = New System.Windows.Forms.Label()
        Me.cbBuscar3 = New System.Windows.Forms.ComboBox()
        Me.panelRegistro = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnModificacionDesc = New System.Windows.Forms.Button()
        Me.txtNuevoCosto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCostoActual = New System.Windows.Forms.TextBox()
        Me.txtNombreCongreso = New System.Windows.Forms.TextBox()
        Me.lblMensualidades = New System.Windows.Forms.Label()
        Me.lblInscripcion = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.panelInfo3.SuspendLayout()
        Me.panelBusqueda3.SuspendLayout()
        Me.panelRegistro.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-1, -2)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(803, 69)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Modificación de costos de congresos"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelInfo3
        '
        Me.panelInfo3.Controls.Add(Me.lblNombreInfo3)
        Me.panelInfo3.Controls.Add(Me.lblEmail3)
        Me.panelInfo3.Controls.Add(Me.txtEmail3)
        Me.panelInfo3.Controls.Add(Me.txtNombre3)
        Me.panelInfo3.Location = New System.Drawing.Point(5, 124)
        Me.panelInfo3.Name = "panelInfo3"
        Me.panelInfo3.Size = New System.Drawing.Size(788, 65)
        Me.panelInfo3.TabIndex = 90
        Me.panelInfo3.Visible = False
        '
        'lblNombreInfo3
        '
        Me.lblNombreInfo3.AutoSize = True
        Me.lblNombreInfo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreInfo3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombreInfo3.Location = New System.Drawing.Point(3, 9)
        Me.lblNombreInfo3.Name = "lblNombreInfo3"
        Me.lblNombreInfo3.Size = New System.Drawing.Size(58, 15)
        Me.lblNombreInfo3.TabIndex = 80
        Me.lblNombreInfo3.Text = "Nombre: "
        '
        'lblEmail3
        '
        Me.lblEmail3.AutoSize = True
        Me.lblEmail3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail3.Location = New System.Drawing.Point(3, 38)
        Me.lblEmail3.Name = "lblEmail3"
        Me.lblEmail3.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail3.TabIndex = 81
        Me.lblEmail3.Text = "Email:"
        '
        'txtEmail3
        '
        Me.txtEmail3.Enabled = False
        Me.txtEmail3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail3.Location = New System.Drawing.Point(70, 35)
        Me.txtEmail3.Name = "txtEmail3"
        Me.txtEmail3.Size = New System.Drawing.Size(474, 21)
        Me.txtEmail3.TabIndex = 82
        '
        'txtNombre3
        '
        Me.txtNombre3.Enabled = False
        Me.txtNombre3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre3.Location = New System.Drawing.Point(70, 6)
        Me.txtNombre3.Name = "txtNombre3"
        Me.txtNombre3.Size = New System.Drawing.Size(474, 21)
        Me.txtNombre3.TabIndex = 79
        '
        'panelBusqueda3
        '
        Me.panelBusqueda3.Controls.Add(Me.txtMatricula3)
        Me.panelBusqueda3.Controls.Add(Me.lblMatricula3)
        Me.panelBusqueda3.Controls.Add(Me.btnBuscar3)
        Me.panelBusqueda3.Controls.Add(Me.lblNombre3)
        Me.panelBusqueda3.Controls.Add(Me.cbBuscar3)
        Me.panelBusqueda3.Location = New System.Drawing.Point(5, 79)
        Me.panelBusqueda3.Name = "panelBusqueda3"
        Me.panelBusqueda3.Size = New System.Drawing.Size(788, 39)
        Me.panelBusqueda3.TabIndex = 89
        '
        'txtMatricula3
        '
        Me.txtMatricula3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula3.Location = New System.Drawing.Point(70, 6)
        Me.txtMatricula3.Name = "txtMatricula3"
        Me.txtMatricula3.Size = New System.Drawing.Size(111, 22)
        Me.txtMatricula3.TabIndex = 75
        '
        'lblMatricula3
        '
        Me.lblMatricula3.AutoSize = True
        Me.lblMatricula3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula3.Location = New System.Drawing.Point(8, 9)
        Me.lblMatricula3.Name = "lblMatricula3"
        Me.lblMatricula3.Size = New System.Drawing.Size(46, 16)
        Me.lblMatricula3.TabIndex = 74
        Me.lblMatricula3.Text = "Clave:"
        '
        'btnBuscar3
        '
        Me.btnBuscar3.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar3.Location = New System.Drawing.Point(187, 0)
        Me.btnBuscar3.Name = "btnBuscar3"
        Me.btnBuscar3.Size = New System.Drawing.Size(41, 39)
        Me.btnBuscar3.TabIndex = 76
        Me.btnBuscar3.UseVisualStyleBackColor = True
        '
        'lblNombre3
        '
        Me.lblNombre3.AutoSize = True
        Me.lblNombre3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre3.Location = New System.Drawing.Point(234, 9)
        Me.lblNombre3.Name = "lblNombre3"
        Me.lblNombre3.Size = New System.Drawing.Size(63, 16)
        Me.lblNombre3.TabIndex = 77
        Me.lblNombre3.Text = "Nombre: "
        '
        'cbBuscar3
        '
        Me.cbBuscar3.FormattingEnabled = True
        Me.cbBuscar3.Location = New System.Drawing.Point(303, 8)
        Me.cbBuscar3.Name = "cbBuscar3"
        Me.cbBuscar3.Size = New System.Drawing.Size(478, 21)
        Me.cbBuscar3.TabIndex = 78
        '
        'panelRegistro
        '
        Me.panelRegistro.Controls.Add(Me.Button1)
        Me.panelRegistro.Controls.Add(Me.Button2)
        Me.panelRegistro.Controls.Add(Me.btnModificacionDesc)
        Me.panelRegistro.Controls.Add(Me.txtNuevoCosto)
        Me.panelRegistro.Controls.Add(Me.Label1)
        Me.panelRegistro.Controls.Add(Me.txtCostoActual)
        Me.panelRegistro.Controls.Add(Me.txtNombreCongreso)
        Me.panelRegistro.Controls.Add(Me.lblMensualidades)
        Me.panelRegistro.Controls.Add(Me.lblInscripcion)
        Me.panelRegistro.Location = New System.Drawing.Point(5, 195)
        Me.panelRegistro.Name = "panelRegistro"
        Me.panelRegistro.Size = New System.Drawing.Size(788, 358)
        Me.panelRegistro.TabIndex = 91
        Me.panelRegistro.Visible = False
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(503, 296)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 46)
        Me.Button2.TabIndex = 107
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnModificacionDesc
        '
        Me.btnModificacionDesc.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnModificacionDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnModificacionDesc.Location = New System.Drawing.Point(237, 296)
        Me.btnModificacionDesc.Name = "btnModificacionDesc"
        Me.btnModificacionDesc.Size = New System.Drawing.Size(60, 46)
        Me.btnModificacionDesc.TabIndex = 106
        Me.btnModificacionDesc.UseVisualStyleBackColor = True
        '
        'txtNuevoCosto
        '
        Me.txtNuevoCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNuevoCosto.Location = New System.Drawing.Point(387, 124)
        Me.txtNuevoCosto.Name = "txtNuevoCosto"
        Me.txtNuevoCosto.Size = New System.Drawing.Size(157, 31)
        Me.txtNuevoCosto.TabIndex = 105
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(233, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 20)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Nuevo costo:"
        '
        'txtCostoActual
        '
        Me.txtCostoActual.Enabled = False
        Me.txtCostoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoActual.Location = New System.Drawing.Point(387, 80)
        Me.txtCostoActual.Name = "txtCostoActual"
        Me.txtCostoActual.Size = New System.Drawing.Size(157, 31)
        Me.txtCostoActual.TabIndex = 103
        '
        'txtNombreCongreso
        '
        Me.txtNombreCongreso.Enabled = False
        Me.txtNombreCongreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCongreso.Location = New System.Drawing.Point(6, 36)
        Me.txtNombreCongreso.Name = "txtNombreCongreso"
        Me.txtNombreCongreso.Size = New System.Drawing.Size(782, 26)
        Me.txtNombreCongreso.TabIndex = 102
        '
        'lblMensualidades
        '
        Me.lblMensualidades.AutoSize = True
        Me.lblMensualidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensualidades.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMensualidades.Location = New System.Drawing.Point(233, 87)
        Me.lblMensualidades.Name = "lblMensualidades"
        Me.lblMensualidades.Size = New System.Drawing.Size(102, 20)
        Me.lblMensualidades.TabIndex = 101
        Me.lblMensualidades.Text = "Costo actual:"
        '
        'lblInscripcion
        '
        Me.lblInscripcion.AutoSize = True
        Me.lblInscripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInscripcion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblInscripcion.Location = New System.Drawing.Point(2, 13)
        Me.lblInscripcion.Name = "lblInscripcion"
        Me.lblInscripcion.Size = New System.Drawing.Size(82, 20)
        Me.lblInscripcion.TabIndex = 100
        Me.lblInscripcion.Text = "Congreso:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(665, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 52)
        Me.Button1.TabIndex = 108
        Me.Button1.Text = "Reestablecer costo original"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ModificacionCostosCongresos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(800, 565)
        Me.Controls.Add(Me.panelRegistro)
        Me.Controls.Add(Me.panelInfo3)
        Me.Controls.Add(Me.panelBusqueda3)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "ModificacionCostosCongresos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ModificacionCostosCongresos"
        Me.panelInfo3.ResumeLayout(False)
        Me.panelInfo3.PerformLayout()
        Me.panelBusqueda3.ResumeLayout(False)
        Me.panelBusqueda3.PerformLayout()
        Me.panelRegistro.ResumeLayout(False)
        Me.panelRegistro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelInfo3 As Panel
    Friend WithEvents lblNombreInfo3 As Label
    Friend WithEvents lblEmail3 As Label
    Friend WithEvents txtEmail3 As TextBox
    Friend WithEvents txtNombre3 As TextBox
    Friend WithEvents panelBusqueda3 As Panel
    Friend WithEvents txtMatricula3 As TextBox
    Friend WithEvents lblMatricula3 As Label
    Friend WithEvents btnBuscar3 As Button
    Friend WithEvents lblNombre3 As Label
    Friend WithEvents cbBuscar3 As ComboBox
    Friend WithEvents panelRegistro As Panel
    Friend WithEvents txtNuevoCosto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCostoActual As TextBox
    Friend WithEvents txtNombreCongreso As TextBox
    Friend WithEvents lblMensualidades As Label
    Friend WithEvents lblInscripcion As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btnModificacionDesc As Button
    Friend WithEvents Button1 As Button
End Class
