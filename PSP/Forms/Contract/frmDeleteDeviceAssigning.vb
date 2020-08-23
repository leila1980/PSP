Public Class frmDeleteDeviceAssigning
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private dtAssigningPos As New DataTable
    Private dtInstalling As New DataTable


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If ShowConfirmDeleteMessage() = True Then
                Me.Delete()
            End If
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(modApplicationMessage.msgDeleteFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub Delete()
        Try
            If DeleteRequiredValidator() = False Then
                Exit Sub
            End If
            clsDalContract.BeginProc()
            clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
            dtAssigningPos.Clear()
            dtAssigningPos = clsDalContract.GetByContractIDSerialCountContractingParty_Contract_Account_Store_Device_Device_Pos_DevicePos_PURE(txtSerial_vc.Text, 1, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtAssigningPos.Rows.Count > 0 Then
                clsDalContract.DDeviceID = dtAssigningPos.Rows(0).Item("DDeviceID")

                If IsDBNull(dtAssigningPos.Rows(0).Item("DSwitch_CardAcceptorID_vc")) = False AndAlso dtAssigningPos.Rows(0).Item("DSwitch_CardAcceptorID_vc") <> "" Then
                    ShowErrorMessage("اين دستگاه به سوئیچ ارسال شده و قابل حذف نمی باشد ")
                    Exit Sub
                End If

                dtInstalling = clsDalContract.GetBYDeviceIDInstallingDetail(clsDalContract.DDeviceID)
                If dtInstalling.Rows.Count = 0 Then
                    clsDalContract.DPDevicePosID = dtAssigningPos.Rows(0).Item("DPDevicePosID")
                    clsDalContract.DDeviceID = dtAssigningPos.Rows(0).Item("DDeviceID")
                    Me.DeleteAssigendPos()
                    Me.DeleteDevice()
                    clsDalContract.UpdateContractImportDeleteAssign(clsDalContract.DDeviceID)
                    'Me.UpdateCodes_Counter(dtAssigningPos)

                    Me.EmptyTextBoxes()
                Else
                    ShowErrorMessage("اين دستگاه نصب شده است و قابل حذف نمی باشد")
                End If

                'clsDalContract.DPDevicePosID = dtAssigningPos.Rows(0).Item("DPDevicePosID")
                'clsDalContract.DDeviceID = dtAssigningPos.Rows(0).Item("DDeviceID")
                'Me.DeleteAssigendPos()
                'Me.DeleteDevice()
                'Me.UpdateCodes_Counter(dtAssigningPos)



                'Me.EmptyTextBoxes()
            Else
                ShowErrorMessage("اطلاعات وارد شده نامعتبر می باشد")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    'Private Sub UpdateCodes_Counter(ByVal dtAssigningPos As DataTable)
    '    Try
    '        Dim dt As New DataTable

    '        Dim strMerchant As String
    '        Dim strVat As String
    '        Dim strOutlet As String
    '        Dim strCode As String

    '        Dim strMerchantFirstPart As String
    '        Dim strVatFirstPart As String
    '        Dim strOutletFirstPart As String
    '        Dim strCodeFirstPart As String


    '        Dim strMerchantCounter As String
    '        Dim strVatCounter As String
    '        Dim strOutletCounter As String
    '        Dim strCodeCounter As String

    '        Dim lngMerchantCounter_Deleted As Int64
    '        Dim lngVatCounter_Deleted As Int64
    '        Dim lngOutletCounter_Deleted As Int64
    '        Dim lngCodeCounter_Deleted As Int64

    '        Dim lngMerchantCounter_ForUpdate As Int64
    '        Dim lngVatCounter_ForUpdate As Int64
    '        Dim lngOutletCounter_ForUpdate As Int64
    '        Dim lngCodeCounter_ForUpdate As Int64

    '        Dim strMerchantCounter_ForUpdate As String
    '        Dim strVatCounter_ForUpdate As String
    '        Dim strOutletCounter_ForUpdate As String
    '        Dim strCodeCounter_ForUpdate As String



    '        Dim MerchantCodes_CounterID As Int64
    '        Dim VatCodes_CounterID As Int64
    '        Dim OutletCodes_CounterID As Int64
    '        Dim CodeCodes_CounterID As Int64

    '        strMerchant = dtAssigningPos.Rows(0).Item("DMerchant_vc")
    '        strVat = dtAssigningPos.Rows(0).Item("DVat_vc")
    '        strOutlet = dtAssigningPos.Rows(0).Item("DOutlet_vc")
    '        strCode = dtAssigningPos.Rows(0).Item("DCode_vc")

    '        strMerchantFirstPart = Microsoft.VisualBasic.Left(strMerchant, strMerchant.Length - 4)
    '        strVatFirstPart = Microsoft.VisualBasic.Left(strVat, strVat.Length - 4)
    '        strOutletFirstPart = Microsoft.VisualBasic.Left(strOutlet, strOutlet.Length - 5)
    '        strCodeFirstPart = Microsoft.VisualBasic.Left(strCode, strCode.Length - 5)

    '        strMerchantCounter = Microsoft.VisualBasic.Right(strMerchant, 4)
    '        strVatCounter = Microsoft.VisualBasic.Right(strVat, 4)
    '        strOutletCounter = Microsoft.VisualBasic.Right(strOutlet, 5)
    '        strCodeCounter = Microsoft.VisualBasic.Right(strCode, 5)

    '        lngMerchantCounter_Deleted = Microsoft.VisualBasic.Val(strMerchantCounter)
    '        lngVatCounter_Deleted = Microsoft.VisualBasic.Val(strVatCounter)
    '        lngOutletCounter_Deleted = Microsoft.VisualBasic.Val(strOutletCounter)
    '        lngCodeCounter_Deleted = Microsoft.VisualBasic.Val(strCodeCounter)

    '        lngMerchantCounter_ForUpdate = lngMerchantCounter_Deleted - 1
    '        lngVatCounter_ForUpdate = lngVatCounter_Deleted - 1
    '        lngOutletCounter_ForUpdate = lngOutletCounter_Deleted - 1
    '        lngCodeCounter_ForUpdate = lngCodeCounter_Deleted - 1

    '        dt.Clear()
    '        dt = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(strMerchantFirstPart, "M")
    '        If dt.Rows.Count > 0 Then
    '            MerchantCodes_CounterID = dt.Rows(0).Item("ID")
    '            If lngMerchantCounter_ForUpdate = 0 Then
    '                '===حذف از Codes_Counter_T
    '                clsDalContract.DeleteCodes_Counter(MerchantCodes_CounterID)
    '            Else
    '                If Microsoft.VisualBasic.Val(dt.Rows(0).Item("LastCounter_vc")) > lngMerchantCounter_ForUpdate Then
    '                    '===بروزرساني  Codes_Counter_T
    '                    strMerchantCounter_ForUpdate = Microsoft.VisualBasic.Right("0000" + lngMerchantCounter_ForUpdate.ToString(), 4)
    '                    clsDalContract.UpdateCodes_CounterForLastCounter(strMerchantCounter_ForUpdate, MerchantCodes_CounterID)
    '                End If
    '            End If
    '        End If


    '        dt.Clear()
    '        dt = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(strVatFirstPart, "V")
    '        If dt.Rows.Count > 0 Then
    '            VatCodes_CounterID = dt.Rows(0).Item("ID")
    '            If lngVatCounter_ForUpdate = 0 Then
    '                '===حذف از Codes_Counter_T
    '                clsDalContract.DeleteCodes_Counter(VatCodes_CounterID)
    '            Else
    '                If Microsoft.VisualBasic.Val(dt.Rows(0).Item("LastCounter_vc")) > lngVatCounter_ForUpdate Then
    '                    '===بروزرساني  Codes_Counter_T
    '                    strVatCounter_ForUpdate = Microsoft.VisualBasic.Right("0000" + lngVatCounter_ForUpdate.ToString(), 4)
    '                    clsDalContract.UpdateCodes_CounterForLastCounter(strVatCounter_ForUpdate, VatCodes_CounterID)
    '                End If
    '            End If
    '        End If

    '        dt.Clear()
    '        dt = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(strOutletFirstPart, "O")
    '        If dt.Rows.Count > 0 Then
    '            OutletCodes_CounterID = dt.Rows(0).Item("ID")
    '            If lngOutletCounter_ForUpdate = 0 Then
    '                '===حذف از Codes_Counter_T
    '                clsDalContract.DeleteCodes_Counter(OutletCodes_CounterID)
    '            Else
    '                If Microsoft.VisualBasic.Val(dt.Rows(0).Item("LastCounter_vc")) > lngOutletCounter_ForUpdate Then
    '                    '===بروزرساني  Codes_Counter_T
    '                    strOutletCounter_ForUpdate = Microsoft.VisualBasic.Right("00000" + lngOutletCounter_ForUpdate.ToString(), 5)
    '                    clsDalContract.UpdateCodes_CounterForLastCounter(strOutletCounter_ForUpdate, OutletCodes_CounterID)
    '                End If
    '            End If
    '        End If

    '        dt.Clear()
    '        dt = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(strCodeFirstPart, "C")
    '        If dt.Rows.Count > 0 Then
    '            CodeCodes_CounterID = dt.Rows(0).Item("ID")
    '            If lngCodeCounter_ForUpdate = 0 Then
    '                '===حذف از Codes_Counter_T
    '                clsDalContract.DeleteCodes_Counter(CodeCodes_CounterID)
    '            Else
    '                If Microsoft.VisualBasic.Val(dt.Rows(0).Item("LastCounter_vc")) > lngCodeCounter_ForUpdate Then
    '                    '===بروزرساني  Codes_Counter_T
    '                    strCodeCounter_ForUpdate = Microsoft.VisualBasic.Right("00000" + lngCodeCounter_ForUpdate.ToString(), 5)
    '                    clsDalContract.UpdateCodes_CounterForLastCounter(strCodeCounter_ForUpdate, CodeCodes_CounterID)
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Function DeleteRequiredValidator()
        Dim res As Boolean = True
        If txtContractID.Text.Trim = "" Then
            ErrorProvider.SetError(txtContractID, "کد قرارداد را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtContractID, "")
        End If
        If txtSerial_vc.Text.Trim = "" Then
            ErrorProvider.SetError(txtSerial_vc, "شماره سریال پز را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtSerial_vc, "")
        End If
        Return res
    End Function
    Private Sub EmptyTextBoxes()
        txtContractID.Text = ""
        txtSerial_vc.Text = ""
    End Sub
#Region "Delete"
    Private Sub DeleteAssigendPos()
        Try
            clsDalContract.DeleteDevicePos()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DeleteDevice()
        Try
            clsDalContract.DeleteDevice()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
    Private Sub frmDeviceAssigningReprint_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If

    End Sub
    Private Sub txtSerial_vc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial_vc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ShowConfirmDeleteMessage() = True Then
                Me.Delete()
            End If
        End If
    End Sub

    Private Sub frmDeleteDeviceAssigning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class