Public Class MainCobrosDiferidosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim co As CobrosController = New CobrosController()
    Dim va As ValidacionesController = New ValidacionesController()

    Private Sub MainCobrosDiferidosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tableFormaPago As DataTable = db.getDataTableFromSQL("SELECT Forma_Pago, Descripcion FROM ing_CatFormaPago")
        ComboboxService.llenarCombobox(cbFormaPago, tableFormaPago, "Forma_Pago", "Descripcion")
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Limpiar()
        Matricula = txtMatricula.Text
        tipoMatricula = va.validarMatricula(Matricula)
        If (tipoMatricula = "False") Then
            Me.Reiniciar()
            Exit Sub
        ElseIf (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelCobros, txtNombre, txtEmail, txtCarrera, txtTurno)
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        MainCobrosDiferidosEDC_Load(Me, Nothing)
    End Sub

    Private Sub txtMatricula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMatricula.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ModalCobrosDiferidosEDC.MdiParent = PrincipalView
        ModalCobrosDiferidosEDC.Show()
    End Sub
End Class