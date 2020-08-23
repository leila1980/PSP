<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptCallsInfoDelay
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
        Me.components = New System.ComponentModel.Container
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.grpCompleted = New System.Windows.Forms.GroupBox
        Me.txtWorkStart = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.grpCompletedDelay = New System.Windows.Forms.GroupBox
        Me.rdoAll = New System.Windows.Forms.RadioButton
        Me.txtSumDelay = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpDelayBetween = New System.Windows.Forms.GroupBox
        Me.DelayFrom = New Timing
        Me.Label4 = New System.Windows.Forms.Label
        Me.DelayTo = New Timing
        Me.Label3 = New System.Windows.Forms.Label
        Me.rdoWithDelay = New System.Windows.Forms.RadioButton
        Me.rdoWithoutDelay = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtWorkEnd = New System.Windows.Forms.MaskedTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtResponseLimitInHourTehran = New AMS.TextBox.NumericTextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCnt = New System.Windows.Forms.ToolStripStatusLabel
        Me.slblRowsCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.cmbVisitor = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtResponseLimitInHourCity = New AMS.TextBox.NumericTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtResponseLimitInHourMarakez = New AMS.TextBox.NumericTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbtResponseDate = New System.Windows.Forms.RadioButton
        Me.rbtCallDate = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblAllFineAmountSum = New System.Windows.Forms.Label
        Me.ReportSearchToolStrip1 = New ReportSearchToolStrip
        Me.rucDate = New ReportUserControl_DateInterval
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCompleted.SuspendLayout()
        Me.grpCompletedDelay.SuspendLayout()
        Me.grpDelayBetween.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvReport)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 217)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(912, 333)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(6, 16)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(900, 306)
        Me.dgvReport.TabIndex = 0
        '
        'grpCompleted
        '
        Me.grpCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCompleted.Controls.Add(Me.txtWorkStart)
        Me.grpCompleted.Controls.Add(Me.Label6)
        Me.grpCompleted.Controls.Add(Me.grpCompletedDelay)
        Me.grpCompleted.Controls.Add(Me.Label9)
        Me.grpCompleted.Controls.Add(Me.txtWorkEnd)
        Me.grpCompleted.Controls.Add(Me.Label5)
        Me.grpCompleted.Location = New System.Drawing.Point(391, 28)
        Me.grpCompleted.Name = "grpCompleted"
        Me.grpCompleted.Size = New System.Drawing.Size(345, 138)
        Me.grpCompleted.TabIndex = 1
        Me.grpCompleted.TabStop = False
        '
        'txtWorkStart
        '
        Me.txtWorkStart.Location = New System.Drawing.Point(193, 18)
        Me.txtWorkStart.Mask = "90:00"
        Me.txtWorkStart.Name = "txtWorkStart"
        Me.txtWorkStart.Size = New System.Drawing.Size(37, 21)
        Me.txtWorkStart.TabIndex = 0
        Me.txtWorkStart.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(168, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "تا :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpCompletedDelay
        '
        Me.grpCompletedDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCompletedDelay.Controls.Add(Me.rdoAll)
        Me.grpCompletedDelay.Controls.Add(Me.txtSumDelay)
        Me.grpCompletedDelay.Controls.Add(Me.Label2)
        Me.grpCompletedDelay.Controls.Add(Me.grpDelayBetween)
        Me.grpCompletedDelay.Controls.Add(Me.rdoWithDelay)
        Me.grpCompletedDelay.Controls.Add(Me.rdoWithoutDelay)
        Me.grpCompletedDelay.Location = New System.Drawing.Point(2, 41)
        Me.grpCompletedDelay.Name = "grpCompletedDelay"
        Me.grpCompletedDelay.Size = New System.Drawing.Size(340, 90)
        Me.grpCompletedDelay.TabIndex = 2
        Me.grpCompletedDelay.TabStop = False
        '
        'rdoAll
        '
        Me.rdoAll.AutoSize = True
        Me.rdoAll.Location = New System.Drawing.Point(284, 14)
        Me.rdoAll.Name = "rdoAll"
        Me.rdoAll.Size = New System.Drawing.Size(46, 17)
        Me.rdoAll.TabIndex = 0
        Me.rdoAll.TabStop = True
        Me.rdoAll.Text = "همه"
        Me.rdoAll.UseVisualStyleBackColor = True
        '
        'txtSumDelay
        '
        Me.txtSumDelay.Enabled = False
        Me.txtSumDelay.Location = New System.Drawing.Point(152, 61)
        Me.txtSumDelay.Name = "txtSumDelay"
        Me.txtSumDelay.ReadOnly = True
        Me.txtSumDelay.Size = New System.Drawing.Size(112, 21)
        Me.txtSumDelay.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(270, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "جمع تاخیرها"
        '
        'grpDelayBetween
        '
        Me.grpDelayBetween.Controls.Add(Me.DelayFrom)
        Me.grpDelayBetween.Controls.Add(Me.Label4)
        Me.grpDelayBetween.Controls.Add(Me.DelayTo)
        Me.grpDelayBetween.Controls.Add(Me.Label3)
        Me.grpDelayBetween.Location = New System.Drawing.Point(6, 10)
        Me.grpDelayBetween.Name = "grpDelayBetween"
        Me.grpDelayBetween.Size = New System.Drawing.Size(140, 72)
        Me.grpDelayBetween.TabIndex = 3
        Me.grpDelayBetween.TabStop = False
        '
        'DelayFrom
        '
        Me.DelayFrom.Hour = ""
        Me.DelayFrom.Location = New System.Drawing.Point(6, 9)
        Me.DelayFrom.Min = ""
        Me.DelayFrom.Name = "DelayFrom"
        Me.DelayFrom.Size = New System.Drawing.Size(110, 26)
        Me.DelayFrom.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(115, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "تا"
        '
        'DelayTo
        '
        Me.DelayTo.Hour = ""
        Me.DelayTo.Location = New System.Drawing.Point(6, 39)
        Me.DelayTo.Min = ""
        Me.DelayTo.Name = "DelayTo"
        Me.DelayTo.Size = New System.Drawing.Size(110, 26)
        Me.DelayTo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(117, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "از"
        '
        'rdoWithDelay
        '
        Me.rdoWithDelay.AutoSize = True
        Me.rdoWithDelay.Location = New System.Drawing.Point(148, 14)
        Me.rdoWithDelay.Name = "rdoWithDelay"
        Me.rdoWithDelay.Size = New System.Drawing.Size(56, 17)
        Me.rdoWithDelay.TabIndex = 2
        Me.rdoWithDelay.TabStop = True
        Me.rdoWithDelay.Text = "با تاخیر"
        Me.rdoWithDelay.UseVisualStyleBackColor = True
        '
        'rdoWithoutDelay
        '
        Me.rdoWithoutDelay.AutoSize = True
        Me.rdoWithoutDelay.Location = New System.Drawing.Point(210, 14)
        Me.rdoWithoutDelay.Name = "rdoWithoutDelay"
        Me.rdoWithoutDelay.Size = New System.Drawing.Size(71, 17)
        Me.rdoWithoutDelay.TabIndex = 1
        Me.rdoWithoutDelay.TabStop = True
        Me.rdoWithoutDelay.Text = "بدون تاخير"
        Me.rdoWithoutDelay.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(277, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "ساعت کاری"
        '
        'txtWorkEnd
        '
        Me.txtWorkEnd.Location = New System.Drawing.Point(129, 18)
        Me.txtWorkEnd.Mask = "90:00"
        Me.txtWorkEnd.Name = "txtWorkEnd"
        Me.txtWorkEnd.Size = New System.Drawing.Size(37, 21)
        Me.txtWorkEnd.TabIndex = 1
        Me.txtWorkEnd.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(233, 21)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "از :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtResponseLimitInHourTehran
        '
        Me.txtResponseLimitInHourTehran.AllowNegative = True
        Me.txtResponseLimitInHourTehran.DigitsInGroup = 0
        Me.txtResponseLimitInHourTehran.Flags = 0
        Me.txtResponseLimitInHourTehran.Location = New System.Drawing.Point(61, 32)
        Me.txtResponseLimitInHourTehran.MaxDecimalPlaces = 4
        Me.txtResponseLimitInHourTehran.MaxWholeDigits = 9
        Me.txtResponseLimitInHourTehran.Name = "txtResponseLimitInHourTehran"
        Me.txtResponseLimitInHourTehran.Prefix = ""
        Me.txtResponseLimitInHourTehran.RangeMax = 1.7976931348623157E+308
        Me.txtResponseLimitInHourTehran.RangeMin = -1.7976931348623157E+308
        Me.txtResponseLimitInHourTehran.Size = New System.Drawing.Size(28, 21)
        Me.txtResponseLimitInHourTehran.TabIndex = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblCnt, Me.slblRowsCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 553)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(921, 22)
        Me.StatusStrip1.TabIndex = 26
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.SlateGray
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(53, 17)
        Me.ToolStripStatusLabel1.Text = "تعداد کل :"
        '
        'lblCnt
        '
        Me.lblCnt.Name = "lblCnt"
        Me.lblCnt.Size = New System.Drawing.Size(10, 17)
        Me.lblCnt.Text = " "
        '
        'slblRowsCount
        '
        Me.slblRowsCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblRowsCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.slblRowsCount.Name = "slblRowsCount"
        Me.slblRowsCount.Size = New System.Drawing.Size(0, 17)
        '
        'cmbVisitor
        '
        Me.cmbVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVisitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVisitor.FormattingEnabled = True
        Me.cmbVisitor.Location = New System.Drawing.Point(571, 173)
        Me.cmbVisitor.Name = "cmbVisitor"
        Me.cmbVisitor.Size = New System.Drawing.Size(302, 21)
        Me.cmbVisitor.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(875, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "بازاریاب :"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(876, 201)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "پروژه :"
        '
        'cmbProject
        '
        Me.cmbProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(571, 198)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(302, 21)
        Me.cmbProject.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtResponseLimitInHourCity)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtResponseLimitInHourMarakez)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtResponseLimitInHourTehran)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Location = New System.Drawing.Point(742, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(176, 138)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "حداکثر زمان پاسخگویی"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "ساعت"
        '
        'txtResponseLimitInHourCity
        '
        Me.txtResponseLimitInHourCity.AllowNegative = True
        Me.txtResponseLimitInHourCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResponseLimitInHourCity.DigitsInGroup = 0
        Me.txtResponseLimitInHourCity.Flags = 0
        Me.txtResponseLimitInHourCity.Location = New System.Drawing.Point(61, 95)
        Me.txtResponseLimitInHourCity.MaxDecimalPlaces = 4
        Me.txtResponseLimitInHourCity.MaxWholeDigits = 9
        Me.txtResponseLimitInHourCity.Name = "txtResponseLimitInHourCity"
        Me.txtResponseLimitInHourCity.Prefix = ""
        Me.txtResponseLimitInHourCity.RangeMax = 1.7976931348623157E+308
        Me.txtResponseLimitInHourCity.RangeMin = -1.7976931348623157E+308
        Me.txtResponseLimitInHourCity.Size = New System.Drawing.Size(28, 21)
        Me.txtResponseLimitInHourCity.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(93, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "شهرستان"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "ساعت"
        '
        'txtResponseLimitInHourMarakez
        '
        Me.txtResponseLimitInHourMarakez.AllowNegative = True
        Me.txtResponseLimitInHourMarakez.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResponseLimitInHourMarakez.DigitsInGroup = 0
        Me.txtResponseLimitInHourMarakez.Flags = 0
        Me.txtResponseLimitInHourMarakez.Location = New System.Drawing.Point(61, 63)
        Me.txtResponseLimitInHourMarakez.MaxDecimalPlaces = 4
        Me.txtResponseLimitInHourMarakez.MaxWholeDigits = 9
        Me.txtResponseLimitInHourMarakez.Name = "txtResponseLimitInHourMarakez"
        Me.txtResponseLimitInHourMarakez.Prefix = ""
        Me.txtResponseLimitInHourMarakez.RangeMax = 1.7976931348623157E+308
        Me.txtResponseLimitInHourMarakez.RangeMin = -1.7976931348623157E+308
        Me.txtResponseLimitInHourMarakez.Size = New System.Drawing.Size(28, 21)
        Me.txtResponseLimitInHourMarakez.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(93, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "مراکز استان"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "ساعت"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(93, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "تهران"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rbtResponseDate)
        Me.GroupBox3.Controls.Add(Me.rbtCallDate)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(147, 100)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "بازه تاریخی"
        '
        'rbtResponseDate
        '
        Me.rbtResponseDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtResponseDate.AutoSize = True
        Me.rbtResponseDate.Location = New System.Drawing.Point(19, 58)
        Me.rbtResponseDate.Name = "rbtResponseDate"
        Me.rbtResponseDate.Size = New System.Drawing.Size(115, 17)
        Me.rbtResponseDate.TabIndex = 1
        Me.rbtResponseDate.Text = "براساس تاریخ پاسخ"
        Me.rbtResponseDate.UseVisualStyleBackColor = True
        '
        'rbtCallDate
        '
        Me.rbtCallDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtCallDate.AutoSize = True
        Me.rbtCallDate.Checked = True
        Me.rbtCallDate.Location = New System.Drawing.Point(18, 28)
        Me.rbtCallDate.Name = "rbtCallDate"
        Me.rbtCallDate.Size = New System.Drawing.Size(116, 17)
        Me.rbtCallDate.TabIndex = 0
        Me.rbtCallDate.TabStop = True
        Me.rbtCallDate.Text = "براساس تاریخ تماس"
        Me.rbtCallDate.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.lblAllFineAmountSum)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 135)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(375, 84)
        Me.GroupBox4.TabIndex = 43
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "جمع مبالغ جریمه به تومان"
        '
        'lblAllFineAmountSum
        '
        Me.lblAllFineAmountSum.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAllFineAmountSum.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblAllFineAmountSum.ForeColor = System.Drawing.Color.Red
        Me.lblAllFineAmountSum.Location = New System.Drawing.Point(3, 17)
        Me.lblAllFineAmountSum.Name = "lblAllFineAmountSum"
        Me.lblAllFineAmountSum.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblAllFineAmountSum.Size = New System.Drawing.Size(369, 64)
        Me.lblAllFineAmountSum.TabIndex = 0
        Me.lblAllFineAmountSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ReportSearchToolStrip1
        '
        Me.ReportSearchToolStrip1.btnExportExcelVisible = True
        Me.ReportSearchToolStrip1.btnPrintVisible = False
        Me.ReportSearchToolStrip1.btnShowVisible = True
        Me.ReportSearchToolStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ReportSearchToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ReportSearchToolStrip1.Name = "ReportSearchToolStrip1"
        Me.ReportSearchToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ReportSearchToolStrip1.Size = New System.Drawing.Size(921, 24)
        Me.ReportSearchToolStrip1.TabIndex = 42
        '
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.GroupBoxText = ""
        Me.rucDate.Location = New System.Drawing.Point(156, 28)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(229, 102)
        Me.rucDate.TabIndex = 2
        '
        'frmRptCallsInfoDelay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 575)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbProject)
        Me.Controls.Add(Me.grpCompleted)
        Me.Controls.Add(Me.ReportSearchToolStrip1)
        Me.Controls.Add(Me.cmbVisitor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rucDate)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRptCallsInfoDelay"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش تاخیر بخش فنی "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCompleted.ResumeLayout(False)
        Me.grpCompleted.PerformLayout()
        Me.grpCompletedDelay.ResumeLayout(False)
        Me.grpCompletedDelay.PerformLayout()
        Me.grpDelayBetween.ResumeLayout(False)
        Me.grpDelayBetween.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rucDate As ReportUserControl_DateInterval
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCnt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slblRowsCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DelayFrom As Timing
    Friend WithEvents DelayTo As Timing
    Friend WithEvents grpCompletedDelay As System.Windows.Forms.GroupBox
    Friend WithEvents rdoWithDelay As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWithoutDelay As System.Windows.Forms.RadioButton
    Friend WithEvents grpDelayBetween As System.Windows.Forms.GroupBox
    Friend WithEvents txtSumDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbVisitor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtWorkStart As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtWorkEnd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grpCompleted As System.Windows.Forms.GroupBox
    Friend txtResponseLimitInHourTehran As AMS.TextBox.NumericTextBox
    Friend WithEvents ReportSearchToolStrip1 As ReportSearchToolStrip
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtResponseLimitInHourCity As AMS.TextBox.NumericTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtResponseLimitInHourMarakez As AMS.TextBox.NumericTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtResponseDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCallDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAll As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAllFineAmountSum As System.Windows.Forms.Label
End Class
