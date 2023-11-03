<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChange_Pass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChange_Pass))
        Me.txtOld_Pass = New System.Windows.Forms.TextBox()
        Me.lbl_PassOld = New System.Windows.Forms.Label()
        Me.txtNew_Pass = New System.Windows.Forms.TextBox()
        Me.lbl_PassNew = New System.Windows.Forms.Label()
        Me.txtConf_Newpass = New System.Windows.Forms.TextBox()
        Me.lbl_Confirm = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdThuchien = New System.Windows.Forms.Button()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOld_Pass
        '
        Me.txtOld_Pass.Location = New System.Drawing.Point(95, 26)
        Me.txtOld_Pass.Name = "txtOld_Pass"
        Me.txtOld_Pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOld_Pass.Size = New System.Drawing.Size(257, 20)
        Me.txtOld_Pass.TabIndex = 21
        '
        'lbl_PassOld
        '
        Me.lbl_PassOld.AutoSize = True
        Me.lbl_PassOld.Location = New System.Drawing.Point(6, 29)
        Me.lbl_PassOld.Name = "lbl_PassOld"
        Me.lbl_PassOld.Size = New System.Drawing.Size(70, 13)
        Me.lbl_PassOld.TabIndex = 22
        Me.lbl_PassOld.Text = "Mật khẩu cũ:"
        '
        'txtNew_Pass
        '
        Me.txtNew_Pass.Location = New System.Drawing.Point(95, 58)
        Me.txtNew_Pass.Name = "txtNew_Pass"
        Me.txtNew_Pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNew_Pass.Size = New System.Drawing.Size(257, 20)
        Me.txtNew_Pass.TabIndex = 23
        '
        'lbl_PassNew
        '
        Me.lbl_PassNew.AutoSize = True
        Me.lbl_PassNew.Location = New System.Drawing.Point(6, 61)
        Me.lbl_PassNew.Name = "lbl_PassNew"
        Me.lbl_PassNew.Size = New System.Drawing.Size(74, 13)
        Me.lbl_PassNew.TabIndex = 24
        Me.lbl_PassNew.Text = "Mật khẩu mới:"
        '
        'txtConf_Newpass
        '
        Me.txtConf_Newpass.Location = New System.Drawing.Point(95, 90)
        Me.txtConf_Newpass.Name = "txtConf_Newpass"
        Me.txtConf_Newpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConf_Newpass.Size = New System.Drawing.Size(257, 20)
        Me.txtConf_Newpass.TabIndex = 25
        '
        'lbl_Confirm
        '
        Me.lbl_Confirm.AutoSize = True
        Me.lbl_Confirm.Location = New System.Drawing.Point(7, 93)
        Me.lbl_Confirm.Name = "lbl_Confirm"
        Me.lbl_Confirm.Size = New System.Drawing.Size(69, 13)
        Me.lbl_Confirm.TabIndex = 26
        Me.lbl_Confirm.Text = "Xác nhận lại:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtConf_Newpass)
        Me.GroupBox1.Controls.Add(Me.lbl_Confirm)
        Me.GroupBox1.Controls.Add(Me.txtNew_Pass)
        Me.GroupBox1.Controls.Add(Me.lbl_PassNew)
        Me.GroupBox1.Controls.Add(Me.txtOld_Pass)
        Me.GroupBox1.Controls.Add(Me.lbl_PassOld)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 130)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'cmdThuchien
        '
        Me.cmdThuchien.BackColor = System.Drawing.Color.Transparent
        Me.cmdThuchien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThuchien.Image = CType(resources.GetObject("cmdThuchien.Image"), System.Drawing.Image)
        Me.cmdThuchien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThuchien.Location = New System.Drawing.Point(183, 149)
        Me.cmdThuchien.Name = "cmdThuchien"
        Me.cmdThuchien.Size = New System.Drawing.Size(100, 30)
        Me.cmdThuchien.TabIndex = 53
        Me.cmdThuchien.Text = "&Thực hiện"
        Me.cmdThuchien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThuchien.UseVisualStyleBackColor = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.Color.Transparent
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(290, 149)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(87, 30)
        Me.cmdThoat.TabIndex = 52
        Me.cmdThoat.Text = "     T&hoát"
        Me.cmdThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'frmChange_Pass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(394, 191)
        Me.Controls.Add(Me.cmdThuchien)
        Me.Controls.Add(Me.cmdThoat)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChange_Pass"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtOld_Pass As System.Windows.Forms.TextBox
    Friend WithEvents lbl_PassOld As System.Windows.Forms.Label
    Friend WithEvents txtNew_Pass As System.Windows.Forms.TextBox
    Friend WithEvents lbl_PassNew As System.Windows.Forms.Label
    Friend WithEvents txtConf_Newpass As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Confirm As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdThuchien As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
End Class
