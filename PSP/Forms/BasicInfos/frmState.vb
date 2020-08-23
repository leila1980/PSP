Imports System.IO
Public Class frmState
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvState, True, True, True, True)
    Private clsDalState As New ClassDALState(modPublicMethod.ConnectionString)
    'Private clsDALTMS As New ClassDALTMS(modPublicMethod.ConnectionString)

    Private dtState As New DataTable
#Region "Events"
    Private Sub frmState_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmState_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
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
            ErrorProvider.SetError(txtStateID, ex.Message)
            ClassError.LogError(ex)
            modPublicMethod.SelectAText(txtStateID)
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

    Private Sub dgvState_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvState.RowEnter
        RowEnter(e.RowIndex)
    End Sub
    Private Sub frmState_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        Me.dgvState.AutoGenerateColumns = False

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

        Dim StateID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        StateID.Control = txtStateID
        StateID.EnabledInAddState = True
        StateID.EnabledInEditState = False
        StateID.EnabledInViewState = False
        StateID.MappedColumn = "colStateID"
        StateID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(StateID)

        Dim Name_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Name_nvc.Control = txtName_nvc
        Name_nvc.EnabledInAddState = True
        Name_nvc.EnabledInEditState = True
        Name_nvc.EnabledInViewState = False
        Name_nvc.MappedColumn = "colName_nvc"
        Name_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Name_nvc)
        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)


        Me.clsMyControler.DataGridView = Me.dgvState
    End Sub
    Private Sub FormLoad()
        Try
            Me.clsDalState.BeginProc()
            dtState = clsDalState.GetAll
            Me.dgvState.DataSource = dtState
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalState.EndProc()
        End Try
    End Sub
    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvState
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtStateID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvState
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Delete()
        clsDalState.StateID = txtStateID.Text.Trim
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvState
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalState.BeginProc()
                DoDelete()
                Me.dtState.AcceptChanges()
            Catch ex As Exception
                Me.dtState.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalState.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Sub Save()
        clsDalState.StateID = txtStateID.Text.Trim
        clsDalState.Name_nvc = txtName_nvc.Text.Trim
        Try
            Me.clsDalState.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    If clsDalState.GetByID().Rows.Count = 0 Then
                        DoInsert()
                    Else
                        Throw New DuplicateNameException(modApplicationMessage.msgDuplicateID)
                    End If
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    DoUpdate()
            End Select
            'TMSWorking()

            dtState.AcceptChanges()
        Catch ex As Exception
            dtState.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalState.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvState
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvState.Focus()
    End Sub
    'Private Sub TMSWorking()
    '    Try
    '        Dim dtTMSTerminal_GetByStateID As New DataTable
    '        Dim dtTMSTerminal_MAXTerminalID As New DataTable
    '        Dim MaxTerminalID As Int64
    '        Dim StateID As String = clsDalState.StateID
    '        Dim StateName As String = clsDalState.Name_nvc

    '        Dim pc As New System.Globalization.PersianCalendar


    '        clsDALTMS.REGISTRATION_DATE = Date.Now

    '        dtTMSTerminal_GetByStateID = clsDalState.ForTMS_TMSTerminal_GetBystateid(StateID)
    '        If dtTMSTerminal_GetByStateID.Rows.Count > 0 Then
    '            clsDALTMS.TERMINAL_ID = dtTMSTerminal_GetByStateID.Rows(0).Item("TERMINAL_ID")
    '            clsDalState.ForTMS_TMSTerminal_Update_ByTerminalID(clsDALTMS.TERMINAL_ID, clsDALTMS.REGISTRATION_DATE)
    '        Else
    '            dtTMSTerminal_MAXTerminalID = clsDalState.ForTMS_TMSTerminal_MAXTerminalID()
    '            MaxTerminalID = dtTMSTerminal_MAXTerminalID.Rows(0).Item("MAXTERMINAL_ID")
    '            clsDALTMS.TERMINAL_ID = (MaxTerminalID + 1).ToString
    '            clsDALTMS.SIGNATURE = StateID
    '            clsDALTMS.NAME = StateName
    '            clsDALTMS.TYPE = vbCrLf
    '            clsDALTMS.STATUS = 0
    '            clsDALTMS.CATEGORY = 0
    '            clsDALTMS.DESCRIPTION = String.Empty

    '            clsDalState.ForTMS_TMSTerminal_Insert1(clsDALTMS.TERMINAL_ID, clsDALTMS.SIGNATURE, clsDALTMS.NAME, clsDALTMS.REGISTRATION_DATE, clsDALTMS.TYPE, clsDALTMS.STATUS, clsDALTMS.CATEGORY, clsDALTMS.DESCRIPTION)
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Me.clsMyControler.DataGridView = dgvState
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvState.Focus()
    End Sub
    Private Sub DoInsert()
        Try
            Me.clsDalState.Insert()
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            Me.clsDalState.Update()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            Me.clsDalState.Delete()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtState.NewRow
            dr.Item("StateID") = clsDalState.StateID
            dr.Item("Name_nvc") = clsDalState.Name_nvc
            Me.dtState.Rows.Add(dr)
            dgvState.CurrentCell = dgvState.Rows(dtState.Rows.Count - 1).Cells(0)
            RowEnter(dtState.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtState.Select("StateID = '" + clsDalState.StateID.Replace("'", "''") + "'")
            If dr.Length > 0 Then
                dr(0).Item("Name_nvc") = clsDalState.Name_nvc
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtState.Select("StateID = '" + clsDalState.StateID.Replace("'", "''") + "'")
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If Me.txtStateID.Text.Trim.Length = 0 Then
            Me.ErrorProvider.SetError(Me.txtStateID, "کد راوارد کنید")
            res = False
        Else
            If Me.txtStateID.Text.Trim.Length <> 3 Then
                Me.ErrorProvider.SetError(Me.txtStateID, "کد باید سه رقمی باشد")
                res = False
            Else
                Me.ErrorProvider.SetError(Me.txtStateID, "")
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
            clsDalState.BeginProc()
            For i As Int32 = 0 To dtExcel.Rows.Count - 1
                If IsDBNull(dtExcel.Rows(i).Item(0)) = True OrElse dtExcel.Rows(i).Item(0).Trim.length <> 3 Then
                    colNotvalidRowsIndex.Add(i + 2)
                    Continue For
                End If
                clsDalState.StateID = dtExcel.Rows(i).Item(0).Trim
                clsDalState.Name_nvc = dtExcel.Rows(i).Item(1).Trim
                If clsDalState.GetByID().Rows.Count = 0 Then
                    DoInsert()
                Else
                    '===nothing
                End If
                dtState.AcceptChanges()
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
            dtState.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalState.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvState
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvState.Focus()
    End Sub
    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.clsMyControler.DataGridView = Me.dgvState
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
        MsgBox(dgvState.Rows.Count)
    End Sub

    Private Sub frmState_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
End Class