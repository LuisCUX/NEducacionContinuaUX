Public Class PagosOpcionalesController
    Dim db As DataBaseService = New DataBaseService

    Sub llenarCombobox(cbConceptoPara As ComboBox, cbTipoPago As ComboBox, cbTipoConcepto As ComboBox, cbNiveles As ComboBox)

        cbConceptoPara.Items.Clear()
        cbConceptoPara.Items.Add("EXTERNO")
        cbConceptoPara.Items.Add("ALUMNO")

        Dim tableTipoPago As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre FROM ing_CatTipoPagoOpcional WHERE Activo = 1")
        ComboboxService.llenarCombobox(cbTipoPago, tableTipoPago, "ID", "Nombre")

        cbTipoConcepto.Items.Clear()
        cbTipoConcepto.Items.Add("PRODUCTO")
        cbTipoConcepto.Items.Add("SERVICIO")

        Dim tableNiveles As DataTable = db.getDataTableFromSQL("SELECT Clave, Nivel FROM mov_CatNivel")
        ComboboxService.llenarCombobox(cbNiveles, tableNiveles, "Clave", "Nivel")
    End Sub

    Sub registrarPagoOpcional(NombrePago As String, Descripcion As String, claveProdServ As String, claveUnidad As String, valorUnitario As Decimal, para As String, considerarIVA As Integer, agregarIVA As Integer, exentaIVA As Integer, idTipoPago As Integer, turno As String, nivel As String)
        Try
            db.startTransaction()
            Dim ID_ResNT As Integer
            If (para <> "EXTERNO") Then
                ID_ResNT = db.exectSQLQueryScalar($"SELECT ID FROM mov_Res_Nivel_Turno WHERE Clave_Nivel = '{nivel}' AND Clave_Turno = '{turno}'")
            End If
            Dim ID_PagoOpcional As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_PagosOpcionales(Nombre, Descripcion, claveProductoServicio, claveUnidad, considerarIVA, AgregaIVA, ExentaIVA, ID_cat_TipoPagoOpcional, Activo) VALUES ('{NombrePago}', '{Descripcion}', '{claveProdServ}', '{claveUnidad}', {considerarIVA}, {agregarIVA}, {exentaIVA}, {idTipoPago}, 1)")
            db.execSQLQueryWithoutParams($"INSERT INTO ing_resPagoOpcionalAsignacion(ID_PagoOpcional, valorUnitario, Para, ID_res_NT, Activo) VALUES ({ID_PagoOpcional}, {valorUnitario}, '{para}', {ID_ResNT}, 1)")
            db.commitTransaction()
            MessageBox.Show("Pago opcional registrado correctamente")
            RegistroPagosOpcionales.Close()
            MainPagosOpcionales.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show($"Error: {ex.Message}")
        End Try

    End Sub
End Class