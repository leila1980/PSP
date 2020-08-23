Public Class ClassDALAccessAccounting
    Private cntAccess As New OleDb.OleDbConnection
    Private cmdAccess As New OleDb.OleDbCommand

    '////////Client_Data//////////////
    Private mvarAccountID As String
    Private mvarBranch_Code As String
    Private mvarClient_Code As String
    Private mvarFirst_Name As String
    Private mvarFamily_Name As String
    Private mvarGender As String
    Private mvarFather_Name As String
    Private mvarBirth_Date As String
    Private mvarBirth_City As String
    Private mvarLegal_ID As String
    Private mvarAccount_Type As String
    Private mvarActivity_Code As String
    Private mvarSocio_Prof_Code As String
    Private mvarAddress_1_Code As String
    Private mvarAddress As String
    Private mvarPhone_1 As String
    Private mvarPhone_2 As String
    Private mvarZip_Code As String
    Private mvarAccountNO_vc As String
    Private mvarCardNo_vc As String
    '//////////////////////////////
#Region "Connection"
    Public Sub ConnectionOpen()
        Try
            If cntAccess.State <> ConnectionState.Open Then
                With cntAccess
                    .ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Trim(AccessAccountingFilePath) & ";Persist Security Info=False"
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
#Region "Client_Data"

    Public Property AccountID() As String
        Get
            Return mvarAccountID
        End Get
        Set(ByVal value As String)
            mvarAccountID = value
        End Set
    End Property
    Public Property Branch_Code() As String
        Get
            Return mvarBranch_Code
        End Get
        Set(ByVal value As String)
            mvarBranch_Code = value
        End Set
    End Property
    Public Property Client_Code() As String
        Get
            Return mvarClient_Code
        End Get
        Set(ByVal value As String)
            mvarClient_Code = value
        End Set
    End Property
    Public Property First_Name() As String
        Get
            Return mvarFirst_Name
        End Get
        Set(ByVal value As String)
            mvarFirst_Name = value
        End Set
    End Property
    Public Property Family_Name() As String
        Get
            Return mvarFamily_Name
        End Get
        Set(ByVal value As String)
            mvarFamily_Name = value
        End Set
    End Property
    Public Property Gender() As String
        Get
            Return mvarGender
        End Get
        Set(ByVal value As String)
            mvarGender = value
        End Set
    End Property
    Public Property Father_Name() As String
        Get
            Return mvarFather_Name
        End Get
        Set(ByVal value As String)
            mvarFather_Name = value
        End Set
    End Property
    Public Property Birth_Date() As String
        Get
            Return mvarBirth_Date
        End Get
        Set(ByVal value As String)
            mvarBirth_Date = value
        End Set
    End Property
    Public Property Birth_City() As String
        Get
            Return mvarBirth_City
        End Get
        Set(ByVal value As String)
            mvarBirth_City = value
        End Set
    End Property
    Public Property Legal_ID() As String
        Get
            Return mvarLegal_ID
        End Get
        Set(ByVal value As String)
            mvarLegal_ID = value
        End Set
    End Property
    Public Property Account_Type() As String
        Get
            Return mvarAccount_Type
        End Get
        Set(ByVal value As String)
            mvarAccount_Type = value
        End Set
    End Property
    Public Property Activity_Code() As String
        Get
            Return mvarActivity_Code
        End Get
        Set(ByVal value As String)
            mvarActivity_Code = value
        End Set
    End Property
    Public Property Socio_Prof_Code() As String
        Get
            Return mvarSocio_Prof_Code
        End Get
        Set(ByVal value As String)
            mvarSocio_Prof_Code = value
        End Set
    End Property
    Public Property Address_1_Code() As String
        Get
            Return mvarAddress_1_Code
        End Get
        Set(ByVal value As String)
            mvarAddress_1_Code = value
        End Set
    End Property
    Public Property Address() As String
        Get
            Return mvarAddress
        End Get
        Set(ByVal value As String)
            mvarAddress = value
        End Set
    End Property
    Public Property Phone_1() As String
        Get
            Return mvarPhone_1
        End Get
        Set(ByVal value As String)
            mvarPhone_1 = value
        End Set
    End Property
    Public Property Phone_2() As String
        Get
            Return mvarPhone_2
        End Get
        Set(ByVal value As String)
            mvarPhone_2 = value
        End Set
    End Property
    Public Property Zip_Code() As String
        Get
            Return mvarZip_Code
        End Get
        Set(ByVal value As String)
            mvarZip_Code = value
        End Set
    End Property
    Public Property AccountNO_vc() As String
        Get
            Return mvarAccountNO_vc
        End Get
        Set(ByVal value As String)
            mvarAccountNO_vc = value
        End Set
    End Property
    Public Property CardNo_vc() As String
        Get
            Return mvarCardNo_vc
        End Get
        Set(ByVal value As String)
            mvarCardNo_vc = value
        End Set
    End Property

#End Region

    '///////////////
#End Region
#Region "Delete"
    Public Sub DeleteALLTClient_Data()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "DELETE FROM Client_Data "
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

    Public Sub InsertTClient_Data()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text

                .CommandText = "INSERT INTO Client_Data " + _
                                "( AccountID," + _
                                "Branch_Code," + _
                                "Client_Code," + _
                                "First_Name," + _
                                "Family_Name," + _
                                "Gender," + _
                                "Father_Name," + _
                                "Birth_Date," + _
                                "Birth_City," + _
                                "Legal_ID," + _
                                "Account_Type," + _
                                "Activity_Code," + _
                                "Socio_Prof_Code," + _
                                "Address_1_Code," + _
                                "Address," + _
                                "Phone_1," + _
                                "Phone_2," + _
                                "Zip_Code," + _
                                "AccountNO_vc," + _
                                "CardNo_vc)" + _
                                " Values ( '" + AccountID.Replace("'", "''") + "'," + _
                                "'" + Branch_Code.Replace("'", "''") + "'," + _
                                "'" + Client_Code.Replace("'", "''") + "'," + _
                                "'" + First_Name.Replace("'", "''") + "'," + _
                                "'" + Family_Name.Replace("'", "''") + "'," + _
                                "'" + Gender.Replace("'", "''") + "'," + _
                                "'" + Father_Name.Replace("'", "''") + "'," + _
                                "'" + Birth_Date.Replace("'", "''") + "'," + _
                                "'" + Birth_City.Replace("'", "''") + "'," + _
                                "'" + Legal_ID.Replace("'", "''") + "'," + _
                                "'" + Account_Type.Replace("'", "''") + "'," + _
                                "'" + Activity_Code.Replace("'", "''") + "'," + _
                                "'" + Socio_Prof_Code.Replace("'", "''") + "'," + _
                                "'" + Address_1_Code.Replace("'", "''") + "'," + _
                                "'" + Address.Replace("'", "''") + "'," + _
                                "'" + Phone_1.Replace("'", "''") + "'," + _
                                "'" + Phone_2.Replace("'", "''") + "'," + _
                                "'" + Zip_Code.Replace("'", "''") + "'," + _
                                "'" + AccountNO_vc.Replace("'", "''") + "'," + _
                                "'" + CardNo_vc.Replace("'", "''") + "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetTClient_Data(ByVal FilePath As String) As DataTable
        Dim daAccess As New OleDb.OleDbDataAdapter
        cntAccess.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Trim(FilePath) & ";Persist Security Info=False"
        Dim dt As New DataTable
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "Select * From Client_Data"
            End With
            daAccess.SelectCommand = cmdAccess
            daAccess.Fill(dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
