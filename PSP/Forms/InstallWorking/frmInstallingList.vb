Public Class frmInstallingList
    Public dtList As New DataTable
    Private dt As DataTable
    Private HeaderId As Long = -1
    Private OBJID As Int16 = 1


    Public Sub Load()
        Try
            Me.cboSearchBy.Items.Clear()
            Me.cboSearchBy.Items.Add("نام")
            Me.cboSearchBy.Items.Add("نام خانوادگی")
            Me.cboSearchBy.Items.Add("کد قرارداد")
            Me.cboSearchBy.Items.Add("نام فروشگاه")
            Me.cboSearchBy.Items.Add("آدرس")
            Me.cboSearchBy.Items.Add("منطقه")
            Me.cboSearchBy.Items.Add("شماره حساب")
            Me.cboSearchBy.Items.Add("پز کد")
            Me.cboSearchBy.Items.Add("Outlet")
            Me.cboSearchBy.Items.Add("شماره سریال")
            Me.cboSearchBy.Items.Add("شماره اموال")
            Me.cboSearchBy.Items.Add("شهر")

            Me.cboSearchBy.SelectedIndex = 0

            Me.Text = "انتخاب دستگاه برای نصب"
            InitDataGridView()
            Dim da As New Dal(ConnectionString)
            dtList = da.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForInstalling(ClassUserLoginDataAccess.ThisUser.ProjectID, OBJID)
            For Each dr As DataRow In dt.Rows
                Dim drDuplicat() As DataRow = dtList.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
                If drDuplicat.Length > 0 Then
                    drDuplicat(0).Delete()
                End If
            Next

            Dim dtDetail As New DataTable
            If Me.HeaderId > 0 Then
                dtDetail = da.GetByIDInstallingDetail(HeaderId, ClassUserLoginDataAccess.ThisUser.ProjectID)
                For Each dr As DataRow In dtDetail.Rows
                    Dim drSelect() As DataRow = dt.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
                    If drSelect.Length = 0 Then
                        Dim mhddr As DataRow = dtList.NewRow

                        mhddr.Item("ContractingPartyID") = dr.Item("ContractingPartyID")
                        mhddr.Item("FirstName_nvc") = dr.Item("FirstName_nvc")
                        mhddr.Item("LastName_nvc") = dr.Item("LastName_nvc")
                        mhddr.Item("NationalCode_nvc") = dr.Item("NationalCode_nvc")
                        mhddr.Item("ContractID") = dr.Item("ContractID")
                        mhddr.Item("ContractNo_vc") = dr.Item("ContractNo_vc")
                        mhddr.Item("AAccountNO_vc") = dr.Item("AAccountNO_vc")
                        mhddr.Item("ACardNo_vc") = dr.Item("ACardNo_vc")
                        mhddr.Item("SStoreID") = dr.Item("SStoreID")
                        mhddr.Item("SName_nvc") = dr.Item("SName_nvc")
                        mhddr.Item("DDeviceID") = dr.Item("DDeviceID")
                        mhddr.Item("DCode_vc") = dr.Item("DCode_vc")
                        mhddr.Item("DOutlet_vc") = dr.Item("DOutlet_vc")
                        mhddr.Item("DVat_vc") = dr.Item("DVat_vc")
                        mhddr.Item("DMerchant_vc") = dr.Item("DMerchant_vc")
                        mhddr.Item("PosID") = dr.Item("PosID")
                        mhddr.Item("PSerial_vc") = dr.Item("PSerial_vc")
                        mhddr.Item("PPropertyNO_vc") = dr.Item("PPropertyNO_vc")
                        mhddr.Item("PEniacCode_vc") = dr.Item("PEniacCode_vc")
                        mhddr.Item("DSwitch_CardAcceptorID_vc") = dr.Item("DSwitch_CardAcceptorID_vc")
                        mhddr.Item("DSwitch_TerminalID_vc") = dr.Item("DSwitch_TerminalID_vc")
                        mhddr.Item("SCityName_nvc") = dr.Item("SCityName_nvc")
                        mhddr.Item("VisitorLastName_nvc") = dr.Item("VisitorLastName_nvc")
                        Me.dtList.Rows.Add(mhddr)
                    End If
                Next
            End If

            dtList.AcceptChanges()

            Dim colCheck As New DataColumn()
            colCheck.DefaultValue = False
            colCheck.AllowDBNull = False
            colCheck.ColumnName = "Check"
            colCheck.DataType = GetType(Boolean)
            Me.dtList.Columns.Add(colCheck)
            Me.DataGridView1.DataSource = dtList
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmInstallingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Load()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtSearch.Focus()

        Dim dr() As DataRow = Me.dtList.Select("Check=1")
        For i As Integer = 0 To dr.Length - 1
            Dim drCheck() As DataRow = dt.Select("DDeviceID=" + dr(i).Item("DDeviceID").ToString)
            If drCheck.Length = 0 Then
                Dim drNew As DataRow = dt.NewRow

                drNew.Item("ContractingPartyID") = dr(i).Item("ContractingPartyID")
                drNew.Item("FirstName_nvc") = dr(i).Item("FirstName_nvc")
                drNew.Item("LastName_nvc") = dr(i).Item("LastName_nvc")
                drNew.Item("NationalCode_nvc") = dr(i).Item("NationalCode_nvc")
                drNew.Item("ContractID") = dr(i).Item("ContractID")
                drNew.Item("ContractNo_vc") = dr(i).Item("ContractNo_vc")
                drNew.Item("AAccountNO_vc") = dr(i).Item("AAccountNO_vc")
                drNew.Item("ACardNo_vc") = dr(i).Item("ACardNo_vc")
                drNew.Item("SStoreID") = dr(i).Item("SStoreID")
                drNew.Item("SName_nvc") = dr(i).Item("SName_nvc")
                drNew.Item("SAddress_nvc") = dr(i).Item("SAddress_nvc")
                drNew.Item("SMunicipalAreaNO_sint") = dr(i).Item("SMunicipalAreaNO_sint")
                drNew.Item("SCityName_nvc") = dr(i).Item("SCityName_nvc")
                drNew.Item("DDeviceID") = dr(i).Item("DDeviceID")
                drNew.Item("DCode_vc") = dr(i).Item("DCode_vc")
                drNew.Item("DOutlet_vc") = dr(i).Item("DOutlet_vc")
                drNew.Item("DVat_vc") = dr(i).Item("DVat_vc")
                drNew.Item("DMerchant_vc") = dr(i).Item("DMerchant_vc")
                drNew.Item("PPosID") = dr(i).Item("PPosID")
                drNew.Item("PSerial_vc") = dr(i).Item("PSerial_vc")
                drNew.Item("PPropertyNO_vc") = dr(i).Item("PPropertyNO_vc")
                drNew.Item("PEniacCode_vc") = dr(i).Item("PEniacCode_vc")
                drNew.Item("DSwitch_CardAcceptorID_vc") = dr(i).Item("DSwitch_CardAcceptorID_vc")
                drNew.Item("DSwitch_TerminalID_vc") = dr(i).Item("DSwitch_TerminalID_vc")
                drNew.Item("SCityName_nvc") = dr(i).Item("SCityName_nvc")
                drNew.Item("VisitorLastName_nvc") = dr(i).Item("VisitorLastName_nvc")


                dt.Rows.Add(drNew)
            End If
        Next
        Me.Close()
    End Sub

    Public Overrides Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Overrides Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.dtList.AcceptChanges()
        btnUnSelect_Click(sender, e)
        Dim dr() As DataRow = dtList.Select(dtList.DefaultView.RowFilter)
        For i As Integer = 0 To dr.Length - 1
            dr(i).Item("Check") = 1
        Next
    End Sub

    Public Overrides Sub btnUnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.dtList.AcceptChanges()
        For Each dr As DataRow In dtList.Rows
            dr.Item("Check") = 0
        Next
    End Sub

    Public Overrides Sub InventSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtSearch.Focus()
        For Each dr As DataRow In dtList.DefaultView.ToTable.Rows
            dr.Item("Check") = Not dr.Item("Check")
        Next
    End Sub

    Private Sub InitDataGridView()
        Me.DataGridView1.AutoGenerateColumns = False

        Dim colCheck As New System.Windows.Forms.DataGridViewCheckBoxColumn
        colCheck.DataPropertyName = "Check"
        colCheck.HeaderText = ""
        colCheck.Name = "colCheck"
        colCheck.ReadOnly = False
        colCheck.Width = 50
        Me.DataGridView1.Columns.Add(colCheck)

        Dim colVisitorLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colVisitorLastName_nvc.DataPropertyName = "VisitorLastName_nvc"
        colVisitorLastName_nvc.HeaderText = "نام بازاریاب"
        colVisitorLastName_nvc.Name = "colVisitorLastName_nvc"
        colVisitorLastName_nvc.ReadOnly = True
        colVisitorLastName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colVisitorLastName_nvc)


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
        colPEniacCode_vc.HeaderText = "EniacCode"
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
    Public Sub New(ByRef dt As DataTable)
        InitializeComponent()
        Me.dt = dt
    End Sub
    Public Sub New(ByRef dt As DataTable, ByVal HeaderId As Int64)
        InitializeComponent()
        Me.dt = dt
        Me.HeaderId = HeaderId
    End Sub
    Public Sub New(ByRef dt As DataTable, ByVal HeaderId As Int64, ByVal OBJID As Int64)
        InitializeComponent()
        Me.dt = dt
        Me.HeaderId = -1
        Me.OBJID = OBJID
    End Sub


    Public Overrides Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case Me.cboSearchBy.SelectedIndex
            Case 0
                Me.dtList.DefaultView.RowFilter = "FirstName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 1
                Me.dtList.DefaultView.RowFilter = "LastName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 2
                If Me.txtSearch.Text = "" Then
                    Me.dtList.DefaultView.RowFilter = ""
                ElseIf IsNumeric(Me.txtSearch.Text) = True Then
                    Me.dtList.DefaultView.RowFilter = "ContractID = " + Me.txtSearch.Text + ""
                End If
            Case 3
                Me.dtList.DefaultView.RowFilter = "SName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 4
                Me.dtList.DefaultView.RowFilter = "SAddress_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 5
                If Me.txtSearch.Text = "" Then
                    Me.dtList.DefaultView.RowFilter = ""
                ElseIf IsNumeric(Me.txtSearch.Text) = True Then
                    Me.dtList.DefaultView.RowFilter = "SMunicipalAreaNO_sint = " + Me.txtSearch.Text + ""
                End If
            Case 6
                Me.dtList.DefaultView.RowFilter = "AAccountNO_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 7
                Me.dtList.DefaultView.RowFilter = "DCode_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 8
                Me.dtList.DefaultView.RowFilter = "DOutlet_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 9
                Me.dtList.DefaultView.RowFilter = "PSerial_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 10
                Me.dtList.DefaultView.RowFilter = "PPropertyNO_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 11
                Me.dtList.DefaultView.RowFilter = "SCityName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
        End Select
    End Sub

End Class