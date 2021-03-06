Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop.Excel

Public Class ClassExcel

    Public Enum enmUpdateLink As Byte
        UserSpecifies = 1
        Never = 2
        Always = 3
    End Enum

    Public Enum enmDelimiterFormat As Byte
        Tab = 1
        Comma = 2
        Space = 3
        Semicolon = 4
        NotSpecifies = 5
        Custom = 6
    End Enum

    Public Enum enmOrigin As Byte
        Macintosh = 1
        Windows = 2
        MSDOS = 3
    End Enum

#Region "Member variable"

    Private _filePath As String = String.Empty
    Private _password As String = String.Empty
    Private _writeReservedPassword As String = String.Empty
    Private _updateLink As enmUpdateLink = enmUpdateLink.Never
    Private _delimiterFormat As enmDelimiterFormat = enmDelimiterFormat.NotSpecifies
    Private _ignoreReadOnlyRecommended As Boolean = True
    Private _origin As enmOrigin = enmOrigin.Windows
    Private _delimiterString As String = String.Empty

#End Region

#Region "Property"

    Public WriteOnly Property UpdateLink() As enmUpdateLink
        Set(ByVal value As enmUpdateLink)
            Me._updateLink = value
        End Set
    End Property

    Public WriteOnly Property Password() As String
        Set(ByVal value As String)
            Me._password = value
        End Set
    End Property

    Public WriteOnly Property WriteReservedPassword() As String
        Set(ByVal value As String)
            Me._writeReservedPassword = value
        End Set
    End Property

    Public WriteOnly Property DelimiterFormat() As enmDelimiterFormat
        Set(ByVal value As enmDelimiterFormat)
            Me._delimiterFormat = value
        End Set
    End Property

    Public WriteOnly Property IgnoreReadOnlyRecommended() As Boolean
        Set(ByVal value As Boolean)
            Me._ignoreReadOnlyRecommended = value
        End Set
    End Property

    Public WriteOnly Property DelimiterString() As String
        Set(ByVal value As String)
            Me._delimiterString = value
        End Set
    End Property

#End Region

#Region "Constractor"

    Public Sub New(ByVal filePath As String)
        Me._filePath = filePath
    End Sub

#End Region

    Public Function Read(ByVal SheetIndex As UInt16, ByVal FirstRowIsHeader As Boolean) As System.Data.DataTable
        If SheetIndex < 1 Then
            SheetIndex = 1
        End If

        Dim Result As New System.Data.DataTable

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Try

            Dim ExcelApplication As New Microsoft.Office.Interop.Excel.Application
            Dim ExcelWorkBook As Microsoft.Office.Interop.Excel.Workbook
            ExcelWorkBook = ExcelApplication.Workbooks.Open(_filePath, _updateLink, True, _delimiterFormat, Me._password, Me._writeReservedPassword, Me._ignoreReadOnlyRecommended, _origin, Me._delimiterString, False, False, 0, True, 1, 0)
            Dim ExcelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = ExcelWorkBook.Sheets(SheetIndex)

            For i As Integer = 1 To ExcelWorkSheet.UsedRange.Columns.Count
                Dim DataColumn As New DataColumn("Field" + i.ToString)
                Result.Columns.Add(DataColumn)
            Next

            For i As Integer = 1 To ExcelWorkSheet.UsedRange.Rows.Count
                Dim dr As DataRow = Result.NewRow
                For j As Integer = 1 To ExcelWorkSheet.UsedRange.Columns.Count
                    dr(j - 1) = DirectCast(ExcelWorkSheet.Cells(i, j), Microsoft.Office.Interop.Excel.Range).Value2
                Next
                If Result.Rows.Count = 0 Then
                    For j As Integer = 1 To ExcelWorkSheet.UsedRange.Columns.Count
                        If IsDBNull(dr(j - 1)) = False Then
                            Result.Rows.Add(dr)
                            Exit For
                        End If
                    Next
                Else
                    Result.Rows.Add(dr)
                End If
            Next

            If FirstRowIsHeader AndAlso Result.Rows.Count > 0 Then
                Dim dr As DataRow = Result.Rows(0)
                For i As Integer = 0 To Result.Columns.Count - 1
                    If IsDBNull(dr(i)) = False Then
                        Result.Columns(i).ColumnName = dr(i)
                    End If
                Next
                dr.Delete()
            End If

            ExcelWorkBook.Close(False)
            ExcelApplication.Quit()

            Result.AcceptChanges()
            Return Result
        Catch ex As Exception
            Throw ex
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try

    End Function

    Public Sub Write(ByVal input(,) As Object)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture

        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim ExcelApplication As New Microsoft.Office.Interop.Excel.Application
            ExcelApplication.SheetsInNewWorkbook = 1
            Dim ExcelWorkBook As Microsoft.Office.Interop.Excel.Workbook = ExcelApplication.Workbooks.Add()
            Dim ExcelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = ExcelWorkBook.Sheets(1)
            ExcelWorkSheet.Columns.NumberFormat = "@"
            ExcelWorkSheet.Range("A1").Resize(input.GetUpperBound(0) + 1, input.GetUpperBound(1) + 1).Value = input
            ExcelWorkBook.SaveAs(Me._filePath)
            ExcelWorkBook.Close()
            ExcelApplication.Quit()
            ExcelApplication = Nothing

            If ShowConfirmMessage("آیا مایل به مشاهده فایل خروجی هستید؟") = True Then
                OpenExcel(Me._filePath)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub

    Public Sub Write(ByVal input As System.Data.DataTable)
        If input.Columns.Count = 0 Then Exit Sub
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim ExcelApplication As New Microsoft.Office.Interop.Excel.Application
            ExcelApplication.SheetsInNewWorkbook = 1
            Dim ExcelWorkBook As Microsoft.Office.Interop.Excel.Workbook = ExcelApplication.Workbooks.Add()
            Dim ExcelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = ExcelWorkBook.Sheets(1)
            ExcelWorkSheet.DisplayRightToLeft = True
            ExcelApplication.DefaultSheetDirection = XlDirection.xlToRight
            Dim arrHeader(0, input.Columns.Count - 1) As Object
            For intCounter As Integer = 0 To (input.Columns.Count - 1)
                arrHeader(0, intCounter) = input.Columns(intCounter).Caption
                ExcelWorkSheet.Range("A1").Resize(arrHeader.GetUpperBound(0) + 1, arrHeader.GetUpperBound(1) + 1).Value = arrHeader
            Next
            For intCounter As Integer = 0 To Convert.ToInt32(Math.Floor((input.Rows.Count - 1) / 10000))
                Dim Start As String = "A" + ((intCounter * 10000) + 2).ToString
                Dim arrayInput(,) As Object
                Dim RowCount As Int64 = 0
                If intCounter = Convert.ToInt32(Math.Floor((input.Rows.Count - 1) / 10000)) Then
                    ReDim arrayInput(((input.Rows.Count - 1) Mod 10000), input.Columns.Count - 1)
                    RowCount = ((input.Rows.Count - 1) Mod 10000)
                Else
                    ReDim arrayInput(9999, input.Columns.Count - 1)
                    RowCount = 9999
                End If
                For intRowCount As Integer = 0 To RowCount
                    For intColumnCounter As Integer = 0 To input.Columns.Count - 1
                        If (input.Rows(intCounter * 10000 + intRowCount)(intColumnCounter) Is DBNull.Value) Or (IsNothing(input.Rows(intCounter * 10000 + intRowCount)(intColumnCounter))) Then
                            arrayInput(intRowCount, intColumnCounter) = String.Empty
                        Else
                            arrayInput(intRowCount, intColumnCounter) = input.Rows(intCounter * 10000 + intRowCount)(intColumnCounter).ToString.Replace("=", "")
                        End If
                    Next
                Next
                ExcelWorkSheet.Columns.NumberFormat = "@"
                ExcelWorkSheet.Range(Start).Resize(arrayInput.GetUpperBound(0) + 1, arrayInput.GetUpperBound(1) + 1).Value = arrayInput
            Next
            ExcelWorkBook.SaveAs(Me._filePath)
            ExcelWorkBook.Close()
            ExcelApplication.Quit()
            ExcelApplication = Nothing

            If ShowConfirmMessage("آیا مایل به مشاهده فایل خروجی هستید؟") = True Then
                OpenExcel(Me._filePath)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub

    Public Sub Write(ByVal input As DataGridView)
        If input.Columns.Count = 0 Then Exit Sub
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim ExcelApplication As New Microsoft.Office.Interop.Excel.Application
            ExcelApplication.SheetsInNewWorkbook = 1
            Dim ExcelWorkBook As Microsoft.Office.Interop.Excel.Workbook = ExcelApplication.Workbooks.Add()
            Dim ExcelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = ExcelWorkBook.Sheets(1)

            Dim arrHeader(0, input.Columns.Count - 1) As Object
            For intCounter As Integer = 0 To (input.Columns.Count - 1)
                arrHeader(0, intCounter) = input.Columns(intCounter).HeaderText.ToString
                ExcelWorkSheet.Range("A1").Resize(arrHeader.GetUpperBound(0) + 1, arrHeader.GetUpperBound(1) + 1).Value = arrHeader
            Next
            For intCounter As Integer = 0 To Convert.ToInt32(Math.Floor((input.Rows.Count - 1) / 10000))
                Dim Start As String = "A" + ((intCounter * 10000) + 2).ToString
                Dim arrayInput(,) As Object
                Dim RowCount As Int64 = 0
                If intCounter = Convert.ToInt32(Math.Floor((input.Rows.Count - 1) / 10000)) Then
                    ReDim arrayInput(((input.Rows.Count - 1) Mod 10000), input.Columns.Count - 1)
                    RowCount = ((input.Rows.Count - 1) Mod 10000)
                Else
                    ReDim arrayInput(9999, input.Columns.Count - 1)
                    RowCount = 9999
                End If
                For intRowCount As Integer = 0 To RowCount
                    If input.Rows(intRowCount).Visible = True Then

                        For intColumnCounter As Integer = 0 To input.Columns.Count - 1
                            If (input.Rows(intCounter * 10000 + intRowCount).Cells(intColumnCounter).Value Is DBNull.Value) Or (IsNothing(input.Rows(intCounter * 10000 + intRowCount).Cells(intColumnCounter).Value)) Then
                                arrayInput(intRowCount, intColumnCounter) = String.Empty
                            Else
                                arrayInput(intRowCount, intColumnCounter) = input.Rows(intCounter * 10000 + intRowCount).Cells(intColumnCounter).Value.ToString.Replace("=", "")
                            End If
                        Next
                    End If

                Next
                ExcelWorkSheet.Columns.NumberFormat = "@"
                ExcelWorkSheet.Range(Start).Resize(arrayInput.GetUpperBound(0) + 1, arrayInput.GetUpperBound(1) + 1).Value = arrayInput
            Next
            ExcelWorkBook.SaveAs(Me._filePath)
            ExcelWorkBook.Close()
            ExcelApplication.Quit()
            ExcelApplication = Nothing

            If ShowConfirmMessage("آیا مایل به مشاهده فایل خروجی هستید؟") = True Then
                OpenExcel(Me._filePath)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub

    Public Sub Write(ByVal lstDataTable As List(Of System.Data.DataTable), ByVal lstSheetName As List(Of String))
        If lstDataTable.Count = 0 Then
            Exit Sub
        End If

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            Dim ExcelApplication As New Microsoft.Office.Interop.Excel.Application
            ExcelApplication.SheetsInNewWorkbook = lstDataTable.Count
            Dim ExcelWorkBook As Microsoft.Office.Interop.Excel.Workbook = ExcelApplication.Workbooks.Add()

            For i As Integer = 0 To lstDataTable.Count - 1
                Dim ExcelWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = ExcelWorkBook.Sheets(i + 1)
                ExcelWorkSheet.Name = lstSheetName(i)
                Dim arrHeader(0, lstDataTable.Item(i).Columns.Count - 1) As Object
                For intCounter As Integer = 0 To (lstDataTable.Item(i).Columns.Count - 1)
                    arrHeader(0, intCounter) = lstDataTable.Item(i).Columns(intCounter).Caption
                    ExcelWorkSheet.Range("A1").Resize(arrHeader.GetUpperBound(0) + 1, arrHeader.GetUpperBound(1) + 1).Value = arrHeader
                Next
                For intCounter As Integer = 0 To Convert.ToInt32(Math.Floor((lstDataTable.Item(i).Rows.Count - 1) / 10000))
                    Dim Start As String = "A" + ((intCounter * 10000) + 2).ToString
                    Dim arrayInput(,) As Object
                    Dim RowCount As Int64 = 0
                    If intCounter = Convert.ToInt32(Math.Floor((lstDataTable.Item(i).Rows.Count - 1) / 10000)) Then
                        ReDim arrayInput(((lstDataTable.Item(i).Rows.Count - 1) Mod 10000), lstDataTable.Item(i).Columns.Count - 1)
                        RowCount = ((lstDataTable.Item(i).Rows.Count - 1) Mod 10000)
                    Else
                        ReDim arrayInput(9999, lstDataTable.Item(i).Columns.Count - 1)
                        RowCount = 9999
                    End If
                    For intRowCount As Integer = 0 To RowCount
                        For intColumnCounter As Integer = 0 To lstDataTable.Item(i).Columns.Count - 1
                            If (lstDataTable.Item(i).Rows(intCounter * 10000 + intRowCount)(intColumnCounter) Is DBNull.Value) Or (IsNothing(lstDataTable.Item(i).Rows(intCounter * 10000 + intRowCount)(intColumnCounter))) Then
                                arrayInput(intRowCount, intColumnCounter) = String.Empty
                            Else
                                arrayInput(intRowCount, intColumnCounter) = lstDataTable.Item(i).Rows(intCounter * 10000 + intRowCount)(intColumnCounter).ToString.Replace("=", "")
                            End If
                        Next
                    Next
                    ExcelWorkSheet.Columns.NumberFormat = "@"
                    ExcelWorkSheet.Range(Start).Resize(arrayInput.GetUpperBound(0) + 1, arrayInput.GetUpperBound(1) + 1).Value = arrayInput
                Next
            Next

            ExcelWorkBook.SaveAs(Me._filePath)
            ExcelWorkBook.Close()
            ExcelApplication.Quit()
            ExcelApplication = Nothing

            If ShowConfirmMessage("آیا مایل به مشاهده فایل خروجی هستید؟") = True Then
                OpenExcel(Me._filePath)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub

    Public Sub OpenExcel(ByVal FileName As String)
        Dim p As New System.Diagnostics.Process
        p.StartInfo.FileName = FileName
        p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
        p.Start()
        p.Close()
    End Sub

    Public Sub ExportToText(ByVal objDataReader As System.Data.DataTable)
        Dim i As Integer
        Dim sb As New System.Text.StringBuilder
        Try
            Dim intColumn, intColumnValue As Integer
            Dim row As DataRow
            For intColumn = 0 To objDataReader.Columns.Count - 1
                sb.Append(objDataReader.Columns(intColumn).ColumnName)
                If intColumnValue <> objDataReader.Columns.Count - 1 Then
                    sb.Append(vbTab)
                End If
            Next
            sb.Append(vbCrLf)
            For Each row In objDataReader.Rows
                For intColumnValue = 0 To objDataReader.Columns.Count - 1
                    sb.Append(StrConv(IIf(IsDBNull(row.Item(intColumnValue)), "", row.Item(intColumnValue)), VbStrConv.ProperCase))
                    If intColumnValue <> objDataReader.Columns.Count - 1 Then
                        sb.Append(vbTab)
                    End If
                Next
                sb.Append(vbCrLf)
            Next

            SaveExcel(Me._filePath, sb)
            If ShowConfirmMessage("آیا مایل به مشاهده فایل خروجی هستید؟") = True Then
                OpenExcel(Me._filePath)
            End If

        Catch ex As Exception
            Throw
        Finally
            objDataReader = Nothing
            sb = Nothing
        End Try
    End Sub

    Public Sub ExportToExcel1(ByVal objDataReader As DataGridView)
        Dim i As Integer
        Dim sb As New System.Text.StringBuilder
        Try
            Dim intColumn, intColumnValue As Integer
            Dim row As DataGridViewRow
            For intColumn = 0 To objDataReader.Columns.Count - 1
                sb.Append(objDataReader.Columns(intColumn).HeaderText)
                If intColumnValue <> objDataReader.Columns.Count - 1 Then
                    sb.Append(vbTab)
                End If
            Next
            sb.Append(vbCrLf)
            For Each row In objDataReader.Rows
                For intColumnValue = 0 To objDataReader.Columns.Count - 1
                    sb.Append(StrConv(IIf(IsDBNull(row.Cells(intColumnValue).Value), "", row.Cells(intColumnValue).Value), VbStrConv.ProperCase))
                    If intColumnValue <> objDataReader.Columns.Count - 1 Then
                        sb.Append(vbTab)
                    End If
                Next
                sb.Append(vbCrLf)
            Next

            SaveExcel(Me._filePath, sb)
            If ShowConfirmMessage("آیا مایل به مشاهده فایل خروجی هستید؟") = True Then
                OpenExcel(Me._filePath)
            End If

        Catch ex As Exception
            Throw
        Finally
            objDataReader = Nothing
            sb = Nothing
        End Try
    End Sub

    Private Sub SaveExcel(ByVal fpath As String, ByVal sb As System.Text.StringBuilder)
        Dim fsFile As New FileStream(fpath, FileMode.Create, FileAccess.Write)
        Dim strWriter As New StreamWriter(fsFile)
        Try
            With strWriter
                .BaseStream.Seek(0, SeekOrigin.End)
                .WriteLine(sb)
                .Close()
            End With
        Catch e As Exception
            Throw
        Finally
            sb = Nothing
            strWriter = Nothing
            fsFile = Nothing
        End Try
    End Sub

End Class
