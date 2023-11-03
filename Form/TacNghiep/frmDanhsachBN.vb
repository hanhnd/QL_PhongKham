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
Public Class frmDanhsachBN
    Dim MaPPDT_goi As String
    Dim KhamLS As String
    Public MaPhieuKham As String = ""

    Private Sub frmDanhsachBN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load_DanhsachBN()
        mdlFunction.Set_Text(Me, Lang)

    End Sub
    
    Private Sub Load_DanhsachBN()
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim i
        Dim Xutri As String
        Try 'dung.le81@gmail.com
            With fgDanhsachBN
                .Rows.Count = 1
                .Cols.Count = 8
                '.Cols(0).Visible = False
                '.Cols(1).Visible = False
                '.Cols(2).Visible = False
                .Item(0, 0) = "Mã bệnh nhân"
                .Item(0, 1) = "Mã khám bệnh"
                .Item(0, 2) = "Ngày khám"
                .Item(0, 3) = "Tên bệnh nhân"
                .Item(0, 4) = "Năm sinh"
                .Item(0, 5) = "Giới tính"
                .Item(0, 6) = "Triệu chứng"
                .Item(0, 7) = "Chẩn đoán"
                .ExtendLastCol = True
                For i = 0 To .Cols.Count - 1
                    .Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
                Next
                SQl = ""

                SQl = " select tblBenhnhan.Mabenhnhan,tblKhambenh.MaKhambenh,tblKhambenh.ThoiGianDangKy," _
                        & " tblBenhnhan.Tenbenhnhan,tblBenhnhan.Namsinh,tblBenhnhan.Gioitinh,tblKhamBenh.TrieuChung, " _
                        & " tblKhambenh.Chandoan " _
                        & " FROM tblBenhnhan inner join tblKhambenh on tblBenhNhan.Mabenhnhan = tblKhambenh.Mabenhnhan "

                If rb_TheoTen.Checked Then
                    SQl = SQl + " where Tenbenhnhan LIKE N'%" & txtTenBenhNhan.Text.Trim() & "%'"
                ElseIf rb_TheoSDT.Checked Then
                    SQl = SQl + " where  LienHe LIKE '%" + txt_SoDienThoai.Text.Trim() + "%'"
                ElseIf rb_TenVaSDT.Checked Then
                    SQl = SQl + " where Tenbenhnhan LIKE N'%" & txtTenBenhNhan.Text.Trim() & "%' AND LienHe LIKE '%" + txt_SoDienThoai.Text.Trim() + "%'"
                ElseIf rb_TenHoacSDT.Checked Then
                    SQl = SQl + " where Tenbenhnhan LIKE N'%" & txtTenBenhNhan.Text.Trim() & "%' Or LienHe LIKE '%" + txt_SoDienThoai.Text.Trim() + "%'"
                End If

                SQl = SQl + " order by MaKhamBenh"
                Cmd = New SqlCommand(SQl, Cn)
                rd = Cmd.ExecuteReader
                Do While rd.Read
                    'Nếu là bn dịch vụ và khong phải DV chuyển PK hoặc Khám lại, Tư vấn  phải ktra xem đã nộp tiền chưa
                    'If rd!TenDT.ToString <> "Dịch vụ" Or rd!Madichvu = "A01003" Or rd!Madichvu = "A01004" Or rd!Madichvu = "A01005" Or Val(rd!Soluong.ToString) > 0 Then
                    .AddItem(rd!Mabenhnhan.ToString & vbTab & rd!MaKhambenh.ToString & vbTab & rd!ThoiGianDangKy.ToString & vbTab & rd!Tenbenhnhan.ToString & vbTab & rd!Namsinh.ToString & vbTab & IIf(rd!Gioitinh = 1, "Nam", "Nữ") & vbTab & rd!TrieuChung.ToString & vbTab & rd!ChanDoan.ToString)
                    'End If
                Loop
                .AutoSizeCols()
                rd.Close()
                Cmd.Dispose()
                lbl_SoLuongBN.Text = Str(.Rows.Count - 1) ' 
            End With
        Catch ex As Exception
            rd.Close()
            MsgBox(ex.Message)
        End Try
        mdlFunction.Set_Text_FlexGrid(Me, fgDanhsachBN, Lang)
    End Sub

    Private Sub cmdXemDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXemDS.Click
        Try
            Load_DanhsachBN()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub fgDanhsachBN_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles fgDanhsachBN.DoubleClick
        If fgDanhsachBN.Row > 0 Then
            MaPhieuKham = Trim(fgDanhsachBN.Item(fgDanhsachBN.Row, 1))
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Dispose()
        End If
    End Sub
    Private Sub fgDanhsachBN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgDanhsachBN.KeyUp
        Dim cmd As New SqlCommand
        Dim Sql As String = ""
        Dim SoThuTu As Integer = Val(fgDanhsachBN.Item(fgDanhsachBN.RowSel, 12))
        'If e.KeyCode = Keys.F7 And fgDanhsachBN.RowSel > 0 Then
        '    Sql = "Insert into " & TenDatabase & ".DBO.Hienthiden (Cumden, Sothutu,HUBden) values(" & Cumden & "," & SoThuTu & "," & HUBden & ")"
        '    cmd.Connection = Cn
        '    cmd.CommandText = Sql
        '    cmd.ExecuteNonQuery()
        'End If
    End Sub
    Private Sub GoiBenhNhan(ByVal CumDen As String, ByVal SoThuTu As Integer)
        Dim sp As New System.Media.SoundPlayer
        Dim HangTram As Integer
        Dim DonVi As Integer
        'sp.SoundLocation = Application.StartupPath + "\Sound\BenhNhan.Wav"
        If SoThuTu = 0 Then Exit Sub
        sp.SoundLocation = Application.StartupPath + "\Sound\binhbong.wav"
        sp.PlaySync()
        sp.SoundLocation = Application.StartupPath + "\Sound\BenhNhan.Wav"
        sp.PlaySync()
        If (SoThuTu < 400) Then
            sp.SoundLocation = Application.StartupPath + "\Sound\" + SoThuTu.ToString().Trim() + ".Wav"
            sp.PlaySync()
        Else
            HangTram = (SoThuTu \ 100) * 100
            sp.SoundLocation = Application.StartupPath + "\Sound\" + HangTram.ToString().Trim() + ".Wav"
            sp.PlaySync()
            DonVi = SoThuTu Mod 100
            If (DonVi > 0) Then
                If (DonVi < 10) Then
                    sp.SoundLocation = Application.StartupPath + "\Sound\Linh" + DonVi.ToString().Trim() + ".Wav"
                Else
                    sp.SoundLocation = Application.StartupPath + "\Sound\" + DonVi.ToString().Trim() + ".Wav"
                End If
                sp.PlaySync()
            End If
        End If
        'sp.PlaySync()
        'If CumDen < 4 Then
        sp.SoundLocation = Application.StartupPath + "\Sound\buong.Wav"
        'Else

        'End If

        sp.PlaySync()
        sp.SoundLocation = Application.StartupPath + "\Sound\" + CumDen.ToString().Trim() + ".Wav"
        sp.PlaySync()
        'sp.SoundLocation = Application.StartupPath + "\Sound\Silent.Wav"
        'sp.PlaySync()
    End Sub

    Private Sub txtTenBenhNhan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTenBenhNhan.KeyDown, txt_SoDienThoai.KeyDown

        If txtTenBenhNhan.Text.Trim() = "" Then
            Exit Sub
        Else
            Try
                If (e.KeyCode = Keys.Enter) Then
                    Load_DanhsachBN()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, fgDanhsachBN, "vi", Cn)
    End Sub
End Class