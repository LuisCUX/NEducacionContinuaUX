Public Class AsignacionPlanesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim vc As ValidacionesController = New ValidacionesController()
    Dim ap As AsignacionPlanesController = New AsignacionPlanesController()
    Dim planID As Integer
    Dim Matricula As String
    Private Sub AsignacionPlanesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
                                                            ORDER BY NombreCliente")
        Dim tableEDC2 As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
                                                            ORDER BY NombreCliente")
        ComboboxService.llenarCombobox(cbExterno, tableEDC, "clave_cliente", "NombreCliente")
        ComboboxService.llenarCombobox(cbNombre2, tableEDC2, "clave_cliente", "NombreCliente")
    End Sub

    Private Sub cbPlanes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbPlanes.SelectionChangeCommitted
        Try
            ap.llenarGridPagos(cbPlanes.SelectedValue, GridPagos)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cbNuevoPlan_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNuevoPlan.SelectionChangeCommitted
        Try
            ap.llenarGridPagos(cbNuevoPlan.SelectedValue, GridNuevoPlan)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        ap.buscarMatriculaEC(Matricula, panelDatos, panelRegistro, txtNombre, txtEmail, cbPlanes)
        planID = db.exectSQLQueryScalar($"SELECT DISTINCT P.ID FROM ing_AsignacionCargosPlanes AS A 
                                                         INNER JOIN ing_PlanesConceptos AS C ON C.ID = A.ID_Concepto
                                                         INNER JOIN ing_Planes AS P ON P.ID = C.ID_Plan
                                                         WHERE A.Matricula = '{Matricula}' AND A.Activo = 1")
        If (planID > 0) Then
            MessageBox.Show("La matricula ingresada ya tiene un plan asignado")
            Me.Reiniciar()
            Exit Sub
        End If
    End Sub

    Private Sub btnBuscar2_Click(sender As Object, e As EventArgs) Handles btnBuscar2.Click
        Matricula = txtMatricula2.Text
        ap.buscarMatriculaEC(Matricula, panelInfo2, panelPlan2, txtNombre2, txtEmail2, cbNuevoPlan)
        planID = db.exectSQLQueryScalar($"SELECT DISTINCT P.ID FROM ing_AsignacionCargosPlanes AS A 
                                                         INNER JOIN ing_PlanesConceptos AS C ON C.ID = A.ID_Concepto
                                                         INNER JOIN ing_Planes AS P ON P.ID = C.ID_Plan
                                                         WHERE A.Matricula = '{Matricula}' AND A.Activo = 1")
        If (planID < 1) Then
            MessageBox.Show("La matricula ingresada no tiene planes registrados")
            Me.Reiniciar()
            Exit Sub
        Else
            Try
                ap.llenarGridPagos(planID, GridPlanActual)
                cbNuevoPlan.DataSource = Nothing
                Dim tablePlanes As DataTable = db.getDataTableFromSQL($"SELECT P.ID, P.Nombre_Plan FROM portal_registroCongreso AS RC
                                                                INNER JOIN portal_tipoAsistente AS TA ON RC.id_tipo_asistente = TA.id_tipo_asistente
                                                                INNER JOIN portal_congreso AS C ON C.id_congreso = TA.id_congreso AND C.activo = 1
                                                                INNER JOIN ing_Planes AS P ON P.ID_Congreso = C.id_congreso AND P.Activo = 1
                                                                WHERE RC.clave_cliente = '{Matricula}' AND P.ID != {planID}")

                ComboboxService.llenarCombobox(cbNuevoPlan, tablePlanes, "ID", "Nombre_Plan")
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectionChangeCommitted
        Try
            txtMatricula.Text = cbExterno.SelectedValue
            btnBuscar.PerformClick()
            txtMatricula.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbNombre2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNombre2.SelectionChangeCommitted
        Try
            txtMatricula.Text = cbNombre2.SelectedValue
            btnBuscar2.PerformClick()
            txtMatricula2.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        AsignacionPlanesEDC_Load(Me, Nothing)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ap.asignarPagosMatricula(Matricula, GridPagos)
    End Sub

    Private Sub btnGuardar2_Click(sender As Object, e As EventArgs) Handles btnGuardar2.Click
        If (GridNuevoPlan.Rows.Count = 0) Then
            MessageBox.Show("Seleccione un plan")
            Exit Sub
        Else
            ap.cambiarPlanPagos(Matricula, GridNuevoPlan, planID)
        End If
    End Sub
End Class