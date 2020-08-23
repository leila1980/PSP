<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCallsFolowing
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCallsFolowing))
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpCallsInfoNotComp = New System.Windows.Forms.TabPage()
        Me.grpGrid = New System.Windows.Forms.GroupBox()
        Me.dgvCallsInfoNComp = New System.Windows.Forms.DataGridView()
        Me.tbpCallsInfoComp = New System.Windows.Forms.TabPage()
        Me.grpGrid2 = New System.Windows.Forms.GroupBox()
        Me.dgvCallsInfoComp = New System.Windows.Forms.DataGridView()
        Me.grpCallsFolowing = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.rbtNotCompleted = New System.Windows.Forms.RadioButton()
        Me.rbtCompleted = New System.Windows.Forms.RadioButton()
        Me.btnResDesc = New System.Windows.Forms.Button()
        Me.txtResponsDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtResponseDate_vc = New DateTextBox.DateTextBox()
        Me.txtCallFolowingID = New System.Windows.Forms.TextBox()
        Me.txtResponseTime_vc = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCallID = New System.Windows.Forms.TextBox()
        Me.ق = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.dgvCallsFolowing = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPDF = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.colCallFolowingID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCallID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompleted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResponsDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResponseDate_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResponseTime_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tbpCallsInfoNotComp.SuspendLayout()
        Me.grpGrid.SuspendLayout()
        CType(Me.dgvCallsInfoNComp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpCallsInfoComp.SuspendLayout()
        Me.grpGrid2.SuspendLayout()
        CType(Me.dgvCallsInfoComp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCallsFolowing.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tsSupplier.SuspendLayout()
        CType(Me.dgvCallsFolowing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpCallsInfoNotComp)
        Me.TabControl1.Controls.Add(Me.tbpCallsInfoComp)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(794, 243)
        Me.TabControl1.TabIndex = 1
        '
        'tbpCallsInfoNotComp
        '
        Me.tbpCallsInfoNotComp.Controls.Add(Me.grpGrid)
        Me.tbpCallsInfoNotComp.Location = New System.Drawing.Point(4, 22)
        Me.tbpCallsInfoNotComp.Name = "tbpCallsInfoNotComp"
        Me.tbpCallsInfoNotComp.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCallsInfoNotComp.Size = New System.Drawing.Size(786, 217)
        Me.tbpCallsInfoNotComp.TabIndex = 0
        Me.tbpCallsInfoNotComp.Text = "ليست تماسهاي ناتمام"
        Me.tbpCallsInfoNotComp.UseVisualStyleBackColor = True
        '
        'grpGrid
        '
        Me.grpGrid.Controls.Add(Me.dgvCallsInfoNComp)
        Me.grpGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpGrid.Location = New System.Drawing.Point(3, 3)
        Me.grpGrid.Name = "grpGrid"
        Me.grpGrid.Size = New System.Drawing.Size(780, 211)
        Me.grpGrid.TabIndex = 8
        Me.grpGrid.TabStop = False
        '
        'dgvCallsInfoNComp
        '
        Me.dgvCallsInfoNComp.AllowUserToAddRows = False
        Me.dgvCallsInfoNComp.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvCallsInfoNComp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCallsInfoNComp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCallsInfoNComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCallsInfoNComp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCallsInfoNComp.Location = New System.Drawing.Point(3, 17)
        Me.dgvCallsInfoNComp.Name = "dgvCallsInfoNComp"
        Me.dgvCallsInfoNComp.ReadOnly = True
        Me.dgvCallsInfoNComp.Size = New System.Drawing.Size(774, 191)
        Me.dgvCallsInfoNComp.TabIndex = 0
        '
        'tbpCallsInfoComp
        '
        Me.tbpCallsInfoComp.Controls.Add(Me.grpGrid2)
        Me.tbpCallsInfoComp.Location = New System.Drawing.Point(4, 22)
        Me.tbpCallsInfoComp.Name = "tbpCallsInfoComp"
        Me.tbpCallsInfoComp.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCallsInfoComp.Size = New System.Drawing.Size(786, 217)
        Me.tbpCallsInfoComp.TabIndex = 1
        Me.tbpCallsInfoComp.Text = "ليست تماسهاي تمام شده"
        Me.tbpCallsInfoComp.UseVisualStyleBackColor = True
        '
        'grpGrid2
        '
        Me.grpGrid2.Controls.Add(Me.dgvCallsInfoComp)
        Me.grpGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpGrid2.Location = New System.Drawing.Point(3, 3)
        Me.grpGrid2.Name = "grpGrid2"
        Me.grpGrid2.Size = New System.Drawing.Size(780, 211)
        Me.grpGrid2.TabIndex = 9
        Me.grpGrid2.TabStop = False
        '
        'dgvCallsInfoComp
        '
        Me.dgvCallsInfoComp.AllowUserToAddRows = False
        Me.dgvCallsInfoComp.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvCallsInfoComp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCallsInfoComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCallsInfoComp.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCallsInfoComp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCallsInfoComp.Location = New System.Drawing.Point(3, 17)
        Me.dgvCallsInfoComp.Name = "dgvCallsInfoComp"
        Me.dgvCallsInfoComp.ReadOnly = True
        Me.dgvCallsInfoComp.Size = New System.Drawing.Size(774, 191)
        Me.dgvCallsInfoComp.TabIndex = 0
        '
        'grpCallsFolowing
        '
        Me.grpCallsFolowing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCallsFolowing.Controls.Add(Me.GroupBox2)
        Me.grpCallsFolowing.Controls.Add(Me.txtResponseDate_vc)
        Me.grpCallsFolowing.Controls.Add(Me.txtCallFolowingID)
        Me.grpCallsFolowing.Controls.Add(Me.txtResponseTime_vc)
        Me.grpCallsFolowing.Controls.Add(Me.Label2)
        Me.grpCallsFolowing.Controls.Add(Me.Label1)
        Me.grpCallsFolowing.Controls.Add(Me.txtCallID)
        Me.grpCallsFolowing.Controls.Add(Me.ق)
        Me.grpCallsFolowing.Location = New System.Drawing.Point(4, 124)
        Me.grpCallsFolowing.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.grpCallsFolowing.Name = "grpCallsFolowing"
        Me.grpCallsFolowing.Padding = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.grpCallsFolowing.Size = New System.Drawing.Size(786, 111)
        Me.grpCallsFolowing.TabIndex = 9
        Me.grpCallsFolowing.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtDescription)
        Me.GroupBox2.Controls.Add(Me.rbtNotCompleted)
        Me.GroupBox2.Controls.Add(Me.rbtCompleted)
        Me.GroupBox2.Controls.Add(Me.btnResDesc)
        Me.GroupBox2.Controls.Add(Me.txtResponsDesc)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(-277, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1058, 75)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(955, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "توضیحات :"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(338, 51)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(613, 21)
        Me.txtDescription.TabIndex = 6
        '
        'rbtNotCompleted
        '
        Me.rbtNotCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtNotCompleted.AutoSize = True
        Me.rbtNotCompleted.Location = New System.Drawing.Point(820, 10)
        Me.rbtNotCompleted.Name = "rbtNotCompleted"
        Me.rbtNotCompleted.Size = New System.Drawing.Size(51, 17)
        Me.rbtNotCompleted.TabIndex = 1
        Me.rbtNotCompleted.TabStop = True
        Me.rbtNotCompleted.Text = "ناتمام"
        Me.rbtNotCompleted.UseVisualStyleBackColor = True
        '
        'rbtCompleted
        '
        Me.rbtCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbtCompleted.AutoSize = True
        Me.rbtCompleted.Location = New System.Drawing.Point(908, 10)
        Me.rbtCompleted.Name = "rbtCompleted"
        Me.rbtCompleted.Size = New System.Drawing.Size(43, 17)
        Me.rbtCompleted.TabIndex = 0
        Me.rbtCompleted.TabStop = True
        Me.rbtCompleted.Text = "تمام"
        Me.rbtCompleted.UseVisualStyleBackColor = True
        '
        'btnResDesc
        '
        Me.btnResDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResDesc.Location = New System.Drawing.Point(296, 26)
        Me.btnResDesc.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.btnResDesc.Name = "btnResDesc"
        Me.btnResDesc.Size = New System.Drawing.Size(29, 22)
        Me.btnResDesc.TabIndex = 4
        Me.btnResDesc.Text = "..."
        Me.btnResDesc.UseVisualStyleBackColor = True
        '
        'txtResponsDesc
        '
        Me.txtResponsDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResponsDesc.Location = New System.Drawing.Point(338, 28)
        Me.txtResponsDesc.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtResponsDesc.Name = "txtResponsDesc"
        Me.txtResponsDesc.Size = New System.Drawing.Size(613, 21)
        Me.txtResponsDesc.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(950, 31)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "شرح کار انجام شده :"
        '
        'txtResponseDate_vc
        '
        Me.txtResponseDate_vc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResponseDate_vc.AutoSize = True
        Me.txtResponseDate_vc.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtResponseDate_vc.DateBackColor = System.Drawing.SystemColors.Window
        Me.txtResponseDate_vc.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.txtResponseDate_vc.DateReadOnly = False
        Me.txtResponseDate_vc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtResponseDate_vc.Location = New System.Drawing.Point(349, 15)
        Me.txtResponseDate_vc.Name = "txtResponseDate_vc"
        Me.txtResponseDate_vc.Size = New System.Drawing.Size(119, 20)
        Me.txtResponseDate_vc.TabIndex = 4
        Me.txtResponseDate_vc.Value = ""
        '
        'txtCallFolowingID
        '
        Me.txtCallFolowingID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCallFolowingID.Location = New System.Drawing.Point(729, 14)
        Me.txtCallFolowingID.Name = "txtCallFolowingID"
        Me.txtCallFolowingID.Size = New System.Drawing.Size(50, 21)
        Me.txtCallFolowingID.TabIndex = 0
        '
        'txtResponseTime_vc
        '
        Me.txtResponseTime_vc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResponseTime_vc.Location = New System.Drawing.Point(241, 14)
        Me.txtResponseTime_vc.Mask = "90:00"
        Me.txtResponseTime_vc.Name = "txtResponseTime_vc"
        Me.txtResponseTime_vc.Size = New System.Drawing.Size(37, 21)
        Me.txtResponseTime_vc.TabIndex = 6
        Me.txtResponseTime_vc.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(283, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ساعت :"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(473, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "تاريخ :"
        '
        'txtCallID
        '
        Me.txtCallID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCallID.Enabled = False
        Me.txtCallID.Location = New System.Drawing.Point(560, 13)
        Me.txtCallID.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtCallID.Name = "txtCallID"
        Me.txtCallID.ReadOnly = True
        Me.txtCallID.Size = New System.Drawing.Size(100, 21)
        Me.txtCallID.TabIndex = 2
        '
        'ق
        '
        Me.ق.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ق.AutoSize = True
        Me.ق.Enabled = False
        Me.ق.Location = New System.Drawing.Point(660, 17)
        Me.ق.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ق.Name = "ق"
        Me.ق.Size = New System.Drawing.Size(60, 13)
        Me.ق.TabIndex = 1
        Me.ق.Text = "کد پیگیری :"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 10)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(765, 330)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tsSupplier)
        Me.GroupBox1.Controls.Add(Me.dgvCallsFolowing)
        Me.GroupBox1.Controls.Add(Me.grpCallsFolowing)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(794, 246)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'tsSupplier
        '
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel})
        Me.tsSupplier.Location = New System.Drawing.Point(3, 17)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(788, 25)
        Me.tsSupplier.TabIndex = 0
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
        'dgvCallsFolowing
        '
        Me.dgvCallsFolowing.AllowUserToAddRows = False
        Me.dgvCallsFolowing.AllowUserToDeleteRows = False
        Me.dgvCallsFolowing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCallsFolowing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCallsFolowing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCallFolowingID, Me.colCallID, Me.colCompleted, Me.colResponsDesc, Me.colResponseDate_vc, Me.colResponseTime_vc, Me.colDescription})
        Me.dgvCallsFolowing.Location = New System.Drawing.Point(8, 55)
        Me.dgvCallsFolowing.Name = "dgvCallsFolowing"
        Me.dgvCallsFolowing.ReadOnly = True
        Me.dgvCallsFolowing.Size = New System.Drawing.Size(779, 71)
        Me.dgvCallsFolowing.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPrint, Me.ToolStripSeparator4, Me.btnPDF, Me.ToolStripSeparator5, Me.btnExportToExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(794, 25)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(47, 22)
        Me.btnPrint.Text = "چاپ"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnPDF
        '
        Me.btnPDF.Image = CType(resources.GetObject("btnPDF.Image"), System.Drawing.Image)
        Me.btnPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(48, 22)
        Me.btnPDF.Text = "PDF"
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SplitContainer1.Size = New System.Drawing.Size(794, 493)
        Me.SplitContainer1.SplitterDistance = 243
        Me.SplitContainer1.TabIndex = 12
        '
        'colCallFolowingID
        '
        Me.colCallFolowingID.DataPropertyName = "CallFolowingID"
        Me.colCallFolowingID.HeaderText = "كد"
        Me.colCallFolowingID.Name = "colCallFolowingID"
        Me.colCallFolowingID.ReadOnly = True
        '
        'colCallID
        '
        Me.colCallID.DataPropertyName = "CallID"
        Me.colCallID.HeaderText = "كد پيگيري کارتابل"
        Me.colCallID.Name = "colCallID"
        Me.colCallID.ReadOnly = True
        Me.colCallID.Width = 150
        '
        'colCompleted
        '
        Me.colCompleted.DataPropertyName = "Completed"
        Me.colCompleted.HeaderText = "وضعيت"
        Me.colCompleted.Name = "colCompleted"
        Me.colCompleted.ReadOnly = True
        '
        'colResponsDesc
        '
        Me.colResponsDesc.DataPropertyName = "ResponsDesc"
        Me.colResponsDesc.HeaderText = "شرح كار انجام شده"
        Me.colResponsDesc.Name = "colResponsDesc"
        Me.colResponsDesc.ReadOnly = True
        Me.colResponsDesc.Width = 130
        '
        'colResponseDate_vc
        '
        Me.colResponseDate_vc.DataPropertyName = "ResponseDate_vc"
        Me.colResponseDate_vc.HeaderText = "تاريخ"
        Me.colResponseDate_vc.Name = "colResponseDate_vc"
        Me.colResponseDate_vc.ReadOnly = True
        '
        'colResponseTime_vc
        '
        Me.colResponseTime_vc.DataPropertyName = "ResponseTime_vc"
        Me.colResponseTime_vc.HeaderText = "ساعت"
        Me.colResponseTime_vc.Name = "colResponseTime_vc"
        Me.colResponseTime_vc.ReadOnly = True
        '
        'colDescription
        '
        Me.colDescription.DataPropertyName = "Description_nvc"
        Me.colDescription.HeaderText = "colDescription"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.ReadOnly = True
        Me.colDescription.Visible = False
        '
        'frmCallsFolowing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 518)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCallsFolowing"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tbpCallsInfoNotComp.ResumeLayout(False)
        Me.grpGrid.ResumeLayout(False)
        CType(Me.dgvCallsInfoNComp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpCallsInfoComp.ResumeLayout(False)
        Me.grpGrid2.ResumeLayout(False)
        CType(Me.dgvCallsInfoComp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCallsFolowing.ResumeLayout(False)
        Me.grpCallsFolowing.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
        CType(Me.dgvCallsFolowing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbpCallsInfoNotComp As System.Windows.Forms.TabPage
    Friend WithEvents grpCallsFolowing As System.Windows.Forms.GroupBox
    Friend WithEvents txtResponseTime_vc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtNotCompleted As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCompleted As System.Windows.Forms.RadioButton
    Friend WithEvents btnResDesc As System.Windows.Forms.Button
    Friend WithEvents txtResponsDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCallID As System.Windows.Forms.TextBox
    Friend WithEvents ق As System.Windows.Forms.Label
    Friend WithEvents grpGrid As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCallsInfoNComp As System.Windows.Forms.DataGridView
    Friend WithEvents tbpCallsInfoComp As System.Windows.Forms.TabPage
    Friend WithEvents grpGrid2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCallsInfoComp As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCallsFolowing As System.Windows.Forms.DataGridView
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
    Friend WithEvents txtCallFolowingID As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtResponseDate_vc As DateTextBox.DateTextBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPDF As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents colCallFolowingID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCallID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCompleted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResponsDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResponseDate_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResponseTime_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescription As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
