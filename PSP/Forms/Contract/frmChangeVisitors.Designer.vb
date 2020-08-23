<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeVisitors
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
        Me.components = New System.ComponentModel.Container
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.uc_Visitor = New Visitor
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboDestVisitor = New System.Windows.Forms.ComboBox
        Me.btnChange = New System.Windows.Forms.Button
        Me.uc_SMC = New Management_State_City
        Me.erp = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.uc_Visitor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboDestVisitor)
        Me.GroupBox1.Controls.Add(Me.btnChange)
        Me.GroupBox1.Controls.Add(Me.uc_SMC)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 142)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'uc_Visitor
        '
        Me.uc_Visitor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uc_Visitor.Location = New System.Drawing.Point(240, 112)
        Me.uc_Visitor.Name = "uc_Visitor"
        Me.uc_Visitor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.uc_Visitor.Size = New System.Drawing.Size(239, 24)
        Me.uc_Visitor.TabIndex = 21
        Me.uc_Visitor.VisitorID = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(194, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "بازاریاب:"
        '
        'cboDestVisitor
        '
        Me.cboDestVisitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestVisitor.FormattingEnabled = True
        Me.cboDestVisitor.Location = New System.Drawing.Point(3, 73)
        Me.cboDestVisitor.Name = "cboDestVisitor"
        Me.cboDestVisitor.Size = New System.Drawing.Size(185, 21)
        Me.cboDestVisitor.TabIndex = 19
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(189, 45)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(50, 23)
        Me.btnChange.TabIndex = 18
        Me.btnChange.Text = "==>>"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'uc_SMC
        '
        Me.uc_SMC.CityID = ""
        Me.uc_SMC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.uc_SMC.Location = New System.Drawing.Point(245, 12)
        Me.uc_SMC.ManagementID = ""
        Me.uc_SMC.Name = "uc_SMC"
        Me.uc_SMC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.uc_SMC.Size = New System.Drawing.Size(239, 96)
        Me.uc_SMC.StateID = ""
        Me.uc_SMC.TabIndex = 15
        '
        'erp
        '
        Me.erp.ContainerControl = Me
        '
        'frmChangeVisitors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 145)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangeVisitors"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تغییر بازاریاب"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.erp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents uc_SMC As Management_State_City
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDestVisitor As System.Windows.Forms.ComboBox
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents uc_Visitor As Visitor
    Friend WithEvents erp As System.Windows.Forms.ErrorProvider
End Class
