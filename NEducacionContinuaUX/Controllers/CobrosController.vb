Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions

Public Class CobrosController
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim xml As XmlService = New XmlService()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()


    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA PAGO OPCIONAL DE ALUMNO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarPagoOpcionalAlumno(concepto As Concepto, Matricula As String, Folio As String)
        Dim ID_ResAsignacion As Integer = db.exectSQLQueryScalar($"SELECT ID_resPagoOpcionalAsignacion FROM ing_AsignacionPagoOpcionalAlumno WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalAlumno SET folioPago = '{Folio}', Activo = 0 WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_resPagoOpcionalAsignacion SET Activo = 0 WHERE ID = {ID_ResAsignacion}")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA PAGO OPCIONAL DE EXTERNO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarPagoOpcionalExterno(concepto As Concepto, Matricula As String, Folio As String)
        Dim ID_ResAsignacion As Integer = db.exectSQLQueryScalar($"SELECT ID_resPagoOpcionalAsignacion FROM ing_AsignacionPagoOpcionalExterno WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionPagoOpcionalExterno SET folioPago = '{Folio}', Activo = 0 WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_resPagoOpcionalAsignacion SET Activo = 0 WHERE ID = {ID_ResAsignacion}")
    End Sub


    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA PAGO OPCIONAL DE EXTERNO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarCongreso(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        Dim formaPagoint As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosCongresos(Folio, Matricula, valorUnitario, Cantidad, valorIVA, Descuento, ID_FormaPago, Fecha_Pago, Autorizado, Condonado, Usuario) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {concepto.Cantidad}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, GETDATE(), 0, 0, '{User.getUsername()}')")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA INSCRIPCION DE DIPLOMADO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarInscripcionDiplomado(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        Dim formaPagoint As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDiplomados(Folio, Matricula, valorUnitario, valorIVA, Descuento, ID_FormaPago, ID_ClavePago, Fecha_Pago, Autorizado, Condonado, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, 6, GETDATE(), 0, 0, '{User.getUsername()}', 1)")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE ID = {concepto.IDConcepto}")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA COLEGIATURA DE DIPLOMADO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarColegiaturaDiplomado(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        Dim formaPagoint As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDiplomados(Folio, Matricula, valorUnitario, Cantidad, Descuento, ID_FormaPago, ID_ClavePago, Fecha_Pago, Autorizado, Condonado, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, 4, GETDATE(), 0, 0, '{User.getUsername()}', 1)")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE ID = {concepto.IDConcepto}")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA PAGO UNICO DE DIPLOMADO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarPagoUnicoDiplomado(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        Dim formaPagoint As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDiplomados(Folio, Matricula, valorUnitario, Cantidad, Descuento, ID_FormaPago, ID_ClavePago, Fecha_Pago, Autorizado, Condonado, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, 5, GETDATE(), 0, 0, '{User.getUsername()}', 1)")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE ID = {concepto.IDConcepto}")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''---------------------------------------------------------COBRA PAGO YA VALIDADO---------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub Cobrar(listaConceptos As List(Of Concepto), formaPago As String, Matricula As String)
        Dim folioPago As String = Me.obtenerFolio()
        Try
            'db.startTransaction()
            For Each concepto As Concepto In listaConceptos
                If (concepto.claveConcepto = "POA") Then
                    Me.cobrarPagoOpcionalAlumno(concepto, Matricula, folioPago)
                ElseIf (concepto.claveConcepto = "POE") Then
                    Me.cobrarPagoOpcionalExterno(concepto, Matricula, folioPago)
                ElseIf (concepto.claveConcepto = "CON") Then
                    Me.cobrarCongreso(concepto, Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "COL") Then
                    Me.cobrarColegiaturaDiplomado(concepto, Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "COLIN") Then
                    Me.cobrarInscripcionDiplomado(concepto, Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "COLPU") Then
                    Me.cobrarPagoUnicoDiplomado(concepto, Matricula, folioPago, formaPago)
                End If
            Next

            Dim Certificado As String = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
            Dim NoCertificado As String = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()

            Dim subtotalSuma As Decimal
            For Each concepto As Concepto In listaConceptos
                subtotalSuma = subtotalSuma + CDec(concepto.costoTotal)
            Next
            Dim SubTotal As String = subtotalSuma.ToString()

            Dim totalSuma As Decimal
            For Each concepto As Concepto In listaConceptos
                totalSuma = totalSuma + CDec(concepto.costoFinal)
            Next
            Dim Total As String = totalSuma.ToString()
            Dim totalIVASuma As Decimal
            For Each concepto As Concepto In listaConceptos
                totalIVASuma = totalIVASuma + CDec(concepto.costoIVATotal)
            Next
            Dim totalIVA As String = totalIVASuma.ToString()

            Dim Descuento As Decimal
            For Each concepto As Concepto In listaConceptos
                Descuento = Descuento + CDec(concepto.descuento)
            Next
            Dim DescuentoS As String = Descuento.ToString()
            Dim Folio As String = folioPago.Substring(1, 6)
            Dim Serie As String = folioPago.Substring(0, 1)
            Dim UsoCFDI As String = "P01"

            SubTotal = ch.getFormat(SubTotal)
            totalIVA = ch.getFormat(totalIVA)
            DescuentoS = ch.getFormat(DescuentoS)
            Total = ((CDec(SubTotal) - CDec(Descuento)) + CDec(totalIVA))

            Dim Fecha As String = db.exectSQLQueryScalar("select STUFF(CONVERT(VARCHAR(50),GETDATE(), 127) ,20,4,'') as fecha")
            MessageBox.Show(Fecha)

            Dim cadena = xml.cadenaPrueba(Serie, Folio, Fecha, formaPago, NoCertificado, SubTotal, DescuentoS, Total, listaConceptos, totalIVA)
            ''Dim sello As String = st.Sellado("C:\Users\darkz\Desktop\pfx\uxa_pfx33.pfx", "12345678a", cadena)
            Dim sello As String = st.Sellado("C:\Users\Luis\Desktop\pfx\uxa_pfx33.pfx", "12345678a", cadena)
            Dim xmlString As String = xml.xmlPrueba(Total, SubTotal, DescuentoS, totalIVA, Fecha, sello, Certificado, NoCertificado, formaPago, Folio, Serie, UsoCFDI, listaConceptos)
            xmlString = xmlString.Replace("utf-16", "UTF-8")
            Dim xmlTimbrado As String = st.Timbrado(xmlString, Folio)
            File.WriteAllText("C:\Users\Luis\Desktop\wea.xml", xmlTimbrado)
            db.execSQLQueryWithoutParams("INSERT INTO ing_xmlPruebas(XML) VALUES ('" & xmlTimbrado & "')")
            db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Usuario = '{User.getUsername()}'")
            MessageBox.Show("XML completado")
            CobrosEDC.Reiniciar()
            'db.commitTransaction()
        Catch ex As Exception
            'db.rollBackTransaction()
            MessageBox.Show(ex.Message)
            CobrosEDC.Reiniciar()
        End Try

    End Sub


    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------CALCULA TOTAL A PAGAR-----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
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
    Public Function obtenerFolio() As String
        Dim Serie As String = db.exectSQLQueryScalar($"SELECT Folio FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}' AND Descripcion = 'ING'")
        Dim Consecutivo As Integer = db.exectSQLQueryScalar($"SELECT Consecutivo + 1 FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}' AND Descripcion = 'ING'")
        Dim ConsecutivoStr As String
        If (Consecutivo > 0 And Consecutivo < 10) Then
            ConsecutivoStr = $"00000{Consecutivo}"
        ElseIf (Consecutivo > 10 And Consecutivo < 100) Then
            ConsecutivoStr = $"0000{Consecutivo}"
        ElseIf (Consecutivo > 100 And Consecutivo < 1000) Then
            ConsecutivoStr = $"000{Consecutivo}"
        ElseIf (Consecutivo > 1000 And Consecutivo < 10000) Then
            ConsecutivoStr = $"000{Consecutivo}"
        ElseIf (Consecutivo > 10000 And Consecutivo < 100000) Then
            ConsecutivoStr = $"00{Consecutivo}"
        ElseIf (Consecutivo > 100000 And Consecutivo < 1000000) Then
            ConsecutivoStr = $"0{Consecutivo}"
        ElseIf (Consecutivo > 1000000 And Consecutivo < 10000000) Then
            ConsecutivoStr = $"{Consecutivo}"
        End If

        Return $"{Serie}{ConsecutivoStr}"
    End Function
End Class
