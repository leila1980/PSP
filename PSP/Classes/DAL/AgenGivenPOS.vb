
Imports Oracle.DataAccess.Client

Namespace Eniac.PSP.DAL

    Public Class AgentGivenPOS

#Region "Global Member"
        Dim cmdSql As New OracleCommand
        Dim daSql As OracleDataAdapter

        Dim cnSql As New OracleConnection(ConnectionString)

        'Dim trSql As SqlTransaction

#End Region

        Public Function SelectAll() As DataTable

            Dim StrSql As String = ""
            Dim dt As New DataTable

            StrSql &= " SELECT AgentGivenPosId, "
            StrSql &= " V.FirstName_nvc || ' ' || V.LastName_nvc As AgentName"
            StrSql &= " ,AG.AgentId "
            StrSql &= " ,CountOfGivenpos"
            StrSql &= " ,DateOfGivenPos"
            StrSql &= " FROM tblAgentGivenPOS  AG "
            StrSql &= " Inner Join Visitor_T  V"
            StrSql &= " ON AG.AgentID=  V.VisitorId "

            Try

                cmdSql.CommandText = StrSql
                daSql = New OracleDataAdapter(StrSql, cnSql)
                daSql.Fill(dt)

                Return dt

                'Catch When Err.Number = 5

                '    MessageBox.Show("اطلاعات وارد شده در قسمت تنظیمات دیتابیس معتبر نمیباشند")

            Catch Ex As Exception
                MessageBox.Show(Ex.Message)
            End Try

        End Function
        Public Function SelectAllById(ByVal Id As Integer) As DataTable

            Dim StrSql As String = ""
            Dim dt As New DataTable

            StrSql &= " SELECT AgentGivenPosId, "
            StrSql &= " V.FistName_nvc || ' ' || V.LastName_nvc As AgentName"
            StrSql &= " ,AG.AgentId "
            StrSql &= " ,CountOfGivenpos"
            StrSql &= " ,DateOfGivenPos"
            StrSql &= " FROM tblAgentGivenPOS AG"
            StrSql &= " Inner Join Visitor_T V"
            StrSql &= " ON AG.AgentID = V.AgentId "
            StrSql &= " Where AgentPerformanceId = " & Id

            cmdSql.CommandText = StrSql
            daSql = New OracleDataAdapter(StrSql, cnSql)
            daSql.Fill(dt)

            Return dt

        End Function

        Public Function InsertAndReturnLastInsertedIdentity(ByVal MyStructure As Eniac.PSP.Structure.AgentGivenPOS) As Integer

            Dim SeqSql As String = "Select AGENTGIVENPOS_SEQ.Nextval from Dual"
            Dim AgentGivenPOSID As Int64

            Dim dt As New DataTable
            daSql = New OracleDataAdapter(SeqSql, cnSql)
            daSql.Fill(dt)

            AgentGivenPOSID = Int64.Parse(dt.Rows(0).Item(0).ToString())


            Dim StrSql As String = ""

            StrSql &= " INSERT INTO tblAgentGivenPOS "
            StrSql &= " (AGENTGIVENPOSID, AgentId"
            StrSql &= " ,CountOfGivenpos"
            StrSql &= " ,DateOfGivenPos)"
            StrSql &= " VALUES "
            StrSql &= " ( "
            StrSql &= AgentGivenPOSID
            StrSql &= "," & MyStructure.AgentId
            StrSql &= "," & MyStructure.CountOfGivenpos
            StrSql &= " , '" & MyStructure.DateOfGivenPos & "')"

            Try
                cmdSql.CommandText = StrSql
                cmdSql.Connection = cnSql

                cnSql.Open()

                'trSql = cnSql.BeginTransaction()
                'cmdSql.Transaction = trSql

                cmdSql.ExecuteNonQuery()


                'trSql.Commit()

                Return AgentGivenPOSID

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                'trSql.Rollback()
            Finally
                cnSql.Close()
            End Try

        End Function
        Public Function SelectVisitor() As DataTable

            Try

                Dim StrSql As String = ""
                Dim dt As New DataTable

                'StrSql &= " SELECT AgentID As 'Id'"
                'StrSql &= " , Name_nvc as 'Name' "
                'StrSql &= " FROM Agent_T "

                StrSql &= " Select FirstName_nvc || ' ' || LastName_nvc As Name,"
                StrSql &= " VisitorId As Id From Visitor_T "

                cmdSql.CommandText = StrSql
                daSql = New OracleDataAdapter(StrSql, cnSql)
                daSql.Fill(dt)

                Return dt

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End Function

        Public Function Delete(ByVal Id As Integer) As Boolean

            Dim strSql As String = ""
            strSql &= " Delete From tblAgentGivenPOS "
            strSql &= " Where AgentGivenPOSId = " & Id

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
        Public Sub Update(ByVal MyStructure As Eniac.PSP.Structure.AgentGivenPOS, ByVal Id As Integer)

            Dim strSql As String = ""

            strSql &= " Update tblAgentGivenPOS "
            strSql &= "  SET AgentId = " & MyStructure.AgentId
            strSql &= " ,CountOfGivenPOS = " & MyStructure.CountOfGivenpos
            strSql &= " ,DateOfGivenPOS = '" & MyStructure.DateOfGivenPos & "'"
            strSql &= " WHERE  AgentGivenPOSId = " & Id

            Try

                cmdSql.CommandText = strSql
                cmdSql.Connection = cnSql
                cnSql.Open()
                cmdSql.ExecuteNonQuery()
                cnSql.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End Sub

    End Class

End Namespace
Namespace Eniac.PSP.Structure
    Public Structure AgentGivenPOS

        Public AgentGiventPosId As Integer
        Public AgentId As Integer
        Public CountOfGivenpos As Integer
        Public DateOfGivenPos As String

    End Structure
End Namespace
