Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptPhieuChiDinh 
    Public MaPhieuCD As String
    Public KhoaThucHien As String
    Public CapCuu As Byte
    Public TenBN As String
    Public Tuoi As Integer
    Public Gioi As String
    Public DiaChi As String
    Public LoCuonGiaySau As Boolean


    Private Sub rptPhieuChiDinh_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        'Me.PageSettings.Margins.Top = 0.7
        'Me.PageSettings.Margins.Left = 0.5
        'Me.PageSettings.Margins.Right = 0.4
        'Me.PageSettings.Margins.Bottom = 0.5
        Me.PageSettings.Margins.Top = 0.2 '0.7
        'Me.PageSettings.Margins.Left = 0.1
        'sửa lại để in theo khổ ngang A4
        Me.PageSettings.Margins.Left = 0 '0.1 + IIf(LoCuonGiaySau, 0, 5.85)
        Me.PageSettings.Margins.Right = 0
        Me.PageSettings.Margins.Bottom = 0.1 '0.5
        ''lblTenPK.Text = GetSetting("PHONGKHAM", "Thuoctinh", "TenPhongKham", "")
        'Barcode1.Text = MaPhieuCD
        If CapCuu = 1 Then
            chkCapCuu.Checked = True
        Else
            chkThuong.Checked = True
        End If
        'lblKhoa.Text = "KHOA: " & KhoaThucHien.ToUpper()
        lblTenBN.Text = TenBN
        lblTuoi.Text = "Tuổi: " & Tuoi.ToString()
        lblGioi.Text = "Giới: " & Gioi
        lblDiaChi.Text = DiaChi '"Địa chỉ: " & DiaChi
        If InStr(lblDoituong.Text, "Quân") > 0 Then
            picQuan.Visible = True
        Else
            picQuan.Visible = False
        End If
        lblTenPK.Text = TenPK.ToUpper
        Select Case Label8.Text.ToUpper
            Case "PHIẾU GP BỆNH"
                lblNoiThucHien.Text = "Nơi thực hiện: "
            Case "PHIẾU HUYẾT HỌC"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng Xét Nghiệm máu TẦNG 1."
            Case "PHIẾU MIỄN DỊCH"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng Xét Nghiệm máu TẦNG 1."
            Case "PHIẾU SINH HÓA"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng Xét Nghiệm máu TẦNG 1."
            Case "PHIẾU NƯỚC TIỂU - VS"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng Xét Nghiệm máu TẦNG 1."
            Case "PHIẾU ĐÔNG MÁU"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng Xét Nghiệm máu TẦNG 1."
            Case "PHIẾU CHỤP X QUANG"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng X-Quang TẦNG 1."
            Case "PHIẾU X-QUANG SỐ"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng X-Quang TẦNG 1."
            Case "PHIẾU CITI"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng X-Quang TẦNG 1."
            Case "PHIẾU SIÊU ÂM"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng Siêu Âm TẦNG 2."
            Case "PHIẾU ĐIỆN TIM"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng Khám TẦNG 1."
            Case "PHIẾU ĐIỆN NÃO"
                lblNoiThucHien.Text = "Nơi thực hiện: Phòng Điện Não TẦNG 3."
            Case "PHIẾU NỘI SOI"
                lblNoiThucHien.Text = "Nơi thực hiện: NS Dạ dày - Tá tràng TẦNG 2; NS Tai Mũi Họng Tầng 3."
        End Select
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        STT.Text = Val(STT.Text) + 1
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Dim h As Single = Detail1.Height
        STT.Height = h
        TextBox1.Height = h
        TextBox2.Height = h
        TextBox3.Height = h
        'TextBox4.Height = h
        'TextBox5.Height = h
        TextBox6.Height = h
        TextBox10.Height = h
        TextBox11.Height = h
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs)
        STT.Text = "0"
    End Sub

     
    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format

    End Sub
End Class
