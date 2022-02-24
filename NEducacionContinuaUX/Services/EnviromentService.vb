Imports System.Configuration

Public Class EnviromentService
    Public Shared Property enviromentStatus As String
    Public Shared Property serverIP As String
    Public Shared Property dbName As String
    Public Shared Property dbUsername As String
    Public Shared Property dbPassword As String
    Public Shared Property connectionString As String
    Public Shared Property reportesPath As String
    Public Shared Property RFCEDC As String
    Public Shared Property ClientID As String
    Public Shared Property ClientSecret As String
    Public Shared Property UXServiceEmail As String

    Public Shared Sub setEnviroment()
        'If (System.Diagnostics.Debugger.IsAttached) Then
        '    serverIP = ConfigurationSettings.AppSettings.Get("developmentServerIP")
        '    dbName = ConfigurationSettings.AppSettings.Get("db")
        '    dbUsername = ConfigurationSettings.AppSettings.Get("user")
        '    dbPassword = ConfigurationSettings.AppSettings.Get("password")
        '    connectionString = $"Data Source={serverIP}; Initial Catalog={dbName}; User ID='{dbUsername}'; Password='{dbPassword}';"
        '    reportesPath = ConfigurationSettings.AppSettings.Get("PathReportesPrueba").ToString()
        '    RFCEDC = ConfigurationSettings.AppSettings.Get("RFC").ToString()
        '    ClientID = ConfigurationSettings.AppSettings.Get("ClientID").ToString()
        '    ClientSecret = ConfigurationSettings.AppSettings.Get("ClientSecret").ToString()
        'Else
        '    serverIP = ConfigurationSettings.AppSettings.Get("productionServerIP")
        '    dbName = ConfigurationSettings.AppSettings.Get("productiondb")
        '    dbUsername = ConfigurationSettings.AppSettings.Get("productionuser")
        '    dbPassword = ConfigurationSettings.AppSettings.Get("productionpassword")
        '    connectionString = $"Data Source={serverIP}; Initial Catalog={dbName}; User ID='{dbUsername}'; Password='{dbPassword}';"
        '    reportesPath = ConfigurationSettings.AppSettings.Get("PathReportesProduccion").ToString()
        '    RFCEDC = ConfigurationSettings.AppSettings.Get("RFC").ToString()
        '    ClientID = ConfigurationSettings.AppSettings.Get("ClientID").ToString()
        '    ClientSecret = ConfigurationSettings.AppSettings.Get("ClientSecret").ToString()
        'End If

        If (System.Diagnostics.Debugger.IsAttached) Then
            serverIP = ConfigurationSettings.AppSettings.Get("developmentServerIP")
            dbName = ConfigurationSettings.AppSettings.Get("db")
            dbUsername = ConfigurationSettings.AppSettings.Get("user")
            dbPassword = ConfigurationSettings.AppSettings.Get("password")
            connectionString = $"Data Source={serverIP}; Initial Catalog={dbName}; User ID='{dbUsername}'; Password='{dbPassword}';"
            reportesPath = ConfigurationSettings.AppSettings.Get("PathReportesPrueba").ToString()
            RFCEDC = ConfigurationSettings.AppSettings.Get("RFC").ToString()
            ClientID = ConfigurationSettings.AppSettings.Get("ClientID").ToString()
            ClientSecret = ConfigurationSettings.AppSettings.Get("ClientSecret").ToString()
            UXServiceEmail = ConfigurationSettings.AppSettings.Get("ux_email_base_route").ToString()
        Else
            serverIP = ConfigurationSettings.AppSettings.Get("developmentServerIP")
            dbName = ConfigurationSettings.AppSettings.Get("db")
            dbUsername = ConfigurationSettings.AppSettings.Get("user")
            dbPassword = ConfigurationSettings.AppSettings.Get("password")
            connectionString = $"Data Source={serverIP}; Initial Catalog={dbName}; User ID='{dbUsername}'; Password='{dbPassword}';"
            reportesPath = ConfigurationSettings.AppSettings.Get("PathReportesPrueba").ToString()
            RFCEDC = ConfigurationSettings.AppSettings.Get("RFC").ToString()
            ClientID = ConfigurationSettings.AppSettings.Get("ClientID").ToString()
            ClientSecret = ConfigurationSettings.AppSettings.Get("ClientSecret").ToString()
            UXServiceEmail = ConfigurationSettings.AppSettings.Get("ux_email_base_route").ToString()
        End If
    End Sub
End Class
