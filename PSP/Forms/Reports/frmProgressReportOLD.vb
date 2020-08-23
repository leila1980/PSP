Public Class frmProgressReportOLD
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

    Private Sub cmbTask_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTask.SelectedIndexChanged
        Dim DT_ActivePoses As New DataTable("ActivePoses", "ActivePoses")
        Dim DT_UpdatedTerminals As New DataTable("UpdatedTerminals", "UpdatedTerminals")
        Dim DT_State As New DataTable

        Dim ActivePoseDLObj As New ClassDALProgressReport(ConnectionString)
        Dim StateDAL As New ClassDALState(ConnectionString)

        Dim TmsDLObj As New ClassDALTMS()
        Try
            DT_ActivePoses = ActivePoseDLObj.GetCountOfActivePose()
            DT_State = StateDAL.GetAll()

            DT_UpdatedTerminals = TmsDLObj.TMS_GetStateTaskActivity(cmbTask.ComboBox.Text)
            DT_State.Columns.Add("ActivePos", GetType(Integer))
            DT_State.Columns.Add("UpdatedTerminals", GetType(Integer))


            For Each dr As DataRow In DT_State.Rows
                Dim udr1() As DataRow = DT_UpdatedTerminals.Select(String.Format("StateID = 'tejarat_{0}'", dr.Item("StateID").ToString))
                If udr1.Length > 0 Then
                    dr.Item("UpdatedTerminals") = udr1(0).Item("UpdatedTerminals")
                End If

                Dim udr2() As DataRow = DT_ActivePoses.Select(String.Format("StateID = '{0}'", dr.Item("StateID").ToString))
                If udr2.Length > 0 Then
                    dr.Item("ActivePos") = udr2(0).Item("ActivePos")
                End If
            Next

            DT_State.AcceptChanges()
            dgvReportProgress.AutoGenerateColumns = False
            dgvReportProgress.DataSource = DT_State
            DT = DT_UpdatedTerminals
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub dgvReportProgress_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvReportProgress.DataSourceChanged
        Dim ActivePos As Int64 = 0
        Dim UpdatedTerminals As Int64 = 0

        For Each dr As DataRow In dgvReportProgress.DataSource.rows
            If IsDBNull(dr.Item("ActivePos")) = False Then
                ActivePos += dr.Item("ActivePos")
            End If
            If IsDBNull(dr.Item("UpdatedTerminals")) = False Then
                UpdatedTerminals += dr.Item("UpdatedTerminals")
            End If
        Next

        Me.txtActivePos.Text = ActivePos
        Me.txtUpdateTerminal.Text = UpdatedTerminals
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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

End Class