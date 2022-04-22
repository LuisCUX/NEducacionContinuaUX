Imports System.ComponentModel

Public Class ModalDatosFiscalesCobrosEDC
    Dim Matricula As String
    Dim IDRegistro As Integer
    Dim RFCDefault As String
    Dim db As DataBaseService = New DataBaseService
    Private Sub ModalDatosFiscalesCobrosEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Matricula = ObjectBagService.getItem("Matricula")
        Dim RFC As String
        Dim tableRFC As DataTable
        If (Matricula.Substring(0, 2) = "EC") Then
            IDRegistro = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroCongreso WHERE clave_cliente = '{Matricula}'")
            RFCDefault = db.exectSQLQueryScalar($"SELECT RFC.rfc FROM portal_catRFC AS RFC
                                                           INNER JOIN portal_rcRFC AS RE ON RE.id_rfc = RFC.id_rfc AND RE.activo = 1 AND RE.id_registro = {IDRegistro}")
            tableRFC = db.getDataTableFromSQL($"SELECT RFC.rfc FROM portal_catRFC AS RFC 
                                                                 INNER JOIN portal_rcRFC AS RC ON RC.id_rfc = RFC.id_rfc
                                                                 WHERE RC.id_registro = {IDRegistro} AND RFC.id_rfc != 2")
            cbRFC.Items.Clear()
            For Each item As DataRow In tableRFC.Rows
                cbRFC.Items.Add(item("rfc"))
            Next
            cbRFC.Text = RFCDefault
            Me.cbRFC_SelectionChangeCommitted(Nothing, Nothing)
        ElseIf (Matricula.Substring(0, 2) = "EX") Then
            IDRegistro = db.exectSQLQueryScalar($"SELECT id_registro FROM portal_registroExterno WHERE clave_cliente = '{Matricula}'")
            RFCDefault = db.exectSQLQueryScalar($"SELECT RFC.rfc FROM portal_catRFC AS RFC
                                                           INNER JOIN portal_reRFC AS RE ON RE.id_rfc = RFC.id_rfc AND RE.activo = 1 AND RE.id_registro = {IDRegistro}")
            tableRFC = db.getDataTableFromSQL($"SELECT RFC.rfc FROM portal_catRFC AS RFC 
                                                                 INNER JOIN portal_reRFC AS RC ON RC.id_rfc = RFC.id_rfc
                                                                 WHERE RC.id_registro = {IDRegistro} AND RFC.id_rfc != 2")
            cbRFC.Items.Clear()
            For Each item As DataRow In tableRFC.Rows
                cbRFC.Items.Add(item("rfc"))
            Next
            cbRFC.Text = RFCDefault
            Me.cbRFC_SelectionChangeCommitted(Nothing, Nothing)
        End If
    End Sub

    Private Sub cbRFC_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbRFC.SelectionChangeCommitted
        Dim tableDatos As DataTable
        If (Matricula.Substring(0, 2) = "EC") Then
            tableDatos = db.getDataTableFromSQL($"SELECT RFC.rfc, RC.direccion, RC.colonia, RC.numero, E.nombre AS NEst, M.nombre AS NMun, RC.localidad, RC.poblacion, RC.razonsocial, RC.correo, RC.telefono, RC.cp, RC.id_res_cfdi_regimen FROM portal_rcRFC AS RC 
                                                                           INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RC.id_rfc
                                                                           INNER JOIN portal_municipio AS M ON M.id_municipio = RC.id_municipio
                                                                           INNER JOIN portal_estado AS E ON E.id_estado = M.id_estado
                                                                           WHERE RC.id_registro = {IDRegistro}  AND RFC.rfc = '{cbRFC.Text}'")
        ElseIf (Matricula.Substring(0, 2) = "EX") Then
            tableDatos = db.getDataTableFromSQL($"SELECT RFC.rfc, RC.direccion, RC.colonia, RC.numero, E.nombre AS NEst, M.nombre AS NMun, RC.localidad, RC.poblacion, RC.razonsocial, RC.correo, RC.telefono, RC.cp, RC.id_res_cfdi_regimen FROM portal_reRFC AS RC 
                                                                           INNER JOIN portal_catRFC AS RFC ON RFC.id_rfc = RC.id_rfc
                                                                           INNER JOIN portal_municipio AS M ON M.id_municipio = RC.id_municipio
                                                                           INNER JOIN portal_estado AS E ON E.id_estado = M.id_estado
                                                                           WHERE RC.id_registro = {IDRegistro}  AND RFC.rfc = '{cbRFC.Text}'")
        End If
        For Each item As DataRow In tableDatos.Rows
            lblRazonSocial.Text = item("razonsocial")
            lblDIreccion.Text = item("direccion")
            lblNumero.Text = item("numero")
            lblColonia.Text = item("colonia")
            lblCP.Text = item("cp")
            lblEstado.Text = item("NEst")
            lblMunicipio.Text = item("NMun")
            lblLocalidad.Text = item("localidad")
            lblPoblacion.Text = item("poblacion")
            lblTelefono.Text = item("telefono")
            lblCorreo.Text = item("correo")
        Next
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim result As DialogResult = MessageBox.Show($"Si sale de esta ventana se usaran los datos fiscales correspondientes al rfc: {RFCDefault} ¿Seguro que quiere salir?", "", MessageBoxButtons.YesNo)
        If (result = 6) Then
            ObjectBagService.setItem("RFCTimbrar", RFCDefault)
            Me.Close()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ObjectBagService.setItem("RFCTimbrar", cbRFC.Text)
        Me.Close()
    End Sub
End Class