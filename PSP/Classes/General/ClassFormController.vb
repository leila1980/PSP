Namespace RIZNARM.WINDOWS.FORMS
    Public Class ClassFormController

        Public Enum ButtonRole As Byte
            Add = 0
            Edit = 1
            Delete = 2
            Save = 3
            Cancel = 4
            Print = 5
            Find = 6
            Choose = 7
            Close = 8
        End Enum

        Public Enum FormState As Byte
            View = 0
            Add = 1
            Edit = 2
            Delete = 3
            Fault = 100
        End Enum

        Public Enum ControlProperty As Byte
            Text = 0
            SelectedValue = 1
            SelectedIndex = 2
            Checked = 3
            Image = 4
            None = 5
            Value = 6
        End Enum

        Public Enum ControlEnableProperty As Byte
            Enable = 0
            [ReadOnly] = 1
        End Enum

        Public Structure ValueControlTemplate
            Dim Control As Object
            Dim MappedColumn As String
            Dim ValueProperty As ControlProperty
            Dim EnableProperty As ControlEnableProperty
            Dim EnabledInViewState As Boolean
            Dim EnabledInAddState As Boolean
            Dim EnabledInEditState As Boolean
        End Structure

        Public Structure ButtonTemplate
            Dim Button As Object
            Dim Role As ButtonRole
            Dim ShortCut As String
            Dim e As Object
        End Structure

#Region "ClassButton"
        Private Class ClassButton
            Private _Button(-1) As ButtonTemplate

            Private Function Contains(ByVal Button As ButtonTemplate) As Boolean
                For i As Integer = 0 To Me._Button.Length - 1
                    If Me._Button(i).Button Is Button.Button Then
                        Return True
                    End If
                Next
                Return False
            End Function

            Private Function IndexOf(ByVal ButtonName As String) As Integer
                For i As Integer = 0 To Me._Button.Length - 1
                    If Me._Button(i).Button.Name = ButtonName Then
                        Return i
                    End If
                Next

                Return -1
            End Function

            Public Function IndexOfShortCut(ByVal ShortCut As String) As Integer()
                Dim res(-1) As Integer
                For i As Integer = 0 To Me._Button.Length - 1
                    If Me._Button(i).ShortCut = ShortCut Then
                        ReDim Preserve res(res.Length)
                        res(res.Length - 1) = i
                    End If
                Next

                Return res
            End Function

            Public Sub Add(ByVal Button As ButtonTemplate)
                If Me.Contains(Button) = False Then
                    ReDim Preserve Me._Button(Me._Button.Length)
                    Me._Button(Me._Button.Length - 1) = Button
                    Select Case Button.Role
                        Case ButtonRole.Add AndAlso String.IsNullOrEmpty(Button.Button.TooltipText)
                            Button.Button.TooltipText = Button.ShortCut + " " + "جدید"
                        Case ButtonRole.Cancel AndAlso String.IsNullOrEmpty(Button.Button.TooltipText)
                            Button.Button.TooltipText = Button.ShortCut + " " + "لغو"
                        Case ButtonRole.Choose AndAlso String.IsNullOrEmpty(Button.Button.TooltipText)
                            Button.Button.TooltipText = Button.ShortCut + " " + "انتخاب"
                        Case ButtonRole.Close AndAlso String.IsNullOrEmpty(Button.Button.TooltipText)
                            Button.Button.TooltipText = Button.ShortCut + " " + "بازگشت"
                        Case ButtonRole.Delete AndAlso String.IsNullOrEmpty(Button.Button.TooltipText)
                            Button.Button.TooltipText = Button.ShortCut + " " + "حذف"
                        Case ButtonRole.Edit AndAlso String.IsNullOrEmpty(Button.Button.TooltipText)
                            Button.Button.TooltipText = Button.ShortCut + " " + "ویرایش"
                        Case ButtonRole.Find AndAlso String.IsNullOrEmpty(Button.Button.TooltipText)
                            Button.Button.TooltipText = Button.ShortCut + " " + "جستجو"
                        Case ButtonRole.Print AndAlso String.IsNullOrEmpty(Button.Button.TooltipText)
                            Button.Button.TooltipText = Button.ShortCut + " " + "چاپ"
                        Case ButtonRole.Save AndAlso String.IsNullOrEmpty(Button.Button.TooltipText)
                            Button.Button.TooltipText = Button.ShortCut + " " + "ذخیره"
                    End Select
                End If
            End Sub

            Public Function GetRoleButtons(ByVal Role As ButtonRole) As ArrayList
                Dim btn As New ArrayList
                For i As Integer = 0 To Me._Button.Length - 1
                    If Me._Button(i).Role = Role Then
                        btn.Add(Me._Button(i))
                    End If
                Next
                Return btn
            End Function

            Public Sub Clear()
                ReDim Me._Button(0)
            End Sub

            Default Public Property Item(ByVal index As Integer) As ButtonTemplate
                Get
                    If index >= 0 AndAlso index < Me._Button.Length Then
                        Return Me._Button(index)
                    Else
                        Return Nothing
                    End If
                End Get
                Set(ByVal value As ButtonTemplate)
                    If index >= 0 AndAlso index < Me._Button.Length Then
                        Me._Button(index) = value
                    End If
                End Set
            End Property

        End Class
#End Region

#Region "ClassControl"
        Private Class ClassControl
            Private _Control(-1) As ValueControlTemplate

            Private Function Contains(ByVal Control As ValueControlTemplate) As Boolean
                For i As Integer = 0 To Me._Control.Length - 1
                    If Me._Control(i).Control Is Control.Control Then
                        Return True
                    End If
                Next
                Return False
            End Function

            Private Function IndexOf(ByVal ControlName As String) As Integer
                For i As Integer = 0 To Me._Control.Length - 1
                    If Me._Control(i).Control.Name = ControlName Then
                        Return i
                    End If
                Next

                Return -1
            End Function

            Public Sub ClearControlValue()
                For i As Integer = 0 To Me._Control.Length - 1
                    Select Case Me._Control(i).ValueProperty
                        Case ControlProperty.Text
                            Me._Control(i).Control.text = ""
                        Case ControlProperty.Value
                            Me._Control(i).Control.value = ""
                        Case ControlProperty.SelectedIndex
                            Me._Control(i).Control.SelectedIndex = -1
                        Case ControlProperty.SelectedValue
                            Me._Control(i).Control.SelectedIndex = -1
                        Case ControlProperty.Checked
                            Me._Control(i).Control.Checked = False
                        Case ControlProperty.Image
                            Me._Control(i).Control.image = Nothing
                    End Select
                Next
            End Sub

            Public Sub Add(ByVal Control As ValueControlTemplate)
                If Me.Contains(Control) = False Then
                    ReDim Preserve Me._Control(Me._Control.Length)
                    Me._Control(Me._Control.Length - 1) = Control
                End If
            End Sub

            Public Function GetColumnControls(ByVal ColumnName As String) As ArrayList
                Dim Control As New ArrayList
                For i As Integer = 0 To Me._Control.Length - 1
                    If Me._Control(i).MappedColumn = ColumnName Then
                        Control.Add(Me._Control(i))
                    End If
                Next
                Return Control
            End Function

            Public Function GetControls() As ArrayList
                Dim Control As New ArrayList
                For i As Integer = 0 To Me._Control.Length - 1
                    Control.Add(Me._Control(i).Control)
                Next
                Return Control
            End Function

            Public Function GetControlEnable(ByVal ControlName As String, ByVal State As ClassFormController.FormState) As Boolean
                Dim ControlLocation As Integer = Me.IndexOf(ControlName)
                If ControlLocation <> -1 Then
                    Select Case State
                        Case FormState.Add
                            Return Me._Control(ControlLocation).EnabledInAddState
                        Case FormState.Edit
                            Return Me._Control(ControlLocation).EnabledInEditState
                        Case FormState.View
                            Return Me._Control(ControlLocation).EnabledInViewState
                        Case Else
                            Return Me._Control(ControlLocation).EnabledInViewState
                    End Select
                End If
            End Function

            Public Sub Clear()
                ReDim Me._Control(0)
            End Sub

            Default Public Property Item(ByVal index As Integer) As ValueControlTemplate
                Get
                    If index >= 0 AndAlso index < Me._Control.Length Then
                        Return Me._Control(index)
                    Else
                        Return Nothing
                    End If
                End Get
                Set(ByVal value As ValueControlTemplate)
                    If index >= 0 AndAlso index < Me._Control.Length Then
                        Me._Control(index) = value
                    End If
                End Set
            End Property

            Public ReadOnly Property Count() As Integer
                Get
                    Return Me._Control.Length
                End Get
            End Property

        End Class
#End Region

#Region "Relations"

        Public Class ClassRelation
            Private _firstGroup As ClassFormController
            Private _sencondGroup As ClassFormController

            Private _DataFetchClass As Object
            Private _MethodName As String

            Private _MapColumn() As String
            Private _LastRow As DataGridViewRow

            Public Sub New(ByVal DataFetchClass As Object, ByVal MethodName As String, ByVal firstGroup As ClassFormController, ByVal secondGroup As ClassFormController, ByVal ParamArray MapColumn() As String)
                Me._MapColumn = MapColumn
                Me._firstGroup = firstGroup
                Me._sencondGroup = secondGroup
                If firstGroup.DataGridView IsNot Nothing Then
                    firstGroup.DataGridView.Tag = Me
                End If
                Me._DataFetchClass = DataFetchClass
                Me._MethodName = MethodName

                If Me._firstGroup.DataGridView IsNot Nothing Then
                    AddHandler Me._firstGroup.DataGridView.SelectionChanged, AddressOf GridRowChange
                    GridRowChange(Me._firstGroup.DataGridView, New EventArgs)
                End If
            End Sub

            Public Sub GridRowChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
                Try
                    If Me._sencondGroup Is Nothing OrElse Me._sencondGroup.DataGridView Is Nothing Then
                        Exit Sub
                    End If
                    If Me._firstGroup.DataGridView.SelectedRows.Count = 0 Then
                        Dim Parameter As New List(Of Object)
                        Parameter.Add(0)
                        Me._sencondGroup.DataGridView.DataSource = _DataFetchClass.GetType.GetMethod(Me._MethodName).Invoke(_DataFetchClass, Parameter.ToArray)
                        Exit Sub
                    End If
                    If Me._firstGroup.DataGridView.SelectedRows(0) Is _LastRow Then
                        ' Exit Sub
                    End If

                    _LastRow = Me._firstGroup.DataGridView.SelectedRows(0)
                    If Me._firstGroup.DataGridView.SelectedRows.Count = 0 Then
                        Me._sencondGroup.DataGridView.DataSource = Nothing
                    Else
                        Dim Parameter As New List(Of Object)
                        For i As Integer = 0 To _MapColumn.Length - 1
                            Parameter.Add(Me._firstGroup.DataGridView.SelectedRows(0).Cells(_MapColumn(i)).Value)
                        Next
                        Me._sencondGroup.DataGridView.DataSource = _DataFetchClass.GetType.GetMethod(Me._MethodName).Invoke(_DataFetchClass, Parameter.ToArray)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try
            End Sub

        End Class

#End Region

#Region "Permission"

        Public Structure PermissionTemplate
            Dim View As Boolean
            Dim Add As Boolean
            Dim Delete As Boolean
            Dim Edit As Boolean
            Dim Print As Boolean
        End Structure

        Private _UserPermission As PermissionTemplate

        Public ReadOnly Property UserPermision() As PermissionTemplate
            Get
                Return Me._UserPermission
            End Get
        End Property

        Public Property CanAdd() As Boolean
            Get
                Return Me._UserPermission.Add
            End Get
            Set(ByVal value As Boolean)
                Me._UserPermission.Add = value
            End Set
        End Property

        Public Property CanDelete() As Boolean
            Get
                Return Me._UserPermission.Delete
            End Get
            Set(ByVal value As Boolean)
                Me._UserPermission.Delete = value
            End Set
        End Property

        Public Property CanEdit() As Boolean
            Get
                Return Me._UserPermission.Edit
            End Get
            Set(ByVal value As Boolean)
                Me._UserPermission.Edit = value
            End Set
        End Property

        Public Property CanPrint() As Boolean
            Get
                Return Me._UserPermission.Print
            End Get
            Set(ByVal value As Boolean)
                Me._UserPermission.Print = value
            End Set
        End Property

        Public Property CanView() As Boolean
            Get
                Return Me._UserPermission.View
            End Get
            Set(ByVal value As Boolean)
                Me._UserPermission.View = value
            End Set
        End Property
#End Region

        Private _Buttons As New ClassButton
        Private _Controls As New ClassControl
        Private _DG As DataGridView
        Private _CurrentState As FormState
        Private _PreviousState As FormState
        Private _LockGridInAddState As Boolean = True
        Private _LockGridInEditState As Boolean = True
        Private _LockGridInViewState As Boolean = False
        Private _rowIndex As Integer = -1

        Public WriteOnly Property LockGridInAddState() As Boolean
            Set(ByVal value As Boolean)
                Me._LockGridInAddState = value
            End Set
        End Property

        Public WriteOnly Property LockGridInEditState() As Boolean
            Set(ByVal value As Boolean)
                Me._LockGridInEditState = value
            End Set
        End Property

        Public WriteOnly Property LockGridInViewState() As Boolean
            Set(ByVal value As Boolean)
                Me._LockGridInViewState = value
            End Set
        End Property

        Private Sub SetControlState(ByVal State As FormState)
            For i As Integer = 0 To Me._Controls.Count - 1
                Select Case Me._Controls.Item(i).EnableProperty
                    Case ControlEnableProperty.Enable
                        Me._Controls.Item(i).Control.Enabled = Me._Controls.GetControlEnable(Me._Controls.Item(i).Control.name, State)
                    Case ControlEnableProperty.ReadOnly
                        Me._Controls.Item(i).Control.ReadOnly = Not Me._Controls.GetControlEnable(Me._Controls.Item(i).Control.name, State)
                End Select
                Dim Parent As Object = Me._Controls(i).Control
                If TypeOf Parent Is Control Then
                    While Parent IsNot Nothing AndAlso Not (TypeOf Parent Is Form)
                        Parent = Parent.Parent
                    End While
                    If Parent IsNot Nothing Then
                        Dim dr() As DataRow = ClassUserLoginDataAccess.dtUserRightOnControls.Select("FormName = '" + Parent.Name + "' And ControlName_nvc = '" + Me._Controls.Item(i).Control.Name.ToString + "' And State_tint = " + Byte.Parse(State).ToString)
                        For j As Int32 = 0 To dr.Length - 1
                            Dim PropertyName() As String = dr(j).Item("Property_vc").ToString.Split(".")
                            Dim PropertyType As System.Type = Me._Controls.Item(i).Control.GetType
                            Dim Obj As Object = Me._Controls.Item(i).Control
                            Dim PropertyValue As Object

                            Dim value As Object = System.Convert.ChangeType(dr(j).Item("Value_vc"), Type.GetType("System.Boolean")) 'Type.GetType(dr(j).Item("DataType_vc")))

                            For k As Integer = 0 To PropertyName.Length - 1
                                If k < PropertyName.Length - 1 Then
                                    PropertyValue = PropertyType.GetProperty(PropertyName(k)).GetValue(Obj, Nothing)
                                    PropertyType = PropertyValue.GetType
                                    Obj = PropertyValue
                                Else
                                    PropertyType.GetProperty(PropertyName(k)).SetValue(Obj, value, Nothing)
                                End If
                            Next
                        Next
                    End If
                End If
            Next

        End Sub

        Private Sub SetButtonState(ByVal Role As ButtonRole, ByVal value As Boolean)
            Dim btn As New ArrayList
            btn = Me._Buttons.GetRoleButtons(Role)
            Dim Permission As Boolean = Me.GetRolePermission(Role)

            For i As Integer = 0 To btn.Count - 1
                btn(i).button.enabled = value And Permission
            Next
        End Sub

        Private Function GetRolePermission(ByVal Role As ButtonRole) As Boolean
            Select Case Role
                Case ButtonRole.Add
                    Return Me._UserPermission.Add
                Case ButtonRole.Delete
                    Return Me._UserPermission.Delete
                Case ButtonRole.Edit
                    Return Me._UserPermission.Edit
                Case ButtonRole.Print
                    Return Me._UserPermission.Print
                Case Else
                    Return True
            End Select
        End Function

        Private Sub GotoViewState()
            Dim btnState As Boolean = (Me._DG IsNot Nothing AndAlso Me._DG.RowCount > 0)
            SetButtonState(ButtonRole.Add, True)
            SetButtonState(ButtonRole.Edit, btnState)
            SetButtonState(ButtonRole.Cancel, False)
            SetButtonState(ButtonRole.Close, True)
            SetButtonState(ButtonRole.Delete, btnState)
            SetButtonState(ButtonRole.Find, btnState)
            SetButtonState(ButtonRole.Print, btnState)
            SetButtonState(ButtonRole.Save, False)
            SetButtonState(ButtonRole.Choose, btnState)
            If _DG IsNot Nothing Then
                Me._DG.Enabled = Not _LockGridInViewState
                If Me._DG.RowCount > 0 AndAlso (Me._DG.RowCount >= Me._rowIndex OrElse Me._DG.RowCount <= Me._rowIndex) AndAlso Me._rowIndex >= 0 Then
                    Me._DG.Rows(_rowIndex).Selected = True
                End If
                If _DG.Tag IsNot Nothing Then
                    DirectCast(Me._DG.Tag, ClassRelation).GridRowChange(Me._DG, New EventArgs)
                End If
            End If
        End Sub

        Private Sub GotoAddState()
            Me._Controls.ClearControlValue()
            SetButtonState(ButtonRole.Add, False)
            SetButtonState(ButtonRole.Edit, False)

            SetButtonState(ButtonRole.Close, False)
            SetButtonState(ButtonRole.Delete, False)
            SetButtonState(ButtonRole.Find, False)
            SetButtonState(ButtonRole.Print, False)
            SetButtonState(ButtonRole.Save, True)
            SetButtonState(ButtonRole.Choose, False)
            SetButtonState(ButtonRole.Cancel, True)
            If _DG IsNot Nothing Then
                Me._DG.Enabled = Not _LockGridInAddState
                If Me._DG.SelectedRows.Count > 0 Then
                    Me._rowIndex = Me._DG.SelectedRows(0).Index
                End If
                Me._DG.CurrentCell = Nothing
            End If
        End Sub

        Private Sub GotoEditState()
            SetButtonState(ButtonRole.Add, False)
            SetButtonState(ButtonRole.Edit, False)
            SetButtonState(ButtonRole.Cancel, True)
            SetButtonState(ButtonRole.Close, False)
            SetButtonState(ButtonRole.Delete, False)
            SetButtonState(ButtonRole.Find, False)
            SetButtonState(ButtonRole.Print, False)
            SetButtonState(ButtonRole.Save, True)
            SetButtonState(ButtonRole.Choose, False)
            If _DG IsNot Nothing Then
                Me._rowIndex = -1
                Me._DG.Enabled = Not _LockGridInEditState
            End If
        End Sub

        Private Sub GotoDeleteState()
            SetButtonState(ButtonRole.Add, False)
            SetButtonState(ButtonRole.Edit, False)
            SetButtonState(ButtonRole.Cancel, False)
            SetButtonState(ButtonRole.Close, False)
            SetButtonState(ButtonRole.Delete, False)
            SetButtonState(ButtonRole.Find, False)
            SetButtonState(ButtonRole.Print, False)
            SetButtonState(ButtonRole.Save, False)
            SetButtonState(ButtonRole.Choose, False)
            If _DG IsNot Nothing Then
                Me._rowIndex = -1
                Me._DG.Enabled = False
                If _DG.Tag IsNot Nothing Then
                    DirectCast(Me._DG.Tag, ClassRelation).GridRowChange(Me._DG, New EventArgs)
                End If
            End If
        End Sub

        Private Sub GotoFaultState()
            SetButtonState(ButtonRole.Add, False)
            SetButtonState(ButtonRole.Edit, False)
            SetButtonState(ButtonRole.Cancel, False)
            SetButtonState(ButtonRole.Close, True)
            SetButtonState(ButtonRole.Delete, False)
            SetButtonState(ButtonRole.Find, False)
            SetButtonState(ButtonRole.Print, False)
            SetButtonState(ButtonRole.Save, False)
            SetButtonState(ButtonRole.Choose, False)
        End Sub

        Public ReadOnly Property CurrentState() As FormState
            Get
                Return Me._CurrentState
            End Get
        End Property

        Public Property DataGridView() As DataGridView
            Get
                Return Me._DG
            End Get
            Set(ByVal value As DataGridView)
                Me._DG = value
            End Set
        End Property

        Public Sub AddButton(ByRef Button As ButtonTemplate)
            Me._Buttons.Add(Button)
        End Sub

        Public Sub AddControl(ByRef Control As ValueControlTemplate)
            Me._Controls.Add(Control)
        End Sub

        Public Sub GotoState(ByVal State As FormState)
            Me._PreviousState = Me._CurrentState
            Me._CurrentState = State

            Select Case State
                Case FormState.Add
                    Me.GotoAddState()
                Case FormState.Delete
                    Me.GotoDeleteState()
                Case FormState.Edit
                    Me.GotoEditState()
                Case FormState.View
                    Me.GotoViewState()
                Case FormState.Fault
                    Me.GotoFaultState()
            End Select

            Me.SetControlState(State)
        End Sub

        Public Sub SetControlsValue(ByVal rowindex As Integer)
            Dim row As DataGridViewRow = Me._DG.Rows(rowindex)
            For Each cel As DataGridViewCell In row.Cells
                Dim control As New ArrayList
                control = Me._Controls.GetColumnControls(Me._DG.Columns(cel.ColumnIndex).Name)
                For i As Integer = 0 To control.Count - 1
                    Dim c As ValueControlTemplate = control(i)
                    Select Case c.ValueProperty
                        Case ControlProperty.SelectedIndex
                            c.Control.SelectedIndex = cel.Value
                        Case ControlProperty.SelectedValue
                            c.Control.SelectedValue = cel.Value
                        Case ControlProperty.Text
                            If IsNothing(cel.Value) = True Then
                                c.Control.text = String.Empty
                            Else
                                c.Control.text = cel.Value.ToString()
                            End If
                        Case ControlProperty.Value
                            c.Control.value = cel.Value.ToString
                        Case ControlProperty.Checked
                            c.Control.checked = cel.Value
                        Case ControlProperty.Image
                            Dim buffer() As Byte = cel.Value
                            Dim memStream As New System.IO.MemoryStream(buffer)
                            c.Control.Image = System.Drawing.Image.FromStream(memStream)
                    End Select
                Next
            Next
        End Sub

        Public Sub SetControlsValue()
            Try
                Dim row As DataGridViewRow = Me._DG.CurrentRow
                For Each cel As DataGridViewCell In row.Cells
                    Dim control As New ArrayList
                    control = Me._Controls.GetColumnControls(Me._DG.Columns(cel.ColumnIndex).Name)
                    For i As Integer = 0 To control.Count - 1
                        Dim c As ValueControlTemplate = control(i)
                        Select Case c.ValueProperty
                            Case ControlProperty.SelectedIndex
                                c.Control.SelectedIndex = cel.Value
                            Case ControlProperty.SelectedValue
                                c.Control.SelectedValue = cel.Value
                                'Case ControlProperty.Text
                                '    c.Control.text = cel.Value.ToString
                                'Case ControlProperty.Value
                                '    c.Control.value = cel.Value
                            Case ControlProperty.Image
                                Dim buffer() As Byte = cel.Value
                                Dim memStream As New System.IO.MemoryStream(buffer)
                                c.Control.Image = System.Drawing.Image.FromStream(memStream)
                        End Select
                    Next
                Next
            Catch ex As Exception
                For i As Integer = 0 To Me._Controls.Count - 1
                    Dim c As ValueControlTemplate = Me._Controls.Item(i)
                    Select Case c.ValueProperty
                        Case ControlProperty.SelectedIndex
                            c.Control.SelectedIndex = -1
                        Case ControlProperty.SelectedValue
                            c.Control.SelectedValue = 0
                        Case ControlProperty.Text
                            c.Control.text = ""
                        Case ControlProperty.Value
                            c.Control.value = ""
                        Case ControlProperty.Image
                            c.Control.Image = Nothing
                    End Select
                Next
            End Try
        End Sub

        Public Sub New(ByRef DataGridView As DataGridView)
            Try
                Me._DG = DataGridView
                Me._CurrentState = FormState.View
                Me._UserPermission.Add = True
                Me._UserPermission.Delete = True
                Me._UserPermission.Edit = True
                Me._UserPermission.Print = True
                Me._UserPermission.View = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub New(ByRef DataGridView As DataGridView, ByVal Permission As PermissionTemplate)
            Try
                Me._DG = DataGridView
                Me._CurrentState = FormState.View

                Me._UserPermission = Permission
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub New(ByRef DataGridView As DataGridView _
                        , ByVal AddPermission As Boolean _
                        , ByVal DeletePermission As Boolean _
                        , ByVal EditPermission As Boolean _
                        , ByVal PrintPermission As Boolean)
            Try
                Me._DG = DataGridView
                Me._CurrentState = FormState.View

                Me._UserPermission.Add = AddPermission
                Me._UserPermission.Delete = DeletePermission
                Me._UserPermission.Edit = EditPermission
                Me._UserPermission.Print = PrintPermission
                Me._UserPermission.View = True
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub DoEvent(ByVal ShortCut As String)
            If ShortCut <> "" Then
                Dim ButtonIndex() As Integer = Me._Buttons.IndexOfShortCut(ShortCut)
                For Each i As Integer In ButtonIndex
                    If Me._Buttons(i).Button.enabled = True Then
                        Dim sender As Object = Me._Buttons(i)
                        Dim e As EventArgs = Nothing
                        CType(Me._Buttons(i).e, System.EventHandler).Invoke(sender, e)
                    End If
                Next
            End If
        End Sub

        Public Sub Key(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Dim PressedKey As String = ""
            Dim ctrl As Boolean = False
            e.Handled = True

            If e.Shift = True Then
                PressedKey += "Shift + "
                ctrl = True
            End If

            If e.Control = True Then
                PressedKey += "Ctrl + "
                ctrl = True
            End If

            If e.Alt = True Then
                PressedKey += "Alt + "
                ctrl = True
            End If

            If e.KeyCode = Keys.Delete Then
                PressedKey += "Delete + "
            End If

            If e.KeyCode = Keys.Insert Then
                PressedKey += "Insert + "
            End If

            If e.KeyCode = Keys.Escape Then
                PressedKey += "ESC + "
            End If

            Select Case e.KeyCode
                Case Keys.F1
                    PressedKey += "F1"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F2
                    PressedKey += "F2"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F3
                    PressedKey += "F3"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F4
                    PressedKey += "F4"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F5
                    PressedKey += "F5"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F6
                    PressedKey += "F6"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F7
                    PressedKey += "F7"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F8
                    PressedKey += "F8"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F9
                    PressedKey += "F9"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F10
                    PressedKey += "F10"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F11
                    PressedKey += "F11"
                    Me.DoEvent(PressedKey)
                    Return
                Case Keys.F12
                    PressedKey += "F12"
                    Me.DoEvent(PressedKey)
                    Return
            End Select


            If PressedKey <> "" Then
                Select Case e.KeyCode
                    Case Keys.A
                        PressedKey += "A"
                    Case Keys.B
                        PressedKey += "B"
                    Case Keys.C
                        PressedKey += "C"
                    Case Keys.D
                        PressedKey += "D"
                    Case Keys.E
                        PressedKey += "E"
                    Case Keys.F
                        PressedKey += "F"
                    Case Keys.G
                        PressedKey += "G"
                    Case Keys.H
                        PressedKey += "H"
                    Case Keys.I
                        PressedKey += "I"
                    Case Keys.J
                        PressedKey += "J"
                    Case Keys.K
                        PressedKey += "K"
                    Case Keys.L
                        PressedKey += "L"
                    Case Keys.M
                        PressedKey += "M"
                    Case Keys.N
                        PressedKey += "N"
                    Case Keys.O
                        PressedKey += "O"
                    Case Keys.P
                        PressedKey += "P"
                    Case Keys.Q
                        PressedKey += "Q"
                    Case Keys.R
                        PressedKey += "R"
                    Case Keys.S
                        PressedKey += "S"
                    Case Keys.T
                        PressedKey += "T"
                    Case Keys.U
                        PressedKey += "U"
                    Case Keys.V
                        PressedKey += "V"
                    Case Keys.W
                        PressedKey += "W"
                    Case Keys.X
                        PressedKey += "X"
                    Case Keys.Y
                        PressedKey += "Y"
                    Case Keys.Z
                        PressedKey += "Z"
                    Case Keys.NumPad0
                        PressedKey += "0"
                    Case Keys.NumPad1
                        PressedKey += "1"
                    Case Keys.NumPad2
                        PressedKey += "2"
                    Case Keys.NumPad3
                        PressedKey += "3"
                    Case Keys.NumPad4
                        PressedKey += "4"
                    Case Keys.NumPad5
                        PressedKey += "5"
                    Case Keys.NumPad6
                        PressedKey += "6"
                    Case Keys.NumPad7
                        PressedKey += "7"
                    Case Keys.NumPad8
                        PressedKey += "8"
                    Case Keys.NumPad9
                        PressedKey += "9"
                    Case Keys.D0
                        PressedKey += "0"
                    Case Keys.D1
                        PressedKey += "1"
                    Case Keys.D2
                        PressedKey += "2"
                    Case Keys.D3
                        PressedKey += "3"
                    Case Keys.D4
                        PressedKey += "4"
                    Case Keys.D5
                        PressedKey += "5"
                    Case Keys.D6
                        PressedKey += "6"
                    Case Keys.D7
                        PressedKey += "7"
                    Case Keys.D8
                        PressedKey += "8"
                    Case Keys.D9
                        PressedKey += "9"
                End Select
            End If

            If PressedKey.EndsWith(" + ") = True AndAlso ctrl = True Then
                PressedKey = ""
            ElseIf PressedKey.EndsWith(" + ") = True AndAlso ctrl = False Then
                PressedKey = PressedKey.Substring(0, PressedKey.Length - 3)
            End If

            If String.IsNullOrEmpty(PressedKey) = False Then
                Me.DoEvent(PressedKey)
            Else
                e.Handled = False
            End If
        End Sub
    End Class
End Namespace
