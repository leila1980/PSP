''' <summary>
''' DataBase Setting 
''' </summary>
''' <remarks></remarks>
Public Class frmDatabaseSetting
#Region "Events"
    Private Sub frmDatabaseSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        LoadConnectionstring()
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If RequiredValidator() = False Then
                MsgBox("اطلاعات وارد شده کامل نمی باشد")
                Exit Sub
            End If
            SetConnectionString()
            Me.Close()
        Catch
            modPublicMethod.ShowErrorMessage(modApplicationMessage.msgSaveConnectionStringError)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub rbtSQLAuthentication1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (rbtSQLAuthentication1.Checked) Then
            GroupBox3.Enabled = True
        Else
            GroupBox3.Enabled = False
        End If
    End Sub
    Private Sub frmDatabaseSetting_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        End If
    End Sub
#End Region
#Region "Methods"
    Public Sub LoadConnectionstring()
        Dim strExistingConnstr() As String
        Try
            strExistingConnstr = My.Settings.strConnectionString.Split(";")
            txbServerName1.Text = strExistingConnstr(0).Replace("Data Source=", "")
            txbDatabaseName1.Text = strExistingConnstr(1).ToString().Replace("Initial Catalog=", "")
            If (My.Settings.strConnectionString.Contains("Integrated security = true")) Then
                rbtWindowsAuthentication1.Checked = True
            Else
                rbtSQLAuthentication1.Checked = True
                txbUserName1.Text = strExistingConnstr(3).Replace("User ID=", "")
                txbPassword1.Text = strExistingConnstr(4).Replace("Password=", "")
            End If
            txbConnectionTimeout1.Text = strExistingConnstr(5).Replace("Connection Timeout=", "")
        Catch ex As Exception
            ' Throw ex
        End Try
    End Sub
    Private Sub SetConnectionString()
        Dim _strConnstr As String
        If (rbtSQLAuthentication1.Checked) Then
            _strConnstr = "Data Source=" & txbServerName1.Text & ";" & "Initial Catalog=" & txbDatabaseName1.Text + ";" & "Persist Security Info=True;" & "User ID=" & txbUserName1.Text & ";" + "Password=" & txbPassword1.Text & ";Connection Timeout=" & IIf(txbConnectionTimeout1.Text.Trim = "", "10", txbConnectionTimeout1.Text.Trim)
        Else
            _strConnstr = "Data Source=" & txbServerName1.Text & ";" & "Initial Catalog=" & txbDatabaseName1.Text + ";" & "Persist Security Info=True;" & "Integrated security = true;Connection Timeout=" & IIf(txbConnectionTimeout1.Text.Trim = "", "10", txbConnectionTimeout1.Text.Trim)
        End If
        My.Settings.Save()
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If txbDatabaseName1.Text = "" Then
            Me.ErrPro.SetError(Me.txbDatabaseName1, "نام بانک اطلاعاتی را وارد کنید")
            res = False
        Else
            Me.ErrPro.SetError(Me.txbDatabaseName1, "")
        End If
        If txbServerName1.Text = "" Then
            Me.ErrPro.SetError(Me.txbServerName1, "نام سرور را وارد کنید")
            res = False
        Else
            Me.ErrPro.SetError(Me.txbServerName1, "")
        End If
        Return res
    End Function
#End Region
End Class