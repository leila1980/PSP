Imports Newtonsoft.Json
Imports PL.ViewModel.WebPosWebService
Imports PL_CSharp
Imports System.Net
Imports System.Text
Imports ViewModel.ViewModel.WebPos.PL_CSharp

Public Class FrmTest
    Private Sub FrmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim webPosDTO As New WebPosDTO


        webPosDTO.Serial = "string"
        webPosDTO.Code = 0

        Dim rowList As New List(Of WebPosDTO)



        rowList.Add(webPosDTO)
        rowList.Add(webPosDTO)

        Dim webClient As New WebClient()
        Dim resByte As Byte()
        Dim resString As String
        Dim reqString() As Byte

        Try
            webClient.Headers("content-type") = "application/json"
            reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(rowList, Formatting.Indented))
            resByte = webClient.UploadData("http://192.168.50.27:1026/api/v1/terminal_add_csv/", "post", reqString)
            resString = Encoding.Default.GetString(resByte)


            webClient.Dispose()



        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try


    End Sub

    Public Function MD5Hash(ByVal Token As String, ByVal accessKey As String) As String
        Dim x As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bs As Byte() = System.Text.Encoding.UTF8.GetBytes(Token & accessKey)
        bs = x.ComputeHash(bs)
        Dim s As New System.Text.StringBuilder()
        For Each b As Byte In bs
            s.Append(b.ToString("x2").ToLower())
        Next
        Dim encryptedString As String = s.ToString()
        Return encryptedString

    End Function


End Class