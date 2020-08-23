Public Class frmAssignContractToVisitor
    Private clsDalVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)

    Private CLSUserLoginDA As New ClassUserLoginDataAccess(ConnectionString)

    Private dtVisitor As New DataTable
    
    Private currentUserVisitorID As Int64

    Private dtImportExcel As New DataTable

    Private flag As Boolean

#Region "Control Events"
    Private Sub frmAssignPosToVisitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FormLoad()
            cboVisitor.SelectedIndex = -1
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnSelectFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFromExcel.Click
        Try

            Me.dgv.EndEdit()
            Me.Import()
            If dtImportExcel.Rows.Count > 0 Then

                Me.dtImportExcel.Columns(0).ColumnName = "colcontractid"
                Me.dtImportExcel.DefaultView.Sort = "colcontractid desc"

                For Each row As DataRow In dtImportExcel.Rows
                    dgv.Rows.Add(row("colcontractid"))

                Next
                Me.dgv.EndEdit()
                Me.TSLabel.Text = dgv.RowCount

            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

#End Region

#Region "Methods"
    Private Sub FormLoad()
        Try
            dgv.AutoGenerateColumns = False
            cboVisitor.SelectedIndex = -1
            CLSUserLoginDA.BeginProc()
            currentUserVisitorID = CLSUserLoginDA.GetVisitorIDByUserID(ClassUserLoginDataAccess.ThisUser.UserID)

            If Not currentUserVisitorID > 0 Then
                currentUserVisitorID = -1
            End If
            CLSUserLoginDA.EndProc()
            FillCboVisitor()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillCboVisitor()
        Try
            dtVisitor.Clear()
          
            dtVisitor = clsDalVisitor.GetUsersVisitorByUserID(ClassUserLoginDataAccess.ThisUser.UserID)

            cboVisitor.DataSource = dtVisitor
            cboVisitor.ValueMember = "VisitorID"
            cboVisitor.DisplayMember = "FullName"

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub Import()
        Try
            dtImportExcel.Clear()
            Dim frm As New OpenFileDialog
            frm.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If frm.FileName = String.Empty Then
                    Exit Sub
                End If
                Dim clsExcel As New ClassExcel(frm.FileName)
                dtImportExcel = clsExcel.Read(1, True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If Me.cboVisitor.SelectedIndex = -1 Then
            Me.erp.SetError(cboVisitor, "ویزیتورانتخاب شود")
            flag = False
            Exit Sub
        ElseIf Me.dgv.RowCount <= 0 Then
            Me.erp.SetError(dgv, "اکسل قراردادهاانتخاب شود")
            flag = False
            Exit Sub
        Else
            erp.Dispose()
        End If


        For Each row As DataGridViewRow In dgv.Rows
            row.Cells("Colvisitorid").Value = cboVisitor.SelectedValue.ToString
            row.Cells("ColFullName").Value = cboVisitor.Text.ToString
            flag = True
        Next

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            clsDalVisitor.BeginProc()
            If dgv.Rows.Count > 0 And flag Then
                For Each row As DataGridViewRow In dgv.Rows
                    clsDalVisitor.ContractID = row.Cells("colcontractid").Value
                    clsDalVisitor.VisitorID = row.Cells("Colvisitorid").Value
                    clsDalVisitor.UpdateVisitorInContract()
                Next
            Else
                ShowMessage("عدم انتخاب قرداد یا بازاریاب")
                Exit Sub
            End If
        Catch ex As Exception
            clsDalVisitor.RollBackProc()
            Throw ex
        Finally
            dgv.DataSource = Nothing
            Me.TSLabel.Text = Nothing
            dgv.Rows.Clear()
            cboVisitor.SelectedIndex = -1
            clsDalVisitor.EndProc()
        End Try

    End Sub
End Class