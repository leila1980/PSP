Public Class frmBaseList

    Public Overridable Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    End Sub

    Public Overridable Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    End Sub

    Public Overridable Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
    End Sub

    Public Overridable Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
    End Sub

    Public Overridable Sub btnUnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnSelect.Click
    End Sub

    Public Overridable Sub InventSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventSelect.Click
    End Sub

    Private Sub frmBaseList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridView1.AutoGenerateColumns = False
    End Sub

    Private Sub cboSearchBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSearchBy.SelectedIndexChanged
        Me.txtSearch.Clear()
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
        'Me.Text = e.RowBounds.Location.X
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, DataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.DataGridView1.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, DataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.DataGridView1.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub

End Class