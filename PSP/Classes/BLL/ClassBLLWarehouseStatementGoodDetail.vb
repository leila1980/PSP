Imports System.Collections

Public Class ClassBLLWarehouseStatementGoodDetail
    Public Property GoodID As Integer
    Public Property Count As Integer
    Public Property serials As List(Of String)

    Public Sub New()
        Me.serials = New List(Of String)
    End Sub

End Class
