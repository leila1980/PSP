Imports FeeSchemaService
Public Class frmContractFeeSchema
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)

    Private dtGrid As New DataTable
    Private dvGrid As New DataView

    Private colError As New Collection
    Private Error_FileName As String = "ContractFeeSchema_Err.txt"


    Private Sub frmSwitchFeeSchema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.FillGrid()
            Me.InitGrid()
            Me.FillCombo()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Try
            If txtFilter.Text.Trim.Length = 0 Then
                dvGrid.RowFilter = ""
            Else
                dvGrid.RowFilter = "ContractID='" & txtFilter.Text & "'"
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        dgv.EndEdit()
        For i As Int32 = 0 To dgv.RowCount - 1
            dgv.Rows(i).Cells("colChk").Value = True
        Next
        dgv.EndEdit()
    End Sub
    Private Sub btnSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNone.Click
        dgv.EndEdit()
        For i As Int32 = 0 To dgv.RowCount - 1
            dgv.Rows(i).Cells("colChk").Value = False
        Next
        dgv.EndEdit()

    End Sub
    Private Sub dgvContract_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        lblCount.Text = dgv.RowCount
    End Sub
    Private Sub dgvContract_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        lblCount.Text = dgv.RowCount
    End Sub

    Private Sub FillGrid()
        Try
            dtGrid = clsDalContract.GetAllContractInfo(ClassUserLoginDataAccess.ThisUser.ProjectID)
            dvGrid = dtGrid.DefaultView
            dgv.DataSource = dvGrid
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub InitGrid()
        Try
            dgv.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
            dgv.Columns("ContractID").HeaderText = "کد قرارداد"
            dgv.Columns("date_vc").HeaderText = "تاریخ قرارداد"
            dgv.Columns("Switch_FeeID_int").HeaderText = "کارمزد"
            dgv.Columns("Switch_FeeDate_vc").HeaderText = "تاریخ تخصیص کارمزد"


        Catch ex As Exception

            Throw ex
        End Try
    End Sub
    Private Sub FillCombo()
        Try
            Dim clsBLLSwitch As New ClassBLLSwitch_FeeManagement

            cboFeeSchema.DataSource = clsBLLSwitch.GetFeeSchemaList
            cboFeeSchema.ValueMember = "id"
            cboFeeSchema.DisplayMember = "name"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        Try
            dgv.EndEdit()
            colError.Clear()
            Dim clsBLLSwitch_FeeManagement As New ClassBLLSwitch_FeeManagement
            Dim Checked As Int32 = 0

            If Me.dtGrid.DefaultView.ToTable.Rows.Count = 0 Then
                modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If

            For i As Integer = 0 To dgv.RowCount - 1
                If dgv.Rows(i).Cells("colCheck").Value = True Then
                    Checked += 1
                End If
            Next
            If Checked = 0 Then
                modPublicMethod.ShowErrorMessage("رکوردی جهت ارسال انتخاب نشده است") 'modApplicationMessage.msgLoadFailed
                Exit Sub
            End If
            For i As Int32 = 0 To dgv.RowCount - 1
                Try
                    If dgv.Rows(i).Cells("colCheck").Value = True Then
                        clsBLLSwitch_FeeManagement.ContractID = dgv.Rows(i).Cells("ContractID").Value
                        clsBLLSwitch_FeeManagement.FeeSchema = cboFeeSchema.SelectedValue
                        clsBLLSwitch_FeeManagement.ContractFeeAssign()
                    End If
                Catch ex As Exception
                    colError.Add("خطا در سطر:" & (i + 1).ToString & Space(3) & ex.Message)
                    Continue For
                End Try
            Next
            If ErrHandling() = False Then
                ShowMessage(modApplicationMessage.msgSuccess)
            End If
            Me.FillGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Public Overloads Function Assign(ByVal ContractID As Int64, ByVal FeeSchema As Int32) As Boolean
        Try
            Assign = False
            clsDalContract.BeginProc()
            clsDalContract.UpdateContract_OnlyFeeSchema(ContractID, FeeSchema)
            Assign = True
        Catch ex As Exception
            Assign = False
            colError.Add(ContractID)
        Finally
            clsDalContract.EndProc()
        End Try
    End Function
    Private Function ErrHandling() As Boolean
        Try
            ClassError.BackupLogErrorFolder()
            ClassError.EmptyLogErrorFolder()

            If colError.Count > 0 Then
                ClassError.LogError(Error_FileName, colError)
                ShowErrorMessage("تعداد موارد داراي اشكال : " & colError.Count.ToString & vbCrLf & modApplicationMessage.msgCollectionError & vbCrLf + TextLogErrorFilePath + Error_FileName)
                Return True
            End If
            Return False
        Catch ex As Exception
            ErrHandling = False
            Throw ex
        End Try

    End Function

End Class
'Public Class frmContractFeeSchema
'    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)

'    Private dtGrid As New DataTable
'    Private dvGrid As New DataView

'    Private colError As New Collection
'    Private Error_FileName As String = "ContractFeeSchema_Err.txt"

'    Dim dtContractIDAllCardAcceptor As New DataTable

'    Private Sub frmSwitchFeeSchema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Try
'            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
'            Me.FillGrid()
'            Me.InitGrid()
'            Me.FillCombo()
'        Catch ex As Exception
'            ShowErrorMessage(ex.Message)
'        End Try
'    End Sub
'    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
'        Try
'            If txtFilter.Text.Trim.Length = 0 Then
'                dvGrid.RowFilter = ""
'            Else
'                dvGrid.RowFilter = "ContractID='" & txtFilter.Text & "'"
'            End If
'        Catch ex As Exception
'            ShowErrorMessage(ex.Message)
'        End Try
'    End Sub
'    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
'        dgv.EndEdit()
'        For i As Int32 = 0 To dgv.RowCount - 1
'            dgv.Rows(i).Cells("colChk").Value = True
'        Next
'        dgv.EndEdit()
'    End Sub
'    Private Sub btnSelectNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectNone.Click
'        dgv.EndEdit()
'        For i As Int32 = 0 To dgv.RowCount - 1
'            dgv.Rows(i).Cells("colChk").Value = False
'        Next
'        dgv.EndEdit()

'    End Sub
'    Private Sub dgvContract_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
'        lblCount.Text = dgv.RowCount
'    End Sub
'    Private Sub dgvContract_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
'        lblCount.Text = dgv.RowCount
'    End Sub

'    Private Sub FillGrid()
'        Try
'            dtGrid = clsDalContract.GetAllContractInfo(ClassUserLoginDataAccess.ThisUser.ProjectID)
'            dvGrid = dtGrid.DefaultView
'            dgv.DataSource = dvGrid
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub
'    Private Sub InitGrid()
'        Try
'            dgv.Columns("LastName_nvc").HeaderText = "نام خانوادگی"
'            dgv.Columns("ContractID").HeaderText = "کد قرارداد"
'            dgv.Columns("date_vc").HeaderText = "تاریخ قرارداد"
'            dgv.Columns("Switch_FeeID_int").HeaderText = "کارمزد"
'            dgv.Columns("Switch_FeeDate_vc").HeaderText = "تاریخ تخصیص کارمزد"


'        Catch ex As Exception

'            Throw ex
'        End Try
'    End Sub
'    Private Sub FillCombo()
'        Try
'            Dim clsBLLSwitch As New ClassBLLSwitch_FeeManagement

'            cboFeeSchema.DataSource = clsBLLSwitch.GetFeeSchemaList
'            cboFeeSchema.ValueMember = "id"
'            cboFeeSchema.DisplayMember = "name"
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub

'    Private Sub btnAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssign.Click
'        Try
'            dgv.EndEdit()
'            colError.Clear()
'            Dim clsBLLSwitch_FeeManagement As New ClassBLLSwitch_FeeManagement
'            Dim Checked As Int32 = 0

'            If Me.dtGrid.DefaultView.ToTable.Rows.Count = 0 Then
'                modPublicMethod.ShowErrorMessage("رکوردی برای ارسال وجود ندارد") 'modApplicationMessage.msgLoadFailed
'                Exit Sub
'            End If

'            For i As Integer = 0 To dgv.RowCount - 1
'                If dgv.Rows(i).Cells("colCheck").Value = True Then
'                    Checked += 1
'                End If
'            Next
'            If Checked = 0 Then
'                modPublicMethod.ShowErrorMessage("رکوردی جهت ارسال انتخاب نشده است") 'modApplicationMessage.msgLoadFailed
'                Exit Sub
'            End If

'            For i As Int32 = 0 To dgv.RowCount - 1
'                If dgv.Rows(i).Cells("colChk").Value = True Then
'                    If Assign(dgv.Rows(i).Cells("ContractID").Value, cboFeeSchema.SelectedValue) = True Then
'                        dtContractIDAllCardAcceptor.Clear()
'                        dtContractIDAllCardAcceptor = clsDalContract.GetByContractIDAllCardAcceptor(dgv.Rows(i).Cells("ContractID").Value, ClassUserLoginDataAccess.ThisUser.ProjectID)
'                        For j As Int32 = 0 To dtContractIDAllCardAcceptor.Rows.Count - 1
'                            Try
'                                clsDalContract.EndProc()
'                                clsBLLSwitch_FeeManagement.Switch_CardAcceptorID = dtContractIDAllCardAcceptor.Rows(j).Item("Switch_CardAcceptorID_vc")
'                                clsBLLSwitch_FeeManagement.FeeSchema = cboFeeSchema.SelectedValue
'                                clsBLLSwitch_FeeManagement.FeeAssign()
'                            Catch feeEx As Exception
'                                colError.Add(feeEx.Message)
'                            End Try
'                        Next
'                    End If
'                End If
'            Next

'            If ErrHandling() = False Then
'                ShowMessage(modApplicationMessage.msgSuccess)
'            End If
'            Me.FillGrid()
'        Catch ex As Exception
'            ShowErrorMessage(ex.Message)
'        End Try
'    End Sub

'    Public Overloads Function Assign(ByVal ContractID As Int64, ByVal FeeSchema As Int32) As Boolean
'        Try
'            Assign = False
'            clsDalContract.BeginProc()
'            clsDalContract.UpdateContract_OnlyFeeSchema(ContractID, FeeSchema)
'            Assign = True
'        Catch ex As Exception
'            Assign = False
'            colError.Add(ContractID)
'        Finally
'            clsDalContract.EndProc()
'        End Try
'    End Function
'    Private Function ErrHandling() As Boolean
'        Try
'            Dim hErr As Boolean = False
'            ClassError.BackupLogErrorFolder()
'            ClassError.EmptyLogErrorFolder()

'            If colError.Count > 0 Then
'                hErr = True
'                ClassError.LogError(Error_FileName, colError)
'                ShowErrorMessage("تعداد موارد داراي اشكال : " & colError.Count.ToString & vbCrLf & modApplicationMessage.msgCollectionError & vbCrLf + TextLogErrorFilePath + Error_FileName)
'            End If

'            ErrHandling = hErr
'        Catch ex As Exception
'            ErrHandling = False
'            Throw ex
'        End Try

'    End Function

'End Class