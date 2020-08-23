Public Class frmSwitchList
    Private dtList As New DataTable
    Private dt As DataTable
    Private HeaderId As Integer = -1

    Private Sub frmSwitchList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.cboSearchBy.Items.Clear()
            Me.cboSearchBy.Items.Add("نام")
            Me.cboSearchBy.Items.Add("نام خانوادگی")
            Me.cboSearchBy.Items.Add("کد ملی")
            Me.cboSearchBy.Items.Add("شماره قرارداد")
            Me.cboSearchBy.Items.Add("تاریخ ثبت")
            Me.cboSearchBy.Items.Add("تاریخ عقد قرارداد")
            Me.cboSearchBy.Items.Add("شماره حساب")
            Me.cboSearchBy.Items.Add("شماره کارت")
            Me.cboSearchBy.Items.Add("شهر")
            Me.cboSearchBy.Items.Add("کد پستی")

            Me.cboSearchBy.SelectedIndex = 0

            Me.Text = "انتخاب سوئیچ"
            InitDataGridView()
            Dim da As New ClassDALSwitch(ConnectionString)
            dtList = da.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForSwitch(1, ClassUserLoginDataAccess.ThisUser.ProjectID)
            For Each dr As DataRow In dt.Rows
                Dim drDuplicat() As DataRow = dtList.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
                If drDuplicat.Length > 0 Then
                    drDuplicat(0).Delete()
                End If
            Next

            Dim dtDetail As New DataTable
            If Me.HeaderId > 0 Then
                dtDetail = da.GetByIDSwitchDetail(HeaderId)
                For Each dr As DataRow In dtDetail.Rows
                    Dim drSelect() As DataRow = dt.Select("DDeviceID=" + dr.Item("DDeviceID").ToString)
                    If drSelect.Length = 0 Then
                        Dim mhddr As DataRow = dtList.NewRow

                        mhddr.Item("ContractingPartyID") = dr.Item("ContractingPartyID")
                        mhddr.Item("FirstName_nvc") = dr.Item("FirstName_nvc")
                        mhddr.Item("LastName_nvc") = dr.Item("LastName_nvc")
                        mhddr.Item("NationalCode_nvc") = dr.Item("NationalCode_nvc")
                        mhddr.Item("ContractID") = dr.Item("ContractID")
                        mhddr.Item("NationalCode_nvc") = dr.Item("NationalCode_nvc")
                        mhddr.Item("ContractID") = dr.Item("ContractID")
                        mhddr.Item("ContractNO_vc") = dr.Item("ContractNO_vc")
                        mhddr.Item("AAccountNO_vc") = dr.Item("AAccountNO_vc")
                        mhddr.Item("ACardNO_vc") = dr.Item("ACardNO_vc")
                        mhddr.Item("SStoreID") = dr.Item("SStoreID")
                        mhddr.Item("SName_nvc") = dr.Item("SName_nvc")
                        mhddr.Item("DDeviceID") = dr.Item("DDeviceID")
                        mhddr.Item("DCode_vc") = dr.Item("DCode_vc")
                        mhddr.Item("DOutlet_vc") = dr.Item("DOutlet_vc")
                        mhddr.Item("DVat_vc") = dr.Item("DVat_vc")
                        mhddr.Item("DMerchant_vc") = dr.Item("DMerchant_vc")
                        mhddr.Item("PPosID") = dr.Item("PPosID")
                        mhddr.Item("PSerial_vc") = dr.Item("PSerial_vc")
                        mhddr.Item("PPropertyNO_vc") = dr.Item("PPropertyNO_vc")
                        mhddr.Item("PEniacCode_vc") = dr.Item("PEniacCode_vc")
                        mhddr.Item("DSwitch_CardAcceptorID_vc") = dr.Item("DSwitch_CardAcceptorID_vc")
                        mhddr.Item("DSwitch_TerminalID_vc") = dr.Item("DSwitch_TerminalID_vc")

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
                drNew.Item("NationalCode_nvc") = dr(i).Item("NationalCode_nvc")
                drNew.Item("ContractID") = dr(i).Item("ContractID")
                drNew.Item("ContractNO_vc") = dr(i).Item("ContractNO_vc")
                drNew.Item("AAccountNO_vc") = dr(i).Item("AAccountNO_vc")
                drNew.Item("ACardNO_vc") = dr(i).Item("ACardNO_vc")
                drNew.Item("SStoreID") = dr(i).Item("SStoreID")
                drNew.Item("SName_nvc") = dr(i).Item("SName_nvc")
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

    Public Sub New(ByRef dt As DataTable, ByVal HeaderID As UInt64)
        InitializeComponent()
        Me.dt = dt
        Me.HeaderId = HeaderID
    End Sub

    Public Overrides Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case Me.cboSearchBy.SelectedIndex
            Case 0
                Me.dtList.DefaultView.RowFilter = "FirstName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 1
                Me.dtList.DefaultView.RowFilter = "LastName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 2
                Me.dtList.DefaultView.RowFilter = "NationalCode_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 3
                If Me.txtSearch.Text = "" Then
                    Me.dtList.DefaultView.RowFilter = ""
                ElseIf IsNumeric(Me.txtSearch.Text) = True Then
                    Me.dtList.DefaultView.RowFilter = "ContractNo_vc =" + Val(Me.txtSearch.Text).ToString
                End If
            Case 4
                Me.dtList.DefaultView.RowFilter = "Date_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 5
                Me.dtList.DefaultView.RowFilter = "SaveDate_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 6
                Me.dtList.DefaultView.RowFilter = "AAccountNO_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 7
                Me.dtList.DefaultView.RowFilter = "ACardNo_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 8
                Me.dtList.DefaultView.RowFilter = "SCityName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 9
                Me.dtList.DefaultView.RowFilter = "SPostCode_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
        End Select
    End Sub

End Class