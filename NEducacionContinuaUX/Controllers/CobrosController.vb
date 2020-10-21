Imports System.Configuration
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Public Class CobrosController
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim xml As XmlService = New XmlService()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim rep As ImpresionReportesService = New ImpresionReportesService()
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder

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
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDiplomados(Folio, Matricula, valorUnitario, valorIVA, Descuento, ID_FormaPago, ID_ClavePago, Fecha_Pago, Autorizado, Condonado, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, 4, GETDATE(), 0, 0, '{User.getUsername()}', 1)")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 5")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------COBRA PAGO UNICO DE DIPLOMADO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub cobrarPagoUnicoDiplomado(concepto As Concepto, Matricula As String, Folio As String, formaPago As String)
        Dim formaPagoint As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_CatFormaPago WHERE Forma_Pago = '{formaPago}'")
        db.execSQLQueryWithoutParams($"INSERT INTO ing_PagosDiplomados(Folio, Matricula, valorUnitario, valorIVA, Descuento, ID_FormaPago, ID_ClavePago, Fecha_Pago, Autorizado, Condonado, Usuario, Activo) VALUES ('{Folio}', '{Matricula}', {CDec(concepto.costoBase)}, {CDec(concepto.costoIVAUnitario)}, {CDec(concepto.descuento)}, {formaPagoint}, 5, GETDATE(), 0, 0, '{User.getUsername()}', 1)")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE ID = {concepto.IDConcepto}")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 4")
        db.execSQLQueryWithoutParams($"UPDATE ing_AsignacionCargosPlanes SET Activo = 0 WHERE Matricula = '{Matricula}' AND ID_ClaveConcepto = 6")
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''---------------------------------------------------------COBRA PAGO YA VALIDADO---------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub Cobrar(listaConceptos As List(Of Concepto), formaPago As String, Matricula As String, RFCCLiente As String, NombreCLiente As String)
        ''---------------------------------------------------------REGISTRO DE COBRO/S EN BASE DE DATOS---------------------------------------------------------
        Dim folioPago As String = Me.obtenerFolio()
        Try
            db.startTransaction()
            For Each concepto As Concepto In listaConceptos
                If (concepto.claveConcepto = "POA") Then
                    Me.cobrarPagoOpcionalAlumno(concepto, Matricula, folioPago)
                ElseIf (concepto.claveConcepto = "POE") Then
                    Me.cobrarPagoOpcionalExterno(concepto, Matricula, folioPago)
                ElseIf (concepto.claveConcepto = "CON") Then
                    Me.cobrarCongreso(concepto, Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "DCO") Then
                    Me.cobrarColegiaturaDiplomado(concepto, Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "DIN") Then
                    Me.cobrarInscripcionDiplomado(concepto, Matricula, folioPago, formaPago)
                ElseIf (concepto.claveConcepto = "DPU") Then
                    Me.cobrarPagoUnicoDiplomado(concepto, Matricula, folioPago, formaPago)
                End If
            Next

            ''---------------------------------------------------------CALCULO DE TOTALES---------------------------------------------------------
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
            Dim TotalText As String
            Dim valores As String()
            If (InStr(Total, ".")) Then
                valores = Split(Total, ".")
                TotalText = $"{Me.Num2Text(valores(0))} PESOS {valores(1)}/100 M.N"
            Else
                TotalText = $"{Me.Num2Text(Total)} PESOS"
            End If
            Dim Fecha As String = db.exectSQLQueryScalar("select STUFF(CONVERT(VARCHAR(50),GETDATE(), 127) ,20,4,'') as fecha")
            MessageBox.Show(Fecha)

            ''---------------------------------------------------------TIMBRADO---------------------------------------------------------
            Dim cadena = xml.cadenaPrueba(Serie, Folio, Fecha, formaPago, NoCertificado, SubTotal, DescuentoS, Total, listaConceptos, totalIVA, RFCCLiente, NombreCLiente)
            ''Dim sello As String = st.Sellado("C:\Users\darkz\Desktop\pfx\uxa_pfx33.pfx", "12345678a", cadena)
            Dim sello As String = st.Sellado("C:\Users\Luis\Desktop\pfx\uxa_pfx33.pfx", "12345678a", cadena)
            Dim xmlString As String = xml.xmlPrueba(Total, SubTotal, DescuentoS, totalIVA, Fecha, sello, Certificado, NoCertificado, formaPago, Folio, Serie, UsoCFDI, listaConceptos, RFCCLiente, NombreCLiente)
            xmlString = xmlString.Replace("utf-16", "UTF-8")
            Dim xmlTimbrado As String = st.Timbrado(xmlString, Folio)
            Dim folioFiscal As String = Me.Extrae_Cadena(xmlTimbrado, "UUID=", " FechaTimbrado")
            folioFiscal = Me.Extrae_Cadena(folioFiscal, "=", "")
            folioFiscal = folioFiscal.Substring(1, folioFiscal.Length() - 1)
            File.WriteAllText("C:\Users\Luis\Desktop\wea.xml", xmlTimbrado)
            ''File.WriteAllText("C:\Users\darkz\Desktop\wea.xml", xmlTimbrado)

            ''---------------------------------------------------------GENERACION DE FACTURA---------------------------------------------------------
            Dim IDXML As Integer = db.insertAndGetIDInserted($"INSERT INTO ing_xmlTimbrados(Matricula_Clave, Folio, FolioFiscal, Certificado, XMLTimbrado, fac_Cadena, fac_Sello, Tipo_Pago, Forma_Pago, Fecha_Pago, Cajero, RegimenFiscal, Subtotal, Descuento, IVA, Total, usoCFDI) VALUES ('{Matricula}', '{Serie}{Folio}', '{folioFiscal}', '{NoCertificado}', '{xmlTimbrado}', '{cadena}', '{sello}', '', '{formaPago}', '{Fecha}', '{User.getUsername}', 'GENERAL DE LEY(603)', {SubTotal}, {DescuentoS}, {totalIVA}, {Total}, '{UsoCFDI}')")
            For Each item As Concepto In listaConceptos
                db.execSQLQueryWithoutParams($"INSERT INTO ing_xmlTimbradosConceptos(XMLID, Nombre_Concepto, Clave_Concepto, ClaveUnidad, PrecioUnitario, IVA, Descuento, Cantidad, Total) VALUES ({IDXML}, '{item.NombreConcepto}', {1}, '{item.cveUnidad}', {item.costoUnitario}, {item.costoIVAUnitario}, {item.descuento}, {item.Cantidad}, {item.costoTotal})")
            Next
            db.execSQLQueryWithoutParams($"UPDATE ing_CatFolios SET Consecutivo = Consecutivo + 1 WHERE Usuario = '{User.getUsername()}'")
            MessageBox.Show("XML completado")
            Dim descripcionCFDI As String = db.exectSQLQueryScalar($"select UPPER('(' + clave_usoCFDI + ')' + ' ' + descripcion) As Clave from ing_cat_usoCFDI WHERE clave_usoCFDI = '{UsoCFDI}'")
            Dim QR As String = $"?re={EnviromentService.RFCEDC}&rr={RFCCLiente}id={folioFiscal}tt={Total}"
            Me.gernerarQr(QR, $"{Serie}{Folio}")
            rep.AgregarFuente("FacturaEDC.rpt")
            rep.AgregarParametros("IDXML", IDXML)
            rep.AgregarParametros("CantidadLetra", TotalText)
            rep.AgregarParametros("ClaveCliente", Matricula)
            rep.AgregarParametros("usoCFDI", descripcionCFDI)
            rep.MostrarReporte()
            CobrosEDC.Reiniciar()
            db.commitTransaction()
        Catch ex As Exception
            db.rollBackTransaction()
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

    Public Function Num2Text(ByVal value As Double) As String
        Dim valores(2) As String  ' IMPORTE CON LETRA
        Dim bandera_numero_letra As Boolean = True ' IMPORTE CON LETRA
        Dim centavos As String 'IMPORTE CON LETRA
        'FUNCION PARA SACAR EL IMPORTE EN LETRA
        Dim valor

        If InStr(value, ".") Then
            valores = Split(value, ".")
            valor = valores(0)
        Else
            valor = value
            bandera_numero_letra = False
        End If

        If bandera_numero_letra = True Then
            bandera_numero_letra = False
            valores = Split(value, ".")
            centavos = valores(1)
        End If

        Select Case valor
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select

    End Function

    Public Sub gernerarQr(QR As String, Nombre As String)

        Try
            Dim img As New Bitmap(QR_Generator.Encode(QR.ToString), New Size(220, 220))
            img.Save($"\\{EnviromentService.serverIP}\ti\NEducacionContinua\QR\{Nombre}.png", Imaging.ImageFormat.Png)
            Thread.Sleep(1500)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
