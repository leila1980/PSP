Imports Oracle.DataAccess.Client

Public Class ClassDALContractimport

#Region "Declare"

    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    Private dt As New DataTable

    Private mvarContractimportID As Int64
    Private mvarImportDate_vc As String
    Private mvarContractID As Int64
    Private mvarMerchant_vc As String
    Private mvarOutlet_vc As String

    Public Property ContractimportID() As Int64
        Get
            Return mvarContractimportID
        End Get
        Set(ByVal value As Int64)
            mvarContractimportID = value
        End Set
    End Property

    Public Property ImportDate_vc() As String
        Get
            Return mvarImportDate_vc
        End Get
        Set(ByVal value As String)
            mvarImportDate_vc = value
        End Set
    End Property

    Public Property ContractID As Int64
        Get
            Return mvarContractID
        End Get
        Set(ByVal value As Int64)
            mvarContractID = value
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
   
#End Region
#Region "Function"

    Public Function GetContractImportByDeviceID(ByVal DEVICEID As Int64) As DataTable
        Try
            Dim dtDEVICEID As New DataTable

            Dim parDEVICEID As New OracleParameter("DEVICEID_", OracleDbType.Int64)
            parDEVICEID.Value = DEVICEID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetContractImportByDeviceID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtDEVICEID, parDEVICEID, parRefCursor)
            Return dtDEVICEID
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Insert() As Int64
        Try

            Dim parImportDate_vc As New OracleParameter("ImportDate_vc_", OracleDbType.Varchar2, 10)
            parImportDate_vc.Value = GetDateNow()

            Dim parImportUserID As New OracleParameter("ImportUserID_", OracleDbType.Int64)
            parImportUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parMerchant_vc As New OracleParameter("Merchant_vc", OracleDbType.Varchar2, 20)
            parMerchant_vc.Value = Merchant_vc

            Dim parOutlet_vc As New OracleParameter("Outlet_vc", OracleDbType.Varchar2, 20)
            parOutlet_vc.Value = Outlet_vc

            Dim parContractImportID As New OracleParameter("ContractImportID_", OracleDbType.Int64)
            parContractImportID.Direction = ParameterDirection.Output


            strSQL = "InsertContractImport_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL _
                             , parImportDate_vc _
                             , parImportUserID _
                             , parContractID _
                             , parMerchant_vc _
                             , parOutlet_vc _
                             , parContractImportID
                             )

            Return Convert.ToInt64(parContractImportID.Value.ToString())
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByContractIDContractImport() As DataTable
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = Me.ContractID

            dt.Clear()
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Me.Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, "GetContractImportBy_SP", dt, parContractID, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByMerchantContractImport() As DataTable
        Try
            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = Me.ContractID

            Dim parMerchant As New OracleParameter("Merchant_", OracleDbType.Varchar2)
            parMerchant.Value = Me.Merchant_vc

            Dim parOutlet As New OracleParameter("Outlet_", OracleDbType.Varchar2)
            parOutlet.Value = Me.Outlet_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            dt.Clear()
            Me.Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, "GetContractImportRepet_SP", dt, parContractID, parMerchant, parOutlet, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
