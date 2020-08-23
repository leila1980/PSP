<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoading
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoading))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPosSerial = New System.Windows.Forms.TextBox
        Me.btnLoad = New System.Windows.Forms.Button
        Me.lblCode_vc = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblOutlet_vc = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lblPassword_vc = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblContractID = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnStartListening = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnFinishListening = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cboPortName = New System.Windows.Forms.ToolStripComboBox
        Me.comPort = New System.IO.Ports.SerialPort(Me.components)
        Me.outerTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.slblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPosSerial)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(591, 53)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(411, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "سریال پز را وارد کنید:"
        '
        'txtPosSerial
        '
        Me.txtPosSerial.Location = New System.Drawing.Point(146, 20)
        Me.txtPosSerial.Name = "txtPosSerial"
        Me.txtPosSerial.Size = New System.Drawing.Size(259, 21)
        Me.txtPosSerial.TabIndex = 0
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(12, 311)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(591, 33)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "ثبت بارگذاری"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'lblCode_vc
        '
        Me.lblCode_vc.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCode_vc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCode_vc.Location = New System.Drawing.Point(6, 14)
        Me.lblCode_vc.Name = "lblCode_vc"
        Me.lblCode_vc.Size = New System.Drawing.Size(570, 33)
        Me.lblCode_vc.TabIndex = 1
        Me.lblCode_vc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblCode_vc)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 140)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(591, 53)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "پز کد"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblOutlet_vc)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 196)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(591, 53)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Outlet"
        '
        'lblOutlet_vc
        '
        Me.lblOutlet_vc.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblOutlet_vc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOutlet_vc.Location = New System.Drawing.Point(10, 12)
        Me.lblOutlet_vc.Name = "lblOutlet_vc"
        Me.lblOutlet_vc.Size = New System.Drawing.Size(570, 33)
        Me.lblOutlet_vc.TabIndex = 2
        Me.lblOutlet_vc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblPassword_vc)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 252)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(591, 53)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "رمز"
        '
        'lblPassword_vc
        '
        Me.lblPassword_vc.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblPassword_vc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPassword_vc.Location = New System.Drawing.Point(10, 13)
        Me.lblPassword_vc.Name = "lblPassword_vc"
        Me.lblPassword_vc.Size = New System.Drawing.Size(570, 33)
        Me.lblPassword_vc.TabIndex = 2
        Me.lblPassword_vc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblContractID)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 83)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(591, 53)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "کد قرارداد"
        '
        'lblContractID
        '
        Me.lblContractID.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblContractID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblContractID.Location = New System.Drawing.Point(6, 14)
        Me.lblContractID.Name = "lblContractID"
        Me.lblContractID.Size = New System.Drawing.Size(570, 33)
        Me.lblContractID.TabIndex = 1
        Me.lblContractID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnStartListening, Me.ToolStripSeparator1, Me.btnFinishListening, Me.ToolStripSeparator2, Me.cboPortName})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(615, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnStartListening
        '
        Me.btnStartListening.Image = CType(resources.GetObject("btnStartListening.Image"), System.Drawing.Image)
        Me.btnStartListening.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStartListening.Name = "btnStartListening"
        Me.btnStartListening.Size = New System.Drawing.Size(128, 22)
        Me.btnStartListening.Text = "شروع ارتباط با دستگاه"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnFinishListening
        '
        Me.btnFinishListening.Image = CType(resources.GetObject("btnFinishListening.Image"), System.Drawing.Image)
        Me.btnFinishListening.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFinishListening.Name = "btnFinishListening"
        Me.btnFinishListening.Size = New System.Drawing.Size(119, 22)
        Me.btnFinishListening.Text = "پايان ارتباط با دستگاه"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cboPortName
        '
        Me.cboPortName.Name = "cboPortName"
        Me.cboPortName.Size = New System.Drawing.Size(121, 25)
        '
        'comPort
        '
        Me.comPort.PortName = "COM2"
        Me.comPort.ReadTimeout = 1500
        Me.comPort.RtsEnable = True
        '
        'outerTimer
        '
        Me.outerTimer.Enabled = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.slblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 365)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(615, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(133, 17)
        Me.ToolStripStatusLabel1.Text = "وضعيت در ارتباط با دستگاه :"
        '
        'slblStatus
        '
        Me.slblStatus.Name = "slblStatus"
        Me.slblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'frmLoading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 387)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoading"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بارگذاری پز"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPosSerial As System.Windows.Forms.TextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCode_vc As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblOutlet_vc As System.Windows.Forms.Label
    Friend WithEvents lblPassword_vc As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblContractID As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnStartListening As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFinishListening As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents comPort As System.IO.Ports.SerialPort
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboPortName As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents outerTimer As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents slblStatus As System.Windows.Forms.ToolStripStatusLabel
End Class
