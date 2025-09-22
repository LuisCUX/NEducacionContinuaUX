Imports System.IO
Imports PdfSharp.Pdf

Public Class EnviarCorreosQRCongresosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim es As UXServiceEmail = New UXServiceEmail()
    Dim pdfs As PDFService = New PDFService()
    Private Sub EnviarCorreosQRCongresosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableCongresos As DataTable = db.getDataTableFromSQL($"SELECT id_congreso, nombre FROM portal_congreso WHERE activo = 1")
        ComboboxService.llenarCombobox(cbCongreso, tableCongresos, "id_congreso", "nombre")
        cbCongreso.SelectedIndex = -1
    End Sub

    Private Sub cbCongreso_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbCongreso.SelectionChangeCommitted
        Dim tableAsistentesPagados As DataTable = db.getDataTableFromSQL($"SELECT RC.clave_cliente, (C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno) AS NombreAsistente, X.Folio FROM portal_registroCongreso as RC
                                                                            INNER JOIN portal_cliente AS C ON C.id_cliente = RC.id_cliente
                                                                            INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                                            INNER JOIN portal_congreso AS CON ON CON.id_congreso = TA.id_congreso
                                                                            INNER JOIN ing_PagosCongresos AS X ON X.Matricula = RC.clave_cliente
                                                                            WHERE CON.id_congreso = 1019 AND RC.activo = 1 AND RC.clave_cliente NOT IN (SELECT Matricula_Clave FROM ing_xmlTimbrados WHERE CanceladaHoy = 1 OR CanceladaOtroDia = 1)
																			AND RC.clave_cliente NOT IN (SELECT B.Matricula FROM ing_BitacoraCorreosCongresos AS B WHERE B.Activo = 1)
                                                                            ORDER BY X.Folio")
        GridAlumnos.DataSource = tableAsistentesPagados
    End Sub

    'Private Sub btnEnviarCorreos_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreos.Click
    '    Dim nombreCongreso As String = cbCongreso.Text
    '    Dim mailStructure As New NEmailStructureModel

    '    Dim cont = 0

    '    For x = 0 To GridAlumnos.Rows.Count - 1
    '        If (cont < 50) Then
    '            ''Dim destino As String = "estebanh@ux.edu.mx"
    '            Dim destino As String = emails(x)
    '            Dim archivo_pdf As Byte() = Nothing
    '            Dim attatchment1 As Byte()
    '            Dim subject As String = $"Pase de acceso – {nombreCongreso}"
    '            Dim Message As String = $"¡Tu acceso al Congreso está listo! <br>
    '                               Te compartimos tu pase digital de ingreso para el Primer Congreso Internacional en Terapias Contextuales y Cognitivo-Conductuales. <br>
    '                               Por favor, guarda el código QR adjunto y preséntalo el día del evento, ya sea desde tu celular o en formato impreso. El personal del congreso lo escaneará para registrar tu asistencia. <br>
    '                               🔒 Este código es personal e intransferible. <br>
    '                               ¡Gracias por ser parte de esta experiencia! <br>
    '                               Atentamente: <br>
    '                               Comité Organizador"
    '            Dim Matricula As String = GridAlumnos.Rows(contGeneral).Cells(0).Value.ToString()

    '            Dim pdf As PdfDocument
    '            pdf = pdfs.getPDFQRCongresos(Matricula)

    '            Using ms As New MemoryStream()
    '                pdf.Save(ms, False) ' Guardar el PDF dentro del MemoryStream
    '                archivo_pdf = ms.ToArray() ' Convertir el MemoryStream a un arreglo de bytes
    '            End Using

    '            mailStructure.to = destino
    '            mailStructure.subject = subject
    '            mailStructure.message = Message
    '            attatchment1 = archivo_pdf
    '            mailStructure.nameFile = $"QR"

    '            es.sendEmailWithFile(mailStructure, attatchment1)

    '            ''manda email
    '        End If
    '    Next
    'End Sub


    Private Sub btnEnviarCorreos_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreos.Click
        Dim nombreCongreso As String = cbCongreso.Text
        Dim mailStructure As New NEmailStructureModel
        Dim emails As New List(Of String)
        emails.Add("luis.c@ux.edu.mx")

        Dim cont As Integer = 1
        Dim contGeneral As String = 0
        Dim email As String
        For x = 0 To emails.Count - 1
            cont = 1
            While cont <= 30

                ''Dim destino As String = "estebanh@ux.edu.mx"
                Dim Matricula As String = GridAlumnos.Rows(contGeneral).Cells(0).Value.ToString()
                Dim destino As String = db.exectSQLQueryScalar($"SELECT C.correo FROM portal_cliente AS C
                                                    INNER JOIN portal_registroCongreso AS RC ON RC.id_cliente = C.id_cliente
                                                    WHERE RC.clave_cliente = '{Matricula}'")
                Dim archivo_pdf As Byte() = Nothing
                Dim attatchment1 As Byte()
                Dim subject As String = $"Pase de acceso – {nombreCongreso} {Matricula}"
                Dim Message As String = $"¡Tu acceso al Congreso está listo! <br>
                                   Te compartimos tu pase digital de ingreso para el Primer Congreso Internacional en Terapias Contextuales y Cognitivo-Conductuales. <br>
                                   Por favor, guarda el código QR adjunto y preséntalo el día del evento, ya sea desde tu celular o en formato impreso. El personal del congreso lo escaneará para registrar tu asistencia. <br>
                                   🔒 Este código es personal e intransferible. <br>
                                   ¡Gracias por ser parte de esta experiencia! <br>
                                   Atentamente: <br>
                                   Comité Organizador"

                Dim pdf As PdfDocument
                pdf = pdfs.getPDFQRCongresos(Matricula)

                Using ms As New MemoryStream()
                    pdf.Save(ms, False) ' Guardar el PDF dentro del MemoryStream
                    archivo_pdf = ms.ToArray() ' Convertir el MemoryStream a un arreglo de bytes
                End Using

                mailStructure.to = destino
                mailStructure.subject = subject
                mailStructure.message = Message
                attatchment1 = archivo_pdf
                mailStructure.nameFile = $"Pase de acceso"

                es.sendEmailWithFile(mailStructure, attatchment1)

                db.execSQLQueryWithoutParams($"INSERT INTO ing_BitacoraCorreosCongresos(Matricula, FechaEnvio, Activo) VALUES ('{Matricula}', GETDATE(), 1)")

                ''manda email
                email = $"{emails(x)} {cont} {GridAlumnos.Rows(contGeneral).Cells(0).Value}"
                cont = cont + 1
                contGeneral = contGeneral + 1
            End While
        Next

    End Sub
End Class