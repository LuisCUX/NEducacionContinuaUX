Imports System.Net
Imports System.Threading
Imports Google.Apis.Admin.Directory.directory_v1
Imports Google.Apis.Admin.Directory.directory_v1.Data
Imports Google.Apis.Auth.GoogleJsonWebSignature
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Auth.OAuth2.Flows
Imports Google.Apis.Auth.OAuth2.Responses
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports MailKit.Net.Smtp
Imports MailKit.Security
Imports MimeKit

Class EmailService
    Private access_token As String = ""
    Private jwtPayload As Payload = Nothing
    Private serviceDirectory As New DirectoryService

    Public Async Sub autorizar()
        Dim client_id As String = EnviromentService.ClientID
        Dim client_secret As String = EnviromentService.ClientSecret
        Dim scopes = {"email", "profile", "https://mail.google.com/", DirectoryService.Scope.AdminDirectoryOrgunit, DirectoryService.Scope.AdminDirectoryUser, DirectoryService.Scope.AdminDirectoryUserAlias}
        Dim clientSecrets = New ClientSecrets With {
            .ClientId = client_id,
            .ClientSecret = client_secret
        }
        Dim dataStore = New FileDataStore($"\\192.168.1.241\ti\NEducacionContinua\.ux.edc", True)

        Try
            Dim authFlow = New GoogleAuthorizationCodeFlow(New GoogleAuthorizationCodeFlow.Initializer With {
                .ClientSecrets = clientSecrets,
                .Scopes = scopes,
                .DataStore = dataStore
            })

            Dim token_original As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                scopes,
                "user",
                CancellationToken.None,
                dataStore
            ).Result

            serviceDirectory = New DirectoryService(New BaseClientService.Initializer() With {
                .HttpClientInitializer = token_original
            })

            Dim token_expirado As Boolean = Now > token_original.Token.IssuedUtc.ToLocalTime().AddSeconds(token_original.Token.ExpiresInSeconds)

            If (token_expirado) Then
                Dim refrescado As Boolean = token_original.RefreshTokenAsync(CancellationToken.None).Result
                Dim token_refresh As TokenResponse = authFlow.LoadTokenAsync("user", CancellationToken.None).Result

                jwtPayload = ValidateAsync(token_refresh.IdToken).Result
                access_token = token_refresh.AccessToken
            Else
                jwtPayload = ValidateAsync(token_original.Token.IdToken).Result
                access_token = token_original.Token.AccessToken
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub SendEmail(mail As Mail)
        Me.autorizar()

        Dim resultado As Boolean = False

        Try
            Dim mensaje As New MimeMessage()
            Dim multipart = New Multipart("mixed")
            Dim smtp As New SmtpClient()
            Dim oauth2 As New SaslMechanismOAuth2(jwtPayload.Email, access_token)

            Dim destinatarios = mail.Destino

            For Each destinatario As String In destinatarios
                mensaje.To.Add(MailboxAddress.Parse(destinatario))
            Next

            multipart.Add(New TextPart("html") With {
                .Text = mail.Mensaje
            })

            mensaje.From.Add(New MailboxAddress("UNIVERSIDAD DE XALAPA", jwtPayload.Email))
            mensaje.Subject = mail.Asunto
            mensaje.Body = multipart

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls)
            smtp.Authenticate(oauth2)
            smtp.Send(mensaje)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Async Sub sendEmailWithFile(mail As Mail)
        Me.autorizar()
        Try
            Dim oauth2 As New SaslMechanismOAuth2(jwtPayload.Email, access_token)
            Dim mensaje As New MimeMessage()
            Dim multipart = New Multipart("mixed")
            Dim smtp As New SmtpClient()

            Dim destinatarios = mail.Destino.Split(",")

            For Each destinatario As String In destinatarios
                mensaje.To.Add(MailboxAddress.Parse(destinatario.Trim()))
            Next

            Dim adjunto = New MimeKit.MimePart("application", "pdf") With {
                    .Content = New MimeKit.MimeContent(System.IO.File.OpenRead(mail.PathFile)),
                    .ContentDisposition = New MimeKit.ContentDisposition(MimeKit.ContentDisposition.Attachment),
                    .ContentTransferEncoding = MimeKit.ContentEncoding.Base64,
                    .FileName = mail.FileName
            }

            multipart.Add(New TextPart("html") With {
                .Text = mail.Mensaje
            })

            multipart.Add(adjunto)

            mensaje.From.Add(New MailboxAddress("UNIVERSIDAD DE XALAPA", Me.jwtPayload.Email))
            mensaje.Subject = mail.Asunto
            mensaje.Body = multipart

            Await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls)
            Await smtp.AuthenticateAsync(oauth2)
            Await smtp.SendAsync(mensaje)
        Catch ex As Exception
            MsgBox("Ocurrió un error al envíar el correo, intento nuevamente", MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub sendEmailWithFileBytesCobro(mail As Mail)
        Me.autorizar()
        Try
            Dim mensaje As New MimeMessage()
            Dim multipart = New Multipart("mixed")
            Dim smtp As New SmtpClient()
            Dim oauth2 As New SaslMechanismOAuth2(jwtPayload.Email, access_token)

            Dim destinatarios = mail.Destino.Split(",")

            For Each destinatario As String In destinatarios
                mensaje.To.Add(MailboxAddress.Parse(destinatario.Trim()))
            Next

            Dim streamFactura As New System.IO.MemoryStream(mail.BytesFile)

            Dim adjuntoFactura = New MimeKit.MimePart("application", "pdf") With {
                    .Content = New MimeKit.MimeContent(streamFactura),
                    .ContentDisposition = New MimeKit.ContentDisposition(MimeKit.ContentDisposition.Attachment),
                    .ContentTransferEncoding = MimeKit.ContentEncoding.Base64,
                    .FileName = mail.FileName
            }

            Dim streamXML As New System.IO.MemoryStream(mail.BytesFile2)

            Dim adjuntoXML = New MimeKit.MimePart("application", "xml") With {
                    .Content = New MimeKit.MimeContent(streamXML),
                    .ContentDisposition = New MimeKit.ContentDisposition(MimeKit.ContentDisposition.Attachment),
                    .ContentTransferEncoding = MimeKit.ContentEncoding.Base64,
                    .FileName = mail.FileName2
            }

            multipart.Add(New TextPart("html") With {
                .Text = mail.Mensaje
            })

            multipart.Add(adjuntoFactura)
            multipart.Add(adjuntoXML)

            mensaje.From.Add(New MailboxAddress("UNIVERSIDAD DE XALAPA", jwtPayload.Email))
            mensaje.Subject = mail.Asunto
            mensaje.Body = multipart

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls)
            smtp.Authenticate(oauth2)
            smtp.Send(mensaje)
        Catch ex As Exception
            MsgBox("Ocurrió un error al envíar el correo, intento nuevamente", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
