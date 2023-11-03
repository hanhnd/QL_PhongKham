<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKB_DanhSachBNKhamBenh
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKB_DanhSachBNKhamBenh))
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbPhongkham = New C1.Win.C1List.C1Combo()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkTheoNVTD = New System.Windows.Forms.CheckBox()
        Me.cmbDoituong = New C1.Win.C1List.C1Combo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDen = New C1.Win.C1Input.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdInDS = New System.Windows.Forms.Button()
        Me.cmdThongke = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.txtNgaykham = New C1.Win.C1Input.C1DateEdit()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.grdThongkeBN = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbPhongkham, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDoituong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaykham, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdThongkeBN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1019, 34)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "DANH SÁCH BỆNH NHÂN KHÁM BỆNH"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmbPhongkham)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.chkTheoNVTD)
        Me.GroupBox1.Controls.Add(Me.cmbDoituong)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmdInDS)
        Me.GroupBox1.Controls.Add(Me.cmdThongke)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cmdThoat)
        Me.GroupBox1.Controls.Add(Me.txtNgaykham)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1019, 64)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'cmbPhongkham
        '
        Me.cmbPhongkham.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbPhongkham.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbPhongkham.AutoCompletion = True
        Me.cmbPhongkham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbPhongkham.Caption = ""
        Me.cmbPhongkham.CaptionHeight = 17
        Me.cmbPhongkham.CaptionStyle = Style1
        Me.cmbPhongkham.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbPhongkham.ColumnCaptionHeight = 17
        Me.cmbPhongkham.ColumnFooterHeight = 17
        Me.cmbPhongkham.ColumnHeaders = False
        Me.cmbPhongkham.ContentHeight = 15
        Me.cmbPhongkham.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbPhongkham.DefColWidth = 50
        Me.cmbPhongkham.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cmbPhongkham.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPhongkham.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPhongkham.EditorHeight = 15
        Me.cmbPhongkham.EvenRowStyle = Style2
        Me.cmbPhongkham.ExtendRightColumn = True
        Me.cmbPhongkham.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbPhongkham.FooterStyle = Style3
        Me.cmbPhongkham.GapHeight = 2
        Me.cmbPhongkham.HeadingStyle = Style4
        Me.cmbPhongkham.HighLightRowStyle = Style5
        Me.cmbPhongkham.ItemHeight = 15
        Me.cmbPhongkham.Location = New System.Drawing.Point(454, 15)
        Me.cmbPhongkham.MatchEntryTimeout = CType(2000, Long)
        Me.cmbPhongkham.MaxDropDownItems = CType(5, Short)
        Me.cmbPhongkham.MaxLength = 32767
        Me.cmbPhongkham.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbPhongkham.Name = "cmbPhongkham"
        Me.cmbPhongkham.OddRowStyle = Style6
        Me.cmbPhongkham.PartialRightColumn = False
        Me.cmbPhongkham.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbPhongkham.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbPhongkham.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbPhongkham.SelectedStyle = Style7
        Me.cmbPhongkham.Size = New System.Drawing.Size(134, 19)
        Me.cmbPhongkham.Style = Style8
        Me.cmbPhongkham.TabIndex = 82
        Me.cmbPhongkham.PropBag = resources.GetString("cmbPhongkham.PropBag")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(384, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 14)
        Me.Label15.TabIndex = 83
        Me.Label15.Text = "Phòng khám:"
        Me.Label15.Visible = False
        '
        'chkTheoNVTD
        '
        Me.chkTheoNVTD.AutoSize = True
        Me.chkTheoNVTD.Location = New System.Drawing.Point(8, 40)
        Me.chkTheoNVTD.Name = "chkTheoNVTD"
        Me.chkTheoNVTD.Size = New System.Drawing.Size(185, 18)
        Me.chkTheoNVTD.TabIndex = 81
        Me.chkTheoNVTD.Text = "Thống kê theo nhân viên tiếp đón"
        Me.chkTheoNVTD.UseVisualStyleBackColor = True
        Me.chkTheoNVTD.Visible = False
        '
        'cmbDoituong
        '
        Me.cmbDoituong.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbDoituong.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbDoituong.AutoCompletion = True
        Me.cmbDoituong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbDoituong.Caption = ""
        Me.cmbDoituong.CaptionHeight = 17
        Me.cmbDoituong.CaptionStyle = Style9
        Me.cmbDoituong.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbDoituong.ColumnCaptionHeight = 17
        Me.cmbDoituong.ColumnFooterHeight = 17
        Me.cmbDoituong.ColumnHeaders = False
        Me.cmbDoituong.ContentHeight = 15
        Me.cmbDoituong.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbDoituong.DefColWidth = 30
        Me.cmbDoituong.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cmbDoituong.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDoituong.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDoituong.EditorHeight = 15
        Me.cmbDoituong.Enabled = False
        Me.cmbDoituong.EvenRowStyle = Style10
        Me.cmbDoituong.ExtendRightColumn = True
        Me.cmbDoituong.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbDoituong.FooterStyle = Style11
        Me.cmbDoituong.GapHeight = 2
        Me.cmbDoituong.HeadingStyle = Style12
        Me.cmbDoituong.HighLightRowStyle = Style13
        Me.cmbDoituong.ItemHeight = 15
        Me.cmbDoituong.Location = New System.Drawing.Point(521, 64)
        Me.cmbDoituong.MatchEntryTimeout = CType(2000, Long)
        Me.cmbDoituong.MaxDropDownItems = CType(5, Short)
        Me.cmbDoituong.MaxLength = 32767
        Me.cmbDoituong.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbDoituong.Name = "cmbDoituong"
        Me.cmbDoituong.OddRowStyle = Style14
        Me.cmbDoituong.PartialRightColumn = False
        Me.cmbDoituong.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbDoituong.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbDoituong.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbDoituong.SelectedStyle = Style15
        Me.cmbDoituong.Size = New System.Drawing.Size(168, 19)
        Me.cmbDoituong.Style = Style16
        Me.cmbDoituong.TabIndex = 79
        Me.cmbDoituong.Visible = False
        Me.cmbDoituong.PropBag = resources.GetString("cmbDoituong.PropBag")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(461, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 14)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Đối tượng:"
        Me.Label4.Visible = False
        '
        'txtDen
        '
        Me.txtDen.BackColor = System.Drawing.Color.White
        Me.txtDen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDen.Culture = 1066
        Me.txtDen.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtDen.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtDen.Location = New System.Drawing.Point(256, 16)
        Me.txtDen.Name = "txtDen"
        Me.txtDen.Size = New System.Drawing.Size(125, 18)
        Me.txtDen.TabIndex = 51
        Me.txtDen.Tag = Nothing
        Me.txtDen.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(224, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 14)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "đến:"
        '
        'cmdInDS
        '
        Me.cmdInDS.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdInDS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInDS.Image = CType(resources.GetObject("cmdInDS.Image"), System.Drawing.Image)
        Me.cmdInDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdInDS.Location = New System.Drawing.Point(720, 12)
        Me.cmdInDS.Name = "cmdInDS"
        Me.cmdInDS.Size = New System.Drawing.Size(96, 32)
        Me.cmdInDS.TabIndex = 50
        Me.cmdInDS.Text = "&Xuất Excel"
        Me.cmdInDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdInDS.UseVisualStyleBackColor = False
        '
        'cmdThongke
        '
        Me.cmdThongke.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdThongke.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThongke.Image = CType(resources.GetObject("cmdThongke.Image"), System.Drawing.Image)
        Me.cmdThongke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThongke.Location = New System.Drawing.Point(616, 12)
        Me.cmdThongke.Name = "cmdThongke"
        Me.cmdThongke.Size = New System.Drawing.Size(96, 32)
        Me.cmdThongke.TabIndex = 49
        Me.cmdThongke.Text = " &Thống kê"
        Me.cmdThongke.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThongke.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(922, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 32)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Get text"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(820, 12)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(96, 32)
        Me.cmdThoat.TabIndex = 48
        Me.cmdThoat.Text = "     T&hoát"
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'txtNgaykham
        '
        Me.txtNgaykham.BackColor = System.Drawing.Color.White
        Me.txtNgaykham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNgaykham.Culture = 1066
        Me.txtNgaykham.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtNgaykham.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtNgaykham.Location = New System.Drawing.Point(99, 17)
        Me.txtNgaykham.Name = "txtNgaykham"
        Me.txtNgaykham.Size = New System.Drawing.Size(125, 18)
        Me.txtNgaykham.TabIndex = 44
        Me.txtNgaykham.Tag = Nothing
        Me.txtNgaykham.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 14)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Đăng ký khám từ:"
        '
        'grdThongkeBN
        '
        Me.grdThongkeBN.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.grdThongkeBN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdThongkeBN.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdThongkeBN.ColumnInfo = resources.GetString("grdThongkeBN.ColumnInfo")
        Me.grdThongkeBN.ExtendLastCol = True
        Me.grdThongkeBN.Location = New System.Drawing.Point(5, 112)
        Me.grdThongkeBN.Name = "grdThongkeBN"
        Me.grdThongkeBN.Rows.Count = 1
        Me.grdThongkeBN.Rows.MinSize = 20
        Me.grdThongkeBN.Size = New System.Drawing.Size(1019, 505)
        Me.grdThongkeBN.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdThongkeBN.Styles"))
        Me.grdThongkeBN.TabIndex = 58
        '
        'frmKB_DanhSachBNKhamBenh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1028, 644)
        Me.Controls.Add(Me.grdThongkeBN)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmKB_DanhSachBNKhamBenh"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbPhongkham, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDoituong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaykham, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdThongkeBN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNgaykham As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents grdThongkeBN As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdThongke As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents cmdInDS As System.Windows.Forms.Button
    Friend WithEvents txtDen As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDoituong As C1.Win.C1List.C1Combo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkTheoNVTD As System.Windows.Forms.CheckBox
    Friend WithEvents cmbPhongkham As C1.Win.C1List.C1Combo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button1 As Button
End Class
