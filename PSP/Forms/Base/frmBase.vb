Public Class frmBase
    Private _CurrentState As State = State.VIEW

    Protected Enum State
        ADD
        EDIT
        VIEW
        Load
    End Enum

    Protected ReadOnly Property CurrentState() As State
        Get
            Return Me._CurrentState
        End Get
    End Property

    Public Overridable Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    End Sub

    Public Overridable Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
    End Sub

    Public Overridable Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    End Sub

    Public Overridable Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    End Sub

    Public Overridable Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    End Sub

    Public Overridable Sub nudNumber_bint_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudNumber_bint.ValueChanged
    End Sub

    Public Overridable Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click
    End Sub

    Public Overridable Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
    End Sub

    Protected Sub GotoState(ByVal myState As State)
        Select Case myState
            Case State.ADD
                Me.btnDel.Enabled = True
                Me.btnList.Enabled = True
                Me.btnAdd.Enabled = False
                Me.txtSaveDate_vc.Enabled = True
                Me.txtDescription_nvc.Enabled = True
                Me.btnDelete.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnSave.Enabled = True
                Me.btnCancel.Enabled = True
                Me.btnPrint.Enabled = False
                Me.nudNumber_bint.Enabled = False
                Me.txtSaveDate_vc.Focus()
                Me._CurrentState = State.ADD

            Case State.EDIT
                Me.btnDel.Enabled = True
                Me.btnList.Enabled = True
                Me.nudNumber_bint.Enabled = False
                Me.txtSaveDate_vc.Enabled = True
                Me.txtDescription_nvc.Enabled = True
                Me.btnAdd.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnSave.Enabled = True
                Me.btnCancel.Enabled = True
                Me.btnPrint.Enabled = False
                Me.txtSaveDate_vc.Focus()
                Me._CurrentState = State.EDIT

            Case State.VIEW
                Me.btnDel.Enabled = False
                Me.btnList.Enabled = False
                Me.nudNumber_bint.Enabled = True
                Me.txtSaveDate_vc.Enabled = False
                Me.txtDescription_nvc.Enabled = False
                Me.btnAdd.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnEdit.Enabled = True
                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
                Me.btnPrint.Enabled = True
                Me.nudNumber_bint.Focus()
                Me._CurrentState = State.VIEW

            Case State.Load
                Me.btnDel.Enabled = False
                Me.btnList.Enabled = False
                Me.nudNumber_bint.Enabled = False
                Me.txtSaveDate_vc.Enabled = False
                Me.txtDescription_nvc.Enabled = False
                Me.btnAdd.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
                Me.btnPrint.Enabled = False
                Me.nudNumber_bint.Focus()
                Me._CurrentState = State.Load
        End Select
    End Sub

    Public Overridable Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        Try
            Dim frm As New SaveFileDialog
            frm.Filter = "Office 2007 Excel File (*.xlsx)|*.xlsx|Office 2003 Excel File (*.xls)|*.xls"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim clsExcel As New ClassExcel(frm.FileName)
                clsExcel.Write(Me.DataGridView1)
            End If

        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        End Try
    End Sub

   
    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim b As SolidBrush = New SolidBrush(DataGridView1.RowHeadersDefaultCellStyle.ForeColor)
        If e.RowBounds.Location.X = 1 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, DataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.DataGridView1.Width - 30, e.RowBounds.Location.Y + 4)
        ElseIf e.RowBounds.Location.X = 18 Then
            e.Graphics.DrawString((e.RowIndex + 1).ToString, DataGridView1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + Me.DataGridView1.Width - 45, e.RowBounds.Location.Y + 4)
        End If
    End Sub

    Private Sub frmBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class