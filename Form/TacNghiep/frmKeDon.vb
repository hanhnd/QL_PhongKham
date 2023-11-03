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
Public Class frmKeDon
    Public sMaPhieuKham As String
    Public sMaBenhNhan As String
    Public sHoTen As String
    Public sGioiTinh As String
    Public sTuoi As String
    Public sDiaChi As String
    Public sChuanDoan As String
    Public sKetLuan As String
    Dim booThemdon, booSuadon As Boolean
    Dim Madonthuoc_Sua As String
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

    Private Sub frmKeDon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '1.Load danh muc thuoc
        '2.Load danh sach don thuoc da co
        Fill_DS_Donthuoc(sMaPhieuKham, grdDSDonthuoc, "")
        '3.Load danh sach don thuoc trong so tay
        DocDM()
    End Sub
    Private Sub DocDM()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet

        'Lấy các danh mục cần thiết

        SQLStr = "select ID_Sotaydonthuoc, Matbenh from tblSotayDonthuoc  where Bacsi = '" & TenDangNhap & "' order by Matbenh"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter
        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet
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

    Private Sub txtThuoc_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtThuoc.KeyUp
        'Chú ý : Key up
        Dim temp As String = ""
        Dim sql As String
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader = Nothing
        'Gộp Keyup và textchange vào 1 nhằm tránh tình trạng 2 thuóc tên như nhau 1 thuoc còn 1 thuoc het
        'đến khi chọn thuốc còn lại báo đã hết, ly do: khi đó txtthuoc_textchange, grdDMthuoc load lại, sẽ chọn row vào dòng hết thuốc

        If e.KeyCode = Keys.Down And grdSoanDonthuoc.Visible Then
            grdDMThuoc.Focus()
            grdDMThuoc.Row = 1
            Exit Sub
        End If
        Try
            If txtThuoc.Text = "" Then grdDMThuoc.Visible = False
            sql = "SELECT     TOP (100) PERCENT thuoc.ThuocID, thuoc.TenThuoc, thuoc.DonViTinh, nc.TenNuoc AS Noisanxuat," _
                  & " loai.TenLoai AS TenGoc, thuoc.DonGia AS DonGiaBHYT,'' As HamLuong,1 As SoLuong, " _
                  & " thuoc.DonGia AS DonGiaQCS, thuoc.DonGia, Lo.SoTon " _
                  & " FROM         Z125_QuanLyDuoc.dbo.DanhMucThuoc AS thuoc LEFT OUTER JOIN " _
                  & " Z125_QuanLyDuoc.dbo.NuocSanXuat AS nc ON thuoc.MaNuoc = nc.MaNuoc INNER JOIN " _
                  & " Z125_QuanLyDuoc.dbo.LoaiThuoc AS loai ON thuoc.LoaiThuoc = loai.MaLoai " _
                  & " LEFT JOIN (SELECT Lo.[ThuocID],sum(Lo.[SoLuong]) As SoTon,Lo.KhoID " _
                  & "           	FROM [Z125_QuanLyDuoc].[dbo].[LoThuoc] As Lo " _
                  & "           	 LEFT JOIN [Z125_QuanLyDuoc].[dbo].DanhMucThuoc DM ON Lo.ThuocID = DM.ThuocID " _
                  & "           	group by Lo.ThuocID, Lo.KhoID ) As Lo ON thuoc.ThuocID = Lo.ThuocID  " _
                  & "  WHERE  Tenthuoc like N'" & txtThuoc.Text & "%' "
            sql = sql + " ORDER BY thuoc.TenThuoc"

            cmd = New SqlCommand(sql, Cn)
            rd = cmd.ExecuteReader()
            If Not rd.HasRows Then
                grdDMThuoc.Visible = False
                rd.Close()
                Exit Sub
            Else
                grdDMThuoc.Visible = True
            End If
            With (grdDMThuoc)
                .Redraw = False
                .Rows.Count = 1
                .Cols.Count = 8
                .Cols.Fixed = 0
                .Rows.Fixed = 1
                .Item(0, 0) = "Mã thuốc"
                .Item(0, 1) = "Tên thuốc"
                .Item(0, 2) = "Tên gốc"
                .Item(0, 3) = "Hàm lượng"
                .Item(0, 4) = "Nơi sản xuất"
                .Item(0, 5) = "ĐVT"
                .Item(0, 6) = "Hết thuốc"
                .Item(0, 7) = "Slg Trong kho" '"Hết thuốc"
                .Cols(0).Visible = False
                .Cols(1).Width = 200
                .Cols(6).DataType = GetType(Boolean)
                .Cols(6).Visible = False
                .Cols(2).Visible = False
                .Cols(5).Width = 50
                Do While rd.Read
                    .AddItem(rd!ThuocID & vbTab & rd!Tenthuoc & vbTab & rd!TenGoc & vbTab & rd!Hamluong & vbTab & rd!Noisanxuat & vbTab & rd!DonViTinh & vbTab & IIf(rd!Soluong <= 0, True, False) & vbTab & rd!SoTon)
                Loop
                .Redraw = True
                '.AutoSizeCols()
                .ExtendLastCol = True
            End With
            rd.Close()
            cmd.Dispose()
            Exit Sub
        Catch ex As Exception
            rd.Close()
        End Try
    End Sub

    Private Sub grdDMThuoc_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDMThuoc.DoubleClick
        If grdDMThuoc.Item(grdDMThuoc.Row, 6) = True Then
            MsgBox("Chú ý: Kho hết thuốc không cho phép kê.", MsgBoxStyle.Critical, "Message!")
            txtThuoc.Tag = ""
            txtThuoc.Text = ""
            grdDMThuoc.Visible = False
            txtThuoc.Focus()
            Exit Sub
        End If
        Try
            txtThuoc.Tag = grdDMThuoc.Item(grdDMThuoc.Row, 0)
            txtTengoc.Text = grdDMThuoc.Item(grdDMThuoc.Row, 2)
            txtHamluong.Text = grdDMThuoc.Item(grdDMThuoc.Row, 3)
            txtDVT_Thuoc.Text = grdDMThuoc.Item(grdDMThuoc.Row, 5)
            txtThuoc.Text = grdDMThuoc.Item(grdDMThuoc.Row, 1)
            txtSoluong_Thuoc.Focus()
            grdDMThuoc.Visible = False
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub grdDSDonthuoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDSDonthuoc.Click
        If grdDSDonthuoc.Row > 0 Then
            Fill_Donthuoc(grdDSDonthuoc.Item(grdDSDonthuoc.Row, 1), grdSoanDonthuoc)
            lblChitiet_Donthuoc.Text = "Danh sách các thuốc kê trong đơn   " + grdDSDonthuoc.Item(grdDSDonthuoc.Row, 1).ToString.Trim() + "   lúc: " + grdDSDonthuoc.Item(grdDSDonthuoc.Row, 2)
            lblChitiet_Donthuoc.Tag = grdDSDonthuoc.Item(grdDSDonthuoc.Row, 1).ToString.Trim()
        End If
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

    Private Sub cmdThem_Thuoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem_Thuoc.Click
        Dim i
        Dim cmd As SqlCommand
        Dim TenthuocThem As String = ""
        Dim cachdung As String

        'Kiểm tra xem đã có tên chưa
        If txtThuoc.Text.Trim() = "" Then Exit Sub
        ' Kiem tra xem da co trong Don chua
        If grdSoanDonthuoc.Rows.Count > 1 Then
            For i = 1 To grdSoanDonthuoc.Rows.Count - 1
                If txtThuoc.Text = grdSoanDonthuoc.Item(i, 2) Then
                    MsgBox("Thuốc này đã có trong đơn. Không cho phép thêm mới", MsgBoxStyle.Critical, "Message!")
                    Exit Sub
                End If
                If optThuocCap.Checked <> grdSoanDonthuoc.Item(i, 8) Or optThuocTutuc.Checked = grdSoanDonthuoc.Item(i, 8) Then
                    MsgBox("Không được kê hai loại thuốc (cấp - tự túc) trong cùng đơn.", MsgBoxStyle.Critical, "Message!")
                    Exit Sub
                End If
            Next
        End If
        If txtSoluong_Thuoc.Text = "" Then
            MsgBox("Số lượng chưa đúng", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        End If
        If txtSoluong_Thuoc.Value <= 0 Then
            MsgBox("Số lượng chưa đúng", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        End If
        If optThuocCap.Checked And txtThuoc.Tag = "" Then ' Nếu là thuốc bảo hiểm thì phải chọn trong DM thuốc BH (kho thuốc cấp)
            MsgBox("Thuốc cấp phải chọn trong danh mục", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        End If
        If optThuocTutuc.Checked And txtThuoc.Tag = "" Then ' Trường hợp thuốc tự túc chưa có trong DM thuốc của BV, hỏi xem có phải thêm vào DM hay ko, nếu có thì thêm
            MsgBox("Thuốc chưa có trong danh mục của bệnh viện. Bạn hãy tìm lại trong danh mục?", MsgBoxStyle.OkOnly, "Message!")
            Exit Sub
        End If
        If txtThuoc.Tag.ToString() = "" Then Exit Sub
        ' Kiem tra xem thuoc da ke chưa
        Dim Madon_dake As String = ""
        cachdung = ""
        If Trim(txtNgaydung.Text) <> "" Then cachdung = cachdung + "Dùng " + Trim(txtNgaydung.Text) + " / ngày:"
        If Trim(txtSang.Text) <> "" Then cachdung = cachdung + " Sáng " + Trim(txtSang.Text) + " -"
        If Trim(txtTrua.Text) <> "" Then cachdung = cachdung + " Trưa " + Trim(txtTrua.Text) + " -"
        If Trim(txtChieu.Text) <> "" Then cachdung = cachdung + " Chiều " + Trim(txtChieu.Text) + " -"
        If Trim(txtToi.Text) <> "" Then cachdung = cachdung + " Tối " + Trim(txtToi.Text)
        If Len(cachdung) > 1 Then
            If VB6.Right(cachdung, 8) = " / ngày:" Then
                cachdung = VB6.Left(cachdung, Len(cachdung) - 2)
            Else
                If VB6.Right(cachdung, 2) = " -" Then
                    cachdung = VB6.Left(cachdung, Len(cachdung) - 2)
                End If
            End If
        End If
        If Trim(txtCachdung_Thuoc.Text) <> "" Then cachdung = cachdung + " (" + Trim(txtCachdung_Thuoc.Text) + ")"
        grdSoanDonthuoc.AddItem(Str(grdSoanDonthuoc.Rows.Count) & vbTab & txtThuoc.Tag & vbTab & txtThuoc.Text & vbTab & txtTengoc.Text & vbTab & txtHamluong.Text & vbTab & txtDVT_Thuoc.Text & vbTab & txtSoluong_Thuoc.Text & vbTab & cachdung & vbTab & optThuocCap.Checked)
        grdSoanDonthuoc.AutoSizeCols()
        txtThuoc.Text = ""
        txtThuoc.Tag = ""
        txtDVT_Thuoc.Text = ""
        txtSoluong_Thuoc.ValueIsDbNull = True
        txtCachdung_Thuoc.Text = ""
        txtThuoc.Focus()
        grdDMThuoc.Visible = False
    End Sub

    Private Sub cmbMatbenh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMatbenh.TextChanged
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Dim temp As String = ""
        If cmdThemdon.Enabled = True Or Not chkDontheomau.Checked Then Exit Sub
        Try
            grdSoanDonthuoc.Rows.Count = 1
           
            SQL = "SELECT a.*,b.Tenthuoc as Ten , b.Tengoc, 1 as SLHT  FROM  tblSOTAYDONTHUOC_CT a " _
            & " left outer join " & TenDatabase & ".DBO.vDanhmucThuoc b  on a.ThuocID = b.ThuocID " _
            & " where a.ID_SotayDonthuoc =  " & cmbMatbenh.SelectedValue & "  order by Thutu"
            'End If
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    If ds.Tables("Hoso").Rows(i).Item("SLHT") > 0 Then
                        grdSoanDonthuoc.AddItem(grdSoanDonthuoc.Rows.Count & vbTab & ds.Tables("Hoso").Rows(i).Item("ThuocID") & vbTab & ds.Tables("Hoso").Rows(i).Item("Ten") & vbTab & vbTab & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong") & vbTab & ds.Tables("Hoso").Rows(i).Item("Cachdung") & vbTab & IIf(ds.Tables("Hoso").Rows(i).Item("Thuocmua") = 0, True, False))
                    Else
                        MsgBox("Chú ý: " + ds.Tables("Hoso").Rows(i).Item("Ten") + " đã hết", MsgBoxStyle.Information, "Message!")
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Lock_Ctr_Kedon(ByVal DK As Boolean)
        cmdThemdon.Enabled = Not DK
        cmdSuadon.Enabled = Not DK
        cmdXoadon.Enabled = Not DK
        cmdLuu_XemDonthuoc.Enabled = Not DK
        cmdClosepanDonthuoc.Enabled = Not DK
        grdDSDonthuoc.Enabled = Not DK

        cmdLuuDonthuoc.Enabled = DK
        cmdKhongLuuDonthuoc.Enabled = DK
        cmdLaydontruoc.Enabled = DK
        cmdThem_Thuoc.Enabled = DK
    End Sub
    Private Sub cmdThemdon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThemdon.Click
        If grdDSDonthuoc.Rows.Count > 1 Then
            If MsgBox("Bạn có chắc chắn muốn thêm mới một đơn thuốc nữa không?", MsgBoxStyle.YesNo, "Yêu cầu xác nhận") = MsgBoxResult.No Then Exit Sub
        End If
        Madonthuoc_Sua = ""
        cmbMatbenh.Text = ""
        cmbMatbenh.SelectedValue = ""
        Lock_Ctr_Kedon(True)
        booThemdon = True
        grdSoanDonthuoc.Rows.Count = 1
        txtThuoc.Focus()
    End Sub

    Private Sub cmdSuadon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSuadon.Click
        If grdDSDonthuoc.Row < 1 Then
            MsgBox("Chưa chọn đơn thuốc để sửa.", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        Else
            Madonthuoc_Sua = grdDSDonthuoc.Item(grdDSDonthuoc.Row, 1)
        End If
        Lock_Ctr_Kedon(True)
        booSuadon = True
        txtThuoc.Focus()
    End Sub

    Private Sub cmdXoadon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXoadon.Click
        If lblChitiet_Donthuoc.Tag <> "" And grdDSDonthuoc.Row > 0 Then
            If MsgBox("Bạn có chắc chắn xóa đơn thuốc này không", MsgBoxStyle.YesNo, "Yêu cầu xác nhận!") = MsgBoxResult.No Then Exit Sub
            Dim Tran As SqlTransaction
            Dim Cmd As New SqlCommand
            Tran = Cn.BeginTransaction()
            Try
                Cmd.Connection = Cn
                Cmd.Transaction = Tran
                Cmd.CommandText = "Delete from tblKhambenh_Donthuoc where makhambenh =  '" & sMaPhieuKham & "' and MaPhieuCD = '" & lblChitiet_Donthuoc.Tag & "' "
                Cmd.ExecuteNonQuery()
                Cmd.CommandText = "Delete from tblKhambenh_Dichvu where makhambenh =  '" & sMaPhieuKham & "' and MaPhieuCD = '" & lblChitiet_Donthuoc.Tag & "' "
                Cmd.ExecuteNonQuery()
                Cmd.CommandText = "Delete from tblKhambenh_Chidinh where makhambenh =  '" & sMaPhieuKham & "' and MaPhieuCD = '" & lblChitiet_Donthuoc.Tag & "' "
                Cmd.ExecuteNonQuery()
                Tran.Commit()
                Cmd.Dispose()
                Fill_DS_Donthuoc(sMaPhieuKham, grdDSDonthuoc, "")
            Catch ex As Exception
                MsgBox(ex.Message)
                Tran.Rollback()
            End Try
        End If
    End Sub

    Private Sub cmdLuu_XemDonthuoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLuu_XemDonthuoc.Click
        If grdSoanDonthuoc.Rows.Count < 2 Or lblChitiet_Donthuoc.Tag = "" Then Exit Sub

        'LuuDonthuoc(txtMaphieukham.Text)
        Dim NgayHT As Date
        Dim frm As New frmPreview
        frm.Tenbenhnhan = sHoTen
        frm.Namsinh = sTuoi
        frm.Gioitinh = sGioiTinh
        frm.Doituong = ""
        frm.Diachi = sDiaChi
        frm.lblDIachi_Capbac = "Địa chỉ: "
        frm.Ketluanbenh = sKetLuan
        frm.Mabenh = ""
        frm.Loidan = txtLoidan.Text
        NgayHT = GetSrvDate()
        frm.Ngaydonthuoc = "Ngày " + Format(NgayHT, "dd") + " tháng " + Format(NgayHT, "MM") + " năm " + Format(NgayHT, "yyyy")
        'frm.SQL_str = "Select * from tblKhambenh_Donthuoc left outer join DMThuoc on tblKhambenh_Donthuoc.Mathuoc = DMThuoc.ThuocID " _
        frm.SQL_str = "Select Mabenhnhan, Makhambenh,MaphieuCD, STT,('   ' + tenthuoc) as tenthuoc,TenGoc,Hamluong,DVT, " _
        & " Soluong, ('   ' + Cachdung) as Cachdung, (1- Thuocmua) as ThuocCap, Thuocmua  from tblKhambenh_Donthuoc   " _
        & " where MaphieuCD = '" & lblChitiet_Donthuoc.Tag & "' and MaKhambenh =  '" & sMaPhieuKham & "' order by Stt,Thuocmua" ' and Thuocmua= 0"
        '& " where Mabenhnhan = '" & txtMabenhnhan.Text & "'  and MaKhambenh =  '" & txtMakhambenh.Text & "' and Maphieukham =  '" & txtMaphieukham.Text & "' order by Thuocmua" ' and Thuocmua= 0"
        frm.Goi = "Don thuoc"
        If chkXemTruocKhiInDonThuoc.Checked Then
            frm.ShowDialog()
        Else
            frm.arViewer_Load(Nothing, Nothing)
            frm.arViewer.Document.Print(False, True, False)
            'frm.arViewer.Document.Print(False, True, False)
        End If
    End Sub

    Private Sub cmdLuuDonthuoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLuuDonthuoc.Click
        LuuDonthuoc(sMaPhieuKham, Madonthuoc_Sua)
        booThemdon = False
        booSuadon = False
        Lock_Ctr_Kedon(False)
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
                If grdSoanDonthuoc.Rows.Count < 1 Then
                    MsgBox("Chưa có thuốc để lưu", MsgBoxStyle.Critical, "Message!")
                    Exit Sub
                End If
                'Thêm Đơn thuốc (1 loại phiếu chỉ định) vào tblKHAMBENH_CHIDINH
                Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','DT',N'{8}',N'{9}', N'{10}'", sMaBenhNhan, sMaPhieuKham, "DT", ThoigianHT, MaKhoaphong, TenDangNhap, "A01117", 0, GetSetting("PHONGKHAM", "Thuoctinh", "Tenbacsi_Ca", ""), "", "")
                Dim MaCD As String = Cmd.ExecuteScalar() ' Lấy mã phiếu chỉ định (thuốc) mới
                lblChitiet_Donthuoc.Tag = MaCD
                lblChitiet_Donthuoc.Text = "Danh sách các thuốc kê trong đơn   " + MaCD
                'Thêm Thuốc đã kê vào tblKHAMBENH_DICHVU và tblKHAMBENH_DONTHUOC
                For i = 1 To grdSoanDonthuoc.Rows.Count - 1
                    Cmd.CommandText = "Insert into tblKHAMBENH_DICHVU ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaDichvu,DVT,Soluong,KhoaThuchien,Daduyet,DaThuchien,Ghichu,Tutuc,Thutuchidinh) " _
                    & " values ( '" & sMaBenhNhan & "','" & sMaPhieuKham & "', " _
                    & " '" & MaCD & "','" & grdSoanDonthuoc.Item(i, 1) & "', " _
                    & "  N'" & Replace(grdSoanDonthuoc.Item(i, 5), "'", "''") & "'," & grdSoanDonthuoc.Item(i, 6) & ", " _
                    & "  '" & MaKhoaphong & "', " _
                    & " 0, 0,''," & 1 - grdSoanDonthuoc.Item(i, 8) & "," & Val(grdSoanDonthuoc.Item(i, 0)) & ")"
                    Cmd.ExecuteNonQuery()
                    Cmd.CommandText = "Insert into tblKHAMBENH_DONTHUOC ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaThuoc,Maphieukham,STT,Tenthuoc,Tengoc, Hamluong,Soluong,	DVT,	Cachdung,	ThuocMua,	Daduyet,	Dathuchien,	Soluongcap,	Ghichu) " _
                    & " values ( '" & sMaBenhNhan & "','" & sMaPhieuKham & "', " _
                    & " '" & MaCD & "','" & grdSoanDonthuoc.Item(i, 1) & "', '" & Ma & "'," & Val(grdSoanDonthuoc.Item(i, 0)) & ", " _
                    & "  N'" & Replace(grdSoanDonthuoc.Item(i, 2), "'", "''") & "',N'" & Replace(grdSoanDonthuoc.Item(i, 3), "'", "''") & "', " _
                    & " N'" & Replace(grdSoanDonthuoc.Item(i, 4), "'", "''") & "'," & grdSoanDonthuoc.Item(i, 6) & ", " _
                    & " N'" & Replace(grdSoanDonthuoc.Item(i, 5), "'", "''") & "', N'" & Replace(grdSoanDonthuoc.Item(i, 7), "'", "''") & "'," & IIf(grdSoanDonthuoc.Item(i, 8), 0, 1) & " ," _
                    & " 0,0,0,'')"
                    Cmd.ExecuteNonQuery()
                Next
            Else ' ****** Trường hợp sửa đơn thuốc *******
                ' (Chú ý: sau này dược ngoại trú hoạt động tốt phải kiểm tra xem đã cấp chưa, nếu đã cấp ko cho sửa)
                If MsgBox("Bạn có chắc chắn muốn ghi đè đơn thuốc cũ không?", MsgBoxStyle.YesNo, "Yêu cầu xác nhận") = MsgBoxResult.No Then Exit Sub
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
                Cmd.CommandText = String.Format("Execute spd_SavePhieuchidinh '{0}','{1}','{2}','{3:MM/dd/yyyy HH:mm:ss}','{4}','{5}','{6}','{7}','','DT',N'{8}',N'{9}',N'{10}'", sMaBenhNhan, sMaPhieuKham, "DT", ThoigianHT, MaKhoaphong, TenDangNhap, "A01117", 0, GetSetting("PHONGKHAM", "Thuoctinh", "Tenbacsi_Ca", ""), "", "")
                Dim MaCD As String = Cmd.ExecuteScalar() ' Lấy mã phiếu chỉ định (thuốc) mới
                'Thêm Thuốc đã kê vào tblKHAMBENH_DICHVU và tblKHAMBENH_DONTHUOC
                For i = 1 To grdSoanDonthuoc.Rows.Count - 1
                    Cmd.CommandText = "Insert into tblKHAMBENH_DICHVU ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaDichvu,DVT,Soluong,KhoaThuchien,Daduyet,DaThuchien,Ghichu,Tutuc,Thutuchidinh) " _
                    & " values ( '" & sMaBenhNhan & "','" & sMaPhieuKham & "', " _
                    & " '" & MaCD & "','" & grdSoanDonthuoc.Item(i, 1) & "', " _
                    & "  N'" & Replace(grdSoanDonthuoc.Item(i, 5), "'", "''") & "'," & grdSoanDonthuoc.Item(i, 6) & ", " _
                    & "  '" & MaKhoaphong & "', " _
                    & " 0, 0,''," & 1 - grdSoanDonthuoc.Item(i, 8) & "," & Val(grdSoanDonthuoc.Item(i, 0)) & ") "
                    Cmd.ExecuteNonQuery()
                    Cmd.CommandText = "Insert into tblKHAMBENH_DONTHUOC ( MaBenhnhan, MaKhambenh, MaphieuCD, " _
                    & " MaThuoc,Maphieukham,STT,Tenthuoc,Tengoc, Hamluong,Soluong,	DVT,	Cachdung,	ThuocMua,	Daduyet,	Dathuchien,	Soluongcap,	Ghichu) " _
                    & " values ( '" & sMaBenhNhan & "','" & sMaPhieuKham & "', " _
                    & " '" & MaCD & "','" & grdSoanDonthuoc.Item(i, 1) & "', '" & Ma & "'," & Val(grdSoanDonthuoc.Item(i, 0)) & ", " _
                    & "  N'" & Replace(grdSoanDonthuoc.Item(i, 2), "'", "''") & "',N'" & Replace(grdSoanDonthuoc.Item(i, 3), "'", "''") & "', " _
                    & " N'" & Replace(grdSoanDonthuoc.Item(i, 4), "'", "''") & "'," & grdSoanDonthuoc.Item(i, 6) & ", " _
                    & " N'" & Replace(grdSoanDonthuoc.Item(i, 5), "'", "''") & "', N'" & Replace(grdSoanDonthuoc.Item(i, 7), "'", "''") & "'," & IIf(grdSoanDonthuoc.Item(i, 8), 0, 1) & " ," _
                    & " 0,0,0,'')"
                    Cmd.ExecuteNonQuery()
                Next
            End If
            'Cập nhật lời dặn của bác sĩ vào bảng Kết quả Khám
            Cmd.CommandText = "Update tblKHAMBENH_KQDVKHAM set Loidan =  N'" & Replace(txtLoidan.Text, "'", "''") & "' " _
            & " where MaphieuCD = '" & Ma & "'"
            Cmd.ExecuteNonQuery()
            Tran.Commit()
            MsgBox("Đã kê đơn xong", MsgBoxStyle.Information, "Message!")
            Dim Madon As String = ""
            Fill_DS_Donthuoc(sMaPhieuKham, grdDSDonthuoc, Madon)
            If Madon <> "" Then Fill_Donthuoc(Madon, grdDonthuoc) 'Fill Đơn thuốc
            ''/FillChiphi(sMaPhieuKham)
            Exit Sub

        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdKhongLuuDonthuoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKhongLuuDonthuoc.Click
        Lock_Ctr_Kedon(False)
        If booThemdon Then grdSoanDonthuoc.Rows.Count = 1
        If booSuadon Then Fill_Donthuoc(grdDSDonthuoc.Item(grdDSDonthuoc.Row, 1), grdSoanDonthuoc)
        booThemdon = False
        booSuadon = False
    End Sub

    Private Sub cmdClosepanDonthuoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClosepanDonthuoc.Click
        Me.Close()
    End Sub

    Private Sub grdDMThuoc_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDMThuoc.KeyUp

        If e.KeyCode = Keys.Enter Then
            If grdDMThuoc.Item(grdDMThuoc.Row, 6) = True Then
                MsgBox("Chú ý: Kho hết thuốc không cho phép kê.", MsgBoxStyle.Critical, "Message!")
                txtThuoc.Tag = ""
                txtThuoc.Text = ""
                grdDMThuoc.Visible = False
                txtThuoc.Focus()
                Exit Sub
            End If
            txtThuoc.Tag = grdDMThuoc.Item(grdDMThuoc.Row, 0)
            txtTengoc.Text = grdDMThuoc.Item(grdDMThuoc.Row, 2)
            txtHamluong.Text = grdDMThuoc.Item(grdDMThuoc.Row, 3)
            txtDVT_Thuoc.Text = grdDMThuoc.Item(grdDMThuoc.Row, 5)
            txtThuoc.Text = grdDMThuoc.Item(grdDMThuoc.Row, 1)
            grdDMThuoc.Visible = False
            txtSoluong_Thuoc.Focus()
        End If
    End Sub

    Private Sub lblThemVaoSoTayDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblThemVaoSoTayDT.Click
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

            SQLCmd.CommandText = String.Format("INSERT INTO tblSOTAYDONTHUOC(Bacsi,Matbenh) VALUES ('{0}',N'{1}')    SELECT Max(ID_SotayDonthuoc) From tblSOTAYDONTHUOC", TenDangNhap, MoTa.Replace("'", "''"))
            ID_SoCD = SQLCmd.ExecuteScalar().ToString()
            'SQLCmd.CommandText = "DELETE FROM tblSOTAYDONTHUOC_CT WHERE ID_SotayDonthuoc=1" & ID_SoCD
            'SQLCmd.ExecuteNonQuery()
            Dim i As Integer
            For i = 1 To grdSoanDonthuoc.Rows.Count - 1
                If Not grdSoanDonthuoc.Rows(i).IsNode Then
                    SQLCmd.CommandText = String.Format("INSERT INTO tblSOTAYDONTHUOC_CT (ID_SotayDonthuoc, ThuocID,TenThuoc,TenGoc,HamLuong,ThuocMua,DVT,SoLuong,CachDung,ThuTu) VALUES ({0},N'{1}',N'{2}',N'{3}',N'{4}',{5},N'{6}',{7},N'{8}',{9})", ID_SoCD, grdSoanDonthuoc(i, 1), grdSoanDonthuoc(i, 2), grdSoanDonthuoc(i, 3).ToString(), grdSoanDonthuoc(i, 4).ToString(), 0, grdSoanDonthuoc(i, 5).ToString(), grdSoanDonthuoc(i, 6).ToString(), grdSoanDonthuoc(i, 7).ToString(), i)
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

        Dim da As SqlDataAdapter
        Dim DsDM As DataSet
        SQLStr = "select ID_Sotaydonthuoc, Matbenh from tblSotayDonthuoc where Bacsi = '" & TenDangNhap & "' order by Matbenh"
        Dim Cmd1 As SqlCommand
        Cmd1 = New SqlCommand(SQLStr, Cn)
        da = New SqlDataAdapter
        da.SelectCommand = Cmd1
        DsDM = New DataSet
        da.Fill(DsDM, "SotayDonthuoc")
        Cmd1.Dispose()

        cmbMatbenh.DataSource = DsDM.Tables("SotayDonthuoc")
        cmbMatbenh.DisplayMember = "Matbenh"
        cmbMatbenh.ValueMember = "ID_Sotaydonthuoc"
        cmbMatbenh.Text = ""
        cmbMatbenh.AutoDropDown = True
        da.Dispose()
        DsDM.Dispose()
        da = Nothing
        Cmd1 = Nothing
        DsDM = Nothing
    End Sub

    Private Sub grdSoanDonthuoc_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdSoanDonthuoc.KeyUp
        Dim i
        Try
            If e.KeyCode = Keys.Delete And (booSuadon Or booThemdon) Then
                If grdSoanDonthuoc.Row > 0 And MsgBox("Bạn có chắc chắn xóa thuốc này không?", MsgBoxStyle.YesNo, "Yêu cầu xác nhận") = MsgBoxResult.Yes Then
                    grdSoanDonthuoc.RemoveItem(grdSoanDonthuoc.Row)
                End If
            End If
            If grdSoanDonthuoc.Rows.Count > 1 Then
                For i = 1 To grdSoanDonthuoc.Rows.Count - 1
                    grdSoanDonthuoc.Item(i, 0) = i.ToString.Trim()
                Next
            End If
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class