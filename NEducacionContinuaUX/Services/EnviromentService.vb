Imports System.Configuration

Public Class EnviromentService
    Public Shared Property enviromentStatus As String
    Public Shared Property serverIP As String
    Public Shared Property dbName As String
    Public Shared Property dbUsername As String
    Public Shared Property dbPassword As String
    Public Shared Property connectionString As String

    Public Shared Sub setEnviroment()
        If (System.Diagnostics.Debugger.IsAttached) Then
            serverIP = ConfigurationSettings.AppSettings.Get("developmentServerIP")
            dbName = ConfigurationSettings.AppSettings.Get("db")
            dbUsername = ConfigurationSettings.AppSettings.Get("user")
            dbPassword = ConfigurationSettings.AppSettings.Get("password")
            connectionString = $"Data Source={serverIP}; Initial Catalog={dbName}; User ID='{dbUsername}'; Password='{dbPassword}';"
        Else
            serverIP = ConfigurationSettings.AppSettings.Get("productionServerIP")
        End If
    End Sub
End Class
