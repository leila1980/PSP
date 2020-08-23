Public Class frmChangePass
    Private clsUserLoginDataAccess As New ClassUserLoginDataAccess(modPublicMethod.ConnectionString)

    Private Sub frmChangePass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            txtUseName.Text = ClassUserLoginDataAccess.ThisUser.UserName_vc
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtNewPassword.Text.Trim = String.Empty Then
            ShowErrorMessage("کلمه عبور جدید خالیست")
        Else
            If txtNewPassword.Text <> txtConfirmPassword.Text Then
                ShowErrorMessage("کلمه عبور جدید با تکرار کلمه عبور برابر نیست")
            Else
                If EnCode(txtPassword.Text) <> ClassUserLoginDataAccess.ThisUser.Password_vc Then
                    ShowErrorMessage("کلمه عبور فعلی اشتباه است")
                Else
                    Try
                        Dim user As ClassUserLoginDataAccess.UserTemplate

                        user.FullName_vc = ClassUserLoginDataAccess.ThisUser.FullName_vc
                        user.IsActive_bit = ClassUserLoginDataAccess.ThisUser.IsActive_bit
                        user.MinAmount = ClassUserLoginDataAccess.ThisUser.MinAmount
                        user.Password_vc = EnCode(txtNewPassword.Text)
                        user.UserID = ClassUserLoginDataAccess.ThisUser.UserID
                        user.UserName_vc = ClassUserLoginDataAccess.ThisUser.UserName_vc

                        clsUserLoginDataAccess.BeginProc()
                        clsUserLoginDataAccess.Update(user)
                        clsUserLoginDataAccess.EndProc()

                        ClassUserLoginDataAccess.ThisUser.Password_vc = user.Password_vc

                        ShowMessage("کلمه عبور با موفقیت تغییر کرد")
                        Me.Close()
                    Catch ex As Exception
                        ShowErrorMessage(ex.Message)
                    End Try

                End If
            End If

        End If


    End Sub

    Private Sub frmChangePass_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub
End Class