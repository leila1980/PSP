Imports log4net

Public Class frmAssignPosToVisitor

    Private clsDalVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)

    Private clsDalPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private clsDalPosVisitor As New ClassDALPosVisitor(modPublicMethod.ConnectionString)
    Private CLSUserLoginDA As New ClassUserLoginDataAccess(ConnectionString)

    Private dtVisitor As New DataTable
    Private dtdgv As New DataTable
    Private dvdgv As DataView

    Private dtdgvselectedPos As New DataTable
    Private dvdgvselectedPos As DataView
    Private currentUserVisitorID As Int64
    Private currentUserIsSuper As Int16

    Private dtImportExcel As New DataTable
#Region "Control Events"
    Private Sub frmAssignPosToVisitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgv)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnSelectedExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectedExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvselectedPos)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Public Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        dgv.EndEdit()
        For i As Integer = 0 To dgv.RowCount - 1
            dgv.Rows(i).Selected = True
        Next
    End Sub
    Public Sub btnUnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnSelect.Click
        dgv.EndEdit()
        For i As Integer = 0 To dgv.RowCount - 1
            dgv.Rows(i).Selected = False
        Next
    End Sub
    Public Sub InventSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventSelect.Click
        dgv.EndEdit()
        For i As Integer = 0 To dgv.RowCount - 1
            dgv.Rows(i).Selected = Not dgv.Rows(i).Selected
        Next
    End Sub
    Private Sub cboVisitor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVisitor.SelectedIndexChanged
        FillSelectedGrid()
        GetVisitorState(cboVisitor.SelectedValue)
        If currentUserVisitorID <> -1 Then
            FillGrid()
        End If
    End Sub
    Public Sub GetVisitorState(ByVal visitorId As Integer)
        clsDalVisitor.BeginProc()
        Dim result As Boolean = clsDalVisitor.GetVisitorStateByVisitorId(visitorId)
        clsDalVisitor.EndProc()
        If result Then
            erp.SetError(Me.cboVisitor, "")
        Else
            erp.SetError(Me.cboVisitor, "وضعیت بازاریاب غیر فعال است ")

        End If
    End Sub
    Private Sub btnAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        Try

            For Each row As DataGridViewRow In dgv.SelectedRows
                If row.Selected Then
                    If Not row.Cells("colStatusID").Value Is DBNull.Value Then
                        If row.Cells("colStatusID").Value = ClassDALPosVisitor.PosVisitorOperations.TransferedToOtherBank Then

                            If Not currentUserIsSuper = -1 Then
                                MsgBox("جهت تخصیص  پزهای انتقالی به سایر بانکها" & vbCrLf & "از بازگشت از سایر بانکها استفاده شود")
                            Else
                                MsgBox("پزهای انتقالی به سایر بانکها قابل تخصیص به بازاریاب نمی باشند")
                            End If

                            Exit Sub
                        End If
                        If row.Cells("colStatusID").Value = ClassDALPosVisitor.PosVisitorOperations.ReturnedToEniacByVisitor Then
                            MsgBox("اگر میخواهید پز مرجوعی را به یک بازاریاب ارسال کنید، ابتدا دریافت آن را تائید نمائید")
                            Exit Sub
                        End If
                    End If
                End If
            Next

            clsDalPosVisitor.VisitorID = cboVisitor.SelectedValue
            clsDalPosVisitor.BeginProc()
            For Each row As DataGridViewRow In dgv.SelectedRows
                If row.Selected Then
                    clsDalPosVisitor.PosID = row.Cells("colPosID").Value
                    clsDalPosVisitor.Operation_tint = ClassDALPosVisitor.PosVisitorOperations.AssignedToVisitor
                    clsDalPosVisitor.DateFa_vc = GetDateNow()
                    clsDalPosVisitor.DateTime = Date.Now()
                    clsDalPosVisitor.Insert()
                End If
            Next

        Catch ex As Exception
            clsDalPosVisitor.RollBackProc()
            Throw ex
        Finally
            clsDalPosVisitor.EndProc()
        End Try

        FillGrid()
        FillSelectedGrid()

    End Sub
    Private Sub btnCancelAssignment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelAssignment.Click
        Try

            For Each row As DataGridViewRow In dgvselectedPos.Rows
                If row.Selected Then
                    If row.Cells("colSelectedStatus").Value Then
                        MsgBox("رکورد تائید شده قابل حذف نمی باشد")
                        Exit Sub
                    End If
                End If
            Next

            clsDalPosVisitor.VisitorID = cboVisitor.SelectedValue
            clsDalPosVisitor.BeginProc()
            For Each row As DataGridViewRow In dgvselectedPos.SelectedRows
                If row.Selected Then
                    clsDalPosVisitor.PosID = row.Cells("colSelectedPosID").Value
                    clsDalPosVisitor.Operation_tint = ClassDALPosVisitor.PosVisitorOperations.AssignmentToVisitorCanceledByEniac
                    clsDalPosVisitor.DateFa_vc = GetDateNow()
                    clsDalPosVisitor.DateTime = Date.Now()
                    clsDalPosVisitor.Insert()
                End If
            Next

        Catch ex As Exception
            clsDalPosVisitor.RollBackProc()
            Throw ex
        Finally
            clsDalPosVisitor.EndProc()
        End Try

        FillGrid()
        FillSelectedGrid()
    End Sub
    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Try
            clsDalPosVisitor.VisitorID = cboVisitor.SelectedValue
            clsDalPosVisitor.BeginProc()
            If dgv.SelectedRows.Count > 0 Then
                Dim strMsg As String
                strMsg = "تعداد " + dgv.SelectedRows.Count.ToString() + "دستگاه جهت تایید انتخاب شده است ، آیا مطمئنید ؟"
                If modPublicMethod.ShowConfirmMessage(strMsg) = False Then
                    Exit Sub
                End If

                For Each row As DataGridViewRow In dgv.SelectedRows
                    If row.Selected Then
                        clsDalPosVisitor.PosID = row.Cells("colPosID").Value
                        clsDalPosVisitor.Operation_tint = ClassDALPosVisitor.PosVisitorOperations.AssignmentConfirmedByVisitor
                        clsDalPosVisitor.DateFa_vc = GetDateNow()
                        clsDalPosVisitor.DateTime = Date.Now()
                        clsDalPosVisitor.Insert()
                    End If
                Next
            End If
        Catch ex As Exception
            clsDalPosVisitor.RollBackProc()
            Throw ex
        Finally
            clsDalPosVisitor.EndProc()
        End Try

        FillGrid()
        FillSelectedGrid()
    End Sub
    Private Sub btnTransferToOtherBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferToOtherBank.Click
        Try
            For Each row As DataGridViewRow In dgv.SelectedRows
                If row.Selected Then
                    If Not row.Cells("colStatusID").Value Is DBNull.Value Then
                        If row.Cells("colStatusID").Value = ClassDALPosVisitor.PosVisitorOperations.TransferedToOtherBank Then
                            MsgBox("پزهای انتقالی به سایر بانکها مجددا قابل انتقال نیستند")
                            Exit Sub
                        End If
                        If row.Cells("colStatusID").Value = ClassDALPosVisitor.PosVisitorOperations.ReturnedToEniacByVisitor Then
                            MsgBox("اگر میخواهید پز مرجوعی را به بانک دیگری منتقل کنید، ابتدا دریافت آن را تائید نمائید")
                            Exit Sub
                        End If
                    End If

                End If
            Next

            clsDalPosVisitor.VisitorID = -1
            clsDalPosVisitor.BeginProc()
            For Each row As DataGridViewRow In dgv.SelectedRows
                If row.Selected Then
                    clsDalPosVisitor.PosID = row.Cells("colPosID").Value
                    clsDalPosVisitor.Operation_tint = ClassDALPosVisitor.PosVisitorOperations.TransferedToOtherBank
                    clsDalPosVisitor.DateFa_vc = GetDateNow()
                    clsDalPosVisitor.DateTime = Date.Now()
                    If clsDalPosVisitor.IsThisPosInstalled() = "1" Then
                        ShowErrorMessage(" دستگاه بشماره سریال " + row.Cells("colSerial_vc").Value.ToString + " نصب شده است ، امکان انتقال آن به سایر بانک ها وجود ندارد")
                    Else
                        clsDalPosVisitor.Insert()
                    End If
                End If
            Next

        Catch ex As Exception
            clsDalPosVisitor.RollBackProc()
            Throw ex
        Finally
            clsDalPosVisitor.EndProc()
        End Try

        FillGrid()
    End Sub
    Private Sub btnReTransferToOtherBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReTransferToOtherBank.Click
        Try

            For Each row As DataGridViewRow In dgv.SelectedRows
                If row.Selected Then

                    If Not row.Cells("colStatusID").Value Is DBNull.Value Then

                        If row.Cells("colStatusID").Value = ClassDALPosVisitor.PosVisitorOperations.ReTransferedToOtherBank Then
                            MsgBox("پزهای بازگشتی از سایر بانکها مجددا قابل بازگشت نیستند")
                            Exit Sub
                        End If
                    End If

                End If
            Next

            clsDalPosVisitor.VisitorID = -1
            clsDalPosVisitor.BeginProc()
            For Each row As DataGridViewRow In dgv.SelectedRows
                If row.Selected Then
                    If row.Cells("colStatusID").Value = ClassDALPosVisitor.PosVisitorOperations.TransferedToOtherBank Then
                        clsDalPosVisitor.PosID = row.Cells("colPosID").Value
                        clsDalPosVisitor.Operation_tint = ClassDALPosVisitor.PosVisitorOperations.ReTransferedToOtherBank
                        clsDalPosVisitor.DateFa_vc = GetDateNow()
                        clsDalPosVisitor.DateTime = Date.Now()
                        clsDalPosVisitor.Insert()
                    End If
                End If
            Next
        Catch ex As Exception
            clsDalPosVisitor.RollBackProc()
            Throw ex
        Finally
            clsDalPosVisitor.EndProc()
        End Try

        FillGrid()
    End Sub
    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Try
            clsDalPosVisitor.VisitorID = cboVisitor.SelectedValue
            clsDalPosVisitor.BeginProc()
            For Each row As DataGridViewRow In dgvselectedPos.SelectedRows
                If row.Selected Then
                    clsDalPosVisitor.PosID = row.Cells("colSelectedPosID").Value
                    clsDalPosVisitor.Operation_tint = ClassDALPosVisitor.PosVisitorOperations.ReturnedToEniacByVisitor
                    clsDalPosVisitor.DateFa_vc = GetDateNow()
                    clsDalPosVisitor.DateTime = Date.Now()

                    'To enable "ReturnedToEniac" operation for installed Pos: 
                    'uncomment the following line and comment out the next If clause

                    'clsDalPosVisitor.Insert()


                    If clsDalPosVisitor.IsThisPosInstalled() = "1" And currentUserIsSuper = -1 Then

                        ShowErrorMessage(" دستگاه بشماره سریال " + row.Cells("colSelectedSerial_vc").Value.ToString + " نصب شده است ، امکان ارجاع آن به شرکت وجود ندارد")

                    Else
                        clsDalPosVisitor.Insert()
                    End If
                End If

            Next

        Catch ex As Exception
            clsDalPosVisitor.RollBackProc()
            Throw ex
        Finally
            clsDalPosVisitor.EndProc()
        End Try

        FillSelectedGrid()
    End Sub
    Private Sub btnAcceptReturnedPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptReturnedPos.Click
        Try

            For Each row As DataGridViewRow In dgv.SelectedRows
                If row.Selected Then
                    If row.Cells("colStatusID").Value Is DBNull.Value _
                        OrElse row.Cells("colStatusID").Value <> ClassDALPosVisitor.PosVisitorOperations.ReturnedToEniacByVisitor Then
                        MsgBox("لطفا فقط پزهای مرجوعی را انتخاب فرمائید")
                        Exit Sub
                    End If
                End If
            Next

            clsDalPosVisitor.VisitorID = -1
            clsDalPosVisitor.BeginProc()
            For Each row As DataGridViewRow In dgv.SelectedRows
                If row.Selected Then
                    clsDalPosVisitor.PosID = row.Cells("colPosID").Value
                    clsDalPosVisitor.Operation_tint = ClassDALPosVisitor.PosVisitorOperations.RecievedByEniac
                    clsDalPosVisitor.DateFa_vc = GetDateNow()
                    clsDalPosVisitor.DateTime = Date.Now()
                    clsDalPosVisitor.Insert()
                End If
            Next

        Catch ex As Exception
            clsDalPosVisitor.RollBackProc()
            Throw ex
        Finally
            clsDalPosVisitor.EndProc()
        End Try

        FillGrid()
    End Sub
    Private Sub dgv_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv.DoubleClick
        Dim _frm As New frmPosVisitorHistory
        _frm.PosID = dgv.CurrentRow.Cells("colPosID").Value
        _frm.Text = _frm.Text + " با سریال " + dgv.CurrentRow.Cells("colSerial_vc").Value
        _frm.ShowDialog()
    End Sub
    Private Sub dgvselectedPos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvselectedPos.DoubleClick
        Dim _frm As New frmPosVisitorHistory
        _frm.PosID = dgvselectedPos.CurrentRow.Cells("colSelectedPosID").Value
        _frm.Text = _frm.Text + " با سریال " + dgvselectedPos.CurrentRow.Cells("colSelectedSerial_vc").Value
        _frm.ShowDialog()
    End Sub
    Private Sub btnSelectFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFromExcel.Click
        Try
             Me.dgv.EndEdit()

            Me.Import()

            If dtImportExcel.Rows.Count > 0 Then

                Me.dtImportExcel.Columns(0).ColumnName = "Serial_vc"
                Me.dtImportExcel.DefaultView.Sort = "Serial_vc desc"
                Me.dvdgv.Sort = "Serial_vc desc"

                For k As Integer = 0 To dgv.RowCount - 1
                    dgv.Rows(k).Selected = False
                Next
              
                Dim Selected As Integer = 0
                Dim i As Integer = 0
                Dim j As Integer = 0
                While i <= dtImportExcel.Rows.Count - 1
                    While j <= dvdgv.Count - 1
                        If (dtImportExcel.DefaultView(i)("Serial_vc").ToString.Trim <= dvdgv(j)("Serial_vc").ToString.Trim) Then
                            If (dtImportExcel.DefaultView(i)("Serial_vc").ToString.Trim.Equals(dvdgv(j)("Serial_vc").ToString.Trim)) Then
                                Me.dgv.Rows(j).Selected = True
                                Selected += 1
                            End If
                            j = j + 1
                        Else
                            Exit While
                        End If
                    End While
                    i = i + 1
                End While

                Me.dgv.EndEdit()

                ShowMessage(Selected.ToString + " پز انتخاب شد!")
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

#End Region

#Region "Methods"
    Private Sub FormLoad()
        Try

            CLSUserLoginDA.BeginProc()
            currentUserVisitorID = CLSUserLoginDA.GetVisitorIDByUserID(ClassUserLoginDataAccess.ThisUser.UserID)
            currentUserIsSuper = CLSUserLoginDA.GetUserIsSuperUser(ClassUserLoginDataAccess.ThisUser.UserID)

            If Not currentUserVisitorID > 0 Then
                currentUserVisitorID = -1
            End If


            If Not currentUserIsSuper > 0 Then
                currentUserIsSuper = -1
            End If

            CLSUserLoginDA.EndProc()

            If currentUserVisitorID = -1 Then
                colSelectedStatus.Visible = True
                colStatus.Visible = True
                btnAssign.Visible = True
                btnCancelAssignment.Visible = True
                btnTransferToOtherBank.Visible = True
                btnAcceptReturnedPos.Visible = True
                btnAccept.Visible = False
                btnReturn.Visible = False
                btnCancelReturn.Visible = False
                btnCheckB2B.Visible = False
                btnUnCheckB2B.Visible = False

                If currentUserIsSuper = -1 Then
                    btnReTransferToOtherBank.Visible = False
                Else
                    btnReTransferToOtherBank.Visible = True
                End If

                lblApproved.Visible = True
                lblApprovedCount.Visible = True
                lblUnApproved.Visible = True
                lblUnApprovedCount.Visible = True
                lblTotalPos.Visible = True
                lblTotalPosCount.Visible = True
                lblApprovedForVisitor.Visible = False
                lblApprovedForVisitorCount.Visible = False
            Else
                colSelectedStatus.Visible = False
                colStatus.Visible = False
                btnAssign.Visible = False
                btnCancelAssignment.Visible = False
                btnTransferToOtherBank.Visible = False
                btnAcceptReturnedPos.Visible = False
                btnAccept.Visible = True
                btnReturn.Visible = True
                btnCancelReturn.Visible = True
                btnCheckB2B.Visible = True
                btnUnCheckB2B.Visible = True
                btnReTransferToOtherBank.Visible = False


                lblApproved.Visible = False
                lblApprovedCount.Visible = False
                lblUnApproved.Visible = False
                lblUnApprovedCount.Visible = False
                lblTotalPos.Visible = False
                lblTotalPosCount.Visible = False
                lblApprovedForVisitor.Visible = True
                lblApprovedForVisitorCount.Visible = True
            End If


            FillCboVisitor()
            FillGrid()
            FillSelectedGrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillCboVisitor()
        Try
            RemoveHandler cboVisitor.SelectedIndexChanged, AddressOf cboVisitor_SelectedIndexChanged

            dtVisitor.Clear()
            'If currentUserVisitorID = -1 Then
            '    cboVisitor.Enabled = True
            'Else
            '    cboVisitor.Enabled = False
            'End If

            dtVisitor = clsDalVisitor.GetUsersVisitorByUserID(ClassUserLoginDataAccess.ThisUser.UserID)

            cboVisitor.DataSource = dtVisitor
            cboVisitor.ValueMember = "VisitorID"
            cboVisitor.DisplayMember = "FullName"

            AddHandler cboVisitor.SelectedIndexChanged, AddressOf cboVisitor_SelectedIndexChanged
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub FillGrid()
        Try
            dtdgv.Clear()
            If currentUserVisitorID = -1 Then
                dtdgv = clsDalPos.GetPosByVisitor(currentUserVisitorID, ClassDALPosVisitor.PosVisitorOperations.AssignedToVisitor)
                lblCount.Text = "تعداد پزهای موجود در انبار: " + dtdgv.Select("StatusID in (5,6,7) or StatusID is null").GetLength(0).ToString()
            Else
                dtdgv = clsDalPos.GetPosByVisitor(cboVisitor.SelectedValue, ClassDALPosVisitor.PosVisitorOperations.AssignedToVisitor)
            End If

            dvdgv = dtdgv.DefaultView
            Me.dgv.DataSource = dvdgv

            InitGrid()

            Dim clsSearch As New ClassSearch
            clsSearch.Init(cboSearchField, cboSearchOperation, _
                           txtSearch, btnSearch, btnSearchBack, _
                           btnRemoveFilter, dgv, dtdgv, dvdgv)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillSelectedGrid()
        Try
            dtdgvselectedPos.Clear()

            If currentUserVisitorID = -1 Then
                dtdgvselectedPos = clsDalPos.GetPosByVisitor(cboVisitor.SelectedValue, ClassDALPosVisitor.PosVisitorOperations.AllOperations)
            Else
                dtdgvselectedPos = clsDalPos.GetPosByVisitor(cboVisitor.SelectedValue, ClassDALPosVisitor.PosVisitorOperations.AssignmentConfirmedByVisitor)
            End If

            dvdgvselectedPos = dtdgvselectedPos.DefaultView
            Me.dgvselectedPos.DataSource = dtdgvselectedPos

            Dim clsSearch As New ClassSearch
            clsSearch.Init(cboSelectedSearchField, cboSelectedSearchOperation, _
                           txtSelectedSearch, btnSelectedSearch, btnSelectedSearchBack, _
                           btnSelectedRemoveFilter, dgvselectedPos, dtdgvselectedPos, dvdgvselectedPos)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            Me.dgv.AutoGenerateColumns = False
            Me.dgvselectedPos.AutoGenerateColumns = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Import()
        Try
            dtImportExcel.Clear()
            Dim frm As New OpenFileDialog
            frm.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If frm.FileName = String.Empty Then
                    Exit Sub
                End If
                Dim clsExcel As New ClassExcel(frm.FileName)
                dtImportExcel = clsExcel.Read(1, True)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CalculateSummaryFields()
        If currentUserVisitorID = -1 Then
            Dim Total As Integer = 0
            Dim Approved As Integer = 0
            Dim UnApproved As Integer = 0

            Total = dgvselectedPos.Rows.Count
            For Each row As DataGridViewRow In dgvselectedPos.Rows
                If Convert.ToBoolean(row.Cells("colSelectedStatus").Value) = True Then
                    Approved += 1
                Else
                    UnApproved += 1
                End If
            Next
            lblApprovedCount.Text = Approved.ToString()
            lblUnApprovedCount.Text = UnApproved.ToString()
            lblTotalPosCount.Text = Total.ToString()

        Else
            lblApprovedForVisitorCount.Text = dgvselectedPos.Rows.Count.ToString()

        End If

    End Sub

#End Region

    Private Sub dgvselectedPos_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvselectedPos.RowsAdded
        CalculateSummaryFields()
    End Sub

    Private Sub dgvselectedPos_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvselectedPos.RowsRemoved
        CalculateSummaryFields()
    End Sub


#Region "Find a Serial"

    Private Sub FindaSerial(ByVal adgv As DataGridView, ByVal serial As String)
        Dim colName As String
        If adgv Is dgv Then
            colName = "colSerial_vc"
        Else
            colName = "colSelectedSerial_vc"
        End If

        For Each row As DataGridViewRow In adgv.Rows
            If Not (row.Cells(colName).Value Is Nothing) Then
                If (row.Cells(colName).Value.ToString = serial) Then
                    row.Selected = True
                    Exit For
                End If
            End If
        Next

    End Sub

    Private Sub txtSearchSerial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchSerial.KeyDown, txtSearchSelectedSerial.KeyDown
        If e.KeyCode = Keys.Enter Then
            If sender Is txtSearchSerial Then
                FindaSerial(dgv, txtSearchSerial.Text)
                txtSearchSerial.SelectAll()
            ElseIf sender Is txtSearchSelectedSerial Then
                FindaSerial(dgvselectedPos, txtSearchSelectedSerial.Text)
                txtSearchSelectedSerial.SelectAll()
            End If

        End If
    End Sub


#End Region

    Private Sub btnCancelReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelReturn.Click
        Try
            Dim Errmsg As String = String.Empty
            clsDalPosVisitor.VisitorID = cboVisitor.SelectedValue
            clsDalPosVisitor.BeginProc()
            For Each row As DataGridViewRow In dgvselectedPos.SelectedRows
                If row.Selected Then
                    'If row.Cells("colStatusDesc").Value.ToString() = "ارجاع به انیاک توسط بازاریاب" Then
                    If row.Cells("colOperationID").Value.ToString() = ClassDALPosVisitor.PosVisitorOperations.ReturnedToEniacByVisitor Then
                        clsDalPosVisitor.PosID = row.Cells("colSelectedPosID").Value
                        clsDalPosVisitor.Operation_tint = ClassDALPosVisitor.PosVisitorOperations.ReturnedToEniacByVisitor
                        clsDalPosVisitor.DateFa_vc = GetDateNow()
                        clsDalPosVisitor.DateTime = Date.Now()
                        Errmsg = clsDalPosVisitor.Delete()
                        'If Errmsg.Length > 0 Then
                        If Errmsg <> "null" Then
                            ShowErrorMessage(Errmsg)
                            clsDalPosVisitor.RollBackProc()
                            Exit Sub
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            clsDalPosVisitor.RollBackProc()
            Throw ex
        Finally
            clsDalPosVisitor.EndProc()
        End Try

        FillSelectedGrid()

    End Sub

#Region " B2B "
    Private Sub btnCheckB2B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckB2B.Click
        If modPublicMethod.ShowConfirmMessage("تغییر کند ؟ B2B وضعیت پز های انتخاب شده به") = True Then
            changeB2B(3) ' Change PosTypeID to B2B
        End If
    End Sub

    Private Sub changeB2B(ByVal checked As Int16)
        If dgvselectedPos.SelectedRows.Count > 0 Then
            Dim SelectedPos As String = String.Empty
            For Each row As DataGridViewRow In dgvselectedPos.SelectedRows
                SelectedPos += "," + row.Cells("colSelectedPosID").Value.ToString()
            Next
            SelectedPos = SelectedPos.Remove(0, 1)

            Try

                clsDalPos.BeginProc()
                clsDalPos.UpdateB2B(checked, SelectedPos)

            Catch ex As Exception
                clsDalPos.RollBackProc()
                Throw ex
            Finally
                clsDalPos.EndProc()
            End Try

            FillSelectedGrid()
        End If
    End Sub

    Private Sub btnUnCheckB2B_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnCheckB2B.Click
        If modPublicMethod.ShowConfirmMessage("وضعیت پز های انتخاب شده به وضعیت عادی تغییر کند ؟") = True Then
            changeB2B(1) ' Change PosTypeID to Regular
        End If
    End Sub

#End Region

    Private Sub btnSelectFromExcelSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFromExcelSelected.Click
        Try

            Me.dgvselectedPos.EndEdit()

            Me.Import()
            If dtImportExcel.Rows.Count > 0 Then

                Me.dtImportExcel.Columns(0).ColumnName = "Serial_vc"
                Me.dtImportExcel.DefaultView.Sort = "Serial_vc desc"
                Me.dvdgvselectedPos.Sort = "Serial_vc desc"

                For k As Integer = 0 To dgvselectedPos.RowCount - 1
                    dgvselectedPos.Rows(k).Selected = False
                Next

                Dim Selected As Integer = 0
                Dim i As Integer = 0
                Dim j As Integer = 0
                While i <= dtImportExcel.Rows.Count - 1
                    While j <= dvdgvselectedPos.Count - 1
                        If dtImportExcel.DefaultView(i)("Serial_vc").ToString <= dvdgvselectedPos(j)("Serial_vc").ToString Then
                            If dtImportExcel.DefaultView(i)("Serial_vc").ToString = dvdgvselectedPos(j)("Serial_vc").ToString Then
                                Me.dgvselectedPos.Rows(j).Selected = True
                                Selected += 1
                            End If
                            j = j + 1
                        Else
                            Exit While
                        End If
                    End While
                    i = i + 1
                End While

                Me.dgvselectedPos.EndEdit()

                ShowMessage(Selected.ToString + " پز انتخاب شد!")
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

  
End Class