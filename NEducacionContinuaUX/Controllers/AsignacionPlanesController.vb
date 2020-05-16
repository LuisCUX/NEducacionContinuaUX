Public Class AsignacionPlanesController
    Dim db As DataBaseService = New DataBaseService()
    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------BUSCA MATRICULA MATRICULA CONGRESO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaEC(Matricula As String, panelDatos As Panel, panelAsignacion As Panel, txtNombre As TextBox, txtEmail As TextBox, cbPlanes As ComboBox)
        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id_clave FROM portal_clave WHERE clave_cliente = '{Matricula}'")

        If (exists < 1) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            AsignacionPlanesEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosEC(Matricula, panelDatos, panelAsignacion, txtNombre, txtEmail, cbPlanes)
    End Sub



    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------LLENA PANEL DE DATOS CONGRESO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosEC(Matricula As String, panelDatos As Panel, panelAsignacion As Panel, txtNombre As TextBox, txtEmail As TextBox, cbPlanes As ComboBox)
        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT UPPER(C.nombre + ' ' + R.apellido_paterno + ' ' + R.apellido_materno) AS Nombre, C.correo FROM portal_cliente AS C 
                                                               INNER JOIN portal_registroCongreso AS R ON R.id_cliente = C.id_cliente
                                                               WHERE R.clave_cliente = '{Matricula}'")

        For Each item As DataRow In tableDatos.Rows
            txtNombre.Text = item("Nombre")
            txtEmail.Text = item("correo")
        Next

        Dim tablePlanes As DataTable = db.getDataTableFromSQL($"SELECT P.ID, P.Nombre_Plan FROM portal_registroCongreso AS RC
                                                                INNER JOIN portal_tipoAsistente AS TA ON RC.id_tipo_asistente = TA.id_tipo_asistente
                                                                INNER JOIN portal_congreso AS C ON C.id_congreso = TA.id_congreso AND C.activo = 1
                                                                INNER JOIN ing_Planes AS P ON P.ID_Congreso = C.id_congreso AND P.Activo = 1
                                                                WHERE RC.clave_cliente = '{Matricula}'")

        ComboboxService.llenarCombobox(cbPlanes, tablePlanes, "ID", "Nombre_Plan")

        panelDatos.Visible = True
        panelAsignacion.Visible = True
    End Sub

    Sub llenarGridPagos(IDPlan As Integer, GridPagos As DataGridView)
        Dim tablePagos As DataTable = db.getDataTableFromSQL($"SELECT ID, Clave, Descripcion, Importe, Recargo, Descuento FROM ing_PlanesConceptos WHERE ID_Plan = {IDPlan} AND Activo = 1 ORDER BY Orden")
        GridPagos.DataSource = tablePagos
    End Sub

    Sub asignarPagosMatricula(Matricula As String, gridPagos As DataGridView)
        Try
            db.startTransaction()
            For x = 0 To gridPagos.Rows.Count - 1
                Dim IDPago As Integer = gridPagos.Rows(x).Cells(0).Value
                db.execSQLQueryWithoutParams($"INSERT INTO ing_AsignacionCargosPlanes(ID_Concepto, Matricula, Fecha_Asignacion, Fecha_Recargo, Autorizado, Condonado, Activo) VALUES ({IDPago}, '{Matricula}', GETDATE(), '1900-01-01', 0, 0, 1)")
            Next
            db.commitTransaction()
            MessageBox.Show("Cargos asignados correctamente")
            AsignacionPlanesEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
        End Try

    End Sub
End Class
