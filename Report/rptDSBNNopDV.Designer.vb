<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptDSBNNopDV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptDSBNNopDV))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtstt = New DataDynamics.ActiveReports.TextBox
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox6 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.lblTenPK = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.txtNgaythang = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.txtTongtien = New DataDynamics.ActiveReports.TextBox
        Me.TextBox7 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox8 = New DataDynamics.ActiveReports.TextBox
        Me.txtBangchu = New DataDynamics.ActiveReports.TextBox
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.txtTT = New DataDynamics.ActiveReports.TextBox
        Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox9 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox10 = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtstt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTenPK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaythang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTongtien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBangchu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.Label3, Me.Label9, Me.Label5, Me.Label4})
        Me.PageHeader1.Height = 0.25!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Label1
        '
        Me.Label1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.HyperLink = Nothing
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.PointF)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.SizeF(0.375!, 0.25!)
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
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.HyperLink = Nothing
        Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.PointF)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.SizeF(2.3125!, 0.25!)
        Me.Label3.Text = "HỌ VÀ TÊN"
        Me.Label3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label9
        '
        Me.Label9.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.HyperLink = Nothing
        Me.Label9.Location = CType(resources.GetObject("Label9.Location"), System.Drawing.PointF)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.SizeF(1.3125!, 0.25!)
        Me.Label9.Text = "SỐ TIỀN"
        Me.Label9.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label5
        '
        Me.Label5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.HyperLink = ""
        Me.Label5.Location = CType(resources.GetObject("Label5.Location"), System.Drawing.PointF)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.SizeF(1.4375!, 0.25!)
        Me.Label5.Text = "Nhóm dịch vụ"
        Me.Label5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label4
        '
        Me.Label4.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.HyperLink = Nothing
        Me.Label4.Location = CType(resources.GetObject("Label4.Location"), System.Drawing.PointF)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.SizeF(1.75!, 0.25!)
        Me.Label4.Text = "Thời gian TT"
        Me.Label4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtstt, Me.TextBox2, Me.TextBox6, Me.TextBox1})
        Me.Detail1.Height = 0.2604167!
        Me.Detail1.Name = "Detail1"
        '
        'txtstt
        '
        Me.txtstt.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.txtstt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.txtstt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.txtstt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtstt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.txtstt.DistinctField = Nothing
        Me.txtstt.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtstt.Location = CType(resources.GetObject("txtstt.Location"), System.Drawing.PointF)
        Me.txtstt.Name = "txtstt"
        Me.txtstt.OutputFormat = Nothing
        Me.txtstt.Size = New System.Drawing.SizeF(2.125!, 0.25!)
        Me.txtstt.Text = Nothing
        Me.txtstt.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox2
        '
        Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox2.DistinctField = Nothing
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TextBox2.Location = CType(resources.GetObject("TextBox2.Location"), System.Drawing.PointF)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = "  0"
        Me.TextBox2.Size = New System.Drawing.SizeF(2.3125!, 0.25!)
        Me.TextBox2.Text = Nothing
        Me.TextBox2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox6
        '
        Me.TextBox6.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox6.DataField = "Sotien"
        Me.TextBox6.DistinctField = Nothing
        Me.TextBox6.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TextBox6.Location = CType(resources.GetObject("TextBox6.Location"), System.Drawing.PointF)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.OutputFormat = Nothing
        Me.TextBox6.Size = New System.Drawing.SizeF(1.3125!, 0.25!)
        Me.TextBox6.Text = Nothing
        Me.TextBox6.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox1.DataField = "Tennhom"
        Me.TextBox1.DistinctField = Nothing
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TextBox1.Location = CType(resources.GetObject("TextBox1.Location"), System.Drawing.PointF)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = "  0"
        Me.TextBox1.Size = New System.Drawing.SizeF(1.4375!, 0.25!)
        Me.TextBox1.Text = Nothing
        Me.TextBox1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.lblTenPK, Me.Label8, Me.txtNgaythang, Me.Line1, Me.Label11})
        Me.ReportHeader1.Height = 0.8645833!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Label2
        '
        Me.Label2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.HyperLink = Nothing
        Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.PointF)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.SizeF(2.375!, 0.25!)
        Me.Label2.Text = ""
        Me.Label2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
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
        Me.lblTenPK.Size = New System.Drawing.SizeF(2.375!, 0.375!)
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
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.HyperLink = Nothing
        Me.Label8.Location = CType(resources.GetObject("Label8.Location"), System.Drawing.PointF)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.SizeF(4.4375!, 0.25!)
        Me.Label8.Text = "DANH SÁCH BỆNH NHÂN"
        Me.Label8.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtNgaythang
        '
        Me.txtNgaythang.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.txtNgaythang.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Line1.X1 = 0.5!
        Me.Line1.X2 = 1.8125!
        Me.Line1.Y1 = 0.3125!
        Me.Line1.Y2 = 0.3125!
        '
        'Label11
        '
        Me.Label11.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.HyperLink = ""
        Me.Label11.Location = CType(resources.GetObject("Label11.Location"), System.Drawing.PointF)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.SizeF(4.4375!, 0.25!)
        Me.Label11.Text = "Nộp tiền:"
        Me.Label11.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.txtTongtien, Me.TextBox7, Me.TextBox8, Me.txtBangchu, Me.Label10, Me.Label6, Me.Label7})
        Me.ReportFooter1.Height = 2.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Line2
        '
        Me.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 0.0!
        Me.Line2.X2 = 7.25!
        Me.Line2.Y1 = 0.0!
        Me.Line2.Y2 = 0.0!
        '
        'txtTongtien
        '
        Me.txtTongtien.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTongtien.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTongtien.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTongtien.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTongtien.DataField = "Sotien"
        Me.txtTongtien.DistinctField = Nothing
        Me.txtTongtien.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTongtien.Location = CType(resources.GetObject("txtTongtien.Location"), System.Drawing.PointF)
        Me.txtTongtien.Name = "txtTongtien"
        Me.txtTongtien.OutputFormat = Nothing
        Me.txtTongtien.Size = New System.Drawing.SizeF(1.375!, 0.1875!)
        Me.txtTongtien.Text = Nothing
        Me.txtTongtien.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox7
        '
        Me.TextBox7.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox7.DistinctField = Nothing
        Me.TextBox7.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TextBox7.Location = CType(resources.GetObject("TextBox7.Location"), System.Drawing.PointF)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.OutputFormat = Nothing
        Me.TextBox7.Size = New System.Drawing.SizeF(0.8125!, 0.1875!)
        Me.TextBox7.Text = "Tổng tiền:"
        Me.TextBox7.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox8
        '
        Me.TextBox8.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox8.DistinctField = Nothing
        Me.TextBox8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = CType(resources.GetObject("TextBox8.Location"), System.Drawing.PointF)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.OutputFormat = Nothing
        Me.TextBox8.Size = New System.Drawing.SizeF(0.8125!, 0.1875!)
        Me.TextBox8.Text = "Bằng chữ:"
        Me.TextBox8.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtBangchu
        '
        Me.txtBangchu.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBangchu.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBangchu.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBangchu.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBangchu.DataField = "Sotien"
        Me.txtBangchu.DistinctField = Nothing
        Me.txtBangchu.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBangchu.Location = CType(resources.GetObject("txtBangchu.Location"), System.Drawing.PointF)
        Me.txtBangchu.Name = "txtBangchu"
        Me.txtBangchu.OutputFormat = Nothing
        Me.txtBangchu.Size = New System.Drawing.SizeF(6.125!, 0.1875!)
        Me.txtBangchu.Text = Nothing
        Me.txtBangchu.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label10
        '
        Me.Label10.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.HyperLink = Nothing
        Me.Label10.Location = CType(resources.GetObject("Label10.Location"), System.Drawing.PointF)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.SizeF(1.375!, 0.25!)
        Me.Label10.Text = "Người lập bảng"
        Me.Label10.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label6
        '
        Me.Label6.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.HyperLink = ""
        Me.Label6.Location = CType(resources.GetObject("Label6.Location"), System.Drawing.PointF)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.SizeF(2.0625!, 0.25!)
        Me.Label6.Text = ""
        Me.Label6.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label7
        '
        Me.Label7.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.HyperLink = ""
        Me.Label7.Location = CType(resources.GetObject("Label7.Location"), System.Drawing.PointF)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.SizeF(2.25!, 0.25!)
        Me.Label7.Text = "Ngày .............tháng ...........năm..................."
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTT, Me.TextBox5, Me.TextBox9, Me.TextBox10})
        Me.GroupHeader1.DataField = "Thoigianthanhtoan"
        Me.GroupHeader1.Height = 0.25!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'txtTT
        '
        Me.txtTT.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.txtTT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.txtTT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.txtTT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.txtTT.DistinctField = Nothing
        Me.txtTT.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtTT.Location = CType(resources.GetObject("txtTT.Location"), System.Drawing.PointF)
        Me.txtTT.Name = "txtTT"
        Me.txtTT.OutputFormat = Nothing
        Me.txtTT.Size = New System.Drawing.SizeF(0.375!, 0.25!)
        Me.txtTT.Text = Nothing
        Me.txtTT.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox5
        '
        Me.TextBox5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox5.DataField = "Thoigianthanhtoan"
        Me.TextBox5.DistinctField = Nothing
        Me.TextBox5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox5.Location = CType(resources.GetObject("TextBox5.Location"), System.Drawing.PointF)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.OutputFormat = Nothing
        Me.TextBox5.Size = New System.Drawing.SizeF(1.75!, 0.25!)
        Me.TextBox5.Text = Nothing
        Me.TextBox5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox9
        '
        Me.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox9.DataField = "Nguoinop_hoten"
        Me.TextBox9.DistinctField = Nothing
        Me.TextBox9.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox9.Location = CType(resources.GetObject("TextBox9.Location"), System.Drawing.PointF)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.OutputFormat = "  0"
        Me.TextBox9.Size = New System.Drawing.SizeF(2.3125!, 0.25!)
        Me.TextBox9.Text = Nothing
        Me.TextBox9.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox10
        '
        Me.TextBox10.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.TextBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickSolid
        Me.TextBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dash
        Me.TextBox10.DataField = "Sotien"
        Me.TextBox10.DistinctField = Nothing
        Me.TextBox10.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox10.Location = CType(resources.GetObject("TextBox10.Location"), System.Drawing.PointF)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.OutputFormat = Nothing
        Me.TextBox10.Size = New System.Drawing.SizeF(2.75!, 0.25!)
        Me.TextBox10.SummaryGroup = "GroupHeader1"
        Me.TextBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.TextBox10.Text = Nothing
        Me.TextBox10.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptDSBNNopDV
        '
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.2!
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.2!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PageSettings.PaperWidth = 8.267716!
        Me.PrintWidth = 7.302083!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtstt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTenPK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaythang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTongtien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBangchu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox10, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTenPK As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNgaythang As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtstt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox6 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtTongtien As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox7 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox8 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBangchu As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtTT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox9 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox10 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
End Class
