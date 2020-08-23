Imports System.IO
Public Class frmError
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvWarrning, True, True, True, True)
    Private clsDalError As New ClassDALError(modPublicMethod.ConnectionString)
    Private clsDALBasicTypes As New ClassDALBasicTypes(modPublicMethod.ConnectionString)

    Private dtWarrning As New DataTable

    Private _CurWarrningID As String
    Private _CurWarrningDesc As String
    Private _CurWarrningStatus As String
#Region "Property"
    Public Property CurWarrningID() As String
        Get
            Return _CurWarrningID
        End Get
        Set(ByVal value As String)
            _CurWarrningID = value
        End Set
    End Property
    Public Property CurWarrningDesc() As String
        Get
            Return _CurWarrningDesc
        End Get
        Set(ByVal value As String)
            _CurWarrningDesc = value
        End Set
    End Property
    Public Property CurWarrningStatus() As String
        Get
            Return _CurWarrningStatus
        End Get
        Set(ByVal value As String)
            _CurWarrningStatus = value
        End Set
    End Property
#End Region
#Region "Events"
    Private Sub frmError_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        If RequiredValidator() = False Then
            Exit Sub
        End If
        Try
            Save()
        Catch ex As DuplicateNameException
            ErrorProvider.SetError(txtErrorID, ex.Message)
            ClassError.LogError(ex)
            modPublicMethod.SelectAText(txtErrorID)
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Cancel()
    End Sub

    Private Sub dgvWarrning_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWarrning.RowEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        RowEnter(e.RowIndex)
        combos(e.RowIndex)
    End Sub
    Private Sub frmError_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Me.clsMyControler.Key(sender, e)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub

    Private Sub frmError_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ' ClassBLLFormHistory.InsertToHistory(Me)
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

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvWarrning)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

#End Region
#Region "Methods"
    Private Sub InitialForms()
        Me.dgvWarrning.AutoGenerateColumns = False

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

        Dim ErrorID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ErrorID.Control = txtErrorID
        ErrorID.EnabledInAddState = True
        ErrorID.EnabledInEditState = True
        ErrorID.EnabledInViewState = False
        ErrorID.MappedColumn = "colErrorID"
        ErrorID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(ErrorID)

        Dim ErrorDescription_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ErrorDescription_nvc.Control = txtDesc_nvc
        ErrorDescription_nvc.EnabledInAddState = True
        ErrorDescription_nvc.EnabledInEditState = True
        ErrorDescription_nvc.EnabledInViewState = False
        ErrorDescription_nvc.MappedColumn = "colErrorDescription_nvc"
        ErrorDescription_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(ErrorDescription_nvc)

        Dim warrningstatus As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        warrningstatus.Control = ComboStatus_BIT
        warrningstatus.EnabledInAddState = True
        warrningstatus.EnabledInEditState = True
        warrningstatus.EnabledInViewState = False
        warrningstatus.MappedColumn = "colstatus_bit"
        warrningstatus.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(warrningstatus)


        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.clsMyControler.DataGridView = Me.dgvWarrning


    End Sub
    Private Sub FormLoad()
        Try
            Me.clsDalError.BeginProc()


            dtWarrning.Columns.Add("ErrorID")
            dtWarrning.Columns.Add("ErrorDescription_nvc")
            dtWarrning.Columns.Add("Status_BIT")

            '    dtWarrning = clsDalError.getall
            For Each row As DataRow In clsDalError.getall.Rows
                If row("Status_BIT") = 0 Then
                    dtWarrning.Rows.Add(row("ErrorID"), row("ErrorDescription_nvc"), "خطا")
                    ComboStatus_BIT.SelectedValue = 0
                Else
                    dtWarrning.Rows.Add(row("ErrorID"), row("ErrorDescription_nvc"), "اخطار")
                    ComboStatus_BIT.SelectedValue = 1
                End If
                ' dtWarrning.Rows.Add(row("ErrorID"), row("ErrorDescription_nvc"), row("Status_BIT"))
            Next
            dtWarrning.AcceptChanges()

            Me.dgvWarrning.DataSource = dtWarrning
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalError.EndProc()
        End Try
    End Sub
    Private Sub combos(ByVal Rowindex As Int32)
        If dgvWarrning.Rows(Rowindex).Cells("colstatus_bit").Value = "خطا" Then
            ComboStatus_BIT.SelectedIndex = 0
        Else
            ComboStatus_BIT.SelectedIndex = 1
        End If
    End Sub
    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvWarrning
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtErrorID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvWarrning
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtDesc_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Delete()
        clsDalError.ErrorID = txtErrorID.Text.Trim
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvWarrning
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalError.BeginProc()
                DoDelete()
                Me.dtWarrning.AcceptChanges()
            Catch ex As Exception
                Me.dtWarrning.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalError.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Sub Save()
        clsDalError.ErrorDescription_nvc = txtDesc_nvc.Text.Trim
        clsDalError.ErrorID = txtErrorID.Text.Trim
        clsDalError.Errorstatus_bit = ComboStatus_BIT.SelectedIndex
        Try
            Me.clsDalError.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    If clsDalError.GetByID().Rows.Count = 0 Then
                        DoInsert()
                    Else
                        Throw New DuplicateNameException(modApplicationMessage.msgDuplicateID)
                    End If
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    clsDalError.ErrorID = txtErrorID.Text.Trim
                    DoUpdate()
            End Select
            dtWarrning.AcceptChanges()
        Catch ex As Exception
            dtWarrning.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalError.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvWarrning
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvWarrning.Focus()
    End Sub

    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        clsMyControler.DataGridView = dgvWarrning
        clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvWarrning.Focus()
    End Sub
    Private Sub DoInsert()
        Try
            Me.clsDalError.Insert()
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            clsDalError.Update()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            clsDalError.Delete()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtWarrning.NewRow
            dr.Item("ErrorID") = clsDalError.ErrorID
            dr.Item("ErrorDescription_nvc") = clsDalError.ErrorDescription_nvc.Trim

            If clsDalError.Errorstatus_bit = 0 Then
                dr.Item("Status_BIT") = "خطا"
            Else
                dr.Item("Status_BIT") = "اخطار"
            End If
           
            Me.dtWarrning.Rows.Add(dr)
            dgvWarrning.CurrentCell = dgvWarrning.Rows(dtWarrning.Rows.Count - 1).Cells(0)
            RowEnter(dtWarrning.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtWarrning.Select("ErrorID = '" + clsDalError.ErrorID.ToString.Trim + "'")
            If dr.Length > 0 Then
                dr(0).Item("ErrorDescription_nvc") = clsDalError.ErrorDescription_nvc.Trim

                If clsDalError.Errorstatus_bit = 0 Then
                    dr(0).Item("Status_BIT") = "خطا"
                Else
                    dr(0).Item("Status_BIT") = "اخطار"
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtWarrning.Select("ErrorID = '" + clsDalError.ErrorID.ToString.Trim + "'")
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True

        If Me.txtDesc_nvc.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtDesc_nvc, "شرح راوارد کنید")
            res = False
            Exit Function
        ElseIf Me.txtErrorID.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtErrorID, "کد را وارد کنید")
            res = False
            Exit Function
        ElseIf Me.ComboStatus_BIT.SelectedIndex = -1 Then
            Me.ErrorProvider.SetError(Me.ComboStatus_BIT, "نوع انتخاب شود")
            res = False
            Exit Function
        Else
            ErrorProvider.Dispose()
        End If

        Return res
    End Function
    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.dgvWarrning.Rows(Rowindex).Selected = True
        Me.clsMyControler.DataGridView = Me.dgvWarrning
        Me.clsMyControler.SetControlsValue(Rowindex)
    End Sub
    Private Sub Choose()
        If dgvWarrning.SelectedRows.Count > 0 Then
            CurWarrningID = dgvWarrning.SelectedRows(0).Cells("colErrorID").Value
            CurWarrningDesc = dgvWarrning.SelectedRows(0).Cells("colErrorDescription_nvc").Value

            If dgvWarrning.SelectedRows(0).Cells("colstatus_bit").Value = "خطا" Then
                CurWarrningStatus = 0
            Else
                dgvWarrning.SelectedRows(0).Cells("colstatus_bit").Value = "اخطار"
                CurWarrningStatus = 1
            End If

        End If
    End Sub


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
            clsDalError.BeginProc()
            For i As Int32 = 0 To dtExcel.Rows.Count - 1
                If IsDBNull(dtExcel.Rows(i).Item(0)) = True OrElse dtExcel.Rows(i).Item(0).Trim.length <> 5 Then
                    colNotvalidRowsIndex.Add(i + 2)
                    Continue For
                End If
                clsDalError.ErrorID = dtExcel.Rows(i).Item(0).Trim
                clsDalError.ErrorDescription_nvc = dtExcel.Rows(i).Item(1).Trim
                clsDalError.Errorstatus_bit = dtExcel.Rows(i).Item(2).Trim
                If clsDalError.GetByID().Rows.Count = 0 Then
                    DoInsert()
                Else
                    '===nothing
                End If
                dtWarrning.AcceptChanges()
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
            dtWarrning.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            Me.clsDalError.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvWarrning
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvWarrning.Focus()
    End Sub
#End Region

End Class