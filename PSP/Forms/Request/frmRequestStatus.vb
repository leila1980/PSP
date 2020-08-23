Public Class frmRequestStatus
    Private clsDalRequest As New ClassDALRequest(modPublicMethod.ConnectionString)
    Private dtRequestStatus As New DataTable

    Public RequestStatusID As Int16
    Public DuplicateRequestID As Int64

    Private Sub frmRequestStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            RemoveHandler cboRequestStatus.SelectedIndexChanged, AddressOf cboRequestStatus_SelectedIndexChanged
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillCombo()
            txtDuplicateRequestID.Enabled = False
            AddHandler cboRequestStatus.SelectedIndexChanged, AddressOf cboRequestStatus_SelectedIndexChanged
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            erp.Clear()
            If RequiredValidtor() = False Then
                Exit Sub
            End If
            RequestStatusID = cboRequestStatus.SelectedValue
            If txtDuplicateRequestID.Enabled = True Then
                DuplicateRequestID = txtDuplicateRequestID.Text.Trim
            Else
                DuplicateRequestID = -1
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FillCombo()
        Try
            dtRequestStatus.Clear()
            dtRequestStatus = clsDalRequest.GetAllRequestStatus()
            cboRequestStatus.DataSource = dtRequestStatus
            cboRequestStatus.DisplayMember = "Name_nvc"
            cboRequestStatus.ValueMember = "RequestStatusID"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cboRequestStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cboRequestStatus.SelectedValue = ClassDALRequest.RequestStatusEnum.repeated Then
            txtDuplicateRequestID.Enabled = True
        Else
            txtDuplicateRequestID.Enabled = False
        End If
    End Sub
    Private Function RequiredValidtor() As Boolean
        Try
            Dim res As Boolean = True
            If cboRequestStatus.SelectedIndex = -1 Then
                erp.SetError(cboRequestStatus, "وضعیت درخواست را انتخاب نمایید")
                res = False
            Else
                erp.SetError(cboRequestStatus, "")
            End If
            If txtDuplicateRequestID.Enabled = True AndAlso txtDuplicateRequestID.Text.Trim = "" Then
                erp.SetError(txtDuplicateRequestID, "شماره درخواست تکراری را وارد نمایید")
                res = False
            Else
                erp.SetError(txtDuplicateRequestID, "")
            End If
            Return res
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class