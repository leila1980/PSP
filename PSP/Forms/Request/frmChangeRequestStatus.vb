Public Class frmChangeRequestStatus
    Private clsDalRequest As New ClassDALRequest(modPublicMethod.ConnectionString)
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsSearch As New ClassSearch

    Private dtdgv As New DataTable
    Private dvdgv As DataView

    Private dtRequestStatus As New DataTable
    Private Sub frmRequestToContract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FormLoad()
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
    Private Sub dgv_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowEnter
        Try
            FillFields(e.RowIndex)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub ddbtnChange_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ddbtnChange.DropDownItemClicked
        Try
            If e.ClickedItem.Tag = 2 Then 'تکراری
                Dim _frm As New frmEnterDuplicateRequestID
                _frm.ShowDialog()
                Select Case _frm.DialogResult
                    Case Windows.Forms.DialogResult.OK
                        clsDalRequest.RequestStatusID = e.ClickedItem.Tag
                        clsDalRequest.DuplicateRequestID = _frm.DuplicateRequestID
                        clsDalRequest.HaveDeviceOutlet = String.Empty
                        Try
                            clsDalRequest.BeginProc()
                            clsDalRequest.UpdateReuest_RequestStatusAndDuplicateRequestID()
                            clsDalRequest.UpdateReuest_RequestStatusAndHaveDeviceOutlet()
                            clsDalRequest.EndProc()
                        Catch ex As Exception
                            clsDalRequest.RollBackProc()
                            Throw ex
                        End Try
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            ElseIf e.ClickedItem.Tag = 5 Then
                Dim _frm As New frmEnterOutlet
                _frm.ShowDialog()
                Select Case _frm.DialogResult
                    Case Windows.Forms.DialogResult.OK
                        clsDalRequest.RequestStatusID = e.ClickedItem.Tag
                        clsDalRequest.HaveDeviceOutlet = _frm.Outlet_vc
                        clsDalRequest.DuplicateRequestID = -1
                        Try
                            clsDalRequest.BeginProc()
                            clsDalRequest.UpdateReuest_RequestStatusAndDuplicateRequestID()
                            clsDalRequest.UpdateReuest_RequestStatusAndHaveDeviceOutlet()
                            clsDalRequest.EndProc()
                        Catch ex As Exception
                            clsDalRequest.RollBackProc()
                            Throw ex
                        End Try
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            Else
                clsDalRequest.HaveDeviceOutlet = String.Empty
                clsDalRequest.RequestStatusID = e.ClickedItem.Tag
                clsDalRequest.DuplicateRequestID = -1
                Try
                    clsDalRequest.BeginProc()
                    clsDalRequest.UpdateReuest_RequestStatusAndDuplicateRequestID()
                    clsDalRequest.UpdateReuest_RequestStatusAndHaveDeviceOutlet()
                    clsDalRequest.EndProc()
                Catch ex As Exception
                    clsDalRequest.RollBackProc()
                    Throw ex
                End Try
            End If
            FillGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub FormLoad()
        Try
            FillGrid()
            Initgrid()
            FillDropDownButton()
            clsSearch.Init(cboSearchField, cboSearchOperation, txtSearch, btnSearch, btnSearchBack, btnRemoveFilter, dgv, dtdgv, dvdgv)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            dtdgv.Clear()
            dtdgv = clsDalRequest.GetAllRequestsWithRequestStatus
            dvdgv = dtdgv.DefaultView
            Me.dgv.DataSource = dvdgv

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Initgrid()
        Try
            dgv.Columns("VisitorFullName").HeaderText = "بازاریاب"
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
            dgv.Columns("ImportDate_vc").Visible = False
            dgv.Columns("ImportUserID").Visible = False
            dgv.Columns("ModifyDate_vc").Visible = False
            dgv.Columns("ModifyUserID").Visible = False
            dgv.Columns("RequestStatusID").Visible = False
            dgv.Columns("RequestStatusName_nvc").HeaderText = "وضعیت درخواست"
            dgv.Columns("DuplicateRequestID").HeaderText = "شماره درخواست تکراری"
            dgv.Columns("HaveDeviceOutlet_vc").HeaderText = "پایانه درخواست دارای دستگاه"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillDropDownButton()
        Try
            dtRequestStatus = clsDalRequest.GetAllRequestStatus()
            ddbtnChange.DropDownItems.Add("درخواست  عادی")
            ddbtnChange.DropDownItems(0).Tag = 0

            For i As Int32 = 0 To dtRequestStatus.Rows.Count - 1
                ddbtnChange.DropDown.Items.Add(dtRequestStatus.Rows(i).Item("Name_nvc"))
                ddbtnChange.DropDownItems(i + 1).Tag = dtRequestStatus.Rows(i).Item("RequestStatusID")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillFields(ByVal RowIndex As Int32)
        Try
            clsDalRequest.RequestID = dgv.Rows(RowIndex).Cells("RequestID").Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub











End Class