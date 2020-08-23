Public Class frmRptGetAllTransactionsInDetail
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)
    Private clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

    Private dt As New DataTable
    Private dv As DataView

    Private DateFrom As String
    Private DateTO As String
    Private Vocher As Byte = 0
    Private Sale As Byte = 0
    Private Bill As Byte = 0
    Private Mojudi As Byte = 0
    Private AuthorizationState As Int32
    Private Sub frmRptGetAllTransactionsInDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            cmbTransactionState.SelectedIndex = 0
            FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub
    Private Sub FillCombo()
        Try
            Me.cmbProject.DataSource = clsDALProject.GetAllForUCtrl(ClassUserLoginDataAccess.ThisUser.UserID)
            Me.cmbProject.ValueMember = "ProjectID_tint"
            Me.cmbProject.DisplayMember = "Name_nvc"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ReportSearchToolStrip1_Show_Click() Handles ReportSearchToolStrip1.Show_Click
        Try
            If rucDate.cboDate.SelectedIndex = 1 Then
                DateFrom = rucDate.txtDateFrom.Value
                DateTO = rucDate.txtDateTo.Value
            Else
                DateFrom = ""
                DateTO = ""
            End If

            Vocher = 0
            Sale = 0
            Bill = 0
            Mojudi = 0
            For Counter As Integer = 0 To ChkList.CheckedItems.Count - 1
                Select Case ChkList.CheckedItems.Item(Counter)
                    Case "شارژ"
                        Vocher = 1
                    Case "خرید"
                        Sale = 1
                    Case "پرداخت قبض"
                        Bill = 1
                    Case "موجودی"
                        Mojudi = 1
                End Select
            Next
            'If Vocher = 0 And Sale = 0 And Bill = 0 And Mojudi = 0 Then
            '    MsgBox("هیچ یک از انواع تراکنش انتخاب نشده است", MsgBoxStyle.Exclamation, "هشدار")
            '    Exit Sub
            'End If
            AuthorizationState = cmbTransactionState.SelectedIndex

            FillGrid()
            InitGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub FillGrid()
        Try
            dt = clsDALReport.GetAllTransactionsInDetail(DateFrom, DateTO, ucVisitor.VisitorID, ucManagement_Branch.ManagementID, ucManagement_Branch.BranchID, txtAccountNo.Text.Trim, txtPayaneh.Text.Trim, Vocher, Sale, Bill, Mojudi, AuthorizationState, cmbProject.SelectedValue)
            dv = dt.DefaultView
            dgv.DataSource = dv
            InitGrid()
            ReportSearchToolStrip1.Init(dgv, dt, Me.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            If dgv.Columns.Count > 0 Then

                dgv.Columns("FullName").HeaderText = "نام پذیرنده"
                dgv.Columns("Payaneh").HeaderText = "پایانه"
                dgv.Columns("Pazirandeh").HeaderText = "پذیرنده"
                dgv.Columns("VisitorName").HeaderText = "نماینده"
                dgv.Columns("StoreName").HeaderText = "فروشگاه"
                dgv.Columns("StateName").HeaderText = "استان"
                dgv.Columns("CityName").HeaderText = "شهر"
                dgv.Columns("ManagementName").HeaderText = "مدیریت"
                dgv.Columns("BranchName").HeaderText = "شعبه"
                dgv.Columns("AccountNO").HeaderText = "شماره حساب"
                dgv.Columns("TransactionType").HeaderText = "نوع تراکنش"
                dgv.Columns("TransactionStatus").HeaderText = "وضعیت تراکنش"
                dgv.Columns("Batch_Status").HeaderText = "نوع بچ"
                dgv.Columns("Batch_Clear_Status").HeaderText = "وضعیت تسویه حساب"
                dgv.Columns("VisitorID").Visible = False
                dgv.Columns("ManagementID").Visible = False
                dgv.Columns("BranchID").Visible = False
                dgv.Columns("ProjectID").HeaderText = "کد پروژه"

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub dgv_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        lblCnt.Text = dgv.RowCount
    End Sub
    Private Sub dgv_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        lblCnt.Text = dgv.RowCount
    End Sub

End Class