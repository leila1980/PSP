Imports System.IO

Public Class ClassText

    Private Shared mvarTextFilePath As String
    Public Shared Property TextFilePath()
        Get
            Return mvarTextFilePath
        End Get
        Set(ByVal value)
            mvarTextFilePath = value
        End Set
    End Property
    Public Shared Function GetText(ByVal Delimiter As String) As DataTable
        Try
            Dim LineIn As String
            Dim LineIn_arr
            Dim oRead As System.IO.StreamReader
            Dim dtTextFile As New DataTable
            Dim drTextFile As DataRow

            If System.IO.File.Exists(TextFilePath) = False Then
                Throw New FileNotFoundException
            Else
                '---Create Columns
                oRead = System.IO.File.OpenText(TextFilePath)
                LineIn = oRead.ReadLine()
                LineIn_arr = LineIn.Split(Delimiter)
                For i As Int32 = 0 To LineIn_arr.length - 1
                    dtTextFile.Columns.Add("col" + i.ToString)
                Next
                dtTextFile.AcceptChanges()
                '---Create Rows
                oRead = System.IO.File.OpenText(TextFilePath)
                While oRead.Peek <> -1
                    LineIn = oRead.ReadLine()
                    LineIn_arr = LineIn.Split(Delimiter)
                    drTextFile = dtTextFile.NewRow
                    For i As Int32 = 0 To LineIn_arr.length - 1
                        drTextFile.Item(i) = LineIn_arr(i)
                    Next
                    dtTextFile.Rows.Add(drTextFile)
                    dtTextFile.AcceptChanges()
                End While
                oRead.Close()
                Return dtTextFile
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function GetText() As DataTable
        Try
            Dim LineIn As String
            Dim oRead As System.IO.StreamReader
            Dim dtTextFile As New DataTable
            Dim drTextFile As DataRow

            If System.IO.File.Exists(TextFilePath) = False Then
                Throw New FileNotFoundException
            Else
                '---Create Columns
                dtTextFile.Columns.Add("col0")
                dtTextFile.AcceptChanges()
                '---Create Rows
                oRead = System.IO.File.OpenText(TextFilePath)
                While oRead.Peek <> -1
                    LineIn = oRead.ReadLine()
                    drTextFile = dtTextFile.NewRow
                    drTextFile.Item(0) = LineIn
                    dtTextFile.Rows.Add(drTextFile)
                    dtTextFile.AcceptChanges()
                End While
                oRead.Close()
                Return dtTextFile
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
