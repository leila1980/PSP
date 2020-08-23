Public Class frmRptGetAllTransactionsSummary

#Region "Declare Variables"

    Public Enum ReportGroup As Byte
        Outlet = 1
        State = 2
        City = 3
        Management = 4
        Branch = 5
        Visitor = 6
        SourceBank = 7
    End Enum

    Dim dtReportByOutletColumns As New DataTable()
    Dim dtReportByStateColumns As New DataTable()
    Dim dtReportByCityColumns As New DataTable()
    Dim dtReportByManagementColumns As New DataTable()
    Dim dtReportByBranchColumns As New DataTable()
    Dim dtReportByVisitorColumns As New DataTable()
    Dim dtReportBySourceBankColumns As New DataTable()

    Dim dtReport As New DataTable()
    Dim clsDalReport2 As New ClassDALReport_2(modPublicMethod.ConnectionString)
#End Region

#Region "Handle Select & Deselect Buttons"

    Private Sub btnSelectAllVisitors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAllVisitors.Click
        For Each dr As DataGridViewRow In dgvVisitors.Rows
            dr.Cells("colSelectedVisitor").Value = True
        Next

    End Sub

    Private Sub btnSelectNoneVisitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNoneVisitor.Click
        For Each dr As DataGridViewRow In dgvVisitors.Rows
            dr.Cells("colSelectedVisitor").Value = False
        Next
    End Sub

    Private Sub btnReverseVisitorSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReverseVisitorSelection.Click
        For Each dr As DataGridViewRow In dgvVisitors.Rows
            dr.Cells("colSelectedVisitor").Value = Not Convert.ToBoolean(dr.Cells("colSelectedVisitor").Value)
        Next
    End Sub

    Private Sub btnSelectAllReportColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAllReportColumns.Click
        For Each dr As DataGridViewRow In dgvReportColumns.Rows
            dr.Cells("colSelectedReportColumn").Value = True
        Next
    End Sub

    Private Sub btnSelectNoneReportColumns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNoneReportColumns.Click
        For Each dr As DataGridViewRow In dgvReportColumns.Rows
            dr.Cells("colSelectedReportColumn").Value = False
        Next
    End Sub

    Private Sub btnReverseReportColumnsSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReverseReportColumnsSelection.Click
        For Each dr As DataGridViewRow In dgvReportColumns.Rows
            dr.Cells("colSelectedReportColumn").Value = Not Convert.ToBoolean(dr.Cells("colSelectedReportColumn").Value)
        Next
    End Sub
#End Region

#Region "Form Load"
    Private Sub FillVisitors()
        Dim clsDalVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)

        clsDalVisitor.BeginProc()

        Try
            Dim dt As DataTable = clsDalVisitor.GetAll()
            dgvVisitors.AutoGenerateColumns = False
            dgvVisitors.DataSource = dt

        Catch ex As Exception

        End Try

    End Sub
    Private Sub FillProjects()
        Dim clsDalProject As New ClassDALProject(modPublicMethod.ConnectionString)
        clsDalProject.BeginProc()
        Try
            Dim dt As DataTable = clsDalProject.GetAll()
            dgvProject.AutoGenerateColumns = False
            dgvProject.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillReportColumnDatatables()

        dtReportByOutletColumns.Columns.Add("ReportColumnEN")
        dtReportByOutletColumns.Columns.Add("ReportColumnFA")
        dtReportByOutletColumns.Rows.Add("Outlet_vc", "کد پایانه")
        dtReportByOutletColumns.Rows.Add("FullName", "نام پذیرنده")
        dtReportByOutletColumns.Rows.Add("NationalCode_nvc", "کد ملی")
        dtReportByOutletColumns.Rows.Add("Management", "کد مدیریت")
        dtReportByOutletColumns.Rows.Add("ManagementName", "نام مدیریت")
        dtReportByOutletColumns.Rows.Add("BranchID", "کد شعبه")
        dtReportByOutletColumns.Rows.Add("BranchName", "نام شعبه")
        dtReportByOutletColumns.Rows.Add("AccountNo_vc", "شماره حساب")
        dtReportByOutletColumns.Rows.Add("StoreName", "نام فروشگاه")
        dtReportByOutletColumns.Rows.Add("GroupID", "کد صنف")
        dtReportByOutletColumns.Rows.Add("GroupName", "نام صنف")
        dtReportByOutletColumns.Rows.Add("StateName", "نام استان")
        dtReportByOutletColumns.Rows.Add("CityName", "نام شهر")
        dtReportByOutletColumns.Rows.Add("Tel1_vc", "تلفن 1")
        dtReportByOutletColumns.Rows.Add("Tel2_vc", "تلفن 2")
        dtReportByOutletColumns.Rows.Add("Mobile_vc", "موبایل")
        dtReportByOutletColumns.Rows.Add("Address_nvc", "آدرس")
        dtReportByOutletColumns.Rows.Add("PostCode_vc", "کد پستی")
        dtReportByOutletColumns.Rows.Add("VisitorName", "نام بازاریاب")
        dtReportByOutletColumns.Rows.Add("MarketingBy", "نوع بازاریابی")
        dtReportByOutletColumns.Rows.Add("ContractID", "کد قرارداد")
        dtReportByOutletColumns.Rows.Add("Merchant_vc", "شماره پذیرنده")
        dtReportByOutletColumns.Rows.Add("EniacCode_vc", "کد پیگیری")
        dtReportByOutletColumns.Rows.Add("PropertyNo_vc", "کد اموال")
        dtReportByOutletColumns.Rows.Add("Serial_vc", "شماره سریال")
        dtReportByOutletColumns.Rows.Add("PosStatus", "وضعیت دستگاه")
        dtReportByOutletColumns.Rows.Add("PosModelName", "مدل دستگاه")
        dtReportByOutletColumns.Rows.Add("AppVersion", "ورژن دستگاه")
        dtReportByOutletColumns.Rows.Add("InstallDate", "تاریخ نصب")
        dtReportByOutletColumns.Rows.Add("PeykarBandi", "تاریخ پیکربندی")
        dtReportByOutletColumns.Rows.Add("TakhsisDate", "تاریخ تخصیص")
        dtReportByOutletColumns.Rows.Add("LastDate", "آخرین تاریخ خرید")
        dtReportByOutletColumns.Rows.Add("CancelDate", "تاریخ فسخ")
        dtReportByOutletColumns.Rows.Add("cmsprojects", "پروژه cms")
        dtReportByOutletColumns.Rows.Add("DeviceID", "کد دستگاه")


        dtReportByStateColumns.Columns.Add("ReportColumnEN")
        dtReportByStateColumns.Columns.Add("ReportColumnFA")
        dtReportByStateColumns.Rows.Add("StateID", "کد استان")
        dtReportByStateColumns.Rows.Add("StateName", "نام استان")
        dtReportByStateColumns.Rows.Add("Store_Count", "تعداد پذیرنده")
        dtReportByStateColumns.Rows.Add("Device_Count", "تعداد دستگاه")
        dtReportByStateColumns.Rows.Add("ActivePos_Count", "تعداد دستگاه فعال")
        dtReportByStateColumns.Rows.Add("Canceled_Count", "تعداد فسخ شده")
        dtReportByStateColumns.Rows.Add("InstallDismissed_Count", "تعداد انصراف از نصب")
        dtReportByStateColumns.Rows.Add("Installed_Count", "تعداد نصب شده")
        dtReportByStateColumns.Rows.Add("ContractBlocked_Count", "تعداد انصراف از قرارداد")
        dtReportByStateColumns.Rows.Add("NotInstalled_Count", "تعداد نصب نشده")
        dtReportByStateColumns.Rows.Add("AverageCount", "سرانه تعداد")
        dtReportByStateColumns.Rows.Add("AverageAmount", "سرانه مبلغ")



        dtReportByCityColumns.Columns.Add("ReportColumnEN")
        dtReportByCityColumns.Columns.Add("ReportColumnFA")
        dtReportByCityColumns.Rows.Add("StateID", "کد استان")
        dtReportByCityColumns.Rows.Add("StateName", "نام استان")
        dtReportByCityColumns.Rows.Add("CityID", "کد شهر")
        dtReportByCityColumns.Rows.Add("CityName", "نام شهر")
        dtReportByCityColumns.Rows.Add("Store_Count", "تعداد پذیرنده")
        dtReportByCityColumns.Rows.Add("Device_Count", "تعداد دستگاه")
        dtReportByCityColumns.Rows.Add("ActivePos_Count", "تعداد دستگاه فعال")
        dtReportByCityColumns.Rows.Add("Canceled_Count", "تعداد فسخ شده")
        dtReportByCityColumns.Rows.Add("InstallDismissed_Count", "تعداد انصراف از نصب")
        dtReportByCityColumns.Rows.Add("Installed_Count", "تعداد نصب شده")
        dtReportByCityColumns.Rows.Add("ContractBlocked_Count", "تعداد انصراف از قرارداد")
        dtReportByCityColumns.Rows.Add("NotInstalled_Count", "تعداد نصب نشده")
        dtReportByCityColumns.Rows.Add("AverageCount", "سرانه تعداد")
        dtReportByCityColumns.Rows.Add("AverageAmount", "سرانه مبلغ")


        dtReportByManagementColumns.Columns.Add("ReportColumnEN")
        dtReportByManagementColumns.Columns.Add("ReportColumnFA")
        dtReportByManagementColumns.Rows.Add("ManagementID", "کد مدیریت")
        dtReportByManagementColumns.Rows.Add("ManagementName", "نام مدیریت")
        dtReportByManagementColumns.Rows.Add("Store_Count", "تعداد پذیرنده")
        dtReportByManagementColumns.Rows.Add("Device_Count", "تعداد دستگاه")
        dtReportByManagementColumns.Rows.Add("ActivePos_Count", "تعداد دستگاه فعال")
        dtReportByManagementColumns.Rows.Add("Canceled_Count", "تعداد فسخ شده")
        dtReportByManagementColumns.Rows.Add("InstallDismissed_Count", "تعداد انصراف از نصب")
        dtReportByManagementColumns.Rows.Add("Installed_Count", "تعداد نصب شده")
        dtReportByManagementColumns.Rows.Add("ContractBlocked_Count", "تعداد انصراف از قرارداد")
        dtReportByManagementColumns.Rows.Add("NotInstalled_Count", "تعداد نصب نشده")
        dtReportByManagementColumns.Rows.Add("AverageCount", "سرانه تعداد")
        dtReportByManagementColumns.Rows.Add("AverageAmount", "سرانه مبلغ")


        dtReportByBranchColumns.Columns.Add("ReportColumnEN")
        dtReportByBranchColumns.Columns.Add("ReportColumnFA")
        dtReportByBranchColumns.Rows.Add("ManagementID", "کد مدیریت")
        dtReportByBranchColumns.Rows.Add("ManagementName", "نام مدیریت")
        dtReportByBranchColumns.Rows.Add("BranchID", "کد شعبه")
        dtReportByBranchColumns.Rows.Add("BranchName", "نام شعبه")
        dtReportByBranchColumns.Rows.Add("Store_Count", "تعداد پذیرنده")
        dtReportByBranchColumns.Rows.Add("Device_Count", "تعداد دستگاه")
        dtReportByBranchColumns.Rows.Add("ActivePos_Count", "تعداد دستگاه فعال")
        dtReportByBranchColumns.Rows.Add("Canceled_Count", "تعداد فسخ شده")
        dtReportByBranchColumns.Rows.Add("InstallDismissed_Count", "تعداد انصراف از نصب")
        dtReportByBranchColumns.Rows.Add("Installed_Count", "تعداد نصب شده")
        dtReportByBranchColumns.Rows.Add("ContractBlocked_Count", "تعداد انصراف از قرارداد")
        dtReportByBranchColumns.Rows.Add("NotInstalled_Count", "تعداد نصب نشده")
        dtReportByBranchColumns.Rows.Add("AverageCount", "سرانه تعداد")
        dtReportByBranchColumns.Rows.Add("AverageAmount", "سرانه مبلغ")


        dtReportByVisitorColumns.Columns.Add("ReportColumnEN")
        dtReportByVisitorColumns.Columns.Add("ReportColumnFA")
        dtReportByVisitorColumns.Rows.Add("VisitorID", "کد نماینده")
        dtReportByVisitorColumns.Rows.Add("VisitorName", "نام نماینده")
        dtReportByVisitorColumns.Rows.Add("Store_Count", "تعداد پذیرنده")
        dtReportByVisitorColumns.Rows.Add("Device_Count", "تعداد دستگاه")
        dtReportByVisitorColumns.Rows.Add("ActivePos_Count", "تعداد دستگاه فعال")
        dtReportByVisitorColumns.Rows.Add("Canceled_Count", "تعداد فسخ شده")
        dtReportByVisitorColumns.Rows.Add("InstallDismissed_Count", "تعداد انصراف از نصب")
        dtReportByVisitorColumns.Rows.Add("Installed_Count", "تعداد نصب شده")
        dtReportByVisitorColumns.Rows.Add("ContractBlocked_Count", "تعداد انصراف از قرارداد")
        dtReportByVisitorColumns.Rows.Add("NotInstalled_Count", "تعداد نصب نشده")
        dtReportByVisitorColumns.Rows.Add("AverageCount", "سرانه تعداد")
        dtReportByVisitorColumns.Rows.Add("AverageAmount", "سرانه مبلغ")

        dgvReportColumns.AutoGenerateColumns = False




    End Sub

    Private Sub FillChartTypes()
        cmbChartType.DataSource = [Enum].GetNames(GetType(System.Windows.Forms.DataVisualization.Charting.SeriesChartType))
        cmbChartType.SelectedItem = "Column"
    End Sub

    Private Sub frmRptGetAllTransactionsSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillVisitors()
        FillProjects()
        FillReportColumnDatatables()
        GetTransactionTypes()
        FillChartTypes()
        cmbReportGroup.SelectedIndex = 0
        cmbTransactionState.SelectedIndex = 0
    End Sub

#End Region

#Region "TreeView"
    Private Sub GetTransactionTypes()
        Dim clsDalTransaction As New ClassDALTransaction(modPublicMethod.ConnectionString)

        clsDalTransaction.BeginProc()
        Dim dt As DataTable = clsDalTransaction.GetTransactionTypes()
        clsDalTransaction.EndProc()

        Dim root As New TreeNode()
        root.Name = "0"
        root.Text = "تمام تراکنش ها"
        GetChildTransactionTypes(root, dt)
        trvTransactionType.Nodes.Add(root)
        trvTransactionType.ExpandAll()


    End Sub

    Private Function GetChildTransactionTypes(ByVal parent As TreeNode, ByVal dt As DataTable) As Boolean
        For Each dr As DataRow In dt.Select("ParentTransactionTypeID = " + parent.Name)
            Dim child As New TreeNode()
            child.Text = dr.Item("TransactionTypeDesc_nvc").ToString()
            child.Name = dr.Item("TransactionTypeID").ToString()
            If dt.Select("ParentTransactionTypeID = " + child.Name).Length > 0 Then
                GetChildTransactionTypes(child, dt)
            End If
            parent.Nodes.Add(child)
        Next

    End Function

    Private Sub trvTransactionType_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvTransactionType.AfterCheck
        RemoveHandler trvTransactionType.AfterCheck, AddressOf trvTransactionType_AfterCheck

        checkNodes(e.Node, e.Node.Checked)

        AddHandler trvTransactionType.AfterCheck, AddressOf trvTransactionType_AfterCheck
    End Sub

    Private Sub checkNodes(ByVal parent As TreeNode, ByVal value As Boolean)
        parent.Checked = value
        If parent.Nodes.Count > 0 Then
            For Each node As TreeNode In parent.Nodes
                checkNodes(node, value)
            Next
        End If
    End Sub

    Private Function ReadCheckedNodes(ByVal node As TreeNode) As String
        Dim NodeStr As String = String.Empty
        Dim tmpStr As String = String.Empty
        If node.Nodes.Count > 0 Then
            For Each chNode As TreeNode In node.Nodes
                tmpStr = ReadCheckedNodes(chNode)
                If tmpStr.Length > 0 Then NodeStr = NodeStr + "," + tmpStr
            Next
        End If
        If node.Checked = True Then
            NodeStr = NodeStr + "," + node.Name
        End If
        If NodeStr.Length > 0 Then NodeStr = NodeStr.Remove(0, 1)


        Return NodeStr


    End Function
#End Region

#Region "Event Handlers"
    Private Sub cmbReportGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReportGroup.SelectedIndexChanged
        SetDgvReportColumns()
        If cmbReportGroup.SelectedIndex = 0 Then
            tbcMain.TabPages.Remove(tbpChart)
        ElseIf Not tbcMain.TabPages.Contains(tbpChart) Then
            tbcMain.TabPages.Add(tbpChart)
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

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        dgvReportColumns.EndEdit()
        dgvVisitors.EndEdit()
        Dim VisitorIDstr As String = ""
        Dim ProjectIDstr As String = String.Empty
        Dim TransactionTypeIDstr As String = String.Empty
        Dim FromDate As String = String.Empty
        Dim ToDate As String = String.Empty
        Dim FromTransactionCount As Long = -1
        Dim ToTransactionCount As Long = -1
        Dim FromTotalPrice As Decimal = -1
        Dim ToTotalPrice As Decimal = -1
        Dim FromPrice As Decimal = -1
        Dim ToPrice As Decimal = -1
        Dim AuthorizationState As Short = -1
        Dim Parent As Short = -1
        Dim activePosDefenition As Short = 0

        '------------------------------------------------------------------
        If Long.TryParse(IIf(String.IsNullOrEmpty(txtFromTransaction.Text), "-1", txtFromTransaction.Text), FromTransactionCount) Then
            erp.SetError(txtFromTransaction, String.Empty)
        Else
            erp.SetError(txtFromTransaction, "مقدار وارد شده نامعتبر است")
            Exit Sub
        End If

        If Long.TryParse(IIf(String.IsNullOrEmpty(txtToTransaction.Text), "-1", txtToTransaction.Text), ToTransactionCount) Then
            erp.SetError(txtToTransaction, String.Empty)
        Else
            erp.SetError(txtToTransaction, "مقدار وارد شده نامعتبر است")
            Exit Sub
        End If

        If Decimal.TryParse(IIf(String.IsNullOrEmpty(txtFromTotalPrice.Text), "-1", txtFromTotalPrice.Text), FromTotalPrice) Then
            erp.SetError(txtFromTotalPrice, String.Empty)
        Else
            erp.SetError(txtFromTotalPrice, "مقدار وارد شده نامعتبر است")
            Exit Sub
        End If


        If Decimal.TryParse(IIf(String.IsNullOrEmpty(txtToTotalPrice.Text), "-1", txtToTotalPrice.Text), ToTotalPrice) Then
            erp.SetError(txtToTotalPrice, String.Empty)
        Else
            erp.SetError(txtToTotalPrice, "مقدار وارد شده نامعتبر است")
            Exit Sub
        End If

        If Decimal.TryParse(IIf(String.IsNullOrEmpty(txtFromPrice.Text), "-1", txtFromPrice.Text), FromPrice) Then
            erp.SetError(txtFromPrice, String.Empty)
        Else
            erp.SetError(txtFromPrice, "مقدار وارد شده نامعتبر است")
            Exit Sub
        End If

        If Decimal.TryParse(IIf(String.IsNullOrEmpty(txtToPrice.Text), "-1", txtToPrice.Text), ToPrice) Then
            erp.SetError(txtToPrice, String.Empty)
        Else
            erp.SetError(txtToPrice, "مقدار وارد شده نامعتبر است")
            Exit Sub
        End If

        AuthorizationState = cmbTransactionState.SelectedIndex


        If rdbActivePos0.Checked Then
            activePosDefenition = 0
        ElseIf rdbActivePos1.Checked Then
            activePosDefenition = 1
        End If

        If chkParent.Checked Then Parent = 1

        For Each dr As DataGridViewRow In dgvVisitors.Rows
            If Convert.ToBoolean(dr.Cells("colSelectedVisitor").Value) Then
                VisitorIDstr = VisitorIDstr + "," + dr.Cells("colVisitorID").Value.ToString()
            End If
        Next
        If VisitorIDstr.Length > 0 Then
            VisitorIDstr = VisitorIDstr.Remove(0, 1)
        End If


        For Each dr As DataGridViewRow In dgvProject.Rows
            If Convert.ToBoolean(dr.Cells("colSelectedProject").Value) Then
                ProjectIDstr = ProjectIDstr + "," + dr.Cells("colProjectID").Value.ToString()
            End If
        Next
        If ProjectIDstr.Length > 0 Then
            ProjectIDstr = ProjectIDstr.Remove(0, 1)
        End If

        Dim tmpstr As String

        For Each node As TreeNode In trvTransactionType.Nodes
            If node.Checked Then
                'TransactionTypeIDstr = TransactionTypeIDstr + "," + node.Name
                tmpstr = ReadCheckedNodes(node)
                If tmpstr.Length > 0 Then TransactionTypeIDstr = TransactionTypeIDstr + "," + tmpstr
            End If
        Next
        If TransactionTypeIDstr.Length > 0 Then
            TransactionTypeIDstr = TransactionTypeIDstr.Remove(0, 1)
        End If

        If rucDate.cboDate.SelectedIndex = 1 Then
            FromDate = rucDate.txtDateFrom.Value
            ToDate = rucDate.txtDateTo.Value
        Else
            FromDate = String.Empty
            ToDate = String.Empty
        End If

        Me.Cursor = Cursors.WaitCursor
        If cmbReportGroup.SelectedIndex = 0 Then  'گزارش بر اساس پایانه
            dtReport.Clear()
            dtReport = clsDalReport2.GetAllTransactionSummary_ByOutlet(VisitorIDstr, ProjectIDstr, TransactionTypeIDstr, FromDate, ToDate, FromTransactionCount, ToTransactionCount, FromTotalPrice, ToTotalPrice, FromPrice, ToPrice, AuthorizationState, Parent)
            dgvReport.DataSource = dtReport
            tbcMain.SelectedTab = tbpReportGrid
        ElseIf cmbReportGroup.SelectedIndex = 1 Then 'گزارش بر اساس استان
            dtReport.Clear()
            dtReport = clsDalReport2.GetAllTransactionSummary_ByState(VisitorIDstr, ProjectIDstr, TransactionTypeIDstr, FromDate, ToDate, FromTransactionCount, ToTransactionCount, FromTotalPrice, ToTotalPrice, FromPrice, ToPrice, AuthorizationState, Parent, activePosDefenition)
            dgvReport.DataSource = dtReport
            tbcMain.SelectedTab = tbpReportGrid
        ElseIf cmbReportGroup.SelectedIndex = 2 Then 'گزارش بر اساس شهر
            dtReport.Clear()
            dtReport = clsDalReport2.GetAllTransactionSummary_ByCity(VisitorIDstr, ProjectIDstr, TransactionTypeIDstr, FromDate, ToDate, FromTransactionCount, ToTransactionCount, FromTotalPrice, ToTotalPrice, FromPrice, ToPrice, AuthorizationState, Parent, activePosDefenition)
            dgvReport.DataSource = dtReport
            tbcMain.SelectedTab = tbpReportGrid
        ElseIf cmbReportGroup.SelectedIndex = 3 Then 'گزارش بر اساس مدیریت
            dtReport.Clear()
            dtReport = clsDalReport2.GetAllTransactionSummary_ByManagement(VisitorIDstr, ProjectIDstr, TransactionTypeIDstr, FromDate, ToDate, FromTransactionCount, ToTransactionCount, FromTotalPrice, ToTotalPrice, FromPrice, ToPrice, AuthorizationState, Parent, activePosDefenition)
            dgvReport.DataSource = dtReport
            tbcMain.SelectedTab = tbpReportGrid
        ElseIf cmbReportGroup.SelectedIndex = 4 Then 'گزارش بر اساس شعبه
            dtReport.Clear()
            dtReport = clsDalReport2.GetAllTransactionSummary_ByBranch(VisitorIDstr, ProjectIDstr, TransactionTypeIDstr, FromDate, ToDate, FromTransactionCount, ToTransactionCount, FromTotalPrice, ToTotalPrice, FromPrice, ToPrice, AuthorizationState, Parent, activePosDefenition)
            dgvReport.DataSource = dtReport
            tbcMain.SelectedTab = tbpReportGrid
        ElseIf cmbReportGroup.SelectedIndex = 5 Then 'گزارش بر اساس نماینده
            dtReport.Clear()
            dtReport = clsDalReport2.GetAllTransactionSummary_ByVisitor(VisitorIDstr, ProjectIDstr, TransactionTypeIDstr, FromDate, ToDate, FromTransactionCount, ToTransactionCount, FromTotalPrice, ToTotalPrice, FromPrice, ToPrice, AuthorizationState, Parent, activePosDefenition)
            dgvReport.DataSource = dtReport
            tbcMain.SelectedTab = tbpReportGrid
        End If
        Me.Cursor = Cursors.Default
        InitDgvReport()
        InitChartCombos()
    End Sub

#End Region

    Private Sub InitChartCombos()
        
        Dim dtchartcombo As New DataTable
        dtchartcombo.Columns.Add("EN")
        dtchartcombo.Columns.Add("FA")

        For Each cl As DataGridViewColumn In dgvReport.Columns
            If cl.Visible Then
                Dim row As DataRow = dtchartcombo.NewRow()
                row.Item("EN") = cl.Name
                row.Item("FA") = cl.HeaderText
                dtchartcombo.Rows.Add(row)
            End If
        Next
        cmbFirstColumn.DataSource = dtchartcombo
        cmbFirstColumn.ValueMember = "EN"
        cmbFirstColumn.DisplayMember = "FA"



    End Sub
    
#Region "Methods"

    Private Sub SetDgvReportColumns()
        If cmbReportGroup.SelectedIndex = 0 Then
            dgvReportColumns.DataSource = Nothing
            dgvReportColumns.DataSource = dtReportByOutletColumns
        ElseIf cmbReportGroup.SelectedIndex = 1 Then
            dgvReportColumns.DataSource = Nothing
            dgvReportColumns.DataSource = dtReportByStateColumns
        ElseIf cmbReportGroup.SelectedIndex = 2 Then
            dgvReportColumns.DataSource = Nothing
            dgvReportColumns.DataSource = dtReportByCityColumns
        ElseIf cmbReportGroup.SelectedIndex = 3 Then
            dgvReportColumns.DataSource = Nothing
            dgvReportColumns.DataSource = dtReportByManagementColumns
        ElseIf cmbReportGroup.SelectedIndex = 4 Then
            dgvReportColumns.DataSource = Nothing
            dgvReportColumns.DataSource = dtReportByBranchColumns
        ElseIf cmbReportGroup.SelectedIndex = 5 Then
            dgvReportColumns.DataSource = Nothing
            dgvReportColumns.DataSource = dtReportByVisitorColumns
        ElseIf cmbReportGroup.SelectedIndex = 6 Then
            dgvReportColumns.DataSource = Nothing
            dgvReportColumns.DataSource = dtReportBySourceBankColumns
        Else
            dgvReportColumns.DataSource = Nothing
        End If
    End Sub

    Private Sub InitDgvReport()
        For Each row As DataGridViewRow In dgvReportColumns.Rows
            If dgvReport.Columns.Contains(row.Cells("colReportColumnEN").Value.ToString()) Then
                dgvReport.Columns(row.Cells("colReportColumnEN").Value.ToString()).HeaderText = row.Cells("colReportColumnFA").Value.ToString()
                dgvReport.Columns(row.Cells("colReportColumnEN").Value.ToString()).Visible = Convert.ToBoolean(row.Cells("colSelectedReportColumn").Value)
            End If
        Next
        If cmbReportGroup.SelectedIndex = 1 Then ' پایانه
            If dgvReport.Columns.Contains("DeviceID1") Then
                dgvReport.Columns("DeviceID1").Visible = False
            End If
        ElseIf cmbReportGroup.SelectedIndex = 1 Then ' استان
            If dgvReport.Columns.Contains("StateID1") Then
                dgvReport.Columns("StateID1").Visible = False
            End If
        ElseIf cmbReportGroup.SelectedIndex = 2 Then ' شهر
            If dgvReport.Columns.Contains("StateID1") Then
                dgvReport.Columns("StateID1").Visible = False
            End If
            If dgvReport.Columns.Contains("CityID1") Then
                dgvReport.Columns("CityID1").Visible = False
            End If
        ElseIf cmbReportGroup.SelectedIndex = 3 Then ' مدیریت
            If dgvReport.Columns.Contains("Management") Then
                dgvReport.Columns("Management").Visible = False
            End If
        ElseIf cmbReportGroup.SelectedIndex = 4 Then ' شعبه
            If dgvReport.Columns.Contains("Management") Then
                dgvReport.Columns("Management").Visible = False
            End If
            If dgvReport.Columns.Contains("BranchID1") Then
                dgvReport.Columns("BranchID1").Visible = False
            End If
        ElseIf cmbReportGroup.SelectedIndex = 5 Then ' بازاریاب
            If dgvReport.Columns.Contains("VisitorID1") Then
                dgvReport.Columns("VisitorID1").Visible = False
            End If
        End If


    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowChart.Click
        Chart1.Series.Clear()
        Chart1.Series.Add("S1")
        Chart1.Series(0).ChartType = [Enum].Parse(GetType(System.Windows.Forms.DataVisualization.Charting.SeriesChartType), cmbChartType.SelectedItem.ToString)

        If cmbReportGroup.SelectedIndex = 1 Then
            Chart1.Series("S1").XValueMember = "StateName"
        ElseIf cmbReportGroup.SelectedIndex = 2 Then
            Chart1.Series("S1").XValueMember = "CityName"
        ElseIf cmbReportGroup.SelectedIndex = 3 Then
            Chart1.Series("S1").XValueMember = "ManagementName"
        ElseIf cmbReportGroup.SelectedIndex = 4 Then
            Chart1.Series("S1").XValueMember = "BranchName"
        ElseIf cmbReportGroup.SelectedIndex = 5 Then
            Chart1.Series("S1").XValueMember = "VisitorName"
        Else
            btnShowChart.Enabled = False
            Exit Sub
        End If


        Chart1.Series(0).YValueMembers = cmbFirstColumn.SelectedValue.ToString()
        Chart1.Series("S1").XValueType = DataVisualization.Charting.ChartValueType.String
        Chart1.Series(0).ToolTip = "#VALX"
        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.Series(0).IsValueShownAsLabel = True
        Chart1.Palette = DataVisualization.Charting.ChartColorPalette.Fire
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        Chart1.DataSource = dtReport

    End Sub
End Class