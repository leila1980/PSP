<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBlockContract
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBlockContract))
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.btnBlockOK = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.btnBlockNOk = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.txtBlockedDate_vc = New FarsiLibrary.Win.Controls.FADatePickerConverter
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.chkBlockedVisitorPayment_bit = New System.Windows.Forms.CheckBox
        Me.txtBlockedDesc_vc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grp2 = New System.Windows.Forms.GroupBox
        Me.txtOutlet_vc = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtVisitorName_nvc = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtStoreName_nvc = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtContarctingPartyName_nvc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtContractID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tsMain.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp1.SuspendLayout()
        Me.grp2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBlockOK, Me.ToolStripSeparator6, Me.btnBlockNOk, Me.ToolStripSeparator1, Me.btnCancel, Me.ToolStripSeparator2, Me.btnExportToExcel})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(910, 25)
        Me.tsMain.TabIndex = 15
        '
        'btnBlockOK
        '
        Me.btnBlockOK.Image = CType(resources.GetObject("btnBlockOK.Image"), System.Drawing.Image)
        Me.btnBlockOK.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBlockOK.Name = "btnBlockOK"
        Me.btnBlockOK.Size = New System.Drawing.Size(119, 22)
        Me.btnBlockOK.Text = "مسدود كردن قرارداد"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnBlockNOk
        '
        Me.btnBlockNOk.Image = CType(resources.GetObject("btnBlockNOk.Image"), System.Drawing.Image)
        Me.btnBlockNOk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBlockNOk.Name = "btnBlockNOk"
        Me.btnBlockNOk.Size = New System.Drawing.Size(122, 22)
        Me.btnBlockNOk.Text = "رفع مسدودي قرارداد"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 22)
        Me.btnCancel.Text = "انصراف"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(93, 22)
        Me.btnExportToExcel.Text = "انتقال به Excel"
        '
        'txtBlockedDate_vc
        '
        Me.txtBlockedDate_vc.CalendarType = FarsiLibrary.Win.Enums.CalendarTypes.English
        Me.txtBlockedDate_vc.Location = New System.Drawing.Point(478, 21)
        Me.txtBlockedDate_vc.Name = "txtBlockedDate_vc"
        Me.txtBlockedDate_vc.Size = New System.Drawing.Size(120, 20)
        Me.txtBlockedDate_vc.TabIndex = 8
        Me.txtBlockedDate_vc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(600, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "تاریخ :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvReport)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 142)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(885, 360)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(14, 15)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(857, 339)
        Me.dgvReport.TabIndex = 0
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.chkBlockedVisitorPayment_bit)
        Me.grp1.Controls.Add(Me.txtBlockedDesc_vc)
        Me.grp1.Controls.Add(Me.Label2)
        Me.grp1.Controls.Add(Me.txtBlockedDate_vc)
        Me.grp1.Controls.Add(Me.Label8)
        Me.grp1.Enabled = False
        Me.grp1.Location = New System.Drawing.Point(12, 25)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(643, 56)
        Me.grp1.TabIndex = 20
        Me.grp1.TabStop = False
        '
        'chkBlockedVisitorPayment_bit
        '
        Me.chkBlockedVisitorPayment_bit.AutoSize = True
        Me.chkBlockedVisitorPayment_bit.Location = New System.Drawing.Point(16, 25)
        Me.chkBlockedVisitorPayment_bit.Name = "chkBlockedVisitorPayment_bit"
        Me.chkBlockedVisitorPayment_bit.Size = New System.Drawing.Size(112, 17)
        Me.chkBlockedVisitorPayment_bit.TabIndex = 11
        Me.chkBlockedVisitorPayment_bit.Text = "حق الزحمه بازارياب"
        Me.chkBlockedVisitorPayment_bit.UseVisualStyleBackColor = True
        '
        'txtBlockedDesc_vc
        '
        Me.txtBlockedDesc_vc.Location = New System.Drawing.Point(134, 21)
        Me.txtBlockedDesc_vc.Name = "txtBlockedDesc_vc"
        Me.txtBlockedDesc_vc.Size = New System.Drawing.Size(290, 21)
        Me.txtBlockedDesc_vc.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(430, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "علت :"
        '
        'grp2
        '
        Me.grp2.Controls.Add(Me.txtOutlet_vc)
        Me.grp2.Controls.Add(Me.Label13)
        Me.grp2.Controls.Add(Me.txtVisitorName_nvc)
        Me.grp2.Controls.Add(Me.Label10)
        Me.grp2.Controls.Add(Me.txtStoreName_nvc)
        Me.grp2.Controls.Add(Me.Label9)
        Me.grp2.Controls.Add(Me.txtContarctingPartyName_nvc)
        Me.grp2.Controls.Add(Me.Label5)
        Me.grp2.Location = New System.Drawing.Point(12, 83)
        Me.grp2.Name = "grp2"
        Me.grp2.Size = New System.Drawing.Size(886, 53)
        Me.grp2.TabIndex = 18
        Me.grp2.TabStop = False
        '
        'txtOutlet_vc
        '
        Me.txtOutlet_vc.Location = New System.Drawing.Point(16, 20)
        Me.txtOutlet_vc.Name = "txtOutlet_vc"
        Me.txtOutlet_vc.ReadOnly = True
        Me.txtOutlet_vc.Size = New System.Drawing.Size(129, 21)
        Me.txtOutlet_vc.TabIndex = 19
        Me.txtOutlet_vc.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(150, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Outlet :"
        '
        'txtVisitorName_nvc
        '
        Me.txtVisitorName_nvc.Location = New System.Drawing.Point(235, 19)
        Me.txtVisitorName_nvc.Name = "txtVisitorName_nvc"
        Me.txtVisitorName_nvc.ReadOnly = True
        Me.txtVisitorName_nvc.Size = New System.Drawing.Size(119, 21)
        Me.txtVisitorName_nvc.TabIndex = 11
        Me.txtVisitorName_nvc.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(357, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "نام بازارياب :"
        '
        'txtStoreName_nvc
        '
        Me.txtStoreName_nvc.Location = New System.Drawing.Point(455, 19)
        Me.txtStoreName_nvc.Name = "txtStoreName_nvc"
        Me.txtStoreName_nvc.ReadOnly = True
        Me.txtStoreName_nvc.Size = New System.Drawing.Size(119, 21)
        Me.txtStoreName_nvc.TabIndex = 9
        Me.txtStoreName_nvc.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(577, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "نام فروشگاه :"
        '
        'txtContarctingPartyName_nvc
        '
        Me.txtContarctingPartyName_nvc.Location = New System.Drawing.Point(662, 19)
        Me.txtContarctingPartyName_nvc.Name = "txtContarctingPartyName_nvc"
        Me.txtContarctingPartyName_nvc.ReadOnly = True
        Me.txtContarctingPartyName_nvc.Size = New System.Drawing.Size(119, 21)
        Me.txtContarctingPartyName_nvc.TabIndex = 5
        Me.txtContarctingPartyName_nvc.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(784, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "نام طرف قرارداد :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtContractID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(661, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(237, 57)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'txtContractID
        '
        Me.txtContractID.Location = New System.Drawing.Point(13, 20)
        Me.txtContractID.Name = "txtContractID"
        Me.txtContractID.Size = New System.Drawing.Size(156, 21)
        Me.txtContractID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(172, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "کد قرارداد :"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'frmBlockContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 524)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.grp2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBlockContract"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        Me.grp2.ResumeLayout(False)
        Me.grp2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBlockOK As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnBlockNOk As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtBlockedDate_vc As FarsiLibrary.Win.Controls.FADatePickerConverter
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents grp1 As System.Windows.Forms.GroupBox
    Friend WithEvents grp2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOutlet_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtVisitorName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtStoreName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtContarctingPartyName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContractID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkBlockedVisitorPayment_bit As System.Windows.Forms.CheckBox
    Friend WithEvents txtBlockedDesc_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
End Class
