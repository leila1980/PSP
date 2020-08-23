Public Class frmImportRequest
    Private clsDalRequest As New ClassDALRequest(modPublicMethod.ConnectionString)
    Private clsDalState As New ClassDALState(modPublicMethod.ConnectionString)
    Private clsDalCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private clsDalGroup As New ClassDALGroup(modPublicMethod.ConnectionString)
    Private clsDalBasicTypes As New ClassDALBasicTypes(modPublicMethod.ConnectionString)

    Private dtExcel As New DataTable
    Private colErr As New Collection
    Private dtErr As New DataTable
    Private ErrImportRequest_FileName As String = "ImportRequest_Err.xls"

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            Me.btnSave.Enabled = True
            Import()
        Catch ex As Exception
            ShowErrorMessage("فایل انتخاب شده دارای فرمت نادرست می باشد")
            'ShowErrorMessage(ex.ToString)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Save()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub Import()
        Try
            dtExcel.Clear()
            Dim frm As New OpenFileDialog
            frm.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If frm.FileName = String.Empty Then
                    Exit Sub
                End If
                Dim clsExcel As New ClassExcel(frm.FileName)
                dtExcel = clsExcel.Read(1, True)
            End If
            'If Not (dtExcel.Columns.Count = 37 OrElse dtExcel.Columns.Count = 38) Then
            '    ShowErrorMessage("فايل نادرستي انتخاب شده است")
            '    Exit Sub
            'End If
            AddNotNullColumn()
            dgv.DataSource = dtExcel

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub AddNotNullColumn()
        Dim Needarray() As String = {"FatherName", "NationalCode", "IdentityCertificateNO", "BirthDate", "HomeTel", "Email", "StoreMunicipalAreaNO", "StoreFax", "AccountTypeID", "StoreCityID", "StoreStateID", "StoreTel2"}
        Dim flag As Boolean = 0
        For Each i As String In Needarray
            flag = 0
            For Each item As DataColumn In dtExcel.Columns
                If item.ColumnName = i.ToString Then
                    flag = 1
                    Continue For
                End If
            Next
            If Not flag Then
                dtExcel.Columns.Add(i.ToString)
            End If
        Next

    End Sub



    Private Sub FillErrorDataTable(ByVal Rad As String, ByVal ReqID As String, ByVal ErrorDescr As String)
        Try
            Dim dr As DataRow = dtErr.NewRow()
            dr.Item("ردیف") = Rad
            dr.Item("کد درخواست") = ReqID
            dr.Item("شرح خطا") = ErrorDescr
            dtErr.Rows.Add(dr)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Save()
        dtErr.Columns.Clear()
        dtErr.Clear()
        dtErr.Columns.Add("ردیف")
        dtErr.Columns.Add("کد درخواست")
        dtErr.Columns.Add("شرح خطا")
        Dim i As Int32
        Dim requestList As New List(Of String)

        Dim citiesID As String = Nothing
        Try
            'colErr.Clear()
            clsDalRequest.BeginProc()

            For i = 0 To dgv.RowCount - 1
                If IsDBNull(dgv.Rows(i).Cells("RequestID").Value) Then
                    FillErrorDataTable((i + 2).ToString, dgv.Rows(i).Cells("RequestID").Value.ToString, "RequestId has null value")
                    'colErr.Add("در سطر" & Space(1) & (i + 2).ToString & Space(1) & "RequestId has null value")
                    Continue For
                End If
                clsDalRequest.RequestID = dgv.Rows(i).Cells("RequestID").Value
                requestList.Add(clsDalRequest.RequestID)
                clsDalRequest.RequestDate_vc = dgv.Rows(i).Cells("RequestDate").Value.ToString
                clsDalRequest.ProjectID = ClassUserLoginDataAccess.ThisUser.ProjectID
                clsDalRequest.FirstName_nvc = dgv.Rows(i).Cells("FirstName").Value.ToString
                clsDalRequest.LastName_nvc = dgv.Rows(i).Cells("LastName").Value.ToString

                If IsDBNull(dgv.Rows(i).Cells("FatherName").Value) Then
                    clsDalRequest.FatherName_nvc = "خالی"
                Else
                    clsDalRequest.FatherName_nvc = dgv.Rows(i).Cells("FatherName").Value.ToString
                End If


                If IsDBNull(dgv.Rows(i).Cells("NationalCode").Value) Then
                    clsDalRequest.NationalCode_nvc = "0000000000"
                Else
                    clsDalRequest.NationalCode_nvc = Mid("0000000000" & dgv.Rows(i).Cells("NationalCode").Value.ToString, dgv.Rows(i).Cells("NationalCode").Value.ToString.Trim.Length + 1, 10) 'dgv.Rows(i).Cells("NationalCode").Value.ToString
                End If

         
                If IsDBNull(dgv.Rows(i).Cells("IdentityCertificateNO").Value) Then
                    clsDalRequest.IdentityCertificateNO_nvc = "1"
                Else
                    clsDalRequest.IdentityCertificateNO_nvc = dgv.Rows(i).Cells("IdentityCertificateNO").Value.ToString
                End If


                If IsDBNull(dgv.Rows(i).Cells("BirthDate").Value) Then
                    clsDalRequest.BirthDate_vc = "0000/00/00"
                Else
                    clsDalRequest.BirthDate_vc = dgv.Rows(i).Cells("BirthDate").Value.ToString
                End If


                clsDalRequest.HomeAddress_nvc = dgv.Rows(i).Cells("HomeAddress").Value.ToString


                If IsDBNull(dgv.Rows(i).Cells("HomeTel").Value) Then
                    clsDalRequest.HomeTel_vc = "خالی"
                Else
                    clsDalRequest.HomeTel_vc = dgv.Rows(i).Cells("HomeTel").Value.ToString
                End If

                clsDalRequest.ShabaAccount = dgv.Rows(i).Cells("ShabaAccount").Value.ToString.Trim
                clsDalRequest.Mobile_vc = dgv.Rows(i).Cells("Mobile").Value.ToString.Trim
                clsDalRequest.Email_nvc = dgv.Rows(i).Cells("Email").Value.ToString.Trim
                clsDalRequest.StoreName_nvc = dgv.Rows(i).Cells("StoreName").Value.ToString.Trim
                clsDalRequest.StoreMunicipalAreaNO_sint = IIf(IsDBNull(dgv.Rows(i).Cells("StoreMunicipalAreaNO").Value), -1, dgv.Rows(i).Cells("StoreMunicipalAreaNO").Value)
                clsDalRequest.StorePostCode_vc = dgv.Rows(i).Cells("StorePostCode").Value.ToString.Trim
                clsDalRequest.StoreAddress_nvc = dgv.Rows(i).Cells("StoreAddress").Value.ToString.Trim
                clsDalRequest.StoreTel1_vc = IIf(String.IsNullOrEmpty(dgv.Rows(i).Cells("StoreTel1").Value.ToString), "-", dgv.Rows(i).Cells("StoreTel1").Value.ToString) ' dgv.Rows(i).Cells("StoreTel1").Value.ToString

                If IsDBNull(dgv.Rows(i).Cells("StoreTel2").Value) Then
                    clsDalRequest.StoreTel2_vc = "000"
                Else
                    clsDalRequest.StoreTel2_vc = dgv.Rows(i).Cells("StoreTel2").Value.ToString
                End If


                clsDalRequest.StoreFax_vc = dgv.Rows(i).Cells("StoreFax").Value.ToString
                clsDalRequest.AccountNO_vc = Mid("0000000000" & dgv.Rows(i).Cells("AccountNO_vc").Value.ToString, dgv.Rows(i).Cells("AccountNO_vc").Value.ToString.Length + 1, 10) 'dgv.Rows(i).Cells("AccountNO_vc").Value.ToString
                clsDalRequest.BranchID = dgv.Rows(i).Cells("BranchID").Value.ToString
                clsDalRequest.AccountTypeID = 118

                clsDalRequest.Merchant_vc = dgv.Rows(i).Cells("Merchant_vc").Value.ToString
                clsDalRequest.Outlet_vc = dgv.Rows(i).Cells("Outlet_vc").Value.ToString

                'clsDalGroup.GetByMappingCodeGroupID(dgv.Rows(i).Cells("StoreGroupID").Value.ToString)
                Try
                    clsDalRequest.StoreGroupID = dgv.Rows(i).Cells("StoreGroupID").Value.ToString
                    clsDalGroup.shaparakcode_vc = clsDalRequest.StoreGroupID
                Catch ex As Exception
                    clsDalRequest.StoreGroupID = -1
                End Try


                'Try
                '    clsDalRequest.AccountTypeID = clsDalBasicTypes.GetByMappingCodeBasicTypesID(IIf(IsDBNull(dgv.Rows(i).Cells("AccountTypeID").Value), -1, dgv.Rows(i).Cells("AccountTypeID").Value), ClassDALBasicTypes.BasicTypeEnum.AccountType) 'mapping
                'Catch ex As Exception
                '    clsDalRequest.AccountTypeID = -1
                'End Try

                Try
                    clsDalRequest.StoreStateID = clsDalCity.GetByCityName(dgv.Rows(i).Cells("StoreCityName").Value.ToString, citiesID)
                Catch ex As Exception
                    clsDalRequest.StoreStateID = -1
                End Try
                Try
                    clsDalRequest.StoreCityID = citiesID
                Catch ex As Exception
                    clsDalRequest.StoreCityID = -1
                End Try

                If ImportValidity(i + 2) = False Then
                    Continue For
                End If
                clsDalRequest.Insert()
            Next
            
            If dtErr.Rows.Count = 0 Then

                'clsDalRequest.EndProc()
                'clsDalRequest.BeginProc()

                'If requestList.Count = 1 Then
                '    clsDalRequest.listOFRequestperty = "'" + clsDalRequest.RequestID.ToString + "'"
                '    dgv.DataSource = clsDalRequest.GetAllByRequestIDRequest
                'Else
                '    For Each id As String In requestList
                '        clsDalRequest.listOFRequestperty = "'" + clsDalRequest.RequestID.ToString + "','" + id.ToString + "'"
                '        dgv.DataSource = clsDalRequest.GetAllByRequestIDRequest
                '    Next

                '    Me.btnSave.Enabled = False
                'End If

                clsDalRequest.EndProc()
                 ShowMessage(modApplicationMessage.msgSuccess)
            Else
                clsDalRequest.EndProc()
                ClassError.ExcelLogError(ErrImportRequest_FileName, dtErr)
                'ClassError.LogError(ErrImportRequest_FileName, colErr)
                ShowErrorMessage("اشکالات فایل جاری که در سیستم ثبت نشدند در فايلي در مسير زير ثبت شده اند " & vbCrLf + TextLogErrorFilePath + ErrImportRequest_FileName)
            End If
        Catch ex As Exception
            clsDalRequest.RollBackProc()
            MessageBox.Show((i + 1).ToString)
            Throw ex
        End Try
    End Sub
    Private Function ImportValidity(ByVal RowIndex As Int32) As Boolean
        Try
            ImportValidity = True
            If clsDalRequest.GetByRequestIDRequest.Rows.Count > 0 Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "شماره درخواست تکراری است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "شماره درخواست تکراری است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.RequestDate_vc) OrElse clsDalRequest.RequestDate_vc = "NULL" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "تاریخ درخواست مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "تاریخ درخواست مشخص نشده است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.FirstName_nvc) OrElse clsDalRequest.FirstName_nvc = "NULL" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "نام مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "نام مشخص نشده است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.Merchant_vc) OrElse clsDalRequest.Merchant_vc = "NULL" Then
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کد پذیرنده مشخص نشده است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.Outlet_vc) OrElse clsDalRequest.Outlet_vc = "NULL" Then
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کد پایانه مشخص نشده است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.LastName_nvc) OrElse clsDalRequest.LastName_nvc = "NULL" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "نام خانوادگی مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "نام خانوادگی مشخص نشده است")
                ImportValidity = False
            End If
            'If String.IsNullOrEmpty(clsDalRequest.FatherName_nvc) OrElse clsDalRequest.FatherName_nvc = "NULL" Then
            '    'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "نام پدر مشخص نشده است")
            '    FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "نام پدر مشخص نشده است")
            '    ImportValidity = False
            'End If
            If String.IsNullOrEmpty(clsDalRequest.NationalCode_nvc.ToString) OrElse clsDalRequest.NationalCode_nvc.Length <> 10 OrElse modPublicMethod.Code_Melli(clsDalRequest.NationalCode_nvc.ToString) = 0 Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "کد ملی نامعتبر است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کد ملی نامعتبر است")
                ImportValidity = False
            End If
            'If String.IsNullOrEmpty(clsDalRequest.IdentityCertificateNO_nvc) OrElse clsDalRequest.IdentityCertificateNO_nvc = "Null" Then
            '    'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "شماره شناسنامه مشخص نشده است")
            '    FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "شماره شناسنامه مشخص نشده است")
            '    ImportValidity = False
            'End If
            'If String.IsNullOrEmpty(clsDalRequest.BirthDate_vc) Then
            '    colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "تاریخ تولد مشخص نشده است")
            '    ImportValidity = False
            'End If
            If String.IsNullOrEmpty(clsDalRequest.StoreName_nvc) OrElse clsDalRequest.StoreName_nvc = "Null" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "نام فروشگاه مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "نام فروشگاه مشخص نشده است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.StoreStateID) OrElse clsDalRequest.StoreStateID = "Null" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "کد استان مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کد استان مشخص نشده است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.StoreCityID) OrElse clsDalRequest.StoreCityID = "Null" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "کد شهر مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کد شهر مشخص نشده است")
            End If
            If String.IsNullOrEmpty(clsDalRequest.StoreMunicipalAreaNO_sint) OrElse clsDalRequest.StoreMunicipalAreaNO_sint.ToString = "Null" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "منطقه شهرداری مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "منطقه شهرداری مشخص نشده است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.StorePostCode_vc) OrElse clsDalRequest.StorePostCode_vc.Trim.Length <> 10 Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "کد پستی نامعتبر است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کد پستی نامعتبر است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.StoreAddress_nvc) OrElse clsDalRequest.StoreAddress_nvc = "Null" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "آدرس مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "آدرس مشخص نشده است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.StoreTel1_vc) OrElse clsDalRequest.StoreTel1_vc = "Null" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "تلفن 1 فروشگاه مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "تلفن 1 فروشگاه مشخص نشده است")
                ImportValidity = False
            End If
            If clsDalRequest.AccountTypeID = -1 Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "نوع حساب معتبری مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "نوع حساب معتبری مشخص نشده است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.AccountNO_vc) Then 'OrElse clsDalRequest.AccountNO_vc.Trim.Length <> 10 OrElse modPublicMethod.CheckAccountNo(clsDalRequest.AccountNO_vc) = False OrElse clsDalRequest.AccountNO_vc = "Null" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "شماره حساب نامعتبر است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "شماره حساب نامعتبر است")
                ImportValidity = False
            End If
            If String.IsNullOrEmpty(clsDalRequest.BranchID) OrElse clsDalRequest.BranchID = "Null" Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "کد شعبه مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کد شعبه مشخص نشده است")
                ImportValidity = False
            End If
            If clsDalRequest.StoreStateID = -1 Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "کداستان مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کداستان مشخص نشده است")
                ImportValidity = False
            End If
            If clsDalRequest.StoreCityID = -1 Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1)  & "کد شهر مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کد شهر مشخص نشده است")
                ImportValidity = False
            End If
            If clsDalRequest.StoreGroupID = -1 Or clsDalGroup.GetOneByID().Rows.Count <= 0 Then
                'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1)  & "کد شهر مشخص نشده است")
                FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, "کد صنف مشخص نشده است")
                ImportValidity = False
            End If

        Catch ex As Exception
            'colErr.Add("در سطر" & Space(1) & RowIndex.ToString & Space(1) & "خطا:" & ex.Message)
            FillErrorDataTable(RowIndex.ToString, clsDalRequest.RequestID, ex.Message)
            ImportValidity = False
        End Try
    End Function

    Private Sub frmImportRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.btnSave.Enabled = True

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
End Class