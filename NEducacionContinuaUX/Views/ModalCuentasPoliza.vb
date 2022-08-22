Public Class ModalCuentasPoliza
    Dim db As DataBaseService = New DataBaseService()
    Private Sub ModalCuentasPoliza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridConceptos.Rows.Clear()
        Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT ID, Nombre FROM ing_PagosOpcionales WHERE Activo = 1 AND cuentaPoliza IS NULL")
        For Each row As DataRow In tableConceptos.Rows
            GridConceptos.Rows.Add(row("ID"), row("Nombre"), "")
        Next
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim result As DialogResult = MessageBox.Show($"Si sale de esta ventana no quedaran registradas las cuentas de los conceptos mostrados ¿Seguro que quiere salir?", "", MessageBoxButtons.YesNo)
        If (result = 6) Then
            Me.Close()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim listaFaltantes As List(Of String) = New List(Of String)
        For x = 0 To GridConceptos.Rows.Count - 1
            If (GridConceptos.Rows(x).Cells(2).Value = "") Then
                Dim nombreConcepto As String
                listaFaltantes.Add(GridConceptos.Rows(x).Cells(1).Value.ToString())
            End If
        Next

        If (listaFaltantes.Count > 0) Then
            Dim message As String
            For x = 0 To listaFaltantes.Count - 1
                message = $"{message}{Environment.NewLine} {listaFaltantes(x)}"
            Next

            Dim result As DialogResult = MessageBox.Show($"No se registró la cuenta de los siguientes conceptos: {Environment.NewLine}{message}{Environment.NewLine}{Environment.NewLine}¿Desea continuar con el registro?", "", MessageBoxButtons.YesNo)
            If (result <> 6) Then
                Exit Sub
            End If
        End If

        For x = 0 To GridConceptos.Rows.Count - 1
            If (GridConceptos.Rows(x).Cells(2).Value.ToString().Count() < 5) Then
                db.execSQLQueryWithoutParams($"UPDATE ing_PagosOpcionales SET cuentaPoliza = NULL WHERE ID = {GridConceptos.Rows(x).Cells(0).Value}")
            Else
                db.execSQLQueryWithoutParams($"UPDATE ing_PagosOpcionales SET cuentaPoliza = '{GridConceptos.Rows(x).Cells(2).Value.ToString()}' WHERE ID = {GridConceptos.Rows(x).Cells(0).Value}")
            End If
        Next
        GridConceptos.Rows.Clear()
        MessageBox.Show("Cambios guardados correctamente")
        Me.Close()
    End Sub
End Class