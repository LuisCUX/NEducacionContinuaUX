Imports Spire.Pdf
Imports ZXing
Imports ZXing.Presentation
Imports BarcodeReader = ZXing.BarcodeReader
Public Class GestionExternosController
    Dim db As DataBaseService = New DataBaseService()

    Sub loadComboboxExternos(cbEstadoInfo As ComboBox, cbEstadoFiscal As ComboBox, cbEstadoEdit As ComboBox, cbEstadoFiscalEdit As ComboBox, cbExternos As ComboBox, cbEstadoEC As ComboBox, cbEstadoFiscalEC As ComboBox)
        Dim tableEstadosI As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableEstadosF As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableEstadosED As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableEstadosFED As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableEstadosEC As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableEstadosFEC As DataTable = db.getDataTableFromSQL("SELECT id_estado, nombre FROM portal_estado")
        Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno) As NombreExterno FROM portal_registroExterno AS E
                                                                 INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                 INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
                                                                 ORDER BY C.nombre")

        ComboboxService.llenarCombobox(cbEstadoInfo, tableEstadosI, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbEstadoFiscal, tableEstadosF, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbEstadoEdit, tableEstadosED, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbEstadoFiscalEdit, tableEstadosFED, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbEstadoEC, tableEstadosEC, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbEstadoFiscalEC, tableEstadosFEC, "id_estado", "nombre")
        ComboboxService.llenarCombobox(cbExternos, tableExternos, "clave_cliente", "NombreExterno")
    End Sub

    Sub buscaDatosMatriculaUX(Matricula As String, txtNombre As TextBox, txtAp_Pat As TextBox, txtAp_Mat As TextBox, txtdireccion As TextBox, txtColonia As TextBox, cbEstado As ComboBox, cbMunicipio As ComboBox, txtCorreo As TextBox, txtCP As TextBox, txtTelefono As TextBox)
        Dim exists As String = db.exectSQLQueryScalar($"SELECT nombre FROM ux.dbo.dae_catAlumnos WHERE matricula = '{Matricula}'")
        Dim sit_esc As String = db.exectSQLQueryScalar($"SELECT sit_esc FROM ux.dbo.dae_catAlumnos WHERE matricula = '{Matricula}'")
        Dim existsEDC As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_catMatriculasUX WHERE MatriculaUX = '{Matricula}'")

        If (exists = Nothing) Then
            MessageBox.Show("La clave ingresada no existe, favor de ingresar una clave valida")
            RegistroExternosOldEDC.matriculaExterna = False
            RegistroExternosOldEDC.Reiniciar()
            Exit Sub
        End If

        If (sit_esc = "B") Then
            MessageBox.Show("La clave ingresada se encuentra dada de baja, favor de ingresar una clave valida")
            RegistroExternosOldEDC.matriculaExterna = False
            RegistroExternosOldEDC.Reiniciar()
            Exit Sub
        End If

        If (existsEDC > 0) Then
            Dim matriculaEX As String = db.exectSQLQueryScalar($"SELECT MatriculaEX FROM ing_catMatriculasUX WHERE MatriculaUX = '{Matricula}'")
            MessageBox.Show($"La clave ingresada ya esta dada de alta en educacion continua con la clave externa: {matriculaEX}")
            RegistroExternosOldEDC.matriculaExterna = False
            RegistroExternosOldEDC.Reiniciar()
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
            RegistroExternosOldEDC.commitChangeEstado()
            cbMunicipio.SelectedValue = item("ciudad")
            cbMunicipio.Enabled = False
            txtCorreo.Text = item("email")
            txtCorreo.Enabled = False
            txtCP.Text = item("cp")
            txtCP.Enabled = False
            txtTelefono.Text = item("tel")
            txtTelefono.Enabled = False
        Next
        RegistroExternosOldEDC.matriculaExterna = True
    End Sub

    Sub buscarDatosMatriculaExterna(Matricula As String, txtNombre As TextBox, txtAP_Pat As TextBox, txtAP_Mat As TextBox, txtDireccion As TextBox, txtColonia As TextBox, cbEstado As ComboBox, cbMunicipio As ComboBox, txtCorreo As TextBox, txtCP As TextBox, txtTelefono As TextBox,
                                    txtRFC As TextBox, txtNR As TextBox, txtDireccionF As TextBox, txtColoniaF As TextBox, cbEstadoF As ComboBox, cbMunicipioF As ComboBox, txtCiudadF As TextBox, txtCorreoF As TextBox, txtCPF As TextBox, txtTelefonoF As TextBox, chbDatosFiscales As CheckBox,
                                    panelDatosPersonalesEdit As Panel, panelDatosFiscalesEdit As Panel, btnGuardarEdit As Button, btnSalirEd As Button, btnLimpiar As Button, cbRFCEd As ComboBox)

        Dim MatUX As String = db.exectSQLQueryScalar($"SELECT MatriculaUX FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")

        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT C.nombre, RE.paterno, RE.materno, C.calle, C.colonia, M.id_estado, C.id_municipio, C.correo, C.cp, C.telefono FROM portal_cliente AS C 
                                                               INNER JOIN portal_registroExterno AS RE ON RE.id_cliente = C.id_cliente
                                                               INNER JOIN portal_municipio AS M ON M.id_municipio = C.id_municipio
                                                               WHERE RE.clave_cliente = '{Matricula}'")
        If (tableDatos.Rows.Count() = 0) Then
            MessageBox.Show("La clave ingresada no existe, ingrese una clave valida")
            RegistroExternosOldEDC.Reiniciar()
            Return
        End If
        For Each item As DataRow In tableDatos.Rows
            txtNombre.Text = item("nombre")
            txtAP_Pat.Text = item("paterno")
            txtAP_Mat.Text = item("materno")
            txtDireccion.Text = item("calle")
            txtColonia.Text = item("colonia")
            cbEstado.SelectedValue = item("id_estado")
            RegistroExternosOldEDC.commitChangeEstadoEdit()
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
        btnLimpiar.Visible = True

        Dim IDRegistroExterno As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")
        Dim DatosFiscales As Integer = db.exectSQLQueryScalar($"SELECT COUNT(id_rfc) FROM portal_reRFC WHERE id_registro = {IDRegistroExterno}")
        If (DatosFiscales = 1) Then
            Dim RFCID As String = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_reRFC WHERE id_registro = {IDRegistroExterno}")
            If (RFCID = 2) Then
                cbRFCEd.Items.Add("Nuevo RFC")
                chbDatosFiscales.Checked = False
                cbRFCEd.SelectedIndex = 0
                RegistroExternosOldEDC.commitChangeRFCEd()
                ''RegistroExternosOldEDC.commitCheckChangedEC()
                RegistroExternosOldEDC.panelDatosFiscalesEdit.Visible = False
            Else
                Dim RFC As String = db.exectSQLQueryScalar($"SELECT rfc FROM portal_catRFC WHERE id_rfc = {RFCID}")
                cbRFCEd.Items.Add("Nuevo RFC")
                cbRFCEd.Items.Add(RFC)
                chbDatosFiscales.Checked = True
                cbRFCEd.SelectedIndex = 1
                RegistroExternosOldEDC.commitChangeRFCEd()
                RegistroExternosOldEDC.panelDatosFiscalesEdit.Visible = True
                ''RegistroExternosOldEDC.commitCheckChangedEC()
            End If
        Else
            Dim RFCID As String = db.exectSQLQueryScalar($"SELECT RFC.rfc FROM portal_catRFC AS RFC
                                                           INNER JOIN portal_reRFC AS RE ON RE.id_rfc = RFC.id_rfc AND RE.activo = 1 AND RE.id_registro = {IDRegistroExterno}")
            Dim tableRFC As DataTable = db.getDataTableFromSQL($"SELECT RFC.rfc FROM portal_catRFC AS RFC 
                                                                 INNER JOIN portal_reRFC AS RC ON RC.id_rfc = RFC.id_rfc
                                                                 WHERE RC.id_registro = {IDRegistroExterno} AND RFC.id_rfc != 2")
            cbRFCEd.Items.Add("Nuevo RFC")
            For Each item As DataRow In tableRFC.Rows
                cbRFCEd.Items.Add(item("rfc"))
            Next
            cbRFCEd.Text = RFCID
            chbDatosFiscales.Checked = True
            RegistroExternosOldEDC.commitChangeRFCEd()
            ''RegistroExternosOldEDC.commitCheckChangedEC()
            RegistroExternosOldEDC.panelDatosFiscalesEdit.Visible = True
        End If
    End Sub

    Sub buscarDatosMatriculaEc(Matricula As String, txtNombre As TextBox, txtAP_Pat As TextBox, txtAP_Mat As TextBox, txtDireccion As TextBox, txtColonia As TextBox, cbEstado As ComboBox, cbMunicipio As ComboBox, txtCorreo As TextBox, txtCP As TextBox, txtTelefono As TextBox,
                                    txtRFC As TextBox, txtNR As TextBox, txtDireccionF As TextBox, txtColoniaF As TextBox, cbEstadoF As ComboBox, cbMunicipioF As ComboBox, txtCiudadF As TextBox, txtCorreoF As TextBox, txtCPF As TextBox, txtTelefonoF As TextBox, chbDatosFiscales As CheckBox,
                                    panelDatosPersonalesEdit As Panel, panelDatosFiscalesEdit As Panel, btnGuardarEdit As Button, btnSalirEd As Button, btnLimpiar As Button, cbRFCEC As ComboBox)

        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT C.nombre, RC.apellido_paterno, RC.apellido_materno, C.calle, C.colonia, E.id_estado, M.id_municipio, C.correo, C.cp, RC.telefono FROM portal_cliente AS C
                                                               INNER JOIN portal_registroCongreso AS RC ON RC.id_cliente = C.id_cliente
                                                               INNER JOIN portal_municipio AS M ON M.id_municipio = C.id_municipio
                                                               INNER JOIN portal_estado AS E ON E.id_estado = M.id_estado  
                                                               WHERE RC.clave_cliente = '{Matricula}'")
        If (tableDatos.Rows.Count() = 0) Then
            MessageBox.Show("La clave ingresada no existe, ingrese una clave valida")
            RegistroExternosOldEDC.Reiniciar()
            Return
        End If
        For Each item As DataRow In tableDatos.Rows
            txtNombre.Text = item("nombre")
            txtAP_Pat.Text = item("apellido_paterno")
            txtAP_Mat.Text = item("apellido_materno")
            txtDireccion.Text = item("calle")
            txtColonia.Text = item("colonia")
            cbEstado.SelectedValue = item("id_estado")
            RegistroExternosOldEDC.commitChangeEstadoEC()
            cbMunicipio.SelectedValue = item("id_municipio")
            txtCorreo.Text = item("correo")
            txtCP.Text = item("cp")
            txtTelefono.Text = item("telefono")
        Next

        panelDatosPersonalesEdit.Visible = True
        chbDatosFiscales.Visible = True
        btnGuardarEdit.Visible = True
        btnSalirEd.Visible = True
        btnLimpiar.Visible = True

        Dim IDRegistroCongreso As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
        Dim DatosFiscales As Integer = db.exectSQLQueryScalar($"SELECT COUNT(id_rfc) FROM portal_rcRFC WHERE id_registro = {IDRegistroCongreso}")
        If (DatosFiscales = 1) Then
            Dim RFCID As String = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_rcRFC WHERE id_registro = {IDRegistroCongreso}")
            If (RFCID = 2) Then
                cbRFCEC.Items.Add("Nuevo RFC")
                chbDatosFiscales.Checked = False
                cbRFCEC.SelectedIndex = 0
                ''RegistroExternosOldEDC.commitChangeRFCEC()
                RegistroExternosOldEDC.commitCheckChangedEC()
            Else
                Dim RFC As String = db.exectSQLQueryScalar($"SELECT rfc FROM portal_catRFC WHERE id_rfc = {RFCID}")
                cbRFCEC.Items.Add("Nuevo RFC")
                cbRFCEC.Items.Add(RFC)
                chbDatosFiscales.Checked = True
                cbRFCEC.SelectedIndex = 1
                RegistroExternosOldEDC.commitChangeRFCEC()
                RegistroExternosOldEDC.panelDatosFiscalesEC.Visible = True
                ''RegistroExternosOldEDC.commitCheckChangedEC()
            End If
        Else
            Dim RFCID As String = db.exectSQLQueryScalar($"SELECT RFC.rfc FROM portal_catRFC AS RFC
                                                           INNER JOIN portal_rcRFC AS RE ON RE.id_rfc = RFC.id_rfc AND RE.activo = 1 AND RE.id_registro = {IDRegistroCongreso}")
            Dim tableRFC As DataTable = db.getDataTableFromSQL($"SELECT RFC.rfc FROM portal_catRFC AS RFC 
                                                                 INNER JOIN portal_rcRFC AS RC ON RC.id_rfc = RFC.id_rfc
                                                                 WHERE RC.id_registro = {IDRegistroCongreso} AND RFC.id_rfc != 2")
            cbRFCEC.Items.Add("Nuevo RFC")
            For Each item As DataRow In tableRFC.Rows
                cbRFCEC.Items.Add(item("rfc"))
            Next
            cbRFCEC.Text = RFCID
            chbDatosFiscales.Checked = True
            RegistroExternosOldEDC.commitChangeRFCEC()
            ''RegistroExternosOldEDC.commitCheckChangedFEC()
            RegistroExternosOldEDC.panelDatosFiscalesEC.Visible = True
        End If
    End Sub

    Sub RegistroExterno(Matricula As Boolean, MatriculaUX As String, Correo As String, Nombre As String, Calle As String, Colonia As String, CP As String, IDMunicipio As Integer, tipo_Persona As Integer, telefono As String, IDNacionalidad As Integer, ap_pat As String, ap_mat As String, clave_cliente As String, datosFiscales As Boolean,
                        RFC As String, DireccionF As String, NumeroF As String, ColoniaF As String, CPF As String, CiudadF As String, TelefonoF As String, CorreoF As String, IDMunicipioF As Integer, RazonSocialF As String, idResRegCF As Integer)
        Try
            db.startTransaction()
            Dim idCliente As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_cliente (correo, nombre, calle, colonia, cp, id_municipio, tipo_persona, telefono, id_nacionalidad) VALUES ('{Correo}', '{Nombre}', '{Calle}', '{Colonia}', '{CP}', {IDMunicipio}, 1, '{telefono}', {IDNacionalidad})")
            Dim idRegistroExterno As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_registroExterno (paterno, materno, id_cliente, clave_cliente) VALUES ('{ap_pat}', '{ap_mat}', {idCliente}, '{clave_cliente}')")

            If (datosFiscales = True) Then
                Dim idRFC As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC (rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', '', '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
                db.execSQLQueryWithoutParams($"INSERT INTO portal_reRFC(id_rfc, id_registro, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial, id_res_cfdi_regimen, Activo) VALUES ({idRFC}, {idRegistroExterno}, '{DireccionF}', '', '{ColoniaF}', '{CPF}', '{CiudadF}', '', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}', {idResRegCF}, 1)")
            Else
                db.execSQLQueryWithoutParams($"INSERT INTO portal_reRFC(id_rfc, id_registro, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial, id_res_cfdi_regimen, Activo) VALUES (2, {idRegistroExterno}, 'XX', '0', 'XX', '0', 'XX', 'XX', '0', 'XX', 0, 'XX', 221, 1)")
            End If

            db.execSQLQueryWithoutParams($"INSERT INTO portal_clave(clave_cliente, id_cliente, id_tipo_cliente) VALUES ('{clave_cliente}', {idCliente}, 1)")

            If (Matricula = True) Then
                db.execSQLQueryWithoutParams($"INSERT INTO ing_catMatriculasUX (MatriculaUX, MatriculaEX) VALUES ('{MatriculaUX}', '{clave_cliente}')")
            End If

            db.execSQLQueryWithoutParams("UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Descripcion = 'EXTERNO'")
            db.commitTransaction()
            MessageBox.Show("Externo registrado correctamente")
            RegistroExternosOldEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub EdicionExterno(Matricula As String, Correo As String, Nombre As String, Calle As String, Colonia As String, CP As String, IDMunicipio As Integer, tipo_Persona As Integer, telefono As String, IDNacionalidad As Integer, ap_pat As String, ap_mat As String, clave_cliente As String, datosFiscales As Boolean,
                        RFC As String, DireccionF As String, NumeroF As String, ColoniaF As String, CPF As String, CiudadF As String, TelefonoF As String, CorreoF As String, IDMunicipioF As Integer, RazonSocialF As String, RegimenFiscal As String, usoCFDI As String)
        Try
            db.startTransaction()
            Dim idcliente As Integer = db.exectSQLQueryScalar($"SELECT id_cliente FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")
            Dim idregistro As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")
            Dim IDResRegCFDI As Integer = db.exectSQLQueryScalar($"SELECT id_res_usoCFDI_regimenFiscal FROM ing_res_usoCFDI_regimenFiscal WHERE clave_usoCFDI = '{usoCFDI}' AND clave_regimeFiscal = '{RegimenFiscal}'")

            Dim numRFC As Integer = db.exectSQLQueryScalar($"SELECT COUNT(id_rfc) FROM portal_reRFC WHERE id_registro = {idregistro}")

            db.execSQLQueryWithoutParams($"UPDATE portal_cliente SET correo = '{Correo}', nombre = '{Nombre}', calle = '{Calle}', colonia = '{Colonia}', cp = '{CP}', id_municipio = {IDMunicipio}, telefono = '{telefono}' WHERE id_cliente = '{idcliente}'")
            db.execSQLQueryWithoutParams($"UPDATE portal_registroExterno SET paterno = '{ap_pat}', materno = '{ap_mat}' WHERE id_registro = {idregistro}")

            If (datosFiscales = True And numRFC > 1) Then
                ''EDICION DE DATOS FISCALES
                Dim IDRFC As Integer = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_catRFC WHERE rfc = '{RFC}'")
                If (IDRFC > 2) Then
                    Dim IDRes As Integer = db.exectSQLQueryScalar($"SELECT id_re_rfc FROM portal_reRFC AS RE
                                                                INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RE.id_rfc
                                                                WHERE RFC.rfc = '{RFC}'")
                    db.execSQLQueryWithoutParams($"UPDATE portal_reRFC SET direccion = '{DireccionF}', numero = numero, colonia = '{ColoniaF}', cp = '{CPF}', poblacion = '{CiudadF}', localidad = '{CiudadF}', telefono = '{TelefonoF}', correo = '{CorreoF}', id_municipio = {IDMunicipioF}, razonsocial = '{RazonSocialF}', id_res_cfdi_regimen = '{IDResRegCFDI}' WHERE id_re_rfc = {IDRes}")
                Else
                    Dim nuevoRFC As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC(rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
                    db.execSQLQueryWithoutParams($"INSERT INTO portal_reRFC(id_rfc, id_registro, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial, id_res_cfdi_regimen, activo) VALUES({nuevoRFC}, {idregistro}, '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}', {IDResRegCFDI}, 1)")
                End If
            ElseIf (datosFiscales = True And numRFC = 1) Then
                ''NUEVO REGISTRO DE DATOS FISCALES
                Dim RFCID As Integer = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_reRFC WHERE id_registro = {idregistro}")
                If (RFCID = 2) Then ''NUEVO REGISTRO DE DATOS FISCALES
                    Dim nuevoRFC As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC(rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
                    db.execSQLQueryWithoutParams($"INSERT INTO portal_reRFC(id_rfc, id_registro, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial, id_res_cfdi_regimen, activo) VALUES({nuevoRFC}, {idregistro}, '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}', {IDResRegCFDI}, 1)")
                Else
                    Dim RFCRegistrado As String = db.exectSQLQueryScalar($"SELECT rfc FROM portal_catRFC WHERE id_rfc = {RFCID}")
                    If (RFCRegistrado = RFC) Then ''UPDATE
                        Dim IDRes As Integer = db.exectSQLQueryScalar($"SELECT id_re_rfc FROM portal_reRFC AS RE
                                                                INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RE.id_rfc
                                                                WHERE RFC.rfc = '{RFC}'")
                        db.execSQLQueryWithoutParams($"UPDATE portal_reRFC SET direccion = '{DireccionF}', numero = numero, colonia = '{ColoniaF}', cp = '{CPF}', poblacion = '{CiudadF}', localidad = '{CiudadF}', telefono = '{TelefonoF}', correo = '{CorreoF}', id_municipio = {IDMunicipioF}, razonsocial = '{RazonSocialF}', id_res_cfdi_regimen = '{IDResRegCFDI}' WHERE id_re_rfc = {IDRes}")
                    Else ''NUEVO REGISTRO    
                        Dim nuevoRFC As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC(rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
                        db.execSQLQueryWithoutParams($"INSERT INTO portal_reRFC(id_rfc, id_registro, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial, id_res_cfdi_regimen, activo) VALUES({nuevoRFC}, {idregistro}, '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}', {IDResRegCFDI}, 1)")
                    End If
                End If
            End If

            db.commitTransaction()
            MessageBox.Show("Datos modificados correctamente")
            RegistroExternosOldEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub EdicionEC(Matricula As String, Correo As String, Nombre As String, Calle As String, Colonia As String, CP As String, IDMunicipio As Integer, tipo_Persona As Integer, telefono As String, IDNacionalidad As Integer, ap_pat As String, ap_mat As String, datosFiscales As Boolean,
                        RFC As String, DireccionF As String, NumeroF As String, ColoniaF As String, CPF As String, CiudadF As String, TelefonoF As String, CorreoF As String, IDMunicipioF As Integer, RazonSocialF As String, RegimenFiscal As String, usoCFDI As String)
        Try
            db.startTransaction()
            Dim idcliente As Integer = db.exectSQLQueryScalar($"SELECT id_cliente FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
            Dim idregistro As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
            Dim IDResRegCFDI As Integer = db.exectSQLQueryScalar($"SELECT id_res_usoCFDI_regimenFiscal FROM ing_res_usoCFDI_regimenFiscal WHERE clave_usoCFDI = '{usoCFDI}' AND clave_regimeFiscal = '{RegimenFiscal}'")

            Dim numRFC As Integer = db.exectSQLQueryScalar($"SELECT COUNT(id_rfc) FROM portal_rcRFC WHERE id_registro = {idregistro}")

            db.execSQLQueryWithoutParams($"UPDATE portal_cliente SET correo = '{Correo}', nombre = '{Nombre}', calle = '{Calle}', colonia = '{Colonia}', cp = '{CP}', id_municipio = {IDMunicipio}, telefono = '{telefono}' WHERE id_cliente = '{idcliente}'")
            db.execSQLQueryWithoutParams($"UPDATE portal_registroCongreso SET apellido_paterno = '{ap_pat}', apellido_materno = '{ap_mat}' WHERE id_registro = {idregistro}")

            If (datosFiscales = True And numRFC > 1) Then
                ''EDICION DE DATOS FISCALES
                Dim IDRFC As Integer = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_catRFC WHERE rfc = '{RFC}'")
                If (IDRFC > 2) Then
                    Dim IDRes As Integer = db.exectSQLQueryScalar($"SELECT id_rc_rfc FROM portal_rcRFC AS RE
                                                                INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RE.id_rfc
                                                                WHERE RFC.rfc = '{RFC}'")
                    db.execSQLQueryWithoutParams($"UPDATE portal_rcRFC SET direccion = '{DireccionF}', numero = numero, colonia = '{ColoniaF}', cp = '{CPF}', poblacion = '{CiudadF}', localidad = '{CiudadF}', telefono = '{TelefonoF}', correo = '{CorreoF}', id_municipio = {IDMunicipioF}, razonsocial = '{RazonSocialF}', id_res_cfdi_regimen = '{IDResRegCFDI}' WHERE id_rc_rfc = {IDRes}")
                Else
                    Dim nuevoRFC As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC(rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
                    db.execSQLQueryWithoutParams($"INSERT INTO portal_rcRFC(id_rfc, id_registro, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial, id_res_cfdi_regimen, activo) VALUES({nuevoRFC}, {idregistro}, '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}', {IDResRegCFDI}, 1)")
                End If
            ElseIf (datosFiscales = True And numRFC = 1) Then
                ''NUEVO REGISTRO DE DATOS FISCALES
                Dim RFCID As Integer = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_rcRFC WHERE id_registro = {idregistro}")
                If (RFCID = 2) Then ''NUEVO REGISTRO DE DATOS FISCALES
                    Dim nuevoRFC As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC(rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
                    db.execSQLQueryWithoutParams($"INSERT INTO portal_rcRFC(id_rfc, id_registro, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial, id_res_cfdi_regimen, activo) VALUES({nuevoRFC}, {idregistro}, '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}', {IDResRegCFDI}, 1)")
                Else
                    Dim RFCRegistrado As String = db.exectSQLQueryScalar($"SELECT rfc FROM portal_catRFC WHERE id_rfc = {RFCID}")
                    If (RFCRegistrado = RFC) Then ''UPDATE
                        Dim IDRes As Integer = db.exectSQLQueryScalar($"SELECT id_rc_rfc FROM portal_rcRFC AS RE
                                                                INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RE.id_rfc
                                                                WHERE RFC.rfc = '{RFC}'")
                        db.execSQLQueryWithoutParams($"UPDATE portal_rcRFC SET direccion = '{DireccionF}', numero = numero, colonia = '{ColoniaF}', cp = '{CPF}', poblacion = '{CiudadF}', localidad = '{CiudadF}', telefono = '{TelefonoF}', correo = '{CorreoF}', id_municipio = {IDMunicipioF}, razonsocial = '{RazonSocialF}', id_res_cfdi_regimen = '{IDResRegCFDI}' WHERE id_rc_rfc = {IDRes}")
                    Else ''NUEVO REGISTRO    
                        Dim nuevoRFC As Integer = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC(rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
                        db.execSQLQueryWithoutParams($"INSERT INTO portal_rcRFC(id_rfc, id_registro, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial, id_res_cfdi_regimen, activo) VALUES({nuevoRFC}, {idregistro}, '{DireccionF}', 0, '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}', {IDResRegCFDI}, 1)")
                    End If
                End If
            End If

            db.commitTransaction()
            MessageBox.Show("Datos modificados correctamente")
            RegistroExternosOldEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Sub EdicionEC(Matricula As String, Correo As String, Nombre As String, Calle As String, Colonia As String, CP As String, IDMunicipio As Integer, tipo_Persona As Integer, telefono As String, IDNacionalidad As Integer, ap_pat As String, ap_mat As String, datosFiscales As Boolean,
    '                    RFC As String, DireccionF As String, NumeroF As String, ColoniaF As String, CPF As String, CiudadF As String, TelefonoF As String, CorreoF As String, IDMunicipioF As Integer, RazonSocialF As String)
    '    Try
    '        db.startTransaction()
    '        Dim idcliente As Integer = db.exectSQLQueryScalar($"SELECT id_cliente FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
    '        Dim idregistro As Integer = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
    '        Dim idRFC As Integer = db.exectSQLQueryScalar($"SELECT id_rfc FROM portal_rcRFC WHERE id_registro = {idregistro}")
    '        db.execSQLQueryWithoutParams($"UPDATE portal_cliente SET correo = '{Correo}', nombre = '{Nombre}', calle = '{Calle}', colonia = '{Colonia}', cp = '{CP}', id_municipio = {IDMunicipio}, telefono = '{telefono}' WHERE id_cliente = '{idcliente}'")
    '        db.execSQLQueryWithoutParams($"UPDATE portal_registroCongreso SET apellido_paterno = '{ap_pat}', apellido_materno = '{ap_mat}' WHERE id_registro = {idregistro}")

    '        If (idRFC > 1) Then
    '            db.execSQLQueryWithoutParams($"UPDATE portal_rcRFC SET direccion = '{DireccionF}', colonia = '{ColoniaF}', cp = '{CPF}', poblacion = '{CiudadF}', localidad = '{CiudadF}', telefono = '{TelefonoF}', correo = '{CorreoF}', id_municipio = '{IDMunicipioF}', razonsocial = '{RazonSocialF}' WHERE id_rfc = {idRFC}")
    '        ElseIf (idRFC = 1) Then
    '            idRFC = db.insertAndGetIDInserted($"INSERT INTO portal_catRFC (rfc, direccion, numero, colonia, cp, poblacion, localidad, telefono, correo, id_municipio, razonsocial) VALUES ('{RFC}', '{DireccionF}', '', '{ColoniaF}', '{CPF}', '{CiudadF}', '{CiudadF}', '{TelefonoF}', '{CorreoF}', {IDMunicipioF}, '{RazonSocialF}')")
    '            db.execSQLQueryWithoutParams($"UPDATE portal_reRFC SET id_rfc = {idRFC} WHERE id_registro = {idregistro}")
    '        End If

    '        db.commitTransaction()
    '        MessageBox.Show("Datos modificados correctamente")
    '        RegistroExternosOldEDC.Reiniciar()
    '    Catch ex As Exception
    '        db.rollBackTransaction()
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

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

    Function validaTextboxFiscal(txtRFC As TextBox, txtRazon As TextBox, txtDireccion As TextBox, txtColonia As TextBox, txtCiudad As TextBox, txtCorreo As TextBox, txtCP As TextBox, txtTelefono As TextBox, cbMunicipio As ComboBox, cbRegistroFiscal As ComboBox, cbUsoCFDI As ComboBox) As Object
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
        ElseIf (cbRegistroFiscal.Text = "") Then
            Return {False, "Seleccione un regimen fiscal"}
        ElseIf (cbUsoCFDI.Text = "") Then
            Return {False, "Seleccione un uso de CFDI"}
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
            Return {False, $"El correo ingresado ya se encuentra registrado con la clave {MatriculaEX}"}
        End If
        Return {True, ""}
    End Function

    Function obtenerNuevaMatricula() As String

        Dim Año As String = DateTime.Now.Year.ToString().Substring(2, 2)

        Dim Consecutivo As Integer = db.exectSQLQueryScalar("SELECT Consecutivo FROM ing_CatFolios WHERE Descripcion = 'EXTERNO'")
        Dim ConsecutivoStr As String
        If (Consecutivo > 0 And Consecutivo < 10) Then
            ConsecutivoStr = $"00{Consecutivo}"
        ElseIf (Consecutivo >= 10 And Consecutivo < 100) Then
            ConsecutivoStr = $"0{Consecutivo}"
        ElseIf (Consecutivo >= 100 And Consecutivo < 1000) Then
            ConsecutivoStr = $"{Consecutivo}"
        End If

        Return $"EX{Año}NA{ConsecutivoStr}"
    End Function

    Sub abrirConstancia(RFC As String)

        If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal")) Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal")
        End If

        Try
            My.Computer.FileSystem.CopyFile($"\\{EnviromentService.documentosIP}\Documentos\ConstanciaFiscal\{RFC}.pdf",
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal\" & RFC & ".pdf",
            FileIO.UIOption.AllDialogs,
            FileIO.UICancelOption.ThrowException)
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal\" & RFC & ".pdf")

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub subirConstancia(RFC As String, fileDialog As OpenFileDialog)
        If fileDialog.ShowDialog = DialogResult.OK Then
            Try
                My.Computer.FileSystem.CopyFile(fileDialog.FileName,
                $"\\{EnviromentService.documentosIP}\Documentos\ConstanciaFiscal\" & RFC & ".pdf",
                FileIO.UIOption.AllDialogs,
                FileIO.UICancelOption.ThrowException)
                MessageBox.Show("Constancia registrada correctamente")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Sub leerQR(RFC As String)
        If (Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal")) Then
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal")
        End If

        Try
            My.Computer.FileSystem.CopyFile($"\\{EnviromentService.documentosIP}\Documentos\ConstanciaFiscal\{RFC}.pdf",
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal\" & RFC & ".pdf",
            FileIO.UIOption.AllDialogs,
            FileIO.UICancelOption.ThrowException)

            Dim doc As PdfDocument = New PdfDocument
            doc.LoadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ConstanciaFiscal\" & RFC & ".pdf")


            Dim reader = New BarcodeReader()
            Dim barcodeBitmap As New Bitmap(doc.SaveAsImage(0))


            Dim Result = reader.Decode(barcodeBitmap)

            If Result IsNot Nothing Then
                Process.Start(Result.Text.ToString())
                Dim urlQR = Result.Text.ToString()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
