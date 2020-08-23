<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgentMonthlyGoalsEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgentMonthlyGoalsEdit))
        Me.txtThird = New System.Windows.Forms.TextBox
        Me.txtFirst = New System.Windows.Forms.TextBox
        Me.txtSecond = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbState = New System.Windows.Forms.ComboBox
        Me.cmbAgent = New System.Windows.Forms.ComboBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnSaveAndContinue = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSaveAndExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Tsb_Cancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtThird
        '
        Me.txtThird.Location = New System.Drawing.Point(17, 90)
        Me.txtThird.Name = "txtThird"
        Me.txtThird.Size = New System.Drawing.Size(171, 21)
        Me.txtThird.TabIndex = 4
        '
        'txtFirst
        '
        Me.txtFirst.Location = New System.Drawing.Point(17, 40)
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(171, 21)
        Me.txtFirst.TabIndex = 2
        '
        'txtSecond
        '
        Me.txtSecond.Location = New System.Drawing.Point(17, 65)
        Me.txtSecond.Name = "txtSecond"
        Me.txtSecond.Size = New System.Drawing.Size(171, 21)
        Me.txtSecond.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(508, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "نام استان"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(505, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "نام نماینده"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(218, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "تعهد ماه اول"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(216, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "تعهد ماه دوم"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(210, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "تعهد ماه سوم"
        '
        'cmbState
        '
        Me.cmbState.FormattingEnabled = True
        Me.cmbState.Location = New System.Drawing.Point(313, 40)
        Me.cmbState.Name = "cmbState"
        Me.cmbState.Size = New System.Drawing.Size(170, 21)
        Me.cmbState.TabIndex = 0
        '
        'cmbAgent
        '
        Me.cmbAgent.FormattingEnabled = True
        Me.cmbAgent.Location = New System.Drawing.Point(313, 67)
        Me.cmbAgent.Name = "cmbAgent"
        Me.cmbAgent.Size = New System.Drawing.Size(170, 21)
        Me.cmbAgent.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSaveAndContinue, Me.ToolStripSeparator1, Me.btnSaveAndExit, Me.ToolStripSeparator2, Me.Tsb_Cancel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStrip1.Size = New System.Drawing.Size(577, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSaveAndContinue
        '
        Me.btnSaveAndContinue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSaveAndContinue.Image = CType(resources.GetObject("btnSaveAndContinue.Image"), System.Drawing.Image)
        Me.btnSaveAndContinue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveAndContinue.Name = "btnSaveAndContinue"
        Me.btnSaveAndContinue.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSaveAndContinue.Size = New System.Drawing.Size(80, 22)
        Me.btnSaveAndContinue.Text = "ثبت و بعدی"
        Me.btnSaveAndContinue.ToolTipText = "ثبت اطلاعات مربوط به سریال (های) انتخاب شده"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnSaveAndExit
        '
        Me.btnSaveAndExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnSaveAndExit.Image = CType(resources.GetObject("btnSaveAndExit.Image"), System.Drawing.Image)
        Me.btnSaveAndExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveAndExit.Name = "btnSaveAndExit"
        Me.btnSaveAndExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnSaveAndExit.Size = New System.Drawing.Size(79, 22)
        Me.btnSaveAndExit.Text = "ثبت و خروج"
        Me.btnSaveAndExit.ToolTipText = "ثبت اطلاعات مربوط به سریال (های) انتخاب شده"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Tsb_Cancel
        '
        Me.Tsb_Cancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Tsb_Cancel.Image = CType(resources.GetObject("Tsb_Cancel.Image"), System.Drawing.Image)
        Me.Tsb_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tsb_Cancel.Name = "Tsb_Cancel"
        Me.Tsb_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tsb_Cancel.Size = New System.Drawing.Size(51, 22)
        Me.Tsb_Cancel.Text = "خروج"
        '
        'frmAgentMonthlyGoalsEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(577, 126)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cmbAgent)
        Me.Controls.Add(Me.cmbState)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSecond)
        Me.Controls.Add(Me.txtFirst)
        Me.Controls.Add(Me.txtThird)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmAgentMonthlyGoalsEdit"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtThird As System.Windows.Forms.TextBox
    Friend WithEvents txtFirst As System.Windows.Forms.TextBox
    Friend WithEvents txtSecond As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbState As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAgent As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents btnSaveAndContinue As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnSaveAndExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents Tsb_Cancel As System.Windows.Forms.ToolStripButton

End Class
