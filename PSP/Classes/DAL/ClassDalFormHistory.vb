Imports RIZNARM.Data
Imports Oracle.DataAccess.Client

''' <summary>
''' Create Date : 1386/10/16
''' Create By : Ehsan Soheili
''' Last Modified : 1386/10/16
''' </summary>
''' <remarks></remarks>
Public Class ClassDalFormHistory
    Inherits Oracle_Client.DataAccess
    Public Structure FormHistoryTemplate
        Dim FormID As ULong
        Dim UserID As ULong
        Dim Date_vc As String
        Dim Time_vc As String
        Dim FormName As String
        Dim BasicType As Int16
    End Structure
    Public Sub New(ByVal ConnectionString As String)
        MyBase.New(ConnectionString)
    End Sub
    Public Function GetFormID(ByVal Template As FormHistoryTemplate) As Int16
        Try
            Dim parFormName As New OracleParameter("FormName_", OracleDbType.Varchar2, 50)
            parFormName.Value = Template.FormName
            Dim parBasicType As New OracleParameter("BasicType_", OracleDbType.Int16)
            parBasicType.Value = Template.BasicType
            Dim parFormID As New OracleParameter("FormID_", OracleDbType.Int64)
            parFormID.Direction = ParameterDirection.Output
            Me.Execute_NonQuery(CommandType.StoreProcedure, "GetByNameFormHistory_SP", parFormName, parBasicType, parFormID)
            Return Int16.Parse(parFormID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Insert(ByVal Template As FormHistoryTemplate)
        Try
            Dim parFormID As New OracleParameter("FormID_", OracleDbType.Int64)
            parFormID.Value = Template.FormID
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = Template.UserID
            Dim parDate As New OracleParameter("Date_vc_", OracleDbType.Varchar2, 10)
            parDate.Value = Template.Date_vc
            Dim parTime As New OracleParameter("Time_vc_", OracleDbType.Varchar2, 8)
            parTime.Value = Template.Time_vc

            Me.Execute_NonQuery(CommandType.StoreProcedure, "InsertFormHistory_SP", parFormID, parUserID, parDate, parTime)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetByUserID(ByVal Template As FormHistoryTemplate) As DataTable
        Try
            Dim _dt As New DataTable
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = Template.UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByUserIDFormHistory_SP", _dt, parUserID, parRefCursor)
            Return _dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class