Imports System.Globalization
Imports System.IO
Imports EniacTech.PSP.Helper.Lib


Module modPublicMethod
    Private mvarPersianCalendar As New PersianCalendar
    Private msg As New CMessageBox
    Public SystemName As String = "PSP"
    Public AccessDeviceCancelFilePath As String = Application.StartupPath + "\Access\Change.mdb"
    Public AccessSwitchFilePath As String = Application.StartupPath + "\Access\TFinal.mdb"
    Public AccessAccountingFilePath As String = Application.StartupPath + "\Access\Accounting.mdb"
    Public AccessSwitchBackupsFolderPath As String = Application.StartupPath + "\AccessBackups\TFinalBackups"
    Public AccessAccountingBackupsFolderPath As String = Application.StartupPath + "\AccessBackups\AccountingBackups"
    Public AccessChangeFilePath As String = Application.StartupPath + "\Access\Change.mdb"

    Private mvarAppName As String

    Public TextLogErrorFilePath As String = "C:\PSPShaparak_LogError\"
    Public TextBckupsLogErrorFilePath As String = "C:\PSPShaparak_LogError\Bckups\"

    Public ExcelFilePath As String = Application.StartupPath + "\Excel\RptGeneral.xls"

    ' Public PDFFilePath As String = "C:\TejaratPDFs"
    Public PDFFilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString + "\Gozaresh\" + "\ShaparakPDFs"


    Public _VJDateNet As New VJDateNet.DateClass

#Region "Message"
    Public Sub ShowMessage(ByVal Message As String)
        msg.ShowMessage(0, Message, modPublicMethod.SystemName, "تائید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
    End Sub
    Public Sub ShowErrorMessage(ByVal Message As String)
        msg.ShowMessage(0, Message, modPublicMethod.SystemName, "تائید", "", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
    End Sub
    Public Function ShowConfirmDeleteMessage() As Boolean
        If msg.ShowMessage(0, modApplicationMessage.msgConfirmDelete, "حذف", "خیر", "بلی", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = DialogResult.No Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ShowConfirmDeleteMessage(ByVal strMSG As String) As Boolean
        If msg.ShowMessage(0, strMSG, "حذف", "خیر", "بلی", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = DialogResult.No Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ShowConfirmMessage(ByVal strMSG As String) As Boolean
        If msg.ShowMessage(0, strMSG, "عملیات", "خیر", "بلی", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = DialogResult.No Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region
#Region "Security"
    Public Function Decode(ByVal strMessage As String) As String
        Try
            Dim txtByte() As Byte = System.Convert.FromBase64String(strMessage)
            Return System.Text.Encoding.UTF8.GetString(txtByte)
        Catch
            Return ""
        End Try
    End Function
    Public Function EnCode(ByVal strMessage As String) As String
        Try
            Dim txtByte() As Byte = System.Text.Encoding.UTF8.GetBytes(strMessage)
            Return System.Convert.ToBase64String(txtByte)
        Catch
            Return ""
        End Try
    End Function
#End Region
#Region "ConnectionString"
    Public ReadOnly Property ConnectionString() As String
        Get


            Return StringSecurityHelper.Decrypt(Global.My.MySettings.Default.strConnectionString)

            ' Return "Persist Security Info=False;User ID=pspshaparak;Password=pspshaparak;Data Source=192.168.40.55/dbpsp" 'My.Settings.HardCodedConnectionString
            ' Return "Persist Security Info=False;User ID=pspshaparak;Password=pspshaparak;Data Source=192.168.50.40/devpsp" 'My.Settings.HardCodedConnectionString
            '"Persist Security Info=False;Data Source=192.168.50.40/devpsp;User ID=pspshaparak_tst;Password=pspshaparak_tst;
        End Get

    End Property

    Public ReadOnly Property SinaConnectionString() As String
        Get
            Return String.Empty
        End Get
    End Property

    Public ReadOnly Property TMSConnectionString() As String
        Get
            Return StringSecurityHelper.Decrypt(Global.My.MySettings.Default.TMSConnectionString)
            'Return "Driver={MySQL ODBC 5.1 Driver};Server=192.168.40.152;Database=ingestate;User=root; Password=root;Option=3;"
        End Get
    End Property
#End Region


    Public Property AppName() As String
        Get
            Return mvarAppName
        End Get
        Set(ByVal value As String)
            mvarAppName = value
        End Set
    End Property

#Region "TheLatestUserLogin"
    Public Property TheLatestUserLogin() As String
        Get
            Return My.Settings.strTheLatestUserLogin
        End Get
        Set(ByVal value As String)
            My.Settings.strTheLatestUserLogin = value
        End Set
    End Property
#End Region
#Region "CheckAccountNo"
    Public Function CheckAccountNo(ByVal AccountNo As String) As Boolean
        Try
            Dim sum As Int64
            Dim Remain As Int64
            sum = Convert.ToInt16(AccountNo.Substring(0, 1)) * 4 + Convert.ToInt16(AccountNo.Substring(1, 1)) * 3 + Convert.ToInt16(AccountNo.Substring(2, 1)) * 2 + Convert.ToInt16(AccountNo.Substring(3, 1)) * 7 + Convert.ToInt16(AccountNo.Substring(4, 1)) * 6 + Convert.ToInt16(AccountNo.Substring(5, 1)) * 5 + Convert.ToInt16(AccountNo.Substring(6, 1)) * 4 + Convert.ToInt16(AccountNo.Substring(7, 1)) * 3 + Convert.ToInt16(AccountNo.Substring(8, 1)) * 2
            Remain = sum Mod 11
            'If (Remain = 0 AndAlso Convert.ToInt16(AccountNo.Substring(9, 1)) <> 0) Then
            '    CheckAccountNo = False
            'Else
            '    If ((11 - Remain) <> AccountNo.Substring(9, 1)) Then
            '        CheckAccountNo = False
            '    Else
            '        CheckAccountNo = True
            '    End If
            'End If
            If Remain = 0 Then
                If Convert.ToInt16(AccountNo.Substring(9, 1)) = 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                If Convert.ToInt16(AccountNo.Substring(9, 1)) = 11 - Remain Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            CheckAccountNo = False
            Throw ex
        End Try
    End Function
#End Region

#Region "DateTime"

    Public Function GetDateNow() As String
        Dim PersianDate As String = String.Empty
        Dim _clsDate As New ClassDalDate(ConnectionString)
        PersianDate = _clsDate.GetPersianDateNow()
        Return PersianDate
        'Dim strYear As String
        'Dim strMonth As String
        'Dim strDay As String
        'strYear = mvarPersianCalendar.GetYear(Date.Now)
        'If Len(mvarPersianCalendar.GetMonth(Date.Now).ToString) < 2 Then
        '    strMonth = "0" & mvarPersianCalendar.GetMonth(Date.Now)
        'Else
        '    strMonth = mvarPersianCalendar.GetMonth(Date.Now)
        'End If
        'If Len(mvarPersianCalendar.GetDayOfMonth(Date.Now).ToString) < 2 Then
        '    strDay = "0" & mvarPersianCalendar.GetDayOfMonth(Date.Now)
        'Else
        '    strDay = mvarPersianCalendar.GetDayOfMonth(Date.Now)
        'End If

        'GetDateNow = (strYear & "/" & strMonth & "/" & strDay)
    End Function
    Public Function GetTimeNow() As String
        Dim strHour As String
        Dim strMinute As String
        If Len(Date.Now.Hour.ToString()) < 2 Then
            strHour = "0" & Date.Now.Hour.ToString()
        Else
            strHour = Date.Now.Hour.ToString()
        End If
        If Len(Date.Now.Minute.ToString()) < 2 Then
            strMinute = "0" & Date.Now.Minute.ToString()
        Else
            strMinute = Date.Now.Minute.ToString()
        End If
        GetTimeNow = (strHour & ":" & strMinute)
    End Function
    Friend Function GetPersianWeekDay(ByVal ForeignDate As Date) As String
        GetPersianWeekDay = ""
        Select Case Weekday(ForeignDate)
            Case 7 : GetPersianWeekDay = "شنبه"
            Case 1 : GetPersianWeekDay = "یک شنبه"
            Case 2 : GetPersianWeekDay = "دو شنبه"
            Case 3 : GetPersianWeekDay = "سه شنبه"
            Case 4 : GetPersianWeekDay = "چهار شنبه"
            Case 5 : GetPersianWeekDay = "پنج شنبه"
            Case 6 : GetPersianWeekDay = "جمعه"
        End Select
    End Function
    Public Function GenerateDatetoString(ByVal StrDate As String) As String
        Dim strRes As String
        strRes = StrDate.Replace("/", "")
        Return strRes
    End Function
    Public Function GenerateStringtoDate(ByVal StrString As String) As String
        Dim strRes As String
        strRes = "13" + StrString.Substring(0, 2) + "/" + StrString.Substring(2, 2) + "/" + StrString.Substring(4, 2)
        Return strRes

    End Function
#End Region
#Region "Conversion"
    Public Function StringToByteArray(ByVal str As String) As Byte()
        Dim encoding As New System.Text.ASCIIEncoding
        Return encoding.GetBytes(str)
    End Function
    Public Function ByteArrayToString(ByVal byt() As Byte) As String
        Dim encoding As New System.Text.ASCIIEncoding
        Return encoding.GetString(byt)
    End Function
#End Region
#Region "Others"
    Public Function Code_Melli(ByVal Nnc As String) As Integer
        Dim Nres As Long
        Dim Nsum As Integer
        Dim Nrem As Integer
        '===Added
        Dim theFirstChar As String
        Dim cnt As Int16 = 0

        theFirstChar = Nnc.Substring(0, 1)
        For i As Int32 = 1 To 9
            If theFirstChar = Nnc.Substring(i, 1) Then
                cnt += 1
            End If
        Next
        If cnt = 9 Then
            Return 0
        End If
        '===
        Nres = 0
        If CDbl(Nnc) < CDbl("0010000010") Then
            Code_Melli = 0
        End If
        Nsum = 0
        For i As Int32 = 1 To 9
            Nsum = Nsum + (CInt(Mid(Nnc, i, 1))) * (11 - i)
        Next
        Nrem = Nsum Mod 11
        Nsum = Nsum / 11
        If Nrem > 1 Then
            Nrem = 11 - Nrem
        End If
        If Nrem = Mid(Nnc, 10, 1) Then
            Nres = 1
        Else
            Nres = 0
        End If
        Code_Melli = Nres
    End Function

    Public Sub SelectAText(ByVal TextBox As TextBox)
        TextBox.Focus()
        TextBox.SelectAll()
    End Sub
    Public Sub SelectAToolStripText(ByVal TextBox As ToolStripTextBox)
        TextBox.Focus()
        TextBox.SelectAll()
    End Sub

    Public Sub ErrorProviderClear(ByVal ErrorProvider As ErrorProvider)
        ErrorProvider.Clear()
        ErrorProvider.RightToLeft = True
    End Sub
    Public Function GetAPartOfString(ByVal Str As String, ByVal start As Int32, ByVal Length As Int32) As String
        Try
            GetAPartOfString = Str.Substring(start, Length)
        Catch
            GetAPartOfString = ""
        End Try
    End Function
    Public Function CorrectLike(ByVal str As String) As String
        Dim res As String = ""
        For Each c As Char In str
            If c = "]" OrElse c = "[" Then
                res += "[" + c + "]"
            Else
                res += c
            End If
        Next
        Return res.Replace("'", "''")
    End Function
    'Public Sub SaveInReg(ByVal Key As String, ByVal Val As String)
    '    Try
    '        My.Computer.Registry.LocalMachine.SetValue(Key, Val)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Public Function GetFromReg(ByVal Key As String) As String
    '    Try
    '        GetFromReg = My.Computer.Registry.LocalMachine.GetValue(Key)
    '    Catch ex As Exception
    '        GetFromReg = ""
    '        Throw ex
    '    End Try
    'End Function
    Public Function DateAddDay(ByVal _Date As String, ByVal day As Short) As String
        Try
            DateAddDay = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), day))
        Catch ex As Exception

        End Try
    End Function
    Public Function DateAddAMonth(ByVal _Date As String) As String
        Try
            Dim _Date_Month As String
            _Date_Month = _Date.Substring(5, 2)
            Select Case _Date_Month
                Case "01"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 30))

                Case "02"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 30))

                Case "03"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 30))

                Case "04"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 30))

                Case "05"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 30))

                Case "06"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 30))

                Case "07"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 29))
                Case "08"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 29))

                Case "09"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 29))

                Case "10"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 29))
                Case "11"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 29))

                Case "12"
                    DateAddAMonth = GenerateStringtoDate(_VJDateNet.JAddDay(GenerateDatetoString(_Date), 28))

            End Select
        Catch ex As Exception
            DateAddAMonth = ""
        End Try
    End Function
    Public Sub CreateDirectory(ByVal DirectoryPath As String)
        Try
            Directory.CreateDirectory(DirectoryPath)
        Catch ex As Exception

        End Try
    End Sub
#End Region
    'Public Function SpecialUser() As Boolean
    '    Dim UserID As Int64 = ClassUserLoginDataAccess.ThisUser.UserID
    '    If UserID = 4 Or UserID = 69 Then 'khodabandelou hosseini
    '        SpecialUser = True
    '    Else
    '        SpecialUser = False
    '    End If
    'End Function
    Public Function CheckTime(ByVal strTime As String) As Boolean
        Try
            If strTime.Trim.Length <> 5 Then
                Return False
            Else
                If strTime.Trim.Substring(0, 2) > 23 OrElse strTime.Trim.Substring(3, 2) > 59 Then
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function CheckMin(ByVal Min As String) As Boolean
        Try
            If Min.Trim.Length <> 2 Then
                Return False
            Else
                If Min > 59 Then
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function GetPosModel(ByVal PosModelID As Int16) As String
        Try

            If PosModelID = 1 Then
                Return "Castles"
            ElseIf PosModelID = 2 Then
                Return "Ing"
            Else
                Return "unknown"
            End If
        Catch ex As Exception
            GetPosModel = "unknown"
        End Try
    End Function
    Public Function GetHourByMin(ByVal min As Int64) As String
        Try
            Dim res As String
            Dim resHour As Int32
            Dim resMin As Int32
            Dim resHourLength As Int32

            resHour = min \ 60
            resMin = min Mod 60

            resHourLength = resHour.ToString.Length

            If resHourLength < 2 Then
                res = Right("0" + resHour.ToString, 2) + ":" + Right("0" + resMin.ToString, 2)
            Else
                res = resHour.ToString + ":" + Right("0" + resMin.ToString, 2)
            End If

            Return res
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
End Module
