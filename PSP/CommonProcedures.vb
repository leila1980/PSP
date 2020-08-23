Imports Newtonsoft.Json
Imports System.Net
Imports System.Text
Imports ViewModel.ViewModel.WebPos.PL_CSharp
Public Class CommonProcedures

    Public Sub CallPostWebService(url As String, contenrtType As String, webPoses As List(Of WebPosDTO))
        Dim webClient As New WebClient()
        Dim resByte As Byte()
        Dim resString As String
        Dim reqString() As Byte

        Try
            webClient.Headers("content-type") = contenrtType

            reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(webPoses, Formatting.Indented))
            resByte = webClient.UploadData(url, "post", reqString)
            resString = Encoding.Default.GetString(resByte)

            webClient.Dispose()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub


End Class
