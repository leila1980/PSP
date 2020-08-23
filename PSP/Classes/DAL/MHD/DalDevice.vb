Imports Oracle.DataAccess.Client

Partial Class Dal
    Public Structure DeviceTemplate
        Dim DeviceID As Int64
        Dim StoreID As Int64
        Dim Code_vc As String
        Dim Outlet_vc As String
        Dim Merchant_vc As String
        Dim Vat_vc As String
        Dim Password_vc As String
        Dim QrCodeStatus As Int16
    End Structure

    ''' <summary>
    ''' دستگاه فعلی پز را برمی گرداند 
    ''' </summary>
    ''' <param name="PosID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDeviceByPosID(ByVal PosID As Int64) As DeviceTemplate
        Try
            Dim Device As DeviceTemplate
            Device.DeviceID = 0

            Dim dt As New DataTable

            Dim parPosID As New OracleParameter("@PosID", OracleDbType.Int64)
            parPosID.Value = PosID

            Dim strSQL As String = "Select * From DevicePos_Device_PosAssigning_V Where PosID=@PosID And Count_int=1"
            Me.Fill(CommandType.Text, strSQL, dt, parPosID)

            If dt.Rows.Count > 0 Then
                Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
                parDeviceID.Value = dt.Rows(0).Item("DeviceID")

                strSQL = "Select * From Device_T Where DeviceID=@DeviceID"
                dt.Rows.Clear()
                dt.Columns.Clear()

                Me.Fill(CommandType.Text, strSQL, dt, parDeviceID)

                If dt.Rows.Count > 0 Then
                    Device.DeviceID = dt.Rows(0).Item("DeviceID")
                    Device.StoreID = dt.Rows(0).Item("StoreID")
                    Device.Code_vc = dt.Rows(0).Item("Code_vc")
                    Device.Outlet_vc = dt.Rows(0).Item("Outlet_vc")
                    Device.Merchant_vc = dt.Rows(0).Item("Merchant_vc").ToString
                    Device.Vat_vc = dt.Rows(0).Item("Vat_vc").ToString
                    Device.Password_vc = dt.Rows(0).Item("Password_vc").ToString
                End If
            End If
            Return Device
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetContractByDeviceID(ByVal DeviceID As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim strSQL As String = "Select * From Contract_Account_Store_Device_PURE_V Where DDeviceID=@DeviceID"
            Me.Fill(CommandType.Text, strSQL, dt, parDeviceID)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Update(ByVal Device As DeviceTemplate)
        Try
            Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
            parDeviceID.Value = Device.DeviceID

            Dim parStoreID As New OracleParameter("@StoreID", OracleDbType.Int64)
            parStoreID.Value = Device.StoreID

            Dim parCode_vc As New OracleParameter("@Code_vc", OracleDbType.Varchar2, 8)
            parCode_vc.Value = Device.Code_vc

            Dim parOutlet_vc As New OracleParameter("@Outlet_vc", OracleDbType.Varchar2, 12)
            parOutlet_vc.Value = Device.Outlet_vc

            Dim parMerchant_vc As New OracleParameter("@Merchant_vc", OracleDbType.Varchar2, 12)
            parMerchant_vc.Value = Device.Merchant_vc

            Dim parVat_vc As New OracleParameter("@Vat_vc", OracleDbType.Varchar2, 15)
            parVat_vc.Value = Device.Vat_vc

            Dim parPassword_vc As New OracleParameter("@Password_vc", OracleDbType.Varchar2, 20)
            parPassword_vc.Value = Device.Password_vc

            Dim strSQL As String = "Update Device_T Set "
            strSQL += "StoreID=@StoreID,Code_vc=@Code_vc,Outlet_vc=@Outlet_vc,Merchant_vc=@Merchant_vc,"
            strSQL += "Vat_vc=@Vat_vc Where DeviceId=@DeviceId"

            Me.Execute_NonQuery(CommandType.Text, strSQL, parDeviceID, parStoreID, parCode_vc, parOutlet_vc, parMerchant_vc, parVat_vc, parPassword_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

   

End Class
