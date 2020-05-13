Public Class AsignacionPlanesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim vc As ValidacionesController = New ValidacionesController()
    Dim ap As AsignacionPlanesController = New AsignacionPlanesController()
    Dim Matricula As String
    Private Sub AsignacionPlanesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
                                                            ORDER BY NombreCliente")
        ComboboxService.llenarCombobox(cbExterno, tableEDC, "clave_cliente", "NombreCliente")
    End Sub

    Private Sub cbPlanes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbPlanes.SelectionChangeCommitted
        Try
            ap.llenarGridPagos(cbPlanes.SelectedValue, GridPagos)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        ap.buscarMatriculaEC(Matricula, panelDatos, panelRegistro, txtNombre, txtEmail, cbPlanes)
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

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        AsignacionPlanesEDC_Load(Me, Nothing)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ap.asignarPagosMatricula(Matricula, GridPagos)
    End Sub
End Class