<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.LabelCompanyName = New System.Windows.Forms.TextBox()
        Me.LabelCopyright = New System.Windows.Forms.TextBox()
        Me.LabelVersion = New System.Windows.Forms.TextBox()
        Me.LabelProductName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = Global.PhongKham.My.Resources.Resources.gara24h
        Me.LogoPictureBox.Location = New System.Drawing.Point(14, 12)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(95, 96)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 5
        Me.LogoPictureBox.TabStop = False
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(15, 127)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(395, 114)
        Me.TextBoxDescription.TabIndex = 2
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = "Mô tả:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (Phần mềm Quản lý Phòng khám)"
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(335, 247)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 26)
        Me.OKButton.TabIndex = 3
        Me.OKButton.Text = "&OK"
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabelCompanyName.Location = New System.Drawing.Point(127, 37)
        Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.LabelCompanyName.Multiline = True
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.ReadOnly = True
        Me.LabelCompanyName.Size = New System.Drawing.Size(281, 17)
        Me.LabelCompanyName.TabIndex = 8
        Me.LabelCompanyName.TabStop = False
        Me.LabelCompanyName.Text = "Mô tả:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (Phần mềm Quản lý Phòng khám)"
        '
        'LabelCopyright
        '
        Me.LabelCopyright.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabelCopyright.Location = New System.Drawing.Point(127, 82)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.LabelCopyright.Multiline = True
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.ReadOnly = True
        Me.LabelCopyright.Size = New System.Drawing.Size(279, 17)
        Me.LabelCopyright.TabIndex = 9
        Me.LabelCopyright.TabStop = False
        Me.LabelCopyright.Text = "Mô tả:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (Phần mềm Quản lý Phòng khám)"
        '
        'LabelVersion
        '
        Me.LabelVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabelVersion.Location = New System.Drawing.Point(127, 59)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.LabelVersion.Multiline = True
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.ReadOnly = True
        Me.LabelVersion.Size = New System.Drawing.Size(280, 17)
        Me.LabelVersion.TabIndex = 10
        Me.LabelVersion.TabStop = False
        Me.LabelVersion.Text = "Mô tả:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (Phần mềm Quản lý Phòng khám)"
        '
        'LabelProductName
        '
        Me.LabelProductName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabelProductName.Location = New System.Drawing.Point(127, 17)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.LabelProductName.Multiline = True
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.ReadOnly = True
        Me.LabelProductName.Size = New System.Drawing.Size(278, 21)
        Me.LabelProductName.TabIndex = 11
        Me.LabelProductName.TabStop = False
        Me.LabelProductName.Text = "Mô tả:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (Phần mềm Quản lý Phòng khám)"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(117, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(293, 96)
        Me.Panel1.TabIndex = 12
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 276)
        Me.Controls.Add(Me.LabelProductName)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.LabelCopyright)
        Me.Controls.Add(Me.LabelCompanyName)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents LabelCopyright As System.Windows.Forms.TextBox
    Friend WithEvents LabelVersion As System.Windows.Forms.TextBox
    Friend WithEvents LabelProductName As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
