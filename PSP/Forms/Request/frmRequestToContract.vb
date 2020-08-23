Public Class frmRequestToContract
    Private clsDalRequest As New ClassDALRequest(modPublicMethod.ConnectionString)
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsSearch As New ClassSearch
    Dim clsCMSProject As New ClassCMSProject(0, "", False, "")


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
            ' FillFields(e.RowIndex)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub ddbtnChange_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ddbtnChange.DropDownItemClicked
        Try
            FillFields(dgv.CurrentRow.Index)
            If e.ClickedItem.Tag = 0 Then

                If Not ImportValidity() Then
                    Exit Sub
                End If

                Dim _frm As New frmExtraFields
                _frm.GroupID = clsDalContract.SGroupID
                _frm.StateID = clsDalContract.SStateID
                _frm.cityID = clsDalContract.SCityID
                If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Select Case _frm.Operation
                        Case frmExtraFields.OperationEnum.Insert
                            'fill extra fields
                            clsDalContract.StateID = _frm.StateID
                            clsDalContract.CityID = _frm.cityID
                            clsDalContract.CIdentityTypeID = _frm.CIdentityTypeID
                            clsDalContract.Date_vc = _frm.ContractDate_vc
                            clsDalContract.ContractNo_vc = _frm.ContractNo_vc
                            clsDalContract.SSIdentityTypeID = _frm.SIdentityTypeID
                            clsDalContract.CMSProjectID = _frm.CMSProjectID
                            clsDalContract.AShabaAccountold = clsDalContract.AShabaAccount
                            InsertNewContract()
                        Case frmExtraFields.OperationEnum.Update
                            clsDalContract.ContractID = _frm.ContractID
                            UpdateAvailableContract()
                        Case Else

                    End Select

                End If
            ElseIf e.ClickedItem.Tag = 2 Then
                Dim _frm As New frmEnterDuplicateRequestID
                _frm.ShowDialog()
                Select Case _frm.DialogResult
                    Case Windows.Forms.DialogResult.OK
                        clsDalRequest.RequestStatusID = e.ClickedItem.Tag
                        clsDalRequest.DuplicateRequestID = _frm.DuplicateRequestID
                        Try
                            clsDalRequest.BeginProc()
                            clsDalRequest.UpdateReuest_RequestStatusAndDuplicateRequestID()
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
                        Try
                            clsDalRequest.BeginProc()
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
                Try
                    clsDalRequest.BeginProc()
                    clsDalRequest.DuplicateRequestID = -1
                    clsDalRequest.RequestStatusID = e.ClickedItem.Tag
                    clsDalRequest.UpdateReuest_RequestStatusAndDuplicateRequestID()
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
            dtdgv = clsDalRequest.GetAllNotConvertedToContract
            dvdgv = dtdgv.DefaultView
            Me.dgv.DataSource = dvdgv

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgv_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv.MouseClick
        Dim rowClicked As Integer
        If e.Button = Windows.Forms.MouseButtons.Right Then
            rowClicked = dgv.HitTest(e.Location.X, e.Location.Y).RowIndex

            If rowClicked >= 0 Then
                ContextMenuStrip1.Show(dgv, e.Location)

            Else
                ContextMenuStrip1.Hide()
            End If

        End If
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
            dgv.Columns("ImportDate_vc").HeaderText = "تاریخ Import"
            dgv.Columns("ShabaAccount").HeaderText = "حساب شبا"
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
    Private Sub FillDropDownButton()
        Try
            dtRequestStatus = clsDalRequest.GetAllRequestStatus()

            ddbtnChange.DropDownItems.Clear()
            ddbtnChange.DropDownItems.Add("تبدیل به قرارداد")
            ddbtnChange.DropDownItems(0).Tag = 0

            For i As Int32 = 0 To dtRequestStatus.Rows.Count - 1
                ddbtnChange.DropDown.Items.Add(dtRequestStatus.Rows(i).Item("Name_nvc"))
                ddbtnChange.DropDownItems(i + 1).Tag = dtRequestStatus.Rows(i).Item("RequestStatusID")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InsertNewContract()
        Try
            clsDalContract.BeginProc()
            clsDalContract.ContractingPartyID = clsDalContract.InsertContractParty()
            clsDalContract.ContractID = clsDalContract.InsertContract_WithRequest()
            clsDalContract.AAccountID = clsDalContract.InsertAccount()
            clsDalContract.SStoreID = clsDalContract.InsertStore()
            InsertContractCMS()
            clsDalContract.EndProc()
        Catch ex As Exception
            clsDalContract.RollBackProc()
            Throw ex
        End Try

    End Sub

    Private Sub InsertContractCMS()
        Try
            clsDalContract.DeleteContractCMSProject()
            'clsDalContract.CMSProjectID = 3
            clsDalContract.InsertContractCMSProject()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateAvailableContract()
        Try
            clsDalContract.BeginProc()
            clsDalContract.UpdateContract_OnlyRequestID()
            clsDalContract.EndProc()
        Catch ex As Exception
            clsDalContract.RollBackProc()
            Throw ex
        End Try

    End Sub
    Private Sub FillFields(ByVal RowIndex As Int32)
        Try
            '
            clsDalContract.RequestID = dgv.Rows(RowIndex).Cells("RequestID").Value
            clsDalContract.FirstName_nvc = dgv.Rows(RowIndex).Cells("FirstName_nvc").Value.ToString
            clsDalContract.LastName_nvc = dgv.Rows(RowIndex).Cells("LastName_nvc").Value.ToString
            clsDalContract.FatherName_nvc = dgv.Rows(RowIndex).Cells("FatherName_nvc").Value.ToString
            clsDalContract.IdentityCertificateNO_nvc = dgv.Rows(RowIndex).Cells("IdentityCertificateNO_nvc").Value.ToString
            clsDalContract.NationalCode_nvc = dgv.Rows(RowIndex).Cells("NationalCode_nvc").Value.ToString
            clsDalContract.BirthDate_vc = dgv.Rows(RowIndex).Cells("BirthDate_vc").Value.ToString
            clsDalContract.HomeAddress_nvc = dgv.Rows(RowIndex).Cells("HomeAddress_nvc").Value.ToString
            clsDalContract.HomeTel_vc = dgv.Rows(RowIndex).Cells("HomeTel_vc").Value.ToString
            clsDalContract.Mobile_vc = dgv.Rows(RowIndex).Cells("Mobile_vc").Value.ToString
            clsDalContract.Email_nvc = dgv.Rows(RowIndex).Cells("Email_nvc").Value.ToString
            clsDalContract.HavingAccount_bit = True
            clsDalContract.AccountTypeID = dgv.Rows(RowIndex).Cells("AccountTypeID").Value.ToString
            clsDalContract.AccountNO_vc = dgv.Rows(RowIndex).Cells("AccountNO_vc").Value.ToString
            clsDalContract.BranchID = dgv.Rows(RowIndex).Cells("BranchID").Value.ToString
            clsDalContract.CardNo_vc = String.Empty
            clsDalContract.Gender_bit = True
            clsDalContract.DegreeID = -1
            clsDalContract.Title_nvc = String.Empty


            clsDalContract.VisitorID = dgv.Rows(RowIndex).Cells("VisitorID").Value.ToString
            clsDalContract.SaveDate_vc = GetDateNow()
            clsDalContract.ProjectID = dgv.Rows(RowIndex).Cells("ProjectID").Value.ToString
            clsDalContract.MarketingByID = ClassDALContract.MarketingByEnum.Bank
            clsDalContract.Merchant_vc = String.Empty
            clsDalContract.ZoncanNo_nvc = String.Empty

            clsDalContract.AAccountTypeID = dgv.Rows(RowIndex).Cells("AccountTypeID").Value.ToString
            clsDalContract.AAccountNO_vc = dgv.Rows(RowIndex).Cells("AccountNO_vc").Value.ToString
            clsDalContract.ABranchID = dgv.Rows(RowIndex).Cells("BranchID").Value.ToString
            clsDalContract.AShabaAccount = dgv.Rows(RowIndex).Cells("ShabaAccount").Value.ToString

            clsDalContract.ACardNo_vc = String.Empty


            clsDalContract.SGroupID = dgv.Rows(RowIndex).Cells("StoreGroupID").Value.ToString
            clsDalContract.SStateID = dgv.Rows(RowIndex).Cells("StoreStateID").Value.ToString
            clsDalContract.SCityID = dgv.Rows(RowIndex).Cells("StoreCityID").Value.ToString

            clsDalContract.SName_nvc = dgv.Rows(RowIndex).Cells("StoreName_nvc").Value.ToString
            clsDalContract.SPostCode_vc = dgv.Rows(RowIndex).Cells("StorePostCode_vc").Value.ToString
            clsDalContract.SAddress_nvc = dgv.Rows(RowIndex).Cells("StoreAddress_nvc").Value.ToString
            clsDalContract.STel1_vc = dgv.Rows(RowIndex).Cells("StoreTel1_vc").Value.ToString
            clsDalContract.STel2_vc = dgv.Rows(RowIndex).Cells("StoreTel2_vc").Value.ToString
            clsDalContract.SFax_vc = dgv.Rows(RowIndex).Cells("StoreFax_vc").Value.ToString
            clsDalContract.SMunicipalAreaNO_sint = dgv.Rows(RowIndex).Cells("StoreMunicipalAreaNO_sint").Value.ToString
            clsDalContract.SDeviceCount_tint = 1
            clsDalContract.SEstateConditionID = -1
            clsDalContract.SSIdentityTypeSDate_vc = String.Empty
            clsDalContract.SSIdentityTypeEDate_vc = String.Empty

            clsDalRequest.RequestID = dgv.Rows(RowIndex).Cells("RequestID").Value



        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function ImportValidity() As Boolean
        Try
            ImportValidity = True

            If clsDalContract.SGroupID = Nothing Then
                MessageBox.Show("کد اصناف نمی تواند خالی باشد")
                ImportValidity = False
            ElseIf clsDalContract.SStateID = Nothing Then
                MessageBox.Show("کد استان نمی تواند خالی باشد")
                ImportValidity = False
            ElseIf clsDalContract.SCityID = Nothing Then
                MessageBox.Show("کد شهر نمی تواند خالی باشد")
                ImportValidity = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

  
    Private Sub ContextMenuStrip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Click
        Try

            Dim frm As New frmReqImgShow()
            frm.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class