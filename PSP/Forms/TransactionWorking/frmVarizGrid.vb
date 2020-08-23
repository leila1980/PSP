
Public Class frmVariz_Print_Edit

    Private clsDALVariz As New ClassDALVariz(modPublicMethod.ConnectionString)
    Dim dt As New DataTable
    Dim flgEdit As Boolean = False
    Dim Mode As Mode = Mode.View

#Region "Sub"

    Private Sub SelectRecord()
        Try

            Me.Cursor = Cursors.WaitCursor
            dt.Rows.Clear()
            clsDALVariz.BeginProc()

            Dim Status As Short
            Select Case Me.cmbStatus.SelectedIndex
                Case 0
                    Status = 2
                Case 1
                    Status = 1
                Case 2
                    Status = 0
            End Select

            dt = clsDALVariz.GetForReport(Me.dtxtFromVarizDate.Value, Me.dtxtToVarizDate.Value, Status)

            If dt.Rows.Count = 0 Then
                ShowErrorMessage("اطلاعاتی مناسب با تاریخ وارد شده یافت نشد")
            End If

        Catch ex As Exception
            Throw ex
        Finally
            clsDALVariz.EndProc()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UpdateRecordOnDB()

        Try

            clsDALVariz.BeginProc()

            clsDALVariz.Variz_HistoryID = Me.dgvVariz.CurrentRow.Cells("Variz_HistoryID").Value
            clsDALVariz.CorrectAccountNo_vc = Me.txtCorrectAccountNo.Text.Trim
            clsDALVariz.Description_nvc = Me.txtDesc.Text.Trim
            clsDALVariz.UpdateVariz_CorrectAccountNo_Description()

        Catch ex As Exception
            Throw ex
        Finally
            clsDALVariz.EndProc()
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub UpdateRecordOnDT()

        Dim dr() As DataRow
        dr = dt.Select("Variz_HistoryID=" & Me.dgvVariz.CurrentRow.Cells("Variz_HistoryID").Value)

        dr(0)("CorrectAccountNo") = Me.txtCorrectAccountNo.Text.Trim
        dr(0)("Description") = Me.txtDesc.Text.Trim

        dt.AcceptChanges()

    End Sub
    Private Sub SetGrid()

        Try
            dgvVariz.DataSource = dt

            dgvVariz.Columns("Variz_HistoryId").Visible = False

            dgvVariz.Columns("AcountOwner").Width = 120
            dgvVariz.Columns("AcountOwner").HeaderText = "نام صاحب حساب"

            dgvVariz.Columns("AccountNO_vc").Width = 120
            dgvVariz.Columns("AccountNO_vc").HeaderText = "شماره حساب"

            dgvVariz.Columns("AgentName").Width = 180
            dgvVariz.Columns("AgentName").HeaderText = "نام نماینده"

            dgvVariz.Columns("StorName").Width = 180
            dgvVariz.Columns("StorName").HeaderText = "نام فروشگاه"

            dgvVariz.Columns("CityName").Width = 100
            dgvVariz.Columns("CityName").HeaderText = "نام شهر"

            dgvVariz.Columns("Switch_TerminalID_vc").Width = 100
            dgvVariz.Columns("Switch_TerminalID_vc").HeaderText = "POS Terminal ID"

            dgvVariz.Columns("Serial_vc").Width = 100
            dgvVariz.Columns("Serial_vc").HeaderText = "شماره سریال دستگاه"

            dgvVariz.Columns("CorrectAccountNo").Width = 100
            dgvVariz.Columns("CorrectAccountNo").HeaderText = "شماره حساب صحیح"

            dgvVariz.Columns("Description").Width = 150
            dgvVariz.Columns("Description").HeaderText = "شـــرح"

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub
    Private Sub SetControlProperty()

        If Mode = Global.Mode.Edit Then
            Me.txtCorrectAccountNo.Enabled = True
            Me.txtDesc.Enabled = True
            Me.txtCorrectAccountNo.Focus()
            Me.dgvVariz.Enabled = False
            Me.btnSave.Enabled = True
            Me.btnEdit.Enabled = False
            Me.btnPrint.Enabled = False
        ElseIf Mode = Global.Mode.View Then
            Me.txtCorrectAccountNo.Enabled = False
            Me.txtDesc.Enabled = False
            Me.dgvVariz.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnSave.Enabled = False
            Me.btnPrint.Enabled = True
        End If

    End Sub

    Private Sub LoadCombo()

        Me.cmbStatus.Items.Add("همــــــــه")     '0
        Me.cmbStatus.Items.Add("تأیید شـده")     '1
        Me.cmbStatus.Items.Add("تأیید نشده")     '2
        Me.cmbStatus.SelectedIndex = 0

    End Sub

    Private Sub SetReport()

        Try

            If Me.dgvVariz.Rows.Count = 0 Then
                MessageBox.Show("اطلاعاتی جهت چاپ وجود ندارد")
                Exit Sub
            End If

            Dim sReportPath As String = ""
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            sReportPath = Application.StartupPath.ToString + "\Reports" + "\RptVariz.rpt"
            objReport.FileName = sReportPath.Trim.ToString
            'Dim F1 As CrystalDecisions.CrystalReports.Engine.FormulaFieldDefinitions = objReport.DataDefinition.FormulaFields

            'F1.Item("ReportDate").Text = "'" & DateTool.ConvertDate(Now) & "'"
            'F1.Item("VarizDate").Text = "'" & Me.dtxtVarizDate.Value & "'"

            objReport.SetDataSource(Me.dgvVariz.DataSource)

            objReport.SetParameterValue("@ReportDate", GetDateNow)
            objReport.SetParameterValue("@VarizDate", Me.dtxtFromVarizDate.Value)

            Dim viewer As New frmViewr
            viewer.CrystalReportViewer.ReportSource = objReport
            viewer.ShowDialog()

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub

#End Region
#Region "Events"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Me.Mode = Global.Mode.View
        SelectRecord()
        SetGrid()
        SetControlProperty()

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If IsNothing(Me.dgvVariz.CurrentRow) Then

            MessageBox.Show("رکوردی جهت ویرایش انتخاب نشده است")
            Exit Sub

        End If

        Mode = Global.Mode.Edit

        SetControlProperty()

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        UpdateRecordOnDB()
        UpdateRecordOnDT()

        Mode = Global.Mode.View
        SetControlProperty()

    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Mode = Global.Mode.View
        SetControlProperty()

    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try
            SetReport()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub
    Private Sub frmVariz_Print_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetControlProperty()
        LoadCombo()

    End Sub
    Private Sub dgvVariz_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvVariz.SelectionChanged

        If Not IsNothing(dgvVariz.CurrentRow) Then
            Me.txtCorrectAccountNo.Text = Me.dgvVariz.CurrentRow.Cells("CorrectAccountNo").Value
            Me.txtDesc.Text = Me.dgvVariz.CurrentRow.Cells("Description").Value
        End If

    End Sub

#End Region

End Class

Public Enum Mode
    Edit
    View
End Enum

