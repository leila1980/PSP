''''  Programmed by: Mehdi Nanshekari
''''  This Class is for Accountingworking form
''''  Last update Date: 1386/09/22

Imports System.Data
Imports Oracle.DataAccess.Client

Public Class ClassDALAccount
    Inherits RIZNARM.Data.Oracle_Client.DataAccess

    Public Structure AccountHeader
        Dim AccountingHeaderID As Int64
        Dim Number_bint As Int64
        Dim SaveDate_vc As String
        Dim Description_nvc As String
    End Structure

    Public Structure AccountDetail
        Dim AccountingDetailID As Int64
        Dim AccountingHeaderID As Int64
        Dim AccountID As Int64
    End Structure

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

    Public Function GetByNumberAccountingHeader(ByVal Number As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parNumber As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber.Value = Number

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByNumberAccountingHeader_SP", dt, parNumber, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByIDAccountingDetail(ByVal AccountingHeaderID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parAccountingHeaderID As New OracleParameter("AccountingHeaderID_", OracleDbType.Int64)
            parAccountingHeaderID.Value = AccountingHeaderID
            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Me.Fill(CommandType.StoreProcedure, "GetByIDAccountingDetail_SP", dt, parAccountingHeaderID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTheLatestAccountingHeaderNumber() As DataTable
        Try
            Dim dt As New DataTable
            ''GetTheLatestAccountingHeaderNumber_SP
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Me.Fill(CommandType.StoreProcedure, "GetTheLatestAccHeaderNum_SP", dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllContractingParty_Contract_Account_AvailableForAccounting() As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID

            Me.Fill(CommandType.StoreProcedure, "GetAllContractingParty_Contract_Account_AvailableForAccounting_SP", dt, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllContractingParty_Contract_Account_AvailableForAccountingMakeFile() As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID

            Me.Fill(CommandType.StoreProcedure, "GetAllContractingParty_Contract_Account_AvailableForAccountingMakeFile_SP", dt, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllContractingParty_Contract_Account_AvailableForBatching() As DataTable
        Try
            Dim dt As New DataTable
            Me.Fill(CommandType.StoreProcedure, "GetAllContractingParty_Contract_Account_AvailableForBatching_SP", dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertAccountHeader(ByVal Header As AccountHeader) As Int64
        Try
            Dim parNumber_bint As New OracleParameter("@Number_bint", OracleDbType.Int64)
            parNumber_bint.Value = Header.Number_bint

            Dim parSaveDate_vc As New OracleParameter("@SaveDate_vc", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = Header.SaveDate_vc

            Dim parDescription_nvc As New OracleParameter("@Description_nvc", OracleDbType.Varchar2, 100)
            parDescription_nvc.Value = Header.Description_nvc

            Dim parAccountingHeaderID As New OracleParameter("@AccountingHeaderID", OracleDbType.Int64)
            parAccountingHeaderID.Direction = ParameterDirection.Output

            Me.Execute_NonQuery(CommandType.StoreProcedure, "InsertAccountingHeader_SP", parNumber_bint, parSaveDate_vc, parDescription_nvc, parAccountingHeaderID)

            Return parAccountingHeaderID.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertAccountDetail(ByVal Detail As AccountDetail) As Int64
        Try
            Dim parAccountingHeaderID As New OracleParameter("AccountingHeaderID_", OracleDbType.Int64)
            parAccountingHeaderID.Value = Detail.AccountingHeaderID

            Dim parAccountID As New OracleParameter("AccountID_", OracleDbType.Int64)
            parAccountID.Value = Detail.AccountID

            Dim parAccountingDetailID As New OracleParameter("AccountingDetailID_", OracleDbType.Int64)
            parAccountingDetailID.Direction = ParameterDirection.Output

            Me.Execute_NonQuery(CommandType.StoreProcedure, "InsertAccountingDetail_SP", parAccountingHeaderID, parAccountID, parAccountingDetailID)

            Return parAccountingDetailID.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteAccountingDetail(ByVal HeaderID As Int64)
        Try
            Dim parHeaderID As New OracleParameter("@HeaderID", OracleDbType.Int64)
            parHeaderID.Value = HeaderID
            Me.Execute_NonQuery(CommandType.StoreProcedure, "DeleteByHeaderIDAccountingDetail_SP", parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteAccountingHeader(ByVal HeaderID As Int64)
        Try
            Dim parHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parHeaderID.Value = HeaderID
            Me.Execute_NonQuery(CommandType.StoreProcedure, "DeleteAccountingHeader_SP", parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateAccountingHeader(ByVal Header As AccountHeader)
        Try
            Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber_bint.Value = Header.Number_bint

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = Header.SaveDate_vc

            Dim parDescription_nvc As New OracleParameter("Description_nvc_", OracleDbType.Varchar2, 100)
            parDescription_nvc.Value = Header.Description_nvc

            Dim parAccountingHeaderID As New OracleParameter("AccountingHeaderID_", OracleDbType.Int64)
            parAccountingHeaderID.Value = Header.AccountingHeaderID

            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateAccountingHeader_SP", parNumber_bint, parSaveDate_vc, parDescription_nvc, parAccountingHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
