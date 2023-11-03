<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txtTenDangNhap As System.Windows.Forms.TextBox
    Friend WithEvents txtMatKhau As System.Windows.Forms.TextBox
    Friend WithEvents cmdDangNhap As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox
        Me.UsernameLabel = New System.Windows.Forms.Label
        Me.PasswordLabel = New System.Windows.Forms.Label
        Me.txtTenDangNhap = New System.Windows.Forms.TextBox
        Me.txtMatKhau = New System.Windows.Forms.TextBox
        Me.cmdDangNhap = New System.Windows.Forms.Button
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.txtTenMayChu = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkNhoMatKhau = New System.Windows.Forms.CheckBox
        Me.txtNgayLV = New C1.Win.C1Input.C1DateEdit
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgayLV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(304, 53)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(7, 66)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(86, 20)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "Tên đăng nhập:"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(7, 98)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(86, 20)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "Mật khẩu:"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTenDangNhap
        '
        Me.txtTenDangNhap.Location = New System.Drawing.Point(93, 67)
        Me.txtTenDangNhap.Name = "txtTenDangNhap"
        Me.txtTenDangNhap.Size = New System.Drawing.Size(207, 20)
        Me.txtTenDangNhap.TabIndex = 2
        Me.txtTenDangNhap.Text = "Admin"
        '
        'txtMatKhau
        '
        Me.txtMatKhau.Location = New System.Drawing.Point(93, 99)
        Me.txtMatKhau.Name = "txtMatKhau"
        Me.txtMatKhau.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMatKhau.Size = New System.Drawing.Size(207, 20)
        Me.txtMatKhau.TabIndex = 3
        '
        'cmdDangNhap
        '
        Me.cmdDangNhap.Image = CType(resources.GetObject("cmdDangNhap.Image"), System.Drawing.Image)
        Me.cmdDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDangNhap.Location = New System.Drawing.Point(91, 196)
        Me.cmdDangNhap.Name = "cmdDangNhap"
        Me.cmdDangNhap.Size = New System.Drawing.Size(90, 30)
        Me.cmdDangNhap.TabIndex = 5
        Me.cmdDangNhap.Text = "Đăng nhập"
        Me.cmdDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdThoat
        '
        Me.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(194, 196)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(90, 30)
        Me.cmdThoat.TabIndex = 6
        Me.cmdThoat.Text = "Thoát     "
        Me.cmdThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTenMayChu
        '
        Me.txtTenMayChu.Location = New System.Drawing.Point(147, 7)
        Me.txtTenMayChu.Name = "txtTenMayChu"
        Me.txtTenMayChu.Size = New System.Drawing.Size(151, 20)
        Me.txtTenMayChu.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(77, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Server name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkNhoMatKhau
        '
        Me.chkNhoMatKhau.AutoSize = True
        Me.chkNhoMatKhau.Location = New System.Drawing.Point(93, 162)
        Me.chkNhoMatKhau.Name = "chkNhoMatKhau"
        Me.chkNhoMatKhau.Size = New System.Drawing.Size(181, 17)
        Me.chkNhoMatKhau.TabIndex = 4
        Me.chkNhoMatKhau.Text = "Nhớ tên đăng nhập và mật khẩu"
        Me.chkNhoMatKhau.UseVisualStyleBackColor = True
        '
        'txtNgayLV
        '
        Me.txtNgayLV.BackColor = System.Drawing.Color.White
        Me.txtNgayLV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNgayLV.Culture = 1066
        Me.txtNgayLV.CustomFormat = "dd/MM/yyyy"
        Me.txtNgayLV.ForeColor = System.Drawing.Color.Black
        Me.txtNgayLV.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtNgayLV.Location = New System.Drawing.Point(93, 133)
        Me.txtNgayLV.Name = "txtNgayLV"
        Me.txtNgayLV.Size = New System.Drawing.Size(207, 18)
        Me.txtNgayLV.TabIndex = 40
        Me.txtNgayLV.Tag = Nothing
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(147, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(151, 20)
        Me.TextBox1.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(77, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 20)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Password sa:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Ngày làm việc:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmLogin
        '
        Me.AcceptButton = Me.cmdDangNhap
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdThoat
        Me.ClientSize = New System.Drawing.Size(304, 235)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNgayLV)
        Me.Controls.Add(Me.chkNhoMatKhau)
        Me.Controls.Add(Me.txtTenMayChu)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdThoat)
        Me.Controls.Add(Me.cmdDangNhap)
        Me.Controls.Add(Me.txtMatKhau)
        Me.Controls.Add(Me.txtTenDangNhap)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đăng nhập hệ thống"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgayLV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTenMayChu As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkNhoMatKhau As System.Windows.Forms.CheckBox
    Private WithEvents txtNgayLV As C1.Win.C1Input.C1DateEdit
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
