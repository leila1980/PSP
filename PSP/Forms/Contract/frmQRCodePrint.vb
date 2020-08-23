Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing

Public Class frmQRCodePrint
    Inherits Form

    Private CounterVar As Integer = 0

    Public Serial As String
    Public StoreName As String
    Public Outlet As String

    Private clsDalContract As New ClassDALContract(modPublicMethod.ConnectionString)
    Private ImageDictionary As Dictionary(Of Integer, Byte())

    Private dt As New DataTable
    Private ImageURL As String = ""
    Private Image As Image = Nothing
    Private BMP As Bitmap


    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub frmQRCodePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblSerialNo.Text = Me.Serial
        Me.lblStoreName.Text = Me.StoreName

        Me.GenerateQRCode(Me.Serial)

    End Sub

    Private Sub GenerateQRCode1(ByVal data As String)
        Try
            Dim qrcode As New TarCode.Barcode.Control.Matrix()

            qrcode.BarcodeType = TarCode.Barcode.Control.MatrixBarcode.QRcode
            qrcode.Valid_Data = data
            qrcode.Width_X = 8
            qrcode.WtoH_Ratio = 1
            'qrcode.drawToFile("c://tarcode-qrcode.png")

            Dim MStream As IO.MemoryStream = Nothing

            Dim ImgBytes() As Byte = qrcode.drawToBytes()
            'Read the image data bytes into a MemoryStream
            MStream = New IO.MemoryStream(ImgBytes)
            'Create a Bitmap from the memory stream data
            Dim Bmp As New Drawing.Bitmap(MStream)
            'Assign the bitmap as the PictureBox Image
            PictureBox2.Image = Bmp

            'Do a victory dance. It worked!

        Catch ex As Exception
            MsgBox("An error generate QRCode: " & ex.Message)
        End Try


    End Sub

    Private Sub GenerateQRCode(ByVal data As String)
        Try


            Dim qrcode As OnBarcode.Barcode.QRCode
            qrcode = New OnBarcode.Barcode.QRCode()
            qrcode.Data = data
            qrcode.X = 8

            ' Create QR-Code and encode barcode to Jpeg format
            qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
            'qrcode.drawBarcode("C://vbnet-qrcode.jpg")

            Dim MStream As IO.MemoryStream = Nothing

            Dim ImgBytes() As Byte = qrcode.drawBarcodeAsBytes()
            'Read the image data bytes into a MemoryStream
            MStream = New IO.MemoryStream(ImgBytes)
            'Create a Bitmap from the memory stream data
            Dim Bmp As New Drawing.Bitmap(MStream)
            'Assign the bitmap as the PictureBox Image
            PictureBox2.Image = Bmp

            'Do a victory dance. It worked!

        Catch ex As Exception
            MsgBox("An error generate QRCode: " & ex.Message)
        End Try


    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        e.Graphics.DrawImage(PictureBox2.Image, 0, 0)

    End Sub

    Private Sub BtnPrintNetwerk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        Dim pd As New PrintDocument
        Dim pdialog As New PrintDialog
        Dim ppd As New PrintPreviewDialog
        BMP = New Bitmap(GroupBox1.Width, GroupBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)

        GroupBox1.DrawToBitmap(BMP, New Rectangle(0, 0, GroupBox1.Width, GroupBox1.Height))
        AddHandler pd.PrintPage, (Sub(s, args)
                                      args.Graphics.DrawImage(BMP, 0, 0)
                                      args.HasMorePages = False
                                  End Sub)
        ''choose a printer
        'pdialog.ShowDialog(Me)
        'pd.PrinterSettings.PrinterName = pdialog.PrinterSettings.PrinterName

        'If pd.PrinterSettings.CanDuplex.ToString Then
        '    pd.PrinterSettings.Duplex = Duplex.Vertical
        'End If

        ''Preview the document
        'ppd.Document = pd
        'ppd.ShowDialog(Me)

        pd.Print()      'actually print data

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim qrcodestatus As Int16
            If chkQRCode.Checked = True Then
                qrcodestatus = 1
            Else
                qrcodestatus = 0
            End If

            clsDalContract.BeginProc()
            clsDalContract.Updateqrcodestatus(Me.Outlet, qrcodestatus)
            MsgBox("عملیات با موفقیت انجام شد")

        Catch ex As Exception

            MessageBox.Show(ex.ToString())
        Finally
            clsDalContract.EndProc()
        End Try
    End Sub
End Class
