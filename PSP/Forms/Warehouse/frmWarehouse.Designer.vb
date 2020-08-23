<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWarehouse
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvStatements = New System.Windows.Forms.DataGridView()
        Me.statementno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_vc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.projecttitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.account = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivery = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statementtype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.createdby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.warehouseStatement_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statementTypecb = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.statementNotxt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.serialtxt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvSerials = New System.Windows.Forms.DataGridView()
        Me.wsSerials = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvWarehouse = New System.Windows.Forms.DataGridView()
        Me.WSGood_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WSGoodName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WSGoodCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvStatements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSerials, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWarehouse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvStatements
        '
        Me.dgvStatements.AllowUserToAddRows = False
        Me.dgvStatements.AllowUserToDeleteRows = False
        Me.dgvStatements.AllowUserToOrderColumns = True
        Me.dgvStatements.AllowUserToResizeRows = False
        Me.dgvStatements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStatements.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.statementno, Me.date_vc, Me.projecttitle, Me.account, Me.delivery, Me.statementtype, Me.reason, Me.createdby, Me.warehouseStatement_ID})
        Me.dgvStatements.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStatements.Location = New System.Drawing.Point(3, 16)
        Me.dgvStatements.Name = "dgvStatements"
        Me.dgvStatements.ReadOnly = True
        Me.dgvStatements.RowHeadersVisible = False
        Me.dgvStatements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStatements.Size = New System.Drawing.Size(997, 222)
        Me.dgvStatements.TabIndex = 0
        '
        'statementno
        '
        Me.statementno.DataPropertyName = "statementno"
        Me.statementno.HeaderText = "شماره سند"
        Me.statementno.Name = "statementno"
        Me.statementno.ReadOnly = True
        Me.statementno.Width = 90
        '
        'date_vc
        '
        Me.date_vc.DataPropertyName = "date_vc"
        Me.date_vc.HeaderText = "تاریخ"
        Me.date_vc.Name = "date_vc"
        Me.date_vc.ReadOnly = True
        Me.date_vc.Width = 70
        '
        'projecttitle
        '
        Me.projecttitle.DataPropertyName = "projecttitle"
        Me.projecttitle.HeaderText = "پروژه"
        Me.projecttitle.Name = "projecttitle"
        Me.projecttitle.ReadOnly = True
        '
        'account
        '
        Me.account.DataPropertyName = "account"
        Me.account.HeaderText = "طرف حساب"
        Me.account.Name = "account"
        Me.account.ReadOnly = True
        Me.account.Width = 170
        '
        'delivery
        '
        Me.delivery.DataPropertyName = "delivery"
        Me.delivery.HeaderText = "تحویل گیرنده"
        Me.delivery.Name = "delivery"
        Me.delivery.ReadOnly = True
        Me.delivery.Width = 170
        '
        'statementtype
        '
        Me.statementtype.DataPropertyName = "statementtype"
        Me.statementtype.HeaderText = "نوع سند"
        Me.statementtype.Name = "statementtype"
        Me.statementtype.ReadOnly = True
        Me.statementtype.Width = 70
        '
        'reason
        '
        Me.reason.DataPropertyName = "reason"
        Me.reason.HeaderText = "علت سند"
        Me.reason.Name = "reason"
        Me.reason.ReadOnly = True
        Me.reason.Width = 150
        '
        'createdby
        '
        Me.createdby.DataPropertyName = "createdby"
        Me.createdby.HeaderText = "ایجاد شده توسط"
        Me.createdby.Name = "createdby"
        Me.createdby.ReadOnly = True
        Me.createdby.Width = 170
        '
        'warehouseStatement_ID
        '
        Me.warehouseStatement_ID.DataPropertyName = "warehousestatement_id"
        Me.warehouseStatement_ID.HeaderText = "warehouseStatement_ID"
        Me.warehouseStatement_ID.Name = "warehouseStatement_ID"
        Me.warehouseStatement_ID.ReadOnly = True
        Me.warehouseStatement_ID.Visible = False
        '
        'statementTypecb
        '
        Me.statementTypecb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.statementTypecb.FormattingEnabled = True
        Me.statementTypecb.Items.AddRange(New Object() {"تمام اسناد", "حواله", "رسید"})
        Me.statementTypecb.Location = New System.Drawing.Point(276, 14)
        Me.statementTypecb.Name = "statementTypecb"
        Me.statementTypecb.Size = New System.Drawing.Size(149, 21)
        Me.statementTypecb.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "شماره سند"
        '
        'statementNotxt
        '
        Me.statementNotxt.Location = New System.Drawing.Point(75, 14)
        Me.statementNotxt.Name = "statementNotxt"
        Me.statementNotxt.Size = New System.Drawing.Size(127, 20)
        Me.statementNotxt.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(225, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "نوع سند"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvStatements)
        Me.GroupBox1.Location = New System.Drawing.Point(-2, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1003, 241)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "اسناد انبار"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.serialtxt)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dgvSerials)
        Me.GroupBox2.Controls.Add(Me.dgvWarehouse)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 285)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1004, 264)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "وضعیت انبار"
        '
        'serialtxt
        '
        Me.serialtxt.Location = New System.Drawing.Point(478, 19)
        Me.serialtxt.Name = "serialtxt"
        Me.serialtxt.Size = New System.Drawing.Size(127, 20)
        Me.serialtxt.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(611, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "سریال"
        '
        'dgvSerials
        '
        Me.dgvSerials.AllowUserToAddRows = False
        Me.dgvSerials.AllowUserToDeleteRows = False
        Me.dgvSerials.AllowUserToResizeColumns = False
        Me.dgvSerials.AllowUserToResizeRows = False
        Me.dgvSerials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSerials.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.wsSerials})
        Me.dgvSerials.Location = New System.Drawing.Point(295, 13)
        Me.dgvSerials.Name = "dgvSerials"
        Me.dgvSerials.ReadOnly = True
        Me.dgvSerials.RowHeadersVisible = False
        Me.dgvSerials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSerials.Size = New System.Drawing.Size(162, 245)
        Me.dgvSerials.TabIndex = 1
        '
        'wsSerials
        '
        Me.wsSerials.DataPropertyName = "serial_vc"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.wsSerials.DefaultCellStyle = DataGridViewCellStyle1
        Me.wsSerials.HeaderText = "سریال"
        Me.wsSerials.Name = "wsSerials"
        Me.wsSerials.ReadOnly = True
        Me.wsSerials.Width = 150
        '
        'dgvWarehouse
        '
        Me.dgvWarehouse.AllowUserToAddRows = False
        Me.dgvWarehouse.AllowUserToDeleteRows = False
        Me.dgvWarehouse.AllowUserToResizeColumns = False
        Me.dgvWarehouse.AllowUserToResizeRows = False
        Me.dgvWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWarehouse.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WSGood_ID, Me.WSGoodName, Me.WSGoodCount})
        Me.dgvWarehouse.Location = New System.Drawing.Point(666, 16)
        Me.dgvWarehouse.Name = "dgvWarehouse"
        Me.dgvWarehouse.ReadOnly = True
        Me.dgvWarehouse.RowHeadersVisible = False
        Me.dgvWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWarehouse.Size = New System.Drawing.Size(335, 245)
        Me.dgvWarehouse.TabIndex = 0
        '
        'WSGood_ID
        '
        Me.WSGood_ID.DataPropertyName = "good_id"
        Me.WSGood_ID.HeaderText = "کد کالا"
        Me.WSGood_ID.Name = "WSGood_ID"
        Me.WSGood_ID.ReadOnly = True
        Me.WSGood_ID.Width = 80
        '
        'WSGoodName
        '
        Me.WSGoodName.DataPropertyName = "name_nvc"
        Me.WSGoodName.HeaderText = "نام کالا"
        Me.WSGoodName.Name = "WSGoodName"
        Me.WSGoodName.ReadOnly = True
        Me.WSGoodName.Width = 150
        '
        'WSGoodCount
        '
        Me.WSGoodCount.DataPropertyName = "totalcount"
        Me.WSGoodCount.HeaderText = "تعداد"
        Me.WSGoodCount.Name = "WSGoodCount"
        Me.WSGoodCount.ReadOnly = True
        Me.WSGoodCount.Width = 80
        '
        'frmWarehouse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 549)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.statementNotxt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.statementTypecb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWarehouse"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "مرور اسناد"
        CType(Me.dgvStatements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvSerials, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWarehouse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statementTypecb As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents statementNotxt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvStatements As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents statementno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents date_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents projecttitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents account As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents delivery As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents statementtype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents createdby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents warehouseStatement_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvWarehouse As System.Windows.Forms.DataGridView
    Friend WithEvents WSGood_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WSGoodName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WSGoodCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvSerials As System.Windows.Forms.DataGridView
    Friend WithEvents wsSerials As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serialtxt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
