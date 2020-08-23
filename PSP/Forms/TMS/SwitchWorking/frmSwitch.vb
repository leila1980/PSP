Public Class frmSwitch
    Private dtDetail As New DataTable
    Private da As New ClassDALSwitch(ConnectionString)

    Private Sub frmSwitch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub

    Private Sub frmSwitch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.Text = "سوئیچ"
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

    Private Function ValidateSwitchForDelete(ByVal DeviceID As Int64) As Boolean
        Try
            Dim daContract As New ClassDALContract(ConnectionString)

            daContract.DDeviceID = DeviceID
            Dim dtSwitch As DataTable = daContract.GetByDeviceIDDevice()
            If dtSwitch.Rows.Count > 0 AndAlso (IsDBNull(dtSwitch.Rows(0).Item("Password_vc")) = False AndAlso dtSwitch.Rows(0).Item("Password_vc").ToString <> "") Then
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
                If ValidateSwitchForDelete(Me.DataGridView1.SelectedRows(0).Cells("colDDeviceID").Value) = False Then
                    ShowMessage(msgAccountListHasAccountNO)
                    Exit Sub
                End If
            Next

            da.BeginProc()
            da.DeleteSwitchDetail(Me.txtID_bint.Text)
            da.DeleteSwitchHeader(Me.txtID_bint.Text)
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
            Dim frm As New frmSwitchList(Me.dtDetail)
            frm.ShowDialog()
        Else
            Dim frm As New frmSwitchList(Me.dtDetail, Me.txtID_bint.Text)
            frm.ShowDialog()
        End If
    End Sub

    Public Overrides Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                If Me.ValidateSwitchForDelete(Me.DataGridView1.SelectedRows(0).Cells("colDDeviceID").Value) = False Then
                    ShowMessage(msgAccountHasAccountNO)
                ElseIf ShowConfirmDeleteMessage() = True Then
                    Dim dr() As DataRow = Me.dtDetail.Select("DDeviceID=" + Me.DataGridView1.SelectedRows(0).Cells("colDDeviceID").Value.ToString)
                    If dr.Length > 0 Then
                        dr(0).Delete()
                        Me.dtDetail.AcceptChanges()
                    End If
                End If
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
                    Dim ID As Long
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

                    Dim Header As New ClassDALSwitch.SwitchHeader
                    Dim Detail As New ClassDALSwitch.SwitchDetail
                    Dim SwitchHeaderID As Long = Me.txtID_bint.Text

                    Header.SaveDate_vc = Me.txtSaveDate_vc.Value
                    Header.Number_bint = Me.nudNumber_bint.Value
                    Header.Description_nvc = Me.txtDescription_nvc.Text
                    Header.SwitchHeaderID = Me.txtID_bint.Text

                    da.UpdateSwitchHeader(Header)
                    da.DeleteSwitchDetail(Header.SwitchHeaderID)
                    For Each dr As DataRow In dtDetail.Rows
                        Detail.DeviceID = dr.Item("DDeviceID")
                        Detail.SwitchDetailID = 0
                        Detail.SwitchHeaderID = SwitchHeaderID
                        Detail.SwitchDetailID = da.InsertSwitchDetail(Detail)
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
        colContractID.Visible = False

        Dim colContractNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractNo_vc.DataPropertyName = "ContractNo_vc"
        colContractNo_vc.HeaderText = "شماره قرار داد"
        colContractNo_vc.Name = "colContractNo_vc"
        colContractNo_vc.ReadOnly = True
        colContractNo_vc.Width = 100
        Me.DataGridView1.Columns.Add(colContractNo_vc)

        Dim colAAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountNO_vc.DataPropertyName = "AAccountNO_vc"
        colAAccountNO_vc.HeaderText = "شماره حساب"
        colAAccountNO_vc.Name = "colAAccountNO_vc"
        colAAccountNO_vc.ReadOnly = True
        colAAccountNO_vc.Width = 120
        Me.DataGridView1.Columns.Add(colAAccountNO_vc)

        Dim colACardNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colACardNO_vc.DataPropertyName = "ACardNO_vc"
        colACardNO_vc.HeaderText = "شماره کارت"
        colACardNO_vc.Name = "colACardNO_vc"
        colACardNO_vc.ReadOnly = True
        colACardNO_vc.Width = 80
        Me.DataGridView1.Columns.Add(colACardNO_vc)

        Dim colSStoreID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSStoreID.DataPropertyName = "SStoreID"
        colSStoreID.HeaderText = "کد فروشگاه"
        colSStoreID.Name = "colSStoreID"
        colSStoreID.ReadOnly = True
        colSStoreID.Visible = False
        Me.DataGridView1.Columns.Add(colSStoreID)
        colSStoreID.Visible = False

        Dim colSName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSName_nvc.DataPropertyName = "SName_nvc"
        colSName_nvc.HeaderText = "نام فروشگاه"
        colSName_nvc.Name = "colSName_nvc"
        colSName_nvc.ReadOnly = True
        colSName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colSName_nvc)

        Dim colDDeviceID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDDeviceID.DataPropertyName = "DDeviceID"
        colDDeviceID.HeaderText = "کد دستگاه"
        colDDeviceID.Name = "colDDeviceID"
        colDDeviceID.ReadOnly = True
        colDDeviceID.Width = 100
        Me.DataGridView1.Columns.Add(colDDeviceID)
        colDDeviceID.Visible = False

        Dim colDCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDCode_vc.DataPropertyName = "DCode_vc"
        colDCode_vc.HeaderText = "پز کد"
        colDCode_vc.Name = "colDCode_vc"
        colDCode_vc.ReadOnly = True
        colDCode_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDCode_vc)

        Dim colDOutlet_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDOutlet_vc.DataPropertyName = "DOutlet_vc"
        colDOutlet_vc.HeaderText = "Outlet"
        colDOutlet_vc.Name = "colDOutlet_vc"
        colDOutlet_vc.ReadOnly = True
        colDOutlet_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDOutlet_vc)

        Dim colDVat_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDVat_vc.DataPropertyName = "DVat_vc"
        colDVat_vc.HeaderText = "DVat_vc"
        colDVat_vc.Name = "colDVat_vc"
        colDVat_vc.ReadOnly = True
        colDVat_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDVat_vc)

        Dim colDMerchant_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDMerchant_vc.DataPropertyName = "DMerchant_vc"
        colDMerchant_vc.HeaderText = "Merchant"
        colDMerchant_vc.Name = "colDMerchant_vc"
        colDMerchant_vc.ReadOnly = True
        colDMerchant_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDMerchant_vc)

        Dim colPPosID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPPosID.DataPropertyName = "PPosID"
        colPPosID.HeaderText = "کد پز"
        colPPosID.Name = "colPPosID"
        colPPosID.ReadOnly = True
        colPPosID.Width = 100
        Me.DataGridView1.Columns.Add(colPPosID)
        colPPosID.Visible = False

        Dim colPSerial_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPSerial_vc.DataPropertyName = "PSerial_vc"
        colPSerial_vc.HeaderText = "سریال پز"
        colPSerial_vc.Name = "colPSerial_vc"
        colPSerial_vc.ReadOnly = True
        colPSerial_vc.Width = 100
        Me.DataGridView1.Columns.Add(colPSerial_vc)

        Dim colPPropertyNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPPropertyNO_vc.DataPropertyName = "PPropertyNO_vc"
        colPPropertyNO_vc.HeaderText = "شماره اموال"
        colPPropertyNO_vc.Name = "colPPropertyNO_vc"
        colPPropertyNO_vc.ReadOnly = True
        colPPropertyNO_vc.Width = 100
        Me.DataGridView1.Columns.Add(colPPropertyNO_vc)

        Dim colPEniacCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPEniacCode_vc.DataPropertyName = "PEniacCode_vc"
        colPEniacCode_vc.HeaderText = "کد پیگیری"
        colPEniacCode_vc.Name = "colPEniacCode_vc"
        colPEniacCode_vc.ReadOnly = True
        colPEniacCode_vc.Width = 100
        Me.DataGridView1.Columns.Add(colPEniacCode_vc)


        Dim colDSwitch_CardAcceptorID_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDSwitch_CardAcceptorID_vc.DataPropertyName = "DSwitch_CardAcceptorID_vc"
        colDSwitch_CardAcceptorID_vc.HeaderText = "CardAcceptorID"
        colDSwitch_CardAcceptorID_vc.Name = "colDSwitch_CardAcceptorID_vc"
        colDSwitch_CardAcceptorID_vc.ReadOnly = True
        colDSwitch_CardAcceptorID_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDSwitch_CardAcceptorID_vc)

        Dim colDSwitch_TerminalID_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDSwitch_TerminalID_vc.DataPropertyName = "DSwitch_TerminalID_vc"
        colDSwitch_TerminalID_vc.HeaderText = "TerminalID"
        colDSwitch_TerminalID_vc.Name = "colDSwitch_TerminalID_vc"
        colDSwitch_TerminalID_vc.ReadOnly = True
        colDSwitch_TerminalID_vc.Width = 100
        Me.DataGridView1.Columns.Add(colDSwitch_TerminalID_vc)
    End Sub

    Private Function GetMaxNumber()
        Try
            Dim dt As New DataTable
            dt = da.GetTheLatestSwitchHeaderNumber()
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
        dtDuplicat = da.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForSwitch(1, ClassUserLoginDataAccess.ThisUser.ProjectID)

        For Each dr As DataRow In dtDetail.Rows
            Dim drSelect() As DataRow = dtDuplicat.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
            If drSelect.Length = 0 Then
                dr.RowError = "قرارداد مورد نظر قبلا جهت برای سوئیچ ارسال شده است"
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
        dtDuplicat = da.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForSwitch(1, ClassUserLoginDataAccess.ThisUser.ProjectID)
        Dim dtCurrentRecord As New DataTable
        dtCurrentRecord = da.GetByIDSwitchDetail(Me.txtID_bint.Text)

        For Each dr As DataRow In dtDetail.Rows
            Dim drSelect() As DataRow = dtDuplicat.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
            If drSelect.Length = 0 Then
                Dim drCurrentSelect() As DataRow = dtCurrentRecord.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
                If drCurrentSelect.Length = 0 Then
                    dr.RowError = "قرارداد مورد نظر قبلا جهت برای سوئیچ ارسال شده است"
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
            dtMHDHeader = da.GetByNumberSwitchHeader(Number)
            If dtMHDHeader.Rows.Count > 0 Then
                Me.txtID_bint.Text = dtMHDHeader.Rows(0).Item("SwitchHeaderID").ToString
                Me.txtSaveDate_vc.Value = dtMHDHeader.Rows(0).Item("SaveDate_vc").ToString
                Me.txtDescription_nvc.Text = dtMHDHeader.Rows(0).Item("Description_nvc").ToString
                dtDetail = da.GetByIDSwitchDetail(Me.txtID_bint.Text)
                Me.DataGridView1.DataSource = Me.dtDetail
            Else
                Me.txtID_bint.Clear()
                Me.txtDescription_nvc.Clear()
                Me.txtSaveDate_vc.Value = ""
                dtDetail = da.GetByIDSwitchDetail(-1)
                Me.DataGridView1.DataSource = Me.dtDetail
            End If
            Me.VIEWSTATE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InsertData(ByRef Number As Int64, ByRef ID As Int64)
        Try
            Dim Header As New ClassDALSwitch.SwitchHeader
            Dim Detail As New ClassDALSwitch.SwitchDetail
            Dim SwitchHeaderID As Long

            Header.SaveDate_vc = Me.txtSaveDate_vc.Value
            Header.Number_bint = Me.GetMaxNumber + 1
            Header.Description_nvc = Me.txtDescription_nvc.Text
            Header.SwitchHeaderID = 0

            SwitchHeaderID = da.InsertSwitchHeader(Header)
            For Each dr As DataRow In dtDetail.Rows
                Detail.DeviceID = dr.Item("DDeviceID")
                Detail.SwitchDetailID = 0
                Detail.SwitchHeaderID = SwitchHeaderID
                Detail.SwitchDetailID = da.InsertSwitchDetail(Detail)
            Next
            ID = SwitchHeaderID
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

    Private Sub frmSwitch_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
End Class