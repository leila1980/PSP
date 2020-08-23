Public Class Timing
    Private _Value As String
    Private _ValueInMin As Int32

    Public ReadOnly Property Value() As String
        Get
            If String.IsNullOrEmpty(Hour) = False And String.IsNullOrEmpty(Min) = False Then
                _Value = Me.Hour & ":" & Me.Min
            ElseIf String.IsNullOrEmpty(Hour) = True And String.IsNullOrEmpty(Min) = False Then
                _Value = "00:" & Me.Min
            ElseIf String.IsNullOrEmpty(Hour) = False And String.IsNullOrEmpty(Min) = True Then
                _Value = Me.Hour & ":00"
            ElseIf String.IsNullOrEmpty(Hour) = True And String.IsNullOrEmpty(Min) = True Then
                _Value = String.Empty
            End If
            Return _Value
        End Get
    End Property
    Public ReadOnly Property ValueInMin() As Int32
        Get
            If String.IsNullOrEmpty(Hour) = False And String.IsNullOrEmpty(Min) = False Then
                _ValueInMin = Me.Hour * 60 + Me.Min
            ElseIf String.IsNullOrEmpty(Hour) = True And String.IsNullOrEmpty(Min) = False Then
                _ValueInMin = Me.Min
            ElseIf String.IsNullOrEmpty(Hour) = False And String.IsNullOrEmpty(Min) = True Then
                _ValueInMin = Me.Hour * 60
            ElseIf String.IsNullOrEmpty(Hour) = True And String.IsNullOrEmpty(Min) = True Then
                _ValueInMin = -1
            End If
            Return _ValueInMin
        End Get
    End Property
    Public Property Hour() As String
        Get

            Return txtHour.Text.Trim

        End Get
        Set(ByVal value As String)
            txtHour.Text = value
        End Set
    End Property
    Public Property Min() As String
        Get

            Return txtMin.Text.Trim


        End Get
        Set(ByVal value As String)
            txtMin.Text = value
        End Set
    End Property
    Private Sub txtHour_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHour.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMin.Focus()
        End If
    End Sub
    Private Sub txtMin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMin.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtHour.Focus()
        End If
    End Sub
End Class
