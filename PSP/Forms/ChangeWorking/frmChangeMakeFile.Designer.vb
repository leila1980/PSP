<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeMakeFile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangeMakeFile))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbtAll = New System.Windows.Forms.RadioButton
        Me.rbtSelective = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtpTo = New FarsiLibrary.Win.Controls.FADatePicker
        Me.lblDateFrom = New System.Windows.Forms.Label
        Me.dtpFrom = New FarsiLibrary.Win.Controls.FADatePicker
        Me.lblDateTo = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.btnMakeFile = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.btnExportExcel = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtAll)
        Me.GroupBox1.Controls.Add(Me.rbtSelective)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(815, 51)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'rbtAll
        '
        Me.rbtAll.AutoSize = True
        Me.rbtAll.Location = New System.Drawing.Point(748, 22)
        Me.rbtAll.Name = "rbtAll"
        Me.rbtAll.Size = New System.Drawing.Size(46, 17)
        Me.rbtAll.TabIndex = 13
        Me.rbtAll.TabStop = True
        Me.rbtAll.Text = "همه"
        Me.rbtAll.UseVisualStyleBackColor = True
        '
        'rbtSelective
        '
        Me.rbtSelective.AutoSize = True
        Me.rbtSelective.Location = New System.Drawing.Point(376, 22)
        Me.rbtSelective.Name = "rbtSelective"
        Me.rbtSelective.Size = New System.Drawing.Size(59, 17)
        Me.rbtSelective.TabIndex = 12
        Me.rbtSelective.TabStop = True
        Me.rbtSelective.Text = "انتخابی"
        Me.rbtSelective.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtpTo)
        Me.GroupBox3.Controls.Add(Me.lblDateFrom)
        Me.GroupBox3.Controls.Add(Me.dtpFrom)
        Me.GroupBox3.Controls.Add(Me.lblDateTo)
        Me.GroupBox3.Controls.Add(Me.lblDate)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(354, 36)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(11, 10)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(120, 20)
        Me.dtpTo.TabIndex = 10
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(287, 13)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(21, 13)
        Me.lblDateFrom.TabIndex = 6
        Me.lblDateFrom.Text = "از :"
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(165, 11)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(120, 20)
        Me.dtpFrom.TabIndex = 9
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(136, 13)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(20, 13)
        Me.lblDateTo.TabIndex = 8
        Me.lblDateTo.Text = "تا :"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(314, 13)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(31, 13)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "تاریخ "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgv)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(815, 434)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(6, 16)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(803, 410)
        Me.dgv.TabIndex = 0
        '
        'btnMakeFile
        '
        Me.btnMakeFile.Image = CType(resources.GetObject("btnMakeFile.Image"), System.Drawing.Image)
        Me.btnMakeFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMakeFile.Name = "btnMakeFile"
        Me.btnMakeFile.Size = New System.Drawing.Size(70, 22)
        Me.btnMakeFile.Text = "تولید فایل"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMakeFile, Me.ToolStripSeparator1, Me.btnExportExcel})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(837, 25)
        Me.tsMain.TabIndex = 3
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(93, 22)
        Me.btnExportExcel.Text = "انتقال به Excel"
        '
        'frmChangeMakeFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 513)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.tsMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmChangeMakeFile"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تولید فایل تغییرات"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnMakeFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnExportExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpTo As FarsiLibrary.Win.Controls.FADatePicker
    Friend WithEvents dtpFrom As FarsiLibrary.Win.Controls.FADatePicker
    Friend WithEvents rbtAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSelective As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
