<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWarehouseTransfer
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWarehouseTransfer))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbReason = New System.Windows.Forms.ComboBox()
        Me.txtWarehouseDescription = New System.Windows.Forms.TextBox()
        Me.dttxtDate = New DateTextBox.DateTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAccountName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAccount = New System.Windows.Forms.Button()
        Me.txtAccountID = New System.Windows.Forms.TextBox()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.txtStatementNo = New AMS.TextBox.NumericTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvWarehouseDetail = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnExcelImport = New System.Windows.Forms.Button()
        Me.lbCount = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSerialNo = New System.Windows.Forms.TextBox()
        Me.dgvWarehouseSerials = New System.Windows.Forms.DataGridView()
        Me.SerialOrder_int = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerialNO_vcS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrintNameh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_ImportSerials = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGenerateSerial = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.SerialExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblWait = New System.Windows.Forms.ToolStripLabel()
        Me.btnNext = New System.Windows.Forms.ToolStripButton()
        Me.btnPrevious = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel13 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel15 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel17 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnConfirmPrint = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.warehouseOrder_int = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GoodID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name_vc = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GoodCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemindedGood = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvWarehouseDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvWarehouseSerials, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbReason)
        Me.GroupBox1.Controls.Add(Me.txtWarehouseDescription)
        Me.GroupBox1.Controls.Add(Me.dttxtDate)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtAccountName)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnAccount)
        Me.GroupBox1.Controls.Add(Me.txtAccountID)
        Me.GroupBox1.Controls.Add(Me.cmbProject)
        Me.GroupBox1.Controls.Add(Me.txtStatementNo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(950, 90)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbReason
        '
        Me.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReason.FormattingEnabled = True
        Me.cmbReason.Location = New System.Drawing.Point(7, 39)
        Me.cmbReason.Name = "cmbReason"
        Me.cmbReason.Size = New System.Drawing.Size(179, 21)
        Me.cmbReason.TabIndex = 15
        '
        'txtWarehouseDescription
        '
        Me.txtWarehouseDescription.Location = New System.Drawing.Point(7, 65)
        Me.txtWarehouseDescription.Name = "txtWarehouseDescription"
        Me.txtWarehouseDescription.Size = New System.Drawing.Size(852, 21)
        Me.txtWarehouseDescription.TabIndex = 14
        '
        'dttxtDate
        '
        Me.dttxtDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dttxtDate.AutoSize = True
        Me.dttxtDate.BackColor = System.Drawing.SystemColors.MenuBar
        Me.dttxtDate.DateBackColor = System.Drawing.SystemColors.Window
        Me.dttxtDate.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.dttxtDate.DateReadOnly = False
        Me.dttxtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dttxtDate.Location = New System.Drawing.Point(426, 12)
        Me.dttxtDate.Name = "dttxtDate"
        Me.dttxtDate.Size = New System.Drawing.Size(114, 20)
        Me.dttxtDate.TabIndex = 3
        Me.dttxtDate.TabStop = False
        Me.dttxtDate.Value = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(865, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "شرح "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(192, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "علت سند"
        '
        'txtAccountName
        '
        Me.txtAccountName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAccountName.Location = New System.Drawing.Point(301, 38)
        Me.txtAccountName.MaxLength = 100
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.ReadOnly = True
        Me.txtAccountName.Size = New System.Drawing.Size(239, 21)
        Me.txtAccountName.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(864, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "کد طرف حساب "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(546, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "نام طرف حساب "
        '
        'btnAccount
        '
        Me.btnAccount.Location = New System.Drawing.Point(707, 39)
        Me.btnAccount.Name = "btnAccount"
        Me.btnAccount.Size = New System.Drawing.Size(31, 21)
        Me.btnAccount.TabIndex = 8
        Me.btnAccount.Text = "..."
        Me.btnAccount.UseVisualStyleBackColor = True
        '
        'txtAccountID
        '
        Me.txtAccountID.Location = New System.Drawing.Point(744, 38)
        Me.txtAccountID.MaxLength = 100
        Me.txtAccountID.Name = "txtAccountID"
        Me.txtAccountID.Size = New System.Drawing.Size(114, 21)
        Me.txtAccountID.TabIndex = 7
        '
        'cmbProject
        '
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(7, 12)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(179, 21)
        Me.cmbProject.TabIndex = 5
        '
        'txtStatementNo
        '
        Me.txtStatementNo.AllowNegative = True
        Me.txtStatementNo.DigitsInGroup = 0
        Me.txtStatementNo.Flags = 0
        Me.txtStatementNo.Location = New System.Drawing.Point(745, 12)
        Me.txtStatementNo.MaxDecimalPlaces = 4
        Me.txtStatementNo.MaxLength = 18
        Me.txtStatementNo.MaxWholeDigits = 9
        Me.txtStatementNo.Name = "txtStatementNo"
        Me.txtStatementNo.Prefix = ""
        Me.txtStatementNo.RangeMax = 1.7976931348623157E+308R
        Me.txtStatementNo.RangeMin = -1.7976931348623157E+308R
        Me.txtStatementNo.ReadOnly = True
        Me.txtStatementNo.Size = New System.Drawing.Size(114, 21)
        Me.txtStatementNo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(192, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "پروژه"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(561, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "تاریخ "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(865, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "شماره سند"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvWarehouseDetail)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 123)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(642, 377)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "اقلام"
        '
        'dgvWarehouseDetail
        '
        Me.dgvWarehouseDetail.AllowUserToDeleteRows = False
        Me.dgvWarehouseDetail.AllowUserToResizeRows = False
        Me.dgvWarehouseDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWarehouseDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.warehouseOrder_int, Me.GoodID, Me.Name_vc, Me.GoodCount, Me.RemindedGood})
        Me.dgvWarehouseDetail.Location = New System.Drawing.Point(6, 15)
        Me.dgvWarehouseDetail.MultiSelect = False
        Me.dgvWarehouseDetail.Name = "dgvWarehouseDetail"
        Me.dgvWarehouseDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvWarehouseDetail.ShowCellErrors = False
        Me.dgvWarehouseDetail.ShowRowErrors = False
        Me.dgvWarehouseDetail.Size = New System.Drawing.Size(628, 356)
        Me.dgvWarehouseDetail.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExcelImport)
        Me.GroupBox3.Controls.Add(Me.lbCount)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtSerialNo)
        Me.GroupBox3.Controls.Add(Me.dgvWarehouseSerials)
        Me.GroupBox3.Location = New System.Drawing.Point(652, 123)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(309, 377)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "سریال ها"
        '
        'btnExcelImport
        '
        Me.btnExcelImport.Enabled = False
        Me.btnExcelImport.Image = Global.My.Resources.Resources.excel_icon
        Me.btnExcelImport.Location = New System.Drawing.Point(7, 15)
        Me.btnExcelImport.Name = "btnExcelImport"
        Me.btnExcelImport.Size = New System.Drawing.Size(25, 23)
        Me.btnExcelImport.TabIndex = 5
        Me.btnExcelImport.UseVisualStyleBackColor = True
        '
        'lbCount
        '
        Me.lbCount.AutoSize = True
        Me.lbCount.Location = New System.Drawing.Point(244, 354)
        Me.lbCount.Name = "lbCount"
        Me.lbCount.Size = New System.Drawing.Size(13, 13)
        Me.lbCount.TabIndex = 4
        Me.lbCount.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(255, 354)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "تعداد کل"
        '
        'txtSerialNo
        '
        Me.txtSerialNo.Enabled = False
        Me.txtSerialNo.Location = New System.Drawing.Point(38, 15)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSerialNo.Size = New System.Drawing.Size(265, 21)
        Me.txtSerialNo.TabIndex = 0
        '
        'dgvWarehouseSerials
        '
        Me.dgvWarehouseSerials.AllowUserToAddRows = False
        Me.dgvWarehouseSerials.AllowUserToDeleteRows = False
        Me.dgvWarehouseSerials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWarehouseSerials.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SerialOrder_int, Me.SerialNO_vcS, Me.colDelete})
        Me.dgvWarehouseSerials.Location = New System.Drawing.Point(5, 41)
        Me.dgvWarehouseSerials.Name = "dgvWarehouseSerials"
        Me.dgvWarehouseSerials.RowHeadersVisible = False
        Me.dgvWarehouseSerials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWarehouseSerials.Size = New System.Drawing.Size(298, 305)
        Me.dgvWarehouseSerials.TabIndex = 2
        '
        'SerialOrder_int
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SerialOrder_int.DefaultCellStyle = DataGridViewCellStyle5
        Me.SerialOrder_int.HeaderText = "ردیف"
        Me.SerialOrder_int.Name = "SerialOrder_int"
        Me.SerialOrder_int.ReadOnly = True
        Me.SerialOrder_int.Width = 70
        '
        'SerialNO_vcS
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SerialNO_vcS.DefaultCellStyle = DataGridViewCellStyle6
        Me.SerialNO_vcS.HeaderText = "شماره سریال"
        Me.SerialNO_vcS.MaxInputLength = 18
        Me.SerialNO_vcS.Name = "SerialNO_vcS"
        Me.SerialNO_vcS.ReadOnly = True
        Me.SerialNO_vcS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SerialNO_vcS.Width = 185
        '
        'colDelete
        '
        Me.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.colDelete.HeaderText = "حذف"
        Me.colDelete.Name = "colDelete"
        Me.colDelete.Text = "حذف"
        Me.colDelete.UseColumnTextForButtonValue = True
        Me.colDelete.Width = 36
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator2, Me.btnCancel1, Me.ToolStripSeparator6, Me.btnPrint, Me.btnDelete, Me.ToolStripSeparator4, Me.ToolStripSeparator3, Me.btnPrintNameh, Me.ToolStripSeparator9, Me.btn_ImportSerials, Me.ToolStripSeparator1, Me.btnImport, Me.ToolStripSeparator5, Me.btnGenerateSerial, Me.ToolStripSeparator8, Me.SerialExport, Me.ToolStripSeparator7, Me.lblWait, Me.btnNext, Me.btnPrevious})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(961, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(43, 22)
        Me.btnSave.Text = "ثبت"
        Me.btnSave.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'btnCancel1
        '
        Me.btnCancel1.Image = CType(resources.GetObject("btnCancel1.Image"), System.Drawing.Image)
        Me.btnCancel1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel1.Name = "btnCancel1"
        Me.btnCancel1.Size = New System.Drawing.Size(62, 22)
        Me.btnCancel1.Text = "انصراف"
        Me.btnCancel1.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator6.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(71, 22)
        Me.btnPrint.Text = "چاپ سند "
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(48, 22)
        Me.btnDelete.Text = "حذف"
        Me.btnDelete.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator4.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator3.Visible = False
        '
        'btnPrintNameh
        '
        Me.btnPrintNameh.Image = CType(resources.GetObject("btnPrintNameh.Image"), System.Drawing.Image)
        Me.btnPrintNameh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrintNameh.Name = "btnPrintNameh"
        Me.btnPrintNameh.Size = New System.Drawing.Size(72, 22)
        Me.btnPrintNameh.Text = "چاپ نامه "
        Me.btnPrintNameh.Visible = False
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator9.Visible = False
        '
        'btn_ImportSerials
        '
        Me.btn_ImportSerials.Image = CType(resources.GetObject("btn_ImportSerials.Image"), System.Drawing.Image)
        Me.btn_ImportSerials.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_ImportSerials.Name = "btn_ImportSerials"
        Me.btn_ImportSerials.Size = New System.Drawing.Size(94, 22)
        Me.btn_ImportSerials.Text = "Serial Import"
        Me.btn_ImportSerials.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator1.Visible = False
        '
        'btnImport
        '
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(84, 22)
        Me.btnImport.Text = "File Import"
        Me.btnImport.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator5.Visible = False
        '
        'btnGenerateSerial
        '
        Me.btnGenerateSerial.Image = CType(resources.GetObject("btnGenerateSerial.Image"), System.Drawing.Image)
        Me.btnGenerateSerial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerateSerial.Name = "btnGenerateSerial"
        Me.btnGenerateSerial.Size = New System.Drawing.Size(81, 22)
        Me.btnGenerateSerial.Text = "تولید سریال"
        Me.btnGenerateSerial.Visible = False
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator8.Visible = False
        '
        'SerialExport
        '
        Me.SerialExport.Image = CType(resources.GetObject("SerialExport.Image"), System.Drawing.Image)
        Me.SerialExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SerialExport.Name = "SerialExport"
        Me.SerialExport.Size = New System.Drawing.Size(91, 22)
        Me.SerialExport.Text = "Serial Export"
        Me.SerialExport.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator7.Visible = False
        '
        'lblWait
        '
        Me.lblWait.ForeColor = System.Drawing.Color.DarkRed
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(93, 22)
        Me.lblWait.Text = "لطفا منتظر بمانید..."
        Me.lblWait.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.RightToLeftAutoMirrorImage = True
        Me.btnNext.Size = New System.Drawing.Size(23, 22)
        Me.btnNext.Text = "Move next"
        Me.btnNext.Visible = False
        '
        'btnPrevious
        '
        Me.btnPrevious.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrevious.Image = CType(resources.GetObject("btnPrevious.Image"), System.Drawing.Image)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.RightToLeftAutoMirrorImage = True
        Me.btnPrevious.Size = New System.Drawing.Size(23, 22)
        Me.btnPrevious.Text = "Move previous"
        Me.btnPrevious.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel11, Me.ToolStripStatusLabel13, Me.ToolStripStatusLabel15, Me.ToolStripStatusLabel17})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 514)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(961, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        Me.StatusStrip1.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(87, 17)
        Me.ToolStripStatusLabel1.Text = "F3 : انتخاب کالا   "
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(82, 17)
        Me.ToolStripStatusLabel3.Text = "F4 : تعریف کالا  "
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(113, 17)
        Me.ToolStripStatusLabel5.Text = "F6 : اضافه کردن سطر  "
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(80, 17)
        Me.ToolStripStatusLabel7.Text = "F7 : حذف سطر  "
        '
        'ToolStripStatusLabel9
        '
        Me.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9"
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(50, 17)
        Me.ToolStripStatusLabel9.Text = "F2 : ثبت  "
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(74, 17)
        Me.ToolStripStatusLabel11.Text = "Esc : انصراف  "
        '
        'ToolStripStatusLabel13
        '
        Me.ToolStripStatusLabel13.Name = "ToolStripStatusLabel13"
        Me.ToolStripStatusLabel13.Size = New System.Drawing.Size(76, 17)
        Me.ToolStripStatusLabel13.Text = "F8 : حذف سند  "
        '
        'ToolStripStatusLabel15
        '
        Me.ToolStripStatusLabel15.Name = "ToolStripStatusLabel15"
        Me.ToolStripStatusLabel15.Size = New System.Drawing.Size(54, 17)
        Me.ToolStripStatusLabel15.Text = "F9 : چاپ  "
        '
        'ToolStripStatusLabel17
        '
        Me.ToolStripStatusLabel17.Name = "ToolStripStatusLabel17"
        Me.ToolStripStatusLabel17.Size = New System.Drawing.Size(146, 17)
        Me.ToolStripStatusLabel17.Text = "Delete : حذف  محتویات سلول  "
        '
        'btnConfirmPrint
        '
        Me.btnConfirmPrint.Location = New System.Drawing.Point(17, 506)
        Me.btnConfirmPrint.Name = "btnConfirmPrint"
        Me.btnConfirmPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirmPrint.TabIndex = 5
        Me.btnConfirmPrint.Text = "تایید و چاپ"
        Me.btnConfirmPrint.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(178, 506)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "انصراف"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(97, 506)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 7
        Me.btnConfirm.Text = "تایید"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'warehouseOrder_int
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.warehouseOrder_int.DefaultCellStyle = DataGridViewCellStyle1
        Me.warehouseOrder_int.Frozen = True
        Me.warehouseOrder_int.HeaderText = "ردیف"
        Me.warehouseOrder_int.Name = "warehouseOrder_int"
        Me.warehouseOrder_int.ReadOnly = True
        Me.warehouseOrder_int.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.warehouseOrder_int.Width = 70
        '
        'GoodID
        '
        Me.GoodID.DataPropertyName = "good_id"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GoodID.DefaultCellStyle = DataGridViewCellStyle2
        Me.GoodID.HeaderText = "کدکالا"
        Me.GoodID.Name = "GoodID"
        Me.GoodID.ReadOnly = True
        Me.GoodID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GoodID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GoodID.Width = 70
        '
        'Name_vc
        '
        Me.Name_vc.DataPropertyName = "name_nvc"
        Me.Name_vc.HeaderText = "نام کالا"
        Me.Name_vc.Name = "Name_vc"
        Me.Name_vc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Name_vc.Width = 250
        '
        'GoodCount
        '
        Me.GoodCount.DataPropertyName = "count"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GoodCount.DefaultCellStyle = DataGridViewCellStyle3
        Me.GoodCount.HeaderText = "تعداد"
        Me.GoodCount.Name = "GoodCount"
        Me.GoodCount.ReadOnly = True
        Me.GoodCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GoodCount.Width = 80
        '
        'RemindedGood
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RemindedGood.DefaultCellStyle = DataGridViewCellStyle4
        Me.RemindedGood.HeaderText = "موجودی"
        Me.RemindedGood.Name = "RemindedGood"
        Me.RemindedGood.ReadOnly = True
        Me.RemindedGood.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RemindedGood.Width = 80
        '
        'frmWarehouseTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 536)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfirmPrint)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWarehouseTransfer"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "فرم نقل و انتقال"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvWarehouseDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvWarehouseSerials, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents btnAccount As System.Windows.Forms.Button
    Public WithEvents txtAccountID As System.Windows.Forms.TextBox
    Public WithEvents cmbProject As System.Windows.Forms.ComboBox
    Public WithEvents txtStatementNo As AMS.TextBox.NumericTextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtAccountName As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents dgvWarehouseDetail As System.Windows.Forms.DataGridView
    Public WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Public WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents dgvWarehouseSerials As System.Windows.Forms.DataGridView
    Public WithEvents dttxtDate As DateTextBox.DateTextBox
    Public WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Public WithEvents btnCancel1 As System.Windows.Forms.ToolStripButton
    Public WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Public WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Public WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Public WithEvents btnGenerateSerial As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents lblWait As System.Windows.Forms.ToolStripLabel
    Public WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Public WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents txtSerialNo As System.Windows.Forms.TextBox
    Public WithEvents ToolStripStatusLabel9 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents ToolStripStatusLabel13 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents ToolStripStatusLabel15 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents ToolStripStatusLabel17 As System.Windows.Forms.ToolStripStatusLabel
    'Public WithEvents txtDescription As MyPersianTextBox
    Friend WithEvents btnPrevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNext As System.Windows.Forms.ToolStripButton
    Public WithEvents btn_ImportSerials As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtWarehouseDescription As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents SerialExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents btnPrintNameh As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnConfirmPrint As System.Windows.Forms.Button
    Friend WithEvents lbCount As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents cmbReason As System.Windows.Forms.ComboBox
    Friend WithEvents btnExcelImport As System.Windows.Forms.Button
    Friend WithEvents SerialOrder_int As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNO_vcS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDelete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents warehouseOrder_int As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GoodID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name_vc As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents GoodCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemindedGood As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
