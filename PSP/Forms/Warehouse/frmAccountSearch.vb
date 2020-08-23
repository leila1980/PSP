Imports System.Data
Public Class frmAccountSearch
    Private dtAccount As New DataTable
    Private _AccountId As String = ""
    Private _AccountName As String = ""

    Public ReadOnly Property AccountID() As String
        Get
            Return Me._AccountId
        End Get
    End Property

    Public ReadOnly Property AccountName() As String
        Get
            Return Me._AccountName
        End Get
    End Property

    Private Sub frmAccountSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim visitor As New ClassDALVisitor(modPublicMethod.ConnectionString)
            visitor.BeginProc()
            dtAccount = visitor.GetAll()
            visitor.EndProc()
            Me.dgvAccount.AutoGenerateColumns = False
            Me.dgvAccount.DataSource = dtAccount
        Catch ex As Exception
            modPublicMethod.ShowErrorMessage(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub Choose()
        Try
            Me._AccountId = Me.dgvAccount.CurrentRow.Cells("colAccountID").Value
            Me._AccountName = Me.dgvAccount.CurrentRow.Cells("colName_vc").Value
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvAccount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvAccount.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Choose()
        End If
    End Sub

    Private Sub dgvAccount_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvAccount.MouseDoubleClick
        Me.Choose()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Select Case Me.cmbSearch.SelectedIndex
            Case 0
                'Me.dtAccount.DefaultView.RowFilter = "VisitorIDStr Like ' " + modPublicMethod.CorrectLike(Me.txtSearch.Text).Replace("'", "''") + "%'"
                Me.dtAccount.DefaultView.RowFilter = "visitorid = " + modPublicMethod.CorrectLike(Me.txtSearch.Text).Replace("'", "''")
            Case 1
                Me.dtAccount.DefaultView.RowFilter = "FullName_nvc Like ' " + modPublicMethod.CorrectLike(Me.txtSearch.Text).Replace("'", "''") + "%'"
        End Select
    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearch.SelectedIndexChanged
        Me.txtSearch.Text = ""
    End Sub

    Private Sub frmAccountSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub

End Class