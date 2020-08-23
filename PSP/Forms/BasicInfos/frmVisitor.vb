Public Class frmVisitor
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvVisitor, True, True, True, True)
    Private clsDalVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private dtVisitor As New DataTable
    Private _CurVisitorID As Int32
    Private _CurVisitorFName As String
    Private _CurVisitorLName As String
    Private _CurVisitorStatus As Integer
#Region "Property"
    Public Property CurVisitorID() As Int32
        Get
            Return _CurVisitorID
        End Get
        Set(ByVal value As Int32)
            _CurVisitorID = value
        End Set
    End Property
    Public Property CurVisitorFName() As String
        Get
            Return _CurVisitorFName
        End Get
        Set(ByVal value As String)
            _CurVisitorFName = value
        End Set
    End Property
    Public Property CurVisitorLName() As String
        Get
            Return _CurVisitorLName
        End Get
        Set(ByVal value As String)
            _CurVisitorLName = value
        End Set
    End Property
    Public Property CurVisitorStatus() As Integer
        Get
            Return _CurVisitorStatus
        End Get
        Set(ByVal value As Integer)
            _CurVisitorStatus = value
        End Set
    End Property
#End Region
#Region "Events"

    Private Sub frmVisitor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmVisitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
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

    Private Sub dgvVisitor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvVisitor.DoubleClick
        Choose()
        Me.Close()
    End Sub
    Private Sub dgvVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVisitor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Choose()
            Me.Close()
        End If
    End Sub
    Private Sub dgvVisitor_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVisitor.RowEnter
        RowEnter(e.RowIndex)
    End Sub

    Private Sub frmVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.clsMyControler.Key(sender, e)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub TextboxEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstName_nvc.Enter, txtLastName_nvc.Enter
        ChooseCulture(sender)
    End Sub
#End Region
#Region "Methods"
    Private Sub InitialForms()
        Me.dgvVisitor.AutoGenerateColumns = False

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

        Dim VisitorID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        VisitorID.Control = txtVisitorID
        VisitorID.EnabledInAddState = False
        VisitorID.EnabledInEditState = False
        VisitorID.EnabledInViewState = False
        VisitorID.MappedColumn = "colVisitorID"
        VisitorID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(VisitorID)

        Dim FirstName_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        FirstName_nvc.Control = txtFirstName_nvc
        FirstName_nvc.EnabledInAddState = True
        FirstName_nvc.EnabledInEditState = True
        FirstName_nvc.EnabledInViewState = False
        FirstName_nvc.MappedColumn = "colFirstName_nvc"
        FirstName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(FirstName_nvc)

        Dim LastName_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        LastName_nvc.Control = txtLastName_nvc
        LastName_nvc.EnabledInAddState = True
        LastName_nvc.EnabledInEditState = True
        LastName_nvc.EnabledInViewState = False
        LastName_nvc.MappedColumn = "colLastName_nvc"
        LastName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(LastName_nvc)

        Dim ContractDate_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ContractDate_vc.Control = dtpContractDate_vc
        ContractDate_vc.EnabledInAddState = True
        ContractDate_vc.EnabledInEditState = True
        ContractDate_vc.EnabledInViewState = False
        ContractDate_vc.MappedColumn = "colContractDate_vc"
        ContractDate_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(ContractDate_vc)


        Dim ActiveStatus As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ActiveStatus.Control = ComboVisitorStatus
        ActiveStatus.EnabledInAddState = True
        ActiveStatus.EnabledInEditState = True
        ActiveStatus.EnabledInViewState = False
        ActiveStatus.MappedColumn = "colActiveStatus"
        ActiveStatus.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(ActiveStatus)

        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.clsMyControler.DataGridView = Me.dgvVisitor



    End Sub
    Private Sub FormLoad()
        Try
            FillComboVisitorStatus()
            Me.clsDalVisitor.BeginProc()
            dtVisitor = clsDalVisitor.GetAll
            Me.dgvVisitor.DataSource = dtVisitor
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalVisitor.EndProc()
        End Try
    End Sub
    Private clsDALBasicTypes As New ClassDALBasicTypes(modPublicMethod.ConnectionString)
    Private Sub FillComboVisitorStatus()
        Try
            Me.clsDALBasicTypes.BeginProc()
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.ActiveStatus
            Me.ComboVisitorStatus.DataSource = clsDALBasicTypes.GetAll

            Me.ComboVisitorStatus.DisplayMember = "Name_nvc"
            Me.ComboVisitorStatus.ValueMember = "MappingCode_vc"
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBasicTypes.EndProc()
        End Try
    End Sub
    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvVisitor
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtFirstName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvVisitor
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtFirstName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Delete()
        clsDalVisitor.VisitorID = Convert.ToInt32(txtVisitorID.Text.Trim)
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvVisitor
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalVisitor.BeginProc()
                DoDelete()
                Me.dtVisitor.AcceptChanges()
            Catch ex As Exception
                Me.dtVisitor.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalVisitor.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Sub Save()
        clsDalVisitor.FirstName_nvc = txtFirstName_nvc.Text.Trim
        clsDalVisitor.LastName_nvc = txtLastName_nvc.Text.Trim
        clsDalVisitor.ContractDate_vc = dtpContractDate_vc.Text.Trim
        clsDalVisitor.ActiveStatus = ComboVisitorStatus.SelectedValue
        Try
            Me.clsDalVisitor.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    DoInsert()
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    clsDalVisitor.VisitorID = Convert.ToInt32(txtVisitorID.Text.Trim)
                    DoUpdate()
            End Select
            dtVisitor.AcceptChanges()
        Catch ex As Exception
            dtVisitor.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalVisitor.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvVisitor
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvVisitor.Focus()
    End Sub
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        clsMyControler.DataGridView = dgvVisitor
        clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvVisitor.Focus()
    End Sub
    Private Sub DoInsert()
        Dim intInsertedID As Int32
        Try
            intInsertedID = Me.clsDalVisitor.Insert()
            clsDalVisitor.VisitorID = intInsertedID
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            clsDalVisitor.Update()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            clsDalVisitor.Delete()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtVisitor.NewRow
            dr.Item("VisitorID") = clsDalVisitor.VisitorID
            dr.Item("FirstName_nvc") = clsDalVisitor.FirstName_nvc.Trim
            dr.Item("LastName_nvc") = clsDalVisitor.LastName_nvc.Trim
            dr.Item("ContractDate_vc") = clsDalVisitor.ContractDate_vc.Trim
            dr.Item("ActiveStatus") = clsDalVisitor.ActiveStatus

            Me.dtVisitor.Rows.Add(dr)
            dgvVisitor.CurrentCell = dgvVisitor.Rows(dtVisitor.Rows.Count - 1).Cells(0)
            RowEnter(dtVisitor.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtVisitor.Select("VisitorID = " + clsDalVisitor.VisitorID.ToString.Trim)
            If dr.Length > 0 Then
                dr(0).Item("FirstName_nvc") = clsDalVisitor.FirstName_nvc.Trim
                dr(0).Item("LastName_nvc") = clsDalVisitor.LastName_nvc.Trim
                dr(0).Item("ContractDate_vc") = clsDalVisitor.ContractDate_vc.Trim
                dr(0).Item("ActiveStatus") = clsDalVisitor.ActiveStatus

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtVisitor.Select("VisitorID = " + clsDalVisitor.VisitorID.ToString.Trim)
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
            Me.ErrorProvider.SetError(Me.txtLastName_nvc, "نام خانوادگی راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtLastName_nvc, "")
        End If
        If Me.dtpContractDate_vc.Text.Trim = "" OrElse Me.dtpContractDate_vc.Text.Trim = "[هیج مقداری انتخاب نشده]" Then
            Me.ErrorProvider.SetError(Me.dtpContractDate_vc, "تاریخ راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.dtpContractDate_vc, "")
        End If

        Return res
    End Function
    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.dgvVisitor.Rows(Rowindex).Selected = True
        Me.clsMyControler.DataGridView = Me.dgvVisitor
        Me.clsMyControler.SetControlsValue(Rowindex)
    End Sub
    Private Sub Choose()
        If dgvVisitor.SelectedRows.Count > 0 Then
            CurVisitorID = dgvVisitor.SelectedRows(0).Cells("colVisitorID").Value
            CurVisitorStatus = dgvVisitor.SelectedRows(0).Cells("colActiveStatus").Value
            If IsDBNull(dgvVisitor.SelectedRows(0).Cells("colFirstName_nvc").Value) = False Then
                CurVisitorFName = dgvVisitor.SelectedRows(0).Cells("colFirstName_nvc").Value
            Else
                CurVisitorFName = String.Empty
            End If
            CurVisitorLName = dgvVisitor.SelectedRows(0).Cells("colLastName_nvc").Value
        End If
    End Sub
    Private Sub ChooseCulture(ByVal sender As Object)
        Dim CultureInfo As System.Globalization.CultureInfo
        Select Case sender.name.tolower
            Case "txtFirstName_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "txtLastName_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case Else
                CultureInfo = New System.Globalization.CultureInfo("en-US", False)
        End Select
        System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo)
    End Sub

#End Region

    Private Sub frmVisitor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class