Public Class ObservacionesController
    Dim db As DataBaseService = New DataBaseService
    Sub tabObservacionesCancelacion(cbTipoObsCancelacion As ComboBox, GridObservaciones As DataGridView)
        Dim tableTipoObservaciones As DataTable = db.getDataTableFromSQL("SELECT ID, Tipo_Observacion FROM ing_CatObservacionesCancelacionTipo")
        ComboboxService.llenarCombobox(cbTipoObsCancelacion, tableTipoObservaciones, "ID", "Tipo_Observacion")

        Dim tableObservacionesCancelaciones As DataTable = db.getDataTableFromSQL("SELECT ID, Observacion FROM ing_CatObservacionesCancelacion WHERE Activo = 1")

        For Each observacion As DataRow In tableObservacionesCancelaciones.Rows
            GridObservaciones.Rows.Add(observacion("ID"), observacion("Observacion"))
        Next
    End Sub
End Class
