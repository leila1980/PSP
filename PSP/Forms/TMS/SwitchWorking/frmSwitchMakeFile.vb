Public Class frmSwitchMakeFile
    Private dtList As New DataTable
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalAccess As New ClassDALAccessSwitch
    Private clsDalSwitch As New ClassDALSwitch(ConnectionString)


    Private Sub frmAccountingMakeFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

            Me.lblNumberFrom.Visible = False
            Me.lblNumberTo.Visible = False
            Me.txtNumberTo.Visible = False
            Me.lblDate.Visible = False
            Me.lblDateFrom.Visible = False
            Me.lblDateTo.Visible = False
            Me.txtDateFrom.Visible = False
            Me.txtDateTo.Visible = False

            Me.Text = "ارسال فایل جهت سوئیچ"
            Me.InitDataGridView()
            Me.dtList.Rows.Clear()
            Me.txtNumberFrom.Text = GetMaxNumber()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Function GetMaxNumber()
        Try
            Dim dt As New DataTable
            dt = clsDalSwitch.GetTheLatestSwitchHeaderNumber()
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item("Number_bint")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Overrides Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.dtList.Rows.Clear()
            Me.dtList = clsDalSwitch.GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForSwitchMakeFile(Val(Me.txtNumberFrom.Text), ClassUserLoginDataAccess.ThisUser.ProjectID, False)
            Me.DataGridView1.DataSource = dtList
            ' dtList.DefaultView.Sort = "SName_nvc"
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Overrides Sub btnMakeFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If txtHour.Text.Length < 5 Then
                modPublicMethod.ShowErrorMessage("ساعت وارد نشده است") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If
            If Val(txtHour.Text.Substring(0, 2)) > 23 OrElse Val(txtHour.Text.Substring(0, 2)) < 0 Then
                modPublicMethod.ShowErrorMessage("ساعت وارد شده نامعتبر می باشد") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If
            If Val(txtHour.Text.Substring(3, 2)) > 59 OrElse Val(txtHour.Text.Substring(3, 2)) < 0 Then
                modPublicMethod.ShowErrorMessage("ساعت وارد شده نامعتبر می باشد") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If

            If Me.dtList.DefaultView.ToTable.Rows.Count = 0 Then
                modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If

            'Me.BackupPreAccessFile()
            clsDalAccess.ConnectionOpen()
            clsDalAccess.DeleteALLTAlocate()
            clsDalAccess.DeleteALLTMerchant()
            clsDalAccess.DeleteALLTOutlet()
            clsDalAccess.DeleteALLTPos()
            clsDalAccess.DeleteALLTreg()
            Me.InsertIntoAccessFiles()
            clsDalAccess.ConnectionClose()
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
            My.Computer.FileSystem.CopyFile(modPublicMethod.AccessSwitchFilePath, modPublicMethod.AccessSwitchBackupsFolderPath + " \Switch_" + bckDate + "_" + bckTime + ".mdb", True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitDataGridView()
        Me.DataGridView1.AutoGenerateColumns = False

        Dim colFirstName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFirstName_nvc.DataPropertyName = "FirstName_nvc"
        colFirstName_nvc.HeaderText = "نام"
        colFirstName_nvc.Name = "colFirstName_nvc"
        colFirstName_nvc.ReadOnly = True
        colFirstName_nvc.Width = 150
        Me.DataGridView1.Columns.Add(colFirstName_nvc)

        Dim colLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colLastName_nvc.DataPropertyName = "LastName_nvc"
        colLastName_nvc.HeaderText = "نام خانوادگی"
        colLastName_nvc.Name = "colLastName_nvc"
        colLastName_nvc.ReadOnly = True
        colLastName_nvc.Width = 250
        Me.DataGridView1.Columns.Add(colLastName_nvc)

        Dim colSName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSName_nvc.DataPropertyName = "SName_nvc"
        colSName_nvc.HeaderText = "نام فروشگاه"
        colSName_nvc.Name = "colSName_nvc"
        colSName_nvc.ReadOnly = True
        colSName_nvc.Width = 250
        Me.DataGridView1.Columns.Add(colSName_nvc)

        Dim colDCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDCode_vc.DataPropertyName = "DCode_vc"
        colDCode_vc.HeaderText = "كد پز"
        colDCode_vc.Name = "colDCode_vc"
        colDCode_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colDCode_vc)

        Dim colPSerial_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPSerial_vc.DataPropertyName = "PSerial_vc"
        colPSerial_vc.HeaderText = "سريال پز"
        colPSerial_vc.Name = "colPSerial_vc"
        colPSerial_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colPSerial_vc)

        Dim colDOutLet_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDOutLet_vc.DataPropertyName = "DOutLet_vc"
        colDOutLet_vc.HeaderText = "Outlet"
        colDOutLet_vc.Name = "colDOutLet_vc"
        colDOutLet_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colDOutLet_vc)


        Dim colDVat_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDVat_vc.DataPropertyName = "DVat_vc"
        colDVat_vc.HeaderText = "Vat"
        colDVat_vc.Name = "colDVat_vc"
        colDVat_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colDVat_vc)


        Dim colMerchant_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colMerchant_vc.DataPropertyName = "DMerchant_vc"
        colMerchant_vc.HeaderText = "Merchant"
        colMerchant_vc.Name = "colMerchant_vc"
        colMerchant_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colMerchant_vc)


        Dim colAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAccountNO_vc.DataPropertyName = "AAccountNO_vc"
        colAccountNO_vc.HeaderText = "شماره حساب"
        colAccountNO_vc.Name = "colAccountNO_vc"
        colAccountNO_vc.ReadOnly = True
        colAccountNO_vc.Width = 100
        Me.DataGridView1.Columns.Add(colAccountNO_vc)


        Dim colAAccountTypeIDName_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountTypeIDName_vc.DataPropertyName = "AAccountTypeName_vc"
        colAAccountTypeIDName_vc.HeaderText = "نوع حساب"
        colAAccountTypeIDName_vc.Name = "colAAccountTypeIDName_vc"
        colAAccountTypeIDName_vc.ReadOnly = True
        colAAccountTypeIDName_vc.Width = 100
        Me.DataGridView1.Columns.Add(colAAccountTypeIDName_vc)


        Dim colABranchID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colABranchID.DataPropertyName = "ABranchID"
        colABranchID.HeaderText = "كد شعبه"
        colABranchID.Name = "colABranchID"
        colABranchID.ReadOnly = True
        colABranchID.Width = 100
        Me.DataGridView1.Columns.Add(colABranchID)

        Dim colSCityID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSCityID.DataPropertyName = "SCityID"
        colSCityID.HeaderText = "كد شهر فروشگاه"
        colSCityID.Name = "colSCityID"
        colSCityID.ReadOnly = True
        colSCityID.Width = 100
        Me.DataGridView1.Columns.Add(colSCityID)

        Dim colSCityName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSCityName_nvc.DataPropertyName = "SCityName_nvc"
        colSCityName_nvc.HeaderText = "نام شهر فروشگاه"
        colSCityName_nvc.Name = "colSCityName_nvc"
        colSCityName_nvc.ReadOnly = True
        colSCityName_nvc.Width = 150
        Me.DataGridView1.Columns.Add(colSCityName_nvc)

        Dim colStateID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colStateID.DataPropertyName = "StateID"
        colStateID.HeaderText = "كد استان فروشگاه"
        colStateID.Name = "colStateID"
        colStateID.ReadOnly = True
        Me.DataGridView1.Columns.Add(colStateID)

        Dim colSTel1_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSTel1_vc.DataPropertyName = "STel1_vc"
        colSTel1_vc.HeaderText = "تلفن 1 فروشگاه"
        colSTel1_vc.Name = "colSTel1_vc"
        colSTel1_vc.ReadOnly = True
        colSTel1_vc.Width = 100
        Me.DataGridView1.Columns.Add(colSTel1_vc)

        Dim colSTel2_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSTel2_vc.DataPropertyName = "STel2_vc"
        colSTel2_vc.HeaderText = "تلفن 2 فروشگاه"
        colSTel2_vc.Name = "colSTel2_vc"
        colSTel2_vc.ReadOnly = True
        colSTel2_vc.Width = 100
        Me.DataGridView1.Columns.Add(colSTel2_vc)


        Dim colSAddress_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSAddress_nvc.DataPropertyName = "SAddress_nvc"
        colSAddress_nvc.HeaderText = "آدرس فروشگاه"
        colSAddress_nvc.Name = "colSAddress_nvc"
        colSAddress_nvc.ReadOnly = True
        colSAddress_nvc.Width = 300
        Me.DataGridView1.Columns.Add(colSAddress_nvc)

        Dim colSPostCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSPostCode_vc.DataPropertyName = "SPostCode_vc"
        colSPostCode_vc.HeaderText = "كد پستي فروشگاه"
        colSPostCode_vc.Name = "colSPostCode_vc"
        colSPostCode_vc.ReadOnly = True
        colSPostCode_vc.Width = 100
        Me.DataGridView1.Columns.Add(colSPostCode_vc)


        Dim colCIdentityTypeIDName_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colCIdentityTypeIDName_vc.DataPropertyName = "CIdentityTypeName_nvc"
        colCIdentityTypeIDName_vc.HeaderText = "نوع مدرك شناسايي"
        colCIdentityTypeIDName_vc.Name = "colCIdentityTypeIDName_vc"
        colCIdentityTypeIDName_vc.ReadOnly = True
        colCIdentityTypeIDName_vc.Width = 150
        Me.DataGridView1.Columns.Add(colCIdentityTypeIDName_vc)

        Dim colEmail_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colEmail_nvc.DataPropertyName = "Email_nvc"
        colEmail_nvc.HeaderText = "ايميل"
        colEmail_nvc.Name = "colEmail_nvc"
        colEmail_nvc.ReadOnly = True
        colEmail_nvc.Width = 150
        Me.DataGridView1.Columns.Add(colEmail_nvc)

        Dim colSFax_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSFax_vc.DataPropertyName = "SFax_vc"
        colSFax_vc.HeaderText = "فكس"
        colSFax_vc.Name = "colSFax_vc"
        colSFax_vc.ReadOnly = True
        colSFax_vc.Width = 100
        Me.DataGridView1.Columns.Add(colSFax_vc)

        Dim colIdentityCertificateNO_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colIdentityCertificateNO_nvc.DataPropertyName = "IdentityCertificateNO_nvc"
        colIdentityCertificateNO_nvc.HeaderText = "شماره مدرك شناسايي"
        colIdentityCertificateNO_nvc.Name = "colIdentityCertificateNO_nvc"
        colIdentityCertificateNO_nvc.ReadOnly = True
        colIdentityCertificateNO_nvc.Width = 100
        Me.DataGridView1.Columns.Add(colIdentityCertificateNO_nvc)


        Dim colCityID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colCityID.DataPropertyName = "CityID"
        colCityID.HeaderText = "كد شهر محل تولد"
        colCityID.Name = "colCityID"
        colCityID.ReadOnly = True
        Me.DataGridView1.Columns.Add(colCityID)

        Dim colHomeAddress_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colHomeAddress_nvc.DataPropertyName = "HomeAddress_nvc"
        colHomeAddress_nvc.HeaderText = "آدرس منزل"
        colHomeAddress_nvc.Name = "colHomeAddress_nvc"
        colHomeAddress_nvc.ReadOnly = True
        colHomeAddress_nvc.Width = 300
        Me.DataGridView1.Columns.Add(colHomeAddress_nvc)


        Dim colHomeTel_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colHomeTel_vc.DataPropertyName = "HomeTel_vc"
        colHomeTel_vc.HeaderText = "تلفن منزل"
        colHomeTel_vc.Name = "colHomeTel_vc"
        colHomeTel_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colHomeTel_vc)

        Dim colMobile_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colMobile_vc.DataPropertyName = "Mobile_vc"
        colMobile_vc.HeaderText = "موبايل"
        colMobile_vc.Name = "colMobile_vc"
        colMobile_vc.ReadOnly = True
        Me.DataGridView1.Columns.Add(colMobile_vc)

        Dim colSGroupID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSGroupID.DataPropertyName = "SGroupID"
        colSGroupID.HeaderText = "كد گروه"
        colSGroupID.Name = "colSGroupID"
        colSGroupID.ReadOnly = True
        Me.DataGridView1.Columns.Add(colSGroupID)

    End Sub

    Private Sub InsertIntoAccessFiles()
        Dim dtStoreTel As New DataTable
        Dim dtIsSerialRepeated As New DataTable
        Try
            clsDalContract.BeginProc()
            For Each dr As DataRow In dtList.DefaultView.ToTable.Rows
                clsDalAccess.MPhone1 = dr.Item("STel1_vc")
                clsDalAccess.OPhone1 = dr.Item("STel1_vc")
                clsDalAccess.MPhone2 = dr.Item("STel2_vc")
                clsDalAccess.OPhone2 = dr.Item("STel2_vc")

                '/// Me.SaveToAccessFile()
                '///SaveToAccessFile_TMerchant()
                clsDalAccess.MAccountNo = dr.Item("AAccountNO_vc").ToString
                clsDalAccess.MAccountType = dr.Item("AAccountTypeName_vc")
                clsDalAccess.MAcronym = dr.Item("SName_nvc")
                clsDalAccess.MBranch = dr.Item("ABranchID")
                clsDalAccess.MCareof = dr.Item("SName_nvc")
                clsDalAccess.MCity = dr.Item("SCityID")
                clsDalAccess.MDoc_Type = dr.Item("CIdentityTypeName_nvc")
                clsDalAccess.MEmail = dr.Item("Email_nvc")
                clsDalAccess.MFax = dr.Item("SFax_vc")
                clsDalAccess.MFname = dr.Item("FirstName_nvc")
                clsDalAccess.MID = dr.Item("IdentityCertificateNO_nvc")

                Select Case dr.Item("SAddress_nvc").ToString.Length
                    Case Is <= 30
                        clsDalAccess.MLine1 = dr.Item("SAddress_nvc")
                        clsDalAccess.MLine2 = String.Empty
                        clsDalAccess.MLine3 = String.Empty
                        clsDalAccess.MLine4 = String.Empty
                    Case Is <= 60
                        clsDalAccess.MLine1 = dr.Item("SAddress_nvc").ToString.Substring(0, 30)
                        clsDalAccess.MLine2 = dr.Item("SAddress_nvc").ToString.Substring(30, dr.Item("SAddress_nvc").ToString.Length - 30)
                        clsDalAccess.MLine3 = String.Empty
                        clsDalAccess.MLine4 = String.Empty
                    Case Is <= 90
                        clsDalAccess.MLine1 = dr.Item("SAddress_nvc").ToString.Substring(0, 30)
                        clsDalAccess.MLine2 = dr.Item("SAddress_nvc").ToString.Substring(30, 30)
                        clsDalAccess.MLine3 = dr.Item("SAddress_nvc").ToString.Substring(60, dr.Item("SAddress_nvc").ToString.Length - 60)
                        clsDalAccess.MLine4 = String.Empty
                    Case Is <= 120
                        clsDalAccess.MLine1 = dr.Item("SAddress_nvc").ToString.Substring(0, 30)
                        clsDalAccess.MLine2 = dr.Item("SAddress_nvc").ToString.Substring(30, 30)
                        clsDalAccess.MLine3 = dr.Item("SAddress_nvc").ToString.Substring(60, 30)
                        clsDalAccess.MLine4 = dr.Item("SAddress_nvc").ToString.Substring(90, dr.Item("SAddress_nvc").ToString.Length - 90)
                End Select
                clsDalAccess.MZip = dr.Item("SPostCode_vc")
                clsDalAccess.MLname = dr.Item("LastName_nvc")
                clsDalAccess.MLocation = dr.Item("SCityName_nvc")
                clsDalAccess.MMerchant = dr.Item("DMerchant_vc")
                clsDalAccess.MOCity = dr.Item("CityID")

                Select Case dr.Item("HomeAddress_nvc").ToString.Length
                    Case Is <= 30
                        clsDalAccess.MOLine1 = dr.Item("HomeAddress_nvc")
                        clsDalAccess.MOLine2 = String.Empty
                        clsDalAccess.MOLine3 = String.Empty
                        clsDalAccess.MOLine4 = String.Empty
                    Case Is <= 60
                        clsDalAccess.MOLine1 = dr.Item("HomeAddress_nvc").ToString.Substring(0, 30)
                        clsDalAccess.MOLine2 = dr.Item("HomeAddress_nvc").ToString.Substring(30, dr.Item("HomeAddress_nvc").ToString.Length - 30)
                        clsDalAccess.MOLine3 = String.Empty
                        clsDalAccess.MOLine4 = String.Empty
                    Case Is <= 90
                        clsDalAccess.MOLine1 = dr.Item("HomeAddress_nvc").ToString.Substring(0, 30)
                        clsDalAccess.MOLine2 = dr.Item("HomeAddress_nvc").ToString.Substring(30, 30)
                        clsDalAccess.MOLine3 = dr.Item("HomeAddress_nvc").ToString.Substring(60, dr.Item("HomeAddress_nvc").ToString.Length - 60)
                        clsDalAccess.MOLine4 = String.Empty
                    Case Is <= 120
                        clsDalAccess.MOLine1 = dr.Item("HomeAddress_nvc").ToString.Substring(0, 30)
                        clsDalAccess.MOLine2 = dr.Item("HomeAddress_nvc").ToString.Substring(30, 30)
                        clsDalAccess.MOLine3 = dr.Item("HomeAddress_nvc").ToString.Substring(60, 30)
                        clsDalAccess.MOLine4 = dr.Item("HomeAddress_nvc").ToString.Substring(90, dr.Item("HomeAddress_nvc").ToString.Length - 90)
                End Select
                clsDalAccess.MOZip = dr.Item("SPostCode_vc")
                clsDalAccess.MOPhone1 = dr.Item("HomeTel_vc")
                clsDalAccess.MOPhone2 = dr.Item("Mobile_vc")
                clsDalAccess.MORegion = dr.Item("StateID")
                clsDalAccess.MOCareof = dr.Item("SName_nvc")
                clsDalAccess.MRegion = dr.Item("SStateID")
                clsDalAccess.MVat = dr.Item("DVat_vc")

                clsDalAccess.InsertTMerchant()
                ''///SaveToAccessFile_TOutlet()
                clsDalAccess.OAcronym = dr.Item("SName_nvc")
                clsDalAccess.OCareof = dr.Item("SName_nvc")
                clsDalAccess.OCity = dr.Item("CityID")
                clsDalAccess.OEmail = dr.Item("Email_nvc")
                clsDalAccess.OFax = dr.Item("SFax_vc")

                Select Case dr.Item("SAddress_nvc").ToString.Length
                    Case Is <= 30
                        clsDalAccess.OLine1 = dr.Item("SAddress_nvc")
                        clsDalAccess.OLine2 = String.Empty
                        clsDalAccess.OLine3 = String.Empty
                        clsDalAccess.OLine4 = String.Empty
                    Case Is <= 60
                        clsDalAccess.OLine1 = dr.Item("SAddress_nvc").ToString.Substring(0, 30)
                        clsDalAccess.OLine2 = dr.Item("SAddress_nvc").ToString.Substring(30, dr.Item("SAddress_nvc").ToString.Length - 30)
                        clsDalAccess.OLine3 = String.Empty
                        clsDalAccess.OLine4 = String.Empty
                    Case Is <= 90
                        clsDalAccess.OLine1 = dr.Item("SAddress_nvc").ToString.Substring(0, 30)
                        clsDalAccess.OLine2 = dr.Item("SAddress_nvc").ToString.Substring(30, 30)
                        clsDalAccess.OLine3 = dr.Item("SAddress_nvc").ToString.Substring(60, dr.Item("SAddress_nvc").ToString.Length - 60)
                        clsDalAccess.OLine4 = String.Empty
                    Case Is <= 120
                        clsDalAccess.OLine1 = dr.Item("SAddress_nvc").ToString.Substring(0, 30)
                        clsDalAccess.OLine2 = dr.Item("SAddress_nvc").ToString.Substring(30, 30)
                        clsDalAccess.OLine3 = dr.Item("SAddress_nvc").ToString.Substring(60, 30)
                        clsDalAccess.OLine4 = dr.Item("SAddress_nvc").ToString.Substring(90, dr.Item("SAddress_nvc").ToString.Length - 90)
                End Select

                clsDalAccess.OZip = dr.Item("SPostCode_vc")
                clsDalAccess.OMCC = dr.Item("SGroupID")
                clsDalAccess.OMerchant = dr.Item("DMerchant_vc")
                clsDalAccess.OOutlet = dr.Item("DOutlet_vc")
                clsDalAccess.ORegion = dr.Item("SStateID")

                clsDalAccess.InsertTOutlet()
                ''///SaveToAccessFile_TPos()
                clsDalAccess.POutlet = dr.Item("DOutlet_vc")
                clsDalAccess.PPos = dr.Item("DCode_vc")
                clsDalAccess.PTime = txtHour.Text.Trim.Replace(":", "")
                clsDalAccess.PSerial = dr.Item("PSerial_vc")
                clsDalAccess.PPropertyNO = dr.Item("PPropertyNO_vc")
                clsDalAccess.PAcronym = dr.Item("SName_nvc")

                clsDalAccess.InsertTPos()
                ''///SaveToAccessFile_TAlocate()
                clsDalAccess.ASerial = dr.Item("PSerial_vc")
                clsDalAccess.APos = dr.Item("DCode_vc")

                clsDalAccess.InsertTAlocate()
                ''///SaveToAccessFile_Treg()

                dtIsSerialRepeated.Clear()
                dtIsSerialRepeated = clsDalContract.IsSerialRepeated(dr.Item("PSerial_vc"))
                If dtIsSerialRepeated.Rows.Count = 0 Then
                    clsDalAccess.RSerial = dr.Item("PSerial_vc")
                    clsDalAccess.InsertTreg()
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub


End Class