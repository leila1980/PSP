Public Class Frm_PosSerials
    Dim Ds_Packing As New DataSet
    Dim oClsPacking As New ClassDalPAcking(ConnectionString) 'modPublicMethod.ConnectionString
    'Dim ClsDalProject As New ClassDalProject(ConnectionString)
    Private clsMyControler As New RIZNARM.WINDOWS.FORMS.ClassFormController(Me.Dgv_Code, True, True, True, True)
    Dim Dv_Packing As DataView
    Protected CanView As Boolean
    Protected CanEdit As Boolean
    Protected CanNew As Boolean
    Protected CanDelete As Boolean
    Protected CanPrint As Boolean
    Private Sub Frm_PosSerials_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(clsMyControler, Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

            Ds_Packing = oClsPacking.Fill_DsPacking
            Cmb_PM.DataSource = Ds_Packing.Tables("PosModel_T")
            Cmb_PM.DisplayMember = "Name_nvc"
            Cmb_PM.ValueMember = "PosModelID"
            Cmb_PM.SelectedIndex = -1
            Cmb_Date.Text = GetDateNow()
            Dim dt As New DataTable

            Txt_EniacCode.Focus()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try

    End Sub
#Region "Txts_KeyDown"
    Private Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click
        Me.Close()
    End Sub
    Private Sub Txt_EniacCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_EniacCode.KeyDown
        If e.KeyCode = Keys.Enter Then

            ErrorProvider.Clear()
            If Txt_EniacCode.Text = "" Then
                ErrorProvider.SetError(Txt_EniacCode, "کد پیگیری وارد نشده است")
                Txt_EniacCode.Focus()
                Exit Sub
            End If
            If oClsPacking.IsNotValueInPacking("EniacCode_vc", Txt_EniacCode.Text) Then
                ErrorProvider.SetError(Txt_EniacCode, "کد پیگیری نامعتبر است")
                Txt_EniacCode.SelectAll()
                'Exit Sub
            ElseIf oClsPacking.IsPacking(Txt_EniacCode.Text) Then
                ErrorProvider.SetError(Txt_EniacCode, "این کد به دستگاه دیگری الصاق شده است")
                Txt_EniacCode.SelectAll()
                'Exit Sub
            Else
                Txt_PropertyCode.Focus()
            End If
            'End If
        End If

    End Sub
    Private Sub Txt_PropertyCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_PropertyCode.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Txt_PropertyCode.Text = "" Then
                ErrorProvider.SetError(Txt_PropertyCode, "کد اموال وارد نشده است")
                Txt_PropertyCode.Focus()
                Exit Sub
            End If
            If oClsPacking.IsNotValueInPacking("PropertyNo_vc", Txt_PropertyCode.Text) = False Then
                ErrorProvider.SetError(Txt_PropertyCode, "این کد به دستگاه دیگری الصاق شده است")
                Txt_PropertyCode.SelectAll()
            Else
                Txt_PosSelrial.Focus()
            End If
        End If
        'Txt_PosSelrial.Focus()
    End Sub
    Private Sub Txt_PosSelrial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_PosSelrial.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_PosSelrial.Text = "" Then
                ErrorProvider.SetError(Txt_PosSelrial, "سریال دستگاه وارد نشده است")
                Txt_PosSelrial.Focus()
                Exit Sub
            End If
            If Txt_PN.Text = "" Then
                Txt_PN.Focus()
            Else
                Btn_Ok.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_PN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_PN.KeyDown
        If e.KeyCode = Keys.Enter Then Cmb_PM.Focus()
    End Sub
    Private Sub Cmb_PM_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmb_PM.KeyDown
        If e.KeyCode = Keys.Enter Then Txt_PartNo.Focus()
    End Sub
    Private Sub Txt_Batch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Batch.KeyDown
        If e.KeyCode = Keys.Enter Then Btn_Ok.Focus()
    End Sub
    Private Sub Txt_PartNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_PartNo.KeyDown
        If e.KeyCode = Keys.Enter Then Txt_Batch.Focus()
    End Sub
#End Region
    Private Sub Btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ok.Click
        Try
            If CheckTxts() Then

                If oClsPacking.IsNotValueInPacking("PropertyNo_vc", Txt_PropertyCode.Text) Then _
                oClsPacking.UpdatePackingT(Txt_EniacCode.Text, Txt_PropertyCode.Text, Txt_PosSelrial.Text, _
                Cmb_PM.SelectedValue.ToString, Txt_PN.Text, Txt_Batch.Text, Cmb_Date.Text, Txt_PartNo.Text)

                DGV_AddNewRow()
                Txt_EniacCode.Text = ""
                Txt_PropertyCode.Text = ""
                Txt_PosSelrial.Text = ""
                Txt_EniacCode.Focus()


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Function CheckTxts() As Boolean
        ErrorProvider.Clear()
        Dim Ctrl As Boolean = True


        '*********
        If Txt_EniacCode.Text = "" Then
            ErrorProvider.SetError(Txt_EniacCode, "کد پیگیری نامعتبر است")
            Ctrl = False
            Txt_EniacCode.Focus()
        Else
            If oClsPacking.IsPacking(Txt_EniacCode.Text) Then
                ErrorProvider.SetError(Txt_EniacCode, "این کد به دستگاه دیگری الصاق شده است")
                Ctrl = False
                Txt_EniacCode.Focus()
                'Exit Function
            End If
            If oClsPacking.IsNotValueInPacking("EniacCode_vc", Txt_EniacCode.Text) Then
                ErrorProvider.SetError(Txt_EniacCode, "کد پیگیری نامعتبر است")
                Ctrl = False
                Txt_EniacCode.Focus()
                'Exit Function
            End If
            If oClsPacking.IsExistCodeInPacking("EniacCode_vc", Txt_EniacCode.Text) = False Then
                ErrorProvider.SetError(Txt_EniacCode, "کد پیگیری موجود نمی باشد")
                Ctrl = False
                Txt_EniacCode.Focus()
                'Exit Function
            End If
        End If
        '*************************
        If Txt_PropertyCode.Text = "" Then
            ErrorProvider.SetError(Txt_PropertyCode, "کد اموال نامعتبر است")
            Ctrl = False
            Txt_PropertyCode.Focus()
        ElseIf oClsPacking.IsNotValueInPacking("TempPropertyNo_vc", Txt_PropertyCode.Text) Then
            ErrorProvider.SetError(Txt_PropertyCode, "کد اموال در سیستم موجود نیست")
            Ctrl = False
            Txt_PropertyCode.Focus()
        Else
            If oClsPacking.IsNotValueInPacking("PropertyNo_vc", Txt_PropertyCode.Text) = False Then
                ErrorProvider.SetError(Txt_PropertyCode, "این کد به دستگاه دیگری الصاق شده است")
                Ctrl = False
                Txt_PropertyCode.Focus()

            End If
        End If
        If oClsPacking.IsExistCodeInPacking("TempPropertyNo_vc", Txt_PropertyCode.Text) = False Then
            ErrorProvider.SetError(Txt_PropertyCode, "کد اموال موجود نمی باشد")
            Ctrl = False
            Txt_PropertyCode.Focus()
            Exit Function
        End If
        '**********************
        If Txt_PosSelrial.Text = "" Then
            ErrorProvider.SetError(Txt_PosSelrial, "سریال دستگاه نامعتبر است")
            Ctrl = False
            Txt_PosSelrial.Focus()
        ElseIf oClsPacking.IsNotSerialInPacking(Txt_PosSelrial.Text) = False Then
            ErrorProvider.SetError(Txt_PosSelrial, "این سریال به دستگاه دیگری الصاق شده است")
            Ctrl = False
            Txt_PosSelrial.Focus()
        End If

        If Txt_PN.Text = "" Then
            ErrorProvider.SetError(Txt_PN, "PN" + "محصول نامعتبر است")
            Ctrl = False
            Txt_PN.Focus()
        End If
        If Cmb_PM.Text = "" Then
            ErrorProvider.SetError(Cmb_PM, "مدل دستگاه نامعتبر است")
            Ctrl = False
            Cmb_PM.Focus()
        End If
        If Txt_Batch.Text = "" Then
            ErrorProvider.SetError(Txt_Batch, "شماره بچ نامعتبر است")
            Ctrl = False
            Txt_Batch.Focus()

        End If
        Return Ctrl
    End Function
    Private Sub DGV_AddNewRow()
        Try
            Dgv_Code.Rows.Add()
            Dim Index As Int16 = Dgv_Code.Rows.Count - 1
            'Dgv_Code.Rows.Add()
            Dgv_Code.Rows(Index).Cells("ColEniacCoder").Value = Txt_EniacCode.Text
            Dgv_Code.Rows(Index).Cells("ColPropertyCode").Value = Txt_PropertyCode.Text
            Dgv_Code.Rows(Index).Cells("ColSerial").Value = Txt_PosSelrial.Text
            Dgv_Code.Rows(Index).Cells("ColPM").Value = Cmb_PM.Text
            Dgv_Code.Rows(Index).Cells("ColPN").Value = Txt_PN.Text
            Dgv_Code.Rows(Index).Cells("ColBatchNo").Value = Txt_Batch.Text
            'Dgv_Code.Rows(Index).Cells("ColProject").Value = Cmb_Project.Text 'oClsPacking.GetProject(Txt_EniacCode.Text)
            Dgv_Code.Rows(Index).Cells("ColPartNo").Value = Txt_PartNo.Text'oClsPacking.GetProject(Txt_EniacCode.Text)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Cmb_Project_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Txt_Batch.Text = oClsPacking.GetMaxCode("BatchNo_int")
    End Sub

    
End Class
