Imports System.IO
Imports System.Text

Public Class PruebaEnvioCorreosEDC
    Dim mailStructure As New NEmailStructureModel
    Dim es As UXServiceEmail = New UXServiceEmail()
    Dim pdf As PDFService = New PDFService()
    Dim attatchment1 As Byte()
    Dim attatchment2 As Byte()
    Private Sub PruebaEnvioCorreos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mailStructure.to = txtDestino.Text
        mailStructure.subject = txtTitulo.Text
        mailStructure.message = txtContenido.Text
        mailStructure.attatchmentImg = txtembebido.Text
        Try
            attatchment1 = File.ReadAllBytes(txtatt1.Text)
        Catch ex As Exception

        End Try

        Try
            attatchment2 = File.ReadAllBytes(txtatt2.Text)
        Catch ex As Exception

        End Try


        mailStructure.nameFile = "Prueba"


        es.sendEmailWithFileBytes(mailStructure, attatchment1, attatchment2)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "Image Files(*.PNG;*.BMP;*.JPG;*.JPEG;*.GIF)|*.PNG;*.BMP;*.JPG;*.JPEG;*.GIF|Text files (*.txt)|*.txt|All files (*.*)|*.*"
        Me.OpenFileDialog1.ShowDialog()
        Dim extension As String = Path.GetExtension(OpenFileDialog1.FileName)
        If (OpenFileDialog1.FileName = "OpenFileDialog1") Then
            txtembebido.Text = ""
        ElseIf (extension <> ".png" And extension <> ".bmp" And extension <> ".jpg" And extension <> ".jpeg" And extension <> ".gif") Then
            MessageBox.Show("Favor de seleccionar una imagen con los formatos .PNG, .BMP, .JPG, .JPEG o .GIF")
            txtembebido.Text = ""
            Exit Sub
        Else
            txtembebido.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.Filter = "Image Files(*.PNG;*.BMP;*.JPG;*.JPEG;*.GIF)|*.PNG;*.BMP;*.JPG;*.JPEG;*.GIF|Text files (*.txt)|*.txt|All files (*.*)|*.*"
        Me.OpenFileDialog1.ShowDialog()
        Dim extension As String = Path.GetExtension(OpenFileDialog1.FileName)
        If (OpenFileDialog1.FileName = "OpenFileDialog1") Then
            txtatt1.Text = ""
        Else
            txtatt1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFileDialog1.Filter = "Image Files(*.PNG;*.BMP;*.JPG;*.JPEG;*.GIF)|*.PNG;*.BMP;*.JPG;*.JPEG;*.GIF|Text files (*.txt)|*.txt|All files (*.*)|*.*"
        Me.OpenFileDialog1.ShowDialog()
        Dim extension As String = Path.GetExtension(OpenFileDialog1.FileName)
        If (OpenFileDialog1.FileName = "OpenFileDialog1") Then
            txtatt2.Text = ""
        Else
            txtatt2.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ''pdf.getPDFQRCongresos()
    End Sub
End Class