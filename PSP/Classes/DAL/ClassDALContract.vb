Imports Oracle.DataAccess.Client

Public Class ClassDALContract
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    '//////////////////////////////////
#Region "Fields"
    Private mvarSCityname_nvc As String
    '////////ContractingParty//////////
    Private mvarContractingPartyID As Int64
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
    Private mvarShabaAccount As String
    Private mvarCardNo_vc As String
    Private mvarBranchID As String
    '/////////Contract/////////////////////////
    Private mvarContractID As Int64
    'Private mvarContractingPartyID As Int64
    Private mvarContractNo_vc As String
    Private mvarMerchant_vc As String
    Private mvarSaveDate_vc As String
    Private mvarDate_vc As String
    Private mvarVisitorID As Int32
    Private mvarMarketingByID As Int16
    Private mvarZoncanNo_nvc As String
    Private mvarProjectID As Int16
    Private mvarRequestID As Int64
    Private mvarCMSProject As Int32
    '////////////Account//////////////////////
    Private mvarAAccountID As Int64
    'Private mvarAContractID As Int64
    Private mvarAAccountNO_vc As String
    Private mvarAShabaAccount As String
    Private mvarAShabaAccountold As String
    Private mvarACardNo_vc As String
    Private mvarAAccountTypeID As Int32
    Private mvarABranchID As String
    Private mvarissenttoshprk As String
    Private mvaraFinancialSupervisionId As String
    '//////////Store///////////////////
    Private mvarSStoreID As Int64
    'Private mvarSAccountID As Int64
    Private mvarSGroupID As String
    Private mvarSLicenseID As String
    Private mvarSSupplementaryID As String
    Private mvarSStateID As String
    Private mvarSCityID As String
    Private mvarSName_nvc As String
    Private mvarSPostCode_vc As String
    Private mvarSAddress_nvc As String
    Private mvarnewSAddress_nvc As String
    Private mvarnewSAddressCode_nvc As String
    Private mvarAddress3_nvc As String
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
    Private mvarStorePosModelID As Int32
    '//////////Device////////////////////
    Private mvarDPosID As Int64
    Private mvarDDeviceID As Int64
    'Private mvarStoreID As Int64
    Private mvarDCode_vc As String
    Private mvarDOutlet_vc As String
    Private mvarDVat_vc As String
    Private mvarDMerchant_vc As String
    Private mvarDPassword_vc As String
    Private mvarDIFCanceled_VisitorPayment_bit As Boolean
    Private mvarDSwitch_CardAcceptorID_vc As String
    Private mvarDSwitch_TerminalID_vc As String
    Private mvarDSwitch_FeeID_int As Int32
    '///////////DevicePos/////////////////
    Private mvarDPDevicePosID As Int64
    Private mvarDPDeviceID As Int64
    Private mvarDPPosID As Int64
    Private mvarDPIOTypeID As ClassDALIOType.IOTypeEnum
    '//////////DevicePosHistory////////////
    Private mvarDPHDevicePosHistoryID As Int64
    Private mvarDPHDeviceID As Int64
    Private mvarDPHPosID As Int64
    Private mvarDPHIOTypeID As Int16
    Private mvarDPHActionDate_vc As String
    Private mvarDPHActionDescription_nvc As String
    Private mvarDPHSaveDate_vc As String
    Private mvarDPHSaveUserID As Int64
    Private mvarDPHSaveAgentID As Int64
    Private mvarDPHIFActionIsCanceled_VisitorPayment_bit As Boolean
    '//////////////Print////////////////////////
    Private mvarPPrintLogID As Int64
    Private mvarPContractID As Int64
    Private mvarPDeviceCount As Int32
    Private mvarPPrintDate As String
    Private mvarPPrintTime As String
    '/////////////////////////////////
    Private mvarDCDeviceCancelID As Int64
    Private mvarDCDeviceID As Int64
    Private mvarDCPosID As Int64
    Private mvarDCDesc_nvc As String
    Private mvarDCDate_vc As String
    Private mvarDCFlag As Int16
    '///////////////////////////////////////////
    Private mvarContractDocImgeID As Int64
    Private mvarImageTypeID As Integer
    Private mvarImageURL_vc As String
    Private mvarImage_vb As Byte()
    Private mvarImageDesc_vc As String
    Private mvarAttachDate_vc As String
    '//////////////////////////////////////////
    Private mvarImageType As String


    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
    Public Enum DeviceCancelFlagTypeEnum As Short
        DevicecancelOK = 1
        DevicecancelNOK = 2
    End Enum
    Public Enum MarketingByEnum As Short
        Agent = 1
        Bank = 2
    End Enum

#Region "Property ContractingParty"

    Public Property ContractingPartyID() As Int64
        Get
            Return mvarContractingPartyID
        End Get
        Set(ByVal value As Int64)
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
    Public Property ShabaAccount() As String
        Get
            Return mvarShabaAccount
        End Get
        Set(ByVal value As String)
            mvarShabaAccount = value
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
    Public Property RequestID() As Int64
        Get
            Return mvarRequestID
        End Get
        Set(ByVal value As Int64)
            mvarRequestID = value
        End Set
    End Property
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
    Public Property MarketingByID() As Int16
        Get
            Return mvarMarketingByID
        End Get
        Set(ByVal value As Int16)
            mvarMarketingByID = value
        End Set
    End Property
    Public Property ZoncanNo_nvc() As String
        Get
            Return mvarZoncanNo_nvc
        End Get
        Set(ByVal value As String)
            mvarZoncanNo_nvc = value
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

    Public Property CMSProjectID() As Int32
        Get
            Return mvarCMSProject
        End Get
        Set(ByVal value As Int32)
            mvarCMSProject = value
        End Set
    End Property

    Public Property StorePosModelID() As Int32
        Get
            Return mvarStorePosModelID
        End Get
        Set(ByVal value As Int32)
            mvarStorePosModelID = value
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
    Public Property AShabaAccount() As String
        Get
            Return mvarAShabaAccount
        End Get
        Set(ByVal value As String)
            mvarAShabaAccount = value
        End Set
    End Property
    Public Property AShabaAccountold() As String
        Get
            Return mvarAShabaAccountold
        End Get
        Set(ByVal value As String)
            mvarAShabaAccountold = value
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
    Public Property issenttoshprk() As String
        Get
            Return mvarissenttoshprk
        End Get
        Set(ByVal value As String)
            mvarissenttoshprk = value
        End Set
    End Property
    Public Property AFinancialSupervisionId() As String
        Get
            Return mvaraFinancialSupervisionId
        End Get
        Set(ByVal value As String)
            mvaraFinancialSupervisionId = value
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

    Public Property SLicenseID() As String
        Get
            Return mvarSLicenseID
        End Get
        Set(ByVal value As String)
            mvarSLicenseID = value
        End Set
    End Property

    Public Property SSupplementary As String
        Get
            Return mvarSSupplementaryID
        End Get
        Set(ByVal value As String)
            mvarSSupplementaryID = value
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
    Public Property newSAddress_nvc() As String
        Get
            Return mvarnewSAddress_nvc
        End Get
        Set(ByVal value As String)
            mvarnewSAddress_nvc = value
        End Set
    End Property
    Public Property newSAddressCode_nvc() As String
        Get
            Return mvarnewSAddressCode_nvc
        End Get
        Set(ByVal value As String)
            mvarnewSAddressCode_nvc = value
        End Set
    End Property
    Public Property Address3_nvc() As String
        Get
            Return mvarAddress3_nvc
        End Get
        Set(ByVal value As String)
            mvarAddress3_nvc = value
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
#Region "Property Device"
    Public Property DPosID() As Int64
        Get
            Return mvarDPosID
        End Get
        Set(ByVal value As Int64)
            mvarDPosID = value
        End Set
    End Property
    Public Property DDeviceID() As Int64
        Get
            Return mvarDDeviceID
        End Get
        Set(ByVal value As Int64)
            mvarDDeviceID = value
        End Set
    End Property
    'Private mvarStoreID As Int64
    Public Property DCode_vc() As String
        Get
            Return mvarDCode_vc
        End Get
        Set(ByVal value As String)
            mvarDCode_vc = value
        End Set
    End Property
    Public Property DOutlet_vc() As String
        Get
            Return mvarDOutlet_vc
        End Get
        Set(ByVal value As String)
            mvarDOutlet_vc = value
        End Set
    End Property
    Public Property DVat_vc() As String
        Get
            Return mvarDVat_vc
        End Get
        Set(ByVal value As String)
            mvarDVat_vc = value
        End Set
    End Property
    Public Property DMerchant_vc() As String
        Get
            Return mvarDMerchant_vc
        End Get
        Set(ByVal value As String)
            mvarDMerchant_vc = value
        End Set
    End Property
    Public Property DPassword_vc() As String
        Get
            Return mvarDPassword_vc
        End Get
        Set(ByVal value As String)
            mvarDPassword_vc = value
        End Set
    End Property
    Public Property DIFCanceled_VisitorPayment_bit() As Boolean
        Get
            Return mvarDIFCanceled_VisitorPayment_bit
        End Get
        Set(ByVal value As Boolean)
            mvarDIFCanceled_VisitorPayment_bit = value
        End Set
    End Property
    Public Property DSwitch_CardAcceptorID_vc() As String
        Get
            Return mvarDSwitch_CardAcceptorID_vc
        End Get
        Set(ByVal value As String)
            mvarDSwitch_CardAcceptorID_vc = value
        End Set
    End Property

    Public Property DSwitch_FeeID_int() As Int32
        Get
            Return mvarDSwitch_FeeID_int
        End Get
        Set(ByVal value As Int32)
            mvarDSwitch_FeeID_int = value
        End Set
    End Property
    Public Property DSwitch_TerminalID_vc() As String
        Get
            Return mvarDSwitch_TerminalID_vc
        End Get
        Set(ByVal value As String)
            mvarDSwitch_TerminalID_vc = value
        End Set
    End Property

#End Region
#Region "Property DevicePos"
    Public Property DPDevicePosID() As Int64
        Get
            Return mvarDPDevicePosID
        End Get
        Set(ByVal value As Int64)
            mvarDPDevicePosID = value
        End Set
    End Property

    Public Property DPDeviceID() As Int64
        Get
            Return mvarDPDeviceID
        End Get
        Set(ByVal value As Int64)
            mvarDPDeviceID = value
        End Set
    End Property
    Public Property DPPosID() As Int64
        Get
            Return mvarDPPosID
        End Get
        Set(ByVal value As Int64)
            mvarDPPosID = value
        End Set
    End Property
    Public Property DPIOTypeID() As Int16
        Get
            Return mvarDPIOTypeID
        End Get
        Set(ByVal value As Int16)
            mvarDPIOTypeID = value
        End Set
    End Property

#End Region
#Region "Property DevicePosHistory"
    Public Property DPHDevicePosHistoryID() As Int64
        Get
            Return mvarDPHDevicePosHistoryID
        End Get
        Set(ByVal value As Int64)
            mvarDPHDevicePosHistoryID = value
        End Set
    End Property
    Public Property DPHDeviceID() As Int64
        Get
            Return mvarDPHDeviceID
        End Get
        Set(ByVal value As Int64)
            mvarDPHDeviceID = value
        End Set
    End Property
    Public Property DPHPosID() As Int64
        Get
            Return mvarDPHPosID
        End Get
        Set(ByVal value As Int64)
            mvarDPHPosID = value
        End Set
    End Property
    Public Property DPHIOTypeID() As Int16
        Get
            Return mvarDPHIOTypeID
        End Get
        Set(ByVal value As Int16)
            mvarDPHIOTypeID = value
        End Set
    End Property
    Public Property DPHActionDate_vc() As String
        Get
            Return mvarDPHActionDate_vc
        End Get
        Set(ByVal value As String)
            mvarDPHActionDate_vc = value
        End Set
    End Property
    Public Property DPHActionDescription_nvc() As String
        Get
            Return mvarDPHActionDescription_nvc
        End Get
        Set(ByVal value As String)
            mvarDPHActionDescription_nvc = value
        End Set
    End Property
    Public Property DPHSaveDate_vc() As String
        Get
            Return mvarDPHSaveDate_vc
        End Get
        Set(ByVal value As String)
            mvarDPHSaveDate_vc = value
        End Set
    End Property
    Public Property DPHSaveUserID() As Int64
        Get
            Return mvarDPHSaveUserID
        End Get
        Set(ByVal value As Int64)
            mvarDPHSaveUserID = value
        End Set
    End Property
    Public Property DPHSaveAgentID() As Int64
        Get
            Return mvarDPHSaveAgentID
        End Get
        Set(ByVal value As Int64)
            mvarDPHSaveAgentID = value
        End Set
    End Property
    Public Property DPHIFActionIsCanceled_VisitorPayment_bit() As Boolean
        Get
            Return mvarDPHIFActionIsCanceled_VisitorPayment_bit
        End Get
        Set(ByVal value As Boolean)
            mvarDPHIFActionIsCanceled_VisitorPayment_bit = value
        End Set
    End Property

#End Region
#Region "Property PrintLog"
    Public Property PPrintLogID() As Int64
        Get
            Return mvarPPrintLogID
        End Get
        Set(ByVal value As Int64)
            mvarPPrintLogID = value
        End Set
    End Property
    Public Property PContractID() As Int64
        Get
            Return mvarPContractID
        End Get
        Set(ByVal value As Int64)
            mvarPContractID = value
        End Set
    End Property
    Public Property PDeviceCount() As Int32
        Get
            Return mvarPDeviceCount
        End Get
        Set(ByVal value As Int32)
            mvarPDeviceCount = value
        End Set
    End Property
    Public Property PPrintDate() As String
        Get
            Return mvarPPrintDate
        End Get
        Set(ByVal value As String)
            mvarPPrintDate = value
        End Set
    End Property
    Public Property PPrintTime() As String
        Get
            Return mvarPPrintTime
        End Get
        Set(ByVal value As String)
            mvarPPrintTime = value
        End Set
    End Property
#End Region
#Region "Property DeviceCancel"
    Public Property DCDeviceCancelID()
        Get
            Return mvarDCDeviceCancelID
        End Get
        Set(ByVal value)
            mvarDCDeviceCancelID = value
        End Set
    End Property
    Public Property DCDeviceID() As Int64
        Get
            Return mvarDCDeviceID
        End Get
        Set(ByVal value As Int64)
            mvarDCDeviceID = value
        End Set
    End Property
    Public Property DCPosID() As Int64
        Get
            Return mvarDCPosID
        End Get
        Set(ByVal value As Int64)
            mvarDCPosID = value
        End Set
    End Property
    Public Property DCDesc_nvc() As String
        Get
            Return mvarDCDesc_nvc
        End Get
        Set(ByVal value As String)
            mvarDCDesc_nvc = value
        End Set
    End Property
    Public Property DCDate_vc() As String
        Get
            Return mvarDCDate_vc
        End Get
        Set(ByVal value As String)
            mvarDCDate_vc = value
        End Set
    End Property
    Public Property DCFlag() As DeviceCancelFlagTypeEnum
        Get
            Return mvarDCFlag
        End Get
        Set(ByVal value As DeviceCancelFlagTypeEnum)
            mvarDCFlag = value
        End Set
    End Property



#End Region

    Public Property SCityname_nvc() As String
        Get
            Return mvarSCityname_nvc
        End Get
        Set(ByVal value As String)
            mvarSCityname_nvc = value
        End Set
    End Property
#End Region

#Region "Property ContractDocImg"

    Public Property ContractDocImgeID As Int64
        Get
            Return mvarContractDocImgeID
        End Get
        Set(ByVal value As Int64)
            mvarContractDocImgeID = value
        End Set
    End Property

    Public Property ImageTypeID As Integer
        Get
            Return mvarImageTypeID
        End Get
        Set(ByVal value As Integer)
            mvarImageTypeID = value
        End Set
    End Property

    Public Property ImageURL_vc As String
        Get
            Return mvarImageURL_vc
        End Get
        Set(ByVal value As String)
            mvarImageURL_vc = value
        End Set
    End Property

    Public Property Image_vb As Byte()
        Get
            Return mvarImage_vb
        End Get
        Set(ByVal value As Byte())
            mvarImage_vb = value
        End Set
    End Property

    Public Property ImageDesc_vc As String
        Get
            Return mvarImageDesc_vc
        End Get
        Set(ByVal value As String)
            mvarImageDesc_vc = value
        End Set
    End Property

    Public Property AttachDate_vc As String
        Get
            Return mvarAttachDate_vc
        End Get
        Set(ByVal value As String)
            mvarAttachDate_vc = value
        End Set
    End Property

#End Region

#Region "Property ImgType"

    Public Property ImageType As String
        Get
            Return mvarImageType
        End Get
        Set(ByVal value As String)
            mvarImageType = value
        End Set
    End Property

#End Region

#Region "Methods"
#Region "Get Methods"
#Region "Get ALL"
    Public Function GetAllMarketingByForUCtrl() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "GetAllMarketingByForUCtrl_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllChange() As DataTable
        Try
            Dim dt As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, "GetAllChange_SP", dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllAria(ByVal CityID As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, "GetAllAria_SP", dt, parCityID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllByPercentContractingParty_Contract(ByVal UserID As Int64) As DataTable 'Modified by Mirmobin
        Try
            Dim dt As New DataTable

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            strSQL = "GetAllByPercentContParty_ByUID"    'last sp : GetAllByPercentContParty
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAccount() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "GetAllAccount_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllStore() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "GetAllStore"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllDevice() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "GetAllDevice_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllDeviceCrash() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "GetAllDeviceCrash_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllContractingParty_Contract_Store_AssignablePos(ByVal MarketingByID As Int16, ByVal ProjectID As Int16, ByVal CMSProjectID As Int32)
        Try
            Dim dt As New DataTable

            Dim paruserID As New OracleParameter("UserID_", OracleDbType.Int64)
            paruserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parMarketingByID As New OracleParameter("MarketingByID_", OracleDbType.Int64)
            parMarketingByID.Value = MarketingByID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int64)
            parProjectID.Value = ProjectID

            Dim parCMSProjectID As New OracleParameter("CMSProjectID_", OracleDbType.Int64)
            parCMSProjectID.Value = CMSProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetAllContractingParty_Contract_Store_AssignablePos_SP()
            'strSQL = "GETCNTPRT_CONT_STR_ASGNBL_POS2"
            strSQL = "GETCNTPRT_CONT_STR_ASGNBL_POS3" 'when Fanava project is selected join to contractImport_T
            'Me.BeginProc()
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, paruserID, parMarketingByID, parProjectID, parCMSProjectID, parRefCursor)
            Return dt
            'Me.EndProc()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllContractingParty_Contract_Account_Store_Device_ReAssignablePos(ByVal ProjectID As Int16)
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllContractingParty_Contract_Account_Store_Device_ReAssignablePos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllContractingParty_Contract_Account_Store_Device_Pos_installingDetail(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllContractingParty_Contract_Account_Store_Device_Pos_installingDetail_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllStore_State_City_Group()
        Try
            Dim dt As New DataTable

            strSQL = "GetAllStore_State_City_Group_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllRealCanceledDeviceContractingParty_Contract_Account_Store_Device_Pos(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetAllRealCanceledDeviceContractingParty_Contract_Account_Store_Device_Pos_SP
            strSQL = "GetAllRealCanceledDevice_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function GetAllTop100ContractingParty_Contract_Account_Store_Device_Pos(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllTop100ContractingParty_Contract_Account_Store_Device_Pos_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllTop100ContractingParty_Contract_Account_Store() As DataTable
        Try
            Dim dt As New DataTable

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllTop100ContractingParty_Contract_Account_Store_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllContract_Store_Group() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "Contract_Store_Group_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function



#End Region
#Region "Get BY"

    Public Function GetByStoreIDRealDeviceCount(ByVal StoreID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = StoreID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByStoreIDRealDeviceCount_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parStoreID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByRequestIDContract(ByVal RequestID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByRequestIDContract_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRequestID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBYDeviceIDInstallingDetail(ByVal DeviceID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''dbo.GetBYDeviceIDInstallingDetail_SP
            strSQL = "GetBYDeviceIDInstallingDetail"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDeviceID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByCodeDeviceCancel(ByVal Code_vc As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parCode_vc As New OracleParameter("Code_vc_", OracleDbType.Varchar2, 8)
            parCode_vc.Value = Code_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByCodeDeviceCancel_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCode_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByStoreIDMerchantAndVat(ByVal StoreID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = StoreID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByStoreIDMerchantAndVat_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parStoreID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByCodeFirstPartAndTypeCodes_Counter(ByVal CodeFirstPart_vc As String, ByVal Type_vc As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parCodeFirstPart_vc As New OracleParameter("CodeFirstPart_vc_", OracleDbType.Varchar2, 50)
            parCodeFirstPart_vc.Value = CodeFirstPart_vc
            Dim parType_vc As New OracleParameter("Type_vc_", OracleDbType.Varchar2, 1)
            parType_vc.Value = Type_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "db_accessadmin.GetByCodeFirstPartAndTypeCodes_Counter_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCodeFirstPart_vc, parType_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTheLatestSwitchTerminalID() As DataTable
        Try
            Dim dt As New DataTable

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetTheLatestSwitch_TerminalID_SP
            strSQL = "GetTheLatestSwitch_TermID_SP2"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'mirmobin
    Public Function GetTerminalIDByContractID(ByVal ContractID As Int64) As DataTable

        Try
            Dim dt As New DataTable
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim paroutlet_vc_ As New OracleParameter("outlet_vc_", OracleDbType.RefCursor, ParameterDirection.Output)


            Dim strSQL As String = "GetTerminalID_By_ContractID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, paroutlet_vc_)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTheLatestSwitchCMSTerminalID() As DataTable
        Try
            Dim dt As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'GetTheLatestSwitch_CMSTerminalID_SP
            strSQL = "GetTheLatestSwtch_CMSTermID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTheLatestSwitchCardAcceptorID() As DataTable
        Try
            Dim dt As New DataTable

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetTheLatestSwitch_CardAcceptorID_SP
            strSQL = "GetTheLatstSwtch_CrdAcptrID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTheLatestSwitch_CMSCardAcceptorID() As DataTable
        Try
            Dim dt As New DataTable
            'GetTheLatestSwitch_CMSCardAcceptorID_SP
            strSQL = "GetTheLtstSwtch_CMSCrdAcID_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByBlockedContrPContrStoreVisitorDevice(ByVal Blocked_bit As Boolean, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parBlocked_bit As New OracleParameter("Blocked_bit_", OracleDbType.Int32)
            parBlocked_bit.Value = Blocked_bit

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'db_accessadmin.GetByBlockedContrPContrStoreVisitorDevice_SP
            strSQL = "GetByBlocked_Contracts_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parBlocked_bit, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByContractIDAndHavPos(ByVal ContractID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByContractIDAndHavPos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByContractIDContrPContrStoreVisitorDevice(ByVal ContractID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetByContractIDContrPContrStoreVisitorDevice_SP
            strSQL = "GetByContIDContPContStrVisDev"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetOutletAndMerchantByContractingPartyID(ByVal StoreID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractingPartyID As New OracleParameter("ContractingPartyID_", OracleDbType.Int64)
            parContractingPartyID.Value = ContractingPartyID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetOtltAndMerchByContPartyID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractingPartyID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetOutletAndMerchantByStoreID(ByVal StoreID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = StoreID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetOutletAndMerchantByStoreID_sp
            strSQL = "GetOutletAndMerchByStoreID_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parStoreID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByBirthDateContractingParty_Contract_Account_Store(ByVal BirthDate_vc1 As String, ByVal BirthDate_vc2 As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parBirthDate_vc1 As New OracleParameter("BirthDate_vc1_", OracleDbType.Varchar2, 10)
            parBirthDate_vc1.Value = BirthDate_vc1
            Dim parBirthDate_vc2 As New OracleParameter("BirthDate_vc2_", OracleDbType.Varchar2, 10)
            parBirthDate_vc2.Value = BirthDate_vc2
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByBirthDateContractingParty_Contract_Account_Store_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parBirthDate_vc1, parBirthDate_vc2, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBySSIdentityTypeEDateContractingParty_Contract_Account_Store(ByVal SSIdentityTypeEDate_vc1 As String, ByVal SSIdentityTypeEDate_vc2 As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parSSIdentityTypeEDate_vc1 As New OracleParameter("SSIdentityTypeEDate_vc1_", OracleDbType.Varchar2, 10)
            parSSIdentityTypeEDate_vc1.Value = SSIdentityTypeEDate_vc1
            Dim parSSIdentityTypeEDate_vc2 As New OracleParameter("SSIdentityTypeEDate_vc2_", OracleDbType.Varchar2, 10)
            parSSIdentityTypeEDate_vc2.Value = SSIdentityTypeEDate_vc2
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBySSIdentityTypeEDateContractingParty_Contract_Account_Store_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSSIdentityTypeEDate_vc1, parSSIdentityTypeEDate_vc2, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByPSerialContractingParty_Contract_Account_Store_Device_Pos(ByVal PSerial_vc As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parPSerial_vc As New OracleParameter("PSerial_vc_", OracleDbType.Varchar2, 20)
            parPSerial_vc.Value = PSerial_vc

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByPSerialContractingParty_Contract_Account_Store_Device_Pos_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPSerial_vc, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByPPropertyNoContractingParty_Contract_Account_Store_Device_Pos(ByVal PPropertyNo_vc As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parPPropertyNo_vc As New OracleParameter("PPropertyNo_vc_", OracleDbType.Varchar2, 20)
            parPPropertyNo_vc.Value = PPropertyNo_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByPPropertyNoContractingParty_Contract_Account_Store_Device_Pos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPPropertyNo_vc, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByPEniacCodeContractingParty_Contract_Account_Store_Device_Pos(ByVal PEniacCode_vc As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parPEniacCode_vc As New OracleParameter("PEniacCode_vc_", OracleDbType.Varchar2, 20)
            parPEniacCode_vc.Value = PEniacCode_vc

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByPEniacCodeContractingParty_Contract_Account_Store_Device_Pos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPEniacCode_vc, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByDOutletContractingParty_Contract_Account_Store_Device_Pos(ByVal DOutlet_vc As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDOutlet_vc As New OracleParameter("DOutlet_vc_", OracleDbType.Varchar2, 20)
            parDOutlet_vc.Value = DOutlet_vc

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByDOutletContractingParty_Contract_Account_Store_Device_Pos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDOutlet_vc, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByDCodeContractingParty_Contract_Account_Store_Device_Pos(ByVal DCode_vc As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDCode_vc As New OracleParameter("DCode_vc_", OracleDbType.Varchar2, 20)
            parDCode_vc.Value = DCode_vc

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByDCodeContractingParty_Contract_Account_Store_Device_Pos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDCode_vc, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByPosIDDevice(ByVal PosID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = PosID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByPosIDDevice"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPosID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByFlagContractingParty_Contract_Accont_Store_Device_Pos_DeviceCancel(ByVal Flag As DeviceCancelFlagTypeEnum, ByVal ProjectID As Int16)
        Try
            Dim dt As New DataTable

            Dim parFlag As New OracleParameter("Flag_", OracleDbType.Int16)
            parFlag.Value = Flag

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetByFlagContractingParty_Contract_Accont_Store_Device_Pos_DeviceCancel_SP
            strSQL = "GetByFlag_DevCancel_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parFlag, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByPosIDFlagDeviceCancelTheLatestOperation(ByVal PosID As Int64, ByVal Flag As DeviceCancelFlagTypeEnum)
        Try
            Dim dt As New DataTable

            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = PosID

            Dim parFlag As New OracleParameter("Flag_", OracleDbType.Int16)
            parFlag.Value = Flag

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByPosIDFlagDeviceCancelTheLatestOperation_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPosID, parFlag, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
        End
    End Function
    Public Function GetByPosIDDeviceCancelTheLatestOperation(ByVal PosID As Int64)
        Try
            Dim dt As New DataTable

            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = PosID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetByPosIDDeviceCancelTheLatestOperation_SP
            strSQL = "GetByPosIDDevCancelLastOp_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPosID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
        End
    End Function

    Public Function GetByContractIDContractingParty_Contract_Account_Store_PURE_SumDeviceCount() As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Dim strSQL As String = "GetByContID_SumDevCount_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByContractIDContractingParty_Contract_Store_Device(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByContractIDContractingParty_Contract_Store_Device_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBySaveDate_SentAccountingContractingParty_Contract_Store_Device(ByVal SaveDate_vc1 As String, ByVal SaveDate_vc2 As String, ByVal SentAccounting_tint As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parSaveDate_vc1 As New OracleParameter("SaveDate_vc1_", OracleDbType.Varchar2, 10)
            parSaveDate_vc1.Value = SaveDate_vc1

            Dim parSaveDate_vc2 As New OracleParameter("SaveDate_vc2_", OracleDbType.Varchar2, 10)
            parSaveDate_vc2.Value = SaveDate_vc2

            Dim parSentAccounting_tint As New OracleParameter("DSentAccounting_tint_", OracleDbType.Int16)
            parSentAccounting_tint.Value = SentAccounting_tint

            strSQL = "GetBySaveDate_SentAccountingContractingParty_Contract_Store_Device_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSaveDate_vc1, parSaveDate_vc2, parSentAccounting_tint)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBySaveDate_SentSwitchContractingParty_Contract_Store_Device(ByVal SaveDate_vc1 As String, ByVal SaveDate_vc2 As String, ByVal SentSwitch_tint As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parSaveDate_vc1 As New OracleParameter("SaveDate_vc1_", OracleDbType.Varchar2, 10)
            parSaveDate_vc1.Value = SaveDate_vc1

            Dim parSaveDate_vc2 As New OracleParameter("SaveDate_vc2_", OracleDbType.Varchar2, 10)
            parSaveDate_vc2.Value = SaveDate_vc2

            Dim parSentSwitch_tint As New OracleParameter("DSentSwitch_tint_", OracleDbType.Int16)
            parSentSwitch_tint.Value = SentSwitch_tint

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBySaveDate_SentSwitchContractingParty_Contract_Store_Device_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSaveDate_vc1, parSaveDate_vc2, parSentSwitch_tint, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBySaveDate_SentInstallingContractingParty_Contract_Store_Device(ByVal SaveDate_vc1 As String, ByVal SaveDate_vc2 As String, ByVal SentInstalling_tint As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parSaveDate_vc1 As New OracleParameter("SaveDate_vc1_", OracleDbType.Varchar2, 10)
            parSaveDate_vc1.Value = SaveDate_vc1

            Dim parSaveDate_vc2 As New OracleParameter("SaveDate_vc2_", OracleDbType.Varchar2, 10)
            parSaveDate_vc2.Value = SaveDate_vc2

            Dim parSentInstalling_tint As New OracleParameter("DSentInstalling_tint_", OracleDbType.Int16)
            parSentInstalling_tint.Value = SentInstalling_tint

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBySaveDate_SentInstallingContractingParty_Contract_Store_Device_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSaveDate_vc1, parSaveDate_vc2, parSentInstalling_tint, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByContractIDContractingParty_Contract(ByVal UserID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            ''GetByContIDContParty_Cont_SP
            strSQL = "GetByContIDConParty_Con_ByUID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByMerchantContractingParty_Contract(ByVal UserID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parMerchant As New OracleParameter("Merchant_vc_", OracleDbType.Varchar2, 12)
            parMerchant.Value = Merchant_vc

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetByMerchantContractingParty_Contract_SP
            ''GetByMerchContParty_Cont_SP
            strSQL = "GetByMerchContParty_Cont_ByUID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parMerchant, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByContractNoContractingParty_Contract(ByVal UserID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractNo_vc As New OracleParameter("ContractNo_vc_", OracleDbType.Varchar2, 20)
            parContractNo_vc.Value = ContractNo_vc

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetByContractNoContractingParty_Contract_SP
            ''GetByContNoContParty_Cont_SP
            strSQL = "GetByContNoConParty_Con_ByUID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractNo_vc, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByNationalCodeContractingParty_Contract(ByVal UserID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parNationalCode_nvc As New OracleParameter("NationalCode_nvc_", OracleDbType.Varchar2, 12)
            parNationalCode_nvc.Value = NationalCode_nvc

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetByNationalCodeContractingParty_Contract_SP
            ''GetByNatiCodeContParty_Cont
            strSQL = "GetByNatCodeCntParty_Cnt_ByUID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parNationalCode_nvc, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByLastNameContractingParty_Contract(ByVal UserID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parLastName_nvc As New OracleParameter("LastName_nvc_", OracleDbType.Varchar2, 50)
            parLastName_nvc.Value = LastName_nvc

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetByLastNameContractingParty_Contract_SP
            ''GetByLNameContParty_Cont_sp
            strSQL = "GetByLNameContParty_Cont_ByUID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parLastName_nvc, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByDateContractingParty_Contract(ByVal UserID As Int64)
        Try
            Dim dt As New DataTable

            Dim parDate_vc As New OracleParameter("Date_vc_", OracleDbType.Varchar2, 10)
            parDate_vc.Value = Date_vc

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetByDateContractingParty_Contract_SP
            ''GetByDateContParty_Cont_SP
            strSQL = "GetByDateContParty_Cont_ByUID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDate_vc, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBySaveDateContractingParty_Contract(ByVal UserID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = SaveDate_vc

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetBySaveDateContractingParty_Contract_SP
            ''GetBySaveDateContParty_Cont_SP
            strSQL = "GetBySaveDateConPrty_Con_ByUID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSaveDate_vc, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByRequestIDContractingParty_Contract(ByVal UserID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetByRequestIDContractingParty_Contract_SP
            ''GetByReqIDContParty_Cont_SP
            strSQL = "GetByReqIDContParty_Cont_ByUID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRequestID, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByOutletContractingParty_Contract(ByVal Userid As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parOutlet As New OracleParameter("Outlet_", OracleDbType.Varchar2, 15)
            parOutlet.Value = DOutlet_vc

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = Userid

            Dim parrefCursor As New OracleParameter("Result_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "GetByOutltContParty_Cont_ByUID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parOutlet, parUserID, parrefCursor)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetByVisitorIDContractingParty_Contract(ByVal ProjectID As Int16) As DataTable  'there is no call to this method
        Try
            Dim dt As New DataTable

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByVisitorIDContractingParty_Contract_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parVisitorID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByContractIDStore() As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByContractIDStore_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByTel2Store() As DataTable
        Try
            Dim dt As New DataTable

            Dim parSTel2_vc As New OracleParameter("STel2_vc_", OracleDbType.Varchar2, 20)
            parSTel2_vc.Value = STel2_vc

            strSQL = "GetByTel2Store_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSTel2_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetByTel1Store() As DataTable
        Try
            Dim dt As New DataTable

            Dim parSTel1_vc As New OracleParameter("STel1_vc_", OracleDbType.Varchar2, 20)
            parSTel1_vc.Value = STel1_vc

            strSQL = "GetByTel1Store_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSTel1_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetByStoreIDCountDevice_SP(ByVal Count_int As Int32) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDStoreID As New OracleParameter("DStoreID_", OracleDbType.Int64)
            parDStoreID.Value = SStoreID

            Dim parCount_int As New OracleParameter("Count_int_", OracleDbType.Int32)
            parCount_int.Value = Count_int

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByStoreIDCountDevice_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDStoreID, parCount_int, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetBYDOutlet() As DataTable
        Try
            Dim dt As New DataTable

            Dim parOutlet_vc As New OracleParameter("Outlet_vc_", OracleDbType.Varchar2, 20)
            parOutlet_vc.Value = DOutlet_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBYOutletDevice_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parOutlet_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBYDCode() As DataTable
        Try
            Dim dt As New DataTable

            Dim parCode_vc As New OracleParameter("Code_vc_", OracleDbType.Varchar2, 8)
            parCode_vc.Value = DCode_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBYCodeDevice_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCode_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByContractIDPrintLog() As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = PContractID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByContractIDPrintLog_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetByGetByContractIDContractingParty_Contract_Store_AssignablePos(ByVal mContractID As Int64, ByVal mMarketingByID As Int16, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = mContractID
            Dim parMarketingByID As New OracleParameter("MarketingByID_", OracleDbType.Int16)
            parMarketingByID.Value = mMarketingByID
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'GetByContractIDContractingParty_Contract_Store_AssignablePos_SP
            strSQL = "GetByContID_AssignablePos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parMarketingByID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetByPosIDDevicePos_Device_PosAssigning() As DataTable
        Try
            Dim dt As New DataTable

            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = DPPosID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByPosIDDevicePos_Device_PosAssigning_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPosID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function GetByAccountIDAccount() As DataTable
        Try
            Dim dt As New DataTable

            Dim parAccountID As New OracleParameter("AccountID_", OracleDbType.Int64)
            parAccountID.Value = AAccountID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByIDAccount_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parAccountID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByDeviceIDDevice()
        Try
            Dim dt As New DataTable

            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DDeviceID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByDeviceIDDevice_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDeviceID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByContractIDSerialCountContractingParty_Contract_Account_Store_Device_Device_Pos_DevicePos_PURE(ByVal PSerial_vc As String, ByVal Count_int As Int16, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parPSerial_vc As New OracleParameter("PSerial_vc_", OracleDbType.Varchar2, 20)
            parPSerial_vc.Value = PSerial_vc

            Dim parCount_int As New OracleParameter("Count_int_", OracleDbType.Int32)
            parCount_int.Value = Count_int

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetByContractIDSerialCountContractingParty_Contract_Account_Store_Device_Device_Pos_DevicePos_PURE_SP
            strSQL = "GetByContIDSerialCountContPar"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parPSerial_vc, parCount_int, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByContractIDSerialContractingParty_Contract_Account_Store_Device_Pos_PURE(ByVal PSerial_vc As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parPSerial_vc As New OracleParameter("PSerial_vc_", OracleDbType.Varchar2, 20)
            parPSerial_vc.Value = PSerial_vc

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByContractIDSerialContractingParty_Contract_Account_Store_Device_Pos_PURE_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parPSerial_vc, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetBYMerchantDevice_LIKE(ByVal Merchant_vc As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parMerchant_vc As New OracleParameter("Merchant_vc_", OracleDbType.Varchar2, 15)
            parMerchant_vc.Value = Merchant_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBYMerchantDevice_LIKE_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parMerchant_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBYVatDevice_LIKE(ByVal Vat As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parVat_vc As New OracleParameter("Vat_vc_", OracleDbType.Varchar2, 15)
            parVat_vc.Value = Vat

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBYVatDevice_LIKE_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parVat_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBYOutletDevice_LIKE(ByVal Outlet As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parOutlet_vc As New OracleParameter("Outlet_vc_", OracleDbType.Varchar2, 12)
            parOutlet_vc.Value = Outlet

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBYOutletDevice_LIKE_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parOutlet_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBYCodeDevice_LIKE(ByVal Code As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parCode_vc As New OracleParameter("Code_vc_", OracleDbType.Varchar2, 8)
            parCode_vc.Value = Code

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBYCodeDevice_LIKE_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCode_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBySerialDevice_Pos(ByVal Serial_vc As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parPSerial_vc As New OracleParameter("PSerial_vc_", OracleDbType.Varchar2, 20)
            parPSerial_vc.Value = Serial_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBySerialDevice_Pos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPSerial_vc, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBYDeviceIDContractingParty_Contract_Account_Store_Device_Pos_PURE(ByVal DeviceID As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetBYDeviceIDContractingParty_Contract_Account_Store_Device_Pos_PURE_SP

            strSQL = "GetBYDevID_POS_PURE_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDeviceID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBYDeviceIDContractingParty_Contract_Account_Store_Device_PURE(ByVal DeviceID As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetBYDeviceIDContractingParty_Contract_Account_Store_Device_PURE_SP
            strSQL = "GetBYDevID_PURE_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDeviceID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Raeisi
    Public Function GetBYDeviceIDContractingParty_Contract_Account_Store_Device_Pos_PURE_Show(ByVal PosSerial As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parPosSerial As New OracleParameter("PosSerial_", OracleDbType.Varchar2)
            parPosSerial.Value = PosSerial

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'strSQL = "GetBYDeviceIDContractingParty_Contract_Account_Store_Device_Pos_PURE_Show_SP"
            strSQL = "GtDVCCNTPCNTACCSTRPOS_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPosSerial, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'raeisi
    Public Function GetBYDeviceIDContractingParty_Contract_Account_Store_Device_PURE_Show(ByVal PosSerial As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parPosSerial As New OracleParameter("PosSerial_", OracleDbType.Varchar2)
            parPosSerial.Value = PosSerial

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'strSQL = "GetBYDeviceIDContractingParty_Contract_Account_Store_Device_PURE_Show_SP"
            strSQL = "GtDVCCNTPCNTACCSTR_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parPosSerial, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByCountGetByCountContractingParty_Contract_Account_Store_Device_DeviceCancel_Device_PosCanceling(ByVal count_int As Int32, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parCount_int As New OracleParameter("Count_int_", OracleDbType.Int32)
            parCount_int.Value = count_int

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByCountGetByCountContractingParty_Contract_Account_Store_Device_DeviceCancel_Device_PosCanceling_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCount_int, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function GetByInstallOKStroe_Device_InstallingHeader_InstallingDetail(ByVal Install_OK As Int16, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parInstall_OK As New OracleParameter("Install_OK_", OracleDbType.Int16)
            parInstall_OK.Value = Install_OK

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetByInstallOKStroe_Device_InstallingHeader_InstallingDetail_SP
            strSQL = "GetByInstallOKHead_Det"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parInstall_OK, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetContractByEnaicCode(ByVal EniacCode As String) As DataTable
        Try
            Dim dtStore As New DataTable

            Dim parEniacSerial As New OracleParameter("EniacCode_", OracleDbType.Varchar2, 20)
            parEniacSerial.Value = EniacCode

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetContractByEnaicCode_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtStore, parEniacSerial, parRefCursor)
            Return dtStore
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByStoreIDDevice() As DataTable
        Try
            Dim dt As New DataTable

            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = SStoreID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByStoreIDDevice_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parStoreID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllInfo_By_ContractID(ByVal Number As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = Number

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetAllInfo_By_ContractID_SP", dt, parContractID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Function GetContractAllDataByID(ByVal contractId) As DataTable
        Try
            Dim dt As New DataTable
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = contractId

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetContractAllDataByID_SP", dt, parContractID, parRefCursor)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#Region "Get Others"
    Public Function GetExistingTitles() As DataTable
        Try
            Dim dtExistingTitles As New DataTable

            strSQL = "GetExistingTitles_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtExistingTitles, parRefCursor)
            Return dtExistingTitles
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTheLatestContract() As DataTable
        Try
            Dim dt As New DataTable
            ''GetTheLatestContract_SP
            strSQL = "GetTheLatestContract"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTheLatestDevice() As DataTable
        Try
            Dim dt As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetTheLatestDevice_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTheLatestPos() As DataTable
        Try
            Dim dt As New DataTable

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetTheLatestPos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGeneral(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllContractingParty_Contract_Account_Store_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#End Region
#Region "Others"
    Public Sub CheckForStoreCancel(ByVal StoreID As Int64, ByRef CountDeviceID As Int32, ByRef CountCanceledDeviceID As Int32)
        Try
            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = StoreID

            Dim parCountDeviceID As New OracleParameter("CountDeviceID_", OracleDbType.Int32)
            parCountDeviceID.Direction = ParameterDirection.Output

            Dim parCountCanceledDeviceID As New OracleParameter("CountCanceledDeviceID_", OracleDbType.Int32)
            parCountCanceledDeviceID.Direction = ParameterDirection.Output

            Dim strSQL As String = "CheckForStoreCancel_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parStoreID, parCountDeviceID, parCountCanceledDeviceID)

            CountDeviceID = parCountDeviceID.Value
            CountCanceledDeviceID = parCountCanceledDeviceID.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function IsSerialRepeated(ByVal Serial_vc As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parSerial_vc As New OracleParameter("Serial_vc_", OracleDbType.Varchar2, 20)
            parSerial_vc.Value = Serial_vc

            strSQL = "IsSerialRepeated_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSerial_vc)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "Insert Methods"
    Public Function InsertCodes_Counter(ByVal Type_vc As String, ByVal CodeFirstPart_vc As String, ByVal LastCounter_vc As String) As Int64
        Try

            Dim parType_vc As New OracleParameter("Type_vc_", OracleDbType.Varchar2, 1)
            parType_vc.Value = Type_vc

            Dim parCodeFirstPart_vc As New OracleParameter("CodeFirstPart_vc_", OracleDbType.Varchar2, 50)
            parCodeFirstPart_vc.Value = CodeFirstPart_vc

            Dim parLastCounter_vc As New OracleParameter("LastCounter_vc_", OracleDbType.Varchar2, 50)
            parLastCounter_vc.Value = LastCounter_vc

            Dim parID As New OracleParameter("ID_", OracleDbType.Int64)
            parID.Direction = ParameterDirection.Output

            Dim strSQL As String = "db_accessadmin.InsertCodes_Counter_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parType_vc, parCodeFirstPart_vc, parLastCounter_vc, parID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertChange(ByVal Merchant_vc As String, ByVal Outlet_vc As String, ByVal StoreName_nvc1 As String, ByVal StoreName_nvc2 As String, ByVal StoreAddress_nvc1 As String, ByVal StoreAddress_nvc2 As String, ByVal StorePostCode_vc1 As String, ByVal StorePostCode_vc2 As String, ByVal StoreStateName_nvc1 As String, ByVal StoreStateName_nvc2 As String, ByVal StoreCityName_nvc1 As String, ByVal StoreCityName_nvc2 As String, ByVal StoreTel1_Vc1 As String, ByVal StoreTel1_Vc2 As String, ByVal StoreTel2_Vc1 As String, ByVal StoreTel2_Vc2 As String, ByVal StoreFax_Vc1 As String, ByVal StoreFax_Vc2 As String, ByVal Email_nvc1 As String, ByVal Email_nvc2 As String, ByVal ChangeDate_vc As String)
        Dim strSQL As String
        Try
            Dim parMerchant_vc As New OracleParameter("Merchant_vc_", OracleDbType.Varchar2, 12)
            parMerchant_vc.Value = Merchant_vc

            Dim parOutlet_vc As New OracleParameter("Outlet_vc_", OracleDbType.Varchar2, 12)
            parOutlet_vc.Value = Outlet_vc

            Dim parStoreName_nvc1 As New OracleParameter("StoreName_nvc1_", OracleDbType.Varchar2, 50)
            parStoreName_nvc1.Value = StoreName_nvc1

            Dim parStoreName_nvc2 As New OracleParameter("StoreName_nvc2_", OracleDbType.Varchar2, 50)
            parStoreName_nvc2.Value = IIf(StoreName_nvc2 = "-1", DBNull.Value, StoreName_nvc2)

            Dim parStoreAddress_nvc1 As New OracleParameter("StoreAddress_nvc1_", OracleDbType.Varchar2, 500)
            parStoreAddress_nvc1.Value = IIf(StoreAddress_nvc1 = "-1", DBNull.Value, StoreAddress_nvc1)

            Dim parStoreAddress_nvc2 As New OracleParameter("StoreAddress_nvc2_", OracleDbType.Varchar2, 500)
            parStoreAddress_nvc2.Value = IIf(StoreAddress_nvc2 = "-1", DBNull.Value, StoreAddress_nvc2)

            Dim parStorePostCode_vc1 As New OracleParameter("StorePostCode_vc1_", OracleDbType.Varchar2, 10)
            parStorePostCode_vc1.Value = IIf(StorePostCode_vc1 = "-1", DBNull.Value, StorePostCode_vc1)

            Dim parStorePostCode_vc2 As New OracleParameter("StorePostCode_vc2_", OracleDbType.Varchar2, 10)
            parStorePostCode_vc2.Value = IIf(StorePostCode_vc2 = "-1", DBNull.Value, StorePostCode_vc2)

            Dim parStoreStateID1 As New OracleParameter("StoreStateID1_", OracleDbType.Varchar2, 3)
            parStoreStateID1.Value = IIf(StoreStateName_nvc1 = "-1", DBNull.Value, StoreStateName_nvc1)

            Dim parStoreStateID2 As New OracleParameter("StoreStateID2_", OracleDbType.Varchar2, 3)
            parStoreStateID2.Value = IIf(StoreStateName_nvc2 = "-1", DBNull.Value, StoreStateName_nvc2)

            Dim parStoreCityID1 As New OracleParameter("StoreCityID1_", OracleDbType.Varchar2, 5)
            parStoreCityID1.Value = IIf(StoreCityName_nvc1 = "-1", DBNull.Value, StoreCityName_nvc1)

            Dim parStoreCityID2 As New OracleParameter("StoreCityID2_", OracleDbType.Varchar2, 5)
            parStoreCityID2.Value = IIf(StoreCityName_nvc2 = "-1", DBNull.Value, StoreCityName_nvc2)

            Dim parStoreTel1_Vc1 As New OracleParameter("StoreTel1_Vc1_", OracleDbType.Varchar2, 20)
            parStoreTel1_Vc1.Value = IIf(StoreTel1_Vc1 = "-1", DBNull.Value, StoreTel1_Vc1)

            Dim parStoreTel1_Vc2 As New OracleParameter("StoreTel1_Vc2_", OracleDbType.Varchar2, 20)
            parStoreTel1_Vc2.Value = IIf(StoreTel1_Vc2 = "-1", DBNull.Value, StoreTel1_Vc2)

            Dim parStoreTel2_Vc1 As New OracleParameter("StoreTel2_Vc1_", OracleDbType.Varchar2, 20)
            parStoreTel2_Vc1.Value = IIf(StoreTel2_Vc1 = "-1", DBNull.Value, StoreTel2_Vc1)

            Dim parStoreTel2_Vc2 As New OracleParameter("StoreTel2_Vc2_", OracleDbType.Varchar2, 20)
            parStoreTel2_Vc2.Value = IIf(StoreTel2_Vc2 = "-1", DBNull.Value, StoreTel2_Vc2)

            Dim parStoreFax_Vc1 As New OracleParameter("StoreFax_Vc1_", OracleDbType.Varchar2, 20)
            parStoreFax_Vc1.Value = IIf(StoreFax_Vc1 = "-1", DBNull.Value, StoreFax_Vc1)


            Dim parStoreFax_Vc2 As New OracleParameter("StoreFax_Vc2_", OracleDbType.Varchar2, 20)
            parStoreFax_Vc2.Value = IIf(StoreFax_Vc2 = "-1", DBNull.Value, StoreFax_Vc2)

            Dim parEmail_nvc1 As New OracleParameter("Email_nvc1", OracleDbType.Varchar2, 20)
            parEmail_nvc1.Value = IIf(Email_nvc1 = "-1", DBNull.Value, Email_nvc1)

            Dim parEmail_nvc2 As New OracleParameter("Email_nvc2_", OracleDbType.Varchar2, 20)
            parEmail_nvc2.Value = IIf(Email_nvc2 = "-1", DBNull.Value, Email_nvc2)

            Dim parChangeDate_vc As New OracleParameter("ChangeDate_vc_", OracleDbType.Varchar2, 10)
            parChangeDate_vc.Value = ChangeDate_vc

            Dim parChangeID As New OracleParameter("ChangeID_", OracleDbType.Int32)
            parChangeID.Direction = ParameterDirection.Output

            strSQL = "InsertChange_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parMerchant_vc, parOutlet_vc, parStoreName_nvc1, parStoreName_nvc2, parStoreAddress_nvc1, parStoreAddress_nvc2, parStorePostCode_vc1, parStorePostCode_vc2, parStoreStateID1, parStoreStateID2, parStoreCityID1, parStoreCityID2, parStoreTel1_Vc1, parStoreTel1_Vc2, parStoreTel2_Vc1, parStoreTel2_Vc2, parStoreFax_Vc1, parStoreFax_Vc2, parEmail_nvc1, parEmail_nvc2, parChangeDate_vc, parChangeID)
            Return Convert.ToInt64(parChangeID.Value.ToString)

            '===Thelatest
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertContractParty() As Int64
        Try
            Dim parFirstName_nvc As New OracleParameter("FirstName_nvc_", OracleDbType.Varchar2, 30)
            parFirstName_nvc.Value = FirstName_nvc

            Dim parLastName_nvc As New OracleParameter("LastName_nvc_", OracleDbType.Varchar2, 50)
            parLastName_nvc.Value = LastName_nvc

            Dim parFatherName_nvc As New OracleParameter("FatherName_nvc_", OracleDbType.Varchar2, 30)
            parFatherName_nvc.Value = FatherName_nvc

            Dim parIdentityCertificateNO_nvc As New OracleParameter("IdentityCertificateNO_nvc_", OracleDbType.Varchar2, 12)
            parIdentityCertificateNO_nvc.Value = IdentityCertificateNO_nvc

            Dim parNationalCode_nvc As New OracleParameter("NationalCode_nvc_", OracleDbType.Varchar2, 12)
            parNationalCode_nvc.Value = NationalCode_nvc

            Dim parGender_bit As New OracleParameter("Gender_bit_", OracleDbType.Int32)
            parGender_bit.Value = Gender_bit

            Dim parBirthDate_vc As New OracleParameter("BirthDate_vc_", OracleDbType.Varchar2, 10)
            parBirthDate_vc.Value = BirthDate_vc

            Dim parStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID.Trim

            Dim parCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID

            Dim parCIdentityTypeID As New OracleParameter("CIdentityTypeID_", OracleDbType.Int32)
            parCIdentityTypeID.Value = CIdentityTypeID

            Dim parDegreeID As New OracleParameter("DegreeID_", OracleDbType.Int32)
            parDegreeID.Value = IIf(DegreeID = -1, DBNull.Value, DegreeID)

            Dim parTitle_nvc As New OracleParameter("Title_nvc_", OracleDbType.Varchar2, 30)
            parTitle_nvc.Value = Title_nvc

            Dim parHomeAddress_nvc As New OracleParameter("HomeAddress_nvc_", OracleDbType.Varchar2, 500)
            parHomeAddress_nvc.Value = HomeAddress_nvc

            Dim parHomeTel_vc As New OracleParameter("HomeTel_vc_", OracleDbType.Varchar2, 20)
            parHomeTel_vc.Value = HomeTel_vc

            Dim parMobile_vc As New OracleParameter("Mobile_vc_", OracleDbType.Varchar2, 20)
            parMobile_vc.Value = Mobile_vc

            Dim parEmail_nvc As New OracleParameter("Email_nvc_", OracleDbType.Varchar2, 50)
            parEmail_nvc.Value = Email_nvc

            Dim parHavingAccount_bit As New OracleParameter("HavingAccount_bit_", OracleDbType.Int32)
            parHavingAccount_bit.Value = HavingAccount_bit

            Dim parAccountTypeID As New OracleParameter("AccountTypeID_", OracleDbType.Int32)
            parAccountTypeID.Value = IIf(AccountTypeID = -1, DBNull.Value, AccountTypeID)

            Dim parAccountNO_vc As New OracleParameter("AccountNO_vc_", OracleDbType.Varchar2, 20)
            parAccountNO_vc.Value = AccountNO_vc

            Dim parShabaAccount As New OracleParameter("ShabaAccount_", OracleDbType.Varchar2, 50)
            parShabaAccount.Value = ShabaAccount ' IIf(AShabaAccount = String.Empty, ShabaAccount, AShabaAccount)

            Dim parCardNo_vc As New OracleParameter("CardNo_vc_", OracleDbType.Varchar2, 8)
            parCardNo_vc.Value = CardNo_vc

            Dim parBranchID As New OracleParameter("BranchID_", OracleDbType.Varchar2, 7)
            parBranchID.Value = IIf(BranchID = "", DBNull.Value, BranchID.ToString)

            Dim parCreateUserID As New OracleParameter("CreateUserID_", OracleDbType.Int64)
            parCreateUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parCreateDate_vc As New OracleParameter("CreateDate_vc_", OracleDbType.Varchar2, 10)
            parCreateDate_vc.Value = GetDateNow()

            Dim parContractingPartyID As New OracleParameter("ContractingPartyID_", OracleDbType.Int64)
            parContractingPartyID.Direction = ParameterDirection.Output

            Dim strSQL As String = "InsertContractingParty_SP1"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL _
                             , parFirstName_nvc _
                             , parLastName_nvc _
                             , parFatherName_nvc _
                             , parIdentityCertificateNO_nvc _
                             , parNationalCode_nvc _
                             , parGender_bit _
                             , parBirthDate_vc _
                             , parStateID _
                             , parCityID _
                             , parCIdentityTypeID _
                             , parDegreeID _
                             , parTitle_nvc _
                             , parHomeAddress_nvc _
                             , parHomeTel_vc, parMobile_vc _
                             , parEmail_nvc _
                             , parHavingAccount_bit _
                             , parAccountTypeID _
                             , parAccountNO_vc _
                             , parCardNo_vc _
                             , parBranchID _
                             , parCreateUserID _
                             , parCreateDate_vc _
                             , parShabaAccount _
                             , parContractingPartyID)
            Return Convert.ToInt64(parContractingPartyID.Value.ToString)

            '===Thelatest
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertContract_WithRequest() As Int64
        Try
            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            Dim parContractingPartyID As New OracleParameter("ContractingPartyID_", OracleDbType.Int64)
            parContractingPartyID.Value = ContractingPartyID

            Dim parDate_vc As New OracleParameter("Date_vc_", OracleDbType.Varchar2, 10)
            parDate_vc.Value = Date_vc

            Dim parMerchant_vc As New OracleParameter("Merchant_vc_", OracleDbType.Varchar2, 12)
            parMerchant_vc.Value = Merchant_vc

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = SaveDate_vc

            Dim parContractNo_vc As New OracleParameter("ContractNo_vc_", OracleDbType.Varchar2, 20)
            parContractNo_vc.Value = ContractNo_vc

            Dim parMarketingByID As New OracleParameter("MarketingByID_", OracleDbType.Int16)
            parMarketingByID.Value = MarketingByID

            Dim parZoncanNo_nvc As New OracleParameter("ZoncanNo_nvc_", OracleDbType.Varchar2, 50)
            parZoncanNo_nvc.Value = ZoncanNo_nvc

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID()

            Dim parCreateUserID As New OracleParameter("CreateUserID_", OracleDbType.Int64)
            parCreateUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parCreateDate_vc As New OracleParameter("CreateDate_vc_", OracleDbType.Varchar2, 10)
            parCreateDate_vc.Value = GetDateNow()

            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = IIf(RequestID = -1, DBNull.Value, RequestID)

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Direction = ParameterDirection.Output

            Dim strSQL As String = "InsertContract_WithRequest_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parVisitorID, parContractingPartyID, parDate_vc, parMerchant_vc, parSaveDate_vc, parContractNo_vc, parCreateUserID, parMarketingByID, parZoncanNo_nvc, parCreateDate_vc, parContractID, parProjectID, parRequestID)
            Return Convert.ToInt64(parContractID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertContract() As Int64
        Try
            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            Dim parContractingPartyID As New OracleParameter("ContractingPartyID_", OracleDbType.Int64)
            parContractingPartyID.Value = ContractingPartyID

            Dim parDate_vc As New OracleParameter("Date_vc_", OracleDbType.Varchar2, 10)
            parDate_vc.Value = Date_vc

            Dim parMerchant_vc As New OracleParameter("Merchant_vc_", OracleDbType.Varchar2, 12)
            parMerchant_vc.Value = Merchant_vc

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = SaveDate_vc

            Dim parContractNo_vc As New OracleParameter("ContractNo_vc_", OracleDbType.Varchar2, 20)
            parContractNo_vc.Value = ContractNo_vc

            Dim parCreateUserID As New OracleParameter("CreateUserID_", OracleDbType.Int64)
            parCreateUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parMarketingByID As New OracleParameter("MarketingByID_", OracleDbType.Int16)
            parMarketingByID.Value = MarketingByID

            Dim parZoncanNo_nvc As New OracleParameter("ZoncanNo_nvc_", OracleDbType.Varchar2, 50)
            parZoncanNo_nvc.Value = ZoncanNo_nvc

            Dim parCreateDate_vc As New OracleParameter("CreateDate_vc_", OracleDbType.Varchar2, 10)
            parCreateDate_vc.Value = GetDateNow()

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int64)
            parProjectID.Value = ProjectID()

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Direction = ParameterDirection.Output


            Dim strSQL As String = "InsertContract_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parVisitorID, parContractingPartyID, parDate_vc, parMerchant_vc, parSaveDate_vc, parContractNo_vc, parCreateUserID, parMarketingByID, parZoncanNo_nvc, parCreateDate_vc, parProjectID, parContractID)
            Return Convert.ToInt64(parContractID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertAccount() As Int64
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID
            Dim parAccountNO_vc As New OracleParameter("AccountNO_vc_", OracleDbType.Varchar2, 20)
            parAccountNO_vc.Value = IIf(AAccountNO_vc.Trim = "", DBNull.Value, AAccountNO_vc)

            Dim parShabaAccount As New OracleParameter("ShabaAccount_", OracleDbType.Varchar2, 50)
            parShabaAccount.Value = IIf(AShabaAccount.Trim = Nothing, DBNull.Value, AShabaAccount)

            Dim parShabaAccountOld As New OracleParameter("oldshabaaccount_", OracleDbType.Varchar2, 50)
            parShabaAccountOld.Value = IIf(AShabaAccountold.Trim = Nothing, DBNull.Value, AShabaAccountold)

            Dim parCardNo_vc As New OracleParameter("CardNo_vc_", OracleDbType.Varchar2, 20)
            parCardNo_vc.Value = IIf(ACardNo_vc.Trim = "", DBNull.Value, ACardNo_vc)

            Dim parAccountTypeID As New OracleParameter("AccountTypeID_", OracleDbType.Int32)
            parAccountTypeID.Value = IIf(AAccountTypeID = -1, DBNull.Value, AAccountTypeID)

            Dim parBranchID As New OracleParameter("BranchID_", OracleDbType.Varchar2, 7)
            parBranchID.Value = ABranchID

            Dim parIsSenttoshprk As New OracleParameter("issenttoshprk", OracleDbType.Char, 1)
            parIsSenttoshprk.Value = issenttoshprk

            Dim parFinancialSupervisionId As New OracleParameter("FinancialSupervisionId_", OracleDbType.Varchar2, 100)
            parFinancialSupervisionId.Value = AFinancialSupervisionId

            Dim parCreateUserID As New OracleParameter("CreateUserID_", OracleDbType.Int64)
            parCreateUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parCreateDate_vc As New OracleParameter("CreateDate_vc_", OracleDbType.Varchar2, 10)
            parCreateDate_vc.Value = GetDateNow()


            Dim parAccountID As New OracleParameter("AccountID_", OracleDbType.Int64)
            parAccountID.Direction = ParameterDirection.Output

          

            Dim strSQL As String = "InsertAccount_SP1"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL _
                             , parContractID _
                             , parAccountNO_vc _
                             , parCardNo_vc _
                             , parAccountTypeID _
                             , parBranchID _
                             , parCreateUserID _
                             , parCreateDate_vc _
                             , parShabaAccount _
                             , parShabaAccountOld _
                             , parIsSenttoshprk _
                             , parFinancialSupervisionId _
                             , parAccountID)
            Return Convert.ToInt64(parAccountID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertStore() As Int64
        Try
            Dim parSAccountID As New OracleParameter("AccountID_", OracleDbType.Int64)
            parSAccountID.Value = AAccountID

            Dim parSGroupID As New OracleParameter("GroupID_", OracleDbType.Varchar2, 4)
            parSGroupID.Value = SGroupID

            Dim parSLicense As New OracleParameter("LicenseID_", OracleDbType.Varchar2, 10)
            parSLicense.Value = SLicenseID

            Dim parGroupSupplementaryID As New OracleParameter("GroupSupplementaryID_", OracleDbType.Varchar2, 10)
            parGroupSupplementaryID.Value = SSupplementary

            Dim parSStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parSStateID.Value = SStateID

            Dim parSCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parSCityID.Value = SCityID

            Dim parSName_nvc As New OracleParameter("Name_nvc_", OracleDbType.Varchar2, 50)
            parSName_nvc.Value = SName_nvc

            Dim parSPostCode_vc As New OracleParameter("PostCode_vc_", OracleDbType.Varchar2, 10)
            parSPostCode_vc.Value = SPostCode_vc


            Dim parSAddress_nvc As New OracleParameter("address_nvc_", OracleDbType.Varchar2, 500)
            parSAddress_nvc.Value = SAddress_nvc

            Dim parnewSAddress_nvc As New OracleParameter("newaddress_nvc_", OracleDbType.Varchar2, 500)
            parnewSAddress_nvc.Value = newSAddressCode_nvc


            Dim parSTel1_vc As New OracleParameter("Tel1_vc_", OracleDbType.Varchar2, 20)
            parSTel1_vc.Value = STel1_vc

            Dim parSTel2_vc As New OracleParameter("Tel2_vc_", OracleDbType.Varchar2, 20)
            parSTel2_vc.Value = STel2_vc

            Dim parSFax_vc As New OracleParameter("Fax_vc_", OracleDbType.Varchar2, 20)
            parSFax_vc.Value = SFax_vc

            Dim parSMunicipalAreaNO_sint As New OracleParameter("MunicipalAreaNO_sint_", OracleDbType.Int16)
            parSMunicipalAreaNO_sint.Value = SMunicipalAreaNO_sint

            Dim parSEstateConditionID As New OracleParameter("EstateConditionID_", OracleDbType.Int32)
            parSEstateConditionID.Value = IIf(SEstateConditionID = -1, DBNull.Value, SEstateConditionID)

            Dim parSSIdentityTypeID As New OracleParameter("SIdentityTypeID_", OracleDbType.Int32)
            parSSIdentityTypeID.Value = SSIdentityTypeID

            Dim parSSIdentityTypeSDate_vc As New OracleParameter("SIdentityTypeSDate_vc_", OracleDbType.Varchar2, 10)
            parSSIdentityTypeSDate_vc.Value = SSIdentityTypeSDate_vc

            Dim parSSIdentityTypeEDate_vc As New OracleParameter("SIdentityTypeEDate_vc_", OracleDbType.Varchar2, 10)
            parSSIdentityTypeEDate_vc.Value = SSIdentityTypeEDate_vc

            Dim parSDeviceCount_tint As New OracleParameter("DeviceCount_tint_", OracleDbType.Int16)
            parSDeviceCount_tint.Value = SDeviceCount_tint

            Dim parCreateUserID As New OracleParameter("CreateUserID_", OracleDbType.Int64)
            parCreateUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parCreateDate_vc As New OracleParameter("CreateDate_vc_", OracleDbType.Varchar2, 10)
            parCreateDate_vc.Value = GetDateNow()

            Dim parSStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parSStoreID.Direction = ParameterDirection.Output

            Dim parAddress3_nvc As New OracleParameter("address3_nvc_", OracleDbType.Varchar2, 500)
            parAddress3_nvc.Value = Address3_nvc

            Dim parSPosModelID As New OracleParameter("StorePosModelID_", OracleDbType.Int16)
            parSPosModelID.Value = StorePosModelID

            Dim strSQL As String = "InsertStore_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSAccountID, parSGroupID, parSStateID, parSCityID, parSName_nvc, parSPostCode_vc, parSAddress_nvc, parnewSAddress_nvc, parSTel1_vc, parSTel2_vc, parSFax_vc, parSMunicipalAreaNO_sint, parSEstateConditionID, parSSIdentityTypeID, parSSIdentityTypeSDate_vc, parSSIdentityTypeEDate_vc, parSDeviceCount_tint, parCreateUserID, parCreateDate_vc, parAddress3_nvc, parSLicense, parGroupSupplementaryID, parSPosModelID, parSStoreID)
            Return Convert.ToInt64(parSStoreID.Value.ToString)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertDevice() As Int64
        Try
            Dim parSStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parSStoreID.Value = SStoreID

            Dim parDCode_vc As New OracleParameter("Code_vc_", OracleDbType.Varchar2, 8)
            parDCode_vc.Value = DCode_vc

            Dim parDOutlet_vc As New OracleParameter("Outlet_vc_", OracleDbType.Varchar2, 12)
            parDOutlet_vc.Value = DOutlet_vc

            Dim parDVat_vc As New OracleParameter("Vat_vc_", OracleDbType.Varchar2, 15)
            parDVat_vc.Value = DVat_vc

            Dim parDMerchant_vc As New OracleParameter("Merchant_vc_", OracleDbType.Varchar2, 15)
            parDMerchant_vc.Value = DMerchant_vc

            Dim parDPassword_vc As New OracleParameter("Password_vc_", OracleDbType.Varchar2, 20)
            parDPassword_vc.Value = IIf(DPassword_vc.Trim = "", DBNull.Value, DPassword_vc)

            '===Vocher
            Dim parDSwitch_CardAcceptorID_vc As New OracleParameter("Switch_CardAcceptorID_vc_", OracleDbType.Varchar2, 15)
            parDSwitch_CardAcceptorID_vc.Value = DSwitch_CardAcceptorID_vc

            Dim parDSwitch_TerminalID_vc As New OracleParameter("Switch_TerminalID_vc_", OracleDbType.Varchar2, 8)
            parDSwitch_TerminalID_vc.Value = DSwitch_TerminalID_vc



            Dim parDDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDDeviceID.Direction = ParameterDirection.Output

            Dim strSQL As String = "InsertDevice_SP"
            '===Vocher
            'Me.BeginProc()
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSStoreID, parDCode_vc, parDOutlet_vc, parDVat_vc, parDMerchant_vc, parDPassword_vc, parDSwitch_CardAcceptorID_vc, parDSwitch_TerminalID_vc, parDDeviceID)
            Dim val As Int64 = Int64.Parse(parDDeviceID.Value.ToString)
            'Me.EndProc()
            Return val
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertDevicePos() As Int64
        Try
            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DPDeviceID

            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = DPPosID

            Dim parIOTypeID As New OracleParameter("IOTypeID_", OracleDbType.Int16)
            parIOTypeID.Value = DPIOTypeID

            Dim parDevicePosID As New OracleParameter("DevicePosID_", OracleDbType.Int64)
            parDevicePosID.Direction = ParameterDirection.Output

            Dim strSQL As String = "InsertDevicePos_SP"
            'Me.BeginProc()
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDeviceID, parPosID, parIOTypeID, parDevicePosID)

            Dim val As Int64 = Int64.Parse(parDevicePosID.Value.ToString)
            'Me.EndProc()
            Return val
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertDevicePosHistory() As Int64
        Try
            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DPHDeviceID
            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = DPHPosID
            Dim parIOTypeID As New OracleParameter("IOTypeID_", OracleDbType.Int16)
            parIOTypeID.Value = DPHIOTypeID
            Dim parActionDate_vc As New OracleParameter("ActionDate_vc_", OracleDbType.Varchar2, 10)
            parActionDate_vc.Value = DPHActionDate_vc
            Dim parActionDescription_nvc As New OracleParameter("ActionDescription_nvc_", OracleDbType.Varchar2, 500)
            parActionDescription_nvc.Value = DPHActionDescription_nvc
            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = DPHSaveDate_vc
            Dim parSaveUserID As New OracleParameter("SaveUserID_", OracleDbType.Int64)
            parSaveUserID.Value = DPHSaveUserID
            Dim parSaveAgentID As New OracleParameter("SaveAgentID_", OracleDbType.Int64)
            parSaveAgentID.Value = DPHSaveAgentID
            Dim parIFActionIsCanceled_VisitorPayment_bit As New OracleParameter("IFActionIsCanceled_VisitorPayment_bit_", OracleDbType.Int32)
            parIFActionIsCanceled_VisitorPayment_bit.Value = DPHIFActionIsCanceled_VisitorPayment_bit



            Dim parDevicePosHistoryID As New OracleParameter("DevicePosHistoryID_", OracleDbType.Int64)
            parDevicePosHistoryID.Direction = ParameterDirection.Output

            Dim strSQL As String = "InsertDevicePosHistory_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDeviceID, parPosID, parIOTypeID, parActionDate_vc, parActionDescription_nvc, parSaveDate_vc, parSaveUserID, parSaveAgentID, parIFActionIsCanceled_VisitorPayment_bit, parDevicePosHistoryID)
            Return parDevicePosHistoryID.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertPrintLog() As Int64
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = PContractID

            Dim parDeviceCount As New OracleParameter("DeviceCount_", OracleDbType.Int32)
            parDeviceCount.Value = PDeviceCount

            Dim parPrintDate As New OracleParameter("PrintDate_", OracleDbType.Varchar2, 10)
            parPrintDate.Value = PPrintDate

            Dim parPrintTime As New OracleParameter("PrintTime_", OracleDbType.Varchar2, 10)
            parPrintTime.Value = PPrintTime

            Dim parPrintLogID As New OracleParameter("PrintLogID_", OracleDbType.Int64)
            parPrintLogID.Direction = ParameterDirection.Output

            Dim strSQL As String = "InsertPrintLog_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parContractID, parDeviceCount, parPrintDate, parPrintTime, parPrintLogID)
            Return Convert.ToInt64(parPrintLogID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertDeviceCancel() As Int64
        Try
            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DCDeviceID

            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = DCPosID

            Dim parDesc_nvc As New OracleParameter("Desc_nvc_", OracleDbType.Varchar2, 100)
            parDesc_nvc.Value = DCDesc_nvc

            Dim parDate_vc As New OracleParameter("Date_vc_", OracleDbType.Varchar2, 10)
            parDate_vc.Value = DCDate_vc

            Dim parFlag As New OracleParameter("Flag_", OracleDbType.Int16)
            parFlag.Value = DCFlag


            Dim parDeviceCancelID As New OracleParameter("DeviceCancelID_", OracleDbType.Int64)
            parDeviceCancelID.Direction = ParameterDirection.Output


            Dim strSQL As String = "InsertDeviceCancel_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDeviceID, parPosID, parDesc_nvc, parDate_vc, parFlag, parDeviceCancelID)
            Return Convert.ToInt64(parDeviceCancelID.Value.ToString)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertContractCMSProject()
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parCMSProjectID As New OracleParameter("CMSProjectID_", OracleDbType.Int32)
            parCMSProjectID.Value = CMSProjectID

            Dim strSQL As String = "ups_InsertContractCMS"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parContractID, parCMSProjectID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertContractDocImg()
        Try

            Dim parcontractdocimgid As New OracleParameter("contractdocimgid_", OracleDbType.Int64)
            parcontractdocimgid.Direction = ParameterDirection.Output

            Dim parcontractid As New OracleParameter("contractid_", OracleDbType.Int64)
            parcontractid.Value = ContractID

            Dim parimagetypeid As New OracleParameter("imagetypeid_", OracleDbType.Int16)
            parimagetypeid.Value = ImageTypeID

            Dim parimageurl As New OracleParameter("imageurl_vc_", OracleDbType.Varchar2, 2000)
            parimageurl.Value = ImageURL_vc

            Dim parimage As New OracleParameter("image_vb_", OracleDbType.Blob)
            parimage.Value = Image_vb

            Dim parimagedesc As New OracleParameter("imagedesc_vc_", OracleDbType.Varchar2, 2000)
            parimagedesc.Value = ImageDesc_vc

            Dim parattachdate As New OracleParameter("attachdate_vc_", OracleDbType.Varchar2, 20)
            parattachdate.Value = AttachDate_vc

            'Dim parimage As New SqlClient.SqlParameter("@BankConfirm_vb_", SqlDbType.VarBinary)
            'parBankConfirm_vb.Value = IIf(IsNothing(BankConfirm_vb), DBNull.Value, BankConfirm_vb)

            Dim strSQL As String = "InsertContractDocImg_SP"
            'Me.BeginProc()
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parcontractdocimgid, parcontractid, parimagetypeid, parimageurl, parimage, parimagedesc, parattachdate)

            'Me.EndProc()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "Update Methods"
    Public Sub UpdateDeviceCancel(ByVal DeviceCancelID As Int64, ByVal Desc_nvc As String)
        Try
            Dim parDesc_nvc As New OracleParameter("Desc_nvc_", OracleDbType.Varchar2, 100)
            parDesc_nvc.Value = Desc_nvc

            Dim parDeviceCancelID As New OracleParameter("DeviceCancelID_", OracleDbType.Int64)
            parDeviceCancelID.Value = DeviceCancelID

            Dim strSQL As String = "UpdateDeviceCancel_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDesc_nvc, parDeviceCancelID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateDeviceForOnlyDesc(ByVal Desc_nvc As String, ByVal DeviceID As Int64)
        Try
            Dim parDesc_nvc As New OracleParameter("Desc_nvc_", OracleDbType.Varchar2, 100)
            parDesc_nvc.Value = Desc_nvc

            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim strSQL As String = "UpdateDeviceForOnlyDesc_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDesc_nvc, parDeviceID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateCodes_CounterForLastCounter(ByVal LastCounter_vc As String, ByVal ID As Int64)
        Try
            Dim parLastCounter_vc As New OracleParameter("LastCounter_vc_", OracleDbType.Varchar2, 50)
            parLastCounter_vc.Value = LastCounter_vc

            Dim parID As New OracleParameter("ID_", OracleDbType.Int64)
            parID.Value = ID

            Dim strSQL As String = "db_accessadmin.UpdateCodes_CounterForLastCounter_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parLastCounter_vc, parID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateContractForBlock(ByVal ContractID As Int64, ByVal Blocked_bit As Boolean, ByVal BlockedDate_vc As String, ByVal BlockedDesc_vc As String, ByVal BlockedVisitorPayment_bit As Boolean)
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parBlockedDate_vc As New OracleParameter("BlockedDate_vc_", OracleDbType.Varchar2, 10)
            parBlockedDate_vc.Value = IIf(Blocked_bit = True, BlockedDate_vc, DBNull.Value)

            Dim parBlockedDesc_vc As New OracleParameter("BlockedDesc_vc_", OracleDbType.Varchar2, 100)
            parBlockedDesc_vc.Value = IIf(Blocked_bit = True, BlockedDesc_vc, DBNull.Value)

            Dim parBlocked_bit As New OracleParameter("Blocked_bit_", OracleDbType.Int32)
            parBlocked_bit.Value = Blocked_bit

            Dim parBlockedVisitorPayment_bit As New OracleParameter("BlockedVisitorPayment_bit_", OracleDbType.Int32)
            parBlockedVisitorPayment_bit.Value = IIf(Blocked_bit = True, BlockedVisitorPayment_bit, DBNull.Value)


            Dim strSQL As String = "UpdateContractForBlock_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parContractID, parBlockedDate_vc, parBlockedDesc_vc, parBlocked_bit, parBlockedVisitorPayment_bit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateDeviceCancel_OnlySentToAccess(ByVal DeviceCancelID As Int64, ByVal SentToAccess_vc As String)
        Try
            Dim parDeviceCancelID As New OracleParameter("DeviceCancelID_", OracleDbType.Int64)
            parDeviceCancelID.Value = DeviceCancelID

            Dim parSentToAccess_vc As New OracleParameter("SentToAccess_vc_", OracleDbType.Varchar2, 10)
            parSentToAccess_vc.Value = SentToAccess_vc
            'UpdateDeviceCancel_OnlySentToAccess_SP
            Dim strSQL As String = "UpdateDevCan_SentToAccess_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDeviceCancelID, parSentToAccess_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateContractParty()
        Try
            Dim parFirstName_nvc As New OracleParameter("FirstName_nvc_", OracleDbType.Varchar2, 30)
            parFirstName_nvc.Value = FirstName_nvc

            Dim parLastName_nvc As New OracleParameter("LastName_nvc_", OracleDbType.Varchar2, 50)
            parLastName_nvc.Value = LastName_nvc

            Dim parFatherName_nvc As New OracleParameter("FatherName_nvc_", OracleDbType.Varchar2, 30)
            parFatherName_nvc.Value = FatherName_nvc

            Dim parIdentityCertificateNO_nvc As New OracleParameter("IdentityCertificateNO_nvc_", OracleDbType.Varchar2, 12)
            parIdentityCertificateNO_nvc.Value = IdentityCertificateNO_nvc

            Dim parNationalCode_nvc As New OracleParameter("NationalCode_nvc_", OracleDbType.Varchar2, 12)
            parNationalCode_nvc.Value = NationalCode_nvc

            Dim parGender_bit As New OracleParameter("Gender_bit_", OracleDbType.Int32)
            parGender_bit.Value = Gender_bit

            Dim parBirthDate_vc As New OracleParameter("BirthDate_vc_", OracleDbType.Varchar2, 10)
            parBirthDate_vc.Value = BirthDate_vc

            Dim parStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID

            Dim parCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID

            Dim parCIdentityTypeID As New OracleParameter("CIdentityTypeID_", OracleDbType.Int32)
            parCIdentityTypeID.Value = CIdentityTypeID

            Dim parDegreeID As New OracleParameter("DegreeID_", OracleDbType.Int32)
            parDegreeID.Value = IIf(DegreeID = -1, DBNull.Value, DegreeID)

            Dim parTitle_nvc As New OracleParameter("Title_nvc_", OracleDbType.Varchar2, 30)
            parTitle_nvc.Value = Title_nvc

            Dim parHomeAddress_nvc As New OracleParameter("HomeAddress_nvc_", OracleDbType.Varchar2, 500)
            parHomeAddress_nvc.Value = HomeAddress_nvc

            Dim parHomeTel_vc As New OracleParameter("HomeTel_vc_", OracleDbType.Varchar2, 20)
            parHomeTel_vc.Value = HomeTel_vc

            Dim parMobile_vc As New OracleParameter("Mobile_vc_", OracleDbType.Varchar2, 20)
            parMobile_vc.Value = Mobile_vc

            Dim parEmail_nvc As New OracleParameter("Email_nvc_", OracleDbType.Varchar2, 50)
            parEmail_nvc.Value = Email_nvc

            Dim parHavingAccount_bit As New OracleParameter("HavingAccount_bit_", OracleDbType.Int32)
            parHavingAccount_bit.Value = HavingAccount_bit

            Dim parAccountTypeID As New OracleParameter("AccountTypeID_", OracleDbType.Int32)
            parAccountTypeID.Value = IIf(AccountTypeID = -1, DBNull.Value, AccountTypeID)

            Dim parAccountNO_vc As New OracleParameter("AccountNO_vc_", OracleDbType.Varchar2, 20)
            parAccountNO_vc.Value = IIf(AccountNO_vc = "", DBNull.Value, AccountNO_vc)

            Dim parCardNo_vc As New OracleParameter("CardNo_vc_", OracleDbType.Varchar2, 20)
            parCardNo_vc.Value = IIf(CardNo_vc = "", DBNull.Value, CardNo_vc)

            Dim parShabaAccount As New OracleParameter("ShabaAccount_", OracleDbType.Varchar2, 50)
            parShabaAccount.Value = IIf(ShabaAccount = String.Empty, DBNull.Value, ShabaAccount)

            Dim parBranchID As New OracleParameter("BranchID_", OracleDbType.Varchar2, 7)
            parBranchID.Value = IIf(BranchID = "", DBNull.Value, BranchID)

            Dim parModify_UserID As New OracleParameter("Modify_UserID_", OracleDbType.Int64)
            parModify_UserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parModify_Date_vc As New OracleParameter("Modify_Date_vc_", OracleDbType.Varchar2, 10)
            parModify_Date_vc.Value = GetDateNow()


            Dim parContractingPartyID As New OracleParameter("ContractingPartyID_", OracleDbType.Int64)
            parContractingPartyID.Value = ContractingPartyID

            Dim strSQL As String = "UpdateContractingParty_SP1"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL _
                             , parFirstName_nvc _
                             , parLastName_nvc _
                             , parFatherName_nvc _
                             , parIdentityCertificateNO_nvc _
                             , parNationalCode_nvc _
                             , parGender_bit _
                             , parBirthDate_vc _
                             , parStateID _
                             , parCityID _
                             , parCIdentityTypeID _
                             , parDegreeID _
                             , parTitle_nvc _
                             , parHomeAddress_nvc _
                             , parHomeTel_vc _
                             , parMobile_vc _
                             , parEmail_nvc _
                             , parHavingAccount_bit _
                             , parAccountTypeID _
                             , parAccountNO_vc _
                             , parCardNo_vc _
                             , parBranchID _
                             , parModify_UserID _
                             , parModify_Date_vc _
                             , parShabaAccount _
                             , parContractingPartyID)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub UpdateContract_OnlyRequestID()
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parModify_UserID As New OracleParameter("Modify_UserID_", OracleDbType.Int64)
            parModify_UserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parModify_Date_vc As New OracleParameter("Modify_Date_vc_", OracleDbType.Varchar2, 10)
            parModify_Date_vc.Value = GetDateNow()

            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID


            Dim strSQL As String = "UpdateCont_OnlyReqID_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parRequestID, parContractID, parModify_UserID, parModify_Date_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function CanVisitorAssignPosToContract(ByVal ContractID As Int64, ByVal PosSerial As String) As Boolean
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parSerial As New OracleParameter("PosSerial_", OracleDbType.Varchar2)
            parSerial.Value = PosSerial

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "CanVisitorAssignPosToCtract_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parSerial, parRefCursor)

            If (dt.Rows.Count > 0) Then
                Return Convert.ToBoolean(dt.Rows(0).Item(0))
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateContract()
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            Dim parContractingPartyID As New OracleParameter("ContractingPartyID_", OracleDbType.Int64)
            parContractingPartyID.Value = ContractingPartyID

            Dim parDate_vc As New OracleParameter("Date_vc_", OracleDbType.Varchar2, 10)
            parDate_vc.Value = Date_vc

            Dim parMerchant_vc As New OracleParameter("Merchant_vc_", OracleDbType.Varchar2, 12)
            parMerchant_vc.Value = Merchant_vc

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = SaveDate_vc

            Dim parContractNo_vc As New OracleParameter("ContractNo_vc_", OracleDbType.Varchar2, 20)
            parContractNo_vc.Value = ContractNo_vc

            Dim parMarketingByID As New OracleParameter("MarketingByID_", OracleDbType.Int16)
            parMarketingByID.Value = MarketingByID

            Dim parZoncanNo_nvc As New OracleParameter("ZoncanNo_nvc_", OracleDbType.Varchar2, 50)
            parZoncanNo_nvc.Value = ZoncanNo_nvc

            Dim parModify_UserID As New OracleParameter("Modify_UserID_", OracleDbType.Int64)
            parModify_UserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parModify_Date_vc As New OracleParameter("Modify_Date_vc_", OracleDbType.Varchar2, 10)
            parModify_Date_vc.Value = GetDateNow()

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID()



            Dim strSQL As String = "UpdateContract_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parVisitorID, parContractingPartyID, parDate_vc, parMerchant_vc, parSaveDate_vc, parContractNo_vc, parMarketingByID, parZoncanNo_nvc, parModify_UserID, parModify_Date_vc, parProjectID, parContractID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function UpdateAccount() As Int64
        Try
            Dim parAccountID As New OracleParameter("AccountID_", OracleDbType.Int64)
            parAccountID.Value = AAccountID
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID
            Dim parAccountNO_vc As New OracleParameter("AccountNO_vc_", OracleDbType.Varchar2, 20)
            parAccountNO_vc.Value = IIf(AAccountNO_vc.Trim = "", DBNull.Value, AAccountNO_vc)
            Dim parCardNo_vc As New OracleParameter("CardNo_vc_", OracleDbType.Varchar2, 20)
            parCardNo_vc.Value = IIf(ACardNo_vc.Trim = "", DBNull.Value, ACardNo_vc)

            Dim parShabaAccount As New OracleParameter("ShabaAccount_", OracleDbType.Varchar2, 50)
            parShabaAccount.Value = IIf(AShabaAccount.Trim = Nothing, DBNull.Value, AShabaAccount)

            Dim parShabaAccountOld As New OracleParameter("oldshabaaccount_", OracleDbType.Varchar2, 50)
            parShabaAccountOld.Value = IIf(AShabaAccountold.Trim = Nothing, DBNull.Value, AShabaAccountold)

            Dim parAccountTypeID As New OracleParameter("AccountTypeID_", OracleDbType.Int32)
            parAccountTypeID.Value = IIf(AAccountTypeID = -1, DBNull.Value, AAccountTypeID)
            Dim parBranchID As New OracleParameter("BranchID_", OracleDbType.Varchar2, 7)
            parBranchID.Value = ABranchID
            Dim parModify_UserID As New OracleParameter("Modify_UserID_", OracleDbType.Int64)
            parModify_UserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parIsSenttoshprk As New OracleParameter("issenttoshprk", OracleDbType.Varchar2, 3)
            parIsSenttoshprk.Value = issenttoshprk

            Dim parFinancialSupervisionId As New OracleParameter("FinancialSupervisionId_", OracleDbType.Varchar2, 100)
            parFinancialSupervisionId.Value = AFinancialSupervisionId

            Dim parModify_Date_vc As New OracleParameter("Modify_Date_vc_", OracleDbType.Varchar2, 10)
            parModify_Date_vc.Value = GetDateNow()


            Dim strSQL As String = "UpdateAccount_SP1"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL _
                             , parAccountID _
                             , parAccountNO_vc _
                             , parCardNo_vc _
                             , parAccountTypeID _
                             , parBranchID _
                             , parContractID _
                             , parModify_UserID _
                             , parModify_Date_vc _
                             , parShabaAccount _
                             , parShabaAccountOld _
                             , parIsSenttoshprk _
                             , parFinancialSupervisionId)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function UpdateAccountOnlyAccountNOCardNO() As Int64
        Try
            Dim parAccountID As New OracleParameter("AccountID_", OracleDbType.Int64)
            parAccountID.Value = AAccountID
            Dim parAccountNO_vc As New OracleParameter("AccountNO_vc_", OracleDbType.Varchar2, 20)
            If AAccountNO_vc = "" Then
                parAccountNO_vc.Value = DBNull.Value
            Else
                parAccountNO_vc.Value = AAccountNO_vc
            End If
            Dim parCardNo_vc As New OracleParameter("CardNo_vc_", OracleDbType.Varchar2, 20)
            If ACardNo_vc = "" Then
                parCardNo_vc.Value = DBNull.Value
            Else
                parCardNo_vc.Value = ACardNo_vc
            End If
            Dim parModify_UserID As New OracleParameter("Modify_UserID_", OracleDbType.Int64)
            parModify_UserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parModify_Date_vc As New OracleParameter("Modify_Date_vc_", OracleDbType.Varchar2, 10)
            parModify_Date_vc.Value = GetDateNow()

            Dim strSQL As String = "UpdateAccount_OnlyAccountNOCardNO_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parAccountID, parAccountNO_vc, parCardNo_vc, parModify_UserID, parModify_Date_vc)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateStore()
        Try
            Dim parSAccountID As New OracleParameter("AccountID_", OracleDbType.Int64)
            parSAccountID.Value = AAccountID

            Dim parSGroupID As New OracleParameter("GroupID_", OracleDbType.Varchar2, 4)
            parSGroupID.Value = SGroupID

            Dim parSLicense As New OracleParameter("LicenseID_", OracleDbType.Varchar2, 10)
            parSLicense.Value = SLicenseID

            Dim parGroupSupplementaryID As New OracleParameter("GroupSupplementaryID_", OracleDbType.Varchar2, 10)
            parGroupSupplementaryID.Value = SSupplementary

            Dim parSStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parSStateID.Value = SStateID

            Dim parSCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parSCityID.Value = SCityID

            Dim parSName_nvc As New OracleParameter("Name_nvc_", OracleDbType.Varchar2, 50)
            parSName_nvc.Value = SName_nvc

            Dim parSPostCode_vc As New OracleParameter("PostCode_vc_", OracleDbType.Varchar2, 10)
            parSPostCode_vc.Value = SPostCode_vc


            Dim parnewSAddress_nvc As New OracleParameter("newaddress_nvc_", OracleDbType.Varchar2, 500)
            parnewSAddress_nvc.Value = newSAddressCode_nvc

            Dim parSTel1_vc As New OracleParameter("Tel1_vc_", OracleDbType.Varchar2, 20)
            parSTel1_vc.Value = STel1_vc

            Dim parSTel2_vc As New OracleParameter("Tel2_vc_", OracleDbType.Varchar2, 20)
            parSTel2_vc.Value = STel2_vc

            Dim parSFax_vc As New OracleParameter("Fax_vc_", OracleDbType.Varchar2, 20)
            parSFax_vc.Value = SFax_vc

            Dim parSMunicipalAreaNO_sint As New OracleParameter("MunicipalAreaNO_sint_", OracleDbType.Int16)
            parSMunicipalAreaNO_sint.Value = SMunicipalAreaNO_sint

            Dim parSEstateConditionID As New OracleParameter("EstateConditionID_", OracleDbType.Int32)
            parSEstateConditionID.Value = IIf(SEstateConditionID = -1, DBNull.Value, SEstateConditionID)

            Dim parSSIdentityTypeID As New OracleParameter("SIdentityTypeID_", OracleDbType.Int32)
            parSSIdentityTypeID.Value = SSIdentityTypeID

            Dim parSSIdentityTypeSDate_vc As New OracleParameter("SIdentityTypeSDate_vc_", OracleDbType.Varchar2, 10)
            parSSIdentityTypeSDate_vc.Value = SSIdentityTypeSDate_vc

            Dim parSSIdentityTypeEDate_vc As New OracleParameter("SIdentityTypeEDate_vc_", OracleDbType.Varchar2, 10)
            parSSIdentityTypeEDate_vc.Value = SSIdentityTypeEDate_vc

            Dim parSDeviceCount_tint As New OracleParameter("DeviceCount_tint_", OracleDbType.Int16)
            parSDeviceCount_tint.Value = SDeviceCount_tint

            Dim parSStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parSStoreID.Value = SStoreID

            Dim parModify_UserID As New OracleParameter("Modify_UserID_", OracleDbType.Int64)
            parModify_UserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parModify_Date_vc As New OracleParameter("Modify_Date_vc_", OracleDbType.Varchar2, 10)
            parModify_Date_vc.Value = GetDateNow()

            Dim parAddress3_nvc As New OracleParameter("Address3_nvc_", OracleDbType.Varchar2, 500)
            parAddress3_nvc.Value = Address3_nvc

            Dim parSPosModelID As New OracleParameter("StorePosModelID_", OracleDbType.Int16)
            parSPosModelID.Value = StorePosModelID


            Dim strSQL As String = "UpdateStore_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSStoreID, parSGroupID, parSStateID, parSCityID, parSName_nvc, parSPostCode_vc, parnewSAddress_nvc, parSTel1_vc, parSTel2_vc, parSFax_vc, parSMunicipalAreaNO_sint, parSEstateConditionID, parSSIdentityTypeID, parSSIdentityTypeSDate_vc, parSSIdentityTypeEDate_vc, parSDeviceCount_tint, parSAccountID, parModify_UserID, parModify_Date_vc, parAddress3_nvc, parSLicense, parGroupSupplementaryID, parSPosModelID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateDevice()
        Try

            Dim parSStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parSStoreID.Value = SStoreID

            Dim parDCode_vc As New OracleParameter("Code_vc_", OracleDbType.Varchar2, 20)
            parDCode_vc.Value = DCode_vc

            Dim parDOutlet_vc As New OracleParameter("Outlet_vc_", OracleDbType.Varchar2, 12)
            parDOutlet_vc.Value = DOutlet_vc

            Dim parDVat_vc As New OracleParameter("Vat_vc_", OracleDbType.Varchar2, 15)
            parDVat_vc.Value = DVat_vc

            Dim parDMerchant_vc As New OracleParameter("Merchant_vc_", OracleDbType.Varchar2, 15)
            parDMerchant_vc.Value = DMerchant_vc

            Dim parDPassword_vc As New OracleParameter("Password_vc_", OracleDbType.Varchar2, 20)
            parDPassword_vc.Value = DPassword_vc

            Dim parDDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDDeviceID.Value = DDeviceID

            Dim strSQL As String = "UpdateDevice_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSStoreID, parDCode_vc, parDOutlet_vc, parDVat_vc, parDMerchant_vc, parDPassword_vc, parDDeviceID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateDevice_OnlyPosID(ByVal PosID As Int64, ByVal DeviceID As Int64, ByVal IFCanceled_VisitorPayment_bit As Boolean)
        Try
            Dim parDPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            If PosID = 0 Then
                parDPosID.Value = DBNull.Value
            Else
                parDPosID.Value = PosID

            End If
            Dim parDDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDDeviceID.Value = DeviceID



            Dim parDIFCanceled_VisitorPayment_bit As New OracleParameter("IFCanceled_VisitorPayment_bit_", OracleDbType.Int32)
            If PosID = 0 Then
                parDIFCanceled_VisitorPayment_bit.Value = True
            ElseIf PosID = -1 Then
                parDIFCanceled_VisitorPayment_bit.Value = IFCanceled_VisitorPayment_bit
            Else
                parDIFCanceled_VisitorPayment_bit.Value = True
            End If


            Dim strSQL As String = "UpdateDevice_OnlyPosID_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDPosID, parDDeviceID, parDIFCanceled_VisitorPayment_bit)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdatePosOnlyActive(ByVal PosID As Int64, ByVal Active_Tint As Int16)
        Try
            Dim parActive_Tint As New OracleParameter("Active_Tint_", OracleDbType.Int16)
            parActive_Tint.Value = Active_Tint

            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = PosID

            strSQL = "UpdatePosOnlyActive_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parPosID, parActive_Tint)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateContractImportDeviceID(ByVal DeviceID As Int64, ByVal ContractID As Int64)
        Try
            Dim parDeviceID As New OracleParameter("v_deviceID", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim parContractID As New OracleParameter("v_contractID", OracleDbType.Int64)
            parContractID.Value = ContractID

            strSQL = "UpdateContractImportDevicID_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDeviceID, parContractID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateContractImportDeleteAssign(ByVal DeviceID As Int64)
        Try
            Dim parDeviceID As New OracleParameter("v_deviceID", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            strSQL = "UpdateContractImportDelete_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDeviceID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateContractDocImg()
        Try
            Dim parImageTypeID As New OracleParameter("IMAGETYPEID_", OracleDbType.Int64)
            parImageTypeID.Value = ImageTypeID

            Dim parContractDocImgID As New OracleParameter("CONTRACTDOCIMGID_", OracleDbType.Int64)
            parContractDocImgID.Value = ContractDocImgeID

            Dim parImageDesc As New OracleParameter("IMAGEDESC_VC_", OracleDbType.Varchar2, 2000)
            parImageDesc.Value = ImageDesc_vc

            Dim strSQL As String = "UpdateContractDocImg_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parImageTypeID, parContractDocImgID, parImageDesc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region
#Region "Delete Methods"
    Public Sub DeleteCodes_Counter(ByVal ID As Int64)
        Try
            Dim parID As New OracleParameter("ID_", OracleDbType.Int64)
            parID.Value = ID

            strSQL = "DeleteCodes_Counter_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteContractingParty()
        Try
            Dim parContractingPartyID As New OracleParameter("ContractingPartyID_", OracleDbType.Int64)
            parContractingPartyID.Value = ContractingPartyID

            strSQL = "DeleteContractingParty_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parContractingPartyID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteContract()
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            strSQL = "DeleteContract_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parContractID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteAccount()
        Try
            Dim parAccountID As New OracleParameter("AccountID_", OracleDbType.Int64)
            parAccountID.Value = AAccountID

            strSQL = "DeleteAccount_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parAccountID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteStore()
        Try
            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = SStoreID

            strSQL = "DeleteStore_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parStoreID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteDevice()
        Try
            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DDeviceID

            strSQL = "DeleteDevice_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDeviceID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteDevicePos()
        Try
            Dim parDevicePosID As New OracleParameter("DevicePosID_", OracleDbType.Int64)
            parDevicePosID.Value = DPDevicePosID

            strSQL = "DeleteDevicePos_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDevicePosID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteContractCMSProject()
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID
            Dim strSQL As String = "usp_DeleteContractCMS"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parContractID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub DeleteContractDocImg()
        Try
            Dim parContractDocImgID As New OracleParameter("CONTRACTDOCIMGID_", OracleDbType.Int64)
            parContractDocImgID.Value = ContractDocImgeID


            strSQL = "DeleteContractDocImg_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parContractDocImgID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Friend Function GetAllMarketingBy() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "GetAllMarketingBy_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Friend Function GetByEniacCode_vcContractingParty_Contract_Account_Store_Device_Pos(ByVal EniacCode As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parEniacCode As New OracleParameter("EniacCode_vc_", OracleDbType.Varchar2, 20)
            parEniacCode.Value = EniacCode

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'strSQL = "GetByEniacCode_vcContractingParty_Contract_Account_Store_Device_Pos_SP"
            strSQL = "GtByEnCodCntPrtCntAccStrDvcPSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parEniacCode, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''Raeisi
    Friend Function GetByDDeviceid_ContractingParty_Contract_Account_Store_Device_Pos(ByVal Deviceid As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parDeviceid As New OracleParameter("Deviceid_", OracleDbType.Varchar2, 20)
            parDeviceid.Value = Deviceid

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'strSQL = "GetByEniacCode_vcContractingParty_Contract_Account_Store_Device_Pos_SP"
            strSQL = "GtByDvcidCntPrtCntAccStrDvcPSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDeviceid, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CanThisAccountChangeManually(ByVal AccountID As Int64) As Boolean
        Try
            CanThisAccountChangeManually = False

            Dim dt As New DataTable

            Dim parAccountID As New OracleParameter("AccountID_", OracleDbType.Int64)
            parAccountID.Value = AccountID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)

            strSQL = "CanThisAccountBeChanged_SP"

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parAccountID, parRefCursor)

            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("res") = 0 Then
                    CanThisAccountChangeManually = True
                Else
                    CanThisAccountChangeManually = False
                End If
            Else
                CanThisAccountChangeManually = False
            End If
        Catch ex As Exception
            CanThisAccountChangeManually = False
            Throw ex
        End Try
    End Function
    Public Function getmeli() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "select distinct NationalCode_nvc,c.ContractID,a.accountID,s.Name_nvc,s.Tel1_vc,s.StoreID from dbo.ContractingParty_T cp inner join dbo.Contract_T c on  cp.ContractingPartyID=c.ContractingPartyID left join dbo.Account_T a on a.Contractid=c.Contractid left join dbo.Store_T s on s.accountid=a.accountid"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateVisitorID(ByVal ContractID As Int64, ByVal VisitorID As Int64)
        Try

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int64)
            parVisitorID.Value = VisitorID



            Dim strSQL As String = "UpdateContract_Visitor_SP"
            Execute_NonQuery(CommandType.StoreProcedure, strSQL, parContractID, parVisitorID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetContract_ContractingParty_By_VisitorAndDate(ByVal VisitorID As Int64, ByVal Date_vc As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int64)
            parVisitorID.Value = VisitorID


            Dim parDate As New OracleParameter("Date_", OracleDbType.Varchar2, 10)
            parDate.Value = Date_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            ''GetContractInformation_BY_VisitorID_Date_SP
            strSQL = "GetContifor_BY_VstrID_Date_SP"
            Fill(CommandType.StoreProcedure, strSQL, dt, parVisitorID, parDate, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "VoucherSwitch"
    Public Function GetByDOutletContractingParty_Contract_Account_Store_Device(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parOutlet_vc As New OracleParameter("Outlet_vc_", OracleDbType.Varchar2, 12)
            parOutlet_vc.Value = DOutlet_vc
            'reza
            'Dim parVisitorId As New OracleParameter("VisitorId_", OracleDbType.Int32, 12)
            'parVisitorId.Value = VisitorID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            ''GetByDOutletContractingParty_Contract_Account_Store_Device_SP
            strSQL = "GetByDOutletContParty_details"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parOutlet_vc, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByStoreIDCardAcceptorID(ByVal StoreID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = StoreID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByStoreIDCardAcceptorID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parStoreID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByStorIDArianaCrdAcptoID(ByVal StoreID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = StoreID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByStorIDArianaCrdAcptoID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parStoreID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetByStoreIDCardAcceptorIDSina(ByVal StoreID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = StoreID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'GetByStoreIDCardAcceptorIDSina_SP
            strSQL = "GetByStoreIDCardAcptrIDSina_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parStoreID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByStoreIDCMSMerchant(ByVal StoreID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            parStoreID.Value = StoreID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "GetByStoreIDCMSMerhcant_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parStoreID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCardAcceptorIDByTheLastOne() As String
        Try
            Dim CardAcceptorID As String

            Dim CodeFirstPart As String = "MERCHANT"

            Dim Counter As Int32
            Dim strCounter As String

            Dim dtCardAcceptorID_Counter As New DataTable
            dtCardAcceptorID_Counter = Me.GetTheLatestSwitchCardAcceptorID()
            If dtCardAcceptorID_Counter.Rows.Count = 0 Then
                strCounter = "1800001"
                CardAcceptorID = CodeFirstPart & strCounter
                Return CardAcceptorID
            ElseIf dtCardAcceptorID_Counter.Rows.Count = 1 Then
                Counter = Convert.ToInt64(dtCardAcceptorID_Counter.Rows(0).Item(0)) + 1
                strCounter = Microsoft.VisualBasic.Right("0000000" & Counter, 7)

                CardAcceptorID = CodeFirstPart & strCounter
                Return CardAcceptorID
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetCMSCardAcceptorIDByTheLastOne() As String
        Try
            Dim CardAcceptorID As String

            Dim CodeFirstPart As String = "MERCHANT"

            Dim Counter As Int32
            Dim strCounter As String

            Dim dtCardAcceptorID_Counter As New DataTable
            dtCardAcceptorID_Counter = Me.GetTheLatestSwitch_CMSCardAcceptorID()
            If dtCardAcceptorID_Counter.Rows.Count = 0 Then
                strCounter = "9900001"
                CardAcceptorID = CodeFirstPart & strCounter
                Return CardAcceptorID
            ElseIf dtCardAcceptorID_Counter.Rows.Count = 1 Then
                Counter = Convert.ToInt64(dtCardAcceptorID_Counter.Rows(0).Item(0)) + 1
                strCounter = Microsoft.VisualBasic.Right("0000000" & Counter, 7)

                CardAcceptorID = CodeFirstPart & strCounter
                Return CardAcceptorID
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetTerminalIDByTheLastOne() As String

        Try
            Dim TerminalID As String

            Dim CodeFirstPart As String = "L"

            Dim Counter As Int32
            Dim strCounter As String

            Dim dtCardAcceptorID_Counter As New DataTable
            dtCardAcceptorID_Counter = Me.GetTheLatestSwitchTerminalID()
            If dtCardAcceptorID_Counter.Rows.Count = 0 Then
                strCounter = "1800001"
                TerminalID = CodeFirstPart & strCounter
                Return TerminalID
            ElseIf dtCardAcceptorID_Counter.Rows.Count = 1 Then
                Counter = Convert.ToInt64(dtCardAcceptorID_Counter.Rows(0).Item(0)) + 1
                strCounter = Microsoft.VisualBasic.Right("0000000" & Counter, 7)

                TerminalID = CodeFirstPart & strCounter
                Return TerminalID
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetCMSTerminalIDByTheLastOne() As String

        Try
            Dim TerminalID As String

            Dim CodeFirstPart As String = "P"

            Dim Counter As Int32
            Dim strCounter As String

            Dim dtCardAcceptorID_Counter As New DataTable
            dtCardAcceptorID_Counter = Me.GetTheLatestSwitchCMSTerminalID()
            If dtCardAcceptorID_Counter.Rows.Count = 0 Then
                strCounter = "9900001"
                TerminalID = CodeFirstPart & strCounter
                Return TerminalID
            ElseIf dtCardAcceptorID_Counter.Rows.Count = 1 Then
                Counter = Convert.ToInt64(dtCardAcceptorID_Counter.Rows(0).Item(0)) + 1
                strCounter = Microsoft.VisualBasic.Right("0000000" & Counter, 7)

                TerminalID = CodeFirstPart & strCounter
                Return TerminalID
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub UpdateDevice_CardAcceptorIDAndTerminalIDAndOtherCodes()
        Try

            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DDeviceID

            Dim parSwitch_CardAcceptorID As New OracleParameter("Switch_CardAcceptorID_vc_", OracleDbType.Varchar2, 15)
            parSwitch_CardAcceptorID.Value = DSwitch_CardAcceptorID_vc

            Dim parSwitch_TerminalID As New OracleParameter("Switch_TerminalID_vc_", OracleDbType.Varchar2, 100)
            parSwitch_TerminalID.Value = DSwitch_TerminalID_vc
            'UpdateDevice_CardAcceptorIDAndTerminalIDAndOtherCodes_SP
            Dim strSQL As String = "UpdateDev_CrdAcptrID_TermID_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_CardAcceptorID, parSwitch_TerminalID, parDeviceID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Public Sub UpdateDevice_AfterSendToSina()
    '    Try
    '        Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
    '        parDeviceID.Value = DDeviceID
    '        'UpdateDevice_AfterSendToSina_SP
    '        Dim strSQL As String = "UpdateDev_AfterSendToSina_SP"
    '        Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDeviceID)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Public Sub UpdateDevice_CMSOutletAndMerchant()
        Try
            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DDeviceID

            Dim parSwitch_CardAcceptorID As New OracleParameter("Switch_CardAcceptorID_vc_", OracleDbType.Varchar2, 15)
            parSwitch_CardAcceptorID.Value = DSwitch_CardAcceptorID_vc

            Dim parSwitch_TerminalID As New OracleParameter("Switch_TerminalID_vc_", OracleDbType.Varchar2, 100)
            parSwitch_TerminalID.Value = DSwitch_TerminalID_vc

            Dim strSQL As String = "UpdateDevice_CMSOutletAndMerchant_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_CardAcceptorID, parSwitch_TerminalID, parDeviceID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDevice_OnlySwitch_FeeID()
        Try
            Dim parSwitch_CardAcceptorID As New OracleParameter("Switch_CardAcceptorID_vc_", OracleDbType.Varchar2, 15)
            parSwitch_CardAcceptorID.Value = DSwitch_CardAcceptorID_vc

            Dim parSwitch_FeeID_int As New OracleParameter("Switch_FeeID_int_", OracleDbType.Int32)
            parSwitch_FeeID_int.Value = DSwitch_FeeID_int

            Dim strSQL As String = "UpdateDevice_Swtch_FeeID_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_CardAcceptorID, parSwitch_FeeID_int)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertSwitch_Fee_History(ByVal Switch_CardAcceptorID_vc As String, ByVal Switch_FeeID_int As Int32, ByVal Switch_FeeTime_vc As String, ByVal UserID As Int64)
        Try


            Dim parSwitch_CardAcceptorID As New OracleParameter("Switch_CardAcceptorID_vc_", OracleDbType.Varchar2, 15)
            parSwitch_CardAcceptorID.Value = Switch_CardAcceptorID_vc

            Dim parSwitch_FeeID_int As New OracleParameter("Switch_FeeID_int_", OracleDbType.Int32)
            parSwitch_FeeID_int.Value = Switch_FeeID_int


            Dim parSwitch_FeeTime_vc As New OracleParameter("Switch_FeeTime_vc_", OracleDbType.Varchar2, 5)
            parSwitch_FeeTime_vc.Value = Switch_FeeTime_vc


            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            Dim strSQL As String = "InsertSwitch_Fee_History_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_CardAcceptorID, parSwitch_FeeID_int, parSwitch_FeeTime_vc, parUserID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetAllCardAcceptorInfo(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllCardAcceptorInfo_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllCardAcceptorInfo_ForPaymentMethodType() As DataTable
        Try
            Dim dt As New DataTable

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'GetAllCardAcceptorInfo_ForPaymentMethodType_SP
            strSQL = "GetAllCrdAcotrInf_PayMetTyp_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllContractInfo(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            strSQL = "GetAllContractInfo_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByContractIDAllCardAcceptor(ByVal ContractID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            strSQL = "GetByContractIDAllCardAcceptor_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContractID, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateContract_OnlyFeeSchema(ByVal ContractID As Int64, ByVal Switch_FeeID_int As Int32)
        Try



            Dim parSwitch_FeeID_int As New OracleParameter("Switch_FeeID_int_", OracleDbType.Int32)
            parSwitch_FeeID_int.Value = Switch_FeeID_int



            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim strSQL As String = "UpdateContract_OnlyFeeSchema_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_FeeID_int, parContractID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "TMS" '---For transaction
    Public Sub ForTMS_TMSTerminal_Insert3(ByVal TERMINAL_ID As String, ByVal SIGNATURE As String, ByVal NAME As String, ByVal REGISTRATION_DATE As DateTime, ByVal TYPE As String, ByVal STATUS As Int32, ByVal CATEGORY As Int32, ByVal DESCRIPTION As String, ByVal PARENT_ID As String, ByVal COMMS As String)
        Try
            Dim parTERMINAL_ID As New OracleParameter("TERMINAL_ID_", OracleDbType.Varchar2)
            parTERMINAL_ID.Value = TERMINAL_ID
            Dim parSIGNATURE As New OracleParameter("SIGNATURE_", OracleDbType.Varchar2)
            parSIGNATURE.Value = SIGNATURE
            Dim parNAME As New OracleParameter("NAME_", OracleDbType.Varchar2)
            parNAME.Value = NAME
            Dim parREGISTRATION_DATE As New OracleParameter("REGISTRATION_DATE_", SqlDbType.DateTime)
            parREGISTRATION_DATE.Value = REGISTRATION_DATE
            Dim parTYPE As New OracleParameter("TYPE_", OracleDbType.Varchar2)
            parTYPE.Value = TYPE
            Dim parSTATUS As New OracleParameter("STATUS_", OracleDbType.Int32)
            parSTATUS.Value = STATUS
            Dim parCATEGORY As New OracleParameter("CATEGORY_", OracleDbType.Int32)
            parCATEGORY.Value = CATEGORY
            Dim parDESCRIPTION As New OracleParameter("DESCRIPTION_", OracleDbType.Varchar2)
            parDESCRIPTION.Value = DESCRIPTION
            Dim parPARENT_ID As New OracleParameter("PARENT_ID_", OracleDbType.Varchar2)
            parPARENT_ID.Value = PARENT_ID
            Dim parCOMMS As New OracleParameter("COMMS_", OracleDbType.Varchar2)
            parCOMMS.Value = COMMS


            Me.Execute_NonQuery(CommandType.StoreProcedure, "ForTMS_TMSTerminal_Insert3", parTERMINAL_ID, parSIGNATURE, parNAME, parREGISTRATION_DATE, parTYPE, parSTATUS, parCATEGORY, parDESCRIPTION, parPARENT_ID, parCOMMS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ForTMS_TMSTerminal_Update_ByTerminalID(ByVal TERMINAL_ID As String, ByVal REGISTRATION_DATE As DateTime, ByVal PARENT_ID As String)
        Try
            Dim parTERMINAL_ID As New OracleParameter("TERMINAL_ID_", OracleDbType.Varchar2)
            parTERMINAL_ID.Value = TERMINAL_ID
            Dim parREGISTRATION_DATE As New OracleParameter("REGISTRATION_DATE_", SqlDbType.DateTime)
            parREGISTRATION_DATE.Value = REGISTRATION_DATE
            Dim parPARENT_ID As New OracleParameter("PARENT_ID_", OracleDbType.Varchar2)
            parPARENT_ID.Value = PARENT_ID


            Me.Execute_NonQuery(CommandType.StoreProcedure, "ForTMS_TMSTerminal_Update_ByTerminalID", parTERMINAL_ID, parREGISTRATION_DATE, parPARENT_ID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ForTMS_TMSTerminal_MAXTerminalID() As DataTable
        Try
            Dim dt As New DataTable


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_MAXTerminalID", dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_TMSTerminal_GetBySerail(ByVal SIGNATURE As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSIGNATURE As New OracleParameter("SIGNATURE_", OracleDbType.Varchar2)
            parSIGNATURE.Value = SIGNATURE


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_GetBySerail", dt, parSIGNATURE)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_TMSTerminal_GetByCityID(ByVal SIGNATURE As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSIGNATURE As New OracleParameter("SIGNATURE_", OracleDbType.Varchar2, 50)
            parSIGNATURE.Value = SIGNATURE


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_GetByCityID", dt, parSIGNATURE)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_GetInfoBySerial_SP(ByVal Serial_vc As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSerial_vc As New OracleParameter("Serial_vc_", OracleDbType.Varchar2)
            parSerial_vc.Value = Serial_vc


            Me.Fill(CommandType.StoreProcedure, "ForTMS_GetInfoBySerial_SP", dt, parSerial_vc)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
    Public Sub UpdateDevice_AfterSendToSina()
        Try

            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DDeviceID
            'UpdateDevice_AfterSendToSina_SP
            Dim strSQL As String = "UpdateDev_AfterSendToSina_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parDeviceID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDevice_OnlySwitch_PaymentMethodType(ByVal Switch_CardAcceptorID_vc As String, ByVal Switch_PaymentMethodType As Int32)
        Try
            Dim parSwitch_CardAcceptorID_vc As New OracleParameter("Switch_CardAcceptorID_vc_", OracleDbType.Varchar2, 15)
            parSwitch_CardAcceptorID_vc.Value = Switch_CardAcceptorID_vc

            Dim parSwitch_PaymentMethodType As New OracleParameter("Switch_PaymentMethodType_", OracleDbType.Int32)
            parSwitch_PaymentMethodType.Value = Switch_PaymentMethodType
            'UpdateDeviceOnlySwitch_PaymentMethodType_SP
            strSQL = "UpdateDev_Switch_PaymMetTyp_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parSwitch_CardAcceptorID_vc, parSwitch_PaymentMethodType)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub TransferContract(ByVal ContractID As Int64, ByVal ProjectID As Int32)
        Try
            BeginProc()
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.IsNullable = False
            parContractID.Value = ContractID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parContractID.IsNullable = False
            parProjectID.Value = ProjectID

            strSQL = "TransferContract_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parContractID, parProjectID)
            EndProc()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateContractByState_Management_City_Visitor(ByVal StateID As String, ByVal CityID As String, ByVal ManagementID As String, ByVal VisitorID As Int32, ByVal DestVisitorID As Int32)
        Try
            Dim parStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID
            Dim parCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID
            Dim parManagementID As New OracleParameter("ManagementID_", OracleDbType.Varchar2, 50)
            parManagementID.Value = ManagementID
            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parDestVisitorID As New OracleParameter("DestVisitorID_", OracleDbType.Int32)
            parDestVisitorID.Value = DestVisitorID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int16)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID



            'UpdateContractByState_Management_City_Visitor_SP
            strSQL = "UpdateCont_ByState_Mngmnt_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parStateID, parCityID, parManagementID, parVisitorID, parDestVisitorID, parProjectID, parUserID)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ChangeContractOfRequest(ByVal OldContractID As Int64, ByVal NewContractID As Int64, ByVal RequestID As Int64)
        Try
            Dim parOldContractID As New OracleParameter("OldContractID_", OracleDbType.Int64)
            parOldContractID.Value = OldContractID
            Dim parNewContractID As New OracleParameter("NewContractID_", OracleDbType.Int64)
            parNewContractID.Value = NewContractID
            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID

            strSQL = "ChangeContractOfRequest_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parOldContractID, parNewContractID, parRequestID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateReuest_RequestStatusAndDuplicateRequestID(ByVal RequestID As Int64, ByVal RequestStatusID As Int16, ByVal DuplicateRequestID As Int64)
        Try
            Dim parRequestID As New OracleParameter("RequestID_", OracleDbType.Int64)
            parRequestID.Value = RequestID
            Dim parRequestStatusID As New OracleParameter("RequestStatusID_", OracleDbType.Int16)
            parRequestStatusID.Value = RequestStatusID
            Dim parDuplicateRequestID As New OracleParameter("DuplicateRequestID_", OracleDbType.Int64)
            parDuplicateRequestID.Value = IIf(DuplicateRequestID = -1, DBNull.Value, DuplicateRequestID)

            Dim parModifyDate_vc As New OracleParameter("ModifyDate_vc_", OracleDbType.Varchar2, 10)
            parModifyDate_vc.Value = GetDateNow()
            Dim parModifyUserID As New OracleParameter("ModifyUserID_", OracleDbType.Int64)
            parModifyUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID


            strSQL = "UpdateReuest_RequestStatusAndDuplicateRequestID_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parRequestID, parRequestStatusID, parDuplicateRequestID, parModifyDate_vc, parModifyUserID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetByContractIDAccount(ByVal CID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContracTID As New OracleParameter("ContracTID_", OracleDbType.Int64)
            parContracTID.Value = CID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByContractIDAccount_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContracTID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByContractIDAndAccountNoAccount(ByVal ContractID As Int64, ByVal AccountNo As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parContracTID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContracTID.Value = ContractID
            Dim parAccountNo As New OracleParameter("AccountNo_", OracleDbType.Varchar2, 20)
            parAccountNo.Value = AccountNo

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "GetByContractIDAndAccNoAcc"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parContracTID, parAccountNo, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   
    Public Function GetContractDeviceStatus(ByVal ContractID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim ParContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            ParContractID.Value = ContractID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByContractId_PosId_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, ParContractID, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetOneStore(ByVal StoreID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim ParStoreID As New OracleParameter("StoreID_", OracleDbType.Int64)
            ParStoreID.Value = StoreID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByStoreId_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, ParStoreID, parRefCursor)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllImageTypes() As DataTable
        Try
            Dim dt As New DataTable

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllImagetypes_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetAllContractDocImg() As DataTable
        Try
            Dim dt As New DataTable

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllContractDocImg_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDocImgByContractID() As DataTable
        Try
            Dim dt As New DataTable

            Dim ParContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            ParContractID.Value = ContractID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetDocImgByContractID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, ParContractID, parRefCursor)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetAllContractHasDocImg() As DataTable
        Try
            Dim dt As New DataTable

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllContractHasDocImg_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parRefCursor)

            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Updateqrcodestatus(ByVal outlet_vc As String, ByVal qrcodestatus As Int16)
        Try
            Dim parOutlet As New OracleParameter("Outlet_vc_", OracleDbType.Varchar2)
            parOutlet.Value = outlet_vc

            Dim parqrcodestatus As New OracleParameter("qrcodestatus_", OracleDbType.Int16)
            parqrcodestatus.Value = qrcodestatus

            strSQL = "UpdateDevice_QrCodeStatus_SP"

            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parOutlet, parqrcodestatus)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetAllContractingPartyInfo(ByVal ProjectID As Int16, ByVal cmsProjectID As Int16, ByVal userID As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parCMSProjectID As New OracleParameter("cmsProjectID_", OracleDbType.Int32)
            parCMSProjectID.Value = CMSProjectID

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            parUserID.Value = userID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Dim strSQL As String = "GETALLCONTRACTINGPARTYSINFO_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parProjectID, parCMSProjectID, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

