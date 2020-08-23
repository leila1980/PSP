Public Class ClassError
    Public Shared Sub LogError(ByVal ex As Exception)
        '===EventViewer
        ShowErrorMessage(ex.Message)
    End Sub

    Public Shared Sub LogError(ByVal FileName As String, ByVal colErr As Collection) 'ByVal txtErr As String
        modPublicMethod.CreateDirectory(TextLogErrorFilePath.Substring(0, TextLogErrorFilePath.Length - 1)) 'C:\EniacTech_LogError")

        Dim strLogErrorFilePath As String = TextLogErrorFilePath + FileName
        If IO.File.Exists(strLogErrorFilePath) Then
            IO.File.Delete(strLogErrorFilePath)
        End If
        Dim FS As New System.IO.FileStream(strLogErrorFilePath, IO.FileMode.Create)
        Dim SW As New System.IO.StreamWriter(FS)
        For i As Int32 = 1 To colErr.Count
            SW.WriteLine(colErr.Item(i).ToString)
        Next
        SW.Close()
    End Sub

    Public Shared Sub ExcelLogError(ByVal FileName As String, ByVal DataTable As DataTable)
        modPublicMethod.CreateDirectory(TextLogErrorFilePath.Substring(0, TextLogErrorFilePath.Length - 1)) 'C:\EniacTech_LogError")
        Dim strLogErrorFilePath As String = TextLogErrorFilePath + FileName
        Try
            If IO.File.Exists(strLogErrorFilePath) Then
                IO.File.Delete(strLogErrorFilePath)
            End If

            Dim clsExcel As New ClassExcel(strLogErrorFilePath)
            clsExcel.Write(DataTable)

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            ClassError.LogError(ex)
        End Try

    End Sub

    Public Shared Sub EmptyLogErrorFolder()
        modPublicMethod.CreateDirectory(TextLogErrorFilePath.Substring(0, TextLogErrorFilePath.Length - 1)) 'C:\EniacTech_LogError")

        Dim strFiles() As String
        strFiles = IO.Directory.GetFiles(TextLogErrorFilePath.Substring(0, TextLogErrorFilePath.Length - 1))
        For i As Int32 = 0 To strFiles.Length - 1
            IO.File.Delete(strFiles(i))
        Next
    End Sub
    Public Shared Sub BackupLogErrorFolder()
        modPublicMethod.CreateDirectory(TextBckupsLogErrorFilePath.Substring(0, TextBckupsLogErrorFilePath.Length - 1)) '"C:\EniacTech_LogError\Bckups")

        Dim strFiles() As String
        Dim arrSplit()
        strFiles = IO.Directory.GetFiles(TextLogErrorFilePath.Substring(0, TextLogErrorFilePath.Length - 1))
        For i As Int32 = 0 To strFiles.Length - 1
            arrSplit = strFiles(i).Split("\")
            IO.File.Copy(strFiles(i), TextBckupsLogErrorFilePath + arrSplit(arrSplit.Length - 1), True)
        Next
    End Sub

End Class
