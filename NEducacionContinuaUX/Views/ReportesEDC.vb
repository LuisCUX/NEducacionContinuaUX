Public Class ReportesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Private Sub ReportesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbTIpoReporte.Items.Add("Individual")
        cbTipoReporte2.Items.Add("Individual")
        cbTIpoReporte.Items.Add("Global")
        cbTipoReporte2.Items.Add("Global")
        If (User.getPerfil = "Cajero") Then
            cbTIpoReporte.Enabled = False
            cbCajero.Enabled = False
        Else
            cbTIpoReporte.Enabled = True
            cbCajero.Enabled = True
        End If

        If (User.getPerfil = "Cajero") Then
            cbTipoReporte2.Enabled = False
            cbCajero2.Enabled = False
        Else
            cbTipoReporte2.Enabled = True
            cbCajero2.Enabled = True
        End If
    End Sub

    Private Sub cbTIpoReporte_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTIpoReporte.SelectionChangeCommitted
        If (cbTIpoReporte.Text = "Individual") Then
            Dim tableCajeros As DataTable = db.getDataTableFromSQL($"SELECT ID, Username FROM ing_Usuarios WHERE Activo = 1")
            ComboboxService.llenarCombobox(cbCajero, tableCajeros, "ID", "Username")
            cbCajero.Enabled = True
        ElseIf (cbTIpoReporte.Text = "Global") Then
            cbCajero.DataSource = Nothing
            cbCajero.Enabled = False
        End If
    End Sub

    Private Sub cbTipoReporte2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoReporte2.SelectionChangeCommitted
        If (cbTipoReporte2.Text = "Individual") Then
            Dim tableCajeros2 As DataTable = db.getDataTableFromSQL($"SELECT ID, Username FROM ing_Usuarios WHERE Activo = 1")
            ComboboxService.llenarCombobox(cbCajero2, tableCajeros2, "ID", "Username")
            cbCajero2.Enabled = True
        ElseIf (cbTIpoReporte2.Text = "Global") Then
            cbCajero2.DataSource = Nothing
            cbCajero2.Enabled = False
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        If (cbTIpoReporte.Text = "Individual") Then
            rep.AgregarFuente("ReporteCorteCajaEDC.rpt")
            rep.AgregarParametros("Usuario", cbCajero.Text)
        ElseIf (cbTIpoReporte.Text = "Global") Then
            rep.AgregarFuente("ReporteCorteCajaEDC.rpt")
            rep.AgregarParametros("Usuario", "")
        End If
        rep.AgregarParametros("FechaFin", Me.obtenerFechaFormato(dtPickerFin))
        rep.AgregarParametros("FechaInicio", Me.obtenerFechaFormato(dtPickerInicio))
        rep.MostrarReporte()
    End Sub

    Private Sub btnGenerar2_Click(sender As Object, e As EventArgs) Handles btnGenerar2.Click
        If (cbTipoReporte2.Text = "Individual") Then
            rep.AgregarFuente("ReporteIngresosDiario.rpt")
            rep.AgregarParametros("Usuario", cbCajero2.Text)
        ElseIf (cbTIpoReporte2.Text = "Global") Then
            rep.AgregarFuente("ReporteIngresosDiario.rpt")
            rep.AgregarParametros("Usuario", "")
        End If
        rep.AgregarParametros("FechaFin", Me.obtenerFechaFormato(dtPickerFin2))
        rep.AgregarParametros("FechaInicio", Me.obtenerFechaFormato(dtPickerInicio2))
        rep.MostrarReporte()
    End Sub

    Function obtenerFechaFormato(dt As DateTimePicker)
        Dim FechaFormateada As String
        FechaFormateada = $"{dt.Value.Year}-{dt.Value.Month}-{dt.Value.Day}"
        Return FechaFormateada
    End Function
End Class