Public Class frmIncompleteContracts
    Private dtReport As New DataTable
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection

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

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            FillGrid()
            InitGrid()

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            dtReport.Clear()

            dtReport = clsDALReport.IncompleteContracts(cmbProject.SelectedValue)
            dgvReport.DataSource = dtReport
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            dgvReport.Columns("ContractID").HeaderText = "کد قرارداد "
            dgvReport.Columns("ContractNo_vc").HeaderText = "شماره قرارداد"
            dgvReport.Columns("FirstName_nvc").HeaderText = "نام"
            dgvReport.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
            dgvReport.Columns("AccountNO_vc").HeaderText = "شماره حساب"
            dgvReport.Columns("BranchName_nvc").HeaderText = "شعبه"
            dgvReport.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
            dgvReport.Columns("Address_nvc").HeaderText = "آدرس"
            dgvReport.Columns("GroupName_nvc").HeaderText = "صنف"
            dgvReport.Columns("StateName_nvc").HeaderText = "استان"
            dgvReport.Columns("CityName_nvc").HeaderText = "شهر"

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


    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()

        End If
    End Sub

    Private Sub frmIncompleteContracts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCombo()
    End Sub

    Private Sub ToolStripSeparator3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSeparator3.Click

    End Sub
End Class