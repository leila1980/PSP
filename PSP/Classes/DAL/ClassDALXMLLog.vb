Imports System.Data
Imports Oracle.DataAccess.Client
Public Class ClassDALXMLLog
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarLOGID As Int64
    Private mvarDATE_ As String
    Private mvarUSERNAME As String
    Private mvarHOSTNAME As String
    Private mvarTABLENAME As String
    Private mvarBEFORE As String
    Private mvarAFTER As String

    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub
#Region "Property XMLLog"
    Public Property LOGID() As Int64
        Get
            Return mvarLOGID
        End Get
        Set(ByVal value As Int64)
            mvarLOGID = value
        End Set
    End Property
    Public Property DATE_() As String
        Get
            Return mvarDATE_
        End Get
        Set(ByVal value As String)
            mvarDATE_ = value
        End Set
    End Property
    Public Property USERNAME() As String
        Get
            Return mvarUSERNAME
        End Get
        Set(ByVal value As String)
            mvarUSERNAME = value
        End Set
    End Property

    Public Property HOSTNAME() As String
        Get
            Return mvarHOSTNAME
        End Get
        Set(ByVal value As String)
            mvarHOSTNAME = value
        End Set
    End Property
    Public Property TABLENAME() As String
        Get
            Return mvarTABLENAME
        End Get
        Set(ByVal value As String)
            mvarTABLENAME = value
        End Set
    End Property
    Public Property BEFORE() As String
        Get
            Return mvarBEFORE
        End Get
        Set(ByVal value As String)
            mvarBEFORE = value
        End Set
    End Property
    Public Property AFTER As String
        Get
            Return mvarAFTER
        End Get
        Set(ByVal value As String)
            mvarAFTER = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Function GetAllXMLLOG() As DataTable
        Try
            Dim dtXMLLOG As New DataTable

            strSQL = "GetAllXMLLOG_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtXMLLOG, parRefCursor)
            Return dtXMLLOG
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllUsernameFromXMLLog() As DataTable
        Try
            Dim dtUsername As New DataTable

            strSQL = "GetAllUSERNAMEFromXMLLOG_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtUsername, parRefCursor)
            Return dtUsername
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllTableNameFromXMLLog() As DataTable
        Try
            Dim dtTableName As New DataTable

            strSQL = "GetAlltablenameFromXMLLOG_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtTableName, parRefCursor)
            Return dtTableName
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllHostNameFromXMLLog() As DataTable
        Try
            Dim dtHostName As New DataTable

            strSQL = "GetAllhostnameFromXMLLOG_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtHostName, parRefCursor)
            Return dtHostName
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetXMLLogByParameter(ByVal DateFrom As String, ByVal DateTo As String, ByVal UserName As String, ByVal TableName As String, ByVal HostName As String, ByVal RowNumFrom As Int64, ByVal RowNumTo As Int64, ByRef RecordCount As Int64)
        Try
            Dim dt As New DataTable

            Dim parDateFrom As New OracleParameter("DateFrom_", OracleDbType.Varchar2, 10)
            parDateFrom.Value = DateFrom

            Dim parDateTo As New OracleParameter("DateTo_", OracleDbType.Varchar2, 10)
            parDateTo.Value = DateTo

            Dim parUsername As New OracleParameter("username_", OracleDbType.Varchar2, 100)
            parUsername.Value = UserName

            Dim parTableName As New OracleParameter("TableName_", OracleDbType.Varchar2, 100)
            parTableName.Value = TableName

            Dim parhostName As New OracleParameter("HostName_", OracleDbType.Varchar2, 100)
            parhostName.Value = HostName

            Dim parRowNumFrom As New OracleParameter("RowNumFrom_", OracleDbType.Int64)
            parRowNumFrom.Value = RowNumFrom

            Dim parRowNumTo As New OracleParameter("RowNumTo_", OracleDbType.Int64)
            parRowNumTo.Value = RowNumTo

            Dim parRecordCount As New OracleParameter("RecordCount_", OracleDbType.Int64, ParameterDirection.Output)
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)


            Dim strSQL As String = "GetXMLLogByParameter_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, _
                 parDateFrom, _
                 parDateTo, _
                 parUsername, _
                 parTableName, _
                 parhostName, _
                 parRowNumFrom, _
                 parRowNumTo, _
                 parRecordCount, _
                 parRefCursor
                 )


            RecordCount = parRecordCount.Value.ToString
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region


End Class

