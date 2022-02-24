﻿Public Class CancelacionFacturasEDC
    Dim db As DataBaseService = New DataBaseService
    Dim Folio As String
    Dim Matricula As String
    Dim IDFolio As Integer
    Dim FechaFactura As Date
    Dim Tipo_Pago As String
    Dim cf As CancelacionFacturasController = New CancelacionFacturasController
    Private Sub CancelacionFacturasEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbTipoCancelacion.Items.Add("Cancelación del día")
        cbTipoCancelacion.Items.Add("Cancelación de otro día")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Folio = txtFolio.Text

        IDFolio = db.exectSQLQueryScalar($"SELECT ID FROM ing_xmlTimbrados WHERE Folio = '{Folio}' AND CanceladaHoy = 0 AND CanceladaOtroDia = 0")
        If (IDFolio < 1) Then
            MessageBox.Show("El folio ingresado no existe o ya esta cancelado, ingrese un folio válido")
            Me.Reiniciar()
            Exit Sub
        End If

        Matricula = db.exectSQLQueryScalar($"SELECT Matricula_Clave FROM ing_xmlTimbrados WHERE Folio = '{Folio}'")
        FechaFactura = db.exectSQLQueryScalar($"SELECT (CONVERT(VARCHAR(20), CAST((SUBSTRING(Fecha_Pago, 0, 11))AS date), 103) + ' ' + SUBSTRING(Fecha_Pago, 12, LEN(Fecha_Pago))) AS FECHA FROM ing_xmlTimbrados WHERE Folio = '{Folio}'")
        Tipo_Pago = db.exectSQLQueryScalar($"SELECT Tipo_Pago FROM ing_xmlTimbrados WHERE Folio = '{Folio}'")
        lblMatriculatxt.Text = Matricula
        lblFechaFacturaciontxt.Text = FechaFactura
        If (cbTipoCancelacion.SelectedIndex = 0 And (FechaFactura.Date <> Date.Today)) Then
            MessageBox.Show("La factura seleccionada no fue emitida el dia de hoy, elija una factura que haya sido emitida el dia de hoy")
            Me.Reiniciar()
            Exit Sub
        ElseIf (cbTipoCancelacion.SelectedIndex = 1 And (FechaFactura.Date = Date.Today)) Then
            MessageBox.Show("La factura seleccionada fue emitida el dia de hoy, elija una factura que no haya sido emitida el dia de hoy")
            Me.Reiniciar()
            Exit Sub
        End If
        lblRFCtxt.Text = db.exectSQLQueryScalar($"SELECT rfc FROM portal_catRFC AS R
                                                  INNER JOIN portal_reRFC AS RE ON RE.id_rfc = R.id_rfc
                                                  INNER JOIN portal_registroExterno AS EX ON EX.id_registro = RE.id_registro
                                                  WHERE EX.clave_cliente = '{Matricula}'")

        Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT Nombre_Concepto, Cantidad, PrecioUnitario, Descuento, IVA, Total FROM ing_xmlTimbradosConceptos WHERE XMLID = {IDFolio}")

        For Each concepto As DataRow In tableConceptos.Rows
            concepto("PrecioUnitario") = Format(CDec(concepto("PrecioUnitario")), "#####0.00")
            concepto("Descuento") = Format(CDec(concepto("Descuento")), "#####0.00")
            concepto("IVA") = Format(CDec(concepto("IVA")), "#####0.00")
            concepto("Total") = Format(CDec(concepto("Total")), "#####0.00")
        Next


        GridConceptos.DataSource = tableConceptos
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        CancelacionFacturasEDC_Load(Me, Nothing)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cbTipoCancelacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoCancelacion.SelectionChangeCommitted
        If (cbTipoCancelacion.SelectedIndex >= 0) Then
            txtFolio.Enabled = True
        Else
            txtFolio.Enabled = False
        End If
    End Sub

    Private Sub btnGuardarCancelacion_Click(sender As Object, e As EventArgs) Handles btnGuardarCancelacion.Click
        If (GridConceptos.Rows.Count() < 1) Then
            MessageBox.Show("No hay conceptos que cancelar, ingrese el folio de una factura para poder cancelarla")
            Me.Reiniciar()
            Exit Sub
        End If
        Try
            db.startTransaction()
            Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT ID, Clave_Concepto, IDConcepto FROM ing_xmlTimbradosConceptos WHERE XMLID = {IDFolio}")
            db.execSQLQueryWithoutParams($"INSERT INTO Ing_Cancelaciones(Folio, Matricula, TipoFactura, IDObservacion, FechaCancelacion, TipoCancelacion, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', '{Tipo_Pago}', 0, GETDATE(), {cbTipoCancelacion.SelectedIndex}, '{User.getUsername}', 1)")

            Dim query As String
            If (cbTipoCancelacion.SelectedIndex = 0) Then
                query = "CanceladaHoy = 1, CanceladaOtroDia = 0"
            ElseIf (cbTipoCancelacion.SelectedIndex = 1) Then
                query = "CanceladaHoy = 0, CanceladaOtroDia = 1"
            End If

            db.execSQLQueryWithoutParams($"UPDATE ing_xmlTimbrados SET {query} WHERE ID = {IDFolio}")
            cf.CancelarPagos(Matricula, IDFolio, Folio, tableConceptos)

            db.commitTransaction()
            MessageBox.Show("Factura cancelada exitosamente")
            Me.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
        End Try
    End Sub
End Class