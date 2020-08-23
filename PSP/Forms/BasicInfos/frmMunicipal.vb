Public Class frmMunicipal
    Private da As New Dal(ConnectionString)
    Private Sub frmMunicipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.SetFavorite()
    End Sub
    Private Sub frmCategories_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'SetPermission(Me, ClassUserLoginDataAccess.ThisUser.UserID, Me.Name)
            tvCategories.ContextMenuStrip = cmnuAddChildren
            FillTreeView()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
            Me.Close()
        End Try
    End Sub

    Private Sub FillTreeView()
        Try
            Dim dt As New DataTable
            dt = Me.da.GetMunicipalArea()

            Dim Node As New TreeNode

            Dim drRoot() As DataRow = dt.Select("ParentID IS NULL")

            With tvCategories

                .BeginUpdate()

                .Nodes.Clear()

                For i As Integer = drRoot.GetLowerBound(0) To drRoot.GetUpperBound(0)
                    Node = New TreeNode
                    Node.Name = drRoot(i).Item("MunicipalareaID")
                    Node.Text = drRoot(i).Item("Name_nvc")
                    Node.Tag = "Root"

                    .Nodes.Add(Node)
                    Node.Expand()

                    AddChildNodes(dt, drRoot(i).Item("MunicipalAreaID"), Node)
                Next

                .EndUpdate()

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddChildNodes(ByRef dtNodes As DataTable, ByVal NodeID As Integer, ByVal Nodes As TreeNode)
        Dim drChilds() As DataRow = dtNodes.Select("ParentID=" + NodeID.ToString)
        Dim Child As New TreeNode

        For i As Integer = drChilds.GetLowerBound(0) To drChilds.GetUpperBound(0)
            Child = New TreeNode
            Child.Name = drChilds(i).Item("MunicipalAreaID")
            Child.Text = drChilds(i).Item("Name_nvc")
            Child.Tag = NodeID.ToString
            Nodes.Nodes.Add(Child)
            Nodes.Expand()
            If ChildNodeExists(dtNodes, drChilds(i).Item("MunicipalAreaID")) Then
                AddChildNodes(dtNodes, drChilds(i).Item("MunicipalAreaID"), Child)
            End If
        Next
    End Sub

    Private Function ChildNodeExists(ByRef dtNodes As DataTable, ByVal NodeID As Integer) As Boolean
        Dim dr() As DataRow = dtNodes.Select("ParentID=" + NodeID.ToString)
        If dr.Length = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnAddNewCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewCategory.Click
        Try
            Dim strMunicipal As String = frmInputBox.ShowForm("·ÿ›« „Ê÷Ê⁄ —« Ê«—œ ò‰Ìœ.")
            If strMunicipal = Nothing Then
                Exit Sub
            End If
            Dim Municipal As New Dal.MunicipalAreaTemplate
            Municipal.ParentID = Nothing
            Municipal.Name_nvc = strMunicipal
            da.BeginProc()
            da.Insert(Municipal)
            FillTreeView()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            da.EndProc()
        End Try
    End Sub

    Private Sub btnAddNewChild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewChild.Click
        Try
            With tvCategories
                If .SelectedNode Is Nothing Then
                    ShowErrorMessage("·ÿ›« „Ê—œÌ —« «‰ Œ«» ò‰Ìœ.")
                    Exit Sub
                End If

                Dim strMunicipal As String = frmInputBox.ShowForm("·ÿ›« ‰«„ “Ì— ‘«ŒÂùÌ " & .SelectedNode.Text & " —« Ê«—œ ò‰Ìœ.")
                If strMunicipal = Nothing Then
                    Exit Sub
                End If

                Dim Municipal As New Dal.MunicipalAreaTemplate
                Municipal.ParentID = tvCategories.SelectedNode.Name
                Municipal.Name_nvc = strMunicipal
                da.BeginProc()
                da.Insert(Municipal)
                FillTreeView()
            End With
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            da.EndProc()
        End Try
    End Sub

    Private Sub mnuAddChildren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddChildren.Click
        Me.btnAddNewChild.PerformClick()
    End Sub

    Private Sub tvCategories_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvCategories.MouseClick
        tvCategories.SelectedNode = tvCategories.GetNodeAt(e.X, e.Y)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmnuAddChildren_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmnuAddChildren.Opening
        If tvCategories.SelectedNode IsNot Nothing Then
            mnuDeleteNode.Text = "Õ–› ò—œ‰ " & tvCategories.SelectedNode.Text
            mnuAddChildren.Text = "«÷«›Â ò—œ‰ “Ì— ‘«ŒÂ »Â " & tvCategories.SelectedNode.Text
            mnuEditNode.Text = "ÊÌ—«Ì‘ " & tvCategories.SelectedNode.Text
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub mnuDeleteNode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDeleteNode.Click
        Try
            da.BeginProc()
            If tvCategories.SelectedNode Is Nothing Then
                ShowErrorMessage("·ÿ›« „Ê—œÌ —« «‰ Œ«» ò‰Ìœ.")
                Exit Sub
            End If

            Dim strMSG As String = "¬Ì« „«Ì· »Â Õ–› " + tvCategories.SelectedNode.Text + " " + "Â” Ìœø" + ControlChars.NewLine + _
                                    "»« Õ–› ò—œ‰ «Ì‰ „Ê—œ Â„Â “Ì— ‘«ŒÂùÂ«Ì „—»ÊÿÂ ‰Ì“ Õ–› ŒÊ«Â‰œ ‘œ Ê «Ì‰ «ÿ·«⁄«  €Ì—ﬁ«»· »«“ê‘  „Ìù»«‘œ." + ControlChars.NewLine + _
                                    "¬Ì« „«Ì· »Â «œ«„Â Â” Ìœø"

            If ShowConfirmDeleteMessage(strMSG) = False Then
                Exit Sub
            End If

            PostOrder(tvCategories.SelectedNode)

            FillTreeView()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            Me.da.EndProc()
        End Try
    End Sub

    Private Sub PostOrder(ByVal Node As TreeNode)
        Try
            For Each n As TreeNode In Node.Nodes
                PostOrder(n)
            Next

            VisitNode(Node)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VisitNode(ByVal Node As TreeNode)
        Try
            Dim Municipal As New Dal.MunicipalAreaTemplate
            Municipal.MunicipalAreaId = Node.Name
            Me.da.Delete(Municipal)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub mnuEditNode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEditNode.Click
        Try
            If tvCategories.SelectedNode Is Nothing Then
                ShowErrorMessage("·ÿ›« „Ê—œÌ —« «‰ Œ«» ò‰Ìœ.")
                Exit Sub
            End If

            Dim strMunicipal As String = frmInputBox.ShowForm("·ÿ›« ‰«„ ÃœÌœ  “Ì— ‘«ŒÂùÌ " & tvCategories.SelectedNode.Text & " —« Ê«—œ ò‰Ìœ.", , tvCategories.SelectedNode.Text)
            If strMunicipal = Nothing Then
                Exit Sub
            End If

            da.BeginProc()
            Dim Municipal As New Dal.MunicipalAreaTemplate
            Municipal.MunicipalAreaId = CType(tvCategories.SelectedNode.Name, Integer)
            Municipal.Name_nvc = strMunicipal
            da.Update(Municipal)
            FillTreeView()
        Catch ex As Exception
            ShowErrorMessage(ex.Message)
        Finally
            da.EndProc()
        End Try
    End Sub

    Private Sub frmMunicipal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ClassBLLFormHistory.InsertToHistory(Me)
    End Sub
End Class