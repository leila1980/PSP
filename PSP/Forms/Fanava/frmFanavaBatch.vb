Public Class frmFanavaBatch
    Private dtDetail As New DataTable
    Private da As New ClassDALFanava(ConnectionString)

    Private Sub frmFanavaBatch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub

    Private Sub frmFanavaBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.GroupBox1.Dispose()
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.Text = "ساخت بچ فناوا"
            Me.GotoState(State.Load)
            Me.btnPrint.Visible = False
            Me.ToolStripSeparator4.Visible = False
            Me.InitDataGridView()
            FillcmbHeaderNumber()
            If (Me.cmbHeaderNumber.Items.Count > 0) Then
                Me.ShowInfo(Me.cmbHeaderNumber.SelectedValue)
            End If

            Me.GotoState(State.VIEW)
            If Me.txtID_bint.Text = "" Then
                Me.CurrentRecordIsNotFound()
            End If
        Catch ex As Exception
            ShowMessage(ex.Message)
        End Try
    End Sub

    Public Overrides Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.GotoState(State.ADD)
        Me.ClearForm()
        'Me.cmbHeaderNumber.SelectedIndex = -1
        Me.txtDate_vc.Value = modPublicMethod.GetDateNow
    End Sub

    Public Overrides Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.ErrPro.Clear()
            FillcmbHeaderNumber()
            VIEWSTATE()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Function ValidateSwitchForDelete(ByVal DeviceID As Int64) As Boolean
        Try
            Dim daContract As New ClassDALContract(ConnectionString)

            daContract.DDeviceID = DeviceID
            Dim dtSwitch As DataTable = daContract.GetByDeviceIDDevice()
            If dtSwitch.Rows.Count > 0 AndAlso (IsDBNull(dtSwitch.Rows(0).Item("Password_vc")) = False AndAlso dtSwitch.Rows(0).Item("Password_vc").ToString <> "") Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Overrides Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Me.txtID_bint.Text = "" Then
                Exit Sub
            End If
            If ShowConfirmDeleteMessage() = False Then
                Exit Sub
            End If

            For Each dr As DataRow In Me.dtDetail.Rows
                If ValidateSwitchForDelete(Me.DataGridView1.SelectedRows(0).Cells("colDDeviceID").Value) = False Then
                    ShowMessage(msgAccountListHasAccountNO)
                    Exit Sub
                End If
            Next

            da.BeginProc()
            da.DeleteBatchDetail(Me.txtID_bint.Text)
            da.DeleteBatchHeader(Me.txtID_bint.Text)
            FillcmbHeaderNumber()
            Me.VIEWSTATE()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            da.EndProc()
        End Try
    End Sub

    Public Overrides Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.GotoState(State.EDIT)
    End Sub

    Public Overrides Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.CurrentState = State.ADD Then
            Dim frm As New frmFanavaList(Me.dtDetail, My.Settings.Fanava_CmsProjectID)
            frm.ShowDialog()
            Me.cmbHeaderNumber.SelectedIndex = -1
            Me.DataGridView1.DataSource = Me.dtDetail
        Else
            Me.dtDetail = da.GetByIDBatchDetail(Me.txtID_bint.Text)
            Dim frm As New frmFanavaList(Me.dtDetail, Me.txtID_bint.Text, My.Settings.Fanava_CmsProjectID)
            frm.ShowDialog()
            Me.DataGridView1.DataSource = Me.dtDetail
        End If
    End Sub

    Public Overrides Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                If Me.ValidateSwitchForDelete(Me.DataGridView1.SelectedRows(0).Cells("colDDeviceID").Value) = False Then
                    ShowMessage(msgAccountHasAccountNO)
                ElseIf ShowConfirmDeleteMessage() = True Then
                    Dim dr() As DataRow = Me.dtDetail.Select("DDeviceID=" + Me.DataGridView1.SelectedRows(0).Cells("colDDeviceID").Value.ToString)
                    If dr.Length > 0 Then
                        dr(0).Delete()
                        Me.dtDetail.AcceptChanges()
                    End If
                End If
            End If
            Me.FillcmbHeaderNumber()

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Overrides Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Select Case Me.CurrentState
                Case State.ADD
                    da.BeginProc()

                    If Me.ValidateForm_ADD = False Then
                        Exit Sub
                    End If

                    Dim Number As Integer = GetMaxNumber() + 1
                    Dim ID As Long
                    Me.InsertData(Number, ID)
                    FillcmbHeaderNumber()

                    VIEWSTATE()
                Case State.EDIT
                    da.BeginProc()

                    If Me.ValidateForm_Edit = False Then
                        Exit Sub
                    End If

                    Dim Header As New ClassDALFanava.BatchHeader
                    Dim Detail As New ClassDALFanava.BatchDetail

                    Header.SaveDate_vc = Me.txtDate_vc.Value
                    Header.Description_nvc = Me.txtBatchDescription_nvc.Text
                    Header.HeaderID = Me.txtID_bint.Text
                    Header.Number_bint = Me.cmbHeaderNumber.SelectedValue()

                    da.UpdateBatchHeader(Header)
                    da.DeleteBatchDetail(Header.HeaderID)
                    For Each dr As DataRow In dtDetail.Rows
                        Detail.ContractID = dr.Item("ContractID")
                        Detail.DetailID = 0
                        Detail.HeaderID = Me.txtID_bint.Text
                        Detail.DetailID = da.InsertBatchDetail(Detail)
                    Next
                    VIEWSTATE()
            End Select
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            da.EndProc()
        End Try
    End Sub

    Private Sub InitDataGridView()
        Me.DataGridView1.AutoGenerateColumns = False

        Dim colFirstName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFirstName_nvc.DataPropertyName = "FirstName_nvc"
        colFirstName_nvc.HeaderText = "نام"
        colFirstName_nvc.Name = "colFirstName_nvc"
        colFirstName_nvc.ReadOnly = True
        colFirstName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colFirstName_nvc)

        Dim colLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colLastName_nvc.DataPropertyName = "LastName_nvc"
        colLastName_nvc.HeaderText = "نام خانوادگی"
        colLastName_nvc.Name = "colLastName_nvc"
        colLastName_nvc.ReadOnly = True
        colLastName_nvc.Width = 200
        Me.DataGridView1.Columns.Add(colLastName_nvc)

        Dim colNationalCode_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colNationalCode_nvc.DataPropertyName = "NationalCode_nvc"
        colNationalCode_nvc.HeaderText = "کد ملی"
        colNationalCode_nvc.Name = "colNationalCode_nvc"
        colNationalCode_nvc.ReadOnly = True
        colNationalCode_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colNationalCode_nvc)

        Dim colContractID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractID.DataPropertyName = "ContractID"
        colContractID.HeaderText = "کد قرار داد"
        colContractID.Name = "colContractID"
        colContractID.ReadOnly = True
        colContractID.Width = 100
        Me.DataGridView1.Columns.Add(colContractID)
        colContractID.Visible = False

        Dim colContractNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractNo_vc.DataPropertyName = "ContractNo_vc"
        colContractNo_vc.HeaderText = "شماره قرار داد"
        colContractNo_vc.Name = "colContractNo_vc"
        colContractNo_vc.ReadOnly = True
        colContractNo_vc.Width = 100
        Me.DataGridView1.Columns.Add(colContractNo_vc)

        Dim colAAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountNO_vc.DataPropertyName = "AAccountNO_vc"
        colAAccountNO_vc.HeaderText = "شماره حساب"
        colAAccountNO_vc.Name = "colAAccountNO_vc"
        colAAccountNO_vc.ReadOnly = True
        colAAccountNO_vc.Width = 120
        Me.DataGridView1.Columns.Add(colAAccountNO_vc)

        Dim colACardNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colACardNO_vc.DataPropertyName = "ACardNO_vc"
        colACardNO_vc.HeaderText = "شماره کارت"
        colACardNO_vc.Name = "colACardNO_vc"
        colACardNO_vc.ReadOnly = True
        colACardNO_vc.Width = 80
        Me.DataGridView1.Columns.Add(colACardNO_vc)

        Dim colSStoreID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSStoreID.DataPropertyName = "SStoreID"
        colSStoreID.HeaderText = "کد فروشگاه"
        colSStoreID.Name = "colSStoreID"
        colSStoreID.ReadOnly = True
        colSStoreID.Visible = False
        Me.DataGridView1.Columns.Add(colSStoreID)
        colSStoreID.Visible = False

        Dim colSName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSName_nvc.DataPropertyName = "SName_nvc"
        colSName_nvc.HeaderText = "نام فروشگاه"
        colSName_nvc.Name = "colSName_nvc"
        colSName_nvc.ReadOnly = True
        colSName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colSName_nvc)

        Dim colDDeviceID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDDeviceID.DataPropertyName = "DDeviceID"
        colDDeviceID.HeaderText = "کد دستگاه"
        colDDeviceID.Name = "colDDeviceID"
        colDDeviceID.ReadOnly = True
        colDDeviceID.Width = 100
        Me.DataGridView1.Columns.Add(colDDeviceID)
        colDDeviceID.Visible = False

        Dim colDCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDCode_vc.DataPropertyName = "DCode_vc"
        colDCode_vc.HeaderText = "پز کد"
        colDCode_vc.Name = "colDCode_vc"
        colDCode_vc.ReadOnly = True
        colDCode_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDCode_vc)

        Dim colDOutlet_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDOutlet_vc.DataPropertyName = "DOutlet_vc"
        colDOutlet_vc.HeaderText = "Outlet"
        colDOutlet_vc.Name = "colDOutlet_vc"
        colDOutlet_vc.ReadOnly = True
        colDOutlet_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDOutlet_vc)

        Dim colDVat_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDVat_vc.DataPropertyName = "DVat_vc"
        colDVat_vc.HeaderText = "DVat_vc"
        colDVat_vc.Name = "colDVat_vc"
        colDVat_vc.ReadOnly = True
        colDVat_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDVat_vc)

        Dim colDMerchant_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDMerchant_vc.DataPropertyName = "DMerchant_vc"
        colDMerchant_vc.HeaderText = "Merchant"
        colDMerchant_vc.Name = "colDMerchant_vc"
        colDMerchant_vc.ReadOnly = True
        colDMerchant_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDMerchant_vc)

        Dim colPPosID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPPosID.DataPropertyName = "PPosID"
        colPPosID.HeaderText = "کد پز"
        colPPosID.Name = "colPPosID"
        colPPosID.ReadOnly = True
        colPPosID.Width = 100
        Me.DataGridView1.Columns.Add(colPPosID)
        colPPosID.Visible = False

        Dim colPSerial_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPSerial_vc.DataPropertyName = "PSerial_vc"
        colPSerial_vc.HeaderText = "سریال پز"
        colPSerial_vc.Name = "colPSerial_vc"
        colPSerial_vc.ReadOnly = True
        colPSerial_vc.Width = 100
        Me.DataGridView1.Columns.Add(colPSerial_vc)

        Dim colPPropertyNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPPropertyNO_vc.DataPropertyName = "PPropertyNO_vc"
        colPPropertyNO_vc.HeaderText = "شماره اموال"
        colPPropertyNO_vc.Name = "colPPropertyNO_vc"
        colPPropertyNO_vc.ReadOnly = True
        colPPropertyNO_vc.Width = 100
        Me.DataGridView1.Columns.Add(colPPropertyNO_vc)

        Dim colPEniacCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPEniacCode_vc.DataPropertyName = "PEniacCode_vc"
        colPEniacCode_vc.HeaderText = "کد پیگیری"
        colPEniacCode_vc.Name = "colPEniacCode_vc"
        colPEniacCode_vc.ReadOnly = True
        colPEniacCode_vc.Width = 100
        Me.DataGridView1.Columns.Add(colPEniacCode_vc)


        Dim colDSwitch_CardAcceptorID_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDSwitch_CardAcceptorID_vc.DataPropertyName = "DSwitch_CardAcceptorID_vc"
        colDSwitch_CardAcceptorID_vc.HeaderText = "CardAcceptorID"
        colDSwitch_CardAcceptorID_vc.Name = "colDSwitch_CardAcceptorID_vc"
        colDSwitch_CardAcceptorID_vc.ReadOnly = True
        colDSwitch_CardAcceptorID_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDSwitch_CardAcceptorID_vc)

        Dim colDSwitch_TerminalID_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDSwitch_TerminalID_vc.DataPropertyName = "DSwitch_TerminalID_vc"
        colDSwitch_TerminalID_vc.HeaderText = "TerminalID"
        colDSwitch_TerminalID_vc.Name = "colDSwitch_TerminalID_vc"
        colDSwitch_TerminalID_vc.ReadOnly = True
        colDSwitch_TerminalID_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDSwitch_TerminalID_vc)
    End Sub

    Private Function GetMaxNumber()
        Try
            Dim dt As New DataTable
            dt = da.GetLatestHeaderNumber()
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item("Number_bint")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function ValidateForm_ADD() As Boolean
        Dim res As Boolean = True
        Me.ErrPro.Clear()

        If Me.txtDate_vc.Value = "" Then
            res = False
            Me.ErrPro.SetError(Me.txtDate_vc, "تاریخ را وارد کنید")
        End If

        Dim dtDuplicat As New DataTable
        dtDuplicat = da.GetByCountContractingParty_Contract_Account_Store_AvailableForBatch(1, ClassUserLoginDataAccess.ThisUser.ProjectID, My.Settings.Fanava_CmsProjectID)

        For Each dr As DataRow In dtDetail.Rows
            Dim drSelect() As DataRow = dtDuplicat.Select("ContractID=" + dr.Item("ContractID").ToString)
            If drSelect.Length = 0 Then
                dr.RowError = "  ساخت بچ برای قرارداد موردنظر قبلا انجام شده است"
                res = False
            End If
        Next

        Return res
    End Function

    Private Function ValidateForm_Edit() As Boolean
        Dim res As Boolean = True
        Me.ErrPro.Clear()

        If Me.txtDate_vc.Value = "" Then
            res = False
            Me.ErrPro.SetError(Me.txtDate_vc, "تاریخ را وارد کنید")
        End If

        Dim dtDuplicat As New DataTable
        dtDuplicat = da.GetByCountContractingParty_Contract_Account_Store_AvailableForBatch(1, ClassUserLoginDataAccess.ThisUser.ProjectID, My.Settings.Fanava_CmsProjectID)
        Dim dtCurrentRecord As New DataTable
        dtCurrentRecord = da.GetByIDBatchDetail(Me.txtID_bint.Text)

        For Each dr As DataRow In dtDetail.Rows
            Dim drSelect() As DataRow = dtDuplicat.Select("ContractID=" + dr.Item("ContractID").ToString)
            If drSelect.Length = 0 Then
                Dim drCurrentSelect() As DataRow = dtCurrentRecord.Select("ContractID=" + dr.Item("ContractID").ToString)
                If drCurrentSelect.Length = 0 Then
                    dr.RowError = " ساخت بچ برای قرارداد موردنظر قبلا انجام شده است"
                    res = False
                End If
            End If
        Next

        Return res
    End Function

    Private Sub CurrentRecordIsNotFound()
        Me.btnEdit.Enabled = False
        Me.btnPrint.Enabled = False
        Me.btnDelete.Enabled = False
    End Sub

    Private Sub ShowInfo(ByVal Number As Integer)
        Try
            Dim dtMHDHeader As New DataTable
            Dim dtMHDDetail As New DataTable
            dtMHDHeader = da.GetByNumberBatchHeader(Number)
            If dtMHDHeader.Rows.Count > 0 Then
                Me.txtID_bint.Text = dtMHDHeader.Rows(0).Item("HeaderID").ToString
                Me.txtDate_vc.Value = dtMHDHeader.Rows(0).Item("SaveDate_vc").ToString
                Me.txtBatchDescription_nvc.Text = dtMHDHeader.Rows(0).Item("Description_nvc").ToString
                dtDetail = da.GetByIDBatchDetail(Me.txtID_bint.Text)
                Me.DataGridView1.DataSource = Me.dtDetail
            Else
                Me.txtID_bint.Clear()
                Me.txtBatchDescription_nvc.Clear()
                Me.txtDate_vc.Value = ""
                dtDetail = da.GetByIDBatchDetail(-1)
                Me.DataGridView1.DataSource = Me.dtDetail
            End If
            Me.VIEWSTATE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InsertData(ByRef Number As Int64, ByRef ID As Int64)
        Try
            Dim Header As New ClassDALFanava.BatchHeader
            Dim Detail As New ClassDALFanava.BatchDetail
            Dim HeaderID As Long

            Header.SaveDate_vc = Me.txtDate_vc.Value
            Header.Number_bint = Me.GetMaxNumber + 1
            Header.Description_nvc = Me.txtBatchDescription_nvc.Text
            Header.HeaderID = 0

            HeaderID = da.InsertBatchHeader(Header)
            For Each dr As DataRow In dtDetail.Rows
                Detail.ContractID = dr.Item("ContractID")
                Detail.DetailID = 0
                Detail.HeaderID = HeaderID
                Detail.DetailID = da.InsertBatchDetail(Detail)
            Next
            ID = HeaderID
            Number = Header.Number_bint
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VIEWSTATE()
        Me.GotoState(State.VIEW)
    End Sub

    Public Sub ClearForm()
        Me.txtDate_vc.Value = ""
        Me.txtBatchDescription_nvc.Text = ""
        Me.dtDetail.Rows.Clear()
        dtDetail.AcceptChanges()
    End Sub

    Private Sub frmSwitch_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

    Private Sub FillcmbHeaderNumber()
        Try
            Me.da.BeginProc()
            Me.cmbHeaderNumber.DisplayMember = "number_bint"
            Me.cmbHeaderNumber.ValueMember = "number_bint"
            Me.cmbHeaderNumber.DataSource = da.GetAllHeaderNumbers(My.Settings.Fanava_CmsProjectID)

              If (cmbHeaderNumber.Items.Count = 0) Then
                Me.DataGridView1.DataSource = Nothing
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Me.da.EndProc()
        End Try
    End Sub
    Public Sub btnExportExcelOld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)

                Dim FanavaFormatdt As New DataTable

                FanavaFormatdt.Columns.Add("MERCH_STORE_NAME", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("LICENSE_NUMBER", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("LICENSE_NUMBER_REFERENCE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("MERCH_CATEGORY_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("MERCH_CATEGORY_DET_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("MERCH_STATE_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("MERCH_CITY_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("POSTAL_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("ADDRESS", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("TEL", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("MOBILE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("NAME", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("LASTNAME", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("BIRTHDAY", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("NATIONAL_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("BANK_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("BANK_BRANCH_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("BANK_ACCOUNT_NUMBER", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("IBAN", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("CNTR_NO", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("PG_CNTR_NO", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("BUSINESS_TYPE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("MERCH_AGENT_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("MERCH_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("LOGICAL_TERMINAL_CODE", Type.GetType("System.String"))

                FanavaFormatdt.Columns.Add("TERMINALTYPE_ID", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("MERCH_GROUP_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("BANK_TYPE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("COMPANY_NAME", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("COMPANY_ESTABLISHED_DATE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("COMPANY_NATIONAL_ID", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("LEGAL_TYPE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("PAN", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("CONTRACTOR_CODE", Type.GetType("System.String"))
                FanavaFormatdt.Columns.Add("MARKETER_TYPE", Type.GetType("System.String"))


                For Each r As DataRow In TryCast(DataGridView1.DataSource, DataTable).Rows
                    Dim newrow As DataRow = FanavaFormatdt.NewRow

                    newrow("LOGICAL_TERMINAL_CODE") = String.Empty
                    newrow("MERCH_CODE") = String.Empty
                    newrow("MERCH_AGENT_CODE") = String.Empty
                    newrow("BUSINESS_TYPE") = "0"
                    newrow("PG_CNTR_NO") = String.Empty
                    newrow("CNTR_NO") = r("ContractID")
                    newrow("IBAN") = r("Shabaaccount")
                    newrow("BANK_ACCOUNT_NUMBER") = r("AAccountNO_vc")
                    newrow("BANK_BRANCH_CODE") = "1827"
                    newrow("BANK_CODE") = r("Shabaaccount").ToString().Substring(4, 3)
                    newrow("NATIONAL_CODE") = r("NationalCode_nvc")
                    newrow("BIRTHDAY") = r("BirthDate_vc")
                    newrow("LASTNAME") = r("LastName_nvc")
                    newrow("NAME") = r("FirstName_nvc")
                    newrow("MOBILE") = r("STel2_vc")
                    newrow("TEL") = r("STel1_vc")
                    newrow("ADDRESS") = r("SAddress_nvc")
                    newrow("POSTAL_CODE") = r("SPostCode_vc")
                    newrow("MERCH_CITY_CODE") = r("cityshaparakCode")
                    newrow("MERCH_STATE_CODE") = r("stateShaparakCode")
                    newrow("MERCH_CATEGORY_DET_CODE") = r("SGroupsupplementaryid").ToString
                    newrow("MERCH_CATEGORY_CODE") = r("SGroupID")
                    newrow("LICENSE_NUMBER_REFERENCE") = String.Empty
                    If r("SLicenseid").ToString = String.Empty Then
                        newrow("LICENSE_NUMBER") = "1"
                    Else
                        newrow("LICENSE_NUMBER") = r("SLicenseid").ToString
                    End If

                    newrow("MERCH_STORE_NAME") = r("SName_nvc")
                    newrow("TERMINALTYPE_ID") = r("Storeposmodelid")
                    newrow("MERCH_GROUP_CODE") = "1213"
                    newrow("BANK_TYPE") = "1"
                    newrow("COMPANY_NAME") = String.Empty
                    newrow("COMPANY_ESTABLISHED_DATE") = String.Empty
                    newrow("COMPANY_NATIONAL_ID") = String.Empty
                    newrow("LEGAL_TYPE") = "2"
                    newrow("PAN") = String.Empty
                    newrow("CONTRACTOR_CODE") = "5"
                    newrow("MARKETER_TYPE") = "0"

                    FanavaFormatdt.Rows.Add(newrow)
                Next

                clsExcel.Write(FanavaFormatdt)
            End If

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Public Overrides Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)

                Dim FanavaFormatdt As New DataTable
                Dim dtFanavaExcelFiels As New DataTable
                dtFanavaExcelFiels = da.getAllFanavaExcelFields()

                For Each row As DataRow In dtFanavaExcelFiels.Rows
                    FanavaFormatdt.Columns.Add(row.Item("excelcolumnname"), Type.GetType("System.String"))
                Next


                For Each r As DataRow In TryCast(DataGridView1.DataSource, DataTable).Rows
                    Dim newrow As DataRow = FanavaFormatdt.NewRow

                    newrow("شناسه نوع ترمینال") = IIf(r("Storeposmodelid") = 7, "2", "1")
                    newrow("تاریخ قرارداد") = modPublicMethod.GetDateNow()
                    newrow("کد نمایندگی") = "1036747"
                    newrow("نام پذیرنده") = r("SName_nvc")
                    newrow("نوع پذیرنده ") = "0"
                    newrow("کد صنف تکمیلی") = r("SGroupsupplementaryid").ToString
                    newrow("شناسه محل پذیرنده") = r("cityfanavamappingcode")
                    newrow("نوع ملکیت") = "0"
                    newrow("کد نوع فعالیت") = "0"
                    newrow("آدرس پذیرنده") = r("SAddress_nvc")
                    newrow("آدرس پذیرنده لاتین") = "eniac"
                    newrow("کد پستی پذیرنده") = r("SPostCode_vc")
                    newrow("تلفن پذیرنده") = r("STel1_vc")
                    newrow("تلفن همراه پذیرنده") = IIf(r("STel2_vc").ToString().Substring(0, 1) <> "0", "0" + r("STel2_vc").ToString(), r("STel2_vc").ToString())
                    newrow("شناسه سمت شخص 1") = "3"
                    newrow("شناسه ملیت شخص 1") = "1"
                    newrow("کد ملی شخص 1") = r("NationalCode_nvc")
                    newrow("نام شخص 1") = r("FirstName_nvc")
                    newrow("نام خانوادگی شخص 1") = r("LastName_nvc")
                    newrow("نام لاتین شخص 1") = "eniac"
                    newrow("نام خانوادگی لاتین شخص 1") = "eniac"
                    newrow("نام پدر شخص 1") = r("FatherName_nvc")
                    newrow("نام پدر لاتین شخص 1") = "eniac"
                    newrow("تاریخ تولد شخص 1") = r("BirthDate_vc")
                    newrow("تلفن همراه شخص 1") = IIf(r("STel2_vc").ToString().Substring(0, 1) <> "0", "0" + r("STel2_vc").ToString(), r("STel2_vc").ToString())
                    newrow("جنسیت شخص 1") = 1
                    newrow("وضعیت حیات شخص 1") = "0"
                    newrow("شماره شناسنامه شخص 1") = r("IdentityCertificateNO_nvc")
                    newrow("نوع صاحب حساب 1") = "0"
                    newrow("کد ملی صاحب حساب 1") = r("NationalCode_nvc")
                    newrow("شماره حساب 1") = r("AccountNO_vc")
                    newrow("شماره شبا حساب 1") = r("Shabaaccount")
                    newrow("درصد تسهیم حساب 1") = "100"
                    newrow("شناسه شعبه حساب 1") = r("FanavaBranchID")
                    newrow("نام انگلیسی پذیرنده") = "eniac"
                    newrow("بازاریاب") = "1036747"

                    FanavaFormatdt.Rows.Add(newrow)
                Next


                clsExcel.Write(FanavaFormatdt)
            End If

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub cmbHeaderNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHeaderNumber.SelectedIndexChanged
        Try
            If (Me.cmbHeaderNumber.SelectedIndex <> -1) Then
                Me.ShowInfo(Me.cmbHeaderNumber.SelectedValue)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class