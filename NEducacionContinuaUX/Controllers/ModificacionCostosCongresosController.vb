Public Class ModificacionCostosCongresosController
    Dim db As DataBaseService = New DataBaseService()
    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------BUSCA MATRICULA MATRICULA CONGRESO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaEC(Matricula As String, panelDatos As Panel, panelAsignacion As Panel, txtNombre As TextBox, txtEmail As TextBox, txtNombreCongreso As TextBox, txtCostoActual As TextBox)
        If (Matricula.Substring(0, 2) <> "EC") Then
            MessageBox.Show("La clave ingresada no es una clave de congresos, ingrese una clave que empiece con EC")
            ModificacionCostosCongresos.Reiniciar()
            Exit Sub
        End If

        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id_clave FROM portal_clave WHERE clave_cliente = '{Matricula}'")

        If (exists < 1) Then
            MessageBox.Show("La clave ingresada no existe, favor de ingresar una clave valida")
            ModificacionCostosCongresos.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosEC(Matricula, panelDatos, panelAsignacion, txtNombre, txtEmail, txtNombreCongreso, txtCostoActual)
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------LLENA PANEL DE DATOS CONGRESO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosEC(Matricula As String, panelInfo As Panel, panelRegistro As Panel, txtNombre As TextBox, txtEmail As TextBox, txtNombreCongreso As TextBox, txtCostoActual As TextBox)
        Dim idTipoAsistente = db.exectSQLQueryScalar($"SELECT id_tipo_asistente FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
        If (IsDBNull(idTipoAsistente)) Then
            MessageBox.Show("La clave ingresada no esta inscrita a algun congreso, ingrese una clave correcta")
            ModificacionCostosCongresos.Reiniciar()
            Exit Sub
        End If

        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT (C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno) AS NombreCliente, C.correo AS Email, CON.nombre AS NombreCongreso FROM portal_registroCongreso AS RC
                                                               INNER JOIN portal_cliente AS C ON C.id_cliente = RC.id_cliente
                                                               INNER JOIN portal_tipoAsistente AS TP ON TP.id_tipo_asistente = RC.id_tipo_asistente
                                                               INNER JOIN portal_congreso AS CON ON CON.id_congreso = TP.id_congreso
                                                               WHERE RC.clave_cliente = '{Matricula}'")

        For Each row As DataRow In tableDatos.Rows
            txtNombre.Text = row("NombreCliente").ToString()
            txtEmail.Text = row("Email").ToString()
            txtNombreCongreso.Text = row("NombreCongreso").ToString()
        Next

        Dim costoTotal As Decimal = db.exectSQLQueryScalar($"SELECT costo_total FROM portal_subtotales WHERE clave_cliente = '{Matricula}'")
        txtCostoActual.Text = costoTotal
        panelInfo.Visible = True
        panelRegistro.Visible = True
    End Sub

    Sub modificarCostoCongreso(Matricula As String, costoActual As Decimal, costoNuevo As Decimal)
        Dim subTotal As Decimal
        Dim iva As Decimal
        Dim costoSinIva As Decimal

        iva = costoNuevo * 0.16
        subTotal = costoNuevo - iva
        Try
            db.execSQLQueryWithoutParams($"UPDATE portal_subtotales SET costo_total = {costoNuevo}, descuento = 0.00, subtotal = {subTotal}, IVA = {iva}, costosiniva = {subTotal} WHERE clave_cliente = '{Matricula}'")
            MessageBox.Show("Costo modificado exitosamente")
            ModificacionCostosCongresos.Reiniciar()
            Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try


    End Sub
End Class
