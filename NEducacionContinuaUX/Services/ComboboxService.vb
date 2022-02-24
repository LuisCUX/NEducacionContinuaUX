Public Class ComboboxService
    Public Shared Sub llenarCombobox(combo As ComboBox, datatable As DataTable, value As String, display As String)
        combo.DataSource = Nothing
        combo.DataSource = datatable
        combo.DisplayMember = display
        combo.ValueMember = value
    End Sub

    Public Shared Sub llenarComboboxVacio(combo As ComboBox, datatable As DataTable, value As String, display As String)
        combo.DataSource = Nothing
        combo.DataSource = datatable
        combo.DisplayMember = display
        combo.ValueMember = value

        combo.SelectedValue = -1
    End Sub
End Class
