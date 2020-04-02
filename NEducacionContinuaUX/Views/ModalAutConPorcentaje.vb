Public Class ModalAutConPorcentaje
    Private Sub ModalAutConPorcentaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
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
        ElseIf InStr(txtPorcentaje.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ModalAutConPorcentaje_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        AutorizacionCondonacionEDC.Enabled = True
    End Sub
End Class