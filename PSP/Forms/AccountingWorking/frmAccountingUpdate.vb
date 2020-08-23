Public Class frmAccountingUpdate
    Private dt As New DataTable

    Public Overrides Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New OpenFileDialog
        frm.Filter = "Microsoft Office Access|*.mdb"
        frm.CheckFileExists = True
        frm.CheckPathExists = True
        frm.Multiselect = False
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtFilePath.Text = frm.FileName
        End If
    End Sub

    Public Overrides Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim da As New ClassDALContract(ConnectionString)
        Try
            da.BeginProc()
            For Each dr As DataRow In dt.Rows
                da.AAccountID = dr.Item("AccountID")
                If IsDBNull(dr.Item("AccountNO_vc")) Then
                    da.AAccountNO_vc = ""
                Else
                    da.AAccountNO_vc = dr.Item("AccountNO_vc")
                End If
                If IsDBNull(dr.Item("CardNO_vc")) Then
                    da.ACardNo_vc = ""
                Else
                    da.ACardNo_vc = dr.Item("CardNO_vc")
                End If
                da.UpdateAccountOnlyAccountNOCardNO()
            Next
            da.EndProc()
            ShowMessage(modApplicationMessage.msgSuccess)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Overrides Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.txtFilePath.Text <> "" Then
                Me.dt.Rows.Clear()
                Dim Access As New ClassDALAccessAccounting
                dt = Access.GetTClient_Data(Me.txtFilePath.Text)
                Me.DataGridView1.DataSource = dt
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub InitDataGridView()
        Me.DataGridView1.AutoGenerateColumns = False

        Dim colAccountID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAccountID.DataPropertyName = "AccountID"
        colAccountID.HeaderText = "کد حساب"
        colAccountID.Name = "colAccountID"
        colAccountID.ReadOnly = True
        colAccountID.Visible = False
        Me.DataGridView1.Columns.Add(colAccountID)

        Dim colAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAccountNO_vc.DataPropertyName = "AccountNO_vc"
        colAccountNO_vc.HeaderText = "شماره حساب"
        colAccountNO_vc.Name = "colAccountNO_vc"
        colAccountNO_vc.ReadOnly = True
        colAccountNO_vc.Width = 100
        Me.DataGridView1.Columns.Add(colAccountNO_vc)

        Dim colAccount_Type As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAccount_Type.DataPropertyName = "Account_Type"
        colAccount_Type.HeaderText = "نوع حساب"
        colAccount_Type.Name = "colAccount_Type"
        colAccount_Type.ReadOnly = True
        colAccount_Type.Width = 100
        Me.DataGridView1.Columns.Add(colAccount_Type)

        Dim colBranch_Code As New System.Windows.Forms.DataGridViewTextBoxColumn
        colBranch_Code.DataPropertyName = "Branch_Code"
        colBranch_Code.HeaderText = "كد شعبه"
        colBranch_Code.Name = "colBranch_Code"
        colBranch_Code.ReadOnly = True
        colBranch_Code.Width = 100
        Me.DataGridView1.Columns.Add(colBranch_Code)

        Dim colFirst_Name As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFirst_Name.DataPropertyName = "First_Name"
        colFirst_Name.HeaderText = "نام"
        colFirst_Name.Name = "colFirst_Name"
        colFirst_Name.ReadOnly = True
        colFirst_Name.Width = 100
        Me.DataGridView1.Columns.Add(colFirst_Name)

        Dim colFamily_Name As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFamily_Name.DataPropertyName = "Family_Name"
        colFamily_Name.HeaderText = "نام خانوادگی"
        colFamily_Name.Name = "colFamily_Name"
        colFamily_Name.ReadOnly = True
        colFamily_Name.Width = 200
        Me.DataGridView1.Columns.Add(colFamily_Name)


        Dim colGender As New System.Windows.Forms.DataGridViewTextBoxColumn
        colGender.DataPropertyName = "Gender"
        colGender.HeaderText = "جنسيت"
        colGender.Name = "colGender"
        colGender.ReadOnly = True
        colGender.Width = 50
        Me.DataGridView1.Columns.Add(colGender)


        Dim colFather_Name As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFather_Name.DataPropertyName = "Father_Name"
        colFather_Name.HeaderText = "نام پدر"
        colFather_Name.Name = "colFather_Name"
        colFather_Name.ReadOnly = True
        colFather_Name.Width = 100
        Me.DataGridView1.Columns.Add(colFather_Name)


        Dim colBirth_Date As New System.Windows.Forms.DataGridViewTextBoxColumn
        colBirth_Date.DataPropertyName = "Birth_Date"
        colBirth_Date.HeaderText = "تاريخ تولد"
        colBirth_Date.Name = "colBirth_Date"
        colBirth_Date.ReadOnly = True
        colBirth_Date.Width = 100
        Me.DataGridView1.Columns.Add(colBirth_Date)


        Dim colBirth_City As New System.Windows.Forms.DataGridViewTextBoxColumn
        colBirth_City.DataPropertyName = "Birth_City"
        colBirth_City.HeaderText = "محل تولد"
        colBirth_City.Name = "colBirth_City"
        colBirth_City.ReadOnly = True
        colBirth_City.Width = 100
        Me.DataGridView1.Columns.Add(colBirth_City)

        Dim colLegal_ID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colLegal_ID.DataPropertyName = "Legal_ID"
        colLegal_ID.HeaderText = "شماره شناسنامه"
        colLegal_ID.Name = "colLegal_ID"
        colLegal_ID.ReadOnly = True
        colLegal_ID.Width = 100
        Me.DataGridView1.Columns.Add(colLegal_ID)

        Dim colClient_Code As New System.Windows.Forms.DataGridViewTextBoxColumn
        colClient_Code.DataPropertyName = "Client_Code"
        colClient_Code.HeaderText = "كد ملي"
        colClient_Code.Name = "colClient_Code"
        colClient_Code.ReadOnly = True
        colClient_Code.Width = 100
        Me.DataGridView1.Columns.Add(colClient_Code)


        Dim colActivity_Code As New System.Windows.Forms.DataGridViewTextBoxColumn
        colActivity_Code.DataPropertyName = "Activity_Code"
        colActivity_Code.HeaderText = "عنوان شغلي"
        colActivity_Code.Name = "colActivity_Code"
        colActivity_Code.ReadOnly = True
        colActivity_Code.Width = 100
        Me.DataGridView1.Columns.Add(colActivity_Code)

        Dim colSocio_Prof_Code As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSocio_Prof_Code.DataPropertyName = "Socio_Prof_Code"
        colSocio_Prof_Code.HeaderText = "مدرك"
        colSocio_Prof_Code.Name = "colSocio_Prof_Code"
        colSocio_Prof_Code.ReadOnly = True
        colSocio_Prof_Code.Width = 100
        Me.DataGridView1.Columns.Add(colSocio_Prof_Code)


        Dim colAddress_1_Code As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAddress_1_Code.DataPropertyName = "Address_1_Code"
        colAddress_1_Code.HeaderText = "نوع آدرس"
        colAddress_1_Code.Name = "colAddress_1_Code"
        colAddress_1_Code.ReadOnly = True
        colAddress_1_Code.Width = 100
        Me.DataGridView1.Columns.Add(colAddress_1_Code)

        Dim colAddress As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAddress.DataPropertyName = "Address"
        colAddress.HeaderText = "آدرس"
        colAddress.Name = "colAddress"
        colAddress.ReadOnly = True
        colAddress.Width = 100
        Me.DataGridView1.Columns.Add(colAddress)

        Dim colPhone_1 As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPhone_1.DataPropertyName = "Phone_1"
        colPhone_1.HeaderText = "تلفن 1"
        colPhone_1.Name = "colPhone_1"
        colPhone_1.ReadOnly = True
        colPhone_1.Width = 100
        Me.DataGridView1.Columns.Add(colPhone_1)

        Dim colPhone_2 As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPhone_2.DataPropertyName = "Phone_2"
        colPhone_2.HeaderText = "تلفن 2"
        colPhone_2.Name = "colPhone_2"
        colPhone_2.ReadOnly = True
        colPhone_2.Width = 100
        Me.DataGridView1.Columns.Add(colPhone_2)

        Dim colZip_Code As New System.Windows.Forms.DataGridViewTextBoxColumn
        colZip_Code.DataPropertyName = "Zip_Code"
        colZip_Code.HeaderText = "كد پستي"
        colZip_Code.Name = "colZip_Code"
        colZip_Code.ReadOnly = True
        colZip_Code.Width = 100
        Me.DataGridView1.Columns.Add(colZip_Code)

        Dim colCardNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colCardNO_vc.DataPropertyName = "CardNO_vc"
        colCardNO_vc.HeaderText = "شماره كارت"
        colCardNO_vc.Name = "colCardNO_vc"
        colCardNO_vc.ReadOnly = True
        colCardNO_vc.Width = 100
        Me.DataGridView1.Columns.Add(colCardNO_vc)
    End Sub
    Private Sub frmAccountingUpdate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmAccountingUpdate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
        Me.Text = "به روز رساني حساب ها"
        Me.InitDataGridView()
    End Sub

    Private Sub frmAccountingUpdate_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
    
End Class