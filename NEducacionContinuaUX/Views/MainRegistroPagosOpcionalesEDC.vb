Public Class MainRegistroPagosOpcionalesEDC
    Dim db As DataBaseService = New DataBaseService()
    Private Sub MainPagosOpcionales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tablePagos As DataTable = db.getDataTableFromSQL("SELECT P.ID, P.claveProductoServicio, P.Nombre, ('$' + CAST(R.valorUnitario AS varchar(MAX))) As valorUnitario, R.Para FROM ing_PagosOpcionales AS P
                                                              INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID_PagoOpcional = P.ID")
        GridPagosOpcionales.DataSource = Nothing
        GridPagosOpcionales.DataSource = tablePagos
    End Sub

    Private Sub btnNuevoPago_Click(sender As Object, e As EventArgs) Handles btnNuevoPago.Click
        ObjectBagService.setItem("tipoVentana", "Nuevo")
        ModalRegistroPagosOpcionalesEDC.MdiParent = PrincipalView
        ModalRegistroPagosOpcionalesEDC.Show()
    End Sub

    Sub reloadGrid()
        Dim tablePagos As DataTable = db.getDataTableFromSQL("SELECT P.ID, P.claveProductoServicio, P.Nombre, ('$' + CAST(R.valorUnitario AS varchar(MAX))) As valorUnitario, R.Para FROM ing_PagosOpcionales AS P
                                                              INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID_PagoOpcional = P.ID")
        GridPagosOpcionales.DataSource = Nothing
        GridPagosOpcionales.DataSource = tablePagos
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        MainPagosOpcionales_Load(Me, Nothing)
    End Sub

    Private Sub GridPagosOpcionales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridPagosOpcionales.CellClick
        Dim ID As Integer = Convert.ToInt32(GridPagosOpcionales.Rows(e.RowIndex).Cells(0).Value)
        ObjectBagService.setItem("tipoVentana", "Edicion")
        ObjectBagService.setItem("IDPago", ID)
        ModalRegistroPagosOpcionalesEDC.MdiParent = PrincipalView
        ModalRegistroPagosOpcionalesEDC.Show()
    End Sub
End Class