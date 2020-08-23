Public Class ClassLogger

    Public Shared Sub WriteEventLog(ByVal sSource As String, ByVal sEvent As String, ByVal sLog As EventLogEntryType, ByVal eventid As Integer)


        Try
            If System.Diagnostics.EventLog.SourceExists(sSource) = False Then
                System.Diagnostics.EventLog.CreateEventSource(sSource, "shaparak")
            End If

            EventLog.WriteEntry(sSource, sEvent, sLog, eventid)

        Catch ex As Exception
            Throw ex
        End Try


    End Sub

End Class
