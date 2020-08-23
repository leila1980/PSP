Imports Oracle.DataAccess.Client

Public Class ClassDALManagement
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    Private dtManagement As New DataTable

    Private mvarManagementID As String
    Private mvarName_nvc As String
    Private mvarStateID As String
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"
    Public Property ManagementID() As String
        Get
            Return mvarManagementID
        End Get
        Set(ByVal value As String)
            mvarManagementID = value
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
    Public Property StateID() As String
        Get
            Return mvarStateID
        End Get
        Set(ByVal value As String)
            mvarStateID = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Function GetAll() As DataTable
        Try
            Dim dtCity As New DataTable

            strSQL = "GetAllManagement_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity)
            Return dtCity
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllForUCtrl() As DataTable
        Try
            Dim dtCity As New DataTable

            strSQL = "GetAllManagementForUCtrl_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity)
            Return dtCity
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByStateIDForUCtrl() As DataTable
        Try
            Dim dtCity As New DataTable
            Dim parStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'GetByStateIDManagementForUCtrl_SP
            strSQL = "GetByStateIDManagementForUCtrl"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parStateID, parRefCursor)
            Return dtCity
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByStateID() As DataTable
        Try
            Dim dtCity As New DataTable

            Dim parStateID As New OracleParameter("@StateID", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID

            strSQL = "GetByStateIDManagement_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parStateID)
            Return dtCity
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
