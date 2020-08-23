Public Class frmProgressReport
    Dim DS As DataSet
    Dim DT As DataTable

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmProgressReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TmsDLObj As New ClassDALTMS()
        Try
            cmbTask.ComboBox.DisplayMember = "Name"
            Me.cmbTask.ComboBox.DataSource = TmsDLObj.TMS_GetAllTask_sp()
            Me.cmbTask.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub UpdatedDetailTabPage_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdatedDetailTabPage.Enter
        Me.SendToExcelAllToolStripButton.Visible = False
        Me.SendToExcelDetailNotUpdatedToolStripButton.Visible = False
        Me.SendToExcelUpdatedDetailToolStripButton.Visible = True
        Me.btnView.Enabled = False

        Dim DT_CityTaskActivityDetail As New DataTable("CityTaskActivityDetail", "CityTaskActivityDetail")
        Dim DT_Contract As New DataTable
        Dim ActivePoseDLObj As New ClassDALProgressReport(ConnectionString)
        Dim ContractDAL As New ClassDALContract(ConnectionString)
        Dim TmsDLObj As New ClassDALTMS()

        Try
            If IsNothing(dgvReportProgress.CurrentRow) = False Then
                DT_CityTaskActivityDetail = TmsDLObj.TMS_GetCityTaskActivityUpdatedDetail(cmbTask.ComboBox.Text, "tejarat_" + dgvReportProgress.CurrentRow.Cells("colStateID").Value.ToString)
                DT_CityTaskActivityDetail.Columns.Add("StoreName", GetType(String))
                DT_CityTaskActivityDetail.Columns.Add("contactingPartyName", GetType(String))
                DT_CityTaskActivityDetail.Columns.Add("OUTLET", GetType(String))
                DT_CityTaskActivityDetail.Columns.Add("Serial_vc", GetType(String))
                DT_CityTaskActivityDetail.Columns.Add("Address_nvc", GetType(String))
                DT_CityTaskActivityDetail.Columns.Add("Tel1_vc", GetType(String))

                For Each dr As DataRow In DT_CityTaskActivityDetail.Rows
                    DT_Contract = ContractDAL.GetContractByEnaicCode(dr.Item("EniacCode"))
                    If DT_Contract.Rows.Count > 0 Then
                        dr.Item("StoreName") = DT_Contract.Rows(0)("Name_nvc").ToString
                        dr.Item("contactingPartyName") = DT_Contract.Rows(0)("contactingPartyName").ToString
                        dr.Item("OUTLET") = DT_Contract.Rows(0)("OUTLET").ToString
                        dr.Item("Serial_vc") = DT_Contract.Rows(0)("Serial_vc").ToString
                        dr.Item("Address_nvc") = DT_Contract.Rows(0)("Address_nvc").ToString
                        dr.Item("Tel1_vc") = DT_Contract.Rows(0)("Tel1_vc").ToString
                    End If
                Next
                DT_CityTaskActivityDetail.AcceptChanges()
                dgvReportProgressUpdatedDetail.AutoGenerateColumns = False
                dgvReportProgressUpdatedDetail.DataSource = DT_CityTaskActivityDetail
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub NotUpdatedDetailTabPage_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotUpdatedDetailTabPage.Enter
        Me.SendToExcelAllToolStripButton.Visible = False
        Me.SendToExcelUpdatedDetailToolStripButton.Visible = False
        Me.SendToExcelDetailNotUpdatedToolStripButton.Visible = True
        Me.btnView.Enabled = False

        Dim DT_CityTaskActivityNotUpdatedDetail As New DataTable("CityTaskActivityNotUpdatedDetail", "CityTaskActivityNotUpdatedDetail")
        Dim DT_Contract As New DataTable
        Dim ActivePoseDLObj As New ClassDALProgressReport(ConnectionString)
        Dim ContractDAL As New ClassDALContract(ConnectionString)
        Dim TmsDLObj As New ClassDALTMS()

        Try
            If IsNothing(dgvReportProgress.CurrentRow) = False Then
                DT_CityTaskActivityNotUpdatedDetail = TmsDLObj.TMS_GetCityTaskActivityNotUpdatedDetail(cmbTask.ComboBox.Text, "tejarat_" + dgvReportProgress.CurrentRow.Cells("colStateID").Value.ToString)
                DT_CityTaskActivityNotUpdatedDetail.Columns.Add("StoreName", GetType(String))
                DT_CityTaskActivityNotUpdatedDetail.Columns.Add("contactingPartyName", GetType(String))
                DT_CityTaskActivityNotUpdatedDetail.Columns.Add("OUTLET", GetType(String))
                DT_CityTaskActivityNotUpdatedDetail.Columns.Add("Serial_vc", GetType(String))
                DT_CityTaskActivityNotUpdatedDetail.Columns.Add("Address_nvc", GetType(String))
                DT_CityTaskActivityNotUpdatedDetail.Columns.Add("Tel1_vc", GetType(String))

                For Each dr As DataRow In DT_CityTaskActivityNotUpdatedDetail.Rows
                    DT_Contract = ContractDAL.GetContractByEnaicCode(dr.Item("EniacCode"))
                    If DT_Contract.Rows.Count > 0 Then
                        dr.Item("StoreName") = DT_Contract.Rows(0)("Name_nvc").ToString
                        dr.Item("contactingPartyName") = DT_Contract.Rows(0)("contactingPartyName").ToString
                        dr.Item("OUTLET") = DT_Contract.Rows(0)("OUTLET").ToString
                        dr.Item("Serial_vc") = DT_Contract.Rows(0)("Serial_vc").ToString
                        dr.Item("Address_nvc") = DT_Contract.Rows(0)("Address_nvc").ToString
                        dr.Item("Tel1_vc") = DT_Contract.Rows(0)("Tel1_vc").ToString
                    End If
                Next
                DT_CityTaskActivityNotUpdatedDetail.AcceptChanges()
                dgvReportProgressNotUpdatedDetail.AutoGenerateColumns = False
                dgvReportProgressNotUpdatedDetail.DataSource = DT_CityTaskActivityNotUpdatedDetail
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub dgvReportProgress_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvReportProgress.DataSourceChanged
        Dim ActivePos As Int64 = 0
        Dim UpdatedTerminals As Int64 = 0
        Dim NotUpdatedTerminals As Int64 = 0

        For Each dr As DataRow In dgvReportProgress.DataSource.rows
            If IsDBNull(dr.Item("ActivePos")) = False Then
                ActivePos += dr.Item("ActivePos")
            End If
            If IsDBNull(dr.Item("UpdatedTerminals")) = False Then
                UpdatedTerminals += dr.Item("UpdatedTerminals")
            End If
            If IsDBNull(dr.Item("NotUpdatedTerminals")) = False Then
                NotUpdatedTerminals += dr.Item("NotUpdatedTerminals")
            End If
        Next

        Me.txtActivePos.Text = ActivePos
        Me.txtUpdateTerminal.Text = UpdatedTerminals
        Me.txtNotUpdateTerminal.Text = NotUpdatedTerminals
    End Sub

    Private Sub AllTabPage_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllTabPage.Enter
        Me.SendToExcelAllToolStripButton.Visible = True
        Me.SendToExcelUpdatedDetailToolStripButton.Visible = False
        Me.SendToExcelDetailNotUpdatedToolStripButton.Visible = False
        Me.btnView.Enabled = True
    End Sub

    Private Sub dgvReportProgress_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReportProgress.CellDoubleClick
        Me.TMSProgressTabControl.SelectedTab = UpdatedDetailTabPage
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Dim DT_ActivePoses As New DataTable("ActivePoses", "ActivePoses")
        Dim DT_StateTaskActivityUpdated As New DataTable("StateTaskActivityUpdated", "StateTaskActivityUpdated")
        Dim DT_StateTaskActivityNotUpdated As New DataTable("StateTaskActivityNotUpdated", "StateTaskActivityNotUpdated")
        Dim DT_State As New DataTable
        Dim ActivePoseDLObj As New ClassDALProgressReport(ConnectionString)
        Dim StateDAL As New ClassDALState(ConnectionString)
        Dim TmsDLObj As New ClassDALTMS()
        Try
            Me.Cursor = Cursors.WaitCursor
            DT_ActivePoses = ActivePoseDLObj.GetStateActivePos()
            DT_State = StateDAL.GetAll()

            DT_StateTaskActivityUpdated = TmsDLObj.TMS_GetStateTaskActivityUpdated(cmbTask.ComboBox.Text)
            DT_StateTaskActivityNotUpdated = TmsDLObj.TMS_GetStateTaskActivityNotUpdated(cmbTask.ComboBox.Text)
            DT_State.Columns.Add("ActivePos", GetType(Integer))
            DT_State.Columns.Add("UpdatedTerminals", GetType(Integer))
            DT_State.Columns.Add("NotUpdatedTerminals", GetType(Integer))

            For Each dr As DataRow In DT_State.Rows
                Dim udr1() As DataRow = DT_StateTaskActivityUpdated.Select(String.Format("StateID = '{0}'", "tejarat_" + dr.Item("StateID").ToString))
                If udr1.Length > 0 Then
                    dr.Item("UpdatedTerminals") = udr1(0).Item("UpdatedTerminals")
                End If

                Dim udr2() As DataRow = DT_StateTaskActivityNotUpdated.Select(String.Format("StateID = '{0}'", "tejarat_" + dr.Item("StateID").ToString))
                If udr2.Length > 0 Then
                    dr.Item("NotUpdatedTerminals") = udr2(0).Item("NotUpdatedTerminals")
                End If

                Dim udr3() As DataRow = DT_ActivePoses.Select(String.Format("StateID = '{0}'", dr.Item("StateID").ToString))
                If udr3.Length > 0 Then
                    dr.Item("ActivePos") = udr3(0).Item("ActivePos")
                End If
            Next
            DT_State.AcceptChanges()
            dgvReportProgress.AutoGenerateColumns = False
            dgvReportProgress.DataSource = DT_State
            DT = DT_StateTaskActivityUpdated
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub SendToExcelAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToExcelAllToolStripButton.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvReportProgress)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub SendToExcelUpdatedDetailToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToExcelUpdatedDetailToolStripButton.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvReportProgressUpdatedDetail)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub SendToExcelDetailNotUpdatedToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToExcelDetailNotUpdatedToolStripButton.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvReportProgressNotUpdatedDetail)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

End Class