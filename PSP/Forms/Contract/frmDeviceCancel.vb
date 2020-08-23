Public Class frmDeviceCancel
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    'Private clsDALTMS As New ClassDALTMS()

    Private clsDALPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private dt As New DataTable
    Private dtReport As New DataTable
    Public DeviceCancelType As DeviceCancelTypeEnum
    Private TheLastTranDate As String
    'Madadi
    Dim res As Boolean = True


    Public Enum DeviceCancelTypeEnum As Int16
        DeviveCancelOK = 1
        DeviceCancelNOK = 2
    End Enum
    Private Sub txtSerial_vc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerial_vc.Leave
        Try
            ErrorProvider.Clear()
            If txtSerial_vc.Text.Trim = "" Then
                Exit Sub
            End If
            txtSerial_vcLeave()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub txtSerial_vcLeave()
        Try
            clsDALPos.BeginProc()
            clsDalContract.BeginProc()
            Select Case Me.DeviceCancelType
                Case DeviceCancelTypeEnum.DeviveCancelOK
                    If CheckSerailValidityForCancelOK() = False Then
                        Me.FillTextBoxes(0, "", "", "", "")
                        ''raeisi----------------------------------------------------------------
                        dt = clsDalContract.GetBYDeviceIDContractingParty_Contract_Account_Store_Device_Pos_PURE_Show(clsDALPos.Serial_vc, ClassUserLoginDataAccess.ThisUser.ProjectID)
                        If dt.Rows.Count > 0 Then
                            clsDalContract.ContractID = dt.Rows(0).Item("ContractID")
                            clsDalContract.FirstName_nvc = dt.Rows(0).Item("FirstName_nvc")
                            clsDalContract.LastName_nvc = dt.Rows(0).Item("LastName_nvc")
                            clsDalContract.SName_nvc = dt.Rows(0).Item("SName_nvc")
                            clsDalContract.DOutlet_vc = dt.Rows(0).Item("DOutlet_vc")
                            TheLastTranDate = String.Empty
                        Else
                            clsDalContract.ContractID = 0
                            clsDalContract.FirstName_nvc = ""
                            clsDalContract.LastName_nvc = ""
                            clsDalContract.SName_nvc = ""
                            clsDalContract.DOutlet_vc = ""
                            TheLastTranDate = ""
                        End If
                        dt.Clear()
                        FillTextBoxes(clsDalContract.ContractID, clsDalContract.DOutlet_vc, clsDalContract.FirstName_nvc + " " + clsDalContract.LastName_nvc, clsDalContract.SName_nvc, TheLastTranDate)
                        '--------------------------------------------------------------------
                        Exit Sub
                    End If
                Case DeviceCancelTypeEnum.DeviceCancelNOK
                    If CheckSerailValidityForCancelNOK() = False Then
                        Me.FillTextBoxes(0, "", "", "", "")
                        ''raeisi----------------------------------------------------------------
                        dt = clsDalContract.GetBYDeviceIDContractingParty_Contract_Account_Store_Device_PURE_Show(clsDALPos.Serial_vc, ClassUserLoginDataAccess.ThisUser.ProjectID)
                        If dt.Rows.Count > 0 Then
                            clsDalContract.ContractID = dt.Rows(0).Item("ContractID")
                            clsDalContract.FirstName_nvc = dt.Rows(0).Item("FirstName_nvc")
                            clsDalContract.LastName_nvc = dt.Rows(0).Item("LastName_nvc")
                            clsDalContract.SName_nvc = dt.Rows(0).Item("SName_nvc")
                            clsDalContract.DOutlet_vc = dt.Rows(0).Item("DOutlet_vc")
                            TheLastTranDate = String.Empty
                        Else
                            clsDalContract.ContractID = 0
                            clsDalContract.FirstName_nvc = ""
                            clsDalContract.LastName_nvc = ""
                            clsDalContract.SName_nvc = ""
                            clsDalContract.DOutlet_vc = ""
                            TheLastTranDate = ""
                        End If
                        dt.Clear()
                        FillTextBoxes(clsDalContract.ContractID, clsDalContract.DOutlet_vc, clsDalContract.FirstName_nvc + " " + clsDalContract.LastName_nvc, clsDalContract.SName_nvc, TheLastTranDate)
                        '----------------------------------------------------------------
                        Exit Sub
                    End If
            End Select

            dt.Clear()
            Select Case Me.DeviceCancelType
                Case DeviceCancelTypeEnum.DeviveCancelOK
                    dt = clsDalContract.GetBYDeviceIDContractingParty_Contract_Account_Store_Device_Pos_PURE(clsDalContract.DDeviceID, ClassUserLoginDataAccess.ThisUser.ProjectID)

                Case DeviceCancelTypeEnum.DeviceCancelNOK
                    dt = clsDalContract.GetBYDeviceIDContractingParty_Contract_Account_Store_Device_PURE(clsDalContract.DDeviceID, ClassUserLoginDataAccess.ThisUser.ProjectID)
            End Select


            If dt.Rows.Count > 0 Then
                clsDalContract.ContractID = dt.Rows(0).Item("ContractID")
                clsDalContract.FirstName_nvc = dt.Rows(0).Item("FirstName_nvc")
                clsDalContract.LastName_nvc = dt.Rows(0).Item("LastName_nvc")
                clsDalContract.SName_nvc = dt.Rows(0).Item("SName_nvc")
                If IsDBNull(dt.Rows(0).Item("DOutlet_vc")) = False Then
                    clsDalContract.DOutlet_vc = dt.Rows(0).Item("DOutlet_vc")
                Else
                    clsDalContract.DOutlet_vc = String.Empty
                End If
                If IsDBNull(dt.Rows(0).Item("TheLastTranDate")) = False Then
                    TheLastTranDate = dt.Rows(0).Item("TheLastTranDate")
                Else
                    TheLastTranDate = String.Empty
                End If




            Else
                clsDalContract.ContractID = 0
                clsDalContract.FirstName_nvc = ""
                clsDalContract.LastName_nvc = ""
                clsDalContract.SName_nvc = ""
                clsDalContract.DOutlet_vc = ""
                TheLastTranDate = ""

            End If

            Select Case Me.DeviceCancelType
                Case DeviceCancelTypeEnum.DeviceCancelNOK
                    dt.Clear()
                    dt = clsDalContract.GetByContractIDContrPContrStoreVisitorDevice(clsDalContract.ContractID, ClassUserLoginDataAccess.ThisUser.ProjectID)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("Blocked_bit") = True Then
                            ErrorProvider.SetError(txtSerial_vc, "قرارداد مربوطه مسدود شده است از اين رو اين پز قابل كنسل كردن عمليات فسخ پز نمي باشد ")
                            Exit Sub
                        Else
                            ErrorProvider.SetError(txtSerial_vc, "")
                        End If
                    Else
                        ErrorProvider.SetError(txtSerial_vc, "خطا")
                        Exit Sub
                    End If


            End Select
            FillTextBoxes(clsDalContract.ContractID, clsDalContract.DOutlet_vc, clsDalContract.FirstName_nvc + " " + clsDalContract.LastName_nvc, clsDalContract.SName_nvc, TheLastTranDate)
            EditState()
        Catch ex As Exception
            Throw ex
        Finally
            clsDALPos.EndProc()
            clsDalContract.EndProc()

        End Try
    End Sub

    Private Function CheckSerailValidityForCancelOK() As Boolean
        'Dim res As Boolean = True 'Madadi
        Try
            dt.Clear()
            clsDALPos.Serial_vc = txtSerial_vc.Text
            dt = clsDALPos.GetBySerialPos(ClassUserLoginDataAccess.ThisUser.UserID)
            If dt.Rows.Count > 0 Then
                clsDalContract.DCPosID = dt.Rows(0).Item("PosID")
                clsDalContract.DPPosID = dt.Rows(0).Item("PosID")
                clsDalContract.DPosID = dt.Rows(0).Item("PosID")

                dt.Clear()
                dt = clsDalContract.GetByPosIDDevice(clsDalContract.DPosID)
                If dt.Rows.Count > 0 Then
                    clsDalContract.DCDeviceID = dt.Rows(0).Item("DeviceID")
                    clsDalContract.DPDeviceID = dt.Rows(0).Item("DeviceID")
                    clsDalContract.DDeviceID = dt.Rows(0).Item("DeviceID")

                    ErrorProvider.SetError(txtSerial_vc, "")
                Else
                    dt.Clear()
                    dt = clsDalContract.GetByPosIDDeviceCancelTheLatestOperation(clsDalContract.DPosID)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("Flag") = ClassDALContract.DeviceCancelFlagTypeEnum.DevicecancelOK Then
                            ErrorProvider.SetError(txtSerial_vc, "این شماره سریال قبلا فسخ شده است ")
                            res = False
                        Else
                            ErrorProvider.SetError(txtSerial_vc, "عملیات فسخ پز برای این شماره سریال انجام شده است ولی تخصیص مجدد انجام نشده است")
                            res = False
                        End If
                    Else
                        ErrorProvider.SetError(txtSerial_vc, "این شماره سریال تخصیص نیافته است")
                        res = False
                    End If
                End If
            Else
                ErrorProvider.SetError(txtSerial_vc, "شماره سریال پز نامعتبر می باشد")
                res = False
            End If
        Catch ex As Exception

            Throw ex
        Finally
            CheckSerailValidityForCancelOK = res
        End Try
    End Function
    Private Function CheckSerailValidityForCancelNOK() As Boolean
        Dim res As Boolean = True
        Try
            'dt.Clear()
            'dt = clsDalContract.GetByContractIDContrPContrStoreVisitorDevice(Convert.ToInt64(txtContractID.Text))
            'If dt.Rows(0).Item("Blocked_bit") = True Then
            '    ErrorProvider.SetError(txtSerial_vc, "قرارداد مربوطه مسدود شده است از اين رو اين پز قابل كنسل كردن عمليات فسخ پز نمي باشد ")
            '    res = False
            '    Exit Function
            'Else
            '    ErrorProvider.SetError(txtSerial_vc, "")
            'End If

            dt.Clear()
            clsDALPos.Serial_vc = txtSerial_vc.Text
            dt = clsDALPos.GetBySerialPos()
            If dt.Rows.Count > 0 Then
                clsDalContract.DCPosID = dt.Rows(0).Item("PosID")
                clsDalContract.DPPosID = dt.Rows(0).Item("PosID")
                clsDalContract.DPosID = dt.Rows(0).Item("PosID")

                dt.Clear()
                dt = clsDalContract.GetByPosIDDeviceCancelTheLatestOperation(clsDalContract.DPosID)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item("Flag") = ClassDALContract.DeviceCancelFlagTypeEnum.DevicecancelOK Then
                        If IsDBNull(dt.Rows(0).Item("SentToAccess_vc")) = True Then
                            clsDalContract.DCDeviceID = dt.Rows(0).Item("DeviceID")
                            clsDalContract.DPDeviceID = dt.Rows(0).Item("DeviceID")
                            clsDalContract.DDeviceID = dt.Rows(0).Item("DeviceID")
                            ErrorProvider.SetError(txtSerial_vc, "")
                        Else
                            ErrorProvider.SetError(txtSerial_vc, "این شماره سریال به بانک ارسال شده است و قابل کنسل کردن نمی باشد ")
                            res = False
                        End If
                    Else
                        ErrorProvider.SetError(txtSerial_vc, "این شماره سریال قبلا کنسل شده است ")
                        res = False
                    End If
                Else
                    ErrorProvider.SetError(txtSerial_vc, "این شماره سریال فسخ پز نشده است ")
                    res = False
                End If
            Else
                ErrorProvider.SetError(txtSerial_vc, "شماره سریال پز نامعتبر می باشد")
                res = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            CheckSerailValidityForCancelNOK = res
        End Try

    End Function
    Private Sub FillTextBoxes(ByVal ContractID As Int64, ByVal Outlet_vc As String, ByVal ContarctingPartyName_nvc As String, ByVal StoreName_nvc As String, ByVal TheLastTranDate As String)
        txtContractID.Text = IIf(ContractID = 0, "", ContractID.ToString)
        txtOutlet_vc.Text = Outlet_vc
        txtContarctingPartyName_nvc.Text = ContarctingPartyName_nvc
        txtStoreName_nvc.Text = StoreName_nvc
        txtTheLastTranDate.Text = TheLastTranDate

    End Sub
    Private Sub EditState()
        grpDetail.Enabled = True
    End Sub
    Private Sub ViewState()
        grpDetail.Enabled = False
    End Sub


    Private Sub frmDeviceCancel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try

    End Sub

    Private Sub LoadcmbDesc()

        Dim DeviceCancelDescription As New Eniac.PSP.DAL.DeviceCancelDesc
        Dim dt As DataTable = DeviceCancelDescription.SelectAll()
        Me.cmbDesc_nvc.DataSource = dt
        Me.cmbDesc_nvc.ValueMember = "DeviceCancelDescId"
        Me.cmbDesc_nvc.DisplayMember = "DeviceCancelDesc"
        Me.cmbDesc_nvc.SelectedIndex = -1

    End Sub

    Private Sub FormLoad()
        Try
            clsDalContract.BeginProc()
            SetForm()
            ClearForm()
            FillGrid()
            LoadcmbDesc()
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub SetForm()
        Select Case Me.DeviceCancelType
            Case DeviceCancelTypeEnum.DeviveCancelOK
                btnDeviceCancel.Text = Me.Text
                GroupBox4.Text = "لیست پزهای فسخ شده"
                chkCanceledVisitorPayment_bit.Visible = True
            Case DeviceCancelTypeEnum.DeviceCancelNOK
                btnDeviceCancel.Text = Me.Text
                GroupBox4.Text = "لیست پزهای کنسل شده"
                chkCanceledVisitorPayment_bit.Visible = False
        End Select
    End Sub
    Private Sub FillGrid()
        Try
            Select Case Me.DeviceCancelType
                Case DeviceCancelTypeEnum.DeviveCancelOK
                    dtReport = clsDalContract.GetByFlagContractingParty_Contract_Accont_Store_Device_Pos_DeviceCancel(ClassDALContract.DeviceCancelFlagTypeEnum.DevicecancelOK, ClassUserLoginDataAccess.ThisUser.ProjectID)
                Case DeviceCancelTypeEnum.DeviceCancelNOK
                    dtReport = clsDalContract.GetByFlagContractingParty_Contract_Accont_Store_Device_Pos_DeviceCancel(ClassDALContract.DeviceCancelFlagTypeEnum.DevicecancelNOK, ClassUserLoginDataAccess.ThisUser.ProjectID)
            End Select
            dgvReport.DataSource = dtReport
            dgvReport.Columns("ContractID").HeaderText = "کد قرارداد"
            dgvReport.Columns("ContractingPartyFullName").HeaderText = "نام طرف قرارداد"
            dgvReport.Columns("SName_nvc").HeaderText = "نام فروشگاه"
            dgvReport.Columns("DOutlet_vc").HeaderText = "Outlet"
            dgvReport.Columns("PSerial_vc").HeaderText = "شماره سریال دستگاه"
            dgvReport.Columns("DCode_vc").HeaderText = "pos code"

            dgvReport.Columns("DCDeviceCancelID").Visible = False
            dgvReport.Columns("DCDeviceID").Visible = False
            dgvReport.Columns("DCPosID").Visible = False
            dgvReport.Columns("DCDesc_nvc").HeaderText = "توضیحات"
            dgvReport.Columns("DCDate_vc").HeaderText = "تاریخ"
            dgvReport.Columns("DIFCanceled_VisitorPayment_bit").HeaderText = "حق الزحمه بازارياب"

            dgvReport.Columns("DCFlag").Visible = False

            dgvReport.Columns("ContractingPartyFullName").Width = 150
            dgvReport.Columns("DCDesc_nvc").Width = 160
            dgvReport.Columns("SName_nvc").Width = 150
            dgvReport.Columns("DOutlet_vc").Width = 110
            dgvReport.Columns("PSerial_vc").Width = 200
            dgvReport.Columns("VisitorFullName").HeaderText = "نام بازارياب"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnDeviceCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeviceCancel.Click
        'Dim CLSUserLoginDA As New ClassUserLoginDataAccess(modPublicMethod.ConnectionString)
        'Try
        '    ErrorProvider.Clear()

        '    Dim ClsReport As New ClassDALReport(modPublicMethod.ConnectionString)
        '    If Me.txtOutlet_vc.Text.Trim <> String.Empty Then
        '        Dim CountOfTranIn20Days As Int64 = ClsReport.GetCountOfTran_ByOutlet_InLastTwentyDays(Me.txtOutlet_vc.Text.Trim)
        '        CLSUserLoginDA.BeginProc()
        '        Dim VisitorIDByUser As Int64 = CLSUserLoginDA.GetVisitorIDByUserID(ClassUserLoginDataAccess.ThisUser.UserID)
        '        CLSUserLoginDA.EndProc()
        '        If (VisitorIDByUser > 0 And CountOfTranIn20Days > 0) Or (VisitorIDByUser = 0) Then
        '            btnDeviceCancelClick()
        '            FillGrid()
        '        Else
        '            ErrorProvider.SetError(txtSerial_vc, "کاربرجاری مجاز به فسخ این سریال نمی باشد")
        '        End If
        '    End If
        'Catch ex As Exception
        '    ShowErrorMessage(ex.Message)
        '    ClassError.LogError(ex)
        'End Try

        Dim CLSUserLoginDA As New ClassUserLoginDataAccess(modPublicMethod.ConnectionString)
        Try
            ErrorProvider.Clear()

            Dim ClsReport As New ClassDALReport(modPublicMethod.ConnectionString)
            If Me.txtOutlet_vc.Text.Trim <> String.Empty Then
                Dim CountOfTranIn20Days As Int64 = ClsReport.GetCountOfTran_ByOutlet_InLastTwentyDays(Me.txtOutlet_vc.Text.Trim)
                CLSUserLoginDA.BeginProc()
                Dim VisitorIDByUser As Int64 = CLSUserLoginDA.GetVisitorIDByUserID(ClassUserLoginDataAccess.ThisUser.UserID)
                CLSUserLoginDA.EndProc()
                If (VisitorIDByUser > 0 And CountOfTranIn20Days > 0) Or (VisitorIDByUser = 0) Then
                    btnDeviceCancelClick()
                    FillGrid()
                Else
                    ErrorProvider.SetError(txtSerial_vc, "کاربرجاری مجاز به فسخ این سریال نمی باشد")
                End If
            End If

            'CLSUserLoginDA.BeginProc()
            'Dim VisitorIDByUser As Int64 = CLSUserLoginDA.GetVisitorIDByUserID(ClassUserLoginDataAccess.ThisUser.UserID)
            'CLSUserLoginDA.EndProc()
            'If VisitorIDByUser = 0 Then
            '    btnDeviceCancelClick()
            '    FillGrid()
            'ElseIf VisitorIDByUser > 0 And Me.txtOutlet_vc.Text.Trim <> String.Empty And res = True Then
            '    Dim CountOfTranIn20Days As Int64 = ClsReport.GetCountOfTran_ByOutlet_InLastTwentyDays(Me.txtOutlet_vc.Text.Trim)
            '    If CountOfTranIn20Days > 0 Then
            '        btnDeviceCancelClick()
            '        FillGrid()
            '    End If
            'Else
            '    ErrorProvider.SetError(txtSerial_vc, "کاربرجاری مجاز به فسخ این سریال نمی باشد")
            'End If

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try

    End Sub
    Private Sub btnDeviceCancelClick()
        Try
            ErrorProvider.Clear()
            clsDalContract.BeginProc()
            'clsDALTMS.BeginProc()
            If RequiredValidator() = False Then
                Exit Sub
            End If
            If RequiredDBValidator() = False Then
                Exit Sub
            End If

            Select Case Me.DeviceCancelType
                Case DeviceCancelTypeEnum.DeviveCancelOK
                    SaveForDeviveCancelOK()

                Case DeviceCancelTypeEnum.DeviceCancelNOK
                    SaveForDeviceCancelNOK()
            End Select
            Me.ClearForm()
            Me.FillTextBoxes(0, "", "", "", "")
            Me.ViewState()
            txtSerial_vc.Focus()
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
            'clsDALTMS.EndProc()
        End Try

    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True

        If txtSerial_vc.Text.Trim = "" Then
            ErrorProvider.SetError(txtSerial_vc, "شماره سریال پز وارد نشده است")
            res = False
        Else
            ErrorProvider.SetError(txtSerial_vc, "")
        End If

        If txtDate_vc.Value = "" Then
            ErrorProvider.SetError(txtDate_vc, "تاریخ وارد نشده است")
            res = False
        Else
            ErrorProvider.SetError(txtDate_vc, "")
        End If

        If cmbDesc_nvc.SelectedIndex = -1 Then
            ErrorProvider.SetError(cmbDesc_nvc, "توضيحات انتخاب نشده است")
            res = False
        Else
            ErrorProvider.SetError(cmbDesc_nvc, "")
        End If


        Return res
    End Function
    Private Function RequiredDBValidator() As Boolean
        Dim res As Boolean = True
        Try
            Select Case Me.DeviceCancelType
                Case DeviceCancelTypeEnum.DeviveCancelOK
                    If CheckSerailValidityForCancelOK() = False Then
                        res = False
                        Exit Function
                    End If
                Case DeviceCancelTypeEnum.DeviceCancelNOK
                    If CheckSerailValidityForCancelNOK() = False Then
                        res = False
                        Exit Function
                    End If
            End Select
        Catch ex As Exception
            res = False
            Throw ex
        Finally
            RequiredDBValidator = res
        End Try
    End Function
    Private Sub SaveForDeviveCancelOK()
        Try
            clsDalContract.DPIOTypeID = ClassDALIOType.IOTypeEnum.OutofStore '2
            clsDalContract.InsertDevicePos()
            clsDalContract.UpdateDevice_OnlyPosID(-1, clsDalContract.DCDeviceID, chkCanceledVisitorPayment_bit.Checked)
            clsDalContract.DCFlag = ClassDALContract.DeviceCancelFlagTypeEnum.DevicecancelOK
            clsDalContract.DCDesc_nvc = cmbDesc_nvc.Text.Trim
            clsDalContract.DCDate_vc = txtDate_vc.Value
            clsDalContract.InsertDeviceCancel()

            'TMSWorking()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Private Sub TMSWorking()
    '    Try
    '        Dim dtSerialInfo As New DataTable
    '        Dim SerialNo As String = txtSerial_vc.Text.Trim
    '        Dim dtTMSTerminal_GetByCityID As New DataTable
    '        Dim dtTMSTerminal_GetBySerailas As New DataTable
    '        Dim dtTMSTerminal_MAXTerminalID As New DataTable
    '        Dim MaxTerminalID As Int64
    '        Dim ProductNo As String
    '        Dim EniacCode As String
    '        Dim CityID As String
    '        Dim pc As New System.Globalization.PersianCalendar

    '        dtSerialInfo = clsDalContract.ForTMS_GetInfoBySerial_SP(SerialNo)
    '        ProductNo = dtSerialInfo.Rows(0).Item("ProductNo_vc")
    '        EniacCode = dtSerialInfo.Rows(0).Item("EniacCode_vc")
    '        CityID = dtSerialInfo.Rows(0).Item("CityID")


    '        clsDALTMS.PARENT_ID = 1
    '        clsDALTMS.REGISTRATION_DATE = Date.Now

    '        dtTMSTerminal_GetBySerailas = clsDalContract.ForTMS_TMSTerminal_GetBySerail("00" + SerialNo)
    '        If dtTMSTerminal_GetBySerailas.Rows.Count > 0 Then
    '            clsDALTMS.TERMINAL_ID = dtTMSTerminal_GetBySerailas.Rows(0).Item("TERMINAL_ID")
    '            clsDalContract.ForTMS_TMSTerminal_Update_ByTerminalID(clsDALTMS.TERMINAL_ID, clsDALTMS.REGISTRATION_DATE, clsDALTMS.PARENT_ID)
    '        Else
    '            dtTMSTerminal_MAXTerminalID = clsDalContract.ForTMS_TMSTerminal_MAXTerminalID()
    '            MaxTerminalID = dtTMSTerminal_MAXTerminalID.Rows(0).Item("MAXTERMINAL_ID")
    '            clsDALTMS.TERMINAL_ID = (MaxTerminalID + 1).ToString
    '            clsDALTMS.SIGNATURE = "00" + SerialNo + ":" + ProductNo
    '            clsDALTMS.NAME = EniacCode
    '            clsDALTMS.TYPE = "U32"
    '            clsDALTMS.STATUS = 0
    '            clsDALTMS.CATEGORY = 1
    '            clsDALTMS.COMMS = vbCrLf
    '            clsDALTMS.DESCRIPTION = "Registered With Query"

    '            clsDalContract.ForTMS_TMSTerminal_Insert3(clsDALTMS.TERMINAL_ID, clsDALTMS.SIGNATURE, clsDALTMS.NAME, clsDALTMS.REGISTRATION_DATE, clsDALTMS.TYPE, clsDALTMS.STATUS, clsDALTMS.CATEGORY, clsDALTMS.DESCRIPTION, clsDALTMS.PARENT_ID, clsDALTMS.COMMS)
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private Sub SaveForDeviceCancelNOK()
        Try
            Try
                clsDalContract.UpdateDevice_OnlyPosID(0, clsDalContract.DCDeviceID, True)
                clsDalContract.DCFlag = ClassDALContract.DeviceCancelFlagTypeEnum.DevicecancelNOK
                clsDalContract.DCDesc_nvc = cmbDesc_nvc.Text.Trim
                clsDalContract.DCDate_vc = txtDate_vc.Value
                clsDalContract.InsertDeviceCancel()
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ClearForm()
        txtDate_vc.Value = GetDateNow()
        cmbDesc_nvc.SelectedIndex = -1
        txtSerial_vc.Text = ""
        chkCanceledVisitorPayment_bit.Checked = False
    End Sub

    Private Sub frmDeviceCancel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ErrorProvider.Clear()
        Me.ClearForm()
        Me.ViewState()
        Me.FillTextBoxes(0, "", "", "", "")
        dgvReport.Focus()
    End Sub
    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvReport.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(Me.dgvReport.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvReport)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim _frm As New frmDeviceCancelEdit
        _frm.ShowDialog()
    End Sub

End Class