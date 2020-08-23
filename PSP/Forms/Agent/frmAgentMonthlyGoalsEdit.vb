Public Class frmAgentMonthlyGoalsEdit


#Region "Global Member"
    Dim MyDAL As New Eniac.PSP.DAL.AgentMonthlyGoalsClass
    Dim MyStructure As New Eniac.PSP.Structure.AgentMonthlyGoalsStructure
    Dim _dtGrid As DataTable
    Dim _Mode As Utility.FormMode
    Dim _Id As Integer

#End Region
#Region "Sub"
    Private Sub SetForm()

        If _Mode = Utility.FormMode.AddNew Then
            Me.Text = "جدید"

        ElseIf _Mode = Utility.FormMode.Update Then

            Me.Text = "ویرایش"
            Me.btnSaveAndContinue.Text = "ذخیره"
            Me.btnSaveAndExit.Visible = False
            ToolStripSeparator1.Visible = False

            Dim drCurrent As DataRow()
            drCurrent = _dtGrid.Select(" AgentMonthlyGoalsID = " & _Id)

            If drCurrent.Length > 0 Then
                Me.cmbAgent.SelectedValue = drCurrent(0)("AgentId")
                Me.cmbState.SelectedValue = drCurrent(0)("StateId")
                Me.txtFirst.Text = drCurrent(0)("FirstMonthPromise")
                Me.txtSecond.Text = drCurrent(0)("SecondMonthPromise")
                Me.txtThird.Text = drCurrent(0)("ThirdMonthPromise")
            End If

        End If
    End Sub
    Public Sub New(ByRef DtGrid As DataTable)

        InitializeComponent()
        _dtGrid = DtGrid
        _Mode = Utility.FormMode.AddNew

    End Sub
    Public Sub New(ByRef dtGrid As DataTable, ByVal ID As Integer)
        InitializeComponent()
        _dtGrid = dtGrid
        _Mode = Utility.FormMode.Update
        _Id = ID
    End Sub
    Private Sub LoadCombo()

        Me.cmbState.DataSource = MyDAL.SelectState
        Me.cmbState.DisplayMember = "Name"
        Me.cmbState.ValueMember = "Id"

        Me.cmbAgent.DataSource = MyDAL.SelectVisitor
        Me.cmbAgent.DisplayMember = "Name"
        Me.cmbAgent.ValueMember = "Id"

    End Sub
    Private Sub Save(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnSaveAndContinue.Click, btnSaveAndExit.Click

        If IsValidForm() = False Then
            Exit Sub
        End If

        MyStructure.FirstMonthPromise = Me.txtFirst.Text
        MyStructure.SecondMonthPromise = Me.txtSecond.Text
        MyStructure.ThirdMonthPromise = Me.txtThird.Text
        MyStructure.StateId = Me.cmbState.SelectedValue
        MyStructure.AgentId = Me.cmbAgent.SelectedValue

        If _Mode = Utility.FormMode.AddNew Then

            Dim LastInsertedIdentity As Integer
            LastInsertedIdentity = MyDAL.InsertAndReturnLastInsertedIdentity(MyStructure)
            Dim dr As DataRow
            dr = _dtGrid.NewRow
            dr("AgentMonthlyGoalsID") = LastInsertedIdentity
            SetDataRow(dr)
            _dtGrid.Rows.Add(dr)

            _dtGrid.AcceptChanges()

            If sender.Name = "btnSaveAndExit" Then
                Me.Close()
            ElseIf sender.Name = "btnSaveAndContinue" Then
                ClearForm()
            End If

        ElseIf _Mode = Utility.FormMode.Update Then

            MyDAL.Update(MyStructure, _Id)
            Dim dr() As DataRow

            dr = _dtGrid.Select("AgentMonthlyGoalsID = " & _Id)

            If dr.Length > 0 Then
                SetDataRow(dr(0))
            End If

            _dtGrid.AcceptChanges()
            Me.Close()

        End If

    End Sub
    Private Sub SetDataRow(ByVal dr As DataRow)

        dr("FirstMonthPromise") = Me.txtFirst.Text
        dr("SecondMonthPromise") = Me.txtSecond.Text
        dr("ThirdMonthPromise") = Me.txtThird.Text
        dr("StateId") = Me.cmbState.SelectedValue
        dr("AgentId") = Me.cmbAgent.SelectedValue
        dr("StateName") = Me.cmbState.Text
        dr("AgentName") = Me.cmbAgent.Text

    End Sub
    Private Sub ClearForm()

        Me.txtFirst.Text = ""
        Me.txtSecond.Text = ""
        Me.txtThird.Text = ""
        Me.cmbState.SelectedIndex = -1
        Me.cmbAgent.SelectedIndex = -1
        cmbState.Focus()

    End Sub
    Private Function IsValidForm() As Boolean

        IsValidForm = False

        If Me.cmbState.SelectedIndex = -1 Then
            MessageBox.Show("استان را مشخص کنید")
            Exit Function
        End If

        If Me.cmbAgent.SelectedIndex = -1 Then
            MessageBox.Show("نماینده را مشخص کنید")
            Exit Function
        End If

        If Me.txtFirst.Text = "" Then
            MessageBox.Show("تعهد ماه اول را مشخص کنید")
            Exit Function
        End If

        If Me.txtSecond.Text = "" Then
            MessageBox.Show("تعهد ماه دوم را مشخص کنید")
            Exit Function
        End If

        If Me.txtThird.Text = "" Then
            MessageBox.Show("تعهد ماه سوم را مشخص کنید")
            Exit Function
        End If

        IsValidForm = True

    End Function

#End Region
#Region "Function"

#End Region
#Region "Events"

    Private Sub frmAgentMonthlyGoalsDisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadCombo()
        SetForm()

    End Sub
    Private Sub Tsb_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsb_Cancel.Click
        Me.Close()
    End Sub
    Private Sub TextBoxes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtFirst.KeyPress, txtSecond.KeyPress, txtThird.KeyPress

        If Char.IsDigit(e.KeyChar) = False And Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 13 Then
            e.Handled = True
        End If

        If Asc(e.KeyChar) = 13 Then
            Me.btnSaveAndContinue.PerformClick()
        End If

    End Sub


#End Region

End Class
