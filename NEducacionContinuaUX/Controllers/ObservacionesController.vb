Public Class ObservacionesController
    Dim db As DataBaseService = New DataBaseService
    Sub tabObservacionesCancelacion(cbTipoObsCancelacion As ComboBox)
        Dim tableTipoObservaciones As DataTable = db.getDataTableFromSQL("SELECT ID, Tipo_Observacion FROM ing_CatObservacionesCancelacionTipo")
        ComboboxService.llenarCombobox(cbTipoObsCancelacion, tableTipoObservaciones, "ID", "Tipo_Observacion")
    End Sub

    Sub llenarGrid(GridObservaciones As DataGridView, tipoObservacion As Integer)
        GridObservaciones.Rows.Clear()
        Dim tableObservacionesCancelaciones As DataTable = db.getDataTableFromSQL($"SELECT ID, Observacion FROM ing_CatObservacionesCancelacion WHERE ID_TipoOtraObservacion = {tipoObservacion}")

        For Each observacion As DataRow In tableObservacionesCancelaciones.Rows
            GridObservaciones.Rows.Add(observacion("ID"), observacion("Observacion"))
        Next
    End Sub
End Class