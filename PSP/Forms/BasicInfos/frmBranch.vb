Imports System.IO
Public Class frmBranch
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvBranch, True, True, True, True)
    Private clsDalBranch As New ClassDALBranch(modPublicMethod.ConnectionString)
    Private dtBranch As New DataTable
    Private _CurID As String
    Public isOpeningFromContract As Boolean = False
#Region "Prpoperty"
    Public Property CurID() As String
        Get
            Return _CurID
        End Get
        Set(ByVal value As String)
            _CurID = value
        End Set
    End Property
#End Region
#Region "Events"

    Private Sub frmBranch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub

    Private Sub frmBranch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Choose()

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
            Choose()

        Catch ex As DuplicateNameException
            ErrorProvider.SetError(txtBranchID, ex.Message)
            ClassError.LogError(ex)
            modPublicMethod.SelectAText(txtBranchID)
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Cancel()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            Import()
        Catch ex As FileNotFoundException
            ShowErrorMessage(msgFileNotFound)
            ClassError.LogError(ex)
        Catch ex As MissingFieldException
            ShowErrorMessage(msgSheetNotEntered)
            ClassError.LogError(ex)
            modPublicMethod.SelectAToolStripText(txtExcelSheetName)
        Catch ex As InvalidDataException
            ShowErrorMessage(msgInvalidSheet)
            ClassError.LogError(ex)
            modPublicMethod.SelectAToolStripText(txtExcelSheetName)
        Catch ex As Exception
            ShowErrorMessage(msgImportFailed)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub dgvBranch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Choose()
            Me.Close()
        End If

    End Sub

    Private Sub dgvBranch_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBranch.RowEnter
        RowEnter(e.RowIndex)
    End Sub

    Private Sub frmBranch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        Me.dgvBranch.AutoGenerateColumns = False

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

        Dim BranchID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        BranchID.Control = txtBranchID
        BranchID.EnabledInAddState = True
        BranchID.EnabledInEditState = False
        BranchID.EnabledInViewState = False
        BranchID.MappedColumn = "colBranchID"
        BranchID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(BranchID)

        Dim Name_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Name_nvc.Control = txtName_nvc
        Name_nvc.EnabledInAddState = True
        Name_nvc.EnabledInEditState = True
        Name_nvc.EnabledInViewState = False
        Name_nvc.MappedColumn = "colName_nvc"
        Name_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Name_nvc)
        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.clsMyControler.DataGridView = Me.dgvBranch
    End Sub
    Private Sub FormLoad()
        Try
            Me.clsDalBranch.BeginProc()
            dtBranch = clsDalBranch.GetAll
            Me.dgvBranch.DataSource = dtBranch
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            cboSearchBy.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalBranch.EndProc()
        End Try
    End Sub
    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvBranch
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtBranchID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvBranch
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Delete()
        clsDalBranch.BranchID = txtBranchID.Text.Trim
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvBranch
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalBranch.BeginProc()
                DoDelete()
                Me.dtBranch.AcceptChanges()
            Catch ex As Exception
                Me.dtBranch.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalBranch.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Sub Save()
        clsDalBranch.BranchID = txtBranchID.Text.Trim
        clsDalBranch.Name_nvc = txtName_nvc.Text.Trim
        Try
            Me.clsDalBranch.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    If clsDalBranch.GetByID().Rows.Count = 0 Then
                        DoInsert()
                    Else
                        Throw New DuplicateNameException(modApplicationMessage.msgDuplicateID)
                    End If
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    DoUpdate()
            End Select
            dtBranch.AcceptChanges()
        Catch ex As Exception
            dtBranch.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalBranch.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvBranch
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvBranch.Focus()
    End Sub
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Me.clsMyControler.DataGridView = dgvBranch
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvBranch.Focus()
    End Sub
    Private Sub DoInsert()
        Try
            Me.clsDalBranch.Insert()
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            Me.clsDalBranch.Update()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            Me.clsDalBranch.Delete()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtBranch.NewRow
            dr.Item("BranchID") = clsDalBranch.BranchID
            dr.Item("Name_nvc") = clsDalBranch.Name_nvc
            Me.dtBranch.Rows.Add(dr)
            dgvBranch.CurrentCell = dgvBranch.Rows(dtBranch.Rows.Count - 1).Cells(0)
            RowEnter(dtBranch.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtBranch.Select("BranchID = '" + clsDalBranch.BranchID.Replace("'", "''") + "'")
            If dr.Length > 0 Then
                dr(0).Item("Name_nvc") = clsDalBranch.Name_nvc
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtBranch.Select("BranchID = '" + clsDalBranch.BranchID.Replace("'", "''") + "'")
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If Me.txtBranchID.Text.Trim.Length = 0 Then
            Me.ErrorProvider.SetError(Me.txtBranchID, "کد راوارد کنید")
            res = False
        Else
            If Me.txtBranchID.Text.Trim.Length <> 7 Then
                Me.ErrorProvider.SetError(Me.txtBranchID, "کد باید هفت رقمی باشد")
                res = False
            Else
                Me.ErrorProvider.SetError(Me.txtBranchID, "")
            End If
        End If

        If Me.txtName_nvc.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtName_nvc, "نام راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtName_nvc, "")
        End If
        Return res
    End Function
    Private Sub Import()
        Try
            OpenFileDialog.FileName = ""
            OpenFileDialog.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            OpenFileDialog.ShowDialog()
            Dim FilePath As String
            FilePath = OpenFileDialog.FileName
            If FilePath.Trim <> "" Then
                ReadFromExcelfile(FilePath)
            End If
        Catch ex As FileNotFoundException
            Throw ex
        Catch ex As MissingFieldException
            Throw ex
        Catch ex As InvalidDataException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ReadFromExcelfile(ByVal FilePath As String)
        Try
            Dim dtExcel As New DataTable

            Dim clsExcel As New ClassExcel(FilePath)
            dtExcel = clsExcel.Read(1, True)


            Dim colNotvalidRowsIndex As New Collection
            If dtExcel.Columns.Count <> 2 Then
                Throw New InvalidDataException
            End If
            clsDalBranch.BeginProc()
            For i As Int32 = 0 To dtExcel.Rows.Count - 1
                If IsDBNull(dtExcel.Rows(i).Item(0)) = True OrElse dtExcel.Rows(i).Item(0).Trim.length <> 6 Then
                    colNotvalidRowsIndex.Add(i + 2)
                    Continue For
                End If
                clsDalBranch.BranchID = dtExcel.Rows(i).Item(0).Trim
                clsDalBranch.Name_nvc = dtExcel.Rows(i).Item(1).Trim
                If clsDalBranch.GetByID().Rows.Count = 0 Then
                    DoInsert()
                Else
                    '===nothing
                End If
                dtBranch.AcceptChanges()
            Next
            If colNotvalidRowsIndex.Count > 0 Then
                Dim strInvalidRowsIndex As String = ""
                For i As Int32 = 1 To colNotvalidRowsIndex.Count
                    strInvalidRowsIndex += colNotvalidRowsIndex.Item(i).ToString.Trim + ","
                Next
                strInvalidRowsIndex = strInvalidRowsIndex.Remove(strInvalidRowsIndex.Trim.Length - 1, 1)
                If colNotvalidRowsIndex.Count = 1 Then
                    ShowErrorMessage("سطر " & strInvalidRowsIndex & "دارای اطلاعات نامعتبر می باشد")
                Else
                    ShowErrorMessage("سطرهای " & strInvalidRowsIndex & "دارای اطلاعات نامعتبر می باشند")
                End If
            End If
        Catch ex As FileNotFoundException
            Throw ex
            Exit Sub
        Catch ex As MissingFieldException
            Throw ex
            Exit Sub
        Catch ex As InvalidDataException
            Throw ex
            Exit Sub
        Catch ex As Exception
            dtBranch.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalBranch.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvBranch
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvBranch.Focus()
    End Sub
    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.clsMyControler.DataGridView = Me.dgvBranch
        Me.clsMyControler.SetControlsValue(Rowindex)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(dgvBranch.Rows.Count)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Search()
        'Catch ex As Exception
        '    ShowErrorMessage(modApplicationMessage.msgSearchFailed)
        '    ClassError.LogError(ex)
        'End Try
    End Sub

    Private Sub Search()
        Dim dvBranch As DataView = dtBranch.DefaultView

        If cboSearchBy.SelectedIndex <> -1 AndAlso txtSearch.Text.Trim <> "" Then
            If cboSearchBy.SelectedIndex = 0 Then 'Code
                dvBranch.RowFilter = "BranchID like '%" & txtSearch.Text.Trim & "%'"
            ElseIf cboSearchBy.SelectedIndex = 1 Then 'Name
                dvBranch.RowFilter = "Name_nvc like '%" & txtSearch.Text.Trim & "%'"
            End If
        Else
            dvBranch.RowFilter = ""
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Search()
    End Sub

    Private Sub Choose()
        If dgvBranch.SelectedRows.Count > 0 Then
            CurID = dgvBranch.SelectedRows(0).Cells("colBranchID").Value
        Else
            CurID = 0
        End If
    End Sub

    Private Sub dgvBranch_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvBranch.DoubleClick
      
        Choose()
        If isOpeningFromContract Then
            Me.Close()
        End If

    End Sub

    Private Sub txtSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.Click

    End Sub

    Private Sub frmBranch_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

   
End Class