Imports System.Threading
Public Class frmDeviceCancelDescEdit

#Region "Global Member"
    Dim MyDAL As New Eniac.PSP.DAL.DeviceCancelDesc
    Dim MyStructure As New Eniac.PSP.Structure.DeviceCancelDesc
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
            Me.btnSave.Text = "ذخیره"
            Dim drCurrent As DataRow()
            drCurrent = _dtGrid.Select("DeviceCancelDescId = " & _Id)

            If drCurrent.Length > 0 Then
                Me.txtDesc.Text = drCurrent(0)("DeviceCancelDesc")
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
   
    Private Sub Save(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnSave.Click

        If IsValidForm() = False Then
            Exit Sub
        End If

        MyStructure.DeviceCancelDesc = Me.txtDesc.Text

        If _Mode = Utility.FormMode.AddNew Then

            Dim LastInsertedIdentity As Integer
            LastInsertedIdentity = MyDAL.InsertAndReturnLastInsertedIdentity(MyStructure)
            Dim dr As DataRow
            dr = _dtGrid.NewRow
            dr("DeviceCancelDescId") = LastInsertedIdentity
            SetDataRow(dr)
            _dtGrid.Rows.Add(dr)

            _dtGrid.AcceptChanges()
            ClearForm()

        ElseIf _Mode = Utility.FormMode.Update Then

            MyDAL.Update(MyStructure, _Id)
            Dim dr() As DataRow

            dr = _dtGrid.Select("DeviceCancelDescId = " & _Id)

            If dr.Length > 0 Then
                SetDataRow(dr(0))
            End If

            _dtGrid.AcceptChanges()
            Me.Close()

        End If

    End Sub
    Private Sub SetDataRow(ByVal dr As DataRow)

        dr("DeviceCancelDesc") = Me.txtDesc.Text

    End Sub
    Private Sub ClearForm()

        Me.txtDesc.Text = ""
       
    End Sub
    Private Function IsValidForm() As Boolean

        IsValidForm = False

        If Me.txtDesc.Text = "" Then
            MessageBox.Show("شرح را وارد نمایید")
            Exit Function
        End If

        IsValidForm = True

    End Function

#End Region

#Region "Events"

    Private Sub frmAgentPerformanceEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("fa-IR")
        SetForm()

    End Sub
    Private Sub Tsb_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsb_Cancel.Click
        Me.Close()
    End Sub

#End Region

End Class