<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ProduceCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ProduceCode))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NUD_Count = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_EniacCode = New System.Windows.Forms.TextBox()
        Me.Txt_PropertyCode = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Btn_Ok = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Dgv_Code = New System.Windows.Forms.DataGridView()
        Me.ColEniacCoder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTempPropertyCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.NUD_Count, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Dgv_Code, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.NUD_Count)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Txt_EniacCode)
        Me.Panel1.Controls.Add(Me.Txt_PropertyCode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(474, 82)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(404, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 14)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "تعداد"
        '
        'NUD_Count
        '
        Me.NUD_Count.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NUD_Count.Location = New System.Drawing.Point(332, 27)
        Me.NUD_Count.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NUD_Count.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUD_Count.Name = "NUD_Count"
        Me.NUD_Count.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NUD_Count.Size = New System.Drawing.Size(64, 22)
        Me.NUD_Count.TabIndex = 11
        Me.NUD_Count.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(184, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "کد پیگیری"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(184, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "کد اموال"
        '
        'Txt_EniacCode
        '
        Me.Txt_EniacCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_EniacCode.ForeColor = System.Drawing.Color.Black
        Me.Txt_EniacCode.Location = New System.Drawing.Point(36, 10)
        Me.Txt_EniacCode.Name = "Txt_EniacCode"
        Me.Txt_EniacCode.Size = New System.Drawing.Size(140, 22)
        Me.Txt_EniacCode.TabIndex = 2
        Me.Txt_EniacCode.Text = "0"
        Me.Txt_EniacCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_PropertyCode
        '
        Me.Txt_PropertyCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_PropertyCode.ForeColor = System.Drawing.Color.Black
        Me.Txt_PropertyCode.Location = New System.Drawing.Point(36, 37)
        Me.Txt_PropertyCode.Name = "Txt_PropertyCode"
        Me.Txt_PropertyCode.Size = New System.Drawing.Size(140, 22)
        Me.Txt_PropertyCode.TabIndex = 0
        Me.Txt_PropertyCode.Text = "0"
        Me.Txt_PropertyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Btn_Ok)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 254)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(474, 56)
        Me.Panel2.TabIndex = 3
        '
        'Btn_Ok
        '
        Me.Btn_Ok.Image = CType(resources.GetObject("Btn_Ok.Image"), System.Drawing.Image)
        Me.Btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Ok.Location = New System.Drawing.Point(36, 17)
        Me.Btn_Ok.Name = "Btn_Ok"
        Me.Btn_Ok.Size = New System.Drawing.Size(99, 25)
        Me.Btn_Ok.TabIndex = 0
        Me.Btn_Ok.Text = "چــــــــــــــاپ"
        Me.Btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Ok.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Dgv_Code)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 82)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(474, 172)
        Me.Panel3.TabIndex = 13
        '
        'Dgv_Code
        '
        Me.Dgv_Code.AllowUserToAddRows = False
        Me.Dgv_Code.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        Me.Dgv_Code.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv_Code.BackgroundColor = System.Drawing.SystemColors.ControlDark
        Me.Dgv_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Code.ColumnHeadersHeight = 30
        Me.Dgv_Code.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColEniacCoder, Me.ColTempPropertyCode})
        Me.Dgv_Code.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Code.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Code.MultiSelect = False
        Me.Dgv_Code.Name = "Dgv_Code"
        Me.Dgv_Code.ReadOnly = True
        Me.Dgv_Code.RowHeadersWidth = 10
        Me.Dgv_Code.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Code.Size = New System.Drawing.Size(470, 168)
        Me.Dgv_Code.TabIndex = 1
        '
        'ColEniacCoder
        '
        Me.ColEniacCoder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColEniacCoder.DataPropertyName = "EniacCode_vc"
        Me.ColEniacCoder.HeaderText = "کد پیگیری"
        Me.ColEniacCoder.Name = "ColEniacCoder"
        Me.ColEniacCoder.ReadOnly = True
        '
        'ColTempPropertyCode
        '
        Me.ColTempPropertyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColTempPropertyCode.DataPropertyName = "TempPropertyNo_vc"
        Me.ColTempPropertyCode.HeaderText = "کد اموال"
        Me.ColTempPropertyCode.Name = "ColTempPropertyCode"
        Me.ColTempPropertyCode.ReadOnly = True
        '
        'Frm_ProduceCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 310)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ProduceCode"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تولید و چاپ کد پیگیری و شماره اموال"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NUD_Count, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.Dgv_Code, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_EniacCode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PropertyCode As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Btn_Ok As System.Windows.Forms.Button
    Friend WithEvents NUD_Count As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Code As System.Windows.Forms.DataGridView
    Friend WithEvents ColEniacCoder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTempPropertyCode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
