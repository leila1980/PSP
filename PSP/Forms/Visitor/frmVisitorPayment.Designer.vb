<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitorPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisitorPayment))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpPaymentDate_vc = New FarsiLibrary.Win.Controls.FADatePickerConverter
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDesc_nvc = New System.Windows.Forms.TextBox
        Me.ntxtPosCount_int = New AMS.TextBox.NumericTextBox
        Me.ntxtPaymentAmount_dc = New AMS.TextBox.NumericTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboVisitor = New System.Windows.Forms.ComboBox
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
        Me.dgvVisitorPayment = New System.Windows.Forms.DataGridView
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPaymentDate_vc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPaymentAmount_dc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPosCount_int = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDesc_nvc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.tsSupplier.SuspendLayout()
        CType(Me.dgvVisitorPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpPaymentDate_vc)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDesc_nvc)
        Me.GroupBox1.Controls.Add(Me.ntxtPosCount_int)
        Me.GroupBox1.Controls.Add(Me.ntxtPaymentAmount_dc)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 352)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 104)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dtpPaymentDate_vc
        '
        Me.dtpPaymentDate_vc.Location = New System.Drawing.Point(319, 16)
        Me.dtpPaymentDate_vc.Name = "dtpPaymentDate_vc"
        Me.dtpPaymentDate_vc.Size = New System.Drawing.Size(120, 20)
        Me.dtpPaymentDate_vc.TabIndex = 17
        Me.dtpPaymentDate_vc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(443, 62)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(17, 21)
        Me.txtID.TabIndex = 16
        Me.txtID.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(242, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "مبلغ پرداخت :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(50, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "تعداد پز"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(441, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "تاریخ پرداخت :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(441, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "توضیحات :"
        '
        'txtDesc_nvc
        '
        Me.txtDesc_nvc.Location = New System.Drawing.Point(17, 43)
        Me.txtDesc_nvc.Multiline = True
        Me.txtDesc_nvc.Name = "txtDesc_nvc"
        Me.txtDesc_nvc.Size = New System.Drawing.Size(422, 56)
        Me.txtDesc_nvc.TabIndex = 11
        '
        'ntxtPosCount_int
        '
        Me.ntxtPosCount_int.AllowNegative = True
        Me.ntxtPosCount_int.DigitsInGroup = 0
        Me.ntxtPosCount_int.Flags = 0
        Me.ntxtPosCount_int.Location = New System.Drawing.Point(17, 13)
        Me.ntxtPosCount_int.MaxDecimalPlaces = 4
        Me.ntxtPosCount_int.MaxWholeDigits = 9
        Me.ntxtPosCount_int.Name = "ntxtPosCount_int"
        Me.ntxtPosCount_int.Prefix = ""
        Me.ntxtPosCount_int.RangeMax = 1.7976931348623157E+308
        Me.ntxtPosCount_int.RangeMin = -1.7976931348623157E+308
        Me.ntxtPosCount_int.Size = New System.Drawing.Size(28, 21)
        Me.ntxtPosCount_int.TabIndex = 10
        Me.ntxtPosCount_int.Text = "1"
        '
        'ntxtPaymentAmount_dc
        '
        Me.ntxtPaymentAmount_dc.AllowNegative = True
        Me.ntxtPaymentAmount_dc.DigitsInGroup = 0
        Me.ntxtPaymentAmount_dc.Flags = 0
        Me.ntxtPaymentAmount_dc.Location = New System.Drawing.Point(100, 17)
        Me.ntxtPaymentAmount_dc.MaxDecimalPlaces = 4
        Me.ntxtPaymentAmount_dc.MaxWholeDigits = 9
        Me.ntxtPaymentAmount_dc.Name = "ntxtPaymentAmount_dc"
        Me.ntxtPaymentAmount_dc.Prefix = ""
        Me.ntxtPaymentAmount_dc.RangeMax = 1.7976931348623157E+308
        Me.ntxtPaymentAmount_dc.RangeMin = -1.7976931348623157E+308
        Me.ntxtPaymentAmount_dc.Size = New System.Drawing.Size(136, 21)
        Me.ntxtPaymentAmount_dc.TabIndex = 9
        Me.ntxtPaymentAmount_dc.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(461, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "نام بازاریاب :"
        '
        'cboVisitor
        '
        Me.cboVisitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitor.FormattingEnabled = True
        Me.cboVisitor.Location = New System.Drawing.Point(117, 35)
        Me.cboVisitor.Name = "cboVisitor"
        Me.cboVisitor.Size = New System.Drawing.Size(343, 21)
        Me.cboVisitor.TabIndex = 0
        '
        'tsSupplier
        '
        Me.tsSupplier.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnEdit, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator3, Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel})
        Me.tsSupplier.Location = New System.Drawing.Point(0, 0)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(531, 25)
        Me.tsSupplier.TabIndex = 11
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
        Me.btnCancel.Size = New System.Drawing.Size(60, 22)
        Me.btnCancel.Text = "انصراف"
        '
        'dgvVisitorPayment
        '
        Me.dgvVisitorPayment.AllowUserToAddRows = False
        Me.dgvVisitorPayment.AllowUserToDeleteRows = False
        Me.dgvVisitorPayment.AllowUserToResizeColumns = False
        Me.dgvVisitorPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVisitorPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colPaymentDate_vc, Me.colPaymentAmount_dc, Me.colPosCount_int, Me.colDesc_nvc})
        Me.dgvVisitorPayment.Location = New System.Drawing.Point(5, 65)
        Me.dgvVisitorPayment.Name = "dgvVisitorPayment"
        Me.dgvVisitorPayment.ReadOnly = True
        Me.dgvVisitorPayment.Size = New System.Drawing.Size(521, 286)
        Me.dgvVisitorPayment.TabIndex = 12
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'colID
        '
        Me.colID.DataPropertyName = "ID"
        Me.colID.HeaderText = "ID"
        Me.colID.MinimumWidth = 2
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 2
        '
        'colPaymentDate_vc
        '
        Me.colPaymentDate_vc.DataPropertyName = "PaymentDate_vc"
        Me.colPaymentDate_vc.HeaderText = "تاریخ پرداخت"
        Me.colPaymentDate_vc.Name = "colPaymentDate_vc"
        Me.colPaymentDate_vc.ReadOnly = True
        '
        'colPaymentAmount_dc
        '
        Me.colPaymentAmount_dc.DataPropertyName = "PaymentAmount_dc"
        Me.colPaymentAmount_dc.HeaderText = "مبلغ پرداخت"
        Me.colPaymentAmount_dc.Name = "colPaymentAmount_dc"
        Me.colPaymentAmount_dc.ReadOnly = True
        '
        'colPosCount_int
        '
        Me.colPosCount_int.DataPropertyName = "PosCount_int"
        Me.colPosCount_int.HeaderText = "تعداد پز"
        Me.colPosCount_int.Name = "colPosCount_int"
        Me.colPosCount_int.ReadOnly = True
        '
        'colDesc_nvc
        '
        Me.colDesc_nvc.DataPropertyName = "Desc_nvc"
        Me.colDesc_nvc.HeaderText = "توضیحات"
        Me.colDesc_nvc.Name = "colDesc_nvc"
        Me.colDesc_nvc.ReadOnly = True
        Me.colDesc_nvc.Width = 140
        '
        'frmVisitorPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 461)
        Me.Controls.Add(Me.dgvVisitorPayment)
        Me.Controls.Add(Me.tsSupplier)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboVisitor)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVisitorPayment"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "پرداخت بازاریابها"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsSupplier.ResumeLayout(False)
        Me.tsSupplier.PerformLayout()
        CType(Me.dgvVisitorPayment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboVisitor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDesc_nvc As System.Windows.Forms.TextBox
    Friend WithEvents ntxtPosCount_int As AMS.TextBox.NumericTextBox
    Friend WithEvents ntxtPaymentAmount_dc As AMS.TextBox.NumericTextBox
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
    Friend WithEvents dgvVisitorPayment As System.Windows.Forms.DataGridView
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents dtpPaymentDate_vc As FarsiLibrary.Win.Controls.FADatePickerConverter
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaymentDate_vc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaymentAmount_dc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPosCount_int As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc_nvc As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
