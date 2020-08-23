<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgressReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgressReport))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DsReport21 = New DSReport2()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblActivePos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtActivePos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtUpdateTerminal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtNotUpdateTerminal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SendToExcelAllToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SendToExcelUpdatedDetailToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SendToExcelDetailNotUpdatedToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbTask = New System.Windows.Forms.ToolStripComboBox()
        Me.btnView = New System.Windows.Forms.ToolStripButton()
        Me.TMSProgressTabControl = New System.Windows.Forms.TabControl()
        Me.AllTabPage = New System.Windows.Forms.TabPage()
        Me.dgvReportProgress = New System.Windows.Forms.DataGridView()
        Me.colStateID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActivePos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUpdatedTerminal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotUpdatedTerminals = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdatedDetailTabPage = New System.Windows.Forms.TabPage()
        Me.dgvReportProgressUpdatedDetail = New System.Windows.Forms.DataGridView()
        Me.NotUpdatedDetailTabPage = New System.Windows.Forms.TabPage()
        Me.dgvReportProgressNotUpdatedDetail = New System.Windows.Forms.DataGridView()
        Me.DsReport22 = New DSReport2()
        Me.DsReport23 = New DSReport2()
        Me.DsReport24 = New DSReport2()
        Me.DsReport25 = New DSReport2()
        Me.colState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCityName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStoreName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colcontactingPartyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOUTLET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerial_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEniacCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAddress_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTel1_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DsReport21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TMSProgressTabControl.SuspendLayout()
        Me.AllTabPage.SuspendLayout()
        CType(Me.dgvReportProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UpdatedDetailTabPage.SuspendLayout()
        CType(Me.dgvReportProgressUpdatedDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NotUpdatedDetailTabPage.SuspendLayout()
        CType(Me.dgvReportProgressNotUpdatedDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsReport22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsReport23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsReport24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsReport25, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DsReport21
        '
        Me.DsReport21.DataSetName = "DSReport2"
        Me.DsReport21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblActivePos, Me.txtActivePos, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.txtUpdateTerminal, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel3, Me.txtNotUpdateTerminal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 403)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(749, 22)
        Me.StatusStrip1.TabIndex = 14
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblActivePos
        '
        Me.lblActivePos.Name = "lblActivePos"
        Me.lblActivePos.Size = New System.Drawing.Size(101, 17)
        Me.lblActivePos.Text = "جمع کل پزهای فعال:"
        '
        'txtActivePos
        '
        Me.txtActivePos.Name = "txtActivePos"
        Me.txtActivePos.Size = New System.Drawing.Size(13, 17)
        Me.txtActivePos.Text = "0"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(111, 17)
        Me.ToolStripStatusLabel2.Text = "جمع پزهای TMS شده:"
        '
        'txtUpdateTerminal
        '
        Me.txtUpdateTerminal.Name = "txtUpdateTerminal"
        Me.txtUpdateTerminal.Size = New System.Drawing.Size(13, 17)
        Me.txtUpdateTerminal.Text = "0"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel5.Text = "|"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(115, 17)
        Me.ToolStripStatusLabel3.Text = "جمع پزهای TMS نشده:"
        '
        'txtNotUpdateTerminal
        '
        Me.txtNotUpdateTerminal.Name = "txtNotUpdateTerminal"
        Me.txtNotUpdateTerminal.Size = New System.Drawing.Size(13, 17)
        Me.txtNotUpdateTerminal.Text = "0"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SendToExcelAllToolStripButton, Me.SendToExcelUpdatedDetailToolStripButton, Me.SendToExcelDetailNotUpdatedToolStripButton, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.cmbTask, Me.btnView})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(749, 25)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'SendToExcelAllToolStripButton
        '
        Me.SendToExcelAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SendToExcelAllToolStripButton.Image = CType(resources.GetObject("SendToExcelAllToolStripButton.Image"), System.Drawing.Image)
        Me.SendToExcelAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SendToExcelAllToolStripButton.Name = "SendToExcelAllToolStripButton"
        Me.SendToExcelAllToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SendToExcelAllToolStripButton.Text = "ارسال لیست کلی به اکسل"
        '
        'SendToExcelUpdatedDetailToolStripButton
        '
        Me.SendToExcelUpdatedDetailToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SendToExcelUpdatedDetailToolStripButton.Image = CType(resources.GetObject("SendToExcelUpdatedDetailToolStripButton.Image"), System.Drawing.Image)
        Me.SendToExcelUpdatedDetailToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SendToExcelUpdatedDetailToolStripButton.Name = "SendToExcelUpdatedDetailToolStripButton"
        Me.SendToExcelUpdatedDetailToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SendToExcelUpdatedDetailToolStripButton.Text = "ارسال جزئیات بروزرسانی شده به اکسل"
        '
        'SendToExcelDetailNotUpdatedToolStripButton
        '
        Me.SendToExcelDetailNotUpdatedToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SendToExcelDetailNotUpdatedToolStripButton.Image = CType(resources.GetObject("SendToExcelDetailNotUpdatedToolStripButton.Image"), System.Drawing.Image)
        Me.SendToExcelDetailNotUpdatedToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SendToExcelDetailNotUpdatedToolStripButton.Name = "SendToExcelDetailNotUpdatedToolStripButton"
        Me.SendToExcelDetailNotUpdatedToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SendToExcelDetailNotUpdatedToolStripButton.Text = "ارسال جزئیات بروز رسانی نشده به اکسل"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripLabel1.Text = "نام Task:"
        '
        'cmbTask
        '
        Me.cmbTask.Name = "cmbTask"
        Me.cmbTask.Size = New System.Drawing.Size(350, 25)
        '
        'btnView
        '
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(61, 22)
        Me.btnView.Text = "مشاهده"
        '
        'TMSProgressTabControl
        '
        Me.TMSProgressTabControl.Controls.Add(Me.AllTabPage)
        Me.TMSProgressTabControl.Controls.Add(Me.UpdatedDetailTabPage)
        Me.TMSProgressTabControl.Controls.Add(Me.NotUpdatedDetailTabPage)
        Me.TMSProgressTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TMSProgressTabControl.Location = New System.Drawing.Point(0, 25)
        Me.TMSProgressTabControl.Name = "TMSProgressTabControl"
        Me.TMSProgressTabControl.RightToLeftLayout = True
        Me.TMSProgressTabControl.SelectedIndex = 0
        Me.TMSProgressTabControl.Size = New System.Drawing.Size(749, 378)
        Me.TMSProgressTabControl.TabIndex = 17
        '
        'AllTabPage
        '
        Me.AllTabPage.Controls.Add(Me.dgvReportProgress)
        Me.AllTabPage.Location = New System.Drawing.Point(4, 22)
        Me.AllTabPage.Name = "AllTabPage"
        Me.AllTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.AllTabPage.Size = New System.Drawing.Size(741, 352)
        Me.AllTabPage.TabIndex = 0
        Me.AllTabPage.Text = "لیست کلی"
        Me.AllTabPage.UseVisualStyleBackColor = True
        '
        'dgvReportProgress
        '
        Me.dgvReportProgress.AllowUserToAddRows = False
        Me.dgvReportProgress.AllowUserToDeleteRows = False
        Me.dgvReportProgress.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvReportProgress.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReportProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportProgress.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStateID, Me.colStateName, Me.colActivePos, Me.colUpdatedTerminal, Me.colNotUpdatedTerminals})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReportProgress.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReportProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReportProgress.Location = New System.Drawing.Point(3, 3)
        Me.dgvReportProgress.MultiSelect = False
        Me.dgvReportProgress.Name = "dgvReportProgress"
        Me.dgvReportProgress.ReadOnly = True
        Me.dgvReportProgress.RowHeadersVisible = False
        Me.dgvReportProgress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReportProgress.Size = New System.Drawing.Size(735, 346)
        Me.dgvReportProgress.TabIndex = 14
        '
        'colStateID
        '
        Me.colStateID.DataPropertyName = "StateID"
        Me.colStateID.HeaderText = "کد استان"
        Me.colStateID.Name = "colStateID"
        Me.colStateID.ReadOnly = True
        Me.colStateID.Visible = False
        '
        'colStateName
        '
        Me.colStateName.DataPropertyName = "Name_nvc"
        Me.colStateName.FillWeight = 269.0722!
        Me.colStateName.HeaderText = "نام استان"
        Me.colStateName.Name = "colStateName"
        Me.colStateName.ReadOnly = True
        Me.colStateName.Width = 350
        '
        'colActivePos
        '
        Me.colActivePos.DataPropertyName = "ActivePos"
        Me.colActivePos.FillWeight = 16.73726!
        Me.colActivePos.HeaderText = "تعداد پزهای فعال"
        Me.colActivePos.Name = "colActivePos"
        Me.colActivePos.ReadOnly = True
        Me.colActivePos.Width = 220
        '
        'colUpdatedTerminal
        '
        Me.colUpdatedTerminal.DataPropertyName = "UpdatedTerminals"
        Me.colUpdatedTerminal.FillWeight = 14.19057!
        Me.colUpdatedTerminal.HeaderText = "تعداد ترمینالهای بروزرسانی شده"
        Me.colUpdatedTerminal.Name = "colUpdatedTerminal"
        Me.colUpdatedTerminal.ReadOnly = True
        Me.colUpdatedTerminal.Width = 200
        '
        'colNotUpdatedTerminals
        '
        Me.colNotUpdatedTerminals.DataPropertyName = "NotUpdatedTerminals"
        Me.colNotUpdatedTerminals.HeaderText = "تعداد ترمینالهای بروز رسانی نشده"
        Me.colNotUpdatedTerminals.Name = "colNotUpdatedTerminals"
        Me.colNotUpdatedTerminals.ReadOnly = True
        Me.colNotUpdatedTerminals.Width = 200
        '
        'UpdatedDetailTabPage
        '
        Me.UpdatedDetailTabPage.Controls.Add(Me.dgvReportProgressUpdatedDetail)
        Me.UpdatedDetailTabPage.Location = New System.Drawing.Point(4, 22)
        Me.UpdatedDetailTabPage.Name = "UpdatedDetailTabPage"
        Me.UpdatedDetailTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.UpdatedDetailTabPage.Size = New System.Drawing.Size(741, 352)
        Me.UpdatedDetailTabPage.TabIndex = 1
        Me.UpdatedDetailTabPage.Text = "جزئیات بروزرسانی شده"
        Me.UpdatedDetailTabPage.UseVisualStyleBackColor = True
        '
        'dgvReportProgressUpdatedDetail
        '
        Me.dgvReportProgressUpdatedDetail.AllowUserToAddRows = False
        Me.dgvReportProgressUpdatedDetail.AllowUserToDeleteRows = False
        Me.dgvReportProgressUpdatedDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.dgvReportProgressUpdatedDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvReportProgressUpdatedDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportProgressUpdatedDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colState, Me.colCityName, Me.colStoreName, Me.colcontactingPartyName, Me.colOUTLET, Me.colSerial_vc, Me.colEniacCode, Me.colAddress_nvc, Me.colTel1_vc})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReportProgressUpdatedDetail.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReportProgressUpdatedDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReportProgressUpdatedDetail.Location = New System.Drawing.Point(3, 3)
        Me.dgvReportProgressUpdatedDetail.MultiSelect = False
        Me.dgvReportProgressUpdatedDetail.Name = "dgvReportProgressUpdatedDetail"
        Me.dgvReportProgressUpdatedDetail.ReadOnly = True
        Me.dgvReportProgressUpdatedDetail.RowHeadersVisible = False
        Me.dgvReportProgressUpdatedDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReportProgressUpdatedDetail.Size = New System.Drawing.Size(735, 346)
        Me.dgvReportProgressUpdatedDetail.TabIndex = 15
        '
        'NotUpdatedDetailTabPage
        '
        Me.NotUpdatedDetailTabPage.Controls.Add(Me.dgvReportProgressNotUpdatedDetail)
        Me.NotUpdatedDetailTabPage.Location = New System.Drawing.Point(4, 22)
        Me.NotUpdatedDetailTabPage.Name = "NotUpdatedDetailTabPage"
        Me.NotUpdatedDetailTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.NotUpdatedDetailTabPage.Size = New System.Drawing.Size(741, 352)
        Me.NotUpdatedDetailTabPage.TabIndex = 2
        Me.NotUpdatedDetailTabPage.Text = "جزئیات بروزرسانی نشده"
        Me.NotUpdatedDetailTabPage.UseVisualStyleBackColor = True
        '
        'dgvReportProgressNotUpdatedDetail
        '
        Me.dgvReportProgressNotUpdatedDetail.AllowUserToAddRows = False
        Me.dgvReportProgressNotUpdatedDetail.AllowUserToDeleteRows = False
        Me.dgvReportProgressNotUpdatedDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        Me.dgvReportProgressNotUpdatedDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvReportProgressNotUpdatedDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportProgressNotUpdatedDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReportProgressNotUpdatedDetail.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvReportProgressNotUpdatedDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReportProgressNotUpdatedDetail.Location = New System.Drawing.Point(3, 3)
        Me.dgvReportProgressNotUpdatedDetail.MultiSelect = False
        Me.dgvReportProgressNotUpdatedDetail.Name = "dgvReportProgressNotUpdatedDetail"
        Me.dgvReportProgressNotUpdatedDetail.ReadOnly = True
        Me.dgvReportProgressNotUpdatedDetail.RowHeadersVisible = False
        Me.dgvReportProgressNotUpdatedDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReportProgressNotUpdatedDetail.Size = New System.Drawing.Size(735, 346)
        Me.dgvReportProgressNotUpdatedDetail.TabIndex = 16
        '
        'DsReport22
        '
        Me.DsReport22.DataSetName = "DSReport2"
        Me.DsReport22.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsReport23
        '
        Me.DsReport23.DataSetName = "DSReport2"
        Me.DsReport23.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsReport24
        '
        Me.DsReport24.DataSetName = "DSReport2"
        Me.DsReport24.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsReport25
        '
        Me.DsReport25.DataSetName = "DSReport2"
        Me.DsReport25.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'colState
        '
        Me.colState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colState.DataPropertyName = "StateName"
        Me.colState.HeaderText = "نام استان"
        Me.colState.Name = "colState"
        Me.colState.ReadOnly = True
        Me.colState.Visible = False
        '
        'colCityName
        '
        Me.colCityName.DataPropertyName = "CityName"
        Me.colCityName.HeaderText = "نام شهر"
        Me.colCityName.Name = "colCityName"
        Me.colCityName.ReadOnly = True
        Me.colCityName.Width = 120
        '
        'colStoreName
        '
        Me.colStoreName.DataPropertyName = "StoreName"
        Me.colStoreName.HeaderText = "نام فروشگاه"
        Me.colStoreName.Name = "colStoreName"
        Me.colStoreName.ReadOnly = True
        Me.colStoreName.Width = 120
        '
        'colcontactingPartyName
        '
        Me.colcontactingPartyName.DataPropertyName = "contactingPartyName"
        Me.colcontactingPartyName.HeaderText = "نام طرف قرارداد"
        Me.colcontactingPartyName.Name = "colcontactingPartyName"
        Me.colcontactingPartyName.ReadOnly = True
        Me.colcontactingPartyName.Width = 150
        '
        'colOUTLET
        '
        Me.colOUTLET.DataPropertyName = "OUTLET"
        Me.colOUTLET.HeaderText = "کد پایانه"
        Me.colOUTLET.Name = "colOUTLET"
        Me.colOUTLET.ReadOnly = True
        '
        'colSerial_vc
        '
        Me.colSerial_vc.DataPropertyName = "Serial_vc"
        Me.colSerial_vc.HeaderText = "سریال"
        Me.colSerial_vc.Name = "colSerial_vc"
        Me.colSerial_vc.ReadOnly = True
        '
        'colEniacCode
        '
        Me.colEniacCode.DataPropertyName = "EniacCode"
        Me.colEniacCode.HeaderText = "کد پیگیری"
        Me.colEniacCode.Name = "colEniacCode"
        Me.colEniacCode.ReadOnly = True
        '
        'colAddress_nvc
        '
        Me.colAddress_nvc.DataPropertyName = "Address_nvc"
        Me.colAddress_nvc.HeaderText = "آدرس"
        Me.colAddress_nvc.Name = "colAddress_nvc"
        Me.colAddress_nvc.ReadOnly = True
        Me.colAddress_nvc.Width = 250
        '
        'colTel1_vc
        '
        Me.colTel1_vc.DataPropertyName = "Tel1_vc"
        Me.colTel1_vc.HeaderText = "تلفن"
        Me.colTel1_vc.Name = "colTel1_vc"
        Me.colTel1_vc.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "StateName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "نام استان"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CityName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "نام شهر"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "StoreName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "نام فروشگاه"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "contactingPartyName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "نام طرف قرارداد"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "OUTLET"
        Me.DataGridViewTextBoxColumn5.HeaderText = "کد پایانه"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Serial_vc"
        Me.DataGridViewTextBoxColumn6.HeaderText = "سریال"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "EniacCode"
        Me.DataGridViewTextBoxColumn7.HeaderText = "کد پیگیری"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Address_nvc"
        Me.DataGridViewTextBoxColumn8.HeaderText = "آدرس"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 250
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Tel1_vc"
        Me.DataGridViewTextBoxColumn9.HeaderText = "تلفن"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'frmProgressReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 425)
        Me.Controls.Add(Me.TMSProgressTabControl)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmProgressReport"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "گزارش پیشرفت TMS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DsReport21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TMSProgressTabControl.ResumeLayout(False)
        Me.AllTabPage.ResumeLayout(False)
        CType(Me.dgvReportProgress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UpdatedDetailTabPage.ResumeLayout(False)
        CType(Me.dgvReportProgressUpdatedDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NotUpdatedDetailTabPage.ResumeLayout(False)
        CType(Me.dgvReportProgressNotUpdatedDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsReport22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsReport23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsReport24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsReport25, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsReport21 As DSReport2
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblActivePos As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtActivePos As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtUpdateTerminal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SendToExcelUpdatedDetailToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbTask As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TMSProgressTabControl As System.Windows.Forms.TabControl
    Friend WithEvents AllTabPage As System.Windows.Forms.TabPage
    Friend WithEvents UpdatedDetailTabPage As System.Windows.Forms.TabPage
    Friend WithEvents dgvReportProgress As System.Windows.Forms.DataGridView
    Friend WithEvents DsReport22 As DSReport2
    Friend WithEvents DsReport23 As DSReport2
    Friend WithEvents dgvReportProgressUpdatedDetail As System.Windows.Forms.DataGridView
    Friend WithEvents DsReport24 As DSReport2
    Friend WithEvents SendToExcelAllToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DsReport25 As DSReport2
    Friend WithEvents NotUpdatedDetailTabPage As System.Windows.Forms.TabPage
    Friend WithEvents dgvReportProgressNotUpdatedDetail As System.Windows.Forms.DataGridView
    Friend WithEvents colStateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActivePos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUpdatedTerminal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotUpdatedTerminals As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendToExcelDetailNotUpdatedToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtNotUpdateTerminal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnView As System.Windows.Forms.ToolStripButton
    Friend WithEvents colState As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCityName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStoreName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colcontactingPartyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOUTLET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerial_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEniacCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAddress_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTel1_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
