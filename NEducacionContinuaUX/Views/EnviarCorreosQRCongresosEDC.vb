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
                                                                            INNER JOIN ing_xmlTimbrados AS X ON X.Matricula_Clave = RC.clave_cliente
                                                                            WHERE CON.id_congreso = {cbCongreso.SelectedValue} AND RC.activo = 1 AND X.CanceladaHoy = 0 AND X.CanceladaOtroDia = 0
                                                                            ORDER BY RC.clave_cliente")
        GridAlumnos.DataSource = tableAsistentesPagados
    End Sub

    Private Sub btnEnviarCorreos_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreos.Click
        Dim nombreCongreso As String = cbCongreso.Text
        Dim mailStructure As New NEmailStructureModel
        Dim destino As String = "estebanh@ux.edu.mx"
        ''Dim destino As String = "luis.c@ux.edu.mx"
        Dim archivo_pdf As Byte() = Nothing
        Dim attatchment1 As Byte()
        Dim subject As String = $"Pase de acceso – {nombreCongreso}"
        Dim Message As String = $"Te compartimos tu pase de acceso para: {nombreCongreso}. <br>
                                 Por favor, guarda este código QR y tenlo listo (en tu celular o impreso) el día del evento. El personal del congreso lo escaneará para registrar tu asistencia. <br>
                                 Este código QR es personal e intransferible. <br>
                                 ¡Gracias por tu participación!"
        Dim Matricula As String = "EC25PS005"

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
        mailStructure.nameFile = $"QR"

        es.sendEmailWithFile(mailStructure, attatchment1)
    End Sub
End Class