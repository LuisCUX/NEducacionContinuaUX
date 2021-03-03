Public Class ReportesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Private Sub ReportesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbTIpoReporte.Items.Add("Individual")
        cbTIpoReporte.Items.Add("Global")
        If (User.getPerfil = "Cajero") Then
            cbTIpoReporte.Enabled = False
            cbCajero.Enabled = False
        Else
            cbTIpoReporte.Enabled = True
            cbCajero.Enabled = True
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

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        If (cbTIpoReporte.Text = "Individual") Then
            rep.AgregarFuente("ReporteCorteCajaEDC.rpt")
            rep.AgregarParametros("Usuario", cbCajero.Text)
        ElseIf (cbTIpoReporte.Text = "Global") Then
            rep.AgregarFuente("ReporteCorteCajaEDC.rpt")
            rep.AgregarParametros("Usuario", "")
        End If
        rep.AgregarParametros("FechaFin", dtPickerFin.Text)
        rep.AgregarParametros("FechaInicio", dtPickerInicio.Text)
        rep.MostrarReporte()
    End Sub
End Class