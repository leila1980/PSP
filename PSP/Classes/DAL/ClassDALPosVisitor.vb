Imports Oracle.DataAccess.Client

Public Class ClassDALPosVisitor
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarPosID As Int64
    Private mvarVisitorID As Int32
    Private mvarOperation_tint As Int16
    Private mvarDateFa_vc As String
    Private mvarDateTime As Date

    Enum PosVisitorOperations
        AllOperations = 0 '1 or 2 or 3
        AssignmentConfirmedByVisitor = 1
        AssignedToVisitor = 2
        TransferedToOtherBank = 3
        ReturnedToEniacByVisitor = 4
        RecievedByEniac = 5
        AssignmentToVisitorCanceledByEniac = 6
        ReTransferedToOtherBank = 7
    End Enum

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"
    Public Property PosID() As Int64
        Get
            Return mvarPosID
        End Get
        Set(ByVal value As Int64)
            mvarPosID = value
        End Set
    End Property
    Public Property VisitorID() As Int32
        Get
            Return mvarVisitorID
        End Get
        Set(ByVal value As Int32)
            mvarVisitorID = value
        End Set
    End Property
    Public Property Operation_tint() As Int16
        Get
            Return mvarOperation_tint
        End Get
        Set(ByVal value As Int16)
            mvarOperation_tint = value
        End Set
    End Property
    Public Property DateFa_vc() As String
        Get
            Return mvarDateFa_vc
        End Get
        Set(ByVal value As String)
            mvarDateFa_vc = value
        End Set
    End Property
    Public Property DateTime() As Date
        Get
            Return mvarDateTime
        End Get
        Set(ByVal value As Date)
            mvarDateTime = value
        End Set
    End Property

#End Region
#Region "Methods"

    Public Function GetByPosIDPosVisitorHistory(ByVal PosID As Int64) As DataTable
        Try
            Dim dtPos As New DataTable

            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = PosID
            'GetByPosIDPosVisitorsHistory_SP'
            strSQL = "GetByPosIDPosVisitorsHistory"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPos, parPosID, parRefCursor)
            Return dtPos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Insert()
        Try
            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = PosID

            Dim parOperation_tint As New OracleParameter("Operation_tint_", OracleDbType.Int16)
            parOperation_tint.Value = Operation_tint

            Dim parDateFa_vc As New OracleParameter("DateFa_vc_", OracleDbType.Varchar2, 10)
            parDateFa_vc.Value = DateFa_vc

            Dim parDateTime As New OracleParameter("DateTime_", OracleDbType.Date)
            parDateTime.Value = DateTime

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            If VisitorID = -1 Then
                parVisitorID.Value = DBNull.Value
            Else
                parVisitorID.Value = VisitorID
            End If

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int32)
            parUserID.Value = ClassUserLoginDataAccess.ThisUser.UserID

            strSQL = "InsertPosVisitor_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure _
                             , strSQL, parPosID, parOperation_tint, parDateFa_vc, parDateTime, parVisitorID, parUserID)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function IsThisPosInstalled() As String
        Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
        parPosID.Value = PosID

        Dim parIsPosInstalled As New OracleParameter("IsPosInstalled_", OracleDbType.Varchar2, 10)
        parIsPosInstalled.Direction = ParameterDirection.Output

        strSQL = "IsThisPosInstalled_SP"
        Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure _
                         , strSQL, parPosID, parIsPosInstalled)

        Return parIsPosInstalled.Value.ToString


    End Function


    Public Function Delete() As String
        Try
            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = PosID

            Dim parOperation_tint As New OracleParameter("Operation_tint_", OracleDbType.Int16)
            parOperation_tint.Value = Operation_tint

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            If VisitorID = -1 Then
                parVisitorID.Value = DBNull.Value
            Else
                parVisitorID.Value = VisitorID
            End If

            Dim parMSG As New OracleParameter("MSG_", OracleDbType.Varchar2, 500)
            parMSG.Direction = ParameterDirection.Output

            strSQL = "DeletePosVisitor_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure _
                             , strSQL, parPosID, parOperation_tint, parVisitorID, parMSG)
            Return parMSG.Value.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub UpdateVisitor_Contract_PosVisitor(ByVal OldVisitorID As Integer, ByVal NewVisitorID As Integer, ByVal ContractID As Integer, ByVal UserID As Integer)
        Try
            Dim parOldVisitorID As New OracleParameter("OldVisitorID_", OracleDbType.Int64)
            parOldVisitorID.Value = OldVisitorID

            Dim parNewVisitorID As New OracleParameter("NewVisitorID_", OracleDbType.Int64)
            parNewVisitorID.Value = NewVisitorID

            Dim parContractID As New OracleParameter("ContractID_", OracleDbType.Int64)
            parContractID.Value = ContractID

            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID

            BeginProc()
            ''UpdateVisitor_Contract_PosVisitor_SP
            strSQL = "UpdateVstr_Cont_PosVisitor_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure _
                             , strSQL, parContractID, parOldVisitorID, parNewVisitorID, parUserID)
        Catch ex As Exception
            Throw ex
        Finally
            EndProc()
        End Try

    End Sub

    Public Function LastStatusIsApprovedByVisitor(ByVal PosSerial As String) As Boolean
        Dim parPosSerial As New OracleParameter("PosSerial_", OracleDbType.Varchar2, 20)
        parPosSerial.Value = PosSerial

        Dim parIsPosApproved As New OracleParameter("IsPosApproved_", OracleDbType.Int32)
        parIsPosApproved.Direction = ParameterDirection.Output

        'IsLastPosStatusApprovedByVisitor_SP
        strSQL = "IsLastPosStatAprvdByVisitor_SP"
        Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure _
                         , strSQL, parPosSerial, parIsPosApproved)

        'Return (parIsPosApproved.Value = 1)
        Return Convert.ToBoolean(Integer.Parse(parIsPosApproved.Value.ToString))

    End Function

    
#End Region
End Class
