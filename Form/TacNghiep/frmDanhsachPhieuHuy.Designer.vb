<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhsachPhieuhuy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDanhsachPhieuhuy))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdXuatExcel = New System.Windows.Forms.Button()
        Me.cmdInDS = New System.Windows.Forms.Button()
        Me.txtDenngay = New C1.Win.C1Input.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTungay = New C1.Win.C1Input.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdThuchien = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTongtien = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblDanhsachPhieuthu = New System.Windows.Forms.Label()
        Me.lblChitietBL = New System.Windows.Forms.Label()
        Me.grdChitiet = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grdDSPhieuthu = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lbl_Count = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.txtDenngay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTungay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdChitiet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDSPhieuthu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmdXuatExcel)
        Me.Panel1.Controls.Add(Me.cmdInDS)
        Me.Panel1.Controls.Add(Me.txtDenngay)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtTungay)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmdThuchien)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmdThoat)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lblTongtien)
        Me.Panel1.Controls.Add(Me.Label41)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1056, 46)
        Me.Panel1.TabIndex = 201
        '
        'cmdXuatExcel
        '
        Me.cmdXuatExcel.BackColor = System.Drawing.Color.Transparent
        Me.cmdXuatExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXuatExcel.Image = Global.PhongKham.My.Resources.Resources.excel_icon1
        Me.cmdXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdXuatExcel.Location = New System.Drawing.Point(798, 8)
        Me.cmdXuatExcel.Name = "cmdXuatExcel"
        Me.cmdXuatExcel.Size = New System.Drawing.Size(122, 30)
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
        Me.cmdInDS.Location = New System.Drawing.Point(709, 8)
        Me.cmdInDS.Name = "cmdInDS"
        Me.cmdInDS.Size = New System.Drawing.Size(86, 30)
        Me.cmdInDS.TabIndex = 165
        Me.cmdInDS.Text = "In d/sách"
        Me.cmdInDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdInDS.UseVisualStyleBackColor = False
        '
        'txtDenngay
        '
        Me.txtDenngay.BackColor = System.Drawing.Color.White
        Me.txtDenngay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDenngay.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtDenngay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDenngay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtDenngay.Location = New System.Drawing.Point(232, 8)
        Me.txtDenngay.Name = "txtDenngay"
        Me.txtDenngay.Size = New System.Drawing.Size(144, 20)
        Me.txtDenngay.TabIndex = 162
        Me.txtDenngay.Tag = Nothing
        Me.txtDenngay.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(200, 11)
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
        Me.txtTungay.Location = New System.Drawing.Point(40, 8)
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
        Me.Label2.Location = New System.Drawing.Point(8, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 16)
        Me.Label2.TabIndex = 163
        Me.Label2.Text = "Từ:"
        '
        'cmdThuchien
        '
        Me.cmdThuchien.BackColor = System.Drawing.Color.Transparent
        Me.cmdThuchien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThuchien.Image = Global.PhongKham.My.Resources.Resources.download1
        Me.cmdThuchien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThuchien.Location = New System.Drawing.Point(607, 8)
        Me.cmdThuchien.Name = "cmdThuchien"
        Me.cmdThuchien.Size = New System.Drawing.Size(98, 30)
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
        Me.Button1.Location = New System.Drawing.Point(985, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 30)
        Me.Button1.TabIndex = 159
        Me.Button1.Text = "Get text"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.Color.Transparent
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = Global.PhongKham.My.Resources.Resources._exit
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(923, 8)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(80, 30)
        Me.cmdThoat.TabIndex = 159
        Me.cmdThoat.Text = "   Đóng lại"
        Me.cmdThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label9.Location = New System.Drawing.Point(548, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 24)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "đồng"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTongtien
        '
        Me.lblTongtien.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTongtien.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTongtien.Location = New System.Drawing.Point(451, 7)
        Me.lblTongtien.Name = "lblTongtien"
        Me.lblTongtien.Size = New System.Drawing.Size(99, 24)
        Me.lblTongtien.TabIndex = 157
        Me.lblTongtien.Text = "0"
        Me.lblTongtien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label41.Location = New System.Drawing.Point(387, 8)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(72, 24)
        Me.Label41.TabIndex = 156
        Me.Label41.Text = "Tổng tiền:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDanhsachPhieuthu
        '
        Me.lblDanhsachPhieuthu.BackColor = System.Drawing.Color.Salmon
        Me.lblDanhsachPhieuthu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDanhsachPhieuthu.ForeColor = System.Drawing.Color.White
        Me.lblDanhsachPhieuthu.Location = New System.Drawing.Point(2, 48)
        Me.lblDanhsachPhieuthu.Name = "lblDanhsachPhieuthu"
        Me.lblDanhsachPhieuthu.Size = New System.Drawing.Size(454, 21)
        Me.lblDanhsachPhieuthu.TabIndex = 197
        Me.lblDanhsachPhieuthu.Text = "Danh sách các phiếu đã hủy"
        Me.lblDanhsachPhieuthu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.lblChitietBL.Size = New System.Drawing.Size(592, 21)
        Me.lblChitietBL.TabIndex = 206
        Me.lblChitietBL.Text = "   Chi tiết biên lai số:"
        Me.lblChitietBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdChitiet
        '
        Me.grdChitiet.AllowEditing = False
        Me.grdChitiet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdChitiet.BackgroundImage = CType(resources.GetObject("grdChitiet.BackgroundImage"), System.Drawing.Image)
        Me.grdChitiet.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdChitiet.ColumnInfo = resources.GetString("grdChitiet.ColumnInfo")
        Me.grdChitiet.ExtendLastCol = True
        Me.grdChitiet.Location = New System.Drawing.Point(464, 71)
        Me.grdChitiet.Name = "grdChitiet"
        Me.grdChitiet.Rows.Count = 1
        Me.grdChitiet.Rows.MinSize = 20
        Me.grdChitiet.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdChitiet.Size = New System.Drawing.Size(592, 569)
        Me.grdChitiet.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdChitiet.Styles"))
        Me.grdChitiet.TabIndex = 205
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
        Me.grdDSPhieuthu.Rows.Count = 1
        Me.grdDSPhieuthu.Rows.MinSize = 20
        Me.grdDSPhieuthu.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdDSPhieuthu.Size = New System.Drawing.Size(454, 569)
        Me.grdDSPhieuthu.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdDSPhieuthu.Styles"))
        Me.grdDSPhieuthu.TabIndex = 198
        '
        'lbl_Count
        '
        Me.lbl_Count.AutoSize = True
        Me.lbl_Count.BackColor = System.Drawing.Color.Salmon
        Me.lbl_Count.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Count.ForeColor = System.Drawing.Color.White
        Me.lbl_Count.Location = New System.Drawing.Point(222, 52)
        Me.lbl_Count.Name = "lbl_Count"
        Me.lbl_Count.Size = New System.Drawing.Size(14, 13)
        Me.lbl_Count.TabIndex = 207
        Me.lbl_Count.Text = "0"
        '
        'frmDanhsachPhieuhuy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 644)
        Me.Controls.Add(Me.lbl_Count)
        Me.Controls.Add(Me.lblChitietBL)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblDanhsachPhieuthu)
        Me.Controls.Add(Me.grdChitiet)
        Me.Controls.Add(Me.grdDSPhieuthu)
        Me.Name = "frmDanhsachPhieuhuy"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtDenngay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTungay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdChitiet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDSPhieuthu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDanhsachPhieuthu As System.Windows.Forms.Label
    Friend WithEvents grdDSPhieuthu As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdThuchien As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTongtien As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtDenngay As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTungay As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdXuatExcel As System.Windows.Forms.Button
    Friend WithEvents cmdInDS As System.Windows.Forms.Button
    Friend WithEvents grdChitiet As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblChitietBL As System.Windows.Forms.Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lbl_Count As Label
End Class
