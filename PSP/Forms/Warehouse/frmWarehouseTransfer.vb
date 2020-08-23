Imports System.IO
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Microsoft.Office.Interop


Public Class frmWarehouseTransfer

    Private posGood As List(Of Integer)
    Private statementType As WarehouseStatementType
    Private visitorID As Integer


#Region "Properties"
    Private Property warehouseStatement As ClassDALWarehouseStatement
    Private Property warehouseDetials As New List(Of ClassBLLWarehouseStatementGoodDetail)



    Private ReadOnly Property currentDetail As ClassBLLWarehouseStatementGoodDetail
        Get
            If Not dgvWarehouseDetail.CurrentRow Is Nothing AndAlso dgvWarehouseDetail.CurrentRow.Index <= Me.warehouseDetials.Count - 1 Then
                Return Me.warehouseDetials(dgvWarehouseDetail.CurrentRow.Index)
            End If
            Return Nothing
        End Get
    End Property

    Public Property StatementID As Integer

#End Region

#Region "Event Handlers"

    Private Sub dgvWarehouseDetail_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvWarehouseDetail.RowsAdded
        Me.fillRowNumber(Me.dgvWarehouseDetail, "warehouseOrder_int")
    End Sub

    Private Sub dgvWarehouseDetail_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWarehouseDetail.CellEnter

        dgvWarehouseSerials.Rows.Clear()
        If Not dgvWarehouseDetail.CurrentRow Is Nothing AndAlso dgvWarehouseDetail.CurrentRow.Index = e.RowIndex AndAlso Not Me.currentDetail Is Nothing Then
            For Each serial As String In Me.currentDetail.serials
                dgvWarehouseSerials.Rows.Add()
                Dim row As DataGridViewRow = New DataGridViewRow()
                row = dgvWarehouseSerials.Rows(dgvWarehouseSerials.RowCount - 1)
                row.Cells("SerialNO_vcS").Value = serial
            Next
            If Me.posGood.Contains(Me.currentDetail.GoodID) Then
                If (Me.statementType = WarehouseStatementType.Transfer AndAlso dgvWarehouseDetail.CurrentRow.Cells("RemindedGood").Value > 0) Or Me.statementType = WarehouseStatementType.Receipt Then
                    txtSerialNo.Enabled = True
                    btnExcelImport.Enabled = True
                End If
            Else
                txtSerialNo.Enabled = False
                btnExcelImport.Enabled = False
            End If
        Else
            txtSerialNo.Enabled = False
            btnExcelImport.Enabled = False
        End If

    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        If confirm() Then
            'show empty form
            Me.Close()
            Dim _frmTransfer As New frmWarehouseTransfer(Me.statementType)
            _frmTransfer.Show()
        End If

    End Sub

    Private Sub btnConfirmPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmPrint.Click

        If confirm() Then
            'show readonly form
            Me.warehouseStatement.BeginProc()
            Dim dt As DataTable = Me.warehouseStatement.GetStatementByStatementNO(Me.warehouseStatement.StatementNo)
            Me.warehouseStatement.EndProc()

            Dim statementID As Integer = dt(0)("warehousestatement_ID")
            Me.StatementID = statementID
            'Me.initialize()
            Me.Close()
            Dim _frmreport As New frmWarehouseStatementDetailsReport(Me.StatementID)
            _frmreport.Show()

        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmWarehouseTransfer_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.FormLoad()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message) 'modApplicationMessage.msgLoadFailed
            ClassError.LogError(ex)
        End Try

    End Sub

    Private Sub dgvWarehouseSerials_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvWarehouseSerials.CellClick
        If e.RowIndex > -1 AndAlso e.ColumnIndex = dgvWarehouseSerials.Columns("colDelete").Index Then
            dgvWarehouseSerials.Rows.RemoveAt(e.RowIndex)
            Me.currentDetail.serials.RemoveAt(e.RowIndex)
            Me.currentDetail.Count -= 1
            dgvWarehouseDetail.CurrentRow.Cells("GoodCount").Value = Me.currentDetail.Count
            lbCount.Text = Convert.ToString(Integer.Parse(lbCount.Text) - 1)
            Me.minusNexsRowsNumbers(Me.dgvWarehouseSerials, "SerialOrder_int", e.RowIndex)
        End If
    End Sub

    Private Sub dgvWarehouseDetail_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvWarehouseDetail.CellEndEdit

        Dim goodID As Integer = dgvWarehouseDetail.CurrentRow.Cells("Name_vc").Value
        If Me.currentDetail Is Nothing Then
            Dim detail As ClassBLLWarehouseStatementGoodDetail
            detail = New ClassBLLWarehouseStatementGoodDetail()
            detail.GoodID = goodID
            Me.warehouseDetials.Add(detail)
        Else
            If Me.currentDetail.serials.Count = 0 Then
                Me.currentDetail.GoodID = goodID
            Else
                MessageBox.Show("نمی توان کالای دارای سریال را تغییر داد")
                dgvWarehouseDetail.CurrentRow.Cells("Name_vc").Value = Me.currentDetail.GoodID
            End If
        End If


        If Not Me.currentDetail.GoodID = 0 Then
            dgvWarehouseDetail.CurrentRow.Cells("GoodID").Value = Me.currentDetail.GoodID
            Me.warehouseStatement.BeginProc()
            Dim count As Integer = Me.warehouseStatement.WarehouseState(Me.currentDetail.GoodID, ClassUserLoginDataAccess.ThisUser.UserID.ToString())
            dgvWarehouseDetail.CurrentRow.Cells("RemindedGood").Value = count.ToString()
            If IsNothing(dgvWarehouseDetail.CurrentRow.Cells("GoodCount").Value) Then
                dgvWarehouseDetail.CurrentRow.Cells("GoodCount").Value = 0
            End If

            If Not Me.posGood.Contains(Me.currentDetail.GoodID) Then
                dgvWarehouseDetail.CurrentRow.Cells("GoodCount").ReadOnly = False
            Else
                dgvWarehouseDetail.CurrentRow.Cells("GoodCount").ReadOnly = True
            End If
        End If


        If e.RowIndex > -1 AndAlso e.ColumnIndex = dgvWarehouseDetail.Columns("GoodCount").Index Then
            If Me.statementType = WarehouseStatementType.Transfer Then
                If Not dgvWarehouseDetail.CurrentRow.Cells("GoodCount").Value Is Nothing Then
                    If Integer.Parse(dgvWarehouseDetail.CurrentRow.Cells("GoodCount").Value) <= Integer.Parse(dgvWarehouseDetail.CurrentRow.Cells("RemindedGood").Value) Then
                        Me.currentDetail.Count = dgvWarehouseDetail.CurrentRow.Cells("GoodCount").Value
                    Else
                        MessageBox.Show("موجودی انبار کافی نمی باشد")
                        dgvWarehouseDetail.CurrentRow.Cells("GoodCount").Value = 0
                    End If
                End If
            Else
                Me.currentDetail.Count = dgvWarehouseDetail.CurrentRow.Cells("GoodCount").Value
            End If
        End If

    End Sub

    Private Sub txtSerialNo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtSerialNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim serial As String = txtSerialNo.Text
            If String.IsNullOrEmpty(serial) Then
                Return
            End If

            If Me.insertSerial(serial) Then
                txtSerialNo.Text = String.Empty
            End If

        End If
    End Sub

    Private Function insertSerial(ByVal serial As String) As Boolean
        'check serial & pos model
        Dim pos As ClassDALPos = New ClassDALPos(modPublicMethod.ConnectionString)
        pos.BeginProc()
        pos.Serial_vc = serial
        Dim dt As DataTable = pos.GetBySerialPos()
        pos.EndProc()
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0)("GOOD_ID")) Then
                Dim GoodID As Int32 = Integer.Parse(dt.Rows(0)("GOOD_ID"))
                Dim columnName As DataGridViewComboBoxCell = DirectCast(dgvWarehouseDetail.CurrentRow.Cells("Name_vc"), DataGridViewComboBoxCell)
                If Not columnName.Value = GoodID Then
                    MessageBox.Show(String.Format("شماره سریال وارد شده ({0}) با نوع انتخابی مطابقت ندارد", serial))
                    Return False
                End If
            Else
                MessageBox.Show(String.Format("اطلاعات این سریال ({0}) معتبر نمی باشد", serial))
                Return False
            End If
        Else
            MessageBox.Show(String.Format("این سریال ({0}) معتبر نمی باشد", serial))
            Return False
        End If

        'reject reapeted serials
        For Each detail As ClassBLLWarehouseStatementGoodDetail In Me.warehouseDetials
            If detail.serials.Contains(serial) Then
                MessageBox.Show(String.Format("سریال وارد شده ({0}) تکراری می باشد", serial))
                Return False
            End If
        Next

        'check whether serial in account warehouse
        Me.warehouseStatement.BeginProc()
        If Me.statementType = WarehouseStatementType.Transfer And Not IsSerialInWarehouse(serial) Then
            Me.warehouseStatement.EndProc()
            MessageBox.Show(String.Format("این سریال ({0}) در انبار شما موجود نمی باشد", serial))
            Return False
        ElseIf Me.statementType = WarehouseStatementType.Receipt And Not isSerialTrasfered(serial) Then
            Me.warehouseStatement.EndProc()
            MessageBox.Show(String.Format("حواله ای در وجه شما برای این سریال ({0}) موجود نمی باشد", serial))
            Return False
        End If
        Me.warehouseStatement.EndProc()

        If Not Me.currentDetail Is Nothing Then
            dgvWarehouseSerials.Rows.Add()
            Dim row As DataGridViewRow = New DataGridViewRow()
            row = dgvWarehouseSerials.Rows(dgvWarehouseSerials.RowCount - 1)
            row.Cells("SerialNO_vcS").Value = serial
            Me.currentDetail.serials.Add(serial)


            Me.currentDetail.Count += 1
            dgvWarehouseDetail.CurrentRow.Cells("GoodCount").Value = Me.currentDetail.Count

            If Not String.IsNullOrEmpty(lbCount.Text) Then
                lbCount.Text = Convert.ToString(Integer.Parse(lbCount.Text) + 1)
            Else
                lbCount.Text = 1
            End If

            dgvWarehouseDetail.CurrentRow.Cells("Name_vc").ReadOnly = True
        Else
            MessageBox.Show("ابتدا یک نوع دستگاه را انتخاب نمایید")
            Return False
        End If

        Return True
    End Function

    Private Sub btnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccount.Click
        Try
            Dim _frmAccountSearch As New frmAccountSearch
            _frmAccountSearch.ShowDialog()
            txtAccountID.Text = _frmAccountSearch.AccountID
            txtAccountName.Text = _frmAccountSearch.AccountName
            cmbProject.Focus()
        Catch ex As Exception
            txtAccountID.Text = ""
            txtAccountName.Text = ""
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim _frmreport As New frmWarehouseStatementDetailsReport(Me.StatementID)
        _frmreport.Show()
    End Sub

    Private Sub dgvWarehouseDetail_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvWarehouseDetail.DataError

    End Sub

    Private Sub btnExcelImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelImport.Click
        If ReadFromExcelfilePSPWarehouse() Then
            MessageBox.Show(String.Format("تعداد سریال های وارد شده {0} می باشد", dgvWarehouseSerials.Rows.Count.ToString))
        End If
    End Sub

    Private Sub dgvWarehouseSerials_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvWarehouseSerials.RowsAdded
        Me.fillRowNumber(Me.dgvWarehouseSerials, "SerialOrder_int")
    End Sub

#End Region

#Region "Methods"

    Private Sub FormLoad()

        Dim visitor As ClassDALWarehouse = New ClassDALWarehouse(modPublicMethod.ConnectionString)
        visitor.BeginProc()
        Dim dt As DataTable = visitor.GetAllUserVisitorByUserID(ClassUserLoginDataAccess.ThisUser.UserID)
        visitor.EndProc()
        Me.visitorID = dt.Rows(0)("Visitor_ID")

        Me.initialize()

    End Sub

    Private Function confirm() As Boolean
        If String.IsNullOrEmpty(Me.dttxtDate.Value) Then
            MessageBox.Show("تاریخ سند را مشخص نمایید")
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtAccountID.Text) Then
            MessageBox.Show("طرف حساب را انتخاب نمایید")
            Return False
        End If

        If Me.cmbProject.SelectedValue Is Nothing Then
            MessageBox.Show("پروژه را انتخاب نمایید")
            Return False
        End If

        If Me.cmbReason.SelectedValue Is Nothing Then
            MessageBox.Show("دلیل سند را انتخاب نمایید")
            Return False
        End If

        Dim details As New List(Of ClassBLLWarehouseStatementGoodDetail)

        For Each detail As ClassBLLWarehouseStatementGoodDetail In Me.warehouseDetials
            If detail.Count > 0 Then
                details.Add(detail)
            End If
        Next

        If details.Count > 0 Then
            Try
                Me.warehouseStatement.BeginProc()
                Me.warehouseStatement.StatementType = Me.statementType
                Me.warehouseStatement.ProjectID = Me.cmbProject.SelectedValue
                Me.warehouseStatement.DeliveryID = Me.visitorID
                Me.warehouseStatement.AccountID = Int32.Parse(Me.txtAccountID.Text)
                Me.warehouseStatement.StatementNo = Int32.Parse(Me.txtStatementNo.Text)
                Me.warehouseStatement.ReasonID = Me.cmbReason.SelectedValue
                Me.warehouseStatement.Date_vc = Me.dttxtDate.Value
                Me.warehouseStatement.Comment = Me.txtWarehouseDescription.Text
                Me.warehouseStatement.CreatedDate = DateTime.Today
                Me.warehouseStatement.UserID = ClassUserLoginDataAccess.ThisUser.UserID
                Me.warehouseStatement.Details = details
                Me.warehouseStatement.register()
                Me.warehouseStatement.EndProc()

            Catch ex As Exception
                Throw ex
            End Try
            Return True
        Else
            MessageBox.Show("حداقل یک کالا را وارد نمایید")
            Return False
        End If
        Return True
    End Function

    Private Sub minusNexsRowsNumbers(ByVal dataGridView As DataGridView, ByVal columnName As String, ByVal rowIndex As Integer)
        For i As Integer = rowIndex To dataGridView.Rows.Count - 1
            dataGridView.Rows(i).Cells(columnName).Value -= 1
        Next
    End Sub

    Private Sub fillRowNumber(ByVal dataGridView As DataGridView, ByVal columnName As String)

        Dim currentRowIndex As Integer = dataGridView.Rows.Count - 1
        If dataGridView.AllowUserToAddRows Then
            currentRowIndex -= 1
        End If

        If currentRowIndex = 0 Then
            dataGridView.Rows(currentRowIndex).Cells(columnName).Value = 1
        ElseIf currentRowIndex > 0 Then
            dataGridView.Rows(currentRowIndex).Cells(columnName).Value = dataGridView.Rows(currentRowIndex - 1).Cells(columnName).Value + 1
        End If

    End Sub

    Private Sub fillStatementNo()
        Me.warehouseStatement.BeginProc()
        Me.txtStatementNo.Text = Me.warehouseStatement.GetNextStatementNo().ToString()
        Me.warehouseStatement.EndProc()
    End Sub

    Private Sub fillReasons()
        Try

            Dim _GetAllWarehouseByUser As New DataTable
            Dim reason As ClassDalWarehouseReason = New ClassDalWarehouseReason(modPublicMethod.ConnectionString)
            reason.BeginProc()
            _GetAllWarehouseByUser = reason.GetAll()
            cmbReason.DataSource = _GetAllWarehouseByUser
            cmbReason.ValueMember = "Reason_ID"
            cmbReason.DisplayMember = "Name_nvc"
            If _GetAllWarehouseByUser.Rows.Count > 0 Then
                cmbReason.SelectedIndex = -1
            End If
            reason.EndProc()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub fillProjects()
        Try
            Dim _GetAllProjects As New DataTable
            Dim project As ClassDALProject = New ClassDALProject(modPublicMethod.ConnectionString)
            project.BeginProc()
            _GetAllProjects = project.GetAllCMSProject()
            cmbProject.DataSource = _GetAllProjects
            cmbProject.ValueMember = "cmsprojectid_int"
            cmbProject.DisplayMember = "Name_nvc"
            If _GetAllProjects.Rows.Count > 0 Then
                cmbProject.SelectedIndex = -1
            End If
            project.EndProc()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub fillGoods()
        Try
            Dim allGoods As DataTable
            Dim good As ClassDalGood = New ClassDalGood(modPublicMethod.ConnectionString)
            good.BeginProc()
            allGoods = good.GetAll()
            Dim nameColumn As DataGridViewComboBoxColumn = DirectCast(dgvWarehouseDetail.Columns("Name_vc"), DataGridViewComboBoxColumn)
            nameColumn.DataSource = allGoods
            nameColumn.ValueMember = "Good_ID"
            nameColumn.DisplayMember = "Name_nvc"
            good.EndProc()

            Me.posGood = New List(Of Integer)
            For Each row As DataRow In allGoods.Rows
                If Not IsDBNull(row("PosModel_id")) Then
                    Me.posGood.Add(row("Good_id"))
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ReadFromExcelfilePSPWarehouse() As Boolean

        Try
            Dim dtImportExcel As New DataTable
            Dim frm As New OpenFileDialog
            frm.Filter = "Excel Files (*.xlsx, *.xls)|*.xlsx;*.xls|Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If frm.FileName = String.Empty Then
                    Exit Function
                End If
                Dim clsExcel As New ClassExcel(frm.FileName)
                dtImportExcel = clsExcel.Read(1, False)

                For Each row As DataRow In dtImportExcel.Rows
                    If Not Me.insertSerial(row(0).ToString()) Then
                        Return False
                    End If
                Next
                Return True
            End If
        Catch ex As Exception
            Throw ex
            Return False
        End Try
        Return False

    End Function

    Private Sub initialize()
        Me.warehouseStatement = New ClassDALWarehouseStatement(modPublicMethod.ConnectionString)

        fillProjects()
        fillReasons()
        fillGoods()

        If Me.StatementID = 0 Then
            fillStatementNo()
            dttxtDate.Value = GetDateNow()
        Else

            Me.GroupBox1.Enabled = False
            Me.dgvWarehouseDetail.ReadOnly = True
            Me.GroupBox3.Enabled = False
            Me.btnConfirmPrint.Enabled = False
            Me.btnConfirm.Enabled = False
            Me.btnCancel.Text = "بستن"
            Me.dgvWarehouseDetail.AllowUserToAddRows = False
            Me.dgvWarehouseDetail.AutoGenerateColumns = False
            Me.dgvWarehouseDetail.Columns("RemindedGood").Visible = False
            dgvWarehouseDetail.Columns("Name_vc").ReadOnly = True
            Me.dgvWarehouseSerials.Columns("colDelete").Visible = False

            'show statement header
            Dim warehouse As ClassDALWarehouseStatement = New ClassDALWarehouseStatement(modPublicMethod.ConnectionString)
            warehouse.BeginProc()
            Dim statement As DataTable = warehouse.GetStatement(Me.StatementID)
            warehouse.EndProc()

            If statement.Rows(0)("warehousestatementtype_id") = 1 Then
                Me.statementType = WarehouseStatementType.Transfer
            Else
                Me.statementType = WarehouseStatementType.Receipt
            End If

            'show statement header
            Me.txtStatementNo.Text = statement.Rows(0)("statementno").ToString()
            Me.dttxtDate.Value = statement.Rows(0)("date_vc")
            Me.cmbProject.SelectedValue = statement.Rows(0)("project_id")
            Me.cmbReason.SelectedValue = statement.Rows(0)("reason_id")
            Me.txtAccountID.Text = statement.Rows(0)("account_id").ToString()
            Me.txtAccountName.Text = statement.Rows(0)("account").ToString()
            Me.txtWarehouseDescription.Text = statement.Rows(0)("comments").ToString()

            'show statement detail
            warehouse.BeginProc()
            Dim details As DataTable = warehouse.GetStatementDetail(statement.Rows(0)("warehousestatement_id"))
            warehouse.EndProc()
            If Me.statementType = WarehouseStatementType.Transfer Then
                For Each row As DataRow In details.Rows
                    row("count") = Math.Abs(row("count"))
                Next
            End If
            Me.dgvWarehouseDetail.DataSource = details

            For Each detail As DataRow In details.Rows
                Dim wsDetail As New ClassBLLWarehouseStatementGoodDetail
                wsDetail.GoodID = detail("good_id")
                wsDetail.Count = detail("count")

                ' fill statement serials
                If Me.posGood.Contains(wsDetail.GoodID) Then
                    warehouse.BeginProc()
                    Dim serials As DataTable = warehouse.GetStatementSerials(statement.Rows(0)("warehousestatement_id"), detail("warehousestatementdetail_id"))
                    warehouse.EndProc()
                    For Each serial As DataRow In serials.Rows
                        wsDetail.serials.Add(serial("serial_vc").ToString())
                    Next
                    'calculate & show all serials count
                    If Not String.IsNullOrEmpty(lbCount.Text) Then
                        lbCount.Text = Convert.ToString(Integer.Parse(lbCount.Text) + wsDetail.serials.Count)
                    Else
                        lbCount.Text = wsDetail.serials.Count.ToString()
                    End If
                End If
                Me.warehouseDetials.Add(wsDetail)
            Next


        End If

        If Me.statementType = WarehouseStatementType.Transfer Then
            Me.Text += " - حواله"
        Else
            Me.Text += " - رسید"
        End If
    End Sub

    Private Function isSerialTrasfered(ByVal serial As String) As Boolean

        Me.warehouseStatement.BeginProc()
        Dim dtserials As DataTable = Me.warehouseStatement.getSerialLastState(serial)
        Me.warehouseStatement.EndProc()
        If dtserials.Rows.Count = 0 Then
            Return True
        Else
            Dim accountID As Integer = dtserials.Rows(0)("account_id")
            Dim statementTypeID As Integer = dtserials.Rows(0)("warehousestatementtype_id")
            If Me.visitorID = accountID And statementTypeID = 1 Then
                Return True
            End If
        End If
        Return False

    End Function

    Public Function IsSerialInWarehouse(ByVal serial As String) As Boolean
        Me.warehouseStatement.BeginProc()
        Dim dtserials As DataTable = Me.warehouseStatement.getSerialLastState(serial)
        Me.warehouseStatement.EndProc()
        If dtserials.Rows.Count > 0 Then
            Dim deliveryID As Integer = dtserials.Rows(0)("delivery_id")
            Dim statementTypeID As Integer = dtserials.Rows(0)("warehousestatementtype_id")
            If Me.visitorID = deliveryID And statementTypeID = 2 Then
                Return True
            End If
        End If
        Return False

    End Function

#End Region

    Public Sub New(ByVal statementID As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.StatementID = statementID
    End Sub

    Public Sub New(ByVal statementType As WarehouseStatementType)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.statementType = statementType

    End Sub

    

    

    
End Class
