Public Class frmTransferVisitor
    Private dtOldVisitor As New DataTable
    Private dtNewVisitor As New DataTable
    Private clsDalVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalPosVisitor As New ClassDALPosVisitor(modPublicMethod.ConnectionString)

    Private Sub frmTransferVisitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub FormLoad()
        FillCombo(cmbOldVisitor, dtOldVisitor)
        FillCombo(cmbNewVisitor, dtNewVisitor)
    End Sub
    Private Sub FillCombo(ByVal cmb As ComboBox, ByVal dt As DataTable)
        Try
            dt.Clear()

            dt = clsDalVisitor.GetUsersVisitorByUserID(ClassUserLoginDataAccess.ThisUser.UserID)

            cmb.DataSource = dt
            cmb.ValueMember = "VisitorID"
            cmb.DisplayMember = "FullName"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbVisitor_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOldVisitor.SelectedValueChanged, cmbNewVisitor.SelectedValueChanged
        btnApprove.Enabled = False
    End Sub
    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        If RequiredValidator() = False Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        FillGrid()
        InitGrid()
        btnApprove.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FillGrid()
        Try
            Dim dt As DataTable = clsDalContract.GetContract_ContractingParty_By_VisitorAndDate(cmbOldVisitor.SelectedValue, txtDate.Value)
            dgv.DataSource = dt
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub InitGrid()
        dgv.Columns("ContractID").HeaderText = "کد قرارداد"
        dgv.Columns("Date_vc").HeaderText = "تاریخ قرارداد"
        dgv.Columns("FirstName_nvc").HeaderText = "نام طرف قرارداد"
        dgv.Columns("LastName_nvc").HeaderText = "نام خانوادگی طرف قرارداد"
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim result As Boolean = True
        If cmbNewVisitor.SelectedIndex = -1 Then
            erp.SetError(cmbNewVisitor, "بازاریاب جدید نمی تواند خالی باشد")
            result = False
        Else
            erp.SetError(cmbNewVisitor, "")
        End If

        If cmbOldVisitor.SelectedIndex = -1 Then
            erp.SetError(cmbOldVisitor, "بازاریاب قدیمی نمی تواند خالی باشد")
            result = False
        Else
            erp.SetError(cmbOldVisitor, "")
        End If

        If txtDate.Value.Trim().Length = 0 Then
            erp.SetError(txtDate, "تاریخ نمی تواند خالی باشد")
            result = False
        Else
            erp.SetError(txtDate, "")
        End If
        Return result

    End Function
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        If dgv.SelectedRows.Count = 0 Then
            ShowErrorMessage("هیچ رکوردی جهت انتقال بازاریاب انتخاب نشده است .")
            Exit Sub
        End If

        If ShowConfirmMessage("تعداد " + dgv.SelectedRows.Count.ToString + "قرارداد جهت تغییر بازاریاب انتخاب شده است ، آیا مطمئنید ؟") Then
            Me.Cursor = Cursors.WaitCursor
            Try
                clsDalContract.BeginProc()
                Dim oldVisitorID As Int64 = Convert.ToInt64(cmbOldVisitor.SelectedValue)
                Dim newVisitorID As Int64 = Convert.ToInt64(cmbNewVisitor.SelectedValue)
                Dim UserID As Int64 = ClassUserLoginDataAccess.ThisUser.UserID
                For Each row As DataGridViewRow In dgv.SelectedRows
                    clsDalPosVisitor.UpdateVisitor_Contract_PosVisitor(oldVisitorID, newVisitorID, Convert.ToInt64(row.Cells("ContractID").Value), UserID)
                Next

            Catch ex As Exception
                ShowErrorMessage(ex.Message)
            Finally
                clsDalContract.EndProc()
            End Try
            btnApprove.Enabled = False
            btnPreview.PerformClick()
            Me.Cursor = Cursors.Default
        End If
    End Sub
End Class