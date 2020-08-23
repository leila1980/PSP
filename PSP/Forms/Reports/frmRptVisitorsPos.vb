Imports Oracle.DataAccess.Client

Public Class frmVisitorPos
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)

    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim ds As New DSReport
    Dim da As New OracleDataAdapter
    Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    Dim dv As New DataView

    Private dtdgv As New DataTable
    Private dvdgv As DataView

    Private dtdgvDetail As New DataTable
    Private dvdgvDetail As DataView

#Region "Events"

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                If (tbcMain.SelectedTab Is tbpMainReport) Then
                    clsExcel.Write(Me.dgvReport)
                Else
                    clsExcel.Write(Me.dgvDetail)
                End If
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

#End Region

#Region "Methods"
    Private Sub FormLoad()
        Try
            FillGrid()
            InitGrid()
            InitSearchToolbar()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitSearchToolbar()

        If tbcMain.SelectedTab Is tbpMainReport Then
            rtsSearch.Init(dgvReport, dtdgv, "")
        Else
            rtsSearch.Init(dgvDetail, dtdgvDetail, "")
        End If

    End Sub
    Private Sub FillGrid()
        Try
            dtdgv = clsDALReport.GetAllVisitorsPosCounts()

            dgvReport.DataSource = dtdgv
            dvdgv = dtdgv.DefaultView
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        dgvReport.Columns("OrderType").Visible = False
        dgvReport.Columns("VisitorID").Visible = False
        dgvReport.Columns("visitor").HeaderText = "نماینده"
        dgvReport.Columns("visitor").Width = 250
        dgvReport.Columns("OperationalPos").HeaderText = "عملیاتی (فعال در سوئیچ)"
        dgvReport.Columns("NotOptAssignedToContract").HeaderText = "تخصیص یافته (غیر عملیاتی)"
        dgvReport.Columns("PureSentToVisitor").HeaderText = "خالص ارسال شده به نماینده"
        dgvReport.Columns("InVisitorsWarehouse").HeaderText = "در انبار نماینده"
        dgvReport.Columns("WaitnigForVisitorsAcceptance").HeaderText = "در انتظار تائید نماینده"
        dgvReport.Columns("WaitingForEniacAcceptance").HeaderText = "در انتظار تائید شرکت"
        dgvReport.Columns("Sum").HeaderText = "جمع کل در اختیار نماینده"
        dgvReport.Columns("InVisitorsWarehouse").DefaultCellStyle.Format = "#,###;(#,###)"
    End Sub
#End Region

    Private Sub frmRptGeneral_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub frmRptGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

    Private Sub CalculateSummeryFields()
        Dim OperationalPos As Integer = 0
        Dim NotOperationalAssignedToContract As Integer = 0
        Dim InVisitorsWarehouse As Integer = 0
        Dim WaitingForVisitorsAcceptance As Integer = 0
        Dim WaitingForEniacAcceptance As Integer = 0
        Dim sum As Integer = 0

        For Each dr As DataGridViewRow In dgvReport.Rows
            OperationalPos += Convert.ToInt32(dr.Cells("OPERATIONALPOS").Value)
            NotOperationalAssignedToContract += Convert.ToInt32(dr.Cells("NOTOPTASSIGNEDTOCONTRACT").Value)
            InVisitorsWarehouse += Convert.ToInt32(dr.Cells("INVISITORSWAREHOUSE").Value)
            WaitingForVisitorsAcceptance += Convert.ToInt32(dr.Cells("WAITNIGFORVISITORSACCEPTANCE").Value)
            WaitingForEniacAcceptance += Convert.ToInt32(dr.Cells("WAITINGFORENIACACCEPTANCE").Value)
            sum += Convert.ToInt32(dr.Cells("SUM").Value)
        Next
        lblOperationalPos.Text = OperationalPos.ToString()
        lblNotOperationalAssignedToContract.Text = NotOperationalAssignedToContract.ToString()
        lblInVisitorsWarehouse.Text = InVisitorsWarehouse.ToString()
        lblWaitnigForVisitorsAcceptance.Text = WaitingForVisitorsAcceptance.ToString()
        lblWaitingForEniacAcceptance.Text = WaitingForEniacAcceptance.ToString()
        lblSum.Text = sum.ToString()


    End Sub

    Private Sub dgvReport_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvReport.RowsAdded
        CalculateSummeryFields()
    End Sub

    Private Sub dgvReport_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvReport.RowsRemoved
        CalculateSummeryFields()
    End Sub

    Private Sub dgvReport_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReport.CellDoubleClick


        FillGridByVisitor(Convert.ToInt64(dgvReport.Rows(e.RowIndex).Cells("VisitorID").Value), dgvReport.Columns(e.ColumnIndex).Name)
        InitGridByVisitor()
        lblVisitorName.Text = dgvReport.Rows(e.RowIndex).Cells("visitor").Value.ToString
        tbcMain.SelectedTab = tbpDetailReport
        'InitSearchToolbar()

        Select Case dgvReport.Columns(e.ColumnIndex).Name.ToString
            Case "OPERATIONALPOS"
                rtsSearch.txtSearch.Text = "عملیاتی (فعال در سوئیچ)".Replace("ی", "ي")
                rtsSearch.cboSearchField.SelectedIndex = 3
                If rtsSearch.cboSearchOperation.Items.Count > 0 Then
                    rtsSearch.cboSearchOperation.SelectedIndex = 0
                    rtsSearch.btnSearch.PerformClick()
                End If
            Case "NOTOPTASSIGNEDTOCONTRACT"
                rtsSearch.txtSearch.Text = "تخصیص یافته (غیر عملیاتی)".Replace("ی", "ي")
                rtsSearch.cboSearchField.SelectedIndex = 3
                If rtsSearch.cboSearchOperation.Items.Count > 0 Then
                    rtsSearch.cboSearchOperation.SelectedIndex = 0
                    rtsSearch.btnSearch.PerformClick()
                End If
            Case "PURESENTTOVISITOR"
                rtsSearch.txtSearch.Text = "خالص ارسال شده به نماینده".Replace("ی", "ي")
                rtsSearch.cboSearchField.SelectedIndex = 3
                If rtsSearch.cboSearchOperation.Items.Count > 0 Then
                    rtsSearch.cboSearchOperation.SelectedIndex = 0
                    rtsSearch.btnSearch.PerformClick()
                End If
            Case "INVISITORSWAREHOUSE"
                rtsSearch.txtSearch.Text = "در انبار نماینده".Replace("ی", "ي")
                rtsSearch.cboSearchField.SelectedIndex = 3
                If rtsSearch.cboSearchOperation.Items.Count > 0 Then
                    rtsSearch.cboSearchOperation.SelectedIndex = 0
                    rtsSearch.btnSearch.PerformClick()
                End If
            Case "WAITNIGFORVISITORSACCEPTANCE"
                rtsSearch.txtSearch.Text = "در انتظار تائید نماینده".Replace("ی", "ي")
                rtsSearch.cboSearchField.SelectedIndex = 3
                If rtsSearch.cboSearchOperation.Items.Count > 0 Then
                    rtsSearch.cboSearchOperation.SelectedIndex = 0
                    rtsSearch.btnSearch.PerformClick()
                End If
            Case "WAITINGFORENIACACCEPTANCE"
                rtsSearch.txtSearch.Text = "در انتظار تائید شرکت".Replace("ی", "ي")
                rtsSearch.cboSearchField.SelectedIndex = 3
                If rtsSearch.cboSearchOperation.Items.Count > 0 Then
                    rtsSearch.cboSearchOperation.SelectedIndex = 0
                    rtsSearch.btnSearch.PerformClick()
                End If
            Case "SUM"
                rtsSearch.txtSearch.Text = "جمع کل در اختیار نماینده".Replace("ی", "ي")
                rtsSearch.cboSearchField.SelectedIndex = 3
                If rtsSearch.cboSearchOperation.Items.Count > 0 Then
                    rtsSearch.cboSearchOperation.SelectedIndex = 0
                    rtsSearch.btnSearch.PerformClick()
                End If
            Case "B2B"
                rtsSearch.txtSearch.Text = "B2B".Replace("ی", "ي")
                rtsSearch.cboSearchField.SelectedIndex = 3
                If rtsSearch.cboSearchOperation.Items.Count > 0 Then
                    rtsSearch.cboSearchOperation.SelectedIndex = 0
                    rtsSearch.btnSearch.PerformClick()
                End If

        End Select
    End Sub
    Private Sub FillGridByVisitor(ByVal VisitorID As Int64, ByVal ReportType As String)
        Try
            Dim _rptType As Int16 = 0

            Select Case ReportType
                Case "OPERATIONALPOS"
                    _rptType = 1
                Case "NOTOPTASSIGNEDTOCONTRACT"
                    _rptType = 2
                Case "INVISITORSWAREHOUSE"
                    _rptType = 3
                Case "PURESENTTOVISITOR"
                    _rptType = 4
                Case "WAITNIGFORVISITORSACCEPTANCE"
                    _rptType = 5
                Case "WAITINGFORENIACACCEPTANCE"
                    _rptType = 6
                Case "B2B"
                    _rptType = 7
                Case "SUM"
                    _rptType = 8
                Case Else
                    _rptType = 0

            End Select

            dtdgvDetail = clsDALReport.GetAllVisitorsPosCounts_ByVisitor(VisitorID, _rptType)

            dgvDetail.DataSource = dtdgvDetail
            dvdgvDetail = dtdgvDetail.DefaultView
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGridByVisitor()
        dgvDetail.Columns("REPORTTYPE").Visible = False
        dgvDetail.Columns("POSID").Visible = False
        dgvDetail.Columns("SERIAL_VC").HeaderText = "سریال دستگاه"
        dgvDetail.Columns("ENIACCODE_VC").HeaderText = "کد پیگیری"
        dgvDetail.Columns("POSMODEL").HeaderText = "مدل دستگاه"
        dgvDetail.Columns("REPORTTYPEDESC").HeaderText = "وضعیت"
    End Sub

    Private Sub tbcMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcMain.SelectedIndexChanged
        InitSearchToolbar()
    End Sub

    Private Sub dgvDetail_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvDetail.RowsAdded
        lblCount.Text = dgvDetail.Rows.Count
    End Sub

    Private Sub dgvDetail_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvDetail.RowsRemoved
        lblCount.Text = dgvDetail.Rows.Count
    End Sub
End Class