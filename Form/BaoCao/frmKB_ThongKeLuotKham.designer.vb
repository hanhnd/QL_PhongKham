<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKB_ThongkeLuotkham
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKB_ThongkeLuotkham))
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdXuatExcel = New System.Windows.Forms.Button
        Me.cmbPhongkham = New C1.Win.C1List.C1Combo
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdThongke = New System.Windows.Forms.Button
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.txtNgaykhamDen = New C1.Win.C1Input.C1DateEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNgaykhamTu = New C1.Win.C1Input.C1DateEdit
        Me.Label16 = New System.Windows.Forms.Label
        Me.grdThongkeBN = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbPhongkham, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaykhamDen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaykhamTu, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(944, 32)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "THỐNG KÊ SỐ LƯỢNG BỆNH NHÂN KHÁM BỆNH"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdXuatExcel)
        Me.GroupBox1.Controls.Add(Me.cmbPhongkham)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cmdThongke)
        Me.GroupBox1.Controls.Add(Me.cmdThoat)
        Me.GroupBox1.Controls.Add(Me.txtNgaykhamDen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNgaykhamTu)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(944, 48)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'cmdXuatExcel
        '
        Me.cmdXuatExcel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdXuatExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXuatExcel.Image = CType(resources.GetObject("cmdXuatExcel.Image"), System.Drawing.Image)
        Me.cmdXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdXuatExcel.Location = New System.Drawing.Point(741, 10)
        Me.cmdXuatExcel.Name = "cmdXuatExcel"
        Me.cmdXuatExcel.Size = New System.Drawing.Size(96, 32)
        Me.cmdXuatExcel.TabIndex = 52
        Me.cmdXuatExcel.Text = "&Xuất Excel"
        Me.cmdXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdXuatExcel.UseVisualStyleBackColor = False
        '
        'cmbPhongkham
        '
        Me.cmbPhongkham.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbPhongkham.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbPhongkham.AutoCompletion = True
        Me.cmbPhongkham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbPhongkham.Caption = ""
        Me.cmbPhongkham.CaptionHeight = 17
        Me.cmbPhongkham.CaptionStyle = Style9
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
        Me.cmbPhongkham.EvenRowStyle = Style10
        Me.cmbPhongkham.ExtendRightColumn = True
        Me.cmbPhongkham.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbPhongkham.FooterStyle = Style11
        Me.cmbPhongkham.GapHeight = 2
        Me.cmbPhongkham.HeadingStyle = Style12
        Me.cmbPhongkham.HighLightRowStyle = Style13
        Me.cmbPhongkham.ItemHeight = 15
        Me.cmbPhongkham.Location = New System.Drawing.Point(432, 15)
        Me.cmbPhongkham.MatchEntryTimeout = CType(2000, Long)
        Me.cmbPhongkham.MaxDropDownItems = CType(5, Short)
        Me.cmbPhongkham.MaxLength = 32767
        Me.cmbPhongkham.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbPhongkham.Name = "cmbPhongkham"
        Me.cmbPhongkham.OddRowStyle = Style14
        Me.cmbPhongkham.PartialRightColumn = False
        Me.cmbPhongkham.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbPhongkham.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbPhongkham.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbPhongkham.SelectedStyle = Style15
        Me.cmbPhongkham.Size = New System.Drawing.Size(177, 19)
        Me.cmbPhongkham.Style = Style16
        Me.cmbPhongkham.TabIndex = 50
        Me.cmbPhongkham.Visible = False
        Me.cmbPhongkham.PropBag = resources.GetString("cmbPhongkham.PropBag")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(362, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Phòng khám:"
        Me.Label15.Visible = False
        '
        'cmdThongke
        '
        Me.cmdThongke.BackColor = System.Drawing.Color.Transparent
        Me.cmdThongke.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThongke.Image = CType(resources.GetObject("cmdThongke.Image"), System.Drawing.Image)
        Me.cmdThongke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThongke.Location = New System.Drawing.Point(637, 11)
        Me.cmdThongke.Name = "cmdThongke"
        Me.cmdThongke.Size = New System.Drawing.Size(96, 32)
        Me.cmdThongke.TabIndex = 49
        Me.cmdThongke.Text = "     &Thực hiện"
        Me.cmdThongke.UseVisualStyleBackColor = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.Color.Transparent
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(840, 11)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(96, 32)
        Me.cmdThoat.TabIndex = 48
        Me.cmdThoat.Text = "     T&hoát"
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'txtNgaykhamDen
        '
        Me.txtNgaykhamDen.BackColor = System.Drawing.Color.White
        Me.txtNgaykhamDen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNgaykhamDen.CustomFormat = "dd/MM/yyyy"
        Me.txtNgaykhamDen.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtNgaykhamDen.Location = New System.Drawing.Point(238, 16)
        Me.txtNgaykhamDen.Name = "txtNgaykhamDen"
        Me.txtNgaykhamDen.Size = New System.Drawing.Size(122, 18)
        Me.txtNgaykhamDen.TabIndex = 46
        Me.txtNgaykhamDen.Tag = Nothing
        Me.txtNgaykhamDen.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "đến ngày:"
        '
        'txtNgaykhamTu
        '
        Me.txtNgaykhamTu.BackColor = System.Drawing.Color.White
        Me.txtNgaykhamTu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNgaykhamTu.CustomFormat = "dd/MM/yyyy"
        Me.txtNgaykhamTu.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtNgaykhamTu.Location = New System.Drawing.Point(59, 16)
        Me.txtNgaykhamTu.Name = "txtNgaykhamTu"
        Me.txtNgaykhamTu.Size = New System.Drawing.Size(122, 18)
        Me.txtNgaykhamTu.TabIndex = 44
        Me.txtNgaykhamTu.Tag = Nothing
        Me.txtNgaykhamTu.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Từ ngày:"
        '
        'grdThongkeBN
        '
        Me.grdThongkeBN.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.grdThongkeBN.AllowEditing = False
        Me.grdThongkeBN.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.grdThongkeBN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdThongkeBN.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdThongkeBN.ColumnInfo = "8,0,0,0,0,85,Columns:0{Width:51;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:223;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.grdThongkeBN.ExtendLastCol = True
        Me.grdThongkeBN.Location = New System.Drawing.Point(5, 96)
        Me.grdThongkeBN.Name = "grdThongkeBN"
        Me.grdThongkeBN.Rows.Count = 1
        Me.grdThongkeBN.Size = New System.Drawing.Size(944, 538)
        Me.grdThongkeBN.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdThongkeBN.Styles"))
        Me.grdThongkeBN.TabIndex = 59
        '
        'frmKB_ThongkeLuotkham
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(954, 644)
        Me.Controls.Add(Me.grdThongkeBN)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmKB_ThongkeLuotkham"
        Me.Text = "Thống kê bệnh nhân"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbPhongkham, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaykhamDen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaykhamTu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdThongkeBN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNgaykhamDen As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNgaykhamTu As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdThongke As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents cmbPhongkham As C1.Win.C1List.C1Combo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents grdThongkeBN As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdXuatExcel As System.Windows.Forms.Button
End Class
