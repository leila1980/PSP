Imports System.Data
Imports Oracle.DataAccess.Client

Public Class ClassDALReport
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

#Region "Methods"
    Public Function GetPazirandehInfoByEniacCode(ByVal EniacCode As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parEniacCode As New OracleParameter("EniacCode_", OracleDbType.Varchar2, 20)
            parEniacCode.Value = EniacCode

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'strSQL = "usp_GetPazirandehInfoByEniacCode"
            strSQL = "GtPazirandehInfoByEniacCodeSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parEniacCode, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetPazirandehInfoBySerial(ByVal Serial As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parSerial As New OracleParameter("Serial_", OracleDbType.Varchar2, 20)
            parSerial.Value = Serial

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'strSQL = "usp_GetPazirandehInfoBySerial"
            strSQL = "GtPazirandehInfoBySerialSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSerial, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetPazirandehInfoByPayaneh(ByVal Payaneh As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parPayaneh As New OracleParameter("Payaneh_", OracleDbType.Varchar2, 8)
            parPayaneh.Value = Payaneh

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'strSQL = "usp_GetPazirandehInfoByPayaneh"
            strSQL = "GtPazirandehInfoByPayanehSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPayaneh, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetVisitTransactionsInDetailPerPayaneh(ByVal Payaneh As String, ByVal DateTo As String, ByVal MaxPrice As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parPayaneh As New OracleParameter("@Payaneh", OracleDbType.Varchar2, 8)
            parPayaneh.Value = Payaneh
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parMaxPrice As New OracleParameter("@MaxPrice", OracleDbType.Decimal, 18)
            parMaxPrice.Value = IIf(MaxPrice.Trim = String.Empty, DBNull.Value, MaxPrice.Trim)


            strSQL = "usp_GetVisitTransactionsInDetailPerPayaneh"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPayaneh, parDateTo, parMaxPrice)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByTypeVisitAmout(ByVal Type As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parType As New OracleParameter("@Type", OracleDbType.Int16)
            parType.Value = Type

            strSQL = "usp_GetByTypeVisitAmout"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parType)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNoConfirmedInstallDetailByVisitorIDAndDate(ByVal DateTo As String, ByVal VisitorID As Int32, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetNoConfirmedInstallDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateTo, parVisitorID, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNoInstalledDetailByVisitorIDAndDate(ByVal DateTo As String, ByVal VisitorID As Int32, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetNoInstalledDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateTo, parVisitorID, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNoConfigedDetailByVisitorIDAndDate(ByVal DateTo As String, ByVal VisitorID As Int32, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID
            strSQL = "usp_GetNoConfigedDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateTo, parVisitorID, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNoTakhsisDetailByVisitorIDAndDate(ByVal DateTo As String, ByVal VisitorID As Int32, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID
            strSQL = "usp_GetNoTakhsisDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateTo, parVisitorID, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetInstalledAndConfirmedInstallDetailByVisitorIDAndDate(ByVal DateFrom As String, ByVal DateTo As String, ByVal VisitorID As Int32, ByVal DateConditition As Int16, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parDateConditition As New OracleParameter("@DateConditition", OracleDbType.Int16)
            parDateConditition.Value = DateConditition
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetInstalledAndConfirmedInstallDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parVisitorID, parDateConditition, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCanceledAndInstalledDetailByVisitorIDAndDate(ByVal DateFrom As String, ByVal DateTo As String, ByVal VisitorID As Int32, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetCanceledAndInstalledDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parVisitorID, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCanceledDetailByVisitorIDAndDate(ByVal DateFrom As String, ByVal DateTo As String, ByVal VisitorID As Int32, ByVal DateConditition As Int16, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parDateConditition As New OracleParameter("@DateConditition", OracleDbType.Int16)
            parDateConditition.Value = DateConditition
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetCanceledDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parVisitorID, parDateConditition, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetInstalledDetailByVisitorIDAndDate(ByVal DateFrom As String, ByVal DateTo As String, ByVal VisitorID As Int32, ByVal DateConditition As Int16, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parDateConditition As New OracleParameter("@DateConditition", OracleDbType.Int16)
            parDateConditition.Value = DateConditition
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetInstalledDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parVisitorID, parDateConditition, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetConfigedDetailByVisitorIDAndDate(ByVal DateFrom As String, ByVal DateTo As String, ByVal VisitorID As Int32, ByVal DateConditition As Int16, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parDateConditition As New OracleParameter("@DateConditition", OracleDbType.Int16)
            parDateConditition.Value = DateConditition
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetConfigedDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parVisitorID, parDateConditition, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTakhsisDetailByVisitorIDAndDate(ByVal DateFrom As String, ByVal DateTo As String, ByVal VisitorID As Int32, ByVal DateConditition As Int16, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parDateConditition As New OracleParameter("@DateConditition", OracleDbType.Int16)
            parDateConditition.Value = DateConditition
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetTakhsisDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parVisitorID, parDateConditition, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetContractDetailByVisitorIDAndDate(ByVal DateFrom As String, ByVal DateTo As String, ByVal VisitorID As Int32, ByVal AccountIncluded As Int16, ByVal DateConditition As Int16, ByVal ProjectID As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parAccountIncluded As New OracleParameter("@AccountIncluded", OracleDbType.Int16)
            parAccountIncluded.Value = AccountIncluded
            Dim parDateConditition As New OracleParameter("@DateConditition", OracleDbType.Int16)
            parDateConditition.Value = DateConditition
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetContractDetailByVisitorIDAndDate"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parVisitorID, parAccountIncluded, parDateConditition, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAgentActivities(ByVal DateFrom As String, ByVal DateTo As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID

            strSQL = "usp_GetAgentActivities"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parUserID, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PeriodicVisit_BasedOnInstall(ByVal DateFrom As String, ByVal DateTo As String, ByVal Month As Int32, ByVal MaxPrice As String, ByVal NegativeTelorance As Int16, ByVal PositiveTelorance As Int16, ByVal CutCorrectPeriod As Boolean, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parMonth As New OracleParameter("@Month", OracleDbType.Int32)
            parMonth.Value = Month
            Dim parMaxPrice As New OracleParameter("@MaxPrice", OracleDbType.Decimal, 18)
            parMaxPrice.Value = IIf(MaxPrice.Trim = String.Empty, DBNull.Value, MaxPrice.Trim)
            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parNegativeTelorance As New OracleParameter("@NegativeTelorance", OracleDbType.Int16)
            parNegativeTelorance.Value = NegativeTelorance
            Dim parPositiveTelorance As New OracleParameter("@PositiveTelorance", OracleDbType.Int16)
            parPositiveTelorance.Value = PositiveTelorance
            Dim parCutCorrectPeriod As New OracleParameter("@CutCorrectPeriod", OracleDbType.Int32)
            parCutCorrectPeriod.Value = CutCorrectPeriod
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID



            strSQL = "usp_PeriodicVisit_BasedOnInstall"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parMonth, parMaxPrice, parUserID, parNegativeTelorance, parPositiveTelorance, parCutCorrectPeriod, parProjectId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PeriodicVisit_BasedOnInstall_NoVisit(ByVal DateFrom As String, ByVal DateTo As String, ByVal Month As Int32, ByVal MaxPrice As String, ByVal NegativeTelorance As Int16, ByVal PositiveTelorance As Int16, ByVal CutCorrectPeriod As Boolean, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parMonth As New OracleParameter("@Month", OracleDbType.Int32)
            parMonth.Value = Month
            Dim parMaxPrice As New OracleParameter("@MaxPrice", OracleDbType.Decimal, 18)
            parMaxPrice.Value = IIf(MaxPrice.Trim = String.Empty, DBNull.Value, MaxPrice.Trim)
            Dim parNegativeTelorance As New OracleParameter("@NegativeTelorance", OracleDbType.Int16)
            parNegativeTelorance.Value = NegativeTelorance
            Dim parPositiveTelorance As New OracleParameter("@PositiveTelorance", OracleDbType.Int16)
            parPositiveTelorance.Value = PositiveTelorance
            Dim parCutCorrectPeriod As New OracleParameter("@CutCorrectPeriod", OracleDbType.Int32)
            parCutCorrectPeriod.Value = CutCorrectPeriod
            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            strSQL = "usp_PeriodicVisit_BasedOnInstall_NoVisit"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parMonth, parMaxPrice, parUserID, parNegativeTelorance, parPositiveTelorance, parCutCorrectPeriod, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PeriodicVisit_BasedOnLastVisit(ByVal DateFrom As String, ByVal DateTo As String, ByVal Month As Int32, ByVal MaxPrice As String, ByVal NegativeTelorance As Int16, ByVal PositiveTelorance As Int16, ByVal CutCorrectPeriod As Boolean, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parMonth As New OracleParameter("@Month", OracleDbType.Int32)
            parMonth.Value = Month
            Dim parMaxPrice As New OracleParameter("@MaxPrice", OracleDbType.Decimal, 18)
            parMaxPrice.Value = IIf(MaxPrice.Trim = String.Empty, DBNull.Value, MaxPrice.Trim)
            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parProjectId As New OracleParameter("@ProjectId", OracleDbType.Int32)
            parProjectId.Value = ProjectID
            Dim parNegativeTelorance As New OracleParameter("@NegativeTelorance", OracleDbType.Int16)
            parNegativeTelorance.Value = NegativeTelorance
            Dim parPositiveTelorance As New OracleParameter("@PositiveTelorance", OracleDbType.Int16)
            parPositiveTelorance.Value = PositiveTelorance
            Dim parCutCorrectPeriod As New OracleParameter("@CutCorrectPeriod", OracleDbType.Int32)
            parCutCorrectPeriod.Value = CutCorrectPeriod

            strSQL = "usp_PeriodicVisit_BasedOnLastVisit"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parMonth, parMaxPrice, parUserID, parProjectId, parNegativeTelorance, parPositiveTelorance, parCutCorrectPeriod)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PeriodicVisit_BasedOnLastVisit_NoVisit(ByVal DateFrom As String, ByVal DateTo As String, ByVal Month As Int32, ByVal MaxPrice As String, ByVal NegativeTelorance As Int16, ByVal PositiveTelorance As Int16, ByVal CutCorrectPeriod As Boolean, ByVal ProjectID As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parMonth As New OracleParameter("@Month", OracleDbType.Int32)
            parMonth.Value = Month
            Dim parMaxPrice As New OracleParameter("@MaxPrice", OracleDbType.Decimal, 18)
            parMaxPrice.Value = IIf(MaxPrice.Trim = String.Empty, DBNull.Value, MaxPrice.Trim)
            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parNegativeTelorance As New OracleParameter("@NegativeTelorance", OracleDbType.Int16)
            parNegativeTelorance.Value = NegativeTelorance
            Dim parPositiveTelorance As New OracleParameter("@PositiveTelorance", OracleDbType.Int16)
            parPositiveTelorance.Value = PositiveTelorance
            Dim parCutCorrectPeriod As New OracleParameter("@CutCorrectPeriod", OracleDbType.Int32)
            parCutCorrectPeriod.Value = CutCorrectPeriod

            strSQL = "usp_PeriodicVisit_BasedOnLastVisit_NoVisit"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parMonth, parMaxPrice, parUserID, parProjectID, parNegativeTelorance, parPositiveTelorance, parCutCorrectPeriod)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PeriodicVisit_BasedOnVisitBase(ByVal DateFrom As String, ByVal DateTo As String, ByVal Month As Int32, ByVal MaxPrice As String, ByVal NegativeTelorance As Int16, ByVal PositiveTelorance As Int16, ByVal CutCorrectPeriod As Boolean, ByVal VisitBaseDateFrom As String, ByVal VisitBaseDateTo As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parMonth As New OracleParameter("@Month", OracleDbType.Int32)
            parMonth.Value = Month
            Dim parMaxPrice As New OracleParameter("@MaxPrice", OracleDbType.Decimal, 18)
            parMaxPrice.Value = IIf(MaxPrice.Trim = String.Empty, DBNull.Value, MaxPrice.Trim)
            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parNegativeTelorance As New OracleParameter("@NegativeTelorance", OracleDbType.Int16)
            parNegativeTelorance.Value = NegativeTelorance
            Dim parPositiveTelorance As New OracleParameter("@PositiveTelorance", OracleDbType.Int16)
            parPositiveTelorance.Value = PositiveTelorance
            Dim parCutCorrectPeriod As New OracleParameter("@CutCorrectPeriod", OracleDbType.Int32)
            parCutCorrectPeriod.Value = CutCorrectPeriod
            Dim parVisitBaseDateFrom As New OracleParameter("@VisitBaseDateFrom", OracleDbType.Varchar2, 10)
            parVisitBaseDateFrom.Value = VisitBaseDateFrom
            Dim parVisitBaseDateTo As New OracleParameter("@VisitBaseDateTo", OracleDbType.Varchar2, 10)
            parVisitBaseDateTo.Value = VisitBaseDateTo

            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID


            strSQL = "usp_PeriodicVisit_BasedOnVisitBase"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parMonth, parMaxPrice, parUserID, parNegativeTelorance, parPositiveTelorance, parCutCorrectPeriod, parVisitBaseDateFrom, parVisitBaseDateTo, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function PeriodicVisit_BasedOnVisitBase_NoVisit(ByVal DateFrom As String, ByVal DateTo As String, ByVal Month As Int32, ByVal MaxPrice As String, ByVal NegativeTelorance As Int16, ByVal PositiveTelorance As Int16, ByVal CutCorrectPeriod As Boolean, ByVal VisitBaseDateFrom As String, ByVal VisitBaseDateTo As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom
            Dim parDateTo As New OracleParameter("@DateTo", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo
            Dim parMonth As New OracleParameter("@Month", OracleDbType.Int32)
            parMonth.Value = Month
            Dim parMaxPrice As New OracleParameter("@MaxPrice", OracleDbType.Decimal, 18)
            parMaxPrice.Value = IIf(MaxPrice.Trim = String.Empty, DBNull.Value, MaxPrice.Trim)
            Dim parNegativeTelorance As New OracleParameter("@NegativeTelorance", OracleDbType.Int16)
            parNegativeTelorance.Value = NegativeTelorance
            Dim parPositiveTelorance As New OracleParameter("@PositiveTelorance", OracleDbType.Int16)
            parPositiveTelorance.Value = PositiveTelorance
            Dim parCutCorrectPeriod As New OracleParameter("@CutCorrectPeriod", OracleDbType.Int32)
            parCutCorrectPeriod.Value = CutCorrectPeriod
            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parVisitBaseDateFrom As New OracleParameter("@VisitBaseDateFrom", OracleDbType.Varchar2, 10)
            parVisitBaseDateFrom.Value = VisitBaseDateFrom
            Dim parVisitBaseDateTo As New OracleParameter("@VisitBaseDateTo", OracleDbType.Varchar2, 10)
            parVisitBaseDateTo.Value = VisitBaseDateTo

            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID


            strSQL = "usp_PeriodicVisit_BasedOnVisitBase_NoVisit"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDateFrom, parDateTo, parMonth, parMaxPrice, parUserID, parNegativeTelorance, parPositiveTelorance, parCutCorrectPeriod, parVisitBaseDateFrom, parVisitBaseDateTo, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllTransactionsInDetail(ByVal FromDate As String, ByVal ToDate As String, ByVal VisitorID As Int32, ByVal ManagementID As String, ByVal BranchID As String, ByVal AccountNO_vc As String, ByVal Payaneh As String, ByVal Vocher As Int16, ByVal Sale As Int16, ByVal Bill As Int16, ByVal Mojudi As Int16, ByVal AuthorizationState As Int16, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parFromDate As New OracleParameter("@FromDate", OracleDbType.Varchar2, 10)
            parFromDate.Value = FromDate
            Dim parToDate As New OracleParameter("@ToDate", OracleDbType.Varchar2, 10)
            parToDate.Value = ToDate
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parManagementID As New OracleParameter("@ManagementID", OracleDbType.Varchar2, 10)
            parManagementID.Value = ManagementID
            Dim parBranchID As New OracleParameter("@BranchID", OracleDbType.Varchar2, 6)
            parBranchID.Value = BranchID
            Dim parAccountNO_vc As New OracleParameter("@AccountNO_vc", OracleDbType.Varchar2, 20)
            parAccountNO_vc.Value = AccountNO_vc
            Dim parPayaneh As New OracleParameter("@Payaneh", OracleDbType.Varchar2, 8)
            parPayaneh.Value = Payaneh

            Dim parVocher As New OracleParameter("@Vocher", OracleDbType.Int16)
            parVocher.Value = Vocher
            Dim parSale As New OracleParameter("@Sale", OracleDbType.Int16)
            parSale.Value = Sale
            Dim parBill As New OracleParameter("@Bill", OracleDbType.Int16)
            parBill.Value = Bill
            Dim parMojudi As New OracleParameter("@Mojudi", OracleDbType.Int16)
            parMojudi.Value = Mojudi
            Dim parAuthorizationState As New OracleParameter("@AuthorizationState", OracleDbType.Int16)
            parAuthorizationState.Value = AuthorizationState
            Dim parMinAmount As New OracleParameter("@MinAmount", OracleDbType.Int64)
            parMinAmount.Value = ClassUserLoginDataAccess.ThisUser.MinAmount

            Dim parUserID As New OracleParameter("@UserID", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID



            strSQL = "usp_GetAllTransactionsInDetail"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parFromDate, parToDate, parVisitorID, parManagementID, parBranchID, parAccountNO_vc, parPayaneh, parVocher, parSale, parBill, parMojudi, parAuthorizationState, parMinAmount, parUserID, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllVisitorCountOfContractID_CountOfInstallingDetailDeviceID(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            strSQL = "GetAllVisitorCountOfContractID_CountOfInstallingDetailDeviceID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllVisitorsPosCounts() As DataTable
        Try
            Dim dt As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "GetVisitorsPosCounts_SP"

            ' add by yousefi & Kiyan
            'strSQL = "GetVisitorsPosCounts_SP11"" Date: 1391/10/04
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetSerialCirculation(ByVal PosSerial As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSerial As New OracleParameter("Serial_", OracleDbType.Varchar2, 20)
            parSerial.Value = PosSerial

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "rptSerialCirculation_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSerial, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAssignPosVisitorConflicts(ByVal ReportType As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parReportType As New OracleParameter("ReportType_", OracleDbType.Int16)
            parReportType.Value = ReportType

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'strSQL = "rptAssignPosToVisitorConflict_SP"
            strSQL = "RPTAssignPosToVisConflictSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parReportType, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllVisitorsPosCounts_ByVisitor(ByVal VisitorID As Int64, ByVal ReportType As Int16) As DataTable
        Try
            Dim dt As New DataTable


            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int64)
            parVisitorID.Value = VisitorID

            Dim parReportType As New OracleParameter("ReportType_", OracleDbType.Int64)
            parReportType.Value = ReportType

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            ' strSQL = "GetVisitorPosCounts_ByVisitor1" Date: 1391/10/04
            ' Comment by yousefi & Kiyan
            strSQL = "GetVisitorPosCounts_ByVisitor"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parVisitorID, parReportType, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByDate_Complete_CallsInfo(ByVal Date_vc As String, ByVal CallDate_vcFrom As String, ByVal CallDate_vcTO As String, ByVal Completed As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parDate As New OracleParameter("@Date", OracleDbType.Varchar2, 1)
            parDate.Value = Date_vc
            Dim parCallDate_vcFrom As New OracleParameter("@CallDate_vcFrom", OracleDbType.Varchar2, 10)
            parCallDate_vcFrom.Value = CallDate_vcFrom
            Dim parCallDate_vcTO As New OracleParameter("@CallDate_vcTO", OracleDbType.Varchar2, 10)
            parCallDate_vcTO.Value = CallDate_vcTO
            Dim parCompleted As New OracleParameter("@Completed", OracleDbType.Int16)
            parCompleted.Value = Completed

            Me.Fill(CommandType.StoreProcedure, "GetByDate_Complete_CallsInfo_SP", dt, parDate, parCallDate_vcFrom, parCallDate_vcTO, parCompleted)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function IncompleteContracts(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Me.Fill(CommandType.StoreProcedure, "IncompleteContracts_SP", dt, parUserID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllPosStatus() As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int16)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID

            strSQL = "GetAllPosStatus_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetYear() As DataTable
        Try
            Dim dt As New DataTable
            strSQL = "usp_GetYear"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCountOfTran_ByOutlet_InLastTwentyDays(ByVal Outlet_vc As String) As Int64
        Try
            Dim result As Int64
            Dim DateFrom As String
            DateFrom = DateTool.ConvertDate(DateAdd(DateInterval.Day, -20, Now())) + " " + Mid(Now().TimeOfDay.ToString, 1, 8)

            'GetCountOfTran_ByOutlet_InLastTwentyDays_fn
            strSQL = "select GetTran_ByOtlt_InLast20Days_fn('" + Outlet_vc + "','" + DateFrom + "') from Dual"
            MyBase.BeginProc()
            result = MyBase.Execute_Scalar(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, 0)
            MyBase.EndProc()
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllPosInstalledStatus(ByVal Serials As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parSerials As New OracleParameter("PosSerial_", OracleDbType.Varchar2, 8000)
            parSerials.Value = Serials
            strSQL = "GetPosInstallStatus"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(CommandType.StoreProcedure, strSQL, dt, parSerials, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetPazirandeInfo(ByVal InstallingHeaderID As String) As DataSet1
        Try
            Dim ds As New DataSet1
            Dim parInstallingHeaderID As New OracleParameter("InstallingHeaderID_", OracleDbType.Varchar2, 100)
            parInstallingHeaderID.Value = InstallingHeaderID
            strSQL = "GetPazirandeInfo"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(CommandType.StoreProcedure, strSQL, ds, parInstallingHeaderID, parRefCursor)
            Return ds
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region
End Class
