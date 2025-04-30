Imports System.Text.RegularExpressions
Public Class ModificacionCostosPlanesEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim vc As ValidacionesController = New ValidacionesController()
    Dim ap As AsignacionPlanesController = New AsignacionPlanesController()
    Dim planID As Integer
    Dim Matricula As String
    Dim combo_filtro As String
    Dim combo_filtro2 As String
    Dim combo_filtro3 As String
    Private Sub ModificacionCostosPlanesEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar3_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Matricula = txtMatricula.Text
        GridActual3.Rows.Clear()
        ap.buscarMatriculaEC(Matricula, panelInfo3, panelModificacion3, txtNombre3, txtEmail3, ComboBox1)
        ComboBox1.DataSource = Nothing
        planID = db.exectSQLQueryScalar($"SELECT DISTINCT P.ID FROM ing_AsignacionCargosPlanes AS A 
                                                         INNER JOIN ing_PlanesConceptos AS C ON C.ID = A.ID_Concepto
                                                         INNER JOIN ing_Planes AS P ON P.ID = C.ID_Plan
                                                         WHERE A.Matricula = '{Matricula}' AND A.Activo = 1")
        If (planID < 1) Then
            MessageBox.Show("La clave ingresada no tiene planes registrados")
            Me.Reiniciar()
            Exit Sub
        Else
            Try
                ap.llenarGridPagosCambioDescuento(planID, GridActual3, Matricula)
                For x = 0 To GridActual3.Rows.Count - 1
                    Dim clave As String = GridActual3.Rows(x).Cells(1).Value
                    If (clave = "P00") Then
                        txtInscripcion.Enabled = True
                    ElseIf (clave = "P13") Then
                        txtPagounico.Enabled = True
                    End If
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtInscripcion_KeyUp(sender As Object, e As KeyEventArgs) Handles txtInscripcion.KeyUp
        For x = 0 To GridActual3.Rows.Count() - 1
            Dim clave As String = GridActual3.Rows(x).Cells(1).Value
            If (clave = "P00") Then
                Dim index = txtInscripcion.Text.IndexOf(".")
                Dim decpoint As String
                If (index = -1) Then
                    decpoint = ".00"
                Else
                    decpoint = ""
                End If
                GridActual3.Rows(x).Cells(4).Value = $"{txtInscripcion.Text}{decpoint}"
            End If
        Next
    End Sub

    Private Sub txtMensualidades_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMensualidades.KeyUp
        For x = 0 To GridActual3.Rows.Count() - 1
            Dim clave As String = GridActual3.Rows(x).Cells(1).Value
            If (clave <> "P00" And clave <> "P13") Then
                Dim index = txtMensualidades.Text.IndexOf(".")
                Dim decpoint As String
                If (index = -1) Then
                    decpoint = ".00"
                Else
                    decpoint = ""
                End If
                GridActual3.Rows(x).Cells(4).Value = $"{txtMensualidades.Text}{decpoint}"
            End If
        Next
    End Sub

    Private Sub txtPagounico_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPagounico.KeyUp
        For x = 0 To GridActual3.Rows.Count() - 1
            Dim clave As String = GridActual3.Rows(x).Cells(1).Value
            If (clave = "P13") Then
                Dim index = txtPagounico.Text.IndexOf(".")
                Dim decpoint As String
                If (index = -1) Then
                    decpoint = ".00"
                Else
                    decpoint = ""
                End If
                GridActual3.Rows(x).Cells(4).Value = $"{txtPagounico.Text}{decpoint}"
            End If
        Next
    End Sub

    Private Sub controlCantidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInscripcion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("0123456789.", Chr(KeyAscii)) = 0 Then
            If KeyAscii <> 8 Then
                KeyAscii = 0
            End If
            e.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        ElseIf InStr(txtInscripcion.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
        Dim value As String = e.KeyChar
        For x = 0 To GridActual3.Rows.Count() - 1
            Dim clave As String = GridActual3.Rows(x).Cells(1).Value
            If (clave = "P00") Then
                Try
                    If (CDec($"{txtInscripcion.Text}{value}") > CDec(GridActual3.Rows(x).Cells(3).Value)) Then
                        txtInscripcion.Clear()
                        GridActual3.Rows(x).Cells(4).Value = " "
                        MessageBox.Show("Ingrese un valor menor al actual")
                        e.Handled = True
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try
            End If
        Next
    End Sub

    Private Sub controlCantidades2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMensualidades.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("0123456789.", Chr(KeyAscii)) = 0 Then
            If KeyAscii <> 8 Then
                KeyAscii = 0
            End If
            e.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        ElseIf InStr(txtMensualidades.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
        Dim value As String = e.KeyChar
        For x = 0 To GridActual3.Rows.Count() - 1
            Dim clave As String = GridActual3.Rows(x).Cells(1).Value
            If (clave <> "P00" And clave <> "P13") Then
                Try
                    If (CDec($"{txtMensualidades.Text}{value}") > CDec(GridActual3.Rows(x).Cells(3).Value)) Then
                        txtMensualidades.Clear()
                        GridActual3.Rows(x).Cells(4).Value = " "
                        MessageBox.Show("Ingrese un valor menor al actual")
                        e.Handled = True
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try
            End If
        Next
    End Sub

    Private Sub controlCantidades3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPagounico.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If InStr("0123456789.", Chr(KeyAscii)) = 0 Then
            If KeyAscii <> 8 Then
                KeyAscii = 0
            End If
            e.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        ElseIf InStr(txtPagounico.Text, ".") > 0 Then
            If KeyAscii = 46 Then
                e.Handled = True
            End If
        End If
        Dim value As String = e.KeyChar
        For x = 0 To GridActual3.Rows.Count() - 1
            Dim clave As String = GridActual3.Rows(x).Cells(1).Value
            If (clave = "P13") Then
                Try
                    If (CDec($"{txtPagounico.Text}{value}") > CDec(GridActual3.Rows(x).Cells(3).Value)) Then
                        GridActual3.Rows(x).Cells(4).Value = " "
                        txtPagounico.Clear()
                        MessageBox.Show("Ingrese un valor menor al actual")
                        e.Handled = True
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try
            End If
        Next
    End Sub



    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        ModificacionCostosPlanesEDC_Load(Me, Nothing)
        txtMatricula.Focus()
    End Sub

    Private Sub btnModificacionDesc_Click(sender As Object, e As EventArgs) Handles btnModificacionDesc.Click
        ap.cambiarDescuentos(Matricula, GridActual3)
        Me.Reiniciar()
    End Sub

    Private Sub btnReestablecer_Click(sender As Object, e As EventArgs) Handles btnReestablecer.Click
        For x = 0 To GridActual3.Rows.Count() - 1
            Dim costoActual As Decimal = Convert.ToDecimal(GridActual3.Rows(x).Cells(3).Value)
            Dim decuentoActual As Decimal = db.exectSQLQueryScalar($"SELECT Descuento FROM ing_AsignacionCargosPlanes WHERE ID_Concepto = {GridActual3.Rows(x).Cells(0).Value} AND Matricula = '{Matricula}'")
            Dim costoOriginal = costoActual + decuentoActual
            GridActual3.Rows(x).Cells(4).Value = costoOriginal.ToString()
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Public Sub keypress_textos_cmb(ByVal TXT As ComboBox, ByVal e As KeyPressEventArgs)
        Try

            Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\:\´]", RegexOptions.IgnoreCase)
            Dim KeyAscii As Short = Asc(e.KeyChar)

            If KeyAscii <> 8 Then
                e.Handled = re.IsMatch(e.KeyChar)
            End If

        Catch ex As Exception
            MsgBox("Error: en la validación de este campo, por favor verifique o comuniquese con sistemas", MsgBoxStyle.Exclamation, "Error en datos")
        End Try

    End Sub

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectionChangeCommitted
        Try
            If (cbExterno.SelectedIndex <> -1) Then
                txtMatricula.Text = cbExterno.SelectedValue
                btnBuscar.PerformClick()
                txtMatricula.Clear()
                cbExterno.Text = ""
                combo_filtro = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbExterno_KeyUp(sender As Object, e As KeyEventArgs) Handles cbExterno.KeyUp
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            combo_filtro = cbExterno.Text
        End If
    End Sub

    Private Sub cbExterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbExterno.KeyPress
        Me.keypress_textos_cmb(cbExterno, e)
        Dim kc As KeysConverter = New KeysConverter()
        Dim encontrar As String = cbExterno.Text

        Dim re As New Regex("[^a-zA-ZñÑáéíóúÁÉÍÓÚ\s\´]", RegexOptions.IgnoreCase)
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If re.IsMatch(e.KeyChar) = False Then

            combo_filtro += kc.ConvertToString(e.KeyChar)
            Dim filtro As String = cbExterno.Text
            Dim tableFiltro As DataTable = db.getDataTableFromSQL($"
                                                                SELECT DISTINCT CL.clave_cliente, UPPER('Externo: '+  C.nombre + ' ' + E.apellido_paterno + ' ' + E.apellido_materno + ' (' + CL.clave_cliente + ')') As NombreCliente FROM portal_registroCongreso AS E
                                                                INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
    										     	WHERE (C.nombre + ' ' +E.apellido_paterno + ' ' +E.apellido_materno LIKE '%{filtro}%')")
            ComboboxService.llenarCombobox(cbExterno, tableFiltro, "clave_cliente", "NombreCliente")
            cbExterno.SelectedValue = -1
            cbExterno.Text = combo_filtro
            cbExterno.DroppedDown = True
            cbExterno.SelectionStart = encontrar.Length
            cbExterno.SelectionLength = cbExterno.Text.Length - cbExterno.SelectionStart
        Else
            If Asc(e.KeyChar) = Keys.Space Then
                combo_filtro += " "
            End If
        End If
    End Sub
End Class