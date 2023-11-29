<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificacionDatosFiscalesECEDC
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
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
        Me.btnCorreo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelModificacion3 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panelInfo3.SuspendLayout()
        Me.panelBusqueda3.SuspendLayout()
        Me.panelModificacion3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-3, -2)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(816, 69)
        Me.lblNombreVentana.TabIndex = 14
        Me.lblNombreVentana.Text = "Modificación de datos fiscales"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelInfo3
        '
        Me.panelInfo3.Controls.Add(Me.ComboBox1)
        Me.panelInfo3.Controls.Add(Me.lblNombreInfo3)
        Me.panelInfo3.Controls.Add(Me.lblEmail3)
        Me.panelInfo3.Controls.Add(Me.txtEmail3)
        Me.panelInfo3.Controls.Add(Me.txtNombre3)
        Me.panelInfo3.Location = New System.Drawing.Point(12, 124)
        Me.panelInfo3.Name = "panelInfo3"
        Me.panelInfo3.Size = New System.Drawing.Size(788, 65)
        Me.panelInfo3.TabIndex = 90
        Me.panelInfo3.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(774, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(10, 21)
        Me.ComboBox1.TabIndex = 83
        Me.ComboBox1.Visible = False
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
        Me.panelBusqueda3.Location = New System.Drawing.Point(12, 79)
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
        'btnCorreo
        '
        Me.btnCorreo.Image = Global.NEducacionContinuaUX.My.Resources.Resources.send_40px
        Me.btnCorreo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCorreo.Location = New System.Drawing.Point(203, 40)
        Me.btnCorreo.Name = "btnCorreo"
        Me.btnCorreo.Size = New System.Drawing.Size(94, 60)
        Me.btnCorreo.TabIndex = 91
        Me.btnCorreo.Text = "Enviar correo"
        Me.btnCorreo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCorreo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 206)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 16)
        Me.Label1.TabIndex = 92
        '
        'panelModificacion3
        '
        Me.panelModificacion3.Controls.Add(Me.Button1)
        Me.panelModificacion3.Controls.Add(Me.Label2)
        Me.panelModificacion3.Controls.Add(Me.btnCorreo)
        Me.panelModificacion3.Location = New System.Drawing.Point(12, 196)
        Me.panelModificacion3.Name = "panelModificacion3"
        Me.panelModificacion3.Size = New System.Drawing.Size(787, 100)
        Me.panelModificacion3.TabIndex = 93
        '
        'Button1
        '
        Me.Button1.Image = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(523, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 60)
        Me.Button1.TabIndex = 93
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(8, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(643, 15)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "Se enviará un correo al email del cliente con un link mediante el cual podrá actu" &
    "alizar o dar de alta sus datos fiscales"
        '
        'ModificacionDatosFiscalesECEDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(811, 308)
        Me.Controls.Add(Me.panelModificacion3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.panelInfo3)
        Me.Controls.Add(Me.panelBusqueda3)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "ModificacionDatosFiscalesECEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ModificacionDatosFiscalesECEDC"
        Me.panelInfo3.ResumeLayout(False)
        Me.panelInfo3.PerformLayout()
        Me.panelBusqueda3.ResumeLayout(False)
        Me.panelBusqueda3.PerformLayout()
        Me.panelModificacion3.ResumeLayout(False)
        Me.panelModificacion3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelInfo3 As Panel
    Friend WithEvents ComboBox1 As ComboBox
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
    Friend WithEvents btnCorreo As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents panelModificacion3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
End Class
