Public Class GenerarPolizaEDC
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Dim db As DataBaseService = New DataBaseService()
    Dim pc As PolizaController = New PolizaController()
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        If (txtNumPoliza.Text.Length < 1) Then
            MessageBox.Show("Ingrese el número de la póliza")
            Exit Sub
        End If
        rep.AgregarFuente("ReportePolizaEDC.rpt")
        rep.AgregarParametros("FechaFin", Me.obtenerFechaFormato(dtPickerFin))
        rep.AgregarParametros("FechaInicio", Me.obtenerFechaFormato(dtPickerInicio))
        rep.AgregarParametros("NumPoliza", txtNumPoliza.Text)
        rep.AgregarParametros("RangoFolios", Me.getRangoFolios(Me.obtenerFechaFormato(dtPickerInicio), Me.obtenerFechaFormato(dtPickerFin)))
        rep.MostrarReporte()
    End Sub

    Function obtenerFechaFormato(dt As DateTimePicker)
        Dim FechaFormateada As String
        FechaFormateada = $"{dt.Value.Year}-{dt.Value.Month}-{dt.Value.Day}"
        Return FechaFormateada
    End Function

    Private Sub btnPol_Click(sender As Object, e As EventArgs) Handles btnPol.Click
        Try
            If (txtNumPoliza.Text.Length < 1) Then
                MessageBox.Show("Ingrese el número de la póliza")
                Exit Sub
            End If
            Dim listaConceptosPoliza As List(Of ConceptoPoliza)
            listaConceptosPoliza = pc.llenarListaPoliza(Me.obtenerFechaFormato(dtPickerInicio), Me.obtenerFechaFormato(dtPickerFin))
            Dim xmlPoliza As String = pc.generarXMLPol(txtNumPoliza.Text, listaConceptosPoliza, Me.getRangoFolios(Me.obtenerFechaFormato(dtPickerInicio), Me.obtenerFechaFormato(dtPickerFin)), dtPickerInicio)
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GenerarPolizaEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conceptosSinCuenta As Integer = db.exectSQLQueryScalar($"SELECT COUNT(ID) FROM ing_PagosOpcionales WHERE Activo = 1 AND cuentaPoliza IS NULL")
        If (conceptosSinCuenta > 0) Then
            MessageBox.Show("Hay conceptos sin cuentas registradas")
            ModalCuentasPoliza.ShowDialog()
        End If
    End Sub

    Private Sub txtNumPoliza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumPoliza.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Function getRangoFolios(FechaInicio As String, FechaFin As String) As String
        Dim message As String
        Dim Primero As String
        Dim Ultimo As String
        Dim numPagos As Integer
        Dim tableUsuarios As DataTable = db.getDataTableFromSQL($"SELECT Username FROM ing_Usuarios WHERE Activo = 1")

        For Each row As DataRow In tableUsuarios.Rows
            numPagos = db.exectSQLQueryScalar($"SELECT COUNT(DISTINCT Folio) FROM obtenerPolizaEDC('{FechaInicio}', '{FechaFin}') WHERE Cajero = '{row("Username")}'")
            If (numPagos > 0) Then
                Primero = db.exectSQLQueryScalar($"SELECT TOP 1 Folio FROM obtenerPolizaEDC('{FechaInicio}', '{FechaFin}') WHERE Cajero = '{row("Username")}' ORDER BY Folio")
                Ultimo = db.exectSQLQueryScalar($"SELECT TOP 1 Folio FROM obtenerPolizaEDC('{FechaInicio}', '{FechaFin}') WHERE Cajero = '{row("Username")}' ORDER BY Folio DESC")
                message = $"{message} {Primero}-{Ultimo}"
            End If
        Next
        Return message
    End Function
End Class