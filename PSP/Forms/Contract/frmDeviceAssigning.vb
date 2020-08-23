Public Class frmDeviceAssigning
#Region "Variable Definitions"
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private clsDalPosVisitor As New ClassDALPosVisitor(modPublicMethod.ConnectionString)
    Private clsDalCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private dtAssignablePos As New DataTable
    Private dvAssignablePos As DataView

    Private dtAssigningPos As New DataTable
    Private PSP As String = "5"
#End Region

#Region "Events"

#Region "Form"

    Private Sub frmDeviceAssigning_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            frmMain.SetFavorite()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub frmDeviceAssigning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            dgvAssignablePos.AutoGenerateColumns = False
            SetdgvAssignablePos()
            Me.FormLoad()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

    Private Sub frmDeviceAssigning_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub

#End Region

#Region "Button"
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignRefresh.Click
        Try
            Me.RefreshdgvAssignablePos()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignNew.Click
        Try
            Add()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnRePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignReprint.Click
        Dim _frmDeviceAssigningReprint As New frmDeviceAssigningReprint
        _frmDeviceAssigningReprint.ShowDialog()
    End Sub

#End Region

#Region "TextBox"
    Private Sub txtSerial_vc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial_vc.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSerial_vcKeyDown()
        End If
    End Sub
#End Region

#Region "Print"
    Private Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
        ClassPrintLabel(Of ClassDALContract).Print(e, clsDalContract)
    End Sub
#End Region

#End Region

#Region "Methods"

#Region "Form"

    Private Sub FormLoad()
        Try
            modPublicMethod.ErrorProviderClear(ErrorProvider)
            FillCombo()
            Me.FilldgvAssignablePos()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Grid"
    Private Sub FilldgvAssignablePos()
        Try
            dtAssignablePos = Me.clsDalContract.GetAllContractingParty_Contract_Store_AssignablePos(MarketingByUC1.cboMarketingByID.SelectedValue, ClassUserLoginDataAccess.ThisUser.ProjectID, cmbProject.SelectedValue)
            dvAssignablePos = dtAssignablePos.DefaultView
            dgvAssignablePos.DataSource = dvAssignablePos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetdgvAssignablePos()
        'Me.dgvAssignablePos.AutoGenerateColumns = False

        Dim colContractID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractID.DataPropertyName = "ContractID"
        colContractID.HeaderText = "کد قرارداد"
        colContractID.Name = "colContractID"
        colContractID.ReadOnly = True
        colContractID.Width = 100
        Me.dgvAssignablePos.Columns.Add(colContractID)


        Dim colFirstName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFirstName_nvc.DataPropertyName = "FirstName_nvc"
        colFirstName_nvc.HeaderText = "نام"
        colFirstName_nvc.Name = "colFirstName_nvc"
        colFirstName_nvc.ReadOnly = True
        colFirstName_nvc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colFirstName_nvc)


        Dim colLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colLastName_nvc.DataPropertyName = "LastName_nvc"
        colLastName_nvc.HeaderText = "نام خانوادگی"
        colLastName_nvc.Name = "colLastName_nvc"
        colLastName_nvc.ReadOnly = True
        colLastName_nvc.Width = 150
        Me.dgvAssignablePos.Columns.Add(colLastName_nvc)


        Dim colNationalCode_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colNationalCode_nvc.DataPropertyName = "NationalCode_nvc"
        colNationalCode_nvc.HeaderText = "کد ملی"
        colNationalCode_nvc.Name = "colNationalCode_nvc"
        colNationalCode_nvc.ReadOnly = True
        colNationalCode_nvc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colNationalCode_nvc)

        Dim colSName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSName_nvc.DataPropertyName = "SName_nvc"
        colSName_nvc.HeaderText = "نام فروشگاه"
        colSName_nvc.Name = "colSName_nvc"
        colSName_nvc.ReadOnly = True
        colSName_nvc.Width = 120
        Me.dgvAssignablePos.Columns.Add(colSName_nvc)

        Dim colSCityName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSCityName_nvc.DataPropertyName = "SCityName_nvc"
        colSCityName_nvc.HeaderText = "شهر"
        colSCityName_nvc.Name = "colSCityName_nvc"
        colSCityName_nvc.ReadOnly = True
        colSCityName_nvc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colSCityName_nvc)

        Dim colVisitorName As New System.Windows.Forms.DataGridViewTextBoxColumn
        colVisitorName.DataPropertyName = "VisitorName"
        colVisitorName.HeaderText = "بازاریاب"
        colVisitorName.Name = "colVisitorName"
        colVisitorName.ReadOnly = True
        colVisitorName.Width = 100
        Me.dgvAssignablePos.Columns.Add(colVisitorName)

        Dim colSAddress_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSAddress_nvc.DataPropertyName = "SAddress_nvc"
        colSAddress_nvc.HeaderText = "آدرس"
        colSAddress_nvc.Name = "colSAddress_nvc"
        colSAddress_nvc.ReadOnly = True
        colSAddress_nvc.Width = 300
        Me.dgvAssignablePos.Columns.Add(colSAddress_nvc)

        Dim colAAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountNO_vc.DataPropertyName = "AAccountNO_vc"
        colAAccountNO_vc.HeaderText = "شماره حساب"
        colAAccountNO_vc.Name = "colAAccountNO_vc"
        colAAccountNO_vc.ReadOnly = True
        colAAccountNO_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colAAccountNO_vc)

        Dim colACardNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colACardNo_vc.DataPropertyName = "ACardNo_vc"
        colACardNo_vc.HeaderText = "شماره کارت"
        colACardNo_vc.Name = "colACardNo_vc"
        colACardNo_vc.ReadOnly = True
        colACardNo_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colACardNo_vc)

        Dim colSDeviceCount_tint As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSDeviceCount_tint.DataPropertyName = "SDeviceCount_tint"
        colSDeviceCount_tint.HeaderText = "تعداد پز"
        colSDeviceCount_tint.Name = "colSDeviceCount_tint"
        colSDeviceCount_tint.ReadOnly = True
        colSDeviceCount_tint.Width = 100
        Me.dgvAssignablePos.Columns.Add(colSDeviceCount_tint)

        Dim colMarketingByID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colMarketingByID.DataPropertyName = "MarketingByID"
        colMarketingByID.Visible = False
        colMarketingByID.Name = "colMarketingByID"
        colMarketingByID.ReadOnly = True
        colMarketingByID.Width = 100
        Me.dgvAssignablePos.Columns.Add(colMarketingByID)


        Dim colMarketingByName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colMarketingByName_nvc.DataPropertyName = "MarketingByName_nvc"
        colMarketingByName_nvc.HeaderText = "بازاریابی توسط"
        colMarketingByName_nvc.Name = "colMarketingByName_nvc"
        colMarketingByName_nvc.ReadOnly = True
        colMarketingByName_nvc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colMarketingByName_nvc)

        Dim colcmsprojects As New System.Windows.Forms.DataGridViewTextBoxColumn
        colcmsprojects.DataPropertyName = "cmsprojects"
        colcmsprojects.HeaderText = "پروژه های CMS"
        colcmsprojects.Name = "colcmsprojects"
        colcmsprojects.ReadOnly = True
        colcmsprojects.Width = 150
        Me.dgvAssignablePos.Columns.Add(colcmsprojects)


    End Sub

    Private Sub RefreshdgvAssignablePos()
        Try
            modPublicMethod.ErrorProviderClear(ErrorProvider)
            Me.FilldgvAssignablePos()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "TextBox"

    Private Sub txtSerial_vcKeyDown()
        Try
            clsDalPos.BeginProc()
            clsDalContract.BeginProc()
            clsDalCity.BeginProc()
            Save()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        Finally
            clsDalContract.EndProc()
            clsDalPos.EndProc()
            clsDalCity.EndProc()
        End Try
    End Sub

    Private Sub FillPosTextBoxes()
        txtPosID.Text = clsDalPos.PosID
        txtPropertyNo_vc.Text = clsDalPos.PropertyNo_vc
        txtEniacCode_vc.Text = clsDalPos.EniacCode_vc
    End Sub

    Private Sub EmptyTextBoxes()
        txtContractID.Text = ""
        txtSerial_vc.Text = ""
        txtPosID.Text = ""
        txtEniacCode_vc.Text = ""
        txtPropertyNo_vc.Text = ""
        txtContractID.Focus()

    End Sub

    Private Function IsBackToBackSerialValidator() As Boolean
        'txtSerial_vc
        clsDalPos.Serial_vc = txtSerial_vc.Text
        If clsDalPos.IsB2BbySerial() = True Then
            ShowErrorMessage("را نمی توان تخصیص داد BackToBack پزهای")
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CanVisitorAssignPosToContract() As Boolean
        If clsDalContract.CanVisitorAssignPosToContract(Convert.ToInt64(txtContractID.Text), txtSerial_vc.Text) = False Then
            ShowErrorMessage("بازاریاب قرارداد انتخاب شده با بازاریاب پز تخصیص داده شده مغایرت دارد")
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "Checking"

    Public Function SerialDBRequiredValidator() As Boolean
        Dim res As Boolean = True
        If SerialValidate() = False Then
            ErrorProvider.SetError(txtSerial_vc, "سریال وارد شده در سیستم موجود نمی باشد")
            res = False
        Else
            If clsDalPos.Active_Tint <> 1 Then
                ErrorProvider.SetError(txtSerial_vc, "سریال وارد شده فعال نمی باشد")
                res = False
            Else
                If clsDalPos.PosTypeID = 2 Then 'دستگاه پشتيبان
                    ErrorProvider.SetError(txtSerial_vc, "سریال وارد شده جزو دستگاههاي پشتيبان مي باشد")
                    res = False
                Else
                    ErrorProvider.SetError(txtSerial_vc, "")
                End If
            End If
        End If
        Return res
    End Function

    Private Function SerialValidate() As Boolean
        Try
            SerialValidate = False
            Dim dt As New DataTable

            clsDalPos.Serial_vc = txtSerial_vc.Text
            dt = clsDalPos.GetBySerialPos()
            If dt.Rows.Count > 0 Then
                SerialValidate = True
                clsDalPos.PosID = dt.Rows(0).Item("PosID")
                clsDalPos.PropertyNo_vc = dt.Rows(0).Item("PropertyNo_vc")
                clsDalPos.EniacCode_vc = dt.Rows(0).Item("EniacCode_vc")
                clsDalPos.Active_Tint = dt.Rows(0).Item("Active_tint")
                clsDalPos.PosTypeID = dt.Rows(0).Item("PosTypeID")
                FillPosTextBoxes()
            Else
                SerialValidate = False
                clsDalPos.PosID = -1
                clsDalPos.PropertyNo_vc = ""
                clsDalPos.EniacCode_vc = ""
                clsDalPos.Active_Tint = -1
                clsDalPos.PosTypeID = -1
                FillPosTextBoxes()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function SaveRequiredValidator() As Boolean
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

    Private Function SaveDBRequiredValidator() As Boolean
        Dim res As Boolean = True
        Dim dtRepeated As New DataTable

        'clsDalContract.DPPosID = Convert.ToInt64(txtPosID.Text.Trim)
        'dtRepeated = clsDalContract.GetByPosIDDevicePos_Device_PosAssigning

        clsDalContract.DPosID = Convert.ToInt64(txtPosID.Text.Trim)
        dtRepeated = clsDalContract.GetByPosIDDevice(clsDalContract.DPosID)
        If dtRepeated.Rows.Count > 0 Then
            Me.ErrorProvider.SetError(Me.txtSerial_vc, "این شماره سریال پز قبلا تخصیص یافته است")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtSerial_vc, "")
            clsDalContract.DPPosID = Convert.ToInt64(txtPosID.Text.Trim)
            clsDalContract.DPIOTypeID = ClassDALIOType.IOTypeEnum.InStore
        End If

        dtRepeated.Clear()
        clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
        dtRepeated = clsDalContract.GetByGetByContractIDContractingParty_Contract_Store_AssignablePos(Convert.ToInt64(txtContractID.Text.Trim), MarketingByUC1.cboMarketingByID.SelectedValue, ClassUserLoginDataAccess.ThisUser.ProjectID)

        If dtRepeated.Rows.Count = 0 Then
            Me.ErrorProvider.SetError(Me.txtContractID, "این کد قرارداد در لیست موجود نمی باشد")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtContractID, "")
            clsDalContract.SStoreID = dtRepeated.Rows(0).Item("SStoreID")
            clsDalContract.DPassword_vc = ""
            clsDalContract.SName_nvc = dtRepeated.Rows(0).Item("SName_nvc")
            clsDalContract.FirstName_nvc = dtRepeated.Rows(0).Item("FirstName_nvc")
            clsDalContract.LastName_nvc = dtRepeated.Rows(0).Item("LastName_nvc")
            clsDalContract.SCityID = dtRepeated.Rows(0).Item("SCityID")
            SetCodes(dtRepeated)
        End If
        Return res
    End Function

    Private Function LastStatusIsApprovedByVisitor() As Boolean
        clsDalPosVisitor.BeginProc()
        Try
            If clsDalPosVisitor.LastStatusIsApprovedByVisitor(txtSerial_vc.Text) = 0 Then
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

#End Region

#Region "Save"
    Private Sub Save()
        Dim dt As New DataTable

        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Try

            If SaveRequiredValidator() = False Then
                Exit Sub
            End If
            If SerialDBRequiredValidator() = False Then
                Exit Sub
            End If
            If IsBackToBackSerialValidator() = False Then
                Exit Sub
            End If
            If CanVisitorAssignPosToContract() = False Then
                Exit Sub
            End If
            If LastStatusIsApprovedByVisitor() = False Then
                Exit Sub
            End If
            If SaveDBRequiredValidator() = False Then
                Exit Sub
            End If

            clsDalContract.BeginProc()
            clsDalCity.BeginProc()

            clsDalCity.CityID = clsDalContract.SCityID
            dt = clsDalCity.GetByID()
            If dt.Rows.Count > 0 Then
                clsDalContract.SCityname_nvc = dt.Rows(0).Item("Name_nvc")
            Else
                clsDalContract.SCityname_nvc = ""
            End If

            Me.PosAssign()

            txtMerchant.Text = clsDalContract.DMerchant_vc
            txtVat.Text = clsDalContract.DVat_vc
            txtoutlet.Text = clsDalContract.DOutlet_vc
            txtCode.Text = clsDalContract.DCode_vc
            Me.clsDalCity.EndProc()
            Me.clsDalContract.EndProc()
        Catch ex As Exception
            'ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            'ClassError.LogError(ex)
            Throw ex 'Exit Sub
        End Try
        Try
            clsDalContract.BeginProc()

            clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
            Me.Add()
            Me.PrintLabel()
            Me.clsDalContract.EndProc()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgPrintFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    'Private Sub InserUpdateCodes_Counter()
    '    'Try
    '    '    Dim dtCodes_Counter As New DataTable

    '    '    dtCodes_Counter.Clear()
    '    '    dtCodes_Counter = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(clsDalContract.DMerchant_vc.Substring(0, 8), "M")
    '    '    If dtCodes_Counter.Rows.Count = 0 Then
    '    '        clsDalContract.InsertCodes_Counter("M", clsDalContract.DMerchant_vc.Substring(0, 8), clsDalContract.DMerchant_vc.Substring(8, 4))
    '    '    Else
    '    '        clsDalContract.UpdateCodes_CounterForLastCounter(clsDalContract.DMerchant_vc.Substring(8, 4), dtCodes_Counter.Rows(0).Item("ID"))
    '    '    End If

    '    '    dtCodes_Counter.Clear()
    '    '    dtCodes_Counter = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(clsDalContract.DVat_vc.Substring(0, 11), "V")
    '    '    If dtCodes_Counter.Rows.Count = 0 Then
    '    '        clsDalContract.InsertCodes_Counter("V", clsDalContract.DVat_vc.Substring(0, 11), clsDalContract.DVat_vc.Substring(11, 4))
    '    '    Else
    '    '        clsDalContract.UpdateCodes_CounterForLastCounter(clsDalContract.DVat_vc.Substring(11, 4), dtCodes_Counter.Rows(0).Item("ID"))
    '    '    End If

    '    '    dtCodes_Counter.Clear()
    '    '    dtCodes_Counter = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(clsDalContract.DOutlet_vc.Substring(0, 7), "O")
    '    '    If dtCodes_Counter.Rows.Count = 0 Then
    '    '        clsDalContract.InsertCodes_Counter("O", clsDalContract.DOutlet_vc.Substring(0, 7), clsDalContract.DOutlet_vc.Substring(7, 5))
    '    '    Else
    '    '        clsDalContract.UpdateCodes_CounterForLastCounter(clsDalContract.DOutlet_vc.Substring(7, 5), dtCodes_Counter.Rows(0).Item("ID"))
    '    '    End If

    '    '    dtCodes_Counter.Clear()
    '    '    dtCodes_Counter = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(clsDalContract.DCode_vc.Substring(0, 3), "C")
    '    '    If dtCodes_Counter.Rows.Count = 0 Then
    '    '        clsDalContract.InsertCodes_Counter("C", clsDalContract.DCode_vc.Substring(0, 3), clsDalContract.DCode_vc.Substring(3, 5))
    '    '    Else
    '    '        clsDalContract.UpdateCodes_CounterForLastCounter(clsDalContract.DCode_vc.Substring(3, 5), dtCodes_Counter.Rows(0).Item("ID"))
    '    '    End If
    '    'Catch ex As Exception
    '    '    Throw ex
    '    'End Try

    'End Sub
    Private Sub PosAssign()
        Try
            Me.SaveDevice()
            Me.SaveDevicePos()
            Me.UpdateDeviceForOnlyPosID()

            Me.UpdateContractImportDeviceID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveDevice()
        Try
            clsDalContract.DPDeviceID = clsDalContract.InsertDevice()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveDevicePos()
        Try
            clsDalContract.InsertDevicePos()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateDeviceForOnlyPosID()
        Try
            clsDalContract.UpdateDevice_OnlyPosID(clsDalContract.DPPosID, clsDalContract.DPDeviceID, True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateContractImportDeviceID()
        Try
            clsDalContract.UpdateContractImportDeviceID(clsDalContract.DPDeviceID, clsDalContract.ContractID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Set Get"
    'Private Sub SetCodes(ByVal dt As DataTable)
    '    Try
    '        Dim MCC As String
    '        Dim MerchantSerial As String = ""
    '        Dim OutletSerial As String = ""
    '        Dim VatSerial As String = ""
    '        Dim CodeSerial As String = ""
    '        MCC = dt.Rows(0).Item("SGroupID").ToString.Trim
    '        Me.GetTheLatestDevice(MerchantSerial, OutletSerial, VatSerial, CodeSerial)
    '        clsDalContract.DMerchant_vc = dt.Rows(0).Item("SCityID").ToString.Remove(0, 1) + MCC + MerchantSerial '****/****/****
    '        clsDalContract.DVat_vc = dt.Rows(0).Item("SStateID").ToString.Remove(0, 1) + dt.Rows(0).Item("SCityID").ToString.Remove(0, 1) + GetAPartOfString(dt.Rows(0).Item("Date_vc").ToString, 2, 2) + GetAPartOfString(dt.Rows(0).Item("Date_vc").ToString, 5, 2) + PSP + VatSerial '**/****/**/**/*/****
    '        clsDalContract.DOutlet_vc = dt.Rows(0).Item("SStateID").ToString.Remove(0, 1) + MCC + PSP + OutletSerial '****/**/*/*****
    '        clsDalContract.DCode_vc = dt.Rows(0).Item("SStateID").ToString.Remove(0, 1) + PSP + CodeSerial '**/*/*****
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private Sub SetCodes(ByVal dt As DataTable)
        Try
            Dim MCC, SCityID, SStateID, Date_vcYear, Date_vcMonth As String
            Dim SStoreID As Int64
            MCC = dt.Rows(0).Item("SGroupID").ToString.Trim
            SCityID = dt.Rows(0).Item("SCityID").ToString.Remove(0, 1)
            SStateID = dt.Rows(0).Item("SStateID").ToString.Remove(0, 1)
            Date_vcYear = GetAPartOfString(dt.Rows(0).Item("Date_vc").ToString, 2, 2)
            Date_vcMonth = GetAPartOfString(dt.Rows(0).Item("Date_vc").ToString, 5, 2)
            SStoreID = dt.Rows(0).Item("SStoreID")

            '===application
            clsDalContract.DMerchant_vc = String.Empty 'clsDalContract.DSwitch_CardAcceptorID_vc 'GetMerchant(SCityID, MCC, SStoreID) '****/****/****
            clsDalContract.DVat_vc = String.Empty 'clsDalContract.DSwitch_CardAcceptorID_vc 'GetVat(SStateID, SCityID, Date_vcYear, Date_vcMonth, PSP, SStoreID) '**/****/**/**/*/****
            clsDalContract.DOutlet_vc = String.Empty 'clsDalContract.DSwitch_TerminalID_vc 'GetOutlet(SStateID, MCC, PSP) '****/**/*/*****
            clsDalContract.DCode_vc = String.Empty 'clsDalContract.DSwitch_TerminalID_vc 'GetCode(SStateID, PSP) '**/*/*****
            '===Vocher
            clsDalContract.DSwitch_CardAcceptorID_vc = String.Empty 'GetCardAcceptorID()
            clsDalContract.DSwitch_TerminalID_vc = String.Empty 'GetTerminalID_vc()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetMerchant(ByVal SCityID As String, ByVal MCC As String, ByVal SStoreID As Int64) As String
        Try
            'اشتباها در سوئيچ بانك تعريف شده است درنتيجه برنام ما نباي آن را توليد كند367270110001
            Dim Merchant As String
            Dim dtMerchantVat As New DataTable

            dtMerchantVat.Clear()
            dtMerchantVat = clsDalContract.GetByStoreIDMerchantAndVat(SStoreID, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtMerchantVat.Rows.Count > 0 Then
                Merchant = dtMerchantVat.Rows(0).Item("Merchant_vc")
                Return Merchant
            Else
                Dim dt2 As New DataTable
                Dim Counter As Int32
                Dim strCounter As String
                Dim MerchantFirstPart As String

                MerchantFirstPart = SCityID + MCC

                Dim dtCodes_Counter As New DataTable
                dtCodes_Counter = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(MerchantFirstPart, "M")
                If dtCodes_Counter.Rows.Count = 0 Then
                    '===اگر نبود همون كار قبلي خودمون رو انجام ميديم
                    Counter = 0
                    While True
                        Counter += 1
                        strCounter = Microsoft.VisualBasic.Right("0000" + Counter.ToString, 4)
                        Merchant = MerchantFirstPart + strCounter
                        dt2 = clsDalContract.GetBYMerchantDevice_LIKE(Merchant)
                        If dt2.Rows.Count = 0 AndAlso Merchant <> "367270110001" Then
                            Return Merchant
                        End If
                    End While
                    '=============================================
                ElseIf dtCodes_Counter.Rows.Count = 1 Then
                    '===اگر بود آخرين كانتر را از آن مي گيريم
                    Counter = Convert.ToInt64(dtCodes_Counter.Rows(0).Item("LastCounter_vc"))
                    While True
                        Counter += 1
                        strCounter = Microsoft.VisualBasic.Right("0000" + Counter.ToString, 4)
                        Merchant = MerchantFirstPart + strCounter
                        dt2 = clsDalContract.GetBYMerchantDevice_LIKE(Merchant)
                        If dt2.Rows.Count = 0 AndAlso Merchant <> "367270110001" Then
                            Return Merchant
                        End If
                    End While
                Else
                    Return String.Empty
                End If
            End If
        Catch ex As Exception
            Return String.Empty
        End Try



    End Function
    Private Function GetVat(ByVal SStateID As String, ByVal SCityID As String, ByVal Date_vcYear As String, ByVal Date_vcMonth As String, ByVal PSP As String, ByVal SStoreID As Int64) As String

        Try
            Dim Vat As String
            Dim dtMerchantVat As New DataTable
            dtMerchantVat.Clear()
            dtMerchantVat = clsDalContract.GetByStoreIDMerchantAndVat(SStoreID, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtMerchantVat.Rows.Count > 0 Then
                Vat = dtMerchantVat.Rows(0).Item("Vat_vc")
                Return Vat
            Else
                Dim Counter As Int32
                Dim strCounter As String
                Dim VatFirstPart As String
                Dim dt2 As New DataTable

                VatFirstPart = SStateID + SCityID + Date_vcYear + Date_vcMonth + PSP

                Dim dtCodes_Counter As New DataTable
                dtCodes_Counter = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(VatFirstPart, "V")
                If dtCodes_Counter.Rows.Count = 0 Then
                    '===اگر نبود همون كار قبلي خودمون رو انجام ميديم
                    Counter = 0
                    While True
                        Counter += 1
                        strCounter = Microsoft.VisualBasic.Right("0000" + Counter.ToString, 4)
                        Vat = VatFirstPart + strCounter
                        dt2 = clsDalContract.GetBYVatDevice_LIKE(Vat)
                        If dt2.Rows.Count = 0 Then
                            Return Vat
                        End If
                    End While
                    '=============================================
                ElseIf dtCodes_Counter.Rows.Count = 1 Then
                    '===اگر بود آخرين كانتر را از آن مي گيريم
                    Counter = Convert.ToInt64(dtCodes_Counter.Rows(0).Item("LastCounter_vc"))
                    While True
                        Counter += 1
                        strCounter = Microsoft.VisualBasic.Right("0000" + Counter.ToString, 4)
                        Vat = VatFirstPart + strCounter
                        dt2 = clsDalContract.GetBYVatDevice_LIKE(Vat)
                        If dt2.Rows.Count = 0 Then
                            Return Vat
                        End If
                    End While
                Else
                    Return String.Empty
                End If
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
        '============Old=================
        'Dim Counter As Int32
        'Dim strCounter As String
        'Dim Count As Int32
        'Dim VatFirstPart As String
        'Dim Vat As String
        'Dim dt1 As New DataTable
        'Dim dt2 As New DataTable

        'VatFirstPart = SStateID + SCityID + Date_vcYear + Date_vcMonth + PSP
        'dt1 = clsDalContract.GetBYVatDevice_LIKE(VatFirstPart)
        'Counter = 0
        'While True
        '    Counter += 1
        '    strCounter = Microsoft.VisualBasic.Right("0000" + Counter.ToString, 4)
        '    Vat = VatFirstPart + strCounter
        '    dt2 = clsDalContract.GetBYVatDevice_LIKE(Vat)
        '    If dt2.Rows.Count = 0 Then
        '        Return Vat
        '    End If
        '    Dim dr() As DataRow = dt2.Select("StoreID=" + SStoreID.ToString)
        '    If dr.Length > 0 Then
        '        Return Vat
        '    End If
        'End While
        '============Old=================
    End Function
    Private Function GetOutlet(ByVal SStateID As String, ByVal MCC As String, ByVal PSP As String) As String
        Try
            Dim Counter As Int32
            Dim strCounter As String
            Dim OutletFirstPart As String
            Dim Outlet As String
            'Dim dt1 As New DataTable
            Dim dt2 As New DataTable

            OutletFirstPart = SStateID + MCC + PSP

            Dim dtCodes_Counter As New DataTable
            dtCodes_Counter = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(OutletFirstPart, "O")
            If dtCodes_Counter.Rows.Count = 0 Then
                '===اگر نبود همون كار قبلي خودمون رو انجام ميديم
                Counter = 0
                While True
                    Counter += 1
                    strCounter = Microsoft.VisualBasic.Right("00000" + Counter.ToString(), 5)
                    Outlet = OutletFirstPart + strCounter
                    dt2 = clsDalContract.GetBYOutletDevice_LIKE(Outlet)
                    If dt2.Rows.Count = 0 Then
                        Return Outlet
                    End If
                End While
                '=============================================
            ElseIf dtCodes_Counter.Rows.Count = 1 Then
                '===اگر بود آخرين كانتر را از آن مي گيريم
                Counter = Convert.ToInt64(dtCodes_Counter.Rows(0).Item("LastCounter_vc"))
                While True
                    Counter += 1
                    strCounter = Microsoft.VisualBasic.Right("00000" + Counter.ToString(), 5)
                    Outlet = OutletFirstPart + strCounter
                    dt2 = clsDalContract.GetBYOutletDevice_LIKE(Outlet)
                    If dt2.Rows.Count = 0 Then
                        Return Outlet
                    End If
                End While
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
        '============Old=================
        'Dim Counter As Int32
        'Dim strCounter As String
        'Dim OutletFirstPart As String
        'Dim Outlet As String
        'Dim dt1 As New DataTable
        'Dim dt2 As New DataTable

        'OutletFirstPart = SStateID + MCC + PSP
        'dt1 = clsDalContract.GetBYOutletDevice_LIKE(OutletFirstPart)
        'Counter = 0
        'While True
        '    Counter += 1
        '    strCounter = Microsoft.VisualBasic.Right("00000" + Counter.ToString(), 5)
        '    Outlet = OutletFirstPart + strCounter
        '    dt2 = clsDalContract.GetBYOutletDevice_LIKE(Outlet)
        '    If dt2.Rows.Count = 0 Then
        '        Return Outlet
        '    End If
        'End While
        '============Old=================
    End Function
    Private Function GetCode(ByVal SStateID As String, ByVal PSP As String) As String

        Try
            Dim Counter As Int32
            Dim strCounter As String

            Dim CodeFirstPart As String
            Dim Code As String
            Dim dt1 As New DataTable
            Dim dt2 As New DataTable

            CodeFirstPart = SStateID + PSP

            Dim dtCodes_Counter As New DataTable
            dtCodes_Counter = clsDalContract.GetByCodeFirstPartAndTypeCodes_Counter(CodeFirstPart, "C")
            If dtCodes_Counter.Rows.Count = 0 Then
                '===اگر نبود همون كار قبلي خودمون رو انجام ميديم
                'dt1 = clsDalContract.GetBYCodeDevice_LIKE(CodeFirstPart)
                Counter = 0
                While True
                    Counter += 1
                    strCounter = Microsoft.VisualBasic.Right("00000" + Counter.ToString(), 5)
                    Code = CodeFirstPart + strCounter
                    dt2 = clsDalContract.GetBYCodeDevice_LIKE(Code)
                    If dt2.Rows.Count = 0 Then
                        'clsDalContract.InsertCodes_Counter("C", CodeFirstPart, strCounter)
                        Return Code
                    End If
                End While
                '=============================================
            ElseIf dtCodes_Counter.Rows.Count = 1 Then
                '===اگر بود آخرين كانتر را از آن مي گيريم
                Counter = Convert.ToInt64(dtCodes_Counter.Rows(0).Item("LastCounter_vc"))
                While True
                    Counter += 1
                    strCounter = Microsoft.VisualBasic.Right("00000" + Counter.ToString(), 5)
                    Code = CodeFirstPart + strCounter
                    dt2 = clsDalContract.GetBYCodeDevice_LIKE(Code)
                    If dt2.Rows.Count = 0 Then
                        'clsDalContract.UpdateCodes_CounterForLastCounter(strCounter, dtCodes_Counter.Rows(0).Item("ID"))
                        Return Code
                    End If
                End While
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
        '============Old=================
        'Dim Counter As Int32
        'Dim strCounter As String

        'Dim CodeFirstPart As String
        'Dim Code As String
        'Dim dt1 As New DataTable
        'Dim dt2 As New DataTable

        'CodeFirstPart = SStateID + PSP
        'dt1 = clsDalContract.GetBYCodeDevice_LIKE(CodeFirstPart)
        'Counter = 0
        'While True
        '    Counter += 1
        '    strCounter = Microsoft.VisualBasic.Right("00000" + Counter.ToString(), 5)
        '    Code = CodeFirstPart + strCounter
        '    dt2 = clsDalContract.GetBYCodeDevice_LIKE(Code)
        '    If dt2.Rows.Count = 0 Then
        '        Return Code
        '    End If
        'End While
        '============Old=================
    End Function
    Private Function GetCardAcceptorID() As String

        Try
            Dim CardAcceptorID As String

            Dim CodeFirstPart As String = "MERCHANT"

            Dim Counter As Int32
            Dim strCounter As String

            Dim dtCardAcceptorID_Counter As New DataTable
            dtCardAcceptorID_Counter = clsDalContract.GetTheLatestSwitchCardAcceptorID()
            If dtCardAcceptorID_Counter.Rows.Count = 0 Then
                strCounter = "1800001"
                CardAcceptorID = CodeFirstPart & strCounter
                Return CardAcceptorID
            ElseIf dtCardAcceptorID_Counter.Rows.Count = 1 Then
                Counter = Convert.ToInt64(dtCardAcceptorID_Counter.Rows(0).Item(0)) + 1
                strCounter = Microsoft.VisualBasic.Right("0000000" & Counter, 7)

                CardAcceptorID = CodeFirstPart & strCounter
                Return CardAcceptorID
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try

    End Function
    Private Function GetTerminalID_vc() As String

        Try
            Dim TerminalID As String

            Dim CodeFirstPart As String = "P"

            Dim Counter As Int32
            Dim strCounter As String

            Dim dtCardAcceptorID_Counter As New DataTable
            dtCardAcceptorID_Counter = clsDalContract.GetTheLatestSwitchTerminalID()
            If dtCardAcceptorID_Counter.Rows.Count = 0 Then
                strCounter = "1800001"

                TerminalID = CodeFirstPart & strCounter
                Return TerminalID
            ElseIf dtCardAcceptorID_Counter.Rows.Count = 1 Then
                Counter = Convert.ToInt64(dtCardAcceptorID_Counter.Rows(0).Item(0)) + 1
                strCounter = Microsoft.VisualBasic.Right("0000000" & Counter, 7)

                TerminalID = CodeFirstPart & strCounter
                Return TerminalID
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Private Sub GetTheLatestDevice(ByRef MerchantSerial As String, ByRef OutletSerial As String, ByRef VatSerial As String, ByRef CodeSerial As String)
        Try
            Dim lngMerchantSerial As Long
            Dim lngOutletSerial As Long
            Dim lngVatSerial As Long
            Dim lngCodeSerial As Long

            Dim dt As New DataTable

            dt = clsDalContract.GetTheLatestDevice()
            If dt.Rows.Count > 0 Then
                If clsDalContract.SStoreID <> 0 Then
                    '===
                    If dt.Rows(0).Item("StoreID") = clsDalContract.SStoreID Then
                        MerchantSerial = GetAPartOfString(dt.Rows(0).Item("Merchant_vc"), dt.Rows(0).Item("Merchant_vc").ToString.Length - 4, 4)
                        VatSerial = GetAPartOfString(dt.Rows(0).Item("Vat_vc"), dt.Rows(0).Item("Vat_vc").ToString.Length - 4, 4)
                    Else
                        MerchantSerial = GetAPartOfString(dt.Rows(0).Item("Merchant_vc"), dt.Rows(0).Item("Merchant_vc").ToString.Length - 4, 4)
                        VatSerial = GetAPartOfString(dt.Rows(0).Item("Vat_vc"), dt.Rows(0).Item("Vat_vc").ToString.Length - 4, 4)

                        lngMerchantSerial = Convert.ToInt64(MerchantSerial) + 1
                        lngVatSerial = Convert.ToInt64(VatSerial) + 1

                        MerchantSerial = Microsoft.VisualBasic.Right("0000" + lngMerchantSerial.ToString, 4)
                        VatSerial = Microsoft.VisualBasic.Right("0000" + lngVatSerial.ToString(), 4)
                    End If
                    OutletSerial = GetAPartOfString(dt.Rows(0).Item("Outlet_vc"), dt.Rows(0).Item("Outlet_vc").ToString.Length - 5, 5)
                    CodeSerial = GetAPartOfString(dt.Rows(0).Item("Code_vc"), dt.Rows(0).Item("Code_vc").ToString.Length - 5, 5)

                    lngOutletSerial = Convert.ToInt64(OutletSerial) + 1
                    lngCodeSerial = Convert.ToInt64(CodeSerial) + 1

                    OutletSerial = Microsoft.VisualBasic.Right("00000" + lngOutletSerial.ToString(), 5)
                    CodeSerial = Microsoft.VisualBasic.Right("00000" + lngCodeSerial.ToString(), 5)

                    '===
                Else
                    MerchantSerial = ""
                    OutletSerial = ""
                    VatSerial = ""
                    CodeSerial = ""
                End If
            Else
                MerchantSerial = "0001"
                OutletSerial = "00001"
                VatSerial = "0001"
                CodeSerial = "00001"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#End Region

#Region "Add"
    Private Sub Add()
        Me.EmptyTextBoxes()
        Me.RefreshdgvAssignablePos()
    End Sub
#End Region

#Region "Print"
    Private Sub PrintLabel()
        Try
            'ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_PoseCode_Outlet
            'PrintDocument.Print()
            ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_StoreName
            PrintDocument.Print()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#Region "RePrint"
    Private Sub MustRePrint()
        Try
            If MessageBox.Show("آیا مایل به چاپ مجدد می باشید ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            clsDalContract.BeginProc()
            clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
            dtAssigningPos = clsDalContract.GetByContractIDSerialCountContractingParty_Contract_Account_Store_Device_Device_Pos_DevicePos_PURE(txtSerial_vc.Text, 1, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtAssigningPos.Rows.Count > 0 Then
                clsDalContract.DOutlet_vc = dtAssigningPos.Rows(0).Item("DOutlet_vc")
                clsDalContract.DCode_vc = dtAssigningPos.Rows(0).Item("DCode_vc")
                clsDalContract.SName_nvc = dtAssigningPos.Rows(0).Item("SName_nvc")
                clsDalContract.FirstName_nvc = dtAssigningPos.Rows(0).Item("FirstName_nvc")
                clsDalContract.LastName_nvc = dtAssigningPos.Rows(0).Item("LastName_nvc")
                Me.RePrintLabel()
                Me.EmptyTextBoxes()
            Else
                ShowErrorMessage("اطلاعات وارد شده نامعتبر می باشد")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub RePrintLabel()
        'Try
        '    ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_PoseCode_Outlet
        '    m_pd.Print()
        '    ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_StoreName
        '    m_pd.Print()
        'Catch ex As Exception
        '    Throw ex
        'End Try
        If txtContractID.Text.Trim <> "" Then
            Try
                Dim dt As New DataTable
                ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_StoreName
                PrintDocument.Print()
            Catch ex As Exception
                Throw ex
            Finally
                Me.clsDalContract.EndProc()
            End Try
        Else
            Throw New KeyNotFoundException
        End If
    End Sub
#End Region
#End Region

#End Region
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignDelete.Click
        Dim _frmDeleteDeviceAssigning As New frmDeleteDeviceAssigning
        _frmDeleteDeviceAssigning.ShowDialog()
        Me.RefreshdgvAssignablePos()
    End Sub

    Private Sub dgvAssignablePos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAssignablePos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Me.Save()
            Catch ex As Exception
                modPublicMethod.ShowErrorMessage(ex.Message)
                ClassError.LogError(ex)
            End Try
        End If
    End Sub

    Private Sub frmDeviceAssigning_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvAssignablePos)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvAssignablePos.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(Me.dgvAssignablePos.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvAssignablePos.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvAssignablePos.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvAssignablePos.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvAssignablePos.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub

    
   
    Private Sub MarketingByUC1_MarketingByID_SelectedIndexChanged() Handles MarketingByUC1.MarketingByID_SelectedIndexChanged
        Try
            RefreshdgvAssignablePos()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
   
    Private Sub FillCombo()
        Dim clsDALCMSProject As New ClassDALCMSProject(ConnectionString)
        clsDALCMSProject.BeginProc()
        Dim dt1 As New DataTable
        dt1 = clsDALCMSProject.GetAll()
        clsDALCMSProject.EndProc()
        Dim dr As DataRow = dt1.NewRow()
        dr("CMSProjectID_int") = "0"
        dr("Name_nvc") = "همه"
        dt1.Rows.InsertAt(dr, 0)

        cmbProject.DataSource = dt1
        cmbProject.ValueMember = "CMSProjectID_int"
        cmbProject.DisplayMember = "Name_nvc"
    End Sub
    Private Sub cmbProject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProject.SelectedIndexChanged
        Try
            If IsNumeric(cmbProject.SelectedValue) = True Then
                RefreshdgvAssignablePos()
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
   
End Class