<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosChange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPosChange))
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSerial_vc = New System.Windows.Forms.TextBox
        Me.txtOutlet_vc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.btnAssignNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnAssignReprint = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument
        Me.GroupBox1.SuspendLayout()
        Me.tsMain.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(127, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "شماره سریال جدید :"
        '
        'txtSerial_vc
        '
        Me.txtSerial_vc.Location = New System.Drawing.Point(25, 15)
        Me.txtSerial_vc.Name = "txtSerial_vc"
        Me.txtSerial_vc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSerial_vc.Size = New System.Drawing.Size(100, 21)
        Me.txtSerial_vc.TabIndex = 4
        '
        'txtOutlet_vc
        '
        Me.txtOutlet_vc.Location = New System.Drawing.Point(351, 16)
        Me.txtOutlet_vc.Name = "txtOutlet_vc"
        Me.txtOutlet_vc.Size = New System.Drawing.Size(100, 21)
        Me.txtOutlet_vc.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(457, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "کد پایانه :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtOutlet_vc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSerial_vc)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(536, 44)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAssignNew, Me.ToolStripSeparator2, Me.btnSave, Me.ToolStripSeparator1, Me.btnAssignReprint})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(543, 25)
        Me.tsMain.TabIndex = 22
        '
        'btnAssignNew
        '
        Me.btnAssignNew.Image = CType(resources.GetObject("btnAssignNew.Image"), System.Drawing.Image)
        Me.btnAssignNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAssignNew.Name = "btnAssignNew"
        Me.btnAssignNew.Size = New System.Drawing.Size(49, 22)
        Me.btnAssignNew.Text = "جدید"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(44, 22)
        Me.btnSave.Text = "ثبت"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator1.Visible = False
        '
        'btnAssignReprint
        '
        Me.btnAssignReprint.Image = CType(resources.GetObject("btnAssignReprint.Image"), System.Drawing.Image)
        Me.btnAssignReprint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAssignReprint.Name = "btnAssignReprint"
        Me.btnAssignReprint.Size = New System.Drawing.Size(73, 22)
        Me.btnAssignReprint.Text = "چاپ مجدد"
        Me.btnAssignReprint.Visible = False
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'frmPosChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 79)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPosChange"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تغییر سریال پذیرنده"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSerial_vc As System.Windows.Forms.TextBox
    Friend WithEvents txtOutlet_vc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAssignNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAssignReprint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
End Class
