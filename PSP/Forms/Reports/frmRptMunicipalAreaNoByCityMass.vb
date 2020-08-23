Imports Oracle.DataAccess.Client

Public Class frmRptMunicipalAreaNoByCityMass
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim ds As New DSReport
    Dim da As New OracleDataAdapter
    Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    Dim prmStateID As New OracleParameter
    Dim prmCityID As New OracleParameter
    Dim prmIsReport As New OracleParameter
    Private clsDALState As New ClassDALState(modPublicMethod.ConnectionString)
    Private clsDALCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Dim dt As New DataTable

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvReport)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub CopyOriginalFile(ByVal DestinationFilePath As String)
        Try
            My.Computer.FileSystem.CopyFile(modPublicMethod.ExcelFilePath, DestinationFilePath)
        Catch ex As Exception
            Throw ex
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
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click, btnChart.Click
        Try
            Print(sender)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillRowsCountLabel()
        slblRowsCount.Text = dgvReport.Rows.Count
    End Sub
    Private Sub FormLoad()
        Try
            OPenConnection()
            FillcboStateID()
            AddHandler cboStateID.SelectedIndexChanged, AddressOf cboStateID_SelectedIndexChanged
            FillcboCityID()
            AddHandler cboCityID.SelectedIndexChanged, AddressOf cboCityID_SelectedIndexChanged
            FillGrid(Me)
            InitGrid()
            FillRowsCountLabel()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGrid(ByVal sender As System.Object)
        Try
            With prmStateID
                .DbType = OracleDbType.Varchar2
                .Value = Me.cboStateID.SelectedValue
                If .Value = Nothing Then .Value = ""
                .ParameterName = "@StateID"
            End With
            With prmCityID
                .DbType = OracleDbType.Varchar2
                .Value = Me.cboCityID.SelectedValue
                If .Value = Nothing Then .Value = ""
                .ParameterName = "@CityID"
            End With
            With prmIsReport
                .DbType = OracleDbType.Int32
                If sender.Name <> "btnChart" Then
                    .Value = 1 'For Report 
                Else
                    .Value = 0 'For Chart
                End If

                .ParameterName = "@IsReport"
            End With

            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                .Parameters.Add(prmStateID)
                .Parameters.Add(prmCityID)
                .Parameters.Add(prmIsReport)
                .CommandText = "GetAllMunicipalAreaNoByCityMass_SP"
            End With
            With da
                .SelectCommand = cmd
                ds.dtMunicipalAreaNoByCityMass.Clear()
                .Fill(ds.dtMunicipalAreaNoByCityMass)
                dt.Clear()
                .Fill(dt)
            End With
            dgvReport.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        dgvReport.Columns("Aria").HeaderText = "نام مناطق شهرداری"
        dgvReport.Columns("Cnt").HeaderText = "تعداد"
    End Sub
    Private Sub frmRptMccMass_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DisposConnection()
    End Sub
    Private Sub frmRptMccMass_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub frmRptMccMass_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub Print(ByVal Sender As System.Object)
        Try
            Dim sReportPath As String = Application.StartupPath.ToString + "\Reports" + "\rptMunicipalAreaNoByCityMass.rpt"
            'sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptMunicipalAreaNoByCityMass.rpt"
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            objReport.FileName = sReportPath.Trim.ToString
            Dim myConStr As New ClassConnectionSpliter(ConnectionString)
            objReport.DataSourceConnections(0).SetConnection(myConStr.DbSource, myConStr.DbName, myConStr.DbUserName, myConStr.DbPass)

            If Sender.Name = "btnPrint" Then
                objReport.SetDataSource(ds)
                objReport.SetParameterValue("@IsReport", True)
            Else
                FillGrid(Sender)
                objReport.SetDataSource(ds)
                objReport.SetParameterValue("@IsReport", False)
            End If
            objReport.SetParameterValue("@ReportDate", GetDateNow)
            objReport.SetParameterValue("@StateID", Me.cboStateID.SelectedValue)
            objReport.SetParameterValue("@CityID", Me.cboCityID.SelectedValue)
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
    Private Sub cboStateID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FillcboCityID()
            FillGrid(Me)
            InitGrid()
            FillRowsCountLabel()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub FillcboStateID()
        Try
            Me.clsDALState.BeginProc()
            cboStateID.DisplayMember = "Name_nvc"
            cboStateID.ValueMember = "StateID"
            Me.cboStateID.DataSource = clsDALState.GetAll
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALState.EndProc()
        End Try
    End Sub
    Private Sub FillcboCityID()
        Try
            Me.clsDALCity.BeginProc()
            If cboStateID.SelectedIndex = -1 Then
                clsDALCity.StateID = "-1"
            Else
                clsDALCity.StateID = cboStateID.SelectedValue
            End If
            Me.cboCityID.DisplayMember = "Name_nvc"
            Me.cboCityID.ValueMember = "CityID"
            Me.cboCityID.DataSource = clsDALCity.GetByStateID
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALCity.EndProc()
        End Try
    End Sub
    Private Sub cboCityID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FillGrid(Me)
            InitGrid()
            FillRowsCountLabel()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub


End Class