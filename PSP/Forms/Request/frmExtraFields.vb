Public Class frmExtraFields
    Private clsDALState As New ClassDALState(modPublicMethod.ConnectionString)
    Private clsDALCity As New ClassDALCity(modPublicMethod.ConnectionString)
    Private clsDALBasicTypes As New ClassDALBasicTypes(modPublicMethod.ConnectionString)
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDALGroup As New ClassDALGroup(modPublicMethod.ConnectionString)
    Public StateID As String
    Public cityID As String
    Public CIdentityTypeID As Int32
    Public ContractDate_vc As String
    Public ContractNo_vc As String
    Public SIdentityTypeID As Int32
    Public GroupID As String
    Public ContractID As Int64
    Public CMSProjectID As Int32

    Public Operation As OperationEnum
    Public Enum OperationEnum As Short
        Insert = 1
        Update = 2
    End Enum
    Private dtRepeated As New DataTable
    Private Sub InsertSection()
        If InsertRequiredFieldValidator() = False Then
            Exit Sub
        End If
        dtRepeated.Clear()
        clsDalContract.ContractNo_vc = txtContractNo_vc.Text
        dtRepeated = clsDalContract.GetByContractNoContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.ProjectID)

        If dtRepeated.Rows.Count > 0 Then
            erp.SetError(Me.txtContractNo_vc, "شماره قرارداد  تکراری است")
            Exit Sub
        Else
            erp.SetError(Me.txtContractNo_vc, "")
        End If

        ContractNo_vc = txtContractNo_vc.Text
        ContractDate_vc = dtxtDate_vc.Value
        StateID = cboStateID.SelectedValue
        cityID = cboCityID.SelectedValue
        CIdentityTypeID = cboCIdentityTypeID.SelectedValue
        SIdentityTypeID = cboSSIdentityTypeID.SelectedValue
        GroupID = cboSGroupID.SelectedValue

        CMSProjectID = chkCMSProject.CheckedItems(0).CMSProjectID

        Operation = OperationEnum.Insert

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub UpdateSection()
        If UpdateRequiredFieldValidator() = False Then
            Exit Sub
        End If
        dtRepeated.Clear()
        clsDalContract.ContractID = txtAvailableContractID.Text
        dtRepeated = clsDalContract.GetByContractIDContractingParty_Contract(-1)

        If dtRepeated.Rows.Count = 0 Then
            erp.SetError(Me.txtAvailableContractID, "کد قرارداد وارد شده موجود نمی باشد")
            Exit Sub
        Else
            If IsDBNull(dtRepeated.Rows(0).Item("RequestID")) = False Then
                erp.SetError(Me.txtAvailableContractID, "کد قرارداد انتخاب شده به درخواست دیگری اختصاص دارد")
                Exit Sub
            Else
                erp.SetError(Me.txtAvailableContractID, "")
            End If
        End If
        ContractID = txtAvailableContractID.Text
        Operation = OperationEnum.Update

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If rdoNewContract.Checked = True Then

                If dtxtDate_vc.Value > modPublicMethod.GetDateNow Then
                    ShowErrorMessage("تاریخ نمی تواند بزرگتر از تاریخ روز جاری باشد")
                Else
                    InsertSection()
                End If

            ElseIf rdoAvailableContract.Checked = True Then

                If dtxtDate_vc.Value > modPublicMethod.GetDateNow Then
                    ShowErrorMessage("تاریخ نمی تواند بزرگتر از تاریخ روز جاری باشد")
                Else
                    UpdateSection()
                End If

            Else
                ShowErrorMessage("آیتمی انتخاب نشده است")
            End If

          
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Function InsertRequiredFieldValidator() As Boolean
        Try
            Dim res As Boolean = True


            If txtContractNo_vc.Text.Trim = "" Then
                erp.SetError(txtContractNo_vc, "شماره قرارداد را وارد کنید")
                res = False
            Else
                erp.SetError(txtContractNo_vc, "")
            End If
            If dtxtDate_vc.Value.Length = 0 Then
                erp.SetError(dtxtDate_vc, "تاریخ را وارد کنید")
                res = False
            Else
                erp.SetError(dtxtDate_vc, "")
            End If
            If cboStateID.Text.Trim = "" Then
                erp.SetError(cboStateID, "استان را انتخاب کنید")
                res = False
            Else
                erp.SetError(cboStateID, "")
            End If
            If cboCityID.Text.Trim = "" Then
                erp.SetError(cboCityID, "شهر را انتخاب کنید")
                res = False
            Else
                erp.SetError(cboCityID, "")
            End If
            If cboCIdentityTypeID.SelectedIndex = -1 Then
                erp.SetError(cboCIdentityTypeID, "مدرک شناسایی را انتخاب کنید")
                res = False
            Else
                erp.SetError(cboCIdentityTypeID, "")
            End If
            If cboSSIdentityTypeID.SelectedIndex = -1 Then
                erp.SetError(cboSSIdentityTypeID, "مدرک شناسایی را انتخاب کنید")
                res = False
            Else
                erp.SetError(cboSSIdentityTypeID, "")
            End If
            If cboSGroupID.SelectedIndex = -1 Then
                erp.SetError(cboSGroupID, "صنف را انتخاب کنید")
                res = False
            Else
                erp.SetError(cboSGroupID, "")
            End If

            If chkCMSProject.CheckedItems.Count <= 0 Then

                erp.SetError(chkCMSProject, "نام پروژه انتخاب شود")
                res = False
            Else
                erp.SetError(chkCMSProject, "")
            End If


            Return res
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function UpdateRequiredFieldValidator() As Boolean
        Try
            Dim res As Boolean = True

            If txtAvailableContractID.Text.Trim = "" Then
                erp.SetError(txtAvailableContractID, "کد قرارداد را وارد کنید")
                res = False
            Else
                erp.SetError(txtAvailableContractID, "")
            End If

            Return res
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmExtraFields_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FormLoad()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub FormLoad()
        Try
            dtxtDate_vc.Value = modPublicMethod.GetDateNow
            rdoNewContract.Checked = True
            grpNew.Enabled = rdoNewContract.Checked
            grpAvailable.Enabled = Not rdoNewContract.Checked
            FillcboCIdentityTypeID()
            FillcboStateID()
            FillcboSSIdentityTypeID()
            FillGroup()
            Me.SetCheckListItems()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cboStateID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStateID.SelectedIndexChanged
        Try
            FillcboCityID(sender)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub FillcboStateID()
        Try
            cboStateID.DisplayMember = "Name_nvc"
            cboStateID.ValueMember = "StateID"
            Me.cboStateID.DataSource = clsDALState.GetAll
            cboStateID.SelectedValue = Me.StateID
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillcboCityID(ByVal sender As Object)
        Try

            If cboStateID.SelectedIndex = -1 Then
                clsDALCity.StateID = "-1"
            Else
                clsDALCity.StateID = cboStateID.SelectedValue
            End If
            Me.cboCityID.DisplayMember = "Name_nvc"
            Me.cboCityID.ValueMember = "CityID"
            Me.cboCityID.DataSource = clsDALCity.GetByStateID
            cboCityID.SelectedValue = cityID
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillcboCIdentityTypeID()
        Try
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.CIdentityType
            Me.cboCIdentityTypeID.DataSource = clsDALBasicTypes.GetAll
            Me.cboCIdentityTypeID.DisplayMember = "Name_nvc"
            Me.cboCIdentityTypeID.ValueMember = "ID"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillcboSSIdentityTypeID()
        Try
            Me.cboSSIdentityTypeID.DisplayMember = "Name_nvc"
            Me.cboSSIdentityTypeID.ValueMember = "ID"
            clsDALBasicTypes.TypeID_sint = ClassDALBasicTypes.BasicTypeEnum.SIdentityType
            Me.cboSSIdentityTypeID.DataSource = clsDALBasicTypes.GetAll
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
            cboSGroupID.SelectedValue = Me.GroupID
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALGroup.EndProc()
        End Try

    End Sub

  
    Private Sub lblCIdentityTypeID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblCIdentityTypeID.LinkClicked
        Try
            Dim _frmBasicTypes As New frmBasicTypes
            _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.CIdentityType
            _frmBasicTypes.ShowDialog()
            ChooseCIdentityTypeID(_frmBasicTypes)
            cboCIdentityTypeID.Focus()

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub ChooseCIdentityTypeID(ByVal frm As frmBasicTypes)
        If frm.CurID <> 0 Then
            FillcboCIdentityTypeID()
            cboCIdentityTypeID.SelectedValue = frm.CurID
        End If
    End Sub

    Private Sub lblSSIdentityTypeID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblSSIdentityTypeID.LinkClicked
        Try
            Dim _frmBasicTypes As New frmBasicTypes
            _frmBasicTypes.BasicType = ClassDALBasicTypes.BasicTypeEnum.SIdentityType
            _frmBasicTypes.ShowDialog()
            ChooseSSIdentityTypeID(_frmBasicTypes)
            cboSSIdentityTypeID.Focus()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub ChooseSSIdentityTypeID(ByVal frm As frmBasicTypes)
        If frm.CurID <> 0 Then
            FillcboSSIdentityTypeID()
            cboSSIdentityTypeID.SelectedValue = frm.CurID
        End If
    End Sub

    Private Sub lblSGroupID_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblSGroupID.LinkClicked
        Dim _frmGroup As New frmGroup
        _frmGroup.ShowDialog()
        ChooseGroupID(_frmGroup)
        cboSGroupID.Focus()
    End Sub
    Private Sub ChooseGroupID(ByVal frm As frmGroup)
        If frm.CurID <> 0 Then
            FillGroup()
            cboSGroupID.SelectedValue = frm.CurID
        End If
    End Sub

    Private Sub rdoContract_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNewContract.CheckedChanged, rdoAvailableContract.CheckedChanged
        grpNew.Enabled = rdoNewContract.Checked
        grpAvailable.Enabled = rdoAvailableContract.Checked
    End Sub

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

    Private Sub chkCMSProject_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles chkCMSProject.MouseClick
        Dim idx, sidx As Integer
        sidx = chkCMSProject.SelectedIndex
        For idx = 0 To chkCMSProject.Items.Count - 1
            If idx <> sidx Then
                chkCMSProject.SetItemChecked(idx, False)
            Else
                chkCMSProject.SetItemChecked(sidx, True)
            End If
        Next
    End Sub

End Class