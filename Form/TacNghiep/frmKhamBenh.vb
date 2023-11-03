Imports System.Data
Imports System.Data.SqlClient
Imports VB6 = Microsoft.VisualBasic
'Imports Excel.XlSaveAsAccessMode
Imports System.IO
Imports System.Drawing.Drawing2D
Imports C1.Win.C1FlexGrid
Imports C1.C1PrintDocument
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Reflection
Imports System.Xml
Public Class frmKhamBenh
    Dim MaPPDT_goi As String
    Dim KhamLS As String
    Dim IStartedXL As Boolean
    Dim TenDVK As String = ""
    Dim TG_Denkham As DateTime  ' = Thời gian chỉ định phiếu khám
    Dim GoiICD As String
    Dim booThemdon, booSuadon As Boolean ' Đánh dấu tình trạng thêm, sửa đơn
    Dim Madonthuoc_Sua As String
    Dim MaPhieuCD As String
    Dim tienDV As Integer = 0
    Dim tienThuoc As Integer = 0
    Dim tongTien As Integer = 0
    Dim collection_SoDT As New AutoCompleteStringCollection()

    Private Sub frmPhongkham_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                panICD.Visible = False
            Case Keys.F3
                'cmdInPhieu_Click(Nothing, Nothing)
            Case Keys.F4
                cmdLuu_XemDonthuoc_Click(Nothing, Nothing)
        End Select
        If e.KeyCode = Keys.Escape Then

        End If
    End Sub ' Mã đơn thuóc cần sửa thông tin

    Private Sub frmKhambenh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New System.Globalization.CultureInfo("vi-VN", False)
        SetEmpty()
        'Moi load form thi moi control deu bi lam mo ko su dung duoc
        'grBenhnhan.Enabled = False
        TabControl2.Enabled = False
        DocDM()
        SetVal_Start()
        SetPos_Start()
        cmdDanhsachBN.Enabled = True
        cmdKedon.Enabled = True
        btnThemLanKham.Enabled = False
        btnLuuBenhNhan.Enabled = False
        btnSuaThongTin.Enabled = False
        btnInPhieuThuoc.Enabled = False
        btnHuyThaoTac.Enabled = False
        SoDienThoai()
        txtLienHe.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtLienHe.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtLienHe.MaskBox.AutoCompleteCustomSource = collection_SoDT
        EnableControls(False)
        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_Grid(Me, grv_DichVu, Lang)
        mdlFunction.Set_Text_Grid(Me, grv_DonThuoc, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdTiensuKB, Lang)
        slu_SoDienThoai.Focus()
    End Sub
    Private Sub EnableControls(ByVal islock As Boolean)
        txtTenbenhnhan.Enabled = islock
        txtTuoi.Enabled = islock
        txtDiachi.Enabled = islock
        txtNgaykham.Enabled = islock
        cmbGioitinh.Enabled = islock
        TabControl2.Enabled = islock
        slu_SoDienThoai.Visible = Not islock
        txtLienHe.Visible = islock
    End Sub
    Private Sub SoDienThoai()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet
        SQLStr = "select SoDienThoai,TenBenhnhan from tblBenhNhan WHERE isnull(SoDienThoai,'') <> ''  order by SoDienThoai"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter
        Adap1.SelectCommand = Cmd1
        Dim dtb As New DataTable()
        Adap1.Fill(dtb)
        slu_SoDienThoai.Properties.DataSource = dtb
        For i As Integer = 0 To dtb.Rows.Count - 1
            collection_SoDT.Add(dtb.Rows(i)("SoDienThoai").ToString())
        Next
    End Sub
    Private Sub SetVal_Start()
        txtCV_Thoigian.Value = GetSrvDate()
    End Sub
    Private Sub SetPos_Start()
        Dim i
    End Sub
    Private Sub DocDM()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet

        'Lấy các danh mục cần thiết
        'So tay don thuoc
        DM_SoTayDonThuoc()
        'So tay chi dinh
        DM_SoTayDichVu()


        cmbGioitinh.ClearItems()
        If Lang = "vi" Then
            cmbGioitinh.AddItem("Nam")
            cmbGioitinh.AddItem("Nữ")
        ElseIf Lang = "en" Then
            cmbGioitinh.AddItem("Male")
            cmbGioitinh.AddItem("Female")
        ElseIf Lang = "my" Then
            cmbGioitinh.AddItem("အထီး")
            cmbGioitinh.AddItem("အပျို")
        End If




        'Gan du lieu len grid chi dinh dich vu
        Dim dtb_DV As DataTable = New DataTable()
        dtb_DV.Columns.Add("STT")
        dtb_DV.Columns.Add("MaDichVu")
        dtb_DV.Columns.Add("DVT")
        dtb_DV.Columns.Add("DonGia")
        dtb_DV.Columns.Add("SoLuong")
        dtb_DV.Columns.Add("ThanhTien")
        GridControl1.DataSource = dtb_DV

        'Danh muc dich vu len gridlookupedit - danh muc dich vu
        SQLStr = "SELECT MaDichVu,TenDichVu,DVT,Dongia As DonGia FROM DMDichVu Where KhongSuDung = 0"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter

        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet()
        Adap1.Fill(DsDM, "DMDichVu")
        Gle_DichVu.DataSource = DsDM.Tables(0)
        Cmd1.Dispose()
        Adap1.Dispose()
        DsDM.Dispose()

        'Gan du lieu len grid chi dinh dich vu
        Dim dtb_DMThuoc As DataTable = New DataTable()

        dtb_DMThuoc.Columns.Add("STT")
        dtb_DMThuoc.Columns.Add("ThuocID")
        dtb_DMThuoc.Columns.Add("DVT")
        dtb_DMThuoc.Columns.Add("DonGia")
        dtb_DMThuoc.Columns.Add("SoLuong")
        dtb_DMThuoc.Columns.Add("ThanhTien")
        dtb_DMThuoc.Columns.Add("CachDung")
        GridControl2.DataSource = dtb_DMThuoc

        'Danh muc dich vu len gridlookupedit - danh muc thuoc
        SQLStr = "SELECT ThuocID,TenThuoc,DonViTinh as DVT,DonGia FROM DMThuoc"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter

        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet()
        Adap1.Fill(DsDM, "DMThuoc")
        gle_DMThuoc.DataSource = DsDM.Tables(0)
        Cmd1.Dispose()
        Adap1.Dispose()
        DsDM.Dispose()

        'Danh muc Bac sy len gridlookupedit - danh muc thuoc
        'SQLStr = "SELECT Manhanvien,Tennhanvien FROM DMNhanVien"
        'Cmd1 = New SqlCommand(SQLStr, Cn)
        'Adap1 = New SqlDataAdapter
        'Adap1.SelectCommand = Cmd1
        'DsDM = New DataSet()
        'Adap1.Fill(DsDM, "DMNhanVien")
        'cmbDM_BacSy.DataSource = DsDM.Tables("DMNhanVien")
        'cmbDM_BacSy.DisplayMember = "Tennhanvien"
        'cmbDM_BacSy.ValueMember = "Manhanvien"
        'cmbDM_BacSy.Text = ""
        'cmbDM_BacSy.AutoDropDown = True
        'Cmd1.Dispose()
        'Adap1.Dispose()
        'DsDM.Dispose()

        Adap1 = Nothing
        Cmd1 = Nothing
        DsDM = Nothing
    End Sub
    Private Sub DM_SoTayDonThuoc()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet

        'Lấy các danh mục cần thiết
        'So tay don thuoc
        SQLStr = "select ID_Sotaydonthuoc, Matbenh from tblSotayDonthuoc where Bacsi = '" & TenDangNhap & "' order by Matbenh"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter

        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet()
        Adap1.Fill(DsDM, "SotayDonthuoc")
        Cmd1.Dispose()

        cmbMatbenh.DataSource = DsDM.Tables("SotayDonthuoc")
        cmbMatbenh.DisplayMember = "Matbenh"
        cmbMatbenh.ValueMember = "ID_Sotaydonthuoc"
        cmbMatbenh.Text = ""
        cmbMatbenh.AutoDropDown = True

        Adap1.Dispose()
        DsDM.Dispose()

        Adap1 = Nothing
        Cmd1 = Nothing
        DsDM = Nothing
    End Sub
    Private Sub DM_SoTayDichVu()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet

        'Lấy các danh mục cần thiết
        'So tay chi dinh
        SQLStr = "select ID_SoCD, Mota from tblSOTAYCHIDINH where Uname = '" & TenDangNhap & "' order by Mota"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter

        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet()
        Adap1.Fill(DsDM, "SoTayChiDinh")
        Cmd1.Dispose()

        cmbSoTayChiDinh.DataSource = DsDM.Tables("SoTayChiDinh")
        cmbSoTayChiDinh.DisplayMember = "Mota"
        cmbSoTayChiDinh.ValueMember = "ID_SoCD"
        cmbSoTayChiDinh.Text = ""
        cmbSoTayChiDinh.AutoDropDown = True


        cmbGioitinh.ClearItems()
        If Lang = "vi" Then
            cmbGioitinh.AddItem("Nam")
            cmbGioitinh.AddItem("Nữ")
        ElseIf Lang = "en" Then
            cmbGioitinh.AddItem("Male")
            cmbGioitinh.AddItem("Female")
        ElseIf Lang = "my" Then
            cmbGioitinh.AddItem("အထီး")
            cmbGioitinh.AddItem("အပျို")
        End If

        Adap1.Dispose()
        DsDM.Dispose()
        Adap1 = Nothing
        Cmd1 = Nothing
        DsDM = Nothing
    End Sub
    Private Sub SetEmpty()
        'Cac control textbox = ""
        txtMabenhnhan.Text = ""
        txtTenbenhnhan.Text = ""
        txtMakhambenh.Text = ""
        txtTrieuchung.Text = ""
        txtChandoanSB.Text = ""
        txtDiachi.Text = ""
        txtLienhe.Text = ""
        txtLoidan.Text = ""
        lblChitiet_Donthuoc.Tag = ""

        txtNgaykham.Value = DBNull.Value
        txtTuoi.Value = DBNull.Value
        cmbGioitinh.Text = ""
        lblTienCLS.Text = "0"
        lblTienThuoc.Text = "0"
        lblTongCP.Text = "0"

        For i = grv_DonThuoc.RowCount - 1 To 0 Step -1
            grv_DonThuoc.DeleteRow(i)
        Next
        For i = grv_DichVu.RowCount - 1 To 0 Step -1
            grv_DichVu.DeleteRow(i)
        Next
    End Sub
    'HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH

    '&&&&&&&&&&&& Nhóm code Fill data trong CSDL ra form &&&&&&&&&&&&
    Public Sub FillData(ByVal maKhamBenh As String) 'ma = Mã kham benh - theo lan kham cua benh nhan
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try
            If Trim(maKhamBenh) = "" Then Exit Sub
            SetEmpty()
            SQL = "select tblBenhnhan.Mabenhnhan,tblKhambenh.MaKhamBenh, tblBenhnhan.Tenbenhnhan, tblBenhnhan.Namsinh,tblBenhnhan.Gioitinh, tblKhambenh.Diachi,   " _
            & " isnull(tblKhambenh.TrieuChung,'') TrieuChung, isnull(tblKhambenh.ChanDoan,'') Chandoan, tblKhambenh.Thoigiandangky,Bacsi,DatCoc,TaiKham, " _
            & " tblBenhnhan.SoDienThoai Lienhe " _
            & " from tblKhambenh inner join tblBenhnhan on tblKhambenh.Mabenhnhan = tblBenhnhan.Mabenhnhan  "
            SQL += " where tblKhambenh.Makhambenh = N'" & maKhamBenh & "' "


            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                'Thong tin hanh chinh
                txtMabenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("MaBenhnhan")
                txtMakhambenh.Text = ds.Tables("Hoso").Rows(0).Item("MaKhambenh")

                txtTenbenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("TenBenhnhan")
                txtTuoi.Value = ds.Tables("Hoso").Rows(0).Item("Namsinh")
                cmbGioitinh.SelectedIndex = IIf(ds.Tables("Hoso").Rows(0).Item("Gioitinh"), 0, 1)
                txtDiachi.Text = ds.Tables("Hoso").Rows(0).Item("Diachi")
                txtLienhe.Text = ds.Tables("Hoso").Rows(0).Item("Lienhe")
                'Thong tin kham và dieu tri
                txtTrieuchung.Text = ds.Tables("Hoso").Rows(0).Item("Trieuchung")
                txtChandoanSB.Text = ds.Tables("Hoso").Rows(0).Item("Chandoan")
                txtNgaykham.Value = ds.Tables("Hoso").Rows(0).Item("Thoigiandangky")
                'cmbDM_BacSy.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Bacsi").ToString().Trim()
                'nmDatCoc.Value = Decimal.Parse(ds.Tables("Hoso").Rows(0).Item("DatCoc").ToString())
                If ds.Tables("Hoso").Rows(0).Item("TaiKham").ToString() <> "" Then
                    dtTaiKham.Value = Convert.ToDateTime(ds.Tables("Hoso").Rows(0).Item("TaiKham").ToString())
                End If

                'Fill DS Đơn thuốc
                Dim Madon As String = ""
                Fill_Donthuoc(maKhamBenh) 'Fill Đơn thuốc
                Fill_DichVu(maKhamBenh) 'Fill Đơn thuốc
                'Fill các danh sach lich su kham benh
                Fill_DSKhamtruoc(txtMabenhnhan.Text)
                'Tinh tong chi phi
                TinhTongChiPhi()
            Else
                MsgBox("The patient is not yet in the Database", MsgBoxStyle.Information, "Messages !")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FillData_ByPhone(ByVal SoDienThoai As String) 'ma = Mã kham benh - theo lan kham cua benh nhan
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try
            If Trim(SoDienThoai) = "" Then Exit Sub
            SetEmpty()
            SQL = " select Top 1 tblBenhnhan.Mabenhnhan,tblKhambenh.MaKhamBenh, tblBenhnhan.Tenbenhnhan, tblBenhnhan.Namsinh,tblBenhnhan.Gioitinh, tblKhambenh.Diachi,   " _
            & " isnull(tblKhambenh.TrieuChung,'') TrieuChung, isnull(tblKhambenh.ChanDoan,'') Chandoan, tblKhambenh.Thoigiandangky,Bacsi,DatCoc,TaiKham, " _
            & " tblBenhnhan.SoDienThoai Lienhe " _
            & " from tblKhambenh inner join tblBenhnhan on tblKhambenh.Mabenhnhan = tblBenhnhan.Mabenhnhan  "
            SQL += " where tblBenhNhan.SoDienThoai = N'" & SoDienThoai & "' ORDER BY tblKhamBenh.Thoigiandangky DESC "


            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                'Thong tin hanh chinh
                txtMabenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("MaBenhnhan")
                txtMakhambenh.Text = ds.Tables("Hoso").Rows(0).Item("MaKhambenh")

                txtTenbenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("TenBenhnhan")
                txtTuoi.Value = ds.Tables("Hoso").Rows(0).Item("Namsinh")
                cmbGioitinh.SelectedIndex = IIf(ds.Tables("Hoso").Rows(0).Item("Gioitinh"), 0, 1)
                txtDiachi.Text = ds.Tables("Hoso").Rows(0).Item("Diachi")
                txtLienHe.Text = ds.Tables("Hoso").Rows(0).Item("Lienhe")
                'Thong tin kham và dieu tri
                txtTrieuchung.Text = ds.Tables("Hoso").Rows(0).Item("Trieuchung")
                txtChandoanSB.Text = ds.Tables("Hoso").Rows(0).Item("Chandoan")
                txtNgaykham.Value = ds.Tables("Hoso").Rows(0).Item("Thoigiandangky")
                'cmbDM_BacSy.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Bacsi").ToString().Trim()
                'nmDatCoc.Value = Decimal.Parse(ds.Tables("Hoso").Rows(0).Item("DatCoc").ToString())
                If ds.Tables("Hoso").Rows(0).Item("TaiKham").ToString() <> "" Then
                    dtTaiKham.Value = Convert.ToDateTime(ds.Tables("Hoso").Rows(0).Item("TaiKham").ToString())
                End If

                'Fill DS Đơn thuốc
                Dim Madon As String = ""
                Fill_Donthuoc(txtMakhambenh.Text) 'Fill Đơn thuốc
                Fill_DichVu(txtMakhambenh.Text) 'Fill Đơn thuốc
                'Fill các danh sach lich su kham benh
                Fill_DSKhamtruoc(txtMabenhnhan.Text)
                'Tinh tong chi phi
                TinhTongChiPhi()
                EnableControls(True)
                btnThemLanKham.Enabled = True
                btnLuuBenhNhan.Enabled = False
                btnSuaThongTin.Enabled = True
                btnInPhieuThuoc.Enabled = True
            Else
                MsgBox("The patient is not yet in the Database", MsgBoxStyle.Information, "Messages !")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fill_DSKhamtruoc(ByVal mabenhnhan As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Dim Xutri As String = ""
        Try
            SQL = "Select tblKhamBenh.MaKhamBenh,tblKhamBenh.ThoiGianDangKy,tblKhamBenh.ChanDoan Chandoan " _
            & " from tblKhambenh " _
            & " where MaBenhNhan = '" & mabenhnhan & "'" _
            & " order by ThoiGianDangKy desc"
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            grdTiensuKB.Rows.Count = 1
            If ds.Tables("Hoso").Rows.Count > 0 Then
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1

                    grdTiensuKB.AddItem((i + 1) & vbTab & ds.Tables("Hoso").Rows(i).Item("MaKhamBenh") _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("ThoiGianDangKy") _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("ChanDoan"))
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fill_Donthuoc(ByVal maKhamBenh As String) 'ma = Mã phiếu chi dinh
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            If Trim(maKhamBenh) = "" Then Exit Sub

            SQL = "Select MaphieuCD,Mathuoc as ThuocID,STT,DVT,DonGia,Soluong as SoLuong,(DonGia*Soluong) as ThanhTien,Cachdung As CachDung from  tblKhambenh_Donthuoc " _
             & " where tblKhambenh_Donthuoc.MaKhamBenh = N'" & maKhamBenh & "' order by STT " '& " left outer join DMTHUOC on tblKhambenh_Donthuoc.Mathuoc = DMTHUOC.ThuocID  " _
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                Madonthuoc_Sua = ds.Tables("Hoso").Rows(0).Item("MaphieuCD")
                GridControl2.DataSource = ds.Tables("Hoso")

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fill_DichVu(ByVal maKhamBenh As String) 'ma = Mã phiếu chi dinh
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            If Trim(maKhamBenh) = "" Then Exit Sub

            SQL = "Select MaphieuCD,MaDichvu as MaDichVu,DVT,DonGia,Soluong As SoLuong,Thutuchidinh as STT,(DonGia*Soluong) as ThanhTien  from  tblKhambenh_DichVu " _
             & " where tblKhambenh_DichVu.MaKhamBenh = N'" & maKhamBenh & "' order by Thutuchidinh " '& " left outer join DMTHUOC on tblKhambenh_Donthuoc.Mathuoc = DMTHUOC.ThuocID  " _
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                MaPhieuCD = ds.Tables("Hoso").Rows(0).Item("MaphieuCD")
                GridControl1.DataSource = ds.Tables("Hoso")

            End If
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
    Public Sub FillChiphi(ByVal Ma) 'Ma = Makhambenh
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            If Trim(Ma) = "" Then Exit Sub
            With grdChiphi
                .Rows.Count = 1
                'SQL = "Select * from (select MaloaiDichvu, TenloaiDichvu,tblKhambenh_Dichvu.MaDichvu,DMDichvu.TenDichvu," _
                '& " DMDichvu.DVT,tblKhambenh_Dichvu.Soluong,DMDichvu.Dongia,DMDichvu.DongiaBHYT,tblKhambenh_Dichvu.Daduyet,  " _
                '& " DMKhoaphong.MaKhoa,DMKhoaphong.TenKhoa, tblKhambenh_Dichvu.Dathuchien  " _
                '& " from tblKhambenh_Dichvu  " _
                '& " left outer join vDMDICHVU on tblKhambenh_Dichvu.MaDichvu = DMDichvu.MaDichvu  " _
                '& " left outer join DMLoaiDichvu on DMDichvu.LoaiDichvu = DMLoaiDichvu.MaLoaiDichvu  " _
                '& " left outer join DMKhoaphong on tblKhambenh_Dichvu.Khoathuchien = DMKhoaphong.Makhoa  " _
                '& " where tblKhambenh_Dichvu.Makhambenh = '" & Ma & "'    " _
                '& " Union all  " _
                '& " Select 'D01' as MaLoaiDichvu, N'Thuốc, hóa chất' as TenloaiDichvu,DMDichvu.MaDichvu,  " _
                '& " Tenthuoc as TenDichvu,DMDichvu.DVT,tblKhambenh_Donthuoc.Soluong,DMDichvu.Dongia,DMDichvu.DongiaBHYT,tblKhambenh_Donthuoc.Daduyet,  " _
                '& " '' as MaKhoa,N'Dược' as TenKhoa,tblKhambenh_Donthuoc.Dathuchien  from tblKhambenh_Donthuoc  " _
                '& " left outer join vDMDICHVU on DMDichvu.MaDichvu = tblKhambenh_Donthuoc.MaThuoc  " _
                '& " where tblKhambenh_Donthuoc.Makhambenh = '" & Ma & "')U   " _
                '& " order by MaLoaiDichvu,MaDichvu"
                SQL = "select MaloaiDichvu, TenloaiDichvu,tblKhambenh_Dichvu.MaDichvu,vDMDichvu.TenDichvu," _
                & " vDMDichvu.DVT,tblKhambenh_Dichvu.Soluong,vDMDichvu.Dongia,vDMDichvu.DongiaBHYT,tblKhambenh_Dichvu.Daduyet,  " _
                & " DMKhoaphong.MaKhoa,DMKhoaphong.TenKhoa, tblKhambenh_Dichvu.Dathuchien  " _
                & " from tblKhambenh_Dichvu  " _
                & " left outer join vDMDICHVU on tblKhambenh_Dichvu.MaDichvu = vDMDichvu.MaDichvu  " _
                & " left outer join DMLoaiDichvu on vDMDichvu.LoaiDichvu = DMLoaiDichvu.MaLoaiDichvu  " _
                & " left outer join DMKhoaphong on tblKhambenh_Dichvu.Khoathuchien = DMKhoaphong.Makhoa  " _
                & " where tblKhambenh_Dichvu.Makhambenh = '" & Ma & "'    " _
                & " order by DMLoaiDichvu.MaLoaiDichvu,tblKhambenh_Dichvu.MaDichvu"

                Cmd = New SqlCommand(SQL, Cn)
                Adap = New SqlDataAdapter
                Adap.SelectCommand = Cmd
                ds = New DataSet
                Adap.Fill(ds, "Hoso")
                If ds.Tables("Hoso").Rows.Count > 0 Then
                    Dim temp As String = ""
                    For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                        temp = ""
                        temp = ds.Tables("Hoso").Rows(i).Item("MaLoaiDichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenLoaiDichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("MaDichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenDichvu")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong")
                        temp = temp & vbTab & Format(Val(ds.Tables("Hoso").Rows(i).Item("Dongia").ToString), "###,###") & vbTab & Format(Val(ds.Tables("Hoso").Rows(i).Item("Dongia").ToString) * Val(ds.Tables("Hoso").Rows(i).Item("Soluong").ToString), "###,###")
                        temp = temp & vbTab & Format(Val(ds.Tables("Hoso").Rows(i).Item("DongiaBHYT").ToString), "###,###") & vbTab & Format(Val(ds.Tables("Hoso").Rows(i).Item("DongiaBHYT").ToString) * Val(ds.Tables("Hoso").Rows(i).Item("Soluong").ToString), "###,###")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("Daduyet") & vbTab & ds.Tables("Hoso").Rows(i).Item("Makhoa") & vbTab & ds.Tables("Hoso").Rows(i).Item("Tenkhoa") & vbTab & ds.Tables("Hoso").Rows(i).Item("Dathuchien")
                        .AddItem(temp)
                    Next
                End If
                .AutoSizeCols()
                .ExtendLastCol = True
                ' Nếu là đối tượng khác
                .Cols(6).Visible = True
                .Cols(7).Visible = True
                .Cols(8).Visible = False
                .Cols(9).Visible = False
                .Subtotal(AggregateEnum.Sum, 0, 1, 7, "{0}")
                .Cols(7).Format() = "###,###"

            End With
            Cmd.Dispose()
            Adap.Dispose()
            Adap.Dispose()
            ds = New DataSet
        Catch ex As Exception
        End Try
    End Sub
    'HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH

    '&&&&&&&&&&&& Nhóm code các sự kiện &&&&&&&&&&&&
    Private Sub cmdGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtTenbenhnhan.Text = "" Then Exit Sub

        MsgBox("Save data successfully", MsgBoxStyle.Information, "Messages!")
        'FillChiphi(txtMakhambenh.Text)
    End Sub
    Private Sub cmdDanhsachBN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDanhsachBN.Click

        Dim frm As New frmDanhsachBN
        frm.MdiParent = FrmMain_KB
        If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            frm.TopMost = True
            txtMakhambenh.Text = frm.MaPhieuKham
            FillData(txtMakhambenh.Text)
            txtTrieuchung.Focus()
            cmdKedon.Enabled = True
            btnThemLanKham.Enabled = True
            btnLuuBenhNhan.Enabled = False
            btnSuaThongTin.Enabled = True
            btnInPhieuThuoc.Enabled = True
            grBenhnhan.Enabled = True
            TabControl2.Enabled = True
            booSuadon = True
        End If
    End Sub

    Private Sub cmdKedon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKedon.Click
        'Clear Controls...
        booThemdon = True
        Madonthuoc_Sua = ""
        MaPhieuCD = ""
        SetEmpty()
        'grBenhnhan.Enabled = True
        EnableControls(True)

        cmdKedon.Enabled = False
        btnThemLanKham.Enabled = False
        btnLuuBenhNhan.Enabled = True
        btnHuyThaoTac.Enabled = True
        btnSuaThongTin.Enabled = False
        btnInPhieuThuoc.Enabled = False
    End Sub

    'Private Sub cmbMatbenh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMatbenh.TextChanged
    '    Dim SQL As String
    '    Dim Cmd As SqlCommand
    '    Dim Adap As SqlDataAdapter
    '    Dim ds As DataSet
    '    Dim i
    '    Dim temp As String = ""
    '    If cmdThemdon.Enabled = True Or txtMaphieukham.Text = "" Or Not chkDontheomau.Checked Then Exit Sub
    '    Try
    '        grdSoanDonthuoc.Rows.Count = 1
    '        If optThuocCap.Checked Then
    '            If cmbDoituong.SelectedValue = "1" Then
    '                temp = " where  KhoID = 'E'   "
    '            End If
    '            If cmbDoituong.SelectedValue = "2" Or cmbDoituong.SelectedValue = "3" Then
    '                temp = " where  KhoID = 'C'    "
    '            End If
    '            SQL = "SELECT a.*,c.Tenthuoc as Ten , c.Tengoc, isnull(b.SlHientai,0) as SLHT  FROM  tblSOTAYDONTHUOC_CT a " _
    '            & " left outer join (select * from  " & TenDatabase & ".DBO.Thekho " & temp & ")  b  on a.ThuocID = b.ThuocID   " _
    '            & " left outer join " & TenDatabase & ".DBO.vDanhmucThuoc c  on a.ThuocID = c.ThuocID  " _
    '            & "  where a.ID_SotayDonthuoc =  " & cmbMatbenh.SelectedValue & " "
    '        Else
    '            SQL = "SELECT a.*,b.Tenthuoc as Ten , b.Tengoc, 1 as SLHT  FROM  tblSOTAYDONTHUOC_CT a " _
    '            & " left outer join " & TenDatabase & ".DBO.vDanhmucThuoc b  on a.ThuocID = b.ThuocID " _
    '            & " where a.ID_SotayDonthuoc =  " & cmbMatbenh.SelectedValue & " "
    '        End If
    '        Cmd = New SqlCommand(SQL, Cn)
    '        Adap = New SqlDataAdapter
    '        Adap.SelectCommand = Cmd
    '        ds = New DataSet
    '        Adap.Fill(ds, "Hoso")
    '        If ds.Tables("Hoso").Rows.Count > 0 Then
    '            For i = 0 To ds.Tables("Hoso").Rows.Count - 1
    '                If ds.Tables("Hoso").Rows(i).Item("SLHT") > 0 Then
    '                    grdSoanDonthuoc.AddItem(grdSoanDonthuoc.Rows.Count & vbTab & ds.Tables("Hoso").Rows(i).Item("ThuocID") & vbTab & ds.Tables("Hoso").Rows(i).Item("Ten") & vbTab & vbTab & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong") & vbTab & ds.Tables("Hoso").Rows(i).Item("Cachdung") & vbTab & IIf(ds.Tables("Hoso").Rows(i).Item("Thuocmua") = 0, True, False))
    '                Else
    '                    MsgBox("Chú ý: " + ds.Tables("Hoso").Rows(i).Item("Ten") + " đã hết", MsgBoxStyle.Information, "Messages!")
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Private Sub cmbMatbenh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMatbenh.TextChanged
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Dim temp As String = ""
        Try
            For i = grv_DonThuoc.RowCount - 1 To 0 Step -1
                grv_DonThuoc.DeleteRow(i)
            Next

            SQL = "SELECT a.ThuocID,a.Thutu as STT,a.Tenthuoc, a.DVT,isnull(b.DonGia,0) as DonGia,a.Soluong as SoLuong,(isnull(b.DonGia,0) * a.Soluong) as ThanhTien,a.CachDung " _
            & " FROM  tblSOTAYDONTHUOC_CT a left outer join   DBO.DMThuoc b  on a.ThuocID = b.ThuocID " _
            & " where a.ID_SotayDonthuoc =  " & cmbMatbenh.SelectedValue & "  order by Thutu"
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "SoThuoc")
            If ds.Tables("SoThuoc").Rows.Count > 0 Then
                GridControl2.DataSource = ds.Tables("SoThuoc")
                TinhTongChiPhi()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Hide()
    End Sub

    ' &&&&&&&&&&&&&&Nhóm lưu data vào CSDL &&&&&&&&&&&&&&&&&&&&&&&&&&&&
    ' &&&&&&&&&& Them moi mot benh nhan &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    Private Sub Them_ThongtinHC()
        ' Thủ tục này để lưu các thông tin hành chính do bác sĩ chỉnh sửa, bổ sung thêm nếu cần
        Dim TenBenhnhan, Namsinh, Gioitinh
        Dim Diachi, Lienhe, Chandoan
        Dim Tran As SqlTransaction
        Dim Cmd As New SqlCommand
        TenBenhnhan = "N'" & Replace(Trim(txtTenbenhnhan.Text), "'", "''") & "'"
        Namsinh = ""
        If txtTuoi.Value Is System.DBNull.Value Then
            Namsinh = "null"
        Else
            Namsinh = txtTuoi.Value.ToString()
        End If
        Gioitinh = IIf(cmbGioitinh.Text = "Nam", 1, 0)
        Diachi = "N'" & Replace(Trim(txtDiachi.Text), "'", "''") & "'"
        Tran = Cn.BeginTransaction()
        Try
            Cmd.Connection = Cn
            Cmd.Transaction = Tran
            Cmd.CommandText = "Select Getdate()"
            Dim ThoigianHT = Cmd.ExecuteScalar()
            'Sửa thông tin bệnh nhân
            If txtMabenhnhan.Text.Trim() = "" Then
                Cmd.CommandText = " Insert into " & TenDatabase & ".DBO.tblBenhnhan ( MaBenhnhan, TenBenhnhan, Namsinh,Gioitinh,SoDienThoai) " _
                                & " values ( " & TenDatabase & ".DBO.LayMaBenhNhan('" & Format(DateTime.Now, "yyMMdd") & "') , " _
                                & " " & TenBenhnhan & " , " & Namsinh & ", " & Gioitinh & ", " & txtLienHe.Text.Trim & " ) " _
                                 & " select Top 1 Mabenhnhan from tblBenhnhan order by MaBenhnhan DESC "
                txtMabenhnhan.Text = Cmd.ExecuteScalar().ToString
            End If

            'thông tin khám bệnh
            Dim strDC As String = nmDatCoc.Value.ToString()
            Cmd.CommandText = "Select " & TenDatabase & ".DBO.LayMaKhambenh('" & Format(DateTime.Now, "yyMMdd") & "')" _
                & " Insert into tblKhambenh ( MaBenhnhan, MaKhambenh, " _
                & "   ThoigianDangky,DoiTuong, " _
                & "   Diachi, " _
                & "   Lienhe,TrieuChung,ChanDoan,BacSi,DatCoc,TaiKham ) " _
                & " values ( '" & txtMabenhnhan.Text & "'," & TenDatabase & ".DBO.LayMaKhambenh('" & Format(DateTime.Now, "yyMMdd") & "') , " _
                & " '" & Format(DateTime.Now, "MM/dd/yyyy HH:mm:ss") & "' , 0, " _
                & " " & Diachi & " ,'" & txtLienHe.Text.Trim() & "' ,N'" & txtTrieuchung.Text.Trim() & "',N'" _
                & txtChandoanSB.Text.Trim() & "',N'',0,'" & Format(dtTaiKham.Value, "MM/dd/yyyy HH:mm:ss") & "') "

            txtMakhambenh.Text = Cmd.ExecuteScalar().ToString
            Tran.Commit()
            Cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()
        End Try
    End Sub

    ' &&&&&&&&&& Cap nhat lai thong tin &&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    Private Sub LuuThongtinHC()
        ' Thủ tục này để lưu các thông tin hành chính do bác sĩ chỉnh sửa, bổ sung thêm nếu cần
        Dim TenBenhnhan, Namsinh, Gioitinh
        Dim Doituong, Diachi, Nghenghiep, Noicongtac, Lienhe, Chandoan
        Dim Tran As SqlTransaction
        Dim Cmd As New SqlCommand
        TenBenhnhan = "N'" & Replace(Trim(txtTenbenhnhan.Text), "'", "''") & "'"
        Namsinh = ""
        If txtTuoi.Value Is System.DBNull.Value Then
            Namsinh = "null"
        Else
            Namsinh = txtTuoi.Value.ToString()
        End If
        Gioitinh = IIf(cmbGioitinh.Text = "Nam", 1, 0)
        Diachi = "N'" & Replace(Trim(txtDiachi.Text), "'", "''") & "'"
        Tran = Cn.BeginTransaction()
        Try
            Cmd.Connection = Cn
            Cmd.Transaction = Tran
            Cmd.CommandText = "Select Getdate()"
            Dim ThoigianHT = Cmd.ExecuteScalar()
            'Sửa thông tin bệnh nhân
            Cmd.CommandText = "Update tblBenhnhan set   TenBenhnhan = " & TenBenhnhan & " ,  " _
            & "   Namsinh =" & Namsinh & ",Gioitinh = " & Gioitinh & " where Mabenhnhan = '" & txtMabenhnhan.Text & "' "
            Cmd.ExecuteNonQuery()
            'Sửa thông tin khám bệnh
            Cmd.CommandText = "Update tblKhambenh set " _
            & "   Diachi = " & Diachi & "" _
            & "   ,Lienhe = N'" & txtLienHe.Text.Trim() & "'" _
            & "   ,TrieuChung = N'" & txtTrieuchung.Text.Trim() & "'" _
            & "   ,ChanDoan = N'" & txtChandoanSB.Text.Trim() & "'" _
            & "   ,BacSi = N''" _
            & "   ,DatCoc = " & nmDatCoc.Value & "" _
            & "   ,TaiKham = '" & Format(dtTaiKham.Value, "MM/dd/yyyy HH:mm:ss") & "'" _
            & " where Mabenhnhan = '" & txtMabenhnhan.Text & "' and  MaKhambenh = '" & txtMakhambenh.Text & "' "
            Cmd.ExecuteNonQuery()
            Tran.Commit()
            Cmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()
        End Try
    End Sub

    Private Sub LuuDonthuoc(ByVal Ma As String, ByVal MaDonS As String) 'Ma = Mã phiếu khám: Đơn thuốc của phiếu khám nào; MaDonS = Mã đơn thuốc, có thể = "" nếu thêm mới đơn
        Dim Sql As String
        Dim Cmd As New SqlCommand
        Dim Tran As SqlTransaction = Nothing
        Dim i
        Try
            Dim ThoigianHT = GetSrvDate()
            Tran = Cn.BeginTransaction()
            Cmd = New SqlCommand()
            Cmd.Connection = Cn
            Cmd.Transaction = Tran

            If MaDonS = "" Then ' ***** Trường hợp thêm mới đơn thuốc *****' Thêm mới vào cả 3 bảng chỉ định,Dịch vụ,Đơn thuốc
                ' Nếu chưa có thuốc nào o cho lưu
                If grv_DonThuoc.RowCount < 1 Then
                    MsgBox("There are no drugs to save", MsgBoxStyle.Critical, "Messages!")
                    Exit Sub
                End If
                'Thêm Đơn thuốc (1 loại phiếu chỉ định) vào tblKHAMBENH_CHIDINH
                Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','DT',N'{8}',N'{9}', N'{10}'", txtMabenhnhan.Text, txtMakhambenh.Text, "DT", ThoigianHT, "", TenDangNhap, txtMaDV.Text, 0, "", "", "")
                Dim MaCD As String = Cmd.ExecuteScalar() ' Lấy mã phiếu chỉ định (thuốc) mới
                lblChitiet_Donthuoc.Tag = MaCD
                lblChitiet_Donthuoc.Text = "Danh sách các thuốc kê trong đơn   " + MaCD
                Madonthuoc_Sua = MaCD
                'Thêm Thuốc đã kê vào tblKHAMBENH_DICHVU và tblKHAMBENH_DONTHUOC
                For i = 0 To grv_DonThuoc.RowCount - 2
                    Cmd.CommandText = "Insert into tblKHAMBENH_DONTHUOC ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaThuoc,Maphieukham,STT,Tenthuoc,Tengoc, Hamluong,Soluong,DonGia,	DVT,	Cachdung,	ThuocMua,	Daduyet,	Dathuchien,	Soluongcap,	Ghichu) " _
                    & " values ( '" & txtMabenhnhan.Text & "','" & txtMakhambenh.Text & "', " _
                    & " '" & MaCD & "','" & grv_DonThuoc.GetRowCellValue(i, "ThuocID").ToString() & "', '" & Ma & "'," & Val(grv_DonThuoc.GetRowCellValue(i, "STT").ToString()) & ", " _
                    & "  N'" & Replace(grv_DonThuoc.GetRowCellDisplayText(i, "ThuocID").ToString(), "'", "''") & "','', " _
                    & " ''," & Val(grv_DonThuoc.GetRowCellValue(i, "SoLuong").ToString()) & ", " & Val(grv_DonThuoc.GetRowCellValue(i, "DonGia").ToString()) & ", " _
                    & " N'" & grv_DonThuoc.GetRowCellValue(i, "DVT").ToString() & "', N'" & Replace(grv_DonThuoc.GetRowCellValue(i, "CachDung").ToString(), "'", "''") & "',1 ," _
                    & " 0,0,0,'')"
                    Cmd.ExecuteNonQuery()
                Next
            Else ' ****** Trường hợp sửa đơn thuốc *******
                ' (Chú ý: sau này dược ngoại trú hoạt động tốt phải kiểm tra xem đã cấp chưa, nếu đã cấp ko cho sửa)
                If MsgBox("Are you sure you want to overwrite your old prescription?", MsgBoxStyle.YesNo, "Request confirmation") = MsgBoxResult.No Then Exit Sub
                ' Xóa trong bảng Đơn thuốc
                Sql = "Delete from tblKhambenh_Donthuoc where MaphieuCD = '" & MaDonS & "'"
                Cmd.CommandText = Sql
                Cmd.ExecuteNonQuery()
                ' Xóa trong bảng Dịch vụ
                Sql = "Delete from tblKhambenh_Dichvu where MaphieuCD = '" & MaDonS & "'"
                Cmd.CommandText = Sql
                Cmd.ExecuteNonQuery()
                ' Xóa trong bảng Chỉ định
                Sql = "Delete from tblKhambenh_Chidinh where MaphieuCD = '" & MaDonS & "'"
                Cmd.CommandText = Sql
                Cmd.ExecuteNonQuery()
                ' Thêm mới vào cả 3 bảng chỉ định,Dịch vụ,Đơn thuốc
                'Thêm Đơn thuốc (1 loại phiếu chỉ định) vào tblKHAMBENH_CHIDINH
                Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','DT',N'{8}',N'{9}',N'{10}'", txtMabenhnhan.Text, txtMakhambenh.Text, "DT", ThoigianHT, MaKhoaphong, TenDangNhap, txtMaDV.Text, 0, "", "", "")
                Dim MaCD As String = Cmd.ExecuteScalar() ' Lấy mã phiếu chỉ định (thuốc) mới
                Madonthuoc_Sua = MaCD
                'Thêm Thuốc đã kê vào tblKHAMBENH_DICHVU và tblKHAMBENH_DONTHUOC
                For i = 0 To grv_DonThuoc.RowCount - 2
                    Dim str As String
                    Cmd.CommandText = "Insert into tblKHAMBENH_DONTHUOC ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                        & " MaThuoc,Maphieukham,STT,Tenthuoc,Tengoc, Hamluong,Soluong,DonGia,	DVT,	Cachdung,	ThuocMua,	Daduyet,	Dathuchien,	Soluongcap,	Ghichu) " _
                        & " values ( '" & txtMabenhnhan.Text & "','" & txtMakhambenh.Text & "', " _
                        & " '" & MaCD & "','" & grv_DonThuoc.GetRowCellValue(i, "ThuocID").ToString() & "', '" & Ma & "'," & Val(grv_DonThuoc.GetRowCellValue(i, "STT").ToString()) & ", " _
                        & "  N'" & Replace(grv_DonThuoc.GetRowCellDisplayText(i, "ThuocID").ToString(), "'", "''") & "','', " _
                        & " ''," & Val(grv_DonThuoc.GetRowCellValue(i, "SoLuong").ToString()) & ", " & Val(grv_DonThuoc.GetRowCellValue(i, "DonGia").ToString()) & ", " _
                        & " N'" & grv_DonThuoc.GetRowCellValue(i, "DVT").ToString() & "', N'" & Replace(grv_DonThuoc.GetRowCellValue(i, "CachDung").ToString(), "'", "''") & "',1 ," _
                        & " 0,0,0,'')"
                    Cmd.ExecuteNonQuery()
                Next
            End If
            'Cập nhật lời dặn của bác sĩ vào bảng Kết quả Khám

            Tran.Commit()
            'MsgBox("Đã kê đơn xong", MsgBoxStyle.Information, "Messages!")
            Dim Madon As String = ""


        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LuuDichVu(ByVal Ma As String, ByVal MaDonS As String) 'Ma = Mã phiếu khám: Đơn thuốc của phiếu khám nào; MaDonS = Mã đơn thuốc, có thể = "" nếu thêm mới đơn
        Dim Sql As String
        Dim Cmd As New SqlCommand
        Dim Tran As SqlTransaction = Nothing
        Dim i
        Try
            Dim ThoigianHT = GetSrvDate()
            Tran = Cn.BeginTransaction()
            Cmd = New SqlCommand()
            Cmd.Connection = Cn
            Cmd.Transaction = Tran

            If MaDonS = "" Then ' ***** Trường hợp thêm mới đơn thuốc *****' Thêm mới vào cả 3 bảng chỉ định,Dịch vụ,Đơn thuốc
                ' Nếu chưa có thuốc nào o cho lưu
                If grv_DichVu.RowCount < 1 Then
                    MsgBox("There are no services to save yet", MsgBoxStyle.Critical, "Messages!")
                    Exit Sub
                End If
                'Thêm Đơn thuốc (1 loại phiếu chỉ định) vào tblKHAMBENH_CHIDINH
                Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','DT',N'{8}',N'{9}', N'{10}'", txtMabenhnhan.Text, txtMakhambenh.Text, "CD", ThoigianHT, "", TenDangNhap, txtMaDV.Text, 0, "", "", "")
                Dim MaCD As String = Cmd.ExecuteScalar() ' Lấy mã phiếu chỉ định (thuốc) mới
                lblChitiet_Donthuoc.Tag = MaCD
                lblChitiet_Donthuoc.Text = "Danh sách các thuốc kê trong đơn   " + MaCD
                MaPhieuCD = MaCD
                'Thêm Thuốc đã kê vào tblKHAMBENH_DICHVU và tblKHAMBENH_DONTHUOC
                For i = 0 To grv_DichVu.RowCount - 2
                    Cmd.CommandText = "Insert into tblKHAMBENH_DichVu ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaDichVu,DVT,DonGia,Soluong,KhoaThucHien,DaDuyet,DaThucHien,TuTuc,Ghichu,Thutuchidinh,MaloaiphieuCD) " _
                    & " values ( '" & txtMabenhnhan.Text & "','" & txtMakhambenh.Text & "' " _
                    & " ,'" & MaCD & "','" & grv_DichVu.GetRowCellValue(i, "MaDichVu").ToString() & "',N'" _
                    & grv_DichVu.GetRowCellValue(i, "DVT").ToString() & "', " & Val(grv_DichVu.GetRowCellDisplayText(i, "DonGia").ToString()) & ", " _
                    & Val(grv_DichVu.GetRowCellDisplayText(i, "SoLuong").ToString()) & ",'', " _
                    & " 1, 1,1, '', " & Val(grv_DichVu.GetRowCellDisplayText(i, "STT").ToString()) & ",'CD')"
                    Cmd.ExecuteNonQuery()
                Next
            Else ' ****** Trường hợp sửa đơn thuốc *******
                ' (Chú ý: sau này dược ngoại trú hoạt động tốt phải kiểm tra xem đã cấp chưa, nếu đã cấp ko cho sửa)
                If MsgBox("Are you sure you want to overwrite the old assignments?", MsgBoxStyle.YesNo, "Request confirmation") = MsgBoxResult.No Then Exit Sub
                ' Xóa trong bảng Đơn thuốc
                ' Xóa trong bảng Dịch vụ
                Sql = "Delete from tblKhambenh_Dichvu where MaphieuCD = '" & MaPhieuCD & "'"
                Cmd.CommandText = Sql
                Cmd.ExecuteNonQuery()
                ' Xóa trong bảng Chỉ định
                Sql = "Delete from tblKhambenh_Chidinh where MaphieuCD = '" & MaPhieuCD & "'"
                Cmd.CommandText = Sql
                Cmd.ExecuteNonQuery()
                ' Thêm mới vào cả 3 bảng chỉ định,Dịch vụ,Đơn thuốc
                'Thêm Đơn thuốc (1 loại phiếu chỉ định) vào tblKHAMBENH_CHIDINH
                Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','DT',N'{8}',N'{9}',N'{10}'", txtMabenhnhan.Text, txtMakhambenh.Text, "CD", ThoigianHT, MaKhoaphong, TenDangNhap, txtMaDV.Text, 0, "", "", "")
                Dim MaCD As String = Cmd.ExecuteScalar() ' Lấy mã phiếu chỉ định (thuốc) mới
                MaPhieuCD = MaCD
                'Thêm Thuốc đã kê vào tblKHAMBENH_DICHVU và tblKHAMBENH_DONTHUOC
                For i = 0 To grv_DichVu.RowCount - 2
                    Cmd.CommandText = "Insert into tblKHAMBENH_DichVu ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                        & " MaDichVu,DVT,DonGia,Soluong,KhoaThucHien,DaDuyet,DaThucHien,TuTuc,Ghichu,Thutuchidinh,MaloaiphieuCD) " _
                        & " values ( '" & txtMabenhnhan.Text & "','" & txtMakhambenh.Text & "' " _
                        & " ,'" & MaCD & "','" & grv_DichVu.GetRowCellValue(i, "MaDichVu").ToString() & "',N'" _
                        & grv_DichVu.GetRowCellValue(i, "DVT").ToString() & "', " & Val(grv_DichVu.GetRowCellDisplayText(i, "DonGia").ToString()) & "," _
                        & Val(grv_DichVu.GetRowCellDisplayText(i, "SoLuong").ToString()) & ",'', " _
                        & " 1,1,1 , '', " & Val(grv_DichVu.GetRowCellDisplayText(i, "STT").ToString()) & ",'CD')"
                    Cmd.ExecuteNonQuery()
                Next
            End If
            'Cập nhật lời dặn của bác sĩ vào bảng Kết quả Khám

            Tran.Commit()
            ' MsgBox("Đã kê đơn xong", MsgBoxStyle.Information, "Messages!")
            Dim Madon As String = ""


        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdLuu_XemDonthuoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If grdSoanDonthuoc.Rows.Count < 2 Or lblChitiet_Donthuoc.Tag = "" Then Exit Sub

        ''LuuDonthuoc(txtMaphieukham.Text)
        'Dim NgayHT As Date
        'Dim frm As New frmPreview
        'frm.Tenbenhnhan = txtTenbenhnhan.Text
        'frm.Namsinh = txtTuoi.Text
        'frm.Gioitinh = cmbGioitinh.Text

        'frm.Diachi = IIf(txtDiachi.Text.Trim() = "", "                                      ", txtDiachi.Text)
        'frm.lblDIachi_Capbac = "Địa chỉ: "

        'frm.Loidan = txtLoidan.Text
        'NgayHT = GetSrvDate()
        'frm.Ngaydonthuoc = "Ngày " + Format(NgayHT, "dd") + " tháng " + Format(NgayHT, "MM") + " năm " + Format(NgayHT, "yyyy")
        ''frm.SQL_str = "Select * from tblKhambenh_Donthuoc left outer join DMThuoc on tblKhambenh_Donthuoc.Mathuoc = DMThuoc.ThuocID " _
        'frm.SQL_str = "Select Mabenhnhan, Makhambenh,MaphieuCD, STT,('   ' + tenthuoc) as tenthuoc,TenGoc,Hamluong,DVT, " _
        '& " Soluong, ('   ' + Cachdung) as Cachdung, (1- Thuocmua) as ThuocCap, Thuocmua  from tblKhambenh_Donthuoc   " _
        '& " where MaphieuCD = '" & lblChitiet_Donthuoc.Tag & "' and MaKhambenh =  '" & txtMakhambenh.Text & "' order by Stt,Thuocmua" ' and Thuocmua= 0"
        ''& " where Mabenhnhan = '" & txtMabenhnhan.Text & "'  and MaKhambenh =  '" & txtMakhambenh.Text & "' and Maphieukham =  '" & txtMaphieukham.Text & "' order by Thuocmua" ' and Thuocmua= 0"
        'frm.Goi = "Don thuoc"

        'frm.arViewer_Load(Nothing, Nothing)
        'frm.arViewer.Document.Print(False, True, False)
        ''frm.arViewer.Document.Print(False, True, False)


    End Sub

    'HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
    '&&&&&&&&&&&&& Code phần kê đơn thuốc &&&&&&&&&&&&&&&&&&&&&&&&&&
    'Private Sub txtThuoc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtThuoc.KeyUp
    '    If e.KeyCode = Keys.Down And grdSoanDonthuoc.Visible Then
    '        grdDMThuoc.Focus()
    '        grdDMThuoc.Row = 1
    '    End If
    'End Sub

    Private Sub grdDMThuoc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub

    'HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH


    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    'Tạm thời chưa dùng chức năng lấy đơn thuốc cũ, nên thiết kế để hiển thị tất cả các đơn đã kê và cho chọn,
    ' ở đây đang lấy đơn gần nhât - > ko nhiều ý nghĩa lắm
    'Private Sub cmdDonthuocCu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDonthuocCu.Click
    '    If txtMaphieukham.Text = "" Then Exit Sub

    '    Dim SQL As String
    '    Dim Cmd As SqlCommand
    '    Dim Adap As SqlDataAdapter
    '    Dim ds As DataSet
    '    Dim i
    '    Try
    '        Dim Maphieu As String = ""
    '        SQL = "SELECT tblKhambenh_Donthuoc.MaphieuCD from  tblKhambenh_Donthuoc " _
    '        & " where tblKhambenh_Donthuoc.Mabenhnhan =  '" & txtMabenhnhan.Text & "' order by MaphieuCD desc"
    '        Cmd = New SqlCommand(SQL, Cn)
    '        Maphieu = Cmd.ExecuteScalar()
    '        If Maphieu = "" Then Exit Sub
    '        SQL = "SELECT tblKhambenh_Donthuoc.*,DMTHUOC.Tenthuoc FROM  tblKhambenh_Donthuoc " _
    '        & " left outer join DMTHUOC  on tblKhambenh_Donthuoc.Mathuoc = DMTHUOC.ThuocID   " _
    '        & " where tblKhambenh_Donthuoc.MaphieuCD =  '" & Maphieu & "' "
    '        Cmd = New SqlCommand(SQL, Cn)
    '        Adap = New SqlDataAdapter
    '        Adap.SelectCommand = Cmd
    '        ds = New DataSet
    '        Adap.Fill(ds, "Hoso")
    '        If ds.Tables("Hoso").Rows.Count > 0 Then
    '            If MsgBox("Bạn có chắc chắn lấy đơn cũ không?", MsgBoxStyle.YesNo, "Yêu cầu xác nhận!") = MsgBoxResult.No Then Exit Sub
    '            grdDonthuoc.Rows.Count = 1
    '            For i = 0 To ds.Tables("Hoso").Rows.Count - 1
    '                grdDonthuoc.AddItem(i + 1 & vbTab & ds.Tables("Hoso").Rows(i).Item("Mathuoc") & vbTab & ds.Tables("Hoso").Rows(i).Item("Tenthuoc") & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong") & vbTab & ds.Tables("Hoso").Rows(i).Item("Cachdung") & vbTab & IIf(ds.Tables("Hoso").Rows(i).Item("Thuocmua") = 0, True, False))
    '            Next
    '        End If
    '        Cmd.Dispose()
    '        Adap.Dispose()
    '        ds.Dispose()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub cmdThoat_Tab1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat_Tab1.Click

        Me.Dispose()
    End Sub




    ' Chua biet de vao dau




    '*********** PHAN CODE form Chỉ định của Quyền chuyển sang *******************
    'Các biến dùng chung trong form
    Private isAddNew As Boolean
    Private PhieuChidinh_Header As String = "" 'Ma loai phieuCD gan voi chi dinh dang xet
    Private MaDoituong_LanLoad_truoc As String = ""

    Private Sub Load_DichVu(ByVal MaDoituong As String)
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim DonGia As String = ""
        Dim i As Integer
        If MaDoituong_LanLoad_truoc = MaDoituong Then Exit Sub
        MaDoituong_LanLoad_truoc = MaDoituong
        If MaDoituong.Substring(0, 1) = "1" Then DonGia = "DonGiaBHYT as DonGia," Else DonGia = "DonGia  as DonGia,"
        'Load dich vu theo Loaidichvu
        'Dim Sql As String = String.Format("  SELECT MaLoaiDichVu,TenLoaiDichVu,a.MaDichVu,TenDichVu,DVT,{0} TenKhoa,0 as Chon,c.MaKhoa " _
        '                                  & " from (((select * from vDMDICHVU  WHERE  Doituong  like '%" & MaDoituong & "%'  and Noitru_Ngoaitru >1 and Khongsudung = 0 ) a  INNER join DMLOAIDICHVU b on a.LoaiDichVu = b.MaloaiDichVu) " _
        '                                   & " LEFT JOIN DMDICHVU_KHOA c ON a.MaDichVu=c.MaDichVu) " _
        '                                   & " LEFT JOIN DMKHOAPHONG d ON c.MaKhoa=d.MaKhoa " _
        '                                   & " WHERE(b.NoiTru_NgoaiTru > 1 And KhongSuDung = 0)  ORDER BY MaLoaiDichVu, ThutuChonChidinh, ThutuChonDichvu", DonGia) 'MaLoaiDichVu

        'Load dich vu theo phieu cd
        Dim Sql As String = String.Format("  SELECT MaLoaiDichVu,TenLoaiDichVu,a.MaDichVu,TenDichVu,DVT,{0} TenLoaiphieuCD,0 as Chon,c.MaLoaiphieuCD " _
                                          & " from (((select * from vDMDICHVU  WHERE  Doituong  like '%" & MaDoituong & "%'  and Noitru_Ngoaitru >1 and Khongsudung = 0 ) a  INNER join DMLOAIDICHVU b on a.LoaiDichVu = b.MaloaiDichVu) " _
                                           & " LEFT JOIN DMDICHVU_PHIEUCD c ON a.MaDichVu=c.MaDichVu) " _
                                           & " LEFT JOIN DMLOAIPHIEUCHIDINH d ON c.MaLoaiphieuCD=d.MaLoaiphieuCD  " _
                                           & " WHERE(b.NoiTru_NgoaiTru > 1 And KhongSuDung = 0)  ORDER BY MaLoaiDichVu, ThutuChonChidinh, ThutuChonDichvu", DonGia) 'MaLoaiDichVu

        SQLCmd.CommandText = Sql
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()

        Dim row As Integer = 1
        With fgDichVu
            .Rows.Count = 1
            While dr.Read()
                .Rows.Add()
                For i = 0 To dr.FieldCount - 1
                    fgDichVu(row, i) = dr.GetValue(i)
                Next
                If dr("MaLoaiphieuCD").ToString() = "" Then
                    fgDichVu.Item(row, "MaLoaiphieuCD") = "CD" 'HeThong.MaKhoaphong
                    fgDichVu.Item(row, "TenLoaiphieuCD") = "Phiếu chỉ định" 'HeThong.TenKhoaphong
                End If
                row = row + 1
            End While
            dr.Close()
            SQLCmd.Dispose()
            dr = Nothing
            .Tree.Column = .Cols("TenDichVu").Index
            .Subtotal(AggregateEnum.None, 0, 1, 0, "{0}")
            For i = 0 To fgDichVu.Rows.Count - 1
                If fgDichVu.Rows(i).IsNode Then .Rows(i).Node.Expanded = False
            Next
            .Cols("TenDichVu").Width = 280
            .Cols("DVT").Width = 40
            .AutoSizeRows(0, 0, .Rows.Count - 1, .Cols.Count - 1, 1, AutoSizeFlags.None)
            '.AutoSizeCols(0, .Cols.Count - 1, 1)

            .Redraw = True
        End With
    End Sub
    Private Sub Load_DichVu(ByVal MaDoituong As String, ByVal TenDichVu As String)
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim DonGia As String = ""
        Dim i As Integer
        'If MaDoituong_LanLoad_truoc = MaDoituong Then Exit Sub
        MaDoituong_LanLoad_truoc = MaDoituong
        If MaDoituong.Substring(0, 1) = "1" Then DonGia = "DonGiaBHYT as DonGia," Else DonGia = "DonGia  as DonGia,"
        'Load dich vu theo Loaidichvu
        'Dim Sql As String = String.Format("  SELECT MaLoaiDichVu ,TenLoaiDichVu,a.MaDichVu,TenDichVu,DVT,{0} TenKhoa,0 as Chon,c.MaKhoa " _
        '                                   & " from (((select * from vDMDICHVU  WHERE  Doituong  like '%" & MaDoituong & "%'  and Noitru_Ngoaitru >1 and Khongsudung = 0 ) a  INNER join DMLOAIDICHVU b on a.LoaiDichVu = b.MaloaiDichVu) " _
        '                                   & " LEFT JOIN DMDICHVU_KHOA c ON a.MaDichVu=c.MaDichVu) " _
        '                                   & " LEFT JOIN DMKHOAPHONG d ON c.MaKhoa=d.MaKhoa " _
        '                                   & " WHERE(b.NoiTru_NgoaiTru > 1 And KhongSuDung = 0) and tendichvu like N'%" & TenDichVu & "%' ORDER BY MaLoaiDichVu,ThutuChonChidinh, ThutuChonDichvu", DonGia) 'MaLoaiDichVu
        'Load dich vu theo phieu cd
        Dim Sql As String = String.Format("  SELECT MaLoaiDichVu ,TenLoaiDichVu,a.MaDichVu,TenDichVu,DVT,{0} TenLoaiphieuCD,0 as Chon,c.MaLoaiphieuCD " _
                                                  & " from (((select * from vDMDICHVU  WHERE  Doituong  like '%" & MaDoituong & "%'  and Noitru_Ngoaitru >1 and Khongsudung = 0 ) a  INNER join DMLOAIDICHVU b on a.LoaiDichVu = b.MaloaiDichVu) " _
                                                  & " LEFT JOIN DMDICHVU_PHIEUCD c ON a.MaDichVu=c.MaDichVu) " _
                                                  & " LEFT JOIN DMLOAIPHIEUCHIDINH d ON c.MaLoaiphieuCD=d.MaLoaiphieuCD  " _
                                                  & " WHERE(b.NoiTru_NgoaiTru > 1 And KhongSuDung = 0) and tendichvu like N'%" & TenDichVu & "%' ORDER BY MaLoaiDichVu,ThutuChonChidinh, ThutuChonDichvu", DonGia) 'MaLoaiDichVu
        SQLCmd.CommandText = Sql
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()

        Dim row As Integer = 1
        With fgDichVu
            .Rows.Count = 1
            While dr.Read()
                .Rows.Add()

                For i = 0 To dr.FieldCount - 1
                    fgDichVu(row, i) = dr.GetValue(i)
                Next
                'If dr("MaKhoa").ToString() = "" Then
                '    fgDichVu(row, "MaLoaiphieuCD") = "CD" 'HeThong.MaKhoaphong
                '    fgDichVu(row, "TenLoaiphieuCD") = "Phiếu chỉ định" 'HeThong.TenKhoaphong
                'End If

                row = row + 1
            End While
            dr.Close()
            SQLCmd.Dispose()
            dr = Nothing
            .Tree.Column = .Cols("TenDichVu").Index
            .Subtotal(AggregateEnum.None, 0, 1, 0, "{0}")
            If TenDichVu.Length = 0 Then
                For i = 0 To fgDichVu.Rows.Count - 1
                    If fgDichVu.Rows(i).IsNode Then .Rows(i).Node.Expanded = False
                Next
            End If

            .Cols("TenDichVu").Width = 280
            .Cols("DVT").Width = 40
            .AutoSizeRows(0, 0, .Rows.Count - 1, .Cols.Count - 1, 1, AutoSizeFlags.None)
            '.AutoSizeCols(0, .Cols.Count - 1, 1)

            .Redraw = True
        End With
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

        ContextMenuStrip1.DropShadowEnabled = True
    End Sub


    Private Sub cmdInPK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim rpt As New rptPhieuKhambenh
        'If txtMakhambenh.Text.Trim() = "" Then Exit Sub
        'LuuPhieukham(txtMaphieukham.Text)
        ''If cmbXutri.SelectedIndex <> 2 And cmbXutri.SelectedIndex <> 5 And cmbXutri.SelectedIndex <> 6 And cmbXutri.SelectedIndex <> 9 Then
        ''    MsgBox("Chỉ in phiếu khám bệnh khi Kê đơn - Nhập viện - Chuyển viện - Chuyển khám chuyên khoa", MsgBoxStyle.Critical, "Messages!")
        ''    Exit Sub
        ''End If
        'rpt.lblBuongso.Text = TenKhoaphong
        'rpt.lblDoituong.Text = cmbDoituong.Text
        'rpt.txtTenbenhnhan.Text = txtTenbenhnhan.Text
        'If cmbDoituong.SelectedValue = "1" Then ' Bào hiểm
        '    rpt.lblCapbac_Sothe.Text = "Thẻ BHYT:"
        '    rpt.txtCapbac_Sothe.Text = lblSotheBHYT.Text
        'Else
        '    rpt.lblCapbac_Sothe.Text = "Cấp bậc"
        '    rpt.txtCapbac_Sothe.Text = cmbCapbac.Text
        'End If
        'rpt.txtDiachi.Text = txtNoicongtac.Text
        'rpt.txtGioitinh.Text = cmbGioitinh.Text
        'rpt.txtMavach.Text = txtMakhambenh.Text
        'rpt.txtNamsinh.Text = txtTuoi.Text
        'rpt.txtYeucaukham.Text = TenDVK
        'rpt.lblLamsang.Text = txtTrieuchung.Text
        'rpt.txtMach.Text = txtMach.Text
        'rpt.txtNhietdo.Text = txtNhietdo.Text
        'rpt.txtHuyetap.Text = txtHuyetap_T.Text + " / " + txtHuyetap_D.Text
        'rpt.lblChandoan.Text = txtChandoan.Text
        'rpt.TextBox1.Text = txtMaBC.Text
        'rpt.lblNgaykham.Text = String.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", GetSrvDate())
        'Dim Xutri As String = ""
        'Select Case cmbXutri.SelectedIndex
        '    Case 2 ' Ke don
        '        Xutri = "Điều trị ngoại trú: Kê đơn"
        '    Case 3 ' Cho về
        '        Xutri = "Cho về"
        '    Case 4 ' Chuyển PK
        '        Xutri = "Chuyển phòng khám: " + cmbChuyenPK_Phong.Text.Trim()
        '    Case 5 ' Nhap vien
        '        Xutri = "Nhập viện: Vào khoa " + cmbKhoa_Nhapvien.Text.Trim()
        '    Case 6 ' Chuyen vien
        '        Xutri = "Chuyển viện: " + txtCV_Benhvien.Text.Trim()
        '    Case 7 ' Hẹn TT
        '        Xutri = "Hẹn thủ thuật."
        '    Case 9 ' Chuyen kham chuyen khoa
        '        Xutri = "Chuyển khám chuyên khoa: " + cmbKhoa_Nhapvien.Text.Trim()
        'End Select
        'rpt.lblXutri.Text = Xutri
        'rpt.lblLoidan.Text = txtLoidan_Phieukham.Text ' txtLoidan.Text
        'rpt.SqlstrDT = "Select * from tblKhambenh_Donthuoc where Makhambenh = '" & txtMakhambenh.Text & "' order by STT"
        'rpt.lblTenBS.Text = Tendaydu
        'rpt.Run()
        'rpt.Document.Print(False, True, False)
        ''rpt.Show()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Kt_codonthuoc_Pkhac()
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try

            If Trim(txtMakhambenh.Text.Trim) = "" Then Exit Sub
            SQL = "Select *  FROM tblKHAMBENH_CHIDINH where left(MaphieuCD,2) = 'DT' and MaKhambenh = '" & txtMakhambenh.Text & "' " _
            & " and KhoaCD <> '" & MaKhoaphong & "' "
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")

            Cmd.Dispose()
            Adap.Dispose()
            ds.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub grdTiensuKB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTiensuKB.DoubleClick
        FillData(grdTiensuKB.Item(grdTiensuKB.Row, 1))
    End Sub
    Private Function Kt_Thuocdake(ByVal MaKB As String, ByVal Mathuoc As String, ByRef Madon As String) As Boolean
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try
            Kt_Thuocdake = False
            Madon = ""
            If Trim(MaKB) = "" Or Trim(Mathuoc) = "" Then Exit Function
            SQL = String.Format("Select *  FROM tblKHAMBENH_Donthuoc where MaKhambenh = '{0}' and Mathuoc = '{1}'  ", MaKB, Mathuoc)
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                Kt_Thuocdake = True
                Madon = ds.Tables("Hoso").Rows(0).Item("MaphieuCD").ToString
            End If
            Cmd.Dispose()
            Adap.Dispose()
            ds.Dispose()
        Catch ex As Exception
        End Try
    End Function

    Private Sub cmdLaydontruoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If cmbDoituong.SelectedValue <> "1" Then Exit Sub
        'Try
        '    Dim frm As New frmDSDonthuocTruoc
        '    frm.TheBHYT = lblSotheBHYT.Text
        '    frm.MdiParent = FrmMain_KB
        '    frm.Show()
        '    frm.TopMost = True
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub panTieuphau_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub lblThemVaoSoTayDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblThemVaoSoTayDT.Click
        'Dim MoTa As String = InputBox("Mô tả mặt bệnh:", "Thêm sổ tay chỉ định", "")
        Dim MoTa As String = InputBox("Disease description:", "Add assignment manual", "")
        If (MoTa = "") Then
            MessageBox.Show("Disease name cannot be left blank!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim ID_SoCD As String = "0"
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim trn As System.Data.SqlClient.SqlTransaction
        trn = Cn.BeginTransaction()
        SQLCmd.Transaction = trn
        Try

            SQLCmd.CommandText = String.Format("INSERT INTO tblSOTAYDONTHUOC(Bacsi,Matbenh) VALUES ('{0}',N'{1}')    SELECT Max(ID_SotayDonthuoc) From tblSOTAYDONTHUOC", TenDangNhap, MoTa.Replace("'", "''"))
            ID_SoCD = SQLCmd.ExecuteScalar().ToString()
            SQLCmd.CommandText = "DELETE FROM tblSOTAYDONTHUOC_CT WHERE ID_SotayDonthuoc=" & ID_SoCD
            SQLCmd.ExecuteNonQuery()
            Dim i As Integer
            For i = 1 To grv_DonThuoc.RowCount - 2
                SQLCmd.CommandText = String.Format("INSERT INTO tblSOTAYDONTHUOC_CT (ID_SotayDonthuoc, ThuocID,TenThuoc,DVT,SoLuong,CachDung,ThuTu,Thuocmua) " _
                                        & " VALUES ({0},N'{1}',N'{2}',N'{3}',{4},'{5}',{6},0)", ID_SoCD, grv_DonThuoc.GetRowCellValue(i, "ThuocID").ToString(), grv_DonThuoc.GetRowCellDisplayText(i, "ThuocID").ToString(), grv_DonThuoc.GetRowCellValue(i, "DVT").ToString(), Convert.ToInt32(grv_DonThuoc.GetRowCellValue(i, "SoLuong").ToString()), grv_DonThuoc.GetRowCellValue(i, "CachDung").ToString(), i)
                SQLCmd.ExecuteNonQuery()
            Next
            trn.Commit()
        Catch ex As Exception
            trn.Rollback()
            MessageBox.Show("There was an error writing data - " & ex.Message, "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLCmd.Dispose()
            trn.Dispose()
        End Try

        'Load lai so tay don thuoc
        DM_SoTayDonThuoc()
    End Sub

    Private Sub txtMakhambenh_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMakhambenh.KeyUp

        If e.KeyCode = Keys.Enter Then
            AutoFill_Makhambenh(txtMakhambenh)
            If Len(Trim(txtMakhambenh.Text)) = 10 Then
                FillData(txtMakhambenh.Text)  '"PK" +
                txtTrieuchung.Focus()
            End If
        End If
    End Sub

    Private Sub lblXoaDonSoTay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblXoaDonSoTay.Click
        Dim frmsotayDT As New frmDS_SoTayDonThuoc
        frmsotayDT.ShowDialog()
        'Load lai so tay don thuoc sau khi xoa
        DM_SoTayDonThuoc()
    End Sub

    Private Sub btnLuuBenhNhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuuBenhNhan.Click
        If txtLienHe.Text.Trim = "" Or txtTenbenhnhan.Text.Trim = "" Then
            Exit Sub
        End If
        '1..Luu thong tin hanh chinh
        Them_ThongtinHC()
        '2..Luu thong tin don thuoc
        Madonthuoc_Sua = ""
        MaPhieuCD = ""
        LuuDonthuoc(txtMakhambenh.Text.Trim(), Madonthuoc_Sua)
        LuuDichVu(txtMakhambenh.Text.Trim(), MaPhieuCD)
        MessageBox.Show("Save data successfully!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information)
        cmdKedon.Enabled = True
        btnLuuBenhNhan.Enabled = False
        btnInPhieuThuoc.Enabled = True
        btnHuyThaoTac.Enabled = False
        btnSuaThongTin.Enabled = True
        '3. Load danh sach tien su kham benh
        Fill_DSKhamtruoc(txtMabenhnhan.Text)
    End Sub

    Private Sub btnSuaThongTin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuaThongTin.Click
        If txtLienHe.Text.Trim = "" Or txtTenbenhnhan.Text.Trim = "" Then
            Exit Sub
        End If
        LuuThongtinHC()
        LuuDonthuoc(txtMakhambenh.Text.Trim(), Madonthuoc_Sua)
        LuuDichVu(txtMakhambenh.Text.Trim(), MaPhieuCD)
        MessageBox.Show("Save data successfully!", "Messages")
        btnLuuBenhNhan.Enabled = False
        btnSuaThongTin.Enabled = True
        btnInPhieuThuoc.Enabled = True
    End Sub

    Private Sub btnInPhieuThuoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInPhieuThuoc.Click
        If (Madonthuoc_Sua = "") Then Exit Sub

        Dim NgayHT As Date
        Dim frm As New frmPreview
        frm.Tenbenhnhan = txtTenbenhnhan.Text
        frm.Namsinh = txtTuoi.Text
        frm.Gioitinh = cmbGioitinh.Text

        frm.Diachi = IIf(txtDiachi.Text.Trim() = "", "                                      ", txtDiachi.Text)
        frm.lblDIachi_Capbac = "Địa chỉ: "
        frm.Ketluanbenh = txtChandoanSB.Text
        frm.Loidan = txtLoidan.Text
        NgayHT = GetSrvDate()
        frm.Ngaydonthuoc = String.Format("{0:HH:mm}, {0:MM/dd/yyyy}", NgayHT) '"Ngày " + Format(NgayHT, "dd") + " tháng " + Format(NgayHT, "MM") + " năm " + Format(NgayHT, "yyyy")
        frm.Bacsy = cmbDM_BacSy.Text.ToString()
        frm.taikham = String.Format("{0:MM/dd/yyyy}", dtTaiKham.Value) '"........ Giờ..........Ngày " + Format(dtTaiKham.Value, "dd") + " tháng " + Format(dtTaiKham.Value, "MM") + " năm " + Format(dtTaiKham.Value, "yyyy")
        frm.SQL_str = "Select Mabenhnhan, Makhambenh,MaphieuCD, STT,('   ' + tenthuoc) as tenthuoc,TenGoc,Hamluong,DVT, " _
        & " Soluong, ('   ' + Cachdung) as Cachdung from tblKhambenh_Donthuoc " _
        & " where MaphieuCD = '" & Madonthuoc_Sua & "' and MaKhambenh =  '" & txtMakhambenh.Text & "' order by Stt" ' and Thuocmua= 0"
        frm.Goi = "Don thuoc"
        'If chkXemTruocKhiInDonThuoc.Checked Then
        'frm.ShowDialog()
        'Else
        frm.arViewer_Load(Nothing, Nothing)
        '    frm.arViewer.Document.Print(False, True, False)
        '    'frm.arViewer.Document.Print(False, True, False)
        'End If

    End Sub

    Private Sub btnThemLanKham_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThemLanKham.Click
        Madonthuoc_Sua = ""
        MaPhieuCD = ""
        'grdSoanDonthuoc.Rows.Count = 1
        lblChitiet_Donthuoc.Tag = ""
        txtTrieuchung.Text = ""
        txtChandoanSB.Text = ""
        cmdKedon.Enabled = False
        btnThemLanKham.Enabled = False
        btnLuuBenhNhan.Enabled = True
        btnHuyThaoTac.Enabled = True
        btnSuaThongTin.Enabled = False
        btnInPhieuThuoc.Enabled = False
        lblTienCLS.Text = "0"
        lblTienThuoc.Text = "0"
        lblTongCP.Text = "0"

        For i = grv_DonThuoc.RowCount - 1 To 0 Step -1
            grv_DonThuoc.DeleteRow(i)
        Next
        For i = grv_DichVu.RowCount - 1 To 0 Step -1
            grv_DichVu.DeleteRow(i)
        Next
        booThemdon = True
        txtTrieuchung.Focus()
    End Sub

    Private Sub btnHuyThaoTac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHuyThaoTac.Click
        cmdDanhsachBN.Enabled = True
        cmdKedon.Enabled = True
        btnThemLanKham.Enabled = False
        btnLuuBenhNhan.Enabled = False
        btnSuaThongTin.Enabled = False
        btnHuyThaoTac.Enabled = False
        btnInPhieuThuoc.Enabled = False
        SetEmpty()
        'grBenhnhan.Enabled = False
        txtTenbenhnhan.Enabled = False
        txtTuoi.Enabled = False
        txtDiachi.Enabled = False
        txtNgaykham.Enabled = False
        cmbGioitinh.Enabled = False
        TabControl2.Enabled = False
    End Sub

    Private Sub gle_DMThuoc_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gle_DMThuoc.EditValueChanged

    End Sub

    Private Sub grv_DonThuoc_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grv_DonThuoc.CellValueChanged
        If (e.Column.FieldName = "ThuocID") Then
            Dim dr As DataRowView = gle_DMThuoc.GetRowByKeyValue(e.Value)
            Dim str As String = dr.Item("DVT").ToString()

            Dim sdongia As Integer = Integer.Parse(dr.Item("DonGia").ToString())
            If (grv_DonThuoc.GetRowCellValue(e.RowHandle, "STT").ToString() = "") Then
                grv_DonThuoc.SetRowCellValue(e.RowHandle, "STT", grv_DonThuoc.RowCount)
            End If
            grv_DonThuoc.SetRowCellValue(e.RowHandle, "DVT", str) ';
            grv_DonThuoc.SetRowCellValue(e.RowHandle, "DonGia", sdongia)
            grv_DonThuoc.SetRowCellValue(e.RowHandle, "SoLuong", 1)


        ElseIf e.Column.FieldName = "SoLuong" Then
            Dim sl As Integer = 0
            If grv_DonThuoc.GetRowCellValue(e.RowHandle, "SoLuong").ToString() <> "" Then
                sl = Convert.ToInt32(grv_DonThuoc.GetRowCellValue(e.RowHandle, "SoLuong").ToString())
            End If

            Dim dg As Integer = 0
            If grv_DonThuoc.GetRowCellValue(e.RowHandle, "DonGia").ToString() <> "" Then
                dg = Convert.ToInt32(grv_DonThuoc.GetRowCellValue(e.RowHandle, "DonGia").ToString())
            End If
            grv_DonThuoc.SetRowCellValue(e.RowHandle, "ThanhTien", sl * dg)
            grv_DonThuoc.SelectCell(e.RowHandle, grv_DonThuoc.Columns("SoLuong"))
            tienThuoc = tienThuoc + (sl * dg)
            tongTien = tienDV + tienThuoc
            lblTongCP.Text = String.Format("{0:#,#}", tongTien)
            lblTienCLS.Text = String.Format("{0:#,#}", tienDV)
            lblTienThuoc.Text = String.Format("{0:#,#}", tienThuoc)
        End If
    End Sub

    Private Sub grv_DichVu_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grv_DichVu.KeyDown
        If e.KeyCode = Keys.Delete Then
            If grv_DichVu.RowCount < 2 Then
                Exit Sub
            End If
            ' Cho xoa luon trong csdl

            If MaPhieuCD = "" Then
                grv_DichVu.DeleteRow(grv_DichVu.FocusedRowHandle)
            Else
                If MessageBox.Show("Are you sure you want to delete the selected service?", "Messages", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim MaDV As String = grv_DichVu.GetFocusedRowCellValue("MaDichVu").ToString()
                    Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
                    SQLCmd.Transaction = trn
                    Try
                        SQLCmd.CommandText = String.Format("DELETE FROM tblKhamBenh_DichVu WHERE MaPhieuCD ='{0}' AND MaDichVu='{1}'", MaPhieuCD, MaDV)
                        SQLCmd.ExecuteNonQuery()
                        If grv_DichVu.RowCount < 1 Then
                            SQLCmd.CommandText = String.Format("DELETE FROM tblKhamBenh_ChiDinh WHERE MaPhieuCD ='{0}'", MaPhieuCD)
                            SQLCmd.ExecuteNonQuery()
                        End If
                    Catch ex As Exception
                        MessageBox.Show("There was an error deleting data - " & ex.Message, "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        SQLCmd.Dispose()
                    End Try
                End If
                grv_DichVu.DeleteRow(grv_DichVu.FocusedRowHandle)
                TinhTongChiPhi()
            End If
        End If
    End Sub

    Private Sub grv_DichVu_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grv_DichVu.CellValueChanged
        If (e.Column.FieldName = "MaDichVu") Then
            Dim dr As DataRowView = Gle_DichVu.GetRowByKeyValue(e.Value)
            Dim str As String = dr.Item("DVT").ToString()

            Dim sdongia As Integer = Integer.Parse(dr.Item("DonGia").ToString())
            If (grv_DichVu.GetRowCellValue(e.RowHandle, "STT").ToString() = "") Then
                grv_DichVu.SetRowCellValue(e.RowHandle, "STT", grv_DichVu.RowCount)
            End If
            grv_DichVu.SetRowCellValue(e.RowHandle, "DVT", str)
            grv_DichVu.SetRowCellValue(e.RowHandle, "DonGia", sdongia)
            grv_DichVu.SetRowCellValue(e.RowHandle, "SoLuong", 1)

        ElseIf e.Column.FieldName = "SoLuong" Then
            Dim sl As Integer = 0
            If grv_DichVu.GetRowCellValue(e.RowHandle, "SoLuong").ToString() <> "" Then
                sl = Convert.ToInt32(grv_DichVu.GetRowCellValue(e.RowHandle, "SoLuong").ToString())
            End If

            Dim dg As Integer = 0
            If grv_DichVu.GetRowCellValue(e.RowHandle, "DonGia").ToString() <> "" Then
                dg = Convert.ToInt32(grv_DichVu.GetRowCellValue(e.RowHandle, "DonGia").ToString())
            End If
            grv_DichVu.SetRowCellValue(e.RowHandle, "ThanhTien", sl * dg)
            grv_DichVu.SelectCell(e.RowHandle, grv_DichVu.Columns("SoLuong"))
            tienDV = tienDV + (sl * dg)
            tongTien = tienThuoc + tienDV
            lblTongCP.Text = String.Format("{0:#,#}", tongTien)
            lblTienCLS.Text = String.Format("{0:#,#}", tienDV)
            lblTienThuoc.Text = String.Format("{0:#,#}", tienThuoc)
        End If
    End Sub

    Private Sub grv_DonThuoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grv_DonThuoc.KeyDown
        If e.KeyCode = Keys.Delete Then
            If grv_DonThuoc.RowCount < 2 Then
                Exit Sub
            End If
            ' Cho xoa luon trong csdl

            If Madonthuoc_Sua = "" Then
                grv_DonThuoc.DeleteRow(grv_DonThuoc.FocusedRowHandle)
            Else
                If MessageBox.Show("Are you sure you want to delete the selected medication?", "Messages", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim MaDV As String = grv_DonThuoc.GetFocusedRowCellValue("ThuocID").ToString()
                    Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
                    SQLCmd.Transaction = trn
                    Try
                        SQLCmd.CommandText = String.Format("DELETE FROM tblKhamBenh_DonThuoc WHERE MaPhieuCD ='{0}' AND MaThuoc='{1}'", Madonthuoc_Sua, MaDV)
                        SQLCmd.ExecuteNonQuery()
                        If grv_DonThuoc.RowCount < 1 Then
                            SQLCmd.CommandText = String.Format("DELETE FROM tblKhamBenh_ChiDinh WHERE MaPhieuCD ='{0}'", Madonthuoc_Sua)
                            SQLCmd.ExecuteNonQuery()
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Có lỗi khi xóa dữ liệu - " & ex.Message, "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        SQLCmd.Dispose()
                    End Try
                    grv_DonThuoc.DeleteRow(grv_DonThuoc.FocusedRowHandle)
                    TinhTongChiPhi()
                End If
            End If
        End If
    End Sub

    Private Sub Gle_DichVu_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gle_DichVu.EditValueChanged

    End Sub

    Private Sub cmbSoTayChiDinh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSoTayChiDinh.TextChanged
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Dim temp As String = ""
        Try
            For i = grv_DichVu.RowCount - 1 To 0 Step -1
                grv_DichVu.DeleteRow(i)
            Next

            SQL = "SELECT a.MaDichVu,1 as STT,b.TenDichVu, b.DVT,isnull(b.DonGia,0) as DonGia,a.Soluong as SoLuong,(isnull(b.DonGia,0) * a.Soluong) as ThanhTien " _
            & " FROM  tblSOTAYCHIDINH_CHITIET a left outer join   DBO.DMDichVu b  on a.MaDichVu = b.MaDichVu " _
            & " where a.ID_SoCD =  " & cmbSoTayChiDinh.SelectedValue & "  order by a.MaDichVu"
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "SoTay")
            If ds.Tables("SoTay").Rows.Count > 0 Then
                GridControl1.DataSource = ds.Tables("SoTay")
                grv_DichVu.SetRowCellValue(i, "STT", i + 1)
            End If
            TinhTongChiPhi()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TinhTongChiPhi()
        'Tinh tien thuoc
        tienThuoc = 0
        For i = 0 To grv_DonThuoc.RowCount - 2
            tienThuoc = tienThuoc + Convert.ToInt32(grv_DonThuoc.GetRowCellValue(i, "ThanhTien").ToString())
        Next

        'Tinh tien DV
        tienDV = 0
        For i = 0 To grv_DichVu.RowCount - 2
            tienDV = tienDV + Convert.ToInt32(grv_DichVu.GetRowCellValue(i, "ThanhTien").ToString())
        Next
        tongTien = tienDV + tienThuoc
        lblTongCP.Text = String.Format("{0:#,#}", tongTien)
        lblTienCLS.Text = String.Format("{0:#,#}", tienDV)
        lblTienThuoc.Text = String.Format("{0:#,#}", tienThuoc)
    End Sub
    Private Sub lblSoTayDichVu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSoTayDichVu.Click
        'Dim MoTa As String = InputBox("Mô tả mặt bệnh:", "Thêm sổ tay chỉ định", "")
        Dim MoTa As String = InputBox("Disease description:", "Add assignment manual", "")
        If (MoTa = "") Then
            MessageBox.Show("Disease name cannot be left blank!", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim ID_SoCD As String = "0"
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim trn As System.Data.SqlClient.SqlTransaction
        trn = Cn.BeginTransaction()
        SQLCmd.Transaction = trn
        Try

            SQLCmd.CommandText = String.Format("INSERT INTO tblSOTAYCHIDINH(ID_SoCD,Uname,Mota) VALUES ((SELECT (isnull(Max(ID_SoCD),0)+1) From tblSOTAYCHIDINH),'{0}',N'{1}')    SELECT Max(ID_SoCD) From tblSOTAYCHIDINH", TenDangNhap, MoTa.Replace("'", "''"))
            ID_SoCD = SQLCmd.ExecuteScalar().ToString()
            SQLCmd.CommandText = "DELETE FROM tblSOTAYCHIDINH_CHITIET WHERE ID_SoCD=" & ID_SoCD
            SQLCmd.ExecuteNonQuery()
            Dim i As Integer
            For i = 0 To grv_DichVu.RowCount - 2
                SQLCmd.CommandText = String.Format("INSERT INTO tblSOTAYCHIDINH_CHITIET (ID_SoCD, MaDichVu,SoLuong,MaLoaiPhieuCD) " _
                                        & " VALUES ({0},N'{1}',{2},N'{3}')", ID_SoCD, grv_DichVu.GetRowCellValue(i, "MaDichVu").ToString(), Convert.ToInt32(grv_DichVu.GetRowCellValue(i, "SoLuong").ToString()), "CD")
                SQLCmd.ExecuteNonQuery()
            Next
            trn.Commit()
        Catch ex As Exception
            trn.Rollback()
            MessageBox.Show("There was an error writing data - " & ex.Message, "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLCmd.Dispose()
            trn.Dispose()
        End Try

        'Load lai so tay dich vu
        DM_SoTayDichVu()
    End Sub

    Private Sub lblXoaSoTayDichVu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblXoaSoTayDichVu.Click
        Dim frmsotayCD As New frmDS_SoTayChiDinh
        frmsotayCD.ShowDialog()
        'Load lai so tay don thuoc sau khi xoa
        DM_SoTayDichVu()
    End Sub

    Private Sub btn_ThuPhi_Click(sender As Object, e As EventArgs) Handles btn_ThuPhi.Click
        Dim frmTPDV As New frmThuPhiDichVu
        frmTPDV.txtMaKhambenh.Text = txtMakhambenh.Text.Trim
        frmTPDV.ShowDialog()
    End Sub

    Private Sub txtLienHe_KeyUp(sender As Object, e As KeyEventArgs) Handles txtLienHe.KeyUp

    End Sub

    Private Sub txtLienHe_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLienHe.KeyDown
        If e.KeyCode = Keys.Enter Then
            FillData_ByPhone(txtLienHe.Text.Trim)
        End If
    End Sub

    Private Sub btnPhieuThu_Click(sender As Object, e As EventArgs) Handles btnPhieuThu.Click
        Dim i
        Dim rptPT_InNhiet As New rptPhieuthu_InNhiet
        Dim rpt_InA5 As New rptPhieuthu_A5
        Dim ThoigianIn As Date
        Try
            ThoigianIn = GetSrvDate()
            rpt_InA5.SqlStr = "select N'" & txtTenbenhnhan.Text & "' As Tenbenhnhan, (N'' + cast (c.Namsinh as nvarchar)) as Namsinh, b.Diachi," _
            & " (N'' + a.Sobienlai) as Sobienlai,a.Miengiam,d.tendichvu,(a.Soluong*a.Dongia) as TongTien,(a.Soluong*a.Miengiam) as Miengiam,ThanhTien from viewPHIEUTHANHTOAN_CT a " _
            & " left join tblKhambenh b on a.Makhambenh = b.Makhambenh " _
            & " left join tblBenhnhan c on b.Mabenhnhan = c.Mabenhnhan " _
            & " left join vDMDICHVU d on a.Madichvu = d.Madichvu  " _
            & " where b.MaKhambenh = '" & txtMakhambenh.Text.Trim & "' order by d.NhomVP, d.Madichvu"
            '' IN Nhiet
            'rptPT_InNhiet.txtNgaythang.Text = String.Format("{0:HH:mm}, ngày {0:dd/MM/yyyy}", ThoigianIn)
            'rptPT_InNhiet.Run(True)
            'If chkXemBienlai.Checked Then
            '    rptPT_InNhiet.Show()
            'Else
            '    For i = 1 To Val(txtSolien.Value)
            '        rptPT_InNhiet.Document.Print(False, False, False)
            '    Next
            'End If

            '' In Thuong
            rpt_InA5.txtNgaythang.Text = String.Format("{0:HH:mm}, {0:dd/MM/yyyy}", ThoigianIn)
            rpt_InA5.Run(True)
            'If chkXemBienlai.Checked Then
            rpt_InA5.Show()
            'Else
            '    For i = 1 To Val(txtSolien.Value)
            '        rpt_InA5.Document.Print(False, False, False)
            '    Next
            'End If
            'panIn.Visible = False
            'cmdThem.Focus()
            'SendKeys.Send("ESC")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub slu_SoDienThoai_EditValueChanged(sender As Object, e As EventArgs) Handles slu_SoDienThoai.EditValueChanged
        FillData_ByPhone(slu_SoDienThoai.EditValue.ToString)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_Grid(Me, grv_DichVu, "vi", Cn)
        mdlFunction.Save_Text_Grid(Me, grv_DonThuoc, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdTiensuKB, "vi", Cn)
    End Sub

    Private Sub grdTiensuKB_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdTiensuKB.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("You definitely want to delete the selected examination information?", "Messages", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim strMaKhamBenh As String = grdTiensuKB.Item(grdTiensuKB.Row, 1)
                Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
                Dim trn As System.Data.SqlClient.SqlTransaction
                trn = Cn.BeginTransaction()
                SQLCmd.Transaction = trn
                Try
                    SQLCmd.CommandText = " DELETE FROM tblKhamBenh_DichVu WHERE makhambenh= '" & strMaKhamBenh & "'" _
                                         & " DELETE FROM tblKhamBenh_DonThuoc WHERE makhambenh= '" & strMaKhamBenh & "'" _
                                         & " DELETE FROM tblKhamBenh_ChiDinh WHERE makhambenh= '" & strMaKhamBenh & "'" _
                                         & " DELETE FROM tblKhamBenh WHERE makhambenh= '" & strMaKhamBenh & "'"
                    SQLCmd.ExecuteNonQuery()
                    trn.Commit()
                    Fill_DSKhamtruoc(txtMabenhnhan.Text)
                    SetEmpty()

                Catch ex As Exception
                    trn.Rollback()
                    MessageBox.Show("There was an error writing data - " & ex.Message, "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    SQLCmd.Dispose()
                    trn.Dispose()
                End Try
            End If
        End If
    End Sub
End Class
