Imports Oracle.DataAccess.Client

Public Class ClassDALBranch
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarBranchID As String
    Private mvarName_nvc As String
    Private mvarManagementID As String
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"
    Public Property BranchID() As String
        Get
            Return mvarBranchID
        End Get
        Set(ByVal value As String)
            mvarBranchID = value
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
    Public Property ManagementID() As String
        Get
            Return mvarManagementID
        End Get
        Set(ByVal value As String)
            mvarManagementID = value
        End Set
    End Property

#End Region
#Region "Methods"
    Public Function GetAllFinancialSupervisionIdByEmployerId(ByVal employerID As String) As DataTable
        Try
            Dim dtSupervision As New DataTable

            strSQL = "GetAllfinancialsupervision_SP"

            Dim parMerchantemployerid As New OracleParameter("v_merchantemployerid", OracleDbType.Varchar2, ParameterDirection.Input)
            parMerchantemployerid.Value = employerID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtSupervision, parMerchantemployerid, parRefCursor)
            Return dtSupervision
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMerchantEmployeridByIbanIdentifier(ByVal ibanIdentifier As String) As String
        Try
            Dim dtMerchantEmployer As New DataTable
            Dim employerId As String = String.Empty
            strSQL = "GetMerchantEmployerID_SP"
            Dim paribanidentifiercode As New OracleParameter("v_ibanidentifiercode", OracleDbType.Varchar2, ParameterDirection.Input)
            paribanidentifiercode.Value = ibanIdentifier
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtMerchantEmployer, paribanidentifiercode, parRefCursor)

            If dtMerchantEmployer.Rows.Count > 0 Then
                employerId = dtMerchantEmployer.Rows(0).Item("merchantemployerid")
            Else
                employerId = "21"
            End If
            Return employerId
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAll() As DataTable
        Try
            Dim dtBranch As New DataTable
            strSQL = "GetAllBranch_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtBranch, parRefCursor)
            Return dtBranch
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllTransactionalBranch_ForCbo() As DataTable
        Try
            Dim dtBranch As New DataTable

            strSQL = "GetTransactionalBranch_ForCbo_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtBranch, parRefCursor)
            Return dtBranch
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByID() As DataTable
        Try
            Dim dtBranch As New DataTable

            Dim parBranchID As New OracleParameter("BranchID_", OracleDbType.Varchar2, 7)
            parBranchID.Value = BranchID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)

            strSQL = "GetByIDBranch_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtBranch, parBranchID, parRefCursor)
            Return dtBranch
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByManagementID() As DataTable
        Try
            Dim dtBranch As New DataTable

            Dim parManagementID As New OracleParameter("@ManagementID", OracleDbType.Varchar2, 10)
            parManagementID.Value = ManagementID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)

            strSQL = "GetByManagementIDBranch_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtBranch, parManagementID, parRefCursor)
            Return dtBranch
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Insert()
        Try
            Dim parBranchID As New OracleParameter("@BranchID", OracleDbType.Varchar2, 7)
            parBranchID.Value = BranchID
            Dim parName_nvc As New OracleParameter("@Name_nvc", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc

            strSQL = "InsertBranch_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parBranchID, parName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update()
        Try
            Dim parBranchID As New OracleParameter("@BranchID", OracleDbType.Varchar2, 7)
            parBranchID.Value = BranchID
            Dim parName_nvc As New OracleParameter("@Name_nvc", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc

            strSQL = "UpdateBranch_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parBranchID, parName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim parBranchID As New OracleParameter("BranchID_", OracleDbType.Varchar2, 7)
            parBranchID.Value = BranchID

            strSQL = "DeleteBranch_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parBranchID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function GetAllZones_ForCbo() As DataTable
        Try
            Dim dtZone As New DataTable

            strSQL = "GetAllZone_ForCbo_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtZone)
            Return dtZone
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
