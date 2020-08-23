Public Class Management_Branch
    Private clsDALManagement As New ClassDALManagement(modPublicMethod.ConnectionString)
    Private clsDALBranch As New ClassDALBranch(modPublicMethod.ConnectionString)

    Private _ManagementID As String = ""
    Private _BranchID As String = ""

    Event ManagementID_SelectedIndexChanged()
    Event BranchID_SelectedIndexChanged()


    Public Property ManagementID() As String
        Get
            Return _ManagementID
        End Get
        Set(ByVal value As String)
            _ManagementID = value
        End Set
    End Property
    Public Property BranchID() As String
        Get
            Return _BranchID
        End Get
        Set(ByVal value As String)
            _BranchID = value
        End Set
    End Property


    Private Sub Management_Branch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FillcboManagement()
            FillcboBranchID()

            AddHandler cboManagement.SelectedIndexChanged, AddressOf cboManagement_SelectedIndexChanged
            AddHandler cboBranchID.SelectedIndexChanged, AddressOf cboBranchID_SelectedIndexChanged
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub
    Private Sub FillcboManagement()
        Try
            Me.clsDALManagement.BeginProc()
            Me.cboManagement.DisplayMember = "Name_nvc"
            Me.cboManagement.ValueMember = "ManagementID"
            Me.cboManagement.DataSource = clsDALManagement.GetAllForUCtrl
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALManagement.EndProc()
        End Try
    End Sub
    Private Sub FillcboBranchID()
        Try
            Me.clsDALBranch.BeginProc()
            If cboManagement.SelectedIndex = -1 Then
                clsDALBranch.ManagementID = "-1"
            Else
                clsDALBranch.ManagementID = cboManagement.SelectedValue
            End If
            Me.cboBranchID.DisplayMember = "Name_nvc"
            Me.cboBranchID.ValueMember = "BranchID"
            Me.cboBranchID.DataSource = clsDALBranch.GetByManagementID
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBranch.EndProc()
        End Try
    End Sub


    Private Sub cboManagement_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FillcboBranchID()
            Me.ManagementID = Me.cboManagement.SelectedValue
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
        RaiseEvent ManagementID_SelectedIndexChanged()
    End Sub
    Private Sub cboBranchID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.cboBranchID.SelectedIndex = -1 Then
                Me.BranchID = String.Empty
            Else
                Me.BranchID = Me.cboBranchID.SelectedValue
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
        End Try
        RaiseEvent BranchID_SelectedIndexChanged()
    End Sub
End Class
