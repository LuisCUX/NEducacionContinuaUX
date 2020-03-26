Public Class AutorizacionCondonacionController
    Dim db As DataBaseService = New DataBaseService()
    Dim ca As CargosController = New CargosController()

    ''----------LLENA COMBOBOX DE LA VENTANA----------''
    Sub llenarComboboxes(cbTipoCondonacion As ComboBox)
        cbTipoCondonacion.Items.Clear()
        cbTipoCondonacion.Items.Add("CONDONACIÓN TOTAL")
        cbTipoCondonacion.Items.Add("CONDONACIÓN PARCIAL")
    End Sub

    ''----------ACTUALIZA ARBOL DE PESTAÑA DE CONDONACION CUANDO SE CAMBIA EL VALOR DEL COMOBOBOX----------''
    Sub ActualizarArbolCondonacion(TreeCondonacion As TreeView, tipoCondonacion As String, Matricula As String, tipoMatricula As String)
        TreeCondonacion.Nodes.Clear()
        Dim ID As Integer
        If (tipoCondonacion = "CONDONACIÓN TOTAL") Then
            ID = 4
        ElseIf (tipoCondonacion = "CONDONACIÓN PARCIAL") Then
            ID = 3
        End If

        Dim tableCondonacionesTotales As DataTable = db.getDataTableFromSQL($"SELECT C.ID, C.Nombre FROM aut_Cat_Claves AS C
                                                                              INNER JOIN aut_res_AutClaves AS R ON R.ID_Clave = C.ID
                                                                              INNER JOIN aut_Cat_Autorizaciones AS A ON A.ID = R.ID_Autorizacion
                                                                              INNER JOIN aut_Cat_TipoAutorizacion AS T ON T.ID = A.ID_TipoAutorizacion AND T.ID = {ID}")
        For Each item As DataRow In tableCondonacionesTotales.Rows
            TreeCondonacion.Nodes.Add(item("Nombre")).StateImageIndex = 2
        Next

        For Each item As TreeNode In TreeCondonacion.Nodes
            Dim tableItem As DataTable = db.getDataTableFromSQL($"SELECT A.Nombre FROM aut_Cat_Autorizaciones AS A
                                                                  INNER JOIN aut_res_AutClaves AS R ON R.ID_Autorizacion = A.ID
                                                                  INNER JOIN aut_Cat_Claves as C ON C.ID = R.ID_Clave
                                                                  WHERE A.ID_TipoAutorizacion = {ID} AND C.Nombre = '{item.Text}'")
            For Each row As DataRow In tableItem.Rows
                TreeCondonacion.Nodes(0).Nodes.Add(row("Nombre")).StateImageIndex = 2
            Next
        Next

        If (tipoCondonacion = "CONDONACIÓN TOTAL") Then
            ca.buscarCongresos(TreeCondonacion, Matricula, tipoMatricula, "AutCon")
        ElseIf (tipoCondonacion = "CONDONACIÓN PARCIAL") Then
            ca.buscarCongresos(TreeCondonacion, Matricula, tipoMatricula, "AutCon")
        End If
    End Sub

End Class
