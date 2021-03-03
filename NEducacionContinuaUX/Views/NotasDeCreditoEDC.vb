Public Class NotasDeCreditoEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim va As ValidacionesController = New ValidacionesController()
    Private Sub NotasDeCreditoEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
                                                            ORDER BY NombreCliente")
        Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
                                                                 INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                 INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
                                                                 ORDER BY C.nombre")

        tableExternos.Merge(tableEDC)
        ComboboxService.llenarCombobox(cbExterno, tableExternos, "clave_cliente", "NombreCliente")

        Dim tableTipoNota As DataTable = db.getDataTableFromSQL($"SELECT ID, TipoNota FROM ing_CatTipoNotaCredito WHERE Activo = 1")
        ComboboxService.llenarCombobox(cbTipoNota, tableTipoNota, "ID", "TipoNota")
    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectionChangeCommitted
        Try
            txtMatricula.Text = cbExterno.SelectedValue
            btnBuscar.PerformClick()
            txtMatricula.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        txtMatriculaDato.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelGridNota, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelGridNota, txtNombre, txtEmail, txtCarrera, txtTurno, txtRFC)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelGridNota, txtNombre, txtEmail, txtCarrera, txtTurno, txtRFC)
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        NotasDeCreditoEDC_Load(Me, Nothing)
    End Sub
End Class