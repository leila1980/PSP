Public Class frmRptCallsInfoDelayOld2
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private clsDalHelpDesk As New ClassDALHelpDesk(modPublicMethod.ConnectionString)
    Dim dt As New DataTable
    Private Sub frmRptCallsInfoDelay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillVisitorCombo()
            FillProjectCombo()
            rdoNotCompleted.Checked = True
            grpCompleted.Enabled = False
            rdoWithoutDelay.Checked = True
            grpDelayBetween.Enabled = False
        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub FillProjectCombo()
        Dim clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

        Me.cmbProject.DataSource = clsDALProject.GetAllForUCtrl(ClassUserLoginDataAccess.ThisUser.UserID)
        Me.cmbProject.ValueMember = "ProjectID_tint"
        Me.cmbProject.DisplayMember = "Name_nvc"
    End Sub
    Private Sub FillVisitorCombo()
        Try
            Me.cmbVisitor.DisplayMember = "FullName"
            Me.cmbVisitor.ValueMember = "VisitorID"
            Me.cmbVisitor.DataSource = clsDALVisitor.GetAllVisitorByUserID_ForCbo(ClassUserLoginDataAccess.ThisUser.UserID) 'clsDALVisitor.GetAllVisitor_ForCbo

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvReport_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvReport.RowsAdded
        lblCnt.Text = dgvReport.RowCount
    End Sub
    Private Sub dgvReport_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvReport.RowsRemoved
        lblCnt.Text = dgvReport.RowCount
    End Sub
    Private Sub ReportSearchToolStrip1_Show_Click() Handles ReportSearchToolStrip1.Show_Click
        Try
            ErrorProvider1.Clear()
            If RequiredValidator() = False Then
                Exit Sub
            End If
            FillGrid()
            InitGrid()
            ReportSearchToolStrip1.Init(dgvReport, dt, Me.Text)
            Calculating()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Function RequiredValidator() As Boolean
        Try
            Dim res As Boolean
            res = True
            If rdoComleted.Checked Then

                If modPublicMethod.CheckTime(txtWorkStart.Text) = False Then
                    ErrorProvider1.SetError(txtWorkStart, "ساعت به طور کامل وارد نشده است و یا نامعتبر می باشد")
                    res = False
                Else
                    ErrorProvider1.SetError(txtWorkStart, "")
                End If

                If modPublicMethod.CheckTime(txtWorkEnd.Text) = False Then
                    ErrorProvider1.SetError(txtWorkEnd, "ساعت به طور کامل وارد نشده است و یا نامعتبر می باشد")
                    res = False
                Else
                    ErrorProvider1.SetError(txtWorkEnd, "")
                End If

                If txtResponseLimitInHour.Text = String.Empty Then
                    ErrorProvider1.SetError(txtResponseLimitInHour, "حداکثر زمان پاسخگویی را مشخص نمایید")
                    res = False
                Else
                    ErrorProvider1.SetError(txtResponseLimitInHour, "")
                End If

                If rdoWithDelay.Checked Then
                    If DelayFrom.Min <> String.Empty Then
                        If modPublicMethod.CheckMin(DelayFrom.Min) = False Then
                            ErrorProvider1.SetError(DelayFrom, "مقدار نامعتبر است")
                            res = False
                        Else
                            ErrorProvider1.SetError(DelayFrom, "")
                        End If
                    End If
                    If DelayTo.Min <> String.Empty Then
                        If modPublicMethod.CheckMin(DelayTo.Min) = False Then
                            ErrorProvider1.SetError(DelayTo, "مقدار نامعتبر است")
                            res = False
                        Else
                            ErrorProvider1.SetError(DelayTo, "")
                        End If
                    End If
                End If
            End If


            Return res

        Catch ex As Exception
            RequiredValidator = False
        End Try
    End Function
    Private Sub FillGrid()
        Dim DateFrom As String
        Dim DateTO As String
        Dim VisitorId As Int64
        Dim Completed As Int16
        Dim WithDelay As Int16
        Dim DelayFromInMin As Int32
        Dim DelayToInMin As Int32
        Dim WorkStart As String
        Dim WorkEnd As String
        Dim ResponseLimitInHour As Int32


        If rucDate.cboDate.SelectedIndex = 1 Then
            DateFrom = rucDate.txtDateFrom.Value
            DateTO = rucDate.txtDateTo.Value
        Else
            DateFrom = ""
            DateTO = ""
        End If
        VisitorId = cmbVisitor.SelectedValue
        If rdoNotCompleted.Checked Then
            Completed = 0
            WithDelay = -1
            DelayFromInMin = -1
            DelayToInMin = -1
            WorkStart = String.Empty
            WorkEnd = String.Empty
            ResponseLimitInHour = -1
        ElseIf rdoComleted.Checked Then
            Completed = 1
            WithDelay = IIf(rdoWithDelay.Checked, 1, 0)
            DelayFromInMin = -1
            DelayToInMin = -1
            WorkStart = txtWorkStart.Text
            WorkEnd = txtWorkEnd.Text
            ResponseLimitInHour = txtResponseLimitInHour.Text
        End If
        If WithDelay = 1 Then
            If DelayFrom.Value <> String.Empty Then
                DelayFromInMin = DelayFrom.ValueInMin
            End If
            If DelayTo.Value <> String.Empty Then
                DelayToInMin = DelayTo.ValueInMin
            End If
        End If
        dt.Clear()
        dt = clsDalHelpDesk.GetCallsResponseDelay(DateFrom, DateTO, VisitorId, Completed, WithDelay, DelayFromInMin, DelayToInMin, WorkStart, WorkEnd, ResponseLimitInHour, 1, ClassUserLoginDataAccess.ThisUser.UserID, cmbProject.SelectedValue)
        dgvReport.DataSource = dt

    End Sub
    Private Sub InitGrid()
        If dgvReport.Columns.Count > 0 Then
            dgvReport.Columns("StateName_nvc").HeaderText = "استان"
            dgvReport.Columns("VisitorName").HeaderText = "بازاریاب"
            dgvReport.Columns("StoreName").HeaderText = "نام فروشگاه"
            dgvReport.Columns("EniacCode_vc").HeaderText = "EniacCode"
            dgvReport.Columns("CallID").HeaderText = "کد پیگیری"
            dgvReport.Columns("ResponsDesc").HeaderText = "شرح پاسخ"
            dgvReport.Columns("CallTime_vc").HeaderText = "ساعت تماس"
            dgvReport.Columns("CallDate_vc").HeaderText = "تاریخ تماس"
            dgvReport.Columns("ResponseDate_vc").HeaderText = "تاریخ پاسخ"
            dgvReport.Columns("RequestDesc").HeaderText = "شرح در خواست"
            dgvReport.Columns("ResponseTime_vc").HeaderText = "ساعت پاسخ"
            dgvReport.Columns("Delay").HeaderText = "تاخیر"
            dgvReport.Columns("DelayInMin").Visible = False

        End If
    End Sub
    Private Sub Calculating()
        If rdoComleted.Checked Then
            If IsDBNull(dt.Compute("Sum(DelayInMin)", "")) = True Then
                txtSumDelay.Text = ""
            Else
                txtSumDelay.Text = modPublicMethod.GetHourByMin(dt.Compute("Sum(DelayInMin)", ""))
            End If
        End If

    End Sub




    Private Sub rdoComleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoComleted.CheckedChanged
        grpCompleted.Enabled = rdoComleted.Checked
    End Sub

    Private Sub rdoNotCompleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNotCompleted.CheckedChanged
        grpCompleted.Enabled = rdoComleted.Checked

    End Sub

    Private Sub rdoWithoutDelay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoWithoutDelay.CheckedChanged
        grpDelayBetween.Enabled = rdoWithDelay.Checked
    End Sub

    Private Sub rdoWithDelay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoWithDelay.CheckedChanged
        grpDelayBetween.Enabled = rdoWithDelay.Checked
    End Sub


End Class