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
Public Class frmLogin
    'Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDangNhap.Click
    '    Try
    '        ' Connection database 
    '        Application.EnableVisualStyles()
    '        Application.CurrentCulture = New System.Globalization.CultureInfo("vi-VN", False)
    '        Cn = New System.Data.SqlClient.SqlConnection()
    '        ConnectionStr = String.Format("Data Source={0};Initial Catalog=" + TenDatabase + "; User ID= sa; Password=", txtTenMayChu.Text.Trim)
    '        Cn.ConnectionString = ConnectionStr
    '        Cn.Open()

    '        ' Kiểm tra Uname, Pass --------------------------
    '        Dim SQLCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
    '        SQLCmd.Connection = Cn
    '        Dim dr As System.Data.SqlClient.SqlDataReader
    '        SQLCmd.CommandText = String.Format("SELECT SYSUSER.*,TenKhoa FROM SYSUSER INNER JOIN DMKHOAPHONG ON MaKhoa=KhoaPhong WHERE UName=N'{0}'", txtTenDangNhap.Text.Trim)
    '        dr = SQLCmd.ExecuteReader()
    '        If Not (dr.HasRows) Then
    '            dr.Close()
    '            MessageBox.Show("Sai tên đăng nhập.", "Message!")
    '            Exit Sub
    '        End If
    '        dr.Read()
    '        If getMd5Hash(txtMatKhau.Text) <> dr!Pass.ToString() Then
    '            MessageBox.Show("Sai mật khẩu, đề nghị kiểm tra lại!", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            dr.Close()
    '            Exit Sub
    '        End If
    '        dr.Close()
    '        '--------------
    '        TenMayChu = txtTenMayChu.Text.Trim
    '        TenDangNhap = txtTenDangNhap.Text.Trim
    '        MatKhau = txtMatKhau.Text.Trim
    '        NgayHienTai = GetSrvDate()
    '        If Year(NgayHienTai) = 2015 Then Exit Sub
    '        SaveSetting("PHONGKHAM", "Thuoctinh", "Tenmaychu", TenMayChu)
    '        SaveSetting("PHONGKHAM", "Thuoctinh", "Tendangnhap", TenDangNhap)
    '        If chkNhoMatKhau.Checked Then
    '            SaveSetting("PHONGKHAM", "Thuoctinh", "Matkhau", MatKhau)
    '        Else
    '            SaveSetting("PHONGKHAM", "Thuoctinh", "Matkhau", "")
    '        End If
    '        frmMain.Show()
    '        Me.Visible = False
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDangNhap.Click
        If LogedIn Then
            Return
        End If
        Dim ConnectSQL As System.Data.SqlClient.SqlConnection = Nothing
        Try
            'Connection database 
            Application.EnableVisualStyles()
            Application.CurrentCulture = New System.Globalization.CultureInfo("vi-VN", False)
            Cn = New System.Data.SqlClient.SqlConnection()
            ConnectionStr = String.Format("Data Source={0};Initial Catalog=" + TenDatabase + "; User ID= sa; Password=", txtTenMayChu.Text.Trim)
            Cn.ConnectionString = ConnectionStr
            Cn.Open()

            ' Kiểm tra Uname, Pass --------------------------
            Dim SQLCmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
            SQLCmd.Connection = Cn
            Dim dr As System.Data.SqlClient.SqlDataReader
            SQLCmd.CommandText = String.Format("SELECT SYSUSER.*,TenKhoa FROM SYSUSER INNER JOIN DMKHOAPHONG ON MaKhoa=KhoaPhong WHERE UName=N'{0}'", txtTenDangNhap.Text.Trim)
            dr = SQLCmd.ExecuteReader()
            If Not (dr.HasRows) Then
                dr.Close()
                MessageBox.Show("Sai tên đăng nhập.", "Message!")
                Exit Sub
            End If
            dr.Read()
            If getMd5Hash(txtMatKhau.Text) <> dr!Pass.ToString() Then
                MessageBox.Show("Sai mật khẩu, đề nghị kiểm tra lại!", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                Exit Sub
            End If
            dr.Close()

            NgayLV = DateTime.Parse(txtNgayLV.Value.ToString()).[Date]
            Dim m_FileInfo As New FileInfo(Application.StartupPath + "\BV354_QLBV.ini")
            'Khoi tao file log
            Dim LogFile As New FileInfo(Application.StartupPath + "\LogFile.log")
            If Not LogFile.Exists Then
                LogFile.Create()
            End If
            Dim m_FileWrite As StreamWriter = m_FileInfo.CreateText()
            m_FileWrite.WriteLine(txtTenMayChu.Text)
            m_FileWrite.WriteLine(txtTenDangNhap.Text)
            m_FileWrite.Close()
            glbUName = txtTenDangNhap.Text
            'Kiem tra version cac file xem co can update hay khong?
            dr.Close()
            LogedIn = True
            SQLCmd.CommandText = String.Format("Select FileName FROM {0} WHERE Filename<>'LoginTHBC.EXE'", TabName)
            dr = SQLCmd.ExecuteReader()
            Dim NumOfFiles As Integer = 0
            Array.Resize(ListFileUpdate, 0)
            While dr.Read()
                NumOfFiles += 1
                Array.Resize(ListFileUpdate, NumOfFiles)
                ListFileUpdate(NumOfFiles - 1) = dr("FileName").ToString()
            End While
            dr.Close()
            For i As Integer = 0 To ListFileUpdate.GetUpperBound(0)
                UpdateFile(ListFileUpdate(i).ToUpper(), ConnectSQL)
            Next
            SQLCmd.Dispose()
            Cn.Close()
            Cn.Dispose()
        Catch ex As Exception
            MessageBox.Show("Không thể truy cập đến máy chủ cơ sở dữ liệu" & vbLf + ex.Message, "Lỗi truy cập", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Function UpdateFile(ByVal FileName As String, ByVal ConnectSQL As System.Data.SqlClient.SqlConnection) As Boolean
        Dim FileExists As Boolean = True
        Dim DBFileVersion As String = ""
        Dim cmd As System.Data.SqlClient.SqlCommand = Nothing
        Try
            If Not File.Exists(Application.StartupPath + "\" & FileName) Then
                MessageBox.Show("Không tìm thấy file [" & FileName & "]" & vbLf & "Bấm OK để tải về từ máy chủ.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FileExists = False
            End If
            Dim FileVersion As String = ""
            If FileExists Then
                If FileName.Substring(FileName.Length - 3).ToUpper() = "XLS" Then
                    FileVersion = String.Format("{0:yyyy.MM.dd.HH.mm}", File.GetLastWriteTime(Application.StartupPath + "\" & FileName))
                Else
                    FileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\" & FileName).FileVersion
                End If
            End If
            Dim dr As System.Data.SqlClient.SqlDataReader
            cmd = New System.Data.SqlClient.SqlCommand()
            cmd.Connection = ConnectSQL
            cmd.CommandText = "SELECT FileVersion FROM " & TabName & " WHERE UPPER(FileName)='" & FileName & "'"
            dr = cmd.ExecuteReader()
            If dr.Read() Then
                DBFileVersion = dr("FileVersion").ToString()
            End If
            dr.Close()
            If String.Compare(FileVersion, DBFileVersion) < 0 Then
                cmd.CommandText = "SELECT FileData FROM " & TabName & " WHERE UPPER(Filename)='" & FileName & "'"
                Dim buffer As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())
                If buffer IsNot Nothing Then
                    Dim OutputStream As Stream = File.OpenWrite(Application.StartupPath + "\tmpFileUpdate")
                    OutputStream.Write(buffer, 0, buffer.Length)
                    OutputStream.Close()
                    If FileExists Then
                        File.Copy(Application.StartupPath + "\" & FileName, Application.StartupPath + "\BackupOf" & FileName, True)
                    End If
                    File.Copy(Application.StartupPath + "\tmpFileUpdate", Application.StartupPath + "\" & FileName, True)
                    If FileName.Substring(FileName.Length - 3).ToUpper() = "XLS" Then
                        Dim tmpDate As String = DBFileVersion.Substring(0, 4) & "-" & DBFileVersion.Substring(5, 2) & "-" & DBFileVersion.Substring(8, 2) & " " & DBFileVersion.Substring(11, 2) & ":" & DBFileVersion.Substring(14, 2) & ":00"
                        File.SetLastWriteTime(Application.StartupPath + "\" & FileName, DateTime.Parse(tmpDate))
                    End If
                    File.Delete(Application.StartupPath + "\tmpFileUpdate")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error occured" & vbLf + ex.Message, "Error")
        Finally
            If cmd IsNot Nothing Then
                cmd.Dispose()
            End If
        End Try
        Return True
    End Function
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThoat.Click
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtTenMayChu.Text = GetSetting("PHONGKHAM", "Thuoctinh", "Tenmaychu", txtTenMayChu.Text)
        txtTenDangNhap.Text = GetSetting("PHONGKHAM", "Thuoctinh", "Tendangnhap", txtTenDangNhap.Text)
        txtMatKhau.Text = GetSetting("PHONGKHAM", "Thuoctinh", "Matkhau", "")
        txtMatKhau.Select()
    End Sub
End Class
