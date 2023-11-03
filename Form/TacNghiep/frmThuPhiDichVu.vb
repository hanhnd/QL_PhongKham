Imports System.Data
Imports System.Data.SqlClient
Imports VB6 = Microsoft.VisualBasic
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
Public Class frmThuPhiDichVu
    Dim booThem As Boolean = False
    Private Truc_Taichinh As Byte = 0
    Private Sub DocDM()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet

        'Lấy các danh mục cần thiết
        SQLStr = "Select MaLoaiDichvu, TenLoaiDichvu from DMLoaiDichVu WHERE isSuDung = 1  ORDER BY Tentat"
        Cmd1 = New SqlCommand(SQLStr, Cn)
        Adap1 = New SqlDataAdapter
        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet
        Adap1.Fill(DsDM, "DMLoaiDichVu")
        Cmd1.Dispose()




        cmbLoaidichvu.DataSource = DsDM.Tables("DMLoaiDichVu")
        cmbLoaidichvu.DisplayMember = "TenLoaiDichvu"
        cmbLoaidichvu.ValueMember = "MaLoaiDichvu"
        cmbLoaidichvu.AutoDropDown = True


        Adap1.Dispose()
        DsDM.Dispose()
        Adap1 = Nothing
        Cmd1 = Nothing
        DsDM = Nothing
    End Sub

    Public Sub SetPos_Start()
        Dim i
        With grdThanhtoan
            .Tree.Column = 3
            Dim cs0 As CellStyle = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            cs0.ForeColor = Color.Blue
            cs0.BackColor = Color.White
            cs0.Font = New Font(.Font, FontStyle.Bold)
            For i = 0 To .Cols.Count - 1
                .Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
            Next
        End With

    End Sub

    Private Sub frmVienphi_Ngoaitru_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 And cmdThem.Visible Then
            cmdThem_Click(sender, e)
        End If
        If e.KeyCode = Keys.F9 And cmdGhi.Visible Then
            cmdGhi_Click(sender, e)
        End If
        If e.KeyCode = Keys.Escape And cmdHuy.Visible Then
            cmdHuy_Click(sender, e)
        End If
        If e.KeyCode = Keys.F10 And panIn.Visible Then
            cmdIn_Click(sender, e)
        End If
    End Sub

    Private Sub frmThanhtoanBHYT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPos_Start()
        DocDM()
        'cmdBatdau_Click(sender, e)
        If txtMaKhambenh.Text.Trim <> "" Then
            Lock_Control(True)
            txtMaKhambenh.Focus()
            booThem = True
            load_Data()
        End If
        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdThanhtoan, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdDichvu, Lang)
    End Sub

    Private Sub SetEmpty()
        txtMaKhambenh.Text = ""
        txtTenbenhnhan.Text = ""
        lblTienphaitra.ValueIsDbNull = True
        lblTongtien.ValueIsDbNull = True
        lblTienthua.ValueIsDbNull = True
        txtGiamtru.ValueIsDbNull = True
        txtBenhnhanNop.Value = 0
        grdThanhtoan.Rows.Count = 1
        'cmbPhongkham.Text = ""
        'cmbPhongkham.SelectedValue = ""
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub cmbLoaidichvu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoaidichvu.TextChanged
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Dim DK_LoaiDV

        Try
            DK_LoaiDV = IIf(cmbLoaidichvu.SelectedValue Is Nothing, "", "and LoaiDichvu =  '" & cmbLoaidichvu.SelectedValue & "' ")
            SQL = "Select a.*, b.Tentat as Tennhom_tat from DMDICHVU a" _
            & " INNER join DMLoaiDichVu b on a.LoaiDichVu = b.MaLoaiDichVu" _
            & " where TenDichvu like N'%" & Replace(txtDichvu.Text.Trim(), "'", "''") & "%'  and Khongsudung = 0 " + DK_LoaiDV 'and (a.noitru_ngoaitru = 2 or a.noitru_ngoaitru = 3) 
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            grdDichvu.Rows.Count = 1
            grdDichvu.Redraw = False
            If ds.Tables("Hoso").Rows.Count > 0 Then
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    grdDichvu.AddItem(ds.Tables("Hoso").Rows(i).Item("LoaiDichVu") & vbTab & ds.Tables("Hoso").Rows(i).Item("Tennhom_tat") _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("MaDichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenDichvu") _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & 1 _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("Dongia") _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("DongiaBHYT"))
                Next
            End If
            grdDichvu.AutoSizeRows()
            grdDichvu.Redraw = True
            Cmd.Dispose()
            Adap.Dispose()
            Adap.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Function Kiemtra_Dachon(ByVal madv As String) As Boolean
        Dim i
        Kiemtra_Dachon = False
        If grdThanhtoan.Rows.Count < 2 Then Exit Function
        For i = 1 To grdThanhtoan.Rows.Count - 1
            If grdThanhtoan.Item(i, 2) = madv Then ' nếu đã có
                Kiemtra_Dachon = True
                Exit Function
            End If
        Next
    End Function

    Private Sub grdThanhtoan_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdThanhtoan.AfterEdit
        If Not IsNumeric(grdThanhtoan.Item(e.Row, e.Col)) Then grdThanhtoan.Item(e.Row, e.Col) = 1
        grdThanhtoan.Item(e.Row, "THANHTIEN") = grdThanhtoan.Item(e.Row, "SOLUONG") * grdThanhtoan.Item(e.Row, "DONGIA") - grdThanhtoan.Item(e.Row, "MIENGIAM")
        grdThanhtoan.Redraw = False
        grdThanhtoan.Subtotal(AggregateEnum.Clear, 0, 1, 1, "{0}")
        grdThanhtoan.Styles.Normal.WordWrap = True
        grdThanhtoan.AutoSizeRows()
        lblTienphaitra.Value = TongtienDV()
        grdThanhtoan.Subtotal(AggregateEnum.None, 0, 1, 1, "{0}")
        grdThanhtoan.Subtotal(AggregateEnum.Sum, 0, 1, 8, "{0}")
        grdThanhtoan.Redraw = True
    End Sub

    Private Sub grdThanhtoan_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdThanhtoan.BeforeEdit
        If grdThanhtoan.Item(e.Row, 2) = "" Or booThem = False Then e.Cancel = True
    End Sub

    Private Sub grdThanhtoan_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdThanhtoan.KeyUp
        If e.KeyCode = Keys.Delete And grdThanhtoan.Row > 0 Then
            If MsgBox("Are you sure you want to delete the selected service?", MsgBoxStyle.YesNo, "Request confirmation!") = MsgBoxResult.No Then Exit Sub
            grdThanhtoan.Redraw = False
            grdThanhtoan.Subtotal(AggregateEnum.Clear, 0, 1, 1, "{0}")
            grdThanhtoan.RemoveItem(grdThanhtoan.Row)
            grdThanhtoan.Subtotal(AggregateEnum.None, 0, 1, 1, "{0}")
            grdThanhtoan.Subtotal(AggregateEnum.Sum, 0, 1, 8, "{0}")
            grdThanhtoan.Redraw = True
            lblTienphaitra.Value = TongtienDV()
        End If
    End Sub


    Private Sub txtMaKhambenh_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaKhambenh.KeyUp
        'Try
        '    If e.KeyCode = Keys.Enter Then
        '        txtMaKhambenh.Text = Trim(txtMaKhambenh.Text)
        '        AutoFill_Makhambenh(txtMaKhambenh)
        '        If Len(Trim(txtMaKhambenh.Text)) = 10 Then
        '            'Hiển thị các thông tin hành chính 
        '            FillDataKB(txtMaKhambenh.Text)
        '            'Hiển thị các dịch vụ chưa thu tiền
        '            FillDichvu(txtMaKhambenh.Text)
        '            Exit Sub
        '        End If
        '        If txtMaKhambenh.Text = "" Then ' Nội viện
        '            Dim frm As New frmTimBN_Noivien
        '            frm.ShowDialog()
        '            'Exit Sub
        '            txtMaKhambenh.Text = "N" + frm.MaVV_Tim
        '            txtTenbenhnhan.Text = frm.TenBN_Tim
        '            cmbPhongkham.SelectedValue = frm.Khoa_Tim
        '            grdThanhtoan.Rows.Count = 1
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        If e.KeyCode = Keys.Enter Then
            load_Data()
        End If

    End Sub
    Private Sub load_Data()
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim i As Integer
        Try

            txtMaKhambenh.Text = Trim(txtMaKhambenh.Text)
            If txtMaKhambenh.Text.Length >= 1 Then

                AutoFill_Makhambenh(txtMaKhambenh)
                If Len(Trim(txtMaKhambenh.Text)) = 10 Then
                    'Hiển thị các thông tin hành chính 
                    FillDataKB(txtMaKhambenh.Text)
                    'Hiển thị các dịch vụ chưa thu tiền
                    FillDichvu(txtMaKhambenh.Text)
                    Exit Sub
                End If
            End If
            If txtMaKhambenh.Text = "" Then ' Nội viện
                'Dim frm As New frmTimBN_Noivien
                'frm.ShowDialog()
                ''Exit Sub
                'txtMaKhambenh.Text = "N" + frm.MaVV_Tim
                'txtTenbenhnhan.Text = frm.TenBN_Tim
                'cmbPhongkham.SelectedValue = frm.Khoa_Tim
                'grdThanhtoan.Rows.Count = 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FillDichvu(ByVal Ma As String) 'Ma = Makhambenh
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim dsKhoa As DataSet
        Dim i
        Try
            If Trim(Ma) = "" Then Exit Sub
            grdDichvu.Rows.Count = 1
            With grdThanhtoan
                .Rows.Count = 1
                SQL = "select c.MaLoaiDichVu Manhom ,c.TenLoaiDichVu as Tennhom_Tat ,a.MaDichvu,b.TenDichvu, b.DVT, a.Soluong, a.Dongia, b.DuocMienGiam " _
                      & "  from tblKhambenh_Dichvu a " _
                      & "  inner join (Select * from DMDICHVU where Loaidichvu <> 'D01') b on a.MaDichvu = b.MaDichvu " _
                      & "  left outer join DMLoaiDichVu c on b.LoaiDichvu = c.MaLoaiDichVu  where a.Makhambenh = '" + txtMaKhambenh.Text.Trim + "' " _
                      & "  And a.Madichvu  not in  (Select distinct madichvu from tblPhieuthanhtoan p inner join tblPhieuthanhtoan_CT q on p.Sobienlai = q.Sobienlai " _
                      & "  where p.Nguoinop_maso = '" + txtMaKhambenh.Text.Trim + "' and p.Phieuhuy = 0) " _
                      & "  UNION ALL            " _
                      & "  select N'Thuốc' Manhom  ,N'Thuốc' as Tennhom_Tat ,a.MaThuoc MaDichvu,b.TenThuoc TenDichvu, b.DonviTinh DVT, a.Soluong, a.Dongia, 0 DuocMienGiam  " _
                      & "  from tblKhambenh_DonThuoc a   inner join (select * from DMTHUOC) b on a.Mathuoc = b.ThuocID                " _
                      & "  where a.Makhambenh = '" + txtMaKhambenh.Text.Trim + "' and a.MaThuoc not in  (Select distinct madichvu from tblPhieuthanhtoan p  " _
                      & " inner join tblPhieuthanhtoan_CT q on p.Sobienlai = q.Sobienlai  " _
                      & "  where p.Nguoinop_maso = '" + txtMaKhambenh.Text.Trim + "' and p.Phieuhuy = 0) "
                ' & " order by b.MaDichvu"
                Cmd = New SqlCommand(SQL, Cn)
                'Cmd.Parameters.AddWithValue("@Ma", Ma)
                Adap = New SqlDataAdapter
                Adap.SelectCommand = Cmd
                ds = New DataSet
                Adap.Fill(ds, "Hoso")
                Dim iRow As Integer = ds.Tables("HoSo").Rows.Count
                If iRow > 0 Then  'ds.Tables("Hoso").Rows.Count
                    Dim temp As String = ""
                    For i = 0 To iRow - 1 'ds.Tables("Hoso").Rows.Count - 1
                        'SQL = "select makhoa from DMDICHVU_KHOA where madichvu = '" & ds.Tables("Hoso").Rows(i).Item("MaDichvu") & "'"
                        'Cmd.CommandText = SQL
                        'Adap.SelectCommand = Cmd
                        'dsKhoa = New DataSet
                        'Adap.Fill(dsKhoa, "DSKHOA")
                        'If dsKhoa.Tables("DSKHOA").Rows.Count = 1 Then ' Có 1 và chỉ 1 khoa thực hiện, nhập vào cửa sổ bên phải để thu luôn
                        temp = ds.Tables("Hoso").Rows(i).Item("Manhom") & vbTab & ds.Tables("Hoso").Rows(i).Item("Tennhom_Tat")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("MaDichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenDichvu")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("Dongia") & vbTab & vbTab & ds.Tables("Hoso").Rows(i).Item("Dongia") * ds.Tables("Hoso").Rows(i).Item("Soluong")
                        'temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("DongiaBHYT") & vbTab & ds.Tables("Hoso").Rows(i).Item("DongiaBHYT") * ds.Tables("Hoso").Rows(i).Item("Soluong")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("DuocMienGiam")
                        'temp = temp & vbTab & dsKhoa.Tables("DSKHOA").Rows(0).Item("Makhoa")

                        If .Rows.Count > 1 Then
                            If .Item(.Rows.Count - 1, 2).ToString <> ds.Tables("Hoso").Rows(i).Item("MaDichvu").ToString Then ' Nếu dịch vụ chưa có thì mới thêm dòng
                                'tránh trường hợp bác sĩ chỉ định trùng nhiều mất công xóa bớt
                                .AddItem(temp)
                            End If
                        Else
                            .AddItem(temp)
                        End If
                        'Else ' Nếu chưa xác định được dịch vụ đó do khoa nào làm, chuyển sang bên trái để nv thu phí tự nhập khoa
                        '    grdDichvu.AddItem(ds.Tables("Hoso").Rows(i).Item("MaNhom") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenNhom_tat") _
                        '    & vbTab & ds.Tables("Hoso").Rows(i).Item("MaDichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenDichvu") _
                        '    & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong") _
                        '    & vbTab & ds.Tables("Hoso").Rows(i).Item("Dongia") _
                        '    & vbTab & ds.Tables("Hoso").Rows(i).Item("DuocMienGiam"))
                        'End If
                        'dsKhoa.Dispose()
                    Next
                End If
                .Subtotal(AggregateEnum.Sum, 0, 1, 8, "{0}")
            End With
            lblTienphaitra.Value = TongtienDV()
            Cmd.Dispose()
            Adap.Dispose()
            Adap.Dispose()
            ds = New DataSet
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillDataKB(ByVal MaKB As String)
        ' Thu tuc này fill cac thong tin hanh chinh bệnh nhân khi có MaKhambenh
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Try
            If Trim(MaKB) = "" Then Exit Sub
            SetEmpty()
            SQL = "select  b.Tenbenhnhan ,a.Doituong   ,'K' as Khoathuchien from dbo.tblKhambenh a " _
            & " left outer join dbo.tblBenhnhan b on  a.Mabenhnhan = b.Mabenhnhan " _
           & " where  a.Makhambenh = N'" & MaKB & "' "
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                txtMaKhambenh.Text = MaKB
                txtTenbenhnhan.Text = ds.Tables("Hoso").Rows(0).Item("TenBenhnhan")
                ' cmbPhongkham.SelectedValue = "K" 'ds.Tables("Hoso").Rows(0).Item("Khoathuchien")
                'If ds.Tables("Hoso").Rows(0).Item("Doituong").ToString <> "4" Then
                '    MsgBox("Chú ý: Không phải bệnh nhân dịch vụ", MsgBoxStyle.Information, "Message!")
                'End If
            Else
                MsgBox("The patient is not yet in the Database!", MsgBoxStyle.Information, "Message !")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function TongtienDV() As Double
        ' Hàm trả về tổng số tiền các dịch vụ BN phải thanh toán 
        Dim i
        Try
            TongtienDV = 0
            lblTongtien.ValueIsDbNull = True
            lblTongtien.Value = 0
            If grdThanhtoan.Rows.Count < 2 Then Exit Function
            For i = 1 To grdThanhtoan.Rows.Count - 1
                If grdThanhtoan.Item(i, 0) <> "" Then 'Nếu là mức con
                    lblTongtien.Value = lblTongtien.Value + Val(Replace(grdThanhtoan.Item(i, "SOLUONG"), ".", "")) * Val(Replace(grdThanhtoan.Item(i, "DONGIA"), ".", ""))
                    TongtienDV = TongtienDV + Val(Replace(grdThanhtoan.Item(i, "THANHTIEN"), ".", ""))
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub cmdThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem.Click
        Lock_Control(True)
        SetEmpty()
        txtMaKhambenh.Focus()
        booThem = True
    End Sub

    Private Sub Lock_Control(ByVal DK As Boolean)
        cmdGhi.Visible = DK
        cmdHuy.Visible = DK

        cmdThem.Visible = Not DK
        cmdThoat.Visible = Not DK
        cmdDSPhieuthu.Visible = Not DK
        cmdDsPhieuhuy.Visible = Not DK
        txtMaKhambenh.ReadOnly = Not DK
        txtTenbenhnhan.ReadOnly = Not DK
    End Sub

    Private Function Layso_Bienlai(ByVal NamThang As String) As String
        ' Thu tuc này lấy 1 số biên lai thanh toán Ngoại trú mới, cú pháp Năm(4) + Tháng(2) + Số TT
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Layso_Bienlai = NamThang.Trim() + "1"
        Try
            SQL = "Select max(cast(right(Sobienlai,len(sobienlai)-6) as Numeric)) as SoBLCuoi from tblPHIEUTHANHTOAN where left(Sobienlai,6) = '" & NamThang & "'"
            Cmd = New SqlCommand(SQL, Cn)
            Dr = Cmd.ExecuteReader
            If Not Dr.HasRows Then ' Chưa có phiếu khám nào
                Dr.Close()
                Exit Function
            Else
                Dr.Read()
                If IsDBNull(Dr!SoBLCuoi) Then
                    Layso_Bienlai = NamThang.Trim() + "1"
                Else
                    Layso_Bienlai = NamThang.Trim() + (Dr!SoBLCuoi + 1).ToString.Trim
                End If
                Dr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub cmdHuy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdHuy.Click
        Lock_Control(False)
        SetEmpty()
        cmdThem.Focus()
        booThem = False
    End Sub

    Private Sub cmdGhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGhi.Click
        Dim i As Int16 = 0
        Dim Sql As String = ""
        Dim Namsinh
        Dim Cmd As New SqlCommand
        Dim Tran As SqlTransaction = Nothing
        Dim Diengiai As String = ""
        If Not KiemtraHople() Then Exit Sub
        If MsgBox("Are you sure you have collected the money yet?", MsgBoxStyle.YesNo, "Message!") = MsgBoxResult.No Then Exit Sub

        Try
            'Thêm vào bảng tblThanhtoan

            Dim ThoigianHT As Date = GetSrvDate()
            Dim Namthang As String = String.Format("{0:yyyyMM}", ThoigianHT)
            Namsinh = ""
            'If txtTuoi.Value Is System.DBNull.Value Then
            '    Namsinh = "null"
            'Else
            '    Namsinh = txtTuoi.Value.ToString()
            'End If
            Dim SoBL As String = Layso_Bienlai(Namthang)
            'Sql = "Insert into tblPHIEUTHANHTOAN (Sobienlai,Nhanvienthanhtoan,Thoigianthanhtoan,Nguoinop_Hoten," _
            '& " Nguoinop_Maso,Nguoinop_Gioitinh,Nguoinop_Namsinh,Nguoinop_Diachi,Nguoinop_Khoa,Lydonop," _
            '& " Diengiai,Sotien,Phieuhuy,Nhanvienhuyphieu,Nhanvienhuyphieu,Thoigianhuyphieu,Lydohuyphieu,Ghichu) " _
            '& " values ()"
            For i = 1 To grdThanhtoan.Rows.Count - 1
                If grdThanhtoan.Item(i, 2) = "" Then
                    Diengiai = Diengiai + grdThanhtoan.Item(i, 3) + ": " + grdThanhtoan.Item(i, "THANHTIEN").ToString + " đồng, "
                End If
            Next
            Sql = "Insert into tblPHIEUTHANHTOAN (Sobienlai,Nhanvienthanhtoan,Thoigianthanhtoan,Nguoinop_Hoten," _
            & " Nguoinop_Maso, Nguoinop_Khoa,Lydonop," _
            & " Diengiai,Sotien ,Ghichu,PhieuHuy, Truc) " _
            & " values ('" & SoBL & "',N'" & Replace(TenDangNhap, "'", "''") & "','" & Format(ThoigianHT, "MM/dd/yyyy HH:mm") & "', " _
            & " N'" & Replace(txtTenbenhnhan.Text.Trim, "'", "''") & "',N'" & Replace(txtMaKhambenh.Text.Trim(), "'", "''") & "', " _
            & " 'K', " _
            & " N'" & lblLydo_In.Text.Trim & "',N'" & Replace(Diengiai, "'", "''") & "'," & lblTienphaitra.Value & ",'',0, " & Truc_Taichinh & ")"
            Tran = Cn.BeginTransaction
            Cmd.Connection = Cn
            Cmd.Transaction = Tran
            Cmd.CommandText = Sql
            Cmd.ExecuteNonQuery()
            For i = 1 To grdThanhtoan.Rows.Count - 1
                'Kiem tra xem co phải nút lá không?. Nếu lá nút lá thì ghi vào tblPHIEUTHANHTOAN_CT
                If grdThanhtoan.Item(i, 2) <> "" Then
                    Sql = "Insert into tblPHIEUTHANHTOAN_CT (Sobienlai,Madichvu,Soluong,Dongia,Thanhtien,Miengiam,Ghichu,Makhoa) values " _
                    & " ('" & SoBL & "','" & grdThanhtoan.Item(i, 2) & "', " & Val(grdThanhtoan.Item(i, "SOLUONG")) & ", " _
                    & " " & Val(grdThanhtoan.Item(i, "DONGIA")) & ", " & Val(grdThanhtoan.Item(i, "THANHTIEN")) & "," & Val(grdThanhtoan.Item(i, "MIENGIAM")) & ",'', '" & grdThanhtoan.Item(i, "MAKHOA") & "')"
                    Cmd.CommandText = Sql
                    Cmd.ExecuteNonQuery()
                End If
            Next
            Lock_Control(False)
            booThem = False
            'MsgBox("Đã lưu thông tin thanh toán vào CSDL.", MsgBoxStyle.Critical, "Message!")
            Fill_PanIn(SoBL)
            panIn.Visible = True
            Tran.Commit()
        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fill_PanIn(ByVal SoBL As String)
        Dim i
        lblTen_IN.Text = txtTenbenhnhan.Text
        'lblDiachi_IN.Text = txtDiachi.Text
        lblLydo_In.Text = "Chi phí DVYT"
        If Lang = "my" Then
            lblLydo_In.Text = "ဆေးစစ်စရိတ်"
        ElseIf Lang = "en" Then
            lblLydo_In.Text = "Medical service costs"
        End If
        txtNoidungIn.Text = ""
        txtSolien.Value = 2
        txtNoidung.Text = ""
        txtTien.Text = ""
        Dim Dem = 0
        For i = 1 To grdThanhtoan.Rows.Count - 1
            If grdThanhtoan.Item(i, 2) = "" Then
                Dem = Dem + 1
                txtNoidungIn.Text = txtNoidungIn.Text + "   " + Dem.ToString.Trim + ".       " + grdThanhtoan.Item(i, 3).ToString + ":  " + grdThanhtoan.Item(i, "THANHTIEN").ToString + " đ. " + vbCrLf
                txtNoidung.Text = txtNoidung.Text + "   " + Dem.ToString.Trim + ".       " + grdThanhtoan.Item(i, 3).ToString + vbCrLf
                txtTien.Text = txtTien.Text + Format(Val(grdThanhtoan.Item(i, "THANHTIEN").ToString), "### ### ###") + " đ " + vbCrLf
                txtSolien.Value = txtSolien.Value + 1
            End If
        Next
        If txtNoidungIn.Text.Trim() <> "" Then
            txtNoidungIn.Text = txtNoidungIn.Text.Substring(0, txtNoidungIn.Text.Length - 2) ' + "."
            txtNoidung.Text = txtNoidung.Text.Substring(0, txtNoidung.Text.Length - 2)
            txtTien.Text = txtTien.Text.Substring(0, txtTien.Text.Length - 2)
        End If
        txtTongtienIN.Text = Format(lblTienphaitra.Value, "### ### ###") + " đ"
        lblBangchu_IN.Text = ReadMoney(lblTienphaitra.Value.ToString.Trim) + " đồng"
        lblSoBienlai.Text = SoBL
        txtSolien.Value = 2 'If txtSolien.Value = 0 Then txtSolien.Value = 2
    End Sub
    'Function InChitiet_tien(ByVal noidung As String, ByVal tien As String) As String
    '    Dim i = 0
    '    InChitiet_tien = ""
    '    Do While noidung.Length < 82
    '        noidung = noidung + " "
    '    Loop
    '    Do While tien.Length < 13
    '        tien = " " + tien
    '    Loop
    '    InChitiet_tien = noidung + tien
    'End Function
    Private Function KiemtraHople() As Boolean
        KiemtraHople = False
        If txtTenbenhnhan.Text.Trim() = "" Then
            MsgBox("The payer name has not been entered.", MsgBoxStyle.Critical, "Message!")
            txtBenhnhanNop.Focus()
            Exit Function
        End If
        If grdThanhtoan.Rows.Count < 2 Then
            MsgBox("There is no service for payment yet.", MsgBoxStyle.Critical, "Message!")
            Exit Function
        End If
        If lblTienphaitra.Value <= 0 Then
            If MsgBox("Total amount < 0. Do you want to continue??", MsgBoxStyle.YesNo, "Message!") = MsgBoxResult.No Then Exit Function
        End If
        KiemtraHople = True
    End Function

    Private Sub cmdIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIn.Click
        'Dim i
        'Dim rptPT As New rptPhieuthu
        'Dim ThoigianIn As Date
        'Try
        '    ThoigianIn = GetSrvDate()
        '    rptPT.txtTenbenhnhan.Text = UCase(txtTenbenhnhan.Text)
        '    rptPT.Label25.Visible = True
        '    rptPT.Label25.Text = cmbPhongkham.Text
        '    rptPT.TextBox1.Text = TenABC(txtTenbenhnhan.Text)
        '    rptPT.txtDiachi_rpt.Text = lblDiachi_IN.Text
        '    rptPT.txtLydo_rpt.Text = lblLydo_In.Text
        '    'rptPT.txtYeucaukham.Text = txtNoidungIn.Text
        '    rptPT.txtYeucaukham.Text = txtNoidung.Text
        '    rptPT.TextBox2.Text = txtTien.Text
        '    rptPT.txtSotien_So.Text = txtTongtienIN.Text
        '    rptPT.txtSotien_Chu.Text = lblBangchu_IN.Text
        '    rptPT.txtNgaythang_rpt.Text = String.Format("{0:HH:mm} ,ngày {0:dd/MM/yyyy}", ThoigianIn)
        '    rptPT.txtNgaythang_rpt2.Text = String.Format("{0:HH:mm} ,ngày {0:dd/MM/yyyy}", ThoigianIn)
        '    rptPT.txtNguoilapphieu.Text = Tendaydu
        '    rptPT.lblSobienlai.Text = "Số: " + lblSoBienlai.Text
        '    rptPT.Run(True)
        '    If chkXemBienlai.Checked Then
        '        rptPT.Show()
        '    Else
        '        For i = 1 To Val(txtSolien.Value)
        '            rptPT.Document.Print(False, False, False)
        '        Next
        '    End If
        '    'rptPT.Document.Printer.PrinterSettings.Copies = txtSolien.Value
        '    panIn.Visible = False
        '    cmdThem.Focus()
        '    SendKeys.Send("ESC")
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
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
            & " where Sobienlai = '" & lblSoBienlai.Text.Trim & "' order by d.NhomVP, d.Madichvu"
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
            If chkXemBienlai.Checked Then
                rpt_InA5.Show()
            Else
                For i = 1 To Val(txtSolien.Value)
                    rpt_InA5.Document.Print(False, False, False)
                Next
            End If
            panIn.Visible = False
            cmdThem.Focus()
            'SendKeys.Send("ESC")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdDongIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDongIn.Click
        panIn.Visible = False
        cmdThem.Focus()
    End Sub

    Private Sub grdDichvu_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDichvu.DoubleClick
        Kichchon()
    End Sub
    Private Sub Kichchon()
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim dsKhoa As DataSet
        Dim i

        If Not booThem Then Exit Sub
        If grdDichvu.Rows.Count < 2 Then Exit Sub
        i = grdDichvu.Row
        If i < 1 Then Exit Sub
        Them_Dichvu(grdDichvu.Item(i, 0), grdDichvu.Item(i, 1), grdDichvu.Item(i, 2), grdDichvu.Item(i, 3), grdDichvu.Item(i, 4), grdDichvu.Item(i, 5), grdDichvu.Item(i, 6), "K", grdDichvu.Item(i, 7))

        'SQL = "select makhoa from DMDICHVU_KHOA where madichvu = '" & grdDichvu.Item(i, 2) & "'"
        'Cmd = New SqlCommand(SQL, Cn)
        'Adap = New SqlDataAdapter
        'Adap.SelectCommand = Cmd
        'dsKhoa = New DataSet
        'Adap.Fill(dsKhoa, "DSKHOA")
        'If dsKhoa.Tables("DSKHOA").Rows.Count = 1 Then ' Có 1 và chỉ 1 khoa thực hiện


        'Else

        'End If
    End Sub
    Private Sub txtDichvu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDichvu.KeyUp
        Try
            If e.KeyCode = Keys.Down And txtDichvu.Text <> "" Then
                grdDichvu.Focus()
                grdDichvu.Row = 1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtDichvu_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDichvu.TextChanged
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Dim DK_LoaiDV
        Try

            DK_LoaiDV = IIf(cmbLoaidichvu.SelectedValue Is Nothing, "", "and LoaiDichvu =  " & cmbLoaidichvu.SelectedValue & " ")
            SQL = "Select a.*, b.Manhom, b.Tentat as Tennhom_tat from vDMDICHVU a" _
            & " INNER join DMLoaiDichVu b on a.LoaiDichVu = b.MaLoaiDichVu" _
            & " where TenDichvu like N'%" & Replace(txtDichvu.Text.Trim(), "'", "''") & "%' and  Doituong like '%4%' and Khongsudung = 0   " + DK_LoaiDV 'and (a.noitru_ngoaitru = 2 or a.noitru_ngoaitru = 3) 
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            grdDichvu.Rows.Count = 1
            grdDichvu.Redraw = False
            If ds.Tables("Hoso").Rows.Count > 0 Then
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    grdDichvu.AddItem(ds.Tables("Hoso").Rows(i).Item("MaNhom") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenNhom_tat") _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("MaDichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenDichvu") _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & 1 _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("Dongia") _
                    & vbTab & ds.Tables("Hoso").Rows(i).Item("DuocMienGiam")) '& vbTab & ds.Tables("Hoso").Rows(i).Item("DongiaBHYT") _
                Next
                '    grdDichvu.Visible = True
                'Else
                '    grdDichvu.Visible = False
            End If
            grdDichvu.AutoSizeRows()
            grdDichvu.Redraw = True
            Cmd.Dispose()
            Adap.Dispose()
            Adap.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdDSPhieuthu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDSPhieuthu.Click
        Dim frm1 As New frmDanhsachPhieuthu
        frm1.MdiParent = FrmMain_VP
        frm1.Show()
        frm1.TopMost = True
    End Sub

    Private Sub cmdDsPhieuhuy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDsPhieuhuy.Click
        Dim frm1 As New frmDanhsachPhieuhuy
        frm1.MdiParent = FrmMain_VP
        frm1.Show()
        frm1.TopMost = True
    End Sub

    Private Sub Them_Dichvu(ByVal Manhom As Byte, ByVal Tennhom As String, ByVal Madichvu As String, ByVal Tendichvu As String, ByVal DVT As String, ByVal Soluong As Double, ByVal Dongia As Double, ByVal Makhoa As String, ByVal MienGiam As Integer)
        'Kiểm tra xem đã có tên chưa
        If Manhom.ToString.Trim() = "" Or Madichvu = "" Then Exit Sub
        If Soluong <= 0 Then
            MsgBox("Quantity is not correct", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        End If
        'Kiem tra xem trong danh sach dich vu da dung co dich vu nay chua
        If Kiemtra_Dachon(Madichvu) Then ' nếu đã có
            'If MsgBox("Dịch vụ " + Tendichvu + " đã có trong danh sách được duyệt." + vbCrLf + "Bạn có chắc chắn muốn thêm không?", MsgBoxStyle.YesNo, "Request confirmation!") = MsgBoxResult.No Then GoTo tt
            If MsgBox("Service " + Tendichvu + " is already on the approved list." + vbCrLf + " Are you sure you want to add?", MsgBoxStyle.YesNo, "Request confirmation!") = MsgBoxResult.No Then GoTo tt
        End If
        'neu chua co hoac co ma vẫn muốn thêm thì them vào danh sách
        grdThanhtoan.Redraw = False
        grdThanhtoan.Subtotal(AggregateEnum.Clear, 0, 1, 1, "{0}")
        grdThanhtoan.AddItem(Manhom & vbTab & Tennhom _
         & vbTab & Madichvu & vbTab & Tendichvu.Trim() _
         & vbTab & DVT.Trim() & vbTab & Soluong _
         & vbTab & Dongia & vbTab & vbTab & Soluong * Dongia & vbTab & MienGiam & vbTab & Makhoa)
        grdThanhtoan.Styles.Normal.WordWrap = True
        grdThanhtoan.AutoSizeRows()
        'grdThanhtoan.AllowSorting = AllowSortingEnum.SingleColumn
        'grdThanhtoan.Cols(1).Sort = SortFlags.Ascending
        grdThanhtoan.Sort(SortFlags.Ascending, 1)
        lblTienphaitra.Value = TongtienDV()
        grdThanhtoan.Subtotal(AggregateEnum.None, 0, 1, 1, "{0}")
        grdThanhtoan.Subtotal(AggregateEnum.Sum, 0, 1, 8, "{0}")
        grdThanhtoan.Redraw = True
tt:
        txtDichvu.Focus()
    End Sub

    Private Sub cmdChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim i
            If Not booThem Then Exit Sub
            If grdDichvu.Rows.Count < 2 Then Exit Sub
            i = grdDichvu.Row
        'Them_Dichvu(grdDichvu.Item(i, 0), grdDichvu.Item(i, 1), grdDichvu.Item(i, 2), grdDichvu.Item(i, 3), grdDichvu.Item(i, 4), grdDichvu.Item(i, 5), grdDichvu.Item(i, 6), cmbKhoathuchien.SelectedValue, grdDichvu.Item(i, 7))

    End Sub

    Private Sub cmdClosepanKhoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub grdDichvu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDichvu.KeyUp
        If e.KeyCode = Keys.Enter Then
            Kichchon()
        End If
    End Sub



    Private Sub txtGiamtru_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGiamtru.TextChanged
        Dim i
        Try
            If grdThanhtoan.Rows.Count < 2 Then Exit Sub
            For i = 1 To grdThanhtoan.Rows.Count - 1
                If grdThanhtoan.Item(i, 0) <> "" Then 'Nếu là mức con
                    Dim str As String = grdThanhtoan(i, "DuocMienGiam")
                    If str = 1 Then 'str.IndexOf("Khám") < 0 And str.IndexOf("Pap`mear") < 0 And str.IndexOf("Tiền sổ") < 0 Then
                        grdThanhtoan.Item(i, "MIENGIAM") = Val(txtGiamtru.Value.ToString) * Val(Replace(grdThanhtoan.Item(i, "SOLUONG"), ".", "")) * Val(Replace(grdThanhtoan.Item(i, "DONGIA"), ".", "")) / 100
                        grdThanhtoan.Item(i, "THANHTIEN") = Val(Replace(grdThanhtoan.Item(i, "SOLUONG"), ".", "")) * Val(Replace(grdThanhtoan.Item(i, "DONGIA"), ".", "")) - grdThanhtoan.Item(i, "MIENGIAM")
                    End If
                End If
            Next
            grdThanhtoan.Subtotal(AggregateEnum.Sum, 0, 1, 8, "{0}")
            lblTienphaitra.Value = TongtienDV()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtBenhnhanNop_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBenhnhanNop.TextChanged
        lblTienthua.Value = txtBenhnhanNop.Value - lblTienphaitra.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdDichvu, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdThanhtoan, "vi", Cn)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class