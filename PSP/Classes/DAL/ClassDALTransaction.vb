Imports Oracle.DataAccess.Client

Public Class ClassDALTransaction
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
    Private mvarPC As String
    Private mvarMTI As String
    Private mvarREFERENCE As String
    Private mvarSTAN As String
    Private mvarROUTING_CODE As String
    Private mvarTRANSACTION_TIME_FA As String
    Private mvarTRANSACTION_TIME As String
    Private mvarLOCAL_DATE_FA As String
    Private mvarLOCAL_DATE As String
    Private mvarOUTLET As String
    Private mvarACC_NAME As String
    Private mvarMCC As String
    Private mvarCARD_NUMBER As String
    Private mvarACCOUNT As String
    Private mvarAMOUNT As String
    Private mvarACTION_CODE As String
    Private mvarACTION As String
    Private mvarREVERSAL_FLAG As String


    Public Property PC() As String
        Get
            Return mvarPC
        End Get
        Set(ByVal value As String)
            mvarPC = value
        End Set
    End Property
    Public Property MTI() As String
        Get
            Return mvarMTI
        End Get
        Set(ByVal value As String)
            mvarMTI = value
        End Set
    End Property
    Public Property REFERENCE() As String
        Get
            Return mvarREFERENCE
        End Get
        Set(ByVal value As String)
            mvarREFERENCE = value
        End Set
    End Property
    Public Property STAN() As String
        Get
            Return mvarSTAN
        End Get
        Set(ByVal value As String)
            mvarSTAN = value
        End Set
    End Property
    Public Property ROUTING_CODE() As String
        Get
            Return mvarROUTING_CODE
        End Get
        Set(ByVal value As String)
            mvarROUTING_CODE = value
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
    Public Property TRANSACTION_TIME() As Date
        Get
            Return mvarTRANSACTION_TIME
        End Get
        Set(ByVal value As Date)
            mvarTRANSACTION_TIME = value
        End Set
    End Property
    Public Property LOCAL_DATE_FA() As String
        Get
            Return mvarLOCAL_DATE_FA
        End Get
        Set(ByVal value As String)
            mvarLOCAL_DATE_FA = value
        End Set
    End Property
    Public Property LOCAL_DATE() As Date
        Get
            Return mvarLOCAL_DATE
        End Get
        Set(ByVal value As Date)
            mvarLOCAL_DATE = value
        End Set
    End Property
    Public Property OUTLET() As String
        Get
            Return mvarOUTLET
        End Get
        Set(ByVal value As String)
            mvarOUTLET = value
        End Set
    End Property
    Public Property ACC_NAME() As String
        Get
            Return mvarACC_NAME
        End Get
        Set(ByVal value As String)
            mvarACC_NAME = value
        End Set
    End Property
    Public Property MCC() As String
        Get
            Return mvarMCC
        End Get
        Set(ByVal value As String)
            mvarMCC = value
        End Set
    End Property
    Public Property CARD_NUMBER() As String
        Get
            Return mvarCARD_NUMBER
        End Get
        Set(ByVal value As String)
            mvarCARD_NUMBER = value
        End Set
    End Property
    Public Property ACCOUNT() As String
        Get
            Return mvarACCOUNT
        End Get
        Set(ByVal value As String)
            mvarACCOUNT = value
        End Set
    End Property
    Public Property AMOUNT() As String
        Get
            Return mvarAMOUNT
        End Get
        Set(ByVal value As String)
            mvarAMOUNT = value
        End Set
    End Property
    Public Property ACTION_CODE() As String
        Get
            Return mvarACTION_CODE
        End Get
        Set(ByVal value As String)
            mvarACTION_CODE = value
        End Set
    End Property
    Public Property ACTION() As String
        Get
            Return mvarACTION
        End Get
        Set(ByVal value As String)
            mvarACTION = value
        End Set
    End Property
    Public Property REVERSAL_FLAG() As String
        Get
            Return mvarREVERSAL_FLAG
        End Get
        Set(ByVal value As String)
            mvarREVERSAL_FLAG = value
        End Set
    End Property

    'Public Sub Insert_current_authorization()
    '    Try
    '        Dim parPC As New OracleParameter("@PC", SqlDbType.Char, 2)
    '        parPC.Value = PC

    '        Dim parMTI As New OracleParameter("@MTI", SqlDbType.Char, 4)
    '        parMTI.Value = MTI

    '        Dim parREFERENCE As New OracleParameter("@REFERENCE", SqlDbType.Char, 12)
    '        parREFERENCE.Value = REFERENCE


    '        Dim parSTAN As New OracleParameter("@STAN", SqlDbType.Char, 4)
    '        parSTAN.Value = STAN

    '        Dim parROUTING_CODE As New OracleParameter("@ROUTING_CODE", SqlDbType.Char, 6)
    '        parROUTING_CODE.Value = ROUTING_CODE


    '        Dim parTRANSACTION_TIME_FA As New OracleParameter("@TRANSACTION_TIME_FA", OracleDbType.Varchar2, 19)
    '        parTRANSACTION_TIME_FA.Value = TRANSACTION_TIME_FA


    '        Dim parTRANSACTION_TIME As New OracleParameter("@TRANSACTION_TIME", SqlDbType.DateTime)
    '        parTRANSACTION_TIME.Value = TRANSACTION_TIME


    '        Dim parLOCAL_DATE_FA As New OracleParameter("@LOCAL_DATE_FA", OracleDbType.Varchar2, 19)
    '        parLOCAL_DATE_FA.Value = LOCAL_DATE_FA


    '        Dim parLOCAL_DATE As New OracleParameter("@LOCAL_DATE", SqlDbType.DateTime)
    '        parLOCAL_DATE.Value = LOCAL_DATE


    '        Dim parOUTLET As New OracleParameter("@OUTLET", OracleDbType.Varchar2, 15)
    '        parOUTLET.Value = OUTLET

    '        Dim parACC_NAME As New OracleParameter("@ACC_NAME", OracleDbType.Varchar2, 40)
    '        parACC_NAME.Value = ACC_NAME

    '        Dim parMCC As New OracleParameter("@MCC", SqlDbType.Char, 4)
    '        parMCC.Value = MCC

    '        Dim parCARD_NUMBER As New OracleParameter("@CARD_NUMBER", OracleDbType.Varchar2, 22)
    '        parCARD_NUMBER.Value = CARD_NUMBER


    '                    Dim par As New OracleParameter("@", SqlDbType.)
    '        par.Value = 


    '                    Dim par As New OracleParameter("@", SqlDbType.)
    '        par.Value = 

    '                    Dim par As New OracleParameter("@", SqlDbType.)
    '        par.Value = 

    '                    Dim par As New OracleParameter("@", SqlDbType.)
    '        par.Value = 











    '        Dim strSQL As String = "Insert_current_authorization_SP"
    '        Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, )

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


    Public Function GetByStoreIDContractingParty_Contract_Account_Store_Device_Install_HistoryAtuoRriazation(ByVal Storeid As Int64) As DataTable
        Try
            Dim dt As New DataTable

            Dim parStoreID As New OracleParameter("@StoreID", OracleDbType.Int64)
            parStoreID.Value = Storeid

            strSQL = "GetByStoreIDContractingParty_Contract_Account_Store_Device_Install_HistoryAtuoRriazation_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parStoreID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllcurrent_authorizationForVisitor(ByVal VisitorID As Integer, ByVal DateFrom As String, ByVal DateTo As String, ByVal ProjectID As Int16) As DataTable
        Try
            Dim dt As New DataTable
            Dim parVisitorID As New OracleParameter("@VisitorID", OracleDbType.Int32)
            Dim parFromDate As New OracleParameter("@DateFrom", OracleDbType.Varchar2, 50)
            Dim parToDate As New OracleParameter("@DateTo", OracleDbType.Varchar2, 50)
            Dim parProjectID As New OracleParameter("@ProjectID", OracleDbType.Int32)

            parProjectID.IsNullable = False
            If String.IsNullOrEmpty(ProjectID) Then
                parProjectID.Value = -1
            Else
                parProjectID.Value = ProjectID
            End If


            parVisitorID.IsNullable = True
            If String.IsNullOrEmpty(VisitorID) Then
                parVisitorID.Value = DBNull.Value
            Else
                parVisitorID.Value = VisitorID
            End If

            parFromDate.IsNullable = True
            If String.IsNullOrEmpty(DateFrom) Then
                parFromDate.Value = DBNull.Value
            Else
                parFromDate.Value = DateFrom
            End If


            parToDate.IsNullable = True
            If String.IsNullOrEmpty(DateTo) Then
                parToDate.Value = DBNull.Value
            Else
                parToDate.Value = DateTo
            End If

            strSQL = "GetAllcurrent_authorizationForVisitor_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parVisitorID, parFromDate, parToDate, parProjectID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllTransactionByCondition(ByVal VisitorID As Nullable(Of Integer), ByVal DateFrom As String, ByVal DateTo As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parCondition As New OracleParameter("@Condition", OracleDbType.Varchar2, 1000)
            Dim condition As String = String.Empty

            If IsNothing(VisitorID) = False Then
                If StrComp(condition, String.Empty) = 0 Then
                    condition = "VisitorID=" + VisitorID.ToString
                Else
                    condition = " and VisitorID=" + VisitorID.ToString
                End If
            End If

            If StrComp(DateFrom, String.Empty) = 1 Then
                If StrComp(condition, String.Empty) = 0 Then
                    condition = "current_authorization.TRANSACTION_TIME_FA>='" + DateFrom + "'"
                Else
                    condition = " and current_authorization.TRANSACTION_TIME_FA>='" + DateFrom + "'"
                End If
            End If

            If StrComp(DateTo, String.Empty) = 1 Then
                If StrComp(condition, String.Empty) = 0 Then
                    condition = "current_authorization.TRANSACTION_TIME_FA<='" + DateTo + "'"
                Else
                    condition = " and current_authorization.TRANSACTION_TIME_FA<='" + DateTo + "'"
                End If
            End If
            parCondition.Value = condition
            strSQL = "GetAllTransactionByCondition_sp"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parCondition)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTransactionTypes()
        Try
            Dim dt As New DataTable

            strSQL = "GetTransactionTypes_SP"
            Fill(Global.RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
