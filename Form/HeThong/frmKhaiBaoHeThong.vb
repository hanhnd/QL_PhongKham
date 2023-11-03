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
Public Class frmKhaiBaoHeThong
    Private Sub frmKhaiBaoHeThong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim SQLStr As String
        Dim Cmd1 As SqlCommand
        Dim Adap1 As SqlDataAdapter
        Dim DsDM As DataSet
        Dim i
        Dim ChonDT As Boolean
        'SQLStr = "Select MaDT, TenDT from DMDOITUONGBN where  Nutla = 1"
        'Cmd1 = New SqlCommand(SQLStr, Cn)
        'Adap1 = New SqlDataAdapter
        'Adap1.SelectCommand = Cmd1
        'DsDM = New DataSet
        'Adap1.Fill(DsDM, "DMDOITUONGBN")
        'Cmd1.Dispose()
        'grdDoituong.Rows.Count = 1
        'If DsDM.Tables("DMDOITUONGBN").Rows.Count > 0 Then
        '    For i = 0 To DsDM.Tables("DMDOITUONGBN").Rows.Count - 1
        '        ChonDT = IIf(InStr(GetSetting("PHONGKHAM", "Thuoctinh", "DTKhongduocchon", ""), DsDM.Tables("DMDOITUONGBN").Rows(i).Item("MaDT")) > 0, False, True)
        '        grdDoituong.AddItem(DsDM.Tables("DMDOITUONGBN").Rows(i).Item("MaDT") & vbTab & DsDM.Tables("DMDOITUONGBN").Rows(i).Item("TenDT") & vbTab & ChonDT)
        '    Next
        'End If
        'chkTuyen.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Tuyen", "1") = "1", True, False)
        'chkSotheBHYT.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_SotheBHYT", "1") = "1", True, False)
        'chkNoidangkyBHYT.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_NoidangkyBHYT", "1") = "1", True, False)
        'chkDoituongBHYT.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_DoituongBHYT", "1") = "1", True, False)
        'chkHandungtheBHYTTu.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_HandungBHYTTu", "1") = "1", True, False)
        'chkHandungtheBHYT.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_HandungBHYT", "1") = "1", True, False)
        'chkNoicaptheBHYT.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_NoicapBHYT", "1") = "1", True, False)

        'chkDiachi.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Diachi", "1") = "1", True, False)
        'chkCapbac.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Capbac", "1") = "1", True, False)
        'chkNghenghiep.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Nghenghiep", "1") = "1", True, False)
        'chkNoilamviec.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Noilamviec", "1") = "1", True, False)
        'chkLienhe.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Lienhe", "1") = "1", True, False)
        'chkTheTE.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_TheTE", "1") = "1", True, False)
        'chkNoigioithieu.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_Noigioithieu", "1") = "1", True, False)
        'chkChandoanNGT.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "enab_ChandoanNGT", "1") = "1", True, False)
        txt_TenPK.Text = GetSetting("PHONGKHAM", "Thuoctinh", "TenPhongKham", "")
        txt_DiaChi.Text = GetSetting("PHONGKHAM", "Thuoctinh", "DiaChiPhongKham", "")
        txt_SDT.Text = GetSetting("PHONGKHAM", "Thuoctinh", "SoDienThoaiPhongKham", "")
        txt_Email.Text = GetSetting("PHONGKHAM", "Thuoctinh", "EmailPhongKham", "")
        mdlFunction.Set_Text(Me, Lang)
        'txtMaDKKCBBD.Text = GetSetting("PHONGKHAM", "Thuoctinh", "MaDKKCBBD", "")
        'txtTraiTuyen.Text = GetSetting("PHONGKHAM", "Thuoctinh", "TraiTuyen", "100")
        'optInLazer.Checked = IIf(GetSetting("PHONGKHAM", "Thuoctinh", "InPK_Lazer", "1") = "1", True, False)

        'txtFTP_IP.Text = GetSetting("PHONGKHAM", "Thuoctinh", "FTP_IP", "")
        'txtFTP_User.Text = GetSetting("PHONGKHAM", "Thuoctinh", "FTP_User", "")
        'txtFTP_Pass.Text = GetSetting("PHONGKHAM", "Thuoctinh", "FTP_Pass", "")
        'mnTienLuong.Value = Decimal.Parse(GetSetting("PHONGKHAM", "Thuoctinh", "LuongToiThieu", 0))

        'optInNhiet.Checked = Not optInLazer.Checked
    End Sub

    Private Sub cmdThongke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThuchien.Click
        Dim i
        'SaveSetting("PHONGKHAM", "Thuoctinh", "DTKhongduocchon", KhongChonDT)
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_Tuyen", IIf(chkTuyen.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_SotheBHYT", IIf(chkSotheBHYT.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_NoidangkyBHYT", IIf(chkNoidangkyBHYT.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_DoituongBHYT", IIf(chkDoituongBHYT.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_HandungBHYTTu", IIf(chkHandungtheBHYTTu.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_HandungBHYT", IIf(chkHandungtheBHYT.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_NoicapBHYT", IIf(chkNoicaptheBHYT.Checked, "1", "0"))

        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_Diachi", IIf(chkDiachi.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_Capbac", IIf(chkCapbac.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_Nghenghiep", IIf(chkNghenghiep.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_Noilamviec", IIf(chkNoilamviec.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_Lienhe", IIf(chkLienhe.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_TheTE", IIf(chkTheTE.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_Noigioithieu", IIf(chkNoigioithieu.Checked, "1", "0"))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "enab_ChandoanNGT", IIf(chkChandoanNGT.Checked, "1", "0"))

        SaveSetting("PHONGKHAM", "Thuoctinh", "TenPhongKham", txt_TenPK.Text.Trim())
        TenPK = txt_TenPK.Text.Trim
        SaveSetting("PHONGKHAM", "Thuoctinh", "DiaChiPhongKham", txt_DiaChi.Text.Trim())
        DiachiPK = txt_DiaChi.Text.Trim
        SaveSetting("PHONGKHAM", "Thuoctinh", "SoDienThoaiPhongKham", txt_SDT.Text.Trim())
        SoDienThoaiPK = txt_SDT.Text.Trim
        SaveSetting("PHONGKHAM", "Thuoctinh", "EmailPhongKham", txt_Email.Text.Trim())
        EmailPK = txt_Email.Text.Trim
        'SaveSetting("PHONGKHAM", "Thuoctinh", "MaDKKCBBD", txtMaDKKCBBD.Text.Trim())
        'MaDKKCBBD = txtMaDKKCBBD.Text.Trim()
        'SaveSetting("PHONGKHAM", "Thuoctinh", "TraiTuyen", txtTraiTuyen.Text.Trim())
        'PhanTram_TraiTuyen = Byte.Parse(IIf(txtTraiTuyen.Text.Trim = "", "100", txtTraiTuyen.Text.Trim()))
        'SaveSetting("PHONGKHAM", "Thuoctinh", "InPK_Lazer", IIf(optInLazer.Checked, "1", "0"))

        'Thong tin ve FTP Server
        'SaveSetting("PHONGKHAM", "Thuoctinh", "FTP_IP", txtFTP_IP.Text.Trim())
        'SaveSetting("PHONGKHAM", "Thuoctinh", "FTP_User", txtFTP_User.Text.Trim())
        'SaveSetting("PHONGKHAM", "Thuoctinh", "FTP_Pass", txtFTP_Pass.Text.Trim())
        'SaveSetting("PHONGKHAM", "Thuoctinh", "LuongToiThieu", mnTienLuong.Value.ToString())
        'LuongToiThieu = Double.Parse(mnTienLuong.Value)
        'ftpServerIP = txtFTP_IP.Text.Trim()
        'ftpUserID = txtFTP_User.Text.Trim()
        'ftpPassword = txtFTP_Pass.Text.Trim()
        MsgBox("Update successful", MsgBoxStyle.Information, "Message!")
    End Sub

    Private Sub cmdThoat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Dispose()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        mdlFunction.Save_Text(Me, "vi", Cn)
    End Sub
End Class


