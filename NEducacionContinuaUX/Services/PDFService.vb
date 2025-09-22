Imports PdfSharp.Pdf
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.Rendering
Imports PdfSharp.Drawing
Imports System.IO
Imports PdfSharp

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
        ''Process.Start(filename)
        Return document
    End Function

    Sub buildDocumentQRCongreso(document As PdfDocument, Matricula As String)
        Dim qrContent As String = db.exectSQLQueryScalar($"SELECT (Matricula + '@' + Folio) AS qrContent FROM ing_PagosCongresos WHERE Matricula = '{Matricula}'")
        Dim mesaCongreso As String = db.exectSQLQueryScalar($"SELECT ISNULL(M.nombre, '') AS nombreMesa
                                                            FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.clave_cliente = '{Matricula}' AND RC.id_cliente = C.id_cliente
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


    Function getPDFConstanciaCongreso(Matricula As String, tipoConstancia As String, idMesa As Integer) As PdfDocument
        Dim document As PdfDocument = New PdfDocument()
        Me.buildDocumentConstanciaCongreso(document, Matricula, tipoConstancia, idMesa)

        Dim filename As String

        If (tipoConstancia = "General") Then
            filename = $"Constancia de asistencia - {Matricula}.pdf"
        ElseIf (tipoConstancia = "Taller") Then
            filename = $"Constancia de taller - {Matricula}.pdf"
        End If

        'Dim folderPath As String = "C:\Users\LuisUXX\Desktop\Constancias tlaxcala\Talleres\"
        'Dim fullPath As String = System.IO.Path.Combine(folderPath, filename)
        document.Save(filename)


        ' ...and start a viewer.
        Process.Start(filename)
        Return document
    End Function

    Sub buildDocumentConstanciaCongreso(document As PdfDocument, Matricula As String, tipoConstancia As String, idMesa As Integer)
        Dim nombreCliente As String
        Dim libro As String
        Dim foja As String
        Dim fecha As String
        Dim nombreMesa As String
        Dim imparte As String

        Dim rutaImagenFondo As String
        ' Crear una página en orientación horizontal
        Dim page As PdfPage = document.AddPage()
        page.Orientation = PageOrientation.Landscape
        page.Size = PageSize.A4

        ' Crear el contexto gráfico
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)

        ' Cargar imagen de fondo
        If (tipoConstancia = "General") Then
            Dim tableDatosGeneral As DataTable = db.getDataTableFromSQL($"SELECT nombre_cliente, libro, foja, fecha FROM portal_infoConstancias WHERE clave_cliente = '{Matricula}' AND id_tipo_asistencia = 1")
            For Each row As DataRow In tableDatosGeneral.Rows
                nombreCliente = row("nombre_cliente")
                libro = row("libro")
                foja = row("foja")
                fecha = row("fecha")
            Next


            rutaImagenFondo = "C:\Users\LuisUXX\Desktop\CONSTANCIAASISTENCIA.png"
            Dim imagenFondo As XImage = XImage.FromFile(rutaImagenFondo)

            ' Dibujar la imagen de fondo cubriendo toda la hoja
            gfx.DrawImage(imagenFondo, 0, 0, page.Width, page.Height)

            Dim fuenteNombre As New XFont("agencyfb", 24, XFontStyle.Bold)
            gfx.DrawString(nombreCliente, fuenteNombre, XBrushes.Black, New XRect(12, 290, page.Width, 30), XStringFormats.TopCenter)

            ' Fuente para los campos inferiores
            Dim fuenteInferior As New XFont("Calibri", 8, XFontStyle.Regular)


            ' Coordenadas base
            Dim yRegistroBase As Double = 483
            Dim espacioEntreLineas As Double = 12

            ' Medir ancho del texto "Libro 3"
            Dim anchoLibro As Double = gfx.MeasureString(libro, fuenteInferior).Width
            Dim xCentroLibro As Double = 100 + anchoLibro / 2 ' Asumiendo que el texto "Libro 3" empieza en X = 90

            ' Calcular posición centrada para los demás textos
            Dim anchoFoja As Double = gfx.MeasureString(foja, fuenteInferior).Width
            Dim xFoja As Double = xCentroLibro - anchoFoja / 2

            Dim anchoFecha As Double = gfx.MeasureString(fecha, fuenteInferior).Width
            Dim xFecha As Double = xCentroLibro - anchoFecha / 2

            ' Dibujar los textos
            gfx.DrawString(libro, fuenteInferior, XBrushes.Black, New XPoint(100, yRegistroBase))
            gfx.DrawString(foja, fuenteInferior, XBrushes.Black, New XPoint(xFoja, yRegistroBase + espacioEntreLineas))
            gfx.DrawString(fecha, fuenteInferior, XBrushes.Black, New XPoint(xFecha, yRegistroBase + 2 * espacioEntreLineas))

            ' ========================
            ' Insertar el Código QR
            ' ========================
            Dim img As Bitmap = Me.gernerarQrConstancias(Matricula, 1)
            Dim qrImage As XImage
            Using ms As New MemoryStream()
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                qrImage = XImage.FromStream(ms)
            End Using
            gfx.DrawImage(qrImage, 705, 350, 100, 100)

        ElseIf (tipoConstancia = "Taller") Then
            Dim tableDatosGeneral As DataTable = db.getDataTableFromSQL($"SELECT INFO.nombre_cliente, INFO.libro, INFO.foja, INFO.fecha, M.nombre, INFO.imparte FROM portal_infoConstancias AS INFO 
                                                                        INNER JOIN portal_mesa AS M ON M.id_mesa = INFO.id_mesa
                                                                        WHERE clave_cliente = '{Matricula}' AND id_tipo_asistencia = 2")
            For Each row As DataRow In tableDatosGeneral.Rows
                nombreCliente = row("nombre_cliente")
                libro = row("libro")
                foja = row("foja")
                fecha = row("fecha")
                nombreMesa = row("nombre")
                imparte = row("imparte")
            Next

            Dim result As String() = Me.getDatosMesa(idMesa)

            rutaImagenFondo = "C:\Users\LuisUXX\Desktop\CONSTANCIATALLERES.png"
            Dim imagenFondo As XImage = XImage.FromFile(rutaImagenFondo)
            Dim xTaller As Integer = 14
            If (idMesa = 1) Then
                xTaller = 35
            ElseIf (idMesa = 2) Then
                xTaller = 0
            ElseIf (idMesa = 3) Then
                xTaller = 0
            End If

            ' Dibujar la imagen de fondo cubriendo toda la hoja
            gfx.DrawImage(imagenFondo, 0, 0, page.Width, page.Height)

            Dim fuenteNombre As New XFont("agencyfb", 24, XFontStyle.Bold)
            gfx.DrawString(nombreCliente, fuenteNombre, XBrushes.Black, New XRect(0, 280, page.Width, 30), XStringFormats.TopCenter)

                Dim fuenteTaller As New XFont("Calibri", 16, XFontStyle.Bold)
            gfx.DrawString(result(0), fuenteTaller, XBrushes.Black, New XRect(xTaller, 330, page.Width, 30), XStringFormats.TopCenter)

            Dim fuenteMaestro As New XFont("Calibri", 16, XFontStyle.Regular)
                gfx.DrawString(result(1), fuenteMaestro, XBrushes.Black, New XRect(Convert.ToInt32(result(2)), 402, page.Width, 30), XStringFormats.TopCenter)

                ' Fuente para los campos inferiores
                Dim fuenteInferior As New XFont("Calibri", 8, XFontStyle.Regular)

                ' Coordenadas base
                Dim yRegistroBase As Double = 490
                Dim espacioEntreLineas As Double = 12

                ' Medir ancho del texto "Libro 3"
                Dim anchoLibro As Double = gfx.MeasureString(libro, fuenteInferior).Width
                Dim xCentroLibro As Double = 90 + anchoLibro / 2 ' Asumiendo que el texto "Libro 3" empieza en X = 9=0

                ' Calcular posición centrada para los demás textos
                Dim anchoFoja As Double = gfx.MeasureString(foja, fuenteInferior).Width
                Dim xFoja As Double = xCentroLibro - anchoFoja / 2

                Dim anchoFecha As Double = gfx.MeasureString(fecha, fuenteInferior).Width
                Dim xFecha As Double = xCentroLibro - anchoFecha / 2

                ' Dibujar los textos
                gfx.DrawString(libro, fuenteInferior, XBrushes.Black, New XPoint(90, yRegistroBase))
                gfx.DrawString(foja, fuenteInferior, XBrushes.Black, New XPoint(xFoja, yRegistroBase + espacioEntreLineas))
                gfx.DrawString(fecha, fuenteInferior, XBrushes.Black, New XPoint(xFecha, yRegistroBase + 2 * espacioEntreLineas))

            ' ========================
            ' Insertar el Código QR
            ' ========================
            Dim img As Bitmap = Me.gernerarQrConstancias(Matricula, 2)
            Dim qrImage As XImage
                Using ms As New MemoryStream()
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    qrImage = XImage.FromStream(ms)
                End Using
            gfx.DrawImage(qrImage, 705, 165, 100, 100)
        End If

    End Sub


    Function getDatosMesa(idMesa As Integer) As String()
        Dim result As String()
        Select Case idMesa
            Case 1
                result = {"""Evaluación y Modificación de la Conducta: el Análisis Funcional como Herramienta Clínica"", en el", "María Xesús Froxán Parga", "135"}
            Case 2
                result = {"""Activación Conductual Adaptada para el Trastorno por Estrés Postraumático"", en el", "Michel André Reyes Ortega", "140"}
            Case 3
                result = {"""Habilidades Clínicas en la Terapia Integral de Pareja"", en el", "Diego Alejandro Garcés Rojas", "145"}
            Case 4
                result = {"""Estrategias de Cambio y Aceptación Basadas en la Terapia Dialéctico Conductual"", en el", "Juan Pablo Boggiano", "117"}
        End Select

        Return result
    End Function

    Function gernerarQrConstancias(Matricula As String, tipoAsistencia As Integer) As Bitmap
        Dim uuid As String = db.exectSQLQueryScalar($"SELECT CAST(ASIST.uuid AS VARCHAR(MAX))FROM portal_asistencias AS ASIST
                                                       INNER JOIN portal_registroCongreso AS RC ON RC.id_registro = ASIST.id_registro
                                                       WHERE RC.clave_cliente = '{Matricula}' AND ASIST.id_tipo_asistencia = {tipoAsistencia}")
        Try
            Dim img As New Bitmap(QR_Generator.Encode($"https://jaguar3.ux.edu.mx/EducacionContinua/validar/{uuid}"), New Size(220, 220))
            Return img
        Catch ex As Exception
            Dim img As New Bitmap(QR_Generator.Encode($"www.ux.edu.mx"), New Size(220, 220))
            Return Nothing
        End Try

    End Function
End Class
