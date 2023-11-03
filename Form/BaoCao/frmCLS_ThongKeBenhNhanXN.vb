Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports VB6 = Microsoft.VisualBasic
Imports System.Drawing.Drawing2D
Imports C1.Win.C1FlexGrid
Imports C1.C1PrintDocument
Imports System.Data.OleDb
Imports System.Globalization
Public Class frmCLS_ThongKeBenhNhanXN ' tên cũ frmBaocaoXN_Thang.vb
    Private Sub SetPos_Start()
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim i, j
        With grdDS
            ' Set Row 0,1
            .Rows.Count = 25
            .Cols.Count = 14
            .Rows.Fixed = 1
            .Cols.Fixed = 2
            .Styles.Fixed.WordWrap = True
            .AutoSizeRows()
            For i = 0 To 1
                .Item(0, i) = "Chế độ"
                .Item(0, i + 2) = "Huyết học"
                .Item(0, i + 4) = "Sinh hóa"
                .Item(0, i + 6) = "Vi sinh"
                .Item(0, i + 8) = "Miễn dịch"
                .Item(0, i + 10) = "GPBL"
                .Item(0, i + 12) = "Tổng hợp"
            Next
            For i = 1 To 8
                .Item(i, 0) = "Nội viện"
                .Item(i + 10, 0) = "Ngoại viện"
            Next
            For i = 1 To 2
                .Item(i, 1) = "Quân+CS"
                .Item(i + 10, 1) = "Quân+CS"
                .Item(i + 2, 1) = "BHQ"
                .Item(i + 12, 1) = "BHQ"
                .Item(i + 4, 1) = "BHK"
                .Item(i + 14, 1) = "BHK"
                .Item(i + 6, 1) = "DV"
                .Item(i + 16, 1) = "DV"

                .Item(i + 8, 0) = "Cộng nội"
                .Item(i + 18, 0) = "Cộng ngoại"
                .Item(i + 20, 0) = "Tổng"
            Next
            .Item(9, 1) = "Số BN"
            .Item(10, 1) = "Số lần XN"
            .Item(19, 1) = "Số BN"
            .Item(20, 1) = "Số lần XN"
            .Item(21, 1) = "Số BN"
            .Item(22, 1) = "Số lần XN"
            .Item(23, 0) = "Tổng hợp"
            '.Item(23, 1) = "Tổng hợp"
            .Item(24, 0) = "Tổng hợp"
            '.Item(24, 1) = "Tổng hợp"
            For i = 2 To 11
                Select Case .Item(0, i)
                    Case "Huyết học"
                        If i Mod 2 = 0 Then .Cols(i).UserData = "HHSN" Else .Cols(i).UserData = "HHSL"
                    Case "Sinh hóa"
                        If i Mod 2 = 0 Then .Cols(i).UserData = "SHSN" Else .Cols(i).UserData = "SHSL"
                    Case "Vi sinh"
                        If i Mod 2 = 0 Then .Cols(i).UserData = "VSSN" Else .Cols(i).UserData = "VSSL"
                    Case "Miễn dịch"
                        If i Mod 2 = 0 Then .Cols(i).UserData = "MDSN" Else .Cols(i).UserData = "MDSL"
                    Case "GPBL"
                        If i Mod 2 = 0 Then .Cols(i).UserData = "GPSN" Else .Cols(i).UserData = "GPSL"
                End Select
            Next
            For i = 2 To 13
                For j = 1 To .Rows.Count - 1
                    .Item(j, i) = ""
                Next
            Next
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Cols(0).AllowMerging = True
            .Cols(1).AllowMerging = True
            For i = 0 To grdDS.Cols.Count - 1
                .Cols(i).Width = .Width / 14 - 1
                .Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
            Next
            .Styles.Fixed.WordWrap = True
            .SelectionMode = SelectionModeEnum.Row
            .AllowEditing = False
            .SubtotalPosition = SubtotalPositionEnum.BelowData
            Dim cs As CellStyle = .Styles.Add("Tổng")
            cs.ForeColor = Color.Green
            cs.Font = New Font(.Font, FontStyle.Bold)
            Dim rg1 As CellRange = .GetCellRange(9, 0, 10, .Cols.Count - 1)
            rg1.Style = .Styles("Tổng")
            Dim rg2 As CellRange = .GetCellRange(19, 0, 22, .Cols.Count - 1)
            rg2.Style = .Styles("Tổng")
            Dim rg3 As CellRange = .GetCellRange(0, 12, .Rows.Count - 1, 13)
            rg3.Style = .Styles("Tổng")
        End With
    End Sub

    Private Sub cmdThuchien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThuchien.Click
        Thongke_BN()
        cmdInBC.Enabled = True
    End Sub

    Private Sub Thongke_BN()
        Dim Sql As String = ""
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i, j, dem As Integer
        Dim Temp_ngay As String = ""
        Dim Ngaydau, Ngaycuoi As Date
        Dim Dong
        Dim Benhnhan_CT = 90000 / 12 '85000 / 12
        Dim XN_CT = 500000 / 12 '450000 / 12
        SetPos_Start()
        'If txtThang.Value <> 1 Then
        '    Ngaydau = CDate("25/" + (txtThang.Value - 1).ToString.Trim + "/" + Format(GetSrvDate(), "yyyy") + " 14:30:00")
        '    Ngaycuoi = CDate("25/" + txtThang.Value.ToString.Trim + "/" + Format(GetSrvDate(), "yyyy") + " 14:30:00")
        'Else
        '    Ngaydau = CDate("25/12/" + Format(GetSrvDate().Year - 1, "yyyy") + " 14:30:00")
        '    Ngaycuoi = CDate("25/1/" + Format(GetSrvDate(), "yyyy") + " 14:30:00")
        'End If
        If DatePart(DateInterval.Month, txtThang.Value) <> 1 Then
            Ngaydau = CDate("25/" + Format(DatePart(DateInterval.Month, txtThang.Value) - 1, "##") + "/" + Format(DatePart(DateInterval.Year, txtThang.Value), "####") + " 07:30:00")
            Ngaycuoi = CDate("25/" + Format(DatePart(DateInterval.Month, txtThang.Value), "##") + "/" + Format(DatePart(DateInterval.Year, txtThang.Value), "####") + " 07:29:59")
        Else
            Ngaydau = CDate("25/12/" + Format(DatePart(DateInterval.Year, txtThang.Value) - 1, "####") + " 07:30:00")
            Ngaycuoi = CDate("25/01/" + Format(DatePart(DateInterval.Year, txtThang.Value), "####") + " 07:29:59")
        End If
        'Lấy chỉ tiêu
        Sql = " select Sobenhnhan, SoXN from tblChitieu where Nam = " & DatePart(DateInterval.Year, txtThang.Value) & " and XN_CDHA = 0"
        Cmd = New SqlCommand(Sql, Cn)
        Cmd.CommandTimeout = 0
        Adap = New SqlDataAdapter
        Adap.SelectCommand = Cmd
        ds = New DataSet
        Adap.Fill(ds, "Chitieu")
        If ds.Tables("Chitieu").Rows.Count > 0 Then
            Benhnhan_CT = ds.Tables("Chitieu").Rows(0).Item("Sobenhnhan") / 12
            XN_CT = ds.Tables("Chitieu").Rows(0).Item("SoXN") / 12
        End If
        Cmd.Dispose()
        Adap.Dispose()
        ds.Dispose()
        Sql = " select BP,Doituong,(MaloaiphieuCD+'SN') as Nhom, count(*) as SN from " _
        & " (select MaphieuCD, Doituong,MaloaiphieuCD, " _
        & "    case KhoaCD when 'K' then 'PK' else 'NV' end as BP " _
        & "  from tblXN_PHIEUCD   " _
        & "  where ThoigianHT between  '" & Format(Ngaydau, "MM/dd/yyyy HH:mm:00") & "' and '" & Format(Ngaycuoi, "MM/dd/yyyy HH:mm:59") & "') a   " _
        & "  group by  Doituong,MaloaiphieuCD, BP order by BP,Doituong"
        Cmd = New SqlCommand(Sql, Cn)
        Cmd.CommandTimeout = 0
        Adap = New SqlDataAdapter
        Adap.SelectCommand = Cmd
        ds = New DataSet
        Adap.Fill(ds, "Hoso")
        With grdDS
            pbThongke.Value = 0
            .Redraw = False
            If ds.Tables("Hoso").Rows.Count > 0 Then
                pbThongke.Maximum = ds.Tables("Hoso").Rows.Count
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    Select Case ds.Tables("Hoso").Rows(i).Item("BP").ToString + ds.Tables("Hoso").Rows(i).Item("Doituong").ToString
                        Case "NV2" : Dong = 1
                        Case "NV3" : Dong = 1
                        Case "NV1" : Dong = 3
                        Case "NV11" : Dong = 3
                        Case "NV12" : Dong = 5
                        Case "NV4" : Dong = 7
                        Case "PK2" : Dong = 11
                        Case "PK3" : Dong = 11
                        Case "PK1" : Dong = 13
                        Case "PK11" : Dong = 13
                        Case "PK12" : Dong = 15
                        Case "PK4" : Dong = 17
                    End Select
                    For j = 1 To .Cols.Count - 1
                        If .Cols(j).UserData = ds.Tables("Hoso").Rows(i).Item("Nhom").ToString Then
                            .Item(Dong, j) = Val(.Item(Dong, j).ToString) + ds.Tables("Hoso").Rows(i).Item("SN")
                            Exit For
                        End If
                    Next
                    pbThongke.Value = i + 1
                Next
            End If
            Cmd.Dispose()
            Adap.Dispose()
            ds.Dispose()
            Sql = "Select BP,Doituong,(MaloaiphieuCD+'SL') as Nhom, count(*) as SL from  " _
            & " (select x.MaphieuCD, Doituong ,MaloaiphieuCD, " _
            & "  case KhoaCD when 'K' then 'PK' else 'NV' end as BP  " _
            & " from tblXN_PHIEUCD x  " _
            & " left join tblXN_Ketqua b on x.MaphieuCD = b.MaphieuCD   " _
            & " where x.ThoigianHT between '" & Format(Ngaydau, "MM/dd/yyyy HH:mm:00") & "' and '" & Format(Ngaycuoi, "MM/dd/yyyy HH:mm:59") & "') a   " _
            & " group by  Doituong,MaloaiphieuCD, BP order by BP,Doituong"
            Cmd = New SqlCommand(Sql, Cn)
            Cmd.CommandTimeout = 0
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            pbThongke.Value = 0
            If ds.Tables("Hoso").Rows.Count > 0 Then
                pbThongke.Maximum = ds.Tables("Hoso").Rows.Count
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    Select Case ds.Tables("Hoso").Rows(i).Item("BP").ToString + ds.Tables("Hoso").Rows(i).Item("Doituong").ToString
                        Case "NV2" : Dong = 2
                        Case "NV3" : Dong = 2
                        Case "NV1" : Dong = 4
                        Case "NV11" : Dong = 4
                        Case "NV12" : Dong = 6
                        Case "NV4" : Dong = 8
                        Case "PK2" : Dong = 12
                        Case "PK3" : Dong = 12
                        Case "PK1" : Dong = 14
                        Case "PK11" : Dong = 14
                        Case "PK12" : Dong = 16
                        Case "PK4" : Dong = 18
                    End Select
                    For j = 1 To .Cols.Count - 1
                        If .Cols(j).UserData = ds.Tables("Hoso").Rows(i).Item("Nhom").ToString Then
                            .Item(Dong, j) = Val(.Item(Dong, j).ToString) + ds.Tables("Hoso").Rows(i).Item("SL")
                            Exit For
                        End If
                    Next
                    pbThongke.Value = i + 1
                Next
            End If
            Tinh_Tong()
            .Redraw = True
        End With
        ds.Dispose()
        Adap.Dispose()
        Cmd.Dispose()
        For i = 2 To 13
            grdDS.Item(23, i) = "Tỷ lệ số BN / tháng = " + Math.Round(((Val(grdDS.Item(21, 12).ToString) * 100) / Benhnhan_CT), 0).ToString + "%"
            grdDS.Item(24, i) = "Tỷ lệ số XN / tháng = " + Math.Round(((Val(grdDS.Item(22, 13).ToString) * 100) / XN_CT), 0).ToString + "%"
        Next
        grdDS.AllowMerging = AllowMergingEnum.Free
        grdDS.Rows(23).AllowMerging = True
        grdDS.Rows(24).AllowMerging = True
    End Sub

    Private Sub Tinh_Tong()
        Dim i, j
        With grdDS
            'Tổng cột
            For i = 1 To .Rows.Count - 3
                For j = 2 To .Cols.Count - 3
                    If i Mod 2 = 1 And j Mod 2 = 0 Then .Item(i, 12) = Val(.Item(i, 12).ToString) + Val(.Item(i, j).ToString)
                    If i Mod 2 = 0 And j Mod 2 = 1 Then .Item(i, 13) = Val(.Item(i, 13).ToString) + Val(.Item(i, j).ToString)
                Next
            Next
            'Tổng hàng
            For j = 2 To .Cols.Count - 1
                For i = 1 To 8
                    If i Mod 2 = 1 And j Mod 2 = 0 Then .Item(9, j) = (Val(.Item(9, j).ToString) + Val(.Item(i, j).ToString)).ToString
                    If i Mod 2 = 0 And j Mod 2 = 1 Then .Item(10, j) = (Val(.Item(10, j).ToString) + Val(.Item(i, j).ToString)).ToString
                    If i Mod 2 = 1 And j Mod 2 = 0 Then .Item(19, j) = (Val(.Item(19, j).ToString) + Val(.Item(i + 10, j).ToString)).ToString
                    If i Mod 2 = 0 And j Mod 2 = 1 Then .Item(20, j) = (Val(.Item(20, j).ToString) + Val(.Item(i + 10, j).ToString)).ToString
                Next
            Next

            For j = 2 To .Cols.Count - 1
                If j Mod 2 = 0 Then .Item(21, j) = (Val(.Item(9, j).ToString) + Val(.Item(19, j).ToString)).ToString
                If j Mod 2 = 1 Then .Item(22, j) = (Val(.Item(10, j).ToString) + Val(.Item(20, j).ToString)).ToString
            Next
        End With
    End Sub

    Private Sub frmSoHH_Dongmau_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPos_Start()
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub cmdInBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInBC.Click
        ' Get the grid's PrintDocument object.
        Dim pd As Printing.PrintDocument
        pd = grdDS.PrintParameters.PrintDocument()

        ' Set up the page (landscape, 1.5" left margin).
        With pd.DefaultPageSettings
            .Margins.Top = 70
            .Margins.Bottom = 20
            .PaperSize.RawKind = 9
            .Landscape = True
            .Margins.Left = 70
            .Margins.Right = 20
        End With
        ' Set up the header and footer fonts.

        grdDS.PrintParameters.HeaderFont = New Font("Times New Roman", 12, FontStyle.Bold)
        grdDS.PrintParameters.FooterFont = New Font("Arial Narrow", 8, FontStyle.Italic)

        ' Preview the grid.
        Dim khoangtg As String = ""
        khoangtg = "Tháng: " + txtThang.Value.ToString + "/" + GetSrvDate().Year.ToString
        Dim Header_Tit As String = ""
        Header_Tit = "BÁO CÁO KHOA XÉT NGHIỆM - GPBL            " + khoangtg + vbCrLf
        grdDS.PrintGrid("Báo cáo khoa xét nghiệm", C1.Win.C1FlexGrid.PrintGridFlags.FitToPageWidth + C1.Win.C1FlexGrid.PrintGridFlags.ShowPreviewDialog + +C1.Win.C1FlexGrid.PrintGridFlags.ShowPageSetupDialog + C1.Win.C1FlexGrid.PrintGridFlags.ShowPrintDialog, Header_Tit, Chr(9) + Chr(9) + "Page {0} of {1}")
        cmdInBC.Enabled = False
    End Sub

    Private Sub cmdXuatExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXuatExcel.Click
        Dim Tenfile As String = ""
        Dim Tensheet As String = ""
        Try
            Tensheet = "Thang " + txtThang.Value.ToString + "_" + GetSrvDate().Year.ToString
            Tenfile = "C:\BaocaoXN.xls"
            grdDS.SaveExcel(Tenfile, Tensheet, FileFlags.IncludeFixedCells)
            MsgBox(String.Format("Đã lưu vào file: {0} tại sheet: {1}", Tenfile, Tensheet))
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class

 