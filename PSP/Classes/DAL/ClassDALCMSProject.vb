Imports Oracle.DataAccess.Client

Public Class ClassDALCMSProject
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarCMSProjectID As Int32
    Private mvarName_nvc As String
    Private mvarESSWS As String
    Private mvarIsSent2Switch As Int16
    Private mvarIsEniacMerchant As Int16
    Private mvarIsEniacOutlet As Int16

    Dim dtState As New DataTable

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

#Region "Property"

    Public Property CMSProjectID() As Int32
        Get
            Return mvarCMSProjectID
        End Get
        Set(ByVal value As Int32)
            mvarCMSProjectID = value
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

    Public Property IsSent2Switch() As Int16
        Get
            Return mvarIsSent2Switch
        End Get
        Set(ByVal value As Int16)
            mvarIsSent2Switch = value
        End Set
    End Property
    Public Property ESSWS_NVC() As String
        Get
            Return mvarESSWS
        End Get
        Set(ByVal value As String)
            mvarESSWS = value
        End Set
    End Property

    Public Property ISEniacMerchant() As Int16
        Get
            Return mvarIsEniacMerchant
        End Get
        Set(ByVal value As Int16)
            mvarIsEniacMerchant = value
        End Set
    End Property

    Public Property IsEniacOutlet() As Int16
        Get
            Return mvarIsEniacOutlet
        End Get
        Set(ByVal value As Int16)
            mvarIsEniacOutlet = value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Function GetAll() As DataTable
        Try
            Dim dtCMSProject As New DataTable
            strSQL = "usp_GetALLCMSProject"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCMSProject, parRefCursor)
            Return dtCMSProject
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByID() As DataTable
        Try
            Dim dtCMSProject As New DataTable
            Dim parCMSProjectID As New OracleParameter("CMSProjectID_int_", OracleDbType.Int32)
            parCMSProjectID.Value = CMSProjectID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "usp_GetCMSProjectByID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCMSProject, parCMSProjectID, parRefCursor)
            Return dtCMSProject
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Insert()
        Try
            Dim parCMSProjectID As New OracleParameter("CMSProjectID_int_", OracleDbType.Int32)
            parCMSProjectID.Value = CMSProjectID

            Dim parName_nvc As New OracleParameter("Name_nvc_", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc

            Dim parEssws_nvc As New OracleParameter("essws_nvc_", OracleDbType.Varchar2)
            parEssws_nvc.Value = ESSWS_NVC

            Dim parIssent2switch As New OracleParameter("issent2switch_", OracleDbType.Int16)
            parIssent2switch.Value = IsSent2Switch

            Dim parIsEniacmerchant As New OracleParameter("iseniacmerchant_", OracleDbType.Int16)
            parIsEniacmerchant.Value = ISEniacMerchant

            Dim parIsEniacoutlet As New OracleParameter("iseniacoutlet_", OracleDbType.Int16)
            parIsEniacoutlet.Value = IsEniacOutlet

            'strSQL = "usp_InsertCMSProject"
            strSQL = "usp_InsertCMSProjectNew"

            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parCMSProjectID, parName_nvc, parEssws_nvc, parIssent2switch, parIsEniacmerchant, parIsEniacoutlet)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Update()
        Try
            Dim parCMSProjectID As New OracleParameter("CMSProjectID_int_", OracleDbType.Int32)
            parCMSProjectID.Value = CMSProjectID

            Dim parName_nvc As New OracleParameter("Name_nvc_", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc

            Dim parEssws_nvc As New OracleParameter("essws_nvc_", OracleDbType.Varchar2)
            parEssws_nvc.Value = ESSWS_NVC

            Dim parIssent2switch As New OracleParameter("issent2switch_", OracleDbType.Int16)
            parIssent2switch.Value = IsSent2Switch

            Dim parIsEniacmerchant As New OracleParameter("iseniacmerchant_", OracleDbType.Int16)
            parIsEniacmerchant.Value = ISEniacMerchant

            Dim parIsEniacoutlet As New OracleParameter("iseniacoutlet_", OracleDbType.Int16)
            parIsEniacoutlet.Value = IsEniacOutlet

            'strSQL = "usp_UpdateCMSProject"
            strSQL = "usp_UpdateCMSProjectNew"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parCMSProjectID, parName_nvc, parEssws_nvc, parIssent2switch, parIsEniacmerchant, parIsEniacoutlet)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Delete()
        Try
            Dim parCMSProjectID As New OracleParameter("CMSProjectID_int_", OracleDbType.Int32)
            parCMSProjectID.Value = CMSProjectID

            strSQL = "usp_DeleteCMSProject"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parCMSProjectID)
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw ex
        End Try
    End Sub

#End Region

End Class
