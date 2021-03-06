Public Class Frm_ViewPosInfo

    'Dim ClsDalProject As New ClassDalProject(ConnectionString)
    Dim oClsPacking As New ClassDalPAcking(ConnectionString) 'modPublicMethod.ConnectionString

    Private Enum FormMode As Short
        Add = 1
        Edit = 2
        Cancel = 3
    End Enum
    Dim MyMode As FormMode
    Private Sub Tsb_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsb_View.Click
        If CheckTxt() Then
            Dim DtPacking As New DataTable
            DtPacking = oClsPacking.GetPackingForViewPosInfo(Txt_Batch.Text)
            Dgv_Packing.AutoGenerateColumns = False
            Dgv_Packing.DataSource = DtPacking
            lbl_Count.Text = Dgv_Packing.Rows.Count.ToString
        End If
    End Sub
    Private Function CheckTxt() As Boolean

        ErrorProvider.Clear()
        Dim Ctrl As Boolean = True
        If Txt_Batch.Text = "" Then
            ErrorProvider.SetError(Txt_Batch, "شماره بچ نمی تواند خالی باشد.")
            Txt_Batch.Focus()
            Ctrl = False
        End If
        
        Return Ctrl
    End Function
    Sub fillCombo()
        Dim dtPM As New DataTable
        dtPM = oClsPacking.GetProductModel
        Cmb_PM.DataSource = dtPM
        Cmb_PM.DisplayMember = "Name_nvc"
        Cmb_PM.ValueMember = "PosModelID"

    End Sub
    Private Sub Frm_ViewPosInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            fillCombo()
            Cmb_Date.Text = GetDateNow()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub
    Private Sub Tsb_ExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tsb_ExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.Dgv_Packing)
            End If
            'ExportToExcel()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub Dgv_Packing_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dgv_Packing.SelectionChanged
        SetTexts()
    End Sub
    Private Sub SetTexts()
        Txt_EniacCode.Text = Dgv_Packing.CurrentRow.Cells("ColEniacCoder").Value.ToString
        Txt_PropertyCode.Text = Dgv_Packing.CurrentRow.Cells("ColPropertyCode").Value.ToString
        Txt_PartNo.Text = Dgv_Packing.CurrentRow.Cells("ColPartNo").Value.ToString
        Txt_PN.Text = Dgv_Packing.CurrentRow.Cells("ColPN").Value.ToString
        Txt_PosSelrial.Text = Dgv_Packing.CurrentRow.Cells("ColSerial").Value.ToString
        Cmb_PM.Text = Dgv_Packing.CurrentRow.Cells("ColPM").Value.ToString
        Cmb_Date.Text = Dgv_Packing.CurrentRow.Cells("ColDate").Value.ToString

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Dgv_Packing.Rows.Count > 0 Then
            MyMode = FormMode.Edit
            PnlEdit.Enabled = True
            Dgv_Packing.Enabled = False
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        MyMode = FormMode.Cancel
        PnlEdit.Enabled = False
        Dgv_Packing.Enabled = True

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If MyMode = FormMode.Edit Then
                If CheckTxts() Then
                    oClsPacking.UpdatePackingTBySomefields(Txt_EniacCode.Text, Txt_PosSelrial.Text, Cmb_PM.SelectedValue.ToString _
                    , Txt_PN.Text, Cmb_Date.Text, Txt_PartNo.Text)
                    PnlEdit.Enabled = False
                    Dgv_Packing.Enabled = True
                    Tsb_View_Click(Me, EventArgs.Empty)
                    MessageBox.Show("ثبت شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MyMode = FormMode.Cancel
                End If
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Function CheckTxts() As Boolean
        ErrorProvider.Clear()
        Dim Ctrl As Boolean = True
       
        If Txt_PosSelrial.Text = "" Then
            ErrorProvider.SetError(Txt_PosSelrial, "سریال دستگاه نامعتبر است")
            Ctrl = False
            Txt_PosSelrial.Focus()
        ElseIf oClsPacking.IsNotSerialInPacking(Txt_PosSelrial.Text) = False Then
            ErrorProvider.SetError(Txt_PosSelrial, "این سریال به دستگاه دیگری الصاق شده است")
            Ctrl = False
            Txt_PosSelrial.Focus()
        End If

        If Txt_PN.Text = "" Then
            ErrorProvider.SetError(Txt_PN, "PN" + "محصول نامعتبر است")
            Ctrl = False
            Txt_PN.Focus()
        End If
        If Cmb_PM.Text = "" Then
            ErrorProvider.SetError(Cmb_PM, "مدل دستگاه نامعتبر است")
            Ctrl = False
            Cmb_PM.Focus()
        End If
        If Txt_PartNo.Text = "" Then
            ErrorProvider.SetError(Txt_PartNo, "شماره پارت نامعتبر است")
            Ctrl = False
            Txt_PartNo.Focus()
        End If
        Return Ctrl
    End Function

End Class