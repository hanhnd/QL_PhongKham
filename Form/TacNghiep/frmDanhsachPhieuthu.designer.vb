<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhsachPhieuthu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDanhsachPhieuthu))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMaKhambenh = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTenbenhnhan = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmdXuatExcel = New System.Windows.Forms.Button()
        Me.cmdInDS = New System.Windows.Forms.Button()
        Me.txtDenngay = New C1.Win.C1Input.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTungay = New C1.Win.C1Input.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdThuchien = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.lblDanhsachPhieuthu = New System.Windows.Forms.Label()
        Me.panIn = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLydonoptien = New System.Windows.Forms.Label()
        Me.txtLydoHuyphieu = New System.Windows.Forms.TextBox()
        Me.lblSoBienlai = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDiachi_IN = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtNoidungIn = New System.Windows.Forms.Label()
        Me.txtTongtienIN = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblTen_IN = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cmdDongIn = New System.Windows.Forms.Button()
        Me.cmdHuyphieu = New System.Windows.Forms.Button()
        Me.lblBangchu_IN = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblChitietBL = New System.Windows.Forms.Label()
        Me.panIn_lai = New System.Windows.Forms.Panel()
        Me.txtTien_lai = New System.Windows.Forms.Label()
        Me.txtNoidung_lai = New System.Windows.Forms.Label()
        Me.chkXemBienlai = New System.Windows.Forms.CheckBox()
        Me.lblLydo_In_lai = New System.Windows.Forms.Label()
        Me.lblSoBienlai_lai = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBangchu_IN_lai = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDiachi_IN_lai = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNoidungIn_lai = New System.Windows.Forms.Label()
        Me.txtTongtienIN_lai = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTen_IN_lai = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSolien_lai = New C1.Win.C1Input.C1NumericEdit()
        Me.cmdDongIn_lai = New System.Windows.Forms.Button()
        Me.cmdIn_lai = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.panHC_Truc = New System.Windows.Forms.Panel()
        Me.cmdBatdau = New System.Windows.Forms.Button()
        Me.optTruc = New System.Windows.Forms.RadioButton()
        Me.optHC = New System.Windows.Forms.RadioButton()
        Me.lbl_count = New System.Windows.Forms.Label()
        Me.grdDSPhieuthu = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grdChitiet = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.txtDenngay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTungay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panIn.SuspendLayout()
        Me.panIn_lai.SuspendLayout()
        CType(Me.txtSolien_lai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panHC_Truc.SuspendLayout()
        CType(Me.grdDSPhieuthu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdChitiet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtMaKhambenh)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtTenbenhnhan)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.cmdXuatExcel)
        Me.Panel1.Controls.Add(Me.cmdInDS)
        Me.Panel1.Controls.Add(Me.txtDenngay)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtTungay)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmdThuchien)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmdThoat)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1046, 46)
        Me.Panel1.TabIndex = 201
        '
        'txtMaKhambenh
        '
        Me.txtMaKhambenh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaKhambenh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaKhambenh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMaKhambenh.Location = New System.Drawing.Point(413, 12)
        Me.txtMaKhambenh.Name = "txtMaKhambenh"
        Me.txtMaKhambenh.Size = New System.Drawing.Size(88, 22)
        Me.txtMaKhambenh.TabIndex = 171
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(367, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 19)
        Me.Label15.TabIndex = 172
        Me.Label15.Text = "Mã số:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTenbenhnhan
        '
        Me.txtTenbenhnhan.BackColor = System.Drawing.Color.White
        Me.txtTenbenhnhan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTenbenhnhan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenbenhnhan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTenbenhnhan.Location = New System.Drawing.Point(554, 12)
        Me.txtTenbenhnhan.Name = "txtTenbenhnhan"
        Me.txtTenbenhnhan.Size = New System.Drawing.Size(137, 22)
        Me.txtTenbenhnhan.TabIndex = 169
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(505, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 20)
        Me.Label14.TabIndex = 170
        Me.Label14.Text = "Họ tên:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdXuatExcel
        '
        Me.cmdXuatExcel.BackColor = System.Drawing.Color.Transparent
        Me.cmdXuatExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXuatExcel.Image = CType(resources.GetObject("cmdXuatExcel.Image"), System.Drawing.Image)
        Me.cmdXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdXuatExcel.Location = New System.Drawing.Point(782, 8)
        Me.cmdXuatExcel.Name = "cmdXuatExcel"
        Me.cmdXuatExcel.Size = New System.Drawing.Size(80, 30)
        Me.cmdXuatExcel.TabIndex = 166
        Me.cmdXuatExcel.Text = "Xuất Excel"
        Me.cmdXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdXuatExcel.UseVisualStyleBackColor = False
        '
        'cmdInDS
        '
        Me.cmdInDS.BackColor = System.Drawing.Color.Transparent
        Me.cmdInDS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInDS.Image = Global.PhongKham.My.Resources.Resources.Print_16x16
        Me.cmdInDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdInDS.Location = New System.Drawing.Point(696, 7)
        Me.cmdInDS.Name = "cmdInDS"
        Me.cmdInDS.Size = New System.Drawing.Size(80, 30)
        Me.cmdInDS.TabIndex = 165
        Me.cmdInDS.Text = "In d/sách"
        Me.cmdInDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdInDS.UseVisualStyleBackColor = False
        Me.cmdInDS.Visible = False
        '
        'txtDenngay
        '
        Me.txtDenngay.BackColor = System.Drawing.Color.White
        Me.txtDenngay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDenngay.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtDenngay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDenngay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtDenngay.Location = New System.Drawing.Point(232, 14)
        Me.txtDenngay.Name = "txtDenngay"
        Me.txtDenngay.Size = New System.Drawing.Size(131, 20)
        Me.txtDenngay.TabIndex = 162
        Me.txtDenngay.Tag = Nothing
        Me.txtDenngay.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(189, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 16)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "đến:"
        '
        'txtTungay
        '
        Me.txtTungay.BackColor = System.Drawing.Color.White
        Me.txtTungay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTungay.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtTungay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTungay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtTungay.Location = New System.Drawing.Point(40, 14)
        Me.txtTungay.Name = "txtTungay"
        Me.txtTungay.Size = New System.Drawing.Size(144, 20)
        Me.txtTungay.TabIndex = 161
        Me.txtTungay.Tag = Nothing
        Me.txtTungay.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 16)
        Me.Label2.TabIndex = 163
        Me.Label2.Text = "Từ:"
        '
        'cmdThuchien
        '
        Me.cmdThuchien.BackColor = System.Drawing.Color.Transparent
        Me.cmdThuchien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThuchien.Image = CType(resources.GetObject("cmdThuchien.Image"), System.Drawing.Image)
        Me.cmdThuchien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThuchien.Location = New System.Drawing.Point(694, 8)
        Me.cmdThuchien.Name = "cmdThuchien"
        Me.cmdThuchien.Size = New System.Drawing.Size(80, 30)
        Me.cmdThuchien.TabIndex = 160
        Me.cmdThuchien.Text = "Thống kê"
        Me.cmdThuchien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThuchien.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(961, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 30)
        Me.Button1.TabIndex = 159
        Me.Button1.Text = "Gettext"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.Color.Transparent
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = Global.PhongKham.My.Resources.Resources._exit
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(870, 8)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(80, 30)
        Me.cmdThoat.TabIndex = 159
        Me.cmdThoat.Text = "   Đóng lại"
        Me.cmdThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'lblDanhsachPhieuthu
        '
        Me.lblDanhsachPhieuthu.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.lblDanhsachPhieuthu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDanhsachPhieuthu.ForeColor = System.Drawing.Color.White
        Me.lblDanhsachPhieuthu.Location = New System.Drawing.Point(2, 48)
        Me.lblDanhsachPhieuthu.Name = "lblDanhsachPhieuthu"
        Me.lblDanhsachPhieuthu.Size = New System.Drawing.Size(454, 21)
        Me.lblDanhsachPhieuthu.TabIndex = 197
        Me.lblDanhsachPhieuthu.Text = "   Danh sách các phiếu thu"
        Me.lblDanhsachPhieuthu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panIn
        '
        Me.panIn.BackColor = System.Drawing.Color.PapayaWhip
        Me.panIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panIn.Controls.Add(Me.Label4)
        Me.panIn.Controls.Add(Me.lblLydonoptien)
        Me.panIn.Controls.Add(Me.txtLydoHuyphieu)
        Me.panIn.Controls.Add(Me.lblSoBienlai)
        Me.panIn.Controls.Add(Me.Label10)
        Me.panIn.Controls.Add(Me.lblDiachi_IN)
        Me.panIn.Controls.Add(Me.GroupBox11)
        Me.panIn.Controls.Add(Me.txtNoidungIn)
        Me.panIn.Controls.Add(Me.txtTongtienIN)
        Me.panIn.Controls.Add(Me.Label29)
        Me.panIn.Controls.Add(Me.Label30)
        Me.panIn.Controls.Add(Me.Label31)
        Me.panIn.Controls.Add(Me.lblTen_IN)
        Me.panIn.Controls.Add(Me.Label32)
        Me.panIn.Controls.Add(Me.Label33)
        Me.panIn.Controls.Add(Me.Label34)
        Me.panIn.Controls.Add(Me.cmdDongIn)
        Me.panIn.Controls.Add(Me.cmdHuyphieu)
        Me.panIn.Controls.Add(Me.lblBangchu_IN)
        Me.panIn.Controls.Add(Me.Label27)
        Me.panIn.Location = New System.Drawing.Point(238, 131)
        Me.panIn.Name = "panIn"
        Me.panIn.Size = New System.Drawing.Size(608, 320)
        Me.panIn.TabIndex = 203
        Me.panIn.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 198
        Me.Label4.Text = "Lý do hủy:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLydonoptien
        '
        Me.lblLydonoptien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLydonoptien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLydonoptien.Location = New System.Drawing.Point(112, 104)
        Me.lblLydonoptien.Name = "lblLydonoptien"
        Me.lblLydonoptien.Size = New System.Drawing.Size(488, 16)
        Me.lblLydonoptien.TabIndex = 197
        Me.lblLydonoptien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLydoHuyphieu
        '
        Me.txtLydoHuyphieu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLydoHuyphieu.Location = New System.Drawing.Point(112, 244)
        Me.txtLydoHuyphieu.Multiline = True
        Me.txtLydoHuyphieu.Name = "txtLydoHuyphieu"
        Me.txtLydoHuyphieu.Size = New System.Drawing.Size(488, 25)
        Me.txtLydoHuyphieu.TabIndex = 196
        Me.txtLydoHuyphieu.Text = "sadád"
        '
        'lblSoBienlai
        '
        Me.lblSoBienlai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSoBienlai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoBienlai.Location = New System.Drawing.Point(112, 32)
        Me.lblSoBienlai.Name = "lblSoBienlai"
        Me.lblSoBienlai.Size = New System.Drawing.Size(488, 19)
        Me.lblSoBienlai.TabIndex = 195
        Me.lblSoBienlai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 16)
        Me.Label10.TabIndex = 194
        Me.Label10.Text = "Số biên lai:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDiachi_IN
        '
        Me.lblDiachi_IN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiachi_IN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiachi_IN.Location = New System.Drawing.Point(112, 82)
        Me.lblDiachi_IN.Name = "lblDiachi_IN"
        Me.lblDiachi_IN.Size = New System.Drawing.Size(488, 16)
        Me.lblDiachi_IN.TabIndex = 189
        Me.lblDiachi_IN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox11
        '
        Me.GroupBox11.Location = New System.Drawing.Point(8, 270)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(592, 8)
        Me.GroupBox11.TabIndex = 188
        Me.GroupBox11.TabStop = False
        '
        'txtNoidungIn
        '
        Me.txtNoidungIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtNoidungIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoidungIn.Location = New System.Drawing.Point(112, 130)
        Me.txtNoidungIn.Name = "txtNoidungIn"
        Me.txtNoidungIn.Size = New System.Drawing.Size(488, 81)
        Me.txtNoidungIn.TabIndex = 187
        '
        'txtTongtienIN
        '
        Me.txtTongtienIN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTongtienIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTongtienIN.Location = New System.Drawing.Point(112, 219)
        Me.txtTongtienIN.Name = "txtTongtienIN"
        Me.txtTongtienIN.Size = New System.Drawing.Size(488, 16)
        Me.txtTongtienIN.TabIndex = 186
        Me.txtTongtienIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(8, 130)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(96, 16)
        Me.Label29.TabIndex = 185
        Me.Label29.Text = "Diễn giải:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(8, 106)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(96, 16)
        Me.Label30.TabIndex = 184
        Me.Label30.Text = "Lý do nộp tiền:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(8, 82)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(96, 16)
        Me.Label31.TabIndex = 183
        Me.Label31.Text = "Địa chỉ:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTen_IN
        '
        Me.lblTen_IN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTen_IN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTen_IN.Location = New System.Drawing.Point(112, 56)
        Me.lblTen_IN.Name = "lblTen_IN"
        Me.lblTen_IN.Size = New System.Drawing.Size(488, 21)
        Me.lblTen_IN.TabIndex = 182
        Me.lblTen_IN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(8, 58)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(96, 16)
        Me.Label32.TabIndex = 181
        Me.Label32.Text = "Họ tên người nộp:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Tomato
        Me.Label33.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(0, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(608, 24)
        Me.Label33.TabIndex = 180
        Me.Label33.Text = "PHIẾU HỦY"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(8, 218)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(96, 16)
        Me.Label34.TabIndex = 179
        Me.Label34.Text = "Số tiền:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdDongIn
        '
        Me.cmdDongIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdDongIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDongIn.Image = Global.PhongKham.My.Resources.Resources._exit
        Me.cmdDongIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDongIn.Location = New System.Drawing.Point(504, 281)
        Me.cmdDongIn.Name = "cmdDongIn"
        Me.cmdDongIn.Size = New System.Drawing.Size(96, 30)
        Me.cmdDongIn.TabIndex = 176
        Me.cmdDongIn.Text = "   Đóng lại"
        Me.cmdDongIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDongIn.UseVisualStyleBackColor = False
        '
        'cmdHuyphieu
        '
        Me.cmdHuyphieu.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdHuyphieu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHuyphieu.Image = Global.PhongKham.My.Resources.Resources.page_cross_icon
        Me.cmdHuyphieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdHuyphieu.Location = New System.Drawing.Point(381, 281)
        Me.cmdHuyphieu.Name = "cmdHuyphieu"
        Me.cmdHuyphieu.Size = New System.Drawing.Size(117, 30)
        Me.cmdHuyphieu.TabIndex = 175
        Me.cmdHuyphieu.Text = "   Hủy phiếu"
        Me.cmdHuyphieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdHuyphieu.UseVisualStyleBackColor = False
        '
        'lblBangchu_IN
        '
        Me.lblBangchu_IN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBangchu_IN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBangchu_IN.Location = New System.Drawing.Point(112, 221)
        Me.lblBangchu_IN.Name = "lblBangchu_IN"
        Me.lblBangchu_IN.Size = New System.Drawing.Size(488, 16)
        Me.lblBangchu_IN.TabIndex = 192
        Me.lblBangchu_IN.Visible = False
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(8, 219)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(96, 16)
        Me.Label27.TabIndex = 191
        Me.Label27.Text = "Bằng chữ:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label27.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(264, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 21)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "Nhấn phím Delete để hủy phiếu !"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblChitietBL
        '
        Me.lblChitietBL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChitietBL.BackColor = System.Drawing.Color.MintCream
        Me.lblChitietBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChitietBL.ForeColor = System.Drawing.Color.Black
        Me.lblChitietBL.Location = New System.Drawing.Point(464, 48)
        Me.lblChitietBL.Name = "lblChitietBL"
        Me.lblChitietBL.Size = New System.Drawing.Size(582, 21)
        Me.lblChitietBL.TabIndex = 206
        Me.lblChitietBL.Text = "   Chi tiết biên lai số:"
        Me.lblChitietBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panIn_lai
        '
        Me.panIn_lai.BackColor = System.Drawing.Color.PapayaWhip
        Me.panIn_lai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panIn_lai.Controls.Add(Me.txtTien_lai)
        Me.panIn_lai.Controls.Add(Me.txtNoidung_lai)
        Me.panIn_lai.Controls.Add(Me.chkXemBienlai)
        Me.panIn_lai.Controls.Add(Me.lblLydo_In_lai)
        Me.panIn_lai.Controls.Add(Me.lblSoBienlai_lai)
        Me.panIn_lai.Controls.Add(Me.Label3)
        Me.panIn_lai.Controls.Add(Me.lblBangchu_IN_lai)
        Me.panIn_lai.Controls.Add(Me.Label6)
        Me.panIn_lai.Controls.Add(Me.lblDiachi_IN_lai)
        Me.panIn_lai.Controls.Add(Me.GroupBox1)
        Me.panIn_lai.Controls.Add(Me.txtNoidungIn_lai)
        Me.panIn_lai.Controls.Add(Me.txtTongtienIN_lai)
        Me.panIn_lai.Controls.Add(Me.Label7)
        Me.panIn_lai.Controls.Add(Me.Label8)
        Me.panIn_lai.Controls.Add(Me.Label9)
        Me.panIn_lai.Controls.Add(Me.lblTen_IN_lai)
        Me.panIn_lai.Controls.Add(Me.Label11)
        Me.panIn_lai.Controls.Add(Me.Label12)
        Me.panIn_lai.Controls.Add(Me.Label13)
        Me.panIn_lai.Controls.Add(Me.txtSolien_lai)
        Me.panIn_lai.Controls.Add(Me.cmdDongIn_lai)
        Me.panIn_lai.Controls.Add(Me.cmdIn_lai)
        Me.panIn_lai.Controls.Add(Me.Label38)
        Me.panIn_lai.Location = New System.Drawing.Point(151, 181)
        Me.panIn_lai.Name = "panIn_lai"
        Me.panIn_lai.Size = New System.Drawing.Size(608, 321)
        Me.panIn_lai.TabIndex = 208
        Me.panIn_lai.Visible = False
        '
        'txtTien_lai
        '
        Me.txtTien_lai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTien_lai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtTien_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTien_lai.Location = New System.Drawing.Point(252, 323)
        Me.txtTien_lai.Name = "txtTien_lai"
        Me.txtTien_lai.Size = New System.Drawing.Size(238, 55)
        Me.txtTien_lai.TabIndex = 199
        '
        'txtNoidung_lai
        '
        Me.txtNoidung_lai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtNoidung_lai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtNoidung_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoidung_lai.Location = New System.Drawing.Point(8, 323)
        Me.txtNoidung_lai.Name = "txtNoidung_lai"
        Me.txtNoidung_lai.Size = New System.Drawing.Size(238, 55)
        Me.txtNoidung_lai.TabIndex = 198
        '
        'chkXemBienlai
        '
        Me.chkXemBienlai.AutoSize = True
        Me.chkXemBienlai.Location = New System.Drawing.Point(217, 275)
        Me.chkXemBienlai.Name = "chkXemBienlai"
        Me.chkXemBienlai.Size = New System.Drawing.Size(102, 17)
        Me.chkXemBienlai.TabIndex = 197
        Me.chkXemBienlai.Text = "Xem trước khi in"
        Me.chkXemBienlai.UseVisualStyleBackColor = True
        '
        'lblLydo_In_lai
        '
        Me.lblLydo_In_lai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLydo_In_lai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblLydo_In_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLydo_In_lai.Location = New System.Drawing.Point(104, 104)
        Me.lblLydo_In_lai.Name = "lblLydo_In_lai"
        Me.lblLydo_In_lai.Size = New System.Drawing.Size(496, 18)
        Me.lblLydo_In_lai.TabIndex = 196
        Me.lblLydo_In_lai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSoBienlai_lai
        '
        Me.lblSoBienlai_lai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSoBienlai_lai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSoBienlai_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoBienlai_lai.Location = New System.Drawing.Point(104, 32)
        Me.lblSoBienlai_lai.Name = "lblSoBienlai_lai"
        Me.lblSoBienlai_lai.Size = New System.Drawing.Size(496, 18)
        Me.lblSoBienlai_lai.TabIndex = 195
        Me.lblSoBienlai_lai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 194
        Me.Label3.Text = "Số biên lai:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBangchu_IN_lai
        '
        Me.lblBangchu_IN_lai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBangchu_IN_lai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblBangchu_IN_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBangchu_IN_lai.Location = New System.Drawing.Point(104, 239)
        Me.lblBangchu_IN_lai.Name = "lblBangchu_IN_lai"
        Me.lblBangchu_IN_lai.Size = New System.Drawing.Size(496, 19)
        Me.lblBangchu_IN_lai.TabIndex = 192
        Me.lblBangchu_IN_lai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBangchu_IN_lai.Visible = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 191
        Me.Label6.Text = "Bằng chữ:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Visible = False
        '
        'lblDiachi_IN_lai
        '
        Me.lblDiachi_IN_lai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiachi_IN_lai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDiachi_IN_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiachi_IN_lai.Location = New System.Drawing.Point(104, 80)
        Me.lblDiachi_IN_lai.Name = "lblDiachi_IN_lai"
        Me.lblDiachi_IN_lai.Size = New System.Drawing.Size(496, 18)
        Me.lblDiachi_IN_lai.TabIndex = 189
        Me.lblDiachi_IN_lai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(8, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 8)
        Me.GroupBox1.TabIndex = 188
        Me.GroupBox1.TabStop = False
        '
        'txtNoidungIn_lai
        '
        Me.txtNoidungIn_lai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtNoidungIn_lai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtNoidungIn_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoidungIn_lai.Location = New System.Drawing.Point(104, 130)
        Me.txtNoidungIn_lai.Name = "txtNoidungIn_lai"
        Me.txtNoidungIn_lai.Size = New System.Drawing.Size(496, 76)
        Me.txtNoidungIn_lai.TabIndex = 187
        '
        'txtTongtienIN_lai
        '
        Me.txtTongtienIN_lai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTongtienIN_lai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtTongtienIN_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTongtienIN_lai.Location = New System.Drawing.Point(104, 216)
        Me.txtTongtienIN_lai.Name = "txtTongtienIN_lai"
        Me.txtTongtienIN_lai.Size = New System.Drawing.Size(496, 19)
        Me.txtTongtienIN_lai.TabIndex = 186
        Me.txtTongtienIN_lai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 16)
        Me.Label7.TabIndex = 185
        Me.Label7.Text = "Diễn giải:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 184
        Me.Label8.Text = "Lý do nộp tiền:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 183
        Me.Label9.Text = "Địa chỉ:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTen_IN_lai
        '
        Me.lblTen_IN_lai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTen_IN_lai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTen_IN_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTen_IN_lai.Location = New System.Drawing.Point(104, 54)
        Me.lblTen_IN_lai.Name = "lblTen_IN_lai"
        Me.lblTen_IN_lai.Size = New System.Drawing.Size(496, 21)
        Me.lblTen_IN_lai.TabIndex = 182
        Me.lblTen_IN_lai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 16)
        Me.Label11.TabIndex = 181
        Me.Label11.Text = "Họ tên người nộp:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.YellowGreen
        Me.Label12.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(608, 24)
        Me.Label12.TabIndex = 180
        Me.Label12.Text = "PHIẾU THU"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(0, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 16)
        Me.Label13.TabIndex = 179
        Me.Label13.Text = "Số tiền:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSolien_lai
        '
        Me.txtSolien_lai.Location = New System.Drawing.Point(104, 272)
        Me.txtSolien_lai.Name = "txtSolien_lai"
        Me.txtSolien_lai.Size = New System.Drawing.Size(88, 20)
        Me.txtSolien_lai.TabIndex = 177
        Me.txtSolien_lai.Tag = Nothing
        Me.txtSolien_lai.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmdDongIn_lai
        '
        Me.cmdDongIn_lai.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdDongIn_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDongIn_lai.Image = CType(resources.GetObject("cmdDongIn_lai.Image"), System.Drawing.Image)
        Me.cmdDongIn_lai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDongIn_lai.Location = New System.Drawing.Point(495, 275)
        Me.cmdDongIn_lai.Name = "cmdDongIn_lai"
        Me.cmdDongIn_lai.Size = New System.Drawing.Size(96, 30)
        Me.cmdDongIn_lai.TabIndex = 176
        Me.cmdDongIn_lai.Text = "   Đóng lại"
        Me.cmdDongIn_lai.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDongIn_lai.UseVisualStyleBackColor = False
        '
        'cmdIn_lai
        '
        Me.cmdIn_lai.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdIn_lai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdIn_lai.Image = CType(resources.GetObject("cmdIn_lai.Image"), System.Drawing.Image)
        Me.cmdIn_lai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdIn_lai.Location = New System.Drawing.Point(383, 275)
        Me.cmdIn_lai.Name = "cmdIn_lai"
        Me.cmdIn_lai.Size = New System.Drawing.Size(96, 30)
        Me.cmdIn_lai.TabIndex = 175
        Me.cmdIn_lai.Text = "    In phiếu"
        Me.cmdIn_lai.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdIn_lai.UseVisualStyleBackColor = False
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(0, 276)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(96, 16)
        Me.Label38.TabIndex = 87
        Me.Label38.Text = "Số liên:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panHC_Truc
        '
        Me.panHC_Truc.BackColor = System.Drawing.Color.YellowGreen
        Me.panHC_Truc.Controls.Add(Me.cmdBatdau)
        Me.panHC_Truc.Controls.Add(Me.optTruc)
        Me.panHC_Truc.Controls.Add(Me.optHC)
        Me.panHC_Truc.Location = New System.Drawing.Point(353, 255)
        Me.panHC_Truc.Name = "panHC_Truc"
        Me.panHC_Truc.Size = New System.Drawing.Size(322, 114)
        Me.panHC_Truc.TabIndex = 428
        Me.panHC_Truc.Visible = False
        '
        'cmdBatdau
        '
        Me.cmdBatdau.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBatdau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBatdau.Location = New System.Drawing.Point(126, 67)
        Me.cmdBatdau.Name = "cmdBatdau"
        Me.cmdBatdau.Size = New System.Drawing.Size(88, 30)
        Me.cmdBatdau.TabIndex = 2
        Me.cmdBatdau.Text = "Bắt đầu"
        Me.cmdBatdau.UseVisualStyleBackColor = True
        '
        'optTruc
        '
        Me.optTruc.AutoSize = True
        Me.optTruc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optTruc.Location = New System.Drawing.Point(204, 24)
        Me.optTruc.Name = "optTruc"
        Me.optTruc.Size = New System.Drawing.Size(90, 23)
        Me.optTruc.TabIndex = 1
        Me.optTruc.TabStop = True
        Me.optTruc.Text = "Giờ trực"
        Me.optTruc.UseVisualStyleBackColor = True
        '
        'optHC
        '
        Me.optHC.AutoSize = True
        Me.optHC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optHC.Location = New System.Drawing.Point(24, 24)
        Me.optHC.Name = "optHC"
        Me.optHC.Size = New System.Drawing.Size(144, 23)
        Me.optHC.TabIndex = 0
        Me.optHC.TabStop = True
        Me.optHC.Text = "Giờ hành chính"
        Me.optHC.UseVisualStyleBackColor = True
        '
        'lbl_count
        '
        Me.lbl_count.AutoSize = True
        Me.lbl_count.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.lbl_count.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_count.ForeColor = System.Drawing.Color.White
        Me.lbl_count.Location = New System.Drawing.Point(200, 52)
        Me.lbl_count.Name = "lbl_count"
        Me.lbl_count.Size = New System.Drawing.Size(14, 13)
        Me.lbl_count.TabIndex = 429
        Me.lbl_count.Text = "0"
        '
        'grdDSPhieuthu
        '
        Me.grdDSPhieuthu.AllowEditing = False
        Me.grdDSPhieuthu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdDSPhieuthu.BackgroundImage = CType(resources.GetObject("grdDSPhieuthu.BackgroundImage"), System.Drawing.Image)
        Me.grdDSPhieuthu.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdDSPhieuthu.ColumnInfo = resources.GetString("grdDSPhieuthu.ColumnInfo")
        Me.grdDSPhieuthu.ExtendLastCol = True
        Me.grdDSPhieuthu.Location = New System.Drawing.Point(2, 71)
        Me.grdDSPhieuthu.Name = "grdDSPhieuthu"
        Me.grdDSPhieuthu.Rows.Count = 10
        Me.grdDSPhieuthu.Rows.MinSize = 20
        Me.grdDSPhieuthu.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdDSPhieuthu.Size = New System.Drawing.Size(454, 568)
        Me.grdDSPhieuthu.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdDSPhieuthu.Styles"))
        Me.grdDSPhieuthu.TabIndex = 207
        '
        'grdChitiet
        '
        Me.grdChitiet.AllowEditing = False
        Me.grdChitiet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdChitiet.BackgroundImage = CType(resources.GetObject("grdChitiet.BackgroundImage"), System.Drawing.Image)
        Me.grdChitiet.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdChitiet.ColumnInfo = resources.GetString("grdChitiet.ColumnInfo")
        Me.grdChitiet.ExtendLastCol = True
        Me.grdChitiet.Location = New System.Drawing.Point(464, 71)
        Me.grdChitiet.Name = "grdChitiet"
        Me.grdChitiet.Rows.Count = 1
        Me.grdChitiet.Rows.MinSize = 20
        Me.grdChitiet.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdChitiet.Size = New System.Drawing.Size(580, 568)
        Me.grdChitiet.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdChitiet.Styles"))
        Me.grdChitiet.TabIndex = 205
        '
        'frmDanhsachPhieuthu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1050, 644)
        Me.Controls.Add(Me.panIn)
        Me.Controls.Add(Me.panIn_lai)
        Me.Controls.Add(Me.lbl_count)
        Me.Controls.Add(Me.panHC_Truc)
        Me.Controls.Add(Me.grdDSPhieuthu)
        Me.Controls.Add(Me.lblChitietBL)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblDanhsachPhieuthu)
        Me.Controls.Add(Me.grdChitiet)
        Me.Name = "frmDanhsachPhieuthu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtDenngay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTungay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panIn.ResumeLayout(False)
        Me.panIn.PerformLayout()
        Me.panIn_lai.ResumeLayout(False)
        Me.panIn_lai.PerformLayout()
        CType(Me.txtSolien_lai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panHC_Truc.ResumeLayout(False)
        Me.panHC_Truc.PerformLayout()
        CType(Me.grdDSPhieuthu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdChitiet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDanhsachPhieuthu As System.Windows.Forms.Label
    Friend WithEvents panIn As System.Windows.Forms.Panel
    Friend WithEvents lblBangchu_IN As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblDiachi_IN As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoidungIn As System.Windows.Forms.Label
    Friend WithEvents txtTongtienIN As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblTen_IN As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cmdDongIn As System.Windows.Forms.Button
    Friend WithEvents cmdHuyphieu As System.Windows.Forms.Button
    Friend WithEvents lblSoBienlai As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdThuchien As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents txtDenngay As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTungay As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdXuatExcel As System.Windows.Forms.Button
    Friend WithEvents cmdInDS As System.Windows.Forms.Button
    Friend WithEvents lblLydonoptien As System.Windows.Forms.Label
    Friend WithEvents txtLydoHuyphieu As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grdChitiet As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblChitietBL As System.Windows.Forms.Label
    Friend WithEvents grdDSPhieuthu As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents panIn_lai As System.Windows.Forms.Panel
    Friend WithEvents txtTien_lai As System.Windows.Forms.Label
    Friend WithEvents txtNoidung_lai As System.Windows.Forms.Label
    Friend WithEvents chkXemBienlai As System.Windows.Forms.CheckBox
    Friend WithEvents lblLydo_In_lai As System.Windows.Forms.Label
    Friend WithEvents lblSoBienlai_lai As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblBangchu_IN_lai As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblDiachi_IN_lai As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoidungIn_lai As System.Windows.Forms.Label
    Friend WithEvents txtTongtienIN_lai As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTen_IN_lai As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSolien_lai As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents cmdDongIn_lai As System.Windows.Forms.Button
    Friend WithEvents cmdIn_lai As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtTenbenhnhan As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMaKhambenh As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents panHC_Truc As System.Windows.Forms.Panel
    Friend WithEvents cmdBatdau As System.Windows.Forms.Button
    Friend WithEvents optTruc As System.Windows.Forms.RadioButton
    Friend WithEvents optHC As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents lbl_count As Label
End Class
