Public Class ClasDALAccessChange
    Private cntAccess As New OleDb.OleDbConnection
    Private cmdAccess As New OleDb.OleDbCommand


    Private mvarMerchant As String
    Private mvarOutlet As String
    Private mvarCareof As String
    Private mvarLine1 As String
    Private mvarLine2 As String
    Private mvarLine3 As String
    Private mvarLine4 As String
    Private mvarZip As String
    Private mvarRegion As String
    Private mvarCity As String
    Private mvarPhone1 As String
    Private mvarPhone2 As String
    Private mvarFax As String
    Private mvarEmail As String

#Region "Connection"
    Public Sub ConnectionOpen()
        Try
            If cntAccess.State <> ConnectionState.Open Then
                With cntAccess
                    .ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Trim(AccessChangeFilePath) & ";Persist Security Info=False"
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
    Public Property Careof() As String
        Get
            Return mvarCareof
        End Get
        Set(ByVal value As String)
            mvarCareof = value
        End Set
    End Property
    Public Property Line1() As String
        Get
            Return mvarLine1
        End Get
        Set(ByVal value As String)
            mvarLine1 = value
        End Set
    End Property
    Public Property Line2() As String
        Get
            Return mvarLine2
        End Get
        Set(ByVal value As String)
            mvarLine2 = value
        End Set
    End Property
    Public Property Line3() As String
        Get
            Return mvarLine3
        End Get
        Set(ByVal value As String)
            mvarLine3 = value
        End Set
    End Property
    Public Property Line4() As String
        Get
            Return mvarLine4
        End Get
        Set(ByVal value As String)
            mvarLine4 = value
        End Set
    End Property
    Public Property Region() As String
        Get
            Return mvarRegion
        End Get
        Set(ByVal value As String)
            mvarRegion = value
        End Set
    End Property
    Public Property City() As String
        Get
            Return mvarCity
        End Get
        Set(ByVal value As String)
            mvarCity = value
        End Set
    End Property
    Public Property Phone1() As String
        Get
            Return mvarPhone1
        End Get
        Set(ByVal value As String)
            mvarPhone1 = value
        End Set
    End Property
    Public Property Phone2() As String
        Get
            Return mvarPhone2
        End Get
        Set(ByVal value As String)
            mvarPhone2 = value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return mvarFax
        End Get
        Set(ByVal value As String)
            mvarFax = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return mvarEmail
        End Get
        Set(ByVal value As String)
            mvarEmail = value
        End Set
    End Property
    
    Public Property Zip() As String
        Get
            Return mvarZip
        End Get
        Set(ByVal value As String)
            mvarZip = value
        End Set
    End Property

    Public Sub InsertTAddress()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO TAddress ( Merchant, Outlet,  Careof, Line1, Line2, Line3, Line4,Zip, Region, City, Phone1, Phone2, Fax, Email )" & _
                               " Values ( '" + Merchant.Replace("'", "''") + "','" + Outlet.Replace("'", "''") + "','" + Careof.Replace("'", "''") + "','" + Line1.Replace("'", "''") + "','" + Line2.Replace("'", "''") + "','" + Line3.Replace("'", "''") + "','" + Line4.Replace("'", "''") + "','" + Zip.Replace("'", "''") + "','" + Region.Replace("'", "''") + "','" + City.Replace("'", "''") + "','" + Phone1.Replace("'", "''") + "','" + Phone2.Replace("'", "''") + "','" + Fax.Replace("'", "''") + "','" + Email.Replace("'", "''") + "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Sub DeleteALLTAddress()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "DELETE FROM TAddress "
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
