<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPosID = New System.Windows.Forms.TextBox()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.cboGood = New System.Windows.Forms.ComboBox()
        Me.txtPartNo_int = New AMS.TextBox.NumericTextBox()
        Me.txtBatchNo_int = New AMS.TextBox.NumericTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboPosModel = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboPosTypeID = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtProductNo_vc = New System.Windows.Forms.TextBox()
        Me.txtEniacCode_vc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPropertyNo_vc = New System.Windows.Forms.TextBox()
        Me.chkActive_Tint = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerial_vc = New System.Windows.Forms.TextBox()
        Me.dgvPos = New System.Windows.Forms.DataGridView()
        Me.colPosID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGoodName_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActive_Tint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosTypeName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo_int = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPartNo_int = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosModelName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProductNo_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerial_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPropertyNo_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEniacCode_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosTypeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosModelID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsSupplier = New System.Windows.Forms.ToolStrip()
        Me.btnSaveAndNext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.cboSearchField = New System.Windows.Forms.ToolStripComboBox()
        Me.cboSearchOperation = New System.Windows.Forms.ToolStripComboBox()
        Me.txtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnSearchBack = New System.Windows.Forms.ToolStripButton()
        Me.btnRemoveFilter = New System.Windows.Forms.ToolStripButton()
        Me.DsReport21 = New DSReport2()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvPos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsSupplier.SuspendLayout()
        CType(Me.DsReport21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(43, 22)
        Me.btnSave.Text = "ثبت"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        Me.btnDelete.Size = New System.Drawing.Size(48, 22)
        Me.btnDelete.Text = "حذف"
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 22)
        Me.btnCancel.Text = "انصراف"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(58, 22)
        Me.btnEdit.Text = "ويرايش"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(851, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "سریال :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(852, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "کد :"
        '
        'txtPosID
        '
        Me.txtPosID.Location = New System.Drawing.Point(715, 16)
        Me.txtPosID.MaxLength = 3
        Me.txtPosID.Name = "txtPosID"
        Me.txtPosID.ReadOnly = True
        Me.txtPosID.Size = New System.Drawing.Size(134, 21)
        Me.txtPosID.TabIndex = 1
        Me.txtPosID.TabStop = False
        '
        'gbDetail
        '
        Me.gbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetail.Controls.Add(Me.cboGood)
        Me.gbDetail.Controls.Add(Me.txtPartNo_int)
        Me.gbDetail.Controls.Add(Me.txtBatchNo_int)
        Me.gbDetail.Controls.Add(Me.Label9)
        Me.gbDetail.Controls.Add(Me.cboPosModel)
        Me.gbDetail.Controls.Add(Me.Label8)
        Me.gbDetail.Controls.Add(Me.cboPosTypeID)
        Me.gbDetail.Controls.Add(Me.Label7)
        Me.gbDetail.Controls.Add(Me.Label6)
        Me.gbDetail.Controls.Add(Me.txtProductNo_vc)
        Me.gbDetail.Controls.Add(Me.txtEniacCode_vc)
        Me.gbDetail.Controls.Add(Me.Label5)
        Me.gbDetail.Controls.Add(Me.txtPropertyNo_vc)
        Me.gbDetail.Controls.Add(Me.chkActive_Tint)
        Me.gbDetail.Controls.Add(Me.Label3)
        Me.gbDetail.Controls.Add(Me.Label4)
        Me.gbDetail.Controls.Add(Me.txtSerial_vc)
        Me.gbDetail.Controls.Add(Me.txtPosID)
        Me.gbDetail.Controls.Add(Me.Label2)
        Me.gbDetail.Controls.Add(Me.Label1)
        Me.gbDetail.Location = New System.Drawing.Point(3, 422)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(928, 118)
        Me.gbDetail.TabIndex = 0
        Me.gbDetail.TabStop = False
        '
        'cboGood
        '
        Me.cboGood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGood.FormattingEnabled = True
        Me.cboGood.Location = New System.Drawing.Point(213, 40)
        Me.cboGood.Name = "cboGood"
        Me.cboGood.Size = New System.Drawing.Size(133, 21)
        Me.cboGood.TabIndex = 19
        '
        'txtPartNo_int
        '
        Me.txtPartNo_int.AllowNegative = True
        Me.txtPartNo_int.DigitsInGroup = 0
        Me.txtPartNo_int.Flags = 0
        Me.txtPartNo_int.Location = New System.Drawing.Point(348, 63)
        Me.txtPartNo_int.MaxDecimalPlaces = 4
        Me.txtPartNo_int.MaxLength = 5
        Me.txtPartNo_int.MaxWholeDigits = 5
        Me.txtPartNo_int.Name = "txtPartNo_int"
        Me.txtPartNo_int.Prefix = ""
        Me.txtPartNo_int.RangeMax = 1.7976931348623157E+308R
        Me.txtPartNo_int.RangeMin = -1.7976931348623157E+308R
        Me.txtPartNo_int.Size = New System.Drawing.Size(133, 21)
        Me.txtPartNo_int.TabIndex = 13
        '
        'txtBatchNo_int
        '
        Me.txtBatchNo_int.AllowNegative = True
        Me.txtBatchNo_int.DigitsInGroup = 0
        Me.txtBatchNo_int.Flags = 0
        Me.txtBatchNo_int.Location = New System.Drawing.Point(348, 86)
        Me.txtBatchNo_int.MaxDecimalPlaces = 4
        Me.txtBatchNo_int.MaxLength = 5
        Me.txtBatchNo_int.MaxWholeDigits = 5
        Me.txtBatchNo_int.Name = "txtBatchNo_int"
        Me.txtBatchNo_int.Prefix = ""
        Me.txtBatchNo_int.RangeMax = 1.7976931348623157E+308R
        Me.txtBatchNo_int.RangeMin = -1.7976931348623157E+308R
        Me.txtBatchNo_int.Size = New System.Drawing.Size(133, 21)
        Me.txtBatchNo_int.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(485, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "شماره بچ :"
        '
        'cboPosModel
        '
        Me.cboPosModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPosModel.FormattingEnabled = True
        Me.cboPosModel.Location = New System.Drawing.Point(348, 40)
        Me.cboPosModel.Name = "cboPosModel"
        Me.cboPosModel.Size = New System.Drawing.Size(133, 21)
        Me.cboPosModel.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(483, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "مدل دستگاه :"
        '
        'cboPosTypeID
        '
        Me.cboPosTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPosTypeID.FormattingEnabled = True
        Me.cboPosTypeID.Location = New System.Drawing.Point(13, 16)
        Me.cboPosTypeID.Name = "cboPosTypeID"
        Me.cboPosTypeID.Size = New System.Drawing.Size(119, 21)
        Me.cboPosTypeID.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(134, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "نوع دستگاه :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(485, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "شماره پارت :"
        '
        'txtProductNo_vc
        '
        Me.txtProductNo_vc.Location = New System.Drawing.Point(348, 16)
        Me.txtProductNo_vc.MaxLength = 20
        Me.txtProductNo_vc.Name = "txtProductNo_vc"
        Me.txtProductNo_vc.Size = New System.Drawing.Size(133, 21)
        Me.txtProductNo_vc.TabIndex = 9
        '
        'txtEniacCode_vc
        '
        Me.txtEniacCode_vc.Location = New System.Drawing.Point(715, 40)
        Me.txtEniacCode_vc.MaxLength = 20
        Me.txtEniacCode_vc.Name = "txtEniacCode_vc"
        Me.txtEniacCode_vc.Size = New System.Drawing.Size(134, 21)
        Me.txtEniacCode_vc.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(482, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "شماره محصول :"
        '
        'txtPropertyNo_vc
        '
        Me.txtPropertyNo_vc.Location = New System.Drawing.Point(715, 63)
        Me.txtPropertyNo_vc.MaxLength = 20
        Me.txtPropertyNo_vc.Name = "txtPropertyNo_vc"
        Me.txtPropertyNo_vc.Size = New System.Drawing.Size(134, 21)
        Me.txtPropertyNo_vc.TabIndex = 5
        '
        'chkActive_Tint
        '
        Me.chkActive_Tint.AutoSize = True
        Me.chkActive_Tint.Location = New System.Drawing.Point(85, 42)
        Me.chkActive_Tint.Name = "chkActive_Tint"
        Me.chkActive_Tint.Size = New System.Drawing.Size(49, 17)
        Me.chkActive_Tint.TabIndex = 18
        Me.chkActive_Tint.Text = "فعال"
        Me.chkActive_Tint.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(851, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "کد پیگیری :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(851, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "شماره اموال :"
        '
        'txtSerial_vc
        '
        Me.txtSerial_vc.Location = New System.Drawing.Point(715, 86)
        Me.txtSerial_vc.MaxLength = 20
        Me.txtSerial_vc.Name = "txtSerial_vc"
        Me.txtSerial_vc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSerial_vc.Size = New System.Drawing.Size(134, 21)
        Me.txtSerial_vc.TabIndex = 7
        '
        'dgvPos
        '
        Me.dgvPos.AllowUserToAddRows = False
        Me.dgvPos.AllowUserToDeleteRows = False
        Me.dgvPos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvPos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPosID, Me.colGoodName_vc, Me.colActive_Tint, Me.colPosTypeName_nvc, Me.colBatchNo_int, Me.colPartNo_int, Me.colPosModelName_nvc, Me.colProductNo_vc, Me.colSerial_vc, Me.colPropertyNo_vc, Me.colEniacCode_vc, Me.colPosTypeId, Me.colPosModelID})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPos.Location = New System.Drawing.Point(5, 55)
        Me.dgvPos.MultiSelect = False
        Me.dgvPos.Name = "dgvPos"
        Me.dgvPos.ReadOnly = True
        Me.dgvPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvPos.RowHeadersVisible = False
        Me.dgvPos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPos.Size = New System.Drawing.Size(926, 361)
        Me.dgvPos.TabIndex = 11
        '
        'colPosID
        '
        Me.colPosID.DataPropertyName = "PosID"
        Me.colPosID.HeaderText = "colPosID"
        Me.colPosID.Name = "colPosID"
        Me.colPosID.ReadOnly = True
        Me.colPosID.Visible = False
        '
        'colGoodName_vc
        '
        Me.colGoodName_vc.DataPropertyName = "GoodName_nvc"
        Me.colGoodName_vc.HeaderText = "ورژن مدل"
        Me.colGoodName_vc.Name = "colGoodName_vc"
        Me.colGoodName_vc.ReadOnly = True
        '
        'colActive_Tint
        '
        Me.colActive_Tint.DataPropertyName = "Active_Tint"
        Me.colActive_Tint.HeaderText = "فعال"
        Me.colActive_Tint.Name = "colActive_Tint"
        Me.colActive_Tint.ReadOnly = True
        '
        'colPosTypeName_nvc
        '
        Me.colPosTypeName_nvc.DataPropertyName = "PosTypeName_nvc"
        Me.colPosTypeName_nvc.HeaderText = "نوع دستگاه"
        Me.colPosTypeName_nvc.Name = "colPosTypeName_nvc"
        Me.colPosTypeName_nvc.ReadOnly = True
        '
        'colBatchNo_int
        '
        Me.colBatchNo_int.DataPropertyName = "BatchNo_int"
        Me.colBatchNo_int.HeaderText = "شماره بچ"
        Me.colBatchNo_int.Name = "colBatchNo_int"
        Me.colBatchNo_int.ReadOnly = True
        '
        'colPartNo_int
        '
        Me.colPartNo_int.DataPropertyName = "PartNo_int"
        Me.colPartNo_int.HeaderText = "شماره پارت"
        Me.colPartNo_int.Name = "colPartNo_int"
        Me.colPartNo_int.ReadOnly = True
        '
        'colPosModelName_nvc
        '
        Me.colPosModelName_nvc.DataPropertyName = "PosModelName_nvc"
        Me.colPosModelName_nvc.HeaderText = "مدل دستگاه"
        Me.colPosModelName_nvc.Name = "colPosModelName_nvc"
        Me.colPosModelName_nvc.ReadOnly = True
        '
        'colProductNo_vc
        '
        Me.colProductNo_vc.DataPropertyName = "ProductNo_vc"
        Me.colProductNo_vc.HeaderText = "شماره محصول"
        Me.colProductNo_vc.Name = "colProductNo_vc"
        Me.colProductNo_vc.ReadOnly = True
        '
        'colSerial_vc
        '
        Me.colSerial_vc.DataPropertyName = "Serial_vc"
        Me.colSerial_vc.HeaderText = "شماره سریال"
        Me.colSerial_vc.Name = "colSerial_vc"
        Me.colSerial_vc.ReadOnly = True
        '
        'colPropertyNo_vc
        '
        Me.colPropertyNo_vc.DataPropertyName = "PropertyNo_vc"
        Me.colPropertyNo_vc.HeaderText = "شماره اموال"
        Me.colPropertyNo_vc.Name = "colPropertyNo_vc"
        Me.colPropertyNo_vc.ReadOnly = True
        '
        'colEniacCode_vc
        '
        Me.colEniacCode_vc.DataPropertyName = "EniacCode_vc"
        Me.colEniacCode_vc.HeaderText = "کد پیگیری"
        Me.colEniacCode_vc.Name = "colEniacCode_vc"
        Me.colEniacCode_vc.ReadOnly = True
        '
        'colPosTypeId
        '
        Me.colPosTypeId.DataPropertyName = "PosTypeId"
        Me.colPosTypeId.HeaderText = "colPosTypeId"
        Me.colPosTypeId.Name = "colPosTypeId"
        Me.colPosTypeId.ReadOnly = True
        Me.colPosTypeId.Visible = False
        '
        'colPosModelID
        '
        Me.colPosModelID.DataPropertyName = "PosModelID"
        Me.colPosModelID.HeaderText = "colPosModelID"
        Me.colPosModelID.Name = "colPosModelID"
        Me.colPosModelID.ReadOnly = True
        Me.colPosModelID.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.Text = "جديد"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsSupplier
        '
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator3, Me.btnSave, Me.btnSaveAndNext, Me.ToolStripSeparator6, Me.btnCancel, Me.ToolStripSeparator5, Me.btnExportToExcel, Me.ToolStripSeparator4, Me.cboSearchField, Me.cboSearchOperation, Me.txtSearch, Me.btnSearch, Me.btnSearchBack, Me.btnRemoveFilter})
        Me.tsSupplier.Location = New System.Drawing.Point(0, 0)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(935, 25)
        Me.tsSupplier.TabIndex = 10
        '
        'btnSaveAndNext
        '
        Me.btnSaveAndNext.Image = CType(resources.GetObject("btnSaveAndNext.Image"), System.Drawing.Image)
        Me.btnSaveAndNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveAndNext.Name = "btnSaveAndNext"
        Me.btnSaveAndNext.Size = New System.Drawing.Size(78, 22)
        Me.btnSaveAndNext.Text = "ثبت و بعدی"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(96, 22)
        Me.btnExportToExcel.Text = "انتقال به Excel"
        '
        'cboSearchField
        '
        Me.cboSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchField.Name = "cboSearchField"
        Me.cboSearchField.Size = New System.Drawing.Size(121, 25)
        '
        'cboSearchOperation
        '
        Me.cboSearchOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchOperation.Name = "cboSearchOperation"
        Me.cboSearchOperation.Size = New System.Drawing.Size(121, 25)
        '
        'txtSearch
        '
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(100, 25)
        '
        'btnSearch
        '
        Me.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(23, 22)
        Me.btnSearch.Text = "Search"
        '
        'btnSearchBack
        '
        Me.btnSearchBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSearchBack.Image = CType(resources.GetObject("btnSearchBack.Image"), System.Drawing.Image)
        Me.btnSearchBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearchBack.Name = "btnSearchBack"
        Me.btnSearchBack.Size = New System.Drawing.Size(23, 22)
        Me.btnSearchBack.Text = "SearchBack"
        '
        'btnRemoveFilter
        '
        Me.btnRemoveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRemoveFilter.Image = CType(resources.GetObject("btnRemoveFilter.Image"), System.Drawing.Image)
        Me.btnRemoveFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRemoveFilter.Name = "btnRemoveFilter"
        Me.btnRemoveFilter.Size = New System.Drawing.Size(23, 22)
        Me.btnRemoveFilter.Text = "RemoveFilter"
        '
        'DsReport21
        '
        Me.DsReport21.DataSetName = "DSReport2"
        Me.DsReport21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmPos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 545)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.dgvPos)
        Me.Controls.Add(Me.tsSupplier)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPos"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعریف پز"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        CType(Me.dgvPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
        CType(Me.DsReport21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtSerial_vc As System.Windows.Forms.TextBox
    Friend WithEvents txtPosID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvPos As System.Windows.Forms.DataGridView
    Friend WithEvents tsSupplier As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkActive_Tint As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEniacCode_vc As System.Windows.Forms.TextBox
    Friend WithEvents txtPropertyNo_vc As System.Windows.Forms.TextBox
    Friend WithEvents txtProductNo_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboPosTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboPosModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboSearchField As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cboSearchOperation As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSearchBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRemoveFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBatchNo_int As AMS.TextBox.NumericTextBox
    Friend WithEvents btnSaveAndNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtPartNo_int As AMS.TextBox.NumericTextBox
    Friend WithEvents cboGood As System.Windows.Forms.ComboBox
    Friend WithEvents colPosID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGoodName_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActive_Tint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosTypeName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo_int As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartNo_int As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosModelName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProductNo_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerial_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPropertyNo_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEniacCode_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosTypeId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosModelID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DsReport21 As DSReport2
End Class
