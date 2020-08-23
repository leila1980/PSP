Public Class frmTMSSendTo
    Dim clsDalTMS As New ClassDALTMS()
    Dim clsDalPos As New ClassDALPos(modPublicMethod.ConnectionString)

    Private dtPos As New DataTable
    Private dtCMS As New DataTable

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try

            clsDalTMS.OpenConnection()
            clsDalTMS.OpenTMSConnection()
            'StateUpdate()
            'CityUpdate()
            PosUpdate()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            clsDalTMS.CloseConnection()
            clsDalTMS.CloseTMSConnection()
        End Try
    End Sub
    Private Sub PosUpdate()
        Try
            '---------------------
            Dim dtNotSentTMS As New DataTable
            Dim dtTMS As New DataTable
            Dim dtTMSTerminal_MAXTerminalID As New DataTable
            Dim dtTMSTerminal_GetByCityID As New DataTable
            Dim Arr()
            Dim EniacCode As String
            Dim Serial As String
            Dim ProductNo As String
            Dim CityID As String
            Dim TMSID As Int64
            Dim Status As String

            '---------------------
            dtNotSentTMS = clsDalTMS.ForTMS_GetByTypeNotSentTMS("P")
            '------Progress Bar---------------
            prgBar.Value = 0
            prgBar.Maximum = dtNotSentTMS.Rows.Count
            GroupBox1.Text = dtNotSentTMS.Rows.Count
            '----------------------------------


            For i As Int32 = 0 To dtNotSentTMS.Rows.Count - 1
                Application.DoEvents()
                '---------------------------
                GroupBox1.Text = (i + 1).ToString & "/" & dtNotSentTMS.Rows.Count
                prgBar.Value = i + 1
                '---------------------------
                TMSID = dtNotSentTMS.Rows(i).Item("TMSID")
                Status = dtNotSentTMS.Rows(i).Item("Status_vc")
                Arr = Split(dtNotSentTMS.Rows(i).Item("Content_nvc").ToString, "\")
                EniacCode = Arr(0)
                Serial = Arr(1)
                ProductNo = Arr(2)

              
                If IsIng(Serial) = True Then

                    Dim Signiture As String = "00" + Serial + ":" + ProductNo

                    If Status = "assign" Then

                        If IsPOSTBank(Serial, "1") Then

                            CityID = "fanava_2_" & Arr(3) 'اگر پست بانک باشد
                        Else
                            CityID = "fanava_" & Arr(3) 'اگر پست بانک نباشد
                        End If
                    End If


                    dtTMS = clsDalTMS.TMS_GetBySerialAndProductNo_TERMINAL(Signiture)
                    '   اگر شرط برابر 0 باشد،به این معنی است که پز در جدول وجود ندارد و باید وارد گردد

                  
                    If dtTMS.Rows.Count = 0 Then 'Insert Pos To TMS
                        If Status = "assign" Then

                            dtTMSTerminal_GetByCityID = clsDalTMS.TMS_GetByCityID_Terminal(CityID)
                            If dtTMSTerminal_GetByCityID.Rows.Count = 0 Then
                                Dim _clsCity As New ClassDALCity(ConnectionString)
                                Dim dt As New DataTable
                                _clsCity.CityID = Arr(3)
                                dt = _clsCity.GetByID()
                                If dt.Rows.Count > 0 Then
                                    ShowErrorMessage("شهر " + dt.Rows(0)("Name_nvc") + " با کد " + Arr(3) + " در TMS تعریف نشده است")
                                End If
                                Continue For
                            Else
                                clsDalTMS.PARENT_ID = dtTMSTerminal_GetByCityID.Rows(0).Item("TERMINAL_ID")
                            End If

                        ElseIf Status = "cancel" Then
                            If IsPOSTBank(Serial, "2") Then
                                clsDalTMS.PARENT_ID = "7129000" 'eniac Post
                            Else
                                clsDalTMS.PARENT_ID = "40417" 'eniac tejarat
                            End If

                        End If

                        clsDalTMS.SIGNATURE = Signiture
                        clsDalTMS.NAME = EniacCode
                        clsDalTMS.TYPE = "U32"
                        clsDalTMS.STATUS = 0
                        clsDalTMS.CATEGORY = 1
                        clsDalTMS.DESCRIPTION = "Registered With Query"
                        clsDalTMS.REGISTRATION_DATE = Date.Now
                        clsDalTMS.COMMS = vbCrLf
                        clsDalTMS.TMS_Terminal_Insert()
                        clsDalTMS.ForTMS_UpdateTMS(1, GetDateNow, TMSID)

                      
                    Else 'Update Pos Parent

                        If Status = "assign" Then
                            dtTMSTerminal_GetByCityID = clsDalTMS.TMS_GetByCityID_Terminal(CityID)

                            If dtTMSTerminal_GetByCityID.Rows.Count = 0 Then
                                Dim _clsCity As New ClassDALCity(ConnectionString)
                                Dim dt As New DataTable
                                _clsCity.CityID = Arr(3)
                                dt = _clsCity.GetByID()
                                If dt.Rows.Count > 0 Then
                                    ShowErrorMessage("شهر " + dt.Rows(0)("Name_nvc") + " با کد " + Arr(3) + " در TMS تعریف نشده است")
                                End If
                                Continue For
                            Else
                                clsDalTMS.PARENT_ID = dtTMSTerminal_GetByCityID.Rows(0).Item("TERMINAL_ID")
                            End If

                        ElseIf Status = "cancel" Then
                            If IsPOSTBank(Serial, "2") Then
                                clsDalTMS.PARENT_ID = "7129000" 'eniac Post
                            Else
                                clsDalTMS.PARENT_ID = "40417" 'eniac tejarat
                            End If
                        End If

                        clsDalTMS.TERMINAL_ID = dtTMS.Rows(0).Item("TERMINAL_ID")
                        clsDalTMS.NAME = EniacCode 'چون گاهی اوقات اطلاعات دستی در جدول وارد شده است که کدپیگیری ندارد
                        clsDalTMS.TMS_Terminal_Update_ByTerminalID()
                        'If Status = "cancel" Then clsDalTMS.ForTMS_TMSTASK_V_TERMINAL_Delete()
                        clsDalTMS.ForTMS_UpdateTMS(1, GetDateNow, TMSID)

                    End If
                End If
            Next
            If dtNotSentTMS.Rows.Count > 0 Then
                ShowMessage(modApplicationMessage.msgSuccess)
            Else
                ShowErrorMessage("موردی برای بروزرسانی یافت نشد")
            End If
        Catch ex As Exception
            Throw ex

        Finally
            'clsDalTMS.CloseConnection()
            'clsDalTMS.CloseTMSConnection()
        End Try
    End Sub

    Private Function IsIng(ByVal Serial As String) As Boolean
        Try
            dtPos.Clear()

            clsDalPos.Serial_vc = Serial
            dtPos = clsDalPos.GetBySerialPos()
            If dtPos.Rows.Count > 0 Then
                If modPublicMethod.GetPosModel(dtPos.Rows(0).Item("PosModelID")) = "Ing" Then
                    IsIng = True
                Else
                    IsIng = False
                End If
            Else
                IsIng = False
            End If
        Catch ex As Exception
            IsIng = False
            Throw ex
        End Try
    End Function

    Private Function IsPOSTBank(ByVal Serial As String, ByVal type As String) As Boolean
        Try


            dtCMS.Clear()
            clsDalPos.Serial_vc = Serial
            dtCMS = clsDalPos.GetByCMSProject(type)

            If dtCMS.Rows.Count > 0 Then

                Select Case dtCMS.Rows(0).Item("cmsprojectid")
                    Case 1
                        IsPOSTBank = False
                    Case 3
                        IsPOSTBank = True
                End Select

            Else
                IsPOSTBank = False
            End If

        Catch ex As Exception
            IsPOSTBank = False
            Throw ex
        End Try

    End Function


    'Private Sub StateUpdate()
    '    Try
    '        Dim dtNotSentTMS As New DataTable
    '        Dim dtTMS As New DataTable
    '        Dim dtTMSTerminal_MAXTerminalID As New DataTable
    '        Dim Arr()
    '        Dim StateID As String
    '        Dim StateName As String
    '        Dim TMSID As Int64
    '        Dim MaxTerminalID As String
    '        dtNotSentTMS = clsDalTMS.ForTMS_GetByTypeNotSentTMS("S")
    '        For i As Int32 = 0 To dtNotSentTMS.Rows.Count - 1
    '            TMSID = dtNotSentTMS.Rows(i).Item("TMSID")
    '            Arr = Split(dtNotSentTMS.Rows(i).Item("Content_nvc").ToString, "\")
    '            StateID = Arr(0)
    '            StateName = Arr(1)
    '            dtTMS = clsDalTMS.ForTMS_TMSTerminal_GetByStateID(StateID)
    '            If dtTMS.Rows.Count = 0 Then
    '                dtTMSTerminal_MAXTerminalID = clsDalTMS.ForTMS_TMSTerminal_MAXTerminalID()
    '                MaxTerminalID = dtTMSTerminal_MAXTerminalID.Rows(0).Item("MAXTERMINAL_ID")
    '                clsDalTMS.TERMINAL_ID = (MaxTerminalID + 1).ToString
    '                clsDalTMS.SIGNATURE = StateID
    '                clsDalTMS.NAME = StateName
    '                clsDalTMS.TYPE = vbCrLf
    '                clsDalTMS.STATUS = 0
    '                clsDalTMS.CATEGORY = 0
    '                clsDalTMS.DESCRIPTION = String.Empty
    '                clsDalTMS.REGISTRATION_DATE = Date.Now

    '                clsDalTMS.ForTMS_TMSTerminal_Insert1() 'warnning:has Transaction Problem
    '                clsDalTMS.ForTMS_UpdateTMS(1, GetDateNow, TMSID) 'warnning:has Transaction Problem
    '            Else
    '                'Nothing
    '            End If
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub CityUpdate()
    '    Try
    '        Dim dtNotSentTMS As New DataTable
    '        Dim dtTMS As New DataTable
    '        Dim dtTMSTerminal_MAXTerminalID As New DataTable
    '        Dim dtTMSTerminal_GetByStateID As New DataTable
    '        Dim Arr()
    '        Dim CityID As String
    '        Dim CityName As String
    '        Dim StateID As String
    '        Dim TMSID As Int64
    '        Dim MaxTerminalID As String

    '        dtNotSentTMS = clsDalTMS.ForTMS_GetByTypeNotSentTMS("C")
    '        For i As Int32 = 0 To dtNotSentTMS.Rows.Count - 1
    '            TMSID = dtNotSentTMS.Rows(i).Item("TMSID")
    '            Arr = Split(dtNotSentTMS.Rows(i).Item("Content_nvc").ToString, "\")
    '            CityID = Arr(0)
    '            CityName = Arr(1)
    '            StateID = Arr(2)
    '            dtTMS = clsDalTMS.ForTMS_TMSTerminal_GetByCityID(CityID)
    '            If dtTMS.Rows.Count = 0 Then
    '                dtTMSTerminal_MAXTerminalID = clsDalTMS.ForTMS_TMSTerminal_MAXTerminalID()
    '                MaxTerminalID = dtTMSTerminal_MAXTerminalID.Rows(0).Item("MAXTERMINAL_ID")
    '                dtTMSTerminal_GetByStateID = clsDalTMS.ForTMS_TMSTerminal_GetByStateID(StateID)
    '                clsDalTMS.PARENT_ID = dtTMSTerminal_GetByStateID.Rows(0).Item("TERMINAL_ID")
    '                clsDalTMS.TERMINAL_ID = (MaxTerminalID + 1).ToString
    '                clsDalTMS.SIGNATURE = CityID
    '                clsDalTMS.NAME = CityName
    '                clsDalTMS.TYPE = vbCrLf
    '                clsDalTMS.STATUS = 0
    '                clsDalTMS.CATEGORY = 0
    '                clsDalTMS.DESCRIPTION = String.Empty
    '                clsDalTMS.REGISTRATION_DATE = Date.Now

    '                clsDalTMS.ForTMS_TMSTerminal_Insert2() 'warnning:has Transaction Problem
    '                clsDalTMS.ForTMS_UpdateTMS(1, GetDateNow, TMSID) 'warnning:has Transaction Problem

    '            Else
    '                'Nothing
    '            End If
    '        Next
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

End Class
