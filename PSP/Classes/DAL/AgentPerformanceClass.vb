
Imports Oracle.DataAccess.Client

Namespace Eniac.PSP.DAL

    Public Class AgentPerformanceClass

#Region "Global Member"

        Dim cmdSql As New OracleCommand
        Dim daSql As OracleDataAdapter

        Dim cnSql As New OracleConnection(ConnectionString)

        'Dim trSql As SqlTransaction

#End Region

        Public Function SelectAll() As DataTable


            Dim StrSql As String = ""
            Dim dt As New DataTable

            StrSql &= " SELECT AgentPerformanceId,S.Name_nvc As StateName, "
            StrSql &= " V.FirstName_nvc || ' ' || V.LastName_nvc As AgentName"
            StrSql &= " ,AP.AgentId "
            StrSql &= " ,AP.StateId "
            StrSql &= " ,ConfirmedNumber"
            StrSql &= " ,CompletedContractNumber"
            StrSql &= " ,ReportDate"
            StrSql &= " FROM tblAgentPerformance  AP "
            StrSql &= " Inner Join Visitor_T  V"
            StrSql &= " ON AP.AgentID =  V.VisitorId "
            StrSql &= " Inner Join State_T  S "
            StrSql &= " On AP.StateId = S.StateID"

            Try

                cmdSql.CommandText = StrSql
                daSql = New OracleDataAdapter(StrSql, cnSql)
                daSql.Fill(dt)

                Return dt

            Catch When Err.Number = 5

                MessageBox.Show("اطلاعات وارد شده در قسمت تنظیمات دیتابیس معتبر نمیباشند")

            Catch Ex As Exception
                MessageBox.Show(Ex.Message)
            End Try

        End Function
        Public Function SelectAllById(ByVal Id As Integer) As DataTable

            Dim StrSql As String = ""
            Dim dt As New DataTable

            StrSql &= " SELECT [AgentPerformanceId],S.Name_nvc As 'StateName', "
            StrSql &= " V.FistName_nvc + Space(1) + V.LastName_nvc As 'AgentName'"
            StrSql &= " ,AP.AgentId "
            StrSql &= " ,AP.StateId "
            StrSql &= " ,[ConfirmedNumber]"
            StrSql &= " ,[CompletedContractNumber]"
            StrSql &= " ,[ReportDate]"
            StrSql &= " FROM([tblAgentPerformance] As AP)"
            StrSql &= " Inner Join dbo.Visitor_T As V"
            StrSql &= " ON AMG.AgentID = A.AgentId "
            StrSql &= " Inner Join dbo.State_T As S "
            StrSql &= " On AMG.StateId = S.StateID"

            StrSql &= " Where AgentPerformanceId = " & Id

            cmdSql.CommandText = StrSql
            daSql = New OracleDataAdapter(StrSql, cnSql)
            daSql.Fill(dt)

            Return dt

        End Function

        Public Function InsertAndReturnLastInsertedIdentity(ByVal MyStructure As Eniac.PSP.Structure.AgentPerformanceStructure) As Integer


            Dim SeqSql As String = "Select AGENTPERFORMANCE_SEQ.Nextval from Dual"

            Dim AGENTMONTHLYGOALSID As Int64

            Dim dt As New DataTable
            daSql = New OracleDataAdapter(SeqSql, cnSql)
            daSql.Fill(dt)

            AGENTMONTHLYGOALSID = Int64.Parse(dt.Rows(0).Item(0).ToString())
 

            Dim StrSql As String = ""

            StrSql &= " INSERT INTO tblAgentPerformance "
            StrSql &= " (AGENTPERFORMANCEID,AgentId"
            StrSql &= " ,StateId"
            StrSql &= " ,ConfirmedNumber"
            StrSql &= " ,CompletedContractNumber"
            StrSql &= " ,ReportDate)"
            StrSql &= " VALUES "
            StrSql &= " ("
            StrSql &= AGENTMONTHLYGOALSID
            StrSql &= "," & MyStructure.AgentId
            StrSql &= ",'" & MyStructure.StateId & "'"
            StrSql &= "," & MyStructure.ConfirmedNumber
            StrSql &= " ," & MyStructure.CompletedContractNumber
            StrSql &= " , '" & MyStructure.ReportDate & "')"

            Try
                cmdSql.CommandText = StrSql
                cmdSql.Connection = cnSql

                cnSql.Open()

                'trSql = cnSql.BeginTransaction()
                'cmdSql.Transaction = trSql

                cmdSql.ExecuteNonQuery()

                'trSql.Commit()

                Return AGENTMONTHLYGOALSID

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
        Public Function SelectState() As DataTable

            Dim StrSql As String = ""
            Dim dt As New DataTable

            StrSql &= " SELECT StateID As Id "
            StrSql &= " ,Name_nvc As Name "
            StrSql &= " FROM State_T "

            Try

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
            strSql &= " Delete From tblAgentPerformance "
            strSql &= " Where AgentPerformanceId = " & Id

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
        Public Sub Update(ByVal MyStructure As Eniac.PSP.Structure.AgentPerformanceStructure, ByVal Id As Integer)

            Dim strSql As String = ""

            strSql &= " Update tblAgentPerformance "
            strSql &= "  SET AgentId = " & MyStructure.AgentId
            strSql &= " ,StateId =  '" & MyStructure.StateId & "'"
            strSql &= " ,ConfirmedNumber = " & MyStructure.ConfirmedNumber
            strSql &= " ,CompletedContractNumber = " & MyStructure.CompletedContractNumber
            strSql &= " ,ReportDate = '" & MyStructure.ReportDate & "'"
            strSql &= " WHERE  AgentPerformanceId  = " & Id

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
    Public Structure AgentPerformanceStructure

        Public AgentPerformanceId As Integer
        Public StateId As String
        Public AgentId As Integer
        Public ConfirmedNumber As Integer
        Public CompletedContractNumber As Integer
        Public ReportDate As String

    End Structure
End Namespace
