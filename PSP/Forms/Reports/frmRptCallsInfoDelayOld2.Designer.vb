<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptCallsInfoDelayOld2
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
        Me.grpDelay = New System.Windows.Forms.GroupBox
        Me.grpCompleted = New System.Windows.Forms.GroupBox
        Me.txtWorkStart = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.grpCompletedDelay = New System.Windows.Forms.GroupBox
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtResponseLimitInHour = New AMS.TextBox.NumericTextBox
        Me.txtWorkEnd = New System.Windows.Forms.MaskedTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.rdoNotCompleted = New System.Windows.Forms.RadioButton
        Me.rdoComleted = New System.Windows.Forms.RadioButton
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCnt = New System.Windows.Forms.ToolStripStatusLabel
        Me.slblRowsCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.cmbVisitor = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.rucDate = New ReportUserControl_DateInterval
        Me.ReportSearchToolStrip1 = New ReportSearchToolStrip
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDelay.SuspendLayout()
        Me.grpCompleted.SuspendLayout()
        Me.grpCompletedDelay.SuspendLayout()
        Me.grpDelayBetween.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvReport)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 238)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(986, 255)
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
        Me.dgvReport.Size = New System.Drawing.Size(974, 228)
        Me.dgvReport.TabIndex = 0
        '
        'grpDelay
        '
        Me.grpDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDelay.Controls.Add(Me.grpCompleted)
        Me.grpDelay.Controls.Add(Me.rdoNotCompleted)
        Me.grpDelay.Controls.Add(Me.rdoComleted)
        Me.grpDelay.Location = New System.Drawing.Point(366, 28)
        Me.grpDelay.Name = "grpDelay"
        Me.grpDelay.Size = New System.Drawing.Size(382, 209)
        Me.grpDelay.TabIndex = 2
        Me.grpDelay.TabStop = False
        '
        'grpCompleted
        '
        Me.grpCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCompleted.Controls.Add(Me.txtWorkStart)
        Me.grpCompleted.Controls.Add(Me.Label6)
        Me.grpCompleted.Controls.Add(Me.grpCompletedDelay)
        Me.grpCompleted.Controls.Add(Me.Label9)
        Me.grpCompleted.Controls.Add(Me.Label7)
        Me.grpCompleted.Controls.Add(Me.Label8)
        Me.grpCompleted.Controls.Add(Me.txtResponseLimitInHour)
        Me.grpCompleted.Controls.Add(Me.txtWorkEnd)
        Me.grpCompleted.Controls.Add(Me.Label5)
        Me.grpCompleted.Location = New System.Drawing.Point(7, 52)
        Me.grpCompleted.Name = "grpCompleted"
        Me.grpCompleted.Size = New System.Drawing.Size(368, 152)
        Me.grpCompleted.TabIndex = 2
        Me.grpCompleted.TabStop = False
        '
        'txtWorkStart
        '
        Me.txtWorkStart.Location = New System.Drawing.Point(193, 40)
        Me.txtWorkStart.Mask = "90:00"
        Me.txtWorkStart.Name = "txtWorkStart"
        Me.txtWorkStart.Size = New System.Drawing.Size(37, 21)
        Me.txtWorkStart.TabIndex = 1
        Me.txtWorkStart.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(168, 43)
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
        Me.grpCompletedDelay.Controls.Add(Me.txtSumDelay)
        Me.grpCompletedDelay.Controls.Add(Me.Label2)
        Me.grpCompletedDelay.Controls.Add(Me.grpDelayBetween)
        Me.grpCompletedDelay.Controls.Add(Me.rdoWithDelay)
        Me.grpCompletedDelay.Controls.Add(Me.rdoWithoutDelay)
        Me.grpCompletedDelay.Location = New System.Drawing.Point(6, 57)
        Me.grpCompletedDelay.Name = "grpCompletedDelay"
        Me.grpCompletedDelay.Size = New System.Drawing.Size(340, 90)
        Me.grpCompletedDelay.TabIndex = 3
        Me.grpCompletedDelay.TabStop = False
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
        Me.Label2.TabIndex = 16
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
        Me.grpDelayBetween.TabIndex = 13
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
        Me.rdoWithDelay.TabIndex = 1
        Me.rdoWithDelay.TabStop = True
        Me.rdoWithDelay.Text = "با تاخیر"
        Me.rdoWithDelay.UseVisualStyleBackColor = True
        '
        'rdoWithoutDelay
        '
        Me.rdoWithoutDelay.AutoSize = True
        Me.rdoWithoutDelay.Location = New System.Drawing.Point(265, 12)
        Me.rdoWithoutDelay.Name = "rdoWithoutDelay"
        Me.rdoWithoutDelay.Size = New System.Drawing.Size(71, 17)
        Me.rdoWithoutDelay.TabIndex = 0
        Me.rdoWithoutDelay.TabStop = True
        Me.rdoWithoutDelay.Text = "بدون تاخير"
        Me.rdoWithoutDelay.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(276, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "ساعت کاری"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(231, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "حداکثر زمان پاسخگویی"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(161, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "ساعت"
        '
        'txtResponseLimitInHour
        '
        Me.txtResponseLimitInHour.AllowNegative = True
        Me.txtResponseLimitInHour.DigitsInGroup = 0
        Me.txtResponseLimitInHour.Flags = 0
        Me.txtResponseLimitInHour.Location = New System.Drawing.Point(202, 12)
        Me.txtResponseLimitInHour.MaxDecimalPlaces = 4
        Me.txtResponseLimitInHour.MaxWholeDigits = 9
        Me.txtResponseLimitInHour.Name = "txtResponseLimitInHour"
        Me.txtResponseLimitInHour.Prefix = ""
        Me.txtResponseLimitInHour.RangeMax = 1.7976931348623157E+308
        Me.txtResponseLimitInHour.RangeMin = -1.7976931348623157E+308
        Me.txtResponseLimitInHour.Size = New System.Drawing.Size(28, 21)
        Me.txtResponseLimitInHour.TabIndex = 0
        '
        'txtWorkEnd
        '
        Me.txtWorkEnd.Location = New System.Drawing.Point(129, 40)
        Me.txtWorkEnd.Mask = "90:00"
        Me.txtWorkEnd.Name = "txtWorkEnd"
        Me.txtWorkEnd.Size = New System.Drawing.Size(37, 21)
        Me.txtWorkEnd.TabIndex = 2
        Me.txtWorkEnd.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(233, 43)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "از :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdoNotCompleted
        '
        Me.rdoNotCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoNotCompleted.AutoSize = True
        Me.rdoNotCompleted.Location = New System.Drawing.Point(301, 10)
        Me.rdoNotCompleted.Name = "rdoNotCompleted"
        Me.rdoNotCompleted.Size = New System.Drawing.Size(74, 17)
        Me.rdoNotCompleted.TabIndex = 0
        Me.rdoNotCompleted.TabStop = True
        Me.rdoNotCompleted.Text = "تمام نشده"
        Me.rdoNotCompleted.UseVisualStyleBackColor = True
        '
        'rdoComleted
        '
        Me.rdoComleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoComleted.AutoSize = True
        Me.rdoComleted.Location = New System.Drawing.Point(305, 33)
        Me.rdoComleted.Name = "rdoComleted"
        Me.rdoComleted.Size = New System.Drawing.Size(70, 17)
        Me.rdoComleted.TabIndex = 1
        Me.rdoComleted.TabStop = True
        Me.rdoComleted.Text = "تمام شده"
        Me.rdoComleted.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblCnt, Me.slblRowsCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 496)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(995, 22)
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
        Me.cmbVisitor.Location = New System.Drawing.Point(755, 133)
        Me.cmbVisitor.Name = "cmbVisitor"
        Me.cmbVisitor.Size = New System.Drawing.Size(173, 21)
        Me.cmbVisitor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(930, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "بازاریاب :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.cmbProject)
        Me.GroupBox4.Location = New System.Drawing.Point(43, 29)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(317, 51)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(272, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "پروژه :"
        '
        'cmbProject
        '
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(18, 18)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(250, 21)
        Me.cmbProject.TabIndex = 0
        '
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.Location = New System.Drawing.Point(751, 28)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(233, 109)
        Me.rucDate.TabIndex = 0
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
        Me.ReportSearchToolStrip1.Size = New System.Drawing.Size(995, 24)
        Me.ReportSearchToolStrip1.TabIndex = 2
        '
        'frmRptCallsInfoDelay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 518)
        Me.Controls.Add(Me.ReportSearchToolStrip1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmbVisitor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grpDelay)
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
        Me.grpDelay.ResumeLayout(False)
        Me.grpDelay.PerformLayout()
        Me.grpCompleted.ResumeLayout(False)
        Me.grpCompleted.PerformLayout()
        Me.grpCompletedDelay.ResumeLayout(False)
        Me.grpCompletedDelay.PerformLayout()
        Me.grpDelayBetween.ResumeLayout(False)
        Me.grpDelayBetween.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rucDate As ReportUserControl_DateInterval
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents grpDelay As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCnt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slblRowsCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DelayFrom As Timing
    Friend WithEvents DelayTo As Timing
    Friend WithEvents rdoNotCompleted As System.Windows.Forms.RadioButton
    Friend WithEvents rdoComleted As System.Windows.Forms.RadioButton
    Friend WithEvents grpCompletedDelay As System.Windows.Forms.GroupBox
    Friend WithEvents rdoWithDelay As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWithoutDelay As System.Windows.Forms.RadioButton
    Friend WithEvents grpDelayBetween As System.Windows.Forms.GroupBox
    Friend WithEvents txtSumDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbVisitor As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtWorkStart As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtWorkEnd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtResponseLimitInHour As AMS.TextBox.NumericTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grpCompleted As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents ReportSearchToolStrip1 As ReportSearchToolStrip
End Class
