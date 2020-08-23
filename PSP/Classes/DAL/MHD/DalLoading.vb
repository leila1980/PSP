Partial Class Dal
    Public Structure LoadingTemplate
        Dim LoadingID As Int64
        Dim PosID As Int64
        Dim DeviceID As Int64
    End Structure

    'Public Function Insert(ByVal Loading As LoadingTemplate) As Int64
    '    Try
    '        Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
    '        parDeviceID.Value = Loading.DeviceID

    '        Dim parPosID As New OracleParameter("@PosID", OracleDbType.Int64)
    '        parPosID.Value = Loading.PosID

    '        Dim strSQL As String
    '        strSQL = "Insert into Loading_T(PosID,DeviceID) values(@PosID,@DeviceID)"
    '        Me.Execute_NonQuery(CommandType.Text, strSQL, parPosID, parDeviceID)

    '        strSQL = "Select @@Identity"
    '        Return Me.Execute_Scalar(CommandType.Text, strSQL, 0)


    '        'Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
    '        'parDeviceID.Value = Loading.DeviceID

    '        'Dim parPosID As New OracleParameter("@PosID", OracleDbType.Int64)
    '        'parPosID.Value = Loading.PosID

    '        'Dim strSQL As String
    '        'strSQL = "Insert into Group_T(GroupID,Name_nvc) values('0123','test')"
    '        'Me.Execute_NonQuery(CommandType.Text, strSQL)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Function GetLoading(ByVal PosID As Int64, ByVal DeviceID As Int64) As Int64
    '    Try
    '        Dim dt As New DataTable

    '        Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
    '        parDeviceID.Value = DeviceID

    '        Dim parPosID As New OracleParameter("@PosID", OracleDbType.Int64)
    '        parPosID.Value = PosID

    '        Dim strSQL As String
    '        strSQL = "Select * From Loading_T Where PosID=@PosID And DeviceID=@DeviceID"
    '        Me.Fill(CommandType.Text, strSQL, dt, parDeviceID, parPosID)

    '        If dt.Rows.Count = 0 Then
    '            Return 0
    '        Else
    '            Return dt.Rows(0).Item("LoadingID")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

End Class