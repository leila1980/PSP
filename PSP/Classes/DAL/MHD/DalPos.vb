Imports Oracle.DataAccess.Client

Partial Class Dal

    Public Structure PosTemplate
        Dim PosID As Int64
        Dim Serial_vc As String
        Dim PropertyNo_vc As String
        Dim EniacCode_vc As String
        Dim Active_tint As Int16
    End Structure

    ''' <summary>
    ''' براساس شماره سریال پز مشخصات پز را برمیگرداند
    ''' </summary>
    ''' <param name="Serial"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPosBySerial(ByVal Serial As String) As PosTemplate
        Try
            Dim Pos As PosTemplate
            Pos.PosID = 0

            Dim dt As New DataTable

            Dim parSerial As New OracleParameter("@Serial_vc", OracleDbType.Varchar2, 20)
            parSerial.Value = Serial

            Dim strSQL As String = "Select * From Pos_T Where Serial_vc=@Serial_vc"
            Me.Fill(CommandType.Text, strSQL, dt, parSerial)

            If dt.Rows.Count > 0 Then
                Pos.PosID = dt.Rows(0).Item("PosID")
                Pos.Serial_vc = dt.Rows(0).Item("Serial_vc")
                Pos.PropertyNo_vc = dt.Rows(0).Item("PropertyNo_vc")
                Pos.EniacCode_vc = dt.Rows(0).Item("EniacCode_vc")
                Pos.Active_tint = dt.Rows(0).Item("Active_tint")
            End If
            Return Pos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
