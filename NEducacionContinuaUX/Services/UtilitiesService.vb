Public Class UtilitiesService
    Private Shared db As DataBaseService = New DataBaseService()

    Public Shared Function getNivelTurno(Matricula As String) As String()
        Dim claveCarrera As String = Matricula.Substring(4, 2)
        Dim Nivel As String = db.exectSQLQueryScalar($"SELECT nivel FROM ux.dbo.dae_catCarreras WHERE clave = '{claveCarrera}'")
        Dim Turno As String = db.exectSQLQueryScalar($"SELECT turno FROM ux.dbo.dae_catCarreras WHERE clave = '{claveCarrera}'")
        Return {Nivel, Turno.Substring(0, 1)}
    End Function

    Public Shared Function getPeriodoActualNT(Nivel As String, Turno As String) As String
        Dim periodo As String = db.exectSQLQueryScalar($"SELECT periodo FROM ux.dbo.dae_catPeriodos WHERE activo = 1 AND actual = 1 AND turno = '{Nivel}' AND nivel = '{Turno}'")
        Return periodo
    End Function
End Class