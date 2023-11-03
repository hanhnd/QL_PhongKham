<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptTongHopThuPhiDichVu_ChiTiet 
    Inherits DataDynamics.ActiveReports.ActiveReport3 

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    'Required by the ActiveReports Designer
    Private components As System.ComponentModel.IContainer
    
    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptTongHopThuPhiDichVu_ChiTiet))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.lblTenPK = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.txtNgaythang = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.txtTT = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.txtSoTT = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox13 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox14 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        CType(Me.lblTenPK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaythang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSoTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label3, Me.Label9, Me.Label5, Me.Label4})
        Me.PageHeader1.Height = 0.3125!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtSoTT, Me.TextBox7, Me.TextBox8, Me.TextBox13, Me.TextBox14})
        Me.Detail1.Height = 0.25!
        Me.Detail1.Name = "Detail1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTT, Me.TextBox5, Me.TextBox9, Me.TextBox10})
        Me.GroupHeader1.DataField = "TenNhom"
        Me.GroupHeader1.Height = 0.2604167!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.01041667!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'lblTenPK
        '
        Me.lblTenPK.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.lblTenPK.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTenPK.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTenPK.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTenPK.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTenPK.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenPK.HyperLink = Nothing
        Me.lblTenPK.Location = CType(resources.GetObject("lblTenPK.Location"), System.Drawing.PointF)
        Me.lblTenPK.Name = "lblTenPK"
        Me.lblTenPK.Size = New System.Drawing.SizeF(2.0!, 0.375!)
        Me.lblTenPK.Text = "Phòng khám HÀ NỘI MEDIC"
        Me.lblTenPK.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label8
        '
        Me.Label8.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.HyperLink = Nothing
        Me.Label8.Location = CType(resources.GetObject("Label8.Location"), System.Drawing.PointF)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.SizeF(4.4375!, 0.375!)
        Me.Label8.Text = "THÔNG KÊ CHI TIẾT THU PHÍ DỊCH VỤ"
        Me.Label8.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtNgaythang
        '
        Me.txtNgaythang.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.txtNgaythang.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgaythang.HyperLink = Nothing
        Me.txtNgaythang.Location = CType(resources.GetObject("txtNgaythang.Location"), System.Drawing.PointF)
        Me.txtNgaythang.Name = "txtNgaythang"
        Me.txtNgaythang.Size = New System.Drawing.SizeF(4.4375!, 0.1875!)
        Me.txtNgaythang.Text = "Ngày ..... tháng ...... năm 200"
        '
        'Line1
        '
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDash
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0.5625!
        Me.Line1.X2 = 1.5625!
        Me.Line1.Y1 = 0.375!
        Me.Line1.Y2 = 0.375!
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTenPK, Me.Label8, Me.txtNgaythang, Me.Line1})
        Me.ReportHeader1.Height = 1.166667!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox1, Me.TextBox2, Me.TextBox3})
        Me.ReportFooter1.Height = 0.6666667!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Label1
        '
        Me.Label1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.HyperLink = Nothing
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.PointF)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.SizeF(0.375!, 0.3125!)
        Me.Label1.Text = "TT"
        Me.Label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label3
        '
        Me.Label3.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.HyperLink = Nothing
        Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.PointF)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.SizeF(0.8125!, 0.3125!)
        Me.Label3.Text = "Số lượng"
        Me.Label3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label9
        '
        Me.Label9.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.HyperLink = Nothing
        Me.Label9.Location = CType(resources.GetObject("Label9.Location"), System.Drawing.PointF)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.SizeF(1.3125!, 0.3125!)
        Me.Label9.Text = "Tổng tiền"
        Me.Label9.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label5
        '
        Me.Label5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.HyperLink = ""
        Me.Label5.Location = CType(resources.GetObject("Label5.Location"), System.Drawing.PointF)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.SizeF(1.4375!, 0.3125!)
        Me.Label5.Text = "Miễn giảm"
        Me.Label5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label4
        '
        Me.Label4.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.HyperLink = Nothing
        Me.Label4.Location = CType(resources.GetObject("Label4.Location"), System.Drawing.PointF)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.SizeF(3.25!, 0.3125!)
        Me.Label4.Text = "Tên dịch vụ"
        Me.Label4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtTT
        '
        Me.txtTT.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.txtTT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.txtTT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTT.DistinctField = Nothing
        Me.txtTT.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTT.Location = CType(resources.GetObject("txtTT.Location"), System.Drawing.PointF)
        Me.txtTT.Name = "txtTT"
        Me.txtTT.OutputFormat = Nothing
        Me.txtTT.Size = New System.Drawing.SizeF(0.375!, 0.25!)
        Me.txtTT.Text = Nothing
        Me.txtTT.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox5
        '
        Me.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox5.DataField = "TenNhom"
        Me.TextBox5.DistinctField = Nothing
        Me.TextBox5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = CType(resources.GetObject("TextBox5.Location"), System.Drawing.PointF)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = Nothing
        Me.TextBox5.Size = New System.Drawing.SizeF(3.25!, 0.25!)
        Me.TextBox5.Text = Nothing
        Me.TextBox5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox9
        '
        Me.TextBox9.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox9.DataField = "SoLuong"
        Me.TextBox9.DistinctField = Nothing
        Me.TextBox9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = CType(resources.GetObject("TextBox9.Location"), System.Drawing.PointF)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = "  0"
        Me.TextBox9.Size = New System.Drawing.SizeF(0.8125!, 0.25!)
        Me.TextBox9.SummaryGroup = "GroupHeader1"
        Me.TextBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox9.Text = Nothing
        Me.TextBox9.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox10
        '
        Me.TextBox10.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.TextBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.TextBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox10.DataField = "ThanhTien"
        Me.TextBox10.DistinctField = Nothing
        Me.TextBox10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = CType(resources.GetObject("TextBox10.Location"), System.Drawing.PointF)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = "### ### ###"
        Me.TextBox10.Size = New System.Drawing.SizeF(2.75!, 0.25!)
        Me.TextBox10.SummaryGroup = "GroupHeader1"
        Me.TextBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox10.Text = Nothing
        Me.TextBox10.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtSoTT
        '
        Me.txtSoTT.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.txtSoTT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.txtSoTT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.txtSoTT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSoTT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.txtSoTT.DistinctField = Nothing
        Me.txtSoTT.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSoTT.Location = CType(resources.GetObject("txtSoTT.Location"), System.Drawing.PointF)
        Me.txtSoTT.Name = "txtSoTT"
        Me.txtSoTT.OutputFormat = Nothing
        Me.txtSoTT.Size = New System.Drawing.SizeF(0.5!, 0.25!)
        Me.txtSoTT.Text = Nothing
        Me.txtSoTT.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox7
        '
        Me.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox7.DataField = "TenDichvu"
        Me.TextBox7.DistinctField = Nothing
        Me.TextBox7.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = CType(resources.GetObject("TextBox7.Location"), System.Drawing.PointF)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = Nothing
        Me.TextBox7.Size = New System.Drawing.SizeF(3.125!, 0.25!)
        Me.TextBox7.Text = Nothing
        Me.TextBox7.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox8
        '
        Me.TextBox8.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox8.DataField = "SoLuong"
        Me.TextBox8.DistinctField = Nothing
        Me.TextBox8.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = CType(resources.GetObject("TextBox8.Location"), System.Drawing.PointF)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = "  0"
        Me.TextBox8.Size = New System.Drawing.SizeF(0.8125!, 0.25!)
        Me.TextBox8.Text = Nothing
        Me.TextBox8.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox13
        '
        Me.TextBox13.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.TextBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox13.DataField = "MienGiam"
        Me.TextBox13.DistinctField = Nothing
        Me.TextBox13.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox13.Location = CType(resources.GetObject("TextBox13.Location"), System.Drawing.PointF)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.OutputFormat = "  0"
        Me.TextBox13.Size = New System.Drawing.SizeF(1.4375!, 0.25!)
        Me.TextBox13.Text = Nothing
        Me.TextBox13.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox14
        '
        Me.TextBox14.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.TextBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.TextBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox14.DataField = "ThanhTien"
        Me.TextBox14.DistinctField = Nothing
        Me.TextBox14.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox14.Location = CType(resources.GetObject("TextBox14.Location"), System.Drawing.PointF)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.OutputFormat = "### ### ###"
        Me.TextBox14.Size = New System.Drawing.SizeF(1.3125!, 0.25!)
        Me.TextBox14.Text = Nothing
        Me.TextBox14.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox1
        '
        Me.TextBox1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox1.DataField = "SoLuong"
        Me.TextBox1.DistinctField = Nothing
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = CType(resources.GetObject("TextBox1.Location"), System.Drawing.PointF)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = "  0"
        Me.TextBox1.Size = New System.Drawing.SizeF(0.8125!, 0.25!)
        Me.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox1.Text = Nothing
        Me.TextBox1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox2
        '
        Me.TextBox2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox2.DataField = "Thoigianthanhtoan"
        Me.TextBox2.DistinctField = Nothing
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox2.Location = CType(resources.GetObject("TextBox2.Location"), System.Drawing.PointF)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = Nothing
        Me.TextBox2.Size = New System.Drawing.SizeF(3.625!, 0.25!)
        Me.TextBox2.Text = "TỔNG CỘNG"
        Me.TextBox2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox3
        '
        Me.TextBox3.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox3.DataField = "ThanhTien"
        Me.TextBox3.DistinctField = Nothing
        Me.TextBox3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = CType(resources.GetObject("TextBox3.Location"), System.Drawing.PointF)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = "### ### ###"
        Me.TextBox3.Size = New System.Drawing.SizeF(2.75!, 0.25!)
        Me.TextBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.TextBox3.Text = Nothing
        Me.TextBox3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'rptTongHopThuPhiDichVu_ChiTiet
        '
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.291667!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        CType(Me.lblTenPK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaythang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSoTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblTenPK As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNgaythang As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSoTT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox13 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox14 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
End Class
