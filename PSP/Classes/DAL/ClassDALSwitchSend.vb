Imports Oracle.DataAccess.Client

Public Class ClassDALSwitchSend
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
    Private strSQL As String
    Private mvarSwitch_ModifyID As Int64
    Private mvarSwitch_Modify_DevicelID As Int64
    Private mvarSwitch_CardAcceptorID As String
    Private mvarSwitch_TerminalID As String
    Public Property Switch_TerminalID() As String
        Get
            Return mvarSwitch_TerminalID
        End Get
        Set(ByVal value As String)
            mvarSwitch_TerminalID = value
        End Set
    End Property
    Public Property Switch_ModifyID() As Int64
        Get
            Return mvarSwitch_ModifyID
        End Get
        Set(ByVal value As Int64)
            mvarSwitch_ModifyID = value
        End Set
    End Property
    Public Property Switch_CardAcceptorID() As String
        Get
            Return mvarSwitch_CardAcceptorID
        End Get
        Set(ByVal value As String)
            mvarSwitch_CardAcceptorID = value
        End Set
    End Property
    Public Property Switch_Modify_DevicelID() As Int64
        Get
            Return mvarSwitch_Modify_DevicelID
        End Get
        Set(ByVal value As Int64)
            mvarSwitch_Modify_DevicelID = value
        End Set
    End Property


    Public Function GetBySwitchCardAcceptor_Info(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDSwitch_CardAcceptorID_vc As New OracleParameter("DSwitch_CardAcceptorID_vc_", OracleDbType.Varchar2, 15)
            parDSwitch_CardAcceptorID_vc.Value = Switch_CardAcceptorID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBySwitchCardAcceptor_Info"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDSwitch_CardAcceptorID_vc, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBySwitchTerminal_Info(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDSwitch_TerminalID_vc As New OracleParameter("DSwitch_TerminalID_vc_", OracleDbType.Varchar2, 8)
            parDSwitch_TerminalID_vc.Value = Switch_TerminalID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBySwitchTerminal_Info_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDSwitch_TerminalID_vc, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByCMSSwitchTerminal_Info(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parOutlet_vc As New OracleParameter("@DCMSOutlet", OracleDbType.Varchar2, 15)
            parOutlet_vc.Value = Switch_TerminalID

            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            strSQL = "GetByCMSSwitchTerminal_Info_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parOutlet_vc, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ForWebPos_UpdateWebPos_SP(ByVal Content_nvc As String, ByVal senttowebpos_Tint As Integer)
        Try

            Dim dt As New DataTable
            Dim _clsDate As New ClassDalDate(ConnectionString)

            Dim senttowebpos_Tint_ As New OracleParameter("Senttowebpos_Tint_", OracleDbType.Int32)
            senttowebpos_Tint_.Value = senttowebpos_Tint

            Dim sentDate_vc_ As New OracleParameter("SentDate_vc_", OracleDbType.Varchar2)
            sentDate_vc_.Value = _clsDate.GetPersianDateNow()

            Dim content_nvc_ As New OracleParameter("CONTENT_NVC_", OracleDbType.Varchar2)
            content_nvc_.Value = Content_nvc

            strSQL = "ForWebPos_UpdateWebPos_SP"

            connection.Open()
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, senttowebpos_Tint_, sentDate_vc_, content_nvc_)
            connection.Close()

        Catch ex As Exception

            Throw ex

        End Try

    End Sub

    Public Function ForWebPos_Modify_Device_Update_GetAllNotSentWebPos(ByVal ProjectID As Int16) As DataTable
        Try

            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "ForWebPos_Mod_ChngNoSntSwCMS"

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)

            Return dt

        Catch ex As Exception

            Throw ex

        End Try

    End Function

    Public Function ForWebPos_Modify_Device_Cancel_GetAllNotSentWebPos(ByVal ProjectID As Int16) As DataTable
        Try

            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "ForWebPos_Modify_CancelCMS"

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)

            Return dt

        Catch ex As Exception

            Throw ex

        End Try

    End Function


    Public Function ForSwitch_Modify_Device_Cancel_GetAllNotSentSwith(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'ForSwitch_Modify_Device_Cancel_GetAllNotSentSwith_SP
            'strSQL = "ForSwitch_Modify_Device_Cancel"
            strSQL = "ForSwitch_Modify_CancelCMS"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            'Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception

            Throw ex
        End Try

    End Function
    Public Function ForWebPos_Modify_Device_PosChange_GetAllNotSentSwith(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'ForSwitch_Modify_Device_PosChange_GetAllNotSentSwith_SP
            strSQL = "ForSwitch_Mod_ChngNoSntSwCMS"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function ForWebPos_Modify_Device_PosChange_GetAllNotSentWebPos(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "ForWebPos_Mod_ChngNoSntSwCMS"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function ForSwitch_Modify_Device_PosChange_GetAllNotSentSwith(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "ForSwitch_Mod_ChngNoSntSwCMS"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ForSwitch_Modify_Device_Cancel_GetAllNotSentToSinaSwith(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''ForSwitch_Modify_Device_Cancel_GetAllNotSentToSinaSwith_SP
            strSQL = "ForSwitch_Mod_Dev_Can_ToSina"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function ForSwitch_Modify_Device_PosChange_GetAllNotSentToSinaSwith(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'ForSwitch_Modify_Device_PosChange_GetAllNotSentToSinaSwith_SP
            strSQL = "ForSwitch_Mod_ChngNoSntSINASw"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub Update_Switch_Modify_Sent()
        Try
            Dim parSwitch_ModifyID As New OracleParameter("Switch_ModifyID_", OracleDbType.Int64)
            parSwitch_ModifyID.Value = Switch_ModifyID
            Dim parSentDate_vc As New OracleParameter("SentDate_vc_", OracleDbType.Varchar2, 10)
            parSentDate_vc.Value = GetDateNow()

            strSQL = "Update_Switch_Modify_Sent_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_ModifyID, parSentDate_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Update_Switch_Modify_Device_Sent()
        Try
            Dim parSwitch_Modify_DevicelID As New OracleParameter("Switch_Modify_DeviceID_", OracleDbType.Int64)
            parSwitch_Modify_DevicelID.Value = Switch_Modify_DevicelID
            Dim parSentDate_vc As New OracleParameter("SentDate_vc_", OracleDbType.Varchar2, 10)
            parSentDate_vc.Value = GetDateNow()
            'Update_Switch_Modify_Device_Sent_SP
            strSQL = "Update_Switch_Mod_Dev_Sent_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_Modify_DevicelID, parSentDate_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Update_Switch_Modify_AfterSendToSina()
        Try
            Dim parSwitch_ModifyID As New OracleParameter("@Switch_ModifyID", OracleDbType.Int64)
            parSwitch_ModifyID.Value = Switch_ModifyID

            strSQL = "Update_Switch_Modify_AfterSendToSina_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_ModifyID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update_Switch_Modify_Device_AfterSendToSina()
        Try
            Dim parSwitch_Modify_DevicelID As New OracleParameter("Switch_Modify_DeviceID_", OracleDbType.Int64)
            parSwitch_Modify_DevicelID.Value = Switch_Modify_DevicelID

            'Update_Switch_Modify_Device_AfterSendToSina_SP
            strSQL = "UpdateSwtch_M_Dev_SndToSina_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_Modify_DevicelID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
