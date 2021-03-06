Public Class frmRptwithoutamountpercent

    Private clsDALReport As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection

    Dim dv As New DataView

    Dim dtwithoutamountpercent As New DSReport.dtwithoutamountpercentDataTable
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
           
            If cmbVisitor.SelectedValue = 0 Then
                VisitorName = ""
            Else
                VisitorName = cmbVisitor.Text
            End If
            Me.Cursor = Cursors.WaitCursor
            FillGrid()
            InitGrid()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub frmRptwithoutamountpercent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub frmRptwithoutamountpercent_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
#End Region
#Region "Methods"
    Private Sub FormLoad()
        Try
            GrpVisitor.Visible = True
            FillCombo()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillCombo()
        Try
            OPenConnection()

            Me.cmbVisitor.DisplayMember = "FullName_nvc"
            Me.cmbVisitor.ValueMember = "VisitorID"
            Me.cmbVisitor.DataSource = clsDALVisitor.FillVisitor_ForCbo 'clsDALVisitor.GetAllVisitor_ForCbo

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
        Else

        End If
    End Sub
    Private Sub FillGrid()
        Try
            dtwithoutamountpercent.Clear()
            clsDALReport.withoutamountpercent(VisitorName, cmbProject.SelectedValue, dtwithoutamountpercent)
            dv = dtwithoutamountpercent.DefaultView

            dgvReport.DataSource = dv
            If dtwithoutamountpercent.Rows.Count > 1 Then
                lblSumconfigcount.Text = dtwithoutamountpercent.Compute("Sum(configcount)", "")
                lblSumcountlesstran.Text = dtwithoutamountpercent.Compute("Sum(countlesstran)", "")
                

            Else
                lblSumconfigcount.Text = ""
                lblSumcountlesstran.Text = ""
                
            End If
            lblRowCount.Text = dtwithoutamountpercent.Rows.Count.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        dgvReport.Columns("fullname").HeaderText = "نام نماینده"
        dgvReport.Columns("configcount").HeaderText = "تعداد کل پایانه ها"
        dgvReport.Columns("countlesstran").HeaderText = "تعداد پایانه های کم مبلغ"
        dgvReport.Columns("perc").HeaderText = "نسبت پایانه های کم مبلغ به کل پایانه ها"
    End Sub

#End Region

End Class