Public Class frmInstallingConfirmation
    Private clsDALInstalling As New Dal(modPublicMethod.ConnectionString)
    'Private clsDALTMS As New ClassDALTMS(modPublicMethod.ConnectionString)

    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDALPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private Detial As New Dal.InstallingDetailTemplate
    Private Header As New Dal.InstallingHeaderTemplate
    Private Installer As New Dal.InstallerTemplat
    Private clsDALInstaller As New Dal(modPublicMethod.ConnectionString)
    Private dt As New DataTable
    Private dtReport As New DataTable
    'Public ConfirmationType As ConfirmationTypeEnum
    'Public Enum ConfirmationTypeEnum As Short
    '    General = 1
    '    Detail = 2
    'End Enum


#Region "Events"
    Private Sub btnConfirmOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmOK.Click
        Try
            btnConfirmOKClick()
            Me.FillGrid()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgAddFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnConfirmNOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmNOk.Click
        Try
            'If Me.ConfirmationType = ConfirmationTypeEnum.General Then
            btnConfirmNOkClick()
            Me.FillGrid()
            'ElseIf Me.ConfirmationType = ConfirmationTypeEnum.Detail Then
            'ClearForm()
            'End If
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgAddFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub txtInstallingDetailID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInstallingDetailID.Leave
        Try
            ErrorProvider.Clear()
            If txtInstallingDetailID.Text.Trim = "" Then
                Exit Sub
            End If
            txtInstallingDetailIDLeave()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
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
    Private Sub frmInstallingConfirmation_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub

#End Region
#Region "Methods"
    Private Sub btnConfirmOKClick()
        Try
            ErrorProvider.Clear()
            clsDALInstalling.BeginProc()
            clsDalContract.BeginProc()
            'clsDALTMS.BeginProc()

            If RequiredValidator() = False Then
                Exit Sub
            End If
            If RequiredDBValidator() = False Then
                Exit Sub
            End If
            If CheckInstallingDetailIDSerialValidity() = False Then
                Exit Sub
            End If
            'If Me.ConfirmationType = ConfirmationTypeEnum.Detail Then
            'If RequiredDetailDBValidator() = False Then
            '    Exit Sub
            'End If

            'End If

            ConfirmOK()


            'If Me.ConfirmationType = ConfirmationTypeEnum.Detail Then
            If chkPurchaseReceipt.Checked = False Then
                MessageBox.Show("برگه مورد نظر بدون داشتن فيش خريد تاييد شد", "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            End If
            If chkDasteGardesh.Checked = False Then
                MessageBox.Show("برگه مورد نظر بدون داشتن ارسال دسته گردش تاييد شد", "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            End If

            'End If

            Me.ClearForm()

        Catch ex As Exception
            Throw ex
        Finally
            clsDALInstalling.EndProc()
            clsDalContract.EndProc()
            'clsDALTMS.EndProc()
        End Try
    End Sub
    Private Sub btnConfirmNOkClick()
        Try
            ErrorProvider.Clear()
            clsDALInstalling.BeginProc()
            clsDalContract.BeginProc()
            If RequiredValidator() = False Then
                Exit Sub
            End If
            If RequiredDBValidator() = False Then
                Exit Sub
            End If
            If CheckInstallingDetailIDSerialValidity() = False Then
                Exit Sub
            End If
            ConfirmNOK()

            Me.ClearForm()

        Catch ex As Exception
            Throw ex
        Finally
            clsDALInstalling.EndProc()
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub ClearForm()
        txtInstallingDetailID.Text = ""
        txtSerial_vc.Text = ""
        FillTextBoxes(0, "", 0, 0, "", "", "", "", "")
        Me.ViewStateDetail()
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If txtInstallingDetailID.Text.Trim = "" Then
            ErrorProvider.SetError(txtInstallingDetailID, "کد فرم وارد نشده است")
            res = False
        Else
            ErrorProvider.SetError(txtInstallingDetailID, "")
        End If
        If txtSerial_vc.Text.Trim = "" Then
            ErrorProvider.SetError(txtSerial_vc, "شماره سریال پز وارد نشده است")
            res = False
        Else
            ErrorProvider.SetError(txtSerial_vc, "")
        End If
        'If Me.ConfirmationType = ConfirmationTypeEnum.General Then
        If txtIns_date.Text.Trim = "" Then
            ErrorProvider.SetError(txtIns_date, "تاریخ وارد نشده است")
            res = False
        Else
            ErrorProvider.SetError(txtIns_date, "")
        End If
        'End If

        Return res
    End Function
    Private Function RequiredDBValidator() As Boolean
        Dim res As Boolean = True
        Try
            If CheckInstallingDetailIDValidity() = False Then
                res = False
            End If
            If CheckSerailValidity() = False Then
                res = False
            End If
        Catch ex As Exception
            res = False
            Throw ex
        Finally
            RequiredDBValidator = res
        End Try
    End Function
    Private Function CheckInstallingDetailIDSerialValidity() As Boolean
        Dim res As Boolean = True
        dt.Clear()
        dt = clsDalContract.GetBYDeviceIDContractingParty_Contract_Account_Store_Device_Pos_PURE(clsDalContract.DDeviceID, ClassUserLoginDataAccess.ThisUser.ProjectID)
        If dt.Rows.Count > 0 Then
            clsDALPos.Serial_vc = dt.Rows(0).Item("PSerial_vc")
        Else
            clsDALPos.Serial_vc = ""
        End If

        If clsDALPos.Serial_vc.Trim <> txtSerial_vc.Text Then
            ErrorProvider.SetError(txtInstallingDetailID, "شماره سریال پز مورد نظر، مربوط به قراردادهای فاز جاری نمی باشد")
            ErrorProvider.SetError(txtSerial_vc, "شماره سریال پز مورد نظر، مربوط به قراردادهای فاز جاری نمی باشد")
            res = False
        Else
            ErrorProvider.SetError(txtInstallingDetailID, "")
            ErrorProvider.SetError(txtSerial_vc, "")
            res = True
        End If
        Return res
    End Function
    Private Sub ConfirmOK()
        Try
            Detial.InstallingDetailID = Convert.ToInt64(txtInstallingDetailID.Text.Trim)
            Detial.Ins_date = txtIns_date.Text.ToString
            Detial.Ins_Time = txtIns_Time.Text.Trim
            Detial.Sign = IIf(chkSign.Checked = True, 1, 0)
            Detial.Card = IIf(chkCard.Checked = True, 1, 0)
            Detial.PurchaseReceipt = IIf(chkPurchaseReceipt.Checked = True, 1, 0)
            Detial.StockReceipt = IIf(chkStockReceipt.Checked = True, 1, 0)
            Detial.DasteGardesh = IIf(chkDasteGardesh.Checked = True, 1, 0)
            Detial.Install_OK = 1

            'If Me.ConfirmationType = ConfirmationTypeEnum.General Then
            '    clsDALInstalling.UpdateInstallingDetail1(Detial)
            'ElseIf Me.ConfirmationType = ConfirmationTypeEnum.Detail Then
            '    clsDALInstalling.UpdateInstallingDetail2(Detial)
            'Else
            '    Throw New Exception
            'End If
            clsDALInstalling.UpdateInstallingDetail(Detial)
            'TMSWorking()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ConfirmNOK()
        Try
            Dim Detial As New Dal.InstallingDetailTemplate
            Detial.InstallingDetailID = Convert.ToInt64(txtInstallingDetailID.Text.Trim)
            Detial.Ins_date = ""
            Detial.Ins_Time = ""
            Detial.Sign = 0
            Detial.Card = 0
            Detial.PurchaseReceipt = 0
            Detial.StockReceipt = 0
            Detial.DasteGardesh = 0
            Detial.Install_OK = 0

            clsDALInstalling.UpdateInstallingDetail(Detial)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function CheckInstallingDetailIDValidity() As Boolean
        Dim res As Boolean = True
        Try
            Detial.InstallingDetailID = txtInstallingDetailID.Text.Trim
            dt.Clear()
            dt = clsDALInstalling.GetBYInstallingDetailIDInstallingDetail(Detial.InstallingDetailID)
            If dt.Rows.Count > 0 Then
                ErrorProvider.SetError(txtInstallingDetailID, "")
                Detial.InstallingHeaderID = dt.Rows(0).Item("InstallingHeaderID")
                clsDalContract.DDeviceID = dt.Rows(0).Item("DeviceID")
            Else
                ErrorProvider.SetError(txtInstallingDetailID, "کد فرم نامعتبر می باشد")
                res = False
            End If
            Return res
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function CheckSerailValidity() As Boolean
        Dim res As Boolean = True
        Try
            dt.Clear()
            dt = clsDalContract.GetBySerialDevice_Pos(txtSerial_vc.Text)
            If dt.Rows.Count > 0 Then
                Detial.DeviceID = dt.Rows(0).Item("DDeviceID")

                dt.Clear()
                dt = clsDALInstalling.GetBYDeviceIDInstallingDetail(Detial.DeviceID)
                If dt.Rows.Count > 0 Then
                    Detial.InstallingDetailID = dt.Rows(0).Item("InstallingDetailID")
                    ErrorProvider.SetError(txtSerial_vc, "")
                Else
                    ErrorProvider.SetError(txtSerial_vc, "این شماره سریال در بچ نصب موجود نمی باشد")
                    res = False
                End If
            Else
                ErrorProvider.SetError(txtSerial_vc, "شماره سریال پز نامعتبر می باشد")
                res = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            CheckSerailValidity = res
        End Try

    End Function

    Private Sub txtInstallingDetailIDLeave()
        Try
            clsDalContract.BeginProc()
            clsDALInstalling.BeginProc()
            clsDALInstaller.BeginProc()

            If CheckInstallingDetailIDValidity() = False Then
                Exit Sub
            End If

            dt.Clear()
            dt = clsDalContract.GetBYDeviceIDContractingParty_Contract_Account_Store_Device_Pos_PURE(clsDalContract.DDeviceID, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dt.Rows.Count > 0 Then
                clsDalContract.ContractID = dt.Rows(0).Item("ContractID")
                clsDalContract.FirstName_nvc = dt.Rows(0).Item("FirstName_nvc")
                clsDalContract.LastName_nvc = dt.Rows(0).Item("LastName_nvc")
                clsDalContract.SName_nvc = dt.Rows(0).Item("SName_nvc")
                clsDalContract.DOutlet_vc = dt.Rows(0).Item("DOutlet_vc")
                clsDalContract.DMerchant_vc = dt.Rows(0).Item("DMerchant_vc")
                clsDALPos.Serial_vc = dt.Rows(0).Item("PSerial_vc")
            Else
                clsDalContract.ContractID = 0
                clsDalContract.FirstName_nvc = ""
                clsDalContract.LastName_nvc = ""
                clsDalContract.SName_nvc = ""
                clsDalContract.DOutlet_vc = ""
                clsDalContract.DMerchant_vc = ""
                clsDALPos.Serial_vc = ""
            End If

            dt.Clear()
            dt = clsDALInstalling.GetByDeviceIDInstallingHeaderInstallingDetail(clsDalContract.DDeviceID)
            If dt.Rows.Count > 0 Then
                Detial.InstallingHeaderID = dt.Rows(0).Item("InstallingHeaderID")
                Detial.Ins_date = IIf(IsDBNull(dt.Rows(0).Item("Ins_date")) = True, "", dt.Rows(0).Item("Ins_date"))
                Header.Number_bint = dt.Rows(0).Item("Number_bint")
                Header.InstallerID = dt.Rows(0).Item("InstallerID")
            Else
                Detial.InstallingHeaderID = 0
                Detial.Ins_date = ""
                Header.Number_bint = 0
                Header.InstallerID = 0
            End If

            dt.Clear()
            dt = clsDALInstaller.GetByInstallerIDInstaller(Header.InstallerID)
            If dt.Rows.Count > 0 Then
                Installer.FirstName_nvc = IIf(IsDBNull(dt.Rows(0).Item("FirstName_nvc")) = True, "", dt.Rows(0).Item("FirstName_nvc"))
                Installer.LastName_nvc = IIf(IsDBNull(dt.Rows(0).Item("LastName_nvc")) = True, "", dt.Rows(0).Item("LastName_nvc"))
            Else
                Installer.FirstName_nvc = ""
                Installer.LastName_nvc = ""
            End If

            txtSerial_vc.Text = clsDALPos.Serial_vc
            FillTextBoxes(clsDalContract.ContractID, clsDalContract.DOutlet_vc, Header.Number_bint, Detial.InstallingHeaderID, clsDalContract.FirstName_nvc + " " + clsDalContract.LastName_nvc, clsDalContract.SName_nvc, Installer.FirstName_nvc + " " + Installer.LastName_nvc, Detial.Ins_date, clsDalContract.DMerchant_vc)
            'If Me.ConfirmationType = ConfirmationTypeEnum.Detail Then
            '    If RequiredDetailDBValidator() = False Then
            '        Exit Sub
            '    End If
            'End If
            FillDetailTextBoxes()

            EditStateDetail()
            'If Me.ConfirmationType = ConfirmationTypeEnum.General Then
            '    EditStateDetail1()
            'ElseIf Me.ConfirmationType = ConfirmationTypeEnum.Detail Then
            '    EditStateDetail2()
            'Else
            '    EditStateDetail1()
            'End If
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
            clsDALInstalling.EndProc()
            clsDALInstaller.EndProc()
        End Try
    End Sub
    Private Sub txtSerial_vcLeave()
        Dim dt As New DataTable
        Try
            If CheckSerailValidity() = False Then
                txtInstallingDetailID.Text = ""
                Exit Sub
            End If

            txtInstallingDetailID.Text = Detial.InstallingDetailID

            dt.Clear()
            dt = clsDalContract.GetBYDeviceIDContractingParty_Contract_Account_Store_Device_Pos_PURE(Detial.DeviceID, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dt.Rows.Count > 0 Then
                clsDalContract.ContractID = dt.Rows(0).Item("ContractID")
                clsDalContract.FirstName_nvc = dt.Rows(0).Item("FirstName_nvc")
                clsDalContract.LastName_nvc = dt.Rows(0).Item("LastName_nvc")
                clsDalContract.SName_nvc = dt.Rows(0).Item("SName_nvc")
                clsDalContract.DOutlet_vc = dt.Rows(0).Item("DOutlet_vc")
            Else
                clsDalContract.ContractID = 0
                clsDalContract.FirstName_nvc = ""
                clsDalContract.LastName_nvc = ""
                clsDalContract.SName_nvc = ""
                clsDalContract.DOutlet_vc = ""
            End If

            dt.Clear()
            dt = clsDALInstalling.GetByDeviceIDInstallingHeaderInstallingDetail(Detial.DeviceID)
            If dt.Rows.Count > 0 Then
                Detial.InstallingHeaderID = dt.Rows(0).Item("InstallingHeaderID")
                Detial.Ins_date = IIf(IsDBNull(dt.Rows(0).Item("Ins_date")) = True, "", dt.Rows(0).Item("Ins_date"))
                Header.Number_bint = dt.Rows(0).Item("Number_bint")
                Header.InstallerID = dt.Rows(0).Item("InstallerID")
            Else
                Detial.InstallingHeaderID = 0
                Detial.Ins_date = ""
                Header.Number_bint = 0
                Header.InstallerID = 0
            End If

            dt.Clear()
            dt = clsDALInstaller.GetByInstallerIDInstaller(Header.InstallerID)
            If dt.Rows.Count > 0 Then
                Installer.FirstName_nvc = IIf(IsDBNull(dt.Rows(0).Item("FirstName_nvc")) = True, "", dt.Rows(0).Item("FirstName_nvc"))
                Installer.LastName_nvc = IIf(IsDBNull(dt.Rows(0).Item("LastName_nvc")) = True, "", dt.Rows(0).Item("LastName_nvc"))
            Else
                Installer.FirstName_nvc = ""
                Installer.LastName_nvc = ""
            End If

            FillTextBoxes(clsDalContract.ContractID, clsDalContract.DOutlet_vc, Header.Number_bint, Detial.InstallingHeaderID, clsDalContract.FirstName_nvc + " " + clsDalContract.LastName_nvc, clsDalContract.SName_nvc, Installer.FirstName_nvc + " " + Installer.LastName_nvc, Detial.Ins_date, clsDalContract.Merchant_vc)
            'If Me.ConfirmationType = ConfirmationTypeEnum.Detail Then
            '    If RequiredDetailDBValidator() = False Then
            '        Exit Sub
            '    End If
            'End If


            FillDetailTextBoxes()

            'If Me.ConfirmationType = ConfirmationTypeEnum.General Then
            '    EditStateDetail1()
            'ElseIf Me.ConfirmationType = ConfirmationTypeEnum.Detail Then
            '    EditStateDetail2()
            'Else
            '    EditStateDetail1()
            'End If

            EditStateDetail()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillTextBoxes(ByVal ContractID As Int64, ByVal Outlet_vc As String, ByVal InstallingHeaderNumber_bint As Int64, ByVal InstallingHeaderID As Int64, ByVal ContarctingPartyName_nvc As String, ByVal StoreName_nvc As String, ByVal InstallerName_nvc As String, ByVal Ins_date2 As String, ByVal Merchant_vc As String)
        txtInstallingHeaderID.Text = IIf(InstallingHeaderID = 0, "", InstallingHeaderID.ToString)
        txtContractID.Text = IIf(ContractID = 0, "", ContractID.ToString)
        txtOutlet_vc.Text = Outlet_vc
        txtMerchant_vc.Text = Merchant_vc
        txtInstallingHeaderNumber_bint.Text = IIf(InstallingHeaderNumber_bint = 0, "", InstallingHeaderNumber_bint.ToString)

        txtContarctingPartyName_nvc.Text = ContarctingPartyName_nvc
        txtStoreName_nvc.Text = StoreName_nvc
        txtInstallerName_nvc.Text = InstallerName_nvc
        txtIns_date2.Text = Ins_date2
    End Sub
    '=========Detail==================
    Private Sub FillDetailTextBoxes()
        Try
            Dim dt As New DataTable
            dt = GetDetail()
            txtIns_date.Text = IIf(IsDBNull(dt.Rows(0).Item("Ins_date")) = True, "", dt.Rows(0).Item("Ins_date"))
            txtIns_Time.Text = IIf(IsDBNull(dt.Rows(0).Item("Ins_Time")) = True, "", dt.Rows(0).Item("Ins_Time"))
            chkSign.Checked = IIf(dt.Rows(0).Item("Sign") = 1, True, False)
            chkCard.Checked = IIf(dt.Rows(0).Item("Card") = 1, True, False)
            chkPurchaseReceipt.Checked = IIf(dt.Rows(0).Item("PurchaseReceipt") = 1, True, False)
            chkStockReceipt.Checked = IIf(dt.Rows(0).Item("StockReceipt") = 1, True, False)
            chkDasteGardesh.Checked = IIf(dt.Rows(0).Item("DasteGardesh") = 1, True, False)

        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgAddFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    'Private Function RequiredDetailDBValidator() As Boolean
    '    Dim res As Boolean = True
    '    Dim Detial As New Dal.InstallingDetailTemplate
    '    Detial.InstallingDetailID = txtInstallingDetailID.Text.Trim
    '    dt = clsDALInstalling.GetBYInstallingDetailIDInstallingDetail(Detial.InstallingDetailID)
    '    If dt.Rows.Count > 0 Then
    '        'If dt.Rows(0).Item("Install_OK") = 1 Then
    '        ErrorProvider.SetError(txtInstallingDetailID, "")
    '        res = True
    '        'else
    '        '    ErrorProvider.SetError(txtInstallingDetailID, "تایید نصب کد فرم مورد نظر انجام نشده است")
    '        '    res = False
    '        'End If
    '    Else
    '        ErrorProvider.SetError(txtInstallingDetailID, "کد فرم مورد نظر نامعتبر می باشد")
    '        res = False
    '    End If
    '    Return res
    'End Function
    Private Function GetDetail() As DataTable
        Try
            Dim Detial As New Dal.InstallingDetailTemplate
            Detial.InstallingDetailID = txtInstallingDetailID.Text.Trim
            dt = clsDALInstalling.GetBYInstallingDetailIDInstallingDetail(Detial.InstallingDetailID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub ViewStateDetail()
        txtInstallingDetailID.Text = ""
        txtInstallingDetailID.Focus()
        grpDetail1.Enabled = False
        grpDetail2.Enabled = False
        txtIns_date.Text = ""
        txtIns_Time.Text = ""
        chkCard.Checked = False
        chkPurchaseReceipt.Checked = False
        chkSign.Checked = False
        chkStockReceipt.Checked = False
        chkDasteGardesh.Checked = False
    End Sub
    'Private Sub EditStateDetail1()
    '    grpDetail1.Enabled = True
    '    grpDetail2.Enabled = False
    'End Sub
    'Private Sub EditStateDetail2()
    '    grpDetail2.Enabled = True
    '    grpDetail1.Enabled = False
    'End Sub
    Private Sub EditStateDetail()
        grpDetail1.Enabled = True
        grpDetail2.Enabled = True
    End Sub
#End Region
    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvReport.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(Me.dgvReport.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub
    Private Sub frmInstallingConfirmation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            'If Me.ConfirmationType = ConfirmationTypeEnum.General Then
            'Me.Text = "تایید نصب"
            'btnConfirmOK.Text = "تایید نصب"
            'btnConfirmNOk.Text = "عدم تایید نصب"
            'ElseIf Me.ConfirmationType = ConfirmationTypeEnum.Detail Then
            '    Me.Text = "ورود اطلاعات نصب"
            '    btnConfirmOK.Text = "ثبت"
            '    btnConfirmNOk.Text = "انصراف"
            'End If
            FillGrid()

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            dtReport.Clear()
            dtReport = clsDalContract.GetByInstallOKStroe_Device_InstallingHeader_InstallingDetail(1, ClassUserLoginDataAccess.ThisUser.ProjectID)
            dgvReport.DataSource = dtReport
            dgvReport.Columns("InstallingDetailID").HeaderText = "کد فرم"
            dgvReport.Columns("Ins_date").HeaderText = "تاریخ نصب"
            dgvReport.Columns("SName_nvc").HeaderText = "نام فروشگاه"
            dgvReport.Columns("SAddress_nvc").HeaderText = "آدرس فروشگاه"
            dgvReport.Columns("SMunicipalAreaNO_sint").HeaderText = "منطقه"
            dgvReport.Columns("DOutlet_vc").HeaderText = "Outlet"
            dgvReport.Columns("DMerchant_vc").HeaderText = "Merchant"
            dgvReport.Columns("PSerial_vc").HeaderText = "سریال دستگاه"
            dgvReport.Columns("IFullName_nvc").HeaderText = "نام نصاب"
            dgvReport.Columns("DCode_vc").HeaderText = "PosCode"
            dgvReport.Columns("ContractID").HeaderText = "کد قرارداد"
            dgvReport.Columns("SStateName_nvc").HeaderText = "استان"
            dgvReport.Columns("SCityName_nvc").HeaderText = "شهر"
            dgvReport.Columns("VisitorLastName_nvc").HeaderText = " نام بازاریاب"


            dgvReport.Columns("SName_nvc").Width = 150
            dgvReport.Columns("SAddress_nvc").Width = 250
            dgvReport.Columns("PSerial_vc").Width = 150
            dgvReport.Columns("IFullName_nvc").Width = 160
        Catch ex As Exception
            Throw ex
        End Try

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

    '        dtSerialInfo = clsDALInstalling.ForTMS_GetInfoBySerial_SP(SerialNo)
    '        ProductNo = dtSerialInfo.Rows(0).Item("ProductNo_vc")
    '        EniacCode = dtSerialInfo.Rows(0).Item("EniacCode_vc")
    '        CityID = dtSerialInfo.Rows(0).Item("CityID")

    '        dtTMSTerminal_GetByCityID = clsDALInstalling.ForTMS_TMSTerminal_GetByCityID(CityID)
    '        clsDALTMS.PARENT_ID = dtTMSTerminal_GetByCityID.Rows(0).Item("TERMINAL_ID")

    '        dtTMSTerminal_GetBySerailas = clsDALInstalling.ForTMS_TMSTerminal_GetBySerail("00" + SerialNo)
    '        If dtTMSTerminal_GetBySerailas.Rows.Count > 0 Then
    '            clsDALTMS.TERMINAL_ID = dtTMSTerminal_GetBySerailas.Rows(0).Item("TERMINAL_ID")
    '            'clsDALInstalling.ForTMS_TMSTerminal_Update_ByTerminalID(clsDALTMS.TERMINAL_ID, clsDALTMS.REGISTRATION_DATE, clsDALTMS.PARENT_ID)
    '            Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    '            Dim da As New OracleDataAdapter
    '            Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    '            Dim prmTerminalID As New OracleParameter
    '            Dim prmPARENT_ID As New OracleParameter

    '            Dim TMSTransaction As OracleTransaction

    '            If cnt.State <> ConnectionState.Open Then
    '                cnt.ConnectionString = modPublicMethod.ConnectionString
    '                cnt.Open()
    '            Else
    '               
    '            End If

    '            With prmTerminalID
    '                .DbType = OracleDbType.Varchar2
    '                .Value = (MaxTerminalID + 1).ToString
    '                .ParameterName = "@TERMINAL_ID"
    '            End With

    '            With prmPARENT_ID
    '                .DbType = OracleDbType.Varchar2
    '                .Value = dtTMSTerminal_GetByCityID.Rows(0).Item("TERMINAL_ID")
    '                .ParameterName = "@PARENT_ID"
    '            End With

    '            With cmd
    '                .Connection = cnt
    '                .CommandType = CommandType.StoredProcedure
    '                .Parameters.Clear()
    '                .Parameters.Add(prmTerminalID)
    '                .Parameters.Add(prmPARENT_ID)

    '                .CommandText = "ForTMS_TMSTerminal_Update_ByTerminalID"
    '                Try
    '                    TMSTransaction = cnt.BeginTransaction()
    '                    .ExecuteNonQuery()
    '                    TMSTransaction.Commit()
    '                Catch ex As Exception
    '                    TMSTransaction.Rollback()
    '                End Try
    '            End With
    '        Else
    '            dtTMSTerminal_MAXTerminalID = clsDALInstalling.ForTMS_TMSTerminal_MAXTerminalID()
    '            MaxTerminalID = dtTMSTerminal_MAXTerminalID.Rows(0).Item("MAXTERMINAL_ID")
    '            clsDALTMS.TERMINAL_ID = (MaxTerminalID + 1).ToString
    '            clsDALTMS.SIGNATURE = "00" + SerialNo + ":" + ProductNo
    '            clsDALTMS.NAME = EniacCode
    '            clsDALTMS.TYPE = "U32"
    '            clsDALTMS.STATUS = 0
    '            clsDALTMS.CATEGORY = 1
    '            clsDALTMS.COMMS = vbCrLf
    '            clsDALTMS.DESCRIPTION = "Registered With Query"
    '            clsDALTMS.REGISTRATION_DATE = pc.ToDateTime(txtIns_date.Text.Substring(0, 4), txtIns_date.Text.Substring(5, 2), txtIns_date.Text.Substring(8, 2), 0, 0, 0, 0, 0)

    '            'clsDALInstalling.ForTMS_TMSTerminal_Insert3(clsDALTMS.TERMINAL_ID, clsDALTMS.SIGNATURE, clsDALTMS.NAME, clsDALTMS.REGISTRATION_DATE, clsDALTMS.TYPE, clsDALTMS.STATUS, clsDALTMS.CATEGORY, clsDALTMS.DESCRIPTION, clsDALTMS.PARENT_ID, clsDALTMS.COMMS)
    '            Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    '            Dim da As New OracleDataAdapter
    '            Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    '            Dim prmTerminalID As New OracleParameter
    '            Dim prmSIGNATURE As New OracleParameter
    '            Dim prmNAME As New OracleParameter
    '            Dim prmREGISTRATION_DATE As New OracleParameter
    '            Dim prmTYPE As New OracleParameter
    '            Dim prmSTATUS As New OracleParameter
    '            Dim prmCATEGORY As New OracleParameter
    '            Dim prmCOMMS As New OracleParameter
    '            Dim prmDESCRIPTION As New OracleParameter
    '            Dim prmPARENT_ID As New OracleParameter
    '            Dim TMSTransaction As OracleTransaction

    '            If cnt.State <> ConnectionState.Open Then
    '                cnt.ConnectionString = modPublicMethod.ConnectionString
    '                cnt.Open()
    '            Else
    '               
    '            End If



    '            With prmTerminalID
    '                .DbType = OracleDbType.Varchar2
    '                .Value = clsDALTMS.TERMINAL_ID
    '                .ParameterName = "@TERMINAL_ID"
    '            End With
    '            With prmSIGNATURE
    '                .DbType = OracleDbType.Varchar2
    '                .Value = clsDALTMS.SIGNATURE
    '                .ParameterName = "@SIGNATURE"
    '            End With

    '            With prmNAME
    '                .DbType = OracleDbType.Varchar2
    '                .Value = clsDALTMS.NAME
    '                .ParameterName = "@NAME"
    '            End With

    '            With prmREGISTRATION_DATE
    '                .DbType = SqlDbType.DateTime
    '                .Value = clsDALTMS.REGISTRATION_DATE ' pc.ToDateTime(txtIns_date.Text.Substring(0, 4), txtIns_date.Text.Substring(5, 2), txtIns_date.Text.Substring(8, 2), 0, 0, 0, 0, 0)
    '                ' Date.Now
    '                .ParameterName = "@REGISTRATION_DATE"
    '            End With

    '            With prmTYPE
    '                .DbType = OracleDbType.Varchar2
    '                .Value = clsDALTMS.TYPE
    '                .ParameterName = "@TYPE"
    '            End With

    '            With prmSTATUS
    '                .DbType = OracleDbType.Int32
    '                .Value = clsDALTMS.STATUS
    '                .ParameterName = "@STATUS"
    '            End With

    '            With prmCATEGORY
    '                .DbType = OracleDbType.Int32
    '                .Value = clsDALTMS.CATEGORY
    '                .ParameterName = "@CATEGORY"
    '            End With

    '            With prmDESCRIPTION
    '                .DbType = OracleDbType.Varchar2
    '                .Value = clsDALTMS.DESCRIPTION
    '                .ParameterName = "@DESCRIPTION"
    '            End With

    '            With prmPARENT_ID
    '                .DbType = OracleDbType.Varchar2
    '                .Value = clsDALTMS.PARENT_ID
    '                .ParameterName = "@PARENT_ID"
    '            End With

    '            With prmCOMMS
    '                .DbType = OracleDbType.Varchar2
    '                .Value = clsDALTMS.COMMS
    '                .ParameterName = "@COMMS"
    '            End With


    '            With cmd
    '                .Connection = cnt
    '                .CommandType = CommandType.StoredProcedure
    '                .Parameters.Clear()
    '                .Parameters.Add(prmTerminalID)
    '                .Parameters.Add(prmREGISTRATION_DATE)
    '                .Parameters.Add(prmPARENT_ID)

    '                .CommandText = "ForTMS_TMSTerminal_Insert3"
    '                Try
    '                    TMSTransaction = cnt.BeginTransaction()
    '                    .ExecuteNonQuery()
    '                    TMSTransaction.Commit()
    '                Catch ex As Exception
    '                    TMSTransaction.Rollback()
    '                End Try
    '            End With

    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    
End Class