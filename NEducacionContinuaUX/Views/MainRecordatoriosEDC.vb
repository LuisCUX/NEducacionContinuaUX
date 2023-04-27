Public Class MainRecordatoriosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Private Sub MainRecordatoriosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Matricula = ObjectBagService.getItem("Matricula")
        ObjectBagService.clearBag()
        Me.recargarGrid()
    End Sub

    Private Sub GridRecordatorios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridRecordatorios.CellClick
        Dim ID As Integer = Convert.ToInt32(GridRecordatorios.Rows(e.RowIndex).Cells(0).Value)
        ObjectBagService.setItem("Tipo", "Edicion")
        ObjectBagService.setItem("IDRecordatorio", ID)
        ObjectBagService.setItem("Matricula", Matricula)
        ModalRecordatoriosEDC.MdiParent = PrincipalView
        ModalRecordatoriosEDC.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ObjectBagService.setItem("Tipo", "Nuevo")
        ObjectBagService.setItem("Matricula", Matricula)
        ModalRecordatoriosEDC.ShowDialog()
    End Sub

    Sub recargarGrid()
        GridRecordatorios.Rows.Clear()
        Dim tableRecordatorios As DataTable = db.getDataTableFromSQL($"SELECT ID, Recordatorio, Fecha, Usuario FROM ing_CatRecordatorios WHERE Matricula = '{Matricula}' AND Activo = 1")
        For Each row As DataRow In tableRecordatorios.Rows
            GridRecordatorios.Rows.Add(row("ID"), row("Recordatorio"), row("Fecha"), row("Usuario"))
        Next
    End Sub
End Class