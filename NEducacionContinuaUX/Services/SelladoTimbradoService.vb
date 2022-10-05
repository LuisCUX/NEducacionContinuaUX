Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Public Class SelladoTimbradoService
    Dim UUID As String
    Dim db As DataBaseService = New DataBaseService
    Function Sellado(rutaCert As String, passCert As String, cadenaXML As String) As String
        Dim sello As String
        Dim verify As Boolean
        Try
            Dim Cert As New X509Certificate2(rutaCert, passCert, X509KeyStorageFlags.Exportable)
            Dim llave_privada As RSACryptoServiceProvider = DirectCast(Cert.PrivateKey, RSACryptoServiceProvider)
            Dim llave_privada1 As New RSACryptoServiceProvider()
            Dim stringCadenaOriginal() As Byte = System.Text.Encoding.UTF8.GetBytes(cadenaXML)
            llave_privada1.ImportParameters(llave_privada.ExportParameters(True))
            Dim firma As Byte() = llave_privada1.SignData(stringCadenaOriginal, "SHA256")
            sello = Convert.ToBase64String(firma)
            verify = llave_privada1.VerifyData(stringCadenaOriginal, "SHA256", firma)
            Return sello
        Catch ex As Exception
            MsgBox("SE PRODUJO LA SIGUIENTE EXCEPCIÒN: " & ex.ToString, MsgBoxStyle.Critical, "Error al sellar")
            Return "error"
        End Try
    End Function

    Function TimbradoPruebas(xml As String, Folio As String) As String
        If (System.Diagnostics.Debugger.IsAttached) Then

        End If
        Dim timbre As New TimbradoUXPruebas.WSCFDI33Client
        Dim respuesta As New TimbradoUXPruebas.RespuestaTFD33
        Dim xmlResult As String
        Dim web As String = xml


        respuesta = timbre.TimbrarCFDI("ECU150924D33", "contRa$3na", web, Folio)
        If (respuesta.OperacionExitosa = True) Then
            xmlResult = respuesta.XMLResultado
            Return xmlResult
        Else
            Throw New Exception($"Error al timbrar {respuesta.MensajeError}")
            Return "Error"
        End If
    End Function

    Function Timbrado(xml As String, Folio As String) As String
        Dim timbre As New TimbradoUXReal.WSCFDI33Client
        Dim respuesta As New TimbradoUXReal.RespuestaTFD33
        Dim xmlResult As String
        Dim web As String = xml


        respuesta = timbre.TimbrarCFDI("ECU150924HR4", "JCXM5@uUgr+", web, Folio)
        If (respuesta.OperacionExitosa = True) Then
            xmlResult = respuesta.XMLResultado
            Return xmlResult
        Else
            Try
                db.execSQLQueryWithoutParams($"INSERT INTO ing_BitacoraXML(XML, Fecha, Cajero) VALUES ('{xml}', GETDATE(), '{User.getUsername}')")
            Catch ex As Exception
                MessageBox.Show("Error al guardar registro en bitacora")
            End Try
            Throw New Exception($"Error al timbrar {respuesta.MensajeError}")
            Return "Error"
        End If
    End Function

    Function TimbreCancelacionFacturasPrueba(ListaUUID As List(Of TimbradoUXPruebas.DetalleCFDICancelacion)) As String()
        Dim timbre As New TimbradoUXPruebas.WSCFDI33Client
        Dim respuesta As New TimbradoUXPruebas.RespuestaCancelacion
        Dim base64PFX As String = db.exectSQLQueryScalar($"SELECT Contenido FROM ing_catCertificados WHERE Activo = 1")
        base64PFX = base64PFX.Replace("  ", "")
        Dim passwordPFX As String = db.exectSQLQueryScalar($"SELECT Password FROM ing_catCertificados WHERE Activo = 1")

        respuesta = timbre.CancelarCFDI("ECU150924D33", "contRa$3na", EnviromentService.RFCEDC, ListaUUID.ToArray(), base64PFX, passwordPFX)
        Dim RespuestaCancelacionDetallada = respuesta.DetallesCancelacion.ToList()
        Dim estatus As String
        If (respuesta.OperacionExitosa = True) Then
            ''Dim RespuestaCancelacionDetallada = respuesta.DetallesCancelacion.ToList()
            Dim mensajeCancelacion As String
            For Each UUID As TimbradoUXPruebas.DetalleCancelacion In RespuestaCancelacionDetallada

                mensajeCancelacion += UUID.CodigoResultado + " " + vbNewLine
                mensajeCancelacion += UUID.MensajeResultado + " " + vbNewLine
                mensajeCancelacion += UUID.UUID + vbNewLine
                mensajeCancelacion += UUID.EsCancelable + "."
                estatus = mensajeCancelacion
            Next
            Return {"True", respuesta.XMLAcuse, mensajeCancelacion, estatus}
        Else
            Return {"False", respuesta.MensajeError, respuesta.MensajeErrorDetallado}
        End If
    End Function

    Function TimbreCancelacionFacturas(ListaUUID As List(Of TimbradoUXReal.DetalleCFDICancelacion)) As String()
        Dim timbre As New TimbradoUXReal.WSCFDI33Client
        Dim respuesta As New TimbradoUXReal.RespuestaCancelacion
        Dim base64PFX As String = db.exectSQLQueryScalar($"SELECT Contenido FROM ing_catCertificados WHERE Activo = 1")
        base64PFX = base64PFX.Replace("  ", "")
        Dim passwordPFX As String = db.exectSQLQueryScalar($"SELECT Password FROM ing_catCertificados WHERE Activo = 1")

        respuesta = timbre.CancelarCFDI("ECU150924HR4", "JCXM5@uUgr+", EnviromentService.RFCEDC, ListaUUID.ToArray(), base64PFX, passwordPFX)
        Dim RespuestaCancelacionDetallada = respuesta.DetallesCancelacion.ToList()
        If (respuesta.OperacionExitosa = True) Then
            ''Dim RespuestaCancelacionDetallada = respuesta.DetallesCancelacion.ToList()
            Dim mensajeCancelacion As String
            Dim estatus As String
            For Each UUID As TimbradoUXReal.DetalleCancelacion In RespuestaCancelacionDetallada
                mensajeCancelacion += UUID.CodigoResultado + " " + vbNewLine
                mensajeCancelacion += UUID.MensajeResultado + " " + vbNewLine
                mensajeCancelacion += UUID.UUID + vbNewLine
                mensajeCancelacion += UUID.EsCancelable + "."
                estatus = UUID.EsCancelable
            Next
            Return {"True", respuesta.XMLAcuse, mensajeCancelacion, estatus}
        Else
            Return {"False", respuesta.MensajeError, respuesta.MensajeErrorDetallado, ""}
        End If
    End Function
End Class
