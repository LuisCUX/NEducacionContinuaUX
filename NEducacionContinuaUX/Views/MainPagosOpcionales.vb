Public Class MainPagosOpcionales
    Dim db As DataBaseService = New DataBaseService()
    Private Sub MainPagosOpcionales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tablePagos As DataTable = db.getDataTableFromSQL("SELECT P.claveProductoServicio, P.Nombre, ('$' + CAST(R.valorUnitario AS varchar(MAX))) As valorUnitario, R.Para FROM ing_PagosOpcionales AS P
                                                              INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID_PagoOpcional = P.ID")
        GridPagosOpcionales.DataSource = Nothing
        GridPagosOpcionales.DataSource = tablePagos
    End Sub

    Private Sub btnNuevoPago_Click(sender As Object, e As EventArgs) Handles btnNuevoPago.Click
        RegistroPagosOpcionales.MdiParent = PrincipalView
        RegistroPagosOpcionales.Show()
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        MainPagosOpcionales_Load(Me, Nothing)
    End Sub
End Class