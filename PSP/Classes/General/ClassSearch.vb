Public Class ClassSearch
    Private dtSearchField As New DataTable
    Private dtSearchOperation As New DataTable
    Private oStack As New Stack
    Private strFilter As String

    Public WithEvents cboSearchField As ToolStripComboBox
    Public WithEvents cboSearchOperation As ToolStripComboBox
    Public WithEvents txtSearch As ToolStripTextBox
    Public WithEvents btnSearch As ToolStripButton
    Public WithEvents btnSearchBack As ToolStripButton
    Public WithEvents btnRemoveFilter As ToolStripButton

    Public dgv As DataGridView
    Public dtdgv As DataTable
    Public dvdgv As DataView

#Region "Search"

    Private Sub FillSearch()
        Try

            For i As Int32 = 0 To dgv.Columns.Count - 1
                If dgv.Columns(i).Visible = True Then
                    If dgv.Columns(i).DataPropertyName <> "" AndAlso dtdgv.Columns(dgv.Columns(i).DataPropertyName).DataType IsNot GetType(System.Boolean) Then
                        Dim dr As DataRow = dtSearchField.NewRow
                        dr.Item("FieldText") = dgv.Columns(i).HeaderText
                        dr.Item("FieldName") = dgv.Columns(i).DataPropertyName
                        dr.Item("FieldType") = dtdgv.Columns(dgv.Columns(i).DataPropertyName).DataType
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
        Catch ex As Exception
            Throw ex
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

    Public Sub Init(ByVal _cboSearchField As ToolStripComboBox, ByVal _cboSearchOperation As ToolStripComboBox, ByVal _txtSearch As ToolStripTextBox, ByVal _btnSearch As ToolStripButton, ByVal _btnSearchBack As ToolStripButton, ByVal _btnRemoveFilter As ToolStripButton, ByVal _dgv As DataGridView, ByVal _dtdgv As DataTable, ByVal _dvdgv As DataView)
        Try
            cboSearchField = _cboSearchField
            cboSearchOperation = _cboSearchOperation
            txtSearch = _txtSearch
            btnSearch = _btnSearch
            btnSearchBack = _btnSearchBack
            btnRemoveFilter = _btnRemoveFilter
            dgv = _dgv
            dtdgv = _dtdgv
            dvdgv = _dvdgv

            dtSearchField.Columns.Add("FieldText")
            dtSearchField.Columns.Add("FieldName")
            dtSearchField.Columns.Add("FieldType")
            dtSearchOperation.Columns.Add("OperationName")
            dtSearchOperation.Columns.Add("Operator")

            RemoveHandler cboSearchField.SelectedIndexChanged, AddressOf cboSearchField_SelectedIndexChanged
            FillSearch()
            AddHandler cboSearchField.SelectedIndexChanged, AddressOf cboSearchField_SelectedIndexChanged
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub cboSearchField_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchField.SelectedIndexChanged
        Try
            FillSearchOperation()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Public Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If cboSearchField.ComboBox.SelectedIndex = -1 OrElse cboSearchOperation.ComboBox.SelectedIndex = -1 OrElse txtSearch.Text.Trim = String.Empty Then
            strFilter = String.Empty
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

            If dvdgv.RowFilter.Contains(String.Format(cboSearchOperation.ComboBox.SelectedValue.ToString, cboSearchField.ComboBox.SelectedValue.ToString, txtSearch.Text)) = False Then
                If String.IsNullOrEmpty(dvdgv.RowFilter) = False Then
                    oStack.Push(dvdgv.RowFilter)
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

        dvdgv.RowFilter = strFilter
    End Sub
    Public Sub btnSearchBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchBack.Click
        If oStack.Count > 0 Then
            strFilter = oStack.Pop
        Else
            strFilter = String.Empty
        End If
        dvdgv.RowFilter = strFilter

    End Sub
    Public Sub btnRemoveFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFilter.Click
        strFilter = String.Empty
        oStack.Clear()
        dvdgv.RowFilter = strFilter
    End Sub
#End Region
End Class
