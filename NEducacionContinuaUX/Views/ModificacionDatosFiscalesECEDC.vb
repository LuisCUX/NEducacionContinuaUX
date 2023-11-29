Public Class ModificacionDatosFiscalesECEDC
    Dim db As DataBaseService = New DataBaseService()
    Dim vc As ValidacionesController = New ValidacionesController()
    Dim ap As AsignacionPlanesController = New AsignacionPlanesController()
    Dim co As CobrosController = New CobrosController()
    Dim planID As Integer
    Dim Matricula As String
    Dim combo_filtro As String
    Dim combo_filtro2 As String
    Dim combo_filtro3 As String
    Private Sub btnBuscar3_Click(sender As Object, e As EventArgs) Handles btnBuscar3.Click
        Matricula = txtMatricula3.Text
        ap.buscarMatriculaEC(Matricula, panelInfo3, panelModificacion3, txtNombre3, txtEmail3, ComboBox1)
        ComboBox1.DataSource = Nothing
    End Sub

    Private Sub btnCorreo_Click(sender As Object, e As EventArgs) Handles btnCorreo.Click
        If (Matricula = "") Then
            MessageBox.Show("Ingrese una matricula")
            Exit Sub
        End If
        Dim result As DialogResult = MessageBox.Show("Se enviará un correo al email del cliente con un link mediante el cual podrá actualizar sus datos fiscales ¿Desea enviar el correo?", "", MessageBoxButtons.YesNo)
        If (result = 6) Then
            co.enviarCorreoActualizacionDatos(Matricula, "EC")
            Me.Reiniciar()
        Else
            Exit Sub
        End If
    End Sub

    Sub Reiniciar()
        Me.Controls.Clear()
        InitializeComponent()
        ModificacionDatosFiscalesECEDC_Load(Me, Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ModificacionDatosFiscalesECEDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class