Imports Oracle.DataAccess.Client

Public Class frmVoucherReport
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)
    Private clsDALRPT2 As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Dim cnt As New OracleConnection
    Private DateFrom As String = ""
    Private DateTO As String = ""
    Private dtdgv As New DataTable
    Private dvdgv As DataView
    Private ProjectID As Int16
    Private VisitorID As String = String.Empty

#Region "Method"

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

            Dim dt As New DataTable
            dt = clsDALProject.GetAll(ClassUserLoginDataAccess.ThisUser.UserID)
            If dt.Rows.Count > 1 Then
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("ProjectID_tint") = 0
                dr("Name_nvc") = "همه"
                dt.Rows.InsertAt(dr, 0)
            End If
            Me.cmbProject.DataSource = dt
            Me.cmbProject.DisplayMember = "Name_nvc"
            Me.cmbProject.ValueMember = "ProjectID_tint"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitialForms()
        SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
    End Sub

    Private Sub FormLoad()
        Try
            InitialForms()
            FillCombo()
            cmbVisitor.SelectedIndex = 0
            cmbProject.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillGrid()
        Try
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

            If cmbProject.SelectedValue = 0 Then
                ProjectID = -1
            Else
                ProjectID = cmbProject.SelectedValue
            End If

            If rucDate.cboDate.SelectedIndex = 1 Then
                DateFrom = rucDate.txtDateFrom.Value
                DateTO = rucDate.txtDateTo.Value
            Else
                DateFrom = ""
                DateTO = ""
            End If
            dgvReport.DataSource = ""
            dvdgv = New DataView
            dgvReport.Columns.Clear()

            Dim ColumnRowNumber As New DataGridViewTextBoxColumn()
            ColumnRowNumber.Name = "colRowNumber"
            ColumnRowNumber.HeaderText = "رديف"
            dgvReport.Columns.Add(ColumnRowNumber)

            dtdgv = clsDALRPT2.GetAllVoucherInformation(VisitorID, DateFrom, DateTO, ProjectID)
            dgvReport.DataSource = dtdgv
            dvdgv = dtdgv.DefaultView

            InitGrid()

            Dim clsSearch As New ClassSearch
            clsSearch.Init(cboSearchField, cboSearchOperation, txtSearch, btnSearch, btnSearchBack, btnRemoveFilter, dgvReport, dtdgv, dvdgv)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub InitGrid()
        Try

            Dim Column As New DataGridViewButtonColumn()
            dgvReport.Columns("FullName").HeaderText = "نام"
            dgvReport.Columns("Outlet_vc").Visible = False
            dgvReport.Columns("Code_vc").HeaderText = "کد پایانه"

            dgvReport.Columns("Serial_vc").HeaderText = "سریال"
            dgvReport.Columns("PropertyNo_vc").HeaderText = "کد اموال"
            dgvReport.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
            dgvReport.Columns("AppVersion").HeaderText = "ورژن"

            dgvReport.Columns("Merchant_vc").HeaderText = "کد پذیرنده"
            dgvReport.Columns("VisitorName").HeaderText = "بازاریاب"
            dgvReport.Columns("StoreName").HeaderText = "نام فروشگاه"
            dgvReport.Columns("StateName").HeaderText = "نام استان"
            dgvReport.Columns("CityName").HeaderText = "نام شهر"
            dgvReport.Columns("Tel1_vc").HeaderText = "تلفن"
            dgvReport.Columns("Address_nvc").HeaderText = "آدرس"
            dgvReport.Columns("PosStatus").HeaderText = "وضعیت"
            dgvReport.Columns("LastDate").HeaderText = "آخرین تراکنش خرید شارژ موفق"
            dgvReport.Columns("InstallDate").HeaderText = "تاریخ نصب"
            dgvReport.Columns("PeykarBandi").HeaderText = "تاریخ پیکربندی"
            dgvReport.Columns("CancelDate").HeaderText = "تاریخ فسخ"
            dgvReport.Columns("PostCode_vc").HeaderText = "کد پستی"

            dgvReport.Columns("Tel1_vc").HeaderText = "تلفن 1"
            dgvReport.Columns("Tel2_vc").HeaderText = "تلفن 2"
            dgvReport.Columns("Mobile_vc").HeaderText = "موبایل"
            dgvReport.Columns("NationalCode_nvc").HeaderText = "کد ملی"
            dgvReport.Columns("MarketingBy").HeaderText = "نوع بازاریابی"
            dgvReport.Columns("GroupID").HeaderText = "کد صنف"
            dgvReport.Columns("GroupName").HeaderText = "نام صنف"
            dgvReport.Columns("BranchID").HeaderText = "کد شعبه"
            dgvReport.Columns("BranchName").HeaderText = "نام شعبه"
            dgvReport.Columns("ManagementID").HeaderText = "کد منطقه"
            dgvReport.Columns("ManagementName").HeaderText = "نام منطقه"
            dgvReport.Columns("PosModelName").HeaderText = "نوع دستگاه"
            dgvReport.Columns("AllTransactionCount").HeaderText = "تعداد فروش کل وچرها"
            dgvReport.Columns("AllTransactionSUM").HeaderText = "مبلغ فروش کل وچرها"

            dgvReport.Columns("AllTransactionCount").DefaultCellStyle.Format = "N0"
            dgvReport.Columns("AllTransactionSUM").DefaultCellStyle.Format = "N0"

            If dtdgv.Compute("Sum(AllTransactionCount)", "") Is DBNull.Value Then
                lblSumOfCount.Text = String.Empty
            Else
                lblSumOfCount.Text = FormatNumber(dtdgv.Compute("Sum(AllTransactionCount)", ""), 0)
            End If
            If dtdgv.Compute("Sum(AllTransactionSUM)", "") Is DBNull.Value Then
                lblSumOfPrice.Text = String.Empty
            Else
                lblSumOfPrice.Text = FormatNumber(dtdgv.Compute("Sum(AllTransactionSUM)", ""), 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Event"

    Private Sub frmVoucherReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Try
            FillGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub dgvReport_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvReport.RowPrePaint
        Dim dataGridView As DataGridView = sender
        dataGridView.Item("colRowNumber", e.RowIndex).Value = e.RowIndex + 1
    End Sub

    Private Sub dgvReport_ColumnAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvReport.ColumnAdded
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("CountColumn".ToLower, "تعداد ")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("SumColumn".ToLower, "مبلغ ")

        If e.Column.Name.ToLower.StartsWith("CountColumn".ToLower) _
        Or e.Column.Name.ToLower.StartsWith("SumColumn".ToLower) Then
            e.Column.DefaultCellStyle.Format = "N0"
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
#End Region

End Class