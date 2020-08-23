Public Class frmBasicTypes
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvBasicTypes, True, True, True, True)
    Private clsDalBasicTypes As New ClassDALBasicTypes(modPublicMethod.ConnectionString)
    Private dtBasicTypes As New DataTable
    Private mvarBasicType As ClassDALBasicTypes.BasicTypeEnum
    Private _CurID As Int32
#Region "Property"
    Public Property BasicType() As ClassDALBasicTypes.BasicTypeEnum
        Get
            Return mvarBasicType
        End Get
        Set(ByVal value As ClassDALBasicTypes.BasicTypeEnum)
            mvarBasicType = value
        End Set
    End Property
    Public Property CurID() As Int32
        Get
            Return _CurID
        End Get
        Set(ByVal value As Int32)
            _CurID = value
        End Set
    End Property
#End Region
#Region "Events"

    Private Sub frmBasicTypes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmBasicTypes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            InitialForms()
            FormLoad()
        Catch ex As Exception
            ClassError.LogError(ex)
            ShowErrorMessage(ex.Message)
            Me.Close()
        End Try
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Add()
        Catch ex As Exception
            ClassError.LogError(ex)
            ShowErrorMessage(modApplicationMessage.msgAddFailed)
        End Try
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Edit()
        Catch ex As Exception
            ClassError.LogError(ex)
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Delete()
            Choose()
        Catch ex As Exception
            ClassError.LogError(ex)
            ShowErrorMessage(modApplicationMessage.msgDeleteFailed)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If RequiredValidator() = False Then
            Exit Sub
        End If
        Try
            Save()
            Choose()
        Catch ex As Exception
            ClassError.LogError(ex)
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Cancel()
    End Sub

    Private Sub dgvBasicTypes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBasicTypes.DoubleClick
        Choose()
        Me.Close()
    End Sub

    Private Sub dgvBasicTypes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBasicTypes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Choose()
            Me.Close()
        End If
    End Sub

    Private Sub dgvBasicTypes_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBasicTypes.RowEnter
        RowEnter(e.RowIndex)
    End Sub
    Private Sub frmBasicTypes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.clsMyControler.Key(sender, e)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub TextboxEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName_nvc.Enter
        ChooseCulture(sender)
    End Sub
#End Region
#Region "Methods"
    Private Sub InitialForms()
        Me.dgvBasicTypes.AutoGenerateColumns = False

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

        Dim ID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ID.Control = txtID
        ID.EnabledInAddState = False
        ID.EnabledInEditState = False
        ID.EnabledInViewState = False
        ID.MappedColumn = "colID"
        ID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(ID)

        Dim Name_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Name_nvc.Control = txtName_nvc
        Name_nvc.EnabledInAddState = True
        Name_nvc.EnabledInEditState = True
        Name_nvc.EnabledInViewState = False
        Name_nvc.MappedColumn = "colName_nvc"
        Name_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Name_nvc)
        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.BasicType, True)
        Me.clsMyControler.DataGridView = Me.dgvBasicTypes
    End Sub
    Private Sub FormLoad()
        Try
            Me.clsDalBasicTypes.BeginProc()
            clsDalBasicTypes.TypeID_sint = Me.BasicType
            Me.Text = clsDalBasicTypes.BasicTypeTable.Item(Me.BasicType)
            dtBasicTypes = clsDalBasicTypes.GetAll
            Me.dgvBasicTypes.DataSource = dtBasicTypes
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalBasicTypes.EndProc()
        End Try
    End Sub
    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvBasicTypes
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvBasicTypes
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Delete()
        clsDalBasicTypes.ID = Convert.ToInt32(txtID.Text.Trim)
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvBasicTypes
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalBasicTypes.BeginProc()
                DoDelete()
                Me.dtBasicTypes.AcceptChanges()
            Catch ex As Exception
                Me.dtBasicTypes.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalBasicTypes.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Sub Save()
        clsDalBasicTypes.Name_nvc = txtName_nvc.Text
        clsDalBasicTypes.TypeID_sint = Me.BasicType
        Try
            Me.clsDalBasicTypes.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    DoInsert()
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    clsDalBasicTypes.ID = Convert.ToInt32(txtID.Text.Trim)
                    DoUpdate()
            End Select
            dtBasicTypes.AcceptChanges()
        Catch ex As Exception
            dtBasicTypes.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalBasicTypes.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvBasicTypes
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvBasicTypes.Focus()
    End Sub
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        clsMyControler.DataGridView = dgvBasicTypes
        clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvBasicTypes.Focus()
    End Sub
    Private Sub DoInsert()
        Dim intInsertedID As Int32
        Try
            intInsertedID = Me.clsDalBasicTypes.Insert()
            clsDalBasicTypes.ID = intInsertedID
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            clsDalBasicTypes.Update()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            clsDalBasicTypes.Delete()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtBasicTypes.NewRow
            dr.Item("ID") = clsDalBasicTypes.ID
            dr.Item("Name_nvc") = clsDalBasicTypes.Name_nvc.Trim
            dr.Item("TypeID_sint") = clsDalBasicTypes.TypeID_sint
            Me.dtBasicTypes.Rows.Add(dr)
            dgvBasicTypes.CurrentCell = dgvBasicTypes.Rows(dtBasicTypes.Rows.Count - 1).Cells(0)
            RowEnter(dtBasicTypes.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtBasicTypes.Select("ID = " + clsDalBasicTypes.ID.ToString.Trim)
            If dr.Length > 0 Then
                dr(0).Item("Name_nvc") = clsDalBasicTypes.Name_nvc.Trim
                dr(0).Item("TypeID_sint") = clsDalBasicTypes.TypeID_sint
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtBasicTypes.Select("ID = " + clsDalBasicTypes.ID.ToString.Trim)
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If Me.txtName_nvc.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtName_nvc, "نام راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtName_nvc, "")
        End If
        Return res
    End Function
    Private Sub RowEnter(ByVal Rowindex As Int32)
        dgvBasicTypes.Rows(Rowindex).Selected = True
        Me.clsMyControler.DataGridView = Me.dgvBasicTypes
        Me.clsMyControler.SetControlsValue(Rowindex)
    End Sub
    Private Sub Choose()
        If dgvBasicTypes.SelectedRows.Count > 0 Then
            CurID = dgvBasicTypes.SelectedRows(0).Cells("colID").Value
        Else
            CurID = 0
        End If
    End Sub
    Private Sub ChooseCulture(ByVal sender As Object)
        Dim CultureInfo As System.Globalization.CultureInfo
        Select Case sender.name.tolower
            Case "txtName_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case Else
                CultureInfo = New System.Globalization.CultureInfo("en-US", False)
        End Select
        System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo)
    End Sub
#End Region

    Private Sub frmBasicTypes_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
End Class