Imports System.Globalization

Public Class ReportUserControl_DateInterval
    Private pc As New PersianCalendar
    Private _CboIndex As SByte
    Private _SelectedDateTimedpDateFrom As String
    Private _SelectedDateTimedpDateTo As String

    'Private _SelectedDateTimetxtDateFrom As String
    'Private _SelectedDateTimetxtDateTo As String

    Event SelectedIndexChange()
    Event dpDateFromSelectedDateTimeChanged()
    Event dpDateToSelectedDateTimeChanged()
    Event txtDateFromValidating()
    Event txtDatetoValidating()

    Public Property GroupBoxText() As String
        Get
            Return GroupBox.Text
        End Get
        Set(ByVal value As String)
            GroupBox.Text = value
        End Set
    End Property
    Public Property SelectedDateTimedpDateFrom() As String
        Get
            Return _SelectedDateTimedpDateFrom
        End Get
        Set(ByVal value As String)
            _SelectedDateTimedpDateFrom = value
        End Set
    End Property
    Public Property SelectedDateTimedpDateTo() As String
        Get
            Return _SelectedDateTimedpDateTo
        End Get
        Set(ByVal value As String)
            _SelectedDateTimedpDateTo = value
        End Set
    End Property
    'Public Property SelectedDateTimetxtDateFrom() As String
    '    Get
    '        Return _SelectedDateTimedpDateFrom
    '    End Get
    '    Set(ByVal value As String)
    '        _SelectedDateTimedpDateFrom = value
    '    End Set
    'End Property
    'Public Property SelectedDateTimetxtDateTo() As String
    '    Get
    '        Return _SelectedDateTimetxtDateTo
    '    End Get
    '    Set(ByVal value As String)
    '        _SelectedDateTimetxtDateTo = value
    '    End Set
    'End Property
    Public Property SelectedIndex() As SByte
        Get
            Return _CboIndex
        End Get
        Set(ByVal value As SByte)
            _CboIndex = value
        End Set
    End Property
    Private Sub ReportUserControl2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Init()
    End Sub
    Private Sub Init()
        With Me.cboDate
            .Items.Add("همه")
            .Items.Add("انتخابی")
        End With
        If Me.cboDate.SelectedIndex = -1 Then Me.cboDate.SelectedIndex = 0 : Me._CboIndex = 0
        Me.dpDateFrom.Enabled = False
        Me.dpDateTo.Enabled = False
        Me.txtDateFrom.Enabled = False
        Me.txtDateTo.Enabled = False
        Me.lblDateFrom.Enabled = False
        Me.lblDateTo.Enabled = False

        AddHandler cboDate.SelectedIndexChanged, AddressOf cboDate_SelectedIndexChanged
        AddHandler dpDateFrom.SelectedDateTimeChanged, AddressOf dpDateFrom_SelectedDateTimeChanged
        AddHandler dpDateTo.SelectedDateTimeChanged, AddressOf dpDateTo_SelectedDateTimeChanged
    End Sub
    Private Sub cboDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case cboDate.SelectedIndex
            Case 0
                Me.dpDateFrom.Enabled = False
                Me.dpDateTo.Enabled = False
                Me.txtDateFrom.Enabled = False
                Me.txtDateTo.Enabled = False
                Me.lblDateFrom.Enabled = False
                Me.lblDateTo.Enabled = False
            Case 1
                Me.dpDateFrom.Enabled = True
                Me.dpDateTo.Enabled = True
                Me.txtDateFrom.Enabled = True
                Me.txtDateTo.Enabled = True
                Me.lblDateFrom.Enabled = True
                Me.lblDateTo.Enabled = True
        End Select
        Me._CboIndex = Me.cboDate.SelectedIndex
        RaiseEvent SelectedIndexChange()
    End Sub
    Private Sub dpDateFrom_SelectedDateTimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpDateFrom.SelectedDateTimeChanged
        Try
            Me.SelectedDateTimedpDateFrom = pc.GetYear(dpDateFrom.SelectedDateTime) & "/" & IIf(pc.GetMonth(dpDateFrom.SelectedDateTime).ToString.Length = 1, "0" & pc.GetMonth(dpDateFrom.SelectedDateTime), pc.GetMonth(dpDateFrom.SelectedDateTime)) & "/" & IIf(pc.GetDayOfMonth(dpDateFrom.SelectedDateTime).ToString.Length = 1, "0" & pc.GetDayOfMonth(dpDateFrom.SelectedDateTime), pc.GetDayOfMonth(dpDateFrom.SelectedDateTime))
        Catch
            Me.SelectedDateTimedpDateFrom = ""
        End Try
        RaiseEvent dpDateFromSelectedDateTimeChanged()
    End Sub
    Private Sub dpDateTo_SelectedDateTimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpDateTo.SelectedDateTimeChanged
        Try
            Me.SelectedDateTimedpDateTo = pc.GetYear(dpDateTo.SelectedDateTime) & "/" & IIf(pc.GetMonth(dpDateTo.SelectedDateTime).ToString.Length = 1, "0" & pc.GetMonth(dpDateTo.SelectedDateTime), pc.GetMonth(dpDateTo.SelectedDateTime)) & "/" & IIf(pc.GetDayOfMonth(dpDateTo.SelectedDateTime).ToString.Length = 1, "0" & pc.GetDayOfMonth(dpDateTo.SelectedDateTime), pc.GetDayOfMonth(dpDateTo.SelectedDateTime))

        Catch ex As Exception
            Me.SelectedDateTimedpDateTo = ""
        End Try
        RaiseEvent dpDateToSelectedDateTimeChanged()
    End Sub


    Private Sub txtDateFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDateFrom.Validating
        Try
            Me.SelectedDateTimedpDateFrom = txtDateFrom.Value
        Catch
            Me.SelectedDateTimedpDateFrom = ""
        End Try
        RaiseEvent txtDateFromValidating()
    End Sub

    Private Sub txtDateTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDateTo.Validating
        Try
            Me.SelectedDateTimedpDateTo = txtDateTo.Value
        Catch
            Me.SelectedDateTimedpDateTo = ""
        End Try
        RaiseEvent txtDatetoValidating()
    End Sub

    Private Sub txtDateTo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDateTo.Load

    End Sub
End Class
