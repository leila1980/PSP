Imports Oracle.DataAccess.Client

Public Class frmrptAssignPosToVisitorConflict
    Private clsDALReport As New ClassDALReport(modPublicMethod.ConnectionString)

    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim ds As New DSReport
    Dim da As New OracleDataAdapter
    Dim cmd As New Oracle.DataAccess.Client.OracleCommand
    Dim dv As New DataView

    Private dtdgvConflict As New DataTable
    Private dtdgvOperationalWithoutVisitor As New DataTable
    Private dtdgvWithoutContract As New DataTable
    Private dtdgvOperationalNotApproved As DataTable

    Private dvdgvConflict As DataView
    Private dvdgvOperationalWithoutVisitor As DataView
    Private dvdgvWithoutContract As DataView
    Private dvdgvOperationalNotApproved As DataView




    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                If tbcMain.SelectedTab Is tbpOperationalWithoutVisitor Then
                    clsExcel.Write(Me.dgvOperationalWithoutVisitor)
                ElseIf tbcMain.SelectedTab Is tbpConflict Then
                    clsExcel.Write(Me.dgvConflict)
                Else
                    clsExcel.Write(Me.dgvWithoutContract)
                End If


            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

#Region "Methods"
    Private Sub FormLoad()
        Try
            FillGrid()
            InitGrid(dgvOperationalWithoutVisitor)
            InitGrid(dgvConflict)
            InitGrid(dgvWithoutContract)
            InitGrid(dgvOperationalNotApproved)


            InitSearchToolbar()
            calculateRowCount()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitSearchToolbar()
        If tbcMain.SelectedTab Is tbpOperationalWithoutVisitor Then
            rtsSearch.Init(dgvOperationalWithoutVisitor, dtdgvOperationalWithoutVisitor, "")
        ElseIf tbcMain.SelectedTab Is tbpConflict Then
            rtsSearch.Init(dgvConflict, dtdgvConflict, "")
        ElseIf tbcMain.SelectedTab Is tbpWithoutContract Then
            rtsSearch.Init(dgvWithoutContract, dtdgvWithoutContract, "")
        ElseIf tbcMain.SelectedTab Is tbpOperationalNotApproved Then
            rtsSearch.Init(dgvOperationalNotApproved, dtdgvOperationalNotApproved, "")
        End If


    End Sub
    Private Sub FillGrid()
        Try
            dtdgvOperationalWithoutVisitor = clsDALReport.GetAssignPosVisitorConflicts(1)
            dtdgvConflict = clsDALReport.GetAssignPosVisitorConflicts(2)
            dtdgvWithoutContract = clsDALReport.GetAssignPosVisitorConflicts(3)
            dtdgvOperationalNotApproved = clsDALReport.GetAssignPosVisitorConflicts(4)

            dgvOperationalWithoutVisitor.DataSource = dtdgvOperationalWithoutVisitor
            dgvConflict.DataSource = dtdgvConflict
            dgvWithoutContract.DataSource = dtdgvWithoutContract
            dgvOperationalNotApproved.DataSource = dtdgvOperationalNotApproved


            dvdgvOperationalWithoutVisitor = dtdgvOperationalWithoutVisitor.DefaultView
            dvdgvConflict = dtdgvConflict.DefaultView
            dvdgvWithoutContract = dtdgvWithoutContract.DefaultView
            dvdgvOperationalNotApproved = dtdgvOperationalNotApproved.DefaultView



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitGrid(ByVal dgv As DataGridView)

        dgv.Columns("PosID").HeaderText = "کد دستگاه"
        dgv.Columns("Serial_vc").HeaderText = "سریال دستگاه"
        dgv.Columns("ContractVisitorID").HeaderText = "کد بازاریاب ثبت شده در قرارداد"
        dgv.Columns("ContractVisitorName").HeaderText = "نام بازاریاب ثبت شده در قرارداد"
        dgv.Columns("AssignedVisitorID").HeaderText = "کد بازاریاب تخصیص داده شده"
        dgv.Columns("AssignedVisitorName").HeaderText = "نام بازاریاب تخصیص داده شده"
        dgv.Columns("DescriptionFa_nvc").HeaderText = "آخرین وضعیت"
        dgv.Columns("ContractID").HeaderText = "کد قرارداد"

        dgv.Columns("AssignedVisitorID").Visible = False
        dgv.Columns("ContractVisitorID").Visible = False
        dgv.Columns("AssignedVisitorName").Width = 225
        dgv.Columns("ContractVisitorName").Width = 225
        dgv.Columns("DescriptionFa_nvc").Width = 250

    End Sub
#End Region

    Private Sub frmRptOperationalPosNotAssigned_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub

    Private Sub frmRptOperationalPosNotAssigned_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub tbcMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcMain.SelectedIndexChanged
        InitSearchToolbar()
        calculateRowCount()

    End Sub

    Private Sub calculateRowCount()
        If tbcMain.SelectedTab Is tbpOperationalWithoutVisitor Then
            lblCount.Text = dgvOperationalWithoutVisitor.Rows.Count.ToString()
        ElseIf tbcMain.SelectedTab Is tbpConflict Then
            lblCount.Text = dgvConflict.Rows.Count.ToString()
        ElseIf tbcMain.SelectedTab Is tbpWithoutContract Then
            lblCount.Text = dgvWithoutContract.Rows.Count.ToString()
        ElseIf tbcMain.SelectedTab Is tbpOperationalNotApproved Then
            lblCount.Text = dgvOperationalNotApproved.Rows.Count.ToString()
        End If
    End Sub

End Class