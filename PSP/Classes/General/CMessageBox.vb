Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Text

Public Delegate Function CallBack_WinProc(ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
Public Delegate Function CallBack_EnumWinProc(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer


Public Class CMessageBox
    <DllImport("user32.dll")> _
    Public Shared Function GetWindowLong(ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    End Function
    <DllImport("kernel32.dll")> _
    Public Shared Function GetCurrentThreadId() As Integer
    End Function
    <DllImport("user32.dll")> _
    Public Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal lpfn As CallBack_WinProc, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Integer
    End Function
    <DllImport("user32.dll")> _
    Public Shared Function UnhookWindowsHookEx(ByVal hHook As Integer) As Integer
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function SetWindowText(ByVal hwnd As Integer, ByVal lpString As String) As Integer
    End Function
    <DllImport("user32.dll")> _
    Public Shared Function EnumChildWindows(ByVal hWndParent As Integer, ByVal lpEnumFunc As CallBack_EnumWinProc, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")> _
    Public Shared Function GetClassName(ByVal hwnd As Integer, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function
    Dim TopCount As Integer
    Dim ButtonCount As Integer

    Private Const GWL_HINSTANCE As Integer = (-6)
    Private Const HCBT_ACTIVATE As Integer = 5
    Private Const WH_CBT As Integer = 5

    Private hHook As Integer

    Dim strCaption1 As String
    Dim strCaption2 As String
    Dim strCaption3 As String

    Public Function ShowMessage(ByVal hParent As Integer, ByVal Prompt As String, ByVal Title As String, ByVal Caption1 As String, ByVal Caption2 As String, ByVal Caption3 As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal DefaultButton As MessageBoxDefaultButton, ByVal options As MessageBoxOptions) As DialogResult

        Dim hInst As Integer
        Dim Thread As Integer
        TopCount = 0
        ButtonCount = 0

        strCaption1 = Caption1
        strCaption2 = Caption2
        strCaption3 = Caption3

        If Title = "" Then Title = Application.ProductName

        Dim myWndProc As CallBack_WinProc = New CallBack_WinProc(AddressOf WinProc)

        hInst = GetWindowLong(hParent, GWL_HINSTANCE)
        Thread = GetCurrentThreadId()
        hHook = SetWindowsHookEx(WH_CBT, myWndProc, hInst, Thread)

        Return MessageBox.Show(Prompt, Title, buttons, icon, DefaultButton, options)
    End Function

    Private Function WinProc(ByVal uMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        Dim myEnumProc As CallBack_EnumWinProc = New CallBack_EnumWinProc(AddressOf EnumWinProc)
        If uMsg = HCBT_ACTIVATE Then
            EnumChildWindows(wParam, myEnumProc, 0)
            UnhookWindowsHookEx(hHook)
        End If
        Return 0
    End Function

    Private Function EnumWinProc(ByVal hWnd As Integer, ByVal lParam As Integer) As Integer
        Dim strBuffer As StringBuilder = New StringBuilder(256)
        TopCount += 1
        GetClassName(hWnd, strBuffer, strBuffer.Capacity)
        Dim ss As String = strBuffer.ToString()
        If (ss.ToUpper().StartsWith("BUTTON")) Then
            ButtonCount += 1
            Select Case ButtonCount
                Case 1
                    SetWindowText(hWnd, strCaption1)
                    Exit Select
                Case 2
                    SetWindowText(hWnd, strCaption2)
                    Exit Select
                Case 3
                    SetWindowText(hWnd, strCaption3)
                    Exit Select
            End Select
        End If
        Return 1
    End Function
End Class

