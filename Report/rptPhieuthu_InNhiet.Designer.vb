<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptPhieuthu_InNhiet
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
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPhieuthu_InNhiet))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtTenDichVu = New DataDynamics.ActiveReports.TextBox
        Me.txtThanhTien = New DataDynamics.ActiveReports.TextBox
        Me.Label24 = New DataDynamics.ActiveReports.Label
        Me.txtSTT = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.lblTenPK = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.txtTenbenhnhan = New DataDynamics.ActiveReports.TextBox
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.txtSotien_So = New DataDynamics.ActiveReports.TextBox
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.txtSotien_Chu = New DataDynamics.ActiveReports.TextBox
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.txtDiachi_rpt = New DataDynamics.ActiveReports.TextBox
        Me.Label18 = New DataDynamics.ActiveReports.Label
        Me.lblSobienlai = New DataDynamics.ActiveReports.Label
        Me.txtNgaythang = New DataDynamics.ActiveReports.Label
        Me.Label31 = New DataDynamics.ActiveReports.Label
        Me.lblTuoi = New DataDynamics.ActiveReports.Label
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.Label19 = New DataDynamics.ActiveReports.Label
        Me.Label22 = New DataDynamics.ActiveReports.Label
        Me.Label23 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.lblNguoithu = New DataDynamics.ActiveReports.Label
        Me.txtTongMiengiam = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.txtTienphaitra = New DataDynamics.ActiveReports.TextBox
        CType(Me.txtTenDichVu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtThanhTien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSTT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTenPK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTenbenhnhan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSotien_So, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSotien_Chu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiachi_rpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSobienlai, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNgaythang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTuoi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNguoithu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTongMiengiam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTienphaitra, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTenDichVu, Me.txtThanhTien, Me.Label24, Me.txtSTT, Me.TextBox1})
        Me.Detail1.Height = 0.1770833!
        Me.Detail1.Name = "Detail1"
        '
        'txtTenDichVu
        '
        Me.txtTenDichVu.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtTenDichVu.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTenDichVu.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTenDichVu.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTenDichVu.DataField = "Tendichvu"
        Me.txtTenDichVu.DistinctField = Nothing
        Me.txtTenDichVu.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenDichVu.Location = CType(resources.GetObject("txtTenDichVu.Location"), System.Drawing.PointF)
        Me.txtTenDichVu.Name = "txtTenDichVu"
        Me.txtTenDichVu.OutputFormat = Nothing
        Me.txtTenDichVu.Size = New System.Drawing.SizeF(1.875!, 0.1875!)
        Me.txtTenDichVu.Text = "Trigricerit"
        Me.txtTenDichVu.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtThanhTien
        '
        Me.txtThanhTien.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.txtThanhTien.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtThanhTien.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtThanhTien.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtThanhTien.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtThanhTien.DataField = "Thanhtien"
        Me.txtThanhTien.DistinctField = Nothing
        Me.txtThanhTien.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThanhTien.Location = CType(resources.GetObject("txtThanhTien.Location"), System.Drawing.PointF)
        Me.txtThanhTien.Name = "txtThanhTien"
        Me.txtThanhTien.OutputFormat = "### ### ###"
        Me.txtThanhTien.Size = New System.Drawing.SizeF(0.5625!, 0.1875!)
        Me.txtThanhTien.Text = "2 180 000"
        Me.txtThanhTien.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label24
        '
        Me.Label24.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.HyperLink = ""
        Me.Label24.Location = CType(resources.GetObject("Label24.Location"), System.Drawing.PointF)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.SizeF(1.5!, 0.25!)
        Me.Label24.Text = ""
        Me.Label24.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtSTT
        '
        Me.txtSTT.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.txtSTT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtSTT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtSTT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtSTT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSTT.DistinctField = Nothing
        Me.txtSTT.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSTT.Location = CType(resources.GetObject("txtSTT.Location"), System.Drawing.PointF)
        Me.txtSTT.Name = "txtSTT"
        Me.txtSTT.OutputFormat = Nothing
        Me.txtSTT.Size = New System.Drawing.SizeF(0.25!, 0.1875!)
        Me.txtSTT.Text = "1"
        Me.txtSTT.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox1
        '
        Me.TextBox1.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.DataField = "Miengiam"
        Me.TextBox1.DistinctField = Nothing
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = CType(resources.GetObject("TextBox1.Location"), System.Drawing.PointF)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = "### ### ###"
        Me.TextBox1.Size = New System.Drawing.SizeF(0.5625!, 0.1875!)
        Me.TextBox1.Text = "2 180 000"
        Me.TextBox1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        Me.TextBox1.Visible = False
        '
        'lblTenPK
        '
        Me.lblTenPK.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.lblTenPK.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTenPK.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTenPK.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTenPK.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTenPK.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTenPK.HyperLink = Nothing
        Me.lblTenPK.Location = CType(resources.GetObject("lblTenPK.Location"), System.Drawing.PointF)
        Me.lblTenPK.Name = "lblTenPK"
        Me.lblTenPK.Size = New System.Drawing.SizeF(1.0625!, 0.3125!)
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
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.HyperLink = Nothing
        Me.Label8.Location = CType(resources.GetObject("Label8.Location"), System.Drawing.PointF)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.SizeF(1.625!, 0.25!)
        Me.Label8.Text = "PHIẾU THU"
        Me.Label8.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label1
        '
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.HyperLink = Nothing
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.PointF)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.SizeF(0.3125!, 0.25!)
        Me.Label1.Text = "BN:"
        Me.Label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtTenbenhnhan
        '
        Me.txtTenbenhnhan.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTenbenhnhan.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTenbenhnhan.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTenbenhnhan.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTenbenhnhan.DataField = "Tenbenhnhan"
        Me.txtTenbenhnhan.DistinctField = Nothing
        Me.txtTenbenhnhan.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenbenhnhan.Location = CType(resources.GetObject("txtTenbenhnhan.Location"), System.Drawing.PointF)
        Me.txtTenbenhnhan.Name = "txtTenbenhnhan"
        Me.txtTenbenhnhan.OutputFormat = Nothing
        Me.txtTenbenhnhan.Size = New System.Drawing.SizeF(2.375!, 0.25!)
        Me.txtTenbenhnhan.Text = Nothing
        Me.txtTenbenhnhan.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label6
        '
        Me.Label6.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.HyperLink = Nothing
        Me.Label6.Location = CType(resources.GetObject("Label6.Location"), System.Drawing.PointF)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.SizeF(2.125!, 0.1875!)
        Me.Label6.Text = "        Tổng cộng:"
        Me.Label6.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtSotien_So
        '
        Me.txtSotien_So.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.txtSotien_So.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtSotien_So.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtSotien_So.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtSotien_So.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSotien_So.DataField = "Thanhtien"
        Me.txtSotien_So.DistinctField = Nothing
        Me.txtSotien_So.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSotien_So.Location = CType(resources.GetObject("txtSotien_So.Location"), System.Drawing.PointF)
        Me.txtSotien_So.Name = "txtSotien_So"
        Me.txtSotien_So.OutputFormat = "### ### ###"
        Me.txtSotien_So.Size = New System.Drawing.SizeF(0.5625!, 0.1875!)
        Me.txtSotien_So.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtSotien_So.Text = Nothing
        '
        'Label7
        '
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.HyperLink = Nothing
        Me.Label7.Location = CType(resources.GetObject("Label7.Location"), System.Drawing.PointF)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.SizeF(0.5625!, 0.1875!)
        Me.Label7.Text = "Bằng chữ:"
        Me.Label7.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtSotien_Chu
        '
        Me.txtSotien_Chu.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSotien_Chu.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSotien_Chu.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSotien_Chu.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSotien_Chu.DistinctField = Nothing
        Me.txtSotien_Chu.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSotien_Chu.Location = CType(resources.GetObject("txtSotien_Chu.Location"), System.Drawing.PointF)
        Me.txtSotien_Chu.Name = "txtSotien_Chu"
        Me.txtSotien_Chu.OutputFormat = Nothing
        Me.txtSotien_Chu.Size = New System.Drawing.SizeF(2.125!, 0.1875!)
        Me.txtSotien_Chu.Text = Nothing
        Me.txtSotien_Chu.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label12
        '
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.HyperLink = Nothing
        Me.Label12.Location = CType(resources.GetObject("Label12.Location"), System.Drawing.PointF)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.SizeF(0.3125!, 0.1875!)
        Me.Label12.Text = "ĐC:"
        Me.Label12.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtDiachi_rpt
        '
        Me.txtDiachi_rpt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDiachi_rpt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDiachi_rpt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDiachi_rpt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDiachi_rpt.DataField = "Diachi"
        Me.txtDiachi_rpt.DistinctField = Nothing
        Me.txtDiachi_rpt.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiachi_rpt.Location = CType(resources.GetObject("txtDiachi_rpt.Location"), System.Drawing.PointF)
        Me.txtDiachi_rpt.Name = "txtDiachi_rpt"
        Me.txtDiachi_rpt.OutputFormat = Nothing
        Me.txtDiachi_rpt.Size = New System.Drawing.SizeF(2.375!, 0.1875!)
        Me.txtDiachi_rpt.Text = Nothing
        Me.txtDiachi_rpt.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label18
        '
        Me.Label18.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.HyperLink = Nothing
        Me.Label18.Location = CType(resources.GetObject("Label18.Location"), System.Drawing.PointF)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.SizeF(1.4375!, 0.1875!)
        Me.Label18.Text = "Người thu tiền"
        '
        'lblSobienlai
        '
        Me.lblSobienlai.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.lblSobienlai.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSobienlai.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSobienlai.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSobienlai.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSobienlai.DataField = "Sobienlai"
        Me.lblSobienlai.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSobienlai.HyperLink = Nothing
        Me.lblSobienlai.Location = CType(resources.GetObject("lblSobienlai.Location"), System.Drawing.PointF)
        Me.lblSobienlai.Name = "lblSobienlai"
        Me.lblSobienlai.Size = New System.Drawing.SizeF(1.625!, 0.25!)
        Me.lblSobienlai.Text = "Số:............................"
        Me.lblSobienlai.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtNgaythang
        '
        Me.txtNgaythang.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.txtNgaythang.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNgaythang.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgaythang.HyperLink = Nothing
        Me.txtNgaythang.Location = CType(resources.GetObject("txtNgaythang.Location"), System.Drawing.PointF)
        Me.txtNgaythang.Name = "txtNgaythang"
        Me.txtNgaythang.Size = New System.Drawing.SizeF(1.5!, 0.1875!)
        Me.txtNgaythang.Text = "Ngày 20 tháng 03 năm 2010"
        Me.txtNgaythang.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label31
        '
        Me.Label31.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.HyperLink = Nothing
        Me.Label31.Location = CType(resources.GetObject("Label31.Location"), System.Drawing.PointF)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.SizeF(1.4375!, 0.1875!)
        Me.Label31.Text = "(Ký, ghi rõ họ tên)"
        '
        'lblTuoi
        '
        Me.lblTuoi.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.lblTuoi.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTuoi.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTuoi.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTuoi.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTuoi.DataField = "Namsinh"
        Me.lblTuoi.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTuoi.HyperLink = ""
        Me.lblTuoi.Location = CType(resources.GetObject("lblTuoi.Location"), System.Drawing.PointF)
        Me.lblTuoi.Name = "lblTuoi"
        Me.lblTuoi.Size = New System.Drawing.SizeF(0.5625!, 0.25!)
        Me.lblTuoi.Text = ""
        Me.lblTuoi.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTenPK, Me.Label8, Me.Label1, Me.txtTenbenhnhan, Me.Label12, Me.txtDiachi_rpt, Me.lblSobienlai, Me.lblTuoi, Me.Label19, Me.Label22, Me.Label23, Me.Line1})
        Me.ReportHeader1.Height = 1.1875!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'Label19
        '
        Me.Label19.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.HyperLink = ""
        Me.Label19.Location = CType(resources.GetObject("Label19.Location"), System.Drawing.PointF)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.SizeF(0.25!, 0.1875!)
        Me.Label19.Text = "TT"
        Me.Label19.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label22
        '
        Me.Label22.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.HyperLink = ""
        Me.Label22.Location = CType(resources.GetObject("Label22.Location"), System.Drawing.PointF)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.SizeF(1.875!, 0.1875!)
        Me.Label22.Text = "Nội dung thu"
        Me.Label22.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label23
        '
        Me.Label23.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.HyperLink = ""
        Me.Label23.Location = CType(resources.GetObject("Label23.Location"), System.Drawing.PointF)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.SizeF(0.5625!, 0.1875!)
        Me.Label23.Text = "Số tiền"
        Me.Label23.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Line1
        '
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.LineStyle = DataDynamics.ActiveReports.LineStyle.Dash
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0.375!
        Me.Line1.X2 = 0.875!
        Me.Line1.Y1 = 0.3125!
        Me.Line1.Y2 = 0.3125!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtSotien_So, Me.txtSotien_Chu, Me.Label7, Me.txtNgaythang, Me.Label18, Me.Label31, Me.Label6, Me.lblNguoithu, Me.txtTongMiengiam, Me.Label2, Me.Label3, Me.txtTienphaitra})
        Me.ReportFooter1.Height = 2.104167!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'lblNguoithu
        '
        Me.lblNguoithu.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.lblNguoithu.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNguoithu.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNguoithu.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNguoithu.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNguoithu.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNguoithu.HyperLink = Nothing
        Me.lblNguoithu.Location = CType(resources.GetObject("lblNguoithu.Location"), System.Drawing.PointF)
        Me.lblNguoithu.Name = "lblNguoithu"
        Me.lblNguoithu.Size = New System.Drawing.SizeF(1.4375!, 0.1875!)
        Me.lblNguoithu.Text = ".............................."
        '
        'txtTongMiengiam
        '
        Me.txtTongMiengiam.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.txtTongMiengiam.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtTongMiengiam.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtTongMiengiam.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtTongMiengiam.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTongMiengiam.DataField = "Miengiam"
        Me.txtTongMiengiam.DistinctField = Nothing
        Me.txtTongMiengiam.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTongMiengiam.Location = CType(resources.GetObject("txtTongMiengiam.Location"), System.Drawing.PointF)
        Me.txtTongMiengiam.Name = "txtTongMiengiam"
        Me.txtTongMiengiam.OutputFormat = "### ### ###"
        Me.txtTongMiengiam.Size = New System.Drawing.SizeF(0.5625!, 0.1875!)
        Me.txtTongMiengiam.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTongMiengiam.Text = Nothing
        '
        'Label2
        '
        Me.Label2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.HyperLink = Nothing
        Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.PointF)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.SizeF(2.125!, 0.1875!)
        Me.Label2.Text = "        Giảm trừ:"
        Me.Label2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label3
        '
        Me.Label3.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.HyperLink = Nothing
        Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.PointF)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.SizeF(2.125!, 0.1875!)
        Me.Label3.Text = "        Số tiền phải trả:"
        Me.Label3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtTienphaitra
        '
        Me.txtTienphaitra.Alignment = DataDynamics.ActiveReports.TextAlignment.Right
        Me.txtTienphaitra.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtTienphaitra.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtTienphaitra.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Dot
        Me.txtTienphaitra.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTienphaitra.DistinctField = Nothing
        Me.txtTienphaitra.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTienphaitra.Location = CType(resources.GetObject("txtTienphaitra.Location"), System.Drawing.PointF)
        Me.txtTienphaitra.Name = "txtTienphaitra"
        Me.txtTienphaitra.OutputFormat = "### ### ###"
        Me.txtTienphaitra.Size = New System.Drawing.SizeF(0.5625!, 0.1875!)
        Me.txtTienphaitra.Text = Nothing
        '
        'rptPhieuthu_InNhiet
        '
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Bottom = 0.1!
        Me.PageSettings.Margins.Left = 0.6!
        Me.PageSettings.Margins.Right = 0.1!
        Me.PageSettings.Margins.Top = 0.5!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait
        Me.PageSettings.PaperHeight = 11.69291!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.PageSettings.PaperWidth = 8.267716!
        Me.PrintWidth = 2.823!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.ReportFooter1)
        CType(Me.txtTenDichVu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtThanhTien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSTT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTenPK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTenbenhnhan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSotien_So, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSotien_Chu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiachi_rpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSobienlai, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNgaythang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTuoi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNguoithu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTongMiengiam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTienphaitra, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents lblTenPK As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTenbenhnhan As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTenDichVu As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSotien_So As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSotien_Chu As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDiachi_rpt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label18 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblSobienlai As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNgaythang As DataDynamics.ActiveReports.Label
    Friend WithEvents Label31 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtThanhTien As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label24 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTuoi As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label19 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label22 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label23 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSTT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblNguoithu As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTongMiengiam As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTienphaitra As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
End Class
