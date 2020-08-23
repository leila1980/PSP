Public Class frmFillDesWhenDeleteFromInstallingDetail
    Private clsDAlContrct As New ClassDALContract(modPublicMethod.ConnectionString)
    Private mvarDeviceID As Int64
    Public Property DeviceID()
        Get
            Return mvarDeviceID
        End Get
        Set(ByVal value)
            mvarDeviceID = value
        End Set
    End Property
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            clsDAlContrct.BeginProc()
            ErrorProvider1.Clear()
            If txtDesc_nvc.Text = "" Then
                ErrorProvider1.SetError(txtDesc_nvc, " Ê÷ÌÕ«  —« Ê«—œ ﬂ‰Ìœ")
                Exit Sub
            End If
            clsDAlContrct.UpdateDeviceForOnlyDesc(txtDesc_nvc.Text, DeviceID)
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            clsDAlContrct.EndProc()
        End Try
    End Sub
End Class