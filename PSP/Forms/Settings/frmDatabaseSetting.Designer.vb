<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabaseSetting
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.ErrPro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txbDatabaseName1 = New System.Windows.Forms.TextBox
        Me.txbServerName1 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txbUserName1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txbPassword1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.rbtWindowsAuthentication1 = New System.Windows.Forms.RadioButton
        Me.rbtSQLAuthentication1 = New System.Windows.Forms.RadioButton
        Me.txbConnectionTimeout1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.ErrPro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(116, 302)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(77, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "تایید"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(35, 302)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "انصراف"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ErrPro
        '
        Me.ErrPro.ContainerControl = Me
        '
        'txbDatabaseName1
        '
        Me.ErrPro.SetIconAlignment(Me.txbDatabaseName1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txbDatabaseName1.Location = New System.Drawing.Point(179, 53)
        Me.txbDatabaseName1.Name = "txbDatabaseName1"
        Me.txbDatabaseName1.Size = New System.Drawing.Size(184, 21)
        Me.txbDatabaseName1.TabIndex = 3
        '
        'txbServerName1
        '
        Me.ErrPro.SetIconAlignment(Me.txbServerName1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
        Me.txbServerName1.Location = New System.Drawing.Point(179, 22)
        Me.txbServerName1.Name = "txbServerName1"
        Me.txbServerName1.Size = New System.Drawing.Size(184, 21)
        Me.txbServerName1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txbDatabaseName1)
        Me.GroupBox1.Controls.Add(Me.txbServerName1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 88)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(366, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "نام بانک اطلاعاتی :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(367, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "نام سرور بانک اطلاعاتی :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.rbtWindowsAuthentication1)
        Me.GroupBox2.Controls.Add(Me.rbtSQLAuthentication1)
        Me.GroupBox2.Location = New System.Drawing.Point(35, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(499, 150)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txbUserName1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txbPassword1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(165, 37)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 68)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'txbUserName1
        '
        Me.txbUserName1.Location = New System.Drawing.Point(16, 15)
        Me.txbUserName1.Name = "txbUserName1"
        Me.txbUserName1.Size = New System.Drawing.Size(115, 21)
        Me.txbUserName1.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(137, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "رمز کاربر :"
        '
        'txbPassword1
        '
        Me.txbPassword1.Location = New System.Drawing.Point(16, 40)
        Me.txbPassword1.Name = "txbPassword1"
        Me.txbPassword1.Size = New System.Drawing.Size(115, 21)
        Me.txbPassword1.TabIndex = 3
        Me.txbPassword1.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "نام کاربر :"
        '
        'rbtWindowsAuthentication1
        '
        Me.rbtWindowsAuthentication1.AutoSize = True
        Me.rbtWindowsAuthentication1.Location = New System.Drawing.Point(314, 117)
        Me.rbtWindowsAuthentication1.Name = "rbtWindowsAuthentication1"
        Me.rbtWindowsAuthentication1.Size = New System.Drawing.Size(173, 17)
        Me.rbtWindowsAuthentication1.TabIndex = 2
        Me.rbtWindowsAuthentication1.TabStop = True
        Me.rbtWindowsAuthentication1.Text = "دسترسی با سیستم Windows."
        Me.rbtWindowsAuthentication1.UseVisualStyleBackColor = True
        '
        'rbtSQLAuthentication1
        '
        Me.rbtSQLAuthentication1.AutoSize = True
        Me.rbtSQLAuthentication1.Location = New System.Drawing.Point(335, 20)
        Me.rbtSQLAuthentication1.Name = "rbtSQLAuthentication1"
        Me.rbtSQLAuthentication1.Size = New System.Drawing.Size(152, 17)
        Me.rbtSQLAuthentication1.TabIndex = 0
        Me.rbtSQLAuthentication1.TabStop = True
        Me.rbtSQLAuthentication1.Text = "دسترسی با سیستم SQL :"
        Me.rbtSQLAuthentication1.UseVisualStyleBackColor = True
        '
        'txbConnectionTimeout1
        '
        Me.txbConnectionTimeout1.Location = New System.Drawing.Point(424, 269)
        Me.txbConnectionTimeout1.Name = "txbConnectionTimeout1"
        Me.txbConnectionTimeout1.Size = New System.Drawing.Size(42, 21)
        Me.txbConnectionTimeout1.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(392, 272)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "ثانیه"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(472, 272)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "مهلت اتصال:"
        '
        'frmDatabaseSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 342)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txbConnectionTimeout1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDatabaseSetting"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تنظیم بانک اطلاعاتی"
        CType(Me.ErrPro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ErrPro As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txbDatabaseName1 As System.Windows.Forms.TextBox
    Friend WithEvents txbServerName1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txbUserName1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbPassword1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbtWindowsAuthentication1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSQLAuthentication1 As System.Windows.Forms.RadioButton
    Friend WithEvents txbConnectionTimeout1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
