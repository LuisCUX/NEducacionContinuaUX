Imports PdfSharp.Pdf
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.Rendering
Imports PdfSharp.Drawing
Imports System.IO

Public Class PDFService
    Dim db As DataBaseService = New DataBaseService()
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
    Dim utils As UtilitiesService = New UtilitiesService()
    Function getPDFQRCongresos(Matricula As String) As PdfDocument
        Dim document As PdfDocument = New PdfDocument()
        Me.buildDocumentQRCongreso(document, Matricula)

        Dim filename As String = "QR.pdf"
        document.Save(filename)



        ' ...and start a viewer.
        Process.Start(filename)
        Return document
    End Function

    Sub buildDocumentQRCongreso(document As PdfDocument, Matricula As String)
        Dim qrContent As String = db.exectSQLQueryScalar($"SELECT (Matricula_Clave + '@' + Folio) AS qrContent FROM ing_xmlTimbrados WHERE Matricula_Clave = '{Matricula}'")
        Dim mesaCongreso As String = db.exectSQLQueryScalar($"SELECT ISNULL(M.nombre, '') AS nombreMesa
                                                            FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.clave_cliente = 'EC25PS005' AND RC.id_cliente = C.id_cliente
                                                            INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                            INNER JOIN portal_congreso AS CON ON CON.id_congreso = TA.id_congreso
                                                            LEFT JOIN portal_registroMesas AS RM ON RC.id_registro = RM.id_registro
                                                            LEFT JOIN portal_mesa AS M ON RM.id_mesa = M.id_mesa")

        ''Dim img As Bitmap = Me.gernerarQr(utils.EncriptarAES(qrContent, "pxrd99wn"))


        ' Crear una página
        Dim page As PdfPage = document.AddPage()
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)

        ' Configuración de fuentes
        Dim fontTituloPrincipal As New XFont("Verdana", 16, XFontStyle.Bold)
        Dim fontSubtitulo As New XFont("Verdana", 14, XFontStyle.Regular)
        Dim fontTextoQR As New XFont("Verdana", 14, XFontStyle.Regular)

        ' ========================
        ' Insertar el Título Principal
        ' ========================
        ' Medir el ancho y alto reales del texto
        Dim tituloPrincipal As String = "Pase de acceso"
        ' Tamaño y medida del título
        Dim tamañoTitulo As XSize = gfx.MeasureString(tituloPrincipal, fontTituloPrincipal)
        Dim altoTitulo As Double = tamañoTitulo.Height

        ' Dibujar el título
        Dim rectXTitulo As Double = 0
        Dim rectYTitulo As Double = 10 ' Puedes ajustar aquí si quieres que esté un poco más abajo
        Dim anchoRectTitulo As Double = page.Width
        Dim altoRectTitulo As Double = altoTitulo + 4

        gfx.DrawString(tituloPrincipal, fontTituloPrincipal, XBrushes.Black, New XRect(rectXTitulo, rectYTitulo, anchoRectTitulo, altoRectTitulo), XStringFormats.TopCenter)

        ' ========================
        ' Insertar el Banner
        ' ========================
        Dim espacioEntreTituloYBanner As Double = 10 ' separación de 10 puntos
        Dim posicionYBanner As Double = rectYTitulo + altoRectTitulo + espacioEntreTituloYBanner

        Dim bannerPath As String = "\\192.168.1.252\Sistemas\Reportes\EducacionContinua\imagenCongreso\1019.jpeg"
        Dim banner As XImage = XImage.FromFile(bannerPath)

        Dim bannerWidth As Double = banner.PixelWidth * 72 / banner.HorizontalResolution
        Dim bannerHeight As Double = banner.PixelHeight * 72 / banner.HorizontalResolution

        Dim maxBannerWidth As Double = page.Width.Point - 40
        If bannerWidth > maxBannerWidth Then
            Dim scale As Double = maxBannerWidth / bannerWidth
            bannerWidth *= scale
            bannerHeight *= scale
        End If

        Dim bannerX As Double = (page.Width.Point - bannerWidth) / 2
        Dim bannerY As Double = 80

        gfx.DrawImage(banner, 0, posicionYBanner, page.Width.Point, bannerHeight)

        ' ========================
        ' Insertar el Texto Intermedio con salto de línea
        ' ========================
        Dim textoIntermedio As String = $"Taller: {mesaCongreso}"

        Dim espacioEntreBannerYTexto As Double = 20
        Dim textoIntermedioY As Double = bannerY + bannerHeight + espacioEntreBannerYTexto

        Dim margenHorizontal As Double = 40
        Dim areaAnchoDisponible As Double = page.Width.Point - (margenHorizontal * 2)

        ' Dividir texto en palabras
        Dim palabras() As String = textoIntermedio.Split(" "c)
        Dim lineaActual As String = ""
        Dim lineas As New List(Of String)()

        For Each palabra In palabras
            Dim pruebaLinea As String = If(String.IsNullOrEmpty(lineaActual), palabra, lineaActual & " " & palabra)
            Dim anchoPrueba As Double = gfx.MeasureString(pruebaLinea, fontSubtitulo).Width

            If anchoPrueba <= areaAnchoDisponible Then
                lineaActual = pruebaLinea
            Else
                ' Agregar la línea anterior y empezar nueva línea
                lineas.Add(lineaActual)
                lineaActual = palabra
            End If
        Next

        ' Agregar última línea
        If Not String.IsNullOrEmpty(lineaActual) Then
            lineas.Add(lineaActual)
        End If

        ' Dibujar las líneas
        Dim alturaLinea As Double = gfx.MeasureString("Prueba", fontSubtitulo).Height
        Dim yActual As Double = textoIntermedioY

        For Each linea In lineas
            gfx.DrawString(linea, fontSubtitulo, XBrushes.Black, New XRect(margenHorizontal, yActual, areaAnchoDisponible, alturaLinea), XStringFormats.TopCenter)
            yActual += alturaLinea + 5 ' 5 puntos de separación entre líneas
        Next

        ' ========================
        ' Insertar el Texto del QR
        ' ========================
        Dim textoQR As String = "Muestra este código QR para registrar tu asistencia"
        Dim espacioEntreTextoYQR As Double = 30
        Dim textoQR_Y As Double = yActual + espacioEntreTextoYQR

        gfx.DrawString(textoQR, fontTextoQR, XBrushes.Black, New XRect(0, textoQR_Y, page.Width, 30), XStringFormats.TopCenter)

        ' ========================
        ' Insertar el Código QR
        ' ========================
        Dim img As Bitmap = Me.gernerarQr(utils.EncriptarAES(qrContent, "pxrd99wn"))
        Dim qrImage As XImage
        Using ms As New MemoryStream()
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            qrImage = XImage.FromStream(ms)
        End Using

        Dim qrWidth As Double = qrImage.PixelWidth * 72 / qrImage.HorizontalResolution
        Dim qrHeight As Double = qrImage.PixelHeight * 72 / qrImage.HorizontalResolution

        Dim maxQrWidth As Double = page.Width.Point - 40
        If qrWidth > maxQrWidth Then
            Dim scaleQr As Double = maxQrWidth / qrWidth
            qrWidth *= scaleQr
            qrHeight *= scaleQr
        End If

        Dim qrX As Double = (page.Width.Point - qrWidth) / 2
        Dim qrY As Double = textoQR_Y + 40

        gfx.DrawImage(qrImage, qrX, qrY, qrWidth, qrHeight)

        ' ========================
        ' Finalizar
        ' ========================
    End Sub

    Function gernerarQr(QR As String) As Bitmap

        Try
            Dim img As New Bitmap(QR_Generator.Encode(QR.ToString), New Size(220, 220))
            Return img
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function
End Class
