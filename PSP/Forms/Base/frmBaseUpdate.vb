Public Class frmBaseUpdate

    Public Overridable Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
    End Sub

    Public Overridable Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
    End Sub

    Public Overridable Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.DataGridView1)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(DataGridView1.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, DataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.DataGridView1.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, DataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.DataGridView1.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub

End Class