''' <summary>
''' Representa la estructura de un correo electronico con el fin de ser enviado
''' </summary>
Public Class EmailModel
    ''' <summary>
    ''' Texto del asunto del email
    ''' </summary>
    Public Property Asunto As String
	''' <summary>
    ''' Contenido del email, puede ser texto plano o contener etiquetas HTML
    ''' </summary>
    Public Property Mensaje As String
    ''' <summary>
    ''' Arreglo con los emails destinos
    ''' </summary>
    Public Property Destino As List(Of String)
    ''' <summary>
    ''' Path del archivo a adjuntar
    ''' </summary>
    Public Property File As String
	''' <summary>
    ''' Arreglo de bytes de un archivo a adjuntar
    ''' </summary>
	Public Property BytesFile As Byte()

    Public Property FileName As String
End Class
