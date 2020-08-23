Imports AcceptorManagementService

Public Class frmSwitchPaymentMethodType
    Dim myConStr As New ClassConnectionSpliter()
    Private clsDalBasicType As New ClassDALBasicTypes(modPublicMethod.ConnectionString)
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Dim clsCMSProject As New ClassCMSProject(0, "", False, "")

    Private colDoneSuccessfully As New Collection
    Private colErr As New Collection
    Private colException As New Collection

    Private ErrDoneSuccessfully_FileName As String = "SwitchPaymentMethod_DoneSuccessfully_Err.txt"
    Private ErrErr_FileName As String = "SwitchPaymentMethod_Err.txt"
    Private ErrException_FileName As String = "SwitchPaymentMethod_Exception.txt"

    Private dtGrid As New DataTable
    Private dvGrid As New DataView

    Private dtImportExcel As New DataTable

    Private Sub frmSwitchFeeSchema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.FillGrid()
            Me.InitGrid()
            Me.FillCombo()
            ReportSearchToolStrip1.Init(dgvCardAcceptor, dtGrid, Me.Text)

            Me.cboImportType.SelectedIndex = 0
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            clsDalContract.BeginProc()
            dtGrid = clsDalContract.GetAllCardAcceptorInfo_ForPaymentMethodType()
            dvGrid = dtGrid.DefaultView
            dgvCardAcceptor.DataSource = dvGrid
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            dgvCardAcceptor.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
            dgvCardAcceptor.Columns("SName_nvc").HeaderText = "نام فروشگاه"
            dgvCardAcceptor.Columns("Switch_CardAcceptorID_vc").HeaderText = "پذیرنده"
            dgvCardAcceptor.Columns("Switch_TerminalID_vc").HeaderText = "پایانه"

            dgvCardAcceptor.Columns("Switch_PaymentMethodType").Visible = False
            dgvCardAcceptor.Columns("Switch_PaymentMethodTypeName").HeaderText = "نوع پرداخت"
            dgvCardAcceptor.Columns("LastName_nvc").Width = 300
            dgvCardAcceptor.Columns("SName_nvc").Width = 300
            dgvCardAcceptor.Columns("Switch_CardAcceptorID_vc").Width = 200
            dgvCardAcceptor.Columns("Switch_TerminalID_vc").Width = 200

            dgvCardAcceptor.Columns("Switch_PaymentMethodTypeName").Width = 200
            dgvCardAcceptor.Columns("SAddress_nvc").Visible = False

        Catch ex As Exception

            Throw ex
        End Try
    End Sub
    Private Sub FillCombo()
        Try
            clsDalBasicType.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.Switch_PaymentMethodType
            cboPaymentMethodType.DataSource = clsDalBasicType.GetAll()
            cboPaymentMethodType.ValueMember = "ID"
            cboPaymentMethodType.DisplayMember = "Name_nvc"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
    '    Try
    '        If txtFilter.Text.Trim.Length = 0 Then
    '            dvGrid.RowFilter = ""
    '        Else
    '            dvGrid.RowFilter = "Switch_CardAcceptorID_vc='" & txtFilter.Text & "'"
    '        End If
    '    Catch ex As Exception
    '        ShowErrorMessage(ex.Message)
    '    End Try
    'End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        dgvCardAcceptor.EndEdit()
        For i As Int32 = 0 To dgvCardAcceptor.RowCount - 1
            dgvCardAcceptor.Rows(i).Cells("colChk").Value = True
        Next
        dgvCardAcceptor.EndEdit()
    End Sub
    Private Sub btnSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNone.Click
        dgvCardAcceptor.EndEdit()
        For i As Int32 = 0 To dgvCardAcceptor.RowCount - 1
            dgvCardAcceptor.Rows(i).Cells("colChk").Value = False
        Next
        dgvCardAcceptor.EndEdit()

    End Sub

    Private Sub dgvCardAcceptor_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvCardAcceptor.RowsAdded
        lblCount.Text = dgvCardAcceptor.RowCount
    End Sub

    Private Sub dgvCardAcceptor_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvCardAcceptor.RowsRemoved
        lblCount.Text = dgvCardAcceptor.RowCount
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvCardAcceptor)
            End If

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        Try
            Me.Assign()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub
    Overloads Sub Assign()
        Try
            Dim checked As Int32 = 0
            dgvCardAcceptor.EndEdit()
            colDoneSuccessfully.Clear()
            colErr.Clear()
            colException.Clear()
            For i As Int32 = 0 To dgvCardAcceptor.RowCount - 1
                If dgvCardAcceptor.Rows(i).Cells("colChk").Value = True Then
                    checked += 1

                    If clsCMSProject.IsSent2Switch Then
                        'If myConStr.ConnectionAvailable(clsCMSProject.ESSWS_NVC) Then
                        Assign(dgvCardAcceptor.Rows(i).Cells("Switch_CardAcceptorID_vc").Value, cboPaymentMethodType.SelectedValue, dgvCardAcceptor.Rows(i).Cells("SAddress_nvc").Value, clsCMSProject.ESSWS_NVC)
                        'Else
                        '    ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
                        'End If
                    End If

                End If
            Next
            If checked = 0 Then
                ShowErrorMessage("موردی از لیست انتخاب نشده است")
                Exit Sub
            End If
            If ErrHandling() = False Then
                ShowMessage(modApplicationMessage.msgSuccess)
            End If
            Me.FillGrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Overloads Sub Assign(ByVal CardAccptor As String, ByVal Switch_PaymentMethodType As Int32, ByVal Address As String, ByVal murl As String)
        Try
            clsDalContract.BeginProc()
            clsDalContract.UpdateDevice_OnlySwitch_PaymentMethodType(CardAccptor, Switch_PaymentMethodType)


            Dim _AcMgService As New AcceptorManagementServiceService()
            Dim _rq_Get As New acceptorManagementRq
            Dim _cardAcceptor_Get As New cardAcceptorDTO
            _rq_Get.cardAcceptor = _cardAcceptor_Get
            _rq_Get.cardAcceptor.id = CardAccptor
            Dim _getCardAcceptorDetailByID_rs As New getCardAcceptorDetailByIDResponse
            Dim _getCardAcceptorDetailByID As New getCardAcceptorDetailByID
            Dim _acceptorManagementRs As New acceptorManagementRs
            _getCardAcceptorDetailByID.AcceptorManagementRq = _rq_Get
            _acceptorManagementRs = _AcMgService.getCardAcceptorDetailByID(_getCardAcceptorDetailByID).return



            Dim _rq As New acceptorManagementRq
            Dim _cardAcceptor As New cardAcceptorDTO
            Dim _institution As New institutionDTO
            Dim _externalAccount As New externalAccountDTO
            Dim _modifyCardAcceptor_rs As New modifyCardAcceptorResponse
            Dim _modifyCardAcceptor As New modifyCardAcceptor
            Dim _modifyCardAcceptor_responseCode As AcceptorManagementService.responseCode
            _rq.cardAcceptor = _cardAcceptor
            _rq.cardAcceptor.inst = _institution
            _rq.cardAcceptor.setlAcnt = _externalAccount

            _rq.cardAcceptor.id = CardAccptor
            Select Case Switch_PaymentMethodType
                Case 126
                    _rq.cardAcceptor.paymentMethod = paymentMethodType.Offline_File_Txn
                Case 127
                    _rq.cardAcceptor.paymentMethod = paymentMethodType.Offline_File_Batch
                Case 128
                    _rq.cardAcceptor.paymentMethod = paymentMethodType.Online_Transfer_Txn
                Case 129
                    _rq.cardAcceptor.paymentMethod = paymentMethodType.Online_Transfer_Batch
            End Select
            _rq.cardAcceptor.paymentMethodSpecified = True

            _rq.cardAcceptor.businessCode = _acceptorManagementRs.cardAcceptor.businessCode
            If Address.Length >= 63 Then
                _rq.cardAcceptor.inst.institutionAddress = Address.Substring(0, 63)
            Else
                _rq.cardAcceptor.inst.institutionAddress = Address '_acceptorManagementRs.cardAcceptor.inst.institutionAddress
            End If
            _rq.cardAcceptor.inst.institutionCellphoneNumber = _acceptorManagementRs.cardAcceptor.inst.institutionCellphoneNumber
            _rq.cardAcceptor.inst.institutionEmailAddress = _acceptorManagementRs.cardAcceptor.inst.institutionEmailAddress
            _rq.cardAcceptor.inst.institutionIIN = _acceptorManagementRs.cardAcceptor.inst.institutionIIN
            _rq.cardAcceptor.inst.institutionLatinAddress = _acceptorManagementRs.cardAcceptor.inst.institutionLatinAddress
            _rq.cardAcceptor.inst.institutionLatinName = _acceptorManagementRs.cardAcceptor.inst.institutionLatinName
            _rq.cardAcceptor.inst.institutionName = _acceptorManagementRs.cardAcceptor.inst.institutionName
            _rq.cardAcceptor.inst.institutionPhone = _acceptorManagementRs.cardAcceptor.inst.institutionPhone

            _rq.cardAcceptor.inst.institutionType = _acceptorManagementRs.cardAcceptor.inst.institutionType
            _rq.cardAcceptor.inst.institutionTypeSpecified = _acceptorManagementRs.cardAcceptor.inst.institutionTypeSpecified
            _rq.cardAcceptor.inst.institutionWebAddress = _acceptorManagementRs.cardAcceptor.inst.institutionWebAddress
            _rq.cardAcceptor.reconciliationCycleLenght = _acceptorManagementRs.cardAcceptor.reconciliationCycleLenght
            _rq.cardAcceptor.setlAcnt.externalAccountBankBranchID = _acceptorManagementRs.cardAcceptor.setlAcnt.externalAccountBankBranchID
            _rq.cardAcceptor.setlAcnt.externalAccountBankID = _acceptorManagementRs.cardAcceptor.setlAcnt.externalAccountBankID
            _rq.cardAcceptor.setlAcnt.externalAccountNumber = _acceptorManagementRs.cardAcceptor.setlAcnt.externalAccountNumber
            _rq.cardAcceptor.setlAcnt.externalAccountTitle = _acceptorManagementRs.cardAcceptor.setlAcnt.externalAccountTitle
            _rq.cardAcceptor.settlementMethodSpecified = _acceptorManagementRs.cardAcceptor.settlementMethodSpecified
            _rq.cardAcceptor.settlementMethod = _acceptorManagementRs.cardAcceptor.settlementMethod
            _rq.cardAcceptor.status = _acceptorManagementRs.cardAcceptor.status
            _rq.cardAcceptor.statusSpecified = _acceptorManagementRs.cardAcceptor.statusSpecified

            _rq.cardAcceptor.setlAcnt.externallAccountTypeSpecified = _acceptorManagementRs.cardAcceptor.setlAcnt.externallAccountTypeSpecified
            _rq.cardAcceptor.settlementTime = _acceptorManagementRs.cardAcceptor.settlementTime

            _modifyCardAcceptor.AcceptorManagementRq = _rq
            _modifyCardAcceptor_rs = _AcMgService.modifyCardAcceptor(_modifyCardAcceptor)
            _modifyCardAcceptor_responseCode = _modifyCardAcceptor_rs.return.responseCode
            '---
            Select Case _modifyCardAcceptor_responseCode
                Case responseCode.DoneSuccessfully
                    clsDalContract.EndProc()
                Case Else
                    clsDalContract.RollBackProc()
                    colErr.Add(CardAccptor & Space(1) & _modifyCardAcceptor_responseCode.ToString)
            End Select
        Catch ex As Exception
            clsDalContract.RollBackProc()
            colException.Add(CardAccptor & Space(1) & ex.Message)
        End Try
    End Sub

    Private Function ErrHandling() As Boolean
        Try
            Dim hErr As Boolean = False
            ClassError.BackupLogErrorFolder()
            ClassError.EmptyLogErrorFolder()

            If colDoneSuccessfully.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrDoneSuccessfully_FileName, colDoneSuccessfully)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colDoneSuccessfully.Count.ToString & vbCrLf & "مواردی که در سوئیچ ثبت شد ولی در سیستم بروزرسانی نشد در فایلی در مسیر زیر قرار دارد" & vbCrLf + TextLogErrorFilePath + ErrDoneSuccessfully_FileName)
            End If
            If colErr.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrErr_FileName, colErr)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colErr.Count.ToString & vbCrLf & "err!" & vbCrLf + TextLogErrorFilePath + ErrErr_FileName)
            End If
            If colException.Count > 0 Then
                hErr = True
                ClassError.LogError(ErrException_FileName, colException)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colException.Count.ToString & vbCrLf & "Exception!" & vbCrLf + TextLogErrorFilePath + ErrException_FileName)
            End If



            ErrHandling = hErr
        Catch ex As Exception
            ErrHandling = False
            Throw ex
        End Try

    End Function

    Private Sub Import()
        Try
            dtImportExcel.Clear()
            Dim frm As New OpenFileDialog
            frm.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If frm.FileName = String.Empty Then
                    Exit Sub
                End If
                Dim clsExcel As New ClassExcel(frm.FileName)
                dtImportExcel = clsExcel.Read(1, True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            Me.Import()
            If dtImportExcel.Rows.Count > 0 Then

                For Each dr As DataGridViewRow In Me.dgvCardAcceptor.Rows
                    dr.Cells(colChk.Name).Value = False
                Next
                Select Case Me.cboImportType.SelectedIndex
                    Case 0
                        Me.dtImportExcel.Columns(0).ColumnName = "Switch_TerminalID_vc"
                        Me.dtImportExcel.DefaultView.Sort = "Switch_TerminalID_vc desc"
                        Me.dvGrid.Sort = "Switch_TerminalID_vc desc"

                        Dim i As Integer = 0
                        Dim j As Integer = 0
                        While i <= dtImportExcel.Rows.Count - 1
                            While j <= dvGrid.Count - 1
                                If Convert.ToInt32(dtImportExcel.DefaultView(i)("Switch_TerminalID_vc").ToString.Remove(0, 1)) <= Convert.ToInt32(dvGrid(j)("Switch_TerminalID_vc").ToString.Remove(0, 1)) Then
                                    If Convert.ToInt32(dvGrid(j)("Switch_TerminalID_vc").ToString.Remove(0, 1)) = Convert.ToInt32(dtImportExcel.DefaultView(i)("Switch_TerminalID_vc").ToString.Remove(0, 1)) Then
                                        Me.dgvCardAcceptor.Rows(j).Cells(colChk.Name.ToString).Value = True
                                    End If
                                    j = j + 1
                                Else
                                    Exit While
                                End If
                            End While
                            i = i + 1
                        End While

                    Case 1
                        Me.dtImportExcel.Columns(0).ColumnName = "Switch_CardAcceptorID_vc"
                        Me.dtImportExcel.DefaultView.Sort = "Switch_CardAcceptorID_vc desc"
                        Me.dvGrid.Sort = "Switch_CardAcceptorID_vc desc"

                        Dim i As Integer = 0
                        Dim j As Integer = 0
                        While i <= dtImportExcel.Rows.Count - 1
                            While j <= dvGrid.Count - 1
                                If Convert.ToInt32(dtImportExcel.DefaultView(i)("Switch_CardAcceptorID_vc").ToString.Remove(0, 8)) <= Convert.ToInt32(dvGrid(j)("Switch_CardAcceptorID_vc").ToString.Remove(0, 8)) Then
                                    If Convert.ToInt32(dvGrid(j)("Switch_CardAcceptorID_vc").ToString.Remove(0, 8)) = Convert.ToInt32(dtImportExcel.DefaultView(i)("Switch_CardAcceptorID_vc").ToString.Remove(0, 8)) Then
                                        Me.dgvCardAcceptor.Rows(j).Cells(colChk.Name.ToString).Value = True
                                    End If
                                    j = j + 1
                                Else
                                    Exit While
                                End If
                            End While
                            i = i + 1
                        End While
                End Select

                Me.dgvCardAcceptor.EndEdit()
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub
End Class