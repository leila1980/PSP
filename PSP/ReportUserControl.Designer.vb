<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportUserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboStateID = New System.Windows.Forms.ComboBox
        Me.cboCityID = New System.Windows.Forms.ComboBox
        Me.cboAria = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(694, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "«” «‰ :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(421, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "‘Â— :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(142, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "„‰ÿﬁÂ :"
        '
        'cboStateID
        '
        Me.cboStateID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStateID.FormattingEnabled = True
        Me.cboStateID.Location = New System.Drawing.Point(511, 15)
        Me.cboStateID.Name = "cboStateID"
        Me.cboStateID.Size = New System.Drawing.Size(179, 21)
        Me.cboStateID.TabIndex = 3
        '
        'cboCityID
        '
        Me.cboCityID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCityID.FormattingEnabled = True
        Me.cboCityID.Location = New System.Drawing.Point(243, 15)
        Me.cboCityID.Name = "cboCityID"
        Me.cboCityID.Size = New System.Drawing.Size(174, 21)
        Me.cboCityID.TabIndex = 4
        '
        'cboAria
        '
        Me.cboAria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAria.FormattingEnabled = True
        Me.cboAria.Location = New System.Drawing.Point(16, 15)
        Me.cboAria.Name = "cboAria"
        Me.cboAria.Size = New System.Drawing.Size(121, 21)
        Me.cboAria.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboAria)
        Me.GroupBox1.Controls.Add(Me.cboCityID)
        Me.GroupBox1.Controls.Add(Me.cboStateID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(754, 46)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'ReportUserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Name = "ReportUserControl1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Size = New System.Drawing.Size(764, 53)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboStateID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCityID As System.Windows.Forms.ComboBox
    Friend WithEvents cboAria As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
