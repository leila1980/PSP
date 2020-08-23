Imports Oracle.DataAccess.Client

Public Class ClassDALHelpDesk
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
    Private mvarCallFolowingID As Int64
    Private mvarCallID As Int64
    Private mvarCompleted As Int16
    Private mvarResponsDesc As String
    Private mvarResponseDate_vc As String
    Private mvarResponseTime_vc As String
    Public Function GetCallsResponseDelay(ByVal DateFrom As String, ByVal DateTo As String, ByVal VisitorID As Int32, ByVal WithDelay As Int16, ByVal DelayFromInMin As Int32, ByVal DelayToInMin As Int32, ByVal WorkStart As String, ByVal WorkEnd As String, ByVal ResponseLimitInHourTehran As Int32, ByVal ResponseLimitInHourMarakez As Int32, ByVal ResponseLimitInHourCity As Int32, ByVal ReferTo As Int32, ByVal UserID As Int64, ByVal ProjectID As Int16, ByVal DateType As Byte)
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("DateFrom_", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom

            Dim parDateTo As New OracleParameter("DateTo_", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            Dim parWithDelay As New OracleParameter("WithDelay_", OracleDbType.Int16)
            parWithDelay.Value = IIf(WithDelay = -1, DBNull.Value, WithDelay)

            Dim parDelayFromInMin As New OracleParameter("DelayFromInMin_", OracleDbType.Int32)
            parDelayFromInMin.Value = IIf(DelayFromInMin = -1, DBNull.Value, DelayFromInMin)

            Dim parDelayToInMin As New OracleParameter("DelayToInMin_", OracleDbType.Int32)
            parDelayToInMin.Value = IIf(DelayToInMin = -1, DBNull.Value, DelayToInMin)

            Dim parWorkStart As New OracleParameter("WorkStart_", OracleDbType.Varchar2, 5)
            parWorkStart.Value = WorkStart

            Dim parWorkEnd As New OracleParameter("WorkEnd_", OracleDbType.Varchar2, 5)
            parWorkEnd.Value = WorkEnd

            Dim parResponseLimitInHourTehran As New OracleParameter("ResponseLimitInHourTehran_", OracleDbType.Int32)
            parResponseLimitInHourTehran.Value = IIf(ResponseLimitInHourTehran = -1, DBNull.Value, ResponseLimitInHourTehran)

            Dim parResponseLimitInHourMarakez As New OracleParameter("ResponseLimitInHourMarakez_", OracleDbType.Int32)
            parResponseLimitInHourMarakez.Value = IIf(ResponseLimitInHourMarakez = -1, DBNull.Value, ResponseLimitInHourMarakez)

            Dim parResponseLimitInHourCity As New OracleParameter("ResponseLimitInHourCity_", OracleDbType.Int32)
            parResponseLimitInHourCity.Value = IIf(ResponseLimitInHourCity = -1, DBNull.Value, ResponseLimitInHourCity)


            Dim parReferTo As New OracleParameter("ReferTo_", OracleDbType.Int32)
            parReferTo.Value = ReferTo

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim ParDateType As New OracleParameter("DateType_", OracleDbType.Int16)
            ParDateType.Value = DateType


            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'Dim strSQL As String = "usp_GetCallsResponseDelay"
            Dim strSQL As String = "GetCallsResponseDelaySP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, _
                 parDateFrom, _
                 parDateTo, _
                 parVisitorID, _
                 parWithDelay, _
                 parDelayFromInMin, _
                 parDelayToInMin, _
                 parWorkStart, _
                 parWorkEnd, _
                 parResponseLimitInHourTehran, _
                 parResponseLimitInHourMarakez, _
                 parResponseLimitInHourCity, _
                 parUserID, _
                 ParDateType, _
                 parReferTo, _
                 parProjectID, _
                 parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetByCallsFollowingIDAnCompletedCallsFollowing(ByVal CallFolowingID As Int64, ByVal Completed As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parCallFolowingID As New OracleParameter("CallFolowingID_", OracleDbType.Int64)
            parCallFolowingID.Value = CallFolowingID

            Dim parCompleted As New OracleParameter("Completed_", OracleDbType.Int16)
            parCompleted.Value = Completed

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'GetByCallsFollowingIDAnCompletedCallsFollowing_SP
            Dim strSQL As String = "GtCallFlowIDCmplCallFollowSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCallFolowingID, parCompleted, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByCallIDAndCompletedCallsFolowing(ByVal CallID As Int64, ByVal Completed As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parCallID As New OracleParameter("CallID_", OracleDbType.Int64)
            parCallID.Value = CallID

            Dim parCompleted As New OracleParameter("Completed_", OracleDbType.Int16)
            parCompleted.Value = Completed

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'GetByCallIDAndCompletedCallsFolowing_SP
            Dim strSQL As String = "GtByCallIDCmplCallsFolowingSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCallID, parCompleted, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByCallIDCallsFolowing(ByVal CallID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parCallID As New OracleParameter("CallID_", OracleDbType.Int64)
            parCallID.Value = CallID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Dim strSQL As String = "GetByCallIDCallsFolowing_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCallID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByReferToAndCompletedCallsInfo(ByVal ReferTo As Int32, ByVal Completed As Int16, ByVal UserID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parReferTo As New OracleParameter("ReferTo_", OracleDbType.Int32)
            parReferTo.Value = ReferTo

            Dim parCompleted As New OracleParameter("Completed_", OracleDbType.Int16)
            parCompleted.Value = Completed

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim parIsForAllVisitors As New OracleParameter("IsForAllVisitors_", OracleDbType.Char)
            parIsForAllVisitors.Value = 0

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            ''Dim strSQL As String = "GetByReferTo_CompletCallInfo"
            Dim strSQL As String = "GtReferToCompletedCallsInfoSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parReferTo, parCompleted, parUserID, parIsForAllVisitors, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateCallsInfoForCompleted(ByVal CallID As Int64, ByVal Completed As Int16)
        Try

            Dim parCallID As New OracleParameter("CallID_", OracleDbType.Int64)
            parCallID.Value = CallID

            Dim parCompleted As New OracleParameter("Completed_", OracleDbType.Int16)
            parCompleted.Value = Completed


            Dim strSQL As String = "UpdateCallsInfoForCompleted_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parCallID, parCompleted)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Friend Function DeleteCallsFolowing_SP(ByVal CallFolowingID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parCallFolowingID As New OracleParameter("CallFolowingID_", OracleDbType.Int64)
            parCallFolowingID.Value = CallFolowingID

            Dim strSQL As String = "DeleteCallsFolowing_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCallFolowingID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    'Friend Function GetByTypeReqResDesc(ByVal Type As Int16) As DataTable
    '    Try
    '        Dim dt As New DataTable
    '        Dim parType As New OracleParameter("@Type", OracleDbType.Int16)
    '        parType.Value = Type

    '        Dim strSQL As String = "GetByTypeReqResDesc_SP"
    '        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parType)
    '        Return dt
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Friend Function GetByOnlyTypeReqResDesc(ByVal Type As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parType As New OracleParameter("Type_", OracleDbType.Int16)
            parType.Value = Type

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Dim strSQL As String = "GetByOnlyTypeReqResDesc_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parType, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertCallsFolowing(ByVal CallID As Int64, ByVal Completed As Int16, _
                                        ByVal ResponsDesc As String, ByVal ResponseDate_vc As String, _
                                        ByVal ResponseTime_vc As String, ByVal Description_nvc As String) As Int64
        Try

            Dim parCallID As New OracleParameter("CallID_", OracleDbType.Int64)
            parCallID.Value = CallID

            Dim parCompleted As New OracleParameter("Completed_", OracleDbType.Int16)
            parCompleted.Value = Completed

            Dim parResponsDesc As New OracleParameter("ResponsDesc_", OracleDbType.Varchar2, 500)
            parResponsDesc.Value = ResponsDesc

            Dim parResponseDate As New OracleParameter("ResponseDate_", OracleDbType.Varchar2, 10)
            parResponseDate.Value = ResponseDate_vc

            Dim parResponseTime As New OracleParameter("ResponseTime_", OracleDbType.Varchar2, 5)
            parResponseTime.Value = ResponseTime_vc


            Dim parDescription As New OracleParameter("Description_", OracleDbType.Varchar2, 500)
            parDescription.Value = Description_nvc

            Dim parCallFolowingID As New OracleParameter("CallFolowingID_", OracleDbType.Int64)
            parCallFolowingID.Direction = ParameterDirection.Output

            Dim strSQL As String = "InsertCallsFolowing_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, _
                             parCallID, _
                             parCompleted, _
                             parResponsDesc, _
                             parResponseDate, _
                             parResponseTime, _
                             parDescription, _
                             parCallFolowingID)

            Return Int64.Parse(parCallFolowingID.Value.value)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function UpdateCallsFolowing(ByVal Completed As Int16, ByVal ResponsDesc As String, ByVal ResponseDate_vc As String, ByVal ResponseTime_vc As String, ByVal CallFolowingID As Int64, ByVal Description_nvc As String) As Int64
        Try


            Dim parCompleted As New OracleParameter("Completed_", OracleDbType.Int16)
            parCompleted.Value = Completed

            Dim parResponsDesc As New OracleParameter("ResponsDesc_", OracleDbType.Varchar2, 500)
            parResponsDesc.Value = ResponsDesc

            Dim parResponseDate As New OracleParameter("ResponseDate_", OracleDbType.Varchar2, 10)
            parResponseDate.Value = ResponseDate_vc

            Dim parResponseTime As New OracleParameter("ResponseTime_", OracleDbType.Varchar2, 5)
            parResponseTime.Value = ResponseTime_vc

            Dim parDescription As New OracleParameter("Description_", OracleDbType.Varchar2, 500)
            parDescription.Value = Description_nvc

            Dim parCallFolowingID As New OracleParameter("CallFolowingID_", OracleDbType.Int64)
            parCallFolowingID.Value = CallFolowingID

            Dim strSQL As String = "UpdateCallsFolowing_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, _
                             parCompleted, _
                             parResponsDesc, _
                             parResponseDate, _
                             parResponseTime, _
                             parDescription, _
                             parCallFolowingID)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
