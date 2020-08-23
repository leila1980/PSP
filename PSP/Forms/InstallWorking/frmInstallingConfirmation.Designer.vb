<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstallingConfirmation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstallingConfirmation))
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.btnConfirmOK = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.btnConfirmNOk = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSerial_vc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtInstallingDetailID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtMerchant_vc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtOutlet_vc = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtInstallingHeaderNumber_bint = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtIns_date2 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtInstallingHeaderID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtInstallerName_nvc = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtStoreName_nvc = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtContarctingPartyName_nvc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtContractID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpDetail2 = New System.Windows.Forms.GroupBox
        Me.chkDasteGardesh = New System.Windows.Forms.CheckBox
        Me.txtIns_Time = New System.Windows.Forms.MaskedTextBox
        Me.chkStockReceipt = New System.Windows.Forms.CheckBox
        Me.chkPurchaseReceipt = New System.Windows.Forms.CheckBox
        Me.chkCard = New System.Windows.Forms.CheckBox
        Me.chkSign = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.grpDetail1 = New System.Windows.Forms.GroupBox
        Me.txtIns_date = New FarsiLibrary.Win.Controls.FADatePickerConverter
        Me.Label8 = New System.Windows.Forms.Label
        Me.tsMain.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.grpDetail2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConfirmOK, Me.ToolStripSeparator6, Me.btnConfirmNOk, Me.ToolStripSeparator1, Me.btnExportToExcel})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(910, 25)
        Me.tsMain.TabIndex = 14
        '
        'btnConfirmOK
        '
        Me.btnConfirmOK.Image = CType(resources.GetObject("btnConfirmOK.Image"), System.Drawing.Image)
        Me.btnConfirmOK.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConfirmOK.Name = "btnConfirmOK"
        Me.btnConfirmOK.Size = New System.Drawing.Size(71, 22)
        Me.btnConfirmOK.Text = "تایید نصب"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnConfirmNOk
        '
        Me.btnConfirmNOk.Image = CType(resources.GetObject("btnConfirmNOk.Image"), System.Drawing.Image)
        Me.btnConfirmNOk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConfirmNOk.Name = "btnConfirmNOk"
        Me.btnConfirmNOk.Size = New System.Drawing.Size(94, 22)
        Me.btnConfirmNOk.Text = "عدم تایید نصب"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(93, 22)
        Me.btnExportToExcel.Text = "انتقال به Excel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSerial_vc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtInstallingDetailID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(206, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(692, 57)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtSerial_vc
        '
        Me.txtSerial_vc.Location = New System.Drawing.Point(20, 20)
        Me.txtSerial_vc.Name = "txtSerial_vc"
        Me.txtSerial_vc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSerial_vc.Size = New System.Drawing.Size(156, 21)
        Me.txtSerial_vc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "شماره سریال پز :"
        '
        'txtInstallingDetailID
        '
        Me.txtInstallingDetailID.Location = New System.Drawing.Point(449, 20)
        Me.txtInstallingDetailID.Name = "txtInstallingDetailID"
        Me.txtInstallingDetailID.Size = New System.Drawing.Size(156, 21)
        Me.txtInstallingDetailID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(608, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "کد فرم :"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMerchant_vc)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtOutlet_vc)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtInstallingHeaderNumber_bint)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtIns_date2)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtInstallingHeaderID)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtInstallerName_nvc)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtStoreName_nvc)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtContarctingPartyName_nvc)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtContractID)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(886, 83)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txtMerchant_vc
        '
        Me.txtMerchant_vc.Location = New System.Drawing.Point(22, 51)
        Me.txtMerchant_vc.Name = "txtMerchant_vc"
        Me.txtMerchant_vc.ReadOnly = True
        Me.txtMerchant_vc.Size = New System.Drawing.Size(119, 21)
        Me.txtMerchant_vc.TabIndex = 21
        Me.txtMerchant_vc.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(144, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Merchant :"
        '
        'txtOutlet_vc
        '
        Me.txtOutlet_vc.Location = New System.Drawing.Point(648, 53)
        Me.txtOutlet_vc.Name = "txtOutlet_vc"
        Me.txtOutlet_vc.ReadOnly = True
        Me.txtOutlet_vc.Size = New System.Drawing.Size(129, 21)
        Me.txtOutlet_vc.TabIndex = 19
        Me.txtOutlet_vc.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(782, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Outlet :"
        '
        'txtInstallingHeaderNumber_bint
        '
        Me.txtInstallingHeaderNumber_bint.Location = New System.Drawing.Point(435, 55)
        Me.txtInstallingHeaderNumber_bint.Name = "txtInstallingHeaderNumber_bint"
        Me.txtInstallingHeaderNumber_bint.ReadOnly = True
        Me.txtInstallingHeaderNumber_bint.Size = New System.Drawing.Size(119, 21)
        Me.txtInstallingHeaderNumber_bint.TabIndex = 17
        Me.txtInstallingHeaderNumber_bint.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(357, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "تاریخ نصب :"
        '
        'txtIns_date2
        '
        Me.txtIns_date2.Location = New System.Drawing.Point(235, 53)
        Me.txtIns_date2.Name = "txtIns_date2"
        Me.txtIns_date2.ReadOnly = True
        Me.txtIns_date2.Size = New System.Drawing.Size(119, 21)
        Me.txtIns_date2.TabIndex = 15
        Me.txtIns_date2.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(558, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "شماره بچ :"
        '
        'txtInstallingHeaderID
        '
        Me.txtInstallingHeaderID.Location = New System.Drawing.Point(22, 50)
        Me.txtInstallingHeaderID.Name = "txtInstallingHeaderID"
        Me.txtInstallingHeaderID.ReadOnly = True
        Me.txtInstallingHeaderID.Size = New System.Drawing.Size(17, 21)
        Me.txtInstallingHeaderID.TabIndex = 13
        Me.txtInstallingHeaderID.TabStop = False
        Me.txtInstallingHeaderID.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "کد بچ :"
        Me.Label6.Visible = False
        '
        'txtInstallerName_nvc
        '
        Me.txtInstallerName_nvc.Location = New System.Drawing.Point(22, 19)
        Me.txtInstallerName_nvc.Name = "txtInstallerName_nvc"
        Me.txtInstallerName_nvc.ReadOnly = True
        Me.txtInstallerName_nvc.Size = New System.Drawing.Size(119, 21)
        Me.txtInstallerName_nvc.TabIndex = 11
        Me.txtInstallerName_nvc.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(144, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "نام نصاب :"
        '
        'txtStoreName_nvc
        '
        Me.txtStoreName_nvc.Location = New System.Drawing.Point(235, 19)
        Me.txtStoreName_nvc.Name = "txtStoreName_nvc"
        Me.txtStoreName_nvc.ReadOnly = True
        Me.txtStoreName_nvc.Size = New System.Drawing.Size(119, 21)
        Me.txtStoreName_nvc.TabIndex = 9
        Me.txtStoreName_nvc.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(357, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "نام فروشگاه :"
        '
        'txtContarctingPartyName_nvc
        '
        Me.txtContarctingPartyName_nvc.Location = New System.Drawing.Point(435, 19)
        Me.txtContarctingPartyName_nvc.Name = "txtContarctingPartyName_nvc"
        Me.txtContarctingPartyName_nvc.ReadOnly = True
        Me.txtContarctingPartyName_nvc.Size = New System.Drawing.Size(119, 21)
        Me.txtContarctingPartyName_nvc.TabIndex = 5
        Me.txtContarctingPartyName_nvc.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(557, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "نام طرف قرارداد :"
        '
        'txtContractID
        '
        Me.txtContractID.Location = New System.Drawing.Point(648, 19)
        Me.txtContractID.Name = "txtContractID"
        Me.txtContractID.ReadOnly = True
        Me.txtContractID.Size = New System.Drawing.Size(131, 21)
        Me.txtContractID.TabIndex = 1
        Me.txtContractID.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(782, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "کد قرارداد :"
        '
        'grpDetail2
        '
        Me.grpDetail2.Controls.Add(Me.chkDasteGardesh)
        Me.grpDetail2.Controls.Add(Me.txtIns_Time)
        Me.grpDetail2.Controls.Add(Me.chkStockReceipt)
        Me.grpDetail2.Controls.Add(Me.chkPurchaseReceipt)
        Me.grpDetail2.Controls.Add(Me.chkCard)
        Me.grpDetail2.Controls.Add(Me.chkSign)
        Me.grpDetail2.Controls.Add(Me.Label7)
        Me.grpDetail2.Enabled = False
        Me.grpDetail2.Location = New System.Drawing.Point(12, 86)
        Me.grpDetail2.Name = "grpDetail2"
        Me.grpDetail2.Size = New System.Drawing.Size(886, 56)
        Me.grpDetail2.TabIndex = 15
        Me.grpDetail2.TabStop = False
        '
        'chkDasteGardesh
        '
        Me.chkDasteGardesh.AutoSize = True
        Me.chkDasteGardesh.Location = New System.Drawing.Point(22, 22)
        Me.chkDasteGardesh.Name = "chkDasteGardesh"
        Me.chkDasteGardesh.Size = New System.Drawing.Size(114, 17)
        Me.chkDasteGardesh.TabIndex = 8
        Me.chkDasteGardesh.Text = "ارسال دسته گردش"
        Me.chkDasteGardesh.UseVisualStyleBackColor = True
        '
        'txtIns_Time
        '
        Me.txtIns_Time.Location = New System.Drawing.Point(771, 20)
        Me.txtIns_Time.Mask = "00:00"
        Me.txtIns_Time.Name = "txtIns_Time"
        Me.txtIns_Time.Size = New System.Drawing.Size(35, 21)
        Me.txtIns_Time.TabIndex = 3
        Me.txtIns_Time.ValidatingType = GetType(Date)
        '
        'chkStockReceipt
        '
        Me.chkStockReceipt.AutoSize = True
        Me.chkStockReceipt.Location = New System.Drawing.Point(208, 24)
        Me.chkStockReceipt.Name = "chkStockReceipt"
        Me.chkStockReceipt.Size = New System.Drawing.Size(90, 17)
        Me.chkStockReceipt.TabIndex = 7
        Me.chkStockReceipt.Text = "فیش موجودی"
        Me.chkStockReceipt.UseVisualStyleBackColor = True
        '
        'chkPurchaseReceipt
        '
        Me.chkPurchaseReceipt.AutoSize = True
        Me.chkPurchaseReceipt.Location = New System.Drawing.Point(372, 23)
        Me.chkPurchaseReceipt.Name = "chkPurchaseReceipt"
        Me.chkPurchaseReceipt.Size = New System.Drawing.Size(73, 17)
        Me.chkPurchaseReceipt.TabIndex = 6
        Me.chkPurchaseReceipt.Text = "فیش خرید"
        Me.chkPurchaseReceipt.UseVisualStyleBackColor = True
        '
        'chkCard
        '
        Me.chkCard.AutoSize = True
        Me.chkCard.Location = New System.Drawing.Point(504, 23)
        Me.chkCard.Name = "chkCard"
        Me.chkCard.Size = New System.Drawing.Size(76, 17)
        Me.chkCard.TabIndex = 5
        Me.chkCard.Text = "تحویل کارت"
        Me.chkCard.UseVisualStyleBackColor = True
        '
        'chkSign
        '
        Me.chkSign.AutoSize = True
        Me.chkSign.Location = New System.Drawing.Point(626, 24)
        Me.chkSign.Name = "chkSign"
        Me.chkSign.Size = New System.Drawing.Size(90, 17)
        Me.chkSign.TabIndex = 4
        Me.chkSign.Text = "امضا فروشگاه"
        Me.chkSign.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(807, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "ساعت :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvReport)
        Me.GroupBox4.Location = New System.Drawing.Point(14, 228)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(885, 279)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(14, 20)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(857, 247)
        Me.dgvReport.TabIndex = 0
        '
        'grpDetail1
        '
        Me.grpDetail1.Controls.Add(Me.txtIns_date)
        Me.grpDetail1.Controls.Add(Me.Label8)
        Me.grpDetail1.Enabled = False
        Me.grpDetail1.Location = New System.Drawing.Point(12, 27)
        Me.grpDetail1.Name = "grpDetail1"
        Me.grpDetail1.Size = New System.Drawing.Size(188, 60)
        Me.grpDetail1.TabIndex = 17
        Me.grpDetail1.TabStop = False
        '
        'txtIns_date
        '
        Me.txtIns_date.CalendarType = FarsiLibrary.Win.Enums.CalendarTypes.English
        Me.txtIns_date.Location = New System.Drawing.Point(18, 21)
        Me.txtIns_date.Name = "txtIns_date"
        Me.txtIns_date.Size = New System.Drawing.Size(120, 20)
        Me.txtIns_date.TabIndex = 8
        Me.txtIns_date.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(144, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "تاریخ :"
        '
        'frmInstallingConfirmation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 524)
        Me.Controls.Add(Me.grpDetail1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grpDetail2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInstallingConfirmation"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " تایید نصب"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpDetail2.ResumeLayout(False)
        Me.grpDetail2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail1.ResumeLayout(False)
        Me.grpDetail1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnConfirmOK As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConfirmNOk As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInstallingDetailID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtSerial_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContarctingPartyName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtContractID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpDetail2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIns_Time As System.Windows.Forms.MaskedTextBox
    Friend WithEvents chkStockReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents chkPurchaseReceipt As System.Windows.Forms.CheckBox
    Friend WithEvents chkCard As System.Windows.Forms.CheckBox
    Friend WithEvents chkSign As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInstallingHeaderID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtInstallerName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtStoreName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOutlet_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtInstallingHeaderNumber_bint As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtIns_date2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents grpDetail1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIns_date As FarsiLibrary.Win.Controls.FADatePickerConverter
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtMerchant_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkDasteGardesh As System.Windows.Forms.CheckBox
End Class
