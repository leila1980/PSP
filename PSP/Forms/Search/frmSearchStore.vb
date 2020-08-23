Public Class frmSearchStore
    Dim clsDALContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Dim dtSearch As New DataTable
    Private _CurID As Int64
    Private _CurName_nvc As String
#Region "Prpoperty"
    Public Property CurID() As Int64
        Get
            Return _CurID
        End Get
        Set(ByVal value As Int64)
            _CurID = value
        End Set
    End Property
    Public Property CurName_nvc() As String
        Get
            Return _CurName_nvc
        End Get
        Set(ByVal value As String)
            _CurName_nvc = value
        End Set
    End Property
#End Region
    Private Sub frmSearchStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub FormLoad()
        Try
            FillGrid()
            InitGrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            clsDALContract.BeginProc()
            dtSearch = clsDALContract.GetAllStore_State_City_Group()
            dgvSearch.DataSource = dtSearch
        Catch ex As Exception
            Throw ex
        Finally
            clsDALContract.EndProc()
        End Try
    End Sub
    Private Sub InitGrid()
        dgvSearch.Columns("StoreID").Visible = False
        dgvSearch.Columns("AccountID").Visible = False
        dgvSearch.Columns("GroupID").HeaderText = "کد صنف"
        dgvSearch.Columns("StateID").Visible = False
        dgvSearch.Columns("CityID").Visible = False
        dgvSearch.Columns("Name_nvc").HeaderText = "نام فروشگاه"
        dgvSearch.Columns("PostCode_vc").HeaderText = "کد پستی"
        dgvSearch.Columns("Address_nvc").HeaderText = "آدرس"
        dgvSearch.Columns("Tel1_vc").HeaderText = "تلفن 1"
        dgvSearch.Columns("Tel2_vc").HeaderText = "تلفن 2"
        dgvSearch.Columns("MunicipalAreaNO_sint").HeaderText = "منطقه"
        dgvSearch.Columns("EstateConditionID").Visible = False
        dgvSearch.Columns("SIdentityTypeID").Visible = False
        dgvSearch.Columns("SIdentityTypeSDate_vc").Visible = False
        dgvSearch.Columns("SIdentityTypeEDate_vc").Visible = False
        dgvSearch.Columns("DeviceCount_tint").HeaderText = "تعداد پز"
        dgvSearch.Columns("StateName_nvc").HeaderText = "استان"
        dgvSearch.Columns("CityName_nvc").HeaderText = "شهر"
        dgvSearch.Columns("GroupName_nvc").HeaderText = "صنف"
        dgvSearch.Columns("EstateConditionName_nvc").HeaderText = "وضعیت تملک"
        dgvSearch.Columns("SIdentityTypeName_nvc").HeaderText = "نوع مدرک شناسایی"

        dgvSearch.Columns("Name_nvc").Width = 120
        dgvSearch.Columns("EstateConditionName_nvc").Width = 120
        dgvSearch.Columns("SIdentityTypeName_nvc").Width = 160

    End Sub

    Private Sub Search()
        Dim dvSearch As DataView = dtSearch.DefaultView

        If cboSearchBy.SelectedIndex <> -1 AndAlso txtSearch.Text.Trim <> "" Then
            If cboSearchBy.SelectedIndex = 0 Then 'Name
                dvSearch.RowFilter = "Name_nvc like '%" & txtSearch.Text.Trim & "%'"
            End If
        Else
            dvSearch.RowFilter = ""
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Try
            Search()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgvSearch_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSearch.DoubleClick
        Try
            Choose()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            Me.Close()
        End Try

    End Sub
    Private Sub Choose()
        If dgvSearch.SelectedRows.Count > 0 Then
            CurID = dgvSearch.SelectedRows(0).Cells("StoreID").Value
            CurName_nvc = dgvSearch.SelectedRows(0).Cells("Name_nvc").Value
        Else
            CurID = 0
            CurName_nvc = ""
        End If
    End Sub
End Class