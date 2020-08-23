Public Class frmPosVisitorHistory

    Private clsDalPosVisitor As New ClassDALPosVisitor(modPublicMethod.ConnectionString)
    Private mvarPosID As Int64
    Private dtdgv As New DataTable
    Private dvdgv As DataView

    Public Property PosID() As Int64
        Get
            Return mvarPosID
        End Get
        Set(ByVal value As Int64)
            mvarPosID = value
        End Set
    End Property

    Private Sub frmPosVisitorHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgv.AutoGenerateColumns = False
        Try
            dtdgv.Clear()

            dtdgv = clsDalPosVisitor.GetByPosIDPosVisitorHistory(PosID)
            dvdgv = dtdgv.DefaultView
            Me.dgv.DataSource = dvdgv

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgv_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgv.RowPrePaint
        Try
            Dim eventTime As Date = Date.Parse(dtdgv.Rows(e.RowIndex)("DateTime").ToString())
            dgv.Rows(e.RowIndex).Cells("colDateFa_vc").ToolTipText = eventTime.TimeOfDay().ToString()
            dgv.Rows(e.RowIndex).Cells("colTime").Value = eventTime.TimeOfDay().ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmPosVisitorHistory_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown, dgv.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class