Imports System.Data
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.Collections.Specialized

Public Class frmNhapChiDinh
    Public fg As C1.Win.C1FlexGrid.C1FlexGrid
    Public IsAddNew As Boolean
    Public NguonChiDinh As Byte '1: Chi dinh tu PPDT; 2:Chi dinh tu SoTayCD
    Public MaDoiTuongBN As String
    Private Sub frmNhapChiDinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim dr As System.Data.SqlClient.SqlDataReader
        If NguonChiDinh = 1 Then
            SQLCmd.CommandText = "Select MaLoaiDichVu, TenLoaiDichVu from DMLOAIDICHVU WHERE NoiTru_NgoaiTru>1 ODDER BY MaLoaiDichVu"
        Else
            SQLCmd.CommandText = "Select ID_SoCD as MaPP,Mota as TenPP from tblSOTAYCHIDINH WHERE UName='" + TenDangNhap + "'"
            grdDMPhuongphap_DT.Visible = False
            Label23.Top = grdDMPhuongphap_DT.Location.Y
            grdChitietND_PPDT.Location = New Point(Label23.Left, Label23.Top + Label23.Height + 2)
            grdChitietND_PPDT.Height = grdChitietND_PPDT.Height + grdDMPhuongphap_DT.Height
            Me.Text = "Sổ tay chỉ định của bác sỹ " + Tendaydu
        End If
        dr = SQLCmd.ExecuteReader()
        cmbNhomPPDT.Tag = "0"
        cmbNhomPPDT.ClearItems()
        Do While (dr.Read())
            cmbNhomPPDT.AddItem(String.Format("{0};{1}", dr("MaPP"), dr("TenPP")))
        Loop
        dr.Close()
        cmbNhomPPDT.SelectedIndex = -1
        cmbNhomPPDT.Tag = "1"
        SQLCmd.Dispose()
        grdChitietND_PPDT.Cols("MaLoaiPhieuCD").Visible = False
        grdChitietND_PPDT.Cols("MaDichVu").Visible = False
        grdChitietND_PPDT.Cols("MaLoaiDichVu").Visible = False
        grdChitietND_PPDT.Cols("TenLoaiDichVu").Visible = False
        grdChitietND_PPDT.Tree.Column = 3
        grdChitietND_PPDT.ClipSeparators = "|;"
        grdChitietND_PPDT.Rows.Count = 1
        grdChitietND_PPDT.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
        Dim cs0 As CellStyle = grdChitietND_PPDT.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
        cs0.BackColor = Color.White
        cs0.ForeColor = Color.DarkBlue
    End Sub

    Private Sub cmbNhomPPDT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNhomPPDT.TextChanged
        If cmbNhomPPDT.Tag.ToString() = "0" Or cmbNhomPPDT.SelectedIndex < 0 Then Exit Sub
        If NguonChiDinh = 1 Then
            Load_SoTayCD(GetCode(cmbNhomPPDT))
        Else
            Load_NoidungPPPDT(GetCode(cmbNhomPPDT))
        End If
    End Sub
    Private Sub Load_SoTayCD(ByVal ID_SotayCD As String)
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = String.Format("SELECT a.MaDichVu,b.TenDichVu,b.DVT,a.SoLuong,{0} As DonGia,1 As Chon,TenLoaiPhieuCD,MaLoaiPhieuCD,a.GhiChu FROM " _
                                        + " (tblSOTAYCHIDINH_CHITIET a INNER JOIN vDMDICHVU b ON a.maDichVu=b.maDichVu ) " _
                                        + " INNER JOIN DMLOAIPHIEUCHIDINH c ON a.MaLoaiPhieuCD=c.MaLoaiPhieuCD WHERE ID_SoCD={1}", IIf(MaDoiTuongBN.Substring(0, 1) = "1", "DonGiaBHYT", "DonGia"), ID_SotayCD)
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
        Do While dr.Read()

        Loop
        dr.Close()
        SQLCmd.Dispose()

    End Sub

    'Private Sub Load_PPDT()
    '    Dim SQL As String
    '    Dim cmd As SqlCommand
    '    Dim rd As SqlDataReader
    '    Dim Ma As String, Ten As String
    '    Dim MaNhomPPDT As String = GetCode(cmbNhomPPDT)
    '    Try
    '        SQL = "Select * from DMPHUONGPHAPDIEUTRI WHERE left(MaPP, 2) = '" & MaNhomPPDT & "' AND Len(MaPP)>2  order by MaPP" 'and Noitru_Ngoaitru <> 2 
    '        cmd = New SqlCommand(SQL, Cn)
    '        rd = cmd.ExecuteReader()
    '        With grdDMPhuongphap_DT
    '            .Tag = "0"
    '            .Rows.Count = 1
    '            Do While rd.Read
    '                Ma = rd!MaPP.ToString()
    '                Ten = rd!TenPP.ToString()
    '                If Len(Ma) = 2 Then
    '                    .AddItem(Ten & vbTab & Ma) '& vbTab & "1" & vbTab & False
    '                    Dim row0 As Row
    '                    row0 = .Rows(.Rows.Count - 1)
    '                    row0.IsNode = True
    '                    row0.Style = .Styles("Node")
    '                    Dim nd0 As Node
    '                    nd0 = row0.Node
    '                    nd0.Level = 0 'level
    '                Else
    '                    .AddItem(Ten & vbTab & Ma) '& vbTab & "1" & vbTab & False
    '                    Dim row1 As Row
    '                    row1 = .Rows(.Rows.Count - 1)
    '                    row1.IsNode = True
    '                    row1.Style = .Styles("Node")
    '                    Dim nd1 As Node
    '                    nd1 = row1.Node
    '                    nd1.Level = 1 'level
    '                End If
    '            Loop
    '        End With
    '        rd.Close()
    '        cmd.Dispose()
    '        grdDMPhuongphap_DT.Tag = "1"
    '        grdDMPhuongphap_DT.Row = -1
    '        If grdDMPhuongphap_DT.Rows.Count > 1 Then grdDMPhuongphap_DT.Row = 1

    '        Exit Sub
    '    Catch ex As Exception
    '        If Not rd.IsClosed() Then rd.Close()
    '    End Try
    'End Sub
    Private Sub Load_NoidungPPPDT(ByVal MaPP As String)
        Dim Sql As String
        Dim Cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim DonGia As String = "DonGia,"
        If MaDoiTuongBN.Substring(0, 1) = "1" Then DonGia = "DonGiaBHYT as DonGia,"

        With grdChitietND_PPDT

            .Redraw = False
            .Rows.Count = 1
            If NguonChiDinh = 1 Then
                Sql = "select '" + MaPP + "' As MAPP, Maloai, Tenloai, Machiphi, TenCP, DVtinh, Soluong, Tudongchon,'' As tenKhoa,'' As maKhoa,'' As GhiChu " _
                    & " from (PHUONGPHAPDT_CHIPHI INNER join ViewDMCHIPHI on PHUONGPHAPDT_CHIPHI.LoaiChiphi = ViewDMCHIPHI.LoaiCP  and PHUONGPHAPDT_CHIPHI.Machiphi = ViewDMCHIPHI.MaCP) " _
                    & " INNER join DMLoaiCHIPHI on PHUONGPHAPDT_CHIPHI.LoaiChiphi = DMLoaiCHIPHI.Maloai  " _
                    & " where PHUONGPHAPDT_CHIPHI.MaPP = '" & MaPP & " ' order by MaLoai,ThuTuChon"
            Else
                Sql = " SELECT MaLoaiDichVu,TenLoaiDichVu,a.MaDichVu,TenDichVu,DVT, Soluong," + DonGia + " 1 as Tudongchon,d.TenLoaiPhieuCD,a.MaLoaiPhieuCD ,a.GhiChu" _
                    & " from ((tblSOTAYCHIDINH_CHITIET a INNER join vDMDICHVU b ON a.MaDichVu = b.MaDichVu) " _
                    & " INNER join DMLOAIDICHVU c on b.LoaiDichVu = c.MaloaiDichVu) " _
                    & " INNER JOIN DMLOAIPHIEUCHIDINH d ON a.MaLoaiPhieuCD= d.MaLoaiPhieuCD where a.ID_SoCD = " & MaPP & " order by MaLoaiDichVu "
            End If
            Cmd = New SqlCommand(Sql, Cn)
            rd = Cmd.ExecuteReader
            Dim row As Integer = 1
            While rd.Read()
                grdChitietND_PPDT.Rows.Add()
                Dim i As Integer
                For i = 0 To rd.FieldCount - 1
                    grdChitietND_PPDT(row, i) = rd.GetValue(i)
                Next
                row = row + 1
            End While

            rd.Close()
            Cmd.Dispose()
            rd = Nothing
            .Tree.Column = .Cols("TenDichVu").Index
            .Subtotal(AggregateEnum.Sum, 0, 1, 0, "{0}")
            .AutoSizeRows(0, 0, .Rows.Count - 1, .Cols.Count - 1, 1, AutoSizeFlags.None)
            .Redraw = True
        End With
    End Sub

    Private Sub grdDMPhuongphap_DT_SelChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDMPhuongphap_DT.SelChange
        If grdDMPhuongphap_DT.Row > 0 And grdDMPhuongphap_DT.Tag.ToString() = "1" Then Load_NoidungPPPDT(grdDMPhuongphap_DT.Item(grdDMPhuongphap_DT.Row, 1))
    End Sub


    Private Sub grdChitietND_PPDT_AfterEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdChitietND_PPDT.AfterEdit
        'If (e.Col = grdChitietND_PPDT.Cols("Chon").Index) Then
        '    If grdChitietND_PPDT.GetCellCheck(e.Row, e.Col) = CheckEnum.Checked Then
        '        Dim MaCP As String = grdChitietND_PPDT.GetDataDisplay(e.Row, "MaCP")
        '        Dim LoaiCP As String = grdChitietND_PPDT.GetDataDisplay(e.Row, "LoaiCP")
        '        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("SELECT a.MaKhoa,b.TenKhoa FROM CHIPHI_KHOA a INNER JOIN DMKHOAPHONG b ON a.MaKhoa=b.MaKhoa WHERE a.LoaiCP=" + LoaiCP + " AND a.MaCP='" + MaCP + "'", HeThong.Cn)
        '        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
        '        If (dr.Read()) Then
        '            grdChitietND_PPDT(e.Row, "TenKhoa") = dr("TenKhoa").ToString()
        '            grdChitietND_PPDT(e.Row, "MaKhoa") = dr("MaKhoa").ToString()
        '        Else
        '            grdChitietND_PPDT(e.Row, "TenKhoa") = HeThong.TenKhoaphong
        '            grdChitietND_PPDT(e.Row, "MaKhoa") = HeThong.MaKhoaphong
        '        End If
        '        dr.Close()
        '        SQLCmd.Dispose()
        '    Else
        '        grdChitietND_PPDT(e.Row, "TenKhoa") = ""
        '        grdChitietND_PPDT(e.Row, "MaKhoa") = ""
        '    End If

        'End If
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdChon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChon.Click
        Dim MaCP As String
        Dim MaKhoa As String
        Dim DonGia As Integer = 0
        Dim SoLuong As Integer
        Dim DaCoCP As Boolean
        Dim i As Integer, j As Integer

        For i = 1 To grdChitietND_PPDT.Rows.Count - 1
            If (grdChitietND_PPDT.GetCellCheck(i, grdChitietND_PPDT.Cols("Chon").Index) = CheckEnum.Checked) Then
                MaCP = grdChitietND_PPDT(i, "MaDichVu")
                MaLoaiPhieuCD = grdChitietND_PPDT(i, "MaLoaiPhieuCD")
                DonGia = grdChitietND_PPDT(i, "DonGia")
                SoLuong = grdChitietND_PPDT(i, "SL")
                DaCoCP = False
                For j = 1 To fg.Rows.Count - 1
                    If (fg(j, "MaDichVu") = MaCP) Then
                        DaCoCP = True
                        Exit For
                    End If
                Next
                If Not DaCoCP Then
                    For j = fg.Rows.Count - 1 To 1 Step -1
                        If fg(j, "MaLoaiPhieuCD") = MaLoaiPhieuCD Then Exit For
                    Next
                    If j = 0 Then
                        fg.AddItem(String.Format("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|0|0|{9}", MaLoaiPhieuCD, grdChitietND_PPDT(i, "TenLoaiPhieuCD"), grdChitietND_PPDT(i, "TenLoaiDichVu"), MaCP, grdChitietND_PPDT(i, "TenDichVu"), grdChitietND_PPDT(i, "DVT"), SoLuong, DonGia, SoLuong * DonGia, grdChitietND_PPDT(i, "GhiChu")))
                    Else
                        fg.AddItem(String.Format("|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|0|0|{9}", MaLoaiPhieuCD, grdChitietND_PPDT(i, "TenLoaiPhieuCD"), grdChitietND_PPDT(i, "TenLoaiDichVu"), MaCP, grdChitietND_PPDT(i, "TenDichVu"), grdChitietND_PPDT(i, "DVT"), SoLuong, DonGia, SoLuong * DonGia, grdChitietND_PPDT(i, "GhiChu")), j + 1)
                    End If
                End If
            End If
        Next
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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = "DELETE FROM [dbo].[tblSOTAYCHIDINH] WHERE ID_SoCD = " + GetCode(cmbNhomPPDT)
        SQLCmd.ExecuteNonQuery()
        SQLCmd.Dispose()

        'Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim dr As System.Data.SqlClient.SqlDataReader
        If NguonChiDinh = 1 Then
            SQLCmd.CommandText = "Select MaLoaiDichVu, TenLoaiDichVu from DMLOAIDICHVU WHERE NoiTru_NgoaiTru>1 ODDER BY MaLoaiDichVu"
        Else
            SQLCmd.CommandText = "Select ID_SoCD as MaPP,Mota as TenPP from tblSOTAYCHIDINH WHERE UName='" + TenDangNhap + "'"
            grdDMPhuongphap_DT.Visible = False
            Label23.Top = grdDMPhuongphap_DT.Location.Y
            grdChitietND_PPDT.Location = New Point(Label23.Left, Label23.Top + Label23.Height + 2)
            grdChitietND_PPDT.Height = grdChitietND_PPDT.Height + grdDMPhuongphap_DT.Height
            Me.Text = "Sổ tay chỉ định của bác sỹ " + Tendaydu
        End If
        dr = SQLCmd.ExecuteReader()
        cmbNhomPPDT.Tag = "0"
        cmbNhomPPDT.ClearItems()
        Do While (dr.Read())
            cmbNhomPPDT.AddItem(String.Format("{0};{1}", dr("MaPP"), dr("TenPP")))
        Loop
        dr.Close()
        cmbNhomPPDT.SelectedIndex = -1
        cmbNhomPPDT.Tag = "1"
        SQLCmd.Dispose()
        grdChitietND_PPDT.Cols("MaLoaiPhieuCD").Visible = False
        grdChitietND_PPDT.Cols("MaDichVu").Visible = False
        grdChitietND_PPDT.Cols("MaLoaiDichVu").Visible = False
        grdChitietND_PPDT.Cols("TenLoaiDichVu").Visible = False
        grdChitietND_PPDT.Tree.Column = 3
        grdChitietND_PPDT.ClipSeparators = "|;"
        grdChitietND_PPDT.Rows.Count = 1
        grdChitietND_PPDT.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
        Dim cs0 As CellStyle = grdChitietND_PPDT.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
        cs0.BackColor = Color.White
        cs0.ForeColor = Color.DarkBlue
    End Sub
End Class