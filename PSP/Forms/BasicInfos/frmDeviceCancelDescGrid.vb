
Public Class frmDeviceCancelDescGrid

#Region "Global Member"
    Dim DAL As New Eniac.PSP.DAL.DeviceCancelDesc
    Dim dtGrid As New DataTable
    Dim flgCombo As Boolean = False

#End Region
#Region "Events"

    Private Sub frmAgentMonthlyGoalsGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

            SetGridStyle()
            flgCombo = False
            flgCombo = True

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frm As New frmDeviceCancelDescEdit(dtGrid)
        frm.ShowDialog()
        Me.dtGrid.DefaultView.RowFilter = ""

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If Me.dgvForm.Rows.Count > 0 Then
            Dim CurrentId As Integer = Me.dgvForm.CurrentRow.Cells("DeviceCancelDescId").Value
            Dim Frm As New frmDeviceCancelDescEdit(dtGrid, CurrentId)
            Frm.ShowDialog()
        End If

    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If Me.dgvForm.Rows.Count = 0 Then
            Exit Sub
        End If

        If MessageBox.Show("آیا رکورد حذف شود؟", "حذف", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim CurrentId As Integer = Me.dgvForm.CurrentRow.Cells("DeviceCancelDescId").Value
            If DAL.Delete(CurrentId) = True Then

                Dim dr() As DataRow
                dr = dtGrid.Select("DeviceCancelDescId = " & CurrentId)
                dr(0).Delete()
                dtGrid.AcceptChanges()
            End If

        End If


    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

#End Region
#Region "Sub"
    Private Sub SetGridStyle()

        dtGrid = DAL.SelectAll()

        If dtGrid Is Nothing Then
            Me.Close()
            Exit Sub
        End If

        Me.dgvForm.DataSource = dtGrid

        Me.dgvForm.Columns("DeviceCancelDescId").Visible = False
        Me.dgvForm.Columns("DeviceCancelDescId").Visible = False

        Me.dgvForm.Columns("DeviceCancelDesc").Width = 1000
        Me.dgvForm.Columns("DeviceCancelDesc").HeaderText = "شرح"

    End Sub

#End Region

End Class