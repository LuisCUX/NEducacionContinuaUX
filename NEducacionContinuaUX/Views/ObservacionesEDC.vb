Public Class ObservacionesEDC
    Dim db As DataBaseService = New DataBaseService
    Dim ob As ObservacionesController = New ObservacionesController
    Dim IDObservacion As Integer
    Private Sub ObservacionesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ob.tabObservacionesCancelacion(cbTipoObsCancelacion)
        btnEditarObCancelacion.Enabled = False
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        ObservacionesEDC_Load(Me, Nothing)
    End Sub

    Private Sub GridObservacionCancelacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridObservacionCancelacion.CellContentClick
        If (GridObservacionCancelacion.Rows(e.RowIndex).Cells(2).Value) Then
            btnGuardarObCancelacion.Enabled = True
            btnEditarObCancelacion.Enabled = False
            GridObservacionCancelacion.EndEdit()
            txtObservacionCancelacion.Clear()
            Exit Sub
        Else
            btnGuardarObCancelacion.Enabled = False
            btnEditarObCancelacion.Enabled = True
        End If

        GridObservacionCancelacion.EndEdit()
        For x = 0 To GridObservacionCancelacion.Rows.Count - 1
            If (e.RowIndex <> x) Then
                GridObservacionCancelacion.Rows(x).Cells(2).Value = False
            End If
        Next

        IDObservacion = GridObservacionCancelacion.Rows(e.RowIndex).Cells(0).Value

        txtObservacionCancelacion.Text = db.exectSQLQueryScalar($"SELECT Observacion FROM ing_CatObservacionesCancelacion WHERE ID = {IDObservacion}")
        chbActivoCancelacion.Checked = db.exectSQLQueryScalar($"SELECT Activo FROM ing_CatObservacionesCancelacion WHERE ID = {IDObservacion}")
    End Sub

    Private Sub btnEditarObCancelacion_Click(sender As Object, e As EventArgs)
        Dim activo As Integer
        If (chbActivoCancelacion.Checked = True) Then
            activo = 1
        Else
            activo = 0
        End If

        If (txtObservacionCancelacion.Text.Length() = 0) Then
            MessageBox.Show("Ingrese una observación")
            Exit Sub
        End If

        db.execSQLQueryWithoutParams($"UPDATE ing_CatObservacionesCancelacion SET Observacion = '{txtObservacionCancelacion.Text}', Activo = {activo} WHERE ID = {IDObservacion}")
        MessageBox.Show("Observacion editada correctamente")
        Me.Reiniciar()
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbTipoObsCancelacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoObsCancelacion.SelectionChangeCommitted
        ob.llenarGrid(GridObservacionCancelacion, cbTipoObsCancelacion.SelectedValue)
    End Sub

    Private Sub btnGuardarObCancelacion_Click(sender As Object, e As EventArgs) Handles btnGuardarObCancelacion.Click
        Dim activo As Integer
        If (chbActivoCancelacion.Checked = True) Then
            activo = 1
        Else
            activo = 0
        End If

        If (txtObservacionCancelacion.Text.Length() = 0) Then
            MessageBox.Show("Ingrese una observación")
            Exit Sub
        End If

        db.execSQLQueryWithoutParams($"INSERT INTO ing_CatObservacionesCancelacion (Observacion, Fecha, ID_TipoOtraObservacion, Usuario, Activo) VALUES('{txtObservacionCancelacion.Text}', GETDATE(), {cbTipoObsCancelacion.SelectedValue}, '{User.getUsername}', {activo})")
        MessageBox.Show("Observacion registrada correctamente")
        Me.Reiniciar()
    End Sub

    Private Sub btnEditarObCancelacion_Click_1(sender As Object, e As EventArgs) Handles btnEditarObCancelacion.Click
        Dim activo As Integer
        If (chbActivoCancelacion.Checked = True) Then
            activo = 1
        Else
            activo = 0
        End If

        If (txtObservacionCancelacion.Text.Length() = 0) Then
            MessageBox.Show("Ingrese una observación")
            Exit Sub
        End If

        db.execSQLQueryWithoutParams($"UPDATE ing_CatObservacionesCancelacion SET Observacion = '{txtObservacionCancelacion.Text}', Fecha = GETDATE(), ID_TipoOtraObservacion = {cbTipoObsCancelacion.SelectedValue}, Usuario = '{User.getUsername}', Activo = {activo} WHERE ID = {IDObservacion}")
        MessageBox.Show("Observacion registrada correctamente")
        Me.Reiniciar()
    End Sub

    Private Sub btnLimpiarObCancelacion_Click(sender As Object, e As EventArgs) Handles btnLimpiarObCancelacion.Click
        Me.Reiniciar()
    End Sub

    Private Sub btnSalirObCancelacion_Click(sender As Object, e As EventArgs) Handles btnSalirObCancelacion.Click
        Me.Close()
    End Sub
End Class