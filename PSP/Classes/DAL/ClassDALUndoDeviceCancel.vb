Imports Oracle.DataAccess.Client

Public Class ClassDALUndoDeviceCancel
    Inherits RIZNARM.Data.Oracle_Client.DataAccess
    Private strSQL As String

    Private mvarOutlet As String
    Private mvarDeviceID As Int64

#Region "Property"

    Public Property Outlet() As String
        Get
            Return mvarOutlet
        End Get
        Set(ByVal value As String)
            mvarOutlet = value
        End Set
    End Property

    Public Property DeviceID() As Int64
        Get
            Return mvarDeviceID
        End Get
        Set(ByVal value As Int64)
            mvarDeviceID = value
        End Set
    End Property

#End Region

    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub

    Public Function GetDeviceIDPosIDAndSentToSwitchStateByOutlet() As DataTable
        Try
            Me.BeginProc()
            Dim dt As New DataTable

            Dim parOutlet As New OracleParameter("Outlet_", OracleDbType.NVarchar2, 15)
            parOutlet.Value = Outlet
            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'usp_GetDeviceIDPosIDAndSendToSwitchStateByOutlet
            strSQL = "usp_GetSendToSwtcStatByOutlet"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parOutlet, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()
        End Try
    End Function

    Public Function GetLastDeviceOfPosByMyDeviceID() As DataTable
        Try
            Me.BeginProc()
            Dim dt As New DataTable

            Dim parDeviceID As New OracleParameter("@DeviceID", OracleDbType.Int64)
            parDeviceID.Value = DeviceID

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            'usp_GetLastDeviceOfPosByDeviceID
            strSQL = "usp_GetLastDevOfPosByDevID"
            Fill(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, dt, parDeviceID, parRefCursor)
            Return dt
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()
        End Try
    End Function

    Public Sub UndoDeviceCancel()
        Try
            Me.BeginProc()
            Dim parOutlet As New OracleParameter("Outlet_", OracleDbType.Varchar2, 15)
            parOutlet.Value = Outlet

            strSQL = "usp_UndoDeviceCancel"
            Execute_NonQuery(RIZNARM.Data.Oracle_Client.DataAccess.CommandType.StoreProcedure, strSQL, parOutlet)
        Catch ex As Exception
            Throw ex
        Finally
            Me.EndProc()
        End Try
    End Sub

End Class
