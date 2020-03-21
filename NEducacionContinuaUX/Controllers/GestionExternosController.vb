Public Class GestionExternosController
    Dim db As DataBaseService = New DataBaseService()

    Sub loadComboboxExternos(cbEstadoInfo As ComboBox, cbEstadoFiscal As ComboBox, cbEstadoEdit As ComboBox, cbEstadoFiscalEdit As ComboBox, cbExternos As ComboBox, cbUX As ComboBox)
        Dim tableEstadosI As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableEstadosF As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableEstadosED As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableEstadosFED As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno) As NombreExterno FROM portal_registroExterno AS E
                                                                 INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                 INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
                                                                 ORDER BY C.nombre")
        Dim tableUX As DataTable = db.getDataTableFromSQL("SELECT H.matricula, UPPER(A.nombre + ' ' + A.ap_pat + ' ' + A.ap_mat) AS NombreAlumno FROM ux.dbo.dae_historia AS H 
                                                           INNER JOIN ux.dbo.dae_catAlumnos AS A ON A.matricula = H.matricula AND A.sit_esc != 'B'
                                                           INNER JOIN ux.dbo.dae_catPeriodos AS P ON P.activo = 1 AND P.actual = 1
                                                           INNER JOIN ux.dbo.dae_catCarreras AS C ON C.clave = H.carrera AND P.nivel = C.nivel AND P.turno = C.turno
                                                           WHERE H.fechaDeInscripcion IS NOT NULL AND H.periodo = P.periodo 
                                                           ORDER BY A.nombre")

        ComboboxService.llenarCombobox(cbEstadoInfo, tableEstadosI, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbEstadoFiscal, tableEstadosF, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbEstadoEdit, tableEstadosED, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbEstadoFiscalEdit, tableEstadosFED, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbExternos, tableExternos, "clave_cliente", "NombreExterno")
        ComboboxService.llenarCombobox(cbUX, tableUX, "Matricula", "NombreAlumno")
    End Sub

    Sub buscaDatosMatriculaUX(Matricula As String, txtNombre As TextBox, txtAp_Pat As TextBox, txtAp_Mat As TextBox, txtdireccion As TextBox, txtColonia As TextBox, cbEstado As ComboBox, cbMunicipio As ComboBox, txtCorreo As TextBox, txtCP As TextBox, txtTelefono As TextBox)
        Dim exists As String = db.exectSQLQueryScalar($"SELECT nombre FROM ux.dbo.dae_catAlumnos WHERE matricula = '{Matricula}'")
        Dim sit_esc As String = db.exectSQLQueryScalar($"SELECT sit_esc FROM ux.dbo.dae_catAlumnos WHERE matricula = '{Matricula}'")
        Dim existsEDC As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_catMatriculasUX WHERE MatriculaUX = '{Matricula}'")

        If (exists = Nothing) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            RegistroExternosEDC.matriculaExterna = False
            RegistroExternosEDC.Reiniciar()
            Exit Sub
        End If

        If (sit_esc = "B") Then
            MessageBox.Show("La matricula ingresada se encuentra dada de baja, favor de ingresar una matricula valida")
            RegistroExternosEDC.matriculaExterna = False
            RegistroExternosEDC.Reiniciar()
            Exit Sub
        End If

        If (existsEDC > 0) Then
            Dim matriculaEX As String = db.exectSQLQueryScalar($"SELECT MatriculaEX FROM ing_catMatriculasUX WHERE MatriculaUX = '{Matricula}'")
            MessageBox.Show($"La matricula ingresada ya esta dada de alta en educacion continua con la matricula externa: {matriculaEX}")
            RegistroExternosEDC.matriculaExterna = False
            RegistroExternosEDC.Reiniciar()
        End If

        Dim tableDatosAlumno As DataTable = db.getDataTableFromSQL($"SELECT nombre, ap_pat, ap_mat, dom, colonia, estado, ciudad, email, cp, tel
                                                                    FROM ux.dbo.dae_catAlumnos WHERE matricula = '{Matricula}'")
        For Each item As DataRow In tableDatosAlumno.Rows
            txtNombre.Text = item("nombre")
            txtNombre.Enabled = False
            txtAp_Pat.Text = item("ap_pat")
            txtAp_Pat.Enabled = False
            txtAp_Mat.Text = item("ap_mat")
            txtAp_Mat.Enabled = False
            txtdireccion.Text = item("dom")
            txtdireccion.Enabled = False
            txtColonia.Text = item("colonia")
            txtColonia.Enabled = False
            cbEstado.SelectedValue = item("estado")
            cbEstado.Enabled = False
            RegistroExternosEDC.commitChangeEstado()
            cbMunicipio.SelectedValue = item("ciudad")
            cbMunicipio.Enabled = False
            txtCorreo.Text = item("email")
            txtCorreo.Enabled = False
            txtCP.Text = item("cp")
            txtCP.Enabled = False
            txtTelefono.Text = item("tel")
            txtTelefono.Enabled = False
        Next
        RegistroExternosEDC.matriculaExterna = True
    End Sub

    Sub buscarDatosMatriculaExterna(Matricula As String, txtNombre As TextBox, txtAP_Pat As TextBox, txtAP_Mat As TextBox, txtDireccion As TextBox, txtColonia As TextBox, cbEstado As ComboBox, cbMunicipio As ComboBox, txtCorreo As TextBox, txtCP As TextBox, txtTelefono As TextBox,
                                    txtRFC As TextBox, txtNR As TextBox, txtDireccionF As TextBox, txtColoniaF As TextBox, cbEstadoF As ComboBox, cbMunicipioF As ComboBox, txtCiudadF As TextBox, txtCorreoF As TextBox, txtCPF As TextBox, txtTelefonoF As TextBox, chbDatosFiscales As CheckBox,
                                    panelDatosPersonalesEdit As Panel, panelDatosFiscalesEdit As Panel, btnGuardarEdit As Button, btnSalirEd As Button)

        Dim MatUX As String = db.exectSQLQueryScalar($"SELECT MatriculaUX FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")

        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT C.nombre, RE.paterno, RE.materno, C.calle, C.colonia, M.id_estado, C.id_municipio, C.correo, C.cp, C.telefono FROM portal_cliente AS C 
                                                               INNER JOIN portal_registroExterno AS RE ON RE.id_cliente = C.id_cliente
                                                               INNER JOIN portal_municipio AS M ON M.id_municipio = C.id_municipio
                                                               WHERE RE.clave_cliente = '{Matricula}'")
        If (tableDatos.Rows.Count() = 0) Then
            MessageBox.Show("La matricula ingresada no existe, ingrese una matricula valida")
            RegistroExternosEDC.Reiniciar()
            Return
        End If
        For Each item As DataRow In tableDatos.Rows
            txtNombre.Text = item("nombre")
            txtAP_Pat.Text = item("paterno")
            txtAP_Mat.Text = item("materno")
            txtDireccion.Text = item("calle")
            txtColonia.Text = item("colonia")
            cbEstado.SelectedValue = item("id_estado")
            RegistroExternosEDC.commitChangeEstadoEdit()
            cbMunicipio.SelectedValue = item("id_municipio")
            txtCorreo.Text = item("correo")
            txtCP.Text = item("cp")
            txtTelefono.Text = item("telefono")
        Next

        If (MatUX <> Nothing) Then
            txtNombre.Enabled = False
            txtAP_Pat.Enabled = False
            txtAP_Mat.Enabled = False
            txtDireccion.Enabled = False
            txtColonia.Enabled = False
            cbEstado.Enabled = False
            cbMunicipio.Enabled = False
            txtCorreo.Enabled = False
            txtCP.Enabled = False
            txtTelefono.Enabled = False
        Else
            txtNombre.Enabled = True
            txtAP_Pat.Enabled = True
            txtAP_Mat.Enabled = True
            txtDireccion.Enabled = True
            txtColonia.Enabled = True
            cbEstado.Enabled = True
            cbMunicipio.Enabled = True
            txtCorreo.Enabled = True
            txtCP.Enabled = True
            txtTelefono.Enabled = True
        End If

        panelDatosPersonalesEdit.Visible = True
        chbDatosFiscales.Visible = True
        btnGuardarEdit.Visible = True
        btnSalirEd.Visible = True

        Dim IDRegistroExterno As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")
        Dim DatosFiscales As Integer = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_reRFC WHERE id_registro = {IDRegistroExterno}")
        If (DatosFiscales > 1) Then
            Dim tableRFCDatos As DataTable = db.getDataTableFromSQL($"SELECT R.rfc, R.razonsocial, R.direccion, R.colonia, M.id_estado, R.id_municipio, R.poblacion, R.correo, R.cp, R.telefono FROM portal_catRFC AS R 
                                                                      INNER JOIN portal_reRFC AS RER ON RER.id_rfc = R.id_rfc
                                                                      INNER JOIN portal_registroExterno AS E ON RER.id_registro = E.id_registro
                                                                      INNER JOIN portal_municipio AS M ON M.id_municipio = R.id_municipio 
                                                                      WHERE E.clave_cliente = '{Matricula}'")
            For Each item As DataRow In tableRFCDatos.Rows
                txtRFC.Text = item("rfc")
                txtNR.Text = item("razonsocial")
                txtDireccionF.Text = item("direccion")
                txtColoniaF.Text = item("colonia")
                cbEstadoF.SelectedValue = item("id_estado")
                RegistroExternosEDC.commitChangeEstadoEditF()
                cbMunicipioF.SelectedValue = item("id_municipio")
                txtCiudadF.Text = item("poblacion")
                txtCorreoF.Text = item("correo")
                txtCPF.Text = item("cp")
                txtTelefonoF.Text = item("telefono")
            Next
            chbDatosFiscales.Checked = True
            RegistroExternosEDC.commitCheckChanged()
        Else
            chbDatosFiscales.Checked = False
            RegistroExternosEDC.commitCheckChanged()
        End If
    End Sub

    Sub RegistroExterno(Matricula As Boolean, MatriculaUX As String, Correo As String, Nombre As String, Calle As String, Colonia As String, CP As String, IDMunicipio As Integer, tipo_Persona As Integer, telefono As String, IDNacionalidad As Integer, ap_pat As String, ap_mat As String, clave_cliente As String, datosFiscales As Boolean,
                        RFC As String, DireccionF As String, NumeroF As String, ColoniaF As String, CPF As String, CiudadF As String, TelefonoF As String, CorreoF As String, IDMunicipioF As Integer, RazonSocialF As String)
        Try
            db.startTransaction()
            Dim idCliente As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_cliente (correo, nombre, calle, colonia, cp, id_municipio, tipo_persona, telefono, id_nacionalidad) VALUES ('{Correo}', '{Nombre}', '{Calle}', '{Colonia}', '{CP}', {IDMunicipio}, {tipo_Persona}, '{telefono}', {IDNacionalidad})")
            Dim idRegistroExterno As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_registroExterno (paterno, materno, id_cliente, clave_cliente) VALUES ('{ap_pat}', '{ap_mat}', {idCliente}, '{clave_cliente}')")

            If (datosFiscales = True) Then
                Dim idRFC As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC (rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', '', '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
                db.execSQLQueryWithoutParams($"INSERT INTO portal_reRFC(id_rfc, id_registro) VALUES ({idRFC}, {idRegistroExterno})")
            Else
                db.execSQLQueryWithoutParams($"INSERT INTO portal_reRFC(id_rfc, id_registro) VALUES (1, {idRegistroExterno})")
            End If

            db.execSQLQueryWithoutParams($"INSERT INTO portal_clave(clave_cliente, id_cliente, id_tipo_cliente) VALUES ('{clave_cliente}', {idCliente}, 1)")

            If (Matricula = True) Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_catMatriculasUX (MatriculaUX, MatriculaEX) VALUES ('{MatriculaUX}', '{clave_cliente}')")
            End If

            db.execSQLQueryWithoutParams("UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Descripcion = 'EXTERNO'")
            db.commitTransaction()
            MessageBox.Show("Externo registrado correctamente")
            RegistroExternosEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub EdicionExterno(Matricula As String, Correo As String, Nombre As String, Calle As String, Colonia As String, CP As String, IDMunicipio As Integer, tipo_Persona As Integer, telefono As String, IDNacionalidad As Integer, ap_pat As String, ap_mat As String, clave_cliente As String, datosFiscales As Boolean,
                        RFC As String, DireccionF As String, NumeroF As String, ColoniaF As String, CPF As String, CiudadF As String, TelefonoF As String, CorreoF As String, IDMunicipioF As Integer, RazonSocialF As String)
        Try
            db.startTransaction()
            Dim idcliente As Integer = db.exectSQLQueryScalar($"SELECT id_cliente FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")
            Dim idregistro As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")
            Dim idRFC As Integer = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_reRFC WHERE id_registro = {idregistro}")
            db.execSQLQueryWithoutParams($"UPDATE portal_cliente SET correo = '{Correo}', nombre = '{Nombre}', calle = '{Calle}', colonia = '{Colonia}', cp = '{CP}', id_municipio = {IDMunicipio}, telefono = '{telefono}' WHERE id_cliente = '{idcliente}'")
            db.execSQLQueryWithoutParams($"UPDATE portal_registroExterno SET paterno = '{ap_pat}', materno = '{ap_mat}' WHERE id_registro = {idregistro}")
            If (idRFC > 1) Then
                db.execSQLQueryWithoutParams($"UPDATE portal_catRFC SET rfc = '{RFC}', direccion = '{DireccionF}', colonia = '{ColoniaF}', cp = '{CPF}', poblacion = '{CiudadF}', localidad = '{CiudadF}', telefono = '{TelefonoF}', correo = '{CorreoF}', id_municipio = '{IDMunicipioF}', razonsocial = '{RazonSocialF}' WHERE id_rfc = {idRFC}")
            ElseIf (idRFC = 1) Then
                idRFC = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC (rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', '', '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
                db.execSQLQueryWithoutParams($"UPDATE portal_reRFC SET id_rfc = {idRFC} WHERE id_registro = {idregistro}")
            End If
            db.commitTransaction()
            MessageBox.Show("Datos modificados correctamente")
            RegistroExternosEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function validaTextboxDatos(txtNombre As TextBox, txtap_pat As TextBox, txtap_mat As TextBox, txtDireccion As TextBox, txtColonia As TextBox, txtCorreo As TextBox, txtCP As TextBox, txtTelefono As TextBox, cbMunicipio As ComboBox) As Object()
        If (txtNombre.Text = "") Then
            Return {False, "Ingrese un nombre"}
        ElseIf (txtap_pat.Text = "") Then
            Return {False, "Ingrese apellido paterno"}
        ElseIf (txtap_mat.Text = "") Then
            Return {False, "Ingrese apellido materno"}
        ElseIf (txtDireccion.Text = "") Then
            Return {False, "Ingrese una direccion"}
        ElseIf (txtColonia.Text = "") Then
            Return {False, "Ingrese una colonia"}
        ElseIf (txtCorreo.Text = "") Then
            Return {False, "Ingrese un correo"}
        ElseIf (txtCP.Text = "") Then
            Return {False, "Ingrese un codigo postal"}
        ElseIf (txtTelefono.Text = "") Then
            Return {False, "Ingrese un telefono"}
        ElseIf (cbMunicipio.Text = "") Then
            Return {False, "Seleccione un municipio"}
        End If
        Return {True, ""}
    End Function

    Function validaTextboxFiscal(txtRFC As TextBox, txtRazon As TextBox, txtDireccion As TextBox, txtColonia As TextBox, txtCiudad As TextBox, txtCorreo As TextBox, txtCP As TextBox, txtTelefono As TextBox, cbMunicipio As ComboBox) As Object
        If (txtRFC.Text = "") Then
            Return {False, "Ingrese el RFC"}
        ElseIf (txtRazon.Text = "") Then
            Return {False, "Ingrese el nombre o razón social"}
        ElseIf (txtDireccion.Text = "") Then
            Return {False, "Ingrese la dirección"}
        ElseIf (txtColonia.Text = "") Then
            Return {False, "Ingrese una colonia"}
        ElseIf (txtCiudad.Text = "") Then
            Return {False, "Ingrese una ciudad"}
        ElseIf (txtCorreo.Text = "") Then
            Return {False, "Ingrese un correo"}
        ElseIf (txtCP.Text = "") Then
            Return {False, "Ingrese un codigo postal"}
        ElseIf (txtTelefono.Text = "") Then
            Return {False, "Ingrese un telefono"}
        ElseIf (cbMunicipio.Text = "") Then
            Return {False, "Seleccione un municipio"}
        End If
        Return {True, ""}
    End Function

    Function validaCorreo(correo As String, tipo As String, Matricula As String) As Object()
        Dim IDCliente As Integer
        If (tipo = "Nuevo") Then
            IDCliente = db.exectSQLQueryScalar($"SELECT id_cliente FROM portal_cliente WHERE correo = '{correo}'")
        ElseIf (tipo = "Edicion") Then
            IDCliente = db.exectSQLQueryScalar($"SELECT C.id_cliente FROM portal_cliente As C 
                                                 INNER JOIN  portal_clave AS CL ON CL.id_cliente = C.id_cliente
                                                 WHERE C.correo = '{correo}' AND CL.clave_cliente != '{Matricula}'")
        End If

        If (IDCliente <> 0) Then
            Dim MatriculaEX As String = db.exectSQLQueryScalar($"SELECT clave_cliente FROM portal_clave WHERE id_cliente = {IDCliente}")
            Return {False, $"El correo ingresado ya se encuentra registrado con la matricula {MatriculaEX}"}
        End If
        Return {True, ""}
    End Function

    Function obtenerNuevaMatricula() As String

        Dim Año As String = DateTime.Now.Year.ToString().Substring(2, 2)

        Dim Consecutivo As Integer = db.exectSQLQueryScalar("SELECT Consecutivo FROM ing_CatFolios WHERE Descripcion = 'EXTERNO'")
        Dim ConsecutivoStr As String
        If (Consecutivo > 0 And Consecutivo < 10) Then
            ConsecutivoStr = $"00{Consecutivo}"
        ElseIf (Consecutivo > 10 And Consecutivo < 100) Then
            ConsecutivoStr = $"0{Consecutivo}"
        ElseIf (Consecutivo > 100 And Consecutivo < 1000) Then
            ConsecutivoStr = $"{Consecutivo}"
        End If

        Return $"EX{Año}NA{ConsecutivoStr}"
    End Function
End Class
