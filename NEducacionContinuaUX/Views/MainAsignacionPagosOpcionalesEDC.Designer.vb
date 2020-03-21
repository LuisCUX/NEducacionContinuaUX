<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainAsignacionPagosOpcionalesEDC
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
        Me.panelBuscar = New System.Windows.Forms.Panel()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.txtMatriculaDato = New System.Windows.Forms.TextBox()
        Me.lblMatriculaDato = New System.Windows.Forms.Label()
        Me.txtTurno = New System.Windows.Forms.TextBox()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.txtCarrera = New System.Windows.Forms.TextBox()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.panelAsignacion = New System.Windows.Forms.Panel()
        Me.GridPagosAsignados = New System.Windows.Forms.DataGridView()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.panelBuscar.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.panelAsignacion.SuspendLayout()
        CType(Me.GridPagosAsignados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-1, -1)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(886, 69)
        Me.lblNombreVentana.TabIndex = 11
        Me.lblNombreVentana.Text = "Asignacion de pagos opcionales"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBuscar
        '
        Me.panelBuscar.Controls.Add(Me.cbExterno)
        Me.panelBuscar.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBuscar.Controls.Add(Me.btnBuscar)
        Me.panelBuscar.Controls.Add(Me.txtMatricula)
        Me.panelBuscar.Controls.Add(Me.lblMatricula)
        Me.panelBuscar.Location = New System.Drawing.Point(12, 71)
        Me.panelBuscar.Name = "panelBuscar"
        Me.panelBuscar.Size = New System.Drawing.Size(858, 54)
        Me.panelBuscar.TabIndex = 12
        '
        'cbExterno
        '
        Me.cbExterno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbExterno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(382, 19)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(458, 21)
        Me.cbExterno.TabIndex = 75
        '
        'lblBusquedaNombre
        '
        Me.lblBusquedaNombre.AutoSize = True
        Me.lblBusquedaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBusquedaNombre.Location = New System.Drawing.Point(321, 20)
        Me.lblBusquedaNombre.Name = "lblBusquedaNombre"
        Me.lblBusquedaNombre.Size = New System.Drawing.Size(63, 16)
        Me.lblBusquedaNombre.TabIndex = 74
        Me.lblBusquedaNombre.Text = "Nombre: "
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_32px
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(193, 11)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(41, 34)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtMatricula
        '
        Me.txtMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula.Location = New System.Drawing.Point(77, 17)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(110, 22)
        Me.txtMatricula.TabIndex = 16
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula.Location = New System.Drawing.Point(7, 18)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(72, 18)
        Me.lblMatricula.TabIndex = 15
        Me.lblMatricula.Text = "Matricula:"
        '
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.txtMatriculaDato)
        Me.panelDatos.Controls.Add(Me.lblMatriculaDato)
        Me.panelDatos.Controls.Add(Me.txtTurno)
        Me.panelDatos.Controls.Add(Me.lblTurno)
        Me.panelDatos.Controls.Add(Me.txtCarrera)
        Me.panelDatos.Controls.Add(Me.lblCarrera)
        Me.panelDatos.Controls.Add(Me.txtEmail)
        Me.panelDatos.Controls.Add(Me.txtNombre)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Location = New System.Drawing.Point(12, 131)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(858, 134)
        Me.panelDatos.TabIndex = 13
        Me.panelDatos.Visible = False
        '
        'txtMatriculaDato
        '
        Me.txtMatriculaDato.Enabled = False
        Me.txtMatriculaDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatriculaDato.Location = New System.Drawing.Point(77, 10)
        Me.txtMatriculaDato.Name = "txtMatriculaDato"
        Me.txtMatriculaDato.Size = New System.Drawing.Size(110, 22)
        Me.txtMatriculaDato.TabIndex = 25
        '
        'lblMatriculaDato
        '
        Me.lblMatriculaDato.AutoSize = True
        Me.lblMatriculaDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatriculaDato.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatriculaDato.Location = New System.Drawing.Point(7, 11)
        Me.lblMatriculaDato.Name = "lblMatriculaDato"
        Me.lblMatriculaDato.Size = New System.Drawing.Size(72, 18)
        Me.lblMatriculaDato.TabIndex = 26
        Me.lblMatriculaDato.Text = "Matricula:"
        '
        'txtTurno
        '
        Me.txtTurno.Enabled = False
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.Location = New System.Drawing.Point(77, 101)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.Size = New System.Drawing.Size(764, 22)
        Me.txtTurno.TabIndex = 24
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurno.Location = New System.Drawing.Point(7, 102)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(51, 18)
        Me.lblTurno.TabIndex = 23
        Me.lblTurno.Text = "Turno:"
        '
        'txtCarrera
        '
        Me.txtCarrera.Enabled = False
        Me.txtCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCarrera.Location = New System.Drawing.Point(77, 70)
        Me.txtCarrera.Name = "txtCarrera"
        Me.txtCarrera.Size = New System.Drawing.Size(764, 22)
        Me.txtCarrera.TabIndex = 22
        '
        'lblCarrera
        '
        Me.lblCarrera.AutoSize = True
        Me.lblCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarrera.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCarrera.Location = New System.Drawing.Point(7, 71)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Size = New System.Drawing.Size(62, 18)
        Me.lblCarrera.TabIndex = 21
        Me.lblCarrera.Text = "Carrera:"
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(77, 39)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(764, 22)
        Me.txtEmail.TabIndex = 20
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(262, 10)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(579, 22)
        Me.txtNombre.TabIndex = 18
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail.Location = New System.Drawing.Point(7, 40)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(49, 18)
        Me.lblEmail.TabIndex = 19
        Me.lblEmail.Text = "Email:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre.Location = New System.Drawing.Point(193, 11)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(70, 18)
        Me.lblNombre.TabIndex = 18
        Me.lblNombre.Text = "Nombre: "
        '
        'panelAsignacion
        '
        Me.panelAsignacion.Controls.Add(Me.GridPagosAsignados)
        Me.panelAsignacion.Controls.Add(Me.btnAgregar)
        Me.panelAsignacion.Location = New System.Drawing.Point(12, 271)
        Me.panelAsignacion.Name = "panelAsignacion"
        Me.panelAsignacion.Size = New System.Drawing.Size(858, 364)
        Me.panelAsignacion.TabIndex = 15
        Me.panelAsignacion.Visible = False
        '
        'GridPagosAsignados
        '
        Me.GridPagosAsignados.AllowUserToAddRows = False
        Me.GridPagosAsignados.AllowUserToDeleteRows = False
        Me.GridPagosAsignados.AllowUserToResizeColumns = False
        Me.GridPagosAsignados.AllowUserToResizeRows = False
        Me.GridPagosAsignados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridPagosAsignados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridPagosAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridPagosAsignados.Location = New System.Drawing.Point(10, 63)
        Me.GridPagosAsignados.Name = "GridPagosAsignados"
        Me.GridPagosAsignados.ReadOnly = True
        Me.GridPagosAsignados.Size = New System.Drawing.Size(831, 282)
        Me.GridPagosAsignados.TabIndex = 19
        '
        'btnAgregar
        '
        Me.btnAgregar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.plus_32px
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(764, 14)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(77, 41)
        Me.btnAgregar.TabIndex = 18
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'MainAsignacionPagosOpcionalesEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(882, 647)
        Me.Controls.Add(Me.panelAsignacion)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.panelBuscar)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Name = "MainAsignacionPagosOpcionalesEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AsignacionPagosOpcionales"
        Me.panelBuscar.ResumeLayout(False)
        Me.panelBuscar.PerformLayout()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.panelAsignacion.ResumeLayout(False)
        CType(Me.GridPagosAsignados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelBuscar As Panel
    Friend WithEvents lblMatricula As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents panelDatos As Panel
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtCarrera As TextBox
    Friend WithEvents lblCarrera As Label
    Friend WithEvents txtTurno As TextBox
    Friend WithEvents lblTurno As Label
    Friend WithEvents panelAsignacion As Panel
    Friend WithEvents btnAgregar As Button
    Friend WithEvents GridPagosAsignados As DataGridView
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents txtMatriculaDato As TextBox
    Friend WithEvents lblMatriculaDato As Label
End Class
