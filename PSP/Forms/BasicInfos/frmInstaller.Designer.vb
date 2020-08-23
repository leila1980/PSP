<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstaller
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstaller))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gbDetail = New System.Windows.Forms.GroupBox
        Me.txtInstallerID = New System.Windows.Forms.TextBox
        Me.txtAddress_nvc = New System.Windows.Forms.TextBox
        Me.txtMobile_vc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTel_vc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtLastName_nvc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFirstName_nvc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.dgvInstaller = New System.Windows.Forms.DataGridView
        Me.colInstallerID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFirstName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLastName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTel_vc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMobile_vc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAddress_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tsSupplier = New System.Windows.Forms.ToolStrip
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.gbDetail.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInstaller, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsSupplier.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.txtInstallerID)
        Me.gbDetail.Controls.Add(Me.txtAddress_nvc)
        Me.gbDetail.Controls.Add(Me.txtMobile_vc)
        Me.gbDetail.Controls.Add(Me.Label5)
        Me.gbDetail.Controls.Add(Me.txtTel_vc)
        Me.gbDetail.Controls.Add(Me.Label4)
        Me.gbDetail.Controls.Add(Me.txtLastName_nvc)
        Me.gbDetail.Controls.Add(Me.Label1)
        Me.gbDetail.Controls.Add(Me.Label3)
        Me.gbDetail.Controls.Add(Me.txtFirstName_nvc)
        Me.gbDetail.Controls.Add(Me.Label2)
        Me.gbDetail.Location = New System.Drawing.Point(17, 317)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(662, 117)
        Me.gbDetail.TabIndex = 12
        Me.gbDetail.TabStop = False
        '
        'txtInstallerID
        '
        Me.txtInstallerID.Location = New System.Drawing.Point(6, 20)
        Me.txtInstallerID.Name = "txtInstallerID"
        Me.txtInstallerID.Size = New System.Drawing.Size(23, 21)
        Me.txtInstallerID.TabIndex = 15
        Me.txtInstallerID.Visible = False
        '
        'txtAddress_nvc
        '
        Me.txtAddress_nvc.Location = New System.Drawing.Point(35, 77)
        Me.txtAddress_nvc.MaxLength = 500
        Me.txtAddress_nvc.Name = "txtAddress_nvc"
        Me.txtAddress_nvc.Size = New System.Drawing.Size(547, 21)
        Me.txtAddress_nvc.TabIndex = 14
        '
        'txtMobile_vc
        '
        Me.txtMobile_vc.Location = New System.Drawing.Point(35, 49)
        Me.txtMobile_vc.MaxLength = 20
        Me.txtMobile_vc.Name = "txtMobile_vc"
        Me.txtMobile_vc.Size = New System.Drawing.Size(278, 21)
        Me.txtMobile_vc.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(323, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "موبایل:"
        '
        'txtTel_vc
        '
        Me.txtTel_vc.Location = New System.Drawing.Point(421, 49)
        Me.txtTel_vc.MaxLength = 20
        Me.txtTel_vc.Name = "txtTel_vc"
        Me.txtTel_vc.Size = New System.Drawing.Size(161, 21)
        Me.txtTel_vc.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(597, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "تلفن:"
        '
        'txtLastName_nvc
        '
        Me.txtLastName_nvc.Location = New System.Drawing.Point(35, 20)
        Me.txtLastName_nvc.MaxLength = 100
        Me.txtLastName_nvc.Name = "txtLastName_nvc"
        Me.txtLastName_nvc.Size = New System.Drawing.Size(278, 21)
        Me.txtLastName_nvc.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(323, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "نام خانوادگی:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(597, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "آدرس:"
        '
        'txtFirstName_nvc
        '
        Me.txtFirstName_nvc.Location = New System.Drawing.Point(421, 20)
        Me.txtFirstName_nvc.Name = "txtFirstName_nvc"
        Me.txtFirstName_nvc.Size = New System.Drawing.Size(161, 21)
        Me.txtFirstName_nvc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(597, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "نام :"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(48, 22)
        Me.btnDelete.Text = "حذف"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(58, 22)
        Me.btnEdit.Text = "ويرايش"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(48, 22)
        Me.btnAdd.Text = "جديد"
        '
        'dgvInstaller
        '
        Me.dgvInstaller.AllowUserToAddRows = False
        Me.dgvInstaller.AllowUserToDeleteRows = False
        Me.dgvInstaller.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvInstaller.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInstaller.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvInstaller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInstaller.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInstallerID, Me.colFirstName_nvc, Me.colLastName_nvc, Me.colTel_vc, Me.colMobile_vc, Me.colAddress_nvc})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInstaller.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInstaller.Location = New System.Drawing.Point(19, 47)
        Me.dgvInstaller.MultiSelect = False
        Me.dgvInstaller.Name = "dgvInstaller"
        Me.dgvInstaller.ReadOnly = True
        Me.dgvInstaller.RowHeadersVisible = False
        Me.dgvInstaller.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInstaller.Size = New System.Drawing.Size(662, 267)
        Me.dgvInstaller.TabIndex = 14
        '
        'colInstallerID
        '
        Me.colInstallerID.DataPropertyName = "InstallerID"
        Me.colInstallerID.HeaderText = "کد "
        Me.colInstallerID.Name = "colInstallerID"
        Me.colInstallerID.ReadOnly = True
        '
        'colFirstName_nvc
        '
        Me.colFirstName_nvc.DataPropertyName = "FirstName_nvc"
        Me.colFirstName_nvc.HeaderText = "نام"
        Me.colFirstName_nvc.Name = "colFirstName_nvc"
        Me.colFirstName_nvc.ReadOnly = True
        Me.colFirstName_nvc.Width = 150
        '
        'colLastName_nvc
        '
        Me.colLastName_nvc.DataPropertyName = "LastName_nvc"
        Me.colLastName_nvc.HeaderText = "نام خانوادگی"
        Me.colLastName_nvc.Name = "colLastName_nvc"
        Me.colLastName_nvc.ReadOnly = True
        Me.colLastName_nvc.Width = 250
        '
        'colTel_vc
        '
        Me.colTel_vc.DataPropertyName = "Tel_vc"
        Me.colTel_vc.HeaderText = "تلفن"
        Me.colTel_vc.Name = "colTel_vc"
        Me.colTel_vc.ReadOnly = True
        Me.colTel_vc.Width = 120
        '
        'colMobile_vc
        '
        Me.colMobile_vc.DataPropertyName = "Mobile_vc"
        Me.colMobile_vc.HeaderText = "موبایل"
        Me.colMobile_vc.Name = "colMobile_vc"
        Me.colMobile_vc.ReadOnly = True
        Me.colMobile_vc.Width = 120
        '
        'colAddress_nvc
        '
        Me.colAddress_nvc.DataPropertyName = "Address_nvc"
        Me.colAddress_nvc.HeaderText = "آدرس"
        Me.colAddress_nvc.Name = "colAddress_nvc"
        Me.colAddress_nvc.ReadOnly = True
        '
        'tsSupplier
        '
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel})
        Me.tsSupplier.Location = New System.Drawing.Point(0, 0)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(692, 25)
        Me.tsSupplier.TabIndex = 13
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'frmInstaller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 462)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.dgvInstaller)
        Me.Controls.Add(Me.tsSupplier)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInstaller"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعریف نصاب "
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInstaller, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents dgvInstaller As System.Windows.Forms.DataGridView
    Friend WithEvents tsSupplier As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtMobile_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTel_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLastName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress_nvc As System.Windows.Forms.TextBox
    Friend WithEvents txtInstallerID As System.Windows.Forms.TextBox
    Friend WithEvents colInstallerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFirstName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLastName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTel_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMobile_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAddress_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
