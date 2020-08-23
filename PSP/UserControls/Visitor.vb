Public Class Visitor
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)

    Private _VisitorID As Int32 = "0"

    Event Visitor_SelectedIndexChanged()

    Public Property VisitorID() As Int32
        Get
            Return _VisitorID
        End Get
        Set(ByVal value As Int32)
            _VisitorID = value
        End Set
    End Property
    Private Sub Visitor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillcboVisitorID()

        AddHandler cboVisitor.SelectedIndexChanged, AddressOf cboVisitor_SelectedIndexChanged
    End Sub
    Private Sub FillcboVisitorID()
        Try
            Me.clsDALVisitor.BeginProc()
            cboVisitor.DisplayMember = "FullName_nvc"
            cboVisitor.ValueMember = "VisitorID"
            Me.cboVisitor.DataSource = clsDALVisitor.GetAllVisitorForUctrl_ExcludeUser
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALVisitor.EndProc()
        End Try
    End Sub
    Private Sub cboVisitor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.VisitorID = Me.cboVisitor.SelectedValue
            RaiseEvent Visitor_SelectedIndexChanged()
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
    End Sub
End Class
