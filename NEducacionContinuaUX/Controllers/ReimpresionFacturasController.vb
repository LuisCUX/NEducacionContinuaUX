Public Class ReimpresionFacturasController
    Dim db As DataBaseService = New DataBaseService()

    Function llenarComboboxFacturas(Matricula As String, cbFacturas As ComboBox) As Boolean
        Dim tableFacturas As DataTable = db.getDataTableFromSQL($"SELECT ID, UPPER('Folio: ' + ' ' + Folio + ' Fecha: ' + Fecha_Pago)As TextoFactura FROM ing_xmlTimbrados WHERE Matricula_Clave = '{Matricula}'")

        If (tableFacturas.Rows.Count() = 0) Then
            MessageBox.Show("La clave ingresada no existe o no tiene facturas cobradas, ingrese una clave diferente")
            Return False
        End If

        ComboboxService.llenarCombobox(cbFacturas, tableFacturas, "ID", "TextoFactura")

        Return True
    End Function

    Function validarMatricula(Matricula As String) As String
        If (Matricula.Length() < 9 Or Matricula.Length() > 9) Then
            MessageBox.Show("La clave ingresada no existe, favor de ingresar una clave valida")
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

    Sub llenarGridFactura(IDFactura As Integer, gridFactura As DataGridView)

    End Sub
End Class
