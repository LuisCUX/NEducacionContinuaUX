Public Class RegistroTipoPagosOpcionales
    Dim db As DataBaseService = New DataBaseService()
    Dim edit As Boolean = False
    Private Sub RegistroTipoPagosOpcionales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tablePagosOpcionales As DataTable = db.getDataTableFromSQL($"SELECT P.ID, P.Clave, P.Nombre, P.Descripcion, A.Nombre As NombreArea, P.Activo FROM ing_CatTipoPagoOpcional AS P
                                                                         INNER JOIN ing_catAreas AS A ON A.ID = P.ID_AreaAsignada")
        Dim Activotxt As String
        edit = False
        For Each pago As DataRow In tablePagosOpcionales.Rows
            If (pago("Activo") = True) Then
                Activotxt = "Si"
            Else
                Activotxt = "No"
            End If
            GridTipoPago.Rows.Add(pago("ID"), pago("Clave"), pago("Descripcion"), pago("Nombre"), pago("NombreArea"), Activotxt)
        Next

        Dim tableAreas As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre FROM ing_catAreas WHERE Activo = 1 ORDER BY Nombre")
        ComboboxService.llenarCombobox(cbAreas, tableAreas, "ID", "Nombre")
        cbAreas.SelectedIndex = -1
    End Sub

    Private Sub btnGuardarB_Click(sender As Object, e As EventArgs) Handles btnGuardarB.Click
        Dim activo As Integer
        If (txtClave.Text = "") Then
            MessageBox.Show("Ingrese la clave del pago opcional")
            Me.Reiniciar()
            Exit Sub
        End If
        If (txtNombre.Text = "") Then
            MessageBox.Show("Ingrese el nombre del pago opcional")
            Me.Reiniciar()
            Exit Sub
        End If
        If (txtDescripcion.Text = "") Then
            MessageBox.Show("Ingrese la descripción del pago opcional")
            Me.Reiniciar()
            Exit Sub
        End If
        If (chbActivo.Checked = True) Then
            activo = 1
        Else
            activo = 0
        End If
        If (edit = False) Then
            Dim existsID As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatTipoPagoOpcional WHERE Clave = '{txtClave.Text}' AND Nombre = '{txtNombre.Text}' AND Descripcion = '{txtDescripcion.Text}'")
            If (existsID > 0) Then
                MessageBox.Show("El tipo de pago opcional ya esta registrado, intente con uno diferente")
                Me.Reiniciar()
                Exit Sub
            End If
            db.execSQLQueryWithoutParams($"INSERT INTO ing_CatTipoPagoOpcional(Clave, Nombre, Descripcion, ID_AreaAsignada, Activo) VALUES ('{txtClave.Text}', '{txtNombre.Text}', '{txtDescripcion.Text}', {cbAreas.SelectedValue}, {activo})")
            MessageBox.Show("Tipo de pago registrado correctamente")
            Me.Reiniciar()
            Exit Sub
        Else
            Dim IDTipoPago As Integer = ObjectBagService.getItem("IDTipoPago")
            Dim existsID As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatTipoPagoOpcional WHERE Clave = '{txtClave.Text}' AND Nombre = '{txtNombre.Text}' AND Descripcion = '{txtDescripcion.Text}' AND ID != {IDTipoPago}")
            If (existsID > 0) Then
                MessageBox.Show("El tipo de pago opcional ya esta registrado, intente con uno diferente")
                Me.Reiniciar()
                Exit Sub
            End If
            db.execSQLQueryWithoutParams($"UPDATE ing_CatTipoPagoOpcional SET Clave = '{txtClave.Text}', Nombre = '{txtNombre.Text}', Descripcion = '{txtDescripcion.Text}', ID_AreaAsignada = {cbAreas.SelectedValue}, Activo = '{activo}' WHERE ID = {IDTipoPago}")
            MessageBox.Show("Tipo de pago modificado correctamente")
            Me.Reiniciar()
            Exit Sub
        End If
    End Sub

    Private Sub GridTipoPago_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridTipoPago.CellContentClick
        If (e.ColumnIndex = 6) Then
            GridTipoPago.EndEdit()
            If (GridTipoPago.Rows(e.RowIndex).Cells(6).Value = True) Then
                Dim IDTipoPago As Integer = GridTipoPago.Rows(e.RowIndex).Cells(0).Value
                ObjectBagService.setItem("IDTipoPago", IDTipoPago)
                txtClave.Text = GridTipoPago.Rows(e.RowIndex).Cells(1).Value
                txtNombre.Text = GridTipoPago.Rows(e.RowIndex).Cells(3).Value
                cbAreas.Text = GridTipoPago.Rows(e.RowIndex).Cells(4).Value
                txtDescripcion.Text = GridTipoPago.Rows(e.RowIndex).Cells(2).Value
                If (GridTipoPago.Rows(e.RowIndex).Cells(5).Value = "Si") Then
                    chbActivo.Checked = True
                Else
                    chbActivo.Checked = False
                End If
                edit = True
            Else
                txtClave.Clear()
                txtNombre.Clear()
                txtDescripcion.Clear()
                chbActivo.Checked = False
                edit = False
                cbAreas.SelectedIndex = -1
            End If
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        RegistroTipoPagosOpcionales_Load(Me, Nothing)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress, txtNombre.KeyPress, txtDescripcion.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub
End Class