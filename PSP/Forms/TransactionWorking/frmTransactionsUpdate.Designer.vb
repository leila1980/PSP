<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransactionsUpdate
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
        Me.btnUpdateTransaction_History = New System.Windows.Forms.Button
        Me.btnUpdateTransaction_Current = New System.Windows.Forms.Button
        Me.btnUpdateTransaction_MerchantBillingAndDetail = New System.Windows.Forms.Button
        Me.btnUpdateTransaction_TerminalbatchStatus = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnUpdateTransaction_History
        '
        Me.btnUpdateTransaction_History.Location = New System.Drawing.Point(59, 62)
        Me.btnUpdateTransaction_History.Name = "btnUpdateTransaction_History"
        Me.btnUpdateTransaction_History.Size = New System.Drawing.Size(180, 23)
        Me.btnUpdateTransaction_History.TabIndex = 0
        Me.btnUpdateTransaction_History.Text = "بروزرسانی تراکنشها_کلی"
        Me.btnUpdateTransaction_History.UseVisualStyleBackColor = True
        '
        'btnUpdateTransaction_Current
        '
        Me.btnUpdateTransaction_Current.Location = New System.Drawing.Point(59, 33)
        Me.btnUpdateTransaction_Current.Name = "btnUpdateTransaction_Current"
        Me.btnUpdateTransaction_Current.Size = New System.Drawing.Size(180, 23)
        Me.btnUpdateTransaction_Current.TabIndex = 1
        Me.btnUpdateTransaction_Current.Text = "بروزرسانی تراکنشها_روزجاری"
        Me.btnUpdateTransaction_Current.UseVisualStyleBackColor = True
        '
        'btnUpdateTransaction_MerchantBillingAndDetail
        '
        Me.btnUpdateTransaction_MerchantBillingAndDetail.Location = New System.Drawing.Point(59, 91)
        Me.btnUpdateTransaction_MerchantBillingAndDetail.Name = "btnUpdateTransaction_MerchantBillingAndDetail"
        Me.btnUpdateTransaction_MerchantBillingAndDetail.Size = New System.Drawing.Size(180, 23)
        Me.btnUpdateTransaction_MerchantBillingAndDetail.TabIndex = 2
        Me.btnUpdateTransaction_MerchantBillingAndDetail.Text = "بروزرسانی تسویه حسابها"
        Me.btnUpdateTransaction_MerchantBillingAndDetail.UseVisualStyleBackColor = True
        '
        'btnUpdateTransaction_TerminalbatchStatus
        '
        Me.btnUpdateTransaction_TerminalbatchStatus.Location = New System.Drawing.Point(59, 119)
        Me.btnUpdateTransaction_TerminalbatchStatus.Name = "btnUpdateTransaction_TerminalbatchStatus"
        Me.btnUpdateTransaction_TerminalbatchStatus.Size = New System.Drawing.Size(180, 23)
        Me.btnUpdateTransaction_TerminalbatchStatus.TabIndex = 4
        Me.btnUpdateTransaction_TerminalbatchStatus.Text = "بروزرسانی TerminalbatchStatus"
        Me.btnUpdateTransaction_TerminalbatchStatus.UseVisualStyleBackColor = True
        '
        'frmTransactionsUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 184)
        Me.Controls.Add(Me.btnUpdateTransaction_TerminalbatchStatus)
        Me.Controls.Add(Me.btnUpdateTransaction_MerchantBillingAndDetail)
        Me.Controls.Add(Me.btnUpdateTransaction_Current)
        Me.Controls.Add(Me.btnUpdateTransaction_History)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransactionsUpdate"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بروزرسانی تراکنشها"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnUpdateTransaction_History As System.Windows.Forms.Button
    Friend WithEvents btnUpdateTransaction_Current As System.Windows.Forms.Button
    Friend WithEvents btnUpdateTransaction_MerchantBillingAndDetail As System.Windows.Forms.Button
    Friend WithEvents btnUpdateTransaction_TerminalbatchStatus As System.Windows.Forms.Button
End Class
