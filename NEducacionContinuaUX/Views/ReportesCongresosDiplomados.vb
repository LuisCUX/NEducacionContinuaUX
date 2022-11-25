Public Class ReportesCongresosDiplomados
    Dim db As DataBaseService = New DataBaseService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Private Sub ReportesCongresosDiplomados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableCongresos As DataTable = db.getDataTableFromSQL($"SELECT id_congreso, nombre FROM portal_congreso WHERE activo = 1")
        ComboboxService.llenarCombobox(cbCongresos, tableCongresos, "id_congreso", "nombre")
    End Sub

    Private Sub btnImprimirReporteAsistentes_Click(sender As Object, e As EventArgs) Handles btnImprimirReporteAsistentes.Click
        rep.AgregarFuente("ListadoAsistentesCongresosEDC.rpt")
        rep.AgregarParametros("IDCongreso", cbCongresos.SelectedValue)
        rep.AgregarParametros("NombreCongreso", cbCongresos.Text)
        rep.MostrarReporte()
    End Sub
End Class