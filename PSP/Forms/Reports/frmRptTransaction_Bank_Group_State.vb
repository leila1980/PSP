Imports Oracle.DataAccess.Client

Public Class frmRptTransaction_Bank_Group_State
    Private clsDALContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim ds As New DSReport
    Dim da As New OracleDataAdapter
    Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    Dim prmIsReport As New OracleParameter
    Dim prmOrder As New OracleParameter

    Public Bank_Group_StateFormType As Bank_Group_StateType
    Dim dt As New DataTable
    Public Enum Bank_Group_StateType As Short
        transaction_Amount_Bank = 1
        Transaction_Amount_Group = 2
        Transaction_Amount_State = 3
        Transaction_Count_Bank = 4
        Transaction_Count_Group = 5
        Transaction_Count_State = 6
    End Enum
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
    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvReport.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(Me.dgvReport.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub
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
    Private Sub frmRptGeneral_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        DisposConnection()
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click, btnChart.Click
        Try
            Print(sender)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

#End Region
#Region "Methods"
    Private Sub FormLoad()
        Try
            OPenConnection()
            rbtDescending.Checked = True
            FillGrid(Me)
            InitGrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGrid(ByVal Sender As Object)
        Try
            Select Case Bank_Group_StateFormType
                Case Bank_Group_StateType.transaction_Amount_Bank

                    With prmIsReport
                        .DbType = OracleDbType.Int32
                        If Sender.Name <> "btnChart" Then
                            .Value = 1 'For Report 
                        Else
                            .Value = 0 'For Chart
                        End If
                        .ParameterName = "@IsReport"
                    End With

                    With prmOrder
                        .DbType = OracleDbType.Varchar2
                        If rbtAssending.Checked = True Then
                            .Value = "A" 'For Report 
                        Else
                            .Value = "D" 'For Chart
                        End If
                        .ParameterName = "@Order"
                    End With

                    With cmd
                        .Connection = cnt
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Clear()
                        .Parameters.Add(prmIsReport)
                        .Parameters.Add(prmOrder)
                        .CommandText = "Transaction_Amount_Bank_SP"
                    End With
                    With da
                        .SelectCommand = cmd
                        ds.dtTransaction_Amount_Bank.Clear()
                        .Fill(ds.dtTransaction_Amount_Bank)
                        dt.Clear()
                        .Fill(dt)
                    End With

                Case Bank_Group_StateType.Transaction_Amount_Group
                    With prmIsReport
                        .DbType = OracleDbType.Int32
                        If Sender.Name <> "btnChart" Then
                            .Value = 1 'For Report 
                        Else
                            .Value = 0 'For Chart
                        End If
                        .ParameterName = "@IsReport"
                    End With

                    With prmOrder
                        .DbType = OracleDbType.Varchar2
                        If rbtAssending.Checked = True Then
                            .Value = "A" 'For Report 
                        Else
                            .Value = "D" 'For Chart
                        End If
                        .ParameterName = "@Order"
                    End With


                    With cmd
                        .Connection = cnt
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Clear()
                        .Parameters.Add(prmIsReport)
                        .Parameters.Add(prmOrder)
                        .CommandText = "Transaction_Amount_Group_SP"
                    End With
                    With da
                        .SelectCommand = cmd
                        ds.dtTransaction_Amount_Group.Clear()
                        .Fill(ds.dtTransaction_Amount_Group)
                        dt.Clear()
                        .Fill(dt)
                    End With


                Case Bank_Group_StateType.Transaction_Amount_State
                    With prmIsReport
                        .DbType = OracleDbType.Int32
                        If Sender.Name <> "btnChart" Then
                            .Value = 1 'For Report 
                        Else
                            .Value = 0 'For Chart
                        End If
                        .ParameterName = "@IsReport"
                    End With

                    With prmOrder
                        .DbType = OracleDbType.Varchar2
                        If rbtAssending.Checked = True Then
                            .Value = "A" 'For Report 
                        Else
                            .Value = "D" 'For Chart
                        End If
                        .ParameterName = "@Order"
                    End With

                    With cmd
                        .Connection = cnt
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Clear()
                        .Parameters.Add(prmIsReport)
                        .Parameters.Add(prmOrder)
                        .CommandText = "Transaction_Amount_State_SP"
                    End With
                    With da
                        .SelectCommand = cmd
                        ds.dtTransaction_Amount_State.Clear()
                        .Fill(ds.dtTransaction_Amount_State)
                        dt.Clear()
                        .Fill(dt)
                    End With


                Case Bank_Group_StateType.Transaction_Count_Bank
                    With prmIsReport
                        .DbType = OracleDbType.Int32
                        If Sender.Name <> "btnChart" Then
                            .Value = 1 'For Report 
                        Else
                            .Value = 0 'For Chart
                        End If
                        .ParameterName = "@IsReport"
                    End With

                    With prmOrder
                        .DbType = OracleDbType.Varchar2
                        If rbtAssending.Checked = True Then
                            .Value = "A" 'For Report 
                        Else
                            .Value = "D" 'For Chart
                        End If
                        .ParameterName = "@Order"
                    End With

                    With cmd
                        .Connection = cnt
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Clear()
                        .Parameters.Add(prmIsReport)
                        .Parameters.Add(prmOrder)
                        .CommandText = "Transaction_Count_Bank_SP"
                    End With
                    With da
                        .SelectCommand = cmd
                        ds.dtTransaction_Count_Bank.Clear()
                        .Fill(ds.dtTransaction_Count_Bank)
                        dt.Clear()
                        .Fill(dt)
                    End With
                    dgvReport.DataSource = ds.dtTransaction_Count_Bank


                Case Bank_Group_StateType.Transaction_Count_Group

                    With prmIsReport
                        .DbType = OracleDbType.Int32
                        If Sender.Name <> "btnChart" Then
                            .Value = 1 'For Report 
                        Else
                            .Value = 0 'For Chart
                        End If
                        .ParameterName = "@IsReport"
                    End With

                    With prmOrder
                        .DbType = OracleDbType.Varchar2
                        If rbtAssending.Checked = True Then
                            .Value = "A" 'For Report 
                        Else
                            .Value = "D" 'For Chart
                        End If
                        .ParameterName = "@Order"
                    End With
                    With cmd
                        .Connection = cnt
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Clear()
                        .Parameters.Add(prmIsReport)
                        .Parameters.Add(prmOrder)
                        .CommandText = "Transaction_Count_Group_SP"
                    End With
                    With da
                        .SelectCommand = cmd
                        ds.dtTransaction_Count_Group.Clear()
                        .Fill(ds.dtTransaction_Count_Group)
                        dt.Clear()
                        .Fill(dt)
                    End With
                    dgvReport.DataSource = ds.dtTransaction_Count_Group
                Case Bank_Group_StateType.Transaction_Count_State
                    With prmIsReport
                        .DbType = OracleDbType.Int32
                        If Sender.Name <> "btnChart" Then
                            .Value = 1 'For Report 
                        Else
                            .Value = 0 'For Chart
                        End If
                        .ParameterName = "@IsReport"
                    End With

                    With prmOrder
                        .DbType = OracleDbType.Varchar2
                        If rbtAssending.Checked = True Then
                            .Value = "A" 'For Report 
                        Else
                            .Value = "D" 'For Chart
                        End If
                        .ParameterName = "@Order"
                    End With
                    With cmd
                        .Connection = cnt
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Clear()
                        .Parameters.Add(prmIsReport)
                        .Parameters.Add(prmOrder)
                        .CommandText = "Transaction_Count_State_SP"
                    End With
                    With da
                        .SelectCommand = cmd
                        ds.dtTransaction_Count_State.Clear()
                        .Fill(ds.dtTransaction_Count_State)
                        dt.Clear()
                        .Fill(dt)
                    End With
            End Select
            dgvReport.DataSource = dt

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Select Case Bank_Group_StateFormType
            Case Bank_Group_StateType.transaction_Amount_Bank
                dgvReport.Columns("BANK_NAME").HeaderText = "نام بانک"
                dgvReport.Columns("Amt").HeaderText = "جمـع ریـالی تـراکنـش"
                dgvReport.Columns("Amt").Width = 220

            Case Bank_Group_StateType.Transaction_Amount_Group
                dgvReport.Columns("MCC").HeaderText = "Mcc"
                dgvReport.Columns("GroupName_nvc").HeaderText = "نام صنف"
                dgvReport.Columns("GroupName_nvc").Width = 150
                dgvReport.Columns("MCC").Width = 80
                dgvReport.Columns("Amt").HeaderText = "جمـع ریـالی تـراکنـش"
                dgvReport.Columns("Amt").Width = 220

            Case Bank_Group_StateType.Transaction_Amount_State
                dgvReport.Columns("StateName_nvc").HeaderText = "استان"
                dgvReport.Columns("Amt").HeaderText = "جمع ریالی تـراکنـش"
                dgvReport.Columns("Amt").Width = 220

            Case Bank_Group_StateType.Transaction_Count_Bank
                dgvReport.Columns("BANK_NAME").HeaderText = "نام بانک"
                dgvReport.Columns("cnt").HeaderText = "تعداد تـراکنـش"
                dgvReport.Columns("cnt").Width = 200
                dgvReport.Columns("cnt").Width = 220

            Case Bank_Group_StateType.Transaction_Count_Group
                dgvReport.Columns("MCC").HeaderText = "Mcc"
                dgvReport.Columns("GroupName_nvc").HeaderText = "نام صنف"
                dgvReport.Columns("cnt").HeaderText = "تعداد تـراکنـش"
                dgvReport.Columns("cnt").Width = 220
                dgvReport.Columns("GroupName_nvc").Width = 150
                dgvReport.Columns("MCC").Width = 80


            Case Bank_Group_StateType.Transaction_Count_State
                dgvReport.Columns("StateName_nvc").HeaderText = "استان"
                dgvReport.Columns("cnt").HeaderText = "تعداد تـراکنـش"
                dgvReport.Columns("cnt").Width = 220

        End Select
    End Sub
    Private Sub Print(ByVal Sender As System.Object)
        Try
            Dim sReportPath As String
            Select Case Bank_Group_StateFormType
                Case Bank_Group_StateType.transaction_Amount_Bank
                    sReportPath = Application.StartupPath.ToString + "\Reports" + "\rptTransaction_Amount_Bank.rpt"
                    'sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptTransaction_Amount_Bank.rpt"

                Case Bank_Group_StateType.Transaction_Amount_Group
                    sReportPath = Application.StartupPath.ToString + "\Reports" + "\rptTransaction_Amount_Group.rpt"
                    'sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptTransaction_Amount_Group.rpt"

                Case Bank_Group_StateType.Transaction_Amount_State
                    sReportPath = Application.StartupPath.ToString + "\Reports" + "\rptTransaction_Amount_State.rpt"
                    'sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptTransaction_Amount_State.rpt"

                Case Bank_Group_StateType.Transaction_Count_Bank
                    sReportPath = Application.StartupPath.ToString + "\Reports" + "\rptTransaction_Count_Bank.rpt"
                    'sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptTransaction_Count_Bank.rpt"

                Case Bank_Group_StateType.Transaction_Count_Group
                    sReportPath = Application.StartupPath.ToString + "\Reports" + "\rptTransaction_Count_Group.rpt"
                    'sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptTransaction_Count_Group.rpt"

                Case Bank_Group_StateType.Transaction_Count_State
                    sReportPath = Application.StartupPath.ToString + "\Reports" + "\rptTransaction_Count_State.rpt"
                    ' sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptTransaction_Count_State.rpt"

            End Select

            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            objReport.FileName = sReportPath.Trim.ToString
            Dim myConStr As New ClassConnectionSpliter(ConnectionString)
            objReport.DataSourceConnections(0).SetConnection(myConStr.DbSource, myConStr.DbName, myConStr.DbUserName, myConStr.DbPass)
            objReport.SetDataSource(ds)
            If Sender.Name = "btnPrint" Then
                objReport.SetParameterValue("@IsReport", True) 'ReP
            Else
                objReport.SetParameterValue("@IsReport", False) 'Chart
            End If
            If rbtAssending.Checked = True Then
                objReport.SetParameterValue("@order", "A") 'ReP
            Else
                objReport.SetParameterValue("@order", "D") 'Chart
            End If
            objReport.SetParameterValue("@ReportDate", GetDateNow)
            frmViewr.CrystalReportViewer.ReportSource = objReport
            frmViewr.ShowDialog()
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
    Private Sub DisposConnection()
        cnt.Close()
        cnt.Dispose()
        cnt = Nothing
    End Sub
#End Region
End Class