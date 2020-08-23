Imports Oracle.DataAccess.Client

Public Class frmRptTransactionsByStoreID
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim ds As New DSReport
    Dim da As New OracleDataAdapter
    Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    Dim dt As New DataTable

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Search()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub Search()
        Try
            Dim _frm As New frmSearchStore
            _frm.ShowDialog()
            txtStoreID.Text = _frm.CurID.ToString
            txtStoreName_nvc.Text = _frm.CurName_nvc
            ShowMethod()
        Catch ex As Exception
            txtStoreID.Text = ""
            txtStoreName_nvc.Text = ""
            Throw ex
        End Try
    End Sub

    Private Sub ShowMethod()
        Try
            If CheckValidity() = False Then
                ShowErrorMessage("موردی برای نمایش انتخاب نشده است")
                Exit Sub
            End If
            FillTextBoxes(Convert.ToInt64(txtStoreID.Text), cmbProject.SelectedValue)
            FillGrid(Convert.ToInt64(txtStoreID.Text))
            InitGrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillTextBoxes(ByVal StoreID As Int64, ByVal ProjectID As Int16)
        Try
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add("@ProjectID", OracleDbType.Int32)
                .Parameters.Item("@ProjectID").Value = ProjectID
                .CommandText = "GetByStoreIDContract_SP"
                OracleCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@StoreID").Value = StoreID
                End With
            End With
            dt.Clear()
            With da
                .SelectCommand = cmd
                .Fill(dt)
            End With
            If dt.Rows.Count > 0 Then
                txtContractDate_vc.Text = dt.Rows(0).Item("date_vc")
            Else
                txtContractDate_vc.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGrid(ByVal StoreID As Int64)
        Try
            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .CommandText = "GetByStoreIDStore_Device_Install_HistoryAuthorization_SP"
                OracleCommandBuilder.DeriveParameters(cmd)
                With .Parameters
                    .Item("@StoreID").Value = StoreID
                End With
            End With
            With da
                .SelectCommand = cmd
                .Fill(ds.dtStore_Device_Install_HistoryAtuoRriazation)
            End With

            dgvReport.DataSource = ds.dtStore_Device_Install_HistoryAtuoRriazation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            dgvReport.Columns("Ins_date").HeaderText = "تاریخ نصب"
            dgvReport.Columns("TRANSACTION_TIME").HeaderText = "زمان تراکنش"
            dgvReport.Columns("TRANSACTION_TIME_EN").Visible = False
            dgvReport.Columns("LOCAL_DATE").HeaderText = "زمان تراکنش در محل دستگاه"
            dgvReport.Columns("LOCAL_DATE_EN").Visible = False
            dgvReport.Columns("OUTLET").HeaderText = "OUTLET"
            dgvReport.Columns("MCC").HeaderText = "MCC"
            dgvReport.Columns("CARD_NUMBER").HeaderText = "شماره کارت"
            dgvReport.Columns("ACCOUNT").HeaderText = "شماره حساب"
            dgvReport.Columns("AMOUNT").HeaderText = "مبلغ تراکنش"
            dgvReport.Columns("ACTION").HeaderText = "وضعیت"
            dgvReport.Columns("[ACTION]").Visible = False


            dgvReport.Columns("TRANSACTION_TIME").Width = 170
            dgvReport.Columns("TRANSACTION_TIME_EN").Visible = False
            dgvReport.Columns("LOCAL_DATE").Width = 170
            dgvReport.Columns("LOCAL_DATE_EN").Visible = False
            dgvReport.Columns("CARD_NUMBER").Width = 150
            dgvReport.Columns("ACCOUNT").Width = 150
            dgvReport.Columns("AMOUNT").Width = 150
            dgvReport.Columns("ACTION").Width = 120
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function CheckValidity() As Boolean
        If txtStoreID.Text.Trim = "" Then
            Return False
        End If
        Return True
    End Function

    Private Sub frmRptTransactionsByStoreID_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            OPenConnection()
            FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        End If
    End Sub
    Private Sub DisposConnection()
        cnt.Close()
        cnt.Dispose()
        cnt = Nothing
    End Sub

    Private Sub frmRptTransactionsByStoreID_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            DisposConnection()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If CheckValidity() = False Then
                ShowErrorMessage("موردی برای چاپ انتخاب نشده است")
                Exit Sub
            End If

            Print()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub Print()
        Try
            Dim sReportPath As String = Application.StartupPath.ToString + "\Reports" + "\rptTrnsactionsByStore.rpt"
            'sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptTrnsactionsByStore.rpt"
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            objReport.FileName = sReportPath.Trim.ToString
            Dim myConStr As New ClassConnectionSpliter(ConnectionString)
            objReport.DataSourceConnections(0).SetConnection(myConStr.DbSource, myConStr.DbName, myConStr.DbUserName, myConStr.DbPass)
            objReport.SetDataSource(ds)
            'ClassReportSetting.SetReportParameters(objReport)
            objReport.SetParameterValue("@ReportDate", GetDateNow)
            objReport.SetParameterValue("@StoreName_nvc", txtStoreName_nvc.Text.Trim)
            objReport.SetParameterValue("@ContractDate_vc", txtContractDate_vc.Text.Trim)

            frmViewr.CrystalReportViewer.ReportSource = objReport
            frmViewr.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
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
End Class