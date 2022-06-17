Imports System.Text.RegularExpressions

Public Class ValidacionesController
    Dim db As DataBaseService = New DataBaseService()
    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------VALIDA EL TIPO DE MATRICULA--------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------

    Function validarMatricula(Matricula As String) As String
        If (Matricula.Length() < 9 Or Matricula.Length() > 9) Then
            MessageBox.Show("La clave ingresada no existe, favor de ingresar una clave valida")
            Return "False"
        Else
            Dim MatriculaUX As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")
            If (MatriculaUX > 0) Then
                Return "EX"
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
    Sub buscarMatriculaUX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As Label, txtEmail As Label, txtCarrera As Label, txtTurno As Label)
        Dim matriculaUX As String = db.exectSQLQueryScalar($"SELECT MatriculaUX FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")
        Dim exists As String = db.exectSQLQueryScalar($"SELECT nombre FROM ux.dbo.dae_catAlumnos WHERE matricula = '{matriculaUX}'")
        Dim sit_esc As String = db.exectSQLQueryScalar($"SELECT sit_esc FROM ux.dbo.dae_catAlumnos WHERE matricula = '{matriculaUX}'")

        If (exists = Nothing) Then
            MessageBox.Show("La clave ingresada no existe, favor de ingresar una clave valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        If (sit_esc = "B") Then
            MessageBox.Show("La clave ingresada se encuentra dada de baja, favor de ingresar una clave valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosUX(matriculaUX, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------------LLENA PANEL DE DATOS UX----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosUX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As Label, txtEmail As Label, txtCarrera As Label, txtTurno As Label)
        Dim nombre As String = db.exectSQLQueryScalar($"SELECT UPPER(nombre + ' ' + ap_pat + ' ' + ap_mat) As NombreAlumno FROM ux.dbo.dae_catAlumnos WHERE Matricula = '{Matricula}'")
        nombre = Regex.Replace(nombre, " {2,}", " ")
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
    ''-------------------------------------------------------BUSCA MATRICULA EXTERNA----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaEX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As Label, txtEmail As Label, txtCarrera As Label, txtTurno As Label, txtRFC As Label, lblCP As Label, lblRegFiscal As Label, lblUsoCFDI As Label, lblDireccion As Label)
        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")

        If (exists < 1) Then
            MessageBox.Show("La clave ingresada no existe, favor de ingresar una clave valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosEX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno, txtRFC, lblCP, lblRegFiscal, lblUsoCFDI, lblDireccion)
    End Sub



    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------LLENA PANEL DE DATOS EXTERNA-------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosEX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As Label, txtEmail As Label, txtCarrera As Label, txtTurno As Label, txtRFC As Label, lblCP As Label, lblRegFiscal As Label, lblUsoCFDI As Label, lblDireccion As Label)
        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno)As Nombre, RE.correo, RFC.rfc, REG.ID_Contador, CF.clave_usoCFDI, RE.cp FROM portal_reRFC AS RE
                                                               INNER JOIN portal_registroExterno AS E ON E.id_registro = RE.id_registro
                                                               INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                               INNER JOIN ing_res_usoCFDI_regimenFiscal AS RF ON RF.id_res_usoCFDI_regimenFiscal = RE.id_res_cfdi_regimen
                                                               LEFT JOIN ing_cat_usoCFDI AS CF ON CF.clave_usoCFDI = RF.clave_usoCFDI
                                                               LEFT JOIN ing_Cat_RegFis AS REG ON REG.ID_Contador = RF.clave_regimeFiscal
                                                               INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RE.id_rfc AND RE.Activo = 1
                                                               WHERE E.clave_cliente = '{Matricula}'")
        For Each item As DataRow In tableDatos.Rows
            Dim nombre As String = item("Nombre")
            nombre = Regex.Replace(nombre, " {2,}", " ")
            txtNombre.Text = nombre
            txtEmail.Text = item("correo")
            txtRFC.Text = item("rfc")
            If (item("rfc") = "XAXX010101000") Then
                lblCP.Text = EnviromentService.CP
            Else
                lblCP.Text = item("cp")
            End If
            Try
                lblRegFiscal.Text = item("ID_Contador")
                lblUsoCFDI.Text = item("clave_usoCFDI")
            Catch ex As Exception
                lblRegFiscal.Text = ""
                lblUsoCFDI.Text = ""
            End Try

        Next
        txtCarrera.Text = ""
        txtTurno.Text = ""

        Dim idRegistro As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")
        Dim direccion As String = db.exectSQLQueryScalar($"SELECT UPPER(direccion + ' Col. ' + colonia + ' ' + M.nombre + ', ' + E.nombre) FROM portal_reRFC AS RE
                                                           INNER JOIN portal_municipio AS M ON M.id_municipio = RE.id_municipio
                                                           INNER JOIN portal_estado AS E ON E.id_estado = M.id_estado
                                                           WHERE RE.id_registro = {idRegistro} AND RE.activo = 1")
        lblDireccion.Text = direccion

        If (txtRFC.Text = "XAXX010101000") Then
            lblCP.Text = EnviromentService.CP
        End If
        panelDatos.Visible = True
        panelCobros.Visible = True
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------BUSCA MATRICULA MATRICULA CONGRESO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaEC(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As Label, txtEmail As Label, txtCarrera As Label, txtTurno As Label, txtRFC As Label, lblCP As Label, lblRegFiscal As Label, lblUsoCFDI As Label, lblDireccion As Label)
        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")

        If (exists < 1) Then
            MessageBox.Show("La clave ingresada no existe, favor de ingresar una clave valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosEC(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno, txtRFC, lblCP, lblRegFiscal, lblUsoCFDI, lblDireccion)
    End Sub



    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------LLENA PANEL DE DATOS CONGRESO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosEC(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As Label, txtEmail As Label, txtCarrera As Label, txtTurno As Label, txtRFC As Label, lblCP As Label, lblRegFiscal As Label, lblUsoCFDI As Label, lblDireccion As Label)
        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT UPPER(C.nombre + ' ' + E.apellido_paterno + ' ' + E.apellido_materno)As Nombre, RE.correo, RFC.rfc, REG.ID_Contador, CF.clave_usoCFDI, RE.cp FROM portal_rcRFC AS RE
                                                               INNER JOIN portal_registroCongreso AS E ON E.id_registro = RE.id_registro
                                                               INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                               INNER JOIN ing_res_usoCFDI_regimenFiscal AS RF ON RF.id_res_usoCFDI_regimenFiscal = RE.id_res_cfdi_regimen
                                                               LEFT JOIN ing_cat_usoCFDI AS CF ON CF.clave_usoCFDI = RF.clave_usoCFDI
                                                               LEFT JOIN ing_Cat_RegFis AS REG ON REG.ID_Contador = RF.clave_regimeFiscal
                                                               INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RE.id_rfc AND RE.Activo = 1
                                                               WHERE E.clave_cliente = '{Matricula}'")
        For Each item As DataRow In tableDatos.Rows
            Dim nombre As String = item("Nombre")
            nombre = Regex.Replace(nombre, " {2,}", " ")
            txtNombre.Text = nombre
            txtEmail.Text = item("correo")
            txtRFC.Text = item("rfc")
            If (item("rfc") = "XAXX010101000") Then
                lblCP.Text = EnviromentService.CP
            Else
                lblCP.Text = item("cp")
            End If
            Try
                lblRegFiscal.Text = item("ID_Contador")
                lblUsoCFDI.Text = item("clave_usoCFDI")
            Catch ex As Exception
                lblRegFiscal.Text = ""
                lblUsoCFDI.Text = ""
            End Try
        Next
        txtCarrera.Text = ""
        txtTurno.Text = ""

        Dim idRegistro As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
        Dim direccion As String = db.exectSQLQueryScalar($"SELECT UPPER(direccion + ' Col. ' + colonia + ' ' + M.nombre + ', ' + E.nombre) FROM portal_rcRFC AS RE
                                                           INNER JOIN portal_municipio AS M ON M.id_municipio = RE.id_municipio
                                                           INNER JOIN portal_estado AS E ON E.id_estado = M.id_estado
                                                           WHERE RE.id_registro = {idRegistro} AND RE.activo = 1")
        lblDireccion.Text = direccion

        panelDatos.Visible = True
        panelCobros.Visible = True
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------------OBTENER RFC---------------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Function obtenerRFC(Matricula As String, tipoMatricula As String)
        Dim RFC As String
        If (tipoMatricula = "EX") Then
            RFC = db.exectSQLQueryScalar($"SELECT rfc FROM portal_catRFC AS R
                                               INNER JOIN portal_reRFC AS RE ON RE.id_rfc = R.id_rfc AND RE.Activo = 1
                                               INNER JOIN portal_registroExterno AS EX ON EX.id_registro = RE.id_registro
                                               WHERE EX.clave_cliente = '{Matricula}'")
        ElseIf (tipoMatricula = "EC") Then
            RFC = db.exectSQLQueryScalar($"SELECT RFC.rfc FROM portal_cliente AS C 
                                               INNER JOIN portal_registroCongreso AS RC ON RC.id_cliente = C.id_cliente
                                               INNER JOIN portal_rcRFC AS X ON X.id_registro = RC.id_registro AND RC.Activo = 1
                                               INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = X.id_rfc
                                               WHERE RC.clave_cliente = '{Matricula}'")
        End If

        Return RFC
    End Function
End Class
