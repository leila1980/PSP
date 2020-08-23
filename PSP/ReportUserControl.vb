Public Class ReportUserControl1
    'Dim cnn As String = "Data Source=netsysserver\sql2005;Initial Catalog=pspmaskanbank;Persist Security Info=True;User ID=soheili;Password=sa123123;Connection Timeout=5"
    'Private clsDALState As New ClassDALState(cnn)
    'Private clsDALCity As New ClassDALCity(cnn)
    'Private clsDALAria As New ClassDALContract(cnn)
    Private clsDALState As New ClassDALState(modPublicMethod.ConnectionString)
    Private clsDALCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private clsDALAria As New ClassDALContract(modPublicMethod.ConnectionString)

    Private _StateID As String = ""
    Private _CityID As String = ""
    Private _AriaID As String = -1
    Event StateID_SelectedIndexChanged()
    Event CityID_SelectedIndexChanged()
    Event AriaID_SelectedIndexChanged()
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
    Public Property AriaID() As String
        Get
            Return _AriaID
        End Get
        Set(ByVal value As String)
            _AriaID = value
        End Set
    End Property
    Private Sub ReportUserControl1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillcboStateID()
        FillcboCityID()
        FillcboAria()
        AddHandler cboStateID.SelectedIndexChanged, AddressOf cboStateID_SelectedIndexChanged
        AddHandler cboCityID.SelectedIndexChanged, AddressOf cboCityID_SelectedIndexChanged
        AddHandler cboAria.SelectedIndexChanged, AddressOf cboAria_SelectedIndexChanged
    End Sub
    Private Sub FillcboStateID()
        Try
            Me.clsDALState.BeginProc()
            cboStateID.DisplayMember = "Name_nvc"
            cboStateID.ValueMember = "StateID"
            Me.cboStateID.DataSource = clsDALState.GetAllForUCtrl
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
    Private Sub FillcboAria()
        Try
            Me.clsDALAria.BeginProc()
            If cboCityID.SelectedIndex = -1 Then
                clsDALAria.CityID = "-1"
            Else
                clsDALAria.CityID = cboCityID.SelectedValue
            End If
            Me.cboAria.DisplayMember = "MunicipalAreaNO_sint"
            Me.cboAria.ValueMember = "MunicipalAreaNO_sint"
            Me.cboAria.DataSource = clsDALAria.GetAllAria(clsDALAria.CityID)
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALAria.EndProc()
        End Try
    End Sub
    Private Sub cboStateID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FillcboCityID()
            Me.StateID = Me.cboStateID.SelectedValue
            RaiseEvent StateID_SelectedIndexChanged()
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
    End Sub
    Private Sub cboCityID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FillcboAria()
            Me.CityID = Me.cboCityID.SelectedValue
            RaiseEvent CityID_SelectedIndexChanged()
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
    End Sub
    Private Sub cboAria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.cboAria.SelectedIndex = 0 Then
                Me.AriaID = -1
            Else
                Me.AriaID = Me.cboAria.SelectedValue
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
        RaiseEvent AriaID_SelectedIndexChanged()
    End Sub


End Class
