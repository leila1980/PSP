<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignPosToVisitor
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignPosToVisitor))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsSupplier = New System.Windows.Forms.ToolStrip()
        Me.cboSearchField = New System.Windows.Forms.ToolStripComboBox()
        Me.cboSearchOperation = New System.Windows.Forms.ToolStripComboBox()
        Me.txtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnSearchBack = New System.Windows.Forms.ToolStripButton()
        Me.btnRemoveFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.btnSelectFromExcel = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboVisitor = New System.Windows.Forms.ComboBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.cboSelectedSearchField = New System.Windows.Forms.ToolStripComboBox()
        Me.cboSelectedSearchOperation = New System.Windows.Forms.ToolStripComboBox()
        Me.txtSelectedSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.btnSelectedSearch = New System.Windows.Forms.ToolStripButton()
        Me.btnSelectedSearchBack = New System.Windows.Forms.ToolStripButton()
        Me.btnSelectedRemoveFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSelectedExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.btnSelectFromExcelSelected = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnReTransferToOtherBank = New System.Windows.Forms.Button()
        Me.btnUnCheckB2B = New System.Windows.Forms.Button()
        Me.btnCheckB2B = New System.Windows.Forms.Button()
        Me.btnCancelReturn = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnAcceptReturnedPos = New System.Windows.Forms.Button()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.btnTransferToOtherBank = New System.Windows.Forms.Button()
        Me.btnCancelAssignment = New System.Windows.Forms.Button()
        Me.btnAssign = New System.Windows.Forms.Button()
        Me.dgvselectedPos = New System.Windows.Forms.DataGridView()
        Me.colSelectedStatus = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colOperationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PosStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStatusDateFaSelected = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSelectedPosID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSelectedEniacCode_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSelectedSerial_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.colPosID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEniacCode_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPropertyNo_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerial_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProductNo_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosModelName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPartNo_int = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo_int = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosTypeName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActive_Tint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatusDateFa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosTypeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPosModelID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSelectAll = New System.Windows.Forms.ToolStripButton()
        Me.btnUnSelect = New System.Windows.Forms.ToolStripButton()
        Me.InventSelect = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblApproved = New System.Windows.Forms.ToolStripLabel()
        Me.lblApprovedCount = New System.Windows.Forms.ToolStripLabel()
        Me.lblUnApproved = New System.Windows.Forms.ToolStripLabel()
        Me.lblUnApprovedCount = New System.Windows.Forms.ToolStripLabel()
        Me.lblApprovedForVisitor = New System.Windows.Forms.ToolStripLabel()
        Me.lblApprovedForVisitorCount = New System.Windows.Forms.ToolStripLabel()
        Me.lblTotalPos = New System.Windows.Forms.ToolStripLabel()
        Me.lblTotalPosCount = New System.Windows.Forms.ToolStripLabel()
        Me.erp = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearchSerial = New System.Windows.Forms.TextBox()
        Me.txtSearchSelectedSerial = New System.Windows.Forms.TextBox()
        Me.tsSupplier.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvselectedPos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsSupplier
        '
        Me.tsSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsSupplier.Dock = System.Windows.Forms.DockStyle.None
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboSearchField, Me.cboSearchOperation, Me.txtSearch, Me.btnSearch, Me.btnSearchBack, Me.btnRemoveFilter, Me.ToolStripSeparator1, Me.btnExportToExcel, Me.btnSelectFromExcel})
        Me.tsSupplier.Location = New System.Drawing.Point(616, 3)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(629, 25)
        Me.tsSupplier.TabIndex = 12
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = Global.My.Resources.Resources.excel_icon
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(96, 22)
        Me.btnExportToExcel.Text = "انتقال به Excel"
        '
        'btnSelectFromExcel
        '
        Me.btnSelectFromExcel.Image = Global.My.Resources.Resources.excel_icon
        Me.btnSelectFromExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectFromExcel.Name = "btnSelectFromExcel"
        Me.btnSelectFromExcel.Size = New System.Drawing.Size(98, 22)
        Me.btnSelectFromExcel.Text = "انتخاب از Excel"
        Me.btnSelectFromExcel.ToolTipText = "انتخاب از Excel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboVisitor)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1369, 42)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(926, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(307, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "برای مشاهده تاریخچه انتقال بر روی ردیف مورد نظر دابل کلیک کنید"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(384, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "بازاریاب"
        '
        'cboVisitor
        '
        Me.cboVisitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitor.FormattingEnabled = True
        Me.cboVisitor.Location = New System.Drawing.Point(6, 15)
        Me.cboVisitor.Name = "cboVisitor"
        Me.cboVisitor.Size = New System.Drawing.Size(372, 21)
        Me.cboVisitor.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboSelectedSearchField, Me.cboSelectedSearchOperation, Me.txtSelectedSearch, Me.btnSelectedSearch, Me.btnSelectedSearchBack, Me.btnSelectedRemoveFilter, Me.ToolStripSeparator2, Me.btnSelectedExportToExcel, Me.btnSelectFromExcelSelected})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(629, 25)
        Me.ToolStrip2.TabIndex = 16
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'cboSelectedSearchField
        '
        Me.cboSelectedSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelectedSearchField.Name = "cboSelectedSearchField"
        Me.cboSelectedSearchField.Size = New System.Drawing.Size(121, 25)
        '
        'cboSelectedSearchOperation
        '
        Me.cboSelectedSearchOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSelectedSearchOperation.Name = "cboSelectedSearchOperation"
        Me.cboSelectedSearchOperation.Size = New System.Drawing.Size(121, 25)
        '
        'txtSelectedSearch
        '
        Me.txtSelectedSearch.Name = "txtSelectedSearch"
        Me.txtSelectedSearch.Size = New System.Drawing.Size(100, 25)
        '
        'btnSelectedSearch
        '
        Me.btnSelectedSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSelectedSearch.Image = CType(resources.GetObject("btnSelectedSearch.Image"), System.Drawing.Image)
        Me.btnSelectedSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectedSearch.Name = "btnSelectedSearch"
        Me.btnSelectedSearch.Size = New System.Drawing.Size(23, 22)
        Me.btnSelectedSearch.Text = "Search"
        '
        'btnSelectedSearchBack
        '
        Me.btnSelectedSearchBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSelectedSearchBack.Image = CType(resources.GetObject("btnSelectedSearchBack.Image"), System.Drawing.Image)
        Me.btnSelectedSearchBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectedSearchBack.Name = "btnSelectedSearchBack"
        Me.btnSelectedSearchBack.Size = New System.Drawing.Size(23, 22)
        Me.btnSelectedSearchBack.Text = "SearchBack"
        '
        'btnSelectedRemoveFilter
        '
        Me.btnSelectedRemoveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSelectedRemoveFilter.Image = CType(resources.GetObject("btnSelectedRemoveFilter.Image"), System.Drawing.Image)
        Me.btnSelectedRemoveFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectedRemoveFilter.Name = "btnSelectedRemoveFilter"
        Me.btnSelectedRemoveFilter.Size = New System.Drawing.Size(23, 22)
        Me.btnSelectedRemoveFilter.Text = "RemoveFilter"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnSelectedExportToExcel
        '
        Me.btnSelectedExportToExcel.Image = Global.My.Resources.Resources.excel_icon
        Me.btnSelectedExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectedExportToExcel.Name = "btnSelectedExportToExcel"
        Me.btnSelectedExportToExcel.Size = New System.Drawing.Size(96, 22)
        Me.btnSelectedExportToExcel.Text = "انتقال به Excel"
        '
        'btnSelectFromExcelSelected
        '
        Me.btnSelectFromExcelSelected.Image = Global.My.Resources.Resources.excel_icon
        Me.btnSelectFromExcelSelected.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectFromExcelSelected.Name = "btnSelectFromExcelSelected"
        Me.btnSelectFromExcelSelected.Size = New System.Drawing.Size(98, 22)
        Me.btnSelectFromExcelSelected.Text = "انتخاب از Excel"
        Me.btnSelectFromExcelSelected.ToolTipText = "انتخاب از Excel"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnReTransferToOtherBank)
        Me.GroupBox2.Controls.Add(Me.btnUnCheckB2B)
        Me.GroupBox2.Controls.Add(Me.btnCheckB2B)
        Me.GroupBox2.Controls.Add(Me.btnCancelReturn)
        Me.GroupBox2.Controls.Add(Me.lblCount)
        Me.GroupBox2.Controls.Add(Me.btnAcceptReturnedPos)
        Me.GroupBox2.Controls.Add(Me.btnReturn)
        Me.GroupBox2.Controls.Add(Me.btnAccept)
        Me.GroupBox2.Controls.Add(Me.btnTransferToOtherBank)
        Me.GroupBox2.Controls.Add(Me.btnCancelAssignment)
        Me.GroupBox2.Controls.Add(Me.btnAssign)
        Me.GroupBox2.Controls.Add(Me.dgvselectedPos)
        Me.GroupBox2.Controls.Add(Me.dgv)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1369, 526)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'btnReTransferToOtherBank
        '
        Me.btnReTransferToOtherBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReTransferToOtherBank.Location = New System.Drawing.Point(943, 489)
        Me.btnReTransferToOtherBank.Name = "btnReTransferToOtherBank"
        Me.btnReTransferToOtherBank.Size = New System.Drawing.Size(142, 33)
        Me.btnReTransferToOtherBank.TabIndex = 24
        Me.btnReTransferToOtherBank.Text = "بازگشت  از سایر بانک ها"
        Me.btnReTransferToOtherBank.UseVisualStyleBackColor = True
        Me.btnReTransferToOtherBank.Visible = False
        '
        'btnUnCheckB2B
        '
        Me.btnUnCheckB2B.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUnCheckB2B.Location = New System.Drawing.Point(363, 489)
        Me.btnUnCheckB2B.Name = "btnUnCheckB2B"
        Me.btnUnCheckB2B.Size = New System.Drawing.Size(88, 33)
        Me.btnUnCheckB2B.TabIndex = 23
        Me.btnUnCheckB2B.Text = "بازگشت از B2B"
        Me.btnUnCheckB2B.UseVisualStyleBackColor = True
        Me.btnUnCheckB2B.Visible = False
        '
        'btnCheckB2B
        '
        Me.btnCheckB2B.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckB2B.Location = New System.Drawing.Point(282, 489)
        Me.btnCheckB2B.Name = "btnCheckB2B"
        Me.btnCheckB2B.Size = New System.Drawing.Size(75, 33)
        Me.btnCheckB2B.TabIndex = 22
        Me.btnCheckB2B.Text = "تبدیل به B2B"
        Me.btnCheckB2B.UseVisualStyleBackColor = True
        Me.btnCheckB2B.Visible = False
        '
        'btnCancelReturn
        '
        Me.btnCancelReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelReturn.Location = New System.Drawing.Point(120, 489)
        Me.btnCancelReturn.Name = "btnCancelReturn"
        Me.btnCancelReturn.Size = New System.Drawing.Size(158, 33)
        Me.btnCancelReturn.TabIndex = 20
        Me.btnCancelReturn.Text = "کنسل کردن ارجاع پز به شرکت"
        Me.btnCancelReturn.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(1143, 499)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 18
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAcceptReturnedPos
        '
        Me.btnAcceptReturnedPos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAcceptReturnedPos.Location = New System.Drawing.Point(722, 489)
        Me.btnAcceptReturnedPos.Name = "btnAcceptReturnedPos"
        Me.btnAcceptReturnedPos.Size = New System.Drawing.Size(215, 33)
        Me.btnAcceptReturnedPos.TabIndex = 17
        Me.btnAcceptReturnedPos.Text = "تائید دریافت پزهای مرجوعی انتخاب شده"
        Me.btnAcceptReturnedPos.UseVisualStyleBackColor = True
        Me.btnAcceptReturnedPos.Visible = False
        '
        'btnReturn
        '
        Me.btnReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReturn.Location = New System.Drawing.Point(6, 489)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(108, 33)
        Me.btnReturn.TabIndex = 16
        Me.btnReturn.Text = "ارجاع پز به شرکت"
        Me.btnReturn.UseVisualStyleBackColor = True
        Me.btnReturn.Visible = False
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(456, 142)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(112, 52)
        Me.btnAccept.TabIndex = 15
        Me.btnAccept.Text = "تائید دریافت پزهای انتخاب شده"
        Me.btnAccept.UseVisualStyleBackColor = True
        Me.btnAccept.Visible = False
        '
        'btnTransferToOtherBank
        '
        Me.btnTransferToOtherBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTransferToOtherBank.Location = New System.Drawing.Point(574, 489)
        Me.btnTransferToOtherBank.Name = "btnTransferToOtherBank"
        Me.btnTransferToOtherBank.Size = New System.Drawing.Size(142, 33)
        Me.btnTransferToOtherBank.TabIndex = 14
        Me.btnTransferToOtherBank.Text = "انتقال پز به سایر بانک ها"
        Me.btnTransferToOtherBank.UseVisualStyleBackColor = True
        Me.btnTransferToOtherBank.Visible = False
        '
        'btnCancelAssignment
        '
        Me.btnCancelAssignment.Location = New System.Drawing.Point(456, 258)
        Me.btnCancelAssignment.Name = "btnCancelAssignment"
        Me.btnCancelAssignment.Size = New System.Drawing.Size(112, 52)
        Me.btnCancelAssignment.TabIndex = 14
        Me.btnCancelAssignment.Text = "< حذف پز از بازاریاب"
        Me.btnCancelAssignment.UseVisualStyleBackColor = True
        Me.btnCancelAssignment.Visible = False
        '
        'btnAssign
        '
        Me.btnAssign.Location = New System.Drawing.Point(456, 200)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(112, 52)
        Me.btnAssign.TabIndex = 14
        Me.btnAssign.Text = "ارسال پز به بازاریاب >"
        Me.btnAssign.UseVisualStyleBackColor = True
        Me.btnAssign.Visible = False
        '
        'dgvselectedPos
        '
        Me.dgvselectedPos.AllowUserToAddRows = False
        Me.dgvselectedPos.AllowUserToDeleteRows = False
        Me.dgvselectedPos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvselectedPos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvselectedPos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvselectedPos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelectedStatus, Me.colOperationID, Me.PosStatus, Me.colStatusDesc, Me.ColStatusDateFaSelected, Me.colSelectedPosID, Me.colSelectedEniacCode_vc, Me.DataGridViewTextBoxColumn3, Me.colSelectedSerial_vc, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvselectedPos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvselectedPos.Location = New System.Drawing.Point(5, 11)
        Me.dgvselectedPos.Name = "dgvselectedPos"
        Me.dgvselectedPos.ReadOnly = True
        Me.dgvselectedPos.RowHeadersVisible = False
        Me.dgvselectedPos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvselectedPos.Size = New System.Drawing.Size(445, 475)
        Me.dgvselectedPos.TabIndex = 13
        '
        'colSelectedStatus
        '
        Me.colSelectedStatus.DataPropertyName = "Status"
        Me.colSelectedStatus.FalseValue = ""
        Me.colSelectedStatus.HeaderText = "تائید دریافت"
        Me.colSelectedStatus.Name = "colSelectedStatus"
        Me.colSelectedStatus.ReadOnly = True
        Me.colSelectedStatus.TrueValue = ""
        '
        'colOperationID
        '
        Me.colOperationID.DataPropertyName = "StatusID"
        Me.colOperationID.HeaderText = "colOperationID"
        Me.colOperationID.Name = "colOperationID"
        Me.colOperationID.ReadOnly = True
        Me.colOperationID.Visible = False
        '
        'PosStatus
        '
        Me.PosStatus.DataPropertyName = "PosStatus"
        Me.PosStatus.HeaderText = "وضعیت POS"
        Me.PosStatus.Name = "PosStatus"
        Me.PosStatus.ReadOnly = True
        '
        'colStatusDesc
        '
        Me.colStatusDesc.DataPropertyName = "StatusDesc"
        Me.colStatusDesc.HeaderText = "وضعیت"
        Me.colStatusDesc.Name = "colStatusDesc"
        Me.colStatusDesc.ReadOnly = True
        '
        'ColStatusDateFaSelected
        '
        Me.ColStatusDateFaSelected.DataPropertyName = "StatusDateFa"
        Me.ColStatusDateFaSelected.HeaderText = "تاریخ"
        Me.ColStatusDateFaSelected.Name = "ColStatusDateFaSelected"
        Me.ColStatusDateFaSelected.ReadOnly = True
        '
        'colSelectedPosID
        '
        Me.colSelectedPosID.DataPropertyName = "PosID"
        Me.colSelectedPosID.HeaderText = "colPosID"
        Me.colSelectedPosID.Name = "colSelectedPosID"
        Me.colSelectedPosID.ReadOnly = True
        Me.colSelectedPosID.Visible = False
        '
        'colSelectedEniacCode_vc
        '
        Me.colSelectedEniacCode_vc.DataPropertyName = "EniacCode_vc"
        Me.colSelectedEniacCode_vc.HeaderText = "کد پیگیری"
        Me.colSelectedEniacCode_vc.Name = "colSelectedEniacCode_vc"
        Me.colSelectedEniacCode_vc.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PropertyNo_vc"
        Me.DataGridViewTextBoxColumn3.HeaderText = "شماره اموال"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'colSelectedSerial_vc
        '
        Me.colSelectedSerial_vc.DataPropertyName = "Serial_vc"
        Me.colSelectedSerial_vc.HeaderText = "شماره سریال"
        Me.colSelectedSerial_vc.Name = "colSelectedSerial_vc"
        Me.colSelectedSerial_vc.ReadOnly = True
        Me.colSelectedSerial_vc.Width = 120
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ProductNo_vc"
        Me.DataGridViewTextBoxColumn5.HeaderText = "شماره محصول"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "PosModelName_nvc"
        Me.DataGridViewTextBoxColumn6.HeaderText = "مدل دستگاه"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PartNo_int"
        Me.DataGridViewTextBoxColumn7.HeaderText = "شماره پارت"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 85
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "BatchNo_int"
        Me.DataGridViewTextBoxColumn8.HeaderText = "شماره بچ"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "PosTypeName_nvc"
        Me.DataGridViewTextBoxColumn9.HeaderText = "نوع دستگاه"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Active_Tint"
        Me.DataGridViewTextBoxColumn10.HeaderText = "فعال"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 50
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "PosTypeId"
        Me.DataGridViewTextBoxColumn11.HeaderText = "colPosTypeId"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "PosModelID"
        Me.DataGridViewTextBoxColumn12.HeaderText = "colPosModelID"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPosID, Me.colStatusID, Me.colEniacCode_vc, Me.colPropertyNo_vc, Me.colSerial_vc, Me.colProductNo_vc, Me.colPosModelName_nvc, Me.colPartNo_int, Me.colBatchNo_int, Me.colPosTypeName_nvc, Me.colActive_Tint, Me.colStatus, Me.colStatusDateFa, Me.colPosTypeId, Me.colPosModelID})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv.Location = New System.Drawing.Point(569, 11)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(676, 475)
        Me.dgv.TabIndex = 12
        '
        'colPosID
        '
        Me.colPosID.DataPropertyName = "PosID"
        Me.colPosID.HeaderText = "colPosID"
        Me.colPosID.Name = "colPosID"
        Me.colPosID.ReadOnly = True
        Me.colPosID.Visible = False
        '
        'colStatusID
        '
        Me.colStatusID.DataPropertyName = "StatusID"
        Me.colStatusID.HeaderText = "StatusID"
        Me.colStatusID.Name = "colStatusID"
        Me.colStatusID.ReadOnly = True
        Me.colStatusID.Visible = False
        '
        'colEniacCode_vc
        '
        Me.colEniacCode_vc.DataPropertyName = "EniacCode_vc"
        Me.colEniacCode_vc.HeaderText = "کد پیگیری"
        Me.colEniacCode_vc.Name = "colEniacCode_vc"
        Me.colEniacCode_vc.ReadOnly = True
        '
        'colPropertyNo_vc
        '
        Me.colPropertyNo_vc.DataPropertyName = "PropertyNo_vc"
        Me.colPropertyNo_vc.HeaderText = "شماره اموال"
        Me.colPropertyNo_vc.Name = "colPropertyNo_vc"
        Me.colPropertyNo_vc.ReadOnly = True
        Me.colPropertyNo_vc.Width = 120
        '
        'colSerial_vc
        '
        Me.colSerial_vc.DataPropertyName = "Serial_vc"
        Me.colSerial_vc.HeaderText = "شماره سریال"
        Me.colSerial_vc.Name = "colSerial_vc"
        Me.colSerial_vc.ReadOnly = True
        Me.colSerial_vc.Width = 120
        '
        'colProductNo_vc
        '
        Me.colProductNo_vc.DataPropertyName = "ProductNo_vc"
        Me.colProductNo_vc.HeaderText = "شماره محصول"
        Me.colProductNo_vc.Name = "colProductNo_vc"
        Me.colProductNo_vc.ReadOnly = True
        Me.colProductNo_vc.Width = 120
        '
        'colPosModelName_nvc
        '
        Me.colPosModelName_nvc.DataPropertyName = "PosModelName_nvc"
        Me.colPosModelName_nvc.HeaderText = "مدل دستگاه"
        Me.colPosModelName_nvc.Name = "colPosModelName_nvc"
        Me.colPosModelName_nvc.ReadOnly = True
        '
        'colPartNo_int
        '
        Me.colPartNo_int.DataPropertyName = "PartNo_int"
        Me.colPartNo_int.HeaderText = "شماره پارت"
        Me.colPartNo_int.Name = "colPartNo_int"
        Me.colPartNo_int.ReadOnly = True
        Me.colPartNo_int.Width = 85
        '
        'colBatchNo_int
        '
        Me.colBatchNo_int.DataPropertyName = "BatchNo_int"
        Me.colBatchNo_int.HeaderText = "شماره بچ"
        Me.colBatchNo_int.Name = "colBatchNo_int"
        Me.colBatchNo_int.ReadOnly = True
        '
        'colPosTypeName_nvc
        '
        Me.colPosTypeName_nvc.DataPropertyName = "PosTypeName_nvc"
        Me.colPosTypeName_nvc.HeaderText = "نوع دستگاه"
        Me.colPosTypeName_nvc.Name = "colPosTypeName_nvc"
        Me.colPosTypeName_nvc.ReadOnly = True
        '
        'colActive_Tint
        '
        Me.colActive_Tint.DataPropertyName = "Active_Tint"
        Me.colActive_Tint.HeaderText = "فعال"
        Me.colActive_Tint.Name = "colActive_Tint"
        Me.colActive_Tint.ReadOnly = True
        Me.colActive_Tint.Width = 50
        '
        'colStatus
        '
        Me.colStatus.DataPropertyName = "Status"
        Me.colStatus.HeaderText = "وضعیت"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        Me.colStatus.Width = 200
        '
        'colStatusDateFa
        '
        Me.colStatusDateFa.DataPropertyName = "StatusDateFa"
        Me.colStatusDateFa.HeaderText = "تاریخ"
        Me.colStatusDateFa.Name = "colStatusDateFa"
        Me.colStatusDateFa.ReadOnly = True
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
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSelectAll, Me.btnUnSelect, Me.InventSelect, Me.ToolStripSeparator3, Me.lblApproved, Me.lblApprovedCount, Me.lblUnApproved, Me.lblUnApprovedCount, Me.lblApprovedForVisitor, Me.lblApprovedForVisitorCount, Me.lblTotalPos, Me.lblTotalPosCount})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 599)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1245, 25)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Image = CType(resources.GetObject("btnSelectAll.Image"), System.Drawing.Image)
        Me.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(77, 22)
        Me.btnSelectAll.Text = "انتخاب همه"
        '
        'btnUnSelect
        '
        Me.btnUnSelect.Image = CType(resources.GetObject("btnUnSelect.Image"), System.Drawing.Image)
        Me.btnUnSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUnSelect.Name = "btnUnSelect"
        Me.btnUnSelect.Size = New System.Drawing.Size(86, 22)
        Me.btnUnSelect.Text = "لغو انتخاب ها"
        '
        'InventSelect
        '
        Me.InventSelect.Image = CType(resources.GetObject("InventSelect.Image"), System.Drawing.Image)
        Me.InventSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InventSelect.Name = "InventSelect"
        Me.InventSelect.Size = New System.Drawing.Size(90, 22)
        Me.InventSelect.Text = "معکوس انتخاب"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblApproved
        '
        Me.lblApproved.Name = "lblApproved"
        Me.lblApproved.Size = New System.Drawing.Size(143, 22)
        Me.lblApproved.Text = "تعداد تایید شده توسط نماینده :"
        '
        'lblApprovedCount
        '
        Me.lblApprovedCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovedCount.Name = "lblApprovedCount"
        Me.lblApprovedCount.Size = New System.Drawing.Size(16, 22)
        Me.lblApprovedCount.Text = "   "
        '
        'lblUnApproved
        '
        Me.lblUnApproved.Name = "lblUnApproved"
        Me.lblUnApproved.Size = New System.Drawing.Size(116, 22)
        Me.lblUnApproved.Text = "در انتظار تایید نماینده : "
        '
        'lblUnApprovedCount
        '
        Me.lblUnApprovedCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnApprovedCount.Name = "lblUnApprovedCount"
        Me.lblUnApprovedCount.Size = New System.Drawing.Size(19, 22)
        Me.lblUnApprovedCount.Text = "    "
        '
        'lblApprovedForVisitor
        '
        Me.lblApprovedForVisitor.Name = "lblApprovedForVisitor"
        Me.lblApprovedForVisitor.Size = New System.Drawing.Size(84, 22)
        Me.lblApprovedForVisitor.Text = "تعداد تایید شده : "
        '
        'lblApprovedForVisitorCount
        '
        Me.lblApprovedForVisitorCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovedForVisitorCount.Name = "lblApprovedForVisitorCount"
        Me.lblApprovedForVisitorCount.Size = New System.Drawing.Size(19, 22)
        Me.lblApprovedForVisitorCount.Text = "    "
        '
        'lblTotalPos
        '
        Me.lblTotalPos.Name = "lblTotalPos"
        Me.lblTotalPos.Size = New System.Drawing.Size(51, 22)
        Me.lblTotalPos.Text = "تعداد کل :"
        '
        'lblTotalPosCount
        '
        Me.lblTotalPosCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPosCount.Name = "lblTotalPosCount"
        Me.lblTotalPosCount.Size = New System.Drawing.Size(19, 22)
        Me.lblTotalPosCount.Text = "    "
        '
        'erp
        '
        Me.erp.ContainerControl = Me
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(458, 475)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = " جستجوی سریال >>"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(462, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "<< جستجوی سریال"
        '
        'txtSearchSerial
        '
        Me.txtSearchSerial.Location = New System.Drawing.Point(455, 109)
        Me.txtSearchSerial.Name = "txtSearchSerial"
        Me.txtSearchSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearchSerial.Size = New System.Drawing.Size(112, 21)
        Me.txtSearchSerial.TabIndex = 28
        '
        'txtSearchSelectedSerial
        '
        Me.txtSearchSelectedSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSearchSelectedSerial.Location = New System.Drawing.Point(455, 491)
        Me.txtSearchSelectedSerial.Name = "txtSearchSelectedSerial"
        Me.txtSearchSelectedSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSearchSelectedSerial.Size = New System.Drawing.Size(112, 21)
        Me.txtSearchSelectedSerial.TabIndex = 27
        '
        'frmAssignPosToVisitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1245, 624)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSearchSerial)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.txtSearchSelectedSerial)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tsSupplier)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MinimumSize = New System.Drawing.Size(1022, 38)
        Me.Name = "frmAssignPosToVisitor"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تخصیص POS به بازاریاب"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvselectedPos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsSupplier As System.Windows.Forms.ToolStrip
    Friend WithEvents cboSearchField As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cboSearchOperation As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSearchBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRemoveFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboVisitor As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSelectAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUnSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents InventSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents erp As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgvselectedPos As System.Windows.Forms.DataGridView
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnAssign As System.Windows.Forms.Button
    Friend WithEvents btnTransferToOtherBank As System.Windows.Forms.Button
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Friend WithEvents btnCancelAssignment As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAcceptReturnedPos As System.Windows.Forms.Button
    Friend WithEvents btnSelectFromExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents cboSelectedSearchField As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cboSelectedSearchOperation As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtSelectedSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnSelectedSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSelectedSearchBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSelectedRemoveFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSelectedExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblApproved As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblApprovedCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblUnApproved As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblUnApprovedCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblApprovedForVisitor As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblApprovedForVisitorCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTotalPos As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTotalPosCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearchSerial As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchSelectedSerial As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelReturn As System.Windows.Forms.Button
    Friend WithEvents btnUnCheckB2B As System.Windows.Forms.Button
    Friend WithEvents btnCheckB2B As System.Windows.Forms.Button
    Friend WithEvents btnSelectFromExcelSelected As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnReTransferToOtherBank As System.Windows.Forms.Button
    Friend WithEvents colSelectedStatus As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colOperationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PosStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatusDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStatusDateFaSelected As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSelectedPosID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSelectedEniacCode_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSelectedSerial_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatusID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEniacCode_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPropertyNo_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerial_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProductNo_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosModelName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartNo_int As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo_int As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosTypeName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActive_Tint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatusDateFa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosTypeId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosModelID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
