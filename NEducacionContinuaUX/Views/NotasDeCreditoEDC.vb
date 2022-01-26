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
        Dim ID As Integer = cbConcepto.SelectedValue
        Dim Descripcion As String
        Dim Total As Decimal = CDec(txtMonto.Text)
        Dim IVA As Decimal = 0.00
        Dim TipoNota As String = db.exectSQLQueryScalar($"SELECT ClaveNota FROM ing_CatTipoNotaCredito WHERE ID = {cbTipoNota.SelectedValue}")
        Dim FolioFactura As String = cbConcepto.Text.Substring(7, 7)
        If (TipoNota = "NDCRC") Then
            Descripcion = $"BONIFICACION DE {db.exectSQLQueryScalar($"SELECT Descripcion FROM ing_PlanesRecargos WHERE ID = {ID}")}"
        End If

        GridNota.Rows.Add(ID, Descripcion, Total, IVA, TipoNota, FolioFactura)
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
            txtMonto.Text = CDec(lblTotal.Text)
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
            va.buscarMatriculaEX(Matricula, panelDatos, panelGridNota, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelGridNota, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt)
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        NotasDeCreditoEDC_Load(Me, Nothing)
    End Sub

    Private Sub txtPorcentaje_TextChanged(sender As Object, e As EventArgs) Handles NUPorcentaje.TextChanged
        Dim total As Decimal = CDec(lblTotal.Text)
        total = (total / 100) * Convert.ToDouble(NUPorcentaje.Text)
        txtMonto.Text = total
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
        Dim listaConceptos As New List(Of Concepto)
        Dim listaUUID As New List(Of String)
        Dim listaUUID2 As New List(Of String)
        Dim listaUUIDDistinct As New List(Of String)
        For x = 0 To GridNota.Rows.Count - 1
            If (GridNota.Rows(x).Cells(4).Value = "NDCRC") Then
                Dim concepto As New Concepto
                concepto = ch.crearConcepto(GridNota.Rows(x).Cells(0).Value, "REC", Matricula)
                concepto.NombreConcepto = GridNota.Rows(x).Cells(1).Value
                listaConceptos.Add(concepto)
                listaUUID.Add(GridNota.Rows(x).Cells(5).Value)
                listaUUID.Add(GridNota.Rows(x).Cells(5).Value)
            End If
        Next
        listaUUID2 = listaUUID
        listaUUID2 = listaUUID2.Distinct().ToList()
        For Each item As String In listaUUID2
            Dim folioFiscal As String = db.exectSQLQueryScalar($"SELECT FolioFiscal FROM ing_xmlTimbrados WHERE Folio = '{item}'")
            listaUUIDDistinct.Add(folioFiscal)
        Next

        nc.GenerarNotaCredito(listaConceptos, listaUUIDDistinct, listaUUID, lblRFCtxt.Text, lblRFCtxt.Text, "P01", lblTotalNota.Text, lblTotalNota.Text, "0.00", Matricula, cbTipoNota.Text)
    End Sub

    Sub actualizarTotal()
        Dim total As Decimal
        For x = 0 To GridNota.Rows.Count() - 1
            total = total + CDec(GridNota.Rows(x).Cells(2).Value)
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
End Class