Imports Oracle.DataAccess.Client


Public Class ClassDALError
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarErrorID As String
    Private mvarDescription As String
    Private mvarState As Integer

    Dim dtError As New DataTable

    Public Sub New(ByVal Cs As String)

        MyBase.new(Cs)
    End Sub

#Region "Property"

    Public Property ErrorID() As String
        Get
            Return mvarErrorID

        End Get
        Set(ByVal value As String)
            mvarErrorID = value
        End Set
    End Property


    Public Property ErrorDescription_nvc() As String
        Get
            Return mvarDescription
        End Get
        Set(ByVal value As String)
            mvarDescription = value
        End Set
    End Property

    Public Property Errorstatus_bit() As Integer
        Get

            Return mvarState

        End Get
        Set(ByVal value As Integer)
            mvarState = value
        End Set
    End Property


#End Region
#Region "Methods"
    Public Function getall() As DataTable
        Try
            Dim dtError As New DataTable()

            strSQL = "GetAllError_SP"
           
            Dim parRefCursor As New OracleParameter("Result_", OracleDbType.RefCursor, ParameterDirection.Output)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtError, parRefCursor)

            Return dtError
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Delete()
        Try
            Dim parErrorID As New OracleParameter("ErrorID_", OracleDbType.Varchar2, 5)
            parErrorID.Value = ErrorID

            strSQL = "DeleteError_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parErrorID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Insert()
        Try
            Dim parErrorID As New OracleParameter("ErrorID_", OracleDbType.Varchar2, 5)
            parErrorID.Value = ErrorID
            Dim parName_nvc As New OracleParameter("ErrorDescription_nvc_", OracleDbType.Varchar2)
            parName_nvc.Value = ErrorDescription_nvc
            Dim parStatus As New OracleParameter("status_bit_", OracleDbType.Int16)
            parStatus.Value = Errorstatus_bit
            
            strSQL = "InsertError_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parErrorID, parName_nvc, parStatus)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Update()
        Try
            Dim parErrorID As New OracleParameter("ErrorID_", OracleDbType.Varchar2, 5)
            parErrorID.Value = ErrorID
            Dim parName_nvc As New OracleParameter("ErrorDescription_nvc_", OracleDbType.Varchar2)
            parName_nvc.Value = ErrorDescription_nvc
            Dim parStatus As New OracleParameter("status_bit_", OracleDbType.Int16)
            parStatus.Value = Errorstatus_bit
            strSQL = "UpdateError_SP"

            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parErrorID, parName_nvc, parStatus)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetByID() As DataTable
        Try
            Dim dtError As New DataTable

            Dim parErrorID As New OracleParameter("ErrorID_", OracleDbType.Varchar2, 5)
            parErrorID.Value = ErrorID

            strSQL = "GetByIDError_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtError, parErrorID, parRefCursor)
            Return dtError
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
