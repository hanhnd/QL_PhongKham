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
Public Class frmKB_ThongkeLuotkham ' Tên cũ frmThongke_Luotkham.vb
    Private Sub SetGrid(ByVal PK As String)
        Dim i
        Try
            With grdThongkeBN
                .Rows.Count = 2
                .Cols.Count = 12
                .Rows.Fixed = 2
                .Item(0, 0) = "STT"
                .Item(1, 0) = "STT"
                .Item(0, 2) = "Tổng số"
                .Item(1, 2) = "Tổng số"
                .Item(0, 3) = "Trong đó"
                .Item(0, 4) = "Trong đó"
                .Item(0, 5) = "Trong đó"
                .Item(0, 6) = "Trong đó"
                .Item(0, 7) = "Trong đó"
                .Item(0, 8) = "Trong đó"
                .Item(0, 9) = "Trong đó"
                .Item(1, 3) = "Quân"
                .Item(1, 4) = "Chính sách"
                .Item(1, 5) = "BHQĐ"
                .Item(1, 6) = "BHQH"
                .Item(1, 7) = "BHTQ"
                .Item(1, 8) = "BH khác"
                .Item(1, 9) = "Dịch vụ"
                .Item(0, 10) = "Vào viện"
                .Item(1, 10) = "Vào viện"
                .Item(0, 11) = "Chuyển viện"
                .Item(1, 11) = "Chuyển viện"
                If PK = "" Then
                    .Item(0, 1) = "Buồng khám"
                    .Item(1, 1) = "Buồng khám"
                Else
                    .Item(0, 1) = "Ngày khám"
                    .Item(1, 1) = "Ngày khám"
                End If
                .AllowMerging = AllowMergingEnum.FixedOnly
                .Rows(0).AllowMerging = True
                .Cols(0).AllowMerging = True
                .Cols(1).AllowMerging = True
                .Cols(2).AllowMerging = True
                .Cols(10).AllowMerging = True
                .Cols(11).AllowMerging = True
                For i = 0 To .Cols.Count - 1
                    .Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
                Next
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DocDM()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet

        
        Adap1 = Nothing
        Cmd1 = Nothing
        DsDM = Nothing
    End Sub
    Private Sub frmThongke_Khambenh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DocDM()
        SetGrid("")
        txtNgaykhamTu.Value = GetSrvDate()
        txtNgaykhamDen.Value = GetSrvDate()
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub cmdThongke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThongke.Click
        Dim Tu, Den, SQL As String
        Dim Cmd As New SqlCommand
        Dim Dr As SqlDataReader
        Dim i, j
        If txtNgaykhamTu.ValueIsDbNull Or txtNgaykhamDen.ValueIsDbNull Then
            MsgBox("Chọn sai khoảng thời gian", MsgBoxStyle.Critical, "Message")
            Exit Sub
        End If
        If txtNgaykhamTu.Value > txtNgaykhamDen.Value Then
            MsgBox("Chọn sai khoảng thời gian", MsgBoxStyle.Critical, "Message")
            Exit Sub
        End If
        Tu = "PK" + Format(txtNgaykhamTu.Value, "yyMMdd") + "0001"
        Den = "PK" + Format(txtNgaykhamDen.Value, "yyMMdd") + "9999"
        SetGrid(cmbPhongkham.SelectedValue)
        If cmbPhongkham.SelectedValue = "" Then ' Nếu không chọn phòng khám nào
            SQL = "Select DTQUAN.Makhoa, DTQUAN.TenKhoa, Quan, CS, BHQD, BHHuu, BHTN,BHKhac, Dan,vaovien, Chuyenvien  From (" _
            & " select makhoa, tenkhoa, count(Doituong) as Quan from DMKHOAPHONG  " _
            & " left outer join ( Select tblKHambenh.Doituong,tblKhambenh_KQDVKHAM.KhoaThuchien from tblKhambenh_KQDVKHAM" _
             & " left outer join tblKHambenh on tblKhambenh_KQDVKHAM.MaKhambenh = tblKHambenh.MaKhambenh" _
            & " where MaphieuCD between  '" & Tu & "' and '" & Den & "'" _
            & " and  tblKHambenh.Doituong  = '2'  ) QUAN" _
            & " on DMKHOAPHONG.MaKHoa = QUAN.KhoaThuchien where is_Phongkham = 1 group by Doituong,Makhoa, TenKhoa ) DTQUAN" _
            & "             inner  Join " _
            & " (select makhoa, tenkhoa, count(Doituong) as CS from DMKHOAPHONG  " _
            & " left outer join ( Select tblKHambenh.Doituong,tblKhambenh_KQDVKHAM.KhoaThuchien from tblKhambenh_KQDVKHAM" _
            & "  left outer join tblKHambenh on tblKhambenh_KQDVKHAM.MaKhambenh = tblKHambenh.MaKhambenh" _
            & " where MaphieuCD between  '" & Tu & "' and '" & Den & "'" _
            & " and  tblKHambenh.Doituong  = '3'  ) CS" _
            & " on DMKHOAPHONG.MaKHoa = CS.KhoaThuchien where is_Phongkham = 1 group by Doituong,Makhoa, TenKhoa ) DTCS" _
            & " on DTQUAN.Makhoa = DTCS.Makhoa" _
            & "             inner  Join " _
            & " (select makhoa, tenkhoa, count(Doituong) as BHQD from DMKHOAPHONG  " _
            & " left outer join ( Select tblKHambenh.Doituong,tblKhambenh_KQDVKHAM.KhoaThuchien from tblKhambenh_KQDVKHAM" _
            & " left outer join tblKHambenh on tblKhambenh_KQDVKHAM.MaKhambenh = tblKHambenh.MaKhambenh" _
            & " where MaphieuCD between  '" & Tu & "' and '" & Den & "'" _
            & " and  tblKHambenh.Doituong  = '1' and  tblKHambenh.Doituongthe  = 'HC' and right(left(tblKHambenh.SotheBHYT,3),2) = '97'  ) BHQD" _
            & " on DMKHOAPHONG.MaKHoa = BHQD.KhoaThuchien where is_Phongkham = 1 group by Doituong,Makhoa, TenKhoa ) DTBHQD" _
            & " on DTQUAN.Makhoa = DTBHQD.Makhoa" _
            & "             inner  Join " _
            & " (select makhoa, tenkhoa, count(Doituong) as BHHuu from DMKHOAPHONG  " _
            & " left outer join ( Select tblKHambenh.Doituong,tblKhambenh_KQDVKHAM.KhoaThuchien from tblKhambenh_KQDVKHAM" _
            & "  left outer join tblKHambenh on tblKhambenh_KQDVKHAM.MaKhambenh = tblKHambenh.MaKhambenh" _
            & " where MaphieuCD between  '" & Tu & "' and '" & Den & "'" _
            & " and  tblKHambenh.Doituong  = '1' and  (tblKHambenh.Doituongthe  = 'HT' or tblKHambenh.Doituongthe  = 'CK') and tblKHambenh.Capbac <> '' and tblKHambenh.Capbac <> '27' ) BHHuu" _
            & " on DMKHOAPHONG.MaKHoa = BHHuu.KhoaThuchien where is_Phongkham = 1 group by Doituong,Makhoa, TenKhoa ) DTBHHuu" _
            & " on DTQUAN.Makhoa = DTBHHuu.Makhoa" _
            & "             inner  Join " _
            & " (select makhoa, tenkhoa, count(Doituong) as BHTN from DMKHOAPHONG  " _
            & " left outer join ( Select tblKHambenh.Doituong,tblKhambenh_KQDVKHAM.KhoaThuchien from tblKhambenh_KQDVKHAM" _
             & " left outer join tblKHambenh on tblKhambenh_KQDVKHAM.MaKhambenh = tblKHambenh.MaKhambenh" _
            & " where MaphieuCD between  '" & Tu & "' and '" & Den & "'" _
            & " and  tblKHambenh.Doituong  = '1' and  tblKHambenh.Doituongthe  = 'TQ'  ) BHTN" _
            & " on DMKHOAPHONG.MaKHoa = BHTN.KhoaThuchien where is_Phongkham = 1 group by Doituong,Makhoa, TenKhoa ) DTBHTN" _
            & " on DTQUAN.Makhoa = DTBHTN.Makhoa" _
            & "             inner  Join " _
            & " (select makhoa, tenkhoa, count(Doituong) as BHKhac from DMKHOAPHONG  " _
            & " left outer join ( Select tblKHambenh.Doituong,tblKhambenh_KQDVKHAM.KhoaThuchien from tblKhambenh_KQDVKHAM" _
             & " left outer join tblKHambenh on tblKhambenh_KQDVKHAM.MaKhambenh = tblKHambenh.MaKhambenh" _
            & " where MaphieuCD between  '" & Tu & "' and '" & Den & "'" _
            & " and  tblKHambenh.Doituong  = '1' and  not (tblKHambenh.Doituongthe  = 'HC' and right(left(tblKHambenh.SotheBHYT,3),2) = '97' ) and not ((tblKHambenh.Doituongthe  = 'HT' or tblKHambenh.Doituongthe  = 'CK') and tblKHambenh.Capbac <> '' and tblKHambenh.Capbac <> '27' ) and tblKHambenh.Doituongthe  <> 'TQ'  ) BHKhac" _
            & " on DMKHOAPHONG.MaKHoa = BHKhac.KhoaThuchien where is_Phongkham = 1 group by Doituong,Makhoa, TenKhoa ) DTBHKhac" _
            & " on DTQUAN.Makhoa = DTBHKhac.Makhoa" _
            & "             inner  Join " _
            & " (select makhoa, tenkhoa, count(Doituong) as Dan from DMKHOAPHONG  " _
            & " left outer join ( Select tblKHambenh.Doituong,tblKhambenh_KQDVKHAM.KhoaThuchien from tblKhambenh_KQDVKHAM" _
            & "  left outer join tblKHambenh on tblKhambenh_KQDVKHAM.MaKhambenh = tblKHambenh.MaKhambenh" _
            & " where MaphieuCD between  '" & Tu & "' and '" & Den & "'" _
            & " and  tblKHambenh.Doituong  = '4'  ) Dan" _
            & " on DMKHOAPHONG.MaKHoa = Dan.KhoaThuchien where is_Phongkham = 1 group by Doituong,Makhoa, TenKhoa ) DTDan" _
            & " on DTQUAN.Makhoa = DTDan.Makhoa" _
            & "             inner  Join " _
            & " (Select  Makhoa  , TenKhoa , Count(HuongGQ) as VaoVien from DMKHOAPHONG " _
            & " Left outer join ( Select  tblKhambenh_KQDVKHAM.KhoaThuchien, HuongGQ from tblKhambenh_KQDVKHAM " _
             & " left outer join tblKHambenh on tblKhambenh_KQDVKHAM.MaKhambenh = tblKHambenh.MaKhambenh " _
            & "             where MaphieuCD between  '" & Tu & "' and '" & Den & "' and HuongGQ =5) VaoVien " _
            & "    on DMKHOAPHONG.MaKHoa = VaoVien.KhoaThuchien where is_Phongkham = 1  " _
            & "  group by  Makhoa, TenKhoa, HuongGQ ) VV  " _
            & "  on DTQUAN.MaKhoa = VV.MaKhoa  " _
            & "             inner  Join " _
            & " (Select  Makhoa  , TenKhoa , Count(HuongGQ) as ChuyenVien from DMKHOAPHONG " _
            & " Left outer join ( Select  tblKhambenh_KQDVKHAM.KhoaThuchien, HuongGQ from tblKhambenh_KQDVKHAM " _
             & " left outer join tblKHambenh on tblKhambenh_KQDVKHAM.MaKhambenh = tblKHambenh.MaKhambenh " _
            & "             where MaphieuCD between  '" & Tu & "' and '" & Den & "' and HuongGQ =6) ChuyenVien " _
            & "    on DMKHOAPHONG.MaKHoa = ChuyenVien.KhoaThuchien where is_Phongkham = 1  " _
             & " group by  Makhoa, TenKhoa, HuongGQ ) CV  " _
             & " on DTQUAN.MaKhoa = CV.MaKhoa  "

            Cmd.Connection = Cn
            Cmd.CommandTimeout = 0
            Cmd.CommandText = SQL
            Dr = Cmd.ExecuteReader
            i = 0
            Do While Dr.Read
                i = i + 1
                grdThongkeBN.AddItem(i & vbTab & Dr!TenKhoa & vbTab & Dr!Quan + Dr!CS + Dr!BHQD + Dr!BHHuu + Dr!BHTN + Dr!BHKhac + Dr!Dan & vbTab & Dr!Quan & vbTab & Dr!CS & vbTab & Dr!BHQD & vbTab & Dr!BHHuu & vbTab & Dr!BHTN & vbTab & Dr!BHKhac & vbTab & Dr!Dan & vbTab & Dr!VaoVien & vbTab & Dr!ChuyenVien)
            Loop
            grdThongkeBN.Tree.Column = 1
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 2, "Tổng cộng: ")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 3, "Tổng cộng: ")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 4, "Tổng cộng: ")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 5, "Tổng cộng: ")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 6, "Tổng cộng: ")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 7, "Tổng cộng: ")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 8, "Tổng cộng: ")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 9, "Tổng cộng: ")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 10, "Tổng cộng: ")
            grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, -1, 11, "Tổng cộng: ")
            Dr.Close()
        Else 'Nếu chọn 1 phòng khám
            'For i = 0 To DateDiff(DateInterval.Day, txtNgaykhamTu.Value, txtNgaykhamDen.Value) ' Gán các ngày
            '    grdThongkeBN.AddItem(i + 1 & vbTab & Format(DateAdd(DateInterval.Day, i, txtNgaykhamTu.Value), "dd/MM/yyyy"))
            'Next
            'For i = 2 To grdThongkeBN.Rows.Count - 1 ' Tính từng ngày
            '    SQL = "Select   BaoHiem, VienPhi, TreEm, VaoVien, ChuyenVien from" _
            '    & " ( Select  1 as MaKhoa, Count(*) as BaoHiem from tblKhambenh_KQDVKHAM " _
            '    & " Left outer join tblKhambenh on tblKhambenh.MaKhambenh = tblKhambenh_KQDVKHAM.MaKhambenh" _
            '    & " where KhoaThuchien = '" & cmbPhongkham.SelectedValue & "' and left(tblKhambenh_KQDVKHAM.MaphieuCD,8) =  'PK' + '" & Format(DateAdd(DateInterval.Day, i - 2, txtNgaykhamTu.Value), "yyMMdd") & "' " _
            '    & " and HuongGQ > 0 and left(tblKHambenh.Doituong,1) = '1'   ) BH" _
            '    & " left outer join " _
            '    & " ( Select  1 as MaKhoa,Count(*) as VienPhi from tblKhambenh_KQDVKHAM " _
            '    & " Left outer join tblKhambenh on tblKhambenh.MaKhambenh = tblKhambenh_KQDVKHAM.MaKhambenh" _
            '    & " where KhoaThuchien = '" & cmbPhongkham.SelectedValue & "' and left(tblKhambenh_KQDVKHAM.MaphieuCD,8) =  'PK' + '" & Format(DateAdd(DateInterval.Day, i - 2, txtNgaykhamTu.Value), "yyMMdd") & "' " _
            '    & " and HuongGQ > 0 and   tblKHambenh.Doituong = '2'   ) VP" _
            '    & " on BH.MaKhoa = VP.MaKhoa" _
            '    & " left outer join " _
            '    & " ( Select 1 as MaKhoa, Count(*)  as TreEm from tblKhambenh_KQDVKHAM " _
            '    & " Left outer join tblKhambenh on tblKhambenh.MaKhambenh = tblKhambenh_KQDVKHAM.MaKhambenh" _
            '    & " where KhoaThuchien = '" & cmbPhongkham.SelectedValue & "' and left(tblKhambenh_KQDVKHAM.MaphieuCD,8) =  'PK' + '" & Format(DateAdd(DateInterval.Day, i - 2, txtNgaykhamTu.Value), "yyMMdd") & "' " _
            '    & " and HuongGQ > 0 and   tblKHambenh.Doituong > '2'  ) TE" _
            '    & " on BH.MaKhoa = TE.MaKhoa" _
            '    & " left outer join " _
            '    & " ( Select 1 as MaKhoa, Count(*)  as VaoVien from tblKhambenh_KQDVKHAM " _
            '    & " Left outer join tblKhambenh on tblKhambenh.MaKhambenh = tblKhambenh_KQDVKHAM.MaKhambenh" _
            '    & " where KhoaThuchien = '" & cmbPhongkham.SelectedValue & "' and left(tblKhambenh_KQDVKHAM.MaphieuCD,8) =  'PK' + '" & Format(DateAdd(DateInterval.Day, i - 2, txtNgaykhamTu.Value), "yyMMdd") & "' " _
            '    & " and HuongGQ = 5 ) VV " _
            '    & " on BH.MaKhoa = VV.MaKhoa" _
            '    & " left outer join " _
            '    & " ( Select 1 as MaKhoa, Count(*)  as ChuyenVien from tblKhambenh_KQDVKHAM " _
            '    & " Left outer join tblKhambenh on tblKhambenh.MaKhambenh = tblKhambenh_KQDVKHAM.MaKhambenh" _
            '    & " where KhoaThuchien = '" & cmbPhongkham.SelectedValue & "' and left(tblKhambenh_KQDVKHAM.MaphieuCD,8) =  'PK' + '" & Format(DateAdd(DateInterval.Day, i - 2, txtNgaykhamTu.Value), "yyMMdd") & "' " _
            '    & " and HuongGQ = 6 ) CV" _
            '    & " on BH.MaKhoa = CV.MaKhoa"
            '    Cmd.Connection = Cn
            '    Cmd.CommandText = SQL
            '    Dr = Cmd.ExecuteReader
            '    Do While Dr.Read
            '        grdThongkeBN.Item(i, 2) = Dr!BaoHiem + Dr!VienPhi + Dr!TreEm
            '        grdThongkeBN.Item(i, 3) = Dr!BaoHiem
            '        grdThongkeBN.Item(i, 4) = Dr!VienPhi
            '        grdThongkeBN.Item(i, 5) = Dr!TreEm
            '        grdThongkeBN.Item(i, 6) = Dr!VaoVien
            '        grdThongkeBN.Item(i, 7) = Dr!ChuyenVien
            '    Loop
            '    Dr.Close()
            'Next
        End If
        For i = 2 To grdThongkeBN.Rows.Count - 1
            For j = 2 To 11
                If Trim(grdThongkeBN.Item(i, j)) = "0" Then grdThongkeBN.Item(i, j) = ""
            Next
        Next
    End Sub

    Private Sub cmdXuatExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXuatExcel.Click
        Dim Thoigian As String
        Try
            Thoigian = Format(txtNgaykhamTu.Value, "yyMMdd") + " _ " + Format(txtNgaykhamDen.Value, "yyMMdd")
            grdThongkeBN.SaveExcel("C:\ThongkeLuotkham.xls", Thoigian, FileFlags.IncludeFixedCells)
            MsgBox("Exported to file C:\ThongkeLuotkham.xls" + ", tại Sheet: " + Thoigian, MsgBoxStyle.Information, "Message!")
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class