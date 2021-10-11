Public Class AsignacionPlanesController
    Dim db As DataBaseService = New DataBaseService()
    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------BUSCA MATRICULA MATRICULA CONGRESO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaEC(Matricula As String, panelDatos As Panel, panelAsignacion As Panel, txtNombre As TextBox, txtEmail As TextBox, cbPlanes As ComboBox)
        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id_clave FROM portal_clave WHERE clave_cliente = '{Matricula}'")

        If (exists < 1) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            AsignacionPlanesoldEDC.Reiniciar()
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

    Sub llenarGridPagosCambioDescuento(IDPlan As Integer, GridPagos As DataGridView, Matricula As String)
        Dim tablePagos As DataTable = db.getDataTableFromSQL($"SELECT PC.ID, PC.Clave, PC.Descripcion, PC.Importe, PC.Recargo, AC.Descuento FROM ing_PlanesConceptos AS PC 
                                                               INNER JOIN ing_AsignacionCargosPlanes AS AC ON AC.ID_Concepto = PC.ID AND AC.Matricula = '{Matricula}'
                                                               WHERE PC.ID_Plan = {IDPlan} AND PC.Activo = 1 AND AC.Activo = 1 ORDER BY Orden")
        For Each row As DataRow In tablePagos.Rows
            GridPagos.Rows.Add(row("ID"), row("Clave"), row("Descripcion"), (CDec(row("Importe")) - CDec(row("Descuento"))), "")
        Next
    End Sub


    Sub asignarPagosMatricula(Matricula As String, gridPagos As DataGridView)
        Try
            db.startTransaction()
            For x = 0 To gridPagos.Rows.Count - 1
                Dim IDPago As Integer = gridPagos.Rows(x).Cells(0).Value
                Dim clave As String = gridPagos.Rows(x).Cells(1).Value.ToString()
                Dim ID_ClavePago As Integer
                If (clave = "P00") Then
                    ID_ClavePago = 6
                ElseIf (clave = "P13") Then
                    ID_ClavePago = 5
                Else
                    ID_ClavePago = 4
                End If
                Dim fechaRecargo As Date
                Dim fechaRecargos As String

                Dim aplicaRecargo As Boolean = db.exectSQLQueryScalar($"SELECT Considera_Recargo FROM ing_PlanesConceptos WHERE ID = {IDPago}")
                If (aplicaRecargo = True) Then
                    fechaRecargo = db.exectSQLQueryScalar($"SELECT Fecha_Calcula_Recargo FROM ing_PlanesConceptos WHERE ID = {IDPago}")
                    ''fechaRecargos = $"{fechaRecargo.Year}/{fechaRecargo.Month}/{fechaRecargo.Day}"
                Else
                    fechaRecargo = "1900-01-01"
                End If
                db.execSQLQueryWithoutParams($"INSERT INTO ing_AsignacionCargosPlanes(ID_Concepto, Matricula, Fecha_Asignacion, Fecha_Recargo, ID_ClaveConcepto, Descuento, ClaveUnidad, Autorizado, Condonado, Activo) VALUES ({IDPago}, '{Matricula}', GETDATE(), '{fechaRecargos}', {ID_ClavePago}, 0.00, 'E48', 0, 0, 1)")
            Next
            db.commitTransaction()
            MessageBox.Show("Cargos asignados correctamente")
            AsignacionPlanesEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
        End Try
    End Sub

    Sub cambiarPlanPagos(Matricula As String, gridPagos As DataGridView, planID As Integer)
        Try
            db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE ID IN (SELECT A.ID FROM ing_AsignacionCargosPlanes AS A 
															                                             INNER JOIN ing_PlanesConceptos AS C ON C.ID = A.ID_Concepto
															                                             INNER JOIN ing_Planes AS P ON P.ID = C.ID_Plan
															                                             WHERE A.Matricula = '{Matricula}' AND P.ID = {planID} AND A.Activo = 1)")
            db.startTransaction()
            For x = 0 To gridPagos.Rows.Count - 1
                Dim IDPago As Integer = gridPagos.Rows(x).Cells(0).Value
                Dim clave As String = gridPagos.Rows(x).Cells(1).Value.ToString()
                Dim ID_ClavePago As Integer
                If (clave = "P00") Then
                    ID_ClavePago = 6
                ElseIf (clave = "P13") Then
                    ID_ClavePago = 5
                Else
                    ID_ClavePago = 4
                End If
                Dim fechaRecargo As Date
                Dim fechaRecargos As String

                Dim aplicaRecargo As Boolean = db.exectSQLQueryScalar($"SELECT Considera_Recargo FROM ing_PlanesConceptos WHERE ID = {IDPago}")
                If (aplicaRecargo = True) Then
                    fechaRecargo = db.exectSQLQueryScalar($"SELECT Fecha_Calcula_Recargo FROM ing_PlanesConceptos WHERE ID = {IDPago}")
                    ''fechaRecargos = $"{fechaRecargo.Year}/{fechaRecargo.Month}/{fechaRecargo.Day}"
                Else
                    fechaRecargo = "1900-01-01"
                End If
                db.execSQLQueryWithoutParams($"INSERT INTO ing_AsignacionCargosPlanes(ID_Concepto, Matricula, Fecha_Asignacion, Fecha_Recargo, ID_ClaveConcepto, Descuento, ClaveUnidad, Autorizado, Condonado, Activo) VALUES ({IDPago}, '{Matricula}', GETDATE(), '{fechaRecargos}', {ID_ClavePago}, 0.00, 'E48', 0, 0, 1)")
            Next
            db.commitTransaction()
            MessageBox.Show("Cargos asignados correctamente")
            CambioPlanesEDC.Reiniciar()
        Catch ex As Exception

        End Try
    End Sub

    Sub cambiarDescuentos(Matricula As String, gridPagos As DataGridView)
        Try
            For x = 0 To gridPagos.Rows.Count - 1
                Dim descuento As Decimal
                If (gridPagos.Rows(x).Cells(4).Value = "") Then
                    descuento = 0.000000
                Else
                    descuento = gridPagos.Rows(x).Cells(3).Value - gridPagos.Rows(x).Cells(4).Value
                End If

                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Descuento = {descuento} WHERE ID_Concepto = {gridPagos.Rows(x).Cells(0).Value} AND Matricula = '{Matricula}' AND Activo = 1")
            Next
            MessageBox.Show("Descuentos registrados correctamente")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class