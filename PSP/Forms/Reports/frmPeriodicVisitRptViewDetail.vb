Public Class frmPeriodicVisitRptViewDetail
    Private dt As New DataTable
    Private dv As DataView
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)

    Public Payaneh As String
    Public DateTo As String
    Public MaxPrice As String

    Private Sub frmRptViewDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            dt.Clear()
            dt = clsDALReport.GetVisitTransactionsInDetailPerPayaneh(Payaneh, DateTo, MaxPrice)
            dv = dt.DefaultView
            dgv.DataSource = dv
            InitGrid()
            ReportSearchToolStrip1.Init(dgv, dt, Me.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            'dgv.Columns("").HeaderText = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        lblCount.Text = dgv.RowCount

    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        lblCount.Text = dgv.RowCount

    End Sub
End Class