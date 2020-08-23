Imports system.Data.SqlClient
Public Class ClassDALReportSina
    Dim cnt As SqlConnection
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Public Enum ReportType As Short
        ContractTakhsis = 1
        TakhsisConfig = 2
        ConfigIns = 3
        ConfigApIns = 4
    End Enum

    Public Sub New(ByVal CS As String)
        cnt = New SqlConnection
        With cnt
            .ConnectionString = CS
            .Open()
        End With
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Try
            cnt.Close()
            cnt.Dispose()
            cnt = Nothing
        Catch ex As Exception

        End Try
    End Sub
    Public Function GetPosVersion(ByVal FromDate As String, ByVal ToDate As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetPosVersion_SP"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@FromDate").Value = FromDate
                    .Item("@ToDate").Value = ToDate
                    If ProjectID = 0 Then
                        .Item("@ProjectId").Value = -1
                    Else
                        .Item("@ProjectId").Value = ProjectID
                    End If
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Transaction_Detail(ByVal StartDate As String, ByVal EndDate As String, ByVal AccountNo As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtTransDetailDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetTransDetail"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@AccountNo").Value = AccountNo
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Transaction_Branch(ByVal StartDate As String, ByVal EndDate As String, ByVal BranchId As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtTransPerBranchDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetTransPerBranch"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@BranchId").Value = BranchId
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Transaction_OutLet(ByVal StartDate As String, ByVal EndDate As String, ByVal AccountNo As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtTransPerOutLetDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetTransPerOutLet"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@AccountNo").Value = AccountNo
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Transaction_Zone(ByVal StartDate As String, ByVal EndDate As String, ByVal Zone As Integer, ByVal ProjectID As Int16, ByRef dt As DSReport.dtTransPerZoneDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetTransPerZone"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@Zone").Value = Zone
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Transaction_Senf(ByVal StartDate As String, ByVal EndDate As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtTransPerSenfDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "gettranspergroup"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub WithOut_Transaction(ByVal StartDate As String, ByVal EndDate As String, ByVal AccountNo As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtWithOutTransDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetWithOutTrans"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@AccountNo").Value = AccountNo
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub withoutamountpercent(ByVal VisitorName As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtwithoutamountpercentDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "get_withoutamountpercent"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@visitor").Value = VisitorName
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub withoutamount(ByVal ProjectID As Int16, ByRef dt As DSReport.dtwithoutamountDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "get_withoutamount"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@userid").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ReverseAfterCutOff(ByVal ShamsiDate As String, ByRef dt As DSReport.dtReverseAfterCutOffDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "get_reversalaftercutoff"
                .Parameters.Clear()
                .Parameters.AddWithValue("@shamsidate", ShamsiDate)
            End With
            Dim d As New SqlClient.SqlDataAdapter
            d.SelectCommand = cmd
            d.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub AgentActivitiesPerTrnsDate(ByVal StartDate As String, ByVal EndDate As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtAgentActivitiesPerTrnsDateDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "get_ins_first_tran"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub AgentActivitiesByTransaction(ByVal StartDate As String, ByVal EndDate As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtAgentActivityByTrnsDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "Gettran4"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@sdate").Value = StartDate
                    .Item("@edate").Value = EndDate
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub AgentDiscordantTakhsis(ByVal StartDate As String, ByVal EndDate As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtAgentTakhsisDiscordantDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "get_contract_takhsis"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub TejaratBankMontly(ByVal StartDate As String, ByVal EndDate As String, ByVal ProjectID As Int16, ByRef dt As DSReport.dtTejaratBankMontlyDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure

                .CommandText = "get_gozareshebank_sp"

                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub AgentDiscordantAfterTakhsis(ByVal StartDate As String, ByVal EndDate As String, ByVal Type As ReportType, ByVal ProjectID As Int16, ByRef dt As DSReport.dtAgentAfterTakhsisDiscordantDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure

                Select Case Type
                    Case ReportType.TakhsisConfig
                        .CommandText = "Get_takhsis_conf"
                    Case ReportType.ConfigIns
                        .CommandText = "get_conf_ins"
                    Case ReportType.ConfigApIns
                        .CommandText = "get_conf_ap_ins"
                End Select

                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function Transaction_All_Count(ByVal StartDate As String, ByVal EndDate As String, ByVal ProjectID As Int16) As DataTable
        Dim dt As New DataTable
        With cmd
            .Connection = cnt
            .CommandTimeout = 1000
            .CommandType = CommandType.StoredProcedure

            .CommandText = "[usp_GetTransactionCount]"

            SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
            With .Parameters
                .Item("@FromDate").Value = StartDate
                .Item("@ToDate").Value = EndDate
                .Item("@ProjectID").Value = ProjectID
            End With
        End With
        With da
            .SelectCommand = cmd
            dt.Clear()
            .Fill(dt)
        End With
        Return dt
    End Function

    Public Sub GetVisitorVOCHER(ByVal StartDate As String, ByVal EndDate As String, ByVal ProjectID As Int16, ByRef dt As DataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetVisitorVOCHER"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@StartDate").Value = StartDate
                    .Item("@EndDate").Value = EndDate
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub OutletActivityTransactions(ByVal StartDate As String, ByVal EndDate As String, ByVal AccountNo As String, ByVal ProjectID As Int16, ByRef dt As DataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "OutletActivityTransactions_SP"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@FromDate").Value = IIf(StartDate = "", DBNull.Value, StartDate)
                    .Item("@ToDate").Value = IIf(EndDate = "", DBNull.Value, EndDate)
                    .Item("@AccountNO_vc").Value = IIf(AccountNo = "", DBNull.Value, AccountNo)
                    .Item("@UserID").Value = ClassUserLoginDataAccess.ThisUser.UserID
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function MonthlyReport(ByVal StartDate As String, ByVal EndDate As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure

                .CommandText = "[usp_GetContractTransactionCountAndAmount]"

                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@FromDate").Value = StartDate
                    .Item("@ToDate").Value = EndDate
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRequestStatus(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "usp_Request_Status"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
    Public Function GetMonthlyReportForSendToTejaratBank(ByVal DateFrom As String, ByVal DateTo As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim cmd As New SqlClient.SqlCommand
            Dim da As New SqlClient.SqlDataAdapter
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetMonthlyReportForSendToTejaratBank_SP"
                .Parameters.Clear()
                If String.IsNullOrEmpty(DateFrom) Then
                    .Parameters.AddWithValue("@DateFrom", DBNull.Value)
                Else
                    .Parameters.AddWithValue("@DateFrom", DateFrom)
                End If
                If String.IsNullOrEmpty(DateTo) Then
                    .Parameters.AddWithValue("@DateTo", DBNull.Value)
                Else
                    .Parameters.AddWithValue("@DateTo", DateTo)
                End If
                If String.IsNullOrEmpty(ProjectID) Then
                    .Parameters.AddWithValue("@ProjectID", -1)
                Else
                    .Parameters.AddWithValue("@ProjectID", ProjectID)
                End If
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AgentActivitiesPerCntDate(ByVal StartDate As String, ByVal EndDate As String, ByVal VisitorID As Integer, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "usp_GetAgentActivities"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@VisitorID").Value = VisitorID
                    .Item("@FromDate").Value = StartDate
                    .Item("@ToDate").Value = EndDate
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                dt.Clear()
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetAllInformation(ByVal VisitorID As String, ByVal FromDate As String, ByVal ToDate As String, ByVal FromAuthorization As String, ByVal ToAuthorization As String, ByVal FromPrice As String, ByVal ToPrice As String, ByVal Vocher As Byte, ByVal Sale As Byte, ByVal Bill As Byte, ByVal Mojudi As Byte, ByVal AuthorizationState As Byte, ByVal ProjectID As Int32, ByVal Parent As Byte, ByVal AdvariVisitToPrice As String, ByVal MorediVisitToPrice As String) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "usp_GetAllInformation"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    If VisitorID = String.Empty Then
                        .Item("@VisitorID").Value = DBNull.Value
                    Else
                        .Item("@VisitorID").Value = VisitorID
                    End If
                    .Item("@FromDate").Value = FromDate
                    .Item("@ToDate").Value = ToDate
                    If FromAuthorization = String.Empty Then
                        .Item("@FromAuthorization").Value = DBNull.Value
                    Else
                        .Item("@FromAuthorization").Value = Convert.ToInt64(FromAuthorization)
                    End If
                    If ToAuthorization = String.Empty Then
                        .Item("@ToAuthorization").Value = DBNull.Value
                    Else
                        .Item("@ToAuthorization").Value = Convert.ToInt64(ToAuthorization)
                    End If
                    If FromPrice = String.Empty Then
                        .Item("@FromPrice").Value = DBNull.Value
                    Else
                        .Item("@FromPrice").Value = Convert.ToInt64(FromPrice)
                    End If
                    If ToPrice = String.Empty Then
                        .Item("@ToPrice").Value = DBNull.Value
                    Else
                        .Item("@ToPrice").Value = Convert.ToInt64(ToPrice)
                    End If
                    .Item("@Vocher").Value = Vocher
                    .Item("@Sale").Value = Sale
                    .Item("@Bill").Value = Bill
                    .Item("@Mojudi").Value = Mojudi
                    .Item("@AuthorizationState").Value = AuthorizationState
                    .Item("@ProjectID").Value = ProjectID
                    .Item("@Parent").Value = Parent
                    .Item("@MinAmount").Value = ClassUserLoginDataAccess.ThisUser.MinAmount
                    If AdvariVisitToPrice = String.Empty Then
                        .Item("@AdvariVisitToPrice").Value = DBNull.Value
                    Else
                        .Item("@AdvariVisitToPrice").Value = Convert.ToInt64(AdvariVisitToPrice)
                    End If
                    If MorediVisitToPrice = String.Empty Then
                        .Item("@MorediVisitToPrice").Value = DBNull.Value
                    Else
                        .Item("@MorediVisitToPrice").Value = Convert.ToInt64(MorediVisitToPrice)
                    End If
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllInformationAuthorization(ByVal FromDate As String, ByVal ToDate As String, ByVal Vocher As Byte, ByVal Sale As Byte, ByVal Bill As Byte, ByVal Mojudi As Byte, ByVal AuthorizationState As Byte, ByVal Outlet As String, ByVal FromPrice As String, ByVal ToPrice As String, ByVal Parent As Byte) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "usp_GetAllInformationAuthorization"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@FromDate").Value = FromDate
                    .Item("@ToDate").Value = ToDate
                    .Item("@Vocher").Value = Vocher
                    .Item("@Sale").Value = Sale
                    .Item("@Bill").Value = Bill
                    .Item("@Mojudi").Value = Mojudi
                    .Item("@AuthorizationState").Value = AuthorizationState
                    .Item("@Outlet").Value = Outlet
                    If FromPrice <> String.Empty Then
                        .Item("@FromPrice").Value = FromPrice
                    End If
                    If ToPrice <> String.Empty Then
                        .Item("@ToPrice").Value = ToPrice
                    End If
                    .Item("@Parent").Value = Parent
                    .Item("@MinAmount").Value = ClassUserLoginDataAccess.ThisUser.MinAmount
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAgentActivityGroupByDate(ByVal VisitorID As String, ByVal DateType As Byte, ByVal FromDate As String, ByVal ToDate As String, ByVal CalcType As Byte, ByVal Vocher As Byte, ByVal Sale As Byte, ByVal Bill As Byte, ByVal Mojudi As Byte, ByVal AuthorizationState As Byte, ByVal FromPrice As String, ByVal ToPrice As String, ByVal ProjectID As Int16, ByVal Parent As Boolean) As DSAgentActivityGroupByDate.dtAgentActivityGroupByDateDataTable
        Try
            Dim dt As New DSAgentActivityGroupByDate.dtAgentActivityGroupByDateDataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "usp_GetAgentActivityGroupByDate"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@DateType").Value = DateType
                    .Item("@FromDate").Value = FromDate
                    .Item("@ToDate").Value = ToDate
                    If VisitorID = String.Empty Or VisitorID = "0" Then
                        .Item("@VisitorID").Value = DBNull.Value
                    Else
                        .Item("@VisitorID").Value = VisitorID
                    End If
                    .Item("@CalcType").Value = CalcType
                    .Item("@Vocher").Value = Vocher
                    .Item("@Sale").Value = Sale
                    .Item("@Bill").Value = Bill
                    .Item("@Mojudi").Value = Mojudi
                    .Item("@AuthorizationState").Value = AuthorizationState
                    If FromPrice = String.Empty Then
                        .Item("@FromPrice").Value = DBNull.Value
                    Else
                        .Item("@FromPrice").Value = Convert.ToInt64(FromPrice)
                    End If
                    If ToPrice = String.Empty Then
                        .Item("@ToPrice").Value = DBNull.Value
                    Else
                        .Item("@ToPrice").Value = Convert.ToInt64(ToPrice)
                    End If
                    .Item("@ProjectID").Value = ProjectID
                    .Item("@MinAmount").Value = ClassUserLoginDataAccess.ThisUser.MinAmount
                    If Parent = True Then
                        .Item("@Parent").Value = 1
                    Else
                        .Item("@Parent").Value = 0
                    End If
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetMonthlyAllInformation(ByVal VisitorID As String, ByVal FromDate As String, ByVal ToDate As String, ByVal FromPrice As String, ByVal ToPrice As String, ByVal Vocher As Byte, ByVal Sale As Byte, ByVal Bill As Byte, ByVal Mojudi As Byte, ByVal AuthorizationState As Byte, ByVal ProjectID As Int32, ByVal Parent As Byte, ByVal AdvariVisitToPrice As String, ByVal MorediVisitToPrice As String) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "usp_GetMonthlyAllInformation"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    If VisitorID = String.Empty Then
                        .Item("@VisitorID").Value = DBNull.Value
                    Else
                        .Item("@VisitorID").Value = VisitorID
                    End If
                    .Item("@FromDate").Value = FromDate
                    .Item("@ToDate").Value = ToDate
                    If FromPrice = String.Empty Then
                        .Item("@FromPrice").Value = DBNull.Value
                    Else
                        .Item("@FromPrice").Value = Convert.ToInt64(FromPrice)
                    End If
                    If ToPrice = String.Empty Then
                        .Item("@ToPrice").Value = DBNull.Value
                    Else
                        .Item("@ToPrice").Value = Convert.ToInt64(ToPrice)
                    End If
                    .Item("@Vocher").Value = Vocher
                    .Item("@Sale").Value = Sale
                    .Item("@Bill").Value = Bill
                    .Item("@Mojudi").Value = Mojudi
                    .Item("@AuthorizationState").Value = AuthorizationState
                    .Item("@ProjectID").Value = ProjectID
                    .Item("@Parent").Value = Parent
                    .Item("@MinAmount").Value = ClassUserLoginDataAccess.ThisUser.MinAmount
                    If AdvariVisitToPrice = String.Empty Then
                        .Item("@AdvariVisitToPrice").Value = DBNull.Value
                    Else
                        .Item("@AdvariVisitToPrice").Value = Convert.ToInt64(AdvariVisitToPrice)
                    End If
                    If MorediVisitToPrice = String.Empty Then
                        .Item("@MorediVisitToPrice").Value = DBNull.Value
                    Else
                        .Item("@MorediVisitToPrice").Value = Convert.ToInt64(MorediVisitToPrice)
                    End If
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMonthlyAllInformation_BankMonthBased(ByVal VisitorID As String, ByVal FromDate As String, ByVal ToDate As String, ByVal FromPrice As String, ByVal ToPrice As String, ByVal Vocher As Byte, ByVal Sale As Byte, ByVal Bill As Byte, ByVal Mojudi As Byte, ByVal AuthorizationState As Byte, ByVal ProjectID As Int32, ByVal Parent As Byte, ByVal AdvariVisitToPrice As String, ByVal MorediVisitToPrice As String) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "usp_GetMonthlyAllInformation_BankMonthBased"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    If VisitorID = String.Empty Then
                        .Item("@VisitorID").Value = DBNull.Value
                    Else
                        .Item("@VisitorID").Value = VisitorID
                    End If
                    .Item("@FromDate").Value = FromDate
                    .Item("@ToDate").Value = ToDate
                    If FromPrice = String.Empty Then
                        .Item("@FromPrice").Value = DBNull.Value
                    Else
                        .Item("@FromPrice").Value = Convert.ToInt64(FromPrice)
                    End If
                    If ToPrice = String.Empty Then
                        .Item("@ToPrice").Value = DBNull.Value
                    Else
                        .Item("@ToPrice").Value = Convert.ToInt64(ToPrice)
                    End If
                    .Item("@Vocher").Value = Vocher
                    .Item("@Sale").Value = Sale
                    .Item("@Bill").Value = Bill
                    .Item("@Mojudi").Value = Mojudi
                    .Item("@AuthorizationState").Value = AuthorizationState
                    .Item("@ProjectID").Value = ProjectID
                    .Item("@Parent").Value = Parent
                    .Item("@MinAmount").Value = ClassUserLoginDataAccess.ThisUser.MinAmount
                    If AdvariVisitToPrice = String.Empty Then
                        .Item("@AdvariVisitToPrice").Value = DBNull.Value
                    Else
                        .Item("@AdvariVisitToPrice").Value = Convert.ToInt64(AdvariVisitToPrice)
                    End If
                    If MorediVisitToPrice = String.Empty Then
                        .Item("@MorediVisitToPrice").Value = DBNull.Value
                    Else
                        .Item("@MorediVisitToPrice").Value = Convert.ToInt64(MorediVisitToPrice)
                    End If
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetVisitTransaction(ByVal ToDate As String, ByVal Outlet As String, ByVal AdvariVisitToPrice As String, ByVal MorediVisitToPrice As String, ByVal Parent As Boolean, ByVal Type As Int16) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "usp_GetVisitTransaction"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@ToDate").Value = ToDate
                    .Item("@Outlet").Value = Outlet
                    If AdvariVisitToPrice = String.Empty Then
                        .Item("@AdvariVisitToPrice").Value = DBNull.Value
                    Else
                        .Item("@AdvariVisitToPrice").Value = Convert.ToInt64(AdvariVisitToPrice)
                    End If
                    If MorediVisitToPrice = String.Empty Then
                        .Item("@MorediVisitToPrice").Value = DBNull.Value
                    Else
                        .Item("@MorediVisitToPrice").Value = Convert.ToInt64(MorediVisitToPrice)
                    End If
                    .Item("@Parent").Value = Parent
                    .Item("@Type").Value = Type
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllVoucherInformation(ByVal VisitorID As String, ByVal FromDate As String, ByVal ToDate As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            With cmd
                .Connection = cnt
                .CommandTimeout = 0
                .CommandType = CommandType.StoredProcedure
                .CommandText = "usp_GetAllVoucherInformation"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    If VisitorID = String.Empty Then
                        .Item("@VisitorID").Value = DBNull.Value
                    Else
                        .Item("@VisitorID").Value = VisitorID
                    End If
                    .Item("@FromDate").Value = FromDate
                    .Item("@ToDate").Value = ToDate
                    .Item("@ProjectID").Value = ProjectID
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

