<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptVisitorContracts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptVisitorContracts))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpFrom = New FarsiLibrary.Win.Controls.FADatePickerConverter
        Me.dtpTo = New FarsiLibrary.Win.Controls.FADatePickerConverter
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbVisitor = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdoContractNotAccounting = New System.Windows.Forms.RadioButton
        Me.rdoContractNotDeviceassigning = New System.Windows.Forms.RadioButton
        Me.rdoCanceledDevice = New System.Windows.Forms.RadioButton
        Me.rdoNotInstalledDevice = New System.Windows.Forms.RadioButton
        Me.rdoContract = New System.Windows.Forms.RadioButton
        Me.rdoInstalledDevice = New System.Windows.Forms.RadioButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.slblRowsCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.btnView = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbVisitor)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(720, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dtpFrom
        '
        Me.dtpFrom.IsHot = True
        Me.dtpFrom.Location = New System.Drawing.Point(189, 18)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(120, 20)
        Me.dtpFrom.TabIndex = 21
        Me.dtpFrom.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'dtpTo
        '
        Me.dtpTo.IsHot = True
        Me.dtpTo.Location = New System.Drawing.Point(13, 18)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(120, 20)
        Me.dtpTo.TabIndex = 20
        Me.dtpTo.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(660, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "بازاریاب :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(310, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "از تاریخ :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(135, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "تا تاریخ :"
        '
        'cmbVisitor
        '
        Me.cmbVisitor.FormattingEnabled = True
        Me.cmbVisitor.Location = New System.Drawing.Point(492, 18)
        Me.cmbVisitor.Name = "cmbVisitor"
        Me.cmbVisitor.Size = New System.Drawing.Size(162, 21)
        Me.cmbVisitor.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoContractNotAccounting)
        Me.GroupBox3.Controls.Add(Me.rdoContractNotDeviceassigning)
        Me.GroupBox3.Controls.Add(Me.rdoCanceledDevice)
        Me.GroupBox3.Controls.Add(Me.rdoNotInstalledDevice)
        Me.GroupBox3.Controls.Add(Me.rdoContract)
        Me.GroupBox3.Controls.Add(Me.rdoInstalledDevice)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 76)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(972, 66)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        '
        'rdoContractNotAccounting
        '
        Me.rdoContractNotAccounting.AutoSize = True
        Me.rdoContractNotAccounting.Location = New System.Drawing.Point(401, 18)
        Me.rdoContractNotAccounting.Name = "rdoContractNotAccounting"
        Me.rdoContractNotAccounting.Size = New System.Drawing.Size(225, 17)
        Me.rdoContractNotAccounting.TabIndex = 5
        Me.rdoContractNotAccounting.TabStop = True
        Me.rdoContractNotAccounting.Text = "قراردادهای منعقد شده-افتتاح حساب نشده"
        Me.rdoContractNotAccounting.UseVisualStyleBackColor = True
        '
        'rdoContractNotDeviceassigning
        '
        Me.rdoContractNotDeviceassigning.AutoSize = True
        Me.rdoContractNotDeviceassigning.Location = New System.Drawing.Point(9, 16)
        Me.rdoContractNotDeviceassigning.Name = "rdoContractNotDeviceassigning"
        Me.rdoContractNotDeviceassigning.Size = New System.Drawing.Size(322, 17)
        Me.rdoContractNotDeviceassigning.TabIndex = 4
        Me.rdoContractNotDeviceassigning.TabStop = True
        Me.rdoContractNotDeviceassigning.Text = "قراردادهای منعقد شده-افتتاح حساب شده-تخصیص پز داده نشده"
        Me.rdoContractNotDeviceassigning.UseVisualStyleBackColor = True
        '
        'rdoCanceledDevice
        '
        Me.rdoCanceledDevice.AutoSize = True
        Me.rdoCanceledDevice.Location = New System.Drawing.Point(224, 42)
        Me.rdoCanceledDevice.Name = "rdoCanceledDevice"
        Me.rdoCanceledDevice.Size = New System.Drawing.Size(107, 17)
        Me.rdoCanceledDevice.TabIndex = 3
        Me.rdoCanceledDevice.TabStop = True
        Me.rdoCanceledDevice.Text = "پزهای فسخ شده"
        Me.rdoCanceledDevice.UseVisualStyleBackColor = True
        '
        'rdoNotInstalledDevice
        '
        Me.rdoNotInstalledDevice.AutoSize = True
        Me.rdoNotInstalledDevice.Location = New System.Drawing.Point(518, 43)
        Me.rdoNotInstalledDevice.Name = "rdoNotInstalledDevice"
        Me.rdoNotInstalledDevice.Size = New System.Drawing.Size(108, 17)
        Me.rdoNotInstalledDevice.TabIndex = 2
        Me.rdoNotInstalledDevice.TabStop = True
        Me.rdoNotInstalledDevice.Text = "پزهای نصب نشده"
        Me.rdoNotInstalledDevice.UseVisualStyleBackColor = True
        '
        'rdoContract
        '
        Me.rdoContract.AutoSize = True
        Me.rdoContract.Location = New System.Drawing.Point(814, 15)
        Me.rdoContract.Name = "rdoContract"
        Me.rdoContract.Size = New System.Drawing.Size(132, 17)
        Me.rdoContract.TabIndex = 1
        Me.rdoContract.TabStop = True
        Me.rdoContract.Text = "قراردادهای منعقد شده"
        Me.rdoContract.UseVisualStyleBackColor = True
        '
        'rdoInstalledDevice
        '
        Me.rdoInstalledDevice.AutoSize = True
        Me.rdoInstalledDevice.Location = New System.Drawing.Point(842, 41)
        Me.rdoInstalledDevice.Name = "rdoInstalledDevice"
        Me.rdoInstalledDevice.Size = New System.Drawing.Size(104, 17)
        Me.rdoInstalledDevice.TabIndex = 0
        Me.rdoInstalledDevice.TabStop = True
        Me.rdoInstalledDevice.Text = "پزهای نصب شده"
        Me.rdoInstalledDevice.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnView, Me.ToolStripSeparator2, Me.btnExportToExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(994, 25)
        Me.ToolStrip1.TabIndex = 1
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvReport)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 142)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(976, 499)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.AllowUserToOrderColumns = True
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(7, 15)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.Size = New System.Drawing.Size(963, 465)
        Me.dgvReport.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.slblRowsCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 646)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(994, 22)
        Me.StatusStrip1.TabIndex = 7
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
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel2.Text = " "
        '
        'slblRowsCount
        '
        Me.slblRowsCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slblRowsCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.slblRowsCount.Name = "slblRowsCount"
        Me.slblRowsCount.Size = New System.Drawing.Size(0, 17)
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.cmbProject)
        Me.GroupBox4.Location = New System.Drawing.Point(732, 25)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(250, 51)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(196, 21)
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
        Me.cmbProject.Size = New System.Drawing.Size(172, 21)
        Me.cmbProject.TabIndex = 0
        '
        'btnView
        '
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(67, 22)
        Me.btnView.Text = "مشاهده"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'frmRptVisitorContracts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 668)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRptVisitorContracts"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش عقد قرارداد بازاریابها"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbVisitor As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoContract As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInstalledDevice As System.Windows.Forms.RadioButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slblRowsCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents rdoNotInstalledDevice As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCanceledDevice As System.Windows.Forms.RadioButton
    Friend WithEvents rdoContractNotAccounting As System.Windows.Forms.RadioButton
    Friend WithEvents rdoContractNotDeviceassigning As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFrom As FarsiLibrary.Win.Controls.FADatePickerConverter
    Friend WithEvents dtpTo As FarsiLibrary.Win.Controls.FADatePickerConverter
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents btnView As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator


End Class
