Public Class frmRptGetMonthlyAllInformation
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private clsDALRPT2 As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Private _DALReport As New ClassDALReport(modPublicMethod.ConnectionString)

    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim strFilter As String
    Private DateFrom As String = ""
    Private DateTO As String = ""
    Private VisitorID As String = String.Empty
    Private Vocher As Byte = 0
    Private Sale As Byte = 0
    Private Bill As Byte = 0
    Private Mojudi As Byte = 0
    Private dtdgv As New DataTable
    Private dvdgv As DataView

#Region "Events"

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvReport)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub frmRptGetMonthlyAllInformation_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub frmRptGetMonthlyAllInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            rdoMonth.Checked = True

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

    Private Sub frmRptGetMonthlyAllInformation_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        DisposConnection()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        FillGrid()
    End Sub

    Private Sub txtFromTransaction_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub txtToTransaction_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub txtFromPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFromPrice.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub txtToPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToPrice.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8)) Or (e.KeyChar = Chr(13))) Then e.KeyChar = Nothing
    End Sub

    Private Sub dgvReport_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReport.CellClick
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If e.ColumnIndex = dgvReport.Columns.Count - 1 Then
            Dim MonthDays As String = String.Empty
            Dim Month As String = String.Empty
            Dim Year As String = String.Empty
            Dim _Frm As New frmRptAuthorizationDetail
            _Frm.lblName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("FullName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("FullName").Value)
            _Frm.lblOutlet.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value)
            _Frm.lblCancelDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value)
            _Frm.lblInstallDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value)
            _Frm.lblMerchant.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value)
            _Frm.lblState.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value)
            _Frm.lblStoreName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("StoreName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("StoreName").Value)
            _Frm.lblVisitor.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value)
            _Frm.txtFromPrice.Text = txtFromPrice.Text
            _Frm.txtToPrice.Text = txtToPrice.Text
            _Frm.chkParent.Checked = chkParent.Checked
            _Frm.chkParent.Visible = chkParent.Visible

            _Frm.cmbTransactionState.SelectedIndex = cmbTransactionState.SelectedIndex
            For Counter As Integer = 0 To ChkList.CheckedItems.Count - 1
                Select Case ChkList.CheckedItems.Item(Counter)
                    Case "شارژ"
                        _Frm.ChkList.SetItemChecked(0, True)
                        _Frm.Vocher = 1
                    Case "خرید"
                        _Frm.ChkList.SetItemChecked(1, True)
                        _Frm.Sale = 1
                    Case "پرداخت قبض"
                        _Frm.ChkList.SetItemChecked(2, True)
                        _Frm.Bill = 1
                    Case "موجودی"
                        _Frm.ChkList.SetItemChecked(3, True)
                        _Frm.Mojudi = 1
                End Select
            Next

            Select Case cboToMonth.SelectedIndex
                Case Is < 6
                    MonthDays = "31"
                Case 6 To 10
                    MonthDays = "30"
                Case 11
                    txtDate.Value = cboToYear.SelectedValue + "/" + cboToMonth.SelectedIndex.ToString.PadLeft(2, "0") + "/30"
                    If txtDate.Value = "" Then
                        MonthDays = "29"
                    Else
                        MonthDays = "30"
                    End If
            End Select

            DateFrom = cboFromYear.SelectedValue + "/" + (cboFromMonth.SelectedIndex + 1).ToString.PadLeft(2, "0") + "/01"
            DateTO = cboToYear.SelectedValue + "/" + (cboToMonth.SelectedIndex + 1).ToString.PadLeft(2, "0") + "/" + MonthDays

            _Frm.rucDate.txtDateFrom.Value = DateFrom
            _Frm.rucDate.txtDateTo.Value = DateTO
            _Frm.DateFrom = DateFrom
            _Frm.DateTO = DateTO
            _Frm.ShowDialog()
        End If
    End Sub

    Private Sub dgvReport_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReport.CellDoubleClick
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub

        Dim MonthDays As String = String.Empty
        Dim Month As String = String.Empty
        Dim Year As String = String.Empty

        If ((e.ColumnIndex = dgvReport.Columns.Count - 1) _
                Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountColumnShetabi".ToLower) = True) _
                Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountColumnNotShetabi".ToLower) = True) _
                Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountColumnALL".ToLower) = True) _
                Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("SumColumnNotShetabi".ToLower) = True) _
                Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("SumColumnShetabi".ToLower) = True) _
                Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("SumColumnALL".ToLower) = True) _
            ) Then

            Dim _Frm As New frmRptAuthorizationDetail
            _Frm.lblName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("FullName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("FullName").Value)
            _Frm.lblOutlet.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value)
            _Frm.lblCancelDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value)
            _Frm.lblInstallDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value)
            _Frm.lblMerchant.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value)
            _Frm.lblState.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value)
            _Frm.lblStoreName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("StoreName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("StoreName").Value)
            _Frm.lblVisitor.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value)
            _Frm.txtFromPrice.Text = txtFromPrice.Text
            _Frm.txtToPrice.Text = txtToPrice.Text
            _Frm.chkParent.Checked = chkParent.Checked
            _Frm.chkParent.Visible = chkParent.Visible

            _Frm.cmbTransactionState.SelectedIndex = cmbTransactionState.SelectedIndex
            For Counter As Integer = 0 To ChkList.CheckedItems.Count - 1
                Select Case ChkList.CheckedItems.Item(Counter)
                    Case "شارژ"
                        _Frm.ChkList.SetItemChecked(0, True)
                        _Frm.Vocher = 1
                    Case "خرید"
                        _Frm.ChkList.SetItemChecked(1, True)
                        _Frm.Sale = 1
                    Case "پرداخت قبض"
                        _Frm.ChkList.SetItemChecked(2, True)
                        _Frm.Bill = 1
                    Case "موجودی"
                        _Frm.ChkList.SetItemChecked(3, True)
                        _Frm.Mojudi = 1
                End Select
            Next
            If e.ColumnIndex = dgvReport.Columns.Count - 1 Then
                Select Case cboToMonth.SelectedIndex
                    Case Is < 6
                        MonthDays = "31"
                    Case 6 To 10
                        MonthDays = "30"
                    Case 11
                        txtDate.Value = cboToYear.SelectedValue + "/" + cboToMonth.SelectedIndex.ToString.PadLeft(2, "0") + "/30"
                        If txtDate.Value = "" Then
                            MonthDays = "29"
                        Else
                            MonthDays = "30"
                        End If
                End Select

                DateFrom = cboFromYear.SelectedValue + "/" + (cboFromMonth.SelectedIndex + 1).ToString.PadLeft(2, "0") + "/01"
                DateTO = cboToYear.SelectedValue + "/" + (cboToMonth.SelectedIndex + 1).ToString.PadLeft(2, "0") + "/" + MonthDays

            ElseIf dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountColumnShetabi".ToLower) = True Then
                Year = dgvReport.Columns(e.ColumnIndex).Name.Substring("CountColumnShetabi".Length, 4)
                Month = dgvReport.Columns(e.ColumnIndex).Name.Substring("CountColumnShetabi".Length + 4, 2)
                Select Case Convert.ToInt16(Month)
                    Case Is <= 6
                        MonthDays = "31"
                    Case 7 To 11
                        MonthDays = "30"
                    Case 12
                        txtDate.Value = Year + "/" + Month.ToString.PadLeft(2, "0") + "/30"
                        If txtDate.Value = "" Then
                            MonthDays = "29"
                        Else
                            MonthDays = "30"
                        End If
                End Select

                DateFrom = Year + "/" + Month.ToString.PadLeft(2, "0") + "/01"
                DateTO = Year + "/" + Month.ToString.PadLeft(2, "0") + "/" + MonthDays

            ElseIf dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountColumnNotShetabi".ToLower) = True Then
                Year = dgvReport.Columns(e.ColumnIndex).Name.Substring("CountColumnNotShetabi".Length, 4)
                Month = dgvReport.Columns(e.ColumnIndex).Name.Substring("CountColumnNotShetabi".Length + 4, 2)
                Select Case Convert.ToInt16(Month)
                    Case Is <= 6
                        MonthDays = "31"
                    Case 7 To 11
                        MonthDays = "30"
                    Case 12
                        txtDate.Value = Year + "/" + Month.ToString.PadLeft(2, "0") + "/30"
                        If txtDate.Value = "" Then
                            MonthDays = "29"
                        Else
                            MonthDays = "30"
                        End If
                End Select

                DateFrom = Year + "/" + Month.ToString.PadLeft(2, "0") + "/01"
                DateTO = Year + "/" + Month.ToString.PadLeft(2, "0") + "/" + MonthDays
            ElseIf (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountColumnALL".ToLower) = True) Then
                Year = dgvReport.Columns(e.ColumnIndex).Name.Substring("CountColumnALL".Length, 4)
                Month = dgvReport.Columns(e.ColumnIndex).Name.Substring("CountColumnALL".Length + 4, 2)
                Select Case Convert.ToInt16(Month)
                    Case Is <= 6
                        MonthDays = "31"
                    Case 7 To 11
                        MonthDays = "30"
                    Case 12
                        txtDate.Value = Year + "/" + Month.ToString.PadLeft(2, "0") + "/30"
                        If txtDate.Value = "" Then
                            MonthDays = "29"
                        Else
                            MonthDays = "30"
                        End If
                End Select

                DateFrom = Year + "/" + Month.ToString.PadLeft(2, "0") + "/01"
                DateTO = Year + "/" + Month.ToString.PadLeft(2, "0") + "/" + MonthDays
            ElseIf dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("SumColumnShetabi".ToLower) = True Then
                Year = dgvReport.Columns(e.ColumnIndex).Name.Substring("SumColumnShetabi".Length, 4)
                Month = dgvReport.Columns(e.ColumnIndex).Name.Substring("SumColumnShetabi".Length + 4, 2)
                Select Case Convert.ToInt16(Month)
                    Case Is <= 6
                        MonthDays = "31"
                    Case 7 To 11
                        MonthDays = "30"
                    Case 12
                        txtDate.Value = Year + "/" + Month.ToString.PadLeft(2, "0") + "/30"
                        If txtDate.Value = "" Then
                            MonthDays = "29"
                        Else
                            MonthDays = "30"
                        End If
                End Select

                DateFrom = Year + "/" + Month.ToString.PadLeft(2, "0") + "/01"
                DateTO = Year + "/" + Month.ToString.PadLeft(2, "0") + "/" + MonthDays

            ElseIf dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("SumColumnNotShetabi".ToLower) = True Then
                Year = dgvReport.Columns(e.ColumnIndex).Name.Substring("SumColumnNotShetabi".Length, 4)
                Month = dgvReport.Columns(e.ColumnIndex).Name.Substring("SumColumnNotShetabi".Length + 4, 2)
                Select Case Convert.ToInt16(Month)
                    Case Is <= 6
                        MonthDays = "31"
                    Case 7 To 11
                        MonthDays = "30"
                    Case 12
                        txtDate.Value = Year + "/" + Month.ToString.PadLeft(2, "0") + "/30"
                        If txtDate.Value = "" Then
                            MonthDays = "29"
                        Else
                            MonthDays = "30"
                        End If
                End Select

                DateFrom = Year + "/" + Month.ToString.PadLeft(2, "0") + "/01"
                DateTO = Year + "/" + Month.ToString.PadLeft(2, "0") + "/" + MonthDays
            ElseIf (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("SumColumnALL".ToLower) = True) Then
                Year = dgvReport.Columns(e.ColumnIndex).Name.Substring("SumColumnALL".Length, 4)
                Month = dgvReport.Columns(e.ColumnIndex).Name.Substring("SumColumnALL".Length + 4, 2)
                Select Case Convert.ToInt16(Month)
                    Case Is <= 6
                        MonthDays = "31"
                    Case 7 To 11
                        MonthDays = "30"
                    Case 12
                        txtDate.Value = Year + "/" + Month.ToString.PadLeft(2, "0") + "/30"
                        If txtDate.Value = "" Then
                            MonthDays = "29"
                        Else
                            MonthDays = "30"
                        End If
                End Select

                DateFrom = Year + "/" + Month.ToString.PadLeft(2, "0") + "/01"
                DateTO = Year + "/" + Month.ToString.PadLeft(2, "0") + "/" + MonthDays
            Else
                Exit Sub
            End If
            _Frm.rucDate.txtDateFrom.Value = DateFrom
            _Frm.rucDate.txtDateTo.Value = DateTO
            _Frm.DateFrom = DateFrom
            _Frm.DateTO = DateTO
            _Frm.ShowDialog()

        ElseIf (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("LastBazdid".ToLower) = True) Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountBazdid".ToLower) = True) Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("MorediLastBazdid".ToLower) = True) Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("MorediCountBazdid".ToLower) = True) Then
            Dim _Frm As New frmRptGetBazdidTransaction

            Select Case cboToMonth.SelectedIndex
                Case Is < 6
                    MonthDays = "31"
                Case 6 To 10
                    MonthDays = "30"
                Case 11
                    txtDate.Value = cboToYear.SelectedValue + "/" + (cboToMonth.SelectedIndex + 1).ToString.PadLeft(2, "0") + "/30"
                    If txtDate.Value = "" Then
                        MonthDays = "29"
                    Else
                        MonthDays = "30"
                    End If
            End Select

            DateTO = cboToYear.SelectedValue + "/" + (cboToMonth.SelectedIndex + 1).ToString.PadLeft(2, "0") + "/" + MonthDays

            _Frm.lblName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("FullName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("FullName").Value)
            _Frm.lblOutlet.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Outlet_vc").Value)
            _Frm.lblCancelDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("CancelDate").Value)
            _Frm.lblInstallDate.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("InstallDate").Value)
            _Frm.lblMerchant.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("Merchant_vc").Value)
            _Frm.lblState.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("PosStatus").Value)
            _Frm.lblStoreName.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("StoreName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("StoreName").Value)
            _Frm.lblVisitor.Text = IIf(dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value Is DBNull.Value, String.Empty, dgvReport.Rows(e.RowIndex).Cells("VisitorName").Value)
            _Frm.txtAdvariToPrice.Text = txtAdvariToPrice.Text
            _Frm.txtMorediToPrice.Text = txtMorediToPrice.Text
            _Frm.chkParent.Checked = chkParent.Checked
            _Frm.chkParent.Visible = chkParent.Visible

            If (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("LastBazdid".ToLower) = True) Or (dgvReport.Columns(e.ColumnIndex).Name.ToLower.StartsWith("CountBazdid".ToLower) = True) Then
                _Frm.Type = 1
            Else
                _Frm.Type = 2
            End If

            _Frm.rucDate.txtDateFrom.Value = String.Empty
            _Frm.rucDate.txtDateTo.Value = DateTO
            _Frm.DateTO = DateTO

            _Frm.ShowDialog()
        End If
    End Sub

    Private Sub dgvReport_ColumnAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvReport.ColumnAdded
        Dim Month As String = String.Empty
        Dim MonthName As String = String.Empty
        If e.Column.HeaderText.ToLower.StartsWith("CountColumnShetabi".ToLower) = True Then
            Month = e.Column.HeaderText.Substring("CountColumnShetabi".Length + 4, 2)
            e.Column.DefaultCellStyle.Format = "N0"
        ElseIf e.Column.HeaderText.ToLower.StartsWith("CountColumnNotShetabi".ToLower) = True Then
            Month = e.Column.HeaderText.Substring("CountColumnNotShetabi".Length + 4, 2)
            e.Column.DefaultCellStyle.Format = "N0"
        ElseIf e.Column.HeaderText.ToLower.StartsWith("CountColumnALL".ToLower) = True Then
            Month = e.Column.HeaderText.Substring("CountColumnALL".Length + 4, 2)
            e.Column.DefaultCellStyle.Format = "N0"
        ElseIf e.Column.HeaderText.ToLower.StartsWith("SumColumnShetabi".ToLower) = True Then
            Month = e.Column.HeaderText.Substring("SumColumnShetabi".Length + 4, 2)
            e.Column.DefaultCellStyle.Format = "N0"
        ElseIf e.Column.HeaderText.ToLower.StartsWith("SumColumnNotShetabi".ToLower) = True Then
            Month = e.Column.HeaderText.Substring("SumColumnNotShetabi".Length + 4, 2)
            e.Column.DefaultCellStyle.Format = "N0"
        ElseIf e.Column.HeaderText.ToLower.StartsWith("SumColumnALL".ToLower) = True Then
            Month = e.Column.HeaderText.Substring("SumColumnALL".Length + 4, 2)
            e.Column.DefaultCellStyle.Format = "N0"
        End If

        If Month <> String.Empty Then
            MonthName = FarsiLibrary.Utils.PersianDate.PersianMonthNames.Default(Month)
        End If
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("CountColumnShetabi".ToLower, "تعداد شتابی ")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("CountColumnNotShetabi".ToLower, "تعداد غیر شتابی ")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("SumColumnShetabi".ToLower, "مبلغ شتابی ")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("SumColumnNotShetabi".ToLower, "مبلغ غیر شتابی ")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("CountColumnALL".ToLower, "تعداد تراکنشهای ماه ")
        e.Column.HeaderText = e.Column.HeaderText.ToLower.Replace("SumColumnALL".ToLower, "مبلغ تراکنشهای ماه ")
        If Not Month = String.Empty Then
            e.Column.HeaderText = e.Column.HeaderText.Replace(Month, " " + MonthName)
        End If

    End Sub

    Private Sub dgvReport_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvReport.RowPrePaint
        Dim dataGridView As DataGridView = sender
        dataGridView.Item("colRowNumber", e.RowIndex).Value = e.RowIndex + 1
    End Sub

#End Region

#Region "Methods"

    Private Sub InitialForms()
        SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        If ClassUserLoginDataAccess.dtUserRightOnControls.Rows.Count > 0 Then
            Dim dr() As DataRow = ClassUserLoginDataAccess.dtUserRightOnControls.Select("ControlName_nvc = 'chkParent' And FormID = 81")
            If (dr.Length = 0) Then
                chkParent.Visible = False
            Else
                chkParent.Visible = dr(0)("Value_vc")
            End If
        Else
            chkParent.Visible = False
        End If
    End Sub

    Private Sub FormLoad()
        Try
            cmbTransactionState.SelectedIndex = 1
            FillCombo()
            cmbVisitor.SelectedIndex = 0
            InitialForms()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetTransactionType()
        Vocher = 0
        Sale = 0
        Bill = 0
        Mojudi = 0
        For Counter As Integer = 0 To ChkList.CheckedItems.Count - 1
            Select Case ChkList.CheckedItems.Item(Counter)
                Case "شارژ"
                    Vocher = 1
                Case "خرید"
                    Sale = 1
                Case "پرداخت قبض"
                    Bill = 1
                Case "موجودی"
                    Mojudi = 1
            End Select
        Next
    End Sub

    Private Function RequiredValidator() As Boolean
        Try
            Dim res As Boolean = True
            If cboFromYear.SelectedIndex = -1 Then
                ErrorProvider.SetError(cboFromYear, "سال از تاریخ را انتخاب کنید")
                res = False
            Else
                ErrorProvider.SetError(cboFromYear, "")
            End If
            If cboToYear.SelectedIndex = -1 Then
                ErrorProvider.SetError(cboToYear, "سال تا تاریخ را انتخاب کنید")
                res = False
            Else
                ErrorProvider.SetError(cboToYear, "")
            End If

            SetTransactionType()
            If Vocher = 0 And Sale = 0 And Bill = 0 And Mojudi = 0 Then
                ErrorProvider.SetError(ChkList, "هیچ یک از انواع تراکنش انتخاب نشده است")
                res = False
            Else
                ErrorProvider.SetError(ChkList, "")
            End If
            Return res

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub FillGrid()
        Try
            If RequiredValidator() = False Then
                Exit Sub
            End If

            Dim dt As DataTable
            If cmbVisitor.SelectedValue = 0 Then
                dt = cmbVisitor.DataSource
                If dt.Rows(0)("State") = 0 Then
                    VisitorID = String.Empty
                Else
                    For Each dr As DataRow In dt.Select(" VisitorID <> 0 ")
                        If VisitorID = String.Empty Then
                            VisitorID = dr("VisitorID").ToString
                        Else
                            VisitorID = VisitorID & " ," & dr("VisitorID").ToString
                        End If
                    Next
                End If
            Else
                VisitorID = Convert.ToString(cmbVisitor.SelectedValue)
            End If

            DateFrom = cboFromYear.SelectedValue + "/" + (cboFromMonth.SelectedIndex + 1).ToString.PadLeft(2, "0")
            DateTO = cboToYear.SelectedValue + "/" + (cboToMonth.SelectedIndex + 1).ToString.PadLeft(2, "0")



            dgvReport.DataSource = ""
            dvdgv = New DataView
            dgvReport.Columns.Clear()

            Dim ColumnRowNumber As New DataGridViewTextBoxColumn()
            ColumnRowNumber.Name = "colRowNumber"
            ColumnRowNumber.HeaderText = "ردیف"
            dgvReport.Columns.Add(ColumnRowNumber)

            If rdoMonth.Checked Then
                dtdgv = clsDALRPT2.GetMonthlyAllInformation(VisitorID, DateFrom, DateTO, txtFromPrice.Text, txtToPrice.Text, Vocher, Sale, Bill, Mojudi, cmbTransactionState.SelectedIndex, cmbProject.SelectedValue, chkParent.Checked, txtAdvariToPrice.Text, txtMorediToPrice.Text)
            ElseIf rdoBankMonh.Checked Then
                dtdgv = clsDALRPT2.GetMonthlyAllInformation_BankMonthBased(VisitorID, DateFrom, DateTO, txtFromPrice.Text, txtToPrice.Text, Vocher, Sale, Bill, Mojudi, cmbTransactionState.SelectedIndex, cmbProject.SelectedValue, chkParent.Checked, txtAdvariToPrice.Text, txtMorediToPrice.Text)
            End If

            dgvReport.DataSource = dtdgv
            dvdgv = dtdgv.DefaultView

            Dim Column As New DataGridViewButtonColumn()
            Column.Name = "btnColumn"
            Column.HeaderText = "نمايش ريز تراکنش"
            Column.Text = "نمايش ريز تراکنش"
            Column.UseColumnTextForButtonValue = True
            dgvReport.Columns.Add(Column)

            InitGrid()

            Dim clsSearch As New ClassSearch
            clsSearch.Init(cboSearchField, cboSearchOperation, txtSearch, btnSearch, btnSearchBack, btnRemoveFilter, dgvReport, dtdgv, dvdgv)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub InitGrid()
        dgvReport.Columns("FullName").HeaderText = "نام"
        dgvReport.Columns("Outlet_vc").HeaderText = "کد پایانه"
        dgvReport.Columns("Merchant_vc").HeaderText = "کد پذیرنده"
        dgvReport.Columns("Serial_vc").HeaderText = "سریال"
        dgvReport.Columns("PropertyNo_vc").HeaderText = "کد اموال"
        dgvReport.Columns("EniacCode_vc").HeaderText = "کد پیگیری"
        dgvReport.Columns("AppVersion").HeaderText = "ورژن"
        dgvReport.Columns("VisitorName").HeaderText = "بازاریاب"
        dgvReport.Columns("StoreName").HeaderText = "نام فروشگاه"
        dgvReport.Columns("StateName").HeaderText = "نام استان"
        dgvReport.Columns("CityName").HeaderText = "نام شهر"
        dgvReport.Columns("Tel1_vc").HeaderText = "تلفن"
        dgvReport.Columns("Address_nvc").HeaderText = "آدرس"
        dgvReport.Columns("PosStatus").HeaderText = "وضعیت"
        dgvReport.Columns("LastDate").HeaderText = "آخرین تراکنش خرید موفق"
        dgvReport.Columns("InstallDate").HeaderText = "تاریخ نصب"
        dgvReport.Columns("PeykarBandi").HeaderText = "تاریخ پیکربندی"
        dgvReport.Columns("CancelDate").HeaderText = "تاریخ فسخ"

        dgvReport.Columns("LastBazdid").HeaderText = "آخرین بازدید ادواری"
        dgvReport.Columns("CountBazdid").HeaderText = "تعداد بازدید ادواری"
        dgvReport.Columns("MorediLastBazdid").HeaderText = "آخرین بازدید موردی"
        dgvReport.Columns("MorediCountBazdid").HeaderText = "تعداد بازدید موردی"

        dgvReport.Columns("PostCode_vc").HeaderText = "کد پستی"


        lblCount.Text = dgvReport.Rows.Count
    End Sub

    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        End If
    End Sub

    Private Sub DisposConnection()
        cnt.Close()
        cnt.Dispose()
        cnt = Nothing
    End Sub

    Private Sub FillCombo()
        Try
            OPenConnection()

            cboFromYear.DataSource = _DALReport.GetYear()
            Me.cboFromYear.DisplayMember = "ContractYear"
            Me.cboFromYear.ValueMember = "ContractYear"
            cboToYear.DataSource = _DALReport.GetYear()
            Me.cboToYear.DisplayMember = "ContractYear"
            Me.cboToYear.ValueMember = "ContractYear"
            cboFromYear.SelectedIndex = cboFromYear.Items.Count - 1
            cboToYear.SelectedIndex = cboToYear.Items.Count - 1
            cboFromMonth.SelectedIndex = 0
            cboToMonth.SelectedIndex = 11
            Me.cmbVisitor.DisplayMember = "FullName"
            Me.cmbVisitor.ValueMember = "VisitorID"
            Me.cmbVisitor.DataSource = clsDALVisitor.GetAllVisitorByUserID_ForCbo(ClassUserLoginDataAccess.ThisUser.UserID) 'clsDALVisitor.GetAllVisitor_ForCbo
            Dim clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

            Me.cmbProject.DataSource = clsDALProject.GetAllForUCtrl(ClassUserLoginDataAccess.ThisUser.UserID)
            Me.cmbProject.ValueMember = "ProjectID_tint"
            Me.cmbProject.DisplayMember = "Name_nvc"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class