Public Class ClassPrintLabel(Of T As ClassDALContract)
    Public Enum PrintLabelTypeEnum As Short
        ContractID = 1
        ContractID_PoseCode_Outlet = 2
        ContractID_StoreName = 3
    End Enum
    Public Shared PrintLabelType As PrintLabelTypeEnum

    Public Shared Sub Print(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal tClass As T)
        Dim g As Graphics = e.Graphics
        Dim Barcodeheight As Integer = 45
        Dim X1 As Integer
        Dim Y1 As Integer

        Select Case PrintLabelType
            Case PrintLabelTypeEnum.ContractID
                X1 = 105 : Y1 = 6
                g.DrawString("کد قرارداد", New Font("B Titr", 8, FontStyle.Bold), Brushes.Black, X1, Y1)
                X1 = 4 : Y1 = 6
                g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(tClass.ContractID), Barcodeheight, True), X1, Y1)

            Case PrintLabelTypeEnum.ContractID_StoreName

                X1 = 210 : Y1 = 1
                g.DrawString("شاپرک", New Font("B Titr", 5, FontStyle.Bold), Brushes.Black, X1, Y1)

                X1 = 210 : Y1 = 10
                g.DrawString("کد قرارداد", New Font("B Titr", 10, FontStyle.Bold), Brushes.Black, X1, Y1)
                X1 = 170 : Y1 = 10
                g.DrawString(tClass.ContractID.ToString, New Font("B Titr", 10, FontStyle.Bold), Brushes.Black, X1, Y1)
                X1 = 50 : Y1 = 10
                g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(tClass.ContractID), Barcodeheight, False), X1, Y1)

                X1 = 200 : Y1 = 45
                g.DrawString("نام فروشگاه", New Font("B Titr", 10, FontStyle.Bold), Brushes.Black, X1, Y1)
                X1 = 50 : Y1 = 45
                g.DrawString(tClass.SName_nvc, New Font("B Titr", 15, FontStyle.Bold), Brushes.Black, X1, Y1)

                X1 = 200 : Y1 = 90
                g.DrawString("نام پذیرنده", New Font("B Titr", 8, FontStyle.Bold), Brushes.Black, X1, Y1)
                X1 = 50 : Y1 = 90
                g.DrawString(tClass.FirstName_nvc + " " + tClass.LastName_nvc, New Font("B Titr", 12, FontStyle.Bold), Brushes.Black, X1, Y1)

                X1 = 200 : Y1 = 125
                g.DrawString("نام شهر", New Font("B Titr", 8, FontStyle.Bold), Brushes.Black, X1, Y1)
                X1 = 50 : Y1 = 125
                g.DrawString(tClass.SCityname_nvc, New Font("B Titr", 12, FontStyle.Bold), Brushes.Black, X1, Y1)

        End Select
    End Sub
    'Public Shared Sub SamplePrint(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
    '    Dim g As Graphics = e.Graphics
    '    Dim Barcodeheight As Integer = 45
    '    Dim X1 As Integer
    '    Dim Y1 As Integer

    '    'X1 = 105 : Y1 = 6
    '    'g.DrawString("کد قرارداد", New Font("B Titr", 8, FontStyle.Bold), Brushes.Black, X1, Y1)
    '    X1 = 4 : Y1 = 6
    '    For i As Integer = 200 To 250
    '        g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage("A" + i.ToString, Barcodeheight, True), X1, Y1)
    '        X1 = X1 + 20 : Y1 = 6
    '    Next
    '    'X1 = 4 : Y1 = 6
    '    'g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage("A"+ , Barcodeheight, True), X1, Y1)


    '    'X1 = 210 : Y1 = 10
    '    'g.DrawString("کد قرارداد", New Font("B Titr", 10, FontStyle.Bold), Brushes.Black, X1, Y1)
    '    'X1 = 160 : Y1 = 10
    '    'g.DrawString(tClass.ContractID.ToString, New Font("B Titr", 10, FontStyle.Bold), Brushes.Black, X1, Y1)
    '    'X1 = 50 : Y1 = 10
    '    'g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(tClass.ContractID), Barcodeheight, False), X1, Y1)
    '    'Case PrintLabelTypeEnum.ContractID_PoseCode_Outlet
    '    '    X1 = 50 : Y1 = 35
    '    '    g.DrawString("کد قرارداد", New Font("Tahoma", 8), Brushes.Black, X1, Y1)
    '    '    X1 = 50 : Y1 = 50
    '    '    g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(tClass.ContractID), Barcodeheight), X1, Y1)

    '    '    X1 = 50 : Y1 = 95
    '    '    g.DrawString("Pos Code", New Font("Tahoma", 8), Brushes.Black, X1, Y1)
    '    '    X1 = 50 : Y1 = 110
    '    '    g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(tClass.DCode_vc), Barcodeheight), X1, Y1)

    '    '    X1 = 50 : Y1 = 155
    '    '    g.DrawString("Outlet", New Font("Tahoma", 8), Brushes.Black, X1, Y1)
    '    '    X1 = 50 : Y1 = 170
    '    '    g.DrawImage(BarCode128.Code128Rendering.MakeBarcodeImage(Convert.ToString(tClass.DOutlet_vc), Barcodeheight), X1, Y1)

    'End Sub

End Class
