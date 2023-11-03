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
Public Class frmKB_DanhSachBNKhamBenh ' Tên cũ frmBangtheodoiDangky
    Private Sub SetPos_Start()
        With grdThongkeBN
            .Rows.Count = 1
            .Cols.Count = 9
            .Rows.Fixed = 1
            .Item(0, 0) = "TT"
            .Item(0, 1) = "Họ và tên"
            .Item(0, 2) = "Năm sinh"
            .Item(0, 3) = "Giới tính"
            .Item(0, 4) = "Địa chỉ"
            .Item(0, 5) = "Ngày Khám"
            .Item(0, 6) = "Mã số khám"
            .Item(0, 7) = "Mã số bệnh nhân"
            .Item(0, 8) = "Triệu chứng"
        End With
    End Sub
    Private Sub DocDM()
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet
        Dim i As Long
        Adap1 = New SqlDataAdapter
        Adap1.SelectCommand = Cmd1
        DsDM = New DataSet
        
    End Sub
    Private Sub frmThongke_Khambenh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPos_Start()
        DocDM()
        txtNgaykham.Value = GetSrvDate()
        txtDen.Value = GetSrvDate()
        cmbPhongkham.Visible = False
        mdlFunction.Set_Text(Me, Lang)
        mdlFunction.Set_Text_FlexGrid(Me, grdThongkeBN, Lang)
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub cmdInDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInDS.Click
        grdThongkeBN.SaveExcel("C:\Dangkykham.xls", "Danh sach", FileFlags.IncludeFixedCells)
        MsgBox("Đã lưu vào file: C:\Dangkykham.xls")
    End Sub

    Private Sub cmdThongke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThongke.Click
        Dim SQl As String
        Dim Cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim i As Integer
        Dim temp, tempKhoa As String
        If chkTheoNVTD.Checked Then
            temp = " and CD.NhanvienCD = '" & TenDangNhap & "'"
        Else
            temp = ""
        End If
        If cmbPhongkham.SelectedIndex <> -1 Then
            tempKhoa = " where Khoathuchien = '" & cmbPhongkham.SelectedValue & "'"
        Else
            tempKhoa = ""
        End If
        If txtNgaykham.ValueIsDbNull Or txtDen.ValueIsDbNull Then Exit Sub
        'SQl = " Select tblBenhnhan.Mabenhnhan, Tenbenhnhan,Namsinh, case Gioitinh when 1 then 'Nam' else N'Nữ' end as Gioitinh, (SotheBHYT + Doituongthe + NoidangkyKCBBD ) as TheBH," _
        '& " HantheBHYT_Tu, HantheBHYT_den, Noigioithieu, Diachi from " _
        '& " (Select MaKhambenh from tblKhambenh_Chidinh CD " _
        '& " where left(CD.MaphieuCD,2) = 'PK' and  CD.ThoigianCD between  '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "'and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "' " & temp & " )Q " _
        '& " left outer join tblKhambenh on Q.MaKhambenh = tblKhambenh.MaKhambenh inner join tblBenhnhan on tblBenhnhan.Mabenhnhan = tblKhambenh.Mabenhnhan "

        'SQl = " Select tblBenhnhan.Mabenhnhan, Tenbenhnhan,Namsinh, case Gioitinh when 1 then 'Nam' else N'Nữ' end as Gioitinh, (SotheBHYT + Doituongthe + NoidangkyKCBBD ) as TheBH," _
        '& " HantheBHYT_Tu, HantheBHYT_den, Noigioithieu, Diachi from " _
        '& " (Select CD.MaKhambenh from tblKhambenh_Chidinh CD inner join (select * from tblKHAMBENH_KQDVKHAM " & tempKhoa & ") KQ  on CD.MaphieuCD = KQ.MaphieuCD " _
        '& " where left(CD.MaphieuCD,2) = 'PK' and  CD.ThoigianCD between  '" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "'and '" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "' " & temp & " )Q " _
        '& " left outer join tblKhambenh on Q.MaKhambenh = tblKhambenh.MaKhambenh inner join tblBenhnhan on tblBenhnhan.Mabenhnhan = tblKhambenh.Mabenhnhan "
        ' & " --OR KB.MaKhamBenh in (SELECT MaKhamBenh FROM tblKHAMBENH_DICHVU) " _ & " OR KB.MaKhamBenh in (SELECT MaKhamBenh FROM tblKhamBenh_ChiDinh) " _

        SQl = "SELECT distinct KB.[MaKhambenh]" _
        & " ,KB.[MaBenhnhan] " _
          & " ,KB.[ThoigianDangky] " _
          & " ,BN.TenBenhNhan " _
          & " ,BN.NamSinh " _
          & " ,case Gioitinh when 1 then 'Nam' else N'Nữ' end as Gioitinh " _
          & " , Diachi,TrieuChung  " _
          & " FROM [dbo].[tblKHAMBENH] KB inner join tblBenhNhan BN " _
          & " on KB.MaBenhNhan = BN.MaBenhNhan " _
          & " where datediff(dd,thoigiandangky,'" & Format(txtNgaykham.Value, "MM/dd/yyyy HH:mm") & "') <=0 and datediff(dd,thoigiandangky,'" & Format(txtDen.Value, "MM/dd/yyyy HH:mm") & "') >=0 " _
         & " AND( KB.MaKhamBenh in (SELECT MaKhamBenh FROM tblKHAMBENH_DONTHUOC) " _
         & " OR KB.MaKhamBenh in (SELECT Nguoinop_Maso FROM tblPHIEUTHANHTOAN)) " _
        'If cmbDoituong.SelectedIndex <> -1 Then
        '    SQl &= " where tblKhambenh.Doituong = '" & cmbDoituong.SelectedValue & "'"
        'End If
        Cmd = New SqlCommand(SQl, Cn)
        Cmd.CommandTimeout = 0
        rd = Cmd.ExecuteReader
        grdThongkeBN.Rows.Count = 1
        grdThongkeBN.Redraw = False
        Do While rd.Read
            i = i + 1
            grdThongkeBN.AddItem(Trim(Str(i)) & vbTab & rd!Tenbenhnhan.ToString & vbTab & rd!Namsinh & vbTab & rd!Gioitinh.ToString & vbTab & rd!Diachi.ToString & vbTab & String.Format("{0: dd/MM/yyyy HH:mm}", rd!ThoigianDangky.ToString) & vbTab & rd!MaKhambenh.ToString & vbTab & rd!MaBenhnhan.ToString & vbTab & rd!TrieuChung.ToString())
        Loop
        rd.Close()
        rd = Nothing
        grdThongkeBN.Redraw = True
        grdThongkeBN.AutoSizeCols()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
        mdlFunction.Save_Text_FlexGrid(Me, grdThongkeBN, "vi", Cn)
    End Sub
End Class