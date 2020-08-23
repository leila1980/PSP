Imports Convertor
Imports PL.ViewModel.WebPosWebService
Imports PL_CSharp
Imports ViewModel.ViewModel.WebPos.PL_CSharp
Imports System.Linq
Imports PL_CSharp.Procedures

Public Class frmSwitchSendTo
    Private cSharfrmSwitchSendTo = New PL_CSharp.Procedures.frmSwitchSendTo
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalSwitch As New ClassDALSwitch(ConnectionString)

    Private dtList As New DataTable
    Dim dtGetByStoreIDCardAcceptorID As New DataTable
    Dim dtGetTheLatestSwitchTerminalID_Counter As New DataTable

    Dim dtSina As New DataTable
    Dim dtGetByStoreIDCardAcceptorIDSina As New DataTable

    Dim tabPageEntered As BL.Enum.TabPageEntered

    Private ColError As New Collection
    Private Error_FileName As String = "SendToSwitch_Err.txt"

    Private SinaColError As New Collection
    Private SinaError_FileName As String = "SendToSinaSwitch.txt"
    Private commonProc As New PL_CSharp.Procedures.frmSwitchSendTo

    '   Private tabPageEnter As index


    Private Sub frmSwitchSendTo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cSharfrmSwitchSendTo = New PL_CSharp.Procedures.frmSwitchSendTo()
            '' Dim dataGridView = cSharfrmSwitchSendTo.dgvWebPos(Me.dgvTejarat)

            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.Text = "ارسال اطلاعات به سوئیچ"
            Me.dtList.Rows.Clear()
            Me.txtNumberFrom.Text = GetMaxNumber()

            Visible_Unvisible_Buttons(Common.HardCodes.TejaratTabPage)

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvTejarat.RowsAdded
        lblCount.Text = dgvTejarat.RowCount
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvTejarat.RowsRemoved
        lblCount.Text = dgvTejarat.RowCount
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvTejarat)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try

            Select Case tabPageEntered
                Case BL.Enum.TabPageEntered.Tejarat
                    Me.View()
                Case BL.Enum.TabPageEntered.WebPos
                    Me.ViewSendToWebPosOrNetsis("W")
                Case BL.Enum.TabPageEntered.NetSis
                    Me.ViewSendToWebPosOrNetsis("N")
            End Select

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            dgvTejarat.EndEdit()
            ColError.Clear()
            Dim clsBLLSwitch As New ClassBLLSwitch_AcceptorManagement
            Dim clsCMSProjects As New ClassCMSProject(0, "", False, "")
            Dim Checkeds As Int32 = 0

            If Me.dtList.DefaultView.ToTable.Rows.Count = 0 Then
                modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If

            For i As Integer = 0 To dgvTejarat.RowCount - 1
                If dgvTejarat.Rows(i).Cells("colCheck").Value = True Then
                    If dgvTejarat.Rows(i).Cells("DSwitch_CardAcceptorID_vc").Value.ToString = String.Empty Then
                        Checkeds += 1
                    End If
                End If
            Next
            If Checkeds = 0 Then
                modPublicMethod.ShowErrorMessage("رکورد معتبری جهت ارسال انتخاب نشده است") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If
            Dim myConStr As New ClassConnectionSpliter()
            Dim PosDal As New ClassDALPos(modPublicMethod.ConnectionString)
            Dim RequestDal As New ClassDALRequest(modPublicMethod.ConnectionString)
            Dim ContractImportDal As New ClassDALContractimport(modPublicMethod.ConnectionString)
            Dim dtSerial As New DataTable
            Dim dtRequest As New DataTable
            Dim dtFanavaContractImport As New DataTable

            For i As Integer = 0 To dgvTejarat.RowCount - 1
                Try
                    clsBLLSwitch.mUrl = dgvTejarat.Rows(i).Cells("essws_nvc").Value
                    clsCMSProjects.IsSent2Switch = dgvTejarat.Rows(i).Cells("issent2switch").Value


                    'If Not myConStr.ConnectionAvailable(clsBLLSwitch.mUrl) Then
                    '    ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
                    '    Continue For
                    'End If

                    If dgvTejarat.Rows(i).Cells("colCheck").Value = True Then
                        If dgvTejarat.Rows(i).Cells("DSwitch_CardAcceptorID_vc").Value.ToString = String.Empty Then
                            PosDal.Serial_vc = dgvTejarat.Rows(i).Cells("PSerial_vc").Value.ToString
                            dtSerial.Clear()
                            dtSerial = PosDal.GetBySerialPos()

                            dtGetByStoreIDCardAcceptorID.Clear()
                            dtGetByStoreIDCardAcceptorID = clsDalContract.GetByStoreIDCardAcceptorID(dgvTejarat.Rows(i).Cells("SStoreID").Value)

                            clsCMSProjects.CMSProjectID = dgvTejarat.Rows(i).Cells("cmsprojectid").Value
                            clsCMSProjects.ISEniacMerchant = dgvTejarat.Rows(i).Cells("ISEniacMerchant").Value
                            clsCMSProjects.IsEniacOutlet = dgvTejarat.Rows(i).Cells("IsEniacOutlet").Value

                            If (clsCMSProjects.ISEniacMerchant = False Or clsCMSProjects.IsEniacOutlet = False) And clsCMSProjects.CMSProjectID <> My.Settings.Fanava_CmsProjectID Then
                                dtRequest.Clear()
                                dtRequest = RequestDal.GetByReqeustID(dgvTejarat.Rows(i).Cells("DDeviceID").Value)

                            ElseIf (clsCMSProjects.ISEniacMerchant = False Or clsCMSProjects.IsEniacOutlet = False) And clsCMSProjects.CMSProjectID = My.Settings.Fanava_CmsProjectID Then
                                dtFanavaContractImport.Clear()
                                dtFanavaContractImport = ContractImportDal.GetContractImportByDeviceID(dgvTejarat.Rows(i).Cells("DDeviceID").Value)
                            End If


                            If dtGetByStoreIDCardAcceptorID.Rows.Count > 0 Then

                                clsBLLSwitch.Switch_CardAcceptorID = dtGetByStoreIDCardAcceptorID.Rows(0).Item("Switch_CardAcceptorID_vc").ToString

                                If dtRequest.Rows.Count > 0 Then

                                    If clsCMSProjects.IsEniacOutlet = False Then
                                        clsBLLSwitch.Switch_TerminalID = dtRequest.Rows(0).Item("outlet_vc").ToString
                                    Else
                                        clsBLLSwitch.Switch_TerminalID = clsDalContract.GetTerminalIDByTheLastOne
                                    End If

                                ElseIf dtFanavaContractImport.Rows.Count > 0 And clsCMSProjects.CMSProjectID = My.Settings.Fanava_CmsProjectID Then

                                    If clsCMSProjects.IsEniacOutlet = False Then
                                        clsBLLSwitch.Switch_TerminalID = dtFanavaContractImport.Rows(0).Item("outlet_vc").ToString
                                    Else
                                        clsBLLSwitch.Switch_TerminalID = clsDalContract.GetTerminalIDByTheLastOne
                                    End If
                                Else

                                    clsBLLSwitch.Switch_TerminalID = clsDalContract.GetTerminalIDByTheLastOne

                                End If

                                ''baraye update faghat dar tejarat ke be switch sina ersal shode va bayad haman paiane ra begirad
                                ''clsBLLSwitch.Switch_CardAcceptorID = ""
                                ''clsBLLSwitch.Switch_TerminalID = ""

                                'clsBLLSwitch.SerialNo = dgv.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")

                                If dtSerial.Rows(0)("PosModelID") = 4 Then
                                    clsBLLSwitch.SerialNo = dgvTejarat.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")
                                Else
                                    clsBLLSwitch.SerialNo = dgvTejarat.Rows(i).Cells("PSerial_vc").Value.ToString
                                End If

                                clsBLLSwitch.DeviceID = dgvTejarat.Rows(i).Cells("DDeviceID").Value
                                clsBLLSwitch.StoreName = dgvTejarat.Rows(i).Cells("SName_nvc").Value.ToString

                                clsBLLSwitch.OnlyAllocateTerminal(clsBLLSwitch.mUrl)

                            Else

                                If dtRequest.Rows.Count > 0 Then

                                    If clsCMSProjects.ISEniacMerchant = False Then
                                        clsBLLSwitch.Switch_CardAcceptorID = dtRequest.Rows(0).Item("merchant_vc").ToString
                                    Else
                                        clsBLLSwitch.Switch_CardAcceptorID = clsDalContract.GetCardAcceptorIDByTheLastOne
                                    End If

                                    If clsCMSProjects.IsEniacOutlet = False Then
                                        clsBLLSwitch.Switch_TerminalID = dtRequest.Rows(0).Item("outlet_vc").ToString
                                    Else
                                        clsBLLSwitch.Switch_TerminalID = clsDalContract.GetTerminalIDByTheLastOne
                                    End If

                                ElseIf dtFanavaContractImport.Rows.Count > 0 And clsCMSProjects.CMSProjectID = My.Settings.Fanava_CmsProjectID Then

                                    If clsCMSProjects.ISEniacMerchant = False Then
                                        clsBLLSwitch.Switch_CardAcceptorID = dtFanavaContractImport.Rows(0).Item("merchant_vc").ToString
                                    Else
                                        clsBLLSwitch.Switch_CardAcceptorID = clsDalContract.GetCardAcceptorIDByTheLastOne
                                    End If

                                    If clsCMSProjects.IsEniacOutlet = False Then
                                        clsBLLSwitch.Switch_TerminalID = dtFanavaContractImport.Rows(0).Item("outlet_vc").ToString
                                    Else
                                        clsBLLSwitch.Switch_TerminalID = clsDalContract.GetTerminalIDByTheLastOne
                                    End If
                                Else
                                    clsBLLSwitch.Switch_CardAcceptorID = clsDalContract.GetCardAcceptorIDByTheLastOne
                                    clsBLLSwitch.Switch_TerminalID = clsDalContract.GetTerminalIDByTheLastOne
                                End If


                                'If dtFanavaContractImport.Rows.Count > 0 Then

                                '    If clsCMSProjects.ISEniacMerchant = False Then
                                '        clsBLLSwitch.Switch_CardAcceptorID = dtFanavaContractImport.Rows(0).Item("merchant_vc").ToString
                                '    Else
                                '        clsBLLSwitch.Switch_CardAcceptorID = clsDalContract.GetCardAcceptorIDByTheLastOne
                                '    End If

                                '    If clsCMSProjects.IsEniacOutlet = False Then
                                '        clsBLLSwitch.Switch_TerminalID = dtFanavaContractImport.Rows(0).Item("outlet_vc").ToString
                                '    Else
                                '        clsBLLSwitch.Switch_CardAcceptorID = clsDalContract.GetTerminalIDByTheLastOne
                                '    End If

                                'End If


                                'Select Case clsCMSProjects.CMSProjectID
                                '    Case 3
                                '        dtRequest.Clear()
                                '        dtRequest = RequestDal.GetByReqeustID(dgvTejarat.Rows(i).Cells("DDeviceID").Value)
                                '        clsBLLSwitch.Switch_CardAcceptorID = dtRequest.Rows(0).Item("merchant_vc").ToString
                                '        clsBLLSwitch.Switch_TerminalID = dtRequest.Rows(0).Item("outlet_vc").ToString
                                '    Case 16
                                '        dtRequest.Clear()
                                '        dtRequest = RequestDal.GetByReqeustID(dgvTejarat.Rows(i).Cells("DDeviceID").Value)
                                '        clsBLLSwitch.Switch_CardAcceptorID = dtRequest.Rows(0).Item("merchant_vc").ToString
                                '        clsBLLSwitch.Switch_TerminalID = clsDalContract.GetTerminalIDByTheLastOne
                                '    Case Else
                                '        clsBLLSwitch.Switch_CardAcceptorID = clsDalContract.GetCardAcceptorIDByTheLastOne
                                '        clsBLLSwitch.Switch_TerminalID = clsDalContract.GetTerminalIDByTheLastOne
                                'End Select


                                ''  baraye update faghat dar tejarat ke be switch sina ersal shode va bayad haman paiane ra begirad
                                ''clsBLLSwitch.Switch_CardAcceptorID = ""
                                ''clsBLLSwitch.Switch_TerminalID = ""


                                'clsBLLSwitch.SerialNo = dgv.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")
                                If dtSerial.Rows(0)("PosModelID") = 4 Then
                                    clsBLLSwitch.SerialNo = dgvTejarat.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")
                                Else
                                    clsBLLSwitch.SerialNo = dgvTejarat.Rows(i).Cells("PSerial_vc").Value.ToString
                                End If
                                clsBLLSwitch.DeviceID = dgvTejarat.Rows(i).Cells("DDeviceID").Value
                                clsBLLSwitch.Switch_FeeID_int = dgvTejarat.Rows(i).Cells("Switch_FeeID_int").Value
                                clsBLLSwitch.StoreGroupID = dgvTejarat.Rows(i).Cells("SGroupID").Value.ToString
                                clsBLLSwitch.StoreAddress = dgvTejarat.Rows(i).Cells("SAddress_nvc").Value.ToString.Trim.Replace(vbCrLf, String.Empty).Replace(vbCr, String.Empty).Replace(vbLf, String.Empty)
                                clsBLLSwitch.Mobile = dgvTejarat.Rows(i).Cells("Mobile_vc").Value.ToString
                                clsBLLSwitch.Email = dgvTejarat.Rows(i).Cells("Email_nvc").Value.ToString
                                clsBLLSwitch.PostalCode = dgvTejarat.Rows(i).Cells("SPostCode_vc").Value.ToString
                                clsBLLSwitch.StoreName = dgvTejarat.Rows(i).Cells("SName_nvc").Value.ToString
                                clsBLLSwitch.StoreTel1 = dgvTejarat.Rows(i).Cells("STel1_vc").Value.ToString
                                clsBLLSwitch.BranchID = dgvTejarat.Rows(i).Cells("ABranchID").Value.ToString
                                clsBLLSwitch.AccountNO = dgvTejarat.Rows(i).Cells("AAccountNO_vc").Value.ToString
                                clsBLLSwitch.AccountTypeName = dgvTejarat.Rows(i).Cells("AAccountTypeName_vc").Value.ToString

                                'Raeisi
                                clsBLLSwitch.EnStoreName = ConvertMethods.FaToEnFirstLineString(dgvTejarat.Rows(i).Cells("SName_nvc").Value.ToString)
                                clsBLLSwitch.SCityName = dgvTejarat.Rows(i).Cells("SCityName_nvc").Value
                                clsBLLSwitch.SStateName = dgvTejarat.Rows(i).Cells("SStateName_nvc").Value
                                clsBLLSwitch.SCityShaparakCode = dgvTejarat.Rows(i).Cells("SCityShaparakCode").Value
                                clsBLLSwitch.SStateShaparakCode = dgvTejarat.Rows(i).Cells("SStateShaparakCode").Value

                                If String.IsNullOrEmpty(dgvTejarat.Rows(i).Cells("ShabaAccount").Value.ToString.Trim) = False _
                                 And dgvTejarat.Rows(i).Cells("ShabaAccount").Value.ToString.Trim.Length = 26 Then
                                    clsBLLSwitch.ShabaAccount = dgvTejarat.Rows(i).Cells("ShabaAccount").Value
                                Else
                                    ColError.Add(("StoreName:" & dgvTejarat.Rows(i).Cells("SName_nvc").Value.ToString & Space(3) & "Serial:" & dgvTejarat.Rows(i).Cells("PSerial_vc").Value.ToString) + "شماره شبا خالی است")
                                    Continue For
                                End If

                                clsBLLSwitch.DefineCarAcceptorAllocateTerminal(clsCMSProjects.IsSent2Switch, clsBLLSwitch.mUrl)
                            End If
                        End If
                    End If
                    InitGrid(dgvTejarat)
                Catch ex As Exception
                    ColError.Add("StoreName:" & dgvTejarat.Rows(i).Cells("SName_nvc").Value.ToString & Space(3) & "Serial:" & dgvTejarat.Rows(i).Cells("PSerial_vc").Value.ToString & Space(3) & "Exception:" & ex.Message)
                    Continue For
                End Try
            Next
            If ErrHandling() = False Then
                ShowMessage(modApplicationMessage.msgSuccess)
            End If
            Me.View()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnSendToSina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Try
        '    dgvSina.EndEdit()
        '    SinaColError.Clear()
        '    Dim clsBLLSinaSwitch As New ClassBLLSwitch_SinaAcceptorManagement
        '    Dim Checked As Int32 = 0

        '    If Me.dtSina.DefaultView.ToTable.Rows.Count = 0 Then
        '        modPublicMethod.ShowErrorMessage("رکوردی برای ارسال  به سیناوجود ندارد") 'modApplicationMessage.msgLoadFailed
        '        Exit Sub
        '    End If

        '    For i As Integer = 0 To dgvSina.RowCount - 1
        '        If dgvSina.Rows(i).Cells("colCheckSina").Value = True Then
        '            If dgvSina.Rows(i).Cells("SentToSina_tint").Value.ToString <> "1" Then
        '                Checked += 1
        '            End If
        '        End If
        '    Next
        '    If Checked = 0 Then
        '        modPublicMethod.ShowErrorMessage("رکورد معتبری جهت ارسال به سینا انتخاب نشده است") 'modApplicationMessage.msgLoadFailed
        '        Exit Sub
        '    End If

        '    Dim PosDal As New ClassDALPos(modPublicMethod.ConnectionString)
        '    Dim dtSerial As New DataTable

        '    For i As Integer = 0 To dgvSina.RowCount - 1
        '        Try
        '            If dgvSina.Rows(i).Cells("colCheckSina").Value = True Then
        '                If dgvSina.Rows(i).Cells("DSwitch_CardAcceptorID_vc").Value <> String.Empty Then

        '                    PosDal.Serial_vc = dgvSina.Rows(i).Cells("PSerial_vc").Value.ToString
        '                    dtSerial.Clear()
        '                    dtSerial = PosDal.GetBySerialPos()

        '                    dtGetByStoreIDCardAcceptorIDSina.Clear()
        '                    dtGetByStoreIDCardAcceptorIDSina = clsDalContract.GetByStoreIDCardAcceptorIDSina(dgvSina.Rows(i).Cells("SStoreID").Value)

        '                    Dim ExistTerminalInSina As Boolean = False

        '                    If dtGetByStoreIDCardAcceptorIDSina.Rows.Count > 0 Then

        '                        For k As Integer = 0 To dtGetByStoreIDCardAcceptorIDSina.Rows.Count - 1
        '                            If String.Compare(dtGetByStoreIDCardAcceptorIDSina.Rows(k)("Switch_TerminalID_vc").ToString, dgvSina.Rows(i).Cells("DSwitch_TerminalID_vc").Value.ToString) = 0 Then
        '                                ExistTerminalInSina = True
        '                                Exit For
        '                            End If
        '                        Next

        '                        If ExistTerminalInSina = False Then
        '                            clsBLLSinaSwitch.Switch_CardAcceptorID = dgvSina.Rows(i).Cells("DSwitch_CardAcceptorID_vc").Value.ToString
        '                            clsBLLSinaSwitch.Switch_TerminalID = dgvSina.Rows(i).Cells("DSwitch_TerminalID_vc").Value.ToString

        '                            If dtSerial.Rows(0)("PosModelID") = 4 Then
        '                                clsBLLSinaSwitch.SerialNo = dgvSina.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")
        '                            Else
        '                                clsBLLSinaSwitch.SerialNo = dgvSina.Rows(i).Cells("PSerial_vc").Value.ToString
        '                            End If

        '                            clsBLLSinaSwitch.DeviceID = dgvSina.Rows(i).Cells("DDeviceID").Value
        '                            clsBLLSinaSwitch.StoreName = dgvSina.Rows(i).Cells("SName_nvc").Value.ToString
        '                            clsBLLSinaSwitch.OnlyAllocateTerminal()
        '                        End If
        '                    Else
        '                        clsBLLSinaSwitch.Switch_CardAcceptorID = dgvSina.Rows(i).Cells("DSwitch_CardAcceptorID_vc").Value.ToString
        '                        clsBLLSinaSwitch.Switch_TerminalID = dgvSina.Rows(i).Cells("DSwitch_TerminalID_vc").Value.ToString

        '                        If dtSerial.Rows(0)("PosModelID") = 4 Then
        '                            clsBLLSinaSwitch.SerialNo = dgvSina.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")
        '                        Else
        '                            clsBLLSinaSwitch.SerialNo = dgvSina.Rows(i).Cells("PSerial_vc").Value.ToString
        '                        End If
        '                        clsBLLSinaSwitch.DeviceID = dgvSina.Rows(i).Cells("DDeviceID").Value
        '                        clsBLLSinaSwitch.Switch_FeeID_int = dgvSina.Rows(i).Cells("Switch_FeeID_int").Value
        '                        clsBLLSinaSwitch.StoreGroupID = dgvSina.Rows(i).Cells("SGroupID").Value.ToString
        '                        clsBLLSinaSwitch.StoreAddress = dgvSina.Rows(i).Cells("SAddress_nvc").Value.ToString().Trim.ToString.Replace(vbCrLf, String.Empty).Replace(vbCr, String.Empty).Replace(vbLf, String.Empty)
        '                        clsBLLSinaSwitch.Mobile = dgvSina.Rows(i).Cells("Mobile_vc").Value.ToString
        '                        clsBLLSinaSwitch.Email = dgvSina.Rows(i).Cells("Email_nvc").Value.ToString
        '                        clsBLLSinaSwitch.StoreName = dgvSina.Rows(i).Cells("SName_nvc").Value.ToString
        '                        clsBLLSinaSwitch.StoreTel1 = dgvSina.Rows(i).Cells("STel1_vc").Value.ToString
        '                        clsBLLSinaSwitch.BranchID = dgvSina.Rows(i).Cells("ABranchID").Value.ToString
        '                        clsBLLSinaSwitch.AccountNO = dgvSina.Rows(i).Cells("AAccountNO_vc").Value.ToString
        '                        clsBLLSinaSwitch.AccountTypeName = dgvSina.Rows(i).Cells("AAccountTypeName_vc").Value.ToString
        '                        Raeisi
        '                        clsBLLSinaSwitch.EnStoreName = ConvertMethods.FaToEnFirstLineString(dgvSina.Rows(i).Cells("SName_nvc").Value.ToString)
        '                        clsBLLSinaSwitch.SCityName = dgvSina.Rows(i).Cells("SCityName_nvc").Value
        '                        clsBLLSinaSwitch.SStateName = dgvSina.Rows(i).Cells("SStateName_nvc").Value
        '                        clsBLLSinaSwitch.SCityShaparakCode = dgvSina.Rows(i).Cells("SCityShaparakCode").Value
        '                        clsBLLSinaSwitch.SStateShaparakCode = dgvSina.Rows(i).Cells("SStateShaparakCode").Value

        '                        If String.IsNullOrEmpty(dgvSina.Rows(i).Cells("ShabaAccount").Value.ToString.Trim) = False _
        '                        And dgvSina.Rows(i).Cells("ShabaAccount").Value.ToString.Trim.Length = 26 Then
        '                            clsBLLSinaSwitch.ShabaAccount = dgvSina.Rows(i).Cells("ShabaAccount").Value
        '                        Else
        '                            SinaColError.Add(("StoreName:" & dgvSina.Rows(i).Cells("SName_nvc").Value.ToString & Space(3) & "Serial:" & dgvSina.Rows(i).Cells("PSerial_vc").Value.ToString) + "شماره شبا خالی است")
        '                            Continue For
        '                        End If

        '                        clsBLLSinaSwitch.DefineCarAcceptorAllocateTerminal()

        '                    End If
        '                End If
        '            End If
        '        Catch ex As Exception
        '            SinaColError.Add("StoreName:" & dgvSina.Rows(i).Cells("SName_nvc").Value.ToString & Space(3) & "Serial:" & dgvSina.Rows(i).Cells("PSerial_vc").Value.ToString & Space(3) & "Exception:" & ex.Message)
        '            Continue For
        '        End Try
        '    Next
        '    If SinaErrHandling() = False Then
        '        ShowMessage(modApplicationMessage.msgSuccess)
        '    End If
        '    Me.ViewSendToSina()
        'Catch ex As Exception
        '    ShowErrorMessage(ex.Message)
        'End Try
    End Sub

    Private Function ErrHandling() As Boolean
        Try
            ClassError.BackupLogErrorFolder()
            ClassError.EmptyLogErrorFolder()
            If ColError.Count > 0 Then
                ClassError.LogError(Error_FileName, ColError)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & ColError.Count.ToString & vbCrLf & modApplicationMessage.msgCollectionError & vbCrLf + TextLogErrorFilePath + Error_FileName)
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function SinaErrHandling() As Boolean
        Try
            ClassError.BackupLogErrorFolder()
            ClassError.EmptyLogErrorFolder()
            If SinaColError.Count > 0 Then
                ClassError.LogError(SinaError_FileName, SinaColError)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & SinaColError.Count.ToString & vbCrLf & modApplicationMessage.msgCollectionError & vbCrLf + TextLogErrorFilePath + SinaError_FileName)
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetMaxNumber()
        Try
            Dim dt As New DataTable
            dt = clsDalSwitch.GetTheLatestSwitchHeaderNumber()
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item("Number_bint")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub View()
        Try
            Me.dtList.Rows.Clear()
            Me.dtList = clsDalSwitch.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForSwitchMakeFile(Val(Me.txtNumberFrom.Text), ClassUserLoginDataAccess.ThisUser.ProjectID, False)
            Me.dgvTejarat.DataSource = dtList
            InitGrid(Me.dgvTejarat)
            Me.ToolStripLabelCount.Text = dtList.Rows.Count.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ViewSendToWebPosOrNetsis(webPosOrNetSis As Char)

        Try
            Me.dtSina.Rows.Clear()
            Me.dtSina = clsDalSwitch.GetInformationsForSendToWebPosOrNetSis(webPosOrNetSis, Val(Me.txtNumberFrom.Text))

            If Me.dtSina.Rows.Count <> 0 Then

                If webPosOrNetSis = Common.HardCodes.WebPos Then
                    Me.dgvWebPos.DataSource = dtSina
                    InitWebPosGrid(Me.dgvWebPos)
                ElseIf webPosOrNetSis = Common.HardCodes.NetSis Then
                    Me.dgvNetsis.DataSource = dtSina
                    InitNetSisGrid(Me.dgvNetsis)
                End If

                Me.ToolStripLabelCountSina.Text = dtSina.Rows.Count.ToString

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub InitNetSisGrid(ByVal dgv As DataGridView)
        Try
            dgv.Columns("NS_AAccountNO_vc").HeaderText = "شماره حساب"
            dgv.Columns("NS_AAccountTypeID").Visible = False
            dgv.Columns("NS_ABranchID").HeaderText = "کد شعبه"
            dgv.Columns("NS_AAccountTypeName_vc").HeaderText = "نوع حساب"
            dgv.Columns("NS_CIdentityTypeName_nvc").HeaderText = "نوع مدرک شناسایی"
            dgv.Columns("NS_SName_nvc").HeaderText = "نام فروشگاه"
            dgv.Columns("NS_SCityID").Visible = False
            dgv.Columns("NS_SStateID").Visible = False
            dgv.Columns("NS_SFax_vc").HeaderText = "فکس"
            dgv.Columns("NS_STel1_vc").HeaderText = "تلفن1"
            dgv.Columns("NS_STel2_vc").HeaderText = "تلفن2"
            dgv.Columns("NS_SAddress_nvc").HeaderText = "آدرس"
            dgv.Columns("NS_SPostCode_vc").HeaderText = "کد پستی"
            dgv.Columns("NS_SGroupID").Visible = False
            dgv.Columns("NS_SCityName_nvc").HeaderText = "شهر"
            dgv.Columns("NS_Email_nvc").HeaderText = "Email"
            dgv.Columns("NS_FirstName_nvc").HeaderText = "نام"
            dgv.Columns("NS_LastName_nvc").HeaderText = "نام خانوادگی"
            dgv.Columns("NS_IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
            dgv.Columns("NS_CityID").Visible = False
            dgv.Columns("NS_StateID").Visible = False
            dgv.Columns("NS_HomeTel_vc").HeaderText = "تلفن منزل"
            dgv.Columns("NS_HomeAddress_nvc").HeaderText = "آدرس منزل"
            dgv.Columns("NS_Mobile_vc").HeaderText = "موبایل"
            dgv.Columns("NS_DMerchant_vc").HeaderText = "Merchant"
            dgv.Columns("NS_DVat_vc").HeaderText = "Vat"
            dgv.Columns("NS_DOutlet_vc").HeaderText = "Outlet"
            dgv.Columns("NS_DCode_vc").HeaderText = "Code"
            dgv.Columns("NS_DSwitch_CardAcceptorID_vc").HeaderText = "Switch_CardAcceptorID"
            dgv.Columns("NS_DSwitch_TerminalID_vc").HeaderText = "Switch_TerminalID"
            dgv.Columns("NS_PSerial_vc").HeaderText = "سریال"
            dgv.Columns("NS_PPropertyNO_vc").HeaderText = "اموال"
            dgv.Columns("NS_ContractID").HeaderText = "کد قرارداد"
            dgv.Columns("NS_Switch_FeeID_int").HeaderText = "کارمزد"

            'dgv.Columns("NS_cmsprojectid").Visible = False ' comment with leila maghsoodi
            'dgv.Columns("NS_essws_nvc").Visible = False ' comment with leila maghsoodi
            'dgv.Columns("NS_issent2switch").Visible = False ' comment with leila maghsoodi
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub InitGrid(ByVal dgv As DataGridView)
        Try
            dgv.Columns("AAccountNO_vc").HeaderText = "شماره حساب"
            dgv.Columns("AAccountTypeID").Visible = False
            dgv.Columns("ABranchID").HeaderText = "کد شعبه"
            dgv.Columns("AAccountTypeName_vc").HeaderText = "نوع حساب"
            dgv.Columns("CIdentityTypeName_nvc").HeaderText = "نوع مدرک شناسایی"
            dgv.Columns("SName_nvc").HeaderText = "نام فروشگاه"
            dgv.Columns("SCityID").Visible = False
            dgv.Columns("SStateID").Visible = False
            dgv.Columns("SFax_vc").HeaderText = "فکس"
            dgv.Columns("STel1_vc").HeaderText = "تلفن1"
            dgv.Columns("STel2_vc").HeaderText = "تلفن2"
            dgv.Columns("SAddress_nvc").HeaderText = "آدرس"
            dgv.Columns("SPostCode_vc").HeaderText = "کد پستی"
            dgv.Columns("SGroupID").Visible = False
            dgv.Columns("SCityName_nvc").HeaderText = "شهر"
            dgv.Columns("Email_nvc").HeaderText = "Email"
            dgv.Columns("FirstName_nvc").HeaderText = "نام"
            dgv.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
            dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
            dgv.Columns("CityID").Visible = False
            dgv.Columns("StateID").Visible = False
            dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
            dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
            dgv.Columns("Mobile_vc").HeaderText = "موبایل"
            dgv.Columns("DMerchant_vc").HeaderText = "Merchant"
            dgv.Columns("DVat_vc").HeaderText = "Vat"
            dgv.Columns("DOutlet_vc").HeaderText = "Outlet"
            dgv.Columns("DCode_vc").HeaderText = "Code"
            dgv.Columns("DSwitch_CardAcceptorID_vc").HeaderText = "Switch_CardAcceptorID"
            dgv.Columns("DSwitch_TerminalID_vc").HeaderText = "Switch_TerminalID"
            dgv.Columns("PSerial_vc").HeaderText = "سریال"
            dgv.Columns("PPropertyNO_vc").HeaderText = "اموال"
            dgv.Columns("ContractID").HeaderText = "کد قرارداد"
            dgv.Columns("Switch_FeeID_int").HeaderText = "کارمزد"

            dgv.Columns("cmsprojectid").Visible = False ' comment with leila maghsoodi
            dgv.Columns("essws_nvc").Visible = False ' comment with leila maghsoodi
            dgv.Columns("issent2switch").Visible = False ' comment with leila maghsoodi
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub InitWebPosGrid(ByVal dgv As DataGridView)
        Try
            dgv.Columns("WP_AAccountNO_vc").HeaderText = "شماره حساب"
            dgv.Columns("WP_AAccountTypeID").Visible = False
            dgv.Columns("WP_ABranchID").HeaderText = "کد شعبه"
            dgv.Columns("WP_AAccountTypeName_vc").HeaderText = "نوع حساب"
            dgv.Columns("WP_CIdentityTypeName_nvc").HeaderText = "نوع مدرک شناسایی"
            dgv.Columns("WP_SName_nvc").HeaderText = "نام فروشگاه"
            dgv.Columns("WP_SCityID").Visible = False
            dgv.Columns("WP_SStateID").Visible = False
            dgv.Columns("WP_SFax_vc").HeaderText = "فکس"
            dgv.Columns("WP_STel1_vc").HeaderText = "تلفن1"
            dgv.Columns("WP_STel2_vc").HeaderText = "تلفن2"
            dgv.Columns("WP_SAddress_nvc").HeaderText = "آدرس"
            dgv.Columns("WP_SPostCode_vc").HeaderText = "کد پستی"
            dgv.Columns("WP_SGroupID").Visible = False
            dgv.Columns("WP_SCityName_nvc").HeaderText = "شهر"
            dgv.Columns("WP_Email_nvc").HeaderText = "Email"
            dgv.Columns("WP_FirstName_nvc").HeaderText = "نام"
            dgv.Columns("WP_LastName_nvc").HeaderText = "نام خانوادگی"
            dgv.Columns("WP_IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
            dgv.Columns("WP_CityID").Visible = False
            dgv.Columns("WP_StateID").Visible = False
            dgv.Columns("WP_HomeTel_vc").HeaderText = "تلفن منزل"
            dgv.Columns("WP_HomeAddress_nvc").HeaderText = "آدرس منزل"
            dgv.Columns("WP_Mobile_vc").HeaderText = "موبایل"
            dgv.Columns("WP_DMerchant_vc").HeaderText = "Merchant"
            dgv.Columns("WP_DVat_vc").HeaderText = "Vat"
            dgv.Columns("WP_DOutlet_vc").HeaderText = "Outlet"
            dgv.Columns("WP_DCode_vc").HeaderText = "Code"
            dgv.Columns("WP_DSwitch_CardAcceptorID_vc").HeaderText = "Switch_CardAcceptorID"
            dgv.Columns("WP_DSwitch_TerminalID_vc").HeaderText = "Switch_TerminalID"
            dgv.Columns("WP_PSerial_vc").HeaderText = "سریال"
            dgv.Columns("WP_PPropertyNO_vc").HeaderText = "اموال"
            dgv.Columns("WP_ContractID").HeaderText = "کد قرارداد"
            dgv.Columns("WP_Switch_FeeID_int").HeaderText = "کارمزد"
            ''  dgv.Columns("cmsprojectid").Visible = False ' comment with leila maghsoodi
            '' dgv.Columns("essws_nvc").Visible = False ' comment with leila maghsoodi
            '' dgv.Columns("issent2switch").Visible = False ' comment with leila maghsoodi
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SinaTabPage_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub btnSelectAllSina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAllWebPos.Click

        commonProc.SelectAllRecords(dgvWebPos)
    End Sub

    Private Sub btnSelectNoneSina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNoneWebPos.Click

        commonProc.ClearAllRecords(dgvWebPos)
    End Sub

    Private Sub Visible_Unvisible_Buttons(tabPage As String)
        Select Case tabPage
            Case Common.HardCodes.TejaratTabPage
                Me.btnSend.Visible = True
                Me.btnSendToWebPos.Visible = False
                Me.btnSendToNetsis.Visible = False
                Me.btnView.Visible = True
                Me.TejaratToolStripSeparator.Visible = True
                Me.WebPosToolStripSeparator.Visible = False
                Me.NetsisToolStripSeparator.Visible = False
                Me.TejToolStrip.Visible = True
                Me.NetsisToolStrip.Visible = False
                Me.NetsisTabPage.Visible = False
                Me.btnSelectAll.Visible = True
                Me.btnSelectNone.Visible = True
            Case Common.HardCodes.WebPosTabPage
                Me.btnSend.Visible = False
                Me.btnSendToWebPos.Visible = True
                Me.btnSendToNetsis.Visible = False
                Me.btnView.Visible = True
                Me.TejaratToolStripSeparator.Visible = False
                Me.WebPosToolStripSeparator.Visible = True
                Me.NetsisToolStripSeparator.Visible = False
                Me.TejToolStrip.Visible = False
                Me.webPosToolStrip.Visible = True
                Me.NetsisTabPage.Visible = False
            Case Common.HardCodes.NetsisTabPage
                Me.btnSend.Visible = False
                Me.btnSendToWebPos.Visible = False
                Me.btnSendToNetsis.Visible = True
                Me.btnView.Visible = True
                Me.NetsisToolStripSeparator.Visible = True
                Me.WebPosToolStripSeparator.Visible = False
                Me.TejaratToolStripSeparator.Visible = False
                Me.TejToolStrip.Visible = False
                Me.webPosToolStrip.Visible = False
                Me.NetsisToolStrip.Visible = True
        End Select

    End Sub


    Private Sub TejaratTabPage_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TejaratTabPage.Enter
        'If True Then

        'End If
        tabPageEntered = BL.Enum.TabPageEntered.Tejarat
        Visible_Unvisible_Buttons(Common.HardCodes.TejaratTabPage)
    End Sub

    Private Sub btnNetsisExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNetsisExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            Dim dt As New DataTable
            dt = clsDalSwitch.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForNetsisExcelMakeFile(Val(Me.txtNumberFrom.Text), ClassUserLoginDataAccess.ThisUser.ProjectID, False)
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                dt.Columns.Add("Charge")
                dt.Columns.Add("MerchantCode")
                clsExcel.Write(dt)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnSendToNetsis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendToNetsis.Click

    End Sub

    Private Sub btnSendToWebPos_Click(sender As Object, e As EventArgs) Handles btnSendToWebPos.Click

        dgvWebPos.EndEdit()

        Dim webPoses As New List(Of WebPosDTO)
        Dim i As Integer

        Try

            Dim selectedWebPoses As New List(Of WebPosDTO)

            Dim RongFormatCodes As New List(Of String)

            For i = 0 To dgvWebPos.Rows.Count - 1
                If dgvWebPos.Rows(i).Cells("colCheckWebPos").Value = True Then

                    Dim selectedWebPos As New WebPosDTO
                    selectedWebPos.serial = DirectCast(dgvWebPos.Rows(i).Cells.Item("WP_PSerial_vc").Value, String)

                    Dim S_Code As String

                    If IsDBNull(dgvWebPos.Rows(i).Cells.Item("WP_DOutlet_vc").Value) Then
                        S_Code = "0"
                    Else
                        S_Code = DirectCast(dgvWebPos.Rows(i).Cells.Item("WP_DOutlet_vc").Value, String)
                    End If

                    If Long.TryParse(S_Code, selectedWebPos.code) Then
                        selectedWebPoses.Add(selectedWebPos)
                    Else
                        RongFormatCodes.Add(S_Code)
                    End If

                End If
            Next

            If RongFormatCodes.Count <> 0 Then
                ShowErrorMessage(Common.HardCodes.ThisCodesHasNotValidFormat & vbCrLf & RongFormatCodes.ListToString())
                Exit Sub
            End If

            Dim commonProc As New PL_CSharp.Procedures.Common

            Dim item As New WebPosDTO

            Dim proc As New PL_CSharp.Procedures.frmSwitchSendTo

            commonProc.DeleteFile("C:\\PSPShaparak_LogError\\WebPoseService-terminal_add_list-Err.txt")

            Dim countOfError As Integer
            countOfError = 0
            Dim webPos As WebPosDTO = New WebPosDTO()

            If selectedWebPoses.Count = 0 Then
                ShowMessage(Common.HardCodes.NotRecordSelected)
                Exit Sub
            End If

            For Each item In selectedWebPoses

                Dim resultWebPosService = commonProc.CallWebServiceWithList(Of WebPosDTO)(Global.My.MySettings.Default.WebPosURL & "terminal_add_list/", "application/json", item, "POST")

                If resultWebPosService.Contains("Success") Then

                    clsDalSwitch.SetSenttowebpos_TintToSent(item.code.ToString)

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


            Me.ViewSendToWebPosOrNetsis(Common.HardCodes.WebPos)

        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Private Sub ViewTabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ViewTabControl.SelectedIndexChanged
        If ViewTabControl.SelectedTab.Text = Common.HardCodes.InformationsForSendToWebPos Then

            ' MessageBox.Show("fsdkljfsdkl")

        End If
    End Sub

    Private Sub NetsisTabPage_Enter(sender As Object, e As EventArgs) Handles NetsisTabPage.Enter
        Try

            tabPageEntered = BL.Enum.TabPageEntered.NetSis
            Visible_Unvisible_Buttons(Common.HardCodes.NetsisTabPage)

        Catch ex As Exception

            ShowErrorMessage(ex.Message)

        End Try
    End Sub

    Private Sub WebPosTabPage_Enter(sender As Object, e As EventArgs) Handles WebPosTabPage.Enter
        Try
            tabPageEntered = BL.Enum.TabPageEntered.WebPos
            Visible_Unvisible_Buttons(Common.HardCodes.WebPosTabPage)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub dgvWebPos_CellClick(sender As Object, e As DataGridViewCellEventArgs)

        If e.ColumnIndex = 0 Then
            If dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = True Then

                dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = False
            ElseIf (dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = False) Or (dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = Nothing) Then

                dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = True
            End If
        End If
        'dgvWebPos.Rows(e.RowIndex).Selected = True
        'MessageBox.Show(dgvWebPos.SelectedRows.Count.ToString())
    End Sub

    Private Sub dgvWebPos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWebPos.RowEnter
        ''e.ro
        'If dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = True Then

        '    dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = False
        'ElseIf (dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = False) Or (dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = Nothing) Then

        '    dgvWebPos.Rows(e.RowIndex).Cells("colCheckWebPos").Value = True
        'End If


    End Sub



    Private Sub BtnClearAllSelected_Click(sender As Object, e As EventArgs)
        commonProc.ClearAllRecords(dgvWebPos)
    End Sub

    Private Sub btnSelectAllRecords_Click(sender As Object, e As EventArgs)
        commonProc.SelectAllRecords(dgvWebPos)
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        commonProc.SelectAllRecords(dgvTejarat)
    End Sub

    Private Sub btnSelectNone_Click(sender As Object, e As EventArgs) Handles btnSelectNone.Click
        commonProc.ClearAllRecords(dgvTejarat)
    End Sub

    Private Sub SelectAllNetSis_Click(sender As Object, e As EventArgs) Handles SelectAllNetSis.Click
        commonProc.SelectAllRecords(dgvNetsis)
    End Sub

    Private Sub SelectNonNetSis_Click(sender As Object, e As EventArgs) Handles SelectNonNetSis.Click
        commonProc.ClearAllRecords(dgvNetsis)
    End Sub
End Class