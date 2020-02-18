Imports System.Data.SqlClient

Public Class DataBaseService
    Private conector As SqlConnection = New SqlConnection()
    Private sqlCommand As SqlCommand = New SqlCommand()
    Private transaction As Boolean = False

    ''-----EJECUTA QUERY SCALAR-----''
    Public Function exectSQLQueryScalar(query As String) As Object
        Try
            Me.ForzarConexion()

            Me.sqlCommand.CommandText = query

            Return Me.sqlCommand.ExecuteScalar()

        Catch ex As Exception
            Throw New Exception($"Error al ejecutar Query - DataBaseBridge.exectSQLQueryScalar() - Error Interno: {ex.Message}")
            Return Nothing
        Finally
            Me.closeConection()
        End Try
    End Function

    ''-----EJECUTA QUERY SIN PARAMETROS-----''
    Public Sub execSQLQueryWithoutParams(query As String)
        Try
            Me.ForzarConexion()
            Me.sqlCommand.CommandText = query
            Me.sqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception($"Error al ejecutar Query - DataBaseBridge.execSQLQueryWithoutParams() - Error Interno: {ex.Message}")
        Finally
            Me.closeConection()
        End Try
    End Sub

    ''-----OBTIENE DATATABLE DE UN QUERY-----
    Public Function getDataTableFromSQL(selectQuery As String) As DataTable
        Try
            Dim data As New DataSet()
            Me.ForzarConexion()
            Me.sqlCommand.CommandText = selectQuery
            Dim adapter As New SqlDataAdapter(Me.sqlCommand)
            adapter.Fill(data)
            Return data.Tables(0)
        Catch ex As Exception
            Throw New Exception($"Error al ejecutar Query - DataBaseBridge.getDataTableFromSQL() - Error Interno: {ex.Message}")
            Return Nothing
        Finally
            Me.closeConection()
        End Try
    End Function

    ''-----INSERTA Y OBTIENE ID INSERTADO-----
    Public Function insertAndGetIDInserted(query As String) As Integer
        Try
            Me.ForzarConexion()
            Me.sqlCommand.CommandText = $"{query};SELECT @@IDENTITY"
            Dim id = Me.sqlCommand.ExecuteScalar()
            Return id
        Catch ex As Exception
            Throw New Exception($"Error al ejecutar Query - DataBaseBridge.insertAndGetIDInserted() - Error Interno: {ex.Message}")
            Return -1
        Finally
            Me.closeConection()
        End Try
    End Function

    ''-----COMIENZA UNA TRANSACCION
    Public Sub startTransaction()
        Me.ForzarConexion()
        Me.sqlCommand.Transaction = Me.conector.BeginTransaction()
        transaction = True
    End Sub

    ''-----COMMIT DE TRANSACCION INICIADA
    Public Sub commitTransaction()
        Me.sqlCommand.Transaction.Commit()
        Me.closeConection()
        Me.sqlCommand.Parameters.Clear()
        Me.sqlCommand.Dispose()
        transaction = False
    End Sub

    ''-----ROLLBACK DE TRANSACCION INICIADA
    Public Sub rollBackTransaction()
        Me.sqlCommand.Transaction.Rollback()
        Me.closeConection()
        Me.sqlCommand.Parameters.Clear()
        Me.sqlCommand.Dispose()
    End Sub

    Private Sub Start()
        Me.conector.ConnectionString = EnviromentService.connectionString
        Me.conector.Open()
        sqlCommand.Connection = Me.conector
    End Sub

    Private Sub ForzarConexion()
        If IsNothing(Me.sqlCommand.Connection) Then
            Me.Start()
            Me.sqlCommand.Connection = Me.conector
        Else
            If Me.sqlCommand.Connection.State = ConnectionState.Closed Then
                Me.Start()
                Me.sqlCommand.Connection = Me.conector
            End If
        End If
    End Sub

    Private Sub closeConection()
        If Not Me.transaction Then
            If IsNothing(Me.sqlCommand.Transaction) Then
                Me.Close()
                Me.sqlCommand.Dispose()
            End If
        End If
    End Sub

    Private Sub Close()
        Me.conector.Close()
    End Sub
End Class
