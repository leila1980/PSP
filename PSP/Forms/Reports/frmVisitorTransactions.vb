Public Class frmVisitorTransactions

    Private DateFrom As String = ""
    Private DateTO As String = ""
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection

    Private Sub frmVisitorTransactions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillCombo()
            Me.Cursor = Cursors.WaitCursor
            FillGrid()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Function Validation() As Boolean
        Try
            If rucDate.cboDate.SelectedIndex = 1 And (DateFrom = "" Or DateTO = "") Then
                ErrPro.SetError(rucDate, "بازه تاریخی را وارد کنید")
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvTransactions)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub FillGrid()
        Try
            Dim DALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
            Dim dtVisitor As New DataTable
            dtVisitor = DALVisitor.GetAllVisitorwithAgentName()
            dgvVisitors.AutoGenerateColumns = False
            dgvVisitors.DataSource = dtVisitor

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub TransactionsTabPage_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionsTabPage.Enter
        Try
            If rucDate.cboDate.SelectedIndex = 0 Then
                DateFrom = ""
                DateTO = ""
            Else
                DateFrom = rucDate.txtDateFrom.Value
                DateTO = rucDate.txtDateTo.Value
            End If

            If Validation() = False Then
                Exit Sub
            End If

            If dgvVisitors.Rows.Count > 0 Then
                Dim DALTransaction As New ClassDALTransaction(modPublicMethod.ConnectionString)
                Dim dtTransaction As New DataTable
                dtTransaction = DALTransaction.GetAllcurrent_authorizationForVisitor(dgvVisitors.CurrentRow.Cells("colVisitorID").Value, DateFrom, DateTO, cmbProject.SelectedValue)
                dgvTransactions.DataSource = String.Empty
                dgvTransactions.DataSource = dtTransaction
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
        
    End Sub

    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        Else

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
End Class