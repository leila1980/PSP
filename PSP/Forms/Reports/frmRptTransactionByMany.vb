Public Class frmRptTransactionByMany
    Private clsDALReport As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Private clsDALBranch As New ClassDALBranch(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection

    Dim dv As New DataView

    Public FormType As Type
    Dim dtGridTrnsDetail As New DSReport.dtTransDetailDataTable
    Dim dtGridTrnsbranch As New DSReport.dtTransPerBranchDataTable
    Dim dtGridTrnsOutLet As New DSReport.dtTransPerOutLetDataTable
    Dim dtGridTrnsZone As New DSReport.dtTransPerZoneDataTable
    Dim dtGridTrnsSenf As New DSReport.dtTransPerSenfDataTable
    Dim dtGridTrnsNone As New DSReport.dtWithOutTransDataTable

    Private DateFrom As String = ""
    Private DateTO As String = ""
    Private AccountNo As String = ""
    Private BranchId As String = ""
    Private ZoneId As Integer = 0

    Public Enum Type As Short
        transaction_Detail = 1
        Transaction_Branch = 2
        Transaction_OutLet = 3
        Transaction_Zone = 4
        Transaction_None = 5
        Transaction_Senf = 6
    End Enum

#Region "Events"
    Private Sub frmRptTransactionByMany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            AccountNo = txtAccountNo.Text
            If cmbBranch.SelectedValue <> "" Then
                BranchId = cmbBranch.SelectedValue
            Else
                BranchId = ""
            End If
            If cmbZone.SelectedValue <> 0 Then
                ZoneId = cmbZone.SelectedValue
            Else
                ZoneId = 0
            End If

            If rucDate.cboDate.SelectedIndex = 1 Then
                DateFrom = rucDate.txtDateFrom.Value
                DateTO = rucDate.txtDateTo.Value
            Else
                DateFrom = ""
                DateTO = ""
            End If

            Me.Cursor = Cursors.WaitCursor
            FillGrid()
            InitGrid()
            Me.Cursor = Cursors.Default
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
    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvReport)
            End If

            'ExportToExcel()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
#End Region

#Region "Methods"
    Private Sub FormLoad()
        Try
            FillCombo2()
            Me.WindowState = FormWindowState.Maximized

            Select Case FormType
                Case Type.transaction_Detail
                    Me.Text = "گزارش ریز تراکنشها"
                    cmbBranch.Enabled = False
                    cmbZone.Enabled = False
                    txtAccountNo.Enabled = True
                Case Type.Transaction_OutLet
                    Me.Text = "گزارش سر جمع تراکنشها"
                    cmbBranch.Enabled = False
                    cmbZone.Enabled = False
                    txtAccountNo.Enabled = True
                Case Type.Transaction_Branch
                    Me.Text = "گزارش سر جمع تراکنشهای شعب"
                    cmbBranch.Enabled = True
                    cmbZone.Enabled = False
                    txtAccountNo.Enabled = False
                    FillCombo()
                Case Type.Transaction_Zone
                    Me.Text = "گزارش سر جمع تراکنشهای منطقه"
                    cmbBranch.Enabled = False
                    cmbZone.Enabled = True
                    txtAccountNo.Enabled = False
                    FillCombo()
                Case Type.Transaction_Senf
                    Me.Text = "گزارش سر جمع تراکنشهای صنف"
                    cmbBranch.Enabled = False
                    cmbZone.Enabled = False
                    txtAccountNo.Enabled = False
                Case Type.Transaction_None
                    Me.Text = "گزارش کم یا بدون تراکنشها"
                    cmbBranch.Enabled = False
                    cmbZone.Enabled = False
                    txtAccountNo.Enabled = True
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillCombo()
        Try
            OPenConnection()

            Select Case FormType
                Case Type.Transaction_Branch
                    Me.cmbBranch.DisplayMember = "Name_nvc"
                    Me.cmbBranch.ValueMember = "BranchID"
                    Me.cmbBranch.DataSource = clsDALBranch.GetAllTransactionalBranch_ForCbo
                Case Type.Transaction_Zone
                    Me.cmbZone.DisplayMember = "ZoneName"
                    Me.cmbZone.ValueMember = "ZoneID"
                    Me.cmbZone.DataSource = clsDALBranch.GetAllZones_ForCbo
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        Else

        End If
    End Sub
    Private Sub FillGrid()
        Try
            Select Case FormType
                Case Type.transaction_Detail
                    dtGridTrnsDetail.Clear()
                    clsDALReport.Transaction_Detail(DateFrom, DateTO, AccountNo, cmbProject.SelectedValue, dtGridTrnsDetail)
                    dv = dtGridTrnsDetail.DefaultView
                    If dtGridTrnsDetail.Rows.Count > 1 Then
                        lblAmountSum.Text = dtGridTrnsDetail.Compute("Sum(Amount)", "")
                    Else
                        lblAmountSum.Text = ""
                    End If
                    lblRowCount.Text = dtGridTrnsDetail.Rows.Count.ToString

                Case Type.Transaction_Branch
                    dtGridTrnsbranch.Clear()
                    clsDALReport.Transaction_Branch(DateFrom, DateTO, BranchId, cmbProject.SelectedValue, dtGridTrnsbranch)
                    dv = dtGridTrnsbranch.DefaultView
                    If dtGridTrnsbranch.Rows.Count > 1 Then
                        lblAmountSum.Text = dtGridTrnsbranch.Compute("Sum(TrnsSum)", "")
                        lblTotalCount.Text = dtGridTrnsbranch.Compute("Sum(TrnsCount)", "")
                        lblallnasbSum.Text = dtGridTrnsbranch.Compute("Sum(allnasb)", "")
                        lblAmountAvg.Text = dtGridTrnsbranch.Compute("Sum(TrnsSum)/Sum(allnasb)", "")
                        LblTrnCountAvg.Text = dtGridTrnsbranch.Compute("Sum(TrnsCount)/Sum(allnasb)", "")
                    Else
                        lblAmountSum.Text = ""
                        lblTotalCount.Text = ""
                        lblallnasbSum.Text = ""
                        lblAmountAvg.Text = ""
                        LblTrnCountAvg.Text = ""
                    End If
                    lblRowCount.Text = dtGridTrnsbranch.Rows.Count.ToString

                Case Type.Transaction_OutLet
                    dtGridTrnsOutLet.Clear()
                    clsDALReport.Transaction_OutLet(DateFrom, DateTO, AccountNo, cmbProject.SelectedValue, dtGridTrnsOutLet)
                    dv = dtGridTrnsOutLet.DefaultView
                    If dtGridTrnsOutLet.Rows.Count > 1 Then
                        lblAmountSum.Text = dtGridTrnsOutLet.Compute("Sum(TrnsSum)", "")
                        lblTotalCount.Text = dtGridTrnsOutLet.Compute("Sum(TrnsCount)", "")
                    Else
                        lblAmountSum.Text = ""
                        lblTotalCount.Text = ""
                    End If
                    lblRowCount.Text = dtGridTrnsOutLet.Rows.Count.ToString

                Case Type.Transaction_Zone
                    dtGridTrnsZone.Clear()
                    clsDALReport.Transaction_Zone(DateFrom, DateTO, ZoneId, cmbProject.SelectedValue, dtGridTrnsZone)
                    dv = dtGridTrnsZone.DefaultView
                    If dtGridTrnsZone.Rows.Count > 1 Then
                        lblAmountSum.Text = dtGridTrnsZone.Compute("Sum(TrnsSum)", "")
                        lblTotalCount.Text = dtGridTrnsZone.Compute("Sum(TrnsCount)", "")
                        lblallnasbSum.Text = dtGridTrnsZone.Compute("Sum(allnasb)", "")
                        lblAmountAvg.Text = dtGridTrnsZone.Compute("Sum(TrnsSum)/Sum(allnasb)", "")
                        LblTrnCountAvg.Text = dtGridTrnsZone.Compute("Sum(TrnsCount)/Sum(allnasb)", "")
                    Else
                        lblAmountSum.Text = ""
                        lblTotalCount.Text = ""
                        lblallnasbSum.Text = ""
                        lblAmountAvg.Text = ""
                        LblTrnCountAvg.Text = ""
                    End If
                    lblRowCount.Text = dtGridTrnsZone.Rows.Count.ToString
                Case Type.Transaction_Senf
                    dtGridTrnsSenf.Clear()
                    clsDALReport.Transaction_Senf(DateFrom, DateTO, cmbProject.SelectedValue, dtGridTrnsSenf)
                    dv = dtGridTrnsSenf.DefaultView
                    If dtGridTrnsSenf.Rows.Count > 1 Then
                        lblAmountSum.Text = dtGridTrnsSenf.Compute("Sum(TrnsSum)", "")
                        lblTotalCount.Text = dtGridTrnsSenf.Compute("Sum(TrnsCount)", "")
                        lblallnasbSum.Text = dtGridTrnsSenf.Compute("Sum(allnasb)", "")
                        lblAmountAvg.Text = dtGridTrnsSenf.Compute("Sum(TrnsSum)/Sum(allnasb)", "")
                        LblTrnCountAvg.Text = dtGridTrnsSenf.Compute("Sum(TrnsCount)/Sum(allnasb)", "")
                    Else
                        lblAmountSum.Text = ""
                        lblTotalCount.Text = ""
                        lblallnasbSum.Text = ""
                        lblAmountAvg.Text = ""
                        LblTrnCountAvg.Text = ""
                    End If
                    lblRowCount.Text = dtGridTrnsSenf.Rows.Count.ToString
                Case Type.Transaction_None
                    dtGridTrnsNone.Clear()
                    clsDALReport.WithOut_Transaction(DateFrom, DateTO, AccountNo, cmbProject.SelectedValue, dtGridTrnsNone)
                    dv = dtGridTrnsNone.DefaultView
                    If dtGridTrnsNone.Rows.Count > 1 Then
                        lblAmountSum.Text = dtGridTrnsNone.Compute("Sum(TrnsSum)", "")
                        lblTotalCount.Text = dtGridTrnsNone.Compute("Sum(TrnsCount)", "")
                    Else
                        lblAmountSum.Text = ""
                        lblTotalCount.Text = ""
                    End If
                    lblRowCount.Text = dtGridTrnsNone.Rows.Count.ToString

            End Select
            dgvReport.DataSource = dv
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Select Case FormType
            Case Type.transaction_Detail
                'dgvReport.Columns("OutLet").HeaderText = "شماره پایانه"
                dgvReport.Columns("AccountNo_vc").HeaderText = "شماره حساب"
                dgvReport.Columns("Stan").HeaderText = "شماره تراکنش"
                dgvReport.Columns("Amount").HeaderText = "مبلغ تراکنش"
                dgvReport.Columns("transaction_time_fa").HeaderText = "تاریخ"
                dgvReport.Columns("Address_nvc").HeaderText = "آدرس"
                dgvReport.Columns("Branch").HeaderText = "شعبه"
                dgvReport.Columns("FullName").HeaderText = "نام و نام خانوادگی"
                dgvReport.Columns("Zone").HeaderText = "منطقه"
                dgvReport.Columns("Amount").Width = 220
                dgvReport.Columns("Amount").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("OUTLET_vc").HeaderText = "شماره پایانه"

            Case Type.Transaction_Branch
                dgvReport.Columns("TrnsCount").HeaderText = "تعداد تراکنش"
                dgvReport.Columns("TrnsCount").Width = 220
                dgvReport.Columns("TrnsCount").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsAvg").HeaderText = "میانگین تراکنش"
                dgvReport.Columns("TrnsAvg").Width = 220
                dgvReport.Columns("TrnsAvg").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsSum").HeaderText = "جمع مبلغ تراکنش"
                dgvReport.Columns("TrnsSum").Width = 220
                dgvReport.Columns("TrnsSum").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("Branch").HeaderText = "شعبه"
                dgvReport.Columns("Zone").HeaderText = "منطقه"
                dgvReport.Columns("allnasb").HeaderText = "تعدادکل دستگاههای نصبی"
                dgvReport.Columns("amountavg").HeaderText = "میانگین مبلغ تراکنش"

            Case Type.Transaction_OutLet
                'dgvReport.Columns("OutLet").HeaderText = "شماره پایانه"
                dgvReport.Columns("AccountNo_vc").HeaderText = "شماره حساب"
                dgvReport.Columns("TrnsCount").HeaderText = "تعداد تراکنش"
                dgvReport.Columns("TrnsCount").Width = 220
                dgvReport.Columns("TrnsCount").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsAvg").HeaderText = "میانگین تراکنش"
                dgvReport.Columns("TrnsAvg").Width = 220
                dgvReport.Columns("TrnsAvg").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsSum").HeaderText = "جمع مبلغ تراکنش"
                dgvReport.Columns("TrnsSum").Width = 220
                dgvReport.Columns("TrnsSum").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("Address_nvc").HeaderText = "آدرس"
                dgvReport.Columns("Branch").HeaderText = "شعبه"
                dgvReport.Columns("FullName").HeaderText = "نام و نام خانوادگی"
                dgvReport.Columns("Zone").HeaderText = "منطقه"
                dgvReport.Columns("Statues").HeaderText = "وضعیت"
                dgvReport.Columns("OUTLET_vc").HeaderText = "شماره پایانه"
                dgvReport.Columns("statues").HeaderText = "وضعیت"

            Case Type.Transaction_Zone
                dgvReport.Columns("TrnsCount").HeaderText = "تعداد تراکنش"
                dgvReport.Columns("TrnsCount").Width = 220
                dgvReport.Columns("TrnsCount").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsAvg").HeaderText = "میانگین تراکنش"
                dgvReport.Columns("TrnsAvg").Width = 220
                dgvReport.Columns("TrnsAvg").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsSum").HeaderText = "جمع مبلغ تراکنش"
                dgvReport.Columns("TrnsSum").Width = 220
                dgvReport.Columns("TrnsSum").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("Zone").HeaderText = "منطقه"
                dgvReport.Columns("allnasb").HeaderText = "تعدادکل دستگاههای نصبی"
                dgvReport.Columns("amountavg").HeaderText = "میانگین مبلغ تراکنش"
            Case Type.Transaction_Senf
                dgvReport.Columns("TrnsCount").HeaderText = "تعداد تراکنش"
                dgvReport.Columns("TrnsCount").Width = 220
                dgvReport.Columns("TrnsCount").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsAvg").HeaderText = "میانگین تراکنش"
                dgvReport.Columns("TrnsAvg").Width = 220
                dgvReport.Columns("TrnsAvg").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsSum").HeaderText = "جمع مبلغ تراکنش"
                dgvReport.Columns("TrnsSum").Width = 220
                dgvReport.Columns("TrnsSum").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("senf").HeaderText = "صنف"
                dgvReport.Columns("allnasb").HeaderText = "تعدادکل دستگاههای نصبی"
                dgvReport.Columns("amountavg").HeaderText = "میانگین مبلغ تراکنش"

            Case Type.Transaction_None
                'dgvReport.Columns("OutLet").HeaderText = "شماره پایانه"
                dgvReport.Columns("AccountNo_vc").HeaderText = "شماره حساب"
                dgvReport.Columns("TrnsCount").HeaderText = "تعداد تراکنش"
                dgvReport.Columns("TrnsCount").Width = 220
                dgvReport.Columns("TrnsCount").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsAvg").HeaderText = "میانگین تراکنش"
                dgvReport.Columns("TrnsAvg").Width = 220
                dgvReport.Columns("TrnsAvg").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("TrnsSum").HeaderText = "جمع مبلغ تراکنش"
                dgvReport.Columns("TrnsSum").Width = 220
                dgvReport.Columns("TrnsSum").DefaultCellStyle.Format = "###,###.###"
                dgvReport.Columns("Address_nvc").HeaderText = "آدرس"
                dgvReport.Columns("Branch").HeaderText = "شعبه"
                dgvReport.Columns("FullName").HeaderText = "نام و نام خانوادگی"
                dgvReport.Columns("Zone").HeaderText = "منطقه"
                dgvReport.Columns("Statues").HeaderText = "وضعیت"
                dgvReport.Columns("OUTLET_vc").HeaderText = "شماره پایانه"
                dgvReport.Columns("statues").HeaderText = "وضعیت"
                dgvReport.Columns("tel1_vc").HeaderText = "تلفن"
        End Select
    End Sub

    Private Sub FillCombo2()
        Try
            OPenConnection()
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