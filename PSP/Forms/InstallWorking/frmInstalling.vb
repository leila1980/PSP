Public Class frmInstalling
    Private _CurrentState As State = State.VIEW
    Private dtDetail As New DataTable
    Private da As New Dal(ConnectionString)
    Dim dt As New DataTable

    Dim Cms As New Dal.MutateCMSPROJECTID




    Protected Enum State
        ADD
        EDIT
        VIEW
        Load
    End Enum
    Protected ReadOnly Property CurrentState() As State
        Get
            Return Me._CurrentState
        End Get
    End Property
    Protected Sub GotoState(ByVal myState As State)
        Select Case myState
            Case State.ADD
                Me.btnDel.Enabled = True
                Me.btnList.Enabled = True
                Me.txtPSerail_vc.Enabled = True
                Me.btnAdd.Enabled = False
                Me.txtSaveDate_vc.Enabled = True
                Me.txtDescription_nvc.Enabled = True
                Me.btnDelete.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnSave.Enabled = True
                Me.btnCancel.Enabled = True
                Me.btnPrint.Enabled = False
                Me.nudNumber_bint.Enabled = False
                Me.txtSaveDate_vc.Focus()
                Me._CurrentState = State.ADD
                Me.cmbInstaller.Enabled = True
                Me.CboCMSPROJ.SelectedIndex = -1
                Me.CboCMSPROJ.Enabled = Enabled
            Case State.EDIT
                Me.btnDel.Enabled = True
                Me.btnList.Enabled = True
                Me.txtPSerail_vc.Enabled = True
                Me.nudNumber_bint.Enabled = False
                Me.txtSaveDate_vc.Enabled = True
                Me.txtDescription_nvc.Enabled = True
                Me.btnAdd.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnSave.Enabled = True
                Me.btnCancel.Enabled = True
                Me.btnPrint.Enabled = False
                Me.txtSaveDate_vc.Focus()
                Me._CurrentState = State.EDIT
                Me.cmbInstaller.Enabled = True
                Me.CboCMSPROJ.Enabled = Enabled
            Case State.VIEW
                Me.txtPSerail_vc.Enabled = False
                Me.btnDel.Enabled = False
                Me.btnList.Enabled = False
                Me.nudNumber_bint.Enabled = True
                Me.txtSaveDate_vc.Enabled = False
                Me.txtDescription_nvc.Enabled = False
                Me.btnAdd.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnEdit.Enabled = True
                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
                Me.btnPrint.Enabled = True
                Me.nudNumber_bint.Focus()
                Me._CurrentState = State.VIEW
                Me.cmbInstaller.Enabled = False
                Me.CboCMSPROJ.Enabled = False
                Me.txtPSerail_vc.Clear()
            Case State.Load
                Me.txtPSerail_vc.Enabled = False
                Me.btnDel.Enabled = False
                Me.btnList.Enabled = False
                Me.nudNumber_bint.Enabled = False
                Me.txtSaveDate_vc.Enabled = False
                Me.txtDescription_nvc.Enabled = False
                Me.btnAdd.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
                Me.btnPrint.Enabled = False
                Me.nudNumber_bint.Focus()
                Me._CurrentState = State.Load
                Me.cmbInstaller.Enabled = False
                Me.CboCMSPROJ.Enabled = False
        End Select
    End Sub

    Private Sub frmInstalling_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmInstalling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.Text = "نصب"
            Me.GotoState(State.Load)
            Me.btnPrint.Visible = False
            Me.ToolStripSeparator4.Visible = False
            Me.cmbInstaller.DisplayMember = "FullName_nvc"
            Me.cmbInstaller.ValueMember = "InstallerID"
            Me.cmbInstaller.DataSource = da.GetAllInstaller
            Me.CboCMSPROJ.DisplayMember = "name_nvc"
            Me.CboCMSPROJ.ValueMember = "cmsprojectid_int"
            Me.CboCMSPROJ.DataSource = da.GetAllCMSPROJECT

          
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
    Private Function ValidateAccountForDelete(ByVal DeviceID As Int64) As Boolean
        Try
            Dim dt As DataTable = da.GetBYDeviceIDInstallingDetail(DeviceID)
            If dt.Rows.Count > 0 AndAlso dt.Rows(0).Item("Status_tint") > 0 Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        For Each dr As DataRow In Me.dtDetail.Rows
            If ValidateAccountForDelete(Me.DataGridView1.SelectedRows(0).Cells("colDDeviceID").Value) = False Then
                ShowMessage("این بچ قبلا نصب شده است و نمی توانید ویرایش کنید")
                Exit Sub
            End If
        Next

        Me.GotoState(State.EDIT)
    End Sub
    Public Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click

        Select Case Me.CurrentState
            Case State.ADD
                If Me.CboCMSPROJ.SelectedIndex = -1 Then
                    Me.ErrPro.SetError(Me.CboCMSPROJ, "نوع پروژه را انتخاب کنید")
                    Exit Sub
                End If
                Dim frm As New frmInstallingList(Me.dtDetail, -1, CboCMSPROJ.SelectedValue)
                frm.ShowDialog()
            Case State.EDIT
                Dim frm As New frmInstallingList(Me.dtDetail, Me.txtID_bint.Text)
                frm.ShowDialog()
        End Select
       
    End Sub
    Public Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                If Me.ValidateAccountForDelete(Me.DataGridView1.SelectedRows(0).Cells("colDDeviceID").Value) = False Then
                    ShowMessage(msgInstallingDeviceHasPrinted)
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
    Public Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Select Case Me.CurrentState
                Case State.ADD
                    da.BeginProc()

                    If Me.ValidateForm_ADD = False Then
                        Exit Sub
                    End If

                    Dim Number As Long
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

                    Dim Header As New Dal.InstallingHeaderTemplate
                    Dim Detail As New Dal.InstallingDetailTemplate
                    Dim InstallingHeaderID As Long = Me.txtID_bint.Text

                    Cms.NewCMSPROJECTD = CboCMSPROJ.SelectedValue

                    Header.SaveDate_vc = Me.txtSaveDate_vc.Value
                    Header.Number_bint = Me.nudNumber_bint.Value
                    Header.Description_nvc = Me.txtDescription_nvc.Text
                    Header.InstallingHeaderID = Me.txtID_bint.Text
                    Header.InstallerID = Me.cmbInstaller.SelectedValue
                    
                    da.UpdateInstallingHeader(Header)
                  
                    If Cms.NewCMSPROJECTD <> Cms.OldCMSPROJECTD Then
                        da.UpdateInstallingHeaderCMS(Header.InstallingHeaderID, Cms.NewCMSPROJECTD)
                    End If
                 
                    'da.DeleteInstallingDetail(Header.InstallingHeaderID)
                    'For Each dr As DataRow In dtDetail.Rows
                    '    Detail.DeviceID = dr.Item("DDeviceID")
                    '    Detail.InstallingDetailID = 0
                    '    Detail.InstallingHeaderID = InstallingHeaderID
                    '    Detail.Status_tint = 0
                    '    Detail.InstallingDetailID = da.InsertInstallingDetail(Detail)
                    '    dr("InstallingDetailID") = Detail.InstallingDetailID
                    'Next
                    '---
                    Dim Counter As Int32
                    dt.Clear()
                    dt = da.GetByIDInstallingDetail(Me.txtID_bint.Text, ClassUserLoginDataAccess.ThisUser.ProjectID)
                    If dt.Rows.Count = 0 Then
                        For Each dr As DataRow In dtDetail.Rows
                            Detail.DeviceID = dr.Item("DDeviceID")
                            Detail.InstallingDetailID = 0
                            Detail.InstallingHeaderID = InstallingHeaderID
                            Detail.Status_tint = 0
                            Detail.InstallingDetailID = da.InsertInstallingDetail(Detail)
                            dr("InstallingDetailID") = Detail.InstallingDetailID
                        Next
                        VIEWSTATE()
                        Exit Sub
                    End If
                    If dtDetail.Rows.Count = 0 Then
                        For i As Int32 = 0 To dt.Rows.Count - 1
                            da.DeleteByDetailIDInstallingDetail(dt.Rows(i).Item("InstallingDetailID"))
                        Next
                        VIEWSTATE()
                        Exit Sub
                    End If

                    For i As Int32 = 0 To dt.Rows.Count - 1
                        Counter = 0
                        For Each dr As DataRow In dtDetail.Rows
                            If dt.Rows(i).Item("DDeviceID") = dr.Item("DDeviceID") Then
                                Counter += 1
                                Exit For
                            End If
                        Next
                        If Counter = 0 Then 'not found in new list ===> delete from installingdetail
                            da.DeleteByDetailIDInstallingDetail(dt.Rows(i).Item("InstallingDetailID"))
                        End If
                    Next
                    dt.Clear()
                    dt = da.GetByIDInstallingDetail(Me.txtID_bint.Text, ClassUserLoginDataAccess.ThisUser.ProjectID)
                    For Each dr As DataRow In dtDetail.Rows
                        For j As Int32 = 0 To dt.Rows.Count - 1
                            Counter = 0
                            If dt.Rows(j).Item("DDeviceID") = dr.Item("DDeviceID") Then
                                Counter += 1
                                Exit For
                            End If
                        Next
                        If Counter = 0 Then 'not found in previous detail  ===> insert  into installingdetail
                            Detail.DeviceID = dr.Item("DDeviceID")
                            Detail.InstallingDetailID = 0
                            Detail.InstallingHeaderID = InstallingHeaderID
                            Detail.Status_tint = 0
                            Detail.InstallingDetailID = da.InsertInstallingDetail(Detail)
                            dr("InstallingDetailID") = Detail.InstallingDetailID
                        End If
                    Next
                    '---
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

        Dim colVisitorLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colVisitorLastName_nvc.DataPropertyName = "VisitorLastName_nvc"
        colVisitorLastName_nvc.HeaderText = "نام بازاریاب"
        colVisitorLastName_nvc.Name = "colVisitorLastName_nvc"
        colVisitorLastName_nvc.ReadOnly = True
        colVisitorLastName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colVisitorLastName_nvc)



        Dim colDDeviceID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDDeviceID.DataPropertyName = "DDeviceID"
        colDDeviceID.HeaderText = "کد دستگاه"
        colDDeviceID.Name = "colDDeviceID"
        colDDeviceID.ReadOnly = True
        colDDeviceID.Width = 100
        colDDeviceID.Visible = False
        Me.DataGridView1.Columns.Add(colDDeviceID)

        Dim colContractID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractID.DataPropertyName = "ContractID"
        colContractID.HeaderText = "کد قرار داد"
        colContractID.Name = "colContractID"
        colContractID.ReadOnly = True
        colContractID.Width = 100
        Me.DataGridView1.Columns.Add(colContractID)

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

        Dim colSAddress_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSAddress_nvc.DataPropertyName = "SAddress_nvc"
        colSAddress_nvc.HeaderText = "آدرس"
        colSAddress_nvc.Name = "colSAddress_nvc"
        colSAddress_nvc.ReadOnly = True
        colSAddress_nvc.Width = 350
        Me.DataGridView1.Columns.Add(colSAddress_nvc)

        Dim colSMunicipalAreaNO_sint As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSMunicipalAreaNO_sint.DataPropertyName = "SMunicipalAreaNO_sint"
        colSMunicipalAreaNO_sint.HeaderText = "منطقه"
        colSMunicipalAreaNO_sint.Name = "colSMunicipalAreaNO_sintv"
        colSMunicipalAreaNO_sint.ReadOnly = True
        colSMunicipalAreaNO_sint.Visible = True
        Me.DataGridView1.Columns.Add(colSMunicipalAreaNO_sint)

        Dim colAAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountNO_vc.DataPropertyName = "AAccountNO_vc"
        colAAccountNO_vc.HeaderText = "شماره حساب"
        colAAccountNO_vc.Name = "colAccountNO_vc"
        colAAccountNO_vc.ReadOnly = True
        colAAccountNO_vc.Width = 100
        Me.DataGridView1.Columns.Add(colAAccountNO_vc)

        Dim colSName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSName_nvc.DataPropertyName = "SName_nvc"
        colSName_nvc.HeaderText = "نام فروشگاه"
        colSName_nvc.Name = "colSName_nvc"
        colSName_nvc.ReadOnly = True
        colSName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colSName_nvc)


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

        Dim colSCityName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSCityName_nvc.DataPropertyName = "SCityName_nvc"
        colSCityName_nvc.HeaderText = "شهر"
        colSCityName_nvc.Name = "colSCityName_nvc"
        colSCityName_nvc.ReadOnly = True
        colSCityName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colSCityName_nvc)

        Dim colSPostCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSPostCode_vc.DataPropertyName = "SPostCode_vc"
        colSPostCode_vc.HeaderText = "کد پستی"
        colSPostCode_vc.Name = "colSPostCode_vc"
        colSPostCode_vc.ReadOnly = True
        colSPostCode_vc.Width = 100
        Me.DataGridView1.Columns.Add(colSPostCode_vc)

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
            dt = da.GetTheLatestInstallingHeaderNumber()
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

        If Me.cmbInstaller.SelectedIndex = -1 Then
            res = False
            Me.ErrPro.SetError(Me.cmbInstaller, "نصاب را انتخاب کنید")
        End If

        Dim dtDuplicat As New DataTable

        dtDuplicat = da.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForInstalling(ClassUserLoginDataAccess.ThisUser.ProjectID, CboCMSPROJ.SelectedValue)
       

    
        For Each dr As DataRow In dtDetail.Rows
            Dim drSelect() As DataRow = dtDuplicat.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
            If drSelect.Length = 0 Then
                dr.RowError = "دستگاه مورد نظر قبلا نصب شده است"
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
        dtDuplicat = da.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForInstalling(ClassUserLoginDataAccess.ThisUser.ProjectID)
        Dim dtCurrentRecord As New DataTable
        dtCurrentRecord = da.GetByIDInstallingDetail(Me.txtID_bint.Text, ClassUserLoginDataAccess.ThisUser.ProjectID)

        For Each dr As DataRow In dtDetail.Rows
            Dim drSelect() As DataRow = dtDuplicat.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
            If drSelect.Length = 0 Then
                Dim drCurrentSelect() As DataRow = dtCurrentRecord.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
                If drCurrentSelect.Length = 0 Then
                    dr.RowError = "دستگاه مورد نظر قبلا نصب شده است"
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
            dtMHDHeader = da.GetByNumberInstallingHeader(Number)
            If dtMHDHeader.Rows.Count > 0 Then
                Me.txtID_bint.Text = dtMHDHeader.Rows(0).Item("InstallingHeaderID").ToString
                Me.txtSaveDate_vc.Value = dtMHDHeader.Rows(0).Item("SaveDate_vc").ToString
                Me.txtDescription_nvc.Text = dtMHDHeader.Rows(0).Item("Description_nvc").ToString
                Me.cmbInstaller.SelectedValue = dtMHDHeader.Rows(0).Item("InstallerID").ToString
                Me.CboCMSPROJ.SelectedValue = dtMHDHeader.Rows(0).Item("cmsprojectid").ToString
                Cms.OldCMSPROJECTD = dtMHDHeader.Rows(0).Item("cmsprojectid")

                dtDetail = da.GetByIDInstallingDetail(Me.txtID_bint.Text, ClassUserLoginDataAccess.ThisUser.ProjectID)
                Me.DataGridView1.DataSource = Me.dtDetail

            Else
                Me.txtID_bint.Clear()
                Me.txtDescription_nvc.Clear()
                Me.txtSaveDate_vc.Value = ""
                dtDetail = da.GetByIDInstallingDetail(-1, ClassUserLoginDataAccess.ThisUser.ProjectID)
                Me.DataGridView1.DataSource = Me.dtDetail
            End If
            Me.VIEWSTATE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InsertData(ByRef Number As Int64, ByRef ID As Int64)
        Try
            Dim Header As New Dal.InstallingHeaderTemplate
            Dim Detail As New Dal.InstallingDetailTemplate
            Dim InstallingHeaderID As ULong

            Header.SaveDate_vc = Me.txtSaveDate_vc.Value
            Header.Number_bint = Me.GetMaxNumber + 1
            Header.Description_nvc = Me.txtDescription_nvc.Text
            Header.InstallingHeaderID = 0
            Header.InstallerID = Me.cmbInstaller.SelectedValue

            InstallingHeaderID = da.InsertInstallingHeader(Header)
            For Each dr As DataRow In dtDetail.Rows
                Detail.DeviceID = dr.Item("DDeviceID")
                Detail.InstallingHeaderID = InstallingHeaderID
                Detail.Status_tint = 0
                Detail.InstallingDetailID = 0
                Detail.InstallingDetailID = da.InsertInstallingDetail(Detail)
                dr("InstallingDetailID") = Detail.InstallingDetailID
            Next

            ID = InstallingHeaderID
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
    Public Sub nudNumber_bint_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNumber_bint.ValueChanged
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
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.GotoState(State.ADD)
        Me.ClearForm()
        Me.txtSaveDate_vc.Value = modPublicMethod.GetDateNow
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
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
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If Me.txtID_bint.Text = "" Then
                Exit Sub
            End If
            If ShowConfirmDeleteMessage() = False Then
                Exit Sub
            End If

            For Each dr As DataRow In Me.dtDetail.Rows
                If ValidateAccountForDelete(Me.DataGridView1.SelectedRows(0).Cells("colDDeviceID").Value) = False Then
                    ShowMessage(msgInstallingDeviceHasPrinted)
                    Exit Sub
                End If
            Next

            da.BeginProc()
            da.DeleteInstallingDetail(Me.txtID_bint.Text)
            da.DeleteInstallingHeader(Me.txtID_bint.Text)
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
    Private Sub txtPSerail_vc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPSerail_vc.KeyDown
        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtPSerail_vc.Text <> "" AndAlso Me.CurrentState = State.ADD Then
                Dim frm As New frmInstallingList(Me.dtDetail)
                frm.Load()
                Dim dr() As DataRow = frm.dtList.Select("PSerial_vc='" + Me.txtPSerail_vc.Text.Replace("'", "''") + "'")
                For i As Integer = 0 To dr.Length - 1
                    dr(i).Item("Check") = 1
                Next
                frm.btnOK_Click(frm.btnOK, e)
                Me.txtPSerail_vc.Clear()
            ElseIf e.KeyCode = Keys.Enter AndAlso Me.txtPSerail_vc.Text <> "" AndAlso Me.CurrentState = State.EDIT Then
                Dim frm As New frmInstallingList(Me.dtDetail, Me.txtID_bint.Text)
                frm.Load()
                Dim dr() As DataRow = frm.dtList.Select("PSerial_vc='" + Me.txtPSerail_vc.Text.Replace("'", "''") + "'")
                For i As Integer = 0 To dr.Length - 1
                    dr(i).Item("Check") = 1
                Next
                frm.btnOK_Click(frm.btnOK, e)
                Me.txtPSerail_vc.Clear()
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.DataGridView1)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub frmInstalling_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(DataGridView1.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, DataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.DataGridView1.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, DataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.DataGridView1.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub
End Class