Imports Oracle.DataAccess.Client
Public Class Frm_ProduceCode
    Dim Ds_ProduceCode As New DataSet
    Dim Dv_ProduceCode As DataView
    Dim oClsPacking As New ClassDalPAcking(ConnectionString) 'modPublicMethod.ConnectionString

    Private Sub Frm_ProduceCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Ds_ProduceCode = oClsPacking.Fill_DsProduceCode

            Dv_ProduceCode = New DataView(Ds_ProduceCode.Tables("Pos_T"), "", "", DataViewRowState.CurrentRows)

            Dgv_Code.AutoGenerateColumns = False
            Dgv_Code.DataSource = Dv_ProduceCode
            Txt_EniacCode.Text = oClsPacking.GetMaxCode("EniacCode_vc")
            'Txt_PropertyCode.Text = oClsPacking.GetMaxCode("TempPropertyNo_vc")
            Txt_PropertyCode.Text = oClsPacking.GetMaxProprty()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ok.Click

        Dim SelectionFormula As String = ""
        Dim EniacReportName As String = "EniacCodeLable.rpt"
        Dim PropertyReportName As String = "PropertyLable.rpt"
        Try



            Dim EniacCode As Object = Txt_EniacCode.Text
            If Txt_EniacCode.Text = "0" Then EniacCode = 1

            Dim PropertyCode As Object = Txt_PropertyCode.Text
            If Txt_PropertyCode.Text = "0" Then PropertyCode = 1

            For i As Int16 = 1 To NUD_Count.Value
                oClsPacking.InsertIntoPos_T(EniacCode, PropertyCode)
                EniacCode += 1
                PropertyCode += 1
            Next
            Dim DtProduceCode As New DataTable
            Ds_ProduceCode = oClsPacking.Fill_DsProduceCode
            DtProduceCode = oClsPacking.Fill_DtAfterProduceCode(Txt_EniacCode.Text)
            Dv_ProduceCode = New DataView(DtProduceCode, "", "", DataViewRowState.CurrentRows)
            Dgv_Code.AutoGenerateColumns = False
            Dgv_Code.DataSource = Dv_ProduceCode

            '***********************
            Dim EndOfEniacCode As Int64 = Val(Txt_EniacCode.Text) + NUD_Count.Value
            SelectionFormula = "ToNumber({Pos_T.EniacCode_vc})>=" + Txt_EniacCode.Text + " AND ToNumber({Pos_T.EniacCode_vc})<=" + EndOfEniacCode.ToString
            Dim MyPrinter As New PrintDialog
            If MyPrinter.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                oClsPacking.PrintMyReport(SelectionFormula, EniacReportName, MyPrinter.PrinterSettings.PrinterName, MyPrinter.PrinterSettings.Copies, Ds_ProduceCode)
                '***********************
                Dim EndOfPropertyCode As Int64 = Val(Txt_PropertyCode.Text) + NUD_Count.Value
                SelectionFormula = "ToNumber({Pos_T.TempPropertyNo_vc})>=" + Txt_PropertyCode.Text + " AND ToNumber({Pos_T.TempPropertyNo_vc})<=" + EndOfPropertyCode.ToString
                Windows.Forms.Cursor.Current = Cursors.WaitCursor
                oClsPacking.PrintMyReport(SelectionFormula, PropertyReportName, MyPrinter.PrinterSettings.PrinterName, MyPrinter.PrinterSettings.Copies, Ds_ProduceCode)
                Windows.Forms.Cursor.Current = Cursors.Default
                '***********************
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txt_PropertyCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PropertyCode.KeyPress
        If Char.IsDigit(e.KeyChar) = False Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Txt_EniacCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_EniacCode.KeyPress
        If Char.IsDigit(e.KeyChar) = False Then
            e.KeyChar = ""
        End If
    End Sub
End Class