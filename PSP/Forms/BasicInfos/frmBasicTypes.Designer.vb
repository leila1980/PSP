<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBasicTypes
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBasicTypes))
        Me.gbDetail = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtName_nvc = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvBasicTypes = New System.Windows.Forms.DataGridView
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
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvBasicTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsSupplier.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.Label1)
        Me.gbDetail.Controls.Add(Me.txtName_nvc)
        Me.gbDetail.Controls.Add(Me.txtID)
        Me.gbDetail.Controls.Add(Me.Label2)
        Me.gbDetail.Location = New System.Drawing.Point(6, 328)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(481, 81)
        Me.gbDetail.TabIndex = 3
        Me.gbDetail.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(403, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "کد :"
        '
        'txtName_nvc
        '
        Me.txtName_nvc.Location = New System.Drawing.Point(181, 51)
        Me.txtName_nvc.Name = "txtName_nvc"
        Me.txtName_nvc.Size = New System.Drawing.Size(207, 21)
        Me.txtName_nvc.TabIndex = 3
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(269, 21)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(119, 21)
        Me.txtID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(403, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "شرح :"
        '
        'dgvBasicTypes
        '
        Me.dgvBasicTypes.AllowUserToAddRows = False
        Me.dgvBasicTypes.AllowUserToDeleteRows = False
        Me.dgvBasicTypes.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.dgvBasicTypes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBasicTypes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvBasicTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBasicTypes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colName_nvc})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBasicTypes.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBasicTypes.Location = New System.Drawing.Point(8, 33)
        Me.dgvBasicTypes.MultiSelect = False
        Me.dgvBasicTypes.Name = "dgvBasicTypes"
        Me.dgvBasicTypes.ReadOnly = True
        Me.dgvBasicTypes.RowHeadersVisible = False
        Me.dgvBasicTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBasicTypes.Size = New System.Drawing.Size(479, 292)
        Me.dgvBasicTypes.TabIndex = 5
        '
        'tsSupplier
        '
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel})
        Me.tsSupplier.Location = New System.Drawing.Point(0, 0)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(497, 25)
        Me.tsSupplier.TabIndex = 4
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
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'colID
        '
        Me.colID.DataPropertyName = "ID"
        Me.colID.HeaderText = "کد "
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        '
        'colName_nvc
        '
        Me.colName_nvc.DataPropertyName = "Name_nvc"
        Me.colName_nvc.HeaderText = "شرح"
        Me.colName_nvc.Name = "colName_nvc"
        Me.colName_nvc.ReadOnly = True
        Me.colName_nvc.Width = 350
        '
        'frmBasicTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 417)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.dgvBasicTypes)
        Me.Controls.Add(Me.tsSupplier)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBasicTypes"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        CType(Me.dgvBasicTypes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents dgvBasicTypes As System.Windows.Forms.DataGridView
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
    Friend WithEvents txtName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
