Imports System.Globalization

Public Class frmChangeMakeFile
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalAccess As New ClasDALAccessChange

    Private dt As New DataTable
    Private dv As New DataView
    Private pc As New PersianCalendar

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgv)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub dgv_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgv.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgv.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgv.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub

    Private Sub frmChangeMakeFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub FormLoad()
        Try
            rbtAll.Checked = True
            FillGrid()
            InitGrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            clsDalContract.BeginProc()
            dt = clsDalContract.GetAllChange()
            dv = dt.DefaultView
            dgv.DataSource = dv
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            dgv.Columns("ChangeID").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("Merchant_vc").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("Outlet_vc").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreName_nvc1").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreName_nvc2").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreAddress_nvc1").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreAddress_nvc2").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StorePostCode_vc1").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StorePostCode_vc2").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreStateID1").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreStateID2").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreCityID1").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreCityID2").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreTel1_Vc1").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreTel1_Vc2").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreTel2_Vc1").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreTel2_Vc2").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreFax_Vc1").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("StoreFax_Vc2").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("Email_nvc1").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("Email_nvc2").SortMode = DataGridViewColumnSortMode.NotSortable
            dgv.Columns("ChangeDate_vc").SortMode = DataGridViewColumnSortMode.NotSortable



            dgv.Columns("ChangeID").HeaderText = "کد تغییر"
            dgv.Columns("Merchant_vc").HeaderText = "Merchant"
            dgv.Columns("Outlet_vc").HeaderText = "Outlet"
            dgv.Columns("StoreName_nvc1").HeaderText = "نام فروشگاه_قدیم"
            dgv.Columns("StoreName_nvc2").HeaderText = "نام فروشگاه_جدید"
            dgv.Columns("StoreAddress_nvc1").HeaderText = "آدرس فروشگاه_قبلی"
            dgv.Columns("StoreAddress_nvc2").HeaderText = "آدرس فروشگاه_جدید"
            dgv.Columns("StorePostCode_vc1").HeaderText = "کد پستی_قبلی"
            dgv.Columns("StorePostCode_vc2").HeaderText = "کد پستی_جدید"
            dgv.Columns("StoreStateID1").HeaderText = "استان_قبلی"
            dgv.Columns("StoreStateID2").HeaderText = "استان_جدید"
            dgv.Columns("StoreCityID1").HeaderText = "شهر_قبلی"
            dgv.Columns("StoreCityID2").HeaderText = "شهر_جدید"
            dgv.Columns("StoreTel1_Vc1").HeaderText = "تلفن 1_قبلی"
            dgv.Columns("StoreTel1_Vc2").HeaderText = "تلفن 1_جدید"
            dgv.Columns("StoreTel2_Vc1").HeaderText = "تلفن 2_قبلی"
            dgv.Columns("StoreTel2_Vc2").HeaderText = "تلفن 2_جدید"
            dgv.Columns("StoreFax_Vc1").HeaderText = "فکس_قبلی"
            dgv.Columns("StoreFax_Vc2").HeaderText = "فکس_جدید"
            dgv.Columns("Email_nvc1").HeaderText = "ایمیل_قبلی"
            dgv.Columns("Email_nvc2").HeaderText = "ایمیل_جدید"
            dgv.Columns("ChangeDate_vc").HeaderText = "تاریخ"

            dgv.Columns("StoreName_nvc1").Width = 170
            dgv.Columns("StoreName_nvc2").Width = 170
            dgv.Columns("StorePostCode_vc1").Width = 170
            dgv.Columns("StorePostCode_vc2").Width = 170

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FilterGrid()
        Try
            Dim SelectedDateTimedpDateFrom As String = String.Empty
            Dim SelectedDateTimedpDateTo As String = String.Empty

            If rbtSelective.Checked = True Then
                Try
                    SelectedDateTimedpDateFrom = pc.GetYear(dtpFrom.SelectedDateTime) & "/" & IIf(pc.GetMonth(dtpFrom.SelectedDateTime).ToString.Length = 1, "0" & pc.GetMonth(dtpFrom.SelectedDateTime), pc.GetMonth(dtpFrom.SelectedDateTime)) & "/" & IIf(pc.GetDayOfMonth(dtpFrom.SelectedDateTime).ToString.Length = 1, "0" & pc.GetDayOfMonth(dtpFrom.SelectedDateTime), pc.GetDayOfMonth(dtpFrom.SelectedDateTime))
                Catch
                    SelectedDateTimedpDateFrom = ""
                End Try
                Try
                    SelectedDateTimedpDateTo = pc.GetYear(dtpTo.SelectedDateTime) & "/" & IIf(pc.GetMonth(dtpTo.SelectedDateTime).ToString.Length = 1, "0" & pc.GetMonth(dtpTo.SelectedDateTime), pc.GetMonth(dtpTo.SelectedDateTime)) & "/" & IIf(pc.GetDayOfMonth(dtpTo.SelectedDateTime).ToString.Length = 1, "0" & pc.GetDayOfMonth(dtpTo.SelectedDateTime), pc.GetDayOfMonth(dtpTo.SelectedDateTime))
                Catch
                    SelectedDateTimedpDateTo = ""
                End Try

                If SelectedDateTimedpDateFrom = String.Empty And SelectedDateTimedpDateTo = String.Empty Then
                    dt.DefaultView.RowFilter = ""
                ElseIf SelectedDateTimedpDateFrom <> String.Empty And SelectedDateTimedpDateTo <> String.Empty Then
                    dt.DefaultView.RowFilter = "ChangeDate_vc >= '" + SelectedDateTimedpDateFrom + "' And ChangeDate_vc <= '" + SelectedDateTimedpDateTo + "'"
                ElseIf SelectedDateTimedpDateFrom <> String.Empty And SelectedDateTimedpDateTo = String.Empty Then
                    dt.DefaultView.RowFilter = "ChangeDate_vc >= '" + SelectedDateTimedpDateFrom + "'"
                ElseIf SelectedDateTimedpDateFrom = String.Empty And SelectedDateTimedpDateTo <> String.Empty Then
                    dt.DefaultView.RowFilter = "ChangeDate_vc <= '" + SelectedDateTimedpDateTo + "'"
                End If
            Else
                dt.DefaultView.RowFilter = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dtpFrom_SelectedDateTimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.SelectedDateTimeChanged
        Try
            FilterGrid()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub dtpTo_SelectedDateTimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.SelectedDateTimeChanged
        Try
            FilterGrid()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub rbtAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAll.CheckedChanged
        Try
            GroupBox3.Enabled = False
            FilterGrid()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub rbtSelective_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSelective.CheckedChanged
        Try
            GroupBox3.Enabled = True
            FilterGrid()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakeFile.Click
        Try
            MakeFile()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub MakeFile()
        Try
            If Me.dgv.Rows.Count = 0 Then
                modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If
            'Me.BackupPreAccessFile()
            clsDalAccess.ConnectionOpen()
            clsDalAccess.DeleteALLTAddress()
            Me.InsertIntoAccessFile()
            clsDalAccess.ConnectionClose()
            ShowMessage(msgSuccess)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub InsertIntoaccessFile()
        Try
            For i As Int64 = 0 To dgv.Rows.Count - 1
                clsDalAccess.Careof = dgv.Rows(i).Cells("StoreName_nvc2").Value
                clsDalAccess.City = dgv.Rows(i).Cells("StoreCityid2").Value
                clsDalAccess.Email = dgv.Rows(i).Cells("Email_nvc2").Value
                clsDalAccess.Fax = dgv.Rows(i).Cells("StoreFax_Vc2").Value

                Select Case dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Length
                    Case Is <= 30
                        clsDalAccess.Line1 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value
                        clsDalAccess.Line2 = String.Empty
                        clsDalAccess.Line3 = String.Empty
                        clsDalAccess.Line4 = String.Empty
                    Case Is <= 60
                        clsDalAccess.Line1 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Substring(0, 30)
                        clsDalAccess.Line2 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Substring(30, dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Length - 30)
                        clsDalAccess.Line3 = String.Empty
                        clsDalAccess.Line4 = String.Empty
                    Case Is <= 90
                        clsDalAccess.Line1 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Substring(0, 30)
                        clsDalAccess.Line2 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Substring(30, 30)
                        clsDalAccess.Line3 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Substring(60, dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Length - 60)
                        clsDalAccess.Line4 = String.Empty
                    Case Is <= 120
                        clsDalAccess.Line1 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Substring(0, 30)
                        clsDalAccess.Line2 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Substring(30, 30)
                        clsDalAccess.Line3 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Substring(60, 30)
                        clsDalAccess.Line4 = dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Substring(90, dgv.Rows(i).Cells("StoreAddress_nvc2").Value.ToString.Length - 90)
                End Select

                clsDalAccess.Zip = dgv.Rows(i).Cells("StorePostCode_vc2").Value.ToString
                clsDalAccess.Merchant = dgv.Rows(i).Cells("Merchant_vc").Value.ToString
                clsDalAccess.Outlet = dgv.Rows(i).Cells("Outlet_vc").Value.ToString
                clsDalAccess.Region = dgv.Rows(i).Cells("StoreStateid2").Value.ToString
                clsDalAccess.Phone2 = dgv.Rows(i).Cells("StoreTel2_Vc2").Value.ToString
                clsDalAccess.Phone1 = dgv.Rows(i).Cells("StoreTel1_Vc2").Value.ToString

                clsDalAccess.InsertTAddress()
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class