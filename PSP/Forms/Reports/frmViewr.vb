Public Class frmViewr
    Dim ds As New DataSet1

    Private Sub frmViewr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrystalReportViewer.ShowGroupTreeButton = False
        CrystalReportViewer.DisplayGroupTree = False
        CrystalReportViewer.ShowRefreshButton = False
        Me.Focus()
    End Sub

End Class