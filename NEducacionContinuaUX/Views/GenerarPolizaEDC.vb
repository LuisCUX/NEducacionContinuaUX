Public Class GenerarPolizaEDC
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Dim db As DataBaseService = New DataBaseService()
    Dim pc As PolizaController = New PolizaController()
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        rep.AgregarFuente("ReportePolizaEDC.rpt")
        rep.AgregarParametros("FechaFin", Me.obtenerFechaFormato(dtPickerFin))
        rep.AgregarParametros("FechaInicio", Me.obtenerFechaFormato(dtPickerInicio))
        rep.MostrarReporte()
    End Sub

    Function obtenerFechaFormato(dt As DateTimePicker)
        Dim FechaFormateada As String
        FechaFormateada = $"{dt.Value.Year}-{dt.Value.Month}-{dt.Value.Day}"
        Return FechaFormateada
    End Function

    Private Sub btnPol_Click(sender As Object, e As EventArgs) Handles btnPol.Click
        Dim listaConceptosPoliza As List(Of ConceptoPoliza)
        listaConceptosPoliza = pc.llenarListaPoliza(Me.obtenerFechaFormato(dtPickerInicio), Me.obtenerFechaFormato(dtPickerFin))
        Dim xmlPoliza As String = pc.generarXMLPol("1", listaConceptosPoliza, "77777777777", dtPickerInicio)
        Dim saveFileDialog1 As New SaveFileDialog
        saveFileDialog1.InitialDirectory = "C:\"
        saveFileDialog1.Title = "Guardar archivo XML"
        saveFileDialog1.DefaultExt = "pol"
        saveFileDialog1.Filter = "POL files (*.pol)|"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        saveFileDialog1.ShowDialog()
        Dim doc As XDocument = XDocument.Parse(xmlPoliza)
        doc.Save(saveFileDialog1.FileName)
    End Sub

    Private Sub GenerarPolizaEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conceptosSinCuenta As Integer = db.exectSQLQueryScalar($"SELECT COUNT(ID) FROM ing_PagosOpcionales WHERE Activo = 1 AND cuentaPoliza IS NULL")
        If (conceptosSinCuenta > 0) Then
            MessageBox.Show("Hay conceptos sin cuentas registradas")
            ModalCuentasPoliza.ShowDialog()
        End If
    End Sub
End Class