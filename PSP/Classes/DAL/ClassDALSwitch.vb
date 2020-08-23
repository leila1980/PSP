''''  LastUpdate by: Mehdi Nanshekari
''''  This Class is for Switch form
''''  Last update Date: 1386/09/24

Imports System.Data
Imports Oracle.DataAccess.Client

Public Class ClassDALSwitch
    Inherits RIZNARM.Data.Oracle_Client.DataAccess


    Public Structure SwitchHeader
        Dim SwitchHeaderID As Int64
        Dim Number_bint As Int64
        Dim SaveDate_vc As String
        Dim Description_nvc As String
    End Structure

    Public Structure SwitchDetail
        Dim SwitchDetailID As Int64
        Dim SwitchHeaderID As Int64
        Dim DeviceID As Int64
    End Structure

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

    Public Function GetByNumberSwitchHeader(ByVal Number As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parNumber As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber.Value = Number
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByNumberSwitchHeader_SP", dt, parNumber, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByIDSwitchDetail(ByVal SwitchHeaderID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSwitchHeaderID As New OracleParameter("SwitchHeaderID_", OracleDbType.Int64)
            parSwitchHeaderID.Value = SwitchHeaderID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ClassUserLoginDataAccess.ThisUser.ProjectID

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByIDSwitchDetail_SP", dt, parSwitchHeaderID, parProjectID, parUserID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTheLatestSwitchHeaderNumber() As DataTable
        Try
            Dim dt As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetTheLatestSwitchHeaderNumber_SP
            Me.Fill(CommandType.StoreProcedure, "GetLatestSwitchHeaderNum_SP", dt, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForSwitch(ByVal Count As Integer, ByVal ProjectID As Long) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID", OracleDbType.Int64)
            parProjectID.Value = ProjectID

            Dim parCount_int As New OracleParameter("Count_int", OracleDbType.Int32)
            parCount_int.Value = Count

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            ''GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForSwitch_SP
            Me.Fill(CommandType.StoreProcedure, "GetByCountavailableForSwitch", dt, parCount_int, parProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForSwitchMakeFile(ByVal Number As Int64, ByVal ProjectID As Int16, ByVal InContractCMS As Boolean) As DataTable
        Try
            Dim dt As New DataTable
            Dim parCount_int As New OracleParameter("Count_int_", OracleDbType.Int32)
            parCount_int.Value = 1

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber_bint.Value = Number

            Dim parInContractCMS As New OracleParameter("InContractCMS_", OracleDbType.Int32)
            parInContractCMS.Value = InContractCMS
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByCountavailableforMakFile", dt, parCount_int, parNumber_bint, parProjectID, parInContractCMS, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''For SendTo WebPos Or Netsis
    Public Function GetInformationsForSendToWebPosOrNetSis(ByVal webPosOrNetSis As Char, ByVal Number As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim paramWebPosOrNetSis As New OracleParameter("WebPosOrNetSIS", OracleDbType.Char)
            paramWebPosOrNetSis.Value = webPosOrNetSis

            Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber_bint.Value = Number

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "ForSendToWebPosOrNetSis", dt, paramWebPosOrNetSis, parNumber_bint, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub SetSenttowebpos_TintToSent(ByVal outlet As String)

        Dim _clsDate As New ClassDalDate(ConnectionString)
        Dim PersianDate = _clsDate.GetPersianDateNow()


        Dim parCode As New OracleParameter("Code_", OracleDbType.Varchar2)
        parCode.Value = outlet

        Dim Senttowebpos_Date As New OracleParameter("Senttowebpos_Date_", OracleDbType.Varchar2)
        Senttowebpos_Date.Value = PersianDate

        Try
            connection.Open()
            Me.Execute_NonQuery(CommandType.StoreProcedure, "Set_Senttowebpos_Tint_To_Sent", parCode, Senttowebpos_Date)
            connection.Close()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForNetsisExcelMakeFile(ByVal Number As Int64, ByVal ProjectID As Int16, ByVal InContractCMS As Boolean) As DataTable
        Try
            Dim dt As New DataTable
            Dim parCount_int As New OracleParameter("Count_int_", OracleDbType.Int32)
            parCount_int.Value = 1

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber_bint.Value = Number

            Dim parInContractCMS As New OracleParameter("InContractCMS_", OracleDbType.Int32)
            parInContractCMS.Value = InContractCMS
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            ''GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForSwitchMakeFile_SP
            Me.Fill(CommandType.StoreProcedure, "GetAllforNetsisExcelFile", dt, parCount_int, parNumber_bint, parProjectID, parInContractCMS, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertSwitchHeader(ByVal Header As SwitchHeader) As Int64
        Try
            Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber_bint.Value = Header.Number_bint

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = Header.SaveDate_vc

            Dim parDescription_nvc As New OracleParameter("Description_nvc_", OracleDbType.Varchar2, 100)
            parDescription_nvc.Value = Header.Description_nvc

            Dim parSwitchHeaderID As New OracleParameter("SwitchHeaderID_", OracleDbType.Int64)
            parSwitchHeaderID.Direction = ParameterDirection.Output

            Me.Execute_NonQuery(CommandType.StoreProcedure, "InsertSwitchHeader_SP", parNumber_bint, parSaveDate_vc, parDescription_nvc, parSwitchHeaderID)

            Return Convert.ToInt64(parSwitchHeaderID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertSwitchDetail(ByVal Detail As SwitchDetail) As Int64
        Try
            Dim parSwitchHeaderID As New OracleParameter("SwitchHeaderID_", OracleDbType.Int64)
            parSwitchHeaderID.Value = Detail.SwitchHeaderID

            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = Detail.DeviceID

            Dim parSwitchDetailID As New OracleParameter("SwitchDetailID_", OracleDbType.Int64)
            parSwitchDetailID.Direction = ParameterDirection.Output

            Me.Execute_NonQuery(CommandType.StoreProcedure, "InsertSwitchDetail_SP", parSwitchHeaderID, parDeviceID, parSwitchDetailID)

            Return Convert.ToInt64(parSwitchDetailID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteSwitchDetail(ByVal HeaderID As Int64)
        Try
            Dim parHeaderID As New OracleParameter("@HeaderID", OracleDbType.Int64)
            parHeaderID.Value = HeaderID

            ''DeleteByHeaderIDSwitchDetail_SP
            Me.Execute_NonQuery(CommandType.StoreProcedure, "DeleteByHeaderIDSwitchDetail", parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteSwitchHeader(ByVal HeaderID As Int64)
        Try
            Dim parHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parHeaderID.Value = HeaderID
            Me.Execute_NonQuery(CommandType.StoreProcedure, "DeleteSwitchHeader_SP", parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateSwitchHeader(ByVal Header As SwitchHeader)
        Try
            Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber_bint.Value = Header.Number_bint

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = Header.SaveDate_vc

            Dim parDescription_nvc As New OracleParameter("Description_nvc_", OracleDbType.Varchar2, 100)
            parDescription_nvc.Value = Header.Description_nvc

            Dim parSwitchHeaderID As New OracleParameter("SwitchHeaderID_", OracleDbType.Int64)
            parSwitchHeaderID.Value = Header.SwitchHeaderID

            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateSwitchHeader_SP", parNumber_bint, parSaveDate_vc, parDescription_nvc, parSwitchHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
