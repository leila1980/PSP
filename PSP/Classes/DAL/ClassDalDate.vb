Public Class ClassDalDate
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarBranchID As String
    Private mvarName_nvc As String
    Private mvarManagementID As String

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

    Public Function GetPersianDateNow() As String
        Try
            Dim PersianDate As String = String.Empty
            Dim Query As String = "select GetPersianDateNow() from Dual"
            MyBase.BeginProc()
            PersianDate = MyBase.Execute_Scalar(CommandType.Text, Query, "")
            MyBase.EndProc()
            Return PersianDate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
