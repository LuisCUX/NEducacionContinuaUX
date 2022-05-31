Public Class CancelacionFacturasEDC
    Dim db As DataBaseService = New DataBaseService
    Dim Folio As String
    Dim Matricula As String
    Dim IDFolio As Integer
    Dim FechaFacturaStr As String
    Dim FechaHoy As String
    Dim Tipo_Pago As String
    Dim c As CobrosController = New CobrosController
    Dim cf As CancelacionFacturasController = New CancelacionFacturasController
    Private Sub CancelacionFacturasEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbTipoCancelacion.Items.Add("Cancelación del día")
        cbTipoCancelacion.Items.Add("Cancelación de otro día")
        Dim tableObservacion As DataTable = db.getDataTableFromSQL($"SELECT ID, Observacion FROM ing_CatObservacionesCancelacion WHERE Activo = 1 AND ID_TipoOtraObservacion = 1")
        ComboboxService.llenarCombobox(cbObservacionCancelaciones, tableObservacion, "iD", "Observacion")

        Dim tableObservacionSAT As DataTable = db.getDataTableFromSQL($"SELECT clave, descripcion FROM ing_cat_motivo_cancelacion_sat WHERE activo = 1")
        ComboboxService.llenarCombobox(cbMotivoSAT, tableObservacionSAT, "clave", "descripcion")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim dia As String
        Dim mes As String
        Dim meshoy
        Dim diahoy
        Dim year As String
        Folio = txtFolio.Text.ToUpper()

        IDFolio = db.exectSQLQueryScalar($"SELECT ID FROM ing_xmlTimbrados WHERE Folio = '{Folio}' AND CanceladaHoy = 0 AND CanceladaOtroDia = 0")
        Dim idCancelacion As Integer = db.exectSQLQueryScalar($"SELECT ID FROM Ing_Cancelaciones WHERE Folio = '{Folio}' AND Activo = 1")
        If (idCancelacion > 0) Then
            Dim Res As Integer = MsgBox("El folio ingresado ya fue cancelado ¿Desea reimprimir el acuse de cancelación?", MsgBoxStyle.YesNo)
            If Res = 6 Then
                cf.obtenerxmlAcuse(txtFolio.Text)
                Exit Sub
            End If
        End If

        If (IDFolio < 1) Then
            MessageBox.Show("El folio ingresado no existe o ya esta cancelado, ingrese un folio válido")
            Me.Reiniciar()
            Exit Sub
        End If

        Matricula = db.exectSQLQueryScalar($"SELECT Matricula_Clave FROM ing_xmlTimbrados WHERE Folio = '{Folio}'")
        FechaFacturaStr = db.exectSQLQueryScalar($"SELECT Fecha_Pago FROM ing_xmlTimbrados WHERE Folio = '{Folio}'")
        year = FechaFacturaStr.Substring(0, 4)
        mes = FechaFacturaStr.Substring(5, 2)
        dia = FechaFacturaStr.Substring(8, 2)

        meshoy = Convert.ToInt32(DateTime.Now.Month)
        If (meshoy < 10) Then
            meshoy = $"0{meshoy}"
        End If
        diahoy = Convert.ToInt32(DateTime.Now.Day)
        If (diahoy < 10) Then
            diahoy = $"0{diahoy}"
        End If

        FechaFacturaStr = $"{dia}/{mes}/{year}"
        FechaHoy = $"{diahoy}/{meshoy}/{DateTime.Now.Year}"

        Tipo_Pago = db.exectSQLQueryScalar($"SELECT Tipo_Pago FROM ing_xmlTimbrados WHERE Folio = '{Folio}'")
        lblMatriculatxt.Text = Matricula
        lblFechaFacturaciontxt.Text = FechaHoy
        If (cbTipoCancelacion.SelectedIndex = 0 And (FechaFacturaStr <> FechaHoy)) Then
            MessageBox.Show("La factura seleccionada no fue emitida el dia de hoy, elija una factura que haya sido emitida el dia de hoy")
            Me.Reiniciar()
            Exit Sub
        ElseIf (cbTipoCancelacion.SelectedIndex = 1 And (FechaFacturaStr = FechaHoy)) Then
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
            Dim st As SelladoTimbradoService = New SelladoTimbradoService()
            Dim UUID As String = db.exectSQLQueryScalar($"SELECT FolioFiscal FROM ing_xmlTimbrados WHERE ID = {IDFolio}")
            Dim RFCReceptor As String = db.exectSQLQueryScalar($"SELECT RFCTimbrado FROM ing_xmlTimbrados WHERE ID = {IDFolio}")
            Dim xmlAcuse As String
            Dim mensajeCancelacion As String
            Dim estatusCancelacion As String
            Dim Total As String = db.exectSQLQueryScalar($"SELECT Total FROM ing_xmlTimbrados WHERE ID = {IDFolio}")

            If (System.Diagnostics.Debugger.IsAttached) Then
                Dim ListaUUID As New List(Of TimbradoUXPruebas.DetalleCFDICancelacion)
                Dim DatosUUID As New TimbradoUXPruebas.DetalleCFDICancelacion
                DatosUUID.UUID = "6E2B9B01-7E57-7E57-7E57-26818FAED065"
                DatosUUID.RFCReceptor = RFCReceptor
                DatosUUID.Total = Total
                DatosUUID.Motivo = cbMotivoSAT.SelectedValue


                ListaUUID.Add(DatosUUID)
                Dim resultado As String()

                ''resultado = st.TimbreCancelacionFacturasPrueba(ListaUUID)
                resultado = {"True", "AAAAAAAAAAA", "201   UUID Cancelado.   25F5CD94-8D50-4DE1-9742-C5B1FA2861E7   Cancelable sin aceptación", "Cancelable sin aceptación"}

                If (resultado(0) = "False") Then
                    BitacoraService.BitacoraCancelacionError(Matricula, Folio, cbMotivoSAT.SelectedValue, resultado(1), resultado(2))
                    MessageBox.Show(resultado(1))
                    Exit Sub
                Else
                    xmlAcuse = resultado(1)
                    mensajeCancelacion = resultado(2)
                    estatusCancelacion = resultado(3)
                End If
            Else
                Dim ListaUUID As New List(Of TimbradoUXReal.DetalleCFDICancelacion)
                Dim DatosUUID As New TimbradoUXReal.DetalleCFDICancelacion
                DatosUUID.UUID = UUID
                DatosUUID.RFCReceptor = RFCReceptor
                DatosUUID.Total = Total
                DatosUUID.Motivo = cbMotivoSAT.SelectedValue

                ListaUUID.Add(DatosUUID)
                Dim resultado As String()
                resultado = st.TimbreCancelacionFacturas(ListaUUID)
                If (resultado(0) = "False") Then
                    BitacoraService.BitacoraCancelacionError(Matricula, Folio, cbMotivoSAT.SelectedValue, resultado(1), resultado(2))
                    MessageBox.Show(resultado(1))
                    Exit Sub
                Else
                    xmlAcuse = resultado(1)
                    xmlAcuse = xmlAcuse.Replace("'", "''")
                    mensajeCancelacion = resultado(2)
                    estatusCancelacion = resultado(3)
                End If
            End If

            db.startTransaction()
            Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT ID, Clave_Concepto, IDConcepto FROM ing_xmlTimbradosConceptos WHERE XMLID = {IDFolio}")
            db.execSQLQueryWithoutParams($"INSERT INTO Ing_Cancelaciones(Folio, Matricula, TipoFactura, IDObservacion, FechaCancelacion, TipoCancelacion, xmlAcuse, mensajeCancelacion, estatusCancelacion, CanceladoSAT, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', '{Tipo_Pago}', {cbObservacionCancelaciones.SelectedValue}, GETDATE(), {cbTipoCancelacion.SelectedIndex}, '{xmlAcuse}', '{mensajeCancelacion}', '{estatusCancelacion}', 1, '{User.getUsername}', 1)")
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
            cf.obtenerxmlAcuse(txtFolio.Text.ToUpper())
            Me.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
        End Try
    End Sub

    Private Sub btnGuardarInterno_Click(sender As Object, e As EventArgs) Handles btnGuardarInterno.Click
        Try
            Dim tableConceptos As DataTable = db.getDataTableFromSQL($"SELECT ID, Clave_Concepto, IDConcepto FROM ing_xmlTimbradosConceptos WHERE XMLID = {IDFolio}")
            db.execSQLQueryWithoutParams($"INSERT INTO Ing_Cancelaciones(Folio, Matricula, TipoFactura, IDObservacion, FechaCancelacion, TipoCancelacion, xmlAcuse, mensajeCancelacion, estatusCancelacion, CanceladoSAT, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', '{Tipo_Pago}', {cbObservacionCancelaciones.SelectedValue}, GETDATE(), {cbTipoCancelacion.SelectedIndex}, 'NULL', 'NULL', 'NULL', 0, '{User.getUsername}', 1)")
            Dim query As String
            If (cbTipoCancelacion.SelectedIndex = 0) Then
                query = "CanceladaHoy = 1, CanceladaOtroDia = 0"
            ElseIf (cbTipoCancelacion.SelectedIndex = 1) Then
                query = "CanceladaHoy = 0, CanceladaOtroDia = 1"
            End If

            db.execSQLQueryWithoutParams($"UPDATE ing_xmlTimbrados SET {query} WHERE ID = {IDFolio}")
            cf.CancelarPagos(Matricula, IDFolio, Folio, tableConceptos)
            MessageBox.Show("Factura cancelada correctamente")
            Me.Reiniciar()
            Exit Sub
        Catch ex As Exception

        End Try
    End Sub

    Function getFechaDTPicker(dtpicker As DateTimePicker) As String
        Dim Fecha

        Fecha = $"{dtpicker.Value.Day}/{dtpicker.Value.Month}/{dtpicker.Value.Year}"

        Return Fecha
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Reiniciar()
    End Sub

    Private Sub btnReimprimir_Click(sender As Object, e As EventArgs) Handles btnReimprimir.Click
        Dim idCancelacion As Integer = db.exectSQLQueryScalar($"SELECT ID FROM Ing_Cancelaciones WHERE Folio = '{txtFolioReimpresion.Text}' AND Activo = 1")
        If (idCancelacion > 0) Then
            cf.obtenerxmlAcuse(txtFolioReimpresion.Text)
        Else
            MessageBox.Show("La factura ingresada no ha sido cancelada o no existe, ingrese un folio válido.")
            Exit Sub
        End If
    End Sub
End Class