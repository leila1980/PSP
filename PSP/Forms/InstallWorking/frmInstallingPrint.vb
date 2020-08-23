Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports Oracle.DataAccess.Client
Imports log4net

Public Class frmInstallingPrint
    Private clsDal As New Dal(modPublicMethod.ConnectionString)
    Private dtList As New DataTable
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(dgvAssignablePos, True, True, True, True)
    Private clsReport As New ClassDALReport(modPublicMethod.ConnectionString)
    Private clsDalAddress As New ClassDalAddress(modPublicMethod.ConnectionString)
    Dim CMSProjectID As Int16 = 1

#Region "Method"
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(frmInstallingPrint))
    Private Sub frmInstallingPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub

    Private Sub frmDeviceAssigning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Dim dt As DataTable = Me.clsDal.GetTheLatestInstallingHeaderNumber

            If dt.Rows.Count > 0 Then
                Me.txtNumber.Text = dt.Rows(0).Item("Number_bint")
            Else
                Me.txtNumber.Text = 0
            End If
            Me.SetdgvAssignablePos()
            modPublicMethod.ErrorProviderClear(ErrorProvider)
            Dim mhddt As New DataTable
            mhddt = Me.clsDal.GetByNumberInstallingHeader(Val(Me.txtNumber.Text))
            Dim Id As Long

            If mhddt.Rows.Count > 0 Then
                Id = mhddt.Rows(0).Item("InstallingHeaderID")
            End If
            dtList = Me.clsDal.GetByIDInstallingDetail(Id, ClassUserLoginDataAccess.ThisUser.ProjectID)
            Me.dgvAssignablePos.DataSource = dtList

            CMSProjectID = mhddt.Rows(0).Item("cmsprojectid")

            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Try
            Dim mhddt As New DataTable
            mhddt = Me.clsDal.GetByNumberInstallingHeader(Val(Me.txtNumber.Text))
            Dim Id As Long
            If mhddt.Rows.Count > 0 Then
                Id = mhddt.Rows(0).Item("InstallingHeaderID")
            End If
            dtList = Me.clsDal.GetByIDInstallingDetail(Id, ClassUserLoginDataAccess.ThisUser.ProjectID)
            Me.dgvAssignablePos.DataSource = dtList
            CMSProjectID = mhddt.Rows(0).Item("cmsprojectid")
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub txtNumber_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnShow_Click(Me.btnShow, e)
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Select Case CMSProjectID
                Case 1
                    PrintTejarat()
                Case 3
                    PrintPOST()
            End Select

        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub frmInstallingPrint_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvAssignablePos)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvAssignablePos.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(Me.dgvAssignablePos.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvAssignablePos.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvAssignablePos.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvAssignablePos.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvAssignablePos.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub

    Private Sub btnRePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRePrint.Click
        Try
            RePrint()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub btnPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDF.Click
        Try

            Select Case CMSProjectID
                Case 1
                    PDF()
                Case 3
                    PDFPOST()
            End Select

        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try

    End Sub

    Private Sub dgvAssignablePos_DataSourceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvAssignablePos.DataSourceChanged
        If dgvAssignablePos.RowCount > 0 Then
            Me.btnPrint.Enabled = True
        Else
            Me.btnPrint.Enabled = False
        End If
    End Sub

#End Region
#Region "Function"

    Private Sub SetdgvAssignablePos()
        Me.dgvAssignablePos.AutoGenerateColumns = False

        Dim printButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        printButton.Button = btnPrint
        printButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Print
        printButton.e = New eventhandler(AddressOf btnPrint_Click)
        printButton.ShortCut = ClassSetting.Print_Shortcut
        clsMyControler.AddButton(printButton)


        Dim colVisitorLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colVisitorLastName_nvc.DataPropertyName = "VisitorLastName_nvc"
        colVisitorLastName_nvc.HeaderText = "نام بازاریاب"
        colVisitorLastName_nvc.Name = "colVisitorLastName_nvc"
        colVisitorLastName_nvc.ReadOnly = True
        colVisitorLastName_nvc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colVisitorLastName_nvc)



        Dim colContractID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractID.DataPropertyName = "ContractID"
        colContractID.HeaderText = "کد طرف قرارداد"
        colContractID.Name = "colContractID"
        colContractID.ReadOnly = True
        colContractID.Width = 100
        Me.dgvAssignablePos.Columns.Add(colContractID)


        Dim colFirstName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFirstName_nvc.DataPropertyName = "FirstName_nvc"
        colFirstName_nvc.HeaderText = "نام"
        colFirstName_nvc.Name = "colFirstName_nvc"
        colFirstName_nvc.ReadOnly = True
        colFirstName_nvc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colFirstName_nvc)

        Dim colLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colLastName_nvc.DataPropertyName = "LastName_nvc"
        colLastName_nvc.HeaderText = "نام خانوادگی"
        colLastName_nvc.Name = "colLastName_nvc"
        colLastName_nvc.ReadOnly = True
        colLastName_nvc.Width = 200
        Me.dgvAssignablePos.Columns.Add(colLastName_nvc)

        Dim colNationalCode_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colNationalCode_nvc.DataPropertyName = "NationalCode_nvc"
        colNationalCode_nvc.HeaderText = "کد ملی"
        colNationalCode_nvc.Name = "colNationalCode_nvc"
        colNationalCode_nvc.ReadOnly = True
        colNationalCode_nvc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colNationalCode_nvc)

        Dim colContractNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractNo_vc.DataPropertyName = "ContractNo_vc"
        colContractNo_vc.HeaderText = "شماره قرار داد"
        colContractNo_vc.Name = "colContractNo_vc"
        colContractNo_vc.ReadOnly = True
        colContractNo_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colContractNo_vc)

        Dim colAAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountNO_vc.DataPropertyName = "AAccountNO_vc"
        colAAccountNO_vc.HeaderText = "شماره حساب"
        colAAccountNO_vc.Name = "colAccountNO_vc"
        colAAccountNO_vc.ReadOnly = True
        colAAccountNO_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colAAccountNO_vc)

        Dim colACardNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colACardNo_vc.DataPropertyName = "ACardNo_vc"
        colACardNo_vc.HeaderText = "شماره کارت"
        colACardNo_vc.Name = "colACardNo_vc"
        colACardNo_vc.ReadOnly = True
        colACardNo_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colACardNo_vc)

        Dim colSStoreID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSStoreID.DataPropertyName = "SStoreID"
        colSStoreID.HeaderText = "کد فروشگاه"
        colSStoreID.Name = "colSStoreID"
        colSStoreID.ReadOnly = True
        colSStoreID.Width = 100
        Me.dgvAssignablePos.Columns.Add(colSStoreID)


        Dim colSName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSName_nvc.DataPropertyName = "SName_nvc"
        colSName_nvc.HeaderText = "نام فروشگاه"
        colSName_nvc.Name = "colSName_nvc"
        colSName_nvc.ReadOnly = True
        colSName_nvc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colSName_nvc)


        Dim colDDeviceID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDDeviceID.DataPropertyName = "DDeviceID"
        colDDeviceID.HeaderText = "کد دستگاه"
        colDDeviceID.Name = "colDDeviceID"
        colDDeviceID.ReadOnly = True
        colDDeviceID.Width = 100
        Me.dgvAssignablePos.Columns.Add(colDDeviceID)


        Dim colDCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDCode_vc.DataPropertyName = "DCode_vc"
        colDCode_vc.HeaderText = "پز کد"
        colDCode_vc.Name = "colDCode_vc"
        colDCode_vc.ReadOnly = True
        colDCode_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colDCode_vc)


        Dim colDOutlet_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDOutlet_vc.DataPropertyName = "DOutlet_vc"
        colDOutlet_vc.HeaderText = "Outlet"
        colDOutlet_vc.Name = "colDOutlet_vc"
        colDOutlet_vc.ReadOnly = True
        colDOutlet_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colDOutlet_vc)

        Dim colDVat_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDVat_vc.DataPropertyName = "DVat_vc"
        colDVat_vc.HeaderText = "Vat"
        colDVat_vc.Name = "colDVat_vc"
        colDVat_vc.ReadOnly = True
        colDVat_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colDVat_vc)

        Dim colDMerchant_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDMerchant_vc.DataPropertyName = "DMerchant_vc"
        colDMerchant_vc.HeaderText = "Merchant"
        colDMerchant_vc.Name = "colDMerchant_vc"
        colDMerchant_vc.ReadOnly = True
        colDMerchant_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colDMerchant_vc)

        Dim colPosID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPosID.DataPropertyName = "PPosID"
        colPosID.HeaderText = "کد پز"
        colPosID.Name = "colPosID"
        colPosID.ReadOnly = True
        colPosID.Width = 100
        Me.dgvAssignablePos.Columns.Add(colPosID)

        Dim colPSerial_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPSerial_vc.DataPropertyName = "PSerial_vc"
        colPSerial_vc.HeaderText = "سریال پز"
        colPSerial_vc.Name = "colPSerial_vc"
        colPSerial_vc.ReadOnly = True
        colPSerial_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colPSerial_vc)


        Dim colPPropertyNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPPropertyNO_vc.DataPropertyName = "PPropertyNO_vc"
        colPPropertyNO_vc.HeaderText = "شماره اموال"
        colPPropertyNO_vc.Name = "colPPropertyNO_vc"
        colPPropertyNO_vc.ReadOnly = True
        colPPropertyNO_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colPPropertyNO_vc)

        Dim colPEniacCode_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colPEniacCode_vc.DataPropertyName = "PEniacCode_vc"
        colPEniacCode_vc.HeaderText = "کد پیگیری"
        colPEniacCode_vc.Name = "colPEniacCode_vc"
        colPEniacCode_vc.ReadOnly = True
        colPEniacCode_vc.Width = 100
        Me.dgvAssignablePos.Columns.Add(colPEniacCode_vc)

        clsMyControler.DataGridView = Me.dgvAssignablePos
        SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

    End Sub
#Region "TEJARAT"
    Private Sub PrintTejarat()
        Try
            Dim ds As New DataSet1
            PreTEJ(ds)
            Dim r As New rptInstalling
            Dim i As New rptCardex
            r.SetDataSource(ds)
            r.Refresh()
            r.PrintToPrinter(1, True, 0, 0)
            i.SetDataSource(ds)
            i.Refresh()
            i.SetParameterValue("@Title", "مجوز صدور حواله")
            i.PrintToPrinter(1, True, 0, 0)
            i.SetParameterValue("@Title", "برگه تحویل قرارداد")
            i.PrintToPrinter(1, True, 0, 0)
            i.SetParameterValue("@Title", "برگه تحویل دستگاه")
            i.PrintToPrinter(1, True, 0, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RePrint()
        Try
            If txtBatchNo.Text.Trim.Length = 0 Then
                ShowErrorMessage("شماره بچ را وارد كنيد")
                Exit Sub
            End If
            If txtOutlet.Text.Trim.Length = 0 Then
                ShowErrorMessage("را وارد كنيد outlet ")
                Exit Sub
            End If

            Dim mhddt As New DataTable
            mhddt = Me.clsDal.GetByNumberInstallingHeader(Val(Me.txtBatchNo.Text))
            Dim Id As Long
            If mhddt.Rows.Count > 0 Then
                Id = mhddt.Rows(0).Item("InstallingHeaderID")
            Else
                ShowErrorMessage("شماره بچ نامعتبر است")
                Exit Sub
            End If

            Dim dt As New DataTable

            dt = clsDal.GetByOutletInstallingDetailInfo(txtOutlet.Text, Id)
            If dt.Rows.Count > 0 Then
                Dim r As New rptInstalling
                r.SetDataSource(dt)
                r.PrintToPrinter(1, True, 0, 0)
            Else
                ShowErrorMessage("اطلاعات وارد شده نامعتبر است")
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PDF()
        Try
            logger.Info("Start----------------=======================================================")

            Dim clsPDF As New ClassPDF
            Dim ds As New DataSet1
            Dim pdfpath As String = PDFFilePath & "\Installing"
            logger.Info("pdfpath------------------------: " + pdfpath)
          
            Dim datetime As String = Replace(GetDateNow(), "/", "") & Replace(GetTimeNow, ":", "")
            PreTEJ(ds)
            Dim r As New rptInstalling
            Dim i As New rptCardex
            r.SetDataSource(ds)
            r.Refresh()
          
            clsPDF.CreatePDF(pdfpath, Me.Text & datetime, r) 'classUserlogindataaccess.thisuser.ftp
            i.SetDataSource(ds)
            i.Refresh()
            
            i.SetParameterValue("@Title", "مجوز صدور حواله")
            clsPDF.CreatePDF(pdfpath, "مجوز صدور حواله" & datetime, i)
            i.SetParameterValue("@Title", "برگه تحویل قرارداد")
            clsPDF.CreatePDF(pdfpath, "برگه تحویل قرارداد" & datetime, i)
            i.SetParameterValue("@Title", "برگه تحویل دستگاه")
            clsPDF.CreatePDF(pdfpath, "برگه تحویل دستگاه" & datetime, i)
            ShowMessage(modApplicationMessage.msgSuccess)
            logger.Info("End----------------=======================================================")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
   
    Private Sub PreTEJ(ByRef ds As DataSet1)
        Try
            logger.Info("PreTEJ")

            Dim mhddt As New DataTable
            mhddt = Me.clsDal.GetByNumberInstallingHeader(Val(Me.txtNumber.Text))
            Dim Id As Long
            If mhddt.Rows.Count > 0 Then
                Id = mhddt.Rows(0).Item("InstallingHeaderID")
            End If
         
            Dim strSQL As String
            strSQL = "Select  Distinct ('" + mhddt.Rows(0).Item("InstallerIDName_nvc") + "') as InstallerFullName_nvc "
            strSQL += ",('" + mhddt.Rows(0).Item("VisitorIDName_nvc") + "') as VisitorFullName_nvc "
            strSQL += ",(ContractingParty_T.FirstName_nvc || ' ' || ContractingParty_T.LastName_nvc) as ContractingPartyFullName_nvc"
            strSQL += ",Contract_T.ContractID"
            strSQL += ",Store_T.Name_nvc as SName_nvc"
            strSQL += ",Store_T.Tel1_vc as STel1_vc"
            strSQL += ",Store_T.newaddress_nvc as SAddress_nvc "
            strSQL += ",Store_T.MunicipalAreaNO_sint as SMunicipalAreaNO_sint"
            strSQL += ",Device_T.Code_vc as DCode_vc"
            strSQL += ",Device_T.Outlet_vc as DOutlet_vc"
            strSQL += ",'*' || Pos_T.Serial_vc || '*' as PSerial_vc"
            strSQL += ",Pos_T.PropertyNO_vc as PPropertyNO_vc"

            strSQL += ",('*'|| cast(InstallingDetail_T.InstallingDetailID as varchar2(100))|| '*') as InstallingDetailID "

            strSQL += ",Account_T.AccountNo_vc "

            strSQL += ",store_t.postcode_vc "
            strSQL += ",contractingparty_t.nationalcode_nvc "
            strSQL += ",account_t.shabaaccount "
            strSQL += ",contractingparty_t.mobile_vc "
            strSQL += ",group_t.name_nvc "

            strSQL += ",'' parvaneNo_nvc "
            strSQL += ",cmsproject_t.name_nvc acceptorBankName_nvc "
            strSQL += ",(select Name_nvc  from PosModel_T where PosModel_T .PosModelID =Pos_T .PosModelID ) PName_nvc "

            strSQL += "from ContractingParty_T "
            strSQL += "Join Contract_T On  ContractingParty_T.ContractingPartyID = Contract_T.ContractingPartyID "

            strSQL += "Join(contract_cms_t) on contract_cms_t.contractid =contract_t.contractid "
            strSQL += "Join(cmsproject_t) on cmsproject_t.cmsprojectid_int=contract_cms_t.cmsprojectid "

            strSQL += " JOIN  (SELECT V.visitorid "
            strSQL += " FROM UserVisitor_T  V "
            strSQL += " WHERE V.UserID = " + ClassUserLoginDataAccess.ThisUser.UserID.ToString
            strSQL += " or  (SELECT COUNT(*) FROM UserVisitor_T WHERE UserID  = "
            strSQL += ClassUserLoginDataAccess.ThisUser.UserID.ToString + ")=0 ) V_T "
            strSQL += " ON V_T.VisitorID = Contract_T.VisitorID "

            strSQL += "Join Account_T On Contract_T.ContractID = Account_T.ContractID "
            strSQL += "Join Store_T On Store_T.AccountID = Account_T.AccountID "

            strSQL += " join (select max(g.groupid) as groupid,"
            strSQL += " max(g.name_nvc) as name_nvc ,  g.shaparakcode_vc "
            strSQL += " from group_t g"
            strSQL += " group by g.shaparakcode_vc) Group_T "
            strSQL += " ON Group_T.Shaparakcode_Vc =store_t.groupid "


            strSQL += "  JOIN Device_T  ON Device_T.StoreID = Store_T.StoreID "
            strSQL += "  JOIN DevicePos_T  ON DevicePos_T.DeviceID = Device_T.DeviceID "
            strSQL += "  JOIN DevicePos_Device_PosAssigning_  ON DevicePos_T.DeviceID = DevicePos_Device_PosAssigning_.DeviceID "
            strSQL += "  JOIN Pos_T  ON DevicePos_Device_PosAssigning_.PosID = Pos_T.PosID "
            strSQL += "  JOIN InstallingDetail_T  ON InstallingDetail_T.DeviceID= DevicePos_Device_PosAssigning_.DeviceID "
            strSQL += "  JOIN Visitor_T  ON Visitor_T.VisitorID = Contract_T.VisitorID  "


            strSQL += "Where DevicePos_Device_PosAssigning_.Count_int = 1 "
            strSQL += "And InstallingDetail_T.InstallingHeaderID=" + Id.ToString


            logger.Info(strSQL)

            Dim strSQL1 As String

            strSQL1 = "Select "
            strSQL1 += "Contract_T.ContractID as ContractingID,"
            strSQL1 += "Store_T.Name_nvc as SName_nvc,"
            strSQL1 += "'*' || Pos_T.Serial_vc || '*' as PSerial_vc,"
            strSQL1 += "Pos_T.PropertyNO_vc as PPropertyNO_vc,"
            strSQL1 += "Pos_T.EniacCode_vc as PEniacCode_vc "
            strSQL1 += "from Contract_T "
            strSQL1 += "Join Account_T On Contract_T.ContractID = Account_T.ContractID "
            strSQL1 += "Join Store_T On Store_T.AccountID = Account_T.AccountID "
            strSQL1 += "Join Device_T On Device_T.StoreID = Store_T.StoreID "
            strSQL1 += "Join DevicePos_T On DevicePos_T.DeviceID = Device_T.DeviceID "
            strSQL1 += "Join DevicePos_Device_PosAssigning_ On DevicePos_T.DeviceID=DevicePos_Device_PosAssigning_.DeviceID "
            strSQL1 += "Join Pos_T On DevicePos_Device_PosAssigning_.PosID=Pos_T.PosID "
            strSQL1 += "Join InstallingDetail_T On InstallingDetail_T.DeviceID = DevicePos_Device_PosAssigning_.DeviceID "
            strSQL1 += "Where(DevicePos_Device_PosAssigning_.Count_int = 1) "
            strSQL1 += "And InstallingDetail_T.InstallingHeaderID=" + Id.ToString

            logger.Info(strSQL1)

            Dim da As New OracleDataAdapter
            da.SelectCommand = New Oracle.DataAccess.Client.OracleCommand(strSQL)
            da.SelectCommand.Connection = New Oracle.DataAccess.Client.OracleConnection(ConnectionString)
            da.Fill(ds, "DTInstalling")
            da.SelectCommand.CommandText = strSQL1
            da.Fill(ds, "Detail")
            'If ds.DTInstalling.Rows.Count > 0 Then
            '    ds.DTInstalling.Rows(0).Item("InstallingHeaderNumber_bint") = Me.txtNumber.Text
            'End If
            logger.Info("Fill ds................................................................")


            For k As Int32 = 0 To ds.DTInstalling.Rows.Count - 1
                ds.DTInstalling.Rows(k).Item("InstallingHeaderNumber_bint") = Me.txtNumber.Text
                ds.DTInstalling.Rows(k).Item("SAddress_nvc") = clsDalAddress.loadAddressDesc(ds.DTInstalling.Rows(k).Item("SAddress_nvc").ToString())
            Next

            da.SelectCommand.CommandText = "Select sysdate from dual"
            da.SelectCommand.Connection.Open()
            Dim Now As Date = da.SelectCommand.ExecuteScalar
            da.SelectCommand.Connection.Close()

            Dim dr As DataRow = ds.Header.NewRow
            dr.Item("BarcodeNumber_bint") = "*" + Me.txtNumber.Text + "*"
            dr.Item("Number_bint") = Me.txtNumber.Text
            dr.Item("FullName_nvc") = mhddt.Rows(0).Item("InstallerIDName_nvc")
            dr.Item("Date_vc") = DateTool.SpellDate(Now)
            ds.Header.Rows.Add(dr)

            logger.Info("dr.Item(""Number_bint"") :      " + dr.Item("Number_bint").ToString)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
#Region "POST"

    Private Sub PrintPOST()
        Try
            Dim ds As New DataSet1()
            PrePOST(ds)
            Dim r As New rptInstallInfo
            Dim i As New rptInstallConfirm

            'r.SetDataSource(ds)
            'r.Refresh()
            'r.PrintToPrinter(1, True, 0, 0)

            If MessageBox.Show("جهت برگه تایید نصب" & vbCrLf & "قرار داده شده است A5 ", "توجه", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                i.SetDataSource(ds)
                i.Refresh()
                i.PrintToPrinter(1, True, 0, 0)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub PDFPOST()
        Try
            Dim clsPDF As New ClassPDF
            Dim ds As New DataSet1
            Dim pdfpath As String = PDFFilePath & "\InstallInfo"
            Dim datetime As String = Replace(GetDateNow(), "/", "") & Replace(GetTimeNow, ":", "")
            PrePOST(ds)
            Dim r As New rptInstallInfo

            r.SetDataSource(ds)
            r.Refresh()
            clsPDF.CreatePDF(pdfpath, Me.Text & datetime, r) 'classUserlogindataaccess.thisuser.ftp

            ShowMessage(modApplicationMessage.msgSuccess)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PrePOST(ByRef ds As DataSet1)
        Try
            Dim mhddt As New DataTable
            mhddt = Me.clsDal.GetByNumberInstallingHeader(Val(Me.txtNumber.Text))
            Dim Id As Long
            If mhddt.Rows.Count > 0 Then
                Id = mhddt.Rows(0).Item("InstallingHeaderID")
            End If


            Dim strSQL As String

            strSQL = " Select  DISTINCT ContractingParty_T.LastName_nvc as ContractingPartyLastName_nvc "
            strSQL += ",ContractingParty_T.FirstName_nvc  as ContractingPartyFirstName_nvc "
            strSQL += ",Store_T.Name_nvc as SName_nvc "
            strSQL += ",Store_T.Tel1_vc as STel1_vc "
            strSQL += ",store_t.newaddress_nvc as SAddress_nvc "
            strSQL += ",Device_T.Outlet_vc as DOutlet_vc "
            strSQL += ",Device_T.merchant_vc as Merchant_vc "
            strSQL += ",Account_T.AccountNo_vc    AccountNo_vc "
            strSQL += ",store_t.postcode_vc    postcode_vc "
            strSQL += ",contractingparty_t.nationalcode_nvc    nationalcode_nvc "

            strSQL += ",substr (account_t.shabaaccount,3,(length(account_t.shabaaccount)-1) )     shabaaccount "
            strSQL += ",contractingparty_t.mobile_vc  mobile_vc "
            strSQL += ",group_t.name_nvc  name_nvc   "

            strSQL += ",Store_T.Tel2_vc as STel2_vc "
            strSQL += ",Store_T.fax_vc as Sfax_vc "
            strSQL += ",(select city_t.name_nvc from city_t where city_t.cityid=store_t.cityid ) Cname_nvc"
            strSQL += ",(select state_t.name_nvc from state_t where state_t.stateid=store_t.stateid  ) Sname_nvc"
            strSQL += ",(select city_t.name_nvc from city_t where city_t.cityid=contractingparty_T.cityid ) Cpname_nvc"
            strSQL += ",(select state_t.name_nvc from state_t where state_t.stateid=contractingparty_T.stateid  ) Spname_nvc"
            strSQL += ",ContractingParty_T.Email_Nvc as cPEmail_Nvc "
            strSQL += ",ContractingParty_T.Homeaddress_Nvc as cPHomeaddress_Nvc "
            strSQL += ",(select branch_t.name_nvc from branch_t where  branch_t.branchid= contractingparty_T.Branchid  ) Bname_nvc"
            strSQL += ",(select branch_t.branchid from branch_t where  branch_t.branchid= contractingparty_T.Branchid  ) branchid"
            strSQL += ",(ContractingParty_T.FirstName_nvc || ' ' || ContractingParty_T.LastName_nvc) as ContractingPartyFullName_nvc "
            strSQL += ",(select posmodel_t.name_nvc from posmodel_t where pos_t.posmodelid=posmodel_t.posmodelid )    posmodel "
            strSQL += ",pos_t.serial_vc   serial_vc"
            strSQL += ",contract_t.contractno_vc  contractno_vc"

            strSQL += " FROM ContractingParty_T  "

            strSQL += " JOIN Contract_T  ON ContractingParty_T.ContractingPartyID = Contract_T.ContractingPartyID "

            strSQL += " JOIN  (SELECT V.visitorid "
            strSQL += " FROM UserVisitor_T  V "
            strSQL += " WHERE V.UserID = " + ClassUserLoginDataAccess.ThisUser.UserID.ToString
            strSQL += " or  (SELECT COUNT(*) FROM UserVisitor_T WHERE UserID  = "
            strSQL += ClassUserLoginDataAccess.ThisUser.UserID.ToString + ")=0 ) V_T "
            strSQL += " ON V_T.VisitorID = Contract_T.VisitorID "

            strSQL += " join(contract_cms_t) on contract_cms_t.contractid =contract_t.contractid "
            strSQL += " join(cmsproject_t) on cmsproject_t.cmsprojectid_int=contract_cms_t.cmsprojectid "

            strSQL += " join Account_T On Contract_T.ContractID = Account_T.ContractID "
            strSQL += " join Store_T On Store_T.AccountID = Account_T.AccountID "

            strSQL += " join (select max(g.groupid) as groupid,"
            strSQL += " max(g.name_nvc) as name_nvc ,  g.shaparakcode_vc "
            strSQL += " from group_t g"
            strSQL += " group by g.shaparakcode_vc) Group_T "
            strSQL += " ON Group_T.Shaparakcode_Vc =store_t.groupid "

            strSQL += "  JOIN Device_T  ON Device_T.StoreID = Store_T.StoreID "
            strSQL += "  JOIN DevicePos_T  ON DevicePos_T.DeviceID = Device_T.DeviceID "
            strSQL += "  JOIN DevicePos_Device_PosAssigning_  ON DevicePos_T.DeviceID = DevicePos_Device_PosAssigning_.DeviceID "
            strSQL += "  JOIN Pos_T  ON DevicePos_Device_PosAssigning_.PosID = Pos_T.PosID "
            strSQL += "  JOIN InstallingDetail_T  ON InstallingDetail_T.DeviceID= DevicePos_Device_PosAssigning_.DeviceID "
            strSQL += "  JOIN Visitor_T  ON Visitor_T.VisitorID = Contract_T.VisitorID  "

            strSQL += "WHERE DevicePos_Device_PosAssigning_.Count_int = 1 "
            strSQL += "AND InstallingDetail_T.InstallingHeaderID =" + Id.ToString



            Dim da As New OracleDataAdapter
            da.SelectCommand = New Oracle.DataAccess.Client.OracleCommand(strSQL)
            da.SelectCommand.Connection = New Oracle.DataAccess.Client.OracleConnection(ConnectionString)
            da.Fill(ds, "DTInstallInfo")


            For k As Int32 = 0 To ds.DTInstallInfo.Rows.Count - 1
                ds.DTInstallInfo.Rows(k).Item("InstallingHeaderNumber_bint") = Me.txtNumber.Text
                ds.DTInstallInfo.Rows(k).Item("SAddress_nvc") = clsDalAddress.loadAddressDesc(ds.DTInstallInfo.Rows(k).Item("SAddress_nvc").ToString())
            Next

            Dim dr As DataRow = ds.Header.NewRow
            dr.Item("BarcodeNumber_bint") = "*" + Me.txtNumber.Text + "*"
            dr.Item("Number_bint") = Me.txtNumber.Text
            dr.Item("FullName_nvc") = mhddt.Rows(0).Item("InstallerIDName_nvc")
            dr.Item("Date_vc") = DateTool.SpellDate(Now)
            ds.Header.Rows.Add(dr)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region
#End Region


End Class