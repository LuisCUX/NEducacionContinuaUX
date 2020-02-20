Public Class AsignacionPagosOpcionalesController
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

    Sub buscarMatriculaUX(Matricula As String, panelDatos As Panel, panelAsignacion As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
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

        Me.llenarPanelDatosUX(Matricula, panelDatos, panelAsignacion, txtNombre, txtEmail, txtCarrera, txtTurno)
    End Sub

    Sub llenarPanelDatosUX(Matricula As String, panelDatos As Panel, panelAsignacion As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
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
        panelAsignacion.Visible = True
    End Sub

    Sub loadAsignacionPagosOpcionalesModal(tipoMatricula As String, Matricula As String, cbTipoPagos As ComboBox, cbPagosOpcionales As ComboBox)
        Dim tableTipoPago As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre FROM ing_CatTipoPagoOpcional WHERE Activo = 1")
        ComboboxService.llenarCombobox(cbTipoPagos, tableTipoPago, "ID", "Nombre")
        cbTipoPagos.SelectedIndex = 0
        Dim tablePagosOpcionales As DataTable
        If (tipoMatricula = "UX") Then
            Dim NT As String() = UtilitiesService.getNivelTurno(Matricula)
            Dim IDNT As Integer = db.exectSQLQueryScalar($"SELECT * FROM mov_Res_Nivel_Turno WHERE Clave_Nivel = '{NT(0)}' AND Clave_Turno = '{NT(1)}'")
            tablePagosOpcionales = db.getDataTableFromSQL($"SELECT R.ID, P.Nombre FROM ing_PagosOpcionales AS P
                                                           INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID_PagoOpcional = P.ID
                                                           WHERE P.ID_cat_TipoPagoOpcional = {cbTipoPagos.SelectedValue} AND R.Para = 'ALUMNO' AND P.Activo = 1 AND ID_res_NT = {IDNT}")
            ComboboxService.llenarCombobox(cbPagosOpcionales, tablePagosOpcionales, "ID", "Nombre")
            ModalAsignacionPagosOpcionalesEDC.commitChangecbPagosOpcionales()
        ElseIf (tipoMatricula = "EC") Then
            tablePagosOpcionales = db.getDataTableFromSQL($"SELECT R.ID, P.Nombre FROM ing_PagosOpcionales AS P
                                                           INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID_PagoOpcional = P.ID
                                                           WHERE P.ID_cat_TipoPagoOpcional = {cbTipoPagos.SelectedValue} AND R.Para = 'EXTERNO' AND P.Activo = 1")
            ComboboxService.llenarCombobox(cbPagosOpcionales, tablePagosOpcionales, "ID", "Nombre")
            ModalAsignacionPagosOpcionalesEDC.commitChangecbPagosOpcionales()
        End If
    End Sub

    Sub guardarPagoOpcional(Matricula As String, tipoMatricula As String, IDPAgo As Integer, Cantidad As Integer, costoUnitario As Decimal)
        If (tipoMatricula = "UX") Then
            db.execSQLQueryWithoutParams($"INSERT INTO ing_AsignacionPagoOpcionalAlumno(ID_resPagoOpcionalAsignacion, Matricula, Cantidad, fechaAsignacion, costoUnitario, Autorizado, Condonado, Activo) VALUES ({IDPAgo}, '{Matricula}', {Cantidad}, GETDATE(), {costoUnitario}, 0, 0, 1)")
            MessageBox.Show("Pago opcional registrado correctamente")
            ModalAsignacionPagosOpcionalesEDC.Close()
            MainAsignacionPagosOpcionalesEDC.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "EC") Then

        End If
    End Sub

    Sub llenarVentanaEdicion(tipoMatricula As String, IDPago As Integer, cbTipoPago As ComboBox, cbPagoOpcional As ComboBox, txtCostoUnitario As TextBox, chbActivo As CheckBox, NUCantidad As NumericUpDown)
        Dim tableInfo As DataTable
        If (tipoMatricula = "UX") Then
            tableInfo = db.getDataTableFromSQL($"SELECT P.ID_cat_TipoPagoOpcional, R.ID, A.Cantidad, A.costoUnitario, A.Activo FROM ing_AsignacionPagoOpcionalAlumno AS A
                                                 INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                 INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional 
                                                 WHERE A.ID = {IDPago}")
            For Each item As DataRow In tableInfo.Rows
                cbTipoPago.SelectedValue = item("ID_cat_TipoPagoOpcional")
                cbPagoOpcional.SelectedValue = item("ID")
                NUCantidad.Value = item("Cantidad")
                txtCostoUnitario.Text = item("costoUnitario")
                chbActivo.Checked = item("Activo")
            Next

        ElseIf (tipoMatricula = "EC") Then

        End If
    End Sub
End Class
