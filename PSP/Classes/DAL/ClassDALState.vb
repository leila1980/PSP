Imports Oracle.DataAccess.Client

Public Class ClassDALState
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarStateID As String
    Private mvarName_nvc As String
    Dim dtState As New DataTable

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"
    Public Property StateID() As String
        Get
            Return mvarStateID
        End Get
        Set(ByVal value As String)
            mvarStateID = value
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
#End Region
#Region "Methods"

    Public Function GetAll() As DataTable
        Try
            Dim dtState As New DataTable

            strSQL = "GetAllState_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtState, parRefCursor)
            Return dtState
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllForUCtrl() As DataTable
        Try
            Dim dtState As New DataTable

            strSQL = "GetAllStateForUCtrl_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtState)
            Return dtState
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllStateForUCtrl_ExcludeUser() As DataTable
        Try
            Dim dtState As New DataTable
            'GetAllStateForUCtrl_ExcludeUser_SP
            strSQL = "GetAllStateForUCtrl_ExUser"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtState, parRefCursor)
            Return dtState
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByID() As DataTable
        Try
            Dim dtState As New DataTable

            Dim parStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByIDState_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtState, parStateID, parRefCursor)
            Return dtState
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Insert()
        Try
            Dim parStateID As New OracleParameter("@StateID", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID
            Dim parName_nvc As New OracleParameter("@Name_nvc", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc

            strSQL = "InsertState_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parStateID, parName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update()
        Try
            Dim parStateID As New OracleParameter("@StateID", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID
            Dim parName_nvc As New OracleParameter("@Name_nvc", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc

            strSQL = "UpdateState_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parStateID, parName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim parStateID As New OracleParameter("@StateID", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID

            strSQL = "DeleteState_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parStateID)
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw ex
        End Try
    End Sub
    Public Function GetByMappingCodeStateID(ByVal MappingCode_vc As String) As String
        Try
            Dim parMappingCode_vc As New OracleParameter("@MappingCode_vc", OracleDbType.Varchar2, 10)
            parMappingCode_vc.Value = MappingCode_vc

            strSQL = "GetByMappingCodeState_SP"
            dtState.Clear()
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtState, parMappingCode_vc)
            If dtState.Rows.Count = 1 Then
                Return dtState.Rows(0).Item("StateID").ToString
            Else
                Throw New Exception("Problem with finding StateMappingCode=" & MappingCode_vc)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function




#End Region


#Region "TMS" '---For transaction
    Public Sub ForTMS_TMSTerminal_Insert1(ByVal TERMINAL_ID As String, ByVal SIGNATURE As String, ByVal NAME As String, ByVal REGISTRATION_DATE As DateTime, ByVal TYPE As String, ByVal STATUS As Int32, ByVal CATEGORY As Int32, ByVal DESCRIPTION As String)
        Try
            Dim parTERMINAL_ID As New OracleParameter("@TERMINAL_ID", OracleDbType.Varchar2, 50)
            parTERMINAL_ID.Value = TERMINAL_ID
            Dim parSIGNATURE As New OracleParameter("@SIGNATURE", OracleDbType.Varchar2, 50)
            parSIGNATURE.Value = SIGNATURE
            Dim parNAME As New OracleParameter("@NAME", OracleDbType.Varchar2, 100)
            parNAME.Value = NAME
            Dim parREGISTRATION_DATE As New OracleParameter("@REGISTRATION_DATE", OracleDbType.Varchar2, 10)
            parREGISTRATION_DATE.Value = REGISTRATION_DATE
            Dim parTYPE As New OracleParameter("@TYPE", OracleDbType.Varchar2, 20)
            parTYPE.Value = TYPE
            Dim parSTATUS As New OracleParameter("@STATUS", OracleDbType.Int32)
            parSTATUS.Value = STATUS
            Dim parCATEGORY As New OracleParameter("@CATEGORY", OracleDbType.Int32)
            parCATEGORY.Value = CATEGORY
            Dim parDESCRIPTION As New OracleParameter("@DESCRIPTION", OracleDbType.Varchar2, 200)
            parDESCRIPTION.Value = DESCRIPTION

            Me.Execute_NonQuery(CommandType.StoreProcedure, "ForTMS_TMSTerminal_Insert1", parTERMINAL_ID, parSIGNATURE, parNAME, parREGISTRATION_DATE, parTYPE, parSTATUS, parCATEGORY, parDESCRIPTION)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ForTMS_TMSTerminal_Update_ByTerminalID(ByVal TERMINAL_ID As String, ByVal REGISTRATION_DATE As Date)
        Try
            Dim parTERMINAL_ID As New OracleParameter("@TERMINAL_ID", OracleDbType.Varchar2, 50)
            parTERMINAL_ID.Value = TERMINAL_ID
            Dim parREGISTRATION_DATE As New OracleParameter("@REGISTRATION_DATE", OracleDbType.Varchar2, 10)
            parREGISTRATION_DATE.Value = REGISTRATION_DATE
            Dim parPARENT_ID As New OracleParameter("@PARENT_ID", OracleDbType.Varchar2, 50)
            parPARENT_ID.Value = DBNull.Value


            Me.Execute_NonQuery(CommandType.StoreProcedure, "ForTMS_TMSTerminal_Update_ByTerminalID", parTERMINAL_ID, parREGISTRATION_DATE, parPARENT_ID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ForTMS_TMSTerminal_MAXTerminalID() As DataTable
        Try
            Dim dt As New DataTable


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_MAXTerminalID", dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_TMSTerminal_GetByStateID(ByVal SIGNATURE As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSIGNATURE As New OracleParameter("@SIGNATURE", OracleDbType.Varchar2, 50)
            parSIGNATURE.Value = SIGNATURE


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_GetByStateID", dt, parSIGNATURE)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
