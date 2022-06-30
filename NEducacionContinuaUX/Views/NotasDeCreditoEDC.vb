Imports System.Text.RegularExpressions

Public Class NotasDeCreditoEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim va As ValidacionesController = New ValidacionesController()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim nc As NotaCreditoController = New NotaCreditoController()
    Dim combo_filtro As String
    Private Sub NotasDeCreditoEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
        '                                                    INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
        '                                                    ORDER BY NombreCliente")
        'Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
        '                                                         INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
        '                                                         INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
        '                                                         ORDER BY C.nombre")

        'tableExternos.Merge(tableEDC)
        'ComboboxService.llenarCombobox(cbExterno, tableExternos, "clave_cliente", "NombreCliente")

        Dim tableTipoNota As DataTable = db.getDataTableFromSQL($"SELECT ID, TipoNota FROM ing_CatTipoNotaCredito WHERE Activo = 1")
        ComboboxService.llenarCombobox(cbTipoNota, tableTipoNota, "ID", "TipoNota")
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If (txtMonto.Text = "" Or NUPorcentaje.Value = 0) Then
            MessageBox.Show("Elija un porcentaje de devolución o bonificación")
            Exit Sub
        End If

        Dim ID As Integer = cbConcepto.SelectedValue

        For x = 0 To GridNota.Rows.Count - 1
            If (ID = GridNota.Rows(x).Cells(0).Value) Then
                MessageBox.Show("El concepto seleccionado ya fue ingresado")
                Exit Sub
            End If
        Next
        Dim IVA As Decimal = db.exectSQLQueryScalar($"select IVA from ing_xmlTimbradosConceptos WHERE ID = {ID}")
        Dim Descripcion As String
        Dim Total As Decimal
        Dim IVAFinal As Decimal
        Dim SinIVA As Decimal
        If (IVA > 0) Then
            Total = Format(CDec(txtMonto.Text) / 1.16, "#####0.00")
            IVAFinal = Format(CDec(txtMonto.Text) - Total, "#####0.00")
        Else
            Total = Format(CDec(txtMonto.Text), "#####0.00")
            IVAFinal = 0.00
        End If
        Dim TipoNota As String = db.exectSQLQueryScalar($"SELECT ClaveNota FROM ing_CatTipoNotaCredito WHERE ID = {cbTipoNota.SelectedValue}")
        Dim FolioFactura As String = cbConcepto.Text.Substring(7, 7)
        If (TipoNota = "NDCRC") Then
            Descripcion = $"BONIFICACION DE {db.exectSQLQueryScalar($"SELECT Descripcion FROM ing_PlanesRecargos WHERE ID = {ID}")}"
        ElseIf (TipoNota = "NDCDE") Then
            Descripcion = $"BONIFICACION DE {db.exectSQLQueryScalar($"SELECT Nombre_Concepto FROM ing_xmlTimbradosConceptos WHERE ID = {ID}")}"
        End If

        GridNota.Rows.Add(ID, Descripcion, Total, IVAFinal, (Total + IVAFinal), TipoNota, FolioFactura, NUPorcentaje.Value, lblTotal.Text)
        Me.actualizarTotal()
    End Sub

    Private Sub cbTipoNota_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoNota.SelectionChangeCommitted
        cbConcepto.DataSource = Nothing
        lblTotal.Text = ""
        txtMonto.Clear()
        txtMonto.Visible = False
        NUPorcentaje.Visible = False
        NUPorcentaje.Value = 0
        If (cbTipoNota.SelectedValue = 1) Then
            Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT R.ID, UPPER('Folio:' + ' ' + R.Folio + ' Fecha: ' + T.Fecha_Pago)As TextoFactura FROM ing_PlanesRecargos AS R
                                                                       INNER JOIN ing_xmlTimbrados AS T ON T.Folio = R.Folio
                                                                       WHERE Matricula_Clave = '{Matricula}' AND R.Activo = 0 AND R.Folio IS NOT NULL AND R.Autorizado = 0 AND R.Condonado = 0")
            ComboboxService.llenarCombobox(cbConcepto, tableConceptos, "ID", "TextoFactura")
        ElseIf (cbTipoNota.SelectedValue = 2) Then
            Dim tableConceptos As DataTable = db.getDataTableFromSQL($"(SELECT TC.ID, UPPER('Folio:' + ' ' + T.Folio + ' Fecha: ' + T.Fecha_Pago + ' - [' + TC.Nombre_Concepto + ']')As TextoFactura FROM ing_xmlTimbradosConceptos AS TC
                                                                       INNER JOIN ing_xmlTimbrados AS T ON T.ID = TC.XMLID AND T.Tipo_Pago != 'NOTA DE CREDITO'
                                                                       WHERE T.Matricula_Clave = '{Matricula}' AND TC.Nota = 0)
                                                                       UNION
                                                                       (SELECT TC.ID, UPPER('Folio:' + ' ' + T.Folio + ' Fecha: ' + T.Fecha_Pago + ' - [' + TC.Nombre_Concepto + ']')As TextoFactura
                                                                       FROM ing_NotasCreditoPorcentajes AS NP
                                                                       INNER JOIN ing_xmlTimbradosConceptos AS TC ON TC.IDConcepto = NP.IDConcepto AND TC.Clave_Concepto = NP.IDClavePago
                                                                       INNER JOIN ing_xmlTimbrados AS T ON TC.XMLID = T.ID
                                                                       WHERE NP.Activo = 1 AND T.Tipo_Pago != 'NOTA DE CREDITO' AND NP.Matricula = '{Matricula}')")
            ComboboxService.llenarCombobox(cbConcepto, tableConceptos, "ID", "TextoFactura")
        End If
    End Sub


    Private Sub cbConcepto_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbConcepto.SelectionChangeCommitted
        lblTotal.Text = ""
        txtMonto.Clear()
        NUPorcentaje.Value = 0
        txtMonto.Visible = False
        NUPorcentaje.Visible = False
        If (cbTipoNota.SelectedValue = 1) Then
            lblTotal.Text = Format(CDec(db.exectSQLQueryScalar($"SELECT Monto FROM ing_PlanesRecargos WHERE ID = {cbConcepto.SelectedValue}")), "#####0.00")
            txtMonto.Visible = True
            NUPorcentaje.Visible = True
            txtMonto.Clear()
            NUPorcentaje.Value = 0
        ElseIf (cbTipoNota.SelectedValue = 2) Then

            Dim IDNota As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_NotasCreditoPorcentajes WHERE IDXMLConcepto = {cbConcepto.SelectedValue}")
            If (IDNota > 0) Then
                lblTotal.Text = Format(CDec(db.exectSQLQueryScalar($"SELECT Importe_Restante FROM ing_NotasCreditoPorcentajes WHERE ID = {IDNota}")), "#####0.00")
            Else
                lblTotal.Text = Format(CDec(db.exectSQLQueryScalar($"SELECT Total FROM ing_xmlTimbradosConceptos WHERE ID = {cbConcepto.SelectedValue}")), "#####0.00")
            End If


            txtMonto.Visible = True
                NUPorcentaje.Visible = True
                txtMonto.Clear()
                NUPorcentaje.Value = 0
            End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        lblMatriculatxt.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelGridNota, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelGridNota, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCPtxt, lblRegFiscaltxt, lblCFDItxt, lblDireccion)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelGridNota, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCPtxt, lblRegFiscaltxt, lblCFDItxt, lblDireccion)
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        NotasDeCreditoEDC_Load(Me, Nothing)
    End Sub

    Private Sub txtPorcentaje_TextChanged(sender As Object, e As EventArgs) Handles NUPorcentaje.TextChanged
        Try
            Dim total As Decimal = CDec(lblTotal.Text)
            total = (total / 100) * Convert.ToDouble(NUPorcentaje.Text)
            txtMonto.Text = total
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NUPorcentaje.KeyPress
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
        ElseIf InStr(NUPorcentaje.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (GridNota.Rows.Count = 0) Then
            MessageBox.Show("Ingrese al menos un concepto")
            Exit Sub
        End If
        Dim listaConceptos As New List(Of Concepto)
        Dim listaUUID As New List(Of String)
        Dim listaUUID2 As New List(Of String)
        Dim listaUUIDDistinct As New List(Of String)
        Dim listaPorcentajes As New List(Of String)
        Dim listaCostoOrignial As New List(Of String)
        Dim claveConcepto As String
        For x = 0 To GridNota.Rows.Count - 1
            Dim concepto As New Concepto
            If (GridNota.Rows(x).Cells(5).Value = "NDCRC") Then
                claveConcepto = "REC"
                concepto = ch.crearConcepto(GridNota.Rows(x).Cells(0).Value, "REC", Matricula)
            ElseIf (GridNota.Rows(x).Cells(5).Value = "NDCDE") Then
                Dim IDConcepto As Integer = db.exectSQLQueryScalar($"SELECT IDConcepto FROM ing_xmlTimbradosConceptos WHERE ID = {GridNota.Rows(x).Cells(0).Value}")
                Dim tipoConcepto As String = db.exectSQLQueryScalar($"SELECT C.Clave FROM ing_xmlTimbradosConceptos AS T
                                                                      INNER JOIN ing_CatClavesPagos AS C ON C.ID = T.Clave_Concepto
                                                                      WHERE T.ID = {GridNota.Rows(x).Cells(0).Value}")
                concepto = ch.crearConcepto(IDConcepto, tipoConcepto, Matricula)
            End If
            concepto.NombreConcepto = GridNota.Rows(x).Cells(1).Value
            concepto.costoTotal = Format(CDec(GridNota.Rows(x).Cells(2).Value), "#####0.00")
            concepto.costoFinal = Format(CDec(GridNota.Rows(x).Cells(4).Value), "#####0.00")
            concepto.costoUnitario = Format(CDec(GridNota.Rows(x).Cells(2).Value), "#####0.00")
            concepto.costoBase = Format(CDec(GridNota.Rows(x).Cells(2).Value), "#####0.00")
            concepto.costoIVATotal = Format(CDec(GridNota.Rows(x).Cells(3).Value), "#####0.00") * concepto.Cantidad
            listaConceptos.Add(concepto)
            listaUUID.Add(GridNota.Rows(x).Cells(6).Value)
            listaPorcentajes.Add(GridNota.Rows(x).Cells(7).Value)
            listaCostoOrignial.Add(GridNota.Rows(x).Cells(8).Value)
        Next
        listaUUID2 = listaUUID
        listaUUID2 = listaUUID2.Distinct().ToList()
        For Each item As String In listaUUID2
            Dim folioFiscal As String = db.exectSQLQueryScalar($"SELECT FolioFiscal FROM ing_xmlTimbrados WHERE Folio = '{item}'")
            listaUUIDDistinct.Add(folioFiscal)
        Next

        nc.GenerarNotaCredito(listaConceptos, listaUUIDDistinct, listaUUID2, listaPorcentajes, listaCostoOrignial, lblRFCtxt.Text, lblNombretxt.Text, lblCFDItxt.Text, Matricula, cbTipoNota.Text, lblRegFiscaltxt.Text, lblCPtxt.Text)
    End Sub

    Sub actualizarTotal()
        Dim total As Decimal
        For x = 0 To GridNota.Rows.Count() - 1
            total = total + CDec(GridNota.Rows(x).Cells(4).Value)
        Next
        lblTotalNota.Text = total
    End Sub

    Public Sub keypress_textos_cmb(ByVal TXT As ComboBox, ByVal e As KeyPressEventArgs)
        Try

            Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\:\´]", RegexOptions.IgnoreCase)
            Dim KeyAscii As Short = Asc(e.KeyChar)

            If KeyAscii <> 8 Then
                e.Handled = re.IsMatch(e.KeyChar)
            End If

        Catch ex As Exception
            MsgBox("Error: en la validación de este campo, por favor verifique o comuniquese con sistemas", MsgBoxStyle.Exclamation, "Error en datos")
        End Try

    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectionChangeCommitted
        Try
            If (cbExterno.SelectedIndex <> -1) Then
                txtMatricula.Text = cbExterno.SelectedValue
                btnBuscar.PerformClick()
                txtMatricula.Clear()
                cbExterno.Text = ""
                combo_filtro = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbExterno_KeyUp(sender As Object, e As KeyEventArgs) Handles cbExterno.KeyUp
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            combo_filtro = cbExterno.Text
        End If
    End Sub

    Private Sub cbExterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbExterno.KeyPress
        Me.keypress_textos_cmb(cbExterno, e)
        Dim kc As KeysConverter = New KeysConverter()
        Dim encontrar As String = cbExterno.Text

        Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\´]", RegexOptions.IgnoreCase)
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If re.IsMatch(e.KeyChar) = False Then

            combo_filtro += kc.ConvertToString(e.KeyChar)
            Dim filtro As String = cbExterno.Text
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"(SELECT RC.clave_cliente, UPPER('Congreso: ' + C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                                INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
    											    WHERE (C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno LIKE '%{filtro}%'))

    											UNION
                                                                (SELECT CL.clave_cliente, UPPER('Externo: '+  C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroExterno AS E
                                                                INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
    										     	WHERE (C.nombre + ' ' +E.paterno + ' ' +E.materno LIKE '%{filtro}%'))")
            ComboboxService.llenarCombobox(cbExterno, tableFiltro, "clave_cliente", "NombreCliente")
            cbExterno.SelectedValue = -1
            cbExterno.Text = combo_filtro
            cbExterno.DroppedDown = True
            cbExterno.SelectionStart = encontrar.Length
            cbExterno.SelectionLength = cbExterno.Text.Length - cbExterno.SelectionStart
        Else
            If Asc(e.KeyChar) = Keys.Space Then
                combo_filtro += " "
            End If
        End If
    End Sub

    Function obtenerIVAConcepto(concepto As Concepto, costoOriginal As Decimal) As Concepto
        Dim unitariosiniva As Decimal = (CDec(costoOriginal) / 1.16)
        Dim IVA As Decimal = costoOriginal - unitariosiniva

        concepto.costoTotal = Format(CDec(unitariosiniva), "#####0.00")
        concepto.costoFinal = Format(CDec(unitariosiniva), "#####0.00")
        concepto.costoUnitario = Format(CDec(unitariosiniva), "#####0.00")
        concepto.costoBase = Format(CDec(unitariosiniva), "#####0.00")

        concepto.costoIVAUnitario = Format(CDec(IVA), "#####0.00")
        concepto.costoIVATotal = Format(CDec(IVA), "#####0.00")
        concepto.CostoIvaBase = unitariosiniva

        Return concepto
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim index As Integer
            index = GridNota.CurrentCell.RowIndex
            GridNota.Rows.RemoveAt(index)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
    End Sub

    Private Sub chb100_CheckedChanged(sender As Object, e As EventArgs) Handles chb100.CheckedChanged
        If (chb100.Checked = True) Then
            NUPorcentaje.Enabled = False
            NUPorcentaje.Value = 100
        Else
            txtMonto.Clear()
            NUPorcentaje.Enabled = True
            NUPorcentaje.Value = 0
        End If
    End Sub
End Class