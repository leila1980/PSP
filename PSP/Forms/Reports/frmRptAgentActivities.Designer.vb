<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptAgentActivities
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.slblRowsCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.ReportSearchToolStrip1 = New ReportSearchToolStrip
        Me.rucDate = New ReportUserControl_DateInterval
        Me.VisitorID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VisitorFullName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AllComitment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConfirmedContractNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CompletedContractNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CountractCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CountractCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TakhsisCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TakhsisCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConfigedCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConfigedCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InstalledCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InstalledCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InstalledAndInstallConfirmedCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InstalledAndInstallConfirmedCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CanceledCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CanceledCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InstalledAndCanceledCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDeviceCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDeviceCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoTakhsisCount_UntilDateTo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoConfigedCount_UntilDateTo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoInstalledCount_UntilDateTo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoInstallConfirmedCount_UntilDateTo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgv)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1060, 595)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VisitorID, Me.VisitorFullName, Me.AllComitment, Me.ConfirmedContractNumber, Me.CompletedContractNumber, Me.CountractCount_UntilDateFrom, Me.CountractCount_Between, Me.AccountCount_UntilDateFrom, Me.AccountCount_Between, Me.TakhsisCount_UntilDateFrom, Me.TakhsisCount_Between, Me.ConfigedCount_UntilDateFrom, Me.ConfigedCount_Between, Me.InstalledCount_UntilDateFrom, Me.InstalledCount_Between, Me.InstalledAndInstallConfirmedCount_UntilDateFrom, Me.InstalledAndInstallConfirmedCount_Between, Me.CanceledCount_UntilDateFrom, Me.CanceledCount_Between, Me.InstalledAndCanceledCount_Between, Me.TotalDeviceCount_UntilDateFrom, Me.TotalDeviceCount_Between, Me.NoTakhsisCount_UntilDateTo, Me.NoConfigedCount_UntilDateTo, Me.NoInstalledCount_UntilDateTo, Me.NoInstallConfirmedCount_UntilDateTo})
        Me.dgv.Location = New System.Drawing.Point(7, 20)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(1047, 569)
        Me.dgv.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblCount, Me.slblRowsCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 727)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1094, 22)
        Me.StatusStrip1.TabIndex = 38
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
        'lblCount
        '
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(10, 17)
        Me.lblCount.Text = " "
        '
        'slblRowsCount
        '
        Me.slblRowsCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblRowsCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.slblRowsCount.Name = "slblRowsCount"
        Me.slblRowsCount.Size = New System.Drawing.Size(0, 17)
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(808, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "پروژه"
        '
        'cmbProject
        '
        Me.cmbProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(627, 43)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(178, 21)
        Me.cmbProject.TabIndex = 44
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
        Me.ReportSearchToolStrip1.Size = New System.Drawing.Size(1094, 24)
        Me.ReportSearchToolStrip1.TabIndex = 41
        '
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.Location = New System.Drawing.Point(851, 25)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(233, 109)
        Me.rucDate.TabIndex = 39
        '
        'VisitorID
        '
        Me.VisitorID.DataPropertyName = "VisitorID"
        Me.VisitorID.HeaderText = "VisitorID"
        Me.VisitorID.Name = "VisitorID"
        Me.VisitorID.ReadOnly = True
        Me.VisitorID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VisitorID.Visible = False
        '
        'VisitorFullName
        '
        Me.VisitorFullName.DataPropertyName = "VisitorFullName"
        Me.VisitorFullName.HeaderText = "نماینده"
        Me.VisitorFullName.Name = "VisitorFullName"
        Me.VisitorFullName.ReadOnly = True
        Me.VisitorFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.VisitorFullName.Width = 250
        '
        'AllComitment
        '
        Me.AllComitment.DataPropertyName = "AllComitment"
        Me.AllComitment.HeaderText = "تعداد کل تعهد"
        Me.AllComitment.Name = "AllComitment"
        Me.AllComitment.ReadOnly = True
        Me.AllComitment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ConfirmedContractNumber
        '
        Me.ConfirmedContractNumber.DataPropertyName = "ConfirmedContractNumber"
        Me.ConfirmedContractNumber.HeaderText = "تعداد کل قرار داد ها"
        Me.ConfirmedContractNumber.Name = "ConfirmedContractNumber"
        Me.ConfirmedContractNumber.ReadOnly = True
        Me.ConfirmedContractNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CompletedContractNumber
        '
        Me.CompletedContractNumber.DataPropertyName = "CompletedContractNumber"
        Me.CompletedContractNumber.HeaderText = "تعداد قراردادهای منعقده کامل "
        Me.CompletedContractNumber.Name = "CompletedContractNumber"
        Me.CompletedContractNumber.ReadOnly = True
        Me.CompletedContractNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CountractCount_UntilDateFrom
        '
        Me.CountractCount_UntilDateFrom.DataPropertyName = "CountractCount_UntilDateFrom"
        Me.CountractCount_UntilDateFrom.HeaderText = "تعداد قراردادهای ثبت شده تا ابتدای بازه"
        Me.CountractCount_UntilDateFrom.Name = "CountractCount_UntilDateFrom"
        Me.CountractCount_UntilDateFrom.ReadOnly = True
        Me.CountractCount_UntilDateFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CountractCount_Between
        '
        Me.CountractCount_Between.DataPropertyName = "CountractCount_Between"
        Me.CountractCount_Between.HeaderText = "تعداد قراردادهای ثبت شده در بازه"
        Me.CountractCount_Between.Name = "CountractCount_Between"
        Me.CountractCount_Between.ReadOnly = True
        Me.CountractCount_Between.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AccountCount_UntilDateFrom
        '
        Me.AccountCount_UntilDateFrom.DataPropertyName = "AccountCount_UntilDateFrom"
        Me.AccountCount_UntilDateFrom.HeaderText = "تعداد حساب دار ها تا ابتدای بازه"
        Me.AccountCount_UntilDateFrom.Name = "AccountCount_UntilDateFrom"
        Me.AccountCount_UntilDateFrom.ReadOnly = True
        Me.AccountCount_UntilDateFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AccountCount_Between
        '
        Me.AccountCount_Between.DataPropertyName = "AccountCount_Between"
        Me.AccountCount_Between.HeaderText = "تعداد حساب دارها در بازه"
        Me.AccountCount_Between.Name = "AccountCount_Between"
        Me.AccountCount_Between.ReadOnly = True
        Me.AccountCount_Between.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TakhsisCount_UntilDateFrom
        '
        Me.TakhsisCount_UntilDateFrom.DataPropertyName = "TakhsisCount_UntilDateFrom"
        Me.TakhsisCount_UntilDateFrom.HeaderText = "تعداد تخصیص داده شده تا ابتدای بازه"
        Me.TakhsisCount_UntilDateFrom.Name = "TakhsisCount_UntilDateFrom"
        Me.TakhsisCount_UntilDateFrom.ReadOnly = True
        Me.TakhsisCount_UntilDateFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TakhsisCount_Between
        '
        Me.TakhsisCount_Between.DataPropertyName = "TakhsisCount_Between"
        Me.TakhsisCount_Between.HeaderText = "تعداد تخصیص داده شده در بازه"
        Me.TakhsisCount_Between.Name = "TakhsisCount_Between"
        Me.TakhsisCount_Between.ReadOnly = True
        Me.TakhsisCount_Between.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ConfigedCount_UntilDateFrom
        '
        Me.ConfigedCount_UntilDateFrom.DataPropertyName = "ConfigedCount_UntilDateFrom"
        Me.ConfigedCount_UntilDateFrom.HeaderText = "تعداد پیکربندی شده در سوئیچ تا ابتدای بازه"
        Me.ConfigedCount_UntilDateFrom.Name = "ConfigedCount_UntilDateFrom"
        Me.ConfigedCount_UntilDateFrom.ReadOnly = True
        Me.ConfigedCount_UntilDateFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ConfigedCount_Between
        '
        Me.ConfigedCount_Between.DataPropertyName = "ConfigedCount_Between"
        Me.ConfigedCount_Between.HeaderText = "تعدا پیکربندی شده در سوئیچ در بازه"
        Me.ConfigedCount_Between.Name = "ConfigedCount_Between"
        Me.ConfigedCount_Between.ReadOnly = True
        Me.ConfigedCount_Between.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'InstalledCount_UntilDateFrom
        '
        Me.InstalledCount_UntilDateFrom.DataPropertyName = "InstalledCount_UntilDateFrom"
        Me.InstalledCount_UntilDateFrom.HeaderText = "تعداد نصب شده تا ابتدای بازه"
        Me.InstalledCount_UntilDateFrom.Name = "InstalledCount_UntilDateFrom"
        Me.InstalledCount_UntilDateFrom.ReadOnly = True
        Me.InstalledCount_UntilDateFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'InstalledCount_Between
        '
        Me.InstalledCount_Between.DataPropertyName = "InstalledCount_Between"
        Me.InstalledCount_Between.HeaderText = "تعداد نصب شده در بازه"
        Me.InstalledCount_Between.Name = "InstalledCount_Between"
        Me.InstalledCount_Between.ReadOnly = True
        Me.InstalledCount_Between.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'InstalledAndInstallConfirmedCount_UntilDateFrom
        '
        Me.InstalledAndInstallConfirmedCount_UntilDateFrom.DataPropertyName = "InstalledAndInstallConfirmedCount_UntilDateFrom"
        Me.InstalledAndInstallConfirmedCount_UntilDateFrom.HeaderText = "تعداد تایید نصب شده  تا ابتدای بازه"
        Me.InstalledAndInstallConfirmedCount_UntilDateFrom.Name = "InstalledAndInstallConfirmedCount_UntilDateFrom"
        Me.InstalledAndInstallConfirmedCount_UntilDateFrom.ReadOnly = True
        '
        'InstalledAndInstallConfirmedCount_Between
        '
        Me.InstalledAndInstallConfirmedCount_Between.DataPropertyName = "InstalledAndInstallConfirmedCount_Between"
        Me.InstalledAndInstallConfirmedCount_Between.HeaderText = "تعداد تایید نصب شده  در بازه"
        Me.InstalledAndInstallConfirmedCount_Between.Name = "InstalledAndInstallConfirmedCount_Between"
        Me.InstalledAndInstallConfirmedCount_Between.ReadOnly = True
        '
        'CanceledCount_UntilDateFrom
        '
        Me.CanceledCount_UntilDateFrom.DataPropertyName = "CanceledCount_UntilDateFrom"
        Me.CanceledCount_UntilDateFrom.HeaderText = "تعدا فسخ شده تا ابتدای بازه"
        Me.CanceledCount_UntilDateFrom.Name = "CanceledCount_UntilDateFrom"
        Me.CanceledCount_UntilDateFrom.ReadOnly = True
        Me.CanceledCount_UntilDateFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CanceledCount_Between
        '
        Me.CanceledCount_Between.DataPropertyName = "CanceledCount_Between"
        Me.CanceledCount_Between.HeaderText = "تعداد فسخ شده در بازه"
        Me.CanceledCount_Between.Name = "CanceledCount_Between"
        Me.CanceledCount_Between.ReadOnly = True
        Me.CanceledCount_Between.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'InstalledAndCanceledCount_Between
        '
        Me.InstalledAndCanceledCount_Between.DataPropertyName = "InstalledAndCanceledCount_Between"
        Me.InstalledAndCanceledCount_Between.HeaderText = "تعداد فسخ شده در بازه که در همین بازه  نصب شده اند"
        Me.InstalledAndCanceledCount_Between.Name = "InstalledAndCanceledCount_Between"
        Me.InstalledAndCanceledCount_Between.ReadOnly = True
        Me.InstalledAndCanceledCount_Between.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TotalDeviceCount_UntilDateFrom
        '
        Me.TotalDeviceCount_UntilDateFrom.DataPropertyName = "TotalDeviceCount_UntilDateFrom"
        Me.TotalDeviceCount_UntilDateFrom.HeaderText = "تعدا کل دستگاههای درخواستی تا ابتدای بازه"
        Me.TotalDeviceCount_UntilDateFrom.Name = "TotalDeviceCount_UntilDateFrom"
        Me.TotalDeviceCount_UntilDateFrom.ReadOnly = True
        Me.TotalDeviceCount_UntilDateFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TotalDeviceCount_Between
        '
        Me.TotalDeviceCount_Between.DataPropertyName = "TotalDeviceCount_Between"
        Me.TotalDeviceCount_Between.HeaderText = "تعداد دستگاههای درخواستی در بازه"
        Me.TotalDeviceCount_Between.Name = "TotalDeviceCount_Between"
        Me.TotalDeviceCount_Between.ReadOnly = True
        Me.TotalDeviceCount_Between.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NoTakhsisCount_UntilDateTo
        '
        Me.NoTakhsisCount_UntilDateTo.DataPropertyName = "NoTakhsisCount_UntilDateTo"
        Me.NoTakhsisCount_UntilDateTo.HeaderText = "تعداد تخصیص داده نشده تا انتهای بازه"
        Me.NoTakhsisCount_UntilDateTo.Name = "NoTakhsisCount_UntilDateTo"
        Me.NoTakhsisCount_UntilDateTo.ReadOnly = True
        Me.NoTakhsisCount_UntilDateTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NoConfigedCount_UntilDateTo
        '
        Me.NoConfigedCount_UntilDateTo.DataPropertyName = "NoConfigedCount_UntilDateTo"
        Me.NoConfigedCount_UntilDateTo.HeaderText = "تعداد پیکربندی نشده تا انتهای بازه"
        Me.NoConfigedCount_UntilDateTo.Name = "NoConfigedCount_UntilDateTo"
        Me.NoConfigedCount_UntilDateTo.ReadOnly = True
        Me.NoConfigedCount_UntilDateTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NoInstalledCount_UntilDateTo
        '
        Me.NoInstalledCount_UntilDateTo.DataPropertyName = "NoInstalledCount_UntilDateTo"
        Me.NoInstalledCount_UntilDateTo.HeaderText = "تعداد نصب نشده تا انتهای بازه"
        Me.NoInstalledCount_UntilDateTo.Name = "NoInstalledCount_UntilDateTo"
        Me.NoInstalledCount_UntilDateTo.ReadOnly = True
        Me.NoInstalledCount_UntilDateTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NoInstallConfirmedCount_UntilDateTo
        '
        Me.NoInstallConfirmedCount_UntilDateTo.DataPropertyName = "NoInstallConfirmedCount_UntilDateTo"
        Me.NoInstallConfirmedCount_UntilDateTo.HeaderText = "تعداد تایید نصب نشده تا انتهای بازه"
        Me.NoInstallConfirmedCount_UntilDateTo.Name = "NoInstallConfirmedCount_UntilDateTo"
        Me.NoInstallConfirmedCount_UntilDateTo.ReadOnly = True
        Me.NoInstallConfirmedCount_UntilDateTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frmRptAgentActivities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 749)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbProject)
        Me.Controls.Add(Me.ReportSearchToolStrip1)
        Me.Controls.Add(Me.rucDate)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmRptAgentActivities"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " گزارش عملکرد نمایندگان"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slblRowsCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents rucDate As ReportUserControl_DateInterval
    Friend WithEvents ReportSearchToolStrip1 As ReportSearchToolStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents VisitorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VisitorFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AllComitment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfirmedContractNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompletedContractNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CountractCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CountractCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TakhsisCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TakhsisCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfigedCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfigedCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstalledCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstalledCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstalledAndInstallConfirmedCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstalledAndInstallConfirmedCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CanceledCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CanceledCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstalledAndCanceledCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDeviceCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDeviceCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoTakhsisCount_UntilDateTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoConfigedCount_UntilDateTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoInstalledCount_UntilDateTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoInstallConfirmedCount_UntilDateTo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
