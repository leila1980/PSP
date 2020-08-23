Imports system.Data.SqlClient
Public Class ClassDALReport_2Old
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
    Public Sub Transaction_Detail(ByVal StartDate As String, ByVal EndDate As String, ByVal AccountNo As String, ByRef dt As DSReport.dtTransDetailDataTable)
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
    Public Sub Transaction_Branch(ByVal StartDate As String, ByVal EndDate As String, ByVal BranchId As String, ByRef dt As DSReport.dtTransPerBranchDataTable)
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
    Public Sub Transaction_OutLet(ByVal StartDate As String, ByVal EndDate As String, ByVal AccountNo As String, ByRef dt As DSReport.dtTransPerOutLetDataTable)
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
    Public Sub Transaction_Zone(ByVal StartDate As String, ByVal EndDate As String, ByVal Zone As Integer, ByRef dt As DSReport.dtTransPerZoneDataTable)
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
    Public Sub Transaction_Senf(ByVal StartDate As String, ByVal EndDate As String, ByRef dt As DSReport.dtTransPerSenfDataTable)
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

    Public Sub WithOut_Transaction(ByVal StartDate As String, ByVal EndDate As String, ByVal AccountNo As String, ByRef dt As DSReport.dtWithOutTransDataTable)
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
    Public Sub AgentActivitiesPerCntDate(ByVal StartDate As String, ByVal EndDate As String, ByVal VisitorName As String, ByVal DateFilterType As String, ByRef dt As DSReport.dtAgentActivitiesPerCntDateDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetAgentActivities"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@visitor").Value = VisitorName
                    .Item("@DateFilterType").Value = DateFilterType
                    .Item("@sdate").Value = StartDate
                    .Item("@edate").Value = EndDate
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
    Public Sub withoutamountpercent(ByVal VisitorName As String, ByRef dt As DSReport.dtwithoutamountpercentDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "get_withoutamountpercent"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@visitor").Value = VisitorName
                    '.Item("@DateFilterType").Value = DateFilterType
                    '.Item("@sdate").Value = StartDate
                    '.Item("@edate").Value = EndDate
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
    Public Sub withoutamount(ByRef dt As DSReport.dtwithoutamountDataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "get_withoutamount"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@userid").Value = ClassUserLoginDataAccess.ThisUser.UserID

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
    Public Sub AgentActivitiesPerTrnsDate(ByVal StartDate As String, ByVal EndDate As String, ByRef dt As DSReport.dtAgentActivitiesPerTrnsDateDataTable)
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
    Public Sub AgentActivitiesByTransaction(ByVal StartDate As String, ByVal EndDate As String, ByRef dt As DSReport.dtAgentActivityByTrnsDataTable)
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
    Public Sub AgentDiscordantTakhsis(ByVal StartDate As String, ByVal EndDate As String, ByRef dt As DSReport.dtAgentTakhsisDiscordantDataTable)
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
    Public Sub TejaratBankMontly(ByVal StartDate As String, ByVal EndDate As String, ByRef dt As DSReport.dtTejaratBankMontlyDataTable)
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
    Public Sub AgentDiscordantAfterTakhsis(ByVal StartDate As String, ByVal EndDate As String, ByVal Type As ReportType, ByRef dt As DSReport.dtAgentAfterTakhsisDiscordantDataTable)
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

    Public Sub GetVisitorVOCHER(ByVal StartDate As String, ByVal EndDate As String, ByRef dt As DataTable)
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

    Public Sub GetMonthlyReportForSendToTejaratBank(ByVal DateFrom As String, ByVal DateTo As String, ByRef dt As DataTable)
        Try
            With cmd
                .Connection = cnt
                .CommandTimeout = 1000
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetMonthlyReportForSendToTejaratBank_SP"
                SqlClient.SqlCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@DateFrom").Value = DateFrom
                    .Item("@DateTo").Value = DateTo
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
End Class

