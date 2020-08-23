Imports System.Data
Imports Oracle.DataAccess.Client

Public Class ClassDalGood
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub

    Function GetAll() As DataTable
        Try
            Dim dt As New DataTable
            Dim strSQL As String = "select * from good_t"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class


