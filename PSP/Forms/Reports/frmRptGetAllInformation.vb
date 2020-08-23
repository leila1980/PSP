Public Class frmRptGetAllInformation
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private clsDALRPT2 As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Private clsDALRPTSina As New ClassDALReport_2Sina(modPublicMethod.SinaConnectionString)

    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim strFilter As String
    Private DateFrom As String = ""
    Private DateTO As String = ""
    Private VisitorID As String = String.Empty
    Private Vocher As Byte = 0
    Private Sale As Byte = 0
    Private Bill As Byte = 0
    Private Mojudi As Byte = 0
    Private dtdgv As New DataTable
    Private dvdgv As DataView

#Region "Events"

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

    Private Sub frmRptGeneral_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub frmRptGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            InitialForms()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

    Private Sub frmRptGeneral_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        DisposConnection()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        FillGrid()
    End Sub

    Private Sub txtFromTransaction_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromTransaction.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub txtToTransaction_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToTransaction.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub txtFromPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromPrice.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub txtToPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToPrice.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub dgvReport_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReport.CellClick
        Try
            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
            If e.ColumnIndex = dgvReport.Columns.Count - 1 Then

                Dim _Frm As New frmRptAuthorizationDetail
                _Frm._rucDate1 = rucDate
                _Frm.lblName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("FullName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("FullName").Value)
                _Frm.lblOutlet.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value)
                _Frm.lblCancelDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value)
                _Frm.lblInstallDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value)
                _Frm.lblMerchant.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value)
                _Frm.lblState.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value)
                _Frm.lblStoreName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("StoreName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("StoreName").Value)
                _Frm.lblVisitor.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value)
                _Frm.txtFromPrice.Text = txtFromPrice.Text
                _Frm.txtToPrice.Text = txtToPrice.Text
                _Frm.chkParent.Checked = chkParent.Checked
                _Frm.chkParent.Visible = chkParent.Visible
                If rucDate.cboDate.SelectedIndex = 1 Then
                    _Frm.rucDate.txtDateFrom.Value = rucDate.txtDateFrom.Value
                    _Frm.rucDate.txtDateTo.Value = rucDate.txtDateTo.Value
                    _Frm.DateFrom = rucDate.txtDateFrom.Value
                    _Frm.DateTO = rucDate.txtDateTo.Value
                Else
                    _Frm.rucDate.txtDateFrom.Value = String.Empty
                    _Frm.rucDate.txtDateTo.Value = String.Empty
                    _Frm.DateFrom = String.Empty
                    _Frm.DateTO = String.Empty
                End If

                _Frm.cmbTransactionState.SelectedIndex = cmbTransactionState.SelectedIndex
                For Counter As Integer = 0 To ChkList.CheckedItems.Count - 1
                    Select Case ChkList.CheckedItems.Item(Counter)
                        Case "شارژ"
                            _Frm.ChkList.SetItemChecked(0, True)
                            _Frm.Vocher = 1
                        Case "خرید"
                            _Frm.ChkList.SetItemChecked(1, True)
                            _Frm.Sale = 1
                        Case "پرداخت قبض"
                            _Frm.ChkList.SetItemChecked(2, True)
                            _Frm.Bill = 1
                        Case "موجودی"
                            _Frm.ChkList.SetItemChecked(3, True)
                            _Frm.Mojudi = 1
                    End Select
                Next
                _Frm.ShowDialog()
            
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub dgvReport_ColumnAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvReport.ColumnAdded
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("SaleTransactionsCount".ToLower, "تعداد تراکنش خرید")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("SaleTransactionAmountSum".ToLower, "مبلغ تراکنش خرید")

        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("BillTransactionsCount".ToLower, "تعداد تراکنش قبض")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("BillTransactionAmountSum".ToLower, "مبلغ تراکنش قبض")

        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("VoucherTransactionsCount".ToLower, "تعداد تراکنش شارژ")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("VoucherTransactionAmountSum".ToLower, "مبلغ تراکنش شارژ")

        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("MojudiTransactionsCount".ToLower, "تعداد تراکنش موجودی")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("MojudiTransactionAmountSum".ToLower, "مبلغ تراکنش موجودی")

        If e.Column.Name.ToLower.StartsWith("SaleTransactionsCount".ToLower) _
        Or e.Column.Name.ToLower.StartsWith("SaleTransactionAmountSum".ToLower) _
        Or e.Column.Name.ToLower.StartsWith("BillTransactionsCount".ToLower) _
        Or e.Column.Name.ToLower.StartsWith("BillTransactionAmountSum".ToLower) _
        Or e.Column.Name.ToLower.StartsWith("VoucherTransactionsCount".ToLower) _
        Or e.Column.Name.ToLower.StartsWith("VoucherTransactionAmountSum".ToLower) _
        Or e.Column.Name.ToLower.StartsWith("MojudiTransactionsCount".ToLower) _
        Or e.Column.Name.ToLower.StartsWith("MojudiTransactionAmountSum".ToLower) Then
            e.Column.DefaultCellStyle.Format = "N0"
        End If
    End Sub

    Private Sub dgvReport_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvReport.RowPrePaint
        Dim dataGridView As DataGridView = sender
        dataGridView.Item("colRowNumber", e.RowIndex).Value = e.RowIndex + 1
    End Sub

    Private Sub txtAdvariToPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdvariToPrice.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub txtMorediToPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMorediToPrice.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub dgvReport_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReport.CellDoubleClick
        Try

            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
            If (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("LastBazdid".ToLower) = True) Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountBazdid".ToLower) = True) Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("MorediLastBazdid".ToLower) = True) Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("MorediCountBazdid".ToLower) = True) Then
                Dim _Frm As New frmRptGetBazdidTransaction
                _Frm._rucDate1 = rucDate
                _Frm.lblName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("FullName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("FullName").Value)
                _Frm.lblOutlet.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value)
                _Frm.lblCancelDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value)
                _Frm.lblInstallDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value)
                _Frm.lblMerchant.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value)
                _Frm.lblState.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value)
                _Frm.lblStoreName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("StoreName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("StoreName").Value)
                _Frm.lblVisitor.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value)
                _Frm.txtAdvariToPrice.Text = txtAdvariToPrice.Text
                _Frm.txtMorediToPrice.Text = txtMorediToPrice.Text
                _Frm.chkParent.Checked = chkParent.Checked
                _Frm.chkParent.Visible = chkParent.Visible
                If (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("LastBazdid".ToLower) = True) Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountBazdid".ToLower) = True) Then
                    _Frm.Type = 1
                Else
                    _Frm.Type = 2
                End If
                If rucDate.cboDate.SelectedIndex = 1 Then
                    _Frm.rucDate.txtDateFrom.Value = String.Empty
                    _Frm.rucDate.txtDateTo.Value = rucDate.txtDateTo.Value
                    _Frm.DateFrom = String.Empty
                    _Frm.DateTO = rucDate.txtDateTo.Value
                Else
                    _Frm.rucDate.txtDateFrom.Value = String.Empty
                    _Frm.rucDate.txtDateTo.Value = String.Empty
                    _Frm.DateFrom = String.Empty
                    _Frm.DateTO = String.Empty
                End If
                _Frm.ShowDialog()
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

#End Region

#Region "Methods"

    Private Sub InitialForms()
        SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        If ClassUserLoginDataAccess.dtUserRightOnControls.Rows.Count > 0 Then
            Dim dr() As DataRow = ClassUserLoginDataAccess.dtUserRightOnControls.Select("ControlName_nvc = 'chkParent' And FormID = 81")
            If (dr.Length = 0) Then
                chkParent.Visible = False
            Else
                chkParent.Visible = dr(0)("Value_vc")
            End If
        Else
            chkParent.Visible = False
        End If
    End Sub

    Private Sub FormLoad()
        Try
            cmbTransactionState.SelectedIndex = 1
            FillCombo()
            cmbVisitor.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillGrid()
        Try
            Dim Parent As Byte = 0
            Dim dt As DataTable
            If cmbVisitor.SelectedValue = 0 Then
                dt = cmbVisitor.DataSource
                If dt.Rows(0)("State") = 0 Then
                    VisitorID = String.Empty
                Else
                    For Each dr As DataRow In dt.Select(" VisitorID <> 0 ")
                        If VisitorID = String.Empty Then
                            VisitorID = dr("VisitorID").ToString
                        Else
                            VisitorID = VisitorID & " ," & dr("VisitorID").ToString
                        End If
                    Next
                End If
            Else
                VisitorID = Convert.ToString(cmbVisitor.SelectedValue)
            End If


            If rucDate.cboDate.SelectedIndex = 1 Then
                DateFrom = rucDate.txtDateFrom.Value
                DateTO = rucDate.txtDateTo.Value
            Else
                DateFrom = ""
                DateTO = ""
            End If
            Vocher = 0
            Sale = 0
            Bill = 0
            Mojudi = 0
            For Counter As Integer = 0 To ChkList.CheckedItems.Count - 1
                Select Case ChkList.CheckedItems.Item(Counter)
                    Case "شارژ"
                        Vocher = 1
                    Case "خرید"
                        Sale = 1
                    Case "پرداخت قبض"
                        Bill = 1
                    Case "موجودی"
                        Mojudi = 1
                End Select
            Next

            If Vocher = 0 And Sale = 0 And Bill = 0 And Mojudi = 0 Then
                MsgBox("هیچ یک از انواع تراکنش انتخاب نشده است", MsgBoxStyle.Exclamation, "هشدار")
                Exit Sub
            End If
            If txtFromTransaction.Text Is String.Empty Then
                txtFromTransaction.Text = "0"
            End If
            If txtToTransaction.Text Is String.Empty Then
                txtToTransaction.Text = "0"
            End If
            If chkParent.Checked = True Then
                Parent = 1
            Else
                Parent = 0
            End If
            dgvReport.DataSource = ""
            dvdgv = New DataView
            dgvReport.Columns.Clear() ' ("btnColumn")

            Dim ColumnRowNumber As New DataGridViewTextBoxColumn()
            ColumnRowNumber.Name = "colRowNumber"
            ColumnRowNumber.HeaderText = "ردیف"
            dgvReport.Columns.Add(ColumnRowNumber)

            dtdgv = clsDALRPT2.GetAllInformation(VisitorID, DateFrom, DateTO, txtFromTransaction.Text, txtToTransaction.Text, txtFromPrice.Text, txtToPrice.Text, Vocher, Sale, Bill, Mojudi, cmbTransactionState.SelectedIndex, cmbProject.SelectedValue, Parent, txtAdvariToPrice.Text, txtMorediToPrice.Text)
            dgvReport.DataSource = dtdgv
            dvdgv = dtdgv.DefaultView

            Dim Column As New DataGridViewButtonColumn()
            Column.Name = "btnColumn"
            Column.HeaderText = "نمایش ریز تراکنش"
            Column.Text = "نمایش ریز تراکنش"
            Column.UseColumnTextForButtonValue = True
            dgvReport.Columns.Add(Column)

            InitGrid()

            Dim clsSearch As New ClassSearch
            clsSearch.Init(cboSearchField, cboSearchOperation, txtSearch, btnSearch, btnSearchBack, btnRemoveFilter, dgvReport, dtdgv, dvdgv)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub InitGrid()
        dgvReport.Columns("cmsprojects").HeaderText = "پروژه های CMS"

        dgvReport.Columns("FullName").HeaderText = "نام"
        dgvReport.Columns("ContractID").HeaderText = "کد قرارداد"
        dgvReport.Columns("Outlet_vc").HeaderText = "کد پایانه"
        dgvReport.Columns("Merchant_vc").HeaderText = "کد پذیرنده"
        dgvReport.Columns("Serial_vc").HeaderText = "سریال"
        dgvReport.Columns("PropertyNo_vc").HeaderText = "کد اموال"
        dgvReport.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
        dgvReport.Columns("AppVersion").HeaderText = "ورژن"
        dgvReport.Columns("MarketingBy").HeaderText = "نوع بازاریابی"
        dgvReport.Columns("VisitorName").HeaderText = "بازاریاب"
        dgvReport.Columns("StoreName").HeaderText = "نام فروشگاه"
        dgvReport.Columns("StateName").HeaderText = "نام استان"
        dgvReport.Columns("CityName").HeaderText = "نام شهر"
        dgvReport.Columns("Tel1_vc").HeaderText = "تلفن 1"
        dgvReport.Columns("Tel2_vc").HeaderText = "تلفن 2"
        dgvReport.Columns("Mobile_vc").HeaderText = "موبایل"
        dgvReport.Columns("NationalCode_nvc").HeaderText = "کد ملی"
        dgvReport.Columns("Address_nvc").HeaderText = "آدرس"
        dgvReport.Columns("PosStatus").HeaderText = "وضعیت"
        dgvReport.Columns("LastDate").HeaderText = "آخرین تراکنش خرید موفق"
        dgvReport.Columns("InstallDate").HeaderText = "تاریخ نصب"
        dgvReport.Columns("PeykarBandi").HeaderText = "تاریخ پیکربندی"
        dgvReport.Columns("CancelDate").HeaderText = "تاریخ فسخ"
        dgvReport.Columns("PaymentType").HeaderText = "نوع پرداخت"
        dgvReport.Columns("Batch_Clear_Status").HeaderText = "وضعیت پرداخت آخرین تراکنش"
        dgvReport.Columns("LastBazdid").HeaderText = "آخرین بازدید ادواری"
        dgvReport.Columns("CountBazdid").HeaderText = "تعداد بازدید ادواری"
        dgvReport.Columns("AccountNO_vc").HeaderText = "شماره حساب"

        dgvReport.Columns("MorediLastBazdid").HeaderText = "آخرین بازدید موردی"
        dgvReport.Columns("MorediCountBazdid").HeaderText = "تعداد بازدید موردی"

        dgvReport.Columns("CountOfShetabi").HeaderText = "تعداد شتابی"
        dgvReport.Columns("CountOfNotShetabi").HeaderText = "تعداد غیر شتابی"
        dgvReport.Columns("SumOfShetabi").HeaderText = "مبلغ شتابی"
        dgvReport.Columns("SumOfNotShetabi").HeaderText = "مبلغ غیر شتابی"
        dgvReport.Columns("TransactionsCount").HeaderText = "کل تراکنشها"
        dgvReport.Columns("TransactionAmountSum").HeaderText = "مبلغ تراکنشها"
        dgvReport.Columns("PostCode_vc").HeaderText = "کد پستی"

        dgvReport.Columns("GroupID").HeaderText = "کد صنف"
        dgvReport.Columns("GroupName").HeaderText = "نام صنف"
        dgvReport.Columns("BranchID").HeaderText = "کد شعبه"
        dgvReport.Columns("BranchName").HeaderText = "نام شعبه"
        dgvReport.Columns("ManagementID").HeaderText = "کد منطقه"
        dgvReport.Columns("ManagementName").HeaderText = "نام منطقه"


        dgvReport.Columns("SumOfShetabi").DefaultCellStyle.Format = "N0"
        dgvReport.Columns("SumOfNotShetabi").DefaultCellStyle.Format = "N0"
        dgvReport.Columns("TransactionAmountSum").DefaultCellStyle.Format = "N0"
        dgvReport.Columns("PosModelName").HeaderText = "نوع دستگاه"

        dgvReport.Columns("ProjectName").HeaderText = "پروژه"

        If dtdgv.Compute("Sum(CountOfShetabi)", "") Is DBNull.Value Then
            lblShetabiCount.Text = String.Empty
        Else
            lblShetabiCount.Text = FormatNumber(dtdgv.Compute("Sum(CountOfShetabi)", ""), 0)
        End If
        If dtdgv.Compute("Sum(CountOfNotShetabi)", "") Is DBNull.Value Then
            lblNotShetabiCount.Text = String.Empty
        Else
            lblNotShetabiCount.Text = FormatNumber(dtdgv.Compute("Sum(CountOfNotShetabi)", ""), 0)
        End If
        If dtdgv.Compute("Sum(SumOfShetabi)", "") Is DBNull.Value Then
            lblSumShetabi.Text = String.Empty
        Else
            lblSumShetabi.Text = FormatNumber(dtdgv.Compute("Sum(SumOfShetabi)", ""), 0)
        End If
        If dtdgv.Compute("Sum(SumOfNotShetabi)", "") Is DBNull.Value Then
            lblSumNotShetabi.Text = String.Empty
        Else
            lblSumNotShetabi.Text = FormatNumber(dtdgv.Compute("Sum(SumOfNotShetabi)", ""), 0)
        End If
        If dtdgv.Compute("Sum(TransactionsCount)", "") Is DBNull.Value Then
            lblSumOfCount.Text = String.Empty
        Else
            lblSumOfCount.Text = FormatNumber(dtdgv.Compute("Sum(TransactionsCount)", ""), 0)
        End If
        If dtdgv.Compute("Sum(TransactionAmountSum)", "") Is DBNull.Value Then
            lblSumOfPrice.Text = String.Empty
        Else
            lblSumOfPrice.Text = FormatNumber(dtdgv.Compute("Sum(TransactionAmountSum)", ""), 0)
        End If

        lblCount.Text = dgvReport.Rows.Count
    End Sub

    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        End If
    End Sub

    Private Sub DisposConnection()
        cnt.Close()
        cnt.Dispose()
        cnt = Nothing
    End Sub

    Private Sub FillCombo()
        Try
            OPenConnection()

            Me.cmbVisitor.DisplayMember = "FullName"
            Me.cmbVisitor.ValueMember = "VisitorID"
            Me.cmbVisitor.DataSource = clsDALVisitor.GetAllVisitorByUserID_ForCbo(ClassUserLoginDataAccess.ThisUser.UserID) 'clsDALVisitor.GetAllVisitor_ForCbo

            Dim clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

            Me.cmbProject.DataSource = clsDALProject.GetAllForUCtrl(ClassUserLoginDataAccess.ThisUser.UserID)
            Me.cmbProject.ValueMember = "ProjectID_tint"
            Me.cmbProject.DisplayMember = "Name_nvc"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region


End Class