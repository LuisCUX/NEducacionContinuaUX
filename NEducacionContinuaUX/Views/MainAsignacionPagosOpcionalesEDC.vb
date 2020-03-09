Public Class MainAsignacionPagosOpcionalesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim MatriculaUX As String
    Dim ap As AsignacionPagosOpcionalesController = New AsignacionPagosOpcionalesController()
    Private Sub AsignacionPagosOpcionalesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        tipoMatricula = ap.validarMatricula(Matricula)
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            MatriculaUX = db.exectSQLQueryScalar($"SELECT MatriculaUX FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")
            ap.buscarMatriculaUX(matriculaux, panelDatos, panelAsignacion, txtNombre, txtEmail, txtCarrera, txtTurno)
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
End Class