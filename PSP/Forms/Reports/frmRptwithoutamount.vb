Public Class frmRptwithoutamount

    Private clsDALReport As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection

    Dim dv As New DataView

    Dim dtwithoutamount As New DSReport.dtwithoutamountDataTable
    Private VisitorName As String = ""
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
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try


            Me.Cursor = Cursors.WaitCursor
            FillGrid()
            InitGrid()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub frmRptwithoutamount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.WindowState = FormWindowState.Maximized
            FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

#End Region
#Region "Methods"


    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        Else

        End If
    End Sub
    Private Sub FillGrid()
        Try
            dtwithoutamount.Clear()
            clsDALReport.withoutamount(cmbProject.SelectedValue, dtwithoutamount)
            dv = dtwithoutamount.DefaultView

            dgvReport.DataSource = dv
            lblRowCount.Text = dtwithoutamount.Rows.Count.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        dgvReport.Columns("fullname").HeaderText = "بازاریاب"
        dgvReport.Columns("outlet").HeaderText = "کد پابانه"
        dgvReport.Columns("sumamount").HeaderText = "جمع مبلغ"
        dgvReport.Columns("maxtran").HeaderText = "زمان آخرین تراکنش"
        dgvReport.Columns("MinTran").HeaderText = "زمان اولین تراکنش"
        dgvReport.Columns("configdate").HeaderText = "ثبت در switch"
        dgvReport.Columns("storename").HeaderText = "نام فروشگاه"
        dgvReport.Columns("address").HeaderText = "آدرس"
        dgvReport.Columns("mantaghe").HeaderText = "منطقه"
        dgvReport.Columns("tel").HeaderText = "تلفن"
        dgvReport.Columns("contractno_vc").HeaderText = "شماره قرار داد"

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