Public Class frmAddress
    Private clsMyControler As RIZNARM.WINDOWS.FORMS.ClassFormController
    Private clsDalAddress As New ClassDalAddress(modPublicMethod.ConnectionString)
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private dtVisitor As New DataTable
    Private _AddressID As Int32
    Private _Code As String
    Private _ACode As String
    Private _Names As String
    Private _Priority As Integer
    Public _AddsressDescription As String
    Public _AddressValue As String
    Private dtAddress As New DataTable
    Private dic As New Dictionary(Of Int16, Int16)
    Private Ctrldic As New Dictionary(Of ComboBox, CheckBox)
    Private dataviewPerfixOne As DataView
    Private dataviewPerfixTwo As DataView
    Private checkCheckBox As Boolean = False


#Region "Property"
    Public Property AddressId() As Int32
        Get
            Return _AddressID
        End Get
        Set(ByVal value As Int32)
            _AddressID = value
        End Set
    End Property
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
        End Set
    End Property
    Public Property ACode() As String
        Get
            Return _ACode
        End Get
        Set(ByVal value As String)
            _ACode = value
        End Set
    End Property
    Public Property Names() As String
        Get
            Return _Names
        End Get
        Set(ByVal value As String)
            _Names = value
        End Set
    End Property
    Public Property Priority() As Integer
        Get
            Return _Priority
        End Get
        Set(ByVal value As Integer)
            _Priority = value
        End Set
    End Property
    Enum MyEnum As Short
        perfixOne = 1
        perfixTwo = 2
    End Enum

#End Region
#Region "Events"
    Private Sub frmAddress_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
    Private Sub frmAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            InitialForms()
            FormLoad()
            If Not String.IsNullOrEmpty(ACode) Then
                dtAddress = clsDalAddress.ConvertAddressCodeToDescription(ACode)
                fillcomboAddress()
                btnAdd.Enabled = False
                Me.btnAdd.Size = New System.Drawing.Size(1, 1)

            End If
        Catch ex As Exception
            ClassError.LogError(ex)
            ShowErrorMessage(ex.Message)
            Me.Close()
        Finally
            modPublicMethod.ErrorProviderClear(ErrorProvider)
        End Try
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Addresslink(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
        ableComBo({ComboPerfix1_1, ComboPerfix2_1, ComboPerfix3_1, ComboPerfix4_1, ComboPerfix5_1, ComboPerfix6_1})
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged, CheckBox5.CheckedChanged, CheckBox4.CheckedChanged, CheckBox3.CheckedChanged, CheckBox2.CheckedChanged, CheckBox1.CheckedChanged
        Dim chk As CheckBox = CType(sender, CheckBox)

        If chk.Checked Then
            ChangedAble(chk, True)
        Else
            ChangedAble(chk, False)
        End If

    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Addresslink(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
        ableComBo({ComboPerfix1_1, ComboPerfix2_1, ComboPerfix3_1, ComboPerfix4_1, ComboPerfix5_1, ComboPerfix6_1})
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Addresslink(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If ((ComboPerfix1_2.SelectedIndex >= 0) And Not String.IsNullOrEmpty(TextBox1.Text)) And ((ComboPerfix2_2.SelectedIndex >= 0) And Not String.IsNullOrEmpty(TextBox2.Text)) Then
            If ValidateKeyword({TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6}) Then
                If MsgBox("استفاده از کلمات پیشوندی" & vbCrLf & " آیا میخواهید ثبت شود", MsgBoxStyle.YesNo, "هشدار") = MsgBoxResult.Yes Then
                    If Save() Then
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    End If
                End If
            Else
                If Save() Then
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End If
            End If
        Else
            ErrorProvider.SetError(Label13, modApplicationMessage.msgForceToFill)
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Cancel()
            Close()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ShowErrorMessage(modApplicationMessage.msgAddFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.T And e.Modifiers = Keys.Shift Then
            e.Handled = False
        End If
    End Sub
    Private Sub frmAddress_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed


        If String.IsNullOrEmpty(TextBox1.Text) Then
            ComboPerfix1_1.SelectedIndex = -1
            ComboPerfix1_2.SelectedIndex = -1
        End If


        If String.IsNullOrEmpty(TextBox2.Text) Then
            ComboPerfix2_1.SelectedIndex = -1
            ComboPerfix2_2.SelectedIndex = -1
        End If


        If String.IsNullOrEmpty(TextBox3.Text) Then
            ComboPerfix3_1.SelectedIndex = -1
            ComboPerfix3_2.SelectedIndex = -1
        End If


        If String.IsNullOrEmpty(TextBox4.Text) Then
            ComboPerfix4_1.SelectedIndex = -1
            ComboPerfix4_2.SelectedIndex = -1
        End If


        If String.IsNullOrEmpty(TextBox5.Text) Then
            ComboPerfix5_1.SelectedIndex = -1
            ComboPerfix5_2.SelectedIndex = -1
        End If


        If String.IsNullOrEmpty(TextBox6.Text) Then
            ComboPerfix6_1.SelectedIndex = -1
            ComboPerfix6_2.SelectedIndex = -1
        End If

    End Sub
    Private Sub ComboPerfix1_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPerfix1_2.SelectedIndexChanged
        'رعایت اولویت
        Dim tmp As String = Nothing
        If dic.Count > 0 Then
            If String.IsNullOrEmpty(ComboPerfix1_2.SelectedValue) Then
                Exit Sub
            End If
            FillComboPriority(ComboPerfix2_2, dic.Item(Convert.ToInt16(ComboPerfix1_2.SelectedValue)))
            TextBox2.Text = String.Empty
        End If
    End Sub
    Private Sub ComboPerfix2_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPerfix2_2.SelectedIndexChanged
        '  عدم پر کردن فیلدهای قبلی 
        If String.IsNullOrEmpty(ComboPerfix1_2.SelectedValue) Then
            ErrorProvider.SetError(ComboPerfix2_2, modApplicationMessage.msgInvalidSelection)
            ComboPerfix2_2.SelectedIndex = -1
        Else
            'رعایت اولویت
            If dic.Count > 0 Then
                If String.IsNullOrEmpty(ComboPerfix2_2.SelectedValue) Then
                    Exit Sub
                End If
                FillComboPriority(ComboPerfix3_2, dic.Item(Convert.ToInt16(ComboPerfix2_2.SelectedValue)))
                TextBox3.Text = String.Empty
            End If
        End If
    End Sub
    Private Sub ComboPerfix3_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPerfix3_2.SelectedIndexChanged
        'عدم پر کردن فیلدهای قبلی 
        If String.IsNullOrEmpty(ComboPerfix2_2.SelectedValue) Then
            ErrorProvider.SetError(ComboPerfix3_2, modApplicationMessage.msgInvalidSelection)
            ComboPerfix3_2.SelectedIndex = -1
        Else
            'رعایت اولویت
            If dic.Count > 0 Then
                If String.IsNullOrEmpty(ComboPerfix3_2.SelectedValue) Then
                    Exit Sub
                End If
                FillComboPriority(ComboPerfix4_2, dic.Item(Convert.ToInt16(ComboPerfix3_2.SelectedValue)))
                TextBox4.Text = String.Empty
            End If
        End If
    End Sub
    Private Sub ComboPerfix4_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPerfix4_2.SelectedIndexChanged
        'عدم پر کردن فیلدهای قبلی 
        If String.IsNullOrEmpty(ComboPerfix3_2.SelectedValue) Then
            ErrorProvider.SetError(ComboPerfix4_2, modApplicationMessage.msgInvalidSelection)
            ComboPerfix4_2.SelectedIndex = -1
        Else
            'رعایت اولویت
            If dic.Count > 0 Then
                If String.IsNullOrEmpty(ComboPerfix4_2.SelectedValue) Then
                    Exit Sub
                End If
                FillComboPriority(ComboPerfix5_2, dic.Item(Convert.ToInt16(ComboPerfix4_2.SelectedValue)))
                TextBox5.Text = String.Empty
            End If
        End If

    End Sub
    Private Sub ComboPerfix5_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPerfix5_2.SelectedIndexChanged
        'عدم پر کردن فیلدهای قبلی 
        If String.IsNullOrEmpty(ComboPerfix4_2.SelectedValue) Then
            ErrorProvider.SetError(ComboPerfix5_2, modApplicationMessage.msgInvalidSelection)
            ComboPerfix5_2.SelectedIndex = -1
        Else
            Dim tmp As String = Nothing
            'رعایت اولویت
            If dic.Count > 0 Then
                If String.IsNullOrEmpty(ComboPerfix5_2.SelectedValue) Then
                    Exit Sub
                End If
                FillComboPriority(ComboPerfix6_2, dic.Item(Convert.ToInt16(ComboPerfix5_2.SelectedValue)))
                TextBox6.Text = String.Empty
            End If
        End If

    End Sub
    Private Sub ComboPerfix6_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPerfix6_2.SelectedIndexChanged
        'عدم پر کردن فیلدهای قبلی 
        If String.IsNullOrEmpty(ComboPerfix5_2.SelectedValue) Then
            ErrorProvider.SetError(ComboPerfix6_2, modApplicationMessage.msgInvalidSelection)
            ComboPerfix6_2.SelectedIndex = -1
        End If
    End Sub

#End Region
#Region "Methods"
    Public Sub New(ByVal parentForm As frmContractingparty_Contract_Account_Store_Device)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        clsMyControler = New RIZNARM.WINDOWS.FORMS.ClassFormController(parentForm.dgvStore, False, True, True, True)
    End Sub
    Private Sub InitialForms()
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
        saveButton.Button = btnSelect
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

        Dim address1_1 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address1_1.Control = ComboPerfix1_1
        address1_1.EnabledInAddState = True
        address1_1.EnabledInEditState = True
        address1_1.EnabledInViewState = False
        address1_1.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address1_1)

        Dim address1_2 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address1_2.Control = ComboPerfix1_2
        address1_2.EnabledInAddState = True
        address1_2.EnabledInEditState = True
        address1_2.EnabledInViewState = False
        address1_2.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address1_2)

        Dim address2_1 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address2_1.Control = ComboPerfix2_1
        address2_1.EnabledInAddState = True
        address2_1.EnabledInEditState = True
        address2_1.EnabledInViewState = False
        address2_1.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address2_1)

        Dim address2_2 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address2_2.Control = ComboPerfix2_2
        address2_2.EnabledInAddState = True
        address2_2.EnabledInEditState = True
        address2_2.EnabledInViewState = False
        address2_2.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address2_2)

        Dim address3_1 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address3_1.Control = ComboPerfix3_1
        address3_1.EnabledInAddState = True

        address3_1.EnabledInEditState = True
        address3_1.EnabledInViewState = False
        address3_1.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address3_1)


        Dim address3_2 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address3_2.Control = ComboPerfix3_2
        address3_2.EnabledInAddState = True

        address3_2.EnabledInEditState = True
        address3_2.EnabledInViewState = False
        address3_2.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address3_2)

        Dim address4_1 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address4_1.Control = ComboPerfix4_1
        address4_1.EnabledInAddState = True

        address4_1.EnabledInEditState = True
        address4_1.EnabledInViewState = False
        address4_1.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address4_1)

        Dim address4_2 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address4_2.Control = ComboPerfix4_2
        address4_2.EnabledInAddState = True

        address4_2.EnabledInEditState = True
        address4_2.EnabledInViewState = False
        address4_2.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address4_2)

        Dim address5_1 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address5_1.Control = ComboPerfix5_1
        address5_1.EnabledInAddState = True

        address5_1.EnabledInEditState = True
        address5_1.EnabledInViewState = False
        address5_1.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address5_1)

        Dim address5_2 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address5_2.Control = ComboPerfix5_2
        address5_2.EnabledInAddState = True

        address5_2.EnabledInEditState = True
        address5_2.EnabledInViewState = False
        address5_2.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address5_2)

        Dim address6_1 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address6_1.Control = ComboPerfix6_1
        address6_1.EnabledInAddState = True

        address6_1.EnabledInEditState = True
        address6_1.EnabledInViewState = False
        address6_1.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address6_1)

        Dim address6_2 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        address6_2.Control = ComboPerfix6_2
        address6_2.EnabledInAddState = True

        address6_2.EnabledInEditState = True
        address6_2.EnabledInViewState = False
        address6_2.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        Me.clsMyControler.AddControl(address6_2)


        Dim AddressOne As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AddressOne.Control = TextBox1
        AddressOne.EnabledInAddState = True

        AddressOne.EnabledInEditState = True
        AddressOne.EnabledInViewState = False
        AddressOne.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(AddressOne)

        Dim AddressTwo As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AddressTwo.Control = TextBox2
        AddressTwo.EnabledInAddState = True

        AddressTwo.EnabledInEditState = True
        AddressTwo.EnabledInViewState = False
        AddressTwo.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(AddressTwo)

        Dim AddressThree As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AddressThree.Control = TextBox3
        AddressThree.EnabledInAddState = True

        AddressThree.EnabledInEditState = True
        AddressThree.EnabledInViewState = False
        AddressThree.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(AddressThree)

        Dim AddressFour As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AddressFour.Control = TextBox4
        AddressFour.EnabledInAddState = True

        AddressFour.EnabledInEditState = True
        AddressFour.EnabledInViewState = False
        AddressFour.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(AddressFour)

        Dim AddressFive As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AddressFive.Control = TextBox5
        AddressFive.EnabledInAddState = True

        AddressFive.EnabledInEditState = True
        AddressFive.EnabledInViewState = False
        AddressFive.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(AddressFive)

        Dim AddressSix As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AddressSix.Control = TextBox6
        AddressSix.EnabledInAddState = True

        AddressSix.EnabledInEditState = True
        AddressSix.EnabledInViewState = False
        AddressSix.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(AddressSix)

        Dim chkone As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        chkone.Control = CheckBox1
        chkone.EnabledInAddState = True

        chkone.EnabledInEditState = True
        chkone.EnabledInViewState = False
        chkone.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(chkone)


        Dim chktwo As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        chktwo.Control = CheckBox2
        chktwo.EnabledInAddState = True

        chktwo.EnabledInEditState = True
        chktwo.EnabledInViewState = False
        chktwo.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(chktwo)

        Dim chkthree As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        chkthree.Control = CheckBox3
        chkthree.EnabledInAddState = True

        chkthree.EnabledInEditState = True
        chkthree.EnabledInViewState = False
        chkthree.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(chkthree)

        Dim chkfour As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        chkfour.Control = CheckBox4
        chkfour.EnabledInAddState = True

        chkfour.EnabledInEditState = True
        chkfour.EnabledInViewState = False
        chkfour.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(chkfour)

        Dim chkfive As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        chkfive.Control = CheckBox5
        chkfive.EnabledInAddState = True

        chkfive.EnabledInEditState = True
        chkfive.EnabledInViewState = False
        chkfive.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(chkfive)

        Dim chksix As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        chksix.Control = CheckBox6
        chksix.EnabledInAddState = True

        chksix.EnabledInEditState = True
        chksix.EnabledInViewState = False
        chksix.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        Me.clsMyControler.AddControl(chksix)

        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        tsAmain.Enabled = True
    End Sub
    Private Sub FormLoad()
        Try
            FillAllCombo()
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillAllCombo()
        FillComboPerfix({ComboPerfix1_1, ComboPerfix2_1, ComboPerfix3_1, ComboPerfix4_1, ComboPerfix5_1, ComboPerfix6_1}, MyEnum.perfixOne)
        FillComboPerfix({ComboPerfix1_2, ComboPerfix2_2, ComboPerfix3_2, ComboPerfix4_2, ComboPerfix5_2, ComboPerfix6_2}, MyEnum.perfixTwo)
        Priorities()
        fillCtrldic()
    End Sub
    Private Sub FillComboPerfix(ByVal controls() As ComboBox, ByVal perfix As MyEnum)
        Dim src As DataTable
        Try
            Me.clsDalAddress.BeginProc()
            src = clsDalAddress.GetAddressForPrefix(perfix)
            For Each cnrl As ComboBox In controls
                cnrl.DisplayMember = "name_nvc"
                cnrl.ValueMember = "code_nvc"
                cnrl.DataSource = src.Copy
                cnrl.SelectedIndex = -1
            Next
        Catch ex As Exception
            Throw ex
        Finally
            Select Case perfix
                Case MyEnum.perfixOne
                    dataviewPerfixOne = New DataView(src)
                Case MyEnum.perfixTwo
                    dataviewPerfixTwo = New DataView(src)
            End Select
            Me.clsDalAddress.EndProc()
        End Try
    End Sub
    Private Sub FillComboPriority(ByVal ctrl As ComboBox, ByVal priority As Integer)
        Try
            Me.clsDalAddress.BeginProc()
            Dim dt As DataTable = clsDalAddress.GetAddressForPrefix(MyEnum.perfixTwo, priority)
            ctrl.DisplayMember = "name_nvc"
            ctrl.ValueMember = "code_nvc"
            ctrl.DataSource = dt.Copy
            ctrl.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalAddress.EndProc()
        End Try
    End Sub
    Private Sub Priorities()
        Try
            Me.clsDalAddress.BeginProc()
            Dim src As DataTable = clsDalAddress.GetAddressForPrefix(MyEnum.perfixTwo)

            For Each row As DataRow In src.Rows
                dic.Add(Convert.ToInt16(row(1)), Convert.ToInt16(row(2)))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Function Save()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        _AddsressDescription = Nothing
        _AddressValue = Nothing
        Names = Nothing
        Code = Nothing
        Dim result As Boolean = False
        Try
           
            '   Select Case clsMyControler.CurrentState
            '      Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
            For Each item As String In RequiredValidator()
                If Not String.IsNullOrEmpty(item) Then
                    _AddsressDescription += item.Trim.Substring(0, item.IndexOf("&")) & "،"
                    _AddressValue += item.Trim.Substring(item.IndexOf("&")) & "،"
                Else
                    Exit For
                End If
            Next

            If (Not String.IsNullOrEmpty(_AddsressDescription)) And Not checkCheckBox Then
                Names = _AddsressDescription.Substring(0, _AddsressDescription.Length - 1)
                Code = _AddressValue.Substring(1, _AddressValue.Length - 2)
                result = True
                Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            Else
                MessageBox.Show("بروز مشکل در عملیات ذخیره سازی ")
                result = False
            End If
            Return result
            '  End Select
        Catch ex As Exception
            ClassError.LogError(ex)
        
        End Try
    End Function
    Private Function ValidateKeyword(ByVal ctrl() As TextBox)
        Dim res As Boolean = False
        ErrorProvider.Clear()
        For Each c As TextBox In ctrl
            If Not String.IsNullOrEmpty(c.Text) Then
                dataviewPerfixOne.RowFilter = Nothing
                dataviewPerfixOne.RowFilter = "NAME_NVC = '" + c.Text.Trim + "'"
                dataviewPerfixTwo.RowFilter = "NAME_NVC ='" + c.Text.Trim + "'"
                If dataviewPerfixOne.Count > 0 Or dataviewPerfixTwo.Count > 0 Then
                    ErrorProvider.SetError(c, modApplicationMessage.msgInvalidKeyword)
                    res = True
                End If
            End If
        Next
        dataviewPerfixOne.RowFilter = Nothing
        dataviewPerfixTwo.RowFilter = Nothing
        Return res
    End Function

    Private Function RequiredValidator() As List(Of String)
        Dim res As New List(Of String)
        checkCheckBox = False
        Try
            If (ComboPerfix1_2.SelectedIndex >= 0) And Not String.IsNullOrEmpty(TextBox1.Text) Then
                If CheckBox1.Checked Then
                    If ComboPerfix1_1.SelectedIndex >= 0 Then
                        res.Add(ComboPerfix1_1.SelectedItem.Row.ItemArray(0).ToString & Space(1) & ComboPerfix1_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox1.Text.Trim & "&" & ComboPerfix1_1.SelectedValue.ToString & "&" & ComboPerfix1_2.SelectedValue.ToString & "&" & TextBox1.Text.Trim)
                    Else
                        checkCheckBox = True
                        ErrorProvider.SetError(ComboPerfix1_1, modApplicationMessage.msgErrorToFill)
                    End If
                Else
                    res.Add(ComboPerfix1_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox1.Text.Trim & "&" & ComboPerfix1_2.SelectedValue.ToString & "&" & TextBox1.Text.Trim)
                End If
            End If

            If (ComboPerfix2_2.SelectedIndex >= 0) And Not String.IsNullOrEmpty(TextBox2.Text) Then
                If CheckBox2.Checked Then
                    If ComboPerfix2_1.SelectedIndex >= 0 Then
                        res.Add(ComboPerfix2_1.SelectedItem.Row.ItemArray(0).ToString & Space(1) & ComboPerfix2_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox2.Text.Trim & "&" & ComboPerfix2_1.SelectedValue.ToString & "&" & ComboPerfix2_2.SelectedValue.ToString & "&" & TextBox2.Text.Trim)
                    Else
                        checkCheckBox = True
                        ErrorProvider.SetError(ComboPerfix2_1, modApplicationMessage.msgErrorToFill)
                    End If
                Else
                    res.Add(ComboPerfix2_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox2.Text.Trim & "&" & ComboPerfix2_2.SelectedValue.ToString & "&" & TextBox2.Text.Trim)
                End If
            End If

            If (ComboPerfix3_2.SelectedIndex >= 0) And Not String.IsNullOrEmpty(TextBox3.Text) Then
                If CheckBox3.Checked Then
                    If ComboPerfix3_1.SelectedIndex >= 0 Then
                        res.Add(ComboPerfix3_1.SelectedItem.Row.ItemArray(0).ToString & Space(1) & ComboPerfix3_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox3.Text.Trim & "&" & ComboPerfix3_1.SelectedValue.ToString & "&" & ComboPerfix3_2.SelectedValue.ToString & "&" & TextBox3.Text.Trim)
                    Else
                        checkCheckBox = True
                        ErrorProvider.SetError(ComboPerfix3_1, modApplicationMessage.msgErrorToFill)
                    End If
                Else
                    res.Add(ComboPerfix3_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox3.Text.Trim & "&" & ComboPerfix3_2.SelectedValue.ToString & "&" & TextBox3.Text.Trim)
                End If
            End If

            If (ComboPerfix4_2.SelectedIndex >= 0) And Not String.IsNullOrEmpty(TextBox4.Text) Then
                If CheckBox4.Checked Then
                    If ComboPerfix4_1.SelectedIndex >= 0 Then
                        res.Add(ComboPerfix4_1.SelectedItem.Row.ItemArray(0).ToString & Space(1) & ComboPerfix4_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox4.Text.Trim & "&" & ComboPerfix4_1.SelectedValue.ToString & "&" & ComboPerfix4_2.SelectedValue.ToString & "&" & TextBox4.Text.Trim)
                    Else
                        checkCheckBox = True
                        ErrorProvider.SetError(ComboPerfix4_1, modApplicationMessage.msgErrorToFill)
                    End If
                Else
                    res.Add(ComboPerfix4_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox4.Text.Trim & "&" & ComboPerfix4_2.SelectedValue.ToString & "&" & TextBox4.Text.Trim)
                End If
            End If

            If (ComboPerfix5_2.SelectedIndex >= 0) And Not String.IsNullOrEmpty(TextBox5.Text) Then
                If CheckBox5.Checked Then
                    If ComboPerfix5_1.SelectedIndex >= 0 Then
                        res.Add(ComboPerfix5_1.SelectedItem.Row.ItemArray(0).ToString & Space(1) & ComboPerfix5_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox5.Text.Trim & "&" & ComboPerfix5_1.SelectedValue.ToString & "&" & ComboPerfix5_2.SelectedValue.ToString & "&" & TextBox5.Text.Trim)
                    Else
                        checkCheckBox = True
                        ErrorProvider.SetError(ComboPerfix5_1, modApplicationMessage.msgErrorToFill)
                    End If
                Else
                    res.Add(ComboPerfix5_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox5.Text.Trim & "&" & ComboPerfix5_2.SelectedValue.ToString & "&" & TextBox5.Text.Trim)
                End If
            End If

            If (ComboPerfix6_2.SelectedIndex >= 0) And Not String.IsNullOrEmpty(TextBox6.Text) Then
                If CheckBox6.Checked Then
                    If ComboPerfix6_1.SelectedIndex >= 0 Then
                        res.Add(ComboPerfix6_1.SelectedItem.Row.ItemArray(0).ToString & Space(1) & ComboPerfix6_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox6.Text.Trim & "&" & ComboPerfix6_1.SelectedValue.ToString & "&" & ComboPerfix6_2.SelectedValue.ToString & "&" & TextBox6.Text.Trim)
                    Else
                        checkCheckBox = True
                        ErrorProvider.SetError(ComboPerfix6_1, modApplicationMessage.msgErrorToFill)
                    End If
                Else
                    res.Add(ComboPerfix6_2.SelectedItem.Row.ItemArray(0).ToString & Space(1) & TextBox6.Text.Trim & "&" & ComboPerfix6_2.SelectedValue.ToString & "&" & TextBox6.Text.Trim)
                End If
            End If
            Return res
        Catch ex As Exception
        End Try
    End Function
    Private Sub Addresslink(ByVal formState As RIZNARM.WINDOWS.FORMS.ClassFormController.FormState)
        clsMyControler.GotoState(formState)
    End Sub
    Private Sub fillcomboAddress()
        For i As Integer = 0 To dtAddress.Rows.Count - 1

            Select Case i
                Case 0
                    ComboPerfix1_1.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), -1, dtAddress.Rows(i)(0).ToString))
                    ComboPerfix1_2.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(0).ToString, dtAddress.Rows(i)(1).ToString))
                    TextBox1.Text = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(1).ToString, dtAddress.Rows(i)(2).ToString))
                Case 1
                    ComboPerfix2_1.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), -1, dtAddress.Rows(i)(0).ToString))
                    ComboPerfix2_2.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(0).ToString, dtAddress.Rows(i)(1).ToString))
                    TextBox2.Text = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(1).ToString, dtAddress.Rows(i)(2).ToString))
                Case 2
                    ComboPerfix3_1.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), -1, dtAddress.Rows(i)(0).ToString))
                    ComboPerfix3_2.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(0).ToString, dtAddress.Rows(i)(1).ToString))
                    TextBox3.Text = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(1).ToString, dtAddress.Rows(i)(2).ToString))
                Case 3
                    ComboPerfix4_1.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), -1, dtAddress.Rows(i)(0).ToString))
                    ComboPerfix4_2.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(0).ToString, dtAddress.Rows(i)(1).ToString))
                    TextBox4.Text = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(1).ToString, dtAddress.Rows(i)(2).ToString))
                Case 4
                    ComboPerfix5_1.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), -1, dtAddress.Rows(i)(0).ToString))
                    ComboPerfix5_2.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(0).ToString, dtAddress.Rows(i)(1).ToString))
                    TextBox5.Text = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(1).ToString, dtAddress.Rows(i)(2).ToString))
                Case 5
                    ComboPerfix6_1.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), -1, dtAddress.Rows(i)(0).ToString))
                    ComboPerfix6_2.SelectedValue = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(0).ToString, dtAddress.Rows(i)(1).ToString))
                    TextBox6.Text = (IIf(String.IsNullOrEmpty(dtAddress.Rows(i)(2).ToString), dtAddress.Rows(i)(1).ToString, dtAddress.Rows(i)(2).ToString))
            End Select
        Next
    End Sub
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
    End Sub
    Private Sub fillCtrldic()
        Ctrldic.Add(ComboPerfix1_1, CheckBox1)
        Ctrldic.Add(ComboPerfix2_1, CheckBox2)
        Ctrldic.Add(ComboPerfix3_1, CheckBox3)
        Ctrldic.Add(ComboPerfix4_1, CheckBox4)
        Ctrldic.Add(ComboPerfix5_1, CheckBox5)
        Ctrldic.Add(ComboPerfix6_1, CheckBox6)
    End Sub
    Private Sub ChangedAble(ByVal ctrl As Control, ByVal able As Boolean)
        Dim res As ComboBox = (From x In Ctrldic Where x.Value.Name = ctrl.Name Select x.Key).FirstOrDefault
        res.Enabled = able
    End Sub
    Private Sub ableComBo(ByVal control() As Control)
        For Each ctrl As ComboBox In control
            If ctrl.SelectedValue <= 0 Then
                ctrl.Enabled = False
            Else
                Ctrldic.Item(ctrl).Checked = True
            End If
        Next
    End Sub

#End Region
  
  
End Class