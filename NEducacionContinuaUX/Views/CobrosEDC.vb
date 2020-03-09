﻿Public Class CobrosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim co As CobrosController = New CobrosController()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Private Sub CobrosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableFormaPago As DataTable = db.getDataTableFromSQL("SELECT Forma_Pago, Descripcion FROM ing_CatFormaPago")
        ComboboxService.llenarCombobox(cbFormaPago, tableFormaPago, "Forma_Pago", "Descripcion")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Limpiar()
        Matricula = txtMatricula.Text
        tipoMatricula = co.validarMatricula(Matricula)
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            co.buscarMatriculaUX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EC") Then
            co.buscarMatriculaEX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
        End If
        co.buscarPagosOpcionales(Tree, Matricula, tipoMatricula)
        Tree.Nodes(1).Expand()
    End Sub
    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        CobrosEDC_Load(Me, Nothing)
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Tree_DoubleClick(sender As Object, e As EventArgs) Handles Tree.DoubleClick
        Me.Nodos()
    End Sub

    Sub Nodos()
        If (Tree.SelectedNode Is Nothing) Then
            Exit Sub
        ElseIf (Tree.SelectedNode.Text) = "Eventos" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Pagos Opcionales" Then
            Exit Sub
        End If
        Dim tipoPago As String = Tree.SelectedNode.Parent.Name()


        If (tipoPago = "nodeEventos") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = Tree.SelectedNode.ToString()
                Tree.SelectedNode.SelectedImageIndex = 0
            Else
                Tree.SelectedNode.Checked = False
                Tree.SelectedNode.SelectedImageIndex = 1
            End If
        ElseIf (tipoPago = "nodePagosOpcionales") Then
            Dim tipoConcepto As String
            If (tipoMatricula = "UX") Then
                tipoConcepto = "POA"
            Else
                tipoConcepto = "POE"
            End If
            Dim index As Integer = Tree.SelectedNode.Index
                If (Tree.SelectedNode.Checked = False) Then
                    Tree.SelectedNode.Checked = True
                    Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, tipoConcepto)
                Me.actualizarTotal(ch.getListaConceptos())
                    Tree.Nodes(1).Nodes(index).SelectedImageIndex = 1
                ElseIf (Tree.SelectedNode.Checked = True) Then
                    Tree.SelectedNode.Checked = False
                    Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.eliminarconcepto(conceptoID, tipoConcepto)
                Me.actualizarTotal(ch.getListaConceptos())
                    Tree.Nodes(1).Nodes(index).SelectedImageIndex = 0
                End If
            End If
    End Sub

    Sub actualizarTotal(listaConceptos As List(Of Concepto))
        Dim Total As Decimal
        Total = 0.00
        For Each concepto As Concepto In listaConceptos
            Total = Total + CDec(concepto.costoFinal)
        Next
        lblTotal.Text = Total.ToString()
    End Sub


    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        Dim listaConceptos As List(Of Concepto) = ch.getListaConceptos()
        If (listaConceptos.Count() = 0) Then
            MessageBox.Show("Ingrese al menos un concepto para poder cobrar")
            Return
        End If
        co.Cobrar(ch.getListaConceptos(), cbFormaPago.SelectedValue, Matricula)
    End Sub

    Sub Limpiar()
        txtNombre.Clear()
        txtEmail.Clear()
        txtCarrera.Clear()
        txtTurno.Clear()
        Tree.Nodes(0).Nodes.Clear()
        Tree.Nodes(1).Nodes.Clear()
        lblTotal.Text = ""
        ch.limpiarListaConceptos()
    End Sub
End Class