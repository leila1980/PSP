Public Class frmRptAuthorizationDetail

    Private clsDALRPT2 As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Public DateFrom As String = ""
    Public DateTO As String = ""
    Public Vocher As Byte = 0
    Public Sale As Byte = 0
    Public Bill As Byte = 0
    Public Mojudi As Byte = 0
    Public _rucDate1 As New ReportUserControl_DateInterval()
    Private dtdgv As New DataTable

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

    Private Sub FillGrid()
        Try
            Dim Parent As Byte = 0
            If chkParent.Checked = True Then
                Parent = 1
            Else
                Parent = 0
            End If
            rucDate.cboDate.SelectedIndex = _rucDate1.cboDate.SelectedIndex
            dtdgv = clsDALRPT2.GetAllInformationAuthorization(DateFrom, DateTO, Vocher, Sale, Bill, Mojudi, cmbTransactionState.SelectedIndex, lblOutlet.Text, txtFromPrice.Text, txtToPrice.Text, Parent)
            dgvReport.DataSource = dtdgv
            dgvReport.Columns("Amount").DefaultCellStyle.Format = "N0"
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub frmRptAuthorizationDetail_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        FillGrid()
    End Sub
End Class