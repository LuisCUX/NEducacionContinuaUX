Imports System.Data.SqlClient

Public Class DataBaseService
    Private conector As SqlConnection = New SqlConnection()
    Private sqlCommand As SqlCommand = New SqlCommand()

    ''-----EJECUTA QUERY SCALAR-----''
    Public Function exectSQLQueryScalar(query As String) As Object
        Try
            Me.Start()

            Me.sqlCommand.CommandText = query

            Return Me.sqlCommand.ExecuteScalar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        Finally
            Me.Close()
        End Try
    End Function

    ''-----EJECUTA QUERY SIN PARAMETROS-----''
    Public Sub execSQLQueryWithoutParams(query As String)
        Try
            Me.Start()
            Me.sqlCommand.CommandText = query
            Me.sqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Me.Close()
        End Try
    End Sub

    ''-----OBTIENE DATATABLE DE UN QUERY-----
    Public Function getDataTableFromSQL(selectQuery As String) As DataTable
        Try
            Dim data As New DataSet()
            Me.Start()
            Me.sqlCommand.CommandText = selectQuery
            Dim adapter As New SqlDataAdapter(Me.sqlCommand)
            adapter.Fill(data)
            Return data.Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Nothing
        Finally
            Me.Close()
        End Try
    End Function

    Private Sub Start()
        Me.conector.ConnectionString = EnviromentService.connectionString
        Me.conector.Open()
        sqlCommand.Connection = Me.conector
    End Sub

    Private Sub Close()
        Me.conector.Close()
    End Sub
End Class
