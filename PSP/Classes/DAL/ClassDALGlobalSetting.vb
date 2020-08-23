Imports Oracle.DataAccess.Client

Public Class ClassDALGlobalSetting
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
    Private mvarID As Int32
    Private mvarName_nvc As String
    Private mvarValue_nvc As String
    Private mvarType_tint As Int16
    Public Property ID() As Int32
        Get
            Return mvarID
        End Get
        Set(ByVal value As Int32)
            mvarID = value
        End Set
    End Property
    Public Property Name_nvc() As String
        Get
            Return mvarName_nvc
        End Get
        Set(ByVal value As String)
            mvarName_nvc = value
        End Set
    End Property
    Public Property Value_nvc() As String
        Get
            Return mvarValue_nvc
        End Get
        Set(ByVal value As String)
            mvarValue_nvc = value
        End Set
    End Property
    Public Property Type_tint() As Int16
        Get
            Return mvarType_tint
        End Get
        Set(ByVal value As Int16)
            mvarType_tint = value
        End Set
    End Property
    Public Enum GlobalSettingEnum As Short
        WaitForVisit = 1
    End Enum
    Public Function InsertGlobalSetting() As Int64
        Try
            Dim parName_nvc As New OracleParameter("@Name_nvc", OracleDbType.Varchar2, 50)
            parName_nvc.Value = Name_nvc
            Dim parValue_nvc As New OracleParameter("@Value_nvc", OracleDbType.Varchar2, 50)
            parValue_nvc.Value = Value_nvc
            Dim parType_tint As New OracleParameter("@Type_tint", OracleDbType.Int16)
            parType_tint.Value = Type_tint
            Dim parID As New OracleParameter("@ID", OracleDbType.Int32)
            parID.Direction = ParameterDirection.Output

            Dim strSQL As String = "InsertGlobalSetting_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parName_nvc, parValue_nvc, parType_tint, parID)
            Return parID.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllGlobalSetting() As DataTable
        Try
            Dim dt As New DataTable

            Dim strSQL As String = "GetAllGlobalSetting_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByTypeGlobalSetting() As DataTable
        Try
            Dim dt As New DataTable

            Dim parType_tint As New OracleParameter("@Type_tint", OracleDbType.Int16)
            parType_tint.Value = Type_tint

            Dim strSQL As String = "GetByTypeGlobalSetting_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteAllGlobalSetting()
        Try
            Dim dt As New DataTable

            Dim strSQL As String = "DeleteAllGlobalSetting_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
