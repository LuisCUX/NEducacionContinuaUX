Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Public Class PagosCreditoController
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim xml As XmlService = New XmlService()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Dim abono As Boolean = False
    Dim co As CobrosController = New CobrosController()
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder

    Function cobroCredito(IDCredito As Integer, CantidadAbonada As Decimal, MontoAnterior As Decimal, MontoNuevo As Decimal, Matricula As String, NumPago As Integer) As Integer
        Try
            Dim IDXML As Integer
            Dim Folio As String = co.obtenerFolio("Pago")
            db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosCredito(ID_Credito, Folio, NumPago, Monto_Anterior, Monto_Actual, Monto_Abonado, Fecha, Activo) VALUES ({IDCredito}, '{Folio}', {NumPago}, {MontoAnterior}, {MontoNuevo}, {CantidadAbonada}, GETDATE(), 1)")
            db.execSQLQueryWithoutParams($"UPDATE ing_Creditos SET NumAbonos = NumAbonos + 1, Cantidad_Abonada = Cantidad_Abonada + {CantidadAbonada} WHERE ID = {IDCredito}")
            db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Usuario = '{User.getUsername()}'")

            If (MontoNuevo = 0) Then

            End If
            MessageBox.Show("Abono registrado correctamente")
            Return 1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return 0
        End Try
    End Function
End Class
