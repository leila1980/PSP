<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitorTransactions
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisitorTransactions))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblRowCount = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ErrPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.VisitorTransactionsTabControl = New System.Windows.Forms.TabControl
        Me.VisitorTabPage = New System.Windows.Forms.TabPage
        Me.dgvVisitors = New System.Windows.Forms.DataGridView
        Me.colVisitorID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFullName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colContractDate_vc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionsTabPage = New System.Windows.Forms.TabPage
        Me.dgvTransactions = New System.Windows.Forms.DataGridView
        Me.DsReport1 = New DSReport
        Me.rucDate = New ReportUserControl_DateInterval
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.GroupBox4.SuspendLayout()
        CType(Me.ErrPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.VisitorTransactionsTabControl.SuspendLayout()
        Me.VisitorTabPage.SuspendLayout()
        CType(Me.dgvVisitors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TransactionsTabPage.SuspendLayout()
        CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsReport1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRowCount)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(-408, 31)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(135, 31)
        Me.GroupBox4.TabIndex = 41
        Me.GroupBox4.TabStop = False
        '
        'lblRowCount
        '
        Me.lblRowCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRowCount.Location = New System.Drawing.Point(15, 7)
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.Size = New System.Drawing.Size(75, 13)
        Me.lblRowCount.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(96, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 14)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "تعداد:"
        '
        'ErrPro
        '
        Me.ErrPro.ContainerControl = Me
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(93, 22)
        Me.btnExportToExcel.Text = "انتقال به Excel"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportToExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(733, 25)
        Me.ToolStrip1.TabIndex = 38
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'VisitorTransactionsTabControl
        '
        Me.VisitorTransactionsTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VisitorTransactionsTabControl.Controls.Add(Me.VisitorTabPage)
        Me.VisitorTransactionsTabControl.Controls.Add(Me.TransactionsTabPage)
        Me.VisitorTransactionsTabControl.Location = New System.Drawing.Point(0, 133)
        Me.VisitorTransactionsTabControl.Name = "VisitorTransactionsTabControl"
        Me.VisitorTransactionsTabControl.RightToLeftLayout = True
        Me.VisitorTransactionsTabControl.SelectedIndex = 0
        Me.VisitorTransactionsTabControl.Size = New System.Drawing.Size(733, 398)
        Me.VisitorTransactionsTabControl.TabIndex = 42
        '
        'VisitorTabPage
        '
        Me.VisitorTabPage.Controls.Add(Me.dgvVisitors)
        Me.VisitorTabPage.Location = New System.Drawing.Point(4, 23)
        Me.VisitorTabPage.Name = "VisitorTabPage"
        Me.VisitorTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.VisitorTabPage.Size = New System.Drawing.Size(725, 371)
        Me.VisitorTabPage.TabIndex = 0
        Me.VisitorTabPage.Text = "لیست نماینده ها"
        Me.VisitorTabPage.UseVisualStyleBackColor = True
        '
        'dgvVisitors
        '
        Me.dgvVisitors.AllowUserToAddRows = False
        Me.dgvVisitors.AllowUserToDeleteRows = False
        Me.dgvVisitors.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvVisitors.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVisitors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVisitors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVisitorID, Me.colFullName_nvc, Me.colContractDate_vc})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVisitors.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVisitors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVisitors.Location = New System.Drawing.Point(3, 3)
        Me.dgvVisitors.MultiSelect = False
        Me.dgvVisitors.Name = "dgvVisitors"
        Me.dgvVisitors.ReadOnly = True
        Me.dgvVisitors.RowHeadersVisible = False
        Me.dgvVisitors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVisitors.Size = New System.Drawing.Size(719, 365)
        Me.dgvVisitors.TabIndex = 14
        '
        'colVisitorID
        '
        Me.colVisitorID.DataPropertyName = "VisitorID"
        Me.colVisitorID.HeaderText = "شناسه نماینده"
        Me.colVisitorID.Name = "colVisitorID"
        Me.colVisitorID.ReadOnly = True
        '
        'colFullName_nvc
        '
        Me.colFullName_nvc.DataPropertyName = "FullName_nvc"
        Me.colFullName_nvc.HeaderText = "نام نماینده"
        Me.colFullName_nvc.Name = "colFullName_nvc"
        Me.colFullName_nvc.ReadOnly = True
        Me.colFullName_nvc.Width = 350
        '
        'colContractDate_vc
        '
        Me.colContractDate_vc.DataPropertyName = "ContractDate_vc"
        Me.colContractDate_vc.HeaderText = "تاریخ قرارداد"
        Me.colContractDate_vc.Name = "colContractDate_vc"
        Me.colContractDate_vc.ReadOnly = True
        Me.colContractDate_vc.Width = 150
        '
        'TransactionsTabPage
        '
        Me.TransactionsTabPage.Controls.Add(Me.dgvTransactions)
        Me.TransactionsTabPage.Location = New System.Drawing.Point(4, 23)
        Me.TransactionsTabPage.Name = "TransactionsTabPage"
        Me.TransactionsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TransactionsTabPage.Size = New System.Drawing.Size(725, 371)
        Me.TransactionsTabPage.TabIndex = 1
        Me.TransactionsTabPage.Text = "تراکنش ها"
        Me.TransactionsTabPage.ToolTipText = "مشاهده تراکنش ها"
        Me.TransactionsTabPage.UseVisualStyleBackColor = True
        '
        'dgvTransactions
        '
        Me.dgvTransactions.AllowUserToAddRows = False
        Me.dgvTransactions.AllowUserToDeleteRows = False
        Me.dgvTransactions.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.dgvTransactions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTransactions.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTransactions.Location = New System.Drawing.Point(3, 3)
        Me.dgvTransactions.MultiSelect = False
        Me.dgvTransactions.Name = "dgvTransactions"
        Me.dgvTransactions.ReadOnly = True
        Me.dgvTransactions.RowHeadersVisible = False
        Me.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransactions.Size = New System.Drawing.Size(719, 365)
        Me.dgvTransactions.TabIndex = 15
        '
        'DsReport1
        '
        Me.DsReport1.DataSetName = "DSReport"
        Me.DsReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.Location = New System.Drawing.Point(504, 28)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(229, 109)
        Me.rucDate.TabIndex = 40
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.cmbProject)
        Me.GroupBox2.Location = New System.Drawing.Point(253, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 50)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(196, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 14)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "پروژه :"
        '
        'cmbProject
        '
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(18, 17)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(172, 22)
        Me.cmbProject.TabIndex = 0
        '
        'frmVisitorTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 535)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.VisitorTransactionsTabControl)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.rucDate)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmVisitorTransactions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.Text = "گزارش تراکنش های نمایندگان"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ErrPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.VisitorTransactionsTabControl.ResumeLayout(False)
        Me.VisitorTabPage.ResumeLayout(False)
        CType(Me.dgvVisitors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TransactionsTabPage.ResumeLayout(False)
        CType(Me.dgvTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsReport1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRowCount As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ErrPro As System.Windows.Forms.ErrorProvider
    Friend WithEvents VisitorTransactionsTabControl As System.Windows.Forms.TabControl
    Friend WithEvents VisitorTabPage As System.Windows.Forms.TabPage
    Friend WithEvents TransactionsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents rucDate As ReportUserControl_DateInterval
    Friend WithEvents dgvVisitors As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents DsReport1 As DSReport
    Friend WithEvents colVisitorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colContractDate_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
End Class
