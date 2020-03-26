﻿Public Class CargosController
    Dim db As DataBaseService = New DataBaseService()

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------BUSCA PAGOS OPCIONALES----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarPagosOpcionales(Tree As TreeView, Matricula As String, TipoMatricula As String, Tipo As String)
        Dim tabla As String
        Dim MatriculaName As String
        Dim claveTipoPago As Integer
        If (TipoMatricula = "UX") Then
            tabla = "ing_AsignacionPagoOpcionalAlumno"
            MatriculaName = "Matricula"
            claveTipoPago = 1
        ElseIf (TipoMatricula = "EX") Then
            tabla = "ing_AsignacionPagoOpcionalExterno"
            claveTipoPago = 2
            MatriculaName = "MatriculaExterna"
        ElseIf (TipoMatricula = "EC") Then
            Return
        End If
        Dim tablePagosOpcionales As DataTable = db.getDataTableFromSQL($"SELECT A.ID, C.Clave, P.Descripcion, A.costoUnitario, A.Cantidad, P.considerarIVA, P.AgregaIVA, P.ExentaIVA FROM {tabla} AS A
                                                                        INNER JOIN ing_resPagoOpcionalAsignacion AS R ON R.ID = A.ID_resPagoOpcionalAsignacion
                                                                        INNER JOIN ing_PagosOpcionales AS P ON P.ID = R.ID_PagoOpcional
                                                                        INNER JOIN ing_CatClavesPagos AS C ON C.ID = {claveTipoPago}
                                                                        WHERE A.{MatriculaName} = '{Matricula}' AND A.Activo = 1")
        For Each item As DataRow In tablePagosOpcionales.Rows
            Dim result As String = $"[{item("ID")}]|{item("Clave")}|{item("Descripcion")}|{item("costoUnitario")}|{item("Cantidad")}|Total: {Me.calcularTotal(item("costoUnitario"), item("Cantidad"), item("considerarIVA"), item("AgregaIVA"), item("exentaIVA"))}"
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
        Dim Costo As Decimal
        If (TipoMatricula <> "EC") Then
            Return
        End If
        Dim tablePagosOpcionales As DataTable = db.getDataTableFromSQL($"SELECT C.id_cliente, CP.Clave, GETDATE() AS FechaHoy, CON.nombre, CO.fecha_limite, CO.costo_antes, CO.costo_despues, 1 As Cantidad, 1 As considerarIVA, 0 As AgregaIVA, 0 As exentaIVA FROM portal_registroCongreso AS RC
                                                                         INNER JOIN portal_cliente AS C ON C.id_cliente = RC.id_cliente
                                                                         INNER JOIN portal_tipoAsistente AS TA ON TA.id_tipo_asistente = RC.id_tipo_asistente
                                                                         INNER JOIN portal_congreso AS CON ON CON.id_congreso = TA.id_congreso
                                                                         INNER JOIN portal_costo AS CO ON CO.id_tipo_asistente = TA.id_tipo_asistente
                                                                         INNER JOIN ing_CatClavesPagos AS CP ON CP.ID = 3
                                                                         WHERE RC.clave_cliente = '{Matricula}' AND RC.clave_cliente NOT IN (SELECT Matricula FROM ing_PagosCongresos)")
        For Each item As DataRow In tablePagosOpcionales.Rows
            If (item("FechaHoy") > item("fecha_limite")) Then
                Costo = item("costo_despues")
            Else
                Costo = item("costo_antes")
            End If
            Dim result As String = $"[{item("id_cliente")}]|{item("Clave")}|{item("nombre")}|{Costo}|{item("Cantidad")}|Total: {Me.calcularTotal(Costo, item("Cantidad"), item("considerarIVA"), item("AgregaIVA"), item("exentaIVA"))}"
            If (Tipo = "Cobros") Then
                Tree.Nodes(1).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(1).Expand()
            ElseIf (Tipo = "AutCon") Then
                Tree.Nodes(0).Nodes(0).Nodes.Add(result).StateImageIndex = 0
                Tree.Nodes(0).Nodes(0).Expand()
            End If
        Next
    End Sub

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
        End If

        Return Format(CDec(total), "#####0.00")
    End Function
End Class
