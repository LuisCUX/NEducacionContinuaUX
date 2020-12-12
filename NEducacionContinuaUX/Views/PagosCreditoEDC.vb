Public Class PagosCreditoEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim pc As PagosCreditoController = New PagosCreditoController()
    Dim va As ValidacionesController = New ValidacionesController()
    Private Sub PagosCreditoEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        txtMatriculaDato.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelCobroCredito, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelCobroCredito, txtNombre, txtEmail, txtCarrera, txtTurno, txtRFC)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelCobroCredito, txtNombre, txtEmail, txtCarrera, txtTurno, txtRFC)
        End If
        Dim tableFacturasCredito As DataTable = db.getDataTableFromSQL($"SELECT ID, UPPER('FOLIO: ' + Folio + ' - FECHA: ' + CAST(Fecha AS VARCHAR(MAX))) As Descripcion FROM ing_Creditos WHERE Matricula = '{Matricula}' AND Activo = 1")
        ComboboxService.llenarCombobox(cbFactura, tableFacturasCredito, "ID", "Descripcion")
    End Sub

    Private Sub cbFactura_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbFactura.SelectionChangeCommitted
        gridConceptosFactura.Rows.Clear()
        Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT C.IDConcepto, C.Clave_Concepto, CP.Clave, C.Nombre_Concepto, C.Total FROM ing_xmlTimbradosConceptos AS C
                                                                   INNER JOIN ing_xmlTimbrados AS T ON T.ID = C.XMLID
                                                                   INNER JOIN ing_Creditos AS CR ON CR.Folio = T.Folio AND CR.FolioFiscal = T.FolioFiscal
                                                                   INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = C.Clave_Concepto
                                                                   WHERE CR.ID = {cbFactura.SelectedValue}")
        For Each row As DataRow In tableConceptos.Rows
            gridConceptosFactura.Rows.Add(row("IDConcepto"), row("Clave_Concepto"), row("Clave"), row("Nombre_Concepto"), row("Total"))
        Next
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If (gridConceptosFactura.Rows.Count = 0) Then
            MessageBox.Show("Seleccione una factura a agregar")
            Exit Sub
        End If
        Dim IDFactura As Integer = cbFactura.SelectedValue
        Dim tableInfoPagos As DataTable = db.getDataTableFromSQL($"SELECT ID, Folio, Fecha, Cantidad, Cantidad_Abonada, NumAbonos FROM ing_Creditos WHERE ID = {IDFactura}")
        Dim tableHistorialPagos As DataTable = db.getDataTableFromSQL($"SELECT Folio, NumPago, Monto_Anterior, Monto_Abonado, Monto_Actual FROM ing_PagosCredito WHERE ID_Credito = {IDFactura}")
        For Each row As DataRow In tableInfoPagos.Rows
            GridFacturaSeleccionada.Rows.Add(row("ID"), row("Folio"), row("Fecha"), row("Cantidad"), row("Cantidad_Abonada"), row("NumAbonos"))
        Next

        For Each row As DataRow In tableHistorialPagos.Rows
            GridFacturaPagos.Rows.Add(row("Folio"), row("NumPago"), row("Monto_Anterior"), row("Monto_Abonado"), row("Monto_Actual"))
        Next

        Dim noPago As Integer = Convert.ToInt32(GridFacturaSeleccionada.Rows(0).Cells(5).Value) + 1
        Dim rowCount As Integer = GridFacturaPagos.Rows.Count - 1
        Dim IDCredito As Integer = GridFacturaSeleccionada.Rows(0).Cells(0).Value
        If (noPago = 1) Then
            lblTotal.Text = db.exectSQLQueryScalar($"SELECT Cantidad FROM ing_Creditos WHERE ID = {IDCredito}")
        Else
            lblTotal.Text = CDec(GridFacturaPagos.Rows(rowCount).Cells(4).Value)
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        PagosCreditoEDC_Load(Me, Nothing)
    End Sub

    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        Dim IDCredito As Integer = GridFacturaSeleccionada.Rows(0).Cells(0).Value
        Dim CantidadAbonada As Decimal = CDec(txtMonto.Text)
        Dim montoAnterior As Decimal
        Dim rowCount As Integer = GridFacturaPagos.Rows.Count - 1

        Dim noPago As Integer = Convert.ToInt32(GridFacturaSeleccionada.Rows(0).Cells(5).Value) + 1
        If (noPago = 1) Then
            montoAnterior = db.exectSQLQueryScalar($"SELECT Cantidad FROM ing_Creditos WHERE ID = {IDCredito}")
        Else
            montoAnterior = CDec(GridFacturaPagos.Rows(rowCount).Cells(4).Value)
        End If
        Dim montoNuevo As Decimal = montoAnterior - CantidadAbonada
        Dim IDXML As Integer = pc.cobroCredito(IDCredito, CantidadAbonada, montoAnterior, montoNuevo, Matricula, noPago)
        Me.Reiniciar()
        Exit Sub
    End Sub
End Class