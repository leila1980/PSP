﻿Public Class frmAgentPerformanceGrid

#Region "Global Member"
    Dim DAL As New Eniac.PSP.DAL.AgentPerformanceClass
    Dim dtGrid As New DataTable
    Dim flgCombo As Boolean = False
#End Region

#Region "Events"

    Private Sub frmAgentMonthlyGoalsGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetGridStyle()
        flgCombo = False
        LoadcmbSearch()
        flgCombo = True

    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim frm As New frmAgentPerformanceEdit(dtGrid)
        frm.ShowDialog()
        Me.dtGrid.DefaultView.RowFilter = ""

    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If Me.dgvForm.Rows.Count > 0 Then
            Dim CurrentId As Integer = Me.dgvForm.CurrentRow.Cells("AgentPerformanceId").Value
            Dim Frm As New frmAgentPerformanceEdit(dtGrid, CurrentId)
            Frm.ShowDialog()
        End If

    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If Me.dgvForm.Rows.Count = 0 Then
            Exit Sub
        End If

        If MessageBox.Show("آیا رکورد حذف شود؟", "حذف", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim CurrentId As Integer = Me.dgvForm.CurrentRow.Cells("AgentPerformanceId").Value
            If DAL.Delete(CurrentId) = True Then

                Dim dr() As DataRow
                dr = dtGrid.Select(" AgentPerformanceId = " & CurrentId)
                dr(0).Delete()
                dtGrid.AcceptChanges()
            End If

        End If

    End Sub
    Private Sub cmbSearchFirst_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSearchFirst.SelectedIndexChanged

        If flgCombo = True Then

            Dim dtCmbSearch As DataTable

            Select Case cmbSearchFirst.SelectedIndex
                Case 0
                    dtGrid.DefaultView.RowFilter = ""
                Case 1 'Agent
                    dtCmbSearch = DAL.SelectVisitor
                Case 2 'State 
                    dtCmbSearch = DAL.SelectState
                Case Else
                    Exit Sub
            End Select

            flgCombo = False
            cmbSearchSecond.ComboBox.DataSource = dtCmbSearch
            cmbSearchSecond.ComboBox.DisplayMember = "Name"
            cmbSearchSecond.ComboBox.ValueMember = "Id"
            cmbSearchSecond.ComboBox.SelectedIndex = -1
            flgCombo = True

        End If

    End Sub
    Private Sub cmbSearchSecond_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchSecond.SelectedIndexChanged

        Dim strWhere As String = ""

        If flgCombo = True Then
            Select Case cmbSearchFirst.SelectedIndex
                Case 1  'Agent
                    Me.dtGrid.DefaultView.Sort = "AgentId"
                    Me.dtGrid.DefaultView.RowFilter = "AgentId = " & Me.cmbSearchSecond.ComboBox.SelectedValue
                Case 2  'State 
                    Me.dtGrid.DefaultView.Sort = "StateId"
                    Me.dtGrid.DefaultView.RowFilter = "StateId = " & Me.cmbSearchSecond.ComboBox.SelectedValue
            End Select
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

        Me.dgvForm.Columns("StateId").Visible = False
        Me.dgvForm.Columns("AgentPerformanceId").Visible = False
        Me.dgvForm.Columns("AgentId").Visible = False

        Me.dgvForm.Columns("ConfirmedNumber").Width = 100
        Me.dgvForm.Columns("ConfirmedNumber").HeaderText = "تعداد منعقده"
        Me.dgvForm.Columns("CompletedContractNumber").Width = 100
        Me.dgvForm.Columns("CompletedContractNumber").HeaderText = "تعداد قرارداد کامل"
        Me.dgvForm.Columns("ReportDate").Width = 100
        Me.dgvForm.Columns("ReportDate").HeaderText = "تاریخ گزارش"
        Me.dgvForm.Columns("AgentName").HeaderText = "نام نماینده"
        Me.dgvForm.Columns("AgentName").Width = 170
        Me.dgvForm.Columns("StateName").HeaderText = "نام استــان"
        Me.dgvForm.Columns("StateName").Width = 170

    End Sub
    Private Sub LoadcmbSearch()
        Me.cmbSearchFirst.Items.Add(" ---")
        Me.cmbSearchFirst.Items.Add("نام نماینده")
        Me.cmbSearchFirst.Items.Add("شهرستـــان")
        Me.cmbSearchFirst.SelectedIndex = 0
    End Sub
#End Region

End Class


