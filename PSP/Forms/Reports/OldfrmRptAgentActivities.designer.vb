<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OldfrmRptAgentActivities
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
        Me.GrpSumCount = New System.Windows.Forms.GroupBox
        Me.lblSumAccountCount_Between = New System.Windows.Forms.Label
        Me.lblSumCountractCount_Between = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblSumTotalDeviceCount = New System.Windows.Forms.Label
        Me.lblSumInstalledAndCanceledCount_Between = New System.Windows.Forms.Label
        Me.lblSumCanceledCount_Between = New System.Windows.Forms.Label
        Me.lblSumCanceledCount_UntilDateFrom = New System.Windows.Forms.Label
        Me.lblSumInstallConfirmedCount_Between = New System.Windows.Forms.Label
        Me.lblSumInstallConfirmedCount_UntilDateFrom = New System.Windows.Forms.Label
        Me.lblSumInstalledCount_Between = New System.Windows.Forms.Label
        Me.lblSumInstalledCount_UntilDateFrom = New System.Windows.Forms.Label
        Me.lblSumConfigedCount_Between = New System.Windows.Forms.Label
        Me.lblSumConfigedCount_UntilDateFrom = New System.Windows.Forms.Label
        Me.lblSumTakhsisCount_Between = New System.Windows.Forms.Label
        Me.lblSumTakhsisCount_UntilDateFrom = New System.Windows.Forms.Label
        Me.lblSumAccountCount_UntilDateFrom = New System.Windows.Forms.Label
        Me.lblSumCountractCount_UntilDateFrom = New System.Windows.Forms.Label
        Me.lblSumCompletedContractNumber = New System.Windows.Forms.Label
        Me.lblSumConfirmedContractNumber = New System.Windows.Forms.Label
        Me.lblSumAllComitment = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgv = New System.Windows.Forms.DataGridView
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
        Me.InstallConfirmedCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InstallConfirmedCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CanceledCount_UntilDateFrom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CanceledCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InstalledAndCanceledCount_Between = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDeviceCount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.slblRowsCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.ReportSearchToolStrip1 = New ReportSearchToolStrip
        Me.rucDate = New ReportUserControl_DateInterval
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GrpSumCount.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GrpSumCount)
        Me.GroupBox1.Controls.Add(Me.dgv)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1318, 590)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'GrpSumCount
        '
        Me.GrpSumCount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSumCount.Controls.Add(Me.lblSumAccountCount_Between)
        Me.GrpSumCount.Controls.Add(Me.lblSumCountractCount_Between)
        Me.GrpSumCount.Controls.Add(Me.Label21)
        Me.GrpSumCount.Controls.Add(Me.Label22)
        Me.GrpSumCount.Controls.Add(Me.lblSumTotalDeviceCount)
        Me.GrpSumCount.Controls.Add(Me.lblSumInstalledAndCanceledCount_Between)
        Me.GrpSumCount.Controls.Add(Me.lblSumCanceledCount_Between)
        Me.GrpSumCount.Controls.Add(Me.lblSumCanceledCount_UntilDateFrom)
        Me.GrpSumCount.Controls.Add(Me.lblSumInstallConfirmedCount_Between)
        Me.GrpSumCount.Controls.Add(Me.lblSumInstallConfirmedCount_UntilDateFrom)
        Me.GrpSumCount.Controls.Add(Me.lblSumInstalledCount_Between)
        Me.GrpSumCount.Controls.Add(Me.lblSumInstalledCount_UntilDateFrom)
        Me.GrpSumCount.Controls.Add(Me.lblSumConfigedCount_Between)
        Me.GrpSumCount.Controls.Add(Me.lblSumConfigedCount_UntilDateFrom)
        Me.GrpSumCount.Controls.Add(Me.lblSumTakhsisCount_Between)
        Me.GrpSumCount.Controls.Add(Me.lblSumTakhsisCount_UntilDateFrom)
        Me.GrpSumCount.Controls.Add(Me.lblSumAccountCount_UntilDateFrom)
        Me.GrpSumCount.Controls.Add(Me.lblSumCountractCount_UntilDateFrom)
        Me.GrpSumCount.Controls.Add(Me.lblSumCompletedContractNumber)
        Me.GrpSumCount.Controls.Add(Me.lblSumConfirmedContractNumber)
        Me.GrpSumCount.Controls.Add(Me.lblSumAllComitment)
        Me.GrpSumCount.Controls.Add(Me.Label19)
        Me.GrpSumCount.Controls.Add(Me.Label20)
        Me.GrpSumCount.Controls.Add(Me.Label15)
        Me.GrpSumCount.Controls.Add(Me.Label16)
        Me.GrpSumCount.Controls.Add(Me.Label11)
        Me.GrpSumCount.Controls.Add(Me.Label12)
        Me.GrpSumCount.Controls.Add(Me.Label13)
        Me.GrpSumCount.Controls.Add(Me.Label14)
        Me.GrpSumCount.Controls.Add(Me.Label9)
        Me.GrpSumCount.Controls.Add(Me.Label10)
        Me.GrpSumCount.Controls.Add(Me.Label8)
        Me.GrpSumCount.Controls.Add(Me.Label5)
        Me.GrpSumCount.Controls.Add(Me.Label6)
        Me.GrpSumCount.Controls.Add(Me.Label7)
        Me.GrpSumCount.Controls.Add(Me.Label4)
        Me.GrpSumCount.Controls.Add(Me.Label3)
        Me.GrpSumCount.Controls.Add(Me.Label2)
        Me.GrpSumCount.Location = New System.Drawing.Point(8, 466)
        Me.GrpSumCount.Name = "GrpSumCount"
        Me.GrpSumCount.Size = New System.Drawing.Size(1304, 116)
        Me.GrpSumCount.TabIndex = 37
        Me.GrpSumCount.TabStop = False
        '
        'lblSumAccountCount_Between
        '
        Me.lblSumAccountCount_Between.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumAccountCount_Between.AutoSize = True
        Me.lblSumAccountCount_Between.Location = New System.Drawing.Point(845, 93)
        Me.lblSumAccountCount_Between.Name = "lblSumAccountCount_Between"
        Me.lblSumAccountCount_Between.Size = New System.Drawing.Size(0, 13)
        Me.lblSumAccountCount_Between.TabIndex = 40
        '
        'lblSumCountractCount_Between
        '
        Me.lblSumCountractCount_Between.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumCountractCount_Between.AutoSize = True
        Me.lblSumCountractCount_Between.Location = New System.Drawing.Point(845, 43)
        Me.lblSumCountractCount_Between.Name = "lblSumCountractCount_Between"
        Me.lblSumCountractCount_Between.Size = New System.Drawing.Size(0, 13)
        Me.lblSumCountractCount_Between.TabIndex = 39
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(898, 93)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(121, 13)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "جمع حساب دارها در بازه:"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(898, 43)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(156, 13)
        Me.Label22.TabIndex = 37
        Me.Label22.Text = "جمع قرادادهای ثبت شده در بازه:"
        '
        'lblSumTotalDeviceCount
        '
        Me.lblSumTotalDeviceCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumTotalDeviceCount.AutoSize = True
        Me.lblSumTotalDeviceCount.Location = New System.Drawing.Point(12, 92)
        Me.lblSumTotalDeviceCount.Name = "lblSumTotalDeviceCount"
        Me.lblSumTotalDeviceCount.Size = New System.Drawing.Size(0, 13)
        Me.lblSumTotalDeviceCount.TabIndex = 36
        '
        'lblSumInstalledAndCanceledCount_Between
        '
        Me.lblSumInstalledAndCanceledCount_Between.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumInstalledAndCanceledCount_Between.AutoSize = True
        Me.lblSumInstalledAndCanceledCount_Between.Location = New System.Drawing.Point(12, 68)
        Me.lblSumInstalledAndCanceledCount_Between.Name = "lblSumInstalledAndCanceledCount_Between"
        Me.lblSumInstalledAndCanceledCount_Between.Size = New System.Drawing.Size(0, 13)
        Me.lblSumInstalledAndCanceledCount_Between.TabIndex = 35
        '
        'lblSumCanceledCount_Between
        '
        Me.lblSumCanceledCount_Between.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumCanceledCount_Between.AutoSize = True
        Me.lblSumCanceledCount_Between.Location = New System.Drawing.Point(12, 43)
        Me.lblSumCanceledCount_Between.Name = "lblSumCanceledCount_Between"
        Me.lblSumCanceledCount_Between.Size = New System.Drawing.Size(0, 13)
        Me.lblSumCanceledCount_Between.TabIndex = 34
        '
        'lblSumCanceledCount_UntilDateFrom
        '
        Me.lblSumCanceledCount_UntilDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumCanceledCount_UntilDateFrom.AutoSize = True
        Me.lblSumCanceledCount_UntilDateFrom.Location = New System.Drawing.Point(12, 17)
        Me.lblSumCanceledCount_UntilDateFrom.Name = "lblSumCanceledCount_UntilDateFrom"
        Me.lblSumCanceledCount_UntilDateFrom.Size = New System.Drawing.Size(0, 13)
        Me.lblSumCanceledCount_UntilDateFrom.TabIndex = 33
        '
        'lblSumInstallConfirmedCount_Between
        '
        Me.lblSumInstallConfirmedCount_Between.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumInstallConfirmedCount_Between.AutoSize = True
        Me.lblSumInstallConfirmedCount_Between.Location = New System.Drawing.Point(288, 92)
        Me.lblSumInstallConfirmedCount_Between.Name = "lblSumInstallConfirmedCount_Between"
        Me.lblSumInstallConfirmedCount_Between.Size = New System.Drawing.Size(0, 13)
        Me.lblSumInstallConfirmedCount_Between.TabIndex = 32
        '
        'lblSumInstallConfirmedCount_UntilDateFrom
        '
        Me.lblSumInstallConfirmedCount_UntilDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumInstallConfirmedCount_UntilDateFrom.AutoSize = True
        Me.lblSumInstallConfirmedCount_UntilDateFrom.Location = New System.Drawing.Point(288, 66)
        Me.lblSumInstallConfirmedCount_UntilDateFrom.Name = "lblSumInstallConfirmedCount_UntilDateFrom"
        Me.lblSumInstallConfirmedCount_UntilDateFrom.Size = New System.Drawing.Size(0, 13)
        Me.lblSumInstallConfirmedCount_UntilDateFrom.TabIndex = 31
        '
        'lblSumInstalledCount_Between
        '
        Me.lblSumInstalledCount_Between.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumInstalledCount_Between.AutoSize = True
        Me.lblSumInstalledCount_Between.Location = New System.Drawing.Point(288, 43)
        Me.lblSumInstalledCount_Between.Name = "lblSumInstalledCount_Between"
        Me.lblSumInstalledCount_Between.Size = New System.Drawing.Size(0, 13)
        Me.lblSumInstalledCount_Between.TabIndex = 30
        '
        'lblSumInstalledCount_UntilDateFrom
        '
        Me.lblSumInstalledCount_UntilDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumInstalledCount_UntilDateFrom.AutoSize = True
        Me.lblSumInstalledCount_UntilDateFrom.Location = New System.Drawing.Point(288, 17)
        Me.lblSumInstalledCount_UntilDateFrom.Name = "lblSumInstalledCount_UntilDateFrom"
        Me.lblSumInstalledCount_UntilDateFrom.Size = New System.Drawing.Size(0, 13)
        Me.lblSumInstalledCount_UntilDateFrom.TabIndex = 29
        '
        'lblSumConfigedCount_Between
        '
        Me.lblSumConfigedCount_Between.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumConfigedCount_Between.AutoSize = True
        Me.lblSumConfigedCount_Between.Location = New System.Drawing.Point(539, 96)
        Me.lblSumConfigedCount_Between.Name = "lblSumConfigedCount_Between"
        Me.lblSumConfigedCount_Between.Size = New System.Drawing.Size(0, 13)
        Me.lblSumConfigedCount_Between.TabIndex = 28
        '
        'lblSumConfigedCount_UntilDateFrom
        '
        Me.lblSumConfigedCount_UntilDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumConfigedCount_UntilDateFrom.AutoSize = True
        Me.lblSumConfigedCount_UntilDateFrom.Location = New System.Drawing.Point(539, 66)
        Me.lblSumConfigedCount_UntilDateFrom.Name = "lblSumConfigedCount_UntilDateFrom"
        Me.lblSumConfigedCount_UntilDateFrom.Size = New System.Drawing.Size(0, 13)
        Me.lblSumConfigedCount_UntilDateFrom.TabIndex = 27
        '
        'lblSumTakhsisCount_Between
        '
        Me.lblSumTakhsisCount_Between.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumTakhsisCount_Between.AutoSize = True
        Me.lblSumTakhsisCount_Between.Location = New System.Drawing.Point(539, 43)
        Me.lblSumTakhsisCount_Between.Name = "lblSumTakhsisCount_Between"
        Me.lblSumTakhsisCount_Between.Size = New System.Drawing.Size(0, 13)
        Me.lblSumTakhsisCount_Between.TabIndex = 25
        '
        'lblSumTakhsisCount_UntilDateFrom
        '
        Me.lblSumTakhsisCount_UntilDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumTakhsisCount_UntilDateFrom.AutoSize = True
        Me.lblSumTakhsisCount_UntilDateFrom.Location = New System.Drawing.Point(539, 17)
        Me.lblSumTakhsisCount_UntilDateFrom.Name = "lblSumTakhsisCount_UntilDateFrom"
        Me.lblSumTakhsisCount_UntilDateFrom.Size = New System.Drawing.Size(0, 13)
        Me.lblSumTakhsisCount_UntilDateFrom.TabIndex = 24
        '
        'lblSumAccountCount_UntilDateFrom
        '
        Me.lblSumAccountCount_UntilDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumAccountCount_UntilDateFrom.AutoSize = True
        Me.lblSumAccountCount_UntilDateFrom.Location = New System.Drawing.Point(845, 68)
        Me.lblSumAccountCount_UntilDateFrom.Name = "lblSumAccountCount_UntilDateFrom"
        Me.lblSumAccountCount_UntilDateFrom.Size = New System.Drawing.Size(0, 13)
        Me.lblSumAccountCount_UntilDateFrom.TabIndex = 23
        '
        'lblSumCountractCount_UntilDateFrom
        '
        Me.lblSumCountractCount_UntilDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumCountractCount_UntilDateFrom.AutoSize = True
        Me.lblSumCountractCount_UntilDateFrom.Location = New System.Drawing.Point(845, 17)
        Me.lblSumCountractCount_UntilDateFrom.Name = "lblSumCountractCount_UntilDateFrom"
        Me.lblSumCountractCount_UntilDateFrom.Size = New System.Drawing.Size(0, 13)
        Me.lblSumCountractCount_UntilDateFrom.TabIndex = 22
        '
        'lblSumCompletedContractNumber
        '
        Me.lblSumCompletedContractNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumCompletedContractNumber.AutoSize = True
        Me.lblSumCompletedContractNumber.Location = New System.Drawing.Point(1103, 70)
        Me.lblSumCompletedContractNumber.Name = "lblSumCompletedContractNumber"
        Me.lblSumCompletedContractNumber.Size = New System.Drawing.Size(0, 13)
        Me.lblSumCompletedContractNumber.TabIndex = 21
        '
        'lblSumConfirmedContractNumber
        '
        Me.lblSumConfirmedContractNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumConfirmedContractNumber.AutoSize = True
        Me.lblSumConfirmedContractNumber.Location = New System.Drawing.Point(1103, 43)
        Me.lblSumConfirmedContractNumber.Name = "lblSumConfirmedContractNumber"
        Me.lblSumConfirmedContractNumber.Size = New System.Drawing.Size(0, 13)
        Me.lblSumConfirmedContractNumber.TabIndex = 20
        '
        'lblSumAllComitment
        '
        Me.lblSumAllComitment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumAllComitment.AutoSize = True
        Me.lblSumAllComitment.Location = New System.Drawing.Point(1103, 17)
        Me.lblSumAllComitment.Name = "lblSumAllComitment"
        Me.lblSumAllComitment.Size = New System.Drawing.Size(0, 13)
        Me.lblSumAllComitment.TabIndex = 19
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(65, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(191, 13)
        Me.Label19.TabIndex = 16
        Me.Label19.Text = "جمع فسخ شده های نصب شده  در بازه:"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(65, 92)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(143, 13)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "جمع دستگاههای درخواستی:"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(65, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(146, 13)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "جمع فسخ شده  تا ابتدای بازه:"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(65, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "جمع فسخ شده در بازه:"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(341, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "جمع تایید نصب شده  تا ابتدای بازه:"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(341, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "جمع تایید نصب شده در بازه:"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(341, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(146, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "جمع  نصب شده  تا ابتدای بازه:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(341, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "جمع  نصب  شده در بازه:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(592, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(165, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "جمع  پیکربندی شده  تا ابتدای بازه:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(592, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "جمع پیکربندی شده در بازه:"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(592, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(181, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "جمع  تخصیص داده شده  تا ابتدای بازه:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(592, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "جمع  تخصیص داده شده در بازه:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(898, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "جمع حساب دارها تا ابتدای بازه:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(898, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(185, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "جمع قرادادهای ثبت شده تا ابتدای بازه:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1156, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "جمع قراردادهای منعقده کامل:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1156, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "جمع کل قراردادها:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1156, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "جمع کل تعهد:"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VisitorID, Me.VisitorFullName, Me.AllComitment, Me.ConfirmedContractNumber, Me.CompletedContractNumber, Me.CountractCount_UntilDateFrom, Me.CountractCount_Between, Me.AccountCount_UntilDateFrom, Me.AccountCount_Between, Me.TakhsisCount_UntilDateFrom, Me.TakhsisCount_Between, Me.ConfigedCount_UntilDateFrom, Me.ConfigedCount_Between, Me.InstalledCount_UntilDateFrom, Me.InstalledCount_Between, Me.InstallConfirmedCount_UntilDateFrom, Me.InstallConfirmedCount_Between, Me.CanceledCount_UntilDateFrom, Me.CanceledCount_Between, Me.InstalledAndCanceledCount_Between, Me.TotalDeviceCount})
        Me.dgv.Location = New System.Drawing.Point(0, 11)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.Size = New System.Drawing.Size(1312, 449)
        Me.dgv.TabIndex = 0
        '
        'VisitorID
        '
        Me.VisitorID.DataPropertyName = "VisitorID"
        Me.VisitorID.HeaderText = "VisitorID"
        Me.VisitorID.Name = "VisitorID"
        Me.VisitorID.ReadOnly = True
        Me.VisitorID.Visible = False
        '
        'VisitorFullName
        '
        Me.VisitorFullName.DataPropertyName = "VisitorFullName"
        Me.VisitorFullName.HeaderText = "نماینده"
        Me.VisitorFullName.Name = "VisitorFullName"
        Me.VisitorFullName.ReadOnly = True
        Me.VisitorFullName.Width = 250
        '
        'AllComitment
        '
        Me.AllComitment.DataPropertyName = "AllComitment"
        Me.AllComitment.HeaderText = "تعداد کل تعهد"
        Me.AllComitment.Name = "AllComitment"
        Me.AllComitment.ReadOnly = True
        '
        'ConfirmedContractNumber
        '
        Me.ConfirmedContractNumber.DataPropertyName = "ConfirmedContractNumber"
        Me.ConfirmedContractNumber.HeaderText = "تعداد کل قرار داد ها"
        Me.ConfirmedContractNumber.Name = "ConfirmedContractNumber"
        Me.ConfirmedContractNumber.ReadOnly = True
        '
        'CompletedContractNumber
        '
        Me.CompletedContractNumber.DataPropertyName = "CompletedContractNumber"
        Me.CompletedContractNumber.HeaderText = "تعداد قراردادهای منعقده کامل "
        Me.CompletedContractNumber.Name = "CompletedContractNumber"
        Me.CompletedContractNumber.ReadOnly = True
        '
        'CountractCount_UntilDateFrom
        '
        Me.CountractCount_UntilDateFrom.DataPropertyName = "CountractCount_UntilDateFrom"
        Me.CountractCount_UntilDateFrom.HeaderText = "تعداد قراردادهای ثبت شده تا ابتدای بازه"
        Me.CountractCount_UntilDateFrom.Name = "CountractCount_UntilDateFrom"
        Me.CountractCount_UntilDateFrom.ReadOnly = True
        '
        'CountractCount_Between
        '
        Me.CountractCount_Between.DataPropertyName = "CountractCount_Between"
        Me.CountractCount_Between.HeaderText = "تعداد قراردادهای ثبت شده در بازه"
        Me.CountractCount_Between.Name = "CountractCount_Between"
        Me.CountractCount_Between.ReadOnly = True
        '
        'AccountCount_UntilDateFrom
        '
        Me.AccountCount_UntilDateFrom.DataPropertyName = "AccountCount_UntilDateFrom"
        Me.AccountCount_UntilDateFrom.HeaderText = "تعداد حساب دار ها تا ابتدای بازه"
        Me.AccountCount_UntilDateFrom.Name = "AccountCount_UntilDateFrom"
        Me.AccountCount_UntilDateFrom.ReadOnly = True
        '
        'AccountCount_Between
        '
        Me.AccountCount_Between.DataPropertyName = "AccountCount_Between"
        Me.AccountCount_Between.HeaderText = "تعداد حساب دارها در بازه"
        Me.AccountCount_Between.Name = "AccountCount_Between"
        Me.AccountCount_Between.ReadOnly = True
        '
        'TakhsisCount_UntilDateFrom
        '
        Me.TakhsisCount_UntilDateFrom.DataPropertyName = "TakhsisCount_UntilDateFrom"
        Me.TakhsisCount_UntilDateFrom.HeaderText = "تعداد تخصیص داده شده تا ابتدای بازه"
        Me.TakhsisCount_UntilDateFrom.Name = "TakhsisCount_UntilDateFrom"
        Me.TakhsisCount_UntilDateFrom.ReadOnly = True
        '
        'TakhsisCount_Between
        '
        Me.TakhsisCount_Between.DataPropertyName = "TakhsisCount_Between"
        Me.TakhsisCount_Between.HeaderText = "تعداد تخصیص داده شده در بازه"
        Me.TakhsisCount_Between.Name = "TakhsisCount_Between"
        Me.TakhsisCount_Between.ReadOnly = True
        '
        'ConfigedCount_UntilDateFrom
        '
        Me.ConfigedCount_UntilDateFrom.DataPropertyName = "ConfigedCount_UntilDateFrom"
        Me.ConfigedCount_UntilDateFrom.HeaderText = "تعداد پیکربندی شده در سوئیچ تا ابتدای بازه"
        Me.ConfigedCount_UntilDateFrom.Name = "ConfigedCount_UntilDateFrom"
        Me.ConfigedCount_UntilDateFrom.ReadOnly = True
        '
        'ConfigedCount_Between
        '
        Me.ConfigedCount_Between.DataPropertyName = "ConfigedCount_Between"
        Me.ConfigedCount_Between.HeaderText = "تعدا پیکربندی شده در سوئیچ در بازه"
        Me.ConfigedCount_Between.Name = "ConfigedCount_Between"
        Me.ConfigedCount_Between.ReadOnly = True
        '
        'InstalledCount_UntilDateFrom
        '
        Me.InstalledCount_UntilDateFrom.DataPropertyName = "InstalledCount_UntilDateFrom"
        Me.InstalledCount_UntilDateFrom.HeaderText = "تعداد نصب شده تا ابتدای بازه"
        Me.InstalledCount_UntilDateFrom.Name = "InstalledCount_UntilDateFrom"
        Me.InstalledCount_UntilDateFrom.ReadOnly = True
        '
        'InstalledCount_Between
        '
        Me.InstalledCount_Between.DataPropertyName = "InstalledCount_Between"
        Me.InstalledCount_Between.HeaderText = "تعداد نصب شده در بازه"
        Me.InstalledCount_Between.Name = "InstalledCount_Between"
        Me.InstalledCount_Between.ReadOnly = True
        '
        'InstallConfirmedCount_UntilDateFrom
        '
        Me.InstallConfirmedCount_UntilDateFrom.DataPropertyName = "InstallConfirmedCount_UntilDateFrom"
        Me.InstallConfirmedCount_UntilDateFrom.HeaderText = "تعداد تایید نصب شده تا ابتدای بازه"
        Me.InstallConfirmedCount_UntilDateFrom.Name = "InstallConfirmedCount_UntilDateFrom"
        Me.InstallConfirmedCount_UntilDateFrom.ReadOnly = True
        '
        'InstallConfirmedCount_Between
        '
        Me.InstallConfirmedCount_Between.DataPropertyName = "InstallConfirmedCount_Between"
        Me.InstallConfirmedCount_Between.HeaderText = "تعداد تایید نصب شده در بازه"
        Me.InstallConfirmedCount_Between.Name = "InstallConfirmedCount_Between"
        Me.InstallConfirmedCount_Between.ReadOnly = True
        '
        'CanceledCount_UntilDateFrom
        '
        Me.CanceledCount_UntilDateFrom.DataPropertyName = "CanceledCount_UntilDateFrom"
        Me.CanceledCount_UntilDateFrom.HeaderText = "تعدا فسخ شده تا ابتدای بازه"
        Me.CanceledCount_UntilDateFrom.Name = "CanceledCount_UntilDateFrom"
        Me.CanceledCount_UntilDateFrom.ReadOnly = True
        '
        'CanceledCount_Between
        '
        Me.CanceledCount_Between.DataPropertyName = "CanceledCount_Between"
        Me.CanceledCount_Between.HeaderText = "تعداد فسخ شده در بازه"
        Me.CanceledCount_Between.Name = "CanceledCount_Between"
        Me.CanceledCount_Between.ReadOnly = True
        '
        'InstalledAndCanceledCount_Between
        '
        Me.InstalledAndCanceledCount_Between.DataPropertyName = "InstalledAndCanceledCount_Between"
        Me.InstalledAndCanceledCount_Between.HeaderText = "تعداد فسخ شده در بازه که در همین بازه  نصب شده اند"
        Me.InstalledAndCanceledCount_Between.Name = "InstalledAndCanceledCount_Between"
        Me.InstalledAndCanceledCount_Between.ReadOnly = True
        '
        'TotalDeviceCount
        '
        Me.TotalDeviceCount.DataPropertyName = "TotalDeviceCount"
        Me.TotalDeviceCount.HeaderText = "تعدا کل دستگاههای درخواستی"
        Me.TotalDeviceCount.Name = "TotalDeviceCount"
        Me.TotalDeviceCount.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblCount, Me.slblRowsCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 722)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1331, 22)
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
        'ReportSearchToolStrip1
        '
        Me.ReportSearchToolStrip1.btnExportExcelVisible = True
        Me.ReportSearchToolStrip1.btnPrintVisible = False
        Me.ReportSearchToolStrip1.btnShowVisible = True
        Me.ReportSearchToolStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ReportSearchToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ReportSearchToolStrip1.Name = "ReportSearchToolStrip1"
        Me.ReportSearchToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ReportSearchToolStrip1.Size = New System.Drawing.Size(1331, 24)
        Me.ReportSearchToolStrip1.TabIndex = 41
        '
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.Location = New System.Drawing.Point(1088, 25)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(233, 109)
        Me.rucDate.TabIndex = 39
        '
        'cmbProject
        '
        Me.cmbProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(871, 44)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(178, 21)
        Me.cmbProject.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1052, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "پروژه"
        '
        'frmRptAgentActivities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1331, 744)
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
        Me.GrpSumCount.ResumeLayout(False)
        Me.GrpSumCount.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpSumCount As System.Windows.Forms.GroupBox
    Friend WithEvents lblSumAccountCount_Between As System.Windows.Forms.Label
    Friend WithEvents lblSumCountractCount_Between As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblSumTotalDeviceCount As System.Windows.Forms.Label
    Friend WithEvents lblSumInstalledAndCanceledCount_Between As System.Windows.Forms.Label
    Friend WithEvents lblSumCanceledCount_Between As System.Windows.Forms.Label
    Friend WithEvents lblSumCanceledCount_UntilDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblSumInstallConfirmedCount_Between As System.Windows.Forms.Label
    Friend WithEvents lblSumInstallConfirmedCount_UntilDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblSumInstalledCount_Between As System.Windows.Forms.Label
    Friend WithEvents lblSumInstalledCount_UntilDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblSumConfigedCount_Between As System.Windows.Forms.Label
    Friend WithEvents lblSumConfigedCount_UntilDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblSumTakhsisCount_Between As System.Windows.Forms.Label
    Friend WithEvents lblSumTakhsisCount_UntilDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblSumAccountCount_UntilDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblSumCountractCount_UntilDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblSumCompletedContractNumber As System.Windows.Forms.Label
    Friend WithEvents lblSumConfirmedContractNumber As System.Windows.Forms.Label
    Friend WithEvents lblSumAllComitment As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slblRowsCount As System.Windows.Forms.ToolStripStatusLabel
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
    Friend WithEvents InstallConfirmedCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstallConfirmedCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CanceledCount_UntilDateFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CanceledCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InstalledAndCanceledCount_Between As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDeviceCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rucDate As ReportUserControl_DateInterval
    Friend WithEvents ReportSearchToolStrip1 As ReportSearchToolStrip
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
