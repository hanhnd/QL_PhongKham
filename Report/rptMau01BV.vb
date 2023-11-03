Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient

Public Class rptMau01BV
    Public MaKB As String
    Public NgayKham As Date
    Public LanThu As Int16
    Public Cmd As SqlCommand
    Public dr As SqlDataReader
    Public LoaiCPIndex As Int16
    Public intTongThanhTienQT, intTienCanTT, intTienBHXH As Decimal
    Dim Tongtien, Phantram
    Public Nguoithanhtoan As String
    Public Sub GetTTCaNhan()
        Cmd = New SqlCommand("", Cn)
        Cmd.CommandText = String.Format("SELECT DMNOIDKKCBBD_BHYT.Tennoicap, DMKHOAPHONG.Tenkhoa," _
        & " a.Makhambenh as Maso, a.Chandoan, a.BenhchinhICD,a.Tenbacsi_ca,b.*,c.*  FROM " & Tendatabase & ".DBO.tblKhamBenh_KQDVKHAM a " _
        & " INNER JOIN " & TenDatabase & ".DBO.tblKhambenh b ON a.Makhambenh = b.Makhambenh  " _
        & " INNER JOIN " & TenDatabase & ".DBO.tblBenhNhan c ON a.MaBenhNhan = c.MaBenhNhan  " _
        & " INNER JOIN DMNOIDKKCBBD_BHYT   ON b.NoidangkyKCBBD = DMNOIDKKCBBD_BHYT.Manoicap  " _
        & " INNER JOIN DMKHOAPHONG   ON a.Khoathuchien = DMKHOAPHONG.Makhoa  " _
        & " WHERE a.Makhambenh='{0}'", MaKB)
        dr = Cmd.ExecuteReader()
        While dr.Read()
            txtMaso.Text = dr("Maso")
            txtHoTen.Text = dr("TenBenhNhan")
            txtTenBN.Text = TenABC(dr("TenBenhNhan"))
            txtTenKT.Text = Nguoithanhtoan
            'TextBox13.Text = dr("Tenbacsi_ca").ToString
            'TextBox19.Text = dr("Tenbacsi_ca").ToString

            'TextBox13.Text = vbCrLf + vbCrLf + TextBox13.Text + dr("Tenbacsi_ca").ToString
            TextBox19.Text = String.Format("{0}{1}. ", TextBox19.Text, dr("Tenbacsi_ca"))

            'txtTenBS.Text = txtTenBS.Text + vbCrLf + LayTen(dr("Bacsi").ToString)
            txtTuoi.Text = Year(Now.Date()) - dr("NamSinh")
            txtGioiTinh.Text = IIf(dr("Gioitinh") = 1, "Nam", "Nữ")
            txtDiaChi.Text = dr("Diachi").ToString()
            txtNoiDKKCBBD.Text = dr("TenNoiCap").ToString()
            TextBox25.Text = dr("NoidangkyKCBBD").ToString()
            'txtKhoa.Text = txtKhoa.Text + dr("TenKhoa").ToString() + " /"
            txtVaoVien.Text = String.Format("7) Đến khám {0:HH} giờ {0:mm} ngày {0:dd / MM / yyyy}", dr("Thoigiandangky"))
            TextBox26.Text = String.Format("8) Kết thúc đợt điều trị ngoại trú {0:HH} giờ {0:mm} ngày {0:dd / MM / yyyy}", dr("Thoigiandangky"))
            txtChanDoan.Text = txtChanDoan.Text + dr("Chandoan").ToString() + ". "
            TextBox14.Text = dr("BenhchinhICD").ToString().ToUpper  'TextBox14.Text + dr("BenhchinhICD").ToString() + ". "
            txtGiaTriTu.Text = String.Format("{0:dd/MM/yyyy}", dr("HantheBHYT_Tu"))
            txtGiaTriDen.Text = String.Format("{0:dd/MM/yyyy}", dr("HantheBHYT_Den"))
            TextBox5.Text = dr("Doituongthe").ToString() + " - " + dr("SoTheBHYT").ToString() + " - " + dr("NoidangkyKCBBD").ToString()
            'If dr("SoTheBHYT").ToString().Length = 11 Then
            TextBox5.Text = dr("Doituongthe").ToString()

            TextBox30.Text = dr("SoTheBHYT").ToString().Substring(0, 1)
            TextBox35.Text = dr("SoTheBHYT").ToString().Substring(1, 2)
            TextBox32.Text = dr("SoTheBHYT").ToString().Substring(3, 2)
            TextBox40.Text = dr("SoTheBHYT").ToString().Substring(5, 3)
            TextBox39.Text = dr("SoTheBHYT").ToString().Substring(8, 5)

            TextBox29.Text = "Nơi chuyển đến: " + IIf(dr("Noigioithieu").ToString() = "", "Tự đến", dr("Noigioithieu").ToString())
            Select Case dr("Tuyen")
                Case 0
                    CheckBox4.Checked = True
                Case 1
                    CheckBox5.Checked = True
                Case 2
                    CheckBox3.Checked = True
            End Select

            'End If
            'txtBH6.Text = dr("Doituongthe").ToString()
            'If dr("NoidangkyKCBBD").ToString().Length = 5 Then
            '    txtBH7.Text = dr("NoidangkyKCBBD").ToString().Substring(0, 2)
            '    txtBH8.Text = dr("NoidangkyKCBBD").ToString().Substring(2, 3)
            'End If
            lblNgaythang.Text = "Ngày " + Format(dr("Thoigiandangky"), "dd") + " tháng " + Format(dr("Thoigiandangky"), "MM") + " năm " + Format(dr("Thoigiandangky"), "yyyy")
        End While
        'txtKhoa.Text = txtKhoa.Text + " Khoa Khám bệnh / BV 354"
        'txtTenBS.Text = txtTenBS.Text.Trim()
        'TextBox14.Text = TextBox14.Text.Trim.Substring(1, TextBox14.Text.Trim.Length - 1)
        'lblNgaythang.Text = "Ngày " + Format(Ngayhientai, "dd") + " tháng " + Format(Ngayhientai, "MM") + " năm " + Format(Ngayhientai, "yyyy")
        'MsgBox(dr("ThoigianDangky")) bộ, 1311070235
        'lblNgaythang.Text = "Ngày " + Format(dr("Thoigiandangky"), "dd") + " tháng " + Format(dr("Thoigiandangky"), "MM") + " năm " + Format(dr("Thoigiandangky"), "yyyy")
        dr.Close()
    End Sub
    Private Sub rptBHXHThanhToan_DataInitialize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.DataInitialize
        Cmd = New SqlCommand("", Cn)
        GetTTCaNhan()
        Dim _ds As DataDynamics.ActiveReports.DataSources.SqlDBDataSource
        _ds = New DataDynamics.ActiveReports.DataSources.SqlDBDataSource()
        _ds.ConnectionString = ConnectionStr 'HeThong.Cn.ConnectionString + "Password=vcntt2007"
        ' _ds.SQL = String.Format("select  DMNHOMDICHVU_BHYT.Manhom, isnull(DMNHOMDICHVU_BHYT.TenNhom,'') as TenLoai, " _
        ' & " DMDICHVU.Tendichvu as TenCP, tblThanhtoanBHYT_CT.DVT,tblThanhtoanBHYT_CT.Soluong,tblThanhtoanBHYT_CT.DongiaBHYT as Dongia," _
        ' & " tblThanhtoanBHYT_CT.Soluong * tblThanhtoanBHYT_CT.DongiaBHYT as ThanhtienQT,tblThanhtoanBHYT_CT.PhantramCCT  " _
        ' & " from tblThanhtoanBHYT_CT  " _
        ' & " left OUTER join DMDICHVU on tblThanhtoanBHYT_CT.Madichvu = DMDICHVU.MaDichvu" _
        ' & " left OUTER join DMNHOMDICHVU_BHYT on DMNHOMDICHVU_BHYT.MaNhom = DMDICHVU.NhomBHYT" _
        '& " where  MaKhambenh='{0}'  order by Manhom", MaKB)

        _ds.SQL = String.Format("select  DMNHOMDICHVU_BHYT.Manhom, isnull(DMNHOMDICHVU_BHYT.TenNhom,'') as TenLoai, " _
        & " case left(vDMDICHVU.Madichvu,1) when 'A' then N'Tiền khám ' else vDMDICHVU.Tendichvu end as TenCP, tblThanhtoanBHYT_CT.DVT,tblThanhtoanBHYT_CT.Soluong,tblThanhtoanBHYT_CT.DongiaBHYT as Dongia," _
        & " tblThanhtoanBHYT_CT.Soluong * tblThanhtoanBHYT_CT.DongiaBHYT as ThanhtienQT,tblThanhtoanBHYT_CT.PhantramCCT  " _
        & " from tblThanhtoanBHYT_CT  " _
        & " left OUTER join vDMDICHVU on tblThanhtoanBHYT_CT.Madichvu = vDMDICHVU.MaDichvu" _
        & " left OUTER join DMNHOMDICHVU_BHYT on DMNHOMDICHVU_BHYT.MaNhom = vDMDICHVU.NhomBHYT" _
        & " where  MaKhambenh='{0}'  order by Manhom", MaKB)


        Me.DataSource = _ds
        Fields.Add("TongSoLuong")
        Fields.Add("TongThanhTienQT")
    End Sub

    Private Sub rptBHXHThanhToan_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        'PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        'PageSettings.Orientation = PageOrientation.Portrait
        'PageSettings.Margins.Left = CType(0.4, Double)
        'PageSettings.Margins.Right = CType(0.2, Double)
        'PageSettings.Margins.Top = CType(0.5, Double)
        'PageSettings.Margins.Bottom = CType(0.5, Double)
        Tongtien = 0
        Phantram = 0
        lblMasoKCBBD.Text = TenPK.ToUpper
        ''lblTenPK.Text = "Mã CSKCB: " + MaDKKCBBD

    End Sub

    Private Sub groupLoaiCPHeader_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupLoaiCPHeader.Format
        LoaiCPIndex = LoaiCPIndex + 1
        txtSTTLoaiCP.Text = " " + LoaiCPIndex.ToString() + ". "
    End Sub

    Private Sub groupLoaiCPFooter_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupLoaiCPFooter.Format
        txtLoaiCPIndex.Text = String.Format("Cộng ({0})", LoaiCPIndex)
    End Sub

    Private Sub rptBHXHThanhToan_FetchData(ByVal sender As System.Object, ByVal eArgs As DataDynamics.ActiveReports.ActiveReport3.FetchEventArgs) Handles MyBase.FetchData
        Fields("TongSoLuong").Value = Fields("SoLuong").Value
        Fields("TongThanhTienQT").Value = 0
        If (Fields("ThanhTienQT").Value.GetType().Name <> "DBNull") Then
            intTongThanhTienQT = intTongThanhTienQT + CType(Fields("ThanhTienQT").Value, Decimal)
            Fields("TongThanhTienQT").Value = Fields("ThanhTienQT").Value
        End If
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Dim temp
        txtTongChiPhiSo.Text = mdlFunction.ReadMoney(Tongtien.ToString()) + " đồng." 'String.Format("{0:### ### ###} đ", Tongtien) 'String.Format("{0:### ### ###} đ", intTongThanhTienQT)
        'txtTongChiPhiChu.Text = mdlFunction.ReadMoney(Tongtien.ToString()) + " đồng."

        temp = 0
        'If (Tongtien < HanMuc) Then
        '    temp = 0
        'Else
        temp = Tongtien * Phantram / 100
        temp = Math.Round(temp, 0)
        'End If
        txtTienCanTT.Text = mdlFunction.ReadMoney((Val(Tongtien - temp)).ToString()) + " đồng." 'IIf(temp = 0, "0 đ", String.Format("{0:### ### ###} đ ", temp))
        txtTienBHXH.Text = mdlFunction.ReadMoney((temp).ToString()) + " đồng." 'String.Format("{0:### ### ###} đ", Tongtien - temp)
        'txtPhanTramCCT.Text = String.Format("{0:###} %", Phantram)
        'txtCanTTChu.Text = mdlFunction.ReadMoney(temp)
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Dim h = Detail1.Height
        textBox15.Height = h
        textBox16.Height = h
        textBox17.Height = h
        textBox18.Height = h
        TextBox41.Height = h
        TextBox44.Height = h
        TextBox45.Height = h
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Tongtien = Tongtien + Val(textBox18.Text)
        Phantram = Double.Parse(TextBox2.Text)
        TextBox41.Text = (Phantram * Val(textBox18.Text) / 100).ToString
        TextBox45.Text = (Val(textBox18.Text) - Val(TextBox41.Text)).ToString
    End Sub

    Private Sub rptPhieuTTRV_BHYT_PrintProgress(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PrintProgress
        DaInPhieuTTRVBHYT(MaKB)
    End Sub
End Class
