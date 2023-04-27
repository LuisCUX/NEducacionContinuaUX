Public Class ModalAutConPorcentaje
    Dim ac As AutorizacionCondonacionController = New AutorizacionCondonacionController()
    Dim precioDec As Decimal
    Dim db As DataBaseService = New DataBaseService
    Private Sub ModalAutConPorcentaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim info As String = $"{ObjectBagService.getItem("Text")}#"
        Dim IDConcepto As Integer = ac.Extrae_Cadena(info, "[", "]")
        precioDec = db.exectSQLQueryScalar($"SELECT costoUnitario FROM ing_AsignacionPagoOpcionalExterno WHERE ID = {IDConcepto}")
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

    Sub CalcularPorcentajes(porcentaje As Double)
        Dim Descuento As Decimal = (precioDec / 100) * porcentaje
        Dim nuevoTotal As Decimal = precioDec - Descuento

        txtDescuento.Text = Format(CDec(Descuento), "#####0.00")
        txtNtotal.Text = Format(CDec(nuevoTotal), "#####0.00")
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
        ObjectBagService.clearBag()
        AutorizacionCondonacionEDC.TreeCondonaciones.SelectedNode.Checked = True
        AutorizacionCondonacionEDC.TreeCondonaciones.SelectedNode.SelectedImageIndex = 1
        AutorizacionCondonacionEDC.GridCondonaciones.Rows.Add(text, CDec(txtPorcentaje.Text), 2, Convert.ToDecimal(txtNtotal.Text))
        AutorizacionCondonacionEDC.Enabled = True
        Me.Close()
    End Sub

    Private Sub txtPorcentaje_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPorcentaje.KeyUp
        If (txtPorcentaje.Text = "") Then
            txtDescuento.Text = "0.00"
            txtNtotal.Text = precioDec
            Exit Sub
        End If
        Me.CalcularPorcentajes(Convert.ToDouble(txtPorcentaje.Text))
    End Sub
End Class