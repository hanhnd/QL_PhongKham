Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports VB6 = Microsoft.VisualBasic
Imports System.Globalization
Module mdlHeThong
    Public Cn As SqlConnection
    Public ConnectionStr As String
    Public TenMayChu As String
    Public TenDangNhap As String
    Public MaKhoaphong As String
    Public TenKhoaphong As String
    Public Khoa_CapNhat As String
    Public Nhom As String
    Public Tendaydu As String
    Public MatKhau As String
    Public MaDKKCBBD As String
    Public TenPK As String
    Public DiachiPK As String
    Public SoDienThoaiPK As String
    Public EmailPK As String
    Public TinhTP As String
    Public TenHeThong As String
    Public TenDatabase As String
    Public NgayHienTai As Date
    Public Path As String
    Public Cumden As String
    Public SoPhongKham As String
    Public HUBden As Byte
    Public PhanTram_TraiTuyen As Byte
    Public frmKB As New frmKhamBenh
    Public frmMain As New frmMain
    Public Row_Height = 25
    Public ftpServerIP As String = "192.168.1.200"
    Public ftpUserID As String = "huy"
    Public ftpPassword As String = "1111"
    Public LuongToiThieu As Double
    Public HanMuc As Double
    Public Lang As String = "vi"

    Sub New()
        NgayHienTai = GetSrvDate()
        TenHeThong = "PHONGKHAM"
        TenDatabase = "PK_RutGon"
        MaDKKCBBD = GetSetting("PHONGKHAM", "Thuoctinh", "MaDKKCBBD", "")
        TenPK = "PK ......"
        'GetSetting("PHONGKHAM", "Thuoctinh", "TenPhongKham", "")
        DiachiPK = "Số ..., ...., ...."
        TinhTP = "Hà Nội"
        PhanTram_TraiTuyen = 0
        LuongToiThieu = Decimal.Parse(GetSetting("PHONGKHAM", "Thuoctinh", "LuongToiThieu", 0))
        HanMuc = 0.15 * LuongToiThieu
    End Sub
End Module

