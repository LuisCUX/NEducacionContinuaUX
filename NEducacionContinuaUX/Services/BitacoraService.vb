Public Class BitacoraService
    Public Shared Sub BitacoraCancelacionError(Matricula As String, Folio As String, IDObservacion As String, MensajeError As String, MensajeErrorDetallado As String)
        Dim db As DataBaseService = New DataBaseService
        db.execSQLQueryWithoutParams($"INSERT INTO ing_BitacoraCancelacionError(Matricula, Folio, IDOBservacion, MensajeError, MensajeErrorDetallado, FechaCancelacion, Usuario) VALUES ('{Matricula}', '{Folio}', {IDObservacion}, '{MensajeError}', '{MensajeErrorDetallado}', GETDATE(), '{User.getUsername}')")
    End Sub
End Class
