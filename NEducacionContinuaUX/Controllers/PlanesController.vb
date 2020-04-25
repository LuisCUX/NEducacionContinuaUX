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

    Sub guardarPlan(Inscripcion As Boolean, PagoUnico As Boolean, Nombre_Plan As String, ID_Congreso As Integer, montoInscripcion As Decimal, recargoInscripcion As Decimal, FechaLimiteInscripcion As Date, FechaRecargoInscripcion As Date, calculoRecargo As String)
        Dim orden As Integer = 1
        Dim ID_Plan As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_Planes (Nombre_Plan, ID_Congreso, Activo) VALUES ('{Nombre_Plan}', {ID_Congreso}, 1)")

        If (Inscripcion = True) Then
            db.execSQLQueryWithoutParams($"INSERT INTO ing_PlanesConceptos (ID_Plan, Orden, Clave, Descripcion, Importe, Recargo, Fecha_Limite_Desc, Calcula_Recargo, Considera_Recargo, Importe_Total, Activo) VALUES ({ID_Plan}, {orden}, 'P01', 'PAGO DE INSCRIPCIÓN A DIPLOMADO', {montoInscripcion}, {recargoInscripcion}, '{FechaLimiteInscripcion}', '{calculoRecargo}', '{FechaRecargoInscripcion}', {montoInscripcion}, 1)")
            orden = orden + 1
        End If

    End Sub
End Class
