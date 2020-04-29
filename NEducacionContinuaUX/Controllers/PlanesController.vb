Public Class PlanesController
    Dim db As DataBaseService = New DataBaseService()
    Sub llenarComboBoxes(cbDiplomados As ComboBox, cbNoPagos As ComboBox, cbEspecificacionRecargos As ComboBox)
        cbEspecificacionRecargos.Items.Clear()
        cbEspecificacionRecargos.Items.Add("Mensual")
        cbEspecificacionRecargos.Items.Add("Bimestral")
        cbEspecificacionRecargos.Items.Add("Semestral")

        Dim tableDiplomados As DataTable = db.getDataTableFromSQL($"SELECT id_congreso, nombre FROM portal_congreso WHERE tipo_congreso = 1")
        ComboboxService.llenarCombobox(cbDiplomados, tableDiplomados, "id_congreso", "nombre")

        cbNoPagos.Items.Clear()
        For x = 0 To 9
            cbNoPagos.Items.Add(x + 1)
        Next
    End Sub

    Function guardarPlan(Nombre_Plan As String, ID_Congreso As Integer) As Integer
        Dim ID_Plan As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_Planes (Nombre_Plan, ID_Congreso, Activo) VALUES ('{Nombre_Plan}', {ID_Congreso}, 1)")
        Return ID_Plan
    End Function

    Function guardarInscripcion(ID_Plan As Integer, Orden As Integer, Importe As Decimal, Recargo As Decimal, Descuento As Decimal, Fecha_Limite_Desc As String, Fecha_Calcula_Recargo As String, Considera_Recargo As Boolean) As Integer
        Dim RecargoBit As Integer
        If (Considera_Recargo = True) Then
            RecargoBit = 1
        Else
            RecargoBit = 0
        End If

        db.execSQLQueryWithoutParams($"INSERT INTO ing_PlanesConceptos(ID_Plan, Orden, Clave, Descripcion, Importe, Recargo, Descuento, Fecha_Limite_Desc, Fecha_Calcula_Recargo, Considera_Recargo, Importe_Total, Activo) VALUES ({ID_Plan}, {Orden}, 'P01', 'PAGO DE INSCRIPCIÓN A DIPLOMADO', {Importe}, {Recargo}, {Descuento}, '{Fecha_Limite_Desc}', '{Fecha_Calcula_Recargo}', {RecargoBit}, {Importe}, 1)")
        Return Orden = Orden + 1
    End Function

    Function guardarPagoUnico(ID_Plan As Integer, Orden As Integer, Importe As Decimal, Descuento As Decimal, Fecha_Limite_Desc As String) As Integer
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PlanesConceptos(ID_Plan, Orden, Clave, Descripcion, Importe, Recargo, Descuento, Fecha_Limite_Desc, Fecha_Calcula_Recargo, Considera_Recargo, Importe_Total, Activo) VALUES ({ID_Plan}, {Orden}, 'P13', 'PAGO COMPLETO DE DIPLOMADO', {Importe}, 0.000000, {Descuento}, '{Fecha_Limite_Desc}', '1900-01-01', 0, {Importe}, 1)")
        Return Orden = Orden + 1
    End Function

    Function guardarPagoPlan(ID_Plan As Integer, Orden As Integer, Clave As String, Mes As String, Importe As Decimal, Recargo As Decimal, Descuento As Decimal, Fecha_Limite_Desc As String, Fecha_Calcula_Recargo As String, Considera_Recargo As Boolean) As Integer
        Dim RecargoBit As Integer
        If (Considera_Recargo = True) Then
            RecargoBit = 1
        Else
            RecargoBit = 0
        End If
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PlanesConceptos(ID_Plan, Orden, Clave, Descripcion, Importe, Recargo, Descuento, Fecha_Limite_Desc, Fecha_Calcula_Recargo, Considera_Recargo, Importe_Total, Activo) VALUES ({ID_Plan}, {Orden}, '{Clave}', '{Mes}', {Importe}, {Recargo}, {Descuento}, '{Fecha_Limite_Desc}', '{Fecha_Calcula_Recargo}', {RecargoBit}, {Importe}, 1)")
        Return Orden = Orden + 1
    End Function

    Function obtenerFechaString(datePicker As DateTimePicker) As String
        Dim dia As String = datePicker.Value.Day
        Dim mes As String = datePicker.Value.Month
        Dim año As String = datePicker.Value.Year

        Return $"{año}-{mes}-{dia}"
    End Function
End Class
