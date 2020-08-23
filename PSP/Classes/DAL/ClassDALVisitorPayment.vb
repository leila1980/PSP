Imports Oracle.DataAccess.Client

Public Class ClassDALVisitorPayment
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarID As Int64
    Private mvarVisitorID As Int32
    Private mvarPaymentDate_vc As String
    Private mvarPaymentAmount_dc As Decimal
    Private mvarPosCount_int As Int32
    Private mvarDesc_nvc As String

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"
    Public Property ID() As Int64
        Get
            Return mvarID
        End Get
        Set(ByVal value As Int64)
            mvarID = value
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
    Public Property PaymentDate_vc() As String
        Get
            Return mvarPaymentDate_vc
        End Get
        Set(ByVal value As String)
            mvarPaymentDate_vc = value
        End Set
    End Property
    Public Property PaymentAmount_dc() As Decimal
        Get
            Return mvarPaymentAmount_dc
        End Get
        Set(ByVal value As Decimal)
            mvarPaymentAmount_dc = value
        End Set
    End Property
    Public Property PosCount_int() As Int32
        Get
            Return mvarPosCount_int
        End Get
        Set(ByVal value As Int32)
            mvarPosCount_int = value
        End Set
    End Property
    Public Property Desc_nvc() As String
        Get
            Return mvarDesc_nvc
        End Get
        Set(ByVal value As String)
            mvarDesc_nvc = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Function GetAll() As DataTable
        Try
            Dim dt As New DataTable

            strSQL = "GetAllVisitorPayment_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByVisitorID() As DataTable
        Try
            Dim dt As New DataTable

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID

            strSQL = "GetByVisitorIDVisitorPayment_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parVisitorID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Insert() As Int64
        Try
            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parPaymentDate_vc As New OracleParameter("PaymentDate_vc_", OracleDbType.Varchar2, 10)
            parPaymentDate_vc.Value = PaymentDate_vc
            Dim parPaymentAmount_dc As New OracleParameter("PaymentAmount_dc_", OracleDbType.Decimal)
            parPaymentAmount_dc.Value = PaymentAmount_dc
            Dim parPosCount_int As New OracleParameter("PosCount_int_", OracleDbType.Int32)
            parPosCount_int.Value = PosCount_int
            Dim parDesc_nvc As New OracleParameter("Desc_nvc_", OracleDbType.Varchar2, 500)
            parDesc_nvc.Value = Desc_nvc
            Dim parID As New OracleParameter("ID_", OracleDbType.Int64)
            parID.Direction = ParameterDirection.Output

            strSQL = "InsertVisitorPayment_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parVisitorID, parPaymentDate_vc, parPaymentAmount_dc, parPosCount_int, parDesc_nvc, parID)
            Return parID.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update()
        Try
            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = VisitorID
            Dim parPaymentDate_vc As New OracleParameter("PaymentDate_vc_", OracleDbType.Varchar2, 10)
            parPaymentDate_vc.Value = PaymentDate_vc
            Dim parPaymentAmount_dc As New OracleParameter("PaymentAmount_dc_", OracleDbType.Decimal)
            parPaymentAmount_dc.Value = PaymentAmount_dc
            Dim parPosCount_int As New OracleParameter("PosCount_int_", OracleDbType.Int32)
            parPosCount_int.Value = PosCount_int
            Dim parDesc_nvc As New OracleParameter("Desc_nvc_", OracleDbType.Varchar2, 500)
            parDesc_nvc.Value = Desc_nvc
            Dim parID As New OracleParameter("ID_", OracleDbType.Int64)
            parID.Value = ID

            strSQL = "UpdateVisitorPayment_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parID, parVisitorID, parPaymentDate_vc, parPaymentAmount_dc, parPosCount_int, parDesc_nvc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim parID As New OracleParameter("ID_", OracleDbType.Int64)
            parID.Value = ID

            strSQL = "DeleteVisitorPayment_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region
End Class
