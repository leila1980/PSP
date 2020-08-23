Imports Oracle.DataAccess.Client

Public Class ClassDALSwitchSendTo
    Private strSQL As String

    Dim cnt As Oracle.DataAccess.Client.OracleConnection
    Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    Dim da As New OracleDataAdapter
    Public Sub OpenConnection()
        Try
            cnt = New Oracle.DataAccess.Client.OracleConnection

            If cnt.State <> ConnectionState.Open Then
                With cnt
                    .ConnectionString = modPublicMethod.ConnectionString
                    .Open()
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub CloseConnection()
        Try
            cnt.Close()
            cnt.Dispose()
            cnt = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ForSwitch_Modify_GetAllNotSentSwith() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "dbo.ForSwitch_Modify_GetAllNotSentSwith_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .CommandText = strSQL
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

    Public Function ForSwitch_Modify_GetAllNotSentToSinaSwith() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "dbo.ForSwitch_Modify_GetAllNotSenTToSinaSwith_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .CommandText = strSQL
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


    Public Function ForSwitch_Modify_GetAllCardAcceptor_NotSentSwith() As DataTable
        Try
            Dim dt As New DataTable

            'Dim parType_vc As New OracleParameter
            'With parType_vc
            '    .ParameterName = "@Type_vc"
            '    .DbType = DbType.String
            '    .Size = 3
            '    .Value = Type
            'End With


            strSQL = "dbo.ForSwitch_Modify_GetAllCardAcceptor_NotSentSwith_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                '.Parameters.Add(parType_vc)
                .CommandText = strSQL
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
    Public Function ForSwitch_Modify_Device_Cancel_GetAllNotSentSwith() As DataTable
        Try
            Dim dt As New DataTable

            'Dim parType_vc As New OracleParameter
            'With parType_vc
            '    .ParameterName = "@Type_vc"
            '    .DbType = DbType.String
            '    .Size = 3
            '    .Value = Type
            'End With


            strSQL = "dbo.ForSwitch_Modify_Device_Cancel_GetAllNotSentSwith_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                '.Parameters.Add(parType_vc)
                .CommandText = strSQL
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
    Public Sub Update_Switch_Modify_Sent(ByVal Switch_ModifyID As Int64, ByVal SentDate_vc As String)
        Try

            Dim parSwitch_ModifyID As New OracleParameter
            With parSwitch_ModifyID
                .ParameterName = "@Switch_ModifyID"
                .DbType = DbType.Int64
                .Value = Switch_ModifyID
            End With
            Dim parSentDate_vc As New OracleParameter
            With parSentDate_vc
                .ParameterName = "@SentDate_vc"
                .DbType = DbType.String
                .Value = SentDate_vc
            End With


            strSQL = "dbo.Update_Switch_Modify_Sent_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parSwitch_ModifyID)
                .Parameters.Add(parSentDate_vc)
                .CommandText = strSQL
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update_Switch_Modify_Device_Sent(ByVal Switch_Modify_DeviceID As Int64, ByVal SentDate_vc As String)
        Try

            Dim parSwitch_Modify_DeviceID As New OracleParameter
            With parSwitch_Modify_DeviceID
                .ParameterName = "@Switch_Modify_DevicelID"
                .DbType = DbType.Int64
                .Value = Switch_Modify_DeviceID
            End With
            Dim parSentDate_vc As New OracleParameter
            With parSentDate_vc
                .ParameterName = "@SentDate_vc"
                .DbType = DbType.String
                .Value = SentDate_vc
            End With


            strSQL = "dbo.Update_Switch_Modify_Device_Sent_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parSwitch_Modify_DeviceID)
                .Parameters.Add(parSentDate_vc)
                .CommandText = strSQL
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function GetBySwitchCardAcceptor_Info(ByVal DSwitch_CardAcceptorID_vc As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDSwitch_CardAcceptorID_vc As New OracleParameter
            With parDSwitch_CardAcceptorID_vc
                .ParameterName = "@DSwitch_CardAcceptorID_vc"
                .DbType = DbType.String
                .Size = 15
                .Value = DSwitch_CardAcceptorID_vc
            End With

            Dim parProjectID As New OracleParameter
            With parProjectID
                .ParameterName = "@ProjectID"
                .DbType = OracleDbType.Int32
                .Value = ProjectID
            End With

            strSQL = "dbo.GetBySwitchCardAcceptor_Info_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parDSwitch_CardAcceptorID_vc)
                .Parameters.Add(parProjectID)
                .CommandText = strSQL
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
    Public Function GetBySwitchTerminal_Info(ByVal DSwitch_TerminalID_vc As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDSwitch_TerminalID_vc As New OracleParameter
            With parDSwitch_TerminalID_vc
                .ParameterName = "@DSwitch_TerminalID_vc"
                .DbType = DbType.String
                .Size = 8
                .Value = DSwitch_TerminalID_vc
            End With

            Dim parProjectID As New OracleParameter
            With parProjectID
                .ParameterName = "@ProjectID"
                .DbType = OracleDbType.Int32
                .Value = ProjectID
            End With

            strSQL = "dbo.GetBySwitchTerminal_Info_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parDSwitch_TerminalID_vc)
                .Parameters.Add(parProjectID)
                .CommandText = strSQL
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
    Public Function ForSwitch_Modify_Device_PosChange_GetAllNotSentSwith() As DataTable
        Try
            Dim dt As New DataTable

            'Dim parType_vc As New OracleParameter
            'With parType_vc
            '    .ParameterName = "@Type_vc"
            '    .DbType = DbType.String
            '    .Size = 3
            '    .Value = Type
            'End With

            Dim parProjectID As New OracleParameter
            With parProjectID
                .ParameterName = "@ProjectID"
                .DbType = OracleDbType.Int32
                .Value = ClassUserLoginDataAccess.ThisUser.ProjectID
            End With

            strSQL = "dbo.ForSwitch_Modify_Device_PosChange_GetAllNotSentSwith_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parProjectID)
                .CommandText = strSQL
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
