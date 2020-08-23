<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferRequest
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
        Me.OkButton = New System.Windows.Forms.Button
        Me.cmbProject = New System.Windows.Forms.ComboBox
        Me.CancelButton = New System.Windows.Forms.Button
        Me.txtContract = New System.Windows.Forms.TextBox
        Me.lblProject = New System.Windows.Forms.Label
        Me.TransferPanel = New System.Windows.Forms.Panel
        Me.LblContractID = New System.Windows.Forms.Label
        Me.TransferPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'OkButton
        '
        Me.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OkButton.Location = New System.Drawing.Point(84, 85)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 27)
        Me.OkButton.TabIndex = 12
        Me.OkButton.Text = "تایید"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'cmbProject
        '
        Me.cmbProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(11, 41)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(242, 21)
        Me.cmbProject.TabIndex = 3
        '
        'CancelButton
        '
        Me.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CancelButton.Location = New System.Drawing.Point(3, 85)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 27)
        Me.CancelButton.TabIndex = 13
        Me.CancelButton.Text = "انصراف"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'txtContract
        '
        Me.txtContract.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContract.Location = New System.Drawing.Point(11, 13)
        Me.txtContract.Name = "txtContract"
        Me.txtContract.Size = New System.Drawing.Size(242, 21)
        Me.txtContract.TabIndex = 2
        '
        'lblProject
        '
        Me.lblProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProject.AutoSize = True
        Me.lblProject.Location = New System.Drawing.Point(255, 49)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(49, 13)
        Me.lblProject.TabIndex = 1
        Me.lblProject.Text = "نام پروژه:"
        '
        'TransferPanel
        '
        Me.TransferPanel.Controls.Add(Me.cmbProject)
        Me.TransferPanel.Controls.Add(Me.txtContract)
        Me.TransferPanel.Controls.Add(Me.lblProject)
        Me.TransferPanel.Controls.Add(Me.LblContractID)
        Me.TransferPanel.Location = New System.Drawing.Point(3, 1)
        Me.TransferPanel.Name = "TransferPanel"
        Me.TransferPanel.Size = New System.Drawing.Size(332, 78)
        Me.TransferPanel.TabIndex = 11
        '
        'LblContractID
        '
        Me.LblContractID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblContractID.AutoSize = True
        Me.LblContractID.Location = New System.Drawing.Point(255, 16)
        Me.LblContractID.Name = "LblContractID"
        Me.LblContractID.Size = New System.Drawing.Size(73, 13)
        Me.LblContractID.TabIndex = 0
        Me.LblContractID.Text = "کد درخواست :"
        '
        'frmTransferRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 117)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.TransferPanel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferRequest"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "انتقال درخواست"
        Me.TransferPanel.ResumeLayout(False)
        Me.TransferPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents CancelButton As System.Windows.Forms.Button
    Friend WithEvents txtContract As System.Windows.Forms.TextBox
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents TransferPanel As System.Windows.Forms.Panel
    Friend WithEvents LblContractID As System.Windows.Forms.Label
End Class
