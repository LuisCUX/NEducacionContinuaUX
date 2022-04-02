Public Class CancelacionFacturasController
    Dim db As DataBaseService = New DataBaseService

    Sub CancelarPagos(Matricula As String, IDXml As Integer, Folio As String, TableConceptos As DataTable)

        For Each concepto As DataRow In TableConceptos.Rows

            If (concepto("Clave_Concepto") = 1) Then ''POA PAGOS OPCIONALES ALUMNOS
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalAlumno SET Activo = 1, folioPago = NULL WHERE Matricula = '{Matricula}' AND ID = {concepto("IDConcepto")}")
            ElseIf (concepto("Clave_Concepto") = 2) Then ''POE PAGOS OPCIONALES EXTERNOS
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalExterno SET Activo = 1, folioPago = NULL WHERE MatriculaExterna = '{Matricula}' AND ID = {concepto("IDConcepto")}")
            ElseIf (concepto("Clave_Concepto") = 3) Then ''CON CONGRESOS
                db.execSQLQueryWithoutParams($"UPDATE ing_PagosCongresos SET Activo = 0 WHERE Matricula = '{Matricula}' AND Folio = '{Folio}'")
            ElseIf (concepto("Clave_Concepto") = 4) Then ''DCO COLEGIATURA DIPLOMADO
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1, Folio = NULL WHERE ID = {concepto("IDConcepto")}")
            ElseIf (concepto("Clave_Concepto") = 5) Then ''DPU PAGO UNICO DIPLOMADO
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1, Folio = NULL WHERE ID = {concepto("IDConcepto")}")
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 4")
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 6")
            ElseIf (concepto("Clave_Concepto") = 6) Then ''DIN INSCRIPCION DIPLOMADO
                db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 1, Folio = NULL WHERE ID = {concepto("IDConcepto")}")
            ElseIf (concepto("Clave_Concepto") = 7) Then ''REC RECARGO
                db.execSQLQueryWithoutParams($"UPDATE ing_PlanesRecargos SET Folio = NULL, Activo = 1 WHERE ID = {concepto("IDConcepto")}")
            End If
        Next

        Dim IDAbono As Integer = Me.buscarAbono(Folio)
        If (IDAbono > 0) Then
            db.execSQLQueryWithoutParams($"UPDATE ing_Abonos SET Activo = 0 WHERE ID = {IDAbono}")
        End If
    End Sub

    Function buscarAbono(Folio As String) As Integer
        Return db.exectSQLQueryScalar($"SELECT ID FROM ing_Abonos WHERE Folio = '{Folio}'")
    End Function
End Class