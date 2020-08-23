
Imports Oracle.DataAccess.Client

Namespace Eniac.PSP.DAL

    Public Class AgentMonthlyGoalsClass

#Region "Global Member"
        Dim cmdSql As New OracleCommand
        Dim daSql As OracleDataAdapter

        Dim cnSql As New OracleConnection(ConnectionString)

        'Dim trSql As SqlTransaction

#End Region

        Public Function SelectAll() As DataTable


            Dim StrSql As String = ""
            Dim dt As New DataTable

            StrSql &= " SELECT S.Name_nvc As StateName, V.FirstName_nvc || ' ' || LastName_nvc As AgentName, "
            StrSql &= " AgentMonthlyGoalsID ,AMG.StateId ,AMG.AgentId "
            StrSql &= " ,FirstMonthPromise ,SecondMonthPromise ,ThirdMonthPromise FROM tblAgentMonthlyGoals AMG"
            StrSql &= " Inner Join Visitor_T V"
            StrSql &= " ON AMG.AgentID =  V.VisitorId "
            StrSql &= " Inner Join State_T S "
            StrSql &= " On AMG.StateId = S.StateID"

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

            StrSql &= " SELECT [AgentMonthlyGoalsID]"
            StrSql &= " ,[StateId]"
            StrSql &= " ,[AgentId] "
            StrSql &= " ,[FirstMonthPromise]"
            StrSql &= " ,[SecondMonthPromise]"
            StrSql &= " ,[ThirdMonthPromise]"
            StrSql &= " FROM([tblAgentMonthlyGoals])"

            StrSql &= " Where AgentMonthlyGoalsID = " & Id

            cmdSql.CommandText = StrSql
            daSql = New OracleDataAdapter(StrSql, cnSql)
            daSql.Fill(dt)

            Return dt

        End Function

        Public Function InsertAndReturnLastInsertedIdentity(ByVal MyStructure As Eniac.PSP.Structure.AgentMonthlyGoalsStructure) As Integer

            Dim SeqSql As String = "Select AGENTMONTHLYGOAL_SEQ.Nextval from Dual"

            Dim AGENTMONTHLYGOALSID As Int64
            Dim dt As New DataTable
            daSql = New OracleDataAdapter(SeqSql, cnSql)
            daSql.Fill(dt)

            AGENTMONTHLYGOALSID = Int64.Parse(dt.Rows(0).Item(0).ToString())

            Dim StrSql As String = ""

            StrSql &= " INSERT INTO tblAgentMonthlyGoals"
            StrSql &= " (AGENTMONTHLYGOALSID, StateId"
            StrSql &= " ,AgentId"
            StrSql &= " ,FirstMonthPromise"
            StrSql &= " ,SecondMonthPromise"
            StrSql &= " ,ThirdMonthPromise)"
            StrSql &= " VALUES ("
            StrSql &= AGENTMONTHLYGOALSID & ","
            StrSql &= "'" & MyStructure.StateId & "',"
            StrSql &= MyStructure.AgentId & ","
            StrSql &= MyStructure.FirstMonthPromise & ","
            StrSql &= MyStructure.SecondMonthPromise & ","
            StrSql &= MyStructure.ThirdMonthPromise
            StrSql &= ")"

            cmdSql.CommandText = StrSql
            cmdSql.Connection = cnSql

            cnSql.Open()

            'trSql = cnSql.BeginTransaction()
            'cmdSql.Transaction = trSql

            Try

                cmdSql.ExecuteNonQuery()

                'cmdSql.ExecuteScalar()
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

                StrSql &= " Select FirstName_nvc ||  ' ' || LastName_nvc As Name,"
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
            strSql &= " Delete From tblAgentMonthlyGoals "
            strSql &= " Where AgentMonthlyGoalsID = " & Id

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
        Public Sub Update(ByVal MyStructure As Eniac.PSP.Structure.AgentMonthlyGoalsStructure, ByVal Id As Integer)

            Dim strSql As String = ""

            strSql &= " UPDATE tblAgentMonthlyGoals "
            strSql &= "SET StateId = '" & MyStructure.StateId & "'"
            strSql &= ",AgentId = " & MyStructure.AgentId
            strSql &= ",FirstMonthPromise = " & MyStructure.FirstMonthPromise
            strSql &= ",SecondMonthPromise = " & MyStructure.SecondMonthPromise
            strSql &= ",ThirdMonthPromise = " & MyStructure.ThirdMonthPromise
            strSql &= " WHERE AgentMonthlyGoalsID = " & Id

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


        Public Function CheckConnectionString() As DataTable

            'این روتین فقط برای جک کردن کانکشن استرینگ نوشته شده است و 
            'و هیچ ارتباطی به کلاس جاری ندارد و در فرم تنظیمات دیتابیس مورد 
            'استفاده قرار گرفته است

            Dim StrSql As String = ""
            Dim dt As New DataTable

            StrSql &= " Select FirstName_nvc ||  ' ' || LastName_nvc As Name,"
            StrSql &= " VisitorId As Id From Visitor_T "

            cmdSql.CommandText = StrSql
            daSql = New OracleDataAdapter(StrSql, cnSql)
            daSql.Fill(dt)

            Return dt

        End Function
    End Class

End Namespace
Namespace Eniac.PSP.Structure
    Public Structure AgentMonthlyGoalsStructure

        Public AgentMonthlyGoalsID As Integer
        Public StateId As String
        Public AgentId As Integer
        Public FirstMonthPromise As Integer
        Public SecondMonthPromise As Integer
        Public ThirdMonthPromise As Integer

    End Structure
End Namespace


