<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTMSSendToOld
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnMakeFile = New System.Windows.Forms.Button
        Me.dgvNotSentTMS = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvNotSentTMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvNotSentTMS)
        Me.GroupBox1.Controls.Add(Me.btnMakeFile)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 75)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnMakeFile
        '
        Me.btnMakeFile.Location = New System.Drawing.Point(160, 20)
        Me.btnMakeFile.Name = "btnMakeFile"
        Me.btnMakeFile.Size = New System.Drawing.Size(101, 23)
        Me.btnMakeFile.TabIndex = 0
        Me.btnMakeFile.Text = "ساخت فایل Excel"
        Me.btnMakeFile.UseVisualStyleBackColor = True
        '
        'dgvNotSentTMS
        '
        Me.dgvNotSentTMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotSentTMS.Location = New System.Drawing.Point(392, 16)
        Me.dgvNotSentTMS.Name = "dgvNotSentTMS"
        Me.dgvNotSentTMS.Size = New System.Drawing.Size(10, 27)
        Me.dgvNotSentTMS.TabIndex = 2
        Me.dgvNotSentTMS.Visible = False
        '
        'frmTMSSendTo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 81)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTMSSendTo"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TMS"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvNotSentTMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMakeFile As System.Windows.Forms.Button
    Friend WithEvents dgvNotSentTMS As System.Windows.Forms.DataGridView
End Class
