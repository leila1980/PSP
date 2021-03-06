﻿Public Class frmTransferRequest

    Private Sub TransferProjectToContract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

            Dim ProjectDALObj As New ClassDALProject(modPublicMethod.ConnectionString)
            cmbProject.DataSource = ProjectDALObj.GetAll()
            cmbProject.DisplayMember = "Name_nvc"
            cmbProject.ValueMember = "ProjectID_tint"

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub OkButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkButton.Click
        Try
            Dim RequestDALObj As New ClassDALRequest(modPublicMethod.ConnectionString)

            RequestDALObj.TransferRequest(Convert.ToInt64(Me.txtContract.Text), Convert.ToInt32(Me.cmbProject.SelectedValue))

            ShowMessage("درخواست انتقال یافت")
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub

End Class