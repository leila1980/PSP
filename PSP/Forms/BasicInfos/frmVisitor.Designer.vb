<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisitor))
        Me.gbDetail = New System.Windows.Forms.GroupBox
        Me.ComboVisitorStatus = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpContractDate_vc = New FarsiLibrary.Win.Controls.FADatePickerConverter
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtLastName_nvc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFirstName_nvc = New System.Windows.Forms.TextBox
        Me.txtVisitorID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvVisitor = New System.Windows.Forms.DataGridView
        Me.colVisitorID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFirstName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLastName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colContractDate_vc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colActiveStatus = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tsSupplier = New System.Windows.Forms.ToolStrip
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvVisitor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsSupplier.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.ComboVisitorStatus)
        Me.gbDetail.Controls.Add(Me.Label5)
        Me.gbDetail.Controls.Add(Me.dtpContractDate_vc)
        Me.gbDetail.Controls.Add(Me.Label4)
        Me.gbDetail.Controls.Add(Me.txtLastName_nvc)
        Me.gbDetail.Controls.Add(Me.Label3)
        Me.gbDetail.Controls.Add(Me.txtFirstName_nvc)
        Me.gbDetail.Controls.Add(Me.txtVisitorID)
        Me.gbDetail.Controls.Add(Me.Label2)
        Me.gbDetail.Controls.Add(Me.Label1)
        Me.gbDetail.Location = New System.Drawing.Point(9, 308)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(508, 128)
        Me.gbDetail.TabIndex = 9
        Me.gbDetail.TabStop = False
        '
        'ComboVisitorStatus
        '
        Me.ComboVisitorStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVisitorStatus.FormattingEnabled = True
        Me.ComboVisitorStatus.Location = New System.Drawing.Point(28, 22)
        Me.ComboVisitorStatus.Name = "ComboVisitorStatus"
        Me.ComboVisitorStatus.Size = New System.Drawing.Size(121, 21)
        Me.ComboVisitorStatus.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(155, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "وضعیت بازاریاب :"
        '
        'dtpContractDate_vc
        '
        Me.dtpContractDate_vc.CalendarType = FarsiLibrary.Win.Enums.CalendarTypes.English
        Me.dtpContractDate_vc.Location = New System.Drawing.Point(291, 101)
        Me.dtpContractDate_vc.Name = "dtpContractDate_vc"
        Me.dtpContractDate_vc.Size = New System.Drawing.Size(120, 20)
        Me.dtpContractDate_vc.TabIndex = 18
        Me.dtpContractDate_vc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(411, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "تاریخ عقد قرار داد :"
        '
        'txtLastName_nvc
        '
        Me.txtLastName_nvc.Location = New System.Drawing.Point(53, 73)
        Me.txtLastName_nvc.MaxLength = 50
        Me.txtLastName_nvc.Name = "txtLastName_nvc"
        Me.txtLastName_nvc.Size = New System.Drawing.Size(373, 21)
        Me.txtLastName_nvc.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(431, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "نام خانوادگی :"
        '
        'txtFirstName_nvc
        '
        Me.txtFirstName_nvc.Location = New System.Drawing.Point(269, 46)
        Me.txtFirstName_nvc.MaxLength = 30
        Me.txtFirstName_nvc.Name = "txtFirstName_nvc"
        Me.txtFirstName_nvc.Size = New System.Drawing.Size(201, 21)
        Me.txtFirstName_nvc.TabIndex = 3
        '
        'txtVisitorID
        '
        Me.txtVisitorID.Location = New System.Drawing.Point(351, 19)
        Me.txtVisitorID.MaxLength = 3
        Me.txtVisitorID.Name = "txtVisitorID"
        Me.txtVisitorID.Size = New System.Drawing.Size(119, 21)
        Me.txtVisitorID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(474, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "نام :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(476, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "کد :"
        '
        'dgvVisitor
        '
        Me.dgvVisitor.AllowUserToAddRows = False
        Me.dgvVisitor.AllowUserToDeleteRows = False
        Me.dgvVisitor.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvVisitor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVisitor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvVisitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVisitor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVisitorID, Me.colFirstName_nvc, Me.colLastName_nvc, Me.colContractDate_vc, Me.colActiveStatus})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVisitor.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVisitor.Location = New System.Drawing.Point(9, 28)
        Me.dgvVisitor.MultiSelect = False
        Me.dgvVisitor.Name = "dgvVisitor"
        Me.dgvVisitor.ReadOnly = True
        Me.dgvVisitor.RowHeadersVisible = False
        Me.dgvVisitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVisitor.Size = New System.Drawing.Size(508, 270)
        Me.dgvVisitor.TabIndex = 11
        '
        'colVisitorID
        '
        Me.colVisitorID.DataPropertyName = "VisitorID"
        Me.colVisitorID.HeaderText = "کد"
        Me.colVisitorID.Name = "colVisitorID"
        Me.colVisitorID.ReadOnly = True
        Me.colVisitorID.Width = 50
        '
        'colFirstName_nvc
        '
        Me.colFirstName_nvc.DataPropertyName = "FirstName_nvc"
        Me.colFirstName_nvc.HeaderText = "نام"
        Me.colFirstName_nvc.Name = "colFirstName_nvc"
        Me.colFirstName_nvc.ReadOnly = True
        Me.colFirstName_nvc.Width = 80
        '
        'colLastName_nvc
        '
        Me.colLastName_nvc.DataPropertyName = "LastName_nvc"
        Me.colLastName_nvc.HeaderText = "نام خانوادگی"
        Me.colLastName_nvc.Name = "colLastName_nvc"
        Me.colLastName_nvc.ReadOnly = True
        Me.colLastName_nvc.Width = 200
        '
        'colContractDate_vc
        '
        Me.colContractDate_vc.DataPropertyName = "ContractDate_vc"
        Me.colContractDate_vc.HeaderText = "تاریخ عقد قرارداد"
        Me.colContractDate_vc.Name = "colContractDate_vc"
        Me.colContractDate_vc.ReadOnly = True
        Me.colContractDate_vc.Width = 120
        '
        'colActiveStatus
        '
        Me.colActiveStatus.DataPropertyName = "ActiveStatus"
        Me.colActiveStatus.HeaderText = "وضعیت"
        Me.colActiveStatus.Name = "colActiveStatus"
        Me.colActiveStatus.ReadOnly = True
        Me.colActiveStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colActiveStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'tsSupplier
        '
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel})
        Me.tsSupplier.Location = New System.Drawing.Point(0, 0)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(529, 25)
        Me.tsSupplier.TabIndex = 10
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
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(58, 22)
        Me.btnEdit.Text = "ويرايش"
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
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'frmVisitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 441)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.dgvVisitor)
        Me.Controls.Add(Me.tsSupplier)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVisitor"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعریف بازاریاب "
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        CType(Me.dgvVisitor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtFirstName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents txtVisitorID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvVisitor As System.Windows.Forms.DataGridView
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
    Friend WithEvents txtLastName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpContractDate_vc As FarsiLibrary.Win.Controls.FADatePickerConverter
    Friend WithEvents ComboVisitorStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents colVisitorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFirstName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLastName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colContractDate_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActiveStatus As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
