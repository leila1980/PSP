<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaseMakeFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaseMakeFile))
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.btnMakeFile = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnView = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtNumberFrom = New AMS.TextBox.NumericTextBox
        Me.txtNumberTo = New AMS.TextBox.NumericTextBox
        Me.txtDateTo = New DateTextBox.DateTextBox
        Me.txtDateFrom = New DateTextBox.DateTextBox
        Me.lblNumber = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblNumberTo = New System.Windows.Forms.Label
        Me.lblNumberFrom = New System.Windows.Forms.Label
        Me.lblDateTo = New System.Windows.Forms.Label
        Me.lblDateFrom = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.tsMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMakeFile, Me.ToolStripSeparator1, Me.btnView, Me.ToolStripSeparator2, Me.btnExportToExcel})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(839, 25)
        Me.tsMain.TabIndex = 0
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
        'btnView
        '
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(67, 22)
        Me.btnView.Text = "مشاهده"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(93, 22)
        Me.btnExportToExcel.Text = "انتقال به Excel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNumberFrom)
        Me.GroupBox1.Controls.Add(Me.txtNumberTo)
        Me.GroupBox1.Controls.Add(Me.txtDateTo)
        Me.GroupBox1.Controls.Add(Me.txtDateFrom)
        Me.GroupBox1.Controls.Add(Me.lblNumber)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.lblNumberTo)
        Me.GroupBox1.Controls.Add(Me.lblNumberFrom)
        Me.GroupBox1.Controls.Add(Me.lblDateTo)
        Me.GroupBox1.Controls.Add(Me.lblDateFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(815, 51)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txtNumberFrom
        '
        Me.txtNumberFrom.AllowNegative = True
        Me.txtNumberFrom.DigitsInGroup = 0
        Me.txtNumberFrom.Flags = 0
        Me.txtNumberFrom.Location = New System.Drawing.Point(549, 20)
        Me.txtNumberFrom.MaxDecimalPlaces = 4
        Me.txtNumberFrom.MaxWholeDigits = 9
        Me.txtNumberFrom.Name = "txtNumberFrom"
        Me.txtNumberFrom.Prefix = ""
        Me.txtNumberFrom.RangeMax = 1.7976931348623157E+308
        Me.txtNumberFrom.RangeMin = -1.7976931348623157E+308
        Me.txtNumberFrom.Size = New System.Drawing.Size(71, 21)
        Me.txtNumberFrom.TabIndex = 2
        '
        'txtNumberTo
        '
        Me.txtNumberTo.AllowNegative = True
        Me.txtNumberTo.DigitsInGroup = 0
        Me.txtNumberTo.Flags = 0
        Me.txtNumberTo.Location = New System.Drawing.Point(452, 20)
        Me.txtNumberTo.MaxDecimalPlaces = 4
        Me.txtNumberTo.MaxWholeDigits = 9
        Me.txtNumberTo.Name = "txtNumberTo"
        Me.txtNumberTo.Prefix = ""
        Me.txtNumberTo.RangeMax = 1.7976931348623157E+308
        Me.txtNumberTo.RangeMin = -1.7976931348623157E+308
        Me.txtNumberTo.Size = New System.Drawing.Size(71, 21)
        Me.txtNumberTo.TabIndex = 4
        '
        'txtDateTo
        '
        Me.txtDateTo.AutoSize = True
        Me.txtDateTo.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtDateTo.DateBackColor = System.Drawing.SystemColors.Window
        Me.txtDateTo.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDateTo.DateReadOnly = False
        Me.txtDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDateTo.Location = New System.Drawing.Point(127, 20)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDateTo.Size = New System.Drawing.Size(87, 20)
        Me.txtDateTo.TabIndex = 9
        Me.txtDateTo.Value = ""
        '
        'txtDateFrom
        '
        Me.txtDateFrom.AutoSize = True
        Me.txtDateFrom.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtDateFrom.DateBackColor = System.Drawing.SystemColors.Window
        Me.txtDateFrom.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDateFrom.DateReadOnly = False
        Me.txtDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDateFrom.Location = New System.Drawing.Point(246, 20)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDateFrom.Size = New System.Drawing.Size(87, 20)
        Me.txtDateFrom.TabIndex = 7
        Me.txtDateFrom.Value = ""
        '
        'lblNumber
        '
        Me.lblNumber.AutoSize = True
        Me.lblNumber.Location = New System.Drawing.Point(645, 24)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(40, 13)
        Me.lblNumber.TabIndex = 0
        Me.lblNumber.Text = "شماره "
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(362, 22)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(31, 13)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "تاریخ "
        '
        'lblNumberTo
        '
        Me.lblNumberTo.AutoSize = True
        Me.lblNumberTo.Location = New System.Drawing.Point(527, 23)
        Me.lblNumberTo.Name = "lblNumberTo"
        Me.lblNumberTo.Size = New System.Drawing.Size(20, 13)
        Me.lblNumberTo.TabIndex = 3
        Me.lblNumberTo.Text = "تا :"
        '
        'lblNumberFrom
        '
        Me.lblNumberFrom.AutoSize = True
        Me.lblNumberFrom.Location = New System.Drawing.Point(626, 24)
        Me.lblNumberFrom.Name = "lblNumberFrom"
        Me.lblNumberFrom.Size = New System.Drawing.Size(21, 13)
        Me.lblNumberFrom.TabIndex = 1
        Me.lblNumberFrom.Text = "از :"
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Location = New System.Drawing.Point(216, 22)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(20, 13)
        Me.lblDateTo.TabIndex = 8
        Me.lblDateTo.Text = "تا :"
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Location = New System.Drawing.Point(335, 22)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(21, 13)
        Me.lblDateFrom.TabIndex = 6
        Me.lblDateFrom.Text = "از :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(815, 434)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 16)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(803, 410)
        Me.DataGridView1.TabIndex = 0
        '
        'frmBaseMakeFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(839, 526)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBaseMakeFile"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnMakeFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDateTo As DateTextBox.DateTextBox
    Friend WithEvents txtDateFrom As DateTextBox.DateTextBox
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblNumberTo As System.Windows.Forms.Label
    Friend WithEvents lblNumberFrom As System.Windows.Forms.Label
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents txtNumberFrom As AMS.TextBox.NumericTextBox
    Friend WithEvents txtNumberTo As AMS.TextBox.NumericTextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnView As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
End Class
