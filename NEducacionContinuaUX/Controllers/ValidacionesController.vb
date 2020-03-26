Public Class ValidacionesController
    Dim db As DataBaseService = New DataBaseService()
    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------VALIDA EL TIPO DE MATRICULA--------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------

    Function validarMatricula(Matricula As String) As String
        If (Matricula.Length() < 9 Or Matricula.Length() > 9) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            Return "False"
        Else
            Dim MatriculaUX As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")
            If (MatriculaUX > 0) Then
                Return "UX"
            ElseIf (Matricula.Substring(0, 2) = "EX") Then
                Return "EX"
            ElseIf (Matricula.Substring(0, 2) = "EC") Then
                Return "EC"
            End If
        End If

        Return "False"
    End Function


    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------BUSCA MATRICULA MATRICULA----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaUX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim matriculaUX As String = db.exectSQLQueryScalar($"SELECT MatriculaUX FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")
        Dim exists As String = db.exectSQLQueryScalar($"SELECT nombre FROM ux.dbo.dae_catAlumnos WHERE matricula = '{matriculaUX}'")
        Dim sit_esc As String = db.exectSQLQueryScalar($"SELECT sit_esc FROM ux.dbo.dae_catAlumnos WHERE matricula = '{matriculaUX}'")

        If (exists = Nothing) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        If (sit_esc = "B") Then
            MessageBox.Show("La matricula ingresada se encuentra dada de baja, favor de ingresar una matricula valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosUX(matriculaUX, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------------LLENA PANEL DE DATOS UX----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
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

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------BUSCA MATRICULA MATRICULA EXTERNA------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaEX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id_clave FROM portal_clave WHERE clave_cliente = '{Matricula}'")

        If (exists < 1) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosEX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
    End Sub



    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------LLENA PANEL DE DATOS EXTERNA-------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosEX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT UPPER(C.nombre + ' ' + EX.paterno + ' ' + EX.materno)As Nombre, C.correo FROM portal_cliente AS C 
                                                               INNER JOIN portal_registroExterno AS EX ON C.id_cliente = EX.id_cliente
                                                               WHERE EX.clave_cliente = '{Matricula}'")
        For Each item As DataRow In tableDatos.Rows
            txtNombre.Text = item("Nombre")
            txtEmail.Text = item("correo")
        Next
        txtCarrera.Text = ""
        txtTurno.Text = ""

        panelDatos.Visible = True
        panelCobros.Visible = True
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------BUSCA MATRICULA MATRICULA CONGRESO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaEC(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id_clave FROM portal_clave WHERE clave_cliente = '{Matricula}'")

        If (exists < 1) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosEC(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
    End Sub



    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------LLENA PANEL DE DATOS CONGRESO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosEC(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT UPPER(C.nombre + ' ' + R.apellido_paterno + ' ' + R.apellido_materno) AS Nombre, C.correo FROM portal_cliente AS C 
                                                               INNER JOIN portal_registroCongreso AS R ON R.id_cliente = C.id_cliente
                                                               WHERE R.clave_cliente = '{Matricula}'")
        For Each item As DataRow In tableDatos.Rows
            txtNombre.Text = item("Nombre")
            txtEmail.Text = item("correo")
        Next
        txtCarrera.Text = ""
        txtTurno.Text = ""

        panelDatos.Visible = True
        panelCobros.Visible = True
    End Sub
End Class
