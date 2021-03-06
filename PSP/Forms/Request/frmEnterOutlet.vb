Public Class frmEnterOutlet
    Private mvarOutlet_vc As String

    Public Property Outlet_vc() As String
        Get
            Return mvarOutlet_vc
        End Get
        Set(ByVal value As String)
            mvarOutlet_vc = value
        End Set
    End Property

    Private Sub btnCancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancle.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidateOutlet() As Boolean
        Try
            Dim clsDevice As New ClassDALContract(ConnectionString)

            Dim result As Boolean = True
            If txtOutlet.Text <> String.Empty Then
                '    ErrorProvider.SetError(txtOutlet, "کد پایانه را وارد کنید")
                '    result = False
                'Else
                clsDevice.DOutlet_vc = txtOutlet.Text
                If clsDevice.GetBYDOutlet().Rows.Count = 0 Then
                    ErrorProvider.SetError(txtOutlet, "کد پایانه نا معتبر است")
                    result = False
                Else
                    ErrorProvider.SetError(txtOutlet, "")
                End If
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        ErrorProvider.Clear()
        If ValidateOutlet() = False Then
            Exit Sub
        End If
        Outlet_vc = txtOutlet.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class