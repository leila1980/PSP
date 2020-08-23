Imports System.Text
Imports c

Namespace Convertor

    Public Class ConvertMethods

#Region "PrivateConstructor"
        Private Sub New()
        End Sub
#End Region


#Region "Methods"
        Public Shared Function FaToEnFirstLineString(ByVal faString As String) As String
            Try
                Dim finglishResult As String = String.Empty
                If faString = String.Empty Then
                    Return String.Empty
                End If
                finglishResult = CreateFinglish(faString)
                If finglishResult.Length > 99 And finglishResult.Length <= 255 Then
                    finglishResult = finglishResult.Substring(100, finglishResult.Length - 100)
                ElseIf finglishResult.Length > 99 And finglishResult.Length > 255 Then
                    finglishResult = finglishResult.Substring(100, 255 - 100)
                ElseIf finglishResult.Length <= 99 Then
                    finglishResult = finglishResult.Substring(0, finglishResult.Length)
                End If

                Return finglishResult.ToString
            Catch ex As Exception
                MessageBox.Show("1")
                Return String.Empty
            End Try

        End Function

        Public Shared Function FaToEnSecoundLineString(ByVal faString As String) As String
            Try

                Dim finglishResult As String = String.Empty
                If faString = String.Empty Then
                    Return String.Empty
                End If

                finglishResult = CreateFinglish(faString)

                If finglishResult.Length > 99 And finglishResult.Length <= 255 Then
                    finglishResult = finglishResult.Substring(100, finglishResult.Length - 100)
                ElseIf finglishResult.Length > 99 And finglishResult.Length > 255 Then
                    finglishResult = finglishResult.Substring(100, 255 - 100)
                ElseIf finglishResult.Length < 99 Then
                    finglishResult = String.Empty
                End If

                Return finglishResult.ToString
            Catch ex As Exception
                MessageBox.Show("2")
                Return String.Empty
            End Try


        End Function

        Public Shared Function FaToEnFirsLineBytes(ByVal faString As String) As String
            Try

                Dim finglishResult As String = String.Empty
                If faString = String.Empty Then
                    Return String.Empty
                End If

                finglishResult = CreateFinglish(faString)

                If finglishResult.Length > 99 And finglishResult.Length <= 255 Then
                    finglishResult = finglishResult.Substring(100, finglishResult.Length - 100)
                ElseIf finglishResult.Length > 99 And finglishResult.Length > 255 Then
                    finglishResult = finglishResult.Substring(100, 255 - 100)
                ElseIf finglishResult.Length <= 99 Then
                    finglishResult = finglishResult.Substring(0, finglishResult.Length)
                End If

                Return finglishResult.ToString
                'Return New UTF8Encoding(True).GetBytes(enResult.ToString)
            Catch ex As Exception
                MessageBox.Show("3")
                Return String.Empty
            End Try

        End Function
        Public Shared Function FaToEnSecoundLineBytes(ByVal faString As String) As String
            Try
                Dim finglishResult As String = String.Empty
                If faString = String.Empty Then
                    Return String.Empty
                End If

                finglishResult = CreateFinglish(faString)

                If finglishResult.Length > 99 And finglishResult.Length <= 255 Then
                    finglishResult = finglishResult.Substring(100, finglishResult.Length - 100)
                ElseIf finglishResult.Length > 99 And finglishResult.Length > 255 Then
                    finglishResult = finglishResult.Substring(100, 255 - 100)
                ElseIf finglishResult.Length < 99 Then
                    finglishResult = String.Empty
                End If

                Return finglishResult.ToString
            Catch ex As Exception
                MessageBox.Show("4")
                Return String.Empty
            End Try
        End Function
        Private Shared Function CreateFinglish(ByVal faString As String) As String

            Dim enResult As New System.Text.StringBuilder(String.Empty)
            faString = faString.Trim
            Dim faToEnHash As New Hashtable

            faToEnHash.Add("آ", "a")
            faToEnHash.Add("ا", "a")
            faToEnHash.Add("ب", "b")
            faToEnHash.Add("پ", "p")
            faToEnHash.Add("ت", "t")
            faToEnHash.Add("ث", "s")
            faToEnHash.Add("ج", "j")
            faToEnHash.Add("چ", "ch")
            faToEnHash.Add("ح", "h")
            faToEnHash.Add("خ", "kh")
            faToEnHash.Add("د", "d")
            faToEnHash.Add("ذ", "z")
            faToEnHash.Add("ر", "r")
            faToEnHash.Add("ز", "z")
            faToEnHash.Add("ژ", "jh")
            faToEnHash.Add("س", "s")
            faToEnHash.Add("ش", "sh")
            faToEnHash.Add("ص", "s")
            faToEnHash.Add("ض", "z")
            faToEnHash.Add("ط", "t")
            faToEnHash.Add("ظ", "z")
            faToEnHash.Add("ع", "a")
            faToEnHash.Add("غ", "gh")
            faToEnHash.Add("ف", "f")
            faToEnHash.Add("ق", "gh")
            faToEnHash.Add("ک", "k")
            faToEnHash.Add("ك", "k")
            faToEnHash.Add("گ", "g")
            faToEnHash.Add("ل", "l")
            faToEnHash.Add("م", "m")
            faToEnHash.Add("ن", "n")
            faToEnHash.Add("و", "v")
            faToEnHash.Add("ه", "h")
            faToEnHash.Add("ی", "i")
            faToEnHash.Add("ي", "i")
            faToEnHash.Add("ء", "e")
            faToEnHash.Add("ئ", "a")
            faToEnHash.Add("ِ", "")
            faToEnHash.Add("?", "")

            For Each c As String In faString
                If faToEnHash.ContainsKey(c) Then
                    enResult.Append(faToEnHash(c))
                Else
                    enResult.Append(c)
                End If
            Next
            Return enResult.ToString

        End Function

        Public Shared Function DateToString(ByVal dateString As String) As String
            Try

                If dateString.Trim = String.Empty Then
                    Return String.Empty
                End If
                dateString = Jalali2Miladi(dateString)

                Return dateString
            Catch ex As Exception
                MessageBox.Show("5")
                Return String.Empty
            End Try
        End Function
        Private Shared Function Jalali2Miladi(ByVal _date As String) As String
            Dim Prdate() As String = Split(_date, "/")
            Dim Mdate As New System.Globalization.PersianCalendar
            Return Mdate.ToDateTime(Int(Prdate(0)), Int(Prdate(1)), Int(Prdate(2)), 1, 1, 1, System.Globalization.GregorianCalendar.ADEra).ToString
        End Function
        Public Shared Function IBAN(ByVal input As String) As String
            Return input.PadRight(34, " ")



                ' Return System.Text.ASCIIEncoding.UTF8.GetBytes(result.ToString)

        End Function
        Public Shared Function DateToByte2(ByVal input As Date) As String
            Try

                Dim DateString As String = input.Year.ToString + "/" + input.Month.ToString.PadLeft(2, "0") + "/" + input.Day.ToString.PadLeft(2, "0")
                Dim result As New System.Text.StringBuilder
                Dim dateSubStrResult As String = DateString.Substring(0, 10)
                Dim dateSplitResult As String() = dateSubStrResult.Split("/")

                For i As Integer = 0 To dateSplitResult.Length - 1
                    result.Append(dateSplitResult((dateSplitResult.Length - 1) - i))
                    If i <> 2 Then
                        result.Append("/")
                    End If
                Next
                Return result.ToString
                ' Return System.Text.ASCIIEncoding.UTF8.GetBytes(result.ToString)
                'Return New UTF8Encoding(True).GetBytes(result.ToString)

            Catch ex As Exception
                MessageBox.Show("6")
                Return ""
                'Return System.Text.ASCIIEncoding.ASCII.GetBytes(String.Empty)
            End Try
        End Function

        Public Shared Function DateToByte(ByVal dateString As String) As String
            Try
                If dateString.Trim = String.Empty Then
                    Return String.Empty
                End If
                dateString = Jalali2Miladi(dateString)
                Return dateString.ToString
            Catch ex As Exception
                MessageBox.Show("6")
                Return String.Empty
            End Try
        End Function
        Public Shared Function IranSystemFirstSubStringToByte(ByVal faString As String) As String
            Try
                If faString.Trim = String.Empty Then
                    Return String.Empty
                End If
                faString = faString.Trim
                If faString.Length >= 99 Then
                    faString = faString.Substring(0, 99)
                Else
                    faString = faString.Substring(0, faString.Length)
                End If
                'Return System.Text.ASCIIEncoding.UTF8.GetBytes(faString.Trim)
                Return GetIranSystem(faString)

            Catch ex As Exception
                MessageBox.Show("7")
                Return String.Empty
            End Try
        End Function

        Public Shared Function IranSystemSpiltSubStringToByte(ByVal faString As String) As String
            Try
                If faString.Trim = String.Empty Then
                    Return String.Empty
                End If
                faString = faString.Trim
                If faString.Length >= 99 Then
                    faString = faString.Substring(0, 99)
                Else
                    faString = faString.Substring(0, faString.Length)
                End If
                ''''''''''''''
                Dim dtAddress As New DataTable
                Dim parameters() As String = faString.Split("،")

                With dtAddress.Columns
                    .Add("col1")
                End With
                For Each item As String In parameters
                    If item.IndexOf("&") = 0 Then
                        item = item.Substring(1, item.Length - 1)
                    End If
                    Dim param() As String = item.Split("&")
                    If param.Length = 3 Then
                        dtAddress.Rows.Add(param(0).Trim + "&" + param(1).Trim + "&" + GetIranSystem(param(2).Trim))
                    ElseIf param.Length = 2 Then
                        dtAddress.Rows.Add(param(0).Trim + "&" + GetIranSystem(param(1).Trim))
                    End If
                Next
                Dim finalString As String = Nothing
                For Each row As DataRow In dtAddress.Rows
                    finalString += row("col1").ToString & "ٹ"
                Next
                ''''''''''''               
                'Return System.Text.ASCIIEncoding.UTF8.GetBytes(faString.Trim)
                Return finalString.Substring(0, finalString.Length - 1)

            Catch ex As Exception
                MessageBox.Show("7")
                Return String.Empty
            End Try
        End Function
        Public Shared Function SpiltSubStringFullName(ByVal faString As String) As String
            Try
                If faString.Trim = String.Empty Then
                    Return String.Empty
                End If
                faString = faString.Trim
                faString = faString.Trim
                If faString.Length > 51 Then
                    faString = faString.Substring(0, 51)
                Else
                    faString = faString.Substring(0, faString.Length)
                End If
                '   Dim commaIran = convert(New Byte() {138})
                Dim parameters() As String = faString.Split("،")
                ' Return GetIranSystem(parameters(1).Trim) & commaIran.ToString & GetIranSystem(parameters(0).Trim)
                Dim finalString As String = Nothing
                finalString = GetIranSystem(parameters(1).Trim) & "," & GetIranSystem(parameters(0).Trim)
                Return finalString
            Catch ex As Exception
                MessageBox.Show("72")
                Return String.Empty
            End Try
        End Function
     

        Public Shared Function SpiltSubStringCity(ByVal faString As String) As String
            Try
                If faString.Trim = String.Empty Then
                    Return String.Empty
                End If
                faString = faString.Trim
                '  Dim commaIran = convert(New Byte() {138})
                Dim parameters() As String = faString.Split("،")

                ' Return parameters(0).Trim & commaIran.ToString  & parameters(1).Trim
                Dim finalString As String = Nothing
                finalString = parameters(0).Trim & "," & parameters(1).Trim
                Return finalString
            Catch ex As Exception
                MessageBox.Show("71")
                Return String.Empty
            End Try
        End Function
        Private Shared Function convert(ByVal bytes() As Byte) As String
            Return String.Concat(System.Text.Encoding.Default.GetString(bytes))
        End Function
        Public Shared Function IranSystemSecoundSubStringToByte(ByVal faString As String) As String
            Try
                If faString.Trim = String.Empty Then
                    Return String.Empty
                End If
                faString = faString.Trim
                If faString.Length > 99 And faString.Length <= 255 Then
                    faString = faString.Substring(100, faString.Length - 100)
                ElseIf faString.Length > 99 And faString.Length > 255 Then
                    faString = faString.Substring(100, 255 - 100)
                ElseIf faString.Length < 99 Then
                    faString = String.Empty
                End If
                ' Return System.Text.ASCIIEncoding.UTF8.GetBytes(faString.Trim)
                Return GetIranSystem(faString)
            Catch ex As Exception
                MessageBox.Show("8")
                Return String.Empty
            End Try
        End Function
        Public Shared Function FirstSubStringToByte(ByVal faString As String) As String
            Try
                If faString.Trim = String.Empty Then
                    Return String.Empty
                End If
                faString = faString.Trim
                If faString.Length >= 99 Then
                    faString = faString.Substring(0, 99)
                Else
                    faString = faString.Substring(0, faString.Length)
                End If
                Return faString.Trim
                'Return GetIranSystem(faString)

            Catch ex As Exception
                MessageBox.Show("7")
                Return String.Empty
            End Try
        End Function

        Public Shared Function SecoundSubStringToByte(ByVal faString As String) As String
            Try
                If faString.Trim = String.Empty Then
                    Return String.Empty
                End If
                faString = faString.Trim
                If faString.Length > 99 And faString.Length <= 255 Then
                    faString = faString.Substring(100, faString.Length - 100)
                ElseIf faString.Length > 99 And faString.Length > 255 Then
                    faString = faString.Substring(100, 255 - 100)
                ElseIf faString.Length < 99 Then
                    faString = String.Empty
                End If
                Return faString.Trim
                'Return GetIranSystem(faString)
            Catch ex As Exception
                MessageBox.Show("8")
                Return String.Empty
            End Try
        End Function

        Public Shared Function SubFirstStringToString(ByVal faString As String) As String
            Try
                If faString.Trim = String.Empty Then
                    Return String.Empty
                End If
                faString = faString.Trim
                If faString.Length > 99 Then
                    faString = faString.Substring(0, 99)
                Else
                    faString = faString.Substring(0, faString.Length)
                End If
                Return faString.Trim
            Catch ex As Exception
                MessageBox.Show("9")
                Return String.Empty
            End Try
        End Function

        Public Shared Function SubSecoundStringToString(ByVal faString As String) As String
            Try
                If faString.Trim = String.Empty Then
                    Return String.Empty
                End If
                faString = faString.Trim
                If faString.Length > 99 And faString.Length <= 255 Then
                    faString = faString.Substring(100, faString.Length - 100)
                ElseIf faString.Length > 99 And faString.Length > 255 Then
                    faString = faString.Substring(100, 255 - 100)
                ElseIf faString.Length < 99 Then
                    faString = String.Empty
                End If
                Return faString.Trim
            Catch ex As Exception
                MessageBox.Show("10")
                Return String.Empty
            End Try
        End Function
#Region "IranSystem"
        Public Shared Function ConvertUnicodeToIranSystem(ByVal chrIn As String, ByVal chrIn_pre As String, ByVal chrIn_post As String) As Byte
            Try
                Dim ascChrIn As Int32
                Dim ascChrIn_pre As Int32
                Dim ascChrIn_post As Int32

                Dim ascChrOut As Byte
                ascChrIn = AscW(chrIn)
                ascChrIn_pre = AscW(chrIn_pre)
                ascChrIn_post = AscW(chrIn_post)


                Select Case ascChrIn
                    Case Is <= 127
                        ascChrOut = ascChrIn
                        If ascChrIn = 32 Then
                            ascChrOut = &HFF
                        End If
                    Case Else
                        Select Case ascChrIn
                            '===اعداد فارسي
                            Case &H6F0  'فارسي 0 
                                ascChrOut = &H80
                            Case &H660 'فارسي 0 
                                ascChrOut = &H80
                            Case &H6F1  'فارسي 1 
                                ascChrOut = &H81
                            Case &H661 'فارسي 1 
                                ascChrOut = &H81
                            Case &H6F2  'فارسي 2 
                                ascChrOut = &H82
                            Case &H662 'فارسي 2 
                                ascChrOut = &H82
                            Case &H6F3  'فارسي 3 
                                ascChrOut = &H83
                            Case &H663 'فارسي 3 
                                ascChrOut = &H83
                            Case &H6F4  'فارسي 4 
                                ascChrOut = &H84
                            Case &H664 'فارسي 4 
                                ascChrOut = &H84
                            Case &H6F5  'فارسي 5 
                                ascChrOut = &H85
                            Case &H665 'فارسي 5 
                                ascChrOut = &H85
                            Case &H6F6  'فارسي 6 
                                ascChrOut = &H86
                            Case &H666 'فارسي 6 
                                ascChrOut = &H86
                            Case &H6F7  'فارسي 7 
                                ascChrOut = &H87
                            Case &H667 'فارسي 7 
                                ascChrOut = &H87
                            Case &H6F8  'فارسي 8 
                                ascChrOut = &H88
                            Case &H668 'فارسي 8 
                                ascChrOut = &H88
                            Case &H6F9  'فارسي 9 
                                ascChrOut = &H89
                            Case &H669 'فارسي 9 
                                ascChrOut = &H89

                                '===علايم فارسي
                            Case &H640 '-  
                                ascChrOut = &H8B
                            Case &H60C ',فارسي  
                                ascChrOut = &H8A
                            Case &H61F '؟فارسي  
                                ascChrOut = &H8C
                            Case &H66A '%فارسي  
                                ascChrOut = &H25
                                '===حروف 1 حالته
                            Case &H62F 'د
                                ascChrOut = &HA2
                            Case &H630 'ذ
                                ascChrOut = &HA3
                            Case &H631 'ر
                                ascChrOut = &HA4
                            Case &H632 'ز
                                ascChrOut = &HA5
                            Case &H698 'ژ
                                ascChrOut = &HA6
                            Case &H648  'و
                                ascChrOut = &HF8
                            Case &H624 'و
                                ascChrOut = &HF8
                            Case &H637 'ط
                                ascChrOut = &HAF
                            Case &H638 'ظ
                                ascChrOut = &HE0
                            Case &H622 'آ
                                ascChrOut = &H8D
                            Case &H674 'ء
                                ascChrOut = &H8F
                            Case &H621  'ء
                                ascChrOut = &H8F
                                '===حروف 2 حالته
                            Case &H628 'ب
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &H92 'ب
                                Else
                                    ascChrOut = &H93 'ب كوچك
                                End If
                            Case &H67E 'پ
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &H94 'پ
                                Else
                                    ascChrOut = &H95 'پ كوچك
                                End If
                            Case &H62A 'ت
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &H96 'ت
                                Else
                                    ascChrOut = &H97 'ت كوچك
                                End If
                            Case &H62B 'ث
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &H98 'ث
                                Else
                                    ascChrOut = &H99 'ث كوچك
                                End If
                            Case &H62C 'ج
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &H9A 'ج
                                Else
                                    ascChrOut = &H9B 'ج كوچك
                                End If
                            Case &H686 'چ
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &H9C 'چ
                                Else
                                    ascChrOut = &H9D 'چ كوچك
                                End If
                            Case &H62D 'ح
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &H9E 'ح
                                Else
                                    ascChrOut = &H9F 'ح كوچك
                                End If
                            Case &H62E 'خ
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HA0 'خ
                                Else
                                    ascChrOut = &HA1 'خ كوچك
                                End If
                            Case &H633 'س
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HA7 'س
                                Else
                                    ascChrOut = &HA8 'س كوچك
                                End If
                            Case &H634 'ش
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HA9 'ش
                                Else
                                    ascChrOut = &HAA 'ش كوچك
                                End If
                            Case &H635 'ص
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HAB 'ص
                                Else
                                    ascChrOut = &HAC 'ص كوچك
                                End If
                            Case &H636 'ض
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HAD 'ض
                                Else
                                    ascChrOut = &HAE 'ض كوچك
                                End If
                            Case &H641 'ف
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HE9 'ف
                                Else
                                    ascChrOut = &HEA 'ف كوچك
                                End If
                            Case &H642 'ق
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HEB 'ق
                                Else
                                    ascChrOut = &HEC 'ق كوچك
                                End If
                            Case &H643  'ك
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HED 'ك
                                Else
                                    ascChrOut = &HEE 'ك كوچك
                                End If
                            Case &H6A9  'ك
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HED 'ك
                                Else
                                    ascChrOut = &HEE 'ك كوچك
                                End If
                            Case &H6AA 'ك
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HED 'ك
                                Else
                                    ascChrOut = &HEE 'ك كوچك
                                End If

                            Case &H6AF 'گ
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HEF 'گ
                                Else
                                    ascChrOut = &HF0 'گ كوچك
                                End If
                            Case &H644 'ل
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HF1 'ل
                                Else
                                    ascChrOut = &HF3 'ل كوچك
                                End If
                            Case &H645 'م
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HF4 'م
                                Else
                                    ascChrOut = &HF5 'م كوچك
                                End If
                            Case &H646 'ن
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HF6 'ن
                                Else
                                    ascChrOut = &HF7 'ن كوچك
                                End If
                            Case &H649  'ي
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HFC 'ي
                                Else
                                    ascChrOut = &HFE 'ي كوچك
                                End If
                            Case &H64A  'ي
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HFC 'ي
                                Else
                                    ascChrOut = &HFE 'ي كوچك
                                End If
                            Case &H6CC  'ي
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HFC 'ي
                                Else
                                    ascChrOut = &HFE 'ي كوچك
                                End If
                            Case &H6D2 'ي
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HFC 'ي
                                Else
                                    ascChrOut = &HFE 'ي كوچك
                                End If
                            Case &H626  'ئ
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HFD 'ئ
                                Else
                                    ascChrOut = &H8E  'ئ كوچك
                                End If
                            Case &H6D3 'ئ
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HFD 'ئ
                                Else
                                    ascChrOut = &H8E 'ئ كوچك
                                End If
                                'Case &H627 Or &H623 Or &H625 Or &H671 Or &H672 Or &H673 Or &H675 'ا
                                '====================================================================
                            Case &H627  'ا
                                If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                    ascChrOut = &H90 'ا
                                Else
                                    ascChrOut = &H91 'ا چسبيده
                                End If
                                'If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                '    If ascChrIn_post = &H631 Then
                                '        ascChrOut = &H90 'ا
                                '    Else
                                '        ascChrOut = &H90 'ا
                                '    End If
                                'Else
                                '    ascChrOut = &H91 'ا چسبيده
                                'End If
                            Case &H623  'ا
                                If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                    ascChrOut = &H90 'ا
                                Else
                                    ascChrOut = &H91 'ا چسبيده
                                End If
                            Case &H625 'ا
                                If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                    ascChrOut = &H90 'ا
                                Else
                                    ascChrOut = &H91 'ا چسبيده
                                End If
                            Case &H671  'ا
                                If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                    ascChrOut = &H90 'ا
                                Else
                                    ascChrOut = &H91 'ا چسبيده
                                End If
                            Case &H672 'ا
                                If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                    ascChrOut = &H90 'ا
                                Else
                                    ascChrOut = &H91 'ا چسبيده
                                End If
                            Case &H673  'ا
                                If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                    ascChrOut = &H90 'ا
                                Else
                                    ascChrOut = &H91 'ا چسبيده
                                End If
                            Case &H675 'ا
                                If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                    ascChrOut = &H90 'ا
                                Else
                                    ascChrOut = &H91 'ا چسبيده
                                End If
                                '==================================================================
                                '===حروف بيش از 2 حالته
                            Case &H639 'ع
                                If ascChrIn_post = &H20 Then 'space
                                    If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                        ascChrOut = &HE1 'ع آخر تنها
                                    Else
                                        ascChrOut = &HE2 'ع آخر چسبان
                                    End If
                                Else
                                    If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                        ascChrOut = &HE4 'ع اول
                                    Else
                                        ascChrOut = &HE3 'ع وسط
                                    End If
                                End If
                            Case &H63A 'غ
                                If ascChrIn_post = &H20 Then 'space
                                    If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                        ascChrOut = &HE5 'غ آخر تنها
                                    Else
                                        ascChrOut = &HE6 'غ آخر چسبان
                                    End If
                                Else
                                    If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                        ascChrOut = &HE8 'غ اول
                                    Else
                                        ascChrOut = &HE7 'غ وسط
                                    End If
                                End If
                            Case &H647  'ه
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HF9 'ه آخر
                                Else
                                    If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                        ascChrOut = &HFB 'ه اول
                                    Else
                                        ascChrOut = &HFA 'ه وسط
                                    End If
                                End If
                            Case &H6BE 'ه
                                If ascChrIn_post = &H20 Then 'space
                                    ascChrOut = &HF9 'ه آخر
                                Else
                                    If ascChrIn_pre = &H20 Or ascChrIn_pre = &H62F Or ascChrIn_pre = &H630 Or ascChrIn_pre = &H631 Or ascChrIn_pre = &H632 Or ascChrIn_pre = &H698 Or ascChrIn_pre = &H648 Or ascChrIn_pre = &H624 Or ascChrIn_pre = &H622 Or ascChrIn_pre = &H621 Or ascChrIn_pre = &H674 Or ascChrIn_pre = &H627 Or ascChrIn_pre = &H623 Or ascChrIn_pre = &H625 Or ascChrIn_pre = &H671 Or ascChrIn_pre = &H672 Or ascChrIn_pre = &H673 Or ascChrIn_pre = &H675 Then 'space د ذ ر ز ژ و آ ا ء
                                        ascChrOut = &HFB 'ه اول
                                    Else
                                        ascChrOut = &HFA 'ه وسط
                                    End If
                                End If

                                '===ناشناس
                            Case Else
                                ascChrOut = &H3F '===?
                        End Select
                End Select
                ConvertUnicodeToIranSystem = ascChrOut
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        Public Overloads Shared Function GetIranSystem(ByVal strInLine As String) As String
            Try
                ' Return System.Text.UTF8Encoding.UTF8.GetBytes(strInLine.ToString)
                Return SAFA2.CWin2Dos.Win2Dos(strInLine)



                'Dim chrInLine As String = ""
                'Dim chrInLine_pre As String = ""
                'Dim chrInLine_post As String = ""
                'Dim byteOutLine As Byte
                'Dim arrbyteOutLine() As Byte
                'Dim arrlength As Int32
                'Dim k As Int32

                'Dim ascChrIn As Int32
                'Dim colchrOutLine127 As New Collection
                'Dim chrInLineLtoR As String = ""
                'Dim chrInLine_preLtoR As String = ""
                'Dim chrInLine_postLtoR As String = ""

                'If strInLine.Length = 0 Then
                '    Dim o As Int32 = 0
                '    'Dim ascChrOut As Byte
                '    'ascChrOut = AscW(strInLine)
                '    'ReDim arrbyteOutLine(0)
                '    'arrbyteOutLine(0) = ascChrOut
                '    'Return arrbyteOutLine
                'End If
                'arrlength = strInLine.Length
                'arrlength = arrlength - 1

                'ReDim arrbyteOutLine(arrlength)
                'k = arrlength 'k = arrlength - 1
                'For j As Int64 = 0 To arrlength
                '    If j = 0 Then
                '        chrInLine_pre = Space(1)
                '    Else
                '        chrInLine_pre = strInLine.Substring(j - 1, 1)
                '    End If
                '    If j = arrlength Then
                '        chrInLine_post = Space(1)
                '    Else
                '        chrInLine_post = strInLine.Substring(j + 1, 1)
                '    End If
                '    chrInLine = strInLine.Substring(j, 1)

                '    ascChrIn = AscW(chrInLine)
                '    '===قسمت LtoR========begin=====================================================
                '    '===جمع كردن اعداد و حروف انگليسي در يك كالكشن
                '    If (ascChrIn = 13) OrElse (ascChrIn = 10) OrElse (ascChrIn = 32) OrElse (ascChrIn >= 65 AndAlso ascChrIn <= 90) OrElse (ascChrIn >= 97 AndAlso ascChrIn <= 122) OrElse (ascChrIn >= 48 AndAlso ascChrIn <= 57) Then
                '        colchrOutLine127.Add(chrInLine)
                '        Continue For
                '    End If
                '    '===وارد كردن كالكشن به آرايه با ترتيب درست======
                '    For c As Int32 = colchrOutLine127.Count To 1 Step -1
                '        chrInLine_preLtoR = Space(1)
                '        chrInLine_postLtoR = Space(1)
                '        chrInLineLtoR = colchrOutLine127.Item(c)
                '        byteOutLine = ConvertUnicodeToIranSystem(chrInLineLtoR, chrInLine_preLtoR, chrInLine_postLtoR)

                '        arrbyteOutLine(k) = byteOutLine
                '        k -= 1
                '    Next
                '    If colchrOutLine127.Count > 0 Then
                '        colchrOutLine127.Clear()
                '    End If
                '    '===قسمت LtoR========end=====================================================
                '    byteOutLine = ConvertUnicodeToIranSystem(chrInLine, chrInLine_pre, chrInLine_post)

                '    arrbyteOutLine(k) = byteOutLine
                '    k -= 1
                'Next
                ''==================================================
                'For c As Int32 = colchrOutLine127.Count To 1 Step -1
                '    chrInLine_preLtoR = Space(1)
                '    chrInLine_postLtoR = Space(1)
                '    chrInLineLtoR = colchrOutLine127.Item(c)
                '    byteOutLine = ConvertUnicodeToIranSystem(chrInLineLtoR, chrInLine_preLtoR, chrInLine_postLtoR)

                '    arrbyteOutLine(k) = byteOutLine
                '    k -= 1
                'Next
                'If colchrOutLine127.Count > 0 Then
                '    colchrOutLine127.Clear()
                'End If
                '  Return arrbyteOutLine.ToString
                ' '===================================================
                ''BW.Write(arrbyteOutLine)
                ''BW.Flush()

            Catch ex As Exception
                Throw ex
            End Try

        End Function

#End Region




#End Region
    End Class
End Namespace
