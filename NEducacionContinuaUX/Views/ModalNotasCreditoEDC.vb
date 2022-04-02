Public Class ModalNotasCreditoEDC
    Dim db As DataBaseService = New DataBaseService
    Private Sub ModalNotasCreditoEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Matricula As String = ObjectBagService.getItem("Matricula")
        ObjectBagService.clearBag()
        Dim tableNotasCredito As DataTable = db.getDataTableFromSQL($"SELECT DISTINCT N.FolioNota FROM ing_NotasCredito AS N
                                                                      INNER JOIN ing_CatTipoNotaCredito AS TN ON TN.ID = N.IDTipoNota AND TN.Activo = 1 AND TN.Bonifica = 1
                                                                      WHERE N.Activo = 1 AND N.Aplicada = 0 AND N.Matricula = '{Matricula}'")
        ComboboxService.llenarCombobox(cbNotasCredito, tableNotasCredito, "FolioNota", "FolioNota")
    End Sub

    Private Sub cbNotasCredito_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNotasCredito.SelectionChangeCommitted
        Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT Descripcion, Importe FROM ing_NotasCredito WHERE FolioNota = '{cbNotasCredito.SelectedValue}'")
        GridConceptos.DataSource = tableConceptos
        Me.CalcularTotal(GridConceptos)
    End Sub

    Sub CalcularTotal(GridConceptos As DataGridView)
        Dim total As Decimal
        For x = 0 To GridConceptos.Rows.Count - 1
            total = total + GridConceptos.Rows(x).Cells(1).Value
        Next
        lblCantidad.Text = Format(CDec(total), "##0.00")
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If (GridConceptos.Rows.Count = 0) Then
            MessageBox.Show("Seleccione una nota de credito")
            Exit Sub
        End If
        CobrosEDC.Enabled = True
        CobrosEDC.txtNotaAplicada.Text = cbNotasCredito.SelectedValue
        CobrosEDC.cbFormaPago.SelectedIndex = 8
        CobrosEDC.cbFormaPago.Enabled = False
        CobrosEDC.lblNotaAplicada.Visible = True
        CobrosEDC.txtNotaAplicada.Visible = True
        CobrosEDC.btnBuscarNota.Visible = True
        CobrosEDC.txtMonto.Text = lblCantidad.Text
        CobrosEDC.txtMonto.Enabled = False
        ObjectBagService.setItem("NotaAgregada", True)
        Me.Close()
    End Sub
End Class