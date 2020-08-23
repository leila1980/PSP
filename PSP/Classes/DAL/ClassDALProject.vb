Imports Oracle.DataAccess.Client
Public Class ClassDALProject
    Inherits RIZNARM.Data.Oracle_Client.DataAccess

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

    Private strSQL As String
    Private mvarProjectID As Int16
    Private mvarName_nvc As String

    Public Property ProjectID()
        Get
            Return (mvarProjectID)
        End Get
        Set(ByVal value)
            mvarProjectID = value
        End Set
    End Property

    Public Property Name_nvc()
        Get
            Return (mvarName_nvc)
        End Get
        Set(ByVal value)
            mvarName_nvc = value
        End Set
    End Property

    Public Function GetAll() As DataTable
        Try
            Dim dt As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, "GetAllProject_SP", dt, parRefCursor)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAll(ByVal UserID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, "GetAllProject_ByUserID_SP", dt, parUserID, parRefCursor)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllForUCtrl(ByVal UserID As Int64)
        Try
            Dim dt As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, "GetAllProjectForUCtrl_SP", dt, parUserID, parRefCursor)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function GetAllCMSProject() As DataTable
        Try
            Dim dt As New DataTable
            Dim strSql As String = "select * from cmsproject_t"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
