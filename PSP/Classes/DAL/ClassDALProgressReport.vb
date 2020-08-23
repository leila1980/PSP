Imports Oracle.DataAccess.Client

Public Class ClassDALProgressReport

    Inherits RIZNARM.Data.Oracle_Client.DataAccess

    Private strSQL As String
    Dim cnt As New Oracle.DataAccess.Client.OracleConnection
    Dim TMScnt As New Odbc.OdbcConnection

    Private mvarCityID As String
    Private mvarCityName As String
    Private mvarCountOfActivePose As String


    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
        With cnt
            .ConnectionString = modPublicMethod.ConnectionString
            .Open()
        End With
        With TMScnt
            .ConnectionString = modPublicMethod.TMSConnectionString
            .Open()
        End With

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

    Public Property CityName() As String
        Get
            Return Me.mvarCityName
        End Get
        Set(ByVal value As String)
            Me.mvarCityName = value
        End Set
    End Property

    Public Property CountOfActivePose()
        Get
            Return Me.mvarCountOfActivePose
        End Get
        Set(ByVal value)
            Me.mvarCountOfActivePose = value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Function GetStateActivePos() As DataTable
        Try
            Dim dtGetCountOfActivePose As New DataTable

            strSQL = "GetStateActivePos_SP"
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dtGetCountOfActivePose, parRefCursor)
            Return dtGetCountOfActivePose

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
