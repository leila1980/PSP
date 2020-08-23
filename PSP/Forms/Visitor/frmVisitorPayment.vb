Public Class frmVisitorPayment

    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvVisitorPayment, True, True, True, True)
    Private clsDalVisitorPayment As New ClassDALVisitorPayment(modPublicMethod.ConnectionString)
    Private clsDalVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private dtVisitorPayment As New DataTable
    Private dtVisitor As DataTable
    '    Private _CurVisitorID As Int32
    '    Private _CurVisitorFName As String
    '    Private _CurVisitorLName As String
    '#Region "Property"
    '    Public Property CurVisitorID() As Int32
    '        Get
    '            Return _CurVisitorID
    '        End Get
    '        Set(ByVal value As Int32)
    '            _CurVisitorID = value
    '        End Set
    '    End Property
    '    Public Property CurVisitorFName() As String
    '        Get
    '            Return _CurVisitorFName
    '        End Get
    '        Set(ByVal value As String)
    '            _CurVisitorFName = value
    '        End Set
    '    End Property
    '    Public Property CurVisitorLName() As String
    '        Get
    '            Return _CurVisitorLName
    '        End Get
    '        Set(ByVal value As String)
    '            _CurVisitorLName = value
    '        End Set
    '    End Property
    '#End Region
#Region "Events"

    Private Sub frmVisitorPayment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmVisitorPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            'Choose()
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
            'Choose()
        Catch ex As Exception
            ClassError.LogError(ex)
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Cancel()
    End Sub

    Private Sub dgvVisitorPayment_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVisitorPayment.RowEnter
        RowEnter(e.RowIndex)
    End Sub
    Private Sub frmVisitor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.clsMyControler.Key(sender, e)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    'Private Sub TextboxEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstName_nvc.Enter, txtLastName_nvc.Enter
    '    ChooseCulture(sender)
    'End Sub
#End Region
#Region "Methods"
    Private Sub InitialForms()
        Me.dgvVisitorPayment.AutoGenerateColumns = False

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

        'Dim VisitorID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        'VisitorID.Control = cboVisitor
        'VisitorID.EnabledInAddState = True
        'VisitorID.EnabledInEditState = True
        'VisitorID.EnabledInViewState = False
        'VisitorID.MappedColumn = "colVisitorID"
        'VisitorID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        'Me.clsMyControler.AddControl(VisitorID)

        Dim PaymentDate_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        PaymentDate_vc.Control = dtpPaymentDate_vc
        PaymentDate_vc.EnabledInAddState = True
        PaymentDate_vc.EnabledInEditState = True
        PaymentDate_vc.EnabledInViewState = False
        PaymentDate_vc.MappedColumn = "colPaymentDate_vc"
        PaymentDate_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(PaymentDate_vc)

        Dim PaymentAmount_dc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        PaymentAmount_dc.Control = ntxtPaymentAmount_dc
        PaymentAmount_dc.EnabledInAddState = True
        PaymentAmount_dc.EnabledInEditState = True
        PaymentAmount_dc.EnabledInViewState = False
        PaymentAmount_dc.MappedColumn = "colPaymentAmount_dc"
        PaymentAmount_dc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(PaymentAmount_dc)

        Dim PosCount_int As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        PosCount_int.Control = ntxtPosCount_int
        PosCount_int.EnabledInAddState = True
        PosCount_int.EnabledInEditState = True
        PosCount_int.EnabledInViewState = False
        PosCount_int.MappedColumn = "colPosCount_int"
        PosCount_int.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(PosCount_int)

        Dim Desc_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Desc_nvc.Control = txtDesc_nvc
        Desc_nvc.EnabledInAddState = True
        Desc_nvc.EnabledInEditState = True
        Desc_nvc.EnabledInViewState = False
        Desc_nvc.MappedColumn = "colDesc_nvc"
        Desc_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Desc_nvc)

        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.clsMyControler.DataGridView = Me.dgvVisitorPayment
    End Sub
    Private Sub FormLoad()
        Try
            Me.clsDalVisitorPayment.BeginProc()
            dtVisitor = Me.clsDalVisitor.GetAll()
            cboVisitor.DataSource = dtVisitor
            cboVisitor.ValueMember = "VisitorID"
            cboVisitor.DisplayMember = "FullName_nvc"
            clsDalVisitorPayment.VisitorID = cboVisitor.SelectedValue
            dtVisitorPayment = clsDalVisitorPayment.GetByVisitorID
            Me.dgvVisitorPayment.DataSource = dtVisitorPayment
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            AddHandler cboVisitor.SelectedIndexChanged, AddressOf cboVisitor_SelectedIndexChanged
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalVisitorPayment.EndProc()
        End Try
    End Sub
    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvVisitorPayment
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            'modPublicMethod.SelectAText(txtFirstName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvVisitorPayment
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            'modPublicMethod.SelectAText(txtFirstName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Delete()
        clsDalVisitorPayment.ID = Convert.ToInt32(txtID.Text.Trim)
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvVisitorPayment
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalVisitorPayment.BeginProc()
                DoDelete()
                Me.dtVisitorPayment.AcceptChanges()
            Catch ex As Exception
                Me.dtVisitorPayment.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalVisitorPayment.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Sub Save()
        clsDalVisitorPayment.VisitorID = cboVisitor.SelectedValue
        clsDalVisitorPayment.PaymentDate_vc = dtpPaymentDate_vc.Text
        clsDalVisitorPayment.PaymentAmount_dc = ntxtPaymentAmount_dc.Text
        clsDalVisitorPayment.PosCount_int = ntxtPosCount_int.Text
        clsDalVisitorPayment.Desc_nvc = txtDesc_nvc.Text.Trim
        Try
            Me.clsDalVisitorPayment.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    DoInsert()
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    clsDalVisitorPayment.ID = Convert.ToInt32(txtID.Text.Trim)
                    DoUpdate()
            End Select
            dtVisitorPayment.AcceptChanges()
        Catch ex As Exception
            dtVisitorPayment.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalVisitorPayment.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvVisitorPayment
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvVisitorPayment.Focus()
    End Sub
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        clsMyControler.DataGridView = dgvVisitorPayment
        clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvVisitorPayment.Focus()
    End Sub
    Private Sub DoInsert()
        Dim intInsertedID As Int32
        Try
            intInsertedID = Me.clsDalVisitorPayment.Insert()
            clsDalVisitorPayment.ID = intInsertedID
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            clsDalVisitorPayment.Update()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            clsDalVisitorPayment.Delete()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtVisitorPayment.NewRow
            dr.Item("ID") = clsDalVisitorPayment.ID
            dr.Item("PaymentDate_vc") = clsDalVisitorPayment.PaymentDate_vc
            dr.Item("PaymentAmount_dc") = clsDalVisitorPayment.PaymentAmount_dc
            dr.Item("PosCount_int") = clsDalVisitorPayment.PosCount_int
            dr.Item("Desc_nvc") = clsDalVisitorPayment.Desc_nvc

            Me.dtVisitorPayment.Rows.Add(dr)
            dgvVisitorPayment.CurrentCell = dgvVisitorPayment.Rows(dtVisitorPayment.Rows.Count - 1).Cells(0)
            RowEnter(dtVisitorPayment.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtVisitorPayment.Select("ID = " + clsDalVisitorPayment.ID.ToString.Trim)
            If dr.Length > 0 Then
                dr(0).Item("PaymentDate_vc") = clsDalVisitorPayment.PaymentDate_vc
                dr(0).Item("PaymentAmount_dc") = clsDalVisitorPayment.PaymentAmount_dc
                dr(0).Item("PosCount_int") = clsDalVisitorPayment.PosCount_int
                dr(0).Item("Desc_nvc") = clsDalVisitorPayment.Desc_nvc
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtVisitorPayment.Select("ID = " + clsDalVisitorPayment.ID.ToString.Trim)
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If Me.cboVisitor.SelectedIndex = -1 Then
            Me.ErrorProvider.SetError(Me.cboVisitor, "نام بازاریاب راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.cboVisitor, "")
        End If
        If Me.dtpPaymentDate_vc.Text = "" OrElse Me.dtpPaymentDate_vc.Text = "[هیج مقداری انتخاب نشده]" Then
            Me.ErrorProvider.SetError(Me.dtpPaymentDate_vc, "تاریخ راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.dtpPaymentDate_vc, "")
        End If
        If Me.ntxtPaymentAmount_dc.Text = "" Then
            Me.ErrorProvider.SetError(Me.ntxtPaymentAmount_dc, "مبلغ راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.ntxtPaymentAmount_dc, "")
        End If
        'If Me.ntxtPosCount_int.Text = "" Then
        '    Me.ErrorProvider.SetError(Me.ntxtPosCount_int, "تعداد راوارد کنید")
        '    res = False
        'Else
        '    Me.ErrorProvider.SetError(Me.ntxtPosCount_int, "")
        'End If

        Return res
    End Function
    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.dgvVisitorPayment.Rows(Rowindex).Selected = True
        Me.clsMyControler.DataGridView = Me.dgvVisitorPayment
        Me.clsMyControler.SetControlsValue(Rowindex)
    End Sub
    'Private Sub Choose()
    '    If dgvVisitor.SelectedRows.Count > 0 Then
    '        CurVisitorID = dgvVisitor.SelectedRows(0).Cells("colVisitorID").Value
    '        CurVisitorFName = dgvVisitor.SelectedRows(0).Cells("colFirstName_nvc").Value
    '        CurVisitorLName = dgvVisitor.SelectedRows(0).Cells("colLastName_nvc").Value
    '    End If
    'End Sub
    'Private Sub ChooseCulture(ByVal sender As Object)
    '    Dim CultureInfo As System.Globalization.CultureInfo
    '    Select Case sender.name.tolower
    '        Case "txtFirstName_nvc".ToLower
    '            CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
    '        Case "txtLastName_nvc".ToLower
    '            CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
    '        Case Else
    '            CultureInfo = New System.Globalization.CultureInfo("en-US", False)
    '    End Select
    '    System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo)
    'End Sub

#End Region

    Private Sub frmVisitor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

    Private Sub cboVisitor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            clsDalVisitorPayment.VisitorID = cboVisitor.SelectedValue
            dtVisitorPayment = clsDalVisitorPayment.GetByVisitorID
            dgvVisitorPayment.DataSource = dtVisitorPayment
            If dtVisitorPayment.Rows.Count = 0 Then
                EmptyTextBoxes()
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub EmptyTextBoxes()
        dtpPaymentDate_vc.Text = ""
        txtDesc_nvc.Text = ""
        ntxtPaymentAmount_dc.Text = ""
        ntxtPosCount_int.Text = ""
    End Sub
End Class