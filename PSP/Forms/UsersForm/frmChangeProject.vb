Public Class frmChangeProject
    Private clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)
    Dim clsUserLoginDataAccess As New ClassUserLoginDataAccess(modPublicMethod.ConnectionString)

    Private Sub frmChangeProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.FillcboProjectID()
            cboProjectID.SelectedValue = ClassUserLoginDataAccess.ThisUser.ProjectID
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillcboProjectID()
        Try
            Me.clsDALProject.BeginProc()
            cboProjectID.DisplayMember = "Name_nvc"
            cboProjectID.ValueMember = "ProjectID_tint"
            Me.cboProjectID.DataSource = clsDALProject.GetAll(ClassUserLoginDataAccess.ThisUser.UserID)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALProject.EndProc()
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ClassUserLoginDataAccess.ThisUser.ProjectID = cboProjectID.SelectedValue
        modPublicMethod.AppName = "‰—„ «›“«— PSP" & "-" & cboProjectID.Text
        clsUserLoginDataAccess.Login(ClassUserLoginDataAccess.ThisUser.UserName_vc, Decode(ClassUserLoginDataAccess.ThisUser.Password_vc), cboProjectID.SelectedValue)
        Me.Close()

    End Sub

    Private Sub frmChangeProject_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub
End Class