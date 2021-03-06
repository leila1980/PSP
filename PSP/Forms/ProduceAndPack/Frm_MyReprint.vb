Imports System.Xml
Imports Yogesh.ExcelXml

Public Class Frm_MyReprint

    Dim M_Ds As New DataSet
    Dim oClsPacking As New ClassDalPAcking(ConnectionString) 'modPublicMethod.ConnectionString

#Region "CheckedChanged"
    Private Sub Rdo_Batch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_Batch.CheckedChanged
        If Rdo_Batch.Checked Then
            Pnl_Batch.Enabled = True
        Else
            Pnl_Batch.Enabled = False
        End If
    End Sub

    Private Sub Rdo_Code_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_Code.CheckedChanged
        If Rdo_Code.Checked Then
            Pnl_Code.Enabled = True
        Else
            Pnl_Code.Enabled = False
        End If
    End Sub

    Private Sub Chk_EniacCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_EniacCode.CheckedChanged
        If Chk_EniacCode.Checked Then
            Pnl_Eniac.Enabled = True
        Else
            Pnl_Eniac.Enabled = False
        End If
    End Sub

    Private Sub Chk_PropertyCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_PropertyCode.CheckedChanged
        If Chk_PropertyCode.Checked Then
            Pnl_Property.Enabled = True
        Else
            Pnl_Property.Enabled = False
        End If
    End Sub
#End Region
    Private Sub Btn_Reprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Reprint.Click
        Try
            ErrorProvider.Clear()
            Dim SelectionFormula As String = ""
            Dim EniacReportName As String = "EniacCodeLable.rpt"
            Dim PropertyReportName As String = "PropertyLable.rpt"
            Dim PropertyByBatchReportName As String = "PropertyLableByBatch.rpt"

            Dim MyPrinter As New PrintDialog
            MyPrinter.ShowDialog()
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            If Rdo_Batch.Checked Then
                SelectionFormula = ""
                If Txt_BatchNo.Text = "" Then
                    ErrorProvider.SetError(Txt_BatchNo, "هیچ شماره بچی وارد نشده است")
                    Exit Sub
                Else
                    If oClsPacking.IsExistCodeInPacking("BatchNo_int", Txt_BatchNo.Text) = False Then
                        ErrorProvider.SetError(Txt_BatchNo, "شماره بچ  موجود نمی باشد")

                    Else
                        SelectionFormula = "{Pos_T.BatchNo_int}=" + Txt_BatchNo.Text
                        PrintMyReport(SelectionFormula, EniacReportName, MyPrinter.PrinterSettings.PrinterName, MyPrinter.PrinterSettings.Copies)
                        PrintMyReport(SelectionFormula, PropertyByBatchReportName, MyPrinter.PrinterSettings.PrinterName, MyPrinter.PrinterSettings.Copies)
                    End If
                End If
            ElseIf Rdo_Code.Checked Then
                If Chk_EniacCode.Checked Then
                    SelectionFormula = ""
                    If Txt_FromEniacCode.Text = "" Then
                        ErrorProvider.SetError(Txt_FromEniacCode, "کد پیگیری وارد نشده است")
                        Exit Sub
                    Else
                        SelectionFormula = "ToNumber({Pos_T.EniacCode_vc})>=" + Txt_FromEniacCode.Text
                        If Txt_ToEniacCode.Text <> "" Then
                            SelectionFormula += " AND ToNumber({Pos_T.EniacCode_vc})<=" + Txt_ToEniacCode.Text
                        End If
                    End If
                    PrintMyReport(SelectionFormula, EniacReportName, MyPrinter.PrinterSettings.PrinterName, MyPrinter.PrinterSettings.Copies)

                End If
                If Chk_PropertyCode.Checked Then
                    SelectionFormula = ""
                    If Txt_FromPropertyCode.Text = "" Then
                        ErrorProvider.SetError(Txt_FromPropertyCode, "کد اموال وارد نشده است")
                        Exit Sub
                    Else
                        SelectionFormula = "ToNumber(totext({Pos_T.TempPropertyNo_vc}))>=" + Txt_FromPropertyCode.Text
                        If Txt_ToPropertyCode.Text <> "" Then
                            SelectionFormula += " AND ToNumber(totext({Pos_T.TempPropertyNo_vc}))<=" + Txt_ToPropertyCode.Text
                        End If
                    End If
                    PrintMyReport(SelectionFormula, PropertyReportName, MyPrinter.PrinterSettings.PrinterName, MyPrinter.PrinterSettings.Copies)

                End If
            End If
            Windows.Forms.Cursor.Current = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
    Sub PrintMyReport(ByVal SelectionFormula As String, ByVal ReportName As String, ByVal PrinterName As String, ByVal nCopy As Int16)
        Try
            M_Ds.Clear()
            Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            rpt.Load(Application.StartupPath & "\Reports\" + ReportName, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
            M_Ds = oClsPacking.Fill_DsPrintCode()
            rpt.SetDataSource(M_Ds)
            rpt.RecordSelectionFormula = SelectionFormula
            rpt.PrintOptions.PrinterName = PrinterName
            rpt.PrintToPrinter(nCopy, False, 0, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Btn_ExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ExportToExcel.Click


        Try
            M_Ds.Clear()
            ErrorProvider.Clear()
            If CheckTxts() Then
                If Rdo_Batch.Checked = True Then
                    M_Ds = oClsPacking.Fill_DsPrintCode(Txt_BatchNo.Text)
                ElseIf Rdo_Code.Checked = True Then
                    M_Ds = oClsPacking.Fill_DsPrintCode(Chk_EniacCode.Checked, Chk_PropertyCode.Checked, Txt_FromEniacCode.Text, Txt_ToEniacCode.Text _
                    , Txt_FromPropertyCode.Text, Txt_ToPropertyCode.Text)
                End If
            End If
            exportToExcel(M_Ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Frm_MyReprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)

        Rdo_Code.Checked = True
        Dim dt As New DataTable
    End Sub
    Private Sub Txt_BatchNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles Txt_BatchNo.KeyPress, Txt_FromEniacCode.KeyPress, Txt_ToEniacCode.KeyPress, Txt_FromPropertyCode.KeyPress, Txt_ToPropertyCode.KeyPress
        If Not Char.IsDigit(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub
    Public Sub exportToExcel(ByVal Ds As DataSet)
        Try

            Dim book As New ExcelXmlWorkbook
            Dim SaveDg As New SaveFileDialog
            SaveDg.Filter = "Excel 2003 files (*.xls)|*.xls|Excel 2007 files (*.xlsx)|*.xlsx"
            If SaveDg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim sheet As Worksheet = book(0)

                If Ds.Tables("Pos_T").Columns.IndexOf("EniacCode_vc") = 0 Then
                    sheet(0, 0).Value = "کد پیگیری "
                End If
                If Ds.Tables("Pos_T").Columns.IndexOf("TempPropertyNo_vc") = 0 Then
                    sheet(0, 0).Value = "کد اموال"
                ElseIf Ds.Tables("Pos_T").Columns.IndexOf("TempPropertyNo_vc") = 1 Then
                    sheet(1, 0).Value = "کد اموال"
                End If
                For i As Integer = 0 To Ds.Tables("Pos_T").Rows.Count - 1
                    For j As Integer = 0 To Ds.Tables("Pos_T").Columns.Count - 1
                        sheet(j, i + 1).Value = Ds.Tables("Pos_T").Rows(i)(j).ToString
                    Next
                Next
                book.Export(SaveDg.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Function CheckTxts() As Boolean

        Dim result As Boolean = True
        If Rdo_Batch.Checked = True Then
            If Txt_BatchNo.Text = "" Then
                ErrorProvider.SetError(Txt_BatchNo, "هیچ شماره بچی وارد نشده است")
                result = False

            End If
        ElseIf Rdo_Code.Checked Then
            If Chk_EniacCode.Checked Then
                If Txt_FromEniacCode.Text = "" Then
                    ErrorProvider.SetError(Txt_FromEniacCode, "کد پیگیری وارد نشده است")
                    result = False

                End If
                If Txt_ToEniacCode.Text = "" Then
                    ErrorProvider.SetError(Txt_ToEniacCode, "کد پیگیری وارد نشده است")
                    result = False

                End If
            End If
            If Chk_PropertyCode.Checked Then

                If Txt_FromPropertyCode.Text = "" Then
                    ErrorProvider.SetError(Txt_FromPropertyCode, "کد اموال وارد نشده است")
                    result = False

                End If
                If Txt_ToPropertyCode.Text = "" Then
                    ErrorProvider.SetError(Txt_ToPropertyCode, "کد اموال وارد نشده است")
                    result = False

                End If
            End If

        End If
        Return result

    End Function





End Class