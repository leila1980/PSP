Public Class frmLogin
    Private Const FormID As Short = 2
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CloseForm()
    End Sub
    Public Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim clsUserLoginDataAccess As New ClassUserLoginDataAccess(modPublicMethod.ConnectionString)
        Try
            clsUserLoginDataAccess.BeginProc()
            If clsUserLoginDataAccess.Login(txtUserName.Text.Trim, txtPassword.Text.Trim, cboProjectID.SelectedValue) Then
                'If clsUserLoginDataAccess.Login("administrator", "adminpass", cboProjectID.SelectedValue) Then
                If ClassUserLoginDataAccess.ThisUser.IsActive_bit = False Then
                    MessageBox.Show("کاربر مورد نظر فعال نمی باشد")
                    txtUserName.Focus()
                    txtUserName.SelectAll()
                Else
                    'modPublicMethod.SaveInReg("PSPMaskanBankUserName", txtUserName.Text)
                    modPublicMethod.TheLatestUserLogin = txtUserName.Text
                    modPublicMethod.AppName = "نرم افزار PSP" & "-" & cboProjectID.Text
                    Me.Close()
                End If
            End If
        Catch
            MessageBox.Show(Err.Description)
            CheckUser = False

            'If Err.Description = "Object reference not set to an instance of an object." OrElse Err.Description.IndexOf("ConnectionString") > 0 Then
            '    CheckUser = False
            '    frmDatabaseSetting.ShowDialog()
            '    clsUserLoginDataAccess = Nothing
            '    clsUserLoginDataAccess = New ClassUserLoginDataAccess(modPublicMethod.ConnectionString)
            '    CheckUser = True
            'Else
            '    MessageBox.Show(Err.Description)
            'End If
        Finally
            txtUserName.Focus()
            txtUserName.SelectAll()
            clsUserLoginDataAccess.EndProc()
        End Try
    End Sub
    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        txtPassword.SelectAll()
    End Sub
    Private Sub frmLogin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        ElseIf e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Alt Then
            CloseForm()
        End If
    End Sub
    Private Sub txtUserName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.GotFocus
        txtUserName.SelectAll()
    End Sub
    Private Sub CloseForm()
        ClassUserLoginDataAccess.ThisUser = Nothing
        End
    End Sub
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'txtUserName.Text = modPublicMethod.TheLatestUserLogin 'modPublicMethod.GetFromReg("PSPMaskanBankUserName")
            FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub FillCombo()
        Try
            Dim clsDAlProject As New ClassDALProject(modPublicMethod.ConnectionString)

            cboProjectID.DataSource = clsDAlProject.GetAll()
            cboProjectID.ValueMember = "ProjectID_tint"
            cboProjectID.DisplayMember = "Name_nvc"

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class