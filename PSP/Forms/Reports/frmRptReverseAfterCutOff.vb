Public Class frmRptReverseAfterCutOff
    Private clsDALReport As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim dv As New DataView
    Dim dtReverseAfterCutOff As New DSReport.dtReverseAfterCutOffDataTable
    Private StrDate As String = ""

    

    Private Sub frmRptReverseAfterCutOff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Cmb_Date.Value = GetDateNow()
            Me.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
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
            dtReverseAfterCutOff.Clear()
            clsDALReport.ReverseAfterCutOff(StrDate, dtReverseAfterCutOff)
            dv = dtReverseAfterCutOff.DefaultView

            dgvReport.DataSource = dv
            If dtReverseAfterCutOff.Rows.Count > 1 Then
                lblSumAmount.Text = dtReverseAfterCutOff.Compute("Sum(amount)", "")
            Else
                lblSumAmount.Text = ""
            End If
            lblRowCount.Text = dtReverseAfterCutOff.Rows.Count.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        dgvReport.Columns("trannoasl").HeaderText = "کد تراکنش اصلی"
        dgvReport.Columns("stan").HeaderText = "کدپیگیری"
        dgvReport.Columns("zamaneasl").HeaderText = "زمان تراکنش اصلی"
        dgvReport.Columns("zemaneaslm").HeaderText = "زمان لاتین تراکنش اصلی"
        dgvReport.Columns("zamanerev").HeaderText = "زمان تراکنش بازگشتی"
        dgvReport.Columns("zemanerevm").HeaderText = "زمان لاتین تراکنش بازگشتی"
        dgvReport.Columns("outlet").HeaderText = "کد پایانه"
        dgvReport.Columns("acc_name").HeaderText = "نام فروشگاه"
        dgvReport.Columns("card_number").HeaderText = "شماره کارت"
        dgvReport.Columns("amount").HeaderText = "مبلغ"
        dgvReport.Columns("action_code").HeaderText = "کد عملیات"
        dgvReport.Columns("revid").HeaderText = "کد تراکنش بازگشتی"

    End Sub
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            StrDate = Cmb_Date.Value
            FillGrid()
            InitGrid()
            Me.Cursor = Cursors.Default

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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Print("\rptReverseAfterCutOff.rpt")
    End Sub
    Private Sub btnPrintTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintTotal.Click
        Print("\rptReverseAfterCutOffTotal.rpt")
    End Sub
    Private Sub Print(ByVal RptName As String)
        Try
            Dim sReportPath As String = Application.StartupPath.ToString + "\Reports" + RptName ' "\rptReverseAfterCutOff.rpt"
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            objReport.FileName = sReportPath.Trim.ToString
            Dim myConStr As New ClassConnectionSpliter(ConnectionString)
            objReport.DataSourceConnections(0).SetConnection(myConStr.DbSource, myConStr.DbName, myConStr.DbUserName, myConStr.DbPass)
            objReport.SetDataSource(dv.Table)

            objReport.SetParameterValue("@shamsidate", StrDate)

            If dv.Table.Rows.Count = 0 Or RptName = "\rptReverseAfterCutOffTotal.rpt" Then
                objReport.SetParameterValue("@Alternate", Me.Cmb_Date.Value)
            Else
                objReport.SetParameterValue("@Alternate", "")
            End If

            frmViewr.CrystalReportViewer.ReportSource = objReport
            frmViewr.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

  
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class