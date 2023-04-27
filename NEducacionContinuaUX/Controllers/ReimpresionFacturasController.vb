Public Class ReimpresionFacturasController
    Dim db As DataBaseService = New DataBaseService()

    Function llenarComboboxFacturas(Matricula As String, cbFacturas As ComboBox) As Boolean
        Dim tableFacturas As DataTable = db.getDataTableFromSQL($"SELECT ID, UPPER('Folio: ' + ' ' + Folio + ' Fecha: ' + Fecha_Pago + 
                                                                  CASE 
                                                                  WHEN CanceladaHoy = 1 OR CanceladaOtroDia = 1 THEN ' -----CANCELADA'
                                                                  WHEN Folio IN (SELECT FolioSustituido FROM ing_Sustituciones WHERE Activo = 1) THEN ' -----SUSTITUIDA'
                                                                  ELSE ''
                                                                  END
                                                                  )As TextoFactura FROM ing_xmlTimbrados WHERE Matricula_Clave = '{Matricula}'")

        If (tableFacturas.Rows.Count() = 0) Then
            MessageBox.Show("La clave ingresada no existe o no tiene facturas cobradas, ingrese una clave diferente")
            Return False
        End If

        ComboboxService.llenarCombobox(cbFacturas, tableFacturas, "ID", "TextoFactura")
        cbFacturas.SelectedIndex = -1
        Return True
    End Function

    Function validarMatricula(Matricula As String) As String
        Matricula = Matricula.ToUpper()
        If (Matricula.Length() < 9 Or Matricula.Length() > 9) Then
            MessageBox.Show("La clave ingresada no existe, favor de ingresar una clave valida")
            Return "False"
        Else
            If (Matricula.Substring(0, 2) = "EX") Then
                Return "EX"
            ElseIf (Matricula.Substring(0, 2) = "EC") Then
                Return "EC"
            End If
        End If

        Return "False"
    End Function

    Sub llenarGridFactura(IDFactura As Integer, gridFactura As DataGridView)

    End Sub

    Sub obtenerDatosCliente(Matricula As String, lblNombre As Label, lblRFC As Label, lblEmail As Label)
        Dim tablas As String()
        If (Matricula.Substring(0, 2) = "EX") Then
            tablas = {"portal_reRFC", "portal_registroExterno"}
        ElseIf (Matricula.Substring(0, 2) = "EC") Then
            tablas = {"portal_rcRFC", "portal_registroCongreso"}
        End If

        Dim RFC As String = db.exectSQLQueryScalar($"SELECT RFC.rfc FROM {tablas(0)} AS RE
                                                     INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RE.id_rfc
                                                     INNER JOIN {tablas(1)} AS EX ON EX.id_registro = RE.id_registro
                                                     WHERE EX.clave_cliente = '{Matricula}'")
        lblRFC.Text = RFC
        If (RFC = "XAXX010101000") Then
            lblNombre.Text = db.exectSQLQueryScalar($"SELECT RE.razonsocial FROM {tablas(0)} AS RE
                                                 INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RE.id_rfc
                                                 INNER JOIN {tablas(1)} AS EX ON EX.id_registro = RE.id_registro
                                                 WHERE EX.clave_cliente = '{Matricula}'")
            lblEmail.Text = db.exectSQLQueryScalar($"SELECT RE.correo FROM {tablas(0)} AS RE
                                                INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RE.id_rfc
                                                INNER JOIN {tablas(1)} AS EX ON EX.id_registro = RE.id_registro
                                                WHERE EX.clave_cliente = '{Matricula}'")
        Else
            lblNombre.Text = db.exectSQLQueryScalar($"select (C.nombre + ' ' + RE.paterno + ' ' + RE.materno) from portal_cliente AS C 
                                                       INNER JOIN {tablas(1)} AS RE ON RE.id_cliente = C.id_cliente
                                                       WHERE RE.clave_cliente = '{Matricula}'")
            lblEmail.Text = db.exectSQLQueryScalar($"select (C.nombre + ' ' + RE.paterno + ' ' + RE.materno) from portal_cliente AS C 
                                                     INNER JOIN {tablas(1)} AS RE ON RE.id_cliente = C.id_cliente
                                                     WHERE RE.clave_cliente = '{Matricula}'")
        End If
    End Sub
End Class
