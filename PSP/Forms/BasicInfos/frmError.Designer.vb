<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmError
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmError))
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboStatus_BIT = New System.Windows.Forms.ComboBox()
        Me.txtDesc_nvc = New System.Windows.Forms.TextBox()
        Me.txtErrorID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvWarrning = New System.Windows.Forms.DataGridView()
        Me.colErrorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colErrorDescription_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus_BIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvWarrning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsSupplier.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.Label3)
        Me.gbDetail.Controls.Add(Me.ComboStatus_BIT)
        Me.gbDetail.Controls.Add(Me.txtDesc_nvc)
        Me.gbDetail.Controls.Add(Me.txtErrorID)
        Me.gbDetail.Controls.Add(Me.Label2)
        Me.gbDetail.Controls.Add(Me.Label1)
        Me.gbDetail.Location = New System.Drawing.Point(9, 308)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(572, 105)
        Me.gbDetail.TabIndex = 9
        Me.gbDetail.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(163, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "نوع :"
        '
        'ComboStatus_BIT
        '
        Me.ComboStatus_BIT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboStatus_BIT.FormattingEnabled = True
        Me.ComboStatus_BIT.Items.AddRange(New Object() {"خطا", "اخطار"})
        Me.ComboStatus_BIT.Location = New System.Drawing.Point(36, 32)
        Me.ComboStatus_BIT.Name = "ComboStatus_BIT"
        Me.ComboStatus_BIT.Size = New System.Drawing.Size(121, 21)
        Me.ComboStatus_BIT.TabIndex = 26
        '
        'txtDesc_nvc
        '
        Me.txtDesc_nvc.Location = New System.Drawing.Point(303, 59)
        Me.txtDesc_nvc.MaxLength = 30
        Me.txtDesc_nvc.Name = "txtDesc_nvc"
        Me.txtDesc_nvc.Size = New System.Drawing.Size(201, 21)
        Me.txtDesc_nvc.TabIndex = 3
        '
        'txtErrorID
        '
        Me.txtErrorID.Location = New System.Drawing.Point(385, 32)
        Me.txtErrorID.MaxLength = 6
        Me.txtErrorID.Name = "txtErrorID"
        Me.txtErrorID.Size = New System.Drawing.Size(119, 21)
        Me.txtErrorID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(508, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "شرح :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(510, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "کد :"
        '
        'dgvWarrning
        '
        Me.dgvWarrning.AllowUserToAddRows = False
        Me.dgvWarrning.AllowUserToDeleteRows = False
        Me.dgvWarrning.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvWarrning.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvWarrning.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvWarrning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvWarrning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWarrning.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colErrorID, Me.colErrorDescription_nvc, Me.colStatus_BIT})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvWarrning.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvWarrning.Location = New System.Drawing.Point(12, 33)
        Me.dgvWarrning.MultiSelect = False
        Me.dgvWarrning.Name = "dgvWarrning"
        Me.dgvWarrning.ReadOnly = True
        Me.dgvWarrning.RowHeadersVisible = False
        Me.dgvWarrning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWarrning.Size = New System.Drawing.Size(569, 270)
        Me.dgvWarrning.TabIndex = 11
        '
        'colErrorID
        '
        Me.colErrorID.DataPropertyName = "ErrorID"
        Me.colErrorID.FillWeight = 80.0!
        Me.colErrorID.HeaderText = "کد"
        Me.colErrorID.Name = "colErrorID"
        Me.colErrorID.ReadOnly = True
        '
        'colErrorDescription_nvc
        '
        Me.colErrorDescription_nvc.DataPropertyName = "ErrorDescription_nvc"
        Me.colErrorDescription_nvc.FillWeight = 170.0!
        Me.colErrorDescription_nvc.HeaderText = "شرح"
        Me.colErrorDescription_nvc.Name = "colErrorDescription_nvc"
        Me.colErrorDescription_nvc.ReadOnly = True
        '
        'colStatus_BIT
        '
        Me.colStatus_BIT.DataPropertyName = "Status_BIT"
        Me.colStatus_BIT.HeaderText = "نوع"
        Me.colStatus_BIT.Name = "colStatus_BIT"
        Me.colStatus_BIT.ReadOnly = True
        '
        'tsSupplier
        '
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel, Me.ToolStripSeparator4, Me.btnImport, Me.txtExcelSheetName, Me.btnExport})
        Me.tsSupplier.Location = New System.Drawing.Point(0, 0)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(593, 25)
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
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(98, 22)
        Me.btnExport.Text = "ارسال به Excel"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'frmError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 417)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.dgvWarrning)
        Me.Controls.Add(Me.tsSupplier)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmError"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعریف اخطار وخطا "
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        CType(Me.dgvWarrning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesc_nvc As System.Windows.Forms.TextBox
    Friend WithEvents txtErrorID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvWarrning As System.Windows.Forms.DataGridView
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
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents colErrorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colErrorDescription_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus_BIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboStatus_BIT As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtExcelSheetName As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class
