Public Class frmEnterDuplicateRequestID
    Private mvarDuplicateRequestID As Int64
    Public Property DuplicateRequestID() As Int64
        Get
            Return mvarDuplicateRequestID
        End Get
        Set(ByVal value As Int64)
            mvarDuplicateRequestID = value
        End Set
    End Property

    Private Sub btnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        ErrorProvider.Clear()
        If txtDuplicateRequestID.Text = "" Then
            ErrorProvider.SetError(txtDuplicateRequestID, "شماره درخواست تکراری را وارد کنید")
            Exit Sub
        End If
        DuplicateRequestID = txtDuplicateRequestID.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class