Public Class frmPasargadContractImport
    Private clsDalContractImport As New ClassDALContractimport(modPublicMethod.ConnectionString)


    Private dtExcel As New DataTable
    Private colErr As New Collection
    Private dtErr As New DataTable
    Private ErrImportRequest_FileName As String = "FanavaContractImport_Err.xls"

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
            'AddNotNullColumn()
            dgv.DataSource = dtExcel

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FillErrorDataTable(ByVal Rad As String, ByVal ReqID As String, ByVal Merchant As String, ByVal Outlet As String, ByVal ErrorDescr As String)
        Try
            Dim dr As DataRow = dtErr.NewRow()
            dr.Item("ردیف") = Rad
            dr.Item("کدورود قراردادفناوا") = ReqID
            dr.Item("کدپایانه") = Merchant
            dr.Item("کدپذیرنده") = Outlet
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
        dtErr.Columns.Add("کدورود قراردادفناوا")
        dtErr.Columns.Add("کدپایانه")
        dtErr.Columns.Add("کدپذیرنده")
        dtErr.Columns.Add("شرح خطا")

        Dim i As Int32
        Dim ContractimportList As New List(Of Int64)
        Dim contractID As String
        Dim merchant As String
        Dim outlet As String

        Dim citiesID As String = Nothing
        Try
            'colErr.Clear()
            clsDalContractImport.BeginProc()

            For i = 0 To dgv.RowCount - 1
                If IsDBNull(dgv.Rows(i).Cells("CNTR_NO").Value) Then

                    contractID = dgv.Rows(i).Cells("CNTR_NO").Value.ToString
                    merchant = dgv.Rows(i).Cells("MERCH_CODE").Value.ToString
                    outlet = dgv.Rows(i).Cells("LOGICAL_TERMINAL_CODE").Value.ToString



                    FillErrorDataTable((i + 2).ToString, contractID, merchant, outlet, "CNTR_NO has null value")
                    'colErr.Add("در سطر" & Space(1) & (i + 2).ToString & Space(1) & "RequestId has null value")
                    Continue For
                End If
                clsDalContractImport.ContractID = dgv.Rows(i).Cells("CNTR_NO").Value
                ContractimportList.Add(clsDalContractImport.ContractID)
                clsDalContractImport.Merchant_vc = dgv.Rows(i).Cells("Merchant_vc").Value.ToString
                clsDalContractImport.Outlet_vc = dgv.Rows(i).Cells("Outlet_vc").Value.ToString

                If ImportValidity(i + 2) = False Then
                    Continue For
                End If

                Dim res As Int64 = clsDalContractImport.Insert()
            Next

            If dtErr.Rows.Count = 0 Then

                clsDalContractImport.EndProc()
                ShowMessage(modApplicationMessage.msgSuccess)
            Else
                clsDalContractImport.EndProc()
                ClassError.ExcelLogError(ErrImportRequest_FileName, dtErr)

                ShowErrorMessage("اشکالات فایل جاری که در سیستم ثبت نشدند در فايلي در مسير زير ثبت شده اند " & vbCrLf + TextLogErrorFilePath + ErrImportRequest_FileName)
            End If
        Catch ex As Exception
            clsDalContractImport.RollBackProc()
            MessageBox.Show((i + 1).ToString)
            Throw ex
        End Try
    End Sub
    Private Function ImportValidity(ByVal RowIndex As Int32) As Boolean
        Try
            ImportValidity = True


            If clsDalContractImport.GetByMerchantContractImport.Rows.Count > 0 Then
                FillErrorDataTable(RowIndex.ToString, clsDalContractImport.ContractID, clsDalContractImport.Merchant_vc, clsDalContractImport.Outlet_vc, "اطلاعات ورودی تکراری است")
                ImportValidity = False
            End If


        Catch ex As Exception
            FillErrorDataTable(RowIndex.ToString, clsDalContractImport.ContractimportID, clsDalContractImport.Merchant_vc, clsDalContractImport.Outlet_vc, ex.Message)
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