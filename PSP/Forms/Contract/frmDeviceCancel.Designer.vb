<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeviceCancel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeviceCancel))
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.btnDeviceCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.grpDetail = New System.Windows.Forms.GroupBox
        Me.txtDate_vc = New DateTextBox.DateTextBox
        Me.cmbDesc_nvc = New System.Windows.Forms.ComboBox
        Me.chkCanceledVisitorPayment_bit = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTheLastTranDate = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtOutlet_vc = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtStoreName_nvc = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtContarctingPartyName_nvc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtContractID = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSerial_vc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tsMain.SuspendLayout()
        Me.grpDetail.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDeviceCancel, Me.ToolStripSeparator1, Me.btnCancel, Me.ToolStripSeparator3, Me.btnEdit, Me.ToolStripSeparator2, Me.btnExportToExcel})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(912, 25)
        Me.tsMain.TabIndex = 15
        '
        'btnDeviceCancel
        '
        Me.btnDeviceCancel.Image = CType(resources.GetObject("btnDeviceCancel.Image"), System.Drawing.Image)
        Me.btnDeviceCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeviceCancel.Name = "btnDeviceCancel"
        Me.btnDeviceCancel.Size = New System.Drawing.Size(63, 22)
        Me.btnDeviceCancel.Text = "فسخ پز"
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 22)
        Me.btnEdit.Text = "ويرايش"
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
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.txtDate_vc)
        Me.grpDetail.Controls.Add(Me.cmbDesc_nvc)
        Me.grpDetail.Controls.Add(Me.chkCanceledVisitorPayment_bit)
        Me.grpDetail.Controls.Add(Me.Label1)
        Me.grpDetail.Controls.Add(Me.Label8)
        Me.grpDetail.Enabled = False
        Me.grpDetail.Location = New System.Drawing.Point(12, 28)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(621, 57)
        Me.grpDetail.TabIndex = 21
        Me.grpDetail.TabStop = False
        '
        'txtDate_vc
        '
        Me.txtDate_vc.AutoSize = True
        Me.txtDate_vc.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtDate_vc.DateBackColor = System.Drawing.SystemColors.Window
        Me.txtDate_vc.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDate_vc.DateReadOnly = False
        Me.txtDate_vc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDate_vc.Location = New System.Drawing.Point(485, 23)
        Me.txtDate_vc.Name = "txtDate_vc"
        Me.txtDate_vc.Size = New System.Drawing.Size(87, 20)
        Me.txtDate_vc.TabIndex = 15
        Me.txtDate_vc.Value = ""
        '
        'cmbDesc_nvc
        '
        Me.cmbDesc_nvc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDesc_nvc.FormattingEnabled = True
        Me.cmbDesc_nvc.Location = New System.Drawing.Point(6, 22)
        Me.cmbDesc_nvc.Name = "cmbDesc_nvc"
        Me.cmbDesc_nvc.Size = New System.Drawing.Size(266, 21)
        Me.cmbDesc_nvc.TabIndex = 14
        '
        'chkCanceledVisitorPayment_bit
        '
        Me.chkCanceledVisitorPayment_bit.AutoSize = True
        Me.chkCanceledVisitorPayment_bit.Location = New System.Drawing.Point(335, 22)
        Me.chkCanceledVisitorPayment_bit.Name = "chkCanceledVisitorPayment_bit"
        Me.chkCanceledVisitorPayment_bit.Size = New System.Drawing.Size(112, 17)
        Me.chkCanceledVisitorPayment_bit.TabIndex = 12
        Me.chkCanceledVisitorPayment_bit.Text = "حق الزحمه بازارياب"
        Me.chkCanceledVisitorPayment_bit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(275, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "توضیحات :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(578, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "تاریخ :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvReport)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 188)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(885, 328)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "لیست پزهای فسخ شده"
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(14, 20)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReport.Size = New System.Drawing.Size(857, 293)
        Me.dgvReport.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTheLastTranDate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtOutlet_vc)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtStoreName_nvc)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtContarctingPartyName_nvc)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtContractID)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 87)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(886, 95)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'txtTheLastTranDate
        '
        Me.txtTheLastTranDate.Location = New System.Drawing.Point(14, 49)
        Me.txtTheLastTranDate.Name = "txtTheLastTranDate"
        Me.txtTheLastTranDate.ReadOnly = True
        Me.txtTheLastTranDate.Size = New System.Drawing.Size(213, 21)
        Me.txtTheLastTranDate.TabIndex = 23
        Me.txtTheLastTranDate.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "تاریخ آخرین تراکنش:"
        '
        'txtOutlet_vc
        '
        Me.txtOutlet_vc.Location = New System.Drawing.Point(653, 51)
        Me.txtOutlet_vc.Name = "txtOutlet_vc"
        Me.txtOutlet_vc.ReadOnly = True
        Me.txtOutlet_vc.Size = New System.Drawing.Size(129, 21)
        Me.txtOutlet_vc.TabIndex = 19
        Me.txtOutlet_vc.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(787, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Outlet :"
        '
        'txtStoreName_nvc
        '
        Me.txtStoreName_nvc.Location = New System.Drawing.Point(14, 19)
        Me.txtStoreName_nvc.Name = "txtStoreName_nvc"
        Me.txtStoreName_nvc.ReadOnly = True
        Me.txtStoreName_nvc.Size = New System.Drawing.Size(213, 21)
        Me.txtStoreName_nvc.TabIndex = 9
        Me.txtStoreName_nvc.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(233, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "نام فروشگاه :"
        '
        'txtContarctingPartyName_nvc
        '
        Me.txtContarctingPartyName_nvc.Location = New System.Drawing.Point(384, 19)
        Me.txtContarctingPartyName_nvc.Name = "txtContarctingPartyName_nvc"
        Me.txtContarctingPartyName_nvc.ReadOnly = True
        Me.txtContarctingPartyName_nvc.Size = New System.Drawing.Size(119, 21)
        Me.txtContarctingPartyName_nvc.TabIndex = 5
        Me.txtContarctingPartyName_nvc.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(506, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "نام طرف قرارداد :"
        '
        'txtContractID
        '
        Me.txtContractID.Location = New System.Drawing.Point(653, 19)
        Me.txtContractID.Name = "txtContractID"
        Me.txtContractID.ReadOnly = True
        Me.txtContractID.Size = New System.Drawing.Size(131, 21)
        Me.txtContractID.TabIndex = 1
        Me.txtContractID.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(787, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "کد قرارداد :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSerial_vc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(638, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 57)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'txtSerial_vc
        '
        Me.txtSerial_vc.Location = New System.Drawing.Point(9, 20)
        Me.txtSerial_vc.Name = "txtSerial_vc"
        Me.txtSerial_vc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSerial_vc.Size = New System.Drawing.Size(156, 21)
        Me.txtSerial_vc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "شماره سریال پز :"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'frmDeviceCancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 526)
        Me.Controls.Add(Me.grpDetail)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeviceCancel"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "فسخ پز"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.grpDetail.ResumeLayout(False)
        Me.grpDetail.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDeviceCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOutlet_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtStoreName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtContarctingPartyName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtContractID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSerial_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkCanceledVisitorPayment_bit As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbDesc_nvc As System.Windows.Forms.ComboBox
    Friend WithEvents txtTheLastTranDate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDate_vc As DateTextBox.DateTextBox
End Class
