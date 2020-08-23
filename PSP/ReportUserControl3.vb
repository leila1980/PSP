Public Class ReportUserControl3
    Private _CboIndex As SByte
    Private _txtFirst As String
    Private _txtSecond As String
    Event SelectedIndexChange()
    Event TextBoxFirstTextChanged()
    Event TextBoxSecondTextChanged()
    Public Property TextBoxFirst() As String
        Get
            Return _txtFirst
        End Get
        Set(ByVal value As String)
            _txtFirst = value
        End Set
    End Property
    Public Property TextBoxSecond() As String
        Get
            Return _txtSecond
        End Get
        Set(ByVal value As String)
            _txtSecond = value
        End Set
    End Property
    Public Property SelectedIndex() As SByte
        Get
            Return _CboIndex
        End Get
        Set(ByVal value As SByte)
            _CboIndex = value
        End Set
    End Property
    Private Sub ReportUserControl3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Init()
    End Sub
    Private Sub Init()
        With Me.cboFilterType
            .Items.Add("همه")
            .Items.Add("کمتر از")
            .Items.Add("بیشتر از")
            .Items.Add("مساوی")
            .Items.Add("ما بین")
        End With
        If Me.cboFilterType.SelectedIndex = -1 Then Me.cboFilterType.SelectedIndex = 0 : Me._CboIndex = 0
        Me.MytxtFirst.Enabled = False
        Me.MytxtSecond.Enabled = False
        Me.lblBetween.Enabled = False
        AddHandler MytxtFirst.TextChanged, AddressOf txtFirst_TextChanged
        AddHandler MytxtSecond.TextChanged, AddressOf txtSecond_TextChanged
        AddHandler cboFilterType.SelectedIndexChanged, AddressOf cboFilterType_SelectedIndexChanged
    End Sub
    Private Sub cboFilterType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case Me.cboFilterType.SelectedIndex
            Case 0
                If Me.MytxtFirst.Enabled = True Then Me.MytxtFirst.Enabled = False
                If Me.MytxtSecond.Enabled = True Then Me.MytxtSecond.Enabled = False
                If Me.lblBetween.Enabled = True Then Me.lblBetween.Enabled = False
                Me._CboIndex = Me.cboFilterType.SelectedIndex
                If Me.MytxtFirst.Text.Length > 0 Then Me._txtFirst = "" : Me.MytxtFirst.Text = ""
                If Me.MytxtSecond.Text.Length > 0 Then Me._txtSecond = "" : Me.MytxtSecond.Text = ""
                RaiseEvent SelectedIndexChange()
            Case 1
                If Me.MytxtFirst.Enabled = False Then Me.MytxtFirst.Enabled = True
                If Me.MytxtSecond.Enabled = True Then Me.MytxtSecond.Enabled = False
                If Me.lblBetween.Enabled = True Then Me.lblBetween.Enabled = False
                Me._CboIndex = Me.cboFilterType.SelectedIndex
                If Me.MytxtSecond.Text.Length > 0 Then Me._txtSecond = "" : Me.MytxtSecond.Text = ""
                RaiseEvent SelectedIndexChange()
            Case 2
                If Me.MytxtFirst.Enabled = False Then Me.MytxtFirst.Enabled = True
                If Me.MytxtSecond.Enabled = True Then Me.MytxtSecond.Enabled = False
                If Me.lblBetween.Enabled = True Then Me.lblBetween.Enabled = False
                Me._CboIndex = Me.cboFilterType.SelectedIndex
                If Me.MytxtSecond.Text.Length > 0 Then Me._txtSecond = "" : Me.MytxtSecond.Text = ""
                RaiseEvent SelectedIndexChange()
            Case 3
                If Me.MytxtFirst.Enabled = False Then Me.MytxtFirst.Enabled = True
                If Me.MytxtSecond.Enabled = True Then Me.MytxtSecond.Enabled = False
                If Me.lblBetween.Enabled = True Then Me.lblBetween.Enabled = False
                Me._CboIndex = Me.cboFilterType.SelectedIndex
                If Me.MytxtSecond.Text.Length > 0 Then Me._txtSecond = "" : Me.MytxtSecond.Text = ""
                RaiseEvent SelectedIndexChange()
            Case 4
                If Me.MytxtFirst.Enabled = False Then Me.MytxtFirst.Enabled = True
                If Me.MytxtSecond.Enabled = False Then Me.MytxtSecond.Enabled = True
                If Me.lblBetween.Enabled = False Then Me.lblBetween.Enabled = True
                Me._CboIndex = Me.cboFilterType.SelectedIndex
                RaiseEvent SelectedIndexChange()

        End Select
        MytxtFirst.Focus()
        MytxtFirst.SelectAll()
    End Sub
    Private Sub txtFirst_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me._txtFirst = Me.MytxtFirst.Text.Trim
        RaiseEvent TextBoxFirstTextChanged()
    End Sub
    Private Sub txtSecond_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me._txtSecond = Me.MytxtSecond.Text.Trim
        RaiseEvent TextBoxSecondTextChanged()
    End Sub
    Private Sub MytxtFirst_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MytxtFirst.Enter
        Me.MytxtFirst.SelectAll()
    End Sub
    Private Sub MytxtSecond_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MytxtSecond.Enter
        Me.MytxtSecond.SelectAll()
    End Sub
End Class
