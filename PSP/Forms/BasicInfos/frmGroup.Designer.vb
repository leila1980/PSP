<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGroup
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGroup))
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.txtShaparakNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName_nvc = New System.Windows.Forms.TextBox()
        Me.txtGroupID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvGroup = New System.Windows.Forms.DataGridView()
        Me.tsSupplier = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.txtExcelSheetName = New System.Windows.Forms.ToolStripTextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.lblSearch = New System.Windows.Forms.ToolStripLabel()
        Me.cboSearchBy = New System.Windows.Forms.ToolStripComboBox()
        Me.txtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.colGroupID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colShaparakNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsSupplier.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.txtShaparakNo)
        Me.gbDetail.Controls.Add(Me.Label3)
        Me.gbDetail.Controls.Add(Me.txtName_nvc)
        Me.gbDetail.Controls.Add(Me.txtGroupID)
        Me.gbDetail.Controls.Add(Me.Label2)
        Me.gbDetail.Controls.Add(Me.Label1)
        Me.gbDetail.Location = New System.Drawing.Point(10, 371)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(921, 102)
        Me.gbDetail.TabIndex = 9
        Me.gbDetail.TabStop = False
        '
        'txtShaparakNo
        '
        Me.txtShaparakNo.Location = New System.Drawing.Point(734, 47)
        Me.txtShaparakNo.MaxLength = 20
        Me.txtShaparakNo.Name = "txtShaparakNo"
        Me.txtShaparakNo.Size = New System.Drawing.Size(119, 21)
        Me.txtShaparakNo.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(859, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "کد شاپرک :"
        '
        'txtName_nvc
        '
        Me.txtName_nvc.Location = New System.Drawing.Point(283, 74)
        Me.txtName_nvc.Name = "txtName_nvc"
        Me.txtName_nvc.Size = New System.Drawing.Size(570, 21)
        Me.txtName_nvc.TabIndex = 3
        '
        'txtGroupID
        '
        Me.txtGroupID.Location = New System.Drawing.Point(734, 20)
        Me.txtGroupID.MaxLength = 4
        Me.txtGroupID.Name = "txtGroupID"
        Me.txtGroupID.Size = New System.Drawing.Size(119, 21)
        Me.txtGroupID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(859, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "نام گروه:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(859, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "کد  :"
        '
        'dgvGroup
        '
        Me.dgvGroup.AllowUserToAddRows = False
        Me.dgvGroup.AllowUserToDeleteRows = False
        Me.dgvGroup.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.dgvGroup.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvGroup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGroup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colGroupID, Me.colShaparakNO, Me.colName_nvc})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGroup.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvGroup.Location = New System.Drawing.Point(10, 31)
        Me.dgvGroup.MultiSelect = False
        Me.dgvGroup.Name = "dgvGroup"
        Me.dgvGroup.ReadOnly = True
        Me.dgvGroup.RowHeadersVisible = False
        Me.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGroup.Size = New System.Drawing.Size(921, 336)
        Me.dgvGroup.TabIndex = 11
        '
        'tsSupplier
        '
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel, Me.ToolStripSeparator4, Me.btnImport, Me.txtExcelSheetName, Me.lblSearch, Me.cboSearchBy, Me.txtSearch, Me.btnSearch})
        Me.tsSupplier.Location = New System.Drawing.Point(0, 0)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(934, 25)
        Me.tsSupplier.TabIndex = 10
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.Text = "جدید"
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
        Me.btnEdit.Text = "ویرایش"
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(62, 22)
        Me.btnCancel.Text = "انصراف"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnImport
        '
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(63, 22)
        Me.btnImport.Text = "Import"
        '
        'txtExcelSheetName
        '
        Me.txtExcelSheetName.Name = "txtExcelSheetName"
        Me.txtExcelSheetName.Size = New System.Drawing.Size(100, 25)
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'lblSearch
        '
        Me.lblSearch.Image = CType(resources.GetObject("lblSearch.Image"), System.Drawing.Image)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(96, 22)
        Me.lblSearch.Text = "جستجو بر اساس"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchBy.Items.AddRange(New Object() {"کد ملی", "نام خانوادگی", "کد قرارداد", "شماره قرارداد", "شماره قرارداد PSP", "تاریخ عقد قرارداد", "تاریخ ثبت قرارداد", "شماره درخواست", "شماره پایانه "})
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.Size = New System.Drawing.Size(121, 25)
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
        '
        'colGroupID
        '
        Me.colGroupID.DataPropertyName = "GroupID"
        Me.colGroupID.HeaderText = "کد "
        Me.colGroupID.Name = "colGroupID"
        Me.colGroupID.ReadOnly = True
        '
        'colShaparakNO
        '
        Me.colShaparakNO.DataPropertyName = "SHAPARAKNO"
        Me.colShaparakNO.HeaderText = "کدشاپرک"
        Me.colShaparakNO.Name = "colShaparakNO"
        Me.colShaparakNO.ReadOnly = True
        '
        'colName_nvc
        '
        Me.colName_nvc.DataPropertyName = "Name_nvc"
        Me.colName_nvc.HeaderText = "نام گروه"
        Me.colName_nvc.Name = "colName_nvc"
        Me.colName_nvc.ReadOnly = True
        Me.colName_nvc.Width = 700
        '
        'frmGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 472)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.dgvGroup)
        Me.Controls.Add(Me.tsSupplier)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGroup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        CType(Me.dgvGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvGroup As System.Windows.Forms.DataGridView
    Friend WithEvents tsSupplier As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtExcelSheetName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtShaparakNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGroupID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboSearchBy As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents colGroupID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShaparakNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
