Imports System.ComponentModel

Public Class ModalDescuento
    Dim row As Integer
    Dim column As Integer
    Dim costoOriginal As Decimal
    Private Sub ModalDescuento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        row = ObjectBagService.getItem("Row")
        column = ObjectBagService.getItem("Column")
        costoOriginal = ObjectBagService.getItem("Costo")
        ObjectBagService.clearBag()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (CDec(txtDescuento.Text) > costoOriginal) Then
            MessageBox.Show("No puede ingresar una cantidad superior al costo unitario del concepto, ingrese una cantidad valida.")
            Exit Sub
        Else
            AsignacionPlanesEDC.GridActual3.Rows(row).Cells(column).Value = Format(CDec(txtDescuento.Text), "#####0.00")
            Me.Close()
        End If

    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
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
        ElseIf InStr(txtDescuento.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ModalDescuento_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        AsignacionPlanesEDC.Enabled = True
    End Sub
End Class