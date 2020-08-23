Imports System.Windows.Forms

Public Class frmInputBox

    Private m_DoNotAcceptEmptyString As Boolean
    Private m_AllowMultiLineInputs As Boolean

    Public Property DoNotAcceptEmptyString() As Boolean
        Get
            Return m_DoNotAcceptEmptyString
        End Get
        Set(ByVal value As Boolean)
            m_DoNotAcceptEmptyString = value
        End Set
    End Property

    Public Property AllowMultiLineInputs() As Boolean
        Get
            Return m_AllowMultiLineInputs
        End Get
        Set(ByVal value As Boolean)
            m_AllowMultiLineInputs = value
        End Set
    End Property

    Public ReadOnly Property Value() As String
        Get
            Return txtValue.Text
        End Get
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If m_DoNotAcceptEmptyString AndAlso txtValue.Text = "" Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
            Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.GotFocus
        txtValue.SelectAll()
    End Sub

    Public Shared Function ShowForm(Optional ByVal Prompt As String = "", Optional ByVal Title As String = "", Optional ByVal DefaultValue As String = "", Optional ByVal DoNotAcceptEmptyString As Boolean = True, Optional ByVal AllowMultiLineInput As Boolean = False) As String

        Dim frm As New frmInputBox

        With frm
            If Title = "" Then Title = My.Application.Info.Title.ToString
            .Text = Title
            .lblPrompt.Text = Prompt
            .txtValue.Text = DefaultValue
            .DoNotAcceptEmptyString = DoNotAcceptEmptyString
            .AllowMultiLineInputs = AllowMultiLineInput
            If AllowMultiLineInput Then
                .txtValue.Height = .txtValue.Height * 4
                .Height = .txtValue.Height + .txtValue.Top + .TableLayoutPanel1.Top + .TableLayoutPanel1.Height + 60
                .txtValue.Multiline = True
            End If
            If .ShowDialog() = DialogResult.OK Then
                Return .Value
            Else
                Return Nothing
            End If
        End With

    End Function

End Class
