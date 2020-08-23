Imports Oracle.DataAccess.Client

Public Class ClassDALRequest

#Region "Declare"



    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    Private dt As New DataTable

    Private mvarRequestID As Int64
    Private mvarRequestStatusID As Int16
    Private mvarDuplicateRequestID As Int64
    Private mvarRequestDate_vc As String
    Private mvarProjectID As Int16
    Private mvarVisitorID As Int32
    Private mvarFirstName_nvc As String
    Private mvarLastName_nvc As String
    Private mvarFatherName_nvc As String
    Private mvarNationalCode_nvc As String
    Private mvarIdentityCertificateNO_nvc As String
    Private mvarBirthDate_vc As String
    Private mvarHomeAddress_nvc As String
    Private mvarHomeTel_vc As String
    Private mvarMobile_vc As String
    Private mvarEmail_nvc As String
    Private mvarStoreName_nvc As String
    Private mvarStoreGroupID As String
    Private mvarStoreStateID As String
    Private mvarStoreCityID As String
    Private mvarStoreMunicipalAreaNO_sint As Int16
    Private mvarStorePostCode_vc As String
    Private mvarStoreAddress_nvc As String
    Private mvarStoreTel1_vc As String
    Private mvarStoreTel2_vc As String
    Private mvarStoreFax_vc As String
    Private mvarAccountTypeID As Int32
    Private mvarAccountNO_vc As String
    Private mvarShabaAccount As String
    Private mvarBranchID As String
    Private mvarCIdentityTypeID As Int32
    Private mvarSIdentityTypeID As Int32
    Private mvarBirthStateID As String
    Private mvarBirthCityID As String
    Private mvarContractDate_vc As String
    Private mvarHaveDeviceOutlet As String
    Private mvarlistOFRequest As String

    Private mvarMerchant_vc As String
    Public Property Merchant_vc() As String
        Get
            Return mvarMerchant_vc
        End Get
        Set(ByVal value As String)
            mvarMerchant_vc = value
        End Set
    End Property

    Private mvarOutlet_vc As String
    Public Property Outlet_vc() As String
        Get
            Return mvarOutlet_vc
        End Get
        Set(ByVal value As String)
            mvarOutlet_vc = value
        End Set
    End Property


    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

    Public Enum RequestStatusEnum As Short
        withNullValue = 0
        cancel = 1
        repeated = 2
        incorrectinfo = 3
        incompleteinfo = 4
    End Enum

    Public Property RequestID() As Int64
        Get
            Return mvarRequestID
        End Get
        Set(ByVal value As Int64)
            mvarRequestID = value
        End Set
    End Property
    Public Property RequestStatusID() As Int64
        Get
            Return mvarRequestStatusID
        End Get
        Set(ByVal value As Int64)
            mvarRequestStatusID = value
        End Set
    End Property
    Public Property DuplicateRequestID() As Int64
        Get
            Return mvarDuplicateRequestID
        End Get
        Set(ByVal value As Int64)
            mvarDuplicateRequestID = value
        End Set
    End Property
    Public Property RequestDate_vc() As String
        Get
            Return mvarRequestDate_vc
        End Get
        Set(ByVal value As String)
            mvarRequestDate_vc = value
        End Set
    End Property
    Public Property ProjectID() As Int16
        Get
            Return mvarProjectID
        End Get
        Set(ByVal value As Int16)
            mvarProjectID = value
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
    Public Property NationalCode_nvc() As String
        Get
            Return mvarNationalCode_nvc
        End Get
        Set(ByVal value As String)
            mvarNationalCode_nvc = value
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
    Public Property BirthDate_vc() As String
        Get
            Return mvarBirthDate_vc
        End Get
        Set(ByVal value As String)
            mvarBirthDate_vc = value
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
    Public Property StoreName_nvc() As String
        Get
            Return mvarStoreName_nvc
        End Get
        Set(ByVal value As String)
            mvarStoreName_nvc = value
        End Set
    End Property
    Public Property StoreGroupID() As String
        Get
            Return mvarStoreGroupID
        End Get
        Set(ByVal value As String)
            mvarStoreGroupID = value
        End Set
    End Property
    Public Property StoreStateID() As String
        Get
            Return mvarStoreStateID
        End Get
        Set(ByVal value As String)
            mvarStoreStateID = value
        End Set
    End Property
    Public Property StoreCityID() As String
        Get
            Return mvarStoreCityID
        End Get
        Set(ByVal value As String)
            mvarStoreCityID = value
        End Set
    End Property
    Public Property StoreMunicipalAreaNO_sint() As Int16
        Get
            Return mvarStoreMunicipalAreaNO_sint
        End Get
        Set(ByVal value As Int16)
            mvarStoreMunicipalAreaNO_sint = value
        End Set
    End Property
    Public Property StorePostCode_vc() As String
        Get
            Return mvarStorePostCode_vc
        End Get
        Set(ByVal value As String)
            mvarStorePostCode_vc = value
        End Set
    End Property
    Public Property StoreAddress_nvc() As String
        Get
            Return mvarStoreAddress_nvc
        End Get
        Set(ByVal value As String)
            mvarStoreAddress_nvc = value
        End Set
    End Property
    Public Property StoreTel1_vc() As String
        Get
            Return mvarStoreTel1_vc
        End Get
        Set(ByVal value As String)
            mvarStoreTel1_vc = value
        End Set
    End Property
    Public Property StoreTel2_vc() As String
        Get
            Return mvarStoreTel2_vc
        End Get
        Set(ByVal value As String)
            mvarStoreTel2_vc = value
        End Set
    End Property
    Public Property StoreFax_vc() As String
        Get
            Return mvarStoreFax_vc
        End Get
        Set(ByVal value As String)
            mvarStoreFax_vc = value
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
    Public Property ShabaAccount() As String
        Get
            Return mvarShabaAccount
        End Get
        Set(ByVal value As String)
            mvarShabaAccount = value
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
    Public Property CIdentityTypeID() As Int32
        Get
            Return mvarCIdentityTypeID
        End Get
        Set(ByVal value As Int32)
            mvarCIdentityTypeID = value
        End Set
    End Property
    Public Property SIdentityTypeID() As Int32
        Get
            Return mvarSIdentityTypeID
        End Get
        Set(ByVal value As Int32)
            mvarSIdentityTypeID = value
        End Set
    End Property
    Public Property BirthStateID() As String
        Get
            Return mvarBirthStateID
        End Get
        Set(ByVal value As String)
            mvarBirthStateID = value
        End Set
    End Property
    Public Property BirthCityID() As String
        Get
            Return mvarBirthCityID
        End Get
        Set(ByVal value As String)
            mvarBirthCityID = value
        End Set
    End Property
    Public Property ContractDate_vc() As String
        Get
            Return mvarContractDate_vc
        End Get
        Set(ByVal value As String)
            mvarContractDate_vc = value
        End Set
    End Property
    Public Property HaveDeviceOutlet() As String
        Get
            Return mvarHaveDeviceOutlet
        End Get
        Set(ByVal value As String)
            mvarHaveDeviceOutlet = value
        End Set
    End Property

    Public Property listOFRequestperty() As String
        Get
            Return mvarlistOFRequest
        End Get
        Set(ByVal value As String)
            mvarlistOFRequest = value
        End Set
    End Property
#End Region
#Region "Function"
    Public Function GetAllNotAssignedToVisitor() As DataTable
        Try
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int16)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            dt.Clear()
            Me.Fill(CommandType.StoreProcedure, "GetAllNotAssignedToVisitor_SP", dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllReqImg() As DataTable
        Try

            Dim parRequsetID As New OracleParameter("RequsetID_", OracleDbType.Int16)
            parRequsetID.Value = Me.RequestID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            dt.Clear()
            Me.Fill(CommandType.StoreProcedure, "GetAllReqImg_SP", dt, parRequsetID, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllNotConvertedToContract() As DataTable
        Try

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int16)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            dt.Clear()
            Me.Fill(CommandType.StoreProcedure, "GetAllNoConvertedToContract_SP", dt, parProjectID, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByReqeustID(ByVal DEVICEID As Int64) As DataTable
        Try
            Dim dtDEVICEID As New DataTable

            Dim parDEVICEID As New OracleParameter("DEVICEID_", OracleDbType.Int64)
            parDEVICEID.Value = DEVICEID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByDEVICEID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtDEVICEID, parDEVICEID, parRefCursor)
            Return dtDEVICEID
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Insert()
        Try
            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID
            Dim parRequestDate_vc As New OracleParameter("RequestDate_vc_", OracleDbType.Varchar2, 10)
            parRequestDate_vc.Value = RequestDate_vc
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int16)
            parProjectID.Value = ProjectID
            Dim parFirstName_nvc As New OracleParameter("FirstName_nvc_", OracleDbType.Varchar2, 30)
            parFirstName_nvc.Value = FirstName_nvc
            Dim parLastName_nvc As New OracleParameter("LastName_nvc_", OracleDbType.Varchar2, 50)
            parLastName_nvc.Value = LastName_nvc
            Dim parFatherName_nvc As New OracleParameter("FatherName_nvc_", OracleDbType.Varchar2, 30)
            parFatherName_nvc.Value = FatherName_nvc
            Dim parNationalCode_nvc As New OracleParameter("NationalCode_nvc_", OracleDbType.Varchar2, 12)
            parNationalCode_nvc.Value = NationalCode_nvc
            Dim parIdentityCertificateNO_nvc As New OracleParameter("IdentityCertificateNO_nvc_", OracleDbType.Varchar2, 12)
            parIdentityCertificateNO_nvc.Value = IdentityCertificateNO_nvc
            Dim parBirthDate_vc As New OracleParameter("BirthDate_vc_", OracleDbType.Varchar2, 10)
            parBirthDate_vc.Value = BirthDate_vc
            Dim parHomeAddress_nvc As New OracleParameter("HomeAddress_nvc_", OracleDbType.Varchar2, 500)
            parHomeAddress_nvc.Value = HomeAddress_nvc
            Dim parHomeTel_vc As New OracleParameter("HomeTel_vc_", OracleDbType.Varchar2, 20)
            parHomeTel_vc.Value = HomeTel_vc
            Dim parMobile_vc As New OracleParameter("Mobile_vc_", OracleDbType.Varchar2, 20)
            parMobile_vc.Value = Mobile_vc
            Dim parEmail_nvc As New OracleParameter("Email_nvc_", OracleDbType.Varchar2, 50)
            parEmail_nvc.Value = Email_nvc
            Dim parStoreName_nvc As New OracleParameter("StoreName_nvc_", OracleDbType.Varchar2, 50)
            parStoreName_nvc.Value = StoreName_nvc
            Dim parStoreGroupID As New OracleParameter("StoreGroupID_", OracleDbType.Varchar2, 4)
            parStoreGroupID.Value = IIf(StoreGroupID = -1, DBNull.Value, StoreGroupID)
            Dim parStoreStateID As New OracleParameter("StoreStateID_", OracleDbType.Varchar2, 3)
            parStoreStateID.Value = StoreStateID
            Dim parStoreCityID As New OracleParameter("StoreCityID_", OracleDbType.Varchar2, 5)
            parStoreCityID.Value = StoreCityID
            Dim parStoreMunicipalAreaNO_sint As New OracleParameter("StoreMunicipalAreaNO_sint_", OracleDbType.Int16)
            parStoreMunicipalAreaNO_sint.Value = StoreMunicipalAreaNO_sint
            Dim parStorePostCode_vc As New OracleParameter("StorePostCode_vc_", OracleDbType.Varchar2, 10)
            parStorePostCode_vc.Value = StorePostCode_vc
            Dim parStoreAddress_nvc As New OracleParameter("StoreAddress_nvc_", OracleDbType.Varchar2, 500)
            parStoreAddress_nvc.Value = StoreAddress_nvc
            Dim parStoreTel1_vc As New OracleParameter("StoreTel1_vc_", OracleDbType.Varchar2, 20)
            parStoreTel1_vc.Value = StoreTel1_vc
            Dim parStoreTel2_vc As New OracleParameter("StoreTel2_vc_", OracleDbType.Varchar2, 20)
            parStoreTel2_vc.Value = StoreTel2_vc
            Dim parStoreFax_vc As New OracleParameter("StoreFax_vc_", OracleDbType.Varchar2, 20)
            parStoreFax_vc.Value = StoreFax_vc
            Dim parAccountTypeID As New OracleParameter("AccountTypeID_", OracleDbType.Int32)
            parAccountTypeID.Value = AccountTypeID
            Dim parAccountNO_vc As New OracleParameter("AccountNO_vc_", OracleDbType.Varchar2, 20)
            parAccountNO_vc.Value = AccountNO_vc

            Dim parShabaAccount As New OracleParameter("ShabaAccount_", OracleDbType.Varchar2, 50)
            parShabaAccount.Value = ShabaAccount

            Dim parBranchID As New OracleParameter("BranchID_", OracleDbType.Varchar2, 7)
            parBranchID.Value = BranchID

            Dim parImportDate_vc As New OracleParameter("ImportDate_vc_", OracleDbType.Varchar2, 10)
            parImportDate_vc.Value = GetDateNow()
            Dim parImportUserID As New OracleParameter("ImportUserID_", OracleDbType.Int64)
            parImportUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parMerchant_vc As New OracleParameter("Merchant_vc", OracleDbType.Varchar2, 20)
            parMerchant_vc.Value = Merchant_vc

            Dim parOutlet_vc As New OracleParameter("Outlet_vc", OracleDbType.Varchar2, 20)
            parOutlet_vc.Value = Outlet_vc


            strSQL = "InsertRequest_SP1"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL _
                             , parRequestID _
                             , parRequestDate_vc _
                             , parProjectID _
                             , parFirstName_nvc _
                             , parLastName_nvc _
                             , parFatherName_nvc _
                             , parNationalCode_nvc _
                             , parIdentityCertificateNO_nvc _
                             , parBirthDate_vc _
                             , parHomeAddress_nvc _
                             , parHomeTel_vc _
                             , parMobile_vc _
                             , parEmail_nvc _
                             , parStoreName_nvc _
                             , parStoreGroupID _
                             , parStoreStateID _
                             , parStoreCityID _
                             , parStoreMunicipalAreaNO_sint _
                             , parStorePostCode_vc _
                             , parStoreAddress_nvc _
                             , parStoreTel1_vc _
                             , parStoreTel2_vc _
                             , parStoreFax_vc _
                             , parAccountTypeID _
                             , parAccountNO_vc _
                             , parBranchID _
                             , parImportDate_vc _
                             , parImportUserID _
                             , parShabaAccount _
                             , parMerchant_vc _
                             , parOutlet_vc)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetByRequestIDRequest() As DataTable
        Try
            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID

            dt.Clear()
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByRequestIDRequest_SP", dt, parRequestID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub UpdateReuest_VisitorID()
        Try
            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID
            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parModifyDate_vc As New OracleParameter("ModifyDate_vc_", OracleDbType.Varchar2, 10)
            parModifyDate_vc.Value = GetDateNow()
            Dim parModifyUserID As New OracleParameter("ModifyUserID_", OracleDbType.Int64)

            parModifyUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID


            strSQL = "UpdateReuest_VisitorID_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parRequestID, parVisitorID, parModifyDate_vc, parModifyUserID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetAllAssignedToVisitorButNotConvertedToContract() As DataTable
        Try
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int16)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            dt.Clear()
            Me.Fill(CommandType.StoreProcedure, "GetAsgndVstrNoCnvrtdToCont_SP", dt, parProjectID, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllRequestStatus() As DataTable
        Try
            Dim d As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Me.Fill(CommandType.StoreProcedure, "GetAllRequestStatus_SP", d, parRefCursor)
            Return d
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateReuest_RequestStatus()
        Try
            Dim parRequestID As New OracleParameter("@RequestID", OracleDbType.Int64)
            parRequestID.Value = RequestID
            Dim parRequestStatusID As New OracleParameter("@RequestStatusID", OracleDbType.Int16)
            parRequestStatusID.Value = IIf(RequestStatusID = RequestStatusEnum.withNullValue, DBNull.Value, RequestStatusID)
            Dim parModifyDate_vc As New OracleParameter("@ModifyDate_vc", OracleDbType.Varchar2, 10)
            parModifyDate_vc.Value = GetDateNow()
            Dim parModifyUserID As New OracleParameter("@ModifyUserID", OracleDbType.Int64)
            parModifyUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID


            strSQL = "UpdateReuest_RequestStatus_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parRequestID, parRequestStatusID, parModifyDate_vc, parModifyUserID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateReuest_RequestStatusAndDuplicateRequestID()
        Try
            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID
            Dim parRequestStatusID As New OracleParameter("RequestStatusID_", OracleDbType.Int16)
            parRequestStatusID.Value = IIf(RequestStatusID = RequestStatusEnum.withNullValue, DBNull.Value, RequestStatusID)
            Dim parDuplicateRequestID As New OracleParameter("DuplicateRequestID_", OracleDbType.Int64)
            parDuplicateRequestID.Value = IIf(DuplicateRequestID = -1, DBNull.Value, DuplicateRequestID)

            Dim parModifyDate_vc As New OracleParameter("ModifyDate_vc_", OracleDbType.Varchar2, 10)
            parModifyDate_vc.Value = GetDateNow()
            Dim parModifyUserID As New OracleParameter("ModifyUserID_", OracleDbType.Int64)
            parModifyUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            strSQL = "UpdateReq_ReqStatDupReqID_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parRequestID, parRequestStatusID, parDuplicateRequestID, parModifyDate_vc, parModifyUserID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateReuest_RequestStatusAndHaveDeviceOutlet()
        Try
            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID
            Dim parRequestStatusID As New OracleParameter("RequestStatusID_", OracleDbType.Int16)
            parRequestStatusID.Value = IIf(RequestStatusID = RequestStatusEnum.withNullValue, DBNull.Value, RequestStatusID)
            Dim parHaveDeviceOutlet_vc As New OracleParameter("HaveDeviceOutlet_vc_", OracleDbType.Varchar2, 12)
            parHaveDeviceOutlet_vc.Value = IIf(HaveDeviceOutlet = String.Empty, DBNull.Value, HaveDeviceOutlet)

            Dim parModifyDate_vc As New OracleParameter("ModifyDate_vc_", OracleDbType.Varchar2, 10)
            parModifyDate_vc.Value = GetDateNow()
            Dim parModifyUserID As New OracleParameter("ModifyUserID_", OracleDbType.Int64)
            parModifyUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            'UpdateReuest_RequestStatusAndHaveDeviceOutlet_SP
            strSQL = "UpdateReq_ReqStatHavDevOtlt_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parRequestID, parRequestStatusID, parHaveDeviceOutlet_vc, parModifyDate_vc, parModifyUserID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetAllRequestsWithRequestStatus() As DataTable
        Try

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int16)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            dt.Clear()
            Me.Fill(CommandType.StoreProcedure, "GetAllReqsWithReqStat", dt, parProjectID, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub TransferRequest(ByVal RequestID As Int64, ByVal ProjectID As Int32)
        Try
            BeginProc()
            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.IsNullable = False
            parRequestID.Value = RequestID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parRequestID.IsNullable = False
            parProjectID.Value = ProjectID

            strSQL = "TransferRequest_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parRequestID, parProjectID)
            EndProc()
        Catch ex As Exception
            RollBackProc()
            Throw ex
        End Try
    End Sub

   
#End Region

End Class
