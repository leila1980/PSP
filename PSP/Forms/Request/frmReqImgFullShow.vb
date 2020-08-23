Imports System.IO
Public Class frmReqImgFullShow

    Private FilePath As String

    Public Sub New(ByVal FilePath As String)
        InitializeComponent()
        Me.FilePath = FilePath
    End Sub

    Private Sub frmReqImgFullShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.picBoxReqImg.Image = Image.FromFile(FilePath)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class