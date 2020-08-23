<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSwitchPaymentMethodType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSwitchPaymentMethodType))
        Me.dgvCardAcceptor = New System.Windows.Forms.DataGridView
        Me.colChk = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.cboPaymentMethodType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.btnSelectAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSelectNone = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.lblCount = New System.Windows.Forms.ToolStripLabel
        Me.btnAssign = New System.Windows.Forms.Button
        Me.lblImportType = New System.Windows.Forms.Label
        Me.cboImportType = New System.Windows.Forms.ComboBox
        Me.btnImport = New System.Windows.Forms.Button
        Me.ReportSearchToolStrip1 = New ReportSearchToolStrip
        CType(Me.dgvCardAcceptor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCardAcceptor
        '
        Me.dgvCardAcceptor.AllowUserToAddRows = False
        Me.dgvCardAcceptor.AllowUserToDeleteRows = False
        Me.dgvCardAcceptor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCardAcceptor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCardAcceptor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colChk})
        Me.dgvCardAcceptor.Location = New System.Drawing.Point(5, 16)
        Me.dgvCardAcceptor.Name = "dgvCardAcceptor"
        Me.dgvCardAcceptor.RowHeadersVisible = False
        Me.dgvCardAcceptor.Size = New System.Drawing.Size(860, 457)
        Me.dgvCardAcceptor.TabIndex = 0
        '
        'colChk
        '
        Me.colChk.HeaderText = ""
        Me.colChk.Name = "colChk"
        Me.colChk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colChk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colChk.Width = 30
        '
        'cboPaymentMethodType
        '
        Me.cboPaymentMethodType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPaymentMethodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentMethodType.FormattingEnabled = True
        Me.cboPaymentMethodType.Location = New System.Drawing.Point(578, 35)
        Me.cboPaymentMethodType.Name = "cboPaymentMethodType"
        Me.cboPaymentMethodType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPaymentMethodType.Size = New System.Drawing.Size(222, 21)
        Me.cboPaymentMethodType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(803, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "نوع پرداخت"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvCardAcceptor)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 487)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "پذیرندگان"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSelectAll, Me.ToolStripSeparator3, Me.btnSelectNone, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.lblCount})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 563)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(889, 25)
        Me.ToolStrip2.TabIndex = 7
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSelectAll.Image = CType(resources.GetObject("btnSelectAll.Image"), System.Drawing.Image)
        Me.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(64, 22)
        Me.btnSelectAll.Text = "انتخاب همه"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnSelectNone
        '
        Me.btnSelectNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSelectNone.Image = CType(resources.GetObject("btnSelectNone.Image"), System.Drawing.Image)
        Me.btnSelectNone.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectNone.Name = "btnSelectNone"
        Me.btnSelectNone.Size = New System.Drawing.Size(60, 22)
        Me.btnSelectNone.Text = "لغو انتخابها"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel1.Text = "تعداد کل :"
        '
        'lblCount
        '
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 22)
        '
        'btnAssign
        '
        Me.btnAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssign.Location = New System.Drawing.Point(377, 35)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(193, 23)
        Me.btnAssign.TabIndex = 9
        Me.btnAssign.Text = "بروزرسانی نوع پرداخت در سوئیچ"
        Me.btnAssign.UseVisualStyleBackColor = True
        '
        'lblImportType
        '
        Me.lblImportType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImportType.AutoSize = True
        Me.lblImportType.Location = New System.Drawing.Point(262, 36)
        Me.lblImportType.Name = "lblImportType"
        Me.lblImportType.Size = New System.Drawing.Size(80, 13)
        Me.lblImportType.TabIndex = 13
        Me.lblImportType.Text = "نوع فایل ورودی:"
        '
        'cboImportType
        '
        Me.cboImportType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboImportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImportType.FormattingEnabled = True
        Me.cboImportType.Items.AddRange(New Object() {"پایانه", "پذیرنده"})
        Me.cboImportType.Location = New System.Drawing.Point(142, 34)
        Me.cboImportType.Name = "cboImportType"
        Me.cboImportType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboImportType.Size = New System.Drawing.Size(114, 21)
        Me.cboImportType.TabIndex = 14
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(67, 33)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(70, 23)
        Me.btnImport.TabIndex = 15
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'ReportSearchToolStrip1
        '
        Me.ReportSearchToolStrip1.btnExportExcelVisible = True
        Me.ReportSearchToolStrip1.btnPrintVisible = True
        Me.ReportSearchToolStrip1.btnShowVisible = False
        Me.ReportSearchToolStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ReportSearchToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ReportSearchToolStrip1.Name = "ReportSearchToolStrip1"
        Me.ReportSearchToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ReportSearchToolStrip1.Size = New System.Drawing.Size(889, 24)
        Me.ReportSearchToolStrip1.TabIndex = 8
        '
        'frmSwitchPaymentMethodType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 588)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.cboImportType)
        Me.Controls.Add(Me.lblImportType)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.ReportSearchToolStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPaymentMethodType)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "frmSwitchPaymentMethodType"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بروزرسانی نوع پرداخت"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvCardAcceptor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCardAcceptor As System.Windows.Forms.DataGridView
    Friend WithEvents cboPaymentMethodType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents colChk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSelectAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSelectNone As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ReportSearchToolStrip1 As ReportSearchToolStrip
    Friend WithEvents btnAssign As System.Windows.Forms.Button
    Friend WithEvents lblImportType As System.Windows.Forms.Label
    Friend WithEvents cboImportType As System.Windows.Forms.ComboBox
    Friend WithEvents btnImport As System.Windows.Forms.Button
End Class
