Public Class frmChangeVisitors
    Private clsDALContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private clsDALVisitor As New ClassDALVisitor(modPublicMethod.ConnectionString)

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        Try
            erp.Clear()
            If cboDestVisitor.SelectedIndex = -1 Then
                erp.SetError(cboDestVisitor, "بازاریاب را انتخاب نمایید")
                Exit Sub
            End If
            If ShowConfirmDeleteMessage("آیا مایل به ادامه هستید؟") = False Then
                Exit Sub
            End If
            ChangeVisitors()
            MsgBox("عملیات با موفقیت انجام شد")
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub ChangeVisitors()
        Try
            clsDALContract.BeginProc()
            clsDALContract.UpdateContractByState_Management_City_Visitor(uc_SMC.StateID, uc_SMC.CityID, uc_SMC.ManagementID, uc_Visitor.VisitorID, cboDestVisitor.SelectedValue)
            clsDALContract.EndProc()
        Catch ex As Exception
            clsDALContract.RollBackProc()
            Throw ex
        End Try
    End Sub
    Private Sub frmChangeVisitors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            FillcboVisitorID()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillcboVisitorID()
        Try
            Me.clsDALVisitor.BeginProc()
            cboDestVisitor.DisplayMember = "FullName_nvc"
            cboDestVisitor.ValueMember = "VisitorID"
            Me.cboDestVisitor.DataSource = clsDALVisitor.GetAll()
        Catch ex As Exception
            Throw ex
        Finally
            Me.clsDALVisitor.EndProc()
        End Try
    End Sub
End Class