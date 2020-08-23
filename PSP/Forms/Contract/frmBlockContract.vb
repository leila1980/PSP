Public Class frmBlockContract
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDALPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private dt As New DataTable
    Private dtReport As New DataTable

#Region "Events"
    Private Sub btnBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlockOK.Click, btnBlockNOk.Click
        Try
            'txtContractID_Leave(sender, e)
            ErrorProvider.Clear()
            btnBlockClick(sender)
            Me.FillGrid()

        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgAddFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    'Private Sub btnBlockNOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmNOk.Click
    '    Try
    '        btnBlockClick()
    '        Me.FillGrid()
    '    Catch ex As Exception
    '        ShowErrorMessage(modApplicationMessage.msgAddFailed)
    '        ClassError.LogError(ex)
    '    End Try
    'End Sub

    Private Sub txtContractID_Leave(ByVal ByValsender As System.Object, ByVal e As System.EventArgs) Handles txtContractID.Leave
        Try
            ErrorProvider.Clear()
            If txtContractID.Text.Trim = "" Then
                Exit Sub
            End If
            clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text)
            txtContractIDLeave()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub frmBlockContract_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub

#End Region
#Region "Methods"
    Private Sub btnBlockClick(ByVal sender As Object)
        Try
            ErrorProvider.Clear()
            clsDalContract.BeginProc()
            If RequiredValidator(sender) = False Then
                Exit Sub
            End If
            If RequiredDBValidator(sender) = False Then
                Exit Sub
            End If
            Block(sender)
            txtContractID.Text = ""
            ClearForm()
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    'Private Sub btnConfirmNOkClick()
    '    Try
    '        ErrorProvider.Clear()
    '        clsDalContract.BeginProc()
    '        If RequiredValidator() = False Then
    '            Exit Sub
    '        End If
    '        If RequiredDBValidator() = False Then
    '            Exit Sub
    '        End If

    '        BlockNOK()

    '        ClearForm()

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        clsDalContract.EndProc()
    '    End Try
    'End Sub
    Private Sub ClearForm()
        clsDalContract.ContractID = -1
        txtBlockedDate_vc.Text = ""
        txtBlockedDesc_vc.Text = ""
        txtContarctingPartyName_nvc.Text = ""
        txtOutlet_vc.Text = ""
        txtStoreName_nvc.Text = ""
        txtVisitorName_nvc.Text = ""
        chkBlockedVisitorPayment_bit.Checked = False
        grp1.Enabled = False
        grp2.Enabled = False
    End Sub
    Private Function RequiredValidator(ByVal sender As Object) As Boolean
        Dim res As Boolean = True
        If txtContractID.Text.Trim = "" Then
            ErrorProvider.SetError(txtContractID, "کد قرارداد وارد نشده است")
            res = False
        Else
            ErrorProvider.SetError(txtContractID, "")
        End If
        If sender.name = "btnBlockOK" Then
            If txtBlockedDate_vc.Text.Trim = "" Then
                ErrorProvider.SetError(txtBlockedDate_vc, "تاریخ وارد نشده است")
                res = False
            Else
                ErrorProvider.SetError(txtBlockedDate_vc, "")
            End If

        End If

        Return res
    End Function
    Private Function RequiredDBValidator(ByVal sender As Object) As Boolean
        Dim res As Boolean = True
        Try
            dt.Clear()
            If sender.name = "btnBlockOK" Then
                dt = clsDalContract.GetByContractIDContrPContrStoreVisitorDevice(clsDalContract.ContractID, ClassUserLoginDataAccess.ThisUser.ProjectID)
                If dt.Rows.Count > 0 Then
                    dt.Clear()
                    dt = clsDalContract.GetByContractIDAndHavPos(clsDalContract.ContractID, ClassUserLoginDataAccess.ThisUser.ProjectID)
                    If dt.Rows.Count > 0 Then
                        ErrorProvider.SetError(txtContractID, "اين قرارداد داراي پز مي باشد و قابل مسدود شدن نيست ")
                        res = False
                    End If
                Else
                    ErrorProvider.SetError(txtContractID, "كد قرارداد نامعتبر مي باشد")
                    res = False
                End If
            ElseIf sender.name = "btnBlockNOk" Then
                dt = clsDalContract.GetByContractIDContrPContrStoreVisitorDevice(clsDalContract.ContractID, ClassUserLoginDataAccess.ThisUser.ProjectID)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0).Item("Blocked_bit")) = True OrElse dt.Rows(0).Item("Blocked_bit") = 0 Then
                        ErrorProvider.SetError(txtContractID, "كد قرارداد قبلا مسدود نشده است")
                        res = False
                    End If
                Else
                    ErrorProvider.SetError(txtContractID, "كد قرارداد نامعتبر مي باشد")
                    res = False
                End If

            End If
        Catch ex As Exception
            res = False
            Throw ex
        Finally
            RequiredDBValidator = res
        End Try
    End Function
   
    Private Sub Block(ByVal sender As Object)
        Try
            If sender.name = "btnBlockOK" Then
                clsDalContract.UpdateContractForBlock(clsDalContract.ContractID, True, txtBlockedDate_vc.Text, txtBlockedDesc_vc.Text, chkBlockedVisitorPayment_bit.Checked)
            ElseIf sender.name = "btnBlockNOk" Then
                clsDalContract.UpdateContractForBlock(clsDalContract.ContractID, False, "", "", True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Private Sub ConfirmNOK()
    '    Try
    '        Dim Detial As New Dal.InstallingDetailTemplate
    '        Detial.InstallingDetailID = Convert.ToInt64(txtContractID.Text.Trim)
    '        Detial.Ins_date = ""
    '        Detial.Ins_Time = ""
    '        Detial.Sign = 0
    '        Detial.Card = 0
    '        Detial.PurchaseReceipt = 0
    '        Detial.StockReceipt = 0
    '        Detial.Install_OK = 0
    '        clsDALInstalling.UpdateInstallingDetail(Detial)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    
    Private Sub txtContractIDLeave()
        ErrorProvider.Clear()
        Try
            clsDalContract.BeginProc()

            dt.Clear()
            dt = clsDalContract.GetByContractIDContrPContrStoreVisitorDevice(clsDalContract.ContractID, ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dt.Rows.Count > 0 Then
                clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text)
                txtContarctingPartyName_nvc.Text = dt.Rows(0).Item("ContractingPartyFullName_vc")
                If IsDBNull(dt.Rows(0).Item("StoreName_nvc")) = False Then
                    txtStoreName_nvc.Text = dt.Rows(0).Item("StoreName_nvc")
                Else
                    txtStoreName_nvc.Text = String.Empty
                End If
                If IsDBNull(dt.Rows(0).Item("VisitorFullName")) = False Then
                    txtVisitorName_nvc.Text = dt.Rows(0).Item("VisitorFullName")
                Else
                    txtVisitorName_nvc.Text = String.Empty
                End If
                If IsDBNull(dt.Rows(0).Item("outlet_vc")) = True Then
                    txtOutlet_vc.Text = ""
                Else
                    txtOutlet_vc.Text = dt.Rows(0).Item("outlet_vc")
                End If
                'txt=clsDalContract.DMerchant_vc = dt.Rows(0).Item("Blocked_bit")
                If IsDBNull(dt.Rows(0).Item("BlockedDate_vc")) = True Then
                    txtBlockedDate_vc.Text = ""
                Else
                    txtBlockedDate_vc.Text = dt.Rows(0).Item("BlockedDate_vc")
                End If
                If IsDBNull(dt.Rows(0).Item("BlockedDesc_vc")) = True Then
                    txtBlockedDesc_vc.Text = ""
                Else
                    txtBlockedDesc_vc.Text = dt.Rows(0).Item("BlockedDesc_vc")
                End If
                If IsDBNull(dt.Rows(0).Item("BlockedVisitorPayment_bit")) = True Then
                    chkBlockedVisitorPayment_bit.Checked = False
                Else
                    chkBlockedVisitorPayment_bit.Checked = dt.Rows(0).Item("BlockedVisitorPayment_bit")
                End If
                grp1.Enabled = True
                grp2.Enabled = True
            Else
                ErrorProvider.SetError(txtContractID, "كد قرارداد نامعتبر مي باشد")
                ClearForm()
            End If

        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
   
#End Region
    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvReport.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(Me.dgvReport.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReport.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReport.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub
    Private Sub frmBlockContract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clsDalContract.BeginProc()
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FillGrid()
        Try
            dtReport.Clear()
            dtReport = clsDalContract.GetByBlockedContrPContrStoreVisitorDevice(1, ClassUserLoginDataAccess.ThisUser.ProjectID)
            dgvReport.DataSource = dtReport
            dgvReport.Columns("contractID").HeaderText = "كد قرارداد"
            dgvReport.Columns("ContractingPartyFullName_vc").HeaderText = "نام طرف قرارداد"
            dgvReport.Columns("StoreName_nvc").HeaderText = "نام فروشگاه"
            dgvReport.Columns("VisitorFullName").HeaderText = "نام بازارياب"
            dgvReport.Columns("outlet_vc").HeaderText = "Outlet"
            dgvReport.Columns("Blocked_bit").Visible = False
            dgvReport.Columns("BlockedDate_vc").HeaderText = "تاريخ مسدودي"
            dgvReport.Columns("BlockedDesc_vc").HeaderText = "علت"
            dgvReport.Columns("BlockedVisitorPayment_bit").HeaderText = " حق الزحمه بازارياب"
            dgvReport.Columns("BlockedVisitorPayment_bit").Width = 150

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
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
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ErrorProvider.Clear()
        txtContractID.Text = ""
        ClearForm()
    End Sub
End Class