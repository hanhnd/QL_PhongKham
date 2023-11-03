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
Public Class frmDanhsachPhieuhuy
    Private Sub SetPos_Start()
        With grdDSPhieuthu
            Dim cs0 As CellStyle = .Styles.Add("Số tiền")
            cs0.ForeColor = Color.Green
            cs0.Font = New Font(.Font, FontStyle.Bold)
            cs0.Format = "### ### ###"
            .Cols.Frozen = 3
        End With
        With grdChitiet
            .Tree.Column = 3
            Dim cs0 As CellStyle = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            cs0.ForeColor = Color.Blue
            'cs0.BackColor = Color.White
            cs0.Font = New Font(.Font, FontStyle.Bold)
        End With
    End Sub
    Private Sub frmDanhsachPhieuthu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPos_Start()
        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdDSPhieuthu, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdChitiet, Lang)
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
        Try
            With grdDSPhieuthu
                SQL = "Select * from tblPHIEUTHANHTOAN " _
                & " where Thoigianhuyphieu between  '" & Format(txtTungay.Value, "MM/dd/yyyy HH:mm") & "' and '" & Format(txtDenngay.Value, "MM/dd/yyyy HH:mm") & "'    and  PhieuHuy = 1   "
                Cmd = New SqlCommand(SQL, Cn)
                Adap = New SqlDataAdapter
                Adap.SelectCommand = Cmd
                ds = New DataSet
                Adap.Fill(ds, "Hoso")
                .Rows.Count = 1
                .Redraw = False
                If ds.Tables("Hoso").Rows.Count > 0 Then
                    For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                        .AddItem(.Rows.Count & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Maso") _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Sobienlai") & vbTab & String.Format("{0: HH:mm, dd/MM/yyyy}", ds.Tables("Hoso").Rows(i).Item("Thoigianthanhtoan")) _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Hoten") & vbTab & ds.Tables("Hoso").Rows(i).Item("Sotien") _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Lydonop") & vbTab & ds.Tables("Hoso").Rows(i).Item("Diengiai") _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Nhanvienthanhtoan") & vbTab & ds.Tables("Hoso").Rows(i).Item("Nguoinop_Diachi") _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Nhanvienhuyphieu") & vbTab & String.Format("{0: HH:mm, dd/MM/yyyy}", ds.Tables("Hoso").Rows(i).Item("Thoigianhuyphieu")) _
                        & vbTab & ds.Tables("Hoso").Rows(i).Item("Lydohuyphieu"))
                    Next
                    lbl_Count.Text = (grdDSPhieuthu.Rows.Count - 1).ToString.Trim()
                    Dim rg As CellRange = .GetCellRange(1, 5, .Rows.Count - 1, 5)
                    rg.Style = .Styles("Số tiền")
                End If
                .AutoSizeRows()
                .Redraw = True
                Cmd.Dispose()
                Adap.Dispose()
                Adap.Dispose()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmdThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThuchien.Click
        lblTongtien.Text = 0
        lblChitietBL.Text = ""
        'lblDanhsachPhieuthu.Text = "   Danh sách các phiếu thu"
        grdDSPhieuthu.Rows.Count = 1
        grdChitiet.Rows.Count = 1
        If txtTungay.ValueIsDbNull Or txtDenngay.ValueIsDbNull Then
            MsgBox("A time period must be selected.", MsgBoxStyle.Critical, "Message!")
            Exit Sub
        End If
        FillDSPhieuthu()
        lblTongtien.Text = String.Format("{0: ### ### ###}", TongtienDV())
    End Sub
    Private Function TongtienDV() As Double
        ' Hàm trả về tổng số tiền của các biên lai đã thanh toán 
        Dim i
        Try
            TongtienDV = 0
            If grdDSPhieuthu.Rows.Count < 2 Then Exit Function
            For i = 1 To grdDSPhieuthu.Rows.Count - 1
                TongtienDV = TongtienDV + Val(Replace(grdDSPhieuthu.Item(i, 5), ".", ""))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub grdDSPhieuthu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDSPhieuthu.Click
        If grdDSPhieuthu.Row < 1 Then Exit Sub
        'lblChitietBL.Text = "  Chi tiết phiếu thu số: " + grdDSPhieuthu.Item(grdDSPhieuthu.Row, 2) + ". Người hủy: " + grdDSPhieuthu.Item(grdDSPhieuthu.Row, 10) + ". Thời gian: " + grdDSPhieuthu.Item(grdDSPhieuthu.Row, 11)
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
                'SQL = "Select * from (select DMLOAIDICHVU.MaLoaidichvu ,DMLOAIDICHVU.TenLoaidichvu,MaNhom, TenNhom," & TenDatabase & ".dbo.tblKhambenh_Dichvu.MaDichvu,DMDichvu.TenDichvu," _
                '& " DMDichvu.DVT," & TenDatabase & ".dbo.tblKhambenh_Dichvu.Soluong,DMDichvu.Dongia,DMDichvu.DongiaBHYT," & TenDatabase & ".dbo.tblKhambenh_Dichvu.Daduyet,  " _
                '& " DMKhoaphong.MaKhoa,DMKhoaphong.TenKhoa, " & TenDatabase & ".dbo.tblKhambenh_Dichvu.Dathuchien  " _
                '& " from " & TenDatabase & ".dbo.tblKhambenh_Dichvu  " _
                '& " left outer join vDMDICHVU on " & TenDatabase & ".dbo.tblKhambenh_Dichvu.MaDichvu = DMDichvu.MaDichvu  " _
                '& " left outer join DMLOAIDICHVU on DMDichvu.LoaiDichvu = DMLOAIDICHVU.MaLoaidichvu   " _
                '& " left outer join DMNHOMDICHVU_BHYT on DMDichvu.NhomBHYT = DMNHOMDICHVU_BHYT.MaNhom   " _
                '& " left outer join DMKhoaphong on " & TenDatabase & ".dbo.tblKhambenh_Dichvu.Khoathuchien = DMKhoaphong.Makhoa  " _
                '& " where " & TenDatabase & ".dbo.tblKhambenh_Dichvu.Makhambenh = '" & Ma & "' and " & TenDatabase & ".dbo.tblKhambenh_Dichvu.Daduyet = 0 " _
                '& " Union all  " _
                '& " Select 'D01' as MaLoaidichvu,  N'Thuốc, hóa chất' as TenLoaidichvu,'1' as MaNhom, N'Thuốc, hóa chất' as TenloaiDichvu,DMDichvu.MaDichvu,  " _
                '& " Tenthuoc as TenDichvu,DMDichvu.DVT," & TenDatabase & ".dbo.tblKhambenh_Donthuoc.Soluong,DMDichvu.Dongia,DMDichvu.DongiaBHYT," & TenDatabase & ".dbo.tblKhambenh_Donthuoc.Daduyet,  " _
                '& " '' as MaKhoa,N'Dược' as TenKhoa," & TenDatabase & ".dbo.tblKhambenh_Donthuoc.Dathuchien  from " & TenDatabase & ".dbo.tblKhambenh_Donthuoc  " _
                '& " left outer join vDMDICHVU on DMDichvu.MaDichvu = " & TenDatabase & ".dbo.tblKhambenh_Donthuoc.MaThuoc  " _
                '& " where " & TenDatabase & ".dbo.tblKhambenh_Donthuoc.Makhambenh = '" & Ma & "'and " & TenDatabase & ".dbo.tblKhambenh_Donthuoc.ThuocMua = 0)U   " _
                '& " order by MaNhom,MaDichvu"
                SQL = "Select *,a.MaDichvu as Dichvu, c.MaLoaiDichvu as ManhomNT_DV, c.TenLoaiDichVu as Tennhom_tat  from  tblPHIEUTHANHTOAN_CT a " _
                & " inner join vDMDICHVU b on a.MaDichvu = b.MaDichvu  " _
                & " left outer join DMLoaiDichVu c on b.LoaiDichVu = c.MaLoaiDichVu " _
                & " where a.Sobienlai = '" & SoBL & "'  order by  b.MaDichvu"
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

    Private Sub cmdXuatExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXuatExcel.Click
        Dim Thoigian As String
        Try
            If txtTungay.ValueIsDbNull Or txtDenngay.ValueIsDbNull Or grdDSPhieuthu.Rows.Count < 2 Then Exit Sub
            Thoigian = Format(txtTungay.Value, "yyyyMMddHHmm") + " _ " + Format(txtDenngay.Value, "yyyyMMddHHmm")
            grdDSPhieuthu.SaveExcel("C:\DanhsachPhieuHuy.xls", Thoigian, FileFlags.IncludeFixedCells)
            MsgBox("Exported to file C:\DanhsachPhieuHuy.xls" + ", tại Sheet: " + Thoigian, MsgBoxStyle.Information, "Message!")
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdDSPhieuthu, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdChitiet, "vi", Cn)
    End Sub
End Class