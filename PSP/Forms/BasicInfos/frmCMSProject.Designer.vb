<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCMSProject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCMSProject))
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
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCMSProjectID = New System.Windows.Forms.TextBox()
        Me.gbDetail = New System.Windows.Forms.GroupBox()
        Me.chkIsEniacOutlet = New System.Windows.Forms.CheckBox()
        Me.chkIsEniacMerchant = New System.Windows.Forms.CheckBox()
        Me.chkIsSent2Switch = New System.Windows.Forms.CheckBox()
        Me.txtEssws = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtName_nvc = New System.Windows.Forms.TextBox()
        Me.dgvCMSProject = New System.Windows.Forms.DataGridView()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsSupplier = New System.Windows.Forms.ToolStrip()
        Me.colCMSProjectID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colESSWS_NVC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIsSent2Switch = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colIsEniacMerchant = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colIsEniacOutlet = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetail.SuspendLayout()
        CType(Me.dgvCMSProject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsSupplier.SuspendLayout()
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
        Me.Label2.Location = New System.Drawing.Point(917, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "نام :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(917, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "کد :"
        '
        'txtCMSProjectID
        '
        Me.txtCMSProjectID.Location = New System.Drawing.Point(791, 19)
        Me.txtCMSProjectID.MaxLength = 3
        Me.txtCMSProjectID.Name = "txtCMSProjectID"
        Me.txtCMSProjectID.Size = New System.Drawing.Size(119, 21)
        Me.txtCMSProjectID.TabIndex = 2
        '
        'gbDetail
        '
        Me.gbDetail.Controls.Add(Me.chkIsEniacOutlet)
        Me.gbDetail.Controls.Add(Me.chkIsEniacMerchant)
        Me.gbDetail.Controls.Add(Me.chkIsSent2Switch)
        Me.gbDetail.Controls.Add(Me.txtEssws)
        Me.gbDetail.Controls.Add(Me.Label4)
        Me.gbDetail.Controls.Add(Me.txtName_nvc)
        Me.gbDetail.Controls.Add(Me.txtCMSProjectID)
        Me.gbDetail.Controls.Add(Me.Label2)
        Me.gbDetail.Controls.Add(Me.Label1)
        Me.gbDetail.Location = New System.Drawing.Point(5, 329)
        Me.gbDetail.Name = "gbDetail"
        Me.gbDetail.Size = New System.Drawing.Size(998, 101)
        Me.gbDetail.TabIndex = 9
        Me.gbDetail.TabStop = False
        '
        'chkIsEniacOutlet
        '
        Me.chkIsEniacOutlet.AutoSize = True
        Me.chkIsEniacOutlet.Location = New System.Drawing.Point(16, 71)
        Me.chkIsEniacOutlet.Name = "chkIsEniacOutlet"
        Me.chkIsEniacOutlet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIsEniacOutlet.Size = New System.Drawing.Size(106, 17)
        Me.chkIsEniacOutlet.TabIndex = 12
        Me.chkIsEniacOutlet.Text = "شماره پایانه انیاک"
        Me.chkIsEniacOutlet.UseVisualStyleBackColor = True
        '
        'chkIsEniacMerchant
        '
        Me.chkIsEniacMerchant.AutoSize = True
        Me.chkIsEniacMerchant.Location = New System.Drawing.Point(16, 43)
        Me.chkIsEniacMerchant.Name = "chkIsEniacMerchant"
        Me.chkIsEniacMerchant.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIsEniacMerchant.Size = New System.Drawing.Size(116, 17)
        Me.chkIsEniacMerchant.TabIndex = 11
        Me.chkIsEniacMerchant.Text = "شماره پذیرنده انیاک"
        Me.chkIsEniacMerchant.UseVisualStyleBackColor = True
        '
        'chkIsSent2Switch
        '
        Me.chkIsSent2Switch.AutoSize = True
        Me.chkIsSent2Switch.Location = New System.Drawing.Point(16, 20)
        Me.chkIsSent2Switch.Name = "chkIsSent2Switch"
        Me.chkIsSent2Switch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkIsSent2Switch.Size = New System.Drawing.Size(100, 17)
        Me.chkIsSent2Switch.TabIndex = 10
        Me.chkIsSent2Switch.Text = "ارسال به سوئیچ"
        Me.chkIsSent2Switch.UseVisualStyleBackColor = True
        '
        'txtEssws
        '
        Me.txtEssws.Location = New System.Drawing.Point(365, 73)
        Me.txtEssws.Name = "txtEssws"
        Me.txtEssws.Size = New System.Drawing.Size(544, 21)
        Me.txtEssws.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(916, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "آدرس سوئیچ:"
        '
        'txtName_nvc
        '
        Me.txtName_nvc.Location = New System.Drawing.Point(365, 47)
        Me.txtName_nvc.Name = "txtName_nvc"
        Me.txtName_nvc.Size = New System.Drawing.Size(544, 21)
        Me.txtName_nvc.TabIndex = 3
        '
        'dgvCMSProject
        '
        Me.dgvCMSProject.AllowUserToAddRows = False
        Me.dgvCMSProject.AllowUserToDeleteRows = False
        Me.dgvCMSProject.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvCMSProject.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCMSProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCMSProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCMSProject.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCMSProjectID, Me.colName_nvc, Me.colESSWS_NVC, Me.colIsSent2Switch, Me.colIsEniacMerchant, Me.colIsEniacOutlet})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCMSProject.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCMSProject.Location = New System.Drawing.Point(5, 36)
        Me.dgvCMSProject.MultiSelect = False
        Me.dgvCMSProject.Name = "dgvCMSProject"
        Me.dgvCMSProject.ReadOnly = True
        Me.dgvCMSProject.RowHeadersVisible = False
        Me.dgvCMSProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCMSProject.Size = New System.Drawing.Size(1002, 292)
        Me.dgvCMSProject.TabIndex = 11
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
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel})
        Me.tsSupplier.Location = New System.Drawing.Point(0, 0)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(1007, 25)
        Me.tsSupplier.TabIndex = 10
        '
        'colCMSProjectID
        '
        Me.colCMSProjectID.DataPropertyName = "CMSProjectID_int"
        Me.colCMSProjectID.HeaderText = "کد"
        Me.colCMSProjectID.Name = "colCMSProjectID"
        Me.colCMSProjectID.ReadOnly = True
        '
        'colName_nvc
        '
        Me.colName_nvc.DataPropertyName = "Name_nvc"
        Me.colName_nvc.HeaderText = "نام"
        Me.colName_nvc.Name = "colName_nvc"
        Me.colName_nvc.ReadOnly = True
        Me.colName_nvc.Width = 150
        '
        'colESSWS_NVC
        '
        Me.colESSWS_NVC.DataPropertyName = "ESSWS_NVC"
        Me.colESSWS_NVC.HeaderText = "آدرس سوئیچ"
        Me.colESSWS_NVC.Name = "colESSWS_NVC"
        Me.colESSWS_NVC.ReadOnly = True
        Me.colESSWS_NVC.Width = 400
        '
        'colIsSent2Switch
        '
        Me.colIsSent2Switch.DataPropertyName = "ISSENT2SWITCH"
        Me.colIsSent2Switch.FalseValue = "0"
        Me.colIsSent2Switch.HeaderText = "ارسال به سوئیچ"
        Me.colIsSent2Switch.Name = "colIsSent2Switch"
        Me.colIsSent2Switch.ReadOnly = True
        Me.colIsSent2Switch.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colIsSent2Switch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colIsSent2Switch.TrueValue = "1"
        Me.colIsSent2Switch.Width = 110
        '
        'colIsEniacMerchant
        '
        Me.colIsEniacMerchant.DataPropertyName = "IsEniacMerchant"
        Me.colIsEniacMerchant.FalseValue = "0"
        Me.colIsEniacMerchant.HeaderText = "شماره پذیرنده انیاک"
        Me.colIsEniacMerchant.Name = "colIsEniacMerchant"
        Me.colIsEniacMerchant.ReadOnly = True
        Me.colIsEniacMerchant.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colIsEniacMerchant.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colIsEniacMerchant.TrueValue = "1"
        Me.colIsEniacMerchant.Width = 120
        '
        'colIsEniacOutlet
        '
        Me.colIsEniacOutlet.DataPropertyName = "IsEniacOutlet"
        Me.colIsEniacOutlet.FalseValue = "0"
        Me.colIsEniacOutlet.HeaderText = "شماره پایانه انیاک"
        Me.colIsEniacOutlet.Name = "colIsEniacOutlet"
        Me.colIsEniacOutlet.ReadOnly = True
        Me.colIsEniacOutlet.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colIsEniacOutlet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colIsEniacOutlet.TrueValue = "1"
        Me.colIsEniacOutlet.Width = 120
        '
        'frmCMSProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 438)
        Me.Controls.Add(Me.gbDetail)
        Me.Controls.Add(Me.dgvCMSProject)
        Me.Controls.Add(Me.tsSupplier)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCMSProject"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعریف پروژه"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetail.ResumeLayout(False)
        Me.gbDetail.PerformLayout()
        CType(Me.dgvCMSProject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
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
    Friend WithEvents txtName_nvc As System.Windows.Forms.TextBox
    Friend WithEvents txtCMSProjectID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvCMSProject As System.Windows.Forms.DataGridView
    Friend WithEvents tsSupplier As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkIsEniacOutlet As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsEniacMerchant As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsSent2Switch As System.Windows.Forms.CheckBox
    Friend WithEvents txtEssws As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents colCMSProjectID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colName_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colESSWS_NVC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIsSent2Switch As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colIsEniacMerchant As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colIsEniacOutlet As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
