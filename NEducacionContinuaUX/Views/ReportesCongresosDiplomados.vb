Public Class ReportesCongresosDiplomados
    Dim db As DataBaseService = New DataBaseService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Private Sub ReportesCongresosDiplomados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableCongresos As DataTable = db.getDataTableFromSQL($"SELECT id_congreso, nombre FROM portal_congreso WHERE visible = 1")
        ComboboxService.llenarCombobox(cbCongresos, tableCongresos, "id_congreso", "nombre")
        cbCongresos.SelectedIndex = -1
        Dim tableCongresos2 As DataTable = db.getDataTableFromSQL($"SELECT id_congreso, nombre FROM portal_congreso WHERE visible = 1")
        ComboboxService.llenarCombobox(cbCongresos2, tableCongresos2, "id_congreso", "nombre")
        cbCongresos2.SelectedIndex = -1
    End Sub

    Private Sub btnImprimirReporteAsistentes_Click(sender As Object, e As EventArgs) Handles btnImprimirReporteAsistentes.Click
        rep.AgregarFuente("ListadoAsistentesCongresosEDC.rpt")
        rep.AgregarParametros("IDCongreso", cbCongresos.SelectedValue)
        rep.AgregarParametros("NombreCongreso", cbCongresos.Text)
        rep.MostrarReporte()
    End Sub

    Private Sub btnImprimirReporteIngresosCD_Click(sender As Object, e As EventArgs) Handles btnImprimirReporteIngresosCD.Click
        rep.AgregarFuente("ReportePagosPorCongresoDiplomado.rpt")
        rep.AgregarParametros("IDCongreso", cbCongresos2.SelectedValue)
        rep.MostrarReporte()
    End Sub
End Class