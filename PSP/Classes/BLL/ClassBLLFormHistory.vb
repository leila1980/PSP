Public Class ClassBLLFormHistory
    Private Shared clsFormHistory As New ClassDalFormHistory(ConnectionString)

    Private Shared MyTemplate As ClassDalFormHistory.FormHistoryTemplate
    Public Shared Sub InsertToHistory(ByVal Form As Form)
        Try
            With MyTemplate
                .Date_vc = GetDateNow()
                .FormName = Form.Name
                .Time_vc = GetTimeNow()
                .UserID = ClassUserLoginDataAccess.ThisUser.UserID
                If TypeOf Form Is frmBasicTypes Then
                    .BasicType = CType(Form, frmBasicTypes).BasicType
                End If
            End With
            With clsFormHistory
                .BeginProc()
                MyTemplate.FormID = .GetFormID(MyTemplate)
                .Insert(MyTemplate)
                MyTemplate.BasicType = 0
            End With
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            clsFormHistory.EndProc()
        End Try
    End Sub
End Class
