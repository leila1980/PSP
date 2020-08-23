Public Class frmDeviceReAssigning
#Region "Variable Definitions"
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.dgvReAssignablePos, True, True, True, True)

    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDalPos As New ClassDALPos(modPublicMethod.ConnectionString)
    Private clsDalCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private dtReAssignablePos As New DataTable
    Private dtReAssigningPos As New DataTable
    Private dt As New DataTable
#End Region
#Region "Events"


#Region "Form"
    
    Private Sub frmDeviceAssigning_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmDeviceAssigning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            SetdgvReAssignablePos()
            Initialform()
            Me.FormLoad()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub frmDeviceAssigning_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
#End Region
#Region "Button"
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignRefresh.Click
        Try
            Me.RefreshdgvReAssignablePos()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Add()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnRePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignReprint.Click
        Dim _frmDeviceAssigningReprint As New frmDeviceAssigningReprint
        _frmDeviceAssigningReprint.ShowDialog()
    End Sub

#End Region
#Region "TextBox"
    Private Sub txtSerial_vc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial_vc.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSerial_vcKeyDown()
        End If
    End Sub
#End Region
#Region "Print"
    Private Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
        ClassPrintLabel(Of ClassDALContract).Print(e, clsDalContract)
    End Sub
#End Region
#End Region
#Region "Methods"
#Region "Form"
    Private Sub FormLoad()
        Try
            modPublicMethod.ErrorProviderClear(ErrorProvider)
            Me.FilldgvReAssignablePos()
            Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Grid"
    Private Sub FilldgvReAssignablePos()
        Try
            dtReAssignablePos = Me.clsDalContract.GetAllContractingParty_Contract_Account_Store_Device_ReAssignablePos(ClassUserLoginDataAccess.ThisUser.ProjectID)
            dgvReAssignablePos.DataSource = dtReAssignablePos
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SetdgvReAssignablePos()
        dgvReAssignablePos.AutoGenerateColumns = False

        Dim colContractID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colContractID.DataPropertyName = "ContractID"
        colContractID.HeaderText = "کد قرارداد"
        colContractID.Name = "colContractID"
        colContractID.ReadOnly = True
        colContractID.Width = 100
        Me.dgvReAssignablePos.Columns.Add(colContractID)

        Dim colFirstName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colFirstName_nvc.DataPropertyName = "FirstName_nvc"
        colFirstName_nvc.HeaderText = "نام"
        colFirstName_nvc.Name = "colFirstName_nvc"
        colFirstName_nvc.ReadOnly = True
        colFirstName_nvc.Width = 100
        Me.dgvReAssignablePos.Columns.Add(colFirstName_nvc)


        Dim colLastName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colLastName_nvc.DataPropertyName = "LastName_nvc"
        colLastName_nvc.HeaderText = "نام خانوادگی"
        colLastName_nvc.Name = "colLastName_nvc"
        colLastName_nvc.ReadOnly = True
        colLastName_nvc.Width = 150
        Me.dgvReAssignablePos.Columns.Add(colLastName_nvc)


        Dim colNationalCode_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colNationalCode_nvc.DataPropertyName = "NationalCode_nvc"
        colNationalCode_nvc.HeaderText = "کد ملی"
        colNationalCode_nvc.Name = "colNationalCode_nvc"
        colNationalCode_nvc.ReadOnly = True
        colNationalCode_nvc.Width = 100
        Me.dgvReAssignablePos.Columns.Add(colNationalCode_nvc)

        Dim colSName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSName_nvc.DataPropertyName = "SName_nvc"
        colSName_nvc.HeaderText = "نام فروشگاه"
        colSName_nvc.Name = "colSName_nvc"
        colSName_nvc.ReadOnly = True
        colSName_nvc.Width = 120
        Me.dgvReAssignablePos.Columns.Add(colSName_nvc)

        Dim colSCityName_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSCityName_nvc.DataPropertyName = "SCityName_nvc"
        colSCityName_nvc.HeaderText = "شهر"
        colSCityName_nvc.Name = "colSCityName_nvc"
        colSCityName_nvc.ReadOnly = True
        colSCityName_nvc.Width = 100
        Me.dgvReAssignablePos.Columns.Add(colSCityName_nvc)

        Dim colSAddress_nvc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSAddress_nvc.DataPropertyName = "SAddress_nvc"
        colSAddress_nvc.HeaderText = "آدرس"
        colSAddress_nvc.Name = "colSAddress_nvc"
        colSAddress_nvc.ReadOnly = True
        colSAddress_nvc.Width = 300
        Me.dgvReAssignablePos.Columns.Add(colSAddress_nvc)

        Dim colAAccountNO_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colAAccountNO_vc.DataPropertyName = "AAccountNO_vc"
        colAAccountNO_vc.HeaderText = "شماره حساب"
        colAAccountNO_vc.Name = "colAAccountNO_vc"
        colAAccountNO_vc.ReadOnly = True
        colAAccountNO_vc.Width = 100
        Me.dgvReAssignablePos.Columns.Add(colAAccountNO_vc)

        Dim colACardNo_vc As New System.Windows.Forms.DataGridViewTextBoxColumn
        colACardNo_vc.DataPropertyName = "ACardNo_vc"
        colACardNo_vc.HeaderText = "شماره کارت"
        colACardNo_vc.Name = "colACardNo_vc"
        colACardNo_vc.ReadOnly = True
        colACardNo_vc.Width = 100
        Me.dgvReAssignablePos.Columns.Add(colACardNo_vc)

        Dim colSDeviceCount_tint As New System.Windows.Forms.DataGridViewTextBoxColumn
        colSDeviceCount_tint.DataPropertyName = "SDeviceCount_tint"
        colSDeviceCount_tint.HeaderText = "تعداد پز"
        colSDeviceCount_tint.Name = "colSDeviceCount_tint"
        colSDeviceCount_tint.ReadOnly = True
        colSDeviceCount_tint.Width = 100
        Me.dgvReAssignablePos.Columns.Add(colSDeviceCount_tint)

        Dim colDDeviceID As New System.Windows.Forms.DataGridViewTextBoxColumn
        colDDeviceID.DataPropertyName = "DDeviceID"
        colDDeviceID.HeaderText = "کد دستگاه"
        colDDeviceID.Name = "colDDeviceID"
        colDDeviceID.ReadOnly = True
        colDDeviceID.Width = 100
        Me.dgvReAssignablePos.Columns.Add(colDDeviceID)

    End Sub
    Private Sub Initialform()
        Dim editButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        editButton.Button = btnReAssigningEdit
        editButton.e = New EventHandler(AddressOf btnReAssigningEdit_Click)
        editButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Edit
        editButton.ShortCut = ClassSetting.Edit_Shortcut
        Me.clsMyControler.AddButton(editButton)

        Dim saveButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        saveButton.Button = btnReAssignSave
        saveButton.e = New EventHandler(AddressOf btnReAssignSave_Click)
        saveButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Save
        saveButton.ShortCut = ClassSetting.OnlySave_Shortcut
        Me.clsMyControler.AddButton(saveButton)

        Dim cancelButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        cancelButton.Button = btnReAssignCancel
        cancelButton.e = New EventHandler(AddressOf btnReAssignCancel_Click)
        cancelButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Cancel
        cancelButton.ShortCut = ClassSetting.Cancel_Shortcut
        Me.clsMyControler.AddButton(cancelButton)

        Dim ContractID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ContractID.Control = txtContractID
        ContractID.EnabledInEditState = False
        ContractID.EnabledInViewState = False
        ContractID.MappedColumn = "colContractID"
        ContractID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(ContractID)

        Dim DDeviceID As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        DDeviceID.Control = txtDeviceID
        DDeviceID.EnabledInEditState = False
        DDeviceID.EnabledInViewState = False
        DDeviceID.MappedColumn = "colDDeviceID"
        DDeviceID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(DDeviceID)

        Dim Serial_vc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Serial_vc.Control = txtSerial_vc
        Serial_vc.EnabledInEditState = True
        Serial_vc.EnabledInViewState = False
        'DDeviceID.MappedColumn = "colDDeviceID"
        Serial_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(Serial_vc)




        Dim FirstName_nvc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        FirstName_nvc.Control = txtFirstName_nvc
        FirstName_nvc.EnabledInEditState = False
        FirstName_nvc.EnabledInViewState = False
        FirstName_nvc.MappedColumn = "colFirstName_nvc"
        FirstName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(FirstName_nvc)

        Dim LastName_nvc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        LastName_nvc.Control = txtLastName_nvc
        LastName_nvc.EnabledInEditState = False
        LastName_nvc.EnabledInViewState = False
        LastName_nvc.MappedColumn = "colLastName_nvc"
        LastName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(LastName_nvc)

        Dim SName_nvc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SName_nvc.Control = txtSName_nvc
        SName_nvc.EnabledInEditState = False
        SName_nvc.EnabledInViewState = False
        SName_nvc.MappedColumn = "colSName_nvc"
        SName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(SName_nvc)

        Dim SCityName_nvc As New RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SCityName_nvc.Control = txtSCityName_nvc
        SCityName_nvc.EnabledInEditState = False
        SCityName_nvc.EnabledInViewState = False
        SCityName_nvc.MappedColumn = "colSCityName_nvc"
        SCityName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        Me.clsMyControler.AddControl(SCityName_nvc)




        Me.clsMyControler.DataGridView = Me.dgvReAssignablePos

    End Sub

    Private Sub RefreshdgvReAssignablePos()
        Try
            modPublicMethod.ErrorProviderClear(ErrorProvider)
            Me.FilldgvReAssignablePos()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
#Region "TextBox"
    Private Sub txtSerial_vcKeyDown()
        Try
            clsDalPos.BeginProc()
            Me.FillTextBoxes()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        Finally
            clsDalPos.EndProc()
        End Try
    End Sub
    Private Sub FillTextBoxes()
        clsDalPos.Serial_vc = txtSerial_vc.Text.Trim
        dt.Clear()
        dt = clsDalPos.GetBySerialPos()
        If dt.Rows.Count > 0 Then
            ErrorProvider.SetError(txtSerial_vc, "")
            txtPosID.Text = dt.Rows(0).Item("PosID")
            txtPropertyNo_vc.Text = dt.Rows(0).Item("PropertyNo_vc")
            txtEniacCode_vc.Text = dt.Rows(0).Item("EniacCode_vc")
        Else
            ErrorProvider.SetError(txtSerial_vc, " سریال وارد شده نامعتبر می باشد ")
            txtPosID.Text = ""
            txtPropertyNo_vc.Text = ""
            txtEniacCode_vc.Text = ""
        End If
    End Sub
    Private Function RequiredDBValidator() As Boolean
        Dim res As Boolean = True
        Try
            If SerialValidate() = False Then
                ErrorProvider.SetError(txtSerial_vc, "سریال وارد شده در سیستم موجود نمی باشد")
                res = False
                Exit Function
            Else
                If clsDalPos.Active_Tint <> 1 Then
                    ErrorProvider.SetError(txtSerial_vc, "سریال وارد شده فعال نمی باشد")
                    res = False
                    Exit Function
                Else
                    ErrorProvider.SetError(txtSerial_vc, "")
                End If
            End If

            clsDalContract.DPosID = clsDalPos.PosID

            If Convert.ToInt64(txtPosID.Text) <> clsDalContract.DPosID Then
                ErrorProvider.SetError(txtSerial_vc, "سریال وارد شده با مشخصات آن همخوانی ندارد")
                res = False
                Exit Function
            Else
                ErrorProvider.SetError(txtSerial_vc, "")
            End If

            dt.Clear()
            dt = clsDalContract.GetByPosIDDevice(clsDalContract.DPosID)
            If dt.Rows.Count > 0 Then
                ErrorProvider.SetError(txtSerial_vc, " سریال وارد شده قبلا تخصیص داده شده است ")
                res = False
                Exit Function
            Else
                ErrorProvider.SetError(txtSerial_vc, "")
            End If


        Catch ex As Exception
            res = False
            Throw ex
        Finally
            RequiredDBValidator = res
        End Try

    End Function
    Private Sub FillPosTextBoxes()
        txtPosID.Text = clsDalPos.PosID
        txtPropertyNo_vc.Text = clsDalPos.PropertyNo_vc
        txtEniacCode_vc.Text = clsDalPos.EniacCode_vc
    End Sub
    Private Sub EmptyTextBoxes()
        txtContractID.Text = ""
        txtDeviceID.Text = ""
        txtSerial_vc.Text = ""
        txtPosID.Text = ""
        txtEniacCode_vc.Text = ""
        txtPropertyNo_vc.Text = ""
    End Sub
#End Region
#Region "Checking"
    Private Function SerialValidate() As Boolean
        Try
            SerialValidate = False
            Dim dt As New DataTable

            clsDalPos.Serial_vc = txtSerial_vc.Text.Trim
            dt.Clear()
            dt = clsDalPos.GetBySerialPos()
            If dt.Rows.Count > 0 Then
                SerialValidate = True
                clsDalPos.PosID = dt.Rows(0).Item("PosID")
                clsDalPos.PropertyNo_vc = dt.Rows(0).Item("PropertyNo_vc")
                clsDalPos.EniacCode_vc = dt.Rows(0).Item("EniacCode_vc")
                clsDalPos.Active_Tint = dt.Rows(0).Item("Active_tint")
                FillPosTextBoxes()
            Else
                SerialValidate = False
                clsDalPos.PosID = -1
                clsDalPos.PropertyNo_vc = ""
                clsDalPos.EniacCode_vc = ""
                clsDalPos.Active_Tint = -1
                FillPosTextBoxes()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   
#End Region
#Region "Save"
    Private Sub Save()
        Try
            clsDalContract.DPPosID = Convert.ToInt64(txtPosID.Text)
            clsDalContract.DPDeviceID = Convert.ToInt64(txtDeviceID.Text)
            clsDalContract.DPIOTypeID = 1
            Me.SaveDevicePos()
            Me.UpdateDeviceForOnlyPosID()
            Me.UpdateContractImportDeviceID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveDevicePos()
        Try
            clsDalContract.InsertDevicePos()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UpdateDeviceForOnlyPosID()
        Try
            clsDalContract.UpdateDevice_OnlyPosID(clsDalContract.DPPosID, clsDalContract.DPDeviceID, True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UpdateContractImportDeviceID()
        Try
            clsDalContract.UpdateContractImportDeviceID(clsDalContract.DDeviceID, clsDalContract.ContractID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Private Sub PosAssign()
    '    Try
    '        Me.SaveDevice()
    '        Me.SaveDevicePos()
    '        Me.UpdateDeviceForOnlyPosID()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub SaveDevice()
    '    Try
    '        clsDalContract.DPDeviceID = clsDalContract.InsertDevice()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub SaveDevicePos()
    '    Try
    '        clsDalContract.InsertDevicePos()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub UpdateDeviceForOnlyPosID()
    '    Try
    '        clsDalContract.UpdateDevice_OnlyPosID(clsDalContract.DPPosID, clsDalContract.DPDeviceID)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
#Region "Set Get"
    'Private Sub SetCodes(ByVal dt As DataTable)
    '    Try
    '        Dim MCC As String
    '        Dim MerchantSerial As String = ""
    '        Dim OutletSerial As String = ""
    '        Dim VatSerial As String = ""
    '        Dim CodeSerial As String = ""
    '        MCC = dt.Rows(0).Item("SGroupID").ToString.Trim
    '        Me.GetTheLatestDevice(MerchantSerial, OutletSerial, VatSerial, CodeSerial)
    '        clsDalContract.DMerchant_vc = dt.Rows(0).Item("SCityID").ToString.Remove(0, 1) + MCC + MerchantSerial '****/****/****
    '        clsDalContract.DVat_vc = dt.Rows(0).Item("SStateID").ToString.Remove(0, 1) + dt.Rows(0).Item("SCityID").ToString.Remove(0, 1) + GetAPartOfString(dt.Rows(0).Item("Date_vc").ToString, 2, 2) + GetAPartOfString(dt.Rows(0).Item("Date_vc").ToString, 5, 2) + PSP + VatSerial '**/****/**/**/*/****
    '        clsDalContract.DOutlet_vc = dt.Rows(0).Item("SStateID").ToString.Remove(0, 1) + MCC + PSP + OutletSerial '****/**/*/*****
    '        clsDalContract.DCode_vc = dt.Rows(0).Item("SStateID").ToString.Remove(0, 1) + PSP + CodeSerial '**/*/*****
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub SetCodes(ByVal dt As DataTable)
    '    Try
    '        Dim MCC, SCityID, SStateID, Date_vcYear, Date_vcMonth As String
    '        Dim SStoreID As Int64
    '        MCC = dt.Rows(0).Item("SGroupID").ToString.Trim
    '        SCityID = dt.Rows(0).Item("SCityID").ToString.Remove(0, 1)
    '        SStateID = dt.Rows(0).Item("SStateID").ToString.Remove(0, 1)
    '        Date_vcYear = GetAPartOfString(dt.Rows(0).Item("Date_vc").ToString, 2, 2)
    '        Date_vcMonth = GetAPartOfString(dt.Rows(0).Item("Date_vc").ToString, 5, 2)
    '        SStoreID = dt.Rows(0).Item("SStoreID")

    '        clsDalContract.DMerchant_vc = GetMerchant(SCityID, MCC, SStoreID) '****/****/****
    '        clsDalContract.DVat_vc = GetVat(SStateID, SCityID, Date_vcYear, Date_vcMonth, PSP, SStoreID) '**/****/**/**/*/****
    '        clsDalContract.DOutlet_vc = GetOutlet(SStateID, MCC, PSP) '****/**/*/*****
    '        clsDalContract.DCode_vc = GetCode(SStateID, PSP) '**/*/*****

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private Function GetMerchant(ByVal SCityID As String, ByVal MCC As String, ByVal SStoreID As Int64) As String
        Dim Counter As Int32
        Dim strCounter As String
        Dim Count As Int32
        Dim MerchantFirstPart As String
        Dim Merchant As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        MerchantFirstPart = SCityID + MCC
        dt1 = clsDalContract.GetBYMerchantDevice_LIKE(MerchantFirstPart)
        Counter = 0
        While True
            Counter += 1
            strCounter = Microsoft.VisualBasic.Right("0000" + Counter.ToString, 4)
            Merchant = MerchantFirstPart + strCounter
            dt2 = clsDalContract.GetBYMerchantDevice_LIKE(Merchant)
            If dt2.Rows.Count = 0 Then
                Return Merchant
            End If
            Dim dr() As DataRow = dt2.Select("StoreID=" + SStoreID.ToString)
            If dr.Length > 0 Then
                Return Merchant
            End If
        End While

    End Function
    Private Function GetVat(ByVal SStateID As String, ByVal SCityID As String, ByVal Date_vcYear As String, ByVal Date_vcMonth As String, ByVal PSP As String, ByVal SStoreID As Int64) As String
        Dim Counter As Int32
        Dim strCounter As String
        Dim Count As Int32
        Dim VatFirstPart As String
        Dim Vat As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        VatFirstPart = SStateID + SCityID + Date_vcYear + Date_vcMonth + PSP
        dt1 = clsDalContract.GetBYVatDevice_LIKE(VatFirstPart)
        Counter = 0
        While True
            Counter += 1
            strCounter = Microsoft.VisualBasic.Right("0000" + Counter.ToString, 4)
            Vat = VatFirstPart + strCounter
            dt2 = clsDalContract.GetBYVatDevice_LIKE(Vat)
            If dt2.Rows.Count = 0 Then
                Return Vat
            End If
            Dim dr() As DataRow = dt2.Select("StoreID=" + SStoreID.ToString)
            If dr.Length > 0 Then
                Return Vat
            End If
        End While

    End Function
    Private Function GetOutlet(ByVal SStateID As String, ByVal MCC As String, ByVal PSP As String) As String
        Dim Counter As Int32
        Dim strCounter As String
        Dim OutletFirstPart As String
        Dim Outlet As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        OutletFirstPart = SStateID + MCC + PSP
        dt1 = clsDalContract.GetBYOutletDevice_LIKE(OutletFirstPart)
        Counter = 0
        While True
            Counter += 1
            strCounter = Microsoft.VisualBasic.Right("00000" + Counter.ToString(), 5)
            Outlet = OutletFirstPart + strCounter
            dt2 = clsDalContract.GetBYOutletDevice_LIKE(Outlet)
            If dt2.Rows.Count = 0 Then
                Return Outlet
            End If
        End While
    End Function
    Private Function GetCode(ByVal SStateID As String, ByVal PSP As String) As String
        Dim Counter As Int32
        Dim strCounter As String

        Dim CodeFirstPart As String
        Dim Code As String
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        CodeFirstPart = SStateID + PSP
        dt1 = clsDalContract.GetBYCodeDevice_LIKE(CodeFirstPart)
        Counter = 0
        While True
            Counter += 1
            strCounter = Microsoft.VisualBasic.Right("00000" + Counter.ToString(), 5)
            Code = CodeFirstPart + strCounter
            dt2 = clsDalContract.GetBYCodeDevice_LIKE(Code)
            If dt2.Rows.Count = 0 Then
                Return Code
            End If
        End While
    End Function
    Private Sub GetTheLatestDevice(ByRef MerchantSerial As String, ByRef OutletSerial As String, ByRef VatSerial As String, ByRef CodeSerial As String)
        Try
            Dim lngMerchantSerial As Long
            Dim lngOutletSerial As Long
            Dim lngVatSerial As Long
            Dim lngCodeSerial As Long

            Dim dt As New DataTable

            dt = clsDalContract.GetTheLatestDevice()
            If dt.Rows.Count > 0 Then
                If clsDalContract.SStoreID <> 0 Then
                    '===
                    If dt.Rows(0).Item("StoreID") = clsDalContract.SStoreID Then
                        MerchantSerial = GetAPartOfString(dt.Rows(0).Item("Merchant_vc"), dt.Rows(0).Item("Merchant_vc").ToString.Length - 4, 4)
                        VatSerial = GetAPartOfString(dt.Rows(0).Item("Vat_vc"), dt.Rows(0).Item("Vat_vc").ToString.Length - 4, 4)
                    Else
                        MerchantSerial = GetAPartOfString(dt.Rows(0).Item("Merchant_vc"), dt.Rows(0).Item("Merchant_vc").ToString.Length - 4, 4)
                        VatSerial = GetAPartOfString(dt.Rows(0).Item("Vat_vc"), dt.Rows(0).Item("Vat_vc").ToString.Length - 4, 4)

                        lngMerchantSerial = Convert.ToInt64(MerchantSerial) + 1
                        lngVatSerial = Convert.ToInt64(VatSerial) + 1

                        MerchantSerial = Microsoft.VisualBasic.Right("0000" + lngMerchantSerial.ToString, 4)
                        VatSerial = Microsoft.VisualBasic.Right("0000" + lngVatSerial.ToString(), 4)
                    End If
                    OutletSerial = GetAPartOfString(dt.Rows(0).Item("Outlet_vc"), dt.Rows(0).Item("Outlet_vc").ToString.Length - 5, 5)
                    CodeSerial = GetAPartOfString(dt.Rows(0).Item("Code_vc"), dt.Rows(0).Item("Code_vc").ToString.Length - 5, 5)

                    lngOutletSerial = Convert.ToInt64(OutletSerial) + 1
                    lngCodeSerial = Convert.ToInt64(CodeSerial) + 1

                    OutletSerial = Microsoft.VisualBasic.Right("00000" + lngOutletSerial.ToString(), 5)
                    CodeSerial = Microsoft.VisualBasic.Right("00000" + lngCodeSerial.ToString(), 5)

                    '===
                Else
                    MerchantSerial = ""
                    OutletSerial = ""
                    VatSerial = ""
                    CodeSerial = ""
                End If
            Else
                MerchantSerial = "0001"
                OutletSerial = "00001"
                VatSerial = "0001"
                CodeSerial = "00001"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
#End Region
#Region "Add"
    Private Sub Add()
        Me.EmptyTextBoxes()
        Me.RefreshdgvReAssignablePos()
    End Sub
#End Region
#Region "Print"
    Private Sub PrintLabel()
        Try
            'ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_PoseCode_Outlet
            'PrintDocument.Print()
            ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_StoreName
            PrintDocument.Print()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#Region "RePrint"
    Private Sub MustRePrint()
        'Try
        '    If MessageBox.Show("آیا مایل به چاپ مجدد می باشید ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '        Exit Sub
        '    End If
        '    clsDalContract.BeginProc()
        '    clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
        '    dtAssigningPos = clsDalContract.GetByContractIDSerialCountContractingParty_Contract_Account_Store_Device_Device_Pos_DevicePos_PURE(txtSerial_vc.Text.Trim, 1)
        '    If dtAssigningPos.Rows.Count > 0 Then
        '        clsDalContract.DOutlet_vc = dtAssigningPos.Rows(0).Item("DOutlet_vc")
        '        clsDalContract.DCode_vc = dtAssigningPos.Rows(0).Item("DCode_vc")
        '        clsDalContract.SName_nvc = dtAssigningPos.Rows(0).Item("SName_nvc")
        '        clsDalContract.FirstName_nvc = dtAssigningPos.Rows(0).Item("FirstName_nvc")
        '        clsDalContract.LastName_nvc = dtAssigningPos.Rows(0).Item("LastName_nvc")
        '        Me.RePrintLabel()
        '        Me.EmptyTextBoxes()
        '    Else
        '        ShowErrorMessage("اطلاعات وارد شده نامعتبر می باشد")
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'Finally
        '    clsDalContract.EndProc()
        'End Try
    End Sub
    Private Sub RePrintLabel()
        ''Try
        ''    ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_PoseCode_Outlet
        ''    m_pd.Print()
        ''    ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_StoreName
        ''    m_pd.Print()
        ''Catch ex As Exception
        ''    Throw ex
        ''End Try
        'If txtContractID.Text.Trim <> "" Then
        '    Try
        '        Dim dt As New DataTable
        '        ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID_StoreName
        '        PrintDocument.Print()
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Me.clsDalContract.EndProc()
        '    End Try
        'Else
        '    Throw New KeyNotFoundException
        'End If
    End Sub
#End Region
#End Region
#End Region
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssignDelete.Click
        'Dim _frmDeleteDeviceAssigning As New frmDeleteDeviceAssigning
        '_frmDeleteDeviceAssigning.ShowDialog()
        'Me.RefreshdgvReAssignablePos()
    End Sub

    'Private Sub dgvAssignablePos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAssignablePos.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Try
    '            Me.Save()
    '        Catch ex As Exception
    '            modPublicMethod.ShowErrorMessage(ex.Message)
    '            ClassError.LogError(ex)
    '        End Try
    '    End If
    'End Sub

    Private Sub frmDeviceAssigning_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'ClassBLLFormHistory.InsertToHistory(Me)
    End Sub

    Private Sub btnExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportToExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.dgvReAssignablePos)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvReAssignablePos.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(Me.dgvReAssignablePos.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReAssignablePos.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReAssignablePos.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, dgvReAssignablePos.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.dgvReAssignablePos.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub
    Private Sub btnReAssigningEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReAssigningEdit.Click
        Try
            Edit()
        Catch ex As Exception
            ClassError.LogError(ex)
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnReAssignSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReAssignSave.Click
        Try
            btnReAssignSaveClick()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnReAssignSaveClick()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        Try
            clsDalPos.BeginProc()
            clsDalContract.BeginProc()
            If RequiredValidator() = False Then
                Exit Sub
            End If
            If RequiredDBValidator() = False Then
                Exit Sub
            End If
            Save()

            FilldgvReAssignablePos()
            Me.clsMyControler.DataGridView = dgvReAssignablePos
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            dgvReAssignablePos.Focus()
            ViewState()


            clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
            clsDalContract.SCityname_nvc = txtSCityName_nvc.Text.Trim
            clsDalContract.FirstName_nvc = txtFirstName_nvc.Text.Trim
            clsDalContract.LastName_nvc = txtLastName_nvc.Text.Trim
            clsDalContract.SName_nvc = txtSName_nvc.Text.Trim
            PrintLabel()


        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        Finally
            clsDalContract.EndProc()
            clsDalPos.EndProc()
        End Try
    End Sub
    Private Sub ViewState()
        txtSerial_vc.Text = ""
        txtPosID.Text = ""
        txtPropertyNo_vc.Text = ""
        txtEniacCode_vc.Text = ""
    End Sub
    Private Sub btnReAssignCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReAssignCancel.Click
        Try
            Cancel()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub Edit()
        Try
            clsMyControler.DataGridView = dgvReAssignablePos
            clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True

        If txtSerial_vc.Text.Trim = "" Then
            ErrorProvider.SetError(txtSerial_vc, "شماره سریال پز وارد نشده است")
            res = False
        Else
            ErrorProvider.SetError(txtSerial_vc, "")
        End If
        If txtDeviceID.Text.Trim = "" Then
            ErrorProvider.SetError(txtDeviceID, " کد دستگاه وارد نشده است")
            res = False
        Else
            ErrorProvider.SetError(txtDeviceID, "")
        End If

        Return res
    End Function
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)

        Me.clsMyControler.DataGridView = dgvReAssignablePos
        Me.clsMyControler.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.dgvReAssignablePos.Focus()
        ViewState()
    End Sub

    Private Sub dgvReAssignablePos_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReAssignablePos.RowEnter
        RowEnter(e.RowIndex)
    End Sub
    Private Sub RowEnter(ByVal Rowindex As Int32)
        Me.clsMyControler.DataGridView = Me.dgvReAssignablePos
        Me.clsMyControler.SetControlsValue(Rowindex)
    End Sub

End Class