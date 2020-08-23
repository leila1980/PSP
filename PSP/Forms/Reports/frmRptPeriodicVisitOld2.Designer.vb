<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptPeriodicVisitOld2
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtNegativeTelorance = New AMS.TextBox.NumericTextBox
        Me.txtPositiveTelorance = New AMS.TextBox.NumericTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMonth = New AMS.TextBox.NumericTextBox
        Me.txtMaxPrice = New AMS.TextBox.NumericTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.erp = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdoBasedOnInstall = New System.Windows.Forms.RadioButton
        Me.rdoBasedOnLastVisit = New System.Windows.Forms.RadioButton
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkCutCorrectPeriod = New System.Windows.Forms.CheckBox
        Me.rucDate = New ReportUserControl_DateInterval
        Me.ReportSearchToolStrip1 = New ReportSearchToolStrip
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtNegativeTelorance)
        Me.GroupBox2.Controls.Add(Me.txtPositiveTelorance)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtMonth)
        Me.GroupBox2.Controls.Add(Me.txtMaxPrice)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(202, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(251, 100)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "روز"
        '
        'txtNegativeTelorance
        '
        Me.txtNegativeTelorance.AllowNegative = True
        Me.txtNegativeTelorance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNegativeTelorance.DigitsInGroup = 0
        Me.txtNegativeTelorance.Flags = 0
        Me.txtNegativeTelorance.Location = New System.Drawing.Point(91, 69)
        Me.txtNegativeTelorance.MaxDecimalPlaces = 4
        Me.txtNegativeTelorance.MaxWholeDigits = 9
        Me.txtNegativeTelorance.Name = "txtNegativeTelorance"
        Me.txtNegativeTelorance.Prefix = ""
        Me.txtNegativeTelorance.RangeMax = 1.7976931348623157E+308
        Me.txtNegativeTelorance.RangeMin = -1.7976931348623157E+308
        Me.txtNegativeTelorance.Size = New System.Drawing.Size(26, 21)
        Me.txtNegativeTelorance.TabIndex = 2
        '
        'txtPositiveTelorance
        '
        Me.txtPositiveTelorance.AllowNegative = True
        Me.txtPositiveTelorance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPositiveTelorance.DigitsInGroup = 0
        Me.txtPositiveTelorance.Flags = 0
        Me.txtPositiveTelorance.Location = New System.Drawing.Point(36, 69)
        Me.txtPositiveTelorance.MaxDecimalPlaces = 4
        Me.txtPositiveTelorance.MaxWholeDigits = 9
        Me.txtPositiveTelorance.Name = "txtPositiveTelorance"
        Me.txtPositiveTelorance.Prefix = ""
        Me.txtPositiveTelorance.RangeMax = 1.7976931348623157E+308
        Me.txtPositiveTelorance.RangeMin = -1.7976931348623157E+308
        Me.txtPositiveTelorance.Size = New System.Drawing.Size(26, 21)
        Me.txtPositiveTelorance.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(63, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "تا"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(120, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "از"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(133, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "تلورانس:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "ماه"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(122, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "تعداد فواصل بازدید:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(123, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "حدکثر مبلغ تراکنش بازدید:"
        '
        'txtMonth
        '
        Me.txtMonth.AllowNegative = True
        Me.txtMonth.DigitsInGroup = 0
        Me.txtMonth.Flags = 0
        Me.txtMonth.Location = New System.Drawing.Point(36, 42)
        Me.txtMonth.MaxDecimalPlaces = 4
        Me.txtMonth.MaxWholeDigits = 9
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Prefix = ""
        Me.txtMonth.RangeMax = 1.7976931348623157E+308
        Me.txtMonth.RangeMin = -1.7976931348623157E+308
        Me.txtMonth.Size = New System.Drawing.Size(81, 21)
        Me.txtMonth.TabIndex = 1
        '
        'txtMaxPrice
        '
        Me.txtMaxPrice.AllowNegative = True
        Me.txtMaxPrice.DigitsInGroup = 0
        Me.txtMaxPrice.Flags = 0
        Me.txtMaxPrice.Location = New System.Drawing.Point(36, 12)
        Me.txtMaxPrice.MaxDecimalPlaces = 4
        Me.txtMaxPrice.MaxWholeDigits = 9
        Me.txtMaxPrice.Name = "txtMaxPrice"
        Me.txtMaxPrice.Prefix = ""
        Me.txtMaxPrice.RangeMax = 1.7976931348623157E+308
        Me.txtMaxPrice.RangeMin = -1.7976931348623157E+308
        Me.txtMaxPrice.Size = New System.Drawing.Size(81, 21)
        Me.txtMaxPrice.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ریال"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgv)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 137)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(832, 316)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(3, 17)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(826, 296)
        Me.dgv.TabIndex = 0
        '
        'erp
        '
        Me.erp.ContainerControl = Me
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 456)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(833, 22)
        Me.StatusStrip1.TabIndex = 50
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(34, 17)
        Me.ToolStripStatusLabel1.Text = "تعداد:"
        '
        'lblCount
        '
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 17)
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rdoBasedOnInstall)
        Me.GroupBox3.Controls.Add(Me.rdoBasedOnLastVisit)
        Me.GroupBox3.Location = New System.Drawing.Point(686, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(146, 100)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'rdoBasedOnInstall
        '
        Me.rdoBasedOnInstall.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoBasedOnInstall.AutoSize = True
        Me.rdoBasedOnInstall.Location = New System.Drawing.Point(39, 26)
        Me.rdoBasedOnInstall.Name = "rdoBasedOnInstall"
        Me.rdoBasedOnInstall.Size = New System.Drawing.Size(91, 17)
        Me.rdoBasedOnInstall.TabIndex = 0
        Me.rdoBasedOnInstall.TabStop = True
        Me.rdoBasedOnInstall.Text = "بر اساس نصب"
        Me.rdoBasedOnInstall.UseVisualStyleBackColor = True
        '
        'rdoBasedOnLastVisit
        '
        Me.rdoBasedOnLastVisit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoBasedOnLastVisit.AutoSize = True
        Me.rdoBasedOnLastVisit.Location = New System.Drawing.Point(9, 60)
        Me.rdoBasedOnLastVisit.Name = "rdoBasedOnLastVisit"
        Me.rdoBasedOnLastVisit.Size = New System.Drawing.Size(122, 17)
        Me.rdoBasedOnLastVisit.TabIndex = 1
        Me.rdoBasedOnLastVisit.TabStop = True
        Me.rdoBasedOnLastVisit.Text = "بر اساس آخرین بازدید"
        Me.rdoBasedOnLastVisit.UseVisualStyleBackColor = True
        '
        'cmbProject
        '
        Me.cmbProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(2, 37)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(157, 21)
        Me.cmbProject.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(162, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "پروژه :"
        '
        'chkCutCorrectPeriod
        '
        Me.chkCutCorrectPeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkCutCorrectPeriod.AutoSize = True
        Me.chkCutCorrectPeriod.Location = New System.Drawing.Point(-69, 70)
        Me.chkCutCorrectPeriod.Name = "chkCutCorrectPeriod"
        Me.chkCutCorrectPeriod.Size = New System.Drawing.Size(265, 17)
        Me.chkCutCorrectPeriod.TabIndex = 4
        Me.chkCutCorrectPeriod.Text = "بازه صحیح بازدید هر دستگاه به بازه بازدید محدود شود"
        Me.chkCutCorrectPeriod.UseVisualStyleBackColor = True
        '
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.Location = New System.Drawing.Point(455, 29)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(228, 102)
        Me.rucDate.TabIndex = 1
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
        Me.ReportSearchToolStrip1.Size = New System.Drawing.Size(833, 24)
        Me.ReportSearchToolStrip1.TabIndex = 40
        '
        'frmRptPeriodicVisit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 478)
        Me.Controls.Add(Me.chkCutCorrectPeriod)
        Me.Controls.Add(Me.cmbProject)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.rucDate)
        Me.Controls.Add(Me.ReportSearchToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmRptPeriodicVisit"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش بازدید ادواری"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rucDate As ReportUserControl_DateInterval
    Friend WithEvents ReportSearchToolStrip1 As ReportSearchToolStrip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents erp As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtMonth As AMS.TextBox.NumericTextBox
    Friend WithEvents txtMaxPrice As AMS.TextBox.NumericTextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoBasedOnInstall As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBasedOnLastVisit As System.Windows.Forms.RadioButton
    Friend WithEvents txtNegativeTelorance As AMS.TextBox.NumericTextBox
    Friend WithEvents txtPositiveTelorance As AMS.TextBox.NumericTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkCutCorrectPeriod As System.Windows.Forms.CheckBox
End Class
