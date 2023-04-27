Public Class AutorizacionCondonacionController
    Dim db As DataBaseService = New DataBaseService()
    Dim ca As CargosController = New CargosController()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()

    ''----------LLENA COMBOBOX DE LA VENTANA----------''
    Sub llenarComboboxes(cbTipoCondonacion As ComboBox)
        cbTipoCondonacion.Items.Clear()
        cbTipoCondonacion.Items.Add("CONDONACIÓN TOTAL")
        cbTipoCondonacion.Items.Add("CONDONACIÓN PARCIAL")
        cbTipoCondonacion.SelectedValue = -1
    End Sub
    ''-----------------------------------------------------------------------------------------------------''
    ''----------ACTUALIZA ARBOL DE PESTAÑA DE CONDONACION CUANDO SE CAMBIA EL VALOR DEL COMOBOBOX----------''
    ''-----------------------------------------------------------------------------------------------------''
    Sub ActualizarArbolCondonacion(TreeCondonacion As TreeView, tipoCondonacion As String, Matricula As String, tipoMatricula As String)
        TreeCondonacion.Nodes.Clear()
        Dim ID As Integer
        If (tipoCondonacion = "CONDONACIÓN TOTAL") Then
            TreeCondonacion.Nodes.Add("Congresos").StateImageIndex = 2
            TreeCondonacion.Nodes.Add("Pagos Opcionales").StateImageIndex = 2
            TreeCondonacion.Nodes.Add("Inscripción").StateImageIndex = 2
            TreeCondonacion.Nodes.Add("Colegiaturas").StateImageIndex = 2
            TreeCondonacion.Nodes.Add("Pago Unico").StateImageIndex = 2
            TreeCondonacion.Nodes.Add("Recargos").StateImageIndex = 2
        ElseIf (tipoCondonacion = "CONDONACIÓN PARCIAL") Then
            TreeCondonacion.Nodes.Add("Pagos Opcionales").StateImageIndex = 2
        End If

        If (tipoCondonacion = "CONDONACIÓN TOTAL") Then
            ca.buscarCongresos(TreeCondonacion, Matricula, tipoMatricula, "ConTotal")
            ca.buscarPagosOpcionales(TreeCondonacion, Matricula, tipoMatricula, "ConTotal")
            ca.buscarInscripcionesDiplomados(TreeCondonacion, Matricula, tipoMatricula, "ConTotal")
            ca.buscarColegiaturas(TreeCondonacion, Matricula, tipoMatricula, "ConTotal")
            ca.buscarPagoUnicoDiplomados(TreeCondonacion, Matricula, tipoMatricula, "ConTotal")
            ca.buscarRecargosDiplomados(TreeCondonacion, Matricula, tipoMatricula, "ConTotal")
        ElseIf (tipoCondonacion = "CONDONACIÓN PARCIAL") Then
            ca.buscarPagosOpcionales(TreeCondonacion, Matricula, tipoMatricula, "ConParcial")
        End If
    End Sub

    Sub ActualizarArbolAutorizacionCaja(TreeAutorizacionCaja As TreeView, Matricula As String, tipoMatricula As String)
        TreeAutorizacionCaja.Nodes.Clear()
        Dim tableAutorizacionesCaja As DataTable = db.getDataTableFromSQL($"SELECT C.ID, C.Nombre FROM aut_Cat_Claves AS C
                                                                              INNER JOIN aut_res_AutClaves AS R ON R.ID_Clave = C.ID
                                                                              INNER JOIN aut_Cat_Autorizaciones AS A ON A.ID = R.ID_Autorizacion
                                                                              INNER JOIN aut_Cat_TipoAutorizacion AS T ON T.ID = A.ID_TipoAutorizacion AND T.ID = 1")
        For Each item As DataRow In tableAutorizacionesCaja.Rows
            TreeAutorizacionCaja.Nodes.Add(item("Nombre")).StateImageIndex = 2
        Next

        For Each item As TreeNode In TreeAutorizacionCaja.Nodes
            Dim tableItem As DataTable = db.getDataTableFromSQL($"SELECT A.Nombre FROM aut_Cat_Autorizaciones AS A
                                                                  INNER JOIN aut_res_AutClaves AS R ON R.ID_Autorizacion = A.ID
                                                                  INNER JOIN aut_Cat_Claves as C ON C.ID = R.ID_Clave
                                                                  WHERE A.ID_TipoAutorizacion = 1 AND C.Nombre = '{item.Text}'")
            For Each row As DataRow In tableItem.Rows
                TreeAutorizacionCaja.Nodes(0).Nodes.Add(row("Nombre")).StateImageIndex = 2
            Next
        Next
        ca.buscarColegiaturasConRecargosDiplomados(TreeAutorizacionCaja, Matricula, tipoMatricula, "AutCaja")
    End Sub

    ''-----------------------------------------------------------------------------------------------------''
    ''---------------------------------------GUARDA CONDONACIONES------------------------------------------''
    ''-----------------------------------------------------------------------------------------------------''
    Sub GuardarCondonaciones(Matricula As String, GridCondonaciones As DataGridView, TipoCondonacion As Integer, observacionID As Integer)

        Try
            db.startTransaction()
            For X = 0 To GridCondonaciones.Rows.Count() - 1
                Dim IDPago As Integer = Convert.ToInt32(Me.Extrae_Cadena(GridCondonaciones.Rows(X).Cells(0).Value, "[", "]"))
                Dim IDConcepto As Integer = GridCondonaciones.Rows(X).Cells(2).Value
                Dim claveConcepto As String = db.exectSQLQueryScalar($"SELECT Clave FROM ing_CatClavesPagos WHERE ID = {IDConcepto}")
                If (TipoCondonacion = 0) Then ''Total
                    Dim Folio As String = Me.ObtenerFolioAC("CONTOTAL")
                    db.execSQLQueryWithoutParams($"INSERT INTO aut_Condonaciones(Folio, Fecha_Condonacion, Matricula, Usuario, ID_Concepto, ID_ClaveConcepto, ID_TipoConAut, Descripcion, Porcentaje, Observaciones, Activo) VALUES ('{Folio}', GETDATE(), '{Matricula}', '{User.getUsername}', {IDPago}, {IDConcepto}, 1, '{GridCondonaciones.Rows(X).Cells(0).Value}', 100, {observacionID}, 1)")
                    db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalExterno SET Activo = 0, Condonado = 1 WHERE ID = {IDPago}")
                    db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Descripcion = 'CONTOTAL'")
                ElseIf (TipoCondonacion = 1) Then ''Parcial
                    Dim Folio As String = Me.ObtenerFolioAC("CONPORCENTUAL")
                    Dim NuevoTotal As Decimal = GridCondonaciones.Rows(X).Cells(3).Value

                    db.execSQLQueryWithoutParams($"INSERT INTO aut_Condonaciones(Folio, Fecha_Condonacion, Matricula, Usuario, ID_Concepto, ID_ClaveConcepto, ID_TipoConAut, Descripcion, Porcentaje, Observaciones, Activo) VALUES ('{Folio}', GETDATE(), '{Matricula}', '{User.getUsername}', {IDPago}, {IDConcepto}, 2, '{GridCondonaciones.Rows(X).Cells(0).Value}', '{GridCondonaciones.Rows(X).Cells(1).Value}', {observacionID}, 1)")
                    db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalExterno SET costoUnitario = {GridCondonaciones.Rows(X).Cells(3).Value} WHERE ID = {IDPago}")
                    db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Descripcion = 'CONPORCENTUAL'")
                End If
            Next
            MessageBox.Show("Pagos condonados correctamente")
            db.commitTransaction()
            AutorizacionCondonacionEDC.Reiniciar()
        Catch ex As Exception
            db.rollBackTransaction()
        End Try
    End Sub

    Sub GuardarAutorizacionesCaja(Matricula As String, GridAutorizacionCaja As DataGridView)
        'For X = 0 To GridAutorizacionCaja.Rows.Count() - 1
        '    Try
        '        db.startTransaction()
        '        Dim Folio As String = Me.ObtenerFolioAC()
        '        Dim IDPago As Integer = Convert.ToInt32(Me.Extrae_Cadena(GridAutorizacionCaja.Rows(X).Cells(1).Value, "[", "]"))
        '        Dim IDConcepto As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatClavesPagos WHERE CLAVE = '{Me.Extrae_Cadena(GridAutorizacionCaja.Rows(X).Cells(1).Value, "(", ")")}'")
        '        Dim claveConcepto As String = db.exectSQLQueryScalar($"SELECT Clave FROM ing_CatClavesPagos WHERE ID = {IDConcepto}")
        '        db.execSQLQueryWithoutParams($"INSERT INTO aut_Autorizaciones(Folio, Fecha_Autorizacion, Matricula, ID_Concepto, ID_ClaveConcepto, ID_res_AutClaves, Descripcion, Observaciones, Usuario, Activo) VALUES ('{Folio}', GETDATE(), '{Matricula}', {IDPago}, {IDConcepto}, {GridAutorizacionCaja.Rows(X).Cells(0).Value}, '{GridAutorizacionCaja.Rows(X).Cells(1).Value}', 'N/A', '{User.getUsername()}', 1)")

        '        db.execSQLQueryWithoutParams($"UPDATE ing_catFolios SET Consecutivo = Consecutivo + 1 WHERE Descripcion = 'AC' AND Usuario = '{User.getUsername()}'")
        '        db.commitTransaction()

        '        If (IDConcepto = 4) Then
        '            db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Autorizado = 1 WHERE ID = {IDPago}")
        '        End If

        '        MessageBox.Show("Conceptos autorizados exitosamente")
        '        AutorizacionCondonacionEDC.Reiniciar()
        '    Catch ex As Exception
        '        db.rollBackTransaction()
        '    End Try
        'Next
    End Sub

    ''----------OBTENER ID RESULTANTE CLAVE AUTORIZACION----------
    Function ObtenerIDResAutCon(TipoAutorizacion As Integer, NombreAutorizacion As String, NombreClave As String) As Integer
        Dim id_Res As Integer = db.exectSQLQueryScalar($"SELECT R.ID FROM aut_res_AutClaves AS R 
                                 INNER JOIN aut_Cat_Autorizaciones AS A ON A.ID_TipoAutorizacion = {TipoAutorizacion} AND A.Nombre = '{NombreAutorizacion}'
                                 INNER JOIN aut_Cat_Claves AS C ON C.Nombre = '{NombreClave}'
                                 WHERE R.ID_Autorizacion = A.ID AND R.ID_Clave = C.ID")
        Return id_Res
    End Function


    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''---------------------------------------------------EXTRAE CADENA ENTRE 2 CARACTERES-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Public Function Extrae_Cadena(ByVal texto As String, ByVal limite_inicio As String, ByVal limite_fin As String)
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        Dim referencias_nodo As String = ""
        posicion1 = InStr(texto, limite_inicio)
        posicion2 = InStrRev(texto, limite_fin)
        referencias_nodo = texto.Substring(posicion1, posicion2 - 1 - posicion1)
        Return referencias_nodo
    End Function


    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------OBTIENE FOLIO DE PAGO-----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Function ObtenerFolioAC(tipo As String)
        Dim Serie As String = db.exectSQLQueryScalar($"SELECT Folio FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}' AND Descripcion = '{tipo}'")
        Dim Consecutivo As Integer = db.exectSQLQueryScalar($"SELECT Consecutivo + 1 FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}' AND Descripcion = '{tipo}'")
        Dim ConsecutivoStr As String
        If (Consecutivo > 0 And Consecutivo < 10) Then
            ConsecutivoStr = $"00000{Consecutivo}"
        ElseIf (Consecutivo >= 10 And Consecutivo < 100) Then
            ConsecutivoStr = $"0000{Consecutivo}"
        ElseIf (Consecutivo >= 100 And Consecutivo < 1000) Then
            ConsecutivoStr = $"000{Consecutivo}"
        ElseIf (Consecutivo >= 1000 And Consecutivo < 10000) Then
            ConsecutivoStr = $"000{Consecutivo}"
        ElseIf (Consecutivo >= 10000 And Consecutivo < 100000) Then
            ConsecutivoStr = $"00{Consecutivo}"
        ElseIf (Consecutivo >= 100000 And Consecutivo < 1000000) Then
            ConsecutivoStr = $"0{Consecutivo}"
        ElseIf (Consecutivo >= 1000000 And Consecutivo < 10000000) Then
            ConsecutivoStr = $"{Consecutivo}"
        End If

        Return $"{Serie}{ConsecutivoStr}"
    End Function

    Function obtenerCostoIVA(Matricula As String) As Decimal()
        Dim tableCostos As DataTable = db.getDataTableFromSQL($"SELECT costo_total, iva, descuento FROM portal_subtotales WHERE clave_cliente = '{Matricula}'")
        Dim costototal As Decimal
        Dim iva As Decimal
        Dim descuento As Decimal
        For Each item As DataRow In tableCostos.Rows
            costototal = item("costo_total")
            iva = item("iva")
            descuento = item("descuento")
        Next

        Return {costototal, iva, descuento}
    End Function

    Function obtenerClavePago(TipoPago As String) As Integer
        If (TipoPago = "Congresos") Then
            Return 3
        ElseIf (TipoPago = "Pagos Opcionales") Then
            Return 2
        ElseIf (TipoPago = "Inscripción") Then
            Return 6
        ElseIf (TipoPago = "Colegiaturas") Then
            Return 4
        ElseIf (TipoPago = "Pago Unico") Then
            Return 5
        ElseIf (TipoPago = "Recargos") Then
            Return 7
        End If
        Return 0
    End Function

    Sub eliminarCondonados(tree As TreeView)

    End Sub
End Class
