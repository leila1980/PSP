<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptGetAllTransactionsSummary
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptGetAllTransactionsSummary))
        Me.tbcMain = New System.Windows.Forms.TabControl
        Me.tbpFilter = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdbActivePos1 = New System.Windows.Forms.RadioButton
        Me.rdbActivePos0 = New System.Windows.Forms.RadioButton
        Me.btnViewReport = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgvReportColumns = New System.Windows.Forms.DataGridView
        Me.colSelectedReportColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colReportColumnEN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colReportColumnFA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnReverseReportColumnsSelection = New System.Windows.Forms.Button
        Me.btnSelectNoneReportColumns = New System.Windows.Forms.Button
        Me.btnSelectAllReportColumns = New System.Windows.Forms.Button
        Me.grpVisitor = New System.Windows.Forms.GroupBox
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.dgvVisitors = New System.Windows.Forms.DataGridView
        Me.colSelectedVisitor = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colVisitorID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colVisitorName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnReverseVisitorSelection = New System.Windows.Forms.Button
        Me.btnSelectNoneVisitor = New System.Windows.Forms.Button
        Me.btnSelectAllVisitors = New System.Windows.Forms.Button
        Me.cmbReportGroup = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkParent = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.grpTransactionType = New System.Windows.Forms.GroupBox
        Me.trvTransactionType = New System.Windows.Forms.TreeView
        Me.cmbTransactionState = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtToTotalPrice = New System.Windows.Forms.TextBox
        Me.txtFromTotalPrice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtToPrice = New System.Windows.Forms.TextBox
        Me.txtFromPrice = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtToTransaction = New System.Windows.Forms.TextBox
        Me.txtFromTransaction = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbpReportGrid = New System.Windows.Forms.TabPage
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.tbpChart = New System.Windows.Forms.TabPage
        Me.cmbFirstColumn = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbChartType = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnShowChart = New System.Windows.Forms.Button
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.erp = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.rucDate = New ReportUserControl_DateInterval
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.dgvProject = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.colSelectedProjectID = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colProjectID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colProjectName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tbcMain.SuspendLayout()
        Me.tbpFilter.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvReportColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVisitor.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvVisitors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.grpTransactionType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbpReportGrid.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.tbpChart.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgvProject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbcMain
        '
        Me.tbcMain.Controls.Add(Me.tbpFilter)
        Me.tbcMain.Controls.Add(Me.tbpReportGrid)
        Me.tbcMain.Controls.Add(Me.tbpChart)
        Me.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcMain.Location = New System.Drawing.Point(0, 0)
        Me.tbcMain.Name = "tbcMain"
        Me.tbcMain.RightToLeftLayout = True
        Me.tbcMain.SelectedIndex = 0
        Me.tbcMain.Size = New System.Drawing.Size(1022, 621)
        Me.tbcMain.TabIndex = 0
        '
        'tbpFilter
        '
        Me.tbpFilter.Controls.Add(Me.GroupBox4)
        Me.tbpFilter.Controls.Add(Me.GroupBox3)
        Me.tbpFilter.Controls.Add(Me.btnViewReport)
        Me.tbpFilter.Controls.Add(Me.GroupBox2)
        Me.tbpFilter.Controls.Add(Me.grpVisitor)
        Me.tbpFilter.Controls.Add(Me.cmbReportGroup)
        Me.tbpFilter.Controls.Add(Me.Label9)
        Me.tbpFilter.Controls.Add(Me.chkParent)
        Me.tbpFilter.Controls.Add(Me.GroupBox5)
        Me.tbpFilter.Controls.Add(Me.GroupBox1)
        Me.tbpFilter.Controls.Add(Me.rucDate)
        Me.tbpFilter.Location = New System.Drawing.Point(4, 22)
        Me.tbpFilter.Name = "tbpFilter"
        Me.tbpFilter.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFilter.Size = New System.Drawing.Size(1014, 595)
        Me.tbpFilter.TabIndex = 0
        Me.tbpFilter.Text = "فیلتر گزارش"
        Me.tbpFilter.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rdbActivePos1)
        Me.GroupBox3.Controls.Add(Me.rdbActivePos0)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(396, 101)
        Me.GroupBox3.TabIndex = 49
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "تعریف پایانه های فعال"
        '
        'rdbActivePos1
        '
        Me.rdbActivePos1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdbActivePos1.AutoSize = True
        Me.rdbActivePos1.Location = New System.Drawing.Point(61, 61)
        Me.rdbActivePos1.Name = "rdbActivePos1"
        Me.rdbActivePos1.Size = New System.Drawing.Size(303, 17)
        Me.rdbActivePos1.TabIndex = 1
        Me.rdbActivePos1.Text = "پایانه هایی که تا تاریخ انتخابی نصب شده و فسخ نشده باشند"
        Me.rdbActivePos1.UseVisualStyleBackColor = True
        '
        'rdbActivePos0
        '
        Me.rdbActivePos0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdbActivePos0.AutoSize = True
        Me.rdbActivePos0.Checked = True
        Me.rdbActivePos0.Location = New System.Drawing.Point(123, 26)
        Me.rdbActivePos0.Name = "rdbActivePos0"
        Me.rdbActivePos0.Size = New System.Drawing.Size(241, 17)
        Me.rdbActivePos0.TabIndex = 0
        Me.rdbActivePos0.TabStop = True
        Me.rdbActivePos0.Text = "پایانه هایی که تا تاریخ انتخابی نصب شده باشند "
        Me.rdbActivePos0.UseVisualStyleBackColor = True
        '
        'btnViewReport
        '
        Me.btnViewReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewReport.Location = New System.Drawing.Point(778, 554)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(224, 23)
        Me.btnViewReport.TabIndex = 48
        Me.btnViewReport.Text = "مشاهده گزارش"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.SplitContainer1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 113)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 471)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ستون های گزارش"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 17)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvReportColumns)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnReverseReportColumnsSelection)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSelectNoneReportColumns)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSelectAllReportColumns)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(396, 451)
        Me.SplitContainer1.SplitterDistance = 412
        Me.SplitContainer1.TabIndex = 15
        '
        'dgvReportColumns
        '
        Me.dgvReportColumns.AllowUserToAddRows = False
        Me.dgvReportColumns.AllowUserToDeleteRows = False
        Me.dgvReportColumns.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvReportColumns.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReportColumns.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelectedReportColumn, Me.colReportColumnEN, Me.colReportColumnFA})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReportColumns.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReportColumns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReportColumns.Location = New System.Drawing.Point(0, 0)
        Me.dgvReportColumns.Name = "dgvReportColumns"
        Me.dgvReportColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReportColumns.Size = New System.Drawing.Size(396, 412)
        Me.dgvReportColumns.TabIndex = 14
        '
        'colSelectedReportColumn
        '
        Me.colSelectedReportColumn.FalseValue = ""
        Me.colSelectedReportColumn.HeaderText = "انتخاب"
        Me.colSelectedReportColumn.Name = "colSelectedReportColumn"
        Me.colSelectedReportColumn.TrueValue = ""
        Me.colSelectedReportColumn.Width = 40
        '
        'colReportColumnEN
        '
        Me.colReportColumnEN.DataPropertyName = "ReportColumnEN"
        Me.colReportColumnEN.HeaderText = "نام انگلیسی ستون گزارش"
        Me.colReportColumnEN.Name = "colReportColumnEN"
        Me.colReportColumnEN.ReadOnly = True
        Me.colReportColumnEN.Visible = False
        Me.colReportColumnEN.Width = 120
        '
        'colReportColumnFA
        '
        Me.colReportColumnFA.DataPropertyName = "ReportColumnFA"
        Me.colReportColumnFA.HeaderText = "نام ستون"
        Me.colReportColumnFA.Name = "colReportColumnFA"
        Me.colReportColumnFA.ReadOnly = True
        Me.colReportColumnFA.Width = 250
        '
        'btnReverseReportColumnsSelection
        '
        Me.btnReverseReportColumnsSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReverseReportColumnsSelection.Image = CType(resources.GetObject("btnReverseReportColumnsSelection.Image"), System.Drawing.Image)
        Me.btnReverseReportColumnsSelection.Location = New System.Drawing.Point(276, 3)
        Me.btnReverseReportColumnsSelection.Name = "btnReverseReportColumnsSelection"
        Me.btnReverseReportColumnsSelection.Size = New System.Drawing.Size(35, 31)
        Me.btnReverseReportColumnsSelection.TabIndex = 2
        Me.btnReverseReportColumnsSelection.UseVisualStyleBackColor = True
        '
        'btnSelectNoneReportColumns
        '
        Me.btnSelectNoneReportColumns.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectNoneReportColumns.Image = CType(resources.GetObject("btnSelectNoneReportColumns.Image"), System.Drawing.Image)
        Me.btnSelectNoneReportColumns.Location = New System.Drawing.Point(317, 3)
        Me.btnSelectNoneReportColumns.Name = "btnSelectNoneReportColumns"
        Me.btnSelectNoneReportColumns.Size = New System.Drawing.Size(35, 31)
        Me.btnSelectNoneReportColumns.TabIndex = 1
        Me.btnSelectNoneReportColumns.UseVisualStyleBackColor = True
        '
        'btnSelectAllReportColumns
        '
        Me.btnSelectAllReportColumns.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAllReportColumns.Image = CType(resources.GetObject("btnSelectAllReportColumns.Image"), System.Drawing.Image)
        Me.btnSelectAllReportColumns.Location = New System.Drawing.Point(358, 3)
        Me.btnSelectAllReportColumns.Name = "btnSelectAllReportColumns"
        Me.btnSelectAllReportColumns.Size = New System.Drawing.Size(35, 31)
        Me.btnSelectAllReportColumns.TabIndex = 0
        Me.btnSelectAllReportColumns.UseVisualStyleBackColor = True
        '
        'grpVisitor
        '
        Me.grpVisitor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVisitor.Controls.Add(Me.SplitContainer2)
        Me.grpVisitor.Location = New System.Drawing.Point(417, 113)
        Me.grpVisitor.Name = "grpVisitor"
        Me.grpVisitor.Size = New System.Drawing.Size(350, 287)
        Me.grpVisitor.TabIndex = 46
        Me.grpVisitor.TabStop = False
        Me.grpVisitor.Text = "بازاریاب"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 17)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvVisitors)
        Me.SplitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnReverseVisitorSelection)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnSelectNoneVisitor)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnSelectAllVisitors)
        Me.SplitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer2.Size = New System.Drawing.Size(344, 267)
        Me.SplitContainer2.SplitterDistance = 227
        Me.SplitContainer2.TabIndex = 16
        '
        'dgvVisitors
        '
        Me.dgvVisitors.AllowUserToAddRows = False
        Me.dgvVisitors.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvVisitors.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvVisitors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVisitors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelectedVisitor, Me.colVisitorID, Me.colVisitorName})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVisitors.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvVisitors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVisitors.Location = New System.Drawing.Point(0, 0)
        Me.dgvVisitors.Name = "dgvVisitors"
        Me.dgvVisitors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVisitors.Size = New System.Drawing.Size(344, 227)
        Me.dgvVisitors.TabIndex = 49
        '
        'colSelectedVisitor
        '
        Me.colSelectedVisitor.HeaderText = "انتخاب"
        Me.colSelectedVisitor.Name = "colSelectedVisitor"
        Me.colSelectedVisitor.Width = 40
        '
        'colVisitorID
        '
        Me.colVisitorID.DataPropertyName = "VisitorID"
        Me.colVisitorID.HeaderText = "کد بازاریاب"
        Me.colVisitorID.Name = "colVisitorID"
        Me.colVisitorID.Visible = False
        '
        'colVisitorName
        '
        Me.colVisitorName.DataPropertyName = "FullName_nvc"
        Me.colVisitorName.HeaderText = "نام بازاریاب"
        Me.colVisitorName.Name = "colVisitorName"
        Me.colVisitorName.Width = 230
        '
        'btnReverseVisitorSelection
        '
        Me.btnReverseVisitorSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReverseVisitorSelection.Image = CType(resources.GetObject("btnReverseVisitorSelection.Image"), System.Drawing.Image)
        Me.btnReverseVisitorSelection.Location = New System.Drawing.Point(225, 3)
        Me.btnReverseVisitorSelection.Name = "btnReverseVisitorSelection"
        Me.btnReverseVisitorSelection.Size = New System.Drawing.Size(35, 31)
        Me.btnReverseVisitorSelection.TabIndex = 2
        Me.btnReverseVisitorSelection.UseVisualStyleBackColor = True
        '
        'btnSelectNoneVisitor
        '
        Me.btnSelectNoneVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectNoneVisitor.Image = CType(resources.GetObject("btnSelectNoneVisitor.Image"), System.Drawing.Image)
        Me.btnSelectNoneVisitor.Location = New System.Drawing.Point(266, 3)
        Me.btnSelectNoneVisitor.Name = "btnSelectNoneVisitor"
        Me.btnSelectNoneVisitor.Size = New System.Drawing.Size(35, 31)
        Me.btnSelectNoneVisitor.TabIndex = 1
        Me.btnSelectNoneVisitor.UseVisualStyleBackColor = True
        '
        'btnSelectAllVisitors
        '
        Me.btnSelectAllVisitors.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAllVisitors.Image = CType(resources.GetObject("btnSelectAllVisitors.Image"), System.Drawing.Image)
        Me.btnSelectAllVisitors.Location = New System.Drawing.Point(306, 3)
        Me.btnSelectAllVisitors.Name = "btnSelectAllVisitors"
        Me.btnSelectAllVisitors.Size = New System.Drawing.Size(35, 31)
        Me.btnSelectAllVisitors.TabIndex = 0
        Me.btnSelectAllVisitors.UseVisualStyleBackColor = True
        '
        'cmbReportGroup
        '
        Me.cmbReportGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbReportGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportGroup.FormattingEnabled = True
        Me.cmbReportGroup.Items.AddRange(New Object() {"پایانه", "استان", "شهر", "مدیریت", "شعبه", "نماینده", "بانک مبدا"})
        Me.cmbReportGroup.Location = New System.Drawing.Point(779, 521)
        Me.cmbReportGroup.Name = "cmbReportGroup"
        Me.cmbReportGroup.Size = New System.Drawing.Size(133, 21)
        Me.cmbReportGroup.TabIndex = 45
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(918, 524)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "گزارش بر اساس :"
        '
        'chkParent
        '
        Me.chkParent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkParent.AutoSize = True
        Me.chkParent.Location = New System.Drawing.Point(853, 491)
        Me.chkParent.Name = "chkParent"
        Me.chkParent.Size = New System.Drawing.Size(150, 17)
        Me.chkParent.TabIndex = 43
        Me.chkParent.Text = "اطلاعات اضافی اعمال گردد"
        Me.chkParent.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.grpTransactionType)
        Me.GroupBox5.Controls.Add(Me.cmbTransactionState)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Location = New System.Drawing.Point(778, 113)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(224, 372)
        Me.GroupBox5.TabIndex = 42
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "وضعیت تراکنش"
        '
        'grpTransactionType
        '
        Me.grpTransactionType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTransactionType.Controls.Add(Me.trvTransactionType)
        Me.grpTransactionType.Location = New System.Drawing.Point(10, 20)
        Me.grpTransactionType.Name = "grpTransactionType"
        Me.grpTransactionType.Size = New System.Drawing.Size(201, 310)
        Me.grpTransactionType.TabIndex = 10
        Me.grpTransactionType.TabStop = False
        Me.grpTransactionType.Text = "نوع تراکنش"
        '
        'trvTransactionType
        '
        Me.trvTransactionType.CheckBoxes = True
        Me.trvTransactionType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvTransactionType.Location = New System.Drawing.Point(3, 17)
        Me.trvTransactionType.Name = "trvTransactionType"
        Me.trvTransactionType.RightToLeftLayout = True
        Me.trvTransactionType.Size = New System.Drawing.Size(195, 290)
        Me.trvTransactionType.TabIndex = 0
        '
        'cmbTransactionState
        '
        Me.cmbTransactionState.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTransactionState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransactionState.FormattingEnabled = True
        Me.cmbTransactionState.Items.AddRange(New Object() {"همه", "موفق", "نا موفق"})
        Me.cmbTransactionState.Location = New System.Drawing.Point(10, 345)
        Me.cmbTransactionState.Name = "cmbTransactionState"
        Me.cmbTransactionState.Size = New System.Drawing.Size(115, 21)
        Me.cmbTransactionState.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(131, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "وضعیت تراکنش :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtToTotalPrice)
        Me.GroupBox1.Controls.Add(Me.txtFromTotalPrice)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtToPrice)
        Me.GroupBox1.Controls.Add(Me.txtFromPrice)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtToTransaction)
        Me.GroupBox1.Controls.Add(Me.txtFromTransaction)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(414, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 101)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "فیلتر"
        '
        'txtToTotalPrice
        '
        Me.txtToTotalPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtToTotalPrice.Location = New System.Drawing.Point(17, 71)
        Me.txtToTotalPrice.MaxLength = 19
        Me.txtToTotalPrice.Name = "txtToTotalPrice"
        Me.txtToTotalPrice.Size = New System.Drawing.Size(74, 21)
        Me.txtToTotalPrice.TabIndex = 17
        '
        'txtFromTotalPrice
        '
        Me.txtFromTotalPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFromTotalPrice.Location = New System.Drawing.Point(151, 71)
        Me.txtFromTotalPrice.MaxLength = 19
        Me.txtFromTotalPrice.Name = "txtFromTotalPrice"
        Me.txtFromTotalPrice.Size = New System.Drawing.Size(74, 21)
        Me.txtFromTotalPrice.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(98, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "تا :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(231, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "جمع کل تراکنش ها از :"
        '
        'txtToPrice
        '
        Me.txtToPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtToPrice.Location = New System.Drawing.Point(17, 44)
        Me.txtToPrice.MaxLength = 19
        Me.txtToPrice.Name = "txtToPrice"
        Me.txtToPrice.Size = New System.Drawing.Size(74, 21)
        Me.txtToPrice.TabIndex = 13
        '
        'txtFromPrice
        '
        Me.txtFromPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFromPrice.Location = New System.Drawing.Point(151, 44)
        Me.txtFromPrice.MaxLength = 19
        Me.txtFromPrice.Name = "txtFromPrice"
        Me.txtFromPrice.Size = New System.Drawing.Size(74, 21)
        Me.txtFromPrice.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(98, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "تا :"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(231, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "مبلغ هر تراکنش از :"
        '
        'txtToTransaction
        '
        Me.txtToTransaction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtToTransaction.Location = New System.Drawing.Point(17, 17)
        Me.txtToTransaction.MaxLength = 8
        Me.txtToTransaction.Name = "txtToTransaction"
        Me.txtToTransaction.Size = New System.Drawing.Size(74, 21)
        Me.txtToTransaction.TabIndex = 7
        '
        'txtFromTransaction
        '
        Me.txtFromTransaction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFromTransaction.Location = New System.Drawing.Point(151, 17)
        Me.txtFromTransaction.MaxLength = 8
        Me.txtFromTransaction.Name = "txtFromTransaction"
        Me.txtFromTransaction.Size = New System.Drawing.Size(74, 21)
        Me.txtFromTransaction.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(98, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "تا :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(231, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "تعداد تراکنش از :"
        '
        'tbpReportGrid
        '
        Me.tbpReportGrid.Controls.Add(Me.dgvReport)
        Me.tbpReportGrid.Controls.Add(Me.ToolStrip1)
        Me.tbpReportGrid.Location = New System.Drawing.Point(4, 22)
        Me.tbpReportGrid.Name = "tbpReportGrid"
        Me.tbpReportGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpReportGrid.Size = New System.Drawing.Size(1014, 595)
        Me.tbpReportGrid.TabIndex = 1
        Me.tbpReportGrid.Text = "گزارش"
        Me.tbpReportGrid.UseVisualStyleBackColor = True
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvReport.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReport.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReport.Location = New System.Drawing.Point(3, 28)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReport.Size = New System.Drawing.Size(1008, 564)
        Me.dgvReport.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportToExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1008, 25)
        Me.ToolStrip1.TabIndex = 0
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
        'tbpChart
        '
        Me.tbpChart.Controls.Add(Me.cmbFirstColumn)
        Me.tbpChart.Controls.Add(Me.Label11)
        Me.tbpChart.Controls.Add(Me.cmbChartType)
        Me.tbpChart.Controls.Add(Me.Label5)
        Me.tbpChart.Controls.Add(Me.btnShowChart)
        Me.tbpChart.Controls.Add(Me.Chart1)
        Me.tbpChart.Location = New System.Drawing.Point(4, 22)
        Me.tbpChart.Name = "tbpChart"
        Me.tbpChart.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpChart.Size = New System.Drawing.Size(1014, 595)
        Me.tbpChart.TabIndex = 2
        Me.tbpChart.Text = "نمودار"
        Me.tbpChart.UseVisualStyleBackColor = True
        '
        'cmbFirstColumn
        '
        Me.cmbFirstColumn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFirstColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFirstColumn.FormattingEnabled = True
        Me.cmbFirstColumn.Location = New System.Drawing.Point(682, 3)
        Me.cmbFirstColumn.Name = "cmbFirstColumn"
        Me.cmbFirstColumn.Size = New System.Drawing.Size(259, 21)
        Me.cmbFirstColumn.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(947, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "ستون اول"
        '
        'cmbChartType
        '
        Me.cmbChartType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChartType.FormattingEnabled = True
        Me.cmbChartType.Location = New System.Drawing.Point(682, 35)
        Me.cmbChartType.Name = "cmbChartType"
        Me.cmbChartType.Size = New System.Drawing.Size(259, 21)
        Me.cmbChartType.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(947, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "نوع نمودار"
        '
        'btnShowChart
        '
        Me.btnShowChart.Location = New System.Drawing.Point(8, 6)
        Me.btnShowChart.Name = "btnShowChart"
        Me.btnShowChart.Size = New System.Drawing.Size(223, 50)
        Me.btnShowChart.TabIndex = 1
        Me.btnShowChart.Text = "مشاهده نمودار"
        Me.btnShowChart.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BorderSkin.BackColor = System.Drawing.Color.Transparent
        ChartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea1.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated90
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(8, 62)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel
        Series1.ChartArea = "ChartArea1"
        Series1.CustomProperties = "LabelStyle=Center"
        Series1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.IsValueShownAsLabel = True
        Series1.Name = "S1"
        Series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire
        Series1.ToolTip = "#VALX"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(1000, 525)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'erp
        '
        Me.erp.ContainerControl = Me
        '
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.GroupBoxText = ""
        Me.rucDate.Location = New System.Drawing.Point(773, 6)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(233, 101)
        Me.rucDate.TabIndex = 20
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.SplitContainer3)
        Me.GroupBox4.Location = New System.Drawing.Point(417, 397)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(350, 184)
        Me.GroupBox4.TabIndex = 50
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "پروژه"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 17)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgvProject)
        Me.SplitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Button2)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Button3)
        Me.SplitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer3.Size = New System.Drawing.Size(344, 164)
        Me.SplitContainer3.SplitterDistance = 124
        Me.SplitContainer3.TabIndex = 16
        '
        'dgvProject
        '
        Me.dgvProject.AllowUserToAddRows = False
        Me.dgvProject.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvProject.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProject.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelectedProjectID, Me.colProjectID, Me.colProjectName})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProject.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProject.Location = New System.Drawing.Point(0, 0)
        Me.dgvProject.Name = "dgvProject"
        Me.dgvProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProject.Size = New System.Drawing.Size(344, 124)
        Me.dgvProject.TabIndex = 49
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(225, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 30)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(266, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 30)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(306, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(35, 30)
        Me.Button3.TabIndex = 0
        Me.Button3.UseVisualStyleBackColor = True
        '
        'colSelectedProjectID
        '
        Me.colSelectedProjectID.HeaderText = "انتخاب"
        Me.colSelectedProjectID.Name = "colSelectedProjectID"
        Me.colSelectedProjectID.Width = 40
        '
        'colProjectID
        '
        Me.colProjectID.DataPropertyName = "ProjectID"
        Me.colProjectID.HeaderText = "کد پروژه"
        Me.colProjectID.Name = "colProjectID"
        Me.colProjectID.Visible = False
        '
        'colProjectName
        '
        Me.colProjectName.DataPropertyName = "Name_nvc"
        Me.colProjectName.HeaderText = "نام پروژه"
        Me.colProjectName.Name = "colProjectName"
        Me.colProjectName.Width = 230
        '
        'frmRptGetAllTransactionsSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 621)
        Me.Controls.Add(Me.tbcMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmRptGetAllTransactionsSummary"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "گزارش تراکنش ها"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tbcMain.ResumeLayout(False)
        Me.tbpFilter.ResumeLayout(False)
        Me.tbpFilter.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvReportColumns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVisitor.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvVisitors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.grpTransactionType.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbpReportGrid.ResumeLayout(False)
        Me.tbpReportGrid.PerformLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tbpChart.ResumeLayout(False)
        Me.tbpChart.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgvProject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcMain As System.Windows.Forms.TabControl
    Friend WithEvents tbpFilter As System.Windows.Forms.TabPage
    Friend WithEvents tbpReportGrid As System.Windows.Forms.TabPage
    Friend WithEvents rucDate As ReportUserControl_DateInterval
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtToPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtFromPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtToTransaction As System.Windows.Forms.TextBox
    Friend WithEvents txtFromTransaction As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtToTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtFromTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTransactionState As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbReportGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkParent As System.Windows.Forms.CheckBox
    Friend WithEvents grpVisitor As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvReportColumns As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnReverseReportColumnsSelection As System.Windows.Forms.Button
    Friend WithEvents btnSelectNoneReportColumns As System.Windows.Forms.Button
    Friend WithEvents btnSelectAllReportColumns As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnReverseVisitorSelection As System.Windows.Forms.Button
    Friend WithEvents btnSelectNoneVisitor As System.Windows.Forms.Button
    Friend WithEvents btnSelectAllVisitors As System.Windows.Forms.Button
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents dgvVisitors As System.Windows.Forms.DataGridView
    Friend WithEvents colSelectedVisitor As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colVisitorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitorName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSelectedReportColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colReportColumnEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReportColumnFA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents grpTransactionType As System.Windows.Forms.GroupBox
    Friend WithEvents trvTransactionType As System.Windows.Forms.TreeView
    Friend WithEvents erp As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbActivePos1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbActivePos0 As System.Windows.Forms.RadioButton
    Friend WithEvents tbpChart As System.Windows.Forms.TabPage
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents btnShowChart As System.Windows.Forms.Button
    Friend WithEvents cmbFirstColumn As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbChartType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvProject As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents colSelectedProjectID As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colProjectID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProjectName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
