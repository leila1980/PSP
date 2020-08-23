Public Class frmRptPosVersion
    Private clsDALReport2 As New ClassDALReport_2(modPublicMethod.ConnectionString)
    Private clsDALProject As New ClassDALProject(modPublicMethod.ConnectionString)

    Private dt As New DataTable
    Private dv As DataView

    Private DateFrom As String
    Private DateTO As String
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    
    Private Sub frmRptGetAllTransactionsInDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillCombo()
            cmbProject.SelectedIndex = 0
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub ReportSearchToolStrip1_Show_Click() Handles ReportSearchToolStrip1.Show_Click
        Try
            If rucDate.cboDate.SelectedIndex = 1 Then
                DateFrom = rucDate.txtDateFrom.Value
                DateTO = rucDate.txtDateTo.Value
            Else
                DateFrom = ""
                DateTO = ""
            End If
            Me.Cursor = Cursors.WaitCursor
            FillGrid()
            InitGrid()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub FillGrid()
        Try
            dt.Clear()
            dt = clsDALReport2.GetPosVersion(DateFrom, DateTO, cmbProject.SelectedValue)
            dv = dt.DefaultView
            dgvReport.DataSource = dv
            InitGrid()
            ReportSearchToolStrip1.Init(dgvReport, dt, Me.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitGrid()
       Try
            If dgvReport.Columns.Count > 0 Then
                dgvReport.Columns("StoreName").HeaderText = "فروشگاه"
                dgvReport.Columns("StateName").HeaderText = "استان"
                dgvReport.Columns("CityName").HeaderText = "شهر"
                dgvReport.Columns("VisitorName").HeaderText = "بازاریاب"
                dgvReport.Columns("Merchant_vc").HeaderText = "کدپذیرنده"
                dgvReport.Columns("Outlet_vc").HeaderText = "کد پایانه"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dgv_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvReport.RowsAdded
        lblCount.Text = dgvReport.RowCount
    End Sub

    Private Sub dgv_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvReport.RowsRemoved
        lblCount.Text = dgvReport.RowCount
    End Sub

    Private Sub OPenConnection()
        If cnt.State <> ConnectionState.Open Then
            cnt.ConnectionString = modPublicMethod.ConnectionString
            cnt.Open()
        End If
    End Sub

    Private Sub DisposConnection()
        cnt.Close()
        cnt.Dispose()
        cnt = Nothing
    End Sub

    Private Sub FillCombo()
        Try
            OPenConnection()
            Dim dt As New DataTable
            dt = clsDALProject.GetAll(ClassUserLoginDataAccess.ThisUser.UserID)
            If dt.Rows.Count > 1 Then
                Dim dr As DataRow
                dr = dt.NewRow()
                dr("ProjectID_tint") = 0
                dr("Name_nvc") = "همه"
                dt.Rows.InsertAt(dr, 0)
            End If
            Me.cmbProject.DataSource = dt
            Me.cmbProject.DisplayMember = "Name_nvc"
            Me.cmbProject.ValueMember = "ProjectID_tint"
            DisposConnection()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

 
End Class