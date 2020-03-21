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
    ''-----------------------------------------------------VALIDA EL TIPO DE MATRICULA--------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------

    Function validarMatricula(Matricula As String) As String
        If (Matricula.Length() < 9 Or Matricula.Length() > 9) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            Return "False"
        Else
            Dim MatriculaUX As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")
            If (MatriculaUX > 0) Then
                Return "UX"
            ElseIf (Matricula.Substring(0, 2) = "EX") Then
                Return "EX"
            ElseIf (Matricula.Substring(0, 2) = "EC") Then
                Return "EC"
            End If
        End If

        Return "False"
    End Function


    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------BUSCA MATRICULA MATRICULA----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaUX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim matriculaUX As String = db.exectSQLQueryScalar($"SELECT MatriculaUX FROM ing_catMatriculasUX WHERE MatriculaEX = '{Matricula}'")
        Dim exists As String = db.exectSQLQueryScalar($"SELECT nombre FROM ux.dbo.dae_catAlumnos WHERE matricula = '{matriculaUX}'")
        Dim sit_esc As String = db.exectSQLQueryScalar($"SELECT sit_esc FROM ux.dbo.dae_catAlumnos WHERE matricula = '{matriculaUX}'")

        If (exists = Nothing) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        If (sit_esc = "B") Then
            MessageBox.Show("La matricula ingresada se encuentra dada de baja, favor de ingresar una matricula valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosUX(matriculaUX, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------------LLENA PANEL DE DATOS UX----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosUX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim nombre As String = db.exectSQLQueryScalar($"SELECT UPPER(nombre + ' ' + ap_pat + ' ' + ap_mat) As NombreAlumno FROM ux.dbo.dae_catAlumnos WHERE Matricula = '{Matricula}'")
        Dim email As String = db.exectSQLQueryScalar($"SELECT email FROM ux.dbo.dae_catAlumnos WHERE Matricula = '{Matricula}'")
        Dim carrera As String = db.exectSQLQueryScalar($"SELECT nombre FROM ux.dbo.dae_catCarreras WHERE clave = '{Matricula.Substring(4, 2)}'")

        Dim NT As String() = UtilitiesService.getNivelTurno(Matricula)
        Dim Turno As String = db.exectSQLQueryScalar($"SELECT Turno FROM mov_CatTurno WHERE clave = '{NT(1)}'")

        txtNombre.Text = nombre
        txtEmail.Text = email
        txtCarrera.Text = carrera
        txtTurno.Text = Turno

        panelDatos.Visible = True
        panelCobros.Visible = True
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------BUSCA MATRICULA MATRICULA EXTERNA------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaEX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id_clave FROM portal_clave WHERE clave_cliente = '{Matricula}'")

        If (exists < 1) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosEX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
    End Sub



    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------LLENA PANEL DE DATOS EXTERNA-------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosEX(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT UPPER(C.nombre + ' ' + EX.paterno + ' ' + EX.materno)As Nombre, C.correo FROM portal_cliente AS C 
                                                               INNER JOIN portal_registroExterno AS EX ON C.id_cliente = EX.id_cliente
                                                               WHERE EX.clave_cliente = '{Matricula}'")
        For Each item As DataRow In tableDatos.Rows
            txtNombre.Text = item("Nombre")
            txtEmail.Text = item("correo")
        Next
        txtCarrera.Text = ""
        txtTurno.Text = ""

        panelDatos.Visible = True
        panelCobros.Visible = True
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-------------------------------------------------BUSCA MATRICULA MATRICULA CONGRESO-----------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarMatriculaEC(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim exists As Integer = db.exectSQLQueryScalar($"SELECT id_clave FROM portal_clave WHERE clave_cliente = '{Matricula}'")

        If (exists < 1) Then
            MessageBox.Show("La matricula ingresada no existe, favor de ingresar una matricula valida")
            CobrosEDC.Reiniciar()
            Exit Sub
        End If

        Me.llenarPanelDatosEC(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
    End Sub



    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''-----------------------------------------------------LLENA PANEL DE DATOS CONGRESO------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub llenarPanelDatosEC(Matricula As String, panelDatos As Panel, panelCobros As Panel, txtNombre As TextBox, txtEmail As TextBox, txtCarrera As TextBox, txtTurno As TextBox)
        Dim tableDatos As DataTable = db.getDataTableFromSQL($"SELECT UPPER(C.nombre + ' ' + R.apellido_paterno + ' ' + R.apellido_materno) AS Nombre, C.correo FROM portal_cliente AS C 
                                                               INNER JOIN portal_registroCongreso AS R ON R.id_cliente = C.id_cliente
                                                               WHERE R.clave_cliente = '{Matricula}'")
        For Each item As DataRow In tableDatos.Rows
            txtNombre.Text = item("Nombre")
            txtEmail.Text = item("correo")
        Next
        txtCarrera.Text = ""
        txtTurno.Text = ""

        panelDatos.Visible = True
        panelCobros.Visible = True
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------BUSCA PAGOS OPCIONALES----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarPagosOpcionales(Tree As TreeView, Matricula As String, TipoMatricula As String)
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
            Tree.Nodes(1).Nodes.Add(result).StateImageIndex = 0
        Next
        Tree.Nodes(1).Expand()
    End Sub

    ''----------------------------------------------------------------------------------------------------------------------------------------
    ''--------------------------------------------------------BUSCA CONGRESOS----------------------------------------------------------
    ''----------------------------------------------------------------------------------------------------------------------------------------
    Sub buscarCongresos(Tree As TreeView, Matricula As String, TipoMatricula As String)
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
            Tree.Nodes(0).Nodes.Add(result).StateImageIndex = 0
        Next
        Tree.Nodes(0).Expand()
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
        Dim Serie As String = db.exectSQLQueryScalar($"SELECT Folio FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}'")
        Dim Consecutivo As Integer = db.exectSQLQueryScalar($"SELECT Consecutivo + 1 FROM ing_CatFolios WHERE Usuario = '{User.getUsername()}'")
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
