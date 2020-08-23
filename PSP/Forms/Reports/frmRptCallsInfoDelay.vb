Public Class frmRptCallsInfoDelay
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private clsDalHelpDesk As New ClassDALHelpDesk(modPublicMethod.ConnectionString)
    Dim dt As New DataTable
    Private Sub frmRptCallsInfoDelay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillVisitorCombo()
            FillProjectCombo()
            rdoAll.Checked = True
            grpDelayBetween.Enabled = False
        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
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
    Private Sub FillProjectCombo()
        Dim clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

        Me.cmbProject.DataSource = clsDALProject.GetAllForUCtrl(ClassUserLoginDataAccess.ThisUser.UserID)
        Me.cmbProject.ValueMember = "ProjectID_tint"
        Me.cmbProject.DisplayMember = "Name_nvc"
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

            If txtResponseLimitInHourTehran.Text = String.Empty Then
                ErrorProvider1.SetError(txtResponseLimitInHourTehran, "حداکثر زمان پاسخگویی تهران را مشخص نمایید")
                res = False
            Else
                ErrorProvider1.SetError(txtResponseLimitInHourTehran, "")
            End If

            If txtResponseLimitInHourMarakez.Text = String.Empty Then
                ErrorProvider1.SetError(txtResponseLimitInHourMarakez, "حداکثر زمان پاسخگویی مراکز استان را مشخص نمایید")
                res = False
            Else
                ErrorProvider1.SetError(txtResponseLimitInHourMarakez, "")
            End If

            If txtResponseLimitInHourCity.Text = String.Empty Then
                ErrorProvider1.SetError(txtResponseLimitInHourCity, "حداکثر زمان پاسخگویی شهرستان را مشخص نمایید")
                res = False
            Else
                ErrorProvider1.SetError(txtResponseLimitInHourCity, "")
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



            Return res

        Catch ex As Exception
            RequiredValidator = False
        End Try
    End Function
    Private Sub FillGrid()
        Dim DateFrom As String
        Dim DateTO As String
        Dim VisitorId As Int64
        Dim WithDelay As Int16
        Dim DelayFromInMin As Int32
        Dim DelayToInMin As Int32
        Dim WorkStart As String
        Dim WorkEnd As String
        Dim ResponseLimitInHourTehran As Int32 = 0
        Dim ResponseLimitInHourMarakez As Int32 = 0
        Dim ResponseLimitInHourCity As Int32 = 0

        If rucDate.cboDate.SelectedIndex = 1 Then
            DateFrom = rucDate.txtDateFrom.Value
            DateTO = rucDate.txtDateTo.Value
        Else
            DateFrom = ""
            DateTO = ""
        End If
        VisitorId = cmbVisitor.SelectedValue

        If rdoWithDelay.Checked Then
            WithDelay = 1
        ElseIf rdoWithoutDelay.Checked Then
            WithDelay = 0
        ElseIf rdoAll.Checked Then
            WithDelay = -1
        End If
        DelayFromInMin = -1
        DelayToInMin = -1
        WorkStart = txtWorkStart.Text
        WorkEnd = txtWorkEnd.Text

        ResponseLimitInHourTehran = txtResponseLimitInHourTehran.Text
        ResponseLimitInHourMarakez = txtResponseLimitInHourMarakez.Text
        ResponseLimitInHourCity = txtResponseLimitInHourCity.Text

        If WithDelay = 1 Then
            If DelayFrom.Value <> String.Empty Then
                DelayFromInMin = DelayFrom.ValueInMin
            End If
            If DelayTo.Value <> String.Empty Then
                DelayToInMin = DelayTo.ValueInMin
            End If
        End If
        Dim DateType As Byte
        If rbtCallDate.Checked = True Then
            DateType = 0
        Else
            DateType = 1
        End If
        dt.Clear()
        dt = clsDalHelpDesk.GetCallsResponseDelay(DateFrom, _
                                                  DateTO, _
                                                  VisitorId, _
                                                  WithDelay, _
                                                  DelayFromInMin, _
                                                  DelayToInMin, _
                                                  WorkStart, _
                                                  WorkEnd, _
                                                  ResponseLimitInHourTehran, _
                                                  ResponseLimitInHourMarakez, _
                                                  ResponseLimitInHourCity, _
                                                  1, _
                                                  ClassUserLoginDataAccess.ThisUser.UserID, _
                                                  cmbProject.SelectedValue, _
                                                  DateType)
        dgvReport.DataSource = dt

        If dt.Compute("Sum(FineAmount)", "") Is DBNull.Value Then
            lblAllFineAmountSum.Text = String.Empty
        Else
            lblAllFineAmountSum.Text = FormatNumber(dt.Compute("Sum(FineAmount)", ""), 0)
        End If

    End Sub
    Private Sub InitGrid()
        If dgvReport.Columns.Count > 0 Then
            dgvReport.Columns("StateName_nvc").HeaderText = "استان"
            dgvReport.Columns("CityName").HeaderText = "شهر"
            dgvReport.Columns("VisitorName").HeaderText = "بازاریاب"
            dgvReport.Columns("StoreName").HeaderText = "نام فروشگاه"
            dgvReport.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
            dgvReport.Columns("CallID").HeaderText = "کد پیگیری کارتابل"
            dgvReport.Columns("ResponsDesc").HeaderText = "شرح پاسخ"
            dgvReport.Columns("CallTime_vc").HeaderText = "ساعت تماس"
            dgvReport.Columns("CallDate_vc").HeaderText = "تاریخ تماس"
            dgvReport.Columns("ResponseDate_vc").HeaderText = "تاریخ پاسخ"
            dgvReport.Columns("RequestDesc").HeaderText = "شرح در خواست"
            dgvReport.Columns("ResponseTime_vc").HeaderText = "ساعت پاسخ"
            dgvReport.Columns("Delay").HeaderText = "تاخیر"
            'dgvReport.Columns("DelayInMin").Visible = False
            dgvReport.Columns("DelayInMin").HeaderText = "تاخیر به دقیقه"
            dgvReport.Columns("FineAmount").HeaderText = "مبلغ جریمه به تومان"
            dgvReport.Columns("Code_vc").HeaderText = "کد پایانه"
        End If
    End Sub
    Private Sub Calculating()
        If IsDBNull(dt.Compute("Sum(DelayInMin)", "")) = True Then
            txtSumDelay.Text = ""
        Else
            txtSumDelay.Text = modPublicMethod.GetHourByMin(dt.Compute("Sum(DelayInMin)", ""))
        End If

    End Sub

    Private Sub rdo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoWithoutDelay.CheckedChanged, rdoAll.CheckedChanged
        grpDelayBetween.Enabled = rdoWithDelay.Checked
    End Sub

    Private Sub rdoWithDelay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoWithDelay.CheckedChanged
        grpDelayBetween.Enabled = rdoWithDelay.Checked
    End Sub

  
End Class