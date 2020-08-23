Imports Oracle.DataAccess.Client

Public Class ClassDALBasicTypes
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    Private dtBasicTypes As New DataTable


    Private mvarID As Int32
    Private mvarName_nvc As String
    Private mvarTypeID_sint As BasicTypeEnum
    Public BasicTypeTable As New Hashtable
    Public Enum BasicTypeEnum As Short
        CIdentityType = 1
        SIdentityType = 2
        Degree = 3
        AccountType = 4
        EstateCondition = 5
        Switch_PaymentMethodType = 6
        ActiveStatus = 7
    End Enum
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
        BasicTypeTable.Add(BasicTypeEnum.CIdentityType, "مدرک شناسایی شخص")
        BasicTypeTable.Add(BasicTypeEnum.SIdentityType, "مدرک شناسایی فروشگاه")
        BasicTypeTable.Add(BasicTypeEnum.Degree, "مدرک تحصیلی")
        BasicTypeTable.Add(BasicTypeEnum.AccountType, "نوع حساب")
        BasicTypeTable.Add(BasicTypeEnum.EstateCondition, "وضعیت تملک")
    End Sub
#Region "Property"
    Public Property ID() As Int32
        Get
            Return mvarID
        End Get
        Set(ByVal value As Int32)
            mvarID = value
        End Set
    End Property
    Public Property Name_nvc() As String
        Get
            Return mvarName_nvc
        End Get
        Set(ByVal value As String)
            mvarName_nvc = value
        End Set
    End Property
    Public Property TypeID_sint() As BasicTypeEnum
        Get
            Return mvarTypeID_sint
        End Get
        Set(ByVal value As BasicTypeEnum)
            mvarTypeID_sint = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Function GetAll() As DataTable
        Try
            Dim dtBasicTypes As New DataTable

            Dim parTypeID_sint As New OracleParameter("TYPEID_SINT_", OracleDbType.Int16)
            parTypeID_sint.Value = TypeID_sint

            strSQL = "GetAllBasicTypes_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtBasicTypes, parTypeID_sint, parRefCursor)
            Return dtBasicTypes
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByID() As DataTable
        Try
            Dim dtBasicTypes As New DataTable

            Dim parID As New OracleParameter("@ID", OracleDbType.Int32)
            parID.Value = ID

            strSQL = "GetByIDBasicTypes_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtBasicTypes, parID)
            Return dtBasicTypes
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Insert() As Int32
        Try
            Dim parName_nvc As New OracleParameter("Name_nvc_", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc
            Dim parTypeID_sint As New OracleParameter("TypeID_sint_", OracleDbType.Int16)
            parTypeID_sint.Value = TypeID_sint
            Dim parID As New OracleParameter("ID_", OracleDbType.Int32)
            parID.Direction = ParameterDirection.Output

            strSQL = "InsertBasicTypes_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parName_nvc, parTypeID_sint, parID)
            Return Convert.ToInt64(parID.Value.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update()
        Try
            Dim parID As New OracleParameter("ID_", OracleDbType.Int32)
            parID.Value = Int32.Parse(ID)
            Dim parName_nvc As New OracleParameter("Name_nvc_", OracleDbType.Varchar2)
            parName_nvc.Value = Name_nvc

            strSQL = "UpdateBasicTypes_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parName_nvc, parID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim parID As New OracleParameter("ID_", OracleDbType.Int32)
            parID.Value = ID

            strSQL = "DeleteBasicTypes_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetByMappingCodeBasicTypesID(ByVal MappingCode_vc As String, ByVal TypeID_sint As BasicTypeEnum) As String
        Try
            Dim parMappingCode_vc As New OracleParameter("MappingCode_vc_", OracleDbType.Varchar2, 10)
            parMappingCode_vc.Value = MappingCode_vc
            Dim parTypeID_sint As New OracleParameter("TypeID_sint_", OracleDbType.Int16)
            parTypeID_sint.Value = TypeID_sint


            strSQL = "GetByMappingCodeBasicTypes_SP"
            dtBasicTypes.Clear()

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)

            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtBasicTypes, parMappingCode_vc, parTypeID_sint, parRefCursor)
            If dtBasicTypes.Rows.Count = 1 Then
                Return dtBasicTypes.Rows(0).Item("ID").ToString
            Else
                Throw New Exception("Problem with finding BasicTypesMappingCode=" & MappingCode_vc)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
