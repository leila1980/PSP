Imports System.Threading
Public Class frmAgentPerformanceEdit

#Region "Global Member"
    Dim MyDAL As New Eniac.PSP.DAL.AgentPerformanceClass
    Dim MyStructure As New Eniac.PSP.Structure.AgentPerformanceStructure
    Dim _dtGrid As DataTable
    Dim _Mode As Utility.FormMode
    Dim _Id As Integer

#End Region
#Region "Sub"
    Private Sub SetForm()

        If _Mode = Utility.FormMode.AddNew Then
            Me.Text = "جدید"
            Me.CmbDate.Text = ""

        ElseIf _Mode = Utility.FormMode.Update Then

            Me.Text = "ویرایش"
            Me.btnSaveAndContinue.Text = "ذخیره"
            Me.btnSaveAndExit.Visible = False
            ToolStripSeparator1.Visible = False

            Dim drCurrent As DataRow()
            drCurrent = _dtGrid.Select(" AgentPerformanceId = " & _Id)

            If drCurrent.Length > 0 Then
                Me.cmbAgent.SelectedValue = drCurrent(0)("AgentId")
                Me.cmbState.SelectedValue = drCurrent(0)("StateId")
                Me.txtConfirmedNumber.Text = drCurrent(0)("ConfirmedNumber")
                Me.txtCompletedContractNumber.Text = drCurrent(0)("CompletedContractNumber")
                Me.CmbDate.Text = drCurrent(0)("ReportDate")

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

        MyStructure.ConfirmedNumber = Me.txtConfirmedNumber.Text
        MyStructure.CompletedContractNumber = Me.txtCompletedContractNumber.Text
        MyStructure.ReportDate = Me.CmbDate.Text
        MyStructure.StateId = Me.cmbState.SelectedValue
        MyStructure.AgentId = Me.cmbAgent.SelectedValue

        If _Mode = Utility.FormMode.AddNew Then

            Dim LastInsertedIdentity As Integer
            LastInsertedIdentity = MyDAL.InsertAndReturnLastInsertedIdentity(MyStructure)
            Dim dr As DataRow
            dr = _dtGrid.NewRow
            dr("AgentPerformanceId") = LastInsertedIdentity
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

            dr = _dtGrid.Select("AgentPerformanceId = " & _Id)

            If dr.Length > 0 Then
                SetDataRow(dr(0))
            End If

            _dtGrid.AcceptChanges()
            Me.Close()


        End If

    End Sub
    Private Sub SetDataRow(ByVal dr As DataRow)

        dr("ConfirmedNumber") = Me.txtConfirmedNumber.Text
        dr("CompletedContractNumber") = Me.txtCompletedContractNumber.Text
        dr("ReportDate") = Me.CmbDate.Text
        dr("StateId") = Me.cmbState.SelectedValue
        dr("AgentId") = Me.cmbAgent.SelectedValue
        dr("StateName") = Me.cmbState.Text
        dr("AgentName") = Me.cmbAgent.Text

    End Sub
    Private Sub ClearForm()

        Me.txtConfirmedNumber.Text = ""
        Me.txtCompletedContractNumber.Text = ""
        Me.CmbDate.Text = ""
        Me.cmbState.SelectedIndex = -1
        Me.cmbAgent.SelectedIndex = -1
        Me.cmbState.Focus()


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

        If Me.txtCompletedContractNumber.Text = "" Then
            MessageBox.Show("تعداد قرارداد کامل را وارد کنید")
            Exit Function
        End If

        If Me.txtConfirmedNumber.Text = "" Then
            MessageBox.Show("تعداد منعقده را وارد کنید")
            Exit Function
        End If

        If Me.CmbDate.Text = "" Or Me.CmbDate.Text.Contains("م") Then
            MessageBox.Show("تاریخ را مشخص کنید")
            Exit Function
        End If


        IsValidForm = True

    End Function

#End Region
#Region "Function"

#End Region
#Region "Events"

    Private Sub frmAgentPerformanceEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("fa-IR")

        LoadCombo()
        SetForm()

    End Sub
    Private Sub Tsb_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsb_Cancel.Click
        Me.Close()
    End Sub
    Private Sub TextBoxes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
Handles txtCompletedContractNumber.KeyPress, txtConfirmedNumber.KeyPress

        If Char.IsDigit(e.KeyChar) = False And Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 13 Then
            e.Handled = True
        End If

        If Asc(e.KeyChar) = 13 Then
            Me.btnSaveAndContinue.PerformClick()
        End If

    End Sub
    Private Sub CmbDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbDate.KeyPress
        e.Handled = True
    End Sub


#End Region


End Class
