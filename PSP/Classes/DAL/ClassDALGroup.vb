Imports Oracle.DataAccess.Client

Public Class ClassDALGroup
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    Private dtGroup As New DataTable

    Private mvarGroupID As String
    Private mvarName_nvc As String
    Private mvarshaparakcode_vc As String
    Private mvarShaparakNO As String

    Private mvarLicenseID As String
    Private mvarLicenseName_nvc As String

    Private mvarGroupSupplementaryID As String
    Private mvarSupplementaryname As String


    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"

#Region "Property ContractDocImg"
    Public Property GroupID() As String
        Get
            Return mvarGroupID
        End Get
        Set(ByVal value As String)
            mvarGroupID = value
        End Set
    End Property
    Public Property Name_nvc() As String
        Get
            Return mvarName_nvc
        End Get
        Set(ByVal value As String)
            mvarName_nvc = value
        End Set
    End Property


    Public Property shaparakNo() As String
        Get
            Return mvarShaparakNO
        End Get
        Set(ByVal value As String)
            mvarShaparakNO = value
        End Set
    End Property

    Public Property shaparakcode_vc() As String
        Get
            Return mvarshaparakcode_vc
        End Get
        Set(ByVal value As String)
            mvarshaparakcode_vc = value
        End Set
    End Property
#End Region

#Region "Property License"

    Public Property LicenseID
        Get
            Return mvarLicenseID
        End Get
        Set(ByVal value)
            mvarLicenseID = value
        End Set
    End Property

    Public Property LicenseName
        Get
            Return mvarLicenseName_nvc
        End Get
        Set(ByVal value)
            mvarLicenseName_nvc = value
        End Set
    End Property

#End Region

#Region "Property GroupSupplementary"

    Public Property GroupSupplementaryID
        Get
            Return mvarGroupSupplementaryID
        End Get
        Set(ByVal value)
            mvarGroupSupplementaryID = value
        End Set
    End Property

    Public Property SupplementaryName
        Get
            Return mvarSupplementaryname
        End Get
        Set(ByVal value)
            mvarSupplementaryname = value
        End Set
    End Property

#End Region


#End Region
#Region "Methods"
    Public Function GetAll() As DataTable
        Try
            Dim dtGroup As New DataTable

            strSQL = "GetAllGroup_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtGroup, parRefCursor)
            Return dtGroup
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetOneByID()
        Try
            Dim dtshaparakcode_vc As New DataTable

            Dim parshaparakcode_vc As New OracleParameter("@shaparakcode_vc", OracleDbType.Varchar2, 4)
            parshaparakcode_vc.Value = shaparakcode_vc
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)

            strSQL = "GetOneByIDshaparakcode_vc_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtshaparakcode_vc, parshaparakcode_vc, parRefCursor)
            Return dtshaparakcode_vc
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByID() As DataTable
        Try
            Dim dtGroup As New DataTable

            Dim parGroupID As New OracleParameter("@GroupID", OracleDbType.Varchar2, 4)
            parGroupID.Value = GroupID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)

            strSQL = "GetByIDGroup_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtGroup, parGroupID, parRefCursor)
            Return dtGroup
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Insert()
        Try
            Dim parGroupID As New OracleParameter("@GroupID", OracleDbType.Varchar2, 4)
            parGroupID.Value = GroupID

            Dim parShaparakNo As New OracleParameter("@ShaparakNO", OracleDbType.Varchar2, 4)
            If IsDBNull(shaparakNo) = False Then
                parShaparakNo.Value = shaparakNo
            Else
                parShaparakNo.Value = DBNull.Value
            End If


            Dim parName_nvc As New OracleParameter("@Name_nvc", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc

            strSQL = "InsertGroup_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parGroupID, parName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update()
        Try
            Dim parGroupID As New OracleParameter("@GroupID", OracleDbType.Varchar2, 4)
            parGroupID.Value = GroupID
            Dim parName_nvc As New OracleParameter("@Name_nvc", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc

            strSQL = "UpdateGroup_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parGroupID, parName_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim parGroupID As New OracleParameter("@GroupID", OracleDbType.Varchar2, 4)
            parGroupID.Value = GroupID

            strSQL = "DeleteGroup_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parGroupID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetByMappingCodeGroupID(ByVal MappingCode_vc As String) As String
        Try
            Dim parMappingCode_vc As New OracleParameter("@MappingCode_vc", OracleDbType.Varchar2, 10)
            parMappingCode_vc.Value = MappingCode_vc

            strSQL = "GetByMappingCodeGroup_SP"
            dtGroup.Clear()
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtGroup, parMappingCode_vc)
            If dtGroup.Rows.Count = 1 Then
                Return dtGroup.Rows(0).Item("GroupID").ToString
            Else
                Throw New Exception("Problem with finding GroupMappingCode=" & MappingCode_vc)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetAllLicenseByGroupID() As DataTable
        Try
            Dim dtGroup As New DataTable

            strSQL = "GetAllLicenseByGroupID_SP"

            Dim parGroupID As New OracleParameter("@GroupID", OracleDbType.Varchar2, 4)
            parGroupID.Value = GroupID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtGroup, parGroupID, parRefCursor)
            Return dtGroup
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetAllSupplementaryByGroupID() As DataTable
        Try
            Dim dtGroup As New DataTable

            strSQL = "GetAllSupplementaryBy_SP"

            Dim parGroupID As New OracleParameter("@GroupID", OracleDbType.Varchar2, 4)
            parGroupID.Value = GroupID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtGroup, parGroupID, parRefCursor)
            Return dtGroup
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
