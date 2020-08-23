Imports Oracle.DataAccess.Client

Public Class ClassContractAndCMS
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarContractID As Int64
    Private mvarCMSProjectID As Int32

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

#Region "Property"

    Public Property CMSProjectID() As String
        Get
            Return mvarCMSProjectID
        End Get
        Set(ByVal value As String)
            mvarCMSProjectID = value
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

#End Region

#Region "Methode"
    Public Function GetByContractID() As DataTable
        Try
            Dim dtCMSProject As New DataTable
            strSQL = "usp_getContractCMS"
            Dim parContract As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContract.Value = ContractID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCMSProject, parContract, parRefCursor)
            Return dtCMSProject
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
