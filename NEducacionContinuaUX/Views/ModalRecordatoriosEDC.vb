Public Class ModalRecordatoriosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim Estado As String
    Dim IDRecordatorioEdit As Integer
    Dim RecordatoriotxtEdit As String
    Dim textoLabelEdit As String
    Dim estadoCheck As Boolean
    Private Sub ModalRecordatoriosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Estado = ObjectBagService.getItem("Tipo")
        Matricula = ObjectBagService.getItem("Matricula")
        If (Estado = "Edicion") Then
            IDRecordatorioEdit = ObjectBagService.getItem("IDRecordatorio")
            Dim tableRecordatorio As DataTable = db.getDataTableFromSQL($"SELECT Recordatorio, Activo, (Usuario + ' - ' + cast(Fecha as varchar(max))) As Info FROM ing_CatRecordatorios WHERE ID = {IDRecordatorioEdit}")
            For Each row As DataRow In tableRecordatorio.Rows
                txtRecordatorio.Text = row("Recordatorio")
                chbActivo.Checked = row("Activo")
                lblInfo.Text = row("Info")
            Next
            ObjectBagService.clearBag()
            lblInfo.Visible = True
            RecordatoriotxtEdit = txtRecordatorio.Text
            textoLabelEdit = lblInfo.Text
            estadoCheck = chbActivo.Checked
        Else
            ObjectBagService.clearBag()
            chbNuevo.Checked = True
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtRecordatorio.Text.Length = 0) Then
            MessageBox.Show("Ingrese un texto")
            Exit Sub
        End If
        Dim bit As Integer
        If (chbActivo.Checked = True) Then
            bit = 1
        Else
            bit = 0
        End If
        If (Estado = "Edicion") Then
            db.execSQLQueryWithoutParams($"UPDATE ing_CatRecordatorios SET Recordatorio = '{txtRecordatorio.Text}', Fecha = GETDATE(), Usuario = '{User.getUsername}', Activo = {bit} WHERE ID = {IDRecordatorioEdit}")
            MessageBox.Show("Cambios guardados correctamente")
        Else
            db.execSQLQueryWithoutParams($"INSERT INTO ing_CatRecordatorios(Matricula, Recordatorio, Fecha, Usuario, Activo) VALUES ('{Matricula}', '{txtRecordatorio.Text}', GETDATE(), '{User.getUsername}', {bit})")
            MessageBox.Show("Recordatorio guardado correctamente")
        End If

        MainRecordatoriosEDC.recargarGrid()
        Me.limpiar()
        Me.Close()
    End Sub

    Private Sub txtRecordatorio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecordatorio.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Sub limpiar()
        txtRecordatorio.Clear()
        chbActivo.Checked = True
        lblInfo.Text = ""
        lblInfo.Visible = False
    End Sub

    Private Sub chbNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbNuevo.CheckedChanged
        If (chbNuevo.Checked = True) Then
            txtRecordatorio.Clear()
            lblInfo.Text = ""
            chbActivo.Checked = True
            Estado = "Nuevo"
        Else
            txtRecordatorio.Text = RecordatoriotxtEdit
            lblInfo.Text = textoLabelEdit
            chbActivo.Checked = estadoCheck
            Estado = "Edicion"
        End If
    End Sub
End Class