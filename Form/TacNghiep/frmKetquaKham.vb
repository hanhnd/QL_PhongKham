Imports VB6 = Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports C1.C1PrintDocument
'Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Reflection
'Imports System.Drawing.Drawing2D
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmKetquaKham
    Dim TenDVK As String = ""
    Dim TG_Denkham As DateTime
    Public Maphieukham As String = ""
    Private Sub frmKhambenh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New System.Globalization.CultureInfo("vi-VN", False)
        DocDM()
        FillData(maphieukham)
    End Sub
     
    Private Sub DocDM()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet

        'Lấy các danh mục cần thiết
        SQLStr = "Select MaDT, TenDT from DMDOITUONGBN where Nutla = 1"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter
        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet
        Adap1.Fill(DsDM, "DMDOITUONGBN")
        Cmd1.Dispose()

        SQLStr = "Select MaKhoa, TenKhoa from DMKhoaphong where is_Phongkham = 1 order by MaKhoa"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1.SelectCommand = Cmd1
        Adap1.Fill(DsDM, "DMPHONGKHAM")
        Cmd1.Dispose()

        SQLStr = "Select MaKhoa, TenKhoa from DMKhoaphong where is_KhoaDieutri = 1 order by MaKhoa"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1.SelectCommand = Cmd1
        Adap1.Fill(DsDM, "DMKHOADIEUTRI")
        Cmd1.Dispose()

        SQLStr = "Select * from DMNGHENGHIEP  order by TenNghenghiep"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1.SelectCommand = Cmd1
        Adap1.Fill(DsDM, "DMNGHENGHIEP")
        Cmd1.Dispose()

        SQLStr = "Select * from DMQUANHAM"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1.SelectCommand = Cmd1
        Adap1.Fill(DsDM, "DMQUANHAM")
        Cmd1.Dispose()

        ' Them vao combo
        cmbDoituong.ColumnWidth = 500
        cmbDoituong.DataSource = DsDM.Tables("DMDOITUONGBN")
        cmbDoituong.DisplayMember = "TenDT"
        cmbDoituong.ValueMember = "MaDT"
        cmbDoituong.Text = ""
        cmbDoituong.AutoDropDown = True

        cmbNghenghiep.DataSource = DsDM.Tables("DMNGHENGHIEP")
        cmbNghenghiep.DisplayMember = "TenNghenghiep"
        cmbNghenghiep.ValueMember = "MaNghenghiep"
        cmbNghenghiep.AutoDropDown = True

        cmbCapbac.DataSource = DsDM.Tables("DMQUANHAM")
        cmbCapbac.DisplayMember = "TenQH"
        cmbCapbac.ValueMember = "MaQH"
        cmbCapbac.AutoDropDown = True

        cmbKhoa_Nhapvien.DataSource = DsDM.Tables("DMKHOADIEUTRI")
        cmbKhoa_Nhapvien.DisplayMember = "TenKhoa"
        cmbKhoa_Nhapvien.ValueMember = "MaKhoa"
        cmbKhoa_Nhapvien.AutoDropDown = True

        cmbGioitinh.ClearItems()
        cmbGioitinh.AddItem("Nam")
        cmbGioitinh.AddItem("Nữ")

        cmbXutri.ClearItems()
        cmbXutri.AddItem("Chưa khám")
        cmbXutri.AddItem("Chờ kết luận")
        cmbXutri.AddItem("Kê đơn")
        cmbXutri.AddItem("Cho về")
        cmbXutri.AddItem("Chuyển phòng khám")
        cmbXutri.AddItem("Nhập viện")
        cmbXutri.AddItem("Chuyển viện")
        cmbXutri.AddItem("Hẹn thủ thuật")
        cmbXutri.AddItem("Bệnh nhân bỏ khám")
        cmbXutri.AddItem("Chuyển khám chuyên khoa")
        cmbXutri.AddItem("Tử vong")

        cmbKhoi_Capcuu.ClearItems()
        cmbKhoi_Capcuu.AddItem("Nội")
        cmbKhoi_Capcuu.AddItem("Ngoại")
        cmbKhoi_Capcuu.SelectedIndex = 0

        Adap1.Dispose()
        DsDM.Dispose()
        Adap1 = Nothing
        Cmd1 = Nothing
        DsDM = Nothing
    End Sub
    Private Sub SetEmpty()
        txtMabenhnhan.Text = ""
        txtTenbenhnhan.Text = ""
        txtMakhambenh.Text = ""
        txtMaphieukham.Text = ""
        txtTenbenhnhan.Text = ""
        lblSotheBHYT.Text = ""
    End Sub
    Public Sub FillData(ByVal maphieukham As String) 'ma = Mã phiếu khám
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try
            If Trim(maphieukham) = "" Then Exit Sub
            SetEmpty()
            SQL = "select  tblBenhnhan.Tenbenhnhan, tblBenhnhan.Namsinh,tblBenhnhan.Gioitinh, tblKhambenh.Diachi,   " _
            & " tblKhambenh.Doituong,(tblKhambenh.Doituongthe + '-' + tblKhambenh.SotheBHYT + '-' + tblKhambenh.NoidangkyKCBBD) " _
            & " as TheBHYT,  tblKhambenh.HantheBHYT_Tu,  tblKhambenh.HantheBHYT_Den, tblKhambenh.ChandoanNGT, tblKhambenh.Nghenghiep, tblKhambenh.Thoigiandangky, " _
            & " tblKhambenh.Capbac,tblKhambenh.Noicongtac, tblKhambenh.Lienhe, tblKhambenh_Chidinh.ThoigianCD, DMDICHVU.TenDichvu as TenDVK, " _
            & " tblKhambenh_KQDVKHAM.*  from tblKhambenh_KQDVKHAM  " _
            & " left outer join tblBenhnhan on tblKhambenh_KQDVKHAM.Mabenhnhan = tblBenhnhan.Mabenhnhan   " _
            & " left outer join tblKhambenh on tblKhambenh.Makhambenh = tblKhambenh_KQDVKHAM.Makhambenh   " _
            & " left outer join tblKhambenh_CHIDINH on tblKhambenh_CHIDINH.MaphieuCD = tblKhambenh_KQDVKHAM.MaphieuCD   " _
            & " inner join vDMDICHVU on tblKhambenh_KQDVKHAM.MaDichvu = DMDICHVU.MaDichvu   " _
            & " where tblKhambenh_KQDVKHAM.MaphieuCD = N'" & maphieukham & "' "
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                'Thong tin hanh chinh
                txtMabenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("MaBenhnhan")
                txtMakhambenh.Text = ds.Tables("Hoso").Rows(0).Item("MaKhambenh")
                txtMaphieukham.Text = ds.Tables("Hoso").Rows(0).Item("MaphieuCD")
                txtMaDV.Text = ds.Tables("Hoso").Rows(0).Item("MaDichvu")
                txtTenbenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("TenBenhnhan")
                txtTuoi.Value = ds.Tables("Hoso").Rows(0).Item("Namsinh")
                cmbGioitinh.SelectedIndex = IIf(ds.Tables("Hoso").Rows(0).Item("Gioitinh"), 0, 1)
                txtDiachi.Text = ds.Tables("Hoso").Rows(0).Item("Diachi")
                cmbDoituong.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Doituong")

                lblSotheBHYT.Text = ds.Tables("Hoso").Rows(0).Item("TheBHYT")
                txtHandungtheBHYT_Tu.Value = ds.Tables("Hoso").Rows(0).Item("HantheBHYT_Tu")
                txtHandungtheBHYT_Den.Value = ds.Tables("Hoso").Rows(0).Item("HantheBHYT_Den")
                txtChandoanNGT.Text = ds.Tables("Hoso").Rows(0).Item("ChandoanNGT")
                cmbCapbac.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Capbac")
                cmbNghenghiep.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Nghenghiep")
                TG_Denkham = ds.Tables("Hoso").Rows(0).Item("ThoigianCD")
                TenDVK = ds.Tables("Hoso").Rows(0).Item("TenDVK")
                txtNgaykham.Value = ds.Tables("Hoso").Rows(0).Item("Thoigiandangky")
                txtNoicongtac.Text = ds.Tables("Hoso").Rows(0).Item("Noicongtac")
                txtLienhe.Text = ds.Tables("Hoso").Rows(0).Item("Lienhe")

                'Thong tin kham và dieu tri
                txtMach.Text = ds.Tables("Hoso").Rows(0).Item("Mach")
                txtNhietdo.Text = ds.Tables("Hoso").Rows(0).Item("Nhietdo")
                txtHuyetap_T.Text = ds.Tables("Hoso").Rows(0).Item("HuyetapT")
                txtHuyetap_D.Text = ds.Tables("Hoso").Rows(0).Item("HuyetapD")
                txtNhiptho.Text = ds.Tables("Hoso").Rows(0).Item("Nhiptho")
                txtChieucao.Text = ds.Tables("Hoso").Rows(0).Item("Chieucao")
                txtCannang.Text = ds.Tables("Hoso").Rows(0).Item("Cannang")
                txtTrieuchung.Text = ds.Tables("Hoso").Rows(0).Item("Trieuchung")
                txtChandoanSB.Text = ds.Tables("Hoso").Rows(0).Item("ChandoanSB")
                txtChandoan.Text = ds.Tables("Hoso").Rows(0).Item("Chandoan")
                txtMaBC.Text = ds.Tables("Hoso").Rows(0).Item("BenhchinhICD")
                txtTenBC.Text = ds.Tables("Hoso").Rows(0).Item("Benhchinh_Ten")
                txtMaBP1.Text = ds.Tables("Hoso").Rows(0).Item("BenhphuICD1")
                txtTenBP1.Text = ds.Tables("Hoso").Rows(0).Item("Benhphu_Ten1")
                txtMaBP2.Text = ds.Tables("Hoso").Rows(0).Item("BenhphuICD2")
                txtTenBP2.Text = ds.Tables("Hoso").Rows(0).Item("Benhphu_Ten2")
                cmbXutri.SelectedIndex = ds.Tables("Hoso").Rows(0).Item("HuongGQ")
                txtLoidan_Phieukham.Text = ds.Tables("Hoso").Rows(0).Item("Loidan_Phieukham").ToString
                txtHenkhamlai.Text = ds.Tables("Hoso").Rows(0).Item("Henkhamlai")
                txtNgayhenkhamlai.Value = ds.Tables("Hoso").Rows(0).Item("Ngayhenkhamlai")
                If txtMaDV.Text = "A01109" Then ' Nếu là dịch vụ khám cấp cứu
                    lblKhoi_CC.Visible = True
                    cmbKhoi_Capcuu.Visible = True
                    lblGio_CC.Visible = True
                    txtGio_Capcuu.Visible = True
                Else
                    lblKhoi_CC.Visible = False
                    cmbKhoi_Capcuu.Visible = False
                    lblGio_CC.Visible = False
                    txtGio_Capcuu.Visible = False
                End If
                cmbKhoi_Capcuu.SelectedIndex = ds.Tables("Hoso").Rows(0).Item("Khoi_Capcuu")
                txtGio_Capcuu.Value = Val(ds.Tables("Hoso").Rows(0).Item("gio_Capcuu").ToString)
                'Thông tin chuyển phòng khám (nếu có)
                'Thông tin nhập viện (nếu có)
                cmbKhoa_Nhapvien.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Nhapvien_Khoa")
                'Thông tin chuyển viện (nếu có)
                'Fill DS Đơn thuốc
                Dim Madon As String = ""
                Fill_DS_Donthuoc(maphieukham, grdDSDonthuoc, Madon)
                If Madon <> "" Then Fill_Donthuoc(Madon, grdDonthuoc) 'Fill Đơn thuốc
            Else
                MsgBox("Bệnh nhân chưa có trong CSDL", MsgBoxStyle.Information, "Message !")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fill_Donthuoc(ByVal maphieuCD As String, ByVal grd As C1.Win.C1FlexGrid.C1FlexGrid) 'ma = Mã phiếu chi dinh
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            With grd
                If Trim(maphieuCD) = "" Then Exit Sub
                .Rows.Count = 1
                SQL = "Select tblKhambenh_Donthuoc.* from  tblKhambenh_Donthuoc " _
                 & " where tblKhambenh_Donthuoc.MaphieuCD = N'" & maphieuCD & "' order by STT " '& " left outer join DMTHUOC on tblKhambenh_Donthuoc.Mathuoc = DMTHUOC.ThuocID  " _
                Cmd = New SqlCommand(SQL, Cn)
                Adap = New SqlDataAdapter
                Adap.SelectCommand = Cmd
                ds = New DataSet
                Adap.Fill(ds, "Hoso")
                If ds.Tables("Hoso").Rows.Count > 0 Then
                    For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                        .AddItem(ds.Tables("Hoso").Rows(i).Item("STT") & vbTab & ds.Tables("Hoso").Rows(i).Item("MaThuoc") & vbTab & ds.Tables("Hoso").Rows(i).Item("Tenthuoc") & vbTab & ds.Tables("Hoso").Rows(i).Item("Tengoc") & vbTab & ds.Tables("Hoso").Rows(i).Item("Hamluong") & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong") & vbTab & ds.Tables("Hoso").Rows(i).Item("Cachdung") & vbTab & IIf(ds.Tables("Hoso").Rows(i).Item("ThuocMua") = 0, True, False))
                    Next
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fill_DS_Donthuoc(ByVal maphieukham As String, ByVal grd As C1.Win.C1FlexGrid.C1FlexGrid, ByRef MaphieuCD_gannhat As String) 'ma = Mã phiếu khám
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            With grd
                If Trim(maphieukham) = "" Then Exit Sub
                .Rows.Count = 1
                SQL = "select Q.MaphieuCD,tblKhambenh_Chidinh.ThoigianCD  from (SELECT DISTINCT MaphieuCD, Maphieukham" _
                & " FROM tblKHAMBENH_DONTHUOC where maphieukham = N'" & maphieukham & "') Q " _
                & " left outer join tblKhambenh_Chidinh on Q.MaphieuCD = tblKhambenh_Chidinh.MaphieuCD "
                Cmd = New SqlCommand(SQL, Cn)
                Adap = New SqlDataAdapter
                Adap.SelectCommand = Cmd
                ds = New DataSet
                Adap.Fill(ds, "Hoso")
                If ds.Tables("Hoso").Rows.Count > 0 Then
                    For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                        .AddItem(i + 1 & vbTab & ds.Tables("Hoso").Rows(i).Item("MaphieuCD") & vbTab & ds.Tables("Hoso").Rows(i).Item("ThoigianCD"))
                    Next
                    MaphieuCD_gannhat = .Item(.Rows.Count - 1, 1).ToString.Trim() ' tra lai ma phieu chi dinh thuoc gan nhat
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdThoat_Tab1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat_Tab1.Click
        Me.Hide()
    End Sub
    Private Sub Refresh_Grid(ByVal fg As C1.Win.C1FlexGrid.C1FlexGrid)
        fg.Subtotal(AggregateEnum.Clear, 0, 2, 0, "{0}")
        fg.Subtotal(AggregateEnum.Sum, 0, 2, fg.Cols("ThanhTien").Index, "{0}")
        fg.AutoSizeCols(0, fg.Cols.Count - 1, 1)
        Dim i As Integer, STT As Integer
        For i = 1 To fg.Rows.Count - 1
            If fg.Rows(i).IsNode Then
                STT = 0
                fg(i, "STT") = ""
            Else
                STT = STT + 1
                fg(i, "STT") = STT.ToString()
            End If
        Next
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub Load_PhieuChiDinh(ByVal grd As C1.Win.C1FlexGrid.C1FlexGrid)
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = String.Format("EXECUTE Spd_LoadPhieuChiDinh '{0}'", txtMakhambenh.Text.Trim())
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
        With grd
            .Tag = "0"
            .Rows.Count = 1
            Do While (dr.Read())
                .AddItem(String.Format("{0}|{1}|{2}|{3}|{4:dd/MM/yyyy HH:mm}|{5}|{6}|{7}|{8}", dr("MaPhieuCD"), dr("TenLoaiphieuCD"), dr("TenDu"), dr("NhanVienCD"), dr("ThoiGianCD"), dr("CapCuu"), dr("PhieuChiDinh_GhiChu"), dr("KieuReport"), dr("Tieude")))
            Loop
            dr.Close()
            .Row = -1
            .AutoSizeCols(0, .Cols.Count - 1, 1)
            .Tag = "1"
            SQLCmd.Dispose()
        End With
    End Sub
    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedIndex = 1 And txtMakhambenh.Text <> "" Then Load_PhieuChiDinh(grdDS_PhieuCD)
    End Sub
    Private Sub grdDS_PhieuCD_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDS_PhieuCD.DoubleClick
        If grdDS_PhieuCD.Row = 0 Then Exit Sub
        Select Case grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 1)
            Case "Phiếu GP bệnh"
                Fill_KQXN(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Huyết học"
                Fill_KQXN(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Miễn dịch"
                Fill_KQXN(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Sinh hóa"
                Fill_KQXN(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Nước tiểu-VS"
                Fill_KQXN(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Đông máu"
                Fill_KQXN(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))

            Case "Phiếu X quang thường"
                Fill_KQCDHA(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu X quang KT số"
                Fill_KQCDHA(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Citi"
                Fill_KQCDHA(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Siêu âm"
                Fill_KQCDHA(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Điện tim"
                Fill_KQCDHA(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Điện não"
                Fill_KQCDHA(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
            Case "Phiếu Nội soi"
                Fill_KQCDHA(grdDS_PhieuCD.Item(grdDS_PhieuCD.Row, 0))
        End Select
    End Sub
    Private Sub Fill_KQXN(ByVal Sophieu As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i, j
        Try
            If Trim(Sophieu) = "" Then Exit Sub
            grdKQ_XN.Redraw = False
            grdKQ_XN.Rows.Count = 1
            txtKetluan.Text = ""
            SQL = "select  a.Ketqua as KetquaXN,b.*,c.MaXN,c.TenXN,d.TenChiso, " _
            & " case when d.GTBT is Null then c.GTBT else d.GTBT end as GTBT," _
            & " case when d.DVT is null then c.DVT else d.DVT end as DVT_CHISO   from BV354_CLS.DBO.tblXN_KETQUA a    " _
            & " left outer join BV354_CLS.DBO.tblXN_KETQUA_CHISO b " _
            & " on a.MaphieuCD = b.MaphieuCD and a.MaCLS = b.MaCLS  " _
            & " inner join BV354_CLS.DBO.DMXETNGHIEM c on a.MaCLS = c.MaXN " _
            & " left join BV354_CLS.DBO.DMCHISO d on b.MaChiso = d.MaChiso " _
            & " where  a.MaphieuCD = N'" & Sophieu & "' order by c.thutu"
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    grdKQ_XN.AddItem(ds.Tables("Hoso").Rows(i).Item("MaXN") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenXN").ToString _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("MaChiso").ToString _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("TenChiso").ToString _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("KETQUA").ToString _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT_CHISO").ToString _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("GTBT").ToString _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("KETQUAXN").ToString)
                    '& IIf(IsDBNull(ds.Tables("Hoso").Rows(i).Item("Ketqua")), ds.Tables("Hoso").Rows(i).Item("KetquaXN").ToString, ds.Tables("Hoso").Rows(i).Item("Ketqua").ToString) 
                Next
            End If
            grdKQ_XN.Tree.Column = 3
            grdKQ_XN.Subtotal(AggregateEnum.Clear, 0, 1, 1, "{0}")
            grdKQ_XN.Subtotal(AggregateEnum.None, 0, 1, 1, "{0}")
            grdKQ_XN.Redraw = True
            Visible_Row()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fill_KQCDHA(ByVal Sophieu As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            If Trim(Sophieu) = "" Then Exit Sub
            grdKQ_XN.Rows.Count = 1
            txtKetluan.Text = ""
            'Kiểm tra xem trong bảng ket qua CDHA
            SQL = "select  Ketquachung from BV354_CLS.DBO.tblCDHA_PhieuCD a " _
            & " where  a.MaphieuCD = N'" & Sophieu & "' "
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then ' có rồi --> fill
                txtKetluan.Text = ds.Tables("Hoso").Rows(0).Item("Ketquachung").ToString
            End If
            Cmd.Dispose()
            Adap.Dispose()
            ds.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Visible_Row()
        Dim i
        grdKQ_XN.Redraw = False
        For i = 1 To grdKQ_XN.Rows.Count - 1
            If grdKQ_XN.Rows(i).IsNode Then
                grdKQ_XN.Item(i, 4) = grdKQ_XN.Item(i + 1, 7)

                Dim Socon = 1
                Do While grdKQ_XN.Rows(i + Socon).IsNode = False
                    Socon = Socon + 1
                    If i + Socon = grdKQ_XN.Rows.Count Then Exit Do
                Loop

                If Socon = 2 Then
                    grdKQ_XN.Rows(i + 1).Visible = False
                    grdKQ_XN.Item(i, 5) = grdKQ_XN.Item(i + 1, 5)
                    grdKQ_XN.Item(i, 6) = grdKQ_XN.Item(i + 1, 6)
                End If
            End If
        Next
        grdKQ_XN.Cols(3).Style.WordWrap = True
        grdKQ_XN.AutoSizeRows()
        grdKQ_XN.Redraw = True
    End Sub
End Class