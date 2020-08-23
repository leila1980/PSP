Imports Oracle.DataAccess.Client
Imports System.IO

Public Class frmRptGeneral
    Private clsDALContract As New ClassDALContract(modPublicMethod.ConnectionString)

    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim dt As New DataTable
    Dim ds As New DSReport
    Dim da As New OracleDataAdapter
    Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    Dim dv As New DataView
    Private dtdgv As New DataTable


#Region "Events"

    'Private Sub ExportToExcel()
    '    Dim strDestinationFilePath As String = ""
    '    Try
    '        If Me.dgvReport.Rows.Count = 0 Then
    '            modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
    '            Exit Sub
    '        End If

    '        Dim frm As New SaveFileDialog
    '        frm.Filter = "Excel File|*.xls"
    '        If frm.ShowDialog() <> Windows.Forms.DialogResult.OK Then
    '            Exit Sub
    '        End If
    '        strDestinationFilePath = frm.FileName
    '        CopyOriginalFile(strDestinationFilePath)


    '        Dim Excel As New ClassDALExcel
    '        Excel.ConnectionOpen(strDestinationFilePath)
    '        For Each dr As DataRow In dt.DefaultView.ToTable.Rows
    '            Excel.ContractingPartyID = dr.Item("ContractingPartyID").ToString
    '            Excel.FirstName_nvc = dr.Item("FirstName_nvc").ToString
    '            Excel.LastName_nvc = dr.Item("LastName_nvc").ToString
    '            Excel.FatherName_nvc = dr.Item("FatherName_nvc").ToString
    '            Excel.IdentityCertificateNO_nvc = dr.Item("IdentityCertificateNO_nvc").ToString
    '            Excel.NationalCode_nvc = dr.Item("NationalCode_nvc").ToString
    '            Excel.Gender_bit = dr.Item("Gender_bit").ToString
    '            Excel.BirthDate_vc = dr.Item("BirthDate_vc").ToString
    '            Excel.Title_nvc = dr.Item("Title_nvc").ToString
    '            Excel.HomeAddress_nvc = dr.Item("HomeAddress_nvc").ToString
    '            Excel.HomeTel_vc = dr.Item("HomeTel_vc").ToString
    '            Excel.HavingAccount_bit = dr.Item("HavingAccount_bit").ToString
    '            Excel.AccountNO_vc = dr.Item("AccountNO_vc").ToString
    '            Excel.CardNo_vc = dr.Item("CardNo_vc").ToString
    '            Excel.ContractID = dr.Item("ContractID").ToString
    '            Excel.ContractNo_vc = dr.Item("ContractNo_vc").ToString
    '            Excel.Merchant_vc = dr.Item("Merchant_vc").ToString
    '            Excel.SaveDate_vc = dr.Item("SaveDate_vc").ToString
    '            Excel.Date_vc = dr.Item("Date_vc").ToString
    '            Excel.AAccountNO_vc = dr.Item("AAccountNO_vc").ToString
    '            Excel.ACardNo_vc = dr.Item("ACardNo_vc").ToString
    '            Excel.SGroupID = dr.Item("SGroupID").ToString
    '            Excel.SName_nvc = dr.Item("SName_nvc").ToString
    '            Excel.SPostCode_vc = dr.Item("SPostCode_vc").ToString
    '            Excel.SAddress_nvc = dr.Item("SAddress_nvc").ToString
    '            Excel.STel1_vc = dr.Item("STel1_vc").ToString
    '            Excel.STel2_vc = dr.Item("STel2_vc").ToString
    '            Excel.SFax_vc = dr.Item("SFax_vc").ToString
    '            Excel.SMunicipalAreaNO_sint = dr.Item("SMunicipalAreaNO_sint").ToString
    '            Excel.SSIdentityTypeSDate_vc = dr.Item("SSIdentityTypeSDate_vc").ToString
    '            Excel.SDeviceCount_tint = dr.Item("SDeviceCount_tint").ToString
    '            Excel.BranchName_nvc = dr.Item("BranchName_nvc").ToString
    '            Excel.AccountTypeIDName_nvc = dr.Item("AccountTypeIDName_nvc").ToString
    '            Excel.DegreeIDName_nvc = dr.Item("DegreeIDName_nvc").ToString
    '            Excel.StateIDName_nvc = dr.Item("StateIDName_nvc").ToString
    '            Excel.CityIDName_nvc = dr.Item("CityIDName_nvc").ToString
    '            Excel.VisitorFullName_nvc = dr.Item("VisitorFullName_nvc").ToString
    '            Excel.ABranchIDName_nvc = dr.Item("ABranchIDName_nvc").ToString
    '            Excel.AAccountTypeIDName_nvc = dr.Item("AAccountTypeIDName_nvc").ToString
    '            Excel.SEstateConditionIDName_nvc = dr.Item("SEstateConditionIDName_nvc").ToString
    '            Excel.SIdentityTypeIDName_nvc = dr.Item("SIdentityTypeIDName_nvc").ToString
    '            Excel.SGroupName_nvc = dr.Item("SGroupName_nvc").ToString
    '            Excel.SStateIDName_nvc = dr.Item("SStateIDName_nvc").ToString
    '            Excel.SCityName_nvc = dr.Item("SCityName_nvc").ToString
    '            Excel.CIdentityTypeIDName_nvc = dr.Item("CIdentityTypeIDName_nvc").ToString

    '            Excel.InsertIntoRptGeneral()
    '        Next
    '        Excel.ConnectionClose()
    '        ShowMessage(msgSuccess)
    '    Catch ex As Exception
    '        ShowErrorMessage(ex.Message)
    '        My.Computer.FileSystem.DeleteFile(strDestinationFilePath)
    '    End Try
    'End Sub

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

    Private Sub btnExportToText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToText.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Text Files|*.txt"

            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                Dim dt As New DataTable
                dt = Me.dgvReport.DataSource.ToTable
                clsExcel.ExportToText(dt)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub



    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            FillGrid(cmbProject.SelectedValue, cmbCMSProject.SelectedValue)
            InitGrid()
            FillRowsCountLabel()

            Dim clsSearch As New ClassSearch
            clsSearch.Init(cboSearchField, cboSearchOperation, txtSearch, btnSearch, btnSearchBack, btnRemoveFilter, dgvReport, dtdgv, dv)

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

#End Region
#Region "Methods"

    Private Sub FillRowsCountLabel()
        slblRowsCount.Text = dgvReport.Rows.Count
    End Sub

    Private Sub FormLoad()
        Try
            FillCombo()
            FillCMSCombo()
            OPenConnection()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillGridOLD(ByVal ProjectID As Int16, ByVal cmsProjectID As Int16)
        Try
            ds = New DSReport
            dgvReport.DataSource = ""
            da = New OracleDataAdapter
            cmd = New Oracle.DataAccess.Client.OracleCommand

            With cmd
                .Connection = cnt
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 0
                .Parameters.Clear()

                .Parameters.Add("ProjectID_", OracleDbType.Int32)
                .Parameters.Item("ProjectID_").Value = ProjectID
                .Parameters.Add("cmsProjectID_", OracleDbType.Int32)
                .Parameters.Item("cmsProjectID_").Value = cmsProjectID
                .Parameters.Add("UserID_", OracleDbType.Int32)
                .Parameters.Item("UserID_").Value = ClassUserLoginDataAccess.ThisUser.UserID
                .Parameters.Add("Result_", OracleDbType.RefCursor, ParameterDirection.Output)
                'GetAllContractingParty_Contract_Account_Store_Device_Pos_SP
                .CommandText = "GETALLCONTRACTINGPARTYSINF1_SP"
            End With
            With da
                .SelectCommand = cmd
                .Fill(ds.dtGeneral)
            End With
            dgvReport.DataSource = ""
            'dgvReport.Rows.Clear()

            dv = ds.dtGeneral.DefaultView
            Me.dtdgv = ds.dtGeneral
            dgvReport.DataSource = dv

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillGrid(ByVal ProjectID As Int16, ByVal cmsProjectID As Int16)
        Try
            Dim dalContract As New ClassDALContract(modPublicMethod.ConnectionString)
            dtdgv = dalContract.GetAllContractingPartyInfo(ProjectID, cmsProjectID, ClassUserLoginDataAccess.ThisUser.UserID)
            dgvReport.DataSource = dtdgv
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitGrid()
        dgvReport.Columns("FirstName_nvc").HeaderText = "نام"
        dgvReport.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
        dgvReport.Columns("FatherName_nvc").HeaderText = "نام پدر"
        dgvReport.Columns("NationalCode_nvc").HeaderText = "کد ملی"
        dgvReport.Columns("Title_nvc").HeaderText = "سمت"
        dgvReport.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
        dgvReport.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
        dgvReport.Columns("Mobile_vc").HeaderText = "موبایل"
        dgvReport.Columns("EMAIL_NVC").HeaderText = "پست الکترونیکی"
        dgvReport.Columns("AccountNO_vc").HeaderText = "شماره حساب موجود"
        dgvReport.Columns("STATEID").HeaderText = "کد استان"
        dgvReport.Columns("CITYID").HeaderText = "کد شهر"
        dgvReport.Columns("BranchName_nvc").HeaderText = "نام شعبه موجود"
        dgvReport.Columns("DegreeIDName_nvc").HeaderText = "مدرک تحصیلی"
        dgvReport.Columns("AccountTypeIDName_nvc").HeaderText = " نوع حساب موجود"
        dgvReport.Columns("CIdentityTypeIDName_nvc").HeaderText = "نوع مدرک شناسایی"
        dgvReport.Columns("CityIDName_nvc").HeaderText = "نام شهر محل تولد"
        dgvReport.Columns("StateIDName_nvc").HeaderText = "نام استان محل تولد"
        dgvReport.Columns("ContractID").HeaderText = "کد قرارداد"
        dgvReport.Columns("Merchant_vc").HeaderText = "کد پذیرنده"
        dgvReport.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت قرارداد"
        dgvReport.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
        dgvReport.Columns("VISITORID").HeaderText = "کد بازاریاب"
        dgvReport.Columns("MarketingByName_nvc").HeaderText = "بازاریابی توسط"
        dgvReport.Columns("VisitorFullName_nvc").HeaderText = "نام ویزیتور"
        dgvReport.Columns("ASHABAACCOUNT").HeaderText = "کدشبا"
        dgvReport.Columns("ABranchIDName_nvc").HeaderText = "نام شعبه"
        dgvReport.Columns("AAccountTypeIDName_nvc").HeaderText = "نوع حساب"
        dgvReport.Columns("SName_nvc").HeaderText = "نام فروشگاه "
        dgvReport.Columns("SPostCode_vc").HeaderText = "کد پستی"
        dgvReport.Columns("SADDRESS_NVC").HeaderText = "آدرس فروشگاه"
        dgvReport.Columns("STel1_vc").HeaderText = "تلفن1فروشگاه"
        dgvReport.Columns("STel2_vc").HeaderText = "موبایل"
        dgvReport.Columns("SFax_vc").HeaderText = "فکس"
        dgvReport.Columns("SDeviceCount_tint").HeaderText = "تعداد پز"
        dgvReport.Columns("SSTATEID").HeaderText = "کد استان فروشگاه"
        dgvReport.Columns("SCITYID").HeaderText = "کد شهر فروشگاه"
        dgvReport.Columns("SCITYNAME_NVC").HeaderText = "نام شهر فروشگاه"
        dgvReport.Columns("SGroupName_nvc").HeaderText = "نام صنف"
        dgvReport.Columns("SSTATEIDNAME_NVC").HeaderText = "نام استان فروشگاه"
        dgvReport.Columns("SIdentityTypeIDName_nvc").HeaderText = "نوع مدرک شناسایی فروشگاه"
        dgvReport.Columns("SEstateConditionIDName_nvc").HeaderText = "وضعیت تملک"
        dgvReport.Columns("DCode_vc").HeaderText = "Pos Code"
        dgvReport.Columns("DOutlet_vc").HeaderText = "کد پایانه"
        dgvReport.Columns("DMerchant_vc").HeaderText = "کد پذیرنده"
        dgvReport.Columns("DVat_vc").HeaderText = "Vat"
        dgvReport.Columns("PPROPERTYNO_VC").HeaderText = "شماره اموال"
        dgvReport.Columns("PSERIAL_VC").HeaderText = "سریال دستگاه"
        dgvReport.Columns("PENIACCODE_VC").HeaderText = "کد پیگیری"
        dgvReport.Columns("PPARTNO_INT").HeaderText = "PARTNO"
        dgvReport.Columns("CMSPROJECTS").HeaderText = "پروژه های CMS"
    End Sub

    Private Sub InitGridOLD()

        dgvReport.Columns("MarketingByName_nvc").HeaderText = "بازاریابی توسط"
        'dgvReport.Columns("ContractingPartyID").HeaderText = "کد طرف قرارداد"
        dgvReport.Columns("ContractingPartyID").Visible = False
        dgvReport.Columns("FirstName_nvc").HeaderText = "نام"
        dgvReport.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
        dgvReport.Columns("FatherName_nvc").HeaderText = "نام پدر"
        'dgvReport.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
        dgvReport.Columns("IdentityCertificateNO_nvc").Visible = False
        dgvReport.Columns("NationalCode_nvc").HeaderText = "کد ملی"
        'dgvReport.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
        dgvReport.Columns("BirthDate_vc").Visible = False
        dgvReport.Columns("Title_nvc").HeaderText = "سمت"
        dgvReport.Columns("HomeAddress_nvc").HeaderText = "آدرس منزل"
        dgvReport.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
        dgvReport.Columns("Mobile_vc").HeaderText = "موبایل"
        dgvReport.Columns("StateIDName_nvc").HeaderText = "نام استان محل تولد"
        dgvReport.Columns("CityIDName_nvc").HeaderText = "نام شهر محل تولد"
        dgvReport.Columns("CIdentityTypeIDName_nvc").HeaderText = "نوع مدرک شناسایی"
        dgvReport.Columns("DegreeIDName_nvc").HeaderText = "مدرک تحصیلی"
        'dgvReport.Columns("HavingAccount_bit").HeaderText = "حساب دارد"
        dgvReport.Columns("HavingAccount_bit").Visible = False
        dgvReport.Columns("AccountNO_vc").HeaderText = "شماره حساب موجود"
        'dgvReport.Columns("CardNo_vc").HeaderText = "شماره کارت موجود"
        dgvReport.Columns("CardNo_vc").Visible = False
        dgvReport.Columns("BranchName_nvc").HeaderText = "نام شعبه موجود"
        dgvReport.Columns("AccountTypeIDName_nvc").HeaderText = " نوع حساب موجود"
        dgvReport.Columns("ContractID").HeaderText = "کد قرارداد"
        'dgvReport.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
        dgvReport.Columns("ContractNo_vc").Visible = False
        dgvReport.Columns("Merchant_vc").HeaderText = "کد قرارداد PSP"
        dgvReport.Columns("SaveDate_vc").HeaderText = "تاریخ ثبت قرارداد"
        dgvReport.Columns("Date_vc").HeaderText = "تاریخ عقد قرارداد"
        dgvReport.Columns("VisitorFullName_nvc").HeaderText = "نام ویزیتور"
        'dgvReport.Columns("AAccountNO_vc").HeaderText = "شماره حساب"
        'dgvReport.Columns("ACardNo_vc").HeaderText = "شماره کارت"
        dgvReport.Columns("AAccountNO_vc").Visible = False
        dgvReport.Columns("ACardNo_vc").Visible = False
        dgvReport.Columns("ABranchIDName_nvc").HeaderText = "نام شعبه"
        dgvReport.Columns("AAccountTypeIDName_nvc").HeaderText = "نوع حساب"
        dgvReport.Columns("SGroupID").HeaderText = "کد صنف"
        dgvReport.Columns("SName_nvc").HeaderText = "نام فروشگاه "
        dgvReport.Columns("SStateIDName_nvc").HeaderText = "نام استان فروشگاه"
        dgvReport.Columns("SCityName_nvc").HeaderText = "نام شهر فروشگاه"
        dgvReport.Columns("SGroupName_nvc").HeaderText = "نام صنف"
        dgvReport.Columns("SPostCode_vc").HeaderText = "کد پستی"
        'dgvReport.Columns("SMunicipalAreaNO_sint").HeaderText = "منطقه شهرداری"
        dgvReport.Columns("SMunicipalAreaNO_sint").Visible = False
        dgvReport.Columns("SAddress_nvc").HeaderText = "آدرس فروشگاه"
        dgvReport.Columns("STel1_vc").HeaderText = "تلفن1فروشگاه"
        dgvReport.Columns("STel2_vc").HeaderText = "تلفن2فروشگاه"
        dgvReport.Columns("SFax_vc").HeaderText = "فکس"
        dgvReport.Columns("SIdentityTypeIDName_nvc").HeaderText = "نوع مدرک شناسایی فروشگاه"
        dgvReport.Columns("SEstateConditionIDName_nvc").HeaderText = "وضعیت تملک"
        'dgvReport.Columns("SSIdentityTypeSDate_vc").HeaderText = "تاریخ شروع اجاره"
        'dgvReport.Columns("SSIdentityTypeEDate_vc").HeaderText = "تاریخ پایان اجاره"

        dgvReport.Columns("SSIdentityTypeSDate_vc").Visible = False
        dgvReport.Columns("SSIdentityTypeEDate_vc").Visible = False

        dgvReport.Columns("SDeviceCount_tint").HeaderText = "تعداد پز"


        dgvReport.Columns("DCode_vc").HeaderText = "Pos Code"
        dgvReport.Columns("DOutlet_vc").HeaderText = "Outlet"
        dgvReport.Columns("DMerchant_vc").HeaderText = "Merchant"
        dgvReport.Columns("DVat_vc").HeaderText = "Vat"
        dgvReport.Columns("PSerial_vc").HeaderText = "سریال دستگاه"
        dgvReport.Columns("PPropertyNo_vc").HeaderText = "شماره اموال"
        dgvReport.Columns("PEniacCode_vc").HeaderText = "کد پیگیری"
        dgvReport.Columns("PActive_tint").HeaderText = "وضعیت فعالیت"
        'dgvReport.Columns("Gender_bit").HeaderText = "جنسیت"
        dgvReport.Columns("Gender_bit").Visible = False


        'dgvReport.Columns("ContractingPartyID").Width = 150
        'dgvReport.Columns("Merchant_vc").Width = 150
        'dgvReport.Columns("SaveDate_vc").Width = 150
        'dgvReport.Columns("Date_vc").Width = 150
        'dgvReport.Columns("SAddress_nvc").Width = 150
        'dgvReport.Columns("STel1_vc").Width = 150
        'dgvReport.Columns("STel2_vc").Width = 150
        'dgvReport.Columns("SSIdentityTypeSDate_vc").Width = 150
        'dgvReport.Columns("SSIdentityTypeEDate_vc").Width = 150
        'dgvReport.Columns("StateIDName_nvc").Width = 150
        'dgvReport.Columns("CityIDName_nvc").Width = 150
        'dgvReport.Columns("SIdentityTypeIDName_nvc").Width = 150
        'dgvReport.Columns("SAddress_nvc").Width = 150
        'dgvReport.Columns("SStateIDName_nvc").Width = 150
        'dgvReport.Columns("SCityName_nvc").Width = 150
        'dgvReport.Columns("CIdentityTypeIDName_nvc").Width = 150
        'dgvReport.Columns("SMunicipalAreaNO_sint").Width = 150
        'dgvReport.Columns("DDeviceID").HeaderText = "DeviceID"
        'dgvReport.Columns("DPosID").HeaderText = "PosID"
        'dgvReport.Columns("PPosID").Visible = False
        'dgvReport.Columns("accNumber_bint").HeaderText = "شماره بچ حساب"
        'dgvReport.Columns("swtNumber_bint").HeaderText = "شماره بچ سوئیچ"
        'dgvReport.Columns("InsNumber_bint").HeaderText = "شماره بچ نصب"

        'dgvReport.Columns("swtNumber_bint").Visible = False
        'dgvReport.Columns("InsNumber_bint").Visible = False

        'dgvReport.Columns("accNumber_bint").Width = 120
        'dgvReport.Columns("swtNumber_bint").Width = 120
        'dgvReport.Columns("InsNumber_bint").Width = 120
        'dgvReport.Columns("ZoncanNo_nvc").HeaderText = "شماره زونکن"

        dgvReport.Columns("cmsprojects").HeaderText = "پروژه های CMS"




        dgvReport.Columns("cmsprojects").Width = 120
        'dgvReport.Columns("shaparakcode_vc").HeaderText = "علامت اختصاری"
        'dgvReport.Columns("shaparakcode_vc").Width = 120

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

    Private Sub frmRptGeneral_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        DisposConnection()
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
            'Dim r As New rptGeneral
            'r.SetDataSource(ds)

            'r.Refresh()

            'r.PrintToPrinter(1, True, 0, 0)

            Dim sReportPath As String = Application.StartupPath.ToString + "\Reports" + "\rptGeneral.rpt"
            'sReportPath = "E:\Projects\EniacProjects\PSPWorkingDirectory\PSP\PSP\Reports\rptGeneral.rpt"
            Dim objReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            objReport.FileName = sReportPath.Trim.ToString
            Dim myConStr As New ClassConnectionSpliter(ConnectionString)
            objReport.DataSourceConnections(0).SetConnection(myConStr.DbSource, myConStr.DbName, myConStr.DbUserName, myConStr.DbPass)
            objReport.SetDataSource(dt)
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

    Private Sub FillCMSCombo()
        Try
            OPenConnection()
            Dim clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

            Me.cmbCMSProject.DataSource = clsDALProject.GetAllCMSProject()
            Me.cmbCMSProject.ValueMember = "CMSPROJECTID_INT"
            Me.cmbCMSProject.DisplayMember = "NAME_NVC"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class