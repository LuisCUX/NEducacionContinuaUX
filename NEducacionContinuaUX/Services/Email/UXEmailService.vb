Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft.Json
Imports Sistema_Académico_UX

Public Class UXServiceEmail

    ''' <summary>
    ''' Envio de email sencillo
    ''' </summary>
    ''' <param name="email"></param>
    Public Async Sub sendEmail(email As NEmailStructureModel)
        Dim client As HttpClient = New HttpClient()

        Try
            Dim URL = $"http://192.168.1.12:3001/api/emails/send-email"

            Dim json As String = JsonConvert.SerializeObject(email)
            Dim jsonHeader As String = "{""emails"": [jsonCompleto]}"
            jsonHeader = jsonHeader.Replace("jsonCompleto", json)
            Dim data As StringContent = New StringContent(jsonHeader, Encoding.UTF8, "application/json")

            Dim response = Await client.PostAsync(URL, data)
            Dim result As String = Await response.Content.ReadAsStringAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Envio de email con archivo adjunto en base64, preferiblemente usar cuando se adjunte un PDF, funciona con archivos locales
    ''' </summary>
    ''' <param name="email"></param>
    Public Async Sub sendEmailWithFileBytes(emailModel As NEmailStructureModel, attatchment1 As Byte(), attatchment2 As Byte())
        Dim client As HttpClient = New HttpClient()

        Try
            Dim URL = $"http://192.168.1.12:3001/api/emails/send-email-pdfxml/"

            Dim base64 = Convert.ToBase64String(attatchment1, 0, attatchment1.Length)
            Dim base642 = Convert.ToBase64String(attatchment2, 0, attatchment2.Length)

            emailModel.attatchment1 = base64
            emailModel.attatchment2 = base642

            Dim json As String = JsonConvert.SerializeObject(emailModel)
            Dim jsonHeader As String = "{""emails"": [jsonCompleto]}"
            jsonHeader = jsonHeader.Replace("jsonCompleto", json)
            Dim data As StringContent = New StringContent(jsonHeader, Encoding.UTF8, "application/json")

            Dim response = Await client.PostAsync(URL, data)
            Dim result As String = Await response.Content.ReadAsStringAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
