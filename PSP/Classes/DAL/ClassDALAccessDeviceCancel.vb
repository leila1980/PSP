Public Class ClassDALAccessDeviceCancel
    Private cntAccess As New OleDb.OleDbConnection
    Private cmdAccess As New OleDb.OleDbCommand

    '////////Client_Data//////////////
    Private mvarPos_Code As String
    Private mvarPos As Boolean
    Private mvarMerchant As Boolean
    Private mvarOutlet As Boolean
    '//////////////////////////////
#Region "Connection"
    Public Sub ConnectionOpen()
        Try
            If cntAccess.State <> ConnectionState.Open Then
                With cntAccess
                    .ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Trim(AccessDeviceCancelFilePath) & ";Persist Security Info=False"
                    .Open()
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ConnectionClose()
        Try
            cntAccess.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Property"
    Public Property Pos_Code() As String
        Get
            Return mvarPos_Code
        End Get
        Set(ByVal value As String)
            mvarPos_Code = value
        End Set
    End Property
    Public Property Pos() As String
        Get
            Return mvarPos
        End Get
        Set(ByVal value As String)
            mvarPos = value
        End Set
    End Property
    Public Property Merchant() As String
        Get
            Return mvarMerchant
        End Get
        Set(ByVal value As String)
            mvarMerchant = value
        End Set
    End Property
    Public Property Outlet() As String
        Get
            Return mvarOutlet
        End Get
        Set(ByVal value As String)
            mvarOutlet = value
        End Set
    End Property
    '///////////////
#End Region
#Region "Delete"
    Public Sub DeleteALLTCancellation()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "DELETE FROM TCancellation "
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region
#Region "Insert"
    Public Sub InsertTCancellation()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text

                .CommandText = "INSERT INTO TCancellation " + _
                                "( Pos_Code," + _
                                "Pos," + _
                                "Merchant," + _
                                "Outlet)" + _
                                " Values ( '" + Pos_Code.Replace("'", "''") + "'," + _
                                Pos + "," + _
                                Merchant + "," + _
                                Outlet + ")"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
End Class
