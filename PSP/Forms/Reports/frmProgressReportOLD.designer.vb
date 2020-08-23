<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgressReportOLD
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgressReportOLD))
        Me.dgvReportProgress = New System.Windows.Forms.DataGridView
        Me.colStateName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colActivePos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUpdatedTerminal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblActivePos = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtActivePos = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtUpdateTerminal = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.cmbTask = New System.Windows.Forms.ToolStripComboBox
        CType(Me.dgvReportProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvReportProgress
        '
        Me.dgvReportProgress.AllowUserToAddRows = False
        Me.dgvReportProgress.AllowUserToDeleteRows = False
        Me.dgvReportProgress.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvReportProgress.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReportProgress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReportProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportProgress.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStateName, Me.colActivePos, Me.colUpdatedTerminal})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReportProgress.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReportProgress.Location = New System.Drawing.Point(0, 28)
        Me.dgvReportProgress.MultiSelect = False
        Me.dgvReportProgress.Name = "dgvReportProgress"
        Me.dgvReportProgress.ReadOnly = True
        Me.dgvReportProgress.RowHeadersVisible = False
        Me.dgvReportProgress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReportProgress.Size = New System.Drawing.Size(749, 372)
        Me.dgvReportProgress.TabIndex = 13
        '
        'colStateName
        '
        Me.colStateName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colStateName.DataPropertyName = "Name_nvc"
        Me.colStateName.HeaderText = "نام استان"
        Me.colStateName.Name = "colStateName"
        Me.colStateName.ReadOnly = True
        '
        'colActivePos
        '
        Me.colActivePos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colActivePos.DataPropertyName = "ActivePos"
        Me.colActivePos.HeaderText = "تعداد پزهای فعال"
        Me.colActivePos.Name = "colActivePos"
        Me.colActivePos.ReadOnly = True
        '
        'colUpdatedTerminal
        '
        Me.colUpdatedTerminal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colUpdatedTerminal.DataPropertyName = "UpdatedTerminals"
        Me.colUpdatedTerminal.HeaderText = "تعداد ترمینالهای بروزرسانی شده"
        Me.colUpdatedTerminal.Name = "colUpdatedTerminal"
        Me.colUpdatedTerminal.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblActivePos, Me.txtActivePos, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.txtUpdateTerminal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 403)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(749, 22)
        Me.StatusStrip1.TabIndex = 14
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblActivePos
        '
        Me.lblActivePos.Name = "lblActivePos"
        Me.lblActivePos.Size = New System.Drawing.Size(103, 17)
        Me.lblActivePos.Text = "جمع کل پزهای فعال:"
        '
        'txtActivePos
        '
        Me.txtActivePos.Name = "txtActivePos"
        Me.txtActivePos.Size = New System.Drawing.Size(13, 17)
        Me.txtActivePos.Text = "0"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(111, 17)
        Me.ToolStripStatusLabel2.Text = "جمع پزهای TMS شده:"
        '
        'txtUpdateTerminal
        '
        Me.txtUpdateTerminal.Name = "txtUpdateTerminal"
        Me.txtUpdateTerminal.Size = New System.Drawing.Size(13, 17)
        Me.txtUpdateTerminal.Text = "0"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.cmbTask})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(749, 25)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ارسال به اکسل"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripLabel1.Text = "نام Task:"
        '
        'cmbTask
        '
        Me.cmbTask.Name = "cmbTask"
        Me.cmbTask.Size = New System.Drawing.Size(350, 25)
        '
        'frmProgressReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 425)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvReportProgress)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmProgressReport"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "گزارش پیشرفت TMS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvReportProgress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvReportProgress As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblActivePos As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtActivePos As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtUpdateTerminal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbTask As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents colStateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActivePos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUpdatedTerminal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
