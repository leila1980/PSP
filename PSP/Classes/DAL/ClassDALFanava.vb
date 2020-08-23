''''  LastUpdate by: Mehdi Nanshekari
''''  This Class is for Switch form
''''  Last update Date: 1386/09/24

Imports System.Data
Imports Oracle.DataAccess.Client

Public Class ClassDALFanava
    Inherits RIZNARM.Data.Oracle_Client.DataAccess


    Public Structure BatchHeader
        Dim HeaderID As Int64
        Dim Number_bint As Int64
        Dim SaveDate_vc As String
        Dim Description_nvc As String
    End Structure

    Public Structure BatchDetail
        Dim DetailID As Int64
        Dim HeaderID As Int64
        Dim ContractID As Int64
    End Structure

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

    Public Function GetByNumberBatchHeader(ByVal Number As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parNumber As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber.Value = Number
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByNumBatchHeader_SP", dt, parNumber, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByIDBatchDetail(ByVal HeaderID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parHeaderID.Value = HeaderID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID

            'Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            'parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByIDBatchDetail_SP", dt, parHeaderID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByIDBatchDetailPasargad(ByVal HeaderID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parHeaderID.Value = HeaderID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID

            'Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            'parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByIDBatchDetailPasargad_SP", dt, parHeaderID, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllBatchDetailByCMSPrjID(ByVal CMSProjectID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim spName As String
            Dim parCmsprojectID As New OracleParameter("CmsprojectID_", OracleDbType.Int64)
            parCmsprojectID.Value = CMSProjectID

            If (CMSProjectID = My.Settings.Fanava_CmsProjectID) Then
                spName = "GETALLBATCHDETAILBYCMSPRJID_SP"

            ElseIf (CMSProjectID = My.Settings.Pasargard_CmsProjectID) Then
                spName = "GETALLBATCHDETAILPasargad_SP"
            End If

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Me.Fill(CommandType.StoreProcedure, spName, dt, parCmsprojectID, parRefCursor)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLatestHeaderNumber() As DataTable
        Try
            Dim dt As New DataTable

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Me.Fill(CommandType.StoreProcedure, "GetLatestHeaderNum_SP", dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllHeaderNumbers(ByVal CMSProjectID As Long) As DataTable
        Try
            Dim dt As New DataTable

            Dim parCmsprojectID As New OracleParameter("CmsprojectID_", OracleDbType.Int64)
            parCmsprojectID.Value = CMSProjectID

            Dim strSQL As String = "GETALLHeaderNumbers_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCmsprojectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByCountContractingParty_Contract_Account_Store_AvailableForBatch(ByVal Count As Integer, ByVal ProjectID As Long, ByVal CMSProjectID As Long) As DataTable
        Try
            Dim dt As New DataTable
            Dim spName As String = ""

            Dim parProjectID As New OracleParameter("ProjectID", OracleDbType.Int64)
            parProjectID.Value = ProjectID

            Dim parCmsprojectID As New OracleParameter("CmsprojectID_", OracleDbType.Int64)
            parCmsprojectID.Value = CMSProjectID

            If (CMSProjectID = My.Settings.Fanava_CmsProjectID) Then
                spName = "GetByCountavailForFanavaBatch"
            ElseIf (CMSProjectID = My.Settings.Pasargard_CmsProjectID) Then
                spName = "GetavailForPasargadBatch"
            End If

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)


            Me.Fill(CommandType.StoreProcedure, spName, dt, parProjectID, parCmsprojectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForSwitchMakeFile(ByVal Number As Int64, ByVal ProjectID As Int16, ByVal InContractCMS As Boolean) As DataTable
    '    Try
    '        Dim dt As New DataTable
    '        Dim parCount_int As New OracleParameter("Count_int_", OracleDbType.Int32)
    '        parCount_int.Value = 1

    '        Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
    '        parProjectID.Value = ProjectID

    '        Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
    '        parNumber_bint.Value = Number

    '        Dim parInContractCMS As New OracleParameter("InContractCMS_", OracleDbType.Int32)
    '        parInContractCMS.Value = InContractCMS
    '        Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

    '        ''GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForSwitchMakeFile_SP
    '        Me.Fill(CommandType.StoreProcedure, "GetByCountavailableforMakFile", dt, parCount_int, parNumber_bint, parProjectID, parInContractCMS, parRefCursor)
    '        Return dt
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForNetsisExcelMakeFile(ByVal Number As Int64, ByVal ProjectID As Int16, ByVal InContractCMS As Boolean) As DataTable
    '    Try
    '        Dim dt As New DataTable
    '        Dim parCount_int As New OracleParameter("Count_int_", OracleDbType.Int32)
    '        parCount_int.Value = 1

    '        Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
    '        parProjectID.Value = ProjectID

    '        Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
    '        parNumber_bint.Value = Number

    '        Dim parInContractCMS As New OracleParameter("InContractCMS_", OracleDbType.Int32)
    '        parInContractCMS.Value = InContractCMS
    '        Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

    '        ''GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForSwitchMakeFile_SP
    '        Me.Fill(CommandType.StoreProcedure, "GetAllforNetsisExcelFile", dt, parCount_int, parNumber_bint, parProjectID, parInContractCMS, parRefCursor)
    '        Return dt
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function InsertBatchHeader(ByVal Header As BatchHeader) As Int64
        Try
            Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber_bint.Value = Header.Number_bint

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = Header.SaveDate_vc

            Dim parDescription_nvc As New OracleParameter("Description_nvc_", OracleDbType.Varchar2, 100)
            parDescription_nvc.Value = Header.Description_nvc

            Dim parHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parHeaderID.Direction = ParameterDirection.Output

            Me.Execute_NonQuery(CommandType.StoreProcedure, "InsertBatchHeader_SP", parNumber_bint, parSaveDate_vc, parDescription_nvc, parHeaderID)

            Return Convert.ToInt64(parHeaderID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertBatchDetail(ByVal Detail As BatchDetail) As Int64
        Try
            Dim parSwitchHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parSwitchHeaderID.Value = Detail.HeaderID

            Dim parContarctID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContarctID.Value = Detail.ContractID

            Dim parDetailID As New OracleParameter("DetailID_", OracleDbType.Int64)
            parDetailID.Direction = ParameterDirection.Output

            Me.Execute_NonQuery(CommandType.StoreProcedure, "InsertBatchDetail_SP", parSwitchHeaderID, parContarctID, parDetailID)

            Return Convert.ToInt64(parDetailID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteBatchDetail(ByVal HeaderID As Int64)
        Try
            Dim parHeaderID As New OracleParameter("@HeaderID", OracleDbType.Int64)
            parHeaderID.Value = HeaderID


            Me.Execute_NonQuery(CommandType.StoreProcedure, "DeleteByHeaderIDDetail", parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteBatchHeader(ByVal HeaderID As Int64)
        Try
            Dim parHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parHeaderID.Value = HeaderID
            Me.Execute_NonQuery(CommandType.StoreProcedure, "DeleteBatchHeader_SP", parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateBatchHeader(ByVal Header As BatchHeader)
        Try
            Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber_bint.Value = Header.Number_bint

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = Header.SaveDate_vc

            Dim parDescription_nvc As New OracleParameter("Description_nvc_", OracleDbType.Varchar2, 100)
            parDescription_nvc.Value = Header.Description_nvc

            Dim parHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parHeaderID.Value = Header.HeaderID

            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateBatchHeader_SP", parNumber_bint, parSaveDate_vc, parDescription_nvc, parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function getAllFanavaExcelFields() As DataTable
        Try
            Dim dt As New DataTable

            Dim strSQL As String = "select distinct FANAVAEXCEL.id,FANAVAEXCEL.excelcolumnname from FANAVAEXCEL order by id asc "
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
