Public Class ModalCobrosDiferidosEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim Matricula As String
    Dim tipoMatricula As String
    Dim co As CobrosController = New CobrosController()
    Dim va As ValidacionesController = New ValidacionesController()
    Dim ca As CargosController = New CargosController()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()

    Dim listaConceptosDiferidos As New List(Of ConceptoDiferido)

    Private Sub ModalCobrosDiferidosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Limpiar()
        Matricula = ObjectBagService.getItem("Matricula")
        tipoMatricula = ObjectBagService.getItem("tipoMatricula")
        ObjectBagService.clearBag()
        If (tipoMatricula = "UX") Then
            va.buscarMatriculaUX(Matricula, panelDatos, panelCobros, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt)
        ElseIf (tipoMatricula = "EX") Then
            va.buscarMatriculaEX(Matricula, panelDatos, panelCobros, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCP, lblRegFiscal, lblCFDItxt)
        ElseIf (tipoMatricula = "EC") Then
            va.buscarMatriculaEC(Matricula, panelDatos, panelCobros, lblNombretxt, lblEmailtxt, lblCarreratxt, lblTurnotxt, lblRFCtxt, lblCP, lblRegFiscal, lblCFDItxt)
        End If

        ca.buscarPagosOpcionales(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarCongresos(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarColegiaturas(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarInscripcionesDiplomados(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarPagoUnicoDiplomados(Tree, Matricula, tipoMatricula, "Cobros")
        ca.buscarRecargosDiplomados(Tree, Matricula, tipoMatricula, "Cobros")



        Tree.Nodes(0).Expand()
        Tree.Nodes(1).Expand()
        Tree.Nodes(2).Expand()
        Tree.Nodes(3).Expand()
        Tree.Nodes(4).Expand()
        Tree.Nodes(5).Expand()
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

        Dim tipoPago As String

        Try
            tipopago = Tree.SelectedNode.Parent.Name()
        Catch ex As Exception
            Exit Sub
        End Try


        If (tipoPago = "nodeCongresos") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "CON", Matricula)

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "CON")
                Me.agregarConceptoDiferido(conceptoID, "CON", Tree.SelectedNode.Text, concepto.costoFinal)

                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(0).Nodes(index).SelectedImageIndex = 1
            Else
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "CON")
                Me.eliminarConceptoDiferido(conceptoID, "CON", Tree.SelectedNode.Text, concepto.costoFinal)

                ch.eliminarconcepto(conceptoID, "CON", Matricula)
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
                ch.agregarconcepto(conceptoID, tipoConcepto, Matricula)

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = tipoConcepto)
                Me.agregarConceptoDiferido(conceptoID, tipoConcepto, Tree.SelectedNode.Text, concepto.costoFinal)

                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(1).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = tipoConcepto)
                Me.eliminarConceptoDiferido(conceptoID, tipoConcepto, Tree.SelectedNode.Text, concepto.costoFinal)

                ch.eliminarconcepto(conceptoID, tipoConcepto, Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(1).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodeInscripcionDip") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "DIN", Matricula)

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "DIN")
                Me.agregarConceptoDiferido(conceptoID, "DIN", Tree.SelectedNode.Text, concepto.costoFinal)

                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(2).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                For Each item As TreeNode In Tree.Nodes(3).Nodes
                    If (item.SelectedImageIndex = 1) Then
                        MessageBox.Show($"No puede pagar colegiaturas sin antes haber pagado el cargo de inscripción")
                        Exit Sub
                    End If
                Next
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "DIN")
                Me.eliminarConceptoDiferido(conceptoID, "DIN", Tree.SelectedNode.Text, concepto.costoFinal)

                ch.eliminarconcepto(conceptoID, "DIN", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(2).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodeColegiaturaDip") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                If (Tree.Nodes(2).Nodes.Count() > 0) Then
                    If (Tree.Nodes(2).Nodes.Count > 0 And Tree.Nodes(2).Nodes(0).SelectedImageIndex <> 1) Then
                        MessageBox.Show("No puede pagar colegiaturas sin antes haber pagado el cargo de inscripción")
                        Exit Sub
                    End If
                End If
                If (Me.validarSeleccionNodosColegiaturas(index, 1) = False) Then
                    Dim mesActual As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "-", "-")
                    MessageBox.Show($"No puede pagar la colegiatura del mes {mesActual} sin antes haber pagado las colegiaturas anteriores")
                    Exit Sub
                End If
                If (Me.buscarRecargoColegiaturas(conceptoID) = False) Then
                    Dim mesActual As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "-", "-")
                    MessageBox.Show($"No puede pagar la colegiatura del mes de {mesActual} sin antes haber pagado el recargo correspondiente")
                    Exit Sub
                End If
                Tree.SelectedNode.Checked = True
                ch.agregarconcepto(conceptoID, "DCO", Matricula)

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "DCO")
                Me.agregarConceptoDiferido(conceptoID, "DCO", Tree.SelectedNode.Text, concepto.costoFinal)

                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(3).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                If (Me.validarSeleccionNodosColegiaturas(index, 2) = False) Then
                    Dim mesActual As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "-", "-")
                    MessageBox.Show($"No puede desmarcar el pago del mes de {mesActual} sin antes haber pagado las colegiaturas posteriores")
                    Exit Sub
                End If
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "DCO")
                Me.eliminarConceptoDiferido(conceptoID, "DCO", Tree.SelectedNode.Text, concepto.costoFinal)

                ch.eliminarconcepto(conceptoID, "DCO", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(3).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodePagoUnicoDip") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "DPU", Matricula)

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "DPU")
                Me.agregarConceptoDiferido(conceptoID, "DPU", Tree.SelectedNode.Text, concepto.costoFinal)

                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(4).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "DPU")
                Me.eliminarConceptoDiferido(conceptoID, "DPU", Tree.SelectedNode.Text, concepto.costoFinal)

                ch.eliminarconcepto(conceptoID, "DPU", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(4).Nodes(index).SelectedImageIndex = 0
            End If
        ElseIf (tipoPago = "nodeColegiaturasRec") Then
            Dim index As Integer = Tree.SelectedNode.Index
            If (Tree.SelectedNode.Checked = False) Then
                Tree.SelectedNode.Checked = True
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                ch.agregarconcepto(conceptoID, "REC", Matricula)

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "REC")
                Me.agregarConceptoDiferido(conceptoID, "REC", Tree.SelectedNode.Text, concepto.costoFinal)

                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(5).Nodes(index).SelectedImageIndex = 1
            ElseIf (Tree.SelectedNode.Checked = True) Then
                Dim recargoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")
                If (Me.buscarConceptoConRecargo(recargoID) = False) Then
                    MessageBox.Show("No puede cobrar conceptos sin antes haber pagado los recargos correspondientes")
                    Exit Sub
                End If
                Tree.SelectedNode.Checked = False
                Dim conceptoID As String = co.Extrae_Cadena(Tree.SelectedNode.ToString(), "[", "]")

                Dim concepto As Concepto = ch.getListaConceptos().Find(Function(c) c.IDConcepto = conceptoID And c.claveConcepto = "REC")
                Me.eliminarConceptoDiferido(conceptoID, "REC", Tree.SelectedNode.Text, concepto.costoFinal)

                ch.eliminarconcepto(conceptoID, "REC", Matricula)
                Me.actualizarTotal(ch.getListaConceptos())
                Tree.Nodes(5).Nodes(index).SelectedImageIndex = 0
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

    Function buscarRecargoColegiaturas(ID As Integer) As Boolean
        Dim IDRecargo As Integer
        Dim seleccionado As Boolean
        For Each item As TreeNode In Tree.Nodes(5).Nodes
            IDRecargo = co.Extrae_Cadena(item.ToString(), "[", "]")
            Dim idConceptoRecargo As Integer = db.exectSQLQueryScalar($"SELECT ID_Concepto FROM ing_PlanesRecargos WHERE ID = {IDRecargo}")
            Dim autorizado As Integer = db.exectSQLQueryScalar($"SELECT Autorizado FROM ing_AsignacionCargosPlanes WHERE ID = {idConceptoRecargo}")
            If (idConceptoRecargo = ID And item.SelectedImageIndex <> 1 And autorizado = False) Then
                Return False
            End If
        Next
        Return True
    End Function

    Function buscarConceptoConRecargo(IDRecargo As Integer) As Boolean
        Dim IDRecargado As Integer = db.exectSQLQueryScalar($"SELECT ID_Concepto FROM ing_PlanesRecargos WHERE ID = {IDRecargo}")
        For x = 0 To 5
            For Each item As TreeNode In Tree.Nodes(x).Nodes
                Dim IDCOncepto As Integer = co.Extrae_Cadena(item.ToString(), "[", "]")
                If (IDCOncepto = IDRecargado And item.SelectedImageIndex = 1) Then
                    Return False
                End If
            Next
        Next

        Return True
    End Function

    Function validarSeleccionNodosColegiaturas(index As Integer, tipo As Integer) As Boolean
        If (tipo = 1) Then
            For x = 0 To index - 1
                If (Tree.Nodes(3).Nodes(x).SelectedImageIndex <> 1) Then
                    Return False
                End If
            Next
        ElseIf (tipo = 2) Then
            For x = index To Tree.Nodes(3).Nodes.Count() - 1
                If (Tree.Nodes(3).Nodes(x).SelectedImageIndex = 1 And Tree.Nodes(3).Nodes(x).Index <> index) Then
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        ModalCobrosDiferidosEDC_Load(Me, Nothing)
    End Sub

    Sub Limpiar()
        lblNombretxt.Text = ""
        lblEmailtxt.Text = ""
        lblCarreratxt.Text = ""
        lblTurnotxt.Text = ""
        Tree.Nodes(0).Nodes.Clear()
        Tree.Nodes(1).Nodes.Clear()
        Tree.Nodes(2).Nodes.Clear()
        Tree.Nodes(3).Nodes.Clear()
        Tree.Nodes(4).Nodes.Clear()
        Tree.Nodes(5).Nodes.Clear()
        lblTotal.Text = ""
    End Sub

    Sub agregarConceptoDiferido(ID As Integer, claveConcepto As String, Descripcion As String, TotalPagar As String)
        Dim conceptoD As New ConceptoDiferido
        conceptoD.IDConcepto = ID
        conceptoD.ClaveConcepto = claveConcepto
        conceptoD.DescripcionConcepto = Descripcion
        conceptoD.TotalCobrar = TotalPagar
        listaConceptosDiferidos.Add(conceptoD)
    End Sub

    Sub eliminarConceptoDiferido(ID As Integer, claveConcepto As String, Descripcion As String, TotalPagar As String)
        listaConceptosDiferidos.RemoveAll(Function(wea) wea.IDConcepto = ID And wea.ClaveConcepto = claveConcepto And wea.DescripcionConcepto = Descripcion And wea.TotalCobrar = TotalPagar)
    End Sub

    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click
        For x = 0 To MainCobrosDiferidosEDC.GridConceptos.Rows.Count - 1
            For Each condepto As ConceptoDiferido In listaConceptosDiferidos
                If (MainCobrosDiferidosEDC.GridConceptos.Rows(x).Cells(0).Value = condepto.IDConcepto And MainCobrosDiferidosEDC.GridConceptos.Rows(x).Cells(1).Value = condepto.ClaveConcepto) Then
                    MessageBox.Show($"El concepto {MainCobrosDiferidosEDC.GridConceptos.Rows(x).Cells(3).Value} ya se encuentra considerado para pago")
                    Exit Sub
                End If
            Next
        Next

        For Each conceptod As ConceptoDiferido In listaConceptosDiferidos
            MainCobrosDiferidosEDC.GridConceptos.Rows.Add(conceptod.IDConcepto, conceptod.ClaveConcepto, Matricula, conceptod.DescripcionConcepto, conceptod.TotalCobrar)
        Next
        MainCobrosDiferidosEDC.actualizarTotal()
        Me.Close()
    End Sub

End Class