<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackup
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackup))
        Me.grpMain = New DevExpress.XtraEditors.GroupControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdChonFile = New System.Windows.Forms.Button
        Me.lblTenFile = New System.Windows.Forms.Label
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.cmdThucHien = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        CType(Me.grpMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpMain
        '
        Me.grpMain.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.grpMain.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpMain.Appearance.Options.UseBackColor = True
        Me.grpMain.Appearance.Options.UseBorderColor = True
        Me.grpMain.AppearanceCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMain.AppearanceCaption.Options.UseFont = True
        Me.grpMain.Controls.Add(Me.Panel1)
        Me.grpMain.Controls.Add(Me.cmdThoat)
        Me.grpMain.Controls.Add(Me.cmdThucHien)
        Me.grpMain.Location = New System.Drawing.Point(2, 2)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(324, 137)
        Me.grpMain.TabIndex = 261
        Me.grpMain.Text = "Nhập tên file dữ liệu"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdChonFile)
        Me.Panel1.Controls.Add(Me.lblTenFile)
        Me.Panel1.Location = New System.Drawing.Point(4, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(314, 43)
        Me.Panel1.TabIndex = 265
        '
        'cmdChonFile
        '
        Me.cmdChonFile.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdChonFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChonFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChonFile.Location = New System.Drawing.Point(278, 6)
        Me.cmdChonFile.Name = "cmdChonFile"
        Me.cmdChonFile.Size = New System.Drawing.Size(33, 30)
        Me.cmdChonFile.TabIndex = 265
        Me.cmdChonFile.Text = "..."
        '
        'lblTenFile
        '
        Me.lblTenFile.BackColor = System.Drawing.SystemColors.Info
        Me.lblTenFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTenFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenFile.Location = New System.Drawing.Point(5, 4)
        Me.lblTenFile.Name = "lblTenFile"
        Me.lblTenFile.Size = New System.Drawing.Size(270, 34)
        Me.lblTenFile.TabIndex = 0
        Me.lblTenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdThoat
        '
        Me.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(170, 89)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(90, 30)
        Me.cmdThoat.TabIndex = 264
        Me.cmdThoat.Text = "     Đóng lại"
        '
        'cmdThucHien
        '
        Me.cmdThucHien.Image = CType(resources.GetObject("cmdThucHien.Image"), System.Drawing.Image)
        Me.cmdThucHien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThucHien.Location = New System.Drawing.Point(67, 89)
        Me.cmdThucHien.Name = "cmdThucHien"
        Me.cmdThucHien.Size = New System.Drawing.Size(90, 30)
        Me.cmdThucHien.TabIndex = 263
        Me.cmdThucHien.Text = "Thực hiện"
        Me.cmdThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder.png")
        Me.ImageList1.Images.SetKeyName(1, "stop.png")
        Me.ImageList1.Images.SetKeyName(2, "Select.ico")
        '
        'frmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.ClientSize = New System.Drawing.Size(328, 141)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gửi dữ liệu lên cấp trên"
        Me.TopMost = True
        CType(Me.grpMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMain.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents grpMain As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents cmdThucHien As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTenFile As System.Windows.Forms.Label
    Friend WithEvents cmdChonFile As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
