Imports Oracle.DataAccess.Client
Public Class ClassDALInstaller
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarInstallerID As Int64
    Private mvarFirstName_nvc As String
    Private mvarLastName_nvc As String
    Private mvarTel_vc As String
    Private mvarMobile_vc As String
    Private mvarAddress_nvc As String

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"
    Public Property InstallerID() As Int64
        Get
            Return mvarInstallerID
        End Get
        Set(ByVal value As Int64)
            mvarInstallerID = value
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
    Public Property Tel_vc() As String
        Get
            Return mvarTel_vc
        End Get
        Set(ByVal value As String)
            mvarTel_vc = value
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
    Public Property Address_nvc() As String
        Get
            Return mvarAddress_nvc
        End Get
        Set(ByVal value As String)
            mvarAddress_nvc = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Function GetAll() As DataTable
        Try
            Dim dtInstaller As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllInstaller_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtInstaller, parRefCursor)
            Return dtInstaller
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByID() As DataTable
        Try
            Dim dtInstaller As New DataTable

            Dim parInstallerID As New OracleParameter("InstallerID_", OracleDbType.Int64)
            parInstallerID.Value = InstallerID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByIDInstaller_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtInstaller, parInstallerID, parRefCursor)
            Return dtInstaller
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Insert()
        Try
            Dim parFirstName_nvc As New OracleParameter("FirstName_nvc_", OracleDbType.Varchar2, 100)
            parFirstName_nvc.Value = FirstName_nvc
            Dim parLastName_nvc As New OracleParameter("LastName_nvc_", OracleDbType.Varchar2, 200)
            parLastName_nvc.Value = LastName_nvc
            Dim parTel_vc As New OracleParameter("Tel_vc_", OracleDbType.Varchar2, 20)
            parTel_vc.Value = Tel_vc
            Dim parMobile_vc As New OracleParameter("Mobile_vc_", OracleDbType.Varchar2, 20)
            parMobile_vc.Value = Mobile_vc
            Dim parAddress_nvc As New OracleParameter("Address_nvc_", OracleDbType.Varchar2, 500)
            parAddress_nvc.Value = Address_nvc
            Dim parInstallerid As New OracleParameter("Installerid_", OracleDbType.Int64)
            parInstallerid.Direction = ParameterDirection.Output

            strSQL = "InsertInstaller_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parFirstName_nvc, parLastName_nvc, parTel_vc, parMobile_vc, parAddress_nvc, parInstallerid)

            InstallerID = Int64.Parse(parInstallerid.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update()
        Try
            Dim parInstallerID As New OracleParameter("InstallerID_", OracleDbType.Int64)
            parInstallerID.Value = InstallerID
            Dim parFirstName_nvc As New OracleParameter("FirstName_nvc_", OracleDbType.Varchar2, 100)
            parFirstName_nvc.Value = FirstName_nvc
            Dim parLastName_nvc As New OracleParameter("LastName_nvc_", OracleDbType.Varchar2, 200)
            parLastName_nvc.Value = LastName_nvc
            Dim parTel_vc As New OracleParameter("Tel_vc_", OracleDbType.Varchar2, 20)
            parTel_vc.Value = Tel_vc
            Dim parMobile_vc As New OracleParameter("Mobile_vc_", OracleDbType.Varchar2, 20)
            parMobile_vc.Value = Mobile_vc
            Dim parAddress_nvc As New OracleParameter("Address_nvc_", OracleDbType.Varchar2, 500)
            parAddress_nvc.Value = Address_nvc

            strSQL = "UpdateInstaller_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parInstallerID, parFirstName_nvc, parLastName_nvc, parTel_vc, parMobile_vc, parAddress_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim parInstallerID As New OracleParameter("InstallerID_", OracleDbType.Int64)
            parInstallerID.Value = InstallerID

            strSQL = "DeleteInstaller_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parInstallerID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class
