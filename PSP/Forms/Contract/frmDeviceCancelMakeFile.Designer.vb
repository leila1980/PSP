<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeviceCancelMakeFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeviceCancelMakeFile))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdoNotSent = New System.Windows.Forms.RadioButton
        Me.rdoAll = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvDeviceCancel = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnmakeFile = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSendToExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.btnSelectAll = New System.Windows.Forms.ToolStripButton
        Me.btnUnSelect = New System.Windows.Forms.ToolStripButton
        Me.InventSelect = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvDeviceCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoNotSent)
        Me.GroupBox1.Controls.Add(Me.rdoAll)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(759, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rdoNotSent
        '
        Me.rdoNotSent.AutoSize = True
        Me.rdoNotSent.Location = New System.Drawing.Point(468, 19)
        Me.rdoNotSent.Name = "rdoNotSent"
        Me.rdoNotSent.Size = New System.Drawing.Size(96, 17)
        Me.rdoNotSent.TabIndex = 1
        Me.rdoNotSent.TabStop = True
        Me.rdoNotSent.Text = "ارسال نشده ها"
        Me.rdoNotSent.UseVisualStyleBackColor = True
        '
        'rdoAll
        '
        Me.rdoAll.AutoSize = True
        Me.rdoAll.Location = New System.Drawing.Point(641, 19)
        Me.rdoAll.Name = "rdoAll"
        Me.rdoAll.Size = New System.Drawing.Size(46, 17)
        Me.rdoAll.TabIndex = 0
        Me.rdoAll.TabStop = True
        Me.rdoAll.Text = "همه"
        Me.rdoAll.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvDeviceCancel)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(759, 421)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'dgvDeviceCancel
        '
        Me.dgvDeviceCancel.AllowUserToAddRows = False
        Me.dgvDeviceCancel.AllowUserToDeleteRows = False
        Me.dgvDeviceCancel.AllowUserToResizeRows = False
        Me.dgvDeviceCancel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDeviceCancel.Location = New System.Drawing.Point(19, 20)
        Me.dgvDeviceCancel.MultiSelect = False
        Me.dgvDeviceCancel.Name = "dgvDeviceCancel"
        Me.dgvDeviceCancel.Size = New System.Drawing.Size(724, 392)
        Me.dgvDeviceCancel.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnmakeFile, Me.ToolStripSeparator1, Me.btnSendToExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(783, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnmakeFile
        '
        Me.btnmakeFile.Image = CType(resources.GetObject("btnmakeFile.Image"), System.Drawing.Image)
        Me.btnmakeFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnmakeFile.Name = "btnmakeFile"
        Me.btnmakeFile.Size = New System.Drawing.Size(70, 22)
        Me.btnmakeFile.Text = "تولید فایل"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnSendToExcel
        '
        Me.btnSendToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSendToExcel.Image = CType(resources.GetObject("btnSendToExcel.Image"), System.Drawing.Image)
        Me.btnSendToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSendToExcel.Name = "btnSendToExcel"
        Me.btnSendToExcel.Size = New System.Drawing.Size(79, 22)
        Me.btnSendToExcel.Text = "ارسال به Excel"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSelectAll, Me.btnUnSelect, Me.InventSelect})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 511)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(783, 25)
        Me.ToolStrip2.TabIndex = 4
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Image = CType(resources.GetObject("btnSelectAll.Image"), System.Drawing.Image)
        Me.btnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(80, 22)
        Me.btnSelectAll.Text = "انتخاب همه"
        '
        'btnUnSelect
        '
        Me.btnUnSelect.Image = CType(resources.GetObject("btnUnSelect.Image"), System.Drawing.Image)
        Me.btnUnSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUnSelect.Name = "btnUnSelect"
        Me.btnUnSelect.Size = New System.Drawing.Size(87, 22)
        Me.btnUnSelect.Text = "لغو انتخاب ها"
        '
        'InventSelect
        '
        Me.InventSelect.Image = CType(resources.GetObject("InventSelect.Image"), System.Drawing.Image)
        Me.InventSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InventSelect.Name = "InventSelect"
        Me.InventSelect.Size = New System.Drawing.Size(95, 22)
        Me.InventSelect.Text = "معکوس انتخاب"
        '
        'frmDeviceCancelMakeFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 536)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeviceCancelMakeFile"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "فسخ پز - تولید فایل"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvDeviceCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNotSent As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAll As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnmakeFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvDeviceCancel As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSelectAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUnSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents InventSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSendToExcel As System.Windows.Forms.ToolStripButton
End Class
