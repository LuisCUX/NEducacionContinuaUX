Public Class LoginEDC
    Dim db As DataBaseService = New DataBaseService()
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnviromentService.setEnviroment()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim ID As Integer = db.exectSQLQueryScalar($"SELECT ID FROM ing_Usuarios WHERE Username = '{txtUsuario.Text}' AND Password = '{txtContraseña.Text}'")
        If (ID > 0) Then
            Dim tableDatosLogin As DataTable = db.getDataTableFromSQL($"SELECT U.Username, U.NUP, UPPER(E.nombre + ' ' + E.apepat + ' ' + E.apemat) AS Nombre, P.Perfil FROM [NEducacionContinua].dbo.ing_Usuarios AS U
                                                                       INNER JOIN [ux].dbo.adm_catEmpleados AS E ON E.nup = U.NUP
                                                                       INNER JOIN [NEducacionContinua].dbo.ing_CatPerfiles AS P ON P.ID = U.ID_Perfil
                                                                       WHERE U.ID = {ID}")
            For Each row As DataRow In tableDatosLogin.Rows
                User.setModel(row("Username"), row("NUP"), row("Nombre"), row("Perfil"))
            Next
            PrincipalView.Show()
            Me.Close()
        Else
            MessageBox.Show("Usario y/o contraseña incorrectos")
            Exit Sub
        End If

    End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub
End Class