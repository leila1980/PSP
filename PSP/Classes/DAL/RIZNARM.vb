Imports System.Data
Imports Oracle.DataAccess.Client
Imports System.Data.SqlClient


Namespace RIZNARM
    Namespace Data

        Namespace Oracle_Client
#Region "DataAccess"
            Public Class DataAccess
                Protected Shared connection As OracleConnection
                Protected Shared command As OracleCommand
                Protected Shared dataAdapter As OracleDataAdapter
                Protected Shared Transaction As OracleTransaction
                Protected Shared OwnerObject As Integer
                Protected Shared OwnerDataacess As DataAccess

                Private Shared ConnectionString As String
                Private _hasSqlErrorOccured As Boolean

                Public Sub New(ByVal cs As String)
                    If connection Is Nothing Then
                        connection = New OracleConnection(cs)
                        ConnectionString = cs
                    End If
                    ' If ConnectionString <> cs Then
                    '===end proc
                    If OwnerDataacess IsNot Nothing Then
                            OwnerDataacess.EndProc()
                        End If
                        connection.Dispose()
                        connection = Nothing

                        connection = New OracleConnection(cs)
                        ConnectionString = cs
                    'End If

                    If command Is Nothing Then
                        command = New OracleCommand
                    End If
                    If dataAdapter Is Nothing Then
                        dataAdapter = New OracleDataAdapter
                    End If
                    _hasSqlErrorOccured = False
                End Sub
                Public ReadOnly Property HasSqlErrorOccured() As Boolean
                    Get
                        Return Me._hasSqlErrorOccured
                    End Get
                End Property
                Public ReadOnly Property ConnectionState() As ConnectionState
                    Get
                        Return connection.State
                    End Get
                End Property
                Public Sub BeginProc()
                    BeginProc(IsolationLevel.ReadCommitted)
                End Sub
                Public Sub BeginProc(ByVal IsolationLevel As System.Data.IsolationLevel)
                    Me._hasSqlErrorOccured = False
                    Try
                        If connection.State = System.Data.ConnectionState.Closed Then
                            OwnerObject = Me.GetHashCode
                            OwnerDataacess = Me
                            connection.Open()
                            Transaction = connection.BeginTransaction(IsolationLevel)
                            command.Transaction = Transaction
                        End If
                    Catch ex As OracleException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
                Public Sub EndProc()
                    If OwnerObject <> Me.GetHashCode Then
                        Return
                    End If
                    Try

                        If Me.HasSqlErrorOccured Then
                            Transaction.Rollback()
                        Else
                            If (connection.State = ConnectionState.Open) Then
                                Transaction.Commit()
                            End If
                        End If
                    Catch ex As OracleException
                        Throw ex
                    Finally
                        Me.CloseConnection()
                    End Try
                End Sub
                Public Sub CommitProc()
                    If OwnerObject <> Me.GetHashCode Then
                        Return
                    End If
                    Try
                        If (connection.State = ConnectionState.Open) Then
                            Transaction.Commit()
                        End If
                    Catch ex As OracleException
                        Throw ex
                    Finally
                        CloseConnection()
                    End Try
                End Sub
                Public Sub RollBackProc()
                    If OwnerObject <> Me.GetHashCode Then
                        Return
                    End If
                    Try
                        If (connection.State = ConnectionState.Open) Then
                            Transaction.Rollback()
                        End If
                    Catch ex As OracleException
                        Throw ex
                    Finally
                        CloseConnection()
                    End Try
                End Sub
                Private Sub CloseConnection()
                    Try
                        connection.Close()
                    Catch ex As OracleException
                        Throw ex
                    End Try
                End Sub
                Private Function ValidateCommandText(ByVal CommandText As String) As String
                    Return CommandText
                End Function
                Public Enum CommandType
                    StoreProcedure = 4
                    [Text] = 1
                End Enum

                Public Sub Execute_NonQuery(ByVal CommandType As CommandType, ByVal CommandText As String, ByVal ParamArray Parameters As OracleParameter())
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            'command.Parameters.Add(Parameters(i).ParameterName, Parameters(i).OracleDbType, Parameters(i).Direction, Parameters(i).Value)
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.Connection = connection
                        command.CommandTimeout = 0
                        command.CommandType = DirectCast(CommandType, CommandType)
                        command.CommandText = CommandText
                        command.ExecuteNonQuery()
                    Catch ex As OracleException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
                Public Function Execute_Reader(ByVal CommandType As CommandType, ByVal CommandText As String, ByVal ParamArray Parameters As OracleParameter()) As OracleDataReader
                    Dim reader As OracleDataReader = Nothing
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.Connection = connection
                        command.CommandTimeout = 0
                        command.CommandType = DirectCast(CommandType, CommandType)
                        command.CommandText = CommandText
                        reader = command.ExecuteReader
                    Catch ex As Exception
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                    Return reader
                End Function
                Public Function Execute_Scalar(ByVal CommandType As CommandType, ByVal CommandText As String, ByVal NullValue As Object, ByVal ParamArray Parameters As OracleParameter()) As Object
                    Dim obj2 As Object = Nothing
                    Try
                        Dim left As Object = Nothing
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.Connection = connection
                        command.CommandTimeout = 0
                        command.CommandType = DirectCast(CommandType, CommandType)
                        command.CommandText = CommandText

                        left = Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(command.ExecuteScalar)
                        If Information.IsDBNull(Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(left)) Then
                            Return NullValue
                        End If
                        obj2 = left
                    Catch exception1 As InvalidCastException
                        Dim exception As InvalidCastException = exception1
                        obj2 = NullValue
                    Catch exception3 As OracleException
                        Me._hasSqlErrorOccured = True
                        Dim ex As OracleException = exception3
                        Throw ex
                    End Try
                    Return obj2
                End Function
                Public Sub Fill(ByVal CommandType As CommandType, ByVal CommandText As String, ByRef srcDataSet As DataSet, ByVal ParamArray Parameters As OracleParameter())
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.CommandText = CommandText
                        command.CommandTimeout = 0
                        command.Connection = connection
                        command.CommandType = DirectCast(CommandType, CommandType)
                        dataAdapter.SelectCommand = command
                        dataAdapter.Fill(srcDataSet)
                    Catch ex As OracleException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
                Public Sub Fill(ByVal CommandType As CommandType, ByVal CommandText As String, ByRef srcDataTable As DataTable, ByVal ParamArray Parameters As OracleParameter())
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0

                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop

                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If

                        command.CommandText = CommandText
                        command.CommandTimeout = 0
                        command.Connection = connection
                        command.CommandType = DirectCast(CommandType, CommandType)

                        dataAdapter.SelectCommand = command
                        dataAdapter.Fill(srcDataTable)

                    Catch ex As OracleException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
                Public Sub Fill(ByVal CommandType As CommandType, ByVal CommandText As String, ByRef srcDataSet As DataSet, ByVal srcTableName As String, ByVal ParamArray Parameters As OracleParameter())
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.CommandText = CommandText
                        command.CommandTimeout = 0
                        command.Connection = connection
                        command.CommandType = DirectCast(CommandType, CommandType)
                        dataAdapter.SelectCommand = command
                        dataAdapter.Fill(srcDataSet, srcTableName)
                    Catch ex As OracleException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
            End Class
#End Region
        End Namespace

        Namespace SQL_Client
#Region "DataAccess"
            Public Class DataAccess
                Private Shared connection As SqlConnection
                Private Shared command As SqlCommand
                Private Shared dataAdapter As SqlDataAdapter
                Private Shared Transaction As SqlTransaction
                Private Shared OwnerObject As Integer
                Private Shared OwnerDataacess As DataAccess

                Private Shared ConnectionString As String
                Private _hasSqlErrorOccured As Boolean

                Public Sub New(ByVal cs As String)
                    If connection Is Nothing Then
                        connection = New SqlConnection(cs)
                        ConnectionString = cs
                    End If
                    If ConnectionString <> cs Then
                        '===end proc
                        If OwnerDataacess IsNot Nothing Then
                            OwnerDataacess.EndProc()
                        End If
                        connection.Dispose()
                        connection = Nothing

                        connection = New SqlConnection(cs)
                        ConnectionString = cs
                    End If

                    If command Is Nothing Then
                        command = New SqlCommand
                    End If
                    If dataAdapter Is Nothing Then
                        dataAdapter = New SqlDataAdapter
                    End If
                    _hasSqlErrorOccured = False
                End Sub
                Public ReadOnly Property HasSqlErrorOccured() As Boolean
                    Get
                        Return Me._hasSqlErrorOccured
                    End Get
                End Property
                Public ReadOnly Property ConnectionState() As ConnectionState
                    Get
                        Return connection.State
                    End Get
                End Property
                Public Sub BeginProc()
                    BeginProc(IsolationLevel.ReadCommitted)
                End Sub
                Public Sub BeginProc(ByVal IsolationLevel As System.Data.IsolationLevel)
                    Me._hasSqlErrorOccured = False
                    Try
                        If connection.State = System.Data.ConnectionState.Closed Then
                            OwnerObject = Me.GetHashCode
                            OwnerDataacess = Me
                            connection.Open()
                            Transaction = connection.BeginTransaction(IsolationLevel)
                            command.Transaction = Transaction
                        End If
                    Catch ex As SqlException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
                Public Sub EndProc()
                    If OwnerObject <> Me.GetHashCode Then
                        Return
                    End If
                    Try
                        If Me.HasSqlErrorOccured Then
                            Transaction.Rollback()
                        Else
                            If (connection.State = ConnectionState.Open) Then
                                Transaction.Commit()
                            End If
                        End If
                    Catch ex As SqlException
                        Throw ex
                    Finally
                        Me.CloseConnection()
                    End Try
                End Sub
                Public Sub CommitProc()
                    If OwnerObject <> Me.GetHashCode Then
                        Return
                    End If
                    Try
                        If (connection.State = ConnectionState.Open) Then
                            Transaction.Commit()
                        End If
                    Catch ex As SqlException
                        Throw ex
                    Finally
                        CloseConnection()
                    End Try
                End Sub
                Public Sub RollBackProc()
                    If OwnerObject <> Me.GetHashCode Then
                        Return
                    End If
                    Try
                        If (connection.State = ConnectionState.Open) Then
                            Transaction.Rollback()
                        End If
                    Catch ex As SqlException
                        Throw ex
                    Finally
                        CloseConnection()
                    End Try
                End Sub
                Private Sub CloseConnection()
                    Try
                        connection.Close()
                    Catch ex As SqlException
                        Throw ex
                    End Try
                End Sub
                Private Function ValidateCommandText(ByVal CommandText As String) As String
                    Return CommandText
                End Function
                Public Enum CommandType
                    StoreProcedure = 4
                    [Text] = 1
                End Enum
                Public Sub Execute_NonQuery(ByVal CommandType As CommandType, ByVal CommandText As String, ByVal ParamArray Parameters As SqlParameter())
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.Connection = connection
                        command.CommandTimeout = 0
                        command.CommandType = DirectCast(CommandType, CommandType)
                        command.CommandText = CommandText
                        command.ExecuteNonQuery()
                    Catch ex As SqlException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
                Public Function Execute_Reader(ByVal CommandType As CommandType, ByVal CommandText As String, ByVal ParamArray Parameters As SqlParameter()) As SqlDataReader
                    Dim reader As SqlDataReader = Nothing
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.Connection = connection
                        command.CommandTimeout = 0
                        command.CommandType = DirectCast(CommandType, CommandType)
                        command.CommandText = CommandText
                        reader = command.ExecuteReader
                    Catch ex As Exception
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                    Return reader
                End Function
                Public Function Execute_Scalar(ByVal CommandType As CommandType, ByVal CommandText As String, ByVal NullValue As Object, ByVal ParamArray Parameters As SqlParameter()) As Object
                    Dim obj2 As Object = Nothing
                    Try
                        Dim left As Object = Nothing
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.Connection = connection
                        command.CommandTimeout = 0
                        command.CommandType = DirectCast(CommandType, CommandType)
                        command.CommandText = CommandText
                        left = Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(command.ExecuteScalar)
                        If Information.IsDBNull(Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(left)) Then
                            Return NullValue
                        End If
                        obj2 = left
                    Catch exception1 As InvalidCastException
                        Dim exception As InvalidCastException = exception1
                        obj2 = NullValue
                    Catch exception3 As SqlException
                        Me._hasSqlErrorOccured = True
                        Dim ex As SqlException = exception3
                        Throw ex
                    End Try
                    Return obj2
                End Function
                Public Sub Fill(ByVal CommandType As CommandType, ByVal CommandText As String, ByRef srcDataSet As DataSet, ByVal ParamArray Parameters As SqlParameter())
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.CommandText = CommandText
                        command.CommandTimeout = 0
                        command.Connection = connection
                        command.CommandType = DirectCast(CommandType, CommandType)
                        dataAdapter.SelectCommand = command
                        dataAdapter.Fill(srcDataSet)
                    Catch ex As SqlException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
                Public Sub Fill(ByVal CommandType As CommandType, ByVal CommandText As String, ByRef srcDataTable As DataTable, ByVal ParamArray Parameters As SqlParameter())
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.CommandText = CommandText
                        command.CommandTimeout = 0
                        command.Connection = connection
                        command.CommandType = DirectCast(CommandType, CommandType)
                        dataAdapter.SelectCommand = command
                        dataAdapter.Fill(srcDataTable)
                    Catch ex As SqlException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
                Public Sub Fill(ByVal CommandType As CommandType, ByVal CommandText As String, ByRef srcDataSet As DataSet, ByVal srcTableName As String, ByVal ParamArray Parameters As SqlParameter())
                    Try
                        command.Parameters.Clear()
                        Dim upperBound As Integer = Parameters.GetUpperBound(0)
                        Dim i As Integer = 0
                        Do While (i <= upperBound)
                            command.Parameters.Add(Parameters(i))
                            i += 1
                        Loop
                        If (CommandType = CommandType.Text) Then
                            CommandText = Me.ValidateCommandText(CommandText)
                        End If
                        command.CommandText = CommandText
                        command.CommandTimeout = 0
                        command.Connection = connection
                        command.CommandType = DirectCast(CommandType, CommandType)
                        dataAdapter.SelectCommand = command
                        dataAdapter.Fill(srcDataSet, srcTableName)
                    Catch ex As SqlException
                        Me._hasSqlErrorOccured = True
                        Throw ex
                    End Try
                End Sub
            End Class
#End Region
        End Namespace

    End Namespace
End Namespace