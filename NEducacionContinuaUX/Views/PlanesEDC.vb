Public Class PlanesEDC
    Dim listaPaneles As New List(Of Panel)
    Dim listatxtImportes As New List(Of TextBox)
    Dim listatxtRecargos As New List(Of TextBox)
    Dim listatxtDescuentos As New List(Of TextBox)
    Dim listatxtDescripcionDescuentos As New List(Of TextBox)
    Dim listadatePickerRecargos As New List(Of DateTimePicker)
    Dim listadatePickerDescuentos As New List(Of DateTimePicker)
    Dim listatxtClaves As New List(Of TextBox)
    Dim listatxtConcepto As New List(Of TextBox)
    Dim pc As PlanesController = New PlanesController()
    Dim db As DataBaseService = New DataBaseService()
    Dim edicion As Boolean = False
    Dim colegiaturas As Integer = 0
    Private Sub PlanesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.llenarListaPanel()
        Me.llenarlistatxtImportes()
        Me.llenarlistatxtRecargos()
        Me.llenarlistatxtDescuentos()
        Me.llenarlistatxtDescripcionDescuentos()
        Me.llenarlistadatepickerdescuentos()
        Me.llenarlistadatepickerrecargos()
        Me.llenalistatxtClaves()
        Me.llenalistatxtConcepto()
        Me.ocultarPaneles()
        pc.llenarComboBoxes(cbDiplomados, cbNoPagos, cbEspecificacionRecargos)
        datePickerRecargoInscripcion.MinDate = DateTime.Now
        datePickerLimiteDescuentoInscripcion.MinDate = DateTime.Now
        datePickerPagoUnico.MinDate = DateTime.Now
        datePickerDescuentoPagoUnico.MinDate = DateTime.Now
    End Sub

    Private Sub cbPlanes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbPlanes.SelectionChangeCommitted
        If (cbPlanes.Text <> "NUEVO PLAN") Then
            txtNombrePlan.Text = cbPlanes.Text
            pc.llenarVentanaPlanesInscripcion(cbPlanes.SelectedValue, chbInscripcion, txtImporteInscripcion, chbRecargoInscripcion, chbDescuentoInscripcion, txtRecargoInscripcion, datePickerRecargoInscripcion, txtDescuentoInscripcion, txtDescripcionDescuentoInscripcion, datePickerLimiteDescuentoInscripcion)
            pc.llenarVentanaPlanesColegiaturas(cbPlanes.SelectedValue, listaPaneles, listatxtImportes, listatxtRecargos, listatxtDescuentos, listatxtDescripcionDescuentos, listadatePickerRecargos, listadatePickerDescuentos, listatxtClaves, listatxtConcepto, txtImportePagos, txtRecargosPagos, txtDescuentoPagos, txtDescripcionDescuentoPagos, chbRecargosPagos, chbDescuentoPagos, cbNoPagos)
            pc.llenarVentanaPlanesPagoUnico(cbPlanes.SelectedValue, chbPagoUnico, txtMontoPagoUnico, chbDescuentoPagoUnico, txtDescuentoPagoUnico, datePickerDescuentoPagoUnico, datePickerPagoUnico)
            edicion = True
        Else
            edicion = False
            Me.resetControls()
        End If
    End Sub

    Private Sub txtNombrePlan_TextChanged(sender As Object, e As EventArgs) Handles txtNombrePlan.TextChanged
        If (txtNombrePlan.TextLength > 0) Then
            chbInscripcion.Enabled = True
            chbPagoUnico.Enabled = True
            txtImportePagos.Enabled = True
            chbRecargosPagos.Enabled = True
            chbDescuentoPagos.Enabled = True
            cbNoPagos.Enabled = True
        Else
            chbInscripcion.Enabled = False
            chbPagoUnico.Enabled = False
            chbInscripcion.Checked = False
            chbPagoUnico.Checked = False
            txtImportePagos.Enabled = False
            chbRecargosPagos.Enabled = False
            chbDescuentoPagos.Enabled = False
            cbNoPagos.Enabled = False
        End If
    End Sub

    ''-----------------------------------------------------------------------------------------------------------------------------
    ''------------------------------------------------CONTROLES TAB INSCRIPCION----------------------------------------------------
    ''-----------------------------------------------------------------------------------------------------------------------------

    Private Sub chbRecargoInscripcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbRecargoInscripcion.CheckedChanged
        If (chbRecargoInscripcion.Checked = True) Then
            txtRecargoInscripcion.Enabled = True
            datePickerRecargoInscripcion.Enabled = True
            txtRecargoInscripcion.Clear()
        Else
            txtRecargoInscripcion.Enabled = False
            datePickerRecargoInscripcion.Enabled = False
            txtRecargoInscripcion.Text = "0.00"
        End If
    End Sub

    Private Sub chbDescuentoInscripcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbDescuentoInscripcion.CheckedChanged
        If (chbDescuentoInscripcion.Checked = True) Then
            txtDescuentoInscripcion.Enabled = True
            datePickerLimiteDescuentoInscripcion.Enabled = True
            txtDescripcionDescuentoInscripcion.Enabled = True
            txtDescuentoInscripcion.Clear()
        Else
            txtDescuentoInscripcion.Enabled = False
            datePickerLimiteDescuentoInscripcion.Enabled = False
            txtDescripcionDescuentoInscripcion.Enabled = False
            txtDescuentoInscripcion.Text = "0.00"
        End If
    End Sub

    Private Sub chbInscripcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbInscripcion.CheckedChanged
        If (chbInscripcion.Checked = True) Then
            txtImporteInscripcion.Enabled = True
            chbDescuentoInscripcion.Enabled = True
            chbRecargoInscripcion.Enabled = True
        Else
            txtImporteInscripcion.Enabled = False
            chbDescuentoInscripcion.Enabled = False
            chbRecargoInscripcion.Enabled = False
            chbDescuentoInscripcion.Checked = False
            chbRecargoInscripcion.Checked = False
        End If
    End Sub

    Private Sub cbDiplomados_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbDiplomados.SelectionChangeCommitted
        Dim tablePlanes As DataTable = db.getDataTableFromSQL($"SELECT ID, Nombre_Plan FROM ing_Planes WHERE ID_Congreso = {cbDiplomados.SelectedValue}")
        Me.resetControls()

        If (tablePlanes.Rows.Count > 0) Then
            ComboboxService.llenarCombobox(cbPlanes, tablePlanes, "ID", "Nombre_Plan")
            txtNombrePlan.Enabled = True
        Else
            cbPlanes.DataSource = Nothing
            cbPlanes.Items.Clear()
            cbPlanes.Items.Add("NUEVO PLAN")
            cbPlanes.SelectedIndex = 0
            txtNombrePlan.Enabled = True
            txtNombrePlan.Clear()
        End If
    End Sub



    ''-----------------------------------------------------------------------------------------------------------------------------
    ''---------------------------------------------------CONTROLES TAB PAGOS-------------------------------------------------------
    ''-----------------------------------------------------------------------------------------------------------------------------

    Private Sub cbNoPagos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNoPagos.SelectionChangeCommitted
        If (txtImportePagos.Text.Length = 0) Then
            MessageBox.Show("Ingrese el importe del total de pagos")
            cbNoPagos.SelectedIndex = 0
            Exit Sub
        End If

        If (chbRecargosPagos.Checked = True And txtRecargosPagos.Text.Length = 0) Then
            MessageBox.Show("Especifique el monto del recargo")
            cbNoPagos.SelectedIndex = 0
            Exit Sub
        End If

        If (chbRecargosPagos.Checked = True And cbEspecificacionRecargos.Text <> "Mensual" And cbEspecificacionRecargos.Text <> "Bimestral" And cbEspecificacionRecargos.Text <> "Semestral") Then
            MessageBox.Show("Especifique las condiciones de calculo de recargos")
            cbNoPagos.SelectedIndex = 0
            Exit Sub
        End If

        If (chbRecargosPagos.Checked = True And chbPrimerDia.Checked = False And txtDiaRecargo.Text.Length = 0) Then
            MessageBox.Show("Especifique el dia de calculo de recargos")
            cbNoPagos.SelectedIndex = 0
            Exit Sub
        End If

        If (chbDescuentoPagos.Checked = True And txtDescuentoPagos.Text.Length = 0) Then
            MessageBox.Show("Especifique el monto de descuento")
            cbNoPagos.SelectedIndex = 0
            Exit Sub
        End If

        If (chbDescuentoPagos.Checked = True And txtDescripcionDescuentoPagos.Text.Length = 0) Then
            MessageBox.Show("Especifique la descripcion de los descuentos")
            cbNoPagos.SelectedIndex = 0
            Exit Sub
        End If

        Dim pagomensual As Decimal = Format((CDec(txtImportePagos.Text) / CDec(cbNoPagos.Text)), "#####0.00")

        For x = 0 To cbNoPagos.SelectedIndex
            listatxtImportes(x).Text = pagomensual
        Next

        If (chbDescuentoPagos.Checked = True) Then
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtDescuentos(x).Text = txtDescuentoPagos.Text
                listatxtDescuentos(x).Enabled = True
                listatxtDescripcionDescuentos(x).Text = txtDescripcionDescuentoPagos.Text
                listatxtDescripcionDescuentos(x).Enabled = True
                listadatePickerDescuentos(x).Enabled = True
            Next
        Else
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtDescuentos(x).Text = "0.00"
            Next
        End If

        If (chbRecargosPagos.Checked = True) Then
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtRecargos(x).Text = txtRecargosPagos.Text
                listatxtRecargos(x).Enabled = True
                listadatePickerRecargos(x).Enabled = True
            Next
        Else
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtRecargos(x).Text = "0.00"
            Next
        End If

        Me.ocultarPaneles()
        colegiaturas = 0
        For x = 0 To cbNoPagos.SelectedIndex
            listaPaneles(x).Visible = True
            colegiaturas = colegiaturas + 1
        Next
    End Sub

    Private Sub chbRecargosPagos_CheckedChanged(sender As Object, e As EventArgs) Handles chbRecargosPagos.CheckedChanged
        If (chbRecargosPagos.Checked = True) Then
            txtRecargosPagos.Enabled = True
            GBRecargos.Enabled = True
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtRecargos(x).Enabled = True
            Next

            For x = 0 To cbNoPagos.SelectedIndex
                listadatePickerRecargos(x).Enabled = True
            Next
        Else
            GBRecargos.Enabled = False
            txtRecargosPagos.Enabled = False
            txtRecargosPagos.Clear()
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtRecargos(x).Enabled = False
                listatxtRecargos(x).Clear()
            Next

            For x = 0 To cbNoPagos.SelectedIndex
                listadatePickerRecargos(x).Enabled = False
                listadatePickerRecargos(x).MinDate = "1990-01-01"
                listadatePickerRecargos(x).Value = "1990-01-01"
            Next
        End If
    End Sub

    Private Sub chbDescuentoPagos_CheckedChanged(sender As Object, e As EventArgs) Handles chbDescuentoPagos.CheckedChanged
        If (chbDescuentoPagos.Checked = True) Then
            txtDescuentoPagos.Enabled = True
            txtDescripcionDescuentoPagos.Enabled = True
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtDescuentos(x).Enabled = True
            Next

            For x = 0 To cbNoPagos.SelectedIndex
                listatxtDescripcionDescuentos(x).Enabled = True
            Next

            For x = 0 To cbNoPagos.SelectedIndex
                listadatePickerDescuentos(x).Enabled = True
            Next
        Else
            txtDescuentoPagos.Enabled = False
            txtDescripcionDescuentoPagos.Enabled = False
            txtDescuentoPagos.Clear()
            txtDescripcionDescuentoPagos.Clear()
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtDescuentos(x).Enabled = False
                listatxtDescuentos(x).Clear()
            Next

            For x = 0 To cbNoPagos.SelectedIndex
                listatxtDescripcionDescuentos(x).Enabled = False
                listatxtDescripcionDescuentos(x).Clear()
            Next

            For x = 0 To cbNoPagos.SelectedIndex
                listadatePickerDescuentos(x).Enabled = False
                listadatePickerDescuentos(x).MinDate = "1990-01-01"
                listadatePickerDescuentos(x).Value = "1990-01-01"
            Next
        End If
    End Sub

    ''-----------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------CONTROLES TAB PAGO UNICO----------------------------------------------------
    ''-----------------------------------------------------------------------------------------------------------------------------

    Private Sub chbPagoUnico_CheckedChanged(sender As Object, e As EventArgs) Handles chbPagoUnico.CheckedChanged
        If (chbPagoUnico.Checked = True) Then
            txtMontoPagoUnico.Enabled = True
            datePickerPagoUnico.Enabled = True
            chbDescuentoPagoUnico.Enabled = True
        Else
            txtMontoPagoUnico.Enabled = False
            datePickerPagoUnico.Enabled = False
            chbDescuentoPagoUnico.Enabled = False
            chbDescuentoPagoUnico.Checked = False
        End If
    End Sub

    Private Sub chbDescuentoPagoUnico_CheckedChanged(sender As Object, e As EventArgs) Handles chbDescuentoPagoUnico.CheckedChanged
        If (chbDescuentoPagoUnico.Checked = True) Then
            txtDescuentoPagoUnico.Enabled = True
            datePickerDescuentoPagoUnico.Enabled = True
            txtDescripcionDescuentoPagoUnico.Enabled = True
            txtDescuentoPagoUnico.Clear()
        Else
            txtDescuentoPagoUnico.Enabled = False
            datePickerDescuentoPagoUnico.Enabled = False
            txtDescripcionDescuentoPagoUnico.Enabled = False
            txtDescuentoPagoUnico.Text = "0.00"
        End If
    End Sub

    Private Sub txtMontoPagoUnico_TextChanged(sender As Object, e As EventArgs) Handles txtMontoPagoUnico.TextChanged
        txtMontoPagoUnicoText.Text = txtMontoPagoUnico.Text
    End Sub

    Private Sub chbPrimerDia_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrimerDia.CheckedChanged
        If (chbPrimerDia.Checked = True) Then
            txtDiaRecargo.Enabled = False
        Else
            txtDiaRecargo.Enabled = True
        End If
    End Sub

    Sub ocultarPaneles()
        For Each panel As Panel In listaPaneles
            panel.Visible = False
        Next
    End Sub


    ''-----------------------------------------------------------------------------------------------------------------------------
    ''----------------------------------------------------CONTROLES TEXTBOX--------------------------------------------------------
    ''-----------------------------------------------------------------------------------------------------------------------------
    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombrePlan.KeyPress, txtDescripcionDescuentoInscripcion.KeyPress, txtDescripcionDescuentoPagoUnico.KeyPress, txtDescripcionDescuentoPagos.KeyPress,
                                                                               txtClavePago1.KeyPress, txtClavePago2.KeyPress, txtClavePago3.KeyPress, txtClavePago4.KeyPress, txtClavePago5.KeyPress, txtClavePago6.KeyPress, txtClavePago7.KeyPress, txtClavePago8.KeyPress, txtClavePago9.KeyPress, txtClavePago10.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtImporteInscripcion_TextChanged(sender As Object, e As EventArgs) Handles txtImporteInscripcion.TextChanged
        txtImporteInscripcionText.Text = txtImporteInscripcion.Text
    End Sub

    Private Sub txtImporteInscripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporteInscripcion.KeyPress
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
        ElseIf InStr(txtImporteInscripcion.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRecargoInscripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecargoInscripcion.KeyPress
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
        ElseIf InStr(txtRecargoInscripcion.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDescuentoInscripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoInscripcion.KeyPress
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
        ElseIf InStr(txtDescuentoInscripcion.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtMontoPagoUnico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoPagoUnico.KeyPress
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
        ElseIf InStr(txtMontoPagoUnico.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDescuentoPagoUnico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoPagoUnico.KeyPress
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
        ElseIf InStr(txtDescuentoPagoUnico.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtImportePagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImportePagos.KeyPress
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
        ElseIf InStr(txtImportePagos.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRecargosPagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecargosPagos.KeyPress
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
        ElseIf InStr(txtRecargosPagos.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDescuentoPagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuentoPagos.KeyPress
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
        ElseIf InStr(txtDescuentoPagos.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDiaRecargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiaRecargo.KeyPress, txtClavePago1.KeyPress, txtClavePago2.KeyPress, txtClavePago3.KeyPress, txtClavePago4.KeyPress, txtClavePago5.KeyPress,
                                                                                         txtClavePago6.KeyPress, txtClavePago7.KeyPress, txtClavePago8.KeyPress, txtClavePago9.KeyPress, txtClavePago10.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDiaRecargo_TextChanged(sender As Object, e As EventArgs) Handles txtDiaRecargo.TextChanged
        Try
            If (Convert.ToInt32(txtDiaRecargo.Text) > 30) Then
                txtDiaRecargo.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago1_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago1.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago1.Text And x <> 0) Then
                    listatxtClaves(x).Clear()
                    txtConcepto1.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago1.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto1.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo1.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago2_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago2.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago2.Text And x <> 1) Then
                    listatxtClaves(x).Clear()
                    txtConcepto2.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago2.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto2.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo2.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago3_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago3.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago3.Text And x <> 2) Then
                    listatxtClaves(x).Clear()
                    txtConcepto3.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago3.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto3.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo3.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago4_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago4.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago4.Text And x <> 3) Then
                    listatxtClaves(x).Clear()
                    txtConcepto4.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago4.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto4.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo4.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago5_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago5.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago5.Text And x <> 4) Then
                    listatxtClaves(x).Clear()
                    txtConcepto5.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago5.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto5.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo5.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago6_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago6.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago6.Text And x <> 5) Then
                    listatxtClaves(x).Clear()
                    txtConcepto6.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago6.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto6.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo6.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago7_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago7.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago7.Text And x <> 6) Then
                    listatxtClaves(x).Clear()
                    txtConcepto7.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago7.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto7.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo7.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago8_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago8.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago8.Text And x <> 7) Then
                    listatxtClaves(x).Clear()
                    txtConcepto8.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago8.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto8.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo8.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago9_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago9.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago9.Text And x <> 8) Then
                    listatxtClaves(x).Clear()
                    txtConcepto9.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago9.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto9.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo9.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClavePago10_TextChanged(sender As Object, e As EventArgs) Handles txtClavePago10.TextChanged
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listatxtClaves(x).Text = txtClavePago10.Text And x <> 9) Then
                    listatxtClaves(x).Clear()
                    txtConcepto10.Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(txtClavePago10.Text)
            Dim mes As String() = Me.getmesclave(clave)
            txtConcepto10.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo10.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefreshPagos_Click(sender As Object, e As EventArgs) Handles btnRefreshPagos.Click
        For x = 0 To 9
            listaPaneles(x).Visible = False
            listatxtClaves(x).Clear()
            listatxtDescripcionDescuentos(x).Clear()
            listatxtDescuentos(x).Clear()
            listatxtImportes(x).Clear()
            listatxtRecargos(x).Clear()
        Next
    End Sub

    Function getmesclave(clave As Integer) As String()
        If (clave = 1) Then
            Return {"Enero", 1}
        ElseIf (clave = 2) Then
            Return {"Febrero", 2}
        ElseIf (clave = 3) Then
            Return {"Marzo", 3}
        ElseIf (clave = 4) Then
            Return {"Abril", 4}
        ElseIf (clave = 5) Then
            Return {"Mayo", 5}
        ElseIf (clave = 6) Then
            Return {"Junio", 6}
        ElseIf (clave = 7) Then
            Return {"Julio", 7}
        ElseIf (clave = 8) Then
            Return {"Agosto", 8}
        ElseIf (clave = 9) Then
            Return {"Septiembre", 9}
        ElseIf (clave = 10) Then
            Return {"Octubre", 10}
        ElseIf (clave = 11) Then
            Return {"Noviembre", 11}
        ElseIf (clave = 12) Then
            Return {"Diciembre", 12}
        End If
        Return {Nothing, Nothing}
    End Function

    Sub llenarListaPanel()
        listaPaneles.Add(panelPagos1)
        listaPaneles.Add(panelPagos2)
        listaPaneles.Add(panelPagos3)
        listaPaneles.Add(panelPagos4)
        listaPaneles.Add(panelPagos5)
        listaPaneles.Add(panelPagos6)
        listaPaneles.Add(panelPagos7)
        listaPaneles.Add(panelPagos8)
        listaPaneles.Add(panelPagos9)
        listaPaneles.Add(panelPagos10)
    End Sub

    Sub llenarlistatxtImportes()
        listatxtImportes.Add(txtMontoPago1)
        listatxtImportes.Add(txtMontoPago2)
        listatxtImportes.Add(txtMontoPago3)
        listatxtImportes.Add(txtMontoPago4)
        listatxtImportes.Add(txtMontoPago5)
        listatxtImportes.Add(txtMontoPago6)
        listatxtImportes.Add(txtMontoPago7)
        listatxtImportes.Add(txtMontoPago8)
        listatxtImportes.Add(txtMontoPago9)
        listatxtImportes.Add(txtMontoPago10)
    End Sub

    Sub llenarlistatxtRecargos()
        listatxtRecargos.Add(txtRecargoPago1)
        listatxtRecargos.Add(txtRecargoPago2)
        listatxtRecargos.Add(txtRecargoPago3)
        listatxtRecargos.Add(txtRecargoPago4)
        listatxtRecargos.Add(txtRecargoPago5)
        listatxtRecargos.Add(txtRecargoPago6)
        listatxtRecargos.Add(txtRecargoPago7)
        listatxtRecargos.Add(txtRecargoPago8)
        listatxtRecargos.Add(txtRecargoPago9)
        listatxtRecargos.Add(txtRecargoPago10)
    End Sub

    Sub llenarlistatxtDescuentos()
        listatxtDescuentos.Add(txtDescuentoPago1)
        listatxtDescuentos.Add(txtDescuentoPago2)
        listatxtDescuentos.Add(txtDescuentoPago3)
        listatxtDescuentos.Add(txtDescuentoPago4)
        listatxtDescuentos.Add(txtDescuentoPago5)
        listatxtDescuentos.Add(txtDescuentoPago6)
        listatxtDescuentos.Add(txtDescuentoPago7)
        listatxtDescuentos.Add(txtDescuentoPago8)
        listatxtDescuentos.Add(txtDescuentoPago9)
        listatxtDescuentos.Add(txtDescuentoPago10)
    End Sub

    Sub llenarlistatxtDescripcionDescuentos()
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago1)
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago2)
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago3)
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago4)
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago5)
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago6)
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago7)
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago8)
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago9)
        listatxtDescripcionDescuentos.Add(txtDescripcionDescuentoPago10)
    End Sub

    Sub llenarlistadatepickerrecargos()
        listadatePickerRecargos.Add(datePickerRecargo1)
        listadatePickerRecargos.Add(datePickerRecargo2)
        listadatePickerRecargos.Add(datePickerRecargo3)
        listadatePickerRecargos.Add(datePickerRecargo4)
        listadatePickerRecargos.Add(datePickerRecargo5)
        listadatePickerRecargos.Add(datePickerRecargo6)
        listadatePickerRecargos.Add(datePickerRecargo7)
        listadatePickerRecargos.Add(datePickerRecargo8)
        listadatePickerRecargos.Add(datePickerRecargo9)
        listadatePickerRecargos.Add(datePickerRecargo10)
    End Sub

    Sub llenarlistadatepickerdescuentos()
        listadatePickerDescuentos.Add(datePickerDescuento1)
        listadatePickerDescuentos.Add(datePickerDescuento2)
        listadatePickerDescuentos.Add(datePickerDescuento3)
        listadatePickerDescuentos.Add(datePickerDescuento4)
        listadatePickerDescuentos.Add(datePickerDescuento5)
        listadatePickerDescuentos.Add(datePickerDescuento6)
        listadatePickerDescuentos.Add(datePickerDescuento7)
        listadatePickerDescuentos.Add(datePickerDescuento8)
        listadatePickerDescuentos.Add(datePickerDescuento9)
        listadatePickerDescuentos.Add(datePickerDescuento10)
    End Sub

    Sub llenalistatxtClaves()
        listatxtClaves.Add(txtClavePago1)
        listatxtClaves.Add(txtClavePago2)
        listatxtClaves.Add(txtClavePago3)
        listatxtClaves.Add(txtClavePago4)
        listatxtClaves.Add(txtClavePago5)
        listatxtClaves.Add(txtClavePago6)
        listatxtClaves.Add(txtClavePago7)
        listatxtClaves.Add(txtClavePago8)
        listatxtClaves.Add(txtClavePago9)
        listatxtClaves.Add(txtClavePago10)
    End Sub

    Sub llenalistatxtConcepto()
        listatxtConcepto.Add(txtConcepto1)
        listatxtConcepto.Add(txtConcepto2)
        listatxtConcepto.Add(txtConcepto3)
        listatxtConcepto.Add(txtConcepto4)
        listatxtConcepto.Add(txtConcepto5)
        listatxtConcepto.Add(txtConcepto6)
        listatxtConcepto.Add(txtConcepto7)
        listatxtConcepto.Add(txtConcepto8)
        listatxtConcepto.Add(txtConcepto9)
        listatxtConcepto.Add(txtConcepto10)
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        PlanesEDC_Load(Me, Nothing)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (chbInscripcion.Checked = True) Then
            If (txtImporteInscripcionText.Text = "") Then
                MessageBox.Show("Ingrese un monto de inscripción")
                Exit Sub
            ElseIf (chbRecargoInscripcion.Checked = True And txtRecargoInscripcion.Text = "") Then
                MessageBox.Show("Ingrese un monto de recargo de inscripción")
                Exit Sub
            ElseIf (chbDescuentoInscripcion.Checked = True And txtDescuentoInscripcion.Text = "") Then
                MessageBox.Show("Ingrese un monto de descuento de inscripción")
                Exit Sub
            ElseIf (chbDescuentoInscripcion.Checked = True And txtDescripcionDescuentoInscripcion.Text = "") Then
                MessageBox.Show("Ingrese una descripción de descuento de inscripción")
                Exit Sub
            End If
        End If

        If (chbPagoUnico.Checked = True) Then
            If (txtMontoPagoUnico.Text = "") Then
                MessageBox.Show("Ingrese el monto correspondiente al pago unico")
                Exit Sub
            ElseIf (chbDescuentoPagoUnico.Checked = True) Then
                MessageBox.Show("Ingrese el monto correspondiente al descuento del pago unico")
                Exit Sub
            End If
        End If

        If (colegiaturas = 0) Then
            MessageBox.Show("Ingrese al menos una colegiatura")
            Exit Sub
        End If

        If (edicion = True) Then
            Dim NoRegistros As Integer = db.exectSQLQueryScalar($"SELECT COUNT(ID) FROM ing_AsignacionCargosPlanes WHERE ID_Concepto IN (SELECT ID FROM ing_PlanesConceptos WHERE ID_Plan = {cbPlanes.SelectedValue})")
            If (NoRegistros > 0) Then
                MessageBox.Show($"Hay {NoRegistros} personas registradas con este plan, no puede ser modificado")
                Exit Sub
                Me.Reiniciar()
            End If
        End If
            Try
            db.startTransaction()
            Dim Orden As Integer = 1
            Dim ID_Plan As Integer = pc.guardarPlan(txtNombrePlan.Text, cbDiplomados.SelectedValue)
            If (chbInscripcion.Checked = True) Then
                pc.guardarInscripcion(ID_Plan, Orden, txtImporteInscripcion.Text, txtRecargoInscripcion.Text, txtDescuentoInscripcion.Text, pc.obtenerFechaString(datePickerLimiteDescuentoInscripcion), pc.obtenerFechaString(datePickerRecargoInscripcion), chbRecargoInscripcion.Checked)
                Orden = Orden + 1
            End If

            For x = 0 To cbNoPagos.SelectedIndex
                Dim Clave As String = listatxtClaves(x).Text
                Dim Mes As String = listatxtConcepto(x).Text.ToUpper()
                pc.guardarPagoPlan(ID_Plan, Orden, Clave, Mes, listatxtImportes(x).Text, listatxtRecargos(x).Text, listatxtDescuentos(x).Text, pc.obtenerFechaString(listadatePickerDescuentos(x)), pc.obtenerFechaString(listadatePickerRecargos(x)), chbRecargosPagos.Checked)
                Orden = Orden + 1
            Next

            If (chbPagoUnico.Checked = True) Then
                pc.guardarPagoUnico(ID_Plan, Orden, CDec(txtMontoPagoUnico.Text), txtDescuentoPagoUnico.Text, pc.obtenerFechaString(datePickerDescuentoPagoUnico), pc.obtenerFechaString(datePickerPagoUnico))
                Orden = Orden + 1
            End If
            db.commitTransaction()
            MessageBox.Show("Plan registrado correctamente")
            Me.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub resetControls()
        ''----------INSCRIPCION----------''
        chbInscripcion.Checked = False
        txtImporteInscripcion.Clear()
        chbRecargoInscripcion.Checked = False
        chbDescuentoInscripcion.Checked = False
        txtImporteInscripcionText.Clear()
        txtRecargoInscripcion.Text = "0.00"
        txtDescuentoInscripcion.Text = "0.00"
        txtDescripcionDescuentoInscripcion.Clear()

        ''----------COLEGIATURAS----------''
        txtImportePagos.Clear()
        txtRecargosPagos.Clear()
        txtDescuentoPagos.Clear()
        txtDescripcionDescuentoPagos.Clear()
        chbRecargosPagos.Checked = False
        chbDescuentoPagos.Checked = False
        For x = 0 To 9
            listaPaneles(x).Visible = False
            listatxtClaves(x).Clear()
            listatxtDescripcionDescuentos(x).Clear()
            listatxtDescuentos(x).Clear()
            listatxtImportes(x).Clear()
            listatxtRecargos(x).Clear()
        Next
        cbNoPagos.SelectedIndex = 0
        cbNoPagos.Enabled = False

        ''----------PAGO UNICO----------''
        chbPagoUnico.Checked = False
        txtMontoPagoUnico.Clear()
        chbDescuentoPagoUnico.Checked = False
        txtMontoPagoUnicoText.Clear()
        txtDescuentoPagoUnico.Text = "0.00"
        txtDescripcionDescuentoPagoUnico.Clear()
    End Sub
End Class