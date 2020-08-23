Public Class ClassDALAccessSwitch
    Private cntAccess As New OleDb.OleDbConnection
    Private cmdAccess As New OleDb.OleDbCommand
    '///////////POS///////////////
    Private mvarPOutlet As String
    Private mvarPPos As String
    Private mvarPTime As String
    Private mvarPSerial As String
    Private mvarPPropertyNO As String
    Private mvarPAcronym As String
    '///////////OUTLET////////////
    Private mvarOMerchant As String
    Private mvarOOutlet As String
    Private mvarOAcronym As String
    Private mvarOCareof As String
    Private mvarOLine1 As String
    Private mvarOLine2 As String
    Private mvarOLine3 As String
    Private mvarOLine4 As String
    Private mvarORegion As String
    Private mvarOCity As String
    Private mvarOPhone1 As String
    Private mvarOPhone2 As String
    Private mvarOFax As String
    Private mvarOEmail As String
    Private mvarOMCC As String
    Private mvarOZip As String

    '////////MERCHANT//////////////
    Private mvarMVat As String
    Private mvarMBranch As String
    Private mvarMAcronym As String
    Private mvarMLocation As String
    Private mvarMMerchant As String
    Private mvarMCareof As String
    Private mvarMLine1 As String
    Private mvarMLine2 As String
    Private mvarMLine3 As String
    Private mvarMLine4 As String
    Private mvarMRegion As String
    Private mvarMCity As String
    Private mvarMPhone1 As String
    Private mvarMPhone2 As String
    Private mvarMFax As String
    Private mvarMEmail As String
    Private mvarMFname As String
    Private mvarMLname As String
    Private mvarMOLine1 As String
    Private mvarMOLine2 As String
    Private mvarMOLine3 As String
    Private mvarMOLine4 As String
    Private mvarMORegion As String
    Private mvarMOCity As String
    Private mvarMOPhone1 As String
    Private mvarMOPhone2 As String
    Private mvarMID As String
    Private mvarMDoc_Type As String
    Private mvarMAccountType As String
    Private mvarMAccountNo As String
    Private mvarMOCareof As String
    Private mvarMZip As String
    Private mvarMOZip As String

    '////TAlocate/////////////////
    Private mvarAPos As String
    Private mvarASerial As String
    '////TReg//////////////////
    Private mvarRSerial As String
    '//////////////////////////////
#Region "Property"

#Region "TPose"
    Public Property POutlet() As String
        Get
            Return mvarPOutlet
        End Get
        Set(ByVal value As String)
            mvarPOutlet = value
        End Set
    End Property
    Public Property PPos() As String
        Get
            Return mvarPPos
        End Get
        Set(ByVal value As String)
            mvarPPos = value
        End Set
    End Property
    Public Property PTime() As String
        Get
            Return mvarPTime
        End Get
        Set(ByVal value As String)
            mvarPTime = value
        End Set
    End Property
    Public Property PSerial() As String
        Get
            Return mvarPSerial
        End Get
        Set(ByVal value As String)
            mvarPSerial = value
        End Set
    End Property
    Public Property PPropertyNO() As String
        Get
            Return mvarPPropertyNO
        End Get
        Set(ByVal value As String)
            mvarPPropertyNO = value
        End Set
    End Property
    Public Property PAcronym() As String
        Get
            Return mvarPAcronym
        End Get
        Set(ByVal value As String)
            mvarPAcronym = value
        End Set
    End Property

#End Region
#Region "TOutlet"
    Public Property OMerchant() As String
        Get
            Return mvarOMerchant
        End Get
        Set(ByVal value As String)
            mvarOMerchant = value
        End Set
    End Property
    Public Property OOutlet() As String
        Get
            Return mvarOOutlet
        End Get
        Set(ByVal value As String)
            mvarOOutlet = value
        End Set
    End Property
    Public Property OAcronym() As String
        Get
            Return mvarOAcronym
        End Get
        Set(ByVal value As String)
            mvarOAcronym = value
        End Set
    End Property
    Public Property OCareof() As String
        Get
            Return mvarOCareof
        End Get
        Set(ByVal value As String)
            mvarOCareof = value
        End Set
    End Property
    Public Property OLine1() As String
        Get
            Return mvarOLine1
        End Get
        Set(ByVal value As String)
            mvarOLine1 = value
        End Set
    End Property
    Public Property OLine2() As String
        Get
            Return mvarOLine2
        End Get
        Set(ByVal value As String)
            mvarOLine2 = value
        End Set
    End Property
    Public Property OLine3() As String
        Get
            Return mvarOLine3
        End Get
        Set(ByVal value As String)
            mvarOLine3 = value
        End Set
    End Property
    Public Property OLine4() As String
        Get
            Return mvarOLine4
        End Get
        Set(ByVal value As String)
            mvarOLine4 = value
        End Set
    End Property
    Public Property ORegion() As String
        Get
            Return mvarORegion
        End Get
        Set(ByVal value As String)
            mvarORegion = value
        End Set
    End Property
    Public Property OCity() As String
        Get
            Return mvarOCity
        End Get
        Set(ByVal value As String)
            mvarOCity = value
        End Set
    End Property
    Public Property OPhone1() As String
        Get
            Return mvarOPhone1
        End Get
        Set(ByVal value As String)
            mvarOPhone1 = value
        End Set
    End Property
    Public Property OPhone2() As String
        Get
            Return mvarOPhone2
        End Get
        Set(ByVal value As String)
            mvarOPhone2 = value
        End Set
    End Property
    Public Property OFax() As String
        Get
            Return mvarOFax
        End Get
        Set(ByVal value As String)
            mvarOFax = value
        End Set
    End Property
    Public Property OEmail() As String
        Get
            Return mvarOEmail
        End Get
        Set(ByVal value As String)
            mvarOEmail = value
        End Set
    End Property
    Public Property OMCC() As String
        Get
            Return mvarOMCC
        End Get
        Set(ByVal value As String)
            mvarOMCC = value
        End Set
    End Property
    Public Property OZip() As String
        Get
            Return mvarOZip
        End Get
        Set(ByVal value As String)
            mvarOZip = value
        End Set
    End Property


#End Region
#Region "TMerchant"
    Public Property MVat() As String
        Get
            Return mvarMVat
        End Get
        Set(ByVal value As String)
            mvarMVat = value
        End Set
    End Property
    Public Property MBranch() As String
        Get
            Return mvarMBranch
        End Get
        Set(ByVal value As String)
            mvarMBranch = value
        End Set
    End Property
    Public Property MAcronym() As String
        Get
            Return mvarMAcronym
        End Get
        Set(ByVal value As String)
            mvarMAcronym = value
        End Set
    End Property
    Public Property MLocation() As String
        Get
            Return mvarMLocation
        End Get
        Set(ByVal value As String)
            mvarMLocation = value
        End Set
    End Property
    Public Property MMerchant() As String
        Get
            Return mvarMMerchant
        End Get
        Set(ByVal value As String)
            mvarMMerchant = value
        End Set
    End Property
    Public Property MCareof() As String
        Get
            Return mvarMCareof
        End Get
        Set(ByVal value As String)
            mvarMCareof = value
        End Set
    End Property
    Public Property MOCareof() As String
        Get
            Return mvarMOCareof
        End Get
        Set(ByVal value As String)
            mvarMOCareof = value
        End Set
    End Property
    Public Property MLine1() As String
        Get
            Return mvarMLine1
        End Get
        Set(ByVal value As String)
            mvarMLine1 = value
        End Set
    End Property
    Public Property MLine2() As String
        Get
            Return mvarMLine2
        End Get
        Set(ByVal value As String)
            mvarMLine2 = value
        End Set
    End Property
    Public Property MLine3() As String
        Get
            Return mvarMLine3
        End Get
        Set(ByVal value As String)
            mvarMLine3 = value
        End Set
    End Property
    Public Property MLine4() As String
        Get
            Return mvarMLine4
        End Get
        Set(ByVal value As String)
            mvarMLine4 = value
        End Set
    End Property
    Public Property MRegion() As String
        Get
            Return mvarMRegion
        End Get
        Set(ByVal value As String)
            mvarMRegion = value
        End Set
    End Property
    Public Property MCity() As String
        Get
            Return mvarMCity
        End Get
        Set(ByVal value As String)
            mvarMCity = value
        End Set
    End Property
    Public Property MPhone1() As String
        Get
            Return mvarMPhone1
        End Get
        Set(ByVal value As String)
            mvarMPhone1 = value
        End Set
    End Property
    Public Property MPhone2() As String
        Get
            Return mvarMPhone2
        End Get
        Set(ByVal value As String)
            mvarMPhone2 = value
        End Set
    End Property
    Public Property MFax() As String
        Get
            Return mvarMFax
        End Get
        Set(ByVal value As String)
            mvarMFax = value
        End Set
    End Property
    Public Property MEmail() As String
        Get
            Return mvarMEmail
        End Get
        Set(ByVal value As String)
            mvarMEmail = value
        End Set
    End Property
    Public Property MFname() As String
        Get
            Return mvarMFname
        End Get
        Set(ByVal value As String)
            mvarMFname = value
        End Set
    End Property
    Public Property MLname() As String
        Get
            Return mvarMLname
        End Get
        Set(ByVal value As String)
            mvarMLname = value
        End Set
    End Property
    Public Property MOLine1() As String
        Get
            Return mvarMOLine1
        End Get
        Set(ByVal value As String)
            mvarMOLine1 = value
        End Set
    End Property
    Public Property MOLine2() As String
        Get
            Return mvarMOLine2
        End Get
        Set(ByVal value As String)
            mvarMOLine2 = value
        End Set
    End Property
    Public Property MOLine3() As String
        Get
            Return mvarMOLine3
        End Get
        Set(ByVal value As String)
            mvarMOLine3 = value
        End Set
    End Property
    Public Property MOLine4() As String
        Get
            Return mvarMOLine4
        End Get
        Set(ByVal value As String)
            mvarMOLine4 = value
        End Set
    End Property
    Public Property MORegion() As String
        Get
            Return mvarMORegion
        End Get
        Set(ByVal value As String)
            mvarMORegion = value
        End Set
    End Property
    Public Property MOCity() As String
        Get
            Return mvarMOCity
        End Get
        Set(ByVal value As String)
            mvarMOCity = value
        End Set
    End Property
    Public Property MOPhone1() As String
        Get
            Return mvarMOPhone1
        End Get
        Set(ByVal value As String)
            mvarMOPhone1 = value
        End Set
    End Property
    Public Property MOPhone2() As String
        Get
            Return mvarMOPhone2
        End Get
        Set(ByVal value As String)
            mvarMOPhone2 = value
        End Set
    End Property
    Public Property MID() As String
        Get
            Return mvarMID
        End Get
        Set(ByVal value As String)
            mvarMID = value
        End Set
    End Property
    Public Property MDoc_Type() As String
        Get
            Return mvarMDoc_Type
        End Get
        Set(ByVal value As String)
            mvarMDoc_Type = value
        End Set
    End Property
    Public Property MAccountType() As String
        Get
            Return mvarMAccountType
        End Get
        Set(ByVal value As String)
            mvarMAccountType = value
        End Set
    End Property
    Public Property MAccountNo() As String
        Get
            Return mvarMAccountNo
        End Get
        Set(ByVal value As String)
            mvarMAccountNo = value
        End Set
    End Property
    Public Property MZip() As String
        Get
            Return mvarMZip
        End Get
        Set(ByVal value As String)
            mvarMZip = value
        End Set
    End Property
    Public Property MOZip() As String
        Get
            Return mvarMOZip
        End Get
        Set(ByVal value As String)
            mvarMOZip = value
        End Set
    End Property

#End Region
#Region "TAlocate"
    Public Property APos() As String
        Get
            Return mvarAPos
        End Get
        Set(ByVal value As String)
            mvarAPos = value
        End Set
    End Property
    Public Property ASerial() As String
        Get
            Return mvarASerial
        End Get
        Set(ByVal value As String)
            mvarASerial = value
        End Set
    End Property
#End Region
#Region "Treg"
    Public Property RSerial() As String
        Get
            Return mvarRSerial
        End Get
        Set(ByVal value As String)
            mvarRSerial = value
        End Set
    End Property
#End Region
    '///////////////
#End Region
#Region "Connection"
    Public Sub ConnectionOpen()
        Try
            If cntAccess.State <> ConnectionState.Open Then
                With cntAccess
                    .ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Trim(AccessSwitchFilePath) & ";Persist Security Info=False"
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
#Region "Insert"
    Public Sub InsertTMerchant()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text

                Dim s As String = "INSERT INTO TMerchant ( Vat, Branch, Acronym, Location, Merchant, Careof, Line1, Line2, Line3" & _
                                ", Line4,Zip, Region, city, Phone1, phone2, Fax, Email, Fname, Lname, OCareof, OLine1, OLine2, OLine3, OLine4,OZip, ORegion, OCity," & _
                                "OPhone1, OPhone2, ID, Doc_Type, AccountType, AccountNo ) " & _
                                " Values ( '" + MVat.ToString.Replace("'", "''") + "','" + MBranch.ToString.Replace("'", "''") + "','" + MAcronym.ToString.Replace("'", "''") + "','" + MLocation.ToString.Replace("'", "''") + "','" + MMerchant.ToString.Replace("'", "''") + "','" + MCareof.ToString.Replace("'", "''") + "','" + MLine1.ToString.Replace("'", "''") + "','" + MLine2.ToString.Replace("'", "''") + "','" + MLine3.ToString.Replace("'", "''") + "','" + MLine4.ToString.Replace("'", "''") + "','" + MZip.ToString.Replace("'", "''") + "','" + MRegion.ToString.Replace("'", "''") + "','" + MCity.ToString.Replace("'", "''") + "','" + MPhone1.ToString.Replace("'", "''") + "','" + MPhone2.ToString.Replace("'", "''") + "','" + MFax.ToString.Replace("'", "''") + "','" + MEmail.ToString.Replace("'", "''") + "','" + MFname.ToString.Replace("'", "''") + "','" + MLname.ToString.Replace("'", "''") + "','" + MOCareof.ToString.Replace("'", "''") + "','" + MOLine1.ToString.Replace("'", "''") + "','" + MOLine2.ToString.Replace("'", "''") + "','" + MOLine3.ToString.Replace("'", "''") + "','" + MOLine4.ToString.Replace("'", "''") + "','" + MOZip.ToString.Replace("'", "''") + "','" + MORegion.ToString.Replace("'", "''") + "','" + MOCity.ToString.Replace("'", "''") + "','" + MOPhone1.ToString.Replace("'", "''") + "','" + MOPhone2.ToString.Replace("'", "''") + "','" + MID.ToString.Replace("'", "''") + "','" + MDoc_Type.ToString.Replace("'", "''") + "','" + MAccountType.ToString.Replace("'", "''") + "','" + MAccountNo.ToString.Replace("'", "''") + "')"
                .CommandText = "INSERT INTO TMerchant ( Vat, Branch, Acronym, Location, Merchant, Careof, Line1, Line2, Line3" & _
                                ", Line4,Zip, Region, city, Phone1, phone2, Fax, Email, Fname, Lname, OCareof, OLine1, OLine2, OLine3, OLine4,OZip, ORegion, OCity," & _
                                "OPhone1, OPhone2, ID, Doc_Type, AccountType, AccountNo ) " & _
                                " Values ( '" + MVat.Replace("'", "''") + "','" + MBranch.Replace("'", "''") + "','" + MAcronym.Replace("'", "''") + "','" + MLocation.Replace("'", "''") + "','" + MMerchant.Replace("'", "''") + "','" + MCareof.Replace("'", "''") + "','" + MLine1.Replace("'", "''") + "','" + MLine2.Replace("'", "''") + "','" + MLine3.Replace("'", "''") + "','" + MLine4.Replace("'", "''") + "','" + MZip.Replace("'", "''") + "','" + MRegion.Replace("'", "''") + "','" + MCity.Replace("'", "''") + "','" + MPhone1.Replace("'", "''") + "','" + MPhone2.Replace("'", "''") + "','" + MFax.Replace("'", "''") + "','" + MEmail.Replace("'", "''") + "','" + MFname.Replace("'", "''") + "','" + MLname.Replace("'", "''") + "','" + MOCareof.Replace("'", "''") + "','" + MOLine1.Replace("'", "''") + "','" + MOLine2.Replace("'", "''") + "','" + MOLine3.Replace("'", "''") + "','" + MOLine4.Replace("'", "''") + "','" + MOZip.Replace("'", "''") + "','" + MORegion.Replace("'", "''") + "','" + MOCity.Replace("'", "''") + "','" + MOPhone1.Replace("'", "''") + "','" + MOPhone2.Replace("'", "''") + "','" + MID.Replace("'", "''") + "','" + MDoc_Type.Replace("'", "''") + "','" + MAccountType.Replace("'", "''") + "','" + MAccountNo.Replace("'", "''") + "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertTOutlet()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO TOutlet ( Merchant, Outlet, Acronym, Careof, Line1, Line2, Line3, Line4,Zip, Region, City, Phone1, Phone2, Fax, Email, MCC )" & _
                               " Values ( '" + OMerchant.Replace("'", "''") + "','" + OOutlet.Replace("'", "''") + "','" + OAcronym.Replace("'", "''") + "','" + OCareof.Replace("'", "''") + "','" + OLine1.Replace("'", "''") + "','" + OLine2.Replace("'", "''") + "','" + OLine3.Replace("'", "''") + "','" + OLine4.Replace("'", "''") + "','" + OZip.Replace("'", "''") + "','" + ORegion.Replace("'", "''") + "','" + OCity.Replace("'", "''") + "','" + OPhone1.Replace("'", "''") + "','" + OPhone2.Replace("'", "''") + "','" + OFax.Replace("'", "''") + "','" + OEmail.Replace("'", "''") + "','" + OMCC.Replace("'", "''") + "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub InsertTPos()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO TPos  (Outlet, Pos,[Time], Serial, PropertyNO,Acronym) VALUES ('" + POutlet.Replace("'", "''") + "','" + PPos.Replace("'", "''") + "','" + PTime.Replace("'", "''") + "','" + PSerial.Replace("'", "''") + "','" + PPropertyNO.Replace("'", "''") + "','" + PAcronym.Replace("'", "''") + "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertTAlocate()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO TAlocate  (Pos, Serial) VALUES ('" + APos + "','" + ASerial + "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertTreg()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO Treg  ( Serial) VALUES ('" + ASerial + "')"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
#Region "Delete"
    Public Sub DeleteALLTMerchant()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "DELETE FROM TMerchant "
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub DeleteALLTOutlet()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "DELETE FROM TOutlet "
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteALLTPos()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "Delete From TPos"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteALLTAlocate()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "Delete From TAlocate"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteALLTreg()
        Try
            With cmdAccess
                .Connection = cntAccess
                .CommandType = CommandType.Text
                .CommandText = "Delete From Treg"
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
