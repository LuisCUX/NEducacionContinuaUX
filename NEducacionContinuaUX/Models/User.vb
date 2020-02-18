Public Class User
    Private Shared Property Username As String
    Private Shared Property NUP As String
    Private Shared Property Nombre As String
    Private Shared Property Perfil As String

    Public Shared Sub setModel(_username As String, _nup As String, _nombre As String, _perfil As String)
        Username = _username
        NUP = _nup
        Nombre = _nombre
        Perfil = _perfil
    End Sub

    Public Shared Function getUsername()
        Return Username
    End Function

    Public Shared Function getNUP()
        Return NUP
    End Function

    Public Shared Function getNombre()
        Return Nombre
    End Function

    Public Shared Function getPerfil()
        Return Perfil
    End Function
End Class
