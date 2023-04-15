<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AutorizacionCondonacionEDC
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutorizacionCondonacionEDC))
        Me.lblNombreVentana = New System.Windows.Forms.Label()
        Me.panelBusqueda = New System.Windows.Forms.Panel()
        Me.cbExterno = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtMatricula = New System.Windows.Forms.TextBox()
        Me.lblMatricula = New System.Windows.Forms.Label()
        Me.panelDatos = New System.Windows.Forms.Panel()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.lblDirecciontxt = New System.Windows.Forms.Label()
        Me.lblCFDItxt = New System.Windows.Forms.Label()
        Me.lblCFDI = New System.Windows.Forms.Label()
        Me.lblRegFiscaltxt = New System.Windows.Forms.Label()
        Me.lblRegFiscal = New System.Windows.Forms.Label()
        Me.lblCPtxt = New System.Windows.Forms.Label()
        Me.lblMatriculaDato = New System.Windows.Forms.Label()
        Me.lblMatriculatxt = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblCarreratxt = New System.Windows.Forms.Label()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.lblTurnotxt = New System.Windows.Forms.Label()
        Me.lblRFCtxt = New System.Windows.Forms.Label()
        Me.lblEmailtxt = New System.Windows.Forms.Label()
        Me.lblNombretxt = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.panelAutCon = New System.Windows.Forms.Panel()
        Me.tabAutCon = New System.Windows.Forms.TabControl()
        Me.tabCondonaciones = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardarCondonaciones = New System.Windows.Forms.Button()
        Me.GridCondonaciones = New System.Windows.Forms.DataGridView()
        Me.cbTipoCondonacion = New System.Windows.Forms.ComboBox()
        Me.lblTipoCondonacion = New System.Windows.Forms.Label()
        Me.TreeCondonaciones = New System.Windows.Forms.TreeView()
        Me.ImageListTree = New System.Windows.Forms.ImageList(Me.components)
        Me.tabAutorizacionCaja = New System.Windows.Forms.TabPage()
        Me.btnGuardarAutorizacionCaja = New System.Windows.Forms.Button()
        Me.GridAutorizacionCaja = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.treeAutorizacionCaja = New System.Windows.Forms.TreeView()
        Me.tabAutorizacionProceso = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.cbObservaciones = New System.Windows.Forms.ComboBox()
        Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Porcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDClavePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelBusqueda.SuspendLayout()
        Me.panelDatos.SuspendLayout()
        Me.panelAutCon.SuspendLayout()
        Me.tabAutCon.SuspendLayout()
        Me.tabCondonaciones.SuspendLayout()
        CType(Me.GridCondonaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAutorizacionCaja.SuspendLayout()
        CType(Me.GridAutorizacionCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAutorizacionProceso.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombreVentana
        '
        Me.lblNombreVentana.BackColor = System.Drawing.Color.Maroon
        Me.lblNombreVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreVentana.ForeColor = System.Drawing.Color.Gold
        Me.lblNombreVentana.Location = New System.Drawing.Point(-2, 0)
        Me.lblNombreVentana.Name = "lblNombreVentana"
        Me.lblNombreVentana.Size = New System.Drawing.Size(1205, 69)
        Me.lblNombreVentana.TabIndex = 13
        Me.lblNombreVentana.Text = "Autorización y Condonación"
        Me.lblNombreVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelBusqueda
        '
        Me.panelBusqueda.Controls.Add(Me.cbExterno)
        Me.panelBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.panelBusqueda.Controls.Add(Me.btnBuscar)
        Me.panelBusqueda.Controls.Add(Me.txtMatricula)
        Me.panelBusqueda.Controls.Add(Me.lblMatricula)
        Me.panelBusqueda.Location = New System.Drawing.Point(12, 72)
        Me.panelBusqueda.Name = "panelBusqueda"
        Me.panelBusqueda.Size = New System.Drawing.Size(1175, 50)
        Me.panelBusqueda.TabIndex = 15
        '
        'cbExterno
        '
        Me.cbExterno.FormattingEnabled = True
        Me.cbExterno.Location = New System.Drawing.Point(298, 15)
        Me.cbExterno.Name = "cbExterno"
        Me.cbExterno.Size = New System.Drawing.Size(556, 21)
        Me.cbExterno.TabIndex = 73
        '
        'lblBusquedaNombre
        '
        Me.lblBusquedaNombre.AutoSize = True
        Me.lblBusquedaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusquedaNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblBusquedaNombre.Location = New System.Drawing.Point(241, 16)
        Me.lblBusquedaNombre.Name = "lblBusquedaNombre"
        Me.lblBusquedaNombre.Size = New System.Drawing.Size(63, 16)
        Me.lblBusquedaNombre.TabIndex = 3
        Me.lblBusquedaNombre.Text = "Nombre: "
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.search_30px
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBuscar.Location = New System.Drawing.Point(186, 7)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(41, 34)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtMatricula
        '
        Me.txtMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatricula.Location = New System.Drawing.Point(69, 13)
        Me.txtMatricula.Name = "txtMatricula"
        Me.txtMatricula.Size = New System.Drawing.Size(111, 22)
        Me.txtMatricula.TabIndex = 1
        '
        'lblMatricula
        '
        Me.lblMatricula.AutoSize = True
        Me.lblMatricula.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatricula.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatricula.Location = New System.Drawing.Point(7, 16)
        Me.lblMatricula.Name = "lblMatricula"
        Me.lblMatricula.Size = New System.Drawing.Size(46, 16)
        Me.lblMatricula.TabIndex = 0
        Me.lblMatricula.Text = "Clave:"
        '
        'panelDatos
        '
        Me.panelDatos.Controls.Add(Me.lblDireccion)
        Me.panelDatos.Controls.Add(Me.lblDirecciontxt)
        Me.panelDatos.Controls.Add(Me.lblCFDItxt)
        Me.panelDatos.Controls.Add(Me.lblCFDI)
        Me.panelDatos.Controls.Add(Me.lblRegFiscaltxt)
        Me.panelDatos.Controls.Add(Me.lblRegFiscal)
        Me.panelDatos.Controls.Add(Me.lblCPtxt)
        Me.panelDatos.Controls.Add(Me.lblMatriculaDato)
        Me.panelDatos.Controls.Add(Me.lblMatriculatxt)
        Me.panelDatos.Controls.Add(Me.lblCP)
        Me.panelDatos.Controls.Add(Me.lblCarreratxt)
        Me.panelDatos.Controls.Add(Me.lblCarrera)
        Me.panelDatos.Controls.Add(Me.lblTurnotxt)
        Me.panelDatos.Controls.Add(Me.lblRFCtxt)
        Me.panelDatos.Controls.Add(Me.lblEmailtxt)
        Me.panelDatos.Controls.Add(Me.lblNombretxt)
        Me.panelDatos.Controls.Add(Me.lblRFC)
        Me.panelDatos.Controls.Add(Me.lblTurno)
        Me.panelDatos.Controls.Add(Me.lblEmail)
        Me.panelDatos.Controls.Add(Me.lblNombre)
        Me.panelDatos.Location = New System.Drawing.Point(12, 128)
        Me.panelDatos.Name = "panelDatos"
        Me.panelDatos.Size = New System.Drawing.Size(1175, 53)
        Me.panelDatos.TabIndex = 16
        Me.panelDatos.Visible = False
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDireccion.Location = New System.Drawing.Point(644, 10)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(0, 15)
        Me.lblDireccion.TabIndex = 101
        '
        'lblDirecciontxt
        '
        Me.lblDirecciontxt.AutoSize = True
        Me.lblDirecciontxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirecciontxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblDirecciontxt.Location = New System.Drawing.Point(561, 10)
        Me.lblDirecciontxt.Name = "lblDirecciontxt"
        Me.lblDirecciontxt.Size = New System.Drawing.Size(62, 15)
        Me.lblDirecciontxt.TabIndex = 100
        Me.lblDirecciontxt.Text = "Direccion:"
        '
        'lblCFDItxt
        '
        Me.lblCFDItxt.AutoSize = True
        Me.lblCFDItxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDItxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDItxt.Location = New System.Drawing.Point(497, 11)
        Me.lblCFDItxt.Name = "lblCFDItxt"
        Me.lblCFDItxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCFDItxt.TabIndex = 99
        '
        'lblCFDI
        '
        Me.lblCFDI.AutoSize = True
        Me.lblCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCFDI.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCFDI.Location = New System.Drawing.Point(435, 10)
        Me.lblCFDI.Name = "lblCFDI"
        Me.lblCFDI.Size = New System.Drawing.Size(62, 15)
        Me.lblCFDI.TabIndex = 98
        Me.lblCFDI.Text = "Uso CFDI:"
        '
        'lblRegFiscaltxt
        '
        Me.lblRegFiscaltxt.AutoSize = True
        Me.lblRegFiscaltxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegFiscaltxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRegFiscaltxt.Location = New System.Drawing.Point(401, 10)
        Me.lblRegFiscaltxt.Name = "lblRegFiscaltxt"
        Me.lblRegFiscaltxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRegFiscaltxt.TabIndex = 93
        '
        'lblRegFiscal
        '
        Me.lblRegFiscal.AutoSize = True
        Me.lblRegFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegFiscal.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRegFiscal.Location = New System.Drawing.Point(284, 10)
        Me.lblRegFiscal.Name = "lblRegFiscal"
        Me.lblRegFiscal.Size = New System.Drawing.Size(92, 15)
        Me.lblRegFiscal.TabIndex = 92
        Me.lblRegFiscal.Text = "Regimen fiscal:"
        '
        'lblCPtxt
        '
        Me.lblCPtxt.AutoSize = True
        Me.lblCPtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCPtxt.Location = New System.Drawing.Point(891, 10)
        Me.lblCPtxt.Name = "lblCPtxt"
        Me.lblCPtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCPtxt.TabIndex = 91
        '
        'lblMatriculaDato
        '
        Me.lblMatriculaDato.AutoSize = True
        Me.lblMatriculaDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatriculaDato.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatriculaDato.Location = New System.Drawing.Point(10, 10)
        Me.lblMatriculaDato.Name = "lblMatriculaDato"
        Me.lblMatriculaDato.Size = New System.Drawing.Size(40, 15)
        Me.lblMatriculaDato.TabIndex = 52
        Me.lblMatriculaDato.Text = "Clave:"
        '
        'lblMatriculatxt
        '
        Me.lblMatriculatxt.AutoSize = True
        Me.lblMatriculatxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatriculatxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblMatriculatxt.Location = New System.Drawing.Point(77, 11)
        Me.lblMatriculatxt.Name = "lblMatriculatxt"
        Me.lblMatriculatxt.Size = New System.Drawing.Size(0, 15)
        Me.lblMatriculatxt.TabIndex = 54
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCP.Location = New System.Drawing.Point(857, 10)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(26, 15)
        Me.lblCP.TabIndex = 90
        Me.lblCP.Text = "CP:"
        '
        'lblCarreratxt
        '
        Me.lblCarreratxt.AutoSize = True
        Me.lblCarreratxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarreratxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCarreratxt.Location = New System.Drawing.Point(824, 31)
        Me.lblCarreratxt.Name = "lblCarreratxt"
        Me.lblCarreratxt.Size = New System.Drawing.Size(0, 15)
        Me.lblCarreratxt.TabIndex = 60
        Me.lblCarreratxt.Visible = False
        '
        'lblCarrera
        '
        Me.lblCarrera.AutoSize = True
        Me.lblCarrera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarrera.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCarrera.Location = New System.Drawing.Point(773, 31)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Size = New System.Drawing.Size(51, 15)
        Me.lblCarrera.TabIndex = 59
        Me.lblCarrera.Text = "Carrera:"
        Me.lblCarrera.Visible = False
        '
        'lblTurnotxt
        '
        Me.lblTurnotxt.AutoSize = True
        Me.lblTurnotxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnotxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurnotxt.Location = New System.Drawing.Point(898, 32)
        Me.lblTurnotxt.Name = "lblTurnotxt"
        Me.lblTurnotxt.Size = New System.Drawing.Size(0, 15)
        Me.lblTurnotxt.TabIndex = 58
        Me.lblTurnotxt.Visible = False
        '
        'lblRFCtxt
        '
        Me.lblRFCtxt.AutoSize = True
        Me.lblRFCtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFCtxt.Location = New System.Drawing.Point(193, 10)
        Me.lblRFCtxt.Name = "lblRFCtxt"
        Me.lblRFCtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblRFCtxt.TabIndex = 57
        '
        'lblEmailtxt
        '
        Me.lblEmailtxt.AutoSize = True
        Me.lblEmailtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailtxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmailtxt.Location = New System.Drawing.Point(332, 32)
        Me.lblEmailtxt.Name = "lblEmailtxt"
        Me.lblEmailtxt.Size = New System.Drawing.Size(0, 15)
        Me.lblEmailtxt.TabIndex = 56
        '
        'lblNombretxt
        '
        Me.lblNombretxt.AutoSize = True
        Me.lblNombretxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombretxt.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombretxt.Location = New System.Drawing.Point(69, 31)
        Me.lblNombretxt.Name = "lblNombretxt"
        Me.lblNombretxt.Size = New System.Drawing.Size(0, 15)
        Me.lblNombretxt.TabIndex = 55
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.SystemColors.Control
        Me.lblRFC.Location = New System.Drawing.Point(156, 10)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 15)
        Me.lblRFC.TabIndex = 53
        Me.lblRFC.Text = "RFC:"
        '
        'lblTurno
        '
        Me.lblTurno.AutoSize = True
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTurno.Location = New System.Drawing.Point(857, 31)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(42, 15)
        Me.lblTurno.TabIndex = 51
        Me.lblTurno.Text = "Turno:"
        Me.lblTurno.Visible = False
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmail.Location = New System.Drawing.Point(284, 32)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 15)
        Me.lblEmail.TabIndex = 50
        Me.lblEmail.Text = "Email:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.Control
        Me.lblNombre.Location = New System.Drawing.Point(10, 31)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblNombre.TabIndex = 49
        Me.lblNombre.Text = "Nombre: "
        '
        'panelAutCon
        '
        Me.panelAutCon.Controls.Add(Me.tabAutCon)
        Me.panelAutCon.Location = New System.Drawing.Point(12, 187)
        Me.panelAutCon.Name = "panelAutCon"
        Me.panelAutCon.Size = New System.Drawing.Size(1175, 473)
        Me.panelAutCon.TabIndex = 17
        Me.panelAutCon.Visible = False
        '
        'tabAutCon
        '
        Me.tabAutCon.Controls.Add(Me.tabCondonaciones)
        Me.tabAutCon.Controls.Add(Me.tabAutorizacionCaja)
        Me.tabAutCon.Controls.Add(Me.tabAutorizacionProceso)
        Me.tabAutCon.Location = New System.Drawing.Point(3, 3)
        Me.tabAutCon.Name = "tabAutCon"
        Me.tabAutCon.SelectedIndex = 0
        Me.tabAutCon.Size = New System.Drawing.Size(1169, 467)
        Me.tabAutCon.TabIndex = 0
        '
        'tabCondonaciones
        '
        Me.tabCondonaciones.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabCondonaciones.Controls.Add(Me.cbObservaciones)
        Me.tabCondonaciones.Controls.Add(Me.lblObservaciones)
        Me.tabCondonaciones.Controls.Add(Me.Button2)
        Me.tabCondonaciones.Controls.Add(Me.btnLimpiar)
        Me.tabCondonaciones.Controls.Add(Me.btnGuardarCondonaciones)
        Me.tabCondonaciones.Controls.Add(Me.GridCondonaciones)
        Me.tabCondonaciones.Controls.Add(Me.cbTipoCondonacion)
        Me.tabCondonaciones.Controls.Add(Me.lblTipoCondonacion)
        Me.tabCondonaciones.Controls.Add(Me.TreeCondonaciones)
        Me.tabCondonaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCondonaciones.Location = New System.Drawing.Point(4, 22)
        Me.tabCondonaciones.Name = "tabCondonaciones"
        Me.tabCondonaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCondonaciones.Size = New System.Drawing.Size(1161, 441)
        Me.tabCondonaciones.TabIndex = 0
        Me.tabCondonaciones.Text = "Condonación parcial o total"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.exit_40px
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(1083, 376)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 53)
        Me.Button2.TabIndex = 40
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.broom_40px
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLimpiar.Location = New System.Drawing.Point(894, 376)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(72, 53)
        Me.btnLimpiar.TabIndex = 39
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardarCondonaciones
        '
        Me.btnGuardarCondonaciones.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.save_40px
        Me.btnGuardarCondonaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarCondonaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarCondonaciones.Location = New System.Drawing.Point(989, 376)
        Me.btnGuardarCondonaciones.Name = "btnGuardarCondonaciones"
        Me.btnGuardarCondonaciones.Size = New System.Drawing.Size(72, 53)
        Me.btnGuardarCondonaciones.TabIndex = 15
        Me.btnGuardarCondonaciones.UseVisualStyleBackColor = True
        '
        'GridCondonaciones
        '
        Me.GridCondonaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridCondonaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridCondonaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCondonaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Concepto, Me.Porcentaje, Me.IDClavePago})
        Me.GridCondonaciones.Location = New System.Drawing.Point(592, 46)
        Me.GridCondonaciones.Name = "GridCondonaciones"
        Me.GridCondonaciones.Size = New System.Drawing.Size(563, 307)
        Me.GridCondonaciones.TabIndex = 12
        '
        'cbTipoCondonacion
        '
        Me.cbTipoCondonacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoCondonacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoCondonacion.FormattingEnabled = True
        Me.cbTipoCondonacion.Location = New System.Drawing.Point(166, 16)
        Me.cbTipoCondonacion.Name = "cbTipoCondonacion"
        Me.cbTipoCondonacion.Size = New System.Drawing.Size(402, 24)
        Me.cbTipoCondonacion.TabIndex = 11
        '
        'lblTipoCondonacion
        '
        Me.lblTipoCondonacion.AutoSize = True
        Me.lblTipoCondonacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCondonacion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblTipoCondonacion.Location = New System.Drawing.Point(11, 17)
        Me.lblTipoCondonacion.Name = "lblTipoCondonacion"
        Me.lblTipoCondonacion.Size = New System.Drawing.Size(155, 18)
        Me.lblTipoCondonacion.TabIndex = 10
        Me.lblTipoCondonacion.Text = "Tipo de condonación: "
        '
        'TreeCondonaciones
        '
        Me.TreeCondonaciones.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TreeCondonaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeCondonaciones.ForeColor = System.Drawing.SystemColors.Control
        Me.TreeCondonaciones.Location = New System.Drawing.Point(14, 46)
        Me.TreeCondonaciones.Name = "TreeCondonaciones"
        Me.TreeCondonaciones.Size = New System.Drawing.Size(554, 307)
        Me.TreeCondonaciones.StateImageList = Me.ImageListTree
        Me.TreeCondonaciones.TabIndex = 9
        '
        'ImageListTree
        '
        Me.ImageListTree.ImageStream = CType(resources.GetObject("ImageListTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTree.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListTree.Images.SetKeyName(0, "unchecked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(1, "checked_checkbox_40px.png")
        Me.ImageListTree.Images.SetKeyName(2, "folder_40px.png")
        '
        'tabAutorizacionCaja
        '
        Me.tabAutorizacionCaja.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabAutorizacionCaja.Controls.Add(Me.btnGuardarAutorizacionCaja)
        Me.tabAutorizacionCaja.Controls.Add(Me.GridAutorizacionCaja)
        Me.tabAutorizacionCaja.Controls.Add(Me.treeAutorizacionCaja)
        Me.tabAutorizacionCaja.Location = New System.Drawing.Point(4, 22)
        Me.tabAutorizacionCaja.Name = "tabAutorizacionCaja"
        Me.tabAutorizacionCaja.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAutorizacionCaja.Size = New System.Drawing.Size(1161, 441)
        Me.tabAutorizacionCaja.TabIndex = 1
        Me.tabAutorizacionCaja.Text = "Autorización de Caja"
        '
        'btnGuardarAutorizacionCaja
        '
        Me.btnGuardarAutorizacionCaja.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.descargar
        Me.btnGuardarAutorizacionCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGuardarAutorizacionCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarAutorizacionCaja.Location = New System.Drawing.Point(1083, 373)
        Me.btnGuardarAutorizacionCaja.Name = "btnGuardarAutorizacionCaja"
        Me.btnGuardarAutorizacionCaja.Size = New System.Drawing.Size(72, 53)
        Me.btnGuardarAutorizacionCaja.TabIndex = 17
        Me.btnGuardarAutorizacionCaja.UseVisualStyleBackColor = True
        '
        'GridAutorizacionCaja
        '
        Me.GridAutorizacionCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridAutorizacionCaja.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridAutorizacionCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridAutorizacionCaja.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.GridAutorizacionCaja.Location = New System.Drawing.Point(592, 15)
        Me.GridAutorizacionCaja.Name = "GridAutorizacionCaja"
        Me.GridAutorizacionCaja.Size = New System.Drawing.Size(563, 330)
        Me.GridAutorizacionCaja.TabIndex = 16
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Node"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Concepto"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'treeAutorizacionCaja
        '
        Me.treeAutorizacionCaja.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.treeAutorizacionCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeAutorizacionCaja.ForeColor = System.Drawing.SystemColors.Control
        Me.treeAutorizacionCaja.Location = New System.Drawing.Point(16, 15)
        Me.treeAutorizacionCaja.Name = "treeAutorizacionCaja"
        Me.treeAutorizacionCaja.Size = New System.Drawing.Size(568, 411)
        Me.treeAutorizacionCaja.StateImageList = Me.ImageListTree
        Me.treeAutorizacionCaja.TabIndex = 10
        '
        'tabAutorizacionProceso
        '
        Me.tabAutorizacionProceso.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tabAutorizacionProceso.Controls.Add(Me.Button1)
        Me.tabAutorizacionProceso.Controls.Add(Me.DataGridView1)
        Me.tabAutorizacionProceso.Controls.Add(Me.TreeView1)
        Me.tabAutorizacionProceso.Location = New System.Drawing.Point(4, 22)
        Me.tabAutorizacionProceso.Name = "tabAutorizacionProceso"
        Me.tabAutorizacionProceso.Size = New System.Drawing.Size(1161, 441)
        Me.tabAutorizacionProceso.TabIndex = 2
        Me.tabAutorizacionProceso.Text = "Autorización de Proceso"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.NEducacionContinuaUX.My.Resources.Resources.descargar
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1083, 373)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 53)
        Me.Button1.TabIndex = 18
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.DataGridView1.Location = New System.Drawing.Point(592, 15)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(563, 330)
        Me.DataGridView1.TabIndex = 17
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Node"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Concepto"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ForeColor = System.Drawing.SystemColors.Control
        Me.TreeView1.Location = New System.Drawing.Point(16, 15)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(568, 411)
        Me.TreeView1.StateImageList = Me.ImageListTree
        Me.TreeView1.TabIndex = 11
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.ForeColor = System.Drawing.SystemColors.Control
        Me.lblObservaciones.Location = New System.Drawing.Point(11, 365)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(112, 18)
        Me.lblObservaciones.TabIndex = 41
        Me.lblObservaciones.Text = "Observaciones:"
        Me.lblObservaciones.Visible = False
        '
        'cbObservaciones
        '
        Me.cbObservaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbObservaciones.FormattingEnabled = True
        Me.cbObservaciones.Location = New System.Drawing.Point(14, 391)
        Me.cbObservaciones.Name = "cbObservaciones"
        Me.cbObservaciones.Size = New System.Drawing.Size(554, 24)
        Me.cbObservaciones.TabIndex = 42
        Me.cbObservaciones.Visible = False
        '
        'Concepto
        '
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        '
        'Porcentaje
        '
        Me.Porcentaje.FillWeight = 15.0!
        Me.Porcentaje.HeaderText = "Porcentaje"
        Me.Porcentaje.Name = "Porcentaje"
        '
        'IDClavePago
        '
        Me.IDClavePago.HeaderText = "IDClavePago"
        Me.IDClavePago.Name = "IDClavePago"
        Me.IDClavePago.Visible = False
        '
        'AutorizacionCondonacionEDC
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1199, 672)
        Me.Controls.Add(Me.panelAutCon)
        Me.Controls.Add(Me.panelDatos)
        Me.Controls.Add(Me.panelBusqueda)
        Me.Controls.Add(Me.lblNombreVentana)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AutorizacionCondonacionEDC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AutorizacionCondonacionEDC"
        Me.panelBusqueda.ResumeLayout(False)
        Me.panelBusqueda.PerformLayout()
        Me.panelDatos.ResumeLayout(False)
        Me.panelDatos.PerformLayout()
        Me.panelAutCon.ResumeLayout(False)
        Me.tabAutCon.ResumeLayout(False)
        Me.tabCondonaciones.ResumeLayout(False)
        Me.tabCondonaciones.PerformLayout()
        CType(Me.GridCondonaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAutorizacionCaja.ResumeLayout(False)
        CType(Me.GridAutorizacionCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAutorizacionProceso.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreVentana As Label
    Friend WithEvents panelBusqueda As Panel
    Friend WithEvents cbExterno As ComboBox
    Friend WithEvents lblBusquedaNombre As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtMatricula As TextBox
    Friend WithEvents lblMatricula As Label
    Friend WithEvents panelDatos As Panel
    Friend WithEvents panelAutCon As Panel
    Friend WithEvents tabAutCon As TabControl
    Friend WithEvents tabCondonaciones As TabPage
    Friend WithEvents tabAutorizacionCaja As TabPage
    Friend WithEvents tabAutorizacionProceso As TabPage
    Friend WithEvents ImageListTree As ImageList
    Friend WithEvents lblTipoCondonacion As Label
    Friend WithEvents TreeCondonaciones As TreeView
    Friend WithEvents cbTipoCondonacion As ComboBox
    Friend WithEvents GridCondonaciones As DataGridView
    Friend WithEvents btnGuardarCondonaciones As Button
    Friend WithEvents btnGuardarAutorizacionCaja As Button
    Friend WithEvents GridAutorizacionCaja As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents treeAutorizacionCaja As TreeView
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents lblTurnotxt As Label
    Friend WithEvents lblRFCtxt As Label
    Friend WithEvents lblEmailtxt As Label
    Friend WithEvents lblNombretxt As Label
    Friend WithEvents lblMatriculatxt As Label
    Friend WithEvents lblRFC As Label
    Friend WithEvents lblMatriculaDato As Label
    Friend WithEvents lblTurno As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblNombre As Label
    Friend WithEvents lblCarreratxt As Label
    Friend WithEvents lblCarrera As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents lblRegFiscaltxt As Label
    Friend WithEvents lblRegFiscal As Label
    Friend WithEvents lblCPtxt As Label
    Friend WithEvents lblCP As Label
    Friend WithEvents lblCFDItxt As Label
    Friend WithEvents lblCFDI As Label
    Friend WithEvents lblDireccion As Label
    Friend WithEvents lblDirecciontxt As Label
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents cbObservaciones As ComboBox
    Friend WithEvents Concepto As DataGridViewTextBoxColumn
    Friend WithEvents Porcentaje As DataGridViewTextBoxColumn
    Friend WithEvents IDClavePago As DataGridViewTextBoxColumn
End Class
