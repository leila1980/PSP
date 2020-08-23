Imports Oracle.DataAccess.Client

Public Class ClassDALTMS
    'Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    'Public Sub New(ByVal CS As String)
    '    MyBase.New(CS)
    'End Sub

    Public cnt As Oracle.DataAccess.Client.OracleConnection
    Public cmd As New Oracle.DataAccess.Client.OracleCommand
    Dim da As New OracleDataAdapter

    Dim TMScnt As Odbc.OdbcConnection
    Dim TMScmd As New Odbc.OdbcCommand
    Dim TMSda As New Odbc.OdbcDataAdapter


    '--Terminal
    Private mvarTERMINAL_ID As String
    Private mvarSIGNATURE As String
    Private mvarREGISTRATION_DATE As DateTime
    Private mvarPARENT_ID As String
    Private mvarNAME As String
    Private mvarDESCRIPTION As String
    Private mvarTYPE As String
    Private mvarSTATUS As Int32
    Private mvarCATEGORY As Int32
    Private mvarCOMMS As String
    Private mvarNEXT_CALL_DATE As String
    '--Task
    Private mvarTASK_ID As String

    Public Property TERMINAL_ID() As String
        Get
            Return mvarTERMINAL_ID
        End Get
        Set(ByVal value As String)
            mvarTERMINAL_ID = value
        End Set
    End Property
    Public Property SIGNATURE() As String
        Get
            Return mvarSIGNATURE
        End Get
        Set(ByVal value As String)
            mvarSIGNATURE = value
        End Set
    End Property
    Public Property NAME() As String
        Get
            Return mvarNAME
        End Get
        Set(ByVal value As String)
            mvarNAME = value
        End Set
    End Property
    Public Property PARENT_ID() As String
        Get
            Return mvarPARENT_ID
        End Get
        Set(ByVal value As String)
            mvarPARENT_ID = value
        End Set
    End Property
    Public Property DESCRIPTION() As String
        Get
            Return mvarDESCRIPTION
        End Get
        Set(ByVal value As String)
            mvarDESCRIPTION = value
        End Set
    End Property
    Public Property REGISTRATION_DATE() As DateTime
        Get
            Return mvarREGISTRATION_DATE
        End Get
        Set(ByVal value As DateTime)
            mvarREGISTRATION_DATE = value
        End Set
    End Property
    Public Property TYPE() As String
        Get
            Return mvarTYPE
        End Get
        Set(ByVal value As String)
            mvarTYPE = value
        End Set
    End Property
    Public Property STATUS() As String
        Get
            Return mvarSTATUS
        End Get
        Set(ByVal value As String)
            mvarSTATUS = value
        End Set
    End Property
    Public Property CATEGORY() As String
        Get
            Return mvarCATEGORY
        End Get
        Set(ByVal value As String)
            mvarCATEGORY = value
        End Set
    End Property
    Public Property COMMS() As String
        Get
            Return mvarCOMMS
        End Get
        Set(ByVal value As String)
            mvarCOMMS = value
        End Set
    End Property
    Public Property NEXT_CALL_DATE() As String
        Get
            Return mvarNEXT_CALL_DATE
        End Get
        Set(ByVal value As String)
            mvarNEXT_CALL_DATE = value
        End Set
    End Property

    Public Property TASK_ID() As String
        Get
            Return mvarTASK_ID
        End Get
        Set(ByVal value As String)
            mvarTASK_ID = value
        End Set
    End Property

#Region "Methods"

    Public Function ForTMS_GetByTypeNotSentTMS(ByVal Type As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parType_vc As New OracleParameter("Type_vc_", OracleDbType.Varchar2)
            parType_vc.Value = Type

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "ForTMS_GetByTypeNotSentTMS_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parType_vc)
                .Parameters.Add(parRefCursor)
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

    Public Function ForTMS_TMSTerminal_GetByStateID(ByVal StateID As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parSIGNATURE As New OracleParameter
            With parSIGNATURE
                .ParameterName = "@SIGNATURE"
                .DbType = DbType.String
                .Size = 50
                .Value = StateID
            End With


            strSQL = "dbo.ForTMS_TMSTerminal_GetByStateID"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parSIGNATURE)
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

    Public Function ForTMS_TERMINAL_GetByEniacCode(ByVal EniacCode As String) As DataTable
        Try

            Dim dt As New DataTable

            Dim parNAME As New OracleParameter
            With parNAME
                .ParameterName = "@NAME"
                .DbType = DbType.String
                .Size = 100
                .Value = EniacCode
            End With


            strSQL = "dbo.ForTMS_TERMINAL_GetByEniacCode_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parNAME)
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

    Public Function ForTMS_TMSTerminal_MAXTerminalID() As DataTable
        Try

            Dim dt As New DataTable

            strSQL = "dbo.ForTMS_TMSTerminal_MAXTerminalID"
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

    'Public Sub ForTMS_TMSTerminal_Insert1()
    '    Try
    '        Dim parTERMINAL_ID As New OracleParameter
    '        Dim parSIGNATURE As New OracleParameter
    '        Dim parNAME As New OracleParameter
    '        Dim parREGISTRATION_DATE As New OracleParameter
    '        Dim parTYPE As New OracleParameter
    '        Dim parSTATUS As New OracleParameter
    '        Dim parCATEGORY As New OracleParameter
    '        Dim parDESCRIPTION As New OracleParameter

    '        With parTERMINAL_ID
    '            .ParameterName = "@TERMINAL_ID"
    '            .DbType = DbType.String
    '            .Size = 50
    '            .Value = TERMINAL_ID
    '        End With
    '        With parSIGNATURE
    '            .ParameterName = "@SIGNATURE"
    '            .DbType = DbType.String
    '            .Size = 50
    '            .Value = SIGNATURE
    '        End With
    '        With parNAME
    '            .ParameterName = "@NAME"
    '            .DbType = DbType.String
    '            .Size = 100
    '            .Value = NAME
    '        End With
    '        With parREGISTRATION_DATE
    '            .ParameterName = "@REGISTRATION_DATE"
    '            .DbType = DbType.DateTime
    '            .Value = REGISTRATION_DATE
    '        End With
    '        With parTYPE
    '            .ParameterName = "@TYPE"
    '            .DbType = DbType.String
    '            .Size = 20
    '            .Value = TYPE
    '        End With
    '        With parSTATUS
    '            .ParameterName = "@STATUS"
    '            .DbType = DbType.Int32
    '            .Value = STATUS
    '        End With
    '        With parCATEGORY
    '            .ParameterName = "@CATEGORY"
    '            .DbType = DbType.Int32
    '            .Value = CATEGORY
    '        End With
    '        With parDESCRIPTION
    '            .ParameterName = "@DESCRIPTION"
    '            .DbType = DbType.String
    '            .Size = 200
    '            .Value = DESCRIPTION
    '        End With


    '        strSQL = "dbo.ForTMS_TMSTerminal_Insert1"
    '        With cmd
    '            .Connection = cnt
    '            .CommandType = CommandType.StoredProcedure
    '            .Parameters.Clear()
    '            .Parameters.Add(parTERMINAL_ID)
    '            .Parameters.Add(parSIGNATURE)
    '            .Parameters.Add(parNAME)
    '            .Parameters.Add(parREGISTRATION_DATE)
    '            .Parameters.Add(parTYPE)
    '            .Parameters.Add(parSTATUS)
    '            .Parameters.Add(parCATEGORY)
    '            .Parameters.Add(parDESCRIPTION)

    '            .CommandText = strSQL
    '            .ExecuteNonQuery()
    '        End With

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Public Sub ForTMS_TMSTerminal_Insert2()
    '    Try
    '        Dim parTERMINAL_ID As New OracleParameter
    '        Dim parSIGNATURE As New OracleParameter
    '        Dim parNAME As New OracleParameter
    '        Dim parREGISTRATION_DATE As New OracleParameter
    '        Dim parTYPE As New OracleParameter
    '        Dim parSTATUS As New OracleParameter
    '        Dim parCATEGORY As New OracleParameter
    '        Dim parDESCRIPTION As New OracleParameter
    '        Dim parPARENT_ID As New OracleParameter

    '        With parTERMINAL_ID
    '            .ParameterName = "@TERMINAL_ID"
    '            .DbType = DbType.String
    '            .Size = 50
    '            .Value = TERMINAL_ID
    '        End With
    '        With parSIGNATURE
    '            .ParameterName = "@SIGNATURE"
    '            .DbType = DbType.String
    '            .Size = 50
    '            .Value = SIGNATURE
    '        End With
    '        With parNAME
    '            .ParameterName = "@NAME"
    '            .DbType = DbType.String
    '            .Size = 100
    '            .Value = NAME
    '        End With
    '        With parREGISTRATION_DATE
    '            .ParameterName = "@REGISTRATION_DATE"
    '            .DbType = DbType.DateTime
    '            .Value = REGISTRATION_DATE
    '        End With
    '        With parTYPE
    '            .ParameterName = "@TYPE"
    '            .DbType = DbType.String
    '            .Size = 20
    '            .Value = TYPE
    '        End With
    '        With parSTATUS
    '            .ParameterName = "@STATUS"
    '            .DbType = DbType.Int32
    '            .Value = STATUS
    '        End With
    '        With parCATEGORY
    '            .ParameterName = "@CATEGORY"
    '            .DbType = DbType.Int32
    '            .Value = CATEGORY
    '        End With
    '        With parDESCRIPTION
    '            .ParameterName = "@DESCRIPTION"
    '            .DbType = DbType.String
    '            .Size = 200
    '            .Value = DESCRIPTION
    '        End With
    '        With parPARENT_ID
    '            .ParameterName = "@PARENT_ID"
    '            .DbType = DbType.String
    '            .Size = 50
    '            .Value = PARENT_ID
    '        End With


    '        strSQL = "dbo.ForTMS_TMSTerminal_Insert2"
    '        With cmd
    '            .Connection = cnt
    '            .CommandType = CommandType.StoredProcedure
    '            .Parameters.Clear()
    '            .Parameters.Add(parTERMINAL_ID)
    '            .Parameters.Add(parSIGNATURE)
    '            .Parameters.Add(parNAME)
    '            .Parameters.Add(parREGISTRATION_DATE)
    '            .Parameters.Add(parTYPE)
    '            .Parameters.Add(parSTATUS)
    '            .Parameters.Add(parCATEGORY)
    '            .Parameters.Add(parDESCRIPTION)
    '            .Parameters.Add(parPARENT_ID)

    '            .CommandText = strSQL
    '            .ExecuteNonQuery()
    '        End With

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Public Sub ForTMS_TMSTerminal_Insert3()
    '    Try
    '        Dim parTERMINAL_ID As New OracleParameter
    '        Dim parSIGNATURE As New OracleParameter
    '        Dim parNAME As New OracleParameter
    '        Dim parREGISTRATION_DATE As New OracleParameter
    '        Dim parTYPE As New OracleParameter
    '        Dim parSTATUS As New OracleParameter
    '        Dim parCATEGORY As New OracleParameter
    '        Dim parDESCRIPTION As New OracleParameter
    '        Dim parPARENT_ID As New OracleParameter
    '        Dim parCOMMS As New OracleParameter

    '        With parTERMINAL_ID
    '            .ParameterName = "@TERMINAL_ID"
    '            .DbType = DbType.String
    '            .Size = 50
    '            .Value = TERMINAL_ID
    '        End With
    '        With parSIGNATURE
    '            .ParameterName = "@SIGNATURE"
    '            .DbType = DbType.String
    '            .Size = 50
    '            .Value = SIGNATURE
    '        End With
    '        With parNAME
    '            .ParameterName = "@NAME"
    '            .DbType = DbType.String
    '            .Size = 100
    '            .Value = NAME
    '        End With
    '        With parREGISTRATION_DATE
    '            .ParameterName = "@REGISTRATION_DATE"
    '            .DbType = DbType.DateTime
    '            .Value = REGISTRATION_DATE
    '        End With
    '        With parTYPE
    '            .ParameterName = "@TYPE"
    '            .DbType = DbType.String
    '            .Size = 20
    '            .Value = TYPE
    '        End With
    '        With parSTATUS
    '            .ParameterName = "@STATUS"
    '            .DbType = DbType.Int32
    '            .Value = STATUS
    '        End With
    '        With parCATEGORY
    '            .ParameterName = "@CATEGORY"
    '            .DbType = DbType.Int32
    '            .Value = CATEGORY
    '        End With
    '        With parDESCRIPTION
    '            .ParameterName = "@DESCRIPTION"
    '            .DbType = DbType.String
    '            .Size = 200
    '            .Value = DESCRIPTION
    '        End With
    '        With parPARENT_ID
    '            .ParameterName = "@PARENT_ID"
    '            .DbType = DbType.String
    '            .Size = 50
    '            .Value = PARENT_ID
    '        End With
    '        With parCOMMS
    '            .ParameterName = "@COMMS"
    '            .DbType = DbType.String
    '            .Size = 200
    '            .Value = COMMS
    '        End With


    '        strSQL = "dbo.ForTMS_TMSTerminal_Insert3"
    '        With cmd
    '            .Connection = cnt
    '            .CommandType = CommandType.StoredProcedure
    '            .Parameters.Clear()
    '            .Parameters.Add(parTERMINAL_ID)
    '            .Parameters.Add(parSIGNATURE)
    '            .Parameters.Add(parNAME)
    '            .Parameters.Add(parREGISTRATION_DATE)
    '            .Parameters.Add(parTYPE)
    '            .Parameters.Add(parSTATUS)
    '            .Parameters.Add(parCATEGORY)
    '            .Parameters.Add(parDESCRIPTION)
    '            .Parameters.Add(parPARENT_ID)
    '            .Parameters.Add(parCOMMS)
    '            .CommandText = strSQL
    '            .ExecuteNonQuery()
    '        End With

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


    Public Sub ForTMS_TMSTASK_V_TERMINAL_Delete()
        Try
            Dim parTERMINAL_ID As New OracleParameter

            With parTERMINAL_ID
                .ParameterName = "@TERMINAL_ID"
                .DbType = DbType.String
                .Size = 50
                .Value = TERMINAL_ID
            End With

            strSQL = "dbo.ForTMS_TMSTASK_V_TERMINAL_Delete"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parTERMINAL_ID)
                .CommandText = strSQL
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ForTMS_UpdateTMS(ByVal Sent_tint As Int16, ByVal SentDate_vc As String, ByVal TMSID As Int64)
        Try

            Dim parSent_tint As New OracleParameter
            Dim parSentDate_vc As New OracleParameter
            Dim parTMSID As New OracleParameter

            With parSent_tint
                .ParameterName = "Sent_tint_"
                .OracleDbType = OracleDbType.Int16
                .Value = Sent_tint
            End With
            With parSentDate_vc
                .ParameterName = "SentDate_vc_"
                .OracleDbType = OracleDbType.Varchar2
                .Value = SentDate_vc
            End With
            With parTMSID
                .ParameterName = "TMSID_"
                .OracleDbType = OracleDbType.Int32
                .Value = TMSID
            End With


            strSQL = "ForTMS_UpdateTMS_SP"
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(parSent_tint)
                .Parameters.Add(parSentDate_vc)
                .Parameters.Add(parTMSID)

                .CommandText = strSQL
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


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


#End Region

#Region "TMS DB Methods"

    Public Function TMS_GetBySerialAndProductNo_TERMINAL(ByVal SIGNATURE As String) As DataTable
        Try

            Dim dt As New DataTable
            strSQL = "CALL GetBySerialAndProductNo_Terminal_SP('" + SIGNATURE.ToString + "')"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
            End With
            With TMSda
                .SelectCommand = TMScmd
                .Fill(dt)
            End With

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TMS_GetByCityID_Terminal(ByVal CityID As String) As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "CALL GetByCityID_Terminal_SP('" + CityID.ToString + "')"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
            End With
            With TMSda
                .SelectCommand = TMScmd
                .Fill(dt)
            End With

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TMS_Terminal_Insert() As Int16
        Try
            strSQL = "CALL Terminal_Insert_SP ('" + SIGNATURE.ToString + "','" + NAME.ToString + "','" + REGISTRATION_DATE.ToString("yyyy/MM/dd HH:ss:mm") + "','" + TYPE.ToString + "','" + STATUS.ToString + "','" + CATEGORY.ToString + "','" + PARENT_ID.ToString + "','" + COMMS.ToString + "','" + DESCRIPTION.ToString + "',@parResStatus )"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .ExecuteNonQuery()

                .CommandType = CommandType.Text
                .CommandText = "select cast(@parResStatus as signed int)"
                Dim res As Int32 = .ExecuteScalar()
                If res <= 0 Then
                    Throw New ApplicationException("Terminal Insert Exception!")
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub TMS_Terminal_Update_ByTerminalID()
        Try

            strSQL = "CALL Terminal_Update_ByTerminalID_SP('" + TERMINAL_ID.ToString + "','" + PARENT_ID.ToString + "','" + NAME.Trim.ToString + " ')"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function TMS_GetStateTaskActivity(ByVal Task_Name As String) As DataTable
        Dim dt As New DataTable
        Try
            strSQL = "CALL StateTaskActivity_sp('" + Task_Name.ToString + "','78c2692c:123126559fc:-4468:C0A81452')"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
            End With
            With TMSda
                Me.OpenTMSConnection()
                .SelectCommand = TMScmd
                TMScmd.Connection = TMScnt
                .Fill(dt)
                Me.CloseTMSConnection()
            End With

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TMS_GetAllTask_sp() As DataTable
        Dim dt As New DataTable
        Try
            strSQL = "CALL GetAllTask_sp('78c2692c:123126559fc:-4468:C0A81452')"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
            End With
            With TMSda
                Me.OpenTMSConnection()
                .SelectCommand = TMScmd
                TMScmd.Connection = TMScnt
                .Fill(dt)
                Me.CloseTMSConnection()
            End With

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TMS_GetStateTaskActivityUpdated(ByVal Task_Name As String) As DataTable
        Dim dt As New DataTable
        Try
            strSQL = "CALL StateTaskActivityUpdated_sp('" + Task_Name.ToString + "','78c2692c:123126559fc:-4468:C0A81452')"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
            End With
            With TMSda
                Me.OpenTMSConnection()
                .SelectCommand = TMScmd
                TMScmd.Connection = TMScnt
                .Fill(dt)
                Me.CloseTMSConnection()
            End With

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TMS_GetStateTaskActivityNotUpdated(ByVal Task_Name As String) As DataTable
        Dim dt As New DataTable
        Try
            strSQL = "CALL StateTaskActivityNotUpdated_sp('" + Task_Name.ToString + "','78c2692c:123126559fc:-4468:C0A81452')"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
            End With
            With TMSda
                Me.OpenTMSConnection()
                .SelectCommand = TMScmd
                TMScmd.Connection = TMScnt
                .Fill(dt)
                Me.CloseTMSConnection()
            End With

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TMS_GetCityTaskActivityUpdatedDetail(ByVal Task_Name As String, ByVal StateID As String) As DataTable
        Dim dt As New DataTable
        Try
            strSQL = "CALL CityTaskActivityUpdatedDetail_sp('" + Task_Name.ToString + "','78c2692c:123126559fc:-4468:C0A81452','" + StateID + "')"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
            End With
            With TMSda
                Me.OpenTMSConnection()
                .SelectCommand = TMScmd
                TMScmd.Connection = TMScnt
                .Fill(dt)
                Me.CloseTMSConnection()
            End With

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TMS_GetCityTaskActivityNotUpdatedDetail(ByVal Task_Name As String, ByVal StateID As String) As DataTable
        Dim dt As New DataTable
        Try
            strSQL = "CALL CityTaskActivityNotUpdatedDetail_sp('" + Task_Name.ToString + "','78c2692c:123126559fc:-4468:C0A81452','" + StateID + "')"
            With TMScmd
                .Connection = TMScnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSQL
            End With
            With TMSda
                Me.OpenTMSConnection()
                .SelectCommand = TMScmd
                TMScmd.Connection = TMScnt
                .Fill(dt)
                Me.CloseTMSConnection()
            End With

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub OpenTMSConnection()
        Try
            TMScnt = New Odbc.OdbcConnection
           
            With TMScnt
                .ConnectionString = modPublicMethod.TMSConnectionString
                .Open()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CloseTMSConnection()
        Try
            TMScnt.Close()
            TMScnt.Dispose()
            TMScnt = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
