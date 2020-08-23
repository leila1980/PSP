Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Globalization
Imports Oracle.DataAccess.Client


Public Class frmRptVisitorContracts
    Private pc As New PersianCalendar

    Private clsDal As New Dal(modPublicMethod.ConnectionString)
    Private dtList As New DataTable
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim ds As New DSReport
    Private Sub frmVisitorContracts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.FormLoad()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message) 'modApplicationMessage.msgLoadFailed
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub FormLoad()
        Try
            OPenConnection()
            'Me.InitialForm()
            FillCombo()

            modPublicMethod.ErrorProviderClear(ErrorProvider)

            rdoContract.Checked = True
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            Me.Close()
        End Try
    End Sub
    Private Sub frmInstallingPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
        DisposConnection()
    End Sub

    Private Sub ShowResult(ByVal ProjectID As Int16)
        Try
            Dim da As New OracleDataAdapter
            Dim cmd As New Oracle.DataAccess.Client.OracleCommand
            Dim SelectedDateTimedpDateFrom As String = String.Empty
            Dim SelectedDateTimedpDateTo As String = String.Empty

            If RequiredValidator() = False Then
                Exit Sub
            End If

            Dim dt As New DataTable
            If rdoInstalledDevice.Checked = True Then
                With cmd
                    .Connection = cnt
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Clear()
                    .Parameters.Add("VisitorID_", OracleDbType.Varchar2, 10)
                    .Parameters.Item("VisitorID_").Value = cmbVisitor.SelectedValue
                    .Parameters.Add("Install_OK_", OracleDbType.Int16)
                    .Parameters.Item("Install_OK_").Value = 1
                    .Parameters.Add("ProjectID_", OracleDbType.Int32)
                    .Parameters.Item("ProjectID_").Value = ProjectID
                    .Parameters.Add("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
                    ''GetByVisitorIDContractingParty_Contract_Account_Store_Device_Pos_InstallingDetail_SP
                    .CommandText = "GetByVstrID_InstallDetail_Sp"
                End With
                With da
                    .SelectCommand = cmd
                    .Fill(dt)
                End With
            ElseIf rdoContract.Checked = True Then
                With cmd
                    .Connection = cnt
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Clear()
                    .Parameters.Add("VisitorID_", OracleDbType.Decimal)
                    .Parameters.Item("VisitorID_").Value = cmbVisitor.SelectedValue
                    .Parameters.Add("ProjectID_", OracleDbType.Int32)
                    .Parameters.Item("ProjectID_").Value = ProjectID
                    .Parameters.Add("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
                    .CommandText = "GetByVisitorIDContractInfo_sp"
                End With
                With da
                    .SelectCommand = cmd

                    .Fill(dt)
                End With

            ElseIf rdoNotInstalledDevice.Checked = True Then
                With cmd
                    .Connection = cnt
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Clear()
                    .Parameters.Add("VisitorID_", OracleDbType.Varchar2, 10)
                    .Parameters.Item("VisitorID_").Value = cmbVisitor.SelectedValue
                    .Parameters.Add("Install_OK_", OracleDbType.Int16)
                    .Parameters.Item("Install_OK_").Value = 0
                    .Parameters.Add("ProjectID_", OracleDbType.Int32)
                    .Parameters.Item("ProjectID_").Value = ProjectID
                    .Parameters.Add("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
                    ''GetByVisitorIDContractingParty_Contract_Account_Store_Device_Pos_InstallingDetail_SP
                    .CommandText = "GetByVstrID_Cont_noDevice_SP"
                End With
                With da
                    .SelectCommand = cmd
                    .Fill(dt)
                End With
            ElseIf rdoCanceledDevice.Checked = True Then
                With cmd
                    .Connection = cnt
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Clear()
                    .Parameters.Add("VisitorID_", OracleDbType.Varchar2, 10)
                    .Parameters.Item("VisitorID_").Value = cmbVisitor.SelectedValue
                    .Parameters.Add("ProjectID_", OracleDbType.Int32)
                    .Parameters.Item("ProjectID_").Value = ProjectID
                    .Parameters.Add("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
                    ''GetByVisitorIDContractingParty_Contract_Account_Store_Device_Pos_DeviceCancel_SP
                    .CommandText = "GetByVstrID_Cont_DevCancel_SP"
                End With
                With da
                    .SelectCommand = cmd
                    .Fill(dt)
                End With
            ElseIf rdoContractNotDeviceassigning.Checked = True Then
                With cmd
                    .Connection = cnt
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Clear()
                    .Parameters.Add("VisitorID_", OracleDbType.Varchar2, 10)
                    .Parameters.Item("VisitorID_").Value = cmbVisitor.SelectedValue
                    .Parameters.Add("ProjectID_", OracleDbType.Int32)
                    .Parameters.Item("ProjectID_").Value = ProjectID
                    .Parameters.Add("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
                    ''GetByVisitorIDContractingParty_Contract_Account_Store_NotDeviceassigning_SP
                    .CommandText = "GetByVstrIDCont_NoDevassig_SP"
                End With
                With da
                    .SelectCommand = cmd
                    .Fill(dt)
                End With
            ElseIf rdoContractNotAccounting.Checked = True Then
                With cmd
                    .Connection = cnt
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Clear()
                    .Parameters.Add("VisitorID_", OracleDbType.Varchar2, 10)
                    .Parameters.Item("VisitorID_").Value = cmbVisitor.SelectedValue
                    .Parameters.Add("ProjectID_", OracleDbType.Int32)
                    .Parameters.Item("ProjectID_").Value = ProjectID
                    .Parameters.Add("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
                    ''GetByVisitorIDContractingParty_Contract_Account_Store_NotAccounting_SP
                    .CommandText = "GetByVisitorID_Cont_NotAcc_SP"
                End With
                With da
                    .SelectCommand = cmd
                    .Fill(dt)
                End With


            End If


            Me.dgvReport.DataSource = dt

            Try
                SelectedDateTimedpDateFrom = pc.GetYear(dtpFrom.SelectedDateTime) & "/" & IIf(pc.GetMonth(dtpFrom.SelectedDateTime).ToString.Length = 1, "0" & pc.GetMonth(dtpFrom.SelectedDateTime), pc.GetMonth(dtpFrom.SelectedDateTime)) & "/" & IIf(pc.GetDayOfMonth(dtpFrom.SelectedDateTime).ToString.Length = 1, "0" & pc.GetDayOfMonth(dtpFrom.SelectedDateTime), pc.GetDayOfMonth(dtpFrom.SelectedDateTime))
            Catch
                SelectedDateTimedpDateFrom = ""
            End Try
            Try
                SelectedDateTimedpDateTo = pc.GetYear(dtpTo.SelectedDateTime) & "/" & IIf(pc.GetMonth(dtpTo.SelectedDateTime).ToString.Length = 1, "0" & pc.GetMonth(dtpTo.SelectedDateTime), pc.GetMonth(dtpTo.SelectedDateTime)) & "/" & IIf(pc.GetDayOfMonth(dtpTo.SelectedDateTime).ToString.Length = 1, "0" & pc.GetDayOfMonth(dtpTo.SelectedDateTime), pc.GetDayOfMonth(dtpTo.SelectedDateTime))
            Catch
                SelectedDateTimedpDateTo = ""
            End Try

            If SelectedDateTimedpDateFrom = String.Empty And SelectedDateTimedpDateTo = String.Empty Then
                dt.DefaultView.RowFilter = ""
            ElseIf SelectedDateTimedpDateFrom <> String.Empty And SelectedDateTimedpDateTo <> String.Empty Then
                dt.DefaultView.RowFilter = "Date_vc >= '" + SelectedDateTimedpDateFrom + "' And Date_vc <= '" + SelectedDateTimedpDateTo + "'"
            ElseIf SelectedDateTimedpDateFrom <> String.Empty And SelectedDateTimedpDateTo = String.Empty Then
                dt.DefaultView.RowFilter = "Date_vc >= '" + SelectedDateTimedpDateFrom + "'"
            ElseIf SelectedDateTimedpDateFrom = String.Empty And SelectedDateTimedpDateTo <> String.Empty Then
                dt.DefaultView.RowFilter = "Date_vc <= '" + SelectedDateTimedpDateTo + "'"
            End If
            Me.dgvReport.DataSource = dt.DefaultView

            FillRowsCountLabel()

            InitGrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            dgvReport.Columns("ContractingPartyID").HeaderText = "کد طرف قرارداد"
            dgvReport.Columns("ContractingPartyID").Width = 120
            dgvReport.Columns("FirstName_nvc").HeaderText = "نام"
            dgvReport.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
            dgvReport.Columns("LastName_nvc").Width = 120
            dgvReport.Columns("NationalCode_nvc").HeaderText = "کد ملی"
            dgvReport.Columns("ContractID").HeaderText = "کد قرارداد"
            dgvReport.Columns("ContractNO_vc").HeaderText = "شماره قرارداد"
            dgvReport.Columns("ContractNO_vc").Width = 150

            dgvReport.Columns("Date_vc").HeaderText = "تاریخ قرارداد"
            dgvReport.Columns("Date_vc").Width = 150
            dgvReport.Columns("Blocked_bit").HeaderText = "وضعيت مسدودي قرارداد"

            dgvReport.Columns("AAccountNO_vc").HeaderText = "شماره حساب"
            dgvReport.Columns("ACardNO_vc").HeaderText = "شماره کارت"
            dgvReport.Columns("SStoreID").Visible = False
            dgvReport.Columns("SName_nvc").HeaderText = "نام فروشگاه"
            dgvReport.Columns("SAddress_nvc").HeaderText = "آدرس"
            dgvReport.Columns("SMunicipalAreaNO_sint").HeaderText = "منطقه"
            dgvReport.Columns("SPostCode_vc").HeaderText = "کد پستی"
            dgvReport.Columns("SCityName_nvc").HeaderText = "شهر"
            dgvReport.Columns("DDeviceID").Visible = False
            dgvReport.Columns("DCode_vc").HeaderText = "pos code"
            dgvReport.Columns("DOutlet_vc").HeaderText = "Outlet"
            dgvReport.Columns("DVat_vc").HeaderText = "Vat"
            dgvReport.Columns("DMerchant_vc").HeaderText = "Merchant"
            dgvReport.Columns("PPosID").Visible = False
            dgvReport.Columns("PSerial_vc").HeaderText = "سریال"
            dgvReport.Columns("PPropertyNO_vc").HeaderText = "شماره اموال"
            dgvReport.Columns("PEniacCode_vc").HeaderText = "کد پیگیری"
            dgvReport.Columns("InstallingDetailID").Visible = False
            dgvReport.Columns("InstallingHeaderID").Visible = False
            dgvReport.Columns("Status_tint").Visible = False
            dgvReport.Columns("Install_OK").HeaderText = "وضعیت نصب"
            dgvReport.Columns("Ins_date").HeaderText = "تاریخ نصب"
            dgvReport.Columns("Ins_Time").HeaderText = "ساعت نصب"
            dgvReport.Columns("batch").HeaderText = "وضعیت بچ"
            Try
                dgvReport.Columns("DCDesc_nvc").HeaderText = "علت فسخ"
                dgvReport.Columns("DCDate_vc").HeaderText = "تاریخ فسخ"
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillRowsCountLabel()
        slblRowsCount.Text = dgvReport.Rows.Count
    End Sub
    Private Function RequiredValidator() As Boolean

        Dim res As Boolean = True
        If cmbVisitor.SelectedIndex = -1 Then
            ErrorProvider.SetError(cmbVisitor, "بازاریاب را انتخاب کنید")
            res = False
        Else
            ErrorProvider.SetError(cmbVisitor, "")
        End If
        Return res
    End Function

    'Private Sub txtNumber_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        btnShow_Click(Me.btnShow, e)
    '    End If
    'End Sub

    'Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim mhddt As New DataTable
    '        mhddt = Me.clsDal.GetByNumberInstallingHeader(Val(Me.txtNumber.Text))
    '        Dim Id As Integer
    '        If mhddt.Rows.Count > 0 Then
    '            Id = mhddt.Rows(0).Item("InstallingHeaderID")
    '        End If

    '        Dim strSQL As String
    '        strSQL = "Select ('" + mhddt.Rows(0).Item("InstallerIDName_nvc") + "') as InstallerFullName_nvc "
    '        strSQL += ",(ContractingParty_T.FirstName_nvc + ' ' + ContractingParty_T.LastName_nvc) as ContractingPartyFullName_nvc"
    '        strSQL += ",Contract_T.ContractID"
    '        strSQL += ",Store_T.Name_nvc as SName_nvc"
    '        strSQL += ",Store_T.Tel1_vc as STel1_vc"
    '        strSQL += ",Store_T.Address_nvc as SAddress_nvc"
    '        strSQL += ",Store_T.MunicipalAreaNO_sint as SMunicipalAreaNO_sint"
    '        strSQL += ",Device_T.Code_vc as DCode_vc"
    '        strSQL += ",Device_T.Outlet_vc as DOutlet_vc"
    '        strSQL += ",Pos_T.Serial_vc as PSerial_vc"
    '        strSQL += ",Pos_T.PropertyNO_vc as PPropertyNO_vc"
    '        strSQL += ",('*'+cast(InstallingDetail_T.InstallingDetailID as nvarchar)+'*') as InstallingDetailID "
    '        strSQL += "from ContractingParty_T "
    '        strSQL += "Join Contract_T On  ContractingParty_T.ContractingPartyID = Contract_T.ContractingPartyID "
    '        strSQL += "Join Account_T On Contract_T.ContractID = Account_T.ContractID "
    '        strSQL += "Join Store_T On Store_T.AccountID = Account_T.AccountID "
    '        strSQL += "Join Device_T On Device_T.StoreID = Store_T.StoreID "
    '        strSQL += "Join DevicePos_T On DevicePos_T.DeviceID = Device_T.DeviceID "
    '        strSQL += "Join DevicePos_Device_PosAssigning_V On DevicePos_T.DeviceID=DevicePos_Device_PosAssigning_V.DeviceID "
    '        strSQL += "Join Pos_T On DevicePos_Device_PosAssigning_V.PosID=Pos_T.PosID "
    '        strSQL += "Join InstallingDetail_T On InstallingDetail_T.DeviceID = DevicePos_Device_PosAssigning_V.DeviceID "
    '        strSQL += "Where DevicePos_Device_PosAssigning_V.Count_int = 1 "
    '        strSQL += "And InstallingDetail_T.InstallingHeaderID=" + Id.ToString

    '        Dim strSQL1 As String
    '        'strSQL1 = "Select "
    '        'strSQL1 += "PEniacCode_vc,PPropertyNO_vc,SName_nvc "
    '        'strSQL1 += ",PSerial_vc,ContractID as contractingID from "
    '        'strSQL1 += "ContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_V INNER Join dbo.DevicePos_Device_PosAssigning_V 	on "
    '        'strSQL1 += "ContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_V.DDeviceID = DevicePos_Device_PosAssigning_V.DeviceID "
    '        'strSQL1 += "INNER JOIN dbo.InstallingDetail_T on InstallingDetail_T.DeviceID=ContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_V.DDeviceID "
    '        'strSQL1 += "Where(Count_int = 1) And ContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_V.DPDevicePosID in "
    '        'strSQL1 += "(select Max(Device_Pos_DevicePos_PURE_V.DPDevicePosID) from Device_Pos_DevicePos_PURE_V where Count_int=1  "
    '        'strSQL1 += "group by Device_Pos_DevicePos_PURE_V.DDeviceID ) and InstallingDetail_T.InstallingHeaderID=" + Id.ToString

    '        strSQL1 = "Select "
    '        strSQL1 += "Contract_T.ContractID as ContractingID,"
    '        strSQL1 += "Store_T.Name_nvc as SName_nvc,"
    '        strSQL1 += "Pos_T.Serial_vc as PSerial_vc,"
    '        strSQL1 += "Pos_T.PropertyNO_vc as PPropertyNO_vc,"
    '        strSQL1 += "Pos_T.EniacCode_vc as PEniacCode_vc "
    '        strSQL1 += "from Contract_T "
    '        strSQL1 += "Join Account_T On Contract_T.ContractID = Account_T.ContractID "
    '        strSQL1 += "Join Store_T On Store_T.AccountID = Account_T.AccountID "
    '        strSQL1 += "Join Device_T On Device_T.StoreID = Store_T.StoreID "
    '        strSQL1 += "Join DevicePos_T On DevicePos_T.DeviceID = Device_T.DeviceID "
    '        strSQL1 += "Join DevicePos_Device_PosAssigning_V On DevicePos_T.DeviceID=DevicePos_Device_PosAssigning_V.DeviceID "
    '        strSQL1 += "Join Pos_T On DevicePos_Device_PosAssigning_V.PosID=Pos_T.PosID "
    '        strSQL1 += "Join InstallingDetail_T On InstallingDetail_T.DeviceID = DevicePos_Device_PosAssigning_V.DeviceID "
    '        strSQL1 += "Where(DevicePos_Device_PosAssigning_V.Count_int = 1) "
    '        strSQL1 += "And InstallingDetail_T.InstallingHeaderID=" + Id.ToString


    '        Dim ds As New DataSet1
    '        Dim da As New OracleDataAdapter
    '        da.SelectCommand = New Oracle.DataAccess.Client.OracleCommand(strSQL)
    '        da.SelectCommand.Connection = New Oracle.DataAccess.Client.OracleConnection(ConnectionString)
    '        da.Fill(ds, "DTInstalling")
    '        da.SelectCommand.CommandText = strSQL1
    '        da.Fill(ds, "Detail")

    '        da.SelectCommand.CommandText = "Select GetDate()"
    '        da.SelectCommand.Connection.Open()
    '        Dim Now As Date = da.SelectCommand.ExecuteScalar
    '        da.SelectCommand.Connection.Close()

    '        Dim dr As DataRow = ds.Header.NewRow
    '        dr.Item("BarcodeNumber_bint") = "*" + Me.txtNumber.Text + "*"
    '        dr.Item("Number_bint") = Me.txtNumber.Text
    '        dr.Item("FullName_nvc") = mhddt.Rows(0).Item("InstallerIDName_nvc")
    '        dr.Item("Date_vc") = DateTool.SpellDate(Now)
    '        ds.Header.Rows.Add(dr)

    '        Dim r As New rptInstalling
    '        Dim i As New rptCardex
    '        r.SetDataSource(ds)
    '        i.SetDataSource(ds)
    '        r.Refresh()
    '        i.Refresh()
    '        r.PrintToPrinter(1, True, 0, 0)
    '        i.PrintToPrinter(1, True, 0, 0)
    '    Catch ex As Exception
    '        modPublicMethod.ShowErrorMessage(ex.Message)
    '        ClassError.LogError(ex)
    '    End Try
    'End Sub

    Private Sub frmInstallingPrint_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

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
    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvReport.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(Me.dgvReport.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub

    Private Sub btnShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbVisitor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVisitor.SelectedIndexChanged
        Try

        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub DateFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Try

            Catch ex As Exception
                modPublicMethod.ShowErrorMessage(ex.Message)
                ClassError.LogError(ex)
            End Try
        End If
    End Sub

    Private Sub DateTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Try

            Catch ex As Exception
                modPublicMethod.ShowErrorMessage(ex.Message)
                ClassError.LogError(ex)
            End Try
        End If
    End Sub

    Private Sub rdoInstalledDevice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoInstalledDevice.CheckedChanged
        If rdoInstalledDevice.Checked = True Then
            Try

            Catch ex As Exception
                modPublicMethod.ShowErrorMessage(ex.Message)
                ClassError.LogError(ex)
            End Try
        End If
    End Sub

    Private Sub rdoContract_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoContract.CheckedChanged
        If rdoContract.Checked = True Then
            Try

            Catch ex As Exception
                modPublicMethod.ShowErrorMessage(ex.Message)
                ClassError.LogError(ex)
            End Try
        End If
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Print()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub Print()
        Try
            'Dim r As New rptVisitorContracts
            'r.SetDataSource(ds)

            'r.Refresh()

            'r.PrintToPrinter(1, True, 0, 0)

            Dim sReportPath As String = Application.StartupPath.ToString + "\Reports" + "\rptVisitorContracts.rpt"
            'sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptVisitorContracts.rpt"
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            objReport.FileName = sReportPath.Trim.ToString
            Dim myConStr As New ClassConnectionSpliter(ConnectionString)
            objReport.DataSourceConnections(0).SetConnection(myConStr.DbSource, myConStr.DbName, myConStr.DbUserName, myConStr.DbPass)
            objReport.SetDataSource(ds)
            'ClassReportSetting.SetReportParameters(objReport)
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

    Private Sub frmRptVisitorContracts_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub

    Private Sub rdoNotInstalledDevice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNotInstalledDevice.CheckedChanged
        If rdoNotInstalledDevice.Checked = True Then
            Try

            Catch ex As Exception
                modPublicMethod.ShowErrorMessage(ex.Message)
                ClassError.LogError(ex)
            End Try
        End If
    End Sub

    Private Sub rdoCanceledDevice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCanceledDevice.CheckedChanged
        If rdoCanceledDevice.Checked = True Then
            Try

            Catch ex As Exception
                modPublicMethod.ShowErrorMessage(ex.Message)
                ClassError.LogError(ex)
            End Try
        End If
    End Sub

    Private Sub rdoContractNotAccounting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoContractNotAccounting.CheckedChanged
        If rdoContractNotAccounting.Checked = True Then
            Try

            Catch ex As Exception
                modPublicMethod.ShowErrorMessage(ex.Message)
                ClassError.LogError(ex)
            End Try
        End If
    End Sub

    Private Sub rdoContractNotDeviceassigning_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoContractNotDeviceassigning.CheckedChanged
        If rdoContractNotDeviceassigning.Checked = True Then
            Try

            Catch ex As Exception
                modPublicMethod.ShowErrorMessage(ex.Message)
                ClassError.LogError(ex)
            End Try
        End If
    End Sub

    Private Sub dtp_SelectedDateTimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.SelectedDateTimeChanged, dtpTo.SelectedDateTimeChanged
        Try


        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub FillCombo()
        Try
            OPenConnection()

            Me.cmbVisitor.DisplayMember = "FullName_nvc"
            Me.cmbVisitor.ValueMember = "VisitorID"
            Me.cmbVisitor.DataSource = clsDALVisitor.FillVisitor_ForCbo

            Dim clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

            Me.cmbProject.DataSource = clsDALProject.GetAllForUCtrl(ClassUserLoginDataAccess.ThisUser.UserID)
            Me.cmbProject.ValueMember = "ProjectID_tint"
            Me.cmbProject.DisplayMember = "Name_nvc"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbProject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProject.SelectedIndexChanged
        Try

        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            ShowResult(cmbProject.SelectedValue)
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
End Class