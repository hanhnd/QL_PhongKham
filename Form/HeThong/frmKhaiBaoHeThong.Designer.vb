<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKhaiBaoHeThong
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKhaiBaoHeThong))
        Me.txt_TenPK = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_TenTat = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_TenTiengAnh = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.mnTienLuong = New System.Windows.Forms.NumericUpDown()
        Me.cmdThuchien = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.optInNhiet = New System.Windows.Forms.RadioButton()
        Me.optInLazer = New System.Windows.Forms.RadioButton()
        Me.CheckBox15 = New System.Windows.Forms.CheckBox()
        Me.CheckBox16 = New System.Windows.Forms.CheckBox()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.picAnhNguoiDung = New System.Windows.Forms.PictureBox()
        Me.txtTraiTuyen = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFTP_User = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFTP_Pass = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFTP_IP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_Email = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMaDKKCBBD = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_SDT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_DiaChi = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.menuChonAnh = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuChonAnh = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuXoaAnh = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.mnTienLuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.picAnhNguoiDung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuChonAnh.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_TenPK
        '
        Me.txt_TenPK.Location = New System.Drawing.Point(261, 22)
        Me.txt_TenPK.Name = "txt_TenPK"
        Me.txt_TenPK.Size = New System.Drawing.Size(327, 20)
        Me.txt_TenPK.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Tên phòng khám:"
        '
        'txt_TenTat
        '
        Me.txt_TenTat.Location = New System.Drawing.Point(684, 131)
        Me.txt_TenTat.Name = "txt_TenTat"
        Me.txt_TenTat.Size = New System.Drawing.Size(327, 20)
        Me.txt_TenTat.TabIndex = 23
        Me.txt_TenTat.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(590, 134)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Tên viết tắt"
        Me.Label1.Visible = False
        '
        'txt_TenTiengAnh
        '
        Me.txt_TenTiengAnh.Location = New System.Drawing.Point(271, 242)
        Me.txt_TenTiengAnh.Name = "txt_TenTiengAnh"
        Me.txt_TenTiengAnh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_TenTiengAnh.Size = New System.Drawing.Size(327, 20)
        Me.txt_TenTiengAnh.TabIndex = 25
        Me.txt_TenTiengAnh.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(168, 242)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Tên tiếng Anh:"
        Me.Label3.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.mnTienLuong)
        Me.GroupBox1.Controls.Add(Me.cmdThuchien)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.cmdThoat)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.picAnhNguoiDung)
        Me.GroupBox1.Controls.Add(Me.txtTraiTuyen)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtFTP_User)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtFTP_Pass)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtFTP_IP)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txt_Email)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtMaDKKCBBD)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_SDT)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_DiaChi)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_TenTat)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_TenPK)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 208)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = Global.PhongKham.My.Resources.Resources.Document_2_Remove
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(184, 151)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(98, 30)
        Me.Button4.TabIndex = 134
        Me.Button4.Text = "GetText"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'mnTienLuong
        '
        Me.mnTienLuong.Location = New System.Drawing.Point(109, 270)
        Me.mnTienLuong.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.mnTienLuong.Name = "mnTienLuong"
        Me.mnTienLuong.Size = New System.Drawing.Size(120, 20)
        Me.mnTienLuong.TabIndex = 133
        Me.mnTienLuong.Visible = False
        '
        'cmdThuchien
        '
        Me.cmdThuchien.BackColor = System.Drawing.Color.Transparent
        Me.cmdThuchien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThuchien.Image = CType(resources.GetObject("cmdThuchien.Image"), System.Drawing.Image)
        Me.cmdThuchien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThuchien.Location = New System.Drawing.Point(379, 153)
        Me.cmdThuchien.Name = "cmdThuchien"
        Me.cmdThuchien.Size = New System.Drawing.Size(105, 30)
        Me.cmdThuchien.TabIndex = 53
        Me.cmdThuchien.Text = "     &Thực hiện"
        Me.cmdThuchien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThuchien.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optInNhiet)
        Me.GroupBox4.Controls.Add(Me.optInLazer)
        Me.GroupBox4.Controls.Add(Me.CheckBox15)
        Me.GroupBox4.Controls.Add(Me.CheckBox16)
        Me.GroupBox4.Location = New System.Drawing.Point(594, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(283, 95)
        Me.GroupBox4.TabIndex = 132
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tùy chọn kiểu máy in phiếu khám bệnh"
        Me.GroupBox4.Visible = False
        '
        'optInNhiet
        '
        Me.optInNhiet.AutoSize = True
        Me.optInNhiet.Checked = True
        Me.optInNhiet.Location = New System.Drawing.Point(10, 54)
        Me.optInNhiet.Name = "optInNhiet"
        Me.optInNhiet.Size = New System.Drawing.Size(84, 17)
        Me.optInNhiet.TabIndex = 7
        Me.optInNhiet.TabStop = True
        Me.optInNhiet.Text = "Máy in Nhiệt"
        Me.optInNhiet.UseVisualStyleBackColor = True
        '
        'optInLazer
        '
        Me.optInLazer.AutoSize = True
        Me.optInLazer.Location = New System.Drawing.Point(10, 31)
        Me.optInLazer.Name = "optInLazer"
        Me.optInLazer.Size = New System.Drawing.Size(85, 17)
        Me.optInLazer.TabIndex = 6
        Me.optInLazer.Text = "Máy in Lazer"
        Me.optInLazer.UseVisualStyleBackColor = True
        '
        'CheckBox15
        '
        Me.CheckBox15.AutoSize = True
        Me.CheckBox15.Location = New System.Drawing.Point(136, 240)
        Me.CheckBox15.Name = "CheckBox15"
        Me.CheckBox15.Size = New System.Drawing.Size(57, 17)
        Me.CheckBox15.TabIndex = 1
        Me.CheckBox15.Text = "Đơn vị"
        Me.CheckBox15.UseVisualStyleBackColor = True
        Me.CheckBox15.Visible = False
        '
        'CheckBox16
        '
        Me.CheckBox16.AutoSize = True
        Me.CheckBox16.Location = New System.Drawing.Point(136, 263)
        Me.CheckBox16.Name = "CheckBox16"
        Me.CheckBox16.Size = New System.Drawing.Size(66, 17)
        Me.CheckBox16.TabIndex = 5
        Me.CheckBox16.Text = "Chức vụ"
        Me.CheckBox16.UseVisualStyleBackColor = True
        Me.CheckBox16.Visible = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.Color.Transparent
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(496, 153)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(92, 30)
        Me.cmdThoat.TabIndex = 52
        Me.cmdThoat.Text = "     T&hoát"
        Me.cmdThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(28, 184)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 13)
        Me.Label12.TabIndex = 131
        Me.Label12.Text = "Logo phòng khám"
        Me.Label12.Visible = False
        '
        'picAnhNguoiDung
        '
        Me.picAnhNguoiDung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picAnhNguoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picAnhNguoiDung.Location = New System.Drawing.Point(18, 21)
        Me.picAnhNguoiDung.Name = "picAnhNguoiDung"
        Me.picAnhNguoiDung.Size = New System.Drawing.Size(120, 160)
        Me.picAnhNguoiDung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAnhNguoiDung.TabIndex = 130
        Me.picAnhNguoiDung.TabStop = False
        Me.picAnhNguoiDung.Visible = False
        '
        'txtTraiTuyen
        '
        Me.txtTraiTuyen.Location = New System.Drawing.Point(109, 250)
        Me.txtTraiTuyen.Name = "txtTraiTuyen"
        Me.txtTraiTuyen.Size = New System.Drawing.Size(327, 20)
        Me.txtTraiTuyen.TabIndex = 41
        Me.txtTraiTuyen.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 275)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Lương tối thiểu:"
        Me.Label13.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 253)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 13)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "% trái tuyến:"
        Me.Label11.Visible = False
        '
        'txtFTP_User
        '
        Me.txtFTP_User.Location = New System.Drawing.Point(109, 322)
        Me.txtFTP_User.Name = "txtFTP_User"
        Me.txtFTP_User.Size = New System.Drawing.Size(327, 20)
        Me.txtFTP_User.TabIndex = 39
        Me.txtFTP_User.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 325)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "ftpUserID:"
        Me.Label8.Visible = False
        '
        'txtFTP_Pass
        '
        Me.txtFTP_Pass.Location = New System.Drawing.Point(109, 351)
        Me.txtFTP_Pass.Name = "txtFTP_Pass"
        Me.txtFTP_Pass.Size = New System.Drawing.Size(327, 20)
        Me.txtFTP_Pass.TabIndex = 37
        Me.txtFTP_Pass.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 354)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "ftpPassword:"
        Me.Label9.Visible = False
        '
        'txtFTP_IP
        '
        Me.txtFTP_IP.Location = New System.Drawing.Point(109, 296)
        Me.txtFTP_IP.Name = "txtFTP_IP"
        Me.txtFTP_IP.Size = New System.Drawing.Size(327, 20)
        Me.txtFTP_IP.TabIndex = 35
        Me.txtFTP_IP.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 299)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "ftpServerIP:"
        Me.Label10.Visible = False
        '
        'txt_Email
        '
        Me.txt_Email.Location = New System.Drawing.Point(261, 105)
        Me.txt_Email.Name = "txt_Email"
        Me.txt_Email.Size = New System.Drawing.Size(327, 20)
        Me.txt_Email.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(156, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "E mail:"
        '
        'txtMaDKKCBBD
        '
        Me.txtMaDKKCBBD.Location = New System.Drawing.Point(109, 218)
        Me.txtMaDKKCBBD.Name = "txtMaDKKCBBD"
        Me.txtMaDKKCBBD.Size = New System.Drawing.Size(327, 20)
        Me.txtMaDKKCBBD.TabIndex = 31
        Me.txtMaDKKCBBD.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 221)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Mã ĐKKCBBĐ:"
        Me.Label6.Visible = False
        '
        'txt_SDT
        '
        Me.txt_SDT.Location = New System.Drawing.Point(261, 78)
        Me.txt_SDT.Name = "txt_SDT"
        Me.txt_SDT.Size = New System.Drawing.Size(327, 20)
        Me.txt_SDT.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(156, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Điện thoại:"
        '
        'txt_DiaChi
        '
        Me.txt_DiaChi.Location = New System.Drawing.Point(261, 51)
        Me.txt_DiaChi.Name = "txt_DiaChi"
        Me.txt_DiaChi.Size = New System.Drawing.Size(327, 20)
        Me.txt_DiaChi.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Địa chỉ:"
        '
        'menuChonAnh
        '
        Me.menuChonAnh.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuChonAnh, Me.mnuXoaAnh})
        Me.menuChonAnh.Name = "menuChonAnh"
        Me.menuChonAnh.Size = New System.Drawing.Size(127, 48)
        '
        'mnuChonAnh
        '
        Me.mnuChonAnh.Name = "mnuChonAnh"
        Me.mnuChonAnh.Size = New System.Drawing.Size(126, 22)
        Me.mnuChonAnh.Text = "Chọn ảnh"
        '
        'mnuXoaAnh
        '
        Me.mnuXoaAnh.Name = "mnuXoaAnh"
        Me.mnuXoaAnh.Size = New System.Drawing.Size(126, 22)
        Me.mnuXoaAnh.Text = "Xóa ảnh"
        '
        'frmKhaiBaoHeThong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(610, 219)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_TenTiengAnh)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmKhaiBaoHeThong"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.mnTienLuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.picAnhNguoiDung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuChonAnh.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_TenPK As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_TenTat As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_TenTiengAnh As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdThuchien As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents txt_DiaChi As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMaDKKCBBD As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_SDT As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Email As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFTP_User As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFTP_Pass As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFTP_IP As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTraiTuyen As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents menuChonAnh As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnuChonAnh As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuXoaAnh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents picAnhNguoiDung As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents optInNhiet As System.Windows.Forms.RadioButton
    Friend WithEvents optInLazer As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox15 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox16 As System.Windows.Forms.CheckBox
    Friend WithEvents mnTienLuong As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button4 As Button
End Class
