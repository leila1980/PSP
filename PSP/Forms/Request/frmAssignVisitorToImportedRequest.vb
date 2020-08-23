Public Class frmAssignVisitorToImportedRequest
    Private clsDalVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private clsDalRequest As New ClassDALRequest(modPublicMethod.ConnectionString)
    Private clsSearch As New ClassSearch

    Private dtVisitor As New DataTable
    Private dtdgv As New DataTable
    Private dvdgv As DataView

    Private Sub frmAssignVisitorToImportedRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            dgv.EndEdit()
            erp.Clear()
            If cboVisitor.SelectedIndex = -1 Then
                erp.SetError(cboVisitor, "بازاریاب را انتخاب نمایید")
                Exit Sub
            End If
            Save()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgv)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Public Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        dgv.EndEdit()
        For i As Integer = 0 To dgv.RowCount - 1
            dgv.Rows(i).Cells("colcheck").Value = True
        Next
    End Sub
    Public Sub btnUnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnSelect.Click
        dgv.EndEdit()
        For i As Integer = 0 To dgv.RowCount - 1
            dgv.Rows(i).Cells("colcheck").Value = False
        Next
    End Sub
    Public Sub InventSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventSelect.Click
        dgv.EndEdit()
        For i As Integer = 0 To dgv.RowCount - 1
            dgv.Rows(i).Cells("colcheck").Value = Not dgv.Rows(i).Cells("colcheck").Value
        Next
    End Sub

    Private Sub FormLoad()
        Try
            FillCboVisitor()
            FillGrid()
            InitGrid()
            clsSearch.Init(cboSearchField, cboSearchOperation, txtSearch, btnSearch, btnSearchBack, btnRemoveFilter, dgv, dtdgv, dvdgv)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillCboVisitor()
        Try
            dtVisitor.Clear()
            dtVisitor = clsDalVisitor.GetAll()
            cboVisitor.DataSource = dtVisitor
            cboVisitor.ValueMember = "VisitorID"
            cboVisitor.DisplayMember = "FullName_nvc"
            cboVisitor.SelectedIndex = -1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            dtdgv.Clear()
            dtdgv = clsDalRequest.GetAllNotAssignedToVisitor
            dvdgv = dtdgv.DefaultView
            Me.dgv.DataSource = dvdgv

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            dgv.Columns("StateName_nvc").HeaderText = "استان"
            dgv.Columns("CityName_nvc").HeaderText = "شهر"
            dgv.Columns("GroupName_nvc").HeaderText = "صنف"
            dgv.Columns("RequestID").HeaderText = "شماره درخواست"
            dgv.Columns("RequestDate_vc").HeaderText = "تاریخ درخواست"
            dgv.Columns("ProjectID").HeaderText = "پروژه"
            dgv.Columns("VisitorID").Visible = False
            dgv.Columns("FirstName_nvc").HeaderText = "نام"
            dgv.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
            dgv.Columns("FatherName_nvc").HeaderText = "نام پدر"
            dgv.Columns("NationalCode_nvc").HeaderText = "کد ملی"
            dgv.Columns("IdentityCertificateNO_nvc").HeaderText = "شماره شناسنامه"
            dgv.Columns("BirthDate_vc").HeaderText = "تاریخ تولد"
            dgv.Columns("HomeAddress_nvc").HeaderText = "آدر منزل"
            dgv.Columns("HomeTel_vc").HeaderText = "تلفن منزل"
            dgv.Columns("Mobile_vc").HeaderText = "موبایل"
            dgv.Columns("Email_nvc").HeaderText = "Email"
            dgv.Columns("StoreName_nvc").HeaderText = "فروشگاه"
            dgv.Columns("StoreGroupID").HeaderText = "کد صنف"
            dgv.Columns("StoreStateID").HeaderText = "کد استان"
            dgv.Columns("StoreCityID").HeaderText = "کد شهر"
            dgv.Columns("StoreMunicipalAreaNO_sint").HeaderText = "منطقه"
            dgv.Columns("StorePostCode_vc").HeaderText = "کد پستی"
            dgv.Columns("StoreAddress_nvc").HeaderText = "آدرس فروشگاه"
            dgv.Columns("StoreTel1_vc").HeaderText = "تلفن فروشگاه 1"
            dgv.Columns("StoreTel2_vc").HeaderText = "تلفن فروشگاه 2 "
            dgv.Columns("StoreFax_vc").HeaderText = "فکس"
            dgv.Columns("AccountTypeID").Visible = False
            dgv.Columns("AccountNO_vc").HeaderText = "شماره حساب"
            dgv.Columns("BranchID").HeaderText = "کد شعبه"
            dgv.Columns("ImportDate_vc").HeaderText = "تاریخ Import"
            dgv.Columns("ImportUserID").Visible = False
            dgv.Columns("ModifyDate_vc").Visible = False
            dgv.Columns("ModifyUserID").Visible = False
            dgv.Columns("RequestStatusID").Visible = False
            dgv.Columns("RequestStatusName_nvc").HeaderText = "وضعیت درخواست"
            dgv.Columns("DuplicateRequestID").HeaderText = "شماره درخواست تکراری"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Save()
        Try
            clsDalRequest.BeginProc()
            For i As Int32 = 0 To dgv.RowCount - 1
                If dgv.Rows(i).Cells("colCheck").Value = True Then
                    clsDalRequest.RequestID = dgv.Rows(i).Cells("RequestID").Value
                    clsDalRequest.VisitorID = cboVisitor.SelectedValue
                    clsDalRequest.UpdateReuest_VisitorID()
                End If
            Next
            clsDalRequest.EndProc()
            FillGrid()
        Catch ex As Exception
            clsDalRequest.RollBackProc()
            Throw ex
        End Try
    End Sub


 
End Class