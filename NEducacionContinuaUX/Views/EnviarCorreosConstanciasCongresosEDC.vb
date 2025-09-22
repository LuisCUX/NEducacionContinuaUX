Imports System.IO
Imports System.Threading
Imports PdfSharp.Pdf
Public Class EnviarCorreosConstanciasCongresosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim es As UXServiceEmail = New UXServiceEmail()
    Dim pdfs As PDFService = New PDFService()
    Private Sub EnviarCorreosConstanciasCongresosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableCongresos As DataTable = db.getDataTableFromSQL($"SELECT id_congreso, nombre FROM portal_congreso")
        ComboboxService.llenarCombobox(cbCongreso, tableCongresos, "id_congreso", "nombre")
        cbCongreso.SelectedIndex = -1
    End Sub

    Private Sub cbCongreso_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbCongreso.SelectionChangeCommitted
        Dim tableAsistentesPagados As DataTable = db.getDataTableFromSQL($"SELECT PIV.clave_cliente, PIV.NombreAsistente,
                                                                           CASE WHEN PIV.General IS NULL THEN 'No'
	                                                                            WHEN PIV.General IS NOT NULL THEN 'Si'
                                                                           END As 'General',
                                                                           CASE WHEN PIV.Taller IS NULL THEN 'No'
	                                                                            WHEN PIV.Taller IS NOT NULL THEN 'Si'
                                                                           END As 'Taller'
                                                                           FROM (SELECT TA.id, RC.clave_cliente, (C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno) AS NombreAsistente, TA.nombre AS TipoAsistencia FROM portal_asistencias AS ASIST
                                                                           INNER JOIN portal_registroCongreso AS RC ON RC.id_registro = ASIST.id_registro
                                                                           INNER JOIN portal_cliente AS C ON C.id_cliente = RC.id_cliente
                                                                           INNER JOIN portal_tipoAsistente AS TP ON TP.id_tipo_asistente = RC.id_tipo_asistente
                                                                           INNER JOIN portal_catTiposAsistencias AS TA ON TA.id = ASIST.id_tipo_asistencia
                                                                           WHERE TP.id_congreso = {cbCongreso.SelectedValue}
                                                                           AND RC.clave_cliente NOT IN (SELECT B.Matricula FROM ing_BitacoraCorreosConstanciasTalleres AS B WHERE B.Activo = 1)) X
                                                                           PIVOT(
	                                                                           SUM(ID)
	                                                                           for TipoAsistencia in ([General], [Taller])
                                                                           ) piv")
        GridAlumnos.DataSource = tableAsistentesPagados
    End Sub

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
            While cont <= 92
                Try
                    ''Dim destino As String = "luis.c@ux.edu.mx"
                    Dim Matricula As String = GridAlumnos.Rows(contGeneral).Cells(0).Value.ToString()
                    Dim destino As String = db.exectSQLQueryScalar($"SELECT C.correo FROM portal_cliente AS C
                                                        INNER JOIN portal_registroCongreso AS RC ON RC.id_cliente = C.id_cliente
                                                        WHERE RC.clave_cliente = '{Matricula}'")
                    Dim archivo_pdfGeneral As Byte() = Nothing
                    Dim archivo_pdfTaller As Byte() = Nothing
                    Dim attatchment1 As Byte()
                    Dim attatchment2 As Byte()
                    Dim pdfGeneral As PdfDocument
                    Dim pdfTaller As PdfDocument
                    Dim subject As String
                    Dim mesaCongreso As String = db.exectSQLQueryScalar($"SELECT ISNULL(M.nombre, '') AS nombreMesa
                                                            FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.clave_cliente = '{Matricula}' AND RC.id_cliente = C.id_cliente
                                                            INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                            INNER JOIN portal_congreso AS CON ON CON.id_congreso = TA.id_congreso
                                                            LEFT JOIN portal_registroMesas AS RM ON RC.id_registro = RM.id_registro
                                                            LEFT JOIN portal_mesa AS M ON RM.id_mesa = M.id_mesa")
                    Dim idMesa As Integer = db.exectSQLQueryScalar($"SELECT ISNULL(M.id_mesa, '') AS nombreMesa
                                                            FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.clave_cliente = '{Matricula}' AND RC.id_cliente = C.id_cliente
                                                            INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                            INNER JOIN portal_congreso AS CON ON CON.id_congreso = TA.id_congreso
                                                            LEFT JOIN portal_registroMesas AS RM ON RC.id_registro = RM.id_registro
                                                            LEFT JOIN portal_mesa AS M ON RM.id_mesa = M.id_mesa")
                    Dim Message As String


                    'If (GridAlumnos.Rows(contGeneral).Cells(2).Value.ToString() = "Si") Then ''ASISTENCIA GENERAL
                    '    pdfGeneral = pdfs.getPDFConstanciaCongreso(Matricula, "General", idMesa)
                    '    Using ms As New MemoryStream()
                    '        pdfGeneral.Save(ms, False) ' Guardar el PDF dentro del MemoryStream
                    '        archivo_pdfGeneral = ms.ToArray() ' Convertir el MemoryStream a un arreglo de bytes
                    '    End Using

                    '    subject = $"Constancia de asistencia – {nombreCongreso} {Matricula}"
                    '    Message = $"Estimado/a Participante <br>
                    '                Le compartimos su constancia de participación en el Primer Congreso Internacional en Terapias Contextuales y Cognitivo-Conductuales. <br>
                    '                Agradecemos profundamente su interés y el valioso aporte que representa su participación en este evento. <br>
                    '                Atentamente: <br>
                    '                Comité Organizador"

                    '    mailStructure.to = destino
                    '    mailStructure.subject = subject
                    '    mailStructure.message = Message

                    '    attatchment1 = archivo_pdfGeneral
                    '    mailStructure.nameFile = $"Constancia de asistencia"

                    '    db.execSQLQueryWithoutParams($"INSERT INTO ing_BitacoraCorreosConstancias(Matricula, FechaEnvio, Activo) VALUES ('{Matricula}', GETDATE(), 1)")

                    '    es.sendEmailWithFile(mailStructure, attatchment1)
                    'End If

                    'If (GridAlumnos.Rows(contGeneral).Cells(3).Value.ToString() = "Si") Then
                    '    pdfTaller = pdfs.getPDFConstanciaCongreso(Matricula, "Taller", idMesa)
                    '    Using ms As New MemoryStream()
                    '        pdfTaller.Save(ms, False) ' Guardar el PDF dentro del MemoryStream
                    '        archivo_pdfTaller = ms.ToArray() ' Convertir el MemoryStream a un arreglo de bytes
                    '    End Using
                    '    subject = $"Constancia de asistencia – {nombreCongreso} {Matricula}"
                    '    Message = $"Estimado/a Participante <br>
                    '                Le compartimos su constancia de participación en el taller titulado: ""{mesaCongreso}"", realizado en el marco del Primer Congreso Internacional en Terapias Contextuales y Cognitivo-Conductuales. <br>
                    '                Agradecemos profundamente su interés y el valioso aporte que representa su participación en este evento. <br>
                    '                Atentamente: <br>
                    '                Comité Organizador"

                    '    mailStructure.to = destino
                    '    mailStructure.subject = subject
                    '    mailStructure.message = Message

                    '    attatchment1 = archivo_pdfTaller
                    '    mailStructure.nameFile = $"Constancia de taller"
                    '    db.execSQLQueryWithoutParams($"INSERT INTO ing_BitacoraCorreosConstanciasTalleres(Matricula, FechaEnvio, Activo) VALUES ('{Matricula}', GETDATE(), 1)")
                    '    es.sendEmailWithFile(mailStructure, attatchment1)
                    'End If



                    '''manda email
                    'email = $"{emails(x)} {cont} {GridAlumnos.Rows(contGeneral).Cells(0).Value}"
                    cont = cont + 1
                    contGeneral = contGeneral + 1
                    Thread.Sleep(2000)
                Catch ex As Exception
                    cont = cont + 1
                    contGeneral = contGeneral + 1
                End Try

            End While
        Next
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pdfTaller As PdfDocument
        'pdfTaller = pdfs.getPDFConstanciaCongreso("EC25PS290", "Taller", 1)
        'pdfTaller = pdfs.getPDFConstanciaCongreso("EC25PS372", "Taller", 2)
        'pdfTaller = pdfs.getPDFConstanciaCongreso("EC25PS132", "Taller", 3)
        pdfTaller = pdfs.getPDFConstanciaCongreso("EC25PS284", "Taller", 2)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pdfGeneral As PdfDocument
        pdfGeneral = pdfs.getPDFConstanciaCongreso("EC25PS284", "General", 1)
    End Sub
End Class