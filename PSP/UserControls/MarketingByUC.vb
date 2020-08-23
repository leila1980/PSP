Public Class MarketingByUC
    Private clsDALConract As New ClassDALContract(modPublicMethod.ConnectionString)

    Private _MarketingByID As Int16
    Event MarketingByID_SelectedIndexChanged()
    Public Property MarketingByID() As Int16
        Get
            Return _MarketingByID
        End Get
        Set(ByVal value As Int16)
            _MarketingByID = value
        End Set
    End Property

    Private Sub UC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillcboMarketingByID()
        AddHandler cboMarketingByID.SelectedIndexChanged, AddressOf cboMarketingByID_SelectedIndexChanged
    End Sub
    Private Sub FillcboMarketingByID()
        Try
            Me.clsDALConract.BeginProc()
            cboMarketingByID.DisplayMember = "Name_nvc"
            cboMarketingByID.ValueMember = "MarketingByID"
            Me.cboMarketingByID.DataSource = clsDALConract.GetAllMarketingByForUCtrl
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALConract.EndProc()
        End Try
    End Sub
    Private Sub cboMarketingByID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Me.MarketingByID = Me.cboMarketingByID.SelectedValue
            RaiseEvent MarketingByID_SelectedIndexChanged()
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
    End Sub
End Class
