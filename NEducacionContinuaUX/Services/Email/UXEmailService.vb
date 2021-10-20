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
    Public Async Sub sendEmail(email As EmailModel)
        Dim client As HttpClient = New HttpClient()

        Try
            Dim URL = $"{ EnviromentService.UXServiceEmail }/api/email/send-simple"

            Dim json As String = JsonConvert.SerializeObject(email)
            Dim data As StringContent = New StringContent(json, Encoding.UTF8, "application/json")

            Dim response = Await client.PostAsync(URL, data)
            Dim result As String = Await response.Content.ReadAsStringAsync()

            If Not result.Contains("mensaje") Then

                If result.Contains("error") Then
                    Throw New Exception("Ocurrió un error en el servidor, verifique los logs")
                Else
                    Throw New Exception("El servidor de correos está caido")
                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

	''' <summary>
    ''' Envio de email con path de archivo adjunto (el archivo debe estar en el servidor)
    ''' </summary>
    ''' <param name="email"></param>
    Public Async Sub sendEmailWithFile(emailModel As EmailModel)
        Dim client As HttpClient = New HttpClient()

        Try
            Dim URL = $"{ EnviromentService.UXServiceEmail }/api/email/send-file"

            Dim json As String = JsonConvert.SerializeObject(emailModel)
            Dim data As StringContent = New StringContent(json, Encoding.UTF8, "application/json")

            Dim response = Await client.PostAsync(URL, data)
            Dim result As String = Await response.Content.ReadAsStringAsync()

            If Not result.Contains("mensaje") Then

                If result.Contains("error") Then
                    Throw New Exception("Ocurrió un error en el servidor, verifique los logs")
                Else
                    Throw New Exception("El servidor de correos está caido")
                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

	''' <summary>
    ''' Envio de email con archivo adjunto en base64, preferiblemente usar cuando se adjunte un PDF, funciona con archivos locales
    ''' </summary>
    ''' <param name="email"></param>
    Public Async Sub sendEmailWithFileBytes(emailModel As EmailModel)
        Dim client As HttpClient = New HttpClient()

        Try
            Dim URL = $"{ EnviromentService.UXServiceEmail }/api/email/send-file-base"

            Dim base64 = Convert.ToBase64String(emailModel.BytesFile, 0, emailModel.BytesFile.Length)

            emailModel.File = base64

            Dim json As String = JsonConvert.SerializeObject(emailModel)
            Dim data As StringContent = New StringContent(json, Encoding.UTF8, "application/json")

            Dim response = Await client.PostAsync(URL, data)
            Dim result As String = Await response.Content.ReadAsStringAsync()

            If Not result.Contains("mensaje") Then

                If result.Contains("error") Then
                    Throw New Exception("Ocurrió un error en el servidor, verifique los logs")
                Else
                    Throw New Exception("El servidor de correos está caido")
                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class
