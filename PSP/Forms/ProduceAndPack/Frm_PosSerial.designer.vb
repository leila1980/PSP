Imports System.Threading

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PosSerials
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PosSerials))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_PartNo = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Cmb_Date = New FarsiLibrary.Win.Controls.FADatePicker()
        Me.Cmb_PM = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Batch = New System.Windows.Forms.TextBox()
        Me.Txt_PN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_EniacCode = New System.Windows.Forms.TextBox()
        Me.Txt_PosSelrial = New System.Windows.Forms.TextBox()
        Me.Txt_PropertyCode = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Ok = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Dgv_Code = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ColEniacCoder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPropertyCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Dgv_Code, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Txt_PartNo)
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.Cmb_Date)
        Me.Panel1.Controls.Add(Me.Cmb_PM)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Txt_Batch)
        Me.Panel1.Controls.Add(Me.Txt_PN)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Txt_EniacCode)
        Me.Panel1.Controls.Add(Me.Txt_PosSelrial)
        Me.Panel1.Controls.Add(Me.Txt_PropertyCode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(697, 150)
        Me.Panel1.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(298, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 14)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "شماره پارت"
        '
        'Txt_PartNo
        '
        Me.Txt_PartNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_PartNo.ForeColor = System.Drawing.Color.Black
        Me.Txt_PartNo.Location = New System.Drawing.Point(108, 90)
        Me.Txt_PartNo.Name = "Txt_PartNo"
        Me.Txt_PartNo.Size = New System.Drawing.Size(184, 22)
        Me.Txt_PartNo.TabIndex = 25
        Me.Txt_PartNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(577, 122)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(29, 14)
        Me.lblDate.TabIndex = 24
        Me.lblDate.Text = "تاریخ"
        '
        'Cmb_Date
        '
        Me.Cmb_Date.Location = New System.Drawing.Point(387, 119)
        Me.Cmb_Date.Name = "Cmb_Date"
        Me.Cmb_Date.Size = New System.Drawing.Size(184, 20)
        Me.Cmb_Date.TabIndex = 23
        Me.Cmb_Date.TextHorizontalAlignment = FarsiLibrary.Win.Enums.TextAlignment.Center
        Me.Cmb_Date.TextVerticalAlignment = FarsiLibrary.Win.Enums.TextAlignment.Center
        '
        'Cmb_PM
        '
        Me.Cmb_PM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cmb_PM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_PM.FormattingEnabled = True
        Me.Cmb_PM.Location = New System.Drawing.Point(108, 62)
        Me.Cmb_PM.Name = "Cmb_PM"
        Me.Cmb_PM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Cmb_PM.Size = New System.Drawing.Size(184, 22)
        Me.Cmb_PM.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(298, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "شماره بچ"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(298, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "PN محصول"
        '
        'Txt_Batch
        '
        Me.Txt_Batch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Batch.ForeColor = System.Drawing.Color.Black
        Me.Txt_Batch.Location = New System.Drawing.Point(108, 118)
        Me.Txt_Batch.Name = "Txt_Batch"
        Me.Txt_Batch.Size = New System.Drawing.Size(184, 22)
        Me.Txt_Batch.TabIndex = 6
        Me.Txt_Batch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_PN
        '
        Me.Txt_PN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_PN.ForeColor = System.Drawing.Color.Black
        Me.Txt_PN.Location = New System.Drawing.Point(108, 35)
        Me.Txt_PN.Name = "Txt_PN"
        Me.Txt_PN.Size = New System.Drawing.Size(184, 22)
        Me.Txt_PN.TabIndex = 4
        Me.Txt_PN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(298, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "مدل دستگاه"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(577, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "کد پیگیری"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(577, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "سریال دستگاه"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(577, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "کد اموال"
        '
        'Txt_EniacCode
        '
        Me.Txt_EniacCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_EniacCode.ForeColor = System.Drawing.Color.Black
        Me.Txt_EniacCode.Location = New System.Drawing.Point(387, 35)
        Me.Txt_EniacCode.Name = "Txt_EniacCode"
        Me.Txt_EniacCode.Size = New System.Drawing.Size(184, 22)
        Me.Txt_EniacCode.TabIndex = 1
        Me.Txt_EniacCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_PosSelrial
        '
        Me.Txt_PosSelrial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_PosSelrial.ForeColor = System.Drawing.Color.Black
        Me.Txt_PosSelrial.Location = New System.Drawing.Point(387, 90)
        Me.Txt_PosSelrial.Name = "Txt_PosSelrial"
        Me.Txt_PosSelrial.Size = New System.Drawing.Size(184, 22)
        Me.Txt_PosSelrial.TabIndex = 3
        Me.Txt_PosSelrial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_PropertyCode
        '
        Me.Txt_PropertyCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_PropertyCode.ForeColor = System.Drawing.Color.Black
        Me.Txt_PropertyCode.Location = New System.Drawing.Point(387, 62)
        Me.Txt_PropertyCode.Name = "Txt_PropertyCode"
        Me.Txt_PropertyCode.Size = New System.Drawing.Size(184, 22)
        Me.Txt_PropertyCode.TabIndex = 2
        Me.Txt_PropertyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Btn_Cancel)
        Me.Panel2.Controls.Add(Me.Btn_Ok)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 359)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(697, 52)
        Me.Panel2.TabIndex = 1
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Image = CType(resources.GetObject("Btn_Cancel.Image"), System.Drawing.Image)
        Me.Btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Cancel.Location = New System.Drawing.Point(108, 15)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(88, 23)
        Me.Btn_Cancel.TabIndex = 8
        Me.Btn_Cancel.Text = "انصـــراف"
        Me.Btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Btn_Ok
        '
        Me.Btn_Ok.Image = CType(resources.GetObject("Btn_Ok.Image"), System.Drawing.Image)
        Me.Btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Ok.Location = New System.Drawing.Point(204, 15)
        Me.Btn_Ok.Name = "Btn_Ok"
        Me.Btn_Ok.Size = New System.Drawing.Size(88, 23)
        Me.Btn_Ok.TabIndex = 7
        Me.Btn_Ok.Text = "تاییــــــد"
        Me.Btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Ok.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Dgv_Code)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 150)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(697, 209)
        Me.Panel3.TabIndex = 2
        '
        'Dgv_Code
        '
        Me.Dgv_Code.AllowUserToAddRows = False
        Me.Dgv_Code.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        Me.Dgv_Code.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv_Code.BackgroundColor = System.Drawing.SystemColors.ControlDark
        Me.Dgv_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Dgv_Code.ColumnHeadersHeight = 30
        Me.Dgv_Code.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColEniacCoder, Me.ColPropertyCode, Me.ColSerial, Me.ColPM, Me.ColPN, Me.ColBatchNo, Me.ColPartNo})
        Me.Dgv_Code.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Code.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Code.MultiSelect = False
        Me.Dgv_Code.Name = "Dgv_Code"
        Me.Dgv_Code.ReadOnly = True
        Me.Dgv_Code.RowHeadersWidth = 5
        Me.Dgv_Code.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv_Code.Size = New System.Drawing.Size(693, 205)
        Me.Dgv_Code.TabIndex = 2
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'ColEniacCoder
        '
        Me.ColEniacCoder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColEniacCoder.DataPropertyName = "EniacCode_vc"
        Me.ColEniacCoder.HeaderText = "کد پیگیری"
        Me.ColEniacCoder.Name = "ColEniacCoder"
        Me.ColEniacCoder.ReadOnly = True
        Me.ColEniacCoder.Width = 81
        '
        'ColPropertyCode
        '
        Me.ColPropertyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColPropertyCode.DataPropertyName = "TempPropertyNo_vc"
        Me.ColPropertyCode.HeaderText = "کد اموال"
        Me.ColPropertyCode.Name = "ColPropertyCode"
        Me.ColPropertyCode.ReadOnly = True
        Me.ColPropertyCode.Width = 74
        '
        'ColSerial
        '
        Me.ColSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColSerial.HeaderText = "سریال دستگاه"
        Me.ColSerial.Name = "ColSerial"
        Me.ColSerial.ReadOnly = True
        Me.ColSerial.Width = 106
        '
        'ColPM
        '
        Me.ColPM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColPM.HeaderText = "مدل دستگاه"
        Me.ColPM.Name = "ColPM"
        Me.ColPM.ReadOnly = True
        Me.ColPM.Width = 95
        '
        'ColPN
        '
        Me.ColPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColPN.HeaderText = "PN دستگاه"
        Me.ColPN.Name = "ColPN"
        Me.ColPN.ReadOnly = True
        Me.ColPN.Width = 89
        '
        'ColBatchNo
        '
        Me.ColBatchNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColBatchNo.HeaderText = "شماره بچ"
        Me.ColBatchNo.Name = "ColBatchNo"
        Me.ColBatchNo.ReadOnly = True
        Me.ColBatchNo.Width = 80
        '
        'ColPartNo
        '
        Me.ColPartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColPartNo.DataPropertyName = "PartNo_int"
        Me.ColPartNo.HeaderText = "شماره پارت"
        Me.ColPartNo.Name = "ColPartNo"
        Me.ColPartNo.ReadOnly = True
        Me.ColPartNo.Width = 90
        '
        'Frm_PosSerials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 411)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_PosSerials"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الصاق کد ها بهPos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.Dgv_Code, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Txt_EniacCode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PosSelrial As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PropertyCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Btn_Ok As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_PN As System.Windows.Forms.TextBox
    Friend WithEvents Cmb_PM As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_Batch As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Dgv_Code As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Private WithEvents lblDate As System.Windows.Forms.Label
    Private WithEvents Cmb_Date As FarsiLibrary.Win.Controls.FADatePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_PartNo As System.Windows.Forms.TextBox
    Friend WithEvents ColEniacCoder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPropertyCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSerial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPartNo As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
