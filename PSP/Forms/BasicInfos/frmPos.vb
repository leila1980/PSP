Imports System.IO

Public Class frmPos
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvPos, True, True, True, True)
    Private clsDalPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private dtPos As New DataTable
    Private dtPosType As New DataTable
    Private dtPosModel As New DataTable
    Private dtGood As New DataTable

    Private dvPos As DataView

    Private dtSearchField As New DataTable
    Private dtSearchOperation As New DataTable

    Private oStack As New Stack
    Dim strFilter As String


#Region "Events"

    Private Sub frmPos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            'txtSerial_vc.Enabled = False
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
            Me.clsDalPos.BeginProc()
            If CheckRepeated() = True Then
                Exit Sub
            End If

            Save()
            Me.clsMyControler.DataGridView = dgvPos
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            dgvPos.Focus()

        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        Finally
            Me.clsDalPos.EndProc()
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Cancel()
    End Sub

    Private Sub dgvState_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPos.RowEnter
        RowEnter(e.RowIndex)
    End Sub
    Private Sub frmPos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.clsMyControler.Key(sender, e)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    'Private Sub TextboxEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEniacCode_vc.Enter, txtPropertyNo_vc.Enter, txtSerial_vc.Enter
    '    ChooseCulture(sender)
    'End Sub
#End Region
#Region "Methods"
    Private Sub InitialForms()
        Me.dgvPos.AutoGenerateColumns = False



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

        Dim saveAndNextButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        saveAndNextButton.Button = btnSaveAndNext
        saveAndNextButton.e = New EventHandler(AddressOf btnSaveAndNext_Click)
        saveAndNextButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Save
        saveAndNextButton.ShortCut = ClassSetting.SaveExit_Shortcut
        Me.clsMyControler.AddButton(saveAndNextButton)

        Dim Search As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        Search.Button = btnSearch
        Search.e = New EventHandler(AddressOf btnSearch_Click)
        Search.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Find
        Search.ShortCut = ClassSetting.Search_Shortcut
        Me.clsMyControler.AddButton(Search)

        Dim SearchBack As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        SearchBack.Button = btnSearchBack
        SearchBack.e = New EventHandler(AddressOf btnSearchBack_Click)
        SearchBack.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Find
        'SearchBack.ShortCut = ClassSetting.Search_Shortcut
        Me.clsMyControler.AddButton(SearchBack)

        Dim RemoveFilter As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        RemoveFilter.Button = btnRemoveFilter
        RemoveFilter.e = New EventHandler(AddressOf btnRemoveFilter_Click)
        RemoveFilter.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Find
        'Search.ShortCut = ClassSetting.Search_Shortcut
        Me.clsMyControler.AddButton(RemoveFilter)



        Dim PosID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        PosID.Control = txtPosID
        PosID.EnabledInAddState = True
        PosID.EnabledInEditState = False
        PosID.EnabledInViewState = False
        PosID.MappedColumn = "colPosID"
        PosID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(PosID)

        Dim Serial_vc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Serial_vc.Control = txtSerial_vc
        Serial_vc.EnabledInAddState = True
        Serial_vc.EnabledInEditState = True
        Serial_vc.EnabledInViewState = False
        Serial_vc.MappedColumn = "colSerial_vc"
        Serial_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Serial_vc)

        Dim PropertyNo_vc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        PropertyNo_vc.Control = txtPropertyNo_vc
        PropertyNo_vc.EnabledInAddState = True
        PropertyNo_vc.EnabledInEditState = True
        PropertyNo_vc.EnabledInViewState = False
        PropertyNo_vc.MappedColumn = "colPropertyNo_vc"
        PropertyNo_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(PropertyNo_vc)

        Dim EniacCode_vc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        EniacCode_vc.Control = txtEniacCode_vc
        EniacCode_vc.EnabledInAddState = True
        EniacCode_vc.EnabledInEditState = True
        EniacCode_vc.EnabledInViewState = False
        EniacCode_vc.MappedColumn = "colEniacCode_vc"
        EniacCode_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(EniacCode_vc)

        Dim Active_Tint As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Active_Tint.Control = chkActive_Tint
        Active_Tint.EnabledInAddState = True
        Active_Tint.EnabledInEditState = True
        Active_Tint.EnabledInViewState = False
        Active_Tint.MappedColumn = "colActive_Tint"
        Active_Tint.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(Active_Tint)

        Dim ProductNo_vc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ProductNo_vc.Control = txtProductNo_vc
        ProductNo_vc.EnabledInAddState = True
        ProductNo_vc.EnabledInEditState = True
        ProductNo_vc.EnabledInViewState = False
        ProductNo_vc.MappedColumn = "colProductNo_vc"
        ProductNo_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(ProductNo_vc)

        Dim PartNo_int As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        PartNo_int.Control = txtPartNo_int
        PartNo_int.EnabledInAddState = True
        PartNo_int.EnabledInEditState = True
        PartNo_int.EnabledInViewState = False
        PartNo_int.MappedColumn = "colPartNo_int"
        PartNo_int.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(PartNo_int)

        Dim PosType As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        PosType.Control = cboPosTypeID
        PosType.EnabledInAddState = True
        PosType.EnabledInEditState = True
        PosType.EnabledInViewState = False
        PosType.MappedColumn = "colPosTypeName_nvc"
        PosType.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(PosType)


        Dim PosModelName_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        PosModelName_nvc.Control = cboPosModel
        PosModelName_nvc.EnabledInAddState = True
        PosModelName_nvc.EnabledInEditState = True
        PosModelName_nvc.EnabledInViewState = False
        PosModelName_nvc.MappedColumn = "colPosModelName_nvc"
        PosModelName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(PosModelName_nvc)

        Dim PosGoodName_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        PosGoodName_vc.Control = cboGood
        PosGoodName_vc.EnabledInAddState = True
        PosGoodName_vc.EnabledInEditState = True
        PosGoodName_vc.EnabledInViewState = False
        PosGoodName_vc.MappedColumn = "colGoodName_vc"
        PosGoodName_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(PosGoodName_vc)

        Dim BatchNo_int As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        BatchNo_int.Control = txtBatchNo_int
        BatchNo_int.EnabledInAddState = True
        BatchNo_int.EnabledInEditState = True
        BatchNo_int.EnabledInViewState = False
        BatchNo_int.MappedColumn = "colBatchNo_int"
        BatchNo_int.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(BatchNo_int)


        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.clsMyControler.DataGridView = Me.dgvPos
    End Sub
    Private Sub FormLoad()
        Try
            Me.clsDalPos.BeginProc()
            FillCboPosTypeID()
            FillCboPosModel()
            FillCboGood()

            dtPos.Clear()
            dtPos = clsDalPos.GetAllPos
            dvPos = dtPos.DefaultView
            Me.dgvPos.DataSource = dvPos

            dtSearchField.Columns.Add("FieldText")
            dtSearchField.Columns.Add("FieldName")
            dtSearchField.Columns.Add("FieldType")

            dtSearchOperation.Columns.Add("OperationName")
            dtSearchOperation.Columns.Add("Operator")

            RemoveHandler cboSearchField.SelectedIndexChanged, AddressOf cboSearchField_SelectedIndexChanged
            FillSearch()
            AddHandler cboSearchField.SelectedIndexChanged, AddressOf cboSearchField_SelectedIndexChanged

            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalPos.EndProc()
        End Try
    End Sub
    Private Sub FillCboPosTypeID()
        Try
            dtPosType.Clear()
            dtPosType = clsDalPos.GetAllPosType()
            cboPosTypeID.DataSource = dtPosType
            cboPosTypeID.DisplayMember = "Name_nvc"
            cboPosTypeID.ValueMember = "PosTypeID"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillcboGood()
        Try
            dtGood.Clear()
            dtGood = clsDalPos.GetAllGood()
            cboGood.DataSource = dtGood
            cboGood.DisplayMember = "Name_nvc"
            cboGood.ValueMember = "GOOD_ID"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillCboPosModel()
        Try
            dtPosModel.Clear()
            dtPosModel = clsDalPos.GetAllPosModel()
            cboPosModel.DataSource = dtPosModel
            cboPosModel.DisplayMember = "Name_nvc"
            cboPosModel.ValueMember = "PosModelID"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Add()
        Try
            clsMyControler.DataGridView = dgvPos
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            modPublicMethod.SelectAText(txtEniacCode_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvPos
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            modPublicMethod.SelectAText(txtEniacCode_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Delete()
        If txtPosID.Text.Trim <> "" Then
            clsDalPos.PosID = Convert.ToInt64(txtPosID.Text.Trim)
        End If
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvPos
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalPos.BeginProc()
                DoDelete()
                Me.dtPos.AcceptChanges()
            Catch ex As Exception
                Me.dtPos.RejectChanges()
                Throw ex
                Exit Sub
            Finally
                clsDalPos.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Sub Save()
        clsDalPos.PropertyNo_vc = txtPropertyNo_vc.Text.Trim
        clsDalPos.Serial_vc = txtSerial_vc.Text
        clsDalPos.EniacCode_vc = txtEniacCode_vc.Text.Trim
        clsDalPos.Active_Tint = IIf(chkActive_Tint.Checked = True, 1, 0)
        clsDalPos.ProductNo_vc = txtProductNo_vc.Text.Trim
        clsDalPos.PartNo_int = IIf(txtPartNo_int.Text.Trim = "", 0, txtPartNo_int.Text.Trim)
        clsDalPos.PosTypeID = cboPosTypeID.SelectedValue
        clsDalPos.PosModelID = cboPosModel.SelectedValue
        clsDalPos.Good_ID = cboGood.SelectedValue
        clsDalPos.BatchNo_int = IIf(txtBatchNo_int.Text.Trim = String.Empty, -1, txtBatchNo_int.Text)

        Try
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    DoInsert()
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    clsDalPos.PosID = Convert.ToInt64(txtPosID.Text.Trim)
                    DoUpdate()
            End Select
            dtPos.AcceptChanges()
        Catch ex As Exception
            dtPos.RejectChanges()
            Throw ex
        End Try

    End Sub
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Me.clsMyControler.DataGridView = dgvPos
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvPos.Focus()
    End Sub
    Private Sub DoInsert()
        Try
            Dim InsertedID As Int64
            InsertedID = Me.clsDalPos.InsertPos()
            clsDalPos.PosID = InsertedID.ToString
            DatatableInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            Me.clsDalPos.UpdatePos()
            DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            Me.clsDalPos.DeletePos()
            DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert()
        Try
            Dim dr As DataRow = Me.dtPos.NewRow
            dr.Item("PosID") = clsDalPos.PosID
            dr.Item("Serial_vc") = clsDalPos.Serial_vc
            dr.Item("PropertyNo_vc") = clsDalPos.PropertyNo_vc
            dr.Item("EniacCode_vc") = clsDalPos.EniacCode_vc
            dr.Item("Active_Tint") = clsDalPos.Active_Tint
            dr.Item("ProductNo_vc") = clsDalPos.ProductNo_vc
            dr.Item("PartNo_int") = clsDalPos.PartNo_int
            dr.Item("PosTypeID") = clsDalPos.PosTypeID
            dr.Item("PosModelid") = clsDalPos.PosModelID
            dr.Item("Good_ID") = clsDalPos.Good_ID
            'dr.Item("PosTypeName_nvc") = cboPosTypeID.Text
            'dr.Item("PosModelName_nvc") = cboPosModel.Text

            Dim dr2() As DataRow
            dr2 = DirectCast(cboPosTypeID.DataSource, DataTable).Select("PosTypeID =" & clsDalPos.PosTypeID)
            If dr2.Length > 0 Then
                dr.Item("PosTypeName_nvc") = dr2(0).Item("Name_nvc")
            Else
                dr.Item("PosTypeName_nvc") = ""
            End If

            Dim dr3() As DataRow
            dr3 = DirectCast(cboPosModel.DataSource, DataTable).Select("PosModelid =" & clsDalPos.PosModelID)
            If dr3.Length > 0 Then
                dr.Item("PosModelName_nvc") = dr3(0).Item("Name_nvc")
            Else
                dr.Item("PosModelName_nvc") = ""
            End If

            Dim dr4() As DataRow
            dr4 = DirectCast(cboGood.DataSource, DataTable).Select("Good_ID =" & clsDalPos.Good_ID)
            If dr4.Length > 0 Then
                dr.Item("GoodName_nvc") = dr4(0).Item("Name_nvc")
            Else
                dr.Item("GoodName_nvc") = ""
            End If


            dr.Item("BatchNo_int") = IIf(clsDalPos.BatchNo_int = -1, DBNull.Value, clsDalPos.BatchNo_int)


            Me.dtPos.Rows.Add(dr)
            If dgvPos.Rows.Count > 0 Then
                dgvPos.CurrentCell = dgvPos.Rows(dgvPos.Rows.Count - 1).Cells("colSerial_vc")
                RowEnter(dgvPos.Rows.Count - 1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtPos.Select("PosID = " + clsDalPos.PosID.ToString)
            If dr.Length > 0 Then
                dr(0).Item("Serial_vc") = clsDalPos.Serial_vc
                dr(0).Item("PropertyNo_vc") = clsDalPos.PropertyNo_vc
                dr(0).Item("EniacCode_vc") = clsDalPos.EniacCode_vc
                dr(0).Item("Active_Tint") = clsDalPos.Active_Tint
                dr(0).Item("ProductNo_vc") = clsDalPos.ProductNo_vc
                dr(0).Item("PartNo_int") = clsDalPos.PartNo_int
                dr(0).Item("PosTypeID") = clsDalPos.PosTypeID
                'dr(0).Item("PosTypeName_nvc") = cboPosTypeID.Text
                dr(0).Item("PosModelid") = clsDalPos.PosModelID
                dr(0).Item("Good_ID") = clsDalPos.Good_ID
                'dr(0).Item("PosModelName_nvc") = cboPosModel.Text



                Dim dr2() As DataRow
                dr2 = DirectCast(cboPosTypeID.DataSource, DataTable).Select("PosTypeID =" & clsDalPos.PosTypeID)
                If dr2.Length > 0 Then
                    dr(0).Item("PosTypeName_nvc") = dr2(0).Item("Name_nvc")
                Else
                    dr(0).Item("PosTypeName_nvc") = ""
                End If

                Dim dr3() As DataRow
                dr3 = DirectCast(cboPosModel.DataSource, DataTable).Select("PosModelid =" & clsDalPos.PosModelID)
                If dr3.Length > 0 Then
                    dr(0).Item("PosModelName_nvc") = dr3(0).Item("Name_nvc")
                Else
                    dr(0).Item("PosModelName_nvc") = ""
                End If


                Dim dr4() As DataRow
                dr4 = DirectCast(cboGood.DataSource, DataTable).Select("Good_ID =" & clsDalPos.Good_ID)
                If dr4.Length > 0 Then
                    dr(0).Item("GoodName_nvc") = dr4(0).Item("Name_nvc")
                Else
                    dr(0).Item("GoodName_nvc") = ""
                End If

                dr(0).Item("BatchNo_int") = IIf(clsDalPos.BatchNo_int = -1, DBNull.Value, clsDalPos.BatchNo_int)


            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtPos.Select("PosID = " + clsDalPos.PosID.ToString)
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If Me.txtSerial_vc.Text.Trim.Length = 0 Then
            Me.ErrorProvider.SetError(Me.txtSerial_vc, "سریال راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtSerial_vc, "")
        End If
        If Me.txtEniacCode_vc.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtEniacCode_vc, "کد پیگیری راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtEniacCode_vc, "")
        End If
        If Me.txtPropertyNo_vc.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtPropertyNo_vc, "شماره اموال راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtPropertyNo_vc, "")
        End If
        If Me.txtProductNo_vc.Text.Trim = "" Then
            Me.ErrorProvider.SetError(Me.txtProductNo_vc, "شماره محصول راوارد کنید")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.txtProductNo_vc, "")
        End If
        If Me.cboPosTypeID.SelectedIndex = -1 Then
            Me.ErrorProvider.SetError(Me.cboPosTypeID, "نوع دستگاه را انتخاب نماييد")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.cboPosTypeID, "")
        End If
        If Me.cboPosModel.SelectedIndex = -1 Then
            Me.ErrorProvider.SetError(Me.cboPosModel, "مدل دستگاه را انتخاب نماييد")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.cboPosModel, "")
        End If

        If Me.cboGood.SelectedIndex = -1 Then
            Me.ErrorProvider.SetError(Me.cboGood, "ورژن مدل را انتخاب نماييد")
            res = False
        Else
            Me.ErrorProvider.SetError(Me.cboGood, "")
        End If


        Return res
    End Function
    Private Function CheckRepeated() As Boolean
        Dim dt As New DataTable
        Dim res As Boolean = False
        clsDalPos.EniacCode_vc = txtEniacCode_vc.Text
        clsDalPos.Serial_vc = txtSerial_vc.Text
        clsDalPos.PropertyNo_vc = txtPropertyNo_vc.Text
        clsDalPos.ProductNo_vc = txtProductNo_vc.Text.Trim
        Select Case Me.clsMyControler.CurrentState
            Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                If clsDalPos.GetBySerialPos.Rows.Count <> 0 Then
                    Me.ErrorProvider.SetError(Me.txtSerial_vc, "سریال تکراری است")
                    res = True
                Else
                    Me.ErrorProvider.SetError(Me.txtSerial_vc, "")
                End If
                If clsDalPos.GetByPropertyNoPos.Rows.Count <> 0 Then
                    Me.ErrorProvider.SetError(Me.txtPropertyNo_vc, "شماره اموال تکراری است")
                    res = True
                Else
                    Me.ErrorProvider.SetError(Me.txtPropertyNo_vc, "")
                End If
                If clsDalPos.GetByEniacCodePos.Rows.Count <> 0 Then
                    Me.ErrorProvider.SetError(Me.txtEniacCode_vc, "کد پیگیری تکراری است")
                    res = True
                Else
                    Me.ErrorProvider.SetError(Me.txtEniacCode_vc, "")
                End If
            Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                clsDalPos.PosID = Convert.ToInt64(txtPosID.Text.Trim)
                dt.Clear()
                dt = clsDalPos.GetBySerialPos()
                If dt.Rows.Count <> 0 Then
                    If clsDalPos.PosID <> dt.Rows(0).Item("PosID") Then
                        Me.ErrorProvider.SetError(Me.txtSerial_vc, "سریال تکراری است")
                        res = True
                    Else
                        Me.ErrorProvider.SetError(Me.txtSerial_vc, "")
                    End If
                Else
                    Me.ErrorProvider.SetError(Me.txtSerial_vc, "")
                End If

                dt.Clear()
                dt = clsDalPos.GetByPropertyNoPos
                If dt.Rows.Count <> 0 Then
                    If clsDalPos.PosID <> dt.Rows(0).Item("PosID") Then
                        Me.ErrorProvider.SetError(Me.txtPropertyNo_vc, "شماره اموال تکراری است")
                        res = True
                    Else
                        Me.ErrorProvider.SetError(Me.txtPropertyNo_vc, "")

                    End If
                Else
                    Me.ErrorProvider.SetError(Me.txtPropertyNo_vc, "")
                End If

                dt.Clear()
                dt = clsDalPos.GetByEniacCodePos
                If dt.Rows.Count <> 0 Then
                    If clsDalPos.PosID <> dt.Rows(0).Item("PosID") Then
                        Me.ErrorProvider.SetError(Me.txtEniacCode_vc, "کد پیگیری تکراری است")
                        res = True
                    Else
                        Me.ErrorProvider.SetError(Me.txtEniacCode_vc, "")
                    End If
                Else
                    Me.ErrorProvider.SetError(Me.txtEniacCode_vc, "")
                End If

                'dt.Clear()
                'dt = clsDalPos.GetByProductNoPos
                'If dt.Rows.Count <> 0 Then
                '    If clsDalPos.PosID <> dt.Rows(0).Item("PosID") Then
                '        Me.ErrorProvider.SetError(Me.txtProductNo_vc, "شماره محصول تکراری است")
                '        res = True
                '    Else
                '        Me.ErrorProvider.SetError(Me.txtProductNo_vc, "")
                '    End If
                'Else
                '    Me.ErrorProvider.SetError(Me.txtProductNo_vc, "")
                'End If
        End Select
        Return res
    End Function
    'Private Sub Import()
    '    Try
    '        OpenFileDialog.FileName = ""
    '        OpenFileDialog.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
    '        OpenFileDialog.ShowDialog()
    '        Dim FilePath As String
    '        FilePath = OpenFileDialog.FileName
    '        If FilePath.Trim <> "" Then
    '                ReadFromExcelfile(FilePath)
    '        End If
    '        ShowMessage(modApplicationMessage.msgSuccess)
    '        'Catch ex As FileNotFoundException
    '        '    Throw ex
    '        'Catch ex As MissingFieldException
    '        '    Throw ex
    '    Catch ex As InvalidDataException
    '        Throw ex
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub ReadFromExcelfile(ByVal FilePath As String)
    '    Try
    '        Dim dtExcel As New DataTable
    '        ClassExcel.ExcelFilePath = FilePath
    '        ClassExcel.ExcelSheetName = "Sheet1" ' txtExcelSheetName.Text.Trim
    '        dtExcel = ClassExcel.GetExcel()

    '        'Dim colNotvalidRowsIndex As New Collection
    '        If dtExcel.Columns.Count < 4 Then
    '            Throw New InvalidDataException
    '        End If
    '        clsDalPos.BeginProc()
    '        For i As Int32 = 0 To dtExcel.Rows.Count - 1
    '            If IsDBNull(dtExcel.Rows(i).Item("SerialNo").ToString.Trim) = True Then
    '                Continue For
    '            Else
    '                clsDalPos.EniacCode_vc = dtExcel.Rows(i).Item("EniacCode").ToString.Trim
    '                clsDalPos.PropertyNo_vc = dtExcel.Rows(i).Item("PropertyNo").ToString.Trim
    '                clsDalPos.Serial_vc = dtExcel.Rows(i).Item("SerialNo").ToString.Trim
    '                clsDalPos.ProductNo_vc = dtExcel.Rows(i).Item("ProductNo").ToString.Trim
    '                clsDalPos.Active_Tint = 1
    '                clsDalPos.PartNo_int = txtPartNo.Text.Trim
    '                clsDalPos.PosTypeID = 1
    '            End If

    '            If clsDalPos.GetBySerialPos.Rows.Count = 0 AndAlso clsDalPos.GetByPropertyNoPos.Rows.Count = 0 AndAlso clsDalPos.GetByEniacCodePos.Rows.Count = 0 Then
    '                DoInsert()
    '            Else
    '                '===nothing
    '            End If
    '            dtPos.AcceptChanges()
    '        Next
    '        'If colNotvalidRowsIndex.Count > 0 Then
    '        '    Dim strInvalidRowsIndex As String = ""
    '        '    For i As Int32 = 1 To colNotvalidRowsIndex.Count
    '        '        strInvalidRowsIndex += colNotvalidRowsIndex.Item(i).ToString.Trim + ","
    '        '    Next
    '        '    strInvalidRowsIndex = strInvalidRowsIndex.Remove(strInvalidRowsIndex.Trim.Length - 1, 1)
    '        '    If colNotvalidRowsIndex.Count = 1 Then
    '        '        ShowErrorMessage("سطر " & strInvalidRowsIndex & "دارای اطلاعات نامعتبر می باشد")
    '        '    Else
    '        '        ShowErrorMessage("سطرهای " & strInvalidRowsIndex & "دارای اطلاعات نامعتبر می باشند")
    '        '    End If
    '        'End If
    '        'Catch ex As FileNotFoundException
    '        '    Throw ex
    '        '    Exit Sub
    '        'Catch ex As MissingFieldException
    '        '    Throw ex
    '        '    Exit Sub
    '    Catch ex As InvalidDataException
    '        Throw ex
    '        Exit Sub
    '    Catch ex As Exception
    '        dtPos.RejectChanges()
    '        Throw ex
    '        Exit Sub
    '    Finally
    '        Me.clsDalPos.EndProc()
    '    End Try

    '    Me.clsMyControler.DataGridView = dgvPos
    '    Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
    '    dgvPos.Focus()
    'End Sub
    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.clsMyControler.DataGridView = Me.dgvPos
        Me.clsMyControler.SetControlsValue(Rowindex)
    End Sub
#End Region


    Private Sub frmPos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
    Private Sub dgvPos_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvPos.RowPostPaint
        'Dim b As SolidBrush = New SolidBrush(dgvPos.RowHeadersDefaultCellStyle.ForeColor)
        ''Me.Text = e.RowBounds.Location.X
        'If e.RowBounds.Location.X = 1 Then
        '    e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvPos.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvPos.Width - 30, e.RowBounds.Location.Y + 4)
        'ElseIf e.RowBounds.Location.X = 18 Then
        '    e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvPos.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvPos.Width - 45, e.RowBounds.Location.Y + 4)
        'End If
    End Sub
    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvPos)
            End If
            'ExportToExcel()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
#Region "Search"
    Private Sub FillSearch()
        Try

            For i As Int32 = 0 To dgvPos.Columns.Count - 1
                If dgvPos.Columns(i).Visible = True Then
                    If dtPos.Columns(dgvPos.Columns(i).DataPropertyName).DataType IsNot GetType(System.Boolean) Then
                        Dim dr As DataRow = dtSearchField.NewRow
                        dr.Item("FieldText") = dgvPos.Columns(i).HeaderText
                        dr.Item("FieldName") = dgvPos.Columns(i).DataPropertyName
                        dr.Item("FieldType") = dtPos.Columns(dgvPos.Columns(i).DataPropertyName).DataType
                        dtSearchField.Rows.Add(dr)
                    End If
                End If
            Next

            cboSearchField.ComboBox.DisplayMember = "FieldText"
            cboSearchField.ComboBox.ValueMember = "FieldName"
            cboSearchField.ComboBox.DataSource = dtSearchField
            cboSearchField.ComboBox.SelectedIndex = -1
            cboSearchOperation.ComboBox.DataSource = Nothing
            txtSearch.Text = String.Empty
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillSearchOperation()
        Try
            dtSearchOperation.Clear()

            Dim dr() As DataRow
            dr = DirectCast(cboSearchField.ComboBox.DataSource, DataTable).Select("FieldName ='" & cboSearchField.ComboBox.SelectedValue & "'")

            If dr.Length > 0 Then
                Select Case dr(0).Item("FieldType").ToString
                    Case "System.String"
                        FillSearchOperationItems("شامل", "{0} Like '%{1}%'")
                        FillSearchOperationItems("برابر با", "{0}='{1}'")
                        FillSearchOperationItems("شروع با", "{0} Like '{1}%'")
                        FillSearchOperationItems("ختم به", "{0} Like '%{1}'")
                        FillSearchOperationItems("غیر شامل", "{0} not Like '%{1}%'")
                        FillSearchOperationItems("نامساوی با", "{0}<>'{1}'")
                        FillSearchOperationItems("بزرگتر از", "{0}>'{1}'")
                        FillSearchOperationItems("بزرگتر از یا مساوی با", "{0}>='{1}'")
                        FillSearchOperationItems("کوچکتر از", "{0}<'{1}'")
                        FillSearchOperationItems("کوچکتر از یا مساوی با", "{0}<='{1}'")

                    Case "System.Boolean"

                    Case "System.DateTime"
                        FillSearchOperationItems("نامساوی با", "{0}<>'{1}'")
                        FillSearchOperationItems("بزرگتر از", "{0}>'{1}'")
                        FillSearchOperationItems("بزرگتر از یا مساوی با", "{0}>='{1}'")
                        FillSearchOperationItems("کوچکتر از", "{0}<'{1}'")
                        FillSearchOperationItems("کوچکتر از یا مساوی با", "{0}<='{1}'")
                    Case Else
                        FillSearchOperationItems("برابر با", "{0}={1}")
                        FillSearchOperationItems("نامساوی با", "{0}<>{1}")
                        FillSearchOperationItems("بزرگتر از", "{0}>{1}")
                        FillSearchOperationItems("بزرگتر از یا مساوی با", "{0}>={1}")
                        FillSearchOperationItems("کوچکتر از", "{0}<{1}")
                        FillSearchOperationItems("کوچکتر از یا مساوی با", "{0}<={1}")

                End Select
            End If
            cboSearchOperation.ComboBox.DisplayMember = "OperationName"
            cboSearchOperation.ComboBox.ValueMember = "Operator"
            cboSearchOperation.ComboBox.DataSource = dtSearchOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillSearchOperationItems(ByVal opname As String, ByVal op As String)
        Dim drOP As DataRow = dtSearchOperation.NewRow
        drOP.Item("OperationName") = opname
        drOP.Item("Operator") = op
        dtSearchOperation.Rows.Add(drOP)
    End Sub

    Private Sub cboSearchField_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchField.SelectedIndexChanged
        Try
            FillSearchOperation()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If cboSearchField.ComboBox.SelectedIndex = -1 OrElse cboSearchOperation.ComboBox.SelectedIndex = -1 OrElse txtSearch.Text.Trim = String.Empty Then
            strFilter = String.Empty
        Else
            Dim dr() As DataRow
            dr = DirectCast(cboSearchField.ComboBox.DataSource, DataTable).Select("FieldName='" & cboSearchField.ComboBox.SelectedValue.ToString & "'")
            If dr.Length > 0 Then
                If Not (dr(0).Item("FieldType") = "System.String" Or dr(0).Item("FieldType") = "System.char" Or dr(0).Item("FieldType") = "System.dateTime" Or dr(0).Item("FieldType") = "System.Boolean") Then
                    If IsNumeric(txtSearch.Text) = False Then
                        Exit Sub
                    End If
                End If
            End If

            If dvPos.RowFilter.Contains(String.Format(cboSearchOperation.ComboBox.SelectedValue.ToString, cboSearchField.ComboBox.SelectedValue.ToString, txtSearch.Text)) = False Then
                If String.IsNullOrEmpty(dvPos.RowFilter) = False Then
                    oStack.Push(dvPos.RowFilter)
                End If
            End If


            If oStack.Count > 0 Then
                strFilter = oStack.Peek
                If strFilter.Contains(String.Format(cboSearchOperation.ComboBox.SelectedValue.ToString, cboSearchField.ComboBox.SelectedValue.ToString, modPublicMethod.CorrectLike(txtSearch.Text))) = False Then
                    strFilter = String.Format(cboSearchOperation.ComboBox.SelectedValue.ToString, cboSearchField.ComboBox.SelectedValue.ToString, modPublicMethod.CorrectLike(txtSearch.Text)) & " And " & strFilter
                End If
            Else
                strFilter = String.Format(cboSearchOperation.ComboBox.SelectedValue.ToString, cboSearchField.ComboBox.SelectedValue.ToString, modPublicMethod.CorrectLike(txtSearch.Text))
            End If
        End If

        dvPos.RowFilter = strFilter
    End Sub
    Private Sub btnSearchBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBack.Click
        If oStack.Count > 0 Then
            strFilter = oStack.Pop
        Else
            strFilter = String.Empty
        End If
        dvPos.RowFilter = strFilter

    End Sub
    Private Sub btnRemoveFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFilter.Click
        strFilter = String.Empty
        oStack.Clear()
        dvPos.RowFilter = strFilter
    End Sub
#End Region

    Private Sub btnSaveAndNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAndNext.Click
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        If RequiredValidator() = False Then
            Exit Sub
        End If
        Try
            Me.clsDalPos.BeginProc()
            If CheckRepeated() = True Then
                Exit Sub
            End If

            Save()
            Me.clsMyControler.DataGridView = dgvPos
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            txtEniacCode_vc.SelectAll()
            txtEniacCode_vc.Focus()

        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        Finally
            Me.clsDalPos.EndProc()
        End Try
    End Sub

    Private Sub cboPosModel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPosModel.SelectedIndexChanged
        Try
            FillcboGood(sender)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub FillcboGood(ByVal sender As Object)
        Try
            Me.clsDalPos.BeginProc()

            If cboPosModel.SelectedIndex = -1 Then
                clsDalPos.PosModelID = -1
            ElseIf cboPosModel.SelectedIndex = 0 Then
                clsDalPos.PosModelID = cboPosModel.SelectedItem(cboPosModel.SelectedIndex)
            Else
                clsDalPos.PosModelID = cboPosModel.SelectedValue
            End If
            Me.cboGood.DisplayMember = "Name_nvc"
            Me.cboGood.ValueMember = "GOOD_ID"
            Me.cboGood.DataSource = clsDalPos.GetGoodByPosModelID

        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalPos.EndProc()
        End Try
    End Sub
End Class