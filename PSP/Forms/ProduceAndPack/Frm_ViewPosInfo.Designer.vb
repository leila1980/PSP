<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ViewPosInfo
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ViewPosInfo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Count = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Batch = New System.Windows.Forms.TextBox()
        Me.Dgv_Packing = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Tsb_View = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Tsb_ExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PnlEdit = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_PartNo = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Cmb_Date = New FarsiLibrary.Win.Controls.FADatePicker()
        Me.Cmb_PM = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_PN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_EniacCode = New System.Windows.Forms.TextBox()
        Me.Txt_PosSelrial = New System.Windows.Forms.TextBox()
        Me.Txt_PropertyCode = New System.Windows.Forms.TextBox()
        Me.ColEniacCoder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPropertyCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv_Packing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lbl_Count)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Txt_Batch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Yellow
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 44)
        Me.Panel1.TabIndex = 1
        '
        'lbl_Count
        '
        Me.lbl_Count.ForeColor = System.Drawing.Color.Black
        Me.lbl_Count.Location = New System.Drawing.Point(4, 15)
        Me.lbl_Count.Name = "lbl_Count"
        Me.lbl_Count.Size = New System.Drawing.Size(66, 14)
        Me.lbl_Count.TabIndex = 30
        Me.lbl_Count.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(76, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 14)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "تعداد"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(667, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "شماره بچ"
        '
        'Txt_Batch
        '
        Me.Txt_Batch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Batch.ForeColor = System.Drawing.Color.Black
        Me.Txt_Batch.Location = New System.Drawing.Point(501, 12)
        Me.Txt_Batch.Name = "Txt_Batch"
        Me.Txt_Batch.Size = New System.Drawing.Size(162, 22)
        Me.Txt_Batch.TabIndex = 6
        Me.Txt_Batch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Dgv_Packing
        '
        Me.Dgv_Packing.AllowUserToAddRows = False
        Me.Dgv_Packing.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        Me.Dgv_Packing.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Packing.BackgroundColor = System.Drawing.SystemColors.ControlDark
        Me.Dgv_Packing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Packing.ColumnHeadersHeight = 30
        Me.Dgv_Packing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColEniacCoder, Me.ColPropertyCode, Me.ColSerial, Me.ColPM, Me.ColPN, Me.ColPartNo, Me.ColDate})
        Me.Dgv_Packing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Packing.Location = New System.Drawing.Point(0, 69)
        Me.Dgv_Packing.MultiSelect = False
        Me.Dgv_Packing.Name = "Dgv_Packing"
        Me.Dgv_Packing.ReadOnly = True
        Me.Dgv_Packing.RowHeadersWidth = 5
        Me.Dgv_Packing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Packing.Size = New System.Drawing.Size(735, 251)
        Me.Dgv_Packing.TabIndex = 4
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tsb_View, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator5, Me.btnCancel, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator2, Me.Tsb_ExportToExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(735, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Tsb_View
        '
        Me.Tsb_View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Tsb_View.Image = CType(resources.GetObject("Tsb_View.Image"), System.Drawing.Image)
        Me.Tsb_View.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsb_View.Name = "Tsb_View"
        Me.Tsb_View.Size = New System.Drawing.Size(45, 22)
        Me.Tsb_View.Text = "مشاهده"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(58, 22)
        Me.btnEdit.Text = "ويرايش"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 22)
        Me.btnCancel.Text = "انصراف"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(43, 22)
        Me.btnSave.Text = "ثبت"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Tsb_ExportToExcel
        '
        Me.Tsb_ExportToExcel.Image = CType(resources.GetObject("Tsb_ExportToExcel.Image"), System.Drawing.Image)
        Me.Tsb_ExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsb_ExportToExcel.Name = "Tsb_ExportToExcel"
        Me.Tsb_ExportToExcel.Size = New System.Drawing.Size(100, 22)
        Me.Tsb_ExportToExcel.Text = "ExportToExcel"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'PnlEdit
        '
        Me.PnlEdit.BackColor = System.Drawing.SystemColors.Control
        Me.PnlEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlEdit.Controls.Add(Me.Label7)
        Me.PnlEdit.Controls.Add(Me.Txt_PartNo)
        Me.PnlEdit.Controls.Add(Me.lblDate)
        Me.PnlEdit.Controls.Add(Me.Cmb_Date)
        Me.PnlEdit.Controls.Add(Me.Cmb_PM)
        Me.PnlEdit.Controls.Add(Me.Label5)
        Me.PnlEdit.Controls.Add(Me.Txt_PN)
        Me.PnlEdit.Controls.Add(Me.Label4)
        Me.PnlEdit.Controls.Add(Me.Label3)
        Me.PnlEdit.Controls.Add(Me.Label2)
        Me.PnlEdit.Controls.Add(Me.Label9)
        Me.PnlEdit.Controls.Add(Me.Txt_EniacCode)
        Me.PnlEdit.Controls.Add(Me.Txt_PosSelrial)
        Me.PnlEdit.Controls.Add(Me.Txt_PropertyCode)
        Me.PnlEdit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlEdit.Enabled = False
        Me.PnlEdit.Location = New System.Drawing.Point(0, 320)
        Me.PnlEdit.Name = "PnlEdit"
        Me.PnlEdit.Size = New System.Drawing.Size(735, 123)
        Me.PnlEdit.TabIndex = 46
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(367, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 14)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "شماره پارت"
        '
        'Txt_PartNo
        '
        Me.Txt_PartNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_PartNo.BackColor = System.Drawing.Color.White
        Me.Txt_PartNo.ForeColor = System.Drawing.Color.Black
        Me.Txt_PartNo.Location = New System.Drawing.Point(199, 65)
        Me.Txt_PartNo.Name = "Txt_PartNo"
        Me.Txt_PartNo.Size = New System.Drawing.Size(162, 22)
        Me.Txt_PartNo.TabIndex = 39
        Me.Txt_PartNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.AutoSize = True
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(651, 95)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(29, 14)
        Me.lblDate.TabIndex = 38
        Me.lblDate.Text = "تاریخ"
        '
        'Cmb_Date
        '
        Me.Cmb_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb_Date.Location = New System.Drawing.Point(489, 92)
        Me.Cmb_Date.Name = "Cmb_Date"
        Me.Cmb_Date.Size = New System.Drawing.Size(152, 20)
        Me.Cmb_Date.TabIndex = 37
        Me.Cmb_Date.TextHorizontalAlignment = FarsiLibrary.Win.Enums.TextAlignment.Center
        Me.Cmb_Date.TextVerticalAlignment = FarsiLibrary.Win.Enums.TextAlignment.Center
        '
        'Cmb_PM
        '
        Me.Cmb_PM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb_PM.BackColor = System.Drawing.Color.White
        Me.Cmb_PM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_PM.FormattingEnabled = True
        Me.Cmb_PM.Location = New System.Drawing.Point(199, 37)
        Me.Cmb_PM.Name = "Cmb_PM"
        Me.Cmb_PM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Cmb_PM.Size = New System.Drawing.Size(162, 22)
        Me.Cmb_PM.TabIndex = 32
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(367, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 14)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "PN محصول"
        '
        'Txt_PN
        '
        Me.Txt_PN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_PN.BackColor = System.Drawing.Color.White
        Me.Txt_PN.ForeColor = System.Drawing.Color.Black
        Me.Txt_PN.Location = New System.Drawing.Point(199, 10)
        Me.Txt_PN.Name = "Txt_PN"
        Me.Txt_PN.Size = New System.Drawing.Size(162, 22)
        Me.Txt_PN.TabIndex = 30
        Me.Txt_PN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(367, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "مدل دستگاه"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(647, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "کد پیگیری"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(647, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 14)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "سریال دستگاه"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(647, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 14)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "کد اموال"
        '
        'Txt_EniacCode
        '
        Me.Txt_EniacCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_EniacCode.BackColor = System.Drawing.Color.GhostWhite
        Me.Txt_EniacCode.ForeColor = System.Drawing.Color.Black
        Me.Txt_EniacCode.Location = New System.Drawing.Point(489, 10)
        Me.Txt_EniacCode.Name = "Txt_EniacCode"
        Me.Txt_EniacCode.ReadOnly = True
        Me.Txt_EniacCode.Size = New System.Drawing.Size(152, 22)
        Me.Txt_EniacCode.TabIndex = 27
        Me.Txt_EniacCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_PosSelrial
        '
        Me.Txt_PosSelrial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_PosSelrial.BackColor = System.Drawing.Color.White
        Me.Txt_PosSelrial.ForeColor = System.Drawing.Color.Black
        Me.Txt_PosSelrial.Location = New System.Drawing.Point(489, 65)
        Me.Txt_PosSelrial.Name = "Txt_PosSelrial"
        Me.Txt_PosSelrial.Size = New System.Drawing.Size(152, 22)
        Me.Txt_PosSelrial.TabIndex = 29
        Me.Txt_PosSelrial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_PropertyCode
        '
        Me.Txt_PropertyCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_PropertyCode.BackColor = System.Drawing.Color.GhostWhite
        Me.Txt_PropertyCode.ForeColor = System.Drawing.Color.Black
        Me.Txt_PropertyCode.Location = New System.Drawing.Point(489, 37)
        Me.Txt_PropertyCode.Name = "Txt_PropertyCode"
        Me.Txt_PropertyCode.ReadOnly = True
        Me.Txt_PropertyCode.Size = New System.Drawing.Size(152, 22)
        Me.Txt_PropertyCode.TabIndex = 28
        Me.Txt_PropertyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColEniacCoder
        '
        Me.ColEniacCoder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColEniacCoder.DataPropertyName = "EniacCode_vc"
        Me.ColEniacCoder.HeaderText = "کد پیگیری"
        Me.ColEniacCoder.Name = "ColEniacCoder"
        Me.ColEniacCoder.ReadOnly = True
        Me.ColEniacCoder.Width = 81
        '
        'ColPropertyCode
        '
        Me.ColPropertyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColPropertyCode.DataPropertyName = "PropertyNo_vc"
        Me.ColPropertyCode.HeaderText = "کد اموال"
        Me.ColPropertyCode.Name = "ColPropertyCode"
        Me.ColPropertyCode.ReadOnly = True
        Me.ColPropertyCode.Width = 74
        '
        'ColSerial
        '
        Me.ColSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColSerial.DataPropertyName = "Serial_vc"
        Me.ColSerial.HeaderText = "سریال دستگاه"
        Me.ColSerial.Name = "ColSerial"
        Me.ColSerial.ReadOnly = True
        Me.ColSerial.Width = 106
        '
        'ColPM
        '
        Me.ColPM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColPM.DataPropertyName = "ProductModel"
        Me.ColPM.HeaderText = "مدل دستگاه"
        Me.ColPM.Name = "ColPM"
        Me.ColPM.ReadOnly = True
        '
        'ColPN
        '
        Me.ColPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColPN.DataPropertyName = "ProductNo_vc"
        Me.ColPN.HeaderText = "PN دستگاه"
        Me.ColPN.Name = "ColPN"
        Me.ColPN.ReadOnly = True
        Me.ColPN.Width = 89
        '
        'ColPartNo
        '
        Me.ColPartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColPartNo.DataPropertyName = "PartNo_int"
        Me.ColPartNo.HeaderText = "شماره پارت"
        Me.ColPartNo.Name = "ColPartNo"
        Me.ColPartNo.ReadOnly = True
        Me.ColPartNo.Width = 90
        '
        'ColDate
        '
        Me.ColDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColDate.DataPropertyName = "ModifyDate_vc"
        Me.ColDate.HeaderText = "تاریخ"
        Me.ColDate.Name = "ColDate"
        Me.ColDate.ReadOnly = True
        Me.ColDate.Width = 54
        '
        'Frm_ViewPosInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 443)
        Me.Controls.Add(Me.Dgv_Packing)
        Me.Controls.Add(Me.PnlEdit)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ViewPosInfo"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نمایش اطلاعات POS ها"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Dgv_Packing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlEdit.ResumeLayout(False)
        Me.PnlEdit.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_Batch As System.Windows.Forms.TextBox
    Friend WithEvents Dgv_Packing As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Tsb_View As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Tsb_ExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents lbl_Count As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PnlEdit As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_PartNo As System.Windows.Forms.TextBox
    Private WithEvents lblDate As System.Windows.Forms.Label
    Private WithEvents Cmb_Date As FarsiLibrary.Win.Controls.FADatePicker
    Friend WithEvents Cmb_PM As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_PN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_EniacCode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PosSelrial As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PropertyCode As System.Windows.Forms.TextBox
    Friend WithEvents ColEniacCoder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPropertyCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSerial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
