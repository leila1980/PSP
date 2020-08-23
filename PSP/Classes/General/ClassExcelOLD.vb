Imports System.IO
Imports Microsoft.Office.Interop

Public Class ClassExcel
    Private Shared dsExcel As New DataSet
    Private Shared mvarExcelFilePath As String
    Private Shared mvarExcelSheetName As String
    Public Shared OPenFileDialog As New OpenFileDialog

    Public Shared Property ExcelFilePath()
        Get
            Return mvarExcelFilePath
        End Get
        Set(ByVal value)
            mvarExcelFilePath = value
        End Set
    End Property
    Public Shared Property ExcelSheetName()
        Get
            Return mvarExcelSheetName
        End Get
        Set(ByVal value)
            mvarExcelSheetName = value
        End Set
    End Property
    Public Shared Function GetExcel() As DataTable
        Try
            Dim ExcelData As New GetExcelData.GetExcelData
            If File.Exists(ExcelFilePath) = False Then
                Throw New FileNotFoundException
            ElseIf ExcelSheetName.trim = "" Then
                Throw New MissingFieldException
            Else
                dsExcel = ExcelData.GetData(ExcelFilePath, ExcelSheetName)
                GetExcel = dsExcel.Tables(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub RunExcelOutput(ByRef DataGridView As DataGridView, ByVal WorkBookName As String, ByVal OutputFileName As String)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim Application As New Excel.Application
            Application.SheetsInNewWorkbook = 1
            Dim wb As Excel.Workbook = Application.Workbooks.Add()
            Dim y As Excel.Worksheet = wb.Sheets(1)
            If WorkBookName.Length > 31 Then
                y.Name = WorkBookName.Substring(0, 31)
            Else
                y.Name = WorkBookName
            End If
            Dim rowIndex As Integer
            Dim colIndex As Integer

            Dim ColCount As Integer = DataGridView.Columns.Count
            Dim RowCount As Integer = DataGridView.Rows.Count
            Dim r(RowCount, ColCount - 1) As String

            For colIndex = 1 To DataGridView.Columns.Count
                'TryCast(y.Cells(1, colIndex), Excel.Range).Value2 = DataGridView.Columns(colIndex - 1).HeaderText
                r(0, colIndex - 1) = DataGridView.Columns(colIndex - 1).HeaderText
            Next

            For rowIndex = 1 To RowCount
                For colIndex = 1 To ColCount
                    'TryCast(y.Cells(rowIndex + 1, colIndex), Excel.Range).Value2 = DataGridView.Item(colIndex - 1, rowIndex - 1).Value.ToString()
                    If IsNothing(DataGridView.Item(colIndex - 1, rowIndex - 1).Value) = True Then
                        r(rowIndex, colIndex - 1) = ""
                    Else
                        r(rowIndex, colIndex - 1) = DataGridView.Item(colIndex - 1, rowIndex - 1).Value.ToString
                    End If
                Next
            Next
            y.Range("A1").Resize(RowCount + 1, ColCount).Value = r
            wb.SaveAs(OutputFileName)
            wb.Close()
            Application.Quit()
            Application = Nothing
            If ShowConfirmMessage("¬Ì« „«Ì· »Â „‘«ÂœÂ ›«Ì· Œ—ÊÃÌ Â” Ìœø") = True Then
                OpenExcel(OutputFileName)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub

    Public Shared Sub RunExcelOutput(ByRef DataTable As DataTable, ByVal WorkBookName As String, ByVal OutputFileName As String)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim Application As New Excel.Application
            Application.SheetsInNewWorkbook = 1
            Dim wb As Excel.Workbook = Application.Workbooks.Add()
            Dim y As Excel.Worksheet = wb.Sheets(1)
            If WorkBookName.Length > 31 Then
                y.Name = WorkBookName.Substring(0, 31)
            Else
                y.Name = WorkBookName
            End If
            Dim rowIndex As Integer
            Dim colIndex As Integer

            Dim ColCount As Integer = DataTable.Columns.Count
            Dim RowCount As Integer = DataTable.Rows.Count
            Dim r(RowCount, ColCount - 1) As String

            For colIndex = 1 To DataTable.Columns.Count
                r(0, colIndex - 1) = DataTable.Columns(colIndex - 1).ColumnName
            Next

            For rowIndex = 1 To RowCount
                For colIndex = 1 To ColCount
                    If IsNothing(DataTable.Rows(rowIndex - 1).Item(colIndex - 1)) = True Then
                        r(rowIndex, colIndex - 1) = ""
                    Else
                        r(rowIndex, colIndex - 1) = DataTable.Rows(rowIndex - 1).Item(colIndex - 1).ToString
                    End If
                Next
            Next
            y.Range("A1").Resize(RowCount + 1, ColCount).Value = r
            wb.SaveAs(OutputFileName)
            wb.Close()
            Application.Quit()
            Application = Nothing
            If ShowConfirmMessage("¬Ì« „«Ì· »Â „‘«ÂœÂ ›«Ì· Œ—ÊÃÌ Â” Ìœø") = True Then
                OpenExcel(OutputFileName)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub
    Public Shared Sub ChooseFile()
        Try
            Dim FilePath As String = String.Empty
            OPenFileDialog.FileName = String.Empty
            OPenFileDialog.Filter = "Excel(*.xls)|*.xls"
            OPenFileDialog.ShowDialog()
            FilePath = OPenFileDialog.FileName.Trim
            If FilePath <> String.Empty Then
                Dim FI As New System.IO.FileInfo(FilePath)
                If FI.Extension.ToString.ToLower = ".xls".ToLower Then
                    ExcelFilePath = FilePath
                Else
                    ExcelFilePath = String.Empty
                End If
            Else
                ExcelFilePath = String.Empty
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Shared Sub OpenExcel(ByVal FileName As String)
        Dim p As New System.Diagnostics.Process
        p.StartInfo.FileName = FileName
        p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
        p.Start()
        p.Close()
    End Sub
End Class
