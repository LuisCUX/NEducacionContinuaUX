Imports System.Security.Cryptography
Imports System.Text
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

    Function EncriptarAES(texto As String, clave As String) As String
        Dim key = New Rfc2898DeriveBytes(clave, Encoding.UTF8.GetBytes("SaltFijo12345678"))
        Dim aesAlg As Aes = Aes.Create()
        aesAlg.Key = key.GetBytes(32) ' 256 bits
        aesAlg.IV = key.GetBytes(16)  ' 128 bits

        Dim encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)

        Using ms = New IO.MemoryStream()
            Using cs = New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                Using sw = New IO.StreamWriter(cs)
                    sw.Write(texto)
                End Using
            End Using
            Return Convert.ToBase64String(ms.ToArray())
        End Using
    End Function
End Class