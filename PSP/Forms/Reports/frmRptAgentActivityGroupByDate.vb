Public Class frmRptAgentActivityGroupByDate

    Private _DalVisitorClass As New ClassDALVisitor(ConnectionString)
    Private _DalReport_2 As New ClassDALReport_2(ConnectionString)
    Private _DALReport As New ClassDALReport(ConnectionString)
    Private _DALProject As New ClassDALProject(ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection

    Private VisitorID As String = String.Empty
    Private Vocher As Byte = 0
    Private Sale As Byte = 0
    Private Bill As Byte = 0
    Private Mojudi As Byte = 0
    Private FromDate As String = String.Empty
    Private ToDate As String = String.Empty
    Private DateType As Byte = 0
    Private CalcType As Byte = 0
    Private AuthorizationState As Byte = 0
    Dim dt As DSAgentActivityGroupByDate.dtAgentActivityGroupByDateDataTable
    Dim strReportName As String = String.Empty

    Private Sub SetTransactionType()
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
    End Sub

    Private Sub SetVisitor()
        Try
            VisitorID = String.Empty
            For Each dgvRow As DataGridViewRow In dgvVisitor.Rows
                If (dgvRow.Cells(CheckedBox.Name).Value Is Nothing) Then
                Else
                    If dgvRow.Cells(CheckedBox.Name).Value = True Then
                        If VisitorID = String.Empty Then
                            VisitorID = dgvRow.Cells(cboVisitorID.Name).Value.ToString
                        Else
                            VisitorID = VisitorID & " ," & dgvRow.Cells(cboVisitorID.Name).Value.ToString
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Function RequiredValidator() As Boolean
        Try
            Dim res As Boolean = True
            If rbtDaily.Checked = True Then
                If txtDateFrom.Value = "" Then
                    ErrorProvider.SetError(txtDateFrom, "از تاریخ را وارد کنید")
                    res = False
                Else
                    ErrorProvider.SetError(txtDateFrom, "")
                End If
                If txtDateTo.Value = "" Then
                    ErrorProvider.SetError(txtDateTo, "تا تاریخ را وارد کنید")
                    res = False
                Else
                    ErrorProvider.SetError(txtDateTo, "")
                End If
            End If
            If rbtMonthly.Checked = True Then
                If cboFromYear.SelectedIndex = -1 Then
                    ErrorProvider.SetError(cboFromYear, "سال از تاریخ را انتخاب کنید")
                    res = False
                Else
                    ErrorProvider.SetError(cboFromYear, "")
                End If
                If cboToYear.SelectedIndex = -1 Then
                    ErrorProvider.SetError(cboToYear, "سال تا تاریخ را انتخاب کنید")
                    res = False
                Else
                    ErrorProvider.SetError(cboToYear, "")
                End If
            End If
            SetTransactionType()
            If Vocher = 0 And Sale = 0 And Bill = 0 And Mojudi = 0 Then
                ErrorProvider.SetError(ChkList, "هیچ یک از انواع تراکنش انتخاب نشده است")
                res = False
            Else
                ErrorProvider.SetError(ChkList, "")
            End If

            SetVisitor()
            If VisitorID = String.Empty Then
                ErrorProvider.SetError(dgvVisitor, "هیچ یک از نمایندگان انتخاب نشده است")
                res = False
            Else
                ErrorProvider.SetError(dgvVisitor, "")
            End If
            Return res

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub rbtDaily_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDaily.CheckedChanged
        If rbtDaily.Checked = True Then
            pnlDaily.Visible = True
            pnlMonthly.Visible = False
        Else
            pnlDaily.Visible = False
            pnlMonthly.Visible = True
        End If
    End Sub

    Private Sub rbtMonthly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMonthly.CheckedChanged
        If rbtMonthly.Checked = True Then
            pnlDaily.Visible = False
            pnlMonthly.Visible = True
        Else
            pnlDaily.Visible = True
            pnlMonthly.Visible = False
        End If
    End Sub

    Private Sub FillVisitorGrid()
        Try
            Dim dt As New DataTable
            dt = _DalVisitorClass.GetAllVisitor_ForCbo(ClassUserLoginDataAccess.ThisUser.UserID)
            Dim dr() As DataRow = dt.Select(" VisitorID = 0 ")
            If dr.Length > 0 Then
                dr(0)("FullName_nvc") = "شرکت"
                dr(0).AcceptChanges()
            End If
            dgvVisitor.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

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

    Private Sub LoadForm()
        FillCombo()
        cboFromMonth.SelectedIndex = 0
        cboToMonth.SelectedIndex = 11
        cboAuthorizationState.SelectedIndex = 1
        cboCalcType.SelectedIndex = 0
        cboChart.SelectedIndex = 0
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        FillVisitorGrid()
        cboFromYear.DataSource = _DALReport.GetYear()
        Me.cboFromYear.DisplayMember = "ContractYear"
        Me.cboFromYear.ValueMember = "ContractYear"
        cboToYear.DataSource = _DALReport.GetYear()
        Me.cboToYear.DisplayMember = "ContractYear"
        Me.cboToYear.ValueMember = "ContractYear"
        cboFromYear.SelectedIndex = cboFromYear.Items.Count - 1
        cboToYear.SelectedIndex = cboToYear.Items.Count - 1
        InitialForms()
    End Sub

    Private Sub frmRptAgentActivityGroupByDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadForm()
    End Sub

    Private Sub dgvVisitor_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVisitor.CellEndEdit
        If (dgvVisitor.Rows.Count = 0) Or (e.RowIndex = -1) Or (e.ColumnIndex <> 0) Or (dgvVisitor.Rows(0).Cells(CheckedBox.Name).Value Is Nothing) Then Exit Sub
        If dgvVisitor.Rows(0).Cells(cboVisitorID.Name).Value = 0 And dgvVisitor.Rows(0).Cells(CheckedBox.Name).Value = True Then
            For intCounter As Integer = 1 To dgvVisitor.Rows.Count - 1
                dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).Value = False
                dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).ReadOnly = True
            Next
        Else
            For intCounter As Integer = 1 To dgvVisitor.Rows.Count - 1
                dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).ReadOnly = False
            Next
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Try

            Dim str As String = cboToYear.SelectedValue + "/" + Convert.ToString((cboToMonth.SelectedIndex + 1)).Trim.PadLeft(2, "0") + "/29"
            Dim MonthDays As String
            Select Case cboToMonth.SelectedIndex
                Case Is < 6
                    MonthDays = "31"
                Case 6 To 10
                    MonthDays = "30"
                Case 11
                    MonthDays = "29"
            End Select

            dgvVisitor.EndEdit()
            If RequiredValidator() = False Then Exit Sub

            If rbtDaily.Checked = True Then
                FromDate = txtDateFrom.Value
                ToDate = txtDateTo.Value
            Else
                FromDate = cboFromYear.SelectedValue + "/" + Convert.ToString((cboFromMonth.SelectedIndex + 1)).Trim.PadLeft(2, "0") + "/01"
                ToDate = cboToYear.SelectedValue + "/" + Convert.ToString((cboToMonth.SelectedIndex + 1)).Trim.PadLeft(2, "0") + "/" + MonthDays.Trim.PadLeft(2, "0")
            End If


            If rbtDaily.Checked = True Then
                DateType = 0
            Else
                DateType = 1
            End If
            SetTransactionType()
            SetVisitor()
            CalcType = cboCalcType.SelectedIndex

            AuthorizationState = cboAuthorizationState.SelectedIndex
            If VisitorID = "0" Then VisitorID = String.Empty
            dt = _DalReport_2.GetAgentActivityGroupByDate(VisitorID, DateType, FromDate, ToDate, CalcType, Vocher, Sale, Bill, Mojudi, AuthorizationState, txtFromPrice.Text, txtToPrice.Text, cboProject.SelectedValue, chkParent.Checked)

            dgvReport.DataSource = dt
            dgvReport.Columns("Date_vc").HeaderText = "تاریخ"
            dgvReport.Columns("VisitorID").HeaderText = "کد بازاریاب"
            dgvReport.Columns("FullName").HeaderText = "نام بازاریاب"
            dgvReport.Columns("ResultValue").HeaderText = "نتیجه"
            dgvReport.Columns("FullName").Width = 300
            If cboCalcType.SelectedIndex < 2 Then
                dgvReport.Columns("ResultValue").DefaultCellStyle.Format = "N0"
            Else
                dgvReport.Columns("ResultValue").DefaultCellStyle.Format = "N4"
            End If

            Dim r As New rptAgentActivityGroupByDate
            r.SetDataSource(DirectCast(dt, DataTable))

            r.SetParameterValue("ChartType", cboChart.SelectedIndex)

            If cboProject.SelectedIndex = 0 Then
                strReportName = cboCalcType.Text + " همه فازهای بانک تجارت "
                r.SetParameterValue("TitleName", " گزارش " + strReportName)
            Else
                strReportName = cboCalcType.Text + " " + cboProject.Text
                r.SetParameterValue("TitleName", " گزارش " + strReportName)
            End If

            CrystalReportViewer1.ReportSource = r
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        End If
    End Sub

    Private Sub FillCombo()
        Try
            OPenConnection()
            Me.cboProject.DataSource = _DALProject.GetAllForUCtrl(ClassUserLoginDataAccess.ThisUser.UserID)
            Me.cboProject.ValueMember = "ProjectID_tint"
            Me.cboProject.DisplayMember = "Name_nvc"
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub cboChart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboChart.SelectedIndexChanged
        If dt Is Nothing Then Exit Sub
        Dim r As New rptAgentActivityGroupByDate
        r.SetDataSource(DirectCast(dt, DataTable))
        r.SetParameterValue("ChartType", cboChart.SelectedIndex)
        r.SetParameterValue("TitleName", " گزارش " + strReportName)
        CrystalReportViewer1.ReportSource = r
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

    Private Sub LinkReversal_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkReversal.LinkClicked
        If dgvVisitor.Rows.Count > 0 Then
            If dgvVisitor.Rows(0).Cells(cboVisitorID.Name).Value = 0 Then
                If dgvVisitor.Rows(0).Cells(CheckedBox.Name).Value = False Then
                    For intCounter As Integer = 1 To dgvVisitor.Rows.Count - 1
                        dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).Value = Not (dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).Value)
                    Next
                End If
            Else
                For intCounter As Integer = 0 To dgvVisitor.Rows.Count - 1
                    dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).Value = Not (dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).Value)
                Next
            End If
        End If
    End Sub

    Private Sub LinkAll_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkAll.LinkClicked
        If dgvVisitor.Rows.Count > 0 Then
            If dgvVisitor.Rows(0).Cells(cboVisitorID.Name).Value = 0 Then
                If dgvVisitor.Rows(0).Cells(CheckedBox.Name).Value = False Then
                    For intCounter As Integer = 1 To dgvVisitor.Rows.Count - 1
                        dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).Value = True
                    Next
                End If
            Else
                For intCounter As Integer = 0 To dgvVisitor.Rows.Count - 1
                    dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).Value = True
                Next
            End If
        End If
        dgvVisitor.EndEdit()
    End Sub

    Private Sub LinkCancel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkCancel.LinkClicked
        If dgvVisitor.Rows.Count > 0 Then
            If dgvVisitor.Rows(0).Cells(cboVisitorID.Name).Value = 0 Then
                If dgvVisitor.Rows(0).Cells(CheckedBox.Name).Value = False Then
                    For intCounter As Integer = 1 To dgvVisitor.Rows.Count - 1
                        dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).Value = False
                    Next
                End If
            Else
                For intCounter As Integer = 0 To dgvVisitor.Rows.Count - 1
                    dgvVisitor.Rows(intCounter).Cells(CheckedBox.Name).Value = False
                Next
            End If
        End If
        dgvVisitor.EndEdit()
    End Sub
End Class