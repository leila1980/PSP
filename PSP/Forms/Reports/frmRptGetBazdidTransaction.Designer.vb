﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptGetBazdidTransaction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptGetBazdidTransaction))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkParent = New System.Windows.Forms.CheckBox
        Me.lblCancelDate = New System.Windows.Forms.Label
        Me.lblInstallDate = New System.Windows.Forms.Label
        Me.lblState = New System.Windows.Forms.Label
        Me.lblStoreName = New System.Windows.Forms.Label
        Me.lblVisitor = New System.Windows.Forms.Label
        Me.lblMerchant = New System.Windows.Forms.Label
        Me.lblOutlet = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvReport = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnShow = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnPrint = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtMorediToPrice = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAdvariToPrice = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.rucDate = New ReportUserControl_DateInterval
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.chkParent)
        Me.GroupBox4.Controls.Add(Me.lblCancelDate)
        Me.GroupBox4.Controls.Add(Me.lblInstallDate)
        Me.GroupBox4.Controls.Add(Me.lblState)
        Me.GroupBox4.Controls.Add(Me.lblStoreName)
        Me.GroupBox4.Controls.Add(Me.lblVisitor)
        Me.GroupBox4.Controls.Add(Me.lblMerchant)
        Me.GroupBox4.Controls.Add(Me.lblOutlet)
        Me.GroupBox4.Controls.Add(Me.lblName)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(157, 28)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(629, 100)
        Me.GroupBox4.TabIndex = 48
        Me.GroupBox4.TabStop = False
        '
        'chkParent
        '
        Me.chkParent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkParent.AutoSize = True
        Me.chkParent.Checked = True
        Me.chkParent.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkParent.Enabled = False
        Me.chkParent.Location = New System.Drawing.Point(12, 72)
        Me.chkParent.Name = "chkParent"
        Me.chkParent.Size = New System.Drawing.Size(130, 17)
        Me.chkParent.TabIndex = 24
        Me.chkParent.Text = "نمایش اطلاعات اضافی"
        Me.chkParent.UseVisualStyleBackColor = True
        '
        'lblCancelDate
        '
        Me.lblCancelDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCancelDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCancelDate.Location = New System.Drawing.Point(212, 72)
        Me.lblCancelDate.Name = "lblCancelDate"
        Me.lblCancelDate.Size = New System.Drawing.Size(108, 17)
        Me.lblCancelDate.TabIndex = 23
        '
        'lblInstallDate
        '
        Me.lblInstallDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInstallDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInstallDate.Location = New System.Drawing.Point(12, 48)
        Me.lblInstallDate.Name = "lblInstallDate"
        Me.lblInstallDate.Size = New System.Drawing.Size(102, 17)
        Me.lblInstallDate.TabIndex = 22
        '
        'lblState
        '
        Me.lblState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblState.Location = New System.Drawing.Point(212, 48)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(108, 17)
        Me.lblState.TabIndex = 21
        '
        'lblStoreName
        '
        Me.lblStoreName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStoreName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStoreName.Location = New System.Drawing.Point(409, 48)
        Me.lblStoreName.Name = "lblStoreName"
        Me.lblStoreName.Size = New System.Drawing.Size(106, 17)
        Me.lblStoreName.TabIndex = 20
        '
        'lblVisitor
        '
        Me.lblVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVisitor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVisitor.Location = New System.Drawing.Point(409, 72)
        Me.lblVisitor.Name = "lblVisitor"
        Me.lblVisitor.Size = New System.Drawing.Size(106, 17)
        Me.lblVisitor.TabIndex = 19
        '
        'lblMerchant
        '
        Me.lblMerchant.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMerchant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMerchant.Location = New System.Drawing.Point(12, 22)
        Me.lblMerchant.Name = "lblMerchant"
        Me.lblMerchant.Size = New System.Drawing.Size(102, 17)
        Me.lblMerchant.TabIndex = 18
        '
        'lblOutlet
        '
        Me.lblOutlet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOutlet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOutlet.Location = New System.Drawing.Point(212, 22)
        Me.lblOutlet.Name = "lblOutlet"
        Me.lblOutlet.Size = New System.Drawing.Size(108, 17)
        Me.lblOutlet.TabIndex = 17
        '
        'lblName
        '
        Me.lblName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblName.Location = New System.Drawing.Point(409, 22)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(106, 17)
        Me.lblName.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(326, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "تاریخ فسخ :"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(120, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "تاریخ نصب :"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(326, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "وضعیت :"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(521, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "نام فروشگاه :"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(521, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "بازاریاب :"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(120, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "کد پذیرنده :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(326, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "کد پایانه :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(521, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "نام و نام خانوادگی :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvReport)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1011, 385)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        '
        'dgvReport
        '
        Me.dgvReport.AllowUserToAddRows = False
        Me.dgvReport.AllowUserToDeleteRows = False
        Me.dgvReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReport.Location = New System.Drawing.Point(8, 18)
        Me.dgvReport.Name = "dgvReport"
        Me.dgvReport.ReadOnly = True
        Me.dgvReport.Size = New System.Drawing.Size(995, 357)
        Me.dgvReport.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnShow, Me.ToolStripSeparator3, Me.btnExportToExcel, Me.ToolStripSeparator1, Me.btnPrint})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1018, 25)
        Me.ToolStrip1.TabIndex = 45
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnShow
        '
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(67, 22)
        Me.btnShow.Text = "مشاهده"
        Me.btnShow.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator3.Visible = False
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Image = CType(resources.GetObject("btnExportToExcel.Image"), System.Drawing.Image)
        Me.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(93, 22)
        Me.btnExportToExcel.Text = "انتقال به Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator1.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(46, 22)
        Me.btnPrint.Text = "چاپ"
        Me.btnPrint.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtMorediToPrice)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAdvariToPrice)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(147, 100)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "سقف مبلغ بازدید"
        '
        'txtMorediToPrice
        '
        Me.txtMorediToPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMorediToPrice.Location = New System.Drawing.Point(11, 60)
        Me.txtMorediToPrice.MaxLength = 19
        Me.txtMorediToPrice.Name = "txtMorediToPrice"
        Me.txtMorediToPrice.ReadOnly = True
        Me.txtMorediToPrice.Size = New System.Drawing.Size(74, 21)
        Me.txtMorediToPrice.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "موردی :"
        '
        'txtAdvariToPrice
        '
        Me.txtAdvariToPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdvariToPrice.Location = New System.Drawing.Point(11, 29)
        Me.txtAdvariToPrice.MaxLength = 8
        Me.txtAdvariToPrice.Name = "txtAdvariToPrice"
        Me.txtAdvariToPrice.ReadOnly = True
        Me.txtAdvariToPrice.Size = New System.Drawing.Size(74, 21)
        Me.txtAdvariToPrice.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(91, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "ادواری :"
        '
        'rucDate
        '
        Me.rucDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rucDate.Enabled = False
        Me.rucDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.rucDate.Location = New System.Drawing.Point(792, 28)
        Me.rucDate.Name = "rucDate"
        Me.rucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.rucDate.SelectedDateTimedpDateFrom = Nothing
        Me.rucDate.SelectedDateTimedpDateTo = Nothing
        Me.rucDate.SelectedIndex = CType(CSByte(0), SByte)
        Me.rucDate.Size = New System.Drawing.Size(226, 104)
        Me.rucDate.TabIndex = 46
        '
        'frmRptGetBazdidTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 514)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.rucDate)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRptGetBazdidTransaction"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ریز بازدیدها"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCancelDate As System.Windows.Forms.Label
    Friend WithEvents lblInstallDate As System.Windows.Forms.Label
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents lblStoreName As System.Windows.Forms.Label
    Friend WithEvents lblVisitor As System.Windows.Forms.Label
    Friend WithEvents lblMerchant As System.Windows.Forms.Label
    Friend WithEvents lblOutlet As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents rucDate As ReportUserControl_DateInterval
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnShow As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMorediToPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAdvariToPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkParent As System.Windows.Forms.CheckBox
End Class
