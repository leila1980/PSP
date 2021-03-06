Public Class frmRptAgentDiscordantActivity
    Private clsDALReport As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection

    Dim dv As New DataView

    Public FormType As Type
    Dim dtGridTakhsisDiscordant As New DSReport.dtAgentTakhsisDiscordantDataTable
    Dim dtGridAfterTakhsisDiscordant As New DSReport.dtAgentAfterTakhsisDiscordantDataTable

    Private DateFrom As String = ""
    Private DateTO As String = ""

    Public Enum Type As Short
        ContractTakhsis = 1
        TakhsisConfig = 2
        ConfigIns = 3
        ConfigApIns = 4
    End Enum

#Region "Events"
    Private Sub frmAgentDiscordantActivity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
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
        Me.WindowState = FormWindowState.Maximized

        Try
            Select Case FormType
                Case Type.ContractTakhsis
                    Me.Text = "گزارش مغایرت قراردادهای حتمی شده و تخصیص نشده"
                Case Type.TakhsisConfig
                    Me.Text = "گزارش مغایرت تخصیص شده ها و پیکربندی نشده ها"
                Case Type.ConfigIns
                    Me.Text = "گزارش مغایرت پیکربندی شده ها و نصب نشده ها"
                Case Type.ConfigApIns
                    Me.Text = "گزارش مغایرت پیکربندی شده ها و تائید نصب نشده ها"
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        End If
    End Sub
    Private Sub FillGrid()
        Try
            Select Case FormType
                Case Type.ContractTakhsis
                    dtGridTakhsisDiscordant.Clear()
                    clsDALReport.AgentDiscordantTakhsis(DateFrom, DateTO, cmbProject.SelectedValue, dtGridTakhsisDiscordant)
                    dv = dtGridTakhsisDiscordant.DefaultView
                    lblRowCount.Text = dtGridTakhsisDiscordant.Rows.Count.ToString

                Case Type.TakhsisConfig
                    dtGridAfterTakhsisDiscordant.Clear()
                    clsDALReport.AgentDiscordantAfterTakhsis(DateFrom, DateTO, ClassDALReport_2.ReportType.TakhsisConfig, cmbProject.SelectedValue, dtGridAfterTakhsisDiscordant)
                    dv = dtGridAfterTakhsisDiscordant.DefaultView
                    lblRowCount.Text = dtGridAfterTakhsisDiscordant.Rows.Count.ToString

                Case Type.ConfigIns
                    dtGridAfterTakhsisDiscordant.Clear()
                    clsDALReport.AgentDiscordantAfterTakhsis(DateFrom, DateTO, ClassDALReport_2.ReportType.ConfigIns, cmbProject.SelectedValue, dtGridAfterTakhsisDiscordant)
                    dv = dtGridAfterTakhsisDiscordant.DefaultView
                    lblRowCount.Text = dtGridAfterTakhsisDiscordant.Rows.Count.ToString

                Case Type.ConfigApIns
                    dtGridAfterTakhsisDiscordant.Clear()
                    clsDALReport.AgentDiscordantAfterTakhsis(DateFrom, DateTO, ClassDALReport_2.ReportType.ConfigApIns, cmbProject.SelectedValue, dtGridAfterTakhsisDiscordant)
                    dv = dtGridAfterTakhsisDiscordant.DefaultView
                    lblRowCount.Text = dtGridAfterTakhsisDiscordant.Rows.Count.ToString

            End Select
            dgvReport.DataSource = dv
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Select Case FormType
            Case Type.ContractTakhsis
                dgvReport.Columns("Contractno_vc").HeaderText = "شماره قرارداد"
                dgvReport.Columns("ContractID").HeaderText = "کد قرارداد"
                dgvReport.Columns("Date_vc").HeaderText = "تاریخ"
                dgvReport.Columns("Accountno_vc").HeaderText = "شماره حساب"
                dgvReport.Columns("StoreName").HeaderText = "نام فروشگاه"
                dgvReport.Columns("City").HeaderText = "شهر"
                dgvReport.Columns("address_nvc").HeaderText = "آدرس"
                dgvReport.Columns("FullName").HeaderText = "نام و نام خانوادگی"
                dgvReport.Columns("visitorid").Visible = False

            Case Type.TakhsisConfig, Type.ConfigIns, Type.ConfigApIns
                dgvReport.Columns("Contractno_vc").HeaderText = "شماره قرارداد"
                dgvReport.Columns("Date_vc").HeaderText = "تاریخ"
                dgvReport.Columns("Accountno_vc").HeaderText = "شماره حساب"
                dgvReport.Columns("StoreName").HeaderText = "نام فروشگاه"
                dgvReport.Columns("City").HeaderText = "شهر"
                dgvReport.Columns("address_nvc").HeaderText = "آدرس"
                dgvReport.Columns("FullName").HeaderText = "نام و نام خانوادگی"
                dgvReport.Columns("Outlet_vc").HeaderText = "کد پذیرنده"
                dgvReport.Columns("propertyno_vc").HeaderText = "شماره اموال"
                dgvReport.Columns("eniaccode_vc").HeaderText = "کد پیگیری"
                dgvReport.Columns("serial_vc").HeaderText = "شماره سریال"
                If FormType = Type.TakhsisConfig Then
                    dgvReport.Columns("visitorid").Visible = False
                    dgvReport.Columns("Outlet_vc").Visible = False
                End If
                If FormType = Type.ConfigApIns Then
                    dgvReport.Columns("visitorid").Visible = False
                    dgvReport.Columns("switch_date_vc").HeaderText = "تاریخ نصب"
                End If

        End Select

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