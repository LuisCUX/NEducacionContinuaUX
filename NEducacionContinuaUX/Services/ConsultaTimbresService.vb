Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Public Class ConsultaTimbresService

    Public Shared Sub EstatusTimbre()

        Dim timbresRestantes As Integer = 0
        Dim ServicioTimbrado As New TimbradoUXPruebas.WSCFDI33Client
        Dim RespuestaServicio As New TimbradoUXPruebas.RespuestaCreditos
        Dim RespuestaDetalleCreditos As New List(Of TimbradoUXPruebas.DetallesPaqueteCreditos)
        Try
            RespuestaServicio = ServicioTimbrado.ConsultarCreditos("ECU150924D33", "contRa$3na")
            If RespuestaServicio.OperacionExitosa = True Then

                Dim respuestaTimbres As String = ""

                RespuestaDetalleCreditos = RespuestaServicio.Paquetes.ToList()

                For Each Paquete As TimbradoUXPruebas.DetallesPaqueteCreditos In RespuestaDetalleCreditos

                    timbresRestantes = Paquete.TimbresRestantes

                    respuestaTimbres += "En Uso: " + Paquete.EnUso.ToString + vbNewLine
                    respuestaTimbres += "Fecha Activacion: " + IIf(Paquete.FechaActivacion Is Nothing, "", Paquete.FechaActivacion) + vbNewLine
                    respuestaTimbres += "Fecha Vencimiento: " + IIf(Paquete.FechaVencimiento Is Nothing, "", Paquete.FechaVencimiento) + vbNewLine
                    respuestaTimbres += "Paquete De Timbres: " + Paquete.Paquete + vbNewLine
                    respuestaTimbres += "Timbres: " + Paquete.Timbres.ToString + vbNewLine

                    respuestaTimbres += "Timbres Restantes: " + timbresRestantes.ToString + vbNewLine
                    respuestaTimbres += "Timbres Usados: " + Paquete.TimbresUsados.ToString + vbNewLine
                    respuestaTimbres += "Vigente: " + IIf(Paquete.Vigente.ToString Is Nothing, "", Paquete.Vigente.ToString) + vbNewLine

                Next

                MsgBox(respuestaTimbres)
            Else
                MsgBox(RespuestaServicio.MensajeError + vbNewLine)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class
