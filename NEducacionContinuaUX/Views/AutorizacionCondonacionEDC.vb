Public Class AutorizacionCondonacionEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim ac As AutorizacionCondonacionController = New AutorizacionCondonacionController()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim ca As CargosController = New CargosController()
    Dim va As ValidacionesController = New ValidacionesController()

    Private Sub AutorizacionCondonacionEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ac.llenarComboboxes(cbTipoCondonacion)
    End Sub

    Private Sub cbTipoCondonacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoCondonacion.SelectionChangeCommitted
        ac.ActualizarArbolCondonacion(TreeCondonaciones, cbTipoCondonacion.Text, Matricula, tipoMatricula)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.limpiar()
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        txtMatriculaDato.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelAutCon, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelAutCon, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelAutCon, txtNombre, txtEmail, txtCarrera, txtTurno)
        End If
    End Sub

    Private Sub TreeCondonaciones_DoubleClick(sender As Object, e As EventArgs) Handles TreeCondonaciones.DoubleClick
        Me.NodosCondonaciones()
    End Sub


    Sub NodosCondonaciones()
        If (TreeCondonaciones.SelectedNode Is Nothing) Then
            Exit Sub
        ElseIf (TreeCondonaciones.SelectedNode.StateImageIndex = 2) Then
            Exit Sub
        End If

        Dim index As Integer = TreeCondonaciones.SelectedNode.Index
        If (TreeCondonaciones.SelectedNode.Checked = False) Then
            TreeCondonaciones.SelectedNode.Checked = True
            TreeCondonaciones.SelectedNode.SelectedImageIndex = 1
            If (cbTipoCondonacion.Text = "CONDONACIÓN PARCIAL") Then
                Me.Enabled = False
                Dim NombreAutorizacion As String = TreeCondonaciones.SelectedNode.Parent.Text
                Dim NombreClave As String = TreeCondonaciones.SelectedNode.Parent.Parent.Text
                Dim ID_res As Integer = ac.ObtenerIDResAutCon(4, NombreAutorizacion, NombreClave)
                ObjectBagService.setItem("ID_RES", ID_res)
                ObjectBagService.setItem("Text", TreeCondonaciones.SelectedNode.Text)
                ModalAutConPorcentaje.MdiParent = PrincipalView
                ModalAutConPorcentaje.Show()
            ElseIf (cbTipoCondonacion.Text = "CONDONACIÓN TOTAL") Then
                Dim NombreAutorizacion As String = TreeCondonaciones.SelectedNode.Parent.Text
                Dim NombreClave As String = TreeCondonaciones.SelectedNode.Parent.Parent.Text
                Dim ID_res As Integer = ac.ObtenerIDResAutCon(4, NombreAutorizacion, NombreClave)
                GridCondonaciones.Rows.Add(ID_res, TreeCondonaciones.SelectedNode.Text, 100.0)
            End If
        Else
            TreeCondonaciones.SelectedNode.Checked = False
            TreeCondonaciones.SelectedNode.SelectedImageIndex = 0

            For x = 0 To GridCondonaciones.Rows.Count() - 1
                If (GridCondonaciones.Rows(x).Cells(1).Value = TreeCondonaciones.SelectedNode.Text) Then
                    GridCondonaciones.Rows.RemoveAt(x)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Sub limpiar()
        txtMatriculaDato.Clear()
        txtNombre.Clear()
        txtEmail.Clear()
        txtCarrera.Clear()
        txtTurno.Clear()
        TreeCondonaciones.Nodes.Clear()
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        AutorizacionCondonacionEDC_Load(Me, Nothing)
    End Sub

    Private Sub btnGuardarCondonaciones_Click(sender As Object, e As EventArgs) Handles btnGuardarCondonaciones.Click
        ac.GuardarCondonaciones(Matricula, GridCondonaciones)
    End Sub

    Private Sub rbExterno_CheckedChanged(sender As Object, e As EventArgs) Handles rbExterno.CheckedChanged
        cbExterno.DataSource = Nothing
        Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreExterno FROM portal_registroExterno AS E
                                                                 INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                 INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
                                                                 ORDER BY C.nombre")
        ComboboxService.llenarCombobox(cbExterno, tableExternos, "clave_cliente", "NombreExterno")
    End Sub

    Private Sub rbEDC_CheckedChanged(sender As Object, e As EventArgs) Handles rbEDC.CheckedChanged
        Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
                                                            ORDER BY NombreCliente")
        ComboboxService.llenarCombobox(cbExterno, tableEDC, "clave_cliente", "NombreCliente")
    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectionChangeCommitted
        Try
            Me.limpiar()
            txtMatricula.Text = cbExterno.SelectedValue
            btnBuscar.PerformClick()
            txtMatricula.Clear()
        Catch ex As Exception

        End Try
    End Sub
End Class