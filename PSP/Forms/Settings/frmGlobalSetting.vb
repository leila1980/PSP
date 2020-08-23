Public Class frmGlobalSetting
    Private clsDalGlobalSetting As New ClassDALGlobalSetting(modPublicMethod.ConnectionString)
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Save()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message) 'modApplicationMessage.msgLoadFailed
            ClassError.LogError(ex)
        End Try
    End Sub

    Private Sub Save()
        Try
            clsDalGlobalSetting.BeginProc()
            If RequiredValidator = False Then
                Exit Sub
            End If
            clsDalGlobalSetting.DeleteAllGlobalSetting()
            clsDalGlobalSetting.Name_nvc = "WaitForSetting"
            clsDalGlobalSetting.Value_nvc = txtWaitForVisit.Text.Trim
            clsDalGlobalSetting.Type_tint = ClassDALGlobalSetting.GlobalSettingEnum.WaitForVisit
            clsDalGlobalSetting.InsertGlobalSetting()
        Catch ex As Exception
            ShowErrorMessage(modApplicationMessage.msgSaveFailed)
            ClassError.LogError(ex)
        Finally
            Me.clsDalGlobalSetting.EndProc()
        End Try
    End Sub
    Private Function RequiredValidator() As Boolean
        Dim res As Boolean = True
        If txtWaitForVisit.Text.Trim = "" Then
            ErrorProvider.SetError(txtWaitForVisit, "اطلاعات وارد شده ناقص می باشد")
            res = False
        Else
            ErrorProvider.SetError(txtWaitForVisit, "")
        End If
        Return res
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class