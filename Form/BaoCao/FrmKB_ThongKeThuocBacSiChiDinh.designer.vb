<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKB_ThongKeThuocBacSiChiDinh
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKB_ThongKeThuocBacSiChiDinh))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grdThongkeBN = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.cmdThongke = New System.Windows.Forms.Button
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.txtTuNgay = New C1.Win.C1Input.C1DateEdit
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtDenNgay = New C1.Win.C1Input.C1DateEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFullName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbBSCD = New C1.Win.C1List.C1Combo
        Me.cmdXuatExcel = New System.Windows.Forms.Button
        CType(Me.grdThongkeBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTuNgay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDenNgay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbBSCD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdThongkeBN
        '
        Me.grdThongkeBN.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.grdThongkeBN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdThongkeBN.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdThongkeBN.ColumnInfo = "0,0,0,0,0,85,Columns:"
        Me.grdThongkeBN.ExtendLastCol = True
        Me.grdThongkeBN.Location = New System.Drawing.Point(4, 100)
        Me.grdThongkeBN.Name = "grdThongkeBN"
        Me.grdThongkeBN.Rows.Count = 1
        Me.grdThongkeBN.Rows.MinSize = 20
        Me.grdThongkeBN.Size = New System.Drawing.Size(946, 540)
        Me.grdThongkeBN.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdThongkeBN.Styles"))
        Me.grdThongkeBN.TabIndex = 0
        Me.grdThongkeBN.Tree.Column = 2
        '
        'cmdThongke
        '
        Me.cmdThongke.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdThongke.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThongke.Image = CType(resources.GetObject("cmdThongke.Image"), System.Drawing.Image)
        Me.cmdThongke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThongke.Location = New System.Drawing.Point(638, 15)
        Me.cmdThongke.Name = "cmdThongke"
        Me.cmdThongke.Size = New System.Drawing.Size(96, 32)
        Me.cmdThongke.TabIndex = 3
        Me.cmdThongke.Text = "     &Thống kê"
        Me.cmdThongke.UseVisualStyleBackColor = False
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(842, 15)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(96, 32)
        Me.cmdThoat.TabIndex = 5
        Me.cmdThoat.Text = "     T&hoát"
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'txtTuNgay
        '
        Me.txtTuNgay.BackColor = System.Drawing.Color.White
        Me.txtTuNgay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTuNgay.Culture = 1066
        Me.txtTuNgay.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtTuNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtTuNgay.Location = New System.Drawing.Point(62, 22)
        Me.txtTuNgay.Name = "txtTuNgay"
        Me.txtTuNgay.Size = New System.Drawing.Size(136, 18)
        Me.txtTuNgay.TabIndex = 0
        Me.txtTuNgay.Tag = Nothing
        Me.txtTuNgay.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Từ ngày:"
        '
        'txtDenNgay
        '
        Me.txtDenNgay.BackColor = System.Drawing.Color.White
        Me.txtDenNgay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDenNgay.Culture = 1066
        Me.txtDenNgay.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtDenNgay.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtDenNgay.Location = New System.Drawing.Point(238, 22)
        Me.txtDenNgay.Name = "txtDenNgay"
        Me.txtDenNgay.Size = New System.Drawing.Size(136, 18)
        Me.txtDenNgay.TabIndex = 1
        Me.txtDenNgay.Tag = Nothing
        Me.txtDenNgay.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "đến:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(946, 34)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "THỐNG KÊ THUỐC DO BÁC SĨ CHỈ ĐỊNH"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFullName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbBSCD)
        Me.GroupBox1.Controls.Add(Me.txtDenNgay)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmdXuatExcel)
        Me.GroupBox1.Controls.Add(Me.cmdThongke)
        Me.GroupBox1.Controls.Add(Me.cmdThoat)
        Me.GroupBox1.Controls.Add(Me.txtTuNgay)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(946, 55)
        Me.GroupBox1.TabIndex = 64
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(384, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Bác sỹ:"
        '
        'txtFullName
        '
        Me.txtFullName.Location = New System.Drawing.Point(482, 43)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(105, 20)
        Me.txtFullName.TabIndex = 115
        Me.txtFullName.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(383, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 18)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Tổng tiền chỉ định:"
        Me.Label4.Visible = False
        '
        'cmbBSCD
        '
        Me.cmbBSCD.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbBSCD.AllowColMove = False
        Me.cmbBSCD.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbBSCD.AutoCompletion = True
        Me.cmbBSCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbBSCD.Caption = ""
        Me.cmbBSCD.CaptionHeight = 17
        Me.cmbBSCD.CaptionStyle = Style1
        Me.cmbBSCD.CaptionVisible = False
        Me.cmbBSCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbBSCD.ColumnCaptionHeight = 17
        Me.cmbBSCD.ColumnFooterHeight = 17
        Me.cmbBSCD.ColumnHeaders = False
        Me.cmbBSCD.ContentHeight = 16
        Me.cmbBSCD.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.cmbBSCD.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbBSCD.DefColWidth = 1
        Me.cmbBSCD.DisplayMember = "Danh mục"
        Me.cmbBSCD.EditorBackColor = System.Drawing.Color.White
        Me.cmbBSCD.EditorFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBSCD.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbBSCD.EditorHeight = 16
        Me.cmbBSCD.EvenRowStyle = Style2
        Me.cmbBSCD.ExtendRightColumn = True
        Me.cmbBSCD.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbBSCD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBSCD.FooterStyle = Style3
        Me.cmbBSCD.GapHeight = 2
        Me.cmbBSCD.HeadingStyle = Style4
        Me.cmbBSCD.HighLightRowStyle = Style5
        Me.cmbBSCD.ItemHeight = 15
        Me.cmbBSCD.Location = New System.Drawing.Point(429, 22)
        Me.cmbBSCD.MatchCol = C1.Win.C1List.MatchColEnum.AllCols
        Me.cmbBSCD.MatchEntryTimeout = CType(2000, Long)
        Me.cmbBSCD.MaxDropDownItems = CType(10, Short)
        Me.cmbBSCD.MaxLength = 32767
        Me.cmbBSCD.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbBSCD.Name = "cmbBSCD"
        Me.cmbBSCD.OddRowStyle = Style6
        Me.cmbBSCD.PartialRightColumn = False
        Me.cmbBSCD.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbBSCD.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbBSCD.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbBSCD.SelectedStyle = Style7
        Me.cmbBSCD.Size = New System.Drawing.Size(196, 20)
        Me.cmbBSCD.Style = Style8
        Me.cmbBSCD.TabIndex = 2
        Me.cmbBSCD.PropBag = resources.GetString("cmbBSCD.PropBag")
        '
        'cmdXuatExcel
        '
        Me.cmdXuatExcel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdXuatExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXuatExcel.Image = CType(resources.GetObject("cmdXuatExcel.Image"), System.Drawing.Image)
        Me.cmdXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdXuatExcel.Location = New System.Drawing.Point(740, 15)
        Me.cmdXuatExcel.Name = "cmdXuatExcel"
        Me.cmdXuatExcel.Size = New System.Drawing.Size(96, 32)
        Me.cmdXuatExcel.TabIndex = 4
        Me.cmdXuatExcel.Text = "     &Xuất Excel"
        Me.cmdXuatExcel.UseVisualStyleBackColor = False
        '
        'FrmKB_ThongKeThuocBacSiChiDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 644)
        Me.Controls.Add(Me.grdThongkeBN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmKB_ThongKeThuocBacSiChiDinh"
        Me.ShowInTaskbar = False
        Me.Text = "Thống kê thuốc do bác sĩ chỉ định"
        CType(Me.grdThongkeBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTuNgay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDenNgay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbBSCD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdThongkeBN As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdThongke As System.Windows.Forms.Button
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents txtTuNgay As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDenNgay As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdXuatExcel As System.Windows.Forms.Button
    Friend WithEvents cmbBSCD As C1.Win.C1List.C1Combo
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
