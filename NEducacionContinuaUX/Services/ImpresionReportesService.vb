Imports System.Configuration
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ImpresionReportesService
    Private reporte As New ReportDocument

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
        Dim reportViewer As ReportViewer = New ReportViewer(Me.reporte)
        reportViewer.Show()
    End Sub

    Public Sub CerrarReporte()
        reporte.Close()
    End Sub

    Public Function obtenerReporteByte() As Byte()
        Try
            Dim result() As Byte = Nothing
            Dim oStream As Stream
            reporte.SetDatabaseLogon(EnviromentService.dbUsername, EnviromentService.dbPassword, EnviromentService.serverIP, EnviromentService.dbName)
            oStream = Me.reporte.ExportToStream(ExportFormatType.PortableDocFormat)

            Dim bytes(oStream.Length) As Byte

            oStream.Read(bytes, 0, Convert.ToInt64(oStream.Length - 1))

            result = bytes

            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Sub guardarReporte(folio As String)
        reporte.SetDatabaseLogon(EnviromentService.dbUsername, EnviromentService.dbPassword, EnviromentService.serverIP, EnviromentService.dbName)

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            Dim FilePath As String = $"\\192.168.1.241\ti\NEducacionContinua\FacturaTemp\{folio}.pdf"
            CrDiskFileDestinationOptions.DiskFileName = FilePath
            CrExportOptions = reporte.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            reporte.Export()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class