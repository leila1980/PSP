
Imports Oracle.DataAccess.Client

Namespace Eniac.PSP.DAL

    Public Class DeviceCancelDesc

#Region "Global Member"
        Dim cmdSql As New OracleCommand
        Dim daSql As OracleDataAdapter
        Dim cnSql As New OracleConnection(ConnectionString)
#End Region

        Public Function SelectAll() As DataTable

            Dim StrSql As String = ""
            Dim dt As New DataTable

            StrSql = " Select DeviceCancelDescId,DeviceCancelDesc From DeviceCancelDesc_T"

            Try

                cmdSql.CommandText = StrSql
                daSql = New OracleDataAdapter(StrSql, cnSql)
                daSql.Fill(dt)

                Return dt

            Catch Ex As Exception
                MessageBox.Show(Ex.Message)
            End Try

        End Function
        Public Function SelectAllById(ByVal Id As Integer) As DataTable

            Dim StrSql As String = ""
            Dim dt As New DataTable

            StrSql &= " SELECT PosCancelDescId,PosCancelDesc From DeviceCancelDesc_T"
            StrSql &= " Where PosCancelDescId = " & Id

            cmdSql.CommandText = StrSql
            daSql = New OracleDataAdapter(StrSql, cnSql)
            daSql.Fill(dt)

            Return dt

        End Function

        Public Function InsertAndReturnLastInsertedIdentity(ByVal MyStructure As Eniac.PSP.Structure.DeviceCancelDesc) As Integer

            Dim SeqSql As String = "Select DEVICECANCELDESC_SEQ.Nextval from Dual"

            Dim DEVICECANCELDESCID As Int64

            Dim dt As New DataTable
            daSql = New OracleDataAdapter(SeqSql, cnSql)
            daSql.Fill(dt)

            DEVICECANCELDESCID = Int64.Parse(dt.Rows(0).Item(0).ToString())


            Dim StrSql As String = ""

            StrSql &= " INSERT INTO DeviceCancelDesc_T "
            StrSql &= "(DEVICECANCELDESCID, DeviceCancelDesc)"
            StrSql &= " VALUES "
            StrSql &= " ( " & DEVICECANCELDESCID
            StrSql &= ", '" & MyStructure.DeviceCancelDesc & "')"

            Try
                cmdSql.CommandText = StrSql
                cmdSql.Connection = cnSql

                cnSql.Open()

                cmdSql.ExecuteNonQuery()

                Return DEVICECANCELDESCID

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                cnSql.Close()
            End Try

        End Function

        Public Function Delete(ByVal Id As Integer) As Boolean

            Dim strSql As String = ""
            strSql &= " Delete From DeviceCancelDesc_T "
            strSql &= " Where DeviceCancelDescId = " & Id

            Try

                cmdSql.CommandText = strSql
                cmdSql.Connection = cnSql
                cnSql.Open()
                cmdSql.ExecuteNonQuery()
                cnSql.Close()

                Return True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return False
            End Try

        End Function
        Public Sub Update(ByVal MyStructure As Eniac.PSP.Structure.DeviceCancelDesc, ByVal Id As Integer)

            Dim strSql As String = ""

            strSql &= " Update DeviceCancelDesc_T "
            strSql &= " set DeviceCancelDesc = '" & MyStructure.DeviceCancelDesc & "'"
            strSql &= " WHERE  DeviceCancelDescId = " & Id

            Try

                cmdSql.CommandText = strSql
                cmdSql.Connection = cnSql
                cnSql.Open()
                cmdSql.ExecuteNonQuery()
                cnSql.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                cnSql.Close()
            End Try

        End Sub

    End Class

End Namespace
Namespace Eniac.PSP.Structure
    Public Structure DeviceCancelDesc
        Public DeviceCancelDescId As Integer
        Public DeviceCancelDesc As String
    End Structure
End Namespace
