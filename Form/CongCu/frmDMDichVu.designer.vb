<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDMDichVu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDMDichVu))
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
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
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbPhieuCD = New C1.Win.C1List.C1Combo()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtThutuBYT = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDonGia = New System.Windows.Forms.NumericUpDown()
        Me.txtDVT = New System.Windows.Forms.TextBox()
        Me.label9 = New System.Windows.Forms.Label()
        Me.txtTentat = New System.Windows.Forms.TextBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.chkKhongSuDung = New System.Windows.Forms.CheckBox()
        Me.txtGhiChu = New System.Windows.Forms.TextBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtMaDichVu = New System.Windows.Forms.MaskedTextBox()
        Me.txtTenDichVu = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmbLoaiDichVu = New C1.Win.C1List.C1Combo()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdThem = New System.Windows.Forms.Button()
        Me.btn_GetText = New System.Windows.Forms.Button()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSua = New System.Windows.Forms.Button()
        Me.cmdXoa = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.groupBox1.SuspendLayout()
        CType(Me.cmbPhieuCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDonGia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLoaiDichVu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.cmbPhieuCD)
        Me.groupBox1.Controls.Add(Me.Label16)
        Me.groupBox1.Controls.Add(Me.txtThutuBYT)
        Me.groupBox1.Controls.Add(Me.Label13)
        Me.groupBox1.Controls.Add(Me.txtDonGia)
        Me.groupBox1.Controls.Add(Me.txtDVT)
        Me.groupBox1.Controls.Add(Me.label9)
        Me.groupBox1.Controls.Add(Me.txtTentat)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.chkKhongSuDung)
        Me.groupBox1.Controls.Add(Me.txtGhiChu)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.txtMaDichVu)
        Me.groupBox1.Controls.Add(Me.txtTenDichVu)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Location = New System.Drawing.Point(492, -3)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(754, 215)
        Me.groupBox1.TabIndex = 75
        Me.groupBox1.TabStop = False
        '
        'cmbPhieuCD
        '
        Me.cmbPhieuCD.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbPhieuCD.AllowColMove = False
        Me.cmbPhieuCD.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbPhieuCD.AutoCompletion = True
        Me.cmbPhieuCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbPhieuCD.Caption = ""
        Me.cmbPhieuCD.CaptionHeight = 17
        Me.cmbPhieuCD.CaptionStyle = Style1
        Me.cmbPhieuCD.CaptionVisible = False
        Me.cmbPhieuCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbPhieuCD.ColumnCaptionHeight = 17
        Me.cmbPhieuCD.ColumnFooterHeight = 17
        Me.cmbPhieuCD.ColumnHeaders = False
        Me.cmbPhieuCD.ContentHeight = 16
        Me.cmbPhieuCD.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.cmbPhieuCD.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbPhieuCD.DefColWidth = 30
        Me.cmbPhieuCD.DisplayMember = "Danh mục"
        Me.cmbPhieuCD.EditorBackColor = System.Drawing.Color.White
        Me.cmbPhieuCD.EditorFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPhieuCD.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbPhieuCD.EditorHeight = 16
        Me.cmbPhieuCD.EvenRowStyle = Style2
        Me.cmbPhieuCD.ExtendRightColumn = True
        Me.cmbPhieuCD.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbPhieuCD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPhieuCD.FooterStyle = Style3
        Me.cmbPhieuCD.GapHeight = 2
        Me.cmbPhieuCD.HeadingStyle = Style4
        Me.cmbPhieuCD.HighLightRowStyle = Style5
        Me.cmbPhieuCD.ItemHeight = 15
        Me.cmbPhieuCD.Location = New System.Drawing.Point(360, 150)
        Me.cmbPhieuCD.MatchCol = C1.Win.C1List.MatchColEnum.AllCols
        Me.cmbPhieuCD.MatchEntryTimeout = CType(2000, Long)
        Me.cmbPhieuCD.MaxDropDownItems = CType(10, Short)
        Me.cmbPhieuCD.MaxLength = 32767
        Me.cmbPhieuCD.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbPhieuCD.Name = "cmbPhieuCD"
        Me.cmbPhieuCD.OddRowStyle = Style6
        Me.cmbPhieuCD.PartialRightColumn = False
        Me.cmbPhieuCD.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbPhieuCD.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbPhieuCD.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbPhieuCD.SelectedStyle = Style7
        Me.cmbPhieuCD.Size = New System.Drawing.Size(198, 20)
        Me.cmbPhieuCD.Style = Style8
        Me.cmbPhieuCD.TabIndex = 67
        Me.cmbPhieuCD.Visible = False
        Me.cmbPhieuCD.PropBag = resources.GetString("cmbPhieuCD.PropBag")
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(271, 152)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 18)
        Me.Label16.TabIndex = 66
        Me.Label16.Text = "Phiếu CĐ:"
        Me.Label16.Visible = False
        '
        'txtThutuBYT
        '
        Me.txtThutuBYT.Location = New System.Drawing.Point(82, 64)
        Me.txtThutuBYT.MaxLength = 255
        Me.txtThutuBYT.Name = "txtThutuBYT"
        Me.txtThutuBYT.Size = New System.Drawing.Size(59, 20)
        Me.txtThutuBYT.TabIndex = 63
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(12, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 18)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Thứ tự:"
        '
        'txtDonGia
        '
        Me.txtDonGia.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtDonGia.Location = New System.Drawing.Point(82, 94)
        Me.txtDonGia.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.txtDonGia.Name = "txtDonGia"
        Me.txtDonGia.Size = New System.Drawing.Size(74, 20)
        Me.txtDonGia.TabIndex = 13
        Me.txtDonGia.ThousandsSeparator = True
        Me.txtDonGia.Value = New Decimal(New Integer() {6000000, 0, 0, 0})
        '
        'txtDVT
        '
        Me.txtDVT.Location = New System.Drawing.Point(82, 37)
        Me.txtDVT.MaxLength = 255
        Me.txtDVT.Name = "txtDVT"
        Me.txtDVT.Size = New System.Drawing.Size(59, 20)
        Me.txtDVT.TabIndex = 5
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(12, 40)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(82, 18)
        Me.label9.TabIndex = 4
        Me.label9.Text = "Đơn vị tính:"
        '
        'txtTentat
        '
        Me.txtTentat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTentat.Location = New System.Drawing.Point(218, 37)
        Me.txtTentat.MaxLength = 255
        Me.txtTentat.Name = "txtTentat"
        Me.txtTentat.Size = New System.Drawing.Size(531, 20)
        Me.txtTentat.TabIndex = 7
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(148, 40)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(72, 18)
        Me.label8.TabIndex = 6
        Me.label8.Text = "Tên viết tắt:"
        '
        'chkKhongSuDung
        '
        Me.chkKhongSuDung.AutoSize = True
        Me.chkKhongSuDung.Location = New System.Drawing.Point(82, 153)
        Me.chkKhongSuDung.Name = "chkKhongSuDung"
        Me.chkKhongSuDung.Size = New System.Drawing.Size(119, 17)
        Me.chkKhongSuDung.TabIndex = 18
        Me.chkKhongSuDung.Text = "Không còn sử dụng"
        Me.chkKhongSuDung.UseVisualStyleBackColor = True
        '
        'txtGhiChu
        '
        Me.txtGhiChu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGhiChu.Location = New System.Drawing.Point(82, 120)
        Me.txtGhiChu.MaxLength = 255
        Me.txtGhiChu.Multiline = True
        Me.txtGhiChu.Name = "txtGhiChu"
        Me.txtGhiChu.Size = New System.Drawing.Size(667, 24)
        Me.txtGhiChu.TabIndex = 17
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(12, 125)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(82, 18)
        Me.label7.TabIndex = 16
        Me.label7.Text = "Ghi chú:"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(12, 96)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(76, 18)
        Me.label5.TabIndex = 12
        Me.label5.Text = "Đơn giá DV:"
        '
        'txtMaDichVu
        '
        Me.txtMaDichVu.AllowPromptAsInput = False
        Me.txtMaDichVu.Location = New System.Drawing.Point(82, 11)
        Me.txtMaDichVu.Mask = "[000]-0000"
        Me.txtMaDichVu.Name = "txtMaDichVu"
        Me.txtMaDichVu.Size = New System.Drawing.Size(59, 20)
        Me.txtMaDichVu.TabIndex = 1
        Me.txtMaDichVu.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtTenDichVu
        '
        Me.txtTenDichVu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTenDichVu.Location = New System.Drawing.Point(218, 11)
        Me.txtTenDichVu.MaxLength = 255
        Me.txtTenDichVu.Multiline = True
        Me.txtTenDichVu.Name = "txtTenDichVu"
        Me.txtTenDichVu.Size = New System.Drawing.Size(531, 20)
        Me.txtTenDichVu.TabIndex = 3
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(148, 14)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(82, 18)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Tên dịch vụ:"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(11, 14)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(82, 18)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Mã dịch vụ:"
        '
        'fg
        '
        Me.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fg.AllowEditing = False
        Me.fg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.ExtendLastCol = True
        Me.fg.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid
        Me.fg.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fg.Location = New System.Drawing.Point(3, 27)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Rows.MinSize = 20
        Me.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fg.ShowCursor = True
        Me.fg.Size = New System.Drawing.Size(454, 584)
        Me.fg.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"))
        Me.fg.TabIndex = 72
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(0, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(75, 18)
        Me.label1.TabIndex = 73
        Me.label1.Text = "Loại dịch vụ"
        '
        'cmbLoaiDichVu
        '
        Me.cmbLoaiDichVu.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbLoaiDichVu.AllowColMove = False
        Me.cmbLoaiDichVu.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbLoaiDichVu.AutoCompletion = True
        Me.cmbLoaiDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbLoaiDichVu.Caption = ""
        Me.cmbLoaiDichVu.CaptionHeight = 17
        Me.cmbLoaiDichVu.CaptionStyle = Style9
        Me.cmbLoaiDichVu.CaptionVisible = False
        Me.cmbLoaiDichVu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbLoaiDichVu.ColumnCaptionHeight = 17
        Me.cmbLoaiDichVu.ColumnFooterHeight = 17
        Me.cmbLoaiDichVu.ColumnHeaders = False
        Me.cmbLoaiDichVu.ContentHeight = 16
        Me.cmbLoaiDichVu.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.cmbLoaiDichVu.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbLoaiDichVu.DefColWidth = 30
        Me.cmbLoaiDichVu.DisplayMember = "Danh mục"
        Me.cmbLoaiDichVu.EditorBackColor = System.Drawing.Color.White
        Me.cmbLoaiDichVu.EditorFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLoaiDichVu.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbLoaiDichVu.EditorHeight = 16
        Me.cmbLoaiDichVu.EvenRowStyle = Style10
        Me.cmbLoaiDichVu.ExtendRightColumn = True
        Me.cmbLoaiDichVu.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbLoaiDichVu.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLoaiDichVu.FooterStyle = Style11
        Me.cmbLoaiDichVu.GapHeight = 2
        Me.cmbLoaiDichVu.HeadingStyle = Style12
        Me.cmbLoaiDichVu.HighLightRowStyle = Style13
        Me.cmbLoaiDichVu.ItemHeight = 15
        Me.cmbLoaiDichVu.Location = New System.Drawing.Point(81, 4)
        Me.cmbLoaiDichVu.MatchCol = C1.Win.C1List.MatchColEnum.AllCols
        Me.cmbLoaiDichVu.MatchEntryTimeout = CType(2000, Long)
        Me.cmbLoaiDichVu.MaxDropDownItems = CType(10, Short)
        Me.cmbLoaiDichVu.MaxLength = 32767
        Me.cmbLoaiDichVu.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbLoaiDichVu.Name = "cmbLoaiDichVu"
        Me.cmbLoaiDichVu.OddRowStyle = Style14
        Me.cmbLoaiDichVu.PartialRightColumn = False
        Me.cmbLoaiDichVu.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbLoaiDichVu.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbLoaiDichVu.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbLoaiDichVu.SelectedStyle = Style15
        Me.cmbLoaiDichVu.Size = New System.Drawing.Size(305, 20)
        Me.cmbLoaiDichVu.Style = Style16
        Me.cmbLoaiDichVu.TabIndex = 74
        Me.cmbLoaiDichVu.PropBag = resources.GetString("cmbLoaiDichVu.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdThem)
        Me.GroupBox2.Controls.Add(Me.btn_GetText)
        Me.GroupBox2.Controls.Add(Me.cmdThoat)
        Me.GroupBox2.Controls.Add(Me.cmdCancel)
        Me.GroupBox2.Controls.Add(Me.cmdSua)
        Me.GroupBox2.Controls.Add(Me.cmdXoa)
        Me.GroupBox2.Controls.Add(Me.cmdOK)
        Me.GroupBox2.Location = New System.Drawing.Point(492, 218)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(754, 50)
        Me.GroupBox2.TabIndex = 79
        Me.GroupBox2.TabStop = False
        '
        'cmdThem
        '
        Me.cmdThem.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdThem.Image = CType(resources.GetObject("cmdThem.Image"), System.Drawing.Image)
        Me.cmdThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThem.Location = New System.Drawing.Point(100, 15)
        Me.cmdThem.Name = "cmdThem"
        Me.cmdThem.Size = New System.Drawing.Size(85, 30)
        Me.cmdThem.TabIndex = 66
        Me.cmdThem.Text = "  &Thêm"
        '
        'btn_GetText
        '
        Me.btn_GetText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_GetText.Location = New System.Drawing.Point(456, 15)
        Me.btn_GetText.Name = "btn_GetText"
        Me.btn_GetText.Size = New System.Drawing.Size(85, 30)
        Me.btn_GetText.TabIndex = 69
        Me.btn_GetText.Text = "Get text"
        Me.btn_GetText.Visible = False
        '
        'cmdThoat
        '
        Me.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(365, 15)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(85, 30)
        Me.cmdThoat.TabIndex = 69
        Me.cmdThoat.Text = " Thoát"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(278, 15)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(85, 30)
        Me.cmdCancel.TabIndex = 71
        Me.cmdCancel.Text = "     &Không ghi"
        '
        'cmdSua
        '
        Me.cmdSua.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSua.Image = CType(resources.GetObject("cmdSua.Image"), System.Drawing.Image)
        Me.cmdSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSua.Location = New System.Drawing.Point(188, 15)
        Me.cmdSua.Name = "cmdSua"
        Me.cmdSua.Size = New System.Drawing.Size(85, 30)
        Me.cmdSua.TabIndex = 67
        Me.cmdSua.Text = "  &Sửa"
        '
        'cmdXoa
        '
        Me.cmdXoa.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdXoa.Image = CType(resources.GetObject("cmdXoa.Image"), System.Drawing.Image)
        Me.cmdXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdXoa.Location = New System.Drawing.Point(277, 14)
        Me.cmdXoa.Name = "cmdXoa"
        Me.cmdXoa.Size = New System.Drawing.Size(85, 30)
        Me.cmdXoa.TabIndex = 68
        Me.cmdXoa.Text = "  &Xóa"
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(188, 15)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(85, 30)
        Me.cmdOK.TabIndex = 70
        Me.cmdOK.Text = "  &Ghi lại"
        '
        'frmDMDichVu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1250, 613)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.fg)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cmbLoaiDichVu)
        Me.Name = "frmDMDichVu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.cmbPhieuCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDonGia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLoaiDichVu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtDVT As System.Windows.Forms.TextBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents txtTentat As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents txtGhiChu As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtDonGia As System.Windows.Forms.NumericUpDown
    Private WithEvents txtMaDichVu As System.Windows.Forms.MaskedTextBox
    Private WithEvents txtTenDichVu As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cmdCancel As System.Windows.Forms.Button
    Private WithEvents cmdXoa As System.Windows.Forms.Button
    Private WithEvents cmdOK As System.Windows.Forms.Button
    Private WithEvents cmdThem As System.Windows.Forms.Button
    Private WithEvents cmdSua As System.Windows.Forms.Button
    Private WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents cmbLoaiDichVu As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents txtThutuBYT As System.Windows.Forms.TextBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbPhieuCD As C1.Win.C1List.C1Combo
    Private WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents chkKhongSuDung As System.Windows.Forms.CheckBox
    Private WithEvents btn_GetText As Button
End Class
