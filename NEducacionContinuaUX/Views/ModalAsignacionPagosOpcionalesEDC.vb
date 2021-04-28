Public Class ModalAsignacionPagosOpcionalesEDC
    Dim NT As String()
    Dim Matricula As String
    Dim MatriculaUX As String
    Dim tipoMatricula As String
    Dim tipoVentana As String
    Dim IDAsignacion As Integer
    Dim ap As AsignacionPagosOpcionalesController = New AsignacionPagosOpcionalesController()
    Dim db As DataBaseService = New DataBaseService()
    Private Sub ModalAsignacionPagosOpcionalesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tipoMatricula = ObjectBagService.getItem("tipoMatricula")
        Matricula = ObjectBagService.getItem("Matricula")
        MatriculaUX = ObjectBagService.getItem("MatriculaUX")
        tipoVentana = ObjectBagService.getItem("tipoVentana")
        IDAsignacion = ObjectBagService.getItem("IDPago")
        ap.loadAsignacionPagosOpcionalesModal(tipoMatricula, MatriculaUX, cbTipoPago, cbPagosOpcionales)

        If (tipoVentana = "Edicion") Then
            Dim IDPago As String = ObjectBagService.getItem("IDPago")
            ap.llenarVentanaEdicion(tipoMatricula, IDPago, cbTipoPago, cbPagosOpcionales, txtValorUnitario, chbActivo, NUCantidad)
            lblActivo.Visible = True
            chbActivo.Visible = True
        End If
        ObjectBagService.clearBag()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtValorUnitario.Text = "") Then
            MessageBox.Show("Ingrese el valor unitario del pago a asignar")
            Return
        End If
        If (cbPagosOpcionales.Text = "") Then
            MessageBox.Show("Seleccione un pago opcional a asignar")
            Return
        End If
        If (tipoVentana = "Edicion") Then
            ap.editarPagoOpcional(Matricula, tipoMatricula, IDAsignacion, NUCantidad.Value, CDec(txtValorUnitario.Text), chbActivo.Checked)
        Else
            ap.guardarPagoOpcional(Matricula, tipoMatricula, cbPagosOpcionales.SelectedValue, NUCantidad.Value, CDec(txtValorUnitario.Text))
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cbPagosOpcionales_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbPagosOpcionales.SelectionChangeCommitted
        Try
            chbExentaIVA.Checked = False
            chbConsideraIVA.Checked = False
            chbIncluyeIVA.Checked = False
            Dim precio As Decimal = db.exectSQLQueryScalar($"SELECT valorUnitario FROM ing_resPagoOpcionalAsignacion WHERE ID = {cbPagosOpcionales.SelectedValue}")
            txtValorUnitario.Text = Format(CDec(precio), "#####0.00")
            Dim agregaIVA As Boolean
            Dim exentaIVA As Boolean
            Dim consideraIVA As Boolean
            Dim tableIVA As DataTable = db.getDataTableFromSQL($"SELECT P.considerarIVA, P.AgregaIVA, P.ExentaIVA FROM ing_resPagoOpcionalAsignacion AS R 
                                                           INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                           WHERE R.ID ={cbPagosOpcionales.SelectedValue}")
            For Each item As DataRow In tableIVA.Rows
                agregaIVA = item("AgregaIVA")
                exentaIVA = item("ExentaIVA")
                consideraIVA = item("considerarIVA")
            Next

            If (agregaIVA = True) Then
                chbIncluyeIVA.Checked = True
            ElseIf (consideraIVA = True) Then
                chbConsideraIVA.Checked = True
            ElseIf (exentaIVA = True) Then
                chbExentaIVA.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub commitChangecbPagosOpcionales()
        cbPagosOpcionales_SelectionChangeCommitted(Nothing, Nothing)
    End Sub

    Private Sub txtValorUnitario_TextChanged(sender As Object, e As EventArgs) Handles txtValorUnitario.TextChanged
        Dim tipo As Integer
        If (chbExentaIVA.Checked = True) Then
            tipo = 3
        ElseIf (chbIncluyeIVA.Checked = True) Then
            tipo = 2
        ElseIf (chbConsideraIVA.Checked = True) Then
            tipo = 1
        End If
        Me.valorUnitario(tipo)
    End Sub

    Private Sub NUCantidad_ValueChanged(sender As Object, e As EventArgs) Handles NUCantidad.ValueChanged
        Dim tipo As Integer
        If (chbExentaIVA.Checked = True) Then
            tipo = 3
        ElseIf (chbIncluyeIVA.Checked = True) Then
            tipo = 2
        ElseIf (chbConsideraIVA.Checked = True) Then
            tipo = 1
        End If
        Me.valorUnitario(tipo)
    End Sub

    Private Sub txtValorUnitario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorUnitario.KeyPress
        Dim num_cantidad As Decimal = 0
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("0123456789.", Chr(KeyAscii)) = 0 Then
            If KeyAscii <> 8 Then
                KeyAscii = 0
            End If
            e.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        ElseIf InStr(txtValorUnitario.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub NUCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NUCantidad.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub valorUnitario(Tipo As Integer)
        If (txtValorUnitario.Text <> "") Then
            If (Tipo = 1) Then
                Dim valorunitarioiva As Decimal = (CDec(txtValorUnitario.Text) / 1.16) * NUCantidad.Value
                txtTotal.Text = Format(CDec(valorunitarioiva), "#####0.00")
            ElseIf (Tipo = 2) Then
                Dim IVA As Decimal = (CDec(txtValorUnitario.Text) * 0.16) * NUCantidad.Value
                IVA = CDec(txtValorUnitario.Text) + IVA
                txtTotal.Text = Format(CDec(IVA), "#####0.00")
            ElseIf (Tipo = 3) Then
                txtTotal.Text = Format((CDec(txtValorUnitario.Text) * NUCantidad.Value), "#####0.00")
            ElseIf (Tipo = 0) Then
                txtTotal.Text = txtValorUnitario.Text
            End If
        Else
            txtTotal.Text = "0.00"
        End If

    End Sub


End Class