Public Class ComboboxService
    Public Shared Sub llenarCombobox(combo As ComboBox, datatable As DataTable, value As String, display As String)
        combo.DataSource = Nothing
        combo.DataSource = datatable
        combo.DisplayMember = display
        combo.ValueMember = value
    End Sub
End Class
