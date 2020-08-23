Public Class frmRptPeriodicVisitOld
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)
    Private clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

    Private dt As New DataTable
    Private dv As DataView

    Private DateFrom As String
    Private DateTO As String
    Enum VisitStateEnum
        Visit = 0
        NoVisit = 1
    End Enum
    Public VisitState As VisitStateEnum
    Private Sub frmRptGetAllTransactionsInDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
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
            If Requieredvalidator() = False Then
                Exit Sub
            End If
            FillGrid()
            InitGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Function Requieredvalidator() As Boolean
        Try
            erp.Clear()
            Dim res As Boolean = True
            If rucDate.cboDate.SelectedIndex = 1 Then
                DateFrom = rucDate.txtDateFrom.Value
                DateTO = rucDate.txtDateTo.Value
                If DateFrom = String.Empty Or DateTO = String.Empty Then
                    erp.SetError(rucDate, "بازه تاریخی را کامل انتخاب کنید")
                    res = False
                Else
                    erp.SetError(rucDate, "")
                End If
            Else
                erp.SetError(rucDate, "بازه تاریخی را وارد نمایید")
                res = False
            End If
            If txtMaxPrice.Text = String.Empty Then
                erp.SetError(txtMaxPrice, "حداکثر مبلغ را مشخص فرمایید")
                res = False
            Else
                erp.SetError(txtMaxPrice, "")
            End If
            If txtMonth.Text = String.Empty Then
                erp.SetError(txtMonth, "تعداد ماه را مشخص فرمایید")
                res = False
            Else
                erp.SetError(txtMonth, "")
            End If
            Return res
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub FillGrid()
        Try
            Select Case VisitState
                Case VisitStateEnum.Visit
                    dt.Clear()
                    dt = clsDALReport.PeriodicVisit_Visit(DateFrom, DateTO, txtMonth.Text, txtMaxPrice.Text, cmbProject.SelectedValue)
                Case VisitStateEnum.NoVisit
                    dt.Clear()
                    dt = clsDALReport.PeriodicVisit_NoVisit(DateFrom, DateTO, txtMonth.Text, txtMaxPrice.Text, cmbProject.SelectedValue)
                Case Else
                    Exit Sub
            End Select
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
                dgv.Columns("ContractID").HeaderText = "کد قرارداد"
                dgv.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
                dgv.Columns("Name").HeaderText = "نام پذیرنده"
                dgv.Columns("StoreName").HeaderText = "فروشگاه"
                dgv.Columns("GroupName").HeaderText = "صنف"
                dgv.Columns("StateName").HeaderText = "استان"
                dgv.Columns("CityName").HeaderText = "شهر"
                dgv.Columns("VisitorName").HeaderText = "نماینده"
                dgv.Columns("Outlet_vc").HeaderText = "outlet"
                dgv.Columns("Code_vc").HeaderText = "poscode"
                dgv.Columns("Installdate").HeaderText = "تاریخ نصب"
                dgv.Columns("TheLastVisitDate").HeaderText = "تاریخ آخرین بازدید"
                dgv.Columns("VisitState").HeaderText = "وضعیت بازدید"
                dgv.Columns("TheLastSuccTran").HeaderText = "زمان آخرین تراکنش خرید موفق"
                dgv.Columns("Canceldate").HeaderText = "تاریخ فسخ"

                Select Case VisitState
                    Case VisitStateEnum.Visit
                        dgv.Columns("Serial_vc").HeaderText = "شماره سریال"
                        dgv.Columns("PropertyNo_vc").HeaderText = "اموال"
                        dgv.Columns("EniacCode_vc").HeaderText = "کد انیاک"
                        dgv.Columns("PosModelName").HeaderText = "مدل دستگاه"
                    Case VisitStateEnum.NoVisit
                        dgv.Columns("Serial_vc").Visible = False
                        dgv.Columns("PropertyNo_vc").Visible = False
                        dgv.Columns("EniacCode_vc").Visible = False
                        dgv.Columns("PosModelName").Visible = False
                End Select
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgv_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        lblCount.Text = dgv.RowCount
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        lblCount.Text = dgv.RowCount
    End Sub
End Class