<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuanTriNguoiDung
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuanTriNguoiDung))
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
        Me.cmbChuongTrinh = New C1.Win.C1List.C1Combo()
        Me.mnuChonAnh = New System.Windows.Forms.ToolStripMenuItem()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.chkPass_editable = New System.Windows.Forms.CheckBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.fgFunct = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.menuChonAnh = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuXoaAnh = New System.Windows.Forms.ToolStripMenuItem()
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdUser = New System.Windows.Forms.RadioButton()
        Me.rdAdmin = New System.Windows.Forms.RadioButton()
        Me.cmbKhoa = New C1.Win.C1List.C1Combo()
        Me.label12 = New System.Windows.Forms.Label()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.label6 = New System.Windows.Forms.Label()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.picAnhNguoiDung = New System.Windows.Forms.PictureBox()
        Me.picChuKy = New System.Windows.Forms.PictureBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.fgUser = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdThem = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdXoaUser = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdGhiUser = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.cmbChuongTrinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage2.SuspendLayout()
        CType(Me.fgFunct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuChonAnh.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.cmbKhoa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        CType(Me.picAnhNguoiDung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChuKy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbChuongTrinh
        '
        Me.cmbChuongTrinh.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbChuongTrinh.AllowColMove = False
        Me.cmbChuongTrinh.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbChuongTrinh.AutoCompletion = True
        Me.cmbChuongTrinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbChuongTrinh.Caption = ""
        Me.cmbChuongTrinh.CaptionHeight = 17
        Me.cmbChuongTrinh.CaptionStyle = Style1
        Me.cmbChuongTrinh.CaptionVisible = False
        Me.cmbChuongTrinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbChuongTrinh.ColumnCaptionHeight = 17
        Me.cmbChuongTrinh.ColumnFooterHeight = 17
        Me.cmbChuongTrinh.ColumnHeaders = False
        Me.cmbChuongTrinh.ContentHeight = 16
        Me.cmbChuongTrinh.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.cmbChuongTrinh.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbChuongTrinh.DefColWidth = 30
        Me.cmbChuongTrinh.DisplayMember = "Danh mục"
        Me.cmbChuongTrinh.EditorBackColor = System.Drawing.Color.White
        Me.cmbChuongTrinh.EditorFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChuongTrinh.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbChuongTrinh.EditorHeight = 16
        Me.cmbChuongTrinh.EvenRowStyle = Style2
        Me.cmbChuongTrinh.ExtendRightColumn = True
        Me.cmbChuongTrinh.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbChuongTrinh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbChuongTrinh.FooterStyle = Style3
        Me.cmbChuongTrinh.GapHeight = 2
        Me.cmbChuongTrinh.HeadingStyle = Style4
        Me.cmbChuongTrinh.HighLightRowStyle = Style5
        Me.cmbChuongTrinh.ItemHeight = 15
        Me.cmbChuongTrinh.Location = New System.Drawing.Point(96, 30)
        Me.cmbChuongTrinh.MatchCol = C1.Win.C1List.MatchColEnum.AllCols
        Me.cmbChuongTrinh.MatchEntryTimeout = CType(2000, Long)
        Me.cmbChuongTrinh.MaxDropDownItems = CType(10, Short)
        Me.cmbChuongTrinh.MaxLength = 32767
        Me.cmbChuongTrinh.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbChuongTrinh.Name = "cmbChuongTrinh"
        Me.cmbChuongTrinh.OddRowStyle = Style6
        Me.cmbChuongTrinh.PartialRightColumn = False
        Me.cmbChuongTrinh.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbChuongTrinh.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbChuongTrinh.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbChuongTrinh.SelectedStyle = Style7
        Me.cmbChuongTrinh.Size = New System.Drawing.Size(678, 20)
        Me.cmbChuongTrinh.Style = Style8
        Me.cmbChuongTrinh.TabIndex = 126
        Me.cmbChuongTrinh.PropBag = resources.GetString("cmbChuongTrinh.PropBag")
        '
        'mnuChonAnh
        '
        Me.mnuChonAnh.Name = "mnuChonAnh"
        Me.mnuChonAnh.Size = New System.Drawing.Size(126, 22)
        Me.mnuChonAnh.Text = "Chọn ảnh"
        '
        'label10
        '
        Me.label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.label10.ForeColor = System.Drawing.Color.Black
        Me.label10.Location = New System.Drawing.Point(571, 167)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(368, 21)
        Me.label10.TabIndex = 131
        Me.label10.Text = "(Kích chuột phải để thay đổi hoặc xóa ảnh)"
        Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(9, 33)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(87, 15)
        Me.label8.TabIndex = 125
        Me.label8.Text = "Chương trình"
        '
        'chkPass_editable
        '
        Me.chkPass_editable.AutoSize = True
        Me.chkPass_editable.Location = New System.Drawing.Point(697, 8)
        Me.chkPass_editable.Name = "chkPass_editable"
        Me.chkPass_editable.Size = New System.Drawing.Size(92, 17)
        Me.chkPass_editable.TabIndex = 132
        Me.chkPass_editable.Text = "Sửa mật khẩu"
        Me.chkPass_editable.UseVisualStyleBackColor = True
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.SystemColors.Control
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(3, 3)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(939, 24)
        Me.lblUser.TabIndex = 124
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.cmbChuongTrinh)
        Me.tabPage2.Controls.Add(Me.label8)
        Me.tabPage2.Controls.Add(Me.lblUser)
        Me.tabPage2.Controls.Add(Me.fgFunct)
        Me.tabPage2.Controls.Add(Me.label7)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Size = New System.Drawing.Size(945, 531)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Quyền sử dụng các chức năng của chương trình"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'fgFunct
        '
        Me.fgFunct.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.fgFunct.ColumnInfo = resources.GetString("fgFunct.ColumnInfo")
        Me.fgFunct.ExtendLastCol = True
        Me.fgFunct.Location = New System.Drawing.Point(3, 75)
        Me.fgFunct.Name = "fgFunct"
        Me.fgFunct.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.fgFunct.Size = New System.Drawing.Size(939, 453)
        Me.fgFunct.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgFunct.Styles"))
        Me.fgFunct.TabIndex = 123
        '
        'label7
        '
        Me.label7.BackColor = System.Drawing.Color.Green
        Me.label7.ForeColor = System.Drawing.Color.White
        Me.label7.Location = New System.Drawing.Point(3, 51)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(939, 24)
        Me.label7.TabIndex = 122
        Me.label7.Text = "Các chức năng của chương trình"
        Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(483, 126)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(87, 15)
        Me.label9.TabIndex = 125
        Me.label9.Text = "Chữ ký"
        Me.label9.Visible = False
        '
        'menuChonAnh
        '
        Me.menuChonAnh.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuChonAnh, Me.mnuXoaAnh})
        Me.menuChonAnh.Name = "menuChonAnh"
        Me.menuChonAnh.Size = New System.Drawing.Size(127, 48)
        '
        'mnuXoaAnh
        '
        Me.mnuXoaAnh.Name = "mnuXoaAnh"
        Me.mnuXoaAnh.Size = New System.Drawing.Size(126, 22)
        Me.mnuXoaAnh.Text = "Xóa ảnh"
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        Me.openFileDialog1.Filter = "Image files |*.JPG;*.JPEG;*.GIF;*.BMP|JPEG File|*.JPG;*.JPEG|GIF File|*.GIF|Bitma" &
    "p file|*.BMP;*.BMPW"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.rdUser)
        Me.groupBox1.Controls.Add(Me.rdAdmin)
        Me.groupBox1.ForeColor = System.Drawing.Color.Navy
        Me.groupBox1.Location = New System.Drawing.Point(480, 184)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(459, 30)
        Me.groupBox1.TabIndex = 124
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Thuộc nhóm"
        '
        'rdUser
        '
        Me.rdUser.ForeColor = System.Drawing.Color.Black
        Me.rdUser.Location = New System.Drawing.Point(183, 12)
        Me.rdUser.Name = "rdUser"
        Me.rdUser.Size = New System.Drawing.Size(93, 15)
        Me.rdUser.TabIndex = 1
        Me.rdUser.Text = "Người dùng"
        '
        'rdAdmin
        '
        Me.rdAdmin.ForeColor = System.Drawing.Color.Black
        Me.rdAdmin.Location = New System.Drawing.Point(93, 12)
        Me.rdAdmin.Name = "rdAdmin"
        Me.rdAdmin.Size = New System.Drawing.Size(93, 15)
        Me.rdAdmin.TabIndex = 0
        Me.rdAdmin.Text = "Quản trị"
        '
        'cmbKhoa
        '
        Me.cmbKhoa.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbKhoa.AllowColMove = False
        Me.cmbKhoa.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbKhoa.AutoCompletion = True
        Me.cmbKhoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbKhoa.Caption = ""
        Me.cmbKhoa.CaptionHeight = 17
        Me.cmbKhoa.CaptionStyle = Style9
        Me.cmbKhoa.CaptionVisible = False
        Me.cmbKhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbKhoa.ColumnCaptionHeight = 17
        Me.cmbKhoa.ColumnFooterHeight = 17
        Me.cmbKhoa.ColumnHeaders = False
        Me.cmbKhoa.ContentHeight = 16
        Me.cmbKhoa.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.cmbKhoa.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbKhoa.DefColWidth = 30
        Me.cmbKhoa.DisplayMember = "Danh mục"
        Me.cmbKhoa.EditorBackColor = System.Drawing.Color.White
        Me.cmbKhoa.EditorFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKhoa.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbKhoa.EditorHeight = 16
        Me.cmbKhoa.EvenRowStyle = Style10
        Me.cmbKhoa.ExtendRightColumn = True
        Me.cmbKhoa.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbKhoa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKhoa.FooterStyle = Style11
        Me.cmbKhoa.GapHeight = 2
        Me.cmbKhoa.HeadingStyle = Style12
        Me.cmbKhoa.HighLightRowStyle = Style13
        Me.cmbKhoa.ItemHeight = 15
        Me.cmbKhoa.Location = New System.Drawing.Point(570, 55)
        Me.cmbKhoa.MatchCol = C1.Win.C1List.MatchColEnum.AllCols
        Me.cmbKhoa.MatchEntryTimeout = CType(2000, Long)
        Me.cmbKhoa.MaxDropDownItems = CType(10, Short)
        Me.cmbKhoa.MaxLength = 32767
        Me.cmbKhoa.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbKhoa.Name = "cmbKhoa"
        Me.cmbKhoa.OddRowStyle = Style14
        Me.cmbKhoa.PartialRightColumn = False
        Me.cmbKhoa.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbKhoa.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbKhoa.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbKhoa.SelectedStyle = Style15
        Me.cmbKhoa.Size = New System.Drawing.Size(242, 20)
        Me.cmbKhoa.Style = Style16
        Me.cmbKhoa.TabIndex = 123
        Me.cmbKhoa.PropBag = resources.GetString("cmbKhoa.PropBag")
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(483, 58)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(87, 15)
        Me.label12.TabIndex = 122
        Me.label12.Text = "Khoa, Phòng"
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "Untitled-4.jpg")
        Me.imageList1.Images.SetKeyName(1, "Untitled-3.jpg")
        '
        'label6
        '
        Me.label6.BackColor = System.Drawing.Color.Green
        Me.label6.ForeColor = System.Drawing.Color.White
        Me.label6.Location = New System.Drawing.Point(3, 3)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(474, 24)
        Me.label6.TabIndex = 121
        Me.label6.Text = "Danh sách người dùng"
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Location = New System.Drawing.Point(2, 5)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(953, 557)
        Me.tabControl1.TabIndex = 115
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.chkPass_editable)
        Me.tabPage1.Controls.Add(Me.label10)
        Me.tabPage1.Controls.Add(Me.picAnhNguoiDung)
        Me.tabPage1.Controls.Add(Me.picChuKy)
        Me.tabPage1.Controls.Add(Me.label9)
        Me.tabPage1.Controls.Add(Me.groupBox1)
        Me.tabPage1.Controls.Add(Me.cmbKhoa)
        Me.tabPage1.Controls.Add(Me.label12)
        Me.tabPage1.Controls.Add(Me.label6)
        Me.tabPage1.Controls.Add(Me.label5)
        Me.tabPage1.Controls.Add(Me.fg)
        Me.tabPage1.Controls.Add(Me.txtConfirm)
        Me.tabPage1.Controls.Add(Me.txtPass)
        Me.tabPage1.Controls.Add(Me.txtFullName)
        Me.tabPage1.Controls.Add(Me.txtUserName)
        Me.tabPage1.Controls.Add(Me.fgUser)
        Me.tabPage1.Controls.Add(Me.label4)
        Me.tabPage1.Controls.Add(Me.label3)
        Me.tabPage1.Controls.Add(Me.label2)
        Me.tabPage1.Controls.Add(Me.label1)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Size = New System.Drawing.Size(945, 531)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Quản trị người dùng"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'picAnhNguoiDung
        '
        Me.picAnhNguoiDung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picAnhNguoiDung.Image = Global.PhongKham.My.Resources.Resources.photo
        Me.picAnhNguoiDung.Location = New System.Drawing.Point(818, 6)
        Me.picAnhNguoiDung.Name = "picAnhNguoiDung"
        Me.picAnhNguoiDung.Size = New System.Drawing.Size(120, 160)
        Me.picAnhNguoiDung.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAnhNguoiDung.TabIndex = 129
        Me.picAnhNguoiDung.TabStop = False
        '
        'picChuKy
        '
        Me.picChuKy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picChuKy.Image = CType(resources.GetObject("picChuKy.Image"), System.Drawing.Image)
        Me.picChuKy.Location = New System.Drawing.Point(570, 116)
        Me.picChuKy.Name = "picChuKy"
        Me.picChuKy.Size = New System.Drawing.Size(201, 50)
        Me.picChuKy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picChuKy.TabIndex = 126
        Me.picChuKy.TabStop = False
        Me.picChuKy.Visible = False
        '
        'label5
        '
        Me.label5.BackColor = System.Drawing.Color.Green
        Me.label5.ForeColor = System.Drawing.Color.White
        Me.label5.Location = New System.Drawing.Point(480, 215)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(459, 21)
        Me.label5.TabIndex = 120
        Me.label5.Text = "Được phép cập nhật dữ liệu cho"
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.label5.Visible = False
        '
        'fg
        '
        Me.fg.AllowEditing = False
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.fg.ColumnInfo = "3,0,0,0,0,85,Columns:0{Width:100;Caption:""Mã Khoa"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:217;Caption:""Tên Kho" &
    "a"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:51;Caption:""Cập nhật"";DataType:System.Boolean;ImageAlign:CenterCent" &
    "er;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.ExtendLastCol = True
        Me.fg.Location = New System.Drawing.Point(480, 236)
        Me.fg.Name = "fg"
        Me.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.fg.Size = New System.Drawing.Size(459, 281)
        Me.fg.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fg.Styles"))
        Me.fg.TabIndex = 119
        Me.fg.Visible = False
        '
        'txtConfirm
        '
        Me.txtConfirm.Location = New System.Drawing.Point(570, 106)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirm.Size = New System.Drawing.Size(242, 20)
        Me.txtConfirm.TabIndex = 118
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(570, 80)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(242, 20)
        Me.txtPass.TabIndex = 116
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(570, 30)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(242, 20)
        Me.txtFullName.TabIndex = 114
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(570, 6)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(108, 20)
        Me.txtUserName.TabIndex = 112
        '
        'fgUser
        '
        Me.fgUser.AllowEditing = False
        Me.fgUser.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.fgUser.ColumnInfo = resources.GetString("fgUser.ColumnInfo")
        Me.fgUser.ExtendLastCol = True
        Me.fgUser.Location = New System.Drawing.Point(3, 30)
        Me.fgUser.Name = "fgUser"
        Me.fgUser.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox
        Me.fgUser.Size = New System.Drawing.Size(474, 487)
        Me.fgUser.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("fgUser.Styles"))
        Me.fgUser.TabIndex = 110
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(483, 109)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(87, 15)
        Me.label4.TabIndex = 117
        Me.label4.Text = "Xác nhận lại MK"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(483, 83)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(87, 15)
        Me.label3.TabIndex = 115
        Me.label3.Text = "Mật khẩu"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(483, 33)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(87, 15)
        Me.label2.TabIndex = 113
        Me.label2.Text = "Tên đầy đủ"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(483, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(87, 15)
        Me.label1.TabIndex = 111
        Me.label1.Text = "Tên đăng nhập"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.Location = New System.Drawing.Point(411, 573)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(72, 28)
        Me.SimpleButton2.TabIndex = 111
        Me.SimpleButton2.Text = "Get text"
        Me.SimpleButton2.Visible = False
        '
        'simpleButton1
        '
        Me.simpleButton1.Image = CType(resources.GetObject("simpleButton1.Image"), System.Drawing.Image)
        Me.simpleButton1.Location = New System.Drawing.Point(876, 568)
        Me.simpleButton1.Name = "simpleButton1"
        Me.simpleButton1.Size = New System.Drawing.Size(72, 28)
        Me.simpleButton1.TabIndex = 111
        Me.simpleButton1.Text = "Thoát"
        '
        'cmdThem
        '
        Me.cmdThem.Image = CType(resources.GetObject("cmdThem.Image"), System.Drawing.Image)
        Me.cmdThem.Location = New System.Drawing.Point(638, 568)
        Me.cmdThem.Name = "cmdThem"
        Me.cmdThem.Size = New System.Drawing.Size(72, 28)
        Me.cmdThem.TabIndex = 112
        Me.cmdThem.Text = "Thêm"
        '
        'cmdXoaUser
        '
        Me.cmdXoaUser.Image = CType(resources.GetObject("cmdXoaUser.Image"), System.Drawing.Image)
        Me.cmdXoaUser.Location = New System.Drawing.Point(795, 568)
        Me.cmdXoaUser.Name = "cmdXoaUser"
        Me.cmdXoaUser.Size = New System.Drawing.Size(72, 28)
        Me.cmdXoaUser.TabIndex = 113
        Me.cmdXoaUser.Text = "Xóa"
        '
        'cmdGhiUser
        '
        Me.cmdGhiUser.Image = CType(resources.GetObject("cmdGhiUser.Image"), System.Drawing.Image)
        Me.cmdGhiUser.Location = New System.Drawing.Point(718, 568)
        Me.cmdGhiUser.Name = "cmdGhiUser"
        Me.cmdGhiUser.Size = New System.Drawing.Size(72, 28)
        Me.cmdGhiUser.TabIndex = 114
        Me.cmdGhiUser.Text = "Ghi"
        '
        'frmQuanTriNguoiDung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(960, 613)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.simpleButton1)
        Me.Controls.Add(Me.cmdThem)
        Me.Controls.Add(Me.cmdXoaUser)
        Me.Controls.Add(Me.cmdGhiUser)
        Me.Name = "frmQuanTriNguoiDung"
        CType(Me.cmbChuongTrinh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage2.ResumeLayout(False)
        CType(Me.fgFunct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuChonAnh.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        CType(Me.cmbKhoa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        CType(Me.picAnhNguoiDung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChuKy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbChuongTrinh As C1.Win.C1List.C1Combo
    Private WithEvents mnuChonAnh As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents chkPass_editable As System.Windows.Forms.CheckBox
    Private WithEvents picChuKy As System.Windows.Forms.PictureBox
    Private WithEvents lblUser As System.Windows.Forms.Label
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents fgFunct As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents picAnhNguoiDung As System.Windows.Forms.PictureBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents menuChonAnh As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnuXoaAnh As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents rdUser As System.Windows.Forms.RadioButton
    Private WithEvents rdAdmin As System.Windows.Forms.RadioButton
    Friend WithEvents cmbKhoa As C1.Win.C1List.C1Combo
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents simpleButton1 As DevExpress.XtraEditors.SimpleButton
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents txtConfirm As System.Windows.Forms.TextBox
    Private WithEvents txtPass As System.Windows.Forms.TextBox
    Private WithEvents txtFullName As System.Windows.Forms.TextBox
    Private WithEvents txtUserName As System.Windows.Forms.TextBox
    Private WithEvents fgUser As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cmdGhiUser As DevExpress.XtraEditors.SimpleButton
    Private WithEvents cmdThem As DevExpress.XtraEditors.SimpleButton
    Private WithEvents cmdXoaUser As DevExpress.XtraEditors.SimpleButton
    Private WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
