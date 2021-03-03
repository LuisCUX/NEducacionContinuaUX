Public Class IVAEDC
    Dim db As DataBaseService = New DataBaseService()
    Private Sub IVA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblIVAActual.Text = db.exectSQLQueryScalar("SELECT valorIVA FROM ing_CatIVA WHERE ID = 1")
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        db.execSQLQueryWithoutParams($"UPDATE ing_CatIVA SET valorIVA = {CDec(txtNuevoIVA.Text)} WHERE ID = 1")
        MessageBox.Show("Cambios guardados correctamente")
        Me.Reiniciar()
    End Sub

    Private Sub txtNuevoIVA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNuevoIVA.KeyPress
        Dim num_cantidad As Decimal = 0
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("0123456789.", Chr(KeyAscii)) = 0 Then
            If KeyAscii <> 8 Then
                KeyAscii = 0
            End If
            e.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        ElseIf InStr(txtNuevoIVA.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        IVA_Load(Me, Nothing)
    End Sub
End Class