Public Class NEmailStructureModel
    ''' <summary>
    ''' Texto del asunto del email
    ''' </summary>
    Public Property [to] As String
    ''' <summary>
    ''' Contenido del email, puede ser texto plano o contener etiquetas HTML
    ''' </summary>
    Public Property subject As String
    ''' <summary>
    ''' Arreglo con los emails destinos
    ''' </summary>
    Public Property message As String
    ''' <summary>
    ''' Arreglo de bytes de un archivo a adjuntar
    ''' </summary>
    Public Property attatchment1 As String
    ''' <summary>
    ''' Arreglo de bytes de un archivo a adjuntar
    ''' </summary>
    Public Property attatchment2 As String
    ''' <summary>
    ''' Arreglo de bytes de una imagen a adjuntar
    ''' </summary>
    Public Property attatchmentImg As String
    ''' <summary>
    ''' Nombre de archivos a adjuntar
    ''' </summary>
    Public Property nameFile As String
End Class
