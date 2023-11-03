'Imports System
'Imports System.Collections.Generic
'Imports System.ComponentModel
'Imports System.Data
'Imports System.Drawing
'Imports System.Text
'Imports System.Windows.Forms
'Imports GlobalModuls

'Namespace BV354_QTHT.Forms.DanhMuc
'    Partial Public Class frmDanhMucDichVu
'        Inherits Form
'        Private IsAddNew As Boolean = False
'        Public Sub New()
'            InitializeComponent()
'        End Sub

'        Private Sub frmDanhMucDichVu_Load(ByVal sender As Object, ByVal e As EventArgs)
'            fg.Tag = "1"
'            cmbLoaiDichVu.Tag = "1"
'            fg.ClipSeparators = "|;"
'            Dim cs As C1.Win.C1FlexGrid.CellStyle = fg.Styles("EmptyArea")
'            cs.BackColor = Color.FromArgb(156, 186, 239)
'            lblMaCLS.Visible = InlineAssignHelper(cmbMaCLS.Visible, False)
'            fgKhoa.Cols("MaKhoa").AllowEditing = InlineAssignHelper(fgKhoa.Cols("TenKhoa").AllowEditing, False)
'            cmdOK.Top = InlineAssignHelper(cmdCancel.Top, cmdThem.Top)
'            Load_CacDanhMuc()
'            Lock_Edit(True)
'        End Sub
'        Private Sub Load_CacDanhMuc()
'            Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", [Global].ConnectSQL)
'            SQLCmd.CommandText = "SELECT * FROM DMLOAIDICHVU"
'            Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
'            cmbLoaiDichVu.Tag = "0"
'            While dr.Read()
'                cmbLoaiDichVu.AddItem(String.Format("{0};{1}", dr("MaLoaiDichVu"), dr("TenLoaiDichVu")))
'            End While
'            dr.Close()
'            cmbLoaiDichVu.SelectedIndex = -1
'            cmbLoaiDichVu.Tag = "1"

'            SQLCmd.CommandText = "SELECT * FROM DMLOAIDICHVU"
'            dr = SQLCmd.ExecuteReader()
'            cmbLoaiDVChuyenToi.Tag = "0"
'            While dr.Read()
'                cmbLoaiDVChuyenToi.AddItem(String.Format("{0};{1}", dr("MaLoaiDichVu"), dr("TenLoaiDichVu")))
'            End While
'            dr.Close()
'            cmbLoaiDVChuyenToi.SelectedIndex = -1
'            cmbLoaiDVChuyenToi.Tag = "1"

'            SQLCmd.CommandText = "SELECT * FROM DMNHOMDICHVU_BHYT"
'            dr = SQLCmd.ExecuteReader()
'            While dr.Read()
'                cmbNhomBHYT.AddItem(String.Format("{0};{1}", dr("MaNhom"), dr("TenNhom")))
'            End While
'            dr.Close()

'            SQLCmd.CommandText = "SELECT * FROM DMNHOMDICHVU_VPNT_DV"
'            dr = SQLCmd.ExecuteReader()
'            While dr.Read()
'                cmbNHOMDICHVU_VPNT_DV.AddItem(String.Format("{0};{1}", dr("MaNhom"), dr("TenNhom")))
'            End While
'            dr.Close()

'            SQLCmd.CommandText = "SELECT * FROM DMNHOMDICHVU_VPNT_BH"
'            dr = SQLCmd.ExecuteReader()
'            While dr.Read()
'                cmbNHOMDICHVU_VPNT_BHYT.AddItem(String.Format("{0};{1}", dr("MaNhom"), dr("TenNhom")))
'            End While
'            dr.Close()

'            SQLCmd.CommandText = "SELECT * FROM DMNHOMDICHVU_VPNOT_BH"
'            dr = SQLCmd.ExecuteReader()
'            While dr.Read()
'                cmbNHOMDICHVU_VPNOT_BH.AddItem(String.Format("{0};{1}", dr("MaNhom"), dr("TenNhom")))
'            End While
'            dr.Close()

'            SQLCmd.CommandText = "SELECT MaKhoa,TenKhoa,0 As ThucHien FROM DMKHOAPHONG"
'            dr = SQLCmd.ExecuteReader()
'            [Global].BindDatareaderToGrid(fgKhoa, dr)
'            dr.Close()
'            SQLCmd.CommandText = "SELECT * FROM DMCANLAMSANG WHERE LoaiXN=1 ORDER BY TenCLS"
'            dr = SQLCmd.ExecuteReader()
'            cmbMaCLS.ClearItems()
'            While dr.Read()
'                cmbMaCLS.AddItem(String.Format("{0};{1}", dr("MaCLS"), dr("TenCLS")))
'            End While
'            dr.Close()
'            SQLCmd.CommandText = "SELECT MaDT,TenDT,0 As Chon FROM DMDOITUONGBN WHERE Len(MaDT)=1 ORDER BY MaDT"
'            dr = SQLCmd.ExecuteReader()
'            [Global].BindDatareaderToGrid(fgDoiTuong, dr)
'            dr.Close()
'            SQLCmd.Dispose()
'        End Sub
'        Private Sub cmbLoaiDichVu_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
'            Dim NhomCanLamSang As String() = New String(7) {"C50", "C51", "C52", "C53", "C54", "C55", _
'             "C56", "C57"}
'            If cmbLoaiDichVu.Tag.ToString() = "0" OrElse cmbLoaiDichVu.SelectedIndex = -1 Then
'                Return
'            End If
'            Dim MaLoaiDichVu As String = GlobalModuls.[Global].GetCode(cmbLoaiDichVu)
'            If MaLoaiDichVu = "D01" Then
'                'thuoc
'                txtMaDichVu.Mask = "000000000000"
'                cmdThem.Enabled = InlineAssignHelper(cmdSua.Enabled, InlineAssignHelper(cmdXoa.Enabled, False))
'            Else
'                txtMaDichVu.Mask = String.Format("[\{0}\{1}\{2}]-000", MaLoaiDichVu.Substring(0, 1), MaLoaiDichVu.Substring(1, 1), MaLoaiDichVu.Substring(2, 1))
'                cmdThem.Enabled = InlineAssignHelper(cmdSua.Enabled, InlineAssignHelper(cmdXoa.Enabled, True))
'            End If
'            lblMaCLS.Visible = InlineAssignHelper(cmbMaCLS.Visible, False)
'            If Array.IndexOf(NhomCanLamSang, MaLoaiDichVu) > -1 Then
'                lblMaCLS.Visible = InlineAssignHelper(cmbMaCLS.Visible, True)
'            End If
'            Load_DichVu(MaLoaiDichVu)
'        End Sub
'        Private Sub Load_DichVu(ByVal MaLoaiDichVu As String)
'            Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", [Global].ConnectSQL)
'            SQLCmd.CommandText = String.Format("SELECT MaDichVu,TenDichVu,DVT,DonGia,DonGiaBHYT,KhongSuDung,DoiTuong FROM DMDICHVU WHERE LoaiDichVu='{0}'", MaLoaiDichVu)
'            Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
'            [Global].BindDatareaderToGrid(fg, dr)
'            SetEmpty()
'            dr.Close()
'            SQLCmd.Dispose()
'        End Sub
'        Private Sub Load_DichVu_ChiTiet(ByVal MaDichVu As String)
'            Dim DoiTuongBN As String = ""
'            Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", [Global].ConnectSQL)
'            SQLCmd.CommandText = String.Format("SELECT * FROM DMDICHVU WHERE MaDichVu='{0}'", MaDichVu)
'            Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
'            If dr.Read() Then
'                txtMaDichVu.Mask = String.Format("[\{0}\{1}\{2}]-000", MaDichVu.Substring(0, 1), MaDichVu.Substring(1, 1), MaDichVu.Substring(2, 1))
'                txtMaDichVu.Text = MaDichVu.Substring(3)
'                txtTenDichVu.Text = dr("TenDichVu").ToString()
'                txtDVT.Text = dr("DVT").ToString()
'                [Global].SetCmb(cmbNhomBHYT, dr("NhomBhYT").ToString())
'                [Global].SetCmb(cmbNHOMDICHVU_VPNT_DV, dr("NhomVPNT_DV").ToString())
'                [Global].SetCmb(cmbNHOMDICHVU_VPNT_BHYT, dr("NhomVTNT_BH").ToString())
'                [Global].SetCmb(cmbNHOMDICHVU_VPNOT_BH, dr("NhomVTNOT_BH").ToString())
'                chkNoiTru.Checked = (dr("NoiTru_NgoaiTru").ToString() = "1" OrElse dr("NoiTru_NgoaiTru").ToString() = "3")
'                chkNgoaiTru.Checked = (dr("NoiTru_NgoaiTru").ToString() = "2" OrElse dr("NoiTru_NgoaiTru").ToString() = "3")
'                Dim DonGia As Decimal = 0
'                Dim bParse As Boolean = Decimal.TryParse(dr("DonGia").ToString(), DonGia)
'                txtDonGia.Value = DonGia
'                bParse = Decimal.TryParse(dr("DonGiaBHYT").ToString(), DonGia)
'                txtDonGiaBHYT.Value = DonGia
'                txtTentat.Text = dr("Tentat").ToString()
'                txtGhiChu.Text = dr("GhiChu").ToString()
'                chkKhongSuDung.Checked = (dr("KhongSuDung").ToString() = "1")
'                chkThuchenh.Checked = (dr("Thuchenh").ToString() = "1")
'                [Global].SetCmb(cmbMaCLS, dr("maCLS").ToString())
'                DoiTuongBN = dr("DoiTUong").ToString()
'            Else
'                SetEmpty()
'            End If
'            dr.Close()
'            Dim i As Integer = 1
'            While i < fgDoiTuong.Rows.Count
'                fgDoiTuong(i, "Chon") = 0
'                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
'            End While
'            Dim l As Integer = 0
'            While l < DoiTuongBN.Length - 1
'                Dim i As Integer = 1
'                While i < fgDoiTuong.Rows.Count
'                    If fgDoiTuong(i, "MaDT").ToString() = DoiTuongBN.Substring(l, 1) Then
'                        fgDoiTuong(i, "Chon") = 1
'                    End If
'                    System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
'                End While
'                l = l + 2
'            End While
'            Dim i As Integer = 1
'            While i < fgKhoa.Rows.Count
'                fgKhoa(i, "ThucHien") = 0
'                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
'            End While
'            SQLCmd.CommandText = "SELECT * FROM DMDICHVU_KHOA WHERE MaDichVu='" + MaDichVu + "'"
'            dr = SQLCmd.ExecuteReader()
'            While dr.Read()
'                Dim i As Integer = 1
'                While i < fgKhoa.Rows.Count
'                    If fgKhoa(i, "MaKhoa").ToString().Trim() = dr("maKhoa").ToString().Trim() Then
'                        fgKhoa(i, "ThucHien") = 1
'                    End If
'                    System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
'                End While
'            End While
'            dr.Close()
'            SQLCmd.Dispose()
'        End Sub

'        Private Sub fg_Click(ByVal sender As Object, ByVal e As EventArgs)
'            If fg.Tag.ToString() = "0" OrElse fg.Row < 1 Then
'                Return
'            End If
'            Load_DichVu_ChiTiet(fg(fg.Row, "MaDichVu").ToString())
'        End Sub
'        Private Sub SetEmpty()
'            txtMaDichVu.Text = ""
'            txtTenDichVu.Text = ""
'            txtDVT.Text = ""
'            cmbNhomBHYT.SelectedIndex = -1
'            chkNgoaiTru.Checked = InlineAssignHelper(chkNoiTru.Checked, InlineAssignHelper(chkKhongSuDung.Checked, InlineAssignHelper(chkThuchenh.Checked, False)))
'            txtDonGia.Value = InlineAssignHelper(txtDonGiaBHYT.Value, 0)
'            txtGhiChu.Text = ""
'            txtTentat.Text = ""
'            Dim i As Integer = 1
'            While i < fgKhoa.Rows.Count
'                fgKhoa(i, "ThucHien") = 0
'                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
'            End While
'        End Sub

'        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
'            Me.Dispose()
'        End Sub
'        Private Sub Lock_Edit(ByVal isLocked As Boolean)
'            cmdThem.Visible = InlineAssignHelper(cmdSua.Visible, InlineAssignHelper(cmdXoa.Visible, InlineAssignHelper(cmdThoat.Visible, isLocked)))
'            cmdOK.Visible = InlineAssignHelper(cmdCancel.Visible, Not isLocked)

'            cmbLoaiDichVu.[ReadOnly] = Not isLocked
'            fg.Enabled = isLocked

'            txtMaDichVu.[ReadOnly] = InlineAssignHelper(txtTenDichVu.[ReadOnly], InlineAssignHelper(cmbNhomBHYT.[ReadOnly], InlineAssignHelper(txtTentat.[ReadOnly], InlineAssignHelper(txtGhiChu.[ReadOnly], InlineAssignHelper(txtDVT.[ReadOnly], isLocked)))))
'            chkNoiTru.Enabled = InlineAssignHelper(chkNgoaiTru.Enabled, InlineAssignHelper(chkKhongSuDung.Enabled, InlineAssignHelper(chkThuchenh.Enabled, Not isLocked)))
'            cmbMaCLS.[ReadOnly] = isLocked
'            fgKhoa.Cols("ThucHien").AllowEditing = Not isLocked
'            txtDonGia.[ReadOnly] = InlineAssignHelper(txtDonGiaBHYT.[ReadOnly], isLocked)

'        End Sub

'        Private Sub cmdSua_Click(ByVal sender As Object, ByVal e As EventArgs)
'            If fg.Row < 1 Then
'                MessageBox.Show("Chưa chọn dịch vụ để sửa!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'                Return
'            End If
'            IsAddNew = False
'            Lock_Edit(False)
'            txtMaDichVu.[ReadOnly] = True
'            txtTenDichVu.Focus()
'        End Sub
'        Private Function LayMaDichVuMoi(ByVal LoaiDichVu As String) As String
'            Dim StrMaMoi As String = LoaiDichVu + "001"
'            Dim dr As System.Data.SqlClient.SqlDataReader
'            Dim SQLCmd As System.Data.SqlClient.SqlCommand
'            Try
'                SQLCmd = New System.Data.SqlClient.SqlCommand("", [Global].ConnectSQL)
'                SQLCmd.CommandText = "SELECT  right(maDichVu,3) as maxMa from DMDICHVU WHERE LoaiDichVu ='" + LoaiDichVu + "' order by maxMa desc"
'                dr = SQLCmd.ExecuteReader()
'                If Not dr.HasRows Then
'                    StrMaMoi = LoaiDichVu + "001"
'                Else
'                    'đọc phần tử đầu tiên
'                    If dr.Read() Then
'                        Dim so As Integer = System.Convert.ToInt32(dr("maxMa"))
'                        so += 1
'                        StrMaMoi = LoaiDichVu + String.Format("{0:000}", so)
'                    End If
'                End If


'                'dr.read();
'                'if (dr["maxMa"].ToString() == "")
'                '{
'                '    StrMaMoi = LoaiDichVu + "001";
'                '}
'                'else
'                '{
'                '    StrMaMoi = dr["maxMa"].ToString().Substring(3);
'                '    StrMaMoi = string.Format("{0:000}", int.Parse(StrMaMoi) + 3);
'                '    StrMaMoi = LoaiDichVu + StrMaMoi;
'                '}
'                dr.Close()
'                SQLCmd.Dispose()
'            Catch ex As Exception
'            End Try

'            Return StrMaMoi
'        End Function

'        Private Sub cmdThem_Click(ByVal sender As Object, ByVal e As EventArgs)
'            If cmbLoaiDichVu.SelectedIndex = -1 Then
'                MessageBox.Show("Chưa chọn nhóm dịch vụ để thêm!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'                Return
'            End If
'            IsAddNew = True
'            Lock_Edit(False)
'            SetEmpty()
'            Dim MaLoaiDichVu As String = GlobalModuls.[Global].GetCode(cmbLoaiDichVu)
'            If MaLoaiDichVu = "D01" Then
'                'thuoc
'                txtMaDichVu.Mask = "000000000000"
'                cmdThem.Enabled = InlineAssignHelper(cmdSua.Enabled, InlineAssignHelper(cmdXoa.Enabled, False))
'            Else
'                txtMaDichVu.Mask = String.Format("[\{0}\{1}\{2}]-000", MaLoaiDichVu.Substring(0, 1), MaLoaiDichVu.Substring(1, 1), MaLoaiDichVu.Substring(2, 1))
'            End If
'            txtMaDichVu.Text = LayMaDichVuMoi([Global].GetCode(cmbLoaiDichVu)).Substring(3)
'            txtTenDichVu.Focus()
'        End Sub

'        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
'            Lock_Edit(True)
'            If fg.Row > 0 Then
'                Load_DichVu_ChiTiet(fg(fg.Row, "MaDichVu").ToString())
'            End If
'        End Sub

'        Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As EventArgs)
'            If cmbNhomBHYT.SelectedIndex = -1 Then
'                MessageBox.Show("Phải chọn nhóm Bảo hiểm y tế!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'                cmbNhomBHYT.Focus()
'                Return
'            End If
'            If cmbNHOMDICHVU_VPNT_DV.SelectedIndex = -1 Then
'                MessageBox.Show("Phải chọn nhóm Viện phí dich vụ ngoại trú!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'                cmbNHOMDICHVU_VPNT_DV.Focus()
'                Return
'            End If
'            If cmbNHOMDICHVU_VPNT_BHYT.SelectedIndex = -1 Then
'                MessageBox.Show("Phải chọn nhóm Viện phí Bảo hiểm y tế ngoại trú!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'                cmbNHOMDICHVU_VPNT_BHYT.Focus()
'                Return
'            End If
'            If cmbNHOMDICHVU_VPNOT_BH.SelectedIndex = -1 Then
'                MessageBox.Show("Phải chọn Viện phí Bảo hiểm y tế nội trú!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'                cmbNHOMDICHVU_VPNOT_BH.Focus()
'                Return
'            End If
'            Dim MaDichVu As String = txtMaDichVu.Text
'            If MaDichVu.Length < 3 Then
'                MessageBox.Show("Mã dịch vụ không đúng!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'                txtMaDichVu.Focus()
'                Return
'            End If
'            MaDichVu = txtMaDichVu.Mask.Replace("\", "").Substring(1, 3) + txtMaDichVu.Text
'            'Global.GetCode(cmbLoaiDichVu) + MaDichVu;
'			Dim NoiTru_NgoaiTru As Integer = If((chkNoiTru.Checked), (1), (0))
'			Dim NgoaiTru As Integer = If((chkNgoaiTru.Checked), (2), (0))
'            NoiTru_NgoaiTru = NoiTru_NgoaiTru + NgoaiTru
'            If NoiTru_NgoaiTru = 0 Then
'                MessageBox.Show("Phải chọn dịch vụ thuộc ngoại trú hay nội trú!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'                chkNoiTru.Focus()
'                Return
'            End If
'            Dim TenDichVu As String = txtTenDichVu.Text
'            Dim LoaiDichVu As String = [Global].GetCode(cmbLoaiDichVu)
'            Dim DonGia As Decimal = txtDonGia.Value
'            Dim DonGiaBHYT As Decimal = txtDonGiaBHYT.Value
'			Dim KhongSuDung As Integer = If((chkKhongSuDung.Checked), (1), (0))
'			Dim Thuchenh As Integer = If((chkThuchenh.Checked), (1), (0))
'            Dim MaCLS As String = ""
'            If cmbMaCLS.Visible Then
'                MaCLS = [Global].GetCode(cmbMaCLS)
'            End If
'            Dim DoiTuong As String = ""
'            Dim i As Integer = 1
'            While i < fgDoiTuong.Rows.Count
'                If fgDoiTuong.GetCellCheck(i, fgDoiTuong.Cols("Chon").Index) = C1.Win.C1FlexGrid.CheckEnum.Checked Then
'                    DoiTuong = DoiTuong + fgDoiTuong(i, "maDT").ToString() + ","
'                End If
'                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
'            End While
'            Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", [Global].ConnectSQL)
'            Dim trn As System.Data.SqlClient.SqlTransaction = [Global].ConnectSQL.BeginTransaction()
'            SQLCmd.Transaction = trn
'            Try
'                If IsAddNew Then
'					SQLCmd.CommandText = String.Format("INSERT INTO DMDICHVU ( MaDichVu, TenDichVu, DVT, LoaiDichVu, NhomBHYT, NhomVPNT_DV, NhomVTNT_BH, NhomVTNOT_BH, NoiTru_NgoaiTru, DonGia, DonGiaBHYT, GhiChu, TenTat,  KhongSuDung, Thuchenh,  MaCLS, DoiTuong) " + " VALUES ('{0}',N'{1}',N'{2}','{3}',{4},{5},{6},{7}, {8} , {9} ,{10},N'{11}',N'{12}', {13} , {14} , {15} ,N'{16}')", MaDichVu, TenDichVu, txtDVT.Text, LoaiDichVu, [Global].GetCode(cmbNhomBHYT), _
'						[Global].GetCode(cmbNHOMDICHVU_VPNT_DV), [Global].GetCode(cmbNHOMDICHVU_VPNT_BHYT), [Global].GetCode(cmbNHOMDICHVU_VPNOT_BH), NoiTru_NgoaiTru, DonGia, DonGiaBHYT, _
'						txtGhiChu.Text, txtTentat.Text, KhongSuDung, Thuchenh, If((MaCLS = ""), ("Null"), ("'" + MaCLS + "'")), DoiTuong)
'                Else

'					SQLCmd.CommandText = String.Format("UPDATE DMDICHVU  SET TenDichVu=N'{1}',DVT=N'{2}',LoaiDichVu='{3}',NhomBHYT={4},NhomVPNT_DV={5},NhomVTNT_BH={6},NhomVTNOT_BH={7},NoiTru_NgoaiTru={8},DonGia={9},DonGiaBHYT={10},GhiChu=N'{11}',TenTat=N'{12}',KhongSuDung={13},Thuchenh={14},MaCLS={15},DoiTuong='{16}' " + " WHERE MaDichVu='{0}'", fg(fg.Row, "MaDichVu"), TenDichVu, txtDVT.Text, LoaiDichVu, [Global].GetCode(cmbNhomBHYT), _
'						[Global].GetCode(cmbNHOMDICHVU_VPNT_DV), [Global].GetCode(cmbNHOMDICHVU_VPNT_BHYT), [Global].GetCode(cmbNHOMDICHVU_VPNOT_BH), NoiTru_NgoaiTru, DonGia, DonGiaBHYT, _
'						txtGhiChu.Text, txtTentat.Text, KhongSuDung, Thuchenh, If((MaCLS = ""), ("Null"), ("'" + MaCLS + "'")), DoiTuong)
'                End If
'                SQLCmd.ExecuteNonQuery()
'                SQLCmd.CommandText = "DELETE FROM DMDICHVU_KHOA WHERE MaDichVu='" + MaDichVu + "'"
'                SQLCmd.ExecuteNonQuery()
'                Dim i As Integer = 1
'                While i < fgKhoa.Rows.Count
'                    If fgKhoa.GetCellCheck(i, fgKhoa.Cols("ThucHien").Index) = C1.Win.C1FlexGrid.CheckEnum.Checked Then
'                        SQLCmd.CommandText = String.Format("INSERT INTO DMDICHVU_KHOA (MaKhoa,MaDichVu) VALUES ('{0}','{1}')", fgKhoa(i, "MaKhoa").ToString(), MaDichVu)
'                        SQLCmd.ExecuteNonQuery()
'                    End If
'                    System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
'                End While
'                trn.Commit()
'                If IsAddNew Then
'                    fg.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", fg.Rows.Count, MaDichVu, TenDichVu, txtDVT.Text, DonGia, _
'                     DonGiaBHYT, KhongSuDung))
'                Else
'                    fg(fg.Row, "TenDichVu") = TenDichVu
'                    fg(fg.Row, "DVT") = txtDVT.Text
'                    fg(fg.Row, "DonGia") = DonGia
'                    fg(fg.Row, "DonGiaBHYT") = DonGiaBHYT
'                    fg(fg.Row, "KhongSuDung") = KhongSuDung
'                End If
'                Lock_Edit(True)
'            Catch ex As Exception
'                trn.Rollback()
'                MessageBox.Show("Có lỗi khi ghi dữ liệu!" & vbLf + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'            Finally
'                SQLCmd.Dispose()
'                trn.Dispose()
'            End Try
'        End Sub

'        Private Sub cmdXoa_Click(ByVal sender As Object, ByVal e As EventArgs)
'            Dim MaDichVu As String = [Global].GetCode(cmbLoaiDichVu) + txtMaDichVu.Text
'            Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", [Global].ConnectSQL)
'            SQLCmd.CommandText = "DELETE FROM DMDICHVU_KHOA WHERE MaDichVu='" + MaDichVu + "'"
'            SQLCmd.ExecuteNonQuery()
'            SQLCmd.CommandText = "DELETE FROM DMDICHVU WHERE MaDichVu='" + MaDichVu + "'"
'            SQLCmd.ExecuteNonQuery()
'            fg.Rows.Remove(fg.Row)
'            MessageBox.Show("Đã xóa dịch vụ!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        End Sub

'        Private Sub cmdChuyenNhom_Click(ByVal sender As Object, ByVal e As EventArgs)
'            If cmbLoaiDVChuyenToi.SelectedIndex = -1 Then
'                MessageBox.Show("Phải chọn nhóm chuyển tới")
'                cmbLoaiDVChuyenToi.Focus()
'                Return
'            End If
'            If cmbLoaiDVChuyenToi.SelectedText = cmbLoaiDichVu.SelectedText Then
'                MessageBox.Show("Nhóm chuyển tới phải khác nhóm ban đầu!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                cmbLoaiDVChuyenToi.Focus()
'                Return
'            End If
'            Dim MaDichVuCu As String = [Global].GetCode(cmbLoaiDichVu) + txtMaDichVu.Text

'			Dim NoiTru_NgoaiTru As Integer = If((chkNoiTru.Checked), (1), (0))
'			Dim NgoaiTru As Integer = If((chkNgoaiTru.Checked), (2), (0))
'            NoiTru_NgoaiTru = NoiTru_NgoaiTru + NgoaiTru

'            Dim TenDichVu As String = txtTenDichVu.Text
'            Dim LoaiDichVuCu As String = [Global].GetCode(cmbLoaiDichVu)
'            Dim LoaiDichVuMoi As String = [Global].GetCode(cmbLoaiDVChuyenToi)

'            Dim MaDichVuMoi As String = LayMaDichVuMoi([Global].GetCode(cmbLoaiDVChuyenToi))
'            Dim DonGia As Decimal = txtDonGia.Value
'            Dim DonGiaBHYT As Decimal = txtDonGiaBHYT.Value
'			Dim KhongSuDung As Integer = If((chkKhongSuDung.Checked), (1), (0))
'			Dim Thuchenh As Integer = If((chkThuchenh.Checked), (1), (0))
'            Dim MaCLS As String = ""
'            If cmbMaCLS.Visible Then
'                MaCLS = [Global].GetCode(cmbMaCLS)
'            End If
'            Dim DoiTuong As String = ""
'            Dim i As Integer = 1
'            While i < fgDoiTuong.Rows.Count
'                If fgDoiTuong.GetCellCheck(i, fgDoiTuong.Cols("Chon").Index) = C1.Win.C1FlexGrid.CheckEnum.Checked Then
'                    DoiTuong = DoiTuong + fgDoiTuong(i, "maDT").ToString() + ","
'                End If
'                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
'            End While
'            Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", [Global].ConnectSQL)
'            Dim trn As System.Data.SqlClient.SqlTransaction = [Global].ConnectSQL.BeginTransaction()
'            SQLCmd.Transaction = trn
'            Try
'                'xoá dữ liệu cũ
'                SQLCmd.CommandText = "DELETE FROM DMDICHVU WHERE MaDichVu='" + MaDichVuCu + "'"
'                SQLCmd.ExecuteNonQuery()
'                SQLCmd.CommandText = "DELETE FROM DMDICHVU_KHOA WHERE MaDichVu='" + MaDichVuCu + "'"
'                SQLCmd.ExecuteNonQuery()
'                'ghi dữ liệu mới
'				SQLCmd.CommandText = String.Format("INSERT INTO DMDICHVU ( MaDichVu, TenDichVu, DVT, LoaiDichVu, NhomBHYT, NhomVPNT_DV, NhomVTNT_BH, NhomVTNOT_BH, NoiTru_NgoaiTru, DonGia, DonGiaBHYT, GhiChu, TenTat,  KhongSuDung, Thuchenh,  MaCLS, DoiTuong) " + " VALUES ('{0}',N'{1}',N'{2}','{3}',{4},{5},{6},{7}, {8} , {9} ,{10},N'{11}',N'{12}', {13} , {14} , {15} ,N'{16}')", MaDichVuMoi, TenDichVu, txtDVT.Text, LoaiDichVuMoi, [Global].GetCode(cmbNhomBHYT), _
'					[Global].GetCode(cmbNHOMDICHVU_VPNT_DV), [Global].GetCode(cmbNHOMDICHVU_VPNT_BHYT), [Global].GetCode(cmbNHOMDICHVU_VPNOT_BH), NoiTru_NgoaiTru, DonGia, DonGiaBHYT, _
'					txtGhiChu.Text, txtTentat.Text, KhongSuDung, Thuchenh, If((MaCLS = ""), ("Null"), ("'" + MaCLS + "'")), DoiTuong)
'                SQLCmd.ExecuteNonQuery()

'                Dim i As Integer = 1
'                While i < fgKhoa.Rows.Count
'                    If fgKhoa.GetCellCheck(i, fgKhoa.Cols("ThucHien").Index) = C1.Win.C1FlexGrid.CheckEnum.Checked Then
'                        SQLCmd.CommandText = String.Format("INSERT INTO DMDICHVU_KHOA (MaKhoa,MaDichVu) VALUES ('{0}','{1}')", fgKhoa(i, "MaKhoa").ToString(), MaDichVuMoi)
'                        SQLCmd.ExecuteNonQuery()
'                    End If
'                    System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
'                End While
'                trn.Commit()
'                fg.Rows.Remove(fg.Row)
'            Catch ex As Exception
'                trn.Rollback()
'                MessageBox.Show("Có lỗi khi ghi dữ liệu!" & vbLf + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
'            Finally

'                SQLCmd.Dispose()
'                MessageBox.Show("Đã chuyển dịch vụ sang nhóm " + cmbLoaiDVChuyenToi.SelectedText, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                trn.Dispose()
'            End Try

'        End Sub
'        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
'            target = value
'            Return value
'        End Function
'    End Class
'End Namespace


Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports GlobalModuls


Partial Public Class frmDMDichVu
    Private IsAddNew As Boolean = False
    Private sTenLoaiDV As String
    Private Sub frmDanhMucDichVu_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        fg.Tag = "1"
        cmbLoaiDichVu.Tag = "1"
        fg.ClipSeparators = "|;"
        Dim cs As C1.Win.C1FlexGrid.CellStyle = fg.Styles("EmptyArea")
        cs.BackColor = Color.FromArgb(156, 186, 239)

        cmdOK.Top = InlineAssignHelper(cmdCancel.Top, cmdThem.Top)
        Load_CacDanhMuc()
        Lock_Edit(True)
        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, fg, Lang)

    End Sub
    Private Sub Load_CacDanhMuc()
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = "SELECT MaLoaiDichvu, " & Lang & " As TenLoaiDichVu FROM DMLOAIDICHVU"
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
        cmbLoaiDichVu.Tag = "0"
        While dr.Read()
            cmbLoaiDichVu.AddItem(String.Format("{0};{1}", dr("MaLoaiDichVu"), dr("TenLoaiDichVu")))
        End While
        dr.Close()
        cmbLoaiDichVu.SelectedIndex = -1
        cmbLoaiDichVu.Tag = "1"

        'SQLCmd.CommandText = "SELECT * FROM DMLOAIDICHVU"
        'dr = SQLCmd.ExecuteReader()
        'cmbLoaiDVChuyenToi.Tag = "0"
        'While dr.Read()
        '    cmbLoaiDVChuyenToi.AddItem(String.Format("{0};{1}", dr("MaLoaiDichVu"), dr("TenLoaiDichVu")))
        'End While
        'dr.Close()
        'cmbLoaiDVChuyenToi.SelectedIndex = -1
        'cmbLoaiDVChuyenToi.Tag = "1"

        'SQLCmd.CommandText = "SELECT * FROM DMNHOMDICHVU_BHYT"
        'dr = SQLCmd.ExecuteReader()
        'While dr.Read()
        '    cmbNhomBHYT.AddItem(String.Format("{0};{1}", dr("MaNhom"), dr("TenNhom")))
        'End While
        'dr.Close()

        'SQLCmd.CommandText = "SELECT * FROM DMNHOMDICHVU_VP"
        'dr = SQLCmd.ExecuteReader()
        'While dr.Read()
        '    cmbNhomVP.AddItem(String.Format("{0};{1}", dr("MaNhom"), dr("TenNhom")))
        'End While
        'dr.Close()

        SQLCmd.CommandText = "SELECT * FROM DMLOAIPHIEUCHIDINH"
        dr = SQLCmd.ExecuteReader()
        While dr.Read()
            cmbPhieuCD.AddItem(String.Format("{0};{1}", dr("MaLoaiphieuCD"), dr("TenLoaiphieuCD")))
        End While
        dr.Close()


        'SQLCmd.CommandText = "SELECT MaKhoa,TenKhoa,0 As ThucHien FROM DMKHOAPHONG"
        'dr = SQLCmd.ExecuteReader()
        'BindDatareaderToGrid(fgKhoa, dr)
        'dr.Close()

        'SQLCmd.CommandText = "SELECT MaDT,TenDT,0 As Chon FROM DMDOITUONGBN WHERE Len(MaDT)=1 ORDER BY MaDT"
        'dr = SQLCmd.ExecuteReader()
        'BindDatareaderToGrid(fgDoiTuong, dr)
        dr.Close()
        SQLCmd.Dispose()
    End Sub
    Private Sub cmbLoaiDichVu_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLoaiDichVu.TextChanged
        Dim NhomCanLamSang As String() = New String(7) {"C50", "C51", "C52", "C53", "C54", "C55",
         "C56", "C57"}
        If cmbLoaiDichVu.Tag.ToString() = "0" OrElse cmbLoaiDichVu.SelectedIndex = -1 Then
            Return
        End If
        Dim MaLoaiDichVu As String = GetCode(cmbLoaiDichVu)
        If MaLoaiDichVu = "D01" Then
            'thuoc
            txtMaDichVu.Mask = "000000000000"
            cmdThem.Enabled = InlineAssignHelper(cmdSua.Enabled, InlineAssignHelper(cmdXoa.Enabled, False))
        Else
            txtMaDichVu.Mask = String.Format("[\{0}\{1}\{2}]-000", MaLoaiDichVu.Substring(0, 1), MaLoaiDichVu.Substring(1, 1), MaLoaiDichVu.Substring(2, 1))
            cmdThem.Enabled = InlineAssignHelper(cmdSua.Enabled, InlineAssignHelper(cmdXoa.Enabled, True))
        End If
        Load_DichVu(MaLoaiDichVu)
    End Sub
    Private Sub Load_DichVu(ByVal MaLoaiDichVu As String)
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = String.Format("SELECT MaDichVu,TenDichVu,DVT,DonGia,DonGiaBHYT,KhongSuDung,DoiTuong FROM DMDICHVU WHERE LoaiDichVu='{0}'", MaLoaiDichVu)
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
        BindDatareaderToGrid(fg, dr)
        SetEmpty()
        dr.Close()
        SQLCmd.Dispose()
    End Sub
    Private Sub Load_DichVu_ChiTiet(ByVal MaDichVu As String)
        Dim DoiTuongBN As String = ""
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = String.Format("SELECT DV.*, P.MaloaiphieuCD FROM DMDICHVU DV left join DMDICHVU_PHIEUCD P on DV.Madichvu = P.Madichvu  WHERE DV.MaDichVu='{0}'", MaDichVu)
        Dim dr As System.Data.SqlClient.SqlDataReader = SQLCmd.ExecuteReader()
        If dr.Read() Then
            txtMaDichVu.Mask = String.Format("[\{0}\{1}\{2}]-000", MaDichVu.Substring(0, 1), MaDichVu.Substring(1, 1), MaDichVu.Substring(2, 1))
            txtMaDichVu.Text = MaDichVu.Substring(3)
            txtTenDichVu.Text = dr("TenDichVu").ToString()
            txtDVT.Text = dr("DVT").ToString()
            'SetCmb(cmbNhomBHYT, dr("NhomBhYT").ToString())
            'SetCmb(cmbNhomVP, dr("NhomVP").ToString())
            Dim DonGia As Decimal = 0
            Dim bParse As Boolean = Decimal.TryParse(dr("DonGia").ToString(), DonGia)
            txtDonGia.Value = DonGia
            bParse = Decimal.TryParse(dr("DonGiaBHYT").ToString(), DonGia)

            txtTentat.Text = dr("Tentat").ToString()
            txtGhiChu.Text = dr("GhiChu").ToString()

            txtThutuBYT.Text = dr("ThutuBYT").ToString()
            chkKhongSuDung.Checked = (dr("KhongSuDung").ToString() = "1")


            DoiTuongBN = dr("DoiTUong").ToString()
            SetCmb(cmbPhieuCD, dr("MaLoaiphieuCD").ToString())

        Else
            SetEmpty()
        End If
        dr.Close()
        Dim i As Integer = 1
        Dim l As Integer = 0


        dr.Close()
        SQLCmd.Dispose()
    End Sub

    Private Sub fg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fg.Click
        If fg.Tag.ToString() = "0" OrElse fg.Row < 1 Then
            Return
        End If
        Load_DichVu_ChiTiet(fg(fg.Row, "MaDichVu").ToString())
    End Sub
    Private Sub SetEmpty()
        txtMaDichVu.Text = ""
        txtTenDichVu.Text = ""
        txtDVT.Text = ""
        txtDonGia.Value = 0

        txtGhiChu.Text = ""
        txtTentat.Text = ""
        txtThutuBYT.Text = ""

        cmbPhieuCD.SelectedIndex = -1
        Dim i As Integer = 1

    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub
    Private Sub Lock_Edit(ByVal isLocked As Boolean)
        cmdThem.Visible = InlineAssignHelper(cmdSua.Visible, InlineAssignHelper(cmdXoa.Visible, InlineAssignHelper(cmdThoat.Visible, isLocked)))
        cmdOK.Visible = InlineAssignHelper(cmdCancel.Visible, Not isLocked)

        cmbLoaiDichVu.[ReadOnly] = Not isLocked
        fg.Enabled = isLocked



    End Sub

    Private Sub cmdSua_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSua.Click
        If fg.Row < 1 Then
            MessageBox.Show("Haven't selected a service to fix yet!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If
        IsAddNew = False
        Lock_Edit(False)
        txtMaDichVu.[ReadOnly] = True
        txtTenDichVu.Focus()
    End Sub
    Private Function LayMaDichVuMoi(ByVal LoaiDichVu As String) As String
        Dim StrMaMoi As String = LoaiDichVu + "001"
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim SQLCmd As System.Data.SqlClient.SqlCommand
        Try
            SQLCmd = New System.Data.SqlClient.SqlCommand("", Cn)
            SQLCmd.CommandText = "SELECT  right(maDichVu,3) as maxMa from DMDICHVU WHERE LoaiDichVu ='" + LoaiDichVu + "' order by maxMa desc"
            dr = SQLCmd.ExecuteReader()
            If Not dr.HasRows Then
                StrMaMoi = LoaiDichVu + "001"
            Else
                'đọc phần tử đầu tiên
                If dr.Read() Then
                    Dim so As Integer = System.Convert.ToInt32(dr("maxMa"))
                    so += 1
                    StrMaMoi = LoaiDichVu + String.Format("{0:000}", so)
                End If
            End If


            'dr.read();
            'if (dr["maxMa"].ToString() == "")
            '{
            '    StrMaMoi = LoaiDichVu + "001";
            '}
            'else
            '{
            '    StrMaMoi = dr["maxMa"].ToString().Substring(3);
            '    StrMaMoi = string.Format("{0:000}", int.Parse(StrMaMoi) + 3);
            '    StrMaMoi = LoaiDichVu + StrMaMoi;
            '}
            dr.Close()
            SQLCmd.Dispose()
        Catch ex As Exception
        End Try

        Return StrMaMoi
    End Function

    Private Sub cmdThem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdThem.Click
        If cmbLoaiDichVu.SelectedIndex = -1 Then
            MessageBox.Show("The service group to add has not been selected!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If
        IsAddNew = True
        Lock_Edit(False)
        SetEmpty()
        Dim MaLoaiDichVu As String = GetCode(cmbLoaiDichVu)
        If MaLoaiDichVu = "D01" Then
            'thuoc
            txtMaDichVu.Mask = "000000000000"
            cmdThem.Enabled = InlineAssignHelper(cmdSua.Enabled, InlineAssignHelper(cmdXoa.Enabled, False))
        Else
            txtMaDichVu.Mask = String.Format("[\{0}\{1}\{2}]-000", MaLoaiDichVu.Substring(0, 1), MaLoaiDichVu.Substring(1, 1), MaLoaiDichVu.Substring(2, 1))
        End If
        txtMaDichVu.Text = LayMaDichVuMoi(GetCode(cmbLoaiDichVu)).Substring(3)
        txtTenDichVu.Focus()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        Lock_Edit(True)
        If fg.Row > 0 Then
            Load_DichVu_ChiTiet(fg(fg.Row, "MaDichVu").ToString())
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdOK.Click
        Dim MaDichVu As String = txtMaDichVu.Text
        If MaDichVu.Length < 3 Then
            MessageBox.Show("Service code is incorrec!", "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtMaDichVu.Focus()
            Return
        End If
        MaDichVu = txtMaDichVu.Mask.Replace("\", "").Substring(1, 3) + txtMaDichVu.Text
        'Global.GetCode(cmbLoaiDichVu) + MaDichVu;

        Dim TenDichVu As String = txtTenDichVu.Text
        Dim LoaiDichVu As String = GetCode(cmbLoaiDichVu)
        Dim DonGia As Decimal = txtDonGia.Value

        Dim KhongSuDung As Integer = IIf((chkKhongSuDung.Checked), (1), (0))

        Dim MaCLS As String = ""
        Dim ThutuBYT As String = txtThutuBYT.Text

        Dim MaloaiphieuCD As String = GetCode(cmbPhieuCD)
        Dim DoiTuong As String = ""
        Dim i As Integer = 1
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        Dim trn As System.Data.SqlClient.SqlTransaction = Cn.BeginTransaction()
        SQLCmd.Transaction = trn
        Try
            If IsAddNew Then
                SQLCmd.CommandText = String.Format("INSERT INTO DMDICHVU ( MaDichVu, TenDichVu, DVT, LoaiDichVu, " _
                                                    & " NhomBHYT, NhomVP, NoiTru_NgoaiTru, DonGia, DonGiaBHYT, GhiChu, " _
                                                    & " TenTat,  KhongSuDung, Thuchenh,    DoiTuong, ThutuBYT, MasoBYT,DuocMienGiam) " _
                                                    & " VALUES ('{0}',N'{1}',N'{2}','{3}',{4},{5},N'{6}',{7}, {8} , N'{9}' ,N'{10}', {11} ,N'{12}', N'{13}',N'{14}', N'{15}',{16} )",
                     MaDichVu, TenDichVu, txtDVT.Text, LoaiDichVu, 0, 0, 0, DonGia, 0,
                 txtGhiChu.Text, txtTentat.Text, KhongSuDung, 0, "", ThutuBYT, "", 0)
            Else
                SQLCmd.CommandText = String.Format("UPDATE DMDICHVU  SET TenDichVu=N'{1}',DVT=N'{2}',LoaiDichVu='{3}',NhomBHYT={4},NhomVP={5}, NoiTru_NgoaiTru={6},DonGia={7},DonGiaBHYT={8},GhiChu=N'{9}',TenTat=N'{10}',KhongSuDung={11},Thuchenh={12}, DoiTuong=N'{13}', ThutuBYT=N'{14}', MasoBYT = N'{15}',DuocMienGiam = {16} " + " WHERE MaDichVu='{0}'", fg(fg.Row, "MaDichVu"), TenDichVu, txtDVT.Text, LoaiDichVu, 0,
                  0, 0, DonGia, 0, txtGhiChu.Text, txtTentat.Text, KhongSuDung, 0, "", ThutuBYT, "", 0)
            End If
            SQLCmd.ExecuteNonQuery()
            SQLCmd.CommandText = "DELETE FROM DMDICHVU_PHIEUCD WHERE MaDichVu='" + MaDichVu + "'"
            SQLCmd.ExecuteNonQuery()
            SQLCmd.CommandText = String.Format("INSERT INTO DMDICHVU_PHIEUCD ( MaDichVu, MaLoaiphieuCD) VALUES ('{0}','{1}')", MaDichVu, MaloaiphieuCD)
            SQLCmd.ExecuteNonQuery()
            SQLCmd.CommandText = "DELETE FROM DMDICHVU_KHOA WHERE MaDichVu='" + MaDichVu + "'"
            SQLCmd.ExecuteNonQuery()
            i = 1
            trn.Commit()
            If IsAddNew Then
                fg.AddItem(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", fg.Rows.Count, MaDichVu, TenDichVu, txtDVT.Text, DonGia,
                 DonGiaBHYT, KhongSuDung))
            Else
                fg(fg.Row, "TenDichVu") = TenDichVu
                fg(fg.Row, "DVT") = txtDVT.Text
                fg(fg.Row, "DonGia") = DonGia
                fg(fg.Row, "DonGiaBHYT") = DonGiaBHYT
                fg(fg.Row, "KhongSuDung") = KhongSuDung
            End If
            Lock_Edit(True)
        Catch ex As Exception
            trn.Rollback()
            MessageBox.Show("There was an error writing data!" & vbLf + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Finally
            SQLCmd.Dispose()
            trn.Dispose()
        End Try
    End Sub

    Private Sub cmdXoa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdXoa.Click
        If txtTenDichVu.Text.Trim = "" Then
            Exit Sub
        End If
        Dim MaDichVu As String = GetCode(cmbLoaiDichVu) + txtMaDichVu.Text
        Dim SQLCmd As New System.Data.SqlClient.SqlCommand("", Cn)
        SQLCmd.CommandText = "DELETE FROM DMDICHVU_PHIEUCD WHERE MaDichVu='" + MaDichVu + "'"
        SQLCmd.ExecuteNonQuery()
        SQLCmd.CommandText = "DELETE FROM DMDICHVU_KHOA WHERE MaDichVu='" + MaDichVu + "'"
        SQLCmd.ExecuteNonQuery()
        SQLCmd.CommandText = "DELETE FROM DMDICHVU WHERE MaDichVu='" + MaDichVu + "'"
        SQLCmd.ExecuteNonQuery()
        fg.Rows.Remove(fg.Row)
        MessageBox.Show("Service removed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Private Sub cmbNhomVP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_GetText_Click(sender As Object, e As EventArgs) Handles btn_GetText.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, fg, "vi", Cn)
    End Sub
End Class

