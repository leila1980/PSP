Imports System.Data
Public Class ClassDALWarehouse
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub

    Public Function GetAllUserVisitorByUserID(ByVal UserID As Int32) As DataTable

        Dim dt As New DataTable
        Dim strSql As String = "select * from warehouse_t "
        strSql += String.Format("where user_id = {0}", UserID.ToString())
        Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)
        'If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)(0)) Then
        '    Return Integer.Parse(dt.Rows(0)(0))
        'End If
        'Return 0
        Return dt

    End Function

End Class
