Imports System.Text.RegularExpressions

Public Class AutorizacionCondonacionEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim ac As AutorizacionCondonacionController = New AutorizacionCondonacionController()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim ca As CargosController = New CargosController()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim combo_filtro As String

    Private Sub AutorizacionCondonacionEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ac.llenarComboboxes(cbTipoCondonacion)
    End Sub

    Private Sub cbTipoCondonacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoCondonacion.SelectionChangeCommitted
        ac.ActualizarArbolCondonacion(TreeCondonaciones, cbTipoCondonacion.Text, Matricula, tipoMatricula)
        Dim tipoObservacion As Integer
        If (cbTipoCondonacion.SelectedIndex = 0) Then
            tipoObservacion = 5
        ElseIf (cbTipoCondonacion.SelectedIndex = 1) Then
            tipoObservacion = 4
        End If
        Dim tableObservaciones As DataTable = db.getDataTableFromSQL($"SELECT ID, Observacion FROM ing_CatObservacionesCancelacion WHERE Activo = 1 AND ID_TipoOtraObservacion = {tipoObservacion}")
        ComboboxService.llenarCombobox(cbObservaciones, tableObservaciones, "ID", "Observacion")
        lblObservaciones.Visible = True
        cbObservaciones.Visible = True

        GridCondonaciones.Rows.Clear()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.limpiar()
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        lblMatriculatxt.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelAutCon, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelAutCon, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCP, lblRegFiscal, lblCFDItxt, lblDireccion)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelAutCon, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCP, lblRegFiscal, lblCFDItxt, lblDireccion)
        End If
        ''ac.ActualizarArbolAutorizacionCaja(treeAutorizacionCaja, Matricula, tipoMatricula)
    End Sub

    Private Sub TreeCondonaciones_DoubleClick(sender As Object, e As EventArgs) Handles TreeCondonaciones.DoubleClick
        Me.NodosCondonaciones()
    End Sub

    Private Sub treeAutorizacionCaja_DoubleClick(sender As Object, e As EventArgs) Handles treeAutorizacionCaja.DoubleClick
        Me.NodosAutorizacionCaja()
    End Sub

    Sub NodosCondonaciones()
        If (TreeCondonaciones.SelectedNode Is Nothing) Then
            Exit Sub
        ElseIf (TreeCondonaciones.SelectedNode.StateImageIndex = 2) Then
            Exit Sub
        End If

        Dim index As Integer = TreeCondonaciones.SelectedNode.Index
        If (TreeCondonaciones.SelectedNode.Checked = False) Then
            If (cbTipoCondonacion.Text = "CONDONACIÓN PARCIAL") Then
                Me.Enabled = False
                Dim NombreAutorizacion As String = TreeCondonaciones.SelectedNode.Parent.Text
                Dim NombreClave As String = TreeCondonaciones.SelectedNode.Parent.Text
                ObjectBagService.setItem("Text", TreeCondonaciones.SelectedNode.Text)
                ModalAutConPorcentaje.MdiParent = PrincipalView
                ModalAutConPorcentaje.Show()
            ElseIf (cbTipoCondonacion.Text = "CONDONACIÓN TOTAL") Then
                TreeCondonaciones.SelectedNode.Checked = True
                TreeCondonaciones.SelectedNode.SelectedImageIndex = 1
                Dim IDClavePago As Integer
                If (TreeCondonaciones.SelectedNode.Parent.Text = "Congresos") Then
                    IDClavePago = 3
                ElseIf (TreeCondonaciones.SelectedNode.Parent.Text = "Pagos Opcionales") Then
                    IDClavePago = 2
                ElseIf (TreeCondonaciones.SelectedNode.Parent.Text = "Inscripción") Then
                    IDClavePago = 6
                ElseIf (TreeCondonaciones.SelectedNode.Parent.Text = "Colegiaturas") Then
                    IDClavePago = 4
                ElseIf (TreeCondonaciones.SelectedNode.Parent.Text = "Pago Unico") Then
                    IDClavePago = 5
                ElseIf (TreeCondonaciones.SelectedNode.Parent.Text = "Recargos") Then
                    IDClavePago = 7
                End If
                GridCondonaciones.Rows.Add(TreeCondonaciones.SelectedNode.Text, 100.0)
                End If
            Else
            TreeCondonaciones.SelectedNode.Checked = False
            TreeCondonaciones.SelectedNode.SelectedImageIndex = 0

            For x = 0 To GridCondonaciones.Rows.Count() - 1
                If (GridCondonaciones.Rows(x).Cells(0).Value = TreeCondonaciones.SelectedNode.Text) Then
                    GridCondonaciones.Rows.RemoveAt(x)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Sub NodosAutorizacionCaja()
        If (treeAutorizacionCaja.SelectedNode Is Nothing) Then
            Exit Sub
        ElseIf (treeAutorizacionCaja.SelectedNode.StateImageIndex = 2) Then
            Exit Sub
        End If

        Dim index As Integer = treeAutorizacionCaja.SelectedNode.Index
        If (treeAutorizacionCaja.SelectedNode.Checked = False) Then
            treeAutorizacionCaja.SelectedNode.Checked = True
            treeAutorizacionCaja.SelectedNode.SelectedImageIndex = 1
            Dim NombreAutorizacion As String = treeAutorizacionCaja.SelectedNode.Parent.Text
            Dim NombreClave As String = treeAutorizacionCaja.SelectedNode.Parent.Parent.Text
            Dim ID_res As Integer = ac.ObtenerIDResAutCon(1, NombreAutorizacion, NombreClave)
            GridAutorizacionCaja.Rows.Add(ID_res, treeAutorizacionCaja.SelectedNode.Text)
        Else
            treeAutorizacionCaja.SelectedNode.Checked = False
            treeAutorizacionCaja.SelectedNode.SelectedImageIndex = 0
            For x = 0 To GridAutorizacionCaja.Rows.Count() - 1
                If (GridAutorizacionCaja.Rows(x).Cells(1).Value = treeAutorizacionCaja.SelectedNode.Text) Then
                    GridAutorizacionCaja.Rows.RemoveAt(x)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Sub limpiar()
        lblMatriculatxt.Text = ""
        lblNombretxt.Text = ""
        lblEmailtxt.Text = ""
        lblCarreratxt.Text = ""
        lblTurnotxt.Text = ""
        TreeCondonaciones.Nodes.Clear()
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        AutorizacionCondonacionEDC_Load(Me, Nothing)
        txtMatricula.Focus()
    End Sub

    Private Sub btnGuardarCondonaciones_Click(sender As Object, e As EventArgs) Handles btnGuardarCondonaciones.Click
        ac.GuardarCondonaciones(Matricula, GridCondonaciones, cbTipoCondonacion.SelectedIndex)
    End Sub

    Private Sub btnGuardarAutorizacionCaja_Click(sender As Object, e As EventArgs) Handles btnGuardarAutorizacionCaja.Click
        ac.GuardarAutorizacionesCaja(Matricula, GridAutorizacionCaja)
    End Sub

    Public Sub keypress_textos_cmb(ByVal TXT As ComboBox, ByVal e As KeyPressEventArgs)
        Try

            Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\:\´]", RegexOptions.IgnoreCase)
            Dim KeyAscii As Short = Asc(e.KeyChar)

            If KeyAscii <> 8 Then
                e.Handled = re.IsMatch(e.KeyChar)
            End If

        Catch ex As Exception
            MsgBox("Error: en la validación de este campo, por favor verifique o comuniquese con sistemas", MsgBoxStyle.Exclamation, "Error en datos")
        End Try

    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectionChangeCommitted
        Try
            If (cbExterno.SelectedIndex <> -1) Then
                txtMatricula.Text = cbExterno.SelectedValue
                btnBuscar.PerformClick()
                txtMatricula.Clear()
                cbExterno.Text = ""
                combo_filtro = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbExterno_KeyUp(sender As Object, e As KeyEventArgs) Handles cbExterno.KeyUp
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            combo_filtro = cbExterno.Text
        End If
    End Sub

    Private Sub cbExterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbExterno.KeyPress
        Me.keypress_textos_cmb(cbExterno, e)
        Dim kc As KeysConverter = New KeysConverter()
        Dim encontrar As String = cbExterno.Text

        Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\´]", RegexOptions.IgnoreCase)
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If re.IsMatch(e.KeyChar) = False Then

            combo_filtro += kc.ConvertToString(e.KeyChar)
            Dim filtro As String = cbExterno.Text
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"(SELECT RC.clave_cliente, UPPER('Congreso: ' + C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                                INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
    											    WHERE (C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno LIKE '%{filtro}%'))

    											UNION
                                                                (SELECT CL.clave_cliente, UPPER('Externo: '+  C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
                                                                INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
    										     	WHERE (C.nombre + ' ' +E.paterno + ' ' +E.materno LIKE '%{filtro}%'))")
            ComboboxService.llenarCombobox(cbExterno, tableFiltro, "clave_cliente", "NombreCliente")
            cbExterno.SelectedValue = -1
            cbExterno.Text = combo_filtro
            cbExterno.DroppedDown = True
            cbExterno.SelectionStart = encontrar.Length
            cbExterno.SelectionLength = cbExterno.Text.Length - cbExterno.SelectionStart
        Else
            If Asc(e.KeyChar) = Keys.Space Then
                combo_filtro += " "
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class