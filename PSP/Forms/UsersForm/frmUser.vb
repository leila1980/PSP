Imports RIZNARM
Imports RIZNARM.WINDOWS.FORMS
''' <summary>
''' Developed by : Ehsan Soheili
''' Create Date : 860726
''' Last Modified : 861011
''' </summary>
''' <remarks></remarks>
Public Class frmUser

    Private clsFormController As New ClassFormController(Me.dguser)
    Private clsFormController2 As New ClassFormController(Me.dgPermission)

    Private clsUserDataAccess As New ClassUserDataAccess(ConnectionString)
    Private clsUserRightDataAccess As New ClassUserRightDataAccess(ConnectionString)
    Private clsFormDataAccess As New ClassFormDataAccess(ConnectionString)
    

    Private dtUser As New DataTable
    Private dtUserRight As New DataTable
    Private dtForm As New DataTable
    Private dtFormID As New DataTable
    
    Private iUserSelected As Integer
    Private iUserID As Integer
    Private Sub frmUser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            System.Windows.Forms.SendKeys.Send("{tab}")
        Else
            Me.clsFormController.Key(sender, e)
        End If
    End Sub
    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillCmbForm()
            Tab1Setting()
            Tab2Setting()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub GetData()
        Try
            With Me.clsUserDataAccess
                Me.dtUser = .GetAll
                Me.dtUser.DefaultView.Sort = "UserName_vc"
                Me.dgUser.DataSource = Me.dtUser
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clsUserDataAccess.BeginProc()
        With Me.clsFormController
            .DataGridView = Me.dgUser
            .GotoState(ClassFormController.FormState.Add)
            'txtCode.Text = clsUserDataAccess.GetNewId
            Me.txtUseName.Focus()
            Me.txtUseName.SelectAll()
        End With
        clsUserDataAccess.EndProc()
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        With Me.clsFormController
            .DataGridView = Me.dgUser
            .GotoState(ClassFormController.FormState.Edit)
            Me.txtPassword.Text = Decode(Me.txtPassword.Text)
            Me.txtConfirmPassword.Text = Decode(Me.txtConfirmPassword.Text)
            Me.txtUseName.Focus()
            Me.txtUseName.SelectAll()
        End With
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        With Me.clsFormController
            .DataGridView = Me.dgUser
            Me.ErrorProvider1.SetError(Me.txtUseName, "")
            .GotoState(ClassFormController.FormState.View)
            .SetControlsValue()
            Me.dgUser.Focus()
        End With
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If modPublicMethod.ShowConfirmDeleteMessage = False Then
                Exit Sub
            End If
            Me.clsUserDataAccess.BeginProc()
            Dim drFound() As DataRow
            drFound = Me.dtUser.Select("UserID = " + Me.dgUser.Item("colUserID", Me.dgUser.CurrentRow.Index).Value.ToString)
            Me.clsUserDataAccess.Delete(Me.dgUser.Item("colUserID", Me.dgUser.CurrentRow.Index).Value)
            If drFound.Length > 0 Then
                drFound(0).Delete()
            End If
            Me.dtUser.AcceptChanges()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            Me.dtUser.RejectChanges()
        Finally
            Me.clsUserDataAccess.EndProc()
            Me.clsFormController.DataGridView = Me.dgUser
            Me.clsFormController.GotoState(ClassFormController.FormState.View)
            Me.clsFormController.SetControlsValue()
            Me.dgUser.Focus()
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            ErrorProvider1.Clear()
            Select Case Me.clsFormController.CurrentState
                Case ClassFormController.FormState.Add
                    If ValidateText() Then
                        Me.clsUserDataAccess.BeginProc()
                        Dim myUser As ClassUserDataAccess.UserTemplate
                        With myUser
                            .UserID = clsUserDataAccess.GetNewId()
                            iUserID = .UserID
                            .UserName_vc = Me.txtUseName.Text
                            .Password_vc = EnCode(Me.txtPassword.Text)
                            .FullName_vc = Me.txtRealName.Text
                            .IsActive_bit = Me.chkActive.Checked
                        End With
                        Me.clsUserDataAccess.Insert(myUser)
                        Dim dr As DataRow = Me.dtUser.NewRow
                        dr.Item("UserID") = myUser.UserID
                        dr.Item("UserName_vc") = myUser.UserName_vc
                        dr.Item("Password_vc") = myUser.Password_vc
                        dr.Item("FullName_vc") = myUser.FullName_vc
                        dr.Item("IsActive_bit") = myUser.IsActive_bit
                        dtUser.Rows.Add(dr)
                        Me.clsFormController.DataGridView = Me.dgUser
                        Me.clsFormController.GotoState(ClassFormController.FormState.View)
                        Me.dgUser.Focus()
                        Me.dtUser.AcceptChanges()
                        Me.clsUserDataAccess.EndProc()
                        'dtFormID = Me.clsFormDataAccess.GetAllFormID()
                        'For i As Int16 = 0 To dtFormID.Rows.Count - 1
                        '    InsertPerNewUser(dtFormID.Rows(i).Item("FormID"))
                        'Next
                    End If
                Case ClassFormController.FormState.Edit
                    If ValidateText() = True Then
                        Me.clsUserDataAccess.BeginProc()
                        Dim myUser As ClassUserDataAccess.UserTemplate
                        With myUser
                            .UserID = Me.dgUser.Item("colUserID", Me.dgUser.CurrentRow.Index).Value
                            .UserName_vc = Me.txtUseName.Text
                            .Password_vc = EnCode(Me.txtPassword.Text)
                            .FullName_vc = Me.txtRealName.Text
                            .IsActive_bit = chkActive.Checked
                        End With
                        Dim drFound() As DataRow
                        drFound = Me.dtUser.Select("UserID = " + Me.dgUser.Item("colUserID", dgUser.CurrentRow.Index).Value.ToString)
                        Me.clsUserDataAccess.Update(myUser)
                        If drFound.Length > 0 Then
                            With myUser
                                drFound(0).Item("UserID") = .UserID
                                drFound(0).Item("UserName_vc") = .UserName_vc
                                drFound(0).Item("Password_vc") = .Password_vc
                                drFound(0).Item("FullName_vc") = .FullName_vc
                                drFound(0).Item("IsActive_bit") = .IsActive_bit
                            End With
                        End If
                        Me.clsFormController.DataGridView = Me.dgUser
                        Me.clsFormController.GotoState(ClassFormController.FormState.View)
                        Me.dgUser.Focus()
                        Me.dtUser.AcceptChanges()
                        Me.clsUserDataAccess.EndProc()
                    End If
            End Select
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            Me.dtUser.RejectChanges()
        End Try
    End Sub
    Private Function ValidateText() As Boolean
        ValidateText = True
        If txtUseName.Text.Length = 0 Then
            ErrorProvider1.SetError(txtUseName, "نام وارد نشده است")
            ValidateText = False
        End If
        If txtPassword.Text = "" Then
            ErrorProvider1.SetError(txtPassword, "کلمه عبور وارد نشده است")
            ValidateText = False
        End If
        If txtPassword.Text <> txtConfirmPassword.Text Then
            ErrorProvider1.SetError(txtPassword, "کلمه عبور و تکرار آن برابر نمی باشند")
            ValidateText = False
        End If
    End Function
    Private Sub TabPage1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter, TabPage2.Enter
        If sender Is TabPage1 Then
            tsCompanyTool.Visible = True
            tsCompanyTool2.Visible = False
            Me.clsFormController.GotoState(ClassFormController.FormState.View)
        ElseIf sender Is TabPage2 Then
            tsCompanyTool2.Visible = True
            tsCompanyTool.Visible = False
            FillgdPermission(iUserSelected)
            Me.clsFormController2.GotoState(ClassFormController.FormState.View)
        End If
    End Sub
    Private Sub Tab1Setting()
        Me.dgUser.AutoGenerateColumns = False

        Dim AddButton As ClassFormController.ButtonTemplate
        With AddButton
            .Button = Me.btnAdd
            .Role = ClassFormController.ButtonRole.Add
            .e = New EventHandler(AddressOf btnAdd_Click)
            .ShortCut = ClassSetting.Add_Shortcut
        End With

        Dim CancelButton As ClassFormController.ButtonTemplate
        With CancelButton
            .Button = Me.btnCancel
            .Role = ClassFormController.ButtonRole.Cancel
            .e = New EventHandler(AddressOf btnCancel_Click)
            .ShortCut = ClassSetting.Cancel_Shortcut
        End With

        Dim DeleteButton As ClassFormController.ButtonTemplate
        With DeleteButton
            .Button = Me.btnDelete
            .Role = ClassFormController.ButtonRole.Delete
            .e = New EventHandler(AddressOf btnDelete_Click)
            .ShortCut = ClassSetting.Delete_Shortcut
        End With

        Dim EditButton As ClassFormController.ButtonTemplate
        With EditButton
            .Button = Me.btnEdit
            .Role = ClassFormController.ButtonRole.Edit
            .e = New EventHandler(AddressOf btnEdit_Click)
            .ShortCut = ClassSetting.Edit_Shortcut
        End With

        Dim SaveButton As ClassFormController.ButtonTemplate
        With SaveButton
            .Button = Me.btnSave
            .Role = ClassFormController.ButtonRole.Save
            .e = New EventHandler(AddressOf btnSave_Click)
            .ShortCut = ClassSetting.OnlySave_Shortcut
        End With

        With clsFormController
            .AddButton(AddButton)
            .AddButton(CancelButton)
            .AddButton(DeleteButton)
            .AddButton(EditButton)
            .AddButton(SaveButton)
        End With

        Dim UserName_vc As New ClassFormController.ValueControlTemplate
        With UserName_vc
            .Control = Me.txtUseName
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = False
            .MappedColumn = "colUserName_vc"
            .ValueProperty = ClassFormController.ControlProperty.Text
        End With
        Me.clsFormController.AddControl(UserName_vc)

        Dim Password_vc As New ClassFormController.ValueControlTemplate
        With Password_vc
            .Control = Me.txtPassword
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = False
            .MappedColumn = "colPassword_vc"
            .ValueProperty = ClassFormController.ControlProperty.Text
        End With
        Me.clsFormController.AddControl(Password_vc)

        Dim ConPassword_vc As New ClassFormController.ValueControlTemplate
        With ConPassword_vc
            .Control = Me.txtConfirmPassword
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = False
            .MappedColumn = "colPassword_vc"
            .ValueProperty = ClassFormController.ControlProperty.Text
        End With
        Me.clsFormController.AddControl(ConPassword_vc)

        Dim FullName_vc As New ClassFormController.ValueControlTemplate
        With FullName_vc
            .Control = Me.txtRealName
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = False
            .MappedColumn = "colFullName_vc"
            .ValueProperty = ClassFormController.ControlProperty.Text
        End With
        Me.clsFormController.AddControl(FullName_vc)

        Dim IsActive_bit As New ClassFormController.ValueControlTemplate
        With IsActive_bit
            .Control = Me.chkActive
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = False
            .MappedColumn = "colIsActive_bit"
            .ValueProperty = ClassFormController.ControlProperty.Checked
        End With
        Me.clsFormController.AddControl(IsActive_bit)

        Me.GetData()
        Me.clsFormController.DataGridView = Me.dgUser
        SetPermission(clsFormController, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.clsFormController.GotoState(ClassFormController.FormState.View)
    End Sub
    Private Sub Tab2Setting()
        Me.dgPermission.AutoGenerateColumns = False

        Dim AddButton2 As ClassFormController.ButtonTemplate
        With AddButton2
            .Button = Me.btnAdd2
            .Role = ClassFormController.ButtonRole.Add
            .e = New EventHandler(AddressOf btnAdd2_Click_1)
            .ShortCut = ClassSetting.Add_Shortcut
        End With

        Dim CancelButton2 As ClassFormController.ButtonTemplate
        With CancelButton2
            .Button = Me.btnCancel2
            .Role = ClassFormController.ButtonRole.Cancel
            .e = New EventHandler(AddressOf btnCancel2_Click_1)
            .ShortCut = ClassSetting.Cancel_Shortcut
        End With

        'Dim DeleteButton2 As ClassFormController.ButtonTemplate
        'With DeleteButton2
        '    .Button = Me.btnDelete2
        '    .Role = ClassFormController.ButtonRole.Delete
        '    .e = New EventHandler(AddressOf btnDelete2_Click_1)
        '    .ShortCut = ClassSetting.Delete_Shortcut
        'End With

        Dim EditButton2 As ClassFormController.ButtonTemplate
        With EditButton2
            .Button = Me.btnEdit2
            .Role = ClassFormController.ButtonRole.Edit
            .e = New EventHandler(AddressOf btnEdit2_Click_1)
            .ShortCut = ClassSetting.Edit_Shortcut
        End With

        Dim SaveButton2 As ClassFormController.ButtonTemplate
        With SaveButton2
            .Button = Me.btnSave2
            .Role = ClassFormController.ButtonRole.Save
            .e = New EventHandler(AddressOf btnSave2_Click_1)
            .ShortCut = ClassSetting.OnlySave_Shortcut
        End With

        With clsFormController2
            .AddButton(AddButton2)
            .AddButton(CancelButton2)
            '.AddButton(DeleteButton2)
            .AddButton(EditButton2)
            .AddButton(SaveButton2)
        End With


        Dim FormName As New ClassFormController.ValueControlTemplate
        With FormName
            .Control = Me.cmbForm
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = True
            .MappedColumn = "colFormID"
            .ValueProperty = ClassFormController.ControlProperty.SelectedValue
        End With
        Me.clsFormController2.AddControl(FormName)


        Dim View_bit As New ClassFormController.ValueControlTemplate
        With View_bit
            .Control = Me.chkView
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = True
            .MappedColumn = "colView_bit"
            .ValueProperty = ClassFormController.ControlProperty.Checked
        End With
        Me.clsFormController2.AddControl(View_bit)

        Dim New_bit As New ClassFormController.ValueControlTemplate
        With New_bit
            .Control = Me.chkNew
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = True
            .MappedColumn = "colNew_bit"
            .ValueProperty = ClassFormController.ControlProperty.Checked
        End With
        Me.clsFormController2.AddControl(New_bit)

        Dim Edit_bit As New ClassFormController.ValueControlTemplate
        With Edit_bit
            .Control = Me.chkEdit
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = True
            .MappedColumn = "colEdit_bit"
            .ValueProperty = ClassFormController.ControlProperty.Checked
        End With
        Me.clsFormController2.AddControl(Edit_bit)

        Dim Delete_bit As New ClassFormController.ValueControlTemplate
        With Delete_bit
            .Control = Me.chkDelete
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = True
            .MappedColumn = "colDelete_bit"
            .ValueProperty = ClassFormController.ControlProperty.Checked
        End With
        Me.clsFormController2.AddControl(Delete_bit)

        Dim Print_bit As New ClassFormController.ValueControlTemplate
        With Print_bit
            .Control = Me.chkPrint
            .EnabledInAddState = True
            .EnabledInEditState = True
            .EnabledInViewState = True
            .MappedColumn = "colPrint_bit"
            .ValueProperty = ClassFormController.ControlProperty.Checked
        End With
        Me.clsFormController2.AddControl(Print_bit)

        Me.clsFormController2.DataGridView = Me.dgPermission
        SetPermission(clsFormController2, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.clsFormController2.GotoState(ClassFormController.FormState.View)

    End Sub
    Private Sub dgUser_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgUser.RowEnter, dgPermission.RowEnter
        If sender Is dgUser Then
            Me.clsFormController.DataGridView = Me.dgUser
            Me.clsFormController.SetControlsValue(e.RowIndex)
            ToolStripStatusLabel1.Text = "کاربر منتخب :" & Me.txtRealName.Text
        ElseIf sender Is dgPermission Then
            Me.clsFormController2.DataGridView = Me.dgPermission
            Me.clsFormController2.SetControlsValue(e.RowIndex)
        End If
    End Sub
    Private Sub FillgdPermission(ByVal UserId As Integer)
        Try
            dtUserRight.Clear()
            Me.dgPermission.DataSource = Me.dtUserRight
            iUserSelected = Me.dgUser.Item("colUserID", Me.dgUser.CurrentRow.Index).Value

            With Me.clsUserRightDataAccess
                Me.dtUserRight = .GetById(iUserSelected)
                Me.dtUserRight.DefaultView.Sort = "FormID"
                Me.dgPermission.DataSource = Me.dtUserRight
            End With
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub FillCmbForm()
        Try
            dtForm.Clear()
            Me.cmbForm.DataSource = Me.dtForm
            With Me.clsFormDataAccess
                Me.dtForm = .GetAll
                Me.dtForm.DefaultView.Sort = "FormID"
                Me.cmbForm.DataSource = Me.dtForm
                Me.cmbForm.DisplayMember = "Text_vc"
                Me.cmbForm.ValueMember = "FormID"
            End With
        Catch
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub cmbForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbForm.SelectedIndexChanged
        CmbFormCheckBox()
    End Sub
    Private Sub btnCancel2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel2.Click
        With Me.clsFormController2
            .DataGridView = Me.dgPermission
            .GotoState(ClassFormController.FormState.View)
            .SetControlsValue()
            Me.dgPermission.Focus()
        End With
    End Sub
    Private Sub btnEdit2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit2.Click
        With Me.clsFormController2
            .DataGridView = Me.dgPermission
            .GotoState(ClassFormController.FormState.Edit)
            CmbFormCheckBox()
        End With
    End Sub
    Private Sub btnDelete2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If modPublicMethod.ShowConfirmDeleteMessage = False Then
                Exit Sub
            End If
            Me.clsUserRightDataAccess.BeginProc()
            Dim drFound() As DataRow
            drFound = Me.dtUserRight.Select("FormID = " + Me.dgPermission.Item("colFormID", dgPermission.CurrentRow.Index).Value.ToString)
            Me.clsUserRightDataAccess.Delete(Me.dgPermission.Item("colUserID2", dgPermission.CurrentRow.Index).Value, Me.dgPermission.Item("colFormID", dgPermission.CurrentRow.Index).Value)
            If drFound.Length > 0 Then
                drFound(0).Delete()
            End If
            Me.dtUserRight.AcceptChanges()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            Me.dtUserRight.RejectChanges()
        Finally
            Me.clsUserRightDataAccess.EndProc()
            Me.clsFormController2.DataGridView = Me.dgPermission
            Me.clsFormController2.GotoState(ClassFormController.FormState.View)
            Me.clsFormController2.SetControlsValue()
            Me.dgPermission.Focus()
        End Try
    End Sub
    Private Sub btnAdd2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd2.Click

        With Me.clsFormController2
            .DataGridView = Me.dgPermission
            .GotoState(ClassFormController.FormState.Add)
            Me.cmbForm.Focus()
            Me.cmbForm.SelectedValue = 0
        End With
        If chkView.Checked = False Then chkView.Checked = True
        If chkNew.Checked = False Then chkNew.Checked = True
        If chkEdit.Checked = False Then chkEdit.Checked = True
        If chkDelete.Checked = False Then chkDelete.Checked = True
        If chkPrint.Checked = False Then chkPrint.Checked = True

    End Sub
    Private Sub btnSave2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave2.Click
        Try
            ErrorProvider1.Clear()
            Select Case Me.clsFormController2.CurrentState
                Case ClassFormController.FormState.Add
                    ' If ValidateText() = True Then
                    Me.clsUserRightDataAccess.BeginProc()
                    Dim myUser As ClassUserRightDataAccess.UserRightTemplate
                    With myUser
                        .UserID = iUserSelected
                        .FormID = cmbForm.SelectedValue
                        .View_bit = chkView.Checked
                        .New_bit = chkNew.Checked
                        .Edit_bit = chkEdit.Checked
                        .Delete_bit = chkDelete.Checked
                        .Print_bit = chkPrint.Checked
                        clsUserDataAccess.BeginProc()
                        .UserProjectID = clsUserDataAccess.GetUserProjectID(iUserSelected)
                        clsUserDataAccess.EndProc()
                    End With
                    Me.clsUserRightDataAccess.Insert(myUser)
                    Dim dr As DataRow = Me.dtUserRight.NewRow
                    dr.Item("UserID") = myUser.UserID
                    dr.Item("FormID") = myUser.FormID
                    dr.Item("View_bit") = myUser.View_bit
                    dr.Item("New_Bit") = myUser.New_bit
                    dr.Item("Edit_bit") = myUser.Edit_bit
                    dr.Item("Delete_bit") = myUser.Delete_bit
                    dr.Item("Print_bit") = myUser.Print_bit
                    dr.Item("UserProjectID") = myUser.UserProjectID
                    dtUserRight.Rows.Add(dr)
                    Me.clsFormController2.DataGridView = Me.dgPermission
                    FillgdPermission()
                    Me.clsFormController2.GotoState(ClassFormController.FormState.View)
                    Me.dgPermission.Focus()
                    Me.dtUserRight.AcceptChanges()
                    ' End If
                Case ClassFormController.FormState.Edit
                    Me.clsUserRightDataAccess.BeginProc()
                    Dim myUser As ClassUserRightDataAccess.UserRightTemplate
                    With myUser
                        .UserID = iUserSelected
                        .FormID = Me.dgPermission.Item("colFormID", Me.dgPermission.CurrentRow.Index).Value
                        .View_bit = chkView.Checked
                        .New_bit = chkNew.Checked
                        .Edit_bit = chkEdit.Checked
                        .Delete_bit = chkDelete.Checked
                        .Print_bit = chkPrint.Checked
                        clsUserDataAccess.BeginProc()
                        .UserProjectID = clsUserDataAccess.GetUserProjectID(iUserSelected)
                        clsUserDataAccess.EndProc()

                    End With
                    Dim drFound() As DataRow
                    drFound = Me.dtUserRight.Select("UserID = " + Me.dgPermission.Item("colUserID2", dgPermission.CurrentRow.Index).Value.ToString)
                    Me.clsUserRightDataAccess.Update(myUser)
                    FillgdPermission()
                    If drFound.Length > 0 Then
                        With myUser
                            drFound(0).Item("UserID") = myUser.UserID
                            drFound(0).Item("FormID") = myUser.FormID
                            drFound(0).Item("View_bit") = myUser.View_bit
                            drFound(0).Item("New_Bit") = myUser.New_bit
                            drFound(0).Item("Edit_bit") = myUser.Edit_bit
                            drFound(0).Item("Delete_bit") = myUser.Delete_bit
                            drFound(0).Item("Print_bit") = myUser.Print_bit
                            drFound(0).Item("UserProjectID") = myUser.UserProjectID
                        End With
                    End If
                    Me.clsFormController2.DataGridView = Me.dgPermission
                    Me.clsFormController2.GotoState(ClassFormController.FormState.View)
                    Me.dgPermission.Focus()
                    Me.dtUserRight.AcceptChanges()
            End Select
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            Me.dtUserRight.RejectChanges()
        Finally
            Me.clsUserRightDataAccess.EndProc()
        End Try
    End Sub
    Private Sub FillgdPermission()
        dtUserRight.Clear()
        Me.dgPermission.DataSource = Me.dtUserRight
        iUserSelected = Me.dgUser.Item("colUserID", Me.dgUser.CurrentRow.Index).Value
        FillgdPermission(iUserSelected)
    End Sub
    Private Sub CmbFormCheckBox()

        Dim iFound As Int32
        Try
            iFound = cmbForm.SelectedValue
        Catch
            Exit Sub
        End Try

        If iFound > 0 Then
            Dim drFound() As DataRow
            drFound = Me.dtForm.Select("FormID = " + Me.cmbForm.SelectedValue.ToString)
            If drFound(0).Item("HaveNew").ToString = True Then
                Me.chkNew.Enabled = True
                Me.chkNew.Checked = True
            Else
                Me.chkNew.Enabled = False
                Me.chkNew.Checked = False
            End If
            If drFound(0).Item("HaveEdit").ToString = True Then
                Me.chkEdit.Enabled = True
                Me.chkEdit.Checked = True
            Else
                Me.chkEdit.Enabled = False
                Me.chkEdit.Checked = False
            End If
            If drFound(0).Item("HaveDelete").ToString = True Then
                Me.chkDelete.Enabled = True
                Me.chkDelete.Checked = True
            Else
                Me.chkDelete.Enabled = False
                Me.chkDelete.Checked = False
            End If
            If drFound(0).Item("HavePrint").ToString = True Then
                Me.chkPrint.Enabled = True
                Me.chkPrint.Checked = True
            Else
                Me.chkPrint.Enabled = False
                Me.chkPrint.Checked = False
            End If
        End If

    End Sub
    Private Sub InsertPerNewUser(ByVal FormID As Integer)
        Try
            Me.clsUserRightDataAccess.BeginProc()
            Dim myUser As ClassUserRightDataAccess.UserRightTemplate
            With myUser
                .UserID = Me.iUserID
                .FormID = FormID
                .Delete_bit = True
                .Edit_bit = True
                .New_bit = True
                .Print_bit = True
                .View_bit = True
            End With
            Me.clsUserRightDataAccess.Insert(myUser)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsUserRightDataAccess.EndProc()
        End Try
    End Sub
    Private Sub frmUser_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
End Class