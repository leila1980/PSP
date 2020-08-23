Imports System.Net
Public Class ClassConnectionSpliter
    Private _DbSource, _DbName, _User, _Pass, sCnnStr As String
    Public Sub New()
    
    End Sub
    Public Sub New(ByVal _ConnectionString As String)
        sCnnStr = _ConnectionString
        SplitCnnStr()
    End Sub
    Public ReadOnly Property DbName() As String
        Get
            Return _DbName
        End Get
    End Property
    Public ReadOnly Property DbSource()
        Get
            Return _DbSource
        End Get
    End Property
    Public ReadOnly Property DbUserName()
        Get
            Return _User
        End Get
    End Property
    Public ReadOnly Property DbPass()
        Get
            Return _Pass
        End Get
    End Property
    Public Sub SplitCnnStr()
        Dim i, x, iCnt As Int16
        Dim iFirstEqual As Int16
        Dim sArray() As String
        Dim sTemp As String
        sArray = Split(sCnnStr.Trim, ";")
        x = 0
        For i = 1 To sArray.Length
            iCnt = sArray(x).Length
            iFirstEqual = InStr(sArray(x), "=")
            sTemp = Mid(sArray(x).ToString, iFirstEqual + 1, iCnt - iFirstEqual)

            Select Case Left(sArray(x).ToString, 4)
                Case "Data"
                    _DbSource = sTemp
                Case "Init"
                    _DbName = sTemp
                Case "Pass"
                    _Pass = sTemp
                Case "User"
                    _User = sTemp
            End Select
            x = x + 1
        Next
        If _Pass = Nothing Then
            _Pass = ""
        End If
    End Sub



    'Public Function ConnectionAvailable(ByVal murl As String) As Boolean

    '    Dim reqFp As HttpWebRequest
    '    Dim resFp As HttpWebResponse


    '    Try
    '        reqFp = HttpWebRequest.Create(murl)
    '        resFp = reqFp.GetResponse()
    '    Catch ex As Exception
    '        Return False
    '    End Try

    '    Dim s = resFp.ResponseUri.ToString

    '    If HttpStatusCode.OK = resFp.StatusCode Then
    '        Return True
    '    Else
    '        Return False
    '    End If

    'End Function


End Class


