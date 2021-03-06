Public Class frmRptTransaction_All_Count
    Private clsDALReport As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim dv As New DataView
    Private DateFrom As String = ""
    Private DateTO As String = ""
  
#Region "Events"
    Private Sub frmRptTransaction_All_Count_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub frmRptTransaction_All_Count_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
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
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
#End Region

#Region "Methods"
    Private Sub FormLoad()
        Try
            Me.WindowState = FormWindowState.Maximized
            Me.Text = "گزارش تعداد تراکنش پایانه"
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
            dgvReport.DataSource = clsDALReport.Transaction_All_Count(DateFrom, DateTO, cmbProject.SelectedValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        dgvReport.Columns("ContractID").HeaderText = "کد قرارداد"
        dgvReport.Columns("ContractingPartyFullName").HeaderText = "نام صاحب فروشگاه"
        dgvReport.Columns("ContractingPartyFullName").Width = 150
        dgvReport.Columns("Name_nvc").HeaderText = "نام فروشگاه"
        dgvReport.Columns("Name_nvc").Width = 150
        dgvReport.Columns("Address_nvc").HeaderText = "آدرس"
        dgvReport.Columns("Address_nvc").Width = 200
        dgvReport.Columns("StateName").HeaderText = "استان"
        dgvReport.Columns("CityName").HeaderText = "شهر"
        dgvReport.Columns("Merchant_vc").HeaderText = "کد پذیرنده"
        dgvReport.Columns("Merchant_vc").Width = 120
        dgvReport.Columns("Outlet_vc").HeaderText = "کد پایانه"
        dgvReport.Columns("TransactionCount").HeaderText = "تعداد تراکنش"
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