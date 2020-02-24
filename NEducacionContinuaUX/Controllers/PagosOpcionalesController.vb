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

    Sub llenarVentanaPago(ID As Integer, cbConceptoPara As ComboBox, cbNivel As ComboBox, cbTurno As ComboBox, cbTipoPago As ComboBox, cbTipoConcepto As ComboBox, cbDivision As ComboBox, cbGrupo As ComboBox, cbClase As ComboBox, cbProdServ As ComboBox, cbUnidad As ComboBox,
                           lblNivel As Label, lblTurno As Label, txtNombre As TextBox, txtDesc As TextBox, txtCostoUnitario As TextBox, txtCostoIVA As TextBox, chbExento As CheckBox, chbAbsorbe As CheckBox, chbAgrega As CheckBox)

        Dim cveProdServ As String
        Dim tableUnidad As DataTable = db.getDataTableFromSQL("SELECT id_claveProd, nombre FROM sat_cat_unidad")
        ComboboxService.llenarCombobox(cbUnidad, tableUnidad, "id_claveProd", "nombre")
        Dim tablePago As DataTable = db.getDataTableFromSQL($"SELECT Nombre, Descripcion, claveProductoServicio, claveUnidad, considerarIVA, AgregaIVA, ExentaIVA, ID_cat_TipoPagoOpcional FROM ing_PagosOpcionales WHERE ID = {ID}")
        For Each item As DataRow In tablePago.Rows
            txtNombre.Text = item("Nombre")
            txtDesc.Text = item("Descripcion")
            cbUnidad.SelectedValue = item("claveUnidad")
            If (item("ConsiderarIVA") = True) Then
                chbAbsorbe.Checked = True
            End If
            If (item("AgregaIVA") = True) Then
                chbAgrega.Checked = True
            End If
            If (item("ExentaIVA") = True) Then
                chbExento.Checked = True
            End If
            cbTipoPago.SelectedValue = item("ID_cat_TipoPagoOpcional")
            cveProdServ = item("claveProductoServicio")
        Next


        Dim prodservlike = cveProdServ.Substring(0, cveProdServ.Length() - 2) + "%"
        Dim tableSAT As DataTable = db.getDataTableFromSQL($"SELECT tipo, cve_division, cve_grupo, cve_clase FROM sat_ClasificacionClavesSAT WHERE cve_clase LIKE '{prodservlike}'")
        For Each item As DataRow In tableSAT.Rows
            cbTipoConcepto.Text = item("tipo")
            ModalRegistroPagosOpcionalesEDC.commitChangeTipo()

            cbDivision.SelectedValue = item("cve_division")
            ModalRegistroPagosOpcionalesEDC.commitChangecbDivision()

            cbGrupo.SelectedValue = item("cve_grupo")
            ModalRegistroPagosOpcionalesEDC.commitChangecbGrupo()

            cbClase.SelectedValue = item("cve_clase")
            ModalRegistroPagosOpcionalesEDC.commitChangecbClase()
        Next

        cbProdServ.SelectedValue = cveProdServ

        Dim tableAsignacion As DataTable = db.getDataTableFromSQL($"SELECT valorUnitario, Para, ID_res_NT FROM ing_resPagoOpcionalAsignacion WHERE ID = {ID}")
        For Each item As DataRow In tableAsignacion.Rows
            txtCostoUnitario.Text = item("valorUnitario")
            cbConceptoPara.Text = item("Para")
            If (item("Para") = "ALUMNO") Then
                lblNivel.Visible = True
                lblTurno.Visible = True

                cbNivel.SelectedValue = db.exectSQLQueryScalar($"SELECT Clave_Nivel FROM mov_Res_Nivel_Turno WHERE ID = {item("ID_res_NT")}")
                cbNivel.Visible = True
                ModalRegistroPagosOpcionalesEDC.commitChangecbNivel()

                cbTurno.SelectedValue = db.exectSQLQueryScalar($"SELECT Clave_Turno FROM mov_Res_Nivel_Turno WHERE ID = {item("ID_res_NT")}")
                cbTurno.Visible = True
            End If
        Next

        txtCostoUnitario.Enabled = True
        chbAbsorbe.Enabled = True
        chbAgrega.Enabled = True
        chbExento.Enabled = True
        cbTipoConcepto.Enabled = True
        cbDivision.Enabled = True
        cbGrupo.Enabled = True
        cbClase.Enabled = True
        cbTipoPago.Enabled = True
        txtNombre.Enabled = True
        txtDesc.Enabled = True
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
            ModalRegistroPagosOpcionalesEDC.Close()
            MainRegistroPagosOpcionalesEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show($"Error: {ex.Message}")
        End Try
    End Sub

    Sub guardarCambios(IDPago As Integer, NombrePago As String, Descripcion As String, claveProdServ As String, claveUnidad As String, valorUnitario As Decimal, para As String, considerarIVA As Integer, agregarIVA As Integer, exentaIVA As Integer, idTipoPago As Integer, turno As String, nivel As String)
        Try
            db.startTransaction()
            Dim ID_ResNT As Integer
            If (para <> "EXTERNO") Then
                ID_ResNT = db.exectSQLQueryScalar($"SELECT ID FROM mov_Res_Nivel_Turno WHERE Clave_Nivel = '{nivel}' AND Clave_Turno = '{turno}'")
            End If

            db.execSQLQueryWithoutParams($"UPDATE ing_PagosOpcionales SET Nombre = '{NombrePago}', Descripcion = '{Descripcion}', claveProductoServicio = '{claveProdServ}', claveUnidad = '{claveUnidad}', considerarIVA = {considerarIVA}, AgregaIVA = {agregarIVA}, ExentaIVA = {exentaIVA}, ID_cat_TipoPagoOpcional = {idTipoPago} WHERE ID = {IDPago}")
            db.execSQLQueryWithoutParams($"UPDATE ing_resPagoOpcionalAsignacion SET valorUnitario = {valorUnitario}, Para = '{para}', ID_res_NT = {ID_ResNT} WHERE ID_PagoOpcional = {IDPago}")
            db.commitTransaction()
            MessageBox.Show("Pago opcional editado correctamente")
            ModalRegistroPagosOpcionalesEDC.Close()
            MainRegistroPagosOpcionalesEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show($"Error: {ex.Message}")
        End Try
    End Sub
End Class