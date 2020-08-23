Imports Oracle.DataAccess.Client

Public Class ClassDALCallCenterInfo
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    Friend Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
    Friend Function GetByTypeReqResDesc(ByVal Type As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parType As New OracleParameter("@Type", OracleDbType.Int16)
            parType.Value = Type

            strSQL = "GetByTypeReqResDesc_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parType)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Friend Function GetByNameAndTypeReqResDesc(ByVal Name As String, ByVal Type As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parName_nvc As New OracleParameter("@Name_nvc", OracleDbType.Varchar2, 500)
            parName_nvc.Value = Name
            Dim parType As New OracleParameter("@Type", OracleDbType.Int16)
            parType.Value = Type

            strSQL = "GetByNameAndTypeReqResDesc_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parName_nvc, parType)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Friend Function GetAllRefrence() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "GetAllRefrence_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Friend Function InsertReqResDesc(ByVal Name_nvc As String, ByVal Type As Int16) As Int32
        Try
            Dim parType As New OracleParameter("Type_", OracleDbType.Int16)
            parType.Value = Type
            Dim parName_nvc As New OracleParameter("Name_nvc_", OracleDbType.NVarchar2, 500)
            parName_nvc.Value = Name_nvc

            Dim parID As New OracleParameter("ID_", OracleDbType.Int32)
            parID.Direction = ParameterDirection.Output

            strSQL = "InsertReqResDesc_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parName_nvc, parType, parID)
            Return parID.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Friend Function InsertCallsInfo(ByVal Completed As Int16, ByVal ReferTo As Int32, ByVal RequestDesc As String, ByVal ResponsDesc As String, ByVal CallDate_vc As String, ByVal CallTime_vc As String, ByVal Moghayerat_Amount_num As Decimal, ByVal Moghayerat_Amount2_num As Decimal, ByVal Moghayerat_CustomerName_nvc As String, ByVal Moghayerat_CardNo_vc As String, ByVal Moghayerat_Tel_vc As String, ByVal Moghayerat_TranDate_vc As String, ByVal Moghayerat_TranTime_vc As String, ByVal DeviceID As Int64, ByVal posid As Int64, ByVal EniacCode_vc As String) As Int64
        Try
            Dim parCompleted As New OracleParameter("Completed", OracleDbType.Int16)
            parCompleted.Value = Completed
            Dim parReferTo As New OracleParameter("ReferTo", OracleDbType.Int32)
            parReferTo.Value = IIf(ReferTo = -1, DBNull.Value, ReferTo)
            Dim parRequestDesc As New OracleParameter("RequestDesc", OracleDbType.Varchar2, 500)
            parRequestDesc.Value = RequestDesc
            Dim parResponsDesc As New OracleParameter("ResponsDesc", OracleDbType.Varchar2, 500)
            parResponsDesc.Value = ResponsDesc
            Dim parCallDate_vc As New OracleParameter("CallDate_vc", OracleDbType.Varchar2, 10)
            parCallDate_vc.Value = CallDate_vc
            Dim parCallTime_vc As New OracleParameter("CallTime_vc", OracleDbType.Varchar2, 5)
            parCallTime_vc.Value = CallTime_vc
            Dim parMoghayerat_Amount_num As New OracleParameter("Moghayerat_Amount_num", OracleDbType.Decimal)
            parMoghayerat_Amount_num.Value = IIf(Moghayerat_Amount_num = -1, DBNull.Value, Moghayerat_Amount_num)
            Dim parMoghayerat_Amount2_num As New OracleParameter("@Moghayerat_Amount2_num", OracleDbType.Decimal)
            parMoghayerat_Amount2_num.Value = IIf(Moghayerat_Amount2_num = -1, DBNull.Value, Moghayerat_Amount2_num)
            Dim parMoghayerat_CustomerName_nvc As New OracleParameter("@Moghayerat_CustomerName_nvc", OracleDbType.Varchar2, 100)
            parMoghayerat_CustomerName_nvc.Value = IIf(Moghayerat_CustomerName_nvc = "", DBNull.Value, Moghayerat_CustomerName_nvc)
            Dim parMoghayerat_CardNo_vc As New OracleParameter("@Moghayerat_CardNo_vc", OracleDbType.Varchar2, 20)
            parMoghayerat_CardNo_vc.Value = IIf(Moghayerat_CardNo_vc = "", DBNull.Value, Moghayerat_CardNo_vc)
            Dim parMoghayerat_Tel_vc As New OracleParameter("@Moghayerat_Tel_vc ", OracleDbType.Varchar2, 20)
            parMoghayerat_Tel_vc.Value = IIf(Moghayerat_Tel_vc = "", DBNull.Value, Moghayerat_Tel_vc)
            Dim parMoghayerat_TranDate_vc As New OracleParameter("@Moghayerat_TranDate_vc", OracleDbType.Varchar2, 10)
            parMoghayerat_TranDate_vc.Value = IIf(Moghayerat_TranDate_vc = "", DBNull.Value, Moghayerat_TranDate_vc)
            Dim parMoghayerat_TranTime_vc As New OracleParameter("@Moghayerat_TranTime_vc", OracleDbType.Varchar2, 5)
            parMoghayerat_TranTime_vc.Value = IIf(Moghayerat_TranTime_vc = "", DBNull.Value, Moghayerat_TranTime_vc)
            Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
            parDeviceID.Value = DeviceID
            Dim parposid As New OracleParameter("@posid", OracleDbType.Int64)
            parposid.Value = posid
            Dim parEniacCode_vc As New OracleParameter("@EniacCode_vc", OracleDbType.Varchar2, 20)
            parEniacCode_vc.Value = EniacCode_vc


            Dim parCallID As New OracleParameter("@CallID", OracleDbType.Int64)
            parCallID.Direction = ParameterDirection.Output

            strSQL = "InsertCallsInfo_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parCompleted, parReferTo, parRequestDesc, parResponsDesc, parCallID, parCallDate_vc, parCallTime_vc, parMoghayerat_Amount_num, parMoghayerat_Amount2_num, parMoghayerat_CustomerName_nvc, parMoghayerat_CardNo_vc, parMoghayerat_Tel_vc, parMoghayerat_TranDate_vc, parMoghayerat_TranTime_vc, parDeviceID, parposid, parEniacCode_vc)
            Return parCallID.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Friend Function GetByDeviceIDCallInfo(ByVal DeviceID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByDeviceIDCallInfo_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDeviceID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Friend Function GetByCallIDCallsInfo(ByVal CallID As Int64) As DataTable
        Try
            Dim dt As New DataTable
            Dim parCallID As New OracleParameter("@CallID", OracleDbType.Int64)
            parCallID.Value = CallID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'strSQL = "GetByCallIDCallsInfo_SP"
            strSQL = "GtCallIDCallsInfAndOtherInfSP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCallID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
