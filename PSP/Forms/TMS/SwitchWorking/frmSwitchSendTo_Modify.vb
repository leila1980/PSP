Imports File
Imports Convertor
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports ViewModel.ViewModel.WebPos.PL_CSharp

Public Class frmSwitchSendTo_Modify

#Region "Property"

    Private clsDalSwitchSend As New ClassDALSwitchSend(modPublicMethod.ConnectionString)
    Private colError As New Collection
    Private SinaColError As New Collection
    Private Error_FileName As String = "Switch_Modify_Err.txt"
    Private SinaError_FileName As String = "SinaSwitch_Modify_Err.txt"
    Dim clsDalSwitchSendTo As New ClassDALSwitchSendTo()
    Dim clsBLLSwitch_AcceptorManagement As New ClassBLLSwitch_AcceptorManagement()
    Dim myConStr As New ClassConnectionSpliter()


    Private clsDalShaparak As New ClassDALShaparak(modPublicMethod.ConnectionString)
    Dim folderBrowserDialog As New FolderBrowserDialog

    Private colCardAcceptorIdIsNotSpecified As New Collection
    Private colCardAcceptorIdNotFound As New Collection
    Private colCardAcceptorInstitutionExternalAccountNotFound As New Collection
    Private colCardAcceptorInstitutionNotFound As New Collection
    Private colCardAcceptorReconciliationCycleLenghtIsNotSpecified As New Collection
    Private colCardAcceptorSettlementMethodIsNotSpecified As New Collection
    Private colCardAcceptorStatusIsNotSpecified As New Collection
    Private colDuplicateTerminalSerialNo As New Collection
    Private colExternalAccountNumberIsNotSpecified As New Collection
    Private colExternalAccountTitleIsNotSpecified As New Collection
    Private colInstitutionAddressIsNotSpecified As New Collection
    Private colInstitutionNameIsNotSpecified As New Collection
    Private colInstitutionTypeIsNotSpecified As New Collection
    Private colInvalidRequest As New Collection
    Private colPeerNameIsNotSpecified As New Collection
    Private colPeerTypeIsNotSpecified As New Collection
    Private colTerminalSerialNoIsNotSpecified As New Collection
    Private colDuplicateCardAcceptorId As New Collection
    Private colDuplicateTerminalId As New Collection
    Private colTerminalIdIsNotSpecified As New Collection

    Private ErrTerminalIdIsNotSpecified_FileName As String = "SendToSwitch_Modify_TerminalIdIsNotSpecified_Err.txt"
    Private ErrCardAcceptorIdIsNotSpecified_FileName As String = "SendToSwitch_Modify_CardAcceptorIdIsNotSpecified_Err.txt"
    Private ErrCardAcceptorIdNotFound_FileName As String = "SendToSwitch_Modify_CardAcceptorIdNotFound_Err.txt"
    Private ErrCardAcceptorInstitutionExternalAccountNotFound_FileName As String = "SendToSwitch_Modify_CardAcceptorInstitutionExternalAccountNotFound_Err.txt"
    Private ErrCardAcceptorInstitutionNotFound_FileName As String = "SendToSwitch_Modify_CardAcceptorInstitutionNotFound_Err.txt"
    Private ErrCardAcceptorReconciliationCycleLenghtIsNotSpecified_FileName As String = "SendToSwitch_Modify_CardAcceptorReconciliationCycleLenghtIsNotSpecified_Err.txt"
    Private ErrCardAcceptorSettlementMethodIsNotSpecified_FileName As String = "SendToSwitch_Modify_CardAcceptorSettlementMethodIsNotSpecified_Err.txt"
    Private ErrCardAcceptorStatusIsNotSpecified_FileName As String = "SendToSwitch_Modify_CardAcceptorStatusIsNotSpecified_Err.txt"
    Private ErrDuplicateTerminalSerialNo_FileName As String = "SendToSwitch_Modify_DuplicateTerminalSerialNo_Err.txt"
    Private ErrExternalAccountNumberIsNotSpecified_FileName As String = "SendToSwitch_Modify_ExternalAccountNumberIsNotSpecified_Err.txt"
    Private ErrExternalAccountTitleIsNotSpecified_FileName As String = "SendToSwitch_Modify_ExternalAccountTitleIsNotSpecified_Err.txt"
    Private ErrInstitutionAddressIsNotSpecified_FileName As String = "SSendToSwitch_Modify_InstitutionAddressIsNotSpecified_Err.txt"
    Private ErrInstitutionNameIsNotSpecified_FileName As String = "SendToSwitch_Modify_InstitutionNameIsNotSpecified_Err.txt"
    Private ErrInstitutionTypeIsNotSpecified_FileName As String = "SendToSwitch_Modify_InstitutionTypeIsNotSpecified_Err.txt"
    Private ErrInvalidRequest_FileName As String = "SendToSwitch_Modify_InvalidRequest_Err.txt"
    Private ErrPeerNameIsNotSpecified_FileName As String = "SendToSwitch_Modify_PeerNameIsNotSpecified_Err.txt"
    Private ErrPeerTypeIsNotSpecified_FileName As String = "SendToSwitch_Modify_PeerTypeIsNotSpecified_Err.txt"
    Private ErrTerminalSerialNoIsNotSpecified_FileName As String = "SendToSwitch_Modify_TerminalSerialNoIsNotSpecified_Err.txt"
    Private ErrDuplicateCardAcceptorId_FileName As String = "SendToSwitch_Modify_DuplicateCardAcceptorId_Err.txt"
    Private ErrDuplicateTerminalId_FileName As String = "SendToSwitch_Modify_DuplicateTerminalId_Err.txt"
#End Region

    Private Sub frmSwitchSendTo_Modify_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
    End Sub

    Private Sub btnTejaratSwitchCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTejaratSwitchCancel.Click

        Try
            colError.Clear()
            Dim clsBLLSwitch_AcceptorManagement As New ClassBLLSwitch_AcceptorManagement
            Dim clsBLLCMSSwitch_AcceptorManagement As New ClassBLLCMSSwitch_AcceptorManagement

            Dim dtNotSentSwitch_Modify_Device As New DataTable
            dtNotSentSwitch_Modify_Device = clsDalSwitchSend.ForSwitch_Modify_Device_Cancel_GetAllNotSentSwith(ClassUserLoginDataAccess.ThisUser.ProjectID)

            If dtNotSentSwitch_Modify_Device.Rows.Count = 0 Then
                ShowErrorMessage("موردی برای بروزرسانی یافت نشد")
                Exit Sub
            End If

            prgCancel.Value = 0
            prgCancel.Maximum = dtNotSentSwitch_Modify_Device.Rows.Count
            grpCancel.Text = dtNotSentSwitch_Modify_Device.Rows.Count

            Dim connect As Boolean = False

            For i As Int32 = 0 To dtNotSentSwitch_Modify_Device.Rows.Count - 1

                Try
                    clsBLLSwitch_AcceptorManagement.mUrl = dtNotSentSwitch_Modify_Device.Rows(i).Item("essws_nvc").ToString

                    Application.DoEvents()
                    prgCancel.Value = i + 1
                    clsBLLSwitch_AcceptorManagement.Switch_Modify_DeviceID = dtNotSentSwitch_Modify_Device.Rows(i).Item("Switch_Modify_DeviceID")
                    clsBLLSwitch_AcceptorManagement.Switch_TerminalID = dtNotSentSwitch_Modify_Device.Rows(i).Item("Content_nvc").ToString

                    clsBLLSwitch_AcceptorManagement.SetTerminalToCancelled(dtNotSentSwitch_Modify_Device.Rows(i).Item("essws_nvc").ToString)

                    If Not ((dtNotSentSwitch_Modify_Device.Rows(i).Item("CMSOutlet_vc") Is DBNull.Value)) AndAlso Not ((dtNotSentSwitch_Modify_Device.Rows(i).Item("CMSOutlet_vc") = String.Empty)) Then
                        clsBLLCMSSwitch_AcceptorManagement.Switch_Modify_DeviceID = dtNotSentSwitch_Modify_Device.Rows(i).Item("Switch_Modify_DeviceID")
                        clsBLLCMSSwitch_AcceptorManagement.Switch_TerminalID = dtNotSentSwitch_Modify_Device.Rows(i).Item("CMSOutlet_vc").ToString
                        clsBLLCMSSwitch_AcceptorManagement.SetTerminalToCancelled(dtNotSentSwitch_Modify_Device.Rows(i).Item("essws_nvc").ToString)
                    End If

                Catch ex As Exception

                    colError.Add("خطا در کد پایانه:" & clsBLLSwitch_AcceptorManagement.Switch_TerminalID.ToString & Space(3) & ex.Message)
                    Continue For

                End Try

            Next

            If ErrHandling() = False Then
                ShowMessage(modApplicationMessage.msgSuccess)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub

    Private Sub btnTejaratSwitchChangePos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTejaratSwitchChangePos.Click
        Try
            colError.Clear()
            Dim clsBLLSwitch_AcceptorManagement As New ClassBLLSwitch_AcceptorManagement
            Dim clsBLLCMSSwitch_AcceptorManagement As New ClassBLLCMSSwitch_AcceptorManagement

            Dim dtNotSentSwitch_Modify_Device As New DataTable
            dtNotSentSwitch_Modify_Device = clsDalSwitchSend.ForSwitch_Modify_Device_PosChange_GetAllNotSentSwith(ClassUserLoginDataAccess.ThisUser.ProjectID)

            If dtNotSentSwitch_Modify_Device.Rows.Count = 0 Then
                ShowErrorMessage("موردی برای بروزرسانی یافت نشد")
                Exit Sub
            End If

            prgChange.Value = 0
            prgChange.Maximum = dtNotSentSwitch_Modify_Device.Rows.Count
            grpChange.Text = dtNotSentSwitch_Modify_Device.Rows.Count

            Dim PosDal As New ClassDALPos(modPublicMethod.ConnectionString)
            Dim dtSerial As New DataTable

            For i As Int32 = 0 To dtNotSentSwitch_Modify_Device.Rows.Count - 1
                Try
                    clsBLLSwitch_AcceptorManagement.mUrl = dtNotSentSwitch_Modify_Device.Rows(i).Item("essws_nvc").ToString

                    Application.DoEvents()
                    prgChange.Value = i + 1

                    PosDal.Serial_vc = dtNotSentSwitch_Modify_Device.Rows(i).Item("ContentAfter_nvc").ToString()
                    dtSerial.Clear()
                    dtSerial = PosDal.GetBySerialPos()

                    clsBLLSwitch_AcceptorManagement.Switch_Modify_DeviceID = dtNotSentSwitch_Modify_Device.Rows(i).Item("Switch_Modify_DeviceID")
                    clsBLLSwitch_AcceptorManagement.Switch_TerminalID = dtNotSentSwitch_Modify_Device.Rows(i).Item("Content_nvc").ToString
                    clsBLLSwitch_AcceptorManagement.mUrl = dtNotSentSwitch_Modify_Device.Rows(i).Item("essws_nvc").ToString

                    If dtSerial.Rows(0)("PosModelID") = 4 Then
                        clsBLLSwitch_AcceptorManagement.SerialNo = dtNotSentSwitch_Modify_Device.Rows(i).Item("ContentAfter_nvc").ToString.Replace(" ", "").Replace("-", "")
                    Else
                        clsBLLSwitch_AcceptorManagement.SerialNo = dtNotSentSwitch_Modify_Device.Rows(i).Item("ContentAfter_nvc").ToString
                    End If

                    clsBLLSwitch_AcceptorManagement.ModifyTermianlSerial(clsBLLSwitch_AcceptorManagement.mUrl)

                    If Not ((dtNotSentSwitch_Modify_Device.Rows(i).Item("CMSOutlet_vc") Is DBNull.Value)) AndAlso Not ((dtNotSentSwitch_Modify_Device.Rows(i).Item("CMSOutlet_vc") = String.Empty)) Then
                        clsBLLCMSSwitch_AcceptorManagement.Switch_Modify_DeviceID = dtNotSentSwitch_Modify_Device.Rows(i).Item("Switch_Modify_DeviceID")
                        clsBLLCMSSwitch_AcceptorManagement.Switch_TerminalID = dtNotSentSwitch_Modify_Device.Rows(i).Item("CMSOutlet_vc").ToString
                        clsBLLCMSSwitch_AcceptorManagement.SerialNo = clsBLLSwitch_AcceptorManagement.SerialNo
                        clsBLLCMSSwitch_AcceptorManagement.ModifyTermianlSerial(clsBLLSwitch_AcceptorManagement.mUrl)
                    End If

                Catch ex As Exception
                    colError.Add("خطا در کد پایانه:" & clsBLLSwitch_AcceptorManagement.Switch_TerminalID.ToString & Space(3) & ex.Message)
                    Continue For
                End Try
            Next
            If ErrHandling() = False Then
                ShowMessage(modApplicationMessage.msgSuccess)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub

    Private Function ErrHandling() As Boolean
        Try
            ClassError.BackupLogErrorFolder()
            ClassError.EmptyLogErrorFolder()
            If colError.Count > 0 Then
                ClassError.LogError(Error_FileName, colError)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colError.Count.ToString & vbCrLf & modApplicationMessage.msgCollectionError & vbCrLf + TextLogErrorFilePath + Error_FileName)
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub btnTejaratUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTejaratUpdate.Click
        Try
            clsDalSwitchSendTo.OpenConnection()
            Switch_Modify()
            If SendToSwitch_ErrHandling() = False Then
                ShowMessage(modApplicationMessage.msgSuccess)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            clsDalSwitchSendTo.CloseConnection()
        End Try
    End Sub

    Private Sub Switch_Modify()
        Try
            colError.Clear()

            Dim dtSwitch_Modify As New DataTable
            Dim Status As String
            Dim FieldName As String = String.Empty
            Dim FieldValue As String = String.Empty

            Dim dtNotSentSwitch_Modify As New DataTable
            dtNotSentSwitch_Modify = clsDalSwitchSendTo.ForSwitch_Modify_GetAllNotSentSwith()

            prgModifyCardAcceptor.Value = 0
            prgModifyCardAcceptor.Maximum = dtNotSentSwitch_Modify.Rows.Count

            grpModifyCardAcceptor.Text = dtNotSentSwitch_Modify.Rows.Count
            For i As Int32 = 0 To dtNotSentSwitch_Modify.Rows.Count - 1

                'clsBLLSwitch_AcceptorManagement.mUrl = dtNotSentSwitch_Modify.Rows(i)("essws_nvc").Value.ToString
                'If Not myConStr.ConnectionAvailable(clsBLLSwitch_AcceptorManagement.mUrl) Then
                '    ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
                '    Continue For
                'End If

                Application.DoEvents()
                prgModifyCardAcceptor.Value = i + 1
                clsBLLSwitch_AcceptorManagement.Switch_ModifyID = dtNotSentSwitch_Modify.Rows(i).Item("Switch_ModifyID")
                Status = dtNotSentSwitch_Modify.Rows(i).Item("Status_vc")
                FieldName = dtNotSentSwitch_Modify.Rows(i).Item("Type_vc")
                FieldValue = dtNotSentSwitch_Modify.Rows(i).Item("ContentAfter_nvc")

                If Status = "CardAcceptor" Then
                    clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID = dtNotSentSwitch_Modify.Rows(i).Item("Content_nvc").ToString
                ElseIf Status = "Terminal" Then
                    clsBLLSwitch_AcceptorManagement.Switch_TerminalID = dtNotSentSwitch_Modify.Rows(i).Item("Content_nvc").ToString
                End If

                Select Case Status
                    Case "CardAcceptor"
                        'Modify CardAcceptor 
                        '==============================================
                        Try
                            clsBLLSwitch_AcceptorManagement.ModifyCardAcceptor(FieldName, FieldValue)
                        Catch ex As Exception
                            Select Case ex.Message.ToString
                                Case "DuplicateCardAcceptorId"
                                    colDuplicateCardAcceptorId.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "DuplicateTerminalId"
                                    colDuplicateCardAcceptorId.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "CardAcceptorIdIsNotSpecified"
                                    colCardAcceptorIdIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "CardAcceptorIdNotFound"
                                    colCardAcceptorIdNotFound.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "CardAcceptorInstitutionExternalAccountNotFound"
                                    colCardAcceptorInstitutionExternalAccountNotFound.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "CardAcceptorInstitutionNotFound"
                                    colCardAcceptorInstitutionNotFound.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "CardAcceptorReconciliationCycleLenghtIsNotSpecified"
                                    colCardAcceptorReconciliationCycleLenghtIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "CardAcceptorSettlementMethodIsNotSpecified"
                                    colCardAcceptorSettlementMethodIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "CardAcceptorStatusIsNotSpecified"
                                    colCardAcceptorStatusIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "DuplicateTerminalSerialNo"
                                    colDuplicateTerminalSerialNo.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "ExternalAccountNumberIsNotSpecified"
                                    colExternalAccountNumberIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "ExternalAccountTitleIsNotSpecified"
                                    colExternalAccountTitleIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "InstitutionAddressIsNotSpecified"
                                    colInstitutionAddressIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "InstitutionNameIsNotSpecified"
                                    colInstitutionNameIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "InstitutionTypeIsNotSpecified"
                                    colInstitutionTypeIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "InvalidRequest"
                                    colInvalidRequest.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "PeerNameIsNotSpecified"
                                    colPeerNameIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "PeerTypeIsNotSpecified"
                                    colPeerTypeIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "TerminalIdIsNotSpecified"
                                    colTerminalIdIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "TerminalSerialNoIsNotSpecified"
                                    colTerminalSerialNoIsNotSpecified.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                                Case "SwitchCardAcceptorID is not found in PSPDataBase"
                                    colCardAcceptorInstitutionNotFound.Add(clsBLLSwitch_AcceptorManagement.Switch_CardAcceptorID)
                            End Select

                        End Try
                    Case "Terminal"
                        'Modify Terminal 
                        '==============================================
                End Select
            Next
            If dtNotSentSwitch_Modify.Rows.Count = 0 Then
                ShowErrorMessage("موردی برای بروزرسانی یافت نشد")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub SinaSwitch_Modify()
    '    Dim clsBLLSinaSwitch_AcceptorManagement As New ClassBLLSwitch_SinaAcceptorManagement
    '    Try
    '        colError.Clear()

    '        Dim dtSinaSwitch_Modify As New DataTable
    '        Dim Status As String
    '        Dim FieldName As String = String.Empty
    '        Dim FieldValue As String = String.Empty

    '        Dim dtNotSentToSinaSwitch_Modify As New DataTable
    '        dtNotSentToSinaSwitch_Modify = clsDalSwitchSendTo.ForSwitch_Modify_GetAllNotSentToSinaSwith()

    '        prgModifyCardAcceptor.Value = 0
    '        prgModifyCardAcceptor.Maximum = dtNotSentToSinaSwitch_Modify.Rows.Count

    '        grpModifyCardAcceptor.Text = dtNotSentToSinaSwitch_Modify.Rows.Count
    '        For i As Int32 = 0 To dtNotSentToSinaSwitch_Modify.Rows.Count - 1
    '            Application.DoEvents()
    '            prgModifyCardAcceptor.Value = i + 1
    '            clsBLLSinaSwitch_AcceptorManagement.Switch_ModifyID = dtNotSentToSinaSwitch_Modify.Rows(i).Item("Switch_ModifyID")
    '            Status = dtNotSentToSinaSwitch_Modify.Rows(i).Item("Status_vc")
    '            FieldName = dtNotSentToSinaSwitch_Modify.Rows(i).Item("Type_vc")
    '            FieldValue = dtNotSentToSinaSwitch_Modify.Rows(i).Item("ContentAfter_nvc")

    '            If Status = "CardAcceptor" Then
    '                clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID = dtNotSentToSinaSwitch_Modify.Rows(i).Item("Content_nvc").ToString
    '            ElseIf Status = "Terminal" Then
    '                clsBLLSinaSwitch_AcceptorManagement.Switch_TerminalID = dtNotSentToSinaSwitch_Modify.Rows(i).Item("Content_nvc").ToString
    '            End If

    '            Select Case Status
    '                Case "CardAcceptor"
    '                    'Modify CardAcceptor 
    '                    '==============================================
    '                    Try
    '                        clsBLLSinaSwitch_AcceptorManagement.ModifyCardAcceptor(FieldName, FieldValue)
    '                    Catch ex As Exception
    '                        Select Case ex.Message.ToString
    '                            Case "DuplicateCardAcceptorId"
    '                                colDuplicateCardAcceptorId.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "DuplicateTerminalId"
    '                                colDuplicateCardAcceptorId.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "CardAcceptorIdIsNotSpecified"
    '                                colCardAcceptorIdIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "CardAcceptorIdNotFound"
    '                                colCardAcceptorIdNotFound.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "CardAcceptorInstitutionExternalAccountNotFound"
    '                                colCardAcceptorInstitutionExternalAccountNotFound.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "CardAcceptorInstitutionNotFound"
    '                                colCardAcceptorInstitutionNotFound.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "CardAcceptorReconciliationCycleLenghtIsNotSpecified"
    '                                colCardAcceptorReconciliationCycleLenghtIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "CardAcceptorSettlementMethodIsNotSpecified"
    '                                colCardAcceptorSettlementMethodIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "CardAcceptorStatusIsNotSpecified"
    '                                colCardAcceptorStatusIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "DuplicateTerminalSerialNo"
    '                                colDuplicateTerminalSerialNo.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "ExternalAccountNumberIsNotSpecified"
    '                                colExternalAccountNumberIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "ExternalAccountTitleIsNotSpecified"
    '                                colExternalAccountTitleIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "InstitutionAddressIsNotSpecified"
    '                                colInstitutionAddressIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "InstitutionNameIsNotSpecified"
    '                                colInstitutionNameIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "InstitutionTypeIsNotSpecified"
    '                                colInstitutionTypeIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "InvalidRequest"
    '                                colInvalidRequest.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "PeerNameIsNotSpecified"
    '                                colPeerNameIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "PeerTypeIsNotSpecified"
    '                                colPeerTypeIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "TerminalIdIsNotSpecified"
    '                                colTerminalIdIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "TerminalSerialNoIsNotSpecified"
    '                                colTerminalSerialNoIsNotSpecified.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                            Case "SwitchCardAcceptorID is not found in PSPDataBase"
    '                                colCardAcceptorInstitutionNotFound.Add(clsBLLSinaSwitch_AcceptorManagement.Switch_CardAcceptorID)
    '                        End Select

    '                    End Try
    '                Case "Terminal"
    '                    'Modify Terminal 
    '                    '==============================================
    '            End Select
    '        Next
    '        If dtNotSentToSinaSwitch_Modify.Rows.Count = 0 Then
    '            ShowErrorMessage("موردی برای بروزرسانی یافت نشد")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


    Private Function SendToSwitch_ErrHandling() As Boolean
        Try
            Dim hErr As Boolean = False
            ClassError.BackupLogErrorFolder()
            ClassError.EmptyLogErrorFolder()

            If colTerminalIdIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrTerminalIdIsNotSpecified_FileName, colTerminalIdIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colTerminalIdIsNotSpecified.Count.ToString & vbCrLf & "TerminalIdIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrTerminalIdIsNotSpecified_FileName)
            End If

            If colCardAcceptorIdIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrCardAcceptorIdIsNotSpecified_FileName, colCardAcceptorIdIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colCardAcceptorIdIsNotSpecified.Count.ToString & vbCrLf & "CardAcceptorIdIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrCardAcceptorIdIsNotSpecified_FileName)
            End If
            If colCardAcceptorIdNotFound.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrCardAcceptorIdNotFound_FileName, colCardAcceptorIdNotFound)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colCardAcceptorIdNotFound.Count.ToString & vbCrLf & "CardAcceptorIdNotFound!" & vbCrLf + TextLogErrorFilePath + ErrCardAcceptorIdNotFound_FileName)
            End If
            If colCardAcceptorInstitutionExternalAccountNotFound.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrCardAcceptorInstitutionExternalAccountNotFound_FileName, colCardAcceptorInstitutionExternalAccountNotFound)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colCardAcceptorInstitutionExternalAccountNotFound.Count.ToString & vbCrLf & "!" & vbCrLf + TextLogErrorFilePath + ErrCardAcceptorInstitutionExternalAccountNotFound_FileName)
            End If
            If colCardAcceptorInstitutionNotFound.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrCardAcceptorInstitutionNotFound_FileName, colCardAcceptorInstitutionNotFound)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colCardAcceptorInstitutionNotFound.Count.ToString & vbCrLf & "!" & vbCrLf + TextLogErrorFilePath + ErrCardAcceptorInstitutionNotFound_FileName)
            End If
            If colCardAcceptorReconciliationCycleLenghtIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrCardAcceptorReconciliationCycleLenghtIsNotSpecified_FileName, colCardAcceptorReconciliationCycleLenghtIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colCardAcceptorReconciliationCycleLenghtIsNotSpecified.Count.ToString & vbCrLf & "CardAcceptorReconciliationCycleLenghtIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrCardAcceptorReconciliationCycleLenghtIsNotSpecified_FileName)
            End If
            If colCardAcceptorSettlementMethodIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrCardAcceptorSettlementMethodIsNotSpecified_FileName, colCardAcceptorSettlementMethodIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colCardAcceptorSettlementMethodIsNotSpecified.Count.ToString & vbCrLf & "CardAcceptorSettlementMethodIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrCardAcceptorSettlementMethodIsNotSpecified_FileName)
            End If
            If colCardAcceptorStatusIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrCardAcceptorStatusIsNotSpecified_FileName, colCardAcceptorStatusIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colCardAcceptorStatusIsNotSpecified.Count.ToString & vbCrLf & "CardAcceptorStatusIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrCardAcceptorStatusIsNotSpecified_FileName)
            End If
            If colDuplicateTerminalSerialNo.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrDuplicateTerminalSerialNo_FileName, colDuplicateTerminalSerialNo)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colDuplicateTerminalSerialNo.Count.ToString & vbCrLf & "DuplicateTerminalSerialNo!" & vbCrLf + TextLogErrorFilePath + ErrDuplicateTerminalSerialNo_FileName)
            End If
            If colExternalAccountNumberIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrExternalAccountNumberIsNotSpecified_FileName, colExternalAccountNumberIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colExternalAccountNumberIsNotSpecified.Count.ToString & vbCrLf & "ExternalAccountNumberIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrExternalAccountNumberIsNotSpecified_FileName)
            End If
            If colExternalAccountTitleIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrExternalAccountTitleIsNotSpecified_FileName, colExternalAccountTitleIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colExternalAccountTitleIsNotSpecified.Count.ToString & vbCrLf & "ExternalAccountTitleIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrExternalAccountTitleIsNotSpecified_FileName)
            End If
            If colInstitutionAddressIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrInstitutionAddressIsNotSpecified_FileName, colInstitutionAddressIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colInstitutionAddressIsNotSpecified.Count.ToString & vbCrLf & "InstitutionAddressIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrInstitutionAddressIsNotSpecified_FileName)
            End If
            If colInstitutionNameIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrInstitutionNameIsNotSpecified_FileName, colInstitutionNameIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colInstitutionNameIsNotSpecified.Count.ToString & vbCrLf & "InstitutionNameIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrInstitutionNameIsNotSpecified_FileName)
            End If
            If colInstitutionTypeIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrInstitutionTypeIsNotSpecified_FileName, colInstitutionTypeIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colInstitutionTypeIsNotSpecified.Count.ToString & vbCrLf & "InstitutionTypeIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrInstitutionTypeIsNotSpecified_FileName)
            End If
            If colInvalidRequest.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrInvalidRequest_FileName, colInvalidRequest)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colInvalidRequest.Count.ToString & vbCrLf & "InvalidRequest!" & vbCrLf + TextLogErrorFilePath + ErrInvalidRequest_FileName)
            End If
            If colPeerNameIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrPeerNameIsNotSpecified_FileName, colPeerNameIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colPeerNameIsNotSpecified.Count.ToString & vbCrLf & "PeerNameIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrPeerNameIsNotSpecified_FileName)
            End If
            If colPeerTypeIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrPeerTypeIsNotSpecified_FileName, colPeerTypeIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colPeerTypeIsNotSpecified.Count.ToString & vbCrLf & "PeerTypeIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrPeerTypeIsNotSpecified_FileName)
            End If
            If colTerminalSerialNoIsNotSpecified.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrTerminalSerialNoIsNotSpecified_FileName, colTerminalSerialNoIsNotSpecified)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colTerminalSerialNoIsNotSpecified.Count.ToString & vbCrLf & "TerminalSerialNoIsNotSpecified!" & vbCrLf + TextLogErrorFilePath + ErrTerminalSerialNoIsNotSpecified_FileName)
            End If
            If colDuplicateCardAcceptorId.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrDuplicateCardAcceptorId_FileName, colDuplicateCardAcceptorId)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colDuplicateCardAcceptorId.Count.ToString & vbCrLf & "DuplicateCardAcceptorId!" & vbCrLf + TextLogErrorFilePath + ErrDuplicateCardAcceptorId_FileName)
            End If
            If colDuplicateTerminalId.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrDuplicateTerminalId_FileName, colDuplicateTerminalId)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colDuplicateTerminalId.Count.ToString & vbCrLf & "DuplicateTerminalId!" & vbCrLf + TextLogErrorFilePath + ErrDuplicateTerminalId_FileName)
            End If

            SendToSwitch_ErrHandling = hErr
        Catch ex As Exception
            SendToSwitch_ErrHandling = False
            Throw ex
        End Try

    End Function

    'Private Sub btnSinaSwitchCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSinaSwitchCancel.Click
    '    Try
    '        SinaColError.Clear()
    '        Dim clsBLLSinaSwitch_AcceptorManagement As New ClassBLLSwitch_SinaAcceptorManagement

    '        Dim dtNotSentToSinaSwitch_Modify_Device As New DataTable
    '        dtNotSentToSinaSwitch_Modify_Device = clsDalSwitchSend.ForSwitch_Modify_Device_Cancel_GetAllNotSentToSinaSwith(ClassUserLoginDataAccess.ThisUser.ProjectID)
    '        If dtNotSentToSinaSwitch_Modify_Device.Rows.Count = 0 Then
    '            ShowErrorMessage("موردی برای بروزرسانی سینایافت نشد")
    '            Exit Sub
    '        End If
    '        prgCancel.Value = 0
    '        prgCancel.Maximum = dtNotSentToSinaSwitch_Modify_Device.Rows.Count
    '        grpCancel.Text = dtNotSentToSinaSwitch_Modify_Device.Rows.Count

    '        For i As Int32 = 0 To dtNotSentToSinaSwitch_Modify_Device.Rows.Count - 1
    '            Try
    '                Application.DoEvents()
    '                prgCancel.Value = i + 1
    '                clsBLLSinaSwitch_AcceptorManagement.Switch_Modify_DeviceID = dtNotSentToSinaSwitch_Modify_Device.Rows(i).Item("Switch_Modify_DeviceID")
    '                clsBLLSinaSwitch_AcceptorManagement.Switch_TerminalID = dtNotSentToSinaSwitch_Modify_Device.Rows(i).Item("Content_nvc").ToString
    '                clsBLLSinaSwitch_AcceptorManagement.SetTerminalToCancelled()
    '            Catch ex As Exception
    '                SinaColError.Add("خطا در کد پایانه:" & clsBLLSinaSwitch_AcceptorManagement.Switch_TerminalID.ToString & Space(3) & ex.Message)
    '                Continue For
    '            End Try
    '        Next
    '        If SinaErrHandling() = False Then
    '            ShowMessage(modApplicationMessage.msgSuccess)
    '        End If
    '    Catch ex As Exception
    '        ShowErrorMessage(ex.Message)
    '    End Try

    'End Sub

    'Private Sub btnSinaSwitchChangePos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSinaSwitchChangePos.Click
    '    Try
    '        colError.Clear()
    '        Dim clsBLLSinaSwitch_AcceptorManagement As New ClassBLLSwitch_SinaAcceptorManagement

    '        Dim dtNotSentTOSinaSwitch_Modify_Device As New DataTable
    '        dtNotSentTOSinaSwitch_Modify_Device = clsDalSwitchSend.ForSwitch_Modify_Device_PosChange_GetAllNotSentToSinaSwith(ClassUserLoginDataAccess.ThisUser.ProjectID)
    '        If dtNotSentTOSinaSwitch_Modify_Device.Rows.Count = 0 Then
    '            ShowErrorMessage("موردی برای بروزرسانی سینا یافت نشد")
    '            Exit Sub
    '        End If
    '        prgChange.Value = 0
    '        prgChange.Maximum = dtNotSentTOSinaSwitch_Modify_Device.Rows.Count
    '        grpChange.Text = dtNotSentTOSinaSwitch_Modify_Device.Rows.Count

    '        Dim PosDal As New ClassDALPos(modPublicMethod.ConnectionString)
    '        Dim dtSerial As New DataTable

    '        For i As Int32 = 0 To dtNotSentTOSinaSwitch_Modify_Device.Rows.Count - 1
    '            Try
    '                Application.DoEvents()
    '                prgChange.Value = i + 1

    '                PosDal.Serial_vc = dtNotSentTOSinaSwitch_Modify_Device.Rows(i).Item("ContentAfter_nvc").ToString()
    '                dtSerial.Clear()
    '                dtSerial = PosDal.GetBySerialPos()

    '                clsBLLSinaSwitch_AcceptorManagement.Switch_Modify_DeviceID = dtNotSentTOSinaSwitch_Modify_Device.Rows(i).Item("Switch_Modify_DeviceID")
    '                clsBLLSinaSwitch_AcceptorManagement.Switch_TerminalID = dtNotSentTOSinaSwitch_Modify_Device.Rows(i).Item("Content_nvc").ToString

    '                If dtSerial.Rows(0)("PosModelID") = 4 Then
    '                    clsBLLSinaSwitch_AcceptorManagement.SerialNo = dtNotSentTOSinaSwitch_Modify_Device.Rows(i).Item("ContentAfter_nvc").ToString.Replace(" ", "").Replace("-", "")
    '                Else
    '                    clsBLLSinaSwitch_AcceptorManagement.SerialNo = dtNotSentTOSinaSwitch_Modify_Device.Rows(i).Item("ContentAfter_nvc").ToString
    '                End If

    '                clsBLLSinaSwitch_AcceptorManagement.ModifyTermianlSerial()

    '            Catch ex As Exception
    '                SinaColError.Add("خطا در کد پایانه:" & clsBLLSinaSwitch_AcceptorManagement.Switch_TerminalID.ToString & Space(3) & ex.Message)
    '                Continue For
    '            End Try
    '        Next
    '        If SinaErrHandling() = False Then
    '            ShowMessage(modApplicationMessage.msgSuccess)
    '        End If
    '    Catch ex As Exception
    '        ShowErrorMessage(ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnSinaUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSinaUpdate.Click
    '    Try
    '        clsDalSwitchSendTo.OpenConnection()
    '        SinaSwitch_Modify()
    '        If SendToSwitch_ErrHandling() = False Then
    '            ShowMessage(modApplicationMessage.msgSuccess)
    '        End If
    '    Catch ex As Exception
    '        ShowErrorMessage(ex.Message)
    '    Finally
    '        clsDalSwitchSendTo.CloseConnection()
    '    End Try
    'End Sub

#Region "Create Shaparak"
    Private Sub BtnCreateShaparak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreateShaparak.Click
        Dim FirstFileNameAndPath As String = String.Empty
        Dim SecoundFileNameAndPath As String = String.Empty
        Dim ThirdFileNameAndPath As String = String.Empty
        Dim FourthFieNameAndPath As String = String.Empty
        Dim RepeatedAccount As String = String.Empty
        Dim FirstFileName As String = "PEC_INSERT_ACCEPTOR"
        Dim SecountFileName As String = "PEC_INSERT_ACCEPTORTERMINAL"
        Dim ThirdFileName As String = "PEC_INSERT_IBAN"
        Dim fourthFileName As String = "INFO_PEC_INSERT_ACCEPTOR"
        Try
            Dim dt As New DataTable
            Dim dtIBAN As New DataTable
            dt.Rows.Clear()
            dtIBAN.Clear()
            clsDalShaparak.OpenConnection()
            clsDalShaparak.BeginProc()
            dt = clsDalShaparak.GetAllNotSentToShaparak(0, "0")
            dtIBAN = clsDalShaparak.GetAllNotSentToShaparakIBAN(0, RepeatedAccount.Trim, "0")
            Dim delimitedFile As DelimitedFile

            Dim FirstFileFields As List(Of Field) = FillFirstFileValue()
            If FirstFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                Exit Sub
            End If

            Dim SecoundFileFields As List(Of Field) = FillSecoundFileValue()
            If SecoundFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                Exit Sub
            End If

            Dim ThirdFileFields As List(Of Field) = FillThirdFileValue()
            If ThirdFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                Exit Sub
            End If

            Dim fourthFileFields As List(Of Field) = FillFourthFileValue()
            If ThirdFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
            End If


            Dim inputNumber As String = InputBox("...شماره فایل را وارد نمایید", "تعیین شماره فایل")

            If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK And inputNumber.Trim <> String.Empty Then

                FirstFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", FirstFileName)
                FirstFileNameAndPath = CreateFileName(FirstFileNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(FirstFileNameAndPath, FirstFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dt)

                SecoundFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", SecountFileName)
                SecoundFileNameAndPath = CreateFileName(SecoundFileNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(SecoundFileNameAndPath, SecoundFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dt)

                ThirdFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", ThirdFileName)
                ThirdFileNameAndPath = CreateFileName(ThirdFileNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(ThirdFileNameAndPath, ThirdFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dtIBAN)

                FourthFieNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", fourthFileName)
                FourthFieNameAndPath = CreateFileName(FourthFieNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(FourthFieNameAndPath, fourthFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dt)

                clsDalShaparak.UpdateSentToShaparak(0, 2, "0")
                clsDalShaparak.CommitProc()
                clsDalShaparak.CloseConnection()

                MessageBox.Show("فایل های  شاپرک ایجاد گردید")
            Else

                If inputNumber.Trim = String.Empty Then
                    MessageBox.Show("لطفا شماره فایل را وارد نمایید")
                End If
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("خطا در تولید فایل شاپرک")

            If System.IO.File.Exists(FirstFileNameAndPath) Then
                System.IO.File.Delete(FirstFileNameAndPath)
            End If
            If System.IO.File.Exists(SecoundFileNameAndPath) Then
                System.IO.File.Delete(SecoundFileNameAndPath)
            End If
            If System.IO.File.Exists(ThirdFileNameAndPath) Then
                System.IO.File.Delete(ThirdFileNameAndPath)
            End If

            If System.IO.File.Exists(FourthFieNameAndPath) Then
                System.IO.File.Delete(FourthFieNameAndPath)
            End If

            clsDalShaparak.RollBackProc()
            clsDalShaparak.CloseConnection()
        End Try
    End Sub


#Region "Shaparak INSERT Methods"
    Public Function FillFirstFileValue() As List(Of Field)
        Dim FirstFileFields As New List(Of Field)
        Try
            Dim stateShaparakCode_vc As New EntityField("StateShaparakCode_vc")
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim yValue As New StaticField
            Dim takhsisDate As New StaticField
            takhsisDate.Value = ConvertMethods.DateToByte2(Now.Date)
            Dim storeEnName As New ComputeField(AddressOf ConvertMethods.FaToEnFirsLineBytes, "StoreName")
            Dim storeFaName As New ComputeField(AddressOf ConvertMethods.IranSystemFirstSubStringToByte, "StoreName")
            Dim storeEnAddressFirstLine As New StaticField
            Dim storeFaAddressFirstLine As New ComputeField(AddressOf ConvertMethods.IranSystemSpiltSubStringToByte, "StoreAddress")
            Dim storeEnAddressSecoundLine As New StaticField
            Dim storeFaAddressSecoundLine As New ComputeField(AddressOf ConvertMethods.IranSystemSecoundSubStringToByte, "StoreAddress")
            ' Dim cityEnName As New EntityField("CityEnShaparak")
            Dim cityEnName As New ComputeField(AddressOf ConvertMethods.SpiltSubStringCity, "CityEnShaparak")
            Dim cityFaName As New ComputeField(AddressOf ConvertMethods.GetIranSystem, "CityName")
            Dim shaparakGroupId As New EntityField("ShaparakGroupCode_vc")
            Dim iRValue As New StaticField
            Dim postalCode As New EntityField("PostCode_vc")
            Dim tel As New EntityField("Tel")
            ' Dim fax As New EntityField("Fax")

            Dim empty0 As New StaticField
            Dim empty1 As New StaticField
            Dim empty2 As New StaticField
            Dim empty3 As New StaticField
            Dim empty4 As New StaticField
            Dim nine As New StaticField
            Dim one As New StaticField
            Dim yValue1 As New StaticField
            Dim nValue As New StaticField
            Dim yValue2 As New StaticField
            Dim yValue3 As New StaticField

            empty0.Value = String.Empty
            empty1.Value = String.Empty
            empty2.Value = String.Empty
            empty3.Value = String.Empty
            empty4.Value = String.Empty
            iRValue.Value = "IR"
            nine.Value = "999999999999"
            number.Value = "581672061"
            nValue.Value = "N"
            one.Value = "1"
            yValue.Value = "Y"
            yValue1.Value = "Y"
            yValue2.Value = "Y"
            yValue3.Value = "Y"
            storeEnAddressFirstLine.Value = "ADDRESS"
            storeEnAddressSecoundLine.Value = String.Empty


            FirstFileFields.Add(number)
            FirstFileFields.Add(switchCardAcceptor)
            FirstFileFields.Add(shaparakGroupId)
            FirstFileFields.Add(yValue)
            FirstFileFields.Add(takhsisDate)
            FirstFileFields.Add(storeEnName)
            FirstFileFields.Add(storeFaName)
            FirstFileFields.Add(storeEnAddressFirstLine)
            FirstFileFields.Add(storeFaAddressFirstLine)
            FirstFileFields.Add(storeEnAddressSecoundLine)
            FirstFileFields.Add(storeFaAddressSecoundLine)
            FirstFileFields.Add(cityEnName)
            FirstFileFields.Add(cityFaName)
            FirstFileFields.Add(stateShaparakCode_vc)
            FirstFileFields.Add(iRValue)
            FirstFileFields.Add(postalCode)
            FirstFileFields.Add(tel)
            '            FirstFileFields.Add(fax)
            FirstFileFields.Add(empty0)
            FirstFileFields.Add(empty1)
            FirstFileFields.Add(empty2)
            FirstFileFields.Add(empty3)
            FirstFileFields.Add(empty4)
            FirstFileFields.Add(nine)
            FirstFileFields.Add(one)
            FirstFileFields.Add(yValue1)
            FirstFileFields.Add(nValue)
            FirstFileFields.Add(yValue2)
            FirstFileFields.Add(yValue3)
        Catch ex As Exception
            MessageBox.Show("خطا در ثبت فیلدهای فایل اول")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return FirstFileFields

    End Function

    Public Function FillSecoundFileValue() As List(Of Field)
        Dim SecoundFileFields As New List(Of Field)
        Try
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim switch_TerminalID_vc As New EntityField("Switch_TerminalID_vc")
            Dim pos As New StaticField
            Dim yValue As New StaticField
            'Dim takhsisDate As New ComputeField(AddressOf ConvertMethods.DateToByte, "TakhsisDate")
            Dim takhsisDate As New StaticField
            takhsisDate.Value = ConvertMethods.DateToByte2(Now.Date)

            Dim null As New StaticField

            number.Value = "581672061"
            pos.Value = "POS"
            yValue.Value = "Y"
            null.Value = String.Empty
            SecoundFileFields.Add(number)
            SecoundFileFields.Add(switchCardAcceptor)
            SecoundFileFields.Add(switch_TerminalID_vc)
            SecoundFileFields.Add(pos)
            SecoundFileFields.Add(yValue)
            SecoundFileFields.Add(takhsisDate)
            SecoundFileFields.Add(null)
        Catch ex As Exception
            MessageBox.Show("خطا در ثبت فیلدهای فایل دوم")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return SecoundFileFields
    End Function

    Public Function FillThirdFileValue() As List(Of Field)
        Dim ThirdFileFields As New List(Of Field)
        Try
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim shabaAccount As New ComputeField(AddressOf ConvertMethods.IBAN, "ShabaAccount")
            Dim yValue As New StaticField
            'Dim takhsisDate As New ComputeField(AddressOf ConvertMethods.DateToByte, "TakhsisDate")
            Dim takhsisDate As New StaticField
            takhsisDate.Value = ConvertMethods.DateToByte2(Now.Date)
            Dim null As New StaticField

            number.Value = "581672061"
            yValue.Value = "Y"
            null.Value = String.Empty

            ThirdFileFields.Add(number)
            ThirdFileFields.Add(switchCardAcceptor)
            ThirdFileFields.Add(shabaAccount)
            ThirdFileFields.Add(yValue)
            ThirdFileFields.Add(takhsisDate)
            ThirdFileFields.Add(null)
        Catch ex As Exception
            MessageBox.Show("خطا در ثبت فیلدهای فایل سوم")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return ThirdFileFields
    End Function

    Public Function FillFourthFileValue() As List(Of Field)
        Dim FourthFileFileds As New List(Of Field)
        Try
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim type As New StaticField
            Dim code1 As New EntityField("nationalcode_nvc")
            Dim code2 As New StaticField
            Dim code3 As New StaticField
            Dim code4 As New StaticField

            '  Dim fName As New ComputeField(AddressOf ConvertMethods.GetIranSystem, "firstname_nvc")
            ' Dim lName As New ComputeField(AddressOf ConvertMethods.GetIranSystem, "lastname_nvc")

            Dim fNameLname1 As New ComputeField(AddressOf ConvertMethods.SpiltSubStringFullName, "FullName")
            Dim fNameLname2 As New StaticField
            Dim fNameLname3 As New StaticField
            Dim fNameLname4 As New StaticField

            Dim cityTelCode As New EntityField("areanumber_vc")
            Dim CountryTelCode As New StaticField
            Dim GroupShaparkNo As New EntityField("GroupShaparakno_vc")
            Dim ActivityNo As New StaticField
            Dim ActivitySource As New StaticField


            number.Value = "581672061"
            type.Value = "0"
            code2.Value = String.Empty
            code3.Value = String.Empty
            code4.Value = String.Empty
            fNameLname2.Value = String.Empty
            fNameLname3.Value = String.Empty
            fNameLname4.Value = String.Empty
            CountryTelCode.Value = "98"
            ActivityNo.Value = String.Empty
            ActivitySource.Value = String.Empty

            FourthFileFileds.Add(number)
            FourthFileFileds.Add(switchCardAcceptor)
            FourthFileFileds.Add(type)
            FourthFileFileds.Add(code1)
            FourthFileFileds.Add(code2)
            FourthFileFileds.Add(code3)
            FourthFileFileds.Add(code4)
            ' FourthFileFileds.Add(fName)
            ' FourthFileFileds.Add(lName)
            FourthFileFileds.Add(fNameLname1)
            FourthFileFileds.Add(fNameLname2)
            FourthFileFileds.Add(fNameLname3)
            FourthFileFileds.Add(fNameLname4)
            FourthFileFileds.Add(cityTelCode)
            FourthFileFileds.Add(CountryTelCode)
            FourthFileFileds.Add(GroupShaparkNo)
            FourthFileFileds.Add(ActivityNo)
            FourthFileFileds.Add(ActivitySource)

        Catch ex As Exception
            MessageBox.Show("INFO خطا در ثبت فیلدهای فایل ")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return FourthFileFileds
    End Function

    Public Function CreateFileName(ByVal fileNameAndPath As String, ByVal inputNumber As String) As String
        Dim fileDate As String

        If CheckDigit(inputNumber) Then
            If inputNumber.Length < 2 Then
                inputNumber = inputNumber.Replace(inputNumber, "0" + inputNumber)
            End If
            fileDate = GetDateNow().Replace("/", String.Empty).Remove(0, 2)
            Return String.Concat(fileNameAndPath, "_", fileDate, "_", inputNumber, ".txt")
        End If
        Return String.Empty

    End Function

    Public Function CheckDigit(ByVal inputNumber As String) As Boolean
        Try
            Dim result As Integer = Integer.Parse(inputNumber)
        Catch ex As Exception
            MessageBox.Show("فرمت عدد ورودی صحیح نمی باشد")
            Return False
        End Try
        Return True
    End Function

#End Region
#End Region

#Region "Update Shaparak"

    Private Sub BtnUpdateShaparak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdateShaparak.Click

        Dim FirstFileNameAndPath As String = String.Empty
        Dim SecoundFileNameAndPath As String = String.Empty
        Dim ThirdFileNameAndPath As String = String.Empty
        Dim fourthFileNameAndPath As String = String.Empty
        Dim RepeatedAccount As String = String.Empty

        Dim FirstFileName As String = "PEC_UPDATE_ACCEPTOR"
        Dim SecountFileName As String = "PEC_UPDATE_ACCEPTORTERMINAL"
        Dim ThirdFileName As String = "PEC_UPDATE_IBAN"
        Dim FourthFileName As String = "INFO_PEC_UPDATE_ACCEPTOR"

        Try
            Dim dt As New DataTable
            Dim dtIBAN As New DataTable
            dt.Rows.Clear()
            dtIBAN.Clear()
            clsDalShaparak.OpenConnection()
            clsDalShaparak.BeginProc()

            dt = clsDalShaparak.GetAllNotSentToShaparak(1, "0")
            dtIBAN = clsDalShaparak.GetAllNotSentToShaparakIBAN(1, RepeatedAccount.Trim, "0")

            Dim delimitedFile As DelimitedFile
            Dim FirstFileFields As List(Of Field) = FillFirstFileValue_UPD()
            If FirstFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                Exit Sub
            End If

            Dim SecoundFileFields As List(Of Field) = FillSecoundFileValue_UPD()
            If SecoundFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                Exit Sub
            End If

            Dim ThirdFileFields As List(Of Field) = FillThirdFileValue_UPD()
            If ThirdFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                Exit Sub
            End If

            Dim FourthFileFields As List(Of Field) = FillFourthFileValue()
            If FourthFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
            End If

            Dim inputNumber As String = InputBox("...شماره فایل را وارد نمایید", "تعیین شماره فایل")

            If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK And inputNumber.Trim <> String.Empty Then

                FirstFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", FirstFileName)
                FirstFileNameAndPath = CreateFileName(FirstFileNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(FirstFileNameAndPath, FirstFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dt)

                SecoundFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", SecountFileName)
                SecoundFileNameAndPath = CreateFileName(SecoundFileNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(SecoundFileNameAndPath, SecoundFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dt)

                ThirdFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", ThirdFileName)
                ThirdFileNameAndPath = CreateFileName(ThirdFileNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(ThirdFileNameAndPath, ThirdFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dtIBAN)


                fourthFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", FourthFileName)
                fourthFileNameAndPath = CreateFileName(fourthFileNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(fourthFileNameAndPath, FourthFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dt)


                clsDalShaparak.UpdateSentToShaparak(1, 2, "0")
                clsDalShaparak.CommitProc()
                clsDalShaparak.CloseConnection()

                MessageBox.Show("فایل های  شاپرک ایجاد گردید")
            Else

                If inputNumber.Trim = String.Empty Then
                    MessageBox.Show("لطفا شماره فایل را وارد نمایید")
                End If
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("خطا در تولید فایل شاپرک")

            If System.IO.File.Exists(FirstFileNameAndPath) Then
                System.IO.File.Delete(FirstFileNameAndPath)
            End If
            If System.IO.File.Exists(SecoundFileNameAndPath) Then
                System.IO.File.Delete(SecoundFileNameAndPath)
            End If
            If System.IO.File.Exists(ThirdFileNameAndPath) Then
                System.IO.File.Delete(ThirdFileNameAndPath)
            End If
            If System.IO.File.Exists(fourthFileNameAndPath) Then
                System.IO.File.Delete(fourthFileNameAndPath)
            End If

            clsDalShaparak.RollBackProc()
            clsDalShaparak.CloseConnection()
        End Try
    End Sub

#Region "Shaparak Update Methods"
    Public Function FillFirstFileValue_UPD() As List(Of Field)
        Dim FirstFileFields As New List(Of Field)
        Try
            Dim stateShaparakCode_vc As New EntityField("StateShaparakCode_vc")
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim yValue As New StaticField
            Dim takhsisDate As New StaticField
            '------------SM takhsisDate.Value = ConvertMethods.DateToByte2(Now.Date)
            Dim storeEnName As New ComputeField(AddressOf ConvertMethods.FaToEnFirsLineBytes, "StoreName")
            Dim storeFaName As New ComputeField(AddressOf ConvertMethods.IranSystemFirstSubStringToByte, "StoreName")
            Dim storeEnAddressFirstLine As New StaticField
            Dim storeFaAddressFirstLine As New ComputeField(AddressOf ConvertMethods.IranSystemSpiltSubStringToByte, "StoreAddress")
            Dim storeEnAddressSecoundLine As New StaticField
            Dim storeFaAddressSecoundLine As New ComputeField(AddressOf ConvertMethods.IranSystemSecoundSubStringToByte, "StoreAddress")
            Dim cityEnName As New ComputeField(AddressOf ConvertMethods.SpiltSubStringCity, "CityEnShaparak")
            Dim cityFaName As New ComputeField(AddressOf ConvertMethods.GetIranSystem, "CityName")
            Dim shaparakGroupId As New EntityField("ShaparakGroupCode_vc")
            Dim iRValue As New StaticField
            Dim postalCode As New EntityField("PostCode_vc")
            Dim tel As New EntityField("Tel")
            'Dim fax As New EntityField("Fax")
            Dim empty0 As New StaticField
            Dim empty1 As New StaticField
            Dim empty2 As New StaticField
            Dim empty3 As New StaticField
            Dim empty4 As New StaticField
            Dim nine As New StaticField
            Dim one As New StaticField
            Dim yValue1 As New StaticField
            Dim nValue As New StaticField
            Dim yValue2 As New StaticField
            Dim yValue3 As New StaticField

            empty0.Value = String.Empty
            empty1.Value = String.Empty
            empty2.Value = String.Empty
            empty3.Value = String.Empty
            empty4.Value = String.Empty
            iRValue.Value = "IR"
            nine.Value = "999999999999"
            number.Value = "581672061"
            nValue.Value = "N"
            one.Value = "1"
            yValue.Value = "Y"
            yValue1.Value = "Y"
            yValue2.Value = "Y"
            yValue3.Value = "Y"
            storeEnAddressFirstLine.Value = "ADDRESS"
            storeEnAddressSecoundLine.Value = String.Empty

            FirstFileFields.Add(number)
            FirstFileFields.Add(switchCardAcceptor)
            FirstFileFields.Add(shaparakGroupId)
            FirstFileFields.Add(yValue)
            '-------------SM  FirstFileFields.Add(takhsisDate)
            FirstFileFields.Add(storeEnName)
            FirstFileFields.Add(storeFaName)
            FirstFileFields.Add(storeEnAddressFirstLine)
            FirstFileFields.Add(storeFaAddressFirstLine)
            FirstFileFields.Add(storeEnAddressSecoundLine)
            FirstFileFields.Add(storeFaAddressSecoundLine)
            FirstFileFields.Add(cityEnName)
            FirstFileFields.Add(cityFaName)
            FirstFileFields.Add(stateShaparakCode_vc)
            FirstFileFields.Add(iRValue)
            FirstFileFields.Add(postalCode)
            FirstFileFields.Add(tel)
            'FirstFileFields.Add(fax)
            FirstFileFields.Add(empty0)
            FirstFileFields.Add(empty1)
            FirstFileFields.Add(empty2)
            FirstFileFields.Add(empty3)
            FirstFileFields.Add(empty4)
            FirstFileFields.Add(nine)
            FirstFileFields.Add(one)
            FirstFileFields.Add(yValue1)
            FirstFileFields.Add(nValue)
            FirstFileFields.Add(yValue2)
            FirstFileFields.Add(yValue3)
        Catch ex As Exception
            MessageBox.Show("خطا در ثبت فیلدهای فایل اول")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return FirstFileFields

    End Function

    Public Function FillSecoundFileValue_UPD() As List(Of Field)
        Dim SecoundFileFields As New List(Of Field)
        Try
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim switch_TerminalID_vc As New EntityField("Switch_TerminalID_vc")
            Dim pos As New StaticField
            Dim yValue As New StaticField
            'Dim takhsisDate As New ComputeField(AddressOf ConvertMethods.DateToByte, "TakhsisDate")
            Dim takhsisDate As New StaticField
            takhsisDate.Value = ConvertMethods.DateToByte2(Now.Date)


            number.Value = "581672061"
            pos.Value = "POS"
            yValue.Value = "Y"

            SecoundFileFields.Add(number)
            SecoundFileFields.Add(switchCardAcceptor)
            SecoundFileFields.Add(switch_TerminalID_vc)
            SecoundFileFields.Add(pos)
            SecoundFileFields.Add(yValue)
            SecoundFileFields.Add(takhsisDate)

        Catch ex As Exception
            MessageBox.Show("خطا در ثبت فیلدهای فایل دوم")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return SecoundFileFields
    End Function

    Public Function FillThirdFileValue_UPD() As List(Of Field)
        Dim ThirdFileFields As New List(Of Field)
        Try
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim shabaAccount As New ComputeField(AddressOf ConvertMethods.IBAN, "ShabaAccount")
            Dim yValue As New StaticField
            'Dim takhsisDate As New ComputeField(AddressOf ConvertMethods.DateToByte, "TakhsisDate")
            '-------------SM Dim takhsisDate As New StaticField
            '--------SM takhsisDate.Value = ConvertMethods.DateToByte2(Now.Date)
            Dim null As New StaticField

            number.Value = "581672061"
            yValue.Value = "Y"
            null.Value = String.Empty

            ThirdFileFields.Add(number)
            ThirdFileFields.Add(switchCardAcceptor)
            ThirdFileFields.Add(shabaAccount)
            ThirdFileFields.Add(yValue)
            ' -----------SM ThirdFileFields.Add(takhsisDate)
            ThirdFileFields.Add(null)
        Catch ex As Exception
            MessageBox.Show("خطا در ثبت فیلدهای فایل سوم")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return ThirdFileFields
    End Function


#End Region
#End Region

#Region "Deleted Shaparak"

    Private Sub BtnDeletedShaparak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeletedShaparak.Click
        '        Dim FirstFileNameAndPath As String = String.Empty
        Dim SecoundFileNameAndPath As String = String.Empty
        Dim ThirdFileNameAndPath As String = String.Empty
        Dim RepeatedAccount As String = String.Empty

        '  Dim FirstFileName As String = "PEC_Not_ACCEPTOR_"
        Dim SecountFileName As String = "PEC_UPDATE_ACCEPTORTERMINAL"
        Dim ThirdFileName As String = "PEC_UPDATE_IBAN"

        Try
            Dim dt As New DataTable
            Dim dtIBAN As New DataTable
            dt.Rows.Clear()
            dtIBAN.Clear()
            clsDalShaparak.OpenConnection()
            clsDalShaparak.BeginProc()

            dt = clsDalShaparak.GetAllNotSentToShaparak(1, "1")
            dtIBAN = clsDalShaparak.GetAllNotSentToShaparakIBAN(1, RepeatedAccount.Trim, "1")

            Dim delimitedFile As DelimitedFile

            'Dim FirstFileFields As List(Of Field) = FillFirstFileValue_UPD()
            'If FirstFileFields.Count = 0 Then
            '    clsDalShaparak.RollBackProc()
            '    clsDalShaparak.CloseConnection()
            '    Exit Sub
            'End If

            Dim SecoundFileFields As List(Of Field) = FillSecoundFileValue_Del()
            If SecoundFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                Exit Sub
            End If

            Dim ThirdFileFields As List(Of Field) = FillThirdFileValue_Del()
            If ThirdFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                Exit Sub
            End If

            Dim inputNumber As String = InputBox("...شماره فایل را وارد نمایید", "تعیین شماره فایل")

            If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK And inputNumber.Trim <> String.Empty Then

                'FirstFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", FirstFileName)
                'FirstFileNameAndPath = CreateFileName(FirstFileNameAndPath, inputNumber)
                'delimitedFile = New DelimitedFile(FirstFileNameAndPath, FirstFileFields, vbCrLf, "|", True)
                'delimitedFile.Write(dt)

                SecoundFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", SecountFileName)
                SecoundFileNameAndPath = CreateFileName(SecoundFileNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(SecoundFileNameAndPath, SecoundFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dt)

                ThirdFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", ThirdFileName)
                ThirdFileNameAndPath = CreateFileName(ThirdFileNameAndPath, inputNumber)
                delimitedFile = New DelimitedFile(ThirdFileNameAndPath, ThirdFileFields, vbCrLf, "|", True)
                delimitedFile.Write(dtIBAN)

                clsDalShaparak.UpdateSentToShaparak(1, 2, "1")
                clsDalShaparak.CommitProc()
                clsDalShaparak.CloseConnection()

                MessageBox.Show("فایل های  شاپرک ایجاد گردید")
            Else

                If inputNumber.Trim = String.Empty Then
                    MessageBox.Show("لطفا شماره فایل را وارد نمایید")
                End If
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("خطا در تولید فایل شاپرک")

            'If System.IO.File.Exists(FirstFileNameAndPath) Then
            '    System.IO.File.Delete(FirstFileNameAndPath)
            'End If
            If System.IO.File.Exists(SecoundFileNameAndPath) Then
                System.IO.File.Delete(SecoundFileNameAndPath)
            End If
            If System.IO.File.Exists(ThirdFileNameAndPath) Then
                System.IO.File.Delete(ThirdFileNameAndPath)
            End If
            clsDalShaparak.RollBackProc()
            clsDalShaparak.CloseConnection()
        End Try
    End Sub
#Region "Shaparak Not Methods"
    Public Function FillSecoundFileValue_Del() As List(Of Field)
        Dim SecoundFileFields As New List(Of Field)
        Try
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim switch_TerminalID_vc As New EntityField("Switch_TerminalID_vc")
            Dim pos As New StaticField
            Dim yValue As New StaticField
            Dim null As New StaticField

            number.Value = "581672061"
            pos.Value = "POS"
            yValue.Value = "N"
            null.Value = String.Empty
            SecoundFileFields.Add(number)
            SecoundFileFields.Add(switchCardAcceptor)
            SecoundFileFields.Add(switch_TerminalID_vc)
            SecoundFileFields.Add(pos)
            SecoundFileFields.Add(yValue)
            SecoundFileFields.Add(null)
        Catch ex As Exception
            MessageBox.Show("خطا در ثبت فیلدهای فایل دوم")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return SecoundFileFields
    End Function

    Public Function FillThirdFileValue_Del() As List(Of Field)
        Dim ThirdFileFields As New List(Of Field)
        Try
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim shabaAccount As New ComputeField(AddressOf ConvertMethods.IBAN, "ShabaAccount")
            Dim yValue As New StaticField
            Dim null As New StaticField

            number.Value = "581672061"
            yValue.Value = "N"
            null.Value = String.Empty

            ThirdFileFields.Add(number)
            ThirdFileFields.Add(switchCardAcceptor)
            ThirdFileFields.Add(shabaAccount)
            ThirdFileFields.Add(yValue)
            ThirdFileFields.Add(null)
        Catch ex As Exception
            MessageBox.Show("خطا در ثبت فیلدهای فایل سوم")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return ThirdFileFields
    End Function


#End Region

#End Region

#Region "Sheba"

    Private Sub BtnSheba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSheba.Click


        Try
            If MakeOldShebaFile() Then
                If MakeNewShebaFile() Then
                    clsDalShaparak.OpenConnection()
                    clsDalShaparak.BeginProc()

                    clsDalShaparak.UpdateISSentToShaparak("1", "2", "1")

                    clsDalShaparak.CommitProc()
                    clsDalShaparak.CloseConnection()

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("خطا در به روز رسانی ")
            MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Public Function MakeOldShebaFile()
        Dim res As Boolean = True
        Dim ThirdDelFileNameAndPath As String = String.Empty
        ' Dim FourthDelFileNameAndPath As String = String.Empty

        Dim RepeatedAccount As String = String.Empty
        Dim ThirdOldFileName As String = "PEC_UPDATE_IBAN"
        ' Dim fourthOldFileName As String = "INFO_PEC_UPDATE_IBAN_"
        Try
            Dim dtIBAN As New DataTable
            dtIBAN.Clear()
            clsDalShaparak.OpenConnection()
            clsDalShaparak.BeginProc()
            dtIBAN = clsDalShaparak.GetAllSentToShaparak("1", "0")

            Dim delimitedFile As DelimitedFile

            Dim ThirdOldFileFields As List(Of Field) = FillThirdFileValue_Sheba("Old")

            If ThirdOldFileFields.Count = 0 Then
                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                res = False
            End If
            'Dim FourthOldFileFields As List(Of Field) = FillFourthFileValue()

            'If FourthOldFileFields.Count = 0 Then
            '    clsDalShaparak.RollBackProc()
            '    clsDalShaparak.CloseConnection()
            '    res = False
            'End If


            If res Then

                Dim inputNumber As String = InputBox("...شماره فایل را وارد نمایید", "تعیین شماره فایل")

                If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK And inputNumber.Trim <> String.Empty Then

                    ThirdDelFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", ThirdOldFileName)
                    ThirdDelFileNameAndPath = CreateFileName(ThirdDelFileNameAndPath, inputNumber)
                    delimitedFile = New DelimitedFile(ThirdDelFileNameAndPath, ThirdOldFileFields, vbCrLf, "|", True)
                    delimitedFile.Write(dtIBAN)

                    'FourthDelFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", fourthOldFileName)
                    'FourthDelFileNameAndPath = CreateFileName(FourthDelFileNameAndPath, inputNumber)
                    'delimitedFile = New DelimitedFile(FourthDelFileNameAndPath, FourthOldFileFields, vbCrLf, "|", True)
                    'delimitedFile.Write(dtIBAN)

                    clsDalShaparak.CommitProc()
                    clsDalShaparak.CloseConnection()

                    MessageBox.Show("فایل به روز رسانی  شاپرک ایجاد گردید")
                Else
                    If inputNumber.Trim = String.Empty Then
                        MessageBox.Show("لطفا شماره فایل به روز رسانی  را وارد نمایید")
                    End If
                    clsDalShaparak.RollBackProc()
                    clsDalShaparak.CloseConnection()

                End If

            End If
        Catch ex As Exception
            MessageBox.Show("خطا در تولید فایل  به روز رسانی شاپرک")

            If System.IO.File.Exists(ThirdDelFileNameAndPath) Then
                System.IO.File.Delete(ThirdDelFileNameAndPath)
            End If
            'If System.IO.File.Exists(FourthDelFileNameAndPath) Then
            '    System.IO.File.Delete(FourthDelFileNameAndPath)
            'End If
            clsDalShaparak.RollBackProc()
            clsDalShaparak.CloseConnection()
            res = False

        End Try
        Return res
    End Function

    Public Function MakeNewShebaFile()
        Dim res As Boolean = True
        Dim ThirdInsFileNameAndPath As String = String.Empty
        Dim RepeatedAccount As String = String.Empty
        Dim ThirdNewFileName As String = "PEC_INSERT_IBAN"
        Try

            Dim dtIBAN As New DataTable
            dtIBAN.Clear()

            clsDalShaparak.OpenConnection()
            clsDalShaparak.BeginProc()
            dtIBAN = clsDalShaparak.GetAllSentToShaparak("1", "0")

            Dim delimitedFile As DelimitedFile

            Dim ThirdNewFileFields As List(Of Field) = FillThirdFileValue_Sheba()

            If ThirdNewFileFields.Count = 0 Then

                clsDalShaparak.RollBackProc()
                clsDalShaparak.CloseConnection()
                res = False
            End If

            If res Then



                Dim inputNumber As String = InputBox("...شماره فایل را وارد نمایید", "تعیین شماره فایل")

                If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK And inputNumber.Trim <> String.Empty Then


                    ThirdInsFileNameAndPath = String.Concat(folderBrowserDialog.SelectedPath.ToString, "\", ThirdNewFileName)
                    ThirdInsFileNameAndPath = CreateFileName(ThirdInsFileNameAndPath, inputNumber)
                    delimitedFile = New DelimitedFile(ThirdInsFileNameAndPath, ThirdNewFileFields, vbCrLf, "|", True)
                    delimitedFile.Write(dtIBAN)

                    clsDalShaparak.CommitProc()
                    clsDalShaparak.CloseConnection()

                    MessageBox.Show("فایل درج  شاپرک ایجاد گردید")
                Else

                    If inputNumber.Trim = String.Empty Then
                        MessageBox.Show("لطفا شماره فایل درج را وارد نمایید")
                    End If
                    clsDalShaparak.RollBackProc()
                    clsDalShaparak.CloseConnection()

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("خطا در تولید فایل درج شاپرک")

            If System.IO.File.Exists(ThirdInsFileNameAndPath) Then
                System.IO.File.Delete(ThirdInsFileNameAndPath)
            End If
            clsDalShaparak.RollBackProc()
            clsDalShaparak.CloseConnection()
            res = False

        End Try
        Return res
    End Function


#Region "Shapark Delete Old & Insert New "
    Public Function FillThirdFileValue_Sheba(Optional ByVal strType As String = Nothing) As List(Of Field)
        Dim ThirdFileFields As New List(Of Field)
        Try
            Dim number As New StaticField
            Dim switchCardAcceptor As New EntityField("Switch_CardAcceptorID_vc")
            Dim shabaAccount As New ComputeField(AddressOf ConvertMethods.IBAN, "ShabaAccount")
            Dim shabaAccountOld As New ComputeField(AddressOf ConvertMethods.IBAN, "oldshabaaccount")
            Dim takhsisDate As New StaticField
            takhsisDate.Value = ConvertMethods.DateToByte2(Now.Date)

            Dim yValue As New StaticField
            Dim null As New StaticField

            number.Value = "581672061"

            If strType = "Old" Then
                yValue.Value = "N"
            Else
                yValue.Value = "Y"
            End If

            null.Value = String.Empty

            ThirdFileFields.Add(number)
            ThirdFileFields.Add(switchCardAcceptor)

            If strType = "Old" Then
                ThirdFileFields.Add(shabaAccountOld)
            Else
                ThirdFileFields.Add(shabaAccount)
            End If

            ThirdFileFields.Add(yValue)


            If strType <> "Old" Then
                ThirdFileFields.Add(takhsisDate)
            End If

            ThirdFileFields.Add(null)
        Catch ex As Exception
            MessageBox.Show("خطا در ثبت فیلدهای فایل سوم")
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
        Return ThirdFileFields
    End Function

    Private Sub btnWebPosSwitchCancel_Click(sender As Object, e As EventArgs) Handles btnWebPosSwitchCancel.Click

        colError.Clear()
        Dim clsBLLSwitch_AcceptorManagement As New ClassBLLSwitch_AcceptorManagement
        Dim clsBLLCMSSwitch_AcceptorManagement As New ClassBLLCMSSwitch_AcceptorManagement

        Dim dtNotSentWebPos_Modify_Device As New DataTable

        dtNotSentWebPos_Modify_Device = clsDalSwitchSend.ForWebPos_Modify_Device_Cancel_GetAllNotSentWebPos(ClassUserLoginDataAccess.ThisUser.ProjectID)

        If dtNotSentWebPos_Modify_Device.Rows.Count = 0 Then
            ShowErrorMessage("موردی برای فسخ یافت نشد")
            Exit Sub
        End If

        Dim serials As List(Of String) = New List(Of String)

        Dim webposes As List(Of WebPosDTO) = New List(Of WebPosDTO)

        Try

            For i As Int32 = 0 To dtNotSentWebPos_Modify_Device.Rows.Count - 1

                Dim webpos As New WebPosDTO
                webpos.code = dtNotSentWebPos_Modify_Device.Rows(i).Item("content_nvc").ToString()
                webpos.serial = dtNotSentWebPos_Modify_Device.Rows(i).Item("CONTRACTNO_VC").ToString()

                webposes.Add(webpos)

            Next i

        Catch ex As Exception
            Throw ex
        End Try

        Dim connect As Boolean = False

        Dim proc As New PL_CSharp.Procedures.frmSwitchSendTo
        Dim commonProc As New PL_CSharp.Procedures.Common

        commonProc.DeleteFile("C:\\PSPShaparak_LogError\\WebPoseService-terminal_delete_list-Err.txt")

        Dim countOfError As Integer
        countOfError = 0

        serials = webposes.Select(Of String)(Function(x) x.serial).ToList()

        Dim resultWebPosService = commonProc.CallWebServiceWithList(Of String)(Global.My.MySettings.Default.WebPosURL & "terminal_delete/", "application/json", serials, "POST")

        If resultWebPosService.Contains("Success") Then

            For Each item As WebPosDTO In webposes
                clsDalSwitchSend.ForWebPos_UpdateWebPos_SP(item.code, 1)
            Next

        Else

            commonProc.LogMessage("C:\\PSPShaparak_LogError\\WebPoseService-terminal_delete_list-Err.txt", resultWebPosService)
            countOfError = countOfError + 1

        End If

        Error_FileName = "WebPoseService-terminal_delete_list-Err.txt"

        If Not (countOfError = 0) Then
            ShowErrorMessage(Common.HardCodes.CountOfErrors & " : " & countOfError.ToString & vbCrLf & Common.HardCodes.ErrorsRegisteredInThisFile & vbCrLf + TextLogErrorFilePath + Error_FileName)
        Else
            ShowMessage(Common.HardCodes.CancelWebposServiceDoneSuccessfully)

        End If

    End Sub

    Private Sub btnWebPosSwitchChangePos_Click(sender As Object, e As EventArgs) Handles btnWebPosSwitchChangePos.Click

        Try

            colError.Clear()
            Dim clsBLLSwitch_AcceptorManagement As New ClassBLLSwitch_AcceptorManagement
            Dim clsBLLCMSSwitch_AcceptorManagement As New ClassBLLCMSSwitch_AcceptorManagement

            Dim dtNotSentWebPos_Modify_Device As New DataTable

            dtNotSentWebPos_Modify_Device = clsDalSwitchSend.ForWebPos_Modify_Device_Update_GetAllNotSentWebPos(ClassUserLoginDataAccess.ThisUser.ProjectID)

            If dtNotSentWebPos_Modify_Device.Rows.Count = 0 Then
                ShowErrorMessage("موردی برای تغییر سریال یافت نشد")
                Exit Sub
            End If

            Dim webPoses As New List(Of WebPosDTO)

            webPoses = (From w In dtNotSentWebPos_Modify_Device
                        Select New WebPosDTO With {.serial = w.Item("Contentafter_Nvc"), .code = Val(w.Item("CONTENT_NVC"))}).AsEnumerable().ToList()


            Dim connect As Boolean = False

            Dim proc As New PL_CSharp.Procedures.frmSwitchSendTo
            Dim commonProc As New PL_CSharp.Procedures.Common

            commonProc.DeleteFile("C:\\PSPShaparak_LogError\\WebPoseService-terminal_Update_serial-Err.txt")

            Dim countOfError As Integer
            countOfError = 0

            Dim webPos As New WebPosDTO

            For Each webPos In webPoses

                Dim resultWebPosService = commonProc.CallWebService(Of WebPosDTO)(Global.My.MySettings.Default.WebPosURL & "terminal_update_serial/", "application/json", webPos, "POST")

                If resultWebPosService.Contains("Success") Then

                    clsDalSwitchSend.ForWebPos_UpdateWebPos_SP(webPos.code.ToString(), 1)
                Else

                    commonProc.LogMessage("C:\\PSPShaparak_LogError\\WebPoseService-terminal_add_list-Err.txt", resultWebPosService)
                    countOfError = countOfError + 1
                End If

            Next

            If Not (countOfError = 0) Then

                ShowErrorMessage(Common.HardCodes.CountOfErrors & " : " & countOfError.ToString & vbCrLf & Common.HardCodes.ErrorsRegisteredInThisFile & vbCrLf + TextLogErrorFilePath + Error_FileName)
            Else

                ShowMessage(Common.HardCodes.SendToWebposServiceDoneSuccessfully)
            End If



        Catch ex As Exception

            Throw ex

        End Try

    End Sub


#End Region

#End Region

End Class

