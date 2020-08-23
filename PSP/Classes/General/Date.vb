'Mehdi Nanshekari
'Nanshekari@Gmail.com
'Date And Time Tools

Public Class DateTool

    Public Shared Function SpellDate(ByVal idate As Date) As String
        Dim strRes As String = ""
        Dim PersianMonthNames() As String = {"", "فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"}
        Dim clsPC As New System.Globalization.PersianCalendar
        Dim clsDW As DayOfWeek = clsPC.GetDayOfWeek(idate)
        Select Case (clsDW)
            Case DayOfWeek.Saturday
                strRes += "شنبه"
            Case DayOfWeek.Sunday
                strRes += "یکشنبه"
            Case DayOfWeek.Monday
                strRes += "دوشنبه"
            Case DayOfWeek.Tuesday
                strRes += "سه شنبه"
            Case DayOfWeek.Wednesday
                strRes += "چهارشنبه"
            Case DayOfWeek.Thursday
                strRes += "پنج شنبه"
            Case DayOfWeek.Friday
                strRes += "جمعه"
        End Select
        strRes += " " + clsPC.GetDayOfMonth(idate).ToString + " " + PersianMonthNames(clsPC.GetMonth(idate)) + " " + clsPC.GetYear(idate).ToString
        Return strRes
    End Function

    Public Shared Function ConvertDate(ByVal idate As String) As Date
        Dim prdate() As String = Split(idate, "/")
        Dim Mdate As New System.Globalization.PersianCalendar
        Return Mdate.ToDateTime(Int(prdate(0)), Int(prdate(1)), Int(prdate(2)), 1, 1, 1, 1, System.Globalization.GregorianCalendar.ADEra)
    End Function

    Public Shared Function ConvertDate(ByVal idate As Date) As String
        Dim pc As New System.Globalization.PersianCalendar

        Dim year As String = pc.GetYear(idate).ToString
        Dim month As String = pc.GetMonth(idate).ToString
        Dim day As String = pc.GetDayOfMonth(idate).ToString

        If year.Length < 2 Then
            year = "0" + year
        End If

        If month.Length < 2 Then
            month = "0" + month
        End If

        If day.Length < 2 Then
            day = "0" + day
        End If

        Return year + "/" + month + "/" + day
    End Function

    Public Shared Function SecondToTime(ByVal Time As Long) As String
        Dim Hour As Int16
        Dim Min As Int16
        Dim Sec As Int16

        Min = Time \ 60
        Sec = Time Mod 60
        Hour = Min \ 60
        Min = Min Mod 60

        Dim strMin As String = Min
        Dim strSec As String = Sec
        Dim strHour As String = Hour

        If strMin.Length < 2 Then
            strMin = "0" + strMin
        End If
        If strSec.Length < 2 Then
            strSec = "0" + strSec
        End If
        If strHour.Length < 2 Then
            strHour = "0" + strHour
        End If
        Return strHour + ":" + strMin + ":" + strSec
    End Function

End Class
