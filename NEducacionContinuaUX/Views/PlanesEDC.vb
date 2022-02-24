Public Class PlanesEDC
    Dim listaPaneles As New List(Of Panel)
    Dim listatxtImportes As New List(Of TextBox)
    Dim listatxtRecargos As New List(Of NumericUpDown)
    Dim listatxtDescuentos As New List(Of NumericUpDown)
    Dim listatxtDescripcionDescuentos As New List(Of TextBox)
    Dim listadatePickerRecargos As New List(Of DateTimePicker)
    Dim listadatePickerDescuentos As New List(Of DateTimePicker)
    Dim listacbClaves As New List(Of ComboBox)
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
        Me.llenalistacbClaves()
        Me.llenarComboboxClavePagos()
        Me.llenalistatxtConcepto()
        Me.ocultarPaneles()
        pc.llenarComboBoxes(cbDiplomados, cbNoPagos, cbEspecificacionRecargos)
        datePickerRecargoInscripcion.MinDate = DateTime.Now
        datePickerLimiteDescuentoInscripcion.MinDate = DateTime.Now
        datePickerPagoUnico.MinDate = DateTime.Now
        datePickerDescuentoPagoUnico.MinDate = DateTime.Now
    End Sub

    Private Sub cbPlanes_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbPlanes.SelectedIndexChanged
        Try
            If (cbPlanes.Text <> "NUEVO PLAN" And cbPlanes.Text <> "-PLAN GENERAL-") Then
                txtNombrePlan.Text = cbPlanes.Text
                txtNombrePlan.Enabled = True
                txtPublicoPlan.Text = db.exectSQLQueryScalar($"SELECT PublicoPlan FROM ing_Planes WHERE ID = {cbPlanes.SelectedValue}")
                pc.llenarVentanaPlanesInscripcion(cbPlanes.SelectedValue, chbInscripcion, txtImporteInscripcion, chbRecargoInscripcion, chbDescuentoInscripcion, NURecargoInscripcion, datePickerRecargoInscripcion, NUDescuentoInscripcion, txtDescripcionDescuentoInscripcion, datePickerLimiteDescuentoInscripcion)
                pc.llenarVentanaPlanesColegiaturas(cbPlanes.SelectedValue, listaPaneles, listatxtImportes, listatxtRecargos, listatxtDescuentos, listatxtDescripcionDescuentos, listadatePickerRecargos, listadatePickerDescuentos, listacbClaves, listatxtConcepto, txtImportePagos, NURecargo, NUDescuento, txtDescripcionDescuentoPagos, chbRecargosPagos, chbDescuentoPagos, cbNoPagos)
                pc.llenarVentanaPlanesPagoUnico(cbPlanes.SelectedValue, chbPagoUnico, txtMontoPagoUnico, chbDescuentoPagoUnico, NUDescuentoPagoUnico, txtDescripcionDescuentoPagoUnico, datePickerDescuentoPagoUnico, datePickerPagoUnico)
                colegiaturas = cbNoPagos.SelectedIndex + 1
                edicion = True
                For x = 0 To colegiaturas - 1
                    listaPaneles(x).Visible = True
                Next
                chbInscripcion.Enabled = True
                chbPagoUnico.Enabled = True
            ElseIf (cbPlanes.Text = "-PLAN GENERAL-") Then
                edicion = False
                Me.resetControls()
                txtNombrePlan.Text = "PLAN GENERAL"
                txtNombrePlan.Enabled = False
            Else
                txtNombrePlan.Clear()
                txtNombrePlan.Enabled = True
                edicion = False
                Me.resetControls()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtImportePagos_TextChanged(sender As Object, e As EventArgs) Handles txtImportePagos.TextChanged
        If (txtImportePagos.TextLength <> 0) Then
            cbNoPagos.Enabled = True
        Else
            cbNoPagos.Enabled = False
        End If
    End Sub

    Private Sub txtNombrePlan_TextChanged(sender As Object, e As EventArgs) Handles txtNombrePlan.TextChanged
        If (txtNombrePlan.TextLength > 0) Then
            chbInscripcion.Enabled = True
            chbPagoUnico.Enabled = True
            txtImportePagos.Enabled = True
            chbRecargosPagos.Enabled = True
            'chbDescuentoPagos.Enabled = True
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
            NURecargoInscripcion.Enabled = True
            datePickerRecargoInscripcion.Enabled = True
            NURecargoInscripcion.Value = 0
        Else
            NURecargoInscripcion.Enabled = False
            datePickerRecargoInscripcion.Enabled = False
            NURecargoInscripcion.Text = "0.00"
        End If
    End Sub

    Private Sub chbDescuentoInscripcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbDescuentoInscripcion.CheckedChanged
        If (chbDescuentoInscripcion.Checked = True) Then
            NUDescuentoInscripcion.Enabled = True
            datePickerLimiteDescuentoInscripcion.Enabled = True
            txtDescripcionDescuentoInscripcion.Enabled = True
            NUDescuentoInscripcion.Value = 0
        Else
            NUDescuentoInscripcion.Enabled = False
            datePickerLimiteDescuentoInscripcion.Enabled = False
            txtDescripcionDescuentoInscripcion.Enabled = False
            NUDescuentoInscripcion.Text = "0.00"
        End If
    End Sub

    Private Sub chbInscripcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbInscripcion.CheckedChanged
        If (chbInscripcion.Checked = True) Then
            txtImporteInscripcion.Enabled = True
            'chbDescuentoInscripcion.Enabled = True
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
        Dim dtPlaceHolder As New DataTable()
        Dim planGeneralBand As Boolean
        dtPlaceHolder.Columns.Add("ID")
        dtPlaceHolder.Columns.Add("Nombre_Plan")


        Dim tablePlanes As DataTable = db.getDataTableFromSQL($"SELECT CAST(ID AS VARCHAR(MAX)) As ID, Nombre_Plan FROM ing_Planes WHERE ID_Congreso = {cbDiplomados.SelectedValue}")
        Me.resetControls()

        If (tablePlanes.Rows.Count > 0) Then
            For Each row As DataRow In tablePlanes.Rows
                Dim PG As Boolean = db.exectSQLQueryScalar($"SELECT PlanGeneral FROM ing_Planes WHERE ID = {row("ID")}")
                If (PG = True) Then
                    planGeneralBand = True
                End If
            Next

            If (planGeneralBand = True) Then
                dtPlaceHolder.Rows.Add(0, "NUEVO PLAN")
            Else
                dtPlaceHolder.Rows.Add(0, "-PLAN GENERAL-")
                dtPlaceHolder.Rows.Add(0, "NUEVO PLAN")
            End If
            dtPlaceHolder.Merge(tablePlanes)
            ComboboxService.llenarComboboxVacio(cbPlanes, dtPlaceHolder, "ID", "Nombre_Plan")
            txtNombrePlan.Enabled = True
            txtPublicoPlan.Enabled = True
        Else
            dtPlaceHolder.Rows.Add(0, "-PLAN GENERAL-")
            dtPlaceHolder.Rows.Add(0, "NUEVO PLAN")
            ComboboxService.llenarComboboxVacio(cbPlanes, dtPlaceHolder, "ID", "Nombre_Plan")
            cbPlanes.SelectedIndex = 0
            txtNombrePlan.Enabled = False
            txtPublicoPlan.Enabled = True
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

        If (chbRecargosPagos.Checked = True And NURecargo.Text.Length = 0) Then
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

        If (chbDescuentoPagos.Checked = True And NUDescuento.Text.Length = 0) Then
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
                listatxtDescuentos(x).Text = NUDescuento.Text
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
                listatxtRecargos(x).Text = NURecargo.Text
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
            NURecargo.Enabled = True
            GBRecargos.Enabled = True
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtRecargos(x).Enabled = True
            Next

            For x = 0 To cbNoPagos.SelectedIndex
                listadatePickerRecargos(x).Enabled = True
            Next
        Else
            GBRecargos.Enabled = False
            NURecargo.Enabled = False
            NURecargo.Value = 0
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtRecargos(x).Enabled = False
                listatxtRecargos(x).Value = 0
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
            NUDescuento.Enabled = True
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
            NUDescuento.Enabled = False
            txtDescripcionDescuentoPagos.Enabled = False
            NUDescuento.Value = 0
            txtDescripcionDescuentoPagos.Clear()
            For x = 0 To cbNoPagos.SelectedIndex
                listatxtDescuentos(x).Enabled = False
                listatxtDescuentos(x).Value = 0
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
            NUDescuentoPagoUnico.Enabled = True
            datePickerDescuentoPagoUnico.Enabled = True
            txtDescripcionDescuentoPagoUnico.Enabled = True
            NUDescuentoPagoUnico.Value = 0
        Else
            NUDescuentoPagoUnico.Enabled = False
            datePickerDescuentoPagoUnico.Enabled = False
            txtDescripcionDescuentoPagoUnico.Enabled = False
            NUDescuentoPagoUnico.Text = "0.00"
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
    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombrePlan.KeyPress, txtDescripcionDescuentoInscripcion.KeyPress, txtDescripcionDescuentoPagoUnico.KeyPress, txtDescripcionDescuentoPagos.KeyPress, txtPublicoPlan.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtImporteInscripcion_TextChanged(sender As Object, e As EventArgs) Handles txtImporteInscripcion.TextChanged
        txtImporteInscripcionText.Text = txtImporteInscripcion.Text
    End Sub

    Private Sub controlCantidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoPago1.KeyPress, txtMontoPago2.KeyPress, txtMontoPago3.KeyPress, txtMontoPago4.KeyPress, txtMontoPago5.KeyPress, txtMontoPago6.KeyPress, txtMontoPago7.KeyPress, txtMontoPago8.KeyPress, txtMontoPago9.KeyPress, txtMontoPago10.KeyPress,
                                                                                             NURecargos1.KeyPress, NURecargos2.KeyPress, NURecargos3.KeyPress, NURecargos4.KeyPress, NURecargos5.KeyPress, NURecargos6.KeyPress, NURecargos7.KeyPress, NURecargos8.KeyPress, NURecargos9.KeyPress, NURecargos10.KeyPress,
                                                                                             NUDescuentos1.KeyPress, NUDescuentos2.KeyPress, NUDescuentos3.KeyPress, NUDescuentos4.KeyPress, NUDescuentos5.KeyPress, NUDescuentos6.KeyPress, NUDescuentos7.KeyPress, NUDescuentos8.KeyPress, NUDescuentos9.KeyPress, NUDescuentos10.KeyPress
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

    Private Sub txtRecargoInscripcion_KeyPress(sender As Object, e As KeyPressEventArgs)
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
        ElseIf InStr(NURecargoInscripcion.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDescuentoInscripcion_KeyPress(sender As Object, e As KeyPressEventArgs)
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
        ElseIf InStr(NUDescuentoInscripcion.Text, ".") > 0 Then
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

    Private Sub txtDescuentoPagoUnico_KeyPress(sender As Object, e As KeyPressEventArgs)
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
        ElseIf InStr(NUDescuentoPagoUnico.Text, ".") > 0 Then
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

    Private Sub txtRecargosPagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NURecargo.KeyPress
        'If (NURecargo.Value > 100 Or NURecargos1.Value > 100 Or NURecargos2.Value > 100 Or NURecargos3.Value > 100 Or NURecargos4.Value > 100 Or NURecargos5.Value > 100 Or NURecargos6.Value > 100 Or NURecargos7.Value > 100 Or NURecargos8.Value > 100 Or NURecargos9.Value > 100 Or NURecargos10.Value > 100) Then
        '    NURecargos1.Text = 0
        '    NURecargos2.Text = 0
        '    NURecargos3.Text = 0
        '    NURecargos4.Text = 0
        '    NURecargos5.Text = 0
        '    NURecargos6.Text = 0
        '    NURecargos7.Text = 0
        '    NURecargos8.Text = 0
        '    NURecargos9.Text = 0
        '    NURecargos10.Text = 0
        'End If
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
        ElseIf InStr(NURecargo.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDescuentoPagos_KeyPress(sender As Object, e As KeyPressEventArgs)
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
        ElseIf InStr(NUDescuento.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDiaRecargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiaRecargo.KeyPress
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

    Private Sub cbClave1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave1.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave1.Text And x <> 0) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave1.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto1.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo1.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento1.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbClave2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave2.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave2.Text And x <> 1) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave2.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto2.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo2.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento2.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbClave3_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave3.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave3.Text And x <> 2) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave3.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto3.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo3.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento3.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbClave4_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave4.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave4.Text And x <> 3) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave4.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto4.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo4.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento4.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbClave5_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave5.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave5.Text And x <> 4) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave5.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto5.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo5.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento5.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbClave6_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave6.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave6.Text And x <> 5) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave6.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto6.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo6.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento6.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbClave7_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave7.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave7.Text And x <> 6) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave7.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto7.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo7.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento7.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbClave8_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave8.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave8.Text And x <> 7) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave8.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto8.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo8.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento8.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbClave9_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave9.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave9.Text And x <> 8) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave9.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto9.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo9.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento9.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbClave10_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbClave10.SelectionChangeCommitted
        Try
            For x = 0 To cbNoPagos.SelectedIndex
                If (listacbClaves(x).Text = cbClave10.Text And x <> 9) Then
                    listacbClaves(x).SelectedIndex = 0
                    listatxtConcepto(x).Clear()
                    Exit Sub
                End If
            Next
            Dim clave As Integer = Convert.ToInt32(cbClave10.Text)
            Dim mes As String() = Me.getmesclave(clave)
            ''txtConcepto10.Text = $"Pago de colegiatura de -{mes(0)}-"

            If (chbRecargosPagos.Checked = True) Then
                Dim dia As Integer
                If (chbPrimerDia.Checked = True) Then
                    dia = 1
                Else
                    dia = Convert.ToInt32(txtDiaRecargo.Text)
                End If
                datePickerRecargo10.Value = $"{DateTime.Now.Year}-{mes(1)}-{dia}"
            End If

            If (chbDescuentoPagos.Checked = True) Then
                Dim dia As Integer
                datePickerDescuento10.Value = $"{DateTime.Now.Year}-{mes(1)}-01"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefreshPagos_Click(sender As Object, e As EventArgs) Handles btnRefreshPagos.Click
        For x = 0 To 9
            listaPaneles(x).Visible = False
            listacbClaves(x).SelectedIndex = 0
            listatxtDescripcionDescuentos(x).Clear()
            listatxtDescuentos(x).Value = 0
            listatxtImportes(x).Clear()
            listatxtRecargos(x).Value = 0
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
        listatxtRecargos.Add(NURecargos1)
        listatxtRecargos.Add(NURecargos2)
        listatxtRecargos.Add(NURecargos3)
        listatxtRecargos.Add(NURecargos4)
        listatxtRecargos.Add(NURecargos5)
        listatxtRecargos.Add(NURecargos6)
        listatxtRecargos.Add(NURecargos7)
        listatxtRecargos.Add(NURecargos8)
        listatxtRecargos.Add(NURecargos9)
        listatxtRecargos.Add(NURecargos10)
    End Sub

    Sub llenarlistatxtDescuentos()
        listatxtDescuentos.Add(NUDescuentos1)
        listatxtDescuentos.Add(NUDescuentos2)
        listatxtDescuentos.Add(NUDescuentos3)
        listatxtDescuentos.Add(NUDescuentos4)
        listatxtDescuentos.Add(NUDescuentos5)
        listatxtDescuentos.Add(NUDescuentos6)
        listatxtDescuentos.Add(NUDescuentos7)
        listatxtDescuentos.Add(NUDescuentos8)
        listatxtDescuentos.Add(NUDescuentos9)
        listatxtDescuentos.Add(NUDescuentos10)
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

    Sub llenalistacbClaves()
        listacbClaves.Add(cbClave1)
        listacbClaves.Add(cbClave2)
        listacbClaves.Add(cbClave3)
        listacbClaves.Add(cbClave4)
        listacbClaves.Add(cbClave5)
        listacbClaves.Add(cbClave6)
        listacbClaves.Add(cbClave7)
        listacbClaves.Add(cbClave8)
        listacbClaves.Add(cbClave9)
        listacbClaves.Add(cbClave10)
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        PlanesEDC_Load(Me, Nothing)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtPublicoPlan.Text = "") Then
            MessageBox.Show("Ingrese el público al que ira dirigido el plan")
            Exit Sub
        End If
        If (chbInscripcion.Checked = True) Then
            If (txtImporteInscripcionText.Text = "") Then
                MessageBox.Show("Ingrese un monto de inscripción")
                Exit Sub
            ElseIf (chbRecargoInscripcion.Checked = True And NURecargoInscripcion.Text = "") Then
                MessageBox.Show("Ingrese un monto de recargo de inscripción")
                Exit Sub
            ElseIf (chbDescuentoInscripcion.Checked = True And NUDescuentoInscripcion.Text = "") Then
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
            ElseIf (NUDescuentoPagoUnico.Text = "") Then
                MessageBox.Show("Ingrese el monto correspondiente al descuento del pago unico")
                Exit Sub
            End If
        End If

        If (colegiaturas = 0) Then
            MessageBox.Show("Ingrese al menos una colegiatura")
            Exit Sub
        End If
        For x = 0 To colegiaturas - 1
            If (listacbClaves(x).Text = " ") Then
                MessageBox.Show("Ingrese la clave correspondiente a las colegiaturas")
                Exit Sub
            End If

            If (listatxtConcepto(x).Text = "" Or listatxtConcepto(x).Text = " ") Then
                MessageBox.Show("Ingrese la clave correspondiente a las colegiaturas")
                Exit Sub
            End If

            If (listatxtImportes(x).Text = "") Then
                MessageBox.Show("Ingrese el importe correspondiente a la colegiatura")
                Exit Sub
            End If

            If (listatxtDescuentos(x).Text = "") Then
                MessageBox.Show("Ingrese el importe correspondiente a los descuentos de la colegiatura")
                Exit Sub
            End If

            If (listatxtRecargos(x).Text = "") Then
                MessageBox.Show("Ingrese el importe correspondiente a los recargos de la colegiatura")
                Exit Sub
            End If
        Next
        Dim Agrega As Integer
        Dim Absorbe As Integer
        Dim Exenta As Integer
        If (RBAgregaC.Checked = True And RBAbsorbeC.Checked = False And RBExentaC.Checked = False) Then
            Agrega = 1
            Absorbe = 0
            Exenta = 0
        ElseIf (RBAgregaC.Checked = False And RBAbsorbeC.Checked = True And RBExentaC.Checked = False) Then
            Agrega = 0
            Absorbe = 1
            Exenta = 0
        ElseIf (RBAgregaC.Checked = False And RBAbsorbeC.Checked = False And RBExentaC.Checked = True) Then
            Agrega = 0
            Absorbe = 0
            Exenta = 1
        End If
        If (edicion = True) Then
            Dim NoRegistros As Integer = db.exectSQLQueryScalar($"SELECT COUNT(DISTINCT A.Matricula) FROM ing_AsignacionCargosPlanes AS A
                                                                  INNER JOIN ing_PlanesConceptos AS C ON C.ID = A.ID_Concepto
                                                                  WHERE C.ID_Plan = {cbPlanes.SelectedValue}")
            If (NoRegistros > 0) Then
                MessageBox.Show($"Hay {NoRegistros} persona/s registrada/s con este plan, no puede ser modificado")
                Exit Sub
                Me.Reiniciar()
            Else
                Try
                    db.startTransaction()
                    db.execSQLQueryWithoutParams($"UPDATE ing_PlanesConceptos SET Activo = 0 WHERE ID_Plan = {cbPlanes.SelectedValue}")
                    db.execSQLQueryWithoutParams($"UPDATE ing_Planes SET Nombre_Plan = '{txtNombrePlan.Text}', PublicoPlan = '{txtPublicoPlan.Text}' WHERE ID = {cbPlanes.SelectedValue}")
                    Dim Orden As Integer = 1
                    If (chbInscripcion.Checked = True) Then
                        pc.guardarInscripcion(cbPlanes.SelectedValue, Orden, txtImporteInscripcion.Text, NURecargoInscripcion.Text, NUDescuentoInscripcion.Text, pc.obtenerFechaString(datePickerLimiteDescuentoInscripcion), pc.obtenerFechaString(datePickerRecargoInscripcion), chbRecargoInscripcion.Checked, Agrega, Absorbe, Exenta)
                        Orden = Orden + 1
                    End If



                    For x = 0 To cbNoPagos.SelectedIndex
                        Dim Clave As String = listacbClaves(x).Text
                        Dim Mes As String = listatxtConcepto(x).Text.ToUpper()
                        pc.guardarPagoPlan(cbPlanes.SelectedValue, Orden, Clave, Mes, listatxtImportes(x).Text, listatxtRecargos(x).Text, listatxtDescuentos(x).Text, pc.obtenerFechaString(listadatePickerDescuentos(x)), pc.obtenerFechaString(listadatePickerRecargos(x)), chbRecargosPagos.Checked, Agrega, Absorbe, Exenta)
                        Orden = Orden + 1
                    Next

                    If (chbPagoUnico.Checked = True) Then
                        pc.guardarPagoUnico(cbPlanes.SelectedValue, Orden, CDec(txtMontoPagoUnico.Text), NUDescuentoPagoUnico.Text, pc.obtenerFechaString(datePickerDescuentoPagoUnico), pc.obtenerFechaString(datePickerPagoUnico), Agrega, Absorbe, Exenta)
                        Orden = Orden + 1
                    End If
                    db.commitTransaction()
                    MessageBox.Show("Plan modificado correctamente")
                    Me.Reiniciar()
                    Exit Sub
                Catch ex As Exception
                    db.rollBackTransaction()
                End Try
            End If
        Else
            Try
                db.startTransaction()
                Dim Orden As Integer = 1
                Dim planGeneral As Integer
                If (cbPlanes.Text = "-PLAN GENERAL-") Then
                    planGeneral = 1
                Else
                    planGeneral = 0
                End If
                Dim ID_Plan As Integer = pc.guardarPlan(txtNombrePlan.Text, cbDiplomados.SelectedValue, planGeneral, txtPublicoPlan.Text)
                If (chbInscripcion.Checked = True) Then
                    pc.guardarInscripcion(ID_Plan, Orden, txtImporteInscripcion.Text, NURecargoInscripcion.Text, NUDescuentoInscripcion.Text, pc.obtenerFechaString(datePickerLimiteDescuentoInscripcion), pc.obtenerFechaString(datePickerRecargoInscripcion), chbRecargoInscripcion.Checked, Agrega, Absorbe, Exenta)
                    Orden = Orden + 1
                End If

                For x = 0 To cbNoPagos.SelectedIndex
                    Dim Clave As String = listacbClaves(x).Text
                    Dim Mes As String = listatxtConcepto(x).Text.ToUpper()
                    pc.guardarPagoPlan(ID_Plan, Orden, Clave, Mes, listatxtImportes(x).Text, listatxtRecargos(x).Text, listatxtDescuentos(x).Text, pc.obtenerFechaString(listadatePickerDescuentos(x)), pc.obtenerFechaString(listadatePickerRecargos(x)), chbRecargosPagos.Checked, Agrega, Absorbe, Exenta)
                    Orden = Orden + 1
                Next

                If (chbPagoUnico.Checked = True) Then
                    pc.guardarPagoUnico(ID_Plan, Orden, CDec(txtMontoPagoUnico.Text), NUDescuentoPagoUnico.Text, pc.obtenerFechaString(datePickerDescuentoPagoUnico), pc.obtenerFechaString(datePickerPagoUnico), Agrega, Absorbe, Exenta)
                    Orden = Orden + 1
                End If
                db.commitTransaction()
                MessageBox.Show("Plan registrado correctamente")
                Me.Close()
                Me.Show()
            Catch ex As Exception
                db.rollBackTransaction()
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Sub resetControls()
        ''----------INSCRIPCION----------''
        chbInscripcion.Checked = False
        txtImporteInscripcion.Clear()
        chbRecargoInscripcion.Checked = False
        chbDescuentoInscripcion.Checked = False
        txtImporteInscripcionText.Clear()
        NURecargoInscripcion.Text = "0.00"
        NUDescuentoInscripcion.Text = "0.00"
        txtDescripcionDescuentoInscripcion.Clear()
        ''----------COLEGIATURAS----------''
        txtImportePagos.Clear()
        NURecargo.Value = 0
        NUDescuento.Value = 0
        txtDescripcionDescuentoPagos.Clear()
        chbRecargosPagos.Checked = False
        chbDescuentoPagos.Checked = False
        For x = 0 To 9
            listaPaneles(x).Visible = False
            listacbClaves(x).SelectedIndex = 0
            listatxtDescripcionDescuentos(x).Clear()
            listatxtDescuentos(x).Value = 0
            listatxtImportes(x).Clear()
            listatxtRecargos(x).Value = 0
        Next
        cbNoPagos.SelectedIndex = 0
        cbNoPagos.Enabled = False

        ''----------PAGO UNICO----------''
        chbPagoUnico.Checked = False
        txtMontoPagoUnico.Clear()
        chbDescuentoPagoUnico.Checked = False
        txtMontoPagoUnicoText.Clear()
        NUDescuentoPagoUnico.Text = "0.00"
        txtDescripcionDescuentoPagoUnico.Clear()
    End Sub

    Sub llenarComboboxClavePagos()
        For Each item As ComboBox In listacbClaves
            item.Items.Add(" ")
            item.Items.Add("01")
            item.Items.Add("02")
            item.Items.Add("03")
            item.Items.Add("04")
            item.Items.Add("05")
            item.Items.Add("06")
            item.Items.Add("07")
            item.Items.Add("08")
            item.Items.Add("09")
            item.Items.Add("10")
            item.Items.Add("11")
            item.Items.Add("12")
        Next
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
    End Sub
End Class