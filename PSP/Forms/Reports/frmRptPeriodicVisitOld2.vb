Public Class frmRptPeriodicVisitOld2
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)
    Private clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

    Private dt As New DataTable
    Private dv As DataView

    Private DateFrom As String
    Private DateTO As String
    Enum VisitStateEnum
        Visit = 0
        NoVisit = 1
    End Enum
    Public VisitState As VisitStateEnum
    Private Sub FillCombo()
        Try
            Me.cmbProject.DataSource = clsDALProject.GetAllForUCtrl(ClassUserLoginDataAccess.ThisUser.UserID)
            Me.cmbProject.ValueMember = "ProjectID_tint"
            Me.cmbProject.DisplayMember = "Name_nvc"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmRptGetAllTransactionsInDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            rdoBasedOnInstall.Checked = True
            FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub ReportSearchToolStrip1_Show_Click() Handles ReportSearchToolStrip1.Show_Click
        Try
            If Requieredvalidator() = False Then
                Exit Sub
            End If
            FillGrid()
            InitGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Function Requieredvalidator() As Boolean
        Try
            erp.Clear()
            Dim res As Boolean = True
            If rucDate.cboDate.SelectedIndex = 1 Then
                DateFrom = rucDate.txtDateFrom.Value
                DateTO = rucDate.txtDateTo.Value
                If DateFrom = String.Empty Or DateTO = String.Empty Then
                    erp.SetError(rucDate, "بازه تاریخی را کامل انتخاب کنید")
                    res = False
                Else
                    erp.SetError(rucDate, "")
                End If
            Else
                erp.SetError(rucDate, "بازه تاریخی را وارد نمایید")
                res = False
            End If
            If clsDALReport.GetByTypeVisitAmout(1).Rows.Count = 0 AndAlso txtMaxPrice.Text = String.Empty Then
                erp.SetError(txtMaxPrice, "حداکثر مبلغ را مشخص نمایید")
                res = False
            Else
                erp.SetError(txtMaxPrice, "")
            End If
            If txtMonth.Text = String.Empty Then
                erp.SetError(txtMonth, "تعداد ماه را مشخص فرمایید")
                res = False
            Else
                erp.SetError(txtMonth, "")
            End If

            If txtNegativeTelorance.Enabled AndAlso txtNegativeTelorance.Text.Trim = String.Empty Then
                erp.SetError(txtNegativeTelorance, "بازه منفی تلورانس را وارد نمایید")
                res = False
            Else
                erp.SetError(txtNegativeTelorance, "")

            End If
            If txtPositiveTelorance.Enabled AndAlso txtPositiveTelorance.Text.Trim = String.Empty Then
                erp.SetError(txtPositiveTelorance, "بازه مثبت تلورانس را وارد نمایید")
                res = False
            Else
                erp.SetError(txtPositiveTelorance, "")

            End If
            Return res
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub FillGrid()
        Try
            Select Case VisitState
                Case VisitStateEnum.Visit
                    dt.Clear()
                    If rdoBasedOnInstall.Checked Then
                        dt = clsDALReport.PeriodicVisit_BasedOnInstall(DateFrom, DateTO, txtMonth.Text, txtMaxPrice.Text, txtNegativeTelorance.Text, txtPositiveTelorance.Text, chkCutCorrectPeriod.Checked, cmbProject.SelectedValue)
                    ElseIf rdoBasedOnLastVisit.Checked Then
                        dt = clsDALReport.PeriodicVisit_BasedOnLastVisit(DateFrom, DateTO, txtMonth.Text, txtMaxPrice.Text, cmbProject.SelectedValue)
                    End If
                Case VisitStateEnum.NoVisit
                    dt.Clear()
                    If rdoBasedOnInstall.Checked Then
                        dt = clsDALReport.PeriodicVisit_BasedOnInstall_NoVisit(DateFrom, DateTO, txtMonth.Text, txtMaxPrice.Text, txtNegativeTelorance.Text, txtPositiveTelorance.Text, chkCutCorrectPeriod.Checked, cmbProject.SelectedValue)
                    ElseIf rdoBasedOnLastVisit.Checked Then
                        dt = clsDALReport.PeriodicVisit_BasedOnLastVisit_NoVisit(DateFrom, DateTO, txtMonth.Text, txtMaxPrice.Text, cmbProject.SelectedValue)
                    End If
                Case Else
                    Exit Sub
            End Select
            dv = dt.DefaultView
            dgv.DataSource = dv
            InitGrid()
            ReportSearchToolStrip1.Init(dgv, dt, Me.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            If dgv.Columns.Count > 0 Then
                dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                dgv.Columns("Name").HeaderText = "نام پذیرنده"
                dgv.Columns("StoreName").HeaderText = "فروشگاه"
                dgv.Columns("GroupName").HeaderText = "صنف"
                dgv.Columns("StateName").HeaderText = "استان"
                dgv.Columns("CityName").HeaderText = "شهر"
                dgv.Columns("VisitorName").HeaderText = "نماینده"
                dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                dgv.Columns("Payaneh").HeaderText = "پایانه"
                dgv.Columns("Switch_CardAcceptorID").HeaderText = "پذیرنده در سوئیچ وچر"
                dgv.Columns("Switch_TerminalID").HeaderText = "پایانه در سوئیچ وچر"
                dgv.Columns("Address").HeaderText = "آدرس"
                dgv.Columns("Tel").HeaderText = "تلفن"
                dgv.Columns("Installdate").HeaderText = "تاریخ نصب"
                dgv.Columns("TheLastSuccTran").HeaderText = "زمان آخرین تراکنش خرید موفق"
                dgv.Columns("Canceldate").HeaderText = "تاریخ فسخ"
                dgv.Columns("VisitState").HeaderText = "وضعیت بازدید"
                dgv.Columns("VisitDate").HeaderText = "تاریخ بازدید"
                dgv.Columns("VisitCount").HeaderText = "تعداد بازدید تا انتهای بازه"

                If rdoBasedOnInstall.Checked Then
                    dgv.Columns("CorrectExact_Date").Visible = False
                    dgv.Columns("CorrectPeriod_DateFrom").HeaderText = "شروع بازه بازدید"
                    dgv.Columns("CorrectPeriod_DateTo").HeaderText = "پایان بازه بازدید"
                    If VisitState = VisitStateEnum.Visit Then
                        dgv.Columns("VisitDate_BeforCorrectPeriod").HeaderText = "تاریخ بازدید قبل از بازه"
                        dgv.Columns("VisitDate_AfterCorrectPeriod").HeaderText = "تاریخ بازدید بعد از بازه"
                        dgv.Columns("Rush").HeaderText = "تعجیل"
                        dgv.Columns("Delay").HeaderText = "تاخیر"
                    End If
                ElseIf rdoBasedOnLastVisit.Checked Then
                    dgv.Columns("TheLastVisitBeforBazeDate").HeaderText = "تاریخ آخرین بازدید قبل از بازه"
                End If
                Select Case VisitState
                    Case VisitStateEnum.Visit
                        dgv.Columns("Serial_vc").HeaderText = "شماره سریال"
                        dgv.Columns("PropertyNo_vc").HeaderText = "اموال"
                        dgv.Columns("EniacCode_vc").HeaderText = "کد انیاک"
                        dgv.Columns("PosModelName").HeaderText = "مدل دستگاه"
                    Case VisitStateEnum.NoVisit
                        dgv.Columns("Serial_vc").Visible = False
                        dgv.Columns("PropertyNo_vc").Visible = False
                        dgv.Columns("EniacCode_vc").Visible = False
                        dgv.Columns("PosModelName").Visible = False
                End Select
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgv_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        lblCount.Text = dgv.RowCount
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        lblCount.Text = dgv.RowCount
    End Sub

    Private Sub rdoBasedOn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBasedOnInstall.CheckedChanged, rdoBasedOnLastVisit.CheckedChanged
        txtNegativeTelorance.Enabled = rdoBasedOnInstall.Checked
        txtPositiveTelorance.Enabled = rdoBasedOnInstall.Checked
        chkCutCorrectPeriod.Enabled = rdoBasedOnInstall.Checked
    End Sub
    Private Sub dgv_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If
            Dim _frm As New frmPeriodicVisitRptViewDetail
            _frm.Payaneh = dgv.Rows(e.RowIndex).Cells("outlet").Value
            _frm.DateTo = DateTO
            _frm.MaxPrice = txtMaxPrice.Text
            _frm.Text = dgv.Columns(e.ColumnIndex).HeaderText.ToString.Substring(5, dgv.Columns(e.ColumnIndex).HeaderText.ToString.Length - 5)
            Select Case e.ColumnIndex
                Case 22
                    _frm.ShowDialog()
            End Select
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

End Class