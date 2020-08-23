Public Class Dal
    Inherits RIZNARM.Data.Oracle_Client.DataAccess

    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub
End Class
