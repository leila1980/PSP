Public Class frmReqResDesc
    Private clsDALHelpDesk As New ClassDALHelpDesk(modPublicMethod.ConnectionString)
    Private dtReqRes As New DataTable
    Public Enum FormType As Short
        other = 1
        Req = 2
        'ResNotCompleted = 3
        'ResCompleted = 4
        ResCallcenter = 5
        ResCartable_Fani = 6
        ResCartable_Bank = 7
        ResCartable_Bazaryabi = 8
    End Enum

    Private _FType As FormType
    Public Property FType() As FormType
        Get
            Return _FType
        End Get
        Set(ByVal value As FormType)
            _FType = value
        End Set
    End Property
    Private _ReqResDesc As String = ""
    Public Property ReqResDesc() As String
        Get
            Return _ReqResDesc
        End Get
        Set(ByVal value As String)
            _ReqResDesc = value
        End Set
    End Property
    Private Sub frmReqResDesc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillReqResGrid(FType)
            InitReqResGrid()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub
    Private Sub FillReqResGrid(ByVal ftype As FormType)
        Try
            clsDALHelpDesk.BeginProc()
            dtReqRes.Clear()
            dtReqRes = clsDALHelpDesk.GetByOnlyTypeReqResDesc(ftype)
            dgvReqRes.DataSource = dtReqRes
        Catch ex As Exception
            Throw ex
        Finally
            clsDALHelpDesk.EndProc()
        End Try
    End Sub
    Private Sub InitReqResGrid()
        Try
            dgvReqRes.Columns("ID").Visible = False
            dgvReqRes.Columns("Name_nvc").HeaderText = ""
            dgvReqRes.Columns("Type").Visible = False
            dgvReqRes.Columns("Name_nvc").Width = 450

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    '    Try
    '        dgvReqRes.EndEdit()
    '        ReqResDesc = String.Empty
    '        For i As Int16 = 0 To dgvReqRes.Rows.Count - 1
    '            If dgvReqRes.Rows(i).Cells("CSelect").Value Then
    '                Me.ReqResDesc = Me.ReqResDesc & Space(1) & dgvReqRes.Rows(i).Cells("Name_nvc").Value
    '            End If
    '        Next
    '        Me.Close()
    '    Catch ex As Exception
    '        ShowErrorMessage(ex.Message)
    '    End Try
    'End Sub


    'Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
    '    Dim Row As Integer
    '    For Row = 1 To dgvReqRes.RowCount - 1
    '        dgvReqRes.Item("CSelect", Row).Value = True
    '    Next

    'End Sub
    'Private Sub btnDeselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselect.Click
    '    Dim Row As Integer
    '    For Row = 0 To dgvReqRes.RowCount - 1
    '        dgvReqRes.Item("CSelect", Row).Value = False
    '    Next
    'End Sub


    'Private Sub dgvReqRes_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If e.RowIndex = 0 AndAlso dgvReqRes.Item("CSelect", 0).Value = True Then
    '        Dim Row As Integer
    '        For Row = 1 To dgvReqRes.RowCount - 1
    '            dgvReqRes.Item("CSelect", Row).Value = False
    '        Next
    '    Else
    '        dgvReqRes.Item("CSelect", 0).Value = False
    '    End If
    '    'If e.ColumnIndex = 0 Then
    '    '    dgvReqRes.Rows(e.RowIndex).Cells(1).Selected = True
    '    'End If
    'End Sub
    Private Sub dgvReqRes_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReqRes.RowEnter
        dgvReqRes.Rows(e.RowIndex).Selected = True
    End Sub
    Private Sub dgvReqRes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvReqRes.DoubleClick
        If dgvReqRes.SelectedRows.Count > 0 Then
            Me.ReqResDesc = dgvReqRes.SelectedRows(0).Cells("Name_nvc").Value
            Me.Close()
        End If
    End Sub
    Private Sub dgvReqRes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvReqRes.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvReqRes.SelectedRows.Count > 0 Then
                Me.ReqResDesc = dgvReqRes.SelectedRows(0).Cells("Name_nvc").Value
                Me.Close()
            End If
        End If
    End Sub

  
End Class