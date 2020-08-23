Imports Oracle.DataAccess.Client

Public Class ClassDALVariz
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarVariz_HistoryID As Int64
    Private mvarAccountNo_vc As String
    Private mvarAmount_num As Decimal
    Private mvarTRANSACTION_TIME_FA As String
    Private mvarTRANSACTION_ID As Int32
    Private mvarStatus As Int16
    Private mvarVariz_Date_vc As String

    Private mvarCorrectAccountNo_vc As String
    Private mvarDescription_nvc As String


    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub


#Region "Property"
    Public Property Variz_HistoryID() As Int64
        Get
            Return mvarVariz_HistoryID
        End Get
        Set(ByVal value As Int64)
            mvarVariz_HistoryID = value
        End Set
    End Property
    Public Property AccountNo_vc() As String
        Get
            Return mvarAccountNo_vc
        End Get
        Set(ByVal value As String)
            mvarAccountNo_vc = value
        End Set
    End Property
    Public Property Amount_num() As Decimal
        Get
            Return mvarAmount_num
        End Get
        Set(ByVal value As Decimal)
            mvarAmount_num = value
        End Set
    End Property
    Public Property TRANSACTION_TIME_FA() As String
        Get
            Return mvarTRANSACTION_TIME_FA
        End Get
        Set(ByVal value As String)
            mvarTRANSACTION_TIME_FA = value
        End Set
    End Property
    Public Property TRANSACTION_ID() As Int64
        Get
            Return mvarTRANSACTION_ID
        End Get
        Set(ByVal value As Int64)
            mvarTRANSACTION_ID = value
        End Set
    End Property
    Public Property Status() As Int16
        Get
            Return mvarStatus
        End Get
        Set(ByVal value As Int16)
            mvarStatus = value
        End Set
    End Property
    Public Property Variz_Date_vc() As String
        Get
            Return mvarVariz_Date_vc
        End Get
        Set(ByVal value As String)
            mvarVariz_Date_vc = value
        End Set
    End Property


    Public Property CorrectAccountNo_vc() As String
        Get
            Return mvarCorrectAccountNo_vc
        End Get
        Set(ByVal value As String)
            mvarCorrectAccountNo_vc = value
        End Set
    End Property

    Public Property Description_nvc() As String
        Get
            Return mvarDescription_nvc
        End Get
        Set(ByVal value As String)
            mvarDescription_nvc = value
        End Set
    End Property

#End Region
#Region "Methods"

    Public Function GetByVariz_DateVariz_History(ByVal Variz_Date_vc As String) As DataTable
        Try
            Dim dt As New DataTable

            Dim parVariz_Date_vc As New OracleParameter("Variz_Date_vc_", OracleDbType.Varchar2, 10)
            parVariz_Date_vc.Value = Variz_Date_vc
            'GetByVariz_DateVariz_History_SP
            strSQL = "GetByVariz_DateVariz_Hist_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parVariz_Date_vc)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByTRANSACTIONTIMEFA_AND_TRANSACTIONIDVariz() As DataTable
        Try
            Dim dt As New DataTable

            Dim parTRANSACTION_TIME_FA As New OracleParameter("TRANSACTION_TIME_FA_", OracleDbType.Varchar2, 19)
            parTRANSACTION_TIME_FA.Value = TRANSACTION_TIME_FA
            Dim parTRANSACTION_ID As New OracleParameter("TRANSACTION_ID_", OracleDbType.Int64)
            parTRANSACTION_ID.Value = TRANSACTION_ID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'GetByTRANSACTIONTIMEFA_AND_TRANSACTIONIDVariz_SP
            strSQL = "GetByTRANTIME_TRANID_Variz_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parTRANSACTION_TIME_FA, parTRANSACTION_ID, parRefCursor)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertVariz_History()
        Try
            Dim parAccountNo_vc As New OracleParameter("AccountNo_vc_", OracleDbType.Varchar2, 20)
            parAccountNo_vc.Value = AccountNo_vc
            Dim parAmount_num As New OracleParameter("Amount_num_", OracleDbType.Decimal)
            parAmount_num.Value = Amount_num
            Dim parTRANSACTION_TIME_FA As New OracleParameter("TRANSACTION_TIME_FA_", OracleDbType.Varchar2, 19)
            parTRANSACTION_TIME_FA.Value = TRANSACTION_TIME_FA
            Dim parTRANSACTION_ID As New OracleParameter("TRANSACTION_ID_", OracleDbType.Int64)
            parTRANSACTION_ID.Value = TRANSACTION_ID
            Dim parStatus As New OracleParameter("Status_", OracleDbType.Int16)
            parStatus.Value = Status
            Dim parVariz_Date_vc As New OracleParameter("Variz_Date_vc_", OracleDbType.Varchar2, 10)
            parVariz_Date_vc.Value = Variz_Date_vc


            strSQL = "InsertVariz_History_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parAccountNo_vc, parAmount_num, parTRANSACTION_TIME_FA, parTRANSACTION_ID, parStatus, parVariz_Date_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertVariz()
        Try
            Dim parTRANSACTION_TIME_FA As New OracleParameter("TRANSACTION_TIME_FA_", OracleDbType.Varchar2, 19)
            parTRANSACTION_TIME_FA.Value = TRANSACTION_TIME_FA
            Dim parTRANSACTION_ID As New OracleParameter("TRANSACTION_ID_", OracleDbType.Int64)
            parTRANSACTION_ID.Value = TRANSACTION_ID
            Dim parStatus As New OracleParameter("Status_", OracleDbType.Int16)
            parStatus.Value = Status
            Dim parVariz_Date_vc As New OracleParameter("Variz_Date_vc_", OracleDbType.Varchar2, 10)
            parVariz_Date_vc.Value = Variz_Date_vc


            strSQL = "InsertVariz_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parTRANSACTION_TIME_FA, parTRANSACTION_ID, parStatus, parVariz_Date_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateVariz()
        Try
            Dim parTRANSACTION_TIME_FA As New OracleParameter("TRANSACTION_TIME_FA_", OracleDbType.Varchar2, 19)
            parTRANSACTION_TIME_FA.Value = TRANSACTION_TIME_FA
            Dim parTRANSACTION_ID As New OracleParameter("TRANSACTION_ID_", OracleDbType.Int64)
            parTRANSACTION_ID.Value = TRANSACTION_ID
            Dim parStatus As New OracleParameter("Status_", OracleDbType.Int16)
            parStatus.Value = Status
            Dim parVariz_Date_vc As New OracleParameter("Variz_Date_vc_", OracleDbType.Varchar2, 10)
            parVariz_Date_vc.Value = Variz_Date_vc


            strSQL = "UpdateVariz_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parTRANSACTION_TIME_FA, parTRANSACTION_ID, parStatus, parVariz_Date_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetForReport(ByVal FromVariz_Date_vc As String, ByVal ToVariz_Date_vc As String, ByVal Status As Short) As DataTable
        Try
            Dim dt As New DataTable
            Dim strSql As String


            strSql = "  SELECT Variz_History_T.Variz_HistoryID, ContractingParty_T.FirstName_nvc || ' ' || ContractingParty_T.LastName_nvc AS AcountOwner, "
            strSql &= " Account_T.AccountNO_vc, Visitor_T.LastName_nvc AS AgentName, Store_T.Name_nvc AS StorName, City_T.Name_nvc AS CityName, "
            strSql &= " Device_T.Switch_TerminalID_vc, Pos_T.Serial_vc, NVL(Variz_History_T.CorrectAccountNo_vc, '') AS CorrectAccountNo, "
            strSql &= " NVL(Variz_History_T.Description_nvc, '') AS Description"
            strSql &= " FROM  ContractingParty_T INNER JOIN"
            strSql &= " Contract_T ON ContractingParty_T.ContractingPartyID = Contract_T.ContractingPartyID INNER JOIN"
            strSql &= " Account_T ON Contract_T.ContractID = Account_T.ContractID INNER JOIN"
            strSql &= " Store_T ON Account_T.AccountID = Store_T.AccountID INNER JOIN"
            strSql &= " Device_T ON Store_T.StoreID = Device_T.StoreID INNER JOIN"
            strSql &= " Visitor_T ON Contract_T.VisitorID = Visitor_T.VisitorID INNER JOIN"
            strSql &= " City_T ON ContractingParty_T.CityID = City_T.CityID AND Store_T.CityID = City_T.CityID INNER JOIN"
            strSql &= " Variz_History_T ON Variz_History_T.AccountNo_vc = Account_T.AccountNO_vc LEFT OUTER JOIN"
            strSql &= " Pos_T ON Device_T.PosID = Pos_T.PosID"

            strSql &= " Where 1 = 1 "

            If FromVariz_Date_vc.Trim <> "" Then
                strSql &= " And Variz_History_T.Variz_Date_vc >=   '" & FromVariz_Date_vc & "'"
            End If

            If ToVariz_Date_vc.Trim <> "" Then
                strSql &= " And Variz_History_T.Variz_Date_vc <=  '" & ToVariz_Date_vc & "'"
            End If

            If Status <> 2 Then
                strSql &= " And Variz_History_T.Status = " & Status
            End If


            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.Text, strSql, dt)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub UpdateVariz_CorrectAccountNo_Description()
        Try

            Dim parVariz_HistoryId As New OracleParameter("Variz_HistoryID_", OracleDbType.Int64)
            parVariz_HistoryId.Value = Variz_HistoryID

            Dim parCorrectAccountNo As New OracleParameter("CorrectAccountNo_vc_", OracleDbType.Varchar2, 20)
            parCorrectAccountNo.Value = CorrectAccountNo_vc

            Dim parDescription As New OracleParameter("Description_nvc_", OracleDbType.Varchar2, 1000)
            parDescription.Value = Description_nvc
            'UpdateVariz_CorrectAccountNo_Desc_SP
            strSQL = "UpdateVariz_CorrectAccNo_Desc"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parVariz_HistoryId, parCorrectAccountNo, parDescription)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
