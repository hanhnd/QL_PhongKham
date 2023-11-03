<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThuPhi_TongHopThu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThuPhi_TongHopThu))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.cmdXuat_Excel = New System.Windows.Forms.Button()
        Me.txtDen = New C1.Win.C1Input.C1DateEdit()
        Me.cmdInDS = New System.Windows.Forms.Button()
        Me.grdThongkeBN = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtNgaykham = New C1.Win.C1Input.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbNhomDV = New C1.Win.C1List.C1Combo()
        Me.cmdThongke = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.txtDen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdThongkeBN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaykham, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbNhomDV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdXuat_Excel
        '
        Me.cmdXuat_Excel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdXuat_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXuat_Excel.Image = CType(resources.GetObject("cmdXuat_Excel.Image"), System.Drawing.Image)
        Me.cmdXuat_Excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdXuat_Excel.Location = New System.Drawing.Point(859, 12)
        Me.cmdXuat_Excel.Name = "cmdXuat_Excel"
        Me.cmdXuat_Excel.Size = New System.Drawing.Size(96, 30)
        Me.cmdXuat_Excel.TabIndex = 176
        Me.cmdXuat_Excel.Text = "  Xuất Excel"
        Me.cmdXuat_Excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdXuat_Excel.UseVisualStyleBackColor = False
        '
        'txtDen
        '
        Me.txtDen.BackColor = System.Drawing.Color.White
        Me.txtDen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDen.Culture = 1066
        Me.txtDen.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtDen.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtDen.Location = New System.Drawing.Point(249, 18)
        Me.txtDen.Name = "txtDen"
        Me.txtDen.Size = New System.Drawing.Size(168, 18)
        Me.txtDen.TabIndex = 56
        Me.txtDen.Tag = Nothing
        Me.txtDen.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'cmdInDS
        '
        Me.cmdInDS.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdInDS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInDS.Image = Global.PhongKham.My.Resources.Resources.Print_16x16
        Me.cmdInDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdInDS.Location = New System.Drawing.Point(959, 11)
        Me.cmdInDS.Name = "cmdInDS"
        Me.cmdInDS.Size = New System.Drawing.Size(96, 30)
        Me.cmdInDS.TabIndex = 177
        Me.cmdInDS.Text = "     &In DS"
        Me.cmdInDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdInDS.UseVisualStyleBackColor = False
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
        Me.grdThongkeBN.Location = New System.Drawing.Point(5, 87)
        Me.grdThongkeBN.Name = "grdThongkeBN"
        Me.grdThongkeBN.Rows.Count = 1
        Me.grdThongkeBN.Rows.MinSize = 20
        Me.grdThongkeBN.Size = New System.Drawing.Size(1231, 552)
        Me.grdThongkeBN.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdThongkeBN.Styles"))
        Me.grdThongkeBN.TabIndex = 61
        '
        'txtNgaykham
        '
        Me.txtNgaykham.BackColor = System.Drawing.Color.White
        Me.txtNgaykham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNgaykham.Culture = 1066
        Me.txtNgaykham.CustomFormat = "HH:mm dd/MM/yyyy"
        Me.txtNgaykham.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.txtNgaykham.Location = New System.Drawing.Point(37, 16)
        Me.txtNgaykham.Name = "txtNgaykham"
        Me.txtNgaykham.Size = New System.Drawing.Size(168, 18)
        Me.txtNgaykham.TabIndex = 55
        Me.txtNgaykham.Tag = Nothing
        Me.txtNgaykham.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "đến:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(23, 13)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Từ:"
        '
        'cmdThoat
        '
        Me.cmdThoat.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = CType(resources.GetObject("cmdThoat.Image"), System.Drawing.Image)
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(1061, 12)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(96, 30)
        Me.cmdThoat.TabIndex = 48
        Me.cmdThoat.Text = "     T&hoát"
        Me.cmdThoat.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1240, 32)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "BÁO CÁO THU DỊCH VỤ Y TẾ NGOẠI TRÚ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbNhomDV)
        Me.GroupBox1.Controls.Add(Me.cmdInDS)
        Me.GroupBox1.Controls.Add(Me.cmdXuat_Excel)
        Me.GroupBox1.Controls.Add(Me.txtDen)
        Me.GroupBox1.Controls.Add(Me.txtNgaykham)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cmdThongke)
        Me.GroupBox1.Controls.Add(Me.cmdThoat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1231, 49)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(442, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 186
        Me.Label3.Text = "Nhóm dịch vụ:"
        '
        'cmbNhomDV
        '
        Me.cmbNhomDV.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbNhomDV.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbNhomDV.AutoCompletion = True
        Me.cmbNhomDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbNhomDV.Caption = ""
        Me.cmbNhomDV.CaptionHeight = 17
        Me.cmbNhomDV.CaptionStyle = Style1
        Me.cmbNhomDV.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbNhomDV.ColumnCaptionHeight = 17
        Me.cmbNhomDV.ColumnFooterHeight = 17
        Me.cmbNhomDV.ColumnHeaders = False
        Me.cmbNhomDV.ContentHeight = 15
        Me.cmbNhomDV.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.cmbNhomDV.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbNhomDV.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cmbNhomDV.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNhomDV.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbNhomDV.EditorHeight = 15
        Me.cmbNhomDV.EvenRowStyle = Style2
        Me.cmbNhomDV.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbNhomDV.FooterStyle = Style3
        Me.cmbNhomDV.GapHeight = 2
        Me.cmbNhomDV.HeadingStyle = Style4
        Me.cmbNhomDV.HighLightRowStyle = Style5
        Me.cmbNhomDV.ItemHeight = 15
        Me.cmbNhomDV.Location = New System.Drawing.Point(533, 18)
        Me.cmbNhomDV.MatchEntryTimeout = CType(2000, Long)
        Me.cmbNhomDV.MaxDropDownItems = CType(5, Short)
        Me.cmbNhomDV.MaxLength = 32767
        Me.cmbNhomDV.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbNhomDV.Name = "cmbNhomDV"
        Me.cmbNhomDV.OddRowStyle = Style6
        Me.cmbNhomDV.PartialRightColumn = False
        Me.cmbNhomDV.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbNhomDV.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbNhomDV.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbNhomDV.SelectedStyle = Style7
        Me.cmbNhomDV.Size = New System.Drawing.Size(204, 19)
        Me.cmbNhomDV.Style = Style8
        Me.cmbNhomDV.TabIndex = 184
        Me.cmbNhomDV.PropBag = resources.GetString("cmbNhomDV.PropBag")
        '
        'cmdThongke
        '
        Me.cmdThongke.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdThongke.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThongke.Image = CType(resources.GetObject("cmdThongke.Image"), System.Drawing.Image)
        Me.cmdThongke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThongke.Location = New System.Drawing.Point(760, 12)
        Me.cmdThongke.Name = "cmdThongke"
        Me.cmdThongke.Size = New System.Drawing.Size(96, 30)
        Me.cmdThongke.TabIndex = 49
        Me.cmdThongke.Text = "     &Thực hiện"
        Me.cmdThongke.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdThongke.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(57, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 30)
        Me.Button1.TabIndex = 49
        Me.Button1.Text = "Get text"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'frmThuPhi_TongHopThu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 644)
        Me.Controls.Add(Me.grdThongkeBN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmThuPhi_TongHopThu"
        Me.Text = "Báo cáo thu dịch vụ y tế ngoại trú"
        CType(Me.txtDen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdThongkeBN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaykham, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbNhomDV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdXuat_Excel As System.Windows.Forms.Button
    Friend WithEvents txtDen As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cmdInDS As System.Windows.Forms.Button
    Friend WithEvents grdThongkeBN As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtNgaykham As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdThongke As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbNhomDV As C1.Win.C1List.C1Combo
    Friend WithEvents Button1 As Button
End Class
