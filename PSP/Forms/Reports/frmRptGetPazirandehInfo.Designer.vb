<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptGetPazirandehInfo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtImportPath = New System.Windows.Forms.TextBox()
        Me.txtExportPath = New System.Windows.Forms.TextBox()
        Me.prgbar = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBrowseImport = New System.Windows.Forms.Button()
        Me.rdoPayaneh = New System.Windows.Forms.RadioButton()
        Me.rdoSerial = New System.Windows.Forms.RadioButton()
        Me.rdoEniacCode = New System.Windows.Forms.RadioButton()
        Me.btnBrowseExport = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(540, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "مسیر فایل ورودی :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(539, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "مسیر فایل خروجی :"
        '
        'txtImportPath
        '
        Me.txtImportPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImportPath.Location = New System.Drawing.Point(45, 21)
        Me.txtImportPath.Name = "txtImportPath"
        Me.txtImportPath.Size = New System.Drawing.Size(493, 21)
        Me.txtImportPath.TabIndex = 2
        '
        'txtExportPath
        '
        Me.txtExportPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExportPath.Location = New System.Drawing.Point(44, 14)
        Me.txtExportPath.Name = "txtExportPath"
        Me.txtExportPath.Size = New System.Drawing.Size(493, 21)
        Me.txtExportPath.TabIndex = 3
        '
        'prgbar
        '
        Me.prgbar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgbar.Location = New System.Drawing.Point(4, 122)
        Me.prgbar.Name = "prgbar"
        Me.prgbar.Size = New System.Drawing.Size(644, 11)
        Me.prgbar.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnBrowseImport)
        Me.GroupBox1.Controls.Add(Me.rdoPayaneh)
        Me.GroupBox1.Controls.Add(Me.rdoSerial)
        Me.GroupBox1.Controls.Add(Me.rdoEniacCode)
        Me.GroupBox1.Controls.Add(Me.txtImportPath)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(644, 70)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'btnBrowseImport
        '
        Me.btnBrowseImport.Location = New System.Drawing.Point(6, 20)
        Me.btnBrowseImport.Name = "btnBrowseImport"
        Me.btnBrowseImport.Size = New System.Drawing.Size(31, 23)
        Me.btnBrowseImport.TabIndex = 6
        Me.btnBrowseImport.Text = "..."
        Me.btnBrowseImport.UseVisualStyleBackColor = True
        '
        'rdoPayaneh
        '
        Me.rdoPayaneh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoPayaneh.AutoSize = True
        Me.rdoPayaneh.Location = New System.Drawing.Point(134, 47)
        Me.rdoPayaneh.Name = "rdoPayaneh"
        Me.rdoPayaneh.Size = New System.Drawing.Size(60, 17)
        Me.rdoPayaneh.TabIndex = 5
        Me.rdoPayaneh.Text = "کد پایانه"
        Me.rdoPayaneh.UseVisualStyleBackColor = True
        '
        'rdoSerial
        '
        Me.rdoSerial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoSerial.AutoSize = True
        Me.rdoSerial.Location = New System.Drawing.Point(285, 47)
        Me.rdoSerial.Name = "rdoSerial"
        Me.rdoSerial.Size = New System.Drawing.Size(54, 17)
        Me.rdoSerial.TabIndex = 4
        Me.rdoSerial.Text = "سریال"
        Me.rdoSerial.UseVisualStyleBackColor = True
        '
        'rdoEniacCode
        '
        Me.rdoEniacCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoEniacCode.AutoSize = True
        Me.rdoEniacCode.Checked = True
        Me.rdoEniacCode.Location = New System.Drawing.Point(445, 47)
        Me.rdoEniacCode.Name = "rdoEniacCode"
        Me.rdoEniacCode.Size = New System.Drawing.Size(71, 17)
        Me.rdoEniacCode.TabIndex = 3
        Me.rdoEniacCode.TabStop = True
        Me.rdoEniacCode.Text = "کد پیگیری"
        Me.rdoEniacCode.UseVisualStyleBackColor = True
        '
        'btnBrowseExport
        '
        Me.btnBrowseExport.Location = New System.Drawing.Point(7, 12)
        Me.btnBrowseExport.Name = "btnBrowseExport"
        Me.btnBrowseExport.Size = New System.Drawing.Size(31, 23)
        Me.btnBrowseExport.TabIndex = 7
        Me.btnBrowseExport.Text = "..."
        Me.btnBrowseExport.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnBrowseExport)
        Me.GroupBox2.Controls.Add(Me.txtExportPath)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(644, 42)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(4, 139)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 9
        Me.btnExport.Text = "تایید"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmRptGetPazirandehInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 167)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.prgbar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRptGetPazirandehInfo"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtImportPath As System.Windows.Forms.TextBox
    Friend WithEvents txtExportPath As System.Windows.Forms.TextBox
    Friend WithEvents prgbar As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPayaneh As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSerial As System.Windows.Forms.RadioButton
    Friend WithEvents rdoEniacCode As System.Windows.Forms.RadioButton
    Friend WithEvents btnBrowseImport As System.Windows.Forms.Button
    Friend WithEvents btnBrowseExport As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
End Class
