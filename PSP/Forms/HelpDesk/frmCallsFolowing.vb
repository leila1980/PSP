Public Class frmCallsFolowing
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvCallsFolowing, True, True, True, True)
    Private clsDalHelpDesk As New ClassDALHelpDesk(modPublicMethod.ConnectionString)
    Private clsDalAddress As New ClassDalAddress(modPublicMethod.ConnectionString)
    Private dtCallsInfoNComp As New DataTable
    Private dtCallsInfoComp As New DataTable
    Private dtCallsFolowing As New DataTable
    Private CallDate As String = String.Empty
    Public Enum ReferToEnum As Short
        fani = 1
        bazaryabi = 2
        bank = 3
    End Enum
    Private mvarReferTo As ReferToEnum
    Public Property ReferTo() As ReferToEnum
        Get
            Return mvarReferTo
        End Get
        Set(ByVal value As ReferToEnum)
            mvarReferTo = value
        End Set
    End Property
    Private Enum CallsInfoType As Short
        Completed = 1
        NotCompleted = 2
    End Enum

#Region "Events"
    Private Sub frmCallsFolowing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clsDalHelpDesk.BeginProc()
            If ReferTo = 1 Then
                btnPrint.Enabled = True
            Else
                btnPrint.Enabled = False
            End If
            SetPermissionForVisitors()
            FillGridCallsInfoNComp()
            InitGridCallsInfoNComp()
            FillGridCallsInfoComp()
            InitGridCallsInfoComp()

            InitCallsFolwing()
            FillCallsFolowing(0, CallsInfoType.Completed)
            FillCallsFolowing(0, CallsInfoType.NotCompleted)


            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            clsDalHelpDesk.EndProc()

        End Try
    End Sub
    Private Sub FillGridCallsInfoNComp()
        Try
            Dim dtCallInfo As DataTable = clsDalHelpDesk.GetByReferToAndCompletedCallsInfo(ReferTo, 0, ClassUserLoginDataAccess.ThisUser.UserID, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtCallInfo.Rows.Count > 0 Then
                For Each dataRow As DataRow In dtCallInfo.Rows
                    If Not String.IsNullOrEmpty(dataRow("ADDRESS").ToString) Then
                        dataRow("ADDRESS") = clsDalAddress.loadAddressDesc(dataRow("ADDRESS").ToString)
                    End If
                Next
            End If
            dgvCallsInfoNComp.DataSource = dtCallInfo

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGridCallsInfoNComp()
        Try
            dgvCallsInfoNComp.Columns("CallID").HeaderText = "كد پيگيري کارتابل"
            dgvCallsInfoNComp.Columns("Completed").Visible = False
            dgvCallsInfoNComp.Columns("RequestDesc").HeaderText = "شرح درخواست"
            dgvCallsInfoNComp.Columns("ResponsDesc").HeaderText = "شرح كار"
            dgvCallsInfoNComp.Columns("DeviceID").Visible = False
            dgvCallsInfoNComp.Columns("posid").Visible = False
            dgvCallsInfoNComp.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
            dgvCallsInfoNComp.Columns("createuser").HeaderText = "کاربر ثبت کننده"
            dgvCallsInfoNComp.Columns("CallDate_vc").HeaderText = "تاريخ تماس"
            dgvCallsInfoNComp.Columns("CallTime_vc").HeaderText = "ساعت تماس"
            dgvCallsInfoNComp.Columns("Outlet_vc").HeaderText = "کد پایانه"
            dgvCallsInfoNComp.Columns("ReferTo").Visible = False
            dgvCallsInfoNComp.Columns("Completed").Width = 120
            dgvCallsInfoNComp.Columns("CallDate_vc").Width = 120
            dgvCallsInfoNComp.Columns("CallTime_vc").Width = 120
            dgvCallsInfoNComp.Columns("CallID").Width = 120

            dgvCallsInfoNComp.Columns("lastname_nvc").HeaderText = "بازاریاب"
            dgvCallsInfoNComp.Columns("MunicipalAreaNO_sint").HeaderText = "منطقه"

            dgvCallsInfoNComp.Columns("Moghayerat_Amount_num").HeaderText = "مبلغ مغايرت"
            dgvCallsInfoNComp.Columns("Moghayerat_Amount2_num").HeaderText = "مبلغ"
            dgvCallsInfoNComp.Columns("Moghayerat_CustomerName_nvc").HeaderText = "نام مشتري"
            dgvCallsInfoNComp.Columns("Moghayerat_CardNo_vc").HeaderText = "شماره كارت"
            dgvCallsInfoNComp.Columns("Moghayerat_Tel_vc").HeaderText = "تلفن"
            dgvCallsInfoNComp.Columns("Moghayerat_TranDate_vc").HeaderText = "تاريخ تراكنش"
            dgvCallsInfoNComp.Columns("Moghayerat_TranTime_vc").HeaderText = "ساعت تراكنش"
            dgvCallsInfoNComp.Columns("DeviceID").Visible = False
            dgvCallsInfoNComp.Columns("Ratio_int").HeaderText = "تعداد دفعات تماس"
            dgvCallsInfoNComp.Columns("ResponseDateTime").HeaderText = "تاریخ آخرین پاسخ"
            dgvCallsInfoNComp.Columns("ADDRESS").HeaderText = "آدرس"
            dgvCallsInfoNComp.Columns("ADDRESS").Width = 500



        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGridCallsInfoComp()

        Try
            Dim dt As DataTable = clsDalHelpDesk.GetByReferToAndCompletedCallsInfo(ReferTo, 1, ClassUserLoginDataAccess.ThisUser.UserID, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dt.Rows.Count > 0 Then
                For Each dataRow As DataRow In dt.Rows
                    If Not String.IsNullOrEmpty(dataRow("ADDRESS").ToString) Then
                        dataRow("ADDRESS") = clsDalAddress.loadAddressDesc(dataRow("ADDRESS").ToString)
                    End If
                Next
            End If
            dgvCallsInfoComp.DataSource = dt

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGridCallsInfoComp()
        Try
            dgvCallsInfoComp.Columns("CallID").HeaderText = "كد پيگيري کارتابل "
            dgvCallsInfoComp.Columns("Completed").Visible = False
            dgvCallsInfoComp.Columns("RequestDesc").HeaderText = "شرح درخواست"
            dgvCallsInfoComp.Columns("ResponsDesc").HeaderText = "شرح كار"
            dgvCallsInfoComp.Columns("DeviceId").Visible = False
            dgvCallsInfoComp.Columns("posid").Visible = False
            dgvCallsInfoComp.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
            dgvCallsInfoComp.Columns("createuser").HeaderText = "کاربر ثبت کننده"
            dgvCallsInfoComp.Columns("CallDate_vc").HeaderText = "تاريخ تماس"
            dgvCallsInfoComp.Columns("CallTime_vc").HeaderText = "ساعت تماس"
            dgvCallsInfoComp.Columns("Outlet_vc").HeaderText = "کد پایانه"
            dgvCallsInfoComp.Columns("ReferTo").Visible = False
            dgvCallsInfoComp.Columns("Completed").Width = 120
            dgvCallsInfoComp.Columns("CallDate_vc").Width = 120
            dgvCallsInfoComp.Columns("CallTime_vc").Width = 120
            dgvCallsInfoComp.Columns("lastname_nvc").HeaderText = "بازاریاب"
            dgvCallsInfoComp.Columns("MunicipalAreaNO_sint").HeaderText = "منطقه"
            dgvCallsInfoComp.Columns("Ratio_int").HeaderText = "تعداد دفعات تماس"
            dgvCallsInfoComp.Columns("ResponseDateTime").HeaderText = "تاریخ آخرین پاسخ"
            dgvCallsInfoComp.Columns("ADDRESS").HeaderText = "آدرس"
            dgvCallsInfoComp.Columns("ADDRESS").Width = 500


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub dgvCallsInfoNComp_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvCallsInfoNComp.RowHeaderMouseDoubleClick
    '    Try
    '        PrePareToSaveCallsFolowing(e.RowIndex)
    '    Catch ex As Exception
    '        ShowErrorMessage(ex.Message)
    '    End Try
    'End Sub
    'Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    '    Try
    '        clsDalHelpDesk.BeginProc()
    '        Save()
    '    Catch ex As Exception
    '        ShowErrorMessage(ex.Message)
    '    Finally
    '        clsDalHelpDesk.EndProc()
    '    End Try
    'End Sub
    'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    '    Try
    '        grpCallsFolowing.Enabled = False
    '        grpGrid.Enabled = True
    '        EmptyCallsInfo()
    '    Catch ex As Exception
    '        ShowErrorMessage(ex.Message)
    '    End Try
    'End Sub

#End Region
#Region "Methods"

    'Private Sub PrePareToSaveCallsFolowing(ByVal row As Integer)
    '    Try
    '        grpCallsFolowing.Enabled = True
    '        grpGrid.Enabled = False
    '        EmptyCallsInfo()
    '        txtCallID.Text = dgvCallsInfoNComp.Rows(row).Cells("CallID").Value.ToString
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub EmptyCallsInfo()
    '    ErrorProvider1.Clear()
    '    txtCallID.Text = ""
    '    txtresDesc.Text = ""
    '    rbtCompleted.Checked = True
    '    txtResponseDate_vc.Text = ""
    '    txtResponseTime_vc.Text = ""
    'End Sub

    'Private Sub Save()
    '    Try
    '        ErrorProvider1.Clear()
    '        If RequiredValidator() = False Then
    '            Exit Sub
    '        End If
    '        clsDalHelpDesk.InsertCallsFolowing(Convert.ToInt64(txtCallID.Text), IIf(rbtCompleted.Checked = True, 1, 0), txtResponsDesc.Text, txtResponseDate_vc.Text, txtResponseTime_vc.Text)
    '        clsDalHelpDesk.UpdateCallsInfoForCompleted_SP(Convert.ToInt64(txtCallID.Text), IIf(rbtCompleted.Checked = True, 1, 0))
    '        FillGridCallsInfoNComp()
    '        FillGridCallsInfoComp()

    '        grpCallsFolowing.Enabled = False
    '        grpGrid.Enabled = True
    '        EmptyCallsInfo()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

#End Region
#Region "CallsFolowing"
#Region "Events"
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
            If dgvCallsFolowing.Rows.Count = 0 Then
                ShowErrorMessage("موردي براي ويرايش وجود ندارد")
                Exit Sub
            End If
            Edit()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If dgvCallsFolowing.Rows.Count = 0 Then
                ShowErrorMessage("موردي براي حذف وجود ندارد")
                Exit Sub
            End If
            If DeleteRequiredValidator() = False Then
                ShowErrorMessage("به ازای این مورد ، تماس ، ""تمام شده"" ثبت شده است ،لذا این مورد  قابل حذف نمی باشد")
                Exit Sub
            End If
            Delete()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgDeleteFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If RequiredValidator() = False Then
            Exit Sub
        End If
        Try
            If RequiredDBValidator() = False Then
                ShowErrorMessage("برای این تماس رکوردی به صورت ""تمام شده"" ثبت شده است ، در نتیجه امکان اضافه کردن مورد دیگری وجود ندارد")
                Exit Sub
            End If
            Save()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Cancel()
    End Sub

    Private Sub dgvCallsFolowing_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCallsFolowing.RowEnter
        RowEnter(e.RowIndex)
    End Sub
    Private Sub frmCallsFolowing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.clsMyControler.Key(sender, e)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
   
#End Region
#Region "Methods"
    Private Sub InitCallsFolwing()
        Me.dgvCallsFolowing.AutoGenerateColumns = False

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


        Dim Completed As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Completed.Control = rbtCompleted
        Completed.EnabledInAddState = True
        Completed.EnabledInEditState = True
        Completed.EnabledInViewState = False
        Completed.MappedColumn = "colCompleted"
        Completed.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(Completed)

        Dim NotCompleted As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        NotCompleted.Control = rbtNotCompleted
        NotCompleted.EnabledInAddState = True
        NotCompleted.EnabledInEditState = True
        NotCompleted.EnabledInViewState = False
        'FemaleGender_bit.MappedColumn = "colGender_bit"
        NotCompleted.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(NotCompleted)


        Dim CallFolowingID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        CallFolowingID.Control = txtCallFolowingID
        CallFolowingID.EnabledInAddState = False
        CallFolowingID.EnabledInEditState = False
        CallFolowingID.EnabledInViewState = False
        CallFolowingID.MappedColumn = "colCallFolowingID"
        CallFolowingID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(CallFolowingID)

        Dim CallID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        CallID.Control = txtCallID
        CallID.EnabledInAddState = False
        CallID.EnabledInEditState = False
        CallID.EnabledInViewState = False
        CallID.MappedColumn = "colCallID"
        CallID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(CallID)


        Dim bResDesc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        bResDesc.Control = btnResDesc
        bResDesc.EnabledInAddState = True
        bResDesc.EnabledInEditState = True
        bResDesc.EnabledInViewState = False
        bResDesc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(bResDesc)

        Dim ResponsDesc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ResponsDesc.Control = txtResponsDesc
        Select Case ReferTo
            Case ReferToEnum.fani
                ResponsDesc.EnabledInAddState = True
                ResponsDesc.EnabledInEditState = True
            Case ReferToEnum.bank
                ResponsDesc.EnabledInAddState = True
                ResponsDesc.EnabledInEditState = True
            Case ReferToEnum.bazaryabi
                ResponsDesc.EnabledInAddState = True
                ResponsDesc.EnabledInEditState = True
        End Select
        ResponsDesc.EnabledInViewState = False
        ResponsDesc.MappedColumn = "colResponsDesc"
        ResponsDesc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(ResponsDesc)

        Dim Description As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Description.Control = txtDescription
        'Description.EnabledInAddState = False
        'Description.EnabledInEditState = False
        Description.EnabledInAddState = True
        Description.EnabledInEditState = True
        Description.EnabledInViewState = False
        Description.MappedColumn = "colDescription"
        Description.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Description)

        Dim ResponseDate_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ResponseDate_vc.Control = txtResponseDate_vc
        ResponseDate_vc.EnabledInAddState = True
        ResponseDate_vc.EnabledInEditState = True
        ResponseDate_vc.EnabledInViewState = False
        ResponseDate_vc.MappedColumn = "colResponseDate_vc"
        ResponseDate_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Value
        Me.clsMyControler.AddControl(ResponseDate_vc)


        Dim ResponseTime_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ResponseTime_vc.Control = txtResponseTime_vc
        ResponseTime_vc.EnabledInAddState = True
        ResponseTime_vc.EnabledInEditState = True
        ResponseTime_vc.EnabledInViewState = False
        ResponseTime_vc.MappedColumn = "colResponseTime_vc"
        ResponseTime_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(ResponseTime_vc)



        Me.clsMyControler.DataGridView = Me.dgvCallsFolowing

        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

    End Sub
    Private Sub FillCallsFolowing(ByVal CallsInfoRow As Int32, ByVal type As CallsInfoType)
        Try
            Select Case type
                Case CallsInfoType.Completed
                    If dgvCallsInfoComp.Rows.Count > 0 Then
                        dtCallsFolowing = clsDalHelpDesk.GetByCallIDCallsFolowing(dgvCallsInfoComp.Rows(CallsInfoRow).Cells("CallID").Value)
                    End If
                Case CallsInfoType.NotCompleted
                    If dgvCallsInfoNComp.Rows.Count > 0 Then
                        dtCallsFolowing = clsDalHelpDesk.GetByCallIDCallsFolowing(dgvCallsInfoNComp.Rows(CallsInfoRow).Cells("CallID").Value)
                    End If
            End Select

            Me.dgvCallsFolowing.DataSource = dtCallsFolowing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Add()
        Try
            If TabControl1.SelectedIndex = 0 Then
                If dgvCallsInfoNComp.SelectedRows.Count > 0 Then
                    clsMyControler.DataGridView = dgvCallsFolowing
                    clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
                    txtCallID.Text = dgvCallsInfoNComp.SelectedRows(0).Cells("CallId").Value
                    grpGrid.Enabled = False
                    grpGrid2.Enabled = False
                    rbtNotCompleted.Checked = True
                    txtResponseDate_vc.Value = modPublicMethod.GetDateNow()
                    txtResponseTime_vc.Text = DateTime.Now.ToString("HH:MM")
                    Dim CLSUserLoginDA As New ClassUserLoginDataAccess(ConnectionString)
                    Try
                        CLSUserLoginDA.BeginProc()
                        If CLSUserLoginDA.GetCountVisitorByUserID(ClassUserLoginDataAccess.ThisUser.UserID) > 0 Then
                            txtResponsDesc.Text = "توضيحات نماينده"
                            txtDescription.Text = String.Empty
                            txtDescription.Enabled = True
                        End If

                        CLSUserLoginDA.EndProc()
                    Catch ex As Exception
                        ShowErrorMessage(ex.Message)
                    End Try
                Else
                    txtCallID.Text = ""
                    ShowErrorMessage("موردي براي ثبت از ليست بالا انتخاب نشده است")
                End If
            Else
                If dgvCallsInfoComp.SelectedRows.Count > 0 Then
                    clsMyControler.DataGridView = dgvCallsFolowing
                    clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
                    txtCallID.Text = dgvCallsInfoComp.SelectedRows(0).Cells("CallId").Value
                    grpGrid.Enabled = False
                    grpGrid2.Enabled = False
                    rbtNotCompleted.Checked = True
                    txtResponseDate_vc.Value = modPublicMethod.GetDateNow()
                    txtResponseTime_vc.Text = DateTime.Now.ToString("hh:mm")
                    Dim CLSUserLoginDA As New ClassUserLoginDataAccess(ConnectionString)
                    Try
                        CLSUserLoginDA.BeginProc()
                        If CLSUserLoginDA.GetCountVisitorByUserID(ClassUserLoginDataAccess.ThisUser.UserID) > 0 Then
                            txtResponsDesc.Text = "توضيحات نماينده"
                            txtDescription.Text = String.Empty
                            txtDescription.Enabled = True
                        End If

                        CLSUserLoginDA.EndProc()
                    Catch ex As Exception
                        ShowErrorMessage(ex.Message)
                    End Try
                Else
                    txtCallID.Text = ""
                    ShowErrorMessage("موردي براي ثبت از ليست بالا انتخاب نشده است")
                End If
            End If
            ' modPublicMethod.SelectAText(txtStateID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvCallsFolowing
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            'modPublicMethod.SelectAText(txtName_nvc)
            grpGrid.Enabled = False
            grpGrid2.Enabled = False
            txtDescriptionEnable()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Delete()
        If modPublicMethod.ShowConfirmDeleteMessage() = True Then
            Try
                clsMyControler.DataGridView = dgvCallsFolowing
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
                clsDalHelpDesk.BeginProc()
                DoDelete()
                RefreshForm()
            Catch ex As Exception
                Throw ex
                Exit Sub
            Finally
                clsDalHelpDesk.EndProc()
                clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
                clsMyControler.SetControlsValue()
            End Try
        End If
    End Sub
    Private Function DeleteRequiredValidator() As Boolean
        Dim dt As New DataTable
        dt = Me.clsDalHelpDesk.GetByCallsFollowingIDAnCompletedCallsFollowing(Convert.ToInt64(txtCallFolowingID.Text), 1)
        If dt.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub Save()
        Try
            Me.clsDalHelpDesk.BeginProc()
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    DoInsert()
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    DoUpdate()
            End Select
            DoUpdateCallInfo()

            RefreshForm()


        Catch ex As Exception
            Throw ex
            Exit Sub
        Finally
            grpGrid.Enabled = True
            grpGrid2.Enabled = True
            Me.clsDalHelpDesk.EndProc()
        End Try

        Me.clsMyControler.DataGridView = dgvCallsFolowing
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        dgvCallsFolowing.Focus()
    End Sub
    Private Sub RefreshForm()
        Try
            FillGridCallsInfoNComp()
            InitGridCallsInfoNComp()
            FillGridCallsInfoComp()
            InitGridCallsInfoComp()

            ClearCallsFollowing()
            If TabControl1.SelectedIndex = 1 Then
                FillCallsFolowing(0, CallsInfoType.Completed)
            ElseIf TabControl1.SelectedIndex = 0 Then
                FillCallsFolowing(0, CallsInfoType.NotCompleted)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Cancel()
        ErrorProvider1.Clear()
        Me.clsMyControler.DataGridView = dgvCallsFolowing
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvCallsFolowing.Focus()
        grpGrid.Enabled = True
        grpGrid2.Enabled = True

    End Sub
    Private Sub DoInsert()
        Try
            Dim id As Int64
            id = Me.clsDalHelpDesk.InsertCallsFolowing(Convert.ToInt64(txtCallID.Text), IIf(rbtCompleted.Checked = True, 1, 0), txtResponsDesc.Text, txtResponseDate_vc.Value, txtResponseTime_vc.Text, txtDescription.Text)
            'DatatableInsert(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdate()
        Try
            Me.clsDalHelpDesk.UpdateCallsFolowing(IIf(rbtCompleted.Checked = True, 1, 0), txtResponsDesc.Text, txtResponseDate_vc.Value, txtResponseTime_vc.Text, Convert.ToInt64(txtCallFolowingID.Text), txtDescription.Text)
            'DatatableUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDelete()
        Try
            Me.clsDalHelpDesk.DeleteCallsFolowing_SP(Convert.ToInt64(txtCallFolowingID.Text))
            'DatatableDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableInsert(ByVal id As Int64)
        Try
            Dim dr As DataRow = Me.dtCallsFolowing.NewRow
            dr.Item("CallFolowingID") = id
            dr.Item("CallID") = Convert.ToInt64(txtCallID.Text)
            dr.Item("Completed") = IIf(rbtCompleted.Checked = True, 1, 0)
            dr.Item("ResponsDesc") = txtResponsDesc.Text
            dr.Item("ResponseDate_vc") = txtResponseDate_vc.Text
            dr.Item("ResponseTime_vc") = txtResponseTime_vc.Text

            Me.dtCallsFolowing.Rows.Add(dr)
            dgvCallsFolowing.CurrentCell = dgvCallsFolowing.Rows(dtCallsFolowing.Rows.Count - 1).Cells(0)
            RowEnter(dtCallsFolowing.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableUpdate()
        Try
            Dim dr() As DataRow = Me.dtCallsFolowing.Select("CallFolowingID = '" + txtCallFolowingID.Text.Replace("'", "''") + "'")
            If dr.Length > 0 Then
                dr(0).Item("CallID") = Convert.ToInt64(txtCallID.Text)
                dr(0).Item("Completed") = IIf(rbtCompleted.Checked = True, 1, 0)
                dr(0).Item("ResponsDesc") = txtResponsDesc.Text
                dr(0).Item("ResponseDate_vc") = txtResponseDate_vc.Text
                dr(0).Item("ResponseTime_vc") = txtResponseTime_vc.Text
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDelete()
        Try
            Dim drDeletedRow() As DataRow = dtCallsFolowing.Select("CallFolowingID = '" + txtCallFolowingID.Text.Replace("'", "''") + "'")
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        ErrorProvider1.Clear()
        RequiredValidator = True
        If txtCallID.Text.Trim = "" Then
            RequiredValidator = False
            ErrorProvider1.SetError(txtCallID, "كد پيگيري نامشخص ميباشد")
        End If
        If txtResponsDesc.Text.Trim = "" Then
            RequiredValidator = False
            ErrorProvider1.SetError(txtResponsDesc, "شرح كار وارد نشده است")
        End If
        If txtResponseDate_vc.Value.Trim.Length <> 10 Then
            RequiredValidator = False
            ErrorProvider1.SetError(txtResponseDate_vc, "تاريخ به طور کامل وارد نشده است")
        ElseIf txtResponseDate_vc.Value > modPublicMethod.GetDateNow Then
            RequiredValidator = False
            ErrorProvider1.SetError(txtResponseDate_vc, "تاریخ نمی تواند بزرگتر از تاریخ روز جاری باشد")
        ElseIf txtResponseDate_vc.Value < CallDate Then
            RequiredValidator = False
            ErrorProvider1.SetError(txtResponseDate_vc, "تاریخ ثبت نمی تواند کوچکتر از تاریخ تماس باشد")
        End If
        If modPublicMethod.CheckTime(txtResponseTime_vc.Text) = False Then
            RequiredValidator = False
            ErrorProvider1.SetError(txtResponseTime_vc, "ساعت به طور کامل وارد نشده است و یا نامعتبر می باشد")
        End If
        If txtDescription.Enabled = True AndAlso txtDescription.Text = String.Empty Then
            RequiredValidator = False
            ErrorProvider1.SetError(txtDescription, "توضیحات وارد نشده است")
        End If
    End Function
    Private Function RequiredDBValidator() As Boolean
        Try
            Dim dt As New DataTable
            dt = Me.clsDalHelpDesk.GetByCallIDAndCompletedCallsFolowing(Convert.ToInt64(txtCallID.Text), 1)
            Select Case Me.clsMyControler.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    If dt.Rows.Count > 0 Then
                        Return False
                    Else
                        Return True
                    End If
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    If rbtCompleted.Checked = True Then
                        If dt.Rows.Count > 0 Then
                            If dt.Rows(0).Item("CallFolowingID") <> txtCallFolowingID.Text Then
                                Return False
                            Else
                                Return True
                            End If
                        Else
                            Return True
                        End If
                    Else
                        Return True
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.clsMyControler.DataGridView = Me.dgvCallsFolowing
        Me.clsMyControler.SetControlsValue(Rowindex)
    End Sub
    'Private Sub ChooseCulture(ByVal sender As Object)
    '    Dim CultureInfo As System.Globalization.CultureInfo
    '    Select Case sender.name.tolower
    '        Case "txtresDesc".ToLower
    '            CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
    '        Case Else
    '            CultureInfo = New System.Globalization.CultureInfo("en-US", False)
    '    End Select
    '    System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo)
    'End Sub
    Private Sub DoUpdateCallInfo()
        Try
            Dim dt As New DataTable
            dt = Me.clsDalHelpDesk.GetByCallIDAndCompletedCallsFolowing(Convert.ToInt64(txtCallID.Text), 1)
            If dt.Rows.Count > 0 Then
                Me.clsDalHelpDesk.UpdateCallsInfoForCompleted(Convert.ToInt64(txtCallID.Text), 1)
            Else
                Me.clsDalHelpDesk.UpdateCallsInfoForCompleted(Convert.ToInt64(txtCallID.Text), 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetPermissionForVisitors()
        Dim CLSUserLoginDA As New ClassUserLoginDataAccess(ConnectionString)
        Try

            CLSUserLoginDA.BeginProc()
            If CLSUserLoginDA.GetCountVisitorByUserID(ClassUserLoginDataAccess.ThisUser.UserID) > 0 Then
                rbtCompleted.Visible = False
                rbtNotCompleted.Visible = False
                btnResDesc.Visible = False

            Else
                rbtCompleted.Visible = True
                rbtNotCompleted.Visible = True
                btnResDesc.Visible = True
            End If
            CLSUserLoginDA.EndProc()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try


    End Sub
#End Region

#End Region




    
   
    Private Sub dgvCallsInfoNComp_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCallsInfoNComp.RowEnter
        Try
            clsDalHelpDesk.BeginProc()
            dtCallsFolowing.Clear()
            FillCallsFolowing(e.RowIndex, CallsInfoType.NotCompleted)
            dtCallsFolowing = clsDalHelpDesk.GetByCallIDCallsFolowing(dgvCallsInfoNComp.Rows(e.RowIndex).Cells("Callid").Value)
            CallDate = dgvCallsInfoNComp.Rows(e.RowIndex).Cells("CallDate_vc").Value().ToString
            dgvCallsFolowing.DataSource = dtCallsFolowing
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            clsDalHelpDesk.EndProc()
        End Try
    End Sub

    Private Sub dgvCallsInfoComp_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCallsInfoComp.RowEnter
        Try
            clsDalHelpDesk.BeginProc()
            dtCallsFolowing.Clear()
            FillCallsFolowing(e.RowIndex, CallsInfoType.Completed)
            dtCallsFolowing = clsDalHelpDesk.GetByCallIDCallsFolowing(dgvCallsInfoComp.Rows(e.RowIndex).Cells("Callid").Value)
            CallDate = dgvCallsInfoComp.Rows(e.RowIndex).Cells("CallDate_vc").Value().ToString
            dgvCallsFolowing.DataSource = dtCallsFolowing
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            clsDalHelpDesk.EndProc()
        End Try
    End Sub

    Private Sub ClearCallsFollowing()
        dtCallsFolowing.Clear()
        dgvCallsFolowing.DataSource = dtCallsFolowing

    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        ClearCallsFollowing()
        If TabControl1.SelectedIndex = 1 Then
            FillGridCallsInfoComp()
            InitGridCallsInfoComp()
            FillCallsFolowing(0, CallsInfoType.Completed)
            Me.clsMyControler.DataGridView = dgvCallsFolowing
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)

        ElseIf TabControl1.SelectedIndex = 0 Then
            FillGridCallsInfoNComp()
            InitGridCallsInfoNComp()
            FillCallsFolowing(0, CallsInfoType.NotCompleted)
            Me.clsMyControler.DataGridView = dgvCallsFolowing
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)

        End If

    End Sub

    Private Sub dgvCallsFolowing_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvCallsFolowing.RowsRemoved
        If dgvCallsFolowing.Rows.Count = 0 Then
            Empty()
        End If
    End Sub
    Private Sub Empty()
        txtCallFolowingID.Text = String.Empty
        txtCallID.Text = String.Empty
        txtResponseDate_vc.Text = String.Empty
        txtResponseTime_vc.Text = String.Empty
        txtResponsDesc.Text = String.Empty
        rbtCompleted.Checked = True
    End Sub
    Private Sub dgvCallsInfoNComp_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvCallsInfoNComp.RowsRemoved
        If dgvCallsInfoNComp.Rows.Count = 0 Then
            dtCallsFolowing.Clear()
            dgvCallsFolowing.DataSource = dtCallsFolowing
            Empty()
        End If
    End Sub

    Private Sub dgvCallsInfoComp_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvCallsInfoComp.RowsRemoved
        If dgvCallsInfoNComp.Rows.Count = 0 Then
            dtCallsFolowing.Clear()
            dgvCallsFolowing.DataSource = dtCallsFolowing
            Empty()
        End If
    End Sub

    Private Sub tbc_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        tbcSelecting(sender, e)
    End Sub
    Private Sub tbcSelecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
        If e.TabPageIndex = 1 Then
            If grpGrid.Enabled = False Then
                e.Cancel = True
            End If
        ElseIf e.TabPageIndex = 0 Then
            If grpGrid2.Enabled = False Then
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim _frm As New frmReprint
        _frm.FormtType = frmReprint.FormtTypeEnum.Print
        _frm.ShowDialog()
    End Sub

    Private Sub btnPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDF.Click
        Dim _frm As New frmReprint
        _frm.FormtType = frmReprint.FormtTypeEnum.PDF

        _frm.ShowDialog()
    End Sub
    Private Sub btnResDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResDesc.Click
        Try
            Dim _frm As New frmReqResDesc
            Select Case ReferTo
                Case ReferToEnum.fani
                    _frm.FType = frmReqResDesc.FormType.ResCartable_Fani
                Case ReferToEnum.bazaryabi
                    _frm.FType = frmReqResDesc.FormType.ResCartable_Bazaryabi
                Case ReferToEnum.bank
                    _frm.FType = frmReqResDesc.FormType.ResCartable_Bank
            End Select
            _frm.ShowDialog()
            txtResponsDesc.Text = _frm.ReqResDesc
            txtDescription.Text = String.Empty
            txtDescriptionEnable()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub rbtCompleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCompleted.CheckedChanged
        Try
            If rbtCompleted.Checked = False Then
                rbtNotCompleted.Checked = True
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
 
    Private Sub txtDescriptionEnable()
        Select Case txtResponsDesc.Text
            Case "تغيير آدرس"
                txtDescription.Enabled = True
            Case "تغيير شماره تلفن"
                txtDescription.Enabled = True
            Case "تغيير نام"
                txtDescription.Enabled = True
            Case "اصلاح نام فروشگاه"
                txtDescription.Enabled = True
            Case "توضيحات نماينده"
                txtDescription.Enabled = True
            Case Else
                txtDescription.Enabled = False
        End Select
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)

                If Me.TabControl1.SelectedTab.Name = Me.TabControl1.TabPages(Me.tbpCallsInfoComp.Name).Name Then
                    clsExcel.Write(Me.dgvCallsInfoComp)
                Else
                    clsExcel.Write(Me.dgvCallsInfoNComp)
                End If
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
End Class