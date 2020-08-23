Imports System.IO
Public Class frmCity
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvCity, True, True, True, True)
    Private clsDalCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private clsDalState As New ClassDALState(modPublicMethod.ConnectionString)
    ' Private clsDALTMS As New ClassDALTMS()

    Private dtCity As New DataTable
    Private dtState As New DataTable
#Region "Events"

    Private Sub frmCity_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmCity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            ErrorProvider.SetError(txtCityID, ex.Message)
            ClassError.LogError(ex)
            modPublicMethod.SelectAText(txtCityID)
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

    Private Sub dgvCity_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCity.RowEnter
        RowEnter(e.RowIndex)
    End Sub
    Private Sub frmCity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.clsMyControler.Key(sender, e)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub TextboxEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName_nvc.Enter
        ChooseCulture(sender)
    End Sub
    Private Sub frmCity_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvCity)
            End If
            'ExportToExcel()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

#End Region
#Region "Methods"
    Private Sub InitialForms()
        Me.dgvCity.AutoGenerateColumns = False

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

        Dim CityID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        CityID.Control = txtCityID
        CityID.EnabledInAddState = True
        CityID.EnabledInEditState = False
        CityID.EnabledInViewState = False
        CityID.MappedColumn = "colCityID"
        CityID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(CityID)

        Dim Name_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Name_nvc.Control = txtName_nvc
        Name_nvc.EnabledInAddState = True
        Name_nvc.EnabledInEditState = True
        Name_nvc.EnabledInViewState = False
        Name_nvc.MappedColumn = "colName_nvc"
        Name_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Name_nvc)

        Dim StateID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        StateID.Control = cmbStateID
        StateID.EnabledInAddState = True
        StateID.EnabledInEditState = True
        StateID.EnabledInViewState = False
        StateID.MappedColumn = "colStateID"
        StateID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(StateID)
        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.clsMyControler.DataGridView = Me.dgvCity
    End Sub
    Private Sub FormLoad()
        Try
            Me.clsDalCity.BeginProc()
            cmbStateID.DisplayMember = "Name_nvc"
            cmbStateID.ValueMember = "StateID"
            dtState = clsDalState.GetAll
            Me.cmbStateID.DataSource = dtState

            dtCity = clsDalCity.GetAll

            Me.dgvCity.DataSource = dtCity
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalCity.EndProc()
        End Try
    End Sub
    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvCity
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtCityID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvCity
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Delete()
        clsDalCity.CityID = txtCityID.Text.Trim
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvCity
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalCity.BeginProc()
                DoDelete()
                Me.dtCity.AcceptChanges()
            Catch ex As Exception
                Me.dtCity.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalCity.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Sub Save()
        clsDalCity.CityID = txtCityID.Text.Trim
        clsDalCity.Name_nvc = txtName_nvc.Text.Trim
        clsDalCity.StateID = cmbStateID.SelectedValue

        Try
            Me.clsDalCity.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    If clsDalCity.GetByID().Rows.Count = 0 Then
                        DoInsert()
                    Else
                        Throw New DuplicateNameException(modApplicationMessage.msgDuplicateID)
                    End If
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    DoUpdate()
            End Select
            'TMSWorking()

            dtCity.AcceptChanges()
        Catch ex As Exception
            dtCity.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalCity.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvCity
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvCity.Focus()
    End Sub

    'Private Sub TMSWorking()
    '    Try
    '        Dim dtTMSTerminal_GetByStateID As New DataTable
    '        Dim dtTMSTerminal_GetByCityID As New DataTable
    '        Dim dtTMSTerminal_MAXTerminalID As New DataTable
    '        Dim MaxTerminalID As Int64
    '        Dim CityID As String = clsDalCity.CityID
    '        Dim CityName As String = clsDalCity.Name_nvc
    '        Dim StateID As String = clsDalCity.StateID

    '        Dim pc As New System.Globalization.PersianCalendar


    '        dtTMSTerminal_GetByStateID = clsDalCity.ForTMS_TMSTerminal_GetByStateID(StateID)
    '        clsDALTMS.PARENT_ID = dtTMSTerminal_GetByStateID.Rows(0).Item("TERMINAL_ID")

    '        dtTMSTerminal_GetByCityID = clsDalCity.ForTMS_TMSTerminal_GetByCityID(CityID)
    '        If dtTMSTerminal_GetByCityID.Rows.Count > 0 Then
    '            clsDALTMS.TERMINAL_ID = dtTMSTerminal_GetByCityID.Rows(0).Item("TERMINAL_ID")
    '            clsDalCity.ForTMS_TMSTerminal_Update_ByTerminalID(clsDALTMS.TERMINAL_ID, clsDALTMS.REGISTRATION_DATE, clsDALTMS.PARENT_ID)
    '        Else
    '            dtTMSTerminal_MAXTerminalID = clsDalCity.ForTMS_TMSTerminal_MAXTerminalID()
    '            MaxTerminalID = dtTMSTerminal_MAXTerminalID.Rows(0).Item("MAXTERMINAL_ID")
    '            clsDALTMS.TERMINAL_ID = (MaxTerminalID + 1).ToString
    '            clsDALTMS.SIGNATURE = CityID
    '            clsDALTMS.NAME = CityName
    '            clsDALTMS.TYPE = vbCrLf
    '            clsDALTMS.STATUS = 0
    '            clsDALTMS.CATEGORY = 0
    '            clsDALTMS.DESCRIPTION = String.Empty
    '            clsDALTMS.REGISTRATION_DATE = Date.Now

    '            clsDalCity.ForTMS_TMSTerminal_Insert2(clsDALTMS.TERMINAL_ID, clsDALTMS.SIGNATURE, clsDALTMS.NAME, clsDALTMS.REGISTRATION_DATE, clsDALTMS.TYPE, clsDALTMS.STATUS, clsDALTMS.CATEGORY, clsDALTMS.DESCRIPTION, clsDALTMS.PARENT_ID)
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Me.clsMyControler.DataGridView = dgvCity
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvCity.Focus()
    End Sub
    Private Sub DoInsert()
        Try
            Me.clsDalCity.Insert()
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            Me.clsDalCity.Update()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            Me.clsDalCity.Delete()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtCity.NewRow
            dr.Item("CityID") = clsDalCity.CityID
            dr.Item("Name_nvc") = clsDalCity.Name_nvc
            dr.Item("StateID") = clsDalCity.StateID
            Me.dtCity.Rows.Add(dr)
            dgvCity.CurrentCell = dgvCity.Rows(dtCity.Rows.Count - 1).Cells(0)
            RowEnter(dtCity.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtCity.Select("CityID = '" + clsDalCity.CityID.Replace("'", "''") + "'")
            If dr.Length > 0 Then
                dr(0).Item("Name_nvc") = clsDalCity.Name_nvc
                dr(0).Item("StateID") = clsDalCity.StateID
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtCity.Select("CityID = '" + clsDalCity.CityID.Replace("'", "''") + "'")
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If Me.txtCityID.Text.Trim.Length = 0 Then
            Me.ErrorProvider.SetError(Me.txtCityID, "کد راوارد کنید")
            res = False
        Else
            If Me.txtCityID.Text.Trim.Length <> 5 Then
                Me.ErrorProvider.SetError(Me.txtCityID, "کد باید پنج رقمی باشد")
                res = False
            Else
                Me.ErrorProvider.SetError(Me.txtCityID, "")
            End If
        End If

        If Me.txtName_nvc.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtName_nvc, "نام راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtName_nvc, "")
        End If

        If Me.cmbStateID.SelectedIndex = -1 Then
            Me.ErrorProvider.SetError(Me.cmbStateID, "استان راانتخاب کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.cmbStateID, "")
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
            If dtExcel.Columns.Count <> 3 Then
                Throw New InvalidDataException
            End If
            clsDalCity.BeginProc()
            For i As Int32 = 0 To dtExcel.Rows.Count - 1
                If IsDBNull(dtExcel.Rows(i).Item(0)) = True OrElse dtExcel.Rows(i).Item(0).Trim.length <> 5 Then
                    colNotvalidRowsIndex.Add(i + 2)
                    Continue For
                End If
                clsDalCity.CityID = dtExcel.Rows(i).Item(0).Trim
                clsDalCity.Name_nvc = dtExcel.Rows(i).Item(1).Trim
                clsDalCity.StateID = dtExcel.Rows(i).Item(2).Trim
                If clsDalCity.GetByID().Rows.Count = 0 Then
                    DoInsert()
                Else
                    '===nothing
                End If
                dtCity.AcceptChanges()
            Next
            If colNotvalidRowsIndex.Count > 0 Then
                Dim strInvalidRowsIndex As String = ""
                For i As Int32 = 0 To colNotvalidRowsIndex.Count - 1
                    strInvalidRowsIndex += colNotvalidRowsIndex.Item(i) & ","
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
            dtCity.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalCity.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvCity
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvCity.Focus()
    End Sub
    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.clsMyControler.DataGridView = Me.dgvCity
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
        MsgBox(dgvCity.Rows.Count)
    End Sub

  End Class