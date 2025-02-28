Public Class ModificacionCostosCongresos
    Dim db As DataBaseService = New DataBaseService()
    Dim vc As ValidacionesController = New ValidacionesController()
    Dim mc As ModificacionCostosCongresosController = New ModificacionCostosCongresosController()
    Dim Matricula As String
    Private Sub ModificacionCostosCongresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar3_Click(sender As Object, e As EventArgs) Handles btnBuscar3.Click
        Matricula = txtMatricula3.Text
        txtCostoActual.Clear()
        txtNuevoCosto.Clear()
        mc.buscarMatriculaEC(Matricula, panelInfo3, panelRegistro, txtNombre3, txtEmail3, txtNombreCongreso, txtCostoActual)

    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula3.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub controlCantidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNuevoCosto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("0123456789.", Chr(KeyAscii)) = 0 Then
            If KeyAscii <> 8 Then
                KeyAscii = 0
            End If
            e.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        ElseIf InStr(txtNuevoCosto.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
        Dim value As String = e.KeyChar
        Try
            If (CDec($"{txtNuevoCosto.Text}{value}") > CDec(txtCostoActual.Text)) Then
                txtNuevoCosto.Clear()
                MessageBox.Show("Ingrese un valor menor al actual")
                e.Handled = True
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub


    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        ModificacionCostosCongresos_Load(Me, Nothing)
        txtMatricula3.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnModificacionDesc_Click(sender As Object, e As EventArgs) Handles btnModificacionDesc.Click
        mc.modificarCostoCongreso(Matricula, Convert.ToDecimal(txtCostoActual.Text), Convert.ToDecimal(txtNuevoCosto.Text))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim costoOriginal As Decimal = db.exectSQLQueryScalar($"SELECT pagar FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
        txtNuevoCosto.Text = costoOriginal
    End Sub
End Class