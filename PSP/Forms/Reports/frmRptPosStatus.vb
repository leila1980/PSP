Public Class frmRptPosStatus

    Private clsDalReport As New ClassDALReport(modPublicMethod.ConnectionString)

    Private dtImportExcel As New DataTable
    Private dtdgvReport As New DataTable
    Private dvdgvReport As DataView



    Private Sub btnSelectFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFromExcel.Click
        Try

            Me.dgvReport.EndEdit()

            Me.Import()

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
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

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim Serials As String = ""
        If dtImportExcel.Rows.Count > 0 Then
            For Each row As DataRow In dtImportExcel.Rows
                Serials = Serials + ",'" + row(0).ToString() + "'"
            Next
        End If
        If Serials.Length > 0 Then
            Serials = Serials.Remove(0, 1)
        End If
        Try
            clsDalReport.BeginProc()

            dtdgvReport = clsDalReport.GetAllPosInstalledStatus(Serials)
            dgvReport.DataSource = dtdgvReport
            InitGrid()

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        Finally

            clsDalReport.EndProc()
        End Try

       

    End Sub


    Private Sub InitGrid()
        dgvReport.Columns("PosID").HeaderText = "کد دستگاه"
        dgvReport.Columns("Serial_vc").HeaderText = "سریال دستگاه"
        dgvReport.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
        dgvReport.Columns("PosModel").HeaderText = "مدل دستگاه"
        dgvReport.Columns("PosStatus").HeaderText = "وضعیت دستگاه"
    End Sub

    Private Sub frmRptPosStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
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
End Class