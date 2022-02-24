Public Class BancosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim edit As Boolean
    Dim editB As Boolean
    Private Sub BancosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.refreshGridTarjetas()
        Me.refreshGridBancos()
        TreeTarjetas.Nodes(0).Expand()
        edit = False
        editB = False
    End Sub
    ''--------------------------------------------------------------------------------------------------------------------------------------''
    ''--------------------------------------------------------TARJETAS----------------------------------------------------------------------''
    ''--------------------------------------------------------------------------------------------------------------------------------------''
    Private Sub btnGuardarT_Click(sender As Object, e As EventArgs) Handles btnGuardarT.Click
        If (edit = False) Then
            Dim exists As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatTipoTarjeta WHERE Nombre = '{txtNombreTarjeta.Text}'")
            If (exists > 0) Then
                MessageBox.Show("El tipo de tarjeta ya esta registrado, intente con uno diferente")
                txtNombreTarjeta.Clear()
                Exit Sub
            End If
            Dim chb As Integer
            If (chbActivoTarjeta.Checked = True) Then
                chb = 1
            Else
                chb = 0
            End If
            db.execSQLQueryWithoutParams($"INSERT INTO ing_CatTipoTarjeta (Nombre, Activo) VALUES ('{txtNombreTarjeta.Text}', {chb})")
        Else
            Dim chb As Integer
            If (chbActivoTarjeta.Checked = True) Then
                chb = 1
            Else
                chb = 0
            End If
            db.execSQLQueryWithoutParams($"UPDATE ing_CatTipoTarjeta SET Nombre = '{txtNombreTarjeta.Text}', Activo = {chb} WHERE ID = {ObjectBagService.getItem("IDTarjeta")}")
            ObjectBagService.clearBag()
            edit = False
        End If
        txtNombreTarjeta.Clear()
        chbActivoTarjeta.Checked = False
        Me.refreshGridBancos()
        Me.refreshGridTarjetas()
    End Sub

    Private Sub GridTarjetas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridTarjetas.CellContentClick
        If (e.ColumnIndex = 3) Then
            GridTarjetas.EndEdit()
            If (GridTarjetas.Rows(e.RowIndex).Cells(3).Value = True) Then
                Dim IDTarjeta As Integer = GridTarjetas.Rows(e.RowIndex).Cells(0).Value
                ObjectBagService.setItem("IDTarjeta", IDTarjeta)
                txtNombreTarjeta.Text = GridTarjetas.Rows(e.RowIndex).Cells(1).Value
                If (GridTarjetas.Rows(e.RowIndex).Cells(2).Value = True) Then
                    chbActivoTarjeta.Checked = True
                Else
                    chbActivoTarjeta.Checked = False
                End If
                edit = True
            Else
                txtNombreTarjeta.Clear()
                chbActivoTarjeta.Checked = False
                edit = False
            End If
        End If
    End Sub

    Private Sub btnSalirT_Click(sender As Object, e As EventArgs) Handles btnSalirT.Click
        Me.Close()
    End Sub

    ''--------------------------------------------------------------------------------------------------------------------------------------''
    ''-----------------------------------------------------------BANCOS---------------------------------------------------------------------''
    ''--------------------------------------------------------------------------------------------------------------------------------------''
    Private Sub Tree_DoubleClick(sender As Object, e As EventArgs) Handles TreeTarjetas.DoubleClick
        Dim index As Integer = TreeTarjetas.SelectedNode.Index
        If (TreeTarjetas.SelectedNode.Checked = False) Then
            TreeTarjetas.SelectedNode.Checked = True
            TreeTarjetas.Nodes(0).Nodes(index).SelectedImageIndex = 1
        Else
            TreeTarjetas.SelectedNode.Checked = False
            TreeTarjetas.Nodes(0).Nodes(index).SelectedImageIndex = 0
        End If
    End Sub

    Private Sub btnGuardarB_Click(sender As Object, e As EventArgs) Handles btnGuardarB.Click
        Try
            db.startTransaction()
            If (editB = False) Then
                Dim exists As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_Cat_Bancos WHERE Nombre_Banco = '{txtNombreBanco.Text}'")
                If (exists > 0) Then
                    MessageBox.Show("El banco ya esta registrado, intente con uno diferente")
                    txtNombreBanco.Clear()
                    Exit Sub
                End If
                Dim chb As Integer
                If (chbActivoBanco.Checked = True) Then
                    chb = 1
                Else
                    chb = 0
                End If
                Dim IDBanco As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_Cat_Bancos (Nombre_Banco, Activo) VALUES ('{txtNombreBanco.Text}', {chb})")
                Dim IDTarjeta As Integer
                For x = 0 To TreeTarjetas.Nodes(0).Nodes.Count - 1
                    If (TreeTarjetas.Nodes(0).Nodes(x).Checked = True) Then
                        IDTarjeta = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatTipoTarjeta WHERE Nombre = '{TreeTarjetas.Nodes(0).Nodes(x).Text}'")
                        db.execSQLQueryWithoutParams($"INSERT INTO ing_res_BancoTarjeta (ID_Banco, ID_TipoTarjeta, Activo) VALUES ({IDBanco}, {IDTarjeta}, 1)")
                    End If
                Next
            Else
                Dim chb As Integer
                If (chbActivoBanco.Checked = True) Then
                    chb = 1
                Else
                    chb = 0
                End If
                Dim IDBanco As Integer = ObjectBagService.getItem("IDBanco")
                db.execSQLQueryWithoutParams($"UPDATE ing_Cat_Bancos SET Nombre_Banco = '{txtNombreBanco.Text}', Activo = {chb} WHERE ID = {IDBanco}")
                For Each node As TreeNode In TreeTarjetas.Nodes(0).Nodes
                    Dim IDRes As Integer
                    Dim checked As Integer

                    If (node.Checked = True) Then
                        checked = 1
                    Else
                        checked = 0
                    End If

                    Dim nombreNode As String = node.Text
                    Dim IDNode As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatTipoTarjeta WHERE Nombre = '{nombreNode}'")
                    IDRes = db.exectSQLQueryScalar($"SELECT ID FROM ing_res_BancoTarjeta WHERE ID_Banco = {IDBanco} AND ID_TipoTarjeta = {IDNode}")
                    If (IDRes < 1) Then
                        IDRes = db.insertAndGetIDInserted($"INSERT INTO ing_res_BancoTarjeta (ID_Banco, ID_TipoTarjeta, Activo) VALUES ({IDBanco}, {IDNode}, NULL)")
                    End If

                    db.execSQLQueryWithoutParams($"UPDATE ing_res_BancoTarjeta SET Activo = {checked} WHERE ID = {IDRes}")

                Next
            End If
            db.commitTransaction()
            txtNombreBanco.Clear()
            chbActivoBanco.Checked = False
            Me.refreshGridBancos()
            Me.refreshGridTarjetas()
        Catch ex As Exception
            db.rollBackTransaction()
        End Try
    End Sub

    Private Sub GridBancos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridBancos.CellContentClick
        If (e.ColumnIndex = 3) Then
            GridBancos.EndEdit()
            If (GridBancos.Rows(e.RowIndex).Cells(3).Value = True) Then
                Dim IDBanco As Integer = GridBancos.Rows(e.RowIndex).Cells(0).Value
                ObjectBagService.setItem("IDBanco", IDBanco)
                txtNombreBanco.Text = GridBancos.Rows(e.RowIndex).Cells(1).Value
                If (GridBancos.Rows(e.RowIndex).Cells(2).Value = True) Then
                    chbActivoBanco.Checked = True
                Else
                    chbActivoBanco.Checked = False
                End If

                Dim tableTarjetas As DataTable = db.getDataTableFromSQL($"SELECT t.Nombre FROM ing_res_BancoTarjeta AS BT
                                                                          INNER JOIN ing_CatTipoTarjeta AS T ON T.ID = BT.ID_TipoTarjeta
                                                                          WHERE BT.ID_Banco = {IDBanco} AND BT.Activo = 1")

                For Each row As DataRow In tableTarjetas.Rows
                    For x = 0 To TreeTarjetas.Nodes(0).Nodes.Count - 1
                        If (row("Nombre") = TreeTarjetas.Nodes(0).Nodes(x).Text) Then
                            TreeTarjetas.Nodes(0).Nodes(x).Checked = True
                        End If
                    Next
                Next
                editB = True
            Else
                For x = 0 To TreeTarjetas.Nodes(0).Nodes.Count - 1
                    TreeTarjetas.Nodes(0).Nodes(x).Checked = False
                Next
            End If
        End If
    End Sub

    Private Sub btnSalirB_Click_1(sender As Object, e As EventArgs) Handles btnSalirB.Click
        Me.Close()
    End Sub

    Sub refreshGridTarjetas()
        GridTarjetas.Rows.Clear()
        Dim tableTarjetas As DataTable = db.getDataTableFromSQL($"SELECT ID, Nombre, Activo FROM ing_CatTipoTarjeta WHERE Activo = 1")
        For Each item As DataRow In tableTarjetas.Rows
            GridTarjetas.Rows.Add(item("ID"), item("Nombre"), item("Activo"))
        Next
    End Sub

    Sub refreshGridBancos()
        GridBancos.Rows.Clear()
        TreeTarjetas.Nodes(0).Nodes.Clear()
        Dim tableTarjetas As DataTable = db.getDataTableFromSQL($"SELECT ID, Nombre, Activo FROM ing_CatTipoTarjeta WHERE Activo = 1")
        Dim tableBancos As DataTable = db.getDataTableFromSQL($"SELECT ID, Nombre_Banco, Activo FROM ing_Cat_Bancos")
        For Each item As DataRow In tableBancos.Rows
            GridBancos.Rows.Add(item("ID"), item("Nombre_Banco"), item("Activo"))
        Next

        For Each item As DataRow In tableTarjetas.Rows
            TreeTarjetas.Nodes(0).Nodes.Add(item("Nombre")).StateImageIndex = 0
        Next
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreBanco.KeyPress, txtNombreTarjeta.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub
End Class