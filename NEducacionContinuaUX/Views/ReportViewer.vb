Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportViewer
    Private Reporte As ReportDocument



    Public Sub New(reporteExterno As ReportDocument)
        InitializeComponent()
        Reporte = reporteExterno
    End Sub

    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Reporte.SetDatabaseLogon(EnviromentService.dbUsername, EnviromentService.dbPassword, EnviromentService.serverIP, EnviromentService.dbName) '(Conexion.user, Conexion.password, Conexion.servidor, Conexion.db)
            Me.CrystalReportViewer1.ReportSource = Me.Reporte
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class