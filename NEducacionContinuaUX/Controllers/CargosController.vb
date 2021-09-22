Public Class CargosController
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------BUSCA PAGOS OPCIONALES----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarPagosOpcionales(Tree As TreeView, Matricula As String, TipoMatricula As String, Tipo As String)
        Dim tabla As String
        Dim MatriculaName As String
        Dim claveTipoPago As Integer
        Dim claveString As String
        If (TipoMatricula = "UX") Then
            tabla = "ing_AsignacionPagoOpcionalAlumno"
            MatriculaName = "Matricula"
            claveTipoPago = 1
            claveString = "POA"
        ElseIf (TipoMatricula = "EX") Then
            tabla = "ing_AsignacionPagoOpcionalExterno"
            claveTipoPago = 2
            MatriculaName = "MatriculaExterna"
            claveString = "POE"
        ElseIf (TipoMatricula = "EC") Then
            Return
        End If
        Dim tablePagosOpcionales As DataTable = db.getDataTableFromSQL($"SELECT A.ID, C.Clave, P.Descripcion, A.costoUnitario, A.Cantidad, P.considerarIVA, P.AgregaIVA, P.ExentaIVA FROM {tabla} AS A
                                                                        INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                                        INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                                        INNER JOIN ing_CatClavesPagos AS C ON C.ID = {claveTipoPago}
                                                                        WHERE A.{MatriculaName} = '{Matricula}' AND A.Activo = 1")
        For Each item As DataRow In tablePagosOpcionales.Rows
            Dim concepto As New Concepto
            concepto = ch.crearConcepto(item("ID"), claveString, Matricula)
            Dim result = Me.generaTexto(concepto, claveTipoPago)
            'Dim result As String = $"[{item("ID")}]|({item("Clave")})|{item("Descripcion")}|{item("costoUnitario")}|{item("Cantidad")}|Total: {Me.calcularTotal(item("costoUnitario"), item("Cantidad"), item("considerarIVA"), item("AgregaIVA"), item("exentaIVA"))}"
            'Dim IDCondonacion As Integer = db.exectSQLQueryScalar($"SELECT ID FROM aut_Condonaciones WHERE ID_ClaveConcepto = {claveTipoPago} AND ID_Concepto = {item("ID")}")
            'If (IDCondonacion > 0) Then
            '    Dim porcentaje As Decimal = db.exectSQLQueryScalar($"SELECT Porcentaje FROM aut_Condonaciones WHERE ID = {IDCondonacion}")
            '    result = result + $"|Condonacion {porcentaje}%"
            'End If
            'Dim abonostring As String = Me.buscarAbonoConcepto(item("ID"), claveTipoPago, Matricula)
            'If (abonostring <> "-") Then
            '    result = result + $"{abonostring}"
            'End If
            If (Tipo = "Cobros") Then
                Tree.Nodes(1).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(1).Expand()
            ElseIf (Tipo = "AutCon") Then
                Tree.Nodes(0).Nodes(0).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(0).Nodes(0).Expand()
            End If
        Next
        Tree.Nodes(0).Expand()
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------BUSCA CONGRESOS----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarCongresos(Tree As TreeView, Matricula As String, TipoMatricula As String, Tipo As String)
        If (TipoMatricula <> "EC") Then
            Return
        End If
        Dim tablePagosOpcionales As DataTable = db.getDataTableFromSQL($"SELECT RC.id_registro, CP.Clave, SUB.costo_total, SUB.descuento, CON.nombre, 1 As Cantidad, 1 As considerarIVA, 0 As AgregaIVA, 0 As exentaIVA FROM portal_registroCongreso AS RC
                                                                         INNER JOIN portal_cliente AS C ON C.id_cliente = RC.id_cliente
                                                                         INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                                         INNER JOIN portal_congreso AS CON ON CON.id_congreso = TA.id_congreso
                                                                         INNER JOIN portal_subtotales AS SUB ON SUB.clave_cliente = RC.clave_cliente
                                                                         INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = 3
                                                                         WHERE RC.clave_cliente = '{Matricula}' AND CON.id_tipo_evento = 2 AND RC.clave_cliente NOT IN (SELECT Matricula FROM ing_PagosCongresos)")
        For Each item As DataRow In tablePagosOpcionales.Rows
            Dim concepto As New Concepto
            concepto = ch.crearConcepto(item("id_registro"), "CON", Matricula)
            Dim result = Me.generaTexto(concepto, 3)
            'Dim result As String = $"[{item("id_registro")}]|({item("Clave")})|{item("nombre")}|{item("costo_total")}|{item("Cantidad")}|Total: {Me.calcularTotal(item("costo_total"), item("Cantidad"), item("considerarIVA"), item("AgregaIVA"), item("exentaIVA"))}"
            'Dim IDCondonacion As Integer = db.exectSQLQueryScalar($"SELECT ID FROM aut_Condonaciones WHERE ID_ClaveConcepto = 3 AND ID_Concepto = {item("id_registro")}")
            'If (IDCondonacion > 0) Then
            '    If (Tipo = "ConTotal") Then
            '        Continue For
            '    End If
            '    Dim porcentaje As Decimal = db.exectSQLQueryScalar($"SELECT Porcentaje FROM aut_Condonaciones WHERE ID = {IDCondonacion}")
            '    result = result + $"|Condonacion {porcentaje}%"
            'End If
            'Dim abonostring As String = Me.buscarAbonoConcepto(item("id_registro"), 3, Matricula)
            'If (abonostring <> "-") Then
            '    result = result + $"{abonostring}"
            'End If
            If (Tipo = "Cobros") Then
                Tree.Nodes(0).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(0).Expand()
            ElseIf (Tipo = "ConTotal") Then
                Tree.Nodes(0).Nodes(0).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(0).Nodes(0).Expand()
            End If
        Next
    End Sub

    Sub buscarInscripcionesDiplomados(Tree As TreeView, Matricula As String, TipoMatricula As String, Tipo As String)
        Dim tableInscripciones As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, C.Importe, CP.Clave, AC.Descuento, C.Fecha_Limite_Desc FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = 6
                                                                      WHERE AC.Matricula = '{Matricula}' AND C.Clave = 'P00' AND AC.Activo = 1")
        Dim descuento As String
        For Each item As DataRow In tableInscripciones.Rows
            Dim concepto As New Concepto
               concepto = ch.crearConcepto(item("ID"), "DIN", Matricula)
            Dim result = Me.generaTexto(concepto, 6)
            'If (item("Fecha_Limite_Desc") < Date.Today) Then
            '    descuento = Format(CDec(0.00), "#####0.00")
            'Else
            '    descuento = Format(CDec(item("Descuento")), "#####0.00")
            'End If
            'Dim result As String = $"[{item("ID")}]|({item("Clave")})|{item("Descripcion")}|{item("Importe")}|{1}|DESCUENTO: {descuento}|Total: {Me.calcularTotal(item("Importe"), 1, True, False, False)}"
            'Dim abonostring As String = Me.buscarAbonoConcepto(item("ID"), 6, Matricula)
            'If (abonostring <> "-") Then
            '    result = result + $"{abonostring}"
            'End If
            If (Tipo = "Cobros") Then
                Tree.Nodes(2).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(2).Expand()
            End If
        Next
    End Sub

    Sub buscarColegiaturas(Tree As TreeView, Matricula As String, TipoMatricula As String, Tipo As String)
        Dim tableColegiaturas As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, C.Importe, CP.Clave, AC.Descuento, C.Fecha_Limite_Desc FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = 4
                                                                      WHERE AC.Matricula = '{Matricula}' AND C.Clave != 'P00' AND C.Clave != 'P13' AND AC.Activo = 1")
        Dim descuento As String
        For Each item As DataRow In tableColegiaturas.Rows
            Dim concepto As New Concepto
            concepto = ch.crearConcepto(item("ID"), "DCO", Matricula)
            Dim result = Me.generaTexto(concepto, 4)
            'If (item("Fecha_Limite_Desc") < Date.Today) Then
            '    descuento = Format(CDec(0.00), "#####0.00")
            'Else
            '    descuento = Format(CDec(item("Descuento")), "#####0.00")
            'End If
            'Dim result As String = $"[{item("ID")}]|({item("Clave")})|{item("Descripcion")}|{item("Importe")}|{1}|DESCUENTO: {descuento}|Total: {Me.calcularTotal(item("Importe"), 1, True, False, False)}"
            'Dim abonostring As String = Me.buscarAbonoConcepto(item("ID"), 4, Matricula)
            'If (abonostring <> "-") Then
            '    result = result + $"{abonostring}"
            'End If
            If (Tipo = "Cobros") Then
                Tree.Nodes(3).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(3).Expand()
            End If
        Next
    End Sub

    Sub buscarPagoUnicoDiplomados(Tree As TreeView, Matricula As String, TipoMatricula As String, Tipo As String)
        Dim tablePagoUnico As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, C.Importe, CP.Clave, C.Fecha_Limite_Pago, AC.Descuento, C.Fecha_Limite_Desc FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = 5
                                                                      WHERE AC.Matricula = '{Matricula}' AND C.Clave = 'P13' AND AC.Activo = 1")
        Dim descuento As String
        For Each item As DataRow In tablePagoUnico.Rows
            'If (item("Fecha_Limite_Desc") < Date.Today) Then
            '    descuento = Format(CDec(0.00), "#####0.00")
            'Else
            '    descuento = Format(CDec(item("Descuento")), "#####0.00")
            'End If
            If (item("Fecha_Limite_Pago") >= Date.Today) Then
                Dim concepto As New Concepto
                concepto = ch.crearConcepto(item("ID"), "DPU", Matricula)
                Dim result = Me.generaTexto(concepto, 5)
                'Dim result As String = $"[{item("ID")}]|({item("Clave")})|{item("Descripcion")}|{item("Importe")}|{1}|DESCUENTO: {descuento}|Total: {Me.calcularTotal(item("Importe"), 1, False, False, False)}"
                'Dim abonostring As String = Me.buscarAbonoConcepto(item("ID"), 5, Matricula)
                'If (abonostring <> "-") Then
                '    result = result + $"{abonostring}"
                'End If
                If (Tipo = "Cobros") Then
                    Tree.Nodes(4).Nodes.Add(result).StateImageIndex = 0
                    Tree.Nodes(4).Expand()
                End If
            Else

            End If
        Next
    End Sub

    Sub buscarRecargosDiplomados(Tree As TreeView, Matricula As String, TipoMatricula As String, Tipo As String)
        Dim query As String = ""
        If (Tipo <> "Cobros") Then
            query = "AND P.Autorizado = 0 AND P.Condonado = 0"
        End If
        Dim tableRecargos As DataTable = db.getDataTableFromSQL($"SELECT P.ID, P.Descripcion, P.Monto, C.Clave FROM ing_PlanesRecargos AS P
                                                                  INNER JOIN ing_CatClavesPagos AS C ON C.ID = 7
                                                                  WHERE P.Matricula = '{Matricula}' AND Activo = 1 {query}")
        For Each item As DataRow In tableRecargos.Rows
            Dim concepto As New Concepto
            concepto = ch.crearConcepto(item("ID"), "REC", Matricula)
            Dim result = Me.generaTexto(concepto, 7)
            'Dim result As String = $"[{item("ID")}]|({item("Clave")})|{item("Descripcion")}|{item("Monto")}|{1}|Total: {Me.calcularTotal(item("Monto"), 1, True, False, False)}"
            'Dim condonacion As Object() = ch.obtenerDatosCondonacion(item("ID"), 7)
            'If (condonacion(0) > 0) Then
            '    result = $"{result}|Condonación {Convert.ToInt32(condonacion(1))}%"
            'End If
            'Dim abonostring As String = Me.buscarAbonoConcepto(item("ID"), 7, Matricula)
            'If (abonostring <> "-") Then
            '    result = result + $"{abonostring}"
            'End If
            If (Tipo = "Cobros") Then
                Tree.Nodes(5).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(5).Expand()
            ElseIf (Tipo = "ConParcial") Then
                Tree.Nodes(0).Nodes(0).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(0).Nodes(0).Expand()
            End If
        Next
    End Sub

    Sub buscarColegiaturasConRecargosDiplomados(Tree As TreeView, Matricula As String, TipoMatricula As String, Tipo As String)
        Dim query As String = ""
        If (Tipo <> "Cobros") Then
            query = "AND AC.Autorizado = 0 AND AC.Condonado = 0"
        End If
        Dim tableRecargos As DataTable = db.getDataTableFromSQL($"SELECT AC.ID, C.Descripcion, C.Importe, CP.Clave FROM ing_AsignacionCargosPlanes AS AC 
                                                                      INNER JOIN ing_PlanesConceptos AS C ON C.ID = AC.ID_Concepto
                                                                      INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = 4
                                                                      INNER JOIN ing_PlanesRecargos AS R ON R.ID_Concepto = AC.ID
                                                                      WHERE AC.Matricula = '{Matricula}' AND C.Clave != 'P00' AND C.Clave != 'P13' AND AC.Activo = 1 {query}")
        For Each item As DataRow In tableRecargos.Rows
            Dim result As String = $"[{item("ID")}]|({item("Clave")})|{item("Descripcion")}|{item("Importe")}|{1}|Total: {Me.calcularTotal(item("Importe"), 1, True, False, False)}"
            If (Tipo = "AutCaja") Then
                Tree.Nodes(0).Nodes(0).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(0).Nodes(0).Expand()
            End If
        Next
    End Sub

    ''------------------------------GENERA TEXTO PARA VENTANA COBROS------------------------------''

    Function generaTexto(concepto As Concepto, claveConcepto As Integer) As String
        Dim result As String
        result = $"[{concepto.IDConcepto}]|{concepto.NombreConcepto}|Precio: ${Format(CDec(concepto.costoUnitario), "#####0.00")}|Cantidad: {concepto.Cantidad}|Descuento: ${concepto.descuento}|"

        Dim IDCondonacion As Integer = db.exectSQLQueryScalar($"SELECT ID FROM aut_Condonaciones WHERE ID_ClaveConcepto = {claveConcepto} AND ID_Concepto = {concepto.IDConcepto}")
        If (IDCondonacion > 0) Then
            Dim porcentaje As Decimal = db.exectSQLQueryScalar($"SELECT Porcentaje FROM aut_Condonaciones WHERE ID = {IDCondonacion}")
            result = result + $"Condonacion {porcentaje}%|"
        End If

        If (concepto.Abono > 0) Then
            result = result + $"Abono: ${Format(CDec(concepto.Abono), "#####0.00")}|"
        End If

        result = result + $"TOTAL: ${concepto.costoFinal}"

        Return result
    End Function

    Function buscarAbonoConcepto(IDConcepto As Integer, claveConcepto As Integer, Matricula As String) As String
        Dim cantidad = db.exectSQLQueryScalar($"SELECT Sum(Cantidad_Abonada) FROM ing_Abonos WHERE Clave_Cliente = '{Matricula}' AND IDPago = {IDConcepto} AND ID_ClavePago = {claveConcepto}")
        If (IsDBNull(cantidad)) Then
            Return "-"
        Else
            Dim abonostring As String = $"|Abono ${Format(CDec(cantidad), "#####0.00")}"
            Return abonostring
        End If
    End Function

    Function calcularTotal(costoUnitario As Decimal, cantidad As Integer, consideraIVA As Boolean, agregaIVA As Boolean, exentaIVA As Boolean) As String
        Dim total As Decimal
        Dim IVA As Decimal
        Dim costosiniva As Decimal

        If (consideraIVA = True And agregaIVA = False And exentaIVA = False) Then
            total = costoUnitario * cantidad
        ElseIf (consideraIVA = False And agregaIVA = True And exentaIVA = False) Then
            IVA = costoUnitario * 0.16
            total = (costoUnitario + IVA) * cantidad
        ElseIf (consideraIVA = False And agregaIVA = False And exentaIVA = True) Then
            total = costoUnitario * cantidad
        ElseIf (consideraIVA = False And agregaIVA = False And exentaIVA = False) Then
            total = costoUnitario * cantidad
        End If

        Return Format(CDec(total), "#####0.00")
    End Function
End Class
