<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhsachBN
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDanhsachBN))
        Me.fgDanhsachBN = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.mnuTacnghiep = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ThêmNộiDungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XóaChiPhíToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbTongsoBN = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rb_TheoSDT = New System.Windows.Forms.RadioButton()
        Me.rb_TenHoacSDT = New System.Windows.Forms.RadioButton()
        Me.rb_TenVaSDT = New System.Windows.Forms.RadioButton()
        Me.rb_TheoTen = New System.Windows.Forms.RadioButton()
        Me.txt_SoDienThoai = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTenBenhNhan = New System.Windows.Forms.TextBox()
        Me.cmdXemDS = New System.Windows.Forms.Button()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbl_SoLuongBN = New System.Windows.Forms.Label()
        CType(Me.fgDanhsachBN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuTacnghiep.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fgDanhsachBN
        '
        Me.fgDanhsachBN.AllowEditing = False
        Me.fgDanhsachBN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fgDanhsachBN.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgDanhsachBN.ColumnInfo = resources.GetString("fgDanhsachBN.ColumnInfo")
        Me.fgDanhsachBN.Location = New System.Drawing.Point(4, 70)
        Me.fgDanhsachBN.Name = "fgDanhsachBN"
        Me.fgDanhsachBN.Rows.Count = 1
        Me.fgDanhsachBN.Rows.MinSize = 25
        Me.fgDanhsachBN.Size = New System.Drawing.Size(1083, 546)
        Me.fgDanhsachBN.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgDanhsachBN.Styles"))
        Me.fgDanhsachBN.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 11)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 13)
        Me.Label19.TabIndex = 74
        Me.Label19.Text = "Họ tên bệnh nhân:"
        '
        'mnuTacnghiep
        '
        Me.mnuTacnghiep.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThêmNộiDungToolStripMenuItem, Me.XóaChiPhíToolStripMenuItem})
        Me.mnuTacnghiep.Name = "mnuTacnghiep"
        Me.mnuTacnghiep.Size = New System.Drawing.Size(144, 48)
        '
        'ThêmNộiDungToolStripMenuItem
        '
        Me.ThêmNộiDungToolStripMenuItem.Name = "ThêmNộiDungToolStripMenuItem"
        Me.ThêmNộiDungToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ThêmNộiDungToolStripMenuItem.Text = "Thêm chi phí"
        '
        'XóaChiPhíToolStripMenuItem
        '
        Me.XóaChiPhíToolStripMenuItem.Name = "XóaChiPhíToolStripMenuItem"
        Me.XóaChiPhíToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.XóaChiPhíToolStripMenuItem.Text = "Xóa chi phí"
        '
        'lbTongsoBN
        '
        Me.lbTongsoBN.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lbTongsoBN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTongsoBN.ForeColor = System.Drawing.Color.Gold
        Me.lbTongsoBN.Location = New System.Drawing.Point(4, 3)
        Me.lbTongsoBN.Name = "lbTongsoBN"
        Me.lbTongsoBN.Size = New System.Drawing.Size(121, 61)
        Me.lbTongsoBN.TabIndex = 5
        Me.lbTongsoBN.Text = "Số lượng:"
        Me.lbTongsoBN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel1.Controls.Add(Me.rb_TheoSDT)
        Me.Panel1.Controls.Add(Me.rb_TenHoacSDT)
        Me.Panel1.Controls.Add(Me.rb_TenVaSDT)
        Me.Panel1.Controls.Add(Me.rb_TheoTen)
        Me.Panel1.Controls.Add(Me.txt_SoDienThoai)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtTenBenhNhan)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Location = New System.Drawing.Point(174, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(660, 61)
        Me.Panel1.TabIndex = 76
        '
        'rb_TheoSDT
        '
        Me.rb_TheoSDT.AutoSize = True
        Me.rb_TheoSDT.Location = New System.Drawing.Point(483, 35)
        Me.rb_TheoSDT.Name = "rb_TheoSDT"
        Me.rb_TheoSDT.Size = New System.Drawing.Size(114, 17)
        Me.rb_TheoSDT.TabIndex = 76
        Me.rb_TheoSDT.Text = "Theo số điện thoại"
        Me.rb_TheoSDT.UseVisualStyleBackColor = True
        '
        'rb_TenHoacSDT
        '
        Me.rb_TenHoacSDT.AutoSize = True
        Me.rb_TenHoacSDT.Location = New System.Drawing.Point(312, 35)
        Me.rb_TenHoacSDT.Name = "rb_TenHoacSDT"
        Me.rb_TenHoacSDT.Size = New System.Drawing.Size(159, 17)
        Me.rb_TenHoacSDT.TabIndex = 76
        Me.rb_TenHoacSDT.Text = "Theo tên hoặc số điện thoại"
        Me.rb_TenHoacSDT.UseVisualStyleBackColor = True
        '
        'rb_TenVaSDT
        '
        Me.rb_TenVaSDT.AutoSize = True
        Me.rb_TenVaSDT.Location = New System.Drawing.Point(142, 35)
        Me.rb_TenVaSDT.Name = "rb_TenVaSDT"
        Me.rb_TenVaSDT.Size = New System.Drawing.Size(147, 17)
        Me.rb_TenVaSDT.TabIndex = 76
        Me.rb_TenVaSDT.Text = "Theo tên và số điện thoại"
        Me.rb_TenVaSDT.UseVisualStyleBackColor = True
        '
        'rb_TheoTen
        '
        Me.rb_TheoTen.AutoSize = True
        Me.rb_TheoTen.Checked = True
        Me.rb_TheoTen.Location = New System.Drawing.Point(47, 35)
        Me.rb_TheoTen.Name = "rb_TheoTen"
        Me.rb_TheoTen.Size = New System.Drawing.Size(68, 17)
        Me.rb_TheoTen.TabIndex = 76
        Me.rb_TheoTen.TabStop = True
        Me.rb_TheoTen.Text = "Theo tên"
        Me.rb_TheoTen.UseVisualStyleBackColor = True
        '
        'txt_SoDienThoai
        '
        Me.txt_SoDienThoai.Location = New System.Drawing.Point(422, 7)
        Me.txt_SoDienThoai.Name = "txt_SoDienThoai"
        Me.txt_SoDienThoai.Size = New System.Drawing.Size(188, 20)
        Me.txt_SoDienThoai.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(347, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Số điện thoại:"
        '
        'txtTenBenhNhan
        '
        Me.txtTenBenhNhan.Location = New System.Drawing.Point(107, 8)
        Me.txtTenBenhNhan.Name = "txtTenBenhNhan"
        Me.txtTenBenhNhan.Size = New System.Drawing.Size(229, 20)
        Me.txtTenBenhNhan.TabIndex = 75
        '
        'cmdXemDS
        '
        Me.cmdXemDS.BackColor = System.Drawing.Color.Transparent
        Me.cmdXemDS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXemDS.Image = Global.PhongKham.My.Resources.Resources.Search
        Me.cmdXemDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdXemDS.Location = New System.Drawing.Point(840, 5)
        Me.cmdXemDS.Name = "cmdXemDS"
        Me.cmdXemDS.Size = New System.Drawing.Size(128, 30)
        Me.cmdXemDS.TabIndex = 54
        Me.cmdXemDS.Text = "&Xem danh sách"
        Me.cmdXemDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdXemDS.UseVisualStyleBackColor = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.Color.Transparent
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = Global.PhongKham.My.Resources.Resources._exit
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(984, 5)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(83, 30)
        Me.cmdThoat.TabIndex = 53
        Me.cmdThoat.Text = "&Thoát"
        Me.cmdThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(917, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 30)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "Get text"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'lbl_SoLuongBN
        '
        Me.lbl_SoLuongBN.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lbl_SoLuongBN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SoLuongBN.ForeColor = System.Drawing.Color.Gold
        Me.lbl_SoLuongBN.Location = New System.Drawing.Point(109, 3)
        Me.lbl_SoLuongBN.Name = "lbl_SoLuongBN"
        Me.lbl_SoLuongBN.Size = New System.Drawing.Size(62, 61)
        Me.lbl_SoLuongBN.TabIndex = 5
        Me.lbl_SoLuongBN.Text = "0"
        Me.lbl_SoLuongBN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmDanhsachBN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1092, 621)
        Me.Controls.Add(Me.lbl_SoLuongBN)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdXemDS)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdThoat)
        Me.Controls.Add(Me.fgDanhsachBN)
        Me.Controls.Add(Me.lbTongsoBN)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDanhsachBN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.fgDanhsachBN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuTacnghiep.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fgDanhsachBN As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lbTongsoBN As System.Windows.Forms.Label
    Friend WithEvents mnuTacnghiep As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ThêmNộiDungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XóaChiPhíToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents cmdXemDS As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtTenBenhNhan As System.Windows.Forms.TextBox
    Friend WithEvents txt_SoDienThoai As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rb_TheoSDT As RadioButton
    Friend WithEvents rb_TenHoacSDT As RadioButton
    Friend WithEvents rb_TenVaSDT As RadioButton
    Friend WithEvents rb_TheoTen As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents lbl_SoLuongBN As Label
End Class
