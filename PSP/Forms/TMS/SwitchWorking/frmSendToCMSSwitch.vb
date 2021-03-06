Public Class frmSendToCMSSwitch
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalSwitch As New ClassDALSwitch(ConnectionString)

    Private dtList As New DataTable
    Dim dtGetByStoreIDCMSMerchant As New DataTable
    Dim dtGetTheLatestSwitchTerminalID_Counter As New DataTable
    Dim myConStr As New ClassConnectionSpliter()
    Private ColError As New Collection
    Private Error_FileName As String = "SendToCMSSwitch_Err.txt"

    Private Sub frmSwitchSendTo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

            Me.Text = "ارسال اطلاعات به سوئیچ CMS"
            Me.dtList.Rows.Clear()
            Me.txtNumberFrom.Text = GetMaxNumber()

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        lblCount.Text = dgv.RowCount
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        lblCount.Text = dgv.RowCount
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        dgv.EndEdit()
        For i As Int32 = 0 To dgv.RowCount - 1
            dgv.Rows(i).Cells("colCheck").Value = True
        Next
        dgv.EndEdit()
    End Sub

    Private Sub btnSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNone.Click
        dgv.EndEdit()
        For i As Int32 = 0 To dgv.RowCount - 1
            dgv.Rows(i).Cells("colCheck").Value = False
        Next
        dgv.EndEdit()

    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgv)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            Me.View()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            dgv.EndEdit()
            ColError.Clear()
            Dim clsBLLCMSSwitch As New ClassBLLCMSSwitch_AcceptorManagement
            Dim Checked As Int32 = 0

            If Me.dtList.DefaultView.ToTable.Rows.Count = 0 Then
                modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If

            For i As Integer = 0 To dgv.RowCount - 1
                If dgv.Rows(i).Cells("colCheck").Value = True Then
                    If dgv.Rows(i).Cells("CMSMerchant_vc").Value = String.Empty Then
                        Checked += 1
                    End If
                End If
            Next
            If Checked = 0 Then
                modPublicMethod.ShowErrorMessage("رکورد معتبری جهت ارسال انتخاب نشده است") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If

            Dim PosDal As New ClassDALPos(modPublicMethod.ConnectionString)
            Dim dtSerial As New DataTable

            For i As Integer = 0 To dgv.RowCount - 1
                Try

                    clsBLLCMSSwitch.mUrl = dgv.Rows(i).Cells("essws_nvc").Value
                    'If Not myConStr.ConnectionAvailable(clsBLLCMSSwitch.mUrl) Then
                    '    ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
                    '    Continue For
                    'End If

                    If dgv.Rows(i).Cells("colCheck").Value = True Then
                        If dgv.Rows(i).Cells("CMSMerchant_vc").Value = String.Empty Then
                            PosDal.Serial_vc = dgv.Rows(i).Cells("PSerial_vc").Value.ToString
                            dtSerial.Clear()
                            dtSerial = PosDal.GetBySerialPos()

                            dtGetByStoreIDCMSMerchant.Clear()
                            dtGetByStoreIDCMSMerchant = clsDalContract.GetByStoreIDCMSMerchant(dgv.Rows(i).Cells("SStoreID").Value)
                            If dtGetByStoreIDCMSMerchant.Rows.Count > 0 Then
                                clsBLLCMSSwitch.Switch_CardAcceptorID = dtGetByStoreIDCMSMerchant.Rows(0).Item("CMSMerchant_vc").ToString
                                clsBLLCMSSwitch.Switch_TerminalID = clsDalContract.GetCMSTerminalIDByTheLastOne
                                'clsBLLCMSSwitch.SerialNo = dgv.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")
                                If dtSerial.Rows(0)("PosModelID") = 4 Then
                                    clsBLLCMSSwitch.SerialNo = dgv.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")
                                Else
                                    clsBLLCMSSwitch.SerialNo = dgv.Rows(i).Cells("PSerial_vc").Value.ToString
                                End If
                                clsBLLCMSSwitch.DeviceID = dgv.Rows(i).Cells("DDeviceID").Value
                                clsBLLCMSSwitch.StoreName = dgv.Rows(i).Cells("SName_nvc").Value.ToString
                                clsBLLCMSSwitch.OnlyAllocateTerminal(clsBLLCMSSwitch.mUrl)
                            Else
                                clsBLLCMSSwitch.Switch_CardAcceptorID = clsDalContract.GetCMSCardAcceptorIDByTheLastOne
                                clsBLLCMSSwitch.Switch_TerminalID = clsDalContract.GetCMSTerminalIDByTheLastOne
                                'clsBLLCMSSwitch.SerialNo = dgv.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")
                                If dtSerial.Rows(0)("PosModelID") = 4 Then
                                    clsBLLCMSSwitch.SerialNo = dgv.Rows(i).Cells("PSerial_vc").Value.ToString.Replace(" ", "").Replace("-", "")
                                Else
                                    clsBLLCMSSwitch.SerialNo = dgv.Rows(i).Cells("PSerial_vc").Value.ToString
                                End If
                                clsBLLCMSSwitch.DeviceID = dgv.Rows(i).Cells("DDeviceID").Value
                                clsBLLCMSSwitch.Switch_FeeID_int = dgv.Rows(i).Cells("Switch_FeeID_int").Value
                                clsBLLCMSSwitch.StoreGroupID = dgv.Rows(i).Cells("SGroupID").Value.ToString
                                clsBLLCMSSwitch.StoreAddress = dgv.Rows(i).Cells("SAddress_nvc").Value.ToString()
                                clsBLLCMSSwitch.Mobile = dgv.Rows(i).Cells("Mobile_vc").Value.ToString
                                clsBLLCMSSwitch.Email = dgv.Rows(i).Cells("Email_nvc").Value.ToString
                                clsBLLCMSSwitch.StoreName = dgv.Rows(i).Cells("SName_nvc").Value.ToString
                                clsBLLCMSSwitch.StoreTel1 = dgv.Rows(i).Cells("STel1_vc").Value.ToString
                                clsBLLCMSSwitch.BranchID = dgv.Rows(i).Cells("ABranchID").Value.ToString
                                clsBLLCMSSwitch.AccountNO = dgv.Rows(i).Cells("AAccountNO_vc").Value.ToString
                                clsBLLCMSSwitch.AccountTypeName = dgv.Rows(i).Cells("AAccountTypeName_vc").Value.ToString
                                clsBLLCMSSwitch.DefineCarAcceptorAllocateTerminal(clsBLLCMSSwitch.mUrl)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    ColError.Add("StoreName:" & dgv.Rows(i).Cells("SName_nvc").Value.ToString & Space(3) & "Serial:" & dgv.Rows(i).Cells("PSerial_vc").Value.ToString & Space(3) & "Exception:" & ex.Message)
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
            Me.dtList = clsDalSwitch.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForSwitchMakeFile(Val(Me.txtNumberFrom.Text), ClassUserLoginDataAccess.ThisUser.ProjectID, True)
            Me.dgv.DataSource = dtList
            InitGrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitGrid()
        Try
            Me.dgv.Columns("AAccountNO_vc").HeaderText = "شماره حساب"
            Me.dgv.Columns("AAccountTypeID").Visible = False
            Me.dgv.Columns("ABranchID").HeaderText = "کد شعبه"
            Me.dgv.Columns("AAccountTypeName_vc").HeaderText = "نوع حساب"
            Me.dgv.Columns("CIdentityTypeName_nvc").HeaderText = "نوع مدرک شناسایی"
            Me.dgv.Columns("SName_nvc").HeaderText = "نام فروشگاه"
            Me.dgv.Columns("SCityID").Visible = False
            Me.dgv.Columns("SStateID").Visible = False
            Me.dgv.Columns("SFax_vc").HeaderText = "فکس"
            Me.dgv.Columns("STel1_vc").HeaderText = "تلفن1"
            Me.dgv.Columns("STel2_vc").HeaderText = "تلفن2"
            Me.dgv.Columns("SAddress_nvc").HeaderText = "آدرس"
            Me.dgv.Columns("SPostCode_vc").HeaderText = "کد پستی"
            Me.dgv.Columns("SGroupID").Visible = False
            Me.dgv.Columns("SCityName_nvc").HeaderText = "شهر"
            Me.dgv.Columns("Email_nvc").HeaderText = "Email"
            Me.dgv.Columns("FirstName_nvc").HeaderText = "نام"
            Me.dgv.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
            Me.dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
            Me.dgv.Columns("CityID").Visible = False
            Me.dgv.Columns("StateID").Visible = False
            Me.dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
            Me.dgv.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
            Me.dgv.Columns("Mobile_vc").HeaderText = "موبایل"
            Me.dgv.Columns("DMerchant_vc").HeaderText = "Merchant"
            Me.dgv.Columns("DVat_vc").HeaderText = "Vat"
            Me.dgv.Columns("DOutlet_vc").HeaderText = "Outlet"
            Me.dgv.Columns("DCode_vc").HeaderText = "Code"
            Me.dgv.Columns("DSwitch_CardAcceptorID_vc").HeaderText = "Switch_CardAcceptorID"
            Me.dgv.Columns("DSwitch_TerminalID_vc").HeaderText = "Switch_TerminalID"

            Me.dgv.Columns("PSerial_vc").HeaderText = "سریال"
            Me.dgv.Columns("PPropertyNO_vc").HeaderText = "اموال"
            Me.dgv.Columns("ContractID").HeaderText = "کد قرارداد"
            Me.dgv.Columns("Switch_FeeID_int").HeaderText = "کارمزد"

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class