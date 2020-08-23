Public Class frmUndoDeviceCancel

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Try
            'If Validation() = False Then
            '    Exit Sub
            'End If
            Dim clsDALUndoDeviceCancel As New ClassDALUndoDeviceCancel(ConnectionString)
            clsDALUndoDeviceCancel.Outlet = txtOutlet.Text
            clsDALUndoDeviceCancel.UndoDeviceCancel()
            ShowMessage("دستگاه مورد نظر، از حالت فسخ خارج گردید")
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Function Validation() As Boolean
        Try
            Dim result As Boolean = True
            If txtOutlet.Text.Length = 0 Then
                ErrorProvider1.SetError(txtOutlet, "کد پایانه را وارد نمایید")
                result = False
            Else
                Dim clsDALUndoDeviceCancel As New ClassDALUndoDeviceCancel(ConnectionString)

                Dim dt As New DataTable
                clsDALUndoDeviceCancel.Outlet = txtOutlet.Text
                dt = clsDALUndoDeviceCancel.GetDeviceIDPosIDAndSentToSwitchStateByOutlet()
                If dt.Rows.Count = 0 Then
                    ErrorProvider1.SetError(txtOutlet, "دستگاهی با کد پایانه وارد شده ثبت نشده است")
                    result = False
                Else
                    If dt.Rows(0)("PosID") > 0 Then
                        ErrorProvider1.SetError(txtOutlet, "اختصاص داده شده است Pos ،برای این پایانه")
                        result = False
                    Else
                        If dt.Rows(0)("Sent_tint") = 1 Then
                            ErrorProvider1.SetError(txtOutlet, "اطلاعات این پایانه به سویچ ارسال شده است و امکان بازگرداندن فسخ وجود ندارد")
                            result = False
                        Else
                            Dim dtDeviceOfPos As New DataTable
                            clsDALUndoDeviceCancel.DeviceID = dt.Rows(0)("DeviceID")
                            dtDeviceOfPos = clsDALUndoDeviceCancel.GetLastDeviceOfPosByMyDeviceID
                            If dtDeviceOfPos.Rows.Count <> 0 Then
                                ErrorProvider1.SetError(txtOutlet, "ی که به این پایانه اختصاص داشت، به دستگاه دیگری اختصاص داده شده استPos")
                                result = False
                            Else
                                ErrorProvider1.SetError(txtOutlet, "")
                            End If
                        End If
                    End If
                End If
            End If
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub frmUndoDeviceCancel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
End Class