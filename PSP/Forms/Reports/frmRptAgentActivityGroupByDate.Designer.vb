<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptAgentActivityGroupByDate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptAgentActivityGroupByDate))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkParent = New System.Windows.Forms.CheckBox
        Me.cboChart = New System.Windows.Forms.ComboBox
        Me.cboProject = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ChkList = New System.Windows.Forms.CheckedListBox
        Me.txtToPrice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboAuthorizationState = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCalcType = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFromPrice = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgvVisitor = New System.Windows.Forms.DataGridView
        Me.cboVisitorID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckedBox = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label21 = New System.Windows.Forms.Label
        Me.pnlMonthly = New System.Windows.Forms.Panel
        Me.cboToYear = New System.Windows.Forms.ComboBox
        Me.cboFromYear = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboToMonth = New System.Windows.Forms.ComboBox
        Me.cboFromMonth = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.pnlDaily = New System.Windows.Forms.Panel
        Me.txtDateTo = New DateTextBox.DateTextBox
        Me.txtDateFrom = New DateTextBox.DateTextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.rbtMonthly = New System.Windows.Forms.RadioButton
        Me.rbtDaily = New System.Windows.Forms.RadioButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnShow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnPrint = New System.Windows.Forms.ToolStripButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.LinkCancel = New System.Windows.Forms.LinkLabel
        Me.LinkAll = New System.Windows.Forms.LinkLabel
        Me.LinkReversal = New System.Windows.Forms.LinkLabel
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvVisitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMonthly.SuspendLayout()
        Me.pnlDaily.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkParent)
        Me.GroupBox1.Controls.Add(Me.cboChart)
        Me.GroupBox1.Controls.Add(Me.cboProject)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ChkList)
        Me.GroupBox1.Controls.Add(Me.txtToPrice)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboAuthorizationState)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboCalcType)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFromPrice)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(781, 109)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'chkParent
        '
        Me.chkParent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkParent.AutoSize = True
        Me.chkParent.Location = New System.Drawing.Point(113, 80)
        Me.chkParent.Name = "chkParent"
        Me.chkParent.Size = New System.Drawing.Size(130, 17)
        Me.chkParent.TabIndex = 27
        Me.chkParent.Text = "نمایش اطلاعات اضافی"
        Me.chkParent.UseVisualStyleBackColor = True
        Me.chkParent.Visible = False
        '
        'cboChart
        '
        Me.cboChart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChart.FormattingEnabled = True
        Me.cboChart.Items.AddRange(New Object() {"خطی", "مساحتی", "دایره ای", "میله ای", "مساحتی سه بعدی", "میله ای سه بعدی"})
        Me.cboChart.Location = New System.Drawing.Point(149, 51)
        Me.cboChart.Name = "cboChart"
        Me.cboChart.Size = New System.Drawing.Size(94, 21)
        Me.cboChart.TabIndex = 26
        '
        'cboProject
        '
        Me.cboProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProject.FormattingEnabled = True
        Me.cboProject.Items.AddRange(New Object() {"همه", "موفق", "نا موفق"})
        Me.cboProject.Location = New System.Drawing.Point(336, 75)
        Me.cboProject.Name = "cboProject"
        Me.cboProject.Size = New System.Drawing.Size(173, 21)
        Me.cboProject.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(515, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "پروژه :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(249, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "نوع نمودار :"
        '
        'ChkList
        '
        Me.ChkList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkList.FormattingEnabled = True
        Me.ChkList.Items.AddRange(New Object() {"شارژ", "خرید", "پرداخت قبض", "موجودی"})
        Me.ChkList.Location = New System.Drawing.Point(617, 17)
        Me.ChkList.Name = "ChkList"
        Me.ChkList.Size = New System.Drawing.Size(85, 84)
        Me.ChkList.TabIndex = 21
        '
        'txtToPrice
        '
        Me.txtToPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtToPrice.Location = New System.Drawing.Point(22, 21)
        Me.txtToPrice.MaxLength = 19
        Me.txtToPrice.Name = "txtToPrice"
        Me.txtToPrice.Size = New System.Drawing.Size(94, 21)
        Me.txtToPrice.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(515, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "نوع محاسبه :"
        '
        'cboAuthorizationState
        '
        Me.cboAuthorizationState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAuthorizationState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAuthorizationState.FormattingEnabled = True
        Me.cboAuthorizationState.Items.AddRange(New Object() {"همه", "موفق", "ناموفق", "ناموفق به تفکیک علت"})
        Me.cboAuthorizationState.Location = New System.Drawing.Point(336, 48)
        Me.cboAuthorizationState.Name = "cboAuthorizationState"
        Me.cboAuthorizationState.Size = New System.Drawing.Size(173, 21)
        Me.cboAuthorizationState.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(705, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "نوع تراکنش :"
        '
        'cboCalcType
        '
        Me.cboCalcType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCalcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalcType.FormattingEnabled = True
        Me.cboCalcType.Items.AddRange(New Object() {"تعداد تراکنش", "جمع مبلغ تراکنش", "میانگین تعدادی", "میانگین ریالی بر اساس تعداد تراکنش", "میانگین ریالی بر اساس تعداد دستگاه فعال"})
        Me.cboCalcType.Location = New System.Drawing.Point(336, 21)
        Me.cboCalcType.Name = "cboCalcType"
        Me.cboCalcType.Size = New System.Drawing.Size(173, 21)
        Me.cboCalcType.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(515, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "وضعیت تراکنش :"
        '
        'txtFromPrice
        '
        Me.txtFromPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFromPrice.Location = New System.Drawing.Point(149, 21)
        Me.txtFromPrice.MaxLength = 19
        Me.txtFromPrice.Name = "txtFromPrice"
        Me.txtFromPrice.Size = New System.Drawing.Size(94, 21)
        Me.txtFromPrice.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(247, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "مبلغ تراکنش از :"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(120, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "تا :"
        '
        'dgvVisitor
        '
        Me.dgvVisitor.AllowUserToAddRows = False
        Me.dgvVisitor.AllowUserToDeleteRows = False
        Me.dgvVisitor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVisitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVisitor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cboVisitorID, Me.FullName, Me.CheckedBox})
        Me.dgvVisitor.Location = New System.Drawing.Point(779, 164)
        Me.dgvVisitor.Name = "dgvVisitor"
        Me.dgvVisitor.RowHeadersVisible = False
        Me.dgvVisitor.Size = New System.Drawing.Size(240, 308)
        Me.dgvVisitor.TabIndex = 20
        '
        'cboVisitorID
        '
        Me.cboVisitorID.DataPropertyName = "VisitorID"
        Me.cboVisitorID.HeaderText = "VisitorID"
        Me.cboVisitorID.Name = "cboVisitorID"
        Me.cboVisitorID.ReadOnly = True
        Me.cboVisitorID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cboVisitorID.Visible = False
        '
        'FullName
        '
        Me.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FullName.DataPropertyName = "FullName_nvc"
        Me.FullName.HeaderText = "نام"
        Me.FullName.Name = "FullName"
        Me.FullName.ReadOnly = True
        '
        'CheckedBox
        '
        Me.CheckedBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.CheckedBox.HeaderText = "انتخاب"
        Me.CheckedBox.Name = "CheckedBox"
        Me.CheckedBox.Width = 42
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(960, 143)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 13)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "نمایندگان :"
        '
        'pnlMonthly
        '
        Me.pnlMonthly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMonthly.Controls.Add(Me.cboToYear)
        Me.pnlMonthly.Controls.Add(Me.cboFromYear)
        Me.pnlMonthly.Controls.Add(Me.Label19)
        Me.pnlMonthly.Controls.Add(Me.Label20)
        Me.pnlMonthly.Controls.Add(Me.cboToMonth)
        Me.pnlMonthly.Controls.Add(Me.cboFromMonth)
        Me.pnlMonthly.Controls.Add(Me.Label17)
        Me.pnlMonthly.Controls.Add(Me.Label18)
        Me.pnlMonthly.Location = New System.Drawing.Point(8, 40)
        Me.pnlMonthly.Name = "pnlMonthly"
        Me.pnlMonthly.Size = New System.Drawing.Size(225, 60)
        Me.pnlMonthly.TabIndex = 18
        '
        'cboToYear
        '
        Me.cboToYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToYear.FormattingEnabled = True
        Me.cboToYear.Items.AddRange(New Object() {"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"})
        Me.cboToYear.Location = New System.Drawing.Point(4, 38)
        Me.cboToYear.Name = "cboToYear"
        Me.cboToYear.Size = New System.Drawing.Size(66, 21)
        Me.cboToYear.TabIndex = 9
        '
        'cboFromYear
        '
        Me.cboFromYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromYear.FormattingEnabled = True
        Me.cboFromYear.Items.AddRange(New Object() {"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"})
        Me.cboFromYear.Location = New System.Drawing.Point(4, 9)
        Me.cboFromYear.Name = "cboFromYear"
        Me.cboFromYear.Size = New System.Drawing.Size(66, 21)
        Me.cboFromYear.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(71, 41)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "سال :"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(71, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "سال :"
        '
        'cboToMonth
        '
        Me.cboToMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToMonth.FormattingEnabled = True
        Me.cboToMonth.Items.AddRange(New Object() {"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"})
        Me.cboToMonth.Location = New System.Drawing.Point(107, 38)
        Me.cboToMonth.Name = "cboToMonth"
        Me.cboToMonth.Size = New System.Drawing.Size(80, 21)
        Me.cboToMonth.TabIndex = 5
        '
        'cboFromMonth
        '
        Me.cboFromMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromMonth.FormattingEnabled = True
        Me.cboFromMonth.Items.AddRange(New Object() {"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"})
        Me.cboFromMonth.Location = New System.Drawing.Point(107, 9)
        Me.cboFromMonth.Name = "cboFromMonth"
        Me.cboFromMonth.Size = New System.Drawing.Size(80, 21)
        Me.cboFromMonth.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(193, 41)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(20, 13)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "تا :"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(193, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(21, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "از :"
        '
        'pnlDaily
        '
        Me.pnlDaily.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDaily.Controls.Add(Me.txtDateTo)
        Me.pnlDaily.Controls.Add(Me.txtDateFrom)
        Me.pnlDaily.Controls.Add(Me.Label14)
        Me.pnlDaily.Controls.Add(Me.Label9)
        Me.pnlDaily.Location = New System.Drawing.Point(9, 41)
        Me.pnlDaily.Name = "pnlDaily"
        Me.pnlDaily.Size = New System.Drawing.Size(225, 60)
        Me.pnlDaily.TabIndex = 2
        '
        'txtDateTo
        '
        Me.txtDateTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDateTo.AutoSize = True
        Me.txtDateTo.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtDateTo.DateBackColor = System.Drawing.SystemColors.Window
        Me.txtDateTo.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDateTo.DateReadOnly = False
        Me.txtDateTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDateTo.Location = New System.Drawing.Point(51, 32)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(84, 21)
        Me.txtDateTo.TabIndex = 17
        Me.txtDateTo.Value = ""
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDateFrom.AutoSize = True
        Me.txtDateFrom.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtDateFrom.DateBackColor = System.Drawing.SystemColors.Window
        Me.txtDateFrom.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDateFrom.DateReadOnly = False
        Me.txtDateFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDateFrom.Location = New System.Drawing.Point(51, 7)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(84, 21)
        Me.txtDateFrom.TabIndex = 16
        Me.txtDateFrom.Value = ""
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(144, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "تا تاریخ :"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(144, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "از تاریخ :"
        '
        'rbtMonthly
        '
        Me.rbtMonthly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtMonthly.AutoSize = True
        Me.rbtMonthly.Location = New System.Drawing.Point(118, 18)
        Me.rbtMonthly.Name = "rbtMonthly"
        Me.rbtMonthly.Size = New System.Drawing.Size(54, 17)
        Me.rbtMonthly.TabIndex = 1
        Me.rbtMonthly.Text = "ماهانه"
        Me.rbtMonthly.UseVisualStyleBackColor = True
        '
        'rbtDaily
        '
        Me.rbtDaily.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtDaily.AutoSize = True
        Me.rbtDaily.Checked = True
        Me.rbtDaily.Location = New System.Drawing.Point(183, 18)
        Me.rbtDaily.Name = "rbtDaily"
        Me.rbtDaily.Size = New System.Drawing.Size(50, 17)
        Me.rbtDaily.TabIndex = 0
        Me.rbtDaily.TabStop = True
        Me.rbtDaily.Text = "روزانه"
        Me.rbtDaily.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnShow, Me.ToolStripSeparator4, Me.btnExportToExcel, Me.ToolStripSeparator1, Me.btnPrint})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1018, 25)
        Me.ToolStrip1.TabIndex = 40
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnShow
        '
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(67, 22)
        Me.btnShow.Text = "مشاهده"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        Me.ToolStripSeparator1.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(46, 22)
        Me.btnPrint.Text = "چاپ"
        Me.btnPrint.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.pnlDaily)
        Me.GroupBox4.Controls.Add(Me.rbtDaily)
        Me.GroupBox4.Controls.Add(Me.rbtMonthly)
        Me.GroupBox4.Controls.Add(Me.pnlMonthly)
        Me.GroupBox4.Location = New System.Drawing.Point(779, 27)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(240, 109)
        Me.GroupBox4.TabIndex = 45
        Me.GroupBox4.TabStop = False
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGotoPageButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowPageNavigateButtons = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.ShowTextSearchButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(765, 307)
        Me.CrystalReportViewer1.TabIndex = 46
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 139)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(773, 333)
        Me.TabControl1.TabIndex = 49
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CrystalReportViewer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(765, 307)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "نموداری"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvReport)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(765, 307)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "ریز اطلاعات"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(0, 1)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(764, 305)
        Me.dgvReport.TabIndex = 2
        '
        'LinkCancel
        '
        Me.LinkCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkCancel.AutoSize = True
        Me.LinkCancel.Location = New System.Drawing.Point(794, 143)
        Me.LinkCancel.Name = "LinkCancel"
        Me.LinkCancel.Size = New System.Drawing.Size(45, 13)
        Me.LinkCancel.TabIndex = 58
        Me.LinkCancel.TabStop = True
        Me.LinkCancel.Text = "لغو همه"
        '
        'LinkAll
        '
        Me.LinkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkAll.AutoSize = True
        Me.LinkAll.Location = New System.Drawing.Point(845, 143)
        Me.LinkAll.Name = "LinkAll"
        Me.LinkAll.Size = New System.Drawing.Size(60, 13)
        Me.LinkAll.TabIndex = 57
        Me.LinkAll.TabStop = True
        Me.LinkAll.Text = "انتخاب همه"
        '
        'LinkReversal
        '
        Me.LinkReversal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkReversal.AutoSize = True
        Me.LinkReversal.Location = New System.Drawing.Point(911, 143)
        Me.LinkReversal.Name = "LinkReversal"
        Me.LinkReversal.Size = New System.Drawing.Size(43, 13)
        Me.LinkReversal.TabIndex = 56
        Me.LinkReversal.TabStop = True
        Me.LinkReversal.Text = "معکوس"
        '
        'frmRptAgentActivityGroupByDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 476)
        Me.Controls.Add(Me.LinkCancel)
        Me.Controls.Add(Me.LinkAll)
        Me.Controls.Add(Me.LinkReversal)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.dgvVisitor)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmRptAgentActivityGroupByDate"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvVisitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMonthly.ResumeLayout(False)
        Me.pnlMonthly.PerformLayout()
        Me.pnlDaily.ResumeLayout(False)
        Me.pnlDaily.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtToPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtFromPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboAuthorizationState As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCalcType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnShow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlDaily As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rbtMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDaily As System.Windows.Forms.RadioButton
    Friend WithEvents txtDateTo As DateTextBox.DateTextBox
    Friend WithEvents txtDateFrom As DateTextBox.DateTextBox
    Friend WithEvents pnlMonthly As System.Windows.Forms.Panel
    Friend WithEvents cboToMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboFromMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dgvVisitor As System.Windows.Forms.DataGridView
    Friend WithEvents ChkList As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboToYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboFromYear As System.Windows.Forms.ComboBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboProject As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboChart As System.Windows.Forms.ComboBox
    Friend WithEvents cboVisitorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckedBox As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents LinkCancel As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkAll As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkReversal As System.Windows.Forms.LinkLabel
    Friend WithEvents chkParent As System.Windows.Forms.CheckBox
End Class
