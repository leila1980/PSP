Imports Oracle.DataAccess.Client

Public Class ClassDALVisitor
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarContractID As Int64
    Private mvarVisitorID As Int32
    Private mvarFirstName_nvc As String
    Private mvarLastName_nvc As String
    Private mvarContractDate_vc As String
    Private mvarActiveStatus As Boolean

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"
    Public Property ContractID() As Int64
        Get
            Return mvarContractID
        End Get
        Set(ByVal value As Int64)
            mvarContractID = value
        End Set
    End Property
    Public Property VisitorID() As Int32
        Get
            Return mvarVisitorID
        End Get
        Set(ByVal value As Int32)
            mvarVisitorID = value
        End Set
    End Property
    Public Property FirstName_nvc() As String
        Get
            Return mvarFirstName_nvc
        End Get
        Set(ByVal value As String)
            mvarFirstName_nvc = value
        End Set
    End Property
    Public Property LastName_nvc() As String
        Get
            Return mvarLastName_nvc
        End Get
        Set(ByVal value As String)
            mvarLastName_nvc = value
        End Set
    End Property
    Public Property ContractDate_vc() As String
        Get
            Return mvarContractDate_vc
        End Get
        Set(ByVal value As String)
            mvarContractDate_vc = value
        End Set
    End Property
    Public Property ActiveStatus() As Boolean
        Get
            Return mvarActiveStatus
        End Get
        Set(ByVal value As Boolean)
            mvarActiveStatus = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Function GetVisitorStateByVisitorId(ByVal VisitorId As Integer) As Integer
        Try
            Dim parVisitorId As New OracleParameter("VisitorId_", OracleDbType.Int64)
            parVisitorId.Value = VisitorId
            Dim VisitorState As Integer
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "GetVisitorStateByVisitorId_SP"
            VisitorState = Execute_Scalar(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, Nothing, parVisitorId, parRefCursor)
            Return VisitorState
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAll() As DataTable
        Try
            Dim dtVisitor As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "GetAllVisitor_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtVisitor, parRefCursor)
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function FillVisitor_ForCbo() As DataTable
        Dim CLSUserLoginDA As New ClassUserLoginDataAccess(ConnectionString)
        Try
            Dim dtVisitor As New DataTable
            CLSUserLoginDA.BeginProc()
            Dim _VisitorIDByUser As Int64 = CLSUserLoginDA.GetVisitorIDByUserID(ClassUserLoginDataAccess.ThisUser.UserID)

            If _VisitorIDByUser <> -1 And _VisitorIDByUser <> 0 Then
                dtVisitor = GetVisitor_ForCbo(_VisitorIDByUser)
            Else
                dtVisitor = GetAllVisitor_ForCbo()
            End If
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        Finally
            CLSUserLoginDA.EndProc()
        End Try
    End Function

    Public Function GetUsersVisitorByUserID(ByVal UserID As Int64) As DataTable
        Try
            Dim dtVisitor As New DataTable
            strSQL = "usp_UserVisitorByUserID"

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            parUserID.Value = UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtVisitor, parUserID, parRefCursor)
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetVisitor_ForCbo(ByVal VisitorIDByUser As Int64) As DataTable
        Try
            Dim dtVisitor As New DataTable
            Dim parVisitorID As New OracleParameter(":VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorIDByUser
            strSQL = "SELECT VISITORid,NVL(FirstName_nvc,'') || ' ' ||  NVL(LastName_nvc,'') as FullName_nvc from Visitor_T Where VisitorID=:VisitorID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dtVisitor, parVisitorID)
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllVisitor_ForCbo() As DataTable
        Try
            Dim dtVisitor As New DataTable
            strSQL = "GetAllVisitor_ForCbo_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtVisitor, parRefCursor)
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllVisitor_ForCbo(ByVal UserID As Int32) As DataTable
        Try
            Dim dtVisitor As New DataTable
            strSQL = "GetAllVisitorByUserID_SP"

            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int32)
            parUserID.Value = UserID

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtVisitor, parUserID)
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllVisitorForUctrl_ExcludeUser() As DataTable
        Try
            Dim dtVisitor As New DataTable
            'GetAllVisitorForUctrl_ExcludeUser_SP
            strSQL = "GetAllVisitorForUctrl_ExUser"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtVisitor, parRefCursor)
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByID() As DataTable
        Try
            Dim dtVisitor As New DataTable

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            strSQL = "GetByIDVisitor_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtVisitor, parVisitorID, parRefCursor)
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllVisitorwithAgentName() As DataTable
        Try
            Dim dtVisitor As New DataTable

            strSQL = "GetAllVisitorwithAgentName_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtVisitor, parRefCursor)
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllUserVisitorByUserID(ByVal UserID As Int32) As DataTable
        Try
            Dim dtVisitor As New DataTable
            strSQL = "GetAllUserVisitorByUserID_SP"

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            parUserID.Value = UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtVisitor, parUserID, parRefCursor)
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function Insert() As Int32
        Try
            Dim parFirstName_nvc As New OracleParameter("FirstName_nvc_", OracleDbType.Varchar2, 30)
            parFirstName_nvc.Value = FirstName_nvc

            Dim parLastName_nvc As New OracleParameter("LastName_nvc_", OracleDbType.Varchar2, 50)
            parLastName_nvc.Value = LastName_nvc

            Dim parContractDate_vc As New OracleParameter("ContractDate_vc_", OracleDbType.Varchar2, 10)
            parContractDate_vc.Value = ContractDate_vc

            Dim parActiveState As New OracleParameter("ActiveState_", OracleDbType.Char, 1)
            parActiveState.Value = IIf(ActiveStatus.ToString = True, "1", "0")

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Direction = ParameterDirection.Output

            strSQL = "InsertVisitor_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parFirstName_nvc, parLastName_nvc, parContractDate_vc, parActiveState, parVisitorID)
            Return Convert.ToInt64(parVisitorID.Value.ToString)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update()
        Try
            Dim parFirstName_nvc As New OracleParameter("FirstName_nvc_", OracleDbType.Varchar2, 30)
            parFirstName_nvc.Value = FirstName_nvc

            Dim parLastName_nvc As New OracleParameter("LastName_nvc_", OracleDbType.Varchar2, 50)
            parLastName_nvc.Value = LastName_nvc

            Dim parContractDate_vc As New OracleParameter("ContractDate_vc_", OracleDbType.Varchar2, 10)
            parContractDate_vc.Value = ContractDate_vc

            Dim parActiveState As New OracleParameter("ActiveState_", OracleDbType.Char, 1)
            parActiveState.Value = IIf(ActiveStatus.ToString = True, "1", "0")

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            strSQL = "UpdateVisitor_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parFirstName_nvc, parLastName_nvc, parContractDate_vc, parActiveState, parVisitorID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            strSQL = "DeleteVisitor_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parVisitorID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetAllVisitorByUserID_ForCbo(ByVal UserID As Int64) As DataTable
        Try
            Dim dtVisitor As New DataTable
            strSQL = "usp_UserVisitorByUserID"

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            parUserID.Value = UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtVisitor, parUserID, parRefCursor)
            If dtVisitor.Rows.Count > 1 Then
                Dim dr As DataRow
                dr = dtVisitor.NewRow
                dr("VisitorID") = 0
                dr("FullName") = "نام"
                dr("State") = dtVisitor.Rows(0)("State")
                dtVisitor.Rows.InsertAt(dr, 0)
            End If
            Return dtVisitor
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Public Sub UpdateVisitorInContract()
        Try

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID
          
             Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            strSQL = "UpdateVisitorInContract_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parContractID, parVisitorID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
