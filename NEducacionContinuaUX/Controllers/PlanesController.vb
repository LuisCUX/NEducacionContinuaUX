Public Class PlanesController
    Sub llenarComboBoxes(cbNoPagos As ComboBox)
        cbNoPagos.Items.Clear()
        For x = 0 To 9
            cbNoPagos.Items.Add(x + 1)
        Next
    End Sub
End Class
