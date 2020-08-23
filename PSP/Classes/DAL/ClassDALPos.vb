Imports Oracle.DataAccess.Client

Public Class ClassDALPos
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarPosID As Int64
    Private mvarSerial_vc As String
    Private mvarPropertyNo_vc As String
    Private mvarEniacCode_vc As String
    Private mvarActive_Tint As Int16
    Private mvarProductNo_vc As String
    Private mvarPartNo_int As String
    Private mvarPosTypeID As Int16
    Private mvarPosModelID As Int16
    Private mvarPosModelName_nvc As String
    Private mvarBatchNo_int As Int32
    Private mvarGood_ID As Int16
    Private mvarGoodName_nvc As String

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property Pos"
    Public Property PosID() As Int64
        Get
            Return mvarPosID
        End Get
        Set(ByVal value As Int64)
            mvarPosID = value
        End Set
    End Property
    Public Property Serial_vc() As String
        Get
            Return mvarSerial_vc
        End Get
        Set(ByVal value As String)
            mvarSerial_vc = value
        End Set
    End Property
    Public Property PropertyNo_vc() As String
        Get
            Return mvarPropertyNo_vc
        End Get
        Set(ByVal value As String)
            mvarPropertyNo_vc = value
        End Set
    End Property
    Public Property EniacCode_vc() As String
        Get
            Return mvarEniacCode_vc
        End Get
        Set(ByVal value As String)
            mvarEniacCode_vc = value
        End Set
    End Property
    Public Property Active_Tint() As Int16
        Get
            Return mvarActive_Tint
        End Get
        Set(ByVal value As Int16)
            mvarActive_Tint = value
        End Set
    End Property
    Public Property ProductNo_vc() As String
        Get
            Return mvarProductNo_vc
        End Get
        Set(ByVal value As String)
            mvarProductNo_vc = value
        End Set
    End Property
    Public Property PartNo_int() As Int32
        Get
            Return mvarPartNo_int
        End Get
        Set(ByVal value As Int32)
            mvarPartNo_int = value
        End Set
    End Property
    Public Property PosTypeID() As Int16
        Get
            Return mvarPosTypeID
        End Get
        Set(ByVal value As Int16)
            mvarPosTypeID = value
        End Set
    End Property
    Public Property PosModelID() As Int16
        Get
            Return mvarPosModelID
        End Get
        Set(ByVal value As Int16)
            mvarPosModelID = value
        End Set
    End Property
    Public Property Good_ID() As String
        Get
            Return mvarGood_ID
        End Get
        Set(ByVal value As String)
            mvarGood_ID = value
        End Set
    End Property
    Public Property GoodName_nvc As String
        Get
            Return mvarGoodName_nvc
        End Get
        Set(ByVal value As String)
            mvarGoodName_nvc = value
        End Set
    End Property

    Public Property PosModelName_nvc() As String
        Get
            Return mvarPosModelName_nvc
        End Get
        Set(ByVal value As String)
            mvarPosModelName_nvc = value
        End Set
    End Property
    Public Property BatchNo_int() As Int32
        Get
            Return mvarBatchNo_int
        End Get
        Set(ByVal value As Int32)
            mvarBatchNo_int = value
        End Set
    End Property
#End Region
#Region "Pos"
#Region "Methods"
    Public Function GetAllPosModel() As DataTable
        Try
            Dim dtPosModele As New DataTable

            strSQL = "GetAllPosModel_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPosModele, parRefCursor)
            Return dtPosModele
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllStorePosModel() As DataTable
        Try
            Dim dtPosModele As New DataTable

            strSQL = "GetAllStorePosModel_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPosModele, parRefCursor)
            Return dtPosModele
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllGood() As DataTable
        Try
            Dim dtGood As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllGood_SP"

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtGood, parRefCursor)
            Return dtGood
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllPosType() As DataTable
        Try
            Dim dtPosType As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllPosType_SP"

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPosType, parRefCursor)
            Return dtPosType
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllPos() As DataTable
        Try
            Dim dtPos As New DataTable
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetAllPos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPos, parRefCursor)
            Return dtPos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetPosByVisitor(ByVal VisitorID As Integer, ByVal Type_tint As Int16, Optional ByVal UserType As String = "-1") As DataTable
        Try
            Dim dtPos As New DataTable

            Dim parVisitorID As New OracleParameter("VisitorID_", OracleDbType.Int32)
            parVisitorID.Value = IIf(VisitorID = -1, DBNull.Value, VisitorID)

            Dim parOperation_tint As New OracleParameter("Operation_tint_", OracleDbType.Int16)
            parOperation_tint.Value = Type_tint


            '  Dim parUserType As New OracleParameter("Usertype_", OracleDbType.Varchar2, 5)
            '  parOperation_tint.Value = UserType

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetPosByVisitor_SP"

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPos, parVisitorID, parOperation_tint, parRefCursor)

            Return dtPos
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetByCMSProject(ByVal type As String) As DataTable
        Try
            Dim dtCMS As New DataTable
            Dim parSerial_vc As New OracleParameter("Serial_vc_", OracleDbType.Varchar2, 20)
            parSerial_vc.Value = Serial_vc
            Dim parType As New OracleParameter("type_", OracleDbType.Varchar2, 5)
            parType.Value = type
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "GetByCMSProject_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCMS, parSerial_vc, parType, parRefCursor)
            Return dtCMS
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetBySerialPos() As DataTable
        Try
            Dim dtPos As New DataTable

            Dim parSerial_vc As New OracleParameter("Serial_vc_", OracleDbType.Varchar2, 20)
            parSerial_vc.Value = Serial_vc
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetBySerialPos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPos, parSerial_vc, parRefCursor)
            Return dtPos
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBySerialPos(ByVal UserID As Int64) As DataTable
        Try
            Dim dtPos As New DataTable

            Dim parSerial_vc As New OracleParameter("Serial_vc_", OracleDbType.Varchar2, 20)
            parSerial_vc.Value = Serial_vc
            Dim parUserID As New OracleParameter("UserID_", OracleDbType.Int64)
            parUserID.Value = UserID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)


            strSQL = "GetBySerialPos_ByUID_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPos, parSerial_vc, parUserID, parRefCursor)
            Return dtPos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByPropertyNoPos() As DataTable
        Try
            Dim dtPos As New DataTable

            Dim parPropertyNo_vc As New OracleParameter("PropertyNo_vc_", OracleDbType.Varchar2, 20)
            parPropertyNo_vc.Value = PropertyNo_vc
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByPropertyNoPos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPos, parPropertyNo_vc, parRefCursor)
            Return dtPos
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByEniacCodePos() As DataTable
        Try
            Dim dtPos As New DataTable

            Dim parEniacCode_vc As New OracleParameter("EniacCode_vc_", OracleDbType.Varchar2, 20)
            parEniacCode_vc.Value = EniacCode_vc

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByEniacCodePos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPos, parEniacCode_vc, parRefCursor)
            Return dtPos
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByProductNoPos() As DataTable
        Try
            Dim dtPos As New DataTable

            Dim parProductNo_vc As New OracleParameter("@ProductNo_vc", OracleDbType.Varchar2, 20)
            parProductNo_vc.Value = ProductNo_vc

            strSQL = "GetByProductNoPos_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtPos, parProductNo_vc)
            Return dtPos
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGoodByPosModelID() As DataTable
        Try
            Dim dtGood As New DataTable

            Dim parPosModelID As New OracleParameter("PosModelID_", OracleDbType.Int16, 10)
            parPosModelID.Value = PosModelID


            strSQL = "GetByPosModelIDGood_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtGood, parPosModelID, parRefCursor)
            Return dtGood
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertPos() As Int64
        Try
            Dim parSerial_vc As New OracleParameter("Serial_vc_", OracleDbType.Varchar2, 20)
            parSerial_vc.Value = Serial_vc
            Dim parPropertyNo_vc As New OracleParameter("PropertyNo_vc_", OracleDbType.Varchar2, 20)
            parPropertyNo_vc.Value = PropertyNo_vc
            Dim parEniacCode_vc As New OracleParameter("EniacCode_vc_", OracleDbType.Varchar2, 20)
            parEniacCode_vc.Value = EniacCode_vc
            Dim parActive_Tint As New OracleParameter("Active_Tint_", OracleDbType.Int16)
            parActive_Tint.Value = Active_Tint
            Dim parProductNo_vc As New OracleParameter("ProductNo_vc_", OracleDbType.Varchar2, 20)
            parProductNo_vc.Value = ProductNo_vc
            Dim parPartNo_int As New OracleParameter("PartNo_int_", OracleDbType.Int32)
            parPartNo_int.Value = PartNo_int
            Dim parPosTypeID As New OracleParameter("PosTypeID_", OracleDbType.Int16)
            parPosTypeID.Value = PosTypeID
            Dim parPosModelID As New OracleParameter("PosModelID_", OracleDbType.Int16)
            parPosModelID.Value = PosModelID
            Dim parBatchNo_int As New OracleParameter("BatchNo_int_", OracleDbType.Int32)
            parBatchNo_int.Value = IIf(BatchNo_int = -1, DBNull.Value, BatchNo_int)
            Dim parGood_ID As New OracleParameter("Good_ID_", OracleDbType.Int16)
            parGood_ID.Value = Good_ID


            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Direction = ParameterDirection.Output

            strSQL = "InsertPos_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, _
                             parSerial_vc, parPropertyNo_vc, parEniacCode_vc, parActive_Tint, _
                             parProductNo_vc, parPartNo_int, parPosTypeID, parPosModelID, parBatchNo_int, parGood_ID, parPosID)
            Return Long.Parse(parPosID.Value.ToString())
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdatePos()
        Try
            Dim parSerial_vc As New OracleParameter("Serial_vc_", OracleDbType.Varchar2, 20)
            parSerial_vc.Value = Serial_vc
            Dim parPropertyNo_vc As New OracleParameter("PropertyNo_vc_", OracleDbType.Varchar2, 20)
            parPropertyNo_vc.Value = PropertyNo_vc
            Dim parEniacCode_vc As New OracleParameter("EniacCode_vc_", OracleDbType.Varchar2, 20)
            parEniacCode_vc.Value = EniacCode_vc
            Dim parActive_Tint As New OracleParameter("Active_Tint_", OracleDbType.Int16)
            parActive_Tint.Value = Active_Tint
            Dim parProductNo_vc As New OracleParameter("ProductNo_vc_", OracleDbType.Varchar2, 20)
            parProductNo_vc.Value = ProductNo_vc
            Dim parPartNo_int As New OracleParameter("PartNo_int_", OracleDbType.Int32)
            parPartNo_int.Value = PartNo_int
            Dim parPosTypeID As New OracleParameter("PosTypeID_", OracleDbType.Int16)
            parPosTypeID.Value = PosTypeID
            Dim parPosModelID As New OracleParameter("PosModelID_", OracleDbType.Int16)
            parPosModelID.Value = PosModelID
            Dim parBatchNo_int As New OracleParameter("BatchNo_int_", OracleDbType.Int32)
            parBatchNo_int.Value = IIf(BatchNo_int = -1, DBNull.Value, BatchNo_int)
            Dim parGood_ID As New OracleParameter("Good_ID_", OracleDbType.Int16)
            parGood_ID.Value = Good_ID

            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = PosID

            strSQL = "UpdatePos_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, _
                             parSerial_vc, parPropertyNo_vc, parEniacCode_vc, _
                             parActive_Tint, parProductNo_vc, parPartNo_int, parPosTypeID, _
                             parPosModelID, parBatchNo_int, parGood_ID, parPosID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdatePos_onlyProductNumber(ByVal posid As Int64, ByVal ProductNo As String)
        Try
            Dim parProductNo_vc As New OracleParameter("@ProductNo_vc", OracleDbType.Varchar2, 20)
            parProductNo_vc.Value = ProductNo

            Dim parPosID As New OracleParameter("@PosID", OracleDbType.Int64)
            parPosID.Value = posid

            strSQL = "UpdatePos_onlyProductNumber_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parPosID, parProductNo_vc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeletePos()
        Try
            Dim parPosID As New OracleParameter("PosID_", OracleDbType.Int64)
            parPosID.Value = PosID
            strSQL = "DeletePos_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parPosID)
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw ex
        End Try
    End Sub
    Public Sub UpdateB2B(ByVal PosTypeID As Int16, ByVal SelectedPoses As String)
        Try
            Dim parPosTypeID As New OracleParameter(":PosTypeID", OracleDbType.Int16)
            parPosTypeID.Value = PosTypeID

            strSQL = "Update Pos_T SET PosTypeID = :PosTypeID WHERE PosID IN (" + SelectedPoses + ")"
            Execute_NonQuery(CommandType.Text, strSQL, parPosTypeID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function IsB2BbySerial() As Boolean
        Try
            Dim dtpos As New DataTable


            Dim parSerial_vc As New OracleParameter(":Serial_vc", OracleDbType.Varchar2, 20)
            parSerial_vc.Value = Serial_vc

            strSQL = "SELECT PosID FROM Pos_T WHERE Serial_vc = :Serial_vc AND PosTypeID = 3 -- B2B "

            Fill(CommandType.Text, strSQL, dtpos, parSerial_vc)
            If dtpos.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function IsPosChangedInLast30Days(ByVal Serial As String, ByVal Outlet As String, ByVal LastMonth As String) As Boolean
        Try
            Dim dt As New DataTable

            Dim parSerial As New OracleParameter("Serial_", OracleDbType.Varchar2, 20)
            parSerial.Value = Serial

            Dim parOutlet As New OracleParameter("Outlet_", OracleDbType.Varchar2, 20)
            parOutlet.Value = Outlet


            Dim parLastMonth As New OracleParameter("LastMonthDate_", OracleDbType.Varchar2, 10)
            parLastMonth.Value = LastMonth


            strSQL = "usp_IsThisPosCanceledInLast30Days"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parSerial, parOutlet, parLastMonth)
            If dt.Rows.Count > 0 Then
                Return Convert.ToBoolean(dt.Rows(0).Item(0))
            Else
                Return True
            End If

        Catch ex As Exception
            Throw ex
        End Try


    End Function


#End Region
#End Region

End Class
