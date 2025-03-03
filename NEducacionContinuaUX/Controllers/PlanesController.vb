﻿Public Class PlanesController
    Dim db As DataBaseService = New DataBaseService()
    Sub llenarComboBoxes(cbDiplomados As ComboBox, cbNoPagos As ComboBox, cbEspecificacionRecargos As ComboBox)
        cbEspecificacionRecargos.Items.Clear()
        cbEspecificacionRecargos.Items.Add("Mensual")
        cbEspecificacionRecargos.Items.Add("Bimestral")
        cbEspecificacionRecargos.Items.Add("Semestral")

        Dim tableDiplomados As DataTable = db.getDataTableFromSQL($"SELECT id_congreso, nombre FROM portal_congreso WHERE id_tipo_evento = 1 AND clave_servicio IS NOT NULL")
        ''Dim tableDiplomados As DataTable = db.getDataTableFromSQL($"SELECT id_congreso, nombre FROM portal_congreso WHERE id_tipo_evento IS NULL")
        ComboboxService.llenarComboboxVacio(cbDiplomados, tableDiplomados, "id_congreso", "nombre")

        cbNoPagos.Items.Clear()
        For x = 0 To 9
            cbNoPagos.Items.Add(x + 1)
        Next
    End Sub

    Function guardarPlan(Nombre_Plan As String, ID_Congreso As Integer, planGeneral As Integer, Publico As String) As Integer
        Dim ID_Plan As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_Planes (Nombre_Plan, ID_Congreso, PublicoPlan, PlanGeneral, Activo) VALUES ('{Nombre_Plan}', {ID_Congreso}, '{Publico}', {planGeneral}, 1)")
        Return ID_Plan
    End Function

    Sub guardarInscripcion(ID_Plan As Integer, Orden As Integer, Importe As Decimal, Recargo As Decimal, Descuento As Decimal, Fecha_Limite_Desc As String, Fecha_Calcula_Recargo As String, Considera_Recargo As Boolean, AgregaIVA As Integer, AbsorbeIVA As Integer, ExentaIVA As Integer)
        Dim RecargoBit As Integer
        If (Considera_Recargo = True) Then
            RecargoBit = 1
        Else
            RecargoBit = 0
        End If

        Dim recargoMonto As Decimal = CDec((Importe / 100) * Recargo)
        Dim descuentoMonto As Decimal = CDec((Importe / 100) * Descuento)

        db.execSQLQueryWithoutParams($"INSERT INTO ing_PlanesConceptos(ID_Plan, Orden, Clave, Descripcion, Importe, Recargo, Recargo_Porcentaje, Descuento, Descuento_Porcentaje, Fecha_Limite_Desc, Fecha_Calcula_Recargo, Considera_Recargo, Fecha_Limite_Pago, Importe_Total, AgregaIVA, AbsorbeIVA, ExentaIVA, Activo) VALUES ({ID_Plan}, {Orden}, 'P00', 'INSCRIPCIÓN', {Importe}, {recargoMonto}, {Recargo}, {descuentoMonto}, {Descuento}, '{Fecha_Limite_Desc}', '{Fecha_Calcula_Recargo}', {RecargoBit}, '1900-01-01', {Importe}, {AgregaIVA}, {AbsorbeIVA}, {ExentaIVA}, 1)")
    End Sub

    Sub guardarPagoUnico(ID_Plan As Integer, Orden As Integer, Importe As Decimal, Descuento As Decimal, Fecha_Limite_Desc As String, Fecha_Limite_Pago As String, AgregaIVA As Integer, AbsorbeIVA As Integer, ExentaIVA As Integer)
        Dim descuentoMonto As Decimal = CDec((Importe / 100) * Descuento)
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PlanesConceptos(ID_Plan, Orden, Clave, Descripcion, Importe, Recargo, Recargo_Porcentaje,  Descuento, Descuento_Porcentaje, Fecha_Limite_Desc, Fecha_Calcula_Recargo, Considera_Recargo, Fecha_Limite_Pago, Importe_Total, AgregaIVA, AbsorbeIVA, ExentaIVA, Activo) VALUES ({ID_Plan}, {Orden}, 'P13', 'PAGO UNICO', {Importe}, 0.00, 0, {descuentoMonto}, {Descuento}, '{Fecha_Limite_Desc}', '1900-01-01', 0, '{Fecha_Limite_Pago}', {Importe}, {AgregaIVA}, {AbsorbeIVA}, {ExentaIVA}, 1)")
    End Sub

    Sub guardarPagoPlan(ID_Plan As Integer, Orden As Integer, Clave As String, Mes As String, Importe As Decimal, Recargo As Decimal, Descuento As Decimal, Fecha_Limite_Desc As String, Fecha_Calcula_Recargo As String, Considera_Recargo As Boolean, AgregaIVA As Integer, AbsorbeIVA As Integer, ExentaIVA As Integer)
        Dim RecargoBit As Integer
        If (Considera_Recargo = True) Then
            RecargoBit = 1
        Else
            RecargoBit = 0
        End If

        Dim recargoMonto As Decimal = CDec((Importe / 100) * Recargo)
        Dim descuentoMonto As Decimal = CDec((Importe / 100) * Descuento)
        Dim ClaveString As String = $"P{Clave}"
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PlanesConceptos(ID_Plan, Orden, Clave, Descripcion, Importe, Recargo, Recargo_Porcentaje, Descuento, Descuento_Porcentaje, Fecha_Limite_Desc, Fecha_Calcula_Recargo, Considera_Recargo, Fecha_Limite_Pago, Importe_Total, AgregaIVA, AbsorbeIVA, ExentaIVA, Activo) VALUES ({ID_Plan}, {Orden}, '{ClaveString}', '{Mes}', {Importe}, {recargoMonto}, {Recargo}, {descuentoMonto}, {Descuento}, '{Fecha_Limite_Desc}', '{Fecha_Calcula_Recargo}', {RecargoBit}, '1900-01-01', {Importe}, {AgregaIVA}, {AbsorbeIVA}, {ExentaIVA}, 1)")
    End Sub

    Sub llenarVentanaPlanesInscripcion(IDPlan As Integer, chbInscripcion As CheckBox, txtImporte As TextBox, chbRecargo As CheckBox, chbDescuento As CheckBox, txtRecargo As NumericUpDown, datePickerFechaRecargo As DateTimePicker, txtDescuento As NumericUpDown, txtDescripcionDescuento As TextBox, datePickerDescuento As DateTimePicker)
        Dim tableInscripcion As DataTable = db.getDataTableFromSQL($"SELECT Importe, Recargo, Recargo_Porcentaje, Fecha_Calcula_Recargo, Descuento, Descuento_Porcentaje, Fecha_Limite_Desc 
                                                                     FROM ing_PlanesConceptos WHERE ID_Plan = {IDPlan} AND Clave = 'P00' AND Activo = 1")
        If (tableInscripcion.Rows.Count = 0) Then
            chbInscripcion.Checked = False
            chbInscripcion.Enabled = False
        Else
            chbInscripcion.Checked = True
            chbInscripcion.Enabled = True
            For Each item As DataRow In tableInscripcion.Rows
                If (CDec(item("Recargo")) <= 0.00) Then
                    chbRecargo.Checked = False
                Else
                    chbRecargo.Checked = True
                End If

                If (CDec(item("Descuento")) <= 0.00) Then
                    chbDescuento.Checked = False
                Else
                    chbDescuento.Checked = True
                End If
                txtImporte.Text = Format(CDec(item("Importe")), "#####0.00")
                txtRecargo.Text = item("Recargo_Porcentaje")
                txtDescuento.Text = item("Descuento_Porcentaje")
                txtDescripcionDescuento.Text = "----------"
                datePickerDescuento.MinDate = item("Fecha_Limite_Desc")
                datePickerDescuento.Value = item("Fecha_Limite_Desc")
                datePickerFechaRecargo.MinDate = item("Fecha_Calcula_Recargo")
                datePickerFechaRecargo.Value = item("Fecha_Calcula_Recargo")
            Next
        End If
    End Sub

    Sub llenarVentanaPlanesColegiaturas(IDPlan As Integer, listaPaneles As List(Of Panel), listatxtImportes As List(Of TextBox), listatxtRecargos As List(Of NumericUpDown), listatxtDescuentos As List(Of NumericUpDown), listatxtDescripcionDescuentos As List(Of TextBox), listadatePickerRecargos As List(Of DateTimePicker), listadatePickerDescuentos As List(Of DateTimePicker), listacbClaves As List(Of ComboBox), listatxtConcepto As List(Of TextBox),
                                        txtImporteTotal As TextBox, txtRecargoTotal As NumericUpDown, txtDescuentoTotal As NumericUpDown, txtDescripcionDescuentos As TextBox, chbRecargo As CheckBox, chbDescuento As CheckBox, cbNoPagos As ComboBox)
        Dim tableColegiaturas As DataTable = db.getDataTableFromSQL($"SELECT Clave, Descripcion, Importe, Recargo, Recargo_Porcentaje, Fecha_Calcula_Recargo, Descuento, Descuento_Porcentaje, Fecha_Limite_Desc
                                                                      From ing_PlanesConceptos
                                                                      Where ID_Plan = {IDPlan} And Activo = 1 And Clave! = 'P00' AND Clave != 'P13'")
        Dim importeTotal As Decimal
        For x = 0 To tableColegiaturas.Rows.Count - 1
            Dim item As DataRow = tableColegiaturas.Rows(x)
            If (CDec(item("Recargo")) <= 0.00) Then
                chbRecargo.Checked = False
                chbRecargo.Enabled = False
            Else
                chbRecargo.Checked = True
                chbRecargo.Enabled = True
            End If

            If (CDec(item("Descuento")) <= 0.00) Then
                chbDescuento.Checked = False
                chbDescuento.Enabled = True
            Else
                chbDescuento.Checked = True
                chbDescuento.Enabled = True
            End If
            listaPaneles(x).Visible = True
            listatxtImportes(x).Text = Format(CDec(item("Importe")), "#####0.00")
            importeTotal = importeTotal + item("Importe")
            listatxtImportes(x).Enabled = True
            listatxtRecargos(x).Text = item("Recargo_Porcentaje")
            txtRecargoTotal.Text = item("Recargo_Porcentaje")
            listatxtRecargos(x).Enabled = True
            listatxtDescuentos(x).Text = item("Descuento_Porcentaje")
            txtDescuentoTotal.Text = item("Descuento_Porcentaje")
            listatxtDescuentos(x).Enabled = True
            listatxtDescripcionDescuentos(x).Text = "----------"
            txtDescripcionDescuentos.Text = "----------"
            listatxtDescripcionDescuentos(x).Enabled = True

            listadatePickerRecargos(x).MinDate = item("Fecha_Calcula_Recargo")
            listadatePickerRecargos(x).Value = item("Fecha_Calcula_Recargo")
            listadatePickerRecargos(x).Enabled = True

            listadatePickerDescuentos(x).MinDate = item("Fecha_Limite_Desc")
            listadatePickerDescuentos(x).Value = item("Fecha_Limite_Desc")
            listadatePickerDescuentos(x).Enabled = True

            listacbClaves(x).Text = item("Clave").ToString().Substring(1, item("Clave").ToString().Length() - 1)
            listacbClaves(x).Enabled = True
            listatxtConcepto(x).Text = item("Descripcion")
        Next
        txtImporteTotal.Text = Format(CDec(importeTotal), "#####0.00")
        txtImporteTotal.Enabled = True
        cbNoPagos.SelectedIndex = tableColegiaturas.Rows.Count - 1
        cbNoPagos.Enabled = True
    End Sub

    Sub llenarVentanaPlanesPagoUnico(IDPlan As Integer, chbPagoUnico As CheckBox, txtImporte As TextBox, chbDescuento As CheckBox, txtDescuento As NumericUpDown, txtDescuentoDescripcion As TextBox, datepickerDescuento As DateTimePicker, datepickerPagoUnico As DateTimePicker)
        Dim tablePagoUnico As DataTable = db.getDataTableFromSQL($"SELECT Importe, Descuento, Descuento_Porcentaje, Fecha_Limite_Desc, Fecha_Limite_Pago 
                                                                   FROM ing_PlanesConceptos WHERE ID_Plan = {IDPlan} AND Clave = 'P13' AND Activo = 1")
        If (tablePagoUnico.Rows.Count = 0) Then
            chbPagoUnico.Checked = False
            chbPagoUnico.Enabled = False
        Else
            chbPagoUnico.Checked = True
            chbPagoUnico.Enabled = True
            For Each item As DataRow In tablePagoUnico.Rows
                If (CDec(item("Descuento")) <= 0.00) Then
                    chbDescuento.Checked = False
                Else
                    chbDescuento.Checked = True
                End If
                txtImporte.Text = Format(CDec(item("Importe")), "#####0.00")
                txtDescuento.Text = item("Descuento_Porcentaje")
                txtDescuentoDescripcion.Text = "----------"
                datepickerDescuento.MinDate = item("Fecha_Limite_Desc")
                datepickerDescuento.Value = item("Fecha_Limite_Desc")
                datepickerPagoUnico.MinDate = item("Fecha_Limite_Pago")
                datepickerPagoUnico.Value = item("Fecha_Limite_Pago")
            Next
        End If
    End Sub

    Function obtenerFechaString(datePicker As DateTimePicker) As String
        Try
            Dim dia As String = datePicker.Value.Day
            Dim mes As String = datePicker.Value.Month
            Dim año As String = datePicker.Value.Year

            Return $"{año}-{mes}-{dia}"
        Catch ex As Exception
            Return "1900-01-01"
        End Try

    End Function
End Class
