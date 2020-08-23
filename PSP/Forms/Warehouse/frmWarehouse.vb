Public Class frmWarehouse

    Private statementSource As DataTable
    Private warehouseSource As DataTable
    Private serialSource As DataTable
    Private warehouse As ClassDALWarehouseStatement
    Private visitorID As Integer

#Region "Event Handlers"

    Private Sub frmAllStatements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            Me.FormLoad()
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message) 'modApplicationMessage.msgLoadFailed
            ClassError.LogError(ex)
        End Try

    End Sub

    Private Sub statementTypecb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statementTypecb.SelectedIndexChanged
        Me.statementSource.DefaultView.RowFilter = Me.getFilter()
    End Sub

    Private Sub statementNotxt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statementNotxt.TextChanged
        Me.statementSource.DefaultView.RowFilter = Me.getFilter()
    End Sub

    Private Sub dgvStatements_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvStatements.MouseDoubleClick
        Me.showStatementDetialsForm()
    End Sub

    Private Sub dgvStatements_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvStatements.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.showStatementDetialsForm()
        End If
    End Sub

    Private Sub dgvWarehouse_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvWarehouse.MouseDoubleClick
        fillSerialGrid()
    End Sub

    Private Sub dgvWarehouse_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvWarehouse.KeyDown
        If e.KeyCode = Keys.Enter Then
            fillSerialGrid()
        End If
    End Sub

    Private Sub serialtxt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles serialtxt.TextChanged
        Me.serialSource.DefaultView.RowFilter = "serial_vc Like '" + modPublicMethod.CorrectLike(Me.serialtxt.Text).Replace("'", "''") + "%'"
    End Sub

#End Region

#Region "Methods"

    Private Sub FormLoad()

        'get visitor for  current user
        Dim visitor As ClassDALWarehouse = New ClassDALWarehouse(modPublicMethod.ConnectionString)
        visitor.BeginProc()
        Dim dt As DataTable = visitor.GetAllUserVisitorByUserID(ClassUserLoginDataAccess.ThisUser.UserID)
        visitor.EndProc()
        Me.visitorID = dt.Rows(0)("Visitor_ID")

        'fill statement grid 
        warehouse = New ClassDALWarehouseStatement(modPublicMethod.ConnectionString)
        warehouse.BeginProc()
        Me.statementSource = warehouse.GetAll(visitorID)
        warehouse.EndProc()
        Me.dgvStatements.AutoGenerateColumns = False
        Me.dgvStatements.DataSource = Me.statementSource
        Me.statementTypecb.SelectedIndex = 0

        'fill warehouse grid
        warehouse.BeginProc()
        Me.warehouseSource = warehouse.GetWareHouseState(visitorID)
        warehouse.EndProc()
        Me.dgvWarehouse.AutoGenerateColumns = False
        For Each row As DataRow In Me.warehouseSource.Rows
            If IsDBNull(row("totalcount")) Then
                row("totalcount") = 0
            End If
        Next
        Me.dgvWarehouse.DataSource = Me.warehouseSource

    End Sub

    Private Function getFilter()

        Dim filter As String = String.Empty
        If Not Me.statementTypecb.SelectedItem.ToString() = "تمام اسناد" Then
            filter = "statementtype Like '" + modPublicMethod.CorrectLike(Me.statementTypecb.SelectedItem.ToString()).Replace("'", "''") + "%'"
        End If

        If Not String.IsNullOrEmpty(Me.statementNotxt.Text) Then
            If Not String.IsNullOrEmpty(filter) Then
                filter += "and "
            End If
            filter += "statementno = " + modPublicMethod.CorrectLike(Me.statementNotxt.Text).Replace("'", "''")
        End If
        Return filter

    End Function

    Private Sub showStatementDetialsForm()
        Dim _frmWarehouseTransfer As New frmWarehouseTransfer(Integer.Parse(Me.dgvStatements.CurrentRow.Cells("warehousestatement_id").Value.ToString()))
        _frmWarehouseTransfer.ShowDialog()
    End Sub

    Private Sub fillSerialGrid()

        Dim goodID As Integer = Me.dgvWarehouse.CurrentRow.Cells("WSGood_ID").Value
        Me.warehouse.BeginProc()
        Me.serialSource = Me.warehouse.GetWarehouseSerialsState(goodID, Me.visitorID)
        Me.warehouse.EndProc()
        Me.dgvStatements.AutoGenerateColumns = False
        Me.dgvSerials.DataSource = Me.serialSource
        Me.serialtxt.Text = String.Empty

    End Sub

#End Region

    

End Class