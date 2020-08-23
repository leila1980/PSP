Public Class frmDeviceCancelMakeFile
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private dt As New DataTable
    Private dtDeviceCancel As New DataTable

    Private Sub frmDeviceCancelMakeFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub FormLoad()
        Try
            clsDalContract.BeginProc()
            Me.Init()
            Me.FillGrid()
            rdoAll.Checked = True
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub Init()
        Me.dgvDeviceCancel.AutoGenerateColumns = False




        Dim colCheck As New System.Windows.Forms.DataGridViewCheckBoxColumn
        colCheck.DataPropertyName = "Check"
        colCheck.HeaderText = ""
        colCheck.Name = "colCheck"
        colCheck.ReadOnly = False
        colCheck.Width = 50
        Me.dgvDeviceCancel.Columns.Add(colCheck)


        Dim colContractID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractID.DataPropertyName = "ContractID"
        colContractID.HeaderText = "کد قرارداد"
        colContractID.Name = "colContractID"
        colContractID.ReadOnly = True
        Me.dgvDeviceCancel.Columns.Add(colContractID)

        Dim colFullName As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFullName.DataPropertyName = "FullName"
        colFullName.HeaderText = "نام و نام خانوادگی"
        colFullName.Name = "colFullName"
        colFullName.ReadOnly = True
        colFullName.Width = 160
        Me.dgvDeviceCancel.Columns.Add(colFullName)

        Dim colSStoreID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSStoreID.DataPropertyName = "SStoreID"
        colSStoreID.HeaderText = ""
        colSStoreID.Name = "colSStoreID"
        colSStoreID.Visible = False
        Me.dgvDeviceCancel.Columns.Add(colSStoreID)

        Dim colSName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSName_nvc.DataPropertyName = "SName_nvc"
        colSName_nvc.HeaderText = "نام فروشگاه"
        colSName_nvc.Name = "colSName_nvc"
        colSName_nvc.ReadOnly = True
        Me.dgvDeviceCancel.Columns.Add(colSName_nvc)

        Dim colDPCDeviceID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDPCDeviceID.DataPropertyName = "DPCDeviceID"
        colDPCDeviceID.HeaderText = ""
        colDPCDeviceID.Name = "colDPCDeviceID"
        colDPCDeviceID.Visible = False
        Me.dgvDeviceCancel.Columns.Add(colDPCDeviceID)

        Dim colDPCPosID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDPCPosID.DataPropertyName = "DPCPosID"
        colDPCPosID.HeaderText = ""
        colDPCPosID.Name = "colDPCPosID"
        colDPCPosID.Visible = False
        Me.dgvDeviceCancel.Columns.Add(colDPCPosID)

        Dim colDPCCount_int As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDPCCount_int.DataPropertyName = "DPCCount_int"
        colDPCCount_int.HeaderText = ""
        colDPCCount_int.Name = "colDPCCount_int"
        colDPCCount_int.Visible = False
        Me.dgvDeviceCancel.Columns.Add(colDPCCount_int)

        Dim colDStoreID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDStoreID.DataPropertyName = "DStoreID"
        colDStoreID.HeaderText = ""
        colDStoreID.Name = "colDStoreID"
        colDStoreID.Visible = False
        Me.dgvDeviceCancel.Columns.Add(colDStoreID)

        Dim colDCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDCode_vc.DataPropertyName = "DCode_vc"
        colDCode_vc.HeaderText = "Pos Code"
        colDCode_vc.Name = "colDCode_vc"
        colDCode_vc.ReadOnly = True
        Me.dgvDeviceCancel.Columns.Add(colDCode_vc)

        Dim colDOutlet_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDOutlet_vc.DataPropertyName = "DOutlet_vc"
        colDOutlet_vc.HeaderText = "outlet"
        colDOutlet_vc.Name = "colDOutlet_vc"
        colDOutlet_vc.ReadOnly = True
        Me.dgvDeviceCancel.Columns.Add(colDOutlet_vc)

        Dim colDMerchant_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDMerchant_vc.DataPropertyName = "DMerchant_vc"
        colDMerchant_vc.HeaderText = "Merchant"
        colDMerchant_vc.Name = "colDMerchant_vc"
        colDMerchant_vc.ReadOnly = True
        Me.dgvDeviceCancel.Columns.Add(colDMerchant_vc)

        Dim colDVat_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDVat_vc.DataPropertyName = "DVat_vc"
        colDVat_vc.HeaderText = "Vat"
        colDVat_vc.Name = "colDVat_vc"
        colDVat_vc.ReadOnly = True
        Me.dgvDeviceCancel.Columns.Add(colDVat_vc)

        Dim colDPosID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDPosID.DataPropertyName = "DPosID"
        colDPosID.HeaderText = "شماره"
        colDPosID.Name = "colDPosID"
        colDPosID.Visible = False
        Me.dgvDeviceCancel.Columns.Add(colDPosID)

        Dim colPSerial_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPSerial_vc.DataPropertyName = "PSerial_vc"
        colPSerial_vc.HeaderText = "سریال دستگاه"
        colPSerial_vc.Name = "colPSerial_vc"
        colPSerial_vc.ReadOnly = True
        Me.dgvDeviceCancel.Columns.Add(colPSerial_vc)

        Dim colPPropertyNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPPropertyNo_vc.DataPropertyName = "PPropertyNo_vc"
        colPPropertyNo_vc.HeaderText = "شماره اموال"
        colPPropertyNo_vc.Name = "colPPropertyNo_vc"
        colPPropertyNo_vc.ReadOnly = True
        Me.dgvDeviceCancel.Columns.Add(colPPropertyNo_vc)

        Dim colPEniacCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPEniacCode_vc.DataPropertyName = "PEniacCode_vc"
        colPEniacCode_vc.HeaderText = "کد پیگیری "
        colPEniacCode_vc.Name = "colPEniacCode_vc"
        colPEniacCode_vc.ReadOnly = True
        Me.dgvDeviceCancel.Columns.Add(colPEniacCode_vc)

        Dim colDCDeviceCancelID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDCDeviceCancelID.DataPropertyName = "DCDeviceCancelID"
        colDCDeviceCancelID.HeaderText = ""
        colDCDeviceCancelID.Name = "colDCDeviceCancelID"
        colDCDeviceCancelID.Visible = False
        Me.dgvDeviceCancel.Columns.Add(colDCDeviceCancelID)

        Dim colDCSentToAccess_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDCSentToAccess_vc.DataPropertyName = "DCSentToAccess_vc"
        colDCSentToAccess_vc.HeaderText = "تاریخ تولید فایل "
        colDCSentToAccess_vc.Name = "colDCSentToAccess_vc"
        colDCSentToAccess_vc.ReadOnly = True
        colDCSentToAccess_vc.Width = 150
        Me.dgvDeviceCancel.Columns.Add(colDCSentToAccess_vc)

        Dim colDCDate_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDCDate_vc.DataPropertyName = "DCDate_vc"
        colDCDate_vc.HeaderText = "تاریخ فسخ پز"
        colDCDate_vc.Name = "colDCDate_vc"
        colDCDate_vc.ReadOnly = True
        colDCDate_vc.Width = 150
        Me.dgvDeviceCancel.Columns.Add(colDCDate_vc)

    End Sub
    Private Sub FillGrid()
        Try
            dtDeviceCancel = clsDalContract.GetAllRealCanceledDeviceContractingParty_Contract_Account_Store_Device_Pos(ClassUserLoginDataAccess.ThisUser.ProjectID)

            Dim colCheck As New DataColumn()
            colCheck.DefaultValue = False
            colCheck.AllowDBNull = False
            colCheck.ColumnName = "Check"
            colCheck.DataType = GetType(Boolean)
            Me.dtDeviceCancel.Columns.Add(colCheck)

            dgvDeviceCancel.DataSource = dtDeviceCancel
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Filter()
        Dim dvDeviceCancel As DataView = dtDeviceCancel.DefaultView

        If rdoAll.Checked Then
            dvDeviceCancel.RowFilter = ""
        Else
            dvDeviceCancel.RowFilter = "DCSentToAccess_vc Is Null "
        End If
    End Sub

    Private Sub rdoAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAll.CheckedChanged
        Try
            If rdoAll.Checked = True Then
                Filter()
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub rdoNotSent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNotSent.CheckedChanged
        Try
            If rdoNotSent.Checked = True Then
                Filter()
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try

    End Sub

    Private Sub btnMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmakeFile.Click
        Try
            btnMakeFileClick()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnMakeFileClick()
        Try
            clsDalContract.BeginProc()
            Me.MakeAccess()
            Me.FillGrid()
            Me.Filter()
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub MakeAccess()
        Try
            Dim Count As Int32
            Dim CountDeviceID As Int32
            Dim CountCanceledDeviceID As Int32
            Dim strDateNow As String = GetDateNow()


            Dim dr() As DataRow = Me.dtDeviceCancel.Select("Check=1")
            If dr.Length = 0 Then
                modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If

            'For i As Int32 = 0 To dgvDeviceCancel.Rows.Count - 1
            '    If dgvDeviceCancel.Rows(i).Cells("colCheck").Value = True Then
            '        Count += 1
            '    End If
            'Next
            'If Count = 0 Then
            '    modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
            '    Exit Sub
            'End If


            Dim Access As New ClassDALAccessDeviceCancel
            Access.ConnectionOpen()
            Access.DeleteALLTCancellation()
            'For i As Int32 = 0 To dgvDeviceCancel.Rows.Count - 1
            For i As Integer = 0 To dr.Length - 1
                'If dgvDeviceCancel.Rows(i).Cells("colCheck").Value = True Then
                Access.Pos_Code = dr(i).Item("DCode_vc").ToString 'dgvDeviceCancel.Rows(i).Cells("DCode_vc").Value
                clsDalContract.CheckForStoreCancel(dr(i).Item("SStoreID").ToString, CountDeviceID, CountCanceledDeviceID)
                If CountDeviceID = CountCanceledDeviceID Then
                    Access.Pos = True
                    Access.Outlet = True
                    Access.Merchant = True
                Else
                    Access.Pos = True
                    Access.Outlet = True
                    Access.Merchant = False
                End If
                Access.InsertTCancellation()
                clsDalContract.UpdateDeviceCancel_OnlySentToAccess(dr(i).Item("DCDeviceCancelID"), strDateNow)
                'End If
                'Next
            Next
            Access.ConnectionClose()
            ShowMessage(msgSuccess)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvDeviceCancel.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(Me.dgvDeviceCancel.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvDeviceCancel.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvDeviceCancel.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvDeviceCancel.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvDeviceCancel.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub
    Public Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        Me.dtDeviceCancel.AcceptChanges()
        btnUnSelect_Click(sender, e)
        Dim dr() As DataRow = Me.dtDeviceCancel.Select(Me.dtDeviceCancel.DefaultView.RowFilter)
        For i As Integer = 0 To dr.Length - 1
            dr(i).Item("Check") = 1
        Next
    End Sub
    Public Sub btnUnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnSelect.Click
        Me.dtDeviceCancel.AcceptChanges()
        For Each dr As DataRow In Me.dtDeviceCancel.Rows
            dr.Item("Check") = 0
        Next
    End Sub
    Public Sub InventSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventSelect.Click
        For Each dr As DataRow In Me.dtDeviceCancel.Rows
            dr.Item("Check") = Not dr.Item("Check")
        Next
    End Sub

    Private Sub btnSendToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvDeviceCancel)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
End Class