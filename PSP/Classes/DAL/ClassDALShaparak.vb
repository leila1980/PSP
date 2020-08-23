Imports Oracle.DataAccess.Client
Public Class ClassDALShaparak
    Inherits RIZNARM.Data.Oracle_Client.DataAccess

#Region "Fields"
    Private dtShaparak As New DataTable
    Private dtShaparakIBAN As New DataTable
    Private dtallShaparak As New DataTable
    Dim cnt As OracleConnection
    Dim cmd As New OracleCommand
   
#End Region


#Region "Constractors"
    Public Sub New(ByVal CS As String)
        MyBase.New(CS)
    End Sub
#End Region
#Region "Functions"
    Public Function GetAllNotSentToShaparak(ByVal sentToShaparak As Int16, ByVal PosId As String) As DataTable
        Try
            dtShaparak.Clear()
            Dim parSentToShaparak As New OracleParameter("SentToShaparak_", OracleDbType.Int16)
            parSentToShaparak.Value = sentToShaparak

            Dim parPosId As New OracleParameter("PosId_", OracleDbType.Char)
            parPosId.Value = PosId


            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetShprkWithSentToShprk_SP", dtShaparak, parSentToShaparak, parPosId, parRefCursor)


            Return dtShaparak
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllNotSentToShaparakIBAN(ByVal sentToShaparak As Int16, ByVal accountNo As String, ByVal PosId As String) As DataTable
        Try
            dtShaparakIBAN.Clear()

            Dim parSentToShaparak As New OracleParameter("SentToShaparak_", OracleDbType.Int16)
            parSentToShaparak.Value = sentToShaparak

            Dim parAccountNo As New OracleParameter("AccountNo_", OracleDbType.NVarchar2, 50)
            parAccountNo.Value = accountNo

            Dim parPosId As New OracleParameter("PosId_", OracleDbType.Char)
            parPosId.Value = PosId

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)
            Me.Fill(CommandType.StoreProcedure, "GetShprkWithSentToShprkIBAN_SP", dtShaparakIBAN, parSentToShaparak, parAccountNo, parPosId, parRefCursor)
            Return dtShaparakIBAN
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllSentToShaparak(ByVal ISSENTTOSHPRK As String, ByVal PosId As String) As DataTable
        Try

            dtallShaparak.Clear()

            Dim parISSENTTOSHPRK As New OracleParameter("ISSENTTOSHPRK_", OracleDbType.Varchar2, 3)
            parISSENTTOSHPRK.Value = ISSENTTOSHPRK


            Dim parPosId As New OracleParameter("PosId_", OracleDbType.Char)
            parPosId.Value = PosId

            Dim parRefCursor As New OracleParameter("RESULT_", OracleDbType.RefCursor, ParameterDirection.Output)

            Me.Fill(CommandType.StoreProcedure, "GetShprkWithSentToShprkAllStt", dtallShaparak, parISSENTTOSHPRK, parPosId, parRefCursor)
            Return dtallShaparak
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub UpdateSentToShaparak(ByVal fromSentToShaparak As Int16, ByVal toSentToShaparak As Int16, ByVal PosId As String)
        Try
            Dim parFromSentToShaparak As New OracleParameter("FromSentToShaparak_", OracleDbType.Int16)
            parFromSentToShaparak.Value = fromSentToShaparak

            Dim parToSentToShaparak As New OracleParameter("ToSentToShaparak_", OracleDbType.Int16)
            parToSentToShaparak.Value = toSentToShaparak

            Dim parPosId As New OracleParameter("PosId_", OracleDbType.Char)
            parPosId.Value = PosId

            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateSentToShprkFromTo_SP", parFromSentToShaparak, parToSentToShaparak, parPosId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateISSentToShaparak(ByVal FromSENTTOSHPRK As String, ByVal ISSENTTOSHPRK As String, ByVal PosId As String)
        Try
            Dim parFromSENTTOSHPRK As New OracleParameter("FROMSENTTOSHPRK_", OracleDbType.Char)
            parFromSENTTOSHPRK.Value = FromSENTTOSHPRK

            Dim parISSENTTOSHPRK As New OracleParameter("ISSENTTOSHPRK_", OracleDbType.Char)
            parISSENTTOSHPRK.Value = ISSENTTOSHPRK

            Dim parPosId As New OracleParameter("PosId_", OracleDbType.Char)
            parPosId.Value = PosId

            Me.Execute_NonQuery(CommandType.StoreProcedure, "UpdateISSentToShprk_SP", parFromSENTTOSHPRK, parISSENTTOSHPRK, parPosId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub OpenConnection()
        Try
            cnt = New OracleConnection

            'If cnt.State <> ConnectionState.Open Then
            With cnt
                .ConnectionString = modPublicMethod.ConnectionString
                .Open()
            End With
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CloseConnection()
        Try
            cnt.Close()
            cnt.Dispose()
            cnt = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class
