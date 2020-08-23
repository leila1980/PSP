Public Class frmAccounting
    Private dtDetail As New DataTable
    Private da As New ClassDALAccount(ConnectionString)
   
    Private Sub frmAccounting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub

    Private Sub frmAccounting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.Text = "افتتاح حساب"
            Me.GotoState(State.Load)
            Me.btnPrint.Visible = False
            Me.ToolStripSeparator4.Visible = False
            Me.InitDataGridView()
            Me.SetMaxValue()
            Me.nudNumber_bint.Value = Me.nudNumber_bint.Maximum
            Me.ShowInfo(Me.nudNumber_bint.Value)
            Me.GotoState(State.VIEW)
            If Me.txtID_bint.Text = "" Then
                Me.CurrentRecordIsNotFound()
            End If

        Catch ex As Exception
            ShowMessage(ex.Message)
        End Try
    End Sub

    Public Overrides Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.GotoState(State.ADD)
        Me.ClearForm()
        Me.txtSaveDate_vc.Value = modPublicMethod.GetDateNow
    End Sub

    Public Overrides Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Me.ErrPro.Clear()
            Me.SetMaxValue()
            Me.nudNumber_bint.Value = Me.nudNumber_bint.Maximum
            Me.ShowInfo(Me.nudNumber_bint.Value)
            VIEWSTATE()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Function ValidateAccountForDelete(ByVal AccountID As Int64) As Boolean
        Try
            Dim daContract As New ClassDALContract(ConnectionString)

            daContract.AAccountID = AccountID
            Dim dtAccount As DataTable = daContract.GetByAccountIDAccount()
            If dtAccount.Rows.Count > 0 AndAlso (IsDBNull(dtAccount.Rows(0).Item("AccountNO_vc")) = False AndAlso dtAccount.Rows(0).Item("AccountNO_vc").ToString <> "") Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Overrides Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Me.txtID_bint.Text = "" Then
                Exit Sub
            End If
            If ShowConfirmDeleteMessage() = False Then
                Exit Sub
            End If

            For Each dr As DataRow In Me.dtDetail.Rows
                If ValidateAccountForDelete(Me.DataGridView1.SelectedRows(0).Cells("colAAccountID").Value) = False Then
                    ShowMessage(msgAccountListHasAccountNO)
                    Exit Sub
                End If
            Next

            da.BeginProc()
            da.DeleteAccountingDetail(Me.txtID_bint.Text)
            da.DeleteAccountingHeader(Me.txtID_bint.Text)
            Me.SetMaxValue()
            Me.nudNumber_bint.Value = Me.nudNumber_bint.Maximum
            Me.ShowInfo(Me.nudNumber_bint.Value)
            Me.VIEWSTATE()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            da.EndProc()
        End Try
    End Sub

    Public Overrides Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.GotoState(State.EDIT)
    End Sub

    Public Overrides Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.CurrentState = State.ADD Then
            Dim frm As New frmAccountingList(Me.dtDetail)
            frm.ShowDialog()
        Else
            Dim frm As New frmAccountingList(Me.dtDetail, Me.txtID_bint.Text)
            frm.ShowDialog()
        End If
    End Sub

    Public Overrides Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                If Me.ValidateAccountForDelete(Me.DataGridView1.SelectedRows(0).Cells("colAAccountID").Value) = False Then
                    ShowMessage(msgAccountHasAccountNO)
                ElseIf ShowConfirmDeleteMessage() = True Then
                    Dim dr() As DataRow = Me.dtDetail.Select("AAccountID=" + Me.DataGridView1.SelectedRows(0).Cells("colAAccountID").Value.ToString)
                    If dr.Length > 0 Then
                        dr(0).Delete()
                        Me.dtDetail.AcceptChanges()
                    End If
                End If

                'For i As Integer = 0 To dtDetail.Rows.Count - 1
                '    dtDetail.Rows(i).Item("Order_int") = i + 1
                'Next
                'dtDetail.AcceptChanges()
            End If


        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Overrides Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Select Case Me.CurrentState
                Case State.ADD
                    da.BeginProc()

                    If Me.ValidateForm_ADD = False Then
                        Exit Sub
                    End If

                    Dim Number As Integer
                    Dim ID As Integer
                    Me.InsertData(Number, ID)
                    Me.SetMaxValue()

                    If Me.nudNumber_bint.Maximum = Number Then
                        Me.txtID_bint.Text = ID
                        Me.nudNumber_bint.Value = Number
                    Else
                        Me.nudNumber_bint.Maximum = Me.nudNumber_bint.Maximum
                        Me.ShowInfo(Me.nudNumber_bint.Maximum)
                    End If

                    VIEWSTATE()
                Case State.EDIT
                    da.BeginProc()

                    If Me.ValidateForm_Edit = False Then
                        Exit Sub
                    End If

                    Dim Header As New ClassDALAccount.AccountHeader
                    Dim Detail As New ClassDALAccount.AccountDetail
                    Dim AccountHeaderID As Integer = Me.txtID_bint.Text

                    Header.SaveDate_vc = Me.txtSaveDate_vc.Value
                    Header.Number_bint = Me.nudNumber_bint.Value
                    Header.Description_nvc = Me.txtDescription_nvc.Text
                    Header.AccountingHeaderID = Me.txtID_bint.Text

                    da.UpdateAccountingHeader(Header)
                    da.DeleteAccountingDetail(Header.AccountingHeaderID)
                    For Each dr As DataRow In dtDetail.Rows
                        Detail.AccountID = dr.Item("AAccountID")
                        Detail.AccountingDetailID = 0
                        Detail.AccountingHeaderID = AccountHeaderID
                        Detail.AccountingDetailID = da.InsertAccountDetail(Detail)
                        dr("AAccountingDetailID") = Detail.AccountingDetailID
                    Next

                    VIEWSTATE()
            End Select
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            da.EndProc()
        End Try
    End Sub

    Private Sub InitDataGridView()
        Me.DataGridView1.AutoGenerateColumns = False

        'Dim colOrder_int As New System.Windows.Forms.DataGridViewTextBoxColumn
        'colOrder_int.DataPropertyName = "Order_int"
        'colOrder_int.HeaderText = "ردیف"
        'colOrder_int.Name = "colOrder_int"
        'colOrder_int.ReadOnly = True
        'colOrder_int.Width = 50
        'Me.DataGridView1.Columns.Add(colOrder_int)

        Dim colFirstName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFirstName_nvc.DataPropertyName = "FirstName_nvc"
        colFirstName_nvc.HeaderText = "نام"
        colFirstName_nvc.Name = "colFirstName_nvc"
        colFirstName_nvc.ReadOnly = True
        colFirstName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colFirstName_nvc)

        Dim colLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colLastName_nvc.DataPropertyName = "LastName_nvc"
        colLastName_nvc.HeaderText = "نام خانوادگی"
        colLastName_nvc.Name = "colLastName_nvc"
        colLastName_nvc.ReadOnly = True
        colLastName_nvc.Width = 200
        Me.DataGridView1.Columns.Add(colLastName_nvc)

        Dim colNationalCode_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colNationalCode_nvc.DataPropertyName = "NationalCode_nvc"
        colNationalCode_nvc.HeaderText = "کد ملی"
        colNationalCode_nvc.Name = "colNationalCode_nvc"
        colNationalCode_nvc.ReadOnly = True
        colNationalCode_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colNationalCode_nvc)


        Dim colContractID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractID.DataPropertyName = "ContractID"
        colContractID.HeaderText = "کد قرار داد"
        colContractID.Name = "colContractID"
        colContractID.ReadOnly = True
        colContractID.Width = 100
        Me.DataGridView1.Columns.Add(colContractID)

        Dim colContractNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractNo_vc.DataPropertyName = "ContractNo_vc"
        colContractNo_vc.HeaderText = "شماره قرار داد"
        colContractNo_vc.Name = "colContractNo_vc"
        colContractNo_vc.ReadOnly = True
        colContractNo_vc.Width = 100
        Me.DataGridView1.Columns.Add(colContractNo_vc)

        Dim colDate_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDate_vc.DataPropertyName = "Date_vc"
        colDate_vc.HeaderText = "تاریخ عقد قرارداد"
        colDate_vc.Name = "colDate_vc"
        colDate_vc.ReadOnly = True
        colDate_vc.Width = 120
        Me.DataGridView1.Columns.Add(colDate_vc)

        Dim colSaveDate_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSaveDate_vc.DataPropertyName = "SaveDate_vc"
        colSaveDate_vc.HeaderText = "تاریخ ثبت"
        colSaveDate_vc.Name = "colSaveDate_vc"
        colSaveDate_vc.ReadOnly = True
        colSaveDate_vc.Width = 80
        Me.DataGridView1.Columns.Add(colSaveDate_vc)


        Dim colAAccountID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountID.DataPropertyName = "AAccountID"
        colAAccountID.HeaderText = "کد حساب"
        colAAccountID.Name = "colAAccountID"
        colAAccountID.ReadOnly = True
        colAAccountID.Visible = False
        Me.DataGridView1.Columns.Add(colAAccountID)

        Dim colAAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountNO_vc.DataPropertyName = "AAccountNO_vc"
        colAAccountNO_vc.HeaderText = "شماره حساب"
        colAAccountNO_vc.Name = "colAccountNO_vc"
        colAAccountNO_vc.ReadOnly = True
        colAAccountNO_vc.Width = 100
        Me.DataGridView1.Columns.Add(colAAccountNO_vc)

        Dim colACardNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colACardNo_vc.DataPropertyName = "ACardNo_vc"
        colACardNo_vc.HeaderText = "شماره کارت"
        colACardNo_vc.Name = "colACardNo_vc"
        colACardNo_vc.ReadOnly = True
        colACardNo_vc.Width = 100
        Me.DataGridView1.Columns.Add(colACardNo_vc)

        Dim colAAccountTypeIDName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountTypeIDName_nvc.DataPropertyName = "AAccountTypeIDName_nvc"
        colAAccountTypeIDName_nvc.HeaderText = "نوع حساب"
        colAAccountTypeIDName_nvc.Name = "colAAccountTypeIDName_nvc"
        colAAccountTypeIDName_nvc.ReadOnly = True
        colAAccountTypeIDName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colAAccountTypeIDName_nvc)

        Dim colABranchIDName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colABranchIDName_nvc.DataPropertyName = "ABranchIDName_nvc"
        colABranchIDName_nvc.HeaderText = "شعبه"
        colABranchIDName_nvc.Name = "colABranchIDName_nvc"
        colABranchIDName_nvc.ReadOnly = True
        colABranchIDName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colABranchIDName_nvc)


    End Sub

    Private Function GetMaxNumber()
        Try
            Dim dt As New DataTable
            dt = da.GetTheLatestAccountingHeaderNumber()
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item("Number_bint")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function ValidateForm_ADD() As Boolean
        Dim res As Boolean = True
        Me.ErrPro.Clear()

        If Me.txtSaveDate_vc.Value = "" Then
            res = False
            Me.ErrPro.SetError(Me.txtSaveDate_vc, "تاریخ را وارد کنید")
        End If

        Dim dtDuplicat As New DataTable
        dtDuplicat = da.GetAllContractingParty_Contract_Account_AvailableForAccounting

        For Each dr As DataRow In dtDetail.Rows
            Dim drSelect() As DataRow = dtDuplicat.Select("AAccountID=" + dr.Item("AAccountID").ToString)
            If drSelect.Length = 0 Then
                dr.RowError = "حساب مورد نظر قبلا افتتاح شده است"
                res = False
            End If
        Next

        Return res
    End Function

    Private Function ValidateForm_Edit() As Boolean
        Dim res As Boolean = True
        Me.ErrPro.Clear()

        If Me.txtSaveDate_vc.Value = "" Then
            res = False
            Me.ErrPro.SetError(Me.txtSaveDate_vc, "تاریخ را وارد کنید")
        End If

        Dim dtDuplicat As New DataTable
        dtDuplicat = da.GetAllContractingParty_Contract_Account_AvailableForAccounting
        Dim dtCurrentRecord As New DataTable
        dtCurrentRecord = da.GetByIDAccountingDetail(Me.txtID_bint.Text, ClassUserLoginDataAccess.ThisUser.ProjectID)

        For Each dr As DataRow In dtDetail.Rows
            Dim drSelect() As DataRow = dtDuplicat.Select("AAccountID=" + dr.Item("AAccountID").ToString)
            If drSelect.Length = 0 Then
                Dim drCurrentSelect() As DataRow = dtCurrentRecord.Select("AAccountID=" + dr.Item("AAccountID").ToString)
                If drCurrentSelect.Length = 0 Then
                    dr.RowError = "قرارداد مورد نظر قبلا جهت افتتاح حساب ارسال شده است"
                    res = False
                End If
            End If
        Next

        Return res
    End Function

    Private Sub CurrentRecordIsNotFound()
        Me.btnEdit.Enabled = False
        Me.btnPrint.Enabled = False
        Me.btnDelete.Enabled = False
    End Sub

    Private Sub ShowInfo(ByVal Number As Integer)
        Try
            Dim dtMHDHeader As New DataTable
            Dim dtMHDDetail As New DataTable
            dtMHDHeader = da.GetByNumberAccountingHeader(Number)
            If dtMHDHeader.Rows.Count > 0 Then
                Me.txtID_bint.Text = dtMHDHeader.Rows(0).Item("AccountingHeaderID").ToString
                Me.txtSaveDate_vc.Value = dtMHDHeader.Rows(0).Item("SaveDate_vc").ToString
                Me.txtDescription_nvc.Text = dtMHDHeader.Rows(0).Item("Description_nvc").ToString
                dtDetail = da.GetByIDAccountingDetail(Me.txtID_bint.Text, ClassUserLoginDataAccess.ThisUser.ProjectID)
                Me.DataGridView1.DataSource = Me.dtDetail
                'Me.dtDetail.Columns.Add(New DataColumn("Order_int", GetType(Int64)))
                'For i As Integer = 0 To dtDetail.Rows.Count - 1
                '    dtDetail.Rows(i).Item("Order_int") = i + 1
                'Next
                'dtDetail.AcceptChanges()
            Else
                Me.txtID_bint.Clear()
                Me.txtDescription_nvc.Clear()
                Me.txtSaveDate_vc.Value = ""
                dtDetail = da.GetByIDAccountingDetail(-1, ClassUserLoginDataAccess.ThisUser.ProjectID)
                Me.DataGridView1.DataSource = Me.dtDetail
                'Me.dtDetail.Columns.Add(New DataColumn("Order_int", GetType(Int64)))
                'For i As Integer = 0 To dtDetail.Rows.Count - 1
                '    dtDetail.Rows(i).Item("Order_int") = i + 1
                'Next
                'dtDetail.AcceptChanges()
            End If
            Me.VIEWSTATE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InsertData(ByRef Number As Int64, ByRef ID As Int64)
        Try
            Dim Header As New ClassDALAccount.AccountHeader
            Dim Detail As New ClassDALAccount.AccountDetail
            Dim AccountHeaderID As Integer

            Header.SaveDate_vc = Me.txtSaveDate_vc.Value
            Header.Number_bint = Me.GetMaxNumber + 1
            Header.Description_nvc = Me.txtDescription_nvc.Text
            Header.AccountingHeaderID = 0

            AccountHeaderID = da.InsertAccountHeader(Header)
            For Each dr As DataRow In dtDetail.Rows
                Detail.AccountID = dr.Item("AAccountID")
                Detail.AccountingDetailID = 0
                Detail.AccountingHeaderID = AccountHeaderID
                Detail.AccountingDetailID = da.InsertAccountDetail(Detail)
                dr("AAccountingDetailID") = Detail.AccountingDetailID
            Next
            ID = AccountHeaderID
            Number = Header.Number_bint
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VIEWSTATE()
        Me.GotoState(State.VIEW)
        If Me.nudNumber_bint.Value = 0 OrElse Me.txtID_bint.Text = "" Then
            Me.CurrentRecordIsNotFound()
        End If
    End Sub

    Private Sub SetMaxValue()
        Me.nudNumber_bint.Maximum = Me.GetMaxNumber
        If Me.nudNumber_bint.Maximum > 0 Then
            Me.nudNumber_bint.Minimum = 1
        Else
            Me.nudNumber_bint.Minimum = 0
        End If
    End Sub

    Public Overrides Sub nudNumber_bint_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.ShowInfo(Me.nudNumber_bint.Value)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ClearForm()
        Me.txtSaveDate_vc.Value = ""
        Me.txtDescription_nvc.Text = ""
        Me.dtDetail.Rows.Clear()
        dtDetail.AcceptChanges()
    End Sub

    Private Sub frmAccounting_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
End Class