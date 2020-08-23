Public Class frmRptGetPazirandehInfo
    Private clsDalReport As New ClassDALReport(modPublicMethod.ConnectionString)
    Dim dtExcelImport As DataTable
    Dim dtExcelExport As DataTable

    Private Sub frmRptGetPazirandehInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnBrowseImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseImport.Click
        Try
            Dim frm As New OpenFileDialog
            frm.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtImportPath.Text = frm.FileName
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnBrowseExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseExport.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtExportPath.Text = frm.FileName
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            dtExcelImport = New DataTable
            dtExcelExport = New DataTable

            If txtImportPath.Text.Trim = String.Empty Then
                Throw New ApplicationException("مسیر فایل ورودی را انتخاب نمایید")
            End If
            If txtExportPath.Text.Trim = String.Empty Then
                Throw New ApplicationException("مسیر فایل خروجی را انتخاب نمایید")
            End If
            If IO.File.Exists(txtImportPath.Text.Trim) = False Then
                Throw New ApplicationException("مسیر فایل ورودی نادرست است")
            End If

            Dim clsExcel As New ClassExcel(txtImportPath.Text.Trim)
            dtExcelImport = clsExcel.Read(1, True)

            If dtExcelImport.Rows.Count = 0 Then
                Throw New ApplicationException("رکوردی در فایل ورودی یافت نشد")
            End If

            prgbar.Value = 0
            prgbar.Maximum = dtExcelImport.Rows.Count

            CreatedtExcelExport()
            Dim dt As New DataTable
            For i As Int32 = 0 To dtExcelImport.Rows.Count - 1
                Application.DoEvents()
                prgbar.Value = i + 1
                dt.Clear()
                If IsDBNull(dtExcelImport.Rows(i).Item(0)) = False Then
                    If rdoEniacCode.Checked Then
                        dt = clsDalReport.GetPazirandehInfoByEniacCode(dtExcelImport.Rows(i).Item(0).ToString.Trim)
                    ElseIf rdoSerial.Checked Then
                        dt = clsDalReport.GetPazirandehInfoBySerial(dtExcelImport.Rows(i).Item(0).ToString.Trim)
                    ElseIf rdoPayaneh.Checked Then
                        dt = clsDalReport.GetPazirandehInfoByPayaneh(dtExcelImport.Rows(i).Item(0).ToString.Trim)
                    End If
                End If
                Dim dr As DataRow = dtExcelExport.NewRow
                If dt.Rows.Count > 0 Then
                    dr("Input") = dtExcelImport.Rows(i).Item(0)
                    dr("فروشگاه") = dt.Rows(0).Item("StoreName")
                    dr("نام") = dt.Rows(0).Item("FirstName_nvc")
                    dr("نام خانوادگی") = dt.Rows(0).Item("LastName_nvc")
                    dr("بازاریاب") = dt.Rows(0).Item("VisitorName")
                    dr("استان") = dt.Rows(0).Item("StateName")
                    dr("شهر") = dt.Rows(0).Item("CityName")
                    dr("آدرس") = dt.Rows(0).Item("Address_nvc")
                    dr("تلفن") = dt.Rows(0).Item("Tel1_vc")
                    dr("موبایل") = dt.Rows(0).Item("Mobile_vc")
                    dr("صنف") = dt.Rows(0).Item("GroupName")
                    dr("وضعیت") = dt.Rows(0).Item("PosStatus")
                    dr("تاریخ نصب") = dt.Rows(0).Item("InstallDate")
                    dr("تاریخ فسخ") = dt.Rows(0).Item("CancelDate")
                    dr("تاریخ پیکربندی") = dt.Rows(0).Item("InitDate")
                    dr("کد قرارداد") = dt.Rows(0).Item("ContractID")
                    dr("شماره قرارداد") = dt.Rows(0).Item("ContractNo_vc")
                    dr("تاریخ قرارداد") = dt.Rows(0).Item("ContractDate")
                    dr("سریال") = dt.Rows(0).Item("Serial_vc")
                    dr("کد پیگیری") = dt.Rows(0).Item("EniacCode_vc")
                    dr("پذیرنده") = dt.Rows(0).Item("Pazirandeh")
                    dr("پایانه") = dt.Rows(0).Item("Payaneh")
                    dr("ورژن Application") = dt.Rows(0).Item("AppVersion")
                Else
                    dr("Input") = dtExcelImport.Rows(i).Item(0)
                    dr("فروشگاه") = String.Empty
                    dr("نام") = String.Empty
                    dr("نام خانوادگی") = String.Empty
                    dr("بازاریاب") = String.Empty
                    dr("استان") = String.Empty
                    dr("شهر") = String.Empty
                    dr("آدرس") = String.Empty
                    dr("تلفن") = String.Empty
                    dr("موبایل") = String.Empty
                    dr("صنف") = String.Empty
                    dr("وضعیت") = String.Empty
                    dr("تاریخ نصب") = String.Empty
                    dr("تاریخ فسخ") = String.Empty
                    dr("تاریخ پیکربندی") = String.Empty
                    dr("کد قرارداد") = String.Empty
                    dr("شماره قرارداد") = String.Empty
                    dr("تاریخ قرارداد") = String.Empty
                    dr("سریال") = String.Empty
                    dr("کد پیگیری") = String.Empty
                    dr("پذیرنده") = String.Empty
                    dr("پایانه") = String.Empty
                    dr("ورژن Application") = String.Empty
                End If
                dtExcelExport.Rows.Add(dr)
            Next
            Dim clsExcelWrite As New ClassExcel(txtExportPath.Text.Trim)
            clsExcelWrite.Write(dtExcelExport)

        Catch ex As Exception
            ShowErrorMessage("اطلاعات ورودی با گزارش خواسته شده مطابقت ندارد")
            'ShowErrorMessage(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CreatedtExcelExport()
        Try
            Dim Input As New DataColumn
            Input.ColumnName = "Input"
            dtExcelExport.Columns.Add(Input)

            Dim StoreName As New DataColumn
            StoreName.ColumnName = "فروشگاه"
            dtExcelExport.Columns.Add(StoreName)

            Dim FirstName_nvc As New DataColumn
            FirstName_nvc.ColumnName = "نام"
            dtExcelExport.Columns.Add(FirstName_nvc)

            Dim LastName_nvc As New DataColumn
            LastName_nvc.ColumnName = "نام خانوادگی"
            dtExcelExport.Columns.Add(LastName_nvc)

            Dim VisitorName As New DataColumn
            VisitorName.ColumnName = "بازاریاب"
            dtExcelExport.Columns.Add(VisitorName)

            Dim StateName As New DataColumn
            StateName.ColumnName = "استان"
            dtExcelExport.Columns.Add(StateName)

            Dim CityName As New DataColumn
            CityName.ColumnName = "شهر"
            dtExcelExport.Columns.Add(CityName)

            Dim Address_nvc As New DataColumn
            Address_nvc.ColumnName = "آدرس"
            dtExcelExport.Columns.Add(Address_nvc)

            Dim Tel1_vc As New DataColumn
            Tel1_vc.ColumnName = "تلفن"
            dtExcelExport.Columns.Add(Tel1_vc)

            Dim Mobile_vc As New DataColumn
            Mobile_vc.ColumnName = "موبایل"
            dtExcelExport.Columns.Add(Mobile_vc)

            Dim GroupName As New DataColumn
            GroupName.ColumnName = "صنف"
            dtExcelExport.Columns.Add(GroupName)

            Dim PosStatus As New DataColumn
            PosStatus.ColumnName = "وضعیت"
            dtExcelExport.Columns.Add(PosStatus)

            Dim InstallDate As New DataColumn
            InstallDate.ColumnName = "تاریخ نصب"
            dtExcelExport.Columns.Add(InstallDate)

            Dim CancelDate As New DataColumn
            CancelDate.ColumnName = "تاریخ فسخ"
            dtExcelExport.Columns.Add(CancelDate)

            Dim InitDate As New DataColumn
            InitDate.ColumnName = "تاریخ پیکربندی"
            dtExcelExport.Columns.Add(InitDate)

            Dim ContractID As New DataColumn
            ContractID.ColumnName = "کد قرارداد"
            dtExcelExport.Columns.Add(ContractID)

            Dim ContractNo_vc As New DataColumn
            ContractNo_vc.ColumnName = "شماره قرارداد"
            dtExcelExport.Columns.Add(ContractNo_vc)

            Dim ContractDate As New DataColumn
            ContractDate.ColumnName = "تاریخ قرارداد"
            dtExcelExport.Columns.Add(ContractDate)

            Dim Serial_vc As New DataColumn
            Serial_vc.ColumnName = "سریال"
            dtExcelExport.Columns.Add(Serial_vc)

            Dim EniacCode_vc As New DataColumn
            EniacCode_vc.ColumnName = "کد پیگیری"
            dtExcelExport.Columns.Add(EniacCode_vc)

            Dim Pazirandeh As New DataColumn
            Pazirandeh.ColumnName = "پذیرنده"
            dtExcelExport.Columns.Add(Pazirandeh)

            Dim Payaneh As New DataColumn
            Payaneh.ColumnName = "پایانه"
            dtExcelExport.Columns.Add(Payaneh)

            Dim AppVersion As New DataColumn
            AppVersion.ColumnName = "ورژن Application"
            dtExcelExport.Columns.Add(AppVersion)





        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class