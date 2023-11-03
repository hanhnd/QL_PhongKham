<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhapChiDinh
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNhapChiDinh))
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.cmbNhomPPDT = New C1.Win.C1List.C1Combo
        Me.grdDMPhuongphap_DT = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Label23 = New System.Windows.Forms.Label
        Me.grdChitietND_PPDT = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.cmdThoat = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.cmdChon = New System.Windows.Forms.Button
        CType(Me.cmbNhomPPDT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDMPhuongphap_DT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdChitietND_PPDT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbNhomPPDT
        '
        Me.cmbNhomPPDT.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbNhomPPDT.AllowRowSizing = C1.Win.C1List.RowSizingEnum.AllRows
        Me.cmbNhomPPDT.AutoCompletion = True
        Me.cmbNhomPPDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbNhomPPDT.Caption = ""
        Me.cmbNhomPPDT.CaptionHeight = 17
        Me.cmbNhomPPDT.CaptionStyle = Style1
        Me.cmbNhomPPDT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbNhomPPDT.ColumnCaptionHeight = 17
        Me.cmbNhomPPDT.ColumnFooterHeight = 17
        Me.cmbNhomPPDT.ColumnHeaders = False
        Me.cmbNhomPPDT.ColumnWidth = 1
        Me.cmbNhomPPDT.ContentHeight = 15
        Me.cmbNhomPPDT.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.cmbNhomPPDT.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbNhomPPDT.DefColWidth = 1
        Me.cmbNhomPPDT.DisplayMember = "Ten"
        Me.cmbNhomPPDT.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cmbNhomPPDT.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNhomPPDT.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbNhomPPDT.EditorHeight = 15
        Me.cmbNhomPPDT.EvenRowStyle = Style2
        Me.cmbNhomPPDT.ExtendRightColumn = True
        Me.cmbNhomPPDT.FlatStyle = C1.Win.C1List.FlatModeEnum.Popup
        Me.cmbNhomPPDT.FooterStyle = Style3
        Me.cmbNhomPPDT.GapHeight = 2
        Me.cmbNhomPPDT.HeadingStyle = Style4
        Me.cmbNhomPPDT.HighLightRowStyle = Style5
        Me.cmbNhomPPDT.ItemHeight = 15
        Me.cmbNhomPPDT.Location = New System.Drawing.Point(1, 2)
        Me.cmbNhomPPDT.MatchEntryTimeout = CType(2000, Long)
        Me.cmbNhomPPDT.MaxDropDownItems = CType(5, Short)
        Me.cmbNhomPPDT.MaxLength = 32767
        Me.cmbNhomPPDT.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbNhomPPDT.Name = "cmbNhomPPDT"
        Me.cmbNhomPPDT.OddRowStyle = Style6
        Me.cmbNhomPPDT.PartialRightColumn = False
        Me.cmbNhomPPDT.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbNhomPPDT.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbNhomPPDT.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbNhomPPDT.SelectedStyle = Style7
        Me.cmbNhomPPDT.Size = New System.Drawing.Size(498, 19)
        Me.cmbNhomPPDT.Style = Style8
        Me.cmbNhomPPDT.TabIndex = 87
        Me.cmbNhomPPDT.PropBag = resources.GetString("cmbNhomPPDT.PropBag")
        '
        'grdDMPhuongphap_DT
        '
        Me.grdDMPhuongphap_DT.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.grdDMPhuongphap_DT.AllowEditing = False
        Me.grdDMPhuongphap_DT.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.grdDMPhuongphap_DT.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:272;Caption:""Dịch vụ khám và điều trị"";TextAlignFixe" & _
            "d:CenterCenter;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:41;Caption:""Mã PP"";Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.grdDMPhuongphap_DT.ExtendLastCol = True
        Me.grdDMPhuongphap_DT.Location = New System.Drawing.Point(1, 22)
        Me.grdDMPhuongphap_DT.Name = "grdDMPhuongphap_DT"
        Me.grdDMPhuongphap_DT.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdDMPhuongphap_DT.Size = New System.Drawing.Size(498, 128)
        Me.grdDMPhuongphap_DT.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdDMPhuongphap_DT.Styles"))
        Me.grdDMPhuongphap_DT.TabIndex = 88
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.DarkCyan
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Yellow
        Me.Label23.Location = New System.Drawing.Point(-2, 153)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(501, 24)
        Me.Label23.TabIndex = 90
        Me.Label23.Text = "CHI TIẾT CÁC DỊCH VỤ"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdChitietND_PPDT
        '
        Me.grdChitietND_PPDT.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.grdChitietND_PPDT.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.grdChitietND_PPDT.ColumnInfo = resources.GetString("grdChitietND_PPDT.ColumnInfo")
        Me.grdChitietND_PPDT.ExtendLastCol = True
        Me.grdChitietND_PPDT.Location = New System.Drawing.Point(1, 178)
        Me.grdChitietND_PPDT.Name = "grdChitietND_PPDT"
        Me.grdChitietND_PPDT.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdChitietND_PPDT.Size = New System.Drawing.Size(498, 302)
        Me.grdChitietND_PPDT.Styles = New C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("grdChitietND_PPDT.Styles"))
        Me.grdChitietND_PPDT.TabIndex = 89
        '
        'cmdThoat
        '
        Me.cmdThoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdThoat.Image = Global.PhongKham.My.Resources.Resources._exit
        Me.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdThoat.Location = New System.Drawing.Point(413, 484)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(86, 32)
        Me.cmdThoat.TabIndex = 153
        Me.cmdThoat.Text = "    &Đóng"
        Me.cmdThoat.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.PhongKham.My.Resources.Resources.page_cross_icon
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(182, 484)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(86, 32)
        Me.btnDelete.TabIndex = 152
        Me.btnDelete.Text = "     &Xóa "
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'cmdChon
        '
        Me.cmdChon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChon.Image = CType(resources.GetObject("cmdChon.Image"), System.Drawing.Image)
        Me.cmdChon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdChon.Location = New System.Drawing.Point(298, 484)
        Me.cmdChon.Name = "cmdChon"
        Me.cmdChon.Size = New System.Drawing.Size(86, 32)
        Me.cmdChon.TabIndex = 152
        Me.cmdChon.Text = "     &Chọn"
        Me.cmdChon.UseVisualStyleBackColor = True
        '
        'frmNhapChiDinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 521)
        Me.Controls.Add(Me.cmdThoat)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.cmdChon)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.grdChitietND_PPDT)
        Me.Controls.Add(Me.grdDMPhuongphap_DT)
        Me.Controls.Add(Me.cmbNhomPPDT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNhapChiDinh"
        Me.Text = "Nhóm dịch vụ y tế"
        CType(Me.cmbNhomPPDT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDMPhuongphap_DT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdChitietND_PPDT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbNhomPPDT As C1.Win.C1List.C1Combo
    Friend WithEvents grdDMPhuongphap_DT As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents grdChitietND_PPDT As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents cmdChon As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
End Class
