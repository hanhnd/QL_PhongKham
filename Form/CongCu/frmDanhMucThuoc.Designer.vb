<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhMucThuoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDanhMucThuoc))
        Me.grdDMTHUOC = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTenThuoc = New System.Windows.Forms.TextBox()
        Me.lblDiaChiHuyenTinh = New System.Windows.Forms.Label()
        Me.txtTenGoc = New System.Windows.Forms.TextBox()
        Me.lblDiaChiCQ_Xa = New System.Windows.Forms.Label()
        Me.txtMaThuoc = New System.Windows.Forms.TextBox()
        Me.lblHoTenBN = New System.Windows.Forms.Label()
        Me.txtDVT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNhaSanXuat = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHamLuong = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDonGia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_GetText = New System.Windows.Forms.Button()
        Me.cmdXoa = New System.Windows.Forms.Button()
        Me.cmdSua = New System.Windows.Forms.Button()
        Me.cmdHuy = New System.Windows.Forms.Button()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.cmdThem = New System.Windows.Forms.Button()
        Me.cmdGhi = New System.Windows.Forms.Button()
        CType(Me.grdDMTHUOC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDMTHUOC
        '
        Me.grdDMTHUOC.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.grdDMTHUOC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDMTHUOC.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdDMTHUOC.ColumnInfo = resources.GetString("grdDMTHUOC.ColumnInfo")
        Me.grdDMTHUOC.Location = New System.Drawing.Point(0, 35)
        Me.grdDMTHUOC.Name = "grdDMTHUOC"
        Me.grdDMTHUOC.Rows.MinSize = 25
        Me.grdDMTHUOC.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdDMTHUOC.Size = New System.Drawing.Size(631, 575)
        Me.grdDMTHUOC.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdDMTHUOC.Styles"))
        Me.grdDMTHUOC.TabIndex = 176
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(631, 32)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "DANH MỤC THUỐC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTenThuoc
        '
        Me.txtTenThuoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTenThuoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenThuoc.Location = New System.Drawing.Point(772, 66)
        Me.txtTenThuoc.Name = "txtTenThuoc"
        Me.txtTenThuoc.Size = New System.Drawing.Size(169, 22)
        Me.txtTenThuoc.TabIndex = 1
        '
        'lblDiaChiHuyenTinh
        '
        Me.lblDiaChiHuyenTinh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiaChiHuyenTinh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiaChiHuyenTinh.Location = New System.Drawing.Point(649, 69)
        Me.lblDiaChiHuyenTinh.Name = "lblDiaChiHuyenTinh"
        Me.lblDiaChiHuyenTinh.Size = New System.Drawing.Size(107, 16)
        Me.lblDiaChiHuyenTinh.TabIndex = 203
        Me.lblDiaChiHuyenTinh.Text = "Tên thuốc:"
        '
        'txtTenGoc
        '
        Me.txtTenGoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTenGoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenGoc.Location = New System.Drawing.Point(772, 94)
        Me.txtTenGoc.Name = "txtTenGoc"
        Me.txtTenGoc.Size = New System.Drawing.Size(169, 22)
        Me.txtTenGoc.TabIndex = 2
        '
        'lblDiaChiCQ_Xa
        '
        Me.lblDiaChiCQ_Xa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiaChiCQ_Xa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiaChiCQ_Xa.Location = New System.Drawing.Point(649, 99)
        Me.lblDiaChiCQ_Xa.Name = "lblDiaChiCQ_Xa"
        Me.lblDiaChiCQ_Xa.Size = New System.Drawing.Size(98, 16)
        Me.lblDiaChiCQ_Xa.TabIndex = 202
        Me.lblDiaChiCQ_Xa.Text = "Tên gốc:"
        '
        'txtMaThuoc
        '
        Me.txtMaThuoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMaThuoc.BackColor = System.Drawing.Color.White
        Me.txtMaThuoc.Enabled = False
        Me.txtMaThuoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaThuoc.Location = New System.Drawing.Point(772, 35)
        Me.txtMaThuoc.Name = "txtMaThuoc"
        Me.txtMaThuoc.Size = New System.Drawing.Size(169, 22)
        Me.txtMaThuoc.TabIndex = 0
        '
        'lblHoTenBN
        '
        Me.lblHoTenBN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHoTenBN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoTenBN.Location = New System.Drawing.Point(649, 40)
        Me.lblHoTenBN.Name = "lblHoTenBN"
        Me.lblHoTenBN.Size = New System.Drawing.Size(102, 16)
        Me.lblHoTenBN.TabIndex = 201
        Me.lblHoTenBN.Text = "Mã thuốc:"
        '
        'txtDVT
        '
        Me.txtDVT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDVT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDVT.Location = New System.Drawing.Point(772, 150)
        Me.txtDVT.Name = "txtDVT"
        Me.txtDVT.Size = New System.Drawing.Size(93, 22)
        Me.txtDVT.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(649, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "ĐVT:"
        '
        'txtNhaSanXuat
        '
        Me.txtNhaSanXuat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNhaSanXuat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNhaSanXuat.Location = New System.Drawing.Point(772, 207)
        Me.txtNhaSanXuat.Name = "txtNhaSanXuat"
        Me.txtNhaSanXuat.Size = New System.Drawing.Size(169, 22)
        Me.txtNhaSanXuat.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(649, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 16)
        Me.Label4.TabIndex = 208
        Me.Label4.Text = "Nhà sản xuất:"
        '
        'txtHamLuong
        '
        Me.txtHamLuong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHamLuong.BackColor = System.Drawing.Color.White
        Me.txtHamLuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHamLuong.Location = New System.Drawing.Point(772, 122)
        Me.txtHamLuong.Name = "txtHamLuong"
        Me.txtHamLuong.Size = New System.Drawing.Size(169, 22)
        Me.txtHamLuong.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(649, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 16)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = "Hàm lượng:"
        '
        'txtDonGia
        '
        Me.txtDonGia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDonGia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDonGia.Location = New System.Drawing.Point(772, 179)
        Me.txtDonGia.Name = "txtDonGia"
        Me.txtDonGia.Size = New System.Drawing.Size(93, 22)
        Me.txtDonGia.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(649, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 211
        Me.Label6.Text = "Đơn giá:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(639, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(315, 32)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "THÔNG TIN VỀ THUỐC"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_GetText
        '
        Me.btn_GetText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_GetText.Location = New System.Drawing.Point(677, 425)
        Me.btn_GetText.Name = "btn_GetText"
        Me.btn_GetText.Size = New System.Drawing.Size(85, 30)
        Me.btn_GetText.TabIndex = 213
        Me.btn_GetText.Text = "Get text"
        Me.btn_GetText.Visible = False
        '
        'cmdXoa
        '
        Me.cmdXoa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdXoa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXoa.Image = CType(resources.GetObject("cmdXoa.Image"), System.Drawing.Image)
        Me.cmdXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdXoa.Location = New System.Drawing.Point(794, 247)
        Me.cmdXoa.Name = "cmdXoa"
        Me.cmdXoa.Size = New System.Drawing.Size(74, 30)
        Me.cmdXoa.TabIndex = 9
        Me.cmdXoa.Text = "&Xóa"
        Me.cmdXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdXoa.UseVisualStyleBackColor = True
        '
        'cmdSua
        '
        Me.cmdSua.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSua.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSua.Image = CType(resources.GetObject("cmdSua.Image"), System.Drawing.Image)
        Me.cmdSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSua.Location = New System.Drawing.Point(718, 247)
        Me.cmdSua.Name = "cmdSua"
        Me.cmdSua.Size = New System.Drawing.Size(73, 30)
        Me.cmdSua.TabIndex = 8
        Me.cmdSua.Text = "    &Sửa"
        Me.cmdSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSua.UseVisualStyleBackColor = True
        '
        'cmdHuy
        '
        Me.cmdHuy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdHuy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHuy.Image = Global.PhongKham.My.Resources.Resources.Undo_16x16
        Me.cmdHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdHuy.Location = New System.Drawing.Point(794, 247)
        Me.cmdHuy.Name = "cmdHuy"
        Me.cmdHuy.Size = New System.Drawing.Size(74, 30)
        Me.cmdHuy.TabIndex = 4
        Me.cmdHuy.Text = " &Huỷ"
        Me.cmdHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdHuy.UseVisualStyleBackColor = True
        Me.cmdHuy.Visible = False
        '
        'cmdThoat
        '
        Me.cmdThoat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(870, 247)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(73, 30)
        Me.cmdThoat.TabIndex = 10
        Me.cmdThoat.Text = "     T&hoát"
        Me.cmdThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThoat.UseVisualStyleBackColor = True
        '
        'cmdThem
        '
        Me.cmdThem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdThem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThem.Image = CType(resources.GetObject("cmdThem.Image"), System.Drawing.Image)
        Me.cmdThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThem.Location = New System.Drawing.Point(646, 247)
        Me.cmdThem.Name = "cmdThem"
        Me.cmdThem.Size = New System.Drawing.Size(70, 30)
        Me.cmdThem.TabIndex = 7
        Me.cmdThem.Text = "  &Thêm"
        Me.cmdThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThem.UseVisualStyleBackColor = True
        '
        'cmdGhi
        '
        Me.cmdGhi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGhi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGhi.Image = Global.PhongKham.My.Resources.Resources.Load
        Me.cmdGhi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGhi.Location = New System.Drawing.Point(718, 247)
        Me.cmdGhi.Name = "cmdGhi"
        Me.cmdGhi.Size = New System.Drawing.Size(74, 30)
        Me.cmdGhi.TabIndex = 3
        Me.cmdGhi.Text = " &Ghi"
        Me.cmdGhi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGhi.UseVisualStyleBackColor = True
        Me.cmdGhi.Visible = False
        '
        'frmDanhMucThuoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 615)
        Me.Controls.Add(Me.btn_GetText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDonGia)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDVT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNhaSanXuat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtHamLuong)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTenThuoc)
        Me.Controls.Add(Me.lblDiaChiHuyenTinh)
        Me.Controls.Add(Me.txtTenGoc)
        Me.Controls.Add(Me.lblDiaChiCQ_Xa)
        Me.Controls.Add(Me.txtMaThuoc)
        Me.Controls.Add(Me.lblHoTenBN)
        Me.Controls.Add(Me.cmdXoa)
        Me.Controls.Add(Me.cmdSua)
        Me.Controls.Add(Me.cmdHuy)
        Me.Controls.Add(Me.cmdThoat)
        Me.Controls.Add(Me.cmdThem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdDMTHUOC)
        Me.Controls.Add(Me.cmdGhi)
        Me.Name = "frmDanhMucThuoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.grdDMTHUOC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdDMTHUOC As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdXoa As System.Windows.Forms.Button
    Friend WithEvents cmdSua As System.Windows.Forms.Button
    Friend WithEvents cmdHuy As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents cmdGhi As System.Windows.Forms.Button
    Friend WithEvents cmdThem As System.Windows.Forms.Button
    Friend WithEvents txtTenThuoc As System.Windows.Forms.TextBox
    Friend WithEvents lblDiaChiHuyenTinh As System.Windows.Forms.Label
    Friend WithEvents txtTenGoc As System.Windows.Forms.TextBox
    Friend WithEvents lblDiaChiCQ_Xa As System.Windows.Forms.Label
    Friend WithEvents txtMaThuoc As System.Windows.Forms.TextBox
    Friend WithEvents lblHoTenBN As System.Windows.Forms.Label
    Friend WithEvents txtDVT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNhaSanXuat As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHamLuong As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDonGia As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents btn_GetText As Button
End Class
