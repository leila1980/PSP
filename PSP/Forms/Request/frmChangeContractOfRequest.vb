Public Class frmChangeContractOfRequest
    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)

    Private dtRequest As New DataTable
    Private dtContract As New DataTable

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub Clear()
        txtContractID.Clear()
        txtRequestID.Clear()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            erp.Clear()
            If RequiredValidator() = False Then
                Exit Sub
            End If
            dtRequest.Clear()
            dtRequest = clsDalContract.GetByRequestIDContract(txtRequestID.Text)
            If dtRequest.Rows.Count = 0 Then
                erp.SetError(Me.txtRequestID, "شماره درخواست وارد شده موجود نبوده و یا در حاضر به قرارداد دیگری اختصاص ندارد")
                Exit Sub
            Else
                erp.SetError(Me.txtRequestID, "")
            End If
            dtContract.Clear()
            clsDalContract.ContractID = txtContractID.Text
            dtContract = clsDalContract.GetByContractIDContractingParty_Contract(ClassUserLoginDataAccess.ThisUser.ProjectID)
            If dtContract.Rows.Count = 0 Then
                erp.SetError(Me.txtContractID, "کد قرارداد وارد شده موجود نمی باشد")
                Exit Sub
            Else
                If IsDBNull(dtContract.Rows(0).Item("RequestID")) = False Then
                    erp.SetError(Me.txtContractID, "کد قرارداد انتخاب شده به درخواست دیگری اختصاص دارد")
                    Exit Sub
                Else
                    erp.SetError(Me.txtContractID, "")
                End If
            End If

            Save(dtRequest.Rows(0).Item("ContractID"), txtContractID.Text, txtRequestID.Text)

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub Save(ByVal OldContractID As Int64, ByVal NewContractID As Int64, ByVal RequestID As Int64)
        Try
            clsDalContract.BeginProc()
            clsDalContract.ChangeContractOfRequest(OldContractID, NewContractID, RequestID)
            clsDalContract.EndProc()
            Me.Clear()
        Catch ex As Exception
            clsDalContract.RollBackProc()
            Throw ex
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Try
            Dim res As Boolean = True

            If txtContractID.Text.Trim = "" Then
                erp.SetError(txtContractID, "کد قرارداد را وارد کنید")
                res = False
            Else
                erp.SetError(txtContractID, "")
            End If

            If txtRequestID.Text.Trim = "" Then
                erp.SetError(txtRequestID, "شماره درخواست را وارد کنید")
                res = False
            Else
                erp.SetError(txtRequestID, "")
            End If

            Return res
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class