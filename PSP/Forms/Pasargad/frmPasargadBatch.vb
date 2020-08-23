Public Class frmPasargadBatch
    Private dtDetail As New DataTable
    Private da As New ClassDALFanava(ConnectionString)

    Private Sub frmPasargadBatch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub

    Private Sub frmPasargadBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.GroupBox1.Dispose()
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.Text = "ساخت بچ پاسارگاد"
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
            Dim frm As New frmFanavaList(Me.dtDetail, My.Settings.Pasargard_CmsProjectID)
            frm.ShowDialog()
            Me.cmbHeaderNumber.SelectedIndex = -1
            Me.DataGridView1.DataSource = Me.dtDetail
        Else
            Me.dtDetail = da.GetByIDBatchDetail(Me.txtID_bint.Text)
            Dim frm As New frmFanavaList(Me.dtDetail, Me.txtID_bint.Text, My.Settings.Pasargard_CmsProjectID)
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
        dtDuplicat = da.GetByCountContractingParty_Contract_Account_Store_AvailableForBatch(1, ClassUserLoginDataAccess.ThisUser.ProjectID, My.Settings.Pasargard_CmsProjectID)

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
        dtDuplicat = da.GetByCountContractingParty_Contract_Account_Store_AvailableForBatch(1, ClassUserLoginDataAccess.ThisUser.ProjectID, My.Settings.Pasargard_CmsProjectID)
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
                dtDetail = da.GetByIDBatchDetailPasargad(Me.txtID_bint.Text)
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
            Me.cmbHeaderNumber.DataSource = da.GetAllHeaderNumbers(My.Settings.Pasargard_CmsProjectID)

            If (cmbHeaderNumber.Items.Count = 0) Then
                Me.DataGridView1.DataSource = Nothing
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Me.da.EndProc()
        End Try
    End Sub

    Public Overrides Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                Dim lstDataTable As List(Of DataTable) = New List(Of DataTable)
                Dim lstSheetName As List(Of String) = New List(Of String)
                Dim PasargadMerchantdt As New DataTable
                Dim PasargadPosdt As New DataTable
                Dim PasargadProjectdt As New DataTable
                Dim pasargadMappingCodeDictionary As Dictionary(Of String, String)

                ''''MERCHANT INFO SHEET
                PasargadMerchantdt.Columns.Add("MerchantEmployerId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantRequestDate", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantBankRegisterCode", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantTypeId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantNationalityId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantFirstName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantLastName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantGenderId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantTeleAreaCode", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantTeleNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantMobileNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantHomeAddress", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantShNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantNationalCode", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantBirthday", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantShIssuedCity", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantFatherName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantCompanyRegisterDate", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantPassportDueDate", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantPassportCode", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantRegisterarBankBranch", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("MerchantForeignerCode", Type.GetType("System.String"))

                ''''SHOP INFO
                PasargadMerchantdt.Columns.Add("ShopEstateTypeId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopRentContractNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopRentContractDueDate", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopTeleAreaCode", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopTeleNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopMobileNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopPostalCode", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopLatinName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopRegisterCity", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopGuildId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopProvinceId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopCityId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopCertificateNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopCertificateDueDate", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopCEOFullName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopContractSignerNationalCode", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopNationalId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopAddress", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ShopShaparakAddress", Type.GetType("System.String"))

                ''''ACCOUNT INFO 
                PasargadMerchantdt.Columns.Add("AccountTypeId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("AccountHolderFirstName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("AccountHolderLastName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("AccountFinancialInstituteId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("AccountFinancialInstituteBranchId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("AccountShebaNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("AccountNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("AccountFinancialInstituteSupervisionId", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("ProjectId", Type.GetType("System.String"))

                ''''REGENT INFO 
                PasargadMerchantdt.Columns.Add("Reagent1FirstName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent1LastName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent1TeleAreaCode", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent1TeleNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent1MobileNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent1HomeAddress", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent2FirstName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent2LastName", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent2TeleAreaCode", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent2TeleNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent2MobileNumber", Type.GetType("System.String"))
                PasargadMerchantdt.Columns.Add("Reagent2HomeAddress", Type.GetType("System.String"))

                ''''POS INFO SHEET
                PasargadPosdt.Columns.Add("POSEmployerId", Type.GetType("System.String"))
                PasargadPosdt.Columns.Add("POSRequestDate", Type.GetType("System.String"))
                PasargadPosdt.Columns.Add("MerchantBankRegisterCode", Type.GetType("System.String"))
                PasargadPosdt.Columns.Add("POSBankRegisterCode", Type.GetType("System.String"))
                PasargadPosdt.Columns.Add("POSTypeId", Type.GetType("System.String"))

                ''''PROJECT INFO SHEET
                PasargadProjectdt.Columns.Add("ID", Type.GetType("System.String"))
                PasargadProjectdt.Columns.Add("NAME", Type.GetType("System.String"))


                For Each r As DataRow In TryCast(DataGridView1.DataSource, DataTable).Rows
                    Dim merchantNewRow As DataRow = PasargadMerchantdt.NewRow
                    Dim posNewRow As DataRow = PasargadPosdt.NewRow
                    Dim projectNewRow As DataRow = PasargadProjectdt.NewRow

                    Dim miladiContractDate As String = ""
                    If (r("Date_vc") IsNot Nothing) Then
                        miladiContractDate = Convertor.ConvertMethods.DateToString(r("Date_vc"))
                    End If

                    Dim miladiBirthdate As String = ""
                    If Not (r("BirthDate_vc") Is Nothing Or r("BirthDate_vc").Equals(String.Empty)) Then
                        miladiBirthdate = Convertor.ConvertMethods.DateToString(r("BirthDate_vc"))
                    End If

                    pasargadMappingCodeDictionary = preparePasargadMappingCode(r("MerchantEmployerId"), r("SEstateConditionID"), TryCast(DataGridView1.DataSource, DataTable).Rows.IndexOf(r) + 2)


                    ''''MERCHANT
                    merchantNewRow("MerchantEmployerId") = r("MerchantEmployerId")
                    merchantNewRow("MerchantRequestDate") = miladiContractDate
                    merchantNewRow("MerchantBankRegisterCode") = pasargadMappingCodeDictionary.Item("merchantBankRegisterCode")
                    merchantNewRow("MerchantTypeId") = "1"
                    merchantNewRow("MerchantNationalityId") = "0"
                    merchantNewRow("MerchantFirstName") = r("FirstName_nvc")
                    merchantNewRow("MerchantLastName") = r("LastName_nvc")
                    merchantNewRow("MerchantGenderId") = IIf(r("Gender_bit") = 1, 0, 1)
                    merchantNewRow("MerchantTeleAreaCode") = r("areanumber_vc")
                    merchantNewRow("MerchantTeleNumber") = r("STel1_vc")
                    merchantNewRow("MerchantMobileNumber") = "0" + r("STel2_vc")
                    merchantNewRow("MerchantHomeAddress") = r("SAddress3_Nvc")
                    merchantNewRow("MerchantShNumber") = r("IdentityCertificateNO_nvc")
                    merchantNewRow("MerchantNationalCode") = r("NationalCode_nvc")
                    merchantNewRow("MerchantBirthday") = miladiBirthdate
                    merchantNewRow("MerchantShIssuedCity") = r("cityName")
                    merchantNewRow("MerchantFatherName") = r("FatherName_nvc")
                    merchantNewRow("MerchantCompanyRegisterDate") = String.Empty
                    merchantNewRow("MerchantPassportDueDate") = String.Empty
                    merchantNewRow("MerchantPassportCode") = String.Empty
                    merchantNewRow("MerchantRegisterarBankBranch") = "325"
                    merchantNewRow("MerchantForeignerCode") = String.Empty

                    ''''SHOP
                    merchantNewRow("ShopEstateTypeId") = pasargadMappingCodeDictionary.Item("shopEstateTypeId")
                    merchantNewRow("ShopRentContractNumber") = String.Empty
                    merchantNewRow("ShopRentContractDueDate") = String.Empty
                    merchantNewRow("ShopTeleAreaCode") = r("areanumber_vc")
                    merchantNewRow("ShopTeleNumber") = r("STel1_vc")
                    merchantNewRow("ShopMobileNumber") = "0" + r("STel2_vc")
                    merchantNewRow("ShopPostalCode") = r("SPostCode_vc")
                    merchantNewRow("ShopName") = r("SName_nvc")
                    merchantNewRow("ShopLatinName") = Convertor.ConvertMethods.FaToEnFirstLineString(r("SName_nvc"))
                    merchantNewRow("ShopRegisterCity") = String.Empty
                    merchantNewRow("ShopGuildId") = r("SGroupsupplementaryid").ToString
                    merchantNewRow("ShopProvinceId") = r("Pasargadstatecode")
                    merchantNewRow("ShopCityId") = r("Pasargadcitycode")
                    merchantNewRow("ShopCertificateNumber") = r("ContractID")
                    merchantNewRow("ShopCertificateDueDate") = "2050/05/02"
                    merchantNewRow("ShopCEOFullName") = String.Empty
                    merchantNewRow("ShopContractSignerNationalCode") = String.Empty
                    merchantNewRow("ShopNationalId") = String.Empty
                    merchantNewRow("ShopAddress") = r("SAddress3_Nvc")
                    merchantNewRow("ShopShaparakAddress") = r("SNEWADDRESS_NVC")

                    ''''ACCOUNT
                    merchantNewRow("AccountTypeId") = "1"
                    merchantNewRow("AccountHolderFirstName") = r("FirstName_nvc")
                    merchantNewRow("AccountHolderLastName") = r("LastName_nvc")
                    merchantNewRow("AccountFinancialInstituteId") = r("MerchantEmployerId")
                    merchantNewRow("AccountFinancialInstituteBranchId") = "111"
                    merchantNewRow("AccountShebaNumber") = r("Shabaaccount")
                    merchantNewRow("AccountNumber") = r("AAccountNO_vc")
                    merchantNewRow("AccountFinancialInstituteSupervisionId") = r("financialSupervisionId")
                    merchantNewRow("ProjectId") = r("ACCOUNTPROJECTID")

                    ''''REGENT
                    merchantNewRow("Reagent1FirstName") = String.Empty
                    merchantNewRow("Reagent1LastName") = String.Empty
                    merchantNewRow("Reagent1TeleAreaCode") = String.Empty
                    merchantNewRow("Reagent1TeleNumber") = String.Empty
                    merchantNewRow("Reagent1MobileNumber") = String.Empty
                    merchantNewRow("Reagent1HomeAddress") = String.Empty
                    merchantNewRow("Reagent2FirstName") = String.Empty
                    merchantNewRow("Reagent2LastName") = String.Empty
                    merchantNewRow("Reagent2TeleAreaCode") = String.Empty
                    merchantNewRow("Reagent2TeleNumber") = String.Empty
                    merchantNewRow("Reagent2MobileNumber") = String.Empty
                    merchantNewRow("Reagent2HomeAddress") = String.Empty

                    ''''POS
                    posNewRow("POSEmployerId") = r("MerchantEmployerId")
                    posNewRow("POSRequestDate") = miladiContractDate
                    posNewRow("MerchantBankRegisterCode") = pasargadMappingCodeDictionary.Item("merchantBankRegisterCode")
                    posNewRow("POSBankRegisterCode") = r("ContractID")
                    If r("Storeposmodelid") IsNot DBNull.Value Then
                        posNewRow("POSTypeId") = IIf(r("Storeposmodelid") = 1, 3, 1)
                    End If


                    ''''PROJECT
                    projectNewRow("ID") = r("ACCOUNTPROJECTID")
                    projectNewRow("Name") = r("ACCOUNTPROJECTNAME")

                    PasargadMerchantdt.Rows.Add(merchantNewRow)
                    PasargadPosdt.Rows.Add(posNewRow)
                    PasargadProjectdt.Rows.Add(projectNewRow)

                Next

                lstSheetName.Add("Merchant")
                lstSheetName.Add("POS")
                lstSheetName.Add("PROJECT")

                lstDataTable.Add(PasargadMerchantdt)
                lstDataTable.Add(PasargadPosdt)
                lstDataTable.Add(PasargadProjectdt)

                clsExcel.Write(lstDataTable, lstSheetName)
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

    Private Function preparePasargadMappingCode(ByVal merchantEmployerId As String, ByVal StoreEStateID As String, ByVal rowNumber As Integer) As Dictionary(Of String, String)

        Dim pasargadMappingCodeDictionary As New Dictionary(Of String, String)
        Dim merchantBankRegisterCode As String = ""
        Dim pOSBankRegisterCode As String = ""
        Dim shopEstateTypeId As String = ""

        pOSBankRegisterCode = Now().ToString().Replace("/", "").Substring(0, 8) + rowNumber.ToString
        merchantBankRegisterCode = merchantEmployerId + pOSBankRegisterCode

        Select Case StoreEStateID
            Case "106"
                shopEstateTypeId = "1"
            Case "111"
                shopEstateTypeId = "2"
            Case "123"
                shopEstateTypeId = "3"
            Case "125"
                shopEstateTypeId = "4"
        End Select

        pasargadMappingCodeDictionary.Add("merchantEmployerId", merchantEmployerId)
        pasargadMappingCodeDictionary.Add("merchantBankRegisterCode", merchantBankRegisterCode)
        pasargadMappingCodeDictionary.Add("pOSBankRegisterCode", pOSBankRegisterCode)
        pasargadMappingCodeDictionary.Add("shopEstateTypeId", shopEstateTypeId)

        Return pasargadMappingCodeDictionary

    End Function

End Class