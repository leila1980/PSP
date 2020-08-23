Public Class frmVariz

    Private clsDalVariz As New ClassDALVariz(modPublicMethod.ConnectionString)
    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            Me.import()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub import()
        Try
            Dim dtText As New DataTable

            Dim _OpenFileDialog As New OpenFileDialog
            Dim arrPath()
            Dim FileName As String
            Dim arrName()
            Dim VDate As String

            _OpenFileDialog.FileName = ""
            _OpenFileDialog.ShowDialog()
            ClassText.TextFilePath = _OpenFileDialog.FileName
            If ClassText.TextFilePath.ToString.Trim = String.Empty Then
                ShowErrorMessage("فايلي انتخاب نشده است")
                Exit Sub
            End If
            arrPath = ClassText.TextFilePath.ToString.Split("\")
            FileName = arrPath(arrPath.Length - 1)
            arrName = FileName.ToString.Split(".")
            VDate = Microsoft.VisualBasic.Right(arrName(0), 6)
            clsDalVariz.Variz_Date_vc = "13" & VDate.Substring(0, 2) & "/" & VDate.Substring(2, 2) & "/" & VDate.Substring(4, 2)
            Label2.Text = clsDalVariz.Variz_Date_vc
            dtText = ClassText.GetText()
            dgvVariz.DataSource = dtText.DefaultView

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Save()
        Try
            Dim dtVarizHistory As New DataTable
            Dim dtVariz As New DataTable
            Dim TDate As String
            prgbar.Value = 0
            prgbar.Maximum = dgvVariz.Rows.Count

            dtVarizHistory = clsDalVariz.GetByVariz_DateVariz_History(clsDalVariz.Variz_Date_vc)
            If dtVarizHistory.Rows.Count > 0 Then
                ShowErrorMessage("اين فايل قبلا وارد شده است در نتیجه هیچ نوع عملیاتی برروی آن انجام نشد")
                Exit Sub
            End If

            For i As Int32 = 0 To dgvVariz.Rows.Count - 1
                Application.DoEvents()
                prgbar.Value = i + 1
                lblCount.Text = i + 1
                clsDalVariz.AccountNo_vc = dgvVariz.Rows(i).Cells(0).Value.ToString.Substring(0, 10)
                clsDalVariz.Amount_num = dgvVariz.Rows(i).Cells(0).Value.ToString.Substring(10, 13)
                TDate = dgvVariz.Rows(i).Cells(0).Value.ToString.Substring(23, 6)
                clsDalVariz.TRANSACTION_TIME_FA = "13" & TDate.Substring(0, 2) & "/" & TDate.Substring(2, 2) & "/" & TDate.Substring(4, 2)
                clsDalVariz.TRANSACTION_ID = dgvVariz.Rows(i).Cells(0).Value.ToString.Substring(29, 6)
                clsDalVariz.Status = dgvVariz.Rows(i).Cells(0).Value.ToString.Substring(35, 1)

                clsDalVariz.InsertVariz_History()
                dtVariz.Clear()
                dtVariz = clsDalVariz.GetByTRANSACTIONTIMEFA_AND_TRANSACTIONIDVariz()
                If dtVariz.Rows.Count = 0 Then
                    clsDalVariz.InsertVariz()
                Else
                    If dtVariz.Rows(0).Item("Variz_Date_vc") <= clsDalVariz.Variz_Date_vc Then
                        clsDalVariz.UpdateVariz()
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            clsDalVariz.BeginProc()
            Me.Cursor = Cursors.WaitCursor
            Me.Save()
            ShowMessage(modApplicationMessage.msgSuccess)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            clsDalVariz.EndProc()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvVariz_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvVariz.RowsAdded
        lblTotalCount.Text = dgvVariz.RowCount
    End Sub

    Private Sub dgvVariz_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvVariz.RowsRemoved
        lblTotalCount.Text = dgvVariz.RowCount
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim frm As New frmVariz_Print_Edit
        frm.ShowDialog()


    End Sub

    Private Sub frmVariz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

    End Sub
End Class