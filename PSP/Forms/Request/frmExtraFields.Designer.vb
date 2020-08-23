<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtraFields
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExtraFields))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCMSProject = New System.Windows.Forms.CheckedListBox()
        Me.grpAvailable = New System.Windows.Forms.GroupBox()
        Me.txtAvailableContractID = New AMS.TextBox.NumericTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpNew = New System.Windows.Forms.GroupBox()
        Me.lblSGroupID = New System.Windows.Forms.LinkLabel()
        Me.cboSGroupID = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtContractNo_vc = New System.Windows.Forms.TextBox()
        Me.lblSSIdentityTypeID = New System.Windows.Forms.LinkLabel()
        Me.cboCityID = New System.Windows.Forms.ComboBox()
        Me.cboStateID = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboSSIdentityTypeID = New System.Windows.Forms.ComboBox()
        Me.dtxtDate_vc = New DateTextBox.DateTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCIdentityTypeID = New System.Windows.Forms.LinkLabel()
        Me.cboCIdentityTypeID = New System.Windows.Forms.ComboBox()
        Me.rdoNewContract = New System.Windows.Forms.RadioButton()
        Me.rdoAvailableContract = New System.Windows.Forms.RadioButton()
        Me.erp = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpAvailable.SuspendLayout()
        Me.grpNew.SuspendLayout()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator6, Me.btnCancel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(361, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCMSProject)
        Me.GroupBox1.Controls.Add(Me.grpAvailable)
        Me.GroupBox1.Controls.Add(Me.grpNew)
        Me.GroupBox1.Controls.Add(Me.rdoNewContract)
        Me.GroupBox1.Controls.Add(Me.rdoAvailableContract)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(361, 353)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkCMSProject
        '
        Me.chkCMSProject.FormattingEnabled = True
        Me.chkCMSProject.Location = New System.Drawing.Point(22, 251)
        Me.chkCMSProject.Name = "chkCMSProject"
        Me.chkCMSProject.Size = New System.Drawing.Size(185, 52)
        Me.chkCMSProject.TabIndex = 20
        '
        'grpAvailable
        '
        Me.grpAvailable.Controls.Add(Me.txtAvailableContractID)
        Me.grpAvailable.Controls.Add(Me.Label1)
        Me.grpAvailable.Location = New System.Drawing.Point(22, 309)
        Me.grpAvailable.Name = "grpAvailable"
        Me.grpAvailable.Size = New System.Drawing.Size(322, 40)
        Me.grpAvailable.TabIndex = 19
        Me.grpAvailable.TabStop = False
        '
        'txtAvailableContractID
        '
        Me.txtAvailableContractID.AllowNegative = True
        Me.txtAvailableContractID.DigitsInGroup = 0
        Me.txtAvailableContractID.Flags = 0
        Me.txtAvailableContractID.Location = New System.Drawing.Point(98, 13)
        Me.txtAvailableContractID.MaxDecimalPlaces = 4
        Me.txtAvailableContractID.MaxWholeDigits = 9
        Me.txtAvailableContractID.Name = "txtAvailableContractID"
        Me.txtAvailableContractID.Prefix = ""
        Me.txtAvailableContractID.RangeMax = 1.7976931348623157E+308R
        Me.txtAvailableContractID.RangeMin = -1.7976931348623157E+308R
        Me.txtAvailableContractID.Size = New System.Drawing.Size(94, 21)
        Me.txtAvailableContractID.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "کد قرارداد :"
        '
        'grpNew
        '
        Me.grpNew.Controls.Add(Me.lblSGroupID)
        Me.grpNew.Controls.Add(Me.cboSGroupID)
        Me.grpNew.Controls.Add(Me.Label6)
        Me.grpNew.Controls.Add(Me.txtContractNo_vc)
        Me.grpNew.Controls.Add(Me.lblSSIdentityTypeID)
        Me.grpNew.Controls.Add(Me.cboCityID)
        Me.grpNew.Controls.Add(Me.cboStateID)
        Me.grpNew.Controls.Add(Me.Label10)
        Me.grpNew.Controls.Add(Me.Label9)
        Me.grpNew.Controls.Add(Me.cboSSIdentityTypeID)
        Me.grpNew.Controls.Add(Me.dtxtDate_vc)
        Me.grpNew.Controls.Add(Me.Label2)
        Me.grpNew.Controls.Add(Me.lblCIdentityTypeID)
        Me.grpNew.Controls.Add(Me.cboCIdentityTypeID)
        Me.grpNew.Location = New System.Drawing.Point(22, 25)
        Me.grpNew.Name = "grpNew"
        Me.grpNew.Size = New System.Drawing.Size(322, 218)
        Me.grpNew.TabIndex = 18
        Me.grpNew.TabStop = False
        '
        'lblSGroupID
        '
        Me.lblSGroupID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSGroupID.AutoSize = True
        Me.lblSGroupID.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblSGroupID.LinkColor = System.Drawing.Color.Orchid
        Me.lblSGroupID.Location = New System.Drawing.Point(188, 186)
        Me.lblSGroupID.Name = "lblSGroupID"
        Me.lblSGroupID.Size = New System.Drawing.Size(37, 13)
        Me.lblSGroupID.TabIndex = 12
        Me.lblSGroupID.TabStop = True
        Me.lblSGroupID.Text = "صنف :"
        '
        'cboSGroupID
        '
        Me.cboSGroupID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSGroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSGroupID.FormattingEnabled = True
        Me.cboSGroupID.Location = New System.Drawing.Point(6, 182)
        Me.cboSGroupID.Name = "cboSGroupID"
        Me.cboSGroupID.Size = New System.Drawing.Size(179, 21)
        Me.cboSGroupID.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(185, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "شماره قرارداد :"
        '
        'txtContractNo_vc
        '
        Me.txtContractNo_vc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContractNo_vc.BackColor = System.Drawing.Color.White
        Me.txtContractNo_vc.Location = New System.Drawing.Point(98, 47)
        Me.txtContractNo_vc.Name = "txtContractNo_vc"
        Me.txtContractNo_vc.Size = New System.Drawing.Size(87, 21)
        Me.txtContractNo_vc.TabIndex = 3
        Me.txtContractNo_vc.TabStop = False
        '
        'lblSSIdentityTypeID
        '
        Me.lblSSIdentityTypeID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSSIdentityTypeID.AutoSize = True
        Me.lblSSIdentityTypeID.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblSSIdentityTypeID.LinkColor = System.Drawing.Color.Orchid
        Me.lblSSIdentityTypeID.Location = New System.Drawing.Point(185, 106)
        Me.lblSSIdentityTypeID.Name = "lblSSIdentityTypeID"
        Me.lblSSIdentityTypeID.Size = New System.Drawing.Size(132, 13)
        Me.lblSSIdentityTypeID.TabIndex = 6
        Me.lblSSIdentityTypeID.TabStop = True
        Me.lblSSIdentityTypeID.Text = "مدرک شناسایی فروشگاه :"
        '
        'cboCityID
        '
        Me.cboCityID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCityID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCityID.FormattingEnabled = True
        Me.cboCityID.Location = New System.Drawing.Point(6, 155)
        Me.cboCityID.Name = "cboCityID"
        Me.cboCityID.Size = New System.Drawing.Size(179, 21)
        Me.cboCityID.TabIndex = 11
        '
        'cboStateID
        '
        Me.cboStateID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStateID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStateID.FormattingEnabled = True
        Me.cboStateID.Location = New System.Drawing.Point(6, 130)
        Me.cboStateID.Name = "cboStateID"
        Me.cboStateID.Size = New System.Drawing.Size(179, 21)
        Me.cboStateID.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(186, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "استان محل سکونت :"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(186, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "شهر محل سکونت :"
        '
        'cboSSIdentityTypeID
        '
        Me.cboSSIdentityTypeID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSSIdentityTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSSIdentityTypeID.FormattingEnabled = True
        Me.cboSSIdentityTypeID.Location = New System.Drawing.Point(6, 103)
        Me.cboSSIdentityTypeID.Name = "cboSSIdentityTypeID"
        Me.cboSSIdentityTypeID.Size = New System.Drawing.Size(179, 21)
        Me.cboSSIdentityTypeID.TabIndex = 7
        '
        'dtxtDate_vc
        '
        Me.dtxtDate_vc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtxtDate_vc.AutoSize = True
        Me.dtxtDate_vc.BackColor = System.Drawing.SystemColors.MenuBar
        Me.dtxtDate_vc.DateBackColor = System.Drawing.SystemColors.Window
        Me.dtxtDate_vc.DateForeColor = System.Drawing.SystemColors.WindowText
        Me.dtxtDate_vc.DateReadOnly = False
        Me.dtxtDate_vc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dtxtDate_vc.Location = New System.Drawing.Point(98, 21)
        Me.dtxtDate_vc.Name = "dtxtDate_vc"
        Me.dtxtDate_vc.Size = New System.Drawing.Size(87, 20)
        Me.dtxtDate_vc.TabIndex = 1
        Me.dtxtDate_vc.Value = ""
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(188, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "تاریخ عقد قرارداد :"
        '
        'lblCIdentityTypeID
        '
        Me.lblCIdentityTypeID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCIdentityTypeID.AutoSize = True
        Me.lblCIdentityTypeID.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblCIdentityTypeID.LinkColor = System.Drawing.Color.Orchid
        Me.lblCIdentityTypeID.Location = New System.Drawing.Point(187, 80)
        Me.lblCIdentityTypeID.Name = "lblCIdentityTypeID"
        Me.lblCIdentityTypeID.Size = New System.Drawing.Size(123, 13)
        Me.lblCIdentityTypeID.TabIndex = 4
        Me.lblCIdentityTypeID.TabStop = True
        Me.lblCIdentityTypeID.Text = "مدرک شناسایی شخص :"
        '
        'cboCIdentityTypeID
        '
        Me.cboCIdentityTypeID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCIdentityTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCIdentityTypeID.FormattingEnabled = True
        Me.cboCIdentityTypeID.Location = New System.Drawing.Point(6, 76)
        Me.cboCIdentityTypeID.Name = "cboCIdentityTypeID"
        Me.cboCIdentityTypeID.Size = New System.Drawing.Size(179, 21)
        Me.cboCIdentityTypeID.TabIndex = 5
        '
        'rdoNewContract
        '
        Me.rdoNewContract.AutoSize = True
        Me.rdoNewContract.Location = New System.Drawing.Point(240, 10)
        Me.rdoNewContract.Name = "rdoNewContract"
        Me.rdoNewContract.Size = New System.Drawing.Size(104, 17)
        Me.rdoNewContract.TabIndex = 17
        Me.rdoNewContract.TabStop = True
        Me.rdoNewContract.Text = "ایجاد قرارداد جدید"
        Me.rdoNewContract.UseVisualStyleBackColor = True
        '
        'rdoAvailableContract
        '
        Me.rdoAvailableContract.AutoSize = True
        Me.rdoAvailableContract.Location = New System.Drawing.Point(253, 251)
        Me.rdoAvailableContract.Name = "rdoAvailableContract"
        Me.rdoAvailableContract.Size = New System.Drawing.Size(86, 17)
        Me.rdoAvailableContract.TabIndex = 16
        Me.rdoAvailableContract.TabStop = True
        Me.rdoAvailableContract.Text = "قرارداد موجود"
        Me.rdoAvailableContract.UseVisualStyleBackColor = True
        '
        'erp
        '
        Me.erp.ContainerControl = Me
        '
        'frmExtraFields
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 378)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "frmExtraFields"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ورود اطلاعات اضافی قراردادها"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpAvailable.ResumeLayout(False)
        Me.grpAvailable.PerformLayout()
        Me.grpNew.ResumeLayout(False)
        Me.grpNew.PerformLayout()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCIdentityTypeID As System.Windows.Forms.LinkLabel
    Friend WithEvents cboCIdentityTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents dtxtDate_vc As DateTextBox.DateTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSSIdentityTypeID As System.Windows.Forms.LinkLabel
    Friend WithEvents cboSSIdentityTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCityID As System.Windows.Forms.ComboBox
    Friend WithEvents cboStateID As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtContractNo_vc As System.Windows.Forms.TextBox
    Friend WithEvents erp As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblSGroupID As System.Windows.Forms.LinkLabel
    Friend WithEvents cboSGroupID As System.Windows.Forms.ComboBox
    Friend WithEvents rdoNewContract As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAvailableContract As System.Windows.Forms.RadioButton
    Friend WithEvents grpAvailable As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpNew As System.Windows.Forms.GroupBox
    Friend WithEvents txtAvailableContractID As AMS.TextBox.NumericTextBox
    Friend WithEvents chkCMSProject As System.Windows.Forms.CheckedListBox
End Class
