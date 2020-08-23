Public Class ClassDALExcel
    Private cntExcel As New OleDb.OleDbConnection
    Private cmdExcel As New OleDb.OleDbCommand
#Region "Variables"
    '////////ContractingParty//////////
    Private mvarContractingPartyID As String
    Private mvarFirstName_nvc As String
    Private mvarLastName_nvc As String
    Private mvarFatherName_nvc As String
    Private mvarIdentityCertificateNO_nvc As String
    Private mvarNationalCode_nvc As String
    Private mvarGender_bit As Boolean
    Private mvarBirthDate_vc As String
    Private mvarStateID As String
    Private mvarCityID As String
    Private mvarCIdentityTypeID As Int32
    Private mvarDegreeID As Int32
    Private mvarTitle_nvc As String
    Private mvarHomeAddress_nvc As String
    Private mvarHomeTel_vc As String
    Private mvarMobile_vc As String
    Private mvarEmail_nvc As String
    Private mvarHavingAccount_bit As Boolean
    Private mvarAccountTypeID As Int32
    Private mvarAccountNO_vc As String
    Private mvarCardNo_vc As String
    Private mvarBranchID As String
    '/////////Contract/////////////////
    Private mvarContractID As Int64
    'Private mvarContractingPartyID As Int64
    Private mvarContractNo_vc As String
    Private mvarMerchant_vc As String
    Private mvarSaveDate_vc As String
    Private mvarDate_vc As String
    Private mvarVisitorID As Int32
    '////////////Account/////////////
    Private mvarAAccountID As Int64
    'Private mvarAContractID As Int64
    Private mvarAAccountNO_vc As String
    Private mvarACardNo_vc As String
    Private mvarAAccountTypeID As Int32
    Private mvarABranchID As String
    '//////////Store///////////////////
    Private mvarSStoreID As Int64
    'Private mvarSAccountID As Int64
    Private mvarSGroupID As String
    Private mvarSStateID As String
    Private mvarSCityID As String
    Private mvarSName_nvc As String
    Private mvarSPostCode_vc As String
    Private mvarSAddress_nvc As String
    Private mvarSTel1_vc As String
    Private mvarSTel2_vc As String
    Private mvarSFax_vc As String
    Private mvarSMunicipalAreaNO_sint As Int16
    Private mvarSEstateConditionID As Int32
    Private mvarSSIdentityTypeID As Int32
    'Private mvarContractID As int64
    Private mvarSSIdentityTypeSDate_vc As String
    Private mvarSSIdentityTypeEDate_vc As String
    Private mvarSDeviceCount_tint As Int16
#End Region

#Region "Connection"
    Public Sub ConnectionOpen(ByVal FilePath)
        Try
            If cntExcel.State <> ConnectionState.Open Then
                With cntExcel
                    .ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                                        "Data Source=" & Trim(FilePath) & ";" & _
                                        "Extended Properties=""Excel 8.0;HDR=YES"""
                    '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Trim(FilePath) & ";Persist Security Info=False"
                    .Open()
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ConnectionClose()
        Try
            cntExcel.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
#Region "Property"
#Region "Property ContractingParty"
    Public Property ContractingPartyID() As String
        Get
            Return mvarContractingPartyID
        End Get
        Set(ByVal value As String)
            mvarContractingPartyID = value
        End Set
    End Property
    Public Property FirstName_nvc() As String
        Get
            Return mvarFirstName_nvc
        End Get
        Set(ByVal value As String)
            mvarFirstName_nvc = value
        End Set
    End Property
    Public Property LastName_nvc() As String
        Get
            Return mvarLastName_nvc
        End Get
        Set(ByVal value As String)
            mvarLastName_nvc = value
        End Set
    End Property
    Public Property FatherName_nvc() As String
        Get
            Return mvarFatherName_nvc
        End Get
        Set(ByVal value As String)
            mvarFatherName_nvc = value
        End Set
    End Property
    Public Property IdentityCertificateNO_nvc() As String
        Get
            Return mvarIdentityCertificateNO_nvc
        End Get
        Set(ByVal value As String)
            mvarIdentityCertificateNO_nvc = value
        End Set
    End Property
    Public Property NationalCode_nvc() As String
        Get
            Return mvarNationalCode_nvc
        End Get
        Set(ByVal value As String)
            mvarNationalCode_nvc = value
        End Set
    End Property
    Public Property Gender_bit() As Boolean
        Get
            Return mvarGender_bit
        End Get
        Set(ByVal value As Boolean)
            mvarGender_bit = value
        End Set
    End Property
    Public Property BirthDate_vc() As String
        Get
            Return mvarBirthDate_vc
        End Get
        Set(ByVal value As String)
            mvarBirthDate_vc = value
        End Set
    End Property
    Public Property StateID() As String
        Get
            Return mvarStateID
        End Get
        Set(ByVal value As String)
            mvarStateID = value
        End Set
    End Property
    Public Property CityID() As String
        Get
            Return mvarCityID
        End Get
        Set(ByVal value As String)
            mvarCityID = value
        End Set
    End Property
    Public Property CIdentityTypeID() As Int32
        Get
            Return mvarCIdentityTypeID
        End Get
        Set(ByVal value As Int32)
            mvarCIdentityTypeID = value
        End Set
    End Property
    Public Property DegreeID() As Int32
        Get
            Return mvarDegreeID
        End Get
        Set(ByVal value As Int32)
            mvarDegreeID = value
        End Set
    End Property
    Public Property Title_nvc() As String
        Get
            Return mvarTitle_nvc
        End Get
        Set(ByVal value As String)
            mvarTitle_nvc = value
        End Set
    End Property
    Public Property HomeAddress_nvc() As String
        Get
            Return mvarHomeAddress_nvc
        End Get
        Set(ByVal value As String)
            mvarHomeAddress_nvc = value
        End Set
    End Property
    Public Property HomeTel_vc() As String
        Get
            Return mvarHomeTel_vc
        End Get
        Set(ByVal value As String)
            mvarHomeTel_vc = value
        End Set
    End Property
    Public Property Mobile_vc() As String
        Get
            Return mvarMobile_vc
        End Get
        Set(ByVal value As String)
            mvarMobile_vc = value
        End Set
    End Property
    Public Property Email_nvc() As String
        Get
            Return mvarEmail_nvc
        End Get
        Set(ByVal value As String)
            mvarEmail_nvc = value
        End Set
    End Property
    Public Property HavingAccount_bit() As Boolean
        Get
            Return mvarHavingAccount_bit
        End Get
        Set(ByVal value As Boolean)
            mvarHavingAccount_bit = value
        End Set
    End Property
    Public Property AccountTypeID() As Int32
        Get
            Return mvarAccountTypeID
        End Get
        Set(ByVal value As Int32)
            mvarAccountTypeID = value
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
    Public Property BranchID() As String
        Get
            Return mvarBranchID
        End Get
        Set(ByVal value As String)
            mvarBranchID = value
        End Set
    End Property
#End Region
#Region "Property Contract"
    Public Property ContractID() As Int64
        Get
            Return mvarContractID
        End Get
        Set(ByVal value As Int64)
            mvarContractID = value
        End Set
    End Property
    Public Property ContractNo_vc() As String
        Get
            Return mvarContractNo_vc
        End Get
        Set(ByVal value As String)
            mvarContractNo_vc = value
        End Set
    End Property
    Public Property Merchant_vc() As String
        Get
            Return mvarMerchant_vc
        End Get
        Set(ByVal value As String)
            mvarMerchant_vc = value
        End Set
    End Property
    Public Property SaveDate_vc() As String
        Get
            Return mvarSaveDate_vc
        End Get
        Set(ByVal value As String)
            mvarSaveDate_vc = value
        End Set
    End Property
    Public Property Date_vc() As String
        Get
            Return mvarDate_vc
        End Get
        Set(ByVal value As String)
            mvarDate_vc = value
        End Set
    End Property
    Public Property VisitorID() As Int32
        Get
            Return mvarVisitorID
        End Get
        Set(ByVal value As Int32)
            mvarVisitorID = value
        End Set
    End Property
#End Region
#Region "Property Account"
    Public Property AAccountID() As Int64
        Get
            Return mvarAAccountID
        End Get
        Set(ByVal value As Int64)
            mvarAAccountID = value
        End Set
    End Property
    Public Property AAccountNO_vc() As String
        Get
            Return mvarAAccountNO_vc
        End Get
        Set(ByVal value As String)
            mvarAAccountNO_vc = value
        End Set
    End Property
    Public Property ACardNo_vc() As String
        Get
            Return mvarACardNo_vc
        End Get
        Set(ByVal value As String)
            mvarACardNo_vc = value
        End Set
    End Property
    Public Property AAccountTypeID() As Int32
        Get
            Return mvarAAccountTypeID
        End Get
        Set(ByVal value As Int32)
            mvarAAccountTypeID = value
        End Set
    End Property
    Public Property ABranchID() As String
        Get
            Return mvarABranchID
        End Get
        Set(ByVal value As String)
            mvarABranchID = value
        End Set
    End Property
#End Region
#Region "Property Store"
    Public Property SStoreID() As Int64
        Get
            Return mvarSStoreID
        End Get
        Set(ByVal value As Int64)
            mvarSStoreID = value
        End Set
    End Property
    'Private mvarSAccountID As Int64
    Public Property SGroupID() As String
        Get
            Return mvarSGroupID
        End Get
        Set(ByVal value As String)
            mvarSGroupID = value
        End Set
    End Property
    Public Property SStateID() As String
        Get
            Return mvarSStateID
        End Get
        Set(ByVal value As String)
            mvarSStateID = value
        End Set
    End Property
    Public Property SCityID() As String
        Get
            Return mvarSCityID
        End Get
        Set(ByVal value As String)
            mvarSCityID = value
        End Set
    End Property
    Public Property SName_nvc() As String
        Get
            Return mvarSName_nvc
        End Get
        Set(ByVal value As String)
            mvarSName_nvc = value
        End Set
    End Property
    Public Property SPostCode_vc() As String
        Get
            Return mvarSPostCode_vc
        End Get
        Set(ByVal value As String)
            mvarSPostCode_vc = value
        End Set
    End Property
    Public Property SAddress_nvc() As String
        Get
            Return mvarSAddress_nvc
        End Get
        Set(ByVal value As String)
            mvarSAddress_nvc = value
        End Set
    End Property
    Public Property STel1_vc() As String
        Get
            Return mvarSTel1_vc
        End Get
        Set(ByVal value As String)
            mvarSTel1_vc = value
        End Set
    End Property
    Public Property STel2_vc() As String
        Get
            Return mvarSTel2_vc
        End Get
        Set(ByVal value As String)
            mvarSTel2_vc = value
        End Set
    End Property
    Public Property SFax_vc() As String
        Get
            Return mvarSFax_vc
        End Get
        Set(ByVal value As String)
            mvarSFax_vc = value
        End Set
    End Property
    Public Property SMunicipalAreaNO_sint() As Int16
        Get
            Return mvarSMunicipalAreaNO_sint
        End Get
        Set(ByVal value As Int16)
            mvarSMunicipalAreaNO_sint = value
        End Set
    End Property
    Public Property SEstateConditionID() As Int32
        Get
            Return mvarSEstateConditionID
        End Get
        Set(ByVal value As Int32)
            mvarSEstateConditionID = value
        End Set
    End Property
    Public Property SSIdentityTypeID() As Int32
        Get
            Return mvarSSIdentityTypeID
        End Get
        Set(ByVal value As Int32)
            mvarSSIdentityTypeID = value
        End Set
    End Property
    Public Property SSIdentityTypeSDate_vc() As String
        Get
            Return mvarSSIdentityTypeSDate_vc
        End Get
        Set(ByVal value As String)
            mvarSSIdentityTypeSDate_vc = value
        End Set
    End Property
    Public Property SSIdentityTypeEDate_vc() As String
        Get
            Return mvarSSIdentityTypeEDate_vc
        End Get
        Set(ByVal value As String)
            mvarSSIdentityTypeEDate_vc = value
        End Set
    End Property
    Public Property SDeviceCount_tint() As Int16
        Get
            Return mvarSDeviceCount_tint
        End Get
        Set(ByVal value As Int16)
            mvarSDeviceCount_tint = value
        End Set
    End Property

#End Region
#End Region
#Region "Methods"
    Public Sub InsertIntoRptGeneral()
        Try
            With cmdExcel
                .Connection = cntExcel
                .CommandType = CommandType.Text

                '.CommandText = "INSERT INTO [sheet1]" & _
                '"( '" + ContractingPartyID.Replace("'", "''") + "','" + +FirstName_nvc.Replace("'", "''") + "')"
                ''"[˜Ï ØÑÝ ÞÑÇÑÏÇÏ]" & _
                ''"[äÇã]" & _
                ''" Values ( '" + ContractingPartyID + "','" + +FirstName_nvc.Replace("'", "''") + "')" '+MVat.Replace("'", "''") + "','" + MBranch.Replace("'", "''") + "')"

                .CommandText = ( _
                "INSERT INTO [Sheet1$]([˜Ï ØÑÝ ÞÑÇÑÏÇÏ],[äÇã] )" & _
                " VALUES('" & FirstName_nvc & "' , " & _
                "'" & ContractingPartyID & "')")

                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
   
#End Region
End Class
