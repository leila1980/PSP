Public Class frmInstaller
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvInstaller, True, True, True, True)
    Private clsDalInstaller As New ClassDALInstaller(modPublicMethod.ConnectionString)
    Private dtInstaller As New DataTable
#Region "Events"

    Private Sub frmInstaller_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmInstaller_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Cancel()
    End Sub
    Private Sub dgvInstaller_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInstaller.RowEnter
        RowEnter(e.RowIndex)
    End Sub
    Private Sub frmInstaller_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.clsMyControler.Key(sender, e)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub TextboxEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstName_nvc.Enter
        ChooseCulture(sender)
    End Sub
#End Region
#Region "Methods"
    Private Sub InitialForms()
        Me.dgvInstaller.AutoGenerateColumns = False

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

        Dim InstallerID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        InstallerID.Control = txtInstallerID
        InstallerID.EnabledInAddState = False
        InstallerID.EnabledInEditState = False
        InstallerID.EnabledInViewState = False
        InstallerID.MappedColumn = "colInstallerID"
        InstallerID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(InstallerID)

        Dim FirstName_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        FirstName_nvc.Control = txtFirstName_nvc
        FirstName_nvc.EnabledInAddState = True
        FirstName_nvc.EnabledInEditState = True
        FirstName_nvc.EnabledInViewState = False
        FirstName_nvc.MappedColumn = "colFirstName_nvc"
        FirstName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(FirstName_nvc)

        Dim LastName_nvc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        LastName_nvc.Control = txtLastName_nvc
        LastName_nvc.EnabledInAddState = True
        LastName_nvc.EnabledInEditState = True
        LastName_nvc.EnabledInViewState = False
        LastName_nvc.MappedColumn = "colLastName_nvc"
        LastName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(LastName_nvc)


        Dim Tel_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Tel_vc.Control = txtTel_vc
        Tel_vc.EnabledInAddState = True
        Tel_vc.EnabledInEditState = True
        Tel_vc.EnabledInViewState = False
        Tel_vc.MappedColumn = "colTel_vc"
        Tel_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Tel_vc)

        Dim Mobile_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Mobile_vc.Control = txtMobile_vc
        Mobile_vc.EnabledInAddState = True
        Mobile_vc.EnabledInEditState = True
        Mobile_vc.EnabledInViewState = False
        Mobile_vc.MappedColumn = "colMobile_vc"
        Mobile_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Mobile_vc)

        Dim Address_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Address_nvc.Control = txtAddress_nvc
        Address_nvc.EnabledInAddState = True
        Address_nvc.EnabledInEditState = True
        Address_nvc.EnabledInViewState = False
        Address_nvc.MappedColumn = "colAddress_nvc"
        Address_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Address_nvc)


        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.clsMyControler.DataGridView = Me.dgvInstaller
    End Sub
    Private Sub FormLoad()
        Try
            Me.clsDalInstaller.BeginProc()

            dtInstaller = clsDalInstaller.GetAll
            Me.dgvInstaller.DataSource = dtInstaller
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalInstaller.EndProc()
        End Try
    End Sub
    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvInstaller
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtFirstName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvInstaller
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtFirstName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Delete()
        clsDalInstaller.InstallerID = txtInstallerID.Text.Trim
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvInstaller
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalInstaller.BeginProc()
                DoDelete()
                Me.dtInstaller.AcceptChanges()
            Catch ex As Exception
                Me.dtInstaller.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalInstaller.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Sub Save()
        clsDalInstaller.FirstName_nvc = txtFirstName_nvc.Text.Trim
        clsDalInstaller.LastName_nvc = txtLastName_nvc.Text.Trim
        clsDalInstaller.Tel_vc = txtTel_vc.Text.Trim
        clsDalInstaller.Mobile_vc = txtMobile_vc.Text.Trim
        clsDalInstaller.Address_nvc = txtAddress_nvc.Text.Trim

        Try
            Me.clsDalInstaller.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    DoInsert()
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    clsDalInstaller.InstallerID = txtInstallerID.Text.Trim
                    DoUpdate()
            End Select

            dtInstaller.AcceptChanges()
        Catch ex As Exception
            dtInstaller.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalInstaller.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvInstaller
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvInstaller.Focus()
    End Sub
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Me.clsMyControler.DataGridView = dgvInstaller
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvInstaller.Focus()
    End Sub
    Private Sub DoInsert()
        Try
            Me.clsDalInstaller.Insert()
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            Me.clsDalInstaller.Update()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            Me.clsDalInstaller.Delete()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtInstaller.NewRow
            dr.Item("InstallerID") = clsDalInstaller.InstallerID
            dr.Item("FirstName_nvc") = clsDalInstaller.FirstName_nvc
            dr.Item("LastName_nvc") = clsDalInstaller.LastName_nvc
            dr.Item("Tel_vc") = clsDalInstaller.Tel_vc
            dr.Item("Mobile_vc") = clsDalInstaller.Mobile_vc
            dr.Item("Address_nvc") = clsDalInstaller.Address_nvc

            Me.dtInstaller.Rows.Add(dr)
            dgvInstaller.CurrentCell = dgvInstaller.Rows(dtInstaller.Rows.Count - 1).Cells(0)
            RowEnter(dtInstaller.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtInstaller.Select("InstallerID = " + clsDalInstaller.InstallerID.ToString)
            If dr.Length > 0 Then
                dr(0).Item("FirstName_nvc") = clsDalInstaller.FirstName_nvc
                dr(0).Item("LastName_nvc") = clsDalInstaller.LastName_nvc
                dr(0).Item("Tel_vc") = clsDalInstaller.Tel_vc
                dr(0).Item("Mobile_vc") = clsDalInstaller.Mobile_vc
                dr(0).Item("Address_nvc") = clsDalInstaller.Address_nvc
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtInstaller.Select("InstallerID = " + clsDalInstaller.InstallerID.ToString())
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True

        If Me.txtLastName_nvc.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtLastName_nvc, "نام خانوادگي راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtLastName_nvc, "")
        End If

        Return res
    End Function
    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.clsMyControler.DataGridView = Me.dgvInstaller
        Me.clsMyControler.SetControlsValue(Rowindex)
    End Sub
    Private Sub ChooseCulture(ByVal sender As Object)
        Dim CultureInfo As System.Globalization.CultureInfo
        Select Case sender.name.tolower
            Case "txtFirstName_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "txtLastName_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "txtAddress_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case Else
                CultureInfo = New System.Globalization.CultureInfo("en-US", False)
        End Select
        System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo)
    End Sub
    Private Sub frmInstaller_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
#End Region

End Class