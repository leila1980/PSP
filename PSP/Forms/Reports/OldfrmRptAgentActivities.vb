Public Class OldfrmRptAgentActivities
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)
    Dim clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

    Private DateFrom As String = ""
    Private DateTO As String = ""
    Dim dt As New DataTable
    Dim dv As New DataView

    Private Sub frmRptGetAllTransactionsInDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillCombo()
        Try
            Me.cmbProject.DataSource = clsDALProject.GetAllForUCtrl(ClassUserLoginDataAccess.ThisUser.UserID)
            Me.cmbProject.ValueMember = "ProjectID_tint"
            Me.cmbProject.DisplayMember = "Name_nvc"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ReportSearchToolStrip1_Show_Click() Handles ReportSearchToolStrip1.Show_Click
        Try
            If rucDate.cboDate.SelectedIndex = 1 Then
                DateFrom = rucDate.txtDateFrom.Value
                DateTO = rucDate.txtDateTo.Value
            Else
                DateFrom = ""
                DateTO = ""
            End If
            FillGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            dt.Clear()
            dt = clsDALReport.GetAgentActivities(DateFrom, DateTO, cmbProject.SelectedValue)
            dv = dt.DefaultView
            dgv.DataSource = dv

            If dt.Rows.Count > 0 Then
                lblSumAccountCount_UntilDateFrom.Text = dt.Compute("Sum(AccountCount_UntilDateFrom)", "")
                lblSumAllComitment.Text = dt.Compute("Sum(AllComitment)", "")
                lblSumCanceledCount_Between.Text = dt.Compute("Sum(CanceledCount_Between)", "")
                lblSumCanceledCount_UntilDateFrom.Text = dt.Compute("Sum(CanceledCount_UntilDateFrom)", "")
                lblSumConfigedCount_Between.Text = dt.Compute("Sum(ConfigedCount_Between)", "")
                lblSumConfigedCount_UntilDateFrom.Text = dt.Compute("Sum(ConfigedCount_UntilDateFrom)", "")
                lblSumCountractCount_UntilDateFrom.Text = dt.Compute("Sum(CountractCount_UntilDateFrom)", "")
                lblSumInstallConfirmedCount_Between.Text = dt.Compute("Sum(InstallConfirmedCount_Between)", "")
                lblSumInstallConfirmedCount_UntilDateFrom.Text = dt.Compute("Sum(InstallConfirmedCount_UntilDateFrom)", "")
                lblSumInstalledCount_Between.Text = dt.Compute("Sum(InstalledCount_Between)", "")
                lblSumInstalledCount_UntilDateFrom.Text = dt.Compute("Sum(InstalledCount_UntilDateFrom)", "")
                lblSumTakhsisCount_Between.Text = dt.Compute("Sum(TakhsisCount_Between)", "")
                lblSumTakhsisCount_UntilDateFrom.Text = dt.Compute("Sum(TakhsisCount_UntilDateFrom)", "")
                lblSumTotalDeviceCount.Text = dt.Compute("Sum(TotalDeviceCount)", "")
                lblSumCompletedContractNumber.Text = dt.Compute("Sum(CompletedContractNumber)", "")
                lblSumConfirmedContractNumber.Text = dt.Compute("Sum(ConfirmedContractNumber)", "")
                lblSumInstalledAndCanceledCount_Between.Text = dt.Compute("Sum(InstalledAndCanceledCount_Between)", "")
                lblSumCountractCount_Between.Text = dt.Compute("Sum(CountractCount_Between)", "")
                lblSumAccountCount_Between.Text = dt.Compute("Sum(AccountCount_Between)", "")
            Else
                lblSumAccountCount_UntilDateFrom.Text = ""
                lblSumAllComitment.Text = ""
                lblSumCanceledCount_Between.Text = ""
                lblSumCanceledCount_UntilDateFrom.Text = ""
                lblSumConfigedCount_Between.Text = ""
                lblSumConfigedCount_UntilDateFrom.Text = ""
                lblSumCountractCount_UntilDateFrom.Text = ""
                lblSumInstallConfirmedCount_Between.Text = ""
                lblSumInstallConfirmedCount_UntilDateFrom.Text = ""
                lblSumInstalledCount_Between.Text = ""
                lblSumInstalledCount_UntilDateFrom.Text = ""
                lblSumTakhsisCount_Between.Text = ""
                lblSumTakhsisCount_UntilDateFrom.Text = ""
                lblSumTotalDeviceCount.Text = ""
                lblSumConfirmedContractNumber.Text = ""
                lblSumInstalledAndCanceledCount_Between.Text = ""
                lblSumCountractCount_Between.Text = ""
                lblSumAccountCount_Between.Text = ""
            End If
            ReportSearchToolStrip1.Init(dgv, dt, Me.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgv_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If
            Dim _frm As New OldfrmRptViewDetail
            _frm.VisitorID = dgv.Rows(e.RowIndex).Cells("VisitorID").Value
            _frm.ProjectID = cmbProject.SelectedValue
            _frm.DateFrom = DateFrom
            _frm.DateTo = DateTO
            _frm.VisitorFullName = dgv.Rows(e.RowIndex).Cells("VisitorFullName").Value
            _frm.Text = dgv.Columns(e.ColumnIndex).HeaderText.ToString.Substring(5, dgv.Columns(e.ColumnIndex).HeaderText.ToString.Length - 5)
            Select Case e.ColumnIndex
                Case 5 'قراداد های ثبت شده تا ابتدای بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.ContractDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 6 'قراداد های ثبت شده در بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.ContractDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 7 'قراداد های حسابدار تا ابتدای بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.AccountDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 8 'قراداد های حسابدار در بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.AccountDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 9 'تخصیص تا ابتدای بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.TakhsisDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 10 'تخصیص در بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.TakhsisDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 11 'پیکربندی تا ابتدای بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.ConfigedDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 12 'پیکربندی در بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.ConfigedDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 13 'نصب تا ابتدای بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.InstalledDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 14 'نصب در بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.InstalledDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()

                Case 15
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.ConfirmedInstallDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()

                Case 16

                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.ConfirmedInstallDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()


                Case 17 'فسخ تا ابتدای بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.CanceledDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 18 'فسخ در بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.CanceledDetail
                    _frm.DateCondition = OldfrmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 19 'نصب و فسخ در بازه
                    _frm.ReportType = OldfrmRptViewDetail.ReportTypeEnum.CanceledAndInstalledDetail
                    _frm.ShowDialog()



            End Select
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
End Class