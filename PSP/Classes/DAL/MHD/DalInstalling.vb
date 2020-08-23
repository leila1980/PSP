Imports Oracle.DataAccess.Client

Partial Class Dal
    Public Structure InstallingHeaderTemplate
        Dim InstallingHeaderID As Int64
        Dim Number_bint As Int64
        Dim SaveDate_vc As String
        Dim Description_nvc As String
        Dim InstallerID As Int64

    End Structure

    Public Structure MutateCMSPROJECTID
        Dim NewCMSPROJECTD As Integer
        Dim OldCMSPROJECTD As Integer
    End Structure


    Public Structure InstallingDetailTemplate
        Dim InstallingDetailID As Int64
        Dim InstallingHeaderID As Int64
        Dim DeviceID As Int64
        Dim Status_tint As Int16
        Dim Install_OK As Int16
        Dim Ins_date As String
        Dim Ins_Time As String
        Dim Sign As Int16
        Dim Card As Int16
        Dim PurchaseReceipt As Int16
        Dim StockReceipt As Int16
        Dim DasteGardesh As Int16

    End Structure

    Public Function GetBYDeviceIDInstallingDetail(ByVal DeviceID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DeviceID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            ''GetBYDeviceIDInstallingDetail_
            Me.Fill(CommandType.StoreProcedure, "GetBYDeviceIDInstallingDetail", dt, parDeviceID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBYInstallingDetailIDInstallingDetail(ByVal InstallingDetailID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parInstallingDetailID As New OracleParameter("InstallingDetailID_", OracleDbType.Int64)
            parInstallingDetailID.Value = InstallingDetailID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Me.Fill(CommandType.StoreProcedure, "GetBYInstallingDetailIDInstall", dt, parInstallingDetailID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByNumberInstallingHeader(ByVal Number As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parNumber As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber.Value = Number
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByNumberInstallingHeader_SP", dt, parNumber, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByInstallerInstallingHeader(ByVal InstallerID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parInstallerID As New OracleParameter("@InstallerID", OracleDbType.Int64)
            parInstallerID.Value = InstallerID
            Me.Fill(CommandType.StoreProcedure, "GetByInstallerInstallingHeader_SP", dt, parInstallerID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByIDInstallingDetail(ByVal InstallingHeaderID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable

            Dim parInstallingHeaderID As New OracleParameter("InstallingHeaderID_", OracleDbType.Int64)
            parInstallingHeaderID.Value = InstallingHeaderID

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID


            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByIDInstallingDetail_SP", dt, parInstallingHeaderID, parProjectID, parUserID, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByVisitorIDContractingParty_Contract_Account_Store_Device_Pos_InstallingDetail(ByVal VisitorID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int64)
            parVisitorID.Value = VisitorID
            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID
            Me.Fill(CommandType.StoreProcedure, "GetByVisitorIDContractingParty_Contract_Account_Store_Device_Pos_InstallingDetail_SP", dt, parVisitorID, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByVisitorIDContractingParty_Contract_Account_Store(ByVal VisitorID As Int64, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int64)
            parVisitorID.Value = VisitorID

            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Me.Fill(CommandType.StoreProcedure, "GetByVisitorIDContractingParty_Contract_Account_Store_SP", dt, parVisitorID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTheLatestInstallingHeaderNumber() As DataTable
        Try
            Dim dt As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            'GetTheLatestInstallingHeaderNumber_SP
            Me.Fill(CommandType.StoreProcedure, "GetTheLatestInstallingHeaderN0", dt, parRefCursor)
            Return dt

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForInstalling(ByVal ProjectID As Int16, Optional ByVal cmsprojectid As Int16 = 1) As DataTable
        Try
            Dim dt As New DataTable

            Dim parProjectID As New OracleParameter("ProjectID_", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Dim parCount_int As New OracleParameter("Count_int_", OracleDbType.Int16)
            parCount_int.Value = 1

            Dim parCMSProjectID As New OracleParameter("cmsprojectid_", OracleDbType.Int16)
            parCMSProjectID.Value = cmsprojectid

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            ''GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_AvailableForInstalling_SP
            Me.Fill(CommandType.StoreProcedure, "GetByCountAvaiForInstalling_SP", dt, parCount_int, parProjectID, parUserID, parCMSProjectID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForInstallingMakeFile(ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parCount_int As New OracleParameter("@Count_int", OracleDbType.Int32)
            parCount_int.Value = 1

            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)
            parProjectID.Value = ProjectID

            Me.Fill(CommandType.StoreProcedure, "GetByCountContractingParty_Contract_Account_Store_Device_DevicePos_Pos_PURE_AvailableForInstallingMakeFile_SP", dt, parCount_int, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertInstallingHeader(ByVal Header As InstallingHeaderTemplate) As Int64
        Try
            Dim parNumber_bint As New OracleParameter("Number_bint_", OracleDbType.Int64)
            parNumber_bint.Value = Header.Number_bint

            Dim parInstallerID As New OracleParameter("InstallerID_", OracleDbType.Int64)
            parInstallerID.Value = Header.InstallerID

            Dim parSaveDate_vc As New OracleParameter("SaveDate_vc_", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = Header.SaveDate_vc

            Dim parDescription_nvc As New OracleParameter("Description_nvc_", OracleDbType.Varchar2, 100)
            parDescription_nvc.Value = Header.Description_nvc


            Dim parInstallingHeaderID As New OracleParameter("InstallingHeaderID_", OracleDbType.Int64)
            parInstallingHeaderID.Direction = ParameterDirection.Output

            Me.Execute_NonQuery(CommandType.StoreProcedure, "InsertInstallingHeader_SP", parNumber_bint, parSaveDate_vc, parDescription_nvc, parInstallingHeaderID, parInstallerID)

            Return Convert.ToInt64(parInstallingHeaderID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertInstallingDetail(ByVal Detail As InstallingDetailTemplate) As Int64
        Try
            Dim parInstallingHeaderID As New OracleParameter("InstallingHeaderID_", OracleDbType.Int64)
            parInstallingHeaderID.Value = Detail.InstallingHeaderID

            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = Detail.DeviceID

            Dim parInstallingDetailID As New OracleParameter("InstallingDetailID_", OracleDbType.Int64)
            parInstallingDetailID.Direction = ParameterDirection.Output

            Dim parStatus_tint As New OracleParameter("Status_tint_", OracleDbType.Int16)
            parStatus_tint.Value = Detail.Status_tint

            Me.Execute_NonQuery(CommandType.StoreProcedure, "InsertInstallingDetail_SP", parInstallingHeaderID, parDeviceID, parStatus_tint, parInstallingDetailID)

            Return Convert.ToInt64(parInstallingDetailID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteInstallingDetail(ByVal HeaderID As Int64)
        Try
            Dim parHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parHeaderID.Value = HeaderID

            Me.Execute_NonQuery(CommandType.StoreProcedure, "DeleteByHeaderIDInstallDet_SP", parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteByDetailIDInstallingDetail(ByVal DetailID As Int64)
        Try
            Dim parDetailID As New OracleParameter("DetailID_", OracleDbType.Int64)
            parDetailID.Value = DetailID
            ''DeleteByDetailIDInstallingDetail_SP
            Me.Execute_NonQuery(CommandType.StoreProcedure, "DeleteByDetIDInsDetatail", parDetailID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteInstallingHeader(ByVal HeaderID As Int64)
        Try
            Dim parHeaderID As New OracleParameter("HeaderID_", OracleDbType.Int64)
            parHeaderID.Value = HeaderID
            Me.Execute_NonQuery(CommandType.StoreProcedure, "DeleteInstallingHeader_SP", parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateInstallingHeader(ByVal Header As InstallingHeaderTemplate)
        Try
            Dim parNumber_bint As New OracleParameter("@Number_bint", OracleDbType.Int64)
            parNumber_bint.Value = Header.Number_bint

            Dim parInstallerID As New OracleParameter("@InstallerID", OracleDbType.Int64)
            parInstallerID.Value = Header.InstallerID

            Dim parSaveDate_vc As New OracleParameter("@SaveDate_vc", OracleDbType.Varchar2, 10)
            parSaveDate_vc.Value = Header.SaveDate_vc

            Dim parDescription_nvc As New OracleParameter("@Description_nvc", OracleDbType.Varchar2, 100)
            parDescription_nvc.Value = Header.Description_nvc

            Dim parInstallingHeaderID As New OracleParameter("@InstallingHeaderID", OracleDbType.Int64)
            parInstallingHeaderID.Value = Header.InstallingHeaderID


            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateInstallingHeader_SP", parNumber_bint, parSaveDate_vc, parDescription_nvc, parInstallingHeaderID, parInstallerID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateInstallingDetailStatus(ByVal DeviceID As Integer, ByVal HeaderID As Integer)
        Try
            Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim parHeaderID As New OracleParameter("@HeaderID", OracleDbType.Int64)
            parHeaderID.Value = HeaderID

            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateInstallingDetailStatus_SP", parDeviceID, parHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub UpdateInstallingHeaderCMS(ByVal InstallingHeaderID As Long, ByVal cmsproject As Integer)
        Try
            Dim parCMSPROJECT As New OracleParameter("@CMSPROJECTID", OracleDbType.Int64)
            parCMSPROJECT.Value = cmsproject

            Dim parInstallingHeaderID As New OracleParameter("@InstallingHeaderID", OracleDbType.Int64)
            parInstallingHeaderID.Value = InstallingHeaderID

            Me.Execute_NonQuery(CommandType.StoreProcedure, "Updatecontract_cms_t_SP", parCMSPROJECT, parInstallingHeaderID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateInstallingDetail(ByVal Detail As InstallingDetailTemplate)
        Try
            Dim parInstallingDetailID As New OracleParameter("@InstallingDetailID", OracleDbType.Int64)
            parInstallingDetailID.Value = Detail.InstallingDetailID

            Dim parIns_date As New OracleParameter("@Ins_date", OracleDbType.Varchar2, 10)
            parIns_date.Value = IIf(Detail.Ins_date = "", DBNull.Value, Detail.Ins_date)

            Dim parIns_Time As New OracleParameter("@Ins_Time", OracleDbType.Varchar2, 5)
            parIns_Time.Value = IIf(Detail.Ins_Time = "", DBNull.Value, Detail.Ins_Time)

            Dim parSign As New OracleParameter("@Sign", OracleDbType.Int16)
            parSign.Value = Detail.Sign

            Dim parCard As New OracleParameter("@Card", OracleDbType.Int16)
            parCard.Value = Detail.Card

            Dim parPurchaseReceipt As New OracleParameter("@PurchaseReceipt", OracleDbType.Int16)
            parPurchaseReceipt.Value = Detail.PurchaseReceipt

            Dim parStockReceipt As New OracleParameter("@StockReceipt", OracleDbType.Int16)
            parStockReceipt.Value = Detail.StockReceipt

            Dim parDasteGardesh As New OracleParameter("@DasteGardesh", OracleDbType.Int16)
            parDasteGardesh.Value = Detail.DasteGardesh


            Dim parInstall_OK As New OracleParameter("@Install_OK", OracleDbType.Int16)
            parInstall_OK.Value = Detail.Install_OK



            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateInstallingDetail_SP", parInstallingDetailID, parIns_date, parIns_Time, parSign, parCard, parPurchaseReceipt, parStockReceipt, parDasteGardesh, parInstall_OK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateInstallingDetail1(ByVal Detail As InstallingDetailTemplate)
        Try
            Dim parInstallingDetailID As New OracleParameter("@InstallingDetailID", OracleDbType.Int64)
            parInstallingDetailID.Value = Detail.InstallingDetailID

            Dim parIns_date As New OracleParameter("@Ins_date", OracleDbType.Varchar2, 10)
            parIns_date.Value = IIf(Detail.Ins_date = "", DBNull.Value, Detail.Ins_date)

            Dim parIns_Time As New OracleParameter("@Ins_Time", OracleDbType.Varchar2, 5)
            parIns_Time.Value = IIf(Detail.Ins_Time = "", DBNull.Value, Detail.Ins_Time)

            Dim parInstall_OK As New OracleParameter("@Install_OK", OracleDbType.Int16)
            parInstall_OK.Value = Detail.Install_OK



            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateInstallingDetail1_SP", parInstallingDetailID, parIns_date, parIns_Time, parInstall_OK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateInstallingDetail2(ByVal Detail As InstallingDetailTemplate)
        Try
            Dim parInstallingDetailID As New OracleParameter("@InstallingDetailID", OracleDbType.Int64)
            parInstallingDetailID.Value = Detail.InstallingDetailID


            Dim parSign As New OracleParameter("@Sign", OracleDbType.Int16)
            parSign.Value = Detail.Sign

            Dim parCard As New OracleParameter("@Card", OracleDbType.Int16)
            parCard.Value = Detail.Card

            Dim parPurchaseReceipt As New OracleParameter("@PurchaseReceipt", OracleDbType.Int16)
            parPurchaseReceipt.Value = Detail.PurchaseReceipt

            Dim parStockReceipt As New OracleParameter("@StockReceipt", OracleDbType.Int16)
            parStockReceipt.Value = Detail.StockReceipt

            Dim parDasteGardesh As New OracleParameter("@DasteGardesh", OracleDbType.Int16)
            parDasteGardesh.Value = Detail.DasteGardesh

            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateInstallingDetail2_SP", parInstallingDetailID, parSign, parCard, parPurchaseReceipt, parStockReceipt)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateInstallingDetailInstallOK(ByVal Detail As InstallingDetailTemplate)
        Try
            Dim parInstallingDetailID As New OracleParameter("@InstallingDetailID", OracleDbType.Int64)
            parInstallingDetailID.Value = Detail.InstallingDetailID

            Dim parInstall_OK As New OracleParameter("@Install_OK", OracleDbType.Int16)
            parInstall_OK.Value = Detail.Install_OK


            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateInstallingDetailInstallOK_SP", parInstallingDetailID, parInstall_OK)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateInstallingDetailDetails(ByVal Detail As InstallingDetailTemplate)
        Try

            Dim parInstallingDetailID As New OracleParameter("@InstallingDetailID", OracleDbType.Int64)
            parInstallingDetailID.Value = Detail.InstallingDetailID

            Dim parIns_date As New OracleParameter("@Ins_date", OracleDbType.Varchar2, 10)
            parIns_date.Value = Detail.Ins_date

            Dim parIns_Time As New OracleParameter("@Ins_Time", OracleDbType.Varchar2, 5)
            parIns_Time.Value = Detail.Ins_Time

            Dim parSign As New OracleParameter("@Sign", OracleDbType.Int16)
            parSign.Value = Detail.Sign

            Dim parCard As New OracleParameter("@Card", OracleDbType.Int16)
            parCard.Value = Detail.Card

            Dim parPurchaseReceipt As New OracleParameter("@PurchaseReceipt", OracleDbType.Int16)
            parPurchaseReceipt.Value = Detail.PurchaseReceipt

            Dim parStockReceipt As New OracleParameter("@StockReceipt", OracleDbType.Int16)
            parStockReceipt.Value = Detail.StockReceipt

            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateInstallingDetailDetails_SP", parInstallingDetailID, parIns_date, parIns_Time, parSign, parCard, parPurchaseReceipt, parStockReceipt)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetByInstallingHeaderIDInstallingHeader(ByVal InstallingHeaderID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parInstallingHeaderID As New OracleParameter("@InstallingHeaderID", OracleDbType.Int64)
            parInstallingHeaderID.Value = InstallingHeaderID


            Me.Fill(CommandType.StoreProcedure, "GetByInstallingHeaderIDInstallingHeader_SP", dt, parInstallingHeaderID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByDeviceIDInstallingHeaderInstallingDetail(ByVal DeviceID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parDeviceID As New OracleParameter("DeviceID_", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByDeviceIDInstallingHeaderI", dt, parDeviceID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByOutletInstallingDetailInfo(ByVal Outlet_vc As String, ByVal InstallingHeaderID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parOutlet_vc As New OracleParameter("@Outlet_vc", OracleDbType.Varchar2, 12)
            parOutlet_vc.Value = Outlet_vc

            Dim parInstallingHeaderID As New OracleParameter("@InstallingHeaderID", OracleDbType.Int64)
            parInstallingHeaderID.Value = InstallingHeaderID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetByOutletInstallingDetailInf", dt, parOutlet_vc, parInstallingHeaderID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#Region "TMS" '---For transaction
    Public Sub ForTMS_TMSTerminal_Insert3(ByVal TERMINAL_ID As String, ByVal SIGNATURE As String, ByVal NAME As String, ByVal REGISTRATION_DATE As DateTime, ByVal TYPE As String, ByVal STATUS As Int32, ByVal CATEGORY As Int32, ByVal DESCRIPTION As String, ByVal PARENT_ID As String, ByVal COMMS As String)
        Try
            Dim parTERMINAL_ID As New OracleParameter("@TERMINAL_ID", OracleDbType.Varchar2, 50)
            parTERMINAL_ID.Value = TERMINAL_ID
            Dim parSIGNATURE As New OracleParameter("@SIGNATURE", OracleDbType.Varchar2, 50)
            parSIGNATURE.Value = SIGNATURE
            Dim parNAME As New OracleParameter("@NAME", OracleDbType.Varchar2, 100)
            parNAME.Value = NAME
            Dim parREGISTRATION_DATE As New OracleParameter("@REGISTRATION_DATE", OracleDbType.Varchar2, 10)
            parREGISTRATION_DATE.Value = REGISTRATION_DATE
            Dim parTYPE As New OracleParameter("@TYPE", OracleDbType.Varchar2, 20)
            parTYPE.Value = TYPE
            Dim parSTATUS As New OracleParameter("@STATUS", OracleDbType.Int32)
            parSTATUS.Value = STATUS
            Dim parCATEGORY As New OracleParameter("@CATEGORY", OracleDbType.Int32)
            parCATEGORY.Value = CATEGORY
            Dim parDESCRIPTION As New OracleParameter("@DESCRIPTION", OracleDbType.Varchar2, 200)
            parDESCRIPTION.Value = DESCRIPTION
            Dim parPARENT_ID As New OracleParameter("@PARENT_ID", OracleDbType.Varchar2, 50)
            parPARENT_ID.Value = PARENT_ID
            Dim parCOMMS As New OracleParameter("@COMMS", OracleDbType.Varchar2, 200)
            parCOMMS.Value = COMMS


            Me.Execute_NonQuery(CommandType.StoreProcedure, "ForTMS_TMSTerminal_Insert3", parTERMINAL_ID, parSIGNATURE, parNAME, parREGISTRATION_DATE, parTYPE, parSTATUS, parCATEGORY, parDESCRIPTION, parPARENT_ID, parCOMMS)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ForTMS_TMSTerminal_Update_ByTerminalID(ByVal TERMINAL_ID As String, ByVal REGISTRATION_DATE As Date, ByVal PARENT_ID As String)
        Try
            Dim parTERMINAL_ID As New OracleParameter("@TERMINAL_ID", OracleDbType.Varchar2, 50)
            parTERMINAL_ID.Value = TERMINAL_ID
            Dim parREGISTRATION_DATE As New OracleParameter("@REGISTRATION_DATE", OracleDbType.Varchar2, 10)
            parREGISTRATION_DATE.Value = REGISTRATION_DATE
            Dim parPARENT_ID As New OracleParameter("@PARENT_ID", OracleDbType.Varchar2, 50)
            parPARENT_ID.Value = PARENT_ID


            Me.Execute_NonQuery(CommandType.StoreProcedure, "ForTMS_TMSTerminal_Update_ByTerminalID", parTERMINAL_ID, parREGISTRATION_DATE, parPARENT_ID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ForTMS_TMSTerminal_MAXTerminalID() As DataTable
        Try
            Dim dt As New DataTable


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_MAXTerminalID", dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_TMSTerminal_GetBySerail(ByVal SIGNATURE As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSIGNATURE As New OracleParameter("@SIGNATURE", OracleDbType.Varchar2)
            parSIGNATURE.Value = SIGNATURE


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_GetBySerail", dt, parSIGNATURE)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_TMSTerminal_GetByCityID(ByVal SIGNATURE As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSIGNATURE As New OracleParameter("@SIGNATURE", OracleDbType.Varchar2, 50)
            parSIGNATURE.Value = SIGNATURE


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_GetByCityID", dt, parSIGNATURE)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_TMSTerminal_GetByStateID(ByVal SIGNATURE As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSIGNATURE As New OracleParameter("@SIGNATURE", OracleDbType.Varchar2, 50)
            parSIGNATURE.Value = SIGNATURE


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_GetByStateID", dt, parSIGNATURE)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_GetInfoBySerial_SP(ByVal Serial_vc As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSerial_vc As New OracleParameter("@Serial_vc", OracleDbType.Varchar2)
            parSerial_vc.Value = Serial_vc


            Me.Fill(CommandType.StoreProcedure, "ForTMS_GetInfoBySerial_SP", dt, parSerial_vc)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
