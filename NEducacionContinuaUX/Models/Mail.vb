Public Class Mail
    Public Property Destino As String
    Public Property Asunto As String
    Public Property Mensaje As String
    Public Property PathFile As String
    Public Property BytesFile As Byte()
    Public Property BytesFile2 As Byte()
    Public Property FileName As String
    Public Property FileName2 As String

    Public Function setMail(Destino As String, Asunto As String, Mensaje As String) As Mail
        Me.Destino = Destino
        Me.Asunto = Asunto
        Me.Mensaje = Mensaje
        Return Me
    End Function

    Public Function setMailPath(Destino As String, Asunto As String, Mensaje As String, PathFile As String) As Mail
        Me.Destino = Destino
        Me.Asunto = Asunto
        Me.Mensaje = Mensaje
        Me.PathFile = PathFile
        Return Me
    End Function

    Public Function setMailByte(Destino As String, Asunto As String, Mensaje As String, BytesFile As Byte(), BytesFile2 As Byte(), FileName As String, FileName2 As String) As Mail
        Me.Destino = Destino
        Me.Asunto = Asunto
        Me.Mensaje = Mensaje
        Me.BytesFile = BytesFile
        Me.BytesFile2 = BytesFile2
        Me.FileName = FileName
        Me.FileName2 = FileName2
        Return Me
    End Function
End Class
