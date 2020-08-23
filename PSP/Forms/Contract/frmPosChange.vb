Public Class frmPosChange
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private clsDalCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private clsDalPosVisitor As New ClassDALPosVisitor(modPublicMethod.ConnectionString)
    Private dtOutlet As New DataTable
    Private dtSerial As New DataTable
    Private dtBeforeAssigned As New DataTable
    Private dtCity As New DataTable

    Private Sub btnAssignNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignNew.Click
        Try
            Me.EmptyTextBoxes()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim CLSUserLoginDA As New ClassUserLoginDataAccess(modPublicMethod.ConnectionString)
        Try
            Dim ClsReport As New ClassDALReport(modPublicMethod.ConnectionString)
            If Me.txtOutlet_vc.Text.Trim <> String.Empty Then
                If txtSerial_vc.Text.Trim().Length = 0 Then
                    ShowErrorMessage("شماره سریال را وارد کنید ")
                    Exit Sub
                ElseIf LastStatusIsApprovedByVisitor() = False Then
                    Exit Sub
                End If
                Dim CountOfTranIn20Days As Int64 = ClsReport.GetCountOfTran_ByOutlet_InLastTwentyDays(Me.txtOutlet_vc.Text.Trim)
                CLSUserLoginDA.BeginProc()
                Dim VisitorIDByUser As Int64 = CLSUserLoginDA.GetVisitorIDByUserID(ClassUserLoginDataAccess.ThisUser.UserID)
                CLSUserLoginDA.EndProc()
                If (VisitorIDByUser > 0 And CountOfTranIn20Days > 0) Or (VisitorIDByUser = 0) Then
                    Save()
                Else
                    ErrorProvider.SetError(txtOutlet_vc, "کاربرجاری مجاز به تغییر سریال این پایانه نمی باشد")
                End If
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Function LastStatusIsApprovedByVisitor() As Boolean
        clsDalPosVisitor.BeginProc()
        Try
            If clsDalPosVisitor.LastStatusIsApprovedByVisitor(txtSerial_vc.Text) = False Then
                ShowErrorMessage("بازاریاب مربوطه ، دریافت این دستگاه را تایید نکرده است")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            clsDalPosVisitor.EndProc()
        End Try
    End Function

    Private Sub EmptyTextBoxes()
        txtOutlet_vc.Clear()
        txtSerial_vc.Clear()
    End Sub
    Private Sub Save()

        Try
            clsDalContract.BeginProc()
            modPublicMethod.ErrorProviderClear(ErrorProvider)
            Try
                If RequiredValidator() = False Then
                    Exit Sub
                End If
                If RequiredValidatorAssignmentIn30Days() = False Then
                    Exit Sub
                End If
                If DBRequiredValidator() = False Then
                    Exit Sub
                End If

                Me.PosChange()
            Catch ex As Exception
                ClassError.LogError(ex)
                Exit Sub
            End Try
            Try
                Me.EmptyTextBoxes()
                'Me.PrintLabel()
            Catch ex As Exception
                ClassError.LogError(ex)
            End Try

        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Try
            Dim res As Boolean = True
            If txtOutlet_vc.Text = String.Empty Then
                ErrorProvider.SetError(txtOutlet_vc, "کد پایانه را وارد کنید")
                res = False
            Else
                ErrorProvider.SetError(txtOutlet_vc, "")
            End If
            If txtSerial_vc.Text.Trim = String.Empty Then
                ErrorProvider.SetError(txtSerial_vc, "سریال را وارد کنید")
                res = False
            Else
                ErrorProvider.SetError(txtSerial_vc, "")
            End If
            Return res
        Catch ex As Exception
            RequiredValidator = False
            Throw ex
        End Try
    End Function
    Private Function RequiredValidatorAssignmentIn30Days() As Boolean
        ' checks if user is not eniac user then continues : 
        Dim CLSUserLoginDA As New ClassUserLoginDataAccess(modPublicMethod.ConnectionString)
        Try
            CLSUserLoginDA.BeginProc()
            Dim VisitorIDByUser As Int64 = CLSUserLoginDA.GetVisitorIDByUserID(ClassUserLoginDataAccess.ThisUser.UserID)
            CLSUserLoginDA.EndProc()
            If (VisitorIDByUser > 0) Then
                Dim lastMonthDate As String
                lastMonthDate = DateTool.ConvertDate(DateAdd(DateInterval.Day, -30, Now()))

                If clsDalPos.IsPosChangedInLast30Days(txtSerial_vc.Text, txtOutlet_vc.Text, lastMonthDate) = True Then
                    ErrorProvider.SetError(txtSerial_vc, "یک سریال در کمتر از 30 روز نمی تواند عوض شود")
                    Return False
                End If
            End If

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            Return False
        End Try
        Return True
    End Function
    Private Function DBRequiredValidator() As Boolean
        Try
            'reza
            'Dim CLSUserLoginDA As New ClassUserLoginDataAccess(modPublicMethod.ConnectionString)

            Dim res As Boolean = True
            clsDalContract.DDeviceID = -1
            clsDalContract.DPosID = -1
            clsDalPos.PosID = -1

            dtOutlet.Clear()
            clsDalContract.DOutlet_vc = txtOutlet_vc.Text.Trim

            'reza
            'clsDalContract.VisitorID = CLSUserLoginDA.GetVisitorIDByUserID(ClassUserLoginDataAccess.ThisUser.UserID)

            dtOutlet = clsDalContract.GetByDOutletContractingParty_Contract_Account_Store_Device(ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtOutlet.Rows.Count = 0 Then
                ErrorProvider.SetError(txtOutlet_vc, "کد نامعتبر است")
                clsDalContract.DDeviceID = -1
                clsDalContract.DPosID = -1
                'clsDalContract.ContractID = -1
                res = False
            Else
                If dtOutlet.Rows(0).Item("DPosid") <= 0 Then
                    ErrorProvider.SetError(txtOutlet_vc, "کد قبلا فسخ پز شده است")
                    clsDalContract.DDeviceID = -1
                    clsDalContract.DPosID = -1
                    'clsDalContract.ContractID = -1
                    res = False
                Else
                    ErrorProvider.SetError(txtOutlet_vc, "")
                    clsDalContract.DDeviceID = dtOutlet.Rows(0).Item("DDeviceID")
                    clsDalContract.DPosID = dtOutlet.Rows(0).Item("DPosID")
                    clsDalContract.DOutlet_vc = dtOutlet.Rows(0).Item("DOutlet_vc")
                    clsDalContract.DCode_vc = dtOutlet.Rows(0).Item("DCode_vc")
                    clsDalContract.SName_nvc = dtOutlet.Rows(0).Item("SName_nvc")
                    clsDalContract.FirstName_nvc = dtOutlet.Rows(0).Item("FirstName_nvc")
                    clsDalContract.LastName_nvc = dtOutlet.Rows(0).Item("LastName_nvc")
                    clsDalContract.SCityID = dtOutlet.Rows(0).Item("SCityID")
                    clsDalCity.CityID = clsDalContract.SCityID
                    dtCity = clsDalCity.GetByID()
                    If dtCity.Rows.Count > 0 Then
                        clsDalContract.SCityname_nvc = dtCity.Rows(0).Item("Name_nvc")
                    Else
                        clsDalContract.SCityname_nvc = ""
                    End If
                End If
            End If



            dtSerial.Clear()
            clsDalPos.Serial_vc = txtSerial_vc.Text
            'Mirmobin
            dtSerial = clsDalPos.GetBySerialPos(ClassUserLoginDataAccess.ThisUser.UserID)
            If dtSerial.Rows.Count = 0 Then
                ErrorProvider.SetError(txtSerial_vc, "سریال نامعتبر است")
                clsDalPos.PosID = -1
                res = False
            Else
                If dtSerial.Rows(0).Item("Active_Tint") <> 1 Then
                    ErrorProvider.SetError(txtSerial_vc, "سریال وارد شده فعال نمی باشد")
                    clsDalPos.PosID = -1
                    res = False
                Else
                    dtBeforeAssigned.Clear()
                    dtBeforeAssigned = clsDalContract.GetByPosIDDevice(dtSerial.Rows(0).Item("posid"))
                    If dtBeforeAssigned.Rows.Count > 0 Then
                        ErrorProvider.SetError(txtSerial_vc, "این سریال به یک پذیرنده در سیستم اختصاص دارد ")
                        clsDalPos.PosID = -1
                        res = False
                    Else
                        ErrorProvider.SetError(txtSerial_vc, "")
                        clsDalPos.PosID = dtSerial.Rows(0).Item("posid")
                    End If
                End If
            End If

            Return res
        Catch ex As Exception
            DBRequiredValidator = False
            Throw ex
        End Try
    End Function
    Private Sub PosChange()
        Try
            Me.SaveForDeviceCancelOK()
            Me.SaveForDeviceCancelNOK()
            Me.ReAssign()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveForDeviceCancelOK()
        Try
            clsDalContract.DPDeviceID = clsDalContract.DDeviceID
            clsDalContract.DPPosID = clsDalContract.DPosID
            clsDalContract.DPIOTypeID = ClassDALIOType.IOTypeEnum.OutofStore '2
            clsDalContract.InsertDevicePos()
            'clsDalContract.UpdateDevice_OnlyPosID(-1, clsDalContract.DDeviceID, True)
            clsDalContract.DCDeviceID = clsDalContract.DDeviceID
            clsDalContract.DCPosID = clsDalContract.DPosID
            clsDalContract.DCFlag = ClassDALContract.DeviceCancelFlagTypeEnum.DevicecancelOK
            clsDalContract.DCDesc_nvc = "Becuase Of Pos Change"
            clsDalContract.DCDate_vc = GetDateNow()
            clsDalContract.InsertDeviceCancel()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveForDeviceCancelNOK()
        Try
            Try
                'clsDalContract.UpdateDevice_OnlyPosID(0, clsDalContract.DDeviceID, True)
                clsDalContract.DCDeviceID = clsDalContract.DDeviceID
                clsDalContract.DCPosID = clsDalContract.DPosID
                clsDalContract.DCFlag = ClassDALContract.DeviceCancelFlagTypeEnum.DevicecancelNOK
                clsDalContract.DCDesc_nvc = "Becuase Of Pos Change"
                clsDalContract.DCDate_vc = GetDateNow()
                clsDalContract.InsertDeviceCancel()
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ReAssign()
        Try
            clsDalContract.DPDeviceID = clsDalContract.DDeviceID
            clsDalContract.DPPosID = clsDalPos.PosID
            clsDalContract.DPIOTypeID = ClassDALIOType.IOTypeEnum.InStore '1
            clsDalContract.InsertDevicePos()
            clsDalContract.UpdateDevice_OnlyPosID(clsDalPos.PosID, clsDalContract.DDeviceID, True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PrintLabel()
        Try
            ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_StoreName
            PrintDocument.Print()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub btnAssignReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignReprint.Click
        Dim _frmDeviceAssigningReprint As New frmDeviceAssigningReprint
        _frmDeviceAssigningReprint.ShowDialog()

    End Sub

    Private Sub frmPosChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

    End Sub
End Class