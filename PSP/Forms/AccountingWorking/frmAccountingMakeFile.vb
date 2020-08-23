Public Class frmAccountingMakeFile
    Private dtList As New DataTable
    Private da As New ClassDALAccount(ConnectionString)

    Private Sub frmAccountingMakeFile_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub

    Private Sub frmAccountingMakeFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.Text = "ارسال فایل جهت افتتاح حساب"
            Me.InitDataGridView()
            Me.dtList.Rows.Clear()
            Me.dtList = da.GetAllContractingParty_Contract_Account_AvailableForAccountingMakeFile
            dtList.Columns("ANumber_bint").DefaultValue = 0
            Me.DataGridView1.DataSource = dtList
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Overrides Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strWhere As String = ""
        If Me.txtDateFrom.Value <> "" Then
            strWhere += "SaveDate_vc>='" + Me.txtDateFrom.Value + "' And "
        End If
        If Me.txtDateTo.Value <> "" Then
            strWhere += "SaveDate_vc<='" + Me.txtDateFrom.Value + "' And "
        End If
        If Me.txtNumberFrom.Text <> "" Then
            strWhere += "ANumber_bint>=" + Me.txtNumberFrom.Text + " And "
        End If
        If Me.txtNumberTo.Text <> "" Then
            strWhere += "ANumber_bint<=" + Me.txtNumberTo.Text + " And "
        End If
        If strWhere.EndsWith(" And ") Then
            strWhere = strWhere.Substring(0, strWhere.Length - 5)
        End If
        Me.dtList.DefaultView.RowFilter = strWhere
    End Sub

    Public Overrides Sub btnMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.dtList.DefaultView.ToTable.Rows.Count = 0 Then
                modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If

            'Me.BackupPreAccessFile()
            Dim Access As New ClassDALAccessAccounting
            Access.ConnectionOpen()
            Access.DeleteALLTClient_Data()
            For Each dr As DataRow In Me.dtList.DefaultView.ToTable.Rows
                Access.Account_Type = dr.Item("AAccountTypeIDName_nvc").ToString
                Access.AccountID = dr.Item("AAccountID").ToString
                Access.AccountNO_vc = dr.Item("AAccountNo_vc").ToString
                Access.Activity_Code = dr.Item("Title_nvc").ToString
                Access.Address = dr.Item("SAddress_nvc").ToString
                Access.Address_1_Code = "2".ToString
                Access.Birth_City = dr.Item("CityName_nvc").ToString
                Access.Birth_Date = dr.Item("BirthDate_vc").ToString.Replace("/", "")
                Access.Branch_Code = dr.Item("ABranchID").ToString
                Access.CardNo_vc = dr.Item("ACardNO_vc").ToString
                Access.Client_Code = dr.Item("NationalCode_nvc").ToString
                Access.Family_Name = dr.Item("LastName_nvc").ToString
                Access.Father_Name = dr.Item("FatherName_nvc").ToString
                Access.First_Name = dr.Item("FirstName_nvc").ToString
                Access.Gender = IIf(dr.Item("Gender_bit"), "مرد", "زن").ToString
                Access.Legal_ID = dr.Item("IdentityCertificateNO_nvc").ToString
                Access.Phone_1 = dr.Item("STel1_vc").ToString
                Access.Phone_2 = dr.Item("HomeTel_vc").ToString
                Access.Socio_Prof_Code = dr.Item("DegreeIDName_nvc").ToString
                Access.Zip_Code = dr.Item("SPostCode_vc").ToString
                Access.InsertTClient_Data()
            Next
            Access.ConnectionClose()
            ShowMessage(msgSuccess)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub BackupPreAccessFile()
        Try
            Dim bckDate As String
            Dim bckTime As String
            bckDate = modPublicMethod.GetDateNow.ToString.Replace("/", "")
            bckTime = modPublicMethod.GetTimeNow.ToString.Replace(":", "")
            My.Computer.FileSystem.CopyFile(modPublicMethod.AccessAccountingFilePath, modPublicMethod.AccessAccountingBackupsFolderPath + " \Accounting_" + bckDate + "_" + bckTime + ".mdb")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitDataGridView()
        Me.DataGridView1.AutoGenerateColumns = False

        Dim colANumber_bint As New System.Windows.Forms.DataGridViewTextBoxColumn
        colANumber_bint.DataPropertyName = "ANumber_bint"
        colANumber_bint.HeaderText = "شماره"
        colANumber_bint.Name = "colANumber_bint"
        colANumber_bint.ReadOnly = True
        Me.DataGridView1.Columns.Add(colANumber_bint)

        Dim colFirstName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFirstName_nvc.DataPropertyName = "FirstName_nvc"
        colFirstName_nvc.HeaderText = "نام"
        colFirstName_nvc.Name = "colFirstName_nvc"
        colFirstName_nvc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colFirstName_nvc)

        Dim colLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colLastName_nvc.DataPropertyName = "LastName_nvc"
        colLastName_nvc.HeaderText = "نام خانوادگی"
        colLastName_nvc.Name = "colLastName_nvc"
        colLastName_nvc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colLastName_nvc)

        Dim colNationalCode_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colNationalCode_nvc.DataPropertyName = "NationalCode_nvc"
        colNationalCode_nvc.HeaderText = "کد ملی"
        colNationalCode_nvc.Name = "colNationalCode_nvc"
        colNationalCode_nvc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colNationalCode_nvc)

        Dim colContractID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractID.DataPropertyName = "ContractID"
        colContractID.HeaderText = "کد قرار داد"
        colContractID.Name = "colContractID"
        colContractID.ReadOnly = True
        Me.DataGridView1.Columns.Add(colContractID)

        Dim colContractNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractNo_vc.DataPropertyName = "ContractNo_vc"
        colContractNo_vc.HeaderText = "شماره قرار داد"
        colContractNo_vc.Name = "colContractNo_vc"
        colContractNo_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colContractNo_vc)

        Dim colDate_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDate_vc.DataPropertyName = "Date_vc"
        colDate_vc.HeaderText = "تاریخ عقد قرارداد"
        colDate_vc.Name = "colDate_vc"
        colDate_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colDate_vc)

        Dim colSaveDate_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSaveDate_vc.DataPropertyName = "SaveDate_vc"
        colSaveDate_vc.HeaderText = "تاریخ ثبت"
        colSaveDate_vc.Name = "colSaveDate_vc"
        colSaveDate_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colSaveDate_vc)


        Dim colAAccountID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountID.DataPropertyName = "AAccountID"
        colAAccountID.HeaderText = "کد حساب"
        colAAccountID.Name = "colAAccountID"
        colAAccountID.ReadOnly = True
        Me.DataGridView1.Columns.Add(colAAccountID)

        Dim colAAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountNO_vc.DataPropertyName = "AAccountNO_vc"
        colAAccountNO_vc.HeaderText = "شماره حساب"
        colAAccountNO_vc.Name = "colAccountNO_vc"
        colAAccountNO_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colAAccountNO_vc)

        Dim colACardNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colACardNo_vc.DataPropertyName = "ACardNo_vc"
        colACardNo_vc.HeaderText = "شماره کارت"
        colACardNo_vc.Name = "colACardNo_vc"
        colACardNo_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colACardNo_vc)

        Dim colAAccountTypeIDName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountTypeIDName_nvc.DataPropertyName = "AAccountTypeIDName_nvc"
        colAAccountTypeIDName_nvc.HeaderText = "نوع حساب"
        colAAccountTypeIDName_nvc.Name = "colAAccountTypeIDName_nvc"
        colAAccountTypeIDName_nvc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colAAccountTypeIDName_nvc)

        Dim colABranchIDName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colABranchIDName_nvc.DataPropertyName = "ABranchIDName_nvc"
        colABranchIDName_nvc.HeaderText = "شعبه"
        colABranchIDName_nvc.Name = "colABranchIDName_nvc"
        colABranchIDName_nvc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colABranchIDName_nvc)
    End Sub

    Private Sub frmAccountingMakeFile_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
End Class