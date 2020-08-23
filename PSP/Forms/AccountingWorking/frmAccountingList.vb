Public Class frmAccountingList
    Private dtList As New DataTable
    Private dt As DataTable
    Private HeaderId As Integer = -1

    Private Sub frmAccountingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.cboSearchBy.Items.Clear()
            Me.cboSearchBy.Items.Add("نام")
            Me.cboSearchBy.Items.Add("نام خانوادگی")
            Me.cboSearchBy.Items.Add("کد ملی")
            Me.cboSearchBy.Items.Add("کد قرارداد")
            Me.cboSearchBy.Items.Add("شماره قرارداد")
            Me.cboSearchBy.Items.Add("تاریخ ثبت")
            Me.cboSearchBy.Items.Add("تاریخ عقد قرارداد")
            Me.cboSearchBy.Items.Add("شماره حساب")
            Me.cboSearchBy.Items.Add("شماره کارت")
            Me.cboSearchBy.Items.Add("نوع حساب")
            Me.cboSearchBy.Items.Add("شعبه")
            Me.cboSearchBy.Items.Add("منطقه")
            Me.cboSearchBy.Items.Add("شهر")
            Me.cboSearchBy.Items.Add("کد پستی")

            Me.cboSearchBy.SelectedIndex = 0

            Me.Text = "انتخاب حساب"
            InitDataGridView()
            Dim da As New ClassDALAccount(ConnectionString)
            dtList = da.GetAllContractingParty_Contract_Account_AvailableForAccounting
            For Each dr As DataRow In dt.Rows
                Dim drDuplicat() As DataRow = dtList.Select("AAccountID=" + dr.Item("AAccountID").ToString)
                For i As Integer = 0 To drDuplicat.Length - 1
                    drDuplicat(i).Delete()
                Next
            Next

            Dim dtDetail As New DataTable
            If Me.HeaderId > 0 Then
                dtDetail = da.GetByIDAccountingDetail(HeaderId, ClassUserLoginDataAccess.ThisUser.ProjectID)
                For Each dr As DataRow In dtDetail.Rows
                    Dim drSelect() As DataRow = dt.Select("AAccountID=" + dr.Item("AAccountID").ToString)
                    If drSelect.Length = 0 Then
                        Dim mhddr As DataRow = dtList.NewRow

                        mhddr.Item("ContractingPartyID") = dr.Item("ContractingPartyID")
                        mhddr.Item("FirstName_nvc") = dr.Item("FirstName_nvc")
                        mhddr.Item("LastName_nvc") = dr.Item("LastName_nvc")
                        mhddr.Item("FatherName_nvc") = dr.Item("FatherName_nvc")
                        mhddr.Item("IdentityCertificateNO_nvc") = dr.Item("IdentityCertificateNO_nvc")
                        mhddr.Item("NationalCode_nvc") = dr.Item("NationalCode_nvc")
                        mhddr.Item("Gender_bit") = dr.Item("Gender_bit")
                        mhddr.Item("BirthDate_vc") = dr.Item("BirthDate_vc")
                        mhddr.Item("StateID") = dr.Item("StateID")
                        mhddr.Item("CityID") = dr.Item("CityID")
                        mhddr.Item("CIdentityTypeID") = dr.Item("CIdentityTypeID")
                        mhddr.Item("DegreeID") = dr.Item("DegreeID")
                        mhddr.Item("Title_nvc") = dr.Item("Title_nvc")
                        mhddr.Item("HomeTel_vc") = dr.Item("HomeTel_vc")
                        mhddr.Item("Mobile_vc") = dr.Item("Mobile_vc")
                        mhddr.Item("Email_nvc") = dr.Item("Email_nvc")
                        mhddr.Item("HavingAccount_bit") = dr.Item("HavingAccount_bit")
                        mhddr.Item("AccountTypeID") = dr.Item("AccountTypeID")
                        mhddr.Item("AccountNO_vc") = dr.Item("AccountNO_vc")
                        mhddr.Item("CardNO_vc") = dr.Item("CardNO_vc")
                        mhddr.Item("BranchID") = dr.Item("BranchID")
                        mhddr.Item("ContractID") = dr.Item("ContractID")
                        mhddr.Item("ContractNO_vc") = dr.Item("ContractNO_vc")
                        mhddr.Item("Merchant_vc") = dr.Item("Merchant_vc")
                        mhddr.Item("SaveDate_vc") = dr.Item("SaveDate_vc")
                        mhddr.Item("Date_vc") = dr.Item("Date_vc")
                        mhddr.Item("VisitorID") = dr.Item("VisitorID")
                        mhddr.Item("AAccountID") = dr.Item("AAccountID")
                        mhddr.Item("AAccountNO_vc") = dr.Item("AAccountNO_vc")
                        mhddr.Item("ACardNO_vc") = dr.Item("ACardNO_vc")
                        mhddr.Item("AAccountTypeID") = dr.Item("AAccountTypeID")
                        mhddr.Item("AAccountTypeIDName_nvc") = dr.Item("AAccountTypeIDName_nvc")
                        mhddr.Item("ABranchID") = dr.Item("ABranchID")
                        mhddr.Item("ABranchIDName_nvc") = dr.Item("ABranchIDName_nvc")
                        mhddr.Item("AAccountingDetailID") = dr.Item("AAccountingDetailID")
                        mhddr.Item("AAccountingHeaderID") = dr.Item("AAccountingHeaderID")

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

            'Me.dtList.Columns.Add(New DataColumn("Order_int", GetType(Int64)))
            'For i As Integer = 0 To dtList.Rows.Count - 1
            '    dtList.Rows(i).Item("Order_int") = i + 1
            'Next
            'dtList.AcceptChanges()

            Me.DataGridView1.DataSource = dtList
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtSearch.Focus()

        Dim dr() As DataRow = Me.dtList.Select("Check=1")
        For i As Integer = 0 To dr.Length - 1
            Dim drCheck() As DataRow = dt.Select("AAccountID=" + dr(i).Item("AAccountID").ToString)
            If drCheck.Length = 0 Then
                Dim drNew As DataRow = dt.NewRow
                drNew.Item("ContractingPartyID") = dr(i).Item("ContractingPartyID")
                drNew.Item("FirstName_nvc") = dr(i).Item("FirstName_nvc")
                drNew.Item("LastName_nvc") = dr(i).Item("LastName_nvc")
                drNew.Item("FatherName_nvc") = dr(i).Item("FatherName_nvc")
                drNew.Item("IdentityCertificateNO_nvc") = dr(i).Item("IdentityCertificateNO_nvc")
                drNew.Item("NationalCode_nvc") = dr(i).Item("NationalCode_nvc")
                drNew.Item("Gender_bit") = dr(i).Item("Gender_bit")
                drNew.Item("BirthDate_vc") = dr(i).Item("BirthDate_vc")
                drNew.Item("StateID") = dr(i).Item("StateID")
                drNew.Item("CityID") = dr(i).Item("CityID")
                drNew.Item("CIdentityTypeID") = dr(i).Item("CIdentityTypeID")
                drNew.Item("DegreeID") = dr(i).Item("DegreeID")
                drNew.Item("Title_nvc") = dr(i).Item("Title_nvc")
                drNew.Item("HomeTel_vc") = dr(i).Item("HomeTel_vc")
                drNew.Item("Mobile_vc") = dr(i).Item("Mobile_vc")
                drNew.Item("Email_nvc") = dr(i).Item("Email_nvc")
                drNew.Item("HavingAccount_bit") = dr(i).Item("HavingAccount_bit")
                drNew.Item("AccountTypeID") = dr(i).Item("AccountTypeID")
                drNew.Item("AccountNO_vc") = dr(i).Item("AccountNO_vc")
                drNew.Item("CardNo_vc") = dr(i).Item("CardNo_vc")
                drNew.Item("BranchID") = dr(i).Item("BranchID")
                drNew.Item("ContractID") = dr(i).Item("ContractID")
                drNew.Item("ContractNo_vc") = dr(i).Item("ContractNo_vc")
                drNew.Item("Merchant_vc") = dr(i).Item("Merchant_vc")
                drNew.Item("SaveDate_vc") = dr(i).Item("SaveDate_vc")
                drNew.Item("Date_vc") = dr(i).Item("Date_vc")
                drNew.Item("VisitorID") = dr(i).Item("VisitorID")
                drNew.Item("AAccountID") = dr(i).Item("AAccountID")
                drNew.Item("AAccountNO_vc") = dr(i).Item("AAccountNO_vc")
                drNew.Item("ACardNo_vc") = dr(i).Item("ACardNo_vc")
                drNew.Item("AAccountTypeID") = dr(i).Item("AAccountTypeID")
                drNew.Item("AAccountTypeIDName_nvc") = dr(i).Item("AAccountTypeIDName_nvc")
                drNew.Item("ABranchID") = dr(i).Item("ABranchID")
                drNew.Item("ABranchIDName_nvc") = dr(i).Item("ABranchIDName_nvc")
                drNew.Item("AAccountingDetailID") = dr(i).Item("AAccountingDetailID")
                drNew.Item("AAccountingHeaderID") = dr(i).Item("AAccountingHeaderID")
                dt.Rows.Add(drNew)
            End If
        Next

        'For i As Integer = 0 To dt.Rows.Count - 1
        '    dt.Rows(i).Item("Order_int") = i + 1
        'Next
        'dt.AcceptChanges()
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

        'Dim colOrder_int As New System.Windows.Forms.DataGridViewTextBoxColumn
        'colOrder_int.DataPropertyName = "Order_int"
        'colOrder_int.HeaderText = "ردیف"
        'colOrder_int.Name = "colOrder_int"
        'colOrder_int.ReadOnly = True
        'colOrder_int.Width = 50
        'Me.DataGridView1.Columns.Add(colOrder_int)

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


        Dim colSCityName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSCityName_nvc.DataPropertyName = "SCityName_nvc"
        colSCityName_nvc.HeaderText = "شهر"
        colSCityName_nvc.Name = "colSCityName_nvc"
        colSCityName_nvc.ReadOnly = True
        colSCityName_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colSCityName_nvc)

        Dim colSPostCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSPostCode_vc.DataPropertyName = "PostCode_vc"
        colSPostCode_vc.HeaderText = "کد پستی"
        colSPostCode_vc.Name = "colSPostCode_vc"
        colSPostCode_vc.ReadOnly = True
        colSPostCode_vc.Width = 100
        Me.DataGridView1.Columns.Add(colSPostCode_vc)
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
                    Me.dtList.DefaultView.RowFilter = "ContractID = " + Me.txtSearch.Text.ToString
                End If
            Case 4
                Me.dtList.DefaultView.RowFilter = "ContractNo_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 5
                Me.dtList.DefaultView.RowFilter = "SaveDate_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 6
                Me.dtList.DefaultView.RowFilter = "Date_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 7
                Me.dtList.DefaultView.RowFilter = "AAccountNO_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 8
                Me.dtList.DefaultView.RowFilter = "ACardNo_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 9
                Me.dtList.DefaultView.RowFilter = "AAccountTypeIDName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 10
                Me.dtList.DefaultView.RowFilter = "ABranchIDName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 11
                If Me.txtSearch.Text = "" Then
                    Me.dtList.DefaultView.RowFilter = ""
                ElseIf IsNumeric(Me.txtSearch.Text) = True Then
                    Me.dtList.DefaultView.RowFilter = "MunicipalAreaNO_sint = " + Val(Me.txtSearch.Text).ToString + ""
                End If
            Case 12
                Me.dtList.DefaultView.RowFilter = "SCityName_nvc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
            Case 13
                Me.dtList.DefaultView.RowFilter = "PostCode_vc Like '%" + CorrectLike(Me.txtSearch.Text) + "%'"
        End Select

    End Sub

End Class