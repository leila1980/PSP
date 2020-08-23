<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptCallsInfoDelayOld
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptCallsInfoDelayOld))
        Me.txtEniacCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnView = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnPrint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnChart = New System.Windows.Forms.ToolStripButton
        Me.grpDelay = New System.Windows.Forms.GroupBox
        Me.grpCompleted = New System.Windows.Forms.GroupBox
        Me.txtSumDelay = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpDelayBetween = New System.Windows.Forms.GroupBox
        Me.txtSTime = New Timing
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtETime = New Timing
        Me.Label3 = New System.Windows.Forms.Label
        Me.rdoWithDelay = New System.Windows.Forms.RadioButton
        Me.rdoWithoutDelay = New System.Windows.Forms.RadioButton
        Me.rdoNotCompleted = New System.Windows.Forms.RadioButton
        Me.rdoComleted = New System.Windows.Forms.RadioButton
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboStateID = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCnt = New System.Windows.Forms.ToolStripStatusLabel
        Me.slblRowsCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.rucDate = New ReportUserControl_DateInterval
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.grpDelay.SuspendLayout()
        Me.grpCompleted.SuspendLayout()
        Me.grpDelayBetween.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtEniacCode
        '
        Me.txtEniacCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEniacCode.Location = New System.Drawing.Point(698, 105)
        Me.txtEniacCode.Name = "txtEniacCode"
        Me.txtEniacCode.Size = New System.Drawing.Size(250, 21)
        Me.txtEniacCode.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(951, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "کد انیاک :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvReport)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(985, 349)
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
        Me.dgvReport.Size = New System.Drawing.Size(973, 322)
        Me.dgvReport.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnView, Me.ToolStripSeparator3, Me.btnExportToExcel, Me.ToolStripSeparator1, Me.btnPrint, Me.ToolStripSeparator2, Me.btnChart})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1009, 25)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnView
        '
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(67, 22)
        Me.btnView.Text = "مشاهده"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'btnChart
        '
        Me.btnChart.Image = CType(resources.GetObject("btnChart.Image"), System.Drawing.Image)
        Me.btnChart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnChart.Name = "btnChart"
        Me.btnChart.Size = New System.Drawing.Size(54, 22)
        Me.btnChart.Text = "نمودار"
        Me.btnChart.Visible = False
        '
        'grpDelay
        '
        Me.grpDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDelay.Controls.Add(Me.grpCompleted)
        Me.grpDelay.Controls.Add(Me.rdoNotCompleted)
        Me.grpDelay.Controls.Add(Me.rdoComleted)
        Me.grpDelay.Location = New System.Drawing.Point(12, 28)
        Me.grpDelay.Name = "grpDelay"
        Me.grpDelay.Size = New System.Drawing.Size(435, 106)
        Me.grpDelay.TabIndex = 23
        Me.grpDelay.TabStop = False
        '
        'grpCompleted
        '
        Me.grpCompleted.Controls.Add(Me.txtSumDelay)
        Me.grpCompleted.Controls.Add(Me.Label2)
        Me.grpCompleted.Controls.Add(Me.grpDelayBetween)
        Me.grpCompleted.Controls.Add(Me.rdoWithDelay)
        Me.grpCompleted.Controls.Add(Me.rdoWithoutDelay)
        Me.grpCompleted.Location = New System.Drawing.Point(6, 8)
        Me.grpCompleted.Name = "grpCompleted"
        Me.grpCompleted.Size = New System.Drawing.Size(340, 90)
        Me.grpCompleted.TabIndex = 10
        Me.grpCompleted.TabStop = False
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
        Me.grpDelayBetween.Controls.Add(Me.txtSTime)
        Me.grpDelayBetween.Controls.Add(Me.Label4)
        Me.grpDelayBetween.Controls.Add(Me.txtETime)
        Me.grpDelayBetween.Controls.Add(Me.Label3)
        Me.grpDelayBetween.Location = New System.Drawing.Point(6, 10)
        Me.grpDelayBetween.Name = "grpDelayBetween"
        Me.grpDelayBetween.Size = New System.Drawing.Size(140, 72)
        Me.grpDelayBetween.TabIndex = 13
        Me.grpDelayBetween.TabStop = False
        '
        'txtSTime
        '
        Me.txtSTime.Hour = ""
        Me.txtSTime.Location = New System.Drawing.Point(6, 9)
        Me.txtSTime.Min = ""
        Me.txtSTime.Name = "txtSTime"
        Me.txtSTime.Size = New System.Drawing.Size(110, 26)
        Me.txtSTime.TabIndex = 6
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
        'txtETime
        '
        Me.txtETime.Hour = ""
        Me.txtETime.Location = New System.Drawing.Point(6, 39)
        Me.txtETime.Min = ""
        Me.txtETime.Name = "txtETime"
        Me.txtETime.Size = New System.Drawing.Size(110, 26)
        Me.txtETime.TabIndex = 7
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
        Me.rdoWithDelay.TabIndex = 12
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
        Me.rdoWithoutDelay.TabIndex = 11
        Me.rdoWithoutDelay.TabStop = True
        Me.rdoWithoutDelay.Text = "بدون تاخير"
        Me.rdoWithoutDelay.UseVisualStyleBackColor = True
        '
        'rdoNotCompleted
        '
        Me.rdoNotCompleted.AutoSize = True
        Me.rdoNotCompleted.Location = New System.Drawing.Point(352, 17)
        Me.rdoNotCompleted.Name = "rdoNotCompleted"
        Me.rdoNotCompleted.Size = New System.Drawing.Size(74, 17)
        Me.rdoNotCompleted.TabIndex = 9
        Me.rdoNotCompleted.TabStop = True
        Me.rdoNotCompleted.Text = "تمام نشده"
        Me.rdoNotCompleted.UseVisualStyleBackColor = True
        '
        'rdoComleted
        '
        Me.rdoComleted.AutoSize = True
        Me.rdoComleted.Location = New System.Drawing.Point(356, 38)
        Me.rdoComleted.Name = "rdoComleted"
        Me.rdoComleted.Size = New System.Drawing.Size(70, 17)
        Me.rdoComleted.TabIndex = 8
        Me.rdoComleted.TabStop = True
        Me.rdoComleted.Text = "تمام شده"
        Me.rdoComleted.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cboStateID
        '
        Me.cboStateID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStateID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStateID.FormattingEnabled = True
        Me.cboStateID.Location = New System.Drawing.Point(698, 81)
        Me.cboStateID.Name = "cboStateID"
        Me.cboStateID.Size = New System.Drawing.Size(250, 21)
        Me.cboStateID.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(952, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "استان :"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblCnt, Me.slblRowsCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 491)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1009, 22)
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
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.Location = New System.Drawing.Point(453, 28)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(229, 109)
        Me.rucDate.TabIndex = 17
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.cmbProject)
        Me.GroupBox4.Location = New System.Drawing.Point(680, 28)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(317, 51)
        Me.GroupBox4.TabIndex = 39
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
        'frmRptCallsInfoDelay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 513)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cboStateID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grpDelay)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEniacCode)
        Me.Controls.Add(Me.rucDate)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRptCallsInfoDelay"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش تاخیر بخش فنی "
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpDelay.ResumeLayout(False)
        Me.grpDelay.PerformLayout()
        Me.grpCompleted.ResumeLayout(False)
        Me.grpCompleted.PerformLayout()
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
    Friend WithEvents txtEniacCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnView As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnChart As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpDelay As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboStateID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCnt As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slblRowsCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtSTime As Timing
    Friend WithEvents txtETime As Timing
    Friend WithEvents rdoNotCompleted As System.Windows.Forms.RadioButton
    Friend WithEvents rdoComleted As System.Windows.Forms.RadioButton
    Friend WithEvents grpCompleted As System.Windows.Forms.GroupBox
    Friend WithEvents rdoWithDelay As System.Windows.Forms.RadioButton
    Friend WithEvents rdoWithoutDelay As System.Windows.Forms.RadioButton
    Friend WithEvents grpDelayBetween As System.Windows.Forms.GroupBox
    Friend WithEvents txtSumDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
End Class
