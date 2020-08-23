<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReqImgShow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReqImgShow))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvReqImg = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkConfirm = New System.Windows.Forms.CheckBox()
        Me.txtImgDescription = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ColImgPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColImg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ColDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colconfirm = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgvReqImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'dgvReqImg
        '
        Me.dgvReqImg.AllowUserToAddRows = False
        Me.dgvReqImg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReqImg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColImgPath, Me.ColImg, Me.ColDesc, Me.Colconfirm})
        Me.dgvReqImg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReqImg.Location = New System.Drawing.Point(3, 17)
        Me.dgvReqImg.Name = "dgvReqImg"
        Me.dgvReqImg.RowTemplate.Height = 100
        Me.dgvReqImg.Size = New System.Drawing.Size(783, 263)
        Me.dgvReqImg.TabIndex = 4
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(789, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(43, 22)
        Me.btnSave.Text = "ثبت"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 22)
        Me.btnCancel.Text = "انصراف"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkConfirm)
        Me.GroupBox1.Controls.Add(Me.txtImgDescription)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(789, 54)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'chkConfirm
        '
        Me.chkConfirm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkConfirm.AutoSize = True
        Me.chkConfirm.Location = New System.Drawing.Point(102, 21)
        Me.chkConfirm.Name = "chkConfirm"
        Me.chkConfirm.Size = New System.Drawing.Size(47, 17)
        Me.chkConfirm.TabIndex = 4
        Me.chkConfirm.Text = "تایید"
        Me.chkConfirm.UseVisualStyleBackColor = True
        '
        'txtImgDescription
        '
        Me.txtImgDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImgDescription.Location = New System.Drawing.Point(155, 20)
        Me.txtImgDescription.MaxLength = 20
        Me.txtImgDescription.Name = "txtImgDescription"
        Me.txtImgDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtImgDescription.Size = New System.Drawing.Size(569, 21)
        Me.txtImgDescription.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(727, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "توضیحات:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvReqImg)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(789, 283)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'ColImgPath
        '
        Me.ColImgPath.DataPropertyName = "ColImgPath"
        Me.ColImgPath.HeaderText = "مسیرعکس"
        Me.ColImgPath.Name = "ColImgPath"
        Me.ColImgPath.Visible = False
        '
        'ColImg
        '
        Me.ColImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColImg.DataPropertyName = "ColImg"
        Me.ColImg.HeaderText = "عکس درخواست"
        Me.ColImg.Name = "ColImg"
        Me.ColImg.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColDesc
        '
        Me.ColDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColDesc.DataPropertyName = "ColDesc"
        Me.ColDesc.HeaderText = "توضیحات"
        Me.ColDesc.Name = "ColDesc"
        '
        'Colconfirm
        '
        Me.Colconfirm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Colconfirm.DataPropertyName = "Colconfirm"
        Me.Colconfirm.HeaderText = "تایید"
        Me.Colconfirm.Name = "Colconfirm"
        '
        'frmReqImgShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 362)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmReqImgShow"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نمایش عکس های درخواست"
        CType(Me.dgvReqImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents dgvReqImg As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtImgDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkConfirm As System.Windows.Forms.CheckBox
    Friend WithEvents ColImgPath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColImg As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ColDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colconfirm As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
