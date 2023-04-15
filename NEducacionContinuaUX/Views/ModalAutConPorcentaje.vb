Public Class ModalAutConPorcentaje
    Private Sub ModalAutConPorcentaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If (txtPorcentaje.Text.Length = 2) Then
            txtPorcentaje.Clear()
            Exit Sub
        End If
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtPorcentaje.Text = "") Then
            MessageBox.Show("Ingrese un porcentaje")
            Exit Sub
        End If
        Dim text As String = ObjectBagService.getItem("Text")
        AutorizacionCondonacionEDC.TreeCondonaciones.SelectedNode.Checked = True
        AutorizacionCondonacionEDC.TreeCondonaciones.SelectedNode.SelectedImageIndex = 1
        AutorizacionCondonacionEDC.GridCondonaciones.Rows.Add(text, CDec(txtPorcentaje.Text), 2)
        AutorizacionCondonacionEDC.Enabled = True
        Me.Close()
    End Sub
End Class