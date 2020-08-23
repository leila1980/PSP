Public Class frmRptAgentActivities
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)
    Private clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

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
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("AccountCount_UntilDateFrom") = dt.Compute("Sum(AccountCount_UntilDateFrom)", "")
                dr("AllComitment") = dt.Compute("Sum(AllComitment)", "")
                dr("CanceledCount_Between") = dt.Compute("Sum(CanceledCount_Between)", "")
                dr("CanceledCount_UntilDateFrom") = dt.Compute("Sum(CanceledCount_UntilDateFrom)", "")
                dr("ConfigedCount_Between") = dt.Compute("Sum(ConfigedCount_Between)", "")
                dr("ConfigedCount_UntilDateFrom") = dt.Compute("Sum(ConfigedCount_UntilDateFrom)", "")
                dr("CountractCount_UntilDateFrom") = dt.Compute("Sum(CountractCount_UntilDateFrom)", "")
                dr("InstalledAndInstallConfirmedCount_Between") = dt.Compute("Sum(InstalledAndInstallConfirmedCount_Between)", "")
                dr("InstalledAndInstallConfirmedCount_UntilDateFrom") = dt.Compute("Sum(InstalledAndInstallConfirmedCount_UntilDateFrom)", "")
                dr("InstalledCount_Between") = dt.Compute("Sum(InstalledCount_Between)", "")
                dr("InstalledCount_UntilDateFrom") = dt.Compute("Sum(InstalledCount_UntilDateFrom)", "")
                dr("TakhsisCount_Between") = dt.Compute("Sum(TakhsisCount_Between)", "")
                dr("TakhsisCount_UntilDateFrom") = dt.Compute("Sum(TakhsisCount_UntilDateFrom)", "")
                dr("TotalDeviceCount_UntilDateFrom") = dt.Compute("Sum(TotalDeviceCount_UntilDateFrom)", "")
                dr("TotalDeviceCount_Between") = dt.Compute("Sum(TotalDeviceCount_Between)", "")
                dr("CompletedContractNumber") = dt.Compute("Sum(CompletedContractNumber)", "")
                dr("ConfirmedContractNumber") = dt.Compute("Sum(ConfirmedContractNumber)", "")
                dr("InstalledAndCanceledCount_Between") = dt.Compute("Sum(InstalledAndCanceledCount_Between)", "")
                dr("CountractCount_Between") = dt.Compute("Sum(CountractCount_Between)", "")
                dr("AccountCount_Between") = dt.Compute("Sum(AccountCount_Between)", "")
                dr("NoTakhsisCount_UntilDateTo") = dt.Compute("Sum(NoTakhsisCount_UntilDateTo)", "")
                dr("NoConfigedCount_UntilDateTo") = dt.Compute("Sum(NoConfigedCount_UntilDateTo)", "")
                dr("NoInstallConfirmedCount_UntilDateTo") = dt.Compute("Sum(NoInstallConfirmedCount_UntilDateTo)", "")
                dr("NoInstalledCount_UntilDateTo") = dt.Compute("Sum(NoInstalledCount_UntilDateTo)", "")
                dr("VisitorFullName") = ""
                dr("VisitorID") = 0
                dt.Rows.Add(dr)
            End If

            dv = dt.DefaultView
            dgv.DataSource = dv


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
            Dim _frm As New frmRptViewDetail
            _frm.VisitorID = dgv.Rows(e.RowIndex).Cells("VisitorID").Value
            _frm.DateFrom = DateFrom
            _frm.DateTo = DateTO
            _frm.VisitorFullName = dgv.Rows(e.RowIndex).Cells("VisitorFullName").Value
            _frm.Text = dgv.Columns(e.ColumnIndex).HeaderText.ToString.Substring(5, dgv.Columns(e.ColumnIndex).HeaderText.ToString.Length - 5)
            _frm.ProjectID = cmbProject.SelectedValue

            Select Case e.ColumnIndex
                Case 5 'قراداد های ثبت شده تا ابتدای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.ContractDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 6 'قراداد های ثبت شده در بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.ContractDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 7 'قراداد های حسابدار تا ابتدای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.AccountDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 8 'قراداد های حسابدار در بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.AccountDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 9 'تخصیص تا ابتدای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.TakhsisDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 10 'تخصیص در بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.TakhsisDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 11 'پیکربندی تا ابتدای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.ConfigedDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 12 'پیکربندی در بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.ConfigedDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 13 'نصب تا ابتدای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.InstalledDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 14 'نصب در بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.InstalledDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 15 'تایید نصب تا ابتدای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.InstalledAndConfirmedInstallDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 16 'تایید نصب در بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.InstalledAndConfirmedInstallDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()


                Case 17 'فسخ تا ابتدای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.CanceledDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Until
                    _frm.ShowDialog()
                Case 18 'فسخ در بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.CanceledDetail
                    _frm.DateCondition = frmRptViewDetail.DateConditionEnum.Between
                    _frm.ShowDialog()
                Case 19 'نصب و فسخ در بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.CanceledAndInstalledDetail
                    _frm.ShowDialog()

                Case 22 'تخصیص داده نشده تا انتهای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.NoThakhsisDetail
                    _frm.ShowDialog()
                Case 23 'پیکربندی نشده تا انتهای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.NoConfigedDetail
                    _frm.ShowDialog()
                Case 24 'نصب نشده تا انتهای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.NoInstalledDetail
                    _frm.ShowDialog()
                Case 25 'تایید نصب نشده تا انتهای بازه
                    _frm.ReportType = frmRptViewDetail.ReportTypeEnum.NoConfirmedInstallDetail
                    _frm.ShowDialog()


            End Select
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

  
End Class