Imports System.Text.RegularExpressions

Public Class MainAsignacionPagosOpcionalesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim MatriculaUX As String
    Dim ap As AsignacionPagosOpcionalesController = New AsignacionPagosOpcionalesController()
    Dim combo_filtro As String
    Private Sub AsignacionPagosOpcionalesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno) As NombreExterno FROM portal_registroExterno AS E
        '                                                         INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
        '                                                         INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
        '                                                         ORDER BY C.nombre")
        'ComboboxService.llenarCombobox(cbExterno, tableExternos, "clave_cliente", "NombreExterno")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        tipoMatricula = ap.validarMatricula(Matricula)
        txtMatriculaDato.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            MatriculaUX = db.exectSQLQueryScalar($"SELECT MatriculaUX FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")
            ap.buscarMatriculaUX(MatriculaUX, panelDatos, panelAsignacion, txtNombre, txtEmail, txtCarrera, txtTurno)
            Dim tablePagos As DataTable = db.getDataTableFromSQL($"SELECT A.ID, P.Nombre, A.costoUnitario, A.Cantidad, (costoUnitario * Cantidad) AS Total FROM ing_AsignacionPagoOpcionalAlumno AS A
                                                                  INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                                  INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                                  WHERE A.Activo = 1 AND A.Matricula = '{Matricula}'")
            GridPagosAsignados.DataSource = Nothing
            GridPagosAsignados.DataSource = tablePagos
        ElseIf (tipoMatricula = "EC") Then
            ap.buscarMatriculaEX(Matricula, panelDatos, panelAsignacion, txtNombre, txtEmail, txtCarrera, txtTurno)
            Dim tablePagosEX As DataTable = db.getDataTableFromSQL($"SELECT A.ID, P.Nombre, A.costoUnitario, A.Cantidad, (costoUnitario * Cantidad) AS Total FROM ing_AsignacionPagoOpcionalExterno AS A
                                                                  INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                                  INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                                  WHERE A.Activo = 1 AND A.MatriculaExterna = '{Matricula}'")
            GridPagosAsignados.DataSource = Nothing
            GridPagosAsignados.DataSource = tablePagosEX
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ObjectBagService.setItem("Matricula", Matricula)
        ObjectBagService.setItem("tipoMatricula", tipoMatricula)
        ObjectBagService.setItem("tipoVentana", "Nuevo")
        ObjectBagService.setItem("MatriculaUX", MatriculaUX)
        ModalAsignacionPagosOpcionalesEDC.MdiParent = PrincipalView
        ModalAsignacionPagosOpcionalesEDC.Show()
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        AsignacionPagosOpcionalesEDC_Load(Me, Nothing)
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub GridPagosAsignados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridPagosAsignados.CellClick
        Dim ID As Integer = Convert.ToInt32(GridPagosAsignados.Rows(e.RowIndex).Cells(0).Value)
        ObjectBagService.setItem("Matricula", Matricula)
        ObjectBagService.setItem("MatriculaUX", MatriculaUX)
        ObjectBagService.setItem("tipoVentana", "Edicion")
        ObjectBagService.setItem("tipoMatricula", tipoMatricula)
        ObjectBagService.setItem("IDPago", ID)
        ModalAsignacionPagosOpcionalesEDC.MdiParent = PrincipalView
        ModalAsignacionPagosOpcionalesEDC.Show()
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
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"
                                                                SELECT CL.clave_cliente, UPPER('Externo: '+  C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
                                                                INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
    										     	WHERE (C.nombre + ' ' +E.paterno + ' ' +E.materno LIKE '%{filtro}%')")
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
End Class