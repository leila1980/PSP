Public Class frmDefUser

    Private _ClassDALUser As New ClassDALUser()
    Private clsUserControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvUser, True, True, True, True)

    Dim dtUser As New DataTable
    Dim dtUserVisitor As DataTable
    Dim dtUserProject As DataTable
    Dim dtUserRight As DataTable
    Dim dtUserRightOnControls As DataTable

#Region "Methods"

    Private Sub InitialForms()
        Me.dgvUser.AutoGenerateColumns = False

        Dim addButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        addButton.Button = btnAdd
        addButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Add
        addButton.e = New eventhandler(AddressOf btnAdd_Click)
        addButton.ShortCut = ClassSetting.Add_Shortcut
        Me.clsUserControler.AddButton(addButton)

        Dim editButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        editButton.Button = btnEdit
        editButton.e = New EventHandler(AddressOf btnEdit_Click)
        editButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Edit
        editButton.ShortCut = ClassSetting.Edit_Shortcut
        Me.clsUserControler.AddButton(editButton)

        Dim deleteButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        deleteButton.Button = btnDelete
        deleteButton.e = New EventHandler(AddressOf btnDelete_Click)
        deleteButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Delete
        deleteButton.ShortCut = ClassSetting.Delete_Shortcut
        Me.clsUserControler.AddButton(deleteButton)

        Dim saveButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        saveButton.Button = btnSave
        saveButton.e = New EventHandler(AddressOf btnSave_Click)
        saveButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Save
        saveButton.ShortCut = ClassSetting.OnlySave_Shortcut
        Me.clsUserControler.AddButton(saveButton)

        Dim cancelButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        cancelButton.Button = btnCancel
        cancelButton.e = New EventHandler(AddressOf btnCancel_Click)
        cancelButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Cancel
        cancelButton.ShortCut = ClassSetting.Cancel_Shortcut
        Me.clsUserControler.AddButton(cancelButton)

        Dim UserID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        UserID.Control = lblUserID
        UserID.EnabledInAddState = True
        UserID.EnabledInEditState = False
        UserID.EnabledInViewState = False
        UserID.MappedColumn = "colUserID"
        UserID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsUserControler.AddControl(UserID)

        Dim FullName As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        FullName.Control = txtRealName
        FullName.EnabledInAddState = True
        FullName.EnabledInEditState = True
        FullName.EnabledInViewState = False
        FullName.MappedColumn = "FullName_vc"
        FullName.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsUserControler.AddControl(FullName)


        FullName.EnabledInAddState = True
        FullName.EnabledInEditState = True
        FullName.EnabledInViewState = True
        FullName.MappedColumn = "FullName_vc"
        FullName.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        FullName.Control = txtProjectRealName
        Me.clsUserControler.AddControl(FullName)
        FullName.Control = txtRightRealName
        Me.clsUserControler.AddControl(FullName)

        Dim UserName As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        UserName.Control = txtUserName
        UserName.EnabledInAddState = True
        UserName.EnabledInEditState = True
        UserName.EnabledInViewState = False
        UserName.MappedColumn = "UserName_vc"
        UserName.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsUserControler.AddControl(UserName)

        Dim SetMinAmount As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SetMinAmount.Control = txtMinAmount
        SetMinAmount.EnabledInAddState = True
        SetMinAmount.EnabledInEditState = True
        SetMinAmount.EnabledInViewState = False
        SetMinAmount.MappedColumn = "MinAmount"
        SetMinAmount.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsUserControler.AddControl(SetMinAmount)

        UserName.EnabledInAddState = True
        UserName.EnabledInEditState = True
        UserName.EnabledInViewState = True
        UserName.MappedColumn = "UserName_vc"
        UserName.Control = txtProjectUserName
        Me.clsUserControler.AddControl(UserName)
        UserName.Control = txtRightUserName
        Me.clsUserControler.AddControl(UserName)


        Dim Password As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Password.Control = txtPassword
        Password.EnabledInAddState = True
        Password.EnabledInEditState = True
        Password.EnabledInViewState = False
        Password.MappedColumn = "colPassword_vc"
        Password.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsUserControler.AddControl(Password)

        Dim ConfirmPassword As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ConfirmPassword.Control = txtConfirmPassword
        ConfirmPassword.EnabledInAddState = True
        ConfirmPassword.EnabledInEditState = True
        ConfirmPassword.EnabledInViewState = False
        ConfirmPassword.MappedColumn = "colPassword_vc"
        ConfirmPassword.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsUserControler.AddControl(ConfirmPassword)

        Dim Active As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Active.Control = chkActive
        Active.EnabledInAddState = True
        Active.EnabledInEditState = True
        Active.EnabledInViewState = False
        Active.MappedColumn = "colIsActive_bit"
        Active.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsUserControler.AddControl(Active)

        Dim Superuser As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Superuser.Control = chkIsSuperUser
        Superuser.EnabledInAddState = True
        Superuser.EnabledInEditState = True
        Superuser.EnabledInViewState = False
        Superuser.MappedColumn = "colIsSuperUser"
        Superuser.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsUserControler.AddControl(Superuser)


        Dim ActiveSearch As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ActiveSearch.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.None
        ActiveSearch.EnabledInAddState = False
        ActiveSearch.EnabledInEditState = False
        ActiveSearch.EnabledInViewState = True
        ActiveSearch.Control = srchUser
        Me.clsUserControler.AddControl(ActiveSearch)


        Dim AccessChangeAcc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AccessChangeAcc.Control = chkAccessChangeAcc
        AccessChangeAcc.EnabledInAddState = True
        AccessChangeAcc.EnabledInEditState = True
        AccessChangeAcc.EnabledInViewState = False
        AccessChangeAcc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsUserControler.AddControl(AccessChangeAcc)


        Dim Activebtn As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Activebtn.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.None
        Activebtn.EnabledInAddState = True
        Activebtn.EnabledInEditState = True
        Activebtn.EnabledInViewState = False
        Activebtn.Control = btnUnmarkAllRight
        Me.clsUserControler.AddControl(Activebtn)
        Activebtn.Control = btnReversalRight
        Me.clsUserControler.AddControl(Activebtn)
        Activebtn.Control = btnMarkAllRight
        Me.clsUserControler.AddControl(Activebtn)
        Activebtn.Control = cboColumn
        Me.clsUserControler.AddControl(Activebtn)

        Activebtn.Control = btnUnmarkAllVisitor
        Me.clsUserControler.AddControl(Activebtn)
        Activebtn.Control = btnReversalVisitor
        Me.clsUserControler.AddControl(Activebtn)
        Activebtn.Control = btnMarkAllVisitor
        Me.clsUserControler.AddControl(Activebtn)
        Activebtn.Control = btnUnmarkAllProject
        Me.clsUserControler.AddControl(Activebtn)
        Activebtn.Control = btnReversalProject
        Me.clsUserControler.AddControl(Activebtn)
        Activebtn.Control = btnMarkAllProject
        Me.clsUserControler.AddControl(Activebtn)

        SetPermission(clsUserControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

        Me.clsUserControler.DataGridView = Me.dgvUser
    End Sub

    Private Sub FormLoad()
        Try
            cboColumn.SelectedIndex = 0
            dtUser = _ClassDALUser.GetAllUser()
            Me.dgvUser.DataSource = dtUser
            Me.clsUserControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            srchUser.Init(dgvUser, dtUser, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Add()
        Try
            tabUserForm.SelectedTab = UserTab
            clsUserControler.DataGridView = dgvUser
            clsUserControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtRealName)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Edit()
        Try
            clsUserControler.DataGridView = dgvUser
            clsUserControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtRealName)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Delete()
        Select Case tabUserForm.SelectedIndex
            Case tabUserForm.TabPages.IndexOf(UserTab)
                If modPublicMethod.ShowConfirmDeleteMessage() = True Then
                    Try
                        clsUserControler.DataGridView = dgvUser
                        clsUserControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                        If lblUserID.Text <> String.Empty Then
                            _ClassDALUser.UserID = Convert.ToInt64(lblUserID.Text)
                            DoDelete()
                            Me.dtUser.AcceptChanges()
                        End If
                    Catch ex As Exception
                        Me.dtUser.RejectChanges()
                        Throw ex
                        Exit Sub
                    Finally
                        clsUserControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                        clsUserControler.SetControlsValue()
                    End Try
                End If
        End Select
    End Sub

    Private Sub Save()
        Try
            Dim intCounter As Int32 = 0
            Me.dgvUserVisitor.EndEdit()
            Me.dgvUserProject.EndEdit()
            Me.dgvUserRight.EndEdit()

            Me.dtUserVisitor.AcceptChanges()
            Me.dtUserProject.AcceptChanges()
            Me.dtUserRight.AcceptChanges()

            Me._ClassDALUser.dtUserVisitor = Me.dtUserVisitor
            Me._ClassDALUser.dtUserProject = Me.dtUserProject
            Me._ClassDALUser.dtUserRight = Me.dtUserRight


            Select Case Me.clsUserControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    _ClassDALUser.UserName = txtUserName.Text
                    If _ClassDALUser.GetAllUser().Rows.Count = 0 Then
                        _ClassDALUser.UserName = txtUserName.Text
                        _ClassDALUser.FullName = txtRealName.Text
                        _ClassDALUser.Password = EnCode(txtPassword.Text)
                        _ClassDALUser.IsActive = chkActive.Checked
                        _ClassDALUser.IsSuperUser = chkIsSuperUser.Checked
                        If txtMinAmount.Text = String.Empty Then
                            _ClassDALUser.MinAmount = 0
                        Else
                            _ClassDALUser.MinAmount = Convert.ToString(txtMinAmount.Text)
                        End If
                        DoInsert()
                    Else
                        Throw New DuplicateNameException(modApplicationMessage.msgDuplicateID)
                    End If
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    If lblUserID.Text <> String.Empty Then
                        _ClassDALUser.UserID = Convert.ToInt64(lblUserID.Text)
                        _ClassDALUser.UserName = txtUserName.Text
                        _ClassDALUser.FullName = txtRealName.Text
                        _ClassDALUser.Password = EnCode(txtPassword.Text)
                        _ClassDALUser.IsActive = chkActive.Checked
                        _ClassDALUser.IsSuperUser = chkIsSuperUser.Checked
                        If txtMinAmount.Text = String.Empty Then
                            _ClassDALUser.MinAmount = 0
                        Else
                            _ClassDALUser.MinAmount = Convert.ToString(txtMinAmount.Text)
                        End If
                        DoUpdate()
                    End If
            End Select

            If Me.clsUserControler.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add Then
                DatatableInsert()
            End If
            dtUser.AcceptChanges()

            Me.clsUserControler.DataGridView = dgvUser
            Me.clsUserControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            dgvUserRight.Columns(FormID.Name).Visible = False
            dgvUser.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Me.clsUserControler.DataGridView = dgvUser
        Me.clsUserControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvUser.Focus()
    End Sub

    Private Sub DoInsert()
        Try
            _ClassDALUser.InsertUser()

            If Me.chkAccessChangeAcc.Checked = False Then
                _ClassDALUser.GetUserProjectByUserIDAndPrjID(_ClassDALUser.UserID)
                _ClassDALUser.InsertUserRightOnControls()
            End If
          
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DoUpdate()
        Try
            Me._ClassDALUser.UpdateUser()

            If Me.chkAccessChangeAcc.Checked = True Then
                Me._ClassDALUser.DeleteUserRightOnControls()
                DtRightonControlsDelete()
            ElseIf Me.dtUserRightOnControls.Rows.Count = 0 Then
                _ClassDALUser.GetUserProjectByUserIDAndPrjID(_ClassDALUser.UserID)
                _ClassDALUser.InsertUserRightOnControls()
            End If

            DatatableUpdate()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DoDelete()
        Try
            _ClassDALUser.DeleteUser()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtUser.NewRow
            dr.Item("UserID") = _ClassDALUser.UserID
            dr.Item("UserName_vc") = _ClassDALUser.UserName
            dr.Item("Password_vc") = _ClassDALUser.Password
            dr.Item("FullName_vc") = _ClassDALUser.FullName
            dr.Item("IsActive_bit") = _ClassDALUser.IsActive
            dr.Item("MinAmount") = _ClassDALUser.MinAmount
            dr.Item("ISSUPERUSER") = _ClassDALUser.IsSuperUser

            Me.dtUser.Rows.Add(dr)
            dgvUser.CurrentCell = dgvUser.Rows(dtUser.Rows.Count - 1).Cells(0)
            RowEnter(dtUser.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtUser.Select("UserID = " + Convert.ToString(_ClassDALUser.UserID).Trim)
            If dr.Length > 0 Then
                dr(0).Item("UserName_vc") = _ClassDALUser.UserName
                dr(0).Item("Password_vc") = _ClassDALUser.Password
                dr(0).Item("FullName_vc") = _ClassDALUser.FullName
                dr(0).Item("IsActive_bit") = _ClassDALUser.IsActive
                dr(0).Item("MinAmount") = _ClassDALUser.MinAmount
                dr(0).Item("ISSUPERUSER") = _ClassDALUser.IsSuperUser

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtUser.Select("UserID = " + lblUserID.Text)
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DtRightonControlsDelete()
        Try
            Dim drDeletedRow() As DataRow = dtUserRightOnControls.Select("UserID = " + lblUserID.Text)
            If drDeletedRow.Length > 0 Then
                For Each row As DataRow In drDeletedRow
                    row.Delete()
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True

        If Me.txtUserName.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtUserName, "نام کاربری را وارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtUserName, "")
        End If

        If Me.txtPassword.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtPassword, "کلمه عبور را وارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtPassword, "")
        End If

        If Me.txtConfirmPassword.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtConfirmPassword, "کلمه عبور را تکرار کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtConfirmPassword, "")
        End If

        If Me.txtConfirmPassword.Text.Trim <> txtPassword.Text Then
            Me.ErrorProvider.SetError(Me.txtConfirmPassword, "کلمه عبور با تکرار کلمه عبور برابر نیست")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtConfirmPassword, "")
        End If
        Return res
    End Function

    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.clsUserControler.DataGridView = Me.dgvUser
        Me.clsUserControler.SetControlsValue(Rowindex)
        Me.FillUserRightOnControlsChkbox()
    End Sub

    Private Sub ChooseCulture(ByVal sender As Object)
        Dim CultureInfo As System.Globalization.CultureInfo
        Select Case sender.name.tolower
            Case "txtUserName".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case Else
                CultureInfo = New System.Globalization.CultureInfo("en-US", False)
        End Select
        System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo)
    End Sub

    Private Sub FillVisitorGrid()
        Try
            dtUserVisitor = Me._ClassDALUser.GetVisitorForUser()
            Me.dgvUserVisitor.DataSource = dtUserVisitor
            srchVisitor.Init(dgvUserVisitor, dtUserVisitor, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillProjectGrid()
        Try
            dtUserProject = Me._ClassDALUser.GetProjectForUser()
            Me.dgvUserProject.DataSource = dtUserProject
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillRightGrid()
        Try
            dtUserRight = Me._ClassDALUser.GetUserRight()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطا")
        End Try
    End Sub

    Private Sub FillUserRightOnControlsChkbox()
        Try
            dtUserRightOnControls = Me._ClassDALUser.GetUserRightOnControls(Me._ClassDALUser.UserID)

            If dtUserRightOnControls.Rows.Count = 0 Then
                Me.chkAccessChangeAcc.Checked = True
            Else

                For Each row As DataRow In dtUserRightOnControls.Rows

                    If (row("CONTROLNAME_NVC") = "txtShabaAccount" And row("PROPERTY_VC") = "ReadOnly" And row("State_tint") = "2" And row("UserProjectId").ToString <> "") Then
                        If row("VALUE_VC") = "FALSE" Then
                            Me.chkAccessChangeAcc.Checked = True
                        Else
                            Me.chkAccessChangeAcc.Checked = False
                        End If
                    End If
                Next


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "خطا")
        End Try
    End Sub

    Private Sub FillProjectCombo()
        Try
            dgvUserProject.EndEdit()
            dtUserProject.AcceptChanges()
            Dim dRow() As DataRow = dtUserProject.Select("Selected = 1")
            Dim dt As New DataTable
            dt.Columns.Add("ProjectID_tint")
            dt.Columns.Add("ProjectName")
            dt.Columns.Add("Selected")
            For intC As Integer = 0 To dRow.Length - 1
                dt.ImportRow(dRow(intC))
            Next
            Me.cmbRightProject.DisplayMember = "ProjectName"
            Me.cmbRightProject.ValueMember = "ProjectID_tint"
            Me.cmbRightProject.DataSource = dt.DefaultView
            If tabUserForm.SelectedTab Is RightTab Then
                If Me.cmbRightProject.Items.Count = 0 Then
                    cmbRightProject.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Event"

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Add()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgAddFailed)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Me.txtPassword.Text = Decode(Me.txtPassword.Text)
            Me.txtConfirmPassword.Text = Decode(Me.txtConfirmPassword.Text)
            Edit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Delete()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgDeleteFailed)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        If RequiredValidator() = False Then
            Exit Sub
        End If
        Try
            Save()
        Catch ex As DuplicateNameException
            ErrorProvider.SetError(txtUserName, ex.Message)
            ClassError.LogError(ex)
            modPublicMethod.SelectAText(txtUserName)
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Cancel()
    End Sub

    Private Sub frmDefUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            InitialForms()
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub dgvUser_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUser.RowEnter
        RowEnter(e.RowIndex)
    End Sub

    Private Sub lblUserID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUserID.TextChanged
        Try
            If Not Me.lblUserID.Text = String.Empty Then
                _ClassDALUser.UserID = Convert.ToInt64(Me.lblUserID.Text)
            Else
                _ClassDALUser.UserID = 0
            End If
            FillVisitorGrid()
            FillRightGrid()
            FillProjectGrid()
            FillProjectCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub txtRealName_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRealName.EnabledChanged
        Try
            dgvUserVisitor.Columns(colSelected.Name).ReadOnly = Not txtRealName.Enabled
            dgvUserProject.Columns(colSelectedProject.Name).ReadOnly = Not txtRealName.Enabled

            dgvUserRight.Columns(colView.Name).ReadOnly = Not txtRealName.Enabled
            dgvUserRight.Columns(colNew.Name).ReadOnly = Not txtRealName.Enabled
            dgvUserRight.Columns(colEdit.Name).ReadOnly = Not txtRealName.Enabled
            dgvUserRight.Columns(colDelete.Name).ReadOnly = Not txtRealName.Enabled
            dgvUserRight.Columns(colPrint.Name).ReadOnly = Not txtRealName.Enabled
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub

    Private Sub UserFormTab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabUserForm.SelectedIndexChanged
        Try
            If tabUserForm.SelectedTab Is UserTab Then
                ToolStripSeparator2.Visible = True
                btnDelete.Visible = True
            Else
                ToolStripSeparator2.Visible = False
                btnDelete.Visible = False
            End If
            If tabUserForm.SelectedTab Is RightTab Then
                FillProjectCombo()
                If Me.cmbRightProject.Items.Count = 0 Then
                    MsgBox("هیچ فازی برای این کاربر قابل دسترسی نمی باشد", MsgBoxStyle.Exclamation, "هشدار")
                    Me.tabUserForm.SelectedTab = Me.ProjectTab
                End If

                If clsUserControler.CurrentState <> RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add Then
                    FillUserRightOnControlsChkbox()
                End If

            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub cmbRightProject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRightProject.SelectedIndexChanged
        Try
            If Not cmbRightProject.SelectedIndex = -1 Then
                If Not Me.lblUserID.Text = String.Empty Then
                    _ClassDALUser.UserID = Convert.ToInt64(Me.lblUserID.Text)
                Else
                    _ClassDALUser.UserID = 0
                End If
                dtUserRight.DefaultView.RowFilter = " ProjectID_tint = " + Convert.ToString(cmbRightProject.SelectedValue)
                Me.dgvUserRight.DataSource = dtUserRight.DefaultView
                srchRight.Init(dgvUserRight, dtUserRight, "")
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnMarkAllVisitor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnMarkAllVisitor.LinkClicked
        Try
            For intCounter As Int32 = 0 To dgvUserVisitor.Rows.Count - 1
                dgvUserVisitor.Rows(intCounter).Cells(colSelected.Name).Value = True
            Next
            dgvUserVisitor.EndEdit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnUnmarkAllVisitor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnUnmarkAllVisitor.LinkClicked
        Try
            For intCounter As Int32 = 0 To dgvUserVisitor.Rows.Count - 1
                dgvUserVisitor.Rows(intCounter).Cells(colSelected.Name).Value = False
            Next
            dgvUserVisitor.EndEdit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnReversalVisitor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnReversalVisitor.LinkClicked
        Try
            For intCounter As Int32 = 0 To dgvUserVisitor.Rows.Count - 1
                If dgvUserVisitor.Rows(intCounter).Cells(colSelected.Name).Value Is DBNull.Value Then dgvUserVisitor.Rows(intCounter).Cells(colSelected.Name).Value = False
                dgvUserVisitor.Rows(intCounter).Cells(colSelected.Name).Value = Not (dgvUserVisitor.Rows(intCounter).Cells(colSelected.Name).Value)
            Next
            dgvUserVisitor.EndEdit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnMarkAllProject_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnMarkAllProject.LinkClicked
        Try
            For intCounter As Int32 = 0 To dgvUserProject.Rows.Count - 1
                dgvUserProject.Rows(intCounter).Cells(colSelectedProject.Name).Value = True
            Next
            dgvUserProject.EndEdit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnUnmarkAllProject_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnUnmarkAllProject.LinkClicked
        Try
            For intCounter As Int32 = 0 To dgvUserProject.Rows.Count - 1
                dgvUserProject.Rows(intCounter).Cells(colSelectedProject.Name).Value = False
            Next
            dgvUserProject.EndEdit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnReversalProject_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnReversalProject.LinkClicked
        Try
            For intCounter As Int32 = 0 To dgvUserProject.Rows.Count - 1
                If dgvUserProject.Rows(intCounter).Cells(colSelectedProject.Name).Value Is DBNull.Value Then dgvUserProject.Rows(intCounter).Cells(colSelectedProject.Name).Value = False
                dgvUserProject.Rows(intCounter).Cells(colSelectedProject.Name).Value = Not (dgvUserProject.Rows(intCounter).Cells(colSelectedProject.Name).Value)
            Next
            dgvUserProject.EndEdit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnMarkAllRight_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnMarkAllRight.LinkClicked
        Try
            If cboColumn.SelectedIndex = -1 Then Exit Sub
            For intCounter As Int32 = 0 To dgvUserRight.Rows.Count - 1
                dgvUserRight.Rows(intCounter).Cells(cboColumn.SelectedIndex + 2).Value = True
            Next
            dgvUserRight.EndEdit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnUnmarkAllRight_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnUnmarkAllRight.LinkClicked
        Try
            If cboColumn.SelectedIndex = -1 Then Exit Sub
            For intCounter As Int32 = 0 To dgvUserRight.Rows.Count - 1
                dgvUserRight.Rows(intCounter).Cells(cboColumn.SelectedIndex + 2).Value = False
            Next
            dgvUserRight.EndEdit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnReversalRight_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnReversalRight.LinkClicked
        Try
            If cboColumn.SelectedIndex = -1 Then Exit Sub
            For intCounter As Int32 = 0 To dgvUserRight.Rows.Count - 1
                If dgvUserRight.Rows(intCounter).Cells(cboColumn.SelectedIndex + 2).Value Is DBNull.Value Then dgvUserRight.Rows(intCounter).Cells(cboColumn.SelectedIndex + 2).Value = False
                dgvUserRight.Rows(intCounter).Cells(cboColumn.SelectedIndex + 2).Value = Not (dgvUserRight.Rows(intCounter).Cells(cboColumn.SelectedIndex + 2).Value)
            Next
            dgvUserRight.EndEdit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
#End Region

   
End Class