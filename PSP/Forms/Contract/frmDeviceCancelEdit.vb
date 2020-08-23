Public Class frmDeviceCancelEdit
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private dtGrid As New DataTable

    Private Sub txtCode_vc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode_vc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                ErrPro.Clear()
                clsDalContract.BeginProc()
                GetPosCode_CancelingInfo()
            End If
        Catch ex As Exception
            ClassError.LogError(ex)
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub GetPosCode_CancelingInfo()
        Try
            If CodeValidation = False Then
                Exit Sub
            End If
            dtGrid = clsDalContract.GetByCodeDeviceCancel(txtCode_vc.Text.Trim)
            If dtGrid.Rows.Count > 0 Then
                cmbDesc_nvc.Text = dtGrid.Rows(0).Item("Desc_nvc")
                txtDeviceCancelID.Text = dtGrid.Rows(0).Item("DeviceCancelID")
                ErrPro.SetError(txtCode_vc, "")
            Else
                cmbDesc_nvc.SelectedIndex = -1
                txtDeviceCancelID.Text = -1
                ErrPro.SetError(txtCode_vc, "ÂÌç „Ê—œÌ Ì«›  ‰‘œ")
            End If
            dgv.DataSource = dtGrid
            InitGrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            dgv.Columns("DeviceCancelID").HeaderText = "ﬂœ ›”Œ"
            dgv.Columns("Date_vc").HeaderText = " «—ÌŒ ›”Œ"
            dgv.Columns("Desc_nvc").HeaderText = " Ê÷ÌÕ« "
            dgv.Columns("Serial_vc").HeaderText = "”—Ì«·"
            dgv.Columns("PropertyNo_vc").HeaderText = "‘„«—Â «„Ê«·"
            dgv.Columns("EniacCode_vc").HeaderText = "ﬂœ «‰Ì«ﬂ"
            dgv.Columns("PartNo_int").HeaderText = "‘„«—Â Å«— "
            dgv.Columns("Outlet_vc").HeaderText = "Outlet"
            dgv.Columns("StoreNmae_nvc").HeaderText = "‰«„ ›—Ê‘ê«Â"

            dgv.Columns("DeviceID").Visible = False
            dgv.Columns("PosID").Visible = False
            dgv.Columns("Flag").Visible = False
            dgv.Columns("SentToAccess_vc").Visible = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function CodeValidation() As Boolean
        Try
            If txtCode_vc.Text.Trim = String.Empty Then
                ErrPro.SetError(txtCode_vc, " —« Ê«—œ ﬂ‰Ìœpos code ")
                CodeValidation = False
            Else
                ErrPro.SetError(txtCode_vc, "")
                CodeValidation = True
            End If
        Catch ex As Exception
            CodeValidation = False
        End Try
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            clsDalContract.BeginProc()
            Me.Save()
        Catch ex As Exception
            ClassError.LogError(ex)
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub Save()
        Try
            If CodeValidation() = False Then
                Exit Sub
            End If
            If dtGrid.Rows.Count = 0 Then
                ShowErrorMessage("„Ê—œÌ »—«Ì À»  ÊÃÊœ ‰œ«—œ")
                Exit Sub
            End If
            clsDalContract.UpdateDeviceCancel(Convert.ToInt64(txtDeviceCancelID.Text.Trim), cmbDesc_nvc.Text.Trim)
            ClearForm()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ClearForm()
        Try
            txtCode_vc.Clear()
            cmbDesc_nvc.SelectedIndex = -1
            dgv.DataSource = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            ClearForm()
        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub dgv_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.RowEnter
        Try
            cmbDesc_nvc.Text = dgv.Rows(e.RowIndex).Cells("Desc_nvc").Value
            txtDeviceCancelID.Text = dgv.Rows(e.RowIndex).Cells("DeviceCancelID").Value
        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub frmDeviceCancelEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadcmbDesc()
    End Sub

    Private Sub LoadcmbDesc()

        Dim DeviceCancelDescription As New Eniac.PSP.DAL.DeviceCancelDesc
        Dim dt As DataTable = DeviceCancelDescription.SelectAll()
        Me.cmbDesc_nvc.DataSource = dt
        Me.cmbDesc_nvc.ValueMember = "DeviceCancelDescId"
        Me.cmbDesc_nvc.DisplayMember = "DeviceCancelDesc"
        Me.cmbDesc_nvc.SelectedIndex = -1

    End Sub

End Class