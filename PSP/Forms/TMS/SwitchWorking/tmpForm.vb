Imports AcceptorManagementService
Public Class frmTemp
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

    Private Sub frmSwitchFeeSchema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.FillGrid()
            Me.InitGrid()
            Me.FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            Dim dt As New DataTable
            clsDalContract.BeginProc()
            dt = clsDalContract.GetAllCardAcceptorInfo_ForPaymentMethodType()
            Dim mydt As New DataTable
            mydt.Columns.Add("LastName_nvc")
            mydt.Columns.Add("SName_nvc")
            mydt.Columns.Add("Switch_CardAcceptorID_vc")
            mydt.Columns.Add("Switch_TerminalID_vc")
            mydt.Columns.Add("Switch_PaymentMethodType")
            mydt.Columns.Add("Switch_PaymentMethodTypeName")
            mydt.Columns.Add("SAddress_nvc")

            'Dim dr() As DataRow = 

            For Each d As DataRow In dt.Select("Switch_PaymentMethodType = 128")
                mydt.ImportRow(d)
            Next
            dgvCardAcceptor.DataSource = mydt
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
                'If dgvCardAcceptor.Rows(i).Cells("colChk").Value = True Then
                checked += 1
                If clsCMSProject.IsSent2Switch Then
                    'If myConStr.ConnectionAvailable(clsCMSProject.ESSWS_NVC) Then
                    Assign(dgvCardAcceptor.Rows(i).Cells("Switch_CardAcceptorID_vc").Value, cboPaymentMethodType.SelectedValue, dgvCardAcceptor.Rows(i).Cells("SAddress_nvc").Value, clsCMSProject.ESSWS_NVC)
                    '    'End If
                    'Else
                    '    ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
                    'End If
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

End Class