Imports System.IO

Public Class frmCMSProject
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvCMSProject, True, True, True, True)
    Private clsDalCMSProject As New ClassDALCMSProject(modPublicMethod.ConnectionString)
    Private dtCMSProject As New DataTable

#Region "Events"


    Private Sub frmCMSProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            InitialForms()
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

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
            ErrorProvider.SetError(txtCMSProjectID, ex.Message)
            ClassError.LogError(ex)
            modPublicMethod.SelectAText(txtCMSProjectID)
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Cancel()
    End Sub

    Private Sub dgvCMSProject_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCMSProject.RowEnter
        RowEnter(e.RowIndex)
    End Sub

    Private Sub frmCMSProject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.clsMyControler.Key(sender, e)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub

#End Region

#Region "Methods"
    Private Sub InitialForms()
        Me.dgvCMSProject.AutoGenerateColumns = False

        Dim addButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        addButton.Button = btnAdd
        addButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Add
        addButton.e = New eventhandler(AddressOf btnAdd_Click)
        addButton.ShortCut = ClassSetting.Add_Shortcut
        Me.clsMyControler.AddButton(addButton)

        Dim editButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        editButton.Button = btnEdit
        editButton.e = New EventHandler(AddressOf btnEdit_Click)
        editButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Edit
        editButton.ShortCut = ClassSetting.Edit_Shortcut
        Me.clsMyControler.AddButton(editButton)

        Dim deleteButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        deleteButton.Button = btnDelete
        deleteButton.e = New EventHandler(AddressOf btnDelete_Click)
        deleteButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Delete
        deleteButton.ShortCut = ClassSetting.Delete_Shortcut
        Me.clsMyControler.AddButton(deleteButton)

        Dim saveButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        saveButton.Button = btnSave
        saveButton.e = New EventHandler(AddressOf btnSave_Click)
        saveButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Save
        saveButton.ShortCut = ClassSetting.OnlySave_Shortcut
        Me.clsMyControler.AddButton(saveButton)

        Dim cancelButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        cancelButton.Button = btnCancel
        cancelButton.e = New EventHandler(AddressOf btnCancel_Click)
        cancelButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Cancel
        cancelButton.ShortCut = ClassSetting.Cancel_Shortcut
        Me.clsMyControler.AddButton(cancelButton)

        Dim CMSProjectID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        CMSProjectID.Control = txtCMSProjectID
        CMSProjectID.EnabledInAddState = True
        CMSProjectID.EnabledInEditState = False
        CMSProjectID.EnabledInViewState = False
        CMSProjectID.MappedColumn = "colCMSProjectID"
        CMSProjectID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(CMSProjectID)

        Dim Name_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Name_nvc.Control = txtName_nvc
        Name_nvc.EnabledInAddState = True
        Name_nvc.EnabledInEditState = True
        Name_nvc.EnabledInViewState = False
        Name_nvc.MappedColumn = "colName_nvc"
        Name_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Name_nvc)

        Dim Essws_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Essws_nvc.Control = txtEssws
        Essws_nvc.EnabledInAddState = True
        Essws_nvc.EnabledInEditState = True
        Essws_nvc.EnabledInViewState = False
        Essws_nvc.MappedColumn = "colESSWS_NVC"
        Essws_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Essws_nvc)

        Dim IsSent2Switch As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        IsSent2Switch.Control = chkIsSent2Switch
        IsSent2Switch.EnabledInAddState = True
        IsSent2Switch.EnabledInEditState = True
        IsSent2Switch.EnabledInViewState = False
        IsSent2Switch.MappedColumn = "colIsSent2Switch"
        IsSent2Switch.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(IsSent2Switch)

        Dim IsEniacMerchant As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        IsEniacMerchant.Control = chkIsEniacMerchant
        IsEniacMerchant.EnabledInAddState = True
        IsEniacMerchant.EnabledInEditState = True
        IsEniacMerchant.EnabledInViewState = False
        IsEniacMerchant.MappedColumn = "colIsEniacMerchant"
        IsEniacMerchant.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(IsEniacMerchant)

        Dim IsEniacOutlet As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        IsEniacOutlet.Control = chkIsEniacOutlet
        IsEniacOutlet.EnabledInAddState = True
        IsEniacOutlet.EnabledInEditState = True
        IsEniacOutlet.EnabledInViewState = False
        IsEniacOutlet.MappedColumn = "colIsEniacOutlet"
        IsEniacOutlet.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(IsEniacOutlet)

        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

        Me.clsMyControler.DataGridView = Me.dgvCMSProject
    End Sub

    Private Sub FormLoad()
        Try
            Me.clsDalCMSProject.BeginProc()
            dtCMSProject = clsDalCMSProject.GetAll
            Me.dgvCMSProject.DataSource = dtCMSProject
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalCMSProject.EndProc()
        End Try
    End Sub

    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvCMSProject
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtCMSProjectID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvCMSProject
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Delete()
        clsDalCMSProject.CMSProjectID = txtCMSProjectID.Text.Trim
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvCMSProject
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalCMSProject.BeginProc()
                DoDelete()
                Me.dtCMSProject.AcceptChanges()
            Catch ex As Exception
                Me.dtCMSProject.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalCMSProject.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub

    Private Sub Save()
        clsDalCMSProject.CMSProjectID = txtCMSProjectID.Text.Trim
        clsDalCMSProject.Name_nvc = txtName_nvc.Text.Trim
        clsDalCMSProject.ESSWS_NVC = txtEssws.Text.Trim

        If chkIsSent2Switch.Checked = True Then
            clsDalCMSProject.IsSent2Switch = 1
        Else
            clsDalCMSProject.IsSent2Switch = 0
        End If

        If chkIsEniacMerchant.Checked = True Then
            clsDalCMSProject.ISEniacMerchant = 1
        Else
            clsDalCMSProject.ISEniacMerchant = 0
        End If

        If chkIsEniacOutlet.Checked = True Then
            clsDalCMSProject.IsEniacOutlet = 1
        Else
            clsDalCMSProject.IsEniacOutlet = 0
        End If

        Try
            Me.clsDalCMSProject.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    If clsDalCMSProject.GetByID().Rows.Count = 0 Then
                        DoInsert()
                    Else
                        Throw New DuplicateNameException(modApplicationMessage.msgDuplicateID)
                    End If
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    DoUpdate()
            End Select
            dtCMSProject.AcceptChanges()
        Catch ex As Exception
            dtCMSProject.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalCMSProject.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvCMSProject
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvCMSProject.Focus()
    End Sub

    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Me.clsMyControler.DataGridView = dgvCMSProject
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvCMSProject.Focus()
    End Sub

    Private Sub DoInsert()
        Try
            Me.clsDalCMSProject.Insert()
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DoUpdate()
        Try
            Me.clsDalCMSProject.Update()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DoDelete()
        Try
            Me.clsDalCMSProject.Delete()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtCMSProject.NewRow
            dr.Item("CMSProjectID_int") = clsDalCMSProject.CMSProjectID
            dr.Item("Name_nvc") = clsDalCMSProject.Name_nvc
            dr.Item("essws_nvc") = clsDalCMSProject.ESSWS_NVC
            dr.Item("issent2switch") = clsDalCMSProject.IsSent2Switch
            dr.Item("iseniacmerchant") = clsDalCMSProject.ISEniacMerchant
            dr.Item("iseniacoutlet") = clsDalCMSProject.IsEniacOutlet
            Me.dtCMSProject.Rows.Add(dr)
            dgvCMSProject.CurrentCell = dgvCMSProject.Rows(dtCMSProject.Rows.Count - 1).Cells(0)
            RowEnter(dtCMSProject.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtCMSProject.Select("CMSProjectID_int = '" + clsDalCMSProject.CMSProjectID.ToString.Replace("'", "''") + "'")
            If dr.Length > 0 Then
                dr(0).Item("Name_nvc") = clsDalCMSProject.Name_nvc
                dr(0).Item("essws_nvc") = clsDalCMSProject.ESSWS_NVC
                dr(0).Item("issent2switch") = clsDalCMSProject.IsSent2Switch
                dr(0).Item("iseniacmerchant") = clsDalCMSProject.ISEniacMerchant
                dr(0).Item("iseniacoutlet") = clsDalCMSProject.IsEniacOutlet
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtCMSProject.Select("CMSProjectID_int = '" + clsDalCMSProject.CMSProjectID.ToString.Replace("'", "''") + "'")
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If Me.txtCMSProjectID.Text.Trim.Length = 0 Then
            Me.ErrorProvider.SetError(Me.txtCMSProjectID, "کد راوارد کنید")
            res = False
        End If

        If Me.txtName_nvc.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtName_nvc, "نام راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtName_nvc, "")
        End If
        Return res
    End Function

    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.clsMyControler.DataGridView = Me.dgvCMSProject
        Me.clsMyControler.SetControlsValue(Rowindex)
    End Sub


#End Region

End Class