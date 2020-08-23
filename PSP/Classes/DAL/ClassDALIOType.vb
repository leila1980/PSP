Imports Oracle.DataAccess.Client

Public Class ClassDALIOType
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarIOTypeID As Int16
    Private mvarName_nvc As String
    Private mvarBehaviour_tint As Int16
    Private mvarDescription_nvc As String
    Public Enum IOTypeEnum As Short
        InStore = 1
        OutofStore = 2
    End Enum
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#Region "Property"
    Public Property IOTypeID() As Int16
        Get
            Return mvarIOTypeID
        End Get
        Set(ByVal value As Int16)
            mvarIOTypeID = value
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
    Public Property Behaviour_tint() As Int16
        Get
            Return mvarBehaviour_tint
        End Get
        Set(ByVal value As Int16)
            mvarBehaviour_tint = value
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
    Public Function GetAllIOType() As DataTable
        Try
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByID() As DataTable
        Try
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetByBehaviourIOType() As DataTable
        Try
            Dim dt As New DataTable
            Dim parBehaviour_tint As New OracleParameter("@Behaviour_tint", OracleDbType.Int16)
            parBehaviour_tint.Value = Behaviour_tint

            Me.Fill(CommandType.StoreProcedure, "GetByBehaviourIOType_SP", dt, parBehaviour_tint)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Insert() As Int32
        Try
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Sub Update()
        Try
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub Delete()
        Try
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region
End Class
