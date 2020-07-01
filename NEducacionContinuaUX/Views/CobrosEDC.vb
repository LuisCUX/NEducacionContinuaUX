﻿Public Class CobrosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim co As CobrosController = New CobrosController()
    Dim ca As CargosController = New CargosController()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim siguienteColegiatura As Integer = 0
    Private Sub CobrosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableFormaPago As DataTable = db.getDataTableFromSQL("SELECT Forma_Pago, Descripcion FROM ing_CatFormaPago")
        ComboboxService.llenarCombobox(cbFormaPago, tableFormaPago, "Forma_Pago", "Descripcion")

        rbExterno.Checked = True
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Limpiar()
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        txtMatriculaDato.Text = Matricula
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
        End If
        ca.buscarPagosOpcionales(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarCongresos(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarColegiaturas(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarInscripcionesDiplomados(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarPagoUnicoDiplomados(Tree, Matricula, tipoMatricula, "Cobros")
        Tree.Nodes(0).Expand()
        Tree.Nodes(1).Expand()
        Tree.Nodes(2).Expand()
        Tree.Nodes(3).Expand()
        Tree.Nodes(4).Expand()
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
        ElseIf Tree.SelectedNode.Text = "Congresos" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Inscripción a Diplomados" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Colegiaturas de Diplomados" Then
            Exit Sub
        ElseIf Tree.SelectedNode.Text = "Pago Unico de Diplomados" Then
            Exit Sub
        End If
        Dim tipoPago As String = Tree.SelectedNode.Parent.Name()


        If (tipoPago = "nodeCongresos") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "CON")
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(0).Nodes(index).SelectedImageIndex = 1
            Else
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.eliminarconcepto(conceptoID, "CON")
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(0).Nodes(index).SelectedImageIndex = 0
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
        ElseIf (tipoPago = "nodeInscripcionDip") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "DIN")
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(2).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.eliminarconcepto(conceptoID, "DIN")
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(2).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodeColegiaturaDip") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                If (index <> siguienteColegiatura) Then
                    Dim mesActual As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "-", "-")
                    MessageBox.Show($"No puede pagar la colegiatura del mes de {mesActual} sin antes haber pagado los meses anteriores")
                    Exit Sub
                Else
                    siguienteColegiatura = siguienteColegiatura + 1
                End If
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "DCO")
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(3).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                siguienteColegiatura = siguienteColegiatura - 1
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.eliminarconcepto(conceptoID, "DCO")
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(3).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodePagoUnicoDip") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "DPU")
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(4).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.eliminarconcepto(conceptoID, "DPU")
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(4).Nodes(index).SelectedImageIndex = 0
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

    Private Sub cbExterno_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbExterno.SelectionChangeCommitted
        Try
            txtMatricula.Text = cbExterno.SelectedValue
            btnBuscar.PerformClick()
            txtMatricula.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        Dim listaConceptos As List(Of Concepto) = ch.getListaConceptos()
        If (listaConceptos.Count() = 0) Then
            MessageBox.Show("Ingrese al menos un concepto para poder cobrar")
            Return
        End If
        co.Cobrar(ch.getListaConceptos(), cbFormaPago.SelectedValue, Matricula)
    End Sub

    Private Sub rbExterno_CheckedChanged(sender As Object, e As EventArgs) Handles rbExterno.CheckedChanged
        cbExterno.DataSource = Nothing
        Dim tableExternos As DataTable = db.getDataTableFromSQL("SELECT CL.clave_cliente, UPPER(C.nombre + ' ' + E.paterno + ' ' + E.materno + ' (' + CL.clave_cliente + ')') As NombreExterno FROM portal_registroExterno AS E
                                                                 INNER JOIN portal_cliente AS C ON E.id_cliente = C.id_cliente
                                                                 INNER JOIN portal_clave AS CL ON CL.id_cliente = C.id_cliente
                                                                 ORDER BY C.nombre")
        ComboboxService.llenarCombobox(cbExterno, tableExternos, "clave_cliente", "NombreExterno")
    End Sub

    Private Sub rbEDC_CheckedChanged(sender As Object, e As EventArgs) Handles rbEDC.CheckedChanged
        cbExterno.DataSource = Nothing
        Dim tableEDC As DataTable = db.getDataTableFromSQL("SELECT RC.clave_cliente, UPPER(C.nombre + ' ' + RC.apellido_paterno + ' ' + RC.apellido_materno + ' (' + RC.clave_cliente + ')') AS NombreCliente FROM portal_registroCongreso AS RC
                                                            INNER JOIN portal_cliente AS C ON RC.id_cliente = C.id_cliente
                                                            ORDER BY NombreCliente")
        ComboboxService.llenarCombobox(cbExterno, tableEDC, "clave_cliente", "NombreCliente")
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