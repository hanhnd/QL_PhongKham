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
Imports System
Public Class FrmKB_ThongKeThuocBacSiChiDinh ' Tên cũ FrmThongkeDichVu_BacSiChiDinh.vb
    Private Sub FrmThongkeDV_BSCD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtTuNgay.Value = GetSrvDate()
        txtDenNgay.Value = GetSrvDate()
        Dim Cmd As New SqlCommand
        Dim rd As SqlDataReader

        Cmd.Connection = Cn
        Cmd.CommandText = "SELECT distinct uname, tendu FROM SYSUSER s inner join tblkhambenh_chidinh tkc on s.Uname = tkc.NhanVienCD where tkc.MaPhieuCD LIKE 'CD%'"
        rd = Cmd.ExecuteReader
        cmbBSCD.Tag = "0"
        While (rd.Read())
            cmbBSCD.AddItem(String.Format("{0};{1}", rd("Uname"), rd("Tendu")))
        End While
        rd.Close()
        cmbBSCD.SelectedIndex = -1
        cmbBSCD.Tag = "1"
        SetPos_Start()
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub cmdXuatExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXuatExcel.Click
        Dim Thoigian As String
        Try
            If txtTuNgay.ValueIsDbNull Or txtDenNgay.ValueIsDbNull Or grdThongkeBN.Rows.Count < 2 Then Exit Sub
            Thoigian = Format(txtTuNgay.Value, "yyyyMMddHHmm") + " _ " + Format(txtDenNgay.Value, "yyyyMMddHHmm")
            Dim dlg As New SaveFileDialog
            dlg.FileName = "C:\SoluongThuoc_BSCD.xls"
            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
                grdThongkeBN.SaveExcel(dlg.FileName, Thoigian, FileFlags.IncludeFixedCells)
                MsgBox("Exported to file " + dlg.FileName + ", tại Sheet: " + Thoigian, MsgBoxStyle.Information, "Message!")
            End If
            'grdThongkeBN.SaveExcel("C:\SoluongDV_BSCD.xls", "Danh sach", FileFlags.IncludeFixedCells)
            'MsgBox("Đã lưu vào file: C:\SoluongDV_BSCD.xls")
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdThongke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThongke.Click
        Dim i As Integer = 0
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim temp As String

        If txtTuNgay.ValueIsDbNull Or txtDenNgay.ValueIsDbNull Then Exit Sub
        If cmbBSCD.SelectedText = "" Then
            temp = ""
        Else
            temp = "tc.NhanVienCD = N'" + cmbBSCD.GetItemText(cmbBSCD.Row, 0).ToString() + "' AND "
        End If

        SQl = "Select tc.nhanvienCD,s.tendu, d2.MaLoaiDichVu, d2.TenLoaiDichVu, td.MaDichVu , d.TenDichVu,d.DonGia, count(td.SoLuong) AS soluong , (d.DonGia*count(td.SoLuong)) AS thanhtien " _
                & "  from tblKhambenh_dichvu td " _
                & "inner join tblKhambenh_chidinh tc on td.MaphieuCD = tc.MaPhieuCD " _
                & "INNER JOIN vDMDICHVU d ON d.MaDichVu = td.MaDichVu " _
                & "INNER JOIN DMLOAIDICHVU d2 ON d.LoaiDichVu = d2.MaLoaiDichVu " _
                & "INNER JOIN SYSUSER s ON s.Uname = tc.NhanvienCD " _
                & "where " + temp + " td.MaPhieuCD LIKE 'DT%' AND (tc.ThoiGianCD BETWEEN  '" & Format(txtTuNgay.Value, "MM/dd/yyyy HH:mm") & "'and '" & Format(txtDenNgay.Value, "MM/dd/yyyy HH:mm") & "') " _
                & "GROUP BY tc.nhanvienCD,s.tendu,d2.MaLoaiDichVu, d2.TenLoaiDichVu, td.MaDichVu , d.TenDichVu,td.SoLuong, d.DonGia " _
                & "ORDER BY tc.nhanvienCD,d2.MaLoaiDichVu "

        Cmd = New SqlCommand(SQl, Cn)
        rd = Cmd.ExecuteReader

        grdThongkeBN.Rows.Count = 1
        grdThongkeBN.Redraw = False
        Do While rd.Read
            i = i + 1
            grdThongkeBN.AddItem(rd!tendu.ToString & vbTab & rd!TenLoaiDichVu.ToString & vbTab & "" & vbTab & rd!TenDichVu.ToString & vbTab & String.Format("{0:###,###}", Decimal.Parse(rd!Dongia.ToString)) & vbTab & rd!Soluong & vbTab & String.Format("{0:###,###}", Decimal.Parse(rd!Thanhtien)) & vbTab & "")
        Loop
        rd.Close()
        rd = Nothing

        grdThongkeBN.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.CompleteLeaf
        grdThongkeBN.Tree.Column = 3
        grdThongkeBN.Tree.Show(3)

        grdThongkeBN.Subtotal(AggregateEnum.None, 0, 0, 0, "{0:###,###}")
        grdThongkeBN.Subtotal(AggregateEnum.None, 1, 1, 1, "{0:###,###}")
        grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, 0, 6, "{0:###,###}")
        grdThongkeBN.Subtotal(AggregateEnum.Sum, 1, 1, 6, "{0:###,###}")
        'grdThongkeBN.Subtotal(AggregateEnum.Sum, 0, 0, 5, "{0:###,###}")
        'grdThongkeBN.Subtotal(AggregateEnum.Sum, 1, 1, 5, "{0:###,###}")
        Dim STT As Integer = 0

        For i = 1 To grdThongkeBN.Rows.Count - 1
            If (grdThongkeBN.GetDataDisplay(i, 0) = "") Then
                STT = 0
            Else
                STT += 1
                grdThongkeBN(i, 2) = STT
            End If
        Next
        '
        grdThongkeBN.Redraw = True
        grdThongkeBN.AutoSizeCols()

    End Sub
    Private Sub SetPos_Start()
        With grdThongkeBN
            .Rows.Count = 1
            .Cols.Count = 8
            .Cols(0).Visible = False
            .Cols(1).Visible = False
            .Rows.Fixed = 1
            .Item(0, 0) = "Bác sĩ chỉ định"
            .Item(0, 1) = "Tên loại dịch vụ"
            .Item(0, 2) = "STT"
            .Item(0, 3) = "Tên dịch vụ"
            .Item(0, 4) = "Đơn giá"
            .Item(0, 5) = "Số lượng"
            .Item(0, 6) = "Thành tiền"
            .Item(0, 7) = "Ghi chú"
        End With
    End Sub
End Class