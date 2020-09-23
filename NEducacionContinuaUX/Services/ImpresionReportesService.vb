Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ImpresionReportesService
    Private reporte As ReportDocument

    Public Sub AgregarFuente(path As String)
        Try
            Me.reporte = New ReportDocument()
            reporte.Load($"{EnviromentService.reportesPath}{path}")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub AgregarParametros(NombreParametro As String, Value As Object)
        Try
            Me.reporte.SetParameterValue(NombreParametro, Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub MostrarReporte()
        Dim reportViewer As ReportViewer = New ReportViewer(reporte)
        reportViewer.Show()
    End Sub
End Class
