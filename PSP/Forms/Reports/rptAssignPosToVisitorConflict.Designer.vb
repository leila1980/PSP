<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrptAssignPosToVisitorConflict
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmrptAssignPosToVisitorConflict))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnPrint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tbcMain = New System.Windows.Forms.TabControl
        Me.tbpOperationalWithoutVisitor = New System.Windows.Forms.TabPage
        Me.dgvOperationalWithoutVisitor = New System.Windows.Forms.DataGridView
        Me.tbpConflict = New System.Windows.Forms.TabPage
        Me.dgvConflict = New System.Windows.Forms.DataGridView
        Me.tbpWithoutContract = New System.Windows.Forms.TabPage
        Me.dgvWithoutContract = New System.Windows.Forms.DataGridView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.tbpOperationalNotApproved = New System.Windows.Forms.TabPage
        Me.dgvOperationalNotApproved = New System.Windows.Forms.DataGridView
        Me.rtsSearch = New ReportSearchToolStrip
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbcMain.SuspendLayout()
        Me.tbpOperationalWithoutVisitor.SuspendLayout()
        CType(Me.dgvOperationalWithoutVisitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpConflict.SuspendLayout()
        CType(Me.dgvConflict, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpWithoutContract.SuspendLayout()
        CType(Me.dgvWithoutContract, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.tbpOperationalNotApproved.SuspendLayout()
        CType(Me.dgvOperationalNotApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportToExcel, Me.ToolStripSeparator1, Me.btnPrint, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1061, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(93, 22)
        Me.btnExportToExcel.Text = "انتقال به Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnPrint
        '
        Me.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(23, 22)
        Me.btnPrint.Text = "ToolStripButton1"
        Me.btnPrint.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.tbcMain)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1059, 563)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'tbcMain
        '
        Me.tbcMain.Controls.Add(Me.tbpOperationalWithoutVisitor)
        Me.tbcMain.Controls.Add(Me.tbpConflict)
        Me.tbcMain.Controls.Add(Me.tbpWithoutContract)
        Me.tbcMain.Controls.Add(Me.tbpOperationalNotApproved)
        Me.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcMain.Location = New System.Drawing.Point(3, 17)
        Me.tbcMain.Name = "tbcMain"
        Me.tbcMain.RightToLeftLayout = True
        Me.tbcMain.SelectedIndex = 0
        Me.tbcMain.Size = New System.Drawing.Size(1053, 543)
        Me.tbcMain.TabIndex = 2
        '
        'tbpOperationalWithoutVisitor
        '
        Me.tbpOperationalWithoutVisitor.Controls.Add(Me.dgvOperationalWithoutVisitor)
        Me.tbpOperationalWithoutVisitor.Location = New System.Drawing.Point(4, 22)
        Me.tbpOperationalWithoutVisitor.Name = "tbpOperationalWithoutVisitor"
        Me.tbpOperationalWithoutVisitor.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOperationalWithoutVisitor.Size = New System.Drawing.Size(1071, 530)
        Me.tbpOperationalWithoutVisitor.TabIndex = 0
        Me.tbpOperationalWithoutVisitor.Text = "پایانه های فعال تخصیص نیافته به بازاریاب"
        Me.tbpOperationalWithoutVisitor.UseVisualStyleBackColor = True
        '
        'dgvOperationalWithoutVisitor
        '
        Me.dgvOperationalWithoutVisitor.AllowUserToAddRows = False
        Me.dgvOperationalWithoutVisitor.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvOperationalWithoutVisitor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOperationalWithoutVisitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOperationalWithoutVisitor.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOperationalWithoutVisitor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOperationalWithoutVisitor.Location = New System.Drawing.Point(3, 3)
        Me.dgvOperationalWithoutVisitor.Name = "dgvOperationalWithoutVisitor"
        Me.dgvOperationalWithoutVisitor.ReadOnly = True
        Me.dgvOperationalWithoutVisitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperationalWithoutVisitor.Size = New System.Drawing.Size(1065, 524)
        Me.dgvOperationalWithoutVisitor.TabIndex = 0
        '
        'tbpConflict
        '
        Me.tbpConflict.Controls.Add(Me.dgvConflict)
        Me.tbpConflict.Location = New System.Drawing.Point(4, 22)
        Me.tbpConflict.Name = "tbpConflict"
        Me.tbpConflict.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpConflict.Size = New System.Drawing.Size(1071, 530)
        Me.tbpConflict.TabIndex = 1
        Me.tbpConflict.Text = "مغایرت در تخصیص"
        Me.tbpConflict.UseVisualStyleBackColor = True
        '
        'dgvConflict
        '
        Me.dgvConflict.AllowUserToAddRows = False
        Me.dgvConflict.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvConflict.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvConflict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvConflict.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvConflict.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConflict.Location = New System.Drawing.Point(3, 3)
        Me.dgvConflict.Name = "dgvConflict"
        Me.dgvConflict.ReadOnly = True
        Me.dgvConflict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConflict.Size = New System.Drawing.Size(1065, 524)
        Me.dgvConflict.TabIndex = 1
        '
        'tbpWithoutContract
        '
        Me.tbpWithoutContract.Controls.Add(Me.dgvWithoutContract)
        Me.tbpWithoutContract.Location = New System.Drawing.Point(4, 22)
        Me.tbpWithoutContract.Name = "tbpWithoutContract"
        Me.tbpWithoutContract.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpWithoutContract.Size = New System.Drawing.Size(1071, 530)
        Me.tbpWithoutContract.TabIndex = 2
        Me.tbpWithoutContract.Text = "پایانه های فعال تخصیص یافته بدون قرارداد"
        Me.tbpWithoutContract.UseVisualStyleBackColor = True
        '
        'dgvWithoutContract
        '
        Me.dgvWithoutContract.AllowUserToAddRows = False
        Me.dgvWithoutContract.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvWithoutContract.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvWithoutContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvWithoutContract.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvWithoutContract.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvWithoutContract.Location = New System.Drawing.Point(3, 3)
        Me.dgvWithoutContract.Name = "dgvWithoutContract"
        Me.dgvWithoutContract.ReadOnly = True
        Me.dgvWithoutContract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWithoutContract.Size = New System.Drawing.Size(1065, 524)
        Me.dgvWithoutContract.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 596)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1061, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(37, 17)
        Me.ToolStripStatusLabel1.Text = "تعداد :"
        '
        'lblCount
        '
        Me.lblCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(13, 17)
        Me.lblCount.Text = "  "
        '
        'tbpOperationalNotApproved
        '
        Me.tbpOperationalNotApproved.Controls.Add(Me.dgvOperationalNotApproved)
        Me.tbpOperationalNotApproved.Location = New System.Drawing.Point(4, 22)
        Me.tbpOperationalNotApproved.Name = "tbpOperationalNotApproved"
        Me.tbpOperationalNotApproved.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOperationalNotApproved.Size = New System.Drawing.Size(1045, 517)
        Me.tbpOperationalNotApproved.TabIndex = 3
        Me.tbpOperationalNotApproved.Text = "پایانه های عملیاتی تایید نشده "
        Me.tbpOperationalNotApproved.UseVisualStyleBackColor = True
        '
        'dgvOperationalNotApproved
        '
        Me.dgvOperationalNotApproved.AllowUserToAddRows = False
        Me.dgvOperationalNotApproved.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvOperationalNotApproved.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvOperationalNotApproved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOperationalNotApproved.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvOperationalNotApproved.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOperationalNotApproved.Location = New System.Drawing.Point(3, 3)
        Me.dgvOperationalNotApproved.Name = "dgvOperationalNotApproved"
        Me.dgvOperationalNotApproved.ReadOnly = True
        Me.dgvOperationalNotApproved.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperationalNotApproved.Size = New System.Drawing.Size(1039, 511)
        Me.dgvOperationalNotApproved.TabIndex = 3
        '
        'rtsSearch
        '
        Me.rtsSearch.btnExportExcelVisible = False
        Me.rtsSearch.btnPrintVisible = False
        Me.rtsSearch.btnShowVisible = False
        Me.rtsSearch.Location = New System.Drawing.Point(0, 0)
        Me.rtsSearch.Name = "rtsSearch"
        Me.rtsSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rtsSearch.Size = New System.Drawing.Size(425, 24)
        Me.rtsSearch.TabIndex = 8
        '
        'frmrptAssignPosToVisitorConflict
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 618)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rtsSearch)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmrptAssignPosToVisitorConflict"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش مغایرت تخصیص پز به بازاریاب"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.tbcMain.ResumeLayout(False)
        Me.tbpOperationalWithoutVisitor.ResumeLayout(False)
        CType(Me.dgvOperationalWithoutVisitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpConflict.ResumeLayout(False)
        CType(Me.dgvConflict, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpWithoutContract.ResumeLayout(False)
        CType(Me.dgvWithoutContract, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tbpOperationalNotApproved.ResumeLayout(False)
        CType(Me.dgvOperationalNotApproved, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents rtsSearch As ReportSearchToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbcMain As System.Windows.Forms.TabControl
    Friend WithEvents tbpOperationalWithoutVisitor As System.Windows.Forms.TabPage
    Friend WithEvents dgvOperationalWithoutVisitor As System.Windows.Forms.DataGridView
    Friend WithEvents tbpConflict As System.Windows.Forms.TabPage
    Friend WithEvents dgvConflict As System.Windows.Forms.DataGridView
    Friend WithEvents tbpWithoutContract As System.Windows.Forms.TabPage
    Friend WithEvents dgvWithoutContract As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbpOperationalNotApproved As System.Windows.Forms.TabPage
    Friend WithEvents dgvOperationalNotApproved As System.Windows.Forms.DataGridView
End Class
