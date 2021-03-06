Public Class frmrptAgentActivityByTrns
    Private clsDALReport As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection

    Dim dv As New DataView

    Dim dtGridAgentactivitybyTrans As New DSReport.dtAgentActivityByTrnsDataTable

    Private DateFrom As String = ""
    Private DateTO As String = ""

#Region "Events"
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
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
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
    Private Sub frmrptAgentActivityByTrns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.WindowState = FormWindowState.Maximized
            FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub
#End Region

#Region "Methods"
    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        End If
    End Sub
    Private Sub FillGrid()
        Try

            dtGridAgentactivitybyTrans.Clear()
            clsDALReport.AgentActivitiesByTransaction(DateFrom, DateTO, cmbProject.SelectedValue, dtGridAgentactivitybyTrans)
            dv = dtGridAgentactivitybyTrans.DefaultView

            dgvReport.DataSource = dv
            If (dtGridAgentactivitybyTrans.Rows.Count > 1) Then
                lblTotalCount.Text = dtGridAgentactivitybyTrans.Compute("Sum(TotalTran)", "")
                lblHighCount.Text = dtGridAgentactivitybyTrans.Compute("Sum(HighTransPosSum)", "")
                lblLowCount.Text = dtGridAgentactivitybyTrans.Compute("Sum(LowTransPosSum)", "")
            Else
                lblTotalCount.Text = ""
                lblHighCount.Text = ""
                lblLowCount.Text = ""
            End If
            lblRowCount.Text = dtGridAgentactivitybyTrans.Rows.Count.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        dgvReport.Columns("TotalTran").HeaderText = "تعداد پایانه های دارای تراکنش"
        dgvReport.Columns("HighTransPosSum").HeaderText = "تعداد پایانمه های بالای 4 تراکنش"
        dgvReport.Columns("HighTransPosPercent").HeaderText = "درصد پایانه های بالای 4 تراکنش"
        dgvReport.Columns("LowTransPosSum").HeaderText = "تعداد پایانه های پائین 4 تراکنش"
        dgvReport.Columns("LowTransPosPercent").HeaderText = "درصد پایانه های پائین 4 تراکنش"
        dgvReport.Columns("FullName").HeaderText = "نام و نام خانوادگی"
    End Sub

    Private Sub FillCombo()
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