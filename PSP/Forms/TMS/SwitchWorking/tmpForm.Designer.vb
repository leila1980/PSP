<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTemp
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
        Me.btnAssign = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvCardAcceptor = New System.Windows.Forms.DataGridView
        Me.colChk = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboPaymentMethodType = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCardAcceptor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAssign
        '
        Me.btnAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssign.Location = New System.Drawing.Point(505, 22)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(193, 23)
        Me.btnAssign.TabIndex = 13
        Me.btnAssign.Text = "بروزرسانی نوع پرداخت در سوئیچ"
        Me.btnAssign.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvCardAcceptor)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(991, 368)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "پذیرندگان"
        '
        'dgvCardAcceptor
        '
        Me.dgvCardAcceptor.AllowUserToAddRows = False
        Me.dgvCardAcceptor.AllowUserToDeleteRows = False
        Me.dgvCardAcceptor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCardAcceptor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCardAcceptor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colChk})
        Me.dgvCardAcceptor.Location = New System.Drawing.Point(8, 19)
        Me.dgvCardAcceptor.Name = "dgvCardAcceptor"
        Me.dgvCardAcceptor.RowHeadersVisible = False
        Me.dgvCardAcceptor.Size = New System.Drawing.Size(977, 338)
        Me.dgvCardAcceptor.TabIndex = 0
        '
        'colChk
        '
        Me.colChk.HeaderText = ""
        Me.colChk.Name = "colChk"
        Me.colChk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colChk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colChk.Width = 30
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(931, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "نوع پرداخت"
        '
        'cboPaymentMethodType
        '
        Me.cboPaymentMethodType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPaymentMethodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentMethodType.FormattingEnabled = True
        Me.cboPaymentMethodType.Location = New System.Drawing.Point(704, 22)
        Me.cboPaymentMethodType.Name = "cboPaymentMethodType"
        Me.cboPaymentMethodType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPaymentMethodType.Size = New System.Drawing.Size(222, 21)
        Me.cboPaymentMethodType.TabIndex = 10
        '
        'tmpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 431)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPaymentMethodType)
        Me.Name = "tmpForm"
        Me.Text = "tmpForm"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvCardAcceptor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAssign As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCardAcceptor As System.Windows.Forms.DataGridView
    Friend WithEvents colChk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPaymentMethodType As System.Windows.Forms.ComboBox
End Class
