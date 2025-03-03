﻿Public Class PagosOpcionalesController
    Dim db As DataBaseService = New DataBaseService

    Sub llenarCombobox(cbConceptoPara As ComboBox, cbTipoPago As ComboBox, cbTipoConcepto As ComboBox, cbNiveles As ComboBox)

        cbConceptoPara.Items.Clear()
        cbConceptoPara.Items.Add("EXTERNO")
        cbConceptoPara.Items.Add("ALUMNO")

        Dim tableTipoPago As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre FROM ing_CatTipoPagoOpcional WHERE Activo = 1")
        ComboboxService.llenarComboboxVacio(cbTipoPago, tableTipoPago, "ID", "Nombre")

        cbTipoConcepto.Items.Clear()
        cbTipoConcepto.Items.Add("PRODUCTO")
        cbTipoConcepto.Items.Add("SERVICIO")

        Dim tableNiveles As DataTable = db.getDataTableFromSQL("SELECT Clave, Nivel FROM mov_CatNivel")
        ComboboxService.llenarComboboxVacio(cbNiveles, tableNiveles, "Clave", "Nivel")
    End Sub

    Sub llenarVentanaPago(ID As Integer, cbConceptoPara As ComboBox, cbNivel As ComboBox, cbTurno As ComboBox, cbTipoPago As ComboBox, cbTipoConcepto As ComboBox, cbDivision As ComboBox, cbGrupo As ComboBox, cbClase As ComboBox, cbProdServ As ComboBox, cbUnidad As ComboBox,
                           lblNivel As Label, lblTurno As Label, txtNombre As TextBox, txtDesc As TextBox, txtCostoUnitario As TextBox, txtCostoIVA As TextBox, chbExento As CheckBox, chbAbsorbe As CheckBox, chbAgrega As CheckBox, txtClavePS As TextBox, chbActivo As CheckBox)
        Dim cveUnidad As String
        Dim cveProdServ As String
        Dim tableUnidad As DataTable = db.getDataTableFromSQL("SELECT id_claveProd, nombre FROM ing_cat_unidad")
        ComboboxService.llenarCombobox(cbUnidad, tableUnidad, "id_claveProd", "nombre")
        Dim tablePago As DataTable = db.getDataTableFromSQL($"SELECT Nombre, Descripcion, claveProductoServicio, claveUnidad, considerarIVA, AgregaIVA, ExentaIVA, ID_cat_TipoPagoOpcional, Activo FROM ing_PagosOpcionales WHERE ID = {ID}")
        For Each item As DataRow In tablePago.Rows
            txtNombre.Text = item("Nombre")
            txtDesc.Text = item("Descripcion")
            cveUnidad = item("claveUnidad")
            If (item("ConsiderarIVA") = True) Then
                chbAbsorbe.Checked = True
            End If
            If (item("AgregaIVA") = True) Then
                chbAgrega.Checked = True
            End If
            If (item("ExentaIVA") = True) Then
                chbExento.Checked = True
            End If
            chbActivo.Checked = item("Activo")
            cbTipoPago.SelectedValue = item("ID_cat_TipoPagoOpcional")
            cveProdServ = item("claveProductoServicio")
        Next

        txtClavePS.Text = cveProdServ
        Me.BuscarClavePS(cveProdServ, cbTipoConcepto, cbDivision, cbGrupo, cbClase, cbProdServ)
        cbUnidad.SelectedValue = cveUnidad
        Dim tableAsignacion As DataTable = db.getDataTableFromSQL($"SELECT valorUnitario, Para, ID_res_NT FROM ing_resPagoOpcionalAsignacion WHERE ID_PagoOpcional = {ID}")
        For Each item As DataRow In tableAsignacion.Rows
            txtCostoUnitario.Text = Format(CDec(item("valorUnitario")), "#####0.00")
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

    Sub registrarPagoOpcional(NombrePago As String, Descripcion As String, claveProdServ As String, claveUnidad As String, valorUnitario As Decimal, para As String, considerarIVA As Integer, agregarIVA As Integer, exentaIVA As Integer, idTipoPago As Integer, turno As String, nivel As String, activo As Boolean)
        Try
            db.startTransaction()
            Dim ID_ResNT As Integer
            If (para <> "EXTERNO") Then
                ID_ResNT = db.exectSQLQueryScalar($"SELECT ID FROM mov_Res_Nivel_Turno WHERE Clave_Nivel = '{nivel}' AND Clave_Turno = '{turno}'")
            End If

            Dim activoInt As Integer
            If (activo) Then
                activoInt = 1
            Else
                activoInt = 0
            End If

            Dim ID_PagoOpcional As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_PagosOpcionales(Nombre, Descripcion, claveProductoServicio, claveUnidad, considerarIVA, AgregaIVA, ExentaIVA, ID_cat_TipoPagoOpcional, Activo) VALUES ('{NombrePago}', '{Descripcion}', '{claveProdServ}', '{claveUnidad}', {considerarIVA}, {agregarIVA}, {exentaIVA}, {idTipoPago}, {activoInt})")
            db.execSQLQueryWithoutParams($"INSERT INTO ing_resPagoOpcionalAsignacion(ID_PagoOpcional, valorUnitario, Para, ID_res_NT, Activo) VALUES ({ID_PagoOpcional}, {valorUnitario}, '{para}', {ID_ResNT}, 1)")
            db.commitTransaction()
            MessageBox.Show("Pago opcional registrado correctamente")
            ModalRegistroPagosOpcionalesEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show($"Error: {ex.Message}")
        End Try
    End Sub

    Sub guardarCambios(IDPago As Integer, NombrePago As String, Descripcion As String, claveProdServ As String, claveUnidad As String, valorUnitario As Decimal, para As String, considerarIVA As Integer, agregarIVA As Integer, exentaIVA As Integer, idTipoPago As Integer, turno As String, nivel As String, activo As Boolean)
        Try
            db.startTransaction()
            Dim ID_ResNT As Integer
            If (para <> "EXTERNO") Then
                ID_ResNT = db.exectSQLQueryScalar($"SELECT ID FROM mov_Res_Nivel_Turno WHERE Clave_Nivel = '{nivel}' AND Clave_Turno = '{turno}'")
            End If

            Dim activoInt As Integer
            If (activo) Then
                activoInt = 1
            Else
                activoInt = 0
            End If

            db.execSQLQueryWithoutParams($"UPDATE ing_PagosOpcionales SET Nombre = '{NombrePago}', Descripcion = '{Descripcion}', claveProductoServicio = '{claveProdServ}', claveUnidad = '{claveUnidad}', considerarIVA = {considerarIVA}, AgregaIVA = {agregarIVA}, ExentaIVA = {exentaIVA}, ID_cat_TipoPagoOpcional = {idTipoPago}, Activo = {activoInt} WHERE ID = {IDPago}")
            db.execSQLQueryWithoutParams($"UPDATE ing_resPagoOpcionalAsignacion SET valorUnitario = {valorUnitario}, Para = '{para}', ID_res_NT = {ID_ResNT} WHERE ID_PagoOpcional = {IDPago}")
            db.commitTransaction()
            MessageBox.Show("Pago opcional editado correctamente")
            MainRegistroPagosOpcionalesEDC.reloadGrid()
            ModalRegistroPagosOpcionalesEDC.Close()
        Catch ex As Exception
            db.rollBackTransaction()
            MessageBox.Show($"Error: {ex.Message}")
        End Try
    End Sub

    Sub BuscarClavePS(Clave As String, cbTipoConcepto As ComboBox, cbDivision As ComboBox, cbGrupo As ComboBox, cbClase As ComboBox, cbProdServ As ComboBox)
        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id FROM ing_CatClaveProdServSAT WHERE ClaveProdServ = '{Clave}'")
        If (exists = 0) Then
            MessageBox.Show("La clave ingresada no existe, ingrese una clave valida")
            Return
        End If

        Dim cve_clase As String = $"{Clave.Substring(0, Clave.Length() - 2) }00"
        Dim tableSat As DataTable = db.getDataTableFromSQL($"SELECT Tipo, Cve_division, cve_grupo, cve_clase FROM ing_ClasificacionClavesSAT WHERE cve_clase = '{cve_clase}'")

        For Each item As DataRow In tableSat.Rows
            If (item("tipo") = "Producto") Then
                cbTipoConcepto.SelectedIndex = 0
            ElseIf (item("tipo") = "Servicio") Then
                cbTipoConcepto.SelectedIndex = 1
            End If
            ModalRegistroPagosOpcionalesEDC.commitChangeTipo()

            cbDivision.SelectedValue = item("Cve_division")
            ModalRegistroPagosOpcionalesEDC.commitChangecbDivision()

            cbGrupo.SelectedValue = item("cve_grupo")
            ModalRegistroPagosOpcionalesEDC.commitChangecbGrupo()

            cbClase.SelectedValue = item("cve_clase")
            ModalRegistroPagosOpcionalesEDC.commitChangecbClase()

            cbProdServ.SelectedValue = Clave
        Next
    End Sub
End Class