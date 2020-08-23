<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeviceReAssigning
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeviceReAssigning))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSCityName_nvc = New System.Windows.Forms.TextBox
        Me.txtSName_nvc = New System.Windows.Forms.TextBox
        Me.txtLastName_nvc = New System.Windows.Forms.TextBox
        Me.txtFirstName_nvc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDeviceID = New System.Windows.Forms.TextBox
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
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.btnReAssigningEdit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnReAssignSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnReAssignCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAssignDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAssignReprint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAssignRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvReAssignablePos = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.tsMain.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReAssignablePos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSCityName_nvc)
        Me.GroupBox1.Controls.Add(Me.txtSName_nvc)
        Me.GroupBox1.Controls.Add(Me.txtLastName_nvc)
        Me.GroupBox1.Controls.Add(Me.txtFirstName_nvc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDeviceID)
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(955, 44)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'txtSCityName_nvc
        '
        Me.txtSCityName_nvc.Location = New System.Drawing.Point(901, 0)
        Me.txtSCityName_nvc.Name = "txtSCityName_nvc"
        Me.txtSCityName_nvc.Size = New System.Drawing.Size(10, 21)
        Me.txtSCityName_nvc.TabIndex = 42
        Me.txtSCityName_nvc.Visible = False
        '
        'txtSName_nvc
        '
        Me.txtSName_nvc.Location = New System.Drawing.Point(912, 0)
        Me.txtSName_nvc.Name = "txtSName_nvc"
        Me.txtSName_nvc.Size = New System.Drawing.Size(10, 21)
        Me.txtSName_nvc.TabIndex = 41
        Me.txtSName_nvc.Visible = False
        '
        'txtLastName_nvc
        '
        Me.txtLastName_nvc.Location = New System.Drawing.Point(924, 0)
        Me.txtLastName_nvc.Name = "txtLastName_nvc"
        Me.txtLastName_nvc.Size = New System.Drawing.Size(10, 21)
        Me.txtLastName_nvc.TabIndex = 25
        Me.txtLastName_nvc.Visible = False
        '
        'txtFirstName_nvc
        '
        Me.txtFirstName_nvc.Location = New System.Drawing.Point(937, -1)
        Me.txtFirstName_nvc.Name = "txtFirstName_nvc"
        Me.txtFirstName_nvc.Size = New System.Drawing.Size(10, 21)
        Me.txtFirstName_nvc.TabIndex = 40
        Me.txtFirstName_nvc.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(757, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "کددستگاه :"
        '
        'txtDeviceID
        '
        Me.txtDeviceID.Location = New System.Drawing.Point(689, 16)
        Me.txtDeviceID.Name = "txtDeviceID"
        Me.txtDeviceID.ReadOnly = True
        Me.txtDeviceID.Size = New System.Drawing.Size(66, 21)
        Me.txtDeviceID.TabIndex = 38
        '
        'lblPosId
        '
        Me.lblPosId.AutoSize = True
        Me.lblPosId.Location = New System.Drawing.Point(450, 18)
        Me.lblPosId.Name = "lblPosId"
        Me.lblPosId.Size = New System.Drawing.Size(34, 13)
        Me.lblPosId.TabIndex = 37
        Me.lblPosId.Text = "PosId"
        Me.lblPosId.Visible = False
        '
        'txtPosID
        '
        Me.txtPosID.Location = New System.Drawing.Point(408, 14)
        Me.txtPosID.Name = "txtPosID"
        Me.txtPosID.ReadOnly = True
        Me.txtPosID.Size = New System.Drawing.Size(39, 21)
        Me.txtPosID.TabIndex = 36
        Me.txtPosID.Visible = False
        '
        'txtPropertyNo_vc
        '
        Me.txtPropertyNo_vc.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPropertyNo_vc.Location = New System.Drawing.Point(217, 14)
        Me.txtPropertyNo_vc.MaxLength = 20
        Me.txtPropertyNo_vc.Name = "txtPropertyNo_vc"
        Me.txtPropertyNo_vc.Size = New System.Drawing.Size(100, 21)
        Me.txtPropertyNo_vc.TabIndex = 32
        Me.txtPropertyNo_vc.TabStop = False
        '
        'txtEniacCode_vc
        '
        Me.txtEniacCode_vc.BackColor = System.Drawing.Color.Gainsboro
        Me.txtEniacCode_vc.Location = New System.Drawing.Point(25, 14)
        Me.txtEniacCode_vc.MaxLength = 20
        Me.txtEniacCode_vc.Name = "txtEniacCode_vc"
        Me.txtEniacCode_vc.Size = New System.Drawing.Size(100, 21)
        Me.txtEniacCode_vc.TabIndex = 33
        Me.txtEniacCode_vc.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(131, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Eniac Code :"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(323, 19)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(71, 13)
        Me.Label35.TabIndex = 34
        Me.Label35.Text = "شماره اموال :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(592, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "شماره سریال پز :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(891, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "کد قرارداد :"
        '
        'txtSerial_vc
        '
        Me.txtSerial_vc.Location = New System.Drawing.Point(490, 14)
        Me.txtSerial_vc.Name = "txtSerial_vc"
        Me.txtSerial_vc.Size = New System.Drawing.Size(100, 21)
        Me.txtSerial_vc.TabIndex = 1
        '
        'txtContractID
        '
        Me.txtContractID.Location = New System.Drawing.Point(822, 16)
        Me.txtContractID.Name = "txtContractID"
        Me.txtContractID.ReadOnly = True
        Me.txtContractID.Size = New System.Drawing.Size(66, 21)
        Me.txtContractID.TabIndex = 0
        '
        'PrintDocument
        '
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnReAssigningEdit, Me.ToolStripSeparator2, Me.btnReAssignSave, Me.ToolStripSeparator3, Me.btnReAssignCancel, Me.ToolStripSeparator1, Me.btnAssignDelete, Me.ToolStripSeparator5, Me.btnAssignReprint, Me.ToolStripSeparator6, Me.btnAssignRefresh, Me.ToolStripSeparator7, Me.btnExportToExcel})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(977, 25)
        Me.tsMain.TabIndex = 24
        '
        'btnReAssigningEdit
        '
        Me.btnReAssigningEdit.Image = CType(resources.GetObject("btnReAssigningEdit.Image"), System.Drawing.Image)
        Me.btnReAssigningEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReAssigningEdit.Name = "btnReAssigningEdit"
        Me.btnReAssigningEdit.Size = New System.Drawing.Size(60, 22)
        Me.btnReAssigningEdit.Text = "ویرایش"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnReAssignSave
        '
        Me.btnReAssignSave.Image = CType(resources.GetObject("btnReAssignSave.Image"), System.Drawing.Image)
        Me.btnReAssignSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReAssignSave.Name = "btnReAssignSave"
        Me.btnReAssignSave.Size = New System.Drawing.Size(44, 22)
        Me.btnReAssignSave.Text = "ثبت"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnReAssignCancel
        '
        Me.btnReAssignCancel.Image = CType(resources.GetObject("btnReAssignCancel.Image"), System.Drawing.Image)
        Me.btnReAssignCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReAssignCancel.Name = "btnReAssignCancel"
        Me.btnReAssignCancel.Size = New System.Drawing.Size(60, 22)
        Me.btnReAssignCancel.Text = "انصراف"
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
        Me.btnAssignDelete.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator5.Visible = False
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
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'dgvReAssignablePos
        '
        Me.dgvReAssignablePos.AllowUserToAddRows = False
        Me.dgvReAssignablePos.AllowUserToDeleteRows = False
        Me.dgvReAssignablePos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReAssignablePos.Location = New System.Drawing.Point(11, 20)
        Me.dgvReAssignablePos.Name = "dgvReAssignablePos"
        Me.dgvReAssignablePos.ReadOnly = True
        Me.dgvReAssignablePos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReAssignablePos.Size = New System.Drawing.Size(933, 491)
        Me.dgvReAssignablePos.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvReAssignablePos)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(955, 525)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'frmDeviceReAssigning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 610)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeviceReAssigning"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تخصیص مجدد پز"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReAssignablePos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPosId As System.Windows.Forms.Label
    Friend WithEvents txtPosID As System.Windows.Forms.TextBox
    Friend WithEvents txtPropertyNo_vc As System.Windows.Forms.TextBox
    Friend WithEvents txtEniacCode_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSerial_vc As System.Windows.Forms.TextBox
    Friend WithEvents txtContractID As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAssignDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAssignReprint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAssignRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvReAssignablePos As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
    Friend WithEvents btnReAssignSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnReAssignCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnReAssigningEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtSCityName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents txtSName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName_nvc As System.Windows.Forms.TextBox
End Class
