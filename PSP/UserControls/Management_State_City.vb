Public Class Management_State_City
    Private clsDALState As New ClassDALState(modPublicMethod.ConnectionString)
    Private clsDALCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private clsDALManagement As New ClassDALManagement(modPublicMethod.ConnectionString)

    Private _StateID As String = ""
    Private _CityID As String = ""
    Private _ManagementID As String = ""

    Event StateID_SelectedIndexChanged()
    Event CityID_SelectedIndexChanged()
    Event ManagementID_SelectedIndexChanged()

    Public Property StateID() As String
        Get
            Return _StateID
        End Get
        Set(ByVal value As String)
            _StateID = value
        End Set
    End Property
    Public Property CityID() As String
        Get
            Return _CityID
        End Get
        Set(ByVal value As String)
            _CityID = value
        End Set
    End Property
    Public Property ManagementID() As String
        Get
            Return _ManagementID
        End Get
        Set(ByVal value As String)
            _ManagementID = value
        End Set
    End Property

    Private Sub Management_State_City_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillcboStateID()
        FillcboCityID()
        FillcboManagement()

        AddHandler cboStateID.SelectedIndexChanged, AddressOf cboStateID_SelectedIndexChanged
        AddHandler cboCityID.SelectedIndexChanged, AddressOf cboCityID_SelectedIndexChanged
        AddHandler cboManagement.SelectedIndexChanged, AddressOf cboManagement_SelectedIndexChanged
    End Sub
    Private Sub FillcboStateID()
        Try
            Me.clsDALState.BeginProc()
            cboStateID.DisplayMember = "Name_nvc"
            cboStateID.ValueMember = "StateID"
            Me.cboStateID.DataSource = clsDALState.GetAllStateForUCtrl_ExcludeUser
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALState.EndProc()
        End Try
    End Sub
    Private Sub FillcboCityID()
        Try
            Me.clsDALCity.BeginProc()
            If cboStateID.SelectedIndex = -1 Then
                clsDALCity.StateID = "-1"
            Else
                clsDALCity.StateID = cboStateID.SelectedValue
            End If
            Me.cboCityID.DisplayMember = "Name_nvc"
            Me.cboCityID.ValueMember = "CityID"
            Me.cboCityID.DataSource = clsDALCity.GetByStateIDForUCtrl
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALCity.EndProc()
        End Try
    End Sub
    Private Sub FillcboManagement()
        Try
            Me.clsDALManagement.BeginProc()
            If cboStateID.SelectedIndex = -1 Then
                clsDALManagement.StateID = "-1"
            Else
                clsDALManagement.StateID = cboStateID.SelectedValue
            End If
            Me.cboManagement.DisplayMember = "Name_nvc"
            Me.cboManagement.ValueMember = "ManagementID"
            Me.cboManagement.DataSource = clsDALManagement.GetByStateIDForUCtrl
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALManagement.EndProc()
        End Try
    End Sub

    Private Sub cboStateID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FillcboCityID()
            FillcboManagement()
            Me.StateID = Me.cboStateID.SelectedValue
            RaiseEvent StateID_SelectedIndexChanged()
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
    End Sub
    Private Sub cboCityID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.cboCityID.SelectedIndex = 0 Then
                Me.CityID = String.Empty
            Else
                Me.CityID = Me.cboCityID.SelectedValue
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
        RaiseEvent CityID_SelectedIndexChanged()
    End Sub
    Private Sub cboManagement_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.cboManagement.SelectedIndex = 0 Then
                Me.ManagementID = String.Empty
            Else
                Me.ManagementID = Me.cboManagement.SelectedValue
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
        RaiseEvent ManagementID_SelectedIndexChanged()
    End Sub

End Class
