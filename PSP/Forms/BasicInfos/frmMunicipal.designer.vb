<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMunicipal
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
        Me.tvCategories = New System.Windows.Forms.TreeView
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.btnAddNewChild = New System.Windows.Forms.Button
        Me.btnAddNewCategory = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmnuAddChildren = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAddChildren = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEditNode = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDeleteNode = New System.Windows.Forms.ToolStripMenuItem
        Me.btnClose = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmnuAddChildren.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvCategories
        '
        Me.tvCategories.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvCategories.Location = New System.Drawing.Point(0, 0)
        Me.tvCategories.Name = "tvCategories"
        Me.tvCategories.RightToLeftLayout = True
        Me.tvCategories.Size = New System.Drawing.Size(287, 377)
        Me.tvCategories.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddNewChild, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddNewCategory, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(346, 38)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(151, 71)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'btnAddNewChild
        '
        Me.btnAddNewChild.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddNewChild.Location = New System.Drawing.Point(3, 38)
        Me.btnAddNewChild.Name = "btnAddNewChild"
        Me.btnAddNewChild.Size = New System.Drawing.Size(145, 23)
        Me.btnAddNewChild.TabIndex = 1
        Me.btnAddNewChild.Text = "اضافه کردن زيرشاخه"
        Me.btnAddNewChild.UseVisualStyleBackColor = True
        '
        'btnAddNewCategory
        '
        Me.btnAddNewCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddNewCategory.Location = New System.Drawing.Point(3, 3)
        Me.btnAddNewCategory.Name = "btnAddNewCategory"
        Me.btnAddNewCategory.Size = New System.Drawing.Size(145, 23)
        Me.btnAddNewCategory.TabIndex = 0
        Me.btnAddNewCategory.Text = "اضافه کردن موضوع جديد"
        Me.btnAddNewCategory.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Location = New System.Drawing.Point(343, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 42)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "براي اضافه کردن/حذف کردن زيرشاخه‌ها، روي ليست کليک راست کنيد."
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox1.Location = New System.Drawing.Point(362, 202)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(99, 118)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PictureBox2.Location = New System.Drawing.Point(305, 141)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'cmnuAddChildren
        '
        Me.cmnuAddChildren.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddChildren, Me.mnuEditNode, Me.mnuDeleteNode})
        Me.cmnuAddChildren.Name = "cmnuAddChildren"
        Me.cmnuAddChildren.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmnuAddChildren.Size = New System.Drawing.Size(171, 70)
        '
        'mnuAddChildren
        '
        Me.mnuAddChildren.Name = "mnuAddChildren"
        Me.mnuAddChildren.Size = New System.Drawing.Size(170, 22)
        Me.mnuAddChildren.Text = "اضافه کردن زیر شاخه"
        '
        'mnuEditNode
        '
        Me.mnuEditNode.Name = "mnuEditNode"
        Me.mnuEditNode.Size = New System.Drawing.Size(170, 22)
        Me.mnuEditNode.Text = "ویرایش"
        '
        'mnuDeleteNode
        '
        Me.mnuDeleteNode.Name = "mnuDeleteNode"
        Me.mnuDeleteNode.Size = New System.Drawing.Size(170, 22)
        Me.mnuDeleteNode.Text = "حذف"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(489, 342)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "بازگشت"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmMunicipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(576, 377)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.tvCategories)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmMunicipal"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مناطق"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmnuAddChildren.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tvCategories As System.Windows.Forms.TreeView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAddNewChild As System.Windows.Forms.Button
    Friend WithEvents btnAddNewCategory As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmnuAddChildren As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAddChildren As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditNode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteNode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
