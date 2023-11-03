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
Public Class frmDanhsachPhieuthu
    Private Truc_Taichinh As Byte = 0
    Private Sub SetPos_Start()
        Dim i
        With grdDSPhieuthu
            '.Cols.Count = 0
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .Item(0, 0) = "Người thu"
            .Cols(0).Name = "NguoiThu"
            .Item(0, 1) = "TT"
            .Cols(1).Name = "ThuTu"
            .Item(0, 2) = "Số biên lai"
            .Cols(2).Name = "SoBienLai"
            .Item(0, 3) = "Người nộp"
            .Cols(3).Name = "NguoiNop"
            .Item(0, 4) = "Số tiền"
            .Cols(4).Name = "SoTien"
            .Item(0, 5) = "Thời gian thu"
            .Cols(5).Name = "ThoiGianThu"
            .Item(0, 6) = "Lý do"
            .Cols(6).Name = "LyDo"
            .Item(0, 7) = "Nội dung"
            .Cols(7).Name = "NoiDung"
            .Item(0, 8) = "Địa chỉ"
            .Cols(8).Name = "DiaChi"
            .Item(0, 9) = "Mã số"
            .Cols(9).Name = "MaSo"
            For i = 0 To .Cols.Count - 1
                .Cols(i).Visible = True
            Next
            .Cols(0).Visible = False
            .Cols(6).Visible = False
            Dim cs0 As CellStyle = .Styles.Add("Số tiền")
            cs0.ForeColor = Color.Green
            cs0.Font = New Font(.Font, FontStyle.Bold)
            cs0.Format = "### ### ###"
            .Cols.Frozen = 3
            .Tree.Column = 2
        End With
        With grdChitiet
            .Tree.Column = 3
            Dim cs0 As CellStyle = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            cs0.ForeColor = Color.Blue
            'cs0.BackColor = Color.White
            cs0.Font = New Font(.Font, FontStyle.Bold)
        End With
        txtTungay.Value = GetSrvDate()
        txtDenngay.Value = GetSrvDate()
    End Sub
    Private Sub frmDanhsachPhieuthu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPos_Start()
        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdDSPhieuthu, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdChitiet, Lang)
        Truc_Taichinh = 0
    End Sub
    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub
    Private Sub FillDSPhieuthu()
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Dim temp As String = ""
        Try
            With grdDSPhieuthu
                If txtMaKhambenh.Text.Trim.Length = 10 Then temp = " and Nguoinop_maso = '" & txtMaKhambenh.Text.Trim & "'"
                SQL = "Select * from tblPHIEUTHANHTOAN " _
                & " left outer join SYSUSER on tblPHIEUTHANHTOAN.Nhanvienthanhtoan = SYSUSER.UName " _
                & " where Thoigianthanhtoan between  '" & Format(txtTungay.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDenngay.Value, "MM/dd/yyyy HH:mm") & "' " _
                & " and Nguoinop_hoten like N'%" & txtTenbenhnhan.Text.Trim & "%' " & temp & " and (PhieuHuy <> 1 or Phieuhuy is null) order by Nhanvienthanhtoan"
                Cmd = New SqlCommand(SQL, Cn)
                Adap = New SqlDataAdapter
                Adap.SelectCommand = Cmd
                ds = New DataSet
                Adap.Fill(ds, "Hoso")
                .Rows.Count = 1
                .Redraw = False
                If ds.Tables("Hoso").Rows.Count > 0 Then
                    For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                        .AddItem(ds.Tables("Hoso").Rows(i).Item("UName") & vbTab & .Rows.Count _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Sobienlai") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Hoten") _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Sotien") & vbTab & String.Format("{0: HH:mm, dd/MM/yyyy}", ds.Tables("Hoso").Rows(i).Item("Thoigianthanhtoan")) _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Lydonop") & vbTab & ds.Tables("Hoso").Rows(i).Item("Diengiai") _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Diachi") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Maso").ToString)
                    Next
                    lbl_count.Text = (grdDSPhieuthu.Rows.Count - 1).ToString.Trim() + ""
                    'Dim rg As CellRange = .GetCellRange(1, 4, .Rows.Count - 1, 4)
                    'rg.Style = .Styles("Số tiền")
                End If
                .Subtotal(AggregateEnum.Sum, 0, -1, 4, "Total: ")
                .Subtotal(AggregateEnum.Sum, 1, 0, 4, "{0}")
                .Redraw = True
                .AutoSizeCols()
                .AutoSizeRows()

                Cmd.Dispose()
                Adap.Dispose()
                Adap.Dispose()
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDSPhieuthu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDSPhieuthu.KeyUp
        If e.KeyCode = Keys.Delete And grdDSPhieuthu.Row > 0 Then
            If MsgBox("Are you sure you want to cancel this receipt?", MsgBoxStyle.YesNo, "Request confirmation!") = MsgBoxResult.No Then Exit Sub
            Fill_PanIn(grdDSPhieuthu.Row)
            panIn.Visible = True
        End If
    End Sub


    'Private Sub cmdHuy_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Lock_Control(False)
    '    SetEmpty()
    '    cmdThuchien.Focus()
    '    booThem = False
    'End Sub


    Private Sub Fill_PanIn(ByVal row As Int16)
        lblSoBienlai.Text = grdDSPhieuthu.Item(row, 2)
        lblTen_IN.Text = grdDSPhieuthu.Item(row, 3)
        lblDiachi_IN.Text = grdDSPhieuthu.Item(row, 9)
        lblLydonoptien.Text = grdDSPhieuthu.Item(row, 6)
        txtNoidungIn.Text = grdDSPhieuthu.Item(row, 7)
        txtTongtienIN.Text = Format(Val(grdDSPhieuthu.Item(row, 4)), "### ### ###") + " đ"
        lblBangchu_IN.Text = ReadMoney(Val(grdDSPhieuthu.Item(row, 4)).ToString) + " đồng"
        txtLydoHuyphieu.Text = ""
    End Sub

    Private Sub cmdHuyphieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHuyphieu.Click
        'Dim rptPT As New rptPhieuthu
        Dim ThoigianHuy As Date
        Dim Tran As SqlTransaction
        Dim Sql As String
        Dim cmd As SqlCommand
        Tran = Nothing
        Try
            If txtLydoHuyphieu.Text.Trim() = "" Then
                MsgBox("Must enter reason for cancellation.", MsgBoxStyle.Critical, "Message!")
                Exit Sub
            End If
            ThoigianHuy = GetSrvDate()
            ' Cập nhật bảng Thanhtoan là phiếu đã hủy
            Tran = Cn.BeginTransaction()
            Sql = "Update tblPHIEUTHANHTOAN set Phieuhuy = 1 , Nhanvienhuyphieu = '" & TenDangNhap & "', " _
            & " Thoigianhuyphieu = '" & Format(ThoigianHuy, "MM/dd/yyyy HH:mm") & "', " _
            & " Lydohuyphieu = N'" & Replace(txtLydoHuyphieu.Text.Trim(), "'", "''") & "', " _
            & " Truc =  " & Truc_Taichinh & "  " _
            & " where Sobienlai = '" & lblSoBienlai.Text & "'"
            cmd = New SqlCommand(Sql, Cn)
            cmd.Transaction = Tran
            cmd.ExecuteNonQuery()
            Tran.Commit()
            FillDSPhieuthu()
            lblChitietBL.Text = ""
            grdChitiet.Rows.Count = 1
            panIn.Visible = False
            If MsgBox("The ticket has been canceled." + vbCrLf + "Do you want to edit the content in the new ticket?", MsgBoxStyle.YesNo, "Message!") = MsgBoxResult.Yes Then
                Suaphieu(lblSoBienlai.Text)
                Me.Dispose()
            End If

        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub cmdThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThuchien.Click
        lblChitietBL.Text = ""
        'lblDanhsachPhieuthu.Text = "   Danh sách các phiếu thu"
        grdDSPhieuthu.Rows.Count = 1
        grdChitiet.Rows.Count = 1
        If txtTungay.ValueIsDbNull Or txtDenngay.ValueIsDbNull Then
            MsgBox("A time period must be selected.", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        End If
        FillDSPhieuthu()
    End Sub
    Private Function TongtienDV() As Double
        ' Hàm trả về tổng số tiền của các biên lai đã thanh toán 
        Dim i
        Try
            TongtienDV = 0
            If grdDSPhieuthu.Rows.Count < 2 Then Exit Function
            For i = 1 To grdDSPhieuthu.Rows.Count - 1
                TongtienDV = TongtienDV + Val(Replace(grdDSPhieuthu.Item(i, 4), ".", ""))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub grdDSPhieuthu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDSPhieuthu.Click
        If grdDSPhieuthu.Row < 1 Then Exit Sub 'Or grdDSPhieuthu.Item(grdDSPhieuthu.Row, 0) = Nothing
        'lblChitietBL.Text = "  Chi tiết phiếu thu số: " + grdDSPhieuthu.Item(grdDSPhieuthu.Row, 2) + ". Người thu: " + grdDSPhieuthu.Item(grdDSPhieuthu.Row, 0) + ". Thời gian: " + grdDSPhieuthu.Item(grdDSPhieuthu.Row, 5)
        FillChitietPhieuthu(grdDSPhieuthu.Item(grdDSPhieuthu.Row, 2))
    End Sub
    Private Sub FillChitietPhieuthu(ByVal SoBL As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            If Trim(SoBL) = "" Then Exit Sub
            With grdChitiet
                .Rows.Count = 1
                SQL = "Select *,a.MaDichvu as Dichvu, c.MaLoaiDichVu as ManhomNT_DV, c.TenLoaiDichVu as Tennhom_tat  from  tblPHIEUTHANHTOAN_CT a " _
                & " inner join vDMDICHVU b on a.MaDichvu = b.MaDichvu  " _
                & " left outer join DMLoaiDichVu c on b.LoaiDichVu = c.MaLoaiDichVu " _
                & " where a.Sobienlai = '" & SoBL & "' order by b.MaDichvu"
                Cmd = New SqlCommand(SQL, Cn)
                Adap = New SqlDataAdapter
                Adap.SelectCommand = Cmd
                ds = New DataSet
                Adap.Fill(ds, "Hoso")
                If ds.Tables("Hoso").Rows.Count > 0 Then
                    Dim temp As String = ""
                    For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                        temp = ds.Tables("Hoso").Rows(i).Item("ManhomNT_DV") & vbTab & ds.Tables("Hoso").Rows(i).Item("Tennhom_tat")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("Dichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenDichvu")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("Dongia")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("Miengiam")
                        temp = temp & vbTab & ds.Tables("Hoso").Rows(i).Item("Dongia") * ds.Tables("Hoso").Rows(i).Item("Soluong") - ds.Tables("Hoso").Rows(i).Item("Miengiam")
                        .AddItem(temp)
                    Next
                End If
                '.AutoSizeCols()
                '.ExtendLastCol = True
                .Subtotal(AggregateEnum.Sum, 0, 1, 8, "{0}")

                '.Cols(9).Format() = "###,###"

            End With
            Cmd.Dispose()
            Adap.Dispose()
            Adap.Dispose()
            ds = New DataSet
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdDongIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDongIn.Click
        panIn.Visible = False
    End Sub

    Private Sub cmdXuatExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXuatExcel.Click
        Dim Thoigian As String
        Try
            If txtTungay.ValueIsDbNull Or txtDenngay.ValueIsDbNull Or grdDSPhieuthu.Rows.Count < 2 Then Exit Sub
            Thoigian = Format(txtTungay.Value, "yyyyMMddHHmm") + " _ " + Format(txtDenngay.Value, "yyyyMMddHHmm")
            If Not System.IO.Directory.Exists("D:\\PhieuThu") Then
                System.IO.Directory.CreateDirectory("D:\\PhieuThu")
            End If
            grdDSPhieuthu.SaveExcel("D:\PhieuThu\Danhsachphieuthu_" + Format(DateTime.Now, "yyyyMMddHHmm") + ".xls", Thoigian, FileFlags.IncludeFixedCells)
            MsgBox("Exported to file D:\PhieuThu\Danhsachphieuthu_" + Format(DateTime.Now, "yyyyMMddHHmm") + ".xls" + ", tại Sheet: " + Thoigian, MsgBoxStyle.Information, "Message!")
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub grdChitiet_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdChitiet.KeyUp
        If e.KeyCode = Keys.F10 And grdChitiet.Rows.Count > 1 And grdDSPhieuthu.Row > 0 Then
            Fill_PanIn_lai(grdDSPhieuthu.Item(grdDSPhieuthu.Row, 2).ToString.Trim())
            panIn_lai.Visible = True
        End If
    End Sub
    Private Sub Fill_PanIn_lai(ByVal SoBL As String)
        Dim i
        lblTen_IN_lai.Text = grdDSPhieuthu.Item(grdDSPhieuthu.Row, 3)
        'lblDiachi_IN.Text = txtDiachi.Text
        'lblLydo_In_lai.Text = "Chi phí DVYT"
        lblDiachi_IN_lai.Text = grdDSPhieuthu.Item(grdDSPhieuthu.Row, 8).ToString.Trim()
        txtNoidungIn_lai.Text = ""
        txtSolien_lai.Value = 2
        txtNoidung_lai.Text = ""
        txtTien_lai.Text = ""
        Dim Dem = 0
        For i = 1 To grdChitiet.Rows.Count - 1
            If grdChitiet.Item(i, 2) = "" Then
                Dem = Dem + 1
                txtNoidungIn_lai.Text = txtNoidungIn_lai.Text + "   " + Dem.ToString.Trim + ".       " + grdChitiet.Item(i, 3).ToString + ":  " + grdChitiet.Item(i, 8).ToString + " đ. " + vbCrLf
                txtNoidung_lai.Text = txtNoidung_lai.Text + "   " + Dem.ToString.Trim + ".       " + grdChitiet.Item(i, 3).ToString + vbCrLf
                txtTien_lai.Text = txtTien_lai.Text + Format(Val(grdChitiet.Item(i, 8).ToString), "### ### ###") + " đ " + vbCrLf
                txtSolien_lai.Value = txtSolien_lai.Value + 1
            End If
        Next
        If txtNoidungIn_lai.Text.Trim() <> "" Then
            txtNoidungIn_lai.Text = txtNoidungIn_lai.Text.Substring(0, txtNoidungIn_lai.Text.Length - 2) ' + "."
            txtNoidung_lai.Text = txtNoidung_lai.Text.Substring(0, txtNoidung_lai.Text.Length - 2)
            txtTien_lai.Text = txtTien_lai.Text.Substring(0, txtTien_lai.Text.Length - 2)
        End If
        txtTongtienIN_lai.Text = Format(Val(grdDSPhieuthu.Item(grdDSPhieuthu.Row, 4).ToString.Trim()), "### ### ###") + " đ"
        lblBangchu_IN_lai.Text = ReadMoney(grdDSPhieuthu.Item(grdDSPhieuthu.Row, 4).ToString.Trim()) + " đồng"
        lblSoBienlai_lai.Text = SoBL
        txtSolien_lai.Value = 1   'If txtSolien_lai.Value = 0 Then txtSolien_lai.Value = 2
    End Sub

    Private Sub cmdIn_lai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIn_lai.Click
        ''Dim i
        ''Dim rptPT As New rptPhieuthu
        ''Dim ThoigianIn As Date
        ''Try
        ''    ThoigianIn = GetSrvDate()
        ''    rptPT.txtTenbenhnhan.Text = UCase(lblTen_IN_lai.Text)
        ''    rptPT.TextBox1.Text = TenABC(lblTen_IN_lai.Text)
        ''    rptPT.txtDiachi_rpt.Text = lblDiachi_IN_lai.Text
        ''    rptPT.txtLydo_rpt.Text = lblLydo_In_lai.Text
        ''    'rptPT.txtYeucaukham.Text = txtNoidungIn.Text
        ''    rptPT.txtYeucaukham.Text = txtNoidung_lai.Text
        ''    rptPT.TextBox2.Text = txtTien_lai.Text
        ''    rptPT.txtSotien_So.Text = txtTongtienIN_lai.Text
        ''    rptPT.txtSotien_Chu.Text = lblBangchu_IN_lai.Text
        ''    rptPT.txtNgaythang_rpt.Text = String.Format("{0:HH:mm} ,ngày {0:dd/MM/yyyy}", ThoigianIn)
        ''    rptPT.txtNgaythang_rpt2.Text = String.Format("{0:HH:mm} ,ngày {0:dd/MM/yyyy}", ThoigianIn)
        ''    rptPT.txtNguoilapphieu.Text = Tendaydu
        ''    rptPT.lblSobienlai.Text = "Số: " + lblSoBienlai_lai.Text
        ''    rptPT.Run(True)
        ''    If chkXemBienlai.Checked Then
        ''        rptPT.Show()
        ''    Else
        ''        For i = 1 To Val(txtSolien_lai.Value)
        ''            rptPT.Document.Print(False, False, False)
        ''        Next
        ''    End If
        ''    'rptPT.Document.Printer.PrinterSettings.Copies = txtSolien.Value
        ''    panIn_lai.Visible = False
        ''Catch ex As Exception
        ''    MsgBox(ex.Message)
        ''End Try
        'Dim i
        'Dim rptPT_InNhiet As New rptPhieuthu_InNhiet
        'Dim ThoigianIn As Date
        'Try
        '    ThoigianIn = GetSrvDate()
        '    rptPT_InNhiet.SqlStr = "select c.Tenbenhnhan, (N'NS: ' + cast (c.Namsinh as nvarchar)) as Namsinh, b.Diachi," _
        '    & " (N'Số: ' + a.Sobienlai) as Sobienlai,d.tendichvu,a.Miengiam,(a.Soluong*a.Dongia) as Thanhtien from viewPHIEUTHANHTOAN_CT a " _
        '    & " left join tblKhambenh b on a.Makhambenh = b.Makhambenh " _
        '    & " left join tblBenhnhan c on b.Mabenhnhan = c.Mabenhnhan " _
        '    & " left join vDMDICHVU d on a.Madichvu = d.Madichvu  " _
        '    & " where Sobienlai = '" & lblSoBienlai_lai.Text.Trim & "' order by d.NhomVP, d.Madichvu"
        '    rptPT_InNhiet.txtNgaythang.Text = String.Format("{0:HH:mm}, ngày {0:dd/MM/yyyy}", ThoigianIn)
        '    rptPT_InNhiet.Run(True)
        '    If chkXemBienlai.Checked Then
        '        rptPT_InNhiet.Show()
        '    Else
        '        For i = 1 To Val(txtSolien_lai.Value)
        '            rptPT_InNhiet.Document.Print(False, False, False)
        '        Next
        '    End If
        '    panIn.Visible = False
        '    'SendKeys.Send("ESC")
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
            & " where Sobienlai = '" & lblSoBienlai_lai.Text.Trim & "' order by d.NhomVP, d.Madichvu"
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

    Private Sub cmdDongIn_lai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDongIn_lai.Click
        panIn_lai.Visible = False
    End Sub
    Private Sub Suaphieu(ByVal SoBL As String)
        'Thủ tục fill Các mục chung và chi tiết của 1 biên lai vào frmVienphi_Ngoaitru
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            If Trim(SoBL) = "" Then Exit Sub
            Dim frm As New frmThuPhiDichVu
            Dim Sender, e
            frm.SetPos_Start()
            frm.cmdThem_Click(Sender, e)
            ' Fill Hành chính
            SQL = "Select *  from  tblPHIEUTHANHTOAN a where a.Sobienlai = '" & SoBL & "' "
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then
                frm.txtMaKhambenh.Text = ds.Tables("Hoso").Rows(i).Item("Nguoinop_Maso").ToString
                frm.txtTenbenhnhan.Text = ds.Tables("Hoso").Rows(i).Item("Nguoinop_Hoten").ToString
            End If
            ' Fill Các dịch vụ
            With frm.grdThanhtoan
                .Redraw = False
                .Rows.Count = 1
                .Subtotal(AggregateEnum.Clear, 0, 1, 1, "{0}")
                SQL = "Select  a.MaDichvu as Dichvu, Tendichvu, DVT,Soluong, a.Dongia,a.Miengiam, a.Makhoa, c.MaLoaiDichVu as ManhomNT_DV, c.TenLoaiDichVu as Tennhom_tat,b.DuocMienGiam   from  tblPHIEUTHANHTOAN_CT a " _
                & " left outer join vDMDICHVU b on a.MaDichvu = b.MaDichvu  " _
                & " left outer join DMLoaiDichVu c on b.LoaiDichVu = c.MaLoaiDichVu " _
                & " where a.Sobienlai = '" & SoBL & "' order by b.MaDichvu"
                Cmd = New SqlCommand(SQL, Cn)
                Adap = New SqlDataAdapter
                Adap.SelectCommand = Cmd
                ds = New DataSet
                Adap.Fill(ds, "Hoso")
                If ds.Tables("Hoso").Rows.Count > 0 Then
                    For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                        .AddItem(ds.Tables("Hoso").Rows(i).Item("ManhomNT_DV") & vbTab & ds.Tables("Hoso").Rows(i).Item("Tennhom_tat") _
                         & vbTab & ds.Tables("Hoso").Rows(i).Item("Dichvu") & vbTab & ds.Tables("Hoso").Rows(i).Item("Tendichvu") _
                         & vbTab & ds.Tables("Hoso").Rows(i).Item("DVT") & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong") _
                         & vbTab & ds.Tables("Hoso").Rows(i).Item("Dongia") _
                         & vbTab & ds.Tables("Hoso").Rows(i).Item("Miengiam") _
                         & vbTab & ds.Tables("Hoso").Rows(i).Item("Soluong") * ds.Tables("Hoso").Rows(i).Item("Dongia") - ds.Tables("Hoso").Rows(i).Item("Miengiam") _
                         & vbTab & ds.Tables("Hoso").Rows(i).Item("DuocMienGiam") _
                         & vbTab & ds.Tables("Hoso").Rows(i).Item("Makhoa"))
                    Next
                End If
                .Styles.Normal.WordWrap = True
                .AutoSizeRows()
                frm.lblTienphaitra.Value = frm.TongtienDV()
                .Subtotal(AggregateEnum.Sum, 0, 1, 8, "{0}")
                .Redraw = True
            End With
            Cmd.Dispose()
            Adap.Dispose()
            Adap.Dispose()
            ds = New DataSet
            frm.MdiParent = FrmMain_VP
            frm.TopMost = True
            'frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdBatdau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBatdau.Click
        If optHC.Checked Then
            Truc_Taichinh = 0
            panHC_Truc.Visible = False
            Exit Sub
        End If
        If optTruc.Checked Then
            Truc_Taichinh = 1
            panHC_Truc.Visible = False
            Panel1.BackColor = Color.PapayaWhip
            Exit Sub
        End If
        MsgBox("Phải chọn giờ hành chính hay giờ trực.", MsgBoxStyle.Critical, "Message!")
    End Sub
  
    Private Sub cmdInDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInDS.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdDSPhieuthu, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdChitiet, "vi", Cn)
    End Sub
End Class