Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Se instancia el WS de Timbrado.
        Dim ServicioTimbrado_FEL As New TimbradoUXReal.WSCFDI33Client

        'Se instancia la Respuesta del WS de Timbrado.
        Dim RespuestaServicio_FEL As New TimbradoUXReal.RespuestaTFD33

        'Se realiza la petición al WebService, almacenando la respuesta en el objeto RespuestaTFD (RespuestaServicio_FEL)
        'Los parametros son usuario,password,referencia
        'Los datos de acceso se deben solicitar a FEL.
        RespuestaServicio_FEL = ServicioTimbrado_FEL.ConsultarTimbrePorReferencia("ECU150924HR4", "JCXM5@uUgr+", TextBox1.Text)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class