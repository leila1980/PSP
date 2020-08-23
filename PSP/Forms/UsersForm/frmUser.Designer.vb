<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtRealName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUseName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgUser = New System.Windows.Forms.DataGridView
        Me.colUserName_vc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFullName_vc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIsActive_bit = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colPassword_vc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkEdit = New System.Windows.Forms.CheckBox
        Me.chkPrint = New System.Windows.Forms.CheckBox
        Me.chkView = New System.Windows.Forms.CheckBox
        Me.chkDelete = New System.Windows.Forms.CheckBox
        Me.chkNew = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbForm = New System.Windows.Forms.ComboBox
        Me.dgPermission = New System.Windows.Forms.DataGridView
        Me.colUserID2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFormCaption = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colView_bit = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colNew_bit = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colEdit_bit = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colDelete_bit = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colPrint_bit = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colFormID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tsCompanyTool = New System.Windows.Forms.ToolStrip
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEdit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.tsCompanyTool2 = New System.Windows.Forms.ToolStrip
        Me.btnAdd2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnEdit2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCancel2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSave2 = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.StatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgPermission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsCompanyTool.SuspendLayout()
        Me.tsCompanyTool2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(743, 436)
        Me.TabControl1.TabIndex = 14
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.dgUser)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(735, 410)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "تعریف کاربران"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkActive)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtRealName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtConfirmPassword)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtUseName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 298)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(719, 106)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.Location = New System.Drawing.Point(170, 53)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(54, 17)
        Me.chkActive.TabIndex = 9
        Me.chkActive.Text = "فعال :"
        Me.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(188, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "نام حقیقی کاربری :"
        '
        'txtRealName
        '
        Me.txtRealName.Location = New System.Drawing.Point(53, 24)
        Me.txtRealName.Name = "txtRealName"
        Me.txtRealName.Size = New System.Drawing.Size(129, 21)
        Me.txtRealName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(621, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "تکرار کلمه عبور :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(621, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "کلمه عبور :"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConfirmPassword.Location = New System.Drawing.Point(491, 75)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(124, 21)
        Me.txtConfirmPassword.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(491, 48)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(124, 21)
        Me.txtPassword.TabIndex = 2
        '
        'txtUseName
        '
        Me.txtUseName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUseName.Location = New System.Drawing.Point(491, 21)
        Me.txtUseName.Name = "txtUseName"
        Me.txtUseName.Size = New System.Drawing.Size(124, 21)
        Me.txtUseName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(621, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "نام کاربری :"
        '
        'dgUser
        '
        Me.dgUser.AllowDrop = True
        Me.dgUser.AllowUserToAddRows = False
        Me.dgUser.AllowUserToDeleteRows = False
        Me.dgUser.AllowUserToResizeRows = False
        Me.dgUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUserName_vc, Me.colFullName_vc, Me.colIsActive_bit, Me.colPassword_vc, Me.colUserID})
        Me.dgUser.Location = New System.Drawing.Point(8, 17)
        Me.dgUser.MultiSelect = False
        Me.dgUser.Name = "dgUser"
        Me.dgUser.ReadOnly = True
        Me.dgUser.RowHeadersVisible = False
        Me.dgUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgUser.Size = New System.Drawing.Size(719, 275)
        Me.dgUser.TabIndex = 13
        '
        'colUserName_vc
        '
        Me.colUserName_vc.DataPropertyName = "UserName_vc"
        Me.colUserName_vc.HeaderText = "نام کاربری"
        Me.colUserName_vc.Name = "colUserName_vc"
        Me.colUserName_vc.ReadOnly = True
        Me.colUserName_vc.Width = 200
        '
        'colFullName_vc
        '
        Me.colFullName_vc.DataPropertyName = "FullName_vc"
        Me.colFullName_vc.HeaderText = "نام واقعی کاربر"
        Me.colFullName_vc.Name = "colFullName_vc"
        Me.colFullName_vc.ReadOnly = True
        Me.colFullName_vc.Width = 250
        '
        'colIsActive_bit
        '
        Me.colIsActive_bit.DataPropertyName = "IsActive_bit"
        Me.colIsActive_bit.HeaderText = "فعال"
        Me.colIsActive_bit.Name = "colIsActive_bit"
        Me.colIsActive_bit.ReadOnly = True
        Me.colIsActive_bit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colIsActive_bit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colIsActive_bit.Width = 150
        '
        'colPassword_vc
        '
        Me.colPassword_vc.DataPropertyName = "Password_vc"
        Me.colPassword_vc.HeaderText = "کلمه عبور"
        Me.colPassword_vc.Name = "colPassword_vc"
        Me.colPassword_vc.ReadOnly = True
        Me.colPassword_vc.Visible = False
        '
        'colUserID
        '
        Me.colUserID.DataPropertyName = "UserID"
        Me.colUserID.HeaderText = "کد کاربر"
        Me.colUserID.Name = "colUserID"
        Me.colUserID.ReadOnly = True
        Me.colUserID.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.dgPermission)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(735, 410)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "مجوز کاربری"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmbForm)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 247)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(719, 157)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.chkEdit)
        Me.GroupBox4.Controls.Add(Me.chkPrint)
        Me.GroupBox4.Controls.Add(Me.chkView)
        Me.GroupBox4.Controls.Add(Me.chkDelete)
        Me.GroupBox4.Controls.Add(Me.chkNew)
        Me.GroupBox4.Location = New System.Drawing.Point(42, 60)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(623, 68)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        '
        'chkEdit
        '
        Me.chkEdit.AutoSize = True
        Me.chkEdit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEdit.Checked = True
        Me.chkEdit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEdit.Location = New System.Drawing.Point(273, 30)
        Me.chkEdit.Name = "chkEdit"
        Me.chkEdit.Size = New System.Drawing.Size(59, 17)
        Me.chkEdit.TabIndex = 4
        Me.chkEdit.Text = "ویرایش"
        Me.chkEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEdit.UseVisualStyleBackColor = True
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrint.Checked = True
        Me.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrint.Location = New System.Drawing.Point(85, 30)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(45, 17)
        Me.chkPrint.TabIndex = 6
        Me.chkPrint.Text = "چاپ"
        Me.chkPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'chkView
        '
        Me.chkView.AutoSize = True
        Me.chkView.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkView.Checked = True
        Me.chkView.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkView.Location = New System.Drawing.Point(474, 30)
        Me.chkView.Name = "chkView"
        Me.chkView.Size = New System.Drawing.Size(56, 17)
        Me.chkView.TabIndex = 0
        Me.chkView.Text = "نمایش"
        Me.chkView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkView.UseVisualStyleBackColor = True
        '
        'chkDelete
        '
        Me.chkDelete.AutoSize = True
        Me.chkDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDelete.Checked = True
        Me.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDelete.Location = New System.Drawing.Point(177, 30)
        Me.chkDelete.Name = "chkDelete"
        Me.chkDelete.Size = New System.Drawing.Size(49, 17)
        Me.chkDelete.TabIndex = 5
        Me.chkDelete.Text = "حذف"
        Me.chkDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDelete.UseVisualStyleBackColor = True
        '
        'chkNew
        '
        Me.chkNew.AutoSize = True
        Me.chkNew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNew.Checked = True
        Me.chkNew.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNew.Location = New System.Drawing.Point(379, 30)
        Me.chkNew.Name = "chkNew"
        Me.chkNew.Size = New System.Drawing.Size(48, 17)
        Me.chkNew.TabIndex = 3
        Me.chkNew.Text = "جدید"
        Me.chkNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNew.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(621, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "نام فرم :"
        '
        'cmbForm
        '
        Me.cmbForm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbForm.FormattingEnabled = True
        Me.cmbForm.Location = New System.Drawing.Point(42, 25)
        Me.cmbForm.Name = "cmbForm"
        Me.cmbForm.Size = New System.Drawing.Size(573, 21)
        Me.cmbForm.TabIndex = 1
        '
        'dgPermission
        '
        Me.dgPermission.AllowDrop = True
        Me.dgPermission.AllowUserToAddRows = False
        Me.dgPermission.AllowUserToDeleteRows = False
        Me.dgPermission.AllowUserToResizeRows = False
        Me.dgPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPermission.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colUserID2, Me.colFormCaption, Me.colView_bit, Me.colNew_bit, Me.colEdit_bit, Me.colDelete_bit, Me.colPrint_bit, Me.colFormID})
        Me.dgPermission.Location = New System.Drawing.Point(6, 14)
        Me.dgPermission.MultiSelect = False
        Me.dgPermission.Name = "dgPermission"
        Me.dgPermission.ReadOnly = True
        Me.dgPermission.RowHeadersVisible = False
        Me.dgPermission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPermission.Size = New System.Drawing.Size(723, 227)
        Me.dgPermission.TabIndex = 14
        '
        'colUserID2
        '
        Me.colUserID2.DataPropertyName = "UserID"
        Me.colUserID2.HeaderText = "کد کاربر"
        Me.colUserID2.Name = "colUserID2"
        Me.colUserID2.ReadOnly = True
        Me.colUserID2.Visible = False
        '
        'colFormCaption
        '
        Me.colFormCaption.DataPropertyName = "FormCaption"
        Me.colFormCaption.HeaderText = "نام فرم"
        Me.colFormCaption.Name = "colFormCaption"
        Me.colFormCaption.ReadOnly = True
        Me.colFormCaption.Width = 200
        '
        'colView_bit
        '
        Me.colView_bit.DataPropertyName = "View_bit"
        Me.colView_bit.HeaderText = "نمایش"
        Me.colView_bit.Name = "colView_bit"
        Me.colView_bit.ReadOnly = True
        Me.colView_bit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colView_bit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colNew_bit
        '
        Me.colNew_bit.DataPropertyName = "New_bit"
        Me.colNew_bit.HeaderText = "جدید"
        Me.colNew_bit.Name = "colNew_bit"
        Me.colNew_bit.ReadOnly = True
        Me.colNew_bit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colNew_bit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colEdit_bit
        '
        Me.colEdit_bit.DataPropertyName = "Edit_bit"
        Me.colEdit_bit.HeaderText = "ویرایش"
        Me.colEdit_bit.Name = "colEdit_bit"
        Me.colEdit_bit.ReadOnly = True
        Me.colEdit_bit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colEdit_bit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colDelete_bit
        '
        Me.colDelete_bit.DataPropertyName = "Delete_bit"
        Me.colDelete_bit.HeaderText = "حذف"
        Me.colDelete_bit.Name = "colDelete_bit"
        Me.colDelete_bit.ReadOnly = True
        Me.colDelete_bit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDelete_bit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colPrint_bit
        '
        Me.colPrint_bit.DataPropertyName = "Print_bit"
        Me.colPrint_bit.HeaderText = "چاپ"
        Me.colPrint_bit.Name = "colPrint_bit"
        Me.colPrint_bit.ReadOnly = True
        Me.colPrint_bit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPrint_bit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colFormID
        '
        Me.colFormID.DataPropertyName = "FormID"
        Me.colFormID.HeaderText = "کد فرم"
        Me.colFormID.Name = "colFormID"
        Me.colFormID.ReadOnly = True
        Me.colFormID.Visible = False
        '
        'tsCompanyTool
        '
        Me.tsCompanyTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator6, Me.btnSave, Me.ToolStripSeparator3, Me.btnCancel})
        Me.tsCompanyTool.Location = New System.Drawing.Point(0, 0)
        Me.tsCompanyTool.Name = "tsCompanyTool"
        Me.tsCompanyTool.Size = New System.Drawing.Size(743, 25)
        Me.tsCompanyTool.TabIndex = 15
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(49, 22)
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
        Me.btnEdit.Size = New System.Drawing.Size(60, 22)
        Me.btnEdit.Text = "ويرايش"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 22)
        Me.btnCancel.Text = "انصراف"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 22)
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
        Me.btnSave.Size = New System.Drawing.Size(44, 22)
        Me.btnSave.Text = "ثبت"
        '
        'tsCompanyTool2
        '
        Me.tsCompanyTool2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd2, Me.ToolStripSeparator4, Me.btnEdit2, Me.ToolStripSeparator5, Me.btnSave2, Me.ToolStripSeparator7, Me.btnCancel2})
        Me.tsCompanyTool2.Location = New System.Drawing.Point(0, 25)
        Me.tsCompanyTool2.Name = "tsCompanyTool2"
        Me.tsCompanyTool2.Size = New System.Drawing.Size(743, 25)
        Me.tsCompanyTool2.TabIndex = 18
        '
        'btnAdd2
        '
        Me.btnAdd2.Image = CType(resources.GetObject("btnAdd2.Image"), System.Drawing.Image)
        Me.btnAdd2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd2.Name = "btnAdd2"
        Me.btnAdd2.Size = New System.Drawing.Size(49, 22)
        Me.btnAdd2.Text = "جديد"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnEdit2
        '
        Me.btnEdit2.Image = CType(resources.GetObject("btnEdit2.Image"), System.Drawing.Image)
        Me.btnEdit2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit2.Name = "btnEdit2"
        Me.btnEdit2.Size = New System.Drawing.Size(60, 22)
        Me.btnEdit2.Text = "ويرايش"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnCancel2
        '
        Me.btnCancel2.Image = CType(resources.GetObject("btnCancel2.Image"), System.Drawing.Image)
        Me.btnCancel2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancel2.Name = "btnCancel2"
        Me.btnCancel2.Size = New System.Drawing.Size(60, 22)
        Me.btnCancel2.Text = "انصراف"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'btnSave2
        '
        Me.btnSave2.Image = CType(resources.GetObject("btnSave2.Image"), System.Drawing.Image)
        Me.btnSave2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave2.Name = "btnSave2"
        Me.btnSave2.Size = New System.Drawing.Size(44, 22)
        Me.btnSave2.Text = "ثبت"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 464)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(743, 22)
        Me.StatusStrip1.TabIndex = 20
        '
        'StatusLabel1
        '
        Me.StatusLabel1.Name = "StatusLabel1"
        Me.StatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 486)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tsCompanyTool2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.tsCompanyTool)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUser"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "فرم تعریف کاربران"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgPermission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsCompanyTool.ResumeLayout(False)
        Me.tsCompanyTool.PerformLayout()
        Me.tsCompanyTool2.ResumeLayout(False)
        Me.tsCompanyTool2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRealName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUseName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgUser As System.Windows.Forms.DataGridView
    Friend WithEvents tsCompanyTool As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgPermission As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
    Friend WithEvents chkDelete As System.Windows.Forms.CheckBox
    Friend WithEvents chkEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkNew As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbForm As System.Windows.Forms.ComboBox
    Friend WithEvents chkView As System.Windows.Forms.CheckBox
    Friend WithEvents tsCompanyTool2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEdit2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents colUserName_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIsActive_bit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPassword_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserID2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFormCaption As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colView_bit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colNew_bit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colEdit_bit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDelete_bit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPrint_bit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colFormID As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
