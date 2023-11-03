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
Public Class frmTiepdon
    'Trạng thái ban đầu: Trên form có các nút: Thêm, sửa , Xóa, tìm kiếm, Thoát, Ghi, Không ghi , các nút đậm hiển thị 
    '1. Nếu bấm Thêm (hoặc F5): Hiển thị nút Không lưu, các nút khác ẩn. Nếu bấm Không ghi thì SetEmpty-> Trạng thái ban đầu
    '1.1. Nếu không nhập mã bệnh nhân thì  thêm mới hoàn toàn
    '- Nhập lần lượt các thông tin, bấm nút (+) để thêm lượt khám (bao gồm thêm bệnh nhân, lần khám, dịch vụ khám, chi phí) - > Trạng thái ban đầu.
    '- Nếu muốn thêm dịch vụ khám nữa: nhập dịch vụ, phòng khám , bấm (+)
    '- > Trạng thái ban đầu.
    '1.2. Nếu nhập mã bệnh nhân: Khi validated kiểm tra xem mã đã có chưa
    '1.2.1. Nếu chưa có
    '- Message: Mã bệnh nhân chưa có
    '- Xóa trắng mã bệnh nhân
    '- Tiếp tục nhập như 1.1
    '- > Trạng thái ban đầu.
    '1.2.2. Nếu đã có: 
    'Kiểm tra ngày khám cuối cùng  (có trường hợp nào ko có ngày khám cuối ko?)
    '1.2.2.1. Nếu ngày khám cuối = ngày hiện tại: (Trường hợp bệnh nhân đã đăng ký 1 dịch vụ khám trong ngày)
    '-  Message: Bệnh nhân đã đăng ký khám trong ngày
    '-  Chuyển về hiển thị Thêm Sửa Xóa
    '-  Load các dịch vụ đã khám trong ngày
    '-  Nếu bệnh nhân muốn thêm dịch vụ thì bấm chọn dịch vụ, phòng khám và bấm nút (+): Khi đó chỉ thêm dịch vụ khám
    '- > Trạng thái ban đầu.
    '1.2.2.2. Nếu ngày khám cuối < ngày hiện tại: (Trường hợp bệnh nhân đã từng đăng ký khám trước đó)
    '-  Ko cần Message 
    '-  Vẫn để nút Ghi – Không ghi
    '-  Load các thông tin bệnh nhân, lần khám, mã khám bệnh = “”, 
    '-  Bấm chọn dịch vụ, phòng khám và bấm nút (+): Khi đó sẽ thêm lần khám, dịch vụ khám
    '- > Trạng thái ban đầu.

    '2. Nếu bấm Sửa
    'ĐK cần có: Load ra mã bệnh nhân, mã khám bệnh
    'Hiển thị nút: Ghi + Không lưu. Các nút khác ẩn.
    '- Người dùng nhập các thông tin hành chính (cả bệnh nhân và lần khám)
    '- Nếu bấm Ghi thì lưu lại các thông tin Bệnh nhân, Khám bệnh theo mã bệnh nhân, mã khám bệnh, - > Trạng thái ban đầu.
    '- Nếu bấm Không ghi - > Trạng thái ban đầu. Load lại thông tin bệnh nhân, khám bệnh theo mã bệnh nhân, mã khám bệnh


    '3. Nếu bấm Xóa
    'Kiểm tra nếu có nhiều lần khám hay không? 
    '- Nếu lớn hơn 1 lần:  Lựa chọn xóa bệnh nhân hay lần khám hiện tại, nếu Yes thì xóa theo lựa chọn, nếu No thì quay lại - > Trạng thái ban đầu
    '- Nếu = 1, hỏi có xóa bệnh nhận ko, Yes thì xóa, No thì quay lại - > Trạng thái ban đầu
    '4. Nếu bấm Tìm kiếm
    'Kết quả trả về phải có mã bệnh nhân và mã khám bệnh, bấm đúp vào thì load các dịch vụ khám đi kèm

    Dim booThem As Boolean
    Dim booSua As Boolean
    Dim TruonghopThemPK
    Dim STTQuan As Integer = 0, STTBH As Integer = 0, STTDan As Integer = 0
    'TruonghopThemPK = 1 (Nếu không nhập mã bệnh nhân thì thêm mới hoàn toàn)
    'TruonghopThemPK = 2 (Có mã BN, Mã KB, trong DS đã có DVk )
    Dim Duoc_Them_BN As Boolean = False
    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose(True)
    End Sub
    Private Sub frmTiepnhan_new_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 Then
            'If cmbDoituong.SelectedValue = "" Then
            '    MsgBox("Hãy chọn đối tượng tiếp đón.", MsgBoxStyle.Critical, "Message!")
            '    cmbDoituong.Focus()
            '    Exit Sub
            'End If
            cmdThem_Click(sender, e)
        End If
        If e.KeyCode = Keys.F7 Then 'Goi tiep
            cmdCall_Click(cmdCall, System.EventArgs.Empty)
        End If
        If e.KeyCode = Keys.F8 Then 'Goi so
            Button8_Click(Button8, System.EventArgs.Empty)
        End If
        If e.KeyCode = Keys.F9 And cmdGhi.Visible Then
            cmdGhi_Click(sender, e)
        End If
        If e.KeyCode = Keys.F10 And cmdInPK.Visible Then
            cmdInPK_Click(sender, e)
        End If
        If e.KeyCode = Keys.F12 Then
            Button7_Click(sender, e)
        End If
        'If e.KeyCode = Keys.F11 Then
        '    InPhieuThanhtoanRV()
        'End If
    End Sub
    Private Sub frmTiepnhan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.panDSBenhnhan.Top = 3
        Me.panDSBenhnhan.Left = 3
        cmbTuyen.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Tuyen", "1") = "1", True, False)
        txtSotheBHYT.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_SotheBHYT", "1") = "1", True, False)
        txtManoiDKKCBBD.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_NoidangkyBHYT", "1") = "1", True, False)
        txtTennoiDKKCBBD.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_NoidangkyBHYT", "1") = "1", True, False)
        txtMaDT.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_DoituongBHYT", "1") = "1", True, False)
        txtTenDT.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_DoituongBHYT", "1") = "1", True, False)
        dtBHTu.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_HandungBHYTTu", "1") = "1", True, False)
        dtBHDen.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_HandungBHYT", "1") = "1", True, False)
        txtTenBHYTTinh.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_NoicapBHYT", "1") = "1", True, False)

        txtDiachi.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Diachi", "1") = "1", True, False)
        cmbCapbac.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Capbac", "1") = "1", True, False)
        cmbNghenghiep.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Nghenghiep", "1") = "1", True, False)
        txtNoicongtac.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Noilamviec", "1") = "1", True, False)
        txtLienhe.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Lienhe", "1") = "1", True, False)
        txtTheTE.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_TheTE", "1") = "1", True, False)
        txtNoigioithieu.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Noigioithieu", "1") = "1", True, False)
        txtChandoan.Enabled = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_ChandoanNGT", "1") = "1", True, False)

        DocDM()
        SetEmpty()
        txtThoigianDangky.Value = GetSrvDate()
        txtThoigianChidinh.Value = GetSrvDate()
        txtNgaykhamT.Value = GetSrvDate()
        Load_Phongkham(NgayHienTai, cmbDoituong_PK.SelectedValue)
        Load_DSBN(GetSrvDate())
        Kiemtra_Quyen_ThemBN(Get_MAC_Address)
        LoadFormChidinh()
        SetPos_Start()
    End Sub
    Private Sub Kiemtra_Quyen_ThemBN(ByVal MAC As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try
            SQL = "SELECT * from " & TenDatabase & ".DBO.MAC_FUNCTION a where a.MAC = N'" & MAC & "' and Tiepdon = 1"
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then ' Được quyền tiếp đón
                Duoc_Them_BN = True
            Else
                Duoc_Them_BN = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DocDM()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet

        SQLStr = "Select MaDT, TenDT from DMDOITUONGBN where  Nutla = 1"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter
        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet
        Adap1.Fill(DsDM, "DMDOITUONGBN")
        Cmd1.Dispose()

        SQLStr = "Select MaDT as Ma, TenDT as Ten from DMDOITUONGBN "
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1.SelectCommand = Cmd1
        Adap1.Fill(DsDM, "DMDOITUONGBN_ALL")
        Cmd1.Dispose()

        SQLStr = "Select makhoa, tenkhoa from DMKhoaphong where  is_Phongkham = 1 order by MaKhoa"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1.SelectCommand = Cmd1
        Adap1.Fill(DsDM, "DMPHONGKHAM")
        Cmd1.Dispose()

        SQLStr = "Select MaDichvu, TenDichvu from vDMDICHVU where  Noitru_Ngoaitru = 2  order by MaDichvu"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1.SelectCommand = Cmd1
        Adap1.Fill(DsDM, "DMDICHVUKHAM")
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

        SQLStr = "Select * from DMDONVI"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1.SelectCommand = Cmd1
        Adap1.Fill(DsDM, "DMDONVI")
        Cmd1.Dispose()
        ' Them vao combo
        cmbDoituong.ColumnWidth = 500
        cmbDoituong.DataSource = DsDM.Tables("DMDOITUONGBN")
        cmbDoituong.DisplayMember = "TenDT"
        cmbDoituong.ValueMember = "MaDT"
        cmbDoituong.SelectedIndex = 1
        cmbDoituong.AutoDropDown = True

        cmbDoituong_PK.ColumnWidth = 500
        cmbDoituong_PK.DataSource = DsDM.Tables("DMDOITUONGBN_ALL")
        cmbDoituong_PK.DisplayMember = "Ten"
        cmbDoituong_PK.ValueMember = "Ma"
        cmbDoituong_PK.Text = ""
        cmbDoituong_PK.AutoDropDown = True



        cmbPhongkham.DataSource = DsDM.Tables("DMPHONGKHAM")
        cmbPhongkham.DisplayMember = "TenKhoa"
        cmbPhongkham.ValueMember = "MaKhoa"
        cmbPhongkham.AutoDropDown = True




        cmbYeucaukham.DataSource = DsDM.Tables("DMDICHVUKHAM")
        cmbYeucaukham.DisplayMember = "TenDichvu"
        cmbYeucaukham.ValueMember = "MaDichvu"
        cmbYeucaukham.AutoDropDown = True


        cmbNghenghiep.DataSource = DsDM.Tables("DMNGHENGHIEP")
        cmbNghenghiep.DisplayMember = "TenNghenghiep"
        cmbNghenghiep.ValueMember = "MaNghenghiep"
        cmbNghenghiep.AutoDropDown = True

        cmbCapbac.DataSource = DsDM.Tables("DMQUANHAM")
        cmbCapbac.DisplayMember = "TenQH"
        cmbCapbac.ValueMember = "MaQH"
        cmbCapbac.AutoDropDown = True

        cmbDonvi.DataSource = DsDM.Tables("DMDONVI")
        cmbDonvi.DisplayMember = "TenTat"
        cmbDonvi.ValueMember = "MaDonvi"
        cmbDonvi.AutoDropDown = True

        cmbGioitinh.ClearItems()
        cmbGioitinh.AddItem("Nam")
        cmbGioitinh.AddItem("Nữ")

        cmbTuyen.ClearItems()
        cmbTuyen.AddItem("Đúng tuyến")
        cmbTuyen.AddItem("Trái tuyến")
        cmbTuyen.AddItem("Cấp cứu")

        txtTuoi.ValueIsDbNull = True

        Adap1.Dispose()
        DsDM.Dispose()
        Adap1 = Nothing
        Cmd1 = Nothing
        DsDM = Nothing
    End Sub
    Private Sub SetEmpty()
        txtMabenhnhan.Text = ""
        txtTenbenhnhan.Text = ""
        txtMaKhambenh.Text = ""
        txtDiachi.Text = ""
        txtLienhe.Text = ""
        txtSotheBHYT.Text = ""
        If txtTenBHYTTinh.Enabled = True Then
            txtTenBHYTTinh.Text = TinhTP
        Else
            txtTenBHYTTinh.Text = ""
        End If
        If cmbTuyen.Enabled Then cmbTuyen.SelectedIndex = 0
        optKhamthuong.Checked = True
        txtTheTE.Text = ""
        txtManoiDKKCBBD.Text = MaDKKCBBD
        txtTennoiDKKCBBD.Text = TenPK
        txtMaDT.Text = ""
        txtTenDT.Text = ""
        cmbCapbac.SelectedValue = ""
        cmbCapbac.Text = ""
        cmbDonvi.SelectedValue = ""
        cmbDonvi.Text = ""
        cmbPhongkham.SelectedValue = ""
        cmbPhongkham.Text = ""
        txtChandoan.Text = ""
        'cmbYeucaukham.Text = ""
        'cmbYeucaukham.SelectedValue = ""
        grdYeucaukham.Rows.Count = 1
        lblLankhamcuoi.Text = "       Lần khám gần nhất"
        dtBHTu.Value = Nothing
        dtBHDen.Value = Nothing
        txtSoBANT.Text = ""
    End Sub
    Function Get_Maxcode() As String
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Get_Maxcode = ""
        SQl = "select isnull(Max(right(mabenhnhan,3)),'0') as MaxCode from tblBenhnhan where left(mabenhnhan,6) = '" & Format(GetSrvDate(), "yyMMdd") & "' "
        Cmd = New SqlCommand(SQl, Cn)
        rd = Cmd.ExecuteReader
        Dim maxcode As Integer
        Do While rd.Read
            maxcode = CType(rd!maxcode, Integer)
        Loop
        rd.Close()
        Get_Maxcode = Format(GetSrvDate(), "yyMMdd") & Format(Val(Trim(maxcode)) + 1, "000")
    End Function
    Public Sub KiemtraBenhnhan(ByVal ma As String, ByRef Co As Boolean, ByRef Last_NgayDangky As Date, ByRef MaKB As String)
        'Hàm kiểm tra xem mã bệnh nhân = Mã đã có trong CSDL chưa
        'Hàm trả về biến Co = true: Nếu đã đăng ký, else. Biến last_Ngaydangky = ngày đăng ký khám gần nhất , Biến MaKB = Mã lần khám gần nhất
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try
            Co = False
            SQL = "SELECT  tblKhambenh.* from tblKhambenh " _
                    & " where tblkhambenh.MaBenhnhan = N'" & ma & "' order by Thoigiandangky desc"
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then ' Có đăng ký rồi
                Co = True
                Last_NgayDangky = ds.Tables("Hoso").Rows(0).Item("Thoigiandangky")
                MaKB = ds.Tables("Hoso").Rows(0).Item("MaKhambenh")
            Else
                Dim cmdDel As SqlCommand = New SqlCommand("Delete from tblBenhnhan where Mabenhnhan = N'" & ma & "'", Cn)
                cmdDel.ExecuteNonQuery()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FillDataHC(ByVal ma As String) 'ma = Mã khám bệnh
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try
            If Trim(ma) = "" Then Exit Sub
            SetEmpty()
            SQL = "SELECT tblBenhnhan.*,tblKhambenh.*, " _
                    & " DMDTTHE_BHYT.TenDT as TenDTThe,DMNOIDKKCBBD_BHYT.Tennoicap" _
                    & " FROM  tblkhambenh " _
                    & " left join tblBenhnhan on tblKhambenh.Mabenhnhan = tblBenhnhan.Mabenhnhan " _
                    & " left join DMDTTHE_BHYT on tblKhambenh.Doituongthe  = DMDTTHE_BHYT.MaDT " _
                    & " left join DMNOIDKKCBBD_BHYT on tblKhambenh.NoidangkyKCBBD  = DMNOIDKKCBBD_BHYT.Manoicap " _
                    & " left join DMDOITUONGBN on tblKhambenh.Doituong  = DMDOITUONGBN.MaDT " _
                    & " left join DMNGHENGHIEP on tblKhambenh.Nghenghiep  = DMNGHENGHIEP.MaNghenghiep " _
                    & " where tblkhambenh.MaKhambenh = N'" & ma & "' "

            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                'Fill Benh nhan
                txtMabenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("MaBenhnhan")
                txtTenbenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("TenBenhnhan")
                txtTuoi.Value = ds.Tables("Hoso").Rows(0).Item("Namsinh")
                cmbGioitinh.SelectedIndex = IIf(ds.Tables("Hoso").Rows(0).Item("Gioitinh"), 0, 1)
                ' Fill Kham benh
                txtMaKhambenh.Text = ds.Tables("Hoso").Rows(0).Item("MaKhambenh")
                cmbDoituong.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Doituong")
                txtDiachi.Text = ds.Tables("Hoso").Rows(0).Item("Diachi")
                cmbNghenghiep.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Nghenghiep")
                cmbCapbac.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Capbac")
                cmbDonvi.SelectedValue = ds.Tables("Hoso").Rows(0).Item("MaDonvi")
                txtNoicongtac.Text = ds.Tables("Hoso").Rows(0).Item("Noicongtac")

                txtLienhe.Text = ds.Tables("Hoso").Rows(0).Item("Lienhe")
                txtTheTE.Text = ds.Tables("Hoso").Rows(0).Item("SotheTE")
                txtNoigioithieu.Text = ds.Tables("Hoso").Rows(0).Item("Noigioithieu")
                txtChandoan.Text = ds.Tables("Hoso").Rows(0).Item("ChandoanNGT")
                txtThoigianDangky.Value = ds.Tables("Hoso").Rows(0).Item("ThoigianDangky")

                cmbTuyen.SelectedIndex = Val(ds.Tables("Hoso").Rows(0).Item("Tuyen").ToString)
                If (cmbDoituong.SelectedValue = "1") Then
                    txtSotheBHYT.Text = ds.Tables("Hoso").Rows(0).Item("SotheBHYT").ToString
                    txtMaDT.Text = ds.Tables("Hoso").Rows(0).Item("DoituongThe").ToString
                    txtTenDT.Text = ds.Tables("Hoso").Rows(0).Item("TenDTThe").ToString
                    txtManoiDKKCBBD.Text = ds.Tables("Hoso").Rows(0).Item("NoidangkyKCBBD").ToString
                    txtTennoiDKKCBBD.Text = ds.Tables("Hoso").Rows(0).Item("Tennoicap").ToString
                    dtBHTu.Value = ds.Tables("Hoso").Rows(0).Item("HantheBHYT_Tu").ToString
                    dtBHDen.Value = ds.Tables("Hoso").Rows(0).Item("HantheBHYT_Den").ToString
                    txtTenBHYTTinh.Text = ds.Tables("Hoso").Rows(0).Item("NoicaptheBHYT").ToString
                    txtSoBANT.Text = ds.Tables("Hoso").Rows(0).Item("SoBANT").ToString
                End If
                '                optKhamthuong.Checked = IIf(ds.Tables("Hoso").Rows(0).Item("Khamthuong_CC") = 0, True, False)
                booThem = False
                booSua = False
                'LockControl(False)
            Else
                MsgBox("Bệnh nhân chưa có trong CSDL", MsgBoxStyle.Information, "Message !")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FillDataHC_SoBANT(ByVal ma As String) 'ma = Mã khám bệnh
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try
            If Trim(ma) = "" Then Exit Sub
            SetEmpty()
            SQL = "SELECT tblBenhnhan.*,tblKhambenh.*, " _
                    & " DMDTTHE_BHYT.TenDT as TenDTThe,DMNOIDKKCBBD_BHYT.Tennoicap" _
                    & " FROM  tblkhambenh " _
                    & " left join tblBenhnhan on tblKhambenh.Mabenhnhan = tblBenhnhan.Mabenhnhan " _
                    & " left join DMDTTHE_BHYT on tblKhambenh.Doituongthe  = DMDTTHE_BHYT.MaDT " _
                    & " left join DMNOIDKKCBBD_BHYT on tblKhambenh.NoidangkyKCBBD  = DMNOIDKKCBBD_BHYT.Manoicap " _
                    & " left join DMDOITUONGBN on tblKhambenh.Doituong  = DMDOITUONGBN.MaDT " _
                    & " left join DMNGHENGHIEP on tblKhambenh.Nghenghiep  = DMNGHENGHIEP.MaNghenghiep " _
                    & " where tblkhambenh.MaKhambenh = N'" & ma & "' "

            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                'Fill Benh nhan
                'txtMabenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("MaBenhnhan")
                txtTenbenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("TenBenhnhan")
                txtTuoi.Value = ds.Tables("Hoso").Rows(0).Item("Namsinh")
                cmbGioitinh.SelectedIndex = IIf(ds.Tables("Hoso").Rows(0).Item("Gioitinh"), 0, 1)
                ' Fill Kham benh

                cmbDoituong.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Doituong")
                txtDiachi.Text = ds.Tables("Hoso").Rows(0).Item("Diachi")
                cmbNghenghiep.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Nghenghiep")
                cmbCapbac.SelectedValue = ds.Tables("Hoso").Rows(0).Item("Capbac")
                cmbDonvi.SelectedValue = ds.Tables("Hoso").Rows(0).Item("MaDonvi")
                txtNoicongtac.Text = ds.Tables("Hoso").Rows(0).Item("Noicongtac")

                txtLienhe.Text = ds.Tables("Hoso").Rows(0).Item("Lienhe")
                txtTheTE.Text = ds.Tables("Hoso").Rows(0).Item("SotheTE")
                txtNoigioithieu.Text = ds.Tables("Hoso").Rows(0).Item("Noigioithieu")
                'txtThoigianDangky.Value = ds.Tables("Hoso").Rows(0).Item("ThoigianDangky")

                cmbTuyen.SelectedIndex = Val(ds.Tables("Hoso").Rows(0).Item("Tuyen").ToString)
                txtSotheBHYT.Text = ds.Tables("Hoso").Rows(0).Item("SotheBHYT")
                txtMaDT.Text = ds.Tables("Hoso").Rows(0).Item("DoituongThe")
                txtTenDT.Text = ds.Tables("Hoso").Rows(0).Item("TenDTThe")
                txtManoiDKKCBBD.Text = ds.Tables("Hoso").Rows(0).Item("NoidangkyKCBBD")
                txtTennoiDKKCBBD.Text = ds.Tables("Hoso").Rows(0).Item("Tennoicap")
                dtBHTu.Value = ds.Tables("Hoso").Rows(0).Item("HantheBHYT_Tu")
                dtBHDen.Value = ds.Tables("Hoso").Rows(0).Item("HantheBHYT_Den")
                txtTenBHYTTinh.Text = ds.Tables("Hoso").Rows(0).Item("NoicaptheBHYT")
                txtSoBANT.Text = ds.Tables("Hoso").Rows(0).Item("SoBANT").ToString
            Else
                MsgBox("Bệnh nhân chưa có trong CSDL", MsgBoxStyle.Information, "Message !")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub FillDanhsachPK(ByVal Ma As String) 'ma = Mã khám bệnh
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            grdYeucaukham.Rows.Count = 1
            SQL = "SELECT tblKHAMBENH_KQDVKHAM.MaphieuCD,tblKHAMBENH_KQDVKHAM.MaDichvu,tblKHAMBENH_KQDVKHAM.Khoathuchien,DMKHOAPHONG.TenKhoa,DMKHOAPHONG.Diadiem," _
            & " tblKHAMBENH_KQDVKHAM.ThutuKham,vDMDICHVU.TenDichvu FROM  tblKHAMBENH_KQDVKHAM  " _
            & " left outer join DMKhoaPhong  on tblKHAMBENH_KQDVKHAM.Khoathuchien = DMKhoaPhong.MaKhoa  " _
            & " left outer join vDMDICHVU  on tblKHAMBENH_KQDVKHAM.MaDichvu = vDMDICHVU.MaDichvu    " _
            & " where tblKHAMBENH_KQDVKHAM.MaKhambenh = N'" & Ma & "' and left(tblKHAMBENH_KQDVKHAM.MaphieuCD,2) = 'PK' "
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    grdYeucaukham.AddItem(ds.Tables("Hoso").Rows(i).Item("Khoathuchien") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenKhoa") & vbTab & ds.Tables("Hoso").Rows(i).Item("ThutuKham") & vbTab & ds.Tables("Hoso").Rows(i).Item("MaDichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenDichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("MaphieuCD") & vbTab & ds.Tables("Hoso").Rows(i).Item("Diadiem"))
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LockControl(ByVal DK As Boolean)
        cmdThem.Visible = Not DK
        cmdSua.Visible = Not DK
        cmdXoa.Visible = Not DK
        cmdThoat.Visible = Not DK
        cmdInPK.Visible = Not DK
        cmdTimkiem.Visible = Not DK

        cmdGhi.Visible = DK
        cmdHuy.Visible = DK
    End Sub
    Private Sub ViewControl(ByVal TT As String)
        Select Case TT
            Case "Start"
                cmdThem.Visible = True
                cmdSua.Visible = True
                cmdXoa.Visible = True
                cmdThoat.Visible = True
                cmdInPK.Visible = True
                cmdTimkiem.Visible = True

                cmdGhi.Visible = False
                cmdHuy.Visible = False

                booThem = False
                booSua = False

                txtMabenhnhan.ReadOnly = True
                grpChidinh.Enabled = True
                lblLankhamcuoi.Visible = False
            Case "Them"
                cmdThem.Visible = False
                cmdSua.Visible = False
                cmdXoa.Visible = False
                cmdThoat.Visible = False
                cmdInPK.Visible = False
                cmdTimkiem.Visible = False
                cmdGhi.Visible = False

                cmdHuy.Visible = True

                booThem = True
                booSua = False

                txtMabenhnhan.ReadOnly = False
                grpChidinh.Enabled = True
            Case "Sua"
                cmdThem.Visible = False
                cmdSua.Visible = False
                cmdXoa.Visible = False
                cmdThoat.Visible = False
                cmdInPK.Visible = False
                cmdTimkiem.Visible = False

                cmdGhi.Visible = True
                cmdHuy.Visible = True

                booThem = False
                booSua = True

                txtMabenhnhan.ReadOnly = True
                grpChidinh.Enabled = False
        End Select
    End Sub
    Private Function KiemtraHL() As Boolean
        KiemtraHL = False
        If Trim(txtTenbenhnhan.Text) = "" Then
            MsgBox("Phải nhập tên bệnh nhân", MsgBoxStyle.Information, "Message !")
            txtSotheBHYT.Focus()
            'txtTenbenhnhan.Focus()
            Exit Function
        End If
        If Trim(cmbDoituong.SelectedValue) = "" Then
            MsgBox("Phải nhập đối tượng bệnh nhân", MsgBoxStyle.Information, "Message !")
            cmbDoituong.Focus()
            Exit Function
        End If
        If Trim(cmbDoituong.Text) <> "Bảo hiểm y tế" And txtSotheBHYT.Text.Trim <> "" Then
            MsgBox("Không được nhập số thẻ BHYT cho đối tượng " + cmbDoituong.Text.Trim, MsgBoxStyle.Information, "Message !")
            txtSotheBHYT.Focus()
            Exit Function
        End If
        If txtTuoi.ValueIsDbNull Then
            MsgBox("Phải nhập tuổi của bệnh nhân ", MsgBoxStyle.Information, "Message !")
            txtTuoi.Focus()
            Exit Function
        End If
        If txtTuoi.Value > Year(GetSrvDate()) Then
            MsgBox("Nhập sai tuổi của bệnh nhân ", MsgBoxStyle.Information, "Message !")
            txtTuoi.Focus()
            Exit Function
        End If
        If cmbDoituong.Text = "Bảo hiểm y tế" Then
            If txtSotheBHYT.Text.Trim() = "" Then
                MsgBox("Phải nhập số thẻ BHYT", MsgBoxStyle.Information, "Message !")
                'txtSotheBHYT.Focus()
                Exit Function
            End If
            If cmbTuyen.SelectedIndex < 0 Then
                MsgBox("Phải nhập tuyến (Đúng tuyến, trái tuyến hoặc Cấp cứu)", MsgBoxStyle.Information, "Message !")
                'cmbTuyen.Focus()
                Exit Function
            End If
            If txtSotheBHYT.Text.Trim().Length() <> 13 Then
                MsgBox("Phải nhập đúng số thẻ BHYT (độ dài 13)", MsgBoxStyle.Information, "Message !")
                'txtSotheBHYT.Focus()
                Exit Function
            End If
            If txtMaDT.Text.Trim().Length() <> 2 Then
                MsgBox("Phải nhập đúng mã đối tượng thẻ BHYT (độ dài 2)", MsgBoxStyle.Information, "Message !")
                'txtMaDT.Focus()
                Exit Function
            End If
            If dtBHTu.ValueIsDbNull Or dtBHDen.ValueIsDbNull Then
                MsgBox("Phải nhập hạn thẻ BHYT (từ ngày - đến ngày)", MsgBoxStyle.Information, "Message !")
                'txtMaDT.Focus()
                Exit Function
            End If
            If DateDiff(DateInterval.Day, dtBHTu.Value, GetSrvDate()) < 0 Then
                MsgBox("Kiểm tra lại ngày thẻ BHYT bắt đầu có giá trị > ngày hiện tại", MsgBoxStyle.Information, "Message !")
                'txtMaDT.Focus()
                Exit Function
            End If
            If DateDiff(DateInterval.Day, dtBHDen.Value, GetSrvDate()) > 0 Then
                MsgBox("Kiểm tra lại hạn thẻ BHYT < ngày hiện tại", MsgBoxStyle.Information, "Message !")
                'txtMaDT.Focus()
                Exit Function
            End If
            If txtManoiDKKCBBD.Text.Trim().Length() <> 5 Then
                MsgBox("Phải nhập đúng mã nơi đăng ký khám chữa bệnh ban đầu (độ dài 5)", MsgBoxStyle.Information, "Message !")
                'txtManoiDKKCBBD.Focus()
                Exit Function
            End If
            If txtSotheBHYT.Text.Trim().Length() = 13 And Val(Mid(txtSotheBHYT.Text.Trim(), 1, 1)) < 1 Then
                MsgBox("Kiểm tra lại số thẻ BHYT (mức quyền lợi phải từ 1 - 9)", MsgBoxStyle.Information, "Message !")
                'txtSotheBHYT.Focus()
                Exit Function
            End If
            If txtManoiDKKCBBD.Text <> MaDKKCBBD And cmbTuyen.SelectedIndex = 0 Then ' Ko đăng ký tại bệnh viện mà đúng tuyến
                If MsgBox("Chú ý: Bệnh nhân Không đăng ký KCBBĐ tại BV - ĐÚNG TUYẾN" & vbCrLf & "Bạn có tiếp tục không?", MsgBoxStyle.YesNo, "Yêu cầu xác nhận!") = MsgBoxResult.No Then
                    Exit Function
                End If
            End If
            If txtTennoiDKKCBBD.Text = TenPK And cmbTuyen.SelectedIndex = 1 Then ' Đăng ký tại bệnh viện mà trái tuyến
                MsgBox("Chú ý: Bệnh nhân Đăng ký KCBBĐ tại BV - TRÁI TUYẾN" & vbCrLf & "Không cho phép tiếp tục.", MsgBoxStyle.Critical, "Message!")
                Exit Function
            End If

            '----Kiểm tra bệnh nhân có trong nội viện ko?---
            Dim SQL As String = "select * from " & TenDatabase & ".DBO.tblTAICHINH_VAOVIEN a where a.SotheBHYT = '" & txtSotheBHYT.Text & "' " _
            & " and a.Mavaovien not in (select Mavaovien from " & TenDatabase & ".DBO.tblTAICHINH_RAVIEN) " _
            & " and left(a.Mavaovien,6) > '" & Format(DateAdd(DateInterval.Day, -30, NgayHienTai), "yyMMdd") & "'"
            Dim cmd As New SqlCommand(SQL, Cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                MsgBox("Chú ý: Bệnh nhân có số thẻ này vào viện ngày " + dr!thoigianvaovien.ToString + " chưa ra viện", MsgBoxStyle.Critical, "Cảnh báo!")
                dr.Close()
            Else
                dr.Close()
            End If
            '--------------------------------------------------
        End If
        'If InStr(GetSetting("PHONGKHAM", "Thuoctinh", "DTKhongduocchon", ""), cmbDoituong.SelectedValue) > 0 Then
        '    MsgBox("Kiểm tra lại việc chọn đối tượng  ", MsgBoxStyle.Information, "Message !")
        '    cmbDoituong.Focus()
        '    Exit Function
        'End If
        KiemtraHL = True
    End Function
    Private Sub cmdThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem.Click
        'Kiem tra Neu tre6n6 15 benh thi out.
        'Dim SQL As String
        'Dim Cmd As SqlCommand
        'Dim Adap As SqlDataAdapter
        'Dim ds As DataSet
        'Dim i
        'Try
        '    SQL = "SELECT isnull(count([MaKhambenh]),0) as SoLuong " _
        '            & " FROM [dbo].[tblKHAMBENH] where DATEDIFF(dd,ThoigianDangky,GETDATE()) = 0"
        '    Cmd = New SqlCommand(SQL, Cn)
        '    Dim SoLuong As Integer
        '    SoLuong = Cmd.ExecuteScalar()
        '    If SoLuong > 15 Then
        '        MessageBox.Show("ĐÂY LÀ BẢN DÙNG THỬ. GIỚI HẠN TIẾP NHẬN 15 BỆNH NHÂN 1 NGÀY! ĐỂ CÓ BẢN CHÍNH THỨC HÃY LIÊN HỆ NHÀ CUNG CẤP!.", "Message")
        '        Return
        '    End If
        'Catch ex As Exception
        'End Try

        SetEmpty()
        txtThoigianDangky.Value = GetSrvDate()
        txtThoigianChidinh.Value = GetSrvDate()
        booThem = True
        ViewControl("Them")
        If cmbTuyen.Enabled Then
            cmbDoituong.Focus()
            'txtSotheBHYT.Focus()
            txtSotheBHYT.Select(2, 0)
        Else
            cmbTuyen.SelectedIndex = -1
            txtTenbenhnhan.Focus()
        End If
    End Sub
    Private Sub cmdSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSua.Click
        If Trim(txtMabenhnhan.Text) = "" Or Trim(txtMaKhambenh.Text) = "" Then
            MsgBox("Chưa chọn bản ghi để sửa", MsgBoxStyle.Information, "Message !")
            Exit Sub
        End If
        booSua = True
        txtMabenhnhan.ReadOnly = True
        txtMaKhambenh.ReadOnly = True
        ViewControl("Sua")
        'Load_Phongkham(txtNgayPK.Value)
    End Sub
    Private Sub cmdXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXoa.Click
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim DaTT As Boolean
        Dim Dakham As Boolean
        Dim Tran As SqlTransaction
        'Kiem tra xem co du dk xoa khong (  da thanh toan BHYT chua)  
        SQl = "Select * from " & TenDatabase & ".DBO.tblThanhtoanBHYT where  Makhambenh = N'" & txtMaKhambenh.Text & "' "
        DaTT = False
        Cmd = New SqlCommand(SQl, Cn)
        rd = Cmd.ExecuteReader
        If rd.HasRows Then DaTT = True
        rd.Close()
        If DaTT Then
            MsgBox("Đã thanh toán, không cho phép xóa", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        End If
        SQl = "Select * from tblKhambenh_KQDVKHAM where  Mabenhnhan = '" & txtMabenhnhan.Text & "' and Makhambenh = '" & txtMaKhambenh.Text & "' and HuongGQ <> 0"
        Dakham = False
        Cmd = New SqlCommand(SQl, Cn)
        rd = Cmd.ExecuteReader
        Do While rd.Read
            Dakham = True
        Loop
        rd.Close()
        If Dakham Then
            MsgBox("Đã khám, không cho phép xóa", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        End If
        ' Yeu cau xac nhan
        If MsgBox("Bạn có chắc chắn muốn xóa bệnh nhân này không ?", MsgBoxStyle.YesNo, "Cảnh báo!") = MsgBoxResult.No Then Exit Sub

        'Xoa trong data
        Tran = Cn.BeginTransaction()
        Try
            Dim KillCmd As New SqlCommand
            KillCmd.Connection = Cn
            KillCmd.Transaction = Tran
            KillCmd.Connection = Cn
            KillCmd.CommandText = "Delete from tblBenhnhan where Mabenhnhan = N'" & txtMabenhnhan.Text & "'"
            KillCmd.ExecuteNonQuery()
            KillCmd.CommandText = "Delete from tblKhambenh where Mabenhnhan = N'" & txtMabenhnhan.Text & "'"
            KillCmd.ExecuteNonQuery()
            KillCmd.CommandText = "Delete from tblKhambenh_DICHVU  where Mabenhnhan = N'" & txtMabenhnhan.Text & "'"
            KillCmd.ExecuteNonQuery()
            KillCmd.CommandText = "Delete from tblKhambenh_Chidinh  where Mabenhnhan = N'" & txtMabenhnhan.Text & "'"
            KillCmd.ExecuteNonQuery()
            KillCmd.CommandText = "Delete from tblKhambenh_KQDVKHAM  where Mabenhnhan = N'" & txtMabenhnhan.Text & "'"
            KillCmd.ExecuteNonQuery()
            KillCmd.CommandText = "Delete from tblKhambenh_DONTHUOC where Mabenhnhan = N'" & txtMabenhnhan.Text & "'"
            KillCmd.ExecuteNonQuery()
            Tran.Commit()
            'Lam tuoi lai fgPhongkham
            SetEmpty()
            grdYeucaukham.Rows.Count = 1
            Load_Phongkham(NgayHienTai, cmbDoituong_PK.SelectedValue)
            Load_DSBN(GetSrvDate())
            KillCmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()
        End Try
    End Sub
    Private Sub cmdGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGhi.Click
        Dim TenBenhnhan, Namsinh, Gioitinh, Tuyen
        Dim Doituong, Diachi, Nghenghiep, Capbac, Madonvi, Noicongtac, Lienhe, TheTE, Noigioithieu, Chandoan, ThoigianDangky
        Dim SotheBHYT, Doituongthe_BHYT, NoiDKKCBBD_BHYT, BHYTTu, BHYTDen, BHXHTinh, SoBANT As String
        Dim Tran As SqlTransaction
        Dim Cmd As New SqlCommand
        Dim Sql As String = ""
        Dim DaTT As Boolean
        Dim Dakham As Boolean
        Dim rd As SqlDataReader
        If Not KiemtraHL() Then
            Exit Sub
        End If


       

        'Kiem tra xem co du dk sửa khong (  da thanh toan BHYT chua)  
        Sql = "Select * from " & TenDatabase & ".DBO.tblThanhtoanBHYT_CT where  Makhambenh = N'" & txtMaKhambenh.Text & "' "
        Dakham = False
        Cmd = New SqlCommand(Sql, Cn)
        rd = Cmd.ExecuteReader
        If rd.HasRows Then DaTT = True
        rd.Close()
        If DaTT Then
            MsgBox("Đã thanh toán, không cho phép sửa", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        End If
        TenBenhnhan = "N'" & Replace(Trim(txtTenbenhnhan.Text), "'", "''") & "'"
        Namsinh = ""
        If txtTuoi.Value Is System.DBNull.Value Then
            Namsinh = "null"
        Else
            Namsinh = txtTuoi.Value.ToString()
        End If
        Gioitinh = IIf(cmbGioitinh.Text = "Nam", 1, 0)
        Doituong = "N'" & Replace(Trim(cmbDoituong.SelectedValue), "'", "''") & "'"
        Diachi = "N'" & Replace(Trim(txtDiachi.Text), "'", "''") & "'"
        Nghenghiep = "N'" & Replace(Trim(cmbNghenghiep.SelectedValue), "'", "''") & "'"
        Capbac = "N'" & Replace(Trim(cmbCapbac.SelectedValue), "'", "''") & "'"
        Madonvi = "N'" & Replace(Trim(cmbDonvi.SelectedValue), "'", "''") & "'"
        Noicongtac = "N'" & Replace(Trim(cmbDonvi.Text), "'", "''") & "'"
        Lienhe = "N'" & Replace(Trim(txtLienhe.Text), "'", "''") & "'"
        TheTE = "N'" & Replace(Trim(txtTheTE.Text), "'", "''") & "'"
        Noigioithieu = "N'" & Replace(Trim(txtNoigioithieu.Text), "'", "''") & "'"
        Chandoan = "N'" & Replace(Trim(txtChandoan.Text), "'", "''") & "'"
        ThoigianDangky = txtThoigianDangky.Value

        Tuyen = cmbTuyen.SelectedIndex
        If Tuyen = -1 Then Tuyen = 0
        SotheBHYT = "N'" & Replace(Trim(txtSotheBHYT.Text), "'", "''") & "'"
        Doituongthe_BHYT = "N'" & Replace(Trim(txtMaDT.Text), "'", "''") & "'"
        NoiDKKCBBD_BHYT = "N'" & Replace(Trim(txtManoiDKKCBBD.Text), "'", "''") & "'"
        If dtBHTu.Text = "" Or dtBHTu.Text = "01/01/0001" Then
            BHYTTu = "NULL"
        Else : BHYTTu = String.Format("'{0:MM/dd/yyyy}'", dtBHTu.Value)
        End If
        If dtBHDen.Text = "" Or dtBHTu.Text = "01/01/0001" Then
            BHYTDen = "NULL"
        Else : BHYTDen = String.Format("'{0:MM/dd/yyyy}'", dtBHDen.Value)
        End If
        BHXHTinh = "N'" & Replace(Trim(txtTenBHYTTinh.Text), "'", "''") & "'"
        SoBANT = "N'" & Replace(Trim(txtSoBANT.Text), "'", "''") & "'"
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
            & "   ThoigianDangky = '" & Format(ThoigianDangky, "MM/dd/yyyy HH:mm:ss") & "', " _
            & " Doituong = " & Doituong & ", Diachi = " & Diachi & ",Noicongtac = " & Noicongtac & ", " _
            & "   Tuyen = " & Tuyen & ", SotheBHYT = " & SotheBHYT & ",Doituongthe = " & Doituongthe_BHYT & ", " _
            & "   NoidangkyKCBBD = " & NoiDKKCBBD_BHYT & ",HantheBHYT_Tu = " & BHYTTu & ", " _
            & "   HantheBHYT_Den =" & BHYTDen & " ,NoicaptheBHYT =" & BHXHTinh & ", " _
            & "   Nghenghiep = " & Nghenghiep & ",Capbac = " & Capbac & ",Madonvi = " & Madonvi & ",SotheTE =  " & TheTE & ", " _
            & "   Lienhe = " & Lienhe & ",Noigioithieu = " & Noigioithieu & ",ChandoanNGT = " & Chandoan & ", SoBANT = " & SoBANT & " " _
            & " where Mabenhnhan = '" & txtMabenhnhan.Text & "' and  MaKhambenh = '" & txtMaKhambenh.Text & "' "
            Cmd.ExecuteNonQuery()
            Tran.Commit()
            Cmd.Dispose()
            ViewControl("Start")
            booSua = False
            MsgBox("Đã lưu thông tin bệnh nhân", MsgBoxStyle.Information, "Message!")
            If txtTennoiDKKCBBD.ReadOnly = False Then
                ThemNoiKCBBD(txtManoiDKKCBBD.Text, txtTennoiDKKCBBD.Text)
                txtTennoiDKKCBBD.ReadOnly = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Tran.Rollback()
        End Try
    End Sub
    Private Sub CapNhatSoTheBHYT()
        Dim Tran As SqlTransaction
        Dim BHTu, BHDen As String
        If dtBHTu.Text = "" Then
            BHTu = "NULL"
        Else : BHTu = String.Format("'{0:MM/dd/yyyy}'", dtBHTu.Value)
        End If
        If dtBHDen.Text = "" Then
            BHDen = "NULL"
        Else : BHDen = String.Format("'{0:MM/dd/yyyy}'", dtBHDen.Value)
        End If
        Dim cmd As SqlCommand
        cmd = New SqlCommand("", Cn)
        Tran = Cn.BeginTransaction()
        Try
            cmd.Transaction = Tran
            cmd.CommandText = String.Format("DELETE FROM TTCANHANBHXH WHERE MATHE = '{0}'", txtSotheBHYT.Text)
            cmd.ExecuteNonQuery()
            cmd.CommandText = String.Format("INSERT INTO TTCANHANBHXH(Ma_KCB,MaThe,MaDT,HoTen,NamSinh,GioiTinh,DiaChi ,GiaTriTu,GiaTriDen,TenBHYTCap, Matinh) " _
                                            & " VALUES(N'{0}',N'{1}',N'{2}',N'{3},{4},{5},N'{6}', " & BHTu & "," & BHDen & ",N'{7}',N'{8}')", _
                                             VB6.Right(txtManoiDKKCBBD.Text.Trim(), 3), txtSotheBHYT.Text.Trim(), txtMaDT.Text.Trim(), txtTenbenhnhan.Text, txtTuoi.Value, 1 - cmbGioitinh.SelectedIndex(), txtDiachi.Text, txtTenBHYTTinh.Text, VB6.Left(txtManoiDKKCBBD.Text.Trim(), 2))
            cmd.ExecuteNonQuery()
            Tran.Commit()
        Catch ex As Exception
            Tran.Rollback()
        End Try
        Tran.Dispose()
    End Sub
    Private Sub cmdHuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHuy.Click
        If booThem = True Then SetEmpty()
        If booSua = True Then
            FillDataHC(txtMaKhambenh.Text)
            FillDanhsachPK(txtMaKhambenh.Text)
        End If
        ViewControl("Start")
    End Sub
    Private Sub grdYCK_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdYeucaukham.KeyUp
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim Dakham As Boolean
        Dim Tran As SqlTransaction
        ' Yeu cau xac nhan
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Bạn có chắc chắn muốn xóa dịch vụ khám này không ?", MsgBoxStyle.YesNo, "Cảnh báo!") = MsgBoxResult.No Then Exit Sub
            'Kiem tra xem co du dk xoa khong (  da thuc hien chua...)  
            SQl = "Select * from tblKhambenh_KQDVKHAM where  Mabenhnhan = '" & txtMabenhnhan.Text & "' and Makhambenh = '" & txtMaKhambenh.Text & "' and  MaphieuCD = N'" & grdYeucaukham.Item(grdYeucaukham.Row, 5).ToString.Trim() & "' " _
            & "  and HuongGQ <> 0"
            Dakham = False
            Cmd = New SqlCommand(SQl, Cn)
            rd = Cmd.ExecuteReader
            Do While rd.Read
                Dakham = True
            Loop
            rd.Close()
            If Dakham Then
                MsgBox("Đã khám, không cho phép xóa", MsgBoxStyle.Critical, "Message!")
                Exit Sub
            End If
            'Xoa trong data
            Tran = Cn.BeginTransaction()
            Try
                Dim KillCmd As New SqlCommand
                KillCmd.Connection = Cn
                KillCmd.Transaction = Tran
                KillCmd.Connection = Cn
                KillCmd.CommandText = "Delete from tblKhambenh_CHIDINH where MaphieuCD = N'" & grdYeucaukham.Item(grdYeucaukham.Row, 5) & "'"
                KillCmd.ExecuteNonQuery()
                KillCmd.CommandText = "Delete from tblKhambenh_DICHVU where MaphieuCD = N'" & grdYeucaukham.Item(grdYeucaukham.Row, 5) & "'"
                KillCmd.ExecuteNonQuery()
                KillCmd.CommandText = "Delete from tblKhambenh_KQDVKHAM where MaphieuCD = N'" & grdYeucaukham.Item(grdYeucaukham.Row, 5) & "'"
                KillCmd.ExecuteNonQuery()
                KillCmd.CommandText = "Delete from tblKhambenh_DONTHUOC where MaphieuCD = N'" & grdYeucaukham.Item(grdYeucaukham.Row, 5) & "'"
                KillCmd.ExecuteNonQuery()
                'Xoa trong grdYCK
                grdYeucaukham.RemoveItem(grdYeucaukham.Row)
                Tran.Commit()
                'Lam tuoi lai fgPhongkham
                Load_Phongkham(NgayHienTai, cmbDoituong_PK.SelectedValue)
                Load_DSBN(GetSrvDate())
                KillCmd.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        End If
    End Sub

    Private Sub txtMabenhnhan_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMabenhnhan.GotFocus
        Label18.ForeColor = Color.Red
    End Sub

    Private Sub txtMabenhnhan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMabenhnhan.LostFocus
        Label18.ForeColor = Color.Black
    End Sub

    Private Sub txtMabenhnhan_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMabenhnhan.Validated
        txtMabenhnhan.Text = Replace(txtMabenhnhan.Text, "'", "")
        AutoFill_Makhambenh(txtMabenhnhan)
        If booThem Then
            Select Case Len(txtMabenhnhan.Text)
                Case 0 ' Không nhập j vào ô mã bệnh nhân
                    Exit Sub
                Case Is < 10 ' Nhập chua đủ ký tự
                    MsgBox("Không có mã bệnh nhân là: " + txtMabenhnhan.Text, MsgBoxStyle.Critical, "Message!")
                    txtMabenhnhan.Text = ""
                    Exit Sub
                Case 10 ' Nhập 10 ký tự
                    ' Kiểm tra xem bệnh nhân và ngày khám bệnh đã có chưa
                    Dim Co As Boolean
                    Dim Last_Ngaykhamcuoi As Date
                    Dim MaKB As String = ""
                    KiemtraBenhnhan(txtMabenhnhan.Text, Co, Last_Ngaykhamcuoi, MaKB)
                    'nếu có 
                    If Co = True Then
                        'Kiểm tra xem ngày đăng ký khám cuối có = ngày hiện tại không
                        'Nếu = 
                        If DateDiff(DateInterval.Day, Last_Ngaykhamcuoi, GetSrvDate()) = 0 Then
                            '-  Message: Bệnh nhân đã đăng ký khám trong ngày
                            MsgBox("Bệnh nhân mã bệnh nhân là: " + txtMabenhnhan.Text + " đã đăng ký khám trong ngày", MsgBoxStyle.Critical, "Message!")
                            '-  Load các dịch vụ đã khám trong ngày
                            FillDataHC(MaKB)
                            FillDanhsachPK(MaKB)
                            '-  Chuyển về hiển thị Thêm Sửa Xóa như ban đầu
                            ViewControl("Start")
                        Else
                            '-Nếu ngày khám cuối < ngày hiện tại: (Trường hợp bệnh nhân đã từng đăng ký khám trước đó)
                            '-  Ko cần Message. Vẫn để nút Ghi – Không ghi
                            '-  Load các thông tin bệnh nhân, lần khám trước, gán mã khám bệnh = “”, Thoigiandangky = Thoigianhientai 
                            FillDataHC(MaKB)
                            txtMaKhambenh.Text = ""
                            txtThoigianDangky.Value = GetSrvDate()
                            '-  Bấm chọn dịch vụ, phòng khám và bấm nút (+): Khi đó sẽ thêm lần khám, dịch vụ khám
                            '- > Trạng thái ban đầu.
                        End If
                    Else ' Nếu chưa đăng ký lần nào
                        '- Message: Mã bệnh nhân chưa có
                        MsgBox("Mã bệnh nhân: " + txtMabenhnhan.Text + " chưa có trong dữ liệu.", MsgBoxStyle.Critical, "Message!")
                        '- Xóa trắng mã bệnh nhân
                        txtMabenhnhan.Text = ""
                        '- Tiếp tục nhập như thêm mới
                        Exit Sub
                    End If
            End Select
        End If
    End Sub
    Private Sub cmbPhongkham_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPhongkham.LostFocus
        'If booThem Then
        Label15.ForeColor = Color.Black
        'If Len(Trim(cmbPhongkham.Text)) = 3 Then
        '    cmbPhongkham.SelectedValue = "K" + Trim(cmbPhongkham.Text)
        '    Exit Sub 
        'End If
        'If Len(Trim(cmbPhongkham.Text)) = 4 Then
        '    cmbPhongkham.SelectedValue = Trim(cmbPhongkham.Text)
        '    Exit Sub
        'End If
        If Len(Trim(cmbPhongkham.Text)) = 3 Then
            cmbPhongkham.SelectedValue = "NV13" + Trim(cmbPhongkham.Text)
            Exit Sub
        End If
    End Sub

    Private Sub cmbDoituong_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDoituong.GotFocus
        Label4.ForeColor = Color.Red
    End Sub
    Private Sub cmbDoituong_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDoituong.Validated
        If booThem Or booSua Then
            If Trim(cmbDoituong.Text) <> "" And cmbDoituong.SelectedValue = Nothing Then
                MsgBox("Chưa chọn đúng đối tượng", MsgBoxStyle.Critical, "Message!")
                cmbDoituong.Focus()
            End If
        End If
    End Sub

    'Private Sub cmbTinh_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If booThem Or booSua Then
    '        If Trim(cmbTinh_TP.Text) <> "" And cmbTinh_TP.SelectedValue = "" Then
    '            MsgBox("Chưa chọn đúng tỉnh - thành phố", MsgBoxStyle.Critical, "Message!")
    '            cmbTinh_TP.Focus()
    '        End If
    '    End If
    'End Sub
    'Private Sub cmbDonvi_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If booThem Or booSua Then
    '        If Trim(cmbDonvi.Text) <> "" And cmbDonvi.SelectedValue = "" Then
    '            MsgBox("Chưa chọn đúng đơn vị", MsgBoxStyle.Critical, "Message!")
    '            cmbDonvi.Focus()
    '        End If
    '    End If
    'End Sub

    Private Sub cmbYCKham_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbYeucaukham.Validated
        If booThem Or booSua Then
            If Trim(cmbYeucaukham.Text) <> "" And cmbYeucaukham.SelectedValue = "" Then
                MsgBox("Chưa chọn đúng yêu cầu khám", MsgBoxStyle.Critical, "Message!")
                cmbYeucaukham.Focus()
            End If
        End If
    End Sub
    Private Sub cmbPhongkham_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPhongkham.Validated
        'If (booThem Or booSua) Then
        '    If Trim(cmbPhongkham.Text) <> "" And cmbPhongkham.SelectedValue = "" Then 'And Val(Trim(cmbPhongkham.Text)) < 1
        '        MsgBox("Chưa chọn đúng phòng khám", MsgBoxStyle.Critical, "Message!")
        '        cmbPhongkham.Focus()
        '    End If
        'End If
    End Sub
    Private Sub Load_DanhsachBN(ByVal Ngay As Date, ByVal ten As String)
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim i As Integer
        If IsDBNull(Ngay) Then Exit Sub
        fgDanhsachBN.Rows.Count = 1
        If txtNgaykhamT.Enabled Then
            SQl = " Select P.Mabenhnhan, tblKhambenh.Makhambenh,Q.MaphieuCD, Tenbenhnhan, Namsinh, Gioitinh,DMDoituongBN.TenDT," _
                 & " tblKhambenh.ChandoanNGT, DMKhoaphong.Tenkhoa from tblkhambenh " _
                 & " inner join (select * from tblBenhnhan where tblBenhnhan.tenbenhnhan Like N'%" & ten & "%') P on P.Mabenhnhan = tblKhambenh.Mabenhnhan " _
                 & " inner join (select * from tblkhambenh_KQDVKHAM where left(MaphieuCD,2) = 'PK')Q " _
                 & " on tblKhambenh.Makhambenh =  Q.Makhambenh " _
                 & " inner join DMKhoaphong on DMKhoaphong.Makhoa = Q.Khoathuchien  " _
                 & " inner join DMDoituongBN on tblkhambenh.Doituong = DMDoituongBN.MaDT  " _
                 & " where  Datediff(day,tblkhambenh.ThoigianDangky ,'" & Format(txtNgaykhamT.Value, "MM/dd/yyyy") & "') = 0"
        Else
            SQl = " Select P.Mabenhnhan, tblKhambenh.Makhambenh,Q.MaphieuCD, Tenbenhnhan, Namsinh, Gioitinh,DMDoituongBN.TenDT," _
                & " tblKhambenh.ChandoanNGT, DMKhoaphong.Tenkhoa from tblkhambenh " _
                & " inner join (select * from tblBenhnhan where tblBenhnhan.tenbenhnhan Like N'%" & ten & "%') P on P.Mabenhnhan = tblKhambenh.Mabenhnhan " _
                & " inner join (select * from tblkhambenh_KQDVKHAM where left(MaphieuCD,2) = 'PK')Q " _
                & " on tblKhambenh.Makhambenh =  Q.Makhambenh " _
                & " inner join DMKhoaphong on DMKhoaphong.Makhoa = Q.Khoathuchien  " _
                & " inner join DMDoituongBN on tblkhambenh.Doituong = DMDoituongBN.MaDT  "
        End If
        '(select  distinct mabenhnhan from tblKhambenh  where ngaykham = '" & Ngay & "' group by Mabenhnhan)Q " _
        Cmd = New SqlCommand(SQl, Cn)
        rd = Cmd.ExecuteReader
        fgDanhsachBN.Redraw = False
        Do While rd.Read
            i = i + 1
            fgDanhsachBN.AddItem(Trim(Str(i)) & vbTab & rd!Tenbenhnhan & vbTab & IIf(rd!Gioitinh = 1, "Nam", "Nữ") & vbTab & rd!Namsinh & vbTab & rd!TenDT & vbTab & rd!Tenkhoa & vbTab & rd!ChandoanNGT & vbTab & rd!Mabenhnhan & vbTab & rd!MaKhambenh & vbTab & rd!MaphieuCD)
        Loop
        fgDanhsachBN.AutoSizeCols()
        fgDanhsachBN.Redraw = True
        rd.Close()
        rd = Nothing
        lblTongsoBN.Text = "Tổng số phiếu khám: " + Str(fgDanhsachBN.Rows.Count - 1)
    End Sub
    Private Sub Load_DSBN(ByVal Ngay As Date)
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim i As Integer
        If IsDBNull(Ngay) Then Exit Sub
        grdDSBN.Rows.Count = 1
        SQl = " Select tblBenhnhan.Mabenhnhan, tblKhambenh.Makhambenh,  Tenbenhnhan, Namsinh, Gioitinh,DMDoituongBN.TenDT, tblKhambenh.Diachi  from tblkhambenh " _
         & " inner join tblBenhnhan on tblKhambenh.Mabenhnhan = tblBenhnhan.Mabenhnhan " _
         & " inner join DMDoituongBN on tblkhambenh.Doituong = DMDoituongBN.MaDT   " _
         & " where  Datediff(day,tblkhambenh.ThoigianDangky ,'" & Format(Ngay, "MM/dd/yyyy") & "') = 0"
        Cmd = New SqlCommand(SQl, Cn)
        rd = Cmd.ExecuteReader
        grdDSBN.Redraw = False
        Do While rd.Read
            i = i + 1
            grdDSBN.AddItem(Trim(Str(i)) & vbTab & rd!Tenbenhnhan & vbTab & IIf(rd!Gioitinh = 1, "Nam", "Nữ") & vbTab & rd!Namsinh & vbTab & rd!TenDT & vbTab & rd!Diachi.ToString & vbTab & "" & vbTab & rd!Mabenhnhan & vbTab & rd!MaKhambenh & vbTab & "")
        Loop
        grdDSBN.Redraw = True
        rd.Close()
        rd = Nothing
    End Sub
    Private Sub cmdTimkiem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimkiem.Click
        panDSBenhnhan.Visible = True
        panDSBenhnhan.BringToFront()
    End Sub
    Private Sub cmdXem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXem.Click
        Load_DanhsachBN(txtNgaykhamT.Value, txtTenbenhnhanT.Text)
    End Sub
    Private Sub cmdDong_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDong.Click
        panDSBenhnhan.Visible = False
    End Sub
    Private Sub fgDanhsachBN_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles fgDanhsachBN.DoubleClick
        If fgDanhsachBN.Rows.Count = 1 Then Exit Sub
        If fgDanhsachBN.Item(fgDanhsachBN.Row, 8) <> "" Then
            FillDataHC(fgDanhsachBN.Item(fgDanhsachBN.Row, 8))
            FillDanhsachPK(fgDanhsachBN.Item(fgDanhsachBN.Row, 8))
            panDSBenhnhan.Visible = False
        End If
    End Sub

    Private Sub txtTenbenhnhan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTenbenhnhan.KeyDown
        If Not (booThem Or booSua) And e.KeyCode <> Keys.F5 And e.KeyCode <> Keys.F9 And e.KeyCode <> Keys.F10 Then
            MsgBox("Phải kích nút Thêm hoặc Sửa", MsgBoxStyle.Critical, "Cảnh báo!")
        End If
    End Sub
    'trần thị tính
    '    thanh toán 31/3/2014
    '    số lưu trữ 1835
    '    bnbh

    Private Sub txtSotheBHYT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSotheBHYT.KeyDown
        If Not (booThem Or booSua) And e.KeyCode <> Keys.F5 And e.KeyCode <> Keys.F9 And e.KeyCode <> Keys.F10 Then
            MsgBox("Phải kích nút Thêm hoặc Sửa", MsgBoxStyle.Critical, "Cảnh báo!")
        End If
    End Sub
    Private Sub txtSotheBHYT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSotheBHYT.Validated
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader = Nothing
        Dim NgaykhamCu As Date
        Dim MaKB As String = ""
        Try
            If Trim(txtSotheBHYT.Text) = "01" Then Exit Sub
            If (booThem Or booSua) And Trim(txtSotheBHYT.Text) <> "" Then
                txtSotheBHYT.Text = UCase(Trim(txtSotheBHYT.Text))
                If txtSotheBHYT.Text.Length() <> 0 And txtSotheBHYT.Text.Length() <> 2 And txtSotheBHYT.Text.Length() <> 11 And txtSotheBHYT.Text.Length() <> 13 Then
                    MsgBox("Chiều dài số thẻ sai (11 hoặc 13)", MsgBoxStyle.Critical, "Cảnh báo!")
                    Exit Sub
                End If
                ' Kiem tra lan kham gan nhat
                NgaykhamCu = "01/01/2000"
                SQl = " Select isnull(ThoigianDangky,'01/01/2000') as Ngaykham , isnull(Makhambenh,'') as MaKB from  tblKHAMBENH " _
                & " where tblKHAMBENH.Doituongthe = '" & Replace(txtMaDT.Text, "'", "''") & "' and tblKHAMBENH.SotheBHYT = N'" & Replace(txtSotheBHYT.Text, "'", "''") & "' order by ThoigianDangky Desc"
                Cmd = New SqlCommand(SQl, Cn)
                rd = Cmd.ExecuteReader
                Do While rd.Read
                    NgaykhamCu = rd!Ngaykham
                    MaKB = rd!MaKB
                    Exit Do
                Loop
                rd.Close()
                rd = Nothing

                Dim Ngay1, Ngay2 As Date

                Ngay1 = New Date(NgaykhamCu.Year, NgaykhamCu.Month, NgaykhamCu.Day, 0, 0, 0)
                Ngay2 = New Date(NgayHienTai.Year, NgayHienTai.Month, NgayHienTai.Day, 0, 0, 0)
                'Dùng hàm này thì khi độ lệch giữa hai thời gian dưới 24h sẽ cho kết quả là 0 nên xảy ra hiện tượng bệnh nhân đến khám 
                ' ngày hôm qua và hôm nay đến khám tiếp mà đến sớm hơn thời gian khám hôm qua sẽ cho kết quả là đã đăng ký khám trong ngày
                Dim x As Integer = DateDiff(DateInterval.Day, Ngay1, Ngay2)

                'If NgaykhamCu <> "01/01/2000" And DateDiff(DateInterval.Day, NgaykhamCu, Ngayhientai) > 0 Then
                If NgaykhamCu <> "01/01/2000" And x > 0 Then
                    lblLankhamcuoi.Visible = True
                    lblLankhamcuoi.Text = "       Lần khám gần nhất cách " + Trim(Str(DateDiff(DateInterval.Day, NgaykhamCu, NgayHienTai))) + " ngày (" + Format(NgaykhamCu, "dd/MM/yyyy") + ")"
                    LayThongtinHC(MaKB)
                Else
                    lblLankhamcuoi.Visible = False
                    lblLankhamcuoi.Text = "       Lần khám gần nhất"
                    'Dien thong tin tu TTCaNhanBHXH
                    SQl = "SELECT * FROM " & TenDatabase & ".DBO.DMTHE_BHYT WHERE MaThe='" & Replace(txtSotheBHYT.Text, "'", "''") & "'"
                    Cmd = New SqlCommand(SQl, Cn)
                    rd = Cmd.ExecuteReader
                    Do While rd.Read
                        txtTenbenhnhan.Text = rd!HoTen.ToString()
                        txtDiachi.Text = rd!DiaChi.ToString() + ""
                        txtTuoi.Value = CDec(Val(rd!NamSinh))
                        cmbGioitinh.SelectedIndex = 1 - CDec(Val(rd!GioiTInh))
                        txtMaDT.Text = rd!MaDT.ToString()
                        txtManoiDKKCBBD.Text = (rd!Matinh + rd!ma_kcb).ToString
                        dtBHTu.Value = rd!GiaTriTu
                        dtBHDen.Value = rd!GiaTriden
                        txtTenBHYTTinh.Text = IIf(IsDBNull(rd!TenBHYTCap), " ", rd!TenBHYTCap)
                        rd.Close()
                        Me.txtMaDT_Validated(Nothing, Nothing)
                        txtTenbenhnhan.Text = UCase(Trim(txtTenbenhnhan.Text))
                        cmbPhongkham.Focus()
                        Exit Do
                    Loop
                    rd.Close()
                End If
                'If NgaykhamCu <> "01/01/2000" And DateDiff(DateInterval.Day, NgaykhamCu, Ngayhientai) = 0 Then
                If NgaykhamCu <> "01/01/2000" And x = 0 Then
                    lblLankhamcuoi.Visible = True
                    lblLankhamcuoi.Text = "       Bệnh nhân đã đăng ký khám trong ngày: " + Format(NgaykhamCu, "dd/MM/yyyy")
                End If
                Dim s As String = Mid(txtSotheBHYT.Text, 2, 2)
                If Mid(txtSotheBHYT.Text.Trim, 2, 2) = "97" Or (txtSotheBHYT.Text.Trim.Length() = 11 And Mid(txtSotheBHYT.Text.Trim, 1, 2) = "97") Then txtTenBHYTTinh.Text = "Quân đội"
                If Mid(txtSotheBHYT.Text.Trim, 2, 2) = "01" Then txtTenBHYTTinh.Text = TinhTP
            End If
            txtManoiDKKCBBD_Validated(sender, e)
            Exit Sub
        Catch ex As Exception
            rd.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LayThongtinHC(ByVal MaKB As String)
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        If MaKB = "" Then Exit Sub
        SQl = " Select tblKHAMBENH.*, tblBENHNHAN.MaBenhnhan, tblBENHNHAN.TenBenhnhan,tblBENHNHAN.Namsinh,tblBENHNHAN.Gioitinh, " _
        & " DMDTTHE_BHYT.TenDT as TenDTThe,DMNOIDKKCBBD_BHYT.Tennoicap from  tblKHAMBENH " _
        & " LEFT OUTER JOIN tblBENHNHAN on tblKHAMBENH.Mabenhnhan =  tblBENHNHAN.mabenhnhan" _
        & " left join DMDTTHE_BHYT on tblKhambenh.Doituongthe  = DMDTTHE_BHYT.MaDT " _
        & " left join DMNOIDKKCBBD_BHYT on tblKhambenh.NoidangkyKCBBD  = DMNOIDKKCBBD_BHYT.Manoicap " _
        & " left join DMDOITUONGBN on tblKhambenh.Doituong  = DMDOITUONGBN.MaDT " _
        & " left join DMNGHENGHIEP on tblKhambenh.Nghenghiep  = DMNGHENGHIEP.MaNghenghiep " _
        & " where tblKHAMBENH.makhambenh = N'" & Replace(MaKB, "'", "''") & "' order by ThoigianDangky Desc"
        Cmd = New SqlCommand(SQl, Cn)
        rd = Cmd.ExecuteReader
        Do While rd.Read
            'Khi load thêm thông tin mã bệnh nhân thì bệnh nhân sẽ được thêm vào với mã bệnh nhân cũ và mã khám bệnh cũ
            'Tuy nhiên trong mục tìm kiếm bệnh nhân sẽ load hết tất cả các lần đăng ký khám của bệnh nhân đó
            ' Và nếu trong trường hợp xoá đăng ký khám (khác với xoá phiếu khám) thì sẽ xoá luôn cả bệnh nhân 
            ' -> Cần phải xem xét và kiểm tra lại
            'txtMabenhnhan.Text = rd!MaBenhnhan.ToString()
            txtTenbenhnhan.Text = rd!TenBenhnhan.ToString()
            txtDiachi.Text = rd!Diachi.ToString()
            txtTuoi.Value = rd!NamSinh
            cmbGioitinh.SelectedIndex = IIf(rd!Gioitinh, 0, 1)
            cmbCapbac.SelectedValue = rd!Capbac.ToString()
            txtMaDT.Text = rd!DoituongThe.ToString()
            txtTenDT.Text = rd!TenDTThe.ToString()
            txtManoiDKKCBBD.Text = rd!NoidangkyKCBBD.ToString()
            txtTennoiDKKCBBD.Text = rd!Tennoicap.ToString()
            dtBHTu.Value = rd!HantheBHYT_Tu
            dtBHDen.Value = rd!HantheBHYT_Den
            txtTenBHYTTinh.Text = rd!NoicaptheBHYT.ToString()
            cmbNghenghiep.SelectedValue = rd!Nghenghiep.ToString()
            txtNoicongtac.Text = rd!Noicongtac.ToString()
            txtLienhe.Text = rd!Lienhe.ToString()
            txtSoBANT.Text = rd!SoBANT.ToString()
            cmbPhongkham.Focus()
            Exit Do
        Loop
        rd.Close()
        rd = Nothing
    End Sub

    Private Sub cmdThemPhieukham_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThemPhieukham.Click
        Dim TenBenhnhan, Namsinh, Gioitinh, Tuyen
        Dim Doituong, Diachi, Nghenghiep, Capbac, MaDonvi, Noicongtac, Lienhe, TheTE, Noigioithieu, Chandoan, ThoigianDangky
        Dim SotheBHYT, Doituongthe_BHYT, NoiDKKCBBD_BHYT, BHYTTu, BHYTDen, BHXHTinh, SoBANT As String
        Dim Capcuu, ThoigianChidinh, Dichvukham, Phongkham, Thutukham
        Dim Tran As SqlTransaction
        Dim i
        Dim Cmd As New SqlCommand
        If Not KiemtraHL() Then
            Exit Sub
        End If

        'Dem so benh nhan : neu > 15 benh nhan mot ngay thi khong cho tiep nhan them nua
        Dim Sql_Check = ""
        Sql_Check = "SELECT count(MaKhamBenh) as SoBenhNhan FROM tblKhambenh WHERE datediff(dd,ThoiGianDangKy,Getdate()) = 0"
        Dim Cmd_check As New SqlCommand(Sql_Check, Cn)
        Dim isSoBenhNhan As Integer
        isSoBenhNhan = Cmd_check.ExecuteScalar()
        If isSoBenhNhan >= 15 Then
            MessageBox.Show("Đây là bản dùng thử, bạn chỉ có thể tiếp nhận 15 bệnh nhân một ngày!. Vui lòng liên hệ với nhà cung cấp để có bản đầy đủ!")
            Cmd_check.Dispose()
            Exit Sub
        End If
        Cmd_check.Dispose()


        If Trim(cmbYeucaukham.SelectedValue) = "" Then
            MsgBox("Phải nhập yêu cầu khám", MsgBoxStyle.Information, "Message !")
            cmbYeucaukham.Focus()
            Exit Sub
        End If
        If Trim(cmbPhongkham.SelectedValue) = "" Then
            MsgBox("Phải nhập phòng khám", MsgBoxStyle.Information, "Message !")
            cmbPhongkham.Focus()
            Exit Sub
        End If
        TenBenhnhan = "N'" & Replace(Trim(txtTenbenhnhan.Text), "'", "''") & "'"
        Namsinh = ""
        If txtTuoi.Value Is System.DBNull.Value Then
            Namsinh = "null"
        Else
            Namsinh = txtTuoi.Value.ToString()
        End If
        Gioitinh = IIf(cmbGioitinh.Text = "Nam", 1, 0)
        Doituong = "N'" & Replace(Trim(cmbDoituong.SelectedValue), "'", "''") & "'"
        Diachi = "N'" & Replace(Trim(txtDiachi.Text), "'", "''") & "'"
        Nghenghiep = "N'" & Replace(Trim(cmbNghenghiep.SelectedValue), "'", "''") & "'"
        Capbac = "N'" & Replace(Trim(cmbCapbac.SelectedValue), "'", "''") & "'"
        MaDonvi = "N'" & Replace(Trim(cmbDonvi.SelectedValue), "'", "''") & "'"
        Noicongtac = "N'" & Replace(Trim(cmbDonvi.Text), "'", "''") & "'"
        Lienhe = "N'" & Replace(Trim(txtLienhe.Text), "'", "''") & "'"
        TheTE = "N'" & Replace(Trim(txtTheTE.Text), "'", "''") & "'"
        Noigioithieu = "N'" & Replace(Trim(txtNoigioithieu.Text), "'", "''") & "'"
        Chandoan = "N'" & Replace(Trim(txtChandoan.Text), "'", "''") & "'"
        SoBANT = "N'" & Replace(Trim(txtSoBANT.Text), "'", "''") & "'"
        ThoigianDangky = txtThoigianDangky.Value

        Tuyen = cmbTuyen.SelectedIndex
        If Tuyen = -1 Then Tuyen = 0
        SotheBHYT = "N'" & Replace(Trim(txtSotheBHYT.Text), "'", "''") & "'"
        Doituongthe_BHYT = "N'" & Replace(Trim(txtMaDT.Text), "'", "''") & "'"
        NoiDKKCBBD_BHYT = "N'" & Replace(Trim(txtManoiDKKCBBD.Text), "'", "''") & "'"
        If dtBHTu.Text = "" Then
            BHYTTu = "NULL"
        Else : BHYTTu = String.Format("'{0:MM/dd/yyyy}'", dtBHTu.Value)
        End If
        If dtBHDen.Text = "" Then
            BHYTDen = "NULL"
        Else : BHYTDen = String.Format("'{0:MM/dd/yyyy}'", dtBHDen.Value)
        End If
        BHXHTinh = "N'" & Replace(Trim(txtTenBHYTTinh.Text), "'", "''") & "'"

        Capcuu = IIf(optKhamthuong.Checked, 0, 1)
        ThoigianChidinh = GetSrvDate()
        Dichvukham = cmbYeucaukham.SelectedValue
        Phongkham = cmbPhongkham.SelectedValue
        Thutukham = Get_MaxThutu(cmbPhongkham.SelectedValue, txtThoigianChidinh.Value)
        If txtMabenhnhan.Text = "" Then 'Truong hop A. Nếu không nhập mã bệnh nhân -> Là BN mới -> thêm mới hoàn toàn
            Tran = Cn.BeginTransaction()
            Try
                Cmd.Connection = Cn
                Cmd.Transaction = Tran
                Cmd.CommandText = "Select Getdate()"
                Dim ThoigianHT = ThoigianDangky 'Cmd.ExecuteScalar()
                'Thêm bệnh nhân
                Cmd.CommandText = "Select " & TenDatabase & ".DBO.LayMaBenhNhan('" & Format(ThoigianHT, "yyMMdd") & "')" _
                & " Insert into tblBenhnhan ( MaBenhnhan, TenBenhnhan, " _
                & "   Namsinh,Gioitinh) " _
                & " values ( " & TenDatabase & ".DBO.LayMaBenhNhan('" & Format(ThoigianHT, "yyMMdd") & "') , " _
                & " " & TenBenhnhan & " , " & Namsinh & ", " & Gioitinh & " ) "

                txtMabenhnhan.Text = Cmd.ExecuteScalar().ToString
                'Thêm lần khám
                Cmd.CommandText = "Select " & TenDatabase & ".DBO.LayMaKhambenh('" & Format(ThoigianHT, "yyMMdd") & "')" _
                & " Insert into tblKhambenh ( MaBenhnhan, MaKhambenh, " _
                & "   ThoigianDangky,Doituong, " _
                & "   Diachi,Noicongtac, Tuyen," _
                & "   SotheBHYT,Doituongthe, " _
                & "   NoidangkyKCBBD,HantheBHYT_Tu, " _
                & "   HantheBHYT_Den,NoicaptheBHYT, " _
                & "   Nghenghiep,Capbac,Madonvi,SotheTE, " _
                & "   Lienhe,Noigioithieu,ChandoanNGT, SoBANT ) " _
                & " values ( '" & txtMabenhnhan.Text & "'," & TenDatabase & ".DBO.LayMaKhambenh('" & Format(ThoigianHT, "yyMMdd") & "') , " _
                & " '" & Format(ThoigianDangky, "MM/dd/yyyy HH:mm:ss") & "' , " & Doituong & ", " _
                & " " & Diachi & " , " & Noicongtac & ", " & Tuyen & ", " _
                & " " & SotheBHYT & " , " & Doituongthe_BHYT & ", " _
                & " " & NoiDKKCBBD_BHYT & " , " & BHYTTu & ", " _
                & " " & BHYTDen & " , " & BHXHTinh & ", " _
                & " " & Nghenghiep & " ," & Capbac & " ," & MaDonvi & " , " & TheTE & ", " _
                & " " & Lienhe & " , " & Noigioithieu & ",  " & Chandoan & " ,  " & SoBANT & " ) "
                txtMaKhambenh.Text = Cmd.ExecuteScalar().ToString
                'Thêm phiếu khám vào tblKHAMBENH_CHIDINH
                Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','PK','','',''", txtMabenhnhan.Text, txtMaKhambenh.Text, "PK", ThoigianHT, MaKhoaphong, TenDangNhap, cmbYeucaukham.SelectedValue, Capcuu)
                Dim MaPK As String = Cmd.ExecuteScalar() ' Lấy mã phiếu khám mới
                'Thêm Dịch vụ vào tblKHAMBENH_DICHVU
                Cmd.CommandText = "Insert into tblKHAMBENH_DICHVU ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                & " MaDichvu,DVT,Soluong,KhoaThuchien,Daduyet,DaThuchien,Ghichu) " _
                & " values ( '" & txtMabenhnhan.Text & "','" & txtMaKhambenh.Text & "', " _
                & " '" & MaPK & "','" & cmbYeucaukham.SelectedValue & "', " _
                & "  N'Lần',1, " _
                & "  '" & cmbPhongkham.SelectedValue & "', " _
                & " 0, 0,'') "
                Cmd.ExecuteNonQuery()
                'Thêm Dịch vụ vào tblKHAMBENH_KQDVKHAM
                Cmd.CommandText = "Insert into tblKHAMBENH_KQDVKHAM ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                & " MaDichvu, Khoathuchien,ThutuKham,HuongGQ) " _
                & " values ( '" & txtMabenhnhan.Text & "','" & txtMaKhambenh.Text & "', " _
                & " '" & MaPK & "','" & cmbYeucaukham.SelectedValue & "', " _
                & " '" & cmbPhongkham.SelectedValue & "', " _
                & " " & Thutukham & " , 0 ) "
                Cmd.ExecuteNonQuery()
                If Not Duoc_Them_BN Then
                    'Cmd.CommandText = "Insert into " & TenDatabase & ".DBO.MAC_LOG(MAC,Chucnang,Thoigian,Tendangnhap,Mabenhnhan ) " _
                    '& " values ( '" & Get_MAC_Address() & "','Tiepdon', " _
                    '& " '" & Format(ThoigianHT, "MM/dd/yyyy HH:mm") & "','" & TenDangNhap & "','" & txtMabenhnhan.Text & "') "
                    'Cmd.ExecuteNonQuery()
                End If
                Tran.Commit()
                Cmd.Dispose()
                ViewControl("Start")
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        Else 'Truong hop B. Nếu có mã bệnh nhân -> Là BN cũ  '''
            'Kiểm tra xem đã có PK này trong danh sách chưa, nếu có rồi không cho thêm nữa
            'If grdYeucaukham.Rows.Count > 1 Then
            '    For i = 1 To grdYeucaukham.Rows.Count - 1
            '        If cmbPhongkham.SelectedValue = grdYeucaukham.Item(i, 0) Then
            '            MsgBox("Phòng khám đã có trong danh sách. Không được thêm mới!", MsgBoxStyle.Critical, "Message!")
            '            Exit Sub
            '        End If
            '    Next
            'End If
            If cmdThem.Visible = True And DateDiff(DateInterval.Day, txtThoigianDangky.Value, GetSrvDate()) = 0 Then 'Truong hop B1. Nếu đã đăng ký khám rồi,
                ' có thể là khám trong ngày khi gõ mã trong lúc bấm Thêm
                'có thể là khám ngày nào đó khi tìm phiếu khám - > kích đúp
                'If DateDiff(DateInterval.Day, txtThoigianDangky.Value, GetSrvDate()) <> 0 Then
                '    'Kiểm tra xem có phải đang ở trạng thái xem lại phiếu khám ngày trước hay ko
                '    ' Nếu đúng ko cho thêm phiếu khám cho ngày đăng ký trước đó
                '    MsgBox("Không được thêm phiếu khám cho ngày trước!", MsgBoxStyle.Critical, "Message!")
                '    Exit Sub
                'End If
                'Nếu khám trong ngày, khi đó đã có Mã bệnh nhân, Mã khám bệnh chỉ thêm dịch vụ mới
                Tran = Cn.BeginTransaction()
                Try
                    Cmd.Connection = Cn
                    Cmd.Transaction = Tran
                    Cmd.CommandText = "Select Getdate()"
                    Dim ThoigianHT = Cmd.ExecuteScalar()
                    'Thêm phiếu khám vào tblKHAMBENH_CHIDINH
                    Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','PK','','',''", txtMabenhnhan.Text, txtMaKhambenh.Text, "PK", ThoigianHT, MaKhoaphong, TenDangNhap, cmbYeucaukham.SelectedValue, Capcuu)
                    Dim MaPK As String = Cmd.ExecuteScalar() ' Lấy mã phiếu khám mới
                    'Thêm Dịch vụ vào tblKHAMBENH_DICHVU
                    Cmd.CommandText = "Insert into tblKHAMBENH_DICHVU ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaDichvu,DVT,Soluong,KhoaThuchien,Daduyet,DaThuchien,Ghichu) " _
                    & " values ( '" & txtMabenhnhan.Text & "','" & txtMaKhambenh.Text & "', " _
                    & " '" & MaPK & "','" & cmbYeucaukham.SelectedValue & "', " _
                    & "  N'Lần',1, " _
                    & "  '" & cmbPhongkham.SelectedValue & "', " _
                    & " 0, 0,'') "
                    Cmd.ExecuteNonQuery()
                    'Thêm Dịch vụ vào tblKHAMBENH_KQDVKHAM
                    Cmd.CommandText = "Insert into tblKHAMBENH_KQDVKHAM ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaDichvu, Khoathuchien,ThutuKham,HuongGQ) " _
                    & " values ( '" & txtMabenhnhan.Text & "','" & txtMaKhambenh.Text & "', " _
                    & " '" & MaPK & "','" & cmbYeucaukham.SelectedValue & "', " _
                    & " '" & cmbPhongkham.SelectedValue & "', " _
                    & " " & Thutukham & " , 0 ) "
                    Cmd.ExecuteNonQuery()
                    If Not Duoc_Them_BN Then
                        'Cmd.CommandText = "Insert into " & TenDatabase & ".DBO.MAC_LOG(MAC,Chucnang,Thoigian,Tendangnhap,Mabenhnhan ) " _
                        '& " values ( '" & Get_MAC_Address() & "','Tiepdon', " _
                        '& " '" & Format(ThoigianHT, "MM/dd/yyyy HH:mm") & "','" & TenDangNhap & "','" & txtMabenhnhan.Text & "') "
                        'Cmd.ExecuteNonQuery()
                    End If
                    Tran.Commit()
                    Cmd.Dispose()
                    ViewControl("Start")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Tran.Rollback()
                End Try
            Else 'Truong hop B2. Nếu đã đăng ký khám lần trước rồi, 
                'khi đó đã có Mã bệnh nhân,thêm lần khám + dịch vụ mới
                Tran = Cn.BeginTransaction()
                Try
                    Cmd.Connection = Cn
                    Cmd.Transaction = Tran
                    Cmd.CommandText = "Select Getdate()"
                    Dim ThoigianHT = Cmd.ExecuteScalar()
                    'Thêm lần khám

                    Cmd.CommandText = "Select " & TenDatabase & ".DBO.LayMaKhambenh('" & Format(ThoigianHT, "yyMMdd") & "')" _
                    & " Insert into tblKhambenh ( MaBenhnhan, MaKhambenh, " _
                    & "   ThoigianDangky,Doituong, " _
                    & "   Diachi,Noicongtac, Tuyen," _
                    & "   SotheBHYT,Doituongthe, " _
                    & "   NoidangkyKCBBD,HantheBHYT_Tu, " _
                    & "   HantheBHYT_Den,NoicaptheBHYT, " _
                    & "   Nghenghiep,Capbac,Madonvi,SotheTE, " _
                    & "   Lienhe,Noigioithieu,ChandoanNGT, SoBANT ) " _
                    & " values ( '" & txtMabenhnhan.Text & "'," & TenDatabase & ".DBO.LayMaKhambenh('" & Format(ThoigianHT, "yyMMdd") & "') , " _
                    & " '" & Format(ThoigianHT, "MM/dd/yyyy HH:mm:ss") & "' , " & Doituong & ", " _
                    & " " & Diachi & " , " & Noicongtac & ", " & Tuyen & ", " _
                    & " " & SotheBHYT & " , " & Doituongthe_BHYT & ", " _
                    & " " & NoiDKKCBBD_BHYT & " , " & BHYTTu & ", " _
                    & " " & BHYTDen & " , " & BHXHTinh & ", " _
                    & " " & Nghenghiep & " ," & Capbac & " ," & MaDonvi & " , " & TheTE & ", " _
                    & " " & Lienhe & " , " & Noigioithieu & ",  " & Chandoan & " ,  " & SoBANT & " ) "
                    txtMaKhambenh.Text = Cmd.ExecuteScalar().ToString
                    'Thêm phiếu khám vào tblKHAMBENH_CHIDINH
                    Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','PK','','',''", txtMabenhnhan.Text, txtMaKhambenh.Text, "PK", ThoigianHT, MaKhoaphong, TenDangNhap, cmbYeucaukham.SelectedValue, Capcuu)
                    Dim MaPK As String = Cmd.ExecuteScalar() ' Lấy mã phiếu khám mới
                    'Thêm Dịch vụ vào tblKHAMBENH_DICHVU
                    Cmd.CommandText = "Insert into tblKHAMBENH_DICHVU ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaDichvu,DVT,Soluong,KhoaThuchien,Daduyet,DaThuchien,Ghichu) " _
                    & " values ( '" & txtMabenhnhan.Text & "','" & txtMaKhambenh.Text & "', " _
                    & " '" & MaPK & "','" & cmbYeucaukham.SelectedValue & "', " _
                    & "  N'Lần',1, " _
                    & "  '" & cmbPhongkham.SelectedValue & "', " _
                    & " 0, 0,'') "
                    Cmd.ExecuteNonQuery()
                    'Thêm Dịch vụ vào tblKHAMBENH_KQDVKHAM
                    Cmd.CommandText = "Insert into tblKHAMBENH_KQDVKHAM ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaDichvu, Khoathuchien,ThutuKham,HuongGQ) " _
                    & " values ( '" & txtMabenhnhan.Text & "','" & txtMaKhambenh.Text & "', " _
                    & " '" & MaPK & "','" & cmbYeucaukham.SelectedValue & "', " _
                    & " '" & cmbPhongkham.SelectedValue & "', " _
                    & " " & Thutukham & " , 0 ) "
                    Cmd.ExecuteNonQuery()
                    If Not Duoc_Them_BN Then
                        'Cmd.CommandText = "Insert into " & TenDatabase & ".DBO.MAC_LOG(MAC,Chucnang,Thoigian,Tendangnhap,Mabenhnhan ) " _
                        '& " values ( '" & Get_MAC_Address() & "','Tiepdon', " _
                        '& " '" & Format(ThoigianHT, "MM/dd/yyyy HH:mm") & "','" & TenDangNhap & "','" & txtMabenhnhan.Text & "') "
                        'Cmd.ExecuteNonQuery()
                    End If
                    Tran.Commit()
                    Cmd.Dispose()
                    ViewControl("Start")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Tran.Rollback()
                End Try
            End If
        End If
        If txtTennoiDKKCBBD.ReadOnly = False Then
            ThemNoiKCBBD(txtManoiDKKCBBD.Text, txtTennoiDKKCBBD.Text)
            txtTennoiDKKCBBD.ReadOnly = True
        End If
        txtChandoan.Focus()
        Load_Phongkham(NgayHienTai, cmbDoituong_PK.SelectedValue)
        Load_DSBN(GetSrvDate())
        FillDanhsachPK(txtMaKhambenh.Text)
    End Sub
    Private Function ThemBenhNhanvaLankham() As Boolean
        Dim TenBenhnhan, Namsinh, Gioitinh, Tuyen
        Dim Doituong, Diachi, Nghenghiep, Capbac, MaDonvi, Noicongtac, Lienhe, TheTE, Noigioithieu, Chandoan, ThoigianDangky
        Dim SotheBHYT, Doituongthe_BHYT, NoiDKKCBBD_BHYT, BHYTTu, BHYTDen, BHXHTinh, SoBANT As String
        Dim Capcuu, ThoigianChidinh, Dichvukham, Phongkham, Thutukham
        Dim Tran As SqlTransaction
        Dim i
        Dim Cmd As New SqlCommand
        ThemBenhNhanvaLankham = False
        If Not KiemtraHL() Then
            Exit Function
        End If
        TenBenhnhan = "N'" & Replace(Trim(txtTenbenhnhan.Text), "'", "''") & "'"
        Namsinh = ""
        If txtTuoi.Value Is System.DBNull.Value Then
            Namsinh = "null"
        Else
            Namsinh = txtTuoi.Value.ToString()
        End If
        Gioitinh = IIf(cmbGioitinh.Text = "Nam", 1, 0)
        Doituong = "N'" & Replace(Trim(cmbDoituong.SelectedValue), "'", "''") & "'"
        Diachi = "N'" & Replace(Trim(txtDiachi.Text), "'", "''") & "'"
        Nghenghiep = "N'" & Replace(Trim(cmbNghenghiep.SelectedValue), "'", "''") & "'"
        Capbac = "N'" & Replace(Trim(cmbCapbac.SelectedValue), "'", "''") & "'"
        MaDonvi = "N'" & Replace(Trim(cmbDonvi.SelectedValue), "'", "''") & "'"
        Noicongtac = "N'" & Replace(Trim(cmbDonvi.Text), "'", "''") & "'"
        Lienhe = "N'" & Replace(Trim(txtLienhe.Text), "'", "''") & "'"
        TheTE = "N'" & Replace(Trim(txtTheTE.Text), "'", "''") & "'"
        Noigioithieu = "N'" & Replace(Trim(txtNoigioithieu.Text), "'", "''") & "'"
        Chandoan = "N'" & Replace(Trim(txtChandoan.Text), "'", "''") & "'"
        SoBANT = "N'" & Replace(Trim(txtSoBANT.Text), "'", "''") & "'"
        ThoigianDangky = txtThoigianDangky.Value

        Tuyen = cmbTuyen.SelectedIndex
        If Tuyen = -1 Then Tuyen = 0
        SotheBHYT = "N'" & Replace(Trim(txtSotheBHYT.Text), "'", "''") & "'"
        Doituongthe_BHYT = "N'" & Replace(Trim(txtMaDT.Text), "'", "''") & "'"
        NoiDKKCBBD_BHYT = "N'" & Replace(Trim(txtManoiDKKCBBD.Text), "'", "''") & "'"
        If dtBHTu.Text = "" Then
            BHYTTu = "NULL"
        Else : BHYTTu = String.Format("'{0:MM/dd/yyyy}'", dtBHTu.Value)
        End If
        If dtBHDen.Text = "" Then
            BHYTDen = "NULL"
        Else : BHYTDen = String.Format("'{0:MM/dd/yyyy}'", dtBHDen.Value)
        End If
        BHXHTinh = "N'" & Replace(Trim(txtTenBHYTTinh.Text), "'", "''") & "'"

        Capcuu = IIf(optKhamthuong.Checked, 0, 1)
        ThoigianChidinh = GetSrvDate()

        If txtMabenhnhan.Text = "" Then 'Truong hop A. Nếu không nhập mã bệnh nhân -> Là BN mới -> thêm mới hoàn toàn
            Tran = Cn.BeginTransaction()
            Try
                Cmd.Connection = Cn
                Cmd.Transaction = Tran
                Cmd.CommandText = "Select Getdate()"
                Dim ThoigianHT = Cmd.ExecuteScalar()
                'Thêm bệnh nhân
                Cmd.CommandText = "Select " & TenDatabase & ".DBO.LayMaBenhNhan('" & Format(ThoigianHT, "yyMMdd") & "')" _
                & " Insert into tblBenhnhan ( MaBenhnhan, TenBenhnhan, " _
                & "   Namsinh,Gioitinh) " _
                & " values ( " & TenDatabase & ".DBO.LayMaBenhNhan('" & Format(ThoigianHT, "yyMMdd") & "') , " _
                & " " & TenBenhnhan & " , " & Namsinh & ", " & Gioitinh & " ) "
                txtMabenhnhan.Text = Cmd.ExecuteScalar().ToString
                'Thêm lần khám
                Cmd.CommandText = "Select " & TenDatabase & ".DBO.LayMaKhambenh('" & Format(ThoigianHT, "yyMMdd") & "')" _
                & " Insert into tblKhambenh ( MaBenhnhan, MaKhambenh, " _
                & "   ThoigianDangky,Doituong, " _
                & "   Diachi,Noicongtac, Tuyen," _
                & "   SotheBHYT,Doituongthe, " _
                & "   NoidangkyKCBBD,HantheBHYT_Tu, " _
                & "   HantheBHYT_Den,NoicaptheBHYT, " _
                & "   Nghenghiep,Capbac,Madonvi,SotheTE, " _
                & "   Lienhe,Noigioithieu,ChandoanNGT, SoBANT ) " _
                & " values ( '" & txtMabenhnhan.Text & "'," & TenDatabase & ".DBO.LayMaKhambenh('" & Format(ThoigianHT, "yyMMdd") & "') , " _
                & " '" & Format(ThoigianDangky, "MM/dd/yyyy HH:mm:ss") & "' , " & Doituong & ", " _
                & " " & Diachi & " , " & Noicongtac & ", " & Tuyen & ", " _
                & " " & SotheBHYT & " , " & Doituongthe_BHYT & ", " _
                & " " & NoiDKKCBBD_BHYT & " , " & BHYTTu & ", " _
                & " " & BHYTDen & " , " & BHXHTinh & ", " _
                & " " & Nghenghiep & " ," & Capbac & " ," & MaDonvi & " , " & TheTE & ", " _
                & " " & Lienhe & " , " & Noigioithieu & ",  " & Chandoan & " ,  " & SoBANT & " ) "
                txtMaKhambenh.Text = Cmd.ExecuteScalar().ToString
                Tran.Commit()
                Cmd.Dispose()
                ViewControl("Start")
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        Else 'Truong hop B. Nếu có mã bệnh nhân -> Là BN cũ  '''
            'Kiểm tra xem đã có PK này trong danh sách chưa, nếu có rồi không cho thêm nữa
            If cmdThem.Visible = True Then 'Truong hop B1. Nếu đã đăng ký khám rồi,
                '' có thể là khám trong ngày khi gõ mã trong lúc bấm Thêm
                ''có thể là khám ngày nào đó khi tìm phiếu khám - > kích đúp
                'If DateDiff(DateInterval.Day, txtThoigianDangky.Value, GetSrvDate()) <> 0 Then
                '    'Kiểm tra xem có phải đang ở trạng thái xem lại phiếu khám ngày trước hay ko
                '    ' Nếu đúng ko cho thêm phiếu khám cho ngày đăng ký trước đó
                '    MsgBox("Không được thêm phiếu khám cho ngày trước!", MsgBoxStyle.Critical, "Message!")
                '    Exit Sub
                'End If
                ''Nếu khám trong ngày, khi đó đã có Mã bệnh nhân, Mã khám bệnh chỉ thêm dịch vụ mới
                'Tran = Cn.BeginTransaction()
                'Try
                '    Cmd.Connection = Cn
                '    Cmd.Transaction = Tran
                '    Cmd.CommandText = "Select Getdate()"
                '    Dim ThoigianHT = Cmd.ExecuteScalar()
                '    'Thêm phiếu khám vào tblKHAMBENH_CHIDINH
                '    Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','PK','','',''", txtMabenhnhan.Text, txtMaKhambenh.Text, "PK", ThoigianHT, MaKhoaphong, TenDangNhap, cmbYeucaukham.SelectedValue, Capcuu)
                '    Dim MaPK As String = Cmd.ExecuteScalar() ' Lấy mã phiếu khám mới
                '    'Thêm Dịch vụ vào tblKHAMBENH_DICHVU
                '    Cmd.CommandText = "Insert into tblKHAMBENH_DICHVU ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                '    & " MaDichvu,DVT,Soluong,KhoaThuchien,Daduyet,DaThuchien,Ghichu) " _
                '    & " values ( '" & txtMabenhnhan.Text & "','" & txtMaKhambenh.Text & "', " _
                '    & " '" & MaPK & "','" & cmbYeucaukham.SelectedValue & "', " _
                '    & "  N'Lần',1, " _
                '    & "  '" & cmbPhongkham.SelectedValue & "', " _
                '    & " 0, 0,'') "
                '    Cmd.ExecuteNonQuery()
                '    'Thêm Dịch vụ vào tblKHAMBENH_KQDVKHAM
                '    Cmd.CommandText = "Insert into tblKHAMBENH_KQDVKHAM ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                '    & " MaDichvu, Khoathuchien,ThutuKham,HuongGQ) " _
                '    & " values ( '" & txtMabenhnhan.Text & "','" & txtMaKhambenh.Text & "', " _
                '    & " '" & MaPK & "','" & cmbYeucaukham.SelectedValue & "', " _
                '    & " '" & cmbPhongkham.SelectedValue & "', " _
                '    & " " & Thutukham & " , 0 ) "
                '    Cmd.ExecuteNonQuery()
                '    If Not Duoc_Them_BN Then
                '        'Cmd.CommandText = "Insert into " & TenDatabase & ".DBO.MAC_LOG(MAC,Chucnang,Thoigian,Tendangnhap,Mabenhnhan ) " _
                '        '& " values ( '" & Get_MAC_Address() & "','Tiepdon', " _
                '        '& " '" & Format(ThoigianHT, "MM/dd/yyyy HH:mm") & "','" & TenDangNhap & "','" & txtMabenhnhan.Text & "') "
                '        'Cmd.ExecuteNonQuery()
                '    End If
                '    Tran.Commit()
                '    Cmd.Dispose()
                '    ViewControl("Start")
                'Catch ex As Exception
                '    MsgBox(ex.Message)
                '    Tran.Rollback()
                'End Try
            Else 'Truong hop B2. Nếu đã đăng ký khám lần trước rồi, 
                'khi đó đã có Mã bệnh nhân,thêm lần khám + dịch vụ mới
                Tran = Cn.BeginTransaction()
                Try
                    Cmd.Connection = Cn
                    Cmd.Transaction = Tran
                    Cmd.CommandText = "Select Getdate()"
                    Dim ThoigianHT = Cmd.ExecuteScalar()
                    'Thêm lần khám
                    Cmd.CommandText = "Select " & TenDatabase & ".DBO.LayMaKhambenh('" & Format(ThoigianHT, "yyMMdd") & "')" _
                    & " Insert into tblKhambenh ( MaBenhnhan, MaKhambenh, " _
                    & "   ThoigianDangky,Doituong, " _
                    & "   Diachi,Noicongtac,Tuyen, " _
                    & "   SotheBHYT,Doituongthe, " _
                    & "   NoidangkyKCBBD,HantheBHYT_Tu, " _
                    & "   HantheBHYT_Den,NoicaptheBHYT, " _
                    & "   Nghenghiep,Capbac,Madonvi,SotheTE, " _
                    & "   Lienhe,Noigioithieu,ChandoanNGT, SoBANT) " _
                    & " values ( '" & txtMabenhnhan.Text & "'," & TenDatabase & ".DBO.LayMaKhambenh('" & Format(ThoigianHT, "yyMMdd") & "') , " _
                    & " '" & Format(ThoigianDangky, "MM/dd/yyyy HH:mm:ss") & "' , " & Doituong & ", " _
                    & " " & Diachi & " , " & Noicongtac & "," & Tuyen & ", " _
                    & " " & SotheBHYT & " , " & Doituongthe_BHYT & ", " _
                    & " " & NoiDKKCBBD_BHYT & " , " & BHYTTu & ", " _
                    & " " & BHYTDen & " , " & BHXHTinh & ", " _
                    & " " & Nghenghiep & " ," & Capbac & " ," & MaDonvi & " , " & TheTE & ", " _
                    & " " & Lienhe & " , " & Noigioithieu & ",  " & Chandoan & ",  " & SoBANT & "  ) "
                    txtMaKhambenh.Text = Cmd.ExecuteScalar().ToString
                    Tran.Commit()
                    Cmd.Dispose()
                    ViewControl("Start")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Tran.Rollback()
                End Try
            End If
        End If
        If txtTennoiDKKCBBD.ReadOnly = False Then
            ThemNoiKCBBD(txtManoiDKKCBBD.Text, txtTennoiDKKCBBD.Text)
            txtTennoiDKKCBBD.ReadOnly = True
        End If
        ThemBenhNhanvaLankham = True
    End Function
    Private Sub ThemNoiKCBBD(ByVal Ma As String, ByVal Ten As String)
        Dim Sql As String
        Dim Cmd As New SqlCommand
        Cmd.Connection = Cn
        Sql = " Delete from DMNOIDKKCBBD_BHYT where Manoicap = '" & Ma & "'"
        Cmd.CommandText = Sql
        Cmd.ExecuteNonQuery()
        Sql = " Insert into DMNOIDKKCBBD_BHYT (Manoicap, Tennoicap) values (N'" & Ma & "',N'" & Replace(Ten, "'", "''") & "' ) "
        Cmd.CommandText = Sql
        Cmd.ExecuteNonQuery()
    End Sub
    Private Sub fgPhongkham_OwnerDrawCell(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles fgPhongkham.OwnerDrawCell
        If Not fgPhongkham.Cols(e.Col).UserData Is Nothing AndAlso e.Row >= fgPhongkham.Rows.Fixed Then
            Dim value As Double
            If Double.TryParse(fgPhongkham.GetDataDisplay(e.Row, e.Col), NumberStyles.Any, CultureInfo.CurrentCulture, value) Then
                'calculate bar extent 
                Dim rc As Rectangle = e.Bounds
                Dim max As Double = CType(fgPhongkham.Cols(e.Col).UserData, Double)
                rc.Width = CType((System.Math.Floor(fgPhongkham.Cols(e.Col).WidthDisplay * value / max)), Integer)

                'draw background
                e.DrawCell(DrawCellFlags.Background Or DrawCellFlags.Border)

                'draw bar
                rc.Inflate(-2, -2)
                e.Graphics.FillRectangle(Brushes.Red, rc)
                rc.Inflate(-1, -1)
                e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rc)

                'draw cell content
                e.DrawCell(DrawCellFlags.Content)
            End If

        End If
    End Sub
    Private Sub Load_Phongkham(ByVal Ngay1 As Date, ByVal MaDT As String)
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd1 As SqlDataReader
        Dim Sum_Luotkham As Integer
        Dim Sum_LuotCho As Integer
        Dim i

        fgPhongkham.Rows.Count = 1
        Sum_Luotkham = 0
        Sum_LuotCho = 0
        If MaDT <> "" Then
            SQl = "select DMKhoaPhong.MaKhoa,DMKhoaPhong.TenKhoa, " _
            & " isNull(SL,0)  as Soluong , " _
            & " isNull(SLCho,0) as SoluongCho from DMKhoaPhong " _
            & " left outer join ( select Khoathuchien, count(Khoathuchien) as SL " _
            & " from tblKhambenh_KQDVKHAM  where left(MaphieuCD,8)= 'PK'+ '" & Format(Ngay1, "yyMMdd") & "'   and mabenhnhan in (select mabenhnhan from tblKhambenh where left(Doituong," & Len(MaDT) & ") =  N'" & MaDT & "') group by Khoathuchien)Q " _
            & " on DMKhoaPhong.MaKhoa = Q.Khoathuchien  " _
            & " left outer join ( select Khoathuchien, count(Khoathuchien) as SLCho " _
            & " from tblKhambenh_KQDVKHAM  where left(MaphieuCD,8)= 'PK'+ '" & Format(Ngay1, "yyMMdd") & "'  and HuongGQ = 0 and mabenhnhan in " _
            & " (select mabenhnhan from tblKhambenh where left(Doituong," & Len(MaDT) & ") =  N'" & MaDT & "') group by Khoathuchien)P " _
            & " on DMKhoaPhong.MaKhoa = P.Khoathuchien  " _
            & " where  DMKhoaPhong.is_Phongkham = 1 order by Makhoa "
            '& " where left(DMKhoaPhong.makhoa,1) = 'K' and len(DMKhoaPhong.makhoa) = 4 "
        Else
            SQl = "select DMKhoaPhong.MaKhoa,DMKhoaPhong.TenKhoa,  isNull(SL,0)  as Soluong ,  " _
            & " isNull(SLCho,0) as SoluongCho from DMKhoaPhong  " _
            & " left outer join ( select Khoathuchien, count(Khoathuchien) as SL  " _
            & " from tblKhambenh_KQDVKHAM  where left(MaphieuCD,8)= 'PK'+ '" & Format(Ngay1, "yyMMdd") & "'  group by Khoathuchien)Q " _
            & " on DMKhoaPhong.MaKhoa = Q.Khoathuchien   " _
            & " left outer join ( select Khoathuchien, count(Khoathuchien) as SLCho  from tblKhambenh_KQDVKHAM " _
            & " where left(MaphieuCD,8)= 'PK'+ '" & Format(Ngay1, "yyMMdd") & "'  and HuongGQ = 0  group by Khoathuchien)P " _
            & " on DMKhoaPhong.MaKhoa = P.Khoathuchien " _
            & " where  DMKhoaPhong.is_Phongkham = 1  order by Makhoa "
        End If
        Cmd = New SqlCommand(SQl, Cn)
        Cmd.CommandTimeout = 0
        rd1 = Cmd.ExecuteReader
        Dim SoPK As Int16
        Do While rd1.Read
            fgPhongkham.AddItem(rd1!makhoa & vbTab & rd1!Tenkhoa & vbTab & IIf(IsDBNull(rd1!Soluong), 0, rd1!Soluong) & vbTab & IIf(IsDBNull(rd1!SoluongCho), 0, rd1!SoluongCho))
            Sum_Luotkham = Sum_Luotkham + IIf(IsDBNull(rd1!Soluong), 0, rd1!Soluong)
            Sum_LuotCho = Sum_LuotCho + IIf(IsDBNull(rd1!SoluongCho), 0, rd1!SoluongCho)
        Loop
        SoPK = fgPhongkham.Rows.Count - 1
        For i = 1 To SoPK
            fgPhongkham.Rows(i).Height = (fgPhongkham.Height - 30) \ SoPK
        Next
        rd1.Close()
        rd1 = Nothing
        txtTongso.Text = Trim(Str(Sum_Luotkham))
        txtTongcho.Text = Trim(Str(Sum_LuotCho))
        Dim Draw As Boolean
        For i = 1 To fgPhongkham.Rows.Count - 1
            If fgPhongkham.Item(i, 3) <> 0 Then Draw = True
        Next
        If Not Draw Then Exit Sub
        'attach scaling info to each numeric column
        Dim r1 As Integer = fgPhongkham.Rows.Fixed
        Dim r2 As Integer = fgPhongkham.Rows.Count - 1
        Dim s As String = Nothing
        'Dim barCols() As String = New String() {"Số lượng"}
        ''Dim barCols() As String = New String() {"UnitPrice", "UnitsInStock", "UnitsOnOrder"}
        'For Each s In barCols
        Dim col As Column = fgPhongkham.Cols(3)
        Dim max As Double = fgPhongkham.Aggregate(AggregateEnum.Max, r1, 3, r2, 3)
        col.UserData = max
        'Next
        'turn on ownerdraw
        fgPhongkham.DrawMode = DrawModeEnum.OwnerDraw
    End Sub

    Private Sub cmbDoituong_PK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDoituong_PK.TextChanged
        Load_Phongkham(NgayHienTai, cmbDoituong_PK.SelectedValue)
    End Sub

    Private Sub txtTenbenhnhan_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenbenhnhan.Validated
        If (booThem Or booSua) And txtTenbenhnhan.Text <> "" Then
            txtTenbenhnhan.Text = UCase(Trim(txtTenbenhnhan.Text))
        End If
    End Sub

    Private Sub cmdInPK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInPK.Click

        Dim i
        Dim rptPKB As New rptPhieuKB
        Try
            If txtMabenhnhan.Text = "" Or grdYeucaukham.Rows.Count < 2 Then
                Exit Sub
            End If
            If grdYeucaukham.Rows.Count = 2 Then            ' Nếu có 1 phiếu khám
                i = 1
            Else
                i = grdYeucaukham.Row
            End If
            If i < 1 Then
                MsgBox("Chưa chọn phiếu khám để in !", MsgBoxStyle.Critical, "Message")
                Exit Sub
            End If
            If GetSetting("PHONGKHAM", "Thuoctinh", "InPK_Lazer", "1") = "1" Then
                rptPKB.lblMakhambenh.Text = "Mã KB: " + txtMaKhambenh.Text
                rptPKB.txtMaphieukham.Text = grdYeucaukham.Item(i, 5)
                rptPKB.txtTenbenhnhan.Text = txtTenbenhnhan.Text
                rptPKB.txtNamsinh.Text = txtTuoi.Value
                rptPKB.txtDiachi.Text = txtDiachi.Text
                rptPKB.txtGioitinh.Text = cmbGioitinh.Text
                rptPKB.lblDoituong.Text = "Đối tượng: " + IIf(cmbDoituong.SelectedValue.ToString.Substring(0, 1) = "1", "Bảo hiểm y tế", cmbDoituong.Text)
                rptPKB.txtSotheBHYT.Text = txtSotheBHYT.Text + "-" + txtMaDT.Text + "-" + txtManoiDKKCBBD.Text
                rptPKB.txtGiatriDen.Text = dtBHDen.Text
                rptPKB.txtNoigioithieu.Text = txtNoigioithieu.Text
                rptPKB.txtThoigiankham.Text = txtThoigianChidinh.Text
                rptPKB.txtDiengiai.Text = txtChandoan.Text
                rptPKB.txtYeucaukham.Text = grdYeucaukham.Item(i, 4)
                rptPKB.lblBuongso.Text = grdYeucaukham.Item(i, 1)
                rptPKB.lblThutu.Text = grdYeucaukham.Item(i, 2)
                'rptPKB.lblNgaykham.Text = "Ngày  " + Format(txtThoigianChidinh.Value, "dd") + " tháng " + Format(txtThoigianChidinh.Value, "MM") + "  năm  " + Format(txtThoigianChidinh.Value, "yyyy")  ' VB6.Right(Format(txtNgaykham.Value, "yyyy"), 1)
                rptPKB.lblNguoilapphieu.Text = Tendaydu
                rptPKB.Run(True)
                'frm.arViewer.Document = rptPKB.Document
                'rptPKB.Show()
                rptPKB.Document.Print(False, False, False)
            Else
                Dim rptPKB_nhiet As New rptPhieuKB_Innhiet
                rptPKB_nhiet.txtTenbenhnhan.Text = txtTenbenhnhan.Text
                rptPKB_nhiet.Label4.Text = txtMaKhambenh.Text
                rptPKB_nhiet.txtNamsinh.Text = txtTuoi.Value
                rptPKB_nhiet.txtGioitinh.Text = cmbGioitinh.Text
                rptPKB_nhiet.lblDoituong.Text = "(" + IIf(cmbDoituong.SelectedValue.ToString.Substring(0, 1) = "1", "BHYT", cmbDoituong.Text) + ")"
                rptPKB_nhiet.lblBuongso.Text = grdYeucaukham.Item(i, 1)
                rptPKB_nhiet.lblThutu.Text = grdYeucaukham.Item(i, 2)
                rptPKB_nhiet.Label3.Text = "( " + grdYeucaukham.Item(i, 6) + " )"
                rptPKB_nhiet.TextBox1.Text = "Ngày  " + Format(txtThoigianChidinh.Value, "dd") + " tháng " + Format(txtThoigianChidinh.Value, "MM") + "  năm  " + Format(txtThoigianChidinh.Value, "yyyy")  ' VB6.Right(Format(txtNgaykham.Value, "yyyy"), 1)
                rptPKB_nhiet.Run(True)
                'rptPKB_nhiet.Show()
                rptPKB_nhiet.Document.Print(False, False, False)
                rptPKB_nhiet.Dispose()
                cmdThem.Focus()
            End If
        Catch ex As Exception
            MsgBox("Có lỗi: " + ex.Message)
        End Try
    End Sub
     
     
    Private Sub txtTuoi_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTuoi.Validated
        If booThem Or booSua Then
            If txtTuoi.Text = "" Then Exit Sub
            If Len(txtTuoi.Text) <= 3 And txtTuoi.Value < 120 Then
                txtTuoi.Value = GetSrvDate.Year - txtTuoi.Value
            End If
        End If
    End Sub

    Private Sub txtManoiDKKCBBD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtManoiDKKCBBD.Validated
        Dim SQL As String
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim Adap As SqlDataAdapter
        Dim Ds As DataSet
        Try
            If Not (booThem Or booSua) Or Trim(txtManoiDKKCBBD.Text) = "" Then
                Exit Sub
            End If
            If Trim(txtManoiDKKCBBD.Text) = "" Then
                txtTennoiDKKCBBD.Text = ""
                Exit Sub
            End If
            'If Trim(txtManoiDKKCBBD.Text) = MaDKKCBBD_BV Then
            '    cmbTuyen.SelectedIndex = 0
            'End If
            SQL = "Select * from DMNOIDKKCBBD_BHYT where Manoicap = '" & Trim(txtManoiDKKCBBD.Text) & "'"
            cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = cmd
            Ds = New DataSet
            Adap.Fill(Ds, "DMNOIDKKCBBD_BHYT")
            If Ds.Tables("DMNOIDKKCBBD_BHYT").Rows.Count > 0 Then
                txtTennoiDKKCBBD.Text = Ds.Tables("DMNOIDKKCBBD_BHYT").Rows(0).Item("Tennoicap")
                'txtNoigioithieu.Text = txtTennoiDKKCBBD.Text
            Else
                If MsgBox("Mã nơi đăng ký KCB ban đầu chưa có trong danh mục." + vbCrLf + "Bạn có muốn thêm mới không?", MsgBoxStyle.YesNo, "Message!") Then
                    txtTennoiDKKCBBD.Text = ""
                    txtTennoiDKKCBBD.ReadOnly = False
                    txtTennoiDKKCBBD.Focus()
                End If
            End If
            cmd.Dispose()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtMaDT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaDT.Validated
        Dim SQL As String
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim Themoi
        Try
            If Not (booThem Or booSua) Or Trim(txtMaDT.Text) = "" Then
                Exit Sub
            End If
            If Trim(txtMaDT.Text) = "" Then
                txtTenDT.Text = ""
                Exit Sub
            End If
            If txtSotheBHYT.Text.Trim.Length() = 13 Then
                Themoi = 1
            Else
                Themoi = 0
            End If

            txtMaDT.Text = UCase(Trim(txtMaDT.Text))
            SQL = "Select * from DMDTTHE_BHYT where MaDT = '" & Trim(txtMaDT.Text) & "' "
            cmd = New SqlCommand(SQL, Cn)
            rd = cmd.ExecuteReader()
            If Not rd.HasRows Then
                txtTenDT.Text = ""
                MsgBox("Nhập sai mã đối tượng thẻ", MsgBoxStyle.Critical, "Message!")
                txtMaDT.Focus()
            End If
            Do While rd.Read
                txtTenDT.Text = rd!TenDT
                'cmbDoituong.SelectedValue = rd!MaDoituongBN.ToString.Substring(0, 1)
            Loop
            rd.Close()
            cmd.Dispose()
            Exit Sub
        Catch ex As Exception
            If rd IsNot Nothing Then rd.Close()
        End Try
    End Sub

    Private Sub txtTenbenhnhan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenbenhnhan.LostFocus
        Label2.ForeColor = Color.Black
    End Sub
    Private Sub txtTenbenhnhan_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTenbenhnhan.GotFocus
        Label2.ForeColor = Color.Red
    End Sub
    Private Sub txtTuoi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTuoi.LostFocus
        Label3.ForeColor = Color.Black
    End Sub
    Private Sub txtTuoi_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTuoi.GotFocus
        Label3.ForeColor = Color.Red
    End Sub
    Private Sub cmbGioitinh_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGioitinh.LostFocus
        Label5.ForeColor = Color.Black
    End Sub
    Private Sub cmbGioitinh_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGioitinh.GotFocus
        Label5.ForeColor = Color.Red
    End Sub


    Private Sub txtDiachi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiachi.LostFocus
        Label9.ForeColor = Color.Black
    End Sub
    Private Sub txtDiachi_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiachi.GotFocus
        Label9.ForeColor = Color.Red
    End Sub
    Private Sub cmbNghenghiep_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNghenghiep.LostFocus
        Label31.ForeColor = Color.Black
    End Sub
    Private Sub cmbNghenghiep_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNghenghiep.GotFocus
        Label31.ForeColor = Color.Red
    End Sub
    Private Sub txtLienhe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLienhe.LostFocus
        Label11.ForeColor = Color.Black
    End Sub
    Private Sub txtLienhe_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLienhe.GotFocus
        Label11.ForeColor = Color.Red
    End Sub
    Private Sub txtSotheBHYT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSotheBHYT.LostFocus
        Label23.ForeColor = Color.Black
    End Sub
    Private Sub txtSotheBHYT_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSotheBHYT.GotFocus
        Label23.ForeColor = Color.Red
    End Sub
    Private Sub txtmadt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaDT.LostFocus
        Label30.ForeColor = Color.Black
    End Sub
    Private Sub txtmadt_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaDT.GotFocus
        Label30.ForeColor = Color.Red
    End Sub
    Private Sub txtManoicap_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtManoiDKKCBBD.LostFocus
        Label29.ForeColor = Color.Black
    End Sub
    Private Sub txtManoicap_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManoiDKKCBBD.GotFocus
        Label29.ForeColor = Color.Red
    End Sub
    Private Sub cmbYeucaukham_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbYeucaukham.LostFocus
        Label14.ForeColor = Color.Black
    End Sub
    Private Sub cmbYeucaukham_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYeucaukham.GotFocus
        Label14.ForeColor = Color.Red
    End Sub

    Private Sub cmbPhongkham_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPhongkham.GotFocus
        Label15.ForeColor = Color.Red
    End Sub


    Private Sub txtTheTE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheTE.GotFocus
        Label36.ForeColor = Color.Red
    End Sub

    Private Sub txtTheTE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheTE.LostFocus
        Label36.ForeColor = Color.Black
    End Sub

    Private Sub chkTimngay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTimngay.CheckedChanged
        If chkTimngay.Checked Then
            txtNgaykhamT.Enabled = True
            txtNgaykhamT.Value = GetSrvDate()
        Else
            txtNgaykhamT.Enabled = False
        End If
    End Sub

    Private Sub dtBHTu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtBHTu.GotFocus
        Label33.ForeColor = Color.Red
    End Sub

    Private Sub dtBHTu_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtBHTu.LostFocus
        Label33.ForeColor = Color.Black
    End Sub

    Private Sub dtBHDen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtBHDen.GotFocus
        Label34.ForeColor = Color.Red
    End Sub

    Private Sub dtBHDen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtBHDen.LostFocus
        Label34.ForeColor = Color.Black
    End Sub
    Private Sub txtTenBHYTTinh_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenBHYTTinh.GotFocus
        Label35.ForeColor = Color.Red
    End Sub

    Private Sub txtTenBHYTTinh_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenBHYTTinh.LostFocus
        Label35.ForeColor = Color.Black
    End Sub
    Private Sub cmbDoituong_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDoituong.LostFocus
        Label4.ForeColor = Color.Black
    End Sub

    Private Sub txtNoicongtac_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoicongtac.GotFocus
        Label8.ForeColor = Color.Red
    End Sub

    Private Sub txtNoicongtac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoicongtac.LostFocus
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub txtNoigioithieu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoigioithieu.GotFocus
        Label37.ForeColor = Color.Red
    End Sub

    Private Sub txtNoigioithieu_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoigioithieu.LostFocus
        Label37.ForeColor = Color.Black
    End Sub

    Private Sub txtChandoan_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChandoan.GotFocus
        Label10.ForeColor = Color.Red
    End Sub

    Private Sub txtChandoan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChandoan.LostFocus
        Label10.ForeColor = Color.Black
    End Sub

    Private Sub txtThoigianDangky_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThoigianDangky.GotFocus
        Label13.ForeColor = Color.Red
    End Sub

    Private Sub txtThoigianDangky_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThoigianDangky.LostFocus
        Label13.ForeColor = Color.Black
    End Sub

    Private Sub txtMaKhambenh_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaKhambenh.GotFocus
        Label38.ForeColor = Color.Red
    End Sub

    Private Sub txtMaKhambenh_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaKhambenh.LostFocus
        Label38.ForeColor = Color.Black
    End Sub

    Private Sub cmbTuyen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTuyen.GotFocus
        Label7.ForeColor = Color.Red
    End Sub

    Private Sub cmbTuyen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTuyen.LostFocus
        Label7.ForeColor = Color.Black
    End Sub

    Private Sub cmbDoituong_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDoituong.TextChanged
        If cmbDoituong.Text = "Bảo hiểm y tế" Then
            grBHYT.Enabled = True
            If txtManoiDKKCBBD.Text = "" Then
                txtManoiDKKCBBD.Text = MaDKKCBBD
                txtTennoiDKKCBBD.Text = TenPK
            End If
        Else
            grBHYT.Enabled = False
            txtManoiDKKCBBD.Text = ""
            txtTennoiDKKCBBD.Text = ""
        End If
    End Sub

    Private Sub cmbDonvi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDonvi.GotFocus
        Label8.ForeColor = Color.Red
    End Sub

    Private Sub cmbDonvi_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDonvi.LostFocus
        Label8.ForeColor = Color.Black
    End Sub

    Private Sub txtSotheBHYT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSotheBHYT.TextChanged

    End Sub
#Region "Code them vao de goi so thu tu kham benh tu day"

    Private Function GetDoiTuong() As Integer
        GetDoiTuong = 0
        If cmbDoituong.Text = "Quân" Or cmbDoituong.Text = "Chính sách" Then GetDoiTuong = 1
        If cmbDoituong.Text = "Bảo hiểm y tế" Then GetDoiTuong = 2
        If cmbDoituong.Text = "Dịch vụ" Then GetDoiTuong = 3
    End Function
    Private Function GetMaxSoThuTu(ByVal DoiTuong As Integer) As Integer
        Dim STT As Integer, oSTT As Object
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand()
        SQLCmd.Connection = Cn
        SQLCmd.CommandText = String.Format("SELECT MAX(SoThuTu) AS STT FROM {0}.DBO.MAXSOTHUTU WHERE DoiTuong = {1}", TenDatabase, DoiTuong)
        oSTT = SQLCmd.ExecuteScalar()
        SQLCmd.Dispose()
        If (oSTT Is DBNull.Value) Then
            STT = 1
        Else
            STT = Integer.Parse(oSTT.ToString()) + 1
        End If
        GetMaxSoThuTu = STT
    End Function
    Private Sub GoiSo(ByVal CumDen As Byte, ByVal SoThuTu As Integer, ByVal DoiTuong As Integer)
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = String.Format("INSERT INTO {0}.DBO.HIENTHIDEN (CumDen,SoThuTu,DoiTuong,HUBden) VALUES ('{1}',{2},{3},1)", TenDatabase, CumDen, SoThuTu, DoiTuong)
        SQLCmd.ExecuteNonQuery()
        'SQLCmd.CommandText = String.Format("INSERT INTO {0}.DBO.HIENTHIDEN (CumDen,SoThuTu,DoiTuong,Speaker) VALUES ('{1}',{2},{3},{4})", Tendatabase, CumDen, SoThuTu, DoiTuong, 1)
        'SQLCmd.ExecuteNonQuery()
        SQLCmd.CommandText = String.Format("DELETE FROM {0}.DBO.MAXSOTHUTU WHERE DoiTuong={1}", TenDatabase, DoiTuong)
        SQLCmd.ExecuteNonQuery()
        SQLCmd.CommandText = String.Format("INSERT INTO {0}.DBO.MAXSOTHUTU (SoThuTu,DoiTuong) VALUES ({1},{2})", TenDatabase, SoThuTu, DoiTuong)
        SQLCmd.ExecuteNonQuery()
        SQLCmd.Dispose()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

    End Sub

    Private Sub cmdCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCall.Click
        If (GetDoiTuong() = 0) Then Exit Sub
        Dim CumDen As Byte
        CumDen = Val(GetSetting("PHONGKHAM", "Thuoctinh", "Cumden", "2"))
        'CumDen = 2
        'If rdBan20.Checked Then
        '    CumDen = 3
        'ElseIf rdBan30.Checked Then
        '    CumDen = 4
        'End If
        Dim DoiTuong As Byte, STT As Integer
        DoiTuong = GetDoiTuong()
        Select Case DoiTuong
            Case 1
                STT = STTQuan
            Case 2
                STT = STTBH
            Case 3
                STT = STTDan
        End Select
        GoiSo(CumDen, STT, DoiTuong)
    End Sub
#End Region



    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim DoiTuong As Byte
        Dim STT As Integer, maxSTT As Integer, oSTT As Object, omaxSTT As Object
        DoiTuong = GetDoiTuong()
        Dim CumDen As Byte
        CumDen = Val(GetSetting("PHONGKHAM", "Thuoctinh", "Cumden", "2"))

        'CumDen = 2

        'If rdBan20.Checked Then
        '    CumDen = 3
        'ElseIf rdBan30.Checked Then
        '    CumDen = 4
        'End If

        Dim SQLCmd As New System.Data.SqlClient.SqlCommand()
        SQLCmd.Connection = Cn
        SQLCmd.CommandText = String.Format("SELECT MAX(SoThuTu) AS STT FROM {0}.DBO.MAXSOTHUTU WHERE DoiTuong = {1}", TenDatabase, DoiTuong)
        oSTT = SQLCmd.ExecuteScalar()
        SQLCmd.CommandText = String.Format("SELECT MAX(SoThuTu) AS STT FROM {0}.DBO.MAXSODACAP WHERE DoiTuong = {1}", TenDatabase, DoiTuong)
        omaxSTT = SQLCmd.ExecuteScalar()
        SQLCmd.Dispose()
        If (omaxSTT Is DBNull.Value) Then
            maxSTT = 0
        Else
            maxSTT = Integer.Parse(omaxSTT.ToString())
        End If
        If (oSTT Is DBNull.Value) Then
            STT = 1
        Else
            STT = Integer.Parse(oSTT.ToString()) + 1
        End If
        Select Case DoiTuong
            Case 1
                STTQuan = STT

            Case 2
                STTBH = STT

            Case 3
                STTDan = STT
        End Select
        If (maxSTT < STT) Then
            MessageBox.Show("Hết số thứ tự của đối tượng " + cmbDoituong.Text.ToUpper() + ". Đề nghị chuyển sang đối tượng khác!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Label1.Text = "TIẾP NHẬN BỆNH NHÂN " + cmbDoituong.Text.ToUpper() + " SỐ " + STT.ToString()
        GoiSo(CumDen, STT, DoiTuong)
    End Sub

    Private Sub txtSotheBHYT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSotheBHYT.Validating

    End Sub

    Private Sub txtSoBANT_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoBANT.KeyUp
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader = Nothing
        Dim NgaykhamCu As Date
        Dim MaKB As String = ""
        Try
            If txtSoBANT.Text.Trim <> "" And e.KeyCode = Keys.Enter And (booThem Or booSua) Then
                SQl = " Select   makhambenh as MaKB, * from  tblKHAMBENH " _
                & " where tblKHAMBENH.SoBANT = '" & Replace(txtSoBANT.Text, "'", "''") & "' order by ThoigianDangky Desc"
                Cmd = New SqlCommand(SQl, Cn)
                rd = Cmd.ExecuteReader
                Do While rd.Read
                    MaKB = rd!MaKB
                    cmbTuyen.SelectedIndex = rd!Tuyen
                    txtSotheBHYT.Text = rd!SotheBHYT.ToString
                    txtMaDT.Text = rd!DoituongThe.ToString
                    Exit Do
                Loop
                rd.Close()
                rd = Nothing
                If MaKB <> "" Then
                    txtSotheBHYT_Validated(sender, e)
                    'FillDataHC_SoBANT(MaKB)
                    cmbYeucaukham.Focus()
                End If

            End If
        Catch ex As Exception
            rd.Close()
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Private Sub optThongtin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optThongtinPK.CheckedChanged, optDanhsachBN.CheckedChanged
        fgPhongkham.Visible = optThongtinPK.Checked
        grdDSBN.Visible = Not optThongtinPK.Checked
    End Sub

    Private Sub grdDSBN_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDSBN.DoubleClick
        If grdDSBN.Rows.Count = 1 Then Exit Sub
        If grdDSBN.Item(grdDSBN.Row, 8) <> "" Then
            FillDataHC(grdDSBN.Item(grdDSBN.Row, 8))
            FillDanhsachPK(grdDSBN.Item(grdDSBN.Row, 8))
        End If
    End Sub





    '*********** PHAN CODE form Chỉ định của Quyền chuyển sang *******************
    'Các biến dùng chung trong form
    Private isAddNew As Boolean
    Private PhieuChidinh_Header As String = "" 'Ma loai phieuCD gan voi chi dinh dang xet
    Private MaDoituong_LanLoad_truoc As String = ""
    Private Sub LoadFormChidinh()
        fgListChiDinh.ClipSeparators = "|;"
        fgListChiDinh.Cols("NhanVienCD").Visible = False
        fgListChiDinh.Cols("CapCuu").Visible = False

        fg.ClipSeparators = "|;"
        fg.Tree.Column = 5
        fg.Cols("MaLoaiphieuCD").Visible = False
        fg.Cols("TenLoaiphieuCD").Visible = False
        fg.Cols("LoaiDichVu").Visible = False
        fg.Cols("MaDichVu").Visible = False
        fg.ContextMenuStrip = ContextMenuStrip1
        Dim cs0 As CellStyle = fg.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
        cs0.BackColor = Color.White
        cs0.ForeColor = Color.DarkBlue

        Dim i As Integer
        For i = 0 To fg.Cols.Count - 1
            fg.Cols(i).AllowEditing = False
        Next

        fgDichVu.Cols("MaLoaiDichVu").Visible = False
        fgDichVu.Cols("TenLoaiDichVu").Visible = False
        fgDichVu.Cols("MaDichVu").Visible = False
        fgDichVu.Cols("MaLoaiphieuCD").Visible = False
        cs0 = fgDichVu.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
        cs0.BackColor = Color.White
        cs0.ForeColor = Color.DarkBlue


        cs0.Font = New Font(fgDichVu.Font.Size, 10)
        Load_DichVu("4")
        isAddNew = False
    End Sub

    Private Sub Load_PhieuChiDinh(ByVal grd As C1.Win.C1FlexGrid.C1FlexGrid)
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = String.Format("EXECUTE Spd_LoadPhieuChiDinh '{0}'", txtMakhambenh.Text.Trim())
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
        With grd
            .Tag = "0"
            .Redraw = False
            .Rows.Count = 1
            fg.Rows.Count = 1
            Do While (dr.Read())
                .AddItem(String.Format("{0}|{1}|{2}|{3}|{4:dd/MM/yyyy HH:mm}|{5}|{6}|{7}|{8}|{9}", dr("MaPhieuCD"), dr("TenLoaiphieuCD"), dr("TenDu"), dr("NhanVienCD"), dr("ThoiGianCD"), dr("CapCuu"), dr("PhieuChiDinh_GhiChu"), dr("KieuReport"), dr("Tieude"), dr("Sobenhan")))
            Loop
            dr.Close()
            .Row = -1
            .AutoSizeCols(0, .Cols.Count - 1, 1)
            .Tag = "1"
            .Redraw = True
            SQLCmd.Dispose()
        End With
    End Sub
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
    Public Sub LoadChiPhiChiTiet(ByVal MaPhieuCD As String)
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = String.Format("EXECUTE Spd_LoadPhieuChiDinh_ChiTiet '{0}','{1}'", MaPhieuCD, cmbDoituong.SelectedValue)
        SQLCmd.CommandTimeout = 0
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
        fg.Redraw = False
        fg.Rows.Count = 1
        Dim row As Integer = 1
        Do While (dr.Read())
            fg.Rows.Add()
            Dim i As Integer
            For i = 0 To dr.FieldCount - 1
                fg(row, i + 1) = dr.GetValue(i)
            Next
            row = row + 1
            PhieuChidinh_Header = dr("MaloaiphieuCD").ToString()
        Loop
        dr.Close()
        SQLCmd.Dispose()
        Refresh_Grid(fg)
        fg.Redraw = True
    End Sub

    Private Sub cmdSuaPhieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSuaPhieu.Click
        If (fgListChiDinh.Row < 1) Then
            MessageBox.Show("Chưa chọn phiếu chỉ định để sửa!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        isAddNew = False
        LockEdit(False)
        'cmbLoaiCP.Focus()
    End Sub

    Private Sub cmdXoaPhieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXoaPhieu.Click
        If (fgListChiDinh.Row < 1) Then
            MessageBox.Show("Chưa chọn phiếu chỉ định để xóa!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim i As Integer
        For i = 1 To fg.Rows.Count - 1
            If fg.GetCellCheck(i, fg.Cols("DaDuyet").Index) = CheckEnum.Checked Then
                MessageBox.Show("Đã có chi phí được duyệt, không thể xóa được phiếu chỉ định này!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Next
        If MessageBox.Show("Bạn có chắc muốn xóa phiếu chỉ định này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        Dim MaPhieuCD As String = fgListChiDinh(fgListChiDinh.Row, "MaPhieuCD").ToString()
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim trn As System.Data.SqlClient.SqlTransaction
        trn = Cn.BeginTransaction()
        SQLCmd.Transaction = trn
        Try
            SQLCmd.CommandText = "DELETE FROM tblKHAMBENH_DICHVU WHERE maPhieuCD='" + MaPhieuCD + "'"
            SQLCmd.ExecuteNonQuery()
            SQLCmd.CommandText = "DELETE FROM tblKHAMBENH_CHIDINH WHERE maPhieuCD='" + MaPhieuCD + "'"
            SQLCmd.ExecuteNonQuery()
            trn.Commit()
            fgListChiDinh.RemoveItem(fgListChiDinh.Row)
        Catch ex As Exception
            trn.Rollback()
            MessageBox.Show("Có lỗi khi xóa dữ liệu - " & ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLCmd.Dispose()
            trn.Dispose()
        End Try
    End Sub

    Private Sub cmdThemPhieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThemPhieu.Click
        fg.Rows.Count = 1
        isAddNew = True
        PhieuChidinh_Header = ""
        LockEdit(False)
        lblChiTietPhieu.Text = "Chi tiết phiếu chỉ định mới của bệnh nhân"
        lblChiTietPhieu.Tag = ""
        txtTieude.Text = ""
        txtTieude.Tag = ""
        txtThoiGianCD.Value = GetSrvDate()
        lblNhanVienCD.Text = Tendaydu
        rdCapCuu.Checked = False
        rdKhamThuong.Checked = True
        'cmbLoaiCP.Focus()
    End Sub
    Private Sub LockEdit(ByVal IsLock As Boolean)
        'cmdChiDinh.Enabled = Not IsLock
        cmdSoTay.Enabled = Not IsLock
        cmdThemPhieu.Enabled = IsLock
        cmdSuaPhieu.Enabled = IsLock
        cmdXoaPhieu.Enabled = IsLock
        cmdInPhieu.Enabled = IsLock
        cmdOK.Visible = Not IsLock
        cmdCancel.Visible = Not IsLock

        cmdClosePanChidinh.Enabled = IsLock
        txtPhieuChiDinh_GhiChu.ReadOnly = IsLock

        fgListChiDinh.Enabled = IsLock
        fgListChiDinh.Visible = IsLock
        fgDichVu.Visible = Not IsLock
        lblLocDichVu.Visible = Not IsLock
        txtLocDichVu.Visible = Not IsLock
        fg.Cols("GhiChu").AllowEditing = Not IsLock
        fg.Cols("SL").AllowEditing = Not IsLock

        'txtThuoc.ReadOnly = IsLock
        'cmbLoaiCP.ReadOnly = IsLock
        'txtSoluong_Thuoc.ReadOnly = IsLock
        'cmbKhoa.ReadOnly = IsLock
        'cmdThem_Thuoc.Visible = Not IsLock
        If IsLock Then
            Label92.Text = "Các phiếu chỉ định của bệnh nhân"
        Else
            Label92.Text = "Chỉ định dịch vụ (Kích đúp chuột)"
        End If
    End Sub

    Private Sub fg_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.AfterEdit
        If Not IsNumeric(fg.Item(e.Row, fg.Cols("SL").Index)) Then fg.Item(e.Row, fg.Cols("SL").Index) = 1
        fg.Item(e.Row, fg.Cols("ThanhTien").Index) = fg.Item(e.Row, fg.Cols("SL").Index) * fg.Item(e.Row, fg.Cols("DonGia").Index)
    End Sub

    Private Sub fg_BeforeEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.BeforeEdit
        If (fg.Rows(e.Row).IsNode) Then e.Cancel = True
        If (fg.GetCellCheck(e.Row, fg.Cols("DaDuyet").Index) = CheckEnum.Checked Or fg.GetCellCheck(e.Row, fg.Cols("DaThucHien").Index) = CheckEnum.Checked) And e.Col = fg.Cols("SL").Index Then e.Cancel = True
    End Sub

    Private Sub fgListChiDinh_SelChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fgListChiDinh.SelChange
        If fgListChiDinh.Tag.ToString() = "0" Or fgListChiDinh.Row < 1 Then Exit Sub
        If (fgListChiDinh(fgListChiDinh.Row, "NhanVienCD") <> TenDangNhap) Then
            cmdSuaPhieu.Enabled = False
            cmdXoaPhieu.Enabled = False
        Else
            cmdSuaPhieu.Enabled = True
            cmdXoaPhieu.Enabled = True
        End If
        lblChiTietPhieu.Text = "Chi tiết phiếu chỉ định số " & fgListChiDinh(fgListChiDinh.Row, "MaPhieuCD")
        lblChiTietPhieu.Tag = fgListChiDinh(fgListChiDinh.Row, "MaPhieuCD")
        txtTieude.Text = fgListChiDinh(fgListChiDinh.Row, "Tieude")
        txtTieude.Tag = fgListChiDinh(fgListChiDinh.Row, "KieuReport")
        lblNhanVienCD.Text = fgListChiDinh(fgListChiDinh.Row, "TenDayDu")
        lblNhanVienCD.Tag = fgListChiDinh(fgListChiDinh.Row, "NhanVienCD")
        txtThoiGianCD.Value = CDate(fgListChiDinh(fgListChiDinh.Row, "ThoiGianCD"))
        txtPhieuChiDinh_GhiChu.Text = fgListChiDinh(fgListChiDinh.Row, "PhieuChiDinh_GhiChu")
        txtPhieuChiDinh_GhiChu.Tag = fgListChiDinh(fgListChiDinh.Row, "Sobenhan")
        If (fgListChiDinh.GetCellCheck(fgListChiDinh.Row, fgListChiDinh.Cols("CapCuu").Index) = C1.Win.C1FlexGrid.CheckEnum.Checked) Then
            rdKhamThuong.Checked = False
            rdCapCuu.Checked = True
        Else
            rdKhamThuong.Checked = True
            rdCapCuu.Checked = False
        End If
        LoadChiPhiChiTiet(fgListChiDinh(fgListChiDinh.Row, "MaPhieuCD"))
    End Sub
    Private Function LaySoBenhAn_PHCN() As String
        Dim SQL As String
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Try
            Dim ngayVaoVien As Date = txtThoigianDangky.Value
            Dim ngayDau, ngayCuoi As Date
            If ngayVaoVien.Month = 12 Then
                ngayDau = Date.Parse("01/12/" & CStr(ngayVaoVien.Year).Trim & " 00:00:00")
                ngayCuoi = Date.Parse("01/12/" & CStr(ngayVaoVien.Year + 1) & " 00:00:00")
            Else
                ngayDau = Date.Parse("01/12/" & CStr(ngayVaoVien.Year - 1).Trim & " 00:00:00")
                ngayCuoi = Date.Parse("01/12/" & CStr(ngayVaoVien.Year) & " 00:00:00")
            End If
            SQL = "Select right(Sobenhan,5) as SoBenhAn from " & TenDatabase & ".DBO.tblKhambenh_Chidinh " & _
            "where Sobenhan is not Null and Sobenhan <> '' and ThoigianCD between CAST('" & Format(ngayDau, "yyyyMMdd") & "' AS DateTime) and CAST('" & Format(ngayCuoi, "yyyyMMdd") & "' AS DateTime) order by SoBenhAn desc"
            cmd = New SqlCommand(SQL, Cn)
            rd = cmd.ExecuteReader()
            If Not rd.HasRows Then
                LaySoBenhAn_PHCN = "PHCN\00001"
                rd.Close()
                cmd.Dispose()
                Exit Function
            End If
            'đọc phần tử đầu tiên
            If rd.Read Then
                Dim so As Integer = CInt(rd!Sobenhan)
                so += 1
                LaySoBenhAn_PHCN = "PHCN\"
                'For i As Int16 = 1 To (5 - CStr(so).Length)
                '    LaySoBenhAn &= "0"
                'Next
                'LaySoBenhAn &= CStr(so)
                LaySoBenhAn_PHCN &= Replace(Space(5 - CStr(so).Length), " ", "0") & CStr(so)
            End If
            rd.Close()
            cmd.Dispose()
        Catch ex As Exception
        End Try
        Try
            rd.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If (txtThoiGianCD.ValueIsDbNull) Then
            MessageBox.Show("Chưa nhập thời gian chỉ định!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtThoiGianCD.Focus()
            Exit Sub
        End If
        Dim i As Integer, CurrentRow As Integer, j As Integer
        Dim MaPhieuCD As String, MaLoaiphieuCD As String = ""
        Dim CapCuu As Byte = 0
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandTimeout = 0
        Dim trn As SqlClient.SqlTransaction
        trn = Cn.BeginTransaction()
        SQLCmd.Transaction = trn
        Try
            If rdCapCuu.Checked Then CapCuu = 1
            If isAddNew Then
                MaPhieuCD = "CD"
                CurrentRow = -1
            Else
                MaPhieuCD = lblChiTietPhieu.Tag.ToString()
                CurrentRow = fgListChiDinh.Row
                If fg.Rows.Count = 1 Then 'Nếu sửa mà xóa hết các dịch vụ
                    SQLCmd.CommandText = String.Format("DELETE FROM tblKHAMBENH_CHIDINH WHERE MaPhieuCD='{0}'", MaPhieuCD)
                    SQLCmd.ExecuteNonQuery()
                    SQLCmd.CommandText = String.Format("DELETE FROM tblKHAMBENH_DICHVU WHERE MaPhieuCD='{0}' ", MaPhieuCD)
                    SQLCmd.ExecuteNonQuery()
                End If
            End If
            For i = 1 To fg.Rows.Count - 1 ' Duyệt đến cuối danh sách các chỉ định đã soạn
                If Not fg.Rows(i).IsNode Then ' Nếu là nút con (là dịch vụ)
                    If fg(i, "MaLoaiphieuCD").ToString().Trim() <> MaLoaiphieuCD Then ' Nếu là 1 loại phiếu CĐ mới
                        MaLoaiphieuCD = fg(i, "MaLoaiphieuCD").ToString().Trim() ' Gán MaLoaiphieuCD = Loại phiếu CĐ mới
                        Dim Sobenhan As String = ""
                        If MaLoaiphieuCD = "TP" Then Sobenhan = LaySoBenhAn_PHCN()
                        If fg(i, "MaLoaiphieuCD").ToString().Trim() <> PhieuChidinh_Header Then 'Them mới phieu chi dinh vao bảng Header: tblKhambenh_Chidinh
                            MaPhieuCD = "CD"
                        Else
                            MaPhieuCD = lblChiTietPhieu.Tag.ToString()
                        End If
                        SQLCmd.CommandText = String.Format("EXECUTE Spd_SavePhieuChiDinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm}','{4}','{5}','{6}','{7}',N'{8}','{9}',N'{10}',N'{11}',N'{12}'", txtMabenhnhan.Text, txtMaKhambenh.Text, MaPhieuCD, txtThoiGianCD.Value, MaKhoaphong, TenDangNhap, "", CapCuu, txtPhieuChiDinh_GhiChu.Text, MaLoaiphieuCD, GetSetting("PHONGKHAM", "Thuoctinh", "Tenbacsi_Ca", ""), txtYta.Text.Trim, Sobenhan)
                        MaPhieuCD = SQLCmd.ExecuteScalar().ToString()
                        SQLCmd.CommandText = String.Format("DELETE FROM tblKHAMBENH_DICHVU WHERE MaPhieuCD='{0}' AND DaThucHien=0 AND DaDuyet=0", MaPhieuCD)
                        SQLCmd.ExecuteNonQuery()

                        For j = i To fg.Rows.Count - 1
                            If fg.Rows(j).IsNode Then Exit For
                            'Them vao bang KHAMBENH_DICHVU (Chi tiet cua phieu Chi dinh)
                            'Nếu chưa thực hiện, chưa duyệt tài chính và vẫn loại phiếu cd đó
                            If fg.GetCellCheck(j, fg.Cols("DaThucHien").Index) <> C1.Win.C1FlexGrid.CheckEnum.Checked And fg.GetCellCheck(j, fg.Cols("DaDuyet").Index) <> C1.Win.C1FlexGrid.CheckEnum.Checked And fg(j, "MaLoaiphieuCD").ToString().Trim() = MaLoaiphieuCD Then
                                SQLCmd.CommandText = String.Format("INSERT INTO tblKHAMBENH_DICHVU (MaBenhNhan,MaKhamBenh,MaPhieuCD,MaDichVu,DVT,SoLuong,MaLoaiphieuCD,DaDuyet,DaThucHien,GhiChu) " _
                                & " VALUES ('{0}','{1}','{2}','{3}',N'{4}',{5},'{6}',0,0,N'{7}')", _
                                 txtMabenhnhan.Text, txtMakhambenh.Text, MaPhieuCD, fg(j, "MaDichVu"), _
                                 fg(j, "DVTinh"), fg(j, "SL"), fg(j, "MaLoaiphieuCD"), fg(j, "GhiChu"))
                                SQLCmd.ExecuteNonQuery()
                            End If
                        Next
                    End If
                End If
            Next
            trn.Commit()
            LockEdit(True)
            Load_PhieuChiDinh(fgListChiDinh)
            fgListChiDinh.Row = CurrentRow
        Catch ex As Exception
            trn.Rollback()
            MessageBox.Show("Có lỗi khi ghi dữ liệu! " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLCmd.Dispose()
            trn.Dispose()
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Dim MaPhieuCD As String
        If (fgListChiDinh.Row > 0) Then
            MaPhieuCD = fgListChiDinh(fgListChiDinh.Row, "MaPhieuCD")
            LoadChiPhiChiTiet(MaPhieuCD)
        Else
            fg.Rows.Count = 1
        End If
        LockEdit(True)
    End Sub

    Private Sub fg_BeforeDeleteRow(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.BeforeDeleteRow
        If (fg.Rows(e.Row).IsNode Or Not cmdOK.Visible) Then e.Cancel = True
    End Sub

    Private Sub fg_AfterDeleteRow(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.AfterDeleteRow
        Refresh_Grid(fg)
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If fg.Row < 1 Or Not cmdOK.Visible Then
            e.Cancel = True
            Exit Sub
        End If
        If fg.Rows(fg.Row).IsNode Then mnuXoaDV.Enabled = False Else mnuXoaDV.Enabled = True
        ContextMenuStrip1.DropShadowEnabled = True
    End Sub

    Private Sub mnuXoaDV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuXoaDV.Click
        fg.RemoveItem(fg.Row)
        Refresh_Grid(fg)
    End Sub

    Private Sub cmdSoTay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSoTay.Click
        Dim frm As New frmNhapChiDinh()
        frm.fg = fg
        frm.IsAddNew = isAddNew
        frm.NguonChiDinh = 2
        frm.MaDoiTuongBN = cmbDoituong.SelectedValue
        frm.ShowDialog()
    End Sub

    Private Sub lblThemSoTayCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblThemSoTayCD.Click
        Dim MoTa As String = InputBox("Mô tả mặt bệnh:", "Thêm sổ tay chỉ định", "")
        If (MoTa = "") Then
            MessageBox.Show("Mặt bệnh không được để trống!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim ID_SoCD As String = "0"
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim trn As System.Data.SqlClient.SqlTransaction
        trn = Cn.BeginTransaction()
        SQLCmd.Transaction = trn
        Try
            SQLCmd.CommandText = String.Format("EXECUTE Spd_SaveSotayCD '{0}','{1}',N'{2}'", ID_SoCD, Tendangnhap, MoTa.Replace("'", "''"))
            ID_SoCD = SQLCmd.ExecuteScalar().ToString()
            SQLCmd.CommandText = "DELETE FROM tblSOTAYCHIDINH_CHITIET WHERE ID_SoCD=" & ID_SoCD
            SQLCmd.ExecuteNonQuery()
            Dim i As Integer
            For i = 1 To fg.Rows.Count - 1
                If Not fg.Rows(i).IsNode Then
                    SQLCmd.CommandText = String.Format("INSERT INTO tblSOTAYCHIDINH_CHITIET (ID_SoCD, MaDichvu,SoLuong,MaLoaiPhieuCD,GhiChu) VALUES ({0},'{1}',{2},'{3}',N'{4}')", ID_SoCD, fg(i, "MaDichVu"), fg(i, "SL"), fg(i, "MaLoaiPhieuCD").ToString(), fg(i, "GhiChu").ToString().Replace("'", "''"))
                    SQLCmd.ExecuteNonQuery()
                End If
            Next
            trn.Commit()
        Catch ex As Exception
            trn.Rollback()
            MessageBox.Show("Có lỗi khi ghi dữ liệu - " & ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SQLCmd.Dispose()
            trn.Dispose()
        End Try
    End Sub

    Private Sub cmdInPhieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInPhieu.Click
        Try
            If (lblChiTietPhieu.Tag.ToString() = "") Then
                MessageBox.Show("Chưa chọn phiếu chỉ định để in!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
            SQLCmd.CommandTimeout = 0
            Dim dr As System.Data.SqlClient.SqlDataReader
            Dim MaLoaiphieuCD As String = ""
            Dim i As Integer
            Dim CapCuu As Byte = IIf(rdCapCuu.Checked, 1, 0)

            For i = 1 To fg.Rows.Count - 1
                If Not fg.Rows(i).IsNode Then
                    If (MaLoaiphieuCD <> fg(i, "MaLoaiphieuCD").ToString()) And fg(i, "MaLoaiphieuCD").ToString() <> "TP" Then
                        Dim rpt As New rptPhieuChiDinh
                        rpt.Document.Name = "Phiếu chỉ định: " & lblChiTietPhieu.Tag.ToString()
                        rpt.Label8.Text = txtTieude.Text.Trim.ToUpper
                        rpt.lblMabenhnhan.Text = txtMakhambenh.Text
                        rpt.Barcode1.Text = txtMakhambenh.Text
                        If fg(i, "MaLoaiphieuCD").ToString() = "VS" Or fg(i, "MaLoaiphieuCD").ToString() = "MD" Then
                            'Nếu là phiếu VS, MD thì barcode là mã phiếu
                            rpt.Barcode1.Text = lblChiTietPhieu.Tag.ToString()
                        End If
                        rpt.Label20.Text = lblChiTietPhieu.Tag.ToString() 'txtMakhambenh.Text
                        rpt.MaPhieuCD = lblChiTietPhieu.Tag.ToString()
                        rpt.CapCuu = CapCuu
                        'rpt.KhoaThucHien = fg(i, "TenKhoa").ToString()
                        rpt.TenBN = txtTenbenhnhan.Text
                        rpt.Tuoi = IIf(txtTuoi.Text <> "", Year(NgayHienTai) - Val(txtTuoi.Text), 0)
                        rpt.Gioi = cmbGioitinh.Text
                        rpt.lblDoiTuong.Text = cmbDoituong.Text
                        If cmbDoituong.Text = "Bảo hiểm y tế" Then
                            rpt.DiaChi = "Cấp bậc: " + cmbCapbac.Text 'txtDiachi.Text
                            rpt.lblHanThe.Text = "Hạn thẻ: " & dtBHDen.Text
                            rpt.lblSoTheBHYT.Text = "Số thẻ BHYT: " & txtMaDT.Text + txtSotheBHYT.Text
                        End If
                        If cmbDoituong.Text = "Quân" Or cmbDoituong.Text = "Chính sách" Then
                            rpt.DiaChi = "Cấp bậc: " + cmbCapbac.Text
                            rpt.lblSoTheBHYT.Text = "Đơn vị: " & txtNoicongtac.Text
                        End If
                        If cmbDoituong.Text = "Dịch vụ" Then
                            rpt.DiaChi = "Địa chỉ: " + txtDiachi.Text
                        End If
                        rpt.lblNoiChiDinh.Text = "Nơi chỉ định: " & TenKhoaphong
                        rpt.lblGhiChu.Text = "Ghi chú: " & txtPhieuChiDinh_GhiChu.Text
                        rpt.TextBox7.Text = "Chẩn đoán: " & txtChandoan.Text
                        rpt.Label23.Text = "" '"Mã bệnh: " + txtMaBC.Text
                        rpt.lblNgayThang.Text = String.Format("{0:HH} giờ {0:mm} - Ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtThoiGianCD.Value)
                        rpt.lblBacSy.Text = GetSetting("PHONGKHAM", "Thuoctinh", "Tenbacsi_Ca", "")
                        If txtTieude.Tag = "1" Then 'Phiếu dạng chỉ định xét nghiệm
                            rpt.Label18.Visible = True
                            rpt.Label21.Visible = True
                            rpt.Label22.Visible = False
                            rpt.Label25.Visible = False
                            rpt.Label27.Visible = False
                            rpt.Label28.Visible = False
                            rpt.Label12.Visible = False

                            rpt.Label10.Visible = False
                            rpt.Label26.Visible = False
                            rpt.Label29.Visible = False
                            rpt.Label30.Visible = False
                            rpt.Label31.Visible = False
                            rpt.Label32.Visible = False

                            rpt.TextBox1.Width = 2.003
                            rpt.ReportFooter1.Height = 2.18
                        Else
                            rpt.Label18.Visible = False
                            rpt.Label21.Visible = False
                            rpt.Label22.Visible = False
                            rpt.Label25.Visible = True
                            rpt.Label27.Visible = True
                            rpt.Label28.Visible = True
                            rpt.Label12.Visible = True

                            rpt.Label5.Visible = False
                            rpt.Label6.Visible = False
                            rpt.Label15.Visible = False
                            rpt.Label16.Visible = False


                            rpt.TextBox2.Visible = False
                            rpt.TextBox3.Visible = False
                            rpt.TextBox10.Visible = False
                            rpt.TextBox11.Visible = False

                            rpt.Label10.Visible = True
                            rpt.Label26.Visible = True
                            rpt.Label29.Visible = True
                            rpt.Label30.Visible = True
                            rpt.Label31.Visible = True
                            rpt.Label32.Visible = True

                        End If
                        MaLoaiphieuCD = fg(i, "MaLoaiphieuCD").ToString()
                        If MaLoaiphieuCD = "TP" Then 'Thiết đặt phiếu chỉ định PHCN
                            rpt.Label15.Text = "Liều lượng"
                            rpt.Label16.Text = "Vị trí"
                            rpt.Label2.Text = "TG"
                            rpt.Label18.Visible = False
                            rpt.Label21.Visible = False
                            rpt.Label22.Visible = False
                            rpt.Label5.Visible = False
                            rpt.TextBox2.Visible = False
                            rpt.TextBox1.Width = 2.003
                            rpt.Picture1.Visible = True
                            rpt.Label17.Size = rpt.Label21.Size
                            rpt.Label19.Size = rpt.Label22.Size
                            rpt.Label17.Location = rpt.Label21.Location
                            rpt.Label19.Location = rpt.Label22.Location
                            rpt.Label15.Left = rpt.Label5.Left + rpt.Label6.Width
                            rpt.TextBox10.Location = rpt.TextBox3.Location
                            rpt.Label6.Location = rpt.Label5.Location
                            rpt.TextBox3.Location = rpt.TextBox2.Location
                            rpt.Label15.Width = 1.685
                            rpt.Label16.Left = rpt.Label15.Left + rpt.Label15.Width
                            rpt.Label16.Width = 0.75
                            rpt.TextBox10.Width = 1.56
                        End If
                        'If MaLoaiphieuCD = "TN" Then ' Nếu là phiếu thủ thuật Ngoại bỏ phần ghi chú
                        'rpt.TextBox6.DataField = ""
                        'End If
                        SQLCmd.CommandText = String.Format("EXECUTE Spd_Khambenh_ChiPhi '{0}','{1}'", lblChiTietPhieu.Tag.ToString(), cmbDoituong.SelectedValue)
                        dr = SQLCmd.ExecuteReader()
                        rpt.DataSource = dr
                        If chkXemPhieu.Checked Then
                            rpt.Show()
                        Else
                            rpt.Run()
                            rpt.Document.Print(chkHienHopChon.Checked, True)
                        End If
                        dr.Close()
                    End If
                    If (MaLoaiphieuCD <> fg(i, "MaLoaiphieuCD").ToString()) And fg(i, "MaLoaiphieuCD").ToString() = "TP" Then
                        Dim rpt As New rptBenhan_NgoaitruPHCN
                        rpt.Document.Name = "BỆNH ÁN NGOẠI TRÚ PHCN"
                        rpt.lblKhoa.Text = String.Format("{1}, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", txtThoiGianCD.Value, TinhTP)
                        rpt.Label15.Text = "Mã KB: " + txtMakhambenh.Text
                        rpt.Label16.Text = "Mã BA: " + txtPhieuChiDinh_GhiChu.Tag.ToString()
                        rpt.lblTenBN.Text = txtTenbenhnhan.Text
                        rpt.lblTuoi.Text = "Tuổi: " & IIf(txtTuoi.Text <> "", Year(DateTime.Now) - Val(txtTuoi.Text), 0)
                        rpt.lblGioi.Text = "Giới tính: " & cmbGioitinh.Text
                        rpt.lblHanThe.Text = "Cấp bậc: " + cmbCapbac.Text
                        rpt.lblSoTheBHYT.Text = "Số thẻ BHYT: " & txtMaDT.Text + txtSotheBHYT.Text
                        If cmbDoituong.Text = "Quân" Or cmbDoituong.Text = "Chính sách" Then
                            rpt.lblDiaChi.Text = txtNoicongtac.Text
                        Else
                            rpt.DiaChi = txtDiachi.Text
                        End If
                        rpt.TextBox2.Text = txtChandoan.Text
                        rpt.TextBox1.Text = txtChandoan.Text
                        rpt.Label18.Text = "" '"Mã bệnh: " + txtMaBC.Text
                        rpt.Label69.Text = GetSetting("PHONGKHAM", "Thuoctinh", "Tenbacsi_Ca", "")


                        'rpt.MaPhieuCD = lblChiTietPhieu.Tag.ToString()
                        'rpt.CapCuu = CapCuu


                        'rpt.lblDoituong.Text = cmbDoituong.Text
                        'If cmbDoituong.Text = "Bảo hiểm y tế" Then
                        '    'rpt.DiaChi = "Cấp bậc: " + cmbCapbac.Text 'txtDiachi.Text
                        '    rpt.lblHanThe.Text = cmbCapbac.Text '"Hạn thẻ: " & txtHandungtheBHYT_Den.Text
                        'End If



                        'GetSetting("PHONGKHAM", "Thuoctinh", "Tenbacsi_Ca", "") '
                        'If txtTieude.Tag = "1" Then 'Phiếu dạng chỉ định xét nghiệm
                        '    rpt.Label18.Visible = True
                        '    rpt.Label21.Visible = True
                        '    rpt.Label22.Visible = False
                        '    rpt.Label25.Visible = False
                        '    rpt.Label27.Visible = False
                        '    rpt.Label28.Visible = False
                        '    rpt.Label12.Visible = False

                        '    rpt.Label10.Visible = False
                        '    rpt.Label26.Visible = False
                        '    rpt.Label29.Visible = False
                        '    rpt.Label30.Visible = False
                        '    rpt.Label31.Visible = False
                        '    rpt.Label32.Visible = False
                        '    rpt.Label33.Visible = False
                        '    rpt.TextBox1.Width = 2.003
                        '    rpt.ReportFooter1.Height = 2.18
                        'Else
                        '    rpt.Label18.Visible = False
                        '    rpt.Label21.Visible = False
                        '    rpt.Label22.Visible = False
                        '    rpt.Label25.Visible = True
                        '    rpt.Label27.Visible = True
                        '    rpt.Label28.Visible = True
                        '    rpt.Label12.Visible = True

                        '    rpt.Label5.Visible = False
                        '    rpt.Label6.Visible = False
                        '    rpt.Label15.Visible = False
                        '    rpt.Label16.Visible = False


                        '    rpt.TextBox2.Visible = False
                        '    rpt.TextBox3.Visible = False
                        '    rpt.TextBox10.Visible = False
                        '    rpt.TextBox11.Visible = False

                        '    rpt.Label10.Visible = True
                        '    rpt.Label26.Visible = True
                        '    rpt.Label29.Visible = True
                        '    rpt.Label30.Visible = True
                        '    rpt.Label31.Visible = True
                        '    rpt.Label32.Visible = True
                        '    rpt.Label33.Visible = True
                        'End If
                        MaLoaiphieuCD = fg(i, "MaLoaiphieuCD").ToString()
                        'If MaLoaiphieuCD = "TP" Then 'Thiết đặt phiếu chỉ định PHCN
                        '    rpt.Label15.Text = "Liều lượng"
                        '    rpt.Label16.Text = "Vị trí"
                        '    rpt.Label2.Text = "TG"
                        '    rpt.Label18.Visible = False
                        '    rpt.Label21.Visible = False
                        '    rpt.Label22.Visible = False
                        '    rpt.Label5.Visible = False
                        '    rpt.TextBox2.Visible = False
                        '    rpt.TextBox1.Width = 2.003
                        '    rpt.Picture1.Visible = True
                        '    rpt.Label17.Size = rpt.Label21.Size
                        '    rpt.Label19.Size = rpt.Label22.Size
                        '    rpt.Label17.Location = rpt.Label21.Location
                        '    rpt.Label19.Location = rpt.Label22.Location
                        '    rpt.Label15.Left = rpt.Label5.Left + rpt.Label6.Width
                        '    rpt.TextBox10.Location = rpt.TextBox3.Location
                        '    rpt.Label6.Location = rpt.Label5.Location
                        '    rpt.TextBox3.Location = rpt.TextBox2.Location
                        '    rpt.Label15.Width = 1.685
                        '    rpt.Label16.Left = rpt.Label15.Left + rpt.Label15.Width
                        '    rpt.Label16.Width = 0.75
                        '    rpt.TextBox10.Width = 1.56
                        'End If
                        ''If MaLoaiphieuCD = "TN" Then ' Nếu là phiếu thủ thuật Ngoại bỏ phần ghi chú
                        ''rpt.TextBox6.DataField = ""
                        ''End If
                        rpt.SqlstrDT = String.Format("EXECUTE Spd_Khambenh_ChiPhi '{0}','{1}'", lblChiTietPhieu.Tag.ToString(), cmbDoituong.SelectedValue)
                        If chkXemPhieu.Checked Then
                            rpt.Show()
                        Else
                            rpt.Run()
                            rpt.Document.Print(chkHienHopChon.Checked, True)
                        End If
                    End If
                End If
            Next
            SQLCmd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub fgDichVu_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fgDichVu.DoubleClick
        If fgDichVu.Row < 1 Then Exit Sub
        If fgDichVu.Rows(fgDichVu.Row).IsNode Then
            fgDichVu.Rows(fgDichVu.Row).Node.Collapsed = Not fgDichVu.Rows(fgDichVu.Row).Node.Collapsed
            Exit Sub
        End If
        cmbNoidungTP.SelectedIndex = -1
        Dim i As Integer = fgDichVu.Row
        If fgDichVu(i, "MaLoaiphieuCD") = "TN" Then
            panTieuphau.Visible = True
            txtBacsy.Text = GetSetting("PHONGKHAM", "Thuoctinh", "Tenbacsi_Ca", "")
        Else
            fgDichVu_DoubleClickExtracted()
        End If
    End Sub
    Private Sub fgDichVu_DoubleClickExtracted()
        Dim MaCP As String
        Dim MaLoaiphieuCD As String
        Dim DonGia As Integer = 0
        Dim SoLuong As Integer
        Dim DaCoCP As Boolean
        Dim i As Integer, j As Integer
        i = fgDichVu.Row
        MaCP = fgDichVu(i, "MaDichVu")
        MaLoaiphieuCD = fgDichVu(i, "MaLoaiphieuCD")
        DonGia = fgDichVu(i, "DonGia")
        SoLuong = 1
        DaCoCP = False
        For j = 1 To fg.Rows.Count - 1
            If (fg(j, "MaDichVu") = MaCP) Then
                DaCoCP = True
                Exit For
            End If
        Next
        If Not DaCoCP Then
            ''Kiểm tra xem dịch vụ này có phải là thủ thuật ngoại khoa ko
            '' nếu đúng phải yêu cầu nhập Nội dung làm
            'If MaLoaiphieuCD = "TT" Then
            '    Dim Ghichu As String = InputBox("Nội dung làm:", "Chọn nội dung làm thủ thuật", "")
            '    If (Ghichu.Trim = "") Then
            '        MessageBox.Show("Phải chọn nội dung làm!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Exit Sub
            '    End If
            'End If
            Dim Ghichu As String = cmbNoidungTP.Text
            For j = fg.Rows.Count - 1 To 1 Step -1
                If fg(j, "MaLoaiphieuCD") = MaLoaiphieuCD Then Exit For
            Next
            If j = 0 Then
                fg.AddItem(String.Format("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|0|0|{9}", MaLoaiphieuCD, fgDichVu(i, "TenLoaiphieuCD"), fgDichVu(i, "TenLoaiDichVu"), MaCP, fgDichVu(i, "TenDichVu"), fgDichVu(i, "DVT"), SoLuong, DonGia, SoLuong * DonGia, Ghichu))
            Else
                fg.AddItem(String.Format("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|0|0|{9}", MaLoaiphieuCD, fgDichVu(i, "TenLoaiphieuCD"), fgDichVu(i, "TenLoaiDichVu"), MaCP, fgDichVu(i, "TenDichVu"), fgDichVu(i, "DVT"), SoLuong, DonGia, SoLuong * DonGia, Ghichu), j + 1)
            End If
        End If
        Refresh_Grid(fg)
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

    Private Sub fg_AfterResizeColumn(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.AfterResizeColumn
        fg.AutoSizeRows(0, 0, fg.Rows.Count - 1, fg.Cols.Count - 1, 1, AutoSizeFlags.None)
    End Sub

    Private Sub fgDichVu_AfterResizeColumn(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgDichVu.AfterResizeColumn
        fgDichVu.AutoSizeRows(0, 0, fgDichVu.Rows.Count - 1, fgDichVu.Cols.Count - 1, 1, AutoSizeFlags.None)
    End Sub

    Private Sub cmdClosePanChidinh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosePanChidinh.Click
        panChidinh.Visible = False
    End Sub

    'Private Sub cmdInPK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInPK.Click
    'Dim rpt As New rptPhieuKhambenh
    'If txtMakhambenh.Text.Trim() = "" Then Exit Sub
    'LuuPhieukham(txtMaphieukham.Text)
    ''If cmbXutri.SelectedIndex <> 2 And cmbXutri.SelectedIndex <> 5 And cmbXutri.SelectedIndex <> 6 And cmbXutri.SelectedIndex <> 9 Then
    ''    MsgBox("Chỉ in phiếu khám bệnh khi Kê đơn - Nhập viện - Chuyển viện - Chuyển khám chuyên khoa", MsgBoxStyle.Critical, "Message!")
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
    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub txtLocDichVu_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocDichVu.TextChanged
        Load_DichVu(cmbDoituong.SelectedValue, txtLocDichVu.Text.Trim())
    End Sub

    Private Sub llbChidinhDV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbChidinhDV.LinkClicked
        If ThemBenhNhanvaLankham() Then
            panChidinh.Visible = True
            Load_PhieuChiDinh(fgListChiDinh)
            LockEdit(True)
            Load_DichVu(cmbDoituong.SelectedValue)
        End If
    End Sub
    Private Sub SetPos_Start()
        Dim i
        With panChidinh
            .Location = New Point(Label1.Left, Panel1.Top)
            .Visible = False
        End With

        'With panICD
        '    .Top = 0
        '    .Left = 0
        '    .Visible = False
        'End With
        'With grdChiphi
        '    .Rows.Count = 1
        '    .Rows.Fixed = 1
        '    .Cols.Count = 14
        '    .Cols.Fixed = 0
        '    .Item(0, 0) = "MaLoaiDichvu"
        '    .Item(0, 1) = "TenLoaiDichvu"
        '    .Item(0, 2) = "MaChiphi"
        '    .Item(0, 3) = "Dịch vụ y tế"
        '    .Item(0, 4) = "ĐVT"
        '    .Item(0, 5) = "Số lượng"
        '    .Item(0, 6) = "Đơn giá"
        '    .Item(0, 7) = "Thành tiền"
        '    .Item(0, 8) = "Đơn giá BHYT"
        '    .Item(0, 9) = "Thành tiền"
        '    .Item(0, 10) = "Đã duyệt"
        '    .Item(0, 11) = "MakhoaTH"
        '    .Item(0, 12) = "Khoa thực hiện"
        '    .Item(0, 13) = "Đã thực hiện"
        '    .Cols(0).Visible = False
        '    .Cols(1).Visible = False
        '    .Cols(2).Visible = False
        '    .Cols(1).Visible = False
        '    .Cols(8).Visible = False
        '    .Cols(9).Visible = False
        '    .Cols(11).Visible = False
        '    .ExtendLastCol = True
        '    .Cols(10).DataType = GetType(Boolean)
        '    .Cols(13).DataType = GetType(Boolean)
        '    .Cols(6).TextAlign = TextAlignEnum.RightCenter
        '    .Cols(7).TextAlign = TextAlignEnum.RightCenter
        '    .Cols(8).TextAlign = TextAlignEnum.RightCenter
        '    .Cols(9).TextAlign = TextAlignEnum.RightCenter
        '    .Tree.Column = 3
        '    Dim cs0 As CellStyle = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
        '    cs0.ForeColor = Color.Black
        '    cs0.BackColor = Color.LightCyan
        '    cs0.Font = New Font(.Font, FontStyle.Bold)
        '    For i = 0 To .Cols.Count - 1
        '        .Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
        '    Next
        'End With
        'With grdDS_PhieuCD
        '    .ClipSeparators = "|;"
        'End With
        'With grdKQ_XN
        '    .Styles("Normal").WordWrap = True
        'End With
        'With grdKQ_XN
        '    .ClipSeparators = "|;"
        'End With
    End Sub
End Class