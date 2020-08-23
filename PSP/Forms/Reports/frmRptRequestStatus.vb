Public Class frmRptRequestStatus
    Private clsDalReport As New ClassDALReport_2(modPublicMethod.ConnectionString)
    'Private clsSearch As New ClassSearch

    Private dtVisitor As New DataTable
    Private dtdgv As New DataTable
    Private dvdgv As DataView
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection

    Private Sub frmRequestState_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillCombo()
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgv)
            End If

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub FormLoad()
        Try
            FillGrid()
            InitGrid()
            Dim clsSearch As New ClassSearch
            clsSearch.Init(cboSearchField, cboSearchOperation, txtSearch, btnSearch, btnSearchBack, btnRemoveFilter, dgv, dtdgv, dvdgv)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillGrid()
        Try
            Me.dgv.DataSource = ""
            dtdgv.Clear()
            dtdgv = clsDalReport.GetRequestStatus(cmbProject.SelectedValue)
            dvdgv = dtdgv.DefaultView
            Me.dgv.DataSource = dvdgv

            If dtdgv.Compute("Sum(DelayPenalty)", "") Is DBNull.Value Then
                lblAllFineAmountSum.Text = String.Empty
            Else
                lblAllFineAmountSum.Text = FormatNumber(dtdgv.Compute("Sum(DelayPenalty)", ""), 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            dgv.Columns("RequestID1").HeaderText = "شماره درخواست"
            dgv.Columns("RequestDate_vc").HeaderText = "تاریخ درخواست"
            dgv.Columns("ImportDate_vc").HeaderText = "تاریخ ورود اطلاعات"

            dgv.Columns("STATNAME").HeaderText = "استان"
            dgv.Columns("CTYNAME").HeaderText = "شهر"
            dgv.Columns("STRNAME").HeaderText = "فروشگاه"
            dgv.Columns("StoreTel1_vc").HeaderText = "تلفن فروشگاه 1"
            dgv.Columns("StoreAddress_nvc").HeaderText = "آدرس فروشگاه"
            dgv.Columns("FullName").HeaderText = "نام بازاریاب"
            dgv.Columns("contractid").HeaderText = "شماره قرارداد"
            dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
            dgv.Columns("Outlet_vC1").HeaderText = "پایانه"
            dgv.Columns("Merchant_vc").HeaderText = "پذیرنده"
            dgv.Columns("Serial_vc").HeaderText = "سریال"
            dgv.Columns("PropertyNo_vc").HeaderText = "شماره اموال"
            dgv.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
            dgv.Columns("posStatus").HeaderText = "وضعیت دستگاه"
            dgv.Columns("InstallDate").HeaderText = "تاریخ نصب"
            dgv.Columns("CancelDate_vc").HeaderText = "تاریخ لغو"
            dgv.Columns("DelayPenalty").HeaderText = "مبلغ جریمه به تومان"
            'dgv.Columns("RequestBankStatusCode").HeaderText = "کد وضعیت"
            'dgv.Columns("RequestBankStatusDate").HeaderText = "تاریخ وضعیت"
            'dgv.Columns("RequestBankStatusDesc").HeaderText = "شرح وضعیت"



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

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        FormLoad()
    End Sub
End Class