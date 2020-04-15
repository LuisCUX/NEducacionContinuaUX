Public Class PlanesEDC
    Dim listaPaneles As New List(Of Panel)
    Dim pc As PlanesController = New PlanesController()
    Private Sub PlanesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.llenarListaPanel()
        Me.ocultarPaneles()
        pc.llenarComboBoxes(cbNoPagos)
    End Sub



    Private Sub txtNombrePlan_TextChanged(sender As Object, e As EventArgs) Handles txtNombrePlan.TextChanged
        If (txtNombrePlan.TextLength > 0) Then
            chbInscripcion.Enabled = True
            chbPagoUnico.Enabled = True
        Else
            chbInscripcion.Enabled = False
            chbPagoUnico.Enabled = False
            chbInscripcion.Checked = False
            chbPagoUnico.Checked = False
        End If
    End Sub

    ''-----------------------------------------------------------------------------------------------------------------------------
    ''------------------------------------------------CONTROLES TAB INSCRIPCION----------------------------------------------------
    ''-----------------------------------------------------------------------------------------------------------------------------

    Private Sub chbRecargoInscripcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbRecargoInscripcion.CheckedChanged
        If (chbRecargoInscripcion.Checked = True) Then
            txtRecargoInscripcion.Enabled = True
            datePickerRecargoInscripcion.Enabled = True
        Else
            txtRecargoInscripcion.Enabled = False
            datePickerRecargoInscripcion.Enabled = False
        End If
    End Sub

    Private Sub chbDescuentoInscripcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbDescuentoInscripcion.CheckedChanged
        If (chbDescuentoInscripcion.Checked = True) Then
            txtDescuentoInscripcion.Enabled = True
            datePickerLimiteDescuentoInscripcion.Enabled = True
            txtDescripcionDescuentoInscripcion.Enabled = True
        Else
            txtDescuentoInscripcion.Enabled = False
            datePickerLimiteDescuentoInscripcion.Enabled = False
            txtDescripcionDescuentoInscripcion.Enabled = False
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

    ''-----------------------------------------------------------------------------------------------------------------------------
    ''---------------------------------------------------CONTROLES TAB PAGOS-------------------------------------------------------
    ''-----------------------------------------------------------------------------------------------------------------------------

    Private Sub cbNoPagos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbNoPagos.SelectionChangeCommitted
        Me.ocultarPaneles()
        For x = 0 To cbNoPagos.SelectedIndex
            listaPaneles(x).Visible = True
        Next
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
        Else
            txtDescuentoPagoUnico.Enabled = False
            datePickerDescuentoPagoUnico.Enabled = False
            txtDescripcionDescuentoPagoUnico.Enabled = False
        End If
    End Sub

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

    Sub ocultarPaneles()
        For Each panel As Panel In listaPaneles
            panel.Visible = False
        Next
    End Sub


End Class