Option Explicit On
Option Compare Binary

Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports log4net
Imports Convertor

Public Class frmContractingparty_Contract_Account_Store_Device
    Dim myConStr As New ClassConnectionSpliter()
    Dim connect As Boolean = False
    Dim Logger As ILog = log4net.LogManager.GetLogger(GetType(frmContractingparty_Contract_Account_Store_Device))
#Region "Variable Definitions"
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDALBasicTypes As New ClassDALBasicTypes(modPublicMethod.ConnectionString)
    Private clsDALState As New ClassDALState(modPublicMethod.ConnectionString)
    Private clsDALCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private clsDALBranch As New ClassDALBranch(modPublicMethod.ConnectionString)
    Private clsDALGroup As New ClassDALGroup(modPublicMethod.ConnectionString)
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
    Private clsDalAddress As New ClassDalAddress(modPublicMethod.ConnectionString)
    Private clsdalPos As New ClassDALPos(modPublicMethod.ConnectionString)

    Dim clsContractAndCMS As New ClassContractAndCMS(ConnectionString)
    Dim clsCMSProject As New ClassCMSProject(0, "", False, "")
    Private clsMyControlerContractingParty As New RIZNARM.WINDOWS.FORMS.ClassFormController(dgvContractingParty_Contract, True, True, True, True)
    Private clsMyControlerAccount As New RIZNARM.WINDOWS.FORMS.ClassFormController(dgvAccount, True, True, True, True)
    Private clsMyControlerStore As New RIZNARM.WINDOWS.FORMS.ClassFormController(dgvStore, True, True, True, True)

    Private dtContractingParty_Contract As New DataTable
    Private dtAccount As New DataTable
    Private dtStore As New DataTable
    Private dtStoreTel As New DataTable
    Private dtDevice As New DataTable
    Private dtDeviceCrash As DataTable

    Private mvarContractingPartyID As Int64
    Private mvarContractID As Int64
    Private mvarStoreID As Int64
    Private mvarStoreTelID As Int64
    Private mvarDeviceID As Int64

    Private OldShebaAccount As String = Nothing
    Private CurrentShebaAccount As String = Nothing


    Private clsDalAccess As New ClassDALAccessSwitch
    Private PSP As String = "5"

    Private blnForcePrint As Boolean = False

    Public SearchingContractID As Int32 = 0
    Private dvDevice_Pos As DataView
    Private dvAccount As DataView
    Private dvDeviceCrash_Pos As DataView


    'Private StoreName_Before As String
    'Private StoreAddress_Before As String
    'Private StorePostCode_Before As String
    'Private StoreStateID_Before As String
    'Private StoreCityID_Before As String
    'Private StoreTel1_Before As String
    'Private StoreTel2_Before As String
    'Private StoreFax_Before As String
    'Private Email_Before As String

    'Private StoreName_After As String
    'Private StoreAddress_After As String
    'Private StorePostCode_After As String
    ''Private StoreStateName_After As String
    ''Private StoreCityName_After As String
    'Private StoreTel1_After As String
    'Private StoreTel2_After As String
    'Private StoreFax_After As String
    'Private Email_After As String

    'Private StoreName_Change As Boolean
    'Private StoreAddress_Change As Boolean
    'Private StorePostCode_Change As Boolean
    ''Private StoreStateName_Change As Boolean
    ''Private StoreCityName_Change As Boolean
    'Private StoreTel1_Change As Boolean
    'Private StoreTel2_Change As Boolean
    'Private StoreFax_Change As Boolean
    'Private Email_Change As Boolean

    Private Enum SearchItemsEnum As Short
        NationalCode = 0
        LastName = 1
        ContractID = 2
        ContractNo = 3
        Merchant = 4
        Date_vc = 5
        SaveDate = 6
        RequestID = 7
        Outlet = 8
    End Enum

#End Region
#Region "Property"


    Public Property ContractingPartyID() As Int64
        Get
            Return mvarContractingPartyID
        End Get
        Set(ByVal value As Int64)
            mvarContractingPartyID = value
        End Set
    End Property
    Public Property ContractID() As Int64
        Get
            Return mvarContractID
        End Get
        Set(ByVal value As Int64)
            mvarContractID = value
        End Set
    End Property
    Public Property StoreID() As Int64
        Get
            Return mvarStoreID
        End Get
        Set(ByVal value As Int64)
            mvarStoreID = value
        End Set
    End Property
    Public Property StoreTelID() As Int64
        Get
            Return mvarStoreTelID
        End Get
        Set(ByVal value As Int64)
            mvarStoreTelID = value
        End Set
    End Property
    Public Property DeviceID() As Int64
        Get
            Return mvarDeviceID
        End Get
        Set(ByVal value As Int64)
            mvarDeviceID = value
        End Set
    End Property
#End Region
#Region "Events"
#Region "Form"
    Private Sub frmContract_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
            Me.clsMyControlerContractingParty.Key(sender, e)
        ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
            Me.clsMyControlerStore.Key(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub frmContract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            SetPermission(clsMyControlerAccount, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.SetCheckListItems()
            Me.InitControls()
            Me.FormLoad()
        Catch ex As Exception
            ' modPublicMethod.ShowErrorMessage(ex.Message) 'modApplicationMessage.msgLoadFailed
            ClassError.LogError(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub frmContract_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmMain.SetFavorite()
    End Sub
#End Region
#Region "TabPage"
    Private Sub tbc_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tbc.Selecting
        tbcSelecting(sender, e)
    End Sub
    Private Sub tbpContractingParty_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbpContractingParty.Enter
        tbpContractingPartyEnter(sender)
        SetPermission(clsMyControlerAccount, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
    End Sub
    Private Sub tbpAccount_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbpAccount.Enter
        tbpAccountEnter(sender)
        SetPermission(clsMyControlerAccount, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
    End Sub

    Private Sub tbpStore_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbpStore.Enter
        tbpStoreEnter(sender)
        SetPermission(clsMyControlerAccount, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
    End Sub
    Private Sub tbpDevice_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbpDevice.Enter
        tbpDeviceEnter(sender)
        SetPermission(clsMyControlerAccount, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
    End Sub
    Private Sub tbc_Deselecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tbc.Deselecting
        If e.TabPageIndex = 3 Then
            tsMain.Enabled = True
        End If
    End Sub

#End Region
#Region "Grids"
    Private Sub dgvContractingParty_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContractingParty_Contract.RowEnter
        Try

            If e.RowIndex >= 0 Then
                dgvContractingParty_ContractRowEnter(e.RowIndex)
            End If

        Catch ex As Exception
            Me.dtAccount.DefaultView.RowFilter = ""
        End Try
    End Sub
    Private Sub dgvAccount_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAccount.RowEnter
        Try
            dgvAccountRowEnter(e.RowIndex)
        Catch ex As Exception
            Me.dtStore.DefaultView.RowFilter = ""
        End Try
    End Sub
    Private Sub dgvStore_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStore.RowEnter
        Try
            dgvStoreRowEnter(e.RowIndex)
            If Not String.IsNullOrEmpty(dgvStore.Rows(e.RowIndex).Cells("colSnewAddress_nvc").Value.ToString) Then
                newtxtSAddress_nvc.Text = clsDalAddress.loadAddressDesc(dgvStore.Rows(e.RowIndex).Cells("colSnewAddress_nvc").Value.ToString)
            Else
                newtxtSAddress_nvc.Text = Nothing
            End If
        Catch ex As Exception
            Me.dtDevice.DefaultView.RowFilter = ""
        End Try
    End Sub
    Private Sub dgvDevice_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            dgvDeviceRowEnter(e.RowIndex)
        Catch ex As Exception
            ShowMessage(ex.ToString)
        End Try
    End Sub
    Private Sub dgvContractingParty_Contract_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvContractingParty_Contract.DoubleClick
        SelectAccountTab()
    End Sub
    Private Sub dgvAccount_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvAccount.DoubleClick
        SelectStoreTab()
    End Sub
    Private Sub dgvStore_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvStore.DoubleClick
        SelectDeviceTab()
    End Sub
#End Region
#Region "Radios"
    Private Sub rdoHavingAccount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoYesHavingAccount_bit.CheckedChanged, rdoNoHavingAccount_bit.CheckedChanged
        rdoHavingAccountCheckedChanged()
    End Sub
    Private Sub rdoHavingAccountCheckedChanged()
        If rdoYesHavingAccount_bit.Checked = False Then
            rdoNoHavingAccount_bit.Checked = True
        End If
        If Me.clsMyControlerContractingParty.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add Or Me.clsMyControlerContractingParty.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit Then
            If rdoYesHavingAccount_bit.Checked = True Then
                cboAccountTypeID.Enabled = True
                txtAccountNO_vc.Enabled = True
                txtShabaAccount.Enabled = True
                txtCardNo_vc.Enabled = True
                lblAccountTypeID.Enabled = True
                cboBranchID.Enabled = True
                lbBranchID.Enabled = True
            ElseIf rdoNoHavingAccount_bit.Checked = True Then
                cboAccountTypeID.Enabled = False
                txtAccountNO_vc.Enabled = False
                txtShabaAccount.Enabled = False
                txtCardNo_vc.Enabled = False
                lblAccountTypeID.Enabled = False
                cboBranchID.Enabled = False
                lbBranchID.Enabled = False

            End If
        End If
    End Sub
    Private Sub rdoMaleGender_bit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMaleGender_bit.CheckedChanged
        If rdoMaleGender_bit.Checked = False Then
            rdoFemaleGender_bit.Checked = True
        End If
    End Sub
#End Region
#Region "Textboxes"
    Private Sub TextboxEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstName_nvc.Enter, txtLastName_nvc.Enter, txtFatherName_nvc.Enter, txtHomeAddress_nvc.Enter, txtSName_nvc.Enter, txtSAddress_nvc.Enter, txtEmail_nvc.Enter, cboTitle_nvc.Enter
        ChooseCulture(sender)
    End Sub
    Private Sub txtVisitorID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVisitorID.TextChanged
        txtVisitorIDTextChanged()
    End Sub
    Private Sub txtVisitorIDTextChanged()
        If txtVisitorID.Text.Trim = "" Then
            txtVisitorFullName.Text = ""
        End If
    End Sub
    Private Sub txtVisitorID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVisitorID.KeyDown
        If e.KeyCode = Keys.Enter AndAlso txtVisitorID.Text.Trim <> "" Then
            Dim VisitorFullName As String
            If CheckVisitorID(Convert.ToInt32(txtVisitorID.Text), VisitorFullName) = False Then
                ErrorProvider.SetError(txtVisitorID, modApplicationMessage.msgInvalidID)
            Else
                ErrorProvider.SetError(txtVisitorID, "")
            End If
            txtVisitorFullName.Text = VisitorFullName
        End If
    End Sub
    Private Sub dtxtDate_vc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtxtDate_vc.Leave
        SetContractNo_Merchant(False)
        FillContractNo_MerchantTextBox()
    End Sub
    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If

    End Sub
#End Region
#Region "Buttons"
    Private Sub SetLinkBtn(ByVal t As System.Windows.Forms.TabPage)
        If t Is Me.tbpContractingParty Then
            lblVisitorID.Text = "بازار یاب :"
            lblAccountTypeID.Text = "نوع حساب :"
            lblCIdentityTypeID.Text = "مدرک شناسایی :"
            lblDegreeID.Text = "مدرک تحصیلی :"
            lbBranchID.Text = "نام شعبه :"
        ElseIf t Is Me.tbpAccount Then
            lblAAccountTypeID.Text = "نوع حساب :"
            lblABranchID.Text = "نام شعبه :"
        ElseIf t Is Me.tbpStore Then
            lblSGroupID.Text = "صنف :"
            lblSSIdentityTypeID.Text = "مدرک شناسایی :"
            lblSEstateConditionID.Text = "وضعیت تملک :"
            lblSADDRESS.Text = "آدرس :"
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Add()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgAddFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            Edit()
        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            'Delete()
        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Cancel()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgAddFailed)
        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Search()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            'PrintLabel()
            'ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID
            'PrintDocument.Print()

            printPasargadContract()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgPrintFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshForm()
    End Sub
#End Region
#Region "Combos"
    Private Sub cboSearchBy_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchBy.EnabledChanged
        btnSearch.Enabled = cboSearchBy.Enabled
    End Sub

    Private Sub cboStateID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStateID.SelectedIndexChanged
        Try
            FillcboCityID(sender)
        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub cboSStateID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSStateID.SelectedIndexChanged
        Try
            FillcboCityID(sender)
        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
    End Sub


    Private Sub cboSSIdentityTypeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSSIdentityTypeID.SelectedIndexChanged
        Try
            If cboSSIdentityTypeID.Text.IndexOf("اجاره") > -1 Then
                If Me.clsMyControlerStore.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add OrElse Me.clsMyControlerStore.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit Then
                    EnableSIdentityTypeDate(True)
                    dtxtSSIdentityTypeSDate_vc.Focus()
                Else
                    EnableSIdentityTypeDate(False)
                End If
            Else
                EnableSIdentityTypeDate(False)
                dtxtSSIdentityTypeSDate_vc.Value = ""
                dtxtSSIdentityTypeEDate_vc.Value = ""
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try

    End Sub
    Private Sub EnableSIdentityTypeDate(ByVal bln As Boolean)
        dtxtSSIdentityTypeSDate_vc.Enabled = bln
        dtxtSSIdentityTypeEDate_vc.Enabled = bln
    End Sub

    Private Sub cboSGroupID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSGroupID.SelectedIndexChanged
        Try
            Me.FillcboLicense(sender)
            Me.FillcboSupplementary(sender)
        Catch ex As Exception
            ClassError.LogError(ex)
        End Try
    End Sub

#End Region
#Region "LinkLabels"
    Private Sub lblCIdentityTypeID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCIdentityTypeID.LinkClicked
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.CIdentityType
        _frmBasicTypes.ShowDialog()
        ChooseCIdentityTypeID(_frmBasicTypes)
        cboCIdentityTypeID.Focus()
    End Sub
    Private Sub lblSSADDRESS_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblSADDRESS.LinkClicked
        Dim _frmAddress As New frmAddress(Me)
        _frmAddress.ACode = newtxtSAddressCode_nvc.Text

        If _frmAddress.ShowDialog() = DialogResult.OK Then
            newtxtSAddress_nvc.Text = Nothing
            newtxtSAddress_nvc.Text = _frmAddress.Names
            newtxtSAddressCode_nvc.Text = _frmAddress.Code
            newtxtSAddress_nvc.SelectAll()
            '  MessageBox.Show("آدرس جدید :" & vbCrLf & newtxtSAddress_nvc.Text.ToString)
        End If
        modPublicMethod.SelectAText(newtxtSAddress_nvc)
    End Sub
    Private Sub lblSSIdentityTypeID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblSSIdentityTypeID.LinkClicked
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.SIdentityType
        _frmBasicTypes.ShowDialog()
        ChooseSSIdentityTypeID(_frmBasicTypes)
        cboSSIdentityTypeID.Focus()
    End Sub
    Private Sub lblDegreeID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblDegreeID.LinkClicked
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.Degree
        _frmBasicTypes.ShowDialog()
        ChooseDegreeID(_frmBasicTypes)
        cboDegreeID.Focus()
    End Sub
    Private Sub lblAccountTypeID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAccountTypeID.LinkClicked
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.AccountType
        _frmBasicTypes.ShowDialog()
        ChooseAccountTypeID(_frmBasicTypes)
        cboAccountTypeID.Focus()
    End Sub
    Private Sub lblAAccountTypeID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAAccountTypeID.LinkClicked
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.AccountType
        _frmBasicTypes.ShowDialog()
        ChooseAAccountTypeID(_frmBasicTypes)
        cboAAccountTypeID.Focus()
    End Sub
    Private Sub lblSEstateConditionID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblSEstateConditionID.LinkClicked
        Dim _frmBasicTypes As New frmBasicTypes
        _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.EstateCondition
        _frmBasicTypes.ShowDialog()
        ChooseSEstateConditionID(_frmBasicTypes)
        cboSEstateConditionID.Focus()
    End Sub
    Private Sub lblVisitorID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblVisitorID.LinkClicked
        Dim _frmVisitor As New frmVisitor
        _frmVisitor.ShowDialog()
        ChooseVisitor(_frmVisitor)
        modPublicMethod.SelectAText(txtFirstName_nvc)
    End Sub
    Private Sub lblSGroupID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblSGroupID.LinkClicked
        Dim _frmGroup As New frmGroup
        _frmGroup.ShowDialog()
        ChooseGroupID(_frmGroup)
        cboSGroupID.Focus()
    End Sub
    Private Sub lbBranchID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbBranchID.LinkClicked
        Dim _frmBranch As New frmBranch
        _frmBranch.isOpeningFromContract = True
        _frmBranch.ShowDialog()
        ChooseBranchID(_frmBranch)
        cboBranchID.Focus()
        _frmBranch.isOpeningFromContract = False
    End Sub
    Private Sub lblABranchID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblABranchID.LinkClicked
        Dim _frmBranch As New frmBranch
        _frmBranch.ShowDialog()
        ChooseABranchID(_frmBranch)
        cboABranchID.Focus()
    End Sub
    Private Sub lblImageScan_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim frm As New frmScan2()
        If Me.txtContractID.Text.Trim <> String.Empty Then
            frm.ContractId = Me.txtContractID.Text
            frm.ShowDialog()
        Else
            ShowErrorMessage("شماره قرارداد خالی است ")
        End If
    End Sub
    Private Sub lblImageShow_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblImageShow.LinkClicked
        Dim frm As New frmShowDocImage
        If Me.txtContractID.Text.Trim <> String.Empty Then
            frm.ContractId = Me.txtContractID.Text
            frm.ShowDialog()
        Else
            ShowErrorMessage("شماره قرارداد خالی است ")
        End If
    End Sub
#End Region
#Region "PrintDocument"
    Private Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage
        ClassPrintLabel(Of ClassDALContract).Print(e, clsDalContract)
        'Dim g As Graphics = e.Graphics
        'Dim Barcodeheight As Integer = 50
        'Dim X1 As Integer
        'Dim Y1 As Integer

        'Select Case PrintLabelType
        '    Case PrintLabelTypeEnum.ContractID
        '        X1 = 50 : Y1 = 35
        '        g.DrawString("شماره قرارداد", New Font("Tahoma", 8), Brushes.Black, X1, Y1)
        '        X1 = 50 : Y1 = 50
        '        g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(clsDalContract.ContractID), Barcodeheight), X1, Y1)

        '    Case PrintLabelTypeEnum.ContractID_PoseCode_Outlet
        '        X1 = 50 : Y1 = 35
        '        g.DrawString("شماره قرارداد", New Font("Tahoma", 8), Brushes.Black, X1, Y1)
        '        X1 = 50 : Y1 = 50
        '        g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(clsDalContract.ContractID), Barcodeheight), X1, Y1)

        '        X1 = 50 : Y1 = 95
        '        g.DrawString("Pos Code", New Font("Tahoma", 8), Brushes.Black, X1, Y1)
        '        X1 = 50 : Y1 = 110
        '        g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(clsDalContract.DCode_vc), Barcodeheight), X1, Y1)

        '        X1 = 50 : Y1 = 155
        '        g.DrawString("Outlet", New Font("Tahoma", 8), Brushes.Black, X1, Y1)
        '        X1 = 50 : Y1 = 170
        '        g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(clsDalContract.DOutlet_vc), Barcodeheight), X1, Y1)
        'End Select
    End Sub
#End Region
    Private Sub frmContractingparty_Contract_Account_Store_Device_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
    Private Sub btnSinglePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSinglePrint.Click
        Try
            SinglePrint()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgPrintFailed)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub SinglePrint()
        Try
            ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID
            PrintBarcodeRoutin()
        Catch ex As Exception
            ShowErrorMessage(ex.ToString)
            Throw ex
        End Try
    End Sub
    Private Sub txtContractID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContractID.TextChanged
        Try

            If IsNumeric(txtContractID.Text) = True Then
                clsContractAndCMS.ContractID = Convert.ToInt64(txtContractID.Text)
            Else
                clsContractAndCMS.ContractID = 0
            End If
            For i As Integer = 0 To chkCMSProject.Items.Count - 1
                chkCMSProject.SetItemChecked(i, False)
            Next
            Dim dt As New DataTable
            dt = clsContractAndCMS.GetByContractID()
            For Each row As DataRow In dt.Rows
                For i As Integer = 0 To chkCMSProject.Items.Count - 1
                    If chkCMSProject.Items(i).CMSProjectID = row("CMSProjectID") Then
                        chkCMSProject.SetItemChecked(i, True)
                    End If
                Next
            Next
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
#End Region
#Region "Methods"
#Region "FormLoad"
    Private Sub InitControls()
        Me.dgvContractingParty_Contract.AutoGenerateColumns = False
        Me.dgvAccount.AutoGenerateColumns = False
        Me.dgvStore.AutoGenerateColumns = False
        'Me.dgvDevice_Pos_DevicePos.AutoGenerateColumns = True

        Me.dgvContractingParty_Contract.Columns("colContractingPartyID").HeaderText = ""
        Me.dgvContractingParty_Contract.Columns("colContractingPartyID").Width = 0
        Me.dgvContractingParty_Contract.Columns("colContractingPartyID").SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dgvContractingParty_Contract.Columns("colContractingPartyID").Resizable = DataGridViewTriState.False

        Me.dgvAccount.Columns("colAAccountID").HeaderText = ""
        Me.dgvAccount.Columns("colAAccountID").Width = 0
        Me.dgvAccount.Columns("colAAccountID").SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dgvAccount.Columns("colAAccountID").Resizable = DataGridViewTriState.False

        Me.dgvStore.Columns("colSStoreID").HeaderText = ""
        Me.dgvStore.Columns("colSStoreID").Width = 0
        Me.dgvStore.Columns("colSStoreID").SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dgvStore.Columns("colSStoreID").Resizable = DataGridViewTriState.False


        '//////////General buttons//////////////
        Dim AddButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        AddButton.Button = btnAdd
        AddButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Add
        AddButton.e = New eventhandler(AddressOf btnAdd_Click)
        AddButton.ShortCut = ClassSetting.Add_Shortcut
        clsMyControlerContractingParty.AddButton(AddButton)
        clsMyControlerAccount.AddButton(AddButton)
        clsMyControlerStore.AddButton(AddButton)

        Dim EditButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        EditButton.Button = btnEdit
        EditButton.e = New EventHandler(AddressOf btnEdit_Click)
        EditButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Edit
        EditButton.ShortCut = ClassSetting.Edit_Shortcut
        clsMyControlerContractingParty.AddButton(EditButton)
        clsMyControlerAccount.AddButton(EditButton)
        clsMyControlerStore.AddButton(EditButton)

        Dim CancelButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        CancelButton.Button = btnCancel
        CancelButton.e = New EventHandler(AddressOf btnCancel_Click)
        CancelButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Cancel
        CancelButton.ShortCut = ClassSetting.Cancel_Shortcut
        clsMyControlerContractingParty.AddButton(CancelButton)
        clsMyControlerAccount.AddButton(CancelButton)
        clsMyControlerStore.AddButton(CancelButton)

        Dim DeleteButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        DeleteButton.Button = btnDelete
        DeleteButton.e = New EventHandler(AddressOf btnDelete_Click)
        DeleteButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Delete
        DeleteButton.ShortCut = ClassSetting.Delete_Shortcut
        clsMyControlerContractingParty.AddButton(DeleteButton)
        clsMyControlerAccount.AddButton(DeleteButton)
        clsMyControlerStore.AddButton(DeleteButton)

        Dim SaveButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        SaveButton.Button = btnSave
        SaveButton.e = New EventHandler(AddressOf btnSave_Click)
        SaveButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Save
        SaveButton.ShortCut = ClassSetting.OnlySave_Shortcut
        clsMyControlerContractingParty.AddButton(SaveButton)
        clsMyControlerAccount.AddButton(SaveButton)
        clsMyControlerStore.AddButton(SaveButton)


        'Dim SearchButton As RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonTemplate
        'SearchButton.Button = btnSearch
        'SearchButton.e = New EventHandler(AddressOf btnSearch_Click)
        'SearchButton.Role = RIZNARM.WINDOWS.FORMS.ClassFormController.ButtonRole.Find
        'SearchButton.ShortCut = ClassSetting.Search_Shortcut
        'clsMyControlerContractingParty.AddButton(SearchButton)

        '//////////Definition Buttons//////////////

        Dim lVisitorID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lVisitorID.Control = lblVisitorID
        lVisitorID.EnabledInAddState = True
        lVisitorID.EnabledInEditState = False
        lVisitorID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        lVisitorID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(lVisitorID)
        ''raeisi
        Dim VisitorFullName As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        VisitorFullName.Control = txtVisitorFullName
        VisitorFullName.EnabledInAddState = True
        VisitorFullName.EnabledInEditState = True
        VisitorFullName.EnabledInViewState = False
        VisitorFullName.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(VisitorFullName)

        Dim lCIdentityTypeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lCIdentityTypeID.Control = lblCIdentityTypeID
        lCIdentityTypeID.EnabledInAddState = True
        lCIdentityTypeID.EnabledInEditState = True
        lCIdentityTypeID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(lCIdentityTypeID)

        Dim lDegreeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lDegreeID.Control = lblDegreeID
        lDegreeID.EnabledInAddState = True
        lDegreeID.EnabledInEditState = True
        lDegreeID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(lDegreeID)

        Dim lAccountTypeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lAccountTypeID.Control = lblAccountTypeID
        lAccountTypeID.EnabledInAddState = True
        lAccountTypeID.EnabledInEditState = True
        lAccountTypeID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(lAccountTypeID)

        Dim lBranchID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lBranchID.Control = lbBranchID
        lBranchID.EnabledInAddState = True
        lBranchID.EnabledInEditState = True
        lBranchID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(lBranchID)

        Dim chkList As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        chkList.Control = chkCMSProject
        chkList.EnabledInAddState = True
        chkList.EnabledInEditState = True
        chkList.EnabledInViewState = False
        clsMyControlerContractingParty.AddControl(chkList)

        Dim lSSIdentityTypeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lSSIdentityTypeID.Control = lblSSIdentityTypeID
        lSSIdentityTypeID.EnabledInAddState = True
        lSSIdentityTypeID.EnabledInEditState = True
        lSSIdentityTypeID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(lSSIdentityTypeID)


        Dim lSEstateConditionID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lSEstateConditionID.Control = lblSEstateConditionID
        lSEstateConditionID.EnabledInAddState = True
        lSEstateConditionID.EnabledInEditState = True
        lSEstateConditionID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(lSEstateConditionID)

        Dim lSGroupID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lSGroupID.Control = lblSGroupID
        lSGroupID.EnabledInAddState = True
        lSGroupID.EnabledInEditState = True
        lSGroupID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(lSGroupID)

        Dim lsAddress As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lsAddress.Control = lblSADDRESS
        lsAddress.EnabledInAddState = True
        lsAddress.EnabledInEditState = True
        lsAddress.EnabledInViewState = False
        '  lsAddress.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(lsAddress)


        Dim tSGroupID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        tSGroupID.Control = trvSGroupID
        tSGroupID.EnabledInAddState = True
        tSGroupID.EnabledInEditState = True
        tSGroupID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(tSGroupID)


        Dim lAAccountTypeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lAAccountTypeID.Control = lblAAccountTypeID
        lAAccountTypeID.EnabledInAddState = True
        lAAccountTypeID.EnabledInEditState = False
        lAAccountTypeID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerAccount.AddControl(lAAccountTypeID)

        Dim lABranchID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        lABranchID.Control = lblABranchID
        lABranchID.EnabledInAddState = True
        lABranchID.EnabledInEditState = False
        lABranchID.EnabledInViewState = False
        'btnGoodTypes.MappedColumn = "colGoodTypeID"
        'btnGoodTypes.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerAccount.AddControl(lABranchID)
        '//////////////////////////////////
        Dim SearchBy As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SearchBy.Control = cboSearchBy
        SearchBy.EnabledInAddState = False
        SearchBy.EnabledInEditState = False
        SearchBy.EnabledInViewState = True
        ' SearchBy.MappedColumn = "colCityID"
        SearchBy.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedIndex
        clsMyControlerContractingParty.AddControl(SearchBy)

        Dim Search As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Search.Control = txtSearch
        Search.EnabledInAddState = False
        Search.EnabledInEditState = False
        Search.EnabledInViewState = True
        'FirstName_nvc.MappedColumn = "colFirstName_nvc"
        Search.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(Search)


        '///////ContractingParty///////////

        Dim ContractingPartyID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ContractingPartyID.Control = txtContractingID
        ContractingPartyID.EnabledInAddState = True
        ContractingPartyID.EnabledInEditState = False
        ContractingPartyID.EnabledInViewState = False
        ContractingPartyID.MappedColumn = "colContractingPartyID"
        ContractingPartyID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(ContractingPartyID)

        Dim FirstName_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        FirstName_nvc.Control = txtFirstName_nvc
        FirstName_nvc.EnabledInAddState = True
        FirstName_nvc.EnabledInEditState = True
        FirstName_nvc.EnabledInViewState = False
        FirstName_nvc.MappedColumn = "colFirstName_nvc"
        FirstName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(FirstName_nvc)

        Dim LastName_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        LastName_nvc.Control = txtLastName_nvc
        LastName_nvc.EnabledInAddState = True
        LastName_nvc.EnabledInEditState = True
        LastName_nvc.EnabledInViewState = False
        LastName_nvc.MappedColumn = "colLastName_nvc"
        LastName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(LastName_nvc)

        Dim FatherName_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        FatherName_nvc.Control = txtFatherName_nvc
        FatherName_nvc.EnabledInAddState = True
        FatherName_nvc.EnabledInEditState = True
        FatherName_nvc.EnabledInViewState = False
        FatherName_nvc.MappedColumn = "colFatherName_nvc"
        FatherName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(FatherName_nvc)

        Dim IdentityCertificateNO_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        IdentityCertificateNO_nvc.Control = txtIdentityCertificateNO_nvc
        IdentityCertificateNO_nvc.EnabledInAddState = True
        IdentityCertificateNO_nvc.EnabledInEditState = True
        IdentityCertificateNO_nvc.EnabledInViewState = False
        IdentityCertificateNO_nvc.MappedColumn = "colIdentityCertificateNO_nvc"
        IdentityCertificateNO_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(IdentityCertificateNO_nvc)

        Dim NationalCode_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        NationalCode_nvc.Control = txtNationalCode_nvc
        NationalCode_nvc.EnabledInAddState = True
        NationalCode_nvc.EnabledInEditState = True
        NationalCode_nvc.EnabledInViewState = False
        NationalCode_nvc.MappedColumn = "colNationalCode_nvc"
        NationalCode_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(NationalCode_nvc)

        Dim MaleGender_bit As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        MaleGender_bit.Control = rdoMaleGender_bit
        MaleGender_bit.EnabledInAddState = True
        MaleGender_bit.EnabledInEditState = True
        MaleGender_bit.EnabledInViewState = False
        MaleGender_bit.MappedColumn = "colGender_bit"
        MaleGender_bit.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        clsMyControlerContractingParty.AddControl(MaleGender_bit)

        Dim FemaleGender_bit As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        FemaleGender_bit.Control = rdoFemaleGender_bit
        FemaleGender_bit.EnabledInAddState = True
        FemaleGender_bit.EnabledInEditState = True
        FemaleGender_bit.EnabledInViewState = False
        'FemaleGender_bit.MappedColumn = "colGender_bit"
        FemaleGender_bit.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        clsMyControlerContractingParty.AddControl(FemaleGender_bit)

        Dim BirthDate_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        BirthDate_vc.Control = dtxtBirthDate_vc
        BirthDate_vc.EnabledInAddState = True
        BirthDate_vc.EnabledInEditState = True
        BirthDate_vc.EnabledInViewState = False
        BirthDate_vc.MappedColumn = "colBirthDate_vc"
        BirthDate_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Value
        clsMyControlerContractingParty.AddControl(BirthDate_vc)

        Dim StateID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        StateID.Control = cboStateID
        StateID.EnabledInAddState = True
        StateID.EnabledInEditState = True
        StateID.EnabledInViewState = False
        StateID.MappedColumn = "colStateID"
        StateID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerContractingParty.AddControl(StateID)

        Dim CityID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        CityID.Control = cboCityID
        CityID.EnabledInAddState = True
        CityID.EnabledInEditState = True
        CityID.EnabledInViewState = False
        CityID.MappedColumn = "colCityID"
        CityID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerContractingParty.AddControl(CityID)

        Dim CIdentityTypeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        CIdentityTypeID.Control = cboCIdentityTypeID
        CIdentityTypeID.EnabledInAddState = True
        CIdentityTypeID.EnabledInEditState = True
        CIdentityTypeID.EnabledInViewState = False
        CIdentityTypeID.MappedColumn = "colCIdentityTypeID"
        CIdentityTypeID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerContractingParty.AddControl(CIdentityTypeID)

        Dim DegreeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        DegreeID.Control = cboDegreeID
        DegreeID.EnabledInAddState = True
        DegreeID.EnabledInEditState = True
        DegreeID.EnabledInViewState = False
        DegreeID.MappedColumn = "colDegreeID"
        DegreeID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerContractingParty.AddControl(DegreeID)

        Dim Title_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Title_nvc.Control = cboTitle_nvc
        Title_nvc.EnabledInAddState = True
        Title_nvc.EnabledInEditState = True
        Title_nvc.EnabledInViewState = False
        Title_nvc.MappedColumn = "colTitle_nvc"
        Title_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(Title_nvc)

        Dim HomeAddress_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        HomeAddress_nvc.Control = txtHomeAddress_nvc
        HomeAddress_nvc.EnabledInAddState = True
        HomeAddress_nvc.EnabledInEditState = True
        HomeAddress_nvc.EnabledInViewState = False
        HomeAddress_nvc.MappedColumn = "colHomeAddress_nvc"
        HomeAddress_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(HomeAddress_nvc)

        Dim HomeTel_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        HomeTel_vc.Control = txtHomeTel_vc
        HomeTel_vc.EnabledInAddState = True
        HomeTel_vc.EnabledInEditState = True
        HomeTel_vc.EnabledInViewState = False
        HomeTel_vc.MappedColumn = "colHomeTel_vc"
        HomeTel_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(HomeTel_vc)

        Dim Email_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Email_nvc.Control = txtEmail_nvc
        Email_nvc.EnabledInAddState = True
        Email_nvc.EnabledInEditState = True
        Email_nvc.EnabledInViewState = False
        Email_nvc.MappedColumn = "colEmail_nvc"
        Email_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(Email_nvc)

        Dim YesHavingAccount_bit As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        YesHavingAccount_bit.Control = rdoYesHavingAccount_bit
        YesHavingAccount_bit.EnabledInAddState = True
        YesHavingAccount_bit.EnabledInEditState = True
        YesHavingAccount_bit.EnabledInViewState = False
        YesHavingAccount_bit.MappedColumn = "colHavingAccount_bit"
        YesHavingAccount_bit.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        clsMyControlerContractingParty.AddControl(YesHavingAccount_bit)

        Dim NOHavingAccount_bit As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        NOHavingAccount_bit.Control = rdoNoHavingAccount_bit
        NOHavingAccount_bit.EnabledInAddState = True
        NOHavingAccount_bit.EnabledInEditState = True
        NOHavingAccount_bit.EnabledInViewState = False
        'NOHavingAccount_bit.MappedColumn = "colHavingAccount_bit"
        NOHavingAccount_bit.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Checked
        clsMyControlerContractingParty.AddControl(NOHavingAccount_bit)

        Dim AccountTypeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AccountTypeID.Control = cboAccountTypeID
        AccountTypeID.EnabledInAddState = True
        AccountTypeID.EnabledInEditState = True
        AccountTypeID.EnabledInViewState = False
        AccountTypeID.MappedColumn = "colAccountTypeID"
        AccountTypeID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerContractingParty.AddControl(AccountTypeID)

        Dim AccountNO_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AccountNO_vc.Control = txtAccountNO_vc
        AccountNO_vc.EnabledInAddState = True
        AccountNO_vc.EnabledInEditState = True
        AccountNO_vc.EnabledInViewState = False
        AccountNO_vc.MappedColumn = "colAccountNO_vc"
        AccountNO_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(AccountNO_vc)

        Dim ShabaAccount As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ShabaAccount.Control = txtShabaAccount
        ShabaAccount.EnabledInAddState = True
        ShabaAccount.EnabledInEditState = True
        ShabaAccount.EnabledInViewState = False
        ShabaAccount.MappedColumn = "colShabaAccount"
        ShabaAccount.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(ShabaAccount)


        Dim CardNo_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        CardNo_vc.Control = txtCardNo_vc
        CardNo_vc.EnabledInAddState = True
        CardNo_vc.EnabledInEditState = True
        CardNo_vc.EnabledInViewState = False
        CardNo_vc.MappedColumn = "colCardNo_vc"
        CardNo_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(CardNo_vc)

        Dim BranchID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        BranchID.Control = cboBranchID
        BranchID.EnabledInAddState = True
        BranchID.EnabledInEditState = True
        BranchID.EnabledInViewState = False
        BranchID.MappedColumn = "colBranchID"
        BranchID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerContractingParty.AddControl(BranchID)

        '////////Contract//////////////
        Dim ContractID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ContractID.Control = txtContractID
        ContractID.EnabledInAddState = True
        ContractID.EnabledInEditState = True
        ContractID.EnabledInViewState = False
        ContractID.MappedColumn = "colContractID"
        ContractID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(ContractID)

        Dim MarketingByID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        MarketingByID.Control = cboMarketingByID
        MarketingByID.EnabledInAddState = True
        MarketingByID.EnabledInEditState = True
        MarketingByID.EnabledInViewState = False
        MarketingByID.MappedColumn = "colMarketingByID"
        MarketingByID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerContractingParty.AddControl(MarketingByID)


        Dim ZoncanNo_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ZoncanNo_nvc.Control = txtZoncanNo_nvc
        ZoncanNo_nvc.EnabledInAddState = False
        ZoncanNo_nvc.EnabledInEditState = False
        ZoncanNo_nvc.EnabledInViewState = False
        ZoncanNo_nvc.MappedColumn = "colZoncanNo_nvc"
        ZoncanNo_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(ZoncanNo_nvc)

        Dim RequestID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        RequestID.Control = txtRequestID
        RequestID.EnabledInAddState = False
        RequestID.EnabledInEditState = False
        RequestID.EnabledInViewState = False
        RequestID.MappedColumn = "colRequestID"
        RequestID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(RequestID)


        Dim VisitorID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        VisitorID.Control = txtVisitorID
        VisitorID.EnabledInAddState = True
        VisitorID.EnabledInEditState = False
        VisitorID.EnabledInViewState = False
        VisitorID.MappedColumn = "colVisitorID"
        VisitorID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(VisitorID)

        Dim Date_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Date_vc.Control = dtxtDate_vc
        Date_vc.EnabledInAddState = True
        Date_vc.EnabledInEditState = True
        Date_vc.EnabledInViewState = False
        Date_vc.MappedColumn = "colDate_vc"
        Date_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Value
        clsMyControlerContractingParty.AddControl(Date_vc)

        Dim Merchant_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        Merchant_vc.Control = txtMerchant_vc
        Merchant_vc.EnabledInAddState = True
        Merchant_vc.EnabledInEditState = True
        Merchant_vc.EnabledInViewState = False
        Merchant_vc.MappedColumn = "colMerchant_vc"
        Merchant_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(Merchant_vc)

        Dim SaveDate_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SaveDate_vc.Control = dtxtSaveDate_vc
        SaveDate_vc.EnabledInAddState = False
        SaveDate_vc.EnabledInEditState = False
        SaveDate_vc.EnabledInViewState = False
        SaveDate_vc.MappedColumn = "colSaveDate_vc"
        SaveDate_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Value
        clsMyControlerContractingParty.AddControl(SaveDate_vc)

        Dim ContractNo_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ContractNo_vc.Control = txtContractNo_vc
        ContractNo_vc.EnabledInAddState = True
        ContractNo_vc.EnabledInEditState = True
        ContractNo_vc.EnabledInViewState = False
        ContractNo_vc.MappedColumn = "colContractNo_vc"
        ContractNo_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerContractingParty.AddControl(ContractNo_vc)

        '////////////Account////////////////
        Dim AAccountID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AAccountID.Control = txtAAccountID
        AAccountID.EnabledInAddState = True
        AAccountID.EnabledInEditState = False
        AAccountID.EnabledInViewState = False
        AAccountID.MappedColumn = "colAAccountID"
        AAccountID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerAccount.AddControl(AAccountID)

        Dim AAccountNO_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AAccountNO_vc.Control = txtAAccountNO_vc
        AAccountNO_vc.EnabledInAddState = True
        AAccountNO_vc.EnabledInEditState = False
        AAccountNO_vc.EnabledInViewState = False
        AAccountNO_vc.MappedColumn = "colAAccountNO_vc"
        AAccountNO_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerAccount.AddControl(AAccountNO_vc)

        Dim AShabaAccount As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AShabaAccount.Control = txtAShabaAccount
        AShabaAccount.EnabledInAddState = True
        AShabaAccount.EnabledInEditState = False
        AShabaAccount.EnabledInViewState = False
        AShabaAccount.MappedColumn = "colAShabaAccount"
        AShabaAccount.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerAccount.AddControl(AShabaAccount)

        Dim ACardNo_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ACardNo_vc.Control = txtACardNo_vc
        ACardNo_vc.EnabledInAddState = True
        ACardNo_vc.EnabledInEditState = False
        ACardNo_vc.EnabledInViewState = False
        ACardNo_vc.MappedColumn = "colACardNo_vc"
        ACardNo_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerAccount.AddControl(ACardNo_vc)

        Dim AAccountTypeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AAccountTypeID.Control = cboAAccountTypeID
        AAccountTypeID.EnabledInAddState = True
        AAccountTypeID.EnabledInEditState = False
        AAccountTypeID.EnabledInViewState = False
        AAccountTypeID.MappedColumn = "colAAccountTypeID"
        AAccountTypeID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerAccount.AddControl(AAccountTypeID)

        Dim ABranchID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        ABranchID.Control = cboABranchID
        ABranchID.EnabledInAddState = True
        ABranchID.EnabledInEditState = False
        ABranchID.EnabledInViewState = False
        ABranchID.MappedColumn = "colABranchID"
        ABranchID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerAccount.AddControl(ABranchID)

        Dim AFinancialSupervisionId As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        AFinancialSupervisionId.Control = cboAFinancialSupervisionId
        AFinancialSupervisionId.EnabledInAddState = True
        AFinancialSupervisionId.EnabledInEditState = True
        AFinancialSupervisionId.EnabledInViewState = False
        AFinancialSupervisionId.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerAccount.AddControl(AFinancialSupervisionId)

        '////////////Store//////////////////

        Dim SStoreID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SStoreID.Control = txtSStoreID
        SStoreID.EnabledInAddState = True
        SStoreID.EnabledInEditState = False
        SStoreID.EnabledInViewState = False
        SStoreID.MappedColumn = "colSStoreID"
        SStoreID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(SStoreID)

        Dim SAccountID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SAccountID.Control = txtSStoreID
        SAccountID.EnabledInAddState = True
        SAccountID.EnabledInEditState = False
        SAccountID.EnabledInViewState = False
        SAccountID.MappedColumn = "colSAccountID"
        SAccountID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(SAccountID)

        Dim SGroupID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SGroupID.Control = cboSGroupID
        SGroupID.EnabledInAddState = True
        SGroupID.EnabledInEditState = True
        SGroupID.EnabledInViewState = False
        SGroupID.MappedColumn = "colSGroupID"
        SGroupID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerStore.AddControl(SGroupID)

        Dim SGroupID1 As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SGroupID1.Control = cboSGroupID1
        SGroupID1.EnabledInAddState = True
        SGroupID1.EnabledInEditState = True
        SGroupID1.EnabledInViewState = False
        SGroupID1.MappedColumn = "colSGroupID"
        SGroupID1.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerStore.AddControl(SGroupID1)

        Dim SLicense As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SLicense.Control = cboSLicense
        SLicense.EnabledInAddState = True
        SLicense.EnabledInEditState = True
        SLicense.EnabledInViewState = False
        SLicense.MappedColumn = "colSLicense"
        SLicense.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerStore.AddControl(SLicense)


        Dim SSupplementary As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SSupplementary.Control = cboSSupplementary
        SSupplementary.EnabledInAddState = True
        SSupplementary.EnabledInEditState = True
        SSupplementary.EnabledInViewState = False
        SSupplementary.MappedColumn = "colSSupplementary"
        SSupplementary.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerStore.AddControl(SSupplementary)

        Dim SStateID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SStateID.Control = cboSStateID
        SStateID.EnabledInAddState = True
        SStateID.EnabledInEditState = True
        SStateID.EnabledInViewState = False
        SStateID.MappedColumn = "colSStateID"
        SStateID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerStore.AddControl(SStateID)

        Dim SCityID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SCityID.Control = cboSCityID
        SCityID.EnabledInAddState = True
        SCityID.EnabledInEditState = True
        SCityID.EnabledInViewState = False
        SCityID.MappedColumn = "colSCityID"
        SCityID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerStore.AddControl(SCityID)

        Dim SName_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SName_nvc.Control = txtSName_nvc
        SName_nvc.EnabledInAddState = True
        SName_nvc.EnabledInEditState = True
        SName_nvc.EnabledInViewState = False
        SName_nvc.MappedColumn = "colSName_nvc"
        SName_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(SName_nvc)

        Dim SPostCode_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SPostCode_vc.Control = txtSPostCode_vc
        SPostCode_vc.EnabledInAddState = True
        SPostCode_vc.EnabledInEditState = True
        SPostCode_vc.EnabledInViewState = False
        SPostCode_vc.MappedColumn = "colSPostCode_vc"
        SPostCode_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(SPostCode_vc)

        Dim SAddress_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SAddress_nvc.Control = txtSAddress_nvc
        SAddress_nvc.EnabledInAddState = True
        SAddress_nvc.EnabledInEditState = True
        SAddress_nvc.EnabledInViewState = False
        SAddress_nvc.MappedColumn = "colSAddress_nvc"
        SAddress_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(SAddress_nvc)

        Dim SnewAddress_nvc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SnewAddress_nvc.Control = newtxtSAddressCode_nvc
        SnewAddress_nvc.EnabledInAddState = True
        SnewAddress_nvc.EnabledInEditState = True
        SnewAddress_nvc.EnabledInViewState = False
        SnewAddress_nvc.MappedColumn = "colSnewAddress_nvc"
        SnewAddress_nvc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(SnewAddress_nvc)

        Dim STel1_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        STel1_vc.Control = txtSTel1_vc
        STel1_vc.EnabledInAddState = True
        STel1_vc.EnabledInEditState = True
        STel1_vc.EnabledInViewState = False
        STel1_vc.MappedColumn = "colSTel1_vc"
        STel1_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(STel1_vc)

        Dim STel2_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        STel2_vc.Control = txtSTel2_vc
        STel2_vc.EnabledInAddState = True
        STel2_vc.EnabledInEditState = True
        STel2_vc.EnabledInViewState = False
        STel2_vc.MappedColumn = "colSTel2_vc"
        STel2_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(STel2_vc)

        Dim SFax_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SFax_vc.Control = txtSFax_vc
        SFax_vc.EnabledInAddState = True
        SFax_vc.EnabledInEditState = True
        SFax_vc.EnabledInViewState = False
        SFax_vc.MappedColumn = "colSFax_vc"
        SFax_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(SFax_vc)

        Dim SMunicipalAreaNO_sint As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SMunicipalAreaNO_sint.Control = ntxtSMunicipalAreaNO_sint
        SMunicipalAreaNO_sint.EnabledInAddState = True
        SMunicipalAreaNO_sint.EnabledInEditState = True
        SMunicipalAreaNO_sint.EnabledInViewState = False
        SMunicipalAreaNO_sint.MappedColumn = "colSMunicipalAreaNO_sint"
        SMunicipalAreaNO_sint.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(SMunicipalAreaNO_sint)

        Dim SEstateConditionID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SEstateConditionID.Control = cboSEstateConditionID
        SEstateConditionID.EnabledInAddState = True
        SEstateConditionID.EnabledInEditState = True
        SEstateConditionID.EnabledInViewState = False
        SEstateConditionID.MappedColumn = "colSEstateConditionID"
        SEstateConditionID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerStore.AddControl(SEstateConditionID)

        Dim SSIdentityTypeID As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SSIdentityTypeID.Control = cboSSIdentityTypeID
        SSIdentityTypeID.EnabledInAddState = True
        SSIdentityTypeID.EnabledInEditState = True
        SSIdentityTypeID.EnabledInViewState = False
        SSIdentityTypeID.MappedColumn = "colSSIdentityTypeID"
        SSIdentityTypeID.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerStore.AddControl(SSIdentityTypeID)

        Dim SSIdentityTypeSDate_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SSIdentityTypeSDate_vc.Control = dtxtSSIdentityTypeSDate_vc
        SSIdentityTypeSDate_vc.EnabledInAddState = True
        SSIdentityTypeSDate_vc.EnabledInEditState = True
        SSIdentityTypeSDate_vc.EnabledInViewState = False
        SSIdentityTypeSDate_vc.MappedColumn = "colSSIdentityTypeSDate_vc"
        SSIdentityTypeSDate_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Value
        clsMyControlerStore.AddControl(SSIdentityTypeSDate_vc)

        Dim SSIdentityTypeEDate_vc As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SSIdentityTypeEDate_vc.Control = dtxtSSIdentityTypeEDate_vc
        SSIdentityTypeEDate_vc.EnabledInAddState = True
        SSIdentityTypeEDate_vc.EnabledInEditState = True
        SSIdentityTypeEDate_vc.EnabledInViewState = False
        SSIdentityTypeEDate_vc.MappedColumn = "colSSIdentityTypeEDate_vc"
        SSIdentityTypeEDate_vc.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Value
        clsMyControlerStore.AddControl(SSIdentityTypeEDate_vc)


        Dim SDeviceCount_tint As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SDeviceCount_tint.Control = txtSDeviceCount_tint
        SDeviceCount_tint.EnabledInAddState = True
        SDeviceCount_tint.EnabledInEditState = True
        SDeviceCount_tint.EnabledInViewState = False
        SDeviceCount_tint.MappedColumn = "colSDeviceCount_tint"
        SDeviceCount_tint.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.Text
        clsMyControlerStore.AddControl(SDeviceCount_tint)

        Dim SPosModel As RIZNARM.WINDOWS.FORMS.ClassFormController.ValueControlTemplate
        SPosModel.Control = cboStorePosModel
        SPosModel.EnabledInAddState = True
        SPosModel.EnabledInEditState = True
        SPosModel.EnabledInViewState = False
        SPosModel.MappedColumn = "colStorePosModelID"
        SPosModel.ValueProperty = RIZNARM.WINDOWS.FORMS.ClassFormController.ControlProperty.SelectedValue
        clsMyControlerStore.AddControl(SPosModel)

        '/////////////Device/////////////


    End Sub
    Private Sub FormLoad()
        Try
            modPublicMethod.ErrorProviderClear(ErrorProvider)
            RefreshForm()
            VisibleControls(True)
            EnableTbpContractingParty(True)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#Region "FillCombos"
    Private Sub FillcboMarketingByID()
        Try
            Me.clsDalContract.BeginProc()
            Me.cboMarketingByID.DataSource = clsDalContract.GetAllMarketingBy

            Me.cboMarketingByID.DisplayMember = "Name_nvc"
            Me.cboMarketingByID.ValueMember = "MarketingByID"
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FillcboCIdentityTypeID()
        Try
            Me.clsDALBasicTypes.BeginProc()
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.CIdentityType
            Me.cboCIdentityTypeID.DataSource = clsDALBasicTypes.GetAll

            Me.cboCIdentityTypeID.DisplayMember = "Name_nvc"
            Me.cboCIdentityTypeID.ValueMember = "ID"
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBasicTypes.EndProc()
        End Try
    End Sub
    Private Sub FillcboDegreeID()
        Try
            Me.clsDALBasicTypes.BeginProc()
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.Degree
            Me.cboDegreeID.DataSource = clsDALBasicTypes.GetAll

            Me.cboDegreeID.DisplayMember = "Name_nvc"
            Me.cboDegreeID.ValueMember = "ID"
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBasicTypes.EndProc()
        End Try
    End Sub
    Private Sub FillcboAccountTypeID()
        Try
            Me.clsDALBasicTypes.BeginProc()
            Me.cboAccountTypeID.DisplayMember = "Name_nvc"
            Me.cboAccountTypeID.ValueMember = "ID"
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.AccountType
            Me.cboAccountTypeID.DataSource = clsDALBasicTypes.GetAll
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBasicTypes.EndProc()
        End Try
    End Sub
    Private Sub FillcboStateID()
        Try
            Me.clsDALState.BeginProc()
            cboStateID.DisplayMember = "Name_nvc"
            cboStateID.ValueMember = "StateID"
            cboSStateID.DisplayMember = "Name_nvc"
            cboSStateID.ValueMember = "StateID"
            Me.cboStateID.DataSource = clsDALState.GetAll
            Me.cboSStateID.DataSource = clsDALState.GetAll
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALState.EndProc()
        End Try
    End Sub
    Private Sub FillcboCityID(ByVal sender As Object)
        Try
            Me.clsDALCity.BeginProc()
            Select Case sender.name
                Case "cboStateID"
                    If cboStateID.SelectedIndex = -1 Then
                        clsDALCity.StateID = "-1"
                    Else
                        clsDALCity.StateID = cboStateID.SelectedValue
                    End If
                    Me.cboCityID.DisplayMember = "Name_nvc"
                    Me.cboCityID.ValueMember = "CityID"
                    Me.cboCityID.DataSource = clsDALCity.GetByStateID
                Case "cboSStateID"
                    If cboSStateID.SelectedIndex = -1 Then
                        clsDALCity.StateID = "-1"
                    Else
                        clsDALCity.StateID = cboSStateID.SelectedValue
                    End If
                    Me.cboSCityID.DisplayMember = "Name_nvc"
                    Me.cboSCityID.ValueMember = "CityID"
                    Me.cboSCityID.DataSource = clsDALCity.GetByStateID
            End Select
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALCity.EndProc()
        End Try
    End Sub
    Private Sub FillcboTitle_nvc()
        Try
            clsDalContract.BeginProc()
            Me.cboTitle_nvc.DataSource = clsDalContract.GetExistingTitles()
            Me.cboTitle_nvc.DisplayMember = "Title_nvc"
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FillcboSEstateConditionID()
        Try
            Me.clsDALBasicTypes.BeginProc()
            Me.cboDegreeID.DisplayMember = "Name_nvc"
            Me.cboDegreeID.ValueMember = "ID"
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.EstateCondition
            Me.cboSEstateConditionID.DataSource = clsDALBasicTypes.GetAll
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBasicTypes.EndProc()
        End Try
    End Sub
    Private Sub FillcboSSIdentityTypeID()
        Try
            Me.clsDALBasicTypes.BeginProc()
            Me.cboSSIdentityTypeID.DisplayMember = "Name_nvc"
            Me.cboSSIdentityTypeID.ValueMember = "ID"
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.SIdentityType
            Me.cboSSIdentityTypeID.DataSource = clsDALBasicTypes.GetAll
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBasicTypes.EndProc()
        End Try
    End Sub
    Private Sub FillcboDAccountTypeID()
        Try
            Me.clsDALBasicTypes.BeginProc()
            Me.cboAAccountTypeID.DisplayMember = "Name_nvc"
            Me.cboAAccountTypeID.ValueMember = "ID"
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.AccountType
            Me.cboAAccountTypeID.DataSource = clsDALBasicTypes.GetAll
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBasicTypes.EndProc()
        End Try

    End Sub
    Private Sub FillcboBranchID()
        Try
            Me.clsDALBranch.BeginProc()
            Me.cboBranchID.DisplayMember = "Name_nvc"
            Me.cboBranchID.ValueMember = "BranchID"
            Me.cboBranchID.DataSource = clsDALBranch.GetAll
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBranch.EndProc()
        End Try

    End Sub
    Private Sub FillcboABranchID()
        Try
            Me.clsDALBranch.BeginProc()
            Me.cboABranchID.DisplayMember = "Name_nvc"
            Me.cboABranchID.ValueMember = "BranchID"
            Me.cboABranchID.DataSource = clsDALBranch.GetAll
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBranch.EndProc()
        End Try

    End Sub

    Private Sub FillCboStorePosModel()
        Try
            Dim dtStorePosModel As DataTable
            dtStorePosModel = clsdalPos.GetAllStorePosModel()
            cboStorePosModel.DataSource = dtStorePosModel
            cboStorePosModel.DisplayMember = "Name_nvc"
            cboStorePosModel.ValueMember = "STOREPOSMODELMAPID"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillGroup()
        Try
            Me.clsDALGroup.BeginProc()

            Me.cboSGroupID.DisplayMember = "Name_nvc"
            Me.cboSGroupID.ValueMember = "GroupID"
            Me.cboSGroupID.DataSource = clsDALGroup.GetAll

            Me.cboSGroupID1.DisplayMember = "GroupID"
            Me.cboSGroupID1.ValueMember = "GroupID"
            Me.cboSGroupID1.DataSource = Me.cboSGroupID.DataSource


        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALGroup.EndProc()
        End Try

    End Sub
    Private Sub FillcboLicense(ByVal sender As Object)
        Try
            Me.clsDALGroup.BeginProc()
            If sender.name = "cboSGroupID"   Then

                If cboSGroupID.SelectedIndex = -1 Then
                    clsDALGroup.GroupID = "-1"
                Else
                    clsDALGroup.GroupID = cboSGroupID.SelectedValue
                End If
                Me.cboSLicense.DisplayMember = "LICENSENAME_NVC"
                Me.cboSLicense.ValueMember = "LICENSEID"
                Me.cboSLicense.DataSource = clsDALGroup.GetAllLicenseByGroupID

            End If
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALGroup.EndProc()
        End Try
    End Sub

    Private Sub FillcboSupplementary(ByVal sender As Object)
        Try
            Me.clsDALGroup.BeginProc()
            If sender.name = "cboSGroupID" Then

                If cboSGroupID.SelectedIndex = -1 Then
                    clsDALGroup.GroupID = "-1"
                Else
                    clsDALGroup.GroupID = cboSGroupID.SelectedValue
                End If
                Me.cboSSupplementary.DisplayMember = "NAME_NVC"
                Me.cboSSupplementary.ValueMember = "GROUPSUPPLEMENTARYID"
                Me.cboSSupplementary.DataSource = clsDALGroup.GetAllSupplementaryByGroupID

            End If
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALGroup.EndProc()
        End Try
    End Sub

    Private Sub FillEstateCondition()
        Try
            Me.clsDALBasicTypes.BeginProc()
            Me.cboSEstateConditionID.DisplayMember = "Name_nvc"
            Me.cboSEstateConditionID.ValueMember = "ID"
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.EstateCondition
            Me.cboSEstateConditionID.DataSource = clsDALBasicTypes.GetAll
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBasicTypes.EndProc()
        End Try
    End Sub
    Private Sub FillcboAFinancialSupervisionId(ByVal employerId As String)
        Try
            Me.clsDALBranch.BeginProc()
            Me.cboAFinancialSupervisionId.DataSource = clsDALBranch.GetAllFinancialSupervisionIdByEmployerId(employerId)
            Me.cboAFinancialSupervisionId.DisplayMember = "supervisionname"
            Me.cboAFinancialSupervisionId.ValueMember = "id"
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALBranch.EndProc()
        End Try

    End Sub

#End Region
#Region "FillGrids"
    Private Sub FilldgvContractParty()
        Try
            Me.clsDalContract.BeginProc()
            dtContractingParty_Contract = Me.clsDalContract.GetAllByPercentContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract

        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvContractPartyByNationalCode()
        Try
            Me.clsDalContract.BeginProc()
            Me.clsDalContract.NationalCode_nvc = txtSearch.Text.Trim
            dtContractingParty_Contract = Me.clsDalContract.GetByNationalCodeContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvContractPartyByLastName()
        Try
            Me.clsDalContract.BeginProc()
            Me.clsDalContract.LastName_nvc = txtSearch.Text.Trim
            dtContractingParty_Contract = Me.clsDalContract.GetByLastNameContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvContractPartyByContractID(ByVal ContractID As Int64)
        Try
            Me.clsDalContract.BeginProc()
            Me.clsDalContract.ContractID = ContractID
            dtContractingParty_Contract = Me.clsDalContract.GetByContractIDContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract
            txtContractID.Text = txtSearch.Text
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvContractPartyByContractNo()
        Try
            Me.clsDalContract.BeginProc()
            Me.clsDalContract.ContractNo_vc = txtSearch.Text.Trim
            dtContractingParty_Contract = Me.clsDalContract.GetByContractNoContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvContractPartyByMerchant()
        Try
            Me.clsDalContract.BeginProc()
            Me.clsDalContract.Merchant_vc = txtSearch.Text.Trim
            dtContractingParty_Contract = Me.clsDalContract.GetByMerchantContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvContractPartyByDate()
        Try
            Me.clsDalContract.BeginProc()
            Me.clsDalContract.Date_vc = txtSearch.Text.Trim
            dtContractingParty_Contract = Me.clsDalContract.GetByDateContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvContractPartyBySaveDate()
        Try
            Me.clsDalContract.BeginProc()
            Me.clsDalContract.SaveDate_vc = txtSearch.Text.Trim
            dtContractingParty_Contract = Me.clsDalContract.GetBySaveDateContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub

    Private Sub FilldgvContractPartyByRequestID()
        Try
            Me.clsDalContract.BeginProc()
            Me.clsDalContract.RequestID = txtSearch.Text.Trim
            dtContractingParty_Contract = Me.clsDalContract.GetByRequestIDContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvContractPartyByOutlet()
        Try
            Me.clsDalContract.BeginProc()
            Me.clsDalContract.DOutlet_vc = txtSearch.Text.Trim
            dtContractingParty_Contract = Me.clsDalContract.GetByOutletContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
            dgvContractingParty_Contract.DataSource = dtContractingParty_Contract
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub

    Private Sub FilldgvAccount()
        Try
            Me.clsDalContract.BeginProc()
            dtAccount = Me.clsDalContract.GetAllAccount()
            dgvAccount.DataSource = dtAccount
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try


    End Sub
    Private Sub FilldgvStore()
        Try
            Me.clsDalContract.BeginProc()
            dtStore = Me.clsDalContract.GetAllStore()
            dgvStore.DataSource = dtStore
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvDevice()
        Try
            Me.clsDalContract.BeginProc()
            Me.dgvDevice_Pos_DevicePos.AutoGenerateColumns = False

            dtDevice = Me.clsDalContract.GetAllDevice()
            dvDevice_Pos = dtDevice.DefaultView
            dgvDevice_Pos_DevicePos.DataSource = dvDevice_Pos

            '  SetdgvDevice_Pos_DevicePos()
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try

    End Sub
    'Private Sub SetdgvDevice_Pos_DevicePos()

    '    'dgvDevice_Pos_DevicePos.Columns("DPADeviceID").Visible = False
    '    'dgvDevice_Pos_DevicePos.Columns("DPADeviceID").Width = 5
    '    'dgvDevice_Pos_DevicePos.Columns("DStoreID").Visible = False
    '    'dgvDevice_Pos_DevicePos.Columns("DPassword_vc").Visible = False
    '    'dgvDevice_Pos_DevicePos.Columns("DPAPosID").Visible = False
    '    'dgvDevice_Pos_DevicePos.Columns("PActive_tint").Visible = False
    '    'dgvDevice_Pos_DevicePos.Columns("DPACount_int").Visible = False
    '    'dgvDevice_Pos_DevicePos.Columns("DPosID").Visible = False

    '    'dgvDevice_Pos_DevicePos.Columns("DCode_vc").HeaderText = "Pos Code"
    '    'dgvDevice_Pos_DevicePos.Columns("DOutlet_vc").HeaderText = "Outlet"
    '    'dgvDevice_Pos_DevicePos.Columns("DMerchant_vc").HeaderText = "Merchant"
    '    'dgvDevice_Pos_DevicePos.Columns("DVat_vc").HeaderText = "Vat"
    '    'dgvDevice_Pos_DevicePos.Columns("PSerial_vc").HeaderText = "سریال پز"
    '    'dgvDevice_Pos_DevicePos.Columns("PPropertyNo_vc").HeaderText = "شماره اموال"
    '    'dgvDevice_Pos_DevicePos.Columns("PEniacCode_vc").HeaderText = "کد پیگیری"
    'End Sub

    Private Sub FilldgvDeviceCrash()
        Try
            Me.clsDalContract.BeginProc()
            Me.dgvDevice_Pos_DevicePosCrash.AutoGenerateColumns = False

            'dtDeviceCrash = Me.clsDalContract.GetAllDeviceCrash()
            dtDeviceCrash = Me.clsDalContract.GetAllDevice()
            dvDeviceCrash_Pos = dtDeviceCrash.DefaultView
            dgvDevice_Pos_DevicePosCrash.DataSource = dvDeviceCrash_Pos

            '  SetdgvDevice_Pos_DevicePosCrash()
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try

    End Sub
    Private Sub FilldgvAccountByContractID()
        Try
            Me.clsDalContract.BeginProc()
            dtAccount = Me.clsDalContract.GetByContractIDAccount(Me.clsDalContract.ContractID)
            dgvAccount.DataSource = dtAccount
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try
    End Sub
    Private Sub FilldgvStoreByContractID()
        Try
            Me.clsDalContract.BeginProc()
            dtStore = Me.clsDalContract.GetByContractIDStore()
            dgvStore.DataSource = dtStore
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try

    End Sub
    Private Sub FilldgvDeviceByStoreID()
        Try
            Me.clsDalContract.BeginProc()
            Me.dgvDevice_Pos_DevicePos.AutoGenerateColumns = False

            dtDevice = Me.clsDalContract.GetByStoreIDDevice()
            dvDevice_Pos = dtDevice.DefaultView
            dgvDevice_Pos_DevicePos.DataSource = dvDevice_Pos

            dtDeviceCrash = Me.clsDalContract.GetByStoreIDDevice()
            dvDeviceCrash_Pos = dtDeviceCrash.DefaultView
            dgvDevice_Pos_DevicePosCrash.DataSource = dvDeviceCrash_Pos


            '  SetdgvDevice_Pos_DevicePos()
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try

    End Sub
    Private Sub FilldgvDeviceCrashBy()
        Try
            Me.clsDalContract.BeginProc()
            Me.dgvDevice_Pos_DevicePosCrash.AutoGenerateColumns = False

            'dtDeviceCrash = Me.clsDalContract.GetAllDeviceCrash()
            'dtDeviceCrash = Me.clsDalContract.GetByDeviceIDDeviceCrash()
            dvDeviceCrash_Pos = dtDeviceCrash.DefaultView
            dgvDevice_Pos_DevicePosCrash.DataSource = dvDeviceCrash_Pos

            '  SetdgvDevice_Pos_DevicePosCrash()
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDalContract.EndProc()
        End Try

    End Sub

    'Private Sub SetdgvDevice_Pos_DevicePosCrash()
    '    Me.dgvDevice_Pos_DevicePosCrash.AutoGenerateColumns = False

    '    'dgvDevice_Pos_DevicePosCrash.Columns("DPADeviceID").Visible = False
    '    'dgvDevice_Pos_DevicePosCrash.Columns("DPADeviceID").Width = 5
    '    'dgvDevice_Pos_DevicePosCrash.Columns("DStoreID").Visible = False
    '    'dgvDevice_Pos_DevicePosCrash.Columns("DPassword_vc").Visible = False
    '    'dgvDevice_Pos_DevicePosCrash.Columns("DPAPosID").Visible = False
    '    'dgvDevice_Pos_DevicePosCrash.Columns("PActive_tint").Visible = False
    '    'dgvDevice_Pos_DevicePosCrash.Columns("DPACount_int").Visible = False
    '    'dgvDevice_Pos_DevicePosCrash.Columns("DPosID").Visible = False

    '    'dgvDevice_Pos_DevicePosCrash.Columns("DCode_vc").HeaderText = "Pos Code"
    '    'dgvDevice_Pos_DevicePosCrash.Columns("DOutlet_vc").HeaderText = "Outlet"
    '    'dgvDevice_Pos_DevicePosCrash.Columns("DMerchant_vc").HeaderText = "Merchant"
    '    'dgvDevice_Pos_DevicePosCrash.Columns("DVat_vc").HeaderText = "Vat"
    '    'dgvDevice_Pos_DevicePosCrash.Columns("PSerial_vc").HeaderText = "سریال پز"
    '    'dgvDevice_Pos_DevicePosCrash.Columns("PPropertyNo_vc").HeaderText = "شماره اموال"
    '    'dgvDevice_Pos_DevicePosCrash.Columns("PEniacCode_vc").HeaderText = "کد پیگیری"
    'End Sub

#End Region
#End Region
#Region "TabPage"
    Private Sub EnableTbpContractingParty(ByVal bln As Boolean)
        tbpContractingParty.Enabled = True
        tbpAccount.Enabled = False
        tbpStore.Enabled = False
        tbpDevice.Enabled = False
    End Sub
    Private Sub EnableTbpAccount(ByVal bln As Boolean)
        tbpContractingParty.Enabled = True
        tbpAccount.Enabled = True
        tbpStore.Enabled = False
        tbpDevice.Enabled = False
    End Sub
    Private Sub EnableTbpStore(ByVal bln As Boolean)
        tbpContractingParty.Enabled = True
        tbpAccount.Enabled = True
        tbpStore.Enabled = True
        tbpDevice.Enabled = False
    End Sub
    Private Sub EnableTbpDevice(ByVal bln As Boolean)
        tbpContractingParty.Enabled = True
        tbpAccount.Enabled = True
        tbpStore.Enabled = True
        tbpDevice.Enabled = True
    End Sub
    Private Sub tbcSelecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
        If Me.tbc.TabPages(e.TabPageIndex).Enabled = False Then
            e.Cancel = True
        Else
            For i As Integer = e.TabPageIndex + 1 To Me.tbc.TabPages.Count - 1
                Me.tbc.TabPages(i).Enabled = False
            Next
        End If
    End Sub
    Private Sub tbpContractingPartyEnter(ByVal sender As System.Object)
        SetRdos()
        VisibleControls(True)
        SetStatusBar(sender)

    End Sub
    Private Sub tbpAccountEnter(ByVal sender As System.Object)
        VisibleControls(False)
        SetStatusBar(sender)

        For intCounter As Integer = 0 To Me.chkCMSProject.CheckedItems.Count - 1
            clsCMSProject = chkCMSProject.CheckedItems(intCounter)
        Next
        
        If (clsCMSProject.CMSProjectID.Equals(My.Settings.Pasargard_CmsProjectID)) Then
            Me.lblSupervision.Visible = True
            Me.cboAFinancialSupervisionId.Visible = True
            If (cboAFinancialSupervisionId.DataSource Is Nothing) Then
                Dim ibanIdentifier As String = txtShabaAccount.Text.Substring(5, 2)
                Dim employerId As String = clsDALBranch.GetAllMerchantEmployeridByIbanIdentifier(ibanIdentifier)
                If (employerId <> String.Empty) Then
                    FillcboAFinancialSupervisionId(employerId)
                Else
                    Me.lblSupervision.Visible = False
                    Me.cboAFinancialSupervisionId.Visible = False
                End If
            End If
        Else
            Me.lblSupervision.Visible = False
            Me.cboAFinancialSupervisionId.Visible = False
        End If

    End Sub
    Private Sub tbpStoreEnter(ByVal sender As System.Object)
        VisibleControls(False)
        SetStatusBar(sender)
    End Sub
    Private Sub tbpDeviceEnter(ByVal sender As System.Object)
        VisibleControls(False)
        SetStatusBar(sender)
    End Sub
    Private Sub SelectAccountTab()
        If Me.dgvContractingParty_Contract.SelectedRows.Count > 0 Then
            tsMain.Enabled = True
            If txtContractID.Text.Trim = "" Then
                Exit Sub
            End If
            Me.tbpAccount.Enabled = True
            tbc.SelectedTab = tbc.TabPages.Item("tbpAccount")

            'Me.dtAccount.DefaultView.RowFilter = "ContractID = " + txtContractID.Text.Trim 'clsDalContract.ContractID.ToString
            Me.clsDalContract.ContractID = txtContractID.Text.Trim
            Me.FilldgvAccountByContractID()

            Me.clsMyControlerAccount.DataGridView = Me.dgvAccount
            CurrentShebaAccount = Nothing
            OldShebaAccount = Nothing
            dvAccount = New DataView(dtAccount)
            dvAccount.RowFilter = "ContractID = " + txtContractID.Text.Trim

            If rdoYesHavingAccount_bit.Checked Then
                If dvAccount.Count = 0 Then
                    CurrentShebaAccount = txtShabaAccount.Text
                    OldShebaAccount = txtShabaAccount.Text
                Else
                    CurrentShebaAccount = dvAccount.Item(0)("ShabaAccount").ToString
                    OldShebaAccount = dvAccount.Item(0)("oldshabaaccount").ToString
                    ' CurrentShebaAccount = IIf(clsDalContract.ShabaAccount = Nothing, dgvAccount.Rows(0).Cells("colAShabaAccount").Value, clsDalContract.ShabaAccount)
                    ' OldShebaAccount = IIf(dtAccount.Rows(0).Item("oldshabaaccount").ToString().Trim = Nothing, dgvAccount.Rows(0).Cells("Cololdshabaaccount").Value, dtAccount.Rows(0).Item("oldshabaaccount").ToString().Trim)
                End If
            End If

            If (cboAFinancialSupervisionId.Visible = True And dvAccount IsNot Nothing And dvAccount.Count > 0) Then
                cboAFinancialSupervisionId.SelectedValue = dvAccount.Item(0)("Financialsupervisionid").ToString
            End If

            Me.clsMyControlerAccount.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            Me.clsMyControlerAccount.SetControlsValue()
            SetLinkBtn(Me.tbc.SelectedTab)

            For intCounter As Integer = 0 To Me.chkCMSProject.CheckedItems.Count - 1
                clsCMSProject = chkCMSProject.CheckedItems(intCounter)
            Next
        End If
    End Sub
    Private Sub SelectStoreTab()
        If Me.dgvAccount.SelectedRows.Count > 0 AndAlso Me.dgvContractingParty_Contract.SelectedRows.Count > 0 Then
            tsMain.Enabled = True
            If txtContractID.Text.Trim = "" Then
                Exit Sub
            End If

            'Me.dtAccount.DefaultView.RowFilter = "ContractID = " + txtContractID.Text.Trim 'clsDalContract.ContractID.ToString
            Me.clsDalContract.ContractID = txtContractID.Text.Trim
            'Me.FilldgvAccountByContractID()

            Me.clsMyControlerAccount.DataGridView = Me.dgvAccount
            Me.clsMyControlerAccount.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            Me.clsMyControlerAccount.SetControlsValue()
            If txtAAccountID.Text.Trim = "" Then
                Exit Sub
            End If
            Me.tbpStore.Enabled = True
            tbc.SelectedTab = tbc.TabPages.Item("tbpStore")


            'Me.dtStore.DefaultView.RowFilter = "AccountID = " + txtAAccountID.Text.Trim.ToString 'clsDalContract.AAccountID.ToString
            Me.clsDalContract.AAccountID = txtAAccountID.Text.Trim.ToString
            Me.FilldgvStoreByContractID()


            Me.clsMyControlerStore.DataGridView = Me.dgvStore
            Me.clsMyControlerStore.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            Me.clsMyControlerStore.SetControlsValue()

            SetLinkBtn(Me.tbc.SelectedTab)
        End If
    End Sub
    Private Sub SelectDeviceTab()
        If Me.dgvStore.SelectedRows.Count > 0 AndAlso Me.dgvAccount.SelectedRows.Count > 0 AndAlso Me.dgvContractingParty_Contract.SelectedRows.Count > 0 Then
            tsMain.Enabled = True
            If txtContractID.Text.Trim = "" Then
                Exit Sub
            End If

            'Me.dtAccount.DefaultView.RowFilter = "ContractID = " + txtContractID.Text.Trim 'clsDalContract.ContractID.ToString
            Me.clsDalContract.ContractID = txtContractID.Text.Trim
            'Me.FilldgvAccountByContractID()

            Me.clsMyControlerAccount.DataGridView = Me.dgvAccount
            Me.clsMyControlerAccount.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            Me.clsMyControlerAccount.SetControlsValue()

            If txtAAccountID.Text.Trim = "" Then
                Exit Sub
            End If

            'Me.dtStore.DefaultView.RowFilter = "AccountID = " + txtAAccountID.Text.Trim.ToString 'clsDalContract.AAccountID.ToString
            'Me.FilldgvStoreByContractID()

            Me.clsMyControlerStore.DataGridView = Me.dgvStore
            Me.clsMyControlerStore.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            Me.clsMyControlerStore.SetControlsValue()

            If txtSStoreID.Text.Trim = "" Then
                Exit Sub
            End If
            tbpDevice.Enabled = True
            tbc.SelectedTab = tbc.TabPages.Item("tbpDevice")


            'Me.dtDevice.DefaultView.RowFilter = "DStoreID = " + txtSStoreID.Text.Trim + " And PActive_tint=1  "
            'Me.dtDeviceCrash.DefaultView.RowFilter = "DStoreID = " + txtSStoreID.Text.Trim + " And PActive_tint=0  "

            Me.clsDalContract.SStoreID = txtSStoreID.Text.Trim
            Me.FilldgvDeviceByStoreID()
            Me.dtDevice.DefaultView.RowFilter = " PActive_tint=1 "
            Me.dtDeviceCrash.DefaultView.RowFilter = "PActive_tint=0 "



            tsMain.Enabled = False
        End If
    End Sub
#End Region
#Region "Grids"
    Private Sub dgvContractingParty_ContractRowEnter(ByVal RowIndex As Int32)
        Try
            dgvContractingParty_Contract.Rows(RowIndex).Selected = True
            Me.clsMyControlerContractingParty.DataGridView = Me.dgvContractingParty_Contract
            clsMyControlerContractingParty.SetControlsValue(RowIndex)
            clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvAccountRowEnter(ByVal RowIndex As Int32)
        Try
            dgvAccount.Rows(RowIndex).Selected = True
            Me.clsMyControlerAccount.DataGridView = Me.dgvAccount
            clsMyControlerAccount.SetControlsValue(RowIndex)
            clsDalContract.AAccountID = Convert.ToInt64(txtAAccountID.Text.Trim)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Private Sub dgvStoreRowEnter(ByVal RowIndex As Int32)
        Try
            dgvStore.Rows(RowIndex).Selected = True
            Me.clsMyControlerStore.DataGridView = Me.dgvStore
            clsMyControlerStore.SetControlsValue(RowIndex)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Private Sub dgvDeviceRowEnter(ByVal RowIndex As Int32)
        Try
            dgvDevice_Pos_DevicePos.Rows(RowIndex).Selected = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Private Sub dgvStoreTelRowEnter(ByVal RowIndex As Int32)
    '    Try
    '        dgvStoreTel.Rows(RowIndex).Selected = True
    '        StoreTelSetControlValues(StoreTelState.View)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
#End Region
#Region "Combos"
    Private Sub EnableSStateCity(ByVal bln As Boolean)
        cboSStateID.Enabled = bln
        cboSCityID.Enabled = bln
    End Sub
    'Private Sub EnableDAccount(ByVal bln As Boolean)
    '    cboDAccountTypeID.Enabled = bln
    '    txtDAccountNO_vc.Enabled = bln
    '    txtDCardNo_vc.Enabled = bln
    '    cboDBranchID.Enabled = bln
    'End Sub

#End Region
#Region "Rdos"
    Private Sub SetRdos()
        If rdoMaleGender_bit.Checked = False Then
            rdoFemaleGender_bit.Checked = True
        End If
        If rdoYesHavingAccount_bit.Checked = False Then
            rdoNoHavingAccount_bit.Checked = True
        End If
    End Sub
#End Region
#Region "Add-Edit-Cancel"
    Public Sub ContractPartyControls()
        txtShabaAccount.Enabled = True
        txtShabaAccount.ReadOnly = False
        txtCardNo_vc.Enabled = True
        txtCardNo_vc.ReadOnly = False
        txtAccountNO_vc.Enabled = True
        txtAccountNO_vc.ReadOnly = False
    End Sub
    Public Sub AccountControls()
        txtAShabaAccount.Enabled = True
        txtAShabaAccount.ReadOnly = False
        txtACardNo_vc.Enabled = True
        txtACardNo_vc.ReadOnly = False
        txtAAccountNO_vc.Enabled = True
        txtAAccountNO_vc.ReadOnly = False
    End Sub
    Private Sub Add()
        Try

            If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
                Try
                    ContractPartyControls()
                    clsDalContract.BeginProc()
                    'If blnForcePrint = True Then
                    '    ShowMessage(" ابتدا لیبل های قرارداد قبلی را چاپ نمایید ")
                    '    Exit Sub
                    'End If
                    ContractPartySelectedTab(False, RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
                    dtxtDate_vc.Value = modPublicMethod.GetDateNow
                    dtxtSaveDate_vc.Value = modPublicMethod.GetDateNow
                    rdoMaleGender_bit.Checked = True
                    rdoNoHavingAccount_bit.Checked = True
                    rdoHavingAccountCheckedChanged()
                    SetContractNo_Merchant(True)
                    FillContractNo_MerchantTextBox()
                    modPublicMethod.SelectAText(txtContractNo_vc)
                Catch ex As Exception
                    Throw ex
                Finally
                    clsDalContract.EndProc()
                End Try
            ElseIf Me.tbc.SelectedTab Is Me.tbpAccount Then
                AccountControls()
                AccountSelectedTab(False, RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
            ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
                StoreSelectedTab(False, RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add)
                txtSDeviceCount_tint.Text = 1

                newtxtSAddress_nvc.Text = Nothing
                '---cboSCity-cboSState
                ForceChooseOneSCityForOneContract()
            ElseIf Me.tbc.SelectedTab Is Me.tbpDevice Then
            End If

            cboDegreeID.SelectedValue = 109 'Diploma

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Edit()
        If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
            ContractPartySelectedTab(False, RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            dtxtDate_vc.Enabled = False
        ElseIf Me.tbc.SelectedTab Is Me.tbpAccount Then
            AccountSelectedTab(False, RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
            EditAccountBiz()
        ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
            StoreSelectedTab(False, RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit)
        ElseIf Me.tbc.SelectedTab Is Me.tbpDevice Then
        End If
    End Sub
    Private Sub EditAccountBiz()
        Try
            clsDalContract.BeginProc()
            Dim dt As New DataTable
            If txtAAccountID.Text.Trim <> "" Then
                If clsDalContract.CanThisAccountChangeManually(Convert.ToInt64(txtAAccountID.Text)) = True Then
                    Me.txtACardNo_vc.Enabled = True
                    Me.txtAAccountNO_vc.Enabled = True
                    Me.txtAShabaAccount.Enabled = True
                    Me.cboABranchID.Enabled = True
                    Me.cboAAccountTypeID.Enabled = True
                    Me.lblAAccountTypeID.Enabled = True
                    Me.lblABranchID.Enabled = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
    'Private Sub Fill_Befor()
    '    If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
    '        Email_Before = txtEmail_nvc.Text.Trim
    '    ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
    '        StoreName_Before = txtSName_nvc.Text.Trim
    '        StoreAddress_Before = txtSAddress_nvc.Text.Trim
    '        StorePostCode_Before = txtSPostCode_vc.Text.Trim
    '        StoreStateID_Before = cboSStateID.SelectedValue
    '        StoreCityID_Before = cboSCityID.SelectedValue
    '        StoreTel1_Before = txtSTel1_vc.Text.Trim
    '        StoreTel2_Before = txtSTel2_vc.Text.Trim
    '        StoreFax_Before = txtSFax_vc.Text.Trim
    '    End If
    'End Sub
    'Private Sub Fill_After()
    '    If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
    '        Email_After = txtEmail_nvc.Text.Trim
    '    ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
    '        StoreName_After = txtSName_nvc.Text.Trim
    '        StoreAddress_After = txtSAddress_nvc.Text.Trim
    '        StorePostCode_After = txtSPostCode_vc.Text.Trim
    '        'StoreStateName_After = cboSStateID.Text.Trim
    '        'StoreCityName_After = cboSCityID.Text.Trim
    '        StoreTel1_After = txtSTel1_vc.Text.Trim
    '        StoreTel2_After = txtSTel2_vc.Text.Trim
    '        StoreFax_After = txtSFax_vc.Text.Trim
    '    End If
    'End Sub
    'Private Sub Fill_Change()
    '    If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
    '        If Email_Before <> Email_After Then
    '            Email_Change = True
    '        Else
    '            Email_Change = False
    '        End If
    '    ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
    '        If StoreName_Before <> StoreName_After Then
    '            StoreName_Change = True
    '        Else
    '            StoreName_Change = False
    '        End If
    '        If StoreAddress_Before <> StoreAddress_After Then
    '            StoreAddress_Change = True
    '        Else
    '            StoreAddress_Change = False
    '        End If
    '        If StorePostCode_Before <> StorePostCode_After Then
    '            StorePostCode_Change = True
    '        Else
    '            StorePostCode_Change = False
    '        End If
    '        'If StoreStateName_Before <> StoreStateName_After Then
    '        '    StoreStateName_Change = True
    '        'Else
    '        '    StoreStateName_Change = False
    '        'End If
    '        'If StoreCityName_Before <> StoreCityName_After Then
    '        '    StoreCityName_Change = True
    '        'Else
    '        '    StoreCityName_Change = False
    '        'End If
    '        If StoreTel1_Before <> StoreTel1_After Then
    '            StoreTel1_Change = True
    '        Else
    '            StoreTel1_Change = False
    '        End If
    '        If StoreTel2_Before <> StoreTel2_After Then
    '            StoreTel2_Change = True
    '        Else
    '            StoreTel2_Change = False
    '        End If
    '        If StoreFax_Before <> StoreFax_After Then
    '            StoreFax_Change = True
    '        Else
    '            StoreFax_Change = False
    '        End If
    '    End If

    'End Sub
    Private Sub DoInsertChangeIfNeccessary(ByVal Merchant_vc As String, ByVal Outlet_vc As String, ByVal Email_Before As String, ByVal Email_After As String, ByVal StoreName_Before As String, ByVal StoreName_After As String, ByVal StoreAddress_Before As String, ByVal StoreAddress_After As String, ByVal StorePostCode_Before As String, ByVal StorePostCode_after As String, ByVal StoreStateID_Before As String, ByVal StoreStateID_after As String, ByVal StoreCityID_Before As String, ByVal StoreCityID_after As String, ByVal StoreTel1_Before As String, ByVal StoreTel1_After As String, ByVal StoreTel2_Before As String, ByVal StoreTel2_After As String, ByVal StoreFax_Before As String, ByVal StoreFax_After As String)
        Try
            If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
                If Email_Before = Email_After Then
                    'nothing
                Else
                    Me.clsDalContract.InsertChange(Merchant_vc, Outlet_vc, StoreName_Before, StoreName_After, StoreAddress_Before, StoreAddress_After, StorePostCode_Before, StorePostCode_after, StoreStateID_Before, StoreStateID_after, StoreCityID_Before, StoreCityID_after, StoreTel1_Before, StoreTel1_After, StoreTel2_Before, StoreTel2_After, StoreFax_Before, StoreFax_After, Email_Before, Email_After, GetDateNow)
                End If
            ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
                If StoreName_Before = StoreName_After AndAlso StoreAddress_Before = StoreAddress_After AndAlso StorePostCode_after = StorePostCode_Before AndAlso StoreTel1_Before = StoreTel1_After AndAlso StoreTel2_Before = StoreTel2_After AndAlso StoreFax_Before = StoreFax_After Then
                    'nothing
                Else
                    Me.clsDalContract.InsertChange(Merchant_vc, Outlet_vc, StoreName_Before, StoreName_After, StoreAddress_Before, StoreAddress_After, StorePostCode_Before, StorePostCode_after, StoreStateID_Before, StoreStateID_after, StoreCityID_Before, StoreCityID_after, StoreTel1_Before, StoreTel1_After, StoreTel2_Before, StoreTel2_After, StoreFax_Before, StoreFax_After, Email_Before, Email_Before, GetDateNow)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Cancel()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
            ContractPartySelectedTab(True, RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            clsMyControlerContractingParty.SetControlsValue()
            EnableTbpContractingParty(True)

        ElseIf Me.tbc.SelectedTab Is Me.tbpAccount Then
            AccountSelectedTab(True, RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            clsMyControlerAccount.SetControlsValue()
            EnableTbpAccount(True)

        ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
            StoreSelectedTab(True, RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            clsMyControlerStore.SetControlsValue()
            If Not String.IsNullOrEmpty(newtxtSAddressCode_nvc.Text) Then
                newtxtSAddress_nvc.Text = clsDalAddress.loadAddressDesc(newtxtSAddressCode_nvc.Text)
            Else
                newtxtSAddress_nvc.Text = Nothing
            End If
            EnableTbpStore(True)

        ElseIf Me.tbc.SelectedTab Is Me.tbpDevice Then
        End If
    End Sub
    Private Sub ContractPartySelectedTab(ByVal tbEnable As Boolean, ByVal FormState As RIZNARM.WINDOWS.FORMS.ClassFormController.FormState)
        Me.tbpAccount.Enabled = tbEnable
        Me.tbpStore.Enabled = tbEnable
        Me.tbpDevice.Enabled = tbEnable
        clsMyControlerContractingParty.DataGridView = Me.dgvContractingParty_Contract
        clsMyControlerContractingParty.GotoState(FormState)
        modPublicMethod.SelectAText(txtVisitorID)
        SetLinkBtn(Me.tbc.SelectedTab)
    End Sub
    Private Sub AccountSelectedTab(ByVal tbEnable As Boolean, ByVal FormState As RIZNARM.WINDOWS.FORMS.ClassFormController.FormState)
        Me.tbpContractingParty.Enabled = tbEnable
        Me.tbpStore.Enabled = tbEnable
        Me.tbpDevice.Enabled = tbEnable
        clsMyControlerAccount.DataGridView = Me.dgvAccount
        clsMyControlerAccount.GotoState(FormState)
        If FormState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add Then
            SetAccountInfoIfExist()
        End If
        SetLinkBtn(Me.tbc.SelectedTab)


    End Sub
    Private Sub SetAccountInfoIfExist()
        If rdoYesHavingAccount_bit.Checked = True Then
            If cboAccountTypeID.SelectedIndex >= 0 Then
                cboAAccountTypeID.SelectedValue = cboAccountTypeID.SelectedValue
            End If
            txtAAccountNO_vc.Text = txtAccountNO_vc.Text.Trim
            txtACardNo_vc.Text = txtCardNo_vc.Text.Trim
            txtAShabaAccount.Text = txtShabaAccount.Text.Trim
            If cboBranchID.SelectedIndex >= 0 Then
                cboABranchID.SelectedValue = cboBranchID.SelectedValue
            End If
        ElseIf rdoNoHavingAccount_bit.Checked = True Then
            cboAAccountTypeID.SelectedIndex = -1
            txtAAccountNO_vc.Text = String.Empty
            txtACardNo_vc.Text = String.Empty
            txtAShabaAccount.Text = String.Empty
            cboABranchID.SelectedIndex = -1
        End If
    End Sub
    Private Sub RefreshContractingParty()

        If txtAAccountNO_vc.Text.Trim = String.Empty Then
            Exit Sub
        End If
        rdoYesHavingAccount_bit.Checked = True
        If cboAccountTypeID.SelectedIndex >= 0 Then
            cboAccountTypeID.SelectedValue = cboAAccountTypeID.SelectedValue
        End If
        txtAccountNO_vc.Text = txtAAccountNO_vc.Text.Trim
        txtCardNo_vc.Text = txtACardNo_vc.Text.Trim
        txtShabaAccount.Text = txtAShabaAccount.Text.Trim
        If cboABranchID.SelectedIndex >= 0 Then
            cboBranchID.SelectedValue = cboABranchID.SelectedValue
        End If

    End Sub
    Private Sub StoreSelectedTab(ByVal tbEnable As Boolean, ByVal FormState As RIZNARM.WINDOWS.FORMS.ClassFormController.FormState)
        Me.tbpContractingParty.Enabled = tbEnable
        Me.tbpAccount.Enabled = tbEnable
        Me.tbpDevice.Enabled = tbEnable
        clsMyControlerStore.DataGridView = Me.dgvStore
        clsMyControlerStore.GotoState(FormState)
        modPublicMethod.SelectAText(txtSName_nvc)
        SetLinkBtn(Me.tbc.SelectedTab)

    End Sub
#End Region
#Region "Save"
    Private Sub Save()
        modPublicMethod.ErrorProviderClear(ErrorProvider)
        '-------------------------------------------------------------tbpContractingParty
        If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
            Try
                clsDalContract.BeginProc()
                If ContractingParty_ContraryValidate() = False Then
                    Exit Sub
                End If

                '----------------- ------------
                Select Case Me.clsMyControlerContractingParty.CurrentState
                    Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                        ContractingParty_ContractAlarm()
                        SetContractNo_Merchant(True)
                        FillContractNo_MerchantTextBox()
                    Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                        SetContractNo_Merchant(False)
                        FillContractNo_MerchantTextBox()
                End Select
                '---------------------------
                If CheckContractingParty_ContractRepeated() = True Then
                    Exit Sub
                End If

                Me.SaveContractingParty_Contract()
                ClassLogger.WriteEventLog("MMS", "SaveContractingParty_Contract,ContractID:" + clsDalContract.ContractID.ToString(), EventLogEntryType.Information, 11)

            Catch ex As Exception
                ShowErrorMessage(modApplicationMessage.msgSaveFailed)
                ClassError.LogError(ex)
            Finally
                EnableTbpContractingParty(True)
                Me.clsDalContract.EndProc()
            End Try
            '----------------------------------------------------------tbpAccount
        ElseIf Me.tbc.SelectedTab Is Me.tbpAccount Then
            Try
                clsDalContract.BeginProc()

                If AccountValidate() = False Then
                    Exit Sub
                End If


                Me.SaveAccount()
                ClassLogger.WriteEventLog("MMS", "SaveAccount(),ContractID:" + clsDalContract.ContractID.ToString() + "AccountID:" + clsDalContract.AAccountID.ToString(), EventLogEntryType.Information, 12)
                RefreshContractingParty()
            Catch ex As DuplicateNameException
                ShowErrorMessage(modApplicationMessage.msgSaveFailed)
                ClassError.LogError(ex)
            Finally
                EnableTbpAccount(True)
                clsDalContract.EndProc()
            End Try
            '---------------------------------------------------------tbpStore
        ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
            Try

                clsDalContract.BeginProc()

                Logger.Info("*****کاربر" & ClassUserLoginDataAccess.ThisUser.FullName_vc & "*****روز: " & GetPersianWeekDay(Today) & "*****ساعت: " & Format(Now, "HH:mm:ss"))
                If StoreValidate() = False Then
                    Exit Sub
                End If
                If StoreDBValidate() = False Then
                    Exit Sub
                End If

                If checkCityOfTejaratContract() Then
                    Exit Sub
                End If

                Select Case Me.clsMyControlerStore.CurrentState
                    Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                        StoreAlarm()
                End Select
                Me.SaveStore()
                ClassLogger.WriteEventLog("MMS", "SaveStore(),ContractID:" + clsDalContract.ContractID.ToString() + "StoreID:" + clsDalContract.SStoreID.ToString(), EventLogEntryType.Information, 13)
                StoreID = Nothing
                StoreID = clsDalContract.SStoreID
                clsDalContract.EndProc()
                CheckAddressToSave()
                '   Logger.Info("Save Store Correctly with ContractID:.........." & txtContractID.Text & "*******" & clsDalContract.newSAddressCode_nvc)
            Catch ex As DuplicateNameException
                ShowErrorMessage(modApplicationMessage.msgSaveFailed)
                ' Logger.Info("This is an error while Saveing Store with ContractID :.........." & txtContractID.Text & "**********" & clsDalContract.newSAddressCode_nvc)
            Finally
                EnableTbpStore(True)
                clsDalContract.EndProc()
            End Try
            '-------------------------------------------------------tbpDevice
        ElseIf Me.tbc.SelectedTab Is Me.tbpDevice Then
        End If
    End Sub
    Private Sub CheckAddressToSave()
        Try
            clsDalContract.BeginProc()
            clsDalContract.SStoreID = StoreID
            Dim new_address = clsDalContract.GetOneStore(clsDalContract.SStoreID).Rows(0)("newaddress_nvc").ToString
            If Not String.IsNullOrEmpty(new_address) Then
                Dim address = clsDalAddress.loadAddressDesc(CType(new_address, String))
            Else
                MessageBox.Show(" خطا در ثبت آدرس فروشگاه : ")
            End If
        Catch ex As Exception
            MessageBox.Show(" مشکل در ثبت  فروشگاه : " & vbCrLf & clsDalContract.SStoreID.ToString)
        Finally
            clsDalContract.EndProc()
            StoreID = Nothing
        End Try
    End Sub


    Private Function checkCityOfTejaratContract()
        Dim result As Boolean = False
        If clsCMSProject.CMSProjectID = 1 Then
            Try
                clsDALCity.BeginProc()
                clsDalContract.SCityID = cboSCityID.SelectedValue
                clsDALCity.CityID = clsDalContract.SCityID
                If String.IsNullOrEmpty(clsDALCity.GetByCityIDCheckShprkNO()) Then
                    ErrorProvider.SetError(cboSCityID, "کد شاپرک موجود نمی باشد")
                    result = True
                End If
            Catch ex As Exception
                ''Throw ex
            Finally
                clsDALCity.EndProc()
            End Try
        End If
        Return result
    End Function
    Private Function CheckContractingParty_ContractRepeated() As Boolean
        Dim res As Boolean = False
        Dim dtRepeated As New DataTable

        clsDalContract.Merchant_vc = txtMerchant_vc.Text.Trim
        clsDalContract.ContractNo_vc = txtContractNo_vc.Text.Trim

        dtRepeated = clsDalContract.GetByMerchantContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.ProjectID)
        Select Case Me.clsMyControlerContractingParty.CurrentState
            Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                If dtRepeated.Rows.Count > 0 Then
                    Me.ErrorProvider.SetError(Me.txtMerchant_vc, "شماره قرارداد PSP تکراری است")
                    res = True
                Else
                    Me.ErrorProvider.SetError(Me.txtMerchant_vc, "")
                End If
            Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                If dtRepeated.Rows.Count = 1 Then
                    If dtRepeated.Rows(0).Item("ContractID") <> txtContractID.Text Then
                        Me.ErrorProvider.SetError(Me.txtMerchant_vc, "شماره قرارداد PSP تکراری است")
                        res = True
                    Else
                        Me.ErrorProvider.SetError(Me.txtMerchant_vc, "")
                    End If
                ElseIf dtRepeated.Rows.Count > 1 Then
                    Me.ErrorProvider.SetError(Me.txtMerchant_vc, "شماره قرارداد PSP تکراری است")
                    res = True
                Else
                    Me.ErrorProvider.SetError(Me.txtMerchant_vc, "")
                End If
        End Select


        dtRepeated.Clear()
        dtRepeated = clsDalContract.GetByContractNoContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.ProjectID)
        Select Case Me.clsMyControlerContractingParty.CurrentState
            Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                If dtRepeated.Rows.Count > 0 Then
                    Me.ErrorProvider.SetError(Me.txtContractNo_vc, "شماره قرارداد  تکراری است")
                    res = True
                Else
                    Me.ErrorProvider.SetError(Me.txtContractNo_vc, "")
                End If
            Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                If dtRepeated.Rows.Count = 1 Then
                    If dtRepeated.Rows(0).Item("ContractID") <> txtContractID.Text Then
                        Me.ErrorProvider.SetError(Me.txtContractNo_vc, "شماره قرارداد  تکراری است")
                        res = True
                    Else
                        Me.ErrorProvider.SetError(Me.txtContractNo_vc, "")
                    End If
                ElseIf dtRepeated.Rows.Count > 1 Then
                    Me.ErrorProvider.SetError(Me.txtContractNo_vc, "شماره قرارداد  تکراری است")
                    res = True
                Else
                    Me.ErrorProvider.SetError(Me.txtContractNo_vc, "")
                End If
        End Select

        Return res
    End Function
    Private Sub SaveContractingParty_Contract()
        Try
            If txtContractingID.Text.Trim <> "" Then
                clsDalContract.ContractingPartyID = Convert.ToInt64(txtContractingID.Text.Trim)
            End If
            clsDalContract.FirstName_nvc = IIf(txtFirstName_nvc.Text.Trim = "", String.Empty, txtFirstName_nvc.Text.Trim)
            clsDalContract.LastName_nvc = IIf(txtLastName_nvc.Text.Trim = "", String.Empty, txtLastName_nvc.Text.Trim)
            clsDalContract.FatherName_nvc = IIf(txtFatherName_nvc.Text.Trim = "", String.Empty, txtFatherName_nvc.Text.Trim)
            clsDalContract.IdentityCertificateNO_nvc = IIf(txtIdentityCertificateNO_nvc.Text.Trim = "", String.Empty, txtIdentityCertificateNO_nvc.Text.Trim)
            clsDalContract.NationalCode_nvc = IIf(txtNationalCode_nvc.Text.Trim = "", String.Empty, txtNationalCode_nvc.Text.Trim)
            clsDalContract.Gender_bit = IIf(rdoFemaleGender_bit.Checked = True, 0, 1)
            clsDalContract.BirthDate_vc = IIf(dtxtBirthDate_vc.Value = "", String.Empty, dtxtBirthDate_vc.Value)
            clsDalContract.StateID = IIf(cboStateID.SelectedIndex = -1, -1, cboStateID.SelectedValue)
            clsDalContract.CityID = IIf(cboCityID.SelectedIndex = -1, -1, cboCityID.SelectedValue)
            clsDalContract.CIdentityTypeID = IIf(cboCIdentityTypeID.SelectedIndex = -1, -1, cboCIdentityTypeID.SelectedValue)
            clsDalContract.DegreeID = IIf(cboDegreeID.SelectedIndex = -1, -1, cboDegreeID.SelectedValue)
            clsDalContract.Title_nvc = IIf(cboTitle_nvc.Text = "", String.Empty, cboTitle_nvc.Text)
            clsDalContract.HomeAddress_nvc = IIf(txtHomeAddress_nvc.Text.Trim = "", String.Empty, txtHomeAddress_nvc.Text.Trim)
            clsDalContract.HomeTel_vc = IIf(txtHomeTel_vc.Text.Trim = "", String.Empty, txtHomeTel_vc.Text.Trim)
            clsDalContract.Mobile_vc = String.Empty
            clsDalContract.Email_nvc = IIf(txtEmail_nvc.Text.Trim = "", String.Empty, txtEmail_nvc.Text.Trim)
            clsDalContract.HavingAccount_bit = IIf(rdoYesHavingAccount_bit.Checked = True, 1, 0)
            If rdoYesHavingAccount_bit.Checked = True And chkCMSProject.SelectedValue <> My.Settings.Fanava_CmsProjectID Then

                clsDalContract.AccountTypeID = IIf(cboAccountTypeID.SelectedIndex = -1, -1, cboAccountTypeID.SelectedValue)
                clsDalContract.AccountNO_vc = IIf(txtAccountNO_vc.Text.Trim = "", String.Empty, txtAccountNO_vc.Text.Trim)
                clsDalContract.ShabaAccount = IIf(txtShabaAccount.Text.Trim = String.Empty, String.Empty, txtShabaAccount.Text.Trim)
                clsDalContract.CardNo_vc = IIf(txtCardNo_vc.Text.Trim = "", String.Empty, txtCardNo_vc.Text.Trim)
                clsDalContract.BranchID = IIf(cboBranchID.SelectedIndex = -1, -1, cboBranchID.SelectedValue)

            ElseIf rdoYesHavingAccount_bit.Checked = True And chkCMSProject.SelectedValue = My.Settings.Fanava_CmsProjectID Then

                clsDalContract.AccountTypeID = My.Settings.Fanava_AccountTypeID.Trim
                clsDalContract.AccountNO_vc = IIf(txtAccountNO_vc.Text.Trim = "", String.Empty, txtAccountNO_vc.Text.Trim)
                clsDalContract.ShabaAccount = IIf(txtShabaAccount.Text.Trim = String.Empty, String.Empty, txtShabaAccount.Text.Trim)
                clsDalContract.CardNo_vc = IIf(txtCardNo_vc.Text.Trim = "", String.Empty, txtCardNo_vc.Text.Trim)
                clsDalContract.BranchID = My.Settings.Fanava_BranchID.Trim

            Else

                clsDalContract.AccountTypeID = -1
                clsDalContract.AccountNO_vc = String.Empty
                clsDalContract.ShabaAccount = String.Empty
                clsDalContract.CardNo_vc = String.Empty
                clsDalContract.BranchID = -1
            End If
            If txtContractID.Text.Trim <> "" Then
                clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
            End If
            clsDalContract.VisitorID = Convert.ToInt32(txtVisitorID.Text.Trim)
            clsDalContract.Date_vc = IIf(dtxtDate_vc.Value.Trim = "", String.Empty, dtxtDate_vc.Value.Trim)
            clsDalContract.Merchant_vc = IIf(txtMerchant_vc.Text.Trim = "", String.Empty, txtMerchant_vc.Text.Trim)
            clsDalContract.SaveDate_vc = IIf(dtxtSaveDate_vc.Value.Trim = "", String.Empty, dtxtSaveDate_vc.Value.Trim)
            clsDalContract.ContractNo_vc = IIf(txtContractNo_vc.Text = "", String.Empty, txtContractNo_vc.Text)
            clsDalContract.MarketingByID = IIf(cboMarketingByID.SelectedIndex = -1, -1, cboMarketingByID.SelectedValue)
            clsDalContract.ZoncanNo_nvc = IIf(txtZoncanNo_nvc.Text.Trim = "", String.Empty, txtZoncanNo_nvc.Text.Trim)
            clsDalContract.ProjectID = ClassUserLoginDataAccess.ThisUser.ProjectID

            Select Case Me.clsMyControlerContractingParty.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    DoInsertContractingParty_Contract()
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    DoChange()
                    DoUpdateContractingParty_Contract()
            End Select
            dtContractingParty_Contract.AcceptChanges()
            Select Case Me.clsMyControlerContractingParty.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    blnForcePrint = True
            End Select
        Catch ex As Exception
            dtContractingParty_Contract.RejectChanges()
            Throw ex
            Exit Sub
        End Try

        Me.clsMyControlerContractingParty.DataGridView = dgvContractingParty_Contract
        Me.clsMyControlerContractingParty.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.tbpAccount.Enabled = True
        Me.tbpStore.Enabled = True
        Me.tbpDevice.Enabled = True
    End Sub
    Private Sub DoChange()
        Dim dtChange As New DataTable
        Try
            'Fill_After()
            'Fill_Change()
            If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
                dtChange = clsDalContract.GetOutletAndMerchantByContractingPartyID(Convert.ToInt64(txtContractingID.Text.Trim), ClassUserLoginDataAccess.ThisUser.ProjectID)
                If dtChange.Rows.Count > 0 Then
                    For i As Integer = 0 To dtChange.Rows.Count - 1
                        If IsDBNull(dtChange.Rows(i).Item("StoreFax_vc")) = True Then
                            dtChange.Rows(i).Item("StoreFax_vc") = String.Empty
                        End If

                        DoInsertChangeIfNeccessary(dtChange.Rows(i).Item("Merchant_vc").ToString, dtChange.Rows(i).Item("Outlet_vc").ToString, dtChange.Rows(i).Item("ContractingPartyEmail_nvc").ToString, txtEmail_nvc.Text.Trim, dtChange.Rows(i).Item("StoreName_nvc").ToString, dtChange.Rows(i).Item("StoreName_nvc").ToString, dtChange.Rows(i).Item("StoreAddress_nvc").ToString, dtChange.Rows(i).Item("StoreAddress_nvc").ToString, dtChange.Rows(i).Item("StorePostCode_vc").ToString, dtChange.Rows(i).Item("StorePostCode_vc").ToString, dtChange.Rows(i).Item("StoreStateID").ToString, dtChange.Rows(i).Item("StoreStateID").ToString, dtChange.Rows(i).Item("StoreCityID").ToString, dtChange.Rows(i).Item("StoreCityID").ToString, dtChange.Rows(i).Item("StoreTel1_vc").ToString, dtChange.Rows(i).Item("StoreTel1_vc").ToString, dtChange.Rows(i).Item("StoreTel2_vc").ToString, dtChange.Rows(i).Item("StoreTel2_vc").ToString, dtChange.Rows(i).Item("StoreFax_vc").ToString, dtChange.Rows(i).Item("StoreFax_vc"))
                    Next
                End If
            ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
                dtChange = clsDalContract.GetOutletAndMerchantByStoreID(Convert.ToInt64(txtSStoreID.Text.Trim), ClassUserLoginDataAccess.ThisUser.ProjectID)
                If dtChange.Rows.Count > 0 Then
                    For i As Integer = 0 To dtChange.Rows.Count - 1
                        DoInsertChangeIfNeccessary(dtChange.Rows(i).Item("Merchant_vc").ToString, dtChange.Rows(i).Item("Outlet_vc").ToString, dtChange.Rows(i).Item("ContractingPartyEmail_nvc").ToString, dtChange.Rows(i).Item("ContractingPartyEmail_nvc").ToString, dtChange.Rows(i).Item("StoreName_nvc").ToString, txtSName_nvc.Text.Trim, dtChange.Rows(i).Item("StoreAddress_nvc").ToString, txtSAddress_nvc.Text.Trim, dtChange.Rows(i).Item("StorePostCode_vc").ToString, txtSPostCode_vc.Text.Trim, dtChange.Rows(i).Item("StoreStateID").ToString, dtChange.Rows(i).Item("StoreStateID").ToString, dtChange.Rows(i).Item("StoreCityID").ToString, dtChange.Rows(i).Item("StoreCityID").ToString, dtChange.Rows(i).Item("StoreTel1_vc").ToString, txtSTel1_vc.Text.Trim, dtChange.Rows(i).Item("StoreTel2_vc").ToString, txtSTel2_vc.Text.Trim, dtChange.Rows(i).Item("StoreFax_vc").ToString, txtSFax_vc.Text.Trim)
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveAccount()
        If txtAAccountID.Text.Trim <> "" Then
            clsDalContract.AAccountID = Convert.ToInt64(txtAAccountID.Text.Trim)
        End If
        clsDalContract.ContractID = txtContractID.Text.Trim
        clsDalContract.AAccountNO_vc = txtAAccountNO_vc.Text.Trim
        clsDalContract.ACardNo_vc = txtACardNo_vc.Text.Trim
        If (cboAAccountTypeID.Visible = True And cboAAccountTypeID.DataSource IsNot Nothing) Then
            clsDalContract.AFinancialSupervisionId = cboAFinancialSupervisionId.SelectedValue
        End If


        If OldShebaAccount <> txtAShabaAccount.Text.Trim Then

            If Me.clsMyControlerContractingParty.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add Then
                clsDalContract.issenttoshprk = "2"
            Else
                clsDalContract.issenttoshprk = "1"
            End If

            clsDalContract.AShabaAccountold = CurrentShebaAccount.Trim
        Else
            clsDalContract.issenttoshprk = "2"
            clsDalContract.AShabaAccountold = OldShebaAccount
        End If
        clsDalContract.AShabaAccount = txtAShabaAccount.Text.Trim

        clsDalContract.AAccountTypeID = IIf(cboAAccountTypeID.SelectedIndex = -1, -1, cboAAccountTypeID.SelectedValue)
        clsDalContract.ABranchID = cboABranchID.SelectedValue
        Try
            Select Case Me.clsMyControlerAccount.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    DoInsertAccount()
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    DoUpdateAccount()
                    'mirmobin

                    If clsCMSProject.IsSent2Switch = 1 Then
                        'If myConStr.ConnectionAvailable(clsCMSProject.ESSWS_NVC) Then
                        Me.SaveAccount_ToSwitch_Svc(clsCMSProject.ESSWS_NVC)
                        'Else
                        '    ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
                        'End If
                    End If
            End Select
            dtAccount.AcceptChanges()
        Catch ex As Exception
            dtAccount.RejectChanges()
            Throw ex
            Exit Sub
        End Try

        Me.clsMyControlerAccount.DataGridView = dgvAccount
        Me.clsMyControlerAccount.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.tbpContractingParty.Enabled = True
        Me.tbpStore.Enabled = True
        Me.tbpDevice.Enabled = True
    End Sub
    Private Sub SaveAccount_ToSwitch_Svc(ByVal murl As String)
        Try
            Dim dt As New DataTable
            Dim proxy As New AcceptorManagementService.AcceptorManagementServiceService()
            Dim getCardAcceptorDetail As New AcceptorManagementService.getCardAcceptorDetailByTerminalID
            Dim getCardAcceptorDetailResponse As New AcceptorManagementService.getCardAcceptorDetailByTerminalIDResponse
            Dim modifyCardAcceptor As New AcceptorManagementService.modifyCardAcceptor
            Dim modifyCardAcceptorRequest As New AcceptorManagementService.acceptorManagementRq
            Dim modifyCardAcceptorResponse As New AcceptorManagementService.modifyCardAcceptorResponse

            dt = clsDalContract.GetTerminalIDByContractID(Convert.ToInt64(txtContractID.Text.Trim)) '"P1905531"

            CheckConnection(murl)



            If dt.Rows.Count <= 0 Then
                Exit Sub
            Else
                For index As Integer = 0 To dt.Rows.Count - 1
                    getCardAcceptorDetail.TerminalID = dt.Rows(index).Item(0).ToString()

                    getCardAcceptorDetailResponse = proxy.getCardAcceptorDetailByTerminalID(getCardAcceptorDetail)
                    modifyCardAcceptorRequest.cardAcceptor = getCardAcceptorDetailResponse.return.cardAcceptor
                    modifyCardAcceptorRequest.cardAcceptor.setlAcnt.externalAccountNumber = txtAAccountNO_vc.Text.Trim
                    modifyCardAcceptorRequest.cardAcceptor.setlAcnt.externalAccountIban = txtAShabaAccount.Text.Trim

                    ' modifyCardAcceptorRequest.cardAcceptor.inst = New institutionDTO()
                    ' modifyCardAcceptorRequest.cardAcceptor.inst.institutionCity = "Taas"

                    modifyCardAcceptor.AcceptorManagementRq = modifyCardAcceptorRequest
                    modifyCardAcceptorResponse = proxy.modifyCardAcceptor(modifyCardAcceptor)

                Next

            End If

        Catch ex As Exception
            ' ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
            ClassError.LogError(ex)
        End Try

    End Sub
    Private Sub SaveStore()

        If txtSStoreID.Text.Trim <> "" Then
            clsDalContract.SStoreID = Convert.ToInt64(txtSStoreID.Text.Trim)
        End If
        clsDalContract.AAccountID = Convert.ToInt64(txtAAccountID.Text.Trim)
        clsDalContract.SGroupID = cboSGroupID.SelectedValue
        clsDalContract.SLicenseID = cboSLicense.SelectedValue
        clsDalContract.SSupplementary = cboSSupplementary.SelectedValue
        clsDalContract.SStateID = cboSStateID.SelectedValue
        clsDalContract.SCityID = cboSCityID.SelectedValue
        clsDalContract.SName_nvc = txtSName_nvc.Text.Trim
        clsDalContract.SPostCode_vc = txtSPostCode_vc.Text.Trim
        If String.IsNullOrEmpty(txtSAddress_nvc.Text.Trim) Then
            clsDalContract.SAddress_nvc = newtxtSAddress_nvc.Text.Trim
        Else
            clsDalContract.SAddress_nvc = txtSAddress_nvc.Text.Trim
        End If

        clsDalContract.newSAddress_nvc = newtxtSAddress_nvc.Text.Trim
        clsDalContract.newSAddressCode_nvc = newtxtSAddressCode_nvc.Text.Trim
        clsDalContract.Address3_nvc = clsDalAddress.loadAddressDesc(clsDalContract.newSAddressCode_nvc)
        clsDalContract.STel1_vc = txtSTel1_vc.Text.Trim
        clsDalContract.STel2_vc = txtSTel2_vc.Text.Trim


        clsDalContract.SFax_vc = txtSFax_vc.Text.Trim
        clsDalContract.SMunicipalAreaNO_sint = Convert.ToInt16(ntxtSMunicipalAreaNO_sint.Text.Trim)
        clsDalContract.SEstateConditionID = IIf(cboSEstateConditionID.SelectedIndex = -1, -1, cboSEstateConditionID.SelectedValue)
        clsDalContract.SSIdentityTypeID = cboSSIdentityTypeID.SelectedValue
        clsDalContract.SSIdentityTypeSDate_vc = dtxtSSIdentityTypeSDate_vc.Value
        clsDalContract.SSIdentityTypeEDate_vc = dtxtSSIdentityTypeEDate_vc.Value
        clsDalContract.SDeviceCount_tint = Convert.ToInt32(txtSDeviceCount_tint.Text.Trim)

        clsDalContract.StorePosModelID = cboStorePosModel.SelectedValue

        Logger.Info("newSAddress_nvc....." & clsDalContract.newSAddress_nvc)

        Try
            clsDALCity.BeginProc()
            clsDALCity.StateID = clsDalContract.SStateID
            clsDALCity.CityID = clsDalContract.SCityID
            If clsDALCity.GetByStateIDAndCityIDCity().Rows.Count = 0 Then
                ShowErrorMessage("ثبت شهر و استان دچار مشكل شده است")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        Finally
            clsDALCity.EndProc()
        End Try

        Try
            Select Case Me.clsMyControlerStore.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    Dim res As Boolean = DoInsertStore()
                    If res = False Then
                        Exit Sub
                    End If
                    Logger.Info("Insert StoreID..........................." + txtSStoreID.Text)
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    DoChange()
                    DoUpdateStore()
                    Logger.Info("Update StoreID..........................." + txtSStoreID.Text)

                    'If clsCMSProject.IsSent2Switch Then
                    '    'If myConStr.ConnectionAvailable(clsCMSProject.ESSWS_NVC) Then
                    '    Me.SaveStore_toSwtich_Svc(clsCMSProject.ESSWS_NVC)
                    '    'Else
                    '    '    ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
                    '    'End If
                    'End If

                    'If clsCMSProject.CMSProjectID = 1 Then
                    '    SaveStore_toSwtich_Svc()
                    'Else
                    '    Logger.Info("Not Need To Save In Switch")
                    'End If

            End Select
            dtStore.AcceptChanges()
        Catch ex As Exception
            Logger.Info("dtStore.RejectChanges...." & ex.ToString)
            dtStore.RejectChanges()
            Throw ex
            Exit Sub
        End Try

        Me.clsMyControlerStore.DataGridView = dgvStore
        Me.clsMyControlerStore.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.tbpContractingParty.Enabled = True
        Me.tbpAccount.Enabled = True
        Me.tbpDevice.Enabled = True

    End Sub
    Private Sub SaveStore_toSwtich_Svc(ByVal murl As String)
        Try
            Dim dt As New DataTable

            Dim intitue As New AcceptorManagementService.institutionDTO
            Dim modifyCardAcceptorRequest As New AcceptorManagementService.acceptorManagementRq
            Dim proxy As New AcceptorManagementService.AcceptorManagementServiceService()
            Dim getCardAcceptorDetail As New AcceptorManagementService.getCardAcceptorDetailByTerminalID
            Dim getCardAcceptorDetailResponse As New AcceptorManagementService.getCardAcceptorDetailByTerminalIDResponse

            Dim modifyCardAcceptorResponse As New AcceptorManagementService.modifyCardAcceptorResponse
            Dim modifyCardAcceptor As New AcceptorManagementService.modifyCardAcceptor

            'dt = clsDalContract.GetTerminalIDByContractID(Convert.ToInt64(txtContractID.Text.Trim)) '"P1905531"

            dt = Me.clsDalContract.GetByStoreIDDevice()
            'If Not (dt Is Nothing) Then
            '    If Not (dt.Rows Is Nothing) Then
            '        Logger.Info("dt row is null")
            '        Exit Sub
            '    End If
            'End If
            CheckConnection(murl)


            If dt.Rows.Count <= 0 Then
                Exit Sub
            Else
                'For index As Integer = 0 To dt.Rows.Count - 1

                'getCardAcceptorDetail.TerminalID = dt.Rows(index).Item(0).ToString()
                getCardAcceptorDetail.TerminalID = dt.Rows(0).Item("DOutlet_vc").ToString()

                getCardAcceptorDetailResponse = proxy.getCardAcceptorDetailByTerminalID(getCardAcceptorDetail)
                modifyCardAcceptorRequest.cardAcceptor = getCardAcceptorDetailResponse.return.cardAcceptor

                If (newtxtSAddress_nvc.Text.Length > 63) Then
                    intitue.institutionAddress = newtxtSAddress_nvc.Text.Substring(0, 63)
                Else
                    intitue.institutionAddress = newtxtSAddress_nvc.Text.Trim
                End If
                '///////moslehi  93/05/22

                If (newtxtSAddressCode_nvc.Text.Length > 99) Then
                    intitue.institutionAddress = newtxtSAddressCode_nvc.Text.Substring(0, 99)
                Else
                    intitue.institutionAddress = newtxtSAddressCode_nvc.Text.Trim
                End If
                '//////////
                intitue.institutionLatinAddress = ConvertMethods.FaToEnFirstLineString(intitue.institutionAddress)

                If (txtSName_nvc.Text.Trim.Length > 63) Then
                    intitue.institutionName = txtSName_nvc.Text.Substring(0, 63)
                Else
                    intitue.institutionName = txtSName_nvc.Text.Trim
                End If
                intitue.institutionLatinName = ConvertMethods.FaToEnFirstLineString(intitue.institutionName)

                modifyCardAcceptorRequest.cardAcceptor.businessCode = cboSGroupID.SelectedValue.ToString


                modifyCardAcceptorRequest.cardAcceptor.inst = intitue
                modifyCardAcceptor.AcceptorManagementRq = modifyCardAcceptorRequest


                modifyCardAcceptorResponse = proxy.modifyCardAcceptor(modifyCardAcceptor)
                'Next
            End If
            Logger.Info("Store in Switch with StoreID.................................." + txtSStoreID.Text)

        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
            Logger.Info("بروز خطا در وب سرویس" + txtSStoreID.Text)
        End Try

    End Sub
    'Private Sub SaveDevice()
    '    Try
    '        'Me.clsDalContract.BeginProc()
    '        Try
    '            Select Case Me.clsMyControlerDevice.CurrentState
    '                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
    '                    SetCodes(True)
    '                    FillDeviceCodeTextBoxes()
    '                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
    '                    SetCodes(False)
    '                    FillDeviceCodeTextBoxes()
    '            End Select
    '        Catch ex As Exception
    '            Throw ex
    '            Exit Sub
    '        End Try

    '        If txtDDeviceID.Text.Trim <> "" Then
    '            clsDalContract.DDeviceID = Convert.ToInt64(txtDDeviceID.Text.Trim)
    '        End If
    '        clsDalContract.DAccountTypeID = IIf(cboDAccountTypeID.SelectedIndex = -1, -1, cboDAccountTypeID.SelectedValue)
    '        clsDalContract.DAccountNO_vc = txtDAccountNO_vc.Text.Trim
    '        clsDalContract.DCardNo_vc = txtDCardNo_vc.Text.Trim
    '        clsDalContract.DBranchID = cboDBranchID.SelectedValue
    '        clsDalContract.DCode_vc = txtDCode_vc.Text.Trim
    '        clsDalContract.DSerial_vc = txtDSerial_vc.Text.Trim
    '        clsDalContract.DPropertyNO_vc = txtDPropertyNO_vc.Text.Trim
    '        clsDalContract.DPassword_vc = txtDPassword_vc.Text.Trim
    '        clsDalContract.DOutlet_vc = txtDOutlet_vc.Text.Trim
    '        clsDalContract.DVat_vc = txtDVat_vc.Text.Trim
    '        clsDalContract.DMerchant_vc = txtDMerchant_vc.Text.Trim
    '        clsDalContract.DEniacCode_vc = txtDEniacCode_vc.Text.Trim
    '        clsDalContract.DSentAccounting_tint = 0
    '        clsDalContract.DSentSwitch_tint = 0
    '        clsDalContract.DSentInstalling_tint = 0
    '        clsDalContract.DEniacCode_vc = txtDEniacCode_vc.Text.Trim

    '        clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
    '        Select Case Me.clsMyControlerDevice.CurrentState
    '            Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
    '                DoInsertDevice()
    '            Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
    '                DoUpdateDevice()
    '        End Select
    '        dtDevice.AcceptChanges()
    '    Catch ex As Exception
    '        dtDevice.RejectChanges()
    '        Throw ex
    '        Exit Sub
    '    Finally
    '        'Me.clsDalContract.EndProc()
    '    End Try


    '    Me.clsMyControlerDevice.DataGridView = dgvDevice
    '    Me.clsMyControlerDevice.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
    '    Me.tbpContractingParty.Enabled = True
    '    Me.tbpStore.Enabled = True
    'End Sub
    'Private Sub UpdateAllDevicesAccountForAStore()
    '    For i As Int32 = 0 To dgvDevice.Rows.Count - 1
    '        clsDalContract.DDeviceID = dgvDevice.Rows(i).Cells("colDDeviceID").Value
    '        clsDalContract.DAccountTypeID = IIf(cboDAccountTypeID.SelectedIndex = -1, -1, cboDAccountTypeID.SelectedValue)
    '        clsDalContract.DAccountNO_vc = txtDAccountNO_vc.Text.Trim
    '        clsDalContract.DCardNo_vc = txtDCardNo_vc.Text.Trim
    '        clsDalContract.DBranchID = cboDBranchID.SelectedValue
    '        DoUpdateDevice_Accounting()

    '    Next
    'End Sub
    Private Function ContractingParty_ContraryValidate()
        Dim res As Boolean = True
        Dim isPostBank As Boolean = False
        Dim ischecked As Boolean = False

        Dim dt As New DataTable
        dt = clsContractAndCMS.GetByContractID()

        If txtContractNo_vc.Text.Trim = "" Then
            ErrorProvider.SetError(txtContractNo_vc, "شماره قرارداد را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtContractNo_vc, "")
        End If
        If dtxtDate_vc.Value.Length = 0 Then
            ErrorProvider.SetError(dtxtDate_vc, "تاریخ را وارد کنید")
            res = False
        ElseIf dtxtDate_vc.Value > modPublicMethod.GetDateNow Then
            ErrorProvider.SetError(dtxtDate_vc, "تاریخ نمی تواند بزرگتر از تاریخ روز جاری باشد")
            res = False
        Else
            ErrorProvider.SetError(dtxtDate_vc, "")
        End If
        If txtFirstName_nvc.Text.Trim = "" Then
            ErrorProvider.SetError(txtFirstName_nvc, "نام  را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtFirstName_nvc, "")
        End If
        If txtLastName_nvc.Text.Trim = "" Then
            ErrorProvider.SetError(txtLastName_nvc, "نام خانوادگی را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtLastName_nvc, "")
        End If
        If txtFatherName_nvc.Text.Trim = "" Then
            ErrorProvider.SetError(txtFatherName_nvc, "نام پدر را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtFatherName_nvc, "")
        End If
        If txtIdentityCertificateNO_nvc.Text.Trim = "" Then
            ErrorProvider.SetError(txtIdentityCertificateNO_nvc, "شماره شناسنامه را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtIdentityCertificateNO_nvc, "")
        End If
        If txtNationalCode_nvc.Text.Trim = "" Then
            ErrorProvider.SetError(txtNationalCode_nvc, "کد ملی را وارد کنید")
            res = False
        Else
            If txtNationalCode_nvc.Text.Trim.Length <> 10 Then
                ErrorProvider.SetError(txtNationalCode_nvc, "کد 10 رقمي نيست")
                res = False
            Else
                If modPublicMethod.Code_Melli(txtNationalCode_nvc.Text) = 0 Then
                    ErrorProvider.SetError(txtNationalCode_nvc, "کد ملی نامعتبر می باشد")
                    res = False
                Else
                    ErrorProvider.SetError(txtNationalCode_nvc, "")
                End If
            End If
        End If

        If cboStateID.Text.Trim = "" Then
            ErrorProvider.SetError(cboStateID, "استان را انتخاب کنید")
            res = False
        Else
            ErrorProvider.SetError(cboStateID, "")
        End If
        If cboCityID.Text.Trim = "" Then
            ErrorProvider.SetError(cboCityID, "شهر را انتخاب کنید")
            res = False
        Else
            ErrorProvider.SetError(cboCityID, "")
        End If
        If cboCIdentityTypeID.SelectedIndex = -1 Then
            ErrorProvider.SetError(cboCIdentityTypeID, "مدرک شناسایی را انتخاب کنید")
            res = False
        Else
            ErrorProvider.SetError(cboCIdentityTypeID, "")
        End If
        If cboMarketingByID.SelectedIndex = -1 Then
            ErrorProvider.SetError(cboMarketingByID, "بازاریابی را انتخاب کنید")
            res = False
        Else
            ErrorProvider.SetError(cboMarketingByID, "")
        End If

        If txtVisitorID.Text.Trim = "" Then
            ErrorProvider.SetError(txtVisitorID, "بازاریاب را وارد کنید")
            res = False
        Else
            If CheckVisitorID(Convert.ToInt32(txtVisitorID.Text), "") = False Then
                ErrorProvider.SetError(txtVisitorID, modApplicationMessage.msgInvalidID)
                res = False
            Else
                ErrorProvider.SetError(txtVisitorID, "")
            End If
        End If



        If chkCMSProject.CheckedItems.Count <= 0 Then
            ErrorProvider.SetError(chkCMSProject, "نام بانک انتخاب شود")
            res = False
        End If



        If rdoYesHavingAccount_bit.Checked = True Then
            If cboBranchID.SelectedIndex = -1 Then
                ErrorProvider.SetError(cboBranchID, "شعبه را انتخاب کنید")
                res = False
            Else
                ErrorProvider.SetError(cboBranchID, "")
            End If




            If txtAccountNO_vc.Text.Trim = "" Then
                ErrorProvider.SetError(txtAccountNO_vc, "شماره حساب را وارد کنید")
                res = False
            Else

                For intCounter As Integer = 0 To Me.chkCMSProject.CheckedItems.Count - 1
                    clsCMSProject = chkCMSProject.CheckedItems(intCounter)
                    If clsCMSProject.CMSProjectID = 3 Then
                        isPostBank = True
                    End If
                Next


                If isPostBank = False And clsCMSProject.CMSProjectID = 1 Then

                    If (txtAccountNO_vc.MaxLength = 10 And txtAccountNO_vc.Text.Trim.Length <> 10) Then
                        ErrorProvider.SetError(txtAccountNO_vc, "شماره حساب باید 10 رقمی باشد")
                        res = False
                    Else
                        If modPublicMethod.CheckAccountNo(txtAccountNO_vc.Text.Trim) = False Then
                            ErrorProvider.SetError(txtAccountNO_vc, "شماره حساب نامعتبر است")
                            res = False
                        Else
                            ErrorProvider.SetError(txtAccountNO_vc, "")
                        End If
                    End If

                End If

            End If



            'ElseIf rdoNoHavingAccount_bit.Checked = True Then
            '    If dtxtBirthDate_vc.Value.Length = 0 Then
            '        ErrorProvider.SetError(dtxtBirthDate_vc, "تاریخ تولد را وارد کنید")
            '        res = False
            '    Else
            '        ErrorProvider.SetError(dtxtBirthDate_vc, "")
            '    End If
        End If

        If dtxtBirthDate_vc.Value.Length = 0 Then
            ErrorProvider.SetError(dtxtBirthDate_vc, "تاریخ تولد را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(dtxtBirthDate_vc, "")
        End If

        If rdoYesHavingAccount_bit.Checked = True Then
            If ShabaAccountValidation(txtShabaAccount.Text, txtShabaAccount) = False Then
                res = False
            End If
        End If

        Return res
    End Function
    Private Sub ContractingParty_ContractAlarm()
        Dim dt As New DataTable
        clsDalContract.NationalCode_nvc = txtNationalCode_nvc.Text.Trim
        dt = clsDalContract.GetByNationalCodeContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.UserID)
        If dt.Rows.Count > 0 Then
            ShowErrorMessage(" کد ملی وارد شده در سیستم موجود است ")
        End If
    End Sub
    Private Function AccountValidate()
        Dim res As Boolean = True
        Dim isPostBank As Boolean = False

        If cboABranchID.SelectedIndex = -1 Then
            ErrorProvider.SetError(cboABranchID, "شعبه را انتخاب نمایید")
            res = False
        Else
            ErrorProvider.SetError(cboABranchID, "")
        End If
        'If cboAAccountTypeID.SelectedIndex = -1 Then
        '    ErrorProvider.SetError(cboAAccountTypeID, "نوع حساب را انتخاب نمایید")
        '    res = False
        'Else
        '    ErrorProvider.SetError(cboAAccountTypeID, "")
        'End If




        If txtAAccountNO_vc.Text.Trim = "" And clsCMSProject.CMSProjectID = 1 Then
            ErrorProvider.SetError(txtAAccountNO_vc, "")

        Else     '''''
            'Dim clsCMSProject As New ClassCMSProject(0, "")
            'For intCounter As Integer = 0 To Me.chkCMSProject.CheckedItems.Count - 1
            '    clsCMSProject = chkCMSProject.CheckedItems(intCounter)
            If clsCMSProject.CMSProjectID = 3 Then
                isPostBank = True
            End If
            ' Next

        End If
        ''''

        If isPostBank = False And clsCMSProject.CMSProjectID = 1 Then
            If (txtAAccountNO_vc.MaxLength = 10 And txtAAccountNO_vc.Text.Trim.Length <> 10) Then
                ErrorProvider.SetError(txtAAccountNO_vc, "شماره حساب باید 10 رقمی باشد")
                res = False
            Else
                If modPublicMethod.CheckAccountNo(txtAAccountNO_vc.Text.Trim) = False Then
                    ErrorProvider.SetError(txtAAccountNO_vc, "شماره حساب نامعتبر است")
                    res = False
                Else
                    ErrorProvider.SetError(txtAAccountNO_vc, "")
                End If
            End If
        End If

        If clsCMSProject.CMSProjectID = 1 Then

            Dim dtAccount As New DataTable
            dtAccount = clsDalContract.GetByContractIDAndAccountNoAccount(txtContractID.Text, txtAAccountNO_vc.Text.Trim)
            Select Case Me.clsMyControlerAccount.CurrentState
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Add
                    If dtAccount.Rows.Count > 0 Then
                        If txtAAccountNO_vc.Text.Trim = String.Empty Then
                            ShowErrorMessage("در حال حاضر یک مورد جهت افتتاح حساب برای این قرارداد تعریف شده است")
                            res = False
                        Else
                            ShowErrorMessage("حساب مربوطه برای این قرارداد تکراری است")
                            res = False
                        End If
                    End If
                Case RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit
                    If dtAccount.Rows.Count > 0 Then
                        If dtAccount.Rows(0).Item("AccountID") <> txtAAccountID.Text Then
                            If txtAAccountNO_vc.Text.Trim = String.Empty Then
                                ShowErrorMessage("در حال حاضر یک مورد جهت افتتاح حساب برای این قرارداد تعریف شده است")
                                res = False
                            Else
                                ShowErrorMessage("حساب مربوطه برای این قرارداد تکراری است")
                                res = False
                            End If
                        End If
                    End If
            End Select

        End If

        If ShabaAccountValidation(txtAShabaAccount.Text, txtAShabaAccount) = False Then
            res = False
        End If

        If cboAFinancialSupervisionId.SelectedIndex = -1 And clsCMSProject.CMSProjectID = My.Settings.Pasargard_CmsProjectID Then
            res = False
            ShowErrorMessage("انتخاب کد سرپرست برای پروژه های پاسارگاد الزامی است")
        End If

        Return res
    End Function
    Private Function StoreValidate()
        Dim res As Boolean = True

        If txtContractID.Text.Trim = "" Then
            ShowErrorMessage("قرارداد را انتخاب کنید")
            Return False
        End If

        If txtSName_nvc.Text.Trim = "" Then
            ErrorProvider.SetError(txtSName_nvc, "نام را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(txtSName_nvc, "")
        End If
        If cboSGroupID.SelectedIndex = -1 Then
            ErrorProvider.SetError(cboSGroupID, "صنف را انتخاب کنید")
            res = False
        Else
            ErrorProvider.SetError(cboSGroupID, "")
        End If
        If cboSStateID.SelectedIndex = -1 Then
            ErrorProvider.SetError(cboSStateID, "استان را انتخاب کنید")
            res = False
        Else
            ErrorProvider.SetError(cboSStateID, "")
        End If
        If cboSCityID.SelectedIndex = -1 Then
            ErrorProvider.SetError(cboSCityID, "شهر را انتخاب کنید")
            res = False
        Else
            ErrorProvider.SetError(cboSCityID, "")
        End If
        If cboSSIdentityTypeID.SelectedIndex = -1 Then
            ErrorProvider.SetError(cboSSIdentityTypeID, "مدرک شناسایی را انتخاب کنید")
            res = False
        Else
            ErrorProvider.SetError(cboSSIdentityTypeID, "")
        End If
        If newtxtSAddress_nvc.Text.Trim = "" Then
            ErrorProvider.SetError(newtxtSAddress_nvc, "آدرس را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(newtxtSAddress_nvc, "")
        End If

        If ntxtSMunicipalAreaNO_sint.Text.Trim = "" Then
            ErrorProvider.SetError(ntxtSMunicipalAreaNO_sint, "منطقه شهرداری را وارد کنید")
            res = False
        Else
            ErrorProvider.SetError(ntxtSMunicipalAreaNO_sint, "")
        End If
        If txtSPostCode_vc.Text.Trim = "" Then
            ErrorProvider.SetError(txtSPostCode_vc, "کد پستی را وارد کنید")
            res = False
        ElseIf txtSPostCode_vc.Text.Trim.Length <> 10 Then
            ErrorProvider.SetError(txtSPostCode_vc, "کد پستی بايد 10 رقمي باشد")
            res = False
        Else
            ErrorProvider.SetError(txtSPostCode_vc, "")
        End If
       
        If txtSTel1_vc.Text.Trim = "" Or txtSTel1_vc.Text.Trim.Length = 0 Then
            ErrorProvider.SetError(txtSTel1_vc, "شماره تلفن را وارد کنید")
            res = False
        ElseIf txtSTel1_vc.Text.Trim.Length <> 8 Then
            ErrorProvider.SetError(txtSTel1_vc, "شماره تلفن باید 8 کاراکتر باشد")
            res = False
        Else
            ErrorProvider.SetError(txtSTel1_vc, "")
        End If

        If txtSTel2_vc.Text.Trim = "" Or txtSTel2_vc.Text.Trim.Length = 0 Then
            ErrorProvider.SetError(txtSTel2_vc, "شماره موبایل را وارد کنید")
            res = False
        ElseIf txtSTel2_vc.Text.Trim.Length <> 10 Then
            ErrorProvider.SetError(txtSTel2_vc, "موبایل باید 10 کاراکتر باشد")
            res = False
        Else
            ErrorProvider.SetError(txtSTel2_vc, "")
        End If


        If txtSDeviceCount_tint.Text.Trim = "" Then
            ErrorProvider.SetError(txtSDeviceCount_tint, "تعداد پز را وارد کنید")
            res = False
        Else
            If Convert.ToInt32(txtSDeviceCount_tint.Text.Trim) > 255 Then
                ErrorProvider.SetError(txtSDeviceCount_tint, "تعداد پز وارد شده نامعتبر می باشد ")
                res = False
            Else
                ErrorProvider.SetError(txtSDeviceCount_tint, "")
            End If
        End If

        If cboStorePosModel.SelectedIndex = -1 Then
            ErrorProvider.SetError(cboStorePosModel, "نوع پز را وارد کنید")
            res = False
        End If

        If cboSEstateConditionID.SelectedIndex = -1 Then
            ErrorProvider.SetError(cboSEstateConditionID, "وضعیت تملک رامشخص کنید")
            res = False
        End If

        Return res
    End Function
    Private Function StoreDBValidate()
        Dim dt As New DataTable
        Dim res As Boolean = True
        If txtSStoreID.Text.Trim <> "" Then
            clsDalContract.SStoreID = Convert.ToInt64(txtSStoreID.Text.Trim)
            dt = clsDalContract.GetByStoreIDRealDeviceCount(clsDalContract.SStoreID)
            If dt.Rows.Count = 0 Then
                ErrorProvider.SetError(txtSDeviceCount_tint, "چنین فروشگاهی موجود نمی باشد")
                res = False
            Else
                If dt.Rows(0).Item("CountDeviceID") > Convert.ToInt16(txtSDeviceCount_tint.Text.Trim) Then
                    ErrorProvider.SetError(txtSDeviceCount_tint, "تعداد پز  وارد شده کمتر از تعداد پزهای اختصاص یافته به این فروشگاه می باشد")
                    res = False
                Else
                    ErrorProvider.SetError(txtSDeviceCount_tint, "")
                End If
            End If

        End If
        Return res
    End Function
    Private Sub StoreAlarm()
        Dim dt As New DataTable
        clsDalContract.STel1_vc = txtSTel1_vc.Text.Trim
        dt = clsDalContract.GetByTel1Store()
        If dt.Rows.Count > 0 Then
            ShowErrorMessage(" تلفن 1 در سیستم موجود است ")
        End If

        dt.Clear()
        If txtSTel2_vc.Text.Trim <> "" Then
            clsDalContract.STel2_vc = txtSTel2_vc.Text.Trim
            dt = clsDalContract.GetByTel2Store()
            If dt.Rows.Count > 0 Then
                ShowErrorMessage(" تلفن 2 در سیستم موجود است ")
            End If
        End If
    End Sub
    Private Sub DoInsertContractingParty_Contract()
        Try
            clsDalContract.ContractingPartyID = clsDalContract.InsertContractParty()
            Me.clsDalContract.ContractID = Me.clsDalContract.InsertContract()
            InsertContractCMS()
            DatatableContractingParty_ContractInsert()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoUpdateContractingParty_Contract()
        Try
            Me.clsDalContract.UpdateContractParty()
            Me.clsDalContract.UpdateContract()
            InsertContractCMS()
            DatatableContractingParty_ContractUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InsertContractCMS()
        Try
            clsDalContract.DeleteContractCMSProject()
            For intCounter As Integer = 0 To Me.chkCMSProject.CheckedItems.Count - 1
                clsCMSProject = chkCMSProject.CheckedItems(intCounter)
                clsDalContract.CMSProjectID = clsCMSProject.CMSProjectID
                clsDalContract.InsertContractCMSProject()
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoInsertAccount()
        Try
            Me.clsDalContract.AAccountID = Me.clsDalContract.InsertAccount()
            DatatableAccountInsert()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub DoUpdateAccount()
        Try
            Me.clsDalContract.UpdateAccount()
            DatatableAccountUpdate()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function DoInsertStore() As Boolean
        Try
            DoInsertStore = True
            Try
                clsDALCity.BeginProc()
                clsDALCity.CityID = clsDalContract.SCityID
                If clsDALCity.GetByID().Rows.Count = 1 Then
                    clsDalContract.SStateID = clsDALCity.GetByID().Rows(0).Item("StateID")
                Else
                    DoInsertStore = False
                    ShowErrorMessage("ثبت شهر و استان دچار مشكل شده است")
                    Exit Function
                End If
            Catch ex As Exception
                DoInsertStore = False
                Throw ex
            Finally
                clsDALCity.EndProc()
            End Try
            Me.clsDalContract.SStoreID = Me.clsDalContract.InsertStore()
            DatatableStoreInsert()
        Catch ex As Exception
            DoInsertStore = False
            Throw ex
        End Try
    End Function
    Private Sub DoUpdateStore()
        Try
            Me.clsDalContract.UpdateStore()
            DatatableStoreUpdate()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableContractingParty_ContractInsert()
        Try
            Dim dr As DataRow = Me.dtContractingParty_Contract.NewRow
            dr.Item("ContractingPartyID") = clsDalContract.ContractingPartyID
            dr.Item("FirstName_nvc") = clsDalContract.FirstName_nvc
            dr.Item("LastName_nvc") = clsDalContract.LastName_nvc
            dr.Item("FatherName_nvc") = clsDalContract.FatherName_nvc
            dr.Item("IdentityCertificateNO_nvc") = clsDalContract.IdentityCertificateNO_nvc
            dr.Item("NationalCode_nvc") = clsDalContract.NationalCode_nvc
            dr.Item("Gender_bit") = clsDalContract.Gender_bit
            dr.Item("StateID") = clsDalContract.StateID
            dr.Item("CityID") = clsDalContract.CityID
            dr.Item("CIdentityTypeID") = clsDalContract.CIdentityTypeID
            dr.Item("DegreeID") = clsDalContract.DegreeID
            dr.Item("Title_nvc") = clsDalContract.Title_nvc
            dr.Item("FatherName_nvc") = clsDalContract.FatherName_nvc
            dr.Item("HomeAddress_nvc") = clsDalContract.HomeAddress_nvc
            dr.Item("HomeTel_vc") = clsDalContract.HomeTel_vc
            dr.Item("Mobile_vc") = clsDalContract.Mobile_vc
            dr.Item("Email_nvc") = clsDalContract.Email_nvc
            dr.Item("HavingAccount_bit") = clsDalContract.HavingAccount_bit
            dr.Item("AccountTypeID") = clsDalContract.AccountTypeID
            dr.Item("BirthDate_vc") = clsDalContract.BirthDate_vc
            dr.Item("ContractID") = clsDalContract.ContractID
            dr.Item("VisitorID") = clsDalContract.VisitorID
            dr.Item("Date_vc") = clsDalContract.Date_vc
            dr.Item("Merchant_vc") = clsDalContract.Merchant_vc
            dr.Item("AccountNO_vc") = clsDalContract.AccountNO_vc
            dr.Item("ShabaAccount") = clsDalContract.ShabaAccount
            dr.Item("CardNo_vc") = clsDalContract.CardNo_vc
            dr.Item("BranchID") = clsDalContract.BranchID
            dr.Item("SaveDate_vc") = clsDalContract.SaveDate_vc
            dr.Item("ContractNo_vc") = clsDalContract.ContractNo_vc
            dr.Item("MarketingByID") = clsDalContract.MarketingByID
            dr.Item("ZoncanNo_nvc") = clsDalContract.ZoncanNo_nvc

            Me.dtContractingParty_Contract.Rows.Add(dr)
            dgvContractingParty_Contract.CurrentCell = dgvContractingParty_Contract.Rows(dtContractingParty_Contract.Rows.Count - 1).Cells(2)
            dgvContractingParty_ContractRowEnter(dtContractingParty_Contract.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableContractingParty_ContractUpdate()
        Try
            Dim dr() As DataRow = Me.dtContractingParty_Contract.Select("ContractingPartyID = " + clsDalContract.ContractingPartyID.ToString)
            If dr.Length > 0 Then
                dr(0).Item("FirstName_nvc") = clsDalContract.FirstName_nvc
                dr(0).Item("LastName_nvc") = clsDalContract.LastName_nvc
                dr(0).Item("FatherName_nvc") = clsDalContract.FatherName_nvc
                dr(0).Item("IdentityCertificateNO_nvc") = clsDalContract.IdentityCertificateNO_nvc
                dr(0).Item("NationalCode_nvc") = clsDalContract.NationalCode_nvc
                dr(0).Item("Gender_bit") = clsDalContract.Gender_bit
                dr(0).Item("StateID") = clsDalContract.StateID
                dr(0).Item("CityID") = clsDalContract.CityID
                dr(0).Item("CIdentityTypeID") = clsDalContract.CIdentityTypeID
                dr(0).Item("DegreeID") = clsDalContract.DegreeID
                dr(0).Item("Title_nvc") = clsDalContract.Title_nvc
                dr(0).Item("FatherName_nvc") = clsDalContract.FatherName_nvc
                dr(0).Item("HomeAddress_nvc") = clsDalContract.HomeAddress_nvc
                dr(0).Item("HomeTel_vc") = clsDalContract.HomeTel_vc
                dr(0).Item("Mobile_vc") = clsDalContract.Mobile_vc
                dr(0).Item("Email_nvc") = clsDalContract.Email_nvc
                dr(0).Item("HavingAccount_bit") = clsDalContract.HavingAccount_bit
                dr(0).Item("AccountTypeID") = clsDalContract.AccountTypeID
                dr(0).Item("BirthDate_vc") = clsDalContract.BirthDate_vc
                dr(0).Item("VisitorID") = clsDalContract.VisitorID
                dr(0).Item("Date_vc") = clsDalContract.Date_vc
                dr(0).Item("Merchant_vc") = clsDalContract.Merchant_vc
                dr(0).Item("AccountNO_vc") = clsDalContract.AccountNO_vc
                dr(0).Item("ShabaAccount") = clsDalContract.ShabaAccount
                dr(0).Item("CardNo_vc") = clsDalContract.CardNo_vc
                dr(0).Item("BranchID") = clsDalContract.BranchID
                dr(0).Item("SaveDate_vc") = clsDalContract.SaveDate_vc
                dr(0).Item("ContractNo_vc") = clsDalContract.ContractNo_vc
                dr(0).Item("MarketingByID") = clsDalContract.MarketingByID
                dr(0).Item("ZoncanNo_nvc") = clsDalContract.ZoncanNo_nvc
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableAccountInsert()
        Try
            Dim dr As DataRow = Me.dtAccount.NewRow

            dr.Item("AccountID") = clsDalContract.AAccountID
            dr.Item("ContractID") = clsDalContract.ContractID
            dr.Item("AccountNO_vc") = clsDalContract.AAccountNO_vc
            dr.Item("ShabaAccount") = clsDalContract.AShabaAccount
            dr.Item("CardNo_vc") = clsDalContract.ACardNo_vc
            dr.Item("AccountTypeID") = clsDalContract.AAccountTypeID
            dr.Item("BranchID") = clsDalContract.ABranchID
            dr.Item("AccountTypeIDName_nvc") = cboAAccountTypeID.Text.Trim
            dr.Item("BranchIDName_nvc") = cboABranchID.Text.Trim
            dr.Item("oldShabaAccount") = clsDalContract.AShabaAccountold
            dr.Item("Financialsupervisionid") = clsDalContract.AFinancialSupervisionId

            Me.dtAccount.Rows.Add(dr)
            dgvAccount.CurrentCell = dgvAccount.Rows(dgvAccount.Rows.Count - 1).Cells(2)
            dgvAccountRowEnter(dgvAccount.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableAccountUpdate()
        Try
            Dim dr() As DataRow = Me.dtAccount.Select("AccountID=" + clsDalContract.AAccountID.ToString)
            If dr.Length > 0 Then
                dr(0).Item("AccountID") = clsDalContract.AAccountID
                dr(0).Item("ContractID") = clsDalContract.ContractID
                dr(0).Item("AccountNO_vc") = clsDalContract.AAccountNO_vc
                dr(0).Item("ShabaAccount") = clsDalContract.AShabaAccount
                dr(0).Item("CardNo_vc") = clsDalContract.ACardNo_vc
                dr(0).Item("AccountTypeID") = clsDalContract.AAccountTypeID
                dr(0).Item("BranchID") = clsDalContract.ABranchID
                dr(0).Item("AccountTypeIDName_nvc") = cboAAccountTypeID.Text.Trim
                dr(0).Item("BranchIDName_nvc") = cboABranchID.Text.Trim
                dr(0).Item("Financialsupervisionid") = clsDalContract.AFinancialSupervisionId
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableStoreInsert()
        Try
            Dim dr As DataRow = Me.dtStore.NewRow

            dr.Item("StoreID") = clsDalContract.SStoreID
            dr.Item("AccountID") = clsDalContract.AAccountID
            dr.Item("GroupID") = clsDalContract.SGroupID
            dr.Item("LicenseID") = clsDalContract.SLicenseID
            dr.Item("GroupSupplementaryID") = clsDalContract.SSupplementary
            dr.Item("StateID") = clsDalContract.SStateID
            dr.Item("CityID") = clsDalContract.SCityID
            dr.Item("Name_nvc") = clsDalContract.SName_nvc
            dr.Item("PostCode_vc") = clsDalContract.SPostCode_vc
            dr.Item("Address_nvc") = clsDalContract.SAddress_nvc
            dr.Item("newAddress_nvc") = clsDalContract.newSAddressCode_nvc
            newtxtSAddress_nvc.Text = clsDalAddress.loadAddressDesc(clsDalContract.newSAddressCode_nvc)
            dr.Item("Tel1_vc") = clsDalContract.STel1_vc
            dr.Item("Tel2_vc") = clsDalContract.STel2_vc
            dr.Item("Fax_vc") = clsDalContract.SFax_vc
            dr.Item("MunicipalAreaNO_sint") = clsDalContract.SMunicipalAreaNO_sint
            dr.Item("EstateConditionID") = clsDalContract.SEstateConditionID
            dr.Item("SIdentityTypeID") = clsDalContract.SSIdentityTypeID
            dr.Item("SIdentityTypeSDate_vc") = clsDalContract.SSIdentityTypeSDate_vc
            dr.Item("SIdentityTypeEDate_vc") = clsDalContract.SSIdentityTypeEDate_vc
            dr.Item("DeviceCount_tint") = clsDalContract.SDeviceCount_tint
            dr.Item("StorePosModelID") = clsDalContract.StorePosModelID

            Me.dtStore.Rows.Add(dr)
            dgvStore.CurrentCell = dgvStore.Rows(dgvStore.Rows.Count - 1).Cells(5)
            dgvStoreRowEnter(dgvStore.Rows.Count - 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableStoreUpdate()
        Try
            Dim dr() As DataRow = Me.dtStore.Select("StoreID = " + clsDalContract.SStoreID.ToString)
            If dr.Length > 0 Then
                dr(0).Item("AccountID") = clsDalContract.AAccountID
                dr(0).Item("GroupID") = clsDalContract.SGroupID
                dr(0).Item("LicenseID") = clsDalContract.SLicenseID
                dr(0).Item("GroupSupplementaryID") = clsDalContract.SSupplementary
                dr(0).Item("StateID") = clsDalContract.SStateID
                dr(0).Item("CityID") = clsDalContract.SCityID
                dr(0).Item("Name_nvc") = clsDalContract.SName_nvc
                dr(0).Item("PostCode_vc") = clsDalContract.SPostCode_vc
                dr(0).Item("Address_nvc") = clsDalContract.SAddress_nvc
                dr(0).Item("newAddress_nvc") = clsDalContract.newSAddressCode_nvc
                newtxtSAddress_nvc.Text = clsDalAddress.loadAddressDesc(clsDalContract.newSAddressCode_nvc)
                dr(0).Item("Tel1_vc") = clsDalContract.STel1_vc
                dr(0).Item("Tel2_vc") = clsDalContract.STel2_vc
                dr(0).Item("Fax_vc") = clsDalContract.SFax_vc
                dr(0).Item("MunicipalAreaNO_sint") = clsDalContract.SMunicipalAreaNO_sint
                dr(0).Item("EstateConditionID") = clsDalContract.SEstateConditionID
                dr(0).Item("SIdentityTypeID") = clsDalContract.SSIdentityTypeID
                dr(0).Item("SIdentityTypeSDate_vc") = clsDalContract.SSIdentityTypeSDate_vc
                dr(0).Item("SIdentityTypeEDate_vc") = clsDalContract.SSIdentityTypeEDate_vc
                dr(0).Item("DeviceCount_tint") = clsDalContract.SDeviceCount_tint
                dr(0).Item("StorePosModelID") = clsDalContract.StorePosModelID
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Delete"
    Private Sub Delete()
        Try
            If modPublicMethod.ShowConfirmDeleteMessage() = False Then
                Exit Sub
            End If
            If Me.tbc.SelectedTab Is Me.tbpContractingParty Then
                Me.DeleteContractingParty_Contrary()
            ElseIf Me.tbc.SelectedTab Is Me.tbpAccount Then
                Me.DeleteAccount()
            ElseIf Me.tbc.SelectedTab Is Me.tbpStore Then
                Me.DeleteStore()
            ElseIf Me.tbc.SelectedTab Is Me.tbpDevice Then
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DeleteContractingParty_Contrary()
        clsDalContract.ContractingPartyID = Convert.ToInt64(txtContractingID.Text.Trim)
        clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
        Dim RequestStatusID As Int16
        Dim DuplicateRequestID As Int64

        If txtRequestID.Text.Trim <> "" Then
            Dim _frm As New frmRequestStatus
            If _frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                RequestStatusID = _frm.RequestStatusID
                DuplicateRequestID = _frm.DuplicateRequestID
            Else
                Exit Sub
            End If
        End If

        Try
            clsMyControlerContractingParty.DataGridView = dgvContractingParty_Contract
            clsMyControlerContractingParty.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
            clsDalContract.BeginProc()
            If txtRequestID.Text.Trim <> "" Then
                clsDalContract.UpdateReuest_RequestStatusAndDuplicateRequestID(txtRequestID.Text, RequestStatusID, DuplicateRequestID)
            End If
            DoDeleteContractingParty_Contrary()
            Me.dtContractingParty_Contract.AcceptChanges()
        Catch ex As Exception
            Me.dtContractingParty_Contract.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            clsDalContract.EndProc()
            clsMyControlerContractingParty.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            clsMyControlerContractingParty.SetControlsValue()
        End Try
    End Sub
    Private Sub DeleteAccount()
        clsDalContract.AAccountID = Convert.ToInt64(txtAAccountID.Text.Trim)
        Try
            clsMyControlerAccount.DataGridView = dgvAccount
            clsMyControlerAccount.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
            clsDalContract.BeginProc()
            DoDeleteAccount()
            Me.dtAccount.AcceptChanges()
        Catch ex As Exception
            Me.dtAccount.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            clsDalContract.EndProc()
            clsMyControlerAccount.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            clsMyControlerAccount.SetControlsValue()
        End Try

    End Sub
    Private Sub DeleteStore()
        clsDalContract.SStoreID = Convert.ToInt64(txtSStoreID.Text.Trim)
        Try
            clsMyControlerStore.DataGridView = dgvStore
            clsMyControlerStore.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
            clsDalContract.BeginProc()
            DoDeleteStore()
            Me.dtStore.AcceptChanges()
        Catch ex As Exception
            Me.dtStore.RejectChanges()
            Throw ex
            Exit Sub
        Finally
            clsDalContract.EndProc()
            clsMyControlerStore.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
            clsMyControlerStore.SetControlsValue()
        End Try
    End Sub
    'Private Sub DeleteDevice()
    '    clsDalContract.DDeviceID = Convert.ToInt64(txtDDeviceID.Text.Trim)
    '    Try
    '        clsMyControlerDevice.DataGridView = dgvDevice
    '        clsMyControlerDevice.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Delete)
    '        clsDalContract.BeginProc()
    '        DoDeleteDevice()
    '        Me.dtDevice.AcceptChanges()
    '    Catch ex As Exception
    '        Me.dtDevice.RejectChanges()
    '        Throw ex
    '        Exit Sub
    '    Finally
    '        clsDalContract.EndProc()
    '        clsMyControlerDevice.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
    '        clsMyControlerDevice.SetControlsValue()
    '    End Try
    'End Sub
    Private Sub DoDeleteContractingParty_Contrary()
        Try
            Me.clsDalContract.DeleteContract()
            Me.clsDalContract.DeleteContractingParty()
            DatatableContractingParty_ContractDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDeleteAccount()
        Try
            Me.clsDalContract.DeleteAccount()
            DatatableAccountDelete()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub DoDeleteStore()
        Try
            Me.clsDalContract.DeleteStore()
            DatatableStoreDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DoDeleteDevice()
        Try
            Me.clsDalContract.DeleteDevice()
            DatatableDeviceDelete()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableContractingParty_ContractDelete()
        Try
            Dim drDeletedRow() As DataRow = Me.dtContractingParty_Contract.Select("ContractingPartyID = " + clsDalContract.ContractingPartyID.ToString)
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableAccountDelete()
        Try
            Dim drDeletedRow() As DataRow = Me.dtAccount.Select("AccountID = " + clsDalContract.AAccountID.ToString)
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableStoreDelete()
        Try
            Dim drDeletedRow() As DataRow = Me.dtStore.Select("StoreID = " + clsDalContract.SStoreID.ToString)
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DatatableDeviceDelete()
        Try
            Dim drDeletedRow() As DataRow = Me.dtDevice.Select("DeviceID = " + clsDalContract.DDeviceID.ToString)
            If drDeletedRow.Length > 0 Then
                drDeletedRow(0).Delete()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "StoreSection"
    Private Sub ForceChooseOneSCityForOneContract()
        If dgvStore.Rows.Count > 0 Then
            EnableSStateCity(False)
            cboSStateID.SelectedValue = dgvStore.Rows(0).Cells("colSStateID").Value
            cboSCityID.SelectedValue = dgvStore.Rows(0).Cells("colSCityID").Value
        ElseIf dgvStore.Rows.Count = 0 Then
            EnableSStateCity(True)
        End If
    End Sub
    Private Sub NotChangeCityIfNeccesary()
        Dim dt As New DataTable
        Try
            dt = clsDalContract.GetOutletAndMerchantByStoreID(Convert.ToInt64(txtSStoreID.Text.Trim), ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dt.Rows.Count > 0 Then
                EnableSStateCity(False)

            End If

        Catch ex As Exception

        End Try
    End Sub
    'Private Sub ForceChooseOneAccountForOneStore()
    '    If dgvDevice.Rows.Count > 0 Then
    '        If dgvDevice.Rows(0).Cells("colDAccountNO_vc").Value.ToString.Trim = "" Then
    '            EnableDAccount(True)
    '        Else
    '            EnableDAccount(False)
    '        End If
    '        cboDAccountTypeID.SelectedValue = dgvDevice.Rows(0).Cells("colDAccountTypeID").Value
    '        txtDAccountNO_vc.Text = dgvDevice.Rows(0).Cells("colDAccountNO_vc").Value
    '        txtDCardNo_vc.Text = dgvDevice.Rows(0).Cells("colDCardNo_vc").Value
    '        cboDBranchID.SelectedValue = dgvDevice.Rows(0).Cells("colDBranchID").Value
    '    ElseIf dgvStore.Rows.Count = 0 Then
    '        EnableDAccount(True)
    '    End If
    'End Sub
#End Region
#Region "Others"
#Region "Check"
    Private Function CheckVisitorID(ByVal VisitorID As Int32, ByRef VisitorFullName As String) As Boolean
        Try
            Dim dt As New DataTable
            clsDALVisitor.BeginProc()
            clsDALVisitor.VisitorID = VisitorID
            dt = clsDALVisitor.GetByID()
            If dt.Rows.Count > 0 Then
                VisitorFullName = dt.Rows(0).Item("FirstName_nvc") & Space(1) & dt.Rows(0).Item("LastName_nvc")
                CheckVisitorID = True
            Else
                VisitorFullName = ""
                CheckVisitorID = False
            End If
        Catch ex As Exception
            VisitorFullName = ""
            CheckVisitorID = False
            Throw ex
        Finally
            clsDALVisitor.EndProc()
        End Try

    End Function
    'Private Function CheckExistingDSerial_vc(ByVal DSerial_vc As String) As Boolean
    '    Try
    '        Dim dt As New DataTable
    '        'clsDalContract.BeginProc()
    '        clsDalContract.DSerial_vc = DSerial_vc
    '        dt = clsDalContract.GetByDSerial()
    '        If dt.Rows.Count > 0 Then
    '            If Me.clsMyControlerDevice.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit Then
    '                If dt.Rows(0).Item("DeviceID") = txtDDeviceID.Text.Trim Then
    '                    CheckExistingDSerial_vc = False
    '                Else
    '                    CheckExistingDSerial_vc = True
    '                End If
    '            Else
    '                CheckExistingDSerial_vc = True
    '            End If
    '        Else
    '            CheckExistingDSerial_vc = False
    '        End If
    '    Catch ex As Exception
    '        CheckExistingDSerial_vc = True
    '        Throw ex
    '    Finally
    '        'clsDalContract.EndProc()
    '    End Try

    'End Function
    'Private Function CheckDExistingDPropertyNO_vc(ByVal PropertyNO_vc As String) As Boolean
    '    Try
    '        Dim dt As New DataTable
    '        'clsDalContract.BeginProc()
    '        clsDalContract.DPropertyNO_vc = PropertyNO_vc
    '        dt = clsDalContract.GetByDPropertyNO()
    '        If dt.Rows.Count > 0 Then
    '            If Me.clsMyControlerDevice.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit Then
    '                If dt.Rows(0).Item("DeviceID") = txtDDeviceID.Text.Trim Then
    '                    CheckDExistingDPropertyNO_vc = False
    '                Else
    '                    CheckDExistingDPropertyNO_vc = True
    '                End If
    '            Else
    '                CheckDExistingDPropertyNO_vc = True
    '            End If
    '        Else
    '            CheckDExistingDPropertyNO_vc = False
    '        End If
    '    Catch ex As Exception
    '        CheckDExistingDPropertyNO_vc = True
    '        Throw ex
    '    Finally
    '        'clsDalContract.EndProc()
    '    End Try

    'End Function
    'Private Function CheckExistingDCode_vc(ByVal DCode_vc As String) As Boolean
    '    Try
    '        Dim dt As New DataTable
    '        clsDalContract.BeginProc()
    '        clsDalContract.DCode_vc = DCode_vc
    '        dt = clsDalContract.GetBYDCode()
    '        If dt.Rows.Count > 0 Then
    '            If Me.clsMyControlerDevice.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit Then
    '                If dt.Rows(0).Item("DeviceID") = txtDDeviceID.Text.Trim Then
    '                    CheckExistingDCode_vc = False
    '                Else
    '                    CheckExistingDCode_vc = True
    '                End If
    '            Else
    '                CheckExistingDCode_vc = True
    '            End If
    '        Else
    '            CheckExistingDCode_vc = False
    '        End If
    '    Catch ex As Exception
    '        CheckExistingDCode_vc = True
    '        Throw ex
    '    Finally
    '        clsDalContract.EndProc()
    '    End Try

    'End Function
    'Private Function CheckDExistingDOutlet_vc(ByVal DOutlet_vc As String) As Boolean
    '    Try
    '        Dim dt As New DataTable
    '        clsDalContract.BeginProc()
    '        clsDalContract.DOutlet_vc = DOutlet_vc
    '        dt = clsDalContract.GetBYDOutlet()
    '        If dt.Rows.Count > 0 Then
    '            If Me.clsMyControlerDevice.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit Then
    '                If dt.Rows(0).Item("DeviceID") = txtDDeviceID.Text.Trim Then
    '                    CheckDExistingDOutlet_vc = False
    '                Else
    '                    CheckDExistingDOutlet_vc = True
    '                End If
    '            Else
    '                CheckDExistingDOutlet_vc = True
    '            End If
    '        Else
    '            CheckDExistingDOutlet_vc = False
    '        End If
    '    Catch ex As Exception
    '        CheckDExistingDOutlet_vc = True
    '        Throw ex
    '    Finally
    '        clsDalContract.EndProc()
    '    End Try

    'End Function
    'Private Function CheckDExistingDEniacCode_bint(ByVal DEniacCode_vc As String)
    '    Try
    '        Dim dt As New DataTable
    '        'clsDalContract.BeginProc()
    '        clsDalContract.DEniacCode_vc = DEniacCode_vc
    '        dt = clsDalContract.GetBYDEniacCode()
    '        If dt.Rows.Count > 0 Then
    '            If Me.clsMyControlerDevice.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit Then
    '                If dt.Rows(0).Item("DeviceID") = txtDDeviceID.Text.Trim Then
    '                    CheckDExistingDEniacCode_bint = False
    '                Else
    '                    CheckDExistingDEniacCode_bint = True
    '                End If
    '            Else
    '                CheckDExistingDEniacCode_bint = True
    '            End If
    '        Else
    '            CheckDExistingDEniacCode_bint = False
    '        End If
    '    Catch ex As Exception
    '        CheckDExistingDEniacCode_bint = True
    '        Throw ex
    '    Finally
    '        ' clsDalContract.EndProc()
    '    End Try

    'End Function

#End Region
#Region "Get"
    Private Sub GetTheLatestContractSerial(ByRef ContractNo_Merchant As String)
        Try
            Dim ContractNoMerchantSerial As String
            Dim lngContractNoMerchantSerial As Int64
            Dim dt As New DataTable
            'Me.clsDalContract.BeginProc()
            dt = clsDalContract.GetTheLatestContract()
            If dt.Rows.Count > 0 Then
                ContractNoMerchantSerial = GetAPartOfString(dt.Rows(0).Item("Merchant_vc"), dt.Rows(0).Item("Merchant_vc").ToString.Length - 6, 6)
                lngContractNoMerchantSerial = Convert.ToInt64(ContractNoMerchantSerial) + 1
                ContractNoMerchantSerial = Microsoft.VisualBasic.Right("000000" + lngContractNoMerchantSerial.ToString(), 6)
            Else
                ContractNoMerchantSerial = "000001"
            End If
            ContractNo_Merchant = ContractNoMerchantSerial
        Catch ex As Exception
            Throw ex
        Finally
            'Me.clsDalContract.EndProc()
        End Try
    End Sub
    'Private Sub GetTheLatestDevice(ByRef MerchantSerial As String, ByRef OutletSerial As String, ByRef VatSerial As String, ByRef CodeSerial As String)
    '    Try
    '        Dim lngMerchantSerial As Long
    '        Dim lngOutletSerial As Long
    '        Dim lngVatSerial As Long
    '        Dim lngCodeSerial As Long
    '        'Dim lngEniacCode As Long

    '        Dim dt As New DataTable
    '        'Me.clsDalContract.BeginProc()
    '        dt = clsDalContract.GetTheLatestDevice()
    '        If dt.Rows.Count > 0 Then
    '            If clsDalContract.SStoreID <> 0 Then
    '                '===
    '                If dt.Rows(0).Item("StoreID") = clsDalContract.SStoreID Then
    '                    MerchantSerial = GetAPartOfString(dt.Rows(0).Item("Merchant_vc"), dt.Rows(0).Item("Merchant_vc").ToString.Length - 4, 4)
    '                    VatSerial = GetAPartOfString(dt.Rows(0).Item("Vat_vc"), dt.Rows(0).Item("Vat_vc").ToString.Length - 4, 4)
    '                Else
    '                    MerchantSerial = GetAPartOfString(dt.Rows(0).Item("Merchant_vc"), dt.Rows(0).Item("Merchant_vc").ToString.Length - 4, 4)
    '                    VatSerial = GetAPartOfString(dt.Rows(0).Item("Vat_vc"), dt.Rows(0).Item("Vat_vc").ToString.Length - 4, 4)

    '                    lngMerchantSerial = Convert.ToInt64(MerchantSerial) + 1
    '                    lngVatSerial = Convert.ToInt64(VatSerial) + 1

    '                    MerchantSerial = Microsoft.VisualBasic.Right("0000" + lngMerchantSerial.ToString, 4)
    '                    VatSerial = Microsoft.VisualBasic.Right("0000" + lngVatSerial.ToString(), 4)
    '                End If
    '                OutletSerial = GetAPartOfString(dt.Rows(0).Item("Outlet_vc"), dt.Rows(0).Item("Outlet_vc").ToString.Length - 5, 5)
    '                CodeSerial = GetAPartOfString(dt.Rows(0).Item("Code_vc"), dt.Rows(0).Item("Code_vc").ToString.Length - 5, 5)

    '                lngOutletSerial = Convert.ToInt64(OutletSerial) + 1
    '                lngCodeSerial = Convert.ToInt64(CodeSerial) + 1

    '                OutletSerial = Microsoft.VisualBasic.Right("00000" + lngOutletSerial.ToString(), 5)
    '                CodeSerial = Microsoft.VisualBasic.Right("00000" + lngCodeSerial.ToString(), 5)

    '                'EniacCode =GetAPartOfString dt.Rows(0).Item("EniacCode_vc") + 1
    '                '===
    '            Else
    '                MerchantSerial = ""
    '                OutletSerial = ""
    '                VatSerial = ""
    '                CodeSerial = ""
    '                'EniacCode = ""
    '            End If
    '        Else
    '            MerchantSerial = "0001"
    '            OutletSerial = "00001"
    '            VatSerial = "0001"
    '            CodeSerial = "00001"
    '            'EniacCode = "000000001"
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        'Me.clsDalContract.EndProc()
    '    End Try

    'End Sub
#End Region
#Region "Set"
    Private Sub SetContractNo_Merchant(ByVal blnChangeContractNo_MerchantSerial As Boolean)
        'If blnChangeContractNo_MerchantSerial = True Then
        '    Dim ContractNo_Merchant As String = ""
        '    GetTheLatestContractSerial(ContractNo_Merchant)
        '    clsDalContract.Merchant_vc = dtxtDate_vc.Value.ToString.Substring(0, 4) + dtxtDate_vc.Value.ToString.Substring(5, 2) + ContractNo_Merchant '---Year\Month\Serial
        'ElseIf blnChangeContractNo_MerchantSerial = False Then
        '    Dim ContractNo_Merchant As String = ""
        '    clsDalContract.Merchant_vc = dtxtDate_vc.Value.ToString.Substring(0, 4) + dtxtDate_vc.Value.ToString.Substring(5, 2) + Microsoft.VisualBasic.Right(txtMerchant_vc.Text.Trim, 6) '---Year\Month\Serial
        'End If
        clsDalContract.Merchant_vc = ""
    End Sub
    Private Sub SetStatusBar(ByVal sender As Object)
        Select Case sender.name
            Case "tbpContractingParty"
                StatusMain.Items.Clear()
                StatusMain.Items.Add("")
            Case "tbpAccount"
                StatusMain.Items.Clear()
                StatusMain.Items.Add("کد قرارداد :" + txtContractID.Text.Trim + Space(5) + "طرف قرارداد :" + txtFirstName_nvc.Text.Trim + Space(1) + txtLastName_nvc.Text.Trim + Space(5))
            Case "tbpStore"
                StatusMain.Items.Clear()
                StatusMain.Items.Add("کد قرارداد :" + txtContractID.Text.Trim + Space(5) + "طرف قرارداد :" + txtFirstName_nvc.Text.Trim + Space(1) + txtLastName_nvc.Text.Trim + Space(10) + "حساب شعبه :" + cboABranchID.Text.Trim + Space(5) + IIf(txtAAccountNO_vc.Text.Trim = "", "", "شماره حساب :" + txtAAccountNO_vc.Text.Trim) + Space(5))
            Case "tbpDevice"
                StatusMain.Items.Clear()
                StatusMain.Items.Add("کد قرارداد :" + txtContractID.Text.Trim + Space(5) + "طرف قرارداد :" + txtFirstName_nvc.Text.Trim + Space(1) + txtLastName_nvc.Text.Trim + Space(10) + "حساب شعبه :" + cboABranchID.Text.Trim + Space(5) + IIf(txtAAccountNO_vc.Text.Trim = "", "", "شماره حساب :" + txtAAccountNO_vc.Text.Trim) + Space(10) + "نام فروشگاه :" + txtSName_nvc.Text.Trim + Space(5))
        End Select
    End Sub


#End Region
#Region "Fill"
    Private Sub FillContractNo_MerchantTextBox()
        txtMerchant_vc.Text = ""
        txtMerchant_vc.Text = clsDalContract.Merchant_vc
    End Sub
    'Private Sub FillDeviceCodeTextBoxes()
    '    txtDOutlet_vc.Text = clsDalContract.DOutlet_vc
    '    txtDVat_vc.Text = clsDalContract.DVat_vc
    '    txtDCode_vc.Text = clsDalContract.DCode_vc
    '    txtDMerchant_vc.Text = clsDalContract.Merchant_vc
    '    'txtDEniacCode_vc.Text = clsDalContract.DEniacCode_vc
    'End Sub

#End Region
#Region "Choose"
    Private Sub ChooseCulture(ByVal sender As Object)
        Dim CultureInfo As System.Globalization.CultureInfo
        Select Case sender.name.tolower
            Case "txtFirstName_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "txtLastName_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "txtFatherName_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "txtHomeAddress_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "txtSName_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "txtSAddress_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "newtxtSAddress_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "txtSTitle_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case "cboTitle_nvc".ToLower
                CultureInfo = New System.Globalization.CultureInfo("fa-IR", False)
            Case Else
                CultureInfo = New System.Globalization.CultureInfo("en-US", False)
        End Select
        System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo)
    End Sub

    Private Sub ChooseVisitor(ByVal frm As frmVisitor)
        If frm.CurVisitorID <> 0 Then
            txtVisitorID.Text = frm.CurVisitorID.ToString
            txtVisitorFullName.Text = frm.CurVisitorFName.ToString & " " & frm.CurVisitorLName.ToString
        End If
    End Sub
    Private Sub ChooseCIdentityTypeID(ByVal frm As frmBasicTypes)
        If frm.CurID <> 0 Then
            FillcboCIdentityTypeID()
            cboCIdentityTypeID.SelectedValue = frm.CurID
        End If
    End Sub
    Private Sub ChooseDegreeID(ByVal frm As frmBasicTypes)
        If frm.CurID <> 0 Then
            FillcboDegreeID()
            cboDegreeID.SelectedValue = frm.CurID
        End If
    End Sub
    Private Sub ChooseAccountTypeID(ByVal frm As frmBasicTypes)
        If frm.CurID <> 0 Then
            FillcboAccountTypeID()
            cboAccountTypeID.SelectedValue = frm.CurID
            'FillcboDAccountTypeID()
        End If
    End Sub
    Private Sub ChooseSSIdentityTypeID(ByVal frm As frmBasicTypes)
        If frm.CurID <> 0 Then
            FillcboSSIdentityTypeID()
            cboSSIdentityTypeID.SelectedValue = frm.CurID
        End If
    End Sub
    Private Sub ChooseSEstateConditionID(ByVal frm As frmBasicTypes)
        If frm.CurID <> 0 Then
            FillEstateCondition()
            cboSEstateConditionID.SelectedValue = frm.CurID
        End If
    End Sub
    Private Sub ChooseAAccountTypeID(ByVal frm As frmBasicTypes)
        If frm.CurID <> 0 Then
            FillcboDAccountTypeID()
            cboAAccountTypeID.SelectedValue = frm.CurID
            'FillcboAccountTypeID()
        End If
    End Sub
    Private Sub ChooseGroupID(ByVal frm As frmGroup)
        If frm.CurID <> 0 Then
            FillGroup()
            cboSGroupID.SelectedValue = frm.CurID
        End If
    End Sub

    Private Sub ChooseBranchID(ByVal frm As frmBranch)
        If frm.CurID <> "" Then
            cboBranchID.SelectedValue = frm.CurID
        End If
    End Sub
    Private Sub ChooseABranchID(ByVal frm As frmBranch)
        If frm.CurID <> 0 Then
            cboABranchID.SelectedValue = frm.CurID
        End If
    End Sub

#End Region
#Region "Others"
    Private Sub VisibleControls(ByVal bln As Boolean)
        lblSearch.Visible = bln
        cboSearchBy.Visible = bln
        txtSearch.Visible = bln
        btnSearch.Visible = bln

        '--------------
        btnRefresh.Visible = bln

    End Sub
    Private Sub Search()
        If cboSearchBy.SelectedIndex <> -1 AndAlso txtSearch.Text.Trim <> "" Then
            If cboSearchBy.SelectedIndex = SearchItemsEnum.NationalCode Then
                FilldgvContractPartyByNationalCode()
            ElseIf cboSearchBy.SelectedIndex = SearchItemsEnum.LastName Then
                FilldgvContractPartyByLastName()
            ElseIf cboSearchBy.SelectedIndex = SearchItemsEnum.ContractID Then
                FilldgvContractPartyByContractID(txtSearch.Text.Trim)
            ElseIf cboSearchBy.SelectedIndex = SearchItemsEnum.ContractNo Then
                FilldgvContractPartyByContractNo()
            ElseIf cboSearchBy.SelectedIndex = SearchItemsEnum.Merchant Then
                FilldgvContractPartyByMerchant()
            ElseIf cboSearchBy.SelectedIndex = SearchItemsEnum.Date_vc Then
                FilldgvContractPartyByDate()
            ElseIf cboSearchBy.SelectedIndex = SearchItemsEnum.SaveDate Then
                FilldgvContractPartyBySaveDate()
            ElseIf cboSearchBy.SelectedIndex = SearchItemsEnum.RequestID Then
                FilldgvContractPartyByRequestID()
            ElseIf cboSearchBy.SelectedIndex = SearchItemsEnum.Outlet Then
                FilldgvContractPartyByOutlet()
            End If
            dgvContractingParty_ContractRowEnter(0)
        Else
            Me.FilldgvContractParty()
        End If
    End Sub
    Public Sub RefreshForm()
        Me.FillcboMarketingByID()
        Me.FillcboCIdentityTypeID()
        Me.FillcboDegreeID()
        Me.FillcboAccountTypeID()
        Me.FillcboStateID()
        Me.FillcboTitle_nvc()
        Me.FillcboSSIdentityTypeID()
        Me.FillcboBranchID()
        Me.FillcboDAccountTypeID()
        Me.FillcboABranchID()
        Me.FillCboStorePosModel()

        Me.FillGroup()
        Me.FillEstateCondition()


        If SearchingContractID <> 0 Then
            Me.FilldgvContractPartyByContractID(SearchingContractID)
        Else
            Me.FilldgvContractParty()
        End If
        Me.FilldgvAccount()
        'Me.FilldgvStore()
        clsDalContract.SStoreID = 0
        'Me.FilldgvStoreTel()
        'Me.FilldgvDevice()
        'Me.FilldgvDeviceCrash()

        Me.clsMyControlerContractingParty.DataGridView = Me.dgvContractingParty_Contract
        'Me.clsMyControlerAccount.DataGridView = Me.dgvAccount
        'Me.clsMyControlerStore.DataGridView = Me.dgvStore

        Me.clsMyControlerContractingParty.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.clsMyControlerAccount.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)
        Me.clsMyControlerStore.GotoState(RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.View)

        tsMain.Enabled = True
        Me.clsMyControlerContractingParty.SetControlsValue()
        SetLinkBtn(Me.tbc.SelectedTab)


    End Sub

#End Region
#End Region
#Region "Print"
    Private Sub PrintLabel()
        If txtContractID.Text.Trim <> "" Then
            Try
                Dim dt As New DataTable

                clsDalContract.BeginProc()
                clsDalContract.ContractID = Convert.ToInt64(txtContractID.Text.Trim)
                'dt = clsDalContract.GetByContractIDContractingParty_Contract
                dt = clsDalContract.GetByContractIDContractingParty_Contract_Account_Store_PURE_SumDeviceCount
                If dt.Rows.Count > 0 Then
                    Dim deviceCount As Int16 = dt.Rows(0).Item("SumDeviceCount_tint")
                    Dim isPostBank As Int16 = dt.Rows(0).Item("cmsprojectid")

                    If isPostBank <> 3 Then
                        blnForcePrint = False
                        PrintLabelLog(dt.Rows.Count)
                        For j As Int16 = 1 To 2 + deviceCount
                            ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID
                            PrintBarcodeRoutin()
                        Next
                    Else
                        PrintContractForm()
                    End If

                Else
                    Throw New KeyNotFoundException
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.clsDalContract.EndProc()
            End Try
        Else
            Throw New KeyNotFoundException
        End If
    End Sub

    Private Sub PrintContractForm()
        Try


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub PrintLabelLog(ByVal DeviceCount As Int32)
        Try
            clsDalContract.PContractID = clsDalContract.ContractID
            clsDalContract.PDeviceCount = DeviceCount
            clsDalContract.PPrintDate = modPublicMethod.GetDateNow
            clsDalContract.PPrintTime = modPublicMethod.GetTimeNow
            clsDalContract.InsertPrintLog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PrintBarcodeRoutin()
        ClassPrintLabel(Of ClassDALContract).PrintLabelType = ClassPrintLabel(Of ClassDALContract).PrintLabelTypeEnum.ContractID
        PrintDocument.Print()
        'm_pd.Print()
    End Sub
#End Region
#Region "CheckList"
    Private Sub SetCheckListItems()
        Dim clsDALCMSProject As New ClassDALCMSProject(ConnectionString)
        clsDALCMSProject.BeginProc()
        Dim dt As New DataTable
        dt = clsDALCMSProject.GetAll()
        clsDALCMSProject.EndProc()
        Dim objCMSProject As New List(Of ClassCMSProject)
        For Counter As Int32 = 0 To dt.Rows.Count - 1
            objCMSProject.Add(New ClassCMSProject(dt.Rows(Counter)("CMSProjectID_int"), dt.Rows(Counter)("Name_nvc"), IIf(Convert.ToByte(dt.Rows(Counter)("issent2switch")) = 1, True, False), IIf(String.IsNullOrEmpty(dt.Rows(Counter)("ESSWS_NVC").ToString), "empty", dt.Rows(Counter)("ESSWS_NVC").ToString)))
        Next
        Me.chkCMSProject.DataSource = objCMSProject
        chkCMSProject.ValueMember = "CMSProjectID"
        chkCMSProject.DisplayMember = "Name"
        chkCMSProject.SelectionMode = SelectionMode.One

    End Sub

#End Region
#Region "ShabaAccountValidation"


    Private Function ShabaAccountValidation(ByVal shabaAccount As String, ByVal mTextBox As MaskedTextBox) As Boolean
        Dim result As Boolean = True
        Dim Count As Int16 = 0

        Dim ShabaSplit As String() = shabaAccount.Split(" ")

        If Me.clsMyControlerContractingParty.CurrentState = RIZNARM.WINDOWS.FORMS.ClassFormController.FormState.Edit AndAlso GetContractDeviceStatus() = True Then

            'If GetContractDeviceStatus() = True Then
            If shabaAccount.Length <> 26 Or ShabaSplit.Length > 1 Then
                txtShabaAccount.Text = String.Empty
            End If
            result = True
            'End If
            Return result
        End If


        If shabaAccount.Length < 26 Then
            ErrorProvider.SetError(mTextBox, "طول شماره حساب شبا نباید کمتر از 26 کاراکتر باشد ")
            result = False
            Return result
        Else
            ErrorProvider.SetError(mTextBox, "")
            result = True

        End If


        If ShabaSplit.Length > 1 Then
            ErrorProvider.SetError(mTextBox, "شماره حساب شبا به صورت صحیح وارد نگردیده است")
            result = False
            Return result
        Else
            ErrorProvider.SetError(mTextBox, "")
            result = True

        End If
        Return result
    End Function

    Private Function GetContractDeviceStatus() As Boolean
        Dim dt As New DataTable
        dt = clsDalContract.GetContractDeviceStatus(txtContractID.Text.Trim)
        Dim posCount As Int16 = dt.Rows.Count

        If posCount = 1 AndAlso dt.Rows(0).Item(0).ToString = "-1" Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub txtShabaAccount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShabaAccount.KeyPress, txtAShabaAccount.KeyPress
        If Char.Equals(e.KeyChar, " "c) Then
            e.KeyChar = Nothing
            Return
        End If
        Return
    End Sub

    Private Sub txtShabaAccount_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtShabaAccount.MouseClick, txtAShabaAccount.MouseClick
        Dim len As Int16 = 0
        Dim maskedTextBox As MaskedTextBox = sender
        len = maskedTextBox.Text.Length
        maskedTextBox.SelectionStart = len
    End Sub
#End Region
#End Region

    '********************************************************************************************
    '#Region "Print Kharab"
    '    ' <remarks>
    '    '   Erweitert den Druckvorschau-Dialog
    '    '   um einige optische Effekte.
    '    ' </remarks>
    '    Public Class ExtendedPrintPreviewDialog
    '        Inherits System.Windows.Forms.PrintPreviewDialog

    '    End Class

    '    '-- Ende ExtendedPrintPreviewDialog.vb --
    '    '---------- Anfang MainForm.vb ----------

    '    ' <remarks>
    '    '   Hauptformular der Anwendung.
    '    ' </remarks>


    '    Private m_pd As New Printing.PrintDocument()
    '    Private m_intCurrentPage As Integer


    '    Private Sub MainForm_Load( _
    '            ByVal sender As System.Object, _
    '            ByVal e As System.EventArgs) _
    '            Handles MyBase.Load
    '        With cboPrinters
    '            Dim s As String
    '            For Each s In Printing.PrinterSettings.InstalledPrinters
    '                .Items.Add(s)
    '            Next s
    '            If .Items.Count > 0 Then
    '                .SelectedIndex = 0
    '            Else
    '                MessageBox.Show("No printers installed, quitting!", _
    '                    Application.ProductName, _
    '                    MessageBoxButtons.OK, _
    '                    MessageBoxIcon.Exclamation)
    '                Me.Close()
    '            End If
    '        End With
    '        m_pd.DocumentName = "Unser erstes Dokument"
    '        AddHandler m_pd.PrintPage, AddressOf m_pd_PrintPage
    '        m_intCurrentPage = 0
    '    End Sub

    '    Private Sub cboPrinters_SelectedIndexChanged( _
    '            ByVal sender As System.Object, _
    '            ByVal e As System.EventArgs)

    '        If cboPrinters.SelectedIndex <> -1 Then
    '            m_pd.PrinterSettings.PrinterName = cboPrinters.Text
    '        End If
    '    End Sub

    '    Private Sub m_pd_PrintPage( _
    '            ByVal sender As System.Object, _
    '            ByVal e As System.Drawing.Printing.PrintPageEventArgs)
    '        ClassPrintLabel(Of ClassDALContract).Print(e, clsDalContract)

    '        'm_intCurrentPage += 1

    '        'Select Case m_intCurrentPage

    '        '    ' Drucken der ersten Seite.
    '        '    Case 1

    '        '        ' Zeichnen eines elliptischen Bereichs
    '        '        ' über die gesamte Seite (ohne Randabstände).
    '        '        e.Graphics.FillEllipse( _
    '        '            New Drawing2D.HatchBrush( _
    '        '            HatchStyle.Percent10, _
    '        '            Color.Red, _
    '        '            Color.White _
    '        '            ), _
    '        '            e.MarginBounds _
    '        '            )

    '        '        ' Text genau in der Mitte der Seite ausgeben.
    '        '        ' Je nach Randabständen muss das
    '        '        ' nicht unbedingt genau in der Mitte der Ellipse sein!
    '        '        Dim strText As String = "Das ist die Seite 1"
    '        '        Dim fntFont As New Font("Arial", 18)
    '        '        e.Graphics.DrawString( _
    '        '            strText, _
    '        '            fntFont, _
    '        '            New SolidBrush(Color.Blue), _
    '        '            CSng( _
    '        '            ( _
    '        '            e.PageBounds.Width - _
    '        '            e.Graphics.MeasureString(strText, fntFont).Width _
    '        '            ) * 0.5 _
    '        '            ), _
    '        '            CSng(200) _
    '        '            )

    '        '        ' Es folgen noch weitere Seiten.
    '        '        e.HasMorePages = True

    '        '        ' Drucken der zweiten Seite.
    '        '    Case 2

    '        '        ' Seitennummer im linken oberen Eck ausgeben.
    '        '        e.Graphics.DrawString( _
    '        '            "Seite 2", _
    '        '            New Font("Times New Roman", 12), _
    '        '            New SolidBrush(Color.Black), _
    '        '            e.MarginBounds.Left, _
    '        '            e.MarginBounds.Top _
    '        '            )

    '        '        ' Das war die letzte Seite.
    '        '        e.HasMorePages = False

    '        '        ' Seitenzähler wieder zurücksetzen.
    '        '        m_intCurrentPage = 0
    '        'End Select
    '    End Sub

    'Private Sub btnPrint_Click( _
    '        ByVal sender As System.Object, _
    '        ByVal e As System.EventArgs) _
    '        Handles btnPrint.Click
    '    Try
    '        If Me.PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
    '            PrintLabel()
    '        End If
    '    Catch ex As KeyNotFoundException
    '        ShowErrorMessage(modApplicationMessage.msgPrintNotFound)
    '        ClassError.LogError(ex)
    '    Catch ex As Exception
    '        ShowErrorMessage(modApplicationMessage.msgPrintFailed)
    '        ClassError.LogError(ex)
    '    End Try


    'End Sub

    '    Private Sub btnPreview_Click( _
    '            ByVal sender As System.Object, _
    '            ByVal e As System.EventArgs)


    '        ' Seitenzähler initialisieren.
    '        m_intCurrentPage = 0

    '        ' Vorschaudialog erstellen und anzeigen.
    '        Dim ppdlg As ExtendedPrintPreviewDialog = _
    '            New ExtendedPrintPreviewDialog()
    '        With ppdlg

    '            ' Der Druckvorschau das Dokument zuweisen.
    '            .Document = m_pd

    '            ' Die Druckvorschau soll maximiert gezeigt werden.
    '            .WindowState = FormWindowState.Maximized

    '            ' Druckvorschau anzeigen.
    '            .ShowDialog(Me)
    '        End With
    '    End Sub

    '    Private Sub btnChoosePrinter_Click( _
    '            ByVal sender As System.Object, _
    '            ByVal e As System.EventArgs)

    '        Dim pdlg As PrintDialog = New PrintDialog()
    '        With pdlg

    '            ' Dokument an Printerdialog weiterreichen.
    '            .Document = m_pd

    '            .PrinterSettings = m_pd.PrinterSettings
    '            .AllowPrintToFile = False
    '            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '                PrintLabel()
    '                'SelectPrinter(cboPrinters, .PrinterSettings.PrinterName)
    '            End If
    '        End With
    '    End Sub

    '    Private Sub btnPageSetup_Click( _
    '            ByVal sender As System.Object, _
    '            ByVal e As System.EventArgs)

    '        Dim psdlg As PageSetupDialog = New PageSetupDialog()
    '        With psdlg
    '            .PrinterSettings = m_pd.PrinterSettings
    '            .PageSettings = m_pd.DefaultPageSettings
    '            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

    '                ' Hier wird ein Fehler (?!) ausgebügelt: VB .NET
    '                ' konvertiert anscheinend alle Werte von Inch in
    '                ' Millimeter, da (vermutlich) im englischen Dialog
    '                ' die(Werte) in Inch eingegeben werden. Allerdings
    '                ' ist der Umrechnungsfaktor nicht genau Inch:Millimeter,
    '                ' sondern etwas mehr, sodass beim Wert 10 bei
    '                ' erneutem Aufruf 9.9 in der TextBox steht.
    '                .PageSettings.Margins = _
    '                    Printing.PrinterUnitConvert.Convert( _
    '                    .PageSettings.Margins, _
    '                    Drawing.Printing.PrinterUnit.ThousandthsOfAnInch, _
    '                    Drawing.Printing.PrinterUnit.HundredthsOfAMillimeter)

    '                ' Die Einstellungen in unserem Formular
    '                ' werden nun angepasst...
    '                SelectPrinter(cboPrinters, .PrinterSettings.PrinterName)
    '            End If
    '        End With
    '    End Sub

    '    ' <summary>
    '    '   Wählt den in <paramref name="strPrinterName"/>
    '    '   angegebenen Drucker in den Einträgen
    '    '   der im Parameter <paramref name="cboComboBox"/> ComboBox aus.
    '    ' </summary>
    '    ' <param name="cboComboBox"></param>
    '    ' <param name="strPrinterName"></param>
    '    Private Sub SelectPrinter( _
    '            ByVal cboComboBox As ToolStripComboBox, _
    '            ByVal strPrinterName As String)
    '        Dim i As Integer
    '        For i = 0 To cboComboBox.Items.Count - 1
    '            If Convert.ToString(cboComboBox.Items(i)) = strPrinterName Then
    '                cboComboBox.SelectedIndex = i
    '                Exit For
    '            End If
    '        Next i
    '    End Sub

    '#End Region

    'Private Sub SetPermissionLocal_Contract()
    '    Dim UserID As Int64 = ClassUserLoginDataAccess.ThisUser.UserID
    '    If modPublicMethod.SpecialUser() = True Then 'khodabandelou hosseini
    '        lblVisitorID.Enabled = True
    '        txtVisitorID.Enabled = True

    '        txtAccountNO_vc.MaxLength = 11
    '    Else
    '        lblVisitorID.Enabled = False
    '        txtVisitorID.Enabled = False

    '        txtAccountNO_vc.MaxLength = 10
    '    End If
    'End Sub
    'Private Sub SetPermissionLocal_Account()

    '    '---------

    'End Sub
    'Private Sub SetPermissionLocal_Store()
    '    Dim UserID As Int64 = ClassUserLoginDataAccess.ThisUser.UserID
    '    If modPublicMethod.SpecialUser() = True Then 'khodabandelou hosseini
    '        cboSStateID.Enabled = True
    '        cboSCityID.Enabled = True
    '    Else
    '        cboSStateID.Enabled = False
    '        cboSCityID.Enabled = False
    '    End If
    'End Sub
    Private Sub CheckConnection(ByVal murl As String)

        'If (Not connect) Then
        '    connect = myConStr.ConnectionAvailable(murl)
        'End If

        'If (Not connect) Then
        '    ShowErrorMessage(modApplicationMessage.msgCardAcceptorDetailByTerminalID)
        'End If


    End Sub
   
    Private Sub chkCMSProject_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkCMSProject.ItemCheck
        Try
            If chkCMSProject.CheckedItems.Count = 1 AndAlso e.CurrentValue = CheckState.Unchecked Then
                e.NewValue = CheckState.Unchecked
            End If

        Catch ex As Exception
            ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub dgvDevice_Pos_DevicePos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDevice_Pos_DevicePos.CellClick
        Try
            If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
            Dim columnName As String = dgvDevice_Pos_DevicePos.Columns(dgvDevice_Pos_DevicePos.CurrentCell.ColumnIndex).Name

            If columnName = "PrintQRCode" Then

                Dim _Frm As New frmQRCodePrint

                _Frm.Serial = IIf(dgvDevice_Pos_DevicePos.Rows(e.RowIndex).Cells("ColPSerial_vc").Value Is DBNull.Value, String.Empty, dgvDevice_Pos_DevicePos.Rows(e.RowIndex).Cells("ColPSerial_vc").Value)
                _Frm.Outlet = IIf(dgvDevice_Pos_DevicePos.Rows(e.RowIndex).Cells("ColDOutlet_vc").Value Is DBNull.Value, String.Empty, dgvDevice_Pos_DevicePos.Rows(e.RowIndex).Cells("ColDOutlet_vc").Value)
                _Frm.StoreName = IIf(Me.txtSName_nvc.Text Is DBNull.Value, String.Empty, Me.txtSName_nvc.Text)
                _Frm.ShowDialog()

            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub printPasargadContract()
        Try
            Dim dt As DataTable = clsDalContract.GetContractAllDataByID(txtContractID.Text)
            Dim r As New rptPasargad

            If (dt IsNot Nothing And dt.Rows.Count > 0) Then
                r.SetParameterValue("name", dt.Rows(0)("FirstName_nvc").ToString() + " " + dt.Rows(0)("LastName_nvc").ToString())
                r.SetParameterValue("nationalcode", dt.Rows(0)("NationalCode_nvc").ToString())
                r.SetParameterValue("birthdate", dt.Rows(0)("BirthDate_vc").ToString())
                r.SetParameterValue("homeaddress", dt.Rows(0)("HomeAddress_nvc").ToString())
                r.SetParameterValue("hometel", dt.Rows(0)("HomeTel_vc").ToString())
                r.SetParameterValue("mobile", dt.Rows(0)("STel2_vc").ToString())
                r.SetParameterValue("storeName", dt.Rows(0)("SName_nvc").ToString())
                r.SetParameterValue("groupName", dt.Rows(0)("groupname").ToString())
                r.SetParameterValue("storeAddress", dt.Rows(0)("SAddress3_Nvc").ToString())
                r.SetParameterValue("postalCOde", dt.Rows(0)("SPostCode_vc").ToString())
                r.SetParameterValue("storeTel", dt.Rows(0)("STel1_vc").ToString())
                r.SetParameterValue("accountNo", dt.Rows(0)("AAccountNO_vc").ToString())
                r.SetParameterValue("shebaAccount", dt.Rows(0)("Shabaaccount").ToString().Remove(0, 2))
                r.SetParameterValue("cityName", dt.Rows(0)("cityName").ToString())
                r.SetParameterValue("areaNumber", dt.Rows(0)("SMunicipalAreaNO_sint").ToString())
                r.PrintToPrinter(1, True, 0, 0)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class



