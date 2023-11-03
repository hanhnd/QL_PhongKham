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
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports Camera_NET
Imports DirectShowLib
Imports System.Drawing.Imaging
Imports System.Drawing.Text

Public Class frmKQ_ChanDoanHA
    Private sa_dangcap As Integer
    Private sa_danggoi As Integer
    Private dt_dangcap As Integer
    Private dt_danggoi As Integer
    Dim Ten_Nhom As String = ""
    Const file_mau = "D:\Mau_KQ.docx"
    Const file_save = "D:\Mau_KQ_saved.docx"
    ' ------- Start -----------------------
    Private Sub Set_pos_start()
        Try
            With panDS_mauKQ
                .Top = 27
                .Left = 4
                .Visible = False
            End With
            With panDSChidinhCLS
                .Top = 50
                .Left = 300
                .Visible = False
            End With
            'txtNgay.Value = GetSrvDate()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DocDM()
        Dim SQLStr As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim DsDM As DataSet

        'Lấy các danh mục cần thiết
        'SQLStr = "Select MaDT, TenDT from " & TenDatabase & ".DBO.DMDOITUONGBN_CT"
        'Cmd = New SqlCommand(SQLStr, Cn)
        Adap = New SqlDataAdapter
        'Adap.SelectCommand = Cmd
        DsDM = New DataSet
        'Adap.Fill(DsDM, "DMDOITUONGBN")
        'Cmd.Dispose()

        'SQLStr = "Select MaKhoa,Tentat from DMKHOAPHONG where is_khoaChidinh = 1 and left(MaKhoa,1) <> 'P' ORDER BY MaKhoa desc"
        'Cmd = New SqlCommand(SQLStr, Cn)
        'Adap.SelectCommand = Cmd
        'Adap.Fill(DsDM, "DMKHOAPHONG")
        'Cmd.Dispose()

        'SQLStr = "Select MaQH, TenQH from DMQUANHAM  ORDER BY MaQH"
        'Cmd = New SqlCommand(SQLStr, Cn)
        'Adap.SelectCommand = Cmd
        'Adap.Fill(DsDM, "DMQUANHAM")
        'Cmd.Dispose()

        SQLStr = "select 'SA' as Ma, N'Siêu âm' as Ten, 'SIEUAM' as Tentat  union all select 'XQ' as Ma, N'X Quang' as Ten, 'XQUANG' as Tentat " _
        & " union all select 'XS' as Ma, N'X Quang KTS' as Ten, 'XQUANGSO' as Tentat union all select 'NS' as Ma, N'Nội soi' as Ten, 'NOISOI' as Tentat " _
        & " union all select 'TD' as Ma, N'Điện tim' as Ten, 'DIENTIM' as Tentat union all select 'DN' as Ma, N'Điện não' as Ten, 'DIENNAO' as Tentat " _
        & " union all select 'CT' as Ma, N'CT Scanner' as Ten, 'CATLOP' as Tentat union all select 'MR' as Ma, N'Cộng hưởng từ' as Ten, 'CONGHUONGTU' as Tentat "
        Cmd = New SqlCommand(SQLStr, Cn)
        Adap.SelectCommand = Cmd
        Adap.Fill(DsDM, "DMLOAICDHA")
        Cmd.Dispose()

        'cmbDoituong.ColumnWidth = 50
        'cmbDoituong.DataSource = DsDM.Tables("DMDOITUONGBN")
        'cmbDoituong.DisplayMember = "TenDT"
        'cmbDoituong.ValueMember = "MaDT"
        'cmbDoituong.Text = ""
        'cmbDoituong.AutoDropDown = True

        cmbKhoaCD.ColumnWidth = 500
        cmbKhoaCD.DataSource = DsDM.Tables("DMKHOAPHONG")
        cmbKhoaCD.DisplayMember = "Tentat"
        cmbKhoaCD.ValueMember = "MaKhoa"
        cmbKhoaCD.Text = ""
        cmbKhoaCD.AutoDropDown = True

        cmbCapbac.DataSource = DsDM.Tables("DMQUANHAM")
        cmbCapbac.DisplayMember = "TenQH"
        cmbCapbac.ValueMember = "MaQH"
        cmbCapbac.Text = ""
        cmbCapbac.AutoDropDown = True

        cmbGioitinh.ClearItems()
        cmbGioitinh.AddItem("Nam")
        cmbGioitinh.AddItem("Nữ")

        cmbLoaiCDHA.DataSource = DsDM.Tables("DMLOAICDHA")
        cmbLoaiCDHA.DisplayMember = "Ten"
        cmbLoaiCDHA.ValueMember = "Ma"
        cmbLoaiCDHA.SelectedIndex = 0 'Val(GetSetting("PHONGKHAM", "Thuoc tinh", "LoaiCDHA", "0"))
        Ten_Nhom = cmbLoaiCDHA.Columns(2).Text
        cmbLoaiCDHA.AutoDropDown = True
        cmbLoaiCDHA.ColumnWidth() = 50

        Adap.Dispose()
        DsDM.Dispose()
        Adap = Nothing
        Cmd = Nothing
        DsDM = Nothing
    End Sub
    Private Sub Load_DSVTTH(ByVal BP As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Try
            grdVTTH.Rows.Count = 1
            grdVTTH.Redraw = False
            SQL = "Select * from DMCDHA_VTTH where Nhom like N'%" & BP & "%'  "
            Cmd = New SqlCommand(SQL, Cn)
            Dr = Cmd.ExecuteReader
            Do While Dr.Read()
                grdVTTH.AddItem(grdVTTH.Rows.Count & vbTab & Dr!MaVTTH & vbTab & Dr!TenVTTH & vbTab & Dr!DVT)
            Loop
            Dr.Close()
            grdVTTH.Redraw = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Load_DSMau(ByVal TenBS As String, ByVal Khuvuc As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Try
            grdDS_mauKQ.Rows.Count = 0
            grdDS_mauKQ.Redraw = False
            SQL = "Select * from DMCDHA_MAUKQ where Khuvuc = N'" & Khuvuc & "' order by nhom "
            Cmd = New SqlCommand(SQL, Cn)
            Dr = Cmd.ExecuteReader
            Do While Dr.Read()
                grdDS_mauKQ.AddItem(Dr!nhom & vbTab & Dr!tenmau & vbTab & Dr!Khuvuc)
            Loop
            Dr.Close()
            grdDS_mauKQ.Tree.Column = 1
            grdDS_mauKQ.Cols(0).Visible = False
            'grdDS.Subtotal(AggregateEnum.None, 0, 1, "{0}")
            grdDS_mauKQ.Subtotal(AggregateEnum.None, 0, 0, 1, "{0}")
            For i = 0 To grdDS_mauKQ.Rows.Count - 1
                If grdDS_mauKQ.Rows(i).IsNode Then grdDS_mauKQ.Rows(i).Node.Collapsed() = True
            Next
            grdDS_mauKQ.Redraw = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Load_DMCDHA(ByVal Nhom As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Try
            grdDS_ChidinhCLS.Rows.Count = 0
            grdDS_ChidinhCLS.Redraw = False
            SQL = "Select a.*, b.TenNhomCDHA from DMCDHA a " _
            & " left join DMCDHA_Nhom b on a.ManhomCDHA = b.ManhomCDHA " _
            & " where Left(a.ManhomCDHA," & Nhom.Trim.Length & ") = N'" & Nhom & "'  order by a.MaCDHA "
            Cmd = New SqlCommand(SQL, Cn)
            Dr = Cmd.ExecuteReader
            Do While Dr.Read()
                grdDS_ChidinhCLS.AddItem(Dr!ManhomCDHA & vbTab & Dr!TenNhomCDHA & vbTab & Dr!MaCDHA & vbTab & Dr!TenCDHA)
            Loop
            Dr.Close()
            grdDS_ChidinhCLS.Cols(0).Visible = False
            grdDS_ChidinhCLS.Cols(1).Visible = False
            grdDS_ChidinhCLS.Cols(2).Visible = False
            grdDS_ChidinhCLS.Tree.Column = 3
            grdDS_ChidinhCLS.Subtotal(AggregateEnum.None, 0, 1, 2, "{0}")
            For i = 0 To grdDS_ChidinhCLS.Rows.Count - 1
                If grdDS_ChidinhCLS.Rows(i).IsNode Then grdDS_ChidinhCLS.Rows(i).Node.Collapsed() = True
            Next
            grdDS_ChidinhCLS.Redraw = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmKQ_ChanDoanHA_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        SaveSetting("PHONGKHAM", "Thuoc tinh", "LoaiCDHA", cmbLoaiCDHA.SelectedIndex.ToString)
    End Sub
    Private Sub frmKQ_Citi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Set_pos_start()
        DocDM()
        Load_DSVTTH(cmbLoaiCDHA.SelectedValue)
        Load_DSMau(TenDangNhap, cmbLoaiCDHA.SelectedValue)
        Load_DMCDHA(cmbLoaiCDHA.SelectedValue)
        'Load_DSPhieuCD(IIf(optDaTH.Checked, 1, 0))
    End Sub
    '-----------------------------------------
    ' ------- Load - Fill-----------------------
    Private Sub Load_DSPhieuCD(ByVal Dathuchien As Byte)
        Dim SQL_DaTH As String
        Dim SQL_ChuaTH As String
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Dim temp_DaTH = ""
        Dim temp_ChuaTH1 = ""
        Dim temp_ChuaTH2 = ""
        ' & " inner join  viewPHIEUTHANHTOAN_CT k on a.Makhambenh = k.Makhambenh and b.Madichvu = k.Madichvu " _
        Try
            grdDS_phieuCD.Rows.Count = 1
            grdDS_phieuCD.Redraw = False
            If chkChonngay.Checked Then
                temp_DaTH = " where datediff( day,a.ThoigianHT ," & String.Format("'{0:MM/dd/yyyy}'", txtNgay.Value) & ") = 0 and a.Tenbenhnhan like N'%" & txtTenbenhnhan_Tim.Text.Trim & "%'"
                temp_ChuaTH1 = " where datediff( day,a.ThoigianCD ," & String.Format("'{0:MM/dd/yyyy}'", txtNgay.Value) & ") = 0  and d.Tenbenhnhan like N'%" & txtTenbenhnhan_Tim.Text.Trim & "%'"
                temp_ChuaTH2 = " where datediff( day, ThoigianHT ," & String.Format("'{0:MM/dd/yyyy}'", txtNgay.Value) & ") = 0  and  Tenbenhnhan like N'%" & txtTenbenhnhan_Tim.Text.Trim & "%'"
            Else
                temp_DaTH = " where a.Tenbenhnhan like N'%" & txtTenbenhnhan_Tim.Text.Trim & "%'"
                temp_ChuaTH1 = " where d.Tenbenhnhan like N'%" & txtTenbenhnhan_Tim.Text.Trim & "%'"
                temp_ChuaTH2 = " where Tenbenhnhan like N'%" & txtTenbenhnhan_Tim.Text.Trim & "%'"
            End If
            SQL_DaTH = "Select a.*, c.Tentat, BacsiCD,d.Tendu as TenBacsiCD,'' TenKhoaCD, " _
                & " e.TenDichvu As TenCDHA, a.ChandoanLS, a.ThoigianCD from tblCDHA_PhieuCD a " _
                & " left outer join tblCDHA_Ketqua b on a.MaphieuCD = b.MaphieuCD" _
                & " left outer join SYSUSER d on a.BacsiCD = d.Uname" _
                & " left outer join DMDICHVU e on e.MaDichvu =b.MaCLS " & temp_DaTH & " " _
                & " and Bophanthuchien = '" & cmbLoaiCDHA.SelectedValue & "'"
            SQL_ChuaTH = "select  a.Capcuu, a.MaphieuCD,a.ThoigianCD, d.Tenbenhnhan, " _
                & " d.Namsinh, d.Gioitinh,  c.Doituong ,c.Diachi, e.Uname,c.Chandoan ChandoanSB, " _
                & " '' Doituongthe,'' SotheBHYT, '' Capbac, a.Mabenhnhan, a.Makhambenh, " _
                & " b.MaDichvu As MaCDHA, f.TenDichvu As TenCDHA from DBO.tblKhambenh_Chidinh a " _
                & " left outer join DBO.tblKhambenh_Dichvu b on a.MaphieuCD = b.MaphieuCD" _
                & " left outer join DBO.tblKhambenh c on a.Makhambenh = c.Makhambenh" _
                & " left outer join DBO.tblBenhnhan d on c.Mabenhnhan = d.Mabenhnhan" _
                & " left outer join SYSUSER e on a.NhanvienCD = e.Uname" _
                & " left outer join .DBO.DMDICHVU f on b.madichvu = f.madichvu" _
                 & temp_ChuaTH1 & " " _
                & " and a.MaPhieuCD not in (select MaphieuCD from tblCDHA_PhieuCD p  " & temp_ChuaTH2 & " )" _
                & " and a.MaLoaiPhieuCD = '" & cmbLoaiCDHA.SelectedValue & "'" '' AND c.Doituong <> 1 " _
            '& " UNION ALL " _
            '& "select  a.Capcuu, a.MaphieuCD,a.ThoigianCD, d.Tenbenhnhan, " _
            '& " d.Namsinh, d.Gioitinh,  c.Doituong ,c.Diachi, e.Uname,h.ChandoanSB, " _
            '& " c.Doituongthe, c.SotheBHYT, c.Capbac, a.Mabenhnhan, a.Makhambenh, " _
            '& " b.MaDichvu As MaCDHA, f.TenDichvu As TenCDHA from " & TenDatabase & ".DBO.tblKhambenh_Chidinh a " _
            '& " left outer join " & TenDatabase & ".DBO.tblKhambenh_Dichvu b on a.MaphieuCD = b.MaphieuCD" _
            '& " left outer join " & TenDatabase & ".DBO.tblKhambenh c on a.Makhambenh = c.Makhambenh" _
            '& " left outer join " & TenDatabase & ".DBO.tblBenhnhan d on c.Mabenhnhan = d.Mabenhnhan" _
            '& " left outer join SYSUSER e on a.NhanvienCD = e.Uname" _
            '& " left outer join " & TenDatabase & ".DBO.DMDICHVU f on b.madichvu = f.madichvu" _
            '& " left outer join " & TenDatabase & ".DBO.tblKhambenh_KQDVKham h on a.Makhambenh = h.Makhambenh and a.MaDV = h.MaDichvu  " _
            '& temp_ChuaTH1 & " " _
            '& " and a.MaPhieuCD not in (select MaphieuCD from tblCDHA_PhieuCD p  " & temp_ChuaTH2 & " )" _
            '& " and a.MaLoaiPhieuCD = '" & cmbLoaiCDHA.SelectedValue & "' AND c.DoiTuong = 1"
            If Dathuchien = 1 Then 'Load từ databases CLS
                Cmd = New SqlCommand(SQL_DaTH, Cn)
                Dr = Cmd.ExecuteReader
                Do While Dr.Read()
                    grdDS_phieuCD.AddItem(grdDS_phieuCD.Rows.Count & vbTab & Dr!MaphieuCD & vbTab & Dr!Tenbenhnhan _
                    & vbTab & IIf(Dr!Gioitinh = 1, "Nam", "Nữ") _
                    & vbTab & Dr!Namsinh _
                    & vbTab & Dr!TenKhoaCD.ToString _
                    & vbTab & Dr!BacsiCD.ToString _
                    & vbTab & Dr!TenCDHA.ToString _
                    & vbTab & Dr!ChandoanLS.ToString _
                    & vbTab & Dr!ThoigianCD _
                    & vbTab & Dr!Capcuu _
                    & vbTab & Dr!Ketquachung.ToString)
                Loop
                Dr.Close()
            Else 'Load từ databases Khambenh và Noitru
                'Kham benh
                If Dathuchien = 0 Then
                    Cmd = New SqlCommand(SQL_ChuaTH, Cn)
                    Dr = Cmd.ExecuteReader
                    Do While Dr.Read()
                        grdDS_phieuCD.AddItem(grdDS_phieuCD.Rows.Count & vbTab & Dr!MaphieuCD & vbTab & Dr!Tenbenhnhan _
                        & vbTab & IIf(Dr!Gioitinh = 1, "Nam", "Nữ") _
                        & vbTab & Dr!Namsinh _
                        & vbTab & "KKB" _
                        & vbTab & Dr!Uname.ToString _
                        & vbTab & Dr!TenCDHA.ToString _
                        & vbTab & Dr!ChandoanSB.ToString _
                        & vbTab & Dr!ThoigianCD _
                        & vbTab & Dr!Capcuu)
                    Loop
                    Dr.Close()
                    'Noi tru - Chưa làm
                Else
                    Cmd = New SqlCommand(SQL_ChuaTH, Cn)
                    Dr = Cmd.ExecuteReader
                    Do While Dr.Read()
                        grdDS_phieuCD.AddItem(grdDS_phieuCD.Rows.Count & vbTab & Dr!MaphieuCD & vbTab & Dr!Tenbenhnhan _
                        & vbTab & IIf(Dr!Gioitinh = 1, "Nam", "Nữ") _
                        & vbTab & Dr!Namsinh _
                        & vbTab & "KKB" _
                        & vbTab & Dr!Uname.ToString _
                        & vbTab & Dr!TenCDHA.ToString _
                        & vbTab & Dr!ChandoanSB.ToString _
                        & vbTab & Dr!ThoigianCD _
                        & vbTab & Dr!Capcuu)
                    Loop
                    Dr.Close()

                    Cmd = New SqlCommand(SQL_DaTH, Cn)
                    Dr = Cmd.ExecuteReader
                    Do While Dr.Read()
                        grdDS_phieuCD.AddItem(grdDS_phieuCD.Rows.Count & vbTab & Dr!MaphieuCD & vbTab & Dr!Tenbenhnhan _
                        & vbTab & IIf(Dr!Gioitinh = 1, "Nam", "Nữ") _
                        & vbTab & Dr!Namsinh _
                        & vbTab & Dr!TenKhoaCD.ToString _
                        & vbTab & Dr!BacsiCD.ToString _
                        & vbTab & Dr!TenCDHA.ToString _
                        & vbTab & Dr!ChandoanLS.ToString _
                        & vbTab & Dr!ThoigianCD _
                        & vbTab & Dr!Capcuu _
                        & vbTab & Dr!Ketquachung.ToString)
                    Loop
                    Dr.Close()
                End If
            End If
            grdDS_phieuCD.Redraw = True
        Catch ex As Exception
            Dr.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Count_PhieuCD()
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Dim DaTH As Integer = 0
        Dim ChuaTH As Integer = 0
        Try
            SQL = "Select count(*) as SL  from tblCDHA_PhieuCD a " _
                & " where datediff( day,a.ThoigianHT ," & String.Format("'{0:MM/dd/yyyy}'", txtNgay.Value) & ") = 0 " _
                & " and Bophanthuchien = '" & cmbLoaiCDHA.SelectedValue & "'"
            Cmd = New SqlCommand(SQL, Cn)
            Dr = Cmd.ExecuteReader
            Do While Dr.Read()
                optDaTH.Text = "Đã thực hiện (" + Dr!SL.ToString.Trim + ")"
                DaTH = Dr!SL
            Loop
            Dr.Close()

            SQL = "select  count(*) as SL from " & TenDatabase & ".DBO.tblKhambenh_Chidinh a " _
                & " where datediff( day,a.ThoigianCD ," & String.Format("'{0:MM/dd/yyyy}'", txtNgay.Value) & ") = 0 " _
                & " and a.MaPhieuCD not in (select MaphieuCD from tblCDHA_PhieuCD p where datediff( day,p.ThoigianHT ," & String.Format("'{0:MM/dd/yyyy}'", txtNgay.Value) & ") = 0 )" _
                & " and a.MaLoaiPhieuCD = '" & cmbLoaiCDHA.SelectedValue & "'"
            Cmd = New SqlCommand(SQL, Cn)
            Dr = Cmd.ExecuteReader
            Do While Dr.Read()
                optChuaTH.Text = "Chưa thực hiện (" + Dr!SL.ToString.Trim + ")"
                ChuaTH = Dr!SL
            Loop
            Dr.Close()
            optTatca.Text = "Tất cả (" + (DaTH + ChuaTH).ToString + ")"

            'Noi tru - Chưa làm

        Catch ex As Exception
            Dr.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LoadFile(ByVal buffer As Byte())
        Try
            If (buffer.Length > 0) Then
                Dim OutputStream As Stream = File.OpenWrite(file_mau)
                OutputStream.Write(buffer, 0, buffer.Length)
                OutputStream.Close()
                Dim memoryStream As New MemoryStream(buffer)
                RichEditControl1.LoadDocument(memoryStream, DocumentFormat.OpenXml)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occured\n" + ex.Message, "Error")
        End Try
    End Sub
    Private Sub Fill_DataHC2Word()
        Try

            RichEditControl1.Document.BeginUpdate()

            Dim searchResult As ISearchResult = RichEditControl1.Document.StartSearch("<TENPK>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, TenPK.ToUpper)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<DiaChiPK>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, DiachiPK)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Sodt>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, SoDT)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Họ tên đầy đủ của bệnh nhân>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, txtTenbenhnhan.Text.Trim())
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Nam/Nữ>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, cmbGioitinh.Text)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Đối tượng>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, cmbDoituong.Text)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Tuổi>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, txtNamsinh.Value.ToString)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Địa chỉ>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, txtDiachi.Text)
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Chẩn đoán lâm sàng>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, txtChandoanLS.Text.Trim())
            Loop

            searchResult = RichEditControl1.Document.StartSearch("<Người chỉ định>", SearchOptions.CaseSensitive, SearchDirection.Forward, RichEditControl1.Document.Range)
            Do While searchResult.FindNext()
                searchResult.Replace(String.Empty)
                Dim insertRange As DocumentRange = RichEditControl1.Document.InsertText(searchResult.CurrentResult.Start, txtBacsi.Text.Trim)
            Loop

            RichEditControl1.Document.EndUpdate()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub
    Private Sub FillData(ByVal Sophieu As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i
        Try
            If Trim(Sophieu) = "" Then Exit Sub
            SetEmpty()
            'Kiểm tra xem trong bảng CLS có chưa?
            'SQL = "select  a.*, c.*, c.Madichvu as MaCDHA, c.Tendichvu as TenCDHA from " & TenDatabase & ".DBO.tblCDHA_PhieuCD a " _
            '& " left outer join tblCDHA_Ketqua b on a.MaphieuCD = b.MaphieuCD" _
            '& " left outer join DMDichvu c on C.Madichvu =b.MaCLS" _
            '& " where  a.MaphieuCD = N'" & Sophieu & "' "
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            'Adap.SelectCommand = Cmd
            ds = New DataSet
            'Adap.Fill(ds, "Hoso")
            'If ds.Tables("Hoso").Rows.Count > 0 Then ' có rồi --> fill
            '    If ds.Tables("Hoso").Rows(0).Item("Bophanthuchien").ToString <> cmbLoaiCDHA.SelectedValue Then
            '        MsgBox("Phiếu chỉ định không thuộc bộ phận này")
            '        Exit Sub
            '    End If
            '    For i = 0 To ds.Tables("Hoso").Rows.Count - 1
            '        optCapcuu.Checked = ds.Tables("Hoso").Rows(i).Item("Capcuu")
            '        optThuong.Checked = Not optCapcuu.Checked
            '        chkTruc.Checked = ds.Tables("Hoso").Rows(i).Item("Truc")
            '        chkTrongh.Checked = Not chkTruc.Checked
            '        txtSophieuCD.Text = ds.Tables("Hoso").Rows(i).Item("MaphieuCD").ToString
            '        txtThoigianCD.Value = ds.Tables("Hoso").Rows(i).Item("ThoigianCD")
            '        txtTenbenhnhan.Text = ds.Tables("Hoso").Rows(i).Item("Tenbenhnhan").ToString().ToUpper()
            '        txtNamsinh.Value = ds.Tables("Hoso").Rows(i).Item("Namsinh")
            '        txtTuoi.Value = Now.Year - ds.Tables("Hoso").Rows(i).Item("Namsinh")
            '        cmbGioitinh.SelectedIndex = IIf(ds.Tables("Hoso").Rows(i).Item("Gioitinh"), 0, 1)
            '        cmbDoituong.SelectedValue = ds.Tables("Hoso").Rows(i).Item("Doituong")
            '        txtDiachi.Text = ds.Tables("Hoso").Rows(i).Item("Diachi")
            '        txtBacsi.Text = ds.Tables("Hoso").Rows(i).Item("BacsiCD")
            '        cmbKhoaCD.SelectedValue = ds.Tables("Hoso").Rows(i).Item("KhoaCD")
            '        txtChandoanLS.Text = ds.Tables("Hoso").Rows(i).Item("ChandoanLS")
            '        txtSotheBHYT.Text = ds.Tables("Hoso").Rows(i).Item("SotheBHYT")
            '        cmbCapbac.SelectedValue = ds.Tables("Hoso").Rows(i).Item("Capbac")
            '        txtKetluan.Text = ds.Tables("Hoso").Rows(i).Item("Ketquachung")
            '        txtMaBN.Text = ds.Tables("Hoso").Rows(i).Item("Mabenhnhan").ToString
            '        txtMaKB.Text = ds.Tables("Hoso").Rows(i).Item("Makhambenh").ToString
            '        txtMaVV.Text = ds.Tables("Hoso").Rows(i).Item("Mavaovien").ToString
            '        txtThoigianHT.Value = ds.Tables("Hoso").Rows(i).Item("ThoigianHT")
            '        'fill YC_CLS
            '        grdYC_CLS.AddItem(ds.Tables("Hoso").Rows(i).Item("MaCDHA") & vbTab & ds.Tables("Hoso").Rows(i).Item("TenCDHA"))
            '    Next
            '    'Fill VTTH
            '    Fill_VTTH(Sophieu)
            '    Cmd.Dispose()
            '    Adap.Dispose()
            '    ds.Dispose()
            '    ''Fill_Server2Word(Ten_Nhom, txtSophieuCD.Text)
            '    Exit Sub 'Thoát
            'Else ' Chưa có trong CLS
            ' & " inner join  viewPHIEUTHANHTOAN_CT k on a.Makhambenh = k.Makhambenh and b.Madichvu = k.Madichvu " _
            'Kiểm tra xem trong bảng Khambenh có chưa? _ 'case c.Doituong when '2' then '2' when '3' then '3' when '4' then '4' when '5' then '5' else  case  when right(left(c.SotheBHYT,3),2) = '97' then '11' else '12' end end as Doituong, " _
            SQL = "select  a.MaLoaiphieuCD, a.Capcuu, a.MaphieuCD,a.ThoigianCD, d.Tenbenhnhan, " _
                & " d.Namsinh, d.Gioitinh, c.Doituong, " _
                & " c.Diachi, a.Tenbacsi_ca as Uname,case h.ChandoanSB when '' then h.Chandoan else h.ChandoanSB end as ChandoanSB , " _
                & " c.Doituongthe, c.SotheBHYT, c.Capbac, a.Mabenhnhan, a.Makhambenh, " _
                & " b.MaDichvu As MaCDHA, f.TenDichvu As TenCDHA from " & TenDatabase & ".DBO.tblKhambenh_Chidinh a " _
                & " left outer join " & TenDatabase & ".DBO.tblKhambenh_Dichvu b on a.MaphieuCD = b.MaphieuCD" _
                & " left outer join " & TenDatabase & ".DBO.tblKhambenh c on a.Makhambenh = c.Makhambenh" _
                & " left outer join " & TenDatabase & ".DBO.tblBenhnhan d on c.Mabenhnhan = d.Mabenhnhan" _
                & " left outer join SYSUSER e on a.NhanvienCD = e.Uname" _
                & " left outer join " & TenDatabase & ".DBO.DMDICHVU f on b.madichvu = f.madichvu" _
                & " left outer join " & TenDatabase & ".DBO.tblKhambenh_KQDVKham h on a.Makhambenh = h.Makhambenh and a.MaDV = h.MaDichvu " _
                & " where  a.MaphieuCD = N'" & Sophieu & "' AND c.Doituong <> 1 " _
                & " UNION ALL " _
                & "select  a.MaLoaiphieuCD, a.Capcuu, a.MaphieuCD,a.ThoigianCD, d.Tenbenhnhan, " _
                & " d.Namsinh, d.Gioitinh, c.Doituong, " _
                & " c.Diachi, a.Tenbacsi_ca as Uname,case h.ChandoanSB when '' then h.Chandoan else h.ChandoanSB end as ChandoanSB , " _
                & " c.Doituongthe, c.SotheBHYT, c.Capbac, a.Mabenhnhan, a.Makhambenh, " _
                & " b.MaDichvu As MaCDHA, f.TenDichvu As TenCDHA from " & TenDatabase & ".DBO.tblKhambenh_Chidinh a " _
                & " left outer join " & TenDatabase & ".DBO.tblKhambenh_Dichvu b on a.MaphieuCD = b.MaphieuCD" _
                & " left outer join " & TenDatabase & ".DBO.tblKhambenh c on a.Makhambenh = c.Makhambenh" _
                & " left outer join " & TenDatabase & ".DBO.tblBenhnhan d on c.Mabenhnhan = d.Mabenhnhan" _
                & " left outer join SYSUSER e on a.NhanvienCD = e.Uname" _
                 & " left outer join " & TenDatabase & ".DBO.DMDICHVU f on b.madichvu = f.madichvu" _
                & " left outer join " & TenDatabase & ".DBO.tblKhambenh_KQDVKham h on a.Makhambenh = h.Makhambenh and a.MaDV = h.MaDichvu " _
                & " where  a.MaphieuCD = N'" & Sophieu & "' AND c.Doituong = 1 "

            Cmd.CommandText = SQL
            Adap.SelectCommand = Cmd
            Adap.Fill(ds, "HosoKB")
            If ds.Tables("HosoKB").Rows.Count > 0 Then ' có trong Khambenh --> fill
                For i = 0 To ds.Tables("HosoKB").Rows.Count - 1
                    If ds.Tables("HosoKB").Rows(0).Item("MaLoaiphieuCD").ToString <> cmbLoaiCDHA.SelectedValue Then
                        MsgBox("Phiếu chỉ định không thuộc bộ phận này")
                        Exit Sub
                    End If
                    optCapcuu.Checked = ds.Tables("HosoKB").Rows(i).Item("Capcuu")
                    optThuong.Checked = Not optCapcuu.Checked

                    txtSophieuCD.Text = ds.Tables("HosoKB").Rows(i).Item("MaphieuCD").ToString
                    txtThoigianCD.Value = ds.Tables("HosoKB").Rows(i).Item("ThoigianCD")
                    txtTenbenhnhan.Text = ds.Tables("HosoKB").Rows(i).Item("Tenbenhnhan").ToString().ToUpper()
                    txtNamsinh.Value = ds.Tables("HosoKB").Rows(i).Item("Namsinh")
                    txtTuoi.Value = Now.Year - ds.Tables("HosoKB").Rows(i).Item("Namsinh")
                    cmbGioitinh.SelectedIndex = IIf(ds.Tables("HosoKB").Rows(i).Item("Gioitinh"), 0, 1)
                    cmbDoituong.SelectedValue = ds.Tables("HosoKB").Rows(i).Item("Doituong")
                    txtDiachi.Text = ds.Tables("HosoKB").Rows(i).Item("Diachi").ToString
                    txtBacsi.Text = ds.Tables("HosoKB").Rows(i).Item("Uname").ToString
                    cmbKhoaCD.SelectedValue = "K" 'ds.Tables("HosoKB").Rows(i).Item("KhoaCD")
                    txtChandoanLS.Text = ds.Tables("HosoKB").Rows(i).Item("ChandoanSB").ToString
                    txtSotheBHYT.Text = ds.Tables("HosoKB").Rows(i).Item("Doituongthe").ToString + ds.Tables("HosoKB").Rows(i).Item("SotheBHYT").ToString
                    cmbCapbac.SelectedValue = ds.Tables("HosoKB").Rows(i).Item("Capbac").ToString
                    txtMaBN.Text = ds.Tables("HosoKB").Rows(i).Item("Mabenhnhan").ToString
                    txtMaKB.Text = ds.Tables("HosoKB").Rows(i).Item("Makhambenh").ToString
                    txtThoigianHT.Value = GetSrvDate()
                    grdYC_CLS.AddItem(ds.Tables("HosoKB").Rows(i).Item("MaCDHA").ToString & vbTab & ds.Tables("HosoKB").Rows(i).Item("TenCDHA").ToString)
                Next
                Cmd.Dispose()
                Adap.Dispose()
                ds.Dispose()
                Tinh_VTTH_theoDinhmuc()
                Exit Sub 'Thoát
            Else 'Kiểm tra xem trong bảng Nội trú có chưa? 
                'Phần này sẽ làm khi triển khai nội trú
            End If
            ' End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fill_VTTH(ByVal Sophieu As String)
        Dim SQL As String
        Dim Cmd As SqlCommand
        Dim Adap As SqlDataAdapter
        Dim ds As DataSet
        Dim i, j
        Try
            If Trim(Sophieu) = "" Then Exit Sub
            SQL = "select  *  from " & TenDatabase & ".DBO.tblCDHA_VTTH a " _
            & " where  a.MaphieuCD = N'" & Sophieu & "' "
            Cmd = New SqlCommand(SQL, Cn)
            Adap = New SqlDataAdapter
            Adap.SelectCommand = Cmd
            ds = New DataSet
            Adap.Fill(ds, "Hoso")
            If ds.Tables("Hoso").Rows.Count > 0 Then ' có rồi --> fill
                For i = 0 To ds.Tables("Hoso").Rows.Count - 1
                    For j = 1 To grdVTTH.Rows.Count - 1
                        If ds.Tables("Hoso").Rows(i).Item("MaVTTH") = grdVTTH.Item(j, 1) Then
                            grdVTTH.Item(j, 4) = ds.Tables("Hoso").Rows(i).Item("Soluong")
                            Exit For
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fill_Mau(ByVal BS As String, ByVal Nhom As String, ByVal Ten As String, ByVal Khuvuc As String)
        Dim Temp As Byte()
        Try
            Cmd = New SqlCommand("", Cn)
            Cmd.CommandText = String.Format("SELECT Nhom, Tenmau, isnull(FileData,'') as FileData FROM DMCDHA_MAUKQ WHERE  Nhom = {1} and Tenmau = {2}  and Khuvuc = {3} ", "N'" + BS.Replace("'", "''") + "'", "N'" + Nhom.Replace("'", "''") + "'", "N'" + Ten.Replace("'", "''") + "'", "N'" + Khuvuc.Replace("'", "''") + "'")
            dr = Cmd.ExecuteReader()
            While dr.Read()
                Temp = dr("FileData")
            End While
            'objWinWordControl.CloseControl()
            'LoadFile(Temp)
            Dim memoryStream As New MemoryStream(Temp)
            RichEditControl1.LoadDocument(memoryStream, DocumentFormat.OpenXml)

            dr.Close()
            'WinWordControl.WinWordControl.wd = Nothing
            'WinWordControl.WinWordControl.wordWnd = 0
            'objWinWordControl.LoadDocument(file_mau)
            'objWinWordControl.document.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
            dr.Close()
        End Try
    End Sub
    '-----------------------------------------
    ' ------- Update -----------------------
    Private Sub Lock_Control(ByVal DK As Boolean)
        cmdGhi.Visible = DK
        cmdKhongghi.Visible = DK
        grdVTTH.Enabled = DK
        grdYC_CLS.Enabled = DK
        lblChonmauKQ.Enabled = DK
        lblThemYC.Enabled = DK

        cmdThem.Visible = Not DK
        cmdSua.Visible = Not DK
        cmdXoa.Visible = Not DK
        cmdThoat.Visible = Not DK
    End Sub
    Private Sub SetEmpty()
        Dim i = 0
        txtSophieuCD.Text = ""
        txtThoigianCD.ValueIsDbNull = True
        txtTenbenhnhan.Text = ""
        txtNamsinh.Value = 0
        txtTuoi.Value = 0
        cmbGioitinh.Text = ""
        cmbGioitinh.SelectedValue = ""
        cmbDoituong.Text = ""
        cmbDoituong.SelectedValue = ""
        cmbCapbac.Text = ""
        'cmbCapbac.SelectedValue = ""
        txtSotheBHYT.Text = ""
        txtDiachi.Text = ""
        txtBacsi.Text = ""
        cmbKhoaCD.Text = ""
        'cmbKhoaCD.SelectedValue = ""
        txtChandoanLS.Text = ""
        txtKetluan.Text = ""
        txtMaBN.Text = ""
        txtMaKB.Text = ""
        txtMaVV.Text = ""
        grdYC_CLS.Rows.Count = 0
        For i = 1 To grdVTTH.Rows.Count - 1
            grdVTTH.Item(i, 4) = ""
        Next
        txtKetluan.Text = ""

    End Sub
    Private Sub cmdThem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThem.Click
        Lock_Control(True)
        SetEmpty()

        txtThoigianCD.Value = GetSrvDate()
        txtThoigianHT.Value = GetSrvDate()
        txtSophieuCD.Enabled = True
        txtSophieuCD.Focus()
    End Sub
    Private Sub cmdSua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSua.Click
        If txtSophieuCD.Text.Trim.Length <> 12 Then Exit Sub
        Lock_Control(True)
        txtSophieuCD.Enabled = False
        txtTenbenhnhan.Focus()
    End Sub
    Private Sub cmdXoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXoa.Click
        Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        cmd.Connection = Cn
        If MsgBox(String.Format("Bạn có chắc chắn muốn xóa phiếu số : {0} không?", txtSophieuCD.Text), MsgBoxStyle.YesNo, "Cảnh báo!") = MsgBoxResult.No Then Exit Sub
        cmd.CommandText = String.Format("DELETE FROM tblCDHA_KETQUA WHERE  MaphieuCD = {0}    ", "N'" + txtSophieuCD.Text.Replace("'", "''") + "'")
        cmd.ExecuteNonQuery()
        cmd.CommandText = String.Format("DELETE FROM tblCDHA_PHIEUCD WHERE  MaphieuCD = {0}    ", "N'" + txtSophieuCD.Text.Replace("'", "''") + "'")
        cmd.ExecuteNonQuery()
        SetEmpty()
        MsgBox("Đã xóa phiếu.", MsgBoxStyle.Information, "Thông báo!")
    End Sub
    Private Sub cmdGhi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGhi.Click
        Dim Capcuu, Truc, ThoigianCD, Tenbenhnhan, Namsinh, Gioitinh
        Dim Doituong, Diachi, BacsiCD, KhoaCD, ChandoanLS, SotheBHYT, Capbac, Ketquachung
        Dim Mabenhnhan, Makhambenh, Mavaovien, KhoaTH, ThoigianHT, BophanTH
        Dim i
        BophanTH = cmbLoaiCDHA.SelectedValue
        Capcuu = IIf(optCapcuu.Checked, 1, 0)
        Truc = IIf(chkTruc.Checked, 1, 0)
        ThoigianCD = txtThoigianCD.Value
        Tenbenhnhan = "N'" & Replace(Trim(txtTenbenhnhan.Text), "'", "''") & "'"
        Namsinh = ""
        If IsDBNull(txtNamsinh.Value) Then
            Namsinh = "null"
        Else
            Namsinh = txtNamsinh.Value.ToString()
        End If
        Gioitinh = IIf(cmbGioitinh.SelectedIndex() = 0, 1, 0)
        Doituong = "N'" & Replace(Trim(cmbDoituong.SelectedValue), "'", "''") & "'"
        Diachi = "N'" & Replace(Trim(txtDiachi.Text), "'", "''") & "'"
        BacsiCD = "N'" & Replace(Trim(txtBacsi.Text), "'", "''") & "'"
        KhoaCD = "N'" & Replace(Trim(cmbKhoaCD.SelectedValue), "'", "''") & "'"
        ChandoanLS = "N'" & Replace(Trim(txtChandoanLS.Text), "'", "''") & "'"
        SotheBHYT = "N'" & Replace(Trim(txtSotheBHYT.Text), "'", "''") & "'"
        Capbac = "N'" & Replace(Trim(cmbCapbac.SelectedValue), "'", "''") & "'"
        Ketquachung = "N'" & Replace(Trim(txtKetluan.Text), "'", "''") & "'"
        Mabenhnhan = "N'" & Replace(Trim(txtMaBN.Text), "'", "''") & "'"
        Makhambenh = "N'" & Replace(Trim(txtMaKB.Text), "'", "''") & "'"
        Mavaovien = "N'" & Replace(Trim(txtMaVV.Text), "'", "''") & "'"
        KhoaTH = "N'" & Replace(Trim(MaKhoaphong), "'", "''") & "'"
        ThoigianHT = txtThoigianHT.Value

        Dim Tran As SqlTransaction = Nothing
        Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        cmd.Connection = Cn
        cmd.CommandTimeout = 0
        If Not KiemtraHL() Then Exit Sub
        Dim sMaCLS As String
        sMaCLS = grdYC_CLS.GetData(grdYC_CLS.RowSel(), 0).ToString()
        Try
            Tran = Cn.BeginTransaction
            cmd.Transaction = Tran

            If txtSophieuCD.Text.Trim = "" Then ' Chưa có phiếu
                ' Thêm phiếu CD mới
                cmd.CommandText = "Select " & TenDatabase & ".DBO.LayMaPhieuCD_CDHA('" & Format(txtThoigianCD.Value, "yyMMdd") & "','" & cmbLoaiCDHA.SelectedValue & "')" _
                & " INSERT INTO tblCDHA_PhieuCD (MaphieuCD,Capcuu,Truc,ThoigianCD,Tenbenhnhan,Namsinh,Gioitinh, " _
                & " Doituong,Diachi,BacsiCD,KhoaCD,ChandoanLS,SotheBHYT,Capbac,Ketquachung," _
                & " Mabenhnhan,Makhambenh,Mavaovien,KhoaTH,ThoigianHT,BophanThuchien) " _
                & " VALUES (" & TenDatabase & ".DBO.LayMaPhieuCD_CDHA('" & Format(txtThoigianCD.Value, "yyMMdd") & "','" & cmbLoaiCDHA.SelectedValue & "'), " _
                & " " & Capcuu & ",  " & Truc & ",  '" & Format(ThoigianCD, "MM/dd/yyyy HH:mm:ss") & "', " _
                & "  " & Tenbenhnhan & ",  " & Namsinh & ",  " & Gioitinh & ",  " & Doituong & ", " _
                & "  " & Diachi & ",  " & BacsiCD & ",  " & KhoaCD & ",  " & ChandoanLS & ", " _
                & "  " & SotheBHYT & ",  " & Capbac & ",  " & Ketquachung & ",  " & Mabenhnhan & ", " _
                & "  " & Makhambenh & ",  " & Mavaovien & ",  " & KhoaTH & ",  '" & Format(ThoigianHT, "MM/dd/yyyy HH:mm:ss") & "','" & BophanTH & "')"
                txtSophieuCD.Text = cmd.ExecuteScalar().ToString
                ' Thêm kết quả mới
                'For i = 0 To grdYC_CLS.Rows.Count - 1
                cmd.CommandText = " INSERT INTO tblCDHA_KETQUA (MaphieuCD,MaCLS,Ketluan ) " _
                & " VALUES ('" & txtSophieuCD.Text & "',  '" & sMaCLS & "',N'" + txtKetluan.Text.Trim() + "' )" 'grdYC_CLS.Item(i, 0)
                cmd.ExecuteNonQuery()
                'Next
                'Thêm VTTH mới
                For i = 1 To grdVTTH.Rows.Count - 1
                    If Val(grdVTTH.Item(i, 4).ToString.Replace(",", ".")) > 0 Then
                        cmd.CommandText = String.Format(" INSERT INTO tblCDHA_VTTH (MaphieuCD,MaVTTH,Soluong )  VALUES ('{0}',  '{1}', {2} )", txtSophieuCD.Text, grdVTTH.Item(i, 1), grdVTTH.Item(i, 4).ToString.Replace(",", "."))
                        cmd.ExecuteNonQuery()
                    End If
                Next
            Else
                If txtSophieuCD.Text.Trim.Length = 12 Then ' Đã có phiếu
                    'Xóa phiếu nếu đã có trong tblCDHA_PhieuCD
                    cmd.CommandText = String.Format("DELETE FROM tblCDHA_PhieuCD WHERE  MaphieuCD ={0} ", "N'" + txtSophieuCD.Text.Trim.Replace("'", "''") + "'")
                    cmd.ExecuteNonQuery()
                    ' Thêm phiếu CD mới
                    cmd.CommandText = "INSERT INTO tblCDHA_PhieuCD (MaphieuCD,Capcuu,Truc,ThoigianCD,Tenbenhnhan,Namsinh,Gioitinh, " _
                    & " Doituong,Diachi,BacsiCD,KhoaCD,ChandoanLS,SotheBHYT,Capbac,Ketquachung," _
                    & " Mabenhnhan,Makhambenh,Mavaovien,KhoaTH,ThoigianHT,BophanThuchien) " _
                    & " VALUES ('" & txtSophieuCD.Text.Trim & "', " _
                    & " " & Capcuu & ",  " & Truc & ",  '" & Format(ThoigianCD, "MM/dd/yyyy HH:mm:ss") & "', " _
                    & "  " & Tenbenhnhan & ",  " & Namsinh & ",  " & Gioitinh & ",  " & Doituong & ", " _
                    & "  " & Diachi & ",  " & BacsiCD & ",  " & KhoaCD & ",  " & ChandoanLS & ", " _
                    & "  " & SotheBHYT & ",  " & Capbac & ",  " & Ketquachung & ",  " & Mabenhnhan & ", " _
                    & "  " & Makhambenh & ",  " & Mavaovien & ",  " & KhoaTH & ",  '" & Format(ThoigianHT, "MM/dd/yyyy HH:mm:ss") & "','" & BophanTH & "')"
                    cmd.ExecuteNonQuery()
                    'Xóa kết quả cũ nếu có
                    cmd.CommandText = String.Format("DELETE FROM tblCDHA_KETQUA WHERE  MaphieuCD ={0} AND MaCLS = '" + sMaCLS + "'", "N'" + txtSophieuCD.Text.Replace("'", "''") + "'")
                    cmd.ExecuteNonQuery()
                    ' Thêm kết quả mới
                    'For i = 0 To grdYC_CLS.Rows.Count - 1
                    cmd.CommandText = " INSERT INTO tblCDHA_KETQUA (MaphieuCD,MaCLS,Ketluan ) " _
                    & " VALUES ('" & txtSophieuCD.Text & "',  '" & sMaCLS & "',N'" + txtKetluan.Text.Trim() + "' )" 'grdYC_CLS.Item(i, 0)
                    cmd.ExecuteNonQuery()
                    'Next
                    'Xóa VTTH cũ nếu có
                    cmd.CommandText = String.Format("DELETE FROM tblCDHA_VTTH WHERE  MaphieuCD ={0}", "N'" + txtSophieuCD.Text.Replace("'", "''") + "'")
                    cmd.ExecuteNonQuery()
                    'Thêm VTTH mới
                    For i = 1 To grdVTTH.Rows.Count - 1
                        If Val(grdVTTH.Item(i, 4).ToString.Replace(",", ".")) > 0 Then
                            cmd.CommandText = String.Format(" INSERT INTO tblCDHA_VTTH (MaphieuCD,MaVTTH,Soluong )  VALUES ('{0}',  '{1}', {2} )", txtSophieuCD.Text, grdVTTH.Item(i, 1), grdVTTH.Item(i, 4).ToString.Replace(",", "."))
                            cmd.ExecuteNonQuery()
                        End If
                    Next

                    cmd.CommandText = String.Format("UPDATE tblKhamBenh_ChiDinh SET DaThucHien = 1 WHERE  MaphieuCD ={0}", "N'" + txtSophieuCD.Text.Replace("'", "''") + "'")
                    cmd.ExecuteNonQuery()
                End If
            End If
            cmd.Dispose()
            'Load lại danh sách phiếu CD
            Tran.Commit()
            'Load_DSPhieuCD(IIf(optDaTH.Checked, 1, 0))
            Lock_Control(False)

        Catch ex As Exception
            Tran.Rollback()
            MsgBox(ex.Message)
            Exit Sub
        End Try
        'Save thông tin kết quả Word
        Save_Word2Server(Ten_Nhom, sMaCLS, txtSophieuCD.Text)
    End Sub
    Private Sub cmdKhongghi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKhongghi.Click
        Lock_Control(False)
        If txtSophieuCD.Text = "" Then
            SetEmpty()

        End If
    End Sub
    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click

        Me.Dispose()
    End Sub
    '-----------------------------------------
    ' ------- Save - Load word server-----------------------
    Private Sub Save_Word2Server(ByVal nhom As String, ByVal maCLS As String, ByVal Sophieu As String)
        'Dim inputStream As Stream = File.OpenRead(file_save)
        'Dim FileSize As Long = inputStream.Length
        'Dim data(FileSize) As Byte
        Try
            'inputStream.Read(data, 0, CInt(FileSize))
            'inputStream.Close()
            'Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
            'objWinWordControl.document.ActiveWindow.Close()

            Dim strNgay = String.Format("{0:dd}-{0:MM}-{0:yyyy}", txtThoigianCD.Value)
            If Not System.IO.Directory.Exists("D:\\KetQua_CDHA\\" + nhom + "\\" + strNgay) Then
                System.IO.Directory.CreateDirectory("D:\\KetQua_CDHA\\" + nhom + "\\" + strNgay)
            End If
            Dim strFile As String
            strFile = "D:\\KetQua_CDHA\\" + nhom + "\\" + strNgay + "\\" + TenABC(txtTenbenhnhan.Text.Trim()) + "_" + maCLS + "_" + Sophieu + ".docx"
            If System.IO.File.Exists(strFile) Then
                'System.IO.File.Delete("D:\\KetQua_CDHA\\" + nhom + "\\" + maCLS + "_" + Sophieu + ".docx")
                If MessageBox.Show("Bệnh nhân đã có kết quả! Bạn muốn lưu lại file kết quả mới?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    strFile = "D:\\KetQua_CDHA\\" + nhom + "\\" + strNgay + "\\" + TenABC(txtTenbenhnhan.Text.Trim()) + "_" + maCLS + "_" + Sophieu + "_" + String.Format("{0:HHmmss}", DateTime.Now) + ".docx"
                    RichEditControl1.SaveDocument(strFile, DocumentFormat.OpenXml)
                Else
                    System.IO.File.Delete(strFile)
                    RichEditControl1.SaveDocument(strFile, DocumentFormat.OpenXml)
                End If
            Else
                RichEditControl1.SaveDocument(strFile, DocumentFormat.OpenXml)

            End If
            'RichEditControl1.SaveDocument("D:\\KetQua_CDHA\\" + nhom + "\\" + maCLS + "_" + Sophieu + ".docx", DocumentFormat.OpenXml)
            'Dim Dir As String = nhom + "/" + Sophieu.Substring(2, 6)

            'Kiểm tra nếu chưa có thư mục (ngày) thì create
            'If File_Ftp_Exists(nhom, Sophieu.Substring(2, 6)) = False Then MakeDir(Dir)

            'Kiểm tra xem có file kq chưa, nếu có thì xóa rồi upload
            'If File_Ftp_Exists(Dir, Sophieu + ".doc") = True Then DeleteFTP(Dir + "\" + Sophieu + ".doc")
            'Upload(Dir, "E:\" + Sophieu + ".doc")

            'If System.IO.File.Exists("E:\" + Sophieu + ".doc") Then System.IO.File.Delete("E:\" + Sophieu + ".doc")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fill_Server2Word(ByVal Nhom As String, ByVal maCLS As String, ByVal Sophieu As String)
        Dim filename As String = Nhom + "\" + maCLS + "_" + Sophieu.Substring(2, 6)
        If System.IO.File.Exists(file_mau) Then System.IO.File.Delete(file_mau)
        Dim strNgay = String.Format("{0:dd}-{0:MM}-{0:yyyy}", txtThoigianCD.Value)
        Try
            '' Download("E:\\", filename, Sophieu + ".doc")
            If System.IO.File.Exists("D:\\KetQua_CDHA\\" + Nhom + "\\" + strNgay + "\\" + TenABC(txtTenbenhnhan.Text.Trim()) + "_" + maCLS + "_" + Sophieu + ".docx") Then
                RichEditControl1.LoadDocument("D:\\KetQua_CDHA\\" + Nhom + "\\" + strNgay + "\\" + TenABC(txtTenbenhnhan.Text.Trim()) + "_" + maCLS + "_" + Sophieu + ".docx")

            End If
        Catch ex As Exception
            If ex.Message <> "Object reference not set to an instance of an object." Then MsgBox(ex.Message)
        End Try
    End Sub
    '-----------------------------------------
    ' ------- Tool -----------------------
    Private Sub txtSophieuCD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSophieuCD.KeyUp
        If e.KeyCode = Keys.Enter Then
            AutoFill_MaphieuCD("CD", txtSophieuCD)
            If txtSophieuCD.Text.Trim.Length() <> 12 Then
                MsgBox("Độ dài mã phiếu không đúng!", MsgBoxStyle.Exclamation, "Thông báo!")
                txtSophieuCD.Text = ""
                Exit Sub
            End If
            FillData(txtSophieuCD.Text.Trim())
        End If
    End Sub
    Private Function KiemtraHL() As Boolean
        KiemtraHL = False
        If Trim(txtTenbenhnhan.Text.Trim) = "" Then
            MsgBox("Phải nhập tên bệnh nhân", MsgBoxStyle.Information, "Thông báo !")
            txtTenbenhnhan.Focus()
            Exit Function
        End If
        'If txtTuoi.Value <= 0 Or txtTuoi.Value > 110 Then
        '    MsgBox("Phải nhập tuổi bệnh nhân", MsgBoxStyle.Information, "Thông báo !")
        '    txtTuoi.Focus()
        '    Exit Function
        'End If
        If cmbGioitinh.SelectedIndex < 0 Then
            MsgBox("Phải nhập giới tính", MsgBoxStyle.Information, "Thông báo !")
            cmbGioitinh.Focus()
            Exit Function
        End If
        If cmbDoituong.SelectedValue = Nothing Then
            MsgBox("Phải nhập đối tượng", MsgBoxStyle.Information, "Thông báo !")
            cmbDoituong.Focus()
            Exit Function
        End If
        'If cmbDoituong.Text.Trim = "Bảo hiểm y tế" And txtSotheBHYT.Text.Trim.Length <> 15 Then
        '    MsgBox("Phải nhập đúng số thẻ BHYT", MsgBoxStyle.Information, "Thông báo !")
        '    txtSotheBHYT.Focus()
        '    Exit Function
        'End If
        'If cmbDoituong.Text.Trim = "Quân" And cmbCapbac.SelectedValue = Nothing Then
        '    MsgBox("Phải nhập cấp bậc.", MsgBoxStyle.Information, "Thông báo !")
        '    cmbCapbac.Focus()
        '    Exit Function
        'End If
        'If cmbDoituong.Text.Trim = "Quân" And txtDiachi.Text.Trim = "" Then
        '    MsgBox("Phải nhập đơn vị.", MsgBoxStyle.Information, "Thông báo !")
        '    txtDiachi.Focus()
        '    Exit Function
        'End If
        If Trim(txtBacsi.Text.Trim) = "" Then
            MsgBox("Phải nhập tên bác sĩ chỉ định", MsgBoxStyle.Information, "Thông báo !")
            txtBacsi.Focus()
            Exit Function
        End If
        If cmbKhoaCD.SelectedValue = Nothing Then
            MsgBox("Phải nhập khoa chỉ định", MsgBoxStyle.Information, "Thông báo !")
            cmbKhoaCD.Focus()
            Exit Function
        End If
        If Trim(txtChandoanLS.Text.Trim) = "" Then
            MsgBox("Phải nhập chẩn đoán lâm sàng", MsgBoxStyle.Information, "Thông báo !")
            txtChandoanLS.Focus()
            Exit Function
        End If

        If Trim(txtKetluan.Text.Trim) = "" Then
            MsgBox("Phải nhập kết luận", MsgBoxStyle.Information, "Thông báo !")
            txtKetluan.Focus()
            txtKetluan.BackColor = Color.Yellow
            Exit Function
        End If
        If grdYC_CLS.Rows.Count = 0 Then
            MsgBox("Phải chọn yêu cầu chiếu chụp", MsgBoxStyle.Information, "Thông báo !")
            panDSChidinhCLS.Visible = True
            Exit Function
        End If
        'For i = 0 To grdYC_CLS.Rows.Count - 1
        '    If grdYC_CLS.Item(i, 0).ToString.Trim = "" Then
        '        MsgBox("Danh sách yêu cầu chiếu chụp chưa đúng (Dòng thứ " + (i + 1).tostring.trim + ").", MsgBoxStyle.Information, "Thông báo !")
        '        Exit Function
        '    End If
        'Next
        KiemtraHL = True
    End Function
    Private Sub lblThemYC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblThemYC.Click
        panDSChidinhCLS.Visible = True
        panDSChidinhCLS.BringToFront()
    End Sub
    Private Sub cmdClose_panChidinhCLS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose_panChidinhCLS.Click
        panDSChidinhCLS.Visible = False
    End Sub
    Private Sub grdDS_ChidinhCLS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDS_ChidinhCLS.DoubleClick
        Dim i = 0
        If grdDS_ChidinhCLS.Item(grdDS_ChidinhCLS.Row, 0) = Nothing Then Exit Sub
        'Thêm vào danh sách YC
        If grdYC_CLS.Rows.Count = 0 Then ' Chưa có YC nào
            grdYC_CLS.AddItem(grdDS_ChidinhCLS.Item(grdDS_ChidinhCLS.Row, 2) & vbTab & grdDS_ChidinhCLS.Item(grdDS_ChidinhCLS.Row, 3))
        Else ' Có YC rồi
            For i = 0 To grdYC_CLS.Rows.Count - 1
                If grdYC_CLS.Item(i, 0) = grdDS_ChidinhCLS.Item(grdDS_ChidinhCLS.Row, 2) Then ' YC mới đã có trong ds
                    MsgBox("Đã có chỉ định trong danh sách yêu cầu. Không được thêm mới!", MsgBoxStyle.Critical, "Thông báo!")
                    Exit Sub
                End If
            Next
            grdYC_CLS.AddItem(grdDS_ChidinhCLS.Item(grdDS_ChidinhCLS.Row, 2) & vbTab & grdDS_ChidinhCLS.Item(grdDS_ChidinhCLS.Row, 3))
        End If
        Tinh_VTTH_theoDinhmuc()
        panDSChidinhCLS.Visible = False
    End Sub
    Private Sub grdVTTH_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdVTTH.BeforeEdit
        If e.Col <> 4 Then e.Cancel = True
    End Sub
    Private Sub grdDS_phieuCD_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDS_phieuCD.DoubleClick
        If grdDS_phieuCD.Row = 0 Then Exit Sub
        TabControl1.TabPages(0).Show()
        TabControl1.SelectedTab = TabPage1
        FillData(grdDS_phieuCD.Item(grdDS_phieuCD.Row, 1))
    End Sub
    Private Sub grdYC_CLS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdYC_CLS.KeyUp
        If e.KeyCode = Keys.Delete And grdYC_CLS.Row >= 0 Then
            grdYC_CLS.RemoveItem(grdYC_CLS.Row)
            Tinh_VTTH_theoDinhmuc()
        End If
    End Sub
    Private Sub optChuaTH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optChuaTH.Click, txtNgay.ValueChanged
        If optChuaTH.Checked Then
            lblNgay.Text = "Ngày chỉ định:"
            Load_DSPhieuCD(0)
        End If
        If optDaTH.Checked Then
            lblNgay.Text = "Ngày thực hiện:"
            Load_DSPhieuCD(1)
        End If
        If optTatca.Checked Then
            lblNgay.Text = "Ngày:"
            Load_DSPhieuCD(2)
        End If
    End Sub
    Private Sub optDaTH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDaTH.Click, txtNgay.ValueChanged
        If optChuaTH.Checked Then
            lblNgay.Text = "Ngày chỉ định:"
            Load_DSPhieuCD(0)
        End If
        If optDaTH.Checked Then
            lblNgay.Text = "Ngày thực hiện:"
            Load_DSPhieuCD(1)
        End If
        If optTatca.Checked Then
            lblNgay.Text = "Ngày:"
            Load_DSPhieuCD(2)
        End If
    End Sub
    Private Sub optTatca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optTatca.Click, txtNgay.ValueChanged
        If optChuaTH.Checked Then
            lblNgay.Text = "Ngày chỉ định:"
            Load_DSPhieuCD(0)
        End If
        If optDaTH.Checked Then
            lblNgay.Text = "Ngày thực hiện:"
            Load_DSPhieuCD(1)
        End If
        If optTatca.Checked Then
            lblNgay.Text = "Ngày:"
            Load_DSPhieuCD(2)
        End If
    End Sub
    Private Sub TabControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyUp
        Select Case e.KeyCode
            Case Keys.F6
                If lblChonmauKQ.Enabled Then panDS_mauKQ.Visible = True
            Case Keys.F5
                If cmdThem.Visible Then cmdThem_Click(sender, e)
            Case Keys.F9
                If cmdGhi.Visible Then cmdGhi_Click(sender, e)
                'Case Keys.F7
                '    GoiSo(1, 1)
                'Case Keys.F8
                '    GoiSo(1, 2)
                'Case Keys.F12
                '    Dim frm As New frmBanDieuKhien
                '    frm.Show()
        End Select
    End Sub
    Private Sub txtNamsinh_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNamsinh.Validated
        If txtNamsinh.Value > 1900 Then
            txtTuoi.Value = Now.Year - txtNamsinh.Value
        End If
    End Sub
    Private Sub txtTuoi_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTuoi.GotFocus
        txtTuoi.Select(0, txtTuoi.Value.ToString.Length)
    End Sub
    Private Sub txtTuoi_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTuoi.Validated
        If txtTuoi.Value > 0 And txtTuoi.Value < 110 Then
            txtNamsinh.Value = Now.Year - txtTuoi.Value
        End If
    End Sub
    Private Sub txtNamsinh_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNamsinh.GotFocus
        txtNamsinh.Select(0, txtNamsinh.Value.ToString.Length)
    End Sub
    Private Sub Tinh_VTTH_theoDinhmuc()
        Dim i As Byte = 0
        Dim j As Byte = 0
        Dim MaCDHA As String = ""
        Dim SQL As String = ""
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Try
            For i = 1 To grdVTTH.Rows.Count - 1
                grdVTTH.Item(i, 4) = 0
            Next
            If grdYC_CLS.Rows.Count = 0 Then Exit Sub
            For i = 0 To grdYC_CLS.Rows.Count - 1
                MaCDHA = grdYC_CLS.Item(i, 0)
                SQL = "Select * from DMCDHA_DINHMUCVTTH where MaCDHA = N'" & MaCDHA & "'"
                Cmd = New SqlCommand(SQL, Cn)
                Dr = Cmd.ExecuteReader
                Do While Dr.Read
                    'Có Vật tư định mức
                    For j = 1 To grdVTTH.Rows.Count - 1
                        If grdVTTH.Item(j, 1) = Dr!MaVTTH.ToString Then
                            grdVTTH.Item(j, 4) += Dr!Soluong
                            Exit For
                        End If
                    Next
                Loop
                Dr.Close()
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtTenbenhnhan_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenbenhnhan.Validated
        txtTenbenhnhan.Text = TenABC(txtTenbenhnhan.Text)
    End Sub
    Private Sub cmdClose_panDS_mauKQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose_panDS_mauKQ.Click
        panDS_mauKQ.Visible = False
        Me.txtKetluan.Focus()
    End Sub
    Private Sub lblChonmauKQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblChonmauKQ.Click
        'If KiemtraHL() Then

        'End If
        panDS_mauKQ.Visible = True
        panDS_mauKQ.BringToFront()

        For Each prc As Process In Process.GetProcessesByName("WINWORD")
            prc.Kill()
        Next

    End Sub
    Private Sub grdDS_mauKQ_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDS_mauKQ.DoubleClick
        If grdDS_mauKQ.Item(grdDS_mauKQ.Row, 0) = Nothing Then Exit Sub
        Fill_Mau(TenDangNhap, grdDS_mauKQ.Item(grdDS_mauKQ.Row, 0), grdDS_mauKQ.Item(grdDS_mauKQ.Row, 1), grdDS_mauKQ.Item(grdDS_mauKQ.Row, 2))
        panDS_mauKQ.Visible = False
        Fill_DataHC2Word()
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            If txtNgay.ValueIsDbNull Then txtNgay.Value = GetSrvDate()
            Count_PhieuCD()
            Load_DSPhieuCD(IIf(optChuaTH.Checked, 0, IIf(optDaTH.Checked, 1, 2)))
        End If
    End Sub
    '-----------------------------------------
    'Private Sub cmdChonfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChonfile.Click
    '    Dim filNm As String
    '    OpenFileDialog1.Multiselect = False
    '    OpenFileDialog1.Filter = "MS-Word Files (*.doc,*.dot) | *.doc;*.dot"
    '    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        filNm = OpenFileDialog1.FileName
    '    Else
    '        Return
    '    End If
    '    'MessageBox.Show("Please wait while the document is being displayed")
    '    'Try
    '    '    objWinWordControl.CloseControl()
    '    'Catch ex1 As Exception
    '    '    objWinWordControl.document = null
    '    '    WinWordControl.WinWordControl.wd = null
    '    '    WinWordControl.WinWordControl.wordWnd = 0
    '    'End Try

    '    Try
    '        'Load the template used for testing.
    '        objWinWordControl.LoadDocument(filNm)
    '    Catch ex2 As Exception
    '        MsgBox(ex2.Message)
    '    End Try

    '    'btnClientName.Enabled = True
    '    'btnRecNo.Enabled = True
    '    'btnCurrentDate.Enabled = True
    'End Sub
    Private Sub txtMaVV_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaVV.KeyUp
        Dim SQL As String = ""
        Dim Cmd As SqlCommand
        Dim Dr As SqlDataReader
        Try
            If txtMaVV.Text.Trim.Length <> 10 Or e.KeyCode <> Keys.Enter Then Exit Sub
            txtThoigianCD.Value = GetSrvDate()
            SQL = String.Format("Select * from " & TenDatabase & ".DBO.tblBenhnhanNoivien where Mavaovien = N'{0}'", txtMaVV.Text)
            Cmd = New SqlCommand(SQL, Cn)
            Dr = Cmd.ExecuteReader
            Do While Dr.Read
                txtTenbenhnhan.Text = Dr!Tenbenhnhan.ToString
                txtNamsinh.Value = Dr!Namsinh
                txtTuoi.Value = Now.Year - Dr!Namsinh
                cmbGioitinh.SelectedIndex = IIf(Dr!Gioitinh, 0, 1)
                cmbDoituong.SelectedValue = Dr!Doituong
                txtDiachi.Text = Dr!Diachi.ToString
                cmbKhoaCD.SelectedValue = Dr!KhoaVV.ToString
                txtSotheBHYT.Text = Dr!Doituongthe.ToString + Dr!SotheBHYT.ToString
                cmbCapbac.SelectedValue = Dr!Capbac.ToString
                txtMaBN.Text = Dr!Mabenhnhan.ToString
                txtMaKB.Text = Dr!Makhambenh.ToString
                cmbKhoaCD.Focus()
            Loop
            Dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub picZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picZoom.Click

    End Sub

    Private Sub cmbLoaiCDHA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoaiCDHA.TextChanged

        TabControl1.TabPages(0).Text = "Kết quả " + cmbLoaiCDHA.Text
        lblDMChidinh.Text = "DANH SÁCH CHỈ ĐỊNH " + cmbLoaiCDHA.Text.ToUpper
        Ten_Nhom = cmbLoaiCDHA.Columns(2).Text
        SetEmpty()
        Load_DSVTTH(cmbLoaiCDHA.SelectedValue)
        Load_DSMau(TenDangNhap, cmbLoaiCDHA.SelectedValue)
        Load_DMCDHA(cmbLoaiCDHA.SelectedValue)
    End Sub

    Private Sub grdYC_CLS_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdYC_CLS.DoubleClick
        Dim sMaCLS As String
        sMaCLS = grdYC_CLS.GetData(grdYC_CLS.RowSel, 0)
        Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
        cmd.Connection = Cn
        cmd.CommandTimeout = 0
        cmd.CommandText = String.Format("SELECT * FROM tblCDHA_KETQUA WHERE  MaphieuCD ={0}", "N'" + txtSophieuCD.Text.Replace("'", "''") + "' AND MaCLS = N'" + sMaCLS + "'")
        Dim da As System.Data.SqlClient.SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dtb As DataTable = New DataTable()
        da.Fill(dtb)
        If (dtb IsNot Nothing And dtb.Rows.Count > 0) Then
            txtKetluan.Text = dtb.Rows(0)("Ketluan").ToString()
        End If

        If dtb.Rows.Count > 0 Then
            For Each prc As Process In Process.GetProcessesByName("WINWORD")
                prc.Kill()
            Next
            Fill_Server2Word(Ten_Nhom, sMaCLS, txtSophieuCD.Text)
        End If
        cmd.Dispose()
    End Sub
    Dim _MouseSelectionRect As NormalizedRect = New NormalizedRect(0, 0, 0, 0)
    Dim _bDrawMouseSelection As Boolean = False

    ' Zooming
    Dim _bZoomed = False
    Dim _fZoomValue = 1.0
    Dim _CameraChoice As CameraChoice = New CameraChoice()
    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedIndex = 1 Then
            'Fill camera list combobox with available cameras
            FillCameraList()

            'Select the first one
            If (comboBoxCameraList.Items.Count > 0) Then
                comboBoxCameraList.SelectedIndex = 0
            End If

            'Fill camera list combobox with available resolutions
            FillResolutionList()
            buttonSnapshotNextSourceFrame.Visible = True
        Else
            buttonSnapshotNextSourceFrame.Visible = False
            cameraControl.CloseCamera()
        End If
    End Sub
    Private Sub FillCameraList()
        comboBoxCameraList.Items.Clear()
        _CameraChoice.UpdateDeviceList()
        For Each camera_device In _CameraChoice.Devices
            comboBoxCameraList.Items.Add(camera_device.Name)
        Next
    End Sub
    Private Sub FillResolutionList()
        comboBoxResolutionList.Items.Clear()
        If Not cameraControl.CameraCreated Then Return
        Dim resolutions As ResolutionList = Camera.GetResolutionList(cameraControl.Moniker)
        If resolutions Is Nothing Then Return
        Dim index_to_select As Integer = -1

        For index As Integer = 0 To resolutions.Count - 1
            comboBoxResolutionList.Items.Add(resolutions(index).ToString())
            If Ten_Nhom = "SIEUAM" Then
                If resolutions(index).Width = 1280 And resolutions(index).Height = 1024 Then
                    index_to_select = index
                End If
            Else
                If resolutions(index).CompareTo(cameraControl.Resolution) = 0 Then
                    index_to_select = index
                End If
            End If

        Next

        If index_to_select >= 0 Then
            comboBoxResolutionList.SelectedIndex = index_to_select
        End If
    End Sub
    Private Sub SetCamera(ByVal camera_moniker As Runtime.InteropServices.ComTypes.IMoniker, ByVal resolution As Resolution)

        Try
            cameraControl.SetCamera(camera_moniker, resolution)
        Catch e As Exception
            MessageBox.Show(e.Message, "Error while running camera")
        End Try

        If Not cameraControl.CameraCreated Then Return
        cameraControl.MixerEnabled = True
        UpdateCameraBitmap()
        UpdateGUIButtons()
    End Sub
    Private Sub UpdateUnzoomButton()
        If _bZoomed Then
            buttonUnZoom.Left = cameraControl.Left + (cameraControl.ClientRectangle.Width - cameraControl.OutputVideoSize.Width) / 2 + 4
            buttonUnZoom.Top = cameraControl.Top + (cameraControl.ClientRectangle.Height - cameraControl.OutputVideoSize.Height) / 2 + 40
            buttonUnZoom.Visible = True
        Else
            buttonUnZoom.Visible = False
        End If
    End Sub
    'Generate bitmap for overlay
    Private Sub UpdateCameraBitmap()

        If (Not cameraControl.MixerEnabled) Then
            Exit Sub
        End If

        cameraControl.OverlayBitmap = GenerateColorKeyBitmap(False)

        '#region D3D bitmap mixer
        'if (cameraControl.UseGDI)
        '{
        '    cameraControl.OverlayBitmap = GenerateColorKeyBitmap(false);
        '}
        'else
        '{
        '    cameraControl.OverlayBitmap = GenerateAlphaBitmap();
        '}
        '#endregion
    End Sub

    ''Update buttons of GUI based on Camera state
    Private Sub UpdateGUIButtons()
        ' buttonCrossbarSettings.Enabled = (cameraControl.CrossbarAvailable)
    End Sub
    Private Function GenerateColorKeyBitmap(ByVal useAntiAlias As Boolean) As Bitmap
        Dim w As Integer = cameraControl.OutputVideoSize.Width
        Dim h As Integer = cameraControl.OutputVideoSize.Height
        If w <= 0 OrElse h <= 0 Then Return Nothing
        Dim bmp As Bitmap = New Bitmap(w, h, PixelFormat.Format24bppRgb)
        Dim g As Graphics = Graphics.FromImage(bmp)

        If useAntiAlias Then
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = TextRenderingHint.AntiAlias
        Else
            g.SmoothingMode = SmoothingMode.None
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit
        End If

        g.Clear(cameraControl.GDIColorKey)

        If _bDrawMouseSelection And IsMouseSelectionRectCorrect() Then
            Dim color_of_pen As Color = Color.Gray

            If IsMouseSelectionRectCorrectAndGood() Then
                color_of_pen = Color.Green
            End If

            Dim pen As Pen = New Pen(color_of_pen, 2.0F)
            Dim rect As Rectangle = New Rectangle(CInt((_MouseSelectionRect.left * w)), CInt((_MouseSelectionRect.top * h)), CInt(((_MouseSelectionRect.right - _MouseSelectionRect.left) * w)), CInt(((_MouseSelectionRect.bottom - _MouseSelectionRect.top) * h)))
            g.DrawLine(pen, rect.Left - 5, rect.Top, rect.Right + 5, rect.Top)
            g.DrawLine(pen, rect.Left - 5, rect.Bottom, rect.Right + 5, rect.Bottom)
            g.DrawLine(pen, rect.Left, rect.Top - 5, rect.Left, rect.Bottom + 5)
            g.DrawLine(pen, rect.Right, rect.Top - 5, rect.Right, rect.Bottom + 5)
            pen.Dispose()
        End If

        If _bZoomed Then
            Dim font As Font = New Font("Tahoma", 16)
            Dim textColorKeyed As Brush = New SolidBrush(Color.DarkBlue)
            g.DrawString("Zoom: " & Math.Round(_fZoomValue, 1).ToString("0.0") & "x", font, textColorKeyed, 4, 4)
            font.Dispose()
            textColorKeyed.Dispose()
        End If

        g.Dispose()
        Return bmp
    End Function

    Private Function IsMouseSelectionRectCorrect() As Boolean
        If Math.Abs(_MouseSelectionRect.right - _MouseSelectionRect.left) < Single.Epsilon * 10 OrElse Math.Abs(_MouseSelectionRect.bottom - _MouseSelectionRect.top) < Single.Epsilon * 10 Then
            Return False
        End If

        If _MouseSelectionRect.left >= _MouseSelectionRect.right OrElse _MouseSelectionRect.top >= _MouseSelectionRect.bottom Then
            Return False
        End If

        If _MouseSelectionRect.left < 0 OrElse _MouseSelectionRect.top < 0 OrElse _MouseSelectionRect.right > 1.0 OrElse _MouseSelectionRect.bottom > 1.0 Then
            Return False
        End If

        Return True
    End Function

    Private Function IsMouseSelectionRectCorrectAndGood() As Boolean
        If Not IsMouseSelectionRectCorrect() Then
            Return False
        End If

        If Math.Abs(_MouseSelectionRect.right - _MouseSelectionRect.left) < 0.1F OrElse Math.Abs(_MouseSelectionRect.bottom - _MouseSelectionRect.top) < 0.1F Then
            Return False
        End If

        Return True
    End Function

    Private Sub comboBoxCameraList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxCameraList.SelectedIndexChanged
        If comboBoxCameraList.SelectedIndex < 0 Then
            cameraControl.CloseCamera()
        Else
            SetCamera(_CameraChoice.Devices(comboBoxCameraList.SelectedIndex).Mon, Nothing)
        End If

        FillResolutionList()
    End Sub

    Private Sub comboBoxResolutionList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBoxResolutionList.SelectedIndexChanged
        If (Not cameraControl.CameraCreated) Then
            Exit Sub
        End If

        Dim comboBoxResolutionIndex = comboBoxResolutionList.SelectedIndex
        If (comboBoxResolutionIndex < 0) Then
            Exit Sub
        End If
        Dim resolutions As ResolutionList = Camera.GetResolutionList(cameraControl.Moniker)

        'If (resolutions Is Nullable) Then
        '    Exit Sub
        'End If
        If (comboBoxResolutionIndex >= resolutions.Count) Then
            Exit Sub
        End If

        If (0 = resolutions(comboBoxResolutionIndex).CompareTo(cameraControl.Resolution)) Then
            'this resolution Is already selected
            Exit Sub
        End If

        'Recreate camera
        SetCamera(cameraControl.Moniker, resolutions(comboBoxResolutionIndex))
    End Sub

    Private Sub cameraControl_OutputVideoSizeChanged(sender As Object, e As EventArgs) Handles cameraControl.OutputVideoSizeChanged
        UpdateCameraBitmap()
        UpdateUnzoomButton()
    End Sub

    Private Sub buttonSnapshotNextSourceFrame_Click(sender As Object, e As EventArgs) Handles buttonSnapshotNextSourceFrame.Click
        If Not cameraControl.CameraCreated Then Return
        Dim bitmap As Bitmap = Nothing

        Try
            bitmap = cameraControl.SnapshotOutputImage() '; cameraControl.SnapshotSourceImage()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error while getting a snapshot")
        End Try

        If bitmap Is Nothing Then Return

        'If (bitmap.Width = 720) Then
        '    Dim _selection As Rectangle
        '    _selection = New Rectangle(New Point(170, 40), New Size())
        '    _selection.Width = 525
        '    _selection.Height = 410
        '    Dim crop As Bitmap = bitmap.Clone(_selection, bitmap.PixelFormat)

        '    ImageList1.Images.Add(crop)
        'Else
        ImageList1.Images.Add(bitmap)
        'End If


        Dim sMaCLS As String = grdYC_CLS.GetData(grdYC_CLS.RowSel(), 0).ToString()
        'sMaCLS = grdYC_CLS.GetData(grdYC_CLS.RowSel, 0)
        Dim ivt As ListViewItem = New ListViewItem()
        ivt.ImageIndex = ImageList1.Images.Count - 1
        ListView1.Items.Add(ivt)
        ListView1.Refresh()
        Dim strNgay = String.Format("{0:dd}-{0:MM}-{0:yyyy}", txtThoigianCD.Value)
        Dim sTenBenhNhan = TenABC(txtTenbenhnhan.Text.Trim())
        Dim strPath = "D:\KetQua_CDHA\" + Ten_Nhom + "\" + strNgay + "\" + sTenBenhNhan + "_" + sMaCLS + "_" + txtSophieuCD.Text + "_" + ImageList1.Images.Count.ToString() + ".jpg" 'Path + "\" + txtSophieuCD.Text + "_" + grv_YeuCau.GetFocusedRowCellValue("MaCDHA").ToString() + "_" + ImageList1.Images.Count.ToString() + ".jpg"
        If System.IO.File.Exists(strPath) Then File.Delete(strPath)
        If Not System.IO.Directory.Exists("D:\KetQua_CDHA\" + Ten_Nhom + "\" + strNgay) Then
            System.IO.Directory.CreateDirectory("D:\KetQua_CDHA\" + Ten_Nhom + "\" + strNgay)
        End If
        bitmap.Save(strPath)

        '' Code Cut anh


    End Sub

    Private Sub frmKQ_ChanDoanHA_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        cameraControl.CloseCamera()
    End Sub

    Private Sub buttonClearSnapshotFrame_Click(sender As Object, e As EventArgs) Handles buttonClearSnapshotFrame.Click
        Dim sMaCLS As String = grdYC_CLS.GetData(grdYC_CLS.RowSel(), 0).ToString()
        Dim strNgay = String.Format("{0:dd}-{0:MM}-{0:yyyy}", txtThoigianCD.Value)
        Dim sTenBenhNhan = TenABC(txtTenbenhnhan.Text.Trim())
        For i = 0 To ListView1.Items.Count - 1
            Dim strPath = "D:\KetQua_CDHA\" + Ten_Nhom + "\" + strNgay + "\" + sTenBenhNhan + "_" + sMaCLS + "_" + txtSophieuCD.Text + "_" + (i + 1).ToString() + ".jpg" 'Path + "\" + txtSophieuCD.Text + "_" + grv_YeuCau.GetFocusedRowCellValue("MaCDHA").ToString() + "_" + ImageList1.Images.Count.ToString() + ".jpg"
            If System.IO.File.Exists(strPath) Then File.Delete(strPath)
        Next
        ListView1.Clear()
        ImageList1.Images.Clear()
    End Sub

    Private Sub btn_ChonAnh_Click(sender As Object, e As EventArgs) Handles btn_ChonAnh.Click
        If ListView1.Items.Count < 1 Then
            MessageBox.Show("Chưa có ảnh để chọn")
            Exit Sub
        End If
        RichEditControl1.Document.BeginUpdate()
        Dim Table As Table = RichEditControl1.Document.InsertTable(RichEditControl1.Document.CaretPosition, 1, ListView1.CheckedItems.Count, AutoFitBehaviorType.AutoFitToContents)

        Dim i = 0

        For Each lvIteam As ListViewItem In ListView1.Items
            If lvIteam.Checked = True Then
                Dim im_iTeam As Image = ImageList1.Images(lvIteam.ImageIndex)
                Dim newImage = New Bitmap(200, 200)

                Using gr = Graphics.FromImage(newImage)
                    gr.SmoothingMode = SmoothingMode.HighQuality
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality
                    gr.DrawImage(im_iTeam, New Rectangle(0, 0, 200, 200))
                End Using

                RichEditControl1.Document.InsertImage(Table.Range.Start, CType(newImage, Image))
                ''ClearBoreders(Table(0, i))
                i = i + 1
            End If

        Next

        'rec_Doc.Document.InsertImage(Table.Range.Start, ImageList1.Images(1))
        'ClearBoreders(Table(0, 1))
        RichEditControl1.Document.EndUpdate()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        RichEditControl1.Document.BeginUpdate()
        'Dim Table As Table = RichEditControl1.Document.InsertTable(RichEditControl1.Document.CaretPosition, 1, 1, AutoFitBehaviorType.AutoFitToContents)
        Dim sMaCLS As String = grdYC_CLS.GetData(grdYC_CLS.RowSel(), 0).ToString()
        Dim strNgay = String.Format("{0:dd}-{0:MM}-{0:yyyy}", txtThoigianCD.Value)
        Dim sTenBenhNhan = TenABC(txtTenbenhnhan.Text.Trim())
        Dim strPath = "D:\KetQua_CDHA\" + Ten_Nhom + "\" + strNgay + "\" + sTenBenhNhan + "_" + sMaCLS + "_" + txtSophieuCD.Text + "_" + (ListView1.FocusedItem.ImageIndex + 1).ToString() + ".jpg" 'Path + "\" + txtSophieuCD.Text + "_" + grv_YeuCau.GetFocusedRowCellValue("MaCDHA").ToString() + "_" + ImageList1.Images.Count.ToString() + ".jpg"
        ''strPath = "C:\Users\Admin\Desktop\New folder (2)\Phạm Thị Minh Phương_CD1808150006__7.jpg"
        'Dim i = 0

        'Dim im_iTeam As Image = ImageList1.Images(ListView1.FocusedItem.ImageIndex)
        Dim newImage = New Bitmap(150, 150)
        Dim im_iTeam As Image = Image.FromFile(strPath)

        Using gr = Graphics.FromImage(newImage)
            gr.SmoothingMode = SmoothingMode.HighQuality
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality
            gr.DrawImage(im_iTeam, New Rectangle(0, 0, 150, 150))
        End Using

        ''chen anh
        Dim myPic As DocumentImage = RichEditControl1.Document.InsertImage(RichEditControl1.Document.CaretPosition, DevExpress.XtraRichEdit.API.Native.DocumentImageSource.FromFile(strPath))
        myPic.ScaleX = 2.5 / 10
        myPic.ScaleY = 2.5 / 10
        'RichEditControl1.Document.EndUpdate()
        ''=====================
        'Dim doc = RichEditControl1.Document
        'Dim Shape = doc.Shapes.InsertPicture(doc.Range.Start, DocumentImageSource.FromFile("img.png"))
        'Shape.ScaleX = doc.Sections(0).Page.Width / Shape.OriginalSize.Width

        ''Code moi cho 1 anh
        'RichEditControl1.Document.BeginUpdate()


        'Dim tb As Shape = RichEditControl1.Document.InsertTextBox(RichEditControl1.Document.CaretPosition)
        'tb.Size = New Size(600, 600) ' SizeF(1.0F, 1.0F)
        'Dim myPic As DocumentImage = tb.TextBox.Document.InsertImage(tb.TextBox.Document.CreatePosition(2), DevExpress.XtraRichEdit.API.Native.DocumentImageSource.FromFile(strPath))
        'myPic.ScaleX = tb.Size.Width / myPic.OriginalSize.Width
        'myPic.ScaleY = tb.Size.Height / myPic.OriginalSize.Height
        ''''tb.HorizontalAlignment = ShapeHorizontalAlignment.Center
        ''tb.Line.Thickness = 0.75F
        'tb.Line.Color = Color.Black
        ''tb.Fill.Color = Color.Red
        'tb.RelativeHorizontalPosition = ShapeRelativeHorizontalPosition.Character
        'tb.RelativeVerticalPosition = ShapeRelativeVerticalPosition.Line

        ''Code moi
        'Dim shapes = RichEditControl1.Document.GetShapes(RichEditControl1.Document.Range)
        'For Each shape As Shape In shapes
        '    If (shape.TextBox IsNot Nothing) Then
        '        Dim textBox As API.Native.TextBox = shape.TextBox
        '        Dim subDocument As SubDocument = textBox.Document
        '        subDocument.BeginUpdate()
        '        Dim myPic As DocumentImage = subDocument.InsertImage(subDocument.Range.Start, DevExpress.XtraRichEdit.API.Native.DocumentImageSource.FromFile(strPath))
        '        myPic.ScaleX = (shape.Size.Width / myPic.OriginalSize.Width) - 0.016
        '        myPic.ScaleY = (shape.Size.Height / myPic.OriginalSize.Height) - 0.01
        '        subDocument.EndUpdate()
        '    End If
        'Next

        RichEditControl1.Document.EndUpdate()

    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        If e.KeyCode <> Keys.Delete Then Exit Sub
        Dim sTenBenhNhan = TenABC(txtTenbenhnhan.Text.Trim())
        Dim sMaCLS As String = grdYC_CLS.GetData(grdYC_CLS.RowSel(), 0).ToString()
        Dim strNgay = String.Format("{0:dd}-{0:MM}-{0:yyyy}", txtThoigianCD.Value)
        Dim iIndex = ListView1.FocusedItem.ImageIndex
        Dim strPath = "D:\KetQua_CDHA\" + Ten_Nhom + "\" + strNgay + "\" + sTenBenhNhan + "_" + sMaCLS + "_" + txtSophieuCD.Text + "_" + (iIndex + 1).ToString() + ".jpg"
        If System.IO.File.Exists(strPath) Then File.Delete(strPath)

        For i = iIndex + 1 To ListView1.Items.Count
            strPath = "D:\KetQua_CDHA\" + Ten_Nhom + "\" + strNgay + "\" + sTenBenhNhan + "_" + sMaCLS + "_" + txtSophieuCD.Text + "_" + (i).ToString() + ".jpg"
            Dim NewstrPath = "D:\KetQua_CDHA\" + Ten_Nhom + "\" + strNgay + "\" + sTenBenhNhan + "_" + sMaCLS + "_" + txtSophieuCD.Text + "_" + (i - 1).ToString() + ".jpg"
            If System.IO.File.Exists(strPath) Then FileSystem.Rename(strPath, NewstrPath)
        Next
        ImageList1.Images.RemoveAt(iIndex)
        ListView1.Items.Clear()
        For i = 0 To ImageList1.Images.Count - 1
            Dim ivt As ListViewItem = New ListViewItem()
            ivt.ImageIndex = i
            ListView1.Items.Add(ivt)
        Next
        'For i = iIndex To ListView1.Items.Count - 1
        '    ImageList1.Images.Item(i) = ImageList1.Images.Item(i + 1)
        '    ListView1.Items.Item(i) = ListView1.Items.Item(i + 1)
        'Next
        'ListView1.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim sv_AnBinh As New AnBinh.svAnBinh
        'Dim sv_Result As New AnBinh.ResultObject
        'sv_Result.OrderCode = txtSophieuCD.Text.Trim()
        'sv_Result.Description = ""
        'sv_Result.OrderResult = txtKetluan.Text.Trim()
        'sv_Result.ResultDate = String.Format("{0:MM/dd/yyyy HH:mm}", DateTime.Now)
        'sv_Result.ResultEmployee = "Employee"
        'sv_Result.ResultMachine = "001"
        ''If (sv_PASC.SendOrder(sv_order).Code = 0) Then
        ''    MessageBox.Show("Gửi dữ liệu thành công!")
        ''End If
        'Dim sMessage = sv_AnBinh.UpDateResult(sv_Result).Message
        mdlFunction.Save_Text(Me, "vi", Cn)
    End Sub
End Class