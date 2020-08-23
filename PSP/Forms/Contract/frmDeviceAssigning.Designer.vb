<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeviceAssigning
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeviceAssigning))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblPosId = New System.Windows.Forms.Label
        Me.txtPosID = New System.Windows.Forms.TextBox
        Me.txtPropertyNo_vc = New System.Windows.Forms.TextBox
        Me.txtEniacCode_vc = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSerial_vc = New System.Windows.Forms.TextBox
        Me.txtContractID = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvAssignablePos = New System.Windows.Forms.DataGridView
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnRePrint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument
        Me.txtMerchant = New System.Windows.Forms.TextBox
        Me.txtVat = New System.Windows.Forms.TextBox
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.txtoutlet = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.btnAssignNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAssignDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAssignReprint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAssignRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.MarketingByUC1 = New MarketingByUC
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvAssignablePos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMain.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPosId)
        Me.GroupBox1.Controls.Add(Me.txtPosID)
        Me.GroupBox1.Controls.Add(Me.txtPropertyNo_vc)
        Me.GroupBox1.Controls.Add(Me.txtEniacCode_vc)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSerial_vc)
        Me.GroupBox1.Controls.Add(Me.txtContractID)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(971, 44)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblPosId
        '
        Me.lblPosId.AutoSize = True
        Me.lblPosId.Location = New System.Drawing.Point(401, 44)
        Me.lblPosId.Name = "lblPosId"
        Me.lblPosId.Size = New System.Drawing.Size(34, 13)
        Me.lblPosId.TabIndex = 37
        Me.lblPosId.Text = "PosId"
        Me.lblPosId.Visible = False
        '
        'txtPosID
        '
        Me.txtPosID.Location = New System.Drawing.Point(359, 45)
        Me.txtPosID.Name = "txtPosID"
        Me.txtPosID.ReadOnly = True
        Me.txtPosID.Size = New System.Drawing.Size(39, 21)
        Me.txtPosID.TabIndex = 36
        Me.txtPosID.Visible = False
        '
        'txtPropertyNo_vc
        '
        Me.txtPropertyNo_vc.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPropertyNo_vc.Location = New System.Drawing.Point(394, 14)
        Me.txtPropertyNo_vc.MaxLength = 20
        Me.txtPropertyNo_vc.Name = "txtPropertyNo_vc"
        Me.txtPropertyNo_vc.Size = New System.Drawing.Size(100, 21)
        Me.txtPropertyNo_vc.TabIndex = 32
        Me.txtPropertyNo_vc.TabStop = False
        '
        'txtEniacCode_vc
        '
        Me.txtEniacCode_vc.BackColor = System.Drawing.Color.Gainsboro
        Me.txtEniacCode_vc.Location = New System.Drawing.Point(220, 14)
        Me.txtEniacCode_vc.MaxLength = 20
        Me.txtEniacCode_vc.Name = "txtEniacCode_vc"
        Me.txtEniacCode_vc.Size = New System.Drawing.Size(100, 21)
        Me.txtEniacCode_vc.TabIndex = 33
        Me.txtEniacCode_vc.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(322, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Eniac Code :"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(497, 19)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(71, 13)
        Me.Label35.TabIndex = 34
        Me.Label35.Text = "شماره اموال :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(680, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "شماره سریال پز :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(881, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "کد قرارداد :"
        '
        'txtSerial_vc
        '
        Me.txtSerial_vc.Location = New System.Drawing.Point(574, 14)
        Me.txtSerial_vc.Name = "txtSerial_vc"
        Me.txtSerial_vc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSerial_vc.Size = New System.Drawing.Size(100, 21)
        Me.txtSerial_vc.TabIndex = 1
        '
        'txtContractID
        '
        Me.txtContractID.Location = New System.Drawing.Point(775, 13)
        Me.txtContractID.Name = "txtContractID"
        Me.txtContractID.Size = New System.Drawing.Size(100, 21)
        Me.txtContractID.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvAssignablePos)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(970, 497)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'dgvAssignablePos
        '
        Me.dgvAssignablePos.AllowUserToAddRows = False
        Me.dgvAssignablePos.AllowUserToDeleteRows = False
        Me.dgvAssignablePos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssignablePos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAssignablePos.Location = New System.Drawing.Point(3, 17)
        Me.dgvAssignablePos.Name = "dgvAssignablePos"
        Me.dgvAssignablePos.ReadOnly = True
        Me.dgvAssignablePos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAssignablePos.Size = New System.Drawing.Size(964, 477)
        Me.dgvAssignablePos.TabIndex = 0
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(49, 22)
        Me.btnNew.Text = "جدید"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 22)
        Me.btnDelete.Text = "حذف"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnRePrint
        '
        Me.btnRePrint.Image = CType(resources.GetObject("btnRePrint.Image"), System.Drawing.Image)
        Me.btnRePrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRePrint.Name = "btnRePrint"
        Me.btnRePrint.Size = New System.Drawing.Size(73, 22)
        Me.btnRePrint.Text = "چاپ مجدد"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(76, 22)
        Me.btnRefresh.Text = "بروزرسانی"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'PrintDocument
        '
        '
        'txtMerchant
        '
        Me.txtMerchant.Location = New System.Drawing.Point(159, 634)
        Me.txtMerchant.Name = "txtMerchant"
        Me.txtMerchant.ReadOnly = True
        Me.txtMerchant.Size = New System.Drawing.Size(133, 21)
        Me.txtMerchant.TabIndex = 12
        '
        'txtVat
        '
        Me.txtVat.Location = New System.Drawing.Point(385, 634)
        Me.txtVat.Name = "txtVat"
        Me.txtVat.ReadOnly = True
        Me.txtVat.Size = New System.Drawing.Size(138, 21)
        Me.txtVat.TabIndex = 13
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(851, 635)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(126, 21)
        Me.txtCode.TabIndex = 15
        '
        'txtoutlet
        '
        Me.txtoutlet.Location = New System.Drawing.Point(623, 634)
        Me.txtoutlet.Name = "txtoutlet"
        Me.txtoutlet.ReadOnly = True
        Me.txtoutlet.Size = New System.Drawing.Size(138, 21)
        Me.txtoutlet.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(813, 637)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(579, 637)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "outlet"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(348, 637)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "vat"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(98, 637)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Merchant"
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAssignNew, Me.ToolStripSeparator1, Me.btnAssignDelete, Me.ToolStripSeparator5, Me.btnAssignReprint, Me.ToolStripSeparator6, Me.btnAssignRefresh, Me.ToolStripSeparator7, Me.btnExportToExcel})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(994, 25)
        Me.tsMain.TabIndex = 21
        '
        'btnAssignNew
        '
        Me.btnAssignNew.Image = CType(resources.GetObject("btnAssignNew.Image"), System.Drawing.Image)
        Me.btnAssignNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAssignNew.Name = "btnAssignNew"
        Me.btnAssignNew.Size = New System.Drawing.Size(49, 22)
        Me.btnAssignNew.Text = "جدید"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnAssignDelete
        '
        Me.btnAssignDelete.Image = CType(resources.GetObject("btnAssignDelete.Image"), System.Drawing.Image)
        Me.btnAssignDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAssignDelete.Name = "btnAssignDelete"
        Me.btnAssignDelete.Size = New System.Drawing.Size(50, 22)
        Me.btnAssignDelete.Text = "حذف"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnAssignReprint
        '
        Me.btnAssignReprint.Image = CType(resources.GetObject("btnAssignReprint.Image"), System.Drawing.Image)
        Me.btnAssignReprint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAssignReprint.Name = "btnAssignReprint"
        Me.btnAssignReprint.Size = New System.Drawing.Size(73, 22)
        Me.btnAssignReprint.Text = "چاپ مجدد"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnAssignRefresh
        '
        Me.btnAssignRefresh.Image = CType(resources.GetObject("btnAssignRefresh.Image"), System.Drawing.Image)
        Me.btnAssignRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAssignRefresh.Name = "btnAssignRefresh"
        Me.btnAssignRefresh.Size = New System.Drawing.Size(76, 22)
        Me.btnAssignRefresh.Text = "بروزرسانی"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(93, 22)
        Me.btnExportToExcel.Text = "انتقال به Excel"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbProject)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.MarketingByUC1)
        Me.GroupBox3.Location = New System.Drawing.Point(588, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(395, 44)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        '
        'cmbProject
        '
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(10, 14)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(100, 21)
        Me.cmbProject.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(113, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "پروژه :"
        '
        'MarketingByUC1
        '
        Me.MarketingByUC1.Location = New System.Drawing.Point(187, 14)
        Me.MarketingByUC1.MarketingByID = CType(0, Short)
        Me.MarketingByUC1.Name = "MarketingByUC1"
        Me.MarketingByUC1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MarketingByUC1.Size = New System.Drawing.Size(202, 25)
        Me.MarketingByUC1.TabIndex = 38
        '
        'frmDeviceAssigning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 668)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.txtoutlet)
        Me.Controls.Add(Me.txtVat)
        Me.Controls.Add(Me.txtMerchant)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeviceAssigning"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تخصیص پز"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvAssignablePos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSerial_vc As System.Windows.Forms.TextBox
    Friend WithEvents txtContractID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPropertyNo_vc As System.Windows.Forms.TextBox
    Friend WithEvents txtEniacCode_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents dgvAssignablePos As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblPosId As System.Windows.Forms.Label
    Friend WithEvents txtPosID As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRePrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtoutlet As System.Windows.Forms.TextBox
    Friend WithEvents txtVat As System.Windows.Forms.TextBox
    Friend WithEvents txtMerchant As System.Windows.Forms.TextBox
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAssignNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAssignDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAssignReprint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAssignRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents MarketingByUC1 As MarketingByUC
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
