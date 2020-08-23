Imports Oracle.DataAccess.Client

Public Class ClassDALCity
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String
    Private dtCity As New DataTable

    Private mvarCityID As String
    Private mvarName_nvc As String
    Private mvarStateID As String
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"
    Public Property CityID() As String
        Get
            Return mvarCityID
        End Get
        Set(ByVal value As String)
            mvarCityID = value
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
    Public Property StateID() As String
        Get
            Return mvarStateID
        End Get
        Set(ByVal value As String)
            mvarStateID = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Function GetAll() As DataTable
        Try
            Dim dtCity As New DataTable

            strSQL = "GetAllCity_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parRefCursor)
            Return dtCity
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByStateIDForUCtrl() As DataTable
        Try
            Dim dtCity As New DataTable
            Dim parStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            strSQL = "GetByStateIDCityForUCtrl_SP"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parStateID, parRefCursor)
            Return dtCity
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByID() As DataTable
        Try
            Dim dtCity As New DataTable

            Dim parCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID

            strSQL = "GetByIDCity_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parCityID, parRefCursor)
            Return dtCity
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByStateID() As DataTable
        Try
            Dim dtCity As New DataTable

            Dim parStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID

            strSQL = "GetByStateIDCity_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parStateID, parRefCursor)
            Return dtCity
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByStateIDAndCityIDCity() As DataTable
        Try
            Dim dtCity As New DataTable

            Dim parStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID

            Dim parCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID


            strSQL = "GetByStateIDAndCityIDCity_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parStateID, parCityID, parRefCursor)
            Return dtCity
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public  Function GetByCityIDCheckShprkNO() As String
        Try
            Dim parCityID As New OracleParameter("@CITYID", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID

            Dim parShaparkNo As New OracleParameter("@SHAPARAKNO", OracleDbType.Varchar2, 7)
            parShaparkNo.Direction = ParameterDirection.Output

            Execute_NonQuery(CommandType.StoreProcedure, "GetByCityIDCheckShprkNO_SP", parCityID, parShaparkNo)

            If (parShaparkNo.Value = Oracle.DataAccess.Types.OracleString.Null) Then
                parShaparkNo.Value = Nothing
            Else
                parShaparkNo.Value = parShaparkNo.Value.ToString
            End If

            Return parShaparkNo.Value

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Insert()
        Try
            Dim parCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID
            Dim parName_nvc As New OracleParameter("Name_nvc_", OracleDbType.Varchar2, 50)
            parName_nvc.Value = Name_nvc
            Dim parStateID As New OracleParameter("StateID_", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID

            strSQL = "InsertCity_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parCityID, parName_nvc, parStateID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update()
        Try
            Dim parCityID As New OracleParameter("@CityID", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID
            Dim parName_nvc As New OracleParameter("@Name_nvc", OracleDbType.Varchar2, 30)
            parName_nvc.Value = Name_nvc
            Dim parStateID As New OracleParameter("@StateID", OracleDbType.Varchar2, 3)
            parStateID.Value = StateID

            strSQL = "UpdateCity_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parCityID, parName_nvc, parStateID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete()
        Try
            Dim parCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID

            strSQL = "DeleteCity_SP"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parCityID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetByMappingCodeCityID(ByVal MappingCode_vc As String) As String
        Try
            Dim parMappingCode_vc As New OracleParameter("@MappingCode_vc", OracleDbType.Varchar2, 10)
            parMappingCode_vc.Value = MappingCode_vc

            strSQL = "GetByMappingCodeCity_SP"
            dtCity.Clear()
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parMappingCode_vc)
            If dtCity.Rows.Count = 1 Then
                Return dtCity.Rows(0).Item("CityID").ToString
            Else
                Throw New Exception("Problem with finding CityMappingCode=" & MappingCode_vc)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByMappingCodeStateID(ByVal MappingCode_vc As String) As String
        Try
            Dim parMappingCode_vc As New OracleParameter("@MappingCode_vc", OracleDbType.Varchar2, 10)
            parMappingCode_vc.Value = MappingCode_vc

            strSQL = "GetByMappingCodeCity_SP"
            dtCity.Clear()
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parMappingCode_vc)
            If dtCity.Rows.Count = 1 Then
                Return dtCity.Rows(0).Item("StateID").ToString
            Else
                Throw New Exception("Problem with finding CityMappingCode=" & MappingCode_vc)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByCityIDStateID(ByVal CityID As String) As String
        Try
            Dim parCityID As New OracleParameter("CityID_", OracleDbType.Varchar2, 5)
            parCityID.Value = CityID


            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)


            strSQL = "GetByCityIDCity_SP"
            dtCity.Clear()
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCity, parCityID, parRefCursor)
            If dtCity.Rows.Count = 1 Then
                Return dtCity.Rows(0).Item("StateID").ToString
            Else
                Throw New Exception("Problem with finding CityMappingCode=" & CityID)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetByCityName(ByVal CityName As String, ByRef CityId As String) As String
        Try
            Dim dtCities As New DataTable

            Dim parCityName As New OracleParameter("CityName_", OracleDbType.Varchar2, 25)
            parCityName.Value = CityName

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            strSQL = "GetByCityNameCity_SP"
            dtCities.Clear()
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtCities, parCityName, parRefCursor)
            CityId = dtCities.Rows(0).Item("CityID").ToString
            Return dtCities.Rows(0).Item("StateID").ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "TMS" '---For transaction
    Public Sub ForTMS_TMSTerminal_Insert2(ByVal TERMINAL_ID As String, ByVal SIGNATURE As String, ByVal NAME As String, ByVal REGISTRATION_DATE As DateTime, ByVal TYPE As String, ByVal STATUS As Int32, ByVal CATEGORY As Int32, ByVal DESCRIPTION As String, ByVal PARENT_ID As String)
        Try
            Dim parTERMINAL_ID As New OracleParameter("@TERMINAL_ID", OracleDbType.Varchar2, 50)
            parTERMINAL_ID.Value = TERMINAL_ID
            Dim parSIGNATURE As New OracleParameter("@SIGNATURE", OracleDbType.Varchar2, 50)
            parSIGNATURE.Value = SIGNATURE
            Dim parNAME As New OracleParameter("@NAME", OracleDbType.Varchar2, 100)
            parNAME.Value = NAME
            Dim parREGISTRATION_DATE As New OracleParameter("@REGISTRATION_DATE", OracleDbType.Varchar2, 10)
            parREGISTRATION_DATE.Value = REGISTRATION_DATE
            Dim parTYPE As New OracleParameter("@TYPE", OracleDbType.Varchar2, 20)
            parTYPE.Value = TYPE
            Dim parSTATUS As New OracleParameter("@STATUS", OracleDbType.Int32)
            parSTATUS.Value = STATUS
            Dim parCATEGORY As New OracleParameter("@CATEGORY", OracleDbType.Int32)
            parCATEGORY.Value = CATEGORY
            Dim parDESCRIPTION As New OracleParameter("@DESCRIPTION", OracleDbType.Varchar2, 200)
            parDESCRIPTION.Value = DESCRIPTION
            Dim parPARENT_ID As New OracleParameter("@PARENT_ID", OracleDbType.Varchar2, 50)
            parPARENT_ID.Value = PARENT_ID


            Me.Execute_NonQuery(CommandType.StoreProcedure, "ForTMS_TMSTerminal_Insert2", parTERMINAL_ID, parSIGNATURE, parNAME, parREGISTRATION_DATE, parTYPE, parSTATUS, parCATEGORY, parDESCRIPTION, parPARENT_ID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ForTMS_TMSTerminal_Update_ByTerminalID(ByVal TERMINAL_ID As String, ByVal REGISTRATION_DATE As Date, ByVal PARENT_ID As String)
        Try
            Dim parTERMINAL_ID As New OracleParameter("@TERMINAL_ID", OracleDbType.Varchar2, 50)
            parTERMINAL_ID.Value = TERMINAL_ID
            Dim parREGISTRATION_DATE As New OracleParameter("@REGISTRATION_DATE", OracleDbType.Varchar2, 10)
            parREGISTRATION_DATE.Value = REGISTRATION_DATE
            Dim parPARENT_ID As New OracleParameter("@PARENT_ID", OracleDbType.Varchar2, 50)
            parPARENT_ID.Value = PARENT_ID


            Me.Execute_NonQuery(CommandType.StoreProcedure, "ForTMS_TMSTerminal_Update_ByTerminalID", parTERMINAL_ID, parREGISTRATION_DATE, parPARENT_ID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ForTMS_TMSTerminal_MAXTerminalID() As DataTable
        Try
            Dim dt As New DataTable


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_MAXTerminalID", dt)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_TMSTerminal_GetByCityID(ByVal SIGNATURE As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSIGNATURE As New OracleParameter("@SIGNATURE", OracleDbType.Varchar2, 50)
            parSIGNATURE.Value = SIGNATURE


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_GetByCityID", dt, parSIGNATURE)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ForTMS_TMSTerminal_GetByStateID(ByVal SIGNATURE As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim parSIGNATURE As New OracleParameter("@SIGNATURE", OracleDbType.Varchar2, 50)
            parSIGNATURE.Value = SIGNATURE


            Me.Fill(CommandType.StoreProcedure, "ForTMS_TMSTerminal_GetByStateID", dt, parSIGNATURE)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
