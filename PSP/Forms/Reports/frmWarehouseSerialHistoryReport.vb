Imports Microsoft.Reporting.WinForms
Public Class frmWarehouseSerialHistoryReport

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click

        Dim warehouse As New ClassDALWarehouseStatement(modPublicMethod.ConnectionString)
        warehouse.BeginProc()
        Dim dt As DataTable = warehouse.GetSerialHistory(Me.serialTXT.Text)
        Me.ReportDataSet.WarehouseStatement.Merge(dt)
        warehouse.EndProc()
        Me.ReportViewer1.LocalReport.SetParameters(New ReportParameter("Serial", Me.serialTXT.Text))
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub frmWarehouseSerialHistoryReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            'Me.FormLoad()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message) 'modApplicationMessage.msgLoadFailed
            ClassError.LogError(ex)
        End Try
        Me.ReportViewer1.LocalReport.ExecuteReportInSandboxAppDomain()
    End Sub
End Class