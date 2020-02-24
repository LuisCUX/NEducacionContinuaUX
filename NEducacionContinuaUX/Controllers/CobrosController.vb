Public Class CobrosController
    Dim db As DataBaseService = New DataBaseService()

    Function validarMatricula(Matricula As String) As String
        If (Matricula.Length() - 9) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            Return "False"
        Else
            If (Matricula.Substring(0, 2) = "UX") Then
                Return "UX"
            ElseIf (Matricula.Substring(0, 2) = "EC" Or Matricula.Substring(0, 2) = "EX") Then
                Return "EC"
            End If
        End If

        Return "False"
    End Function

    Sub buscarMatriculaUX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim exists As String = db.exectSQLQueryScalar($"SELECT nombre FROM ux.dbo.dae_catAlumnos WHERE matricula = '{Matricula}'")
        Dim sit_esc As String = db.exectSQLQueryScalar($"SELECT sit_esc FROM ux.dbo.dae_catAlumnos WHERE matricula = '{Matricula}'")

        If (exists = Nothing) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            MainAsignacionPagosOpcionalesEDC.Reiniciar()
            Exit Sub
        End If

        If (sit_esc = "B") Then
            MessageBox.Show("La matricula ingresada se encuentra dada de baja, favor de ingresar una matricula valida")
            MainAsignacionPagosOpcionalesEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosUX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
    End Sub

    Sub llenarPanelDatosUX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim nombre As String = db.exectSQLQueryScalar($"SELECT UPPER(nombre + ' ' + ap_pat + ' ' + ap_mat) As NombreAlumno FROM ux.dbo.dae_catAlumnos WHERE Matricula = '{Matricula}'")
        Dim email As String = db.exectSQLQueryScalar($"SELECT email FROM ux.dbo.dae_catAlumnos WHERE Matricula = '{Matricula}'")
        Dim carrera As String = db.exectSQLQueryScalar($"SELECT nombre FROM ux.dbo.dae_catCarreras WHERE clave = '{Matricula.Substring(4, 2)}'")

        Dim NT As String() = UtilitiesService.getNivelTurno(Matricula)
        Dim Turno As String = db.exectSQLQueryScalar($"SELECT Turno FROM mov_CatTurno WHERE clave = '{NT(1)}'")

        txtNombre.Text = nombre
        txtEmail.Text = email
        txtCarrera.Text = carrera
        txtTurno.Text = Turno

        panelDatos.Visible = True
        panelCobros.Visible = True
    End Sub

    Sub buscarPagosOpcionales(Tree As TreeView, Matricula As String, TipoMatricula As String)
        Dim tabla As String
        If (TipoMatricula = "UX") Then
            tabla = "ing_AsignacionPagoOpcionalAlumno"
        ElseIf (TipoMatricula = "EC") Then
            tabla = "ing_AsignacionPagoOpcionalExterno"
        End If
        Dim tablePagosOpcionales As DataTable = db.getDataTableFromSQL($"SELECT A.ID, C.Clave, P.Descripcion, A.costoUnitario, A.Cantidad, P.considerarIVA, P.AgregaIVA, P.ExentaIVA FROM {tabla} AS A
                                                                        INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                                        INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                                        INNER JOIN ing_CatClavesPagos AS C ON C.ID = 1
                                                                        WHERE A.Matricula = '{Matricula}' AND A.Activo = 1")
        For Each item As DataRow In tablePagosOpcionales.Rows

            Dim result As String = $"{item("ID")}|{item("Clave")}|{item("Descripcion")}|{item("costoUnitario")}|{item("Cantidad")}"
        Next
    End Sub

    Function calcularTotal(costoUnitario As Decimal, cantidad As Integer, consideraIVA As Boolean, agregaIVA As Boolean, exentaIVA As Boolean) As String
        Dim total As Decimal

        If (consideraIVA = True And agregaIVA = False And exentaIVA = False) Then

        ElseIf (consideraIVA = False And agregaIVA = True And exentaIVA = False) Then

        ElseIf (consideraIVA = False And agregaIVA = False And exentaIVA = True) Then

        End If

        Return Format(CDec(total), "#####0.00")
    End Function
End Class
