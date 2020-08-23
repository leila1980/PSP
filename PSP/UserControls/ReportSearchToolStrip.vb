Public Class ReportSearchToolStrip
    Private dtSearchField As New DataTable
    Private dtSearchOperation As New DataTable
    Private MyDataGridView As DataGridView
    Private MyDataTable As DataTable
    Private MyDataView As DataView
    Private MyExcelSheetName As String
    Private strFilter As String
    Private oStack As New Stack
    Private OrginalFilter As String

    Event Print_Click()
    Event Show_Click()


    Public Property btnShowVisible() As Boolean
        Get
            Return btnShow.Visible
        End Get
        Set(ByVal value As Boolean)
            btnShow.Visible = value
            ToolStripSeparator1.Visible = value
        End Set
    End Property
    Public Property btnPrintVisible() As Boolean
        Get
            Return btnPrint.Visible
        End Get
        Set(ByVal value As Boolean)
            btnPrint.Visible = value
            ToolStripSeparator10.Visible = value
        End Set
    End Property
    Public Property btnExportExcelVisible() As Boolean
        Get
            Return btnExportExcel.Visible
        End Get
        Set(ByVal value As Boolean)
            btnExportExcel.Visible = value
            ToolStripSeparator4.Visible = value
        End Set
    End Property
    Public Sub Init(ByVal datagridview As DataGridView, ByVal datatable As DataTable, ByVal excelsheetname As String)
        MyDataGridView = datagridview
        MyDataTable = datatable
        MyDataView = MyDataTable.DefaultView
        Me.OrginalFilter = MyDataTable.DefaultView.RowFilter

        MyExcelSheetName = excelsheetname
        If dtSearchField.Columns.Count = 0 Then
            dtSearchField.Columns.Add("FieldText")
            dtSearchField.Columns.Add("FieldName")
            dtSearchField.Columns.Add("FieldType")
        End If
        If dtSearchOperation.Columns.Count = 0 Then
            dtSearchOperation.Columns.Add("OperationName")
            dtSearchOperation.Columns.Add("Operator")
        End If
        RemoveHandler cboSearchField.SelectedIndexChanged, AddressOf cboSearchField_SelectedIndexChanged
        FillSearch()
        AddHandler cboSearchField.SelectedIndexChanged, AddressOf cboSearchField_SelectedIndexChanged
    End Sub
    Private Sub FillSearch()
        dtSearchField.Clear()
        For i As Int32 = 0 To MyDataGridView.Columns.Count - 1
            If MyDataGridView.Columns(i).Visible = True Then
                'OrElse MyDataTable.Columns(MyDataGridView.Columns(i).Name).DataType Is GetType(System.Boolean)
                If MyDataGridView.Columns(i).CellType.FullName <> "System.Windows.Forms.DataGridViewCheckBoxCell" Then
                    Dim dr As DataRow = dtSearchField.NewRow
                    dr.Item("FieldText") = MyDataGridView.Columns(i).HeaderText
                    dr.Item("FieldName") = MyDataGridView.Columns(i).Name.ToString
                    dr.Item("FieldType") = MyDataTable.Columns(MyDataGridView.Columns(i).Name).DataType
                    dtSearchField.Rows.Add(dr)
                End If
            End If
        Next
        cboSearchField.ComboBox.DisplayMember = "FieldText"
        cboSearchField.ComboBox.ValueMember = "FieldName"
        cboSearchField.ComboBox.DataSource = dtSearchField
        cboSearchField.ComboBox.SelectedIndex = -1
        cboSearchOperation.ComboBox.DataSource = Nothing
        txtSearch.Text = String.Empty

    End Sub
    Private Sub cboSearchField_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchField.SelectedIndexChanged
        Try
            FillSearchOperation()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillSearchOperation()
        Try
            dtSearchOperation.Clear()

            Dim dr() As DataRow
            dr = DirectCast(cboSearchField.ComboBox.DataSource, DataTable).Select("FieldName ='" & cboSearchField.ComboBox.SelectedValue & "'")

            If dr.Length > 0 Then
                Select Case dr(0).Item("FieldType").ToString
                    Case "System.String"
                        FillSearchOperationItems("شامل", "{0} Like '%{1}%'")
                        FillSearchOperationItems("برابر با", "{0}='{1}'")
                        FillSearchOperationItems("شروع با", "{0} Like '{1}%'")
                        FillSearchOperationItems("ختم به", "{0} Like '%{1}'")
                        FillSearchOperationItems("غیر شامل", "{0} not Like '%{1}%'")
                        FillSearchOperationItems("نامساوی با", "{0}<>'{1}'")
                        FillSearchOperationItems("بزرگتر از", "{0}>'{1}'")
                        FillSearchOperationItems("بزرگتر از یا مساوی با", "{0}>='{1}'")
                        FillSearchOperationItems("کوچکتر از", "{0}<'{1}'")
                        FillSearchOperationItems("کوچکتر از یا مساوی با", "{0}<='{1}'")

                    Case "System.Boolean"

                    Case "System.DateTime"
                        FillSearchOperationItems("نامساوی با", "{0}<>'{1}'")
                        FillSearchOperationItems("بزرگتر از", "{0}>'{1}'")
                        FillSearchOperationItems("بزرگتر از یا مساوی با", "{0}>='{1}'")
                        FillSearchOperationItems("کوچکتر از", "{0}<'{1}'")
                        FillSearchOperationItems("کوچکتر از یا مساوی با", "{0}<='{1}'")
                    Case Else
                        FillSearchOperationItems("برابر با", "{0}={1}")
                        FillSearchOperationItems("نامساوی با", "{0}<>{1}")
                        FillSearchOperationItems("بزرگتر از", "{0}>{1}")
                        FillSearchOperationItems("بزرگتر از یا مساوی با", "{0}>={1}")
                        FillSearchOperationItems("کوچکتر از", "{0}<{1}")
                        FillSearchOperationItems("کوچکتر از یا مساوی با", "{0}<={1}")

                End Select
            End If
            cboSearchOperation.ComboBox.DisplayMember = "OperationName"
            cboSearchOperation.ComboBox.ValueMember = "Operator"
            cboSearchOperation.ComboBox.DataSource = dtSearchOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillSearchOperationItems(ByVal opname As String, ByVal op As String)
        Dim drOP As DataRow = dtSearchOperation.NewRow
        drOP.Item("OperationName") = opname
        drOP.Item("Operator") = op
        dtSearchOperation.Rows.Add(drOP)
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        MyDataGridView.EndEdit()
        If cboSearchField.ComboBox.SelectedIndex = -1 OrElse cboSearchOperation.ComboBox.SelectedIndex = -1 OrElse txtSearch.Text.Trim = String.Empty Then
            strFilter = Me.OrginalFilter
        Else
            Dim dr() As DataRow
            dr = DirectCast(cboSearchField.ComboBox.DataSource, DataTable).Select("FieldName='" & cboSearchField.ComboBox.SelectedValue.ToString & "'")
            If dr.Length > 0 Then
                If Not (dr(0).Item("FieldType") = "System.String" Or dr(0).Item("FieldType") = "System.char" Or dr(0).Item("FieldType") = "System.dateTime" Or dr(0).Item("FieldType") = "System.Boolean") Then
                    If IsNumeric(txtSearch.Text) = False Then
                        Exit Sub
                    End If
                End If
            End If


            If MyDataView.RowFilter.Contains(String.Format(cboSearchOperation.ComboBox.SelectedValue.ToString, cboSearchField.ComboBox.SelectedValue.ToString, txtSearch.Text)) = False Then
                If String.IsNullOrEmpty(MyDataView.RowFilter) = False Then
                    oStack.Push(MyDataView.RowFilter)
                End If
            End If



            If oStack.Count > 0 Then
                strFilter = oStack.Peek
                If strFilter.Contains(String.Format(cboSearchOperation.ComboBox.SelectedValue.ToString, cboSearchField.ComboBox.SelectedValue.ToString, modPublicMethod.CorrectLike(txtSearch.Text))) = False Then
                    strFilter = String.Format(cboSearchOperation.ComboBox.SelectedValue.ToString, cboSearchField.ComboBox.SelectedValue.ToString, modPublicMethod.CorrectLike(txtSearch.Text)) & " And " & strFilter
                End If
            Else
                strFilter = String.Format(cboSearchOperation.ComboBox.SelectedValue.ToString, cboSearchField.ComboBox.SelectedValue.ToString, modPublicMethod.CorrectLike(txtSearch.Text))
            End If
        End If

        If txtSearch.Text.Trim = String.Empty Then
            strFilter = cboSearchField.ComboBox.SelectedValue.ToString + " is null "
        End If

        MyDataView.RowFilter = strFilter
        MyDataGridView.DataSource = MyDataView
    End Sub
    Private Sub btnSearchBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBack.Click
        MyDataGridView.EndEdit()
        If oStack.Count > 0 AndAlso Not (oStack.Count = 1 And oStack.Peek = Me.OrginalFilter) Then
            strFilter = oStack.Pop
        Else
            strFilter = Me.OrginalFilter
        End If
        MyDataView.RowFilter = strFilter
        MyDataGridView.DataSource = MyDataView

    End Sub

    Private Sub btnRemoveFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFilter.Click
        MyDataGridView.EndEdit()
        strFilter = Me.OrginalFilter
        oStack.Clear()
        MyDataView.RowFilter = strFilter
        MyDataGridView.DataSource = MyDataView
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.MyDataGridView)
            End If
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        RaiseEvent Print_Click()
    End Sub
    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Try
            RaiseEvent Show_Click()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
End Class
